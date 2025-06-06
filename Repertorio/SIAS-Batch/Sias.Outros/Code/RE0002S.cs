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
using Sias.Outros.DB2.RE0002S;

namespace Code
{
    public class RE0002S
    {
        public bool IsCall { get; set; }

        public RE0002S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------                                       */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  APURA VALORES IS E PREMIO PARA     *      */
        /*"      *                             CALCULO AUTOMATICO DE RESSEGURO DO *      */
        /*"      *                             EXCEDENTE DE RESPONSABILIDADE DO   *      */
        /*"      *                             MULTIRISCO (EMPRESARIAL/CONDOMINIO)*      */
        /*"      *                             PRODUTO  1804                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  RE0002S                            *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  AGOSTO / 2019                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - SUB-ROTINA RE0002S COPIA DA SUB-ROTINA MR7001S COM*      */
        /*"      *              COM ALTERACAO DOS PARAMETROS DE ENTRADA           *      */
        /*"      * 13/08/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 192299 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR A REGRA DE CALCULO DO RESSEGURO DO PRODUTO*      */
        /*"      *              1804 DO MODO PROPORCIONAL PARA O MODO FINANCEIRO  *      */
        /*"      *              A PARTIR DO DIA 17/05/2021 COM A INCLUSAO DO NOVO *      */
        /*"      *              PARAMETRO LKRE02-DTEMS-AP DA SUB-ROTINA RE0002S   *      */
        /*"      * 20/05/2021 - GILSON PINTO DA SILVA    JAZZ - TAREFA   - 289210 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01          AREAS-AUXILIARES.*/
        public RE0002S_AREAS_AUXILIARES AREAS_AUXILIARES { get; set; } = new RE0002S_AREAS_AUXILIARES();
        public class RE0002S_AREAS_AUXILIARES : VarBasis
        {
            /*"  05        WFIM-MRAPOCOB        PIC  X(001)     VALUE SPACES.*/
            public StringBasis WFIM_MRAPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-MRAPOITE        PIC  X(001)     VALUE SPACES.*/
            public StringBasis WFIM_MRAPOITE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-APOLICOR        PIC  X(001)     VALUE SPACES.*/
            public StringBasis WFIM_APOLICOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-RETORNO           PIC S9(005)     VALUE +0 COMP-3*/
            public IntBasis WS_RETORNO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05        WS-MENSAGEM          PIC  X(070)     VALUE SPACES.*/
            public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"  05        WS-IMPSEG-IX         PIC S9(15)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_IMPSEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  05        WS-PRMTAR-VR         PIC S9(13)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_PRMTAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05        WS-PRMTAR-IT         PIC S9(13)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_PRMTAR_IT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05        WS-VLDESCTO          PIC S9(13)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLDESCTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05        WS-VLDESC-IT         PIC S9(13)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLDESC_IT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05        WS-VLCOSCED          PIC S9(13)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLCOSCED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05        WS-VLCOMISS          PIC S9(13)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VLCOMISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05        WS-PCT-CORR          PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_PCT_CORR { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-PCT-PREM          PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_PCT_PREM { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-PCT-COSC          PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_PCT_COSC { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-PCT-DSCT          PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_PCT_DSCT { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-DSCT-COBER        PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_DSCT_COBER { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-DSCT-BONUS        PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_DSCT_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-DSCT-FIDEL        PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_DSCT_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"  05        WS-FATOR-ADIC        PIC S9(05)V9(7) VALUE +0 COMP-3*/
            public DoubleBasis WS_FATOR_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(05)V9(7)"), 7);
            /*"01          LK-RE0002S.*/
        }
        public RE0002S_LK_RE0002S LK_RE0002S { get; set; } = new RE0002S_LK_RE0002S();
        public class RE0002S_LK_RE0002S : VarBasis
        {
            /*"  05        LKRE02-ENTRADA.*/
            public RE0002S_LKRE02_ENTRADA LKRE02_ENTRADA { get; set; } = new RE0002S_LKRE02_ENTRADA();
            public class RE0002S_LKRE02_ENTRADA : VarBasis
            {
                /*"    10      LKRE02-NUM-APOL        PIC S9(013)       COMP-3.*/
                public IntBasis LKRE02_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10      LKRE02-NUM-ENDS        PIC S9(009)       COMP.*/
                public IntBasis LKRE02_NUM_ENDS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10      LKRE02-COD-PROD        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_COD_PROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LKRE02-COD-SUBG        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LKRE02-DTEMS-AP        PIC  X(010).*/
                public StringBasis LKRE02_DTEMS_AP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10      LKRE02-DTINIVIG        PIC  X(010).*/
                public StringBasis LKRE02_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10      LKRE02-DTTERVIG        PIC  X(010).*/
                public StringBasis LKRE02_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10      LKRE02-TIP-ENDS        PIC  X(001).*/
                public StringBasis LKRE02_TIP_ENDS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      LKRE02-RAMO-CBT        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_RAMO_CBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LKRE02-MODL-CBT        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_MODL_CBT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LKRE02-NUM-VERS        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_NUM_VERS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LKRE02-NUM-ITEM        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05        LKRE02-SAIDA.*/
            }
            public RE0002S_LKRE02_SAIDA LKRE02_SAIDA { get; set; } = new RE0002S_LKRE02_SAIDA();
            public class RE0002S_LKRE02_SAIDA : VarBasis
            {
                /*"    10      LKRE02-IMP-SEGR        PIC S9(013)V99    COMP-3.*/
                public DoubleBasis LKRE02_IMP_SEGR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    10      LKRE02-PRM-TARF        PIC S9(013)V99    COMP-3.*/
                public DoubleBasis LKRE02_PRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    10      LKRE02-VLDESCTO        PIC S9(013)V99    COMP-3.*/
                public DoubleBasis LKRE02_VLDESCTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    10      LKRE02-PCT-CORR        PIC S9(005)V9(7)  COMP-3.*/
                public DoubleBasis LKRE02_PCT_CORR { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(7)"), 7);
                /*"    10      LKRE02-PCT-COSC        PIC S9(004)V9(5)  COMP-3.*/
                public DoubleBasis LKRE02_PCT_COSC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
                /*"    10      LKRE02-PRM-LIDR        PIC S9(013)V99    COMP-3.*/
                public DoubleBasis LKRE02_PRM_LIDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    10      LKRE02-ADC-FRAC        PIC S9(013)V99    COMP-3.*/
                public DoubleBasis LKRE02_ADC_FRAC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"    10      LKRE02-COD-RETN        PIC S9(004)       COMP.*/
                public IntBasis LKRE02_COD_RETN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LKRE02-MENSAGEM        PIC  X(070).*/
                public StringBasis LKRE02_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            }
        }


