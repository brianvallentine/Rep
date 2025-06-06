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
using Sias.Outros.DB2.CT0006S;

namespace Code
{
    public class CT0006S
    {
        public bool IsCall { get; set; }

        public CT0006S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ...............  SUBROTINAS                          *      */
        /*"      *   PROGRAMA ..............  CT0006S                             *      */
        /*"      *   ANALISTA ..............  FAST COMPUTER                       *      */
        /*"      *   PROGRAMADOR ...........  FAST COMPUTER                       *      */
        /*"      *   DATA CODIFICACAO ......  AGOSTO / 2006                       *      */
        /*"      *   FUNCAO ................  CONSISTIR CEP                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                           BOOK                 ACESSO   *      */
        /*"      * ----------------------------------------------------- -------- *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.01 - INCLUI RETORNO: DO TIPO LOGRADOURO, NOME DO LOGRADOURO, *      */
        /*"      *        NOME DO BAIRRO, NOME DA LOCALIDADE(CIDADE),NOME UNIDADE *      */
        /*"      *        OPERACIONAL, NOME DO CENTRALIZADOR.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01           AREA-DE-WORK.*/
        public CT0006S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CT0006S_AREA_DE_WORK();
        public class CT0006S_AREA_DE_WORK : VarBasis
        {
            /*"    05         WRETORNO            PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05         WS-SQLCODE          PIC  S9(004)   COMP.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         WCEP-DESTINO        PIC  9(008)    VALUE  ZEROS.*/
            public IntBasis WCEP_DESTINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05         FILLER              REDEFINES      WCEP-DESTINO.*/
            private _REDEF_CT0006S_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CT0006S_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CT0006S_FILLER_0(); _.Move(WCEP_DESTINO, _filler_0); VarBasis.RedefinePassValue(WCEP_DESTINO, _filler_0, WCEP_DESTINO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WCEP_DESTINO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WCEP_DESTINO); }
            }  //Redefines
            public class _REDEF_CT0006S_FILLER_0 : VarBasis
            {
                /*"       10       WCEP-DEST-NUMR      PIC  9(005).*/
                public IntBasis WCEP_DEST_NUMR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10       WCEP-DEST-COMP      PIC  9(003).*/
                public IntBasis WCEP_DEST_COMP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"01           AREA-DE-WORK.*/

                public _REDEF_CT0006S_FILLER_0()
                {
                    WCEP_DEST_NUMR.ValueChanged += OnValueChanged;
                    WCEP_DEST_COMP.ValueChanged += OnValueChanged;
                }

            }
        }
        public CT0006S_AREA_DE_WORK_0 AREA_DE_WORK_0 { get; set; } = new CT0006S_AREA_DE_WORK_0();
        public class CT0006S_AREA_DE_WORK_0 : VarBasis
        {
            /*"  05         WLINK-LINKAGE.*/
            public CT0006S_WLINK_LINKAGE WLINK_LINKAGE { get; set; } = new CT0006S_WLINK_LINKAGE();
            public class CT0006S_WLINK_LINKAGE : VarBasis
            {
                /*"    10       WLINK-INPUT.*/
                public CT0006S_WLINK_INPUT WLINK_INPUT { get; set; } = new CT0006S_WLINK_INPUT();
                public class CT0006S_WLINK_INPUT : VarBasis
                {
                    /*"      15     WLINK-CEP-DESTINO   PIC  9(008)    VALUE  ZEROS.*/
                    public IntBasis WLINK_CEP_DESTINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      15     WLINK-SIGLA-UF      PIC  X(002)    VALUE  SPACES.*/
                    public StringBasis WLINK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"    10       WLINK-SQLCODE       PIC  S9(004)   COMP.*/
                }
                public IntBasis WLINK_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       WLINK-MENSAGEM      PIC  X(070)    VALUE  SPACES.*/
                public StringBasis WLINK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10       WLINK-TP-LOGRAD     PIC  X(036)    VALUE  SPACES.*/
                public StringBasis WLINK_TP_LOGRAD { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10       WLINK-NOM-LOGRAD    PIC  X(100)    VALUE  SPACES.*/
                public StringBasis WLINK_NOM_LOGRAD { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"    10       WLINK-BAIRRO        PIC  X(072)    VALUE  SPACES.*/
                public StringBasis WLINK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"    10       WLINK-CIDADE        PIC  X(072)    VALUE  SPACES.*/
                public StringBasis WLINK_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"    10       WLINK-UNIDADE-OPER  PIC  X(072)    VALUE  SPACES.*/
                public StringBasis WLINK_UNIDADE_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"    10       WLINK-CENTRALIZ     PIC  X(072)    VALUE  SPACES.*/
                public StringBasis WLINK_CENTRALIZ { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"  05        WABEND.*/
            }
            public CT0006S_WABEND WABEND { get; set; } = new CT0006S_WABEND();
            public class CT0006S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC X(010) VALUE           ' CT0006S '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CT0006S ");
                /*"    10      FILLER              PIC X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01           CT0006S-LINKAGE.*/
            }
        }
        public CT0006S_CT0006S_LINKAGE CT0006S_LINKAGE { get; set; } = new CT0006S_CT0006S_LINKAGE();
        public class CT0006S_CT0006S_LINKAGE : VarBasis
        {
            /*"  05         CT0006S-CEP-DESTINO    PIC  9(008).*/
            public IntBasis CT0006S_CEP_DESTINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         CT0006S-SIGLA-UF       PIC  X(002).*/
            public StringBasis CT0006S_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05         CT0006S-SQLCODE        PIC S9(004) COMP.*/
            public IntBasis CT0006S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         CT0006S-MENSAGEM       PIC  X(070).*/
            public StringBasis CT0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         CT0006S-TP-LOGRAD      PIC  X(036).*/
            public StringBasis CT0006S_TP_LOGRAD { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"  05         CT0006S-NOM-LOGRAD     PIC  X(100).*/
            public StringBasis CT0006S_NOM_LOGRAD { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05         CT0006S-BAIRRO         PIC  X(072).*/
            public StringBasis CT0006S_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CIDADE         PIC  X(072).*/
            public StringBasis CT0006S_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-UNIDADE-OPER   PIC  X(072).*/
            public StringBasis CT0006S_UNIDADE_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CENTRALIZ      PIC  X(072).*/
            public StringBasis CT0006S_CENTRALIZ { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        }


        public Dclgens.GE318 GE318 { get; set; } = new Dclgens.GE318();
        public Dclgens.GE321 GE321 { get; set; } = new Dclgens.GE321();
        public Dclgens.GE322 GE322 { get; set; } = new Dclgens.GE322();
        public Dclgens.GE324 GE324 { get; set; } = new Dclgens.GE324();
        public Dclgens.GE329 GE329 { get; set; } = new Dclgens.GE329();
        public Dclgens.GE326 GE326 { get; set; } = new Dclgens.GE326();
        public Dclgens.GE332 GE332 { get; set; } = new Dclgens.GE332();
        public Dclgens.GE353 GE353 { get; set; } = new Dclgens.GE353();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(CT0006S_CT0006S_LINKAGE CT0006S_CT0006S_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*CT0006S_LINKAGE*/
        {
            try
            {
                this.CT0006S_LINKAGE = CT0006S_CT0006S_LINKAGE_P;

                /*" -125- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -126- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -127- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -138- INITIALIZE CT0006S-SQLCODE CT0006S-MENSAGEM CT0006S-TP-LOGRAD CT0006S-NOM-LOGRAD CT0006S-BAIRRO CT0006S-CIDADE CT0006S-UNIDADE-OPER CT0006S-CENTRALIZ. */
                _.Initialize(
                    CT0006S_LINKAGE.CT0006S_SQLCODE
                    , CT0006S_LINKAGE.CT0006S_MENSAGEM
                    , CT0006S_LINKAGE.CT0006S_TP_LOGRAD
                    , CT0006S_LINKAGE.CT0006S_NOM_LOGRAD
                    , CT0006S_LINKAGE.CT0006S_BAIRRO
                    , CT0006S_LINKAGE.CT0006S_CIDADE
                    , CT0006S_LINKAGE.CT0006S_UNIDADE_OPER
                    , CT0006S_LINKAGE.CT0006S_CENTRALIZ
                );

                /*" -141- MOVE SPACES TO WRETORNO */
                _.Move("", AREA_DE_WORK.WRETORNO);

                /*" -142- PERFORM R0500-00-CONSISTE-PARAMETRO */

                R0500_00_CONSISTE_PARAMETRO_SECTION();

                /*" -143- IF WRETORNO EQUAL SPACES */

                if (AREA_DE_WORK.WRETORNO.IsEmpty())
                {

                    /*" -145- PERFORM R1000-00-PROCESSA-CODIGO. */

                    R1000_00_PROCESSA_CODIGO_SECTION();
                }


                /*" -147- MOVE WLINK-SQLCODE TO CT0006S-SQLCODE */
                _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE, CT0006S_LINKAGE.CT0006S_SQLCODE);

                /*" -150- STRING CT0006S-MENSAGEM SQLERRMC DELIMITED BY ' ' INTO WLINK-MENSAGEM */
                #region STRING
                var spl1 = CT0006S_LINKAGE.CT0006S_MENSAGEM.GetMoveValues().Split(" ").FirstOrDefault();
                var spl2 = DB.SQLERRMC.GetMoveValues().Split(" ").FirstOrDefault();
                var results3 = spl1 + spl2;
                _.Move(results3, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);
                #endregion

                /*" -151- MOVE WLINK-MENSAGEM TO CT0006S-MENSAGEM */
                _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM, CT0006S_LINKAGE.CT0006S_MENSAGEM);

                /*" -152- MOVE WLINK-TP-LOGRAD TO CT0006S-TP-LOGRAD */
                _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD, CT0006S_LINKAGE.CT0006S_TP_LOGRAD);

                /*" -153- MOVE WLINK-NOM-LOGRAD TO CT0006S-NOM-LOGRAD */
                _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD, CT0006S_LINKAGE.CT0006S_NOM_LOGRAD);

                /*" -154- MOVE WLINK-BAIRRO TO CT0006S-BAIRRO */
                _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO, CT0006S_LINKAGE.CT0006S_BAIRRO);

                /*" -156- MOVE WLINK-CIDADE TO CT0006S-CIDADE */
                _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE, CT0006S_LINKAGE.CT0006S_CIDADE);

                /*" -156- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CT0006S_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" R0500-00-CONSISTE-PARAMETRO-SECTION */
        private void R0500_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -167- MOVE '0500' TO WNR-EXEC-SQL */
            _.Move("0500", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

            /*" -169- MOVE CT0006S-LINKAGE TO WLINK-LINKAGE */
            _.Move(CT0006S_LINKAGE, AREA_DE_WORK_0.WLINK_LINKAGE);

            /*" -170- IF WLINK-CEP-DESTINO NOT NUMERIC */

            if (!AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_INPUT.WLINK_CEP_DESTINO.IsNumeric())
            {

                /*" -171- MOVE '*' TO WRETORNO */
                _.Move("*", AREA_DE_WORK.WRETORNO);

                /*" -173- MOVE 'CEP DO DESTINATARIO NAO INFORMADO' TO WLINK-MENSAGEM */
                _.Move("CEP DO DESTINATARIO NAO INFORMADO", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                /*" -174- GO TO R0500-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;

                /*" -175- ELSE */
            }
            else
            {


                /*" -176- IF WLINK-CEP-DESTINO EQUAL ZEROS */

                if (AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_INPUT.WLINK_CEP_DESTINO == 00)
                {

                    /*" -177- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -179- MOVE 'CEP DO DESTINATARIO NAO INFORMADO' TO WLINK-MENSAGEM */
                    _.Move("CEP DO DESTINATARIO NAO INFORMADO", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -179- GO TO R0500-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CODIGO-SECTION */
        private void R1000_00_PROCESSA_CODIGO_SECTION()
        {
            /*" -193- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

            /*" -194- PERFORM R1100-00-VERIFICA-FAIXA */

            R1100_00_VERIFICA_FAIXA_SECTION();

            /*" -195- IF WRETORNO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WRETORNO.IsEmpty())
            {

                /*" -197- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -200- MOVE '1001' TO WNR-EXEC-SQL */
            _.Move("1001", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

            /*" -201- PERFORM R1200-00-VERIFICA-CEP */

            R1200_00_VERIFICA_CEP_SECTION();

            /*" -202- IF WRETORNO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WRETORNO.IsEmpty())
            {

                /*" -204- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -204- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-VERIFICA-FAIXA-SECTION */
        private void R1100_00_VERIFICA_FAIXA_SECTION()
        {
            /*" -221- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

            /*" -223- MOVE SPACES TO WRETORNO */
            _.Move("", AREA_DE_WORK.WRETORNO);

            /*" -225- MOVE WLINK-CEP-DESTINO TO GE332-COD-INI-CEP. */
            _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_INPUT.WLINK_CEP_DESTINO, GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_INI_CEP);

            /*" -240- PERFORM R1100_00_VERIFICA_FAIXA_DB_SELECT_1 */

            R1100_00_VERIFICA_FAIXA_DB_SELECT_1();

            /*" -243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -244- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -245- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -246- MOVE 'CEP FORA DA FAIXA' TO WLINK-MENSAGEM */
                    _.Move("CEP FORA DA FAIXA", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -247- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -248- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -249- ELSE */
                }
                else
                {


                    /*" -251- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -252- ELSE */
                    }
                    else
                    {


                        /*" -253- MOVE SQLCODE TO WLINK-SQLCODE */
                        _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                        /*" -255- MOVE 'PROBLEMA NO ACESSO A TRIAGEM CEP' TO WLINK-MENSAGEM */
                        _.Move("PROBLEMA NO ACESSO A TRIAGEM CEP", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                        /*" -256- MOVE '*' TO WRETORNO */
                        _.Move("*", AREA_DE_WORK.WRETORNO);

                        /*" -257- GO TO R1100-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                        return;

                        /*" -258- END-IF */
                    }


                    /*" -259- END-IF */
                }


                /*" -261- END-IF. */
            }


            /*" -264- MOVE '1101' TO WNR-EXEC-SQL */
            _.Move("1101", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

            /*" -265- MOVE GE353-NOM-UNIDADE-OPER TO WLINK-UNIDADE-OPER. */
            _.Move(GE353.DCLGE_DNE_TRIAGEM.GE353_NOM_UNIDADE_OPER, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_UNIDADE_OPER);

            /*" -269- MOVE GE353-NOM-CENTRALIZADOR TO WLINK-CENTRALIZ. */
            _.Move(GE353.DCLGE_DNE_TRIAGEM.GE353_NOM_CENTRALIZADOR, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CENTRALIZ);

            /*" -271- MOVE WLINK-SIGLA-UF TO GE332-COD-UF */
            _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_INPUT.WLINK_SIGLA_UF, GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_UF);

            /*" -280- PERFORM R1100_00_VERIFICA_FAIXA_DB_SELECT_2 */

            R1100_00_VERIFICA_FAIXA_DB_SELECT_2();

            /*" -283- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -284- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -285- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -287- MOVE 'CEP FORA DA FAIXA RESERVADA PARA A UF' TO WLINK-MENSAGEM */
                    _.Move("CEP FORA DA FAIXA RESERVADA PARA A UF", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -288- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -289- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -290- ELSE */
                }
                else
                {


                    /*" -291- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -293- MOVE 'PROBLEMA NO ACESSO A FAIXA CEP          ' TO WLINK-MENSAGEM */
                    _.Move("PROBLEMA NO ACESSO A FAIXA CEP          ", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -294- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -295- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -296- END-IF */
                }


                /*" -298- END-IF. */
            }


            /*" -298- MOVE '1102' TO WNR-EXEC-SQL. */
            _.Move("1102", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" R1100-00-VERIFICA-FAIXA-DB-SELECT-1 */
        public void R1100_00_VERIFICA_FAIXA_DB_SELECT_1()
        {
            /*" -240- EXEC SQL SELECT COD_INI_FAIXA_CEP, COD_FIM_FAIXA_CEP, NOM_UNIDADE_OPER , NOM_CENTRALIZADOR INTO :GE353-COD-INI-FAIXA-CEP, :GE353-COD-FIM-FAIXA-CEP, :GE353-NOM-UNIDADE-OPER , :GE353-NOM-CENTRALIZADOR FROM SEGUROS.GE_DNE_TRIAGEM WHERE COD_INI_FAIXA_CEP <= :GE332-COD-INI-CEP AND COD_FIM_FAIXA_CEP >= :GE332-COD-INI-CEP END-EXEC. */

            var r1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1 = new R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1()
            {
                GE332_COD_INI_CEP = GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_INI_CEP.ToString(),
            };

            var executed_1 = R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1.Execute(r1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE353_COD_INI_FAIXA_CEP, GE353.DCLGE_DNE_TRIAGEM.GE353_COD_INI_FAIXA_CEP);
                _.Move(executed_1.GE353_COD_FIM_FAIXA_CEP, GE353.DCLGE_DNE_TRIAGEM.GE353_COD_FIM_FAIXA_CEP);
                _.Move(executed_1.GE353_NOM_UNIDADE_OPER, GE353.DCLGE_DNE_TRIAGEM.GE353_NOM_UNIDADE_OPER);
                _.Move(executed_1.GE353_NOM_CENTRALIZADOR, GE353.DCLGE_DNE_TRIAGEM.GE353_NOM_CENTRALIZADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-VERIFICA-FAIXA-DB-SELECT-2 */
        public void R1100_00_VERIFICA_FAIXA_DB_SELECT_2()
        {
            /*" -280- EXEC SQL SELECT COD_INI_CEP, COD_FIM_CEP INTO :GE332-COD-INI-CEP, :GE332-COD-FIM-CEP FROM SEGUROS.GE_DNE_FAIXA_UF WHERE COD_UF = :GE332-COD-UF AND COD_INI_CEP <= :GE332-COD-INI-CEP AND COD_FIM_CEP >= :GE332-COD-INI-CEP END-EXEC. */

            var r1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1 = new R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1()
            {
                GE332_COD_INI_CEP = GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_INI_CEP.ToString(),
                GE332_COD_UF = GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_UF.ToString(),
            };

            var executed_1 = R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1.Execute(r1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE332_COD_INI_CEP, GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_INI_CEP);
                _.Move(executed_1.GE332_COD_FIM_CEP, GE332.DCLGE_DNE_FAIXA_UF.GE332_COD_FIM_CEP);
            }


        }

        [StopWatch]
        /*" R1200-00-VERIFICA-CEP-SECTION */
        private void R1200_00_VERIFICA_CEP_SECTION()
        {
            /*" -313- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

            /*" -314- MOVE WLINK-CEP-DESTINO TO WCEP-DESTINO. */
            _.Move(AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_INPUT.WLINK_CEP_DESTINO, AREA_DE_WORK.WCEP_DESTINO);

            /*" -316- MOVE SPACES TO GE324-COD-UF. */
            _.Move("", GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

            /*" -318- IF WCEP-DEST-COMP NOT LESS 000 AND WCEP-DEST-COMP NOT GREATER 899 */

            if (AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP >= 000 && AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP <= 899)
            {

                /*" -319- MOVE WCEP-DESTINO TO GE318-COD-CEP */
                _.Move(AREA_DE_WORK.WCEP_DESTINO, GE318.DCLGE_DNE_LOG_UF.GE318_COD_CEP);

                /*" -323- MOVE '1201' TO WNR-EXEC-SQL */
                _.Move("1201", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

                /*" -325- PERFORM R1110-10-SELECT-GE318. */

                R1110_10_SELECT_GE318_SECTION();
            }


            /*" -327- IF WCEP-DEST-COMP NOT LESS 900 AND WCEP-DEST-COMP NOT GREATER 959 */

            if (AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP >= 900 && AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP <= 959)
            {

                /*" -328- MOVE WCEP-DESTINO TO GE321-COD-CEP */
                _.Move(AREA_DE_WORK.WCEP_DESTINO, GE321.DCLGE_DNE_GRD_USUARIO.GE321_COD_CEP);

                /*" -332- MOVE '1202' TO WNR-EXEC-SQL */
                _.Move("1202", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

                /*" -334- PERFORM R1110-20-SELECT-GE321. */

                R1110_20_SELECT_GE321_SECTION();
            }


            /*" -337- IF ((WCEP-DEST-COMP NOT LESS 970 AND WCEP-DEST-COMP NOT GREATER 989) OR WCEP-DEST-COMP EQUAL 999) */

            if (((AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP >= 970 && AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP <= 989) || AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP == 999))
            {

                /*" -338- MOVE WCEP-DESTINO TO GE322-COD-CEP */
                _.Move(AREA_DE_WORK.WCEP_DESTINO, GE322.DCLGE_DNE_UNID_OPER.GE322_COD_CEP);

                /*" -342- MOVE '1203' TO WNR-EXEC-SQL */
                _.Move("1203", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

                /*" -344- PERFORM R1110-30-SELECT-GE322. */

                R1110_30_SELECT_GE322_SECTION();
            }


            /*" -346- IF WCEP-DEST-COMP NOT LESS 990 AND WCEP-DEST-COMP NOT GREATER 998 */

            if (AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP >= 990 && AREA_DE_WORK.FILLER_0.WCEP_DEST_COMP <= 998)
            {

                /*" -347- MOVE WCEP-DESTINO TO GE326-COD-CEP */
                _.Move(AREA_DE_WORK.WCEP_DESTINO, GE326.DCLGE_DNE_CXPST_COM.GE326_COD_CEP);

                /*" -351- MOVE '1204' TO WNR-EXEC-SQL */
                _.Move("1204", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

                /*" -353- PERFORM R1110-40-SELECT-GE326. */

                R1110_40_SELECT_GE326_SECTION();
            }


            /*" -354- IF GE324-COD-UF EQUAL SPACES */

            if (GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF.IsEmpty())
            {

                /*" -355- MOVE WCEP-DESTINO TO GE324-COD-CEP */
                _.Move(AREA_DE_WORK.WCEP_DESTINO, GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_CEP);

                /*" -359- MOVE '1205' TO WNR-EXEC-SQL */
                _.Move("1205", AREA_DE_WORK_0.WABEND.WNR_EXEC_SQL);

                /*" -361- PERFORM R1110-50-SELECT-GE324 */

                R1110_50_SELECT_GE324_SECTION();

                /*" -362- IF GE324-COD-UF EQUAL SPACES */

                if (GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF.IsEmpty())
                {

                    /*" -363- MOVE 999 TO WLINK-SQLCODE */
                    _.Move(999, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -365- MOVE 'CEP NAO CADASTRADO' TO WLINK-MENSAGEM */
                    _.Move("CEP NAO CADASTRADO", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -366- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -366- GO TO R1200-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1110-10-SELECT-GE318-SECTION */
        private void R1110_10_SELECT_GE318_SECTION()
        {
            /*" -382- PERFORM R1110_10_SELECT_GE318_DB_SELECT_1 */

            R1110_10_SELECT_GE318_DB_SELECT_1();

            /*" -385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -386- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -387- MOVE SPACES TO GE324-COD-UF */
                    _.Move("", GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

                    /*" -388- GO TO R1110-10-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_10_SAIDA*/ //GOTO
                    return;

                    /*" -389- ELSE */
                }
                else
                {


                    /*" -390- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -391- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -393- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_DNE_LOG_UF' TO WLINK-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE_DNE_LOG_UF", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -394- GO TO R1110-10-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_10_SAIDA*/ //GOTO
                    return;

                    /*" -396- END-IF. */
                }

            }


            /*" -398- MOVE GE318-COD-UF TO GE324-COD-UF. */
            _.Move(GE318.DCLGE_DNE_LOG_UF.GE318_COD_UF, GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

            /*" -416- PERFORM R1110_10_SELECT_GE318_DB_SELECT_2 */

            R1110_10_SELECT_GE318_DB_SELECT_2();

            /*" -419- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -420- MOVE GE318-IND-TP-LOGRADOURO TO WLINK-TP-LOGRAD */
                _.Move(GE318.DCLGE_DNE_LOG_UF.GE318_IND_TP_LOGRADOURO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD);

                /*" -421- MOVE GE318-NOM-LOGRADOURO TO WLINK-NOM-LOGRAD */
                _.Move(GE318.DCLGE_DNE_LOG_UF.GE318_NOM_LOGRADOURO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD);

                /*" -422- MOVE GE329-NOM-BAIRRO TO WLINK-BAIRRO */
                _.Move(GE329.DCLGE_DNE_BAIRRO.GE329_NOM_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO);

                /*" -423- MOVE GE324-NOM-LOCALIDADE TO WLINK-CIDADE */
                _.Move(GE324.DCLGE_DNE_LOCALIDADE.GE324_NOM_LOCALIDADE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

                /*" -424- ELSE */
            }
            else
            {


                /*" -426- MOVE SPACES TO WLINK-TP-LOGRAD WLINK-NOM-LOGRAD WLINK-BAIRRO WLINK-CIDADE */
                _.Move("", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

                /*" -426- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-10-SELECT-GE318-DB-SELECT-1 */
        public void R1110_10_SELECT_GE318_DB_SELECT_1()
        {
            /*" -382- EXEC SQL SELECT COD_UF INTO :GE318-COD-UF FROM SEGUROS.GE_DNE_LOG_UF WHERE COD_CEP = :GE318-COD-CEP END-EXEC. */

            var r1110_10_SELECT_GE318_DB_SELECT_1_Query1 = new R1110_10_SELECT_GE318_DB_SELECT_1_Query1()
            {
                GE318_COD_CEP = GE318.DCLGE_DNE_LOG_UF.GE318_COD_CEP.ToString(),
            };

            var executed_1 = R1110_10_SELECT_GE318_DB_SELECT_1_Query1.Execute(r1110_10_SELECT_GE318_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE318_COD_UF, GE318.DCLGE_DNE_LOG_UF.GE318_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_10_SAIDA*/

        [StopWatch]
        /*" R1110-10-SELECT-GE318-DB-SELECT-2 */
        public void R1110_10_SELECT_GE318_DB_SELECT_2()
        {
            /*" -416- EXEC SQL SELECT A.IND_TP_LOGRADOURO, A.NOM_LOGRADOURO , C.NOM_BAIRRO , B.NOM_LOCALIDADE INTO :GE318-IND-TP-LOGRADOURO , :GE318-NOM-LOGRADOURO , :GE329-NOM-BAIRRO , :GE324-NOM-LOCALIDADE FROM SEGUROS.GE_DNE_LOG_UF A, SEGUROS.GE_DNE_LOCALIDADE B, SEGUROS.GE_DNE_BAIRRO C WHERE A.COD_CEP = :GE318-COD-CEP AND A.NUM_LOCALIDADE = B.NUM_LOCALIDADE AND B.NUM_LOCALIDADE = C.NUM_LOCALIDADE AND A.NUM_INI_BAIRRO = C.NUM_BAIRRO END-EXEC */

            var r1110_10_SELECT_GE318_DB_SELECT_2_Query1 = new R1110_10_SELECT_GE318_DB_SELECT_2_Query1()
            {
                GE318_COD_CEP = GE318.DCLGE_DNE_LOG_UF.GE318_COD_CEP.ToString(),
            };

            var executed_1 = R1110_10_SELECT_GE318_DB_SELECT_2_Query1.Execute(r1110_10_SELECT_GE318_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE318_IND_TP_LOGRADOURO, GE318.DCLGE_DNE_LOG_UF.GE318_IND_TP_LOGRADOURO);
                _.Move(executed_1.GE318_NOM_LOGRADOURO, GE318.DCLGE_DNE_LOG_UF.GE318_NOM_LOGRADOURO);
                _.Move(executed_1.GE329_NOM_BAIRRO, GE329.DCLGE_DNE_BAIRRO.GE329_NOM_BAIRRO);
                _.Move(executed_1.GE324_NOM_LOCALIDADE, GE324.DCLGE_DNE_LOCALIDADE.GE324_NOM_LOCALIDADE);
            }


        }

        [StopWatch]
        /*" R1110-20-SELECT-GE321-SECTION */
        private void R1110_20_SELECT_GE321_SECTION()
        {
            /*" -442- PERFORM R1110_20_SELECT_GE321_DB_SELECT_1 */

            R1110_20_SELECT_GE321_DB_SELECT_1();

            /*" -445- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -446- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -447- MOVE SPACES TO GE324-COD-UF */
                    _.Move("", GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

                    /*" -448- GO TO R1110-20-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_20_SAIDA*/ //GOTO
                    return;

                    /*" -449- ELSE */
                }
                else
                {


                    /*" -450- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -451- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -453- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_DNE_GRD_USUARIO' TO WLINK-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE_DNE_GRD_USUARIO", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -454- GO TO R1110-20-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_20_SAIDA*/ //GOTO
                    return;

                    /*" -455- END-IF */
                }


                /*" -456- ELSE */
            }
            else
            {


                /*" -458- MOVE GE321-COD-UF TO GE324-COD-UF. */
                _.Move(GE321.DCLGE_DNE_GRD_USUARIO.GE321_COD_UF, GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);
            }


            /*" -475- PERFORM R1110_20_SELECT_GE321_DB_SELECT_2 */

            R1110_20_SELECT_GE321_DB_SELECT_2();

            /*" -478- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -479- MOVE GE321-NOM-TP-LOGRADOURO TO WLINK-TP-LOGRAD */
                _.Move(GE321.DCLGE_DNE_GRD_USUARIO.GE321_NOM_TP_LOGRADOURO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD);

                /*" -480- MOVE GE321-NOM-LOGRADOURO TO WLINK-NOM-LOGRAD */
                _.Move(GE321.DCLGE_DNE_GRD_USUARIO.GE321_NOM_LOGRADOURO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD);

                /*" -481- MOVE GE329-NOM-BAIRRO TO WLINK-BAIRRO */
                _.Move(GE329.DCLGE_DNE_BAIRRO.GE329_NOM_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO);

                /*" -482- MOVE GE324-NOM-LOCALIDADE TO WLINK-CIDADE */
                _.Move(GE324.DCLGE_DNE_LOCALIDADE.GE324_NOM_LOCALIDADE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

                /*" -483- ELSE */
            }
            else
            {


                /*" -485- MOVE SPACES TO WLINK-TP-LOGRAD WLINK-NOM-LOGRAD WLINK-BAIRRO WLINK-CIDADE */
                _.Move("", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

                /*" -485- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-20-SELECT-GE321-DB-SELECT-1 */
        public void R1110_20_SELECT_GE321_DB_SELECT_1()
        {
            /*" -442- EXEC SQL SELECT COD_UF INTO :GE321-COD-UF FROM SEGUROS.GE_DNE_GRD_USUARIO WHERE COD_CEP = :GE321-COD-CEP END-EXEC. */

            var r1110_20_SELECT_GE321_DB_SELECT_1_Query1 = new R1110_20_SELECT_GE321_DB_SELECT_1_Query1()
            {
                GE321_COD_CEP = GE321.DCLGE_DNE_GRD_USUARIO.GE321_COD_CEP.ToString(),
            };

            var executed_1 = R1110_20_SELECT_GE321_DB_SELECT_1_Query1.Execute(r1110_20_SELECT_GE321_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE321_COD_UF, GE321.DCLGE_DNE_GRD_USUARIO.GE321_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_20_SAIDA*/

        [StopWatch]
        /*" R1110-20-SELECT-GE321-DB-SELECT-2 */
        public void R1110_20_SELECT_GE321_DB_SELECT_2()
        {
            /*" -475- EXEC SQL SELECT A.NOM_TP_LOGRADOURO , A.NOM_LOGRADOURO , C.NOM_BAIRRO , B.NOM_LOCALIDADE INTO :GE321-NOM-TP-LOGRADOURO , :GE321-NOM-LOGRADOURO , :GE329-NOM-BAIRRO , :GE324-NOM-LOCALIDADE FROM SEGUROS.GE_DNE_GRD_USUARIO A, SEGUROS.GE_DNE_LOCALIDADE B, SEGUROS.GE_DNE_BAIRRO C WHERE A.COD_CEP = :GE321-COD-CEP AND A.NUM_LOCALIDADE = B.NUM_LOCALIDADE AND B.NUM_LOCALIDADE = C.NUM_LOCALIDADE AND A.NUM_BAIRRO = C.NUM_BAIRRO END-EXEC. */

            var r1110_20_SELECT_GE321_DB_SELECT_2_Query1 = new R1110_20_SELECT_GE321_DB_SELECT_2_Query1()
            {
                GE321_COD_CEP = GE321.DCLGE_DNE_GRD_USUARIO.GE321_COD_CEP.ToString(),
            };

            var executed_1 = R1110_20_SELECT_GE321_DB_SELECT_2_Query1.Execute(r1110_20_SELECT_GE321_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE321_NOM_TP_LOGRADOURO, GE321.DCLGE_DNE_GRD_USUARIO.GE321_NOM_TP_LOGRADOURO);
                _.Move(executed_1.GE321_NOM_LOGRADOURO, GE321.DCLGE_DNE_GRD_USUARIO.GE321_NOM_LOGRADOURO);
                _.Move(executed_1.GE329_NOM_BAIRRO, GE329.DCLGE_DNE_BAIRRO.GE329_NOM_BAIRRO);
                _.Move(executed_1.GE324_NOM_LOCALIDADE, GE324.DCLGE_DNE_LOCALIDADE.GE324_NOM_LOCALIDADE);
            }


        }

        [StopWatch]
        /*" R1110-30-SELECT-GE322-SECTION */
        private void R1110_30_SELECT_GE322_SECTION()
        {
            /*" -501- PERFORM R1110_30_SELECT_GE322_DB_SELECT_1 */

            R1110_30_SELECT_GE322_DB_SELECT_1();

            /*" -504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -505- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -506- MOVE SPACES TO GE324-COD-UF */
                    _.Move("", GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

                    /*" -507- GO TO R1110-30-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_30_SAIDA*/ //GOTO
                    return;

                    /*" -508- ELSE */
                }
                else
                {


                    /*" -509- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -510- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -511- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -513- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_DNE_UNID_OPER' TO WLINK-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE_DNE_UNID_OPER", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -514- GO TO R1110-30-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_30_SAIDA*/ //GOTO
                    return;

                    /*" -515- END-IF */
                }


                /*" -516- ELSE */
            }
            else
            {


                /*" -518- MOVE GE322-COD-UF TO GE324-COD-UF. */
                _.Move(GE322.DCLGE_DNE_UNID_OPER.GE322_COD_UF, GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);
            }


            /*" -535- PERFORM R1110_30_SELECT_GE322_DB_SELECT_2 */

            R1110_30_SELECT_GE322_DB_SELECT_2();

            /*" -538- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -539- MOVE GE322-NOM-TP-LOGRADOURO TO WLINK-TP-LOGRAD */
                _.Move(GE322.DCLGE_DNE_UNID_OPER.GE322_NOM_TP_LOGRADOURO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD);

                /*" -540- MOVE GE322-NOM-LOGRADOURO TO WLINK-NOM-LOGRAD */
                _.Move(GE322.DCLGE_DNE_UNID_OPER.GE322_NOM_LOGRADOURO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD);

                /*" -541- MOVE GE329-NOM-BAIRRO TO WLINK-BAIRRO */
                _.Move(GE329.DCLGE_DNE_BAIRRO.GE329_NOM_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO);

                /*" -542- MOVE GE324-NOM-LOCALIDADE TO WLINK-CIDADE */
                _.Move(GE324.DCLGE_DNE_LOCALIDADE.GE324_NOM_LOCALIDADE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

                /*" -543- ELSE */
            }
            else
            {


                /*" -545- MOVE SPACES TO WLINK-TP-LOGRAD WLINK-NOM-LOGRAD WLINK-BAIRRO WLINK-CIDADE */
                _.Move("", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

                /*" -545- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-30-SELECT-GE322-DB-SELECT-1 */
        public void R1110_30_SELECT_GE322_DB_SELECT_1()
        {
            /*" -501- EXEC SQL SELECT COD_UF INTO :GE322-COD-UF FROM SEGUROS.GE_DNE_UNID_OPER WHERE COD_CEP = :GE322-COD-CEP END-EXEC. */

            var r1110_30_SELECT_GE322_DB_SELECT_1_Query1 = new R1110_30_SELECT_GE322_DB_SELECT_1_Query1()
            {
                GE322_COD_CEP = GE322.DCLGE_DNE_UNID_OPER.GE322_COD_CEP.ToString(),
            };

            var executed_1 = R1110_30_SELECT_GE322_DB_SELECT_1_Query1.Execute(r1110_30_SELECT_GE322_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE322_COD_UF, GE322.DCLGE_DNE_UNID_OPER.GE322_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_30_SAIDA*/

        [StopWatch]
        /*" R1110-30-SELECT-GE322-DB-SELECT-2 */
        public void R1110_30_SELECT_GE322_DB_SELECT_2()
        {
            /*" -535- EXEC SQL SELECT A.NOM_TP_LOGRADOURO, A.NOM_LOGRADOURO, C.NOM_BAIRRO, B.NOM_LOCALIDADE INTO :GE322-NOM-TP-LOGRADOURO , :GE322-NOM-LOGRADOURO , :GE329-NOM-BAIRRO , :GE324-NOM-LOCALIDADE FROM SEGUROS.GE_DNE_UNID_OPER A, SEGUROS.GE_DNE_LOCALIDADE B, SEGUROS.GE_DNE_BAIRRO C WHERE A.COD_CEP = :GE322-COD-CEP AND A.NUM_LOCALIDADE = B.NUM_LOCALIDADE AND B.NUM_LOCALIDADE = C.NUM_LOCALIDADE AND A.NUM_BAIRRO = C.NUM_BAIRRO END-EXEC. */

            var r1110_30_SELECT_GE322_DB_SELECT_2_Query1 = new R1110_30_SELECT_GE322_DB_SELECT_2_Query1()
            {
                GE322_COD_CEP = GE322.DCLGE_DNE_UNID_OPER.GE322_COD_CEP.ToString(),
            };

            var executed_1 = R1110_30_SELECT_GE322_DB_SELECT_2_Query1.Execute(r1110_30_SELECT_GE322_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE322_NOM_TP_LOGRADOURO, GE322.DCLGE_DNE_UNID_OPER.GE322_NOM_TP_LOGRADOURO);
                _.Move(executed_1.GE322_NOM_LOGRADOURO, GE322.DCLGE_DNE_UNID_OPER.GE322_NOM_LOGRADOURO);
                _.Move(executed_1.GE329_NOM_BAIRRO, GE329.DCLGE_DNE_BAIRRO.GE329_NOM_BAIRRO);
                _.Move(executed_1.GE324_NOM_LOCALIDADE, GE324.DCLGE_DNE_LOCALIDADE.GE324_NOM_LOCALIDADE);
            }


        }

        [StopWatch]
        /*" R1110-40-SELECT-GE326-SECTION */
        private void R1110_40_SELECT_GE326_SECTION()
        {
            /*" -561- PERFORM R1110_40_SELECT_GE326_DB_SELECT_1 */

            R1110_40_SELECT_GE326_DB_SELECT_1();

            /*" -564- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -565- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -566- MOVE SPACES TO GE324-COD-UF */
                    _.Move("", GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

                    /*" -567- ELSE */
                }
                else
                {


                    /*" -568- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -569- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -571- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_DNE_CXPST_COM' TO WLINK-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE_DNE_CXPST_COM", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -572- END-IF */
                }


                /*" -573- ELSE */
            }
            else
            {


                /*" -575- MOVE GE326-COD-UF TO GE324-COD-UF. */
                _.Move(GE326.DCLGE_DNE_CXPST_COM.GE326_COD_UF, GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);
            }


            /*" -576- MOVE SPACES TO WLINK-TP-LOGRAD WLINK-NOM-LOGRAD WLINK-BAIRRO WLINK-CIDADE. */
            _.Move("", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_TP_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_NOM_LOGRAD, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_BAIRRO, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_CIDADE);

        }

        [StopWatch]
        /*" R1110-40-SELECT-GE326-DB-SELECT-1 */
        public void R1110_40_SELECT_GE326_DB_SELECT_1()
        {
            /*" -561- EXEC SQL SELECT COD_UF INTO :GE326-COD-UF FROM SEGUROS.GE_DNE_CXPST_COM WHERE COD_CEP = :GE326-COD-CEP END-EXEC. */

            var r1110_40_SELECT_GE326_DB_SELECT_1_Query1 = new R1110_40_SELECT_GE326_DB_SELECT_1_Query1()
            {
                GE326_COD_CEP = GE326.DCLGE_DNE_CXPST_COM.GE326_COD_CEP.ToString(),
            };

            var executed_1 = R1110_40_SELECT_GE326_DB_SELECT_1_Query1.Execute(r1110_40_SELECT_GE326_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE326_COD_UF, GE326.DCLGE_DNE_CXPST_COM.GE326_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_40_SAIDA*/

        [StopWatch]
        /*" R1110-50-SELECT-GE324-SECTION */
        private void R1110_50_SELECT_GE324_SECTION()
        {
            /*" -592- PERFORM R1110_50_SELECT_GE324_DB_SELECT_1 */

            R1110_50_SELECT_GE324_DB_SELECT_1();

            /*" -595- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -596- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -597- MOVE SPACES TO GE324-COD-UF */
                    _.Move("", GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);

                    /*" -598- ELSE */
                }
                else
                {


                    /*" -599- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -600- MOVE '*' TO WRETORNO */
                    _.Move("*", AREA_DE_WORK.WRETORNO);

                    /*" -601- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_DNE_LOCALIDADE' TO WLINK-MENSAGEM. */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE_DNE_LOCALIDADE", AREA_DE_WORK_0.WLINK_LINKAGE.WLINK_MENSAGEM);
                }

            }


        }

        [StopWatch]
        /*" R1110-50-SELECT-GE324-DB-SELECT-1 */
        public void R1110_50_SELECT_GE324_DB_SELECT_1()
        {
            /*" -592- EXEC SQL SELECT COD_UF INTO :GE324-COD-UF FROM SEGUROS.GE_DNE_LOCALIDADE WHERE COD_CEP = :GE324-COD-CEP END-EXEC. */

            var r1110_50_SELECT_GE324_DB_SELECT_1_Query1 = new R1110_50_SELECT_GE324_DB_SELECT_1_Query1()
            {
                GE324_COD_CEP = GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_CEP.ToString(),
            };

            var executed_1 = R1110_50_SELECT_GE324_DB_SELECT_1_Query1.Execute(r1110_50_SELECT_GE324_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE324_COD_UF, GE324.DCLGE_DNE_LOCALIDADE.GE324_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_50_SAIDA*/
    }
}