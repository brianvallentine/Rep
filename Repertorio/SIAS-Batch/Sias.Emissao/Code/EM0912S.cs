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
using Sias.Emissao.DB2.EM0912S;

namespace Code
{
    public class EM0912S
    {
        public bool IsCall { get; set; }

        public EM0912S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0912S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  JOYCE                              *      */
        /*"      *   DATA CODIFICACAO .......  FEVEREIRO/2003                     *      */
        /*"      *   VERSAO ......... .......  29012009 17:00HS                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZA ITENS APOLICE DE          *      */
        /*"      *                             MULTIRISCO                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              BOOK              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * APOLICES                            APOLICES          INPUT    *      */
        /*"      * ENDOSSOS                            ENDOSSOS          INPUT    *      */
        /*"      * MR_PROPOSTA_ITEM                    MRPROITE          INPUT    *      */
        /*"      * MR_PROPOSTA_COBER                   MRPROCOR          INPUT    *      */
        /*"      * MR_PROP_BENS_SEGUR                  MRPROBEN          INPUT    *      */
        /*"      * PROPOSTA_CLAUSULAS                  PROPOCLA          INPUT    *      */
        /*"      * MR_APOLICE_ITEM                     MRAPOITE          OUTPUT   *      */
        /*"      * MR_APOLICE_COBER                    MRAPOCOB          OUTPUT   *      */
        /*"      * APOLICE_CLAUSULAS                   APOLICLA          OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CADMUS 18.768                                    *      */
        /*"      *                                                                *      */
        /*"      *             - PASSA A TRATAR O DESCONTO COMERCIAL              *      */
        /*"      *               PARA O PRODUTO 1804.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/02/2009 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"BRSEG * INCLUSAO TRATAMENTO RENOVACAO AUTOMATICA COM DEBITO C/C        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WNULL-COD-BENEF            PIC S9(004)    VALUE +0  COMP.*/
        public IntBasis WNULL_COD_BENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-FONTE                PIC S9(004)    VALUE +0  COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-NRPROPOS             PIC S9(009)    VALUE +0  COMP.*/
        public IntBasis WHOST_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WHOST-NUM-APOL             PIC S9(013)    VALUE +0  COMP-3*/
        public IntBasis WHOST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    WHOST-NRENDOS              PIC S9(009)    VALUE +0  COMP.*/
        public IntBasis WHOST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WHOST-DTMOVABE             PIC  X(010).*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTINIVIG             PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-CODCORR              PIC S9(009)    VALUE +0  COMP.*/
        public IntBasis WHOST_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WS-TOT-IMP-SEGURADA-IX     PIC S9(015)V99 VALUE +0  COMP.*/
        public DoubleBasis WS_TOT_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77    WS-TOT-IMP-SEGURADA-VAR    PIC S9(015)V99 VALUE +0  COMP.*/
        public DoubleBasis WS_TOT_IMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77    WS-TOT-PRM-TARIFARIO-IX    PIC S9(015)V99 VALUE +0  COMP.*/
        public DoubleBasis WS_TOT_PRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77    WS-TOT-PRM-TARIFARIO-VAR   PIC S9(015)V99 VALUE +0  COMP.*/
        public DoubleBasis WS_TOT_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77    VIND-COD-EMP              PIC S9(004)     VALUE +0  COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)     VALUE +0  COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public EM0912S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0912S_AREA_DE_WORK();
        public class EM0912S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WFIM-MRPROITE          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MRPROITE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-MRPROCOR          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MRPROCOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PROPOCLA          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PROPOCLA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PROPOCOB          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PROPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-S-MRPROITE          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_MRPROITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-MRAPOITE          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_MRAPOITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-MRPROCOR          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_MRPROCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-MRAPOCOB          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_MRAPOCOB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-MRPROBEN          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-MRPROBEN          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-BENSCOBER         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-BENSCOBER         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-PROPCLAU          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-APOLCLAU          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-PROPCOBER         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_PROPCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-APOLCOBER         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_APOLCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-APOLICOB          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_APOLICOB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        WABEND.*/
            public EM0912S_WABEND WABEND { get; set; } = new EM0912S_WABEND();
            public class EM0912S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0912S'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0912S");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01               LK-PROPOSTA.*/
            }
        }
        public EM0912S_LK_PROPOSTA LK_PROPOSTA { get; set; } = new EM0912S_LK_PROPOSTA();
        public class EM0912S_LK_PROPOSTA : VarBasis
        {
            /*"  05             LK-FONTE             PIC S9(004)        COMP.*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-NRPROPOS          PIC S9(009)        COMP.*/
            public IntBasis LK_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-NUM-APOL          PIC S9(013)        COMP-3.*/
            public IntBasis LK_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05             LK-NRENDOS           PIC S9(009)        COMP.*/
            public IntBasis LK_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-DTMOVABE          PIC  X(010).*/
            public StringBasis LK_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05             LK-CODCORR           PIC S9(009)        COMP.*/
            public IntBasis LK_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-RETORNO           PIC  X(070).*/
            public StringBasis LK_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05             LK-CODPRODU          PIC S9(004)        COMP.*/
            public IntBasis LK_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-S-MRPROITE        PIC  9(004).*/
            public IntBasis LK_S_MRPROITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-MRAPOITE        PIC  9(004).*/
            public IntBasis LK_I_MRAPOITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-MRPROCOR        PIC  9(004).*/
            public IntBasis LK_S_MRPROCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-MRAPOCOB        PIC  9(004).*/
            public IntBasis LK_I_MRAPOCOB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-MRPROBEN        PIC  9(004).*/
            public IntBasis LK_S_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-MRPROBEN        PIC  9(004).*/
            public IntBasis LK_I_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-BENSCOBER       PIC  9(004).*/
            public IntBasis LK_S_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-BENSCOBER       PIC  9(004).*/
            public IntBasis LK_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-PROPCLAU        PIC  9(004).*/
            public IntBasis LK_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-APOLCLAU        PIC  9(004).*/
            public IntBasis LK_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-PROPCOBER       PIC  9(004).*/
            public IntBasis LK_S_PROPCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-APOLCOBER       PIC  9(004).*/
            public IntBasis LK_I_APOLCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-EMISDIARIA      PIC  9(004).*/
            public IntBasis LK_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-APOLICOB        PIC  9(004).*/
            public IntBasis LK_I_APOLICOB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }


        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.MRBENSEG MRBENSEG { get; set; } = new Dclgens.MRBENSEG();
        public Dclgens.MRPROITE MRPROITE { get; set; } = new Dclgens.MRPROITE();
        public Dclgens.MRAPOITE MRAPOITE { get; set; } = new Dclgens.MRAPOITE();
        public Dclgens.MRPROCOR MRPROCOR { get; set; } = new Dclgens.MRPROCOR();
        public Dclgens.MRPROQUE MRPROQUE { get; set; } = new Dclgens.MRPROQUE();
        public Dclgens.MRAPOCOB MRAPOCOB { get; set; } = new Dclgens.MRAPOCOB();
        public Dclgens.PROPOCLA PROPOCLA { get; set; } = new Dclgens.PROPOCLA();
        public Dclgens.APOLICLA APOLICLA { get; set; } = new Dclgens.APOLICLA();
        public Dclgens.PROPOCOB PROPOCOB { get; set; } = new Dclgens.PROPOCOB();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public EM0912S_CSR_MRPROITE CSR_MRPROITE { get; set; } = new EM0912S_CSR_MRPROITE();
        public EM0912S_CSR_MRPROCOR CSR_MRPROCOR { get; set; } = new EM0912S_CSR_MRPROCOR();
        public EM0912S_V1PROPCLAU V1PROPCLAU { get; set; } = new EM0912S_V1PROPCLAU();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0912S_LK_PROPOSTA EM0912S_LK_PROPOSTA_P) //PROCEDURE DIVISION USING 
        /*LK_PROPOSTA*/
        {
            try
            {
                this.LK_PROPOSTA = EM0912S_LK_PROPOSTA_P;

                /*" -181- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -182- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -185- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -188- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -188- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PROPOSTA, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -212- MOVE ZEROS TO AC-S-MRPROITE AC-I-MRAPOITE AC-S-MRPROCOR AC-I-MRAPOCOB AC-S-MRPROBEN AC-I-MRPROBEN AC-S-BENSCOBER AC-I-BENSCOBER AC-S-PROPCLAU AC-I-APOLCLAU AC-S-PROPCOBER AC-I-APOLCOBER AC-I-APOLICOB WS-TOT-IMP-SEGURADA-IX WS-TOT-IMP-SEGURADA-VAR WS-TOT-PRM-TARIFARIO-IX WS-TOT-PRM-TARIFARIO-VAR. */
            _.Move(0, AREA_DE_WORK.AC_S_MRPROITE, AREA_DE_WORK.AC_I_MRAPOITE, AREA_DE_WORK.AC_S_MRPROCOR, AREA_DE_WORK.AC_I_MRAPOCOB, AREA_DE_WORK.AC_S_MRPROBEN, AREA_DE_WORK.AC_I_MRPROBEN, AREA_DE_WORK.AC_S_BENSCOBER, AREA_DE_WORK.AC_I_BENSCOBER, AREA_DE_WORK.AC_S_PROPCLAU, AREA_DE_WORK.AC_I_APOLCLAU, AREA_DE_WORK.AC_S_PROPCOBER, AREA_DE_WORK.AC_I_APOLCOBER, AREA_DE_WORK.AC_I_APOLICOB, WS_TOT_IMP_SEGURADA_IX, WS_TOT_IMP_SEGURADA_VAR, WS_TOT_PRM_TARIFARIO_IX, WS_TOT_PRM_TARIFARIO_VAR);

            /*" -213- IF LK-CODPRODU EQUAL 99 */

            if (LK_PROPOSTA.LK_CODPRODU == 99)
            {

                /*" -215- GO TO R0000-90-FINAL. */

                R0000_90_FINAL(); //GOTO
                return;
            }


            /*" -216- MOVE LK-FONTE TO WHOST-FONTE */
            _.Move(LK_PROPOSTA.LK_FONTE, WHOST_FONTE);

            /*" -217- MOVE LK-NRPROPOS TO WHOST-NRPROPOS */
            _.Move(LK_PROPOSTA.LK_NRPROPOS, WHOST_NRPROPOS);

            /*" -218- MOVE LK-NUM-APOL TO WHOST-NUM-APOL */
            _.Move(LK_PROPOSTA.LK_NUM_APOL, WHOST_NUM_APOL);

            /*" -219- MOVE LK-NRENDOS TO WHOST-NRENDOS */
            _.Move(LK_PROPOSTA.LK_NRENDOS, WHOST_NRENDOS);

            /*" -220- MOVE LK-DTMOVABE TO WHOST-DTMOVABE */
            _.Move(LK_PROPOSTA.LK_DTMOVABE, WHOST_DTMOVABE);

            /*" -222- MOVE LK-CODCORR TO WHOST-CODCORR */
            _.Move(LK_PROPOSTA.LK_CODCORR, WHOST_CODCORR);

            /*" -222- PERFORM R1000-00-PROCESSA-REGISTRO. */

            R1000_00_PROCESSA_REGISTRO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINAL */

            R0000_90_FINAL();

        }

        [StopWatch]
        /*" R0000-90-FINAL */
        private void R0000_90_FINAL(bool isPerform = false)
        {
            /*" -227- MOVE AC-S-MRPROITE TO LK-S-MRPROITE */
            _.Move(AREA_DE_WORK.AC_S_MRPROITE, LK_PROPOSTA.LK_S_MRPROITE);

            /*" -228- MOVE AC-I-MRAPOITE TO LK-I-MRAPOITE */
            _.Move(AREA_DE_WORK.AC_I_MRAPOITE, LK_PROPOSTA.LK_I_MRAPOITE);

            /*" -229- MOVE AC-S-MRPROCOR TO LK-S-MRPROCOR */
            _.Move(AREA_DE_WORK.AC_S_MRPROCOR, LK_PROPOSTA.LK_S_MRPROCOR);

            /*" -230- MOVE AC-I-MRAPOCOB TO LK-I-MRAPOCOB */
            _.Move(AREA_DE_WORK.AC_I_MRAPOCOB, LK_PROPOSTA.LK_I_MRAPOCOB);

            /*" -231- MOVE AC-S-MRPROBEN TO LK-S-MRPROBEN */
            _.Move(AREA_DE_WORK.AC_S_MRPROBEN, LK_PROPOSTA.LK_S_MRPROBEN);

            /*" -232- MOVE AC-I-MRPROBEN TO LK-I-MRPROBEN */
            _.Move(AREA_DE_WORK.AC_I_MRPROBEN, LK_PROPOSTA.LK_I_MRPROBEN);

            /*" -233- MOVE AC-S-BENSCOBER TO LK-S-BENSCOBER */
            _.Move(AREA_DE_WORK.AC_S_BENSCOBER, LK_PROPOSTA.LK_S_BENSCOBER);

            /*" -234- MOVE AC-I-BENSCOBER TO LK-I-BENSCOBER */
            _.Move(AREA_DE_WORK.AC_I_BENSCOBER, LK_PROPOSTA.LK_I_BENSCOBER);

            /*" -235- MOVE AC-S-PROPCLAU TO LK-S-PROPCLAU */
            _.Move(AREA_DE_WORK.AC_S_PROPCLAU, LK_PROPOSTA.LK_S_PROPCLAU);

            /*" -236- MOVE AC-I-APOLCLAU TO LK-I-APOLCLAU */
            _.Move(AREA_DE_WORK.AC_I_APOLCLAU, LK_PROPOSTA.LK_I_APOLCLAU);

            /*" -237- MOVE AC-S-PROPCOBER TO LK-S-PROPCOBER */
            _.Move(AREA_DE_WORK.AC_S_PROPCOBER, LK_PROPOSTA.LK_S_PROPCOBER);

            /*" -238- MOVE AC-I-APOLCOBER TO LK-I-APOLCOBER */
            _.Move(AREA_DE_WORK.AC_I_APOLCOBER, LK_PROPOSTA.LK_I_APOLCOBER);

            /*" -240- MOVE 0 TO LK-I-EMISDIARIA */
            _.Move(0, LK_PROPOSTA.LK_I_EMISDIARIA);

            /*" -242- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -242- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -253- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -255- PERFORM R1100-00-SELECT-APOL-ENDOSSO. */

            R1100_00_SELECT_APOL_ENDOSSO_SECTION();

            /*" -256- PERFORM R2100-00-DECLARE-MR-PROP-ITEM. */

            R2100_00_DECLARE_MR_PROP_ITEM_SECTION();

            /*" -257- MOVE SPACES TO WFIM-MRPROITE. */
            _.Move("", AREA_DE_WORK.WFIM_MRPROITE);

            /*" -260- PERFORM R2110-00-INSERT-MR-APOL-ITEM UNTIL WFIM-MRPROITE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MRPROITE.IsEmpty()))
            {

                R2110_00_INSERT_MR_APOL_ITEM_SECTION();
            }

            /*" -261- PERFORM R2300-00-DECLARE-MR-PROP-COBER. */

            R2300_00_DECLARE_MR_PROP_COBER_SECTION();

            /*" -262- MOVE SPACES TO WFIM-MRPROCOR. */
            _.Move("", AREA_DE_WORK.WFIM_MRPROCOR);

            /*" -265- PERFORM R2310-00-INSERT-MR-APOL-COBER UNTIL WFIM-MRPROCOR NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MRPROCOR.IsEmpty()))
            {

                R2310_00_INSERT_MR_APOL_COBER_SECTION();
            }

            /*" -267- PERFORM R2340-00-INSERT-APOLICOB. */

            R2340_00_INSERT_APOLICOB_SECTION();

            /*" -269- PERFORM R2400-00-UPDATE-MR-BENS-SEG. */

            R2400_00_UPDATE_MR_BENS_SEG_SECTION();

            /*" -271- PERFORM R2500-00-UPDATE-MR-PROP-QUEST. */

            R2500_00_UPDATE_MR_PROP_QUEST_SECTION();

            /*" -272- PERFORM R2600-00-DECLARE-PROP-CLAUS. */

            R2600_00_DECLARE_PROP_CLAUS_SECTION();

            /*" -273- MOVE SPACES TO WFIM-PROPOCLA. */
            _.Move("", AREA_DE_WORK.WFIM_PROPOCLA);

            /*" -274- PERFORM R2610-00-INSERT-APOL-CLAUS UNTIL WFIM-PROPOCLA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PROPOCLA.IsEmpty()))
            {

                R2610_00_INSERT_APOL_CLAUS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-APOL-ENDOSSO-SECTION */
        private void R1100_00_SELECT_APOL_ENDOSSO_SECTION()
        {
            /*" -285- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -301- PERFORM R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1 */

            R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1();

            /*" -304- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -305- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -307- MOVE 'V1ENDOSSO (DOCUMENTO NAO CADASTRADO)' TO LK-RETORNO */
                    _.Move("V1ENDOSSO (DOCUMENTO NAO CADASTRADO)", LK_PROPOSTA.LK_RETORNO);

                    /*" -308- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -309- ELSE */
                }
                else
                {


                    /*" -311- MOVE 'PROBLEMAS NO SELECT (V1ENDOSSO) ... ' TO LK-RETORNO */
                    _.Move("PROBLEMAS NO SELECT (V1ENDOSSO) ... ", LK_PROPOSTA.LK_RETORNO);

                    /*" -313- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -314- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -314- MOVE ZEROS TO APOLICES-COD-PRODUTO. */
                _.Move(0, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-APOL-ENDOSSO-DB-SELECT-1 */
        public void R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1()
        {
            /*" -301- EXEC SQL SELECT T1.ORGAO_EMISSOR, T1.RAMO_EMISSOR, T2.COD_FONTE, T2.TIPO_ENDOSSO , T1.COD_PRODUTO INTO :APOLICES-ORGAO-EMISSOR, :APOLICES-RAMO-EMISSOR, :ENDOSSOS-COD-FONTE, :ENDOSSOS-TIPO-ENDOSSO, :APOLICES-COD-PRODUTO:VIND-CODPRODU FROM SEGUROS.APOLICES T1, SEGUROS.ENDOSSOS T2 WHERE T2.NUM_APOLICE = :WHOST-NUM-APOL AND T2.NUM_ENDOSSO = :WHOST-NRENDOS AND T1.NUM_APOLICE = T2.NUM_APOLICE END-EXEC. */

            var r1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1 = new R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-MR-PROP-ITEM-SECTION */
        private void R2100_00_DECLARE_MR_PROP_ITEM_SECTION()
        {
            /*" -325- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -350- PERFORM R2100_00_DECLARE_MR_PROP_ITEM_DB_DECLARE_1 */

            R2100_00_DECLARE_MR_PROP_ITEM_DB_DECLARE_1();

            /*" -352- PERFORM R2100_00_DECLARE_MR_PROP_ITEM_DB_OPEN_1 */

            R2100_00_DECLARE_MR_PROP_ITEM_DB_OPEN_1();

            /*" -355- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -357- MOVE 'PROBLEMAS NO OPEN (CSR-MRPROITE) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (CSR-MRPROITE) ", LK_PROPOSTA.LK_RETORNO);

                /*" -357- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-MR-PROP-ITEM-DB-DECLARE-1 */
        public void R2100_00_DECLARE_MR_PROP_ITEM_DB_DECLARE_1()
        {
            /*" -350- EXEC SQL DECLARE CSR-MRPROITE CURSOR FOR SELECT NUM_ITEM, COD_PRODUTO, NUM_VERSAO, NUM_TP_MORA_IMOVEL, NUM_TP_OCUP_IMOVEL, DTH_INI_VIGENCIA, DTH_FIM_VIGENCIA, IND_TIPO_SEGURO, QTD_RENOVACAO, STA_PROPOSTA_ITEM, NUM_PROPOSTA_SIMU, OCORR_ENDERECO, PCT_DESC_FIDEL, PCT_DESC_AGRUP, PCT_DESC_EXPER, COD_CLIENTE, COD_BENEFICIARIO, VALUE(IND_RENOVACAO_AUT, 'N' ), PCT_DESC_FUNC_PUBL, PCT_DESC_COMERCIAL FROM SEGUROS.MR_PROPOSTA_ITEM WHERE COD_FONTE = :WHOST-FONTE AND NUM_PROPOSTA = :WHOST-NRPROPOS ORDER BY NUM_ITEM END-EXEC. */
            CSR_MRPROITE = new EM0912S_CSR_MRPROITE(true);
            string GetQuery_CSR_MRPROITE()
            {
                var query = @$"SELECT NUM_ITEM
							, 
							COD_PRODUTO
							, 
							NUM_VERSAO
							, 
							NUM_TP_MORA_IMOVEL
							, 
							NUM_TP_OCUP_IMOVEL
							, 
							DTH_INI_VIGENCIA
							, 
							DTH_FIM_VIGENCIA
							, 
							IND_TIPO_SEGURO
							, 
							QTD_RENOVACAO
							, 
							STA_PROPOSTA_ITEM
							, 
							NUM_PROPOSTA_SIMU
							, 
							OCORR_ENDERECO
							, 
							PCT_DESC_FIDEL
							, 
							PCT_DESC_AGRUP
							, 
							PCT_DESC_EXPER
							, 
							COD_CLIENTE
							, 
							COD_BENEFICIARIO
							, 
							VALUE(IND_RENOVACAO_AUT
							, 'N' )
							, 
							PCT_DESC_FUNC_PUBL
							, 
							PCT_DESC_COMERCIAL 
							FROM SEGUROS.MR_PROPOSTA_ITEM 
							WHERE COD_FONTE = '{WHOST_FONTE}' 
							AND NUM_PROPOSTA = '{WHOST_NRPROPOS}' 
							ORDER BY NUM_ITEM";

                return query;
            }
            CSR_MRPROITE.GetQueryEvent += GetQuery_CSR_MRPROITE;

        }

        [StopWatch]
        /*" R2100-00-DECLARE-MR-PROP-ITEM-DB-OPEN-1 */
        public void R2100_00_DECLARE_MR_PROP_ITEM_DB_OPEN_1()
        {
            /*" -352- EXEC SQL OPEN CSR-MRPROITE END-EXEC. */

            CSR_MRPROITE.Open();

        }

        [StopWatch]
        /*" R2300-00-DECLARE-MR-PROP-COBER-DB-DECLARE-1 */
        public void R2300_00_DECLARE_MR_PROP_COBER_DB_DECLARE_1()
        {
            /*" -554- EXEC SQL DECLARE CSR-MRPROCOR CURSOR FOR SELECT COD_COBERTURA, NUM_ITEM, RAMO_COBERTURA, MODALI_COBERTURA, DTH_INI_VIGENCIA, DTH_FIM_VIGENCIA, IMP_SEGURADA_IX, IMP_SEGURADA_VAR, TAXA_IS_COBER, PRM_TARIFARIO_IX, PRM_TARIFARIO_VAR, PCT_FRANQUIA, VAL_FRANQ_OBR_IX, SIT_REGISTRO, COD_EMPRESA FROM SEGUROS.MR_PROPOSTA_COBER WHERE COD_FONTE = :WHOST-FONTE AND NUM_PROPOSTA = :WHOST-NRPROPOS ORDER BY NUM_ITEM, COD_COBERTURA END-EXEC. */
            CSR_MRPROCOR = new EM0912S_CSR_MRPROCOR(true);
            string GetQuery_CSR_MRPROCOR()
            {
                var query = @$"SELECT COD_COBERTURA
							, 
							NUM_ITEM
							, 
							RAMO_COBERTURA
							, 
							MODALI_COBERTURA
							, 
							DTH_INI_VIGENCIA
							, 
							DTH_FIM_VIGENCIA
							, 
							IMP_SEGURADA_IX
							, 
							IMP_SEGURADA_VAR
							, 
							TAXA_IS_COBER
							, 
							PRM_TARIFARIO_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							PCT_FRANQUIA
							, 
							VAL_FRANQ_OBR_IX
							, 
							SIT_REGISTRO
							, 
							COD_EMPRESA 
							FROM SEGUROS.MR_PROPOSTA_COBER 
							WHERE COD_FONTE = '{WHOST_FONTE}' 
							AND NUM_PROPOSTA = '{WHOST_NRPROPOS}' 
							ORDER BY NUM_ITEM
							, 
							COD_COBERTURA";

                return query;
            }
            CSR_MRPROCOR.GetQueryEvent += GetQuery_CSR_MRPROCOR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-INSERT-MR-APOL-ITEM-SECTION */
        private void R2110_00_INSERT_MR_APOL_ITEM_SECTION()
        {
            /*" -367- PERFORM R2120-00-FETCH-MR-PROP-ITEM */

            R2120_00_FETCH_MR_PROP_ITEM_SECTION();

            /*" -368- IF WFIM-MRPROITE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_MRPROITE.IsEmpty())
            {

                /*" -370- GO TO R2110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -372- PERFORM R2130-00-MONTA-MR-APOL-ITEM */

            R2130_00_MONTA_MR_APOL_ITEM_SECTION();

            /*" -374- MOVE '211' TO WNR-EXEC-SQL. */
            _.Move("211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -422- PERFORM R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1 */

            R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1();

            /*" -425- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -427- MOVE 'MR_APOLICE_ITEM (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("MR_APOLICE_ITEM (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -429- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -432- MOVE 'MR_APOLICE_ITEM (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("MR_APOLICE_ITEM (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -434- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -434- ADD 1 TO AC-I-MRAPOITE. */
            AREA_DE_WORK.AC_I_MRAPOITE.Value = AREA_DE_WORK.AC_I_MRAPOITE + 1;

        }

        [StopWatch]
        /*" R2110-00-INSERT-MR-APOL-ITEM-DB-INSERT-1 */
        public void R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1()
        {
            /*" -422- EXEC SQL INSERT INTO SEGUROS.MR_APOLICE_ITEM (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_PRODUTO, NUM_VERSAO, NUM_TP_MORA_IMOVEL, NUM_TP_OCUP_IMOVEL, DTH_INI_VIG_ITEM, DTH_FIM_VIG_ITEM, QTD_RENOVACAO, OCORR_ENDERECO, STA_PROP_ITEM, PCT_DESC_FIDEL, PCT_DESC_AGRUP, PCT_DESC_EXPER, DTH_TIMESTAMP, COD_CLIENTE, COD_BENEFICIARIO, IND_RENOVACAO_AUT, NUM_PROPOSTA_SIMU, PCT_DESC_FUNC_PUBL, PCT_DESC_COMERCIAL) VALUES (:MRAPOITE-NUM-APOLICE, :MRAPOITE-NUM-ENDOSSO, :MRAPOITE-NUM-ITEM, :MRAPOITE-COD-PRODUTO, :MRAPOITE-NUM-VERSAO, :MRAPOITE-NUM-TP-MORA-IMOVEL, :MRAPOITE-NUM-TP-OCUP-IMOVEL, :MRAPOITE-DTH-INI-VIG-ITEM, :MRAPOITE-DTH-FIM-VIG-ITEM, :MRAPOITE-QTD-RENOVACAO, :MRAPOITE-OCORR-ENDERECO, :MRAPOITE-STA-PROP-ITEM, :MRAPOITE-PCT-DESC-FIDEL, :MRAPOITE-PCT-DESC-AGRUP, :MRAPOITE-PCT-DESC-EXPER, CURRENT TIMESTAMP, :MRAPOITE-COD-CLIENTE, :MRAPOITE-COD-BENEFICIARIO :WNULL-COD-BENEF, :MRAPOITE-IND-RENOVACAO-AUT, :MRAPOITE-NUM-PROPOSTA-SIMU, :MRAPOITE-PCT-DESC-FUNC-PUBL, :MRAPOITE-PCT-DESC-COMERCIAL) END-EXEC. */

            var r2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1 = new R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1()
            {
                MRAPOITE_NUM_APOLICE = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_APOLICE.ToString(),
                MRAPOITE_NUM_ENDOSSO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ENDOSSO.ToString(),
                MRAPOITE_NUM_ITEM = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM.ToString(),
                MRAPOITE_COD_PRODUTO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_COD_PRODUTO.ToString(),
                MRAPOITE_NUM_VERSAO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_VERSAO.ToString(),
                MRAPOITE_NUM_TP_MORA_IMOVEL = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_TP_MORA_IMOVEL.ToString(),
                MRAPOITE_NUM_TP_OCUP_IMOVEL = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_TP_OCUP_IMOVEL.ToString(),
                MRAPOITE_DTH_INI_VIG_ITEM = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_DTH_INI_VIG_ITEM.ToString(),
                MRAPOITE_DTH_FIM_VIG_ITEM = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_DTH_FIM_VIG_ITEM.ToString(),
                MRAPOITE_QTD_RENOVACAO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_QTD_RENOVACAO.ToString(),
                MRAPOITE_OCORR_ENDERECO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_OCORR_ENDERECO.ToString(),
                MRAPOITE_STA_PROP_ITEM = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_STA_PROP_ITEM.ToString(),
                MRAPOITE_PCT_DESC_FIDEL = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL.ToString(),
                MRAPOITE_PCT_DESC_AGRUP = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_AGRUP.ToString(),
                MRAPOITE_PCT_DESC_EXPER = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_EXPER.ToString(),
                MRAPOITE_COD_CLIENTE = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_COD_CLIENTE.ToString(),
                MRAPOITE_COD_BENEFICIARIO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_COD_BENEFICIARIO.ToString(),
                WNULL_COD_BENEF = WNULL_COD_BENEF.ToString(),
                MRAPOITE_IND_RENOVACAO_AUT = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_IND_RENOVACAO_AUT.ToString(),
                MRAPOITE_NUM_PROPOSTA_SIMU = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_PROPOSTA_SIMU.ToString(),
                MRAPOITE_PCT_DESC_FUNC_PUBL = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FUNC_PUBL.ToString(),
                MRAPOITE_PCT_DESC_COMERCIAL = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_COMERCIAL.ToString(),
            };

            R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1.Execute(r2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-FETCH-MR-PROP-ITEM-SECTION */
        private void R2120_00_FETCH_MR_PROP_ITEM_SECTION()
        {
            /*" -445- MOVE '212' TO WNR-EXEC-SQL. */
            _.Move("212", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -466- PERFORM R2120_00_FETCH_MR_PROP_ITEM_DB_FETCH_1 */

            R2120_00_FETCH_MR_PROP_ITEM_DB_FETCH_1();

            /*" -469- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -470- MOVE 'S' TO WFIM-MRPROITE */
                _.Move("S", AREA_DE_WORK.WFIM_MRPROITE);

                /*" -470- PERFORM R2120_00_FETCH_MR_PROP_ITEM_DB_CLOSE_1 */

                R2120_00_FETCH_MR_PROP_ITEM_DB_CLOSE_1();

                /*" -473- GO TO R2120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -477- DISPLAY 'PROBLEMAS NO FETCH (MR-PROPOSTA-ITEM) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (MR-PROPOSTA-ITEM) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -479- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -479- ADD 1 TO AC-S-MRPROITE. */
            AREA_DE_WORK.AC_S_MRPROITE.Value = AREA_DE_WORK.AC_S_MRPROITE + 1;

        }

        [StopWatch]
        /*" R2120-00-FETCH-MR-PROP-ITEM-DB-FETCH-1 */
        public void R2120_00_FETCH_MR_PROP_ITEM_DB_FETCH_1()
        {
            /*" -466- EXEC SQL FETCH CSR-MRPROITE INTO :MRPROITE-NUM-ITEM, :MRPROITE-COD-PRODUTO, :MRPROITE-NUM-VERSAO, :MRPROITE-NUM-TP-MORA-IMOVEL, :MRPROITE-NUM-TP-OCUP-IMOVEL, :MRPROITE-DTH-INI-VIGENCIA, :MRPROITE-DTH-FIM-VIGENCIA, :MRPROITE-IND-TIPO-SEGURO, :MRPROITE-QTD-RENOVACAO, :MRPROITE-STA-PROPOSTA-ITEM, :MRPROITE-NUM-PROPOSTA-SIMU, :MRPROITE-OCORR-ENDERECO, :MRPROITE-PCT-DESC-FIDEL, :MRPROITE-PCT-DESC-AGRUP, :MRPROITE-PCT-DESC-EXPER, :MRPROITE-COD-CLIENTE, :MRPROITE-COD-BENEFICIARIO :WNULL-COD-BENEF, :MRPROITE-IND-RENOVACAO-AUT, :MRPROITE-PCT-DESC-FUNC-PUBL, :MRPROITE-PCT-DESC-COMERCIAL END-EXEC. */

            if (CSR_MRPROITE.Fetch())
            {
                _.Move(CSR_MRPROITE.MRPROITE_NUM_ITEM, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_ITEM);
                _.Move(CSR_MRPROITE.MRPROITE_COD_PRODUTO, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_COD_PRODUTO);
                _.Move(CSR_MRPROITE.MRPROITE_NUM_VERSAO, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_VERSAO);
                _.Move(CSR_MRPROITE.MRPROITE_NUM_TP_MORA_IMOVEL, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_TP_MORA_IMOVEL);
                _.Move(CSR_MRPROITE.MRPROITE_NUM_TP_OCUP_IMOVEL, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_TP_OCUP_IMOVEL);
                _.Move(CSR_MRPROITE.MRPROITE_DTH_INI_VIGENCIA, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_DTH_INI_VIGENCIA);
                _.Move(CSR_MRPROITE.MRPROITE_DTH_FIM_VIGENCIA, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_DTH_FIM_VIGENCIA);
                _.Move(CSR_MRPROITE.MRPROITE_IND_TIPO_SEGURO, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_IND_TIPO_SEGURO);
                _.Move(CSR_MRPROITE.MRPROITE_QTD_RENOVACAO, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_QTD_RENOVACAO);
                _.Move(CSR_MRPROITE.MRPROITE_STA_PROPOSTA_ITEM, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_STA_PROPOSTA_ITEM);
                _.Move(CSR_MRPROITE.MRPROITE_NUM_PROPOSTA_SIMU, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_PROPOSTA_SIMU);
                _.Move(CSR_MRPROITE.MRPROITE_OCORR_ENDERECO, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_OCORR_ENDERECO);
                _.Move(CSR_MRPROITE.MRPROITE_PCT_DESC_FIDEL, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_FIDEL);
                _.Move(CSR_MRPROITE.MRPROITE_PCT_DESC_AGRUP, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_AGRUP);
                _.Move(CSR_MRPROITE.MRPROITE_PCT_DESC_EXPER, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_EXPER);
                _.Move(CSR_MRPROITE.MRPROITE_COD_CLIENTE, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_COD_CLIENTE);
                _.Move(CSR_MRPROITE.MRPROITE_COD_BENEFICIARIO, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_COD_BENEFICIARIO);
                _.Move(CSR_MRPROITE.WNULL_COD_BENEF, WNULL_COD_BENEF);
                _.Move(CSR_MRPROITE.MRPROITE_IND_RENOVACAO_AUT, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_IND_RENOVACAO_AUT);
                _.Move(CSR_MRPROITE.MRPROITE_PCT_DESC_FUNC_PUBL, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_FUNC_PUBL);
                _.Move(CSR_MRPROITE.MRPROITE_PCT_DESC_COMERCIAL, MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_COMERCIAL);
            }

        }

        [StopWatch]
        /*" R2120-00-FETCH-MR-PROP-ITEM-DB-CLOSE-1 */
        public void R2120_00_FETCH_MR_PROP_ITEM_DB_CLOSE_1()
        {
            /*" -470- EXEC SQL CLOSE CSR-MRPROITE END-EXEC */

            CSR_MRPROITE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-MONTA-MR-APOL-ITEM-SECTION */
        private void R2130_00_MONTA_MR_APOL_ITEM_SECTION()
        {
            /*" -490- MOVE '213' TO WNR-EXEC-SQL. */
            _.Move("213", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -491- MOVE WHOST-NUM-APOL TO MRAPOITE-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_APOLICE);

            /*" -492- MOVE WHOST-NRENDOS TO MRAPOITE-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ENDOSSO);

            /*" -493- MOVE MRPROITE-NUM-ITEM TO MRAPOITE-NUM-ITEM */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_ITEM, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM);

            /*" -494- MOVE MRPROITE-COD-PRODUTO TO MRAPOITE-COD-PRODUTO */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_COD_PRODUTO, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_COD_PRODUTO);

            /*" -495- MOVE MRPROITE-NUM-VERSAO TO MRAPOITE-NUM-VERSAO */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_VERSAO, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_VERSAO);

            /*" -497- MOVE MRPROITE-NUM-TP-MORA-IMOVEL TO MRAPOITE-NUM-TP-MORA-IMOVEL */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_TP_MORA_IMOVEL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_TP_MORA_IMOVEL);

            /*" -499- MOVE MRPROITE-NUM-TP-OCUP-IMOVEL TO MRAPOITE-NUM-TP-OCUP-IMOVEL */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_TP_OCUP_IMOVEL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_TP_OCUP_IMOVEL);

            /*" -500- MOVE MRPROITE-DTH-INI-VIGENCIA TO MRAPOITE-DTH-INI-VIG-ITEM */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_DTH_INI_VIGENCIA, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_DTH_INI_VIG_ITEM);

            /*" -501- MOVE MRPROITE-DTH-FIM-VIGENCIA TO MRAPOITE-DTH-FIM-VIG-ITEM */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_DTH_FIM_VIGENCIA, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_DTH_FIM_VIG_ITEM);

            /*" -502- MOVE MRPROITE-QTD-RENOVACAO TO MRAPOITE-QTD-RENOVACAO */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_QTD_RENOVACAO, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_QTD_RENOVACAO);

            /*" -503- MOVE MRPROITE-OCORR-ENDERECO TO MRAPOITE-OCORR-ENDERECO */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_OCORR_ENDERECO, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_OCORR_ENDERECO);

            /*" -504- MOVE MRPROITE-PCT-DESC-FIDEL TO MRAPOITE-PCT-DESC-FIDEL */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_FIDEL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL);

            /*" -505- MOVE MRPROITE-PCT-DESC-AGRUP TO MRAPOITE-PCT-DESC-AGRUP */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_AGRUP, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_AGRUP);

            /*" -506- MOVE MRPROITE-PCT-DESC-EXPER TO MRAPOITE-PCT-DESC-EXPER */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_EXPER, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_EXPER);

            /*" -509- MOVE MRPROITE-PCT-DESC-FUNC-PUBL TO MRAPOITE-PCT-DESC-FUNC-PUBL */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_FUNC_PUBL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FUNC_PUBL);

            /*" -512- MOVE MRPROITE-PCT-DESC-COMERCIAL TO MRAPOITE-PCT-DESC-COMERCIAL */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_PCT_DESC_COMERCIAL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_COMERCIAL);

            /*" -513- MOVE MRPROITE-COD-CLIENTE TO MRAPOITE-COD-CLIENTE. */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_COD_CLIENTE, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_COD_CLIENTE);

            /*" -514- MOVE MRPROITE-COD-BENEFICIARIO TO MRAPOITE-COD-BENEFICIARIO. */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_COD_BENEFICIARIO, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_COD_BENEFICIARIO);

            /*" -516- MOVE MRPROITE-IND-RENOVACAO-AUT TO MRAPOITE-IND-RENOVACAO-AUT. */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_IND_RENOVACAO_AUT, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_IND_RENOVACAO_AUT);

            /*" -519- MOVE MRPROITE-NUM-PROPOSTA-SIMU TO MRAPOITE-NUM-PROPOSTA-SIMU. */
            _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_NUM_PROPOSTA_SIMU, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_PROPOSTA_SIMU);

            /*" -520- IF ENDOSSOS-TIPO-ENDOSSO = '5' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO == "5")
            {

                /*" -521- MOVE 'I' TO MRAPOITE-STA-PROP-ITEM */
                _.Move("I", MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_STA_PROP_ITEM);

                /*" -522- ELSE */
            }
            else
            {


                /*" -522- MOVE MRPROITE-STA-PROPOSTA-ITEM TO MRAPOITE-STA-PROP-ITEM. */
                _.Move(MRPROITE.DCLMR_PROPOSTA_ITEM.MRPROITE_STA_PROPOSTA_ITEM, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_STA_PROP_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DECLARE-MR-PROP-COBER-SECTION */
        private void R2300_00_DECLARE_MR_PROP_COBER_SECTION()
        {
            /*" -533- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -554- PERFORM R2300_00_DECLARE_MR_PROP_COBER_DB_DECLARE_1 */

            R2300_00_DECLARE_MR_PROP_COBER_DB_DECLARE_1();

            /*" -556- PERFORM R2300_00_DECLARE_MR_PROP_COBER_DB_OPEN_1 */

            R2300_00_DECLARE_MR_PROP_COBER_DB_OPEN_1();

            /*" -559- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -561- MOVE 'PROBLEMAS NO OPEN (CSR-MRPROCOR) ' TO LK-RETORNO */
                _.Move("PROBLEMAS NO OPEN (CSR-MRPROCOR) ", LK_PROPOSTA.LK_RETORNO);

                /*" -561- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-DECLARE-MR-PROP-COBER-DB-OPEN-1 */
        public void R2300_00_DECLARE_MR_PROP_COBER_DB_OPEN_1()
        {
            /*" -556- EXEC SQL OPEN CSR-MRPROCOR END-EXEC. */

            CSR_MRPROCOR.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-PROP-CLAUS-DB-DECLARE-1 */
        public void R2600_00_DECLARE_PROP_CLAUS_DB_DECLARE_1()
        {
            /*" -860- EXEC SQL DECLARE V1PROPCLAU CURSOR FOR SELECT COD_EMPRESA, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, NUM_ITEM, COD_CLAUSULA, LIMITE_INDENIZA_IX, TIPO_CLAUSULA FROM SEGUROS.PROPOSTA_CLAUSULAS WHERE COD_FONTE = :WHOST-FONTE AND NUM_PROPOSTA = :WHOST-NRPROPOS ORDER BY NUM_ITEM END-EXEC. */
            V1PROPCLAU = new EM0912S_V1PROPCLAU(true);
            string GetQuery_V1PROPCLAU()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							RAMO_COBERTURA
							, 
							MODALI_COBERTURA
							, 
							COD_COBERTURA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							NUM_ITEM
							, 
							COD_CLAUSULA
							, 
							LIMITE_INDENIZA_IX
							, 
							TIPO_CLAUSULA 
							FROM SEGUROS.PROPOSTA_CLAUSULAS 
							WHERE COD_FONTE = '{WHOST_FONTE}' 
							AND NUM_PROPOSTA = '{WHOST_NRPROPOS}' 
							ORDER BY NUM_ITEM";

                return query;
            }
            V1PROPCLAU.GetQueryEvent += GetQuery_V1PROPCLAU;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-INSERT-MR-APOL-COBER-SECTION */
        private void R2310_00_INSERT_MR_APOL_COBER_SECTION()
        {
            /*" -571- PERFORM R2320-00-FETCH-MR-PROP-COBER */

            R2320_00_FETCH_MR_PROP_COBER_SECTION();

            /*" -572- IF WFIM-MRPROCOR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_MRPROCOR.IsEmpty())
            {

                /*" -574- GO TO R2310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -576- PERFORM R2330-00-MONTA-MR-APOL-COBER */

            R2330_00_MONTA_MR_APOL_COBER_SECTION();

            /*" -578- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -616- PERFORM R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1 */

            R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1();

            /*" -619- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -621- MOVE 'MR_APOLICE_COBER (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("MR_APOLICE_COBER (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -623- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -624- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -626- MOVE 'MR_APOLICE_COBER (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("MR_APOLICE_COBER (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -628- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -628- ADD 1 TO AC-I-MRAPOCOB. */
            AREA_DE_WORK.AC_I_MRAPOCOB.Value = AREA_DE_WORK.AC_I_MRAPOCOB + 1;

        }

        [StopWatch]
        /*" R2310-00-INSERT-MR-APOL-COBER-DB-INSERT-1 */
        public void R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1()
        {
            /*" -616- EXEC SQL INSERT INTO SEGUROS.MR_APOLICE_COBER (NUM_APOLICE , NUM_ENDOSSO , COD_COBERTURA , NUM_ITEM , RAMO_COBERTURA , MODALI_COBERTURA , DTH_INI_VIG_COBER , DTH_FIM_VIG_COBER , IMP_SEGURADA_IX , IMP_SEGURADA_VAR , TAXA_IS , PRM_TARIFARIO_IX , PRM_TARIFARIO_VAR , VAL_MIN_FRANQ_IX , PCT_FRANQUIA , SIT_REGISTRO , DTH_TIMESTAMP , COD_EMPRESA) VALUES (:MRAPOCOB-NUM-APOLICE, :MRAPOCOB-NUM-ENDOSSO, :MRAPOCOB-COD-COBERTURA, :MRAPOCOB-NUM-ITEM, :MRAPOCOB-RAMO-COBERTURA, :MRAPOCOB-MODALI-COBERTURA, :MRAPOCOB-DTH-INI-VIG-COBER, :MRAPOCOB-DTH-FIM-VIG-COBER, :MRAPOCOB-IMP-SEGURADA-IX, :MRAPOCOB-IMP-SEGURADA-VAR, :MRAPOCOB-TAXA-IS, :MRAPOCOB-PRM-TARIFARIO-IX, :MRAPOCOB-PRM-TARIFARIO-VAR, :MRAPOCOB-VAL-MIN-FRANQ-IX, :MRAPOCOB-PCT-FRANQUIA, :MRAPOCOB-SIT-REGISTRO, CURRENT TIMESTAMP, :MRAPOCOB-COD-EMPRESA) END-EXEC. */

            var r2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1 = new R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1()
            {
                MRAPOCOB_NUM_APOLICE = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE.ToString(),
                MRAPOCOB_NUM_ENDOSSO = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO.ToString(),
                MRAPOCOB_COD_COBERTURA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_COBERTURA.ToString(),
                MRAPOCOB_NUM_ITEM = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ITEM.ToString(),
                MRAPOCOB_RAMO_COBERTURA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_RAMO_COBERTURA.ToString(),
                MRAPOCOB_MODALI_COBERTURA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_MODALI_COBERTURA.ToString(),
                MRAPOCOB_DTH_INI_VIG_COBER = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_DTH_INI_VIG_COBER.ToString(),
                MRAPOCOB_DTH_FIM_VIG_COBER = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_DTH_FIM_VIG_COBER.ToString(),
                MRAPOCOB_IMP_SEGURADA_IX = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_IX.ToString(),
                MRAPOCOB_IMP_SEGURADA_VAR = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_VAR.ToString(),
                MRAPOCOB_TAXA_IS = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_TAXA_IS.ToString(),
                MRAPOCOB_PRM_TARIFARIO_IX = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX.ToString(),
                MRAPOCOB_PRM_TARIFARIO_VAR = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_VAR.ToString(),
                MRAPOCOB_VAL_MIN_FRANQ_IX = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_VAL_MIN_FRANQ_IX.ToString(),
                MRAPOCOB_PCT_FRANQUIA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PCT_FRANQUIA.ToString(),
                MRAPOCOB_SIT_REGISTRO = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_SIT_REGISTRO.ToString(),
                MRAPOCOB_COD_EMPRESA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_EMPRESA.ToString(),
            };

            R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1.Execute(r2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-FETCH-MR-PROP-COBER-SECTION */
        private void R2320_00_FETCH_MR_PROP_COBER_SECTION()
        {
            /*" -639- MOVE '232' TO WNR-EXEC-SQL. */
            _.Move("232", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -655- PERFORM R2320_00_FETCH_MR_PROP_COBER_DB_FETCH_1 */

            R2320_00_FETCH_MR_PROP_COBER_DB_FETCH_1();

            /*" -658- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -659- MOVE 'S' TO WFIM-MRPROCOR */
                _.Move("S", AREA_DE_WORK.WFIM_MRPROCOR);

                /*" -659- PERFORM R2320_00_FETCH_MR_PROP_COBER_DB_CLOSE_1 */

                R2320_00_FETCH_MR_PROP_COBER_DB_CLOSE_1();

                /*" -662- GO TO R2320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -666- DISPLAY 'PROBLEMAS NO FETCH (CSR-MRPROCOR) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (CSR-MRPROCOR) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -668- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -668- ADD 1 TO AC-S-MRPROCOR. */
            AREA_DE_WORK.AC_S_MRPROCOR.Value = AREA_DE_WORK.AC_S_MRPROCOR + 1;

        }

        [StopWatch]
        /*" R2320-00-FETCH-MR-PROP-COBER-DB-FETCH-1 */
        public void R2320_00_FETCH_MR_PROP_COBER_DB_FETCH_1()
        {
            /*" -655- EXEC SQL FETCH CSR-MRPROCOR INTO :MRPROCOR-COD-COBERTURA, :MRPROCOR-NUM-ITEM, :MRPROCOR-RAMO-COBERTURA, :MRPROCOR-MODALI-COBERTURA, :MRPROCOR-DTH-INI-VIGENCIA, :MRPROCOR-DTH-FIM-VIGENCIA, :MRPROCOR-IMP-SEGURADA-IX, :MRPROCOR-IMP-SEGURADA-VAR, :MRPROCOR-TAXA-IS-COBER, :MRPROCOR-PRM-TARIFARIO-IX, :MRPROCOR-PRM-TARIFARIO-VAR, :MRPROCOR-PCT-FRANQUIA, :MRPROCOR-VAL-FRANQ-OBR-IX, :MRPROCOR-SIT-REGISTRO, :MRPROCOR-COD-EMPRESA END-EXEC. */

            if (CSR_MRPROCOR.Fetch())
            {
                _.Move(CSR_MRPROCOR.MRPROCOR_COD_COBERTURA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_COD_COBERTURA);
                _.Move(CSR_MRPROCOR.MRPROCOR_NUM_ITEM, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_NUM_ITEM);
                _.Move(CSR_MRPROCOR.MRPROCOR_RAMO_COBERTURA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_RAMO_COBERTURA);
                _.Move(CSR_MRPROCOR.MRPROCOR_MODALI_COBERTURA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_MODALI_COBERTURA);
                _.Move(CSR_MRPROCOR.MRPROCOR_DTH_INI_VIGENCIA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_DTH_INI_VIGENCIA);
                _.Move(CSR_MRPROCOR.MRPROCOR_DTH_FIM_VIGENCIA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_DTH_FIM_VIGENCIA);
                _.Move(CSR_MRPROCOR.MRPROCOR_IMP_SEGURADA_IX, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_IMP_SEGURADA_IX);
                _.Move(CSR_MRPROCOR.MRPROCOR_IMP_SEGURADA_VAR, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_IMP_SEGURADA_VAR);
                _.Move(CSR_MRPROCOR.MRPROCOR_TAXA_IS_COBER, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_TAXA_IS_COBER);
                _.Move(CSR_MRPROCOR.MRPROCOR_PRM_TARIFARIO_IX, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PRM_TARIFARIO_IX);
                _.Move(CSR_MRPROCOR.MRPROCOR_PRM_TARIFARIO_VAR, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PRM_TARIFARIO_VAR);
                _.Move(CSR_MRPROCOR.MRPROCOR_PCT_FRANQUIA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PCT_FRANQUIA);
                _.Move(CSR_MRPROCOR.MRPROCOR_VAL_FRANQ_OBR_IX, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_VAL_FRANQ_OBR_IX);
                _.Move(CSR_MRPROCOR.MRPROCOR_SIT_REGISTRO, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_SIT_REGISTRO);
                _.Move(CSR_MRPROCOR.MRPROCOR_COD_EMPRESA, MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R2320-00-FETCH-MR-PROP-COBER-DB-CLOSE-1 */
        public void R2320_00_FETCH_MR_PROP_COBER_DB_CLOSE_1()
        {
            /*" -659- EXEC SQL CLOSE CSR-MRPROCOR END-EXEC */

            CSR_MRPROCOR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2330-00-MONTA-MR-APOL-COBER-SECTION */
        private void R2330_00_MONTA_MR_APOL_COBER_SECTION()
        {
            /*" -679- MOVE '233' TO WNR-EXEC-SQL. */
            _.Move("233", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -680- MOVE WHOST-NUM-APOL TO MRAPOCOB-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE);

            /*" -681- MOVE WHOST-NRENDOS TO MRAPOCOB-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO);

            /*" -682- MOVE MRPROCOR-COD-COBERTURA TO MRAPOCOB-COD-COBERTURA */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_COD_COBERTURA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_COBERTURA);

            /*" -683- MOVE MRPROCOR-NUM-ITEM TO MRAPOCOB-NUM-ITEM */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_NUM_ITEM, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ITEM);

            /*" -684- MOVE MRPROCOR-RAMO-COBERTURA TO MRAPOCOB-RAMO-COBERTURA */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_RAMO_COBERTURA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_RAMO_COBERTURA);

            /*" -685- MOVE MRPROCOR-MODALI-COBERTURA TO MRAPOCOB-MODALI-COBERTURA */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_MODALI_COBERTURA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_MODALI_COBERTURA);

            /*" -686- MOVE MRPROCOR-DTH-INI-VIGENCIA TO MRAPOCOB-DTH-INI-VIG-COBER */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_DTH_INI_VIGENCIA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_DTH_INI_VIG_COBER);

            /*" -687- MOVE MRPROCOR-DTH-FIM-VIGENCIA TO MRAPOCOB-DTH-FIM-VIG-COBER */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_DTH_FIM_VIGENCIA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_DTH_FIM_VIG_COBER);

            /*" -688- MOVE MRPROCOR-IMP-SEGURADA-IX TO MRAPOCOB-IMP-SEGURADA-IX */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_IMP_SEGURADA_IX, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_IX);

            /*" -689- MOVE MRPROCOR-IMP-SEGURADA-VAR TO MRAPOCOB-IMP-SEGURADA-VAR */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_IMP_SEGURADA_VAR, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_VAR);

            /*" -690- MOVE MRPROCOR-TAXA-IS-COBER TO MRAPOCOB-TAXA-IS */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_TAXA_IS_COBER, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_TAXA_IS);

            /*" -691- MOVE MRPROCOR-PRM-TARIFARIO-IX TO MRAPOCOB-PRM-TARIFARIO-IX */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PRM_TARIFARIO_IX, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX);

            /*" -693- MOVE MRPROCOR-PRM-TARIFARIO-VAR TO MRAPOCOB-PRM-TARIFARIO-VAR */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PRM_TARIFARIO_VAR, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_VAR);

            /*" -694- MOVE MRPROCOR-PCT-FRANQUIA TO MRAPOCOB-PCT-FRANQUIA */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PCT_FRANQUIA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PCT_FRANQUIA);

            /*" -695- MOVE MRPROCOR-VAL-FRANQ-OBR-IX TO MRAPOCOB-VAL-MIN-FRANQ-IX */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_VAL_FRANQ_OBR_IX, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_VAL_MIN_FRANQ_IX);

            /*" -696- MOVE MRPROCOR-COD-EMPRESA TO MRAPOCOB-COD-EMPRESA */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_COD_EMPRESA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_EMPRESA);

            /*" -697- ADD MRPROCOR-IMP-SEGURADA-IX TO WS-TOT-IMP-SEGURADA-IX */
            WS_TOT_IMP_SEGURADA_IX.Value = WS_TOT_IMP_SEGURADA_IX + MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_IMP_SEGURADA_IX;

            /*" -698- ADD MRPROCOR-IMP-SEGURADA-VAR TO WS-TOT-IMP-SEGURADA-VAR */
            WS_TOT_IMP_SEGURADA_VAR.Value = WS_TOT_IMP_SEGURADA_VAR + MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_IMP_SEGURADA_VAR;

            /*" -699- ADD MRPROCOR-PRM-TARIFARIO-IX TO WS-TOT-PRM-TARIFARIO-IX */
            WS_TOT_PRM_TARIFARIO_IX.Value = WS_TOT_PRM_TARIFARIO_IX + MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PRM_TARIFARIO_IX;

            /*" -701- ADD MRPROCOR-PRM-TARIFARIO-VAR TO WS-TOT-PRM-TARIFARIO-VAR. */
            WS_TOT_PRM_TARIFARIO_VAR.Value = WS_TOT_PRM_TARIFARIO_VAR + MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_PRM_TARIFARIO_VAR;

            /*" -702- IF ENDOSSOS-TIPO-ENDOSSO = '5' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO == "5")
            {

                /*" -703- MOVE 'I' TO MRAPOCOB-SIT-REGISTRO */
                _.Move("I", MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_SIT_REGISTRO);

                /*" -704- ELSE */
            }
            else
            {


                /*" -704- MOVE MRPROCOR-SIT-REGISTRO TO MRAPOCOB-SIT-REGISTRO. */
                _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_SIT_REGISTRO, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2330_99_SAIDA*/

        [StopWatch]
        /*" R2340-00-INSERT-APOLICOB-SECTION */
        private void R2340_00_INSERT_APOLICOB_SECTION()
        {
            /*" -715- MOVE '234' TO WNR-EXEC-SQL. */
            _.Move("234", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -716- MOVE WHOST-NUM-APOL TO APOLICOB-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -717- MOVE WHOST-NRENDOS TO APOLICOB-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -719- MOVE ZEROS TO APOLICOB-NUM-ITEM APOLICOB-COD-COBERTURA */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -720- MOVE 1 TO APOLICOB-OCORR-HISTORICO */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -721- MOVE WS-TOT-IMP-SEGURADA-IX TO APOLICOB-IMP-SEGURADA-IX */
            _.Move(WS_TOT_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

            /*" -722- MOVE WS-TOT-IMP-SEGURADA-VAR TO APOLICOB-IMP-SEGURADA-VAR */
            _.Move(WS_TOT_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -723- MOVE WS-TOT-PRM-TARIFARIO-IX TO APOLICOB-PRM-TARIFARIO-IX */
            _.Move(WS_TOT_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

            /*" -724- MOVE WS-TOT-PRM-TARIFARIO-VAR TO APOLICOB-PRM-TARIFARIO-VAR */
            _.Move(WS_TOT_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -725- MOVE MRPROCOR-RAMO-COBERTURA TO APOLICOB-RAMO-COBERTURA */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -727- MOVE MRPROCOR-MODALI-COBERTURA TO APOLICOB-MODALI-COBERTURA. */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_MODALI_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -728- IF APOLICOB-PRM-TARIFARIO-VAR NOT EQUAL ZEROS */

            if (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR != 00)
            {

                /*" -729- MOVE 100 TO APOLICOB-PCT-COBERTURA */
                _.Move(100, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

                /*" -730- ELSE */
            }
            else
            {


                /*" -732- MOVE ZEROS TO APOLICOB-PCT-COBERTURA. */
                _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);
            }


            /*" -733- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -734- MOVE MRPROCOR-DTH-INI-VIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_DTH_INI_VIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -735- MOVE MRPROCOR-DTH-FIM-VIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(MRPROCOR.DCLMR_PROPOSTA_COBER.MRPROCOR_DTH_FIM_VIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -736- MOVE ZEROS TO APOLICOB-COD-EMPRESA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -738- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -776- PERFORM R2340_00_INSERT_APOLICOB_DB_INSERT_1 */

            R2340_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -779- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -781- MOVE 'APOLICE_COBERTURAS (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("APOLICE_COBERTURAS (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -783- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -784- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -786- MOVE 'APOLICE_COBERTURAS (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("APOLICE_COBERTURAS (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -788- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -788- ADD 1 TO AC-I-APOLCOBER. */
            AREA_DE_WORK.AC_I_APOLCOBER.Value = AREA_DE_WORK.AC_I_APOLCOBER + 1;

        }

        [StopWatch]
        /*" R2340-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R2340_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -776- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, OCORR_HISTORICO, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, IMP_SEGURADA_VAR, PRM_TARIFARIO_VAR, PCT_COBERTURA, FATOR_MULTIPLICA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, COD_EMPRESA, TIMESTAMP, SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE, :APOLICOB-NUM-ENDOSSO, :APOLICOB-NUM-ITEM, :APOLICOB-OCORR-HISTORICO, :APOLICOB-RAMO-COBERTURA, :APOLICOB-MODALI-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-IMP-SEGURADA-VAR, :APOLICOB-PRM-TARIFARIO-VAR, :APOLICOB-PCT-COBERTURA, :APOLICOB-FATOR-MULTIPLICA, :APOLICOB-DATA-INIVIGENCIA, :APOLICOB-DATA-TERVIGENCIA, :APOLICOB-COD-EMPRESA, CURRENT TIMESTAMP, :APOLICOB-SIT-REGISTRO) END-EXEC. */

            var r2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
            };

            R2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2340_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-UPDATE-MR-BENS-SEG-SECTION */
        private void R2400_00_UPDATE_MR_BENS_SEG_SECTION()
        {
            /*" -799- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -806- PERFORM R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1 */

            R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1();

            /*" -809- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -811- MOVE 'PROBLEMAS NO UPDATE (MR-BENS-SEGURADO)' TO LK-RETORNO */
                _.Move("PROBLEMAS NO UPDATE (MR-BENS-SEGURADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -811- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-UPDATE-MR-BENS-SEG-DB-UPDATE-1 */
        public void R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1()
        {
            /*" -806- EXEC SQL UPDATE SEGUROS.MR_BENS_SEGURADO SET NUM_APOLICE = :WHOST-NUM-APOL, NUM_ENDOSSO = :WHOST-NRENDOS, DTH_TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :WHOST-FONTE AND NUM_PROPOSTA = :WHOST-NRPROPOS END-EXEC. */

            var r2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1 = new R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
                WHOST_NRPROPOS = WHOST_NRPROPOS.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
            };

            R2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1.Execute(r2400_00_UPDATE_MR_BENS_SEG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-MR-PROP-QUEST-SECTION */
        private void R2500_00_UPDATE_MR_PROP_QUEST_SECTION()
        {
            /*" -822- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -829- PERFORM R2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1 */

            R2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1();

            /*" -832- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -834- MOVE 'PROBLEMAS NO UPDATE (MR-PROP-QUEST)' TO LK-RETORNO */
                _.Move("PROBLEMAS NO UPDATE (MR-PROP-QUEST)", LK_PROPOSTA.LK_RETORNO);

                /*" -834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-MR-PROP-QUEST-DB-UPDATE-1 */
        public void R2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1()
        {
            /*" -829- EXEC SQL UPDATE SEGUROS.MR_PROPOSTA_QUEST SET NUM_APOLICE = :WHOST-NUM-APOL, NUM_ENDOSSO = :WHOST-NRENDOS, DTH_TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :WHOST-FONTE AND NUM_PROPOSTA = :WHOST-NRPROPOS END-EXEC. */

            var r2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1_Update1 = new R2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1_Update1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
                WHOST_NRPROPOS = WHOST_NRPROPOS.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
            };

            R2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1_Update1.Execute(r2500_00_UPDATE_MR_PROP_QUEST_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLARE-PROP-CLAUS-SECTION */
        private void R2600_00_DECLARE_PROP_CLAUS_SECTION()
        {
            /*" -845- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -860- PERFORM R2600_00_DECLARE_PROP_CLAUS_DB_DECLARE_1 */

            R2600_00_DECLARE_PROP_CLAUS_DB_DECLARE_1();

            /*" -862- PERFORM R2600_00_DECLARE_PROP_CLAUS_DB_OPEN_1 */

            R2600_00_DECLARE_PROP_CLAUS_DB_OPEN_1();

            /*" -865- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -866- DISPLAY 'R2600-00 (ERRO DECLARE CLAUSULAS)' */
                _.Display($"R2600-00 (ERRO DECLARE CLAUSULAS)");

                /*" -866- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-DECLARE-PROP-CLAUS-DB-OPEN-1 */
        public void R2600_00_DECLARE_PROP_CLAUS_DB_OPEN_1()
        {
            /*" -862- EXEC SQL OPEN V1PROPCLAU END-EXEC. */

            V1PROPCLAU.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-INSERT-APOL-CLAUS-SECTION */
        private void R2610_00_INSERT_APOL_CLAUS_SECTION()
        {
            /*" -876- PERFORM R2620-00-FETCH-PROP-CLAUS */

            R2620_00_FETCH_PROP_CLAUS_SECTION();

            /*" -877- IF WFIM-PROPOCLA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_PROPOCLA.IsEmpty())
            {

                /*" -879- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -881- PERFORM R2630-00-MONTA-APOL-CLAUS */

            R2630_00_MONTA_APOL_CLAUS_SECTION();

            /*" -883- MOVE '263' TO WNR-EXEC-SQL. */
            _.Move("263", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -911- PERFORM R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1 */

            R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1();

            /*" -914- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -917- DISPLAY 'R2610-00 (REGISTRO DUPLICADO) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"R2610-00 (REGISTRO DUPLICADO) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -919- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -920- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -923- DISPLAY 'R2610-00 (PROBLEMAS NA INSERCAO) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"R2610-00 (PROBLEMAS NA INSERCAO) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -925- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -925- ADD +1 TO AC-I-APOLCLAU. */
            AREA_DE_WORK.AC_I_APOLCLAU.Value = AREA_DE_WORK.AC_I_APOLCLAU + +1;

        }

        [StopWatch]
        /*" R2610-00-INSERT-APOL-CLAUS-DB-INSERT-1 */
        public void R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1()
        {
            /*" -911- EXEC SQL INSERT INTO SEGUROS.APOLICE_CLAUSULAS (COD_EMPRESA, NUM_APOLICE, NUM_ENDOSSO, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA , DATA_INIVIGENCIA, DATA_TERVIGENCIA, NUM_ITEM , COD_CLAUSULA , TIPO_CLAUSULA , LIMITE_INDENIZA_IX , TIMESTAMP) VALUES (:APOLICLA-COD-EMPRESA, :APOLICLA-NUM-APOLICE, :APOLICLA-NUM-ENDOSSO, :APOLICLA-RAMO-COBERTURA, :APOLICLA-MODALI-COBERTURA, :APOLICLA-COD-COBERTURA , :APOLICLA-DATA-INIVIGENCIA, :APOLICLA-DATA-TERVIGENCIA, :APOLICLA-NUM-ITEM , :APOLICLA-COD-CLAUSULA , :APOLICLA-TIPO-CLAUSULA , :APOLICLA-LIMITE-INDENIZA-IX , CURRENT TIMESTAMP) END-EXEC. */

            var r2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1 = new R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1()
            {
                APOLICLA_COD_EMPRESA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_COD_EMPRESA.ToString(),
                APOLICLA_NUM_APOLICE = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_NUM_APOLICE.ToString(),
                APOLICLA_NUM_ENDOSSO = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_NUM_ENDOSSO.ToString(),
                APOLICLA_RAMO_COBERTURA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_RAMO_COBERTURA.ToString(),
                APOLICLA_MODALI_COBERTURA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_MODALI_COBERTURA.ToString(),
                APOLICLA_COD_COBERTURA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_COD_COBERTURA.ToString(),
                APOLICLA_DATA_INIVIGENCIA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_DATA_INIVIGENCIA.ToString(),
                APOLICLA_DATA_TERVIGENCIA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_DATA_TERVIGENCIA.ToString(),
                APOLICLA_NUM_ITEM = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_NUM_ITEM.ToString(),
                APOLICLA_COD_CLAUSULA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_COD_CLAUSULA.ToString(),
                APOLICLA_TIPO_CLAUSULA = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_TIPO_CLAUSULA.ToString(),
                APOLICLA_LIMITE_INDENIZA_IX = APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_LIMITE_INDENIZA_IX.ToString(),
            };

            R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1.Execute(r2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2620-00-FETCH-PROP-CLAUS-SECTION */
        private void R2620_00_FETCH_PROP_CLAUS_SECTION()
        {
            /*" -936- MOVE '262' TO WNR-EXEC-SQL. */
            _.Move("262", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -947- PERFORM R2620_00_FETCH_PROP_CLAUS_DB_FETCH_1 */

            R2620_00_FETCH_PROP_CLAUS_DB_FETCH_1();

            /*" -950- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -951- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -952- MOVE 'S' TO WFIM-PROPOCLA */
                    _.Move("S", AREA_DE_WORK.WFIM_PROPOCLA);

                    /*" -952- PERFORM R2620_00_FETCH_PROP_CLAUS_DB_CLOSE_1 */

                    R2620_00_FETCH_PROP_CLAUS_DB_CLOSE_1();

                    /*" -954- GO TO R2620-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/ //GOTO
                    return;

                    /*" -955- ELSE */
                }
                else
                {


                    /*" -956- DISPLAY 'R2620-00 (ERRO FETCH CLAUSULAS) ... ' */
                    _.Display($"R2620-00 (ERRO FETCH CLAUSULAS) ... ");

                    /*" -958- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -958- ADD +1 TO AC-S-PROPCLAU. */
            AREA_DE_WORK.AC_S_PROPCLAU.Value = AREA_DE_WORK.AC_S_PROPCLAU + +1;

        }

        [StopWatch]
        /*" R2620-00-FETCH-PROP-CLAUS-DB-FETCH-1 */
        public void R2620_00_FETCH_PROP_CLAUS_DB_FETCH_1()
        {
            /*" -947- EXEC SQL FETCH V1PROPCLAU INTO :PROPOCLA-COD-EMPRESA, :PROPOCLA-RAMO-COBERTURA, :PROPOCLA-MODALI-COBERTURA, :PROPOCLA-COD-COBERTURA, :PROPOCLA-DATA-INIVIGENCIA, :PROPOCLA-DATA-TERVIGENCIA, :PROPOCLA-NUM-ITEM, :PROPOCLA-COD-CLAUSULA, :PROPOCLA-LIMITE-INDENIZA-IX, :PROPOCLA-TIPO-CLAUSULA END-EXEC. */

            if (V1PROPCLAU.Fetch())
            {
                _.Move(V1PROPCLAU.PROPOCLA_COD_EMPRESA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_COD_EMPRESA);
                _.Move(V1PROPCLAU.PROPOCLA_RAMO_COBERTURA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_RAMO_COBERTURA);
                _.Move(V1PROPCLAU.PROPOCLA_MODALI_COBERTURA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_MODALI_COBERTURA);
                _.Move(V1PROPCLAU.PROPOCLA_COD_COBERTURA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_COD_COBERTURA);
                _.Move(V1PROPCLAU.PROPOCLA_DATA_INIVIGENCIA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_DATA_INIVIGENCIA);
                _.Move(V1PROPCLAU.PROPOCLA_DATA_TERVIGENCIA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_DATA_TERVIGENCIA);
                _.Move(V1PROPCLAU.PROPOCLA_NUM_ITEM, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_NUM_ITEM);
                _.Move(V1PROPCLAU.PROPOCLA_COD_CLAUSULA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_COD_CLAUSULA);
                _.Move(V1PROPCLAU.PROPOCLA_LIMITE_INDENIZA_IX, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_LIMITE_INDENIZA_IX);
                _.Move(V1PROPCLAU.PROPOCLA_TIPO_CLAUSULA, PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_TIPO_CLAUSULA);
            }

        }

        [StopWatch]
        /*" R2620-00-FETCH-PROP-CLAUS-DB-CLOSE-1 */
        public void R2620_00_FETCH_PROP_CLAUS_DB_CLOSE_1()
        {
            /*" -952- EXEC SQL CLOSE V1PROPCLAU END-EXEC */

            V1PROPCLAU.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/

        [StopWatch]
        /*" R2630-00-MONTA-APOL-CLAUS-SECTION */
        private void R2630_00_MONTA_APOL_CLAUS_SECTION()
        {
            /*" -969- MOVE '263' TO WNR-EXEC-SQL. */
            _.Move("263", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -970- MOVE PROPOCLA-COD-EMPRESA TO APOLICLA-COD-EMPRESA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_COD_EMPRESA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_COD_EMPRESA);

            /*" -971- MOVE WHOST-NUM-APOL TO APOLICLA-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_NUM_APOLICE);

            /*" -972- MOVE WHOST-NRENDOS TO APOLICLA-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_NUM_ENDOSSO);

            /*" -973- MOVE PROPOCLA-RAMO-COBERTURA TO APOLICLA-RAMO-COBERTURA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_RAMO_COBERTURA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_RAMO_COBERTURA);

            /*" -974- MOVE PROPOCLA-MODALI-COBERTURA TO APOLICLA-MODALI-COBERTURA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_MODALI_COBERTURA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_MODALI_COBERTURA);

            /*" -975- MOVE PROPOCLA-COD-COBERTURA TO APOLICLA-COD-COBERTURA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_COD_COBERTURA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_COD_COBERTURA);

            /*" -976- MOVE PROPOCLA-DATA-INIVIGENCIA TO APOLICLA-DATA-INIVIGENCIA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_DATA_INIVIGENCIA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_DATA_INIVIGENCIA);

            /*" -977- MOVE PROPOCLA-DATA-TERVIGENCIA TO APOLICLA-DATA-TERVIGENCIA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_DATA_TERVIGENCIA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_DATA_TERVIGENCIA);

            /*" -978- MOVE PROPOCLA-NUM-ITEM TO APOLICLA-NUM-ITEM */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_NUM_ITEM, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_NUM_ITEM);

            /*" -979- MOVE PROPOCLA-COD-CLAUSULA TO APOLICLA-COD-CLAUSULA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_COD_CLAUSULA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_COD_CLAUSULA);

            /*" -980- MOVE PROPOCLA-TIPO-CLAUSULA TO APOLICLA-TIPO-CLAUSULA */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_TIPO_CLAUSULA, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_TIPO_CLAUSULA);

            /*" -981- MOVE PROPOCLA-LIMITE-INDENIZA-IX TO APOLICLA-LIMITE-INDENIZA-IX. */
            _.Move(PROPOCLA.DCLPROPOSTA_CLAUSULAS.PROPOCLA_LIMITE_INDENIZA_IX, APOLICLA.DCLAPOLICE_CLAUSULAS.APOLICLA_LIMITE_INDENIZA_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2630_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -991- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -993- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -993- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -995- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -999- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1001- IF LK-RETORNO EQUAL SPACES OR LOW-VALUES */

            if (LK_PROPOSTA.LK_RETORNO.IsLowValues())
            {

                /*" -1003- MOVE ALL '*' TO LK-RETORNO. */
                _.MoveAll("*", LK_PROPOSTA.LK_RETORNO);
            }


            /*" -1003- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}