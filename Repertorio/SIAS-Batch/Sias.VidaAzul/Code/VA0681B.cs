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
using Sias.VidaAzul.DB2.VA0681B;

namespace Code
{
    public class VA0681B
    {
        public bool IsCall { get; set; }

        public VA0681B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  RELATORIO DE DEVOLU��ES EFETUADAS  *      */
        /*"      *                             PARA OS PRODUTOS DE VIDA.          *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  TERCIO FREITAS                     *      */
        /*"      *                                                                *      */
        /*"      *   EMPRESA ................  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0681B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  15/03/2010                         *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS .................  38.632                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQUIVO_DEVOLUCAO { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis ARQUIVO_DEVOLUCAO
        {
            get
            {
                _.Move(REG_DEVOLUCAO, _ARQUIVO_DEVOLUCAO); VarBasis.RedefinePassValue(REG_DEVOLUCAO, _ARQUIVO_DEVOLUCAO, REG_DEVOLUCAO); return _ARQUIVO_DEVOLUCAO;
            }
        }
        public SortBasis<VA0681B_REG_SVA0681B> SVA0681B { get; set; } = new SortBasis<VA0681B_REG_SVA0681B>(new VA0681B_REG_SVA0681B());
        /*"01            REG-DEVOLUCAO       PIC X(350).*/
        public StringBasis REG_DEVOLUCAO { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");
        /*"01            REG-SVA0681B.*/
        public VA0681B_REG_SVA0681B REG_SVA0681B { get; set; } = new VA0681B_REG_SVA0681B();
        public class VA0681B_REG_SVA0681B : VarBasis
        {
            /*"    03        SVA-NOM-PRODUTO        PIC X(040).*/
            public StringBasis SVA_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03        SVA-NOM-FILIAL         PIC X(030).*/
            public StringBasis SVA_NOM_FILIAL { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    03        SVA-COD-SR             PIC X(036).*/
            public StringBasis SVA_COD_SR { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"    03        SVA-NOM-AGENCIA        PIC X(036).*/
            public StringBasis SVA_NOM_AGENCIA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"    03        SVA-COD-INDICADOR      PIC 9(015).*/
            public IntBasis SVA_COD_INDICADOR { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03        SVA-NUM-CERTIFICADO    PIC 9(015).*/
            public IntBasis SVA_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03        SVA-DATA-QUITACAO      PIC X(010).*/
            public StringBasis SVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03        SVA-VLR-PREMIO         PIC 9(015)V99.*/
            public DoubleBasis SVA_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    03        SVA-SIT-PROPOSTA       PIC X(030).*/
            public StringBasis SVA_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    03        SVA-DES-MOTIVO         PIC X(070).*/
            public StringBasis SVA_DES_MOTIVO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"    03        SVA-COD-USUARIO        PIC X(008).*/
            public StringBasis SVA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77  WSIST-DTMOVABE                  PIC X(10).*/
        public StringBasis WSIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WSIST-DTCURREN                  PIC X(10).*/
        public StringBasis WSIST_DTCURREN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DTINI                     PIC X(10).*/
        public StringBasis WHOST_DTINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DTFIM                     PIC X(10).*/
        public StringBasis WHOST_DTFIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WFIM-SORT                       PIC X(01).*/
        public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  HISCONPA-NUM-PARCELA            PIC S9(4) COMP.*/
        public IntBasis HISCONPA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-USUARIO                 PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-IND                      PIC  S9(004)    COMP   VALUE +0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NOM-ESCNEG             PIC  S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_NOM_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-WORK-AREAS.*/
        public VA0681B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0681B_WS_WORK_AREAS();
        public class VA0681B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 WFIM-MOVIMENTO           PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 AC-GRAVADOS              PIC 9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-LIDOS                 PIC 9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 QTD-MOVIMENTO            PIC 9(007) VALUE ZEROS.*/
            public IntBasis QTD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 WS-VLR-PREMIO            PIC S9(15)V9(2) COMP-3 VALUE 0.*/
            public DoubleBasis WS_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
            /*"01  LD00.*/
        }
        public VA0681B_LD00 LD00 { get; set; } = new VA0681B_LD00();
        public class VA0681B_LD00 : VarBasis
        {
            /*"    03 LD00-NOME-PROGRAMA       PIC X(008)  VALUE 'VA0681B'.*/
            public StringBasis LD00_NOME_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0681B");
            /*"    03 FILLER                   PIC X(029)       VALUE '    DEVOLUCOES EFETUADAS    '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"    DEVOLUCOES EFETUADAS    ");
            /*"    03 FILLER                   PIC X(005) VALUE 'DATA:'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA:");
            /*"    03 LD00-DATA                PIC X(010)  VALUE SPACES.*/
            public StringBasis LD00_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  LC01.*/
        }
        public VA0681B_LC01 LC01 { get; set; } = new VA0681B_LC01();
        public class VA0681B_LC01 : VarBasis
        {
            /*"    03 LC01-NOM-PRODUTO         PIC X(007)       VALUE 'PRODUTO'.*/
            public StringBasis LC01_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-NOM-FILIAL          PIC X(006)       VALUE 'FILIAL'.*/
            public StringBasis LC01_NOM_FILIAL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"FILIAL");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-COD-SR              PIC X(002)       VALUE 'SR'.*/
            public StringBasis LC01_COD_SR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"SR");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-NOM-AGENCIA         PIC X(007)       VALUE 'AGENCIA'.*/
            public StringBasis LC01_NOM_AGENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AGENCIA");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-COD-INDICADOR       PIC X(009)       VALUE 'INDICADOR'.*/
            public StringBasis LC01_COD_INDICADOR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"INDICADOR");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-NUM-CERTIFICADO     PIC X(011)       VALUE 'CERTIFICADO'.*/
            public StringBasis LC01_NUM_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-DATA-QUITACAO       PIC X(008)       VALUE 'QUITACAO'.*/
            public StringBasis LC01_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"QUITACAO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-VLR-PREMIO          PIC X(006)       VALUE 'PREMIO'.*/
            public StringBasis LC01_VLR_PREMIO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-SIT-PROPOSTA        PIC X(008)       VALUE 'SITUACAO'.*/
            public StringBasis LC01_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SITUACAO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-MOTIVO              PIC X(006)       VALUE 'MOTIVO'.*/
            public StringBasis LC01_MOTIVO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"MOTIVO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LC01-COD-USUARIO         PIC X(007)       VALUE 'USUARIO'.*/
            public StringBasis LC01_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"USUARIO");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER                   PIC X(197)  VALUE SPACES.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "197", "X(197)"), @"");
            /*"01  LD02.*/
        }
        public VA0681B_LD02 LD02 { get; set; } = new VA0681B_LD02();
        public class VA0681B_LD02 : VarBasis
        {
            /*"    03 LD02-NOM-PRODUTO         PIC X(040).*/
            public StringBasis LD02_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-NOM-FILIAL          PIC X(030).*/
            public StringBasis LD02_NOM_FILIAL { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-COD-SR              PIC X(036).*/
            public StringBasis LD02_COD_SR { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-NOM-AGENCIA         PIC X(036).*/
            public StringBasis LD02_NOM_AGENCIA { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-COD-INDICADOR       PIC 9(015).*/
            public IntBasis LD02_COD_INDICADOR { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-NUM-CERTIFICADO     PIC 9(014).*/
            public IntBasis LD02_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-DATA-QUITACAO       PIC X(010).*/
            public StringBasis LD02_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-VLR-PREMIO          PIC 9(015),99.*/
            public DoubleBasis LD02_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-SIT-PROPOSTA        PIC X(030).*/
            public StringBasis LD02_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-DES-MOTIVO          PIC X(070).*/
            public StringBasis LD02_DES_MOTIVO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD02-COD-USUARIO         PIC X(008).*/
            public StringBasis LD02_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01 LD03.*/
        }
        public VA0681B_LD03 LD03 { get; set; } = new VA0681B_LD03();
        public class VA0681B_LD03 : VarBasis
        {
            /*"     03 FILLER                  PIC X(020)        VALUE 'TOTAL DE DEVOLUCOES;'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL DE DEVOLUCOES;");
            /*"     03 LD03-TOT-PREMIO         PIC 9(015),99.*/
            public DoubleBasis LD03_TOT_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"     03 FILLER                  PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  WABEND.*/
        }
        public VA0681B_WABEND WABEND { get; set; } = new VA0681B_WABEND();
        public class VA0681B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(016) VALUE            '*** VA0681B *** '.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VA0681B *** ");
            /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      05      LOCALIZA-ABEND-1.*/
            public VA0681B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0681B_LOCALIZA_ABEND_1();
            public class VA0681B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO               PIC  X(040)   VALUE SPACES*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      05      LOCALIZA-ABEND-2.*/
            }
            public VA0681B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0681B_LOCALIZA_ABEND_2();
            public class VA0681B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                 PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"      05         WSQLERRO.*/
            }
            public VA0681B_WSQLERRO WSQLERRO { get; set; } = new VA0681B_WSQLERRO();
            public class VA0681B_WSQLERRO : VarBasis
            {
                /*"        10       FILLER               PIC  X(014) VALUE              ' *** SQLERRMC '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"        10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.DEVOLVID DEVOLVID { get; set; } = new Dclgens.DEVOLVID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public VA0681B_CPROPOSTA CPROPOSTA { get; set; } = new VA0681B_CPROPOSTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQUIVO_DEVOLUCAO_FILE_NAME_P, string SVA0681B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQUIVO_DEVOLUCAO.SetFile(ARQUIVO_DEVOLUCAO_FILE_NAME_P);
                SVA0681B.SetFile(SVA0681B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -253- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -255- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -257- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -262- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -263- DISPLAY 'PROGRAMA EM EXECUCAO VA0681B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0681B  ");

            /*" -264- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -265- DISPLAY 'VERSAO V.00 38.626 15/03/2010 ' */
            _.Display($"VERSAO V.00 38.626 15/03/2010 ");

            /*" -266- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -268- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -269- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -271- MOVE '0000          ' TO COMANDO. */
            _.Move("0000          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -273- PERFORM 0015-LER-SISTEMA. */

            M_0015_LER_SISTEMA_SECTION();

            /*" -275- PERFORM 0010-ABRIR-ARQUIVOS. */

            M_0010_ABRIR_ARQUIVOS_SECTION();

            /*" -276- MOVE WSIST-DTMOVABE(1:4) TO LD00-DATA(7:4). */
            _.MoveAtPosition(WSIST_DTMOVABE.Substring(1, 4), LD00.LD00_DATA, 7, 4);

            /*" -277- MOVE '/' TO LD00-DATA(6:1). */
            _.MoveAtPosition("/", LD00.LD00_DATA, 6, 1);

            /*" -278- MOVE WSIST-DTMOVABE(6:2) TO LD00-DATA(4:2). */
            _.MoveAtPosition(WSIST_DTMOVABE.Substring(6, 2), LD00.LD00_DATA, 4, 2);

            /*" -279- MOVE '/' TO LD00-DATA(3:1). */
            _.MoveAtPosition("/", LD00.LD00_DATA, 3, 1);

            /*" -281- MOVE WSIST-DTMOVABE(9:2) TO LD00-DATA(1:2). */
            _.MoveAtPosition(WSIST_DTMOVABE.Substring(9, 2), LD00.LD00_DATA, 1, 2);

            /*" -282- WRITE REG-DEVOLUCAO FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_DEVOLUCAO);

            ARQUIVO_DEVOLUCAO.Write(REG_DEVOLUCAO.GetMoveValues().ToString());

            /*" -284- WRITE REG-DEVOLUCAO FROM LC01. */
            _.Move(LC01.GetMoveValues(), REG_DEVOLUCAO);

            ARQUIVO_DEVOLUCAO.Write(REG_DEVOLUCAO.GetMoveValues().ToString());

            /*" -286- PERFORM 0020-DECLARE-CURSOR. */

            M_0020_DECLARE_CURSOR_SECTION();

            /*" -288- PERFORM 0030-FETCH-CURSOR. */

            M_0030_FETCH_CURSOR_SECTION();

            /*" -289- IF WFIM-MOVIMENTO EQUAL 'S' */

            if (WS_WORK_AREAS.WFIM_MOVIMENTO == "S")
            {

                /*" -290- DISPLAY '---------PROGRAMA VA0681B-------------' */
                _.Display($"---------PROGRAMA VA0681B-------------");

                /*" -291- DISPLAY '                                      ' */
                _.Display($"                                      ");

                /*" -292- DISPLAY '  NAO HA DEVOLUCAO A SER PROCESSADA   ' */
                _.Display($"  NAO HA DEVOLUCAO A SER PROCESSADA   ");

                /*" -293- DISPLAY '  DATA PROCESSAMENTO -' WSIST-DTMOVABE */
                _.Display($"  DATA PROCESSAMENTO -{WSIST_DTMOVABE}");

                /*" -294- DISPLAY '                                      ' */
                _.Display($"                                      ");

                /*" -295- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -296- DISPLAY '                                      ' */
                _.Display($"                                      ");

                /*" -297- MOVE ZEROS TO LD03-TOT-PREMIO */
                _.Move(0, LD03.LD03_TOT_PREMIO);

                /*" -298- WRITE REG-DEVOLUCAO FROM LD03 */
                _.Move(LD03.GetMoveValues(), REG_DEVOLUCAO);

                ARQUIVO_DEVOLUCAO.Write(REG_DEVOLUCAO.GetMoveValues().ToString());

                /*" -299- GO TO 9998-FINALIZAR */

                M_9998_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -301- END-IF. */
            }


            /*" -303- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -308- SORT SVA0681B ON ASCENDING KEY SVA-NOM-PRODUTO SVA-NOM-FILIAL INPUT PROCEDURE 0040-SELECIONA THRU 0040-FIM OUTPUT PROCEDURE 0050-GRAVA-ARQ THRU 0050-FIM. */
            SVA0681B.Sort("SVA-NOM-PRODUTO,SVA-NOM-FILIAL", () => M_0040_SELECIONA_SECTION(), () => M_0050_GRAVA_ARQ_SECTION());

            /*" -310- PERFORM 9998-FINALIZAR. */

            M_9998_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-0010-ABRIR-ARQUIVOS-SECTION */
        private void M_0010_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -319- MOVE '0010-ABRIR-ARQUIVOS ' TO PARAGRAFO. */
            _.Move("0010-ABRIR-ARQUIVOS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -323- MOVE '0010' TO COMANDO. */
            _.Move("0010", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -323- OPEN OUTPUT ARQUIVO-DEVOLUCAO. */
            ARQUIVO_DEVOLUCAO.Open(REG_DEVOLUCAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0015-LER-SISTEMA-SECTION */
        private void M_0015_LER_SISTEMA_SECTION()
        {
            /*" -332- MOVE '0015-LER-SISTEMA    ' TO PARAGRAFO. */
            _.Move("0015-LER-SISTEMA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -336- MOVE '0015' TO COMANDO. */
            _.Move("0015", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -341- PERFORM M_0015_LER_SISTEMA_DB_SELECT_1 */

            M_0015_LER_SISTEMA_DB_SELECT_1();

            /*" -344- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -345- DISPLAY '------ VA0681B --------------------------' */
                _.Display($"------ VA0681B --------------------------");

                /*" -346- DISPLAY '                                         ' */
                _.Display($"                                         ");

                /*" -347- DISPLAY 'ERRO NO ACESSO A TABELA DE SISTEMAS - VA' */
                _.Display($"ERRO NO ACESSO A TABELA DE SISTEMAS - VA");

                /*" -348- DISPLAY '                                         ' */
                _.Display($"                                         ");

                /*" -349- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -350- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -350- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0015-LER-SISTEMA-DB-SELECT-1 */
        public void M_0015_LER_SISTEMA_DB_SELECT_1()
        {
            /*" -341- EXEC SQL SELECT DATA_MOV_ABERTO INTO :WSIST-DTMOVABE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var m_0015_LER_SISTEMA_DB_SELECT_1_Query1 = new M_0015_LER_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0015_LER_SISTEMA_DB_SELECT_1_Query1.Execute(m_0015_LER_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSIST_DTMOVABE, WSIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0015_FIM*/

        [StopWatch]
        /*" M-0020-DECLARE-CURSOR-SECTION */
        private void M_0020_DECLARE_CURSOR_SECTION()
        {
            /*" -359- MOVE '0020-DECLARE-CURSOR ' TO PARAGRAFO. */
            _.Move("0020-DECLARE-CURSOR ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -363- MOVE '0020' TO COMANDO. */
            _.Move("0020", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -393- PERFORM M_0020_DECLARE_CURSOR_DB_DECLARE_1 */

            M_0020_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -395- PERFORM M_0020_DECLARE_CURSOR_DB_OPEN_1 */

            M_0020_DECLARE_CURSOR_DB_OPEN_1();

            /*" -398- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -399- DISPLAY 'VA0681B - PROBLEMAS NO OPEN CPROPOSTA ' */
                _.Display($"VA0681B - PROBLEMAS NO OPEN CPROPOSTA ");

                /*" -399- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0020-DECLARE-CURSOR-DB-DECLARE-1 */
        public void M_0020_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -393- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT E.NOME_FONTE, D.COD_ESCNEG, D.NOME_ABREV_ESCNEG, C.COD_AGENCIA, C.NOME_AGENCIA, B.NUM_PARCELA, A.COD_USUARIO, A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.SIT_REGISTRO, A.DATA_QUITACAO, A.NUM_MATRI_VENDEDOR, A.COD_CLIENTE FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.HIST_CONT_PARCELVA B, SEGUROS.AGENCIAS_CEF C, SEGUROS.ESCRITORIO_NEGOCIO D, SEGUROS.FONTES E WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.COD_OPERACAO = 501 AND B.DATA_MOVIMENTO = :WSIST-DTMOVABE AND A.AGE_COBRANCA = C.COD_AGENCIA AND C.COD_ESCNEG = D.COD_ESCNEG AND D.COD_FONTE = E.COD_FONTE ORDER BY 1,2,3 WITH UR END-EXEC. */
            CPROPOSTA = new VA0681B_CPROPOSTA(true);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT E.NOME_FONTE
							, 
							D.COD_ESCNEG
							, 
							D.NOME_ABREV_ESCNEG
							, 
							C.COD_AGENCIA
							, 
							C.NOME_AGENCIA
							, 
							B.NUM_PARCELA
							, 
							A.COD_USUARIO
							, 
							A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.SIT_REGISTRO
							, 
							A.DATA_QUITACAO
							, 
							A.NUM_MATRI_VENDEDOR
							, 
							A.COD_CLIENTE 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.HIST_CONT_PARCELVA B
							, 
							SEGUROS.AGENCIAS_CEF C
							, 
							SEGUROS.ESCRITORIO_NEGOCIO D
							, 
							SEGUROS.FONTES E 
							WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND B.COD_OPERACAO = 501 
							AND B.DATA_MOVIMENTO = '{WSIST_DTMOVABE}' 
							AND A.AGE_COBRANCA = C.COD_AGENCIA 
							AND C.COD_ESCNEG = D.COD_ESCNEG 
							AND D.COD_FONTE = E.COD_FONTE 
							ORDER BY 1
							,2
							,3";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" M-0020-DECLARE-CURSOR-DB-OPEN-1 */
        public void M_0020_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -395- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-0030-FETCH-CURSOR-SECTION */
        private void M_0030_FETCH_CURSOR_SECTION()
        {
            /*" -408- MOVE '0030-FETCH-CURSOR' TO PARAGRAFO. */
            _.Move("0030-FETCH-CURSOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -412- MOVE '0030' TO COMANDO. */
            _.Move("0030", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -428- PERFORM M_0030_FETCH_CURSOR_DB_FETCH_1 */

            M_0030_FETCH_CURSOR_DB_FETCH_1();

            /*" -431- IF VIND-NOM-ESCNEG LESS ZEROS */

            if (VIND_NOM_ESCNEG < 00)
            {

                /*" -432- MOVE ' ' TO ESCRINEG-NOME-ABREV-ESCNEG */
                _.Move(" ", ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_NOME_ABREV_ESCNEG);

                /*" -434- END-IF. */
            }


            /*" -435- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -436- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -437- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", WS_WORK_AREAS.WFIM_MOVIMENTO);

                    /*" -437- PERFORM M_0030_FETCH_CURSOR_DB_CLOSE_1 */

                    M_0030_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -439- GO TO 0030-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0030_FIM*/ //GOTO
                    return;

                    /*" -440- ELSE */
                }
                else
                {


                    /*" -442- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -442- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" M-0030-FETCH-CURSOR-DB-FETCH-1 */
        public void M_0030_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -428- EXEC SQL FETCH CPROPOSTA INTO :FONTES-NOME-FONTE, :ESCRINEG-COD-ESCNEG, :ESCRINEG-NOME-ABREV-ESCNEG :VIND-NOM-ESCNEG, :AGENCIAS-COD-AGENCIA, :AGENCIAS-NOME-AGENCIA, :HISCONPA-NUM-PARCELA, :PROPOVA-COD-USUARIO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-SIT-REGISTRO, :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-MATRI-VENDEDOR, :PROPOVA-COD-CLIENTE END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
                _.Move(CPROPOSTA.ESCRINEG_COD_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG);
                _.Move(CPROPOSTA.ESCRINEG_NOME_ABREV_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_NOME_ABREV_ESCNEG);
                _.Move(CPROPOSTA.VIND_NOM_ESCNEG, VIND_NOM_ESCNEG);
                _.Move(CPROPOSTA.AGENCIAS_COD_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);
                _.Move(CPROPOSTA.AGENCIAS_NOME_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA);
                _.Move(CPROPOSTA.HISCONPA_NUM_PARCELA, HISCONPA_NUM_PARCELA);
                _.Move(CPROPOSTA.PROPOVA_COD_USUARIO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);
                _.Move(CPROPOSTA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPOSTA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPOSTA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPOSTA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CPROPOSTA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CPROPOSTA.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(CPROPOSTA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" M-0030-FETCH-CURSOR-DB-CLOSE-1 */
        public void M_0030_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -437- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0030_FIM*/

        [StopWatch]
        /*" M-0040-SELECIONA-SECTION */
        private void M_0040_SELECIONA_SECTION()
        {
            /*" -451- MOVE '0040-SELECIONAUIVOS ' TO PARAGRAFO. */
            _.Move("0040-SELECIONAUIVOS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -455- MOVE '0040' TO COMANDO. */
            _.Move("0040", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -456- PERFORM 0100-PROCESSAR UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty()))
            {

                M_0100_PROCESSAR_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSAR-SECTION */
        private void M_0100_PROCESSAR_SECTION()
        {
            /*" -465- MOVE '0100-PROCESSAR      ' TO PARAGRAFO. */
            _.Move("0100-PROCESSAR      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -469- MOVE '0100' TO COMANDO. */
            _.Move("0100", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -471- PERFORM 0110-SELECT-PRODUTO. */

            M_0110_SELECT_PRODUTO_SECTION();

            /*" -473- PERFORM 0120-SELECT-HISCOBER. */

            M_0120_SELECT_HISCOBER_SECTION();

            /*" -475- PERFORM 0130-SELECT-COBHISVA. */

            M_0130_SELECT_COBHISVA_SECTION();

            /*" -477- PERFORM 0140-SELECT-DEVOLVID. */

            M_0140_SELECT_DEVOLVID_SECTION();

            /*" -479- COMPUTE WS-VLR-PREMIO = WS-VLR-PREMIO + HISCOBPR-VLPREMIO. */
            WS_WORK_AREAS.WS_VLR_PREMIO.Value = WS_WORK_AREAS.WS_VLR_PREMIO + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO;

            /*" -479- PERFORM 0150-CARREGA-SORT. */

            M_0150_CARREGA_SORT_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0100_LEITURA */

            M_0100_LEITURA();

        }

        [StopWatch]
        /*" M-0100-LEITURA */
        private void M_0100_LEITURA(bool isPerform = false)
        {
            /*" -483- PERFORM 0030-FETCH-CURSOR. */

            M_0030_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0110-SELECT-PRODUTO-SECTION */
        private void M_0110_SELECT_PRODUTO_SECTION()
        {
            /*" -492- MOVE '0110-SELECT-PRODUTO ' TO PARAGRAFO. */
            _.Move("0110-SELECT-PRODUTO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -496- MOVE '0110' TO COMANDO. */
            _.Move("0110", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -499- MOVE PROPOVA-NUM-APOLICE TO PRODUVG-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -502- MOVE PROPOVA-COD-SUBGRUPO TO PRODUVG-COD-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -508- PERFORM M_0110_SELECT_PRODUTO_DB_SELECT_1 */

            M_0110_SELECT_PRODUTO_DB_SELECT_1();

            /*" -511- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -512- GO TO 0100-LEITURA */

                M_0100_LEITURA(); //GOTO
                return;

                /*" -512- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-SELECT-PRODUTO-DB-SELECT-1 */
        public void M_0110_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -508- EXEC SQL SELECT NOME_PRODUTO INTO :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO END-EXEC. */

            var m_0110_SELECT_PRODUTO_DB_SELECT_1_Query1 = new M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(m_0110_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0120-SELECT-HISCOBER-SECTION */
        private void M_0120_SELECT_HISCOBER_SECTION()
        {
            /*" -521- MOVE '0120-SELECT-HISCOBER' TO PARAGRAFO. */
            _.Move("0120-SELECT-HISCOBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -525- MOVE '0120' TO COMANDO. */
            _.Move("0120", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -528- MOVE PROPOVA-NUM-CERTIFICADO TO HISCOBPR-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -534- PERFORM M_0120_SELECT_HISCOBER_DB_SELECT_1 */

            M_0120_SELECT_HISCOBER_DB_SELECT_1();

            /*" -537- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -538- GO TO 0100-LEITURA */

                M_0100_LEITURA(); //GOTO
                return;

                /*" -538- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0120-SELECT-HISCOBER-DB-SELECT-1 */
        public void M_0120_SELECT_HISCOBER_DB_SELECT_1()
        {
            /*" -534- EXEC SQL SELECT VLPREMIO INTO :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var m_0120_SELECT_HISCOBER_DB_SELECT_1_Query1 = new M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1.Execute(m_0120_SELECT_HISCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_FIM*/

        [StopWatch]
        /*" M-0130-SELECT-COBHISVA-SECTION */
        private void M_0130_SELECT_COBHISVA_SECTION()
        {
            /*" -547- MOVE '0130-SELECT-COBHISVA' TO PARAGRAFO. */
            _.Move("0130-SELECT-COBHISVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -551- MOVE '0130' TO COMANDO. */
            _.Move("0130", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -554- MOVE PROPOVA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -557- MOVE HISCONPA-NUM-PARCELA TO COBHISVI-NUM-PARCELA. */
            _.Move(HISCONPA_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -563- PERFORM M_0130_SELECT_COBHISVA_DB_SELECT_1 */

            M_0130_SELECT_COBHISVA_DB_SELECT_1();

            /*" -566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -567- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -568- PERFORM 0135-SELECT-RELATORIOS */

                    M_0135_SELECT_RELATORIOS_SECTION();

                    /*" -569- ELSE */
                }
                else
                {


                    /*" -570- GO TO 0100-LEITURA */

                    M_0100_LEITURA(); //GOTO
                    return;

                    /*" -571- END-IF */
                }


                /*" -573- END-IF. */
            }


            /*" -574- MOVE COBHISVI-COD-DEVOLUCAO TO DEVOLVID-COD-DEVOLUCAO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);

        }

        [StopWatch]
        /*" M-0130-SELECT-COBHISVA-DB-SELECT-1 */
        public void M_0130_SELECT_COBHISVA_DB_SELECT_1()
        {
            /*" -563- EXEC SQL SELECT COD_DEVOLUCAO INTO :COBHISVI-COD-DEVOLUCAO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA END-EXEC. */

            var m_0130_SELECT_COBHISVA_DB_SELECT_1_Query1 = new M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            var executed_1 = M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1.Execute(m_0130_SELECT_COBHISVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_COD_DEVOLUCAO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_FIM*/

        [StopWatch]
        /*" M-0135-SELECT-RELATORIOS-SECTION */
        private void M_0135_SELECT_RELATORIOS_SECTION()
        {
            /*" -583- MOVE '0135-SELECT-RELATORIOS' TO PARAGRAFO. */
            _.Move("0135-SELECT-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -587- MOVE '0135' TO COMANDO. */
            _.Move("0135", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -593- PERFORM M_0135_SELECT_RELATORIOS_DB_SELECT_1 */

            M_0135_SELECT_RELATORIOS_DB_SELECT_1();

            /*" -596- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -597- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -598- MOVE ZEROS TO RELATORI-COD-OPERACAO */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

                    /*" -599- ELSE */
                }
                else
                {


                    /*" -600- GO TO 0100-LEITURA */

                    M_0100_LEITURA(); //GOTO
                    return;

                    /*" -601- END-IF */
                }


                /*" -603- END-IF. */
            }


            /*" -604- MOVE RELATORI-COD-OPERACAO TO DEVOLVID-COD-DEVOLUCAO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);

        }

        [StopWatch]
        /*" M-0135-SELECT-RELATORIOS-DB-SELECT-1 */
        public void M_0135_SELECT_RELATORIOS_DB_SELECT_1()
        {
            /*" -593- EXEC SQL SELECT COD_OPERACAO INTO :RELATORI-COD-OPERACAO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA END-EXEC. */

            var m_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1 = new M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            var executed_1 = M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1.Execute(m_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0135_FIM*/

        [StopWatch]
        /*" M-0140-SELECT-DEVOLVID-SECTION */
        private void M_0140_SELECT_DEVOLVID_SECTION()
        {
            /*" -613- MOVE '0140-SELECT-DEVOLVID' TO PARAGRAFO. */
            _.Move("0140-SELECT-DEVOLVID", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -617- MOVE '0140' TO COMANDO. */
            _.Move("0140", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -619- INITIALIZE DEVOLVID-DESC-DEVOLUCAO. */
            _.Initialize(
                DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO
            );

            /*" -624- PERFORM M_0140_SELECT_DEVOLVID_DB_SELECT_1 */

            M_0140_SELECT_DEVOLVID_DB_SELECT_1();

            /*" -627- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -628- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -629- MOVE ' ' TO DEVOLVID-DESC-DEVOLUCAO */
                    _.Move(" ", DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO);

                    /*" -630- ELSE */
                }
                else
                {


                    /*" -631- GO TO 0100-LEITURA */

                    M_0100_LEITURA(); //GOTO
                    return;

                    /*" -632- END-IF */
                }


                /*" -632- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0140-SELECT-DEVOLVID-DB-SELECT-1 */
        public void M_0140_SELECT_DEVOLVID_DB_SELECT_1()
        {
            /*" -624- EXEC SQL SELECT DESC_DEVOLUCAO INTO :DEVOLVID-DESC-DEVOLUCAO FROM SEGUROS.DEVOLUCAO_VIDAZUL WHERE COD_DEVOLUCAO = :DEVOLVID-COD-DEVOLUCAO END-EXEC. */

            var m_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1 = new M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1()
            {
                DEVOLVID_COD_DEVOLUCAO = DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO.ToString(),
            };

            var executed_1 = M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1.Execute(m_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DEVOLVID_DESC_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0140_FIM*/

        [StopWatch]
        /*" M-0150-CARREGA-SORT-SECTION */
        private void M_0150_CARREGA_SORT_SECTION()
        {
            /*" -641- MOVE '0150-CARREGA-SORT' TO PARAGRAFO. */
            _.Move("0150-CARREGA-SORT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -645- MOVE '0150' TO COMANDO. */
            _.Move("0150", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -648- MOVE FONTES-NOME-FONTE TO SVA-NOM-FILIAL. */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, REG_SVA0681B.SVA_NOM_FILIAL);

            /*" -651- MOVE ESCRINEG-COD-ESCNEG TO SVA-COD-SR(1:4) */
            _.MoveAtPosition(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG, REG_SVA0681B.SVA_COD_SR, 1, 4);

            /*" -654- MOVE ESCRINEG-NOME-ABREV-ESCNEG TO SVA-COD-SR(6:15). */
            _.MoveAtPosition(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_NOME_ABREV_ESCNEG, REG_SVA0681B.SVA_COD_SR, 6, 15);

            /*" -657- MOVE AGENCIAS-COD-AGENCIA TO SVA-NOM-AGENCIA (1:4). */
            _.MoveAtPosition(AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA, REG_SVA0681B.SVA_NOM_AGENCIA, 1, 4);

            /*" -660- MOVE AGENCIAS-NOME-AGENCIA TO SVA-NOM-AGENCIA (6:19). */
            _.MoveAtPosition(AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA, REG_SVA0681B.SVA_NOM_AGENCIA, 6, 19);

            /*" -663- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO SVA-COD-INDICADOR. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, REG_SVA0681B.SVA_COD_INDICADOR);

            /*" -666- MOVE PRODUVG-NOME-PRODUTO TO SVA-NOM-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, REG_SVA0681B.SVA_NOM_PRODUTO);

            /*" -669- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA0681B.SVA_NUM_CERTIFICADO);

            /*" -672- MOVE PROPOVA-SIT-REGISTRO TO SVA-SIT-PROPOSTA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO, REG_SVA0681B.SVA_SIT_PROPOSTA);

            /*" -675- MOVE PROPOVA-DATA-QUITACAO TO SVA-DATA-QUITACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVA0681B.SVA_DATA_QUITACAO);

            /*" -678- MOVE HISCOBPR-VLPREMIO TO SVA-VLR-PREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVA0681B.SVA_VLR_PREMIO);

            /*" -681- MOVE PROPOVA-COD-USUARIO TO SVA-COD-USUARIO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO, REG_SVA0681B.SVA_COD_USUARIO);

            /*" -684- MOVE DEVOLVID-DESC-DEVOLUCAO(3:70) TO SVA-DES-MOTIVO. */
            _.Move(DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO.Substring(3, 70), REG_SVA0681B.SVA_DES_MOTIVO);

            /*" -684- RELEASE REG-SVA0681B. */
            SVA0681B.Release(REG_SVA0681B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0150_FIM*/

        [StopWatch]
        /*" M-0050-GRAVA-ARQ-SECTION */
        private void M_0050_GRAVA_ARQ_SECTION()
        {
            /*" -693- MOVE '0050-GRAVA-ARQ   ' TO PARAGRAFO. */
            _.Move("0050-GRAVA-ARQ   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -697- MOVE '0050' TO COMANDO. */
            _.Move("0050", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -699- PERFORM 0055-LE-SORT. */

            M_0055_LE_SORT_SECTION();

            /*" -700- PERFORM 0200-GRAVA-ARQUIVO UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WFIM_SORT == "S"))
            {

                M_0200_GRAVA_ARQUIVO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0050_FIM*/

        [StopWatch]
        /*" M-0055-LE-SORT-SECTION */
        private void M_0055_LE_SORT_SECTION()
        {
            /*" -709- MOVE '0055-LE-SORT     ' TO PARAGRAFO. */
            _.Move("0055-LE-SORT     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -713- MOVE '0055' TO COMANDO. */
            _.Move("0055", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -715- RETURN SVA0681B AT END */
            try
            {
                SVA0681B.Return(REG_SVA0681B, () =>
                {

                    /*" -715- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0055_FIM*/

        [StopWatch]
        /*" M-0200-GRAVA-ARQUIVO-SECTION */
        private void M_0200_GRAVA_ARQUIVO_SECTION()
        {
            /*" -724- MOVE '0210-GRAVA-ARQUIVO' TO PARAGRAFO. */
            _.Move("0210-GRAVA-ARQUIVO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -726- MOVE '0210' TO COMANDO. */
            _.Move("0210", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -730- INITIALIZE LD02. */
            _.Initialize(
                LD02
            );

            /*" -733- MOVE SVA-NOM-FILIAL TO LD02-NOM-FILIAL. */
            _.Move(REG_SVA0681B.SVA_NOM_FILIAL, LD02.LD02_NOM_FILIAL);

            /*" -736- MOVE SVA-COD-SR TO LD02-COD-SR. */
            _.Move(REG_SVA0681B.SVA_COD_SR, LD02.LD02_COD_SR);

            /*" -739- MOVE SVA-NOM-AGENCIA TO LD02-NOM-AGENCIA. */
            _.Move(REG_SVA0681B.SVA_NOM_AGENCIA, LD02.LD02_NOM_AGENCIA);

            /*" -742- MOVE SVA-COD-INDICADOR TO LD02-COD-INDICADOR. */
            _.Move(REG_SVA0681B.SVA_COD_INDICADOR, LD02.LD02_COD_INDICADOR);

            /*" -745- MOVE SVA-NOM-PRODUTO TO LD02-NOM-PRODUTO. */
            _.Move(REG_SVA0681B.SVA_NOM_PRODUTO, LD02.LD02_NOM_PRODUTO);

            /*" -748- MOVE SVA-NUM-CERTIFICADO TO LD02-NUM-CERTIFICADO. */
            _.Move(REG_SVA0681B.SVA_NUM_CERTIFICADO, LD02.LD02_NUM_CERTIFICADO);

            /*" -749- EVALUATE SVA-SIT-PROPOSTA */
            switch (REG_SVA0681B.SVA_SIT_PROPOSTA.Value.Trim())
            {

                /*" -750- WHEN    '0' */
                case "0":

                    /*" -751- MOVE 'A INTEGRAR' TO LD02-SIT-PROPOSTA */
                    _.Move("A INTEGRAR", LD02.LD02_SIT_PROPOSTA);

                    /*" -752- WHEN    '1' */
                    break;
                case "1":

                    /*" -753- MOVE 'EM CRITICA' TO LD02-SIT-PROPOSTA */
                    _.Move("EM CRITICA", LD02.LD02_SIT_PROPOSTA);

                    /*" -754- WHEN    '2' */
                    break;
                case "2":

                    /*" -755- MOVE 'NAO ACEITA' TO LD02-SIT-PROPOSTA */
                    _.Move("NAO ACEITA", LD02.LD02_SIT_PROPOSTA);

                    /*" -756- WHEN    '3' */
                    break;
                case "3":

                    /*" -757- MOVE 'INTEGRADA' TO LD02-SIT-PROPOSTA */
                    _.Move("INTEGRADA", LD02.LD02_SIT_PROPOSTA);

                    /*" -758- WHEN    '4' */
                    break;
                case "4":

                    /*" -759- MOVE 'CANCELADA' TO LD02-SIT-PROPOSTA */
                    _.Move("CANCELADA", LD02.LD02_SIT_PROPOSTA);

                    /*" -760- WHEN    '5' */
                    break;
                case "5":

                    /*" -761- MOVE 'SEM RCAP' TO LD02-SIT-PROPOSTA */
                    _.Move("SEM RCAP", LD02.LD02_SIT_PROPOSTA);

                    /*" -762- WHEN    '6' */
                    break;
                case "6":

                    /*" -763- MOVE 'SUSPENSA' TO LD02-SIT-PROPOSTA */
                    _.Move("SUSPENSA", LD02.LD02_SIT_PROPOSTA);

                    /*" -764- WHEN    '7' */
                    break;
                case "7":

                    /*" -765- MOVE 'AG EMISSAO' TO LD02-SIT-PROPOSTA */
                    _.Move("AG EMISSAO", LD02.LD02_SIT_PROPOSTA);

                    /*" -766- WHEN    '8' */
                    break;
                case "8":

                    /*" -767- MOVE 'AG PAGTO' TO LD02-SIT-PROPOSTA */
                    _.Move("AG PAGTO", LD02.LD02_SIT_PROPOSTA);

                    /*" -768- WHEN    '9' */
                    break;
                case "9":

                    /*" -769- MOVE 'AG PROPO' TO LD02-SIT-PROPOSTA */
                    _.Move("AG PROPO", LD02.LD02_SIT_PROPOSTA);

                    /*" -770- WHEN    '10' */
                    break;
                case "10":

                    /*" -771- MOVE 'AG CRIVO' TO LD02-SIT-PROPOSTA */
                    _.Move("AG CRIVO", LD02.LD02_SIT_PROPOSTA);

                    /*" -772- WHEN    OTHER */
                    break;
                default:

                    /*" -773- MOVE 'A INTEGRAR' TO LD02-SIT-PROPOSTA */
                    _.Move("A INTEGRAR", LD02.LD02_SIT_PROPOSTA);

                    /*" -775- END-EVALUATE. */
                    break;
            }


            /*" -778- MOVE SVA-DATA-QUITACAO TO LD02-DATA-QUITACAO. */
            _.Move(REG_SVA0681B.SVA_DATA_QUITACAO, LD02.LD02_DATA_QUITACAO);

            /*" -781- MOVE SVA-VLR-PREMIO TO LD02-VLR-PREMIO. */
            _.Move(REG_SVA0681B.SVA_VLR_PREMIO, LD02.LD02_VLR_PREMIO);

            /*" -784- MOVE SVA-COD-USUARIO TO LD02-COD-USUARIO. */
            _.Move(REG_SVA0681B.SVA_COD_USUARIO, LD02.LD02_COD_USUARIO);

            /*" -787- MOVE SVA-DES-MOTIVO TO LD02-DES-MOTIVO. */
            _.Move(REG_SVA0681B.SVA_DES_MOTIVO, LD02.LD02_DES_MOTIVO);

            /*" -789- WRITE REG-DEVOLUCAO FROM LD02. */
            _.Move(LD02.GetMoveValues(), REG_DEVOLUCAO);

            ARQUIVO_DEVOLUCAO.Write(REG_DEVOLUCAO.GetMoveValues().ToString());

            /*" -789- ADD 1 TO AC-GRAVADOS. */
            WS_WORK_AREAS.AC_GRAVADOS.Value = WS_WORK_AREAS.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM M_0200_LEITURA */

            M_0200_LEITURA();

        }

        [StopWatch]
        /*" M-0200-LEITURA */
        private void M_0200_LEITURA(bool isPerform = false)
        {
            /*" -793- PERFORM 0055-LE-SORT. */

            M_0055_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-9997-FECHAR-ARQUIVOS-SECTION */
        private void M_9997_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -802- MOVE '9997-FECHAR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("9997-FECHAR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -806- MOVE '9997' TO COMANDO. */
            _.Move("9997", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -806- CLOSE ARQUIVO-DEVOLUCAO. */
            ARQUIVO_DEVOLUCAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9997_FIM*/

        [StopWatch]
        /*" M-9998-FINALIZAR-SECTION */
        private void M_9998_FINALIZAR_SECTION()
        {
            /*" -815- MOVE '9998-FINALIZAR      ' TO PARAGRAFO. */
            _.Move("9998-FINALIZAR      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -819- MOVE '9998' TO COMANDO. */
            _.Move("9998", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -820- IF AC-LIDOS GREATER ZEROS */

            if (WS_WORK_AREAS.AC_LIDOS > 00)
            {

                /*" -821- MOVE WS-VLR-PREMIO TO LD03-TOT-PREMIO */
                _.Move(WS_WORK_AREAS.WS_VLR_PREMIO, LD03.LD03_TOT_PREMIO);

                /*" -822- WRITE REG-DEVOLUCAO FROM LD03 */
                _.Move(LD03.GetMoveValues(), REG_DEVOLUCAO);

                ARQUIVO_DEVOLUCAO.Write(REG_DEVOLUCAO.GetMoveValues().ToString());

                /*" -824- END-IF. */
            }


            /*" -825- DISPLAY '                    ' . */
            _.Display($"                    ");

            /*" -826- DISPLAY 'TOTAL DE LIDOS....: ' AC-LIDOS. */
            _.Display($"TOTAL DE LIDOS....: {WS_WORK_AREAS.AC_LIDOS}");

            /*" -827- DISPLAY 'TOTAL DE GRAVADOS.: ' AC-GRAVADOS. */
            _.Display($"TOTAL DE GRAVADOS.: {WS_WORK_AREAS.AC_GRAVADOS}");

            /*" -828- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -830- DISPLAY '** VA0681B ** TERMINO NORMAL    ' . */
            _.Display($"** VA0681B ** TERMINO NORMAL    ");

            /*" -832- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -834- PERFORM 9997-FECHAR-ARQUIVOS. */

            M_9997_FECHAR_ARQUIVOS_SECTION();

            /*" -834- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9998_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -845- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -846- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -847- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -849- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -850- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

            /*" -852- DISPLAY WSQLERRO. */
            _.Display(WABEND.WSQLERRO);

            /*" -852- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -855- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -856- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -856- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -860- DISPLAY '*** VA0681B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0681B *** ERRO DE EXECUCAO");

            /*" -862- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -862- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/
    }
}