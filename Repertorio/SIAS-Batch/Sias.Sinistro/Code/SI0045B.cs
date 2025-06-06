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
using Sias.Sinistro.DB2.SI0045B;

namespace Code
{
    public class SI0045B
    {
        public bool IsCall { get; set; }

        public SI0045B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0045B                             *      */
        /*"      *   ANALISTA ............... JEFFERSON                           *      */
        /*"      *   PROGRAMADOR ............ JEFFERSON                           *      */
        /*"      *   DATA CODIFICACAO ....... FEVEREIRO / 2007                    *      */
        /*"      *   FUNCAO :                                                            */
        /*"      *   - GERA O CANCELAMENTO DOS SINISTROS COM DOCUMENTOS PENDENTES *      */
        /*"      *   (TED) APOS 30 DIAS DA EMISSAO DA 3  REITECAO DO TED, SOLICI- *      */
        /*"      *   TANDO OS DOCUMENTOS PENDENTES. FAZ O CANCELAMENTO SOMENTE    *      */
        /*"      *   PARA ARQUIVO DO PROCESSO PODENDO SER O SINISTRO REATIVADO A  *      */
        /*"      *   QUALQUER MOMENTO.                                            *      */
        /*"      *   - FAZ EMISSAO DE RELATORIO COM ESSES SINISTROS CANCELADOS    *      */
        /*"      *   PARA GEPOI                                                   *      */
        /*"      *   - NOME DO ARQUIVO SAIDA.    "PRINTER"                        *      */
        /*"      *     RELATORIO QUE DEVERA SER ENVIADO A GEPOI, EM UMA VIA       *      */
        /*"      ***************                                                  *      */
        /*"      *   O BOOK LBSI1001 ENCONTRA-SE NA LIB DES.SIA.SRCLIB.DATA       *      */
        /*"      ***************                                                  *      */
        /*"      *   OS BOOKS LBWCT001 E LBWCT002 ENCONTRAM-SE NA LIB             *      */
        /*"      *   DES.SIA.SRCLIB.DATA                                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 25/08/2008 - PATRICIA SALES                                    *      */
        /*"      *              CADMUS 13418                                      *      */
        /*"      *              PROCURAR V.03                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 16/07/2008 - WELLINGTON VERAS (POLITEC                         *      */
        /*"      *              PROJETO FGV                                       *      */
        /*"      *              INIBIR O COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  20/10/2010 - CADIMUS 47494/2010 - CIRCULAR 395:               *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *               MARCELO NEVES (TE41729)   PROCURAR: C395         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0045B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RSI0045B
        {
            get
            {
                _.Move(REG_MOVTO, _RSI0045B); VarBasis.RedefinePassValue(REG_MOVTO, _RSI0045B, REG_MOVTO); return _RSI0045B;
            }
        }
        /*"01          REG-MOVTO           PIC  X(132).*/
        public StringBasis REG_MOVTO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01     LINK-PARAMETRO.*/
        public SI0045B_LINK_PARAMETRO LINK_PARAMETRO { get; set; } = new SI0045B_LINK_PARAMETRO();
        public class SI0045B_LINK_PARAMETRO : VarBasis
        {
            /*"  05   LINK-NUM-APOL-SINISTRO        PIC  9(013).*/
            public IntBasis LINK_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05   LINK-VAL-RESERVA-DESEJADA     PIC  9(013)V99.*/
            public DoubleBasis LINK_VAL_RESERVA_DESEJADA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   LINK-MSG-ADICIONAL            PIC  X(080).*/
            public StringBasis LINK_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05   LINK-IND-ERRO                 PIC  X(003).*/
            public StringBasis LINK_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05   LINK-MSG-ERRO                 PIC  X(080).*/
            public StringBasis LINK_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05   LINK-SQLCODE                  PIC S9(004) COMP.*/
            public IntBasis LINK_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   LINK-NOME-TABELA              PIC  X(030).*/
            public StringBasis LINK_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"01  HOST-MES-OPERACAO-AVISO      PIC S9(004)    VALUE +0 COMP.*/
        }
        public IntBasis HOST_MES_OPERACAO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-VALOR-PENDENTE          PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis HOST_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  HOST-VAL-OPERACAO-PAGO       PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis HOST_VAL_OPERACAO_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  HOST-OCORR-HIST-CANCELAMENTO PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis HOST_OCORR_HIST_CANCELAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-COD-OPERAC-CANCELAMENTO PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis HOST_COD_OPERAC_CANCELAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-NUM-CARTA               PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis HOST_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  HOST-E-PARA-CANCELAR         PIC  X(003)    VALUE SPACES.*/
        public StringBasis HOST_E_PARA_CANCELAR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  WHOST-COD-FASE               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DIFERENCA-DIAS         PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_DIFERENCA_DIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-CARTA-REITERA          PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_CARTA_REITERA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-NUM-CARTA-REITERA      PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_CARTA_REITERA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-REITERACOES            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_REITERACOES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  AREA-DE-WORK.*/
        public SI0045B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0045B_AREA_DE_WORK();
        public class SI0045B_AREA_DE_WORK : VarBasis
        {
            /*" 05 WESTA-SIMOVIMENTO-SINI       PIC X(003)     VALUE SPACES.*/
            public StringBasis WESTA_SIMOVIMENTO_SINI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*" 05 WCOD-USUARIO-ANT             PIC X(010)     VALUE SPACES.*/
            public StringBasis WCOD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*" 05 WFIM-JOIN                    PIC X(001)     VALUE SPACES.*/
            public StringBasis WFIM_JOIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 05 AC-PAGINA                    PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-LINHAS                    PIC 9(002)     VALUE 90.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 90);
            /*" 05 AC-L-JOIN                    PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_L_JOIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-GRAVA-SINISHIS            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SINISHIS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-ACHOU-SIMOVSIN            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_ACHOU_SIMOVSIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-GRAVA-SISINACO            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SISINACO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-GRAVA-SININFAS            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SININFAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-GRAVA-SIHISACO            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SIHISACO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-UPDAT-SINISMES            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_UPDAT_SINISMES { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-UPDAT-SINISHIS            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_UPDAT_SINISHIS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-UPDAT-SINIHAB1            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_UPDAT_SINIHAB1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-ACHOU-SINISCON            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_ACHOU_SINISCON { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-GRAVA-SINISACO            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SINISACO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-UPDAT-SINISCON            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_UPDAT_SINISCON { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 05 AC-GRAVA-SIHISACM            PIC 9(006)     VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SIHISACM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05    WTIME.*/
            public SI0045B_WTIME WTIME { get; set; } = new SI0045B_WTIME();
            public class SI0045B_WTIME : VarBasis
            {
                /*"    10  WTIME-HH                 PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WTIME-MM                 PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WTIME-SS                 PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WTIME-CC                 PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05    WTIME-AUX.*/
            }
            public SI0045B_WTIME_AUX WTIME_AUX { get; set; } = new SI0045B_WTIME_AUX();
            public class SI0045B_WTIME_AUX : VarBasis
            {
                /*"    10  WTIME-HH-AUX             PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_HH_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WTIME-PONTO01            PIC  X(001)   VALUE '.'.*/
                public StringBasis WTIME_PONTO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10  WTIME-MM-AUX             PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_MM_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WTIME-PONTO02            PIC  X(001)   VALUE '.'.*/
                public StringBasis WTIME_PONTO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10  WTIME-SS-AUX             PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WTIME_SS_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05    WDATA.*/
            }
            public SI0045B_WDATA WDATA { get; set; } = new SI0045B_WDATA();
            public class SI0045B_WDATA : VarBasis
            {
                /*"    10  WDATA-DIA                PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WDATA-TRACO01            PIC  X(001)   VALUE '/'.*/
                public StringBasis WDATA_TRACO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10  WDATA-MES                PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  WDATA-TRACO02            PIC  X(001)   VALUE '/'.*/
                public StringBasis WDATA_TRACO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10  WDATA-ANO                PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05    WDATA-SQL.*/
            }
            public SI0045B_WDATA_SQL WDATA_SQL { get; set; } = new SI0045B_WDATA_SQL();
            public class SI0045B_WDATA_SQL : VarBasis
            {
                /*"    10  WDATA-ANO-SQL            PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WDATA_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10  FILLER                   PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  WDATA-MES-SQL            PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WDATA_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10  FILLER                   PIC  X(001)   VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10  WDATA-DIA-SQL            PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WDATA_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        LC-00                 PIC  X(132)   VALUE SPACES.*/
            }
            public StringBasis LC_00 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"  05        LC-01.*/
            public SI0045B_LC_01 LC_01 { get; set; } = new SI0045B_LC_01();
            public class SI0045B_LC_01 : VarBasis
            {
                /*"     10     FILLER                PIC  X(045)   VALUE 'SI0045B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SI0045B");
                /*"     10     FILLER                PIC  X(069)   VALUE            '            CAIXA SEGURADORA S.A.        '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)"), @"            CAIXA SEGURADORA S.A.        ");
                /*"     10     FILLER                PIC  X(014)   VALUE 'PAGINA:'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"PAGINA:");
                /*"     10     LC-01-PAGINA          PIC  Z999.*/
                public IntBasis LC_01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"  05        LC-02.*/
            }
            public SI0045B_LC_02 LC_02 { get; set; } = new SI0045B_LC_02();
            public class SI0045B_LC_02 : VarBasis
            {
                /*"     10     FILLER                PIC  X(045)   VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                /*"     10     FILLER                PIC  X(069)   VALUE            '                                         '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)"), @"                                         ");
                /*"     10     FILLER                PIC  X(008)   VALUE 'DATA  :'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA  :");
                /*"     10     LC-02-DATA            PIC  X(010)   VALUE SPACES.*/
                public StringBasis LC_02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05        LC-03.*/
            }
            public SI0045B_LC_03 LC_03 { get; set; } = new SI0045B_LC_03();
            public class SI0045B_LC_03 : VarBasis
            {
                /*"     10     FILLER                PIC  X(036)   VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"     10     FILLER                PIC  X(078)   VALUE            'RELACAO DE SINISTROS PARA ARQUIVAMENTO POR FALTA DE            'DOCUMENTOS'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "78", "X(078)"), @"RELACAO DE SINISTROS PARA ARQUIVAMENTO POR FALTA DE            ");
                /*"     10     FILLER                PIC  X(010)   VALUE 'HORA  :'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA  :");
                /*"     10     LC-03-HORA            PIC  X(008)   VALUE SPACES.*/
                public StringBasis LC_03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05        LC-04.*/
            }
            public SI0045B_LC_04 LC_04 { get; set; } = new SI0045B_LC_04();
            public class SI0045B_LC_04 : VarBasis
            {
                /*"     10     FILLER                PIC  X(132)   VALUE ALL '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05        LC-05.*/
            }
            public SI0045B_LC_05 LC_05 { get; set; } = new SI0045B_LC_05();
            public class SI0045B_LC_05 : VarBasis
            {
                /*"     10     FILLER                PIC  X(034) VALUE            'SINISTRO       NOME DO ANALISTA DO'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"SINISTRO       NOME DO ANALISTA DO");
                /*"     10     FILLER                PIC  X(042) VALUE            ' PROCESSO             N REIT.  N.ULT.CARTA'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @" PROCESSO             N REIT.  N.ULT.CARTA");
                /*"     10     FILLER                PIC  X(035) VALUE            '  DATA CARTA  N.PROTOCOLO  FILIAL  '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"  DATA CARTA  N.PROTOCOLO  FILIAL  ");
                /*"     10     FILLER                PIC  X(021) VALUE            'DESTINATARIO         '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"DESTINATARIO         ");
                /*"  05      LD-01.*/
            }
            public SI0045B_LD_01 LD_01 { get; set; } = new SI0045B_LD_01();
            public class SI0045B_LD_01 : VarBasis
            {
                /*"     10   DET-NUM-SINISTRO        PIC  9(013) VALUE ZEROS.*/
                public IntBasis DET_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"     10   FILLER                  PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     10   DET-ANALISTA-SINI       PIC  X(040) VALUE SPACES.*/
                public StringBasis DET_ANALISTA_SINI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     10   FILLER                  PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     10   DET-NUM-ULT-REITERA     PIC  ZZ9.*/
                public IntBasis DET_NUM_ULT_REITERA { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                /*"     10   FILLER                  PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"     10   DET-NUM-ULT-CARTA       PIC  ZZZZZZZZ9.*/
                public IntBasis DET_NUM_ULT_CARTA { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"     10   FILLER                  PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     10   DET-DATA-ULT-CARTA      PIC  X(010) VALUE SPACES.*/
                public StringBasis DET_DATA_ULT_CARTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"     10   FILLER                  PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     10   DET-NUM-PROTOCOLO       PIC  ZZZZZZZZ9BBBB.*/
                public IntBasis DET_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9BBBB."));
                /*"     10   DET-COD-FILIAL          PIC  ZZZ9.*/
                public IntBasis DET_COD_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"     10   FILLER                  PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     10   DET-DESTINATARIO        PIC  X(021) VALUE SPACES.*/
                public StringBasis DET_DESTINATARIO { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"  05      LD-02.*/
            }
            public SI0045B_LD_02 LD_02 { get; set; } = new SI0045B_LD_02();
            public class SI0045B_LD_02 : VarBasis
            {
                /*"     10   FILLER                  PIC  X(025) VALUE          'QUANTIDADE DE SINISTROS: '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"QUANTIDADE DE SINISTROS: ");
                /*"     10   LD2-QUANTIDADE-LIDA     PIC  ZZZZ9.*/
                public IntBasis LD2_QUANTIDADE_LIDA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"     10   FILLER                  PIC  X(102) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "102", "X(102)"), @"");
                /*"  05      LD-03.*/
            }
            public SI0045B_LD_03 LD_03 { get; set; } = new SI0045B_LD_03();
            public class SI0045B_LD_03 : VarBasis
            {
                /*"     10   FILLER                  PIC  X(033) VALUE          ' "NENHUM SINISTRO FOI CANCELADO" '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"     10   FILLER                  PIC  X(105) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "105", "X(105)"), @"");
                /*"  05      WS-QUANTIDADE-LIDA      PIC  9(05).*/
            }
            public IntBasis WS_QUANTIDADE_LIDA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05        WABEND.*/
            public SI0045B_WABEND WABEND { get; set; } = new SI0045B_WABEND();
            public class SI0045B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0045B'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0045B");
                /*"    10      FILLER               PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL         PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER               PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE             PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GECARTA GECARTA { get; set; } = new Dclgens.GECARTA();
        public Dclgens.GECARTEX GECARTEX { get; set; } = new Dclgens.GECARTEX();
        public Dclgens.GECARACO GECARACO { get; set; } = new Dclgens.GECARACO();
        public Dclgens.GECARPAR GECARPAR { get; set; } = new Dclgens.GECARPAR();
        public Dclgens.GEDESTIN GEDESTIN { get; set; } = new Dclgens.GEDESTIN();
        public Dclgens.GEDESCLA GEDESCLA { get; set; } = new Dclgens.GEDESCLA();
        public Dclgens.GERECADE GERECADE { get; set; } = new Dclgens.GERECADE();
        public Dclgens.SIDOCACO SIDOCACO { get; set; } = new Dclgens.SIDOCACO();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public Dclgens.SIREFAEV SIREFAEV { get; set; } = new Dclgens.SIREFAEV();
        public Dclgens.SIDOCPAR SIDOCPAR { get; set; } = new Dclgens.SIDOCPAR();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SIEVETIP SIEVETIP { get; set; } = new Dclgens.SIEVETIP();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SIANAROD SIANAROD { get; set; } = new Dclgens.SIANAROD();
        public Dclgens.SIHISACO SIHISACO { get; set; } = new Dclgens.SIHISACO();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINISCON SINISCON { get; set; } = new Dclgens.SINISCON();
        public Dclgens.SINISACO SINISACO { get; set; } = new Dclgens.SINISACO();
        public Dclgens.SIHISACM SIHISACM { get; set; } = new Dclgens.SIHISACM();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public SI0045B_JOIN_1 JOIN_1 { get; set; } = new SI0045B_JOIN_1();
        public SI0045B_LEITURA_FASES LEITURA_FASES { get; set; } = new SI0045B_LEITURA_FASES();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0045B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0045B.SetFile(RSI0045B_FILE_NAME_P);

                /*" -294- MOVE '0001' TO WNR-EXEC-SQL. */
                _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -294- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -295- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -296- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -296- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -304- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -306- OPEN OUTPUT RSI0045B. */
            RSI0045B.Open(REG_MOVTO);

            /*" -307- PERFORM R0900-00-DECLARA-JOIN */

            R0900_00_DECLARA_JOIN_SECTION();

            /*" -309- PERFORM R0910-00-LE-JOIN */

            R0910_00_LE_JOIN_SECTION();

            /*" -311- MOVE SISINACO-COD-USUARIO TO WCOD-USUARIO-ANT. */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO, AREA_DE_WORK.WCOD_USUARIO_ANT);

            /*" -315- PERFORM R1000-00-PROCESSA UNTIL WFIM-JOIN EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_JOIN == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -318- MOVE AC-GRAVA-SINISHIS TO LD2-QUANTIDADE-LIDA WS-QUANTIDADE-LIDA. */
            _.Move(AREA_DE_WORK.AC_GRAVA_SINISHIS, AREA_DE_WORK.LD_02.LD2_QUANTIDADE_LIDA, AREA_DE_WORK.WS_QUANTIDADE_LIDA);

            /*" -319- IF WS-QUANTIDADE-LIDA GREATER ZERO */

            if (AREA_DE_WORK.WS_QUANTIDADE_LIDA > 00)
            {

                /*" -320- WRITE REG-MOVTO FROM LC-04 AFTER 1 */
                _.Move(AREA_DE_WORK.LC_04.GetMoveValues(), REG_MOVTO);

                RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

                /*" -321- WRITE REG-MOVTO FROM LD-02 AFTER 2 */
                _.Move(AREA_DE_WORK.LD_02.GetMoveValues(), REG_MOVTO);

                RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

                /*" -322- ELSE */
            }
            else
            {


                /*" -323- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO WDATA-ANO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.WDATA.WDATA_ANO);

                /*" -324- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WDATA-MES */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.WDATA.WDATA_MES);

                /*" -325- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO WDATA-DIA */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.WDATA.WDATA_DIA);

