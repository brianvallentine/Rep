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
using Sias.Bilhetes.DB2.BI0005S;

namespace Code
{
    public class BI0005S
    {
        public bool IsCall { get; set; }

        public BI0005S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  BI - BILHETES                      *      */
        /*"      *   PROGRAMA ...............  BI0005S.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  CANETTA                            *      */
        /*"      *   PROGRAMADOR ............  CANETTA                            *      */
        /*"      *   DATA CODIFICACAO .......  04/2024                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CONSULTA PESSOA                    *      */
        /*"      *                                                                *      */
        /*"      *   LINKAGE: BO0005L                                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACOES                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.00  * VERSAO XX EM XX/XXXX - JAZZ XXXXXX                             *      */
        /*"      *   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.00                        XXXXXXX             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01           WS-WORKING.*/
        public BI0005S_WS_WORKING WS_WORKING { get; set; } = new BI0005S_WS_WORKING();
        public class BI0005S_WS_WORKING : VarBasis
        {
            /*"  03         WS-AUXILIARES.*/
            public BI0005S_WS_AUXILIARES WS_AUXILIARES { get; set; } = new BI0005S_WS_AUXILIARES();
            public class BI0005S_WS_AUXILIARES : VarBasis
            {
                /*"    05       WS-SQLCODE         PIC   ---9.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05       WS-MAX-SEQ-EMA     PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis WS_MAX_SEQ_EMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-MAX-SEQ-TEL     PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis WS_MAX_SEQ_TEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-MAX-OCO-END     PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis WS_MAX_OCO_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       IND-TEL            PIC S9(003) COMP-3  VALUE +0.*/
                public IntBasis IND_TEL { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05       VIND-FILLER        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_FILLER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03         NIVEIS-88.*/
            }
            public BI0005S_NIVEIS_88 NIVEIS_88 { get; set; } = new BI0005S_NIVEIS_88();
            public class BI0005S_NIVEIS_88 : VarBasis
            {
                /*"    05       N88-CADASTRO-PESS  PIC  X(001)    VALUE '&'.*/

                public SelectorBasis N88_CADASTRO_PESS { get; set; } = new SelectorBasis("001", "&")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     PESSOA-CADASTRADA                 VALUE 'S'. */
							new SelectorItemBasis("PESSOA_CADASTRADA", "S")
                }
                };

