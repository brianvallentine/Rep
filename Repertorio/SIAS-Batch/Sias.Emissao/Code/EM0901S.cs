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
using Sias.Emissao.DB2.EM0901S;

namespace Code
{
    public class EM0901S
    {
        public bool IsCall { get; set; }

        public EM0901S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *        FUNCAO.............. ROTINA DE CALCULO DE PARCELAS      *      */
        /*"      *        PROGRAMA............ EM0901S                            *      */
        /*"      *        ANALISTA............ PROCAS                             *      */
        /*"      *        PROGRAMADOR......... PROCAS/ALEX                        *      */
        /*"      *        DATA CODIFICACAO.... SETEMBRO/91                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO REALIZADA EM 16/07/2001 - CIRCULAR SUSEP 156/2001   *      */
        /*"      *  VALOR DE CUSTO DE APOLICE DEVER� SER 10% DO VALOR LIQUIDO     *      */
        /*"      *  LIMITADO EM R$ 60,00.                                         *      */
        /*"      *  SO HOUVE ALTERACAO NO A6000. NO RESTANTE FORAM ACRESCENTADOS  *      */
        /*"      *  APENAS COMENTARIOS.                                           *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77  MOED-COD-MOEDA              PIC S9(04)       COMP VALUE +0.*/
        public IntBasis MOED_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MOED-DTINIVIG               PIC  X(10).*/
        public StringBasis MOED_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  MOED-TIPO-MOEDA             PIC  X(01).*/
        public StringBasis MOED_TIPO_MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  MOED-VALOR                  PIC S9(06)V9(09) COMP-3 VALUE +0*/
        public DoubleBasis MOED_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
        /*"77  CUST-VLBASE10               PIC S9(13)V99    COMP-3 VALUE +0*/
        public DoubleBasis CUST_VLBASE10 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CUST-VLINIFAI               PIC S9(13)V99    COMP-3 VALUE +0*/
        public DoubleBasis CUST_VLINIFAI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CUST-VLFINFAI               PIC S9(13)V99    COMP-3 VALUE +0*/
        public DoubleBasis CUST_VLFINFAI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  CUST-DTINIVIG               PIC  X(10).*/
        public StringBasis CUST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  CUST-VLCUSTO                PIC S9(13)V99    COMP-3 VALUE +0*/
        public DoubleBasis CUST_VLCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  FRAC-RAMO                   PIC S9(04)       COMP VALUE +0.*/
        public IntBasis FRAC_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  FRAC-DTINIVIG               PIC  X(10).*/
        public StringBasis FRAC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  FRAC-NRPARCEL               PIC S9(04)       COMP VALUE +0.*/
        public IntBasis FRAC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  FRAC-QTPARCEL               PIC S9(04)       COMP VALUE +0.*/
        public IntBasis FRAC_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  FRAC-INDPRLIQ               PIC S9(03)V9(8)  COMP-3 VALUE +0*/
        public DoubleBasis FRAC_INDPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(8)"), 8);
        /*"77  FRAC-INDADIC                PIC S9(03)V9(8)  COMP-3 VALUE +0*/
        public DoubleBasis FRAC_INDADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(8)"), 8);
        /*"77  FRAC-PCJUROS                PIC S9(03)V9(2)  COMP-3 VALUE +0*/
        public DoubleBasis FRAC_PCJUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(2)"), 2);
        /*"77  VL-BASECUSTO                PIC S9(13)V99    COMP-3 VALUE +0*/
        public DoubleBasis VL_BASECUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  VL-BASECUSTO-IX             PIC S9(10)V9(5)  COMP-3 VALUE +0*/
        public DoubleBasis VL_BASECUSTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  VL-PCDESCON                 PIC S9(15)V9(02) COMP-3 VALUE +0*/
        public DoubleBasis VL_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
        /*"77  VL-PCDESCON-IX              PIC S9(10)V9(05) COMP-3 VALUE +0*/
        public DoubleBasis VL_PCDESCON_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  VL-LIQUIDO-CUSTO            PIC S9(15)V9(02) COMP-3 VALUE +0*/
        public DoubleBasis VL_LIQUIDO_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
        /*"01          WABEND.*/
        public EM0901S_WABEND WABEND { get; set; } = new EM0901S_WABEND();
        public class EM0901S_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' EM0901S  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0901S  ");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(007) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"000");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01          WERRO               PIC  S9(09)    VALUE ZEROS.*/
        }
        public IntBasis WERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01          WVL-LIQUIDO         PIC  ZZZ.ZZZ.ZZ9,99.*/
        public DoubleBasis WVL_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
        /*"01          WWWW-VLINIFAI       PIC  ZZZ.ZZZ.ZZ9,99-.*/
        public DoubleBasis WWWW_VLINIFAI { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
        /*"01          WVL-PERCENT         PIC  ZZZ.ZZ9,9999.*/
        public DoubleBasis WVL_PERCENT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999."), 4);
        /*"01          WWRK-INDPRLIQ       PIC S9(03)V9(6)  COMP-3 VALUE +0*/
        public DoubleBasis WWRK_INDPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(6)"), 6);
        /*"01               CALCULOS.*/
        public EM0901S_CALCULOS CALCULOS { get; set; } = new EM0901S_CALCULOS();
        public class EM0901S_CALCULOS : VarBasis
        {
            /*"    03           RAMO                   PIC S9(04)  COMP.*/
            public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    03           COD-MOEDA              PIC  9(04).*/
            public IntBasis COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03           DTINIVIG-LK            PIC  X(10).*/
            public StringBasis DTINIVIG_LK { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03           NRPARCEL               PIC  9(02).*/
            public IntBasis NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03           QTPARCEL               PIC  9(02).*/
            public IntBasis QTPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03           IND-FRAC               PIC  X(01).*/
            public StringBasis IND_FRAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03           ISENTA-CUSTO           PIC  X(01).*/
            public StringBasis ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03           PCIOF                  PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03           PCENTRAD               PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03           PCJUROS                PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCJUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03           PCDESCON               PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03           VL-PREMIO-BASE         PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_PREMIO_BASE { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-TAR-IX              PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-DESC-IX             PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_DESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-LIQ-IX              PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_LIQ_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-ADIC-IX             PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_ADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-CUSTO-IX            PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_CUSTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-IOF-IX              PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_IOF_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-TOTAL-IX            PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03           VL-TARIFA              PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           VL-DESCONTO            PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           VL-LIQUIDO             PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           VL-ADICIONAL           PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_ADICIONAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           VL-CUSTO               PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           VL-IOF                 PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           VL-TOTAL               PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           W01A0077.*/
            public EM0901S_W01A0077 W01A0077 { get; set; } = new EM0901S_W01A0077();
            public class EM0901S_W01A0077 : VarBasis
            {
                /*"      05         W01A0077-LIT           PIC  X(71).*/
                public StringBasis W01A0077_LIT { get; set; } = new StringBasis(new PIC("X", "71", "X(71)."), @"");
                /*"      05         W01A0077-LITR REDEFINES W01A0077-LIT.*/
                private _REDEF_EM0901S_W01A0077_LITR _w01a0077_litr { get; set; }
                public _REDEF_EM0901S_W01A0077_LITR W01A0077_LITR
                {
                    get { _w01a0077_litr = new _REDEF_EM0901S_W01A0077_LITR(); _.Move(W01A0077_LIT, _w01a0077_litr); VarBasis.RedefinePassValue(W01A0077_LIT, _w01a0077_litr, W01A0077_LIT); _w01a0077_litr.ValueChanged += () => { _.Move(_w01a0077_litr, W01A0077_LIT); }; return _w01a0077_litr; }
                    set { VarBasis.RedefinePassValue(value, _w01a0077_litr, W01A0077_LIT); }
                }  //Redefines
                public class _REDEF_EM0901S_W01A0077_LITR : VarBasis
                {
                    /*"        07       W01A0077-VERSAO        PIC  9(03).*/
                    public IntBasis W01A0077_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"        07       FILLER                 PIC  X(68).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "68", "X(68)."), @"");
                    /*"      05         W01A0077-COD           PIC  X(06).*/

                    public _REDEF_EM0901S_W01A0077_LITR()
                    {
                        W01A0077_VERSAO.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W01A0077_COD { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"    03           NRRCAP                 PIC S9(09)       COMP.*/
            }
            public IntBasis NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03           VL-COBER-ASSIST        PIC S9(15)V99    COMP-3.*/
            public DoubleBasis VL_COBER_ASSIST { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"    03           PCDESCON-ADIC          PIC S9(03)V9999  COMP-3.*/
            public DoubleBasis PCDESCON_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
            /*"    03           PCDESCON-BONUS         PIC S9(03)V9999  COMP-3.*/
            public DoubleBasis PCDESCON_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        }


        public EM0901S_V1MOEDA V1MOEDA { get; set; } = new EM0901S_V1MOEDA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0901S_CALCULOS EM0901S_CALCULOS_P) //PROCEDURE DIVISION USING 
        /*CALCULOS*/
        {
            try
            {
                this.CALCULOS = EM0901S_CALCULOS_P;

                /*" -137-  Removido na conversão: EXIT. */

                /*" -137- FLUXCONTROL_PERFORM M-0000-ROTINA-PRINCIPAL-SECTION */

                M_0000_ROTINA_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CALCULOS };
            return Result;
        }

        [StopWatch]
        /*" M-0000-ROTINA-PRINCIPAL-SECTION */
        private void M_0000_ROTINA_PRINCIPAL_SECTION()
        {
            /*" -143- PERFORM A1000-INICIO */

            A1000_INICIO_SECTION();

            /*" -145- PERFORM A2000-LE-MOEDA */

            A2000_LE_MOEDA_SECTION();

            /*" -146- IF NRPARCEL EQUAL 0 */

            if (CALCULOS.NRPARCEL == 0)
            {

                /*" -147- PERFORM A3000-CALCULA-UNICO */

                A3000_CALCULA_UNICO_SECTION();

                /*" -148- ELSE */
            }
            else
            {


                /*" -149- IF NRPARCEL EQUAL 1 */

                if (CALCULOS.NRPARCEL == 1)
                {

                    /*" -150- PERFORM A4000-PRIMEIRA-PARCELA */

                    A4000_PRIMEIRA_PARCELA_SECTION();

                    /*" -151- ELSE */
                }
                else
                {


                    /*" -153- PERFORM A5000-CALCULA-DEMAIS. */

                    A5000_CALCULA_DEMAIS_SECTION();
                }

            }


            /*" -155- MOVE SPACES TO W01A0077. */
            _.Move("", CALCULOS.W01A0077);

            /*" -156- IF MOED-TIPO-MOEDA EQUAL '0' */

            if (MOED_TIPO_MOEDA == "0")
            {

                /*" -157- MOVE VL-TARIFA TO VL-TAR-IX */
                _.Move(CALCULOS.VL_TARIFA, CALCULOS.VL_TAR_IX);

                /*" -158- MOVE VL-DESCONTO TO VL-DESC-IX */
                _.Move(CALCULOS.VL_DESCONTO, CALCULOS.VL_DESC_IX);

                /*" -159- MOVE VL-LIQUIDO TO VL-LIQ-IX */
                _.Move(CALCULOS.VL_LIQUIDO, CALCULOS.VL_LIQ_IX);

                /*" -160- MOVE VL-ADICIONAL TO VL-ADIC-IX */
                _.Move(CALCULOS.VL_ADICIONAL, CALCULOS.VL_ADIC_IX);

                /*" -161- MOVE VL-CUSTO TO VL-CUSTO-IX */
                _.Move(CALCULOS.VL_CUSTO, CALCULOS.VL_CUSTO_IX);

                /*" -162- MOVE VL-IOF TO VL-IOF-IX */
                _.Move(CALCULOS.VL_IOF, CALCULOS.VL_IOF_IX);

                /*" -164- MOVE VL-TOTAL TO VL-TOTAL-IX. */
                _.Move(CALCULOS.VL_TOTAL, CALCULOS.VL_TOTAL_IX);
            }


            /*" -164- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_999_EXIT*/

        [StopWatch]
        /*" A1000-INICIO-SECTION */
        private void A1000_INICIO_SECTION()
        {
            /*" -174- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -176- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -178- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1000_999_EXIT*/

        [StopWatch]
        /*" A2000-LE-MOEDA-SECTION */
        private void A2000_LE_MOEDA_SECTION()
        {
            /*" -185- MOVE 'A2000' TO WNR-EXEC-SQL */
            _.Move("A2000", WABEND.WNR_EXEC_SQL);

            /*" -186- MOVE COD-MOEDA TO MOED-COD-MOEDA */
            _.Move(CALCULOS.COD_MOEDA, MOED_COD_MOEDA);

            /*" -188- MOVE DTINIVIG-LK TO MOED-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, MOED_DTINIVIG);

            /*" -197- PERFORM A2000_LE_MOEDA_DB_DECLARE_1 */

            A2000_LE_MOEDA_DB_DECLARE_1();

            /*" -200- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -202- MOVE ' ERRO ACESSO V1MOEDA 1' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA 1", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -204- MOVE SQLCODE TO W01A0077-COD */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_COD);

                /*" -206- GOBACK. */

                throw new GoBack();
            }


            /*" -206- PERFORM A2000_LE_MOEDA_DB_OPEN_1 */

            A2000_LE_MOEDA_DB_OPEN_1();

            /*" -209- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -211- MOVE ' ERRO ACESSO V1MOEDA 2' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA 2", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -213- MOVE SQLCODE TO W01A0077-COD */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_COD);

                /*" -215- GOBACK. */

                throw new GoBack();
            }


            /*" -218- PERFORM A2000_LE_MOEDA_DB_FETCH_1 */

            A2000_LE_MOEDA_DB_FETCH_1();

            /*" -221- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -223- MOVE 'MOEDA SEM COTACAO/INDISPONIVEL' TO W01A0077 */
                _.Move("MOEDA SEM COTACAO/INDISPONIVEL", CALCULOS.W01A0077);

                /*" -225- GOBACK. */

                throw new GoBack();
            }


            /*" -226- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -228- MOVE ' ERRO ACESSO V1MOEDA' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -230- MOVE SQLCODE TO W01A0077-COD */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_COD);

                /*" -232- GOBACK. */

                throw new GoBack();
            }


            /*" -232- PERFORM A2000_LE_MOEDA_DB_CLOSE_1 */

            A2000_LE_MOEDA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-DECLARE-1 */
        public void A2000_LE_MOEDA_DB_DECLARE_1()
        {
            /*" -197- EXEC SQL DECLARE V1MOEDA CURSOR FOR SELECT VLCRUZAD, TIPO_MOEDA FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :MOED-COD-MOEDA AND DTINIVIG <= :MOED-DTINIVIG AND DTTERVIG >= :MOED-DTINIVIG AND SITUACAO = '0' END-EXEC. */
            V1MOEDA = new EM0901S_V1MOEDA(true);
            string GetQuery_V1MOEDA()
            {
                var query = @$"SELECT VLCRUZAD
							, 
							TIPO_MOEDA 
							FROM SEGUROS.V1MOEDA 
							WHERE CODUNIMO = '{MOED_COD_MOEDA}' 
							AND DTINIVIG <= '{MOED_DTINIVIG}' 
							AND DTTERVIG >= '{MOED_DTINIVIG}' 
							AND SITUACAO = '0'";

                return query;
            }
            V1MOEDA.GetQueryEvent += GetQuery_V1MOEDA;

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-OPEN-1 */
        public void A2000_LE_MOEDA_DB_OPEN_1()
        {
            /*" -206- EXEC SQL OPEN V1MOEDA END-EXEC. */

            V1MOEDA.Open();

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-FETCH-1 */
        public void A2000_LE_MOEDA_DB_FETCH_1()
        {
            /*" -218- EXEC SQL FETCH V1MOEDA INTO :MOED-VALOR, :MOED-TIPO-MOEDA END-EXEC. */

            if (V1MOEDA.Fetch())
            {
                _.Move(V1MOEDA.MOED_VALOR, MOED_VALOR);
                _.Move(V1MOEDA.MOED_TIPO_MOEDA, MOED_TIPO_MOEDA);
            }

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-CLOSE-1 */
        public void A2000_LE_MOEDA_DB_CLOSE_1()
        {
            /*" -232- EXEC SQL CLOSE V1MOEDA END-EXEC. */

            V1MOEDA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A2999_999_EXIT*/

        [StopWatch]
        /*" A3000-CALCULA-UNICO-SECTION */
        private void A3000_CALCULA_UNICO_SECTION()
        {
            /*" -245- MOVE ZEROS TO FRAC-INDPRLIQ FRAC-INDADIC */
            _.Move(0, FRAC_INDPRLIQ, FRAC_INDADIC);

            /*" -246- IF PCJUROS NOT EQUAL ZEROS */

            if (CALCULOS.PCJUROS != 00)
            {

                /*" -247- PERFORM A4200-FRACIONA-OUTROS */

                A4200_FRACIONA_OUTROS_SECTION();

                /*" -257- GO TO A3000-10-CONTINUA. */

                A3000_10_CONTINUA(); //GOTO
                return;
            }


            /*" -257- MOVE VL-PREMIO-BASE TO VL-TAR-IX. */
            _.Move(CALCULOS.VL_PREMIO_BASE, CALCULOS.VL_TAR_IX);

            /*" -0- FLUXCONTROL_PERFORM A3000_10_CONTINUA */

            A3000_10_CONTINUA();

        }

        [StopWatch]
        /*" A3000-10-CONTINUA */
        private void A3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -268- COMPUTE VL-DESC-IX ROUNDED = (VL-TAR-IX * PCDESCON) / 100. */
            CALCULOS.VL_DESC_IX.Value = (CALCULOS.VL_TAR_IX * CALCULOS.PCDESCON) / 100f;

            /*" -273- COMPUTE VL-LIQ-IX ROUNDED = VL-TAR-IX - VL-DESC-IX. */
            CALCULOS.VL_LIQ_IX.Value = CALCULOS.VL_TAR_IX - CALCULOS.VL_DESC_IX;

            /*" -276- COMPUTE VL-TARIFA ROUNDED = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -279- COMPUTE VL-DESCONTO ROUNDED = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -287- COMPUTE VL-LIQUIDO = VL-TARIFA - VL-DESCONTO. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_TARIFA - CALCULOS.VL_DESCONTO;

            /*" -288- IF ISENTA-CUSTO EQUAL 'N' */

            if (CALCULOS.ISENTA_CUSTO == "N")
            {

                /*" -289- MOVE VL-LIQUIDO TO VL-BASECUSTO */
                _.Move(CALCULOS.VL_LIQUIDO, VL_BASECUSTO);

                /*" -290- PERFORM A6000-LE-CUSTO */

                A6000_LE_CUSTO_SECTION();

                /*" -291- MOVE CUST-VLCUSTO TO VL-CUSTO */
                _.Move(CUST_VLCUSTO, CALCULOS.VL_CUSTO);

                /*" -292- ELSE */
            }
            else
            {


                /*" -294- MOVE ZEROS TO VL-CUSTO. */
                _.Move(0, CALCULOS.VL_CUSTO);
            }


            /*" -303- COMPUTE VL-CUSTO-IX = VL-CUSTO / MOED-VALOR. */
            CALCULOS.VL_CUSTO_IX.Value = CALCULOS.VL_CUSTO / MOED_VALOR;

            /*" -307- COMPUTE VL-IOF-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX. */
            CALCULOS.VL_IOF_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX;

            /*" -317- COMPUTE VL-IOF-IX = (VL-IOF-IX * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = (CALCULOS.VL_IOF_IX * CALCULOS.PCIOF) / 100f;

            /*" -330- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            CALCULOS.VL_TOTAL_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_IOF_IX;

            /*" -339- COMPUTE VL-ADICIONAL ROUNDED = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -343- COMPUTE VL-IOF ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-CUSTO. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_CUSTO;

            /*" -353- COMPUTE VL-IOF ROUNDED = (VL-IOF * PCIOF) / 100. */
            CALCULOS.VL_IOF.Value = (CALCULOS.VL_IOF * CALCULOS.PCIOF) / 100f;

            /*" -356- COMPUTE VL-TOTAL ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-IOF + VL-CUSTO. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF + CALCULOS.VL_CUSTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_CALCULA_UNICO*/

        [StopWatch]
        /*" A4000-PRIMEIRA-PARCELA-SECTION */
        private void A4000_PRIMEIRA_PARCELA_SECTION()
        {
            /*" -384- MOVE ZEROS TO FRAC-INDPRLIQ FRAC-INDADIC */
            _.Move(0, FRAC_INDPRLIQ, FRAC_INDADIC);

            /*" -385- IF IND-FRAC EQUAL 'S' */

            if (CALCULOS.IND_FRAC == "S")
            {

                /*" -386- PERFORM A4100-FRACIONA-ESPECIAL */

                A4100_FRACIONA_ESPECIAL_SECTION();

                /*" -387- GO TO R4000-10-CONTINUA */

                R4000_10_CONTINUA(); //GOTO
                return;

                /*" -388- ELSE */
            }
            else
            {


                /*" -389- IF PCJUROS NOT EQUAL ZEROS */

                if (CALCULOS.PCJUROS != 00)
                {

                    /*" -390- PERFORM A4200-FRACIONA-OUTROS */

                    A4200_FRACIONA_OUTROS_SECTION();

                    /*" -392- GO TO R4000-10-CONTINUA. */

                    R4000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -393- IF PCENTRAD NOT EQUAL ZEROS */

            if (CALCULOS.PCENTRAD != 00)
            {

                /*" -396- COMPUTE VL-TAR-IX ROUNDED = (VL-PREMIO-BASE * PCENTRAD) / 100 */
                CALCULOS.VL_TAR_IX.Value = (CALCULOS.VL_PREMIO_BASE * CALCULOS.PCENTRAD) / 100f;

                /*" -397- ELSE */
            }
            else
            {


                /*" -398- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / QTPARCEL. */
                CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / CALCULOS.QTPARCEL;
            }


            /*" -0- FLUXCONTROL_PERFORM R4000_10_CONTINUA */

            R4000_10_CONTINUA();

        }

        [StopWatch]
        /*" R4000-10-CONTINUA */
        private void R4000_10_CONTINUA(bool isPerform = false)
        {
            /*" -406- COMPUTE VL-DESC-IX ROUNDED = (VL-TAR-IX * PCDESCON) / 100. */
            CALCULOS.VL_DESC_IX.Value = (CALCULOS.VL_TAR_IX * CALCULOS.PCDESCON) / 100f;

            /*" -409- COMPUTE VL-LIQ-IX ROUNDED = VL-TAR-IX - VL-DESC-IX. */
            CALCULOS.VL_LIQ_IX.Value = CALCULOS.VL_TAR_IX - CALCULOS.VL_DESC_IX;

            /*" -412- COMPUTE VL-TARIFA ROUNDED = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -415- COMPUTE VL-DESCONTO ROUNDED = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -418- COMPUTE VL-ADICIONAL ROUNDED = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -421- COMPUTE VL-LIQUIDO = VL-TARIFA - VL-DESCONTO. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_TARIFA - CALCULOS.VL_DESCONTO;

            /*" -423- IF ISENTA-CUSTO EQUAL 'N' */

            if (CALCULOS.ISENTA_CUSTO == "N")
            {

                /*" -427- COMPUTE VL-PCDESCON-IX = (VL-PREMIO-BASE * PCDESCON) / 100 */
                VL_PCDESCON_IX.Value = (CALCULOS.VL_PREMIO_BASE * CALCULOS.PCDESCON) / 100f;

                /*" -430- COMPUTE VL-PCDESCON = VL-PCDESCON-IX * MOED-VALOR */
                VL_PCDESCON.Value = VL_PCDESCON_IX * MOED_VALOR;

                /*" -433- COMPUTE VL-LIQUIDO-CUSTO = VL-PREMIO-BASE - VL-PCDESCON */
                VL_LIQUIDO_CUSTO.Value = CALCULOS.VL_PREMIO_BASE - VL_PCDESCON;

                /*" -435- MOVE VL-LIQUIDO-CUSTO TO VL-BASECUSTO */
                _.Move(VL_LIQUIDO_CUSTO, VL_BASECUSTO);

                /*" -437- PERFORM A6000-LE-CUSTO */

                A6000_LE_CUSTO_SECTION();

                /*" -438- MOVE CUST-VLCUSTO TO VL-CUSTO */
                _.Move(CUST_VLCUSTO, CALCULOS.VL_CUSTO);

                /*" -439- ELSE */
            }
            else
            {


                /*" -441- MOVE ZEROS TO VL-CUSTO. */
                _.Move(0, CALCULOS.VL_CUSTO);
            }


            /*" -444- COMPUTE VL-CUSTO-IX = VL-CUSTO / MOED-VALOR. */
            CALCULOS.VL_CUSTO_IX.Value = CALCULOS.VL_CUSTO / MOED_VALOR;

            /*" -448- COMPUTE VL-IOF-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX. */
            CALCULOS.VL_IOF_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX;

            /*" -452- COMPUTE VL-IOF-IX = (VL-IOF-IX * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = (CALCULOS.VL_IOF_IX * CALCULOS.PCIOF) / 100f;

            /*" -457- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            CALCULOS.VL_TOTAL_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_IOF_IX;

            /*" -461- COMPUTE VL-IOF = VL-LIQUIDO + VL-ADICIONAL + VL-CUSTO. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_CUSTO;

            /*" -465- COMPUTE VL-IOF ROUNDED = (VL-IOF * PCIOF) / 100. */
            CALCULOS.VL_IOF.Value = (CALCULOS.VL_IOF * CALCULOS.PCIOF) / 100f;

            /*" -468- COMPUTE VL-TOTAL ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-IOF + VL-CUSTO. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF + CALCULOS.VL_CUSTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4999_PRIMEIRA_PARCELA*/

        [StopWatch]
        /*" A4100-FRACIONA-ESPECIAL-SECTION */
        private void A4100_FRACIONA_ESPECIAL_SECTION()
        {
            /*" -476- MOVE 'A4100' TO WNR-EXEC-SQL */
            _.Move("A4100", WABEND.WNR_EXEC_SQL);

            /*" -477- MOVE RAMO TO FRAC-RAMO */
            _.Move(CALCULOS.RAMO, FRAC_RAMO);

            /*" -478- MOVE DTINIVIG-LK TO FRAC-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, FRAC_DTINIVIG);

            /*" -479- MOVE NRPARCEL TO FRAC-NRPARCEL */
            _.Move(CALCULOS.NRPARCEL, FRAC_NRPARCEL);

            /*" -481- MOVE QTPARCEL TO FRAC-QTPARCEL */
            _.Move(CALCULOS.QTPARCEL, FRAC_QTPARCEL);

            /*" -492- PERFORM A4100_FRACIONA_ESPECIAL_DB_SELECT_1 */

            A4100_FRACIONA_ESPECIAL_DB_SELECT_1();

            /*" -495- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -497- MOVE 'ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS' TO W01A0077 */
                _.Move("ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS", CALCULOS.W01A0077);

                /*" -499- GOBACK. */

                throw new GoBack();
            }


            /*" -500- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -502- MOVE 'ERRO ACESSO V1FRACIONAMENTO' TO W01A0077 */
                _.Move("ERRO ACESSO V1FRACIONAMENTO", CALCULOS.W01A0077);

                /*" -504- GOBACK. */

                throw new GoBack();
            }


            /*" -507- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / FRAC-QTPARCEL. */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / FRAC_QTPARCEL;

            /*" -511- COMPUTE VL-ADIC-IX = VL-PREMIO-BASE * ((( FRAC-INDPRLIQ * FRAC-QTPARCEL ) - 1 ) / FRAC-QTPARCEL ). */
            CALCULOS.VL_ADIC_IX.Value = CALCULOS.VL_PREMIO_BASE * (((FRAC_INDPRLIQ * FRAC_QTPARCEL) - 1) / FRAC_QTPARCEL);

        }

        [StopWatch]
        /*" A4100-FRACIONA-ESPECIAL-DB-SELECT-1 */
        public void A4100_FRACIONA_ESPECIAL_DB_SELECT_1()
        {
            /*" -492- EXEC SQL SELECT INDPRLIQ, INDADIC INTO :FRAC-INDPRLIQ, :FRAC-INDADIC FROM SEGUROS.V1FRACIONAMENTO WHERE RAMO = :FRAC-RAMO AND DTINIVIG <= :FRAC-DTINIVIG AND DTTERVIG >= :FRAC-DTINIVIG AND NRPARCEL = :FRAC-NRPARCEL AND QTPARCEL = :FRAC-QTPARCEL END-EXEC. */

            var a4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1 = new A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1()
            {
                FRAC_DTINIVIG = FRAC_DTINIVIG.ToString(),
                FRAC_NRPARCEL = FRAC_NRPARCEL.ToString(),
                FRAC_QTPARCEL = FRAC_QTPARCEL.ToString(),
                FRAC_RAMO = FRAC_RAMO.ToString(),
            };

            var executed_1 = A4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1.Execute(a4100_FRACIONA_ESPECIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FRAC_INDPRLIQ, FRAC_INDPRLIQ);
                _.Move(executed_1.FRAC_INDADIC, FRAC_INDADIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4100_999_EXIT*/

        [StopWatch]
        /*" A4200-FRACIONA-OUTROS-SECTION */
        private void A4200_FRACIONA_OUTROS_SECTION()
        {
            /*" -521- MOVE 'A4200' TO WNR-EXEC-SQL */
            _.Move("A4200", WABEND.WNR_EXEC_SQL);

            /*" -522- IF W01A0077-VERSAO GREATER 200 */

            if (CALCULOS.W01A0077.W01A0077_LITR.W01A0077_VERSAO > 200)
            {

                /*" -523- MOVE 31 TO FRAC-RAMO */
                _.Move(31, FRAC_RAMO);

                /*" -524- ELSE */
            }
            else
            {


                /*" -525- IF NRRCAP NOT EQUAL ZEROS */

                if (CALCULOS.NRRCAP != 00)
                {

                    /*" -526- MOVE ZEROS TO FRAC-RAMO */
                    _.Move(0, FRAC_RAMO);

                    /*" -527- ELSE */
                }
                else
                {


                    /*" -529- MOVE 01 TO FRAC-RAMO. */
                    _.Move(01, FRAC_RAMO);
                }

            }


            /*" -531- MOVE DTINIVIG-LK TO FRAC-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, FRAC_DTINIVIG);

            /*" -532- IF QTPARCEL EQUAL ZEROS */

            if (CALCULOS.QTPARCEL == 00)
            {

                /*" -533- MOVE 1 TO FRAC-QTPARCEL */
                _.Move(1, FRAC_QTPARCEL);

                /*" -534- ELSE */
            }
            else
            {


                /*" -536- MOVE QTPARCEL TO FRAC-QTPARCEL. */
                _.Move(CALCULOS.QTPARCEL, FRAC_QTPARCEL);
            }


            /*" -538- MOVE FRAC-QTPARCEL TO FRAC-NRPARCEL */
            _.Move(FRAC_QTPARCEL, FRAC_NRPARCEL);

            /*" -548- PERFORM A4200_FRACIONA_OUTROS_DB_SELECT_1 */

            A4200_FRACIONA_OUTROS_DB_SELECT_1();

            /*" -551- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -553- MOVE 'ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS' TO W01A0077 */
                _.Move("ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS", CALCULOS.W01A0077);

                /*" -555- GOBACK. */

                throw new GoBack();
            }


            /*" -556- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -558- MOVE 'ERRO ACESSO V1FRACIONAMENTO' TO W01A0077 */
                _.Move("ERRO ACESSO V1FRACIONAMENTO", CALCULOS.W01A0077);

                /*" -560- GOBACK. */

                throw new GoBack();
            }


            /*" -563- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / FRAC-QTPARCEL. */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / FRAC_QTPARCEL;

            /*" -567- COMPUTE VL-ADIC-IX = VL-PREMIO-BASE * ((( FRAC-INDPRLIQ * FRAC-QTPARCEL ) - 1 ) / FRAC-QTPARCEL ). */
            CALCULOS.VL_ADIC_IX.Value = CALCULOS.VL_PREMIO_BASE * (((FRAC_INDPRLIQ * FRAC_QTPARCEL) - 1) / FRAC_QTPARCEL);

        }

        [StopWatch]
        /*" A4200-FRACIONA-OUTROS-DB-SELECT-1 */
        public void A4200_FRACIONA_OUTROS_DB_SELECT_1()
        {
            /*" -548- EXEC SQL SELECT INDPRLIQ, INDADIC INTO :FRAC-INDPRLIQ, :FRAC-INDADIC FROM SEGUROS.V1FRACIONAMENTO WHERE RAMO = :FRAC-RAMO AND DTINIVIG <= :FRAC-DTINIVIG AND DTTERVIG >= :FRAC-DTINIVIG AND NRPARCEL = :FRAC-NRPARCEL AND QTPARCEL = :FRAC-QTPARCEL END-EXEC. */

            var a4200_FRACIONA_OUTROS_DB_SELECT_1_Query1 = new A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1()
            {
                FRAC_DTINIVIG = FRAC_DTINIVIG.ToString(),
                FRAC_NRPARCEL = FRAC_NRPARCEL.ToString(),
                FRAC_QTPARCEL = FRAC_QTPARCEL.ToString(),
                FRAC_RAMO = FRAC_RAMO.ToString(),
            };

            var executed_1 = A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1.Execute(a4200_FRACIONA_OUTROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FRAC_INDPRLIQ, FRAC_INDPRLIQ);
                _.Move(executed_1.FRAC_INDADIC, FRAC_INDADIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4200_999_EXIT*/

        [StopWatch]
        /*" A5000-CALCULA-DEMAIS-SECTION */
        private void A5000_CALCULA_DEMAIS_SECTION()
        {
            /*" -584- MOVE ZEROS TO FRAC-INDPRLIQ FRAC-INDADIC */
            _.Move(0, FRAC_INDPRLIQ, FRAC_INDADIC);

            /*" -585- IF IND-FRAC EQUAL 'S' */

            if (CALCULOS.IND_FRAC == "S")
            {

                /*" -586- PERFORM A4100-FRACIONA-ESPECIAL */

                A4100_FRACIONA_ESPECIAL_SECTION();

                /*" -587- GO TO R5000-10-CONTINUA */

                R5000_10_CONTINUA(); //GOTO
                return;

                /*" -588- ELSE */
            }
            else
            {


                /*" -589- IF PCJUROS NOT EQUAL ZEROS */

                if (CALCULOS.PCJUROS != 00)
                {

                    /*" -590- PERFORM A4200-FRACIONA-OUTROS */

                    A4200_FRACIONA_OUTROS_SECTION();

                    /*" -592- GO TO R5000-10-CONTINUA. */

                    R5000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -593- COMPUTE VL-TAR-IX ROUNDED = VL-PREMIO-BASE / (QTPARCEL - 1). */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / (CALCULOS.QTPARCEL - 1);

            /*" -0- FLUXCONTROL_PERFORM R5000_10_CONTINUA */

            R5000_10_CONTINUA();

        }

        [StopWatch]
        /*" R5000-10-CONTINUA */
        private void R5000_10_CONTINUA(bool isPerform = false)
        {
            /*" -601- COMPUTE VL-DESC-IX ROUNDED = (VL-TAR-IX * PCDESCON) / 100. */
            CALCULOS.VL_DESC_IX.Value = (CALCULOS.VL_TAR_IX * CALCULOS.PCDESCON) / 100f;

            /*" -604- COMPUTE VL-LIQ-IX ROUNDED = VL-TAR-IX - VL-DESC-IX. */
            CALCULOS.VL_LIQ_IX.Value = CALCULOS.VL_TAR_IX - CALCULOS.VL_DESC_IX;

            /*" -606- MOVE ZEROS TO VL-CUSTO-IX */
            _.Move(0, CALCULOS.VL_CUSTO_IX);

            /*" -610- COMPUTE VL-IOF-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX. */
            CALCULOS.VL_IOF_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX;

            /*" -614- COMPUTE VL-IOF-IX = (VL-IOF-IX * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = (CALCULOS.VL_IOF_IX * CALCULOS.PCIOF) / 100f;

            /*" -619- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            CALCULOS.VL_TOTAL_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_IOF_IX;

            /*" -622- COMPUTE VL-TARIFA ROUNDED = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -625- COMPUTE VL-DESCONTO ROUNDED = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -628- COMPUTE VL-ADICIONAL ROUNDED = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -631- COMPUTE VL-LIQUIDO = VL-TARIFA - VL-DESCONTO. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_TARIFA - CALCULOS.VL_DESCONTO;

            /*" -633- MOVE ZEROS TO VL-CUSTO */
            _.Move(0, CALCULOS.VL_CUSTO);

            /*" -637- COMPUTE VL-IOF = VL-LIQUIDO + VL-ADICIONAL + VL-CUSTO. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_CUSTO;

            /*" -641- COMPUTE VL-IOF ROUNDED = (VL-IOF * PCIOF) / 100. */
            CALCULOS.VL_IOF.Value = (CALCULOS.VL_IOF * CALCULOS.PCIOF) / 100f;

            /*" -644- COMPUTE VL-TOTAL ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-IOF + VL-CUSTO. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF + CALCULOS.VL_CUSTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A5999_CALCULA_DEMAIS*/

        [StopWatch]
        /*" A6000-LE-CUSTO-SECTION */
        private void A6000_LE_CUSTO_SECTION()
        {
            /*" -682- MOVE 'A6000' TO WNR-EXEC-SQL */
            _.Move("A6000", WABEND.WNR_EXEC_SQL);

            /*" -683- IF VL-BASECUSTO > 0 */

            if (VL_BASECUSTO > 0)
            {

                /*" -685- MOVE VL-BASECUSTO TO CUST-VLINIFAI */
                _.Move(VL_BASECUSTO, CUST_VLINIFAI);

                /*" -689- COMPUTE CUST-VLBASE10 = (CUST-VLINIFAI * 10) / 100 */
                CUST_VLBASE10.Value = (CUST_VLINIFAI * 10) / 100f;

                /*" -690- IF CUST-VLBASE10 > 60 */

                if (CUST_VLBASE10 > 60)
                {

                    /*" -691- MOVE 60 TO CUST-VLCUSTO */
                    _.Move(60, CUST_VLCUSTO);

                    /*" -692- ELSE */
                }
                else
                {


                    /*" -694- MOVE CUST-VLBASE10 TO CUST-VLCUSTO */
                    _.Move(CUST_VLBASE10, CUST_VLCUSTO);

                    /*" -695- ELSE */
                }

            }
            else
            {


                /*" -695- MOVE ZEROS TO CUST-VLCUSTO. */
                _.Move(0, CUST_VLCUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A6999_999_EXIT*/
    }
}