                /*" -326- MOVE '/' TO WDATA-TRACO01 WDATA-TRACO02 */
                _.Move("/", AREA_DE_WORK.WDATA.WDATA_TRACO01, AREA_DE_WORK.WDATA.WDATA_TRACO02);

                /*" -328- MOVE WDATA TO LC-02-DATA */
                _.Move(AREA_DE_WORK.WDATA, AREA_DE_WORK.LC_02.LC_02_DATA);

                /*" -329- ACCEPT WTIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME);

                /*" -330- MOVE WTIME-HH TO WTIME-HH-AUX */
                _.Move(AREA_DE_WORK.WTIME.WTIME_HH, AREA_DE_WORK.WTIME_AUX.WTIME_HH_AUX);

                /*" -331- MOVE WTIME-MM TO WTIME-MM-AUX */
                _.Move(AREA_DE_WORK.WTIME.WTIME_MM, AREA_DE_WORK.WTIME_AUX.WTIME_MM_AUX);

                /*" -332- MOVE WTIME-SS TO WTIME-SS-AUX */
                _.Move(AREA_DE_WORK.WTIME.WTIME_SS, AREA_DE_WORK.WTIME_AUX.WTIME_SS_AUX);

                /*" -333- MOVE ':' TO WTIME-PONTO01 WTIME-PONTO02 */
                _.Move(":", AREA_DE_WORK.WTIME_AUX.WTIME_PONTO01, AREA_DE_WORK.WTIME_AUX.WTIME_PONTO02);

                /*" -334- MOVE WTIME-AUX TO LC-03-HORA */
                _.Move(AREA_DE_WORK.WTIME_AUX, AREA_DE_WORK.LC_03.LC_03_HORA);

                /*" -335- PERFORM R4100-00-IMPRIMIR-CABECALHO */

                R4100_00_IMPRIMIR_CABECALHO_SECTION();

                /*" -336- WRITE REG-MOVTO FROM LD-03 AFTER 2 */
                _.Move(AREA_DE_WORK.LD_03.GetMoveValues(), REG_MOVTO);

                RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

                /*" -336- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -341- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -343- CLOSE RSI0045B. */
            RSI0045B.Close();

            /*" -344- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -345- DISPLAY '***   SI0045B - FIM NORMAL ***' */
            _.Display($"***   SI0045B - FIM NORMAL ***");

            /*" -346- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -347- DISPLAY 'LIDOS DO FETCH........: ' AC-L-JOIN */
            _.Display($"LIDOS DO FETCH........: {AREA_DE_WORK.AC_L_JOIN}");

            /*" -348- DISPLAY 'INCL SINI-HISTORICO...: ' AC-GRAVA-SINISHIS */
            _.Display($"INCL SINI-HISTORICO...: {AREA_DE_WORK.AC_GRAVA_SINISHIS}");

            /*" -349- DISPLAY 'LIDO SI-MOVIMENTO-SINI: ' AC-ACHOU-SIMOVSIN */
            _.Display($"LIDO SI-MOVIMENTO-SINI: {AREA_DE_WORK.AC_ACHOU_SIMOVSIN}");

            /*" -350- DISPLAY 'INCL SI-SINISTRO-ACOMP: ' AC-GRAVA-SISINACO */
            _.Display($"INCL SI-SINISTRO-ACOMP: {AREA_DE_WORK.AC_GRAVA_SISINACO}");

            /*" -351- DISPLAY 'INCL SI-SINISTRO-FASE.: ' AC-GRAVA-SININFAS */
            _.Display($"INCL SI-SINISTRO-FASE.: {AREA_DE_WORK.AC_GRAVA_SININFAS}");

            /*" -352- DISPLAY 'INCL SI-HIST-ACOMPANHA: ' AC-GRAVA-SIHISACO */
            _.Display($"INCL SI-HIST-ACOMPANHA: {AREA_DE_WORK.AC_GRAVA_SIHISACO}");

            /*" -353- DISPLAY 'ALTE SINI-MESTRE......: ' AC-UPDAT-SINISMES */
            _.Display($"ALTE SINI-MESTRE......: {AREA_DE_WORK.AC_UPDAT_SINISMES}");

            /*" -354- DISPLAY 'ALTE SINI-HISTORICO...: ' AC-UPDAT-SINISHIS */
            _.Display($"ALTE SINI-HISTORICO...: {AREA_DE_WORK.AC_UPDAT_SINISHIS}");

            /*" -355- DISPLAY 'ALTE SINI-HABIT01.....: ' AC-UPDAT-SINIHAB1 */
            _.Display($"ALTE SINI-HABIT01.....: {AREA_DE_WORK.AC_UPDAT_SINIHAB1}");

            /*" -356- DISPLAY 'LIDO SINI-CONTROLE....: ' AC-ACHOU-SINISCON */
            _.Display($"LIDO SINI-CONTROLE....: {AREA_DE_WORK.AC_ACHOU_SINISCON}");

            /*" -357- DISPLAY 'INCL SINISTRO-ACOMPANH: ' AC-GRAVA-SINISACO */
            _.Display($"INCL SINISTRO-ACOMPANH: {AREA_DE_WORK.AC_GRAVA_SINISACO}");

            /*" -358- DISPLAY 'ALTE SINI-CONTROLE....: ' AC-UPDAT-SINISCON */
            _.Display($"ALTE SINI-CONTROLE....: {AREA_DE_WORK.AC_UPDAT_SINISCON}");

            /*" -361- DISPLAY 'INCL SI-HIST-ACOMP....: ' AC-GRAVA-SIHISACM */
            _.Display($"INCL SI-HIST-ACOMP....: {AREA_DE_WORK.AC_GRAVA_SIHISACM}");

