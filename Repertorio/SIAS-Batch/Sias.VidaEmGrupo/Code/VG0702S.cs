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
using Sias.VidaEmGrupo.DB2.VG0702S;

namespace Code
{
    public class VG0702S
    {
        public bool IsCall { get; set; }

        public VG0702S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DA SUBROTINA                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  CONVERSAO DE CAPITAIS COM COBERTURA PARA CAPITAIS PUROS       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO   |    DATA    |    AUTOR     |       HISTORICO       *      */
        /*"      *            |            |              |                       *      */
        /*"      *     01     |  26/09/91  |   PROCAS     |                       *      */
        /*"      *     02     |  08/03/93  |   PROCAS     |  INCLUSAO DE DMH      *      */
        /*"      *     03     |    /  /    |   PROCAS     |                       *      */
        /*"      *     04     |    /  /    |   PROCAS     |                       *      */
        /*"      *     05     |    /  /    |   PROCAS     |                       *      */
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
        /*"01  SALARIO                      PIC S9(013)V99       COMP-3.*/
        public DoubleBasis SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  TAXA-VG                      PIC S9(007)V9(04)    COMP-3.*/
        public DoubleBasis TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V9(04)"), 4);
        /*"01  TAXA-AP-MORACID              PIC S9(005)V9(06)    COMP-3.*/
        public DoubleBasis TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(06)"), 6);
        /*"01  TAXA-AP-INVPERM              PIC S9(005)V9(06)    COMP-3.*/
        public DoubleBasis TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(06)"), 6);
        /*"01  TAXA-AP-AMDS                 PIC S9(005)V9(06)    COMP-3.*/
        public DoubleBasis TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(06)"), 6);
        /*"01  TAXA-AP-DH                   PIC S9(005)V9(06)    COMP-3.*/
        public DoubleBasis TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(06)"), 6);
        /*"01  TAXA-AP-DIT                  PIC S9(005)V9(06)    COMP-3.*/
        public DoubleBasis TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(06)"), 6);
        /*"01  TAXA-AP-DMH                  PIC S9(005)V9(06)    COMP-3.*/
        public DoubleBasis TAXA_AP_DMH { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(06)"), 6);
        /*"01  VIND-AP-DMH                  PIC S9(004)          COMP.*/
        public IntBasis VIND_AP_DMH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GARAN-ADIC-IEA               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  GARAN-ADIC-IPA               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  GARAN-ADIC-IPD               PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_IPD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  GARAN-ADIC-HD                PIC S9(005)V9(02)    COMP-3.*/
        public DoubleBasis GARAN_ADIC_HD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  FILLER.*/
        public VG0702S_FILLER_0 FILLER_0 { get; set; } = new VG0702S_FILLER_0();
        public class VG0702S_FILLER_0 : VarBasis
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
            public VG0702S_DATA_SQL DATA_SQL { get; set; } = new VG0702S_DATA_SQL();
            public class VG0702S_DATA_SQL : VarBasis
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
            public VG0702S_DATA_SISTEMA DATA_SISTEMA { get; set; } = new VG0702S_DATA_SISTEMA();
            public class VG0702S_DATA_SISTEMA : VarBasis
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
            /*"    05 DATA-DDMMAAAA  REDEFINES  DATA-NORMAL.*/
            private _REDEF_VG0702S_DATA_DDMMAAAA _data_ddmmaaaa { get; set; }
            public _REDEF_VG0702S_DATA_DDMMAAAA DATA_DDMMAAAA
            {
                get { _data_ddmmaaaa = new _REDEF_VG0702S_DATA_DDMMAAAA(); _.Move(DATA_NORMAL, _data_ddmmaaaa); VarBasis.RedefinePassValue(DATA_NORMAL, _data_ddmmaaaa, DATA_NORMAL); _data_ddmmaaaa.ValueChanged += () => { _.Move(_data_ddmmaaaa, DATA_NORMAL); }; return _data_ddmmaaaa; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaaaa, DATA_NORMAL); }
            }  //Redefines
            public class _REDEF_VG0702S_DATA_DDMMAAAA : VarBasis
            {
                /*"       10 DIA                    PIC  9(002).*/
                public IntBasis DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 MES                    PIC  9(002).*/
                public IntBasis MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 ANO                    PIC  9(004).*/
                public IntBasis ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 DATA-INVERTIDA            PIC  9(008).*/

                public _REDEF_VG0702S_DATA_DDMMAAAA()
                {
                    DIA_1.ValueChanged += OnValueChanged;
                    MES_1.ValueChanged += OnValueChanged;
                    ANO_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-AAAAMMDD  REDEFINES  DATA-INVERTIDA.*/
            private _REDEF_VG0702S_DATA_AAAAMMDD _data_aaaammdd { get; set; }
            public _REDEF_VG0702S_DATA_AAAAMMDD DATA_AAAAMMDD
            {
                get { _data_aaaammdd = new _REDEF_VG0702S_DATA_AAAAMMDD(); _.Move(DATA_INVERTIDA, _data_aaaammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aaaammdd, DATA_INVERTIDA); _data_aaaammdd.ValueChanged += () => { _.Move(_data_aaaammdd, DATA_INVERTIDA); }; return _data_aaaammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aaaammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VG0702S_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 ANO                    PIC  9(004).*/
                public IntBasis ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 MES                    PIC  9(002).*/
                public IntBasis MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 DIA                    PIC  9(002).*/
                public IntBasis DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 AUX-PREM-MORTE-ACIDENTAL   PIC S9(013)V99 COMP-3 VALUE 0.*/

                public _REDEF_VG0702S_DATA_AAAAMMDD()
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
            /*"    05 AUX-PREM-DESPESA-MEDICA    PIC S9(013)V99 COMP-3 VALUE 0.*/
            public DoubleBasis AUX_PREM_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01  PARAMETROS.*/
        }
        public VG0702S_PARAMETROS PARAMETROS { get; set; } = new VG0702S_PARAMETROS();
        public class VG0702S_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public VG0702S_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0702S_LK_NASCIMENTO();
            public class VG0702S_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO            PIC  9(008).*/
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
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DESPESA-MEDICA        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
            /*"    05 LK-PURO-DESPESA-MEDICA        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                PIC S9(03) COMP.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VG0702S_PARAMETROS VG0702S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*PARAMETROS*/
        {
            try
            {
                this.PARAMETROS = VG0702S_PARAMETROS_P;

                /*" -145- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -149- MOVE 'S' TO FLAG-CALCULA-PREMIO. */
                _.Move("S", FILLER_0.FLAG_CALCULA_PREMIO);

                /*" -153- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -156- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -158- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return Result;
                }


                /*" -167- IF (LK-APOLICE NOT NUMERIC) OR (LK-SALARIO NOT NUMERIC) OR (LK-COBT-MORTE-NATURAL NOT NUMERIC) OR (LK-COBT-MORTE-ACIDENTAL NOT NUMERIC) OR (LK-COBT-INV-PERMANENTE NOT NUMERIC) OR (LK-COBT-ASS-MEDICA NOT NUMERIC) OR (LK-COBT-DIARIA-HOSPITALAR NOT NUMERIC) OR (LK-COBT-DIARIA-INTERNACAO NOT NUMERIC) OR (LK-COBT-DESPESA-MEDICA NOT NUMERIC) */

                if ((!PARAMETROS.LK_APOLICE.IsNumeric()) || (!PARAMETROS.LK_SALARIO.IsNumeric()) || (!PARAMETROS.LK_COBT_MORTE_NATURAL.IsNumeric()) || (!PARAMETROS.LK_COBT_MORTE_ACIDENTAL.IsNumeric()) || (!PARAMETROS.LK_COBT_INV_PERMANENTE.IsNumeric()) || (!PARAMETROS.LK_COBT_ASS_MEDICA.IsNumeric()) || (!PARAMETROS.LK_COBT_DIARIA_HOSPITALAR.IsNumeric()) || (!PARAMETROS.LK_COBT_DIARIA_INTERNACAO.IsNumeric()) || (!PARAMETROS.LK_COBT_DESPESA_MEDICA.IsNumeric()))
                {

                    /*" -168- MOVE 'DADOS NAO NUMERICOS' TO LK-MENSAGEM */
                    _.Move("DADOS NAO NUMERICOS", PARAMETROS.LK_MENSAGEM);

                    /*" -169- MOVE 10 TO LK-RETURN-CODE */
                    _.Move(10, PARAMETROS.LK_RETURN_CODE);

                    /*" -171- GO TO 9999-FIM. */

                    M_9999_FIM(); //GOTO
                    return Result;
                }


                /*" -172- IF LK-NASCIMENTO EQUAL SPACES */

                if (PARAMETROS.LK_NASCIMENTO.IsEmpty())
                {

                    /*" -173- MOVE ZEROS TO LK-DATA-NASCIMENTO */
                    _.Move(0, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO);

                    /*" -174- ELSE */
                }
                else
                {


                    /*" -175- IF LK-DATA-NASCIMENTO NOT NUMERIC */

                    if (!PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO.IsNumeric())
                    {

                        /*" -176- MOVE 'DATA DE NASCIMENTO INVALIDA' TO LK-MENSAGEM */
                        _.Move("DATA DE NASCIMENTO INVALIDA", PARAMETROS.LK_MENSAGEM);

                        /*" -177- MOVE 10 TO LK-RETURN-CODE */
                        _.Move(10, PARAMETROS.LK_RETURN_CODE);

                        /*" -179- GO TO 9999-FIM. */

                        M_9999_FIM(); //GOTO
                        return Result;
                    }

                }


                /*" -181- IF ZEROS EQUAL LK-APOLICE OR LK-SUBGRUPO */

                if (PARAMETROS.LK_APOLICE.IsEmpty() || PARAMETROS.LK_SUBGRUPO.IsEmpty())
                {

                    /*" -182- MOVE 'APOLICE/SUBGRUPO ZERADOS' TO LK-MENSAGEM */
                    _.Move("APOLICE/SUBGRUPO ZERADOS", PARAMETROS.LK_MENSAGEM);

                    /*" -183- MOVE 20 TO LK-RETURN-CODE */
                    _.Move(20, PARAMETROS.LK_RETURN_CODE);

                    /*" -185- GO TO 9999-FIM. */

                    M_9999_FIM(); //GOTO
                    return Result;
                }


                /*" -188- IF ZEROS EQUAL LK-IDADE AND LK-DATA-NASCIMENTO AND LK-SALARIO */

                if (PARAMETROS.LK_IDADE.IsEmpty() && PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO.IsEmpty() && PARAMETROS.LK_SALARIO.IsEmpty())
                {

                    /*" -190- MOVE 'N' TO FLAG-CALCULA-PREMIO. */
                    _.Move("N", FILLER_0.FLAG_CALCULA_PREMIO);
                }


                /*" -192- IF ZEROS EQUAL LK-COBT-MORTE-NATURAL AND LK-COBT-MORTE-ACIDENTAL */

                if (PARAMETROS.LK_COBT_MORTE_NATURAL.IsEmpty() && PARAMETROS.LK_COBT_MORTE_ACIDENTAL.IsEmpty())
                {

                    /*" -193- MOVE 'CAPITAIS COBERTURA ZERADOS' TO LK-MENSAGEM */
                    _.Move("CAPITAIS COBERTURA ZERADOS", PARAMETROS.LK_MENSAGEM);

                    /*" -194- MOVE 20 TO LK-RETURN-CODE */
                    _.Move(20, PARAMETROS.LK_RETURN_CODE);

                    /*" -196- GO TO 9999-FIM. */

                    M_9999_FIM(); //GOTO
                    return Result;
                }


                /*" -197- MOVE SISTEMA-DTMOVABE TO DATA-SQL. */
                _.Move(SISTEMA_DTMOVABE, FILLER_0.DATA_SQL);

                /*" -199- MOVE CORR DATA-SQL TO DATA-SISTEMA. */
                _.MoveCorr(FILLER_0.DATA_SQL, FILLER_0.DATA_SISTEMA);

                /*" -200- MOVE LK-APOLICE TO NUM-APOLICE. */
                _.Move(PARAMETROS.LK_APOLICE, NUM_APOLICE);

                /*" -202- MOVE LK-SUBGRUPO TO COD-SUBGRUPO. */
                _.Move(PARAMETROS.LK_SUBGRUPO, COD_SUBGRUPO);

                /*" -203- IF LK-DATA-NASCIMENTO NOT EQUAL ZEROS */

                if (PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO != 00)
                {

                    /*" -205- PERFORM 0010-CALCULA-IDADE. */

                    M_0010_CALCULA_IDADE(true);
                }


                /*" -206- IF LK-IDADE NOT EQUAL ZEROS */

                if (PARAMETROS.LK_IDADE != 00)
                {

                    /*" -207- MOVE LK-IDADE TO IDADE */
                    _.Move(PARAMETROS.LK_IDADE, IDADE);

                    /*" -209- PERFORM 0020-ACESSA-FAIXA-ETARIA. */

                    M_0020_ACESSA_FAIXA_ETARIA(true);
                }


                /*" -210- IF LK-SALARIO NOT EQUAL ZEROS */

                if (PARAMETROS.LK_SALARIO != 00)
                {

                    /*" -211- MOVE LK-SALARIO TO SALARIO */
                    _.Move(PARAMETROS.LK_SALARIO, SALARIO);

                    /*" -213- PERFORM M-0030-ACESSA-FAIXA-SALARIAL. */

                    M_0030_ACESSA_FAIXA_SALARIAL(true);
                }


                /*" -215- PERFORM 0040-ACESSA-COND-TEC. */

                M_0040_ACESSA_COND_TEC(true);

                /*" -217- PERFORM 0050-CAPITAIS-PUROS. */

                M_0050_CAPITAIS_PUROS(true);

                /*" -218- IF CALCULA-PREMIOS */

                if (FILLER_0.FLAG_CALCULA_PREMIO["CALCULA_PREMIOS"])
                {

                    /*" -220- PERFORM 0060-PREMIOS-SEGURO. */

                    M_0060_PREMIOS_SEGURO(true);
                }


                /*" -221- MOVE ZEROS TO LK-RETURN-CODE. */
                _.Move(0, PARAMETROS.LK_RETURN_CODE);

                /*" -223- MOVE SPACES TO LK-MENSAGEM. */
                _.Move("", PARAMETROS.LK_MENSAGEM);

                /*" -224- GOBACK. */

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
            /*" -153- EXEC SQL SELECT DTMOVABE INTO :SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

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
            /*" -229- MOVE LK-DATA-NASCIMENTO TO DATA-INVERTIDA. */
            _.Move(PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, FILLER_0.DATA_INVERTIDA);

            /*" -232- COMPUTE LK-IDADE = ANO OF DATA-SISTEMA - ANO OF DATA-AAAAMMDD. */
            PARAMETROS.LK_IDADE.Value = FILLER_0.DATA_SISTEMA.ANO_0 - FILLER_0.DATA_AAAAMMDD.ANO_2;

        }

        [StopWatch]
        /*" M-0020-ACESSA-FAIXA-ETARIA */
        private void M_0020_ACESSA_FAIXA_ETARIA(bool isPerform = false)
        {
            /*" -243- PERFORM M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1 */

            M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1();

            /*" -246- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -247- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -248- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_0.FLAG_CALCULA_PREMIO);

                    /*" -249- ELSE */
                }
                else
                {


                    /*" -250- MOVE 'ERRO NO ACESSO A FAIXA ETARIA' TO LK-MENSAGEM */
                    _.Move("ERRO NO ACESSO A FAIXA ETARIA", PARAMETROS.LK_MENSAGEM);

                    /*" -252- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0020-ACESSA-FAIXA-ETARIA-DB-SELECT-1 */
        public void M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1()
        {
            /*" -243- EXEC SQL SELECT TAXA_VG INTO :TAXA-VG FROM SEGUROS.V1FAIXAETA WHERE NUM_APOLICE = :NUM-APOLICE AND COD_SUBGRUPO = :COD-SUBGRUPO AND IDADE_INICIAL >= :IDADE AND IDADE_FINAL <= :IDADE AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

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
            /*" -262- PERFORM M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1 */

            M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1();

            /*" -265- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -266- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -267- MOVE 'N' TO FLAG-CALCULA-PREMIO */
                    _.Move("N", FILLER_0.FLAG_CALCULA_PREMIO);

                    /*" -268- ELSE */
                }
                else
                {


                    /*" -269- MOVE 'ERRO NO ACESSO A FAIXA SALARIAL' TO LK-MENSAGEM */
                    _.Move("ERRO NO ACESSO A FAIXA SALARIAL", PARAMETROS.LK_MENSAGEM);

                    /*" -271- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0030-ACESSA-FAIXA-SALARIAL-DB-SELECT-1 */
        public void M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1()
        {
            /*" -262- EXEC SQL SELECT TAXA_VG INTO :TAXA-VG FROM SEGUROS.V1FAIXASAL WHERE NUM_APOLICE = :NUM-APOLICE AND COD_SUBGRUPO = :COD-SUBGRUPO AND SALARIO_INICIAL >= :SALARIO AND SALARIO_FINAL <= :SALARIO END-EXEC. */

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
            /*" -297- PERFORM M_0040_ACESSA_COND_TEC_DB_SELECT_1 */

            M_0040_ACESSA_COND_TEC_DB_SELECT_1();

            /*" -300- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -301- MOVE 'ERRO NO ACESSO A COND. TECNICA' TO LK-MENSAGEM */
                _.Move("ERRO NO ACESSO A COND. TECNICA", PARAMETROS.LK_MENSAGEM);

                /*" -303- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -304- IF VIND-AP-DMH LESS ZEROS */

            if (VIND_AP_DMH < 00)
            {

                /*" -306- MOVE 0 TO TAXA-AP-DMH. */
                _.Move(0, TAXA_AP_DMH);
            }


        }

        [StopWatch]
        /*" M-0040-ACESSA-COND-TEC-DB-SELECT-1 */
        public void M_0040_ACESSA_COND_TEC_DB_SELECT_1()
        {
            /*" -297- EXEC SQL SELECT TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :TAXA-AP-MORACID, :TAXA-AP-INVPERM, :TAXA-AP-AMDS, :TAXA-AP-DH, :TAXA-AP-DIT, :GARAN-ADIC-IEA, :GARAN-ADIC-IPA, :GARAN-ADIC-IPD, :GARAN-ADIC-HD FROM SEGUROS.V1CONDTEC WHERE NUM_APOLICE = :NUM-APOLICE AND COD_SUBGRUPO = :COD-SUBGRUPO END-EXEC. */

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
        /*" M-0050-CAPITAIS-PUROS */
        private void M_0050_CAPITAIS_PUROS(bool isPerform = false)
        {
            /*" -311- COMPUTE LK-PURO-MORTE-NATURAL = LK-COBT-MORTE-NATURAL. */
            PARAMETROS.LK_PURO_MORTE_NATURAL.Value = PARAMETROS.LK_COBT_MORTE_NATURAL;

            /*" -314- COMPUTE LK-PURO-MORTE-ACIDENTAL ROUNDED = LK-COBT-MORTE-ACIDENTAL - LK-PURO-MORTE-NATURAL. */
            PARAMETROS.LK_PURO_MORTE_ACIDENTAL.Value = PARAMETROS.LK_COBT_MORTE_ACIDENTAL - PARAMETROS.LK_PURO_MORTE_NATURAL;

            /*" -318- COMPUTE LK-PURO-MORTE-ACIDENTAL ROUNDED = LK-PURO-MORTE-ACIDENTAL - (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IEA) / 100. */
            PARAMETROS.LK_PURO_MORTE_ACIDENTAL.Value = PARAMETROS.LK_PURO_MORTE_ACIDENTAL - (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IEA) / 100f;

            /*" -322- COMPUTE LK-PURO-INV-PERMANENTE ROUNDED = LK-COBT-INV-PERMANENTE - (LK-PURO-MORTE-NATURAL * GARAN-ADIC-IPA) / 100. */
            PARAMETROS.LK_PURO_INV_PERMANENTE.Value = PARAMETROS.LK_COBT_INV_PERMANENTE - (PARAMETROS.LK_PURO_MORTE_NATURAL * GARAN_ADIC_IPA) / 100f;

            /*" -324- COMPUTE LK-PURO-ASS-MEDICA = LK-COBT-ASS-MEDICA. */
            PARAMETROS.LK_PURO_ASS_MEDICA.Value = PARAMETROS.LK_COBT_ASS_MEDICA;

            /*" -327- COMPUTE LK-PURO-DIARIA-HOSPITALAR = LK-COBT-DIARIA-HOSPITALAR. */
            PARAMETROS.LK_PURO_DIARIA_HOSPITALAR.Value = PARAMETROS.LK_COBT_DIARIA_HOSPITALAR;

            /*" -330- COMPUTE LK-PURO-DIARIA-INTERNACAO = LK-COBT-DIARIA-INTERNACAO. */
            PARAMETROS.LK_PURO_DIARIA_INTERNACAO.Value = PARAMETROS.LK_COBT_DIARIA_INTERNACAO;

            /*" -333- COMPUTE LK-PURO-DESPESA-MEDICA = LK-COBT-DESPESA-MEDICA. */
            PARAMETROS.LK_PURO_DESPESA_MEDICA.Value = PARAMETROS.LK_COBT_DESPESA_MEDICA;

        }

        [StopWatch]
        /*" M-0060-PREMIOS-SEGURO */
        private void M_0060_PREMIOS_SEGURO(bool isPerform = false)
        {
            /*" -339- COMPUTE LK-PREM-MORTE-NATURAL ROUNDED = (LK-PURO-MORTE-NATURAL * TAXA-VG) / 1000. */
            PARAMETROS.LK_PREM_MORTE_NATURAL.Value = (PARAMETROS.LK_PURO_MORTE_NATURAL * TAXA_VG) / 1000f;

            /*" -342- COMPUTE AUX-PREM-MORTE-ACIDENTAL ROUNDED = (LK-PURO-MORTE-ACIDENTAL * TAXA-AP-MORACID) / 1000. */
            FILLER_0.AUX_PREM_MORTE_ACIDENTAL.Value = (PARAMETROS.LK_PURO_MORTE_ACIDENTAL * TAXA_AP_MORACID) / 1000f;

            /*" -345- COMPUTE AUX-PREM-INV-PERMANENTE ROUNDED = (LK-PURO-INV-PERMANENTE * TAXA-AP-INVPERM) / 1000. */
            FILLER_0.AUX_PREM_INV_PERMANENTE.Value = (PARAMETROS.LK_PURO_INV_PERMANENTE * TAXA_AP_INVPERM) / 1000f;

            /*" -348- COMPUTE AUX-PREM-ASS-MEDICA ROUNDED = (LK-PURO-ASS-MEDICA * TAXA-AP-AMDS) / 1000. */
            FILLER_0.AUX_PREM_ASS_MEDICA.Value = (PARAMETROS.LK_PURO_ASS_MEDICA * TAXA_AP_AMDS) / 1000f;

            /*" -351- COMPUTE AUX-PREM-DIARIA-HOSPITALAR ROUNDED = (LK-PURO-DIARIA-HOSPITALAR * TAXA-AP-DH) / 1000. */
            FILLER_0.AUX_PREM_DIARIA_HOSPITALAR.Value = (PARAMETROS.LK_PURO_DIARIA_HOSPITALAR * TAXA_AP_DH) / 1000f;

            /*" -354- COMPUTE AUX-PREM-DIARIA-INTERNACAO ROUNDED = (LK-PURO-DIARIA-INTERNACAO * TAXA-AP-DIT) / 1000. */
            FILLER_0.AUX_PREM_DIARIA_INTERNACAO.Value = (PARAMETROS.LK_PURO_DIARIA_INTERNACAO * TAXA_AP_DIT) / 1000f;

            /*" -357- COMPUTE AUX-PREM-DESPESA-MEDICA ROUNDED = (LK-PURO-DESPESA-MEDICA * TAXA-AP-DMH) / 1000. */
            FILLER_0.AUX_PREM_DESPESA_MEDICA.Value = (PARAMETROS.LK_PURO_DESPESA_MEDICA * TAXA_AP_DMH) / 1000f;

            /*" -365- COMPUTE LK-PREM-ACIDENTES-PESSOAIS = AUX-PREM-MORTE-ACIDENTAL + AUX-PREM-INV-PERMANENTE + AUX-PREM-ASS-MEDICA + AUX-PREM-DIARIA-HOSPITALAR + AUX-PREM-DIARIA-INTERNACAO + AUX-PREM-DESPESA-MEDICA. */
            PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS.Value = FILLER_0.AUX_PREM_MORTE_ACIDENTAL + FILLER_0.AUX_PREM_INV_PERMANENTE + FILLER_0.AUX_PREM_ASS_MEDICA + FILLER_0.AUX_PREM_DIARIA_HOSPITALAR + FILLER_0.AUX_PREM_DIARIA_INTERNACAO + FILLER_0.AUX_PREM_DESPESA_MEDICA;

            /*" -369- COMPUTE LK-PREM-TOTAL = LK-PREM-ACIDENTES-PESSOAIS + LK-PREM-MORTE-NATURAL. */
            PARAMETROS.LK_PREM_TOTAL.Value = PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS + PARAMETROS.LK_PREM_MORTE_NATURAL;

        }

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -372- MOVE SQLCODE TO LK-RETURN-CODE. */
            _.Move(DB.SQLCODE, PARAMETROS.LK_RETURN_CODE);

        }

        [StopWatch]
        /*" M-9999-FIM */
        private void M_9999_FIM(bool isPerform = false)
        {
            /*" -376- GOBACK. */

            throw new GoBack();

        }
    }
}