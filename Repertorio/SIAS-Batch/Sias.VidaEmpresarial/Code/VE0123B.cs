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
using Sias.VidaEmpresarial.DB2.VE0123B;

namespace Code
{
    public class VE0123B
    {
        public bool IsCall { get; set; }

        public VE0123B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   SOLICITACAO ............ CADMUS 92.882                              */
        /*"      *   DATA ................... ABRIL/2014                                 */
        /*"      *   ANALISTA ............... BRICE HO                                   */
        /*"      *   FUNCAO ................. CORRECAO MONETARIA DOS CERTIFICADOS        */
        /*"      *                            EMPRESARIAL ANTECIPADOS NO VENCIMEN-       */
        /*"      *                            TO DO PRIMEIRO ANIVERSARIO PELO            */
        /*"      *                            IGPM.                                      */
        /*"      *                            MIGRACAO CERTIFICADOS EMPRESARIAL          */
        /*"      *                            ANTECIPADOS PARA MENSAL.                   */
        /*"      *                                                                       */
        /*"      *   PRODUTOS: 9343 - VIDA EMPRESARIAL VG                                */
        /*"      *             8209 - VIDA EMPRESARIAL APC                               */
        /*"      *                                                                       */
        /*"      *   CERTIFICADOS EMPRESARIAL ANTECIPADOS ATIVOS, A VENCER NOS           */
        /*"      *   PROXIMOS 30 DIAS,  QUE NAO TENHAM A OPCAO DE "NAO MIGRAR"           */
        /*"      *   ( STA_MUDANCA_PLANO DIFERENTE DE 'N' ) DEVERAO MIGRAR DE            */
        /*"      *   ANUAL PARA MENSAL, A SABER:                                         */
        /*"      *             DE  9343  PARA  9329                                      */
        /*"      *             DE  8209  PARA  8205                                      */
        /*"      *                                                                       */
        /*"      *   CERTIFICADOS ANTECIPADOS ATIVOS A VENCER NOS PROXIMOS 30 DIAS       */
        /*"      *   QUE TENHAM A OPÇÃO DE "NAO MIGRAR" (STA_MUDANCA_PLANO = 'N')        */
        /*"      *   DEVERÃO PERMANECER COMO ANUAL,PERDENDO O STATUS DE ANTECIPADO       */
        /*"      *   MANTENDO O MESMO CODIGO DO PRODUTO.                                 */
        /*"      *                                                                       */
        /*"      *   EM AMBAS DAS SITUCOES ACIMA, OS CERTIFICADOS TERAO SEUS             */
        /*"      *   PREMIOS CORRIGIDOS PELO IGPM.                                       */
        /*"      *                                                                       */
        /*"      * OBSERVACOES.                                                          */
        /*"      * ============                                                          */
        /*"      * 1.   CASO O FATOR DE CORRECAO IGPM FOR MENOR OU IGUAL A ZEROS,        */
        /*"      *      O PROGRAMA PROCESSA A MIGRACAO SEM CORRIGIR OS VALORES           */
        /*"      *      E TERMINA COM RC=2 PARA GERAR E-MAIL PARA OS GESTORES.           */
        /*"      *                                                                       */
        /*"      * 2.   CASO NAO ENCONTRE O INDICE IGPM NA DATA TERMINO DE COTACAO       */
        /*"      *      (SISTEMAS-DTTER-COTACAO),O PROGRAMA NAO PROCESSA A MIGRACAO      */
        /*"      *      E TERMINA COM RC=3 PARA GERAR E-MAIL PARA OS GESTORES.           */
        /*"      *-----------------------------------------------------------------      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *                 A L T E R A C O E S                                   */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 08 - D 575149 T 585137                                *      */
        /*"      *             - ACERTAR INSERT'S NA HIS_COBER_PROPOST  E         *      */
        /*"      *             V0COBERPROPVA                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/05/2024 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07   - DEMANDA 192339                                 *      */
        /*"      *               - FAZER COM QUE A DATA DE TERMINO DE VIGENCIA DA *      */
        /*"      *                 OPCAO_PAG_VIDAZUL FIQUE IGUAL A AQUELA CADAS-  *      */
        /*"      *                 TRADA NA HIS_COBER_PROPOST, PARA QUE, NAO DE   *      */
        /*"      *                 ERRO NO VG0853B QUANDO FOR GERAR COBRANCA.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/07/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 06   - JOA�O ARAU�JO                                         */
        /*"      *               - CORRECA�O ABEND JV1                                   */
        /*"      *   EM 01/04/2019 - MILLENIUM                                    *      */
        /*"      *                                       PROCURE POR JV102        *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 05 -  ADAILTON DIAS                                          */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 23/01/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 143.195                                             */
        /*"      *                                                                       */
        /*"      *             - ALTERACAO DE POSICAO DA ROTINA                          */
        /*"      *               R2600-00-ATUALIZA-PRODUTOS-VG PARA EXECUTAR DEPOIS      */
        /*"      *               DE MIGRAR AS APOLICES.                                  */
        /*"      *                                                                       */
        /*"      *   EM 16/11/2016 - LUIGI CONTE                                         */
        /*"      *                                            PROCURE POR V.04           */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 03 - CAD 102.406                                             */
        /*"      *                                                                       */
        /*"      *             - ALTERACAO DE COD_PRODUTO E PERIODO_PGMTO                */
        /*"      *               NA SEGUROS.PRODUTOS_VG PARA AS APOLICES MIGRADAS        */
        /*"      *                                                                       */
        /*"      *   EM 05/11/2014 - ELIERMES OLIVEIRA                                   */
        /*"      *                                            PROCURE POR V.03           */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 02 - CAD 98.264                                              */
        /*"      *                                                                       */
        /*"      *               - DESABILITAR INSERT NA MOVIMENTOS_VGAP.                */
        /*"      *               - AJUSTES NO CALCULO DAS DATAS DE VIGENCIAS             */
        /*"      *                 DA HIS_COBER_PROPOST.                                 */
        /*"      *                                                                       */
        /*"      *   EM 21/05/2014 - BRICE HO                                            */
        /*"      *                                                                       */
        /*"      *                                            PROCURE POR V.02           */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 01 - CAD 98.188                                              */
        /*"      *                                                                       */
        /*"      *               - RETIRAR VALIDACAO DO NUMERO OCORRENCIA                */
        /*"      *                 DO PROPOVA X HISCOBPR DA ROTINA                       */
        /*"      *                 R2000-00-CALC-CORRECAO-IGPM.                          */
        /*"      *                                                                       */
        /*"      *   EM 20/05/2014 - BRICE HO                                            */
        /*"      *                                                                       */
        /*"      *                                            PROCURE POR V.01           */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------------      */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-PROPOVA-DATA-QUITACAO       PIC X(10) VALUE SPACES.*/
        public StringBasis WS_PROPOVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  SISTEMAS-DATA-CORTE            PIC   X(010).*/
        public StringBasis SISTEMAS_DATA_CORTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTMOV-ABERTO          PIC   X(010).*/
        public StringBasis SISTEMAS_DTMOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTMOV-ABERTO-30       PIC   X(010).*/
        public StringBasis SISTEMAS_DTMOV_ABERTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTINI-COTACAO         PIC   X(010).*/
        public StringBasis SISTEMAS_DTINI_COTACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTTER-COTACAO         PIC   X(010).*/
        public StringBasis SISTEMAS_DTTER_COTACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-COUNT                    PIC  S9(015) COMP-3 VALUE +0.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WIND                           PIC   9(002) VALUE ZEROS.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"77  WFIM-CURS01                    PIC   X(003) VALUE SPACES.*/
        public StringBasis WFIM_CURS01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WFIM-CURS02                    PIC   X(003) VALUE SPACES.*/
        public StringBasis WFIM_CURS02 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  W-IND-CORR                     PIC   X(003) VALUE SPACES.*/
        public StringBasis W_IND_CORR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-TIME                        PIC   X(008) VALUE ZEROS.*/
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WS-NUM-PROPOSTA-AUT            PIC  S9(009) COMP.*/
        public IntBasis WS_NUM_PROPOSTA_AUT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WS-DTANIVERS                   PIC   X(010).*/
        public StringBasis WS_DTANIVERS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-DTANIVERS-1                 PIC   X(010).*/
        public StringBasis WS_DTANIVERS_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-DTANIVERS-2                 PIC   X(010).*/
        public StringBasis WS_DTANIVERS_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-DTANIVERS-3                 PIC   X(010).*/
        public StringBasis WS_DTANIVERS_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  TABELA-IGPM.*/
        public VE0123B_TABELA_IGPM TABELA_IGPM { get; set; } = new VE0123B_TABELA_IGPM();
        public class VE0123B_TABELA_IGPM : VarBasis
        {
            /*"    03  FILLER   OCCURS 12  TIMES.*/
            public ListBasis<VE0123B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VE0123B_FILLER_0>(12);
            public class VE0123B_FILLER_0 : VarBasis
            {
                /*"        05  TB-IGPM-DATA           PIC   X(010).*/
                public StringBasis TB_IGPM_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        05  TB-IGPM-VALOR          PIC  S9(006)V9(9) COMP-3.*/
                public DoubleBasis TB_IGPM_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                /*"        05  TB-IGPM-ACUM-MES       PIC  S9(006)V9(9) COMP-3.*/
                public DoubleBasis TB_IGPM_ACUM_MES { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                /*"01  WS-DATA-SISTEMA                             VALUE SPACES.*/
            }
        }
        public VE0123B_WS_DATA_SISTEMA WS_DATA_SISTEMA { get; set; } = new VE0123B_WS_DATA_SISTEMA();
        public class VE0123B_WS_DATA_SISTEMA : VarBasis
        {
            /*"    03  WS-ANO-SIST                PIC   9(004).*/
            public IntBasis WS_ANO_SIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03  FILLER                     PIC   X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-MES-SIST                PIC   9(002).*/
            public IntBasis WS_MES_SIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  FILLER                     PIC   X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-DIA-SIST                PIC   9(002).*/
            public IntBasis WS_DIA_SIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  VALORES-CORRIGIDOS.*/
        }
        public VE0123B_VALORES_CORRIGIDOS VALORES_CORRIGIDOS { get; set; } = new VE0123B_VALORES_CORRIGIDOS();
        public class VE0123B_VALORES_CORRIGIDOS : VarBasis
        {
            /*"    03  W-IMPSEGUR-CORR            PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPSEGUR_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPSEGIND-CORR           PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPSEGIND_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPMORNATU-CORR          PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPMORNATU_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPMORACID-CORR          PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPMORACID_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPINVPERM-CORR          PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPINVPERM_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPAMDS-CORR             PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPAMDS_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPDH-CORR               PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPDH_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-IMPDIT-CORR              PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_IMPDIT_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-PRMVG-CORR               PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_PRMVG_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-PRMAP-CORR               PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_PRMAP_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-PRMTOT-CORR              PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_PRMTOT_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  W-PRMDIT-CORR              PIC  S9(013)V99   COMP-3.*/
            public DoubleBasis W_PRMDIT_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  W-DIG-CONTA                    PIC   X(001).*/
        }
        public StringBasis W_DIG_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  W-DIG-CTA-NUM  REDEFINES  W-DIG-CONTA                                   PIC   9(001).*/
        private _REDEF_IntBasis _w_dig_cta_num { get; set; }
        public _REDEF_IntBasis W_DIG_CTA_NUM
        {
            get { _w_dig_cta_num = new _REDEF_IntBasis(new PIC("9", "001", "9(001).")); ; _.Move(W_DIG_CONTA, _w_dig_cta_num); VarBasis.RedefinePassValue(W_DIG_CONTA, _w_dig_cta_num, W_DIG_CONTA); _w_dig_cta_num.ValueChanged += () => { _.Move(_w_dig_cta_num, W_DIG_CONTA); }; return _w_dig_cta_num; }
            set { VarBasis.RedefinePassValue(value, _w_dig_cta_num, W_DIG_CONTA); }
        }  //Redefines
        /*"01  ACUMULADORES.*/
        public VE0123B_ACUMULADORES ACUMULADORES { get; set; } = new VE0123B_ACUMULADORES();
        public class VE0123B_ACUMULADORES : VarBasis
        {
            /*"    03  W-IGPM-ACUM                PIC S9(006)V9(9)    VALUE +0.*/
            public DoubleBasis W_IGPM_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"    03  W-IGPM-EDIT1               PIC  ZZZZZ9,9(9)- .*/
            public DoubleBasis W_IGPM_EDIT1 { get; set; } = new DoubleBasis(new PIC("ZZZZZ9,9", "6", "ZZZZZ9V9(9)-"), 10);
            /*"    03  W-IGPM-EDIT2               PIC  ZZZZZ9,9(9)- .*/
            public DoubleBasis W_IGPM_EDIT2 { get; set; } = new DoubleBasis(new PIC("ZZZZZ9,9", "6", "ZZZZZ9V9(9)-"), 10);
            /*"    03  AC-LIDOS                   PIC   9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-CONTA                   PIC   9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-NAO-MIGRA               PIC   9(006) VALUE ZEROS.*/
            public IntBasis AC_NAO_MIGRA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-MIGRADOS                PIC   9(006) VALUE ZEROS.*/
            public IntBasis AC_MIGRADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-PROC                    PIC   9(006) VALUE ZEROS.*/
            public IntBasis AC_PROC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  WIND-NULOS.*/
        }
        public VE0123B_WIND_NULOS WIND_NULOS { get; set; } = new VE0123B_WIND_NULOS();
        public class VE0123B_WIND_NULOS : VarBasis
        {
            /*"    03  VIND-STAMDPLAN             PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_STAMDPLAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-OPEDEB                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_OPEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-AGEDEB                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_AGEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-CTADEB                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_CTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-DIGDEB                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_DIGDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-NUMCAR                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_NUMCAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-IMPSEGAUXF            PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_IMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-VLCUSTAUXF            PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_VLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-PRMDIT                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_PRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  VIND-QTMDIT                PIC  S9(004) COMP   VALUE +0.*/
            public IntBasis VIND_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  WABEND.*/
        }
        public VE0123B_WABEND WABEND { get; set; } = new VE0123B_WABEND();
        public class VE0123B_WABEND : VarBasis
        {
            /*"    03  FILLER                     PIC   X(010)    VALUE           'VE0123B '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VE0123B ");
            /*"    03  FILLER                     PIC  X(026)     VALUE           '*** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"    03  WNR-EXEC-SQL               PIC  X(006)     VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"    03  FILLER                     PIC  X(013)     VALUE           '*** SQLCODE '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"*** SQLCODE ");
            /*"    03  WSQLCODE                   PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
        }
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();

        public VE0123B_CURS01 CURS01 { get; set; } = new VE0123B_CURS01(true);
        string GetQuery_CURS01()
        {
            var query = @$"SELECT NUM_APOLICE
							,COD_SUBGRUPO
							,NUM_CERTIFICADO
							,COD_CLIENTE
							,OCOREND
							,COD_FONTE
							,AGE_COBRANCA
							,OCORR_HISTORICO
							,DATA_QUITACAO
							,DATA_VENCIMENTO
							,DTPROXVEN
							,NUM_PARCELA
							,COD_PRODUTO
							,NUM_PROPOSTA
							,STA_MUDANCA_PLANO
							FROM SEGUROS.PROPOSTAS_VA WHERE COD_PRODUTO IN (9343
							, 8209
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9343}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}') AND SIT_REGISTRO = '3' AND STA_ANTECIPACAO = 'S' AND DTPROXVEN <= '{SISTEMAS_DTMOV_ABERTO_30}' ORDER BY NUM_APOLICE
							, COD_SUBGRUPO";

            return query;
        }


        public VE0123B_CURS02 CURS02 { get; set; } = new VE0123B_CURS02(true);
        string GetQuery_CURS02()
        {
            var query = @$"SELECT DATA_INIVIGENCIA
							, VAL_VENDA
							FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = 23 AND DATA_INIVIGENCIA >= '{SISTEMAS_DTINI_COTACAO}' ORDER BY DATA_INIVIGENCIA FETCH FIRST 12 ROWS ONLY";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            CURS01.GetQueryEvent += GetQuery_CURS01;
            CURS02.GetQueryEvent += GetQuery_CURS02;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -315- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -316- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -317- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -320- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -321- DISPLAY 'PROGRAMA EM EXECUCAO   VE0123B ' */
            _.Display($"PROGRAMA EM EXECUCAO   VE0123B ");

