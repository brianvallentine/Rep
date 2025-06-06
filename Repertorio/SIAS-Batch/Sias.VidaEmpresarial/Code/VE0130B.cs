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
using Sias.VidaEmpresarial.DB2.VE0130B;

namespace Code
{
    public class VE0130B
    {
        public bool IsCall { get; set; }

        public VE0130B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   SOLICITACAO ............ CADMUS 139.356                             */
        /*"      *   DATA ................... JULHO/2016                                 */
        /*"      *   ANALISTA ............... ELIERMES OLIVEIRA                          */
        /*"      *   FUNCAO ................. CORRECAO MONETARIA PELO IGPM PARA          */
        /*"      *                            PRODUTOS EMPRESARIAL GLOBAL                */
        /*"      *                            8205, 8209, 9329 E 9343 APARTIR DO         */
        /*"      *                            SEGUNDO ANIVERSARIO DO SEGURO.             */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   PRODUTOS: 9329 - VIDA EMPRESARIAL VG  - MENSAL                      */
        /*"      *             8205 - VIDA EMPRESARIAL APC - MENSAL                      */
        /*"      *             9343 - VIDA EMPRESARIAL VG  - ANUAL                       */
        /*"      *             8209 - VIDA EMPRESARIAL APC - ANUAL                       */
        /*"      *-----------------------------------------------------------------      */
        /*"      *                         OBSERVACOES                                   */
        /*"      *-----------------------------------------------------------------      */
        /*"      * 1.   CASO O FATOR DE CORRECAO IGPM FOR MENOR OU IGUAL A ZEROS,        */
        /*"      *      O PROGRAMA PROCESSA A MIGRACAO SEM CORRIGIR OS VALORES           */
        /*"      *      E TERMINA COM RC=2 PARA GERAR E-MAIL PARA OS GESTORES.           */
        /*"      *                                                                       */
        /*"      * 2.   CASO NAO ENCONTRE O INDICE IGPM NA DATA TERMINO DE COTACAO       */
        /*"      *      (SISTEMAS-DTTER-COTACAO),O PROGRAMA NAO PROCESSA A MIGRACAO      */
        /*"      *      E TERMINA COM RC=3 PARA GERAR E-MAIL PARA OS GESTORES.           */
        /*"      *                                                                       */
        /*"      * 3.   A CORRECAO NO PRIMEIRO ANIVERSARIO DO SEGURO EH REALIZADA        */
        /*"      *      PELO PGM VE0123B.                                                */
        /*"      *-----------------------------------------------------------------      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *                 A L T E R A C O E S                                   */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 01 - CAD 999.999                                             */
        /*"      *                                                                       */
        /*"      *             - XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX       */
        /*"      *               XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX       */
        /*"      *                                                                       */
        /*"      *   EM 99/99/9999 - XXXXXXXXXXXXXXXXX                                   */
        /*"      *                                            PROCURE POR V.01           */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 02 -  ADAILTON DIAS                                          */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 22/01/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - D 575149 T 584969                                *      */
        /*"      *             - ACERTAR INSERT'S NA HIS_COBER_PROPOST  E         *      */
        /*"      *             V0COBERPROPVA                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2024 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  SISTEMAS-DATA-CORTE            PIC   X(010).*/
        public StringBasis SISTEMAS_DATA_CORTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTMOV-ABERTO          PIC   X(010).*/
        public StringBasis SISTEMAS_DTMOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTMOV-ABERTO-30       PIC   X(010).*/
        public StringBasis SISTEMAS_DTMOV_ABERTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DTMOV-YEAR            PIC  S9(004) COMP.*/
        public IntBasis SISTEMAS_DTMOV_YEAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SISTEMAS-DTMOV-MONTH           PIC  S9(004) COMP.*/
        public IntBasis SISTEMAS_DTMOV_MONTH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  WS-DTQUITACAO-1D               PIC   X(010).*/
        public StringBasis WS_DTQUITACAO_1D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-DTPROXVEN-1D                PIC   X(010).*/
        public StringBasis WS_DTPROXVEN_1D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-DTINIVIG-1D                 PIC   X(010).*/
        public StringBasis WS_DTINIVIG_1D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WS-DTINIVIG-YEAR               PIC  S9(004) COMP.*/
        public IntBasis WS_DTINIVIG_YEAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-DTPROXVEN-YEAR              PIC  S9(004) COMP.*/
        public IntBasis WS_DTPROXVEN_YEAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-DTPROXVEN-MONTH             PIC  S9(004) COMP.*/
        public IntBasis WS_DTPROXVEN_MONTH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  TABELA-IGPM.*/
        public VE0130B_TABELA_IGPM TABELA_IGPM { get; set; } = new VE0130B_TABELA_IGPM();
        public class VE0130B_TABELA_IGPM : VarBasis
        {
            /*"    03  FILLER   OCCURS 12  TIMES.*/
            public ListBasis<VE0130B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VE0130B_FILLER_0>(12);
            public class VE0130B_FILLER_0 : VarBasis
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
        public VE0130B_WS_DATA_SISTEMA WS_DATA_SISTEMA { get; set; } = new VE0130B_WS_DATA_SISTEMA();
        public class VE0130B_WS_DATA_SISTEMA : VarBasis
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
        public VE0130B_VALORES_CORRIGIDOS VALORES_CORRIGIDOS { get; set; } = new VE0130B_VALORES_CORRIGIDOS();
        public class VE0130B_VALORES_CORRIGIDOS : VarBasis
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
        public VE0130B_ACUMULADORES ACUMULADORES { get; set; } = new VE0130B_ACUMULADORES();
        public class VE0130B_ACUMULADORES : VarBasis
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
            /*"    03  AC-JAH-PROC                PIC   9(006) VALUE ZEROS.*/
            public IntBasis AC_JAH_PROC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  WIND-NULOS.*/
        }
        public VE0130B_WIND_NULOS WIND_NULOS { get; set; } = new VE0130B_WIND_NULOS();
        public class VE0130B_WIND_NULOS : VarBasis
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
        public VE0130B_WABEND WABEND { get; set; } = new VE0130B_WABEND();
        public class VE0130B_WABEND : VarBasis
        {
            /*"    03  FILLER                     PIC   X(010)    VALUE           'VE0130B '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VE0130B ");
            /*"    03  FILLER                     PIC  X(026)     VALUE           '*** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"    03  WNR-EXEC-SQL               PIC  X(006)     VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"    03  FILLER                     PIC  X(013)     VALUE           '*** SQLCODE '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"*** SQLCODE ");
            /*"    03  WSQLCODE                   PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


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

        public VE0130B_CURS01 CURS01 { get; set; } = new VE0130B_CURS01(true);
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
							,VALUE(STA_MUDANCA_PLANO
							, ' ')
							,DTPROXVEN - (DAY(DTPROXVEN) - 1) DAYS
							,DATA_QUITACAO - (DAY(DATA_QUITACAO) - 1) DAYS
							,YEAR(DTPROXVEN)
							,MONTH(DTPROXVEN)
							FROM SEGUROS.PROPOSTAS_VA WHERE COD_PRODUTO IN (9329
							, 8205
							, 9343
							, 8209
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9329}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8205}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9343}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}') AND SIT_REGISTRO = '3' AND DTPROXVEN <= '{SISTEMAS_DTMOV_ABERTO_30}' AND MONTH(DATA_QUITACAO) = '{SISTEMAS_DTMOV_MONTH}' AND ('{SISTEMAS_DTMOV_YEAR}' - YEAR(DATA_QUITACAO)) > 1 AND YEAR(DTPROXVEN) = '{SISTEMAS_DTMOV_YEAR}' ORDER BY NUM_APOLICE
							, COD_SUBGRUPO";

            return query;
        }


        public VE0130B_CURS02 CURS02 { get; set; } = new VE0130B_CURS02(true);
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
            /*" -263- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -264- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -265- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -268- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -269- DISPLAY '          PROGRAMA EM EXECUCAO VE0130B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VE0130B          ");

            /*" -270- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -271- DISPLAY 'VRS V.03: ' FUNCTION WHEN-COMPILED ' - D 575149' */