            /*" -361- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -362- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -370- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -376- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -379- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -380- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -380- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -376- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r0500_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0500_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-JOIN-SECTION */
        private void R0900_00_DECLARA_JOIN_SECTION()
        {
            /*" -390- MOVE '0090' TO WNR-EXEC-SQL. */
            _.Move("0090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -445- PERFORM R0900_00_DECLARA_JOIN_DB_DECLARE_1 */

            R0900_00_DECLARA_JOIN_DB_DECLARE_1();

            /*" -447- PERFORM R0900_00_DECLARA_JOIN_DB_OPEN_1 */

            R0900_00_DECLARA_JOIN_DB_OPEN_1();

            /*" -450- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -451- DISPLAY 'PROBLEMAS NO OPEN JOIN ' */
                _.Display($"PROBLEMAS NO OPEN JOIN ");

                /*" -451- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-JOIN-DB-DECLARE-1 */
        public void R0900_00_DECLARA_JOIN_DB_DECLARE_1()
        {
            /*" -445- EXEC SQL DECLARE JOIN-1 CURSOR FOR SELECT A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.DAC_PROTOCOLO_SINI, A.NUM_OCORR_SINIACO, A.COD_EVENTO, A.DATA_MOVTO_SINIACO, (DAYS(CURRENT DATE) - DAYS(A.DATA_MOVTO_SINIACO)), A.COD_USUARIO, A.NUM_CARTA, B.SEQ_CARTA_REITERA, VALUE(B.NUM_CARTA_REITERA, 0), D.NUM_APOL_SINISTRO, D.COD_PRODUTO FROM SEGUROS.SI_SINISTRO_ACOMP A, SEGUROS.GE_CARTA B, SEGUROS.GE_CARTA_ACOMP C, SEGUROS.SINISTRO_MESTRE D, SEGUROS.SI_DOCUMENTO_ACOMP E WHERE A.COD_EVENTO IN (1002, 1024, 1187) AND A.COD_FONTE = D.COD_FONTE AND A.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI AND A.COD_FONTE = E.COD_FONTE AND A.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI AND D.SIT_REGISTRO <> '2' AND A.NUM_CARTA = B.NUM_CARTA AND A.NUM_CARTA = C.NUM_CARTA AND B.STA_ENVIO_CARTA = 'S' AND C.COD_EVENTO = 2020 AND E.COD_EVENTO = 2013 AND A.NUM_OCORR_SINIACO = (SELECT MAX(E.NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_ACOMP E WHERE A.COD_FONTE = E.COD_FONTE AND A.NUM_PROTOCOLO_SINI= E.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI= E.DAC_PROTOCOLO_SINI) AND E.TIMESTAMP = (SELECT MAX(F.TIMESTAMP) FROM SEGUROS.SI_DOCUMENTO_ACOMP F WHERE E.COD_FONTE = F.COD_FONTE AND E.NUM_PROTOCOLO_SINI= F.NUM_PROTOCOLO_SINI AND E.DAC_PROTOCOLO_SINI= F.DAC_PROTOCOLO_SINI AND F.COD_EVENTO = 2013) ORDER BY A.COD_USUARIO, A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.NUM_CARTA WITH UR END-EXEC. */
            JOIN_1 = new SI0045B_JOIN_1(false);
            string GetQuery_JOIN_1()
            {
                var query = @$"SELECT A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.DAC_PROTOCOLO_SINI
							, 
							A.NUM_OCORR_SINIACO
							, 
							A.COD_EVENTO
							, 
							A.DATA_MOVTO_SINIACO
							, 
							(DAYS(CURRENT DATE) - 
							DAYS(A.DATA_MOVTO_SINIACO))
							, 
							A.COD_USUARIO
							, 
							A.NUM_CARTA
							, 
							B.SEQ_CARTA_REITERA
							, 
							VALUE(B.NUM_CARTA_REITERA
							, 0)
							, 
							D.NUM_APOL_SINISTRO
							, 
							D.COD_PRODUTO 
							FROM SEGUROS.SI_SINISTRO_ACOMP A
							, 
							SEGUROS.GE_CARTA B
							, 
							SEGUROS.GE_CARTA_ACOMP C
							, 
							SEGUROS.SINISTRO_MESTRE D
							, 
							SEGUROS.SI_DOCUMENTO_ACOMP E 
							WHERE A.COD_EVENTO IN (1002
							, 1024
							, 1187) 
							AND A.COD_FONTE = D.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI 
							AND A.COD_FONTE = E.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = E.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = E.DAC_PROTOCOLO_SINI 
							AND D.SIT_REGISTRO <> '2' 
							AND A.NUM_CARTA = B.NUM_CARTA 
							AND A.NUM_CARTA = C.NUM_CARTA 
							AND B.STA_ENVIO_CARTA = 'S' 
							AND C.COD_EVENTO = 2020 
							AND E.COD_EVENTO = 2013 
							AND A.NUM_OCORR_SINIACO = 
							(SELECT MAX(E.NUM_OCORR_SINIACO) 
							FROM SEGUROS.SI_SINISTRO_ACOMP E 
							WHERE A.COD_FONTE = E.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI= E.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI= E.DAC_PROTOCOLO_SINI) 
							AND E.TIMESTAMP = 
							(SELECT MAX(F.TIMESTAMP) 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP F 
							WHERE E.COD_FONTE = F.COD_FONTE 
							AND E.NUM_PROTOCOLO_SINI= F.NUM_PROTOCOLO_SINI 
							AND E.DAC_PROTOCOLO_SINI= F.DAC_PROTOCOLO_SINI 
							AND F.COD_EVENTO = 2013) 
							ORDER BY A.COD_USUARIO
							, 
							A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.NUM_CARTA";

                return query;
            }
            JOIN_1.GetQueryEvent += GetQuery_JOIN_1;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-JOIN-DB-OPEN-1 */
        public void R0900_00_DECLARA_JOIN_DB_OPEN_1()
        {
            /*" -447- EXEC SQL OPEN JOIN-1 END-EXEC. */

            JOIN_1.Open();

        }

        [StopWatch]
        /*" R2900-00-INSERE-FASE-SINIST-DB-DECLARE-1 */
        public void R2900_00_INSERE_FASE_SINIST_DB_DECLARE_1()
        {
            /*" -1183- EXEC SQL DECLARE LEITURA_FASES CURSOR FOR SELECT COD_FASE, DATA_INIVIG_REFAEV, IND_ALTERACAO_FASE FROM SEGUROS.SI_REL_FASE_EVENTO WHERE COD_EVENTO = 1102 AND DATA_INIVIG_REFAEV <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIG_REFAEV >= :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */
            LEITURA_FASES = new SI0045B_LEITURA_FASES(true);
            string GetQuery_LEITURA_FASES()
            {
                var query = @$"SELECT COD_FASE
							, 
							DATA_INIVIG_REFAEV
							, 
							IND_ALTERACAO_FASE 
							FROM SEGUROS.SI_REL_FASE_EVENTO 
							WHERE COD_EVENTO = 1102 
							AND DATA_INIVIG_REFAEV <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DATA_TERVIG_REFAEV >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            LEITURA_FASES.GetQueryEvent += GetQuery_LEITURA_FASES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-JOIN-SECTION */
        private void R0910_00_LE_JOIN_SECTION()
        {
            /*" -461- MOVE '0091' TO WNR-EXEC-SQL. */
            _.Move("0091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -475- PERFORM R0910_00_LE_JOIN_DB_FETCH_1 */

            R0910_00_LE_JOIN_DB_FETCH_1();

            /*" -478- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -479- ADD 1 TO AC-L-JOIN */
                AREA_DE_WORK.AC_L_JOIN.Value = AREA_DE_WORK.AC_L_JOIN + 1;

                /*" -480- ELSE */
            }
            else
            {


                /*" -481- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -482- MOVE 'S' TO WFIM-JOIN */
                    _.Move("S", AREA_DE_WORK.WFIM_JOIN);

                    /*" -482- PERFORM R0910_00_LE_JOIN_DB_CLOSE_1 */

                    R0910_00_LE_JOIN_DB_CLOSE_1();

                    /*" -484- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -485- ELSE */
                }
                else
                {


                    /*" -486- DISPLAY 'PROBLEMAS NO FETCH JOIN ' */
                    _.Display($"PROBLEMAS NO FETCH JOIN ");

                    /*" -486- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-JOIN-DB-FETCH-1 */
        public void R0910_00_LE_JOIN_DB_FETCH_1()
        {
            /*" -475- EXEC SQL FETCH JOIN-1 INTO :SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, :SISINACO-NUM-OCORR-SINIACO, :SISINACO-COD-EVENTO, :SISINACO-DATA-MOVTO-SINIACO, :WHOST-DIFERENCA-DIAS, :SISINACO-COD-USUARIO, :HOST-NUM-CARTA, :GECARTA-SEQ-CARTA-REITERA, :GECARTA-NUM-CARTA-REITERA, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-COD-PRODUTO END-EXEC. */

            if (JOIN_1.Fetch())
            {
                _.Move(JOIN_1.SISINACO_COD_FONTE, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE);
                _.Move(JOIN_1.SISINACO_NUM_PROTOCOLO_SINI, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI);
                _.Move(JOIN_1.SISINACO_DAC_PROTOCOLO_SINI, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI);
                _.Move(JOIN_1.SISINACO_NUM_OCORR_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO);
                _.Move(JOIN_1.SISINACO_COD_EVENTO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO);
                _.Move(JOIN_1.SISINACO_DATA_MOVTO_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);
                _.Move(JOIN_1.WHOST_DIFERENCA_DIAS, WHOST_DIFERENCA_DIAS);
                _.Move(JOIN_1.SISINACO_COD_USUARIO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO);
                _.Move(JOIN_1.HOST_NUM_CARTA, HOST_NUM_CARTA);
                _.Move(JOIN_1.GECARTA_SEQ_CARTA_REITERA, GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA);
                _.Move(JOIN_1.GECARTA_NUM_CARTA_REITERA, GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA_REITERA);
                _.Move(JOIN_1.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(JOIN_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-JOIN-DB-CLOSE-1 */
        public void R0910_00_LE_JOIN_DB_CLOSE_1()
        {
            /*" -482- EXEC SQL CLOSE JOIN-1 END-EXEC */

            JOIN_1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -502- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -504- PERFORM R1500-00-VERIFICA-E-CANCELAR. */

            R1500_00_VERIFICA_E_CANCELAR_SECTION();

            /*" -505- IF HOST-E-PARA-CANCELAR = 'NAO' */

            if (HOST_E_PARA_CANCELAR == "NAO")
            {

                /*" -507- GO TO R1000-NOVA-LEITURA. */

                R1000_NOVA_LEITURA(); //GOTO
                return;
            }


            /*" -509- PERFORM R2000-00-PROCESSA-CANCELAMENTO. */

            R2000_00_PROCESSA_CANCELAMENTO_SECTION();

            /*" -509- PERFORM R4000-00-PROCESSA-IMPRESSAO. */

            R4000_00_PROCESSA_IMPRESSAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_NOVA_LEITURA */

            R1000_NOVA_LEITURA();

        }

        [StopWatch]
        /*" R1000-NOVA-LEITURA */
        private void R1000_NOVA_LEITURA(bool isPerform = false)
        {
            /*" -512- PERFORM R0910-00-LE-JOIN. */

            R0910_00_LE_JOIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-VERIFICA-E-CANCELAR-SECTION */
        private void R1500_00_VERIFICA_E_CANCELAR_SECTION()
        {
            /*" -522- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -524- MOVE SPACES TO HOST-E-PARA-CANCELAR. */
            _.Move("", HOST_E_PARA_CANCELAR);

            /*" -526- PERFORM R1501-00-SINISTRO-ENCERRADO. */

            R1501_00_SINISTRO_ENCERRADO_SECTION();

            /*" -531- IF HOST-E-PARA-CANCELAR EQUAL 'NAO' */

            if (HOST_E_PARA_CANCELAR == "NAO")
            {

                /*" -533- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -535- PERFORM R1502-00-QTD-REITERACAO. */

            R1502_00_QTD_REITERACAO_SECTION();

            /*" -540- IF HOST-E-PARA-CANCELAR EQUAL 'NAO' */

            if (HOST_E_PARA_CANCELAR == "NAO")
            {

                /*" -545- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -547- MOVE SPACES TO HOST-E-PARA-CANCELAR. */
            _.Move("", HOST_E_PARA_CANCELAR);

            /*" -556- PERFORM R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1 */

            R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1();

            /*" -559- IF SQLCODE = 0 OR -811 */

            if (DB.SQLCODE.In("0", "-811"))
            {

                /*" -560- DISPLAY ' ' */
                _.Display($" ");

                /*" -562- DISPLAY 'COD_OPERACAO IMPEDE CANCELAR   ' 'SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                $"COD_OPERACAO IMPEDE CANCELAR   SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -563- MOVE 'NAO' TO HOST-E-PARA-CANCELAR */
                _.Move("NAO", HOST_E_PARA_CANCELAR);

                /*" -565- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -566- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -567- MOVE 'SIM' TO HOST-E-PARA-CANCELAR */
                _.Move("SIM", HOST_E_PARA_CANCELAR);

                /*" -569- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -570- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -571- DISPLAY 'PROBLEMAS NO SELECT DO VALOR PAGO' */
                _.Display($"PROBLEMAS NO SELECT DO VALOR PAGO");

                /*" -572- DISPLAY ' ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($" {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -572- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-VERIFICA-E-CANCELAR-DB-SELECT-1 */
        public void R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1()
        {
            /*" -556- EXEC SQL SELECT NUM_APOL_SINISTRO INTO :SINISHIS-NUM-APOL-SINISTRO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1001,1002,1003,1004,1009, 1081,1082,1083,1084, 1181,1182,1183,1184) WITH UR END-EXEC. */

            var r1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1 = new R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1.Execute(r1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1501-00-SINISTRO-ENCERRADO-SECTION */
        private void R1501_00_SINISTRO_ENCERRADO_SECTION()
        {
            /*" -585- MOVE '1501' TO WNR-EXEC-SQL. */
            _.Move("1501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -601- PERFORM R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1 */

            R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1();

            /*" -604- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -605- DISPLAY ' ' */
                _.Display($" ");

                /*" -607- DISPLAY 'R1500 PROBLEMAS NO SELECT COD_FASE     ' ' ' SINISMES-NUM-APOL-SINISTRO */

                $"R1500 PROBLEMAS NO SELECT COD_FASE      {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -608- MOVE ZEROS TO WHOST-COD-FASE */
                _.Move(0, WHOST_COD_FASE);

                /*" -610- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -611- IF WHOST-COD-FASE EQUAL 4 */

            if (WHOST_COD_FASE == 4)
            {

                /*" -612- MOVE 'NAO' TO HOST-E-PARA-CANCELAR */
                _.Move("NAO", HOST_E_PARA_CANCELAR);

                /*" -613- ELSE */
            }
            else
            {


                /*" -613- MOVE 'SIM' TO HOST-E-PARA-CANCELAR. */
                _.Move("SIM", HOST_E_PARA_CANCELAR);
            }


        }

        [StopWatch]
        /*" R1501-00-SINISTRO-ENCERRADO-DB-SELECT-1 */
        public void R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1()
        {
            /*" -601- EXEC SQL SELECT COD_FASE INTO :WHOST-COD-FASE FROM SEGUROS.SI_SINISTRO_FASE WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI AND NUM_OCORR_SINIACO = (SELECT MAX(NUM_OCORR_SINIACO) FROM SEGUROS.SI_SINISTRO_FASE E WHERE E.COD_FONTE = :SISINACO-COD-FONTE AND E.NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND E.DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI) WITH UR END-EXEC. */

            var r1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1 = new R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1.Execute(r1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_FASE, WHOST_COD_FASE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1501_99_SAIDA*/

        [StopWatch]
        /*" R1502-00-QTD-REITERACAO-SECTION */
        private void R1502_00_QTD_REITERACAO_SECTION()
        {
            /*" -623- MOVE '1502' TO WNR-EXEC-SQL. */
            _.Move("1502", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -624- MOVE 1 TO WHOST-REITERACOES */
            _.Move(1, WHOST_REITERACOES);

            /*" -627- MOVE GECARTA-NUM-CARTA-REITERA TO WHOST-CARTA-REITERA. */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA_REITERA, WHOST_CARTA_REITERA);

            /*" -628- IF WHOST-CARTA-REITERA EQUAL ZERO */

            if (WHOST_CARTA_REITERA == 00)
            {

                /*" -629- MOVE 'NAO' TO HOST-E-PARA-CANCELAR */
                _.Move("NAO", HOST_E_PARA_CANCELAR);

                /*" -629- GO TO R1502-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1502_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1502_00_LEITURA */

            R1502_00_LEITURA();

        }

        [StopWatch]
        /*" R1502-00-LEITURA */
        private void R1502_00_LEITURA(bool isPerform = false)
        {
            /*" -638- MOVE WHOST-CARTA-REITERA TO WHOST-NUM-CARTA-REITERA */
            _.Move(WHOST_CARTA_REITERA, WHOST_NUM_CARTA_REITERA);

            /*" -646- PERFORM R1502_00_LEITURA_DB_SELECT_1 */

            R1502_00_LEITURA_DB_SELECT_1();

            /*" -649- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -650- DISPLAY ' ' */
                _.Display($" ");

                /*" -652- DISPLAY 'R1502 PROBLEMAS NO SELECT GE_CARTA     ' ' ' WHOST-NUM-CARTA-REITERA */

                $"R1502 PROBLEMAS NO SELECT GE_CARTA      {WHOST_NUM_CARTA_REITERA}"
                .Display();

                /*" -654- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -655- IF WHOST-CARTA-REITERA NOT EQUAL ZERO */

            if (WHOST_CARTA_REITERA != 00)
            {

                /*" -656- ADD 1 TO WHOST-REITERACOES */
                WHOST_REITERACOES.Value = WHOST_REITERACOES + 1;

                /*" -658- GO TO R1502-00-LEITURA. */
                new Task(() => R1502_00_LEITURA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -659- IF WHOST-REITERACOES < 3 */

            if (WHOST_REITERACOES < 3)
            {

                /*" -660- MOVE 'NAO' TO HOST-E-PARA-CANCELAR */
                _.Move("NAO", HOST_E_PARA_CANCELAR);

                /*" -662- GO TO R1502-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1502_99_SAIDA*/ //GOTO
                return;
            }


            /*" -663- IF WHOST-REITERACOES > 3 */

            if (WHOST_REITERACOES > 3)
            {

                /*" -664- MOVE 'SIM' TO HOST-E-PARA-CANCELAR */
                _.Move("SIM", HOST_E_PARA_CANCELAR);

                /*" -666- GO TO R1502-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1502_99_SAIDA*/ //GOTO
                return;
            }


            /*" -668- IF WHOST-REITERACOES = 3 AND WHOST-DIFERENCA-DIAS NOT < 30 */

            if (WHOST_REITERACOES == 3 && WHOST_DIFERENCA_DIAS! < 30)
            {

                /*" -669- MOVE 'SIM' TO HOST-E-PARA-CANCELAR */
                _.Move("SIM", HOST_E_PARA_CANCELAR);

                /*" -670- ELSE */
            }
            else
            {


                /*" -670- MOVE 'NAO' TO HOST-E-PARA-CANCELAR. */
                _.Move("NAO", HOST_E_PARA_CANCELAR);
            }


        }

        [StopWatch]
        /*" R1502-00-LEITURA-DB-SELECT-1 */
        public void R1502_00_LEITURA_DB_SELECT_1()
        {
            /*" -646- EXEC SQL SELECT VALUE(NUM_CARTA_REITERA, 0) INTO :WHOST-CARTA-REITERA FROM SEGUROS.GE_CARTA WHERE NUM_CARTA = :WHOST-NUM-CARTA-REITERA AND STA_ENVIO_CARTA = 'S' WITH UR END-EXEC. */

            var r1502_00_LEITURA_DB_SELECT_1_Query1 = new R1502_00_LEITURA_DB_SELECT_1_Query1()
            {
                WHOST_NUM_CARTA_REITERA = WHOST_NUM_CARTA_REITERA.ToString(),
            };

            var executed_1 = R1502_00_LEITURA_DB_SELECT_1_Query1.Execute(r1502_00_LEITURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CARTA_REITERA, WHOST_CARTA_REITERA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1502_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-CANCELAMENTO-SECTION */
        private void R2000_00_PROCESSA_CANCELAMENTO_SECTION()
        {
            /*" -680- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -682- PERFORM R2100-00-ACESSA-SINI-MESTRE. */

            R2100_00_ACESSA_SINI_MESTRE_SECTION();

            /*" -684- PERFORM R2200-00-ACESSA-SINI-HISTOR. */

            R2200_00_ACESSA_SINI_HISTOR_SECTION();

            /*" -686- PERFORM R2300-00-OBTEM-VAL-PENDENTE. */

            R2300_00_OBTEM_VAL_PENDENTE_SECTION();

            /*" -688- PERFORM R2400-00-CANCELA-SINISTRO. */

            R2400_00_CANCELA_SINISTRO_SECTION();

            /*" -690- PERFORM R2600-00-AJUSTE-DA-RESERVA. */

            R2600_00_AJUSTE_DA_RESERVA_SECTION();

            /*" -692- PERFORM R2700-00-ACESSA-SI-MOV-SINI. */

            R2700_00_ACESSA_SI_MOV_SINI_SECTION();

            /*" -694- IF WESTA-SIMOVIMENTO-SINI = 'SIM' */

            if (AREA_DE_WORK.WESTA_SIMOVIMENTO_SINI == "SIM")
            {

                /*" -696- PERFORM R2800-00-GERA-SINI-ACOMP */

                R2800_00_GERA_SINI_ACOMP_SECTION();

                /*" -698- PERFORM R2900-00-INSERE-FASE-SINIST */

                R2900_00_INSERE_FASE_SINIST_SECTION();

                /*" -699- PERFORM R3000-00-INSERE-HIST-ACOMP */

                R3000_00_INSERE_HIST_ACOMP_SECTION();

                /*" -701- END-IF. */
            }


            /*" -703- PERFORM R3100-00-ATUALI-SINI-MESTRE. */

            R3100_00_ATUALI_SINI_MESTRE_SECTION();

            /*" -705- PERFORM R3200-00-ATUALI-SINI-HISTOR. */

            R3200_00_ATUALI_SINI_HISTOR_SECTION();

            /*" -707- PERFORM R3300-00-ATUALI-SINI-HABIT1. */

            R3300_00_ATUALI_SINI_HABIT1_SECTION();

            /*" -709- PERFORM R3400-00-ACESSA-SINI-CONTRO. */

            R3400_00_ACESSA_SINI_CONTRO_SECTION();

            /*" -711- PERFORM R3500-00-INSERE-SINI-ACOMPA. */

            R3500_00_INSERE_SINI_ACOMPA_SECTION();

            /*" -713- PERFORM R3600-00-ATUALI-SINI-CONTRO. */

            R3600_00_ATUALI_SINI_CONTRO_SECTION();

            /*" -713- PERFORM R3700-00-INSERE-HIST-ACOMP. */

            R3700_00_INSERE_HIST_ACOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-ACESSA-SINI-MESTRE-SECTION */
        private void R2100_00_ACESSA_SINI_MESTRE_SECTION()
        {
            /*" -723- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -767- PERFORM R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1 */

            R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1();

            /*" -770- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -771- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_MESTRE' */
                _.Display($"PROBLEMAS NO SELECT SINISTRO_MESTRE");

                /*" -772- DISPLAY ' ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($" {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-ACESSA-SINI-MESTRE-DB-SELECT-1 */
        public void R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1()
        {
            /*" -767- EXEC SQL SELECT TIPO_REGISTRO, COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOL_SINISTRO, NUM_APOLICE, NUM_ENDOSSO, OCORR_HISTORICO, DATA_COMUNICADO, DATA_OCORRENCIA, DATA_TECNICA, COD_CAUSA, NUM_IRB, NUM_AVISO_IRB, NUM_MOV_SINI_ATU, NUM_MOV_SINI_ANT, DATA_ULT_MOVIMENTO, SIT_REGISTRO, VALUE(RAMO,0), VALUE(COD_PRODUTO,0) INTO :SINISMES-TIPO-REGISTRO, :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI, :SINISMES-DAC-PROTOCOLO-SINI, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-NUM-ENDOSSO, :SINISMES-OCORR-HISTORICO, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-TECNICA, :SINISMES-COD-CAUSA, :SINISMES-NUM-IRB, :SINISMES-NUM-AVISO-IRB, :SINISMES-NUM-MOV-SINI-ATU, :SINISMES-NUM-MOV-SINI-ANT, :SINISMES-DATA-ULT-MOVIMENTO, :SINISMES-SIT-REGISTRO, :SINISMES-RAMO, :SINISMES-COD-PRODUTO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1 = new R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1.Execute(r2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(executed_1.SINISMES_DAC_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_PROTOCOLO_SINI);
                _.Move(executed_1.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(executed_1.SINISMES_NUM_ENDOSSO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO);
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
                _.Move(executed_1.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(executed_1.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(executed_1.SINISMES_DATA_TECNICA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA);
                _.Move(executed_1.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(executed_1.SINISMES_NUM_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);
                _.Move(executed_1.SINISMES_NUM_AVISO_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_AVISO_IRB);
                _.Move(executed_1.SINISMES_NUM_MOV_SINI_ATU, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ATU);
                _.Move(executed_1.SINISMES_NUM_MOV_SINI_ANT, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_MOV_SINI_ANT);
                _.Move(executed_1.SINISMES_DATA_ULT_MOVIMENTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_ULT_MOVIMENTO);
                _.Move(executed_1.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(executed_1.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-ACESSA-SINI-HISTOR-SECTION */
        private void R2200_00_ACESSA_SINI_HISTOR_SECTION()
        {
            /*" -782- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -837- PERFORM R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1 */

            R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1();

            /*" -840- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -841- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_HISTORICO' */
                _.Display($"PROBLEMAS NO SELECT SINISTRO_HISTORICO");

                /*" -842- DISPLAY ' ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($" {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -842- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-ACESSA-SINI-HISTOR-DB-SELECT-1 */
        public void R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1()
        {
            /*" -837- EXEC SQL SELECT COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, NUM_APOLICE, COD_PRODUTO, VALUE(NOM_PROGRAMA, ' ' ), MONTH(DATA_MOVIMENTO) INTO :SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-HORA-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, :SINISHIS-NOM-PROGRAMA, :HOST-MES-OPERACAO-AVISO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 WITH UR END-EXEC. */

            var r2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1 = new R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1.Execute(r2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_EMPRESA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA);
                _.Move(executed_1.SINISHIS_TIPO_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.SINISHIS_HORA_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO);
                _.Move(executed_1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(executed_1.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(executed_1.SINISHIS_DATA_NEGOCIADA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);
                _.Move(executed_1.SINISHIS_FONTE_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);
                _.Move(executed_1.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(executed_1.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(executed_1.SINISHIS_ORDEM_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);
                _.Move(executed_1.SINISHIS_NUM_RECIBO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);
                _.Move(executed_1.SINISHIS_NUM_MOV_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO);
                _.Move(executed_1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(executed_1.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(executed_1.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(executed_1.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(executed_1.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(executed_1.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
                _.Move(executed_1.HOST_MES_OPERACAO_AVISO, HOST_MES_OPERACAO_AVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-OBTEM-VAL-PENDENTE-SECTION */
        private void R2300_00_OBTEM_VAL_PENDENTE_SECTION()
        {
            /*" -854- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -856- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -858- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -860- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -861- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -863- DISPLAY 'PROBLEMA CALL SI1001S ' ' ' SINISMES-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI1001S  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -864- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -865- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -866- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -867- ELSE */
            }
            else
            {


                /*" -869- MOVE SI1001S-VALOR-CALCULADO TO HOST-VALOR-PENDENTE. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VALOR_PENDENTE);
            }


            /*" -870- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WDATA-MES-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.WDATA_SQL.WDATA_MES_SQL);

            /*" -871- IF HOST-VALOR-PENDENTE < 0 */

            if (HOST_VALOR_PENDENTE < 0)
            {

                /*" -873- IF HOST-MES-OPERACAO-AVISO = WDATA-MES-SQL */

                if (HOST_MES_OPERACAO_AVISO == AREA_DE_WORK.WDATA_SQL.WDATA_MES_SQL)
                {

                    /*" -874- MOVE 102 TO SINISHIS-COD-OPERACAO */
                    _.Move(102, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                    /*" -876- ELSE */
                }
                else
                {


                    /*" -877- MOVE 112 TO SINISHIS-COD-OPERACAO */
                    _.Move(112, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                    /*" -879- END-IF */
                }


                /*" -880- MOVE 'SI0045B' TO SINISHIS-COD-USUARIO */
                _.Move("SI0045B", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);

                /*" -882- MOVE '0' TO SINISHIS-SIT-REGISTRO */
                _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                /*" -886- COMPUTE SINISMES-OCORR-HISTORICO = SINISMES-OCORR-HISTORICO + 1 */
                SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

                /*" -888- MOVE SINISMES-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

                /*" -891- COMPUTE SINISHIS-VAL-OPERACAO = HOST-VALOR-PENDENTE * -1 */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = HOST_VALOR_PENDENTE * -1;

                /*" -891- PERFORM R2500-00-INSERE-SINI-HISTOR. */

                R2500_00_INSERE_SINI_HISTOR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-CANCELA-SINISTRO-SECTION */
        private void R2400_00_CANCELA_SINISTRO_SECTION()
        {
            /*" -901- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -902- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WDATA-MES-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.WDATA_SQL.WDATA_MES_SQL);

            /*" -904- IF HOST-MES-OPERACAO-AVISO = WDATA-MES-SQL */

            if (HOST_MES_OPERACAO_AVISO == AREA_DE_WORK.WDATA_SQL.WDATA_MES_SQL)
            {

                /*" -905- MOVE 107 TO SINISHIS-COD-OPERACAO */
                _.Move(107, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -907- ELSE */
            }
            else
            {


                /*" -909- MOVE 117 TO SINISHIS-COD-OPERACAO. */
                _.Move(117, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
            }


            /*" -910- MOVE 'SI0045B' TO SINISHIS-COD-USUARIO. */
            _.Move("SI0045B", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);

            /*" -912- MOVE '0' TO SINISHIS-SIT-REGISTRO. */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -913- IF HOST-VALOR-PENDENTE > 0 */

            if (HOST_VALOR_PENDENTE > 0)
            {

                /*" -914- MOVE HOST-VALOR-PENDENTE TO SINISHIS-VAL-OPERACAO */
                _.Move(HOST_VALOR_PENDENTE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                /*" -915- ELSE */
            }
            else
            {


                /*" -917- MOVE ZEROS TO SINISHIS-VAL-OPERACAO. */
                _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


            /*" -920- COMPUTE SINISMES-OCORR-HISTORICO = SINISMES-OCORR-HISTORICO + 1. */
            SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

            /*" -921- MOVE SINISMES-OCORR-HISTORICO TO HOST-OCORR-HIST-CANCELAMENTO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, HOST_OCORR_HIST_CANCELAMENTO);

            /*" -923- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERAC-CANCELAMENTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERAC_CANCELAMENTO);

            /*" -925- MOVE SINISMES-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -925- PERFORM R2500-00-INSERE-SINI-HISTOR. */

            R2500_00_INSERE_SINI_HISTOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERE-SINI-HISTOR-SECTION */
        private void R2500_00_INSERE_SINI_HISTOR_SECTION()
        {
            /*" -935- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -936- MOVE SINISMES-TIPO-REGISTRO TO SINISHIS-TIPO-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);

            /*" -938- MOVE SINISMES-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -940- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -941- ACCEPT WTIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME);

            /*" -942- MOVE WTIME-HH TO WTIME-HH-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_HH, AREA_DE_WORK.WTIME_AUX.WTIME_HH_AUX);

            /*" -943- MOVE WTIME-MM TO WTIME-MM-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_MM, AREA_DE_WORK.WTIME_AUX.WTIME_MM_AUX);

            /*" -944- MOVE WTIME-SS TO WTIME-SS-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_SS, AREA_DE_WORK.WTIME_AUX.WTIME_SS_AUX);

            /*" -945- MOVE '.' TO WTIME-PONTO01 WTIME-PONTO02. */
            _.Move(".", AREA_DE_WORK.WTIME_AUX.WTIME_PONTO01, AREA_DE_WORK.WTIME_AUX.WTIME_PONTO02);

            /*" -947- MOVE WTIME-AUX TO SINISHIS-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.WTIME_AUX, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO);

            /*" -948- MOVE SPACES TO SINISHIS-NOME-FAVORECIDO. */
            _.Move("", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -949- MOVE '9999-12-31' TO SINISHIS-DATA-LIM-CORRECAO. */
            _.Move("9999-12-31", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);

            /*" -950- MOVE '9999-12-31' TO SINISHIS-DATA-NEGOCIADA. */
            _.Move("9999-12-31", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);

            /*" -951- MOVE ZEROS TO SINISHIS-TIPO-FAVORECIDO. */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);

            /*" -952- MOVE '0' TO SINISHIS-SIT-CONTABIL. */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

            /*" -953- MOVE SINISMES-NUM-APOLICE TO SINISHIS-NUM-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);

            /*" -954- MOVE SINISMES-COD-PRODUTO TO SINISHIS-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);

            /*" -956- MOVE 'SI0045B' TO SINISHIS-NOM-PROGRAMA. */
            _.Move("SI0045B", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);

            /*" -1008- PERFORM R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1 */

            R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1();

            /*" -1011- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1012- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_HISTORICO' */
                _.Display($"PROBLEMAS NO INSERT SINISTRO_HISTORICO");

                /*" -1016- DISPLAY ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' SINISHIS-DATA-MOVIMENTO */

                $" {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}"
                .Display();

                /*" -1018- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1018- ADD 1 TO AC-GRAVA-SINISHIS. */
            AREA_DE_WORK.AC_GRAVA_SINISHIS.Value = AREA_DE_WORK.AC_GRAVA_SINISHIS + 1;

        }

        [StopWatch]
        /*" R2500-00-INSERE-SINI-HISTOR-DB-INSERT-1 */
        public void R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1()
        {
            /*" -1008- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-HORA-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, :SINISHIS-NOM-PROGRAMA) END-EXEC. */

            var r2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1 = new R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1()
            {
                SINISHIS_COD_EMPRESA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA.ToString(),
                SINISHIS_TIPO_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_HORA_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO.ToString(),
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
                SINISHIS_NOM_PROGRAMA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.ToString(),
            };

            R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1.Execute(r2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-AJUSTE-DA-RESERVA-SECTION */
        private void R2600_00_AJUSTE_DA_RESERVA_SECTION()
        {
            /*" -1031- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1033- INITIALIZE LINK-PARAMETRO. */
            _.Initialize(
                LINK_PARAMETRO
            );

            /*" -1034- MOVE SINISMES-NUM-APOL-SINISTRO TO LINK-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LINK_PARAMETRO.LINK_NUM_APOL_SINISTRO);

            /*" -1036- MOVE ZEROS TO LINK-VAL-RESERVA-DESEJADA */
            _.Move(0, LINK_PARAMETRO.LINK_VAL_RESERVA_DESEJADA);

            /*" -1038- CALL 'SI0502S' USING LINK-PARAMETRO */
            _.Call("SI0502S", LINK_PARAMETRO);

            /*" -1039- IF LINK-MSG-ERRO NOT = SPACES */

            if (!LINK_PARAMETRO.LINK_MSG_ERRO.IsEmpty())
            {

                /*" -1041- DISPLAY 'PROBLEMA CALL SI0502S ' ' ' SINISMES-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI0502S  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -1042- DISPLAY 'SQLCODE = ' LINK-SQLCODE */
                _.Display($"SQLCODE = {LINK_PARAMETRO.LINK_SQLCODE}");

                /*" -1043- DISPLAY LINK-MSG-ERRO */
                _.Display(LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -1043- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-ACESSA-SI-MOV-SINI-SECTION */
        private void R2700_00_ACESSA_SI_MOV_SINI_SECTION()
        {
            /*" -1053- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1055- MOVE SPACES TO WESTA-SIMOVIMENTO-SINI. */
            _.Move("", AREA_DE_WORK.WESTA_SIMOVIMENTO_SINI);

            /*" -1081- PERFORM R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1 */

            R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1();

            /*" -1084- IF SQLCODE NOT = ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1085- DISPLAY 'PROBLEMAS NO SELECT SI_MOVIMENTO_SINI' */
                _.Display($"PROBLEMAS NO SELECT SI_MOVIMENTO_SINI");

                /*" -1088- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -1090- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1091- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1092- MOVE 'SIM' TO WESTA-SIMOVIMENTO-SINI */
                _.Move("SIM", AREA_DE_WORK.WESTA_SIMOVIMENTO_SINI);

                /*" -1093- ADD 1 TO AC-ACHOU-SIMOVSIN */
                AREA_DE_WORK.AC_ACHOU_SIMOVSIN.Value = AREA_DE_WORK.AC_ACHOU_SIMOVSIN + 1;

                /*" -1094- ELSE */
            }
            else
            {


                /*" -1095- MOVE 'NAO' TO WESTA-SIMOVIMENTO-SINI */
                _.Move("NAO", AREA_DE_WORK.WESTA_SIMOVIMENTO_SINI);

                /*" -1095- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-ACESSA-SI-MOV-SINI-DB-SELECT-1 */
        public void R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1()
        {
            /*" -1081- EXEC SQL SELECT COD_ESTIPULANTE, COD_PRODUTO, NUM_CONTR_ESTIP, NOME_SEGURADO, VALUE(COD_ASHAB,0), NATUREZA_SINISTRO, VALUE(RAMO_EMISSOR,0), VALUE(COD_CAUSA,0), DATA_COMUNICADO, COD_GIAFI INTO :SIMOVSIN-COD-ESTIPULANTE, :SIMOVSIN-COD-PRODUTO, :SIMOVSIN-NUM-CONTR-ESTIP, :SIMOVSIN-NOME-SEGURADO, :SIMOVSIN-COD-ASHAB, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-RAMO-EMISSOR, :SIMOVSIN-COD-CAUSA, :SIMOVSIN-DATA-COMUNICADO, :SIMOVSIN-COD-GIAFI FROM SEGUROS.SI_MOVIMENTO_SINI WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI WITH UR END-EXEC. */

            var r2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1 = new R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1.Execute(r2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOVSIN_COD_ESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE);
                _.Move(executed_1.SIMOVSIN_COD_PRODUTO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_PRODUTO);
                _.Move(executed_1.SIMOVSIN_NUM_CONTR_ESTIP, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NUM_CONTR_ESTIP);
                _.Move(executed_1.SIMOVSIN_NOME_SEGURADO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO);
                _.Move(executed_1.SIMOVSIN_COD_ASHAB, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ASHAB);
                _.Move(executed_1.SIMOVSIN_NATUREZA_SINISTRO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO);
                _.Move(executed_1.SIMOVSIN_RAMO_EMISSOR, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_RAMO_EMISSOR);
                _.Move(executed_1.SIMOVSIN_COD_CAUSA, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_CAUSA);
                _.Move(executed_1.SIMOVSIN_DATA_COMUNICADO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_DATA_COMUNICADO);
                _.Move(executed_1.SIMOVSIN_COD_GIAFI, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_GIAFI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-GERA-SINI-ACOMP-SECTION */
        private void R2800_00_GERA_SINI_ACOMP_SECTION()
        {
            /*" -1105- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1108- INITIALIZE PROTOCOLO-RECEBIDO PROTOCOLO-ENVIO */
            _.Initialize(
                LBWCT001.PROTOCOLO_RECEBIDO
                , LBWCT002.PROTOCOLO_ENVIO
            );

            /*" -1109- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -1110- MOVE 'SI0045B' TO IN-USUARIO */
            _.Move("SI0045B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -1112- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -1113- PERFORM R2810-00-MAX-SISINACO */

            R2810_00_MAX_SISINACO_SECTION();

            /*" -1115- ADD 1 TO SISINACO-NUM-OCORR-SINIACO */
            SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO.Value = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO + 1;

            /*" -1117- MOVE 1102 TO SISINACO-COD-EVENTO */
            _.Move(1102, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO);

            /*" -1119- MOVE 'GERANDO EVENTO CANCELAMENTO P/ FALTA DOC' TO SISINACO-DESCR-COMPLEMENTAR */
            _.Move("GERANDO EVENTO CANCELAMENTO P/ FALTA DOC", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DESCR_COMPLEMENTAR);

            /*" -1121- MOVE SISTEMAS-DATA-MOV-ABERTO TO SISINACO-DATA-MOVTO-SINIACO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

            /*" -1125- CALL 'PTACOMOS' USING PROTOCOLO-RECEBIDO DCLSI-SINISTRO-ACOMP PROTOCOLO-ENVIO */
            _.Call("PTACOMOS", LBWCT001.PROTOCOLO_RECEBIDO, SISINACO.DCLSI_SINISTRO_ACOMP, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1126- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -1133- DISPLAY '*** PROBLEMAS NA SUBROTINA PTACOMOS ***' ' ' OUT-COD-RETORNO ' ' OUT-COD-RETORNO-SQL ' ' OUT-MENSAGEM ' ' HOST-NUM-CARTA ' ' SISINACO-NUM-OCORR-SINIACO ' ' SISINACO-COD-EVENTO */

                $"*** PROBLEMAS NA SUBROTINA PTACOMOS *** {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO} {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL} {LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM} {HOST_NUM_CARTA} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO}"
                .Display();

                /*" -1135- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1135- ADD 1 TO AC-GRAVA-SISINACO. */
            AREA_DE_WORK.AC_GRAVA_SISINACO.Value = AREA_DE_WORK.AC_GRAVA_SISINACO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2810-00-MAX-SISINACO-SECTION */
        private void R2810_00_MAX_SISINACO_SECTION()
        {
            /*" -1145- MOVE '2810' TO WNR-EXEC-SQL. */
            _.Move("2810", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1153- PERFORM R2810_00_MAX_SISINACO_DB_SELECT_1 */

            R2810_00_MAX_SISINACO_DB_SELECT_1();

            /*" -1156- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1160- DISPLAY 'PROBLEMAS NO MAX SI_SINISTRO_ACOMP' ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                $"PROBLEMAS NO MAX SI_SINISTRO_ACOMP {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -1160- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2810-00-MAX-SISINACO-DB-SELECT-1 */
        public void R2810_00_MAX_SISINACO_DB_SELECT_1()
        {
            /*" -1153- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_SINIACO), 0) INTO :SISINACO-NUM-OCORR-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI WITH UR END-EXEC. */

            var r2810_00_MAX_SISINACO_DB_SELECT_1_Query1 = new R2810_00_MAX_SISINACO_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R2810_00_MAX_SISINACO_DB_SELECT_1_Query1.Execute(r2810_00_MAX_SISINACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINACO_NUM_OCORR_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2810_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERE-FASE-SINIST-SECTION */
        private void R2900_00_INSERE_FASE_SINIST_SECTION()
        {
            /*" -1170- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1174- INITIALIZE PROTOCOLO-RECEBIDO DCLSI-SINISTRO-FASE PROTOCOLO-ENVIO */
            _.Initialize(
                LBWCT001.PROTOCOLO_RECEBIDO
                , SISINFAS.DCLSI_SINISTRO_FASE
                , LBWCT002.PROTOCOLO_ENVIO
            );

            /*" -1183- PERFORM R2900_00_INSERE_FASE_SINIST_DB_DECLARE_1 */

            R2900_00_INSERE_FASE_SINIST_DB_DECLARE_1();

            /*" -1185- PERFORM R2900_00_INSERE_FASE_SINIST_DB_OPEN_1 */

            R2900_00_INSERE_FASE_SINIST_DB_OPEN_1();

            /*" -1188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1190- DISPLAY 'PROBLEMAS DECLARE SI_REL_FASE_EVENTO' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"PROBLEMAS DECLARE SI_REL_FASE_EVENTO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -1190- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2900_10_LER_OUTRA_FASE */

            R2900_10_LER_OUTRA_FASE();

        }

        [StopWatch]
        /*" R2900-00-INSERE-FASE-SINIST-DB-OPEN-1 */
        public void R2900_00_INSERE_FASE_SINIST_DB_OPEN_1()
        {
            /*" -1185- EXEC SQL OPEN LEITURA_FASES END-EXEC. */

            LEITURA_FASES.Open();

        }

        [StopWatch]
        /*" R2900-10-LER-OUTRA-FASE */
        private void R2900_10_LER_OUTRA_FASE(bool isPerform = false)
        {
            /*" -1197- PERFORM R2900_10_LER_OUTRA_FASE_DB_FETCH_1 */

            R2900_10_LER_OUTRA_FASE_DB_FETCH_1();

            /*" -1200- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1200- PERFORM R2900_10_LER_OUTRA_FASE_DB_CLOSE_1 */

                R2900_10_LER_OUTRA_FASE_DB_CLOSE_1();

                /*" -1202- GO TO R2900-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;

                /*" -1203- ELSE */
            }
            else
            {


                /*" -1204- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -1206- DISPLAY 'PROBLEMAS DECLARE SI_REL_FASE_EVENTO' ' ' SISTEMAS-DATA-MOV-ABERTO */

                    $"PROBLEMAS DECLARE SI_REL_FASE_EVENTO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                    .Display();

                    /*" -1210- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1212- IF SIREFAEV-IND-ALTERACAO-FASE EQUAL '1' */

            if (SIREFAEV.DCLSI_REL_FASE_EVENTO.SIREFAEV_IND_ALTERACAO_FASE == "1")
            {

                /*" -1213- MOVE 1 TO IN-OPERACAO */
                _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

                /*" -1214- MOVE '9999-12-31' TO SISINFAS-DATA-FECHA-SIFA */
                _.Move("9999-12-31", SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA);

                /*" -1215- ELSE */
            }
            else
            {


                /*" -1216- MOVE 2 TO IN-OPERACAO */
                _.Move(2, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

                /*" -1219- MOVE SISINACO-DATA-MOVTO-SINIACO TO SISINFAS-DATA-FECHA-SIFA. */
                _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA);
            }


            /*" -1220- MOVE SISINACO-COD-FONTE TO SISINFAS-COD-FONTE */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE);

            /*" -1222- MOVE SISINACO-NUM-PROTOCOLO-SINI TO SISINFAS-NUM-PROTOCOLO-SINI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI);

            /*" -1224- MOVE SISINACO-DAC-PROTOCOLO-SINI TO SISINFAS-DAC-PROTOCOLO-SINI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI);

            /*" -1225- MOVE SIREFAEV-COD-FASE TO SISINFAS-COD-FASE */
            _.Move(SIREFAEV.DCLSI_REL_FASE_EVENTO.SIREFAEV_COD_FASE, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE);

            /*" -1226- MOVE 1102 TO SISINFAS-COD-EVENTO */
            _.Move(1102, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO);

            /*" -1228- MOVE SISINACO-NUM-OCORR-SINIACO TO SISINFAS-NUM-OCORR-SINIACO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO);

            /*" -1230- MOVE SIREFAEV-DATA-INIVIG-REFAEV TO SISINFAS-DATA-INIVIG-REFAEV */
            _.Move(SIREFAEV.DCLSI_REL_FASE_EVENTO.SIREFAEV_DATA_INIVIG_REFAEV, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV);

            /*" -1233- MOVE SISINACO-DATA-MOVTO-SINIACO TO SISINFAS-DATA-ABERTURA-SIFA */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA);

            /*" -1237- CALL 'PTFASESS' USING PROTOCOLO-RECEBIDO DCLSI-SINISTRO-FASE PROTOCOLO-ENVIO */
            _.Call("PTFASESS", LBWCT001.PROTOCOLO_RECEBIDO, SISINFAS.DCLSI_SINISTRO_FASE, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1238- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -1252- DISPLAY '*** PROBLEMAS NA SUBROTINA PTFASESS ***' ' ' OUT-COD-RETORNO ' ' OUT-COD-RETORNO-SQL ' ' OUT-MENSAGEM ' ' SISINFAS-COD-FONTE ' ' SISINFAS-NUM-PROTOCOLO-SINI ' ' SISINFAS-DAC-PROTOCOLO-SINI ' ' SISINFAS-COD-FASE ' ' SISINFAS-COD-EVENTO ' ' SISINFAS-NUM-OCORR-SINIACO ' ' SISINFAS-DATA-INIVIG-REFAEV ' ' SISINFAS-DATA-ABERTURA-SIFA ' ' SISINFAS-DATA-FECHA-SIFA ' ' IN-OPERACAO */

                $"*** PROBLEMAS NA SUBROTINA PTFASESS *** {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO} {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL} {LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA} {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA} {LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO}"
                .Display();

                /*" -1254- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1256- ADD 1 TO AC-GRAVA-SININFAS. */
            AREA_DE_WORK.AC_GRAVA_SININFAS.Value = AREA_DE_WORK.AC_GRAVA_SININFAS + 1;

            /*" -1256- GO TO R2900-10-LER-OUTRA-FASE. */
            new Task(() => R2900_10_LER_OUTRA_FASE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2900-10-LER-OUTRA-FASE-DB-FETCH-1 */
        public void R2900_10_LER_OUTRA_FASE_DB_FETCH_1()
        {
            /*" -1197- EXEC SQL FETCH LEITURA_FASES INTO :SIREFAEV-COD-FASE, :SIREFAEV-DATA-INIVIG-REFAEV, :SIREFAEV-IND-ALTERACAO-FASE END-EXEC. */

            if (LEITURA_FASES.Fetch())
            {
                _.Move(LEITURA_FASES.SIREFAEV_COD_FASE, SIREFAEV.DCLSI_REL_FASE_EVENTO.SIREFAEV_COD_FASE);
                _.Move(LEITURA_FASES.SIREFAEV_DATA_INIVIG_REFAEV, SIREFAEV.DCLSI_REL_FASE_EVENTO.SIREFAEV_DATA_INIVIG_REFAEV);
                _.Move(LEITURA_FASES.SIREFAEV_IND_ALTERACAO_FASE, SIREFAEV.DCLSI_REL_FASE_EVENTO.SIREFAEV_IND_ALTERACAO_FASE);
            }

        }

        [StopWatch]
        /*" R2900-10-LER-OUTRA-FASE-DB-CLOSE-1 */
        public void R2900_10_LER_OUTRA_FASE_DB_CLOSE_1()
        {
            /*" -1200- EXEC SQL CLOSE LEITURA_FASES END-EXEC */

            LEITURA_FASES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERE-HIST-ACOMP-SECTION */
        private void R3000_00_INSERE_HIST_ACOMP_SECTION()
        {
            /*" -1266- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1268- INITIALIZE DCLSI-HIST-ACOMPANHA. */
            _.Initialize(
                SIHISACO.DCLSI_HIST_ACOMPANHA
            );

            /*" -1269- MOVE SISINACO-COD-FONTE TO SIHISACO-COD-FONTE */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_COD_FONTE);

            /*" -1271- MOVE SISINACO-NUM-PROTOCOLO-SINI TO SIHISACO-NUM-PROTOCOLO-SINI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_PROTOCOLO_SINI);

            /*" -1273- MOVE SISINACO-DAC-PROTOCOLO-SINI TO SIHISACO-DAC-PROTOCOLO-SINI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_DAC_PROTOCOLO_SINI);

            /*" -1275- MOVE SISINACO-NUM-OCORR-SINIACO TO SIHISACO-NUM-OCORR-SINIACO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_OCORR_SINIACO);

            /*" -1277- MOVE SINISMES-NUM-APOL-SINISTRO TO SIHISACO-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_APOL_SINISTRO);

            /*" -1279- MOVE HOST-OCORR-HIST-CANCELAMENTO TO SIHISACO-OCORR-HISTORICO */
            _.Move(HOST_OCORR_HIST_CANCELAMENTO, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_OCORR_HISTORICO);

            /*" -1282- MOVE HOST-COD-OPERAC-CANCELAMENTO TO SIHISACO-COD-OPERACAO */
            _.Move(HOST_COD_OPERAC_CANCELAMENTO, SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_COD_OPERACAO);

            /*" -1298- PERFORM R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1 */

            R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1();

            /*" -1301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1309- DISPLAY 'PROBLEMAS NO INSERT SI_HIST_ACOMPANHA' ' ' SIHISACO-COD-FONTE ' ' SIHISACO-NUM-PROTOCOLO-SINI ' ' SIHISACO-DAC-PROTOCOLO-SINI ' ' SIHISACO-NUM-OCORR-SINIACO ' ' SIHISACO-NUM-APOL-SINISTRO ' ' SIHISACO-COD-OPERACAO ' ' SIHISACO-OCORR-HISTORICO */

                $"PROBLEMAS NO INSERT SI_HIST_ACOMPANHA {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_COD_FONTE} {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_PROTOCOLO_SINI} {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_DAC_PROTOCOLO_SINI} {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_OCORR_SINIACO} {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_APOL_SINISTRO} {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_COD_OPERACAO} {SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_OCORR_HISTORICO}"
                .Display();

                /*" -1311- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1311- ADD 1 TO AC-GRAVA-SIHISACO. */
            AREA_DE_WORK.AC_GRAVA_SIHISACO.Value = AREA_DE_WORK.AC_GRAVA_SIHISACO + 1;

        }

        [StopWatch]
        /*" R3000-00-INSERE-HIST-ACOMP-DB-INSERT-1 */
        public void R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1()
        {
            /*" -1298- EXEC SQL INSERT INTO SEGUROS.SI_HIST_ACOMPANHA (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_OCORR_SINIACO, NUM_APOL_SINISTRO, COD_OPERACAO, OCORR_HISTORICO) VALUES (:SIHISACO-COD-FONTE, :SIHISACO-NUM-PROTOCOLO-SINI, :SIHISACO-DAC-PROTOCOLO-SINI, :SIHISACO-NUM-OCORR-SINIACO, :SIHISACO-NUM-APOL-SINISTRO, :SIHISACO-COD-OPERACAO, :SIHISACO-OCORR-HISTORICO) END-EXEC. */

            var r3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 = new R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1()
            {
                SIHISACO_COD_FONTE = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_COD_FONTE.ToString(),
                SIHISACO_NUM_PROTOCOLO_SINI = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_PROTOCOLO_SINI.ToString(),
                SIHISACO_DAC_PROTOCOLO_SINI = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_DAC_PROTOCOLO_SINI.ToString(),
                SIHISACO_NUM_OCORR_SINIACO = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_OCORR_SINIACO.ToString(),
                SIHISACO_NUM_APOL_SINISTRO = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_NUM_APOL_SINISTRO.ToString(),
                SIHISACO_COD_OPERACAO = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_COD_OPERACAO.ToString(),
                SIHISACO_OCORR_HISTORICO = SIHISACO.DCLSI_HIST_ACOMPANHA.SIHISACO_OCORR_HISTORICO.ToString(),
            };

            R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1.Execute(r3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-ATUALI-SINI-MESTRE-SECTION */
        private void R3100_00_ATUALI_SINI_MESTRE_SECTION()
        {
            /*" -1321- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1327- PERFORM R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1 */

            R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1();

            /*" -1330- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1331- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_MESTRE' */
                _.Display($"PROBLEMAS NO UPDATE SINISTRO_MESTRE");

                /*" -1334- DISPLAY ' ' SINISMES-NUM-APOL-SINISTRO ' ' SINISMES-OCORR-HISTORICO ' ' SISTEMAS-DATA-MOV-ABERTO */

                $" {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -1336- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1336- ADD 1 TO AC-UPDAT-SINISMES. */
            AREA_DE_WORK.AC_UPDAT_SINISMES.Value = AREA_DE_WORK.AC_UPDAT_SINISMES + 1;

        }

        [StopWatch]
        /*" R3100-00-ATUALI-SINI-MESTRE-DB-UPDATE-1 */
        public void R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1()
        {
            /*" -1327- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET OCORR_HISTORICO = :SINISMES-OCORR-HISTORICO, DATA_ULT_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, SIT_REGISTRO = '2' WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1 = new R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1()
            {
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1.Execute(r3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-ATUALI-SINI-HISTOR-SECTION */
        private void R3200_00_ATUALI_SINI_HISTOR_SECTION()
        {
            /*" -1346- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1353- PERFORM R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1 */

            R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1();

            /*" -1356- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -1357- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_HISTORICO' */
                _.Display($"PROBLEMAS NO UPDATE SINISTRO_HISTORICO");

                /*" -1358- DISPLAY ' ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($" {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1360- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1360- ADD 1 TO AC-UPDAT-SINISHIS. */
            AREA_DE_WORK.AC_UPDAT_SINISHIS.Value = AREA_DE_WORK.AC_UPDAT_SINISHIS + 1;

        }

        [StopWatch]
        /*" R3200-00-ATUALI-SINI-HISTOR-DB-UPDATE-1 */
        public void R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1()
        {
            /*" -1353- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET SIT_REGISTRO = '2' WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181,1182,1183,1184,1081, 1082,1083,1084,9000) AND SIT_REGISTRO IN ( '0' , '1' ) END-EXEC. */

            var r3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1 = new R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1.Execute(r3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-ATUALI-SINI-HABIT1-SECTION */
        private void R3300_00_ATUALI_SINI_HABIT1_SECTION()
        {
            /*" -1370- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1374- PERFORM R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1 */

            R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1();

            /*" -1377- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1378- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_HABIT01' */
                _.Display($"PROBLEMAS NO UPDATE SINISTRO_HABIT01");

                /*" -1379- DISPLAY ' ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($" {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1381- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1381- ADD 1 TO AC-UPDAT-SINIHAB1. */
            AREA_DE_WORK.AC_UPDAT_SINIHAB1.Value = AREA_DE_WORK.AC_UPDAT_SINIHAB1 + 1;

        }

        [StopWatch]
        /*" R3300-00-ATUALI-SINI-HABIT1-DB-UPDATE-1 */
        public void R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1()
        {
            /*" -1374- EXEC SQL UPDATE SEGUROS.SINISTRO_HABIT01 SET SITUACAO = '2' WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1 = new R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1.Execute(r3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-ACESSA-SINI-CONTRO-SECTION */
        private void R3400_00_ACESSA_SINI_CONTRO_SECTION()
        {
            /*" -1391- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1417- PERFORM R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1 */

            R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1();

            /*" -1420- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1421- DISPLAY 'PROBLEMAS NO SELECT DA SINISTRO_CONTROLE' */
                _.Display($"PROBLEMAS NO SELECT DA SINISTRO_CONTROLE");

                /*" -1424- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -1426- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1426- ADD 1 TO AC-ACHOU-SINISCON. */
            AREA_DE_WORK.AC_ACHOU_SINISCON.Value = AREA_DE_WORK.AC_ACHOU_SINISCON + 1;

        }

        [StopWatch]
        /*" R3400-00-ACESSA-SINI-CONTRO-DB-SELECT-1 */
        public void R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1()
        {
            /*" -1417- EXEC SQL SELECT COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOLICE, COD_SUBGRUPO, OCORR_HISTORICO, PEND_VISTORIA, PEND_RESSEGURO, SIT_REGISTRO, PEND_VIST_COMPL INTO :SINISCON-COD-FONTE, :SINISCON-NUM-PROTOCOLO-SINI, :SINISCON-DAC-PROTOCOLO-SINI, :SINISCON-NUM-APOLICE, :SINISCON-COD-SUBGRUPO, :SINISCON-OCORR-HISTORICO, :SINISCON-PEND-VISTORIA, :SINISCON-PEND-RESSEGURO, :SINISCON-SIT-REGISTRO, :SINISCON-PEND-VIST-COMPL FROM SEGUROS.SINISTRO_CONTROLE WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI WITH UR END-EXEC. */

            var r3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1 = new R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1.Execute(r3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCON_COD_FONTE, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE);
                _.Move(executed_1.SINISCON_NUM_PROTOCOLO_SINI, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI);
                _.Move(executed_1.SINISCON_DAC_PROTOCOLO_SINI, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI);
                _.Move(executed_1.SINISCON_NUM_APOLICE, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_APOLICE);
                _.Move(executed_1.SINISCON_COD_SUBGRUPO, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_SUBGRUPO);
                _.Move(executed_1.SINISCON_OCORR_HISTORICO, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO);
                _.Move(executed_1.SINISCON_PEND_VISTORIA, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VISTORIA);
                _.Move(executed_1.SINISCON_PEND_RESSEGURO, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_RESSEGURO);
                _.Move(executed_1.SINISCON_SIT_REGISTRO, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_SIT_REGISTRO);
                _.Move(executed_1.SINISCON_PEND_VIST_COMPL, SINISCON.DCLSINISTRO_CONTROLE.SINISCON_PEND_VIST_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERE-SINI-ACOMPA-SECTION */
        private void R3500_00_INSERE_SINI_ACOMPA_SECTION()
        {
            /*" -1436- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1437- MOVE SINISCON-COD-FONTE TO SINISACO-COD-FONTE. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_FONTE);

            /*" -1439- MOVE SINISCON-NUM-PROTOCOLO-SINI TO SINISACO-NUM-PROTOCOLO-SINI. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_NUM_PROTOCOLO_SINI);

            /*" -1443- MOVE SINISCON-DAC-PROTOCOLO-SINI TO SINISACO-DAC-PROTOCOLO-SINI. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DAC_PROTOCOLO_SINI);

            /*" -1444- MOVE 8998 TO SINISACO-COD-OPERACAO */
            _.Move(8998, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_OPERACAO);

            /*" -1446- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISACO-DATA-OPERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO);

            /*" -1447- ACCEPT WTIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME);

            /*" -1448- MOVE WTIME-HH TO WTIME-HH-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_HH, AREA_DE_WORK.WTIME_AUX.WTIME_HH_AUX);

            /*" -1449- MOVE WTIME-MM TO WTIME-MM-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_MM, AREA_DE_WORK.WTIME_AUX.WTIME_MM_AUX);

            /*" -1450- MOVE WTIME-SS TO WTIME-SS-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_SS, AREA_DE_WORK.WTIME_AUX.WTIME_SS_AUX);

            /*" -1452- MOVE '.' TO WTIME-PONTO01 WTIME-PONTO02. */
            _.Move(".", AREA_DE_WORK.WTIME_AUX.WTIME_PONTO01, AREA_DE_WORK.WTIME_AUX.WTIME_PONTO02);

            /*" -1453- MOVE WTIME-AUX TO SINISACO-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.WTIME_AUX, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO);

            /*" -1455- COMPUTE SINISCON-OCORR-HISTORICO = SINISCON-OCORR-HISTORICO + 1. */
            SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO.Value = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO + 1;

            /*" -1456- MOVE SINISCON-OCORR-HISTORICO TO SINISACO-OCORR-HISTORICO. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_OCORR_HISTORICO);

            /*" -1457- MOVE 'SI0045B' TO SINISACO-COD-USUARIO. */
            _.Move("SI0045B", SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_USUARIO);

            /*" -1459- MOVE ZEROS TO SINISACO-COD-EMPRESA. */
            _.Move(0, SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_EMPRESA);

            /*" -1481- PERFORM R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1 */

            R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1();

            /*" -1484- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1485- DISPLAY 'PROBLEMAS NO INSERT DA SINISTRO_ACOMPANHA' */
                _.Display($"PROBLEMAS NO INSERT DA SINISTRO_ACOMPANHA");

                /*" -1494- DISPLAY ' ' SINISACO-COD-FONTE ' ' SINISACO-NUM-PROTOCOLO-SINI ' ' SINISACO-DAC-PROTOCOLO-SINI ' ' SINISACO-COD-OPERACAO ' ' SINISACO-DATA-OPERACAO ' ' SINISACO-HORA-OPERACAO ' ' SINISACO-OCORR-HISTORICO ' ' SINISACO-COD-USUARIO ' ' SINISACO-COD-EMPRESA */

                $" {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_FONTE} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_NUM_PROTOCOLO_SINI} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DAC_PROTOCOLO_SINI} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_OPERACAO} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_OCORR_HISTORICO} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_USUARIO} {SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_COD_EMPRESA}"
                .Display();

                /*" -1496- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1496- ADD 1 TO AC-GRAVA-SINISACO. */
            AREA_DE_WORK.AC_GRAVA_SINISACO.Value = AREA_DE_WORK.AC_GRAVA_SINISACO + 1;

        }

        [StopWatch]
        /*" R3500-00-INSERE-SINI-ACOMPA-DB-INSERT-1 */
        public void R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1()
        {
            /*" -1481- EXEC SQL INSERT INTO SEGUROS.SINISTRO_ACOMPANHA (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_OPERACAO, DATA_OPERACAO, HORA_OPERACAO, OCORR_HISTORICO, COD_USUARIO, COD_EMPRESA, TIMESTAMP) VALUES (:SINISACO-COD-FONTE, :SINISACO-NUM-PROTOCOLO-SINI, :SINISACO-DAC-PROTOCOLO-SINI, :SINISACO-COD-OPERACAO, :SINISACO-DATA-OPERACAO, :SINISACO-HORA-OPERACAO, :SINISACO-OCORR-HISTORICO, :SINISACO-COD-USUARIO, :SINISACO-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1 = new R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1()
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

            R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1.Execute(r3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-ATUALI-SINI-CONTRO-SECTION */
        private void R3600_00_ATUALI_SINI_CONTRO_SECTION()
        {
            /*" -1506- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1512- PERFORM R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1 */

            R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1();

            /*" -1515- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1516- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_CONTROLE' */
                _.Display($"PROBLEMAS NO UPDATE SINISTRO_CONTROLE");

                /*" -1519- DISPLAY ' ' SINISCON-COD-FONTE ' ' SINISCON-NUM-PROTOCOLO-SINI ' ' SINISCON-DAC-PROTOCOLO-SINI */

                $" {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI} {SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -1521- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1521- ADD 1 TO AC-UPDAT-SINISCON. */
            AREA_DE_WORK.AC_UPDAT_SINISCON.Value = AREA_DE_WORK.AC_UPDAT_SINISCON + 1;

        }

        [StopWatch]
        /*" R3600-00-ATUALI-SINI-CONTRO-DB-UPDATE-1 */
        public void R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1()
        {
            /*" -1512- EXEC SQL UPDATE SEGUROS.SINISTRO_CONTROLE SET OCORR_HISTORICO = :SINISCON-OCORR-HISTORICO WHERE COD_FONTE = :SINISCON-COD-FONTE AND NUM_PROTOCOLO_SINI= :SINISCON-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI= :SINISCON-DAC-PROTOCOLO-SINI END-EXEC. */

            var r3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1 = new R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1()
            {
                SINISCON_OCORR_HISTORICO = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_OCORR_HISTORICO.ToString(),
                SINISCON_NUM_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.ToString(),
                SINISCON_DAC_PROTOCOLO_SINI = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.ToString(),
                SINISCON_COD_FONTE = SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE.ToString(),
            };

            R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1.Execute(r3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERE-HIST-ACOMP-SECTION */
        private void R3700_00_INSERE_HIST_ACOMP_SECTION()
        {
            /*" -1531- MOVE '3700' TO WNR-EXEC-SQL. */
            _.Move("3700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1532- MOVE SINISCON-COD-FONTE TO SIHISACM-COD-FONTE. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_COD_FONTE, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_COD_FONTE);

            /*" -1534- MOVE SINISCON-NUM-PROTOCOLO-SINI TO SIHISACM-NUM-PROTOCOLO-SINI. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_NUM_PROTOCOLO_SINI);

            /*" -1536- MOVE SINISCON-DAC-PROTOCOLO-SINI TO SIHISACM-DAC-PROTOCOLO-SINI. */
            _.Move(SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_DAC_PROTOCOLO_SINI);

            /*" -1537- MOVE SINISMES-NUM-APOL-SINISTRO TO SIHISACM-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_NUM_APOL_SINISTRO);

            /*" -1538- MOVE SINISACO-OCORR-HISTORICO TO SIHISACM-OCORR-HISTORICO. */
            _.Move(SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_OCORR_HISTORICO, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_OCORR_HISTORICO);

            /*" -1539- MOVE HOST-OCORR-HIST-CANCELAMENTO TO SIHISACM-OCORR-HIST. */
            _.Move(HOST_OCORR_HIST_CANCELAMENTO, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_OCORR_HIST);

            /*" -1541- MOVE HOST-COD-OPERAC-CANCELAMENTO TO SIHISACM-COD-OPERACAO. */
            _.Move(HOST_COD_OPERAC_CANCELAMENTO, SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_COD_OPERACAO);

            /*" -1557- PERFORM R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1 */

            R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1();

            /*" -1560- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1561- DISPLAY 'PROBLEMAS NO INSERT DA SI_HIST_ACOMP' */
                _.Display($"PROBLEMAS NO INSERT DA SI_HIST_ACOMP");

                /*" -1568- DISPLAY ' ' SIHISACM-COD-FONTE ' ' SIHISACM-NUM-PROTOCOLO-SINI ' ' SIHISACM-DAC-PROTOCOLO-SINI ' ' SIHISACM-OCORR-HISTORICO ' ' SIHISACM-NUM-APOL-SINISTRO ' ' SIHISACM-OCORR-HIST ' ' SIHISACM-COD-OPERACAO */

                $" {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_COD_FONTE} {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_NUM_PROTOCOLO_SINI} {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_DAC_PROTOCOLO_SINI} {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_OCORR_HISTORICO} {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_NUM_APOL_SINISTRO} {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_OCORR_HIST} {SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_COD_OPERACAO}"
                .Display();

                /*" -1570- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1570- ADD 1 TO AC-GRAVA-SIHISACM. */
            AREA_DE_WORK.AC_GRAVA_SIHISACM.Value = AREA_DE_WORK.AC_GRAVA_SIHISACM + 1;

        }

        [StopWatch]
        /*" R3700-00-INSERE-HIST-ACOMP-DB-INSERT-1 */
        public void R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1()
        {
            /*" -1557- EXEC SQL INSERT INTO SEGUROS.SI_HIST_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, OCORR_HISTORICO, NUM_APOL_SINISTRO, OCORR_HIST, COD_OPERACAO) VALUES (:SIHISACM-COD-FONTE, :SIHISACM-NUM-PROTOCOLO-SINI, :SIHISACM-DAC-PROTOCOLO-SINI, :SIHISACM-OCORR-HISTORICO, :SIHISACM-NUM-APOL-SINISTRO, :SIHISACM-OCORR-HIST, :SIHISACM-COD-OPERACAO) END-EXEC. */

            var r3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1 = new R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1()
            {
                SIHISACM_COD_FONTE = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_COD_FONTE.ToString(),
                SIHISACM_NUM_PROTOCOLO_SINI = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_NUM_PROTOCOLO_SINI.ToString(),
                SIHISACM_DAC_PROTOCOLO_SINI = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_DAC_PROTOCOLO_SINI.ToString(),
                SIHISACM_OCORR_HISTORICO = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_OCORR_HISTORICO.ToString(),
                SIHISACM_NUM_APOL_SINISTRO = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_NUM_APOL_SINISTRO.ToString(),
                SIHISACM_OCORR_HIST = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_OCORR_HIST.ToString(),
                SIHISACM_COD_OPERACAO = SIHISACM.DCLSI_HIST_ACOMP.SIHISACM_COD_OPERACAO.ToString(),
            };

            R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1.Execute(r3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-PROCESSA-IMPRESSAO-SECTION */
        private void R4000_00_PROCESSA_IMPRESSAO_SECTION()
        {
            /*" -1580- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1581- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO WDATA-ANO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.WDATA.WDATA_ANO);

            /*" -1582- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WDATA-MES. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.WDATA.WDATA_MES);

            /*" -1583- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO WDATA-DIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.WDATA.WDATA_DIA);

            /*" -1584- MOVE '/' TO WDATA-TRACO01 WDATA-TRACO02. */
            _.Move("/", AREA_DE_WORK.WDATA.WDATA_TRACO01, AREA_DE_WORK.WDATA.WDATA_TRACO02);

            /*" -1586- MOVE WDATA TO LC-02-DATA. */
            _.Move(AREA_DE_WORK.WDATA, AREA_DE_WORK.LC_02.LC_02_DATA);

            /*" -1587- ACCEPT WTIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME);

            /*" -1588- MOVE WTIME-HH TO WTIME-HH-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_HH, AREA_DE_WORK.WTIME_AUX.WTIME_HH_AUX);

            /*" -1589- MOVE WTIME-MM TO WTIME-MM-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_MM, AREA_DE_WORK.WTIME_AUX.WTIME_MM_AUX);

            /*" -1590- MOVE WTIME-SS TO WTIME-SS-AUX. */
            _.Move(AREA_DE_WORK.WTIME.WTIME_SS, AREA_DE_WORK.WTIME_AUX.WTIME_SS_AUX);

            /*" -1591- MOVE ':' TO WTIME-PONTO01 WTIME-PONTO02. */
            _.Move(":", AREA_DE_WORK.WTIME_AUX.WTIME_PONTO01, AREA_DE_WORK.WTIME_AUX.WTIME_PONTO02);

            /*" -1593- MOVE WTIME-AUX TO LC-03-HORA. */
            _.Move(AREA_DE_WORK.WTIME_AUX, AREA_DE_WORK.LC_03.LC_03_HORA);

            /*" -1595- IF AC-LINHAS GREATER 57 OR SISINACO-COD-USUARIO NOT = WCOD-USUARIO-ANT */

            if (AREA_DE_WORK.AC_LINHAS > 57 || SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO != AREA_DE_WORK.WCOD_USUARIO_ANT)
            {

                /*" -1597- PERFORM R4100-00-IMPRIMIR-CABECALHO. */

                R4100_00_IMPRIMIR_CABECALHO_SECTION();
            }


            /*" -1599- MOVE SISINACO-COD-USUARIO TO WCOD-USUARIO-ANT. */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO, AREA_DE_WORK.WCOD_USUARIO_ANT);

            /*" -1601- PERFORM R4200-00-ACESSA-USUARIOS. */

            R4200_00_ACESSA_USUARIOS_SECTION();

            /*" -1602- MOVE SINISMES-NUM-APOL-SINISTRO TO DET-NUM-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, AREA_DE_WORK.LD_01.DET_NUM_SINISTRO);

            /*" -1603- MOVE USUARIOS-NOME-USUARIO TO DET-ANALISTA-SINI. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.LD_01.DET_ANALISTA_SINI);

            /*" -1604- MOVE WHOST-REITERACOES TO DET-NUM-ULT-REITERA. */
            _.Move(WHOST_REITERACOES, AREA_DE_WORK.LD_01.DET_NUM_ULT_REITERA);

            /*" -1606- MOVE HOST-NUM-CARTA TO DET-NUM-ULT-CARTA. */
            _.Move(HOST_NUM_CARTA, AREA_DE_WORK.LD_01.DET_NUM_ULT_CARTA);

            /*" -1608- MOVE SISINACO-DATA-MOVTO-SINIACO(1:4) TO WDATA-ANO. */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.Substring(1, 4), AREA_DE_WORK.WDATA.WDATA_ANO);

            /*" -1610- MOVE SISINACO-DATA-MOVTO-SINIACO(6:2) TO WDATA-MES. */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.Substring(6, 2), AREA_DE_WORK.WDATA.WDATA_MES);

            /*" -1612- MOVE SISINACO-DATA-MOVTO-SINIACO(9:2) TO WDATA-DIA. */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.Substring(9, 2), AREA_DE_WORK.WDATA.WDATA_DIA);

            /*" -1614- MOVE '/' TO WDATA-TRACO01 WDATA-TRACO02. */
            _.Move("/", AREA_DE_WORK.WDATA.WDATA_TRACO01, AREA_DE_WORK.WDATA.WDATA_TRACO02);

            /*" -1616- MOVE WDATA TO DET-DATA-ULT-CARTA. */
            _.Move(AREA_DE_WORK.WDATA, AREA_DE_WORK.LD_01.DET_DATA_ULT_CARTA);

            /*" -1618- MOVE SISINACO-NUM-PROTOCOLO-SINI TO DET-NUM-PROTOCOLO. */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI, AREA_DE_WORK.LD_01.DET_NUM_PROTOCOLO);

            /*" -1620- PERFORM R4300-00-ACESSA-GIPRO-GITER. */

            R4300_00_ACESSA_GIPRO_GITER_SECTION();

            /*" -1621- MOVE GEDESTIN-COD-FILIAL TO DET-COD-FILIAL. */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_COD_FILIAL, AREA_DE_WORK.LD_01.DET_COD_FILIAL);

            /*" -1623- MOVE GEDESTIN-NOME-DESTINATARIO TO DET-DESTINATARIO. */
            _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, AREA_DE_WORK.LD_01.DET_DESTINATARIO);

            /*" -1624- WRITE REG-MOVTO FROM LD-01 AFTER 2. */
            _.Move(AREA_DE_WORK.LD_01.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1624- ADD 02 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 02;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-IMPRIMIR-CABECALHO-SECTION */
        private void R4100_00_IMPRIMIR_CABECALHO_SECTION()
        {
            /*" -1634- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1635- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -1637- MOVE AC-PAGINA TO LC-01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC_01.LC_01_PAGINA);

            /*" -1638- WRITE REG-MOVTO FROM LC-01 AFTER PAGE. */
            _.Move(AREA_DE_WORK.LC_01.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1639- WRITE REG-MOVTO FROM LC-02 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_02.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1640- WRITE REG-MOVTO FROM LC-03 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_03.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1641- WRITE REG-MOVTO FROM LC-04 AFTER 3. */
            _.Move(AREA_DE_WORK.LC_04.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1642- WRITE REG-MOVTO FROM LC-05 AFTER 2. */
            _.Move(AREA_DE_WORK.LC_05.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1643- WRITE REG-MOVTO FROM LC-04 AFTER 2. */
            _.Move(AREA_DE_WORK.LC_04.GetMoveValues(), REG_MOVTO);

            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1644- MOVE SPACES TO REG-MOVTO */
            _.Move("", REG_MOVTO);

            /*" -1645- WRITE REG-MOVTO AFTER 1. */
            RSI0045B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -1645- MOVE 10 TO AC-LINHAS. */
            _.Move(10, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-ACESSA-USUARIOS-SECTION */
        private void R4200_00_ACESSA_USUARIOS_SECTION()
        {
            /*" -1655- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1669- PERFORM R4200_00_ACESSA_USUARIOS_DB_SELECT_1 */

            R4200_00_ACESSA_USUARIOS_DB_SELECT_1();

            /*" -1672- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1673- DISPLAY 'PROBLEMAS NO SELECT DA USUARIOS' */
                _.Display($"PROBLEMAS NO SELECT DA USUARIOS");

                /*" -1674- DISPLAY ' ' SISINACO-COD-USUARIO */
                _.Display($" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO}");

                /*" -1674- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4200-00-ACESSA-USUARIOS-DB-SELECT-1 */
        public void R4200_00_ACESSA_USUARIOS_DB_SELECT_1()
        {
            /*" -1669- EXEC SQL SELECT COD_USUARIO, COD_FONTE, NUM_CENTRO_CUSTO, NUM_MATRICULA, NOME_USUARIO INTO :USUARIOS-COD-USUARIO, :USUARIOS-COD-FONTE, :USUARIOS-NUM-CENTRO-CUSTO, :USUARIOS-NUM-MATRICULA, :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SISINACO-COD-USUARIO WITH UR END-EXEC. */

            var r4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1 = new R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1()
            {
                SISINACO_COD_USUARIO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO.ToString(),
            };

            var executed_1 = R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1.Execute(r4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
                _.Move(executed_1.USUARIOS_COD_FONTE, USUARIOS.DCLUSUARIOS.USUARIOS_COD_FONTE);
                _.Move(executed_1.USUARIOS_NUM_CENTRO_CUSTO, USUARIOS.DCLUSUARIOS.USUARIOS_NUM_CENTRO_CUSTO);
                _.Move(executed_1.USUARIOS_NUM_MATRICULA, USUARIOS.DCLUSUARIOS.USUARIOS_NUM_MATRICULA);
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-ACESSA-GIPRO-GITER-SECTION */
        private void R4300_00_ACESSA_GIPRO_GITER_SECTION()
        {
            /*" -1684- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1700- PERFORM R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1 */

            R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1();

            /*" -1703- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1704- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1705- MOVE ZEROS TO GEDESTIN-COD-FILIAL */
                    _.Move(0, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_COD_FILIAL);

                    /*" -1707- MOVE 'NAO EXISTE DESTINATARIO' TO GEDESTIN-NOME-DESTINATARIO */
                    _.Move("NAO EXISTE DESTINATARIO", GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);

                    /*" -1708- ELSE */
                }
                else
                {


                    /*" -1709- DISPLAY 'PROBLEMAS NO SELECT GE_DESTINATARIO E MOVSINI' */
                    _.Display($"PROBLEMAS NO SELECT GE_DESTINATARIO E MOVSINI");

                    /*" -1710- DISPLAY ' ' SISINACO-COD-USUARIO */
                    _.Display($" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO}");

                    /*" -1713- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1714- IF SINISMES-COD-PRODUTO = 6814 OR 7701 OR 7709 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("6814", "7701", "7709"))
            {

                /*" -1715- MOVE ZEROS TO GEDESTIN-COD-FILIAL */
                _.Move(0, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_COD_FILIAL);

                /*" -1716- MOVE 'CAIXA CONSORCIOS S/A' TO GEDESTIN-NOME-DESTINATARIO. */
                _.Move("CAIXA CONSORCIOS S/A", GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);
            }


        }

        [StopWatch]
        /*" R4300-00-ACESSA-GIPRO-GITER-DB-SELECT-1 */
        public void R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1()
        {
            /*" -1700- EXEC SQL SELECT B.COD_FILIAL, B.NOME_DESTINATARIO INTO :GEDESTIN-COD-FILIAL, :GEDESTIN-NOME-DESTINATARIO FROM SEGUROS.SI_MOVIMENTO_SINI A, SEGUROS.GE_DESTINATARIO B WHERE A.COD_GIAFI = B.COD_FILIAL AND A.COD_SUBESTIPULANTE = B.COD_CLIENTE AND A.COD_FONTE = :SISINACO-COD-FONTE AND A.NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND A.DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI WITH UR END-EXEC. */

            var r4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1 = new R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1.Execute(r4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDESTIN_COD_FILIAL, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_COD_FILIAL);
                _.Move(executed_1.GEDESTIN_NOME_DESTINATARIO, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1726- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1728- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1728- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1732- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1733- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -1734- DISPLAY '***   SI0045B - CANCELADO  ***' */
            _.Display($"***   SI0045B - CANCELADO  ***");

            /*" -1736- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -1736- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}