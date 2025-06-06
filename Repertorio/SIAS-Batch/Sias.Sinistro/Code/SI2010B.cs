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
using Sias.Sinistro.DB2.SI2010B;

namespace Code
{
    public class SI2010B
    {
        public bool IsCall { get; set; }

        public SI2010B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                       */
        /*"      *   DOCUMENTO    :    CAD.12402                                         */
        /*"      *   SISTEMA      :    SINISTRO                                          */
        /*"      *   PROGRAMA     :    SI2010B                                           */
        /*"      *   OBJETIVO     :    RELATORIO PARA PRODUTO 1803, APRESENTANDO         */
        /*"      *                :    OS VALORES PAGOS DE SINISTROS, HONOR�RIOS,        */
        /*"      *                     E DESPESAS DOS PRESTADORES DELPHOS, GM,           */
        /*"      *                     JOPEMA E LONDRINA VISTORIAS.                      */
        /*"      *   ANALISTA     :    JOSE G OLIVEIRA                                   */
        /*"      *   ANALISTA     :    JANAINA                                           */
        /*"      *   DATA         :    JULHO/2008                                        */
        /*"      *                                                                       */
        /*"      *   VERSAO       :    WS-VERSAO                                         */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 02 - CAD 95.992                                              */
        /*"      *              - INCLUIR PRODUTO 1805 (CCA)                             */
        /*"      *   EM 31/03/2014 -  DAIRO LOPES                                        */
        /*"      *                                            PROCURE POR V.02           */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 01 - CAD 10.003                                              */
        /*"      *                                                                       */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10                      */
        /*"      *                                                                       */
        /*"      *   EM 26/09/2013 -  ROGERIO PEREIRA                                    */
        /*"      *                                                                       */
        /*"      *                                            PROCURE POR V.01           */
        /*"      *-----------------------------------------------------------------      */
        /*"      * RECOMPILACAO - 23/05/2014 WELLINGTON F R C VERAS - TE39902     *      */
        /*"      *                ALTERACAO NAS SUBROTINAS FI0100S E FI0101S A    *      */
        /*"      * CADMUS:        A ALIQUOTA DE RETENCAO DO ISS EM BELO HORIZONTE *      */
        /*"      * C98258         DE 2% PARA 2,5 %. LEI N� 10.692.                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI2010B1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI2010B1
        {
            get
            {
                _.Move(REG_SI2010B1, _SI2010B1); VarBasis.RedefinePassValue(REG_SI2010B1, _SI2010B1, REG_SI2010B1); return _SI2010B1;
            }
        }
        /*"01  REG-SI2010B1.*/
        public SI2010B_REG_SI2010B1 REG_SI2010B1 { get; set; } = new SI2010B_REG_SI2010B1();
        public class SI2010B_REG_SI2010B1 : VarBasis
        {
            /*"    05          LINHA              PIC  X(230).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "230", "X(230)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  APO-NUMBIL                  PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis APO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  APO-CODCLIEN                PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis APO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  CONG-CONGENER               PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis CONG_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CONG-NOMECONG               PIC  X(040).*/
        public StringBasis CONG_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  M-NUM-APOLICE               PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis M_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  M-NUM-APO-SINI              PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis M_NUM_APO_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  M-RAMO                      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis M_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  M-FONTE                     PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis M_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  M-CODPRODU                  PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis M_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  M-CODPRODU-NULL             PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis M_CODPRODU_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  M-DATORR                    PIC  X(010).*/
        public StringBasis M_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  M-NUMIRB                    PIC S9(011)     VALUE +0 COMP-3.*/
        public IntBasis M_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77  M-AVIIRB                    PIC  X(010).*/
        public StringBasis M_AVIIRB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  H-TIPREG                    PIC  X(001).*/
        public StringBasis H_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  H-DTMOVTO                   PIC  X(010).*/
        public StringBasis H_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  H-NUM-APO-SINI              PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis H_NUM_APO_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  H-OPERACAO                  PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis H_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  H-VAL-OPERACAO              PIC S9(013)V99  VALUE +0 COMP-3.*/
        public DoubleBasis H_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  H-CODPSVI                   PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis H_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  H-CONGENER                  PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis H_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  H-NOMFAV                    PIC  X(040).*/
        public StringBasis H_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  H-FONPAG                    PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis H_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  H-TIPFAV                    PIC  X(001).*/
        public StringBasis H_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  H-LIMCRR                    PIC  X(010).*/
        public StringBasis H_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  H-FONPAG-ANT                PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis H_FONPAG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SIST-DTMOVABE               PIC  X(010).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  GEFONTE-FONTE               PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis GEFONTE_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  GEFONTE-NOMEFTE             PIC  X(040).*/
        public StringBasis GEFONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  GEFONTE-CIDADE              PIC  X(020).*/
        public StringBasis GEFONTE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77  V1CLIE-TPPESSOA             PIC  X(001).*/
        public StringBasis V1CLIE_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V1CLIE-CGCCPF               PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V1CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V1CLIE-CODCLIEN             PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis V1CLIE_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1CLIE-NOME-RAZAO           PIC  X(040).*/
        public StringBasis V1CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  WS-VERSAO                   PIC  X(040)     VALUE              'SI2010B - VERSAO:11011008 - 18:00HS'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SI2010B - VERSAO:11011008 - 18:00HS");
        /*"  03    LC01.*/
        public SI2010B_LC01 LC01 { get; set; } = new SI2010B_LC01();
        public class SI2010B_LC01 : VarBasis
        {
            /*"    05  FILLER                   PIC  X(007) VALUE 'SI2010B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI2010B");
            /*"    05  FILLER                   PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"    05  FILLER                   PIC  X(039) VALUE        '       CAIXA SEGUROS '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"       CAIXA SEGUROS ");
            /*"    05  FILLER                   PIC  X(014) VALUE SPACES.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
            /*"    05  LC01-DATA-DD             PIC  X(002) VALUE SPACES.*/
            public StringBasis LC01_DATA_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05  FILLER                   PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05  LC01-DATA-MM             PIC  X(002) VALUE SPACES.*/
            public StringBasis LC01_DATA_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05  FILLER                   PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05  LC01-DATA-AA             PIC  X(004) VALUE SPACES.*/
            public StringBasis LC01_DATA_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  03    REG-CABEC.*/
        }
        public SI2010B_REG_CABEC REG_CABEC { get; set; } = new SI2010B_REG_CABEC();
        public class SI2010B_REG_CABEC : VarBasis
        {
            /*"    05          FILLER         PIC X(12) VALUE 'VISTORIADORA'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VISTORIADORA");
            /*"    05          FILLER         PIC X(29) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @";");
            /*"    05          FILLER         PIC X(07) VALUE 'APOLICE'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
            /*"    05          FILLER         PIC X(07) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @";");
            /*"    05          FILLER         PIC X(07) VALUE 'PRODUTO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"    05          FILLER         PIC X(03) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
            /*"    05          FILLER         PIC X(08) VALUE 'SINISTRO'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
            /*"    05          FILLER         PIC X(06) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @";");
            /*"    05          FILLER         PIC X(07) VALUE 'DIA DEB'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"DIA DEB");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(10) VALUE 'DT VENCTO '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT VENCTO ");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(14) VALUE 'HONO VLR BRUTO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"HONO VLR BRUTO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(14) VALUE 'HONO VLR LIQ  '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"HONO VLR LIQ  ");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(14) VALUE 'DESPESAS      '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DESPESAS      ");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(13) VALUE 'SITUACAO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SITUACAO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(08) VALUE 'NOTAF'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NOTAF");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(40) VALUE ' RAZAO SOCIAL'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" RAZAO SOCIAL");
            /*"  03    REG-SAIDA.*/
        }
        public SI2010B_REG_SAIDA REG_SAIDA { get; set; } = new SI2010B_REG_SAIDA();
        public class SI2010B_REG_SAIDA : VarBasis
        {
            /*"    05  SAIDA-VISTORIADORA       PIC  X(40) VALUE SPACES.*/
            public StringBasis SAIDA_VISTORIADORA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-NUM-APOLICE        PIC  9(13) VALUE ZEROS.*/
            public IntBasis SAIDA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-COD-PRODUTO        PIC  9(04) VALUE ZEROS.*/
            public IntBasis SAIDA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-NUM-SINISTRO       PIC  9(13) VALUE ZEROS.*/
            public IntBasis SAIDA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-DIA-DEBITO         PIC  X(02) VALUE SPACES.*/
            public StringBasis SAIDA_DIA_DEBITO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"    05  FILLER                   PIC  X(05) VALUE SPACES.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-DT-VENCIMENTO      PIC  X(10) VALUE SPACES.*/
            public StringBasis SAIDA_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-HONOR-VLR-BRU      PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis SAIDA_HONOR_VLR_BRU { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-HONOR-VLR-LIQ      PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis SAIDA_HONOR_VLR_LIQ { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-DESPESAS           PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis SAIDA_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-SITUACAO           PIC  X(01) VALUE SPACES.*/
            public StringBasis SAIDA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  SAIDA-DES-SITUACAO       PIC  X(12) VALUE SPACES.*/
            public StringBasis SAIDA_DES_SITUACAO { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"");
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-NUM-DOC-FISCAL     PIC  ZZZZZZZ9.*/
            public IntBasis SAIDA_NUM_DOC_FISCAL { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  SAIDA-NOME-RAZAO         PIC  X(40) VALUE SPACES.*/
            public StringBasis SAIDA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05  FILLER                   PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01          VAR-AUXILIARES.*/
        }
        public SI2010B_VAR_AUXILIARES VAR_AUXILIARES { get; set; } = new SI2010B_VAR_AUXILIARES();
        public class SI2010B_VAR_AUXILIARES : VarBasis
        {
            /*"  03            WSQLCODE3           PIC S9(009) COMP VALUE ZEROS*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WS-CONTROLE         PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03            WS-LEITURA          PIC  9(009) VALUE ZEROS.*/
            public IntBasis WS_LEITURA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03            WS-DIA-DEB          PIC  X(004) VALUE ZEROS.*/
            public StringBasis WS_DIA_DEB { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  03  W-CARTA-CRED1-CONTRATO.*/
            public SI2010B_W_CARTA_CRED1_CONTRATO W_CARTA_CRED1_CONTRATO { get; set; } = new SI2010B_W_CARTA_CRED1_CONTRATO();
            public class SI2010B_W_CARTA_CRED1_CONTRATO : VarBasis
            {
                /*"      05 W-CARTA-CRED1-PONTO-VENDA  PIC  ZZZ9.*/
                public IntBasis W_CARTA_CRED1_PONTO_VENDA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"      05 FILLER                     PIC  X(001)  VALUE  '-'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      05 W-CARTA-CRED1-NUM-CONTRATO PIC  9(009)  VALUE ZEROS.*/
                public IntBasis W_CARTA_CRED1_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"  03            WDATA.*/
            }
            public SI2010B_WDATA WDATA { get; set; } = new SI2010B_WDATA();
            public class SI2010B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-DD            PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA-R             REDEFINES WDATA                                    PIC  X(010).*/
            }
            private _REDEF_StringBasis _wdata_r { get; set; }
            public _REDEF_StringBasis WDATA_R
            {
                get { _wdata_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATA, _wdata_r); VarBasis.RedefinePassValue(WDATA, _wdata_r, WDATA); _wdata_r.ValueChanged += () => { _.Move(_wdata_r, WDATA); }; return _wdata_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_r, WDATA); }
            }  //Redefines
            /*"  03            WFIM-V1HISTMEST     PIC  X(001) VALUE  SPACES.*/
            public StringBasis WFIM_V1HISTMEST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WFIM-V1SISINCHE     PIC  X(001) VALUE  SPACES.*/
            public StringBasis WFIM_V1SISINCHE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WFIM-TRELSIN2       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            DISPLAY-SALDO       PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis DISPLAY_SALDO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"  03            WS-TOTBRU-HON       PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_TOTBRU_HON { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOTBRU-DSP       PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_TOTBRU_DSP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-VALOR            PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-TOTAL            PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-NRO              PIC  9(002)                                    VALUE 0.*/
            public IntBasis WS_NRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03            WC-TOTAL            PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WC_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WS-VALOR-IRF        PIC S9(013)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_VALOR_IRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-VALOR-ISS        PIC S9(013)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_VALOR_ISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-TOT-IRF          PIC S9(013)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_TOT_IRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-TOT-ISS          PIC S9(013)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_TOT_ISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WPARTE1             PIC S9(011)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WPARTE1 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V99"), 2);
            /*"  03            WPARTE2             PIC S9(011)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WPARTE2 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V99"), 2);
            /*"  03            WCOD-FONTE          PIC S9(004)       COMP.*/
            public IntBasis WCOD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WNOME-FONTE         PIC  X(040).*/
            public StringBasis WNOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03            WS-DIA-DT-EMISSAO   PIC S9(004)       COMP.*/
            public IntBasis WS_DIA_DT_EMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WS-PRESTASERV       PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_PRESTASERV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            CHAVE-ANT.*/
            public SI2010B_CHAVE_ANT CHAVE_ANT { get; set; } = new SI2010B_CHAVE_ANT();
            public class SI2010B_CHAVE_ANT : VarBasis
            {
                /*"    05          WS-SINISTRO-ANT     PIC  9(013)  VALUE ZEROS.*/
                public IntBasis WS_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          WS-CODPSVI-ANT      PIC  9(009)  VALUE ZEROS.*/
                public IntBasis WS_CODPSVI_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"  03            CHAVE-ATU.*/
            }
            public SI2010B_CHAVE_ATU CHAVE_ATU { get; set; } = new SI2010B_CHAVE_ATU();
            public class SI2010B_CHAVE_ATU : VarBasis
            {
                /*"    05          WS-SINISTRO-ATU     PIC  9(013)  VALUE ZEROS.*/
                public IntBasis WS_SINISTRO_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          WS-CODPSVI-ATU      PIC  9(009)  VALUE ZEROS.*/
                public IntBasis WS_CODPSVI_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"  03            LIDOS-CURSOR        PIC  9(006)  VALUE ZEROS.*/
            }
            public IntBasis LIDOS_CURSOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            AC-IMPRESSOS        PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            LIDOS-REEMISSAO     PIC  9(006)  VALUE ZEROS.*/
            public IntBasis LIDOS_REEMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            IMPRES-EMISSAO      PIC  9(006)  VALUE ZEROS.*/
            public IntBasis IMPRES_EMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            IMPRES-REEMISSAO    PIC  9(006)  VALUE ZEROS.*/
            public IntBasis IMPRES_REEMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03        WABEND.*/
            public SI2010B_WABEND WABEND { get; set; } = new SI2010B_WABEND();
            public class SI2010B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI2010B1'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI2010B1");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          WVALOR              PIC  S9(015)V99 COMP-3.*/
            }
        }
        public DoubleBasis WVALOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"01          WRESPOSTA           PIC   X(004)   VALUE  SPACES.*/
        public StringBasis WRESPOSTA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01          WAREA-1.*/
        public SI2010B_WAREA_1 WAREA_1 { get; set; } = new SI2010B_WAREA_1();
        public class SI2010B_WAREA_1 : VarBasis
        {
            /*"  03        WTAM-1              PIC   9(003)   VALUE  15.*/
            public IntBasis WTAM_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 15);
            /*"  03        WLINHA-1            PIC   X(032)   VALUE  SPACES.*/
            public StringBasis WLINHA_1 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
            /*"01          WAREA-2.*/
        }
        public SI2010B_WAREA_2 WAREA_2 { get; set; } = new SI2010B_WAREA_2();
        public class SI2010B_WAREA_2 : VarBasis
        {
            /*"  03        WTAM-2              PIC   9(003)   VALUE  80.*/
            public IntBasis WTAM_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 80);
            /*"  03        WLINHA-2            PIC   X(098)   VALUE  SPACES.*/
            public StringBasis WLINHA_2 { get; set; } = new StringBasis(new PIC("X", "98", "X(098)"), @"");
            /*"01          WAREA-3.*/
        }
        public SI2010B_WAREA_3 WAREA_3 { get; set; } = new SI2010B_WAREA_3();
        public class SI2010B_WAREA_3 : VarBasis
        {
            /*"  03        WTAM-3              PIC   9(003)   VALUE  33.*/
            public IntBasis WTAM_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 33);
            /*"  03        WLINHA-3            PIC   X(098)   VALUE  SPACES.*/
            public StringBasis WLINHA_3 { get; set; } = new StringBasis(new PIC("X", "98", "X(098)"), @"");
            /*"01          WS-DATA-EXTENSO.*/
        }
        public SI2010B_WS_DATA_EXTENSO WS_DATA_EXTENSO { get; set; } = new SI2010B_WS_DATA_EXTENSO();
        public class SI2010B_WS_DATA_EXTENSO : VarBasis
        {
            /*"  03        WS-DIA-EXT          PIC   9(002)   VALUE  ZEROS.*/
            public IntBasis WS_DIA_EXT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03        FILLER              PIC   X(004)   VALUE  ' DE '.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
            /*"  03        WS-MES-EXT          PIC   X(009)   VALUE  SPACES.*/
            public StringBasis WS_MES_EXT { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  03        FILLER              PIC   X(004)   VALUE  ' DE '.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
            /*"  03        WS-ANO-EXT          PIC   9(004)   VALUE  ZEROS.*/
            public IntBasis WS_ANO_EXT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01          LK-IMPOSTOS.*/
        }
        public SI2010B_LK_IMPOSTOS LK_IMPOSTOS { get; set; } = new SI2010B_LK_IMPOSTOS();
        public class SI2010B_LK_IMPOSTOS : VarBasis
        {
            /*"    03      LK-ATUALIZA    PIC  X(001).*/
            public StringBasis LK_ATUALIZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-IDTRIBUTA   PIC  X(001).*/
            public StringBasis LK_IDTRIBUTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PROGRAMA    PIC  X(007).*/
            public StringBasis LK_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"    03      LK-FONTE       PIC S9(004)    COMP.*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LK-TIPFAV      PIC  X(001).*/
            public StringBasis LK_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-TIPREG      PIC  X(001).*/
            public StringBasis LK_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-CODFAV      PIC S9(009)    COMP.*/
            public IntBasis LK_CODFAV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03      LK-VALBRU      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALBRU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-DTMOVABE    PIC  X(010).*/
            public StringBasis LK_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03      LK-DCOIRF      PIC  X(001).*/
            public StringBasis LK_DCOIRF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PCTIRF      PIC S9(003)V99 COMP-3.*/
            public DoubleBasis LK_PCTIRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    03      LK-DCOISS      PIC  X(001).*/
            public StringBasis LK_DCOISS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PCDESISS    PIC S9(003)V99 COMP-3.*/
            public DoubleBasis LK_PCDESISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    03      LK-NOMFAV      PIC  X(040).*/
            public StringBasis LK_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03      LK-NUMREC      PIC S9(009)    COMP.*/
            public IntBasis LK_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03      LK-VALISS      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-VALIRF      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALIRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-VALIAP      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALIAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-NOMEFTE     PIC  X(040).*/
            public StringBasis LK_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03      LK-TPPESSOA    PIC  X(001).*/
            public StringBasis LK_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-CODSVI      PIC S9(004)    COMP.*/
            public IntBasis LK_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LK-INSPREFE    PIC S9(015)    COMP-3.*/
            public IntBasis LK_INSPREFE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    03      LK-INSINPS     PIC S9(015)    COMP-3.*/
            public IntBasis LK_INSINPS { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    03      LK-CGCCPF      PIC S9(015)    COMP-3.*/
            public IntBasis LK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    03      LK-EXEC-SQL    PIC  X(004).*/
            public StringBasis LK_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    03      LK-RETCODE     PIC S9(004)    COMP.*/
            public IntBasis LK_RETCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LK-MENSAGEM    PIC  X(077).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"    03      LK-VALDDUDEP   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALDDUDEP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-DCOINSS     PIC  X(001).*/
            public StringBasis LK_DCOINSS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03      LK-PCTINSS     PIC S9(003)V99 COMP-3.*/
            public DoubleBasis LK_PCTINSS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"    03      LK-VALINSS     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_VALINSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03      LK-EMPRESA     PIC S9(009)    COMP.*/
            public IntBasis LK_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        }


        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.FIPADOFI FIPADOFI { get; set; } = new Dclgens.FIPADOFI();
        public Dclgens.SIPADOFI SIPADOFI { get; set; } = new Dclgens.SIPADOFI();
        public SI2010B_V1HISTMEST V1HISTMEST { get; set; } = new SI2010B_V1HISTMEST();
        public SI2010B_V1SISINCHE V1SISINCHE { get; set; } = new SI2010B_V1SISINCHE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI2010B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI2010B1.SetFile(SI2010B1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -392- MOVE '001' TO WNR-EXEC-SQL */
            _.Move("001", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -394- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -395- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -398- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -401- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -405- INITIALIZE LK-IMPOSTOS */
            _.Initialize(
                LK_IMPOSTOS
            );

            /*" -407- OPEN OUTPUT SI2010B1. */
            SI2010B1.Open(REG_SI2010B1);

            /*" -409- PERFORM R0010-000-LER-V1SISTEMA */

            R0010_000_LER_V1SISTEMA_SECTION();

            /*" -411- PERFORM R0012-000-LER-RELATORIOS */

            R0012_000_LER_RELATORIOS_SECTION();

            /*" -412- MOVE SIST-DTMOVABE TO WDATA. */
            _.Move(SIST_DTMOVABE, VAR_AUXILIARES.WDATA);

            /*" -413- MOVE WDATA-AA TO LC01-DATA-AA. */
            _.Move(VAR_AUXILIARES.WDATA.WDATA_AA, LC01.LC01_DATA_AA);

            /*" -414- MOVE WDATA-MM TO LC01-DATA-MM. */
            _.Move(VAR_AUXILIARES.WDATA.WDATA_MM, LC01.LC01_DATA_MM);

            /*" -416- MOVE WDATA-DD TO LC01-DATA-DD. */
            _.Move(VAR_AUXILIARES.WDATA.WDATA_DD, LC01.LC01_DATA_DD);

            /*" -417- WRITE REG-SI2010B1 FROM LC01. */
            _.Move(LC01.GetMoveValues(), REG_SI2010B1);

            SI2010B1.Write(REG_SI2010B1.GetMoveValues().ToString());

            /*" -419- WRITE REG-SI2010B1 FROM REG-CABEC. */
            _.Move(REG_CABEC.GetMoveValues(), REG_SI2010B1);

            SI2010B1.Write(REG_SI2010B1.GetMoveValues().ToString());

            /*" -420- PERFORM R0014-000-DECLARE-V1HISTMEST */

            R0014_000_DECLARE_V1HISTMEST_SECTION();

            /*" -422- PERFORM R0015-000-FETCH-V1HISTMEST */

            R0015_000_FETCH_V1HISTMEST_SECTION();

            /*" -423- IF WFIM-V1HISTMEST NOT EQUAL SPACES */

            if (!VAR_AUXILIARES.WFIM_V1HISTMEST.IsEmpty())
            {

                /*" -424- DISPLAY ' PROG SI2010B1 -  NENHUM REGISTRO SELECIONADO' */
                _.Display($" PROG SI2010B1 -  NENHUM REGISTRO SELECIONADO");

                /*" -425- GO TO 000-900-FIM */

                M_000_900_FIM(); //GOTO
                return;

                /*" -427- END-IF */
            }


            /*" -428- MOVE SPACES TO WFIM-V1HISTMEST */
            _.Move("", VAR_AUXILIARES.WFIM_V1HISTMEST);

            /*" -430- MOVE SPACES TO WFIM-V1SISINCHE */
            _.Move("", VAR_AUXILIARES.WFIM_V1SISINCHE);

            /*" -431- PERFORM R0030-000-PROCESSA-REGISTRO UNTIL WFIM-V1HISTMEST NOT EQUAL SPACES. */

            while (!(!VAR_AUXILIARES.WFIM_V1HISTMEST.IsEmpty()))
            {

                R0030_000_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -438- CLOSE SI2010B1. */
            SI2010B1.Close();

            /*" -439- DISPLAY 'LIDOS CURSOR      = ' LIDOS-CURSOR. */
            _.Display($"LIDOS CURSOR      = {VAR_AUXILIARES.LIDOS_CURSOR}");

            /*" -440- DISPLAY 'GRAVADOS ARQUIVO  = ' AC-IMPRESSOS. */
            _.Display($"GRAVADOS ARQUIVO  = {VAR_AUXILIARES.AC_IMPRESSOS}");

            /*" -441- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -442- DISPLAY '  ' */
            _.Display($"  ");

            /*" -443- DISPLAY '  PROG. SI2010B1      ' */
            _.Display($"  PROG. SI2010B1      ");

            /*" -444- DISPLAY '  TERMINO NORMAL     ' */
            _.Display($"  TERMINO NORMAL     ");

            /*" -446- DISPLAY '  ' */
            _.Display($"  ");

            /*" -446- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" R0010-000-LER-V1SISTEMA-SECTION */
        private void R0010_000_LER_V1SISTEMA_SECTION()
        {
            /*" -455- MOVE '010-000-LER-V1SISTEMA' TO PARAGRAFO. */
            _.Move("010-000-LER-V1SISTEMA", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -457- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -462- PERFORM R0010_000_LER_V1SISTEMA_DB_SELECT_1 */

            R0010_000_LER_V1SISTEMA_DB_SELECT_1();

            /*" -465- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -466- DISPLAY 'SI2010B1  - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI2010B1  - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -468- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -470- MOVE SIST-DTMOVABE TO WDATA-R. */
            _.Move(SIST_DTMOVABE, VAR_AUXILIARES.WDATA_R);

            /*" -471- DISPLAY ' ' */
            _.Display($" ");

            /*" -475- DISPLAY 'SI2010B1 - DATA DO PROCESSAMENTO ' ' ' WDATA-DD '/' WDATA-MM '/' WDATA-AA. */

            $"SI2010B1 - DATA DO PROCESSAMENTO  {VAR_AUXILIARES.WDATA.WDATA_DD}/{VAR_AUXILIARES.WDATA.WDATA_MM}/{VAR_AUXILIARES.WDATA.WDATA_AA}"
            .Display();

            /*" -476- DISPLAY WS-VERSAO. */
            _.Display(WS_VERSAO);

            /*" -476- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0010-000-LER-V1SISTEMA-DB-SELECT-1 */
        public void R0010_000_LER_V1SISTEMA_DB_SELECT_1()
        {
            /*" -462- EXEC SQL SELECT DTMOVABE INTO :SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var r0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_000_LER_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_011_999_EXIT*/

        [StopWatch]
        /*" R0012-000-LER-RELATORIOS-SECTION */
        private void R0012_000_LER_RELATORIOS_SECTION()
        {
            /*" -486- MOVE '012-000-LER-RELATORIO' TO PARAGRAFO. */
            _.Move("012-000-LER-RELATORIO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -488- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -499- PERFORM R0012_000_LER_RELATORIOS_DB_SELECT_1 */

            R0012_000_LER_RELATORIOS_DB_SELECT_1();

            /*" -502- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -503- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, VAR_AUXILIARES.WABEND.WSQLCODE);

                /*" -504- DISPLAY 'PROGRAMA NAO SOLICITADO NA RELATORIOS' */
                _.Display($"PROGRAMA NAO SOLICITADO NA RELATORIOS");

                /*" -505- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -506- ELSE */
            }
            else
            {


                /*" -508- DISPLAY 'PROG SI2010B  - PERIODO INICIAL=' RELATORI-PERI-INICIAL */
                _.Display($"PROG SI2010B  - PERIODO INICIAL={RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

                /*" -509- END-IF */
            }


            /*" -509- . */

        }

        [StopWatch]
        /*" R0012-000-LER-RELATORIOS-DB-SELECT-1 */
        public void R0012_000_LER_RELATORIOS_DB_SELECT_1()
        {
            /*" -499- EXEC SQL SELECT PERI_INICIAL INTO :RELATORI-PERI-INICIAL FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI2010B1' AND SIT_REGISTRO = '0' END-EXEC. */

            var r0012_000_LER_RELATORIOS_DB_SELECT_1_Query1 = new R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1.Execute(r0012_000_LER_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0012_999_EXIT*/

        [StopWatch]
        /*" R0014-000-DECLARE-V1HISTMEST-SECTION */
        private void R0014_000_DECLARE_V1HISTMEST_SECTION()
        {
            /*" -518- MOVE '014-000-DECLARE-V1HISTMEST' TO PARAGRAFO */
            _.Move("014-000-DECLARE-V1HISTMEST", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -520- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -524- INITIALIZE REG-SAIDA REG-SI2010B1. */
            _.Initialize(
                REG_SAIDA
                , REG_SI2010B1
            );

            /*" -546- PERFORM R0014_000_DECLARE_V1HISTMEST_DB_DECLARE_1 */

            R0014_000_DECLARE_V1HISTMEST_DB_DECLARE_1();

            /*" -548- PERFORM R0014_000_DECLARE_V1HISTMEST_DB_OPEN_1 */

            R0014_000_DECLARE_V1HISTMEST_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0014-000-DECLARE-V1HISTMEST-DB-DECLARE-1 */
        public void R0014_000_DECLARE_V1HISTMEST_DB_DECLARE_1()
        {
            /*" -546- EXEC SQL DECLARE V1HISTMEST CURSOR FOR SELECT M.NOME_FAVORECIDO ,H.NUM_APOLICE ,H.NUM_APOL_SINISTRO ,M.COD_PRODUTO ,M.VAL_OPERACAO ,M.COD_OPERACAO ,H.SIT_REGISTRO ,M.COD_PREST_SERVICO ,M.TIPO_FAVORECIDO ,M.FONTE_PAGAMENTO ,M.OCORR_HISTORICO FROM SEGUROS.SINISTRO_MESTRE H ,SEGUROS.SINISTRO_HISTORICO M WHERE M.DATA_MOVIMENTO > :RELATORI-PERI-INICIAL AND M.COD_OPERACAO IN (2010 , 3010 ) AND M.COD_PRODUTO IN ( 1803 , 1805 ) AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND M.COD_PREST_SERVICO IN (891743 , 893742, 3022015, 3133157, 3122833) WITH UR END-EXEC. */
            V1HISTMEST = new SI2010B_V1HISTMEST(true);
            string GetQuery_V1HISTMEST()
            {
                var query = @$"SELECT M.NOME_FAVORECIDO 
							,H.NUM_APOLICE 
							,H.NUM_APOL_SINISTRO 
							,M.COD_PRODUTO 
							,M.VAL_OPERACAO 
							,M.COD_OPERACAO 
							,H.SIT_REGISTRO 
							,M.COD_PREST_SERVICO 
							,M.TIPO_FAVORECIDO 
							,M.FONTE_PAGAMENTO 
							,M.OCORR_HISTORICO 
							FROM SEGUROS.SINISTRO_MESTRE H 
							,SEGUROS.SINISTRO_HISTORICO M 
							WHERE M.DATA_MOVIMENTO > '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND M.COD_OPERACAO IN (2010
							, 3010 ) 
							AND M.COD_PRODUTO IN ( 1803
							, 1805 ) 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND M.COD_PREST_SERVICO IN (891743
							, 893742
							, 3022015
							, 
							3133157
							, 3122833)";

                return query;
            }
            V1HISTMEST.GetQueryEvent += GetQuery_V1HISTMEST;

        }

        [StopWatch]
        /*" R0014-000-DECLARE-V1HISTMEST-DB-OPEN-1 */
        public void R0014_000_DECLARE_V1HISTMEST_DB_OPEN_1()
        {
            /*" -548- EXEC SQL OPEN V1HISTMEST END-EXEC. */

            V1HISTMEST.Open();

        }

        [StopWatch]
        /*" R0610-00-DECLARE-SISINCHE-DB-DECLARE-1 */
        public void R0610_00_DECLARE_SISINCHE_DB_DECLARE_1()
        {
            /*" -788- EXEC SQL DECLARE V1SISINCHE CURSOR FOR SELECT NUM_CHEQUE_INTERNO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WITH UR END-EXEC. */
            V1SISINCHE = new SI2010B_V1SISINCHE(true);
            string GetQuery_V1SISINCHE()
            {
                var query = @$"SELECT NUM_CHEQUE_INTERNO 
							FROM SEGUROS.SI_SINI_CHEQUE 
							WHERE NUM_APOL_SINISTRO = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}' 
							AND COD_OPERACAO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}' 
							AND OCORR_HISTORICO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}'";

                return query;
            }
            V1SISINCHE.GetQueryEvent += GetQuery_V1SISINCHE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0014_999_EXIT*/

        [StopWatch]
        /*" R0015-000-FETCH-V1HISTMEST-SECTION */
        private void R0015_000_FETCH_V1HISTMEST_SECTION()
        {
            /*" -557- MOVE 'R0015-000-FETCH-V1HISTMEST' TO PARAGRAFO. */
            _.Move("R0015-000-FETCH-V1HISTMEST", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -559- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -562- INITIALIZE DCLSINISTRO-MESTRE DCLSINISTRO-HISTORICO */
            _.Initialize(
                SINISMES.DCLSINISTRO_MESTRE
                , SINISHIS.DCLSINISTRO_HISTORICO
            );

            /*" -574- PERFORM R0015_000_FETCH_V1HISTMEST_DB_FETCH_1 */

            R0015_000_FETCH_V1HISTMEST_DB_FETCH_1();

            /*" -577- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -577- PERFORM R0015_000_FETCH_V1HISTMEST_DB_CLOSE_1 */

                R0015_000_FETCH_V1HISTMEST_DB_CLOSE_1();

                /*" -579- MOVE 'S' TO WFIM-V1HISTMEST */
                _.Move("S", VAR_AUXILIARES.WFIM_V1HISTMEST);

                /*" -580- ELSE */
            }
            else
            {


                /*" -580- ADD 1 TO LIDOS-CURSOR. */
                VAR_AUXILIARES.LIDOS_CURSOR.Value = VAR_AUXILIARES.LIDOS_CURSOR + 1;
            }


        }

        [StopWatch]
        /*" R0015-000-FETCH-V1HISTMEST-DB-FETCH-1 */
        public void R0015_000_FETCH_V1HISTMEST_DB_FETCH_1()
        {
            /*" -574- EXEC SQL FETCH V1HISTMEST INTO :SINISHIS-NOME-FAVORECIDO ,:SINISMES-NUM-APOLICE ,:SINISMES-NUM-APOL-SINISTRO ,:SINISHIS-COD-PRODUTO ,:SINISHIS-VAL-OPERACAO ,:SINISHIS-COD-OPERACAO ,:SINISMES-SIT-REGISTRO ,:SINISHIS-COD-PREST-SERVICO ,:SINISHIS-TIPO-FAVORECIDO ,:SINISHIS-FONTE-PAGAMENTO ,:SINISHIS-OCORR-HISTORICO END-EXEC. */

            if (V1HISTMEST.Fetch())
            {
                _.Move(V1HISTMEST.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(V1HISTMEST.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(V1HISTMEST.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(V1HISTMEST.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(V1HISTMEST.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(V1HISTMEST.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(V1HISTMEST.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(V1HISTMEST.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(V1HISTMEST.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(V1HISTMEST.SINISHIS_FONTE_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);
                _.Move(V1HISTMEST.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R0015-000-FETCH-V1HISTMEST-DB-CLOSE-1 */
        public void R0015_000_FETCH_V1HISTMEST_DB_CLOSE_1()
        {
            /*" -577- EXEC SQL CLOSE V1HISTMEST END-EXEC */

            V1HISTMEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_999_EXIT*/

        [StopWatch]
        /*" R0030-000-PROCESSA-REGISTRO-SECTION */
        private void R0030_000_PROCESSA_REGISTRO_SECTION()
        {
            /*" -589- MOVE 'R0030-000-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R0030-000-PROCESSA-REGISTRO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -591- MOVE '0030' TO WNR-EXEC-SQL. */
            _.Move("0030", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -595- MOVE +0 TO WS-TOT-IRF WS-TOT-ISS WS-TOTBRU-HON. */
            _.Move(+0, VAR_AUXILIARES.WS_TOT_IRF, VAR_AUXILIARES.WS_TOT_ISS, VAR_AUXILIARES.WS_TOTBRU_HON);

            /*" -600- INITIALIZE LK-IMPOSTOS */
            _.Initialize(
                LK_IMPOSTOS
            );

            /*" -601- MOVE SINISHIS-FONTE-PAGAMENTO TO LK-FONTE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO, LK_IMPOSTOS.LK_FONTE);

            /*" -602- MOVE SINISHIS-COD-PREST-SERVICO TO LK-CODFAV */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, LK_IMPOSTOS.LK_CODFAV);

            /*" -604- MOVE ZEROS TO LK-VALBRU */
            _.Move(0, LK_IMPOSTOS.LK_VALBRU);

            /*" -605- IF SINISHIS-TIPO-FAVORECIDO = '7' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO == "7")
            {

                /*" -606- MOVE 'N' TO LK-DCOIRF */
                _.Move("N", LK_IMPOSTOS.LK_DCOIRF);

                /*" -607- ELSE */
            }
            else
            {


                /*" -611- MOVE SPACE TO LK-DCOIRF. */
                _.Move("", LK_IMPOSTOS.LK_DCOIRF);
            }


            /*" -612- PERFORM R0610-00-DECLARE-SISINCHE */

            R0610_00_DECLARE_SISINCHE_SECTION();

            /*" -613- PERFORM R0611-00-FETCH-V1SISINCHE */

            R0611_00_FETCH_V1SISINCHE_SECTION();

            /*" -616- PERFORM R0612-00-PROCESSA-REGISTRO UNTIL WFIM-V1SISINCHE NOT EQUAL SPACES. */

            while (!(!VAR_AUXILIARES.WFIM_V1SISINCHE.IsEmpty()))
            {

                R0612_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -616- PERFORM R0015-000-FETCH-V1HISTMEST. */

            R0015_000_FETCH_V1HISTMEST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" R0031-000-GRAVA-ARQUIVO-SECTION */
        private void R0031_000_GRAVA_ARQUIVO_SECTION()
        {
            /*" -625- MOVE '031-000-GRAVA-ARQUIVO' TO PARAGRAFO. */
            _.Move("031-000-GRAVA-ARQUIVO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -629- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -630- MOVE SINISHIS-NOME-FAVORECIDO TO SAIDA-VISTORIADORA */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, REG_SAIDA.SAIDA_VISTORIADORA);

            /*" -631- MOVE SINISMES-NUM-APOLICE TO SAIDA-NUM-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, REG_SAIDA.SAIDA_NUM_APOLICE);

            /*" -632- MOVE SINISHIS-COD-PRODUTO TO SAIDA-COD-PRODUTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, REG_SAIDA.SAIDA_COD_PRODUTO);

            /*" -633- MOVE SINISMES-NUM-APOL-SINISTRO TO SAIDA-NUM-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REG_SAIDA.SAIDA_NUM_SINISTRO);

            /*" -634- MOVE SINISMES-TOT-HONORARIOS-IX TO SAIDA-HONOR-VLR-BRU */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_HONORARIOS_IX, REG_SAIDA.SAIDA_HONOR_VLR_BRU);

            /*" -636- MOVE SINISMES-TOT-DESPESAS-IX TO SAIDA-DESPESAS */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_DESPESAS_IX, REG_SAIDA.SAIDA_DESPESAS);

            /*" -637- MOVE FIPADOFI-NUM-DOC-FISCAL TO SAIDA-NUM-DOC-FISCAL */
            _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL, REG_SAIDA.SAIDA_NUM_DOC_FISCAL);

            /*" -639- MOVE CLIENTES-NOME-RAZAO TO SAIDA-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SAIDA.SAIDA_NOME_RAZAO);

            /*" -641- MOVE SINISMES-SIT-REGISTRO TO SAIDA-SITUACAO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO, REG_SAIDA.SAIDA_SITUACAO);

            /*" -642- IF SINISMES-SIT-REGISTRO = 0 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == 0)
            {

                /*" -643- MOVE ' - PENDENTE' TO SAIDA-DES-SITUACAO */
                _.Move(" - PENDENTE", REG_SAIDA.SAIDA_DES_SITUACAO);

                /*" -644- ELSE */
            }
            else
            {


                /*" -645- IF SINISMES-SIT-REGISTRO = 1 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == 1)
                {

                    /*" -646- MOVE ' - PAGO' TO SAIDA-DES-SITUACAO */
                    _.Move(" - PAGO", REG_SAIDA.SAIDA_DES_SITUACAO);

                    /*" -647- ELSE */
                }
                else
                {


                    /*" -648- MOVE ' - CANCELADO' TO SAIDA-DES-SITUACAO */
                    _.Move(" - CANCELADO", REG_SAIDA.SAIDA_DES_SITUACAO);

                    /*" -649- END-IF */
                }


                /*" -651- END-IF. */
            }


            /*" -653- MOVE CHEQUEMI-DATA-EMISSAO TO SAIDA-DT-VENCIMENTO */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO, REG_SAIDA.SAIDA_DT_VENCIMENTO);

            /*" -654- IF WS-DIA-DT-EMISSAO = ZEROS */

            if (VAR_AUXILIARES.WS_DIA_DT_EMISSAO == 00)
            {

                /*" -655- MOVE SPACES TO SAIDA-DIA-DEBITO */
                _.Move("", REG_SAIDA.SAIDA_DIA_DEBITO);

                /*" -656- ELSE */
            }
            else
            {


                /*" -657- MOVE WS-DIA-DT-EMISSAO TO WS-DIA-DEB */
                _.Move(VAR_AUXILIARES.WS_DIA_DT_EMISSAO, VAR_AUXILIARES.WS_DIA_DEB);

                /*" -658- MOVE WS-DIA-DEB(3:2) TO SAIDA-DIA-DEBITO */
                _.Move(VAR_AUXILIARES.WS_DIA_DEB.Substring(3, 2), REG_SAIDA.SAIDA_DIA_DEBITO);

                /*" -660- END-IF. */
            }


            /*" -662- WRITE REG-SI2010B1 FROM REG-SAIDA */
            _.Move(REG_SAIDA.GetMoveValues(), REG_SI2010B1);

            SI2010B1.Write(REG_SI2010B1.GetMoveValues().ToString());

            /*" -664- ADD 1 TO AC-IMPRESSOS */
            VAR_AUXILIARES.AC_IMPRESSOS.Value = VAR_AUXILIARES.AC_IMPRESSOS + 1;

            /*" -665- INITIALIZE REG-SAIDA REG-SI2010B1. */
            _.Initialize(
                REG_SAIDA
                , REG_SI2010B1
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0031_999_EXIT*/

        [StopWatch]
        /*" R0032-000-PROCESSA-PRESTADOR-SECTION */
        private void R0032_000_PROCESSA_PRESTADOR_SECTION()
        {
            /*" -674- MOVE '032-000-PROCESSA-PRESTADOR' TO PARAGRAFO. */
            _.Move("032-000-PROCESSA-PRESTADOR", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -680- MOVE '032' TO WNR-EXEC-SQL. */
            _.Move("032", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -681- IF SINISHIS-COD-OPERACAO = 3010 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 3010)
            {

                /*" -682- MOVE SINISHIS-VAL-OPERACAO TO WS-TOTBRU-HON */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, VAR_AUXILIARES.WS_TOTBRU_HON);

                /*" -683- MOVE SINISHIS-VAL-OPERACAO TO SINISMES-TOT-HONORARIOS-IX */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_HONORARIOS_IX);

                /*" -684- ELSE */
            }
            else
            {


                /*" -684- MOVE SINISHIS-VAL-OPERACAO TO SINISMES-TOT-DESPESAS-IX. */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TOT_DESPESAS_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0032_999_EXIT*/

        [StopWatch]
        /*" R0035-000-CHAMA-CALCULO-SECTION */
        private void R0035_000_CHAMA_CALCULO_SECTION()
        {
            /*" -693- MOVE '035-000-CHAMA-CALCULO' TO PARAGRAFO. */
            _.Move("035-000-CHAMA-CALCULO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -695- MOVE '035' TO WNR-EXEC-SQL. */
            _.Move("035", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -700- PERFORM R0032-000-PROCESSA-PRESTADOR */

            R0032_000_PROCESSA_PRESTADOR_SECTION();

            /*" -701- IF SINISHIS-COD-OPERACAO = 3010 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 3010)
            {

                /*" -707- PERFORM R0605-00-CHAMA-CALC-IMPOSTO THRU R0605-99-SAIDA. */

                R0605_00_CHAMA_CALC_IMPOSTO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605_99_SAIDA*/

            }


            /*" -711- PERFORM R0640-00-LER-RAZAO-SOCIAL */

            R0640_00_LER_RAZAO_SOCIAL_SECTION();

            /*" -716- PERFORM R0620-00-LER-SI-DOCUMENTO */

            R0620_00_LER_SI_DOCUMENTO_SECTION();

            /*" -719- COMPUTE SAIDA-HONOR-VLR-LIQ = WS-TOTBRU-HON - WS-TOT-IRF - WS-TOT-ISS. */
            REG_SAIDA.SAIDA_HONOR_VLR_LIQ.Value = VAR_AUXILIARES.WS_TOTBRU_HON - VAR_AUXILIARES.WS_TOT_IRF - VAR_AUXILIARES.WS_TOT_ISS;

            /*" -719- PERFORM R0031-000-GRAVA-ARQUIVO. */

            R0031_000_GRAVA_ARQUIVO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_999_EXIT*/

        [StopWatch]
        /*" R0605-00-CHAMA-CALC-IMPOSTO-SECTION */
        private void R0605_00_CHAMA_CALC_IMPOSTO_SECTION()
        {
            /*" -729- MOVE 'R0605-00-CHAMA-CALC-IMPOSTO' TO PARAGRAFO. */
            _.Move("R0605-00-CHAMA-CALC-IMPOSTO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -731- MOVE '0605' TO WNR-EXEC-SQL. */
            _.Move("0605", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -735- MOVE 'N' TO LK-ATUALIZA */
            _.Move("N", LK_IMPOSTOS.LK_ATUALIZA);

            /*" -736- MOVE WS-TOTBRU-HON TO LK-VALBRU */
            _.Move(VAR_AUXILIARES.WS_TOTBRU_HON, LK_IMPOSTOS.LK_VALBRU);

            /*" -737- IF LK-VALBRU EQUAL ZERO */

            if (LK_IMPOSTOS.LK_VALBRU == 00)
            {

                /*" -738- MOVE 'N' TO LK-IDTRIBUTA */
                _.Move("N", LK_IMPOSTOS.LK_IDTRIBUTA);

                /*" -739- ELSE */
            }
            else
            {


                /*" -741- MOVE 'S' TO LK-IDTRIBUTA. */
                _.Move("S", LK_IMPOSTOS.LK_IDTRIBUTA);
            }


            /*" -742- MOVE 'SI2010B1' TO LK-PROGRAMA */
            _.Move("SI2010B1", LK_IMPOSTOS.LK_PROGRAMA);

            /*" -743- MOVE '2' TO LK-TIPFAV */
            _.Move("2", LK_IMPOSTOS.LK_TIPFAV);

            /*" -745- MOVE '4' TO LK-TIPREG */
            _.Move("4", LK_IMPOSTOS.LK_TIPREG);

            /*" -747- MOVE SIST-DTMOVABE TO LK-DTMOVABE */
            _.Move(SIST_DTMOVABE, LK_IMPOSTOS.LK_DTMOVABE);

            /*" -749- MOVE SPACE TO LK-DCOISS */
            _.Move("", LK_IMPOSTOS.LK_DCOISS);

            /*" -754- MOVE ZEROS TO LK-PCTIRF LK-PCDESISS LK-VALISS LK-VALIRF. */
            _.Move(0, LK_IMPOSTOS.LK_PCTIRF, LK_IMPOSTOS.LK_PCDESISS, LK_IMPOSTOS.LK_VALISS, LK_IMPOSTOS.LK_VALIRF);

            /*" -756- CALL 'FI0100S' USING LK-IMPOSTOS. */
            _.Call("FI0100S", LK_IMPOSTOS);

            /*" -757- IF LK-MENSAGEM NOT EQUAL SPACES */

            if (!LK_IMPOSTOS.LK_MENSAGEM.IsEmpty())
            {

                /*" -759- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -761- MOVE LK-VALIRF TO WS-VALOR-IRF WS-TOT-IRF */
            _.Move(LK_IMPOSTOS.LK_VALIRF, VAR_AUXILIARES.WS_VALOR_IRF, VAR_AUXILIARES.WS_TOT_IRF);

            /*" -762- MOVE LK-VALISS TO WS-VALOR-ISS WS-TOT-ISS. */
            _.Move(LK_IMPOSTOS.LK_VALISS, VAR_AUXILIARES.WS_VALOR_ISS, VAR_AUXILIARES.WS_TOT_ISS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-DECLARE-SISINCHE-SECTION */
        private void R0610_00_DECLARE_SISINCHE_SECTION()
        {
            /*" -772- MOVE 'R0610-00-DECLARE-SISINCHE' TO PARAGRAFO */
            _.Move("R0610-00-DECLARE-SISINCHE", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -774- MOVE '610' TO WNR-EXEC-SQL. */
            _.Move("610", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -775- MOVE SPACES TO WFIM-V1SISINCHE */
            _.Move("", VAR_AUXILIARES.WFIM_V1SISINCHE);

            /*" -777- MOVE ZEROS TO WS-LEITURA */
            _.Move(0, VAR_AUXILIARES.WS_LEITURA);

            /*" -781- INITIALIZE DCLCHEQUES-EMITIDOS DCLSI-SINI-CHEQUE WS-DIA-DT-EMISSAO */
            _.Initialize(
                CHEQUEMI.DCLCHEQUES_EMITIDOS
                , SISINCHE.DCLSI_SINI_CHEQUE
                , VAR_AUXILIARES.WS_DIA_DT_EMISSAO
            );

            /*" -788- PERFORM R0610_00_DECLARE_SISINCHE_DB_DECLARE_1 */

            R0610_00_DECLARE_SISINCHE_DB_DECLARE_1();

            /*" -790- PERFORM R0610_00_DECLARE_SISINCHE_DB_OPEN_1 */

            R0610_00_DECLARE_SISINCHE_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0610-00-DECLARE-SISINCHE-DB-OPEN-1 */
        public void R0610_00_DECLARE_SISINCHE_DB_OPEN_1()
        {
            /*" -790- EXEC SQL OPEN V1SISINCHE END-EXEC. */

            V1SISINCHE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_999_EXIT*/

        [StopWatch]
        /*" R0611-00-FETCH-V1SISINCHE-SECTION */
        private void R0611_00_FETCH_V1SISINCHE_SECTION()
        {
            /*" -799- MOVE 'R0611-00-FETCH-V1SISINCHE' TO PARAGRAFO. */
            _.Move("R0611-00-FETCH-V1SISINCHE", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -801- MOVE '611' TO WNR-EXEC-SQL. */
            _.Move("611", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -803- PERFORM R0611_00_FETCH_V1SISINCHE_DB_FETCH_1 */

            R0611_00_FETCH_V1SISINCHE_DB_FETCH_1();

            /*" -807- ADD 1 TO WS-LEITURA. */
            VAR_AUXILIARES.WS_LEITURA.Value = VAR_AUXILIARES.WS_LEITURA + 1;

            /*" -808- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- PERFORM R0611_00_FETCH_V1SISINCHE_DB_CLOSE_1 */

                R0611_00_FETCH_V1SISINCHE_DB_CLOSE_1();

                /*" -810- MOVE 'S' TO WFIM-V1SISINCHE */
                _.Move("S", VAR_AUXILIARES.WFIM_V1SISINCHE);

                /*" -811- MOVE SPACES TO CHEQUEMI-DATA-EMISSAO */
                _.Move("", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);

                /*" -812- MOVE ZEROS TO WS-DIA-DT-EMISSAO */
                _.Move(0, VAR_AUXILIARES.WS_DIA_DT_EMISSAO);

                /*" -814- END-IF */
            }


            /*" -814- . */

        }

        [StopWatch]
        /*" R0611-00-FETCH-V1SISINCHE-DB-FETCH-1 */
        public void R0611_00_FETCH_V1SISINCHE_DB_FETCH_1()
        {
            /*" -803- EXEC SQL FETCH V1SISINCHE INTO :SISINCHE-NUM-CHEQUE-INTERNO END-EXEC. */

            if (V1SISINCHE.Fetch())
            {
                _.Move(V1SISINCHE.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
            }

        }

        [StopWatch]
        /*" R0611-00-FETCH-V1SISINCHE-DB-CLOSE-1 */
        public void R0611_00_FETCH_V1SISINCHE_DB_CLOSE_1()
        {
            /*" -808- EXEC SQL CLOSE V1SISINCHE END-EXEC */

            V1SISINCHE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0611_999_EXIT*/

        [StopWatch]
        /*" R0612-00-PROCESSA-REGISTRO-SECTION */
        private void R0612_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -822- MOVE 'R0612-00-PROCESSA-REGISTRO' TO PARAGRAFO */
            _.Move("R0612-00-PROCESSA-REGISTRO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -824- MOVE '612' TO WNR-EXEC-SQL. */
            _.Move("612", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -831- PERFORM R0612_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R0612_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -834- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -835- MOVE SPACES TO CHEQUEMI-DATA-EMISSAO */
                _.Move("", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);

                /*" -836- MOVE ZEROS TO WS-DIA-DT-EMISSAO */
                _.Move(0, VAR_AUXILIARES.WS_DIA_DT_EMISSAO);

                /*" -837- ELSE */
            }
            else
            {


                /*" -838- PERFORM R0035-000-CHAMA-CALCULO */

                R0035_000_CHAMA_CALCULO_SECTION();

                /*" -840- END-IF. */
            }


            /*" -840- PERFORM R0611-00-FETCH-V1SISINCHE. */

            R0611_00_FETCH_V1SISINCHE_SECTION();

        }

        [StopWatch]
        /*" R0612-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R0612_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -831- EXEC SQL SELECT DATA_EMISSAO, DAY(DATA_EMISSAO) INTO :CHEQUEMI-DATA-EMISSAO ,:WS-DIA-DT-EMISSAO FROM SEGUROS.CHEQUES_EMITIDOS WHERE NUM_CHEQUE_INTERNO = :SISINCHE-NUM-CHEQUE-INTERNO WITH UR END-EXEC. */

            var r0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                SISINCHE_NUM_CHEQUE_INTERNO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO.ToString(),
            };

            var executed_1 = R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CHEQUEMI_DATA_EMISSAO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);
                _.Move(executed_1.WS_DIA_DT_EMISSAO, VAR_AUXILIARES.WS_DIA_DT_EMISSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0612_999_EXIT*/

        [StopWatch]
        /*" R0620-00-LER-SI-DOCUMENTO-SECTION */
        private void R0620_00_LER_SI_DOCUMENTO_SECTION()
        {
            /*" -849- MOVE 'R0620-00-PROCESSA-REGISTRO' TO PARAGRAFO */
            _.Move("R0620-00-PROCESSA-REGISTRO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -851- MOVE '612' TO WNR-EXEC-SQL. */
            _.Move("612", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -853- MOVE 0 TO FIPADOFI-NUM-DOC-FISCAL */
            _.Move(0, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);

            /*" -854- MOVE SINISMES-NUM-APOL-SINISTRO TO SIPADOFI-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_APOL_SINISTRO);

            /*" -856- MOVE SINISHIS-COD-OPERACAO TO SIPADOFI-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_COD_OPERACAO);

            /*" -867- PERFORM R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1 */

            R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1();

            /*" -870- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -871- MOVE 0 TO SIPADOFI-NUM-DOCF-INTERNO */
                _.Move(0, SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO);

                /*" -872- ELSE */
            }
            else
            {


                /*" -873- PERFORM R0630-00-LER-FI-DOCUMENTO */

                R0630_00_LER_FI_DOCUMENTO_SECTION();

                /*" -874- END-IF */
            }


            /*" -874- . */

        }

        [StopWatch]
        /*" R0620-00-LER-SI-DOCUMENTO-DB-SELECT-1 */
        public void R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1()
        {
            /*" -867- EXEC SQL SELECT NUM_DOCF_INTERNO ,MAX(OCORR_HISTORICO) INTO :SIPADOFI-NUM-DOCF-INTERNO ,:SIPADOFI-OCORR-HISTORICO FROM SEGUROS.SI_PAGA_DOC_FISCAL WHERE NUM_APOL_SINISTRO = :SIPADOFI-NUM-APOL-SINISTRO AND COD_OPERACAO = :SIPADOFI-COD-OPERACAO GROUP BY NUM_DOCF_INTERNO ORDER BY NUM_DOCF_INTERNO WITH UR END-EXEC. */

            var r0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1 = new R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1()
            {
                SIPADOFI_NUM_APOL_SINISTRO = SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_APOL_SINISTRO.ToString(),
                SIPADOFI_COD_OPERACAO = SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_COD_OPERACAO.ToString(),
            };

            var executed_1 = R0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1.Execute(r0620_00_LER_SI_DOCUMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPADOFI_NUM_DOCF_INTERNO, SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO);
                _.Move(executed_1.SIPADOFI_OCORR_HISTORICO, SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_999_EXIT*/

        [StopWatch]
        /*" R0630-00-LER-FI-DOCUMENTO-SECTION */
        private void R0630_00_LER_FI_DOCUMENTO_SECTION()
        {
            /*" -883- MOVE 'R0630-00-PROCESSA-REGISTRO' TO PARAGRAFO */
            _.Move("R0630-00-PROCESSA-REGISTRO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -885- MOVE '630' TO WNR-EXEC-SQL. */
            _.Move("630", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -886- MOVE SIPADOFI-NUM-DOCF-INTERNO TO FIPADOFI-NUM-DOCF-INTERNO */
            _.Move(SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO);

            /*" -888- MOVE SINISHIS-COD-PREST-SERVICO TO FIPADOFI-COD-FORNECEDOR */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_FORNECEDOR);

            /*" -895- PERFORM R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1 */

            R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1();

            /*" -898- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -899- MOVE 0 TO FIPADOFI-NUM-DOC-FISCAL */
                _.Move(0, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);

                /*" -899- END-IF. */
            }


        }

        [StopWatch]
        /*" R0630-00-LER-FI-DOCUMENTO-DB-SELECT-1 */
        public void R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1()
        {
            /*" -895- EXEC SQL SELECT NUM_DOC_FISCAL INTO :FIPADOFI-NUM-DOC-FISCAL FROM SEGUROS.FI_PAGA_DOC_FISCAL WHERE NUM_DOCF_INTERNO = :FIPADOFI-NUM-DOCF-INTERNO AND COD_FORNECEDOR = :FIPADOFI-COD-FORNECEDOR WITH UR END-EXEC. */

            var r0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1 = new R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1()
            {
                FIPADOFI_NUM_DOCF_INTERNO = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO.ToString(),
                FIPADOFI_COD_FORNECEDOR = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_FORNECEDOR.ToString(),
            };

            var executed_1 = R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1.Execute(r0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FIPADOFI_NUM_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0630_999_EXIT*/

        [StopWatch]
        /*" R0640-00-LER-RAZAO-SOCIAL-SECTION */
        private void R0640_00_LER_RAZAO_SOCIAL_SECTION()
        {
            /*" -908- MOVE 'R0640-00-PROCESSA-REGISTRO' TO PARAGRAFO */
            _.Move("R0640-00-PROCESSA-REGISTRO", VAR_AUXILIARES.WABEND.PARAGRAFO);

            /*" -910- MOVE '640' TO WNR-EXEC-SQL. */
            _.Move("640", VAR_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -912- MOVE SPACES TO CLIENTES-NOME-RAZAO */
            _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -927- PERFORM R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1 */

            R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1();

            /*" -930- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -931- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -933- DISPLAY 'R0640-ERRO LER RAZAO SOCIAL APO=' SINISHIS-NUM-APOLICE */
                _.Display($"R0640-ERRO LER RAZAO SOCIAL APO={SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE}");

                /*" -933- END-IF. */
            }


        }

        [StopWatch]
        /*" R0640-00-LER-RAZAO-SOCIAL-DB-SELECT-1 */
        public void R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1()
        {
            /*" -927- EXEC SQL SELECT T1.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES T1 , SEGUROS.LOTERICO01 T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T2.NUM_APOLICE = :SINISMES-NUM-APOLICE AND T2.DTTERVIG = (SELECT MAX(T3.DTTERVIG) FROM SEGUROS.LOTERICO01 T3 WHERE T3.COD_CLIENTE = T2.COD_CLIENTE AND T2.NUM_APOLICE = T3.NUM_APOLICE ) WITH UR END-EXEC. */

            var r0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1 = new R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1.Execute(r0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0640_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -943- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, VAR_AUXILIARES.WABEND.WSQLCODE);

                /*" -944- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], VAR_AUXILIARES.WABEND.WSQLCODE1);

                /*" -945- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], VAR_AUXILIARES.WABEND.WSQLCODE2);

                /*" -946- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, VAR_AUXILIARES.WSQLCODE3);
            }


            /*" -948- DISPLAY WABEND. */
            _.Display(VAR_AUXILIARES.WABEND);

            /*" -949- CLOSE SI2010B1. */
            SI2010B1.Close();

            /*" -949- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -951- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -951- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}