        public Dclgens.MRAPOCOB MRAPOCOB { get; set; } = new Dclgens.MRAPOCOB();
        public Dclgens.MRPROCOB MRPROCOB { get; set; } = new Dclgens.MRPROCOB();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.MRAPOITE MRAPOITE { get; set; } = new Dclgens.MRAPOITE();
        public Dclgens.MR022 MR022 { get; set; } = new Dclgens.MR022();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public RE0002S_C01_MRAPOITE C01_MRAPOITE { get; set; } = new RE0002S_C01_MRAPOITE();
        public RE0002S_C01_MRAPOCOB C01_MRAPOCOB { get; set; } = new RE0002S_C01_MRAPOCOB();
        public RE0002S_CCORRET CCORRET { get; set; } = new RE0002S_CCORRET();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(RE0002S_LK_RE0002S RE0002S_LK_RE0002S_P) //PROCEDURE DIVISION USING 
        /*LK_RE0002S*/
        {
            try
            {
                this.LK_RE0002S = RE0002S_LK_RE0002S_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PROCESSO-PRINCIPAL-SECTION */

                R0000_00_PROCESSO_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_RE0002S };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R0000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -147- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -148- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -149- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -153- PERFORM R0100-00-CONSISTE-PARAMETRO. */

            R0100_00_CONSISTE_PARAMETRO_SECTION();

            /*" -154- IF WS-RETORNO NOT = ZEROS */

            if (AREAS_AUXILIARES.WS_RETORNO != 00)
            {

                /*" -155- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -160- END-IF. */
            }


            /*" -161- MOVE LKRE02-NUM-APOL TO MRAPOCOB-NUM-APOLICE. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE);

            /*" -162- MOVE LKRE02-NUM-ENDS TO MRAPOCOB-NUM-ENDOSSO. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ENDS, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO);

            /*" -163- MOVE LKRE02-RAMO-CBT TO MRAPOCOB-RAMO-COBERTURA. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_RAMO_CBT, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_RAMO_COBERTURA);

            /*" -164- MOVE LKRE02-MODL-CBT TO MRAPOCOB-MODALI-COBERTURA. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_MODL_CBT, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_MODALI_COBERTURA);

            /*" -165- MOVE LKRE02-COD-PROD TO MRPROCOB-COD-PRODUTO. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_PROD, MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO);

            /*" -166- MOVE LKRE02-NUM-VERS TO MRAPOITE-NUM-VERSAO. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_VERS, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_VERSAO);

            /*" -168- MOVE LKRE02-NUM-ITEM TO MRAPOITE-NUM-ITEM. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ITEM, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM);

            /*" -170- PERFORM R0500-00-PROCESSA-DOCTO. */

            R0500_00_PROCESSA_DOCTO_SECTION();

            /*" -171- IF WS-RETORNO NOT = ZEROS */

            if (AREAS_AUXILIARES.WS_RETORNO != 00)
            {

                /*" -172- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -174- END-IF. */
            }


            /*" -175- MOVE WS-IMPSEG-IX TO LKRE02-IMP-SEGR. */
            _.Move(AREAS_AUXILIARES.WS_IMPSEG_IX, LK_RE0002S.LKRE02_SAIDA.LKRE02_IMP_SEGR);

            /*" -176- MOVE WS-PRMTAR-VR TO LKRE02-PRM-TARF. */
            _.Move(AREAS_AUXILIARES.WS_PRMTAR_VR, LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_TARF);

            /*" -177- MOVE WS-VLDESCTO TO LKRE02-VLDESCTO. */
            _.Move(AREAS_AUXILIARES.WS_VLDESCTO, LK_RE0002S.LKRE02_SAIDA.LKRE02_VLDESCTO);

            /*" -178- MOVE WS-PCT-CORR TO LKRE02-PCT-CORR. */
            _.Move(AREAS_AUXILIARES.WS_PCT_CORR, LK_RE0002S.LKRE02_SAIDA.LKRE02_PCT_CORR);

            /*" -180- MOVE WS-PCT-COSC TO LKRE02-PCT-COSC. */
            _.Move(AREAS_AUXILIARES.WS_PCT_COSC, LK_RE0002S.LKRE02_SAIDA.LKRE02_PCT_COSC);

            /*" -185- COMPUTE LKRE02-PRM-LIDR = WS-PRMTAR-VR - WS-VLDESCTO - WS-VLCOMISS - WS-VLCOSCED. */
            LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_LIDR.Value = AREAS_AUXILIARES.WS_PRMTAR_VR - AREAS_AUXILIARES.WS_VLDESCTO - AREAS_AUXILIARES.WS_VLCOMISS - AREAS_AUXILIARES.WS_VLCOSCED;

            /*" -188- COMPUTE LKRE02-ADC-FRAC = LKRE02-PRM-LIDR * WS-FATOR-ADIC. */
            LK_RE0002S.LKRE02_SAIDA.LKRE02_ADC_FRAC.Value = LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_LIDR * AREAS_AUXILIARES.WS_FATOR_ADIC;

            /*" -189- MOVE ZEROS TO LKRE02-COD-RETN. */
            _.Move(0, LK_RE0002S.LKRE02_SAIDA.LKRE02_COD_RETN);

            /*" -191- MOVE SPACES TO LKRE02-MENSAGEM. */
            _.Move("", LK_RE0002S.LKRE02_SAIDA.LKRE02_MENSAGEM);

            /*" -191- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-CONSISTE-PARAMETRO-SECTION */
        private void R0100_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -202- MOVE ZEROS TO LKRE02-IMP-SEGR. */
            _.Move(0, LK_RE0002S.LKRE02_SAIDA.LKRE02_IMP_SEGR);

            /*" -203- MOVE ZEROS TO LKRE02-PRM-TARF. */
            _.Move(0, LK_RE0002S.LKRE02_SAIDA.LKRE02_PRM_TARF);

            /*" -204- MOVE ZEROS TO WS-RETORNO. */
            _.Move(0, AREAS_AUXILIARES.WS_RETORNO);

            /*" -206- MOVE SPACES TO WS-MENSAGEM. */
            _.Move("", AREAS_AUXILIARES.WS_MENSAGEM);

            /*" -207- IF LKRE02-NUM-APOL EQUAL ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL == 00)
            {

                /*" -208- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -210- MOVE 'R0100 - NUMERO DA APOLICE NAO INFORMADO' TO WS-MENSAGEM */
                _.Move("R0100 - NUMERO DA APOLICE NAO INFORMADO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -211- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -213- END-IF. */
            }


            /*" -214- IF LKRE02-COD-PROD EQUAL ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_PROD == 00)
            {

                /*" -215- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -217- MOVE 'R0100 - CODIGO DO PRODUTO NAO INFORMADO' TO WS-MENSAGEM */
                _.Move("R0100 - CODIGO DO PRODUTO NAO INFORMADO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -218- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -220- END-IF. */
            }


            /*" -222- IF LKRE02-DTEMS-AP EQUAL SPACES OR LKRE02-DTEMS-AP EQUAL LOW-VALUES */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTEMS_AP.IsEmpty() || LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTEMS_AP.IsLowValues())
            {

                /*" -223- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -225- MOVE 'R0100 - DATA DE EMISSAO DA APOLICE INVALIDA' TO WS-MENSAGEM */
                _.Move("R0100 - DATA DE EMISSAO DA APOLICE INVALIDA", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -226- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -228- END-IF. */
            }


            /*" -230- IF LKRE02-DTINIVIG EQUAL SPACES OR LKRE02-DTINIVIG EQUAL LOW-VALUES */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTINIVIG.IsEmpty() || LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTINIVIG.IsLowValues())
            {

                /*" -231- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -233- MOVE 'R0100 - DATA DE INICIO DE VIGENCIA INVALIDA' TO WS-MENSAGEM */
                _.Move("R0100 - DATA DE INICIO DE VIGENCIA INVALIDA", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -234- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -236- END-IF. */
            }


            /*" -238- IF LKRE02-DTTERVIG EQUAL SPACES OR LKRE02-DTTERVIG EQUAL LOW-VALUES */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTTERVIG.IsEmpty() || LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTTERVIG.IsLowValues())
            {

                /*" -239- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -241- MOVE 'R0100 - DATA DE TERMINO DE VIGENCIA INVALIDA' TO WS-MENSAGEM */
                _.Move("R0100 - DATA DE TERMINO DE VIGENCIA INVALIDA", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -242- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -244- END-IF. */
            }


            /*" -246- IF LKRE02-TIP-ENDS EQUAL SPACES OR LKRE02-TIP-ENDS EQUAL LOW-VALUES */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_TIP_ENDS.IsEmpty() || LK_RE0002S.LKRE02_ENTRADA.LKRE02_TIP_ENDS.IsLowValues())
            {

                /*" -247- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -249- MOVE 'R0100 - TIPO DE ENDOSSO DO DOCTO INVALIDO' TO WS-MENSAGEM */
                _.Move("R0100 - TIPO DE ENDOSSO DO DOCTO INVALIDO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -250- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -252- END-IF. */
            }


            /*" -253- IF LKRE02-RAMO-CBT EQUAL ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_RAMO_CBT == 00)
            {

                /*" -254- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -256- MOVE 'R0100 - CODIGO DO RAMO NAO INFORMADO' TO WS-MENSAGEM */
                _.Move("R0100 - CODIGO DO RAMO NAO INFORMADO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -257- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -259- END-IF. */
            }


            /*" -261- IF LKRE02-NUM-VERS NOT = ZEROS AND LKRE02-NUM-ITEM EQUAL ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_VERS != 00 && LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ITEM == 00)
            {

                /*" -262- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -264- MOVE 'R0100 - VERSAO INFORMADA E ITEM NAO' TO WS-MENSAGEM */
                _.Move("R0100 - VERSAO INFORMADA E ITEM NAO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -265- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -267- END-IF. */
            }


            /*" -269- IF LKRE02-NUM-ITEM NOT = ZEROS AND LKRE02-NUM-VERS EQUAL ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ITEM != 00 && LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_VERS == 00)
            {

                /*" -270- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -272- MOVE 'R0100 - ITEM INFORMADO E VERSAO NAO' TO WS-MENSAGEM */
                _.Move("R0100 - ITEM INFORMADO E VERSAO NAO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -273- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -273- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-DOCTO-SECTION */
        private void R0500_00_PROCESSA_DOCTO_SECTION()
        {
            /*" -291- MOVE +0 TO WS-IMPSEG-IX WS-PRMTAR-VR WS-VLDESCTO WS-PCT-CORR WS-PCT-COSC WS-VLCOMISS WS-VLCOSCED. */
            _.Move(+0, AREAS_AUXILIARES.WS_IMPSEG_IX, AREAS_AUXILIARES.WS_PRMTAR_VR, AREAS_AUXILIARES.WS_VLDESCTO, AREAS_AUXILIARES.WS_PCT_CORR, AREAS_AUXILIARES.WS_PCT_COSC, AREAS_AUXILIARES.WS_VLCOMISS, AREAS_AUXILIARES.WS_VLCOSCED);

            /*" -292- IF LKRE02-NUM-ITEM EQUAL ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ITEM == 00)
            {

                /*" -293- PERFORM R0700-00-PROCESSA-ENDOSSO */

                R0700_00_PROCESSA_ENDOSSO_SECTION();

                /*" -294- ELSE */
            }
            else
            {


                /*" -295- PERFORM R1000-00-PROCESSA-ITEM */

                R1000_00_PROCESSA_ITEM_SECTION();

                /*" -297- END-IF. */
            }


            /*" -299- PERFORM R2000-00-CALCULA-EXPURGOS. */

            R2000_00_CALCULA_EXPURGOS_SECTION();

            /*" -300- MOVE LKRE02-NUM-APOL TO PARCEHIS-NUM-APOLICE. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -302- MOVE LKRE02-NUM-ENDS TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ENDS, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -302- PERFORM R2500-00-SELECT-PARCEHIS. */

            R2500_00_SELECT_PARCEHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-ENDOSSO-SECTION */
        private void R0700_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -314- PERFORM R0800-00-DECLARE-ITENS-ENDO. */

            R0800_00_DECLARE_ITENS_ENDO_SECTION();

            /*" -316- PERFORM R0850-00-FETCH-ITENS-ENDO. */

            R0850_00_FETCH_ITENS_ENDO_SECTION();

            /*" -317- PERFORM R0900-00-PROCESSA-ITENS-ENDO UNTIL WFIM-MRAPOITE EQUAL 'S' . */

            while (!(AREAS_AUXILIARES.WFIM_MRAPOITE == "S"))
            {

                R0900_00_PROCESSA_ITENS_ENDO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-DECLARE-ITENS-ENDO-SECTION */
        private void R0800_00_DECLARE_ITENS_ENDO_SECTION()
        {
            /*" -338- PERFORM R0800_00_DECLARE_ITENS_ENDO_DB_DECLARE_1 */

            R0800_00_DECLARE_ITENS_ENDO_DB_DECLARE_1();

            /*" -340- PERFORM R0800_00_DECLARE_ITENS_ENDO_DB_OPEN_1 */

            R0800_00_DECLARE_ITENS_ENDO_DB_OPEN_1();

            /*" -343- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -344- MOVE SQLCODE TO WS-RETORNO */
                _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                /*" -346- MOVE 'R0800 - ERRO NO DECLARE DA TABL MR_APOLICE_ITEM' TO WS-MENSAGEM */
                _.Move("R0800 - ERRO NO DECLARE DA TABL MR_APOLICE_ITEM", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -347- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -348- ELSE */
            }
            else
            {


                /*" -349- MOVE 'N' TO WFIM-MRAPOITE */
                _.Move("N", AREAS_AUXILIARES.WFIM_MRAPOITE);

                /*" -349- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-DECLARE-ITENS-ENDO-DB-DECLARE-1 */
        public void R0800_00_DECLARE_ITENS_ENDO_DB_DECLARE_1()
        {
            /*" -338- EXEC SQL DECLARE C01_MRAPOITE CURSOR FOR SELECT NUM_ITEM, NUM_VERSAO, VALUE(PCT_DESC_FIDEL,+0) FROM SEGUROS.MR_APOLICE_ITEM WHERE NUM_APOLICE = :MRAPOCOB-NUM-APOLICE AND NUM_ENDOSSO = :MRAPOCOB-NUM-ENDOSSO AND COD_PRODUTO = :MRPROCOB-COD-PRODUTO ORDER BY NUM_ITEM WITH UR END-EXEC. */
            C01_MRAPOITE = new RE0002S_C01_MRAPOITE(true);
            string GetQuery_C01_MRAPOITE()
            {
                var query = @$"SELECT NUM_ITEM
							, 
							NUM_VERSAO
							, 
							VALUE(PCT_DESC_FIDEL
							,+0) 
							FROM SEGUROS.MR_APOLICE_ITEM 
							WHERE NUM_APOLICE = '{MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO}' 
							AND COD_PRODUTO = '{MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO}' 
							ORDER BY 
							NUM_ITEM";

                return query;
            }
            C01_MRAPOITE.GetQueryEvent += GetQuery_C01_MRAPOITE;

        }

        [StopWatch]
        /*" R0800-00-DECLARE-ITENS-ENDO-DB-OPEN-1 */
        public void R0800_00_DECLARE_ITENS_ENDO_DB_OPEN_1()
        {
            /*" -340- EXEC SQL OPEN C01_MRAPOITE END-EXEC. */

            C01_MRAPOITE.Open();

        }

        [StopWatch]
        /*" R1100-00-DECLARE-MRAPOCOB-DB-DECLARE-1 */
        public void R1100_00_DECLARE_MRAPOCOB_DB_DECLARE_1()
        {
            /*" -443- EXEC SQL DECLARE C01_MRAPOCOB CURSOR FOR SELECT COD_COBERTURA , RAMO_COBERTURA , MODALI_COBERTURA , IMP_SEGURADA_IX , PRM_TARIFARIO_VAR, COD_EMPRESA FROM SEGUROS.MR_APOLICE_COBER WHERE NUM_APOLICE = :MRAPOCOB-NUM-APOLICE AND NUM_ENDOSSO = :MRAPOCOB-NUM-ENDOSSO AND NUM_ITEM = :MRAPOITE-NUM-ITEM WITH UR END-EXEC. */
            C01_MRAPOCOB = new RE0002S_C01_MRAPOCOB(true);
            string GetQuery_C01_MRAPOCOB()
            {
                var query = @$"SELECT COD_COBERTURA
							, 
							RAMO_COBERTURA
							, 
							MODALI_COBERTURA
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							COD_EMPRESA 
							FROM SEGUROS.MR_APOLICE_COBER 
							WHERE NUM_APOLICE = '{MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO}' 
							AND NUM_ITEM = '{MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM}'";

                return query;
            }
            C01_MRAPOCOB.GetQueryEvent += GetQuery_C01_MRAPOCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0850-00-FETCH-ITENS-ENDO-SECTION */
        private void R0850_00_FETCH_ITENS_ENDO_SECTION()
        {
            /*" -363- PERFORM R0850_00_FETCH_ITENS_ENDO_DB_FETCH_1 */

            R0850_00_FETCH_ITENS_ENDO_DB_FETCH_1();

            /*" -366- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -367- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -368- MOVE 'S' TO WFIM-MRAPOITE */
                    _.Move("S", AREAS_AUXILIARES.WFIM_MRAPOITE);

                    /*" -368- PERFORM R0850_00_FETCH_ITENS_ENDO_DB_CLOSE_1 */

                    R0850_00_FETCH_ITENS_ENDO_DB_CLOSE_1();

                    /*" -370- ELSE */
                }
                else
                {


                    /*" -371- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -373- MOVE 'R0850 - ERRO NO FETCH DA TABL MR_APOLICE_ITEM' TO WS-MENSAGEM */
                    _.Move("R0850 - ERRO NO FETCH DA TABL MR_APOLICE_ITEM", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -374- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -375- END-IF */
                }


                /*" -375- END-IF. */
            }


        }

        [StopWatch]
        /*" R0850-00-FETCH-ITENS-ENDO-DB-FETCH-1 */
        public void R0850_00_FETCH_ITENS_ENDO_DB_FETCH_1()
        {
            /*" -363- EXEC SQL FETCH C01_MRAPOITE INTO :MRAPOITE-NUM-ITEM, :MRAPOITE-NUM-VERSAO, :MRAPOITE-PCT-DESC-FIDEL END-EXEC. */

            if (C01_MRAPOITE.Fetch())
            {
                _.Move(C01_MRAPOITE.MRAPOITE_NUM_ITEM, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM);
                _.Move(C01_MRAPOITE.MRAPOITE_NUM_VERSAO, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_VERSAO);
                _.Move(C01_MRAPOITE.MRAPOITE_PCT_DESC_FIDEL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL);
            }

        }

        [StopWatch]
        /*" R0850-00-FETCH-ITENS-ENDO-DB-CLOSE-1 */
        public void R0850_00_FETCH_ITENS_ENDO_DB_CLOSE_1()
        {
            /*" -368- EXEC SQL CLOSE C01_MRAPOITE END-EXEC */

            C01_MRAPOITE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-PROCESSA-ITENS-ENDO-SECTION */
        private void R0900_00_PROCESSA_ITENS_ENDO_SECTION()
        {
            /*" -387- PERFORM R1000-00-PROCESSA-ITEM. */

            R1000_00_PROCESSA_ITEM_SECTION();

            /*" -387- PERFORM R0850-00-FETCH-ITENS-ENDO. */

            R0850_00_FETCH_ITENS_ENDO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-ITEM-SECTION */
        private void R1000_00_PROCESSA_ITEM_SECTION()
        {
            /*" -399- MOVE ZEROS TO WS-PRMTAR-IT. */
            _.Move(0, AREAS_AUXILIARES.WS_PRMTAR_IT);

            /*" -401- PERFORM R1100-00-DECLARE-MRAPOCOB. */

            R1100_00_DECLARE_MRAPOCOB_SECTION();

            /*" -403- PERFORM R1200-00-FETCH-MRAPOCOB. */

            R1200_00_FETCH_MRAPOCOB_SECTION();

            /*" -408- PERFORM R1300-00-PROCESSA-MRAPOCOB UNTIL WFIM-MRAPOCOB EQUAL 'S' . */

            while (!(AREAS_AUXILIARES.WFIM_MRAPOCOB == "S"))
            {

                R1300_00_PROCESSA_MRAPOCOB_SECTION();
            }

            /*" -410- MOVE ZEROS TO WS-PCT-DSCT. */
            _.Move(0, AREAS_AUXILIARES.WS_PCT_DSCT);

            /*" -412- PERFORM R1500-00-CALCULA-DESCONTOS. */

            R1500_00_CALCULA_DESCONTOS_SECTION();

            /*" -413- IF LKRE02-COD-PROD = 1804 */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_PROD == 1804)
            {

                /*" -419- COMPUTE WS-VLDESC-IT = WS-PRMTAR-IT * WS-PCT-DSCT / 100 */
                AREAS_AUXILIARES.WS_VLDESC_IT.Value = AREAS_AUXILIARES.WS_PRMTAR_IT * AREAS_AUXILIARES.WS_PCT_DSCT / 100f;

                /*" -421- END-IF. */
            }


            /*" -421- COMPUTE WS-VLDESCTO = WS-VLDESCTO + WS-VLDESC-IT. */
            AREAS_AUXILIARES.WS_VLDESCTO.Value = AREAS_AUXILIARES.WS_VLDESCTO + AREAS_AUXILIARES.WS_VLDESC_IT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DECLARE-MRAPOCOB-SECTION */
        private void R1100_00_DECLARE_MRAPOCOB_SECTION()
        {
            /*" -443- PERFORM R1100_00_DECLARE_MRAPOCOB_DB_DECLARE_1 */

            R1100_00_DECLARE_MRAPOCOB_DB_DECLARE_1();

            /*" -445- PERFORM R1100_00_DECLARE_MRAPOCOB_DB_OPEN_1 */

            R1100_00_DECLARE_MRAPOCOB_DB_OPEN_1();

            /*" -448- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -449- MOVE SQLCODE TO WS-RETORNO */
                _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                /*" -451- MOVE 'R1100 - ERRO NO DECLARE DA TABL MR_APOLICE_COBER' TO WS-MENSAGEM */
                _.Move("R1100 - ERRO NO DECLARE DA TABL MR_APOLICE_COBER", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -452- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -453- ELSE */
            }
            else
            {


                /*" -454- MOVE 'N' TO WFIM-MRAPOCOB */
                _.Move("N", AREAS_AUXILIARES.WFIM_MRAPOCOB);

                /*" -454- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-DECLARE-MRAPOCOB-DB-OPEN-1 */
        public void R1100_00_DECLARE_MRAPOCOB_DB_OPEN_1()
        {
            /*" -445- EXEC SQL OPEN C01_MRAPOCOB END-EXEC. */

            C01_MRAPOCOB.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-APOLICOR-DB-DECLARE-1 */
        public void R2100_00_DECLARE_APOLICOR_DB_DECLARE_1()
        {
            /*" -772- EXEC SQL DECLARE CCORRET CURSOR FOR SELECT PCT_PART_CORRETOR , PCT_COM_CORRETOR FROM SEGUROS.APOLICE_CORRETOR WHERE NUM_APOLICE = :APOLICOR-NUM-APOLICE AND COD_SUBGRUPO = :APOLICOR-COD-SUBGRUPO AND RAMO_COBERTURA = :APOLICOR-RAMO-COBERTURA AND MODALI_COBERTURA = :APOLICOR-MODALI-COBERTURA AND DATA_INIVIGENCIA <= :APOLICOR-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :APOLICOR-DATA-INIVIGENCIA WITH UR END-EXEC. */
            CCORRET = new RE0002S_CCORRET(true);
            string GetQuery_CCORRET()
            {
                var query = @$"SELECT PCT_PART_CORRETOR
							, 
							PCT_COM_CORRETOR 
							FROM SEGUROS.APOLICE_CORRETOR 
							WHERE NUM_APOLICE = '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO}' 
							AND RAMO_COBERTURA = '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA}' 
							AND MODALI_COBERTURA = '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA}' 
							AND DATA_INIVIGENCIA <= '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA}' 
							AND DATA_TERVIGENCIA >= '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA}'";

                return query;
            }
            CCORRET.GetQueryEvent += GetQuery_CCORRET;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-FETCH-MRAPOCOB-SECTION */
        private void R1200_00_FETCH_MRAPOCOB_SECTION()
        {
            /*" -471- PERFORM R1200_00_FETCH_MRAPOCOB_DB_FETCH_1 */

            R1200_00_FETCH_MRAPOCOB_DB_FETCH_1();

            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -475- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -476- MOVE 'S' TO WFIM-MRAPOCOB */
                    _.Move("S", AREAS_AUXILIARES.WFIM_MRAPOCOB);

                    /*" -476- PERFORM R1200_00_FETCH_MRAPOCOB_DB_CLOSE_1 */

                    R1200_00_FETCH_MRAPOCOB_DB_CLOSE_1();

                    /*" -478- ELSE */
                }
                else
                {


                    /*" -479- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -481- MOVE 'R1200 - ERRO NO FETCH DA TABL MR_APOLICE_COBER' TO WS-MENSAGEM */
                    _.Move("R1200 - ERRO NO FETCH DA TABL MR_APOLICE_COBER", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -482- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -483- END-IF */
                }


                /*" -483- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-FETCH-MRAPOCOB-DB-FETCH-1 */
        public void R1200_00_FETCH_MRAPOCOB_DB_FETCH_1()
        {
            /*" -471- EXEC SQL FETCH C01_MRAPOCOB INTO :MRAPOCOB-COD-COBERTURA , :MRAPOCOB-RAMO-COBERTURA , :MRAPOCOB-MODALI-COBERTURA , :MRAPOCOB-IMP-SEGURADA-IX , :MRAPOCOB-PRM-TARIFARIO-VAR, :MRAPOCOB-COD-EMPRESA END-EXEC. */

            if (C01_MRAPOCOB.Fetch())
            {
                _.Move(C01_MRAPOCOB.MRAPOCOB_COD_COBERTURA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_COBERTURA);
                _.Move(C01_MRAPOCOB.MRAPOCOB_RAMO_COBERTURA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_RAMO_COBERTURA);
                _.Move(C01_MRAPOCOB.MRAPOCOB_MODALI_COBERTURA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_MODALI_COBERTURA);
                _.Move(C01_MRAPOCOB.MRAPOCOB_IMP_SEGURADA_IX, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_IX);
                _.Move(C01_MRAPOCOB.MRAPOCOB_PRM_TARIFARIO_VAR, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_VAR);
                _.Move(C01_MRAPOCOB.MRAPOCOB_COD_EMPRESA, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R1200-00-FETCH-MRAPOCOB-DB-CLOSE-1 */
        public void R1200_00_FETCH_MRAPOCOB_DB_CLOSE_1()
        {
            /*" -476- EXEC SQL CLOSE C01_MRAPOCOB END-EXEC */

            C01_MRAPOCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-MRAPOCOB-SECTION */
        private void R1300_00_PROCESSA_MRAPOCOB_SECTION()
        {
            /*" -524- PERFORM R1400-00-SELECT-PROD-COBT. */

            R1400_00_SELECT_PROD_COBT_SECTION();

            /*" -526- IF MRPROCOB-IND-CESSAO EQUAL 'A' OR MRPROCOB-IND-RESSEGURO EQUAL 'A' */

            if (MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_CESSAO == "A" || MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_RESSEGURO == "A")
            {

                /*" -528- MOVE 'COBERTURA SEM IDENTIFICACAO DE RESSEGURO' TO WS-MENSAGEM */
                _.Move("COBERTURA SEM IDENTIFICACAO DE RESSEGURO", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -529- MOVE 999 TO WS-RETORNO */
                _.Move(999, AREAS_AUXILIARES.WS_RETORNO);

                /*" -530- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -534- END-IF. */
            }


            /*" -535- IF MRPROCOB-COD-PRODUTO EQUAL 1804 */

            if (MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO == 1804)
            {

                /*" -536- IF LKRE02-DTEMS-AP < '2021-05-17' */

                if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTEMS_AP < "2021-05-17")
                {

                    /*" -537- IF MRPROCOB-IND-CESSAO EQUAL 'S' */

                    if (MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_CESSAO == "S")
                    {

                        /*" -539- COMPUTE WS-IMPSEG-IX = WS-IMPSEG-IX + MRAPOCOB-IMP-SEGURADA-IX */
                        AREAS_AUXILIARES.WS_IMPSEG_IX.Value = AREAS_AUXILIARES.WS_IMPSEG_IX + MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_IX;

                        /*" -540- END-IF */
                    }


                    /*" -541- ELSE */
                }
                else
                {


                    /*" -542- IF MRPROCOB-IND-RESSEGURO EQUAL 'S' */

                    if (MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_RESSEGURO == "S")
                    {

                        /*" -544- COMPUTE WS-IMPSEG-IX = WS-IMPSEG-IX + MRAPOCOB-IMP-SEGURADA-IX */
                        AREAS_AUXILIARES.WS_IMPSEG_IX.Value = AREAS_AUXILIARES.WS_IMPSEG_IX + MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_IMP_SEGURADA_IX;

                        /*" -545- END-IF */
                    }


                    /*" -547- END-IF */
                }


                /*" -548- IF MRPROCOB-IND-RESSEGURO EQUAL 'S' */

                if (MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_RESSEGURO == "S")
                {

                    /*" -550- COMPUTE WS-PRMTAR-VR = WS-PRMTAR-VR + MRAPOCOB-PRM-TARIFARIO-VAR */
                    AREAS_AUXILIARES.WS_PRMTAR_VR.Value = AREAS_AUXILIARES.WS_PRMTAR_VR + MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_VAR;

                    /*" -552- COMPUTE WS-PRMTAR-IT = WS-PRMTAR-IT + MRAPOCOB-PRM-TARIFARIO-VAR */
                    AREAS_AUXILIARES.WS_PRMTAR_IT.Value = AREAS_AUXILIARES.WS_PRMTAR_IT + MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_VAR;

                    /*" -553- END-IF */
                }


                /*" -555- END-IF. */
            }


            /*" -555- PERFORM R1200-00-FETCH-MRAPOCOB. */

            R1200_00_FETCH_MRAPOCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PROD-COBT-SECTION */
        private void R1400_00_SELECT_PROD_COBT_SECTION()
        {
            /*" -580- PERFORM R1400_00_SELECT_PROD_COBT_DB_SELECT_1 */

            R1400_00_SELECT_PROD_COBT_DB_SELECT_1();

            /*" -583- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -584- MOVE SQLCODE TO WS-RETORNO */
                _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                /*" -586- MOVE 'R1400 - ERRO NO SELECT DA TABL MR_PRODUTO_COBER' TO WS-MENSAGEM */
                _.Move("R1400 - ERRO NO SELECT DA TABL MR_PRODUTO_COBER", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -587- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -587- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-PROD-COBT-DB-SELECT-1 */
        public void R1400_00_SELECT_PROD_COBT_DB_SELECT_1()
        {
            /*" -580- EXEC SQL SELECT IND_RESSEGURO , IND_CESSAO , COD_TP_COBERTURA INTO :MRPROCOB-IND-RESSEGURO , :MRPROCOB-IND-CESSAO , :MRPROCOB-COD-TP-COBERTURA FROM SEGUROS.MR_PRODUTO_COBER WHERE COD_PRODUTO = :MRPROCOB-COD-PRODUTO AND COD_EMPRESA = :MRAPOCOB-COD-EMPRESA AND NUM_VERSAO = :MRAPOITE-NUM-VERSAO AND RAMO_COBERTURA = :MRAPOCOB-RAMO-COBERTURA AND MODALI_COBERTURA = :MRAPOCOB-MODALI-COBERTURA AND COD_COBERTURA = :MRAPOCOB-COD-COBERTURA WITH UR END-EXEC. */

            var r1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1 = new R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1()
            {
                MRAPOCOB_MODALI_COBERTURA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_MODALI_COBERTURA.ToString(),
                MRAPOCOB_RAMO_COBERTURA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_RAMO_COBERTURA.ToString(),
                MRAPOCOB_COD_COBERTURA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_COBERTURA.ToString(),
                MRPROCOB_COD_PRODUTO = MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO.ToString(),
                MRAPOCOB_COD_EMPRESA = MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_EMPRESA.ToString(),
                MRAPOITE_NUM_VERSAO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_VERSAO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MRPROCOB_IND_RESSEGURO, MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_RESSEGURO);
                _.Move(executed_1.MRPROCOB_IND_CESSAO, MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_IND_CESSAO);
                _.Move(executed_1.MRPROCOB_COD_TP_COBERTURA, MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_TP_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-CALCULA-DESCONTOS-SECTION */
        private void R1500_00_CALCULA_DESCONTOS_SECTION()
        {
            /*" -598- IF LKRE02-COD-PROD = 1804 */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_PROD == 1804)
            {

                /*" -602- MOVE ZEROS TO WS-DSCT-COBER WS-DSCT-BONUS WS-DSCT-FIDEL */
                _.Move(0, AREAS_AUXILIARES.WS_DSCT_COBER, AREAS_AUXILIARES.WS_DSCT_BONUS, AREAS_AUXILIARES.WS_DSCT_FIDEL);

                /*" -603- IF LKRE02-TIP-ENDS = '0' OR '1' */

                if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_TIP_ENDS.In("0", "1"))
                {

                    /*" -604- PERFORM R1600-00-PROCESSA-DESCTO */

                    R1600_00_PROCESSA_DESCTO_SECTION();

                    /*" -606- END-IF */
                }


                /*" -609- COMPUTE WS-PCT-DSCT = WS-DSCT-COBER + WS-DSCT-BONUS + WS-DSCT-FIDEL */
                AREAS_AUXILIARES.WS_PCT_DSCT.Value = AREAS_AUXILIARES.WS_DSCT_COBER + AREAS_AUXILIARES.WS_DSCT_BONUS + AREAS_AUXILIARES.WS_DSCT_FIDEL;

                /*" -609- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-DESCTO-SECTION */
        private void R1600_00_PROCESSA_DESCTO_SECTION()
        {
            /*" -620- MOVE LKRE02-NUM-APOL TO MR022-NUM-APOLICE. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL, MR022.DCLMR_APOL_ITEM_EMPR.MR022_NUM_APOLICE);

            /*" -622- MOVE LKRE02-NUM-ENDS TO MR022-NUM-ENDOSSO. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ENDS, MR022.DCLMR_APOL_ITEM_EMPR.MR022_NUM_ENDOSSO);

            /*" -624- PERFORM R1700-SELECT-MR022. */

            R1700_SELECT_MR022_SECTION();

            /*" -625- IF LKRE02-NUM-ITEM NOT = ZEROS */

            if (LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ITEM != 00)
            {

                /*" -626- MOVE LKRE02-NUM-APOL TO MRAPOITE-NUM-APOLICE */
                _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_APOLICE);

                /*" -627- MOVE LKRE02-NUM-ENDS TO MRAPOITE-NUM-ENDOSSO */
                _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_ENDS, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ENDOSSO);

                /*" -628- PERFORM R1800-SELECT-MRAPOITE */

                R1800_SELECT_MRAPOITE_SECTION();

                /*" -630- END-IF. */
            }


            /*" -631- MOVE MR022-PCT-DESC-COBERTURA TO WS-DSCT-COBER. */
            _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA, AREAS_AUXILIARES.WS_DSCT_COBER);

            /*" -632- MOVE MR022-PCT-BONUS-RENOVCAO TO WS-DSCT-BONUS. */
            _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO, AREAS_AUXILIARES.WS_DSCT_BONUS);

            /*" -632- MOVE MRAPOITE-PCT-DESC-FIDEL TO WS-DSCT-FIDEL. */
            _.Move(MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL, AREAS_AUXILIARES.WS_DSCT_FIDEL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-SELECT-MR022-SECTION */
        private void R1700_SELECT_MR022_SECTION()
        {
            /*" -664- PERFORM R1700_SELECT_MR022_DB_SELECT_1 */

            R1700_SELECT_MR022_DB_SELECT_1();

            /*" -667- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -668- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -671- MOVE ZEROS TO MR022-PCT-DESC-COBERTURA MR022-PCT-BONUS-RENOVCAO MR022-PCT-DESC-CORRETOR */
                    _.Move(0, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_CORRETOR);

                    /*" -672- ELSE */
                }
                else
                {


                    /*" -674- MOVE 'R1700 - ERRO NO SELECT TABL MR_APOL_ITEM_EMPR' TO WS-MENSAGEM */
                    _.Move("R1700 - ERRO NO SELECT TABL MR_APOL_ITEM_EMPR", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -675- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -676- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -677- END-IF */
                }


                /*" -677- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-SELECT-MR022-DB-SELECT-1 */
        public void R1700_SELECT_MR022_DB_SELECT_1()
        {
            /*" -664- EXEC SQL SELECT VALUE(A.PCT_DESC_COBERTURA,+0), VALUE(A.PCT_BONUS_RENOVCAO,+0), VALUE(A.PCT_DESC_CORRETOR,+0) INTO :MR022-PCT-DESC-COBERTURA, :MR022-PCT-BONUS-RENOVCAO, :MR022-PCT-DESC-CORRETOR FROM SEGUROS.MR_APOL_ITEM_EMPR A WHERE A.NUM_APOLICE = :MR022-NUM-APOLICE AND A.NUM_ENDOSSO = :MR022-NUM-ENDOSSO AND A.NUM_ITEM = :MRAPOITE-NUM-ITEM AND A.NUM_SUB_ITEM = (SELECT MAX(B.NUM_SUB_ITEM) FROM SEGUROS.MR_APOL_ITEM_EMPR B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_ITEM = A.NUM_ITEM) WITH UR END-EXEC. */

            var r1700_SELECT_MR022_DB_SELECT_1_Query1 = new R1700_SELECT_MR022_DB_SELECT_1_Query1()
            {
                MR022_NUM_APOLICE = MR022.DCLMR_APOL_ITEM_EMPR.MR022_NUM_APOLICE.ToString(),
                MR022_NUM_ENDOSSO = MR022.DCLMR_APOL_ITEM_EMPR.MR022_NUM_ENDOSSO.ToString(),
                MRAPOITE_NUM_ITEM = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM.ToString(),
            };

            var executed_1 = R1700_SELECT_MR022_DB_SELECT_1_Query1.Execute(r1700_SELECT_MR022_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MR022_PCT_DESC_COBERTURA, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA);
                _.Move(executed_1.MR022_PCT_BONUS_RENOVCAO, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO);
                _.Move(executed_1.MR022_PCT_DESC_CORRETOR, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_CORRETOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-SELECT-MRAPOITE-SECTION */
        private void R1800_SELECT_MRAPOITE_SECTION()
        {
            /*" -696- PERFORM R1800_SELECT_MRAPOITE_DB_SELECT_1 */

            R1800_SELECT_MRAPOITE_DB_SELECT_1();

            /*" -699- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -700- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -701- MOVE ZEROS TO MRAPOITE-PCT-DESC-FIDEL */
                    _.Move(0, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL);

                    /*" -702- ELSE */
                }
                else
                {


                    /*" -704- MOVE 'R1800 - ERRO NO SELECT DA TABELA MR_APOLICE_ITEM' TO WS-MENSAGEM */
                    _.Move("R1800 - ERRO NO SELECT DA TABELA MR_APOLICE_ITEM", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -705- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -706- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -707- END-IF */
                }


                /*" -707- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-SELECT-MRAPOITE-DB-SELECT-1 */
        public void R1800_SELECT_MRAPOITE_DB_SELECT_1()
        {
            /*" -696- EXEC SQL SELECT VALUE(PCT_DESC_FIDEL,+0) INTO :MRAPOITE-PCT-DESC-FIDEL FROM SEGUROS.MR_APOLICE_ITEM WHERE NUM_APOLICE = :MRAPOITE-NUM-APOLICE AND NUM_ENDOSSO = :MRAPOITE-NUM-ENDOSSO AND NUM_ITEM = :MRAPOITE-NUM-ITEM AND COD_PRODUTO = :MRPROCOB-COD-PRODUTO WITH UR END-EXEC. */

            var r1800_SELECT_MRAPOITE_DB_SELECT_1_Query1 = new R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1()
            {
                MRAPOITE_NUM_APOLICE = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_APOLICE.ToString(),
                MRAPOITE_NUM_ENDOSSO = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ENDOSSO.ToString(),
                MRPROCOB_COD_PRODUTO = MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO.ToString(),
                MRAPOITE_NUM_ITEM = MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM.ToString(),
            };

            var executed_1 = R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1.Execute(r1800_SELECT_MRAPOITE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MRAPOITE_PCT_DESC_FIDEL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CALCULA-EXPURGOS-SECTION */
        private void R2000_00_CALCULA_EXPURGOS_SECTION()
        {
            /*" -721- MOVE ZEROS TO WS-PCT-CORR. */
            _.Move(0, AREAS_AUXILIARES.WS_PCT_CORR);

            /*" -722- MOVE LKRE02-NUM-APOL TO APOLICOR-NUM-APOLICE. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -723- MOVE LKRE02-COD-SUBG TO APOLICOR-COD-SUBGRUPO. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_COD_SUBG, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

            /*" -724- MOVE LKRE02-RAMO-CBT TO APOLICOR-RAMO-COBERTURA. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_RAMO_CBT, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -725- MOVE LKRE02-MODL-CBT TO APOLICOR-MODALI-COBERTURA. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_MODL_CBT, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA);

            /*" -727- MOVE LKRE02-DTINIVIG TO APOLICOR-DATA-INIVIGENCIA. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTINIVIG, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA);

            /*" -729- PERFORM R2100-00-DECLARE-APOLICOR. */

            R2100_00_DECLARE_APOLICOR_SECTION();

            /*" -732- PERFORM R2200-00-FETCH-APOLICOR UNTIL WFIM-APOLICOR EQUAL 'S' . */

            while (!(AREAS_AUXILIARES.WFIM_APOLICOR == "S"))
            {

                R2200_00_FETCH_APOLICOR_SECTION();
            }

            /*" -740- COMPUTE WS-VLCOMISS = (WS-PRMTAR-VR - WS-VLDESCTO) * WS-PCT-CORR / 100. */
            AREAS_AUXILIARES.WS_VLCOMISS.Value = (AREAS_AUXILIARES.WS_PRMTAR_VR - AREAS_AUXILIARES.WS_VLDESCTO) * AREAS_AUXILIARES.WS_PCT_CORR / 100f;

            /*" -742- MOVE ZEROS TO WS-PCT-COSC. */
            _.Move(0, AREAS_AUXILIARES.WS_PCT_COSC);

            /*" -743- MOVE LKRE02-NUM-APOL TO APOLCOSS-NUM-APOLICE. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_NUM_APOL, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_NUM_APOLICE);

            /*" -745- MOVE LKRE02-DTINIVIG TO APOLCOSS-DATA-INIVIGENCIA. */
            _.Move(LK_RE0002S.LKRE02_ENTRADA.LKRE02_DTINIVIG, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_DATA_INIVIGENCIA);

            /*" -747- PERFORM R2300-00-SELECT-APOLCOSS. */

            R2300_00_SELECT_APOLCOSS_SECTION();

            /*" -748- COMPUTE WS-VLCOSCED = (WS-PRMTAR-VR - WS-VLDESCTO) * WS-PCT-COSC / 100. */
            AREAS_AUXILIARES.WS_VLCOSCED.Value = (AREAS_AUXILIARES.WS_PRMTAR_VR - AREAS_AUXILIARES.WS_VLDESCTO) * AREAS_AUXILIARES.WS_PCT_COSC / 100f;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-APOLICOR-SECTION */
        private void R2100_00_DECLARE_APOLICOR_SECTION()
        {
            /*" -772- PERFORM R2100_00_DECLARE_APOLICOR_DB_DECLARE_1 */

            R2100_00_DECLARE_APOLICOR_DB_DECLARE_1();

            /*" -774- PERFORM R2100_00_DECLARE_APOLICOR_DB_OPEN_1 */

            R2100_00_DECLARE_APOLICOR_DB_OPEN_1();

            /*" -777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -778- MOVE SQLCODE TO WS-RETORNO */
                _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                /*" -780- MOVE 'R2100 - ERRO NO DECLARE DA TAB APOLICE_CORRETOR' TO WS-MENSAGEM */
                _.Move("R2100 - ERRO NO DECLARE DA TAB APOLICE_CORRETOR", AREAS_AUXILIARES.WS_MENSAGEM);

                /*" -781- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -782- ELSE */
            }
            else
            {


                /*" -783- MOVE 'N' TO WFIM-APOLICOR */
                _.Move("N", AREAS_AUXILIARES.WFIM_APOLICOR);

                /*" -783- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-APOLICOR-DB-OPEN-1 */
        public void R2100_00_DECLARE_APOLICOR_DB_OPEN_1()
        {
            /*" -774- EXEC SQL OPEN CCORRET END-EXEC. */

            CCORRET.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-FETCH-APOLICOR-SECTION */
        private void R2200_00_FETCH_APOLICOR_SECTION()
        {
            /*" -796- PERFORM R2200_00_FETCH_APOLICOR_DB_FETCH_1 */

            R2200_00_FETCH_APOLICOR_DB_FETCH_1();

            /*" -799- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -800- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -801- MOVE 'S' TO WFIM-APOLICOR */
                    _.Move("S", AREAS_AUXILIARES.WFIM_APOLICOR);

                    /*" -801- PERFORM R2200_00_FETCH_APOLICOR_DB_CLOSE_1 */

                    R2200_00_FETCH_APOLICOR_DB_CLOSE_1();

                    /*" -803- ELSE */
                }
                else
                {


                    /*" -804- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -806- MOVE 'R2200 - ERRO NO FETCH DA APOLICE_CORRETOR' TO WS-MENSAGEM */
                    _.Move("R2200 - ERRO NO FETCH DA APOLICE_CORRETOR", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -807- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -808- END-IF */
                }


                /*" -809- ELSE */
            }
            else
            {


                /*" -816- COMPUTE WS-PCT-CORR = WS-PCT-CORR + (APOLICOR-PCT-COM-CORRETOR * APOLICOR-PCT-PART-CORRETOR / 100) */
                AREAS_AUXILIARES.WS_PCT_CORR.Value = AREAS_AUXILIARES.WS_PCT_CORR + (APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR * APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR / 100f);

                /*" -816- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-FETCH-APOLICOR-DB-FETCH-1 */
        public void R2200_00_FETCH_APOLICOR_DB_FETCH_1()
        {
            /*" -796- EXEC SQL FETCH CCORRET INTO :APOLICOR-PCT-PART-CORRETOR, :APOLICOR-PCT-COM-CORRETOR END-EXEC. */

            if (CCORRET.Fetch())
            {
                _.Move(CCORRET.APOLICOR_PCT_PART_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);
                _.Move(CCORRET.APOLICOR_PCT_COM_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);
            }

        }

        [StopWatch]
        /*" R2200-00-FETCH-APOLICOR-DB-CLOSE-1 */
        public void R2200_00_FETCH_APOLICOR_DB_CLOSE_1()
        {
            /*" -801- EXEC SQL CLOSE CCORRET END-EXEC */

            CCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-APOLCOSS-SECTION */
        private void R2300_00_SELECT_APOLCOSS_SECTION()
        {
            /*" -834- PERFORM R2300_00_SELECT_APOLCOSS_DB_SELECT_1 */

            R2300_00_SELECT_APOLCOSS_DB_SELECT_1();

            /*" -837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -838- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -839- MOVE ZEROS TO WS-PCT-COSC */
                    _.Move(0, AREAS_AUXILIARES.WS_PCT_COSC);

                    /*" -840- ELSE */
                }
                else
                {


                    /*" -841- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -843- MOVE 'R2300 - ERRO NO SELECT DA APOL_COSSEGURADORA' TO WS-MENSAGEM */
                    _.Move("R2300 - ERRO NO SELECT DA APOL_COSSEGURADORA", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -844- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -845- END-IF */
                }


                /*" -846- ELSE */
            }
            else
            {


                /*" -847- MOVE APOLCOSS-PCT-PART-COSSEGURO TO WS-PCT-COSC */
                _.Move(APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO, AREAS_AUXILIARES.WS_PCT_COSC);

                /*" -847- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-APOLCOSS-DB-SELECT-1 */
        public void R2300_00_SELECT_APOLCOSS_DB_SELECT_1()
        {
            /*" -834- EXEC SQL SELECT VALUE(SUM(PCT_PART_COSSEGURO),+0) INTO :APOLCOSS-PCT-PART-COSSEGURO FROM SEGUROS.APOL_COSSEGURADORA WHERE NUM_APOLICE = :APOLCOSS-NUM-APOLICE AND DATA_INIVIGENCIA <= :APOLCOSS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :APOLCOSS-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1 = new R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1()
            {
                APOLCOSS_DATA_INIVIGENCIA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_DATA_INIVIGENCIA.ToString(),
                APOLCOSS_NUM_APOLICE = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_APOLCOSS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOSS_PCT_PART_COSSEGURO, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-PARCEHIS-SECTION */
        private void R2500_00_SELECT_PARCEHIS_SECTION()
        {
            /*" -868- PERFORM R2500_00_SELECT_PARCEHIS_DB_SELECT_1 */

            R2500_00_SELECT_PARCEHIS_DB_SELECT_1();

            /*" -871- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -872- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -873- MOVE ZEROS TO WS-FATOR-ADIC */
                    _.Move(0, AREAS_AUXILIARES.WS_FATOR_ADIC);

                    /*" -874- ELSE */
                }
                else
                {


                    /*" -875- MOVE SQLCODE TO WS-RETORNO */
                    _.Move(DB.SQLCODE, AREAS_AUXILIARES.WS_RETORNO);

                    /*" -877- MOVE 'R2500 - ERRO NO SELECT DA PARCELA_HISTORICO' TO WS-MENSAGEM */
                    _.Move("R2500 - ERRO NO SELECT DA PARCELA_HISTORICO", AREAS_AUXILIARES.WS_MENSAGEM);

                    /*" -878- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -879- END-IF */
                }


                /*" -880- ELSE */
            }
            else
            {


                /*" -881- IF PARCEHIS-PRM-LIQUIDO = ZEROS */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO == 00)
                {

                    /*" -882- MOVE ZEROS TO WS-FATOR-ADIC */
                    _.Move(0, AREAS_AUXILIARES.WS_FATOR_ADIC);

                    /*" -883- ELSE */
                }
                else
                {


                    /*" -885- COMPUTE WS-FATOR-ADIC = PARCEHIS-ADICIONAL-FRACIO / PARCEHIS-PRM-LIQUIDO */
                    AREAS_AUXILIARES.WS_FATOR_ADIC.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO / PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO;

                    /*" -886- END-IF */
                }


                /*" -886- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-PARCEHIS-DB-SELECT-1 */
        public void R2500_00_SELECT_PARCEHIS_DB_SELECT_1()
        {
            /*" -868- EXEC SQL SELECT VALUE(SUM(PRM_LIQUIDO),+0), VALUE(SUM(ADICIONAL_FRACIO),+0) INTO :PARCEHIS-PRM-LIQUIDO, :PARCEHIS-ADICIONAL-FRACIO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND OCORR_HISTORICO = 01 AND COD_OPERACAO < 0200 WITH UR END-EXEC. */

            var r2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 = new R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(executed_1.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -905- MOVE +0 TO WS-IMPSEG-IX WS-PRMTAR-VR WS-VLDESCTO WS-PCT-CORR WS-PCT-COSC WS-FATOR-ADIC WS-VLCOMISS WS-VLCOSCED. */
            _.Move(+0, AREAS_AUXILIARES.WS_IMPSEG_IX, AREAS_AUXILIARES.WS_PRMTAR_VR, AREAS_AUXILIARES.WS_VLDESCTO, AREAS_AUXILIARES.WS_PCT_CORR, AREAS_AUXILIARES.WS_PCT_COSC, AREAS_AUXILIARES.WS_FATOR_ADIC, AREAS_AUXILIARES.WS_VLCOMISS, AREAS_AUXILIARES.WS_VLCOSCED);

            /*" -906- MOVE WS-RETORNO TO LKRE02-COD-RETN. */
            _.Move(AREAS_AUXILIARES.WS_RETORNO, LK_RE0002S.LKRE02_SAIDA.LKRE02_COD_RETN);

            /*" -908- MOVE WS-MENSAGEM TO LKRE02-MENSAGEM. */
            _.Move(AREAS_AUXILIARES.WS_MENSAGEM, LK_RE0002S.LKRE02_SAIDA.LKRE02_MENSAGEM);

            /*" -908- GOBACK. */

            throw new GoBack();

        }
    }
}