                /*"01           BI0005L-LINKAGE.*/
            }
        }
        public BI0005S_BI0005L_LINKAGE BI0005L_LINKAGE { get; set; } = new BI0005S_BI0005L_LINKAGE();
        public class BI0005S_BI0005L_LINKAGE : VarBasis
        {
            /*"  03         BI0005L-ENTRADA.*/
            public BI0005S_BI0005L_ENTRADA BI0005L_ENTRADA { get; set; } = new BI0005S_BI0005L_ENTRADA();
            public class BI0005S_BI0005L_ENTRADA : VarBasis
            {
                /*"    05       BI0005L-E-COD-PESSOA    PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_E_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  03         BI0005L-SAIDA.*/
            }
            public BI0005S_BI0005L_SAIDA BI0005L_SAIDA { get; set; } = new BI0005S_BI0005L_SAIDA();
            public class BI0005S_BI0005L_SAIDA : VarBasis
            {
                /*"    05       BI0005L-S-NOME-PESSOA   PIC  X(040).*/
                public StringBasis BI0005L_S_NOME_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-TIPO-PESSOA   PIC  X(001).*/
                public StringBasis BI0005L_S_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-SIGLA-PESSOA  PIC  X(010).*/
                public StringBasis BI0005L_S_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05       BI0005L-S-CPF           PIC S9(011)    COMP-3.*/
                public IntBasis BI0005L_S_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                /*"    05       BI0005L-S-DATA-NASC     PIC X(010).*/
                public StringBasis BI0005L_S_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05       BI0005L-S-SEXO          PIC  X(001).*/
                public StringBasis BI0005L_S_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-ESTADO-CIVIL  PIC  X(001).*/
                public StringBasis BI0005L_S_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-NUM-IDENT     PIC  X(015).*/
                public StringBasis BI0005L_S_NUM_IDENT { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05       BI0005L-S-ORGAO-EXPED   PIC  X(005).*/
                public StringBasis BI0005L_S_ORGAO_EXPED { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05       BI0005L-S-UF-EXPEDIDORA PIC  X(002).*/
                public StringBasis BI0005L_S_UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       BI0005L-S-DATA-EXPED    PIC  X(010).*/
                public StringBasis BI0005L_S_DATA_EXPED { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05       BI0005L-S-COD-CBO       PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_S_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       BI0005L-S-TIP-IDE-SIVPF PIC  X(005).*/
                public StringBasis BI0005L_S_TIP_IDE_SIVPF { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05       BI0005L-S-CGC           PIC S9(015)    COMP-3.*/
                public IntBasis BI0005L_S_CGC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"    05       BI0005L-S-NOME-FANTASIA PIC  X(040).*/
                public StringBasis BI0005L_S_NOME_FANTASIA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-ENDERECO-R    PIC  X(040).*/
                public StringBasis BI0005L_S_ENDERECO_R { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-TIPO-ENDER-R  PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_TIPO_ENDER_R { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-COMPL-ENDER-R PIC  X(015).*/
                public StringBasis BI0005L_S_COMPL_ENDER_R { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05       BI0005L-S-BAIRRO-R      PIC  X(020).*/
                public StringBasis BI0005L_S_BAIRRO_R { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-CEP-R         PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_S_CEP_R { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       BI0005L-S-CIDADE-R      PIC  X(020).*/
                public StringBasis BI0005L_S_CIDADE_R { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-SIGLA-UF-R    PIC  X(002).*/
                public StringBasis BI0005L_S_SIGLA_UF_R { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       BI0005L-S-SIT-ENDER-R   PIC  X(001).*/
                public StringBasis BI0005L_S_SIT_ENDER_R { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-OCC-END-R     PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_OCC_END_R { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-ENDERECO-C    PIC  X(040).*/
                public StringBasis BI0005L_S_ENDERECO_C { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-TIPO-ENDER-C  PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_TIPO_ENDER_C { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-COMPL-ENDER-C PIC  X(015).*/
                public StringBasis BI0005L_S_COMPL_ENDER_C { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05       BI0005L-S-BAIRRO-C      PIC  X(020).*/
                public StringBasis BI0005L_S_BAIRRO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-CEP-C         PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_S_CEP_C { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       BI0005L-S-CIDADE-C      PIC  X(020).*/
                public StringBasis BI0005L_S_CIDADE_C { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-SIGLA-UF-C    PIC  X(002).*/
                public StringBasis BI0005L_S_SIGLA_UF_C { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       BI0005L-S-SIT-ENDER-C   PIC  X(001).*/
                public StringBasis BI0005L_S_SIT_ENDER_C { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-OCC-END-C     PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_OCC_END_C { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-EMAIL         PIC  X(040).*/
                public StringBasis BI0005L_S_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-SIT-EMAIL     PIC  X(001).*/
                public StringBasis BI0005L_S_SIT_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-TELEFONE      OCCURS    003       TIMES.*/
                public ListBasis<BI0005S_BI0005L_S_TELEFONE> BI0005L_S_TELEFONE { get; set; } = new ListBasis<BI0005S_BI0005L_S_TELEFONE>(003);
                public class BI0005S_BI0005L_S_TELEFONE : VarBasis
                {
                    /*"      07     BI0005L-S-TIPO-FONE     PIC S9(004)    COMP-3.*/
                    public IntBasis BI0005L_S_TIPO_FONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     BI0005L-S-DDI           PIC S9(004)    COMP-3.*/
                    public IntBasis BI0005L_S_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     BI0005L-S-DDD           PIC S9(004)    COMP-3.*/
                    public IntBasis BI0005L_S_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     BI0005L-S-NUM-FONE      PIC S9(011)    COMP-3.*/
                    public IntBasis BI0005L_S_NUM_FONE { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                    /*"      07     BI0005L-S-SIT-FONE      PIC  X(001).*/
                    public StringBasis BI0005L_S_SIT_FONE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    05        BI0005L-S-COD-ERR       PIC S9(004)    COMP-3.*/
                }
                public IntBasis BI0005L_S_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05        BI0005L-S-COD-SQL       PIC   ---9.*/
                public IntBasis BI0005L_S_COD_SQL { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05        BI0005L-S-LIT-ERR       PIC  X(030).*/
                public StringBasis BI0005L_S_LIT_ERR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.PESSOJUR PESSOJUR { get; set; } = new Dclgens.PESSOJUR();
        public Dclgens.PESSOEND PESSOEND { get; set; } = new Dclgens.PESSOEND();
        public Dclgens.PESSOEMA PESSOEMA { get; set; } = new Dclgens.PESSOEMA();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(BI0005S_BI0005L_LINKAGE BI0005S_BI0005L_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*BI0005L_LINKAGE*/
        {
            try
            {
                this.BI0005L_LINKAGE = BI0005S_BI0005L_LINKAGE_P;

                /*" -0- FLUXCONTROL_PERFORM M-0000-00-BI0005S-SECTION */

                M_0000_00_BI0005S_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { BI0005L_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" M-0000-00-BI0005S-SECTION */
        private void M_0000_00_BI0005S_SECTION()
        {
            /*" -144- DISPLAY '0000-00-BI0005S        ' */
            _.Display($"0000-00-BI0005S        ");

            /*" -145- DISPLAY '***' */
            _.Display($"***");

            /*" -146- DISPLAY 'BI0005L-E-COD-PESSOA: ' BI0005L-E-COD-PESSOA */
            _.Display($"BI0005L-E-COD-PESSOA: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}");

            /*" -149- DISPLAY '***' */
            _.Display($"***");

            /*" -151- PERFORM 10000-00-INICIAL THRU 10000-99-SAIDA */

            M_10000_00_INICIAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/


            /*" -153- PERFORM 30000-00-TRATA-PESSOA THRU 30000-99-SAIDA */

            M_30000_00_TRATA_PESSOA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_30000_99_SAIDA*/


            /*" -157- PERFORM 50000-00-TRATA-TELEFONE THRU 50000-99-SAIDA VARYING IND-TEL FROM 001 BY 001 UNTIL IND-TEL GREATER 003 */

            for (WS_WORKING.WS_AUXILIARES.IND_TEL.Value = 001; !(WS_WORKING.WS_AUXILIARES.IND_TEL > 003); WS_WORKING.WS_AUXILIARES.IND_TEL.Value += 001)
            {

                M_50000_00_TRATA_TELEFONE_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/

            }

            /*" -159- PERFORM 70000-00-TRATA-EMAIL THRU 70000-99-SAIDA */

            M_70000_00_TRATA_EMAIL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/


            /*" -161- PERFORM 90000-00-ENDERECO-FIS THRU 90000-99-SAIDA */

            M_90000_00_ENDERECO_FIS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/


            /*" -163- PERFORM B0000-00-ENDERECO-JUR THRU B0000-99-SAIDA */

            B0000_00_ENDERECO_JUR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/


            /*" -165- DISPLAY '0000-00-BI0005S-FIM    ' */
            _.Display($"0000-00-BI0005S-FIM    ");

            /*" -167- GOBACK */

            throw new GoBack();

            /*" -167- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SAIDA*/

        [StopWatch]
        /*" M-10000-00-INICIAL-SECTION */
        private void M_10000_00_INICIAL_SECTION()
        {
            /*" -178- DISPLAY '10000-00-INICIAL       ' */
            _.Display($"10000-00-INICIAL       ");

            /*" -179- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -180- DISPLAY ' BI0005S - MANUTENCAO BASES PESSOAS - V.00       ' */
            _.Display($" BI0005S - MANUTENCAO BASES PESSOAS - V.00       ");

            /*" -181- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -187- DISPLAY ' VERSAO DE : ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $" VERSAO DE : FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -188- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -197- DISPLAY ' DATA DE PROCESSAMENTO: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $" DATA DE PROCESSAMENTO: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -198- INITIALIZE BI0005L-SAIDA */
            _.Initialize(
                BI0005L_LINKAGE.BI0005L_SAIDA
            );

            /*" -200- MOVE 'PROCESSAMENTO NORMAL' TO BI0005L-S-LIT-ERR */
            _.Move("PROCESSAMENTO NORMAL", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

            /*" -202- IF (BI0005L-E-COD-PESSOA NOT NUMERIC) OR (BI0005L-E-COD-PESSOA EQUAL ZEROS) */

            if ((!BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.IsNumeric()) || (BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA == 00))
            {

                /*" -203- MOVE 001 TO BI0005L-S-COD-ERR */
                _.Move(001, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR);

                /*" -204- MOVE 'COD DE PESSOA INVALIDO' TO BI0005L-S-LIT-ERR */
                _.Move("COD DE PESSOA INVALIDO", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -205- GOBACK */

                throw new GoBack();

                /*" -207- END-IF */
            }


            /*" -207- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-SECTION */
        private void M_30000_00_TRATA_PESSOA_SECTION()
        {
            /*" -219- DISPLAY '30000-00-TRATA-PESSOA   ' */
            _.Display($"30000-00-TRATA-PESSOA   ");

            /*" -229- PERFORM M_30000_00_TRATA_PESSOA_DB_SELECT_1 */

            M_30000_00_TRATA_PESSOA_DB_SELECT_1();

            /*" -233- DISPLAY 'SEL PESSOA: ' BI0005L-E-COD-PESSOA ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -234- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -237- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -238- MOVE 'ERRO SEL PESSOA' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL PESSOA", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -239- DISPLAY '***' */
                _.Display($"***");

                /*" -240- DISPLAY ' BI0005S - 30000-00-TRATA-PESSOA     ' */
                _.Display($" BI0005S - 30000-00-TRATA-PESSOA     ");

                /*" -241- DISPLAY ' ERRO SEL PESSOA (' WS-SQLCODE ')' */

                $" ERRO SEL PESSOA ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -242- DISPLAY '***' */
                _.Display($"***");

                /*" -243- GOBACK */

                throw new GoBack();

                /*" -246- END-IF */
            }


            /*" -247- IF BI0005L-S-TIPO-PESSOA EQUAL 'F' */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA == "F")
            {

                /*" -271- PERFORM M_30000_00_TRATA_PESSOA_DB_SELECT_2 */

                M_30000_00_TRATA_PESSOA_DB_SELECT_2();

                /*" -273- ELSE */
            }
            else
            {


                /*" -281- PERFORM M_30000_00_TRATA_PESSOA_DB_SELECT_3 */

                M_30000_00_TRATA_PESSOA_DB_SELECT_3();

                /*" -284- END-IF */
            }


            /*" -287- DISPLAY 'SEL PESSOA_FIS/JUR: ' BI0005L-E-COD-PESSOA '/TIPO PESSOA: ' BI0005L-S-TIPO-PESSOA ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_FIS/JUR: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/TIPO PESSOA: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -291- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -292- DISPLAY 'BI0005L-S-TIPO-PESSOA: ' BI0005L-S-TIPO-PESSOA */
                _.Display($"BI0005L-S-TIPO-PESSOA: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA}");

                /*" -293- IF BI0005L-S-TIPO-PESSOA EQUAL 'F' */

                if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA == "F")
                {

                    /*" -294- MOVE 'ERRO SEL PESSOA_FISICA' TO BI0005L-S-LIT-ERR */
                    _.Move("ERRO SEL PESSOA_FISICA", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                    /*" -295- ELSE */
                }
                else
                {


                    /*" -296- MOVE 'ERRO SEL PESSOA_JURIDICA' TO BI0005L-S-LIT-ERR */
                    _.Move("ERRO SEL PESSOA_JURIDICA", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                    /*" -297- END-IF */
                }


                /*" -298- DISPLAY '***' */
                _.Display($"***");

                /*" -299- DISPLAY ' BI0005S - 30000-00-TRATA-PESSOA     ' */
                _.Display($" BI0005S - 30000-00-TRATA-PESSOA     ");

                /*" -300- IF BI0005L-S-TIPO-PESSOA EQUAL 'F' */

                if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA == "F")
                {

                    /*" -301- DISPLAY 'ERRO SEL PESSOA_FISICA (' WS-SQLCODE ')' */

                    $"ERRO SEL PESSOA_FISICA ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -302- ELSE */
                }
                else
                {


                    /*" -303- DISPLAY 'ERRO SEL PESSOA_JURIDI (' WS-SQLCODE ')' */

                    $"ERRO SEL PESSOA_JURIDI ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -304- END-IF */
                }


                /*" -305- DISPLAY '***' */
                _.Display($"***");

                /*" -306- GOBACK */

                throw new GoBack();

                /*" -308- END-IF */
            }


            /*" -308- . */

        }

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-DB-SELECT-1 */
        public void M_30000_00_TRATA_PESSOA_DB_SELECT_1()
        {
            /*" -229- EXEC SQL SELECT NOME_PESSOA , TIPO_PESSOA , SIGLA_PESSOA INTO :BI0005L-S-NOME-PESSOA , :BI0005L-S-TIPO-PESSOA , :BI0005L-S-SIGLA-PESSOA :VIND-FILLER FROM SEGUROS.PESSOA WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA WITH UR END-EXEC */

            var m_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1 = new M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
            };

            var executed_1 = M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1.Execute(m_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI0005L_S_NOME_PESSOA, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA);
                _.Move(executed_1.BI0005L_S_TIPO_PESSOA, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA);
                _.Move(executed_1.BI0005L_S_SIGLA_PESSOA, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_PESSOA);
                _.Move(executed_1.VIND_FILLER, WS_WORKING.WS_AUXILIARES.VIND_FILLER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_30000_99_SAIDA*/

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-DB-SELECT-2 */
        public void M_30000_00_TRATA_PESSOA_DB_SELECT_2()
        {
            /*" -271- EXEC SQL SELECT CPF , DATA_NASCIMENTO , SEXO , ESTADO_CIVIL , NUM_IDENTIDADE , ORGAO_EXPEDIDOR , UF_EXPEDIDORA , DATA_EXPEDICAO , COD_CBO , TIPO_IDENT_SIVPF INTO :BI0005L-S-CPF , :BI0005L-S-DATA-NASC , :BI0005L-S-SEXO , :BI0005L-S-ESTADO-CIVIL , :BI0005L-S-NUM-IDENT , :BI0005L-S-ORGAO-EXPED , :BI0005L-S-UF-EXPEDIDORA , :BI0005L-S-DATA-EXPED :VIND-FILLER , :BI0005L-S-COD-CBO , :BI0005L-S-TIP-IDE-SIVPF FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA WITH UR END-EXEC */

            var m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 = new M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
            };

            var executed_1 = M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1.Execute(m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI0005L_S_CPF, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF);
                _.Move(executed_1.BI0005L_S_DATA_NASC, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC);
                _.Move(executed_1.BI0005L_S_SEXO, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO);
                _.Move(executed_1.BI0005L_S_ESTADO_CIVIL, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL);
                _.Move(executed_1.BI0005L_S_NUM_IDENT, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NUM_IDENT);
                _.Move(executed_1.BI0005L_S_ORGAO_EXPED, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ORGAO_EXPED);
                _.Move(executed_1.BI0005L_S_UF_EXPEDIDORA, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_UF_EXPEDIDORA);
                _.Move(executed_1.BI0005L_S_DATA_EXPED, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_EXPED);
                _.Move(executed_1.VIND_FILLER, WS_WORKING.WS_AUXILIARES.VIND_FILLER);
                _.Move(executed_1.BI0005L_S_COD_CBO, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO);
                _.Move(executed_1.BI0005L_S_TIP_IDE_SIVPF, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIP_IDE_SIVPF);
            }


        }

        [StopWatch]
        /*" M-50000-00-TRATA-TELEFONE-SECTION */
        private void M_50000_00_TRATA_TELEFONE_SECTION()
        {
            /*" -319- DISPLAY '50000-00-TRATA-TELEFONE' */
            _.Display($"50000-00-TRATA-TELEFONE");

            /*" -326- PERFORM M_50000_00_TRATA_TELEFONE_DB_SELECT_1 */

            M_50000_00_TRATA_TELEFONE_DB_SELECT_1();

            /*" -332- DISPLAY 'MAX PESSOA_TELEFONE: ' BI0005L-E-COD-PESSOA '/' IND-TEL '/' WS-MAX-SEQ-TEL ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_TELEFONE: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/{WS_WORKING.WS_AUXILIARES.IND_TEL}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -336- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -337- MOVE 'ERRO MAX TELEFONE' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO MAX TELEFONE", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -338- DISPLAY '***' */
                _.Display($"***");

                /*" -339- DISPLAY ' BI0005S - 50000-00-TRATA-TELEFONE   ' */
                _.Display($" BI0005S - 50000-00-TRATA-TELEFONE   ");

                /*" -340- DISPLAY ' ERRO MAX TELEFONE (' WS-SQLCODE ')' */

                $" ERRO MAX TELEFONE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -341- DISPLAY '***' */
                _.Display($"***");

                /*" -342- MOVE 'ERRO MAX TELEFONE' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO MAX TELEFONE", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -343- GOBACK */

                throw new GoBack();

                /*" -346- END-IF */
            }


            /*" -347- IF WS-MAX-SEQ-TEL EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL == 00)
            {

                /*" -348- GO TO 50000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/ //GOTO
                return;

                /*" -351- END-IF */
            }


            /*" -367- PERFORM M_50000_00_TRATA_TELEFONE_DB_SELECT_2 */

            M_50000_00_TRATA_TELEFONE_DB_SELECT_2();

            /*" -372- DISPLAY 'SEL PESSOA_TELEFONE: ' BI0005L-E-COD-PESSOA '/' WS-MAX-SEQ-TEL ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_TELEFONE: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -373- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -375- MOVE TIPO-FONE OF DCLPESSOA-TELEFONE TO BI0005L-S-TIPO-FONE(IND-TEL) */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0005L_S_TIPO_FONE);

                /*" -377- MOVE DDI OF DCLPESSOA-TELEFONE TO BI0005L-S-DDI(IND-TEL) */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDI, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0005L_S_DDI);

                /*" -379- MOVE DDD OF DCLPESSOA-TELEFONE TO BI0005L-S-DDD(IND-TEL) */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0005L_S_DDD);

                /*" -381- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO BI0005L-S-NUM-FONE(IND-TEL) */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0005L_S_NUM_FONE);

                /*" -383- MOVE SITUACAO-FONE OF DCLPESSOA-TELEFONE TO BI0005L-S-SIT-FONE(IND-TEL) */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0005L_S_SIT_FONE);

                /*" -384- ELSE */
            }
            else
            {


                /*" -387- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -388- MOVE 'ERRO SEL TELEFONE' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL TELEFONE", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -389- DISPLAY '***' */
                _.Display($"***");

                /*" -390- DISPLAY ' BI0005S - 50000-00-TRATA-TELEFONE   ' */
                _.Display($" BI0005S - 50000-00-TRATA-TELEFONE   ");

                /*" -391- DISPLAY ' ERRO SEL TELEFONE (' WS-SQLCODE ')' */

                $" ERRO SEL TELEFONE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -392- DISPLAY ' CODIGO PESSOA: ' BI0005L-E-COD-PESSOA */
                _.Display($" CODIGO PESSOA: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}");

                /*" -393- DISPLAY ' TIPO FONE ' IND-TEL */
                _.Display($" TIPO FONE {WS_WORKING.WS_AUXILIARES.IND_TEL}");

                /*" -394- DISPLAY ' SEQ FONE: ' WS-MAX-SEQ-TEL */
                _.Display($" SEQ FONE: {WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL}");

                /*" -395- DISPLAY '***' */
                _.Display($"***");

                /*" -396- GOBACK */

                throw new GoBack();

                /*" -398- END-IF */
            }


            /*" -398- . */

        }

        [StopWatch]
        /*" M-50000-00-TRATA-TELEFONE-DB-SELECT-1 */
        public void M_50000_00_TRATA_TELEFONE_DB_SELECT_1()
        {
            /*" -326- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :WS-MAX-SEQ-TEL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND TIPO_FONE = :IND-TEL WITH UR END-EXEC */

            var m_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1 = new M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
                IND_TEL = WS_WORKING.WS_AUXILIARES.IND_TEL.ToString(),
            };

            var executed_1 = M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1.Execute(m_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_SEQ_TEL, WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL);
            }


        }

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-DB-SELECT-3 */
        public void M_30000_00_TRATA_PESSOA_DB_SELECT_3()
        {
            /*" -281- EXEC SQL SELECT CGC , NOME_FANTASIA INTO :BI0005L-S-CGC , :BI0005L-S-NOME-FANTASIA FROM SEGUROS.PESSOA_JURIDICA WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA WITH UR END-EXEC */

            var m_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1 = new M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
            };

            var executed_1 = M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1.Execute(m_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI0005L_S_CGC, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CGC);
                _.Move(executed_1.BI0005L_S_NOME_FANTASIA, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_FANTASIA);
            }


        }

        [StopWatch]
        /*" M-50000-00-TRATA-TELEFONE-DB-SELECT-2 */
        public void M_50000_00_TRATA_TELEFONE_DB_SELECT_2()
        {
            /*" -367- EXEC SQL SELECT TIPO_FONE , DDI , DDD , NUM_FONE , SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.TIPO-FONE , :DCLPESSOA-TELEFONE.DDI , :DCLPESSOA-TELEFONE.DDD , :DCLPESSOA-TELEFONE.NUM-FONE , :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND TIPO_FONE = :IND-TEL AND SEQ_FONE = :WS-MAX-SEQ-TEL WITH UR END-EXEC */

            var m_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 = new M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
                WS_MAX_SEQ_TEL = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL.ToString(),
                IND_TEL = WS_WORKING.WS_AUXILIARES.IND_TEL.ToString(),
            };

            var executed_1 = M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1.Execute(m_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TIPO_FONE, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);
                _.Move(executed_1.DDI, PESFONE.DCLPESSOA_TELEFONE.DDI);
                _.Move(executed_1.DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(executed_1.NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-TRATA-EMAIL-SECTION */
        private void M_70000_00_TRATA_EMAIL_SECTION()
        {
            /*" -410- DISPLAY '70000-00-TRATA-EMAIL    ' */
            _.Display($"70000-00-TRATA-EMAIL    ");

            /*" -416- PERFORM M_70000_00_TRATA_EMAIL_DB_SELECT_1 */

            M_70000_00_TRATA_EMAIL_DB_SELECT_1();

            /*" -421- DISPLAY 'MAX PESSOA_EMAIL: ' BI0005L-E-COD-PESSOA '/' WS-MAX-SEQ-EMA ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_EMAIL: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -422- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -425- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -426- MOVE 'ERRO MAX EMAIL' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO MAX EMAIL", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -427- DISPLAY '***' */
                _.Display($"***");

                /*" -428- DISPLAY ' BI0005S - 70000-00-TRATA-EMAIL    ' */
                _.Display($" BI0005S - 70000-00-TRATA-EMAIL    ");

                /*" -429- DISPLAY ' ERRO MAX PESSOA_EMAIL (' WS-SQLCODE ')' */

                $" ERRO MAX PESSOA_EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -430- DISPLAY '***' */
                _.Display($"***");

                /*" -431- GOBACK */

                throw new GoBack();

                /*" -434- END-IF */
            }


            /*" -435- IF WS-MAX-SEQ-EMA EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA == 00)
            {

                /*" -436- GO TO 70000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/ //GOTO
                return;

                /*" -439- END-IF */
            }


            /*" -448- PERFORM M_70000_00_TRATA_EMAIL_DB_SELECT_2 */

            M_70000_00_TRATA_EMAIL_DB_SELECT_2();

            /*" -453- DISPLAY 'SEL PESSOA_EMAIL: ' BI0005L-E-COD-PESSOA '/' WS-MAX-SEQ-EMA ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_EMAIL: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -454- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -457- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -458- MOVE 'ERRO SEL EMAIL' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL EMAIL", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -459- DISPLAY '***' */
                _.Display($"***");

                /*" -460- DISPLAY ' 70000-00-TRATA-EMAIL      ' */
                _.Display($" 70000-00-TRATA-EMAIL      ");

                /*" -461- DISPLAY ' ERRO SEL EMAIL (' WS-SQLCODE ')' */

                $" ERRO SEL EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -462- DISPLAY ' CODIGO PESSOA: ' BI0005L-E-COD-PESSOA */
                _.Display($" CODIGO PESSOA: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}");

                /*" -463- DISPLAY ' SEQ EMAIL: ' WS-MAX-SEQ-EMA */
                _.Display($" SEQ EMAIL: {WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA}");

                /*" -464- DISPLAY '***' */
                _.Display($"***");

                /*" -465- MOVE 'ERRO SEL PESSOA_EMAIL' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL PESSOA_EMAIL", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -466- GOBACK */

                throw new GoBack();

                /*" -468- END-IF */
            }


            /*" -468- . */

        }

        [StopWatch]
        /*" M-70000-00-TRATA-EMAIL-DB-SELECT-1 */
        public void M_70000_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -416- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :WS-MAX-SEQ-EMA FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA WITH UR END-EXEC */

            var m_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
            };

            var executed_1 = M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(m_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_SEQ_EMA, WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-TRATA-EMAIL-DB-SELECT-2 */
        public void M_70000_00_TRATA_EMAIL_DB_SELECT_2()
        {
            /*" -448- EXEC SQL SELECT EMAIL , SITUACAO_EMAIL INTO :BI0005L-S-EMAIL , :BI0005L-S-SIT-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND SEQ_EMAIL = :WS-MAX-SEQ-EMA WITH UR END-EXEC */

            var m_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1 = new M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
                WS_MAX_SEQ_EMA = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA.ToString(),
            };

            var executed_1 = M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1.Execute(m_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI0005L_S_EMAIL, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL);
                _.Move(executed_1.BI0005L_S_SIT_EMAIL, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIT_EMAIL);
            }


        }

        [StopWatch]
        /*" M-90000-00-ENDERECO-FIS-SECTION */
        private void M_90000_00_ENDERECO_FIS_SECTION()
        {
            /*" -480- DISPLAY '90000-00-ENDERECO-FIS      ' */
            _.Display($"90000-00-ENDERECO-FIS      ");

            /*" -487- PERFORM M_90000_00_ENDERECO_FIS_DB_SELECT_1 */

            M_90000_00_ENDERECO_FIS_DB_SELECT_1();

            /*" -493- DISPLAY 'MAX PESSOA_END: ' BI0005L-E-COD-PESSOA '/' 001 '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_END: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/001/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -494- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -497- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -498- MOVE 'ERRO MAX ENDERECO' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -499- DISPLAY '***' */
                _.Display($"***");

                /*" -500- DISPLAY ' BI0005S - 90000-00-ENDERECO-FIS         ' */
                _.Display($" BI0005S - 90000-00-ENDERECO-FIS         ");

                /*" -501- DISPLAY ' ERRO MAX ENDERECO (' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -502- DISPLAY '***' */
                _.Display($"***");

                /*" -503- GOBACK */

                throw new GoBack();

                /*" -505- END-IF */
            }


            /*" -506- IF WS-MAX-OCO-END EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END == 00)
            {

                /*" -507- GO TO 90000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/ //GOTO
                return;

                /*" -510- END-IF */
            }


            /*" -534- PERFORM M_90000_00_ENDERECO_FIS_DB_SELECT_2 */

            M_90000_00_ENDERECO_FIS_DB_SELECT_2();

            /*" -540- DISPLAY 'SEL PESSOA_END R: ' BI0005L-E-COD-PESSOA '/' BI0005L-S-CEP-R '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_END R: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -544- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -545- MOVE 'ERRO SEL ENDERECO' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -546- DISPLAY '***' */
                _.Display($"***");

                /*" -547- DISPLAY ' BI0005S - 90000-00-ENDERECO-FIS          ' */
                _.Display($" BI0005S - 90000-00-ENDERECO-FIS          ");

                /*" -548- DISPLAY ' ERRO SEL ENDERECO (' WS-SQLCODE ')' */

                $" ERRO SEL ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -549- DISPLAY ' CODIGO PESSOA: ' WS-MAX-OCO-END */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -550- DISPLAY ' OCORRENCIA: ' WS-MAX-OCO-END */
                _.Display($" OCORRENCIA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -551- DISPLAY '***' */
                _.Display($"***");

                /*" -552- MOVE 'ERRO SEL ENDERECO' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -553- GOBACK */

                throw new GoBack();

                /*" -555- END-IF */
            }


            /*" -555- . */

        }

        [StopWatch]
        /*" M-90000-00-ENDERECO-FIS-DB-SELECT-1 */
        public void M_90000_00_ENDERECO_FIS_DB_SELECT_1()
        {
            /*" -487- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :WS-MAX-OCO-END FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND TIPO_ENDER = 001 WITH UR END-EXEC */

            var m_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1 = new M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
            };

            var executed_1 = M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1.Execute(m_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCO_END, WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/

        [StopWatch]
        /*" M-90000-00-ENDERECO-FIS-DB-SELECT-2 */
        public void M_90000_00_ENDERECO_FIS_DB_SELECT_2()
        {
            /*" -534- EXEC SQL SELECT ENDERECO , OCORR_ENDERECO , TIPO_ENDER , COMPL_ENDER , BAIRRO , CEP , CIDADE , SIGLA_UF , SITUACAO_ENDERECO INTO :BI0005L-S-ENDERECO-R , :BI0005L-S-OCC-END-R , :BI0005L-S-TIPO-ENDER-R , :BI0005L-S-COMPL-ENDER-R :VIND-FILLER , :BI0005L-S-BAIRRO-R , :BI0005L-S-CEP-R , :BI0005L-S-CIDADE-R , :BI0005L-S-SIGLA-UF-R , :BI0005L-S-SIT-ENDER-R FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND TIPO_ENDER = 001 AND OCORR_ENDERECO = :WS-MAX-OCO-END WITH UR END-EXEC */

            var m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 = new M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
                WS_MAX_OCO_END = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.ToString(),
            };

            var executed_1 = M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1.Execute(m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI0005L_S_ENDERECO_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R);
                _.Move(executed_1.BI0005L_S_OCC_END_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_OCC_END_R);
                _.Move(executed_1.BI0005L_S_TIPO_ENDER_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_ENDER_R);
                _.Move(executed_1.BI0005L_S_COMPL_ENDER_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COMPL_ENDER_R);
                _.Move(executed_1.VIND_FILLER, WS_WORKING.WS_AUXILIARES.VIND_FILLER);
                _.Move(executed_1.BI0005L_S_BAIRRO_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R);
                _.Move(executed_1.BI0005L_S_CEP_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R);
                _.Move(executed_1.BI0005L_S_CIDADE_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R);
                _.Move(executed_1.BI0005L_S_SIGLA_UF_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R);
                _.Move(executed_1.BI0005L_S_SIT_ENDER_R, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIT_ENDER_R);
            }


        }

        [StopWatch]
        /*" B0000-00-ENDERECO-JUR-SECTION */
        private void B0000_00_ENDERECO_JUR_SECTION()
        {
            /*" -567- DISPLAY 'B0000-00-ENDERECO-JUR       ' */
            _.Display($"B0000-00-ENDERECO-JUR       ");

            /*" -574- PERFORM B0000_00_ENDERECO_JUR_DB_SELECT_1 */

            B0000_00_ENDERECO_JUR_DB_SELECT_1();

            /*" -580- DISPLAY 'MAX PESSOA_END: ' BI0005L-E-COD-PESSOA '/' 002 '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_END: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/002/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -581- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -584- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -585- MOVE 'ERRO MAX ENDERECO' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -586- DISPLAY '***' */
                _.Display($"***");

                /*" -587- DISPLAY ' BI0005S - B0000-00-ENDERECO-JUR     ' */
                _.Display($" BI0005S - B0000-00-ENDERECO-JUR     ");

                /*" -588- DISPLAY ' ERRO MAX ENDERECO (' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -589- DISPLAY '***' */
                _.Display($"***");

                /*" -590- GOBACK */

                throw new GoBack();

                /*" -592- END-IF */
            }


            /*" -593- IF WS-MAX-OCO-END EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END == 00)
            {

                /*" -594- GO TO B0000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/ //GOTO
                return;

                /*" -597- END-IF */
            }


            /*" -621- PERFORM B0000_00_ENDERECO_JUR_DB_SELECT_2 */

            B0000_00_ENDERECO_JUR_DB_SELECT_2();

            /*" -626- DISPLAY 'SEL PESSOA_END C: ' BI0005L-E-COD-PESSOA '/' BI0005L-S-CEP-C ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_END C: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_C} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -627- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -630- MOVE SQLCODE TO WS-SQLCODE BI0005L-S-COD-ERR BI0005L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL);

                /*" -631- MOVE 'ERRO SEL ENDERECO COM' TO BI0005L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO COM", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR);

                /*" -632- DISPLAY '***' */
                _.Display($"***");

                /*" -633- DISPLAY ' BI0005S - B0000-00-ENDERECO-JUR          ' */
                _.Display($" BI0005S - B0000-00-ENDERECO-JUR          ");

                /*" -634- DISPLAY ' ERRO SEL ENDERECO (' WS-SQLCODE ')' */

                $" ERRO SEL ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -635- DISPLAY ' CODIGO PESSOA: ' BI0005L-E-COD-PESSOA */
                _.Display($" CODIGO PESSOA: {BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA}");

                /*" -636- DISPLAY ' OCORRENCIA: ' WS-MAX-OCO-END */
                _.Display($" OCORRENCIA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -637- DISPLAY '***' */
                _.Display($"***");

                /*" -638- GOBACK */

                throw new GoBack();

                /*" -640- END-IF */
            }


            /*" -640- . */

        }

        [StopWatch]
        /*" B0000-00-ENDERECO-JUR-DB-SELECT-1 */
        public void B0000_00_ENDERECO_JUR_DB_SELECT_1()
        {
            /*" -574- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :WS-MAX-OCO-END FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND TIPO_ENDER = 002 WITH UR END-EXEC */

            var b0000_00_ENDERECO_JUR_DB_SELECT_1_Query1 = new B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
            };

            var executed_1 = B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1.Execute(b0000_00_ENDERECO_JUR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCO_END, WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/

        [StopWatch]
        /*" B0000-00-ENDERECO-JUR-DB-SELECT-2 */
        public void B0000_00_ENDERECO_JUR_DB_SELECT_2()
        {
            /*" -621- EXEC SQL SELECT ENDERECO , OCORR_ENDERECO , TIPO_ENDER , COMPL_ENDER , BAIRRO , CEP , CIDADE , SIGLA_UF , SITUACAO_ENDERECO INTO :BI0005L-S-ENDERECO-C , :BI0005L-S-OCC-END-C , :BI0005L-S-TIPO-ENDER-C , :BI0005L-S-COMPL-ENDER-C :VIND-FILLER , :BI0005L-S-BAIRRO-C , :BI0005L-S-CEP-C , :BI0005L-S-CIDADE-C , :BI0005L-S-SIGLA-UF-C , :BI0005L-S-SIT-ENDER-C FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA AND TIPO_ENDER = 002 AND OCORR_ENDERECO = :WS-MAX-OCO-END WITH UR END-EXEC */

            var b0000_00_ENDERECO_JUR_DB_SELECT_2_Query1 = new B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1()
            {
                BI0005L_E_COD_PESSOA = BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA.ToString(),
                WS_MAX_OCO_END = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.ToString(),
            };

            var executed_1 = B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1.Execute(b0000_00_ENDERECO_JUR_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BI0005L_S_ENDERECO_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_C);
                _.Move(executed_1.BI0005L_S_OCC_END_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_OCC_END_C);
                _.Move(executed_1.BI0005L_S_TIPO_ENDER_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_ENDER_C);
                _.Move(executed_1.BI0005L_S_COMPL_ENDER_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COMPL_ENDER_C);
                _.Move(executed_1.VIND_FILLER, WS_WORKING.WS_AUXILIARES.VIND_FILLER);
                _.Move(executed_1.BI0005L_S_BAIRRO_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_C);
                _.Move(executed_1.BI0005L_S_CEP_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_C);
                _.Move(executed_1.BI0005L_S_CIDADE_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_C);
                _.Move(executed_1.BI0005L_S_SIGLA_UF_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_C);
                _.Move(executed_1.BI0005L_S_SIT_ENDER_C, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIT_ENDER_C);
            }


        }
    }
}