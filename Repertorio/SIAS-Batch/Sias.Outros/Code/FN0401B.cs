using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Sias.Outros.DB2.FN0401B;

namespace Code
{
    public class FN0401B
    {
        public bool IsCall { get; set; }

        public FN0401B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  INTERFACE SASSE/FENAE              *      */
        /*"      *   PROGRAMA ...............  FN0401B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CONSEDA4                           *      */
        /*"      *   PROGRAMADOR ............  CONSEDA4                           *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/1999                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CRIACAO DO MOVIMENTO DIARIO CONTEN-*      */
        /*"      *                             DO AS OPERACOES DE BAIXA (COBRANCA,*      */
        /*"      *                             ESTORNO, CANCELAMENTO, REATIVACAO) *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    06/04/2011 - CADMUS 54479 - COLOCAR CLAUSULA WITH UR NOS    *      */
        /*"      *                 COMANDOS SELECT                                *      */
        /*"      *               - SERGIO LORETO PROCURAR POR ======> C54479      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    23/11/2009 - CADMUS 33062 - ADEQUAR P. TRATAR OS PRODUTOS   *      */
        /*"      *                 COMERCIALIZADOS VIA AIC CREDMINAS              *      */
        /*"      *    WV1109     - W. FRANCISCO R C VERAS (TE39902)  - POLITEC    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V1HISTOPARC       INPUT    *      */
        /*"      * APOLICES                            V1APOLICE         INPUT    *      */
        /*"      * PARCELAS                            V1PARCELA         INPUT    *      */
        /*"      * FICHA ENDOSSO                       V0FICHAENDOS      INPUT    *      */
        /*"      * FICHA PARCELA                       V0FICHAPARC       I-O      *      */
        /*"      * FICHA PARCELA HISTORICO             V0FICHAHISTPARC   OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _FENHIST { get; set; } = new FileBasis(new PIC("X", "107", "X(107)"));

        public FileBasis FENHIST
        {
            get
            {
                _.Move(REG_FENHIST, _FENHIST); VarBasis.RedefinePassValue(REG_FENHIST, _FENHIST, REG_FENHIST); return _FENHIST;
            }
        }
        /*"01        REG-FENHIST           PIC  X(107).*/
        public StringBasis REG_FENHIST { get; set; } = new StringBasis(new PIC("X", "107", "X(107)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-EMPRESA        PIC S9(004)                COMP.*/
        public IntBasis VIND_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-RCAP       PIC S9(004)                COMP.*/
        public IntBasis VIND_DAT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLPREMIO       PIC S9(004)                COMP.*/
        public IntBasis VIND_VLPREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1FONT-FONTE        PIC S9(004)                 COMP.*/
        public IntBasis W1FONT_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WSIT-PARCELA        PIC  X(001).*/
        public StringBasis WSIT_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WSIT-ENDOSSO        PIC  X(001).*/
        public StringBasis WSIT_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WHOST-CODCORR       PIC S9(009)                COMP.*/
        public IntBasis WHOST_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1SIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0ENDO-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HIST-NUMAPOL      PIC S9(013)                COMP-3*/
        public IntBasis V1HIST_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HIST-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V1HIST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HIST-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V1HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HIST-DACPARC      PIC  X(001).*/
        public StringBasis V1HIST_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HIST-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HIST-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V1HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HIST-HORAOPER     PIC  X(008).*/
        public StringBasis V1HIST_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HIST-OCORHIST     PIC S9(004) COMP.*/
        public IntBasis V1HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HIST-PRM-TAR      PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VAL-DESC     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VLPRMLIQ     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VLADIFRA     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VLCUSEMI     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VLIOCC       PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VLPRMTOT     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-VLPREMIO     PIC S9(013)V9(02)          COMP-3*/
        public DoubleBasis V1HIST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HIST-DTVENCTO     PIC  X(010).*/
        public StringBasis V1HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HIST-BCOCOBR      PIC S9(004)                COMP.*/
        public IntBasis V1HIST_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HIST-AGECOBR      PIC S9(004)                COMP.*/
        public IntBasis V1HIST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HIST-NRAVISO      PIC S9(009)                COMP.*/
        public IntBasis V1HIST_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HIST-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V1HIST_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HIST-SITCONTB     PIC  X(001).*/
        public StringBasis V1HIST_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HIST-COD-USUAR    PIC  X(008).*/
        public StringBasis V1HIST_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HIST-RNUDOC       PIC S9(009)                COMP.*/
        public IntBasis V1HIST_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HIST-DTQITBCO     PIC  X(010).*/
        public StringBasis V1HIST_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HIST-COD-EMP      PIC S9(009)                COMP.*/
        public IntBasis V1HIST_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FEND-QTPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V0FEND_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FPARC-NUMAPOL        PIC S9(013)       COMP-3.*/
        public IntBasis V0FPARC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FPARC-NRENDOS        PIC S9(009)       COMP.*/
        public IntBasis V0FPARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FPARC-NRPARCEL       PIC S9(004)       COMP.*/
        public IntBasis V0FPARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FPARC-DTVENCTO       PIC  X(010).*/
        public StringBasis V0FPARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FPARC-SITUACAO       PIC  X(001).*/
        public StringBasis V0FPARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FPARC-FOLLOWUP       PIC  X(001).*/
        public StringBasis V0FPARC_FOLLOWUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FPARC-TIMESTAMP      PIC  X(026).*/
        public StringBasis V0FPARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0FHPAR-NUMAPOL        PIC S9(013)       COMP-3.*/
        public IntBasis V0FHPAR_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FHPAR-NRENDOS        PIC S9(009)       COMP.*/
        public IntBasis V0FHPAR_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FHPAR-NRPARCEL       PIC S9(004)       COMP.*/
        public IntBasis V0FHPAR_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FHPAR-OCORHIST       PIC S9(004)       COMP.*/
        public IntBasis V0FHPAR_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FHPAR-OPERACAO       PIC S9(004)       COMP.*/
        public IntBasis V0FHPAR_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FHPAR-VLPRMTOT       PIC S9(013)V99    COMP-3.*/
        public DoubleBasis V0FHPAR_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FHPAR-DTMOVTO        PIC  X(010).*/
        public StringBasis V0FHPAR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FHPAR-DTQITBCO       PIC  X(010).*/
        public StringBasis V0FHPAR_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FHPAR-VLPREMIO       PIC S9(013)V99    COMP-3.*/
        public DoubleBasis V0FHPAR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FHPAR-TIMESTAMP      PIC  X(026).*/
        public StringBasis V0FHPAR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         WREG-HEADER.*/
        public FN0401B_WREG_HEADER WREG_HEADER { get; set; } = new FN0401B_WREG_HEADER();
        public class FN0401B_WREG_HEADER : VarBasis
        {
            /*"  05       FHDR-PROGRAMA         PIC  X(006)    VALUE 'FN0401'.*/
            public StringBasis FHDR_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"FN0401");
            /*"  05       FHDR-TIPOREG          PIC  X(008)    VALUE 'HEADER'.*/
            public StringBasis FHDR_TIPOREG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HEADER");
            /*"  05       FHDR-DTMOVABE         PIC  X(010).*/
            public StringBasis FHDR_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01         WREG-TRAILLER.*/
        }
        public FN0401B_WREG_TRAILLER WREG_TRAILLER { get; set; } = new FN0401B_WREG_TRAILLER();
        public class FN0401B_WREG_TRAILLER : VarBasis
        {
            /*"  05       FTRL-PROGRAMA         PIC  X(006)    VALUE 'FN0401'.*/
            public StringBasis FTRL_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"FN0401");
            /*"  05       FTRL-TIPOREG          PIC  X(008)    VALUE 'TRAILLER'*/
            public StringBasis FTRL_TIPOREG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"TRAILLER");
            /*"  05       FTRL-DTMOVABE         PIC  X(010).*/
            public StringBasis FTRL_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FTRL-QTDREG           PIC  9(009).*/
            public IntBasis FTRL_QTDREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"01         WREG-FENHIST.*/
        }
        public FN0401B_WREG_FENHIST WREG_FENHIST { get; set; } = new FN0401B_WREG_FENHIST();
        public class FN0401B_WREG_FENHIST : VarBasis
        {
            /*"  05       FHST-NUMAPOL          PIC  9(013).*/
            public IntBasis FHST_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-NRENDOS          PIC  9(009).*/
            public IntBasis FHST_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-NRPARCEL         PIC  9(004).*/
            public IntBasis FHST_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-OCORHIST         PIC  9(004).*/
            public IntBasis FHST_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-OPERACAO         PIC  9(004).*/
            public IntBasis FHST_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-DTMOVTO          PIC  X(010).*/
            public StringBasis FHST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-VLPRMTOT         PIC  9(013).99.*/
            public IntBasis FHST_VLPRMTOT { get; set; } = new IntBasis(new PIC("9", "15", "9(013).99."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-VLPRMLIQ         PIC  9(013).99.*/
            public IntBasis FHST_VLPRMLIQ { get; set; } = new IntBasis(new PIC("9", "15", "9(013).99."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-SITUACAO         PIC  X(001).*/
            public StringBasis FHST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-DTQITBCO         PIC  X(010).*/
            public StringBasis FHST_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FHST-DTVENCTO         PIC  X(010).*/
            public StringBasis FHST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public FN0401B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FN0401B_AREA_DE_WORK();
        public class FN0401B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(09)     VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05         CH-VERIFICA       PIC  X(001)    VALUE SPACES.*/
            public StringBasis CH_VERIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1HISTOPARC  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-L-V1HISTOPARC  PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis AC_L_V1HISTOPARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENHIST      PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis AC_G_FENHIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WABEND.*/
            public FN0401B_WABEND WABEND { get; set; } = new FN0401B_WABEND();
            public class FN0401B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' FN0401B'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" FN0401B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public FN0401B_V1HISTOPARC V1HISTOPARC { get; set; } = new FN0401B_V1HISTOPARC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string FENHIST_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                FENHIST.SetFile(FENHIST_FILE_NAME_P);

                /*" -276- MOVE '0000' TO WNR-EXEC-SQL. */
                _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -277- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -280- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -284- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -284- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -294- OPEN OUTPUT FENHIST */
            FENHIST.Open(REG_FENHIST);

            /*" -295- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -296- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -298- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -300- PERFORM R0900-00-DECLARE-V1HISTOPARC */

            R0900_00_DECLARE_V1HISTOPARC_SECTION();

            /*" -301- PERFORM R0910-00-FETCH-V1HISTOPARC */

            R0910_00_FETCH_V1HISTOPARC_SECTION();

            /*" -302- IF WFIM-V1HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty())
            {

                /*" -303- PERFORM R9000-00-ENCERRA-SEM-MOVTO */

                R9000_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -305- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -307- PERFORM R0200-00-GRAVA-HEADERS. */

            R0200_00_GRAVA_HEADERS_SECTION();

            /*" -310- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -310- PERFORM R0300-00-GRAVA-TRAILLERS. */

            R0300_00_GRAVA_TRAILLERS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -316- CLOSE FENHIST */
            FENHIST.Close();

            /*" -317- DISPLAY 'LIDOS V1HISTOPARC........ = ' AC-L-V1HISTOPARC */
            _.Display($"LIDOS V1HISTOPARC........ = {AREA_DE_WORK.AC_L_V1HISTOPARC}");

            /*" -319- DISPLAY 'GRAVADOS FENHIST......... = ' AC-G-FENHIST */
            _.Display($"GRAVADOS FENHIST......... = {AREA_DE_WORK.AC_G_FENHIST}");

            /*" -321- DISPLAY 'FN0401B - FIM NORMAL' */
            _.Display($"FN0401B - FIM NORMAL");

            /*" -323- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -323- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -336- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -346- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -349- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -350- DISPLAY 'FN0401B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"FN0401B - SISTEMA NAO ESTA CADASTRADO");

                /*" -351- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -351- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -346- EXEC SQL SELECT DTMOVABE , CURRENT DATE , CURRENT TIMESTAMP INTO :V1SIST-DTMOVABE , :V1SIST-DTCURRENT , :V1SIST-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
                _.Move(executed_1.V1SIST_TIMESTAMP, V1SIST_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-GRAVA-HEADERS-SECTION */
        private void R0200_00_GRAVA_HEADERS_SECTION()
        {
            /*" -363- MOVE V1SIST-DTMOVABE TO FHDR-DTMOVABE */
            _.Move(V1SIST_DTMOVABE, WREG_HEADER.FHDR_DTMOVABE);

            /*" -363- WRITE REG-FENHIST FROM WREG-HEADER. */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENHIST);

            FENHIST.Write(REG_FENHIST.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-GRAVA-TRAILLERS-SECTION */
        private void R0300_00_GRAVA_TRAILLERS_SECTION()
        {
            /*" -375- MOVE V1SIST-DTMOVABE TO FTRL-DTMOVABE */
            _.Move(V1SIST_DTMOVABE, WREG_TRAILLER.FTRL_DTMOVABE);

            /*" -376- MOVE AC-G-FENHIST TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENHIST, WREG_TRAILLER.FTRL_QTDREG);

            /*" -376- WRITE REG-FENHIST FROM WREG-TRAILLER. */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENHIST);

            FENHIST.Write(REG_FENHIST.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1HISTOPARC-SECTION */
        private void R0900_00_DECLARE_V1HISTOPARC_SECTION()
        {
            /*" -390- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -392- DISPLAY 'INICIO DO DECLARE - V1HISTOPARC' */
            _.Display($"INICIO DO DECLARE - V1HISTOPARC");

            /*" -429- PERFORM R0900_00_DECLARE_V1HISTOPARC_DB_DECLARE_1 */

            R0900_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();

            /*" -431- PERFORM R0900_00_DECLARE_V1HISTOPARC_DB_OPEN_1 */

            R0900_00_DECLARE_V1HISTOPARC_DB_OPEN_1();

            /*" -434- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -435- DISPLAY 'R0900-00 (ERRO NO DECLARE V1HISTOPARC' */
                _.Display($"R0900-00 (ERRO NO DECLARE V1HISTOPARC");

                /*" -437- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -437- DISPLAY 'FINAL DO DECLARE - VIHISTOPARC ' . */
            _.Display($"FINAL DO DECLARE - VIHISTOPARC ");

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1HISTOPARC-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1HISTOPARC_DB_DECLARE_1()
        {
            /*" -429- EXEC SQL DECLARE V1HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.DTMOVTO , A.OPERACAO , A.OCORHIST , A.VLPRMLIQ , A.VLPRMTOT , A.DTQITBCO , A.DTVENCTO , B.CODSUBES , B.DTINIVIG FROM SEGUROS.V1HISTOPARC A, SEGUROS.V0ENDOSSO B, SEGUROS.APOLICES C WHERE C.ORGAO_EMISSOR <> 90 AND C.NUM_APOLICE NOT IN (109300001662 , 109300001664 , 109300001666 , 107700000014 ) AND C.NUM_APOLICE = A.NUM_APOLICE AND A.DTMOVTO = :V1SIST-DTMOVABE AND A.OPERACAO BETWEEN 100 AND 599 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS ORDER BY NUM_APOLICE , NRENDOS , NRPARCEL , OCORHIST WITH UR END-EXEC. */
            V1HISTOPARC = new FN0401B_V1HISTOPARC(true);
            string GetQuery_V1HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.DTMOVTO
							, 
							A.OPERACAO
							, 
							A.OCORHIST
							, 
							A.VLPRMLIQ
							, 
							A.VLPRMTOT
							, 
							A.DTQITBCO
							, 
							A.DTVENCTO
							, 
							B.CODSUBES
							, 
							B.DTINIVIG 
							FROM SEGUROS.V1HISTOPARC A
							, 
							SEGUROS.V0ENDOSSO B
							, 
							SEGUROS.APOLICES C 
							WHERE C.ORGAO_EMISSOR <> 90 
							AND C.NUM_APOLICE NOT IN (109300001662
							, 
							109300001664
							, 
							109300001666
							, 
							107700000014 ) 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND A.DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND A.OPERACAO BETWEEN 100 AND 599 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NRENDOS = B.NRENDOS 
							ORDER BY NUM_APOLICE
							, 
							NRENDOS
							, 
							NRPARCEL
							, 
							OCORHIST";

                return query;
            }
            V1HISTOPARC.GetQueryEvent += GetQuery_V1HISTOPARC;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1HISTOPARC-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1HISTOPARC_DB_OPEN_1()
        {
            /*" -431- EXEC SQL OPEN V1HISTOPARC END-EXEC. */

            V1HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1HISTOPARC-SECTION */
        private void R0910_00_FETCH_V1HISTOPARC_SECTION()
        {
            /*" -448- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0910_10_FETCH */

            R0910_10_FETCH();

        }

        [StopWatch]
        /*" R0910-10-FETCH */
        private void R0910_10_FETCH(bool isPerform = false)
        {
            /*" -452- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -465- PERFORM R0910_10_FETCH_DB_FETCH_1 */

            R0910_10_FETCH_DB_FETCH_1();

            /*" -468- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -469- MOVE 'S' TO WFIM-V1HISTOPARC */
                _.Move("S", AREA_DE_WORK.WFIM_V1HISTOPARC);

                /*" -469- PERFORM R0910_10_FETCH_DB_CLOSE_1 */

                R0910_10_FETCH_DB_CLOSE_1();

                /*" -472- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -474- MOVE '0' TO CH-VERIFICA */
            _.Move("0", AREA_DE_WORK.CH_VERIFICA);

            /*" -475- PERFORM R0920-00-VERIFICA-CORRET-FENAE */

            R0920_00_VERIFICA_CORRET_FENAE_SECTION();

            /*" -476- IF CH-VERIFICA EQUAL '0' */

            if (AREA_DE_WORK.CH_VERIFICA == "0")
            {

                /*" -478- GO TO R0910-10-FETCH. */
                new Task(() => R0910_10_FETCH()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -479- IF VIND-DTQITBCO EQUAL -1 */

            if (VIND_DTQITBCO == -1)
            {

                /*" -481- MOVE SPACES TO V1HIST-DTQITBCO. */
                _.Move("", V1HIST_DTQITBCO);
            }


            /*" -482- IF VIND-DTQITBCO EQUAL -1 */

            if (VIND_DTQITBCO == -1)
            {

                /*" -484- MOVE SPACES TO V1HIST-DTQITBCO. */
                _.Move("", V1HIST_DTQITBCO);
            }


            /*" -484- ADD 1 TO AC-L-V1HISTOPARC. */
            AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;

        }

        [StopWatch]
        /*" R0910-10-FETCH-DB-FETCH-1 */
        public void R0910_10_FETCH_DB_FETCH_1()
        {
            /*" -465- EXEC SQL FETCH V1HISTOPARC INTO :V1HIST-NUMAPOL , :V1HIST-NRENDOS , :V1HIST-NRPARCEL , :V1HIST-DTMOVTO , :V1HIST-OPERACAO , :V1HIST-OCORHIST , :V1HIST-VLPRMLIQ , :V1HIST-VLPRMTOT , :V1HIST-DTQITBCO:VIND-DTQITBCO, :V1HIST-DTVENCTO , :V0ENDO-CODSUBES, :V0ENDO-DTINIVIG END-EXEC. */

            if (V1HISTOPARC.Fetch())
            {
                _.Move(V1HISTOPARC.V1HIST_NUMAPOL, V1HIST_NUMAPOL);
                _.Move(V1HISTOPARC.V1HIST_NRENDOS, V1HIST_NRENDOS);
                _.Move(V1HISTOPARC.V1HIST_NRPARCEL, V1HIST_NRPARCEL);
                _.Move(V1HISTOPARC.V1HIST_DTMOVTO, V1HIST_DTMOVTO);
                _.Move(V1HISTOPARC.V1HIST_OPERACAO, V1HIST_OPERACAO);
                _.Move(V1HISTOPARC.V1HIST_OCORHIST, V1HIST_OCORHIST);
                _.Move(V1HISTOPARC.V1HIST_VLPRMLIQ, V1HIST_VLPRMLIQ);
                _.Move(V1HISTOPARC.V1HIST_VLPRMTOT, V1HIST_VLPRMTOT);
                _.Move(V1HISTOPARC.V1HIST_DTQITBCO, V1HIST_DTQITBCO);
                _.Move(V1HISTOPARC.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(V1HISTOPARC.V1HIST_DTVENCTO, V1HIST_DTVENCTO);
                _.Move(V1HISTOPARC.V0ENDO_CODSUBES, V0ENDO_CODSUBES);
                _.Move(V1HISTOPARC.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
            }

        }

        [StopWatch]
        /*" R0910-10-FETCH-DB-CLOSE-1 */
        public void R0910_10_FETCH_DB_CLOSE_1()
        {
            /*" -469- EXEC SQL CLOSE V1HISTOPARC END-EXEC */

            V1HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-VERIFICA-CORRET-FENAE-SECTION */
        private void R0920_00_VERIFICA_CORRET_FENAE_SECTION()
        {
            /*" -496- MOVE '0920' TO WNR-EXEC-SQL. */
            _.Move("0920", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -509- PERFORM R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1 */

            R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1();

            /*" -512- IF SQLCODE EQUAL 0 OR 811 OR -811 */

            if (DB.SQLCODE.In("0", "811", "-811"))
            {

                /*" -513- MOVE '1' TO CH-VERIFICA */
                _.Move("1", AREA_DE_WORK.CH_VERIFICA);

                /*" -514- ELSE */
            }
            else
            {


                /*" -515- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -516- MOVE '0' TO CH-VERIFICA */
                    _.Move("0", AREA_DE_WORK.CH_VERIFICA);

                    /*" -517- ELSE */
                }
                else
                {


                    /*" -518- DISPLAY 'R0920-00 (ERRO NO SELECT V1APOLCORRET)' */
                    _.Display($"R0920-00 (ERRO NO SELECT V1APOLCORRET)");

                    /*" -518- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0920-00-VERIFICA-CORRET-FENAE-DB-SELECT-1 */
        public void R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1()
        {
            /*" -509- EXEC SQL SELECT A.CODCORR INTO :WHOST-CODCORR FROM SEGUROS.V1APOLCORRET A, SEGUROS.V1PRODUTOR B WHERE A.NUM_APOLICE = :V1HIST-NUMAPOL AND A.CODSUBES = :V0ENDO-CODSUBES AND A.DTINIVIG <= :V0ENDO-DTINIVIG AND A.DTTERVIG >= :V0ENDO-DTINIVIG AND A.CODCORR = B.CODPDT AND B.CGCCPF IN (42278473000103, 29552064000187) WITH UR END-EXEC. */

            var r0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 = new R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1()
            {
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V1HIST_NUMAPOL = V1HIST_NUMAPOL.ToString(),
            };

            var executed_1 = R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1.Execute(r0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODCORR, WHOST_CODCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -531- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -532- MOVE V1HIST-NUMAPOL TO FHST-NUMAPOL */
            _.Move(V1HIST_NUMAPOL, WREG_FENHIST.FHST_NUMAPOL);

            /*" -533- MOVE V1HIST-NRENDOS TO FHST-NRENDOS */
            _.Move(V1HIST_NRENDOS, WREG_FENHIST.FHST_NRENDOS);

            /*" -534- MOVE V1HIST-NRPARCEL TO FHST-NRPARCEL */
            _.Move(V1HIST_NRPARCEL, WREG_FENHIST.FHST_NRPARCEL);

            /*" -535- MOVE V1HIST-OCORHIST TO FHST-OCORHIST */
            _.Move(V1HIST_OCORHIST, WREG_FENHIST.FHST_OCORHIST);

            /*" -536- MOVE V1HIST-OPERACAO TO FHST-OPERACAO */
            _.Move(V1HIST_OPERACAO, WREG_FENHIST.FHST_OPERACAO);

            /*" -537- MOVE V1HIST-DTMOVTO TO FHST-DTMOVTO */
            _.Move(V1HIST_DTMOVTO, WREG_FENHIST.FHST_DTMOVTO);

            /*" -538- MOVE V1HIST-VLPRMTOT TO FHST-VLPRMTOT */
            _.Move(V1HIST_VLPRMTOT, WREG_FENHIST.FHST_VLPRMTOT);

            /*" -539- MOVE V1HIST-VLPRMLIQ TO FHST-VLPRMLIQ */
            _.Move(V1HIST_VLPRMLIQ, WREG_FENHIST.FHST_VLPRMLIQ);

            /*" -540- MOVE V1HIST-DTQITBCO TO FHST-DTQITBCO */
            _.Move(V1HIST_DTQITBCO, WREG_FENHIST.FHST_DTQITBCO);

            /*" -542- MOVE V1HIST-DTVENCTO TO FHST-DTVENCTO */
            _.Move(V1HIST_DTVENCTO, WREG_FENHIST.FHST_DTVENCTO);

            /*" -544- IF (V1HIST-OPERACAO NOT LESS 100) AND (V1HIST-OPERACAO LESS 200) */

            if ((V1HIST_OPERACAO >= 100) && (V1HIST_OPERACAO < 200))
            {

                /*" -545- MOVE '0' TO FHST-SITUACAO */
                _.Move("0", WREG_FENHIST.FHST_SITUACAO);

                /*" -546- ELSE */
            }
            else
            {


                /*" -548- IF (V1HIST-OPERACAO NOT LESS 200) AND (V1HIST-OPERACAO LESS 300) */

                if ((V1HIST_OPERACAO >= 200) && (V1HIST_OPERACAO < 300))
                {

                    /*" -549- MOVE '1' TO FHST-SITUACAO */
                    _.Move("1", WREG_FENHIST.FHST_SITUACAO);

                    /*" -550- ELSE */
                }
                else
                {


                    /*" -552- IF (V1HIST-OPERACAO NOT LESS 300) AND (V1HIST-OPERACAO LESS 400) */

                    if ((V1HIST_OPERACAO >= 300) && (V1HIST_OPERACAO < 400))
                    {

                        /*" -553- MOVE '0' TO FHST-SITUACAO */
                        _.Move("0", WREG_FENHIST.FHST_SITUACAO);

                        /*" -554- ELSE */
                    }
                    else
                    {


                        /*" -556- IF (V1HIST-OPERACAO NOT LESS 400) AND (V1HIST-OPERACAO LESS 500) */

                        if ((V1HIST_OPERACAO >= 400) && (V1HIST_OPERACAO < 500))
                        {

                            /*" -557- MOVE '2' TO FHST-SITUACAO */
                            _.Move("2", WREG_FENHIST.FHST_SITUACAO);

                            /*" -558- ELSE */
                        }
                        else
                        {


                            /*" -560- IF (V1HIST-OPERACAO NOT LESS 500) AND (V1HIST-OPERACAO LESS 600) */

                            if ((V1HIST_OPERACAO >= 500) && (V1HIST_OPERACAO < 600))
                            {

                                /*" -561- MOVE '0' TO FHST-SITUACAO */
                                _.Move("0", WREG_FENHIST.FHST_SITUACAO);

                                /*" -562- ELSE */
                            }
                            else
                            {


                                /*" -564- DISPLAY 'R1000-00 OPERACAO INVALIDA = ' V1HIST-OPERACAO */
                                _.Display($"R1000-00 OPERACAO INVALIDA = {V1HIST_OPERACAO}");

                                /*" -566- GO TO R9999-00-ROT-ERRO. */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -568- WRITE REG-FENHIST FROM WREG-FENHIST. */
            _.Move(WREG_FENHIST.GetMoveValues(), REG_FENHIST);

            FENHIST.Write(REG_FENHIST.GetMoveValues().ToString());

            /*" -570- ADD 1 TO AC-G-FENHIST */
            AREA_DE_WORK.AC_G_FENHIST.Value = AREA_DE_WORK.AC_G_FENHIST + 1;

            /*" -570- PERFORM R0910-00-FETCH-V1HISTOPARC. */

            R0910_00_FETCH_V1HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9000_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -585- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -586- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -587- DISPLAY '*   FN0401B - RELACAO COBRANCA DIARIA      *' */
            _.Display($"*   FN0401B - RELACAO COBRANCA DIARIA      *");

            /*" -588- DISPLAY '*   -------   ------- -------- ------      *' */
            _.Display($"*   -------   ------- -------- ------      *");

            /*" -589- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -590- DISPLAY '*   NAO HOUVE MOVIMENTACAO                 *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO                 *");

            /*" -591- DISPLAY '*   NESTA DATA ' */
            _.Display($"*   NESTA DATA ");

            /*" -592- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -592- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -607- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -609- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -609- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -611- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}