            /*" -322- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -324- DISPLAY 'VERSAO V.08 D575149 02/05/2024' */
            _.Display($"VERSAO V.08 D575149 02/05/2024");

            /*" -325- MOVE 'VE0123B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("VE0123B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -326- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -326- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -327- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -328- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -329- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -330- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -331- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -332- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -333- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, WABEND.WSQLCODE);

                /*" -334- GO TO R9000-00-FINALIZA */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -336- END-IF */
            }


            /*" -337- PERFORM R0010-00-PROCESSO-INICIO. */

            R0010_00_PROCESSO_INICIO_SECTION();

            /*" -338- PERFORM R0300-00-OPEN-CURS01. */

            R0300_00_OPEN_CURS01_SECTION();

            /*" -340- PERFORM R0400-00-FETCH-CURS01. */

            R0400_00_FETCH_CURS01_SECTION();

            /*" -343- PERFORM R1000-00-PROCESSA-CURS01 UNTIL WFIM-CURS01 EQUAL 'SIM' . */

            while (!(WFIM_CURS01 == "SIM"))
            {

                R1000_00_PROCESSA_CURS01_SECTION();
            }

            /*" -343- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_99_SAIDA */

            R0000_99_SAIDA();

        }

        [StopWatch]
        /*" R0000-99-SAIDA */
        private void R0000_99_SAIDA(bool isPerform = false)
        {
            /*" -346- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0010-00-PROCESSO-INICIO-SECTION */
        private void R0010_00_PROCESSO_INICIO_SECTION()
        {
            /*" -353- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -354- PERFORM R0200-00-VERIFICA-COTACAO. */

            R0200_00_VERIFICA_COTACAO_SECTION();

            /*" -357- PERFORM R0250-00-APURAR-INDICE. */

            R0250_00_APURAR_INDICE_SECTION();

            /*" -358- COMPUTE W-IGPM-ACUM ROUNDED = W-IGPM-ACUM / 100 + 1 */
            ACUMULADORES.W_IGPM_ACUM.Value = ACUMULADORES.W_IGPM_ACUM / 100f + 1;

            /*" -360- MOVE W-IGPM-ACUM TO W-IGPM-EDIT1 */
            _.Move(ACUMULADORES.W_IGPM_ACUM, ACUMULADORES.W_IGPM_EDIT1);

            /*" -361- IF W-IGPM-ACUM NOT GREATER ZEROS */

            if (ACUMULADORES.W_IGPM_ACUM <= 00)
            {

                /*" -362- DISPLAY 'SEM FATOR CORRECAO IGPM PARA O PERIODO' */
                _.Display($"SEM FATOR CORRECAO IGPM PARA O PERIODO");

                /*" -363- DISPLAY 'MIGRACAO IRA OCORRER SEM CORRECAO' */
                _.Display($"MIGRACAO IRA OCORRER SEM CORRECAO");

                /*" -364- DISPLAY 'FATOR CORRECAO IGPM = ' W-IGPM-EDIT1 */
                _.Display($"FATOR CORRECAO IGPM = {ACUMULADORES.W_IGPM_EDIT1}");

                /*" -365- MOVE 'NAO' TO W-IND-CORR */
                _.Move("NAO", W_IND_CORR);

                /*" -366- MOVE 2 TO RETURN-CODE */
                _.Move(2, RETURN_CODE);

                /*" -366- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -377- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -389- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- DISPLAY 'ERRO SELECT SISTEMAS (VE) ' */
                _.Display($"ERRO SELECT SISTEMAS (VE) ");

                /*" -394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -396- END-IF. */
            }


            /*" -397- MOVE SISTEMAS-DTMOV-ABERTO TO WS-DATA-SISTEMA. */
            _.Move(SISTEMAS_DTMOV_ABERTO, WS_DATA_SISTEMA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -389- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 02 MONTH , DATA_MOV_ABERTO - 13 MONTH , DATA_MOV_ABERTO + 01 MONTH INTO :SISTEMAS-DTMOV-ABERTO ,:SISTEMAS-DTTER-COTACAO ,:SISTEMAS-DTINI-COTACAO ,:SISTEMAS-DTMOV-ABERTO-30 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VE' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DTMOV_ABERTO, SISTEMAS_DTMOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DTTER_COTACAO, SISTEMAS_DTTER_COTACAO);
                _.Move(executed_1.SISTEMAS_DTINI_COTACAO, SISTEMAS_DTINI_COTACAO);
                _.Move(executed_1.SISTEMAS_DTMOV_ABERTO_30, SISTEMAS_DTMOV_ABERTO_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-VERIFICA-COTACAO-SECTION */
        private void R0200_00_VERIFICA_COTACAO_SECTION()
        {
            /*" -411- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -413- MOVE 01 TO SISTEMAS-DTTER-COTACAO(9:2). */
            _.MoveAtPosition(01, SISTEMAS_DTTER_COTACAO, 9, 2);

            /*" -419- PERFORM R0200_00_VERIFICA_COTACAO_DB_SELECT_1 */

            R0200_00_VERIFICA_COTACAO_DB_SELECT_1();

            /*" -422- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -424- DISPLAY 'ERRO SELECT(COUNT) MOEDAS_COTACAO - NRSQL ' WNR-EXEC-SQL */
                _.Display($"ERRO SELECT(COUNT) MOEDAS_COTACAO - NRSQL {WABEND.WNR_EXEC_SQL}");

                /*" -425- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -427- END-IF. */
            }


            /*" -428- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -430- DISPLAY 'INDICE IGPM NAO CADASTRADO PARA A DATA <' SISTEMAS-DTTER-COTACAO '>' */

                $"INDICE IGPM NAO CADASTRADO PARA A DATA <{SISTEMAS_DTTER_COTACAO}>"
                .Display();

                /*" -431- DISPLAY 'ENCAMINHADO E-MAIL PARA GERTI' */
                _.Display($"ENCAMINHADO E-MAIL PARA GERTI");

                /*" -432- DISPLAY 'PROCESSAMENTO INTERROMPIDO COM RC=3' */
                _.Display($"PROCESSAMENTO INTERROMPIDO COM RC=3");

                /*" -433- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -434- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -434- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-VERIFICA-COTACAO-DB-SELECT-1 */
        public void R0200_00_VERIFICA_COTACAO_DB_SELECT_1()
        {
            /*" -419- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = 23 AND DATA_INIVIGENCIA = :SISTEMAS-DTTER-COTACAO END-EXEC. */

            var r0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1 = new R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DTTER_COTACAO = SISTEMAS_DTTER_COTACAO.ToString(),
            };

            var executed_1 = R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1.Execute(r0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-APURAR-INDICE-SECTION */
        private void R0250_00_APURAR_INDICE_SECTION()
        {
            /*" -446- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -448- MOVE 01 TO SISTEMAS-DTINI-COTACAO(9:2). */
            _.MoveAtPosition(01, SISTEMAS_DTINI_COTACAO, 9, 2);

            /*" -448- PERFORM R0250_00_APURAR_INDICE_DB_OPEN_1 */

            R0250_00_APURAR_INDICE_DB_OPEN_1();

            /*" -451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -452- DISPLAY 'ERRO OPEN CURSOR CURS02' */
                _.Display($"ERRO OPEN CURSOR CURS02");

                /*" -453- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -456- END-IF. */
            }


            /*" -458- PERFORM R0260-00-FETCH-COTACAO */

            R0260_00_FETCH_COTACAO_SECTION();

            /*" -459- IF WFIM-CURS02 EQUAL 'FIM' */

            if (WFIM_CURS02 == "FIM")
            {

                /*" -461- DISPLAY 'NAO ENCONTROU NENHUM INDICE IGPM PARA A DATA <' SISTEMAS-DTINI-COTACAO '>' */

                $"NAO ENCONTROU NENHUM INDICE IGPM PARA A DATA <{SISTEMAS_DTINI_COTACAO}>"
                .Display();

                /*" -462- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -465- END-IF. */
            }


            /*" -466- MOVE SPACES TO TABELA-IGPM */
            _.Move("", TABELA_IGPM);

            /*" -467- MOVE 1 TO WIND */
            _.Move(1, WIND);

            /*" -470- MOVE MOEDACOT-DATA-INIVIGENCIA TO TB-IGPM-DATA (WIND) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_DATA);

            /*" -472- IF MOEDACOT-VAL-VENDA LESS ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA < 00)
            {

                /*" -473- MOVE ZEROS TO MOEDACOT-VAL-VENDA */
                _.Move(0, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);

                /*" -475- END-IF. */
            }


            /*" -481- MOVE MOEDACOT-VAL-VENDA TO TB-IGPM-VALOR (WIND) TB-IGPM-ACUM-MES (WIND) W-IGPM-ACUM */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES, ACUMULADORES.W_IGPM_ACUM);

            /*" -483- PERFORM R0260-00-FETCH-COTACAO */

            R0260_00_FETCH_COTACAO_SECTION();

            /*" -484- IF WFIM-CURS02 EQUAL 'FIM' */

            if (WFIM_CURS02 == "FIM")
            {

                /*" -486- DISPLAY 'ENCONTROU SOMENTE UM INDICE IGPM PARA A DATA <' SISTEMAS-DTINI-COTACAO '>' */

                $"ENCONTROU SOMENTE UM INDICE IGPM PARA A DATA <{SISTEMAS_DTINI_COTACAO}>"
                .Display();

                /*" -487- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -489- END-IF. */
            }


            /*" -492- PERFORM R0270-CARREGA-COTACAO UNTIL WFIM-CURS02 EQUAL 'FIM' . */

            while (!(WFIM_CURS02 == "FIM"))
            {

                R0270_CARREGA_COTACAO_SECTION();
            }

            /*" -494- IF WIND EQUAL 99 */

            if (WIND == 99)
            {

                /*" -495- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -495- END-IF. */
            }


        }

        [StopWatch]
        /*" R0250-00-APURAR-INDICE-DB-OPEN-1 */
        public void R0250_00_APURAR_INDICE_DB_OPEN_1()
        {
            /*" -448- EXEC SQL OPEN CURS02 END-EXEC. */

            CURS02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-FETCH-COTACAO-SECTION */
        private void R0260_00_FETCH_COTACAO_SECTION()
        {
            /*" -506- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WABEND.WNR_EXEC_SQL);

            /*" -510- PERFORM R0260_00_FETCH_COTACAO_DB_FETCH_1 */

            R0260_00_FETCH_COTACAO_DB_FETCH_1();

            /*" -513- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -514- CONTINUE */

                /*" -515- ELSE */
            }
            else
            {


                /*" -516- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -517- MOVE 'FIM' TO WFIM-CURS02 */
                    _.Move("FIM", WFIM_CURS02);

                    /*" -518- ELSE */
                }
                else
                {


                    /*" -519- DISPLAY 'ERRO FETCH CURS02 ' */
                    _.Display($"ERRO FETCH CURS02 ");

                    /*" -520- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -521- END-IF */
                }


                /*" -521- END-IF. */
            }


        }

        [StopWatch]
        /*" R0260-00-FETCH-COTACAO-DB-FETCH-1 */
        public void R0260_00_FETCH_COTACAO_DB_FETCH_1()
        {
            /*" -510- EXEC SQL FETCH CURS02 INTO :MOEDACOT-DATA-INIVIGENCIA ,:MOEDACOT-VAL-VENDA END-EXEC. */

            if (CURS02.Fetch())
            {
                _.Move(CURS02.MOEDACOT_DATA_INIVIGENCIA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA);
                _.Move(CURS02.MOEDACOT_VAL_VENDA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-CARREGA-COTACAO-SECTION */
        private void R0270_CARREGA_COTACAO_SECTION()
        {
            /*" -530- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", WABEND.WNR_EXEC_SQL);

            /*" -534- ADD 1 TO WIND */
            WIND.Value = WIND + 1;

            /*" -535- IF WIND GREATER 12 */

            if (WIND > 12)
            {

                /*" -536- DISPLAY 'ESTOUROU TABELA INDICE IGPM' */
                _.Display($"ESTOUROU TABELA INDICE IGPM");

                /*" -537- MOVE 99 TO WIND */
                _.Move(99, WIND);

                /*" -538- MOVE 'FIM' TO WFIM-CURS02 */
                _.Move("FIM", WFIM_CURS02);

                /*" -539- GO TO R0270-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/ //GOTO
                return;

                /*" -541- END-IF. */
            }


            /*" -544- MOVE MOEDACOT-DATA-INIVIGENCIA TO TB-IGPM-DATA (WIND) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_DATA);

            /*" -546- IF MOEDACOT-VAL-VENDA LESS ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA < 00)
            {

                /*" -548- MOVE ZEROS TO TB-IGPM-VALOR (WIND) TB-IGPM-ACUM-MES (WIND) */
                _.Move(0, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES);

                /*" -549- GO TO R0270-01-LER-OUTRO */

                R0270_01_LER_OUTRO(); //GOTO
                return;

                /*" -551- END-IF. */
            }


            /*" -553- MOVE MOEDACOT-VAL-VENDA TO TB-IGPM-VALOR (WIND) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR);

            /*" -557- COMPUTE W-IGPM-ACUM = (((MOEDACOT-VAL-VENDA / 100 + 1) * (W-IGPM-ACUM / 100 + 1) - 1 ) * 100 ). */
            ACUMULADORES.W_IGPM_ACUM.Value = (((MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA / 100f + 1) * (ACUMULADORES.W_IGPM_ACUM / 100f + 1) - 1) * 100);

            /*" -557- MOVE W-IGPM-ACUM TO TB-IGPM-ACUM-MES (WIND). */
            _.Move(ACUMULADORES.W_IGPM_ACUM, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES);

            /*" -0- FLUXCONTROL_PERFORM R0270_01_LER_OUTRO */

            R0270_01_LER_OUTRO();

        }

        [StopWatch]
        /*" R0270-01-LER-OUTRO */
        private void R0270_01_LER_OUTRO(bool isPerform = false)
        {
            /*" -560- PERFORM R0260-00-FETCH-COTACAO. */

            R0260_00_FETCH_COTACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-OPEN-CURS01-SECTION */
        private void R0300_00_OPEN_CURS01_SECTION()
        {
            /*" -570- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -570- PERFORM R0300_00_OPEN_CURS01_DB_OPEN_1 */

            R0300_00_OPEN_CURS01_DB_OPEN_1();

            /*" -573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -574- DISPLAY 'ERRO OPEN CURSOR CURS01 ' */
                _.Display($"ERRO OPEN CURSOR CURS01 ");

                /*" -575- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -575- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-OPEN-CURS01-DB-OPEN-1 */
        public void R0300_00_OPEN_CURS01_DB_OPEN_1()
        {
            /*" -570- EXEC SQL OPEN CURS01 END-EXEC. */

            CURS01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-SECTION */
        private void R0400_00_FETCH_CURS01_SECTION()
        {
            /*" -585- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -601- PERFORM R0400_00_FETCH_CURS01_DB_FETCH_1 */

            R0400_00_FETCH_CURS01_DB_FETCH_1();

            /*" -604- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -605- CONTINUE */

                /*" -606- ELSE */
            }
            else
            {


                /*" -607- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -608- MOVE 'SIM' TO WFIM-CURS01 */
                    _.Move("SIM", WFIM_CURS01);

                    /*" -608- PERFORM R0400_00_FETCH_CURS01_DB_CLOSE_1 */

                    R0400_00_FETCH_CURS01_DB_CLOSE_1();

                    /*" -610- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -611- ELSE */
                }
                else
                {


                    /*" -612- DISPLAY 'ERRO FETCH CURS01 ' */
                    _.Display($"ERRO FETCH CURS01 ");

                    /*" -613- DISPLAY 'CERTIFICADO......' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -614- DISPLAY 'NUM APOLICE......' PROPOVA-NUM-APOLICE */
                    _.Display($"NUM APOLICE......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -615- DISPLAY 'COD SUBGRUPO.....' PROPOVA-COD-SUBGRUPO */
                    _.Display($"COD SUBGRUPO.....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                    /*" -616- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -617- END-IF */
                }


                /*" -619- END-IF. */
            }


            /*" -622- ADD 1 TO AC-LIDOS AC-CONTA. */
            ACUMULADORES.AC_LIDOS.Value = ACUMULADORES.AC_LIDOS + 1;
            ACUMULADORES.AC_CONTA.Value = ACUMULADORES.AC_CONTA + 1;

            /*" -623- IF AC-CONTA GREATER 999 */

            if (ACUMULADORES.AC_CONTA > 999)
            {

                /*" -624- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -625- MOVE ZEROS TO AC-CONTA */
                _.Move(0, ACUMULADORES.AC_CONTA);

                /*" -628- DISPLAY 'LIDOS PROPOVA ..... ' AC-LIDOS ' ' WS-TIME ' ' PROPOVA-NUM-CERTIFICADO */

                $"LIDOS PROPOVA ..... {ACUMULADORES.AC_LIDOS} {WS_TIME} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -628- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-DB-FETCH-1 */
        public void R0400_00_FETCH_CURS01_DB_FETCH_1()
        {
            /*" -601- EXEC SQL FETCH CURS01 INTO :PROPOVA-NUM-APOLICE ,:PROPOVA-COD-SUBGRUPO ,:PROPOVA-NUM-CERTIFICADO ,:PROPOVA-COD-CLIENTE ,:PROPOVA-OCOREND ,:PROPOVA-COD-FONTE ,:PROPOVA-AGE-COBRANCA ,:PROPOVA-OCORR-HISTORICO ,:PROPOVA-DATA-QUITACAO ,:PROPOVA-DATA-VENCIMENTO ,:PROPOVA-DTPROXVEN ,:PROPOVA-NUM-PARCELA ,:PROPOVA-COD-PRODUTO ,:PROPOVA-NUM-PROPOSTA ,:PROPOVA-STA-MUDANCA-PLANO:VIND-STAMDPLAN END-EXEC. */

            if (CURS01.Fetch())
            {
                _.Move(CURS01.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CURS01.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CURS01.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CURS01.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CURS01.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(CURS01.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(CURS01.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(CURS01.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CURS01.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CURS01.PROPOVA_DATA_VENCIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);
                _.Move(CURS01.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CURS01.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CURS01.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CURS01.PROPOVA_NUM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PROPOSTA);
                _.Move(CURS01.PROPOVA_STA_MUDANCA_PLANO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO);
                _.Move(CURS01.VIND_STAMDPLAN, WIND_NULOS.VIND_STAMDPLAN);
            }

        }

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-DB-CLOSE-1 */
        public void R0400_00_FETCH_CURS01_DB_CLOSE_1()
        {
            /*" -608- EXEC SQL CLOSE CURS01 END-EXEC */

            CURS01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CURS01-SECTION */
        private void R1000_00_PROCESSA_CURS01_SECTION()
        {
            /*" -638- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -639- IF VIND-STAMDPLAN LESS +0 */

            if (WIND_NULOS.VIND_STAMDPLAN < +0)
            {

                /*" -640- MOVE SPACES TO PROPOVA-STA-MUDANCA-PLANO */
                _.Move("", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO);

                /*" -644- END-IF. */
            }


            /*" -645- PERFORM R2000-00-CALC-CORRECAO-IGPM */

            R2000_00_CALC_CORRECAO_IGPM_SECTION();

            /*" -646- PERFORM R2100-00-ATUALIZA-HISCOBPR */

            R2100_00_ATUALIZA_HISCOBPR_SECTION();

            /*" -655- PERFORM R2400-00-ATUALIZA-PROPOVA */

            R2400_00_ATUALIZA_PROPOVA_SECTION();

            /*" -657- IF PROPOVA-STA-MUDANCA-PLANO EQUAL 'N' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO == "N")
            {

                /*" -658- ADD 1 TO AC-NAO-MIGRA */
                ACUMULADORES.AC_NAO_MIGRA.Value = ACUMULADORES.AC_NAO_MIGRA + 1;

                /*" -659- ELSE */
            }
            else
            {


                /*" -660- PERFORM R4000-00-MIGRAR-PARA-MENSAL */

                R4000_00_MIGRAR_PARA_MENSAL_SECTION();

                /*" -661- PERFORM R2600-00-ATUALIZA-PRODUTOS-VG */

                R2600_00_ATUALIZA_PRODUTOS_VG_SECTION();

                /*" -662- ADD 1 TO AC-MIGRADOS */
                ACUMULADORES.AC_MIGRADOS.Value = ACUMULADORES.AC_MIGRADOS + 1;

                /*" -666- END-IF. */
            }


            /*" -668- PERFORM R8400-00-GRAVA-RELATORIOS */

            R8400_00_GRAVA_RELATORIOS_SECTION();

            /*" -669- ADD 1 TO AC-PROC */
            ACUMULADORES.AC_PROC.Value = ACUMULADORES.AC_PROC + 1;

            /*" -669- PERFORM R0400-00-FETCH-CURS01. */

            R0400_00_FETCH_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CALC-CORRECAO-IGPM-SECTION */
        private void R2000_00_CALC_CORRECAO_IGPM_SECTION()
        {
            /*" -681- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -684- PERFORM R8000-00-SELECT-HISCOBPR. */

            R8000_00_SELECT_HISCOBPR_SECTION();

            /*" -688- PERFORM R8100-00-SELECT-OPCPAGVI. */

            R8100_00_SELECT_OPCPAGVI_SECTION();

            /*" -691- IF W-IND-CORR EQUAL 'NAO' */

            if (W_IND_CORR == "NAO")
            {

                /*" -692- PERFORM R2200-00-ATUALIZ-VAL-CORR */

                R2200_00_ATUALIZ_VAL_CORR_SECTION();

                /*" -693- GO TO R2000-10-FIM-CORRECAO */

                R2000_10_FIM_CORRECAO(); //GOTO
                return;

                /*" -695- END-IF. */
            }


            /*" -701- COMPUTE W-IMPSEGUR-CORR ROUNDED = HISCOBPR-IMPSEGUR * W-IGPM-ACUM . */
            VALORES_CORRIGIDOS.W_IMPSEGUR_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR * ACUMULADORES.W_IGPM_ACUM;

            /*" -702- IF W-IMPSEGUR-CORR NOT GREATER HISCOBPR-IMPSEGUR */

            if (VALORES_CORRIGIDOS.W_IMPSEGUR_CORR <= HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR)
            {

                /*" -703- PERFORM R2200-00-ATUALIZ-VAL-CORR */

                R2200_00_ATUALIZ_VAL_CORR_SECTION();

                /*" -704- GO TO R2000-10-FIM-CORRECAO */

                R2000_10_FIM_CORRECAO(); //GOTO
                return;

                /*" -707- END-IF. */
            }


            /*" -711- COMPUTE W-IMPSEGIND-CORR ROUNDED = HISCOBPR-IMPSEGIND * W-IGPM-ACUM. */
            VALORES_CORRIGIDOS.W_IMPSEGIND_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND * ACUMULADORES.W_IGPM_ACUM;

            /*" -712- IF HISCOBPR-IMP-MORNATU EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00)
            {

                /*" -713- MOVE ZEROS TO W-IMPMORNATU-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPMORNATU_CORR);

                /*" -714- ELSE */
            }
            else
            {


                /*" -716- COMPUTE W-IMPMORNATU-CORR ROUNDED = HISCOBPR-IMP-MORNATU * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPMORNATU_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU * ACUMULADORES.W_IGPM_ACUM;

                /*" -719- END-IF. */
            }


            /*" -720- IF HISCOBPR-IMPMORACID EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID == 00)
            {

                /*" -721- MOVE ZEROS TO W-IMPMORACID-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPMORACID_CORR);

                /*" -722- ELSE */
            }
            else
            {


                /*" -724- COMPUTE W-IMPMORACID-CORR ROUNDED = HISCOBPR-IMPMORACID * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPMORACID_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID * ACUMULADORES.W_IGPM_ACUM;

                /*" -727- END-IF. */
            }


            /*" -728- IF HISCOBPR-IMPINVPERM EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM == 00)
            {

                /*" -729- MOVE ZEROS TO W-IMPINVPERM-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPINVPERM_CORR);

                /*" -730- ELSE */
            }
            else
            {


                /*" -732- COMPUTE W-IMPINVPERM-CORR ROUNDED = HISCOBPR-IMPINVPERM * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPINVPERM_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM * ACUMULADORES.W_IGPM_ACUM;

                /*" -735- END-IF. */
            }


            /*" -736- IF HISCOBPR-IMPAMDS EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS == 00)
            {

                /*" -737- MOVE ZEROS TO W-IMPAMDS-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPAMDS_CORR);

                /*" -738- ELSE */
            }
            else
            {


                /*" -740- COMPUTE W-IMPAMDS-CORR ROUNDED = HISCOBPR-IMPAMDS * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPAMDS_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS * ACUMULADORES.W_IGPM_ACUM;

                /*" -743- END-IF. */
            }


            /*" -744- IF HISCOBPR-IMPDH EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH == 00)
            {

                /*" -745- MOVE ZEROS TO W-IMPDH-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPDH_CORR);

                /*" -746- ELSE */
            }
            else
            {


                /*" -748- COMPUTE W-IMPDH-CORR ROUNDED = HISCOBPR-IMPDH * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPDH_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH * ACUMULADORES.W_IGPM_ACUM;

                /*" -751- END-IF. */
            }


            /*" -752- IF HISCOBPR-IMPDIT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT == 00)
            {

                /*" -753- MOVE ZEROS TO W-IMPDIT-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPDIT_CORR);

                /*" -754- ELSE */
            }
            else
            {


                /*" -756- COMPUTE W-IMPDIT-CORR ROUNDED = HISCOBPR-IMPDIT * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPDIT_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT * ACUMULADORES.W_IGPM_ACUM;

                /*" -759- END-IF. */
            }


            /*" -760- IF HISCOBPR-PRMVG EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG == 00)
            {

                /*" -761- MOVE ZEROS TO W-PRMVG-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMVG_CORR);

                /*" -762- ELSE */
            }
            else
            {


                /*" -764- COMPUTE W-PRMVG-CORR ROUNDED = HISCOBPR-PRMVG * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_PRMVG_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG * ACUMULADORES.W_IGPM_ACUM;

                /*" -767- END-IF. */
            }


            /*" -768- IF HISCOBPR-PRMAP EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP == 00)
            {

                /*" -769- MOVE ZEROS TO W-PRMAP-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMAP_CORR);

                /*" -770- ELSE */
            }
            else
            {


                /*" -772- COMPUTE W-PRMAP-CORR ROUNDED = HISCOBPR-PRMAP * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_PRMAP_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP * ACUMULADORES.W_IGPM_ACUM;

                /*" -775- END-IF. */
            }


            /*" -780- COMPUTE W-PRMTOT-CORR = W-PRMVG-CORR + W-PRMAP-CORR . */
            VALORES_CORRIGIDOS.W_PRMTOT_CORR.Value = VALORES_CORRIGIDOS.W_PRMVG_CORR + VALORES_CORRIGIDOS.W_PRMAP_CORR;

            /*" -782- IF VIND-PRMDIT LESS ZEROS OR HISCOBPR-PRMDIT EQUAL ZEROS */

            if (WIND_NULOS.VIND_PRMDIT < 00 || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT == 00)
            {

                /*" -783- MOVE ZEROS TO W-PRMDIT-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMDIT_CORR);

                /*" -784- ELSE */
            }
            else
            {


                /*" -786- COMPUTE W-PRMDIT-CORR ROUNDED = HISCOBPR-PRMDIT * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_PRMDIT_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT * ACUMULADORES.W_IGPM_ACUM;

                /*" -786- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2000_10_FIM_CORRECAO */

            R2000_10_FIM_CORRECAO();

        }

        [StopWatch]
        /*" R2000-10-FIM-CORRECAO */
        private void R2000_10_FIM_CORRECAO(bool isPerform = false)
        {
            /*" -812- PERFORM R2000_10_FIM_CORRECAO_DB_SELECT_1 */

            R2000_10_FIM_CORRECAO_DB_SELECT_1();

            /*" -815- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -816- DISPLAY 'ERRO NO CALCULO DAS DATAS DE VIGENCIAS' */
                _.Display($"ERRO NO CALCULO DAS DATAS DE VIGENCIAS");

                /*" -817- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -821- END-IF. */
            }


            /*" -822- MOVE HISCOBPR-IMP-MORNATU TO MOVIMVGA-IMP-MORNATU-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -823- MOVE W-IMPMORNATU-CORR TO MOVIMVGA-IMP-MORNATU-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORNATU_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -824- MOVE HISCOBPR-IMPMORACID TO MOVIMVGA-IMP-MORACID-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);

            /*" -825- MOVE W-IMPMORACID-CORR TO MOVIMVGA-IMP-MORACID-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORACID_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -826- MOVE HISCOBPR-IMPINVPERM TO MOVIMVGA-IMP-INVPERM-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

            /*" -827- MOVE W-IMPINVPERM-CORR TO MOVIMVGA-IMP-INVPERM-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPINVPERM_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -828- MOVE HISCOBPR-IMPAMDS TO MOVIMVGA-IMP-AMDS-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);

            /*" -829- MOVE W-IMPAMDS-CORR TO MOVIMVGA-IMP-AMDS-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPAMDS_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);

            /*" -830- MOVE HISCOBPR-IMPDH TO MOVIMVGA-IMP-DH-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

            /*" -831- MOVE W-IMPDH-CORR TO MOVIMVGA-IMP-DH-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPDH_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

            /*" -832- MOVE HISCOBPR-IMPDIT TO MOVIMVGA-IMP-DIT-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);

            /*" -833- MOVE W-IMPDIT-CORR TO MOVIMVGA-IMP-DIT-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPDIT_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);

            /*" -834- MOVE HISCOBPR-PRMVG TO MOVIMVGA-PRM-VG-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -835- MOVE W-PRMVG-CORR TO MOVIMVGA-PRM-VG-ATU */
            _.Move(VALORES_CORRIGIDOS.W_PRMVG_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -836- MOVE HISCOBPR-PRMAP TO MOVIMVGA-PRM-AP-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -836- MOVE W-PRMAP-CORR TO MOVIMVGA-PRM-AP-ATU. */
            _.Move(VALORES_CORRIGIDOS.W_PRMAP_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

        }

        [StopWatch]
        /*" R2000-10-FIM-CORRECAO-DB-SELECT-1 */
        public void R2000_10_FIM_CORRECAO_DB_SELECT_1()
        {
            /*" -812- EXEC SQL SELECT DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR ,DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR - 1 DAY ,DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR - 2 DAY ,DATE(:PROPOVA-DATA-QUITACAO) + 1 YEAR - 3 DAY INTO :WS-DTANIVERS ,:WS-DTANIVERS-1 ,:WS-DTANIVERS-2 ,:WS-DTANIVERS-3 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VE' WITH UR END-EXEC */

            var r2000_10_FIM_CORRECAO_DB_SELECT_1_Query1 = new R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1()
            {
                PROPOVA_DATA_QUITACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.ToString(),
            };

            var executed_1 = R2000_10_FIM_CORRECAO_DB_SELECT_1_Query1.Execute(r2000_10_FIM_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DTANIVERS, WS_DTANIVERS);
                _.Move(executed_1.WS_DTANIVERS_1, WS_DTANIVERS_1);
                _.Move(executed_1.WS_DTANIVERS_2, WS_DTANIVERS_2);
                _.Move(executed_1.WS_DTANIVERS_3, WS_DTANIVERS_3);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-ATUALIZA-HISCOBPR-SECTION */
        private void R2100_00_ATUALIZA_HISCOBPR_SECTION()
        {
            /*" -849- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -851- IF PROPOVA-STA-MUDANCA-PLANO EQUAL 'N' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO == "N")
            {

                /*" -852- MOVE WS-DTANIVERS-1 TO HISCOBPR-DATA-TERVIGENCIA */
                _.Move(WS_DTANIVERS_1, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

                /*" -854- ELSE */
            }
            else
            {


                /*" -855- MOVE WS-DTANIVERS-3 TO HISCOBPR-DATA-TERVIGENCIA */
                _.Move(WS_DTANIVERS_3, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

                /*" -857- END-IF. */
            }


            /*" -863- PERFORM R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1 */

            R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1();

            /*" -866- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -867- DISPLAY 'ERRO UPDATE HIS_COBER_PROPOST ' */
                _.Display($"ERRO UPDATE HIS_COBER_PROPOST ");

                /*" -868- DISPLAY 'CERTIFICADO......' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -869- DISPLAY 'OCORR_HISTORICO..' HISCOBPR-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO..{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO}");

                /*" -870- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -875- END-IF. */
            }


            /*" -877- IF PROPOVA-STA-MUDANCA-PLANO EQUAL 'N' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO == "N")
            {

                /*" -878- MOVE WS-DTANIVERS TO HISCOBPR-DATA-INIVIGENCIA */
                _.Move(WS_DTANIVERS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

                /*" -879- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
                _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

                /*" -881- ELSE */
            }
            else
            {


                /*" -882- MOVE WS-DTANIVERS-2 TO HISCOBPR-DATA-INIVIGENCIA */
                _.Move(WS_DTANIVERS_2, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

                /*" -883- MOVE WS-DTANIVERS-1 TO HISCOBPR-DATA-TERVIGENCIA */
                _.Move(WS_DTANIVERS_1, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

                /*" -885- END-IF. */
            }


            /*" -886- ADD 1 TO HISCOBPR-OCORR-HISTORICO */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO + 1;

            /*" -887- MOVE W-IMPSEGUR-CORR TO HISCOBPR-IMPSEGUR */
            _.Move(VALORES_CORRIGIDOS.W_IMPSEGUR_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

            /*" -888- MOVE W-IMPSEGIND-CORR TO HISCOBPR-IMPSEGIND */
            _.Move(VALORES_CORRIGIDOS.W_IMPSEGIND_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);

            /*" -889- MOVE 895 TO HISCOBPR-COD-OPERACAO */
            _.Move(895, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

            /*" -890- MOVE W-IMPMORNATU-CORR TO HISCOBPR-IMP-MORNATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORNATU_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -891- MOVE W-IMPMORACID-CORR TO HISCOBPR-IMPMORACID */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORACID_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -892- MOVE W-IMPINVPERM-CORR TO HISCOBPR-IMPINVPERM */
            _.Move(VALORES_CORRIGIDOS.W_IMPINVPERM_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

            /*" -893- MOVE W-IMPAMDS-CORR TO HISCOBPR-IMPAMDS */
            _.Move(VALORES_CORRIGIDOS.W_IMPAMDS_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -894- MOVE W-IMPDH-CORR TO HISCOBPR-IMPDH */
            _.Move(VALORES_CORRIGIDOS.W_IMPDH_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -895- MOVE W-IMPDIT-CORR TO HISCOBPR-IMPDIT */
            _.Move(VALORES_CORRIGIDOS.W_IMPDIT_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -896- MOVE W-PRMTOT-CORR TO HISCOBPR-VLPREMIO */
            _.Move(VALORES_CORRIGIDOS.W_PRMTOT_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);

            /*" -897- MOVE W-PRMVG-CORR TO HISCOBPR-PRMVG */
            _.Move(VALORES_CORRIGIDOS.W_PRMVG_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

            /*" -898- MOVE W-PRMAP-CORR TO HISCOBPR-PRMAP */
            _.Move(VALORES_CORRIGIDOS.W_PRMAP_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

            /*" -899- MOVE W-PRMDIT-CORR TO HISCOBPR-PRMDIT */
            _.Move(VALORES_CORRIGIDOS.W_PRMDIT_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);

            /*" -899- PERFORM R8300-00-INSERT-HISCOBPR. */

            R8300_00_INSERT_HISCOBPR_SECTION();

        }

        [StopWatch]
        /*" R2100-00-ATUALIZA-HISCOBPR-DB-UPDATE-1 */
        public void R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1()
        {
            /*" -863- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = :HISCOBPR-DATA-TERVIGENCIA ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO END-EXEC */

            var r2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1 = new R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1()
            {
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1.Execute(r2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-ATUALIZ-VAL-CORR-SECTION */
        private void R2200_00_ATUALIZ_VAL_CORR_SECTION()
        {
            /*" -909- MOVE HISCOBPR-IMPSEGUR TO W-IMPSEGUR-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, VALORES_CORRIGIDOS.W_IMPSEGUR_CORR);

            /*" -910- MOVE HISCOBPR-IMPSEGIND TO W-IMPSEGIND-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, VALORES_CORRIGIDOS.W_IMPSEGIND_CORR);

            /*" -911- MOVE HISCOBPR-IMP-MORNATU TO W-IMPMORNATU-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, VALORES_CORRIGIDOS.W_IMPMORNATU_CORR);

            /*" -912- MOVE HISCOBPR-IMPMORACID TO W-IMPMORACID-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, VALORES_CORRIGIDOS.W_IMPMORACID_CORR);

            /*" -913- MOVE HISCOBPR-IMPINVPERM TO W-IMPINVPERM-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, VALORES_CORRIGIDOS.W_IMPINVPERM_CORR);

            /*" -914- MOVE HISCOBPR-IMPAMDS TO W-IMPAMDS-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, VALORES_CORRIGIDOS.W_IMPAMDS_CORR);

            /*" -915- MOVE HISCOBPR-IMPDH TO W-IMPDH-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, VALORES_CORRIGIDOS.W_IMPDH_CORR);

            /*" -916- MOVE HISCOBPR-IMPDIT TO W-IMPDIT-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, VALORES_CORRIGIDOS.W_IMPDIT_CORR);

            /*" -917- MOVE HISCOBPR-VLPREMIO TO W-PRMTOT-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, VALORES_CORRIGIDOS.W_PRMTOT_CORR);

            /*" -918- MOVE HISCOBPR-PRMVG TO W-PRMVG-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, VALORES_CORRIGIDOS.W_PRMVG_CORR);

            /*" -920- MOVE HISCOBPR-PRMAP TO W-PRMAP-CORR. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, VALORES_CORRIGIDOS.W_PRMAP_CORR);

            /*" -921- IF VIND-PRMDIT LESS ZEROS */

            if (WIND_NULOS.VIND_PRMDIT < 00)
            {

                /*" -922- MOVE ZEROS TO W-PRMDIT-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMDIT_CORR);

                /*" -923- ELSE */
            }
            else
            {


                /*" -924- MOVE HISCOBPR-PRMDIT TO W-PRMDIT-CORR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT, VALORES_CORRIGIDOS.W_PRMDIT_CORR);

                /*" -924- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-ATUALIZA-PROPOVA-SECTION */
        private void R2400_00_ATUALIZA_PROPOVA_SECTION()
        {
            /*" -937- MOVE 895 TO PROPOVA-COD-OPERACAO */
            _.Move(895, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO);

            /*" -947- PERFORM R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1 */

            R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1();

            /*" -950- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -951- DISPLAY 'ERRO UPDATE PROPOSTAS_VA ' */
                _.Display($"ERRO UPDATE PROPOSTAS_VA ");

                /*" -952- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -953- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -953- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-ATUALIZA-PROPOVA-DB-UPDATE-1 */
        public void R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1()
        {
            /*" -947- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_OPERACAO = :PROPOVA-COD-OPERACAO ,DATA_MOVIMENTO = :WS-DTANIVERS ,OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO ,SIT_INTERFACE = '0' ,TIMESTAMP = CURRENT TIMESTAMP ,COD_USUARIO = 'VE0123B' ,STA_ANTECIPACAO = 'N' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1 = new R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_COD_OPERACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO.ToString(),
                WS_DTANIVERS = WS_DTANIVERS.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1.Execute(r2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERE-MOVIMVGA-SECTION */
        private void R2500_00_INSERE_MOVIMVGA_SECTION()
        {
            /*" -964- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -969- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO W-DIG-CTA-NUM. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, W_DIG_CTA_NUM);

            /*" -974- PERFORM R2500_00_INSERE_MOVIMVGA_DB_SELECT_1 */

            R2500_00_INSERE_MOVIMVGA_DB_SELECT_1();

            /*" -977- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -978- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -979- DISPLAY 'COD FONTE NAO CADASTRADO' */
                    _.Display($"COD FONTE NAO CADASTRADO");

                    /*" -980- ELSE */
                }
                else
                {


                    /*" -981- DISPLAY 'ERRO SELECT FONTES' */
                    _.Display($"ERRO SELECT FONTES");

                    /*" -983- END-IF */
                }


                /*" -984- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -985- DISPLAY 'COD FONTE   = ' PROPOVA-COD-FONTE */
                _.Display($"COD FONTE   = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE}");

                /*" -986- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -990- END-IF. */
            }


            /*" -1067- PERFORM R2500_00_INSERE_MOVIMVGA_DB_INSERT_1 */

            R2500_00_INSERE_MOVIMVGA_DB_INSERT_1();

            /*" -1070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1071- DISPLAY 'ERRO INSERT MOVIMENTO_VGAP ' */
                _.Display($"ERRO INSERT MOVIMENTO_VGAP ");

                /*" -1072- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1073- DISPLAY 'APOLICE     = ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1074- DISPLAY 'SUBGRUPO    = ' PROPOVA-COD-SUBGRUPO */
                _.Display($"SUBGRUPO    = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1075- DISPLAY 'FONTE       = ' PROPOVA-COD-FONTE */
                _.Display($"FONTE       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE}");

                /*" -1076- DISPLAY 'PROPOSTA    = ' WS-NUM-PROPOSTA-AUT */
                _.Display($"PROPOSTA    = {WS_NUM_PROPOSTA_AUT}");

                /*" -1077- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1081- END-IF. */
            }


            /*" -1085- PERFORM R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1 */

            R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1();

            /*" -1088- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1089- DISPLAY 'ERRO UPDATE FONTES' */
                _.Display($"ERRO UPDATE FONTES");

                /*" -1090- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1091- DISPLAY 'COD FONTE   = ' PROPOVA-COD-FONTE */
                _.Display($"COD FONTE   = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE}");

                /*" -1092- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1092- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-INSERE-MOVIMVGA-DB-SELECT-1 */
        public void R2500_00_INSERE_MOVIMVGA_DB_SELECT_1()
        {
            /*" -974- EXEC SQL SELECT ULT_PROP_AUTOMAT + 1 INTO :WS-NUM-PROPOSTA-AUT FROM SEGUROS.FONTES WHERE COD_FONTE = :PROPOVA-COD-FONTE END-EXEC. */

            var r2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1 = new R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
            };

            var executed_1 = R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1.Execute(r2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PROPOSTA_AUT, WS_NUM_PROPOSTA_AUT);
            }


        }

        [StopWatch]
        /*" R2500-00-INSERE-MOVIMVGA-DB-INSERT-1 */
        public void R2500_00_INSERE_MOVIMVGA_DB_INSERT_1()
        {
            /*" -1067- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP VALUES ( :PROPOVA-NUM-APOLICE ,:PROPOVA-COD-SUBGRUPO ,:PROPOVA-COD-FONTE ,:WS-NUM-PROPOSTA-AUT , '1' ,:PROPOVA-NUM-CERTIFICADO , ' ' , '4' ,:PROPOVA-COD-CLIENTE , 0 , 0 , 0 , 0 , 0 , 'S' , 'S' ,:OPCPAGVI-PERI-PAGAMENTO , 12 , ' ' , ' ' , ' ' , 0 , ' ' ,:PROPOVA-OCOREND ,:PROPOVA-OCOREND , 104 ,:PROPOVA-AGE-COBRANCA , ' ' , 0 ,:OPCPAGVI-NUM-CONTA-DEBITO ,:W-DIG-CONTA , 0 , ' ' , '1' , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,:MOVIMVGA-IMP-MORNATU-ANT ,:MOVIMVGA-IMP-MORNATU-ATU ,:MOVIMVGA-IMP-MORACID-ANT ,:MOVIMVGA-IMP-MORACID-ATU ,:MOVIMVGA-IMP-INVPERM-ANT ,:MOVIMVGA-IMP-INVPERM-ATU ,:MOVIMVGA-IMP-AMDS-ANT ,:MOVIMVGA-IMP-AMDS-ATU ,:MOVIMVGA-IMP-DH-ANT ,:MOVIMVGA-IMP-DH-ATU ,:MOVIMVGA-IMP-DIT-ANT ,:MOVIMVGA-IMP-DIT-ATU ,:MOVIMVGA-PRM-VG-ANT ,:MOVIMVGA-PRM-VG-ATU ,:MOVIMVGA-PRM-AP-ANT ,:MOVIMVGA-PRM-AP-ATU , 895 ,:SISTEMAS-DTMOV-ABERTO , 0 , '1' , 'VE0123B' ,:SISTEMAS-DTMOV-ABERTO , NULL , NULL , NULL , NULL , NULL ,:WS-DTANIVERS , NULL , ' ' ) END-EXEC. */

            var r2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1 = new R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
                WS_NUM_PROPOSTA_AUT = WS_NUM_PROPOSTA_AUT.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                OPCPAGVI_PERI_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
                PROPOVA_AGE_COBRANCA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                W_DIG_CONTA = W_DIG_CONTA.ToString(),
                MOVIMVGA_IMP_MORNATU_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT.ToString(),
                MOVIMVGA_IMP_MORNATU_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.ToString(),
                MOVIMVGA_IMP_MORACID_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT.ToString(),
                MOVIMVGA_IMP_MORACID_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.ToString(),
                MOVIMVGA_IMP_INVPERM_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT.ToString(),
                MOVIMVGA_IMP_INVPERM_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.ToString(),
                MOVIMVGA_IMP_AMDS_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT.ToString(),
                MOVIMVGA_IMP_AMDS_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU.ToString(),
                MOVIMVGA_IMP_DH_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT.ToString(),
                MOVIMVGA_IMP_DH_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU.ToString(),
                MOVIMVGA_IMP_DIT_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT.ToString(),
                MOVIMVGA_IMP_DIT_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU.ToString(),
                MOVIMVGA_PRM_VG_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT.ToString(),
                MOVIMVGA_PRM_VG_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.ToString(),
                MOVIMVGA_PRM_AP_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT.ToString(),
                MOVIMVGA_PRM_AP_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.ToString(),
                SISTEMAS_DTMOV_ABERTO = SISTEMAS_DTMOV_ABERTO.ToString(),
                WS_DTANIVERS = WS_DTANIVERS.ToString(),
            };

            R2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1.Execute(r2500_00_INSERE_MOVIMVGA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2500-00-INSERE-MOVIMVGA-DB-UPDATE-1 */
        public void R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1()
        {
            /*" -1085- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :WS-NUM-PROPOSTA-AUT WHERE COD_FONTE = :PROPOVA-COD-FONTE END-EXEC. */

            var r2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1 = new R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1()
            {
                WS_NUM_PROPOSTA_AUT = WS_NUM_PROPOSTA_AUT.ToString(),
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
            };

            R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1.Execute(r2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-ATUALIZA-PRODUTOS-VG-SECTION */
        private void R2600_00_ATUALIZA_PRODUTOS_VG_SECTION()
        {
            /*" -1109- PERFORM R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1 */

            R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1();

            /*" -1112- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1113- DISPLAY 'ERRO UPDATE PRODUTOS_VG ' */
                _.Display($"ERRO UPDATE PRODUTOS_VG ");

                /*" -1115- DISPLAY 'APOLICE = ' PROPOVA-NUM-APOLICE ' SUBGRUPO = ' PROPOVA-COD-SUBGRUPO */

                $"APOLICE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} SUBGRUPO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}"
                .Display();

                /*" -1116- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1117- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-ATUALIZA-PRODUTOS-VG-DB-UPDATE-1 */
        public void R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1()
        {
            /*" -1109- EXEC SQL UPDATE SEGUROS.PRODUTOS_VG SET COD_PRODUTO = :PROPOVA-COD-PRODUTO , PERI_PAGAMENTO = 1 WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1 = new R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1()
            {
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1.Execute(r2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-MIGRAR-PARA-MENSAL-SECTION */
        private void R4000_00_MIGRAR_PARA_MENSAL_SECTION()
        {
            /*" -1129- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -1130- MOVE 1 TO SUBGVGAP-PERI-FATURAMENTO */
            _.Move(1, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);

            /*" -1131- MOVE WS-DTANIVERS TO SUBGVGAP-DATA-INIVIGENCIA */
            _.Move(WS_DTANIVERS, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA);

            /*" -1133- MOVE '9999-12-31' TO SUBGVGAP-DATA-TERVIGENCIA */
            _.Move("9999-12-31", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA);

            /*" -1140- PERFORM R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1 */

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1();

            /*" -1143- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1144- DISPLAY 'ERRO UPDATE SUBGRUPOS_VGAP ' */
                _.Display($"ERRO UPDATE SUBGRUPOS_VGAP ");

                /*" -1145- DISPLAY 'APOLICE      = ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE      = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1146- DISPLAY 'SUBGRUPO     = ' PROPOVA-COD-SUBGRUPO */
                _.Display($"SUBGRUPO     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1147- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1148- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1152- END-IF. */
            }


            /*" -1154- MOVE WS-DTANIVERS-2 TO OPCPAGVI-DATA-INIVIGENCIA */
            _.Move(WS_DTANIVERS_2, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);

            /*" -1155- MOVE '9998-12-31' TO OPCPAGVI-DATA-TERVIGENCIA */
            _.Move("9998-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -1156- MOVE 1 TO OPCPAGVI-PERI-PAGAMENTO */
            _.Move(1, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);

            /*" -1157- MOVE 'VE0123B' TO OPCPAGVI-COD-USUARIO */
            _.Move("VE0123B", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_USUARIO);

            /*" -1161- PERFORM R8200-00-INSERT-OPCPAGVI. */

            R8200_00_INSERT_OPCPAGVI_SECTION();

            /*" -1162- MOVE '4000-A' TO WNR-EXEC-SQL. */
            _.Move("4000-A", WABEND.WNR_EXEC_SQL);

            /*" -1164- DISPLAY '*** CER/TERVIGENCIA: ' PROPOVA-NUM-CERTIFICADO '/' WS-DTANIVERS-3 */

            $"*** CER/TERVIGENCIA: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{WS_DTANIVERS_3}"
            .Display();

            /*" -1171- PERFORM R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2 */

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2();

            /*" -1174- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1175- DISPLAY 'ERRO UPDATE OPCAO_PAG_VIDAZUL ' */
                _.Display($"ERRO UPDATE OPCAO_PAG_VIDAZUL ");

                /*" -1176- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1177- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1181- END-IF. */
            }


            /*" -1183- MOVE '4000-B' TO WNR-EXEC-SQL. */
            _.Move("4000-B", WABEND.WNR_EXEC_SQL);

            /*" -1188- PERFORM R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3 */

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3();

            /*" -1191- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1192- DISPLAY 'ERRO UPDATE OPCAO_PAG_VIDAZUL ' */
                _.Display($"ERRO UPDATE OPCAO_PAG_VIDAZUL ");

                /*" -1193- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1194- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1198- END-IF. */
            }


            /*" -1199- MOVE '4000-C' TO WNR-EXEC-SQL. */
            _.Move("4000-C", WABEND.WNR_EXEC_SQL);

            /*" -1202- PERFORM R8000-00-SELECT-HISCOBPR */

            R8000_00_SELECT_HISCOBPR_SECTION();

            /*" -1203- ADD 1 TO HISCOBPR-OCORR-HISTORICO */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO + 1;

            /*" -1204- MOVE 202 TO HISCOBPR-COD-OPERACAO */
            _.Move(202, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

            /*" -1205- MOVE WS-DTANIVERS TO HISCOBPR-DATA-INIVIGENCIA */
            _.Move(WS_DTANIVERS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -1210- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1211- IF HISCOBPR-PRMDIT GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT > 00)
            {

                /*" -1213- COMPUTE HISCOBPR-PRMDIT ROUNDED = HISCOBPR-PRMDIT / 12 */
                HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT / 12f;

                /*" -1216- END-IF */
            }


            /*" -1220- COMPUTE HISCOBPR-VLPREMIO ROUNDED = HISCOBPR-VLPREMIO / 12 */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO / 12f;

            /*" -1225- COMPUTE HISCOBPR-PRMVG ROUNDED = HISCOBPR-PRMVG / 12 */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG / 12f;

            /*" -1228- COMPUTE HISCOBPR-PRMAP = HISCOBPR-VLPREMIO - HISCOBPR-PRMVG */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO - HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG;

            /*" -1232- PERFORM R8300-00-INSERT-HISCOBPR. */

            R8300_00_INSERT_HISCOBPR_SECTION();

            /*" -1234- MOVE '4000-D' TO WNR-EXEC-SQL. */
            _.Move("4000-D", WABEND.WNR_EXEC_SQL);

            /*" -1248- MOVE 202 TO PROPOVA-COD-OPERACAO */
            _.Move(202, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO);

            /*" -1253- PERFORM R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1 */

            R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1();

            /*" -1256- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1257- DISPLAY 'ERRO SELECT PROPOSTAS_VA' */
                _.Display($"ERRO SELECT PROPOSTAS_VA");

                /*" -1258- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1259- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1261- END-IF. */
            }


            /*" -1263- IF PROPOVA-COD-PRODUTO EQUAL 9343 OR JVPRD9343 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9343", JVBKINCL.JV_PRODUTOS.JVPRD9343.ToString()))
            {

                /*" -1264- IF WS-PROPOVA-DATA-QUITACAO >= LK-GEJVW002-JV-DTA-INI */

                if (WS_PROPOVA_DATA_QUITACAO >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
                {

                    /*" -1265- MOVE JVPRD9329 TO PROPOVA-COD-PRODUTO */
                    _.Move(JVBKINCL.JV_PRODUTOS.JVPRD9329, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                    /*" -1266- ELSE */
                }
                else
                {


                    /*" -1267- MOVE 9329 TO PROPOVA-COD-PRODUTO */
                    _.Move(9329, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                    /*" -1268- END-IF */
                }


                /*" -1270- END-IF. */
            }


            /*" -1272- IF PROPOVA-COD-PRODUTO EQUAL 8209 OR JVPRD8209 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("8209", JVBKINCL.JV_PRODUTOS.JVPRD8209.ToString()))
            {

                /*" -1273- IF WS-PROPOVA-DATA-QUITACAO >= LK-GEJVW002-JV-DTA-INI */

                if (WS_PROPOVA_DATA_QUITACAO >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
                {

                    /*" -1274- MOVE JVPRD8205 TO PROPOVA-COD-PRODUTO */
                    _.Move(JVBKINCL.JV_PRODUTOS.JVPRD8205, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                    /*" -1275- ELSE */
                }
                else
                {


                    /*" -1276- MOVE 8205 TO PROPOVA-COD-PRODUTO */
                    _.Move(8205, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                    /*" -1277- END-IF */
                }


                /*" -1283- END-IF. */
            }


            /*" -1290- PERFORM R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4 */

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4();

            /*" -1293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1294- DISPLAY 'ERRO UPDATE PROPOSTAS_VA ' */
                _.Display($"ERRO UPDATE PROPOSTAS_VA ");

                /*" -1295- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1296- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1296- END-IF. */
            }


        }

        [StopWatch]
        /*" R4000-00-MIGRAR-PARA-MENSAL-DB-UPDATE-1 */
        public void R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1()
        {
            /*" -1140- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET PERI_FATURAMENTO = :SUBGVGAP-PERI-FATURAMENTO ,DATA_INIVIGENCIA = :SUBGVGAP-DATA-INIVIGENCIA ,DATA_TERVIGENCIA = :SUBGVGAP-DATA-TERVIGENCIA WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1 = new R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                SUBGVGAP_DATA_INIVIGENCIA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA.ToString(),
                SUBGVGAP_DATA_TERVIGENCIA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1.Execute(r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-MIGRAR-PARA-MENSAL-DB-UPDATE-2 */
        public void R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2()
        {
            /*" -1171- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET DATA_TERVIGENCIA = :WS-DTANIVERS-3 ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1 = new R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1()
            {
                WS_DTANIVERS_3 = WS_DTANIVERS_3.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1.Execute(r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R4000-00-MIGRAR-PARA-MENSAL-DB-SELECT-1 */
        public void R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1()
        {
            /*" -1253- EXEC SQL SELECT DATA_QUITACAO INTO :WS-PROPOVA-DATA-QUITACAO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1 = new R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1.Execute(r4000_00_MIGRAR_PARA_MENSAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_PROPOVA_DATA_QUITACAO, WS_PROPOVA_DATA_QUITACAO);
            }


        }

        [StopWatch]
        /*" R8000-00-SELECT-HISCOBPR-SECTION */
        private void R8000_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1313- PERFORM R8000_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R8000_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1316- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1317- DISPLAY 'ERRO SELECT MAX HIS_COBER_PROPOST' */
                _.Display($"ERRO SELECT MAX HIS_COBER_PROPOST");

                /*" -1318- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1319- DISPLAY 'NUM APOLICE  = ' PROPOVA-NUM-APOLICE */
                _.Display($"NUM APOLICE  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1320- DISPLAY 'COD SUBGRUPO = ' PROPOVA-COD-SUBGRUPO */
                _.Display($"COD SUBGRUPO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1321- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1325- END-IF. */
            }


            /*" -1388- PERFORM R8000_00_SELECT_HISCOBPR_DB_SELECT_2 */

            R8000_00_SELECT_HISCOBPR_DB_SELECT_2();

            /*" -1391- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- DISPLAY 'ERRO SELECT HIS_COBER_PROPOST' */
                _.Display($"ERRO SELECT HIS_COBER_PROPOST");

                /*" -1393- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1394- DISPLAY 'NUM OCORR    = ' HISCOBPR-OCORR-HISTORICO */
                _.Display($"NUM OCORR    = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO}");

                /*" -1395- DISPLAY 'NUM APOLICE  = ' PROPOVA-NUM-APOLICE */
                _.Display($"NUM APOLICE  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1396- DISPLAY 'COD SUBGRUPO = ' PROPOVA-COD-SUBGRUPO */
                _.Display($"COD SUBGRUPO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -1397- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1397- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R8000_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1313- EXEC SQL SELECT MAX(OCORR_HISTORICO) INTO :HISCOBPR-OCORR-HISTORICO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R4000-00-MIGRAR-PARA-MENSAL-DB-UPDATE-3 */
        public void R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3()
        {
            /*" -1188- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET DATA_TERVIGENCIA = '9999-12-31' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9998-12-31' END-EXEC. */

            var r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1 = new R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1.Execute(r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R8000-00-SELECT-HISCOBPR-DB-SELECT-2 */
        public void R8000_00_SELECT_HISCOBPR_DB_SELECT_2()
        {
            /*" -1388- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT INTO :HISCOBPR-NUM-CERTIFICADO ,:HISCOBPR-OCORR-HISTORICO ,:HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMPSEGUR ,:HISCOBPR-QUANT-VIDAS ,:HISCOBPR-IMPSEGIND ,:HISCOBPR-COD-OPERACAO ,:HISCOBPR-OPCAO-COBERTURA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMVG ,:HISCOBPR-PRMAP ,:HISCOBPR-QTDE-TIT-CAPITALIZ ,:HISCOBPR-VAL-TIT-CAPITALIZ ,:HISCOBPR-VAL-CUSTO-CAPITALI ,:HISCOBPR-IMPSEGCDG ,:HISCOBPR-VLCUSTCDG ,:HISCOBPR-COD-USUARIO ,:HISCOBPR-TIMESTAMP ,:HISCOBPR-IMPSEGAUXF:VIND-IMPSEGAUXF ,:HISCOBPR-VLCUSTAUXF:VIND-VLCUSTAUXF ,:HISCOBPR-PRMDIT:VIND-PRMDIT ,:HISCOBPR-QTMDIT:VIND-QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO WITH UR END-EXEC. */

            var r8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1 = new R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1.Execute(r8000_00_SELECT_HISCOBPR_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);
                _.Move(executed_1.HISCOBPR_COD_USUARIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);
                _.Move(executed_1.HISCOBPR_TIMESTAMP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_TIMESTAMP);
                _.Move(executed_1.HISCOBPR_IMPSEGAUXF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGAUXF);
                _.Move(executed_1.VIND_IMPSEGAUXF, WIND_NULOS.VIND_IMPSEGAUXF);
                _.Move(executed_1.HISCOBPR_VLCUSTAUXF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF);
                _.Move(executed_1.VIND_VLCUSTAUXF, WIND_NULOS.VIND_VLCUSTAUXF);
                _.Move(executed_1.HISCOBPR_PRMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                _.Move(executed_1.VIND_PRMDIT, WIND_NULOS.VIND_PRMDIT);
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
                _.Move(executed_1.VIND_QTMDIT, WIND_NULOS.VIND_QTMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-MIGRAR-PARA-MENSAL-DB-UPDATE-4 */
        public void R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4()
        {
            /*" -1290- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_OPERACAO = :PROPOVA-COD-OPERACAO ,COD_PRODUTO = :PROPOVA-COD-PRODUTO ,OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO ,DATA_VENCIMENTO = DTPROXVEN - 1 MONTH WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1 = new R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_COD_OPERACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1.Execute(r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R8100-00-SELECT-OPCPAGVI-SECTION */
        private void R8100_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -1437- PERFORM R8100_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R8100_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -1440- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1441- DISPLAY 'ERRO SELECT OPCAO_PAG_VIDAZUL ' */
                _.Display($"ERRO SELECT OPCAO_PAG_VIDAZUL ");

                /*" -1442- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1443- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1445- END-IF. */
            }


            /*" -1446- IF VIND-AGEDEB LESS +0 */

            if (WIND_NULOS.VIND_AGEDEB < +0)
            {

                /*" -1450- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -1452- END-IF. */
            }


            /*" -1453- IF VIND-NUMCAR LESS +0 */

            if (WIND_NULOS.VIND_NUMCAR < +0)
            {

                /*" -1454- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -1454- END-IF. */
            }


        }

        [StopWatch]
        /*" R8100-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R8100_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -1437- EXEC SQL SELECT NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_USUARIO , TIMESTAMP , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-NUM-CERTIFICADO ,:OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO ,:OPCPAGVI-COD-USUARIO ,:OPCPAGVI-TIMESTAMP ,:OPCPAGVI-COD-AGENCIA-DEBITO :VIND-AGEDEB ,:OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB ,:OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB ,:OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB ,:OPCPAGVI-NUM-CARTAO-CREDITO :VIND-NUMCAR FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
                _.Move(executed_1.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_USUARIO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_USUARIO);
                _.Move(executed_1.OPCPAGVI_TIMESTAMP, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_TIMESTAMP);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGEDEB, WIND_NULOS.VIND_AGEDEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPEDEB, WIND_NULOS.VIND_OPEDEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_CTADEB, WIND_NULOS.VIND_CTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGDEB, WIND_NULOS.VIND_DIGDEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_NUMCAR, WIND_NULOS.VIND_NUMCAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8200-00-INSERT-OPCPAGVI-SECTION */
        private void R8200_00_INSERT_OPCPAGVI_SECTION()
        {
            /*" -1478- PERFORM R8200_00_INSERT_OPCPAGVI_DB_INSERT_1 */

            R8200_00_INSERT_OPCPAGVI_DB_INSERT_1();

            /*" -1481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1482- DISPLAY 'ERRO INSERT OPCAO_PAG_VIDAZUL ' */
                _.Display($"ERRO INSERT OPCAO_PAG_VIDAZUL ");

                /*" -1483- DISPLAY 'CERTIFICADO  = ' OPCPAGVI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                /*" -1484- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1484- END-IF. */
            }


        }

        [StopWatch]
        /*" R8200-00-INSERT-OPCPAGVI-DB-INSERT-1 */
        public void R8200_00_INSERT_OPCPAGVI_DB_INSERT_1()
        {
            /*" -1478- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES ( :OPCPAGVI-NUM-CERTIFICADO ,:OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO ,:OPCPAGVI-COD-USUARIO , CURRENT TIMESTAMP ,:OPCPAGVI-COD-AGENCIA-DEBITO :VIND-AGEDEB ,:OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB ,:OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB ,:OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB ,:OPCPAGVI-NUM-CARTAO-CREDITO :VIND-NUMCAR ) END-EXEC. */

            var r8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 = new R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                OPCPAGVI_DATA_INIVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA.ToString(),
                OPCPAGVI_DATA_TERVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.ToString(),
                OPCPAGVI_OPCAO_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.ToString(),
                OPCPAGVI_PERI_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO.ToString(),
                OPCPAGVI_DIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO.ToString(),
                OPCPAGVI_COD_USUARIO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_USUARIO.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                VIND_AGEDEB = WIND_NULOS.VIND_AGEDEB.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                VIND_OPEDEB = WIND_NULOS.VIND_OPEDEB.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                VIND_CTADEB = WIND_NULOS.VIND_CTADEB.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                VIND_DIGDEB = WIND_NULOS.VIND_DIGDEB.ToString(),
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
                VIND_NUMCAR = WIND_NULOS.VIND_NUMCAR.ToString(),
            };

            R8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1.Execute(r8200_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_99_SAIDA*/

        [StopWatch]
        /*" R8300-00-INSERT-HISCOBPR-SECTION */
        private void R8300_00_INSERT_HISCOBPR_SECTION()
        {
            /*" -1553- PERFORM R8300_00_INSERT_HISCOBPR_DB_INSERT_1 */

            R8300_00_INSERT_HISCOBPR_DB_INSERT_1();

            /*" -1556- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1557- DISPLAY 'ERRO INSERT HIS_COBER_PROPOST' */
                _.Display($"ERRO INSERT HIS_COBER_PROPOST");

                /*" -1558- DISPLAY 'CERTIFICADO     = ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO     = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -1559- DISPLAY 'OCORR HISTORICO = ' HISCOBPR-OCORR-HISTORICO */
                _.Display($"OCORR HISTORICO = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO}");

                /*" -1560- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1560- END-IF. */
            }


        }

        [StopWatch]
        /*" R8300-00-INSERT-HISCOBPR-DB-INSERT-1 */
        public void R8300_00_INSERT_HISCOBPR_DB_INSERT_1()
        {
            /*" -1553- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES ( :HISCOBPR-NUM-CERTIFICADO ,:HISCOBPR-OCORR-HISTORICO ,:HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMPSEGUR ,:HISCOBPR-QUANT-VIDAS ,:HISCOBPR-IMPSEGIND ,:HISCOBPR-COD-OPERACAO ,:HISCOBPR-OPCAO-COBERTURA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMVG ,:HISCOBPR-PRMAP ,:HISCOBPR-QTDE-TIT-CAPITALIZ ,:HISCOBPR-VAL-TIT-CAPITALIZ ,:HISCOBPR-VAL-CUSTO-CAPITALI ,:HISCOBPR-IMPSEGCDG ,:HISCOBPR-VLCUSTCDG , 'VE0123B' , CURRENT TIMESTAMP ,:HISCOBPR-IMPSEGAUXF:VIND-IMPSEGAUXF ,:HISCOBPR-VLCUSTAUXF:VIND-VLCUSTAUXF ,:HISCOBPR-PRMDIT :VIND-PRMDIT ,:HISCOBPR-QTMDIT :VIND-QTMDIT ) END-EXEC. */

            var r8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 = new R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_QUANT_VIDAS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND.ToString(),
                HISCOBPR_COD_OPERACAO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO.ToString(),
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_VLPREMIO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG.ToString(),
                HISCOBPR_IMPSEGAUXF = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGAUXF.ToString(),
                VIND_IMPSEGAUXF = WIND_NULOS.VIND_IMPSEGAUXF.ToString(),
                HISCOBPR_VLCUSTAUXF = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF.ToString(),
                VIND_VLCUSTAUXF = WIND_NULOS.VIND_VLCUSTAUXF.ToString(),
                HISCOBPR_PRMDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT.ToString(),
                VIND_PRMDIT = WIND_NULOS.VIND_PRMDIT.ToString(),
                HISCOBPR_QTMDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT.ToString(),
                VIND_QTMDIT = WIND_NULOS.VIND_QTMDIT.ToString(),
            };

            R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1.Execute(r8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8300_99_SAIDA*/

        [StopWatch]
        /*" R8400-00-GRAVA-RELATORIOS-SECTION */
        private void R8400_00_GRAVA_RELATORIOS_SECTION()
        {
            /*" -1571- INITIALIZE DCLRELATORIOS. */
            _.Initialize(
                RELATORI.DCLRELATORIOS
            );

            /*" -1572- MOVE 'VE0123B' TO RELATORI-COD-USUARIO. */
            _.Move("VE0123B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -1573- MOVE 'VE' TO RELATORI-IDE-SISTEMA. */
            _.Move("VE", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -1574- MOVE 'VLNXA' TO RELATORI-COD-RELATORIO. */
            _.Move("VLNXA", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -1575- MOVE 1 TO RELATORI-NUM-COPIAS. */
            _.Move(1, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -1580- MOVE SISTEMAS-DTMOV-ABERTO TO RELATORI-DATA-SOLICITACAO RELATORI-PERI-INICIAL RELATORI-PERI-FINAL RELATORI-DATA-REFERENCIA. */
            _.Move(SISTEMAS_DTMOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -1581- MOVE PROPOVA-NUM-APOLICE TO RELATORI-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -1583- MOVE SUBGVGAP-COD-SUBGRUPO TO RELATORI-COD-SUBGRUPO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -1585- MOVE PROPOVA-NUM-CERTIFICADO TO RELATORI-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -1587- MOVE '1' TO RELATORI-SIT-REGISTRO. */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -1630- PERFORM R8400_00_GRAVA_RELATORIOS_DB_INSERT_1 */

            R8400_00_GRAVA_RELATORIOS_DB_INSERT_1();

            /*" -1633- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1634- DISPLAY 'ERRO INSERT RELATORIOS ' */
                _.Display($"ERRO INSERT RELATORIOS ");

                /*" -1635- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1636- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1636- END-IF. */
            }


        }

        [StopWatch]
        /*" R8400-00-GRAVA-RELATORIOS-DB-INSERT-1 */
        public void R8400_00_GRAVA_RELATORIOS_DB_INSERT_1()
        {
            /*" -1630- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( :RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA ,:RELATORI-PERI-RENOVACAO ,:RELATORI-PCT-AUMENTO , CURRENT TIMESTAMP ) END-EXEC. */

            var r8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 = new R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
            };

            R8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1.Execute(r8400_00_GRAVA_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8400_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1647- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -1648- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1649- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -1650- DISPLAY '*      TERMINO NORMAL DO PROGRAMA VE0123B    *' . */
            _.Display($"*      TERMINO NORMAL DO PROGRAMA VE0123B    *");

            /*" -1651- DISPLAY '* CORRECAO / MIGRACAO EMPRESARIAL ANTECIPADO *' . */
            _.Display($"* CORRECAO / MIGRACAO EMPRESARIAL ANTECIPADO *");

            /*" -1652- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -1653- DISPLAY '* DTMOV-ABERTO        : ' SISTEMAS-DTMOV-ABERTO. */
            _.Display($"* DTMOV-ABERTO        : {SISTEMAS_DTMOV_ABERTO}");

            /*" -1654- DISPLAY '* DTMOV-ABERTO-30     : ' SISTEMAS-DTMOV-ABERTO-30. */
            _.Display($"* DTMOV-ABERTO-30     : {SISTEMAS_DTMOV_ABERTO_30}");

            /*" -1655- DISPLAY '* DTTER-COTACAO  IGPM : ' SISTEMAS-DTTER-COTACAO. */
            _.Display($"* DTTER-COTACAO  IGPM : {SISTEMAS_DTTER_COTACAO}");

            /*" -1656- DISPLAY '* FATOR CORRECAO IGPM : ' W-IGPM-EDIT1. */
            _.Display($"* FATOR CORRECAO IGPM : {ACUMULADORES.W_IGPM_EDIT1}");

            /*" -1657- DISPLAY '*                       ' */
            _.Display($"*                       ");

            /*" -1658- DISPLAY '* TOTAL LIDOS         : ' AC-LIDOS. */
            _.Display($"* TOTAL LIDOS         : {ACUMULADORES.AC_LIDOS}");

            /*" -1659- DISPLAY '* TOTAL PROCESSADOS   : ' AC-PROC. */
            _.Display($"* TOTAL PROCESSADOS   : {ACUMULADORES.AC_PROC}");

            /*" -1660- DISPLAY '* TOTAL <NAO MIGRAR>  : ' AC-NAO-MIGRA. */
            _.Display($"* TOTAL <NAO MIGRAR>  : {ACUMULADORES.AC_NAO_MIGRA}");

            /*" -1661- DISPLAY '* TOTAL < MIGRADOS >  : ' AC-MIGRADOS. */
            _.Display($"* TOTAL < MIGRADOS >  : {ACUMULADORES.AC_MIGRADOS}");

            /*" -1662- DISPLAY '*                       ' */
            _.Display($"*                       ");

            /*" -1664- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -1665- DISPLAY ' ' */
            _.Display($" ");

            /*" -1666- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -1667- DISPLAY 'INDICES UTILIZADOS NO CALCULO DO IGPM ACUMULADO' */
            _.Display($"INDICES UTILIZADOS NO CALCULO DO IGPM ACUMULADO");

            /*" -1668- DISPLAY ' ' */
            _.Display($" ");

            /*" -1669- DISPLAY '   DATA        VALOR IGPM          IGPM ACUM   ' */
            _.Display($"   DATA        VALOR IGPM          IGPM ACUM   ");

            /*" -1671- DISPLAY '----------  -----------------  ----------------' */
            _.Display($"----------  -----------------  ----------------");

            /*" -1672- MOVE 1 TO WIND */
            _.Move(1, WIND);

            /*" -1676- PERFORM R9100-00-IMPRIME-TAB-IGPM UNTIL TB-IGPM-DATA(WIND) EQUAL SPACES OR WIND GREATER 12. */

            while (!(TABELA_IGPM.FILLER_0[WIND].TB_IGPM_DATA == string.Empty || WIND > 12))
            {

                R9100_00_IMPRIME_TAB_IGPM_SECTION();
            }

            /*" -1677- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -1679- DISPLAY ' ' */
            _.Display($" ");

            /*" -1679- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-IMPRIME-TAB-IGPM-SECTION */
        private void R9100_00_IMPRIME_TAB_IGPM_SECTION()
        {
            /*" -1692- MOVE TB-IGPM-VALOR (WIND) TO W-IGPM-EDIT1 */
            _.Move(TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR, ACUMULADORES.W_IGPM_EDIT1);

            /*" -1694- MOVE TB-IGPM-ACUM-MES (WIND) TO W-IGPM-EDIT2 */
            _.Move(TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES, ACUMULADORES.W_IGPM_EDIT2);

            /*" -1698- DISPLAY TB-IGPM-DATA (WIND) '  ' W-IGPM-EDIT1 '  ' W-IGPM-EDIT2. */

            $"{TABELA_IGPM.FILLER_0[WIND]}  {ACUMULADORES.W_IGPM_EDIT1}  {ACUMULADORES.W_IGPM_EDIT2}"
            .Display();

            /*" -1698- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1708- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1710- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1710- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1713- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1713- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}