            $"VRS V.03: FUNCTION{_.WhenCompiled()} - D 575149"
            .Display();

            /*" -272- DISPLAY ' ' */
            _.Display($" ");

            /*" -280- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -282- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -283- PERFORM R0010-00-PROCESSO-INICIO. */

            R0010_00_PROCESSO_INICIO_SECTION();

            /*" -284- PERFORM R0300-00-OPEN-CURS01. */

            R0300_00_OPEN_CURS01_SECTION();

            /*" -286- PERFORM R0400-00-FETCH-CURS01. */

            R0400_00_FETCH_CURS01_SECTION();

            /*" -289- PERFORM R1000-00-PROC-CORRECAO-IGPM UNTIL WFIM-CURS01 EQUAL 'SIM' . */

            while (!(WFIM_CURS01 == "SIM"))
            {

                R1000_00_PROC_CORRECAO_IGPM_SECTION();
            }

            /*" -289- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_99_SAIDA */

            R0000_99_SAIDA();

        }

        [StopWatch]
        /*" R0000-99-SAIDA */
        private void R0000_99_SAIDA(bool isPerform = false)
        {
            /*" -292- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0010-00-PROCESSO-INICIO-SECTION */
        private void R0010_00_PROCESSO_INICIO_SECTION()
        {
            /*" -299- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -300- PERFORM R0200-00-VERIFICA-COTACAO. */

            R0200_00_VERIFICA_COTACAO_SECTION();

            /*" -303- PERFORM R0250-00-APURAR-INDICE. */

            R0250_00_APURAR_INDICE_SECTION();

            /*" -304- COMPUTE W-IGPM-ACUM ROUNDED = W-IGPM-ACUM / 100 + 1 */
            ACUMULADORES.W_IGPM_ACUM.Value = ACUMULADORES.W_IGPM_ACUM / 100f + 1;

            /*" -306- MOVE W-IGPM-ACUM TO W-IGPM-EDIT1 */
            _.Move(ACUMULADORES.W_IGPM_ACUM, ACUMULADORES.W_IGPM_EDIT1);

            /*" -307- IF (W-IGPM-ACUM NOT GREATER ZEROS) */

            if ((ACUMULADORES.W_IGPM_ACUM <= 00))
            {

                /*" -308- DISPLAY '-------------- A  T  E  N  C  A  O ------------' */
                _.Display($"-------------- A  T  E  N  C  A  O ------------");

                /*" -309- DISPLAY 'SEM FATOR CORRECAO IGPM PARA O PERIODO' */
                _.Display($"SEM FATOR CORRECAO IGPM PARA O PERIODO");

                /*" -310- DISPLAY 'NAO TEM COMO FAZER CORRECAO MONETARIA' */
                _.Display($"NAO TEM COMO FAZER CORRECAO MONETARIA");

                /*" -311- DISPLAY 'FATOR CORRECAO IGPM = ' W-IGPM-EDIT1 */
                _.Display($"FATOR CORRECAO IGPM = {ACUMULADORES.W_IGPM_EDIT1}");

                /*" -312- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -313- MOVE 2 TO RETURN-CODE */
                _.Move(2, RETURN_CODE);

                /*" -314- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -314- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -324- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -340- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -343- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -344- DISPLAY 'ERRO SELECT SISTEMAS (VE) ' */
                _.Display($"ERRO SELECT SISTEMAS (VE) ");

                /*" -345- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -347- END-IF. */
            }


            /*" -347- MOVE SISTEMAS-DTMOV-ABERTO TO WS-DATA-SISTEMA. */
            _.Move(SISTEMAS_DTMOV_ABERTO, WS_DATA_SISTEMA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -340- EXEC SQL SELECT DATA_MOV_ABERTO ,DATA_MOV_ABERTO - 02 MONTH ,DATA_MOV_ABERTO - 13 MONTH ,DATA_MOV_ABERTO + 01 MONTH ,YEAR(DATA_MOV_ABERTO + 01 MONTH) ,MONTH(DATA_MOV_ABERTO + 01 MONTH) INTO :SISTEMAS-DTMOV-ABERTO ,:SISTEMAS-DTTER-COTACAO ,:SISTEMAS-DTINI-COTACAO ,:SISTEMAS-DTMOV-ABERTO-30 ,:SISTEMAS-DTMOV-YEAR ,:SISTEMAS-DTMOV-MONTH FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VE' WITH UR END-EXEC */

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
                _.Move(executed_1.SISTEMAS_DTMOV_YEAR, SISTEMAS_DTMOV_YEAR);
                _.Move(executed_1.SISTEMAS_DTMOV_MONTH, SISTEMAS_DTMOV_MONTH);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-VERIFICA-COTACAO-SECTION */
        private void R0200_00_VERIFICA_COTACAO_SECTION()
        {
            /*" -360- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -362- MOVE 01 TO SISTEMAS-DTTER-COTACAO(9:2). */
            _.MoveAtPosition(01, SISTEMAS_DTTER_COTACAO, 9, 2);

            /*" -368- PERFORM R0200_00_VERIFICA_COTACAO_DB_SELECT_1 */

            R0200_00_VERIFICA_COTACAO_DB_SELECT_1();

            /*" -371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -373- DISPLAY 'ERRO SELECT(COUNT) MOEDAS_COTACAO - NRSQL ' WNR-EXEC-SQL */
                _.Display($"ERRO SELECT(COUNT) MOEDAS_COTACAO - NRSQL {WABEND.WNR_EXEC_SQL}");

                /*" -374- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -376- END-IF. */
            }


            /*" -377- IF (WHOST-COUNT EQUAL ZEROS) */

            if ((WHOST_COUNT == 00))
            {

                /*" -378- DISPLAY '-------------- A  T  E  N  C  A  O ------------' */
                _.Display($"-------------- A  T  E  N  C  A  O ------------");

                /*" -380- DISPLAY 'INDICE IGPM NAO CADASTRADO PARA A DATA <' SISTEMAS-DTTER-COTACAO '>' */

                $"INDICE IGPM NAO CADASTRADO PARA A DATA <{SISTEMAS_DTTER_COTACAO}>"
                .Display();

                /*" -381- DISPLAY 'ENCAMINHADO E-MAIL PARA GERTI' */
                _.Display($"ENCAMINHADO E-MAIL PARA GERTI");

                /*" -382- DISPLAY 'PROCESSAMENTO INTERROMPIDO COM RC=3' */
                _.Display($"PROCESSAMENTO INTERROMPIDO COM RC=3");

                /*" -383- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -384- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -385- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -385- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-VERIFICA-COTACAO-DB-SELECT-1 */
        public void R0200_00_VERIFICA_COTACAO_DB_SELECT_1()
        {
            /*" -368- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = 23 AND DATA_INIVIGENCIA = :SISTEMAS-DTTER-COTACAO END-EXEC. */

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
            /*" -397- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -399- MOVE 01 TO SISTEMAS-DTINI-COTACAO(9:2). */
            _.MoveAtPosition(01, SISTEMAS_DTINI_COTACAO, 9, 2);

            /*" -399- PERFORM R0250_00_APURAR_INDICE_DB_OPEN_1 */

            R0250_00_APURAR_INDICE_DB_OPEN_1();

            /*" -402- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -403- DISPLAY 'ERRO OPEN CURSOR CURS02' */
                _.Display($"ERRO OPEN CURSOR CURS02");

                /*" -404- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -407- END-IF. */
            }


            /*" -409- PERFORM R0260-00-FETCH-COTACAO */

            R0260_00_FETCH_COTACAO_SECTION();

            /*" -410- IF WFIM-CURS02 EQUAL 'FIM' */

            if (WFIM_CURS02 == "FIM")
            {

                /*" -412- DISPLAY 'NAO ENCONTROU NENHUM INDICE IGPM PARA A DATA <' SISTEMAS-DTINI-COTACAO '>' */

                $"NAO ENCONTROU NENHUM INDICE IGPM PARA A DATA <{SISTEMAS_DTINI_COTACAO}>"
                .Display();

                /*" -413- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -416- END-IF. */
            }


            /*" -417- MOVE SPACES TO TABELA-IGPM */
            _.Move("", TABELA_IGPM);

            /*" -418- MOVE 1 TO WIND */
            _.Move(1, WIND);

            /*" -421- MOVE MOEDACOT-DATA-INIVIGENCIA TO TB-IGPM-DATA (WIND) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_DATA);

            /*" -423- IF MOEDACOT-VAL-VENDA LESS ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA < 00)
            {

                /*" -424- MOVE ZEROS TO MOEDACOT-VAL-VENDA */
                _.Move(0, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);

                /*" -426- END-IF. */
            }


            /*" -432- MOVE MOEDACOT-VAL-VENDA TO TB-IGPM-VALOR (WIND) TB-IGPM-ACUM-MES (WIND) W-IGPM-ACUM */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES, ACUMULADORES.W_IGPM_ACUM);

            /*" -434- PERFORM R0260-00-FETCH-COTACAO */

            R0260_00_FETCH_COTACAO_SECTION();

            /*" -435- IF WFIM-CURS02 EQUAL 'FIM' */

            if (WFIM_CURS02 == "FIM")
            {

                /*" -437- DISPLAY 'ENCONTROU SOMENTE UM INDICE IGPM PARA A DATA <' SISTEMAS-DTINI-COTACAO '>' */

                $"ENCONTROU SOMENTE UM INDICE IGPM PARA A DATA <{SISTEMAS_DTINI_COTACAO}>"
                .Display();

                /*" -438- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -440- END-IF. */
            }


            /*" -443- PERFORM R0270-CARREGA-COTACAO UNTIL WFIM-CURS02 EQUAL 'FIM' . */

            while (!(WFIM_CURS02 == "FIM"))
            {

                R0270_CARREGA_COTACAO_SECTION();
            }

            /*" -445- IF (WIND EQUAL 99) */

            if ((WIND == 99))
            {

                /*" -446- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -446- END-IF. */
            }


        }

        [StopWatch]
        /*" R0250-00-APURAR-INDICE-DB-OPEN-1 */
        public void R0250_00_APURAR_INDICE_DB_OPEN_1()
        {
            /*" -399- EXEC SQL OPEN CURS02 END-EXEC. */

            CURS02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-FETCH-COTACAO-SECTION */
        private void R0260_00_FETCH_COTACAO_SECTION()
        {
            /*" -457- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WABEND.WNR_EXEC_SQL);

            /*" -461- PERFORM R0260_00_FETCH_COTACAO_DB_FETCH_1 */

            R0260_00_FETCH_COTACAO_DB_FETCH_1();

            /*" -464- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -465- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -466- MOVE 'FIM' TO WFIM-CURS02 */
                    _.Move("FIM", WFIM_CURS02);

                    /*" -467- ELSE */
                }
                else
                {


                    /*" -468- DISPLAY 'ERRO FETCH CURS02 ' */
                    _.Display($"ERRO FETCH CURS02 ");

                    /*" -469- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -470- END-IF */
                }


                /*" -470- END-IF. */
            }


        }

