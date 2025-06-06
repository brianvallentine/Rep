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
using Sias.Loterico.DB2.LT3151S;

namespace Code
{
    public class LT3151S
    {
        public bool IsCall { get; set; }

        public LT3151S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"000300*-----------------------------------------------------------------      */
        /*"000400*                                                                       */
        /*"000600*                                                                       */
        /*"000700*----------------------------------------------------------------*      */
        /*"000800*   SISTEMA ................  LOTERICOS                          *      */
        /*"000900*   PROGRAMA ...............  LT3151S (LT3151S)                  *      */
        /*"001000*----------------------------------------------------------------*      */
        /*"001100*   COORDENADOR.............  JEFFERSON BARRETO                  *      */
        /*"001200*   ANALISTA ...............  JOSE G OLIVEIRA                    *      */
        /*"001300*   PROGRAMADOR ............  JOSE G OLIVEIRA                    *      */
        /*"001400*   DATA CODIFICACAO .......  SET/2009                           *      */
        /*"001400*   VERSAO..................  12122008 23:00HS                   *      */
        /*"001500*----------------------------------------------------------------*      */
        /*"001600*   FUNCAO .................  CALCULO DO PREMIO DA PROPOSTA      *      */
        /*"001700*                             A PARTIR DE DADOS INFORMADOS       *      */
        /*"001800*                             IMPSEG/TAXAS/COEFICIENTES          *      */
        /*"001900*                                                                *      */
        /*"002000*                             RENOVACAO 2009                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  * 18/02/2020 - JAZZ 230834 - OLIVEIRA                            *      */
        /*"      *                            INCLUIR TIPO-OPERACAO = '02' PARA   *      */
        /*"      *                            O LIMITE DE 70% DO DESCONTO RENOVAC *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  * 05/12/2019 - JAZZ 225343 - FLAVIO DE LIMA SILVA.               *      */
        /*"      *                            AUMENTAR O LIMITE DE DESCONTOS TOTAL*      */
        /*"      *                            DE 50% PARA O LIMITE DE 70% DO VALOR*      */
        /*"      *                            BRUTO DA PROPOSTA A PARTIR DESTE ANO*      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * 01/11/2019 - JAZZ 221095 - FLAVIO DE LIMA SILVA                *      */
        /*"      *              RENOVACAO PRODUTO 1803 - FAZER CALCULO DO PREMIO  *      */
        /*"      *              CONSIDERANDO ESTE ANO DE 2020 - BISSEXTO.         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * 26/08/2019 - JAZZ 211969 - FLAVIO DE LIMA SILVA                *      */
        /*"      *              RENOVACAO CCA 2019/2020 - VIGENCIA DE 14 MESES    *      */
        /*"      *              PARA AS PROPOSTAS DESTE ANO SEM ALTERAR CALCULOS  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * 05/07/2016 - CADMUS 139270 - LISIANE BRAGANCA SOARES           *      */
        /*"      *              SIMULACAO DA RENOVACAO                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   07/10/2015 - ALTERADO POR LISIANE PARA RENOVACAO 2015/2016   *      */
        /*"      *                DO PRODUTO '1803' LOTERICO - CADMUS 123722      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  *   11/06/2015 - ALTERADO POR LISIANE PARA RENOVACAO 2015/2016   *      */
        /*"      *                DO PRODUTO '1805' CCA - CADMUS 116809           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"002200*                                                                *      */
        /*"002300*     CHAMADA POR: LT3020B                                       *      */
        /*"002400*                  EM0010B                                       *      */
        /*"002500*                  SPBLT021                                      *      */
        /*"002600*                  LT3084B                                       *      */
        /*"002700*                  LT3091B                                       *      */
        /*"002800*                  LT3092B                                       *      */
        /*"002900*----------------------------------------------------------------*      */
        /*"003000* DADOS DE ENTRADA:                                              *      */
        /*"003100* -----------------                                              *      */
        /*"003200*        CAMPOS NOVOS EM 12/03/2013                              *      */
        /*"      *        LT3151-CRITICAR-PRMLIQ        PIC S9(04)       COMP.           */
        /*"      *        LT3151-VLR-MIN-SAP            PIC S9(08)V9(02) COMP-3.         */
        /*"      *        LT3151-VLR-MIN-PRMLIQ         PIC S9(08)V9(02) COMP-3.         */
        /*"      *                                                                       */
        /*"003300*        LT3151-COD-LOTERICO    -  CODIGO DO LOTERICO            *      */
        /*"003400*        LT3151-QTD-PARCELAS    -  1 A 12                        *      */
        /*"003500*        LT3151-DTINIVIG-APOLICE-  DATA INICIO VIG DA APOLICE    *      */
        /*"003600*        LT3151-DTTERVIG-APOLICE   DATA TERMINO VIG DA APOLICE   *      */
        /*"003700*                             CALCULADO A PARTIR DE 01/01/2009   *      */
        /*"003800*        LT3151-TIPO-CALCULO    -  PR=PRO-RATA  PC=PRAZO CURTO   *      */
        /*"003900*                                                                *      */
        /*"004000*        LT3151-IMPSEG          -  IMP.SEG 1 A 20                *      */
        /*"004100*        LT3151-TAXAS           -  TAXAS   1 A 20                *      */
        /*"004200* (NAO)  LT3151-COEFICIENES     -  COEF    1 A 12                *      */
        /*"004300*              OS COEFICIENTES SAO MONTADOS INTERNAMENTE                */
        /*"004400*-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01              LPARM.*/
        public LT3151S_LPARM LPARM { get; set; } = new LT3151S_LPARM();
        public class LT3151S_LPARM : VarBasis
        {
            /*"   03          LPARM01.*/
            public LT3151S_LPARM01 LPARM01 { get; set; } = new LT3151S_LPARM01();
            public class LT3151S_LPARM01 : VarBasis
            {
                /*"      05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05       LPARM01-AA      PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          LPARM02         PIC S9(005)      COMP-3.*/
                public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    03          LPARM03.*/
                public LT3151S_LPARM03 LPARM03 { get; set; } = new LT3151S_LPARM03();
                public class LT3151S_LPARM03 : VarBasis
                {
                    /*"      05       LPARM03-DD      PIC  9(002).*/
                    public IntBasis LPARM03_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      05       LPARM03-MM      PIC  9(002).*/
                    public IntBasis LPARM03_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      05       LPARM03-AA      PIC  9(004).*/
                    public IntBasis LPARM03_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01 WS-AREA-TRABALHO.*/
                }
            }
        }
        public LT3151S_WS_AREA_TRABALHO WS_AREA_TRABALHO { get; set; } = new LT3151S_WS_AREA_TRABALHO();
        public class LT3151S_WS_AREA_TRABALHO : VarBasis
        {
            /*"   05 WS-QT-REG                     PIC S9(01) COMP VALUE 0.*/
            public IntBasis WS_QT_REG { get; set; } = new IntBasis(new PIC("S9", "1", "S9(01)"));
            /*"   05 WS-NM-PROGRAMA                PIC X(07) VALUE SPACES.*/
            public StringBasis WS_NM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
            /*"   05 HOST-COUNT                    PIC S9(04) COMP.*/
            public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 HOST-DATA-INI                 PIC X(10).*/
            public StringBasis HOST_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 HOST-DATA-FIM                 PIC X(10).*/
            public StringBasis HOST_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 WS-EXISTE-DESC-SEM-SINI-INF   PIC S9(04) COMP VALUE 0.*/
            public IntBasis WS_EXISTE_DESC_SEM_SINI_INF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-EXISTE-DESC-SEM-SINI       PIC S9(04) COMP VALUE 0.*/
            public IntBasis WS_EXISTE_DESC_SEM_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-COD-LOTERICO               PIC S9(10) COMP-3.*/
            public IntBasis WS_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
            /*"   05 WS-DTINIVIG-APOLICE           PIC  X(10).*/
            public StringBasis WS_DTINIVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 WS-DTTERVIG-APOLICE           PIC  X(10).*/
            public StringBasis WS_DTTERVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05  WS-VERSAO                          PIC  X(120) VALUE        'LT3151S-VERSAO: V15-06122019 11:40HS  - JAZZ 225343        'ALTERAR DESCONTO DE RENOVACAO'.*/
            public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3151S-VERSAO: V15-06122019 11:40HS  - JAZZ 225343        ");
            /*"   05  WS-VERSAO-V14                      PIC  X(120) VALUE        'LT3151S-VERSAO: V14-04092019 10:15HS  - PRODUTO CCA'.*/
            public StringBasis WS_VERSAO_V14 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3151S-VERSAO: V14-04092019 10:15HS  - PRODUTO CCA");
            /*"   05  WS-VERSAO-V13                      PIC  X(120) VALUE        'LT3151S-VERSAO: V13-02092013 10:15HS  - PRODUTO CCA'.*/
            public StringBasis WS_VERSAO_V13 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3151S-VERSAO: V13-02092013 10:15HS  - PRODUTO CCA");
            /*"   05  WS-VERSAO-12                       PIC  X(120) VALUE        'LT3151S-VERSAO: V12-11042013 08:32HS  - CAD61050 AJUSTE        'IS E QTD PCL '.*/
            public StringBasis WS_VERSAO_12 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3151S-VERSAO: V12-11042013 08:32HS  - CAD61050 AJUSTE        ");
            /*"   05  WS-VERSAO-V11                      PIC  X(120) VALUE        'LT3151S-VERSAO: V11-05122012 14:49HS  - CAD61050 RENOVA        'CAO 2013'.*/
            public StringBasis WS_VERSAO_V11 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3151S-VERSAO: V11-05122012 14:49HS  - CAD61050 RENOVA        ");
            /*"   05  WS-VERSAO-10                       PIC  X(120) VALUE        'LT3151S-VERSAO: V10-04102011 09:53HS  - CAD61050 RENOVA        'CAO 2012'.*/
            public StringBasis WS_VERSAO_10 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3151S-VERSAO: V10-04102011 09:53HS  - CAD61050 RENOVA        ");
            /*"   05  WS-VERSAO-09                       PIC  X(50) VALUE                    'LT3151S-VERSAO:15102010 17:00HS'.*/
            public StringBasis WS_VERSAO_09 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"LT3151S-VERSAO:15102010 17:00HS");
            /*"   05  WS-VERSAO-08                       PIC  X(50) VALUE                    'LT3151S-VERSAO:12122008 23:00HS'.*/
            public StringBasis WS_VERSAO_08 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"LT3151S-VERSAO:12122008 23:00HS");
            /*"   05       WS-QTDIAS-VIGENCIA   PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-QTDIAS-DECORRIDOS PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_DECORRIDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-QTDIAS-DECORRER   PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_DECORRER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       V0APO-NUM-APOLICE    PIC S9(013)  COMP-3 VALUE +0.*/
            public IntBasis V0APO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05       VIND-NUM-TITULO      PIC S9(004)  COMP VALUE +0.*/
            public IntBasis VIND_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WS-NUMERO-LOTERICO  PIC  9(009)  VALUE ZEROS.*/
            public IntBasis WS_NUMERO_LOTERICO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"   05  FILLER REDEFINES WS-NUMERO-LOTERICO.*/
            private _REDEF_LT3151S_FILLER_0 _filler_0 { get; set; }
            public _REDEF_LT3151S_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_LT3151S_FILLER_0(); _.Move(WS_NUMERO_LOTERICO, _filler_0); VarBasis.RedefinePassValue(WS_NUMERO_LOTERICO, _filler_0, WS_NUMERO_LOTERICO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NUMERO_LOTERICO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_NUMERO_LOTERICO); }
            }  //Redefines
            public class _REDEF_LT3151S_FILLER_0 : VarBasis
            {
                /*"     10 WS-NUM-LOTERICO    PIC  9(008).*/
                public IntBasis WS_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"     10 WS-DV-LOTERICO     PIC  9(001).*/
                public IntBasis WS_DV_LOTERICO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   05  WS-CGCCPF-X                PIC  X(15).*/

                public _REDEF_LT3151S_FILLER_0()
                {
                    WS_NUM_LOTERICO.ValueChanged += OnValueChanged;
                    WS_DV_LOTERICO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CGCCPF_X { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"   05  WS-CGCCPF-NUM REDEFINES WS-CGCCPF-X                                 PIC  9(15).*/
            private _REDEF_IntBasis _ws_cgccpf_num { get; set; }
            public _REDEF_IntBasis WS_CGCCPF_NUM
            {
                get { _ws_cgccpf_num = new _REDEF_IntBasis(new PIC("9", "15", "9(15).")); ; _.Move(WS_CGCCPF_X, _ws_cgccpf_num); VarBasis.RedefinePassValue(WS_CGCCPF_X, _ws_cgccpf_num, WS_CGCCPF_X); _ws_cgccpf_num.ValueChanged += () => { _.Move(_ws_cgccpf_num, WS_CGCCPF_X); }; return _ws_cgccpf_num; }
                set { VarBasis.RedefinePassValue(value, _ws_cgccpf_num, WS_CGCCPF_X); }
            }  //Redefines
            /*"   05       WS-VALOR                    PIC 9(010)V9(2).*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(2)."), 2);
            /*"   05       WS-VALOR-SAIDA   PIC ZZZ.ZZZ.ZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_VALOR_SAIDA { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-INDICE-SAIDA  PIC ZZZZZ9          VALUE ZEROS.*/
            public IntBasis WS_INDICE_SAIDA { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9"));
            /*"   05       WS-VALOR-PREMIO             PIC S9(008)V9(6)  COMP-3*/
            public DoubleBasis WS_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(6)"), 6);
            /*"   05       WS-FATOR                    PIC S9(003)V9(6)  COMP-3*/
            public DoubleBasis WS_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05       WS-FATOR-S                  PIC ZZZZ9,999999.*/
            public DoubleBasis WS_FATOR_S { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V999999."), 6);
            /*"   05       WS-PCT-PRM-ANUAL            PIC S9(003)V99    COMP-3*/
            public DoubleBasis WS_PCT_PRM_ANUAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"   05       WS-PCT-PRM-DECORRIDO        PIC S9(003)V99    COMP-3*/
            public DoubleBasis WS_PCT_PRM_DECORRIDO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"   05       WS-TOTAL-DESCONTO           PIC S9(007)V99    COMP-3*/
            public DoubleBasis WS_TOTAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V99"), 2);
            /*"   05       WS-50PCT-SUBTOTAL           PIC S9(007)V99    COMP-3*/
            public DoubleBasis WS_50PCT_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V99"), 2);
            /*"   05       WS-70PCT-SUBTOTAL           PIC S9(007)V99    COMP-3*/
            public DoubleBasis WS_70PCT_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V99"), 2);
            /*"   05       WS-PCT-DESC-TOTAL           PIC S9(008)V99  COMP-3                                                     VALUE ZEROS*/
            public DoubleBasis WS_PCT_DESC_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
            /*"   05       WS-PCT-DESC-ARRED           PIC S9(008)V  COMP-3                                                     VALUE ZEROS*/
            public DoubleBasis WS_PCT_DESC_ARRED { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V"), 0);
            /*"   05  WS-PCT-COBERTURA           PIC S9(003)V9(9)  COMP-3.*/
            public DoubleBasis WS_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
            /*"   05  WS-PCT-DESC-COB-ADIC       PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_DESC_COB_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05  WS-PCT-DESC-EXP            PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05  WS-PCT-DESC-FIDEL          PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05  WS-PCT-IOF           PIC S9(008)V9(6)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(6)"), 6);
            /*"   05  WS-CUSTO-APOLICE     PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-VLR-TAXA-ADESAO   PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_TAXA_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-DISPLAY           PIC  X(003) VALUE SPACES.*/
            public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05  WS-VLR-ADIC-COBER    PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_ADIC_COBER { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-VLR-MIN-SAP       PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_MIN_SAP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-VLR-MIN-PRMLIQ    PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_MIN_PRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05         WS-DATE.*/
            public LT3151S_WS_DATE WS_DATE { get; set; } = new LT3151S_WS_DATE();
            public class LT3151S_WS_DATE : VarBasis
            {
                /*"     10       WS-AA-DATE         PIC  9(02).*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10       WS-MM-DATE         PIC  9(02).*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10       WS-DD-DATE         PIC  9(02).*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05       WS-DATA-SQL-AUX               PIC X(10).*/
            }
            public StringBasis WS_DATA_SQL_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DATA-SQL-AUX-R REDEFINES WS-DATA-SQL-AUX .*/
            private _REDEF_LT3151S_WS_DATA_SQL_AUX_R _ws_data_sql_aux_r { get; set; }
            public _REDEF_LT3151S_WS_DATA_SQL_AUX_R WS_DATA_SQL_AUX_R
            {
                get { _ws_data_sql_aux_r = new _REDEF_LT3151S_WS_DATA_SQL_AUX_R(); _.Move(WS_DATA_SQL_AUX, _ws_data_sql_aux_r); VarBasis.RedefinePassValue(WS_DATA_SQL_AUX, _ws_data_sql_aux_r, WS_DATA_SQL_AUX); _ws_data_sql_aux_r.ValueChanged += () => { _.Move(_ws_data_sql_aux_r, WS_DATA_SQL_AUX); }; return _ws_data_sql_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sql_aux_r, WS_DATA_SQL_AUX); }
            }  //Redefines
            public class _REDEF_LT3151S_WS_DATA_SQL_AUX_R : VarBasis
            {
                /*"     10     WS-ANO-SQL-AUX                PIC 9(04).*/
                public IntBasis WS_ANO_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10     FILLER                        PIC X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-SQL-AUX                PIC 9(02).*/
                public IntBasis WS_MES_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER                        PIC X(01).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-SQL-AUX                PIC 9(02).*/
                public IntBasis WS_DIA_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05       WS-DATA-DB2.*/

                public _REDEF_LT3151S_WS_DATA_SQL_AUX_R()
                {
                    WS_ANO_SQL_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_MES_SQL_AUX.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_DIA_SQL_AUX.ValueChanged += OnValueChanged;
                }

            }
            public LT3151S_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new LT3151S_WS_DATA_DB2();
            public class LT3151S_WS_DATA_DB2 : VarBasis
            {
                /*"     10     WS-ANO-DB2       PIC  9(004)          VALUE ZEROS.*/
                public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-MES-DB2       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-DIA-DB2       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-DATA-SQL.*/
            }
            public LT3151S_WS_DATA_SQL WS_DATA_SQL { get; set; } = new LT3151S_WS_DATA_SQL();
            public class LT3151S_WS_DATA_SQL : VarBasis
            {
                /*"     10     WS-ANO-SQL       PIC  9(004)          VALUE ZEROS.*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-MES-SQL       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     05     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     05     WS-DIA-SQL       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-ERRO                  PIC   9(04).*/
            }
            public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WS-QTD-PARCELAS          PIC   9(04).*/
            public IntBasis WS_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WTOTAL-PREMIO-BRUTO      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-PREMIO-LIQNP      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_LIQNP { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-JURO-1P           PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_JURO_1P { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-JURO              PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_JURO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-IOF               PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_IOF { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IOF-PRIM              PIC   9(009)V99.*/
            public DoubleBasis WS_IOF_PRIM { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IOF-OUTR              PIC   9(009)V99.*/
            public DoubleBasis WS_IOF_OUTR { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IND                   PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IND1                  PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IND2                  PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-ORDEM                 PIC   9(006) VALUE 1.*/
            public IntBasis WS_ORDEM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 1);
            /*"   05       WS-INDICE                PIC   9(006) VALUE 1.*/
            public IntBasis WS_INDICE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 1);
            /*"   05       WS-QTD-PARCELAS-SALVA    PIC   9(006) VALUE 0.*/
            public IntBasis WS_QTD_PARCELAS_SALVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-CRITICAR-PRMLIQ-SALVA PIC   9(006) VALUE 0.*/
            public IntBasis WS_CRITICAR_PRMLIQ_SALVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-HOUVE-ALTERACAO   PIC X(003) VALUE SPACES.*/
            public StringBasis WS_HOUVE_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05       WS-ANO-RENOVACAO         PIC   X(004) VALUE ' '.*/
            public StringBasis WS_ANO_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
            /*"   05 TAB-IMPSEG-SALVA   COMP-3.*/
            public LT3151S_TAB_IMPSEG_SALVA TAB_IMPSEG_SALVA { get; set; } = new LT3151S_TAB_IMPSEG_SALVA();
            public class LT3151S_TAB_IMPSEG_SALVA : VarBasis
            {
                /*"      10 TB-IMPSEG-SALVA PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_IMPSEG_SALVA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05 TAB-PREMIO-LIQ   COMP-3.*/
            }
            public LT3151S_TAB_PREMIO_LIQ TAB_PREMIO_LIQ { get; set; } = new LT3151S_TAB_PREMIO_LIQ();
            public class LT3151S_TAB_PREMIO_LIQ : VarBasis
            {
                /*"      10 TB-PREMIO-LIQ  PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_PREMIO_LIQ { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05 TAB-PREMIO-LIQ-1PCL   COMP-3.*/
            }
            public LT3151S_TAB_PREMIO_LIQ_1PCL TAB_PREMIO_LIQ_1PCL { get; set; } = new LT3151S_TAB_PREMIO_LIQ_1PCL();
            public class LT3151S_TAB_PREMIO_LIQ_1PCL : VarBasis
            {
                /*"      10 TB-PREMIO-LIQ-1PCL PIC S9(08)V99 COMP-3 OCCURS 20 TIMES*/
                public ListBasis<DoubleBasis, double> TB_PREMIO_LIQ_1PCL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05 TAB-IOF       COMP-3.*/
            }
            public LT3151S_TAB_IOF TAB_IOF { get; set; } = new LT3151S_TAB_IOF();
            public class LT3151S_TAB_IOF : VarBasis
            {
                /*"     10 TB-IOF       PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_IOF { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05     TABELA-ORDEM-COBER.*/
            }
            public LT3151S_TABELA_ORDEM_COBER TABELA_ORDEM_COBER { get; set; } = new LT3151S_TABELA_ORDEM_COBER();
            public class LT3151S_TABELA_ORDEM_COBER : VarBasis
            {
                /*"    07     TAB-ORDEM-COBER.*/
                public LT3151S_TAB_ORDEM_COBER TAB_ORDEM_COBER { get; set; } = new LT3151S_TAB_ORDEM_COBER();
                public class LT3151S_TAB_ORDEM_COBER : VarBasis
                {
                    /*"     10   FILLER             PIC  9(002)  VALUE 7.*/
                    public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 7);
                    /*"     10   FILLER             PIC  9(002)  VALUE 8.*/
                    public IntBasis FILLER_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 8);
                    /*"     10   FILLER             PIC  9(002)  VALUE 9.*/
                    public IntBasis FILLER_9 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 9);
                    /*"     10   FILLER             PIC  9(002)  VALUE 3.*/
                    public IntBasis FILLER_10 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 3);
                    /*"     10   FILLER             PIC  9(002)  VALUE 6.*/
                    public IntBasis FILLER_11 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 6);
                    /*"     10   FILLER             PIC  9(002)  VALUE 10.*/
                    public IntBasis FILLER_12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 10);
                    /*"     10   FILLER             PIC  9(002)  VALUE 11.*/
                    public IntBasis FILLER_13 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 11);
                    /*"     10   FILLER             PIC  9(002)  VALUE 12.*/
                    public IntBasis FILLER_14 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 12);
                    /*"     10   FILLER             PIC  9(002)  VALUE 13.*/
                    public IntBasis FILLER_15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 13);
                    /*"     10   FILLER             PIC  9(002)  VALUE 14.*/
                    public IntBasis FILLER_16 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 14);
                    /*"     10   FILLER             PIC  9(002)  VALUE 15.*/
                    public IntBasis FILLER_17 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 15);
                    /*"     10   FILLER             PIC  9(002)  VALUE 16.*/
                    public IntBasis FILLER_18 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 16);
                    /*"     10   FILLER             PIC  9(002)  VALUE 17.*/
                    public IntBasis FILLER_19 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 17);
                    /*"     10   FILLER             PIC  9(002)  VALUE 18.*/
                    public IntBasis FILLER_20 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 18);
                    /*"     10   FILLER             PIC  9(002)  VALUE 19.*/
                    public IntBasis FILLER_21 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                    /*"    07     TAB-ORDEM-COBER-R   REDEFINES          TAB-ORDEM-COBER.*/
                }
                private _REDEF_LT3151S_TAB_ORDEM_COBER_R _tab_ordem_cober_r { get; set; }
                public _REDEF_LT3151S_TAB_ORDEM_COBER_R TAB_ORDEM_COBER_R
                {
                    get { _tab_ordem_cober_r = new _REDEF_LT3151S_TAB_ORDEM_COBER_R(); _.Move(TAB_ORDEM_COBER, _tab_ordem_cober_r); VarBasis.RedefinePassValue(TAB_ORDEM_COBER, _tab_ordem_cober_r, TAB_ORDEM_COBER); _tab_ordem_cober_r.ValueChanged += () => { _.Move(_tab_ordem_cober_r, TAB_ORDEM_COBER); }; return _tab_ordem_cober_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_ordem_cober_r, TAB_ORDEM_COBER); }
                }  //Redefines
                public class _REDEF_LT3151S_TAB_ORDEM_COBER_R : VarBasis
                {
                    /*"     10   TB-ORDEM-COBER   OCCURS 15 TIMES PIC  9(002).*/
                    public ListBasis<IntBasis, Int64> TB_ORDEM_COBER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "2", "9(002)."), 15);
                    /*"   05            WABEND.*/

                    public _REDEF_LT3151S_TAB_ORDEM_COBER_R()
                    {
                        TB_ORDEM_COBER.ValueChanged += OnValueChanged;
                    }

                }
            }
            public LT3151S_WABEND WABEND { get; set; } = new LT3151S_WABEND();
            public class LT3151S_WABEND : VarBasis
            {
                /*"    10          FILLER           PIC  X(008)      VALUE               'LT3151S '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LT3151S ");
                /*"    10          FILLER           PIC  X(025)      VALUE               '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10          WNR-EXEC-SQL     PIC  X(004)      VALUE   '0000'*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10          FILLER           PIC  X(013)      VALUE               ' *** SQLCODE '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10          WSQLCODE         PIC  ZZZZZ999-   VALUE    ZEROS*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Copies.LBLT3150 LBLT3150 { get; set; } = new Copies.LBLT3150();
        public Copies.LBLT3159 LBLT3159 { get; set; } = new Copies.LBLT3159();
        public Copies.LBTB3101 LBTB3101 { get; set; } = new Copies.LBTB3101();
        public Copies.LBLT3171 LBLT3171 { get; set; } = new Copies.LBLT3171();
        public Copies.LBLT3151 LBLT3151 { get; set; } = new Copies.LBLT3151();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.FCLOTERI FCLOTERI { get; set; } = new Dclgens.FCLOTERI();
        public Dclgens.FCCONBAN FCCONBAN { get; set; } = new Dclgens.FCCONBAN();
        public Dclgens.LTMVPRBO LTMVPRBO { get; set; } = new Dclgens.LTMVPRBO();
        public Dclgens.LTMVPRCO LTMVPRCO { get; set; } = new Dclgens.LTMVPRCO();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PRAZOSEG PRAZOSEG { get; set; } = new Dclgens.PRAZOSEG();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3151_LT3151_AREA_PARAMETROS LBLT3151_LT3151_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3151_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3151.LT3151_AREA_PARAMETROS = LBLT3151_LT3151_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3151.LT3151_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -346- PERFORM R1000-00-PROCESSA-REGISTRO. */

            R1000_00_PROCESSA_REGISTRO_SECTION();

            /*" -347- PERFORM R9000-00-ROT-RETORNO. */

            R9000_00_ROT_RETORNO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-CRITICA-PARAMETROS-SECTION */
        private void R0100_CRITICA_PARAMETROS_SECTION()
        {
            /*" -357- MOVE 0 TO WS-ERRO */
            _.Move(0, WS_AREA_TRABALHO.WS_ERRO);

            /*" -359- MOVE '1001-01-01' TO WS-DATA-SQL */
            _.Move("1001-01-01", WS_AREA_TRABALHO.WS_DATA_SQL);

            /*" -360- ACCEPT WS-DATE FROM DATE */
            _.Move(_.AcceptDate("DATE"), WS_AREA_TRABALHO.WS_DATE);

            /*" -361- MOVE WS-DD-DATE TO WS-DIA-SQL */
            _.Move(WS_AREA_TRABALHO.WS_DATE.WS_DD_DATE, WS_AREA_TRABALHO.WS_DATA_SQL.WS_DIA_SQL);

            /*" -362- MOVE WS-MM-DATE TO WS-MES-SQL */
            _.Move(WS_AREA_TRABALHO.WS_DATE.WS_MM_DATE, WS_AREA_TRABALHO.WS_DATA_SQL.WS_MES_SQL);

            /*" -363- MOVE WS-AA-DATE TO WS-ANO-SQL */
            _.Move(WS_AREA_TRABALHO.WS_DATE.WS_AA_DATE, WS_AREA_TRABALHO.WS_DATA_SQL.WS_ANO_SQL);

            /*" -365- ADD 2000 TO WS-ANO-SQL */
            WS_AREA_TRABALHO.WS_DATA_SQL.WS_ANO_SQL.Value = WS_AREA_TRABALHO.WS_DATA_SQL.WS_ANO_SQL + 2000;

            /*" -367- MOVE SPACES TO LT3151-MSG-RETORNO */
            _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

            /*" -368- MOVE 1 TO WS-ORDEM */
            _.Move(1, WS_AREA_TRABALHO.WS_ORDEM);

            /*" -369- MOVE LT3151-QTD-PARCELAS TO WS-QTD-PARCELAS-SALVA */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS, WS_AREA_TRABALHO.WS_QTD_PARCELAS_SALVA);

            /*" -374- MOVE LT3151-CRITICAR-PRMLIQ TO WS-CRITICAR-PRMLIQ-SALVA */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ, WS_AREA_TRABALHO.WS_CRITICAR_PRMLIQ_SALVA);

            /*" -376- PERFORM R0110-00-VERIFICA-PRODUTO */

            R0110_00_VERIFICA_PRODUTO_SECTION();

            /*" -378- PERFORM R0105-00-LER-PERIODO-VIGENTE */

            R0105_00_LER_PERIODO_VIGENTE_SECTION();

            /*" -379- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 20); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -381- IF LT3151-IMPSEG (WS-IND) > 0 AND LT3151-TAXAS (WS-IND) > 0 */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND].LT3151_IMPSEG > 0 && LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_AREA_TRABALHO.WS_IND].LT3151_TAXAS > 0)
                {

                    /*" -382- ADD 1 TO WS-ERRO */
                    WS_AREA_TRABALHO.WS_ERRO.Value = WS_AREA_TRABALHO.WS_ERRO + 1;

                    /*" -383- END-IF */
                }


                /*" -385- MOVE LT3151-IMPSEG(WS-IND) TO TB-IMPSEG-SALVA(WS-IND) */
                _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND].LT3151_IMPSEG, WS_AREA_TRABALHO.TAB_IMPSEG_SALVA.TB_IMPSEG_SALVA[WS_AREA_TRABALHO.WS_IND]);

                /*" -387- END-PERFORM */
            }

            /*" -388- IF WS-ERRO < 2 */

            if (WS_AREA_TRABALHO.WS_ERRO < 2)
            {

                /*" -390- MOVE ' LT3151S-IMPSEG E TAXA INSUFICIENTES PARA CALCULO' TO LT3151-MSG-RETORNO */
                _.Move(" LT3151S-IMPSEG E TAXA INSUFICIENTES PARA CALCULO", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -391- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -392- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -393- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -395- END-IF */
            }


            /*" -397- MOVE 0 TO WS-ERRO */
            _.Move(0, WS_AREA_TRABALHO.WS_ERRO);

            /*" -398- IF LT3151-QTD-PARCELAS < 1 OR > 12 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS < 1 || LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS > 12)
            {

                /*" -400- MOVE '  LT3151S-QTD PARCELAS INVALIDO ' TO LT3151-MSG-RETORNO */
                _.Move("  LT3151S-QTD PARCELAS INVALIDO ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -401- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -402- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -403- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -405- END-IF */
            }


            /*" -406- IF LT3151-COD-REGIAO < 1 OR > 4 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_REGIAO < 1 || LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_REGIAO > 4)
            {

                /*" -408- MOVE '  LT3151S-COD REGIAO INVALIDO ' TO LT3151-MSG-RETORNO */
                _.Move("  LT3151S-COD REGIAO INVALIDO ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -409- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -410- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -411- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -413- END-IF */
            }


            /*" -414- IF LT3151-NUM-CLASSE-ADESAO < 1 OR > 5 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO < 1 || LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO > 5)
            {

                /*" -416- MOVE '  LT3151S-NUM CLASSE  INVALIDO ' TO LT3151-MSG-RETORNO */
                _.Move("  LT3151S-NUM CLASSE  INVALIDO ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -417- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -418- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -419- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -421- END-IF */
            }


            /*" -422- IF LT3151-PCT-IOF EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF == 00)
            {

                /*" -424- MOVE ' LT3151S-PERCENTUAL IOF ZERADO   ' TO LT3151-MSG-RETORNO */
                _.Move(" LT3151S-PERCENTUAL IOF ZERADO   ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -425- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -426- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -427- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -429- END-IF */
            }


            /*" -430- IF LT3151-VLR-MIN-SAP EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP == 00)
            {

                /*" -432- MOVE ' LT3151S-VALOR MINIMO DA SAP  INVALIDO   ' TO LT3151-MSG-RETORNO */
                _.Move(" LT3151S-VALOR MINIMO DA SAP  INVALIDO   ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -433- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -434- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -435- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -437- END-IF */
            }


            /*" -438- IF LT3151-VLR-MIN-PRMLIQ EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ == 00)
            {

                /*" -440- MOVE ' LT3151S-VALOR MINIMO DO PREMIO LIQ INVALIDO ' TO LT3151-MSG-RETORNO */
                _.Move(" LT3151S-VALOR MINIMO DO PREMIO LIQ INVALIDO ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -441- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -442- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -443- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -445- END-IF */
            }


            /*" -452- IF (LT3171-PRODUTO = 1805 AND LT3151-DTINIVIG-APOLICE < '2015-11-01' ) OR (LT3171-PRODUTO = 1803 AND LT3151-DTINIVIG-APOLICE < '2016-01-01' ) */

            if ((LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO == 1805 && LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE < "2015-11-01") || (LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO == 1803 && LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE < "2016-01-01"))
            {

                /*" -453- IF LT3151-VLR-TAXA-ADESAO = ZEROS */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO == 00)
                {

                    /*" -455- MOVE 'LT3151S-VALOR TAXA DE ADESAO INVALIDO' TO LT3151-MSG-RETORNO */
                    _.Move("LT3151S-VALOR TAXA DE ADESAO INVALIDO", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                    /*" -456- DISPLAY LT3151-MSG-RETORNO */
                    _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                    /*" -457- MOVE 1 TO LT3151-COD-RETORNO */
                    _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                    /*" -458- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -459- END-IF */
                }


                /*" -462- END-IF */
            }


            /*" -463- IF LT3151-TIPO-CALCULO EQUAL 'PR' OR 'PC' OR '  ' */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO.In("PR", "PC", " "))
            {

                /*" -464- MOVE 0 TO LT3151-COD-RETORNO */
                _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -465- ELSE */
            }
            else
            {


                /*" -467- MOVE ' LT3151S-TIPO CALCULO PR/PC ' TO LT3151-MSG-RETORNO */
                _.Move(" LT3151S-TIPO CALCULO PR/PC ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -468- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -469- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -470- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -472- END-IF */
            }


            /*" -473- MOVE LT3151-DTINIVIG-APOLICE TO WS-DATA-SQL-AUX */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE, WS_AREA_TRABALHO.WS_DATA_SQL_AUX);

            /*" -474- PERFORM R0140-CRITICA-DATA-SQL */

            R0140_CRITICA_DATA_SQL_SECTION();

            /*" -475- IF WS-ERRO > ZEROS */

            if (WS_AREA_TRABALHO.WS_ERRO > 00)
            {

                /*" -477- MOVE ' LT3151S-DTINIVIG-APOLICE - INVALIDA ' TO LT3151-MSG-RETORNO */
                _.Move(" LT3151S-DTINIVIG-APOLICE - INVALIDA ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -478- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -479- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -480- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -490- END-IF */
            }


            /*" -492- MOVE LT3159S-TB-VALOR-DT(52) TO LT3151-DTTERVIG-APOLICE */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[52].LT3159S_TB_VALOR_DT, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE);

            /*" -493- PERFORM R0140-CRITICA-DATA-SQL */

            R0140_CRITICA_DATA_SQL_SECTION();

            /*" -494- IF WS-ERRO > ZEROS */

            if (WS_AREA_TRABALHO.WS_ERRO > 00)
            {

                /*" -496- MOVE 'LT3151S-DTTERVIG-APOLICE - INVALIDA ' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S-DTTERVIG-APOLICE - INVALIDA ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -497- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -498- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -499- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -501- END-IF */
            }


            /*" -502- IF LT3151-DTINIVIG-APOLICE >= LT3151-DTTERVIG-APOLICE */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE >= LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE)
            {

                /*" -504- MOVE 'LT3151S-DTINIVIG >= DTTERVIG ' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S-DTINIVIG >= DTTERVIG ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -505- MOVE 121 TO LT3151-COD-RETORNO */
                _.Move(121, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -507- DISPLAY 'LT3151S-R0100-DTINI =' LT3151-DTINIVIG-APOLICE ' DTTER =' LT3151-DTTERVIG-APOLICE */

                $"LT3151S-R0100-DTINI ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE} DTTER ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE}"
                .Display();

                /*" -508- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -509- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -518- END-IF */
            }


            /*" -520- MOVE LT3151-DTINIVIG-APOLICE TO WS-DATA-SQL-AUX */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE, WS_AREA_TRABALHO.WS_DATA_SQL_AUX);

            /*" -522- IF WS-MES-SQL-AUX EQUAL 1 AND WS-DIA-SQL-AUX EQUAL 1 */

            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX == 1 && WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX == 1)
            {

                /*" -523- MOVE ' ' TO LT3151-TIPO-CALCULO */
                _.Move(" ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO);

                /*" -524- ELSE */
            }
            else
            {


                /*" -525- MOVE 'PR' TO LT3151-TIPO-CALCULO */
                _.Move("PR", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO);

                /*" -532- END-IF */
            }


            /*" -535- IF (LT3171-PRODUTO = 1805 ) AND (LT3151-DTINIVIG-APOLICE >= '2019-11-01' ) AND (LT3151-DTINIVIG-APOLICE <= '2019-12-31' ) */

            if ((LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO == 1805) && (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE >= "2019-11-01") && (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE <= "2019-12-31"))
            {

                /*" -536- DISPLAY 'TIPO CALCULO NORMAL - RENOVACAO CCA 2019' */
                _.Display($"TIPO CALCULO NORMAL - RENOVACAO CCA 2019");

                /*" -537- MOVE ' ' TO LT3151-TIPO-CALCULO */
                _.Move(" ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO);

                /*" -545- END-IF */
            }


            /*" -546- IF LT3151-COD-RETORNO GREATER ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO > 00)
            {

                /*" -547- PERFORM R9000-00-ROT-RETORNO */

                R9000_00_ROT_RETORNO_SECTION();

                /*" -549- END-IF */
            }


            /*" -550- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -551- DISPLAY WS-VERSAO */
                _.Display(WS_AREA_TRABALHO.WS_VERSAO);

                /*" -552- END-IF */
            }


            /*" -552- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0105-00-LER-PERIODO-VIGENTE-SECTION */
        private void R0105_00_LER_PERIODO_VIGENTE_SECTION()
        {
            /*" -598- MOVE 0 TO WS-QT-REG */
            _.Move(0, WS_AREA_TRABALHO.WS_QT_REG);

            /*" -599- MOVE 'LT3179B' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("LT3179B", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -601- MOVE LT3171-PRODUTO TO LTSOLPAR-COD-PRODUTO */
            _.Move(LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -608- PERFORM R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1 */

            R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1();

            /*" -611- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -613- MOVE 'LT3151S - ERRO NA LEITURA TABELA LT_SOLICITA_PARAM' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S - ERRO NA LEITURA TABELA LT_SOLICITA_PARAM", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -614- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -615- DISPLAY 'LT3151S-COD-PROGRAMA ' LTSOLPAR-COD-PROGRAMA */
                _.Display($"LT3151S-COD-PROGRAMA {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA}");

                /*" -616- DISPLAY 'LT3151S-COD-PRODUTO ' LTSOLPAR-COD-PRODUTO */
                _.Display($"LT3151S-COD-PRODUTO {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO}");

                /*" -617- MOVE 105 TO LT3151-COD-RETORNO */
                _.Move(105, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -618- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -620- END-IF */
            }


            /*" -622- INITIALIZE LT3159S-AREA-PARAMETROS */
            _.Initialize(
                LBLT3159.LT3159S_AREA_PARAMETROS
            );

            /*" -623- IF WS-QT-REG > 0 */

            if (WS_AREA_TRABALHO.WS_QT_REG > 0)
            {

                /*" -624- MOVE 'SIMULACAO' TO LT3159S-NOME */
                _.Move("SIMULACAO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME);

                /*" -625- ELSE */
            }
            else
            {


                /*" -626- MOVE SPACES TO LT3159S-NOME */
                _.Move("", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME);

                /*" -628- END-IF */
            }


            /*" -629- MOVE '04' TO LT3159S-OPERACAO */
            _.Move("04", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO);

            /*" -632- MOVE 0 TO LT3159S-PARAM LT3159S-VALOR */
            _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR);

            /*" -633- MOVE LT3171-PRODUTO TO LT3159S-COD-PRODUTO */
            _.Move(LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO);

            /*" -634- MOVE LT3151-DTINIVIG-APOLICE TO LT3159S-DATA-INIVIGENCIA */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA);

            /*" -637- MOVE 'LT3159S' TO WS-NM-PROGRAMA */
            _.Move("LT3159S", WS_AREA_TRABALHO.WS_NM_PROGRAMA);

            /*" -639- CALL 'LT3159S' USING LT3159S-AREA-PARAMETROS */
            _.Call("LT3159S", LBLT3159.LT3159S_AREA_PARAMETROS);

            /*" -640- IF LT3159S-COD-RETORNO > 0 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO > 0)
            {

                /*" -642- MOVE 'LT3151S - R0105-NAO TEM PARAMETROS' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S - R0105-NAO TEM PARAMETROS", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -643- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -644- DISPLAY 'LT3151S-ANO PERIODO = ' LT3159S-ANO-RENOVACAO */
                _.Display($"LT3151S-ANO PERIODO = {LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_ANO_RENOVACAO}");

                /*" -645- DISPLAY 'LT3151S-DTINIVIG = ' LT3151-DTINIVIG-APOLICE */
                _.Display($"LT3151S-DTINIVIG = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE}");

                /*" -646- MOVE 105 TO LT3151-COD-RETORNO */
                _.Move(105, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -647- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -649- END-IF */
            }


            /*" -650- MOVE LT3159S-TB-VALOR (1) TO LT3151-CUSTO-APOLICE */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[1].LT3159S_TB_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE);

            /*" -651- MOVE LT3159S-TB-VALOR (2) TO LT3151-PCT-IOF */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[2].LT3159S_TB_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF);

            /*" -652- MOVE LT3159S-TB-VALOR (11) TO LT3151-VLR-TAXA-ADESAO */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[11].LT3159S_TB_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO);

            /*" -653- MOVE LT3159S-TB-VALOR (67) TO LT3151-VLR-ADIC-COBER */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[67].LT3159S_TB_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_ADIC_COBER);

            /*" -654- MOVE LT3159S-TB-VALOR-DT(68) TO WS-DISPLAY */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[68].LT3159S_TB_VALOR_DT, WS_AREA_TRABALHO.WS_DISPLAY);

            /*" -655- MOVE LT3159S-TB-VALOR (69) TO LT3151-VLR-MIN-SAP */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[69].LT3159S_TB_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP);

            /*" -657- MOVE LT3159S-TB-VALOR (70) TO LT3151-VLR-MIN-PRMLIQ */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[70].LT3159S_TB_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ);

            /*" -658- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -659- DISPLAY 'LT3151S-R0105 PARAMETROS *******' */
                _.Display($"LT3151S-R0105 PARAMETROS *******");

                /*" -660- DISPLAY 'LT3151S-CUSTO-APOLICE   =' LT3151-CUSTO-APOLICE */
                _.Display($"LT3151S-CUSTO-APOLICE   ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE}");

                /*" -661- DISPLAY 'LT3151S-PCT-IOF         =' LT3151-PCT-IOF */
                _.Display($"LT3151S-PCT-IOF         ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF}");

                /*" -662- DISPLAY 'LT3151S-VLR-TAXA-ADESAO =' LT3151-VLR-TAXA-ADESAO */
                _.Display($"LT3151S-VLR-TAXA-ADESAO ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO}");

                /*" -663- DISPLAY 'LT3151S-VLR-ADIC-COBER  =' LT3151-VLR-ADIC-COBER */
                _.Display($"LT3151S-VLR-ADIC-COBER  ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_ADIC_COBER}");

                /*" -664- DISPLAY 'LT3151S-WS-DISPLAY      =' WS-DISPLAY */
                _.Display($"LT3151S-WS-     ={WS_AREA_TRABALHO.WS_DISPLAY}");

                /*" -665- DISPLAY 'LT3151S-VLR-MIN-SAP     =' LT3151-VLR-MIN-SAP */
                _.Display($"LT3151S-VLR-MIN-SAP     ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP}");

                /*" -666- DISPLAY 'LT3151S-VLR-MIN-PRMLIQ  =' LT3151-VLR-MIN-PRMLIQ */
                _.Display($"LT3151S-VLR-MIN-PRMLIQ  ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ}");

                /*" -666- END-IF. */
            }


        }

        [StopWatch]
        /*" R0105-00-LER-PERIODO-VIGENTE-DB-SELECT-1 */
        public void R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1()
        {
            /*" -608- EXEC SQL SELECT COUNT(*) INTO :WS-QT-REG FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO WITH UR END-EXEC */

            var r0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1 = new R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1()
            {
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1.Execute(r0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_REG, WS_AREA_TRABALHO.WS_QT_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-VERIFICA-PRODUTO-SECTION */
        private void R0110_00_VERIFICA_PRODUTO_SECTION()
        {
            /*" -682- INITIALIZE LT3171-AREA-PARAMETROS */
            _.Initialize(
                LBLT3171.LT3171_AREA_PARAMETROS
            );

            /*" -683- MOVE 'LT3171S' TO WS-NM-PROGRAMA */
            _.Move("LT3171S", WS_AREA_TRABALHO.WS_NM_PROGRAMA);

            /*" -686- MOVE LT3151-COD-LOTERICO TO LT3171-NUM-LOTERICO */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO, LBLT3171.LT3171_AREA_PARAMETROS.LT3171_NUM_LOTERICO);

            /*" -688- CALL 'LT3171S' USING LT3171-AREA-PARAMETROS */
            _.Call("LT3171S", LBLT3171.LT3171_AREA_PARAMETROS);

            /*" -689- IF LT3171-COD-RETORNO > ZEROS */

            if (LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO > 00)
            {

                /*" -690- DISPLAY 'LT3171S-R0010-ERRO CALL LT3171S' */
                _.Display($"LT3171S-R0010-ERRO CALL LT3171S");

                /*" -690- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-INICIALIZAR-VARIAVEIS-SECTION */
        private void R0120_INICIALIZAR_VARIAVEIS_SECTION()
        {
            /*" -701- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 20); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -705- MOVE 0 TO TB-PREMIO-LIQ (WS-IND) TB-PREMIO-LIQ-1PCL (WS-IND) TB-IOF (WS-IND) LT3151-PREMIOS (WS-IND) */
                _.Move(0, WS_AREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WS_AREA_TRABALHO.WS_IND], WS_AREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WS_AREA_TRABALHO.WS_IND], WS_AREA_TRABALHO.TAB_IOF.TB_IOF[WS_AREA_TRABALHO.WS_IND], LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_PREMIOS.LT3151_TAB_PREMIOS[WS_AREA_TRABALHO.WS_IND].LT3151_PREMIOS);

                /*" -707- END-PERFORM */
            }

            /*" -737- MOVE 0 TO LT3151-VL-PREMIO-TOTAL LT3151-VL-PREMIO-TOTAL-1PCL LT3151-VL-BOLETO LT3151-ADICIONAL-TOTAL LT3151-JURO-TOTAL LT3151-IOF-TOTAL LT3151-COD-RETORNO LT3151-IOF-PCL1 LT3151-ADICIONAL-FRAC-PCL1 LT3151-JUROS-PCL1 LT3151-PERC-JUROS-PCL1 LT3151-VL-PREMIO-LIQ-PCL1 LT3151-VL-PREMIO-PCL1 LT3151-IOF-PCLN LT3151-ADICIONAL-FRAC-PCLN LT3151-JUROS-PCLN LT3151-PERC-JUROS-PCLN LT3151-VL-PREMIO-LIQ-PCLN LT3151-VL-PREMIO-PCLN WTOTAL-PREMIO-LIQNP LT3151-DESC-FIDEL LT3151-DESC-EXP LT3151-DESC-AGRUP LT3151-NUM-APOL-DESC LT3151-VL-SUBTOTAL WS-IOF-PRIM WS-IOF-OUTR WSQLCODE WS-ERRO SQLCODE. */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL_1PCL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_BOLETO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_TOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_TOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_FRAC_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PERC_JUROS_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_FRAC_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PERC_JUROS_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN, WS_AREA_TRABALHO.WTOTAL_PREMIO_LIQNP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_FIDEL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_EXP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_AGRUP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOL_DESC, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL, WS_AREA_TRABALHO.WS_IOF_PRIM, WS_AREA_TRABALHO.WS_IOF_OUTR, WS_AREA_TRABALHO.WABEND.WSQLCODE, WS_AREA_TRABALHO.WS_ERRO, DB.SQLCODE);

            /*" -737- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0140-CRITICA-DATA-SQL-SECTION */
        private void R0140_CRITICA_DATA_SQL_SECTION()
        {
            /*" -751- MOVE 0 TO WS-ERRO. */
            _.Move(0, WS_AREA_TRABALHO.WS_ERRO);

            /*" -757- IF WS-ANO-SQL-AUX LESS THAN 1900 OR WS-ANO-SQL-AUX GREATER 3000 OR WS-MES-SQL-AUX LESS THAN 1 OR WS-MES-SQL-AUX GREATER 12 OR WS-DIA-SQL-AUX LESS THAN 1 OR WS-DIA-SQL-AUX GREATER 31 */

            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX < 1900 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX > 3000 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX < 1 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX > 12 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX < 1 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 31)
            {

                /*" -758- MOVE 1 TO WS-ERRO */
                _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                /*" -759- ELSE */
            }
            else
            {


                /*" -760- IF WS-MES-SQL-AUX EQUAL 4 OR 6 OR 9 OR 11 */

                if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX.In("4", "6", "9", "11"))
                {

                    /*" -761- IF WS-DIA-SQL-AUX GREATER 30 */

                    if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 30)
                    {

                        /*" -762- MOVE 1 TO WS-ERRO */
                        _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                        /*" -764- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -765- ELSE */
                    }

                }
                else
                {


                    /*" -766- IF WS-MES-SQL-AUX EQUAL 2 */

                    if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX == 2)
                    {

                        /*" -768- DIVIDE WS-ANO-SQL-AUX BY 4 GIVING WS-IND REMAINDER WS-IND1 */
                        _.Divide(WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX, 4, WS_AREA_TRABALHO.WS_IND, WS_AREA_TRABALHO.WS_IND1);

                        /*" -769- IF WS-IND1 GREATER ZEROS */

                        if (WS_AREA_TRABALHO.WS_IND1 > 00)
                        {

                            /*" -770- IF WS-DIA-SQL-AUX GREATER 28 */

                            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 28)
                            {

                                /*" -771- MOVE 1 TO WS-ERRO */
                                _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                                /*" -773- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -774- ELSE */
                            }

                        }
                        else
                        {


                            /*" -775- IF WS-DIA-SQL-AUX GREATER 29 */

                            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 29)
                            {

                                /*" -776- MOVE 1 TO WS-ERRO */
                                _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                                /*" -778- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -779- ELSE */
                            }

                        }

                    }
                    else
                    {


                        /*" -780- IF WS-DIA-SQL-AUX GREATER 31 */

                        if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 31)
                        {

                            /*" -781- MOVE 1 TO WS-ERRO. */
                            _.Move(1, WS_AREA_TRABALHO.WS_ERRO);
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0293-00-MONTAR-COEF-2009-SECTION */
        private void R0293_00_MONTAR_COEF_2009_SECTION()
        {
            /*" -861- MOVE LT3151-NUM-CLASSE-ADESAO TO LT3150-NUM-CLASSE */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE);

            /*" -862- MOVE LT3151-COD-REGIAO TO LT3150-COD-REGIAO */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_REGIAO, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_REGIAO);

            /*" -863- MOVE LT3151-DTINIVIG-APOLICE TO LT3150-DTINIVIG */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTINIVIG);

            /*" -864- MOVE LT3151-DTTERVIG-APOLICE TO LT3150-DTTERVIG */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTTERVIG);

            /*" -865- MOVE ZEROS TO LT3150-COD-RETORNO */
            _.Move(0, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO);

            /*" -866- MOVE SPACES TO LT3150-DISPLAY */
            _.Move("", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DISPLAY);

            /*" -867- MOVE SPACES TO LT3150-MENSAGEM */
            _.Move("", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM);

            /*" -870- MOVE 'LT3150S' TO WS-NM-PROGRAMA */
            _.Move("LT3150S", WS_AREA_TRABALHO.WS_NM_PROGRAMA);

            /*" -872- CALL 'LT3150S' USING LT3150-AREA-PARAMETROS */
            _.Call("LT3150S", LBLT3150.LT3150_AREA_PARAMETROS);

            /*" -873- IF LT3150-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO != 00)
            {

                /*" -874- MOVE LT3150-COD-RETORNO TO LT3151-COD-RETORNO */
                _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -875- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -876- GO TO R0293-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0293_99_SAIDA*/ //GOTO
                return;

                /*" -878- END-IF */
            }


            /*" -879- MOVE 0 TO WS-ERRO */
            _.Move(0, WS_AREA_TRABALHO.WS_ERRO);

            /*" -880- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 12 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 12); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -881- MOVE LT3150-PCT-COEFICIENTE(WS-IND) TO LT3151-COEF(WS-IND) */
                _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[WS_AREA_TRABALHO.WS_IND].LT3150_PCT_COEFICIENTE, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[WS_AREA_TRABALHO.WS_IND].LT3151_COEF);

                /*" -882- IF LT3151-COEF(WS-IND) EQUAL ZEROS */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[WS_AREA_TRABALHO.WS_IND].LT3151_COEF == 00)
                {

                    /*" -883- ADD 1 TO WS-ERRO */
                    WS_AREA_TRABALHO.WS_ERRO.Value = WS_AREA_TRABALHO.WS_ERRO + 1;

                    /*" -884- END-IF */
                }


                /*" -886- END-PERFORM */
            }

            /*" -887- IF WS-ERRO > 0 */

            if (WS_AREA_TRABALHO.WS_ERRO > 0)
            {

                /*" -889- MOVE 'LT3151S-R0293-COEFICIENTES ZERADOS - INVALIDO' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S-R0293-COEFICIENTES ZERADOS - INVALIDO", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -890- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -891- MOVE 293 TO LT3151-COD-RETORNO */
                _.Move(293, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -892- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0293_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -971- PERFORM R0100-CRITICA-PARAMETROS */

            R0100_CRITICA_PARAMETROS_SECTION();

            /*" -975- PERFORM R2200-CALCULAR-FATOR-PRORATA */

            R2200_CALCULAR_FATOR_PRORATA_SECTION();

            /*" -976- PERFORM R0293-00-MONTAR-COEF-2009 */

            R0293_00_MONTAR_COEF_2009_SECTION();

            /*" -977- IF LT3151-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO != 00)
            {

                /*" -978- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -983- END-IF */
            }


            /*" -987- COMPUTE WS-PCT-IOF = LT3151-PCT-IOF / 100 */
            WS_AREA_TRABALHO.WS_PCT_IOF.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF / 100f;

            /*" -988- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -992- DISPLAY 'LT3151S-R1000-QTD PARCELAS = ' LT3151-QTD-PARCELAS ' CRITICAR-PRM-LIQ=' LT3151-CRITICAR-PRMLIQ ' ORDEM=' WS-ORDEM ' PCT-IOF=' WS-PCT-IOF */

                $"LT3151S-R1000-QTD PARCELAS = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS} CRITICAR-PRM-LIQ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ} ORDEM={WS_AREA_TRABALHO.WS_ORDEM} PCT-IOF={WS_AREA_TRABALHO.WS_PCT_IOF}"
                .Display();

                /*" -992- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_CALCULAR_PREMIO */

            R1000_10_CALCULAR_PREMIO();

        }

        [StopWatch]
        /*" R1000-10-CALCULAR-PREMIO */
        private void R1000_10_CALCULAR_PREMIO(bool isPerform = false)
        {
            /*" -998- PERFORM R0120-INICIALIZAR-VARIAVEIS */

            R0120_INICIALIZAR_VARIAVEIS_SECTION();

            /*" -1000- MOVE ZEROS TO WS-VALOR-PREMIO */
            _.Move(0, WS_AREA_TRABALHO.WS_VALOR_PREMIO);

            /*" -1001- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 20); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -1003- IF LT3151-IMPSEG(WS-IND) GREATER ZEROS AND LT3151-TAXAS (WS-IND) GREATER ZEROS */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND].LT3151_IMPSEG > 00 && LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_AREA_TRABALHO.WS_IND].LT3151_TAXAS > 00)
                {

                    /*" -1004- PERFORM R2000-CALCULAR-PREMIOS */

                    R2000_CALCULAR_PREMIOS_SECTION();

                    /*" -1005- END-IF */
                }


                /*" -1007- END-PERFORM */
            }

            /*" -1011- PERFORM R1200-00-CALCULAR-PARCELAS */

            R1200_00_CALCULAR_PARCELAS_SECTION();

            /*" -1012- IF LT3151-CRITICAR-PRMLIQ EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ == 00)
            {

                /*" -1013- DISPLAY 'LT3151S-SAIDA CRITICAR ZERADO ??????' */
                _.Display($"LT3151S-SAIDA CRITICAR ZERADO ??????");

                /*" -1014- GO TO R1000-90-FIM-CALCULO */

                R1000_90_FIM_CALCULO(); //GOTO
                return;

                /*" -1016- END-IF */
            }


            /*" -1019- IF (LT3151-VL-PREMIO-LIQ < LT3151-VLR-MIN-PRMLIQ) OR (LT3151-VL-PREMIO-PCL1 LESS THAN (LT3151-VLR-TAXA-ADESAO + LT3151-VLR-MIN-SAP)) */

            if ((LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ < LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ) || (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1 < (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP)))
            {

                /*" -1020- MOVE 'SIM' TO WS-HOUVE-ALTERACAO */
                _.Move("SIM", WS_AREA_TRABALHO.WS_HOUVE_ALTERACAO);

                /*" -1021- IF LT3151-QTD-PARCELAS > 1 */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS > 1)
                {

                    /*" -1022- COMPUTE LT3151-QTD-PARCELAS = LT3151-QTD-PARCELAS - 1 */
                    LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS - 1;

                    /*" -1023- MOVE 1 TO LT3151-CRITICAR-PRMLIQ */
                    _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ);

                    /*" -1024- MOVE LT3151-QTD-PARCELAS TO WS-INDICE-SAIDA */
                    _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS, WS_AREA_TRABALHO.WS_INDICE_SAIDA);

                    /*" -1025- MOVE SPACES TO LT3151-MSG-RETORNO */
                    _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                    /*" -1030- STRING 'LT3151S-' 'PRMLIQ/VLR.1PCL AJUSTADO PELA QTD PARCELAS' ' ' WS-INDICE-SAIDA DELIMITED BY SIZE INTO LT3151-MSG-RETORNO END-STRING */
                    #region STRING
                    var spl1 = "LT3151S-" + "PRMLIQ/VLR.1PCL AJUSTADO PELA QTD PARCELAS" + " " + WS_AREA_TRABALHO.WS_INDICE_SAIDA.GetMoveValues();
                    _.Move(spl1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);
                    #endregion

                    /*" -1031- DISPLAY LT3151-MSG-RETORNO */
                    _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                    /*" -1032- ELSE */
                }
                else
                {


                    /*" -1033- IF WS-ORDEM <= 15 */

                    if (WS_AREA_TRABALHO.WS_ORDEM <= 15)
                    {

                        /*" -1034- DISPLAY 'LT3151S-ORDEM MENOR QUE 15 ORDEM=' WS-ORDEM */
                        _.Display($"LT3151S-ORDEM MENOR QUE 15 ORDEM={WS_AREA_TRABALHO.WS_ORDEM}");

                        /*" -1035- MOVE TB-ORDEM-COBER(WS-ORDEM) TO WS-IND2 */
                        _.Move(WS_AREA_TRABALHO.TABELA_ORDEM_COBER.TAB_ORDEM_COBER_R.TB_ORDEM_COBER[WS_AREA_TRABALHO.WS_ORDEM], WS_AREA_TRABALHO.WS_IND2);

                        /*" -1036- MOVE 2 TO LT3151-CRITICAR-PRMLIQ */
                        _.Move(2, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ);

                        /*" -1037- IF LT3171-PRODUTO EQUAL 1803 */

                        if (LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO == 1803)
                        {

                            /*" -1038- PERFORM R1300-00-AJUSTAR-IMPSEG */

                            R1300_00_AJUSTAR_IMPSEG_SECTION();

                            /*" -1039- ELSE */
                        }
                        else
                        {


                            /*" -1040- PERFORM R1350-00-AJUSTAR-IMPSEG-CCA */

                            R1350_00_AJUSTAR_IMPSEG_CCA_SECTION();

                            /*" -1041- END-IF */
                        }


                        /*" -1042- MOVE LT3151-QTD-PARCELAS TO WS-INDICE-SAIDA */
                        _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS, WS_AREA_TRABALHO.WS_INDICE_SAIDA);

                        /*" -1043- MOVE SPACES TO LT3151-MSG-RETORNO */
                        _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                        /*" -1049- STRING 'LT3151S-' 'PRMLIQ/VLR.1PCL AJUSTADO PELA IMP.SEG' ' ' WS-INDICE-SAIDA ' -  COBER=' WS-IND2 DELIMITED BY SIZE INTO LT3151-MSG-RETORNO END-STRING */
                        #region STRING
                        var spl2 = "LT3151S-" + "PRMLIQ/VLR.1PCL AJUSTADO PELA IMP.SEG" + " " + WS_AREA_TRABALHO.WS_INDICE_SAIDA.GetMoveValues();
                        spl2 += " - COBER=";
                        var spl3 = WS_AREA_TRABALHO.WS_IND2.GetMoveValues();
                        var results4 = spl2 + spl3;
                        _.Move(results4, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);
                        #endregion

                        /*" -1050- DISPLAY LT3151-MSG-RETORNO */
                        _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                        /*" -1051- ELSE */
                    }
                    else
                    {


                        /*" -1052- MOVE 3 TO LT3151-CRITICAR-PRMLIQ */
                        _.Move(3, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ);

                        /*" -1053- MOVE SPACES TO LT3151-MSG-RETORNO */
                        _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                        /*" -1058- STRING 'LT3151S-' 'PRMLIQ E VLR.1PCL IMPOSSIVEL EFETUAR AJUSTE' ' COM ESSES VALORES ' DELIMITED BY SIZE INTO LT3151-MSG-RETORNO END-STRING */
                        #region STRING
                        var spl4 = "LT3151S-" + "PRMLIQ E VLR.1PCL IMPOSSIVEL EFETUAR AJUSTE" + " COM ESSES VALORES ";
                        _.Move(spl4, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);
                        #endregion

                        /*" -1059- DISPLAY LT3151-MSG-RETORNO */
                        _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                        /*" -1060- GO TO R1000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;

                        /*" -1061- END-IF */
                    }


                    /*" -1062- END-IF */
                }


                /*" -1063- GO TO R1000-10-CALCULAR-PREMIO */
                new Task(() => R1000_10_CALCULAR_PREMIO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1063- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-90-FIM-CALCULO */
        private void R1000_90_FIM_CALCULO(bool isPerform = false)
        {
            /*" -1068- IF (LT3151-VL-PREMIO-LIQ < LT3151-VLR-MIN-PRMLIQ) */

            if ((LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ < LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ))
            {

                /*" -1069- MOVE SPACES TO LT3151-MSG-RETORNO */
                _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1070- MOVE LT3151-VLR-MIN-PRMLIQ TO WS-VALOR-SAIDA */
                _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ, WS_AREA_TRABALHO.WS_VALOR_SAIDA);

                /*" -1075- STRING 'LT3151S-' 'PREMIO LIQUIDO INF AO MINIMO DE ' ' ' WS-VALOR-SAIDA DELIMITED BY SIZE INTO LT3151-MSG-RETORNO END-STRING */
                #region STRING
                var spl5 = "LT3151S-" + "PREMIO LIQUIDO INF AO MINIMO DE " + " " + WS_AREA_TRABALHO.WS_VALOR_SAIDA.GetMoveValues();
                _.Move(spl5, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);
                #endregion

                /*" -1076- DISPLAY 'LT3151S-WS-VALOR-SAIDA=' WS-VALOR-SAIDA */
                _.Display($"LT3151S-WS-VALOR-SAIDA={WS_AREA_TRABALHO.WS_VALOR_SAIDA}");

                /*" -1077- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1079- END-IF */
            }


            /*" -1081- COMPUTE WS-VALOR = LT3151-VLR-TAXA-ADESAO + LT3151-VLR-MIN-SAP */
            WS_AREA_TRABALHO.WS_VALOR.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP;

            /*" -1083- MOVE WS-VALOR TO WS-VALOR-SAIDA */
            _.Move(WS_AREA_TRABALHO.WS_VALOR, WS_AREA_TRABALHO.WS_VALOR_SAIDA);

            /*" -1084- IF (LT3151-VL-PREMIO-PCL1 LESS THAN WS-VALOR ) */

            if ((LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1 < WS_AREA_TRABALHO.WS_VALOR))
            {

                /*" -1085- MOVE SPACES TO LT3151-MSG-RETORNO */
                _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1090- STRING 'LT3151S-' 'VALOR DA 1.PARCELA INFERIOR A ' ' ' WS-VALOR-SAIDA DELIMITED BY SIZE INTO LT3151-MSG-RETORNO END-STRING */
                #region STRING
                var spl6 = "LT3151S-" + "VALOR DA 1.PARCELA INFERIOR A " + " " + WS_AREA_TRABALHO.WS_VALOR_SAIDA.GetMoveValues();
                _.Move(spl6, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);
                #endregion

                /*" -1091- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1093- END-IF */
            }


            /*" -1093- PERFORM R1500-DISPLAY-CALCULO. */

            R1500_DISPLAY_CALCULO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CALCULAR-PARCELAS-SECTION */
        private void R1200_00_CALCULAR_PARCELAS_SECTION()
        {
            /*" -1103- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1104- DISPLAY 'LT3151S-R1200-CALCULANDO PCL COM IOF=' WS-PCT-IOF */
                _.Display($"LT3151S-R1200-CALCULANDO PCL COM IOF={WS_AREA_TRABALHO.WS_PCT_IOF}");

                /*" -1106- END-IF */
            }


            /*" -1109- COMPUTE LT3151-DESC-AGRUP = LT3151-VL-SUBTOTAL * LT3151-PCT-DESC-AGRUP / 100. */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_AGRUP.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_AGRUP / 100f;

            /*" -1112- COMPUTE LT3151-DESC-EXP = LT3151-VL-SUBTOTAL * LT3151-PCT-DESC-EXP / 100. */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_EXP.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_EXP / 100f;

            /*" -1115- COMPUTE LT3151-DESC-FIDEL = LT3151-VL-SUBTOTAL * LT3151-PCT-DESC-FIDEL / 100. */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_FIDEL.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_FIDEL / 100f;

            /*" -1118- COMPUTE LT3151-DESC-COFRE = LT3151-VL-SUBTOTAL * LT3151-PCT-DESC-COFRE / 100. */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_COFRE.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_COFRE / 100f;

            /*" -1122- COMPUTE LT3151-DESC-BLINDAGEM = LT3151-VL-SUBTOTAL * LT3151-PCT-DESC-BLINDAGEM / 100. */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_BLINDAGEM.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_BLINDAGEM / 100f;

            /*" -1124- PERFORM R1205-VERIFICA-DESC-RENOVA-INF */

            R1205_VERIFICA_DESC_RENOVA_INF_SECTION();

            /*" -1127- DISPLAY 'LT3151-TIPO-OPERACAO :' LT3151-TIPO-OPERACAO ' QTDRENPB:' LT3151-QTDRENOV */

            $"LT3151-TIPO-OPERACAO :{LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_OPERACAO} QTDRENPB:{LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTDRENOV}"
            .Display();

            /*" -1132- IF (WS-EXISTE-DESC-SEM-SINI-INF > 0 AND WS-EXISTE-DESC-SEM-SINI-INF < 11 ) OR ((LT3151-TIPO-OPERACAO EQUAL '06' OR '02' ) AND LT3151-QTDRENOV NOT EQUAL ZEROS ) */

            if ((WS_AREA_TRABALHO.WS_EXISTE_DESC_SEM_SINI_INF > 0 && WS_AREA_TRABALHO.WS_EXISTE_DESC_SEM_SINI_INF < 11) || ((LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_OPERACAO.In("06", "02")) && LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTDRENOV != 00))
            {

                /*" -1133- PERFORM R1206-VERIFICA-DESCONTO-MAX-70 */

                R1206_VERIFICA_DESCONTO_MAX_70_SECTION();

                /*" -1134- ELSE */
            }
            else
            {


                /*" -1135- PERFORM R1210-VERIFICA-DESCONTO-MAX-50 */

                R1210_VERIFICA_DESCONTO_MAX_50_SECTION();

                /*" -1139- END-IF */
            }


            /*" -1144- MOVE LT3151-VL-PREMIO-LIQ TO LT3151-VL-PREMIO-LIQ-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN);

            /*" -1151- COMPUTE LT3151-VL-PREMIO-PCL1 = LT3151-VL-PREMIO-LIQ * LT3151-COEF(LT3151-QTD-PARCELAS) + LT3151-CUSTO-APOLICE */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS].LT3151_COEF.Value + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE;

            /*" -1156- COMPUTE LT3151-VL-PREMIO-LIQ-PCL1 = LT3151-VL-PREMIO-LIQ * LT3151-COEF(LT3151-QTD-PARCELAS) */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCL1.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS].LT3151_COEF.Value;

            /*" -1162- COMPUTE LT3151-VL-PREMIO-TOTAL-1PCL ROUNDED = ( LT3151-VL-PREMIO-LIQ * LT3151-COEF( 1 ) + LT3151-CUSTO-APOLICE) * (1 + WS-PCT-IOF ) */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL_1PCL.Value = (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[1].LT3151_COEF.Value + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE) * (1 + WS_AREA_TRABALHO.WS_PCT_IOF);

            /*" -1165- COMPUTE LT3151-IOF-PCL1 ROUNDED = LT3151-VL-PREMIO-PCL1 * WS-PCT-IOF */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1 * WS_AREA_TRABALHO.WS_PCT_IOF;

            /*" -1168- COMPUTE LT3151-VL-PREMIO-PCL1 = LT3151-VL-PREMIO-PCL1 + LT3151-IOF-PCL1 */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1 + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1;

            /*" -1169- MOVE LT3151-VL-PREMIO-PCL1 TO LT3151-VL-PREMIO-TOTAL */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL);

            /*" -1173- MOVE LT3151-IOF-PCL1 TO LT3151-IOF-TOTAL */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_TOTAL);

            /*" -1175- IF LT3151-QTD-PARCELAS GREATER 1 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS > 1)
            {

                /*" -1178- COMPUTE LT3151-VL-PREMIO-LIQ-PCLN = LT3151-VL-PREMIO-LIQ * LT3151-COEF(LT3151-QTD-PARCELAS) */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS].LT3151_COEF.Value;

                /*" -1181- COMPUTE LT3151-IOF-PCLN ROUNDED = LT3151-VL-PREMIO-LIQ-PCLN * WS-PCT-IOF */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN * WS_AREA_TRABALHO.WS_PCT_IOF;

                /*" -1184- COMPUTE LT3151-VL-PREMIO-PCLN = LT3151-VL-PREMIO-LIQ-PCLN + LT3151-IOF-PCLN */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN;

                /*" -1189- COMPUTE LT3151-VL-PREMIO-TOTAL ROUNDED = LT3151-VL-PREMIO-PCL1 + (LT3151-VL-PREMIO-PCLN * (LT3151-QTD-PARCELAS - 1)) */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1 + (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN * (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS - 1));

                /*" -1192- COMPUTE LT3151-IOF-TOTAL = LT3151-IOF-PCL1 + (LT3151-IOF-PCLN * (LT3151-QTD-PARCELAS - 1)) */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_TOTAL.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1 + (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN * (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS - 1));

                /*" -1198- END-IF */
            }


            /*" -1206- COMPUTE LT3151-JURO-TOTAL ROUNDED = (LT3151-VL-PREMIO-LIQ * LT3151-COEF(LT3151-QTD-PARCELAS) * LT3151-QTD-PARCELAS ) - LT3151-VL-PREMIO-LIQ */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL.Value = (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS].LT3151_COEF.Value * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS) - LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ;

            /*" -1207- IF LT3151-JURO-TOTAL < 0,5 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL < 0.5)
            {

                /*" -1208- MOVE ZEROS TO LT3151-JURO-TOTAL */
                _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL);

                /*" -1213- END-IF */
            }


            /*" -1216- COMPUTE LT3151-JUROS-PCL1 ROUNDED = LT3151-JURO-TOTAL / LT3151-QTD-PARCELAS */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCL1.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL / LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS;

            /*" -1219- MOVE LT3151-JUROS-PCL1 TO LT3151-ADICIONAL-FRAC-PCL1 LT3151-JUROS-PCLN LT3151-ADICIONAL-FRAC-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_FRAC_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_FRAC_PCLN);

            /*" -1224- MOVE LT3151-JURO-TOTAL TO LT3151-ADICIONAL-TOTAL */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_TOTAL);

            /*" -1225- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 20); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -1226- MOVE TB-PREMIO-LIQ(WS-IND) TO LT3151-PREMIOS(WS-IND) */
                _.Move(WS_AREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WS_AREA_TRABALHO.WS_IND], LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_PREMIOS.LT3151_TAB_PREMIOS[WS_AREA_TRABALHO.WS_IND].LT3151_PREMIOS);

                /*" -1227- END-PERFORM */
            }

            /*" -1227- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1205-VERIFICA-DESC-RENOVA-INF-SECTION */
        private void R1205_VERIFICA_DESC_RENOVA_INF_SECTION()
        {
            /*" -1239- INITIALIZE WS-EXISTE-DESC-SEM-SINI-INF WS-COD-LOTERICO WS-DTINIVIG-APOLICE WS-DTTERVIG-APOLICE */
            _.Initialize(
                WS_AREA_TRABALHO.WS_EXISTE_DESC_SEM_SINI_INF
                , WS_AREA_TRABALHO.WS_COD_LOTERICO
                , WS_AREA_TRABALHO.WS_DTINIVIG_APOLICE
                , WS_AREA_TRABALHO.WS_DTTERVIG_APOLICE
            );

            /*" -1240- MOVE LT3151-COD-LOTERICO TO WS-COD-LOTERICO */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO, WS_AREA_TRABALHO.WS_COD_LOTERICO);

            /*" -1241- MOVE LT3151-DTINIVIG-APOLICE TO WS-DTINIVIG-APOLICE */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE, WS_AREA_TRABALHO.WS_DTINIVIG_APOLICE);

            /*" -1243- MOVE LT3151-DTTERVIG-APOLICE TO WS-DTTERVIG-APOLICE */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE, WS_AREA_TRABALHO.WS_DTTERVIG_APOLICE);

            /*" -1265- PERFORM R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1 */

            R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1();

            /*" -1268- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1273- DISPLAY 'LT3151S-*** PROBLEMAS NO SELECT QTD DE RENOVA' ' ' LT3151-NUM-APOLICE ' ' LT3151-DTINIVIG-APOLICE ' ' LT3151-DTTERVIG-APOLICE ' ' SQLCODE */

                $"LT3151S-*** PROBLEMAS NO SELECT QTD DE RENOVA {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOLICE} {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE} {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE} {DB.SQLCODE}"
                .Display();

                /*" -1275- MOVE 'LT3151S-ERRO SELECT QTD DE RENOVACAO ' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S-ERRO SELECT QTD DE RENOVACAO ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1276- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1277- MOVE 1 TO LT3151-COD-RETORNO */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -1278- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1278- END-IF. */
            }


        }

        [StopWatch]
        /*" R1205-VERIFICA-DESC-RENOVA-INF-DB-SELECT-1 */
        public void R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1()
        {
            /*" -1265- EXEC SQL SELECT VALUE(A.QTD_REN_SEM_SINI,0) ,VALUE(A.QTD_REN_SEM_SINI_INF,11) INTO :WS-EXISTE-DESC-SEM-SINI ,:WS-EXISTE-DESC-SEM-SINI-INF FROM SEGUROS.LT_MOV_PROPOSTA A WHERE A.COD_EXT_SEGURADO = :WS-COD-LOTERICO AND A.DT_INIVIG_PROPOSTA BETWEEN :WS-DTINIVIG-APOLICE AND :WS-DTTERVIG-APOLICE AND A.QTD_REN_SEM_SINI_INF IS NOT NULL AND A.QTD_REN_SEM_SINI_INF NOT IN (11) AND A.SEQ_PROPOSTA = (SELECT MAX(B.SEQ_PROPOSTA) FROM SEGUROS.LT_MOV_PROPOSTA B WHERE B.COD_EXT_SEGURADO = :WS-COD-LOTERICO AND B.DT_INIVIG_PROPOSTA BETWEEN :WS-DTINIVIG-APOLICE AND :WS-DTTERVIG-APOLICE AND B.QTD_REN_SEM_SINI_INF IS NOT NULL AND B.QTD_REN_SEM_SINI_INF NOT IN (11)) WITH UR END-EXEC */

            var r1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1 = new R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1()
            {
                WS_DTINIVIG_APOLICE = WS_AREA_TRABALHO.WS_DTINIVIG_APOLICE.ToString(),
                WS_DTTERVIG_APOLICE = WS_AREA_TRABALHO.WS_DTTERVIG_APOLICE.ToString(),
                WS_COD_LOTERICO = WS_AREA_TRABALHO.WS_COD_LOTERICO.ToString(),
            };

            var executed_1 = R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1.Execute(r1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EXISTE_DESC_SEM_SINI, WS_AREA_TRABALHO.WS_EXISTE_DESC_SEM_SINI);
                _.Move(executed_1.WS_EXISTE_DESC_SEM_SINI_INF, WS_AREA_TRABALHO.WS_EXISTE_DESC_SEM_SINI_INF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1205_99_SAIDA*/

        [StopWatch]
        /*" R1206-VERIFICA-DESCONTO-MAX-70-SECTION */
        private void R1206_VERIFICA_DESCONTO_MAX_70_SECTION()
        {
            /*" -1290- DISPLAY 'DECONSTO MAX DE 70%' */
            _.Display($"DECONSTO MAX DE 70%");

            /*" -1293- INITIALIZE WS-70PCT-SUBTOTAL WS-TOTAL-DESCONTO */
            _.Initialize(
                WS_AREA_TRABALHO.WS_70PCT_SUBTOTAL
                , WS_AREA_TRABALHO.WS_TOTAL_DESCONTO
            );

            /*" -1295- COMPUTE WS-70PCT-SUBTOTAL = LT3151-VL-SUBTOTAL * 0,70 */
            WS_AREA_TRABALHO.WS_70PCT_SUBTOTAL.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * 0.70;

            /*" -1302- COMPUTE WS-TOTAL-DESCONTO = (LT3151-DESC-AGRUP + LT3151-DESC-EXP + LT3151-DESC-FIDEL + LT3151-DESC-COFRE + LT3151-DESC-BLINDAGEM ) */
            WS_AREA_TRABALHO.WS_TOTAL_DESCONTO.Value = (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_AGRUP + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_EXP + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_FIDEL + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_COFRE + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_BLINDAGEM);

            /*" -1303- COMPUTE WS-PCT-DESC-TOTAL = WS-TOTAL-DESCONTO * 100 */
            WS_AREA_TRABALHO.WS_PCT_DESC_TOTAL.Value = WS_AREA_TRABALHO.WS_TOTAL_DESCONTO * 100;

            /*" -1306- COMPUTE WS-PCT-DESC-ARRED ROUNDED = WS-PCT-DESC-TOTAL / LT3151-VL-SUBTOTAL */
            WS_AREA_TRABALHO.WS_PCT_DESC_ARRED.Value = WS_AREA_TRABALHO.WS_PCT_DESC_TOTAL / LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL;

            /*" -1307- IF WS-TOTAL-DESCONTO > WS-70PCT-SUBTOTAL */

            if (WS_AREA_TRABALHO.WS_TOTAL_DESCONTO > WS_AREA_TRABALHO.WS_70PCT_SUBTOTAL)
            {

                /*" -1309- COMPUTE LT3151-VL-PREMIO-LIQ = LT3151-VL-SUBTOTAL - WS-70PCT-SUBTOTAL */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL - WS_AREA_TRABALHO.WS_70PCT_SUBTOTAL;

                /*" -1310- MOVE WS-70PCT-SUBTOTAL TO LT3151-VL-DESC-TOTAIS */
                _.Move(WS_AREA_TRABALHO.WS_70PCT_SUBTOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_TOTAIS);

                /*" -1311- ELSE */
            }
            else
            {


                /*" -1313- COMPUTE LT3151-VL-PREMIO-LIQ = LT3151-VL-SUBTOTAL - WS-TOTAL-DESCONTO */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL - WS_AREA_TRABALHO.WS_TOTAL_DESCONTO;

                /*" -1314- MOVE WS-TOTAL-DESCONTO TO LT3151-VL-DESC-TOTAIS */
                _.Move(WS_AREA_TRABALHO.WS_TOTAL_DESCONTO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_TOTAIS);

                /*" -1316- END-IF */
            }


            /*" -1318- MOVE WS-PCT-DESC-ARRED TO LT3151-VL-DESC-CONCEDIDO */
            _.Move(WS_AREA_TRABALHO.WS_PCT_DESC_ARRED, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_CONCEDIDO);

            /*" -1319- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1327- DISPLAY 'LT3151S-======= DESCONTOS TOTAIS ======== ' ' SUB TOTAL = ' LT3151-VL-SUBTOTAL ' 70% = ' WS-70PCT-SUBTOTAL ' TOTAL = ' WS-TOTAL-DESCONTO ' LIQUIDO = ' LT3151-VL-PREMIO-LIQ ' DESC. CONCEDIDO = ' LT3151-VL-DESC-TOTAIS ' DESC. TOTAL     = ' LT3151-VL-DESC-CONCEDIDO ' DESC. ARREDON   = ' WS-PCT-DESC-ARRED */

                $"LT3151S-======= DESCONTOS TOTAIS ========  SUB TOTAL = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL} 70% = {WS_AREA_TRABALHO.WS_70PCT_SUBTOTAL} TOTAL = {WS_AREA_TRABALHO.WS_TOTAL_DESCONTO} LIQUIDO = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ} DESC. CONCEDIDO = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_TOTAIS} DESC. TOTAL     = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_CONCEDIDO} DESC. ARREDON   = {WS_AREA_TRABALHO.WS_PCT_DESC_ARRED}"
                .Display();

                /*" -1328- END-IF */
            }


            /*" -1328- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1206_99_SAIDA*/

        [StopWatch]
        /*" R1210-VERIFICA-DESCONTO-MAX-50-SECTION */
        private void R1210_VERIFICA_DESCONTO_MAX_50_SECTION()
        {
            /*" -1339- DISPLAY 'DECONSTO MAX DE 50%' */
            _.Display($"DECONSTO MAX DE 50%");

            /*" -1342- INITIALIZE WS-50PCT-SUBTOTAL WS-TOTAL-DESCONTO */
            _.Initialize(
                WS_AREA_TRABALHO.WS_50PCT_SUBTOTAL
                , WS_AREA_TRABALHO.WS_TOTAL_DESCONTO
            );

            /*" -1344- COMPUTE WS-50PCT-SUBTOTAL = LT3151-VL-SUBTOTAL * 0,50 */
            WS_AREA_TRABALHO.WS_50PCT_SUBTOTAL.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL * 0.50;

            /*" -1351- COMPUTE WS-TOTAL-DESCONTO = (LT3151-DESC-AGRUP + LT3151-DESC-EXP + LT3151-DESC-FIDEL + LT3151-DESC-COFRE + LT3151-DESC-BLINDAGEM ) */
            WS_AREA_TRABALHO.WS_TOTAL_DESCONTO.Value = (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_AGRUP + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_EXP + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_FIDEL + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_COFRE + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_BLINDAGEM);

            /*" -1352- COMPUTE WS-PCT-DESC-TOTAL = WS-TOTAL-DESCONTO * 100 */
            WS_AREA_TRABALHO.WS_PCT_DESC_TOTAL.Value = WS_AREA_TRABALHO.WS_TOTAL_DESCONTO * 100;

            /*" -1355- COMPUTE WS-PCT-DESC-ARRED ROUNDED = WS-PCT-DESC-TOTAL / LT3151-VL-SUBTOTAL */
            WS_AREA_TRABALHO.WS_PCT_DESC_ARRED.Value = WS_AREA_TRABALHO.WS_PCT_DESC_TOTAL / LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL;

            /*" -1356- IF WS-TOTAL-DESCONTO > WS-50PCT-SUBTOTAL */

            if (WS_AREA_TRABALHO.WS_TOTAL_DESCONTO > WS_AREA_TRABALHO.WS_50PCT_SUBTOTAL)
            {

                /*" -1358- COMPUTE LT3151-VL-PREMIO-LIQ = LT3151-VL-SUBTOTAL - WS-50PCT-SUBTOTAL */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL - WS_AREA_TRABALHO.WS_50PCT_SUBTOTAL;

                /*" -1359- MOVE WS-50PCT-SUBTOTAL TO LT3151-VL-DESC-TOTAIS */
                _.Move(WS_AREA_TRABALHO.WS_50PCT_SUBTOTAL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_TOTAIS);

                /*" -1360- ELSE */
            }
            else
            {


                /*" -1362- COMPUTE LT3151-VL-PREMIO-LIQ = LT3151-VL-SUBTOTAL - WS-TOTAL-DESCONTO */
                LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL - WS_AREA_TRABALHO.WS_TOTAL_DESCONTO;

                /*" -1363- MOVE WS-TOTAL-DESCONTO TO LT3151-VL-DESC-TOTAIS */
                _.Move(WS_AREA_TRABALHO.WS_TOTAL_DESCONTO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_TOTAIS);

                /*" -1366- END-IF */
            }


            /*" -1368- MOVE WS-PCT-DESC-ARRED TO LT3151-VL-DESC-CONCEDIDO */
            _.Move(WS_AREA_TRABALHO.WS_PCT_DESC_ARRED, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_CONCEDIDO);

            /*" -1369- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1377- DISPLAY 'LT3151S-======= DESCONTOS TOTAIS ======== ' ' SUB TOTAL = ' LT3151-VL-SUBTOTAL ' 50% = ' WS-50PCT-SUBTOTAL ' TOTAL = ' WS-TOTAL-DESCONTO ' LIQUIDO = ' LT3151-VL-PREMIO-LIQ ' DESC. CONCEDIDO = ' LT3151-VL-DESC-TOTAIS ' DESC. TOTAL     = ' LT3151-VL-DESC-CONCEDIDO ' DESC. ARREDON   = ' WS-PCT-DESC-ARRED */

                $"LT3151S-======= DESCONTOS TOTAIS ========  SUB TOTAL = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL} 50% = {WS_AREA_TRABALHO.WS_50PCT_SUBTOTAL} TOTAL = {WS_AREA_TRABALHO.WS_TOTAL_DESCONTO} LIQUIDO = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ} DESC. CONCEDIDO = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_TOTAIS} DESC. TOTAL     = {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_DESC_CONCEDIDO} DESC. ARREDON   = {WS_AREA_TRABALHO.WS_PCT_DESC_ARRED}"
                .Display();

                /*" -1378- END-IF */
            }


            /*" -1378- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_SAIDA*/

        [StopWatch]
        /*" R1300-00-AJUSTAR-IMPSEG-SECTION */
        private void R1300_00_AJUSTAR_IMPSEG_SECTION()
        {
            /*" -1388- IF WS-ORDEM > 15 */

            if (WS_AREA_TRABALHO.WS_ORDEM > 15)
            {

                /*" -1389- DISPLAY 'LT3151S-SAIDA - ORDEM MAIOR QUE 15 ??????????' */
                _.Display($"LT3151S-SAIDA - ORDEM MAIOR QUE 15 ??????????");

                /*" -1390- GO TO R1300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;

                /*" -1392- END-IF */
            }


            /*" -1393- IF LT3151-IMPSEG(WS-IND2) EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG == 00)
            {

                /*" -1394- ADD 1 TO WS-ORDEM */
                WS_AREA_TRABALHO.WS_ORDEM.Value = WS_AREA_TRABALHO.WS_ORDEM + 1;

                /*" -1395- MOVE TB-ORDEM-COBER(WS-ORDEM) TO WS-IND2 */
                _.Move(WS_AREA_TRABALHO.TABELA_ORDEM_COBER.TAB_ORDEM_COBER_R.TB_ORDEM_COBER[WS_AREA_TRABALHO.WS_ORDEM], WS_AREA_TRABALHO.WS_IND2);

                /*" -1396- GO TO R1300-00-AJUSTAR-IMPSEG */
                new Task(() => R1300_00_AJUSTAR_IMPSEG_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1398- END-IF */
            }


            /*" -1403- DISPLAY 'LT3151S-R1300-TESTANDO ORDEM =' WS-ORDEM ' COBERTURA =' WS-IND2 */

            $"LT3151S-R1300-TESTANDO ORDEM ={WS_AREA_TRABALHO.WS_ORDEM} COBERTURA ={WS_AREA_TRABALHO.WS_IND2}"
            .Display();

            /*" -1404- MOVE 0 TO WS-VALOR */
            _.Move(0, WS_AREA_TRABALHO.WS_VALOR);

            /*" -1405- IF TB-LIMITE-MIN (WS-IND2) GREATER ZEROS */

            if (LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MIN > 00)
            {

                /*" -1406- MOVE TB-LIMITE-MIN (WS-IND2) TO WS-VALOR */
                _.Move(LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MIN, WS_AREA_TRABALHO.WS_VALOR);

                /*" -1408- END-IF */
            }


            /*" -1409- IF WS-VALOR EQUAL ZEROS */

            if (WS_AREA_TRABALHO.WS_VALOR == 00)
            {

                /*" -1410- IF TB-LIMITE-PCTMIN(WS-IND2) GREATER ZEROS */

                if (LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMIN > 00)
                {

                    /*" -1412- COMPUTE WS-VALOR = LT3151-IMPSEG(1) * TB-LIMITE-PCTMIN(WS-IND2)/100 */
                    WS_AREA_TRABALHO.WS_VALOR.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[1].LT3151_IMPSEG.Value * LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMIN.Value / 100f;

                    /*" -1413- END-IF */
                }


                /*" -1415- END-IF */
            }


            /*" -1420- COMPUTE LT3151-IMPSEG(WS-IND2) = LT3151-IMPSEG(WS-IND2) + WS-VALOR */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG.Value + WS_AREA_TRABALHO.WS_VALOR;

            /*" -1421- IF TB-LIMITE-PCTMAX(WS-IND2) GREATER ZEROS */

            if (LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMAX > 00)
            {

                /*" -1423- COMPUTE WS-VALOR = LT3151-IMPSEG(1) * TB-LIMITE-PCTMAX(WS-IND2)/100 */
                WS_AREA_TRABALHO.WS_VALOR.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[1].LT3151_IMPSEG.Value * LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMAX.Value / 100f;

                /*" -1424- IF LT3151-IMPSEG(WS-IND2) > WS-VALOR */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG > WS_AREA_TRABALHO.WS_VALOR)
                {

                    /*" -1425- MOVE WS-VALOR TO LT3151-IMPSEG(WS-IND2) */
                    _.Move(WS_AREA_TRABALHO.WS_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG);

                    /*" -1426- ADD 1 TO WS-ORDEM */
                    WS_AREA_TRABALHO.WS_ORDEM.Value = WS_AREA_TRABALHO.WS_ORDEM + 1;

                    /*" -1427- END-IF */
                }


                /*" -1429- END-IF */
            }


            /*" -1430- IF TB-LIMITE-MAX(WS-IND2) GREATER ZEROS */

            if (LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MAX > 00)
            {

                /*" -1431- IF LT3151-IMPSEG(WS-IND2) > TB-LIMITE-MAX(WS-IND2) */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG > LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MAX)
                {

                    /*" -1433- MOVE TB-LIMITE-MAX(WS-IND2) TO LT3151-IMPSEG(WS-IND2) */
                    _.Move(LBTB3101.TABELA_DE_LIMITE_MINMAX.TABELA_LIMITE_MINMAX_R.TAB_LIMITE_MINMAX[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MAX, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG);

                    /*" -1434- ADD 1 TO WS-ORDEM */
                    WS_AREA_TRABALHO.WS_ORDEM.Value = WS_AREA_TRABALHO.WS_ORDEM + 1;

                    /*" -1435- END-IF */
                }


                /*" -1439- END-IF */
            }


            /*" -1439- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-AJUSTAR-IMPSEG-CCA-SECTION */
        private void R1350_00_AJUSTAR_IMPSEG_CCA_SECTION()
        {
            /*" -1449- IF WS-ORDEM > 15 */

            if (WS_AREA_TRABALHO.WS_ORDEM > 15)
            {

                /*" -1450- DISPLAY 'LT3151S-SAIDA - ORDEM MAIOR QUE 15 ??????????' */
                _.Display($"LT3151S-SAIDA - ORDEM MAIOR QUE 15 ??????????");

                /*" -1451- GO TO R1350-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/ //GOTO
                return;

                /*" -1453- END-IF */
            }


            /*" -1454- IF LT3151-IMPSEG(WS-IND2) EQUAL ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG == 00)
            {

                /*" -1455- ADD 1 TO WS-ORDEM */
                WS_AREA_TRABALHO.WS_ORDEM.Value = WS_AREA_TRABALHO.WS_ORDEM + 1;

                /*" -1456- MOVE TB-ORDEM-COBER(WS-ORDEM) TO WS-IND2 */
                _.Move(WS_AREA_TRABALHO.TABELA_ORDEM_COBER.TAB_ORDEM_COBER_R.TB_ORDEM_COBER[WS_AREA_TRABALHO.WS_ORDEM], WS_AREA_TRABALHO.WS_IND2);

                /*" -1457- GO TO R1350-00-AJUSTAR-IMPSEG-CCA */
                new Task(() => R1350_00_AJUSTAR_IMPSEG_CCA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1459- END-IF */
            }


            /*" -1464- DISPLAY 'LT3151S-R1350-TESTANDO ORDEM CCA =' WS-ORDEM ' COBERTURA =' WS-IND2 */

            $"LT3151S-R1350-TESTANDO ORDEM CCA ={WS_AREA_TRABALHO.WS_ORDEM} COBERTURA ={WS_AREA_TRABALHO.WS_IND2}"
            .Display();

            /*" -1465- MOVE 0 TO WS-VALOR */
            _.Move(0, WS_AREA_TRABALHO.WS_VALOR);

            /*" -1466- IF TB-LIMITE-MIN-CCA (WS-IND2) GREATER ZEROS */

            if (LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MIN_CCA > 00)
            {

                /*" -1467- MOVE TB-LIMITE-MIN-CCA (WS-IND2) TO WS-VALOR */
                _.Move(LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MIN_CCA, WS_AREA_TRABALHO.WS_VALOR);

                /*" -1469- END-IF */
            }


            /*" -1470- IF WS-VALOR EQUAL ZEROS */

            if (WS_AREA_TRABALHO.WS_VALOR == 00)
            {

                /*" -1471- IF TB-LIMITE-PCTMIN-CCA(WS-IND2) GREATER ZEROS */

                if (LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMIN_CCA > 00)
                {

                    /*" -1473- COMPUTE WS-VALOR = LT3151-IMPSEG(1) * TB-LIMITE-PCTMIN-CCA(WS-IND2)/100 */
                    WS_AREA_TRABALHO.WS_VALOR.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[1].LT3151_IMPSEG.Value * LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMIN_CCA.Value / 100f;

                    /*" -1474- END-IF */
                }


                /*" -1476- END-IF */
            }


            /*" -1481- COMPUTE LT3151-IMPSEG(WS-IND2) = LT3151-IMPSEG(WS-IND2) + WS-VALOR */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG.Value + WS_AREA_TRABALHO.WS_VALOR;

            /*" -1482- IF TB-LIMITE-PCTMAX-CCA(WS-IND2) GREATER ZEROS */

            if (LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMAX_CCA > 00)
            {

                /*" -1484- COMPUTE WS-VALOR = LT3151-IMPSEG(1) * TB-LIMITE-PCTMAX-CCA(WS-IND2)/100 */
                WS_AREA_TRABALHO.WS_VALOR.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[1].LT3151_IMPSEG.Value * LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_PCTMAX_CCA.Value / 100f;

                /*" -1485- IF LT3151-IMPSEG(WS-IND2) > WS-VALOR */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG > WS_AREA_TRABALHO.WS_VALOR)
                {

                    /*" -1486- MOVE WS-VALOR TO LT3151-IMPSEG(WS-IND2) */
                    _.Move(WS_AREA_TRABALHO.WS_VALOR, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG);

                    /*" -1487- ADD 1 TO WS-ORDEM */
                    WS_AREA_TRABALHO.WS_ORDEM.Value = WS_AREA_TRABALHO.WS_ORDEM + 1;

                    /*" -1488- END-IF */
                }


                /*" -1490- END-IF */
            }


            /*" -1491- IF TB-LIMITE-MAX-CCA(WS-IND2) GREATER ZEROS */

            if (LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MAX_CCA > 00)
            {

                /*" -1492- IF LT3151-IMPSEG(WS-IND2) > TB-LIMITE-MAX-CCA(WS-IND2) */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG > LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MAX_CCA)
                {

                    /*" -1494- MOVE TB-LIMITE-MAX-CCA(WS-IND2) TO LT3151-IMPSEG(WS-IND2) */
                    _.Move(LBTB3101.TABELA_DE_LIMITE_MINMAX_CCA.FILLER_29.TAB_LIMITE_MINMAX_CCA[WS_AREA_TRABALHO.WS_IND2].TB_LIMITE_MAX_CCA, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND2].LT3151_IMPSEG);

                    /*" -1495- ADD 1 TO WS-ORDEM */
                    WS_AREA_TRABALHO.WS_ORDEM.Value = WS_AREA_TRABALHO.WS_ORDEM + 1;

                    /*" -1496- END-IF */
                }


                /*" -1498- END-IF */
            }


            /*" -1500- DISPLAY 'R1350-SAIDA---TESTANDO ORDEM CCA =' WS-ORDEM ' COBERTURA =' WS-IND2 */

            $"R1350-SAIDA---TESTANDO ORDEM CCA ={WS_AREA_TRABALHO.WS_ORDEM} COBERTURA ={WS_AREA_TRABALHO.WS_IND2}"
            .Display();

            /*" -1500- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1500-DISPLAY-CALCULO-SECTION */
        private void R1500_DISPLAY_CALCULO_SECTION()
        {
            /*" -1508- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1509- COMPUTE WS-QTD-PARCELAS = LT3151-QTD-PARCELAS - 1 */
                WS_AREA_TRABALHO.WS_QTD_PARCELAS.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS - 1;

                /*" -1511- DISPLAY 'LT3151S-RESUMO================================== '=======================' */
                _.Display($"LT3151S-RESUMO================================== =======================");

                /*" -1517- DISPLAY 'LT3151S-LOT=' LT3151-COD-LOTERICO ' CGCCPF=' LT3151-CGCCPF ' CLASSE=' LT3151-NUM-CLASSE-ADESAO ' REG=' LT3151-COD-REGIAO ' QTD=' LT3151-QTD-PARCELAS ' VLR-ADIC-CB=' LT3151-VLR-ADIC-COBER */

                $"LT3151S-LOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO} CGCCPF={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CGCCPF} CLASSE={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO} REG={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_REGIAO} QTD={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS} VLR-ADIC-CB={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_ADIC_COBER}"
                .Display();

                /*" -1518- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

                for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 20); WS_AREA_TRABALHO.WS_IND.Value += 1)
                {

                    /*" -1519- IF LT3151-IMPSEG (WS-IND) GREATER ZEROS */

                    if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND].LT3151_IMPSEG > 00)
                    {

                        /*" -1523- DISPLAY 'LT3151S-CB=' WS-IND ' IS=' LT3151-IMPSEG (WS-IND) ' TX=' LT3151-TAXAS (WS-IND) ' PM=' TB-PREMIO-LIQ (WS-IND) */

                        $"LT3151S-CB={WS_AREA_TRABALHO.WS_IND} IS={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND]} TX={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_AREA_TRABALHO.WS_IND]} PM={WS_AREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WS_AREA_TRABALHO.WS_IND]}"
                        .Display();

                        /*" -1524- END-IF */
                    }


                    /*" -1525- END-PERFORM */
                }

                /*" -1529- DISPLAY 'LT3151S-DTINI=' LT3151-DTINIVIG-APOLICE ' TCALC=' LT3151-TIPO-CALCULO ' CAP=' LT3151-CUSTO-APOLICE ' PCTIOF=' LT3151-PCT-IOF */

                $"LT3151S-DTINI={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE} TCALC={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO} CAP={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE} PCTIOF={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF}"
                .Display();

                /*" -1532- DISPLAY 'LT3151S-COEF1PCL=' LT3151-COEF( 1 ) ' COEFNPCL=' LT3151-COEF(LT3151-QTD-PARCELAS) ' FT-PRORATA=' WS-FATOR-S */

                $"LT3151S-COEF1PCL=LT3151-COEF(1) COEFNPCL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_COEF.LT3151_TAB_COEF[LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS]} FT-PRORATA={WS_AREA_TRABALHO.WS_FATOR_S}"
                .Display();

                /*" -1537- DISPLAY 'LT3151S-PCT-AGRUP=' LT3151-PCT-DESC-AGRUP ' EXP=' LT3151-PCT-DESC-EXP ' FID=' LT3151-PCT-DESC-FIDEL ' COF=' LT3151-PCT-DESC-COFRE ' BLIN=' LT3151-PCT-DESC-BLINDAGEM */

                $"LT3151S-PCT-AGRUP={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_AGRUP} EXP={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_EXP} FID={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_FIDEL} COF={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_COFRE} BLIN={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_BLINDAGEM}"
                .Display();

                /*" -1543- DISPLAY 'LT3151S-DESC-AGRUP=' LT3151-DESC-AGRUP ' EXP=' LT3151-DESC-EXP ' FID=' LT3151-DESC-FIDEL ' COF=' LT3151-DESC-COFRE ' BLIN=' LT3151-DESC-BLINDAGEM ' APOL=' LT3151-NUM-APOL-DESC */

                $"LT3151S-DESC-AGRUP={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_AGRUP} EXP={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_EXP} FID={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_FIDEL} COF={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_COFRE} BLIN={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DESC_BLINDAGEM} APOL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOL_DESC}"
                .Display();

                /*" -1547- DISPLAY 'LT3151S-SUBTOT=' LT3151-VL-SUBTOTAL ' PRMLIQ=' LT3151-VL-PREMIO-LIQ ' AVISTA=' LT3151-VL-PREMIO-TOTAL-1PCL ' PRMTOT=' LT3151-VL-PREMIO-TOTAL */

                $"LT3151S-SUBTOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL} PRMLIQ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ} AVISTA={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL_1PCL} PRMTOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL}"
                .Display();

                /*" -1552- DISPLAY 'LT3151S-PRMLIQ PCL1=' LT3151-VL-PREMIO-LIQ-PCL1 ' JUR=' LT3151-JUROS-PCL1 ' IOF=' LT3151-IOF-PCL1 ' ADIC=' LT3151-ADICIONAL-FRAC-PCL1 ' TOT=' LT3151-VL-PREMIO-PCL1 */

                $"LT3151S-PRMLIQ PCL1={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCL1} JUR={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCL1} IOF={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1} ADIC={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_FRAC_PCL1} TOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1}"
                .Display();

                /*" -1557- DISPLAY 'LT3151S-PRMLIQ PCLN=' LT3151-VL-PREMIO-LIQ-PCLN ' JUR=' LT3151-JUROS-PCLN ' IOF=' LT3151-IOF-PCLN ' ADIC=' LT3151-ADICIONAL-FRAC-PCLN ' TOT=' LT3151-VL-PREMIO-PCLN */

                $"LT3151S-PRMLIQ PCLN={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN} JUR={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCLN} IOF={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN} ADIC={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_FRAC_PCLN} TOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN}"
                .Display();

                /*" -1560- DISPLAY 'LT3151S-JURTOT=' LT3151-JURO-TOTAL ' IOFTOT=' LT3151-IOF-TOTAL ' ADICTOT=' LT3151-ADICIONAL-TOTAL */

                $"LT3151S-JURTOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JURO_TOTAL} IOFTOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_TOTAL} ADICTOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_ADICIONAL_TOTAL}"
                .Display();

                /*" -1564- DISPLAY 'LT3151S-#### 1 PARCELA DE= ' LT3151-VL-PREMIO-PCL1 ' + ' WS-QTD-PARCELAS ' DE ' LT3151-VL-PREMIO-PCLN '  TOT=' LT3151-VL-PREMIO-TOTAL */

                $"LT3151S-#### 1 PARCELA DE= {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1} + {WS_AREA_TRABALHO.WS_QTD_PARCELAS} DE {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN}  TOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL}"
                .Display();

                /*" -1566- DISPLAY 'LT3151S-FIM RESUMO ============================== '===============' */
                _.Display($"LT3151S-FIM RESUMO ============================== ===============");

                /*" -1567- END-IF */
            }


            /*" -1567- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_SAIDA*/

        [StopWatch]
        /*" R2000-CALCULAR-PREMIOS-SECTION */
        private void R2000_CALCULAR_PREMIOS_SECTION()
        {
            /*" -1579- PERFORM R2100-CALCULAR-PREMIO */

            R2100_CALCULAR_PREMIO_SECTION();

            /*" -1584- MOVE WS-VALOR-PREMIO TO TB-PREMIO-LIQ(WS-IND) */
            _.Move(WS_AREA_TRABALHO.WS_VALOR_PREMIO, WS_AREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WS_AREA_TRABALHO.WS_IND]);

            /*" -1586- COMPUTE LT3151-VL-SUBTOTAL = LT3151-VL-SUBTOTAL + WS-VALOR-PREMIO */
            LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL.Value = LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_SUBTOTAL + WS_AREA_TRABALHO.WS_VALOR_PREMIO;

            /*" -1587- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1592- DISPLAY 'LT3151S-' ' CB=' WS-IND ' IS=' LT3151-IMPSEG (WS-IND) ' TX=' LT3151-TAXAS (WS-IND) ' PM=' TB-PREMIO-LIQ (WS-IND) */

                $"LT3151S- CB={WS_AREA_TRABALHO.WS_IND} IS={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND]} TX={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_AREA_TRABALHO.WS_IND]} PM={WS_AREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WS_AREA_TRABALHO.WS_IND]}"
                .Display();

                /*" -1593- END-IF */
            }


            /*" -1593- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R2100-CALCULAR-PREMIO-SECTION */
        private void R2100_CALCULAR_PREMIO_SECTION()
        {
            /*" -1601- IF WS-IND EQUAL 1 */

            if (WS_AREA_TRABALHO.WS_IND == 1)
            {

                /*" -1604- COMPUTE WS-VALOR-PREMIO ROUNDED = (LT3151-IMPSEG(WS-IND) * LT3151-TAXAS (WS-IND) * WS-FATOR) / 100 */
                WS_AREA_TRABALHO.WS_VALOR_PREMIO.Value = (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND].LT3151_IMPSEG.Value * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_AREA_TRABALHO.WS_IND].LT3151_TAXAS.Value * WS_AREA_TRABALHO.WS_FATOR) / 100f;

                /*" -1610- ADD LT3151-VLR-ADIC-COBER TO WS-VALOR-PREMIO */
                WS_AREA_TRABALHO.WS_VALOR_PREMIO.Value = WS_AREA_TRABALHO.WS_VALOR_PREMIO + LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_ADIC_COBER;

                /*" -1611- ELSE */
            }
            else
            {


                /*" -1614- COMPUTE WS-VALOR-PREMIO ROUNDED = (LT3151-IMPSEG(WS-IND) * LT3151-TAXAS (WS-IND) * WS-FATOR) / 100 */
                WS_AREA_TRABALHO.WS_VALOR_PREMIO.Value = (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_AREA_TRABALHO.WS_IND].LT3151_IMPSEG.Value * LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_AREA_TRABALHO.WS_IND].LT3151_TAXAS.Value * WS_AREA_TRABALHO.WS_FATOR) / 100f;

                /*" -1615- END-IF */
            }


            /*" -1615- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-CALCULAR-FATOR-PRORATA-SECTION */
        private void R2200_CALCULAR_FATOR_PRORATA_SECTION()
        {
            /*" -1629- MOVE 'R2200' TO WNR-EXEC-SQL. */
            _.Move("R2200", WS_AREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -1632- MOVE 1 TO WS-FATOR WS-FATOR-S. */
            _.Move(1, WS_AREA_TRABALHO.WS_FATOR, WS_AREA_TRABALHO.WS_FATOR_S);

            /*" -1633- IF LT3151-TIPO-CALCULO EQUAL 'PR' OR 'PC' */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO.In("PR", "PC"))
            {

                /*" -1634- MOVE 1 TO WS-FATOR */
                _.Move(1, WS_AREA_TRABALHO.WS_FATOR);

                /*" -1635- ELSE */
            }
            else
            {


                /*" -1636- GO TO R2200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/ //GOTO
                return;

                /*" -1652- END-IF */
            }


            /*" -1658- MOVE 365 TO WS-QTDIAS-VIGENCIA. */
            _.Move(365, WS_AREA_TRABALHO.WS_QTDIAS_VIGENCIA);

            /*" -1660- IF (LT3171-PRODUTO EQUAL 1805 OR 1803 ) AND (HOST-DATA-FIM EQUAL '2020-12-31' ) */

            if ((LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO.In("1805", "1803")) && (WS_AREA_TRABALHO.HOST_DATA_FIM == "2020-12-31"))
            {

                /*" -1661- MOVE 366 TO WS-QTDIAS-VIGENCIA */
                _.Move(366, WS_AREA_TRABALHO.WS_QTDIAS_VIGENCIA);

                /*" -1666- END-IF */
            }


            /*" -1668- MOVE LT3151-DTINIVIG-APOLICE TO HOST-DATA-INI */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE, WS_AREA_TRABALHO.HOST_DATA_INI);

            /*" -1670- MOVE LT3151-DTTERVIG-APOLICE TO HOST-DATA-FIM */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE, WS_AREA_TRABALHO.HOST_DATA_FIM);

            /*" -1677- PERFORM R1100-00-OBTEM-QTD-DIAS */

            R1100_00_OBTEM_QTD_DIAS_SECTION();

            /*" -1678- ADD 1 TO HOST-COUNT */
            WS_AREA_TRABALHO.HOST_COUNT.Value = WS_AREA_TRABALHO.HOST_COUNT + 1;

            /*" -1684- MOVE HOST-COUNT TO WS-QTDIAS-DECORRER */
            _.Move(WS_AREA_TRABALHO.HOST_COUNT, WS_AREA_TRABALHO.WS_QTDIAS_DECORRER);

            /*" -1685- IF LT3151-TIPO-CALCULO EQUAL 'PR' */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO == "PR")
            {

                /*" -1687- COMPUTE WS-FATOR = WS-QTDIAS-DECORRER / WS-QTDIAS-VIGENCIA */
                WS_AREA_TRABALHO.WS_FATOR.Value = WS_AREA_TRABALHO.WS_QTDIAS_DECORRER / WS_AREA_TRABALHO.WS_QTDIAS_VIGENCIA;

                /*" -1688- ELSE */
            }
            else
            {


                /*" -1689- IF LT3151-TIPO-CALCULO EQUAL 'PC' */

                if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO == "PC")
                {

                    /*" -1690- COMPUTE WS-FATOR = WS-PCT-PRM-DECORRIDO / 100 */
                    WS_AREA_TRABALHO.WS_FATOR.Value = WS_AREA_TRABALHO.WS_PCT_PRM_DECORRIDO / 100f;

                    /*" -1691- END-IF */
                }


                /*" -1693- END-IF */
            }


            /*" -1694- IF WS-FATOR EQUAL ZEROS */

            if (WS_AREA_TRABALHO.WS_FATOR == 00)
            {

                /*" -1695- MOVE 1 TO WS-FATOR */
                _.Move(1, WS_AREA_TRABALHO.WS_FATOR);

                /*" -1697- END-IF */
            }


            /*" -1699- MOVE WS-FATOR TO WS-FATOR-S */
            _.Move(WS_AREA_TRABALHO.WS_FATOR, WS_AREA_TRABALHO.WS_FATOR_S);

            /*" -1700- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1706- DISPLAY 'LT3151S-FATOR PRORATA-CALCULADO' ' DTI=' LT3151-DTINIVIG-APOLICE ' DTT=' LT3151-DTTERVIG-APOLICE ' DVIG=' WS-QTDIAS-VIGENCIA ' DDEC=' WS-QTDIAS-DECORRER ' FT=' WS-FATOR-S */

                $"LT3151S-FATOR PRORATA-CALCULADO DTI={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE} DTT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE} DVIG={WS_AREA_TRABALHO.WS_QTDIAS_VIGENCIA} DDEC={WS_AREA_TRABALHO.WS_QTDIAS_DECORRER} FT={WS_AREA_TRABALHO.WS_FATOR_S}"
                .Display();

                /*" -1707- END-IF */
            }


            /*" -1707- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-OBTEM-QTD-DIAS-SECTION */
        private void R1100_00_OBTEM_QTD_DIAS_SECTION()
        {
            /*" -1717- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WS_AREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -1723- PERFORM R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1 */

            R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1();

            /*" -1726- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1731- DISPLAY 'LT3151S-*** PROBLEMAS NO SELECT CALENDARIO' ' ' LT3151-NUM-APOLICE ' ' HOST-DATA-INI ' ' HOST-DATA-FIM ' ' SQLCODE */

                $"LT3151S-*** PROBLEMAS NO SELECT CALENDARIO {LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOLICE} {WS_AREA_TRABALHO.HOST_DATA_INI} {WS_AREA_TRABALHO.HOST_DATA_FIM} {DB.SQLCODE}"
                .Display();

                /*" -1733- MOVE 'LT3151S-ERRO SELECT CALENDARIO ' TO LT3151-MSG-RETORNO */
                _.Move("LT3151S-ERRO SELECT CALENDARIO ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1734- DISPLAY LT3151-MSG-RETORNO */
                _.Display(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO);

                /*" -1735- MOVE 11 TO LT3151-COD-RETORNO */
                _.Move(11, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO);

                /*" -1736- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1738- END-IF. */
            }


            /*" -1744- UNSTRING HOST-DATA-INI DELIMITED BY '-' INTO WS-ANO-RENOVACAO END-UNSTRING */
            _.Unstring(WS_AREA_TRABALHO.HOST_DATA_INI,
                [new UnstringDelimitedParameter("-")],
                [new UnstringIntoParameter(WS_AREA_TRABALHO.WS_ANO_RENOVACAO)
            ]);

            /*" -1745- IF LT3171-PRODUTO EQUAL 1805 */

            if (LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO == 1805)
            {

                /*" -1748- IF (HOST-DATA-INI = '2019-11-01' ) AND (HOST-DATA-FIM = '2020-12-31' ) AND (WS-ANO-RENOVACAO = '2019' ) */

                if ((WS_AREA_TRABALHO.HOST_DATA_INI == "2019-11-01") && (WS_AREA_TRABALHO.HOST_DATA_FIM == "2020-12-31") && (WS_AREA_TRABALHO.WS_ANO_RENOVACAO == "2019"))
                {

                    /*" -1749- DISPLAY 'LT3151S-RENOVACAO CCA - 2019 14 MESES' */
                    _.Display($"LT3151S-RENOVACAO CCA - 2019 14 MESES");

                    /*" -1750- MOVE 365 TO HOST-COUNT */
                    _.Move(365, WS_AREA_TRABALHO.HOST_COUNT);

                    /*" -1751- ELSE */
                }
                else
                {


                    /*" -1754- IF (HOST-DATA-INI > '2019-11-01' ) AND (HOST-DATA-FIM = '2020-12-31' ) AND (WS-ANO-RENOVACAO = '2019' ) */

                    if ((WS_AREA_TRABALHO.HOST_DATA_INI > "2019-11-01") && (WS_AREA_TRABALHO.HOST_DATA_FIM == "2020-12-31") && (WS_AREA_TRABALHO.WS_ANO_RENOVACAO == "2019"))
                    {

                        /*" -1756- DISPLAY 'LT3151S-RENOVA CCA - COM INICIO APOS' 'INICIO 01-11-19 E ANTES DE 01-01-20.' */
                        _.Display($"LT3151S-RENOVA CCA - COM INICIO APOSINICIO 01-11-19 E ANTES DE 01-01-20.");

                        /*" -1757- MOVE 366 TO HOST-COUNT */
                        _.Move(366, WS_AREA_TRABALHO.HOST_COUNT);

                        /*" -1758- END-IF */
                    }


                    /*" -1759- END-IF */
                }


                /*" -1761- END-IF */
            }


            /*" -1762- IF HOST-COUNT > 366 */

            if (WS_AREA_TRABALHO.HOST_COUNT > 366)
            {

                /*" -1767- DISPLAY 'LT3151S-PROBLEMAS NO COUNT DIAS VIG ' ' QTD DIAS=' HOST-COUNT ' DATA INI=' HOST-DATA-INI ' DATA TER=' HOST-DATA-FIM ' LIMITADO PARA 366' */

                $"LT3151S-PROBLEMAS NO COUNT DIAS VIG  QTD DIAS={WS_AREA_TRABALHO.HOST_COUNT} DATA INI={WS_AREA_TRABALHO.HOST_DATA_INI} DATA TER={WS_AREA_TRABALHO.HOST_DATA_FIM} LIMITADO PARA 366"
                .Display();

                /*" -1768- MOVE 366 TO HOST-COUNT */
                _.Move(366, WS_AREA_TRABALHO.HOST_COUNT);

                /*" -1770- END-IF. */
            }


            /*" -1771- IF WS-DISPLAY EQUAL 'SIM' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "SIM")
            {

                /*" -1774- DISPLAY 'LT3151S-DATA-INI=' HOST-DATA-INI ' DATA-TER=' HOST-DATA-FIM ' QTD-DIAS=' HOST-COUNT */

                $"LT3151S-DATA-INI={WS_AREA_TRABALHO.HOST_DATA_INI} DATA-TER={WS_AREA_TRABALHO.HOST_DATA_FIM} QTD-DIAS={WS_AREA_TRABALHO.HOST_COUNT}"
                .Display();

                /*" -1775- END-IF */
            }


            /*" -1775- . */

        }

        [StopWatch]
        /*" R1100-00-OBTEM-QTD-DIAS-DB-SELECT-1 */
        public void R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1()
        {
            /*" -1723- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :HOST-DATA-INI AND DATA_CALENDARIO < :HOST-DATA-FIM END-EXEC. */

            var r1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1 = new R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1()
            {
                HOST_DATA_INI = WS_AREA_TRABALHO.HOST_DATA_INI.ToString(),
                HOST_DATA_FIM = WS_AREA_TRABALHO.HOST_DATA_FIM.ToString(),
            };

            var executed_1 = R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1.Execute(r1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, WS_AREA_TRABALHO.HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LE-PRAZOSEG-SECTION */
        private void R1200_00_LE_PRAZOSEG_SECTION()
        {
            /*" -1786- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WS_AREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -1799- PERFORM R1200_00_LE_PRAZOSEG_DB_SELECT_1 */

            R1200_00_LE_PRAZOSEG_DB_SELECT_1();

            /*" -1802- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1805- DISPLAY 'LT3151S-PROBLEMAS NO SELECT PRAZO_SEGURO' ' ' LTMVPROP-NUM-APOLICE ' ' PRAZOSEG-INICIO-PRAZO */

                $"LT3151S-PROBLEMAS NO SELECT PRAZO_SEGURO {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE} {PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_INICIO_PRAZO}"
                .Display();

                /*" -1805- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-LE-PRAZOSEG-DB-SELECT-1 */
        public void R1200_00_LE_PRAZOSEG_DB_SELECT_1()
        {
            /*" -1799- EXEC SQL SELECT A.PCT_PRM_ANUAL INTO :PRAZOSEG-PCT-PRM-ANUAL FROM SEGUROS.PRAZO_SEGURO A WHERE A.COD_TABELA = 5 AND A.INICIO_PRAZO <= :PRAZOSEG-INICIO-PRAZO AND A.FIM_PRAZO >= :PRAZOSEG-INICIO-PRAZO AND A.DATA_INIVIGENCIA = (SELECT MAX(B.DATA_INIVIGENCIA) FROM SEGUROS.PRAZO_SEGURO B WHERE A.COD_TABELA = B.COD_TABELA AND A.INICIO_PRAZO = B.INICIO_PRAZO AND A.FIM_PRAZO = B.FIM_PRAZO) END-EXEC. */

            var r1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1 = new R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1()
            {
                PRAZOSEG_INICIO_PRAZO = PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_INICIO_PRAZO.ToString(),
            };

            var executed_1 = R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1.Execute(r1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRAZOSEG_PCT_PRM_ANUAL, PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_PCT_PRM_ANUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ROT-RETORNO-SECTION */
        private void R9000_00_ROT_RETORNO_SECTION()
        {
            /*" -1816- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_AREA_TRABALHO.WABEND.WSQLCODE);

            /*" -1817- IF LT3151-COD-RETORNO GREATER ZEROS */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO > 00)
            {

                /*" -1821- DISPLAY 'LT3151S-R9000-ERRO:' ' COD-ERRO=' LT3151-COD-RETORNO ' MSG-ERRO=' LT3151-MSG-RETORNO ' SQLCODE =' WSQLCODE */

                $"LT3151S-R9000-ERRO: COD-ERRO={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO} MSG-ERRO={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO} SQLCODE ={WS_AREA_TRABALHO.WABEND.WSQLCODE}"
                .Display();

                /*" -1823- END-IF */
            }


            /*" -1824- GOBACK . */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1835- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_AREA_TRABALHO.WABEND.WSQLCODE);

            /*" -1838- DISPLAY WABEND */
            _.Display(WS_AREA_TRABALHO.WABEND);

            /*" -1838- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1840- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1844- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1844- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}