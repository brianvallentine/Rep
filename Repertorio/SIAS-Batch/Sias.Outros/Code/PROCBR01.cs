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

namespace Code
{
    public class PROCBR01
    {
        public bool IsCall { get; set; }

        public PROCBR01()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SUBROTINAS                         *      */
        /*"      *   PROGRAMA ...............  PROCBR01                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS / VANDO                     *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO / 1994                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  TRANFORMA VALORES EM CODIGOS PARA  *      */
        /*"      *                             IMPRESSAO DE BARRAS.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           AREA-DE-WORK.*/
        public PROCBR01_AREA_DE_WORK AREA_DE_WORK { get; set; } = new PROCBR01_AREA_DE_WORK();
        public class PROCBR01_AREA_DE_WORK : VarBasis
        {
            /*"  05         WK-RCCODE         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WK_RCCODE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01          BR-CODIG-DE-BARRA.*/
        }
        public PROCBR01_BR_CODIG_DE_BARRA BR_CODIG_DE_BARRA { get; set; } = new PROCBR01_BR_CODIG_DE_BARRA();
        public class PROCBR01_BR_CODIG_DE_BARRA : VarBasis
        {
            /*"  03        BR-COD-XEROX          PIC  X(050)   VALUE           '10001010011100000101101000110000011100100101000110'.*/
            public StringBasis BR_COD_XEROX { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"10001010011100000101101000110000011100100101000110");
            /*"  03        RBR-COD-XEROX         REDEFINES     BR-COD-XEROX.*/
            private _REDEF_PROCBR01_RBR_COD_XEROX _rbr_cod_xerox { get; set; }
            public _REDEF_PROCBR01_RBR_COD_XEROX RBR_COD_XEROX
            {
                get { _rbr_cod_xerox = new _REDEF_PROCBR01_RBR_COD_XEROX(); _.Move(BR_COD_XEROX, _rbr_cod_xerox); VarBasis.RedefinePassValue(BR_COD_XEROX, _rbr_cod_xerox, BR_COD_XEROX); _rbr_cod_xerox.ValueChanged += () => { _.Move(_rbr_cod_xerox, BR_COD_XEROX); }; return _rbr_cod_xerox; }
                set { VarBasis.RedefinePassValue(value, _rbr_cod_xerox, BR_COD_XEROX); }
            }  //Redefines
            public class _REDEF_PROCBR01_RBR_COD_XEROX : VarBasis
            {
                /*"    05      BR-COD-XEROX10        OCCURS        10 TIMES.*/
                public ListBasis<PROCBR01_BR_COD_XEROX10> BR_COD_XEROX10 { get; set; } = new ListBasis<PROCBR01_BR_COD_XEROX10>(10);
                public class PROCBR01_BR_COD_XEROX10 : VarBasis
                {
                    /*"      07    BR-COD-XEROX5         OCCURS        5  TIMES                                  PIC  9(001).*/
                    public ListBasis<IntBasis, Int64> BR_COD_XEROX5 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 5);
                    /*"  03        BR-COMP-XEROX.*/

                    public PROCBR01_BR_COD_XEROX10()
                    {
                        BR_COD_XEROX5.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PROCBR01_RBR_COD_XEROX()
                {
                    BR_COD_XEROX10.ValueChanged += OnValueChanged;
                }

            }
            public PROCBR01_BR_COMP_XEROX BR_COMP_XEROX { get; set; } = new PROCBR01_BR_COMP_XEROX();
            public class PROCBR01_BR_COMP_XEROX : VarBasis
            {
                /*"    05      BR-COMPOSTO-XEROX     OCCURS        10 TIMES                                  PIC  9(001).*/
                public ListBasis<IntBasis, Int64> BR_COMPOSTO_XEROX { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 10);
                /*"  03        RBR-COMP-XEROX        REDEFINES     BR-COMP-XEROX.*/
            }
            private _REDEF_PROCBR01_RBR_COMP_XEROX _rbr_comp_xerox { get; set; }
            public _REDEF_PROCBR01_RBR_COMP_XEROX RBR_COMP_XEROX
            {
                get { _rbr_comp_xerox = new _REDEF_PROCBR01_RBR_COMP_XEROX(); _.Move(BR_COMP_XEROX, _rbr_comp_xerox); VarBasis.RedefinePassValue(BR_COMP_XEROX, _rbr_comp_xerox, BR_COMP_XEROX); _rbr_comp_xerox.ValueChanged += () => { _.Move(_rbr_comp_xerox, BR_COMP_XEROX); }; return _rbr_comp_xerox; }
                set { VarBasis.RedefinePassValue(value, _rbr_comp_xerox, BR_COMP_XEROX); }
            }  //Redefines
            public class _REDEF_PROCBR01_RBR_COMP_XEROX : VarBasis
            {
                /*"    05      RBR-COMPOSTO-XEROX    OCCURS        5  TIMES                                  PIC  9(002).*/
                public ListBasis<IntBasis, Int64> RBR_COMPOSTO_XEROX { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "2", "9(002)."), 5);
                /*"  03        BR-COD-BARRA-NUM.*/