        [StopWatch]
        /*" R0260-00-FETCH-COTACAO-DB-FETCH-1 */
        public void R0260_00_FETCH_COTACAO_DB_FETCH_1()
        {
            /*" -461- EXEC SQL FETCH CURS02 INTO :MOEDACOT-DATA-INIVIGENCIA ,:MOEDACOT-VAL-VENDA END-EXEC. */

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
            /*" -479- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", WABEND.WNR_EXEC_SQL);

            /*" -483- ADD 1 TO WIND */
            WIND.Value = WIND + 1;

            /*" -484- IF WIND GREATER 12 */

            if (WIND > 12)
            {

                /*" -485- DISPLAY 'ESTOUROU TABELA INDICE IGPM' */
                _.Display($"ESTOUROU TABELA INDICE IGPM");

                /*" -486- MOVE 99 TO WIND */
                _.Move(99, WIND);

                /*" -487- MOVE 'FIM' TO WFIM-CURS02 */
                _.Move("FIM", WFIM_CURS02);

                /*" -488- GO TO R0270-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/ //GOTO
                return;

                /*" -490- END-IF. */
            }


            /*" -493- MOVE MOEDACOT-DATA-INIVIGENCIA TO TB-IGPM-DATA (WIND) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_DATA);

            /*" -495- IF MOEDACOT-VAL-VENDA LESS ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA < 00)
            {

                /*" -497- MOVE ZEROS TO TB-IGPM-VALOR (WIND) TB-IGPM-ACUM-MES (WIND) */
                _.Move(0, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES);

                /*" -498- GO TO R0270-01-LER-OUTRO */

                R0270_01_LER_OUTRO(); //GOTO
                return;

                /*" -500- END-IF. */
            }


            /*" -502- MOVE MOEDACOT-VAL-VENDA TO TB-IGPM-VALOR (WIND) */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR);

            /*" -506- COMPUTE W-IGPM-ACUM = (((MOEDACOT-VAL-VENDA / 100 + 1) * (W-IGPM-ACUM / 100 + 1) - 1 ) * 100 ). */
            ACUMULADORES.W_IGPM_ACUM.Value = (((MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA / 100f + 1) * (ACUMULADORES.W_IGPM_ACUM / 100f + 1) - 1) * 100);

            /*" -506- MOVE W-IGPM-ACUM TO TB-IGPM-ACUM-MES (WIND). */
            _.Move(ACUMULADORES.W_IGPM_ACUM, TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES);

            /*" -0- FLUXCONTROL_PERFORM R0270_01_LER_OUTRO */

            R0270_01_LER_OUTRO();

        }

        [StopWatch]
        /*" R0270-01-LER-OUTRO */
        private void R0270_01_LER_OUTRO(bool isPerform = false)
        {
            /*" -509- PERFORM R0260-00-FETCH-COTACAO. */

            R0260_00_FETCH_COTACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-OPEN-CURS01-SECTION */
        private void R0300_00_OPEN_CURS01_SECTION()
        {
            /*" -519- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -519- PERFORM R0300_00_OPEN_CURS01_DB_OPEN_1 */

            R0300_00_OPEN_CURS01_DB_OPEN_1();

            /*" -522- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -523- DISPLAY 'ERRO OPEN CURSOR CURS01 ' */
                _.Display($"ERRO OPEN CURSOR CURS01 ");

                /*" -524- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -524- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-OPEN-CURS01-DB-OPEN-1 */
        public void R0300_00_OPEN_CURS01_DB_OPEN_1()
        {
            /*" -519- EXEC SQL OPEN CURS01 END-EXEC. */

            CURS01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-SECTION */
        private void R0400_00_FETCH_CURS01_SECTION()
        {
            /*" -534- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -554- PERFORM R0400_00_FETCH_CURS01_DB_FETCH_1 */

            R0400_00_FETCH_CURS01_DB_FETCH_1();

            /*" -557- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -558- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -559- MOVE 'SIM' TO WFIM-CURS01 */
                    _.Move("SIM", WFIM_CURS01);

                    /*" -559- PERFORM R0400_00_FETCH_CURS01_DB_CLOSE_1 */

                    R0400_00_FETCH_CURS01_DB_CLOSE_1();

                    /*" -561- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -562- ELSE */
                }
                else
                {


                    /*" -563- DISPLAY 'ERRO FETCH CURS01 ' */
                    _.Display($"ERRO FETCH CURS01 ");

                    /*" -564- DISPLAY 'CERTIFICADO......' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -565- DISPLAY 'NUM APOLICE......' PROPOVA-NUM-APOLICE */
                    _.Display($"NUM APOLICE......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -566- DISPLAY 'COD SUBGRUPO.....' PROPOVA-COD-SUBGRUPO */
                    _.Display($"COD SUBGRUPO.....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                    /*" -567- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -568- END-IF */
                }


                /*" -570- END-IF. */
            }


            /*" -573- ADD 1 TO AC-LIDOS AC-CONTA. */
            ACUMULADORES.AC_LIDOS.Value = ACUMULADORES.AC_LIDOS + 1;
            ACUMULADORES.AC_CONTA.Value = ACUMULADORES.AC_CONTA + 1;

            /*" -574- IF (AC-CONTA GREATER 999) */

            if ((ACUMULADORES.AC_CONTA > 999))
            {

                /*" -575- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -576- MOVE ZEROS TO AC-CONTA */
                _.Move(0, ACUMULADORES.AC_CONTA);

                /*" -579- DISPLAY 'LIDOS PROPOVA ..... ' AC-LIDOS ' ' WS-TIME ' ' PROPOVA-NUM-CERTIFICADO */

                $"LIDOS PROPOVA ..... {ACUMULADORES.AC_LIDOS} {WS_TIME} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -579- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-DB-FETCH-1 */
        public void R0400_00_FETCH_CURS01_DB_FETCH_1()
        {
            /*" -554- EXEC SQL FETCH CURS01 INTO :PROPOVA-NUM-APOLICE ,:PROPOVA-COD-SUBGRUPO ,:PROPOVA-NUM-CERTIFICADO ,:PROPOVA-COD-CLIENTE ,:PROPOVA-OCOREND ,:PROPOVA-COD-FONTE ,:PROPOVA-AGE-COBRANCA ,:PROPOVA-OCORR-HISTORICO ,:PROPOVA-DATA-QUITACAO ,:PROPOVA-DATA-VENCIMENTO ,:PROPOVA-DTPROXVEN ,:PROPOVA-NUM-PARCELA ,:PROPOVA-COD-PRODUTO ,:PROPOVA-NUM-PROPOSTA ,:PROPOVA-STA-MUDANCA-PLANO ,:WS-DTPROXVEN-1D ,:WS-DTQUITACAO-1D ,:WS-DTPROXVEN-YEAR ,:WS-DTPROXVEN-MONTH END-EXEC. */

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
                _.Move(CURS01.WS_DTPROXVEN_1D, WS_DTPROXVEN_1D);
                _.Move(CURS01.WS_DTQUITACAO_1D, WS_DTQUITACAO_1D);
                _.Move(CURS01.WS_DTPROXVEN_YEAR, WS_DTPROXVEN_YEAR);
                _.Move(CURS01.WS_DTPROXVEN_MONTH, WS_DTPROXVEN_MONTH);
            }

        }

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-DB-CLOSE-1 */
        public void R0400_00_FETCH_CURS01_DB_CLOSE_1()
        {
            /*" -559- EXEC SQL CLOSE CURS01 END-EXEC */

            CURS01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROC-CORRECAO-IGPM-SECTION */
        private void R1000_00_PROC_CORRECAO_IGPM_SECTION()
        {
            /*" -590- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -592- PERFORM R8000-00-SELECT-HISCOBPR. */

            R8000_00_SELECT_HISCOBPR_SECTION();

            /*" -594- IF (HISCOBPR-COD-OPERACAO EQUAL 895) AND (WS-DTINIVIG-YEAR >= WS-DTPROXVEN-YEAR) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO == 895) && (WS_DTINIVIG_YEAR >= WS_DTPROXVEN_YEAR))
            {

                /*" -595- ADD 1 TO AC-JAH-PROC */
                ACUMULADORES.AC_JAH_PROC.Value = ACUMULADORES.AC_JAH_PROC + 1;

                /*" -596- ELSE */
            }
            else
            {


                /*" -597- PERFORM R2000-00-CALC-CORRECAO-IGPM */

                R2000_00_CALC_CORRECAO_IGPM_SECTION();

                /*" -598- PERFORM R2100-00-ATUALIZA-HISCOBPR */

                R2100_00_ATUALIZA_HISCOBPR_SECTION();

                /*" -600- PERFORM R2400-00-ATUALIZA-PROPOVA */

                R2400_00_ATUALIZA_PROPOVA_SECTION();

                /*" -601- ADD 1 TO AC-PROC */
                ACUMULADORES.AC_PROC.Value = ACUMULADORES.AC_PROC + 1;

                /*" -603- END-IF. */
            }


            /*" -603- PERFORM R0400-00-FETCH-CURS01. */

            R0400_00_FETCH_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CALC-CORRECAO-IGPM-SECTION */
        private void R2000_00_CALC_CORRECAO_IGPM_SECTION()
        {
            /*" -615- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R8100-00-SELECT-OPCPAGVI. */

            R8100_00_SELECT_OPCPAGVI_SECTION();

            /*" -624- COMPUTE W-IMPSEGUR-CORR ROUNDED = HISCOBPR-IMPSEGUR * W-IGPM-ACUM . */
            VALORES_CORRIGIDOS.W_IMPSEGUR_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR * ACUMULADORES.W_IGPM_ACUM;

            /*" -625- IF (W-IMPSEGUR-CORR NOT GREATER HISCOBPR-IMPSEGUR) */

            if ((VALORES_CORRIGIDOS.W_IMPSEGUR_CORR <= HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR))
            {

                /*" -626- DISPLAY 'CALC CORRECAO IMPSEGUR = IMPSEGUR ANTERIOR ' */
                _.Display($"CALC CORRECAO IMPSEGUR = IMPSEGUR ANTERIOR ");

                /*" -627- PERFORM R2200-00-ATUALIZ-VAL-CORR */

                R2200_00_ATUALIZ_VAL_CORR_SECTION();

                /*" -628- GO TO R2000-10-FIM-CORRECAO */

                R2000_10_FIM_CORRECAO(); //GOTO
                return;

                /*" -631- END-IF. */
            }


            /*" -635- COMPUTE W-IMPSEGIND-CORR ROUNDED = HISCOBPR-IMPSEGIND * W-IGPM-ACUM. */
            VALORES_CORRIGIDOS.W_IMPSEGIND_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND * ACUMULADORES.W_IGPM_ACUM;

            /*" -636- IF (HISCOBPR-IMP-MORNATU EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00))
            {

                /*" -637- MOVE ZEROS TO W-IMPMORNATU-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPMORNATU_CORR);

                /*" -638- ELSE */
            }
            else
            {


                /*" -640- COMPUTE W-IMPMORNATU-CORR ROUNDED = HISCOBPR-IMP-MORNATU * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPMORNATU_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU * ACUMULADORES.W_IGPM_ACUM;

                /*" -643- END-IF. */
            }


            /*" -644- IF (HISCOBPR-IMPMORACID EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID == 00))
            {

                /*" -645- MOVE ZEROS TO W-IMPMORACID-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPMORACID_CORR);

                /*" -646- ELSE */
            }
            else
            {


                /*" -648- COMPUTE W-IMPMORACID-CORR ROUNDED = HISCOBPR-IMPMORACID * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPMORACID_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID * ACUMULADORES.W_IGPM_ACUM;

                /*" -651- END-IF. */
            }


            /*" -652- IF (HISCOBPR-IMPINVPERM EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM == 00))
            {

                /*" -653- MOVE ZEROS TO W-IMPINVPERM-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPINVPERM_CORR);

                /*" -654- ELSE */
            }
            else
            {


                /*" -656- COMPUTE W-IMPINVPERM-CORR ROUNDED = HISCOBPR-IMPINVPERM * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPINVPERM_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM * ACUMULADORES.W_IGPM_ACUM;

                /*" -659- END-IF. */
            }


            /*" -660- IF (HISCOBPR-IMPAMDS EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS == 00))
            {

                /*" -661- MOVE ZEROS TO W-IMPAMDS-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPAMDS_CORR);

                /*" -662- ELSE */
            }
            else
            {


                /*" -664- COMPUTE W-IMPAMDS-CORR ROUNDED = HISCOBPR-IMPAMDS * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPAMDS_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS * ACUMULADORES.W_IGPM_ACUM;

                /*" -667- END-IF. */
            }


            /*" -668- IF (HISCOBPR-IMPDH EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH == 00))
            {

                /*" -669- MOVE ZEROS TO W-IMPDH-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPDH_CORR);

                /*" -670- ELSE */
            }
            else
            {


                /*" -672- COMPUTE W-IMPDH-CORR ROUNDED = HISCOBPR-IMPDH * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPDH_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH * ACUMULADORES.W_IGPM_ACUM;

                /*" -675- END-IF. */
            }


            /*" -676- IF (HISCOBPR-IMPDIT EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT == 00))
            {

                /*" -677- MOVE ZEROS TO W-IMPDIT-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_IMPDIT_CORR);

                /*" -678- ELSE */
            }
            else
            {


                /*" -680- COMPUTE W-IMPDIT-CORR ROUNDED = HISCOBPR-IMPDIT * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_IMPDIT_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT * ACUMULADORES.W_IGPM_ACUM;

                /*" -683- END-IF. */
            }


            /*" -684- IF (HISCOBPR-PRMVG EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG == 00))
            {

                /*" -685- MOVE ZEROS TO W-PRMVG-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMVG_CORR);

                /*" -686- ELSE */
            }
            else
            {


                /*" -688- COMPUTE W-PRMVG-CORR ROUNDED = HISCOBPR-PRMVG * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_PRMVG_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG * ACUMULADORES.W_IGPM_ACUM;

                /*" -691- END-IF. */
            }


            /*" -692- IF (HISCOBPR-PRMAP EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP == 00))
            {

                /*" -693- MOVE ZEROS TO W-PRMAP-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMAP_CORR);

                /*" -694- ELSE */
            }
            else
            {


                /*" -696- COMPUTE W-PRMAP-CORR ROUNDED = HISCOBPR-PRMAP * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_PRMAP_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP * ACUMULADORES.W_IGPM_ACUM;

                /*" -699- END-IF. */
            }


            /*" -702- COMPUTE W-PRMTOT-CORR = W-PRMVG-CORR + W-PRMAP-CORR . */
            VALORES_CORRIGIDOS.W_PRMTOT_CORR.Value = VALORES_CORRIGIDOS.W_PRMVG_CORR + VALORES_CORRIGIDOS.W_PRMAP_CORR;

            /*" -704- IF (VIND-PRMDIT LESS ZEROS) OR (HISCOBPR-PRMDIT EQUAL ZEROS) */

            if ((WIND_NULOS.VIND_PRMDIT < 00) || (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT == 00))
            {

                /*" -705- MOVE ZEROS TO W-PRMDIT-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMDIT_CORR);

                /*" -706- ELSE */
            }
            else
            {


                /*" -708- COMPUTE W-PRMDIT-CORR ROUNDED = HISCOBPR-PRMDIT * W-IGPM-ACUM */
                VALORES_CORRIGIDOS.W_PRMDIT_CORR.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT * ACUMULADORES.W_IGPM_ACUM;

                /*" -708- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2000_10_FIM_CORRECAO */

            R2000_10_FIM_CORRECAO();

        }

        [StopWatch]
        /*" R2000-10-FIM-CORRECAO */
        private void R2000_10_FIM_CORRECAO(bool isPerform = false)
        {
            /*" -716- MOVE HISCOBPR-IMP-MORNATU TO MOVIMVGA-IMP-MORNATU-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -717- MOVE W-IMPMORNATU-CORR TO MOVIMVGA-IMP-MORNATU-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORNATU_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -718- MOVE HISCOBPR-IMPMORACID TO MOVIMVGA-IMP-MORACID-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);

            /*" -719- MOVE W-IMPMORACID-CORR TO MOVIMVGA-IMP-MORACID-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORACID_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -720- MOVE HISCOBPR-IMPINVPERM TO MOVIMVGA-IMP-INVPERM-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

            /*" -721- MOVE W-IMPINVPERM-CORR TO MOVIMVGA-IMP-INVPERM-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPINVPERM_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -722- MOVE HISCOBPR-IMPAMDS TO MOVIMVGA-IMP-AMDS-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);

            /*" -723- MOVE W-IMPAMDS-CORR TO MOVIMVGA-IMP-AMDS-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPAMDS_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);

            /*" -724- MOVE HISCOBPR-IMPDH TO MOVIMVGA-IMP-DH-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

            /*" -725- MOVE W-IMPDH-CORR TO MOVIMVGA-IMP-DH-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPDH_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

            /*" -726- MOVE HISCOBPR-IMPDIT TO MOVIMVGA-IMP-DIT-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);

            /*" -727- MOVE W-IMPDIT-CORR TO MOVIMVGA-IMP-DIT-ATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPDIT_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);

            /*" -728- MOVE HISCOBPR-PRMVG TO MOVIMVGA-PRM-VG-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -729- MOVE W-PRMVG-CORR TO MOVIMVGA-PRM-VG-ATU */
            _.Move(VALORES_CORRIGIDOS.W_PRMVG_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -730- MOVE HISCOBPR-PRMAP TO MOVIMVGA-PRM-AP-ANT */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -730- MOVE W-PRMAP-CORR TO MOVIMVGA-PRM-AP-ATU. */
            _.Move(VALORES_CORRIGIDOS.W_PRMAP_CORR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-ATUALIZA-HISCOBPR-SECTION */
        private void R2100_00_ATUALIZA_HISCOBPR_SECTION()
        {
            /*" -741- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -742- IF (SISTEMAS-DTMOV-MONTH > WS-DTPROXVEN-MONTH) */

            if ((SISTEMAS_DTMOV_MONTH > WS_DTPROXVEN_MONTH))
            {

                /*" -743- MOVE WS-DTQUITACAO-1D(06:02) TO WS-DTPROXVEN-1D(06:02) */
                _.MoveAtPosition(WS_DTQUITACAO_1D.Substring(6, 2), WS_DTPROXVEN_1D, 6, 2);

                /*" -745- END-IF */
            }


            /*" -746- IF (WS-DTPROXVEN-1D > WS-DTINIVIG-1D) */

            if ((WS_DTPROXVEN_1D > WS_DTINIVIG_1D))
            {

                /*" -747- MOVE WS-DTPROXVEN-1D TO HISCOBPR-DATA-INIVIGENCIA */
                _.Move(WS_DTPROXVEN_1D, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

                /*" -748- ELSE */
            }
            else
            {


                /*" -749- MOVE WS-DTINIVIG-1D TO HISCOBPR-DATA-INIVIGENCIA */
                _.Move(WS_DTINIVIG_1D, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

                /*" -753- END-IF. */
            }


            /*" -760- PERFORM R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1 */

            R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1();

            /*" -763- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -764- DISPLAY 'ERRO UPDATE HIS_COBER_PROPOST ' */
                _.Display($"ERRO UPDATE HIS_COBER_PROPOST ");

                /*" -765- DISPLAY 'CERTIFICADO......' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -766- DISPLAY 'OCORR_HISTORICO..' HISCOBPR-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO..{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO}");

                /*" -767- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -772- END-IF. */
            }


            /*" -774- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -775- ADD 1 TO HISCOBPR-OCORR-HISTORICO */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO + 1;

            /*" -776- MOVE W-IMPSEGUR-CORR TO HISCOBPR-IMPSEGUR */
            _.Move(VALORES_CORRIGIDOS.W_IMPSEGUR_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

            /*" -777- MOVE W-IMPSEGIND-CORR TO HISCOBPR-IMPSEGIND */
            _.Move(VALORES_CORRIGIDOS.W_IMPSEGIND_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);

            /*" -778- MOVE 895 TO HISCOBPR-COD-OPERACAO */
            _.Move(895, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

            /*" -779- MOVE W-IMPMORNATU-CORR TO HISCOBPR-IMP-MORNATU */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORNATU_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -780- MOVE W-IMPMORACID-CORR TO HISCOBPR-IMPMORACID */
            _.Move(VALORES_CORRIGIDOS.W_IMPMORACID_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -781- MOVE W-IMPINVPERM-CORR TO HISCOBPR-IMPINVPERM */
            _.Move(VALORES_CORRIGIDOS.W_IMPINVPERM_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

            /*" -782- MOVE W-IMPAMDS-CORR TO HISCOBPR-IMPAMDS */
            _.Move(VALORES_CORRIGIDOS.W_IMPAMDS_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -783- MOVE W-IMPDH-CORR TO HISCOBPR-IMPDH */
            _.Move(VALORES_CORRIGIDOS.W_IMPDH_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -784- MOVE W-IMPDIT-CORR TO HISCOBPR-IMPDIT */
            _.Move(VALORES_CORRIGIDOS.W_IMPDIT_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -785- MOVE W-PRMTOT-CORR TO HISCOBPR-VLPREMIO */
            _.Move(VALORES_CORRIGIDOS.W_PRMTOT_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);

            /*" -786- MOVE W-PRMVG-CORR TO HISCOBPR-PRMVG */
            _.Move(VALORES_CORRIGIDOS.W_PRMVG_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

            /*" -787- MOVE W-PRMAP-CORR TO HISCOBPR-PRMAP */
            _.Move(VALORES_CORRIGIDOS.W_PRMAP_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

            /*" -789- MOVE W-PRMDIT-CORR TO HISCOBPR-PRMDIT */
            _.Move(VALORES_CORRIGIDOS.W_PRMDIT_CORR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);

            /*" -789- PERFORM R8300-00-INSERT-HISCOBPR. */

            R8300_00_INSERT_HISCOBPR_SECTION();

        }

        [StopWatch]
        /*" R2100-00-ATUALIZA-HISCOBPR-DB-UPDATE-1 */
        public void R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1()
        {
            /*" -760- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = DATE(:HISCOBPR-DATA-INIVIGENCIA) - 1 DAY ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO END-EXEC */

            var r2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1 = new R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1()
            {
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
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
            /*" -799- MOVE HISCOBPR-IMPSEGUR TO W-IMPSEGUR-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, VALORES_CORRIGIDOS.W_IMPSEGUR_CORR);

            /*" -800- MOVE HISCOBPR-IMPSEGIND TO W-IMPSEGIND-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, VALORES_CORRIGIDOS.W_IMPSEGIND_CORR);

            /*" -801- MOVE HISCOBPR-IMP-MORNATU TO W-IMPMORNATU-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, VALORES_CORRIGIDOS.W_IMPMORNATU_CORR);

            /*" -802- MOVE HISCOBPR-IMPMORACID TO W-IMPMORACID-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, VALORES_CORRIGIDOS.W_IMPMORACID_CORR);

            /*" -803- MOVE HISCOBPR-IMPINVPERM TO W-IMPINVPERM-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, VALORES_CORRIGIDOS.W_IMPINVPERM_CORR);

            /*" -804- MOVE HISCOBPR-IMPAMDS TO W-IMPAMDS-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, VALORES_CORRIGIDOS.W_IMPAMDS_CORR);

            /*" -805- MOVE HISCOBPR-IMPDH TO W-IMPDH-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, VALORES_CORRIGIDOS.W_IMPDH_CORR);

            /*" -806- MOVE HISCOBPR-IMPDIT TO W-IMPDIT-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, VALORES_CORRIGIDOS.W_IMPDIT_CORR);

            /*" -807- MOVE HISCOBPR-VLPREMIO TO W-PRMTOT-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, VALORES_CORRIGIDOS.W_PRMTOT_CORR);

            /*" -808- MOVE HISCOBPR-PRMVG TO W-PRMVG-CORR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, VALORES_CORRIGIDOS.W_PRMVG_CORR);

            /*" -810- MOVE HISCOBPR-PRMAP TO W-PRMAP-CORR. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, VALORES_CORRIGIDOS.W_PRMAP_CORR);

            /*" -811- IF VIND-PRMDIT LESS ZEROS */

            if (WIND_NULOS.VIND_PRMDIT < 00)
            {

                /*" -812- MOVE ZEROS TO W-PRMDIT-CORR */
                _.Move(0, VALORES_CORRIGIDOS.W_PRMDIT_CORR);

                /*" -813- ELSE */
            }
            else
            {


                /*" -814- MOVE HISCOBPR-PRMDIT TO W-PRMDIT-CORR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT, VALORES_CORRIGIDOS.W_PRMDIT_CORR);

                /*" -814- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-ATUALIZA-PROPOVA-SECTION */
        private void R2400_00_ATUALIZA_PROPOVA_SECTION()
        {
            /*" -827- MOVE 895 TO PROPOVA-COD-OPERACAO */
            _.Move(895, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO);

            /*" -836- PERFORM R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1 */

            R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1();

            /*" -839- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -840- DISPLAY 'ERRO UPDATE PROPOSTAS_VA ' */
                _.Display($"ERRO UPDATE PROPOSTAS_VA ");

                /*" -841- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -842- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -842- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-ATUALIZA-PROPOVA-DB-UPDATE-1 */
        public void R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1()
        {
            /*" -836- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_OPERACAO = :PROPOVA-COD-OPERACAO ,DATA_MOVIMENTO = :HISCOBPR-DATA-INIVIGENCIA ,OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO ,SIT_INTERFACE = '0' ,TIMESTAMP = CURRENT TIMESTAMP ,COD_USUARIO = 'VE0130B' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1 = new R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_COD_OPERACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1.Execute(r2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-SELECT-HISCOBPR-SECTION */
        private void R8000_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -924- PERFORM R8000_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R8000_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -927- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -928- DISPLAY 'ERRO SELECT HIS_COBER_PROPOST' */
                _.Display($"ERRO SELECT HIS_COBER_PROPOST");

                /*" -929- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -930- DISPLAY 'NUM OCORR    = ' HISCOBPR-OCORR-HISTORICO */
                _.Display($"NUM OCORR    = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO}");

                /*" -931- DISPLAY 'NUM APOLICE  = ' PROPOVA-NUM-APOLICE */
                _.Display($"NUM APOLICE  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -932- DISPLAY 'COD SUBGRUPO = ' PROPOVA-COD-SUBGRUPO */
                _.Display($"COD SUBGRUPO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -933- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -933- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R8000_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -924- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_INIVIGENCIA + 1 DAY , YEAR(DATA_INIVIGENCIA) , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT INTO :HISCOBPR-NUM-CERTIFICADO ,:HISCOBPR-OCORR-HISTORICO ,:HISCOBPR-DATA-INIVIGENCIA ,:WS-DTINIVIG-1D ,:WS-DTINIVIG-YEAR ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMPSEGUR ,:HISCOBPR-QUANT-VIDAS ,:HISCOBPR-IMPSEGIND ,:HISCOBPR-COD-OPERACAO ,:HISCOBPR-OPCAO-COBERTURA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMVG ,:HISCOBPR-PRMAP ,:HISCOBPR-QTDE-TIT-CAPITALIZ ,:HISCOBPR-VAL-TIT-CAPITALIZ ,:HISCOBPR-VAL-CUSTO-CAPITALI ,:HISCOBPR-IMPSEGCDG ,:HISCOBPR-VLCUSTCDG ,:HISCOBPR-COD-USUARIO ,:HISCOBPR-TIMESTAMP ,:HISCOBPR-IMPSEGAUXF:VIND-IMPSEGAUXF ,:HISCOBPR-VLCUSTAUXF:VIND-VLCUSTAUXF ,:HISCOBPR-PRMDIT:VIND-PRMDIT ,:HISCOBPR-QTMDIT:VIND-QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = (SELECT MAX(T1.OCORR_HISTORICO) FROM SEGUROS.HIS_COBER_PROPOST T1 WHERE T1.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO) WITH UR END-EXEC. */

            var r8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.WS_DTINIVIG_1D, WS_DTINIVIG_1D);
                _.Move(executed_1.WS_DTINIVIG_YEAR, WS_DTINIVIG_YEAR);
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
        /*" R8100-00-SELECT-OPCPAGVI-SECTION */
        private void R8100_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -973- PERFORM R8100_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R8100_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -977- DISPLAY 'ERRO SELECT OPCAO_PAG_VIDAZUL ' */
                _.Display($"ERRO SELECT OPCAO_PAG_VIDAZUL ");

                /*" -978- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -979- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -981- END-IF. */
            }


            /*" -982- IF VIND-AGEDEB LESS +0 */

            if (WIND_NULOS.VIND_AGEDEB < +0)
            {

                /*" -986- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -988- END-IF. */
            }


            /*" -989- IF VIND-NUMCAR LESS +0 */

            if (WIND_NULOS.VIND_NUMCAR < +0)
            {

                /*" -990- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -990- END-IF. */
            }


        }

        [StopWatch]
        /*" R8100-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R8100_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -973- EXEC SQL SELECT NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_USUARIO , TIMESTAMP , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-NUM-CERTIFICADO ,:OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO ,:OPCPAGVI-COD-USUARIO ,:OPCPAGVI-TIMESTAMP ,:OPCPAGVI-COD-AGENCIA-DEBITO :VIND-AGEDEB ,:OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB ,:OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB ,:OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB ,:OPCPAGVI-NUM-CARTAO-CREDITO :VIND-NUMCAR FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

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
        /*" R8300-00-INSERT-HISCOBPR-SECTION */
        private void R8300_00_INSERT_HISCOBPR_SECTION()
        {
            /*" -1059- PERFORM R8300_00_INSERT_HISCOBPR_DB_INSERT_1 */

            R8300_00_INSERT_HISCOBPR_DB_INSERT_1();

            /*" -1062- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1063- DISPLAY 'ERRO INSERT HIS_COBER_PROPOST' */
                _.Display($"ERRO INSERT HIS_COBER_PROPOST");

                /*" -1064- DISPLAY 'CERTIFICADO     = ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO     = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -1065- DISPLAY 'OCORR HISTORICO = ' HISCOBPR-OCORR-HISTORICO */
                _.Display($"OCORR HISTORICO = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO}");

                /*" -1066- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1066- END-IF. */
            }


        }

        [StopWatch]
        /*" R8300-00-INSERT-HISCOBPR-DB-INSERT-1 */
        public void R8300_00_INSERT_HISCOBPR_DB_INSERT_1()
        {
            /*" -1059- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES ( :HISCOBPR-NUM-CERTIFICADO ,:HISCOBPR-OCORR-HISTORICO ,:HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMPSEGUR ,:HISCOBPR-QUANT-VIDAS ,:HISCOBPR-IMPSEGIND ,:HISCOBPR-COD-OPERACAO ,:HISCOBPR-OPCAO-COBERTURA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMVG ,:HISCOBPR-PRMAP ,:HISCOBPR-QTDE-TIT-CAPITALIZ ,:HISCOBPR-VAL-TIT-CAPITALIZ ,:HISCOBPR-VAL-CUSTO-CAPITALI ,:HISCOBPR-IMPSEGCDG ,:HISCOBPR-VLCUSTCDG , 'VE0130B' , CURRENT TIMESTAMP ,:HISCOBPR-IMPSEGAUXF:VIND-IMPSEGAUXF ,:HISCOBPR-VLCUSTAUXF:VIND-VLCUSTAUXF ,:HISCOBPR-PRMDIT :VIND-PRMDIT ,:HISCOBPR-QTMDIT :VIND-QTMDIT ) END-EXEC. */

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
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1078- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -1079- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1080- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -1081- DISPLAY '*      TERMINO NORMAL DO PROGRAMA VE0130B    *' . */
            _.Display($"*      TERMINO NORMAL DO PROGRAMA VE0130B    *");

            /*" -1082- DISPLAY '*      CORRECAO IGPM DE EMPRESARIAL GLOBAL   *' . */
            _.Display($"*      CORRECAO IGPM DE EMPRESARIAL GLOBAL   *");

            /*" -1083- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -1084- DISPLAY '* DTMOV-ABERTO        : ' SISTEMAS-DTMOV-ABERTO. */
            _.Display($"* DTMOV-ABERTO        : {SISTEMAS_DTMOV_ABERTO}");

            /*" -1085- DISPLAY '* DTMOV-ABERTO-30     : ' SISTEMAS-DTMOV-ABERTO-30. */
            _.Display($"* DTMOV-ABERTO-30     : {SISTEMAS_DTMOV_ABERTO_30}");

            /*" -1086- DISPLAY '* DTMOV-ABERTO-ANO    : ' SISTEMAS-DTMOV-YEAR */
            _.Display($"* DTMOV-ABERTO-ANO    : {SISTEMAS_DTMOV_YEAR}");

            /*" -1087- DISPLAY '* DTMOV-ABERTO-MES    : ' SISTEMAS-DTMOV-MONTH */
            _.Display($"* DTMOV-ABERTO-MES    : {SISTEMAS_DTMOV_MONTH}");

            /*" -1088- DISPLAY '*---------------------------------------------' */
            _.Display($"*---------------------------------------------");

            /*" -1089- DISPLAY '* DTTER-COTACAO  IGPM : ' SISTEMAS-DTTER-COTACAO. */
            _.Display($"* DTTER-COTACAO  IGPM : {SISTEMAS_DTTER_COTACAO}");

            /*" -1090- DISPLAY '* FATOR CORRECAO IGPM : ' W-IGPM-EDIT1. */
            _.Display($"* FATOR CORRECAO IGPM : {ACUMULADORES.W_IGPM_EDIT1}");

            /*" -1091- DISPLAY '*---------------------------------------------' */
            _.Display($"*---------------------------------------------");

            /*" -1092- DISPLAY '* TOTAL LIDOS         : ' AC-LIDOS. */
            _.Display($"* TOTAL LIDOS         : {ACUMULADORES.AC_LIDOS}");

            /*" -1093- DISPLAY '* TOTAL CORRECAO PROC : ' AC-PROC. */
            _.Display($"* TOTAL CORRECAO PROC : {ACUMULADORES.AC_PROC}");

            /*" -1094- DISPLAY '* TOTAL JAH CORRIGIDO : ' AC-JAH-PROC. */
            _.Display($"* TOTAL JAH CORRIGIDO : {ACUMULADORES.AC_JAH_PROC}");

            /*" -1095- DISPLAY '*                       ' */
            _.Display($"*                       ");

            /*" -1097- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -1098- DISPLAY ' ' */
            _.Display($" ");

            /*" -1099- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -1100- DISPLAY 'INDICES UTILIZADOS NO CALCULO DO IGPM ACUMULADO' */
            _.Display($"INDICES UTILIZADOS NO CALCULO DO IGPM ACUMULADO");

            /*" -1101- DISPLAY ' ' */
            _.Display($" ");

            /*" -1102- DISPLAY '   DATA        VALOR IGPM          IGPM ACUM   ' */
            _.Display($"   DATA        VALOR IGPM          IGPM ACUM   ");

            /*" -1104- DISPLAY '----------  -----------------  ----------------' */
            _.Display($"----------  -----------------  ----------------");

            /*" -1105- MOVE 1 TO WIND */
            _.Move(1, WIND);

            /*" -1109- PERFORM R9100-00-IMPRIME-TAB-IGPM UNTIL TB-IGPM-DATA(WIND) EQUAL SPACES OR WIND GREATER 12. */

            while (!(TABELA_IGPM.FILLER_0[WIND].TB_IGPM_DATA == string.Empty || WIND > 12))
            {

                R9100_00_IMPRIME_TAB_IGPM_SECTION();
            }

            /*" -1110- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -1112- DISPLAY ' ' */
            _.Display($" ");

            /*" -1112- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-IMPRIME-TAB-IGPM-SECTION */
        private void R9100_00_IMPRIME_TAB_IGPM_SECTION()
        {
            /*" -1125- MOVE TB-IGPM-VALOR (WIND) TO W-IGPM-EDIT1 */
            _.Move(TABELA_IGPM.FILLER_0[WIND].TB_IGPM_VALOR, ACUMULADORES.W_IGPM_EDIT1);

            /*" -1127- MOVE TB-IGPM-ACUM-MES (WIND) TO W-IGPM-EDIT2 */
            _.Move(TABELA_IGPM.FILLER_0[WIND].TB_IGPM_ACUM_MES, ACUMULADORES.W_IGPM_EDIT2);

            /*" -1131- DISPLAY TB-IGPM-DATA (WIND) '  ' W-IGPM-EDIT1 '  ' W-IGPM-EDIT2. */

            $"{TABELA_IGPM.FILLER_0[WIND]}  {ACUMULADORES.W_IGPM_EDIT1}  {ACUMULADORES.W_IGPM_EDIT2}"
            .Display();

            /*" -1131- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1141- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1143- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1143- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1146- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1146- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}