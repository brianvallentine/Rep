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
using Sias.Sinistro.DB2.SI0806B;

namespace Code
{
    public class SI0806B
    {
        public bool IsCall { get; set; }

        public SI0806B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *PROGRAMA ALTERADO PARA GERAR RECIBO DE UMA DETERMINADA DATA. /*      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    SINISTRO                          //      */
        /*"      * PROGRAMA             :    SI0806B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RECIBO DE SINISTRO -   //      */
        /*"      *                           NOSSA LIDERANCA - 2 VIA           //      */
        /*"      * ANALISTA/PROGRAMADOR :    PROCAS/ENRICO                     //      */
        /*"      * DATA                 :    JUNHO / 91                        //      */
        /*"      *                           MARCO/92   -   FREDERICO          //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *  ALTERACAO LIGIA 16/02/95 : INCLUSAO DE TEXTO ESPECIAL PARA    *      */
        /*"      *                             PAGAMENTO PARCIAL DO RAMO 48       *      */
        /*"      *                             (CREDITO INTERNO)                  *      */
        /*"      *  ALTERACAO HEIDER17/05/95 : IMPRESSAO DOS CAMPOS 'VALOR TOTAL  *      */
        /*"      *  OBS: COPIADO DO SI0059B    DIVIDA' E 'PARTICIPACAO DA CEF'    *      */
        /*"      *                             A PARTIR DA OPERACAO 2 (V0HISTSINI)*      */
        /*"      *                             PARA RAMO 48 (CREDITO INTERNO).    *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0806M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0806M1
        {
            get
            {
                _.Move(REG_SI0806M1, _SI0806M1); VarBasis.RedefinePassValue(REG_SI0806M1, _SI0806M1, REG_SI0806M1); return _SI0806M1;
            }
        }
        /*"01  REG-SI0806M1.*/
        public SI0806B_REG_SI0806M1 REG_SI0806M1 { get; set; } = new SI0806B_REG_SI0806M1();
        public class SI0806B_REG_SI0806M1 : VarBasis
        {
            /*"    05          SALTO              PIC  X(001).*/
            public StringBasis SALTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05          LINHA              PIC  X(130).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "130", "X(130)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77         V1RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V1RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RELA-DATA-REFERE  PIC  X(010).*/
        public StringBasis V1RELA_DATA_REFERE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1RELA-SITUACAO     PIC  X(001).*/
        public StringBasis V1RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EMPRESA-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           GEUNIMO-VLCRUZAD       PIC S9(006)V9(9)  COMP-3.*/
        public DoubleBasis GEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77           GEUNIMO-SIGLUNIM       PIC  X(006).*/
        public StringBasis GEUNIMO_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77           MEST-NUM-APOL          PIC S9(013)       COMP-3.*/
        public IntBasis MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           MEST-NRENDOS           PIC S9(009)       COMP.*/
        public IntBasis MEST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           MEST-SINLID            PIC  X(015).*/
        public StringBasis MEST_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77           MEST-NRCERTIF          PIC S9(015)       COMP-3.*/
        public IntBasis MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77           MEST-DIGCERT           PIC  X(001).*/
        public StringBasis MEST_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           MEST-IDTPSEGU          PIC  X(001).*/
        public StringBasis MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           MEST-DATORR            PIC  X(010).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           MEST-CODSUBES          PIC S9(004)       COMP.*/
        public IntBasis MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-CODCAU            PIC S9(004)       COMP.*/
        public IntBasis MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-MOEDA-SINI        PIC S9(004)       COMP.*/
        public IntBasis MEST_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-RAMO              PIC S9(004)       COMP.*/
        public IntBasis MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           MEST-DATCMD            PIC  X(010).*/
        public StringBasis MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           THIST-APOL-SINI        PIC S9(013)       COMP-3.*/
        public IntBasis THIST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           THIST-OPERACAO         PIC S9(004)       COMP.*/
        public IntBasis THIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-DTMOVTO          PIC  X(010).*/
        public StringBasis THIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           THIST-VALPRI           PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-VALPRI-CEF       PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI_CEF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-VALPRI-TOT       PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-VALPRI1          PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-VALPRI2          PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_VALPRI2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-CRRMON           PIC S9(013)V99    COMP-3.*/
        public DoubleBasis THIST_CRRMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           THIST-TIPFAV           PIC  X(001).*/
        public StringBasis THIST_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           THIST-LIMCRR           PIC  X(010).*/
        public StringBasis THIST_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           THIST-NOMFAV           PIC  X(040).*/
        public StringBasis THIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           THIST-SITUACAO         PIC  X(001).*/
        public StringBasis THIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           THIST-FONPAG           PIC S9(004)       COMP.*/
        public IntBasis THIST_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           THIST-CODPSVI          PIC S9(009)       COMP.*/
        public IntBasis THIST_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           FONPAG-IND             PIC S9(004)       COMP.*/
        public IntBasis FONPAG_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           CAUSA-DESCAU           PIC  X(040).*/
        public StringBasis CAUSA_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1FORN-PCISS           PIC S9(003)V99    COMP-3.*/
        public DoubleBasis V1FORN_PCISS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           RELSIN-DTMOVTO         PIC  X(010).*/
        public StringBasis RELSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELSIN-APOL-SINI       PIC S9(013)       COMP-3.*/
        public IntBasis RELSIN_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           RELSIN-OPERACAO        PIC S9(004)       COMP.*/
        public IntBasis RELSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           RELSIN-OCORHIST        PIC S9(004)       COMP.*/
        public IntBasis RELSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           RELSIN-FONTE           PIC S9(004)       COMP.*/
        public IntBasis RELSIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SIST-DTMOVABE          PIC  X(010).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTCURRENT         PIC  X(010).*/
        public StringBasis SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTRECIBO          PIC  X(010).*/
        public StringBasis SIST_DTRECIBO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           PARAM-RAMO-VGAPC       PIC S9(004)      COMP.*/
        public IntBasis PARAM_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           PARAM-RAMO-VG          PIC S9(004)      COMP.*/
        public IntBasis PARAM_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           PARAM-RAMO-AP          PIC S9(004)      COMP.*/
        public IntBasis PARAM_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           PARAM-RAMO-SAUDE       PIC S9(004)      COMP.*/
        public IntBasis PARAM_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           PARAM-RAMO-EDUCACAO    PIC S9(004)      COMP.*/
        public IntBasis PARAM_RAMO_EDUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1SEGVG-CLIENTE        PIC S9(009)       COMP.*/
        public IntBasis V1SEGVG_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1CLI-NOME-RAZAO       PIC  X(040).*/
        public StringBasis V1CLI_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           GERAMO-NOMERAMO        PIC  X(040).*/
        public StringBasis GERAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           GEFONTE-NOMEFTE        PIC  X(040).*/
        public StringBasis GEFONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           GEFONTE-CIDADE         PIC  X(020).*/
        public StringBasis GEFONTE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77           APOL-NOME              PIC  X(040).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           APOL-ORGAO             PIC S9(004)       COMP.*/
        public IntBasis APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           APDCORR-CODCORR        PIC S9(009)      COMP.*/
        public IntBasis APDCORR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           APDCORR-NUM-APOL       PIC S9(013)      COMP-3.*/
        public IntBasis APDCORR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           APDCORR-DTINIVIG       PIC  X(010).*/
        public StringBasis APDCORR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           APDCORR-DTTERVIG       PIC  X(010).*/
        public StringBasis APDCORR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           PRODUTOR-CODPDT        PIC S9(009)      COMP.*/
        public IntBasis PRODUTOR_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           PRODUTOR-NOMPDT        PIC  X(040).*/
        public StringBasis PRODUTOR_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           ENDOSSO-FONTE          PIC S9(004)      COMP.*/
        public IntBasis ENDOSSO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           VARIAV-IND             PIC S9(004)      COMP.*/
        public IntBasis VARIAV_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WCOD-FONTE             PIC S9(004)       COMP.*/
        public IntBasis WCOD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WMOEDA                 PIC S9(004) COMP VALUE ZEROS*/
        public IntBasis WMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WGEUNIMO-DTTERVIG      PIC X(010).*/
        public StringBasis WGEUNIMO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WGEUNIMO-DTINIVIG      PIC X(010).*/
        public StringBasis WGEUNIMO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              W.*/
        public SI0806B_W W { get; set; } = new SI0806B_W();
        public class SI0806B_W : VarBasis
        {
            /*"  03            LC00.*/
            public SI0806B_LC00 LC00 { get; set; } = new SI0806B_LC00();
            public class SI0806B_LC00 : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03            LC0A.*/
            }
            public SI0806B_LC0A LC0A { get; set; } = new SI0806B_LC0A();
            public class SI0806B_LC0A : VarBasis
            {
                /*"    05          FILLER              PIC  X(030) VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'RECIBO'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"RECIBO");
                /*"    05          FILLER              PIC  X(003) VALUE 'DE'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DE");
                /*"    05          FILLER              PIC  X(022) VALUE 'SINISTRO'*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"SINISTRO");
                /*"    05          FILLER              PIC  X(016) VALUE 'SINISTRO'*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SINISTRO");
                /*"  03            LC01.*/
            }
            public SI0806B_LC01 LC01 { get; set; } = new SI0806B_LC01();
            public class SI0806B_LC01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(064) VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"");
                /*"    05          LC01-SINISTRO       PIC  9(013).*/
                public IntBasis LC01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  03            LC0B.*/
            }
            public SI0806B_LC0B LC0B { get; set; } = new SI0806B_LC0B();
            public class SI0806B_LC0B : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'NOME'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"NOME");
                /*"    05          FILLER              PIC  X(056) VALUE 'SEGURADO'*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"SEGURADO");
                /*"    05          FILLER              PIC  X(016) VALUE 'FILIAL'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"FILIAL");
                /*"  03            LC02.*/
            }
            public SI0806B_LC02 LC02 { get; set; } = new SI0806B_LC02();
            public class SI0806B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC02-NOME           PIC  X(040) VALUE SPACES.*/
                public StringBasis LC02_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          LC02-NOMEFTE        PIC  X(017) VALUE SPACES.*/
                public StringBasis LC02_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"  03            LC0C.*/
            }
            public SI0806B_LC0C LC0C { get; set; } = new SI0806B_LC0C();
            public class SI0806B_LC0C : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC X(61) VALUE 'FAVORECIDO'*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "61", "X(61)"), @"FAVORECIDO");
                /*"    05          FILLER              PIC  X(016) VALUE 'RAMO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"RAMO");
                /*"  03            LC03.*/
            }
            public SI0806B_LC03 LC03 { get; set; } = new SI0806B_LC03();
            public class SI0806B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC03-NOMFAV         PIC  X(040) VALUE SPACES.*/
                public StringBasis LC03_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          LC03-NOMERAMO       PIC  X(017) VALUE SPACES.*/
                public StringBasis LC03_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"  03            LC0D.*/
            }
            public SI0806B_LC0D LC0D { get; set; } = new SI0806B_LC0D();
            public class SI0806B_LC0D : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(017) VALUE 'APOLICE'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"APOLICE");
                /*"    05          FILLER              PIC  X(007) VALUE 'ENDOSSO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"ENDOSSO");
                /*"    05          FILLER              PIC  X(008) VALUE '/FATURA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"/FATURA");
                /*"    05          FILLER              PIC  X(005) VALUE 'ITEM/'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"ITEM/");
                /*"    05          FILLER             PIC X(13) VALUE 'CERTIFICADO'*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CERTIFICADO");
                /*"    05          FILLER              PIC X(11) VALUE 'OCORRENCIA'*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"OCORRENCIA");
                /*"    05          FILLER              PIC X(06) VALUE 'VALOR'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR");
                /*"    05          FILLER              PIC X(10) VALUE 'EM  REAIS'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"EM  REAIS");
                /*"  03            LC04.*/
            }
            public SI0806B_LC04 LC04 { get; set; } = new SI0806B_LC04();
            public class SI0806B_LC04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC04-APOLICE        PIC  9(013).*/
                public IntBasis LC04_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC04-NRENDOS        PIC  9(006) BLANK WHEN ZERO.*/
                public IntBasis LC04_NRENDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC04-ITEM.*/
                public SI0806B_LC04_ITEM LC04_ITEM { get; set; } = new SI0806B_LC04_ITEM();
                public class SI0806B_LC04_ITEM : VarBasis
                {
                    /*"      07        LC04-NRCERTIF       PIC  9(015) BLANK WHEN ZERO.*/
                    public IntBasis LC04_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                }
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC04-DATA-OCORR.*/
                public SI0806B_LC04_DATA_OCORR LC04_DATA_OCORR { get; set; } = new SI0806B_LC04_DATA_OCORR();
                public class SI0806B_LC04_DATA_OCORR : VarBasis
                {
                    /*"      07        LC04-DD-OC          PIC  9(002).*/
                    public IntBasis LC04_DD_OC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04-MM-OC          PIC  9(002).*/
                    public IntBasis LC04_MM_OC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04-AA-OC          PIC  9(004).*/
                    public IntBasis LC04_AA_OC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC04-VALOR          PIC  ***.***.***.**9,99.*/
                public DoubleBasis LC04_VALOR { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.***.**9V99."), 2);
                /*"  03            LC04A.*/
            }
            public SI0806B_LC04A LC04A { get; set; } = new SI0806B_LC04A();
            public class SI0806B_LC04A : VarBasis
            {
                /*"    05          FILLER              PIC  X(008) VALUE 'CAUSA :'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CAUSA :");
                /*"    05          LC04A-CODCAU        PIC  9(004) VALUE ZEROS.*/
                public IntBasis LC04A_CODCAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' -'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" -");
                /*"    05          LC04A-CAUSA         PIC  X(040) VALUE SPACES.*/
                public StringBasis LC04A_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LC04A-LITER         PIC  X(013) VALUE SPACES.*/
                public StringBasis LC04A_LITER { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          LC04A-SINLID        PIC  X(015) VALUE SPACES.*/
                public StringBasis LC04A_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"  03            LC05.*/
            }
            public SI0806B_LC05 LC05 { get; set; } = new SI0806B_LC05();
            public class SI0806B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ' GERAIS A IMPORTANCIA SUPRACI-'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ");
                /*"  03            LC06.*/
            }
            public SI0806B_LC06 LC06 { get; set; } = new SI0806B_LC06();
            public class SI0806B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TADA COMO INDENIZACAO FINAL E TOTAL, POR TODOS OS               ' DANOS E PREJUIZOS QUE SE ORI-'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TADA COMO INDENIZACAO FINAL E TOTAL, POR TODOS OS               ");
                /*"  03            LC07.*/
            }
            public SI0806B_LC07 LC07 { get; set; } = new SI0806B_LC07();
            public class SI0806B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'GINARAM DA OCORRENCIA DESCRITA E REGULADA NO PROC               'ESSO DE SINISTRO EM REFERENCIA.'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"GINARAM DA OCORRENCIA DESCRITA E REGULADA NO PROC               ");
                /*"  03            LC09.*/
            }
            public SI0806B_LC09 LC09 { get; set; } = new SI0806B_LC09();
            public class SI0806B_LC09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               'COMPANHIA, PLENA, GERAL E  IR-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               ");
                /*"  03            LC10.*/
            }
            public SI0806B_LC10 LC10 { get; set; } = new SI0806B_LC10();
            public class SI0806B_LC10 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'REVOGAVEL QUITACAO DE PAGO (S) E SATISFEITO (S) D               'E TODOS OS PREJUIZOS SOFRIDOS,'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"REVOGAVEL QUITACAO DE PAGO (S) E SATISFEITO (S) D               ");
                /*"  03            LC11.*/
            }
            public SI0806B_LC11 LC11 { get; set; } = new SI0806B_LC11();
            public class SI0806B_LC11 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               'ONTRA O CAUSADOR E/OU  RESPON-'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               ");
                /*"  03            LC12.*/
            }
            public SI0806B_LC12 LC12 { get; set; } = new SI0806B_LC12();
            public class SI0806B_LC12 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'SAVEL PELO EVENTO, E DIREITOS SOBRE A PROPRIEDADE               ' DO (S) BEM (NS)  CARACTERIZA-'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"SAVEL PELO EVENTO, E DIREITOS SOBRE A PROPRIEDADE               ");
                /*"  03            LC13.*/
            }
            public SI0806B_LC13 LC13 { get; set; } = new SI0806B_LC13();
            public class SI0806B_LC13 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'DO (S) SENDO O MESMO UTILIZADO PELA COMPANHIA DA               'MANEIRA QUE LHE CONVIR SEM QUE'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"DO (S) SENDO O MESMO UTILIZADO PELA COMPANHIA DA               ");
                /*"  03            LC14.*/
            }
            public SI0806B_LC14 LC14 { get; set; } = new SI0806B_LC14();
            public class SI0806B_LC14 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'NOS ASSISTA DIREITO A RECLAMACOES.'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"NOS ASSISTA DIREITO A RECLAMACOES.");
                /*"  03            LC15.*/
            }
            public SI0806B_LC15 LC15 { get; set; } = new SI0806B_LC15();
            public class SI0806B_LC15 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3 (TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03            LC16.*/
            }
            public SI0806B_LC16 LC16 { get; set; } = new SI0806B_LC16();
            public class SI0806B_LC16 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TEOR PARA UM SO EFEITO.'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TEOR PARA UM SO EFEITO.");
                /*"  03            LC17.*/
            }
            public SI0806B_LC17 LC17 { get; set; } = new SI0806B_LC17();
            public class SI0806B_LC17 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ' GERAIS A IMPORTANCIA SUPRACI-'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ");
                /*"  03            LC18.*/
            }
            public SI0806B_LC18 LC18 { get; set; } = new SI0806B_LC18();
            public class SI0806B_LC18 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TADA COMO INDENIZACAO FINAL E TOTAL, POR TODOS OS               ' DANOS E PREJUIZOS QUE SE ORI-'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TADA COMO INDENIZACAO FINAL E TOTAL, POR TODOS OS               ");
                /*"  03            LC19.*/
            }
            public SI0806B_LC19 LC19 { get; set; } = new SI0806B_LC19();
            public class SI0806B_LC19 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'GINARAM DA OCORRENCIA DESCRITA E REGULADA NO PROC               'ESSO DE SINISTRO EM REFERENCIA.'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"GINARAM DA OCORRENCIA DESCRITA E REGULADA NO PROC               ");
                /*"  03            LC21.*/
            }
            public SI0806B_LC21 LC21 { get; set; } = new SI0806B_LC21();
            public class SI0806B_LC21 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               'COMPANHIA, PLENA, GERAL E  IR-'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               ");
                /*"  03            LC22.*/
            }
            public SI0806B_LC22 LC22 { get; set; } = new SI0806B_LC22();
            public class SI0806B_LC22 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'REVOGAVEL QUITACAO DE PAGO (S) E SATISFEITO (S) D               'E TODOS OS PREJUIZOS SOFRIDOS,'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"REVOGAVEL QUITACAO DE PAGO (S) E SATISFEITO (S) D               ");
                /*"  03            LC23.*/
            }
            public SI0806B_LC23 LC23 { get; set; } = new SI0806B_LC23();
            public class SI0806B_LC23 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               'ONTRA O CAUSADOR E/OU  RESPON-'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               ");
                /*"  03            LC24.*/
            }
            public SI0806B_LC24 LC24 { get; set; } = new SI0806B_LC24();
            public class SI0806B_LC24 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(072) VALUE               'SAVEL PELO EVENTO.'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"SAVEL PELO EVENTO.");
                /*"  03            LC25.*/
            }
            public SI0806B_LC25 LC25 { get; set; } = new SI0806B_LC25();
            public class SI0806B_LC25 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3 (TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03            LC26.*/
            }
            public SI0806B_LC26 LC26 { get; set; } = new SI0806B_LC26();
            public class SI0806B_LC26 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TEOR PARA UM SO EFEITO.'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TEOR PARA UM SO EFEITO.");
                /*"  03            LC27.*/
            }
            public SI0806B_LC27 LC27 { get; set; } = new SI0806B_LC27();
            public class SI0806B_LC27 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ' GERAIS A IMPORTANCIA SUPRACI-'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ");
                /*"  03            LC28.*/
            }
            public SI0806B_LC28 LC28 { get; set; } = new SI0806B_LC28();
            public class SI0806B_LC28 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TADA COMO INDENIZACAO PARCIAL, PELOS DANOS E PREJ               'UIZOS QUE SE ORIGINARAM DA  O-'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TADA COMO INDENIZACAO PARCIAL, PELOS DANOS E PREJ               ");
                /*"  03            LC29.*/
            }
            public SI0806B_LC29 LC29 { get; set; } = new SI0806B_LC29();
            public class SI0806B_LC29 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'CORRENCIA DESCRITA E REGULADA NO PROCESSO DE SINI               'STRO EM REFERENCIA.'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CORRENCIA DESCRITA E REGULADA NO PROCESSO DE SINI               ");
                /*"  03            LC31.*/
            }
            public SI0806B_LC31 LC31 { get; set; } = new SI0806B_LC31();
            public class SI0806B_LC31 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'A PARCELA FINAL DA INDENIZACAO SERA RECEBIDA QUAN               'DO DO TERMINO DA REGULACAO  DO'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"A PARCELA FINAL DA INDENIZACAO SERA RECEBIDA QUAN               ");
                /*"  03            LC32.*/
            }
            public SI0806B_LC32 LC32 { get; set; } = new SI0806B_LC32();
            public class SI0806B_LC32 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'EVENTO, CONFORME DOCUMENTOS QUE COMPOEM O REFERID               'O PROCESSO.'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"EVENTO, CONFORME DOCUMENTOS QUE COMPOEM O REFERID               ");
                /*"  03            LC33.*/
            }
            public SI0806B_LC33 LC33 { get; set; } = new SI0806B_LC33();
            public class SI0806B_LC33 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3(TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03            LC34.*/
            }
            public SI0806B_LC34 LC34 { get; set; } = new SI0806B_LC34();
            public class SI0806B_LC34 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TEOR PARA UM SO EFEITO.'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TEOR PARA UM SO EFEITO.");
                /*"  03            LC35.*/
            }
            public SI0806B_LC35 LC35 { get; set; } = new SI0806B_LC35();
            public class SI0806B_LC35 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ' GERAIS A IMPORTANCIA SUPRACI-'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ");
                /*"  03            LC36.*/
            }
            public SI0806B_LC36 LC36 { get; set; } = new SI0806B_LC36();
            public class SI0806B_LC36 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TADA COMO COMPLEMENTO DE INDENIZACAO POR PREJUIZO               'S CONSTATADOS E APURADOS  APOS'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TADA COMO COMPLEMENTO DE INDENIZACAO POR PREJUIZO               ");
                /*"  03            LC37.*/
            }
            public SI0806B_LC37 LC37 { get; set; } = new SI0806B_LC37();
            public class SI0806B_LC37 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'O TERMINO DA REGULACAO, CONFORME DOCUMENTOS ANEXO               'S AO PROCESSO EM REFERENCIA.'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"O TERMINO DA REGULACAO, CONFORME DOCUMENTOS ANEXO               ");
                /*"  03            LC39.*/
            }
            public SI0806B_LC39 LC39 { get; set; } = new SI0806B_LC39();
            public class SI0806B_LC39 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               'COMPANHIA, PLENA, GERAL E  IR-'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               ");
                /*"  03            LC40.*/
            }
            public SI0806B_LC40 LC40 { get; set; } = new SI0806B_LC40();
            public class SI0806B_LC40 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'REVOGAVEL QUITACAO DE PAGO (S) SATISFEITO (S) DE               'TODOS OS  PREJUIZOS  SOFRIDOS,'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"REVOGAVEL QUITACAO DE PAGO (S) SATISFEITO (S) DE               ");
                /*"  03            LC41.*/
            }
            public SI0806B_LC41 LC41 { get; set; } = new SI0806B_LC41();
            public class SI0806B_LC41 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               'ONTRA O CAUSADOR E/OU RESPON-'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               ");
                /*"  03            LC42.*/
            }
            public SI0806B_LC42 LC42 { get; set; } = new SI0806B_LC42();
            public class SI0806B_LC42 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'SAVEL PELO EVENTO SUPRACITADO.'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"SAVEL PELO EVENTO SUPRACITADO.");
                /*"  03            LC43.*/
            }
            public SI0806B_LC43 LC43 { get; set; } = new SI0806B_LC43();
            public class SI0806B_LC43 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3 (TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03            LC44.*/
            }
            public SI0806B_LC44 LC44 { get; set; } = new SI0806B_LC44();
            public class SI0806B_LC44 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TEOR PARA UM SO FIM E EFEITO.'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TEOR PARA UM SO FIM E EFEITO.");
                /*"  03            LC45.*/
            }
            public SI0806B_LC45 LC45 { get; set; } = new SI0806B_LC45();
            public class SI0806B_LC45 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ' GERAIS A IMPORTANCIA SUPRACI-'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ");
                /*"  03            LC46.*/
            }
            public SI0806B_LC46 LC46 { get; set; } = new SI0806B_LC46();
            public class SI0806B_LC46 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TADA COMO ADIANTAMENTO PELOS DANOS E PREJUIZOS QU               'E SE ORIGINARAM DA  OCORRENCIA'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TADA COMO ADIANTAMENTO PELOS DANOS E PREJUIZOS QU               ");
                /*"  03            LC47.*/
            }
            public SI0806B_LC47 LC47 { get; set; } = new SI0806B_LC47();
            public class SI0806B_LC47 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'DESCRITA, EM REGULACAO NO PROCESSO DE SINISTRO EM               ' REFERENCIA.'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"DESCRITA, EM REGULACAO NO PROCESSO DE SINISTRO EM               ");
                /*"  03            LC49.*/
            }
            public SI0806B_LC49 LC49 { get; set; } = new SI0806B_LC49();
            public class SI0806B_LC49 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'A EFETIVA INDENIZACAO REFERENTE AO PRESENTE PROCE               'SSO SERA FEITA QUANDO DO  TER-'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"A EFETIVA INDENIZACAO REFERENTE AO PRESENTE PROCE               ");
                /*"  03            LC50.*/
            }
            public SI0806B_LC50 LC50 { get; set; } = new SI0806B_LC50();
            public class SI0806B_LC50 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'MINO DA REGULACAO DO EVENTO DESCONTANDO-SE O VALO               'R DO ADIANTAMENTO AQUI  CONCE-'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"MINO DA REGULACAO DO EVENTO DESCONTANDO-SE O VALO               ");
                /*"  03            LC51.*/
            }
            public SI0806B_LC51 LC51 { get; set; } = new SI0806B_LC51();
            public class SI0806B_LC51 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'DIDO.'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"DIDO.");
                /*"  03            LC52.*/
            }
            public SI0806B_LC52 LC52 { get; set; } = new SI0806B_LC52();
            public class SI0806B_LC52 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3 (TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03            LC53.*/
            }
            public SI0806B_LC53 LC53 { get; set; } = new SI0806B_LC53();
            public class SI0806B_LC53 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TEOR PARA UM SO EFEITO.'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TEOR PARA UM SO EFEITO.");
                /*"  03            LC54.*/
            }
            public SI0806B_LC54 LC54 { get; set; } = new SI0806B_LC54();
            public class SI0806B_LC54 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(023) VALUE               'TOTAL DE INDENIZACAO'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"TOTAL DE INDENIZACAO");
                /*"    05          LC54-INDENIZ        PIC  ZZ.ZZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LC54_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "14", "ZZ.ZZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"  03            LC55.*/
            }
            public SI0806B_LC55 LC55 { get; set; } = new SI0806B_LC55();
            public class SI0806B_LC55 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(023) VALUE               'TOTAL DE ADIANTAMENTO'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"TOTAL DE ADIANTAMENTO");
                /*"    05          LC55-ADIANT         PIC  ZZ.ZZZ.ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LC55_ADIANT { get; set; } = new DoubleBasis(new PIC("9", "14", "ZZ.ZZZ.ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"  03            LC57.*/
            }
            public SI0806B_LC57 LC57 { get; set; } = new SI0806B_LC57();
            public class SI0806B_LC57 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(022) VALUE               'TOTAL'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"TOTAL");
                /*"    05          LC57-TOTAL          PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99-*/
                public DoubleBasis LC57_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99-"), 3);
                /*"  03            LC0E.*/
            }
            public SI0806B_LC0E LC0E { get; set; } = new SI0806B_LC0E();
            public class SI0806B_LC0E : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE 'CORRETOR'*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CORRETOR");
                /*"  03            LC58.*/
            }
            public SI0806B_LC58 LC58 { get; set; } = new SI0806B_LC58();
            public class SI0806B_LC58 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC58-CODPDT         PIC  9(006) BLANK WHEN ZERO.*/
                public IntBasis LC58_CODPDT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC58-TRACO          PIC  X(003) VALUE SPACES.*/
                public StringBasis LC58_TRACO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC58-NOMPDT         PIC  X(032) VALUE SPACES.*/
                public StringBasis LC58_NOMPDT { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC0F.*/
            }
            public SI0806B_LC0F LC0F { get; set; } = new SI0806B_LC0F();
            public class SI0806B_LC0F : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE  SPACE.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE 'LOCAL E'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LOCAL E");
                /*"    05          FILLER              PIC  X(052) VALUE 'DATA'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"DATA");
                /*"    05          FILLER              PIC X(20) VALUE 'ASSINATURA'*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"ASSINATURA");
                /*"  03            LC58A.*/
            }
            public SI0806B_LC58A LC58A { get; set; } = new SI0806B_LC58A();
            public class SI0806B_LC58A : VarBasis
            {
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          LC58A-FONTE         PIC  X(020) JUST RIGHT.*/
                public StringBasis LC58A_FONTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER              PIC  X(003) VALUE ', '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @", ");
                /*"    05          LC58A-DIA-EMIS      PIC  99     VALUE 99.*/
                public IntBasis LC58A_DIA_EMIS { get; set; } = new IntBasis(new PIC("9", "2", "99"), 99);
                /*"    05          FILLER              PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    05          LC58A-MES-EMIS      PIC  X(010) VALUE SPACES.*/
                public StringBasis LC58A_MES_EMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE                                    ' DE '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"    05          LC58A-ANO-EMIS      PIC  9(004) VALUE 9999.*/
                public IntBasis LC58A_ANO_EMIS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 9999);
                /*"  03            LC58B.*/
            }
            public SI0806B_LC58B LC58B { get; set; } = new SI0806B_LC58B();
            public class SI0806B_LC58B : VarBasis
            {
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(036) VALUE ALL '-'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  03            LC58C.*/
            }
            public SI0806B_LC58C LC58C { get; set; } = new SI0806B_LC58C();
            public class SI0806B_LC58C : VarBasis
            {
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'NOME :'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"NOME :");
                /*"  03            LC58D.*/
            }
            public SI0806B_LC58D LC58D { get; set; } = new SI0806B_LC58D();
            public class SI0806B_LC58D : VarBasis
            {
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'CPF  :'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CPF  :");
                /*"  03            LC58E.*/
            }
            public SI0806B_LC58E LC58E { get; set; } = new SI0806B_LC58E();
            public class SI0806B_LC58E : VarBasis
            {
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'IDENT:'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"IDENT:");
                /*"  03            LC60.*/
            }
            public SI0806B_LC60 LC60 { get; set; } = new SI0806B_LC60();
            public class SI0806B_LC60 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(037) VALUE               'EM FUNCAO DE CORRECAO MONETARIA'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"EM FUNCAO DE CORRECAO MONETARIA");
                /*"    05          LC60-LIT            PIC  X(004) VALUE SPACES.*/
                public StringBasis LC60_LIT { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC60-CRRMON         PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC60_CRRMON { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  03            LC62.*/
            }
            public SI0806B_LC62 LC62 { get; set; } = new SI0806B_LC62();
            public class SI0806B_LC62 : VarBasis
            {
                /*"    05          FILLER              PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"    05          FILLER              PIC  X(022) VALUE                'INDENIZACAO TOTAL...: '.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"INDENIZACAO TOTAL...: ");
                /*"    05          LC62-VAL-TOT        PIC **.***.***.***.**9,99.*/
                public DoubleBasis LC62_VAL_TOT { get; set; } = new DoubleBasis(new PIC("9", "1", "**.***.***.***.**9V99."), 2);
                /*"  03            LC63.*/
            }
            public SI0806B_LC63 LC63 { get; set; } = new SI0806B_LC63();
            public class SI0806B_LC63 : VarBasis
            {
                /*"    05          FILLER              PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"    05          FILLER              PIC  X(022) VALUE                'PREMIO RETIDO/IOF...: '.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"PREMIO RETIDO/IOF...: ");
                /*"    05          LC63-PR-IOF         PIC **.***.***.***.**9,99.*/
                public DoubleBasis LC63_PR_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "**.***.***.***.**9V99."), 2);
                /*"  03            LC64.*/
            }
            public SI0806B_LC64 LC64 { get; set; } = new SI0806B_LC64();
            public class SI0806B_LC64 : VarBasis
            {
                /*"    05          FILLER              PIC  X(038) VALUE SPACES.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"    05          FILLER              PIC  X(022) VALUE                'INDENIZACAO LIQUIDA : '.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"INDENIZACAO LIQUIDA : ");
                /*"    05          LC64-VAL-LIQ        PIC **.***.***.***.**9,99.*/
                public DoubleBasis LC64_VAL_LIQ { get; set; } = new DoubleBasis(new PIC("9", "1", "**.***.***.***.**9V99."), 2);
                /*"  03            LC65.*/
            }
            public SI0806B_LC65 LC65 { get; set; } = new SI0806B_LC65();
            public class SI0806B_LC65 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'O BENEFICIARIO, ACIMA INDICADO, DECLARA TER RECEB               'IDO DA SASSE -  CIA.  NACIONAL'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"O BENEFICIARIO, ACIMA INDICADO, DECLARA TER RECEB               ");
                /*"  03            LC66.*/
            }
            public SI0806B_LC66 LC66 { get; set; } = new SI0806B_LC66();
            public class SI0806B_LC66 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'DE SEGUROS GERAIS, A QUANTIA SUPRA, EM PAGAMENTO               'INTEGRAL DO BENEFICIO QUE  LHE'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"DE SEGUROS GERAIS, A QUANTIA SUPRA, EM PAGAMENTO               ");
                /*"   03            LC67.*/
                public SI0806B_LC67 LC67 { get; set; } = new SI0806B_LC67();
                public class SI0806B_LC67 : VarBasis
                {
                    /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                    public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"    05          FILLER              PIC  X(080) VALUE               'CABE PELO SEGURO INSTITUIDO ATRAVES DA APOLICE E               'CERTIFICADO ACIMA CONSIGNADOS.'.*/
                    public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CABE PELO SEGURO INSTITUIDO ATRAVES DA APOLICE E               ");
                    /*"  03            LC69.*/
                }
            }
            public SI0806B_LC69 LC69 { get; set; } = new SI0806B_LC69();
            public class SI0806B_LC69 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'POR SER VERDADE, FIRMO O PRESENTE RECIBO EM 3 (TR               'ES) VIAS DE IGUAL TEOR E  PARA'.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"POR SER VERDADE, FIRMO O PRESENTE RECIBO EM 3 (TR               ");
                /*"  03            LC70.*/
            }
            public SI0806B_LC70 LC70 { get; set; } = new SI0806B_LC70();
            public class SI0806B_LC70 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'UM SO EFEITO, DANDO A CITADA COMPANHIA, PLENA, RA               'SA E GERAL QUITACAO, DECLARAN-'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"UM SO EFEITO, DANDO A CITADA COMPANHIA, PLENA, RA               ");
                /*"  03            LC71.*/
            }
            public SI0806B_LC71 LC71 { get; set; } = new SI0806B_LC71();
            public class SI0806B_LC71 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'DO-ME INTEGRALMENTE PAGO E SATISFEITO DE TODOS E               'QUAISQUER DIREITOS,  INDENIZA-'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"DO-ME INTEGRALMENTE PAGO E SATISFEITO DE TODOS E               ");
                /*"  03            LC72.*/
            }
            public SI0806B_LC72 LC72 { get; set; } = new SI0806B_LC72();
            public class SI0806B_LC72 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'CAO OU RECLAMACAO RELACIONADOS COM O SINISTRO EM               'APRECO.'.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CAO OU RECLAMACAO RELACIONADOS COM O SINISTRO EM               ");
                /*"  03            LC74.*/
            }
            public SI0806B_LC74 LC74 { get; set; } = new SI0806B_LC74();
            public class SI0806B_LC74 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"01              WRAMO48.*/
            }
        }
        public SI0806B_WRAMO48 WRAMO48 { get; set; } = new SI0806B_WRAMO48();
        public class SI0806B_WRAMO48 : VarBasis
        {
            /*"  03            LC75.*/
            public SI0806B_LC75 LC75 { get; set; } = new SI0806B_LC75();
            public class SI0806B_LC75 : VarBasis
            {
                /*"    05          FILLER            PIC X(001) VALUE  SPACE.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC X(007) VALUE 'APOLICE'.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"APOLICE");
                /*"    05          FILLER            PIC X(047) VALUE SPACES.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"    05          FILLER            PIC X(025) VALUE               'VALOR TOTAL DA DIVIDA'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"VALOR TOTAL DA DIVIDA");
                /*"  03            LC76.*/
            }
            public SI0806B_LC76 LC76 { get; set; } = new SI0806B_LC76();
            public class SI0806B_LC76 : VarBasis
            {
                /*"    05          FILLER            PIC X(003) VALUE SPACES.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC76-APOLICE      PIC 9(013).*/
                public IntBasis LC76_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05          FILLER            PIC X(046) VALUE SPACES.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          LC76-VALOR        PIC ***.***.***.**9,99.*/
                public DoubleBasis LC76_VALOR { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.***.**9V99."), 2);
                /*"  03            LC77A.*/
            }
            public SI0806B_LC77A LC77A { get; set; } = new SI0806B_LC77A();
            public class SI0806B_LC77A : VarBasis
            {
                /*"    05          FILLER            PIC X(055) VALUE  SPACES.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    05          FILLER            PIC X(025) VALUE               'PARTICIPACAO  DA  CEF  NA'.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"PARTICIPACAO  DA  CEF  NA");
                /*"  03            LC77B.*/
            }
            public SI0806B_LC77B LC77B { get; set; } = new SI0806B_LC77B();
            public class SI0806B_LC77B : VarBasis
            {
                /*"    05          FILLER            PIC X(055) VALUE  SPACES.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    05          FILLER            PIC X(025) VALUE               'PERDA  LIQUIDA DEFINITIVA'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"PERDA  LIQUIDA DEFINITIVA");
                /*"  03            LC77C.*/
            }
            public SI0806B_LC77C LC77C { get; set; } = new SI0806B_LC77C();
            public class SI0806B_LC77C : VarBasis
            {
                /*"    05          FILLER            PIC X(055) VALUE  SPACES.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    05          FILLER            PIC X(025) VALUE               '(DE ACORDO COM APOLICE)  '.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"(DE ACORDO COM APOLICE)  ");
                /*"  03            LC78.*/
            }
            public SI0806B_LC78 LC78 { get; set; } = new SI0806B_LC78();
            public class SI0806B_LC78 : VarBasis
            {
                /*"    05          FILLER            PIC X(062) VALUE SPACES.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "62", "X(062)"), @"");
                /*"    05          LC78-VALOR        PIC ***.***.***.**9,99.*/
                public DoubleBasis LC78_VALOR { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.***.**9V99."), 2);
                /*"  03            LC79.*/
            }
            public SI0806B_LC79 LC79 { get; set; } = new SI0806B_LC79();
            public class SI0806B_LC79 : VarBasis
            {
                /*"    05          FILLER            PIC X(001) VALUE  SPACE.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC X(011) VALUE 'OCORRENCIA'.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"OCORRENCIA");
                /*"    05          FILLER            PIC X(043) VALUE  SPACES.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"    05          FILLER            PIC X(025) VALUE               'LIQUIDO REEMBOLSADO A CEF'.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"LIQUIDO REEMBOLSADO A CEF");
                /*"  03            LC80.*/
            }
            public SI0806B_LC80 LC80 { get; set; } = new SI0806B_LC80();
            public class SI0806B_LC80 : VarBasis
            {
                /*"    05          FILLER            PIC X(003) VALUE SPACES.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC80-DATA-OCORR.*/
                public SI0806B_LC80_DATA_OCORR LC80_DATA_OCORR { get; set; } = new SI0806B_LC80_DATA_OCORR();
                public class SI0806B_LC80_DATA_OCORR : VarBasis
                {
                    /*"      07        LC80-DD-OC        PIC 9(002).*/
                    public IntBasis LC80_DD_OC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER            PIC X(001) VALUE '/'.*/
                    public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC80-MM-OC        PIC 9(002).*/
                    public IntBasis LC80_MM_OC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER            PIC X(001) VALUE '/'.*/
                    public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC80-AA-OC        PIC 9(004).*/
                    public IntBasis LC80_AA_OC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER            PIC X(049) VALUE SPACES.*/
                }
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"");
                /*"    05          LC80-VALOR        PIC ZZZ.ZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC80_VALOR { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ.ZZZ.ZZZVZZ."), @"");
                /*"  03            LC81.*/
            }
            public SI0806B_LC81 LC81 { get; set; } = new SI0806B_LC81();
            public class SI0806B_LC81 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ' GERAIS A IMPORTANCIA SUPRACI-'.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"RECEBI (EMOS) DA SASSE - CIA. NACIONAL DE SEGUROS               ");
                /*"  03            LC82.*/
            }
            public SI0806B_LC82 LC82 { get; set; } = new SI0806B_LC82();
            public class SI0806B_LC82 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TADA COMO INDENIZACAO PARCIAL, PELOS DANOS E PREJ               'UIZOS QUE SE ORIGINARAM DA  O-'.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TADA COMO INDENIZACAO PARCIAL, PELOS DANOS E PREJ               ");
                /*"  03            LC83.*/
            }
            public SI0806B_LC83 LC83 { get; set; } = new SI0806B_LC83();
            public class SI0806B_LC83 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'CORRENCIA DESCRITA E REGULADA NO PROCESSO DE SINI               'STRO EM REFERENCIA   RECEBENDO'.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CORRENCIA DESCRITA E REGULADA NO PROCESSO DE SINI               ");
                /*"  03            LC84.*/
            }
            public SI0806B_LC84 LC84 { get; set; } = new SI0806B_LC84();
            public class SI0806B_LC84 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'ESTA INDENIZACAO DOU (AMOS) A REFERIDA COMPANHIA               ', PLENA, GERAL  E  IRREVOGAVEL'.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"ESTA INDENIZACAO DOU (AMOS) A REFERIDA COMPANHIA               ");
                /*"  03            LC85.*/
            }
            public SI0806B_LC85 LC85 { get; set; } = new SI0806B_LC85();
            public class SI0806B_LC85 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'QUITACAO DE PAGO (S) E SATISFEITO (S) OS PREJUIZO               'S SOFRIDOS, REFERENTES A PERDA'.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"QUITACAO DE PAGO (S) E SATISFEITO (S) OS PREJUIZO               ");
                /*"  03            LC86.*/
            }
            public SI0806B_LC86 LC86 { get; set; } = new SI0806B_LC86();
            public class SI0806B_LC86 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'LIQUIDA DEFINITIVA DEDUZIDA A PARTICIPACAO OBRIGA               'TORIA DO SEGURADO,  SUB-ROGAN-'.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"LIQUIDA DEFINITIVA DEDUZIDA A PARTICIPACAO OBRIGA               ");
                /*"  03            LC87.*/
            }
            public SI0806B_LC87 LC87 { get; set; } = new SI0806B_LC87();
            public class SI0806B_LC87 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'DO-LHE TODAS AS ACOES QUE POSSAM CABER CONTRA  O               'CAUSADOR E/OU RESPONSAVEL PELO'.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"DO-LHE TODAS AS ACOES QUE POSSAM CABER CONTRA  O               ");
                /*"  03            LC88.*/
            }
            public SI0806B_LC88 LC88 { get; set; } = new SI0806B_LC88();
            public class SI0806B_LC88 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(072) VALUE               'EVENTO.                       '.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"EVENTO.                       ");
                /*"  03            LC89.*/
            }
            public SI0806B_LC89 LC89 { get; set; } = new SI0806B_LC89();
            public class SI0806B_LC89 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PELO PRESENTE FAZ AINDA A CEF SUBROGACAO A SASSE               'DOS DIREITOS A SUA  PARTICIPA-'.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PELO PRESENTE FAZ AINDA A CEF SUBROGACAO A SASSE               ");
                /*"  03            LC90.*/
            }
            public SI0806B_LC90 LC90 { get; set; } = new SI0806B_LC90();
            public class SI0806B_LC90 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'CAO NO VALOR TOTAL DA DIVIDA ACIMA INDICADA,   A               'FIM DE QUE A SASSE PROMOVA   A'.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"CAO NO VALOR TOTAL DA DIVIDA ACIMA INDICADA,   A               ");
                /*"  03            LC91.*/
            }
            public SI0806B_LC91 LC91 { get; set; } = new SI0806B_LC91();
            public class SI0806B_LC91 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'SUA RECUPERACAO JUDICIAL OU EXTRAJUDICIAL.'.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"SUA RECUPERACAO JUDICIAL OU EXTRAJUDICIAL.");
                /*"  03            LC92.*/
            }
            public SI0806B_LC92 LC92 { get; set; } = new SI0806B_LC92();
            public class SI0806B_LC92 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3 (TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03            LC93.*/
            }
            public SI0806B_LC93 LC93 { get; set; } = new SI0806B_LC93();
            public class SI0806B_LC93 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACE.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(080) VALUE               'TEOR PARA UM SO EFEITO.'.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"TEOR PARA UM SO EFEITO.");
                /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA-CURR.*/
            public SI0806B_WDATA_CURR WDATA_CURR { get; set; } = new SI0806B_WDATA_CURR();
            public class SI0806B_WDATA_CURR : VarBasis
            {
                /*"    05          WDATA-AA-CURR       PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-CURR.*/
            }
            public SI0806B_WHORA_CURR WHORA_CURR { get; set; } = new SI0806B_WHORA_CURR();
            public class SI0806B_WHORA_CURR : VarBasis
            {
                /*"    05          WHORA-HH-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SS-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-CC-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA-CABEC.*/
            }
            public SI0806B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0806B_WDATA_CABEC();
            public class SI0806B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0806B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0806B_WHORA_CABEC();
            public class SI0806B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA.*/
            }
            public SI0806B_WDATA WDATA { get; set; } = new SI0806B_WDATA();
            public class SI0806B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-DD            PIC  9(002).*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-R             REDEFINES WDATA                                    PIC  X(010).*/
            }
            private _REDEF_StringBasis _wdata_r { get; set; }
            public _REDEF_StringBasis WDATA_R
            {
                get { _wdata_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATA, _wdata_r); VarBasis.RedefinePassValue(WDATA, _wdata_r, WDATA); _wdata_r.ValueChanged += () => { _.Move(_wdata_r, WDATA); }; return _wdata_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_r, WDATA); }
            }  //Redefines
            /*"  03            WZEROS              PIC 9(003) VALUE 0.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03            WHUM                PIC 9(003) VALUE 1.*/
            public IntBasis WHUM { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 1);
            /*"  03            WFIM-TRELSIN1       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TRELSIN2       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TMESTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TMESTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-THISTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_THISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            W-CONT-PAG          PIC  S9(005) VALUE  +0.*/
            public IntBasis W_CONT_PAG { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            W-CONT-LIN          PIC  S9(002) VALUE  +70.*/
            public IntBasis W_CONT_LIN { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +70);
            /*"  03            WSINISTRO-ANT       PIC   9(013) VALUE ZEROS.*/
            public IntBasis WSINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            FILLER              REDEFINES WSINISTRO-ANT.*/
            private _REDEF_SI0806B_FILLER_232 _filler_232 { get; set; }
            public _REDEF_SI0806B_FILLER_232 FILLER_232
            {
                get { _filler_232 = new _REDEF_SI0806B_FILLER_232(); _.Move(WSINISTRO_ANT, _filler_232); VarBasis.RedefinePassValue(WSINISTRO_ANT, _filler_232, WSINISTRO_ANT); _filler_232.ValueChanged += () => { _.Move(_filler_232, WSINISTRO_ANT); }; return _filler_232; }
                set { VarBasis.RedefinePassValue(value, _filler_232, WSINISTRO_ANT); }
            }  //Redefines
            public class _REDEF_SI0806B_FILLER_232 : VarBasis
            {
                /*"    05          WORGSIN             PIC   9(003).*/
                public IntBasis WORGSIN { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          WRMOSIN             PIC   9(002).*/
                public IntBasis WRMOSIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WNUMSIN             PIC   9(008).*/
                public IntBasis WNUMSIN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            WAPOLSIN-ANT        PIC   9(013) VALUE ZEROS.*/

                public _REDEF_SI0806B_FILLER_232()
                {
                    WORGSIN.ValueChanged += OnValueChanged;
                    WRMOSIN.ValueChanged += OnValueChanged;
                    WNUMSIN.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WAPOLSIN_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            FILLER              REDEFINES WAPOLSIN-ANT.*/
            private _REDEF_SI0806B_FILLER_233 _filler_233 { get; set; }
            public _REDEF_SI0806B_FILLER_233 FILLER_233
            {
                get { _filler_233 = new _REDEF_SI0806B_FILLER_233(); _.Move(WAPOLSIN_ANT, _filler_233); VarBasis.RedefinePassValue(WAPOLSIN_ANT, _filler_233, WAPOLSIN_ANT); _filler_233.ValueChanged += () => { _.Move(_filler_233, WAPOLSIN_ANT); }; return _filler_233; }
                set { VarBasis.RedefinePassValue(value, _filler_233, WAPOLSIN_ANT); }
            }  //Redefines
            public class _REDEF_SI0806B_FILLER_233 : VarBasis
            {
                /*"    05          WORGSIN-ANT         PIC   9(003).*/
                public IntBasis WORGSIN_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          WRMOSIN-ANT         PIC   9(002).*/
                public IntBasis WRMOSIN_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WNUMSIN-ANT         PIC   9(008).*/
                public IntBasis WNUMSIN_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            WAUX-NUM-APOL       PIC   9(013) VALUE ZEROS.*/

                public _REDEF_SI0806B_FILLER_233()
                {
                    WORGSIN_ANT.ValueChanged += OnValueChanged;
                    WRMOSIN_ANT.ValueChanged += OnValueChanged;
                    WNUMSIN_ANT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WAUX_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            FILLER              REDEFINES WAUX-NUM-APOL.*/
            private _REDEF_SI0806B_FILLER_234 _filler_234 { get; set; }
            public _REDEF_SI0806B_FILLER_234 FILLER_234
            {
                get { _filler_234 = new _REDEF_SI0806B_FILLER_234(); _.Move(WAUX_NUM_APOL, _filler_234); VarBasis.RedefinePassValue(WAUX_NUM_APOL, _filler_234, WAUX_NUM_APOL); _filler_234.ValueChanged += () => { _.Move(_filler_234, WAUX_NUM_APOL); }; return _filler_234; }
                set { VarBasis.RedefinePassValue(value, _filler_234, WAUX_NUM_APOL); }
            }  //Redefines
            public class _REDEF_SI0806B_FILLER_234 : VarBasis
            {
                /*"    05          WORGAO              PIC   9(003).*/
                public IntBasis WORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          WRAMO               PIC   9(002).*/
                public IntBasis WRAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC   9(008).*/
                public IntBasis FILLER_235 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03            WIMP-LC55           PIC   X(001) VALUE 'N'.*/

                public _REDEF_SI0806B_FILLER_234()
                {
                    WORGAO.ValueChanged += OnValueChanged;
                    WRAMO.ValueChanged += OnValueChanged;
                    FILLER_235.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WIMP_LC55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WIMP-MASC           PIC   X(001) VALUE 'N'.*/
            public StringBasis WIMP_MASC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WOPER-ANT           PIC  S9(004) VALUE  +0.*/
            public IntBasis WOPER_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WS-VLISS            PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WS_VLISS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WC-VALOR            PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WC_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WC-TOTAL            PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WC_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WC-VAL1             PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WC_VAL1 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WC-VAL2             PIC S9(015)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WC_VAL2 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WC-VAL3             PIC S9(013)V99  COMP-3                                    VALUE +0.*/
            public DoubleBasis WC_VAL3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WQTD-MOEDA      PIC 9(013)V9(4)   VALUE ZEROS.*/
            public DoubleBasis WQTD_MOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V9(4)"), 4);
            /*"  03            WNOME-FONTE         PIC  X(040).*/
            public StringBasis WNOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03            WGEUNIMO-CODUNIMO  PIC 9(004).*/
            public IntBasis WGEUNIMO_CODUNIMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03            WRAMO-ANT           PIC  9(002)  VALUE ZEROS.*/
            public IntBasis WRAMO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03            LIDOS-EMISSAO       PIC  9(006)  VALUE ZEROS.*/
            public IntBasis LIDOS_EMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            LIDOS-REEMISSAO     PIC  9(006)  VALUE ZEROS.*/
            public IntBasis LIDOS_REEMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            IMPRES-EMISSAO      PIC  9(006)  VALUE ZEROS.*/
            public IntBasis IMPRES_EMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            IMPRES-REEMISSAO    PIC  9(006)  VALUE ZEROS.*/
            public IntBasis IMPRES_REEMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WETAPA              PIC  X(001)  VALUE 'E'.*/
            public StringBasis WETAPA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"  03            WVIA                PIC  9(001)  VALUE  1.*/
            public IntBasis WVIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 1);
            /*"  03            WS-CONTADOR         PIC  9(001)  VALUE  0.*/
            public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WTEXTO              PIC  9(001)  VALUE  0.*/
            public IntBasis WTEXTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WTABMES-G.*/
            public SI0806B_WTABMES_G WTABMES_G { get; set; } = new SI0806B_WTABMES_G();
            public class SI0806B_WTABMES_G : VarBasis
            {
                /*"    05          FILLER     PIC  X(009) VALUE '  JANEIRO'.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"    05          FILLER     PIC  X(009) VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    05          FILLER     PIC  X(009) VALUE '    MARCO'.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"    05          FILLER     PIC  X(009) VALUE '    ABRIL'.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"    05          FILLER     PIC  X(009) VALUE '     MAIO'.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"    05          FILLER     PIC  X(009) VALUE '    JUNHO'.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"    05          FILLER     PIC  X(009) VALUE '    JULHO'.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"    05          FILLER     PIC  X(009) VALUE '   AGOSTO'.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"    05          FILLER     PIC  X(009) VALUE ' SETEMBRO'.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"    05          FILLER     PIC  X(009) VALUE '  OUTUBRO'.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"    05          FILLER     PIC  X(009) VALUE ' NOVEMBRO'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"    05          FILLER     PIC  X(009) VALUE ' DEZEMBRO'.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"  03            TABELA-MESES-R  REDEFINES WTABMES-G*/
            }
            private _REDEF_SI0806B_TABELA_MESES_R _tabela_meses_r { get; set; }
            public _REDEF_SI0806B_TABELA_MESES_R TABELA_MESES_R
            {
                get { _tabela_meses_r = new _REDEF_SI0806B_TABELA_MESES_R(); _.Move(WTABMES_G, _tabela_meses_r); VarBasis.RedefinePassValue(WTABMES_G, _tabela_meses_r, WTABMES_G); _tabela_meses_r.ValueChanged += () => { _.Move(_tabela_meses_r, WTABMES_G); }; return _tabela_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tabela_meses_r, WTABMES_G); }
            }  //Redefines
            public class _REDEF_SI0806B_TABELA_MESES_R : VarBasis
            {
                /*"    05          WTABMES         PIC  X(009)  OCCURS 12.*/
                public ListBasis<StringBasis, string> WTABMES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)"), 12);
                /*"  03            WTAB-LETRA-01.*/

                public _REDEF_SI0806B_TABELA_MESES_R()
                {
                    WTABMES.ValueChanged += OnValueChanged;
                }

            }
            public SI0806B_WTAB_LETRA_01 WTAB_LETRA_01 { get; set; } = new SI0806B_WTAB_LETRA_01();
            public class SI0806B_WTAB_LETRA_01 : VarBasis
            {
                /*"    05          WTAB1-LETRA PIC  X(001) OCCURS 132.*/
                public ListBasis<StringBasis, string> WTAB1_LETRA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 132);
                /*"  03            WTAB-LETRA-02.*/
            }
            public SI0806B_WTAB_LETRA_02 WTAB_LETRA_02 { get; set; } = new SI0806B_WTAB_LETRA_02();
            public class SI0806B_WTAB_LETRA_02 : VarBasis
            {
                /*"    05          WTAB2-LETRA PIC  X(001) OCCURS 132.*/
                public ListBasis<StringBasis, string> WTAB2_LETRA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 132);
                /*"  03            WLC58A           VALUE SPACES.*/
            }
            public SI0806B_WLC58A WLC58A { get; set; } = new SI0806B_WLC58A();
            public class SI0806B_WLC58A : VarBasis
            {
                /*"    05          FILLER           PIC X(012).*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    05          WLC58A-LINHA     PIC X(132).*/
                public StringBasis WLC58A_LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
                /*"  03            X01              PIC 9(003) VALUE ZEROS.*/
            }
            public IntBasis X01 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03            X02              PIC 9(003) VALUE ZEROS.*/
            public IntBasis X02 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03            X03              PIC 9(003) VALUE ZEROS.*/
            public IntBasis X03 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"01          FILLER.*/
        }
        public SI0806B_FILLER_249 FILLER_249 { get; set; } = new SI0806B_FILLER_249();
        public class SI0806B_FILLER_249 : VarBasis
        {
            /*"  03  WFIM-V1RELATORIOS         PIC X(003)  VALUE SPACES.*/
            public StringBasis WFIM_V1RELATORIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  W-TEM-RECIBO-PARA-EMITIR  PIC X(003)  VALUE SPACES.*/
            public StringBasis W_TEM_RECIBO_PARA_EMITIR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  W-CONTA-RELAT-SOLICITADO  PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_CONTA_RELAT_SOLICITADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            WTABG-RAMOS.*/
            public SI0806B_WTABG_RAMOS WTABG_RAMOS { get; set; } = new SI0806B_WTABG_RAMOS();
            public class SI0806B_WTABG_RAMOS : VarBasis
            {
                /*"    05          WTABG-RAMO-ZERA.*/
                public SI0806B_WTABG_RAMO_ZERA WTABG_RAMO_ZERA { get; set; } = new SI0806B_WTABG_RAMO_ZERA();
                public class SI0806B_WTABG_RAMO_ZERA : VarBasis
                {
                    /*"      07        FILLER              PIC S9(004) COMP VALUE +0.*/
                    public IntBasis FILLER_250 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07        FILLER              PIC  X(040) VALUE SPACES.*/
                    public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"      07        WTABG-RAMOGRUPO.*/
                    public SI0806B_WTABG_RAMOGRUPO WTABG_RAMOGRUPO { get; set; } = new SI0806B_WTABG_RAMOGRUPO();
                    public class SI0806B_WTABG_RAMOGRUPO : VarBasis
                    {
                        /*"        09      WTABG-OCORRERAMO    OCCURS  100   TIMES                                    INDEXED  BY   I01.*/
                        public ListBasis<SI0806B_WTABG_OCORRERAMO> WTABG_OCORRERAMO { get; set; } = new ListBasis<SI0806B_WTABG_OCORRERAMO>(100);
                        public class SI0806B_WTABG_OCORRERAMO : VarBasis
                        {
                            /*"          11    WTABG-RAMO          PIC S9(004) COMP.*/
                            public IntBasis WTABG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          11    WTABG-NOMERAMO      PIC  X(040).*/
                            public StringBasis WTABG_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                            /*"  03            WTABG-FONTES.*/
                        }
                    }
                }
            }
            public SI0806B_WTABG_FONTES WTABG_FONTES { get; set; } = new SI0806B_WTABG_FONTES();
            public class SI0806B_WTABG_FONTES : VarBasis
            {
                /*"    05          WTABG-FONTE-ZERA.*/
                public SI0806B_WTABG_FONTE_ZERA WTABG_FONTE_ZERA { get; set; } = new SI0806B_WTABG_FONTE_ZERA();
                public class SI0806B_WTABG_FONTE_ZERA : VarBasis
                {
                    /*"      07        FILLER              PIC S9(004) COMP VALUE +0.*/
                    public IntBasis FILLER_252 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07        FILLER              PIC  X(040) VALUE SPACES.*/
                    public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"      07        WTABG-FONTEGRUPO.*/
                    public SI0806B_WTABG_FONTEGRUPO WTABG_FONTEGRUPO { get; set; } = new SI0806B_WTABG_FONTEGRUPO();
                    public class SI0806B_WTABG_FONTEGRUPO : VarBasis
                    {
                        /*"        09      WTABG-OCORREFONTE   OCCURS  200   TIMES                                    INDEXED  BY   I02.*/
                        public ListBasis<SI0806B_WTABG_OCORREFONTE> WTABG_OCORREFONTE { get; set; } = new ListBasis<SI0806B_WTABG_OCORREFONTE>(200);
                        public class SI0806B_WTABG_OCORREFONTE : VarBasis
                        {
                            /*"          11    WTABG-FONTE         PIC S9(004) COMP.*/
                            public IntBasis WTABG_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          11    WTABG-NOMEFTE       PIC  X(040).*/
                            public StringBasis WTABG_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                            /*"  03        WABEND.*/
                        }
                    }
                }
            }
            public SI0806B_WABEND WABEND { get; set; } = new SI0806B_WABEND();
            public class SI0806B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0806B'.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0806B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0806B_LK_LINK LK_LINK { get; set; } = new SI0806B_LK_LINK();
        public class SI0806B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0806B_V1RELATORIOS V1RELATORIOS { get; set; } = new SI0806B_V1RELATORIOS();
        public SI0806B_TRELSIN1 TRELSIN1 { get; set; } = new SI0806B_TRELSIN1();
        public SI0806B_TAPDCORR TAPDCORR { get; set; } = new SI0806B_TAPDCORR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0806M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0806M1.SetFile(SI0806M1_FILE_NAME_P);

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
            /*" -1139- OPEN OUTPUT SI0806M1. */
            SI0806M1.Open(REG_SI0806M1);

            /*" -1140- MOVE '005' TO WNR-EXEC-SQL */
            _.Move("005", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1142- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", FILLER_249.WABEND.PARAGRAFO);

            /*" -1143- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1145- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1148- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1151- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), WRAMO48.WHORA_CURR);

            /*" -1152- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(WRAMO48.WHORA_CURR.WHORA_HH_CURR, WRAMO48.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -1153- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(WRAMO48.WHORA_CURR.WHORA_MM_CURR, WRAMO48.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -1155- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(WRAMO48.WHORA_CURR.WHORA_SS_CURR, WRAMO48.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -1156- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, WRAMO48.WDATA_CURR);

            /*" -1157- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(WRAMO48.WDATA_CURR.WDATA_DD_CURR, WRAMO48.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1158- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(WRAMO48.WDATA_CURR.WDATA_MM_CURR, WRAMO48.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1160- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(WRAMO48.WDATA_CURR.WDATA_AA_CURR, WRAMO48.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1162- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -1164- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -1166- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -1173- PERFORM 070-000-LER-V1PARAMRAMO. */

            M_070_000_LER_V1PARAMRAMO_SECTION();

            /*" -1174- MOVE '010' TO WNR-EXEC-SQL */
            _.Move("010", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1176- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", FILLER_249.WABEND.PARAGRAFO);

            /*" -1182- PERFORM M_000_000_PRINCIPAL_DB_DECLARE_1 */

            M_000_000_PRINCIPAL_DB_DECLARE_1();

            /*" -1184- PERFORM M_000_000_PRINCIPAL_DB_OPEN_1 */

            M_000_000_PRINCIPAL_DB_OPEN_1();

            /*" -1187- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1188- DISPLAY 'PROBLEMAS OPEN V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS OPEN V1RELATORIOS ... ");

                /*" -1190- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1191- MOVE 'NAO' TO WFIM-V1RELATORIOS. */
            _.Move("NAO", FILLER_249.WFIM_V1RELATORIOS);

            /*" -1193- MOVE ZERO TO W-CONTA-RELAT-SOLICITADO. */
            _.Move(0, FILLER_249.W_CONTA_RELAT_SOLICITADO);

            /*" -1195- PERFORM 100-00-FETCH-V1RELATORIOS. */

            M_100_00_FETCH_V1RELATORIOS_SECTION();

            /*" -1198- PERFORM 110-00-EXECUTA-RECIBO UNTIL WFIM-V1RELATORIOS EQUAL 'SIM' . */

            while (!(FILLER_249.WFIM_V1RELATORIOS == "SIM"))
            {

                M_110_00_EXECUTA_RECIBO_SECTION();
            }

            /*" -1200- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -1201- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1202- CLOSE SI0806M1. */
            SI0806M1.Close();

            /*" -1202- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-DB-DECLARE-1 */
        public void M_000_000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -1182- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT CODRELAT, DATA_REFERENCIA FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0806B' AND SITUACAO = ' ' END-EXEC. */
            V1RELATORIOS = new SI0806B_V1RELATORIOS(false);
            string GetQuery_V1RELATORIOS()
            {
                var query = @$"SELECT CODRELAT
							, 
							DATA_REFERENCIA 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'SI0806B' 
							AND SITUACAO = ' '";

                return query;
            }
            V1RELATORIOS.GetQueryEvent += GetQuery_V1RELATORIOS;

        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-DB-OPEN-1 */
        public void M_000_000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -1184- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1()
        {
            /*" -1399- EXEC SQL DECLARE TRELSIN1 CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.DTMOVTO, H.OPERACAO, H.OCORHIST, M.FONTE, M.COD_MOEDA_SINI, H.LIMCRR FROM SEGUROS.V1HISTSINI H, SEGUROS.V1MESTSINI M WHERE H.DTMOVTO = :SIST-DTRECIBO AND (H.OPERACAO = 1001 OR H.OPERACAO = 1002 OR H.OPERACAO = 1003 OR H.OPERACAO = 1004 OR H.OPERACAO = 9001) AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.SITUACAO = '1' ORDER BY FONTE, NUM_APOL_SINISTRO, OPERACAO, OCORHIST END-EXEC. */
            TRELSIN1 = new SI0806B_TRELSIN1(true);
            string GetQuery_TRELSIN1()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.DTMOVTO
							, 
							H.OPERACAO
							, H.OCORHIST
							, 
							M.FONTE
							, 
							M.COD_MOEDA_SINI
							, 
							H.LIMCRR 
							FROM SEGUROS.V1HISTSINI H
							, 
							SEGUROS.V1MESTSINI M 
							WHERE H.DTMOVTO = '{SIST_DTRECIBO}' 
							AND 
							(H.OPERACAO = 1001 
							OR H.OPERACAO = 1002 
							OR H.OPERACAO = 1003 
							OR H.OPERACAO = 1004 
							OR H.OPERACAO = 9001) 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.SITUACAO = '1' 
							ORDER BY FONTE
							, NUM_APOL_SINISTRO
							, OPERACAO
							, OCORHIST";

                return query;
            }
            TRELSIN1.GetQueryEvent += GetQuery_TRELSIN1;

        }

        [StopWatch]
        /*" M-100-00-FETCH-V1RELATORIOS-SECTION */
        private void M_100_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -1211- MOVE '100-00-FETCH-V1RELATORIOS' TO PARAGRAFO. */
            _.Move("100-00-FETCH-V1RELATORIOS", FILLER_249.WABEND.PARAGRAFO);

            /*" -1213- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1216- PERFORM M_100_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            M_100_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -1219- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1220- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1221- MOVE 'SIM' TO WFIM-V1RELATORIOS */
                    _.Move("SIM", FILLER_249.WFIM_V1RELATORIOS);

                    /*" -1221- PERFORM M_100_00_FETCH_V1RELATORIOS_DB_CLOSE_1 */

                    M_100_00_FETCH_V1RELATORIOS_DB_CLOSE_1();

                    /*" -1223- GO TO 100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1224- ELSE */
                }
                else
                {


                    /*" -1225- DISPLAY 'ERRO FETCH V1RELATORIOS ... ' */
                    _.Display($"ERRO FETCH V1RELATORIOS ... ");

                    /*" -1227- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1229- ADD 1 TO W-CONTA-RELAT-SOLICITADO. */
            FILLER_249.W_CONTA_RELAT_SOLICITADO.Value = FILLER_249.W_CONTA_RELAT_SOLICITADO + 1;

            /*" -1229- MOVE V1RELA-DATA-REFERE TO SIST-DTRECIBO. */
            _.Move(V1RELA_DATA_REFERE, SIST_DTRECIBO);

        }

        [StopWatch]
        /*" M-100-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void M_100_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -1216- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-CODRELAT, :V1RELA-DATA-REFERE END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_CODRELAT, V1RELA_CODRELAT);
                _.Move(V1RELATORIOS.V1RELA_DATA_REFERE, V1RELA_DATA_REFERE);
            }

        }

        [StopWatch]
        /*" M-100-00-FETCH-V1RELATORIOS-DB-CLOSE-1 */
        public void M_100_00_FETCH_V1RELATORIOS_DB_CLOSE_1()
        {
            /*" -1221- EXEC SQL CLOSE V1RELATORIOS END-EXEC */

            V1RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_99_SAIDA*/

        [StopWatch]
        /*" M-110-00-EXECUTA-RECIBO-SECTION */
        private void M_110_00_EXECUTA_RECIBO_SECTION()
        {
            /*" -1240- PERFORM 090-000-CURSOR-TRELSIN-E. */

            M_090_000_CURSOR_TRELSIN_E_SECTION();

            /*" -1241- MOVE SPACES TO WFIM-TRELSIN1. */
            _.Move("", WRAMO48.WFIM_TRELSIN1);

            /*" -1242- MOVE ZEROS TO IMPRES-EMISSAO. */
            _.Move(0, WRAMO48.IMPRES_EMISSAO);

            /*" -1243- MOVE 'SIM' TO W-TEM-RECIBO-PARA-EMITIR. */
            _.Move("SIM", FILLER_249.W_TEM_RECIBO_PARA_EMITIR);

            /*" -1245- PERFORM 150-000-LER-TRELSIN-E. */

            M_150_000_LER_TRELSIN_E_SECTION();

            /*" -1246- IF WFIM-TRELSIN1 EQUAL 'S' */

            if (WRAMO48.WFIM_TRELSIN1 == "S")
            {

                /*" -1247- DISPLAY '*******************************************' */
                _.Display($"*******************************************");

                /*" -1248- DISPLAY '*        NAO HOUVE EMISSAO DE RECIBO      *' */
                _.Display($"*        NAO HOUVE EMISSAO DE RECIBO      *");

                /*" -1249- DISPLAY '*          PARA A DATA SOLICITADA         *' */
                _.Display($"*          PARA A DATA SOLICITADA         *");

                /*" -1250- DISPLAY '*                                         *' */
                _.Display($"*                                         *");

                /*" -1251- DISPLAY '* DATA SOLICITADA = ' SIST-DTRECIBO */
                _.Display($"* DATA SOLICITADA = {SIST_DTRECIBO}");

                /*" -1252- DISPLAY '*******************************************' */
                _.Display($"*******************************************");

                /*" -1253- MOVE 'NAO' TO W-TEM-RECIBO-PARA-EMITIR */
                _.Move("NAO", FILLER_249.W_TEM_RECIBO_PARA_EMITIR);

                /*" -1254- ELSE */
            }
            else
            {


                /*" -1257- PERFORM 120-000-PROCESSA-E UNTIL WFIM-TRELSIN1 EQUAL 'S' . */

                while (!(WRAMO48.WFIM_TRELSIN1 == "S"))
                {

                    M_120_000_PROCESSA_E_SECTION();
                }
            }


            /*" -1258- IF W-TEM-RECIBO-PARA-EMITIR EQUAL 'SIM' */

            if (FILLER_249.W_TEM_RECIBO_PARA_EMITIR == "SIM")
            {

                /*" -1259- DISPLAY ' ' */
                _.Display($" ");

                /*" -1260- DISPLAY '=>  PARA A DATA SOLICITADA ' SIST-DTRECIBO */
                _.Display($"=>  PARA A DATA SOLICITADA {SIST_DTRECIBO}");

                /*" -1261- DISPLAY '=> FORAM EMITIDOS ' IMPRES-EMISSAO ' RECIBOS' */

                $"=> FORAM EMITIDOS {WRAMO48.IMPRES_EMISSAO} RECIBOS"
                .Display();

                /*" -1263- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -1264- MOVE 0 TO WC-VALOR. */
            _.Move(0, WRAMO48.WC_VALOR);

            /*" -1264- PERFORM 100-00-FETCH-V1RELATORIOS. */

            M_100_00_FETCH_V1RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_99_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -1280- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -1283- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -1285- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -1290- IF LK-RTCODE NOT EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE != 00)
            {

                /*" -1291- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -1291- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -1280- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOM_EMP, V1EMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -1308- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", FILLER_249.WABEND.PARAGRAFO);

            /*" -1309- MOVE WTABG-RAMO-ZERA TO WTABG-RAMOGRUPO. */
            _.Move(FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA, FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO);

            /*" -1309- MOVE WTABG-FONTE-ZERA TO WTABG-FONTEGRUPO. */
            _.Move(FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA, FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -1323- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", FILLER_249.WABEND.PARAGRAFO);

            /*" -1325- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1331- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -1334- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1335- DISPLAY 'SI0806B  - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0806B  - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -1337- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1338- MOVE SIST-DTMOVABE TO WDATA-R. */
            _.Move(SIST_DTMOVABE, WRAMO48.WDATA_R);

            /*" -1339- MOVE WDATA-DD TO LC58A-DIA-EMIS. */
            _.Move(WRAMO48.WDATA.WDATA_DD, W.LC58A.LC58A_DIA_EMIS);

            /*" -1341- MOVE WTABMES (WDATA-MM) TO LC58A-MES-EMIS. */
            _.Move(WRAMO48.TABELA_MESES_R.WTABMES[WRAMO48.WDATA.WDATA_MM], W.LC58A.LC58A_MES_EMIS);

            /*" -1341- MOVE WDATA-AA TO LC58A-ANO-EMIS. */
            _.Move(WRAMO48.WDATA.WDATA_AA, W.LC58A.LC58A_ANO_EMIS);

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -1331- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
                _.Move(executed_1.SIST_DTCURRENT, SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-SECTION */
        private void M_070_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -1351- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1353- MOVE '070-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("070-000-LER-TSISTEMA", FILLER_249.WABEND.PARAGRAFO);

            /*" -1359- PERFORM M_070_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            M_070_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -1362- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1363- DISPLAY 'SI0806B  - V1PARAMRAMO NAO ENCONTRADA' */
                _.Display($"SI0806B  - V1PARAMRAMO NAO ENCONTRADA");

                /*" -1363- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void M_070_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -1359- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, RAMO_SAUDE, RAMO_EDUCACAO INTO :PARAM-RAMO-VGAPC, :PARAM-RAMO-VG, :PARAM-RAMO-AP, :PARAM-RAMO-SAUDE, :PARAM-RAMO-EDUCACAO FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 = new M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAM_RAMO_VGAPC, PARAM_RAMO_VGAPC);
                _.Move(executed_1.PARAM_RAMO_VG, PARAM_RAMO_VG);
                _.Move(executed_1.PARAM_RAMO_AP, PARAM_RAMO_AP);
                _.Move(executed_1.PARAM_RAMO_SAUDE, PARAM_RAMO_SAUDE);
                _.Move(executed_1.PARAM_RAMO_EDUCACAO, PARAM_RAMO_EDUCACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-SECTION */
        private void M_090_000_CURSOR_TRELSIN_E_SECTION()
        {
            /*" -1377- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1379- MOVE '090-000-CURSOR-TRELSIN-E' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-TRELSIN-E", FILLER_249.WABEND.PARAGRAFO);

            /*" -1399- PERFORM M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELSIN_E_DB_DECLARE_1();

            /*" -1401- PERFORM M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1 */

            M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-E-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELSIN_E_DB_OPEN_1()
        {
            /*" -1401- EXEC SQL OPEN TRELSIN1 END-EXEC. */

            TRELSIN1.Open();

        }

        [StopWatch]
        /*" M-336-000-CURSOR-TAPDCORR-DB-DECLARE-1 */
        public void M_336_000_CURSOR_TAPDCORR_DB_DECLARE_1()
        {
            /*" -2029- EXEC SQL DECLARE TAPDCORR CURSOR FOR SELECT NUM_APOLICE, CODCORR, DTINIVIG, DTTERVIG FROM SEGUROS.V1APOLCORRET WHERE NUM_APOLICE = :MEST-NUM-APOL AND CODSUBES = :MEST-CODSUBES AND INDCRT = '1' AND DTINIVIG <= :MEST-DATCMD AND DTTERVIG >= :MEST-DATCMD ORDER BY NUM_APOLICE, CODCORR END-EXEC. */
            TAPDCORR = new SI0806B_TAPDCORR(true);
            string GetQuery_TAPDCORR()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODCORR
							, 
							DTINIVIG
							, DTTERVIG 
							FROM SEGUROS.V1APOLCORRET 
							WHERE NUM_APOLICE = '{MEST_NUM_APOL}' 
							AND CODSUBES = '{MEST_CODSUBES}' 
							AND INDCRT = '1' 
							AND DTINIVIG <= '{MEST_DATCMD}' 
							AND DTTERVIG >= '{MEST_DATCMD}' 
							ORDER BY NUM_APOLICE
							, CODCORR";

                return query;
            }
            TAPDCORR.GetQueryEvent += GetQuery_TAPDCORR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-E-SECTION */
        private void M_120_000_PROCESSA_E_SECTION()
        {
            /*" -1414- MOVE '120-000-PROCESSA-E' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA-E", FILLER_249.WABEND.PARAGRAFO);

            /*" -1416- MOVE '035' TO WNR-EXEC-SQL */
            _.Move("035", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1418- PERFORM 210-000-LER-THISTSIN-E. */

            M_210_000_LER_THISTSIN_E_SECTION();

            /*" -1419- IF THIST-SITUACAO NOT EQUAL '1' */

            if (THIST_SITUACAO != "1")
            {

                /*" -1420- PERFORM 150-000-LER-TRELSIN-E */

                M_150_000_LER_TRELSIN_E_SECTION();

                /*" -1422- GO TO 120-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                return;
            }


            /*" -1424- MOVE ZEROS TO WS-VLISS */
            _.Move(0, WRAMO48.WS_VLISS);

            /*" -1426- IF THIST-TIPFAV EQUAL '7' AND THIST-CODPSVI GREATER ZEROS */

            if (THIST_TIPFAV == "7" && THIST_CODPSVI > 00)
            {

                /*" -1427- PERFORM 215-000-LER-V1FORNECEDOR */

                M_215_000_LER_V1FORNECEDOR_SECTION();

                /*" -1430- COMPUTE WS-VLISS = (THIST-VALPRI * V1FORN-PCISS) / 100 */
                WRAMO48.WS_VLISS.Value = (THIST_VALPRI * V1FORN_PCISS) / 100f;

                /*" -1432- COMPUTE THIST-VALPRI = THIST-VALPRI - WS-VLISS */
                THIST_VALPRI.Value = THIST_VALPRI - WRAMO48.WS_VLISS;

                /*" -1435- MOVE THIST-VALPRI TO LC04-VALOR LC80-VALOR. */
                _.Move(THIST_VALPRI, W.LC04.LC04_VALOR, WRAMO48.LC80.LC80_VALOR);
            }


            /*" -1437- IF RELSIN-OPERACAO EQUAL 1001 OR 1002 OR 1003 OR 1004 */

            if (RELSIN_OPERACAO.In("1001", "1002", "1003", "1004"))
            {

                /*" -1439- PERFORM 255-000-LER-THISTSIN-9030. */

                M_255_000_LER_THISTSIN_9030_SECTION();
            }


            /*" -1440- IF THIST-APOL-SINI NOT = WSINISTRO-ANT */

            if (THIST_APOL_SINI != WRAMO48.WSINISTRO_ANT)
            {

                /*" -1442- PERFORM 300-000-LER-TMESTSIN-E */

                M_300_000_LER_TMESTSIN_E_SECTION();

                /*" -1443- MOVE RELSIN-FONTE TO WCOD-FONTE */
                _.Move(RELSIN_FONTE, WCOD_FONTE);

                /*" -1444- PERFORM 310-000-PESQ-TGEFONTE */

                M_310_000_PESQ_TGEFONTE_SECTION();

                /*" -1446- MOVE WNOME-FONTE TO LC02-NOMEFTE */
                _.Move(WRAMO48.WNOME_FONTE, W.LC02.LC02_NOMEFTE);

                /*" -1448- PERFORM 313-000-NOME-FONTE */

                M_313_000_NOME_FONTE_SECTION();

                /*" -1449- MOVE THIST-APOL-SINI TO WSINISTRO-ANT */
                _.Move(THIST_APOL_SINI, WRAMO48.WSINISTRO_ANT);

                /*" -1451- MOVE THIST-APOL-SINI TO WAUX-NUM-APOL */
                _.Move(THIST_APOL_SINI, WRAMO48.WAUX_NUM_APOL);

                /*" -1452- MOVE WRAMO TO MEST-RAMO. */
                _.Move(WRAMO48.FILLER_234.WRAMO, MEST_RAMO);
            }


            /*" -1453- PERFORM 350-000-PESQ-TGERAMO */

            M_350_000_PESQ_TGERAMO_SECTION();

            /*" -1454- PERFORM 355-000-PESQ-TCAUSA */

            M_355_000_PESQ_TCAUSA_SECTION();

            /*" -1455- PERFORM 356-000-VER-COSSEGURO */

            M_356_000_VER_COSSEGURO_SECTION();

            /*" -1456- MOVE WRAMO TO WRAMO-ANT */
            _.Move(WRAMO48.FILLER_234.WRAMO, WRAMO48.WRAMO_ANT);

            /*" -1457- PERFORM 330-000-LER-TAPOLICE */

            M_330_000_LER_TAPOLICE_SECTION();

            /*" -1458- PERFORM 335-000-LER-TENDOSSO */

            M_335_000_LER_TENDOSSO_SECTION();

            /*" -1459- PERFORM 336-000-CURSOR-TAPDCORR */

            M_336_000_CURSOR_TAPDCORR_SECTION();

            /*" -1461- PERFORM 340-000-LER-TAPDCORR. */

            M_340_000_LER_TAPDCORR_SECTION();

            /*" -1463- MOVE ZEROES TO WC-VAL3. */
            _.Move(0, WRAMO48.WC_VAL3);

            /*" -1465- PERFORM 800-000-LER-PREMIO-IOF. */

            M_800_000_LER_PREMIO_IOF_SECTION();

            /*" -1468- MOVE 0 TO WS-CONTADOR. */
            _.Move(0, WRAMO48.WS_CONTADOR);

            /*" -1470- PERFORM 360-000-IMPRIME. */

            M_360_000_IMPRIME_SECTION();

            /*" -1474- MOVE 0 TO WC-VAL1 WC-VAL2 WC-VAL3 */
            _.Move(0, WRAMO48.WC_VAL1, WRAMO48.WC_VAL2, WRAMO48.WC_VAL3);

            /*" -1475- MOVE 'N' TO WIMP-LC55. */
            _.Move("N", WRAMO48.WIMP_LC55);

            /*" -1477- ADD 1 TO IMPRES-EMISSAO. */
            WRAMO48.IMPRES_EMISSAO.Value = WRAMO48.IMPRES_EMISSAO + 1;

            /*" -1477- PERFORM 150-000-LER-TRELSIN-E. */

            M_150_000_LER_TRELSIN_E_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-E-SECTION */
        private void M_150_000_LER_TRELSIN_E_SECTION()
        {
            /*" -1491- MOVE '150-000-LER-TRELSIN-E' TO PARAGRAFO. */
            _.Move("150-000-LER-TRELSIN-E", FILLER_249.WABEND.PARAGRAFO);

            /*" -1493- MOVE '040' TO WNR-EXEC-SQL */
            _.Move("040", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1500- PERFORM M_150_000_LER_TRELSIN_E_DB_FETCH_1 */

            M_150_000_LER_TRELSIN_E_DB_FETCH_1();

            /*" -1503- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1503- PERFORM M_150_000_LER_TRELSIN_E_DB_CLOSE_1 */

                M_150_000_LER_TRELSIN_E_DB_CLOSE_1();

                /*" -1505- MOVE 'S' TO WFIM-TRELSIN1 */
                _.Move("S", WRAMO48.WFIM_TRELSIN1);

                /*" -1507- GO TO 150-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/ //GOTO
                return;
            }


            /*" -1508- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1510- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-E-DB-FETCH-1 */
        public void M_150_000_LER_TRELSIN_E_DB_FETCH_1()
        {
            /*" -1500- EXEC SQL FETCH TRELSIN1 INTO :RELSIN-APOL-SINI, :RELSIN-DTMOVTO, :RELSIN-OPERACAO, :RELSIN-OCORHIST, :RELSIN-FONTE, :MEST-MOEDA-SINI, :THIST-LIMCRR END-EXEC. */

            if (TRELSIN1.Fetch())
            {
                _.Move(TRELSIN1.RELSIN_APOL_SINI, RELSIN_APOL_SINI);
                _.Move(TRELSIN1.RELSIN_DTMOVTO, RELSIN_DTMOVTO);
                _.Move(TRELSIN1.RELSIN_OPERACAO, RELSIN_OPERACAO);
                _.Move(TRELSIN1.RELSIN_OCORHIST, RELSIN_OCORHIST);
                _.Move(TRELSIN1.RELSIN_FONTE, RELSIN_FONTE);
                _.Move(TRELSIN1.MEST_MOEDA_SINI, MEST_MOEDA_SINI);
                _.Move(TRELSIN1.THIST_LIMCRR, THIST_LIMCRR);
            }

        }

        [StopWatch]
        /*" M-150-000-LER-TRELSIN-E-DB-CLOSE-1 */
        public void M_150_000_LER_TRELSIN_E_DB_CLOSE_1()
        {
            /*" -1503- EXEC SQL CLOSE TRELSIN1 END-EXEC */

            TRELSIN1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-210-000-LER-THISTSIN-E-SECTION */
        private void M_210_000_LER_THISTSIN_E_SECTION()
        {
            /*" -1533- MOVE '210-000-LER-THISTSIN-E' TO PARAGRAFO. */
            _.Move("210-000-LER-THISTSIN-E", FILLER_249.WABEND.PARAGRAFO);

            /*" -1535- MOVE '045' TO WNR-EXEC-SQL. */
            _.Move("045", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1552- PERFORM M_210_000_LER_THISTSIN_E_DB_SELECT_1 */

            M_210_000_LER_THISTSIN_E_DB_SELECT_1();

            /*" -1555- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1556- DISPLAY 'SI0806B  - NAO HA REGISTRO NA THISTSIN' */
                _.Display($"SI0806B  - NAO HA REGISTRO NA THISTSIN");

                /*" -1559- DISPLAY 'APOLICE_SINISTRO = ' RELSIN-APOL-SINI ' DTMOVTO = ' RELSIN-DTMOVTO ' OPERACAO = ' RELSIN-OPERACAO ' OCORHIST = ' RELSIN-OCORHIST */

                $"APOLICE_SINISTRO = {RELSIN_APOL_SINI} DTMOVTO = {RELSIN_DTMOVTO} OPERACAO = {RELSIN_OPERACAO} OCORHIST = {RELSIN_OCORHIST}"
                .Display();

                /*" -1560- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1561- ELSE */
            }
            else
            {


                /*" -1562- MOVE THIST-APOL-SINI TO LC01-SINISTRO */
                _.Move(THIST_APOL_SINI, W.LC01.LC01_SINISTRO);

                /*" -1563- MOVE THIST-NOMFAV TO LC03-NOMFAV */
                _.Move(THIST_NOMFAV, W.LC03.LC03_NOMFAV);

                /*" -1564- MOVE THIST-VALPRI TO LC54-INDENIZ WC-VAL1. */
                _.Move(THIST_VALPRI, W.LC54.LC54_INDENIZ, WRAMO48.WC_VAL1);
            }


        }

        [StopWatch]
        /*" M-210-000-LER-THISTSIN-E-DB-SELECT-1 */
        public void M_210_000_LER_THISTSIN_E_DB_SELECT_1()
        {
            /*" -1552- EXEC SQL SELECT NUM_APOL_SINISTRO, VAL_OPERACAO, DTMOVTO, NOMFAV, SITUACAO, TIPFAV, FONPAG, CODPSVI INTO :THIST-APOL-SINI, :THIST-VALPRI, :THIST-DTMOVTO, :THIST-NOMFAV, :THIST-SITUACAO, :THIST-TIPFAV, :THIST-FONPAG, :THIST-CODPSVI FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND OPERACAO = :RELSIN-OPERACAO AND DTMOVTO = :RELSIN-DTMOVTO AND OCORHIST = :RELSIN-OCORHIST END-EXEC. */

            var m_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1 = new M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
                RELSIN_OPERACAO = RELSIN_OPERACAO.ToString(),
                RELSIN_OCORHIST = RELSIN_OCORHIST.ToString(),
                RELSIN_DTMOVTO = RELSIN_DTMOVTO.ToString(),
            };

            var executed_1 = M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1.Execute(m_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_APOL_SINI, THIST_APOL_SINI);
                _.Move(executed_1.THIST_VALPRI, THIST_VALPRI);
                _.Move(executed_1.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(executed_1.THIST_NOMFAV, THIST_NOMFAV);
                _.Move(executed_1.THIST_SITUACAO, THIST_SITUACAO);
                _.Move(executed_1.THIST_TIPFAV, THIST_TIPFAV);
                _.Move(executed_1.THIST_FONPAG, THIST_FONPAG);
                _.Move(executed_1.THIST_CODPSVI, THIST_CODPSVI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-215-000-LER-V1FORNECEDOR-SECTION */
        private void M_215_000_LER_V1FORNECEDOR_SECTION()
        {
            /*" -1579- MOVE '215-000-LER-V1FORNECEDOR' TO PARAGRAFO. */
            _.Move("215-000-LER-V1FORNECEDOR", FILLER_249.WABEND.PARAGRAFO);

            /*" -1581- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1586- PERFORM M_215_000_LER_V1FORNECEDOR_DB_SELECT_1 */

            M_215_000_LER_V1FORNECEDOR_DB_SELECT_1();

            /*" -1589- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1590- DISPLAY 'SI0806B - NAO HA REGISTRO (V1FORNECEDOR) ... ' */
                _.Display($"SI0806B - NAO HA REGISTRO (V1FORNECEDOR) ... ");

                /*" -1591- DISPLAY 'CLIFOR = ' THIST-CODPSVI */
                _.Display($"CLIFOR = {THIST_CODPSVI}");

                /*" -1593- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1595- DISPLAY 'SI0806B - PROBLEMAS SELECT (V1FORNECEDOR) ... ' */
                _.Display($"SI0806B - PROBLEMAS SELECT (V1FORNECEDOR) ... ");

                /*" -1596- DISPLAY 'CLIFOR = ' THIST-CODPSVI */
                _.Display($"CLIFOR = {THIST_CODPSVI}");

                /*" -1596- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-215-000-LER-V1FORNECEDOR-DB-SELECT-1 */
        public void M_215_000_LER_V1FORNECEDOR_DB_SELECT_1()
        {
            /*" -1586- EXEC SQL SELECT PCDESISS INTO :V1FORN-PCISS FROM SEGUROS.V1FORNECEDOR WHERE CLIFOR = :THIST-CODPSVI END-EXEC. */

            var m_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1 = new M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1()
            {
                THIST_CODPSVI = THIST_CODPSVI.ToString(),
            };

            var executed_1 = M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1.Execute(m_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FORN_PCISS, V1FORN_PCISS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_215_999_EXIT*/

        [StopWatch]
        /*" M-255-000-LER-THISTSIN-9030-SECTION */
        private void M_255_000_LER_THISTSIN_9030_SECTION()
        {
            /*" -1614- MOVE '255-000-LER-THISTSIN-9030' TO PARAGRAFO. */
            _.Move("255-000-LER-THISTSIN-9030", FILLER_249.WABEND.PARAGRAFO);

            /*" -1616- MOVE '055' TO WNR-EXEC-SQL. */
            _.Move("055", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1624- PERFORM M_255_000_LER_THISTSIN_9030_DB_SELECT_1 */

            M_255_000_LER_THISTSIN_9030_DB_SELECT_1();

            /*" -1627- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1629- MOVE THIST-VALPRI1 TO LC55-ADIANT WC-VAL2 */
                _.Move(THIST_VALPRI1, W.LC55.LC55_ADIANT, WRAMO48.WC_VAL2);

                /*" -1631- MOVE 'S' TO WIMP-LC55 */
                _.Move("S", WRAMO48.WIMP_LC55);

                /*" -1632- COMPUTE WC-TOTAL = WC-VAL1 - WC-VAL2 */
                WRAMO48.WC_TOTAL.Value = WRAMO48.WC_VAL1 - WRAMO48.WC_VAL2;

                /*" -1632- MOVE WC-TOTAL TO LC57-TOTAL. */
                _.Move(WRAMO48.WC_TOTAL, W.LC57.LC57_TOTAL);
            }


        }

        [StopWatch]
        /*" M-255-000-LER-THISTSIN-9030-DB-SELECT-1 */
        public void M_255_000_LER_THISTSIN_9030_DB_SELECT_1()
        {
            /*" -1624- EXEC SQL SELECT VAL_OPERACAO INTO :THIST-VALPRI1 FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :THIST-APOL-SINI AND OPERACAO = 9030 AND OCORHIST = :RELSIN-OCORHIST END-EXEC. */

            var m_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1 = new M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1()
            {
                THIST_APOL_SINI = THIST_APOL_SINI.ToString(),
                RELSIN_OCORHIST = RELSIN_OCORHIST.ToString(),
            };

            var executed_1 = M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1.Execute(m_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_VALPRI1, THIST_VALPRI1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_255_999_EXIT*/

        [StopWatch]
        /*" M-300-000-LER-TMESTSIN-E-SECTION */
        private void M_300_000_LER_TMESTSIN_E_SECTION()
        {
            /*" -1646- MOVE '300-000-LER-TMESTSIN' TO PARAGRAFO. */
            _.Move("300-000-LER-TMESTSIN", FILLER_249.WABEND.PARAGRAFO);

            /*" -1648- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1666- PERFORM M_300_000_LER_TMESTSIN_E_DB_SELECT_1 */

            M_300_000_LER_TMESTSIN_E_DB_SELECT_1();

            /*" -1669- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1671- DISPLAY 'SI0806B - NAO HA REGISTRO NA TMESTSIN CORRESPOND 'NTE AO TRELSIN - EMISSAO' */

                $"SI0806B - NAO HA REGISTRO NA TMESTSIN CORRESPOND NTEAOTRELSIN-EMISSAO"
                .Display();

                /*" -1672- DISPLAY 'APOLICE_SINISTRO = ' RELSIN-APOL-SINI */
                _.Display($"APOLICE_SINISTRO = {RELSIN_APOL_SINI}");

                /*" -1673- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1674- ELSE */
            }
            else
            {


                /*" -1676- MOVE MEST-NUM-APOL TO LC04-APOLICE LC76-APOLICE */
                _.Move(MEST_NUM_APOL, W.LC04.LC04_APOLICE, WRAMO48.LC76.LC76_APOLICE);

                /*" -1677- MOVE MEST-NRENDOS TO LC04-NRENDOS */
                _.Move(MEST_NRENDOS, W.LC04.LC04_NRENDOS);

                /*" -1678- MOVE MEST-NRCERTIF TO LC04-NRCERTIF */
                _.Move(MEST_NRCERTIF, W.LC04.LC04_ITEM.LC04_NRCERTIF);

                /*" -1679- MOVE MEST-DATORR TO WDATA-R */
                _.Move(MEST_DATORR, WRAMO48.WDATA_R);

                /*" -1681- MOVE WDATA-DD TO LC04-DD-OC LC80-DD-OC */
                _.Move(WRAMO48.WDATA.WDATA_DD, W.LC04.LC04_DATA_OCORR.LC04_DD_OC, WRAMO48.LC80.LC80_DATA_OCORR.LC80_DD_OC);

                /*" -1683- MOVE WDATA-MM TO LC04-MM-OC LC80-MM-OC */
                _.Move(WRAMO48.WDATA.WDATA_MM, W.LC04.LC04_DATA_OCORR.LC04_MM_OC, WRAMO48.LC80.LC80_DATA_OCORR.LC80_MM_OC);

                /*" -1684- MOVE WDATA-AA TO LC04-AA-OC LC80-AA-OC. */
                _.Move(WRAMO48.WDATA.WDATA_AA, W.LC04.LC04_DATA_OCORR.LC04_AA_OC, WRAMO48.LC80.LC80_DATA_OCORR.LC80_AA_OC);
            }


        }

        [StopWatch]
        /*" M-300-000-LER-TMESTSIN-E-DB-SELECT-1 */
        public void M_300_000_LER_TMESTSIN_E_DB_SELECT_1()
        {
            /*" -1666- EXEC SQL SELECT NUM_APOLICE, SINLID, NRENDOS, NRCERTIF, DIGCERT, IDTPSEGU, DATORR, CODSUBES, CODCAU, COD_MOEDA_SINI, DATCMD INTO :MEST-NUM-APOL, :MEST-SINLID, :MEST-NRENDOS, :MEST-NRCERTIF, :MEST-DIGCERT, :MEST-IDTPSEGU, :MEST-DATORR, :MEST-CODSUBES, :MEST-CODCAU, :MEST-MOEDA-SINI, :MEST-DATCMD FROM SEGUROS.V1MESTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI END-EXEC. */

            var m_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1 = new M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1.Execute(m_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MEST_NUM_APOL, MEST_NUM_APOL);
                _.Move(executed_1.MEST_SINLID, MEST_SINLID);
                _.Move(executed_1.MEST_NRENDOS, MEST_NRENDOS);
                _.Move(executed_1.MEST_NRCERTIF, MEST_NRCERTIF);
                _.Move(executed_1.MEST_DIGCERT, MEST_DIGCERT);
                _.Move(executed_1.MEST_IDTPSEGU, MEST_IDTPSEGU);
                _.Move(executed_1.MEST_DATORR, MEST_DATORR);
                _.Move(executed_1.MEST_CODSUBES, MEST_CODSUBES);
                _.Move(executed_1.MEST_CODCAU, MEST_CODCAU);
                _.Move(executed_1.MEST_MOEDA_SINI, MEST_MOEDA_SINI);
                _.Move(executed_1.MEST_DATCMD, MEST_DATCMD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-310-000-PESQ-TGEFONTE-SECTION */
        private void M_310_000_PESQ_TGEFONTE_SECTION()
        {
            /*" -1698- SET I02 TO WZEROS. */
            I02.Value = WRAMO48.WZEROS;

            /*" -1699- MOVE '310-000-PESQ-TGEFONTE' TO PARAGRAFO. */
            _.Move("310-000-PESQ-TGEFONTE", FILLER_249.WABEND.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM M_310_100_LOOP */

            M_310_100_LOOP();

        }

        [StopWatch]
        /*" M-310-100-LOOP */
        private void M_310_100_LOOP(bool isPerform = false)
        {
            /*" -1705- SET I02 UP BY WHUM. */
            I02.Value += WRAMO48.WHUM;

            /*" -1707- IF I02 GREATER 200 */

            if (I02 > 200)
            {

                /*" -1708- DISPLAY 'SI0806B  - ESTOURO DE TABELA INTERNA DE FONTE' */
                _.Display($"SI0806B  - ESTOURO DE TABELA INTERNA DE FONTE");

                /*" -1711- GO TO 310-200-ACESSA-TGEFONTE. */

                M_310_200_ACESSA_TGEFONTE(); //GOTO
                return;
            }


            /*" -1712- IF WTABG-NOMEFTE (I02) EQUAL SPACES */

            if (FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I02].WTABG_NOMEFTE == string.Empty)
            {

                /*" -1715- GO TO 310-200-ACESSA-TGEFONTE. */

                M_310_200_ACESSA_TGEFONTE(); //GOTO
                return;
            }


            /*" -1716- IF WCOD-FONTE EQUAL WTABG-FONTE (I02) */

            if (WCOD_FONTE == FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I02].WTABG_FONTE)
            {

                /*" -1719- MOVE WTABG-NOMEFTE (I02) TO WNOME-FONTE */
                _.Move(FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I02].WTABG_NOMEFTE, WRAMO48.WNOME_FONTE);

                /*" -1720- GO TO 310-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_999_EXIT*/ //GOTO
                return;

                /*" -1721- ELSE */
            }
            else
            {


                /*" -1721- GO TO 310-100-LOOP. */
                new Task(() => M_310_100_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" M-310-200-ACESSA-TGEFONTE */
        private void M_310_200_ACESSA_TGEFONTE(bool isPerform = false)
        {
            /*" -1728- MOVE '065' TO WNR-EXEC-SQL. */
            _.Move("065", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1731- MOVE '310-200-ACESSA-TGEFONTE' TO PARAGRAFO. */
            _.Move("310-200-ACESSA-TGEFONTE", FILLER_249.WABEND.PARAGRAFO);

            /*" -1736- PERFORM M_310_200_ACESSA_TGEFONTE_DB_SELECT_1 */

            M_310_200_ACESSA_TGEFONTE_DB_SELECT_1();

            /*" -1739- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1740- DISPLAY 'SI0806B -FONTE NAO CADASTRADO' */
                _.Display($"SI0806B -FONTE NAO CADASTRADO");

                /*" -1741- DISPLAY 'FONTE    = ' WCOD-FONTE */
                _.Display($"FONTE    = {WCOD_FONTE}");

                /*" -1742- ELSE */
            }
            else
            {


                /*" -1743- IF I02 NOT GREATER 200 */

                if (I02 <= 200)
                {

                    /*" -1744- MOVE WCOD-FONTE TO WTABG-FONTE (I02) */
                    _.Move(WCOD_FONTE, FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I02].WTABG_FONTE);

                    /*" -1746- MOVE GEFONTE-NOMEFTE TO WTABG-NOMEFTE (I02). */
                    _.Move(GEFONTE_NOMEFTE, FILLER_249.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I02].WTABG_NOMEFTE);
                }

            }


            /*" -1746- MOVE GEFONTE-NOMEFTE TO WNOME-FONTE. */
            _.Move(GEFONTE_NOMEFTE, WRAMO48.WNOME_FONTE);

        }

        [StopWatch]
        /*" M-310-200-ACESSA-TGEFONTE-DB-SELECT-1 */
        public void M_310_200_ACESSA_TGEFONTE_DB_SELECT_1()
        {
            /*" -1736- EXEC SQL SELECT NOMEFTE INTO :GEFONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :WCOD-FONTE END-EXEC. */

            var m_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1 = new M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1()
            {
                WCOD_FONTE = WCOD_FONTE.ToString(),
            };

            var executed_1 = M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1.Execute(m_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEFONTE_NOMEFTE, GEFONTE_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_999_EXIT*/

        [StopWatch]
        /*" M-313-000-NOME-FONTE-SECTION */
        private void M_313_000_NOME_FONTE_SECTION()
        {
            /*" -1757- MOVE '313-000-NOME-FONTE  ' TO PARAGRAFO. */
            _.Move("313-000-NOME-FONTE  ", FILLER_249.WABEND.PARAGRAFO);

            /*" -1759- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1767- PERFORM M_313_000_NOME_FONTE_DB_SELECT_1 */

            M_313_000_NOME_FONTE_DB_SELECT_1();

            /*" -1770- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1771- DISPLAY 'SI0806B  - FONTE NAO ENCONTRADA' */
                _.Display($"SI0806B  - FONTE NAO ENCONTRADA");

                /*" -1772- DISPLAY 'NUM-APOLICE = ' MEST-NUM-APOL */
                _.Display($"NUM-APOLICE = {MEST_NUM_APOL}");

                /*" -1774- MOVE SPACES TO GEFONTE-CIDADE. */
                _.Move("", GEFONTE_CIDADE);
            }


            /*" -1774- MOVE GEFONTE-CIDADE TO LC58A-FONTE. */
            _.Move(GEFONTE_CIDADE, W.LC58A.LC58A_FONTE);

        }

        [StopWatch]
        /*" M-313-000-NOME-FONTE-DB-SELECT-1 */
        public void M_313_000_NOME_FONTE_DB_SELECT_1()
        {
            /*" -1767- EXEC SQL SELECT CIDADE INTO :GEFONTE-CIDADE FROM SEGUROS.V1FONTE WHERE FONTE = :THIST-FONPAG END-EXEC. */

            var m_313_000_NOME_FONTE_DB_SELECT_1_Query1 = new M_313_000_NOME_FONTE_DB_SELECT_1_Query1()
            {
                THIST_FONPAG = THIST_FONPAG.ToString(),
            };

            var executed_1 = M_313_000_NOME_FONTE_DB_SELECT_1_Query1.Execute(m_313_000_NOME_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEFONTE_CIDADE, GEFONTE_CIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_313_999_EXIT*/

        [StopWatch]
        /*" M-330-000-LER-TAPOLICE-SECTION */
        private void M_330_000_LER_TAPOLICE_SECTION()
        {
            /*" -1787- MOVE '330-000-LER-TAPOLICE' TO PARAGRAFO. */
            _.Move("330-000-LER-TAPOLICE", FILLER_249.WABEND.PARAGRAFO);

            /*" -1789- MOVE '075' TO WNR-EXEC-SQL. */
            _.Move("075", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1800- PERFORM M_330_000_LER_TAPOLICE_DB_SELECT_1 */

            M_330_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -1803- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1804- DISPLAY 'SI0806B  - SEGURADO NAO ENCONTRADO' */
                _.Display($"SI0806B  - SEGURADO NAO ENCONTRADO");

                /*" -1805- DISPLAY 'NUM-APOLICE = ' MEST-NUM-APOL */
                _.Display($"NUM-APOLICE = {MEST_NUM_APOL}");

                /*" -1806- MOVE SPACES TO LC02-NOME */
                _.Move("", W.LC02.LC02_NOME);

                /*" -1807- ELSE */
            }
            else
            {


                /*" -1809- MOVE APOL-NOME TO LC02-NOME. */
                _.Move(APOL_NOME, W.LC02.LC02_NOME);
            }


            /*" -1820- IF WRAMO EQUAL PARAM-RAMO-VGAPC OR WRAMO EQUAL PARAM-RAMO-VG OR WRAMO EQUAL PARAM-RAMO-AP OR WRAMO EQUAL PARAM-RAMO-SAUDE OR WRAMO EQUAL PARAM-RAMO-EDUCACAO */

            if (WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_VGAPC || WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_VG || WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_AP || WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_SAUDE || WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_EDUCACAO)
            {

                /*" -1823- IF WRAMO EQUAL PARAM-RAMO-AP AND MEST-NRCERTIF EQUAL ZEROES AND MEST-IDTPSEGU EQUAL ' ' */

                if (WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_AP && MEST_NRCERTIF == 00 && MEST_IDTPSEGU == " ")
                {

                    /*" -1824- PERFORM 331-000-LER-SINIITEM */

                    M_331_000_LER_SINIITEM_SECTION();

                    /*" -1825- ELSE */
                }
                else
                {


                    /*" -1826- PERFORM 332-000-LER-SEGURAVG */

                    M_332_000_LER_SEGURAVG_SECTION();

                    /*" -1827- ELSE */
                }

            }
            else
            {


                /*" -1828- IF WRAMO NOT EQUAL 32 */

                if (WRAMO48.FILLER_234.WRAMO != 32)
                {

                    /*" -1829- PERFORM 331-000-LER-SINIITEM */

                    M_331_000_LER_SINIITEM_SECTION();

                    /*" -1830- ELSE */
                }
                else
                {


                    /*" -1830- PERFORM 333-000-LER-APOLICE. */

                    M_333_000_LER_APOLICE_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-330-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_330_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -1800- EXEC SQL SELECT NOME INTO :APOL-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :MEST-NUM-APOL END-EXEC */

            var m_330_000_LER_TAPOLICE_DB_SELECT_1_Query1 = new M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
            };

            var executed_1 = M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1.Execute(m_330_000_LER_TAPOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_NOME, APOL_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-331-000-LER-SINIITEM-SECTION */
        private void M_331_000_LER_SINIITEM_SECTION()
        {
            /*" -1839- MOVE '331-000-LER-SINIITEM ' TO PARAGRAFO. */
            _.Move("331-000-LER-SINIITEM ", FILLER_249.WABEND.PARAGRAFO);

            /*" -1841- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1843- IF MEST-IDTPSEGU EQUAL '8' OR MEST-IDTPSEGU EQUAL '9' */

            if (MEST_IDTPSEGU == "8" || MEST_IDTPSEGU == "9")
            {

                /*" -1845- MOVE '1' TO MEST-IDTPSEGU. */
                _.Move("1", MEST_IDTPSEGU);
            }


            /*" -1853- PERFORM M_331_000_LER_SINIITEM_DB_SELECT_1 */

            M_331_000_LER_SINIITEM_DB_SELECT_1();

            /*" -1856- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1857- DISPLAY 'SI0806B  - V1SINI_ITEM NAO ENCONTRADA' */
                _.Display($"SI0806B  - V1SINI_ITEM NAO ENCONTRADA");

                /*" -1858- DISPLAY 'NUM-APOL-SINISTRO = ' MEST-NUM-APOL */
                _.Display($"NUM-APOL-SINISTRO = {MEST_NUM_APOL}");

                /*" -1859- MOVE 'NAO CADASTRADO-VG' TO LC02-NOME */
                _.Move("NAO CADASTRADO-VG", W.LC02.LC02_NOME);

                /*" -1860- MOVE 0 TO V1SEGVG-CLIENTE */
                _.Move(0, V1SEGVG_CLIENTE);

                /*" -1862- GO TO 331-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_331_999_EXIT*/ //GOTO
                return;
            }


            /*" -1862- PERFORM 334-000-LER-CLIENTE. */

            M_334_000_LER_CLIENTE_SECTION();

        }

        [StopWatch]
        /*" M-331-000-LER-SINIITEM-DB-SELECT-1 */
        public void M_331_000_LER_SINIITEM_DB_SELECT_1()
        {
            /*" -1853- EXEC SQL SELECT COD_CLIENTE INTO :V1SEGVG-CLIENTE FROM SEGUROS.V1SINI_ITEM WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI END-EXEC. */

            var m_331_000_LER_SINIITEM_DB_SELECT_1_Query1 = new M_331_000_LER_SINIITEM_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_331_000_LER_SINIITEM_DB_SELECT_1_Query1.Execute(m_331_000_LER_SINIITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGVG_CLIENTE, V1SEGVG_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_331_999_EXIT*/

        [StopWatch]
        /*" M-332-000-LER-SEGURAVG-SECTION */
        private void M_332_000_LER_SEGURAVG_SECTION()
        {
            /*" -1873- MOVE '332-000-LER-SEGURAVG ' TO PARAGRAFO. */
            _.Move("332-000-LER-SEGURAVG ", FILLER_249.WABEND.PARAGRAFO);

            /*" -1875- MOVE '085' TO WNR-EXEC-SQL. */
            _.Move("085", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1877- IF MEST-IDTPSEGU EQUAL '8' OR MEST-IDTPSEGU EQUAL '9' */

            if (MEST_IDTPSEGU == "8" || MEST_IDTPSEGU == "9")
            {

                /*" -1879- MOVE '1' TO MEST-IDTPSEGU. */
                _.Move("1", MEST_IDTPSEGU);
            }


            /*" -1890- PERFORM M_332_000_LER_SEGURAVG_DB_SELECT_1 */

            M_332_000_LER_SEGURAVG_DB_SELECT_1();

            /*" -1893- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1894- DISPLAY 'SI0806B  - V1SEGURAVG NAO ENCONTRADA' */
                _.Display($"SI0806B  - V1SEGURAVG NAO ENCONTRADA");

                /*" -1895- DISPLAY 'NUM-APOLICE     = ' MEST-NUM-APOL */
                _.Display($"NUM-APOLICE     = {MEST_NUM_APOL}");

                /*" -1896- DISPLAY 'TIPO-SEGURADO   = ' MEST-IDTPSEGU */
                _.Display($"TIPO-SEGURADO   = {MEST_IDTPSEGU}");

                /*" -1897- DISPLAY 'NUM-CERTIFICADO = ' MEST-NRCERTIF */
                _.Display($"NUM-CERTIFICADO = {MEST_NRCERTIF}");

                /*" -1898- DISPLAY 'COD-SUBGRUPO    = ' MEST-CODSUBES */
                _.Display($"COD-SUBGRUPO    = {MEST_CODSUBES}");

                /*" -1899- MOVE 'NAO CADASTRADO-VG' TO LC02-NOME */
                _.Move("NAO CADASTRADO-VG", W.LC02.LC02_NOME);

                /*" -1900- MOVE 0 TO V1SEGVG-CLIENTE */
                _.Move(0, V1SEGVG_CLIENTE);

                /*" -1902- GO TO 332-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_332_999_EXIT*/ //GOTO
                return;
            }


            /*" -1902- PERFORM 334-000-LER-CLIENTE. */

            M_334_000_LER_CLIENTE_SECTION();

        }

        [StopWatch]
        /*" M-332-000-LER-SEGURAVG-DB-SELECT-1 */
        public void M_332_000_LER_SEGURAVG_DB_SELECT_1()
        {
            /*" -1890- EXEC SQL SELECT COD_CLIENTE INTO :V1SEGVG-CLIENTE FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :MEST-NUM-APOL AND TIPO_SEGURADO = :MEST-IDTPSEGU AND NUM_CERTIFICADO = :MEST-NRCERTIF AND COD_SUBGRUPO = :MEST-CODSUBES END-EXEC. */

            var m_332_000_LER_SEGURAVG_DB_SELECT_1_Query1 = new M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_IDTPSEGU = MEST_IDTPSEGU.ToString(),
                MEST_NRCERTIF = MEST_NRCERTIF.ToString(),
                MEST_CODSUBES = MEST_CODSUBES.ToString(),
            };

            var executed_1 = M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1.Execute(m_332_000_LER_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGVG_CLIENTE, V1SEGVG_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_332_999_EXIT*/

        [StopWatch]
        /*" M-333-000-LER-APOLICE-SECTION */
        private void M_333_000_LER_APOLICE_SECTION()
        {
            /*" -1913- MOVE '333-000-LER-APOLICE ' TO PARAGRAFO. */
            _.Move("333-000-LER-APOLICE ", FILLER_249.WABEND.PARAGRAFO);

            /*" -1915- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1917- IF MEST-IDTPSEGU EQUAL '8' OR MEST-IDTPSEGU EQUAL '9' */

            if (MEST_IDTPSEGU == "8" || MEST_IDTPSEGU == "9")
            {

                /*" -1919- MOVE '1' TO MEST-IDTPSEGU. */
                _.Move("1", MEST_IDTPSEGU);
            }


            /*" -1927- PERFORM M_333_000_LER_APOLICE_DB_SELECT_1 */

            M_333_000_LER_APOLICE_DB_SELECT_1();

            /*" -1930- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1931- DISPLAY 'SI0806B  - V1APOLICE NAO ENCONTRADA' */
                _.Display($"SI0806B  - V1APOLICE NAO ENCONTRADA");

                /*" -1932- DISPLAY 'NUM-APOLICE     = ' MEST-NUM-APOL */
                _.Display($"NUM-APOLICE     = {MEST_NUM_APOL}");

                /*" -1933- MOVE 'NAO CADASTRADO-VG' TO LC02-NOME */
                _.Move("NAO CADASTRADO-VG", W.LC02.LC02_NOME);

                /*" -1934- MOVE 0 TO V1SEGVG-CLIENTE */
                _.Move(0, V1SEGVG_CLIENTE);

                /*" -1936- GO TO 333-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_333_999_EXIT*/ //GOTO
                return;
            }


            /*" -1936- PERFORM 334-000-LER-CLIENTE. */

            M_334_000_LER_CLIENTE_SECTION();

        }

        [StopWatch]
        /*" M-333-000-LER-APOLICE-DB-SELECT-1 */
        public void M_333_000_LER_APOLICE_DB_SELECT_1()
        {
            /*" -1927- EXEC SQL SELECT CODCLIEN INTO :V1SEGVG-CLIENTE FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :MEST-NUM-APOL END-EXEC. */

            var m_333_000_LER_APOLICE_DB_SELECT_1_Query1 = new M_333_000_LER_APOLICE_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
            };

            var executed_1 = M_333_000_LER_APOLICE_DB_SELECT_1_Query1.Execute(m_333_000_LER_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGVG_CLIENTE, V1SEGVG_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_333_999_EXIT*/

        [StopWatch]
        /*" M-334-000-LER-CLIENTE-SECTION */
        private void M_334_000_LER_CLIENTE_SECTION()
        {
            /*" -1945- MOVE '334-000-LER-CLIENTE  ' TO PARAGRAFO. */
            _.Move("334-000-LER-CLIENTE  ", FILLER_249.WABEND.PARAGRAFO);

            /*" -1947- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1954- PERFORM M_334_000_LER_CLIENTE_DB_SELECT_1 */

            M_334_000_LER_CLIENTE_DB_SELECT_1();

            /*" -1958- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1959- DISPLAY 'SI0806B  - V1CLIENTE NAO ENCONTRADA' */
                _.Display($"SI0806B  - V1CLIENTE NAO ENCONTRADA");

                /*" -1960- DISPLAY 'NUM-APOLICE = ' MEST-NUM-APOL */
                _.Display($"NUM-APOLICE = {MEST_NUM_APOL}");

                /*" -1961- DISPLAY 'RAMO        = ' WRAMO */
                _.Display($"RAMO        = {WRAMO48.FILLER_234.WRAMO}");

                /*" -1962- DISPLAY 'COD-CLIENTE = ' V1SEGVG-CLIENTE */
                _.Display($"COD-CLIENTE = {V1SEGVG_CLIENTE}");

                /*" -1963- MOVE 'NAO CADASTRADO-CLI' TO LC02-NOME */
                _.Move("NAO CADASTRADO-CLI", W.LC02.LC02_NOME);

                /*" -1965- GO TO 334-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_334_999_EXIT*/ //GOTO
                return;
            }


            /*" -1965- MOVE V1CLI-NOME-RAZAO TO LC02-NOME. */
            _.Move(V1CLI_NOME_RAZAO, W.LC02.LC02_NOME);

        }

        [StopWatch]
        /*" M-334-000-LER-CLIENTE-DB-SELECT-1 */
        public void M_334_000_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1954- EXEC SQL SELECT NOME_RAZAO INTO :V1CLI-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :V1SEGVG-CLIENTE END-EXEC. */

            var m_334_000_LER_CLIENTE_DB_SELECT_1_Query1 = new M_334_000_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                V1SEGVG_CLIENTE = V1SEGVG_CLIENTE.ToString(),
            };

            var executed_1 = M_334_000_LER_CLIENTE_DB_SELECT_1_Query1.Execute(m_334_000_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLI_NOME_RAZAO, V1CLI_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_334_999_EXIT*/

        [StopWatch]
        /*" M-335-000-LER-TENDOSSO-SECTION */
        private void M_335_000_LER_TENDOSSO_SECTION()
        {
            /*" -1980- MOVE '335-000-LER-TENDOSSO' TO PARAGRAFO. */
            _.Move("335-000-LER-TENDOSSO", FILLER_249.WABEND.PARAGRAFO);

            /*" -1982- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -1991- PERFORM M_335_000_LER_TENDOSSO_DB_SELECT_1 */

            M_335_000_LER_TENDOSSO_DB_SELECT_1();

            /*" -1994- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1995- DISPLAY 'SI0806B  - ENDOSSO NAO ENCONTRADO NA TENDOSSO' */
                _.Display($"SI0806B  - ENDOSSO NAO ENCONTRADO NA TENDOSSO");

                /*" -1998- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL ' NRENDOS = ' MEST-NRENDOS */

                $"NUM_APOLICE = {MEST_NUM_APOL} NRENDOS = {MEST_NRENDOS}"
                .Display();

                /*" -1999- ELSE */
            }
            else
            {


                /*" -1999- MOVE ENDOSSO-FONTE TO RELSIN-FONTE. */
                _.Move(ENDOSSO_FONTE, RELSIN_FONTE);
            }


        }

        [StopWatch]
        /*" M-335-000-LER-TENDOSSO-DB-SELECT-1 */
        public void M_335_000_LER_TENDOSSO_DB_SELECT_1()
        {
            /*" -1991- EXEC SQL SELECT FONTE INTO :ENDOSSO-FONTE FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :MEST-NUM-APOL AND NRENDOS = :MEST-NRENDOS END-EXEC. */

            var m_335_000_LER_TENDOSSO_DB_SELECT_1_Query1 = new M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_NRENDOS = MEST_NRENDOS.ToString(),
            };

            var executed_1 = M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1.Execute(m_335_000_LER_TENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSO_FONTE, ENDOSSO_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_335_999_EXIT*/

        [StopWatch]
        /*" M-336-000-CURSOR-TAPDCORR-SECTION */
        private void M_336_000_CURSOR_TAPDCORR_SECTION()
        {
            /*" -2015- MOVE '336-000-CURSOR-TAPDCORR' TO PARAGRAFO */
            _.Move("336-000-CURSOR-TAPDCORR", FILLER_249.WABEND.PARAGRAFO);

            /*" -2017- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2029- PERFORM M_336_000_CURSOR_TAPDCORR_DB_DECLARE_1 */

            M_336_000_CURSOR_TAPDCORR_DB_DECLARE_1();

            /*" -2031- PERFORM M_336_000_CURSOR_TAPDCORR_DB_OPEN_1 */

            M_336_000_CURSOR_TAPDCORR_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-336-000-CURSOR-TAPDCORR-DB-OPEN-1 */
        public void M_336_000_CURSOR_TAPDCORR_DB_OPEN_1()
        {
            /*" -2031- EXEC SQL OPEN TAPDCORR END-EXEC. */

            TAPDCORR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_336_999_EXIT*/

        [StopWatch]
        /*" M-340-000-LER-TAPDCORR-SECTION */
        private void M_340_000_LER_TAPDCORR_SECTION()
        {
            /*" -2043- MOVE '340-000-LER-TAPDCORR' TO PARAGRAFO. */
            _.Move("340-000-LER-TAPDCORR", FILLER_249.WABEND.PARAGRAFO);

            /*" -2045- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2050- PERFORM M_340_000_LER_TAPDCORR_DB_FETCH_1 */

            M_340_000_LER_TAPDCORR_DB_FETCH_1();

            /*" -2053- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2054- DISPLAY 'SI0806B  - REGISTRO NAO ENCONTRADO NA TAPDCORR' */
                _.Display($"SI0806B  - REGISTRO NAO ENCONTRADO NA TAPDCORR");

                /*" -2058- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL ' CODSUBES ' MEST-CODSUBES ' NRENDOS ' MEST-NRENDOS */

                $"NUM_APOLICE = {MEST_NUM_APOL} CODSUBES {MEST_CODSUBES} NRENDOS {MEST_NRENDOS}"
                .Display();

                /*" -2059- MOVE ZEROS TO LC58-CODPDT */
                _.Move(0, W.LC58.LC58_CODPDT);

                /*" -2060- MOVE SPACES TO LC58-NOMPDT */
                _.Move("", W.LC58.LC58_NOMPDT);

                /*" -2061- MOVE SPACES TO LC58-TRACO */
                _.Move("", W.LC58.LC58_TRACO);

                /*" -2062- ELSE */
            }
            else
            {


                /*" -2063- MOVE APDCORR-CODCORR TO LC58-CODPDT */
                _.Move(APDCORR_CODCORR, W.LC58.LC58_CODPDT);

                /*" -2064- MOVE ' -' TO LC58-TRACO */
                _.Move(" -", W.LC58.LC58_TRACO);

                /*" -2066- PERFORM 345-000-LER-PRODUTOR. */

                M_345_000_LER_PRODUTOR_SECTION();
            }


            /*" -2066- PERFORM M_340_000_LER_TAPDCORR_DB_CLOSE_1 */

            M_340_000_LER_TAPDCORR_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-340-000-LER-TAPDCORR-DB-FETCH-1 */
        public void M_340_000_LER_TAPDCORR_DB_FETCH_1()
        {
            /*" -2050- EXEC SQL FETCH TAPDCORR INTO :APDCORR-NUM-APOL, :APDCORR-CODCORR, :APDCORR-DTINIVIG, :APDCORR-DTTERVIG END-EXEC. */

            if (TAPDCORR.Fetch())
            {
                _.Move(TAPDCORR.APDCORR_NUM_APOL, APDCORR_NUM_APOL);
                _.Move(TAPDCORR.APDCORR_CODCORR, APDCORR_CODCORR);
                _.Move(TAPDCORR.APDCORR_DTINIVIG, APDCORR_DTINIVIG);
                _.Move(TAPDCORR.APDCORR_DTTERVIG, APDCORR_DTTERVIG);
            }

        }

        [StopWatch]
        /*" M-340-000-LER-TAPDCORR-DB-CLOSE-1 */
        public void M_340_000_LER_TAPDCORR_DB_CLOSE_1()
        {
            /*" -2066- EXEC SQL CLOSE TAPDCORR END-EXEC. */

            TAPDCORR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_340_999_EXIT*/

        [StopWatch]
        /*" M-345-000-LER-PRODUTOR-SECTION */
        private void M_345_000_LER_PRODUTOR_SECTION()
        {
            /*" -2080- MOVE '345-000-LER-PRODUTOR' TO PARAGRAFO. */
            _.Move("345-000-LER-PRODUTOR", FILLER_249.WABEND.PARAGRAFO);

            /*" -2083- MOVE '115' TO WNR-EXEC-SQL. */
            _.Move("115", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2091- PERFORM M_345_000_LER_PRODUTOR_DB_SELECT_1 */

            M_345_000_LER_PRODUTOR_DB_SELECT_1();

            /*" -2094- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2095- DISPLAY 'SI0806B  - PRODUTOR NAO ENCONTRADO NA PRODUTOR' */
                _.Display($"SI0806B  - PRODUTOR NAO ENCONTRADO NA PRODUTOR");

                /*" -2097- DISPLAY 'CODCORR = ' APDCORR-CODCORR ' FONTE = ' RELSIN-FONTE */

                $"CODCORR = {APDCORR_CODCORR} FONTE = {RELSIN_FONTE}"
                .Display();

                /*" -2101- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL ' CODSUBES ' MEST-CODSUBES ' NRENDOS ' MEST-NRENDOS */

                $"NUM_APOLICE = {MEST_NUM_APOL} CODSUBES {MEST_CODSUBES} NRENDOS {MEST_NRENDOS}"
                .Display();

                /*" -2102- MOVE SPACES TO LC58-NOMPDT */
                _.Move("", W.LC58.LC58_NOMPDT);

                /*" -2103- ELSE */
            }
            else
            {


                /*" -2103- MOVE PRODUTOR-NOMPDT TO LC58-NOMPDT. */
                _.Move(PRODUTOR_NOMPDT, W.LC58.LC58_NOMPDT);
            }


        }

        [StopWatch]
        /*" M-345-000-LER-PRODUTOR-DB-SELECT-1 */
        public void M_345_000_LER_PRODUTOR_DB_SELECT_1()
        {
            /*" -2091- EXEC SQL SELECT NOMPDT INTO :PRODUTOR-NOMPDT FROM SEGUROS.V1PRODUTOR WHERE CODPDT = :APDCORR-CODCORR END-EXEC. */

            var m_345_000_LER_PRODUTOR_DB_SELECT_1_Query1 = new M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1()
            {
                APDCORR_CODCORR = APDCORR_CODCORR.ToString(),
            };

            var executed_1 = M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1.Execute(m_345_000_LER_PRODUTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTOR_NOMPDT, PRODUTOR_NOMPDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_345_999_EXIT*/

        [StopWatch]
        /*" M-350-000-PESQ-TGERAMO-SECTION */
        private void M_350_000_PESQ_TGERAMO_SECTION()
        {
            /*" -2118- SET I01 TO WZEROS. */
            I01.Value = WRAMO48.WZEROS;

            /*" -2119- MOVE '350-000-PES-TGERAMO' TO PARAGRAFO. */
            _.Move("350-000-PES-TGERAMO", FILLER_249.WABEND.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM M_350_100_LOOP */

            M_350_100_LOOP();

        }

        [StopWatch]
        /*" M-350-100-LOOP */
        private void M_350_100_LOOP(bool isPerform = false)
        {
            /*" -2125- SET I01 UP BY WHUM. */
            I01.Value += WRAMO48.WHUM;

            /*" -2127- IF I01 GREATER 100 */

            if (I01 > 100)
            {

                /*" -2128- DISPLAY 'SI0806B  - ESTOURO DE TABELA INTERNA DE RAMO' */
                _.Display($"SI0806B  - ESTOURO DE TABELA INTERNA DE RAMO");

                /*" -2131- GO TO 350-200-ACESSA-TGERAMO. */

                M_350_200_ACESSA_TGERAMO(); //GOTO
                return;
            }


            /*" -2132- IF WTABG-NOMERAMO (I01) EQUAL SPACES */

            if (FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I01].WTABG_NOMERAMO == string.Empty)
            {

                /*" -2135- GO TO 350-200-ACESSA-TGERAMO. */

                M_350_200_ACESSA_TGERAMO(); //GOTO
                return;
            }


            /*" -2136- IF WRAMO EQUAL WTABG-RAMO (I01) */

            if (WRAMO48.FILLER_234.WRAMO == FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I01].WTABG_RAMO)
            {

                /*" -2139- MOVE WTABG-NOMERAMO (I01) TO LC03-NOMERAMO */
                _.Move(FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I01].WTABG_NOMERAMO, W.LC03.LC03_NOMERAMO);

                /*" -2140- GO TO 350-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/ //GOTO
                return;

                /*" -2141- ELSE */
            }
            else
            {


                /*" -2141- GO TO 350-100-LOOP. */
                new Task(() => M_350_100_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" M-350-200-ACESSA-TGERAMO */
        private void M_350_200_ACESSA_TGERAMO(bool isPerform = false)
        {
            /*" -2151- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2154- MOVE '350-200-ACESSA-TGERAMO' TO PARAGRAFO. */
            _.Move("350-200-ACESSA-TGERAMO", FILLER_249.WABEND.PARAGRAFO);

            /*" -2155- MOVE WRAMO TO MEST-RAMO. */
            _.Move(WRAMO48.FILLER_234.WRAMO, MEST_RAMO);

            /*" -2161- PERFORM M_350_200_ACESSA_TGERAMO_DB_SELECT_1 */

            M_350_200_ACESSA_TGERAMO_DB_SELECT_1();

            /*" -2164- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2165- DISPLAY 'SI0806B -RAMO NAO CADASTRADO' */
                _.Display($"SI0806B -RAMO NAO CADASTRADO");

                /*" -2166- DISPLAY 'RAMO     = ' WRAMO */
                _.Display($"RAMO     = {WRAMO48.FILLER_234.WRAMO}");

                /*" -2167- DISPLAY 'MODALIDA = 0' */
                _.Display($"MODALIDA = 0");

                /*" -2168- ELSE */
            }
            else
            {


                /*" -2169- IF I01 NOT GREATER 100 */

                if (I01 <= 100)
                {

                    /*" -2170- MOVE WRAMO TO WTABG-RAMO (I01) */
                    _.Move(WRAMO48.FILLER_234.WRAMO, FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I01].WTABG_RAMO);

                    /*" -2172- MOVE GERAMO-NOMERAMO TO WTABG-NOMERAMO (I01). */
                    _.Move(GERAMO_NOMERAMO, FILLER_249.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I01].WTABG_NOMERAMO);
                }

            }


            /*" -2172- MOVE GERAMO-NOMERAMO TO LC03-NOMERAMO. */
            _.Move(GERAMO_NOMERAMO, W.LC03.LC03_NOMERAMO);

        }

        [StopWatch]
        /*" M-350-200-ACESSA-TGERAMO-DB-SELECT-1 */
        public void M_350_200_ACESSA_TGERAMO_DB_SELECT_1()
        {
            /*" -2161- EXEC SQL SELECT NOMERAMO INTO :GERAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :MEST-RAMO AND MODALIDA = 0 END-EXEC. */

            var m_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1 = new M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1()
            {
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1.Execute(m_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GERAMO_NOMERAMO, GERAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_350_999_EXIT*/

        [StopWatch]
        /*" M-355-000-PESQ-TCAUSA-SECTION */
        private void M_355_000_PESQ_TCAUSA_SECTION()
        {
            /*" -2185- MOVE '125' TO WNR-EXEC-SQL. */
            _.Move("125", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2188- MOVE '355-000-PESQ-TCAUSA' TO PARAGRAFO. */
            _.Move("355-000-PESQ-TCAUSA", FILLER_249.WABEND.PARAGRAFO);

            /*" -2194- PERFORM M_355_000_PESQ_TCAUSA_DB_SELECT_1 */

            M_355_000_PESQ_TCAUSA_DB_SELECT_1();

            /*" -2198- MOVE MEST-CODCAU TO LC04A-CODCAU. */
            _.Move(MEST_CODCAU, W.LC04A.LC04A_CODCAU);

            /*" -2199- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2201- DISPLAY 'CAUSA ' MEST-CODCAU ' NAO CADASTRADA - ' ' RAMO = ' MEST-RAMO */

                $"CAUSA {MEST_CODCAU} NAO CADASTRADA -  RAMO = {MEST_RAMO}"
                .Display();

                /*" -2204- DISPLAY 'DOCTO ' MEST-NUM-APOL ' ' MEST-NRENDOS */

                $"DOCTO {MEST_NUM_APOL} {MEST_NRENDOS}"
                .Display();

                /*" -2205- MOVE ' ' TO LC04A-CAUSA */
                _.Move(" ", W.LC04A.LC04A_CAUSA);

                /*" -2206- GO TO 355-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_355_999_EXIT*/ //GOTO
                return;

                /*" -2207- ELSE */
            }
            else
            {


                /*" -2207- MOVE CAUSA-DESCAU TO LC04A-CAUSA. */
                _.Move(CAUSA_DESCAU, W.LC04A.LC04A_CAUSA);
            }


        }

        [StopWatch]
        /*" M-355-000-PESQ-TCAUSA-DB-SELECT-1 */
        public void M_355_000_PESQ_TCAUSA_DB_SELECT_1()
        {
            /*" -2194- EXEC SQL SELECT DESCAU INTO :CAUSA-DESCAU FROM SEGUROS.V1SINICAUSA WHERE RAMO = :MEST-RAMO AND CODCAU = :MEST-CODCAU END-EXEC. */

            var m_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1 = new M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1()
            {
                MEST_CODCAU = MEST_CODCAU.ToString(),
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1.Execute(m_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAUSA_DESCAU, CAUSA_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_355_999_EXIT*/

        [StopWatch]
        /*" M-356-000-VER-COSSEGURO-SECTION */
        private void M_356_000_VER_COSSEGURO_SECTION()
        {
            /*" -2219- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2222- MOVE '356-000-VER-COSSEGURO' TO PARAGRAFO. */
            _.Move("356-000-VER-COSSEGURO", FILLER_249.WABEND.PARAGRAFO);

            /*" -2223- IF WORGAO EQUAL 090 */

            if (WRAMO48.FILLER_234.WORGAO == 090)
            {

                /*" -2224- MOVE ' SIN.LIDER - ' TO LC04A-LITER */
                _.Move(" SIN.LIDER - ", W.LC04A.LC04A_LITER);

                /*" -2225- MOVE MEST-SINLID TO LC04A-SINLID */
                _.Move(MEST_SINLID, W.LC04A.LC04A_SINLID);

                /*" -2226- ELSE */
            }
            else
            {


                /*" -2227- MOVE SPACES TO LC04A-LITER */
                _.Move("", W.LC04A.LC04A_LITER);

                /*" -2227- MOVE SPACES TO LC04A-SINLID. */
                _.Move("", W.LC04A.LC04A_SINLID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_356_999_EXIT*/

        [StopWatch]
        /*" M-360-000-IMPRIME-SECTION */
        private void M_360_000_IMPRIME_SECTION()
        {
            /*" -2240- MOVE '360-000-IMPRIME' TO PARAGRAFO. */
            _.Move("360-000-IMPRIME", FILLER_249.WABEND.PARAGRAFO);

            /*" -2247- ADD 1 TO WS-CONTADOR. */
            WRAMO48.WS_CONTADOR.Value = WRAMO48.WS_CONTADOR + 1;

            /*" -2249- MOVE SPACES TO LC01. */
            _.Move("", W.LC01);

            /*" -2252- WRITE REG-SI0806M1 FROM LC01 AFTER PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2256- WRITE REG-SI0806M1 FROM LC01 AFTER 10. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2258- MOVE THIST-APOL-SINI TO LC01-SINISTRO. */
            _.Move(THIST_APOL_SINI, W.LC01.LC01_SINISTRO);

            /*" -2261- WRITE REG-SI0806M1 FROM LC0A AFTER 1. */
            _.Move(W.LC0A.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2264- WRITE REG-SI0806M1 FROM LC0A AFTER 0. */
            _.Move(W.LC0A.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2267- WRITE REG-SI0806M1 FROM LC01 AFTER 1. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2270- WRITE REG-SI0806M1 FROM LC0B AFTER 1. */
            _.Move(W.LC0B.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2273- WRITE REG-SI0806M1 FROM LC0B AFTER 0. */
            _.Move(W.LC0B.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2276- WRITE REG-SI0806M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2279- WRITE REG-SI0806M1 FROM LC0C AFTER 1. */
            _.Move(W.LC0C.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2282- WRITE REG-SI0806M1 FROM LC0C AFTER 0. */
            _.Move(W.LC0C.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2285- WRITE REG-SI0806M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2287- IF WRAMO EQUAL 48 AND RELSIN-OPERACAO EQUAL 1003 */

            if (WRAMO48.FILLER_234.WRAMO == 48 && RELSIN_OPERACAO == 1003)
            {

                /*" -2288- PERFORM 367-000-TEXTO-7 */

                M_367_000_TEXTO_7_SECTION();

                /*" -2289- GO TO 360-000-RODAPE */

                M_360_000_RODAPE(); //GOTO
                return;

                /*" -2290- ELSE */
            }
            else
            {


                /*" -2292- WRITE REG-SI0806M1 FROM LC0D AFTER 1 */
                _.Move(W.LC0D.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2294- WRITE REG-SI0806M1 FROM LC0D AFTER 0 */
                _.Move(W.LC0D.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2304- WRITE REG-SI0806M1 FROM LC04 AFTER 1. */
                _.Move(W.LC04.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2307- IF WRAMO EQUAL PARAM-RAMO-VGAPC OR WRAMO EQUAL PARAM-RAMO-VG OR WRAMO EQUAL PARAM-RAMO-AP */

            if (WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_VGAPC || WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_VG || WRAMO48.FILLER_234.WRAMO == PARAM_RAMO_AP)
            {

                /*" -2308- PERFORM 366-000-TEXTO-6 */

                M_366_000_TEXTO_6_SECTION();

                /*" -2309- ELSE */
            }
            else
            {


                /*" -2310- IF RELSIN-OPERACAO EQUAL 1001 */

                if (RELSIN_OPERACAO == 1001)
                {

                    /*" -2311- PERFORM 361-000-TEXTO-3 */

                    M_361_000_TEXTO_3_SECTION();

                    /*" -2312- ELSE */
                }
                else
                {


                    /*" -2313- IF RELSIN-OPERACAO EQUAL 1004 */

                    if (RELSIN_OPERACAO == 1004)
                    {

                        /*" -2314- PERFORM 362-000-TEXTO-4 */

                        M_362_000_TEXTO_4_SECTION();

                        /*" -2315- ELSE */
                    }
                    else
                    {


                        /*" -2318- IF ((RELSIN-OPERACAO EQUAL 1002 OR 1003) AND (WRMOSIN EQUAL 31 OR 32) AND (MEST-CODCAU EQUAL 4 OR 5 OR 6 OR 7)) */

                        if (((RELSIN_OPERACAO.In("1002", "1003")) && (WRAMO48.FILLER_232.WRMOSIN.In("31", "32")) && (MEST_CODCAU.In("4", "5", "6", "7"))))
                        {

                            /*" -2319- PERFORM 363-000-TEXTO-1 */

                            M_363_000_TEXTO_1_SECTION();

                            /*" -2320- ELSE */
                        }
                        else
                        {


                            /*" -2321- IF RELSIN-OPERACAO EQUAL 9001 */

                            if (RELSIN_OPERACAO == 9001)
                            {

                                /*" -2322- PERFORM 364-000-TEXTO-5 */

                                M_364_000_TEXTO_5_SECTION();

                                /*" -2323- ELSE */
                            }
                            else
                            {


                                /*" -2325- PERFORM 365-000-TEXTO-2. */

                                M_365_000_TEXTO_2_SECTION();
                            }

                        }

                    }

                }

            }


            /*" -2326- IF WTEXTO EQUAL 4 OR 2 */

            if (WRAMO48.WTEXTO.In("4", "2"))
            {

                /*" -2328- WRITE REG-SI0806M1 FROM LC74 AFTER 1 */
                _.Move(W.LC74.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2329- ELSE */
            }
            else
            {


                /*" -2330- IF WTEXTO EQUAL 1 */

                if (WRAMO48.WTEXTO == 1)
                {

                    /*" -2332- WRITE REG-SI0806M1 FROM LC74 AFTER 1 */
                    _.Move(W.LC74.GetMoveValues(), REG_SI0806M1);

                    SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                    /*" -2333- ELSE */
                }
                else
                {


                    /*" -2334- IF WTEXTO EQUAL 6 */

                    if (WRAMO48.WTEXTO == 6)
                    {

                        /*" -2336- WRITE REG-SI0806M1 FROM LC74 AFTER 3 */
                        _.Move(W.LC74.GetMoveValues(), REG_SI0806M1);

                        SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                        /*" -2337- ELSE */
                    }
                    else
                    {


                        /*" -2338- IF WTEXTO EQUAL 3 */

                        if (WRAMO48.WTEXTO == 3)
                        {

                            /*" -2340- WRITE REG-SI0806M1 FROM LC74 AFTER 3 */
                            _.Move(W.LC74.GetMoveValues(), REG_SI0806M1);

                            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                            /*" -2341- ELSE */
                        }
                        else
                        {


                            /*" -2342- WRITE REG-SI0806M1 FROM LC74 AFTER 2. */
                            _.Move(W.LC74.GetMoveValues(), REG_SI0806M1);

                            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_360_000_RODAPE */

            M_360_000_RODAPE();

        }

        [StopWatch]
        /*" M-360-000-RODAPE */
        private void M_360_000_RODAPE(bool isPerform = false)
        {
            /*" -2351- WRITE REG-SI0806M1 FROM LC0E AFTER 3. */
            _.Move(W.LC0E.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2354- WRITE REG-SI0806M1 FROM LC0E AFTER 0. */
            _.Move(W.LC0E.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2357- WRITE REG-SI0806M1 FROM LC58 AFTER 1. */
            _.Move(W.LC58.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2359- PERFORM 370-000-AJUSTA-LC58A. */

            M_370_000_AJUSTA_LC58A_SECTION();

            /*" -2362- WRITE REG-SI0806M1 FROM WLC58A AFTER 3. */
            _.Move(WRAMO48.WLC58A.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2365- WRITE REG-SI0806M1 FROM LC58B AFTER 4. */
            _.Move(W.LC58B.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2368- WRITE REG-SI0806M1 FROM LC58B AFTER 0. */
            _.Move(W.LC58B.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2371- WRITE REG-SI0806M1 FROM LC58C AFTER 2. */
            _.Move(W.LC58C.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2374- WRITE REG-SI0806M1 FROM LC58C AFTER 0. */
            _.Move(W.LC58C.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2377- WRITE REG-SI0806M1 FROM LC58D AFTER 2. */
            _.Move(W.LC58D.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2380- WRITE REG-SI0806M1 FROM LC58D AFTER 0. */
            _.Move(W.LC58D.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2383- WRITE REG-SI0806M1 FROM LC58E AFTER 2. */
            _.Move(W.LC58E.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2384- WRITE REG-SI0806M1 FROM LC58E AFTER 0. */
            _.Move(W.LC58E.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-361-000-TEXTO-3-SECTION */
        private void M_361_000_TEXTO_3_SECTION()
        {
            /*" -2400- MOVE 3 TO WTEXTO */
            _.Move(3, WRAMO48.WTEXTO);

            /*" -2403- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2404- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2406- WRITE REG-SI0806M1 FROM LC27 AFTER 3 */
                _.Move(W.LC27.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2407- ELSE */
            }
            else
            {


                /*" -2410- WRITE REG-SI0806M1 FROM LC27 AFTER 1. */
                _.Move(W.LC27.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2413- WRITE REG-SI0806M1 FROM LC28 AFTER 1 */
            _.Move(W.LC28.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2419- WRITE REG-SI0806M1 FROM LC29 AFTER 1 */
            _.Move(W.LC29.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2422- WRITE REG-SI0806M1 FROM LC31 AFTER 1 */
            _.Move(W.LC31.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2425- WRITE REG-SI0806M1 FROM LC32 AFTER 1 */
            _.Move(W.LC32.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2428- WRITE REG-SI0806M1 FROM LC33 AFTER 1 */
            _.Move(W.LC33.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2431- WRITE REG-SI0806M1 FROM LC34 AFTER 1 */
            _.Move(W.LC34.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2432- IF WC-VAL3 NOT EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 != 00)
            {

                /*" -2434- WRITE REG-SI0806M1 FROM LC62 AFTER 1 */
                _.Move(W.LC62.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2436- WRITE REG-SI0806M1 FROM LC63 AFTER 1 */
                _.Move(W.LC63.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2438- WRITE REG-SI0806M1 FROM LC64 AFTER 1 */
                _.Move(W.LC64.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2439- ELSE */
            }
            else
            {


                /*" -2440- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_361_999_EXIT*/

        [StopWatch]
        /*" M-362-000-TEXTO-4-SECTION */
        private void M_362_000_TEXTO_4_SECTION()
        {
            /*" -2451- MOVE 4 TO WTEXTO */
            _.Move(4, WRAMO48.WTEXTO);

            /*" -2454- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2455- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2457- WRITE REG-SI0806M1 FROM LC35 AFTER 2 */
                _.Move(W.LC35.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2458- ELSE */
            }
            else
            {


                /*" -2461- WRITE REG-SI0806M1 FROM LC35 AFTER 1. */
                _.Move(W.LC35.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2464- WRITE REG-SI0806M1 FROM LC36 AFTER 1 */
            _.Move(W.LC36.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2470- WRITE REG-SI0806M1 FROM LC37 AFTER 1 */
            _.Move(W.LC37.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2473- WRITE REG-SI0806M1 FROM LC39 AFTER 1 */
            _.Move(W.LC39.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2476- WRITE REG-SI0806M1 FROM LC40 AFTER 1 */
            _.Move(W.LC40.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2479- WRITE REG-SI0806M1 FROM LC41 AFTER 1 */
            _.Move(W.LC41.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2482- WRITE REG-SI0806M1 FROM LC42 AFTER 1 */
            _.Move(W.LC42.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2485- WRITE REG-SI0806M1 FROM LC43 AFTER 1 */
            _.Move(W.LC43.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2488- WRITE REG-SI0806M1 FROM LC44 AFTER 1 */
            _.Move(W.LC44.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2489- IF WC-VAL3 NOT EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 != 00)
            {

                /*" -2491- WRITE REG-SI0806M1 FROM LC62 AFTER 1 */
                _.Move(W.LC62.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2493- WRITE REG-SI0806M1 FROM LC63 AFTER 1 */
                _.Move(W.LC63.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2495- WRITE REG-SI0806M1 FROM LC64 AFTER 1 */
                _.Move(W.LC64.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2496- ELSE */
            }
            else
            {


                /*" -2497- WRITE REG-SI0806M1 FROM LC00 AFTER 2. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_362_999_EXIT*/

        [StopWatch]
        /*" M-363-000-TEXTO-1-SECTION */
        private void M_363_000_TEXTO_1_SECTION()
        {
            /*" -2509- MOVE 1 TO WTEXTO */
            _.Move(1, WRAMO48.WTEXTO);

            /*" -2510- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2513- WRITE REG-SI0806M1 FROM LC05 AFTER 2 */
                _.Move(W.LC05.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2514- ELSE */
            }
            else
            {


                /*" -2518- WRITE REG-SI0806M1 FROM LC05 AFTER 2. */
                _.Move(W.LC05.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2521- WRITE REG-SI0806M1 FROM LC06 AFTER 1 */
            _.Move(W.LC06.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2527- WRITE REG-SI0806M1 FROM LC07 AFTER 1 */
            _.Move(W.LC07.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2530- WRITE REG-SI0806M1 FROM LC09 AFTER 1 */
            _.Move(W.LC09.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2533- WRITE REG-SI0806M1 FROM LC10 AFTER 1 */
            _.Move(W.LC10.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2536- WRITE REG-SI0806M1 FROM LC11 AFTER 1 */
            _.Move(W.LC11.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2539- WRITE REG-SI0806M1 FROM LC12 AFTER 1 */
            _.Move(W.LC12.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2542- WRITE REG-SI0806M1 FROM LC13 AFTER 1 */
            _.Move(W.LC13.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2545- WRITE REG-SI0806M1 FROM LC14 AFTER 1 */
            _.Move(W.LC14.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2548- WRITE REG-SI0806M1 FROM LC15 AFTER 1 */
            _.Move(W.LC15.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2551- WRITE REG-SI0806M1 FROM LC16 AFTER 1 */
            _.Move(W.LC16.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2552- IF WC-VAL3 NOT EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 != 00)
            {

                /*" -2554- WRITE REG-SI0806M1 FROM LC62 AFTER 1 */
                _.Move(W.LC62.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2556- WRITE REG-SI0806M1 FROM LC63 AFTER 1 */
                _.Move(W.LC63.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2559- WRITE REG-SI0806M1 FROM LC64 AFTER 1. */
                _.Move(W.LC64.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2560- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_363_999_EXIT*/

        [StopWatch]
        /*" M-364-000-TEXTO-5-SECTION */
        private void M_364_000_TEXTO_5_SECTION()
        {
            /*" -2571- MOVE 5 TO WTEXTO */
            _.Move(5, WRAMO48.WTEXTO);

            /*" -2574- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2575- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2577- WRITE REG-SI0806M1 FROM LC45 AFTER 3 */
                _.Move(W.LC45.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2578- ELSE */
            }
            else
            {


                /*" -2581- WRITE REG-SI0806M1 FROM LC45 AFTER 1. */
                _.Move(W.LC45.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2584- WRITE REG-SI0806M1 FROM LC46 AFTER 1 */
            _.Move(W.LC46.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2590- WRITE REG-SI0806M1 FROM LC47 AFTER 1 */
            _.Move(W.LC47.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2593- WRITE REG-SI0806M1 FROM LC49 AFTER 1 */
            _.Move(W.LC49.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2596- WRITE REG-SI0806M1 FROM LC50 AFTER 1 */
            _.Move(W.LC50.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2599- WRITE REG-SI0806M1 FROM LC51 AFTER 1 */
            _.Move(W.LC51.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2602- WRITE REG-SI0806M1 FROM LC52 AFTER 1 */
            _.Move(W.LC52.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2605- WRITE REG-SI0806M1 FROM LC53 AFTER 1 */
            _.Move(W.LC53.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2606- IF WC-VAL3 NOT EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 != 00)
            {

                /*" -2608- WRITE REG-SI0806M1 FROM LC62 AFTER 1 */
                _.Move(W.LC62.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2610- WRITE REG-SI0806M1 FROM LC63 AFTER 1 */
                _.Move(W.LC63.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2612- WRITE REG-SI0806M1 FROM LC64 AFTER 1 */
                _.Move(W.LC64.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2613- ELSE */
            }
            else
            {


                /*" -2614- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_364_999_EXIT*/

        [StopWatch]
        /*" M-365-000-TEXTO-2-SECTION */
        private void M_365_000_TEXTO_2_SECTION()
        {
            /*" -2625- MOVE 2 TO WTEXTO */
            _.Move(2, WRAMO48.WTEXTO);

            /*" -2628- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2629- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2631- WRITE REG-SI0806M1 FROM LC17 AFTER 2 */
                _.Move(W.LC17.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2632- ELSE */
            }
            else
            {


                /*" -2635- WRITE REG-SI0806M1 FROM LC17 AFTER 1. */
                _.Move(W.LC17.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2638- WRITE REG-SI0806M1 FROM LC18 AFTER 1 */
            _.Move(W.LC18.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2644- WRITE REG-SI0806M1 FROM LC19 AFTER 1 */
            _.Move(W.LC19.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2647- WRITE REG-SI0806M1 FROM LC21 AFTER 1 */
            _.Move(W.LC21.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2650- WRITE REG-SI0806M1 FROM LC22 AFTER 1 */
            _.Move(W.LC22.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2653- WRITE REG-SI0806M1 FROM LC23 AFTER 1 */
            _.Move(W.LC23.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2656- WRITE REG-SI0806M1 FROM LC24 AFTER 1 */
            _.Move(W.LC24.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2659- WRITE REG-SI0806M1 FROM LC25 AFTER 1 */
            _.Move(W.LC25.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2662- WRITE REG-SI0806M1 FROM LC26 AFTER 1. */
            _.Move(W.LC26.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2663- IF WC-VAL3 NOT EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 != 00)
            {

                /*" -2665- WRITE REG-SI0806M1 FROM LC62 AFTER 1 */
                _.Move(W.LC62.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2667- WRITE REG-SI0806M1 FROM LC63 AFTER 1 */
                _.Move(W.LC63.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2669- WRITE REG-SI0806M1 FROM LC64 AFTER 1 */
                _.Move(W.LC64.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2670- ELSE */
            }
            else
            {


                /*" -2671- WRITE REG-SI0806M1 FROM LC00 AFTER 2. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_365_999_EXIT*/

        [StopWatch]
        /*" M-366-000-TEXTO-6-SECTION */
        private void M_366_000_TEXTO_6_SECTION()
        {
            /*" -2682- MOVE 6 TO WTEXTO */
            _.Move(6, WRAMO48.WTEXTO);

            /*" -2685- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2686- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2688- WRITE REG-SI0806M1 FROM LC65 AFTER 3 */
                _.Move(W.LC65.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2689- ELSE */
            }
            else
            {


                /*" -2692- WRITE REG-SI0806M1 FROM LC65 AFTER 1. */
                _.Move(W.LC65.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2695- WRITE REG-SI0806M1 FROM LC66 AFTER 1 */
            _.Move(W.LC66.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2701- WRITE REG-SI0806M1 FROM LC67 AFTER 1 */
            _.Move(W.LC66.LC67.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2704- WRITE REG-SI0806M1 FROM LC69 AFTER 1 */
            _.Move(W.LC69.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2707- WRITE REG-SI0806M1 FROM LC70 AFTER 1 */
            _.Move(W.LC70.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2710- WRITE REG-SI0806M1 FROM LC71 AFTER 1 */
            _.Move(W.LC71.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2716- WRITE REG-SI0806M1 FROM LC72 AFTER 1 */
            _.Move(W.LC72.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2717- IF WC-VAL3 NOT EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 != 00)
            {

                /*" -2719- WRITE REG-SI0806M1 FROM LC62 AFTER 1 */
                _.Move(W.LC62.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2721- WRITE REG-SI0806M1 FROM LC63 AFTER 1 */
                _.Move(W.LC63.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2723- WRITE REG-SI0806M1 FROM LC64 AFTER 1 */
                _.Move(W.LC64.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2724- ELSE */
            }
            else
            {


                /*" -2725- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_366_999_EXIT*/

        [StopWatch]
        /*" M-367-000-TEXTO-7-SECTION */
        private void M_367_000_TEXTO_7_SECTION()
        {
            /*" -2737- MOVE '135' TO WNR-EXEC-SQL. */
            _.Move("135", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2745- PERFORM M_367_000_TEXTO_7_DB_SELECT_1 */

            M_367_000_TEXTO_7_DB_SELECT_1();

            /*" -2748- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2749- MOVE THIST-VALPRI TO LC76-VALOR */
                _.Move(THIST_VALPRI, WRAMO48.LC76.LC76_VALOR);

                /*" -2750- MOVE ZEROS TO LC78-VALOR */
                _.Move(0, WRAMO48.LC78.LC78_VALOR);

                /*" -2751- ELSE */
            }
            else
            {


                /*" -2752- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2753- DISPLAY 'ERRO NO ACESSO DA OPERACAO 2 - RAMO 48' */
                    _.Display($"ERRO NO ACESSO DA OPERACAO 2 - RAMO 48");

                    /*" -2754- DISPLAY 'SINISTRO : ' RELSIN-APOL-SINI */
                    _.Display($"SINISTRO : {RELSIN_APOL_SINI}");

                    /*" -2755- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2756- ELSE */
                }
                else
                {


                    /*" -2757- COMPUTE THIST-VALPRI-TOT = THIST-VALPRI-CEF + THIST-VALPRI */
                    THIST_VALPRI_TOT.Value = THIST_VALPRI_CEF + THIST_VALPRI;

                    /*" -2758- MOVE THIST-VALPRI-TOT TO LC76-VALOR */
                    _.Move(THIST_VALPRI_TOT, WRAMO48.LC76.LC76_VALOR);

                    /*" -2763- MOVE THIST-VALPRI-CEF TO LC78-VALOR. */
                    _.Move(THIST_VALPRI_CEF, WRAMO48.LC78.LC78_VALOR);
                }

            }


            /*" -2765- MOVE 7 TO WTEXTO */
            _.Move(7, WRAMO48.WTEXTO);

            /*" -2767- WRITE REG-SI0806M1 FROM LC75 AFTER 1 */
            _.Move(WRAMO48.LC75.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2770- WRITE REG-SI0806M1 FROM LC75 AFTER 0 */
            _.Move(WRAMO48.LC75.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2773- WRITE REG-SI0806M1 FROM LC76 AFTER 1 */
            _.Move(WRAMO48.LC76.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2775- WRITE REG-SI0806M1 FROM LC77A AFTER 1 */
            _.Move(WRAMO48.LC77A.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2777- WRITE REG-SI0806M1 FROM LC77A AFTER 0 */
            _.Move(WRAMO48.LC77A.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2779- WRITE REG-SI0806M1 FROM LC77B AFTER 1 */
            _.Move(WRAMO48.LC77B.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2781- WRITE REG-SI0806M1 FROM LC77B AFTER 0 */
            _.Move(WRAMO48.LC77B.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2783- WRITE REG-SI0806M1 FROM LC77C AFTER 1 */
            _.Move(WRAMO48.LC77C.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2786- WRITE REG-SI0806M1 FROM LC77C AFTER 0 */
            _.Move(WRAMO48.LC77C.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2789- WRITE REG-SI0806M1 FROM LC78 AFTER 1 */
            _.Move(WRAMO48.LC78.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2791- WRITE REG-SI0806M1 FROM LC79 AFTER 1 */
            _.Move(WRAMO48.LC79.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2794- WRITE REG-SI0806M1 FROM LC79 AFTER 0 */
            _.Move(WRAMO48.LC79.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2797- WRITE REG-SI0806M1 FROM LC80 AFTER 1 */
            _.Move(WRAMO48.LC80.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2800- WRITE REG-SI0806M1 FROM LC00 AFTER 1. */
            _.Move(W.LC00.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2801- IF WC-VAL3 EQUAL ZEROES */

            if (WRAMO48.WC_VAL3 == 00)
            {

                /*" -2803- WRITE REG-SI0806M1 FROM LC81 AFTER 3 */
                _.Move(WRAMO48.LC81.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

                /*" -2804- ELSE */
            }
            else
            {


                /*" -2807- WRITE REG-SI0806M1 FROM LC81 AFTER 1. */
                _.Move(WRAMO48.LC81.GetMoveValues(), REG_SI0806M1);

                SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());
            }


            /*" -2810- WRITE REG-SI0806M1 FROM LC82 AFTER 1 */
            _.Move(WRAMO48.LC82.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2813- WRITE REG-SI0806M1 FROM LC83 AFTER 1 */
            _.Move(WRAMO48.LC83.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2816- WRITE REG-SI0806M1 FROM LC84 AFTER 1 */
            _.Move(WRAMO48.LC84.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2819- WRITE REG-SI0806M1 FROM LC85 AFTER 1 */
            _.Move(WRAMO48.LC85.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2822- WRITE REG-SI0806M1 FROM LC86 AFTER 1 */
            _.Move(WRAMO48.LC86.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2825- WRITE REG-SI0806M1 FROM LC87 AFTER 1 */
            _.Move(WRAMO48.LC87.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2828- WRITE REG-SI0806M1 FROM LC88 AFTER 1 */
            _.Move(WRAMO48.LC88.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2831- WRITE REG-SI0806M1 FROM LC89 AFTER 1 */
            _.Move(WRAMO48.LC89.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2834- WRITE REG-SI0806M1 FROM LC90 AFTER 1 */
            _.Move(WRAMO48.LC90.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2837- WRITE REG-SI0806M1 FROM LC91 AFTER 1 */
            _.Move(WRAMO48.LC91.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2840- WRITE REG-SI0806M1 FROM LC92 AFTER 1 */
            _.Move(WRAMO48.LC92.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

            /*" -2841- WRITE REG-SI0806M1 FROM LC93 AFTER 1. */
            _.Move(WRAMO48.LC93.GetMoveValues(), REG_SI0806M1);

            SI0806M1.Write(REG_SI0806M1.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-367-000-TEXTO-7-DB-SELECT-1 */
        public void M_367_000_TEXTO_7_DB_SELECT_1()
        {
            /*" -2745- EXEC SQL SELECT VAL_OPERACAO INTO :THIST-VALPRI-CEF FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND OPERACAO = 2 AND SITUACAO = '0' END-EXEC. */

            var m_367_000_TEXTO_7_DB_SELECT_1_Query1 = new M_367_000_TEXTO_7_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_367_000_TEXTO_7_DB_SELECT_1_Query1.Execute(m_367_000_TEXTO_7_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_VALPRI_CEF, THIST_VALPRI_CEF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_367_999_EXIT*/

        [StopWatch]
        /*" M-370-000-AJUSTA-LC58A-SECTION */
        private void M_370_000_AJUSTA_LC58A_SECTION()
        {
            /*" -2855- MOVE '370-000-AJUSTA-LC58A' TO PARAGRAFO. */
            _.Move("370-000-AJUSTA-LC58A", FILLER_249.WABEND.PARAGRAFO);

            /*" -2856- MOVE SPACES TO WTAB-LETRA-02 */
            _.Move("", WRAMO48.WTAB_LETRA_02);

            /*" -2857- MOVE LC58A TO WTAB-LETRA-01 */
            _.Move(W.LC58A, WRAMO48.WTAB_LETRA_01);

            /*" -2859- MOVE ZEROS TO X02. */
            _.Move(0, WRAMO48.X02);

            /*" -2863- PERFORM 370-100-LOOP VARYING X01 FROM 1 BY 1 UNTIL X01 GREATER 132. */

            for (WRAMO48.X01.Value = 1; !(WRAMO48.X01 > 132); WRAMO48.X01.Value += 1)
            {

                M_370_100_LOOP();
            }

            /*" -2864- MOVE WTAB-LETRA-02 TO WLC58A-LINHA. */
            _.Move(WRAMO48.WTAB_LETRA_02, WRAMO48.WLC58A.WLC58A_LINHA);

            /*" -2864- GO TO 370-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-370-100-LOOP */
        private void M_370_100_LOOP(bool isPerform = false)
        {
            /*" -2869- IF WTAB1-LETRA (X01) NOT = SPACES */

            if (WRAMO48.WTAB_LETRA_01.WTAB1_LETRA[WRAMO48.X01] != string.Empty)
            {

                /*" -2870- ADD +1 TO X02 */
                WRAMO48.X02.Value = WRAMO48.X02 + +1;

                /*" -2871- MOVE WTAB1-LETRA (X01) TO WTAB2-LETRA (X02) */
                _.Move(WRAMO48.WTAB_LETRA_01.WTAB1_LETRA[WRAMO48.X01], WRAMO48.WTAB_LETRA_02.WTAB2_LETRA[WRAMO48.X02]);

                /*" -2872- ELSE */
            }
            else
            {


                /*" -2873- ADD +1 TO X02 */
                WRAMO48.X02.Value = WRAMO48.X02 + +1;

                /*" -2877- PERFORM 370-999-EXIT VARYING X03 FROM X01 BY 1 UNTIL X03 GREATER 132 OR WTAB1-LETRA (X03) NOT = SPACES */

                for (WRAMO48.X03.Value = WRAMO48.X01; !(WRAMO48.X03 > 132 || WRAMO48.WTAB_LETRA_01.WTAB1_LETRA[WRAMO48.X03] != string.Empty); WRAMO48.X03.Value += 1)
                {
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/

                }

                /*" -2877- COMPUTE X01 = X03 - 1. */
                WRAMO48.X01.Value = WRAMO48.X03 - 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_110_FIM*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-SECTION */
        private void M_610_000_LER_TGEUNIMO_SECTION()
        {
            /*" -2926- MOVE '140' TO WNR-EXEC-SQL */
            _.Move("140", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2930- MOVE '610-000-LER-TGEUNIMO' TO PARAGRAFO. */
            _.Move("610-000-LER-TGEUNIMO", FILLER_249.WABEND.PARAGRAFO);

            /*" -2939- PERFORM M_610_000_LER_TGEUNIMO_DB_SELECT_1 */

            M_610_000_LER_TGEUNIMO_DB_SELECT_1();

            /*" -2942- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2945- DISPLAY 'SI0806B  - NAO CONSTA REGISTRO NA V1MOEDA ' ' - CODUNIMO = ' WMOEDA ' - DTINIVIG = ' WGEUNIMO-DTINIVIG */

                $"SI0806B  - NAO CONSTA REGISTRO NA V1MOEDA  - CODUNIMO = {WMOEDA} - DTINIVIG = {WGEUNIMO_DTINIVIG}"
                .Display();

                /*" -2945- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-DB-SELECT-1 */
        public void M_610_000_LER_TGEUNIMO_DB_SELECT_1()
        {
            /*" -2939- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :GEUNIMO-VLCRUZAD, :GEUNIMO-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WMOEDA AND DTINIVIG <= :WGEUNIMO-DTINIVIG AND DTTERVIG >= :WGEUNIMO-DTTERVIG END-EXEC. */

            var m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 = new M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1()
            {
                WGEUNIMO_DTINIVIG = WGEUNIMO_DTINIVIG.ToString(),
                WGEUNIMO_DTTERVIG = WGEUNIMO_DTTERVIG.ToString(),
                WMOEDA = WMOEDA.ToString(),
            };

            var executed_1 = M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1.Execute(m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEUNIMO_VLCRUZAD, GEUNIMO_VLCRUZAD);
                _.Move(executed_1.GEUNIMO_SIGLUNIM, GEUNIMO_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-680-000-LIMPA-REGISTROS-SECTION */
        private void M_680_000_LIMPA_REGISTROS_SECTION()
        {
            /*" -2965- MOVE '680-000-LIMPA-REGISTROS' TO PARAGRAFO. */
            _.Move("680-000-LIMPA-REGISTROS", FILLER_249.WABEND.PARAGRAFO);

            /*" -2968- MOVE '145' TO WNR-EXEC-SQL. */
            _.Move("145", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -2988- MOVE ZEROS TO LC01-SINISTRO LC04-APOLICE LC76-APOLICE LC04-NRENDOS LC04-NRCERTIF LC04-DD-OC LC80-DD-OC LC04-MM-OC LC80-MM-OC LC04-AA-OC LC80-AA-OC LC04-VALOR LC80-VALOR LC54-INDENIZ LC55-ADIANT LC57-TOTAL LC58A-DIA-EMIS LC58A-ANO-EMIS LC58-CODPDT. */
            _.Move(0, W.LC01.LC01_SINISTRO, W.LC04.LC04_APOLICE, WRAMO48.LC76.LC76_APOLICE, W.LC04.LC04_NRENDOS, W.LC04.LC04_ITEM.LC04_NRCERTIF, W.LC04.LC04_DATA_OCORR.LC04_DD_OC, WRAMO48.LC80.LC80_DATA_OCORR.LC80_DD_OC, W.LC04.LC04_DATA_OCORR.LC04_MM_OC, WRAMO48.LC80.LC80_DATA_OCORR.LC80_MM_OC, W.LC04.LC04_DATA_OCORR.LC04_AA_OC, WRAMO48.LC80.LC80_DATA_OCORR.LC80_AA_OC, W.LC04.LC04_VALOR, WRAMO48.LC80.LC80_VALOR, W.LC54.LC54_INDENIZ, W.LC55.LC55_ADIANT, W.LC57.LC57_TOTAL, W.LC58A.LC58A_DIA_EMIS, W.LC58A.LC58A_ANO_EMIS, W.LC58.LC58_CODPDT);

            /*" -2994- MOVE SPACES TO LC02-NOME LC02-NOMEFTE LC03-NOMFAV LC03-NOMERAMO LC58A-FONTE LC58A-MES-EMIS LC58-NOMPDT. */
            _.Move("", W.LC02.LC02_NOME, W.LC02.LC02_NOMEFTE, W.LC03.LC03_NOMFAV, W.LC03.LC03_NOMERAMO, W.LC58A.LC58A_FONTE, W.LC58A.LC58A_MES_EMIS, W.LC58.LC58_NOMPDT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_680_999_EXIT*/

        [StopWatch]
        /*" M-800-000-LER-PREMIO-IOF-SECTION */
        private void M_800_000_LER_PREMIO_IOF_SECTION()
        {
            /*" -3011- MOVE '800-000-LER-THISTSIN-E' TO PARAGRAFO. */
            _.Move("800-000-LER-THISTSIN-E", FILLER_249.WABEND.PARAGRAFO);

            /*" -3013- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -3022- PERFORM M_800_000_LER_PREMIO_IOF_DB_SELECT_1 */

            M_800_000_LER_PREMIO_IOF_DB_SELECT_1();

            /*" -3025- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3027- MOVE THIST-VALPRI TO LC04-VALOR LC80-VALOR */
                _.Move(THIST_VALPRI, W.LC04.LC04_VALOR, WRAMO48.LC80.LC80_VALOR);

                /*" -3028- ELSE */
            }
            else
            {


                /*" -3029- COMPUTE WC-VAL3 = THIST-VALPRI - THIST-VALPRI2 */
                WRAMO48.WC_VAL3.Value = THIST_VALPRI - THIST_VALPRI2;

                /*" -3030- MOVE THIST-VALPRI TO LC62-VAL-TOT */
                _.Move(THIST_VALPRI, W.LC62.LC62_VAL_TOT);

                /*" -3031- MOVE THIST-VALPRI2 TO LC63-PR-IOF */
                _.Move(THIST_VALPRI2, W.LC63.LC63_PR_IOF);

                /*" -3033- MOVE WC-VAL3 TO LC64-VAL-LIQ LC04-VALOR LC80-VALOR. */
                _.Move(WRAMO48.WC_VAL3, W.LC64.LC64_VAL_LIQ, W.LC04.LC04_VALOR, WRAMO48.LC80.LC80_VALOR);
            }


        }

        [StopWatch]
        /*" M-800-000-LER-PREMIO-IOF-DB-SELECT-1 */
        public void M_800_000_LER_PREMIO_IOF_DB_SELECT_1()
        {
            /*" -3022- EXEC SQL SELECT VAL_OPERACAO INTO :THIST-VALPRI2 FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND OPERACAO = 1 AND SITUACAO = '0' AND OCORHIST = :RELSIN-OCORHIST END-EXEC. */

            var m_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1 = new M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
                RELSIN_OCORHIST = RELSIN_OCORHIST.ToString(),
            };

            var executed_1 = M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1.Execute(m_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_VALPRI2, THIST_VALPRI2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -3044- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", FILLER_249.WABEND.PARAGRAFO);

            /*" -3046- MOVE '155' TO WNR-EXEC-SQL. */
            _.Move("155", FILLER_249.WABEND.WNR_EXEC_SQL);

            /*" -3047- IF W-CONTA-RELAT-SOLICITADO EQUAL ZERO */

            if (FILLER_249.W_CONTA_RELAT_SOLICITADO == 00)
            {

                /*" -3048- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3049- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -3050- DISPLAY '*  NAO HOUVE SOLICITACAO PELO USUARIO,  *' */
                _.Display($"*  NAO HOUVE SOLICITACAO PELO USUARIO,  *");

                /*" -3051- DISPLAY '*  PARA EXECUCAO DO PROGRAMA SI0806B.   *' */
                _.Display($"*  PARA EXECUCAO DO PROGRAMA SI0806B.   *");

                /*" -3052- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -3053- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                /*" -3054- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -3055- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3057- GO TO 900-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/ //GOTO
                return;
            }


            /*" -3061- PERFORM M_900_000_FINALIZA_DB_DELETE_1 */

            M_900_000_FINALIZA_DB_DELETE_1();

            /*" -3064- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3065- DISPLAY 'ERRO NA DELECAO DOS PEDIDOS DE EMISSAO' */
                _.Display($"ERRO NA DELECAO DOS PEDIDOS DE EMISSAO");

                /*" -3066- DISPLAY 'DE RECIBOS. (V1RELATORIOS)' */
                _.Display($"DE RECIBOS. (V1RELATORIOS)");

                /*" -3068- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3068- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3072- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3073- DISPLAY '*****************************************' */
            _.Display($"*****************************************");

            /*" -3074- DISPLAY '*                                       *' */
            _.Display($"*                                       *");

            /*" -3075- DISPLAY '*           PROGRAMA SI0806B            *' */
            _.Display($"*           PROGRAMA SI0806B            *");

            /*" -3076- DISPLAY '*                                       *' */
            _.Display($"*                                       *");

            /*" -3077- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
            _.Display($"*      ==>  TERMINO NORMAL  <==         *");

            /*" -3078- DISPLAY '*                                       *' */
            _.Display($"*                                       *");

            /*" -3078- DISPLAY '*****************************************' . */
            _.Display($"*****************************************");

        }

        [StopWatch]
        /*" M-900-000-FINALIZA-DB-DELETE-1 */
        public void M_900_000_FINALIZA_DB_DELETE_1()
        {
            /*" -3061- EXEC SQL DELETE FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0806B' AND SITUACAO = ' ' END-EXEC. */

            var m_900_000_FINALIZA_DB_DELETE_1_Delete1 = new M_900_000_FINALIZA_DB_DELETE_1_Delete1()
            {
            };

            M_900_000_FINALIZA_DB_DELETE_1_Delete1.Execute(m_900_000_FINALIZA_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -3091- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3092- DISPLAY ' ' */
                _.Display($" ");

                /*" -3093- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -3094- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0806B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0806B  *");

                /*" -3095- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -3096- DISPLAY ' ' */
                _.Display($" ");

                /*" -3097- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {FILLER_249.WABEND.WNR_EXEC_SQL}");

                /*" -3098- DISPLAY '==> PARAGRAFO ONDE OCORREU O ERRO = ' PARAGRAFO */
                _.Display($"==> PARAGRAFO ONDE OCORREU O ERRO = {FILLER_249.WABEND.PARAGRAFO}");

                /*" -3099- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_249.WABEND.WSQLCODE);

                /*" -3100- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_249.WABEND.WSQLCODE1);

                /*" -3101- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_249.WABEND.WSQLCODE2);

                /*" -3102- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, WRAMO48.WSQLCODE3);
            }


            /*" -3104- DISPLAY WABEND. */
            _.Display(FILLER_249.WABEND);

            /*" -3105- CLOSE SI0806M1. */
            SI0806M1.Close();

            /*" -3105- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3106- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3108- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3108- GOBACK. */

            throw new GoBack();

        }
    }
}