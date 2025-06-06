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
using Sias.VidaAzul.DB2.VA0955B;

namespace Code
{
    public class VA0955B
    {
        public bool IsCall { get; set; }

        public VA0955B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   USUARIO ................  AUDITORIA INTERNA                  *      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *   PROGRAMA ...............  VA0955B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL DE 2007                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................. GERACAO DO ARQUIVO CONTENDO TODAS   *      */
        /*"      *                            AS OPERACOES DOS SINISTROS AVISADOS *      */
        /*"      *                            NO MES PARA O RAMO VIDA.            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _AUDTSINI { get; set; } = new FileBasis(new PIC("X", "700", "X(700)"));

        public FileBasis AUDTSINI
        {
            get
            {
                _.Move(REG_AUDTSINI, _AUDTSINI); VarBasis.RedefinePassValue(REG_AUDTSINI, _AUDTSINI, REG_AUDTSINI); return _AUDTSINI;
            }
        }
        public SortBasis<VA0955B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<VA0955B_REG_ARQSORT>(new VA0955B_REG_ARQSORT());
        /*"01          REG-ARQSORT.*/
        public VA0955B_REG_ARQSORT REG_ARQSORT { get; set; } = new VA0955B_REG_ARQSORT();
        public class VA0955B_REG_ARQSORT : VarBasis
        {
            /*"  05        SD-TIP-PEND           PIC  X(002).*/
            public StringBasis SD_TIP_PEND { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        SD-RAMO-CBT           PIC  9(004).*/
            public IntBasis SD_RAMO_CBT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        SD-NUM-SINI           PIC  9(013).*/
            public IntBasis SD_NUM_SINI { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05        SD-COD-OPER           PIC  9(004).*/
            public IntBasis SD_COD_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        SD-OCORHIST           PIC  9(013).*/
            public IntBasis SD_OCORHIST { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05        SD-VAL-OPER           PIC S9(015)V99.*/
            public DoubleBasis SD_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
            /*"  05        SD-SIT-CONT           PIC  X(001).*/
            public StringBasis SD_SIT_CONT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05        SD-DTMOVTO            PIC  X(010).*/
            public StringBasis SD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        SD-NOMFAV             PIC  X(040).*/
            public StringBasis SD_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01          REG-AUDTSINI        PIC  X(0700).*/
        }
        public StringBasis REG_AUDTSINI { get; set; } = new StringBasis(new PIC("X", "700", "X(0700)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77  VIND-VAL-JURO               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VAL_JURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODUSU-PRE             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU_PRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-AGENCIA-DEB        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPER-CONTA-DEB         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NUM-CONTA-DEB          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIG-CONTA-DEB          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-RETORNO-CEF        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODUSU-LIB             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU_LIB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTMOVTO                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CPF                    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-DATA-REF              PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-AGE-COBRANCA          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-COD-PRODUTO           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0SIST-DTMOVABE-1           PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0SIST-DTMOVABE             PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0SIST-DTCURRENT            PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-DTH-INI              PIC  X(010).*/
        public StringBasis WHOST_DTH_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DTH-FIM              PIC  X(010).*/
        public StringBasis WHOST_DTH_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RELA-CODRELAT             PIC  X(008)      VALUE SPACES.*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  V0EMPR-COD-EMPR             PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0EMPR_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0EMPR-NOME-EMPR            PIC  X(040)      VALUE SPACES.*/
        public StringBasis V0EMPR_NOME_EMPR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77  V0MSIN-NUM-SINI             PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0MSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0MSIN-NUM-APOL             PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0MSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0MSIN-TIPREG               PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0MSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  V0MSIN-FONTE                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MSIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MSIN-PROTSINI             PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0MSIN_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0MSIN-RAMO                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MSIN_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MSIN-CODLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MSIN_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MSIN-SINLID               PIC  X(015)      VALUE SPACES.*/
        public StringBasis V0MSIN_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"77  V0MSIN-DATCMD               PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0MSIN_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0MSIN-DATORR               PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0MSIN_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0MSIN-DATTEC               PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0MSIN_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0MSIN-NRCERTIF             PIC S9(015)      VALUE +0 COMP-3*/
        public IntBasis V0MSIN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0MSIN-CODCAU               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MSIN_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HSIN-NUM-SINI             PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0HSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0HSIN-VAL-JURO             PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HSIN_VAL_JURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0HSIN-CODUSU-PRE           PIC  X(008).*/
        public StringBasis V0HSIN_CODUSU_PRE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0HSIN-CODUSU-LIB           PIC  X(008).*/
        public StringBasis V0HSIN_CODUSU_LIB { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0HSIN-DTMOVTO              PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0HSIN-OCORHIST             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HSIN-OPERACAO             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HSIN-VAL-OPERACAO         PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HSIN_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0HSIN-VAL-PARCIAL          PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HSIN_VAL_PARCIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-IND-BEN                  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_IND_BEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05        LD00.*/
        public VA0955B_LD00 LD00 { get; set; } = new VA0955B_LD00();
        public class VA0955B_LD00 : VarBasis
        {
            /*"      10      FILLER              PIC X(07)   VALUE 'VA0955B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA0955B");
            /*"      10      FILLER              PIC X(08)   VALUE  SPACES.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"      10      FILLER              PIC X(50)   VALUE            'SINISTROS AVISADOS NO MES                         '*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"SINISTROS AVISADOS NO MES                         ");
            /*"      10      FILLER              PIC X(05)   VALUE            ' DIAS'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" DIAS");
            /*"      10      FILLER              PIC X(08)   VALUE             ' DATA : '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" DATA : ");
            /*"      10      LD00-DATAINI        PIC X(10).*/
            public StringBasis LD00_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"      10      FILLER              PIC X(03)   VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
            /*"01          WCAB-AUDTSINI.*/
        }
        public VA0955B_WCAB_AUDTSINI WCAB_AUDTSINI { get; set; } = new VA0955B_WCAB_AUDTSINI();
        public class VA0955B_WCAB_AUDTSINI : VarBasis
        {
            /*"  05        FILLER              PIC  X(009) VALUE 'CD FILIAL'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CD FILIAL");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'NM FILIAL'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NM FILIAL");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'CD ESCNEG'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CD ESCNEG");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'NM ESCNEG'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NM ESCNEG");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(005) VALUE 'CD PV'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"CD PV");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(005) VALUE 'NM PV'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"NM PV");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'CD PRODUTO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CD PRODUTO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'NM PRODUTO'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NM PRODUTO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'CD FRAUDE'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CD FRAUDE");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'NM FRAUDE'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NM FRAUDE");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'CD CAUSA'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CD CAUSA");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'NM CAUSA'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NM CAUSA");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'INDICADOR'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"INDICADOR");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'NRCERTIF'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NRCERTIF");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'SINISTRO'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SINISTRO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(004) VALUE 'NOME'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NOME");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(003) VALUE 'CPF'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"CPF");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(006) VALUE 'BAIRRO'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"BAIRRO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(006) VALUE 'CIDADE'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CIDADE");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(002) VALUE 'UF'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'CEP'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CEP");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'MOVIMENTO '.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"MOVIMENTO ");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'OCORRENCIA'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"OCORRENCIA");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'COMUNICADO'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"COMUNICADO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'PROTOCOLO'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PROTOCOLO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'VL AVISADO'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VL AVISADO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'VL JURO'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VL JURO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'VL PAGO'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VL PAGO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(010) VALUE 'PRE-LIBERA'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PRE-LIBERA");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'LIBERACAO'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"LIBERACAO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'APOLICE'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"APOLICE");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'DTINIVIG'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DTINIVIG");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(008) VALUE 'DTTERVIG'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DTTERVIG");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(012) VALUE 'BENEFICIARIO'*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"BENEFICIARIO");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(009) VALUE 'CPF BENEF'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CPF BENEF");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'OPC PAG'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"OPC PAG");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'CHEQUE '.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CHEQUE ");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'CONTA  '.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CONTA  ");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        FILLER              PIC  X(007) VALUE 'RETORNO'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"RETORNO");
            /*"  05        FILLER              PIC  X(374) VALUE SPACES.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "374", "X(374)"), @"");
            /*"01          WREG-AUDTSINI.*/
        }
        public VA0955B_WREG_AUDTSINI WREG_AUDTSINI { get; set; } = new VA0955B_WREG_AUDTSINI();
        public class VA0955B_WREG_AUDTSINI : VarBasis
        {
            /*"  05        REG-FONTE           PIC  9(004).*/
            public IntBasis REG_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-FONTE      PIC  X(040).*/
            public StringBasis REG_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CD-ESCNEG       PIC  9(004).*/
            public IntBasis REG_CD_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-ESCNEG     PIC  X(040).*/
            public StringBasis REG_NOME_ESCNEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CD-AGENCIA      PIC  9(004).*/
            public IntBasis REG_CD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-AGENCIA    PIC  X(040).*/
            public StringBasis REG_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-PRODUTO         PIC  9(004).*/
            public IntBasis REG_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-PRODUTO    PIC  X(040).*/
            public StringBasis REG_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-COD-OPER-F      PIC  9(004).*/
            public IntBasis REG_COD_OPER_F { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DESCR-OPER-F    PIC  X(040).*/
            public StringBasis REG_DESCR_OPER_F { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CODCAU          PIC  9(004).*/
            public IntBasis REG_CODCAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-CAUSA      PIC  X(040).*/
            public StringBasis REG_NOME_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NRMATRVEN       PIC  9(015).*/
            public IntBasis REG_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NRCERTIF        PIC  9(015).*/
            public IntBasis REG_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NUM-SINI        PIC  9(013).*/
            public IntBasis REG_NUM_SINI { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-RAZAO      PIC  X(040).*/
            public StringBasis REG_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CPF             PIC  9(011).*/
            public IntBasis REG_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-BAIRRO          PIC  X(020).*/
            public StringBasis REG_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CIDADE          PIC  X(020).*/
            public StringBasis REG_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-UF              PIC  X(002).*/
            public StringBasis REG_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CEP             PIC  9(008).*/
            public IntBasis REG_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DTMOVTO         PIC  X(010).*/
            public StringBasis REG_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DATORR          PIC  X(010).*/
            public StringBasis REG_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DATCMD          PIC  X(010).*/
            public StringBasis REG_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DATTEC          PIC  X(010).*/
            public StringBasis REG_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-VAL-AVISADO     PIC  9999999999999,99.*/
            public DoubleBasis REG_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-VAL-JURO        PIC  9999999999999,99.*/
            public DoubleBasis REG_VAL_JURO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-VAL-PAGO        PIC  9999999999999,99.*/
            public DoubleBasis REG_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CODUSU-PRE      PIC  X(008).*/
            public StringBasis REG_CODUSU_PRE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CODUSU-LIB      PIC  X(008).*/
            public StringBasis REG_CODUSU_LIB { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NUM-APOL        PIC  9(013).*/
            public IntBasis REG_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DTINIVIG        PIC  X(010).*/
            public StringBasis REG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DTTERVIG        PIC  X(010).*/
            public StringBasis REG_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NOME-BENEF      PIC  X(040).*/
            public StringBasis REG_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-CPF-BENEF       PIC  9(011).*/
            public IntBasis REG_CPF_BENEF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-OPCAO-PAG       PIC  X(011).*/
            public StringBasis REG_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-NUM-CHEQUE      PIC  9(009).*/
            public IntBasis REG_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-COD-AGENCIA     PIC  9(004).*/
            public IntBasis REG_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        REG-COD-OPERACAO    PIC  9(004).*/
            public IntBasis REG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        FILLER              PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        REG-NUM-CONTA       PIC  9(012).*/
            public IntBasis REG_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05        FILLER              PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05        REG-DIG-CONTA       PIC  9(001).*/
            public IntBasis REG_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        REG-DES-RETORNO     PIC  X(020).*/
            public StringBasis REG_DES_RETORNO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        FILLER              PIC  X(048) VALUE SPACES.*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
            /*"01          W-TABELAS.*/
        }
        public VA0955B_W_TABELAS W_TABELAS { get; set; } = new VA0955B_W_TABELAS();
        public class VA0955B_W_TABELAS : VarBasis
        {
            /*"  05        TABELA-MESES.*/
            public VA0955B_TABELA_MESES TABELA_MESES { get; set; } = new VA0955B_TABELA_MESES();
            public class VA0955B_TABELA_MESES : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE 'JANEIRO'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JANEIRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'MARCO'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MARCO");
                /*"    10      FILLER              PIC  X(009) VALUE 'ABRIL'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ABRIL");
                /*"    10      FILLER              PIC  X(009) VALUE 'MAIO'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MAIO");
                /*"    10      FILLER              PIC  X(009) VALUE 'JUNHO'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JUNHO");
                /*"    10      FILLER              PIC  X(009) VALUE 'JULHO'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JULHO");
                /*"    10      FILLER              PIC  X(009) VALUE 'AGOSTO'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AGOSTO");
                /*"    10      FILLER              PIC  X(009) VALUE 'SETEMBRO'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SETEMBRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'OUTUBRO'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"OUTUBRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'NOVEMBRO'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NOVEMBRO");
                /*"    10      FILLER              PIC  X(009) VALUE 'DEZEMBRO'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DEZEMBRO");
                /*"  05        TAB-MES             REDEFINES   TABELA-MESES                                OCCURS      12                                PIC  X(009).*/
            }
            private _REDEF_StringBasis _tab_mes { get; set; }
            public _REDEF_StringBasis TAB_MES
            {
                get { _tab_mes = new _REDEF_StringBasis(new PIC("X", "009", "X(009).")); ; _.Move(TABELA_MESES, _tab_mes); VarBasis.RedefinePassValue(TABELA_MESES, _tab_mes, TABELA_MESES); _tab_mes.ValueChanged += () => { _.Move(_tab_mes, TABELA_MESES); }; return _tab_mes; }
                set { VarBasis.RedefinePassValue(value, _tab_mes, TABELA_MESES); }
            }  //Redefines
            /*"  05        TABELA-SINI-PENDT.*/
            public VA0955B_TABELA_SINI_PENDT TABELA_SINI_PENDT { get; set; } = new VA0955B_TABELA_SINI_PENDT();
            public class VA0955B_TABELA_SINI_PENDT : VarBasis
            {
                /*"    10      TAB-SINI-PEND       OCCURS   100   TIMES.*/
                public ListBasis<VA0955B_TAB_SINI_PEND> TAB_SINI_PEND { get; set; } = new ListBasis<VA0955B_TAB_SINI_PEND>(100);
                public class VA0955B_TAB_SINI_PEND : VarBasis
                {
                    /*"      15    W-RAMO              PIC  9(004).*/
                    public IntBasis W_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    W-PEND-001-030      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_001_030 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"      15    W-PEND-031-060      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_031_060 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"      15    W-PEND-061-120      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_061_120 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"      15    W-PEND-121-180      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_121_180 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"      15    W-PEND-181-365      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_181_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"      15    W-PEND-ACM-365      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_ACM_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"      15    W-PEND-TOT-GER      PIC S9(015)V99.*/
                    public DoubleBasis W_PEND_TOT_GER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99."), 2);
                    /*"01   AREA-DE-WORK.*/
                }
            }
        }
        public VA0955B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0955B_AREA_DE_WORK();
        public class VA0955B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WS-CHAVE-ATU.*/
            public VA0955B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VA0955B_WS_CHAVE_ATU();
            public class VA0955B_WS_CHAVE_ATU : VarBasis
            {
                /*"     10  WS-SINISTRO-ATU        PIC  9(013).*/
                public IntBasis WS_SINISTRO_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"     10  WS-COD-CAUSA-ATU       PIC  9(004).*/
                public IntBasis WS_COD_CAUSA_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05 WS-CHAVE-ANT.*/
            }
            public VA0955B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA0955B_WS_CHAVE_ANT();
            public class VA0955B_WS_CHAVE_ANT : VarBasis
            {
                /*"     10  WS-SINISTRO-ANT        PIC  9(013).*/
                public IntBasis WS_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"     10  WS-COD-CAUSA-ANT       PIC  9(004).*/
                public IntBasis WS_COD_CAUSA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05 WTEM-SEGURVGA              PIC  X(003)      VALUE SPACES.*/
            }
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 WTEM-BILHETE               PIC  X(003)      VALUE SPACES.*/
            public StringBasis WTEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 WTEM-SINISMES              PIC  X(003)      VALUE SPACES.*/
            public StringBasis WTEM_SINISMES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 WTEM-PROPOVA               PIC  X(003)      VALUE SPACES.*/
            public StringBasis WTEM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 W-STATUS                   PIC  9(002)      VALUE ZEROS.*/
            public IntBasis W_STATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 W-IND                      PIC  9(004)      VALUE ZEROS.*/
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05 W-RESTO                    PIC S9(004)      VALUE +0.*/
            public IntBasis W_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05 WFIM-V0RELATORIOS          PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 WFIM-V0SINISTROS           PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V0SINISTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 WFIM-ARQSORT               PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_ARQSORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 WFIM-CBENEF                PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_CBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 AC-LINHAS                  PIC  9(002)      VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05 AC-PAGINA                  PIC  9(004)      VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05 AC-L-SINISTROS             PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_SINISTROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05 AC-G-ARQSORT               PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_G_ARQSORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05 AC-L-ARQSORT               PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_ARQSORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05 AC-L-BENEF                 PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_BENEF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05 AC-G-AUDTSINI              PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_G_AUDTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05 WTIP-PEND-ANT              PIC  X(002)      VALUE SPACES.*/
            public StringBasis WTIP_PEND_ANT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05 WCOD-RAMO-ANT              PIC  9(004)      VALUE ZEROS.*/
            public IntBasis WCOD_RAMO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05 W-PCPARTIC                 PIC S9(004)V9(5) VALUE +0.*/
            public DoubleBasis W_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
            /*"  05 W-PCTRESEG                 PIC S9(004)V9(5) VALUE +0.*/
            public DoubleBasis W_PCTRESEG { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
            /*"  05 W-TOT-VAL-OPER             PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis W_TOT_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 W-VAL-OPER-TOT             PIC ---.---.---.--9,99.*/
            public DoubleBasis W_VAL_OPER_TOT { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
            /*"  05 WTOT-PEND-001-030          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_001_030 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-PEND-031-060          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_031_060 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-PEND-061-120          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_061_120 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-PEND-121-180          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_121_180 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-PEND-181-365          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_181_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-PEND-ACM-365          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_ACM_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-PEND-GERAL            PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_PEND_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-001-030          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_001_030 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-031-060          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_031_060 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-061-120          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_061_120 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-121-180          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_121_180 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-181-365          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_181_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-ACM-365          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_ACM_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-TIPO-PENDT            PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_TIPO_PENDT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-001-030          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_001_030 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-031-060          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_031_060 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-061-120          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_061_120 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-121-180          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_121_180 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-181-365          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_181_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-ACM-365          PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_ACM_365 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05 WTOT-RAMO-PENDT            PIC S9(015)V99   VALUE +0.*/
            public DoubleBasis WTOT_RAMO_PENDT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WDATA-SIST            PIC  X(010)      VALUE  SPACES.*/
            public StringBasis WDATA_SIST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      FILLER                REDEFINES        WDATA-SIST.*/
            private _REDEF_VA0955B_FILLER_138 _filler_138 { get; set; }
            public _REDEF_VA0955B_FILLER_138 FILLER_138
            {
                get { _filler_138 = new _REDEF_VA0955B_FILLER_138(); _.Move(WDATA_SIST, _filler_138); VarBasis.RedefinePassValue(WDATA_SIST, _filler_138, WDATA_SIST); _filler_138.ValueChanged += () => { _.Move(_filler_138, WDATA_SIST); }; return _filler_138; }
                set { VarBasis.RedefinePassValue(value, _filler_138, WDATA_SIST); }
            }  //Redefines
            public class _REDEF_VA0955B_FILLER_138 : VarBasis
            {
                /*"    10    WDATA-SIST-ANO        PIC  9(004).*/
                public IntBasis WDATA_SIST_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-SIST-MES        PIC  9(002).*/
                public IntBasis WDATA_SIST_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-SIST-DIA        PIC  9(002).*/
                public IntBasis WDATA_SIST_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-CURR            PIC  X(010)      VALUE SPACES.*/

                public _REDEF_VA0955B_FILLER_138()
                {
                    WDATA_SIST_ANO.ValueChanged += OnValueChanged;
                    FILLER_139.ValueChanged += OnValueChanged;
                    WDATA_SIST_MES.ValueChanged += OnValueChanged;
                    FILLER_140.ValueChanged += OnValueChanged;
                    WDATA_SIST_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      FILLER                REDEFINES        WDATA-CURR.*/
            private _REDEF_VA0955B_FILLER_141 _filler_141 { get; set; }
            public _REDEF_VA0955B_FILLER_141 FILLER_141
            {
                get { _filler_141 = new _REDEF_VA0955B_FILLER_141(); _.Move(WDATA_CURR, _filler_141); VarBasis.RedefinePassValue(WDATA_CURR, _filler_141, WDATA_CURR); _filler_141.ValueChanged += () => { _.Move(_filler_141, WDATA_CURR); }; return _filler_141; }
                set { VarBasis.RedefinePassValue(value, _filler_141, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_VA0955B_FILLER_141 : VarBasis
            {
                /*"    10    WDATA-AA-CURR         PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-MM-CURR         PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-DD-CURR         PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-EDIT.*/

                public _REDEF_VA0955B_FILLER_141()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_142.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_143.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public VA0955B_WDATA_EDIT WDATA_EDIT { get; set; } = new VA0955B_WDATA_EDIT();
            public class VA0955B_WDATA_EDIT : VarBasis
            {
                /*"    10    WDATA-DD-EDIT         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_DD_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDATA-MM-EDIT         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_MM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDATA-AA-EDIT         PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDATA_AA_EDIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WDATA-REFER           PIC  X(010)      VALUE SPACES.*/
            }
            public StringBasis WDATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      FILLER                REDEFINES        WDATA-REFER.*/
            private _REDEF_VA0955B_FILLER_146 _filler_146 { get; set; }
            public _REDEF_VA0955B_FILLER_146 FILLER_146
            {
                get { _filler_146 = new _REDEF_VA0955B_FILLER_146(); _.Move(WDATA_REFER, _filler_146); VarBasis.RedefinePassValue(WDATA_REFER, _filler_146, WDATA_REFER); _filler_146.ValueChanged += () => { _.Move(_filler_146, WDATA_REFER); }; return _filler_146; }
                set { VarBasis.RedefinePassValue(value, _filler_146, WDATA_REFER); }
            }  //Redefines
            public class _REDEF_VA0955B_FILLER_146 : VarBasis
            {
                /*"    10    WDATA-REF-ANO         PIC  9(004).*/
                public IntBasis WDATA_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-REF-MES         PIC  9(002).*/
                public IntBasis WDATA_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-REF-DIA         PIC  9(002).*/
                public IntBasis WDATA_REF_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WHORA-CURR.*/

                public _REDEF_VA0955B_FILLER_146()
                {
                    WDATA_REF_ANO.ValueChanged += OnValueChanged;
                    FILLER_147.ValueChanged += OnValueChanged;
                    WDATA_REF_MES.ValueChanged += OnValueChanged;
                    FILLER_148.ValueChanged += OnValueChanged;
                    WDATA_REF_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA0955B_WHORA_CURR WHORA_CURR { get; set; } = new VA0955B_WHORA_CURR();
            public class VA0955B_WHORA_CURR : VarBasis
            {
                /*"    10    WHORA-HH-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-MM-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-SS-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-CC-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WHORA-EDIT.*/
            }
            public VA0955B_WHORA_EDIT WHORA_EDIT { get; set; } = new VA0955B_WHORA_EDIT();
            public class VA0955B_WHORA_EDIT : VarBasis
            {
                /*"    10    WHORA-HH-EDIT         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-MM-EDIT         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-SS-EDIT         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01       LK-LINK.*/
            }
        }
        public VA0955B_LK_LINK LK_LINK { get; set; } = new VA0955B_LK_LINK();
        public class VA0955B_LK_LINK : VarBasis
        {
            /*"  05     LK-RTCODE              PIC S9(004)    VALUE +0  COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-TAMANHO             PIC S9(004)    VALUE +40 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05     LK-TITULO              PIC  X(132)    VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01       PARAMETROS-DT.*/
        }
        public VA0955B_PARAMETROS_DT PARAMETROS_DT { get; set; } = new VA0955B_PARAMETROS_DT();
        public class VA0955B_PARAMETROS_DT : VarBasis
        {
            /*"  05     LKDT-DATA-INI          PIC  X(010).*/
            public StringBasis LKDT_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05     LKDT-DATA-FIM          PIC  X(010).*/
            public StringBasis LKDT_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05     LKDT-QTDE-DIAS         PIC  9(009).*/
            public IntBasis LKDT_QTDE_DIAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05     LKDT-RETURN-CODE       PIC  9(002).*/
            public IntBasis LKDT_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05     LKDT-MENSAGEM          PIC  X(040).*/
            public StringBasis LKDT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01       WABEND.*/
        }
        public VA0955B_WABEND WABEND { get; set; } = new VA0955B_WABEND();
        public class VA0955B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE ' VA0955B'.*/
            public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0955B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE ' *** SQLCODE'*/
            public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE");
            /*"  05     WSQLCODE               PIC -------999     VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
        }


        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SINBENCB SINBENCB { get; set; } = new Dclgens.SINBENCB();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SINISACO SINISACO { get; set; } = new Dclgens.SINISACO();
        public Dclgens.CODIGOPE CODIGOPE { get; set; } = new Dclgens.CODIGOPE();
        public VA0955B_V0SINISTROS V0SINISTROS { get; set; } = new VA0955B_V0SINISTROS();
        public VA0955B_C_SINISACO C_SINISACO { get; set; } = new VA0955B_C_SINISACO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string AUDTSINI_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                AUDTSINI.SetFile(AUDTSINI_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-INICIO-SECTION */

                R0000_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-INICIO-SECTION */
        private void R0000_INICIO_SECTION()
        {
            /*" -577- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -578- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -581- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -584- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -588- OPEN OUTPUT AUDTSINI. */
            AUDTSINI.Open(REG_AUDTSINI, AREA_DE_WORK.W_STATUS);

            /*" -589- IF W-STATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W_STATUS != 00)
            {

                /*" -590- DISPLAY 'R0000 - ERRO NO OPEN DO ARQ AUDTSINI' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQ AUDTSINI");

                /*" -591- DISPLAY 'STATUS  - ' W-STATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.W_STATUS}");

                /*" -593- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -594- WRITE REG-AUDTSINI FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_AUDTSINI);

            AUDTSINI.Write(REG_AUDTSINI.GetMoveValues().ToString());

            /*" -596- WRITE REG-AUDTSINI FROM WCAB-AUDTSINI */
            _.Move(WCAB_AUDTSINI.GetMoveValues(), REG_AUDTSINI);

            AUDTSINI.Write(REG_AUDTSINI.GetMoveValues().ToString());

            /*" -598- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -600- PERFORM R0200-00-SELECT-V0EMPRESA. */

            R0200_00_SELECT_V0EMPRESA_SECTION();

            /*" -602- MOVE +500000 TO SORT-FILE-SIZE. */
            _.Move(+500000, SORT_FILE_SIZE);

            /*" -610- SORT ARQSORT ON ASCENDING KEY SD-TIP-PEND SD-RAMO-CBT SD-NUM-SINI INPUT PROCEDURE R0400-00-INPUT-SORT THRU R0400-99-SAIDA OUTPUT PROCEDURE R0700-00-OUTPUT-SORT THRU R0700-99-SAIDA. */
            SORT_RETURN.Value = ARQSORT.Sort("SD-TIP-PEND,SD-RAMO-CBT,SD-NUM-SINI", () => R0400_00_INPUT_SORT_SECTION(), () => R0700_00_OUTPUT_SORT_SECTION());

            /*" -613- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -614- DISPLAY 'VA0955B *** PROBLEMAS NO SORT ***' */
                _.Display($"VA0955B *** PROBLEMAS NO SORT ***");

                /*" -615- DISPLAY 'SORT-RETURN - ' SORT-RETURN */
                _.Display($"SORT-RETURN - {SORT_RETURN}");

                /*" -617- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -617- PERFORM R0300-00-DELETE-V0RELATORIOS. */

            R0300_00_DELETE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -623- MOVE W-TOT-VAL-OPER TO W-VAL-OPER-TOT. */
            _.Move(AREA_DE_WORK.W_TOT_VAL_OPER, AREA_DE_WORK.W_VAL_OPER_TOT);

            /*" -625- CLOSE AUDTSINI. */
            AUDTSINI.Close();

            /*" -626- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -627- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -628- DISPLAY '*   DADOS DE CONTROLE DE PROCESSAMENTO       *' . */
            _.Display($"*   DADOS DE CONTROLE DE PROCESSAMENTO       *");

            /*" -629- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -630- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -631- DISPLAY ' ' */
            _.Display($" ");

            /*" -633- DISPLAY '* NUMERO DE REGISTROS LIDOS NA SINISTROS   = ' AC-L-SINISTROS. */
            _.Display($"* NUMERO DE REGISTROS LIDOS NA SINISTROS   = {AREA_DE_WORK.AC_L_SINISTROS}");

            /*" -635- DISPLAY '* NUMERO DE REGISTROS GRAVADOS NO ARQSORT  = ' AC-G-ARQSORT. */
            _.Display($"* NUMERO DE REGISTROS GRAVADOS NO ARQSORT  = {AREA_DE_WORK.AC_G_ARQSORT}");

            /*" -637- DISPLAY '* NUMERO DE REGISTROS LIDOS NO ARQSORT     = ' AC-L-ARQSORT. */
            _.Display($"* NUMERO DE REGISTROS LIDOS NO ARQSORT     = {AREA_DE_WORK.AC_L_ARQSORT}");

            /*" -639- DISPLAY '* NUM. DE REGISTROS GRAV. NO ARQ. AUDTSINI = ' AC-G-AUDTSINI. */
            _.Display($"* NUM. DE REGISTROS GRAV. NO ARQ. AUDTSINI = {AREA_DE_WORK.AC_G_AUDTSINI}");

            /*" -642- DISPLAY '* VALOR TOTAL DAS OPERACOES DE PENDENCIA   = ' W-VAL-OPER-TOT. */
            _.Display($"* VALOR TOTAL DAS OPERACOES DE PENDENCIA   = {AREA_DE_WORK.W_VAL_OPER_TOT}");

            /*" -643- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -644- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -645- DISPLAY '*                PROGRAMA                    *' . */
            _.Display($"*                PROGRAMA                    *");

            /*" -646- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -647- DISPLAY '*            ==> VA0955B <==                 *' . */
            _.Display($"*            ==> VA0955B <==                 *");

            /*" -648- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -649- DISPLAY '*   TERMINO  ==> N O R M A L <==             *' . */
            _.Display($"*   TERMINO  ==> N O R M A L <==             *");

            /*" -650- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -652- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -652- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -656- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -656- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -669- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -678- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -681- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -682- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA");

                /*" -683- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -684- ELSE */
            }
            else
            {


                /*" -687- DISPLAY 'DATA DO MOVIMENTO VA - ' V0SIST-DTMOVABE. */
                _.Display($"DATA DO MOVIMENTO VA - {V0SIST_DTMOVABE}");
            }


            /*" -688- MOVE V0SIST-DTMOVABE TO WHOST-DTH-INI */
            _.Move(V0SIST_DTMOVABE, WHOST_DTH_INI);

            /*" -690- MOVE V0SIST-DTMOVABE TO WHOST-DTH-FIM. */
            _.Move(V0SIST_DTMOVABE, WHOST_DTH_FIM);

            /*" -692- MOVE '01' TO WHOST-DTH-INI(9:2). */
            _.MoveAtPosition("01", WHOST_DTH_INI, 9, 2);

            /*" -693- MOVE V0SIST-DTMOVABE(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(1, 4), LD00.LD00_DATAINI, 7, 4);

            /*" -694- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 3, 1);

            /*" -695- MOVE V0SIST-DTMOVABE(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(6, 2), LD00.LD00_DATAINI, 4, 2);

            /*" -696- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00.LD00_DATAINI, 6, 1);

            /*" -696- MOVE V0SIST-DTMOVABE(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(V0SIST_DTMOVABE.Substring(9, 2), LD00.LD00_DATAINI, 1, 2);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -678- EXEC SQL SELECT DTMOVABE - 1 YEAR, DTMOVABE, CURRENT DATE INTO :V0SIST-DTMOVABE-1, :V0SIST-DTMOVABE, :V0SIST-DTCURRENT FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE_1, V0SIST_DTMOVABE_1);
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.V0SIST_DTCURRENT, V0SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0EMPRESA-SECTION */
        private void R0200_00_SELECT_V0EMPRESA_SECTION()
        {
            /*" -709- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -714- PERFORM R0200_00_SELECT_V0EMPRESA_DB_SELECT_1 */

            R0200_00_SELECT_V0EMPRESA_DB_SELECT_1();

            /*" -717- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -718- DISPLAY 'R0200 - ERRO NO SELECT DA V0EMPRESA' */
                _.Display($"R0200 - ERRO NO SELECT DA V0EMPRESA");

                /*" -720- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -721- MOVE V0SIST-DTCURRENT TO WDATA-CURR. */
            _.Move(V0SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -722- MOVE WDATA-DD-CURR TO WDATA-DD-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_141.WDATA_DD_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDIT);

            /*" -723- MOVE WDATA-MM-CURR TO WDATA-MM-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_141.WDATA_MM_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDIT);

            /*" -725- MOVE WDATA-AA-CURR TO WDATA-AA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_141.WDATA_AA_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDIT);

            /*" -726- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -727- MOVE WHORA-HH-CURR TO WHORA-HH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDIT);

            /*" -728- MOVE WHORA-MM-CURR TO WHORA-MM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDIT);

            /*" -728- MOVE WHORA-SS-CURR TO WHORA-SS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDIT);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V0EMPRESA-DB-SELECT-1 */
        public void R0200_00_SELECT_V0EMPRESA_DB_SELECT_1()
        {
            /*" -714- EXEC SQL SELECT NOME_EMPRESA INTO :V0EMPR-NOME-EMPR FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0EMPR_NOME_EMPR, V0EMPR_NOME_EMPR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DELETE-V0RELATORIOS-SECTION */
        private void R0300_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -738- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-INPUT-SORT-SECTION */
        private void R0400_00_INPUT_SORT_SECTION()
        {
            /*" -766- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -768- PERFORM R0500-00-DECLARE-V0SINISTROS. */

            R0500_00_DECLARE_V0SINISTROS_SECTION();

            /*" -770- PERFORM R0550-00-FETCH-V0SINISTROS. */

            R0550_00_FETCH_V0SINISTROS_SECTION();

            /*" -771- IF WFIM-V0SINISTROS = 'S' */

            if (AREA_DE_WORK.WFIM_V0SINISTROS == "S")
            {

                /*" -772- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -773- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -774- ELSE */
            }
            else
            {


                /*" -775- PERFORM R0600-00-PROCESSA-SINISTROS UNTIL WFIM-V0SINISTROS NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V0SINISTROS.IsEmpty()))
                {

                    R0600_00_PROCESSA_SINISTROS_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V0SINISTROS-SECTION */
        private void R0500_00_DECLARE_V0SINISTROS_SECTION()
        {
            /*" -788- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -802- PERFORM R0500_00_DECLARE_V0SINISTROS_DB_DECLARE_1 */

            R0500_00_DECLARE_V0SINISTROS_DB_DECLARE_1();

            /*" -804- PERFORM R0500_00_DECLARE_V0SINISTROS_DB_OPEN_1 */

            R0500_00_DECLARE_V0SINISTROS_DB_OPEN_1();

            /*" -807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- DISPLAY 'R0500 - ERRO NO DECLARE DA V0SINISTROS' */
                _.Display($"R0500 - ERRO NO DECLARE DA V0SINISTROS");

                /*" -809- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -810- ELSE */
            }
            else
            {


                /*" -810- MOVE SPACES TO WFIM-V0SINISTROS. */
                _.Move("", AREA_DE_WORK.WFIM_V0SINISTROS);
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0SINISTROS-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V0SINISTROS_DB_DECLARE_1()
        {
            /*" -802- EXEC SQL DECLARE V0SINISTROS CURSOR FOR SELECT NUM_APOL_SINISTRO, COD_OPERACAO , OCORR_HISTORICO , NOME_FAVORECIDO , DATA_MOVIMENTO , SIT_CONTABIL , VAL_OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE DATA_MOVIMENTO BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND COD_OPERACAO = 101 ORDER BY DATA_MOVIMENTO END-EXEC. */
            V0SINISTROS = new VA0955B_V0SINISTROS(true);
            string GetQuery_V0SINISTROS()
            {
                var query = @$"SELECT NUM_APOL_SINISTRO
							, 
							COD_OPERACAO
							, 
							OCORR_HISTORICO
							, 
							NOME_FAVORECIDO
							, 
							DATA_MOVIMENTO
							, 
							SIT_CONTABIL
							, 
							VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_HISTORICO 
							WHERE DATA_MOVIMENTO BETWEEN '{WHOST_DTH_INI}' 
							AND '{WHOST_DTH_FIM}' 
							AND COD_OPERACAO = 101 
							ORDER BY 
							DATA_MOVIMENTO";

                return query;
            }
            V0SINISTROS.GetQueryEvent += GetQuery_V0SINISTROS;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V0SINISTROS-DB-OPEN-1 */
        public void R0500_00_DECLARE_V0SINISTROS_DB_OPEN_1()
        {
            /*" -804- EXEC SQL OPEN V0SINISTROS END-EXEC. */

            V0SINISTROS.Open();

        }

        [StopWatch]
        /*" R1450-00-SELECT-SINISACO-DB-DECLARE-1 */
        public void R1450_00_SELECT_SINISACO_DB_DECLARE_1()
        {
            /*" -1741- EXEC SQL DECLARE C_SINISACO CURSOR FOR SELECT B.COD_OPERACAO , B.DESCR_OPERACAO FROM SEGUROS.SINISTRO_ACOMPANHA A, SEGUROS.CODIGO_OPERACAO B WHERE A.COD_FONTE = :V0MSIN-FONTE AND A.NUM_PROTOCOLO_SINI = :V0MSIN-PROTSINI AND B.COD_OPERACAO = A.COD_OPERACAO AND A.COD_OPERACAO IN (720, 1244, 1245, 1246, 1247, 1248, 675, 704, 1004, 1179, 1180) ORDER BY A.DATA_OPERACAO DESC END-EXEC. */
            C_SINISACO = new VA0955B_C_SINISACO(true);
            string GetQuery_C_SINISACO()
            {
                var query = @$"SELECT 
							B.COD_OPERACAO
							, 
							B.DESCR_OPERACAO 
							FROM SEGUROS.SINISTRO_ACOMPANHA A
							, 
							SEGUROS.CODIGO_OPERACAO B 
							WHERE A.COD_FONTE = '{V0MSIN_FONTE}' 
							AND A.NUM_PROTOCOLO_SINI = '{V0MSIN_PROTSINI}' 
							AND B.COD_OPERACAO = A.COD_OPERACAO 
							AND A.COD_OPERACAO IN (720
							, 
							1244
							, 
							1245
							, 
							1246
							, 
							1247
							, 
							1248
							, 
							675
							, 
							704
							, 
							1004
							, 
							1179
							, 
							1180) 
							ORDER BY A.DATA_OPERACAO DESC";

                return query;
            }
            C_SINISACO.GetQueryEvent += GetQuery_C_SINISACO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-FETCH-V0SINISTROS-SECTION */
        private void R0550_00_FETCH_V0SINISTROS_SECTION()
        {
            /*" -823- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", WABEND.WNR_EXEC_SQL);

            /*" -831- PERFORM R0550_00_FETCH_V0SINISTROS_DB_FETCH_1 */

            R0550_00_FETCH_V0SINISTROS_DB_FETCH_1();

            /*" -834- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -835- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -836- MOVE 'S' TO WFIM-V0SINISTROS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0SINISTROS);

                    /*" -836- PERFORM R0550_00_FETCH_V0SINISTROS_DB_CLOSE_1 */

                    R0550_00_FETCH_V0SINISTROS_DB_CLOSE_1();

                    /*" -838- ELSE */
                }
                else
                {


                    /*" -839- DISPLAY 'R0550 - ERRO NO FETCH DA V0SINISTROS' */
                    _.Display($"R0550 - ERRO NO FETCH DA V0SINISTROS");

                    /*" -840- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -841- ELSE */
                }

            }
            else
            {


                /*" -841- ADD 1 TO AC-L-SINISTROS. */
                AREA_DE_WORK.AC_L_SINISTROS.Value = AREA_DE_WORK.AC_L_SINISTROS + 1;
            }


        }

        [StopWatch]
        /*" R0550-00-FETCH-V0SINISTROS-DB-FETCH-1 */
        public void R0550_00_FETCH_V0SINISTROS_DB_FETCH_1()
        {
            /*" -831- EXEC SQL FETCH V0SINISTROS INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-COD-OPERACAO , :SINISHIS-OCORR-HISTORICO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-SIT-CONTABIL, :SINISHIS-VAL-OPERACAO END-EXEC. */

            if (V0SINISTROS.Fetch())
            {
                _.Move(V0SINISTROS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(V0SINISTROS.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(V0SINISTROS.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(V0SINISTROS.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(V0SINISTROS.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(V0SINISTROS.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(V0SINISTROS.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0550-00-FETCH-V0SINISTROS-DB-CLOSE-1 */
        public void R0550_00_FETCH_V0SINISTROS_DB_CLOSE_1()
        {
            /*" -836- EXEC SQL CLOSE V0SINISTROS END-EXEC */

            V0SINISTROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROCESSA-SINISTROS-SECTION */
        private void R0600_00_PROCESSA_SINISTROS_SECTION()
        {
            /*" -854- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -856- MOVE SPACES TO REG-ARQSORT. */
            _.Move("", REG_ARQSORT);

            /*" -857- MOVE SINISHIS-NUM-APOL-SINISTRO TO SD-NUM-SINI. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, REG_ARQSORT.SD_NUM_SINI);

            /*" -858- MOVE SINISHIS-COD-OPERACAO TO SD-COD-OPER. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, REG_ARQSORT.SD_COD_OPER);

            /*" -859- MOVE SINISHIS-OCORR-HISTORICO TO SD-OCORHIST. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, REG_ARQSORT.SD_OCORHIST);

            /*" -860- MOVE SINISHIS-VAL-OPERACAO TO SD-VAL-OPER. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, REG_ARQSORT.SD_VAL_OPER);

            /*" -861- MOVE SINISHIS-DATA-MOVIMENTO TO SD-DTMOVTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_ARQSORT.SD_DTMOVTO);

            /*" -862- MOVE SINISHIS-SIT-CONTABIL TO SD-SIT-CONT. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL, REG_ARQSORT.SD_SIT_CONT);

            /*" -864- MOVE SINISHIS-NOME-FAVORECIDO TO SD-NOMFAV. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, REG_ARQSORT.SD_NOMFAV);

            /*" -866- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -866- ADD 1 TO AC-G-ARQSORT. */
            AREA_DE_WORK.AC_G_ARQSORT.Value = AREA_DE_WORK.AC_G_ARQSORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0600_90_PROXIMO_REGISTRO */

            R0600_90_PROXIMO_REGISTRO();

        }

        [StopWatch]
        /*" R0600-90-PROXIMO-REGISTRO */
        private void R0600_90_PROXIMO_REGISTRO(bool isPerform = false)
        {
            /*" -870- PERFORM R0550-00-FETCH-V0SINISTROS. */

            R0550_00_FETCH_V0SINISTROS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-OUTPUT-SORT-SECTION */
        private void R0700_00_OUTPUT_SORT_SECTION()
        {
            /*" -883- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -884- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -885- DISPLAY 'R0700 - ERRO NO ARQUIVO DO SORT' */
                _.Display($"R0700 - ERRO NO ARQUIVO DO SORT");

                /*" -886- DISPLAY 'SORT-RETURN - ' SORT-RETURN */
                _.Display($"SORT-RETURN - {SORT_RETURN}");

                /*" -888- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -890- INITIALIZE TABELA-SINI-PENDT. */
            _.Initialize(
                W_TABELAS.TABELA_SINI_PENDT
            );

            /*" -892- PERFORM R0750-00-LER-ARQSORT. */

            R0750_00_LER_ARQSORT_SECTION();

            /*" -894- IF WFIM-ARQSORT NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_ARQSORT.IsEmpty())
            {

                /*" -895- ELSE */
            }
            else
            {


                /*" -896- PERFORM R0800-00-PROCESSA-PENDENTE UNTIL WFIM-ARQSORT NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_ARQSORT.IsEmpty()))
                {

                    R0800_00_PROCESSA_PENDENTE_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0750-00-LER-ARQSORT-SECTION */
        private void R0750_00_LER_ARQSORT_SECTION()
        {
            /*" -908- MOVE '0750' TO WNR-EXEC-SQL. */
            _.Move("0750", WABEND.WNR_EXEC_SQL);

            /*" -910- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -911- MOVE 'S' TO WFIM-ARQSORT */
                    _.Move("S", AREA_DE_WORK.WFIM_ARQSORT);

                    /*" -913- GO TO R0750-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -913- ADD 1 TO AC-L-ARQSORT. */
            AREA_DE_WORK.AC_L_ARQSORT.Value = AREA_DE_WORK.AC_L_ARQSORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-PENDENTE-SECTION */
        private void R0800_00_PROCESSA_PENDENTE_SECTION()
        {
            /*" -926- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -928- MOVE SD-TIP-PEND TO WTIP-PEND-ANT. */
            _.Move(REG_ARQSORT.SD_TIP_PEND, AREA_DE_WORK.WTIP_PEND_ANT);

            /*" -930- PERFORM R0900-00-PROCESSA-TIPO-PEND UNTIL WFIM-ARQSORT NOT EQUAL SPACES OR SD-TIP-PEND NOT EQUAL WTIP-PEND-ANT. */

            while (!(!AREA_DE_WORK.WFIM_ARQSORT.IsEmpty() || REG_ARQSORT.SD_TIP_PEND != AREA_DE_WORK.WTIP_PEND_ANT))
            {

                R0900_00_PROCESSA_TIPO_PEND_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-PROCESSA-TIPO-PEND-SECTION */
        private void R0900_00_PROCESSA_TIPO_PEND_SECTION()
        {
            /*" -943- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -945- MOVE SD-RAMO-CBT TO WCOD-RAMO-ANT. */
            _.Move(REG_ARQSORT.SD_RAMO_CBT, AREA_DE_WORK.WCOD_RAMO_ANT);

            /*" -948- PERFORM R1000-00-PROCESSA-RAMO-COBT UNTIL WFIM-ARQSORT NOT EQUAL SPACES OR SD-TIP-PEND NOT EQUAL WTIP-PEND-ANT OR SD-RAMO-CBT NOT EQUAL WCOD-RAMO-ANT. */

            while (!(!AREA_DE_WORK.WFIM_ARQSORT.IsEmpty() || REG_ARQSORT.SD_TIP_PEND != AREA_DE_WORK.WTIP_PEND_ANT || REG_ARQSORT.SD_RAMO_CBT != AREA_DE_WORK.WCOD_RAMO_ANT))
            {

                R1000_00_PROCESSA_RAMO_COBT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-RAMO-COBT-SECTION */
        private void R1000_00_PROCESSA_RAMO_COBT_SECTION()
        {
            /*" -961- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -963- MOVE SD-NUM-SINI TO V0MSIN-NUM-SINI. */
            _.Move(REG_ARQSORT.SD_NUM_SINI, V0MSIN_NUM_SINI);

            /*" -965- PERFORM R1100-00-SELECT-V0MESTSINI. */

            R1100_00_SELECT_V0MESTSINI_SECTION();

            /*" -966- IF WTEM-SINISMES EQUAL 'NAO' */

            if (AREA_DE_WORK.WTEM_SINISMES == "NAO")
            {

                /*" -968- GO TO R1000-90-LER-REGISTRO. */

                R1000_90_LER_REGISTRO(); //GOTO
                return;
            }


            /*" -970- PERFORM R1200-00-SELECT-V0HISTSINI. */

            R1200_00_SELECT_V0HISTSINI_SECTION();

            /*" -972- PERFORM R1205-00-SELECT-V0HISTSINI. */

            R1205_00_SELECT_V0HISTSINI_SECTION();

            /*" -974- PERFORM R1206-00-SELECT-V0HISTSINI. */

            R1206_00_SELECT_V0HISTSINI_SECTION();

            /*" -976- PERFORM R1207-00-SELECT-V0HISTSINI. */

            R1207_00_SELECT_V0HISTSINI_SECTION();

            /*" -977- IF V0MSIN-NRCERTIF > 0 */

            if (V0MSIN_NRCERTIF > 0)
            {

                /*" -978- PERFORM R1210-00-SELECT-SEGURVGA */

                R1210_00_SELECT_SEGURVGA_SECTION();

                /*" -979- IF WTEM-SEGURVGA EQUAL 'NAO' */

                if (AREA_DE_WORK.WTEM_SEGURVGA == "NAO")
                {

                    /*" -980- GO TO R1000-90-LER-REGISTRO */

                    R1000_90_LER_REGISTRO(); //GOTO
                    return;

                    /*" -981- END-IF */
                }


                /*" -982- ELSE */
            }
            else
            {


                /*" -983- PERFORM R1215-00-SELECT-BILHETE */

                R1215_00_SELECT_BILHETE_SECTION();

                /*" -984- IF WTEM-BILHETE EQUAL 'NAO' */

                if (AREA_DE_WORK.WTEM_BILHETE == "NAO")
                {

                    /*" -985- GO TO R1000-90-LER-REGISTRO */

                    R1000_90_LER_REGISTRO(); //GOTO
                    return;

                    /*" -986- END-IF */
                }


                /*" -988- END-IF */
            }


            /*" -990- PERFORM R1220-00-SELECT-ENDOSSOS */

            R1220_00_SELECT_ENDOSSOS_SECTION();

            /*" -990- PERFORM R1400-00-GRAVA-ARQV-AUDTSINI. */

            R1400_00_GRAVA_ARQV_AUDTSINI_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LER_REGISTRO */

            R1000_90_LER_REGISTRO();

        }

        [StopWatch]
        /*" R1000-90-LER-REGISTRO */
        private void R1000_90_LER_REGISTRO(bool isPerform = false)
        {
            /*" -994- PERFORM R0750-00-LER-ARQSORT. */

            R0750_00_LER_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0MESTSINI-SECTION */
        private void R1100_00_SELECT_V0MESTSINI_SECTION()
        {
            /*" -1005- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -1008- MOVE 'SIM' TO WTEM-SINISMES */
            _.Move("SIM", AREA_DE_WORK.WTEM_SINISMES);

            /*" -1035- PERFORM R1100_00_SELECT_V0MESTSINI_DB_SELECT_1 */

            R1100_00_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -1038- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1039- DISPLAY 'R1100 - ERRO NO SELECT DA V0MESTSINI' */
                _.Display($"R1100 - ERRO NO SELECT DA V0MESTSINI");

                /*" -1040- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                /*" -1042- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1043- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1044- MOVE 'NAO' TO WTEM-SINISMES */
                _.Move("NAO", AREA_DE_WORK.WTEM_SINISMES);

                /*" -1046- END-IF. */
            }


            /*" -1048- IF V0MSIN-RAMO = 77 OR 81 OR 82 OR 93 OR 97 NEXT SENTENCE */

            if (V0MSIN_RAMO.In("77", "81", "82", "93", "97"))
            {

                /*" -1049- ELSE */
            }
            else
            {


                /*" -1050- MOVE 'NAO' TO WTEM-SINISMES */
                _.Move("NAO", AREA_DE_WORK.WTEM_SINISMES);

                /*" -1050- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R1100_00_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -1035- EXEC SQL SELECT NUM_APOL_SINISTRO, NUM_APOLICE, TIPREG, FONTE, RAMO, CODLIDER, SINLID, DATCMD, DATORR, DATTEC, NRCERTIF, CODCAU INTO :V0MSIN-NUM-SINI, :V0MSIN-NUM-APOL, :V0MSIN-TIPREG, :V0MSIN-FONTE, :V0MSIN-RAMO, :V0MSIN-CODLIDER, :V0MSIN-SINLID, :V0MSIN-DATCMD, :V0MSIN-DATORR, :V0MSIN-DATTEC, :V0MSIN-NRCERTIF, :V0MSIN-CODCAU FROM SEGUROS.V0MESTSINI WHERE NUM_APOL_SINISTRO = :V0MSIN-NUM-SINI END-EXEC. */

            var r1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                V0MSIN_NUM_SINI = V0MSIN_NUM_SINI.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_NUM_SINI, V0MSIN_NUM_SINI);
                _.Move(executed_1.V0MSIN_NUM_APOL, V0MSIN_NUM_APOL);
                _.Move(executed_1.V0MSIN_TIPREG, V0MSIN_TIPREG);
                _.Move(executed_1.V0MSIN_FONTE, V0MSIN_FONTE);
                _.Move(executed_1.V0MSIN_RAMO, V0MSIN_RAMO);
                _.Move(executed_1.V0MSIN_CODLIDER, V0MSIN_CODLIDER);
                _.Move(executed_1.V0MSIN_SINLID, V0MSIN_SINLID);
                _.Move(executed_1.V0MSIN_DATCMD, V0MSIN_DATCMD);
                _.Move(executed_1.V0MSIN_DATORR, V0MSIN_DATORR);
                _.Move(executed_1.V0MSIN_DATTEC, V0MSIN_DATTEC);
                _.Move(executed_1.V0MSIN_NRCERTIF, V0MSIN_NRCERTIF);
                _.Move(executed_1.V0MSIN_CODCAU, V0MSIN_CODCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0HISTSINI-SECTION */
        private void R1200_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -1063- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1069- PERFORM R1200_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R1200_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -1072- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1073- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1074- MOVE ZEROS TO V0HSIN-VAL-OPERACAO */
                    _.Move(0, V0HSIN_VAL_OPERACAO);

                    /*" -1075- ELSE */
                }
                else
                {


                    /*" -1076- DISPLAY 'R1200 - ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"R1200 - ERRO NO SELECT DA V0HISTSINI");

                    /*" -1077- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1077- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R1200_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -1069- EXEC SQL SELECT VAL_OPERACAO INTO :V0HSIN-VAL-OPERACAO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0MSIN-NUM-SINI AND OPERACAO = 101 END-EXEC. */

            var r1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                V0MSIN_NUM_SINI = V0MSIN_NUM_SINI.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSIN_VAL_OPERACAO, V0HSIN_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1205-00-SELECT-V0HISTSINI-SECTION */
        private void R1205_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -1090- MOVE '1205' TO WNR-EXEC-SQL. */
            _.Move("1205", WABEND.WNR_EXEC_SQL);

            /*" -1091- MOVE SD-NUM-SINI TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(REG_ARQSORT.SD_NUM_SINI, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -1093- MOVE SD-OCORHIST TO SINISHIS-OCORR-HISTORICO */
            _.Move(REG_ARQSORT.SD_OCORHIST, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -1100- PERFORM R1205_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R1205_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -1103- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1104- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1105- MOVE SPACES TO V0HSIN-CODUSU-PRE */
                    _.Move("", V0HSIN_CODUSU_PRE);

                    /*" -1106- ELSE */
                }
                else
                {


                    /*" -1107- DISPLAY 'R1205 - ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"R1205 - ERRO NO SELECT DA V0HISTSINI");

                    /*" -1108- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1110- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1111- IF VIND-CODUSU-PRE LESS +0 */

            if (VIND_CODUSU_PRE < +0)
            {

                /*" -1112- MOVE SPACES TO V0HSIN-CODUSU-PRE */
                _.Move("", V0HSIN_CODUSU_PRE);

                /*" -1112- END-IF. */
            }


        }

        [StopWatch]
        /*" R1205-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R1205_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -1100- EXEC SQL SELECT MAX(CODUSU) INTO :V0HSIN-CODUSU-PRE:VIND-CODUSU-PRE FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORHIST = :SINISHIS-OCORR-HISTORICO AND OPERACAO IN (1181, 1182, 1183) END-EXEC. */

            var r1205_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R1205_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1205_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r1205_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSIN_CODUSU_PRE, V0HSIN_CODUSU_PRE);
                _.Move(executed_1.VIND_CODUSU_PRE, VIND_CODUSU_PRE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1205_99_SAIDA*/

        [StopWatch]
        /*" R1206-00-SELECT-V0HISTSINI-SECTION */
        private void R1206_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -1125- MOVE '1206' TO WNR-EXEC-SQL. */
            _.Move("1206", WABEND.WNR_EXEC_SQL);

            /*" -1132- PERFORM R1206_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R1206_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -1135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1136- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1137- MOVE SPACES TO V0HSIN-CODUSU-LIB */
                    _.Move("", V0HSIN_CODUSU_LIB);

                    /*" -1138- ELSE */
                }
                else
                {


                    /*" -1139- DISPLAY 'R1206 - ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"R1206 - ERRO NO SELECT DA V0HISTSINI");

                    /*" -1140- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1142- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1143- IF VIND-CODUSU-LIB LESS +0 */

            if (VIND_CODUSU_LIB < +0)
            {

                /*" -1144- MOVE SPACES TO V0HSIN-CODUSU-LIB */
                _.Move("", V0HSIN_CODUSU_LIB);

                /*" -1144- END-IF. */
            }


        }

        [StopWatch]
        /*" R1206-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R1206_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -1132- EXEC SQL SELECT MAX(CODUSU) INTO :V0HSIN-CODUSU-LIB:VIND-CODUSU-LIB FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORHIST = :SINISHIS-OCORR-HISTORICO AND OPERACAO IN (1081, 1082, 1083, 1084) END-EXEC. */

            var r1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSIN_CODUSU_LIB, V0HSIN_CODUSU_LIB);
                _.Move(executed_1.VIND_CODUSU_LIB, VIND_CODUSU_LIB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1206_99_SAIDA*/

        [StopWatch]
        /*" R1207-00-SELECT-V0HISTSINI-SECTION */
        private void R1207_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -1157- MOVE '1207' TO WNR-EXEC-SQL. */
            _.Move("1207", WABEND.WNR_EXEC_SQL);

            /*" -1159- MOVE SD-DTMOVTO TO SINISHIS-DATA-MOVIMENTO */
            _.Move(REG_ARQSORT.SD_DTMOVTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -1167- PERFORM R1207_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R1207_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -1170- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1171- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1172- MOVE ZEROS TO V0HSIN-VAL-JURO */
                    _.Move(0, V0HSIN_VAL_JURO);

                    /*" -1173- ELSE */
                }
                else
                {


                    /*" -1174- DISPLAY 'R1207 - ERRO NO SELECT V0HISTSINI   ' */
                    _.Display($"R1207 - ERRO NO SELECT V0HISTSINI   ");

                    /*" -1175- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1177- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1178- IF VIND-VAL-JURO LESS +0 */

            if (VIND_VAL_JURO < +0)
            {

                /*" -1179- MOVE ZEROS TO V0HSIN-VAL-JURO */
                _.Move(0, V0HSIN_VAL_JURO);

                /*" -1179- END-IF. */
            }


        }

        [StopWatch]
        /*" R1207-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R1207_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -1167- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :V0HSIN-VAL-JURO:VIND-VAL-JURO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORHIST = :SINISHIS-OCORR-HISTORICO AND DTMOVTO = :SINISHIS-DATA-MOVIMENTO AND OPERACAO IN (1301, 1302) END-EXEC. */

            var r1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
            };

            var executed_1 = R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSIN_VAL_JURO, V0HSIN_VAL_JURO);
                _.Move(executed_1.VIND_VAL_JURO, VIND_VAL_JURO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1207_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-SEGURVGA-SECTION */
        private void R1210_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -1191- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -1193- MOVE 'SIM' TO WTEM-SEGURVGA */
            _.Move("SIM", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -1217- PERFORM R1210_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1210_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -1220- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1221- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1222- MOVE 'NAO' TO WTEM-SEGURVGA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -1223- GO TO R1210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1224- ELSE */
                }
                else
                {


                    /*" -1225- DISPLAY 'R1210 - ERRO NO SELECT DA SEGURADOS_VGAP' */
                    _.Display($"R1210 - ERRO NO SELECT DA SEGURADOS_VGAP");

                    /*" -1226- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1228- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1231- MOVE '1211' TO WNR-EXEC-SQL. */
            _.Move("1211", WABEND.WNR_EXEC_SQL);

            /*" -1233- INITIALIZE DCLCLIENTES. */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -1240- PERFORM R1210_00_SELECT_SEGURVGA_DB_SELECT_2 */

            R1210_00_SELECT_SEGURVGA_DB_SELECT_2();

            /*" -1243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1244- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1245- GO TO R1210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1246- ELSE */
                }
                else
                {


                    /*" -1247- DISPLAY 'R1210 - ERRO NO SELECT DA CLIENTES      ' */
                    _.Display($"R1210 - ERRO NO SELECT DA CLIENTES      ");

                    /*" -1248- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1250- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1253- MOVE '1212' TO WNR-EXEC-SQL. */
            _.Move("1212", WABEND.WNR_EXEC_SQL);

            /*" -1255- INITIALIZE DCLENDERECOS. */
            _.Initialize(
                ENDERECO.DCLENDERECOS
            );

            /*" -1267- PERFORM R1210_00_SELECT_SEGURVGA_DB_SELECT_3 */

            R1210_00_SELECT_SEGURVGA_DB_SELECT_3();

            /*" -1270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1271- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1272- GO TO R1210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1273- ELSE */
                }
                else
                {


                    /*" -1274- DISPLAY 'R1210 - ERRO NO SELECT DA ENDERECO      ' */
                    _.Display($"R1210 - ERRO NO SELECT DA ENDERECO      ");

                    /*" -1275- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1277- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1280- MOVE '1213' TO WNR-EXEC-SQL. */
            _.Move("1213", WABEND.WNR_EXEC_SQL);

            /*" -1282- INITIALIZE DCLPROPOSTAS-VA. */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -1284- MOVE 'SIM' TO WTEM-PROPOVA */
            _.Move("SIM", AREA_DE_WORK.WTEM_PROPOVA);

            /*" -1293- PERFORM R1210_00_SELECT_SEGURVGA_DB_SELECT_4 */

            R1210_00_SELECT_SEGURVGA_DB_SELECT_4();

            /*" -1296- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1297- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1298- MOVE 'NAO' TO WTEM-PROPOVA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PROPOVA);

                    /*" -1299- GO TO R1210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1300- ELSE */
                }
                else
                {


                    /*" -1301- DISPLAY 'R1210 - ERRO NO SELECT DA ENDERECO      ' */
                    _.Display($"R1210 - ERRO NO SELECT DA ENDERECO      ");

                    /*" -1302- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1302- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1210_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -1217- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, NUM_CERTIFICADO, OCORR_HISTORICO, COD_CLIENTE, DATA_INIVIGENCIA, OCORR_ENDERECO, NUM_MATRICULA, AGE_COBRANCA INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-DATA-INIVIGENCIA, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-AGE-COBRANCA FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :V0MSIN-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                V0MSIN_NRCERTIF = V0MSIN_NRCERTIF.ToString(),
            };

            var executed_1 = R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(executed_1.SEGURVGA_NUM_MATRICULA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);
                _.Move(executed_1.SEGURVGA_AGE_COBRANCA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-SEGURVGA-DB-SELECT-2 */
        public void R1210_00_SELECT_SEGURVGA_DB_SELECT_2()
        {
            /*" -1240- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

            var r1210_00_SELECT_SEGURVGA_DB_SELECT_2_Query1 = new R1210_00_SELECT_SEGURVGA_DB_SELECT_2_Query1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1210_00_SELECT_SEGURVGA_DB_SELECT_2_Query1.Execute(r1210_00_SELECT_SEGURVGA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R1215-00-SELECT-BILHETE-SECTION */
        private void R1215_00_SELECT_BILHETE_SECTION()
        {
            /*" -1315- MOVE '1215' TO WNR-EXEC-SQL. */
            _.Move("1215", WABEND.WNR_EXEC_SQL);

            /*" -1317- MOVE 'SIM' TO WTEM-BILHETE */
            _.Move("SIM", AREA_DE_WORK.WTEM_BILHETE);

            /*" -1338- PERFORM R1215_00_SELECT_BILHETE_DB_SELECT_1 */

            R1215_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1342- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1343- MOVE 'NAO' TO WTEM-BILHETE */
                    _.Move("NAO", AREA_DE_WORK.WTEM_BILHETE);

                    /*" -1344- GO TO R1215-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1215_99_SAIDA*/ //GOTO
                    return;

                    /*" -1345- ELSE */
                }
                else
                {


                    /*" -1346- DISPLAY 'R1215 - ERRO NO SELECT DA BILHETE       ' */
                    _.Display($"R1215 - ERRO NO SELECT DA BILHETE       ");

                    /*" -1347- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1349- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1352- MOVE '1216' TO WNR-EXEC-SQL. */
            _.Move("1216", WABEND.WNR_EXEC_SQL);

            /*" -1354- INITIALIZE DCLCLIENTES. */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -1361- PERFORM R1215_00_SELECT_BILHETE_DB_SELECT_2 */

            R1215_00_SELECT_BILHETE_DB_SELECT_2();

            /*" -1364- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1365- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1366- GO TO R1215-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1215_99_SAIDA*/ //GOTO
                    return;

                    /*" -1367- ELSE */
                }
                else
                {


                    /*" -1368- DISPLAY 'R1215 - ERRO NO SELECT DA CLIENTES      ' */
                    _.Display($"R1215 - ERRO NO SELECT DA CLIENTES      ");

                    /*" -1369- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1371- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1374- MOVE '1217' TO WNR-EXEC-SQL. */
            _.Move("1217", WABEND.WNR_EXEC_SQL);

            /*" -1376- INITIALIZE DCLENDERECOS. */
            _.Initialize(
                ENDERECO.DCLENDERECOS
            );

            /*" -1388- PERFORM R1215_00_SELECT_BILHETE_DB_SELECT_3 */

            R1215_00_SELECT_BILHETE_DB_SELECT_3();

            /*" -1391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1393- GO TO R1215-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1215_99_SAIDA*/ //GOTO
                    return;

                    /*" -1394- ELSE */
                }
                else
                {


                    /*" -1395- DISPLAY 'R1210 - ERRO NO SELECT DA ENDERECO      ' */
                    _.Display($"R1210 - ERRO NO SELECT DA ENDERECO      ");

                    /*" -1396- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1398- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1398- MOVE 'NAO' TO WTEM-PROPOVA. */
            _.Move("NAO", AREA_DE_WORK.WTEM_PROPOVA);

        }

        [StopWatch]
        /*" R1215-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R1215_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1338- EXEC SQL SELECT NUM_APOLICE, 0, NUM_BILHETE, 0, COD_CLIENTE, DATA_QUITACAO, OCORR_ENDERECO, NUM_MATRICULA, AGE_COBRANCA INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-NUM-ITEM, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-DATA-INIVIGENCIA, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-AGE-COBRANCA FROM SEGUROS.BILHETE WHERE NUM_APOLICE = :V0MSIN-NUM-APOL END-EXEC. */

            var r1215_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                V0MSIN_NUM_APOL = V0MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r1215_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(executed_1.SEGURVGA_NUM_MATRICULA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);
                _.Move(executed_1.SEGURVGA_AGE_COBRANCA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA);
            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-SEGURVGA-DB-SELECT-3 */
        public void R1210_00_SELECT_SEGURVGA_DB_SELECT_3()
        {
            /*" -1267- EXEC SQL SELECT BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE AND OCORR_ENDERECO = :SEGURVGA-OCORR-ENDERECO END-EXEC. */

            var r1210_00_SELECT_SEGURVGA_DB_SELECT_3_Query1 = new R1210_00_SELECT_SEGURVGA_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_ENDERECO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1210_00_SELECT_SEGURVGA_DB_SELECT_3_Query1.Execute(r1210_00_SELECT_SEGURVGA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R1215-00-SELECT-BILHETE-DB-SELECT-2 */
        public void R1215_00_SELECT_BILHETE_DB_SELECT_2()
        {
            /*" -1361- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

            var r1215_00_SELECT_BILHETE_DB_SELECT_2_Query1 = new R1215_00_SELECT_BILHETE_DB_SELECT_2_Query1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1215_00_SELECT_BILHETE_DB_SELECT_2_Query1.Execute(r1215_00_SELECT_BILHETE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1215_99_SAIDA*/

        [StopWatch]
        /*" R1215-00-SELECT-BILHETE-DB-SELECT-3 */
        public void R1215_00_SELECT_BILHETE_DB_SELECT_3()
        {
            /*" -1388- EXEC SQL SELECT BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE AND OCORR_ENDERECO = :SEGURVGA-OCORR-ENDERECO END-EXEC. */

            var r1215_00_SELECT_BILHETE_DB_SELECT_3_Query1 = new R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_ENDERECO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1.Execute(r1215_00_SELECT_BILHETE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-SEGURVGA-DB-SELECT-4 */
        public void R1210_00_SELECT_SEGURVGA_DB_SELECT_4()
        {
            /*" -1293- EXEC SQL SELECT NUM_MATRI_VENDEDOR, COD_PRODUTO, AGE_COBRANCA INTO :PROPOVA-NUM-MATRI-VENDEDOR, :PROPOVA-COD-PRODUTO, :PROPOVA-AGE-COBRANCA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO END-EXEC. */

            var r1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1 = new R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1.Execute(r1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
            }


        }

        [StopWatch]
        /*" R1220-00-SELECT-ENDOSSOS-SECTION */
        private void R1220_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1411- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", WABEND.WNR_EXEC_SQL);

            /*" -1419- PERFORM R1220_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1220_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1422- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1423- DISPLAY 'R1220 - ERRO NO SELECT DA ENDOSSOS          ' */
                _.Display($"R1220 - ERRO NO SELECT DA ENDOSSOS          ");

                /*" -1424- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                /*" -1424- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1220-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1220_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1419- EXEC SQL SELECT COD_PRODUTO , DATA_TERVIGENCIA INTO :ENDOSSOS-COD-PRODUTO , :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-ARQV-AUDTSINI-SECTION */
        private void R1400_00_GRAVA_ARQV_AUDTSINI_SECTION()
        {
            /*" -1437- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1439- INITIALIZE WREG-AUDTSINI. */
            _.Initialize(
                WREG_AUDTSINI
            );

            /*" -1440- MOVE V0MSIN-FONTE TO REG-FONTE */
            _.Move(V0MSIN_FONTE, WREG_AUDTSINI.REG_FONTE);

            /*" -1441- PERFORM R1410-00-SELECT-FONTES */

            R1410_00_SELECT_FONTES_SECTION();

            /*" -1443- MOVE FONTES-NOME-FONTE TO REG-NOME-FONTE. */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, WREG_AUDTSINI.REG_NOME_FONTE);

            /*" -1444- IF WTEM-PROPOVA EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PROPOVA == "SIM")
            {

                /*" -1445- MOVE PROPOVA-AGE-COBRANCA TO WHOST-AGE-COBRANCA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, WHOST_AGE_COBRANCA);

                /*" -1447- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO REG-NRMATRVEN */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, WREG_AUDTSINI.REG_NRMATRVEN);

                /*" -1448- ELSE */
            }
            else
            {


                /*" -1449- MOVE SEGURVGA-AGE-COBRANCA TO WHOST-AGE-COBRANCA */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA, WHOST_AGE_COBRANCA);

                /*" -1451- MOVE SEGURVGA-NUM-MATRICULA TO REG-NRMATRVEN */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA, WREG_AUDTSINI.REG_NRMATRVEN);

                /*" -1453- END-IF. */
            }


            /*" -1454- MOVE WHOST-AGE-COBRANCA TO REG-CD-AGENCIA. */
            _.Move(WHOST_AGE_COBRANCA, WREG_AUDTSINI.REG_CD_AGENCIA);

            /*" -1455- PERFORM R1420-00-SELECT-AGENCCEF */

            R1420_00_SELECT_AGENCCEF_SECTION();

            /*" -1456- MOVE AGENCCEF-NOME-AGENCIA TO REG-NOME-AGENCIA. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA, WREG_AUDTSINI.REG_NOME_AGENCIA);

            /*" -1457- MOVE AGENCCEF-COD-ESCNEG TO REG-CD-ESCNEG. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, WREG_AUDTSINI.REG_CD_ESCNEG);

            /*" -1459- MOVE ESCRINEG-REGIAO-ESCNEG TO REG-NOME-ESCNEG. */
            _.Move(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG, WREG_AUDTSINI.REG_NOME_ESCNEG);

            /*" -1462- MOVE SEGURVGA-NUM-CERTIFICADO TO REG-NRCERTIF. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, WREG_AUDTSINI.REG_NRCERTIF);

            /*" -1463- MOVE SD-NUM-SINI TO REG-NUM-SINI */
            _.Move(REG_ARQSORT.SD_NUM_SINI, WREG_AUDTSINI.REG_NUM_SINI);

            /*" -1464- MOVE V0MSIN-NUM-APOL TO REG-NUM-APOL. */
            _.Move(V0MSIN_NUM_APOL, WREG_AUDTSINI.REG_NUM_APOL);

            /*" -1465- MOVE V0MSIN-DATCMD TO REG-DATCMD */
            _.Move(V0MSIN_DATCMD, WREG_AUDTSINI.REG_DATCMD);

            /*" -1466- MOVE V0MSIN-DATORR TO REG-DATORR */
            _.Move(V0MSIN_DATORR, WREG_AUDTSINI.REG_DATORR);

            /*" -1467- MOVE V0MSIN-DATTEC TO REG-DATTEC */
            _.Move(V0MSIN_DATTEC, WREG_AUDTSINI.REG_DATTEC);

            /*" -1468- MOVE SD-DTMOVTO TO REG-DTMOVTO */
            _.Move(REG_ARQSORT.SD_DTMOVTO, WREG_AUDTSINI.REG_DTMOVTO);

            /*" -1470- MOVE V0MSIN-CODCAU TO REG-CODCAU */
            _.Move(V0MSIN_CODCAU, WREG_AUDTSINI.REG_CODCAU);

            /*" -1471- PERFORM R1430-00-SELECT-SINISCAU */

            R1430_00_SELECT_SINISCAU_SECTION();

            /*" -1473- MOVE SINISCAU-DESCR-CAUSA TO REG-NOME-CAUSA */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, WREG_AUDTSINI.REG_NOME_CAUSA);

            /*" -1475- MOVE SEGURVGA-DATA-INIVIGENCIA TO REG-DTINIVIG */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, WREG_AUDTSINI.REG_DTINIVIG);

            /*" -1477- MOVE ENDOSSOS-DATA-TERVIGENCIA TO REG-DTTERVIG */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WREG_AUDTSINI.REG_DTTERVIG);

            /*" -1479- MOVE V0HSIN-VAL-OPERACAO TO REG-VAL-AVISADO. */
            _.Move(V0HSIN_VAL_OPERACAO, WREG_AUDTSINI.REG_VAL_AVISADO);

            /*" -1481- MOVE V0HSIN-VAL-JURO TO REG-VAL-JURO. */
            _.Move(V0HSIN_VAL_JURO, WREG_AUDTSINI.REG_VAL_JURO);

            /*" -1483- MOVE SD-VAL-OPER TO REG-VAL-PAGO. */
            _.Move(REG_ARQSORT.SD_VAL_OPER, WREG_AUDTSINI.REG_VAL_PAGO);

            /*" -1484- MOVE SD-NOMFAV TO REG-NOME-BENEF */
            _.Move(REG_ARQSORT.SD_NOMFAV, WREG_AUDTSINI.REG_NOME_BENEF);

            /*" -1486- MOVE ZEROS TO REG-CPF-BENEF */
            _.Move(0, WREG_AUDTSINI.REG_CPF_BENEF);

            /*" -1488- MOVE CLIENTES-NOME-RAZAO TO REG-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WREG_AUDTSINI.REG_NOME_RAZAO);

            /*" -1490- MOVE CLIENTES-CGCCPF TO REG-CPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WREG_AUDTSINI.REG_CPF);

            /*" -1492- MOVE ENDERECO-BAIRRO TO REG-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, WREG_AUDTSINI.REG_BAIRRO);

            /*" -1494- MOVE ENDERECO-CIDADE TO REG-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, WREG_AUDTSINI.REG_CIDADE);

            /*" -1496- MOVE ENDERECO-SIGLA-UF TO REG-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, WREG_AUDTSINI.REG_UF);

            /*" -1499- MOVE ENDERECO-CEP TO REG-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, WREG_AUDTSINI.REG_CEP);

            /*" -1500- IF WTEM-PROPOVA EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PROPOVA == "SIM")
            {

                /*" -1503- MOVE PROPOVA-COD-PRODUTO TO REG-PRODUTO WHOST-COD-PRODUTO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WREG_AUDTSINI.REG_PRODUTO, WHOST_COD_PRODUTO);

                /*" -1504- ELSE */
            }
            else
            {


                /*" -1507- MOVE ENDOSSOS-COD-PRODUTO TO REG-PRODUTO WHOST-COD-PRODUTO */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, WREG_AUDTSINI.REG_PRODUTO, WHOST_COD_PRODUTO);

                /*" -1509- END-IF. */
            }


            /*" -1511- PERFORM R1440-00-SELECT-PRODUVG */

            R1440_00_SELECT_PRODUVG_SECTION();

            /*" -1514- MOVE PRODUVG-NOME-PRODUTO TO REG-NOME-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, WREG_AUDTSINI.REG_NOME_PRODUTO);

            /*" -1516- PERFORM R1450-00-SELECT-SINISACO */

            R1450_00_SELECT_SINISACO_SECTION();

            /*" -1519- MOVE CODIGOPE-COD-OPERACAO TO REG-COD-OPER-F. */
            _.Move(CODIGOPE.DCLCODIGO_OPERACAO.CODIGOPE_COD_OPERACAO, WREG_AUDTSINI.REG_COD_OPER_F);

            /*" -1522- MOVE CODIGOPE-DESCR-OPERACAO TO REG-DESCR-OPER-F. */
            _.Move(CODIGOPE.DCLCODIGO_OPERACAO.CODIGOPE_DESCR_OPERACAO, WREG_AUDTSINI.REG_DESCR_OPER_F);

            /*" -1524- MOVE V0HSIN-CODUSU-PRE TO REG-CODUSU-PRE. */
            _.Move(V0HSIN_CODUSU_PRE, WREG_AUDTSINI.REG_CODUSU_PRE);

            /*" -1527- MOVE V0HSIN-CODUSU-LIB TO REG-CODUSU-LIB. */
            _.Move(V0HSIN_CODUSU_LIB, WREG_AUDTSINI.REG_CODUSU_LIB);

            /*" -1528- IF SD-SIT-CONT EQUAL '1' */

            if (REG_ARQSORT.SD_SIT_CONT == "1")
            {

                /*" -1529- MOVE 'CHEQUE' TO REG-OPCAO-PAG */
                _.Move("CHEQUE", WREG_AUDTSINI.REG_OPCAO_PAG);

                /*" -1533- MOVE ZEROS TO REG-COD-AGENCIA REG-COD-OPERACAO REG-NUM-CONTA REG-DIG-CONTA */
                _.Move(0, WREG_AUDTSINI.REG_COD_AGENCIA, WREG_AUDTSINI.REG_COD_OPERACAO, WREG_AUDTSINI.REG_NUM_CONTA, WREG_AUDTSINI.REG_DIG_CONTA);

                /*" -1534- PERFORM R1500-00-SELECT-SISINCHE */

                R1500_00_SELECT_SISINCHE_SECTION();

                /*" -1536- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO REG-NUM-CHEQUE */
                _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, WREG_AUDTSINI.REG_NUM_CHEQUE);

                /*" -1537- ELSE */
            }
            else
            {


                /*" -1538- IF SD-SIT-CONT EQUAL '2' */

                if (REG_ARQSORT.SD_SIT_CONT == "2")
                {

                    /*" -1539- MOVE 'C/C' TO REG-OPCAO-PAG */
                    _.Move("C/C", WREG_AUDTSINI.REG_OPCAO_PAG);

                    /*" -1540- MOVE ZEROS TO REG-NUM-CHEQUE */
                    _.Move(0, WREG_AUDTSINI.REG_NUM_CHEQUE);

                    /*" -1541- PERFORM R1600-00-SELECT-MOVDEBCE */

                    R1600_00_SELECT_MOVDEBCE_SECTION();

                    /*" -1543- MOVE MOVDEBCE-COD-AGENCIA-DEB TO REG-COD-AGENCIA */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, WREG_AUDTSINI.REG_COD_AGENCIA);

                    /*" -1545- MOVE MOVDEBCE-OPER-CONTA-DEB TO REG-COD-OPERACAO */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, WREG_AUDTSINI.REG_COD_OPERACAO);

                    /*" -1547- MOVE MOVDEBCE-NUM-CONTA-DEB TO REG-NUM-CONTA */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, WREG_AUDTSINI.REG_NUM_CONTA);

                    /*" -1549- MOVE MOVDEBCE-NUM-CONTA-DEB TO REG-NUM-CONTA */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, WREG_AUDTSINI.REG_NUM_CONTA);

                    /*" -1551- MOVE MOVDEBCE-DIG-CONTA-DEB TO REG-DIG-CONTA */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, WREG_AUDTSINI.REG_DIG_CONTA);

                    /*" -1552- ELSE */
                }
                else
                {


                    /*" -1553- IF SD-SIT-CONT EQUAL '5' */

                    if (REG_ARQSORT.SD_SIT_CONT == "5")
                    {

                        /*" -1554- MOVE 'SIVAT ' TO REG-OPCAO-PAG */
                        _.Move("SIVAT ", WREG_AUDTSINI.REG_OPCAO_PAG);

                        /*" -1559- MOVE ZEROS TO REG-NUM-CHEQUE REG-COD-AGENCIA REG-COD-OPERACAO REG-NUM-CONTA REG-DIG-CONTA */
                        _.Move(0, WREG_AUDTSINI.REG_NUM_CHEQUE, WREG_AUDTSINI.REG_COD_AGENCIA, WREG_AUDTSINI.REG_COD_OPERACAO, WREG_AUDTSINI.REG_NUM_CONTA, WREG_AUDTSINI.REG_DIG_CONTA);

                        /*" -1560- ELSE */
                    }
                    else
                    {


                        /*" -1561- MOVE 'OUTROS' TO REG-OPCAO-PAG */
                        _.Move("OUTROS", WREG_AUDTSINI.REG_OPCAO_PAG);

                        /*" -1566- MOVE ZEROS TO REG-NUM-CHEQUE REG-COD-AGENCIA REG-COD-OPERACAO REG-NUM-CONTA REG-DIG-CONTA */
                        _.Move(0, WREG_AUDTSINI.REG_NUM_CHEQUE, WREG_AUDTSINI.REG_COD_AGENCIA, WREG_AUDTSINI.REG_COD_OPERACAO, WREG_AUDTSINI.REG_NUM_CONTA, WREG_AUDTSINI.REG_DIG_CONTA);

                        /*" -1567- END-IF */
                    }


                    /*" -1568- END-IF */
                }


                /*" -1570- END-IF. */
            }


            /*" -1571- WRITE REG-AUDTSINI FROM WREG-AUDTSINI */
            _.Move(WREG_AUDTSINI.GetMoveValues(), REG_AUDTSINI);

            AUDTSINI.Write(REG_AUDTSINI.GetMoveValues().ToString());

            /*" -1572- IF W-STATUS = ZEROS */

            if (AREA_DE_WORK.W_STATUS == 00)
            {

                /*" -1573- ADD 1 TO AC-G-AUDTSINI */
                AREA_DE_WORK.AC_G_AUDTSINI.Value = AREA_DE_WORK.AC_G_AUDTSINI + 1;

                /*" -1574- ELSE */
            }
            else
            {


                /*" -1575- DISPLAY 'R1400 - ERRO NO WRITE DO ARQ AUDTSINI' */
                _.Display($"R1400 - ERRO NO WRITE DO ARQ AUDTSINI");

                /*" -1576- DISPLAY 'STATUS   - ' W-STATUS */
                _.Display($"STATUS   - {AREA_DE_WORK.W_STATUS}");

                /*" -1577- DISPLAY 'SINISTRO - ' REG-NUM-SINI */
                _.Display($"SINISTRO - {WREG_AUDTSINI.REG_NUM_SINI}");

                /*" -1578- DISPLAY 'APOLICE  - ' REG-NUM-APOL */
                _.Display($"APOLICE  - {WREG_AUDTSINI.REG_NUM_APOL}");

                /*" -1578- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-FONTES-SECTION */
        private void R1410_00_SELECT_FONTES_SECTION()
        {
            /*" -1591- MOVE '1410' TO WNR-EXEC-SQL. */
            _.Move("1410", WABEND.WNR_EXEC_SQL);

            /*" -1596- PERFORM R1410_00_SELECT_FONTES_DB_SELECT_1 */

            R1410_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1600- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1601- MOVE SPACES TO FONTES-NOME-FONTE */
                    _.Move("", FONTES.DCLFONTES.FONTES_NOME_FONTE);

                    /*" -1602- ELSE */
                }
                else
                {


                    /*" -1603- DISPLAY 'R1410 - ERRO NO SELECT DA FONTES            ' */
                    _.Display($"R1410 - ERRO NO SELECT DA FONTES            ");

                    /*" -1604- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI ' ' V0MSIN-FONTE */

                    $"SINISTRO - {V0MSIN_NUM_SINI} {V0MSIN_FONTE}"
                    .Display();

                    /*" -1604- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1410-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1410_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1596- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :V0MSIN-FONTE END-EXEC. */

            var r1410_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R1410_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                V0MSIN_FONTE = V0MSIN_FONTE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r1410_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-SELECT-AGENCCEF-SECTION */
        private void R1420_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -1617- MOVE '1420' TO WNR-EXEC-SQL. */
            _.Move("1420", WABEND.WNR_EXEC_SQL);

            /*" -1628- PERFORM R1420_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R1420_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -1631- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1632- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1633- MOVE ZEROS TO AGENCCEF-COD-ESCNEG */
                    _.Move(0, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);

                    /*" -1635- MOVE SPACES TO ESCRINEG-REGIAO-ESCNEG AGENCCEF-NOME-AGENCIA */
                    _.Move("", ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);

                    /*" -1636- ELSE */
                }
                else
                {


                    /*" -1637- DISPLAY 'R1420 - ERRO NO SELECT DA AGENCCEF          ' */
                    _.Display($"R1420 - ERRO NO SELECT DA AGENCCEF          ");

                    /*" -1638- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI ' ' V0MSIN-FONTE */

                    $"SINISTRO - {V0MSIN_NUM_SINI} {V0MSIN_FONTE}"
                    .Display();

                    /*" -1638- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1420-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R1420_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -1628- EXEC SQL SELECT A.NOME_AGENCIA, A.COD_ESCNEG, B.REGIAO_ESCNEG INTO :AGENCCEF-NOME-AGENCIA, :AGENCCEF-COD-ESCNEG, :ESCRINEG-REGIAO-ESCNEG FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.ESCRITORIO_NEGOCIO B WHERE A.COD_AGENCIA = :WHOST-AGE-COBRANCA AND B.COD_ESCNEG = A.COD_ESCNEG END-EXEC. */

            var r1420_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R1420_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                WHOST_AGE_COBRANCA = WHOST_AGE_COBRANCA.ToString(),
            };

            var executed_1 = R1420_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r1420_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_NOME_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
                _.Move(executed_1.ESCRINEG_REGIAO_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1430-00-SELECT-SINISCAU-SECTION */
        private void R1430_00_SELECT_SINISCAU_SECTION()
        {
            /*" -1651- MOVE '1430' TO WNR-EXEC-SQL. */
            _.Move("1430", WABEND.WNR_EXEC_SQL);

            /*" -1657- PERFORM R1430_00_SELECT_SINISCAU_DB_SELECT_1 */

            R1430_00_SELECT_SINISCAU_DB_SELECT_1();

            /*" -1660- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1661- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1662- MOVE SPACES TO SINISCAU-DESCR-CAUSA */
                    _.Move("", SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);

                    /*" -1663- ELSE */
                }
                else
                {


                    /*" -1664- DISPLAY 'R1430 - ERRO NO SELECT DA SINISCAU          ' */
                    _.Display($"R1430 - ERRO NO SELECT DA SINISCAU          ");

                    /*" -1665- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI ' ' V0MSIN-CODCAU */

                    $"SINISTRO - {V0MSIN_NUM_SINI} {V0MSIN_CODCAU}"
                    .Display();

                    /*" -1665- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1430-00-SELECT-SINISCAU-DB-SELECT-1 */
        public void R1430_00_SELECT_SINISCAU_DB_SELECT_1()
        {
            /*" -1657- EXEC SQL SELECT DESCR_CAUSA INTO :SINISCAU-DESCR-CAUSA FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :V0MSIN-RAMO AND COD_CAUSA = :V0MSIN-CODCAU END-EXEC. */

            var r1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1 = new R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1()
            {
                V0MSIN_CODCAU = V0MSIN_CODCAU.ToString(),
                V0MSIN_RAMO = V0MSIN_RAMO.ToString(),
            };

            var executed_1 = R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1.Execute(r1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1430_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-SELECT-PRODUVG-SECTION */
        private void R1440_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1678- MOVE '1440' TO WNR-EXEC-SQL. */
            _.Move("1440", WABEND.WNR_EXEC_SQL);

            /*" -1684- PERFORM R1440_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1440_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1687- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1688- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1693- PERFORM R1440_00_SELECT_PRODUVG_DB_SELECT_2 */

                    R1440_00_SELECT_PRODUVG_DB_SELECT_2();

                    /*" -1695- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1696- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1697- MOVE SPACES TO PRODUVG-NOME-PRODUTO */
                            _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);

                            /*" -1698- ELSE */
                        }
                        else
                        {


                            /*" -1699- DISPLAY 'R1440 - ERRO NO SELECT DA PRODUTO 1 ' */
                            _.Display($"R1440 - ERRO NO SELECT DA PRODUTO 1 ");

                            /*" -1700- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                            _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                            /*" -1701- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1702- END-IF */
                        }


                        /*" -1704- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1705- ELSE */
                    }

                }
                else
                {


                    /*" -1706- DISPLAY 'R1440 - ERRO NO SELECT DA PRODUTO           ' */
                    _.Display($"R1440 - ERRO NO SELECT DA PRODUTO           ");

                    /*" -1707- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1707- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1440-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1440_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1684- EXEC SQL SELECT NOME_PRODUTO INTO :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-SELECT-PRODUVG-DB-SELECT-2 */
        public void R1440_00_SELECT_PRODUVG_DB_SELECT_2()
        {
            /*" -1693- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :WHOST-COD-PRODUTO END-EXEC */

            var r1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1 = new R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1()
            {
                WHOST_COD_PRODUTO = WHOST_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1.Execute(r1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }

        [StopWatch]
        /*" R1450-00-SELECT-SINISACO-SECTION */
        private void R1450_00_SELECT_SINISACO_SECTION()
        {
            /*" -1720- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", WABEND.WNR_EXEC_SQL);

            /*" -1741- PERFORM R1450_00_SELECT_SINISACO_DB_DECLARE_1 */

            R1450_00_SELECT_SINISACO_DB_DECLARE_1();

            /*" -1743- PERFORM R1450_00_SELECT_SINISACO_DB_OPEN_1 */

            R1450_00_SELECT_SINISACO_DB_OPEN_1();

            /*" -1746- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1747- DISPLAY 'R1450 - ERRO NO OPEN C_SINISACO            ' */
                _.Display($"R1450 - ERRO NO OPEN C_SINISACO            ");

                /*" -1748- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                /*" -1750- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1753- MOVE '1451' TO WNR-EXEC-SQL. */
            _.Move("1451", WABEND.WNR_EXEC_SQL);

            /*" -1756- PERFORM R1450_00_SELECT_SINISACO_DB_FETCH_1 */

            R1450_00_SELECT_SINISACO_DB_FETCH_1();

            /*" -1759- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1760- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1761- MOVE ZEROS TO CODIGOPE-COD-OPERACAO */
                    _.Move(0, CODIGOPE.DCLCODIGO_OPERACAO.CODIGOPE_COD_OPERACAO);

                    /*" -1762- MOVE SPACES TO CODIGOPE-DESCR-OPERACAO */
                    _.Move("", CODIGOPE.DCLCODIGO_OPERACAO.CODIGOPE_DESCR_OPERACAO);

                    /*" -1763- ELSE */
                }
                else
                {


                    /*" -1764- DISPLAY 'R1451 - ERRO NO FETCH C_SINISACO            ' */
                    _.Display($"R1451 - ERRO NO FETCH C_SINISACO            ");

                    /*" -1765- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1767- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1767- PERFORM R1450_00_SELECT_SINISACO_DB_CLOSE_1 */

            R1450_00_SELECT_SINISACO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R1450-00-SELECT-SINISACO-DB-OPEN-1 */
        public void R1450_00_SELECT_SINISACO_DB_OPEN_1()
        {
            /*" -1743- EXEC SQL OPEN C_SINISACO END-EXEC. */

            C_SINISACO.Open();

        }

        [StopWatch]
        /*" R1450-00-SELECT-SINISACO-DB-FETCH-1 */
        public void R1450_00_SELECT_SINISACO_DB_FETCH_1()
        {
            /*" -1756- EXEC SQL FETCH C_SINISACO INTO :CODIGOPE-COD-OPERACAO, :CODIGOPE-DESCR-OPERACAO END-EXEC. */

            if (C_SINISACO.Fetch())
            {
                _.Move(C_SINISACO.CODIGOPE_COD_OPERACAO, CODIGOPE.DCLCODIGO_OPERACAO.CODIGOPE_COD_OPERACAO);
                _.Move(C_SINISACO.CODIGOPE_DESCR_OPERACAO, CODIGOPE.DCLCODIGO_OPERACAO.CODIGOPE_DESCR_OPERACAO);
            }

        }

        [StopWatch]
        /*" R1450-00-SELECT-SINISACO-DB-CLOSE-1 */
        public void R1450_00_SELECT_SINISACO_DB_CLOSE_1()
        {
            /*" -1767- EXEC SQL CLOSE C_SINISACO END-EXEC. */

            C_SINISACO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-SISINCHE-SECTION */
        private void R1500_00_SELECT_SISINCHE_SECTION()
        {
            /*" -1780- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1783- MOVE SD-NUM-SINI TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(REG_ARQSORT.SD_NUM_SINI, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -1786- MOVE SD-COD-OPER TO SINISHIS-COD-OPERACAO */
            _.Move(REG_ARQSORT.SD_COD_OPER, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1789- MOVE SD-OCORHIST TO SINISHIS-OCORR-HISTORICO */
            _.Move(REG_ARQSORT.SD_OCORHIST, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -1796- PERFORM R1500_00_SELECT_SISINCHE_DB_SELECT_1 */

            R1500_00_SELECT_SISINCHE_DB_SELECT_1();

            /*" -1799- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1800- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1801- MOVE ZEROS TO SISINCHE-NUM-CHEQUE-INTERNO */
                    _.Move(0, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);

                    /*" -1802- ELSE */
                }
                else
                {


                    /*" -1803- DISPLAY 'R1500 - ERRO NO SELECT DA SISINCHE  ' */
                    _.Display($"R1500 - ERRO NO SELECT DA SISINCHE  ");

                    /*" -1804- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1804- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-SISINCHE-DB-SELECT-1 */
        public void R1500_00_SELECT_SISINCHE_DB_SELECT_1()
        {
            /*" -1796- EXEC SQL SELECT NUM_CHEQUE_INTERNO INTO :SISINCHE-NUM-CHEQUE-INTERNO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO END-EXEC. */

            var r1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1 = new R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-MOVDEBCE-SECTION */
        private void R1600_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -1817- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1820- MOVE SD-NUM-SINI TO MOVDEBCE-NUM-APOLICE */
            _.Move(REG_ARQSORT.SD_NUM_SINI, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1823- MOVE SD-COD-OPER TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(REG_ARQSORT.SD_COD_OPER, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -1826- MOVE SD-OCORHIST TO MOVDEBCE-NUM-PARCELA */
            _.Move(REG_ARQSORT.SD_OCORHIST, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -1842- PERFORM R1600_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R1600_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -1845- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1846- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1847- PERFORM R1500-00-SELECT-SISINCHE */

                    R1500_00_SELECT_SISINCHE_SECTION();

                    /*" -1848- IF SISINCHE-NUM-CHEQUE-INTERNO GREATER 0 */

                    if (SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO > 0)
                    {

                        /*" -1849- PERFORM R1700-00-SELECT-MOVDEBCE */

                        R1700_00_SELECT_MOVDEBCE_SECTION();

                        /*" -1850- ELSE */
                    }
                    else
                    {


                        /*" -1855- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB */
                        _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                        /*" -1857- MOVE 55 TO MOVDEBCE-COD-RETORNO-CEF */
                        _.Move(55, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                        /*" -1858- END-IF */
                    }


                    /*" -1859- ELSE */
                }
                else
                {


                    /*" -1860- DISPLAY 'R1600 - ERRO NO SELECT DA MOVDEBCE  ' */
                    _.Display($"R1600 - ERRO NO SELECT DA MOVDEBCE  ");

                    /*" -1861- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1863- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1864- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 55 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 55)
            {

                /*" -1865- MOVE SPACES TO REG-DES-RETORNO */
                _.Move("", WREG_AUDTSINI.REG_DES_RETORNO);

                /*" -1866- GO TO R1600-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;

                /*" -1868- END-IF. */
            }


            /*" -1869- IF VIND-COD-AGENCIA-DEB LESS +0 */

            if (VIND_COD_AGENCIA_DEB < +0)
            {

                /*" -1874- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -1876- MOVE 55 TO MOVDEBCE-COD-RETORNO-CEF */
                _.Move(55, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                /*" -1878- END-IF. */
            }


            /*" -1879- IF VIND-COD-RETORNO-CEF LESS +0 */

            if (VIND_COD_RETORNO_CEF < +0)
            {

                /*" -1880- MOVE SPACES TO REG-DES-RETORNO */
                _.Move("", WREG_AUDTSINI.REG_DES_RETORNO);

                /*" -1881- ELSE */
            }
            else
            {


                /*" -1882- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 02 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 02)
                {

                    /*" -1883- MOVE 'CONTA NAO CADASTRADA' TO REG-DES-RETORNO */
                    _.Move("CONTA NAO CADASTRADA", WREG_AUDTSINI.REG_DES_RETORNO);

                    /*" -1884- ELSE */
                }
                else
                {


                    /*" -1885- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 04 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 04)
                    {

                        /*" -1886- MOVE 'OUTRAS RESTRICOES   ' TO REG-DES-RETORNO */
                        _.Move("OUTRAS RESTRICOES   ", WREG_AUDTSINI.REG_DES_RETORNO);

                        /*" -1887- ELSE */
                    }
                    else
                    {


                        /*" -1888- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 10 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 10)
                        {

                            /*" -1889- MOVE 'AGENCIA ENCERRADA   ' TO REG-DES-RETORNO */
                            _.Move("AGENCIA ENCERRADA   ", WREG_AUDTSINI.REG_DES_RETORNO);

                            /*" -1890- ELSE */
                        }
                        else
                        {


                            /*" -1891- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 12 */

                            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 12)
                            {

                                /*" -1892- MOVE 'VALOR INVALIDO      ' TO REG-DES-RETORNO */
                                _.Move("VALOR INVALIDO      ", WREG_AUDTSINI.REG_DES_RETORNO);

                                /*" -1893- ELSE */
                            }
                            else
                            {


                                /*" -1894- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 14 */

                                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 14)
                                {

                                    /*" -1895- MOVE 'AGENCIA INVALIDA    ' TO REG-DES-RETORNO */
                                    _.Move("AGENCIA INVALIDA    ", WREG_AUDTSINI.REG_DES_RETORNO);

                                    /*" -1896- ELSE */
                                }
                                else
                                {


                                    /*" -1897- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 15 */

                                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 15)
                                    {

                                        /*" -1898- MOVE 'DV CONTA INVALIDO   ' TO REG-DES-RETORNO */
                                        _.Move("DV CONTA INVALIDO   ", WREG_AUDTSINI.REG_DES_RETORNO);

                                        /*" -1899- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1900- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 18 */

                                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 18)
                                        {

                                            /*" -1901- MOVE 'DATA INVALIDA       ' TO REG-DES-RETORNO */
                                            _.Move("DATA INVALIDA       ", WREG_AUDTSINI.REG_DES_RETORNO);

                                            /*" -1902- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1903- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 30 */

                                            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 30)
                                            {

                                                /*" -1904- MOVE 'SEM CONTRATO        ' TO REG-DES-RETORNO */
                                                _.Move("SEM CONTRATO        ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                /*" -1905- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1906- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 96 */

                                                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 96)
                                                {

                                                    /*" -1907- MOVE 'VALOR ZERADO        ' TO REG-DES-RETORNO */
                                                    _.Move("VALOR ZERADO        ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                    /*" -1908- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1909- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 97 OR 98 */

                                                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.In("97", "98"))
                                                    {

                                                        /*" -1910- MOVE 'CANCELADO           ' TO REG-DES-RETORNO */
                                                        _.Move("CANCELADO           ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                        /*" -1911- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1912- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 99 */

                                                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 99)
                                                        {

                                                            /*" -1913- MOVE 'ESTORNADO           ' TO REG-DES-RETORNO */
                                                            _.Move("ESTORNADO           ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                            /*" -1914- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1915- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 99 */

                                                            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 99)
                                                            {

                                                                /*" -1915- MOVE 'OUTROS              ' TO REG-DES-RETORNO. */
                                                                _.Move("OUTROS              ", WREG_AUDTSINI.REG_DES_RETORNO);
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R1600_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1842- EXEC SQL SELECT COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, COD_RETORNO_CEF INTO :MOVDEBCE-COD-AGENCIA-DEB:VIND-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB :VIND-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB :VIND-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB :VIND-DIG-CONTA-DEB, :MOVDEBCE-COD-RETORNO-CEF:VIND-COD-RETORNO-CEF FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1600_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R1600_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1600_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_COD_AGENCIA_DEB, VIND_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_OPER_CONTA_DEB, VIND_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NUM_CONTA_DEB, VIND_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_DIG_CONTA_DEB, VIND_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
                _.Move(executed_1.VIND_COD_RETORNO_CEF, VIND_COD_RETORNO_CEF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-MOVDEBCE-SECTION */
        private void R1700_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -1928- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1931- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1935- MOVE ZEROS TO MOVDEBCE-NUM-ENDOSSO MOVDEBCE-NUM-PARCELA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -1951- PERFORM R1700_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R1700_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -1954- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1955- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1960- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB */
                    _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                    /*" -1962- MOVE 55 TO MOVDEBCE-COD-RETORNO-CEF */
                    _.Move(55, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                    /*" -1963- ELSE */
                }
                else
                {


                    /*" -1964- DISPLAY 'R1600 - ERRO NO SELECT DA MOVDEBCE  ' */
                    _.Display($"R1600 - ERRO NO SELECT DA MOVDEBCE  ");

                    /*" -1965- DISPLAY 'SINISTRO - ' V0MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V0MSIN_NUM_SINI}");

                    /*" -1967- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1968- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 55 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 55)
            {

                /*" -1969- MOVE SPACES TO REG-DES-RETORNO */
                _.Move("", WREG_AUDTSINI.REG_DES_RETORNO);

                /*" -1970- GO TO R1700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;

                /*" -1972- END-IF. */
            }


            /*" -1973- IF VIND-COD-AGENCIA-DEB LESS +0 */

            if (VIND_COD_AGENCIA_DEB < +0)
            {

                /*" -1978- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -1980- MOVE 55 TO MOVDEBCE-COD-RETORNO-CEF */
                _.Move(55, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                /*" -1982- END-IF. */
            }


            /*" -1983- IF VIND-COD-RETORNO-CEF LESS +0 */

            if (VIND_COD_RETORNO_CEF < +0)
            {

                /*" -1985- MOVE 55 TO MOVDEBCE-COD-RETORNO-CEF */
                _.Move(55, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                /*" -1985- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R1700_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1951- EXEC SQL SELECT COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, COD_RETORNO_CEF INTO :MOVDEBCE-COD-AGENCIA-DEB:VIND-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB :VIND-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB :VIND-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB :VIND-DIG-CONTA-DEB, :MOVDEBCE-COD-RETORNO-CEF:VIND-COD-RETORNO-CEF FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_COD_AGENCIA_DEB, VIND_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_OPER_CONTA_DEB, VIND_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NUM_CONTA_DEB, VIND_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_DIG_CONTA_DEB, VIND_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
                _.Move(executed_1.VIND_COD_RETORNO_CEF, VIND_COD_RETORNO_CEF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-VERIFICA-MOTIVO-SECTION */
        private void R1800_00_VERIFICA_MOTIVO_SECTION()
        {
            /*" -1997- IF VIND-COD-RETORNO-CEF LESS +0 */

            if (VIND_COD_RETORNO_CEF < +0)
            {

                /*" -1998- MOVE SPACES TO REG-DES-RETORNO */
                _.Move("", WREG_AUDTSINI.REG_DES_RETORNO);

                /*" -1999- ELSE */
            }
            else
            {


                /*" -2000- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 00 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 00)
                {

                    /*" -2001- MOVE 'EFETUADO            ' TO REG-DES-RETORNO */
                    _.Move("EFETUADO            ", WREG_AUDTSINI.REG_DES_RETORNO);

                    /*" -2002- ELSE */
                }
                else
                {


                    /*" -2003- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 02 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 02)
                    {

                        /*" -2004- MOVE 'CONTA NAO CADASTRADA' TO REG-DES-RETORNO */
                        _.Move("CONTA NAO CADASTRADA", WREG_AUDTSINI.REG_DES_RETORNO);

                        /*" -2005- ELSE */
                    }
                    else
                    {


                        /*" -2006- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 04 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 04)
                        {

                            /*" -2007- MOVE 'OUTRAS RESTRICOES   ' TO REG-DES-RETORNO */
                            _.Move("OUTRAS RESTRICOES   ", WREG_AUDTSINI.REG_DES_RETORNO);

                            /*" -2008- ELSE */
                        }
                        else
                        {


                            /*" -2009- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 10 */

                            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 10)
                            {

                                /*" -2010- MOVE 'AGENCIA ENCERRADA   ' TO REG-DES-RETORNO */
                                _.Move("AGENCIA ENCERRADA   ", WREG_AUDTSINI.REG_DES_RETORNO);

                                /*" -2011- ELSE */
                            }
                            else
                            {


                                /*" -2012- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 12 */

                                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 12)
                                {

                                    /*" -2013- MOVE 'VALOR INVALIDO      ' TO REG-DES-RETORNO */
                                    _.Move("VALOR INVALIDO      ", WREG_AUDTSINI.REG_DES_RETORNO);

                                    /*" -2014- ELSE */
                                }
                                else
                                {


                                    /*" -2015- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 14 */

                                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 14)
                                    {

                                        /*" -2016- MOVE 'AGENCIA INVALIDA    ' TO REG-DES-RETORNO */
                                        _.Move("AGENCIA INVALIDA    ", WREG_AUDTSINI.REG_DES_RETORNO);

                                        /*" -2017- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2018- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 15 */

                                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 15)
                                        {

                                            /*" -2019- MOVE 'DV CONTA INVALIDO   ' TO REG-DES-RETORNO */
                                            _.Move("DV CONTA INVALIDO   ", WREG_AUDTSINI.REG_DES_RETORNO);

                                            /*" -2020- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2021- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 18 */

                                            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 18)
                                            {

                                                /*" -2022- MOVE 'DATA INVALIDA       ' TO REG-DES-RETORNO */
                                                _.Move("DATA INVALIDA       ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                /*" -2023- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2024- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 30 */

                                                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 30)
                                                {

                                                    /*" -2025- MOVE 'SEM CONTRATO        ' TO REG-DES-RETORNO */
                                                    _.Move("SEM CONTRATO        ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                    /*" -2026- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -2027- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 96 */

                                                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 96)
                                                    {

                                                        /*" -2028- MOVE 'VALOR ZERADO        ' TO REG-DES-RETORNO */
                                                        _.Move("VALOR ZERADO        ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                        /*" -2029- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -2030- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 97 OR 98 */

                                                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.In("97", "98"))
                                                        {

                                                            /*" -2031- MOVE 'CANCELADO           ' TO REG-DES-RETORNO */
                                                            _.Move("CANCELADO           ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                            /*" -2032- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2033- IF MOVDEBCE-COD-RETORNO-CEF EQUAL 99 */

                                                            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 99)
                                                            {

                                                                /*" -2034- MOVE 'ESTORNADO           ' TO REG-DES-RETORNO */
                                                                _.Move("ESTORNADO           ", WREG_AUDTSINI.REG_DES_RETORNO);

                                                                /*" -2035- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -2035- MOVE 'OUTROS              ' TO REG-DES-RETORNO. */
                                                                _.Move("OUTROS              ", WREG_AUDTSINI.REG_DES_RETORNO);
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2049- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -2050- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -2051- DISPLAY '* VA0955B - NAO FOI ENCONTRADO MOVIMENTO     *' . */
            _.Display($"* VA0955B - NAO FOI ENCONTRADO MOVIMENTO     *");

            /*" -2052- DISPLAY '*           NO MES/ANO DE REFERENCIA PARA    *' . */
            _.Display($"*           NO MES/ANO DE REFERENCIA PARA    *");

            /*" -2053- DISPLAY '*           EXECUTAR O PROGRAMA DA AUDITORIA *' . */
            _.Display($"*           EXECUTAR O PROGRAMA DA AUDITORIA *");

            /*" -2054- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -2055- DISPLAY '*       TERMINO ==> A N O R M A L <==        *' . */
            _.Display($"*       TERMINO ==> A N O R M A L <==        *");

            /*" -2056- DISPLAY '*                                            *' . */
            _.Display($"*                                            *");

            /*" -2056- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2070- CLOSE AUDTSINI. */
            AUDTSINI.Close();

            /*" -2072- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2074- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2074- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2078- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2078- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}