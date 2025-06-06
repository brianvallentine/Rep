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
using Sias.VidaEmGrupo.DB2.VG0710S;

namespace Code
{
    public class VG0710S
    {
        public bool IsCall { get; set; }

        public VG0710S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DA SUBROTINA                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  CONVERSAO DE CAPITAIS PUROS PARA CAPITAIS COM COBERTURA       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO   |    DATA    |    AUTOR     |       HISTORICO       *      */
        /*"      *            |            |              |                       *      */
        /*"      *     01     |  30/09/91  |   PROCAS     |                       *      */
        /*"      *     02     |    /  /    |   PROCAS     |                       *      */
        /*"      *     03     |    /  /    |   PROCAS     |                       *      */
        /*"      *     04     |    /  /    |   PROCAS     |                       *      */
        /*"      *     05     |    /  /    |   PROCAS     |                       *      */
        /*"      *     06     |  14/07/06  |   MARCO      | LK-MENSAGEM-VISISTEMA *      */
        /*"      *            |            |              | PROCURAR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.              MARCEL   30/06/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01  SISTEMA-DTMOVABE             PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  NUM-APOLICE                  PIC S9(013)          COMP-3.*/
        public IntBasis NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  COD-SUBGRUPO                 PIC S9(004)          COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  IDADE                        PIC S9(004)          COMP.*/
        public IntBasis IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RAMO                         PIC S9(004)          COMP.*/
        public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MODALIDA                     PIC S9(004)          COMP.*/
        public IntBasis MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SALARIO                      PIC S9(013)V99       COMP-3.*/
        public DoubleBasis SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  TAXA-VG                      PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  TAXA-AP-MORACID              PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  TAXA-AP-INVPERM              PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  TAXA-AP-AMDS                 PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  TAXA-AP-DH                   PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  TAXA-AP-DIT                  PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  GARAN-ADIC-IEA               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  GARAN-ADIC-IPA               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  GARAN-ADIC-IPD               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IPD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  GARAN-ADIC-HD                PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_HD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  FILLER.*/
        public VG0710S_FILLER_0 FILLER_0 { get; set; } = new VG0710S_FILLER_0();
        public class VG0710S_FILLER_0 : VarBasis
        {
            /*"    05 FLAG-CALCULA-PREMIO       PIC  X VALUE 'S'.*/

            public SelectorBasis FLAG_CALCULA_PREMIO { get; set; } = new SelectorBasis("X", "S")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CALCULA-PREMIOS        VALUE 'S'. */
							new SelectorItemBasis("CALCULA_PREMIOS", "S")
                }
            };

            /*"    05 DATA-SQL.*/
            public VG0710S_DATA_SQL DATA_SQL { get; set; } = new VG0710S_DATA_SQL();
            public class VG0710S_DATA_SQL : VarBasis
            {
                /*"       10 ANO                    PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                 PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10 MES                    PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                 PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10 DIA                    PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 DATA-SISTEMA.*/
            }
            public VG0710S_DATA_SISTEMA DATA_SISTEMA { get; set; } = new VG0710S_DATA_SISTEMA();
            public class VG0710S_DATA_SISTEMA : VarBasis
            {
                /*"       10 ANO                    PIC  9(004).*/
                public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 MES                    PIC  9(002).*/
                public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 DIA                    PIC  9(002).*/
                public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 DATA-NORMAL               PIC  9(008).*/
            }
            public IntBasis DATA_NORMAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-DDMMAA REDEFINES DATA-NORMAL.*/
            private _REDEF_VG0710S_DATA_DDMMAA _data_ddmmaa { get; set; }
            public _REDEF_VG0710S_DATA_DDMMAA DATA_DDMMAA
            {
                get { _data_ddmmaa = new _REDEF_VG0710S_DATA_DDMMAA(); _.Move(DATA_NORMAL, _data_ddmmaa); VarBasis.RedefinePassValue(DATA_NORMAL, _data_ddmmaa, DATA_NORMAL); _data_ddmmaa.ValueChanged += () => { _.Move(_data_ddmmaa, DATA_NORMAL); }; return _data_ddmmaa; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa, DATA_NORMAL); }
            }  //Redefines
            public class _REDEF_VG0710S_DATA_DDMMAA : VarBasis
            {
                /*"       10 DIA                    PIC  9(002).*/
                public IntBasis DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 MES                    PIC  9(002).*/
                public IntBasis MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 ANO                    PIC  9(004).*/
                public IntBasis ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 DATA-INVERTIDA            PIC  9(008).*/

                public _REDEF_VG0710S_DATA_DDMMAA()
                {
                    DIA_1.ValueChanged += OnValueChanged;
                    MES_1.ValueChanged += OnValueChanged;
                    ANO_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
            private _REDEF_VG0710S_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VG0710S_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VG0710S_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VG0710S_DATA_AAMMDD : VarBasis
            {
                /*"       10 ANO                    PIC  9(004).*/
                public IntBasis ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 MES                    PIC  9(002).*/
                public IntBasis MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 DIA                    PIC  9(002).*/
                public IntBasis DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 AUX-PREM-MORTE-ACIDENTAL   PIC S9(013)V99 COMP-3 VALUE 0.*/

                public _REDEF_VG0710S_DATA_AAMMDD()
                {
                    ANO_2.ValueChanged += OnValueChanged;
                    MES_2.ValueChanged += OnValueChanged;
                    DIA_2.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis AUX_PREM_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 AUX-PREM-INV-PERMANENTE    PIC S9(013)V99 COMP-3 VALUE 0.*/
            public DoubleBasis AUX_PREM_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 AUX-PREM-ASS-MEDICA        PIC S9(013)V99 COMP-3 VALUE 0.*/
            public DoubleBasis AUX_PREM_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 AUX-PREM-DIARIA-HOSPITALAR PIC S9(013)V99 COMP-3 VALUE 0.*/
            public DoubleBasis AUX_PREM_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 AUX-PREM-DIARIA-INTERNACAO PIC S9(013)V99 COMP-3 VALUE 0.*/
            public DoubleBasis AUX_PREM_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  PARAMETROS.*/
        }
        public VG0710S_PARAMETROS PARAMETROS { get; set; } = new VG0710S_PARAMETROS();
        public class VG0710S_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public VG0710S_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0710S_LK_NASCIMENTO();
            public class VG0710S_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                PIC S9(03) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VG0710S_PARAMETROS VG0710S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*PARAMETROS*/
        {
            try
            {
                this.PARAMETROS = VG0710S_PARAMETROS_P;

                /*" -147- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -151- MOVE 'S' TO FLAG-CALCULA-PREMIO. */
                _.Move("S", FILLER_0.FLAG_CALCULA_PREMIO);

                /*" -155- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -158- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -159- MOVE 'ERRO SELECT NA V1SISTEMA' TO LK-MENSAGEM */
                    _.Move("ERRO SELECT NA V1SISTEMA", PARAMETROS.LK_MENSAGEM);

                    /*" -161- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return Result;
                }


                /*" -169- IF (LK-APOLICE NOT NUMERIC) OR (LK-SALARIO NOT NUMERIC) OR (LK-PURO-MORTE-NATURAL NOT NUMERIC) OR (LK-PURO-MORTE-ACIDENTAL NOT NUMERIC) OR (LK-PURO-INV-PERMANENTE NOT NUMERIC) OR (LK-PURO-ASS-MEDICA NOT NUMERIC) OR (LK-PURO-DIARIA-HOSPITALAR NOT NUMERIC) OR (LK-PURO-DIARIA-INTERNACAO NOT NUMERIC) */

                if ((!PARAMETROS.LK_APOLICE.IsNumeric()) || (!PARAMETROS.LK_SALARIO.IsNumeric()) || (!PARAMETROS.LK_PURO_MORTE_NATURAL.IsNumeric()) || (!PARAMETROS.LK_PURO_MORTE_ACIDENTAL.IsNumeric()) || (!PARAMETROS.LK_PURO_INV_PERMANENTE.IsNumeric()) || (!PARAMETROS.LK_PURO_ASS_MEDICA.IsNumeric()) || (!PARAMETROS.LK_PURO_DIARIA_HOSPITALAR.IsNumeric()) || (!PARAMETROS.LK_PURO_DIARIA_INTERNACAO.IsNumeric()))
                {

                    /*" -170- MOVE 'DADOS NAO NUMERICOS' TO LK-MENSAGEM */
                    _.Move("DADOS NAO NUMERICOS", PARAMETROS.LK_MENSAGEM);

                    /*" -171- MOVE 10 TO LK-RETURN-CODE */
                    _.Move(10, PARAMETROS.LK_RETURN_CODE);

                    /*" -173- GO TO 9999-FIM. */

                    M_9999_FIM(); //GOTO
                    return Result;
                }


                /*" -174- IF LK-NASCIMENTO EQUAL SPACES */

                if (PARAMETROS.LK_NASCIMENTO.IsEmpty())
                {

                    /*" -175- MOVE ZEROS TO LK-DATA-NASCIMENTO */
                    _.Move(0, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO);

                    /*" -176- ELSE */
                }
                else
                {


                    /*" -177- IF LK-DATA-NASCIMENTO NOT NUMERIC */

                    if (!PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO.IsNumeric())
                    {

                        /*" -178- MOVE 'DATA DE NASCIMENTO INVALIDA' TO LK-MENSAGEM */
                        _.Move("DATA DE NASCIMENTO INVALIDA", PARAMETROS.LK_MENSAGEM);

                        /*" -179- MOVE 10 TO LK-RETURN-CODE */
                        _.Move(10, PARAMETROS.LK_RETURN_CODE);

                        /*" -181- GO TO 9999-FIM. */

                        M_9999_FIM(); //GOTO
                        return Result;
                    }

                }


                /*" -183- IF ZEROS EQUAL LK-APOLICE OR LK-SUBGRUPO */

                if (PARAMETROS.LK_APOLICE.IsEmpty() || PARAMETROS.LK_SUBGRUPO.IsEmpty())
                {

                    /*" -184- MOVE 'APOLICE/SUBGRUPO ZERADOS' TO LK-MENSAGEM */
                    _.Move("APOLICE/SUBGRUPO ZERADOS", PARAMETROS.LK_MENSAGEM);

                    /*" -185- MOVE 20 TO LK-RETURN-CODE */
                    _.Move(20, PARAMETROS.LK_RETURN_CODE);

                    /*" -187- GO TO 9999-FIM. */

                    M_9999_FIM(); //GOTO
                    return Result;
                }


                /*" -190- IF ZEROS EQUAL LK-IDADE AND LK-DATA-NASCIMENTO AND LK-SALARIO */

                if (PARAMETROS.LK_IDADE.IsEmpty() && PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO.IsEmpty() && PARAMETROS.LK_SALARIO.IsEmpty())
                {

                    /*" -192- MOVE 'N' TO FLAG-CALCULA-PREMIO. */
                    _.Move("N", FILLER_0.FLAG_CALCULA_PREMIO);
                }


                /*" -194- MOVE LK-APOLICE TO NUM-APOLICE. */
                _.Move(PARAMETROS.LK_APOLICE, NUM_APOLICE);

                /*" -196- PERFORM 0070-ACESSA-APOLICE. */

                M_0070_ACESSA_APOLICE(true);

                /*" -198- IF RAMO EQUAL 93 AND MODALIDA EQUAL 2 */

                if (RAMO == 93 && MODALIDA == 2)
                {

                    /*" -200- MOVE LK-PURO-MORTE-NATURAL TO LK-COBT-MORTE-NATURAL */
                    _.Move(PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_NATURAL);

                    /*" -202- MOVE LK-PURO-MORTE-ACIDENTAL TO LK-COBT-MORTE-ACIDENTAL */
                    _.Move(PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL);

                    /*" -204- MOVE LK-PURO-INV-PERMANENTE TO LK-COBT-INV-PERMANENTE */
                    _.Move(PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_PERMANENTE);

                    /*" -206- MOVE LK-PURO-INV-PERMANENTE TO LK-COBT-INV-POR-ACIDENTE */
                    _.Move(PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE);

                    /*" -208- MOVE LK-PURO-ASS-MEDICA TO LK-COBT-ASS-MEDICA */
                    _.Move(PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_COBT_ASS_MEDICA);

                    /*" -210- MOVE LK-PURO-DIARIA-HOSPITALAR TO LK-COBT-DIARIA-HOSPITALAR */
                    _.Move(PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR);

                    /*" -212- MOVE LK-PURO-DIARIA-INTERNACAO TO LK-COBT-DIARIA-INTERNACAO */
                    _.Move(PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_DIARIA_INTERNACAO);

                    /*" -213- MOVE ZEROS TO LK-RETURN-CODE */
                    _.Move(0, PARAMETROS.LK_RETURN_CODE);

                    /*" -214- MOVE SPACES TO LK-MENSAGEM */
                    _.Move("", PARAMETROS.LK_MENSAGEM);

                    /*" -216- GOBACK. */

                    throw new GoBack();
                }


                /*" -218- IF ZEROS EQUAL LK-PURO-MORTE-NATURAL AND LK-PURO-MORTE-ACIDENTAL */

                if (PARAMETROS.LK_PURO_MORTE_NATURAL.IsEmpty() && PARAMETROS.LK_PURO_MORTE_ACIDENTAL.IsEmpty())
                {

                    /*" -219- MOVE 'CAPITAIS PUROS ZERADOS' TO LK-MENSAGEM */
                    _.Move("CAPITAIS PUROS ZERADOS", PARAMETROS.LK_MENSAGEM);

                    /*" -220- MOVE 20 TO LK-RETURN-CODE */
                    _.Move(20, PARAMETROS.LK_RETURN_CODE);

                    /*" -222- GO TO 9999-FIM. */

                    M_9999_FIM(); //GOTO
                    return Result;
                }


                /*" -223- MOVE SISTEMA-DTMOVABE TO DATA-SQL. */
                _.Move(SISTEMA_DTMOVABE, FILLER_0.DATA_SQL);

                /*" -225- MOVE CORR DATA-SQL TO DATA-SISTEMA. */
                _.MoveCorr(FILLER_0.DATA_SQL, FILLER_0.DATA_SISTEMA);

                /*" -226- MOVE LK-APOLICE TO NUM-APOLICE. */
                _.Move(PARAMETROS.LK_APOLICE, NUM_APOLICE);

                /*" -228- MOVE LK-SUBGRUPO TO COD-SUBGRUPO. */
                _.Move(PARAMETROS.LK_SUBGRUPO, COD_SUBGRUPO);

                /*" -229- IF LK-DATA-NASCIMENTO NOT EQUAL ZEROS */

                if (PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO != 00)
                {

                    /*" -231- PERFORM 0010-CALCULA-IDADE. */

                    M_0010_CALCULA_IDADE(true);
                }


                /*" -232- IF LK-IDADE NOT EQUAL ZEROS */

                if (PARAMETROS.LK_IDADE != 00)
                {

                    /*" -233- MOVE LK-IDADE TO IDADE */
                    _.Move(PARAMETROS.LK_IDADE, IDADE);

                    /*" -235- PERFORM 0020-ACESSA-FAIXA-ETARIA. */

                    M_0020_ACESSA_FAIXA_ETARIA(true);
                }


                /*" -236- IF LK-SALARIO NOT EQUAL ZEROS */

                if (PARAMETROS.LK_SALARIO != 00)
                {

                    /*" -237- MOVE LK-SALARIO TO SALARIO */
                    _.Move(PARAMETROS.LK_SALARIO, SALARIO);

                    /*" -239- PERFORM M-0030-ACESSA-FAIXA-SALARIAL. */

                    M_0030_ACESSA_FAIXA_SALARIAL(true);
                }


                /*" -241- PERFORM 0040-ACESSA-COND-TEC. */

                M_0040_ACESSA_COND_TEC(true);

                /*" -243- PERFORM 0050-CAPITAIS-COBERTURA. */

                M_0050_CAPITAIS_COBERTURA(true);

                /*" -244- IF CALCULA-PREMIOS */

                if (FILLER_0.FLAG_CALCULA_PREMIO["CALCULA_PREMIOS"])
                {

                    /*" -246- PERFORM 0060-PREMIOS-SEGURO. */

                    M_0060_PREMIOS_SEGURO(true);
                }


                /*" -247- MOVE ZEROS TO LK-RETURN-CODE. */
                _.Move(0, PARAMETROS.LK_RETURN_CODE);

                /*" -249- MOVE SPACES TO LK-MENSAGEM. */
                _.Move("", PARAMETROS.LK_MENSAGEM);

                /*" -249- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -155- EXEC SQL SELECT DTMOVABE INTO :SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0010-CALCULA-IDADE */
        private void M_0010_CALCULA_IDADE(bool isPerform = false)
        {
            /*" -255- MOVE LK-DATA-NASCIMENTO TO DATA-INVERTIDA. */
            _.Move(PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, FILLER_0.DATA_INVERTIDA);

            /*" -256- COMPUTE LK-IDADE = ANO OF DATA-SISTEMA - ANO OF DATA-AAMMDD. */
            PARAMETROS.LK_IDADE.Value = FILLER_0.DATA_SISTEMA.ANO_0 - FILLER_0.DATA_AAMMDD.ANO_2;

        }

        [StopWatch]
        /*" M-0020-ACESSA-FAIXA-ETARIA */
        private void M_0020_ACESSA_FAIXA_ETARIA(bool isPerform = false)
        {
            /*" -269- PERFORM M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1 */

            M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1();

            /*" -272- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -273- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -274- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_0.FLAG_CALCULA_PREMIO);

                    /*" -275- ELSE */
                }
                else
                {


                    /*" -276- MOVE 'ERRO NO ACESSO A FAIXA ETARIA' TO LK-MENSAGEM */
                    _.Move("ERRO NO ACESSO A FAIXA ETARIA", PARAMETROS.LK_MENSAGEM);

                    /*" -276- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0020-ACESSA-FAIXA-ETARIA-DB-SELECT-1 */
        public void M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1()
        {
            /*" -269- EXEC SQL SELECT TAXA_VG INTO :TAXA-VG FROM SEGUROS.V1FAIXAETA WHERE NUM_APOLICE = :NUM-APOLICE AND COD_SUBGRUPO = :COD-SUBGRUPO AND IDADE_INICIAL >= :IDADE AND IDADE_FINAL <= :IDADE AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 = new M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1()
            {
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
                IDADE = IDADE.ToString(),
            };

            var executed_1 = M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1.Execute(m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXA_VG, TAXA_VG);
            }


        }

        [StopWatch]
        /*" M-0030-ACESSA-FAIXA-SALARIAL */
        private void M_0030_ACESSA_FAIXA_SALARIAL(bool isPerform = false)
        {
            /*" -288- PERFORM M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1 */

            M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1();

            /*" -291- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -292- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -293- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_0.FLAG_CALCULA_PREMIO);

                    /*" -294- ELSE */
                }
                else
                {


                    /*" -295- MOVE 'ERRO NO ACESSO A FAIXA SALARIAL' TO LK-MENSAGEM */
                    _.Move("ERRO NO ACESSO A FAIXA SALARIAL", PARAMETROS.LK_MENSAGEM);

                    /*" -295- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0030-ACESSA-FAIXA-SALARIAL-DB-SELECT-1 */
        public void M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1()
        {
            /*" -288- EXEC SQL SELECT TAXA_VG INTO :TAXA-VG FROM SEGUROS.V1FAIXASAL WHERE NUM_APOLICE = :NUM-APOLICE AND COD_SUBGRUPO = :COD-SUBGRUPO AND SALARIO_INICIAL >= :SALARIO AND SALARIO_FINAL <= :SALARIO END-EXEC. */

            var m_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1 = new M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1()
            {
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
                SALARIO = SALARIO.ToString(),
            };

            var executed_1 = M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1.Execute(m_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXA_VG, TAXA_VG);
            }


        }

        [StopWatch]
        /*" M-0040-ACESSA-COND-TEC */
        private void M_0040_ACESSA_COND_TEC(bool isPerform = false)
        {
            /*" -321- PERFORM M_0040_ACESSA_COND_TEC_DB_SELECT_1 */

            M_0040_ACESSA_COND_TEC_DB_SELECT_1();

            /*" -324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -325- MOVE 'ERRO NO ACESSO A COND. TECNICA' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A COND. TECNICA", PARAMETROS.LK_MENSAGEM);

                /*" -325- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0040-ACESSA-COND-TEC-DB-SELECT-1 */
        public void M_0040_ACESSA_COND_TEC_DB_SELECT_1()
        {
            /*" -321- EXEC SQL SELECT TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :TAXA-AP-MORACID, :TAXA-AP-INVPERM, :TAXA-AP-AMDS, :TAXA-AP-DH, :TAXA-AP-DIT, :GARAN-ADIC-IEA, :GARAN-ADIC-IPA, :GARAN-ADIC-IPD, :GARAN-ADIC-HD FROM SEGUROS.V1CONDTEC WHERE NUM_APOLICE = :NUM-APOLICE AND COD_SUBGRUPO = :COD-SUBGRUPO END-EXEC. */

            var m_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1 = new M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1()
            {
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1.Execute(m_0040_ACESSA_COND_TEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TAXA_AP_MORACID, TAXA_AP_MORACID);
                _.Move(executed_1.TAXA_AP_INVPERM, TAXA_AP_INVPERM);
                _.Move(executed_1.TAXA_AP_AMDS, TAXA_AP_AMDS);
                _.Move(executed_1.TAXA_AP_DH, TAXA_AP_DH);
                _.Move(executed_1.TAXA_AP_DIT, TAXA_AP_DIT);
                _.Move(executed_1.GARAN_ADIC_IEA, GARAN_ADIC_IEA);
                _.Move(executed_1.GARAN_ADIC_IPA, GARAN_ADIC_IPA);
                _.Move(executed_1.GARAN_ADIC_IPD, GARAN_ADIC_IPD);
                _.Move(executed_1.GARAN_ADIC_HD, GARAN_ADIC_HD);
            }


        }

        [StopWatch]
        /*" M-0050-CAPITAIS-COBERTURA */
        private void M_0050_CAPITAIS_COBERTURA(bool isPerform = false)
        {
            /*" -332- COMPUTE LK-COBT-MORTE-NATURAL = LK-PURO-MORTE-NATURAL. */
            PARAMETROS.LK_COBT_MORTE_NATURAL.Value = PARAMETROS.LK_PURO_MORTE_NATURAL;

            /*" -335- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = LK-PURO-MORTE-ACIDENTAL + LK-PURO-MORTE-NATURAL. */
            PARAMETROS.LK_COBT_MORTE_ACIDENTAL.Value = PARAMETROS.LK_PURO_MORTE_ACIDENTAL + PARAMETROS.LK_PURO_MORTE_NATURAL;

            /*" -339- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = LK-COBT-MORTE-ACIDENTAL + (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IEA) / 100. */
            PARAMETROS.LK_COBT_MORTE_ACIDENTAL.Value = PARAMETROS.LK_COBT_MORTE_ACIDENTAL + (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IEA) / 100f;

            /*" -343- COMPUTE LK-COBT-INV-PERMANENTE ROUNDED = LK-PURO-INV-PERMANENTE + (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IPA) / 100. */
            PARAMETROS.LK_COBT_INV_PERMANENTE.Value = PARAMETROS.LK_PURO_INV_PERMANENTE + (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IPA) / 100f;

            /*" -346- COMPUTE LK-COBT-INV-POR-ACIDENTE ROUNDED = (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IPD) / 100. */
            PARAMETROS.LK_COBT_INV_POR_ACIDENTE.Value = (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IPD) / 100f;

            /*" -348- COMPUTE LK-COBT-ASS-MEDICA = LK-PURO-ASS-MEDICA. */
            PARAMETROS.LK_COBT_ASS_MEDICA.Value = PARAMETROS.LK_PURO_ASS_MEDICA;

            /*" -350- COMPUTE LK-COBT-DIARIA-HOSPITALAR = LK-PURO-DIARIA-HOSPITALAR */
            PARAMETROS.LK_COBT_DIARIA_HOSPITALAR.Value = PARAMETROS.LK_PURO_DIARIA_HOSPITALAR;

            /*" -351- COMPUTE LK-COBT-DIARIA-INTERNACAO = LK-PURO-DIARIA-INTERNACAO */
            PARAMETROS.LK_COBT_DIARIA_INTERNACAO.Value = PARAMETROS.LK_PURO_DIARIA_INTERNACAO;

            /*" -351- . */

        }

        [StopWatch]
        /*" M-0060-PREMIOS-SEGURO */
        private void M_0060_PREMIOS_SEGURO(bool isPerform = false)
        {
            /*" -358- COMPUTE LK-PREM-MORTE-NATURAL ROUNDED = (LK-PURO-MORTE-NATURAL * TAXA-VG) / 1000. */
            PARAMETROS.LK_PREM_MORTE_NATURAL.Value = (PARAMETROS.LK_PURO_MORTE_NATURAL * TAXA_VG) / 1000f;

            /*" -361- COMPUTE AUX-PREM-MORTE-ACIDENTAL ROUNDED = (LK-PURO-MORTE-ACIDENTAL * TAXA-AP-MORACID) / 1000. */
            FILLER_0.AUX_PREM_MORTE_ACIDENTAL.Value = (PARAMETROS.LK_PURO_MORTE_ACIDENTAL * TAXA_AP_MORACID) / 1000f;

            /*" -364- COMPUTE AUX-PREM-INV-PERMANENTE ROUNDED = (LK-PURO-INV-PERMANENTE * TAXA-AP-INVPERM) / 1000. */
            FILLER_0.AUX_PREM_INV_PERMANENTE.Value = (PARAMETROS.LK_PURO_INV_PERMANENTE * TAXA_AP_INVPERM) / 1000f;

            /*" -367- COMPUTE AUX-PREM-ASS-MEDICA ROUNDED = (LK-PURO-ASS-MEDICA * TAXA-AP-AMDS) / 1000. */
            FILLER_0.AUX_PREM_ASS_MEDICA.Value = (PARAMETROS.LK_PURO_ASS_MEDICA * TAXA_AP_AMDS) / 1000f;

            /*" -370- COMPUTE AUX-PREM-DIARIA-HOSPITALAR ROUNDED = (LK-PURO-DIARIA-HOSPITALAR * TAXA-AP-DH) / 1000. */
            FILLER_0.AUX_PREM_DIARIA_HOSPITALAR.Value = (PARAMETROS.LK_PURO_DIARIA_HOSPITALAR * TAXA_AP_DH) / 1000f;

            /*" -373- COMPUTE AUX-PREM-DIARIA-INTERNACAO ROUNDED = (LK-PURO-DIARIA-INTERNACAO * TAXA-AP-DIT) / 1000. */
            FILLER_0.AUX_PREM_DIARIA_INTERNACAO.Value = (PARAMETROS.LK_PURO_DIARIA_INTERNACAO * TAXA_AP_DIT) / 1000f;

            /*" -380- COMPUTE LK-PREM-ACIDENTES-PESSOAIS = AUX-PREM-MORTE-ACIDENTAL + AUX-PREM-INV-PERMANENTE + AUX-PREM-ASS-MEDICA + AUX-PREM-DIARIA-HOSPITALAR + AUX-PREM-DIARIA-INTERNACAO. */
            PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS.Value = FILLER_0.AUX_PREM_MORTE_ACIDENTAL + FILLER_0.AUX_PREM_INV_PERMANENTE + FILLER_0.AUX_PREM_ASS_MEDICA + FILLER_0.AUX_PREM_DIARIA_HOSPITALAR + FILLER_0.AUX_PREM_DIARIA_INTERNACAO;

            /*" -382- COMPUTE LK-PREM-TOTAL = LK-PREM-ACIDENTES-PESSOAIS + LK-PREM-MORTE-NATURAL. */
            PARAMETROS.LK_PREM_TOTAL.Value = PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS + PARAMETROS.LK_PREM_MORTE_NATURAL;

        }

        [StopWatch]
        /*" M-0070-ACESSA-APOLICE */
        private void M_0070_ACESSA_APOLICE(bool isPerform = false)
        {
            /*" -391- PERFORM M_0070_ACESSA_APOLICE_DB_SELECT_1 */

            M_0070_ACESSA_APOLICE_DB_SELECT_1();

            /*" -394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -395- MOVE 'ERRO NO ACESSO A APOLICE ' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A APOLICE ", PARAMETROS.LK_MENSAGEM);

                /*" -395- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0070-ACESSA-APOLICE-DB-SELECT-1 */
        public void M_0070_ACESSA_APOLICE_DB_SELECT_1()
        {
            /*" -391- EXEC SQL SELECT MODALIDA, RAMO INTO :MODALIDA, :RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :NUM-APOLICE END-EXEC. */

            var m_0070_ACESSA_APOLICE_DB_SELECT_1_Query1 = new M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1()
            {
                NUM_APOLICE = NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0070_ACESSA_APOLICE_DB_SELECT_1_Query1.Execute(m_0070_ACESSA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MODALIDA, MODALIDA);
                _.Move(executed_1.RAMO, RAMO);
            }


        }

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -400- MOVE SQLCODE TO LK-RETURN-CODE. */
            _.Move(DB.SQLCODE, PARAMETROS.LK_RETURN_CODE);

        }

        [StopWatch]
        /*" M-9999-FIM */
        private void M_9999_FIM(bool isPerform = false)
        {
            /*" -404- GOBACK. */

            throw new GoBack();

        }
    }
}