                public _REDEF_PROCBR01_RBR_COMP_XEROX()
                {
                    RBR_COMPOSTO_XEROX.ValueChanged += OnValueChanged;
                }

            }
            public PROCBR01_BR_COD_BARRA_NUM BR_COD_BARRA_NUM { get; set; } = new PROCBR01_BR_COD_BARRA_NUM();
            public class PROCBR01_BR_COD_BARRA_NUM : VarBasis
            {
                /*"    05      BR-NUMERO             PIC  X(044).*/
                public StringBasis BR_NUMERO { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
                /*"  03        RBR-COD-BARRA-NUM     REDEFINES     BR-COD-BARRA-NUM*/
            }
            private _REDEF_PROCBR01_RBR_COD_BARRA_NUM _rbr_cod_barra_num { get; set; }
            public _REDEF_PROCBR01_RBR_COD_BARRA_NUM RBR_COD_BARRA_NUM
            {
                get { _rbr_cod_barra_num = new _REDEF_PROCBR01_RBR_COD_BARRA_NUM(); _.Move(BR_COD_BARRA_NUM, _rbr_cod_barra_num); VarBasis.RedefinePassValue(BR_COD_BARRA_NUM, _rbr_cod_barra_num, BR_COD_BARRA_NUM); _rbr_cod_barra_num.ValueChanged += () => { _.Move(_rbr_cod_barra_num, BR_COD_BARRA_NUM); }; return _rbr_cod_barra_num; }
                set { VarBasis.RedefinePassValue(value, _rbr_cod_barra_num, BR_COD_BARRA_NUM); }
            }  //Redefines
            public class _REDEF_PROCBR01_RBR_COD_BARRA_NUM : VarBasis
            {
                /*"    05      RBR-COD-BARRA-30      OCCURS        44 TIMES                                  PIC  9(001).*/
                public ListBasis<IntBasis, Int64> RBR_COD_BARRA_30 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 44);
                /*"  03        BR-COD-BARRA-XEROX    PIC  X(110).*/

                public _REDEF_PROCBR01_RBR_COD_BARRA_NUM()
                {
                    RBR_COD_BARRA_30.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis BR_COD_BARRA_XEROX { get; set; } = new StringBasis(new PIC("X", "110", "X(110)."), @"");
            /*"  03        RBR-COD-BARRA-XEROX   REDEFINES   BR-COD-BARRA-XEROX*/
            private _REDEF_PROCBR01_RBR_COD_BARRA_XEROX _rbr_cod_barra_xerox { get; set; }
            public _REDEF_PROCBR01_RBR_COD_BARRA_XEROX RBR_COD_BARRA_XEROX
            {
                get { _rbr_cod_barra_xerox = new _REDEF_PROCBR01_RBR_COD_BARRA_XEROX(); _.Move(BR_COD_BARRA_XEROX, _rbr_cod_barra_xerox); VarBasis.RedefinePassValue(BR_COD_BARRA_XEROX, _rbr_cod_barra_xerox, BR_COD_BARRA_XEROX); _rbr_cod_barra_xerox.ValueChanged += () => { _.Move(_rbr_cod_barra_xerox, BR_COD_BARRA_XEROX); }; return _rbr_cod_barra_xerox; }
                set { VarBasis.RedefinePassValue(value, _rbr_cod_barra_xerox, BR_COD_BARRA_XEROX); }
            }  //Redefines
            public class _REDEF_PROCBR01_RBR_COD_BARRA_XEROX : VarBasis
            {
                /*"    05      BR-COD-BAR-XER        OCCURS        110  TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> BR_COD_BAR_XER { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 110);
                /*"  03        BR-INDEX1-XEROX       PIC  9(003)   VALUE ZERO.*/

                public _REDEF_PROCBR01_RBR_COD_BARRA_XEROX()
                {
                    BR_COD_BAR_XER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis BR_INDEX1_XEROX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        BR-INDEX2-XEROX       PIC  9(003)   VALUE ZERO.*/
            public IntBasis BR_INDEX2_XEROX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        BR-INDEX1-BARRA       PIC  9(003)   VALUE ZERO.*/
            public IntBasis BR_INDEX1_BARRA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        BR-INDEX2-BARRA       PIC  9(003)   VALUE ZERO.*/
            public IntBasis BR_INDEX2_BARRA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        BR-INDEX-XER-COMP     PIC  9(003)   VALUE ZERO.*/
            public IntBasis BR_INDEX_XER_COMP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        BR-NUMER.*/
            public PROCBR01_BR_NUMER BR_NUMER { get; set; } = new PROCBR01_BR_NUMER();
            public class PROCBR01_BR_NUMER : VarBasis
            {
                /*"    05      BR-BANCO              PIC  9(003).*/
                public IntBasis BR_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05      BR-MOEDA              PIC  9(001).*/
                public IntBasis BR_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05      BR-DIGITO             PIC  9(001).*/
                public IntBasis BR_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05      BR-VTITULO            PIC  9(012)V99.*/
                public DoubleBasis BR_VTITULO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
                /*"    05      BR-NNUMERO            PIC  9(010).*/
                public IntBasis BR_NNUMERO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    05      BR-CCEDIDO            PIC  9(015).*/
                public IntBasis BR_CCEDIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"  03        BR-FIM-SUP            PIC  9(001).*/
            }
            public IntBasis BR_FIM_SUP { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03        IND4                  PIC  9(002).*/
            public IntBasis IND4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03        IND5                  PIC  9(002).*/
            public IntBasis IND5 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01          BR-CODIGO-DE-BARRA.*/
        }
        public PROCBR01_BR_CODIGO_DE_BARRA BR_CODIGO_DE_BARRA { get; set; } = new PROCBR01_BR_CODIGO_DE_BARRA();
        public class PROCBR01_BR_CODIGO_DE_BARRA : VarBasis
        {
            /*"  03        BR-START              PIC  X(001)   VALUE '<'.*/
            public StringBasis BR_START { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"<");
            /*"  03        BR-CODBARRA           PIC  X(110)   VALUE  SPACES.*/
            public StringBasis BR_CODBARRA { get; set; } = new StringBasis(new PIC("X", "110", "X(110)"), @"");
            /*"  03        BR-STOP               PIC  X(001)   VALUE '>'.*/
            public StringBasis BR_STOP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @">");
            /*"01          LINK-AREA.*/
        }
        public PROCBR01_LINK_AREA LINK_AREA { get; set; } = new PROCBR01_LINK_AREA();
        public class PROCBR01_LINK_AREA : VarBasis
        {
            /*"  03        LK-BANCO               PIC  9(003).*/
            public IntBasis LK_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03        LK-MOEDA               PIC  9(001).*/
            public IntBasis LK_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03        LK-DIGITO              PIC  9(001).*/
            public IntBasis LK_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03        LK-VALOR               PIC  9(012)V99.*/
            public DoubleBasis LK_VALOR { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  03        LK-NNURO               PIC  9(010).*/
            public IntBasis LK_NNURO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03        LK-CDCED               PIC  9(015).*/
            public IntBasis LK_CDCED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  03        LK-CODIGO              PIC  X(112).*/
            public StringBasis LK_CODIGO { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
            /*"  03        LK-RCCODE              PIC  X(001).*/
            public StringBasis LK_RCCODE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROCBR01_LINK_AREA PROCBR01_LINK_AREA_P) //PROCEDURE DIVISION USING 
        /*LINK_AREA*/
        {
            try
            {
                this.LINK_AREA = PROCBR01_LINK_AREA_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_AREA, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -129- PERFORM R1000-00-PROCESSA-CODIGO */

            R1000_00_PROCESSA_CODIGO_SECTION();

            /*" -130- IF RETURN-CODE EQUAL ZEROS */

            if (RETURN_CODE == 00)
            {

                /*" -131- MOVE BR-CODIGO-DE-BARRA TO LK-CODIGO */
                _.Move(BR_CODIGO_DE_BARRA, LINK_AREA.LK_CODIGO);

                /*" -132- MOVE SPACES TO LK-RCCODE */
                _.Move("", LINK_AREA.LK_RCCODE);

                /*" -133- ELSE */
            }
            else
            {


                /*" -134- MOVE SPACES TO LK-CODIGO */
                _.Move("", LINK_AREA.LK_CODIGO);

                /*" -136- MOVE 'E' TO LK-RCCODE. */
                _.Move("E", LINK_AREA.LK_RCCODE);
            }


            /*" -136- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CODIGO-SECTION */
        private void R1000_00_PROCESSA_CODIGO_SECTION()
        {
            /*" -148- MOVE LK-BANCO TO BR-BANCO */
            _.Move(LINK_AREA.LK_BANCO, BR_CODIG_DE_BARRA.BR_NUMER.BR_BANCO);

            /*" -149- MOVE LK-MOEDA TO BR-MOEDA */
            _.Move(LINK_AREA.LK_MOEDA, BR_CODIG_DE_BARRA.BR_NUMER.BR_MOEDA);

            /*" -150- MOVE LK-DIGITO TO BR-DIGITO */
            _.Move(LINK_AREA.LK_DIGITO, BR_CODIG_DE_BARRA.BR_NUMER.BR_DIGITO);

            /*" -151- MOVE LK-VALOR TO BR-VTITULO */
            _.Move(LINK_AREA.LK_VALOR, BR_CODIG_DE_BARRA.BR_NUMER.BR_VTITULO);

            /*" -152- MOVE LK-NNURO TO BR-NNUMERO */
            _.Move(LINK_AREA.LK_NNURO, BR_CODIG_DE_BARRA.BR_NUMER.BR_NNUMERO);

            /*" -154- MOVE LK-CDCED TO BR-CCEDIDO */
            _.Move(LINK_AREA.LK_CDCED, BR_CODIG_DE_BARRA.BR_NUMER.BR_CCEDIDO);

            /*" -154- PERFORM R2000-00-MONTA-COD-BARRAS. */

            R2000_00_MONTA_COD_BARRAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-MONTA-COD-BARRAS-SECTION */
        private void R2000_00_MONTA_COD_BARRAS_SECTION()
        {
            /*" -166- MOVE BR-NUMER TO BR-NUMERO */
            _.Move(BR_CODIG_DE_BARRA.BR_NUMER, BR_CODIG_DE_BARRA.BR_COD_BARRA_NUM.BR_NUMERO);

            /*" -167- MOVE 1 TO BR-INDEX-XER-COMP */
            _.Move(1, BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP);

            /*" -168- MOVE 1 TO BR-INDEX1-BARRA */
            _.Move(1, BR_CODIG_DE_BARRA.BR_INDEX1_BARRA);

            /*" -169- MOVE 2 TO BR-INDEX2-BARRA */
            _.Move(2, BR_CODIG_DE_BARRA.BR_INDEX2_BARRA);

            /*" -170- PERFORM R2100-00-MONTA-BARRAS 22 TIMES */

            for (int i = 0; i < 22; i++)
            {

                R2100_00_MONTA_BARRAS_SECTION();

            }

            /*" -170- MOVE BR-COD-BARRA-XEROX TO BR-CODBARRA. */
            _.Move(BR_CODIG_DE_BARRA.BR_COD_BARRA_XEROX, BR_CODIGO_DE_BARRA.BR_CODBARRA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MONTA-BARRAS-SECTION */
        private void R2100_00_MONTA_BARRAS_SECTION()
        {
            /*" -183- MOVE RBR-COD-BARRA-30 (BR-INDEX1-BARRA) TO BR-INDEX1-XEROX */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_BARRA_NUM.RBR_COD_BARRA_30[BR_CODIG_DE_BARRA.BR_INDEX1_BARRA], BR_CODIG_DE_BARRA.BR_INDEX1_XEROX);

            /*" -184- IF BR-INDEX1-XEROX EQUAL ZERO */

            if (BR_CODIG_DE_BARRA.BR_INDEX1_XEROX == 00)
            {

                /*" -186- MOVE 10 TO BR-INDEX1-XEROX. */
                _.Move(10, BR_CODIG_DE_BARRA.BR_INDEX1_XEROX);
            }


            /*" -188- MOVE RBR-COD-BARRA-30 (BR-INDEX2-BARRA) TO BR-INDEX2-XEROX */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_BARRA_NUM.RBR_COD_BARRA_30[BR_CODIG_DE_BARRA.BR_INDEX2_BARRA], BR_CODIG_DE_BARRA.BR_INDEX2_XEROX);

            /*" -189- IF BR-INDEX2-XEROX EQUAL ZERO */

            if (BR_CODIG_DE_BARRA.BR_INDEX2_XEROX == 00)
            {

                /*" -191- MOVE 10 TO BR-INDEX2-XEROX. */
                _.Move(10, BR_CODIG_DE_BARRA.BR_INDEX2_XEROX);
            }


            /*" -193- MOVE BR-COD-XEROX5 (BR-INDEX1-XEROX 1) TO BR-COMPOSTO-XEROX (01) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX1_XEROX].BR_COD_XEROX5[1], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[01]);

            /*" -196- MOVE BR-COD-XEROX5 (BR-INDEX2-XEROX 1) TO BR-COMPOSTO-XEROX (02) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX2_XEROX].BR_COD_XEROX5[1], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[02]);

            /*" -198- MOVE BR-COD-XEROX5 (BR-INDEX1-XEROX 2) TO BR-COMPOSTO-XEROX (03) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX1_XEROX].BR_COD_XEROX5[2], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[03]);

            /*" -201- MOVE BR-COD-XEROX5 (BR-INDEX2-XEROX 2) TO BR-COMPOSTO-XEROX (04) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX2_XEROX].BR_COD_XEROX5[2], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[04]);

            /*" -203- MOVE BR-COD-XEROX5 (BR-INDEX1-XEROX 3) TO BR-COMPOSTO-XEROX (05) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX1_XEROX].BR_COD_XEROX5[3], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[05]);

            /*" -206- MOVE BR-COD-XEROX5 (BR-INDEX2-XEROX 3) TO BR-COMPOSTO-XEROX (06) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX2_XEROX].BR_COD_XEROX5[3], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[06]);

            /*" -208- MOVE BR-COD-XEROX5 (BR-INDEX1-XEROX 4) TO BR-COMPOSTO-XEROX (07) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX1_XEROX].BR_COD_XEROX5[4], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[07]);

            /*" -211- MOVE BR-COD-XEROX5 (BR-INDEX2-XEROX 4) TO BR-COMPOSTO-XEROX (08) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX2_XEROX].BR_COD_XEROX5[4], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[08]);

            /*" -213- MOVE BR-COD-XEROX5 (BR-INDEX1-XEROX 5) TO BR-COMPOSTO-XEROX (09) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX1_XEROX].BR_COD_XEROX5[5], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[09]);

            /*" -216- MOVE BR-COD-XEROX5 (BR-INDEX2-XEROX 5) TO BR-COMPOSTO-XEROX (10) */
            _.Move(BR_CODIG_DE_BARRA.RBR_COD_XEROX.BR_COD_XEROX10[BR_CODIG_DE_BARRA.BR_INDEX2_XEROX].BR_COD_XEROX5[5], BR_CODIG_DE_BARRA.BR_COMP_XEROX.BR_COMPOSTO_XEROX[10]);

            /*" -217- IF RBR-COMPOSTO-XEROX (01) EQUAL 01 */

            if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[01] == 01)
            {

                /*" -218- MOVE 'N' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                _.Move("N", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                /*" -219- ELSE */
            }
            else
            {


                /*" -220- IF RBR-COMPOSTO-XEROX (01) EQUAL 11 */

                if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[01] == 11)
                {

                    /*" -221- MOVE 'W' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                    _.Move("W", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                    /*" -222- ELSE */
                }
                else
                {


                    /*" -223- IF RBR-COMPOSTO-XEROX (01) EQUAL 00 */

                    if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[01] == 00)
                    {

                        /*" -224- MOVE 'n' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                        _.Move("n", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                        /*" -225- ELSE */
                    }
                    else
                    {


                        /*" -227- MOVE 'w' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP). */
                        _.Move("w", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -229- ADD 1 TO BR-INDEX-XER-COMP */
            BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP.Value = BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP + 1;

            /*" -230- IF RBR-COMPOSTO-XEROX (02) EQUAL 01 */

            if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[02] == 01)
            {

                /*" -231- MOVE 'N' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                _.Move("N", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                /*" -232- ELSE */
            }
            else
            {


                /*" -233- IF RBR-COMPOSTO-XEROX (02) EQUAL 11 */

                if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[02] == 11)
                {

                    /*" -234- MOVE 'W' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                    _.Move("W", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                    /*" -235- ELSE */
                }
                else
                {


                    /*" -236- IF RBR-COMPOSTO-XEROX (02) EQUAL 00 */

                    if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[02] == 00)
                    {

                        /*" -237- MOVE 'n' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                        _.Move("n", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                        /*" -238- ELSE */
                    }
                    else
                    {


                        /*" -240- MOVE 'w' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP). */
                        _.Move("w", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -242- ADD 1 TO BR-INDEX-XER-COMP */
            BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP.Value = BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP + 1;

            /*" -243- IF RBR-COMPOSTO-XEROX (03) EQUAL 01 */

            if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[03] == 01)
            {

                /*" -244- MOVE 'N' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                _.Move("N", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                /*" -245- ELSE */
            }
            else
            {


                /*" -246- IF RBR-COMPOSTO-XEROX (03) EQUAL 11 */

                if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[03] == 11)
                {

                    /*" -247- MOVE 'W' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                    _.Move("W", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                    /*" -248- ELSE */
                }
                else
                {


                    /*" -249- IF RBR-COMPOSTO-XEROX (03) EQUAL 00 */

                    if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[03] == 00)
                    {

                        /*" -250- MOVE 'n' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                        _.Move("n", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                        /*" -251- ELSE */
                    }
                    else
                    {


                        /*" -253- MOVE 'w' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP). */
                        _.Move("w", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -255- ADD 1 TO BR-INDEX-XER-COMP */
            BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP.Value = BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP + 1;

            /*" -256- IF RBR-COMPOSTO-XEROX (04) EQUAL 01 */

            if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[04] == 01)
            {

                /*" -257- MOVE 'N' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                _.Move("N", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                /*" -258- ELSE */
            }
            else
            {


                /*" -259- IF RBR-COMPOSTO-XEROX (04) EQUAL 11 */

                if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[04] == 11)
                {

                    /*" -260- MOVE 'W' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                    _.Move("W", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                    /*" -261- ELSE */
                }
                else
                {


                    /*" -262- IF RBR-COMPOSTO-XEROX (04) EQUAL 00 */

                    if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[04] == 00)
                    {

                        /*" -263- MOVE 'n' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                        _.Move("n", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                        /*" -264- ELSE */
                    }
                    else
                    {


                        /*" -266- MOVE 'w' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP). */
                        _.Move("w", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -268- ADD 1 TO BR-INDEX-XER-COMP */
            BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP.Value = BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP + 1;

            /*" -269- IF RBR-COMPOSTO-XEROX (05) EQUAL 01 */

            if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[05] == 01)
            {

                /*" -270- MOVE 'N' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                _.Move("N", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                /*" -271- ELSE */
            }
            else
            {


                /*" -272- IF RBR-COMPOSTO-XEROX (05) EQUAL 11 */

                if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[05] == 11)
                {

                    /*" -273- MOVE 'W' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                    _.Move("W", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                    /*" -274- ELSE */
                }
                else
                {


                    /*" -275- IF RBR-COMPOSTO-XEROX (05) EQUAL 00 */

                    if (BR_CODIG_DE_BARRA.RBR_COMP_XEROX.RBR_COMPOSTO_XEROX[05] == 00)
                    {

                        /*" -276- MOVE 'n' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP) */
                        _.Move("n", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);

                        /*" -277- ELSE */
                    }
                    else
                    {


                        /*" -279- MOVE 'w' TO BR-COD-BAR-XER (BR-INDEX-XER-COMP). */
                        _.Move("w", BR_CODIG_DE_BARRA.RBR_COD_BARRA_XEROX.BR_COD_BAR_XER[BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -280- ADD 1 TO BR-INDEX-XER-COMP */
            BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP.Value = BR_CODIG_DE_BARRA.BR_INDEX_XER_COMP + 1;

            /*" -281- ADD 2 TO BR-INDEX1-BARRA */
            BR_CODIG_DE_BARRA.BR_INDEX1_BARRA.Value = BR_CODIG_DE_BARRA.BR_INDEX1_BARRA + 2;

            /*" -281- ADD 2 TO BR-INDEX2-BARRA. */
            BR_CODIG_DE_BARRA.BR_INDEX2_BARRA.Value = BR_CODIG_DE_BARRA.BR_INDEX2_BARRA + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/
    }
}