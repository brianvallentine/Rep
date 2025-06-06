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
using Sias.Emissao.DB2.EM0904S;

namespace Code
{
    public class EM0904S
    {
        public bool IsCall { get; set; }

        public EM0904S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *        FUNCAO.............. ROTINA DE CALCULO DE PARCELAS      *      */
        /*"      *                             MULTIRISCO CONDOMINIO -            *      */
        /*"      *                             CONVENIO MINAS BRASIL              *      */
        /*"      *        PROGRAMA............ EM0904S                            *      */
        /*"      *        ANALISTA............ CHICON                             *      */
        /*"      *        PROGRAMADOR......... CHICON                             *      */
        /*"      *        DATA CODIFICACAO.... FEVEREIRO/2005                     *      */
        /*"      *                                                                *      */
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
        /*"77  VL-BASECUSTO-IX             PIC S9(15)V9(2)  COMP-3 VALUE +0*/
        public DoubleBasis VL_BASECUSTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77  VL-PRM-TARIF-BASE           PIC S9(15)V9(2)  COMP-3 VALUE +0*/
        public DoubleBasis VL_PRM_TARIF_BASE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77  VL-DESC-ADIC                PIC S9(15)V9(2)  COMP-3 VALUE +0*/
        public DoubleBasis VL_DESC_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77  VL-DESC-BONUS               PIC S9(15)V9(2)  COMP-3 VALUE +0*/
        public DoubleBasis VL_DESC_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77  VL-DESC-CORRETOR            PIC S9(15)V9(2)  COMP-3 VALUE +0*/
        public DoubleBasis VL_DESC_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77  WS-VALOR-DESC               PIC S9(10)V9(05) COMP-3 VALUE +0*/
        public DoubleBasis WS_VALOR_DESC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"01          WABEND.*/
        public EM0904S_WABEND WABEND { get; set; } = new EM0904S_WABEND();
        public class EM0904S_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' EM0904S  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0904S  ");
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
        public EM0904S_CALCULOS CALCULOS { get; set; } = new EM0904S_CALCULOS();
        public class EM0904S_CALCULOS : VarBasis
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
            public EM0904S_W01A0077 W01A0077 { get; set; } = new EM0904S_W01A0077();
            public class EM0904S_W01A0077 : VarBasis
            {
                /*"      05         W01A0077-LIT           PIC  X(71).*/
                public StringBasis W01A0077_LIT { get; set; } = new StringBasis(new PIC("X", "71", "X(71)."), @"");
                /*"      05         W01A0077-LITR REDEFINES W01A0077-LIT.*/
                private _REDEF_EM0904S_W01A0077_LITR _w01a0077_litr { get; set; }
                public _REDEF_EM0904S_W01A0077_LITR W01A0077_LITR
                {
                    get { _w01a0077_litr = new _REDEF_EM0904S_W01A0077_LITR(); _.Move(W01A0077_LIT, _w01a0077_litr); VarBasis.RedefinePassValue(W01A0077_LIT, _w01a0077_litr, W01A0077_LIT); _w01a0077_litr.ValueChanged += () => { _.Move(_w01a0077_litr, W01A0077_LIT); }; return _w01a0077_litr; }
                    set { VarBasis.RedefinePassValue(value, _w01a0077_litr, W01A0077_LIT); }
                }  //Redefines
                public class _REDEF_EM0904S_W01A0077_LITR : VarBasis
                {
                    /*"       07        W01A0077-VERSAO        PIC  9(03).*/
                    public IntBasis W01A0077_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"       07        FILLER                 PIC  X(68).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "68", "X(68)."), @"");
                    /*"      05         W01A0077-COD           PIC  X(06).*/

                    public _REDEF_EM0904S_W01A0077_LITR()
                    {
                        W01A0077_VERSAO.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W01A0077_COD { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"    03           NRRCAP                 PIC S9(09)       COMP.*/
            }
            public IntBasis NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03           VL-PRM-COBER-ASSIST    PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_PRM_COBER_ASSIST { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03           PCDESCON-ADIC          PIC S9(03)V9(04) COMP-3.*/
            public DoubleBasis PCDESCON_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
            /*"    03           PCDESCON-BONUS         PIC S9(03)V9(04) COMP-3.*/
            public DoubleBasis PCDESCON_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        }


        public EM0904S_V1MOEDA V1MOEDA { get; set; } = new EM0904S_V1MOEDA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0904S_CALCULOS EM0904S_CALCULOS_P) //PROCEDURE DIVISION USING 
        /*CALCULOS*/
        {
            try
            {
                this.CALCULOS = EM0904S_CALCULOS_P;

                /*" -132-  Removido na conversão: EXIT. */

                /*" -132- FLUXCONTROL_PERFORM M-0000-ROTINA-PRINCIPAL-SECTION */

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
            /*" -139- PERFORM A1000-INICIO */

            A1000_INICIO_SECTION();

            /*" -151- PERFORM A2000-LE-MOEDA */

            A2000_LE_MOEDA_SECTION();

            /*" -152- IF NRPARCEL EQUAL 0 */

            if (CALCULOS.NRPARCEL == 0)
            {

                /*" -153- PERFORM A3000-CALCULA-UNICO */

                A3000_CALCULA_UNICO_SECTION();

                /*" -154- ELSE */
            }
            else
            {


                /*" -155- IF NRPARCEL EQUAL 1 */

                if (CALCULOS.NRPARCEL == 1)
                {

                    /*" -156- PERFORM A4000-PRIMEIRA-PARCELA */

                    A4000_PRIMEIRA_PARCELA_SECTION();

                    /*" -157- ELSE */
                }
                else
                {


                    /*" -159- PERFORM A5000-CALCULA-DEMAIS. */

                    A5000_CALCULA_DEMAIS_SECTION();
                }

            }


            /*" -161- MOVE SPACES TO W01A0077. */
            _.Move("", CALCULOS.W01A0077);

            /*" -162- IF MOED-TIPO-MOEDA EQUAL '0' */

            if (MOED_TIPO_MOEDA == "0")
            {

                /*" -163- MOVE VL-TARIFA TO VL-TAR-IX */
                _.Move(CALCULOS.VL_TARIFA, CALCULOS.VL_TAR_IX);

                /*" -164- MOVE VL-DESCONTO TO VL-DESC-IX */
                _.Move(CALCULOS.VL_DESCONTO, CALCULOS.VL_DESC_IX);

                /*" -165- MOVE VL-LIQUIDO TO VL-LIQ-IX */
                _.Move(CALCULOS.VL_LIQUIDO, CALCULOS.VL_LIQ_IX);

                /*" -166- MOVE VL-ADICIONAL TO VL-ADIC-IX */
                _.Move(CALCULOS.VL_ADICIONAL, CALCULOS.VL_ADIC_IX);

                /*" -167- MOVE VL-CUSTO TO VL-CUSTO-IX */
                _.Move(CALCULOS.VL_CUSTO, CALCULOS.VL_CUSTO_IX);

                /*" -168- MOVE VL-IOF TO VL-IOF-IX */
                _.Move(CALCULOS.VL_IOF, CALCULOS.VL_IOF_IX);

                /*" -170- MOVE VL-TOTAL TO VL-TOTAL-IX. */
                _.Move(CALCULOS.VL_TOTAL, CALCULOS.VL_TOTAL_IX);
            }


            /*" -170- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_999_EXIT*/

        [StopWatch]
        /*" A1000-INICIO-SECTION */
        private void A1000_INICIO_SECTION()
        {
            /*" -176- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -178- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -180- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -185- MOVE ZEROS TO VL-PRM-TARIF-BASE VL-DESC-ADIC VL-DESC-BONUS VL-DESC-CORRETOR. */
            _.Move(0, VL_PRM_TARIF_BASE, VL_DESC_ADIC, VL_DESC_BONUS, VL_DESC_CORRETOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1000_999_EXIT*/

        [StopWatch]
        /*" A2000-LE-MOEDA-SECTION */
        private void A2000_LE_MOEDA_SECTION()
        {
            /*" -193- MOVE 'A2000' TO WNR-EXEC-SQL */
            _.Move("A2000", WABEND.WNR_EXEC_SQL);

            /*" -194- MOVE COD-MOEDA TO MOED-COD-MOEDA */
            _.Move(CALCULOS.COD_MOEDA, MOED_COD_MOEDA);

            /*" -196- MOVE DTINIVIG-LK TO MOED-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, MOED_DTINIVIG);

            /*" -204- PERFORM A2000_LE_MOEDA_DB_DECLARE_1 */

            A2000_LE_MOEDA_DB_DECLARE_1();

            /*" -207- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -209- MOVE ' ERRO ACESSO V1MOEDA 1' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA 1", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -211- MOVE SQLCODE TO W01A0077-COD */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_COD);

                /*" -213- GOBACK. */

                throw new GoBack();
            }


            /*" -213- PERFORM A2000_LE_MOEDA_DB_OPEN_1 */

            A2000_LE_MOEDA_DB_OPEN_1();

            /*" -216- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -218- MOVE ' ERRO ACESSO V1MOEDA 2' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA 2", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -220- MOVE SQLCODE TO W01A0077-COD */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_COD);

                /*" -222- GOBACK. */

                throw new GoBack();
            }


            /*" -225- PERFORM A2000_LE_MOEDA_DB_FETCH_1 */

            A2000_LE_MOEDA_DB_FETCH_1();

            /*" -228- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -230- MOVE 'MOEDA SEM COTACAO/INDISPONIVEL' TO W01A0077 */
                _.Move("MOEDA SEM COTACAO/INDISPONIVEL", CALCULOS.W01A0077);

                /*" -232- GOBACK. */

                throw new GoBack();
            }


            /*" -233- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -235- MOVE ' ERRO ACESSO V1MOEDA' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -237- MOVE SQLCODE TO W01A0077-COD */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_COD);

                /*" -239- GOBACK. */

                throw new GoBack();
            }


            /*" -239- PERFORM A2000_LE_MOEDA_DB_CLOSE_1 */

            A2000_LE_MOEDA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-DECLARE-1 */
        public void A2000_LE_MOEDA_DB_DECLARE_1()
        {
            /*" -204- EXEC SQL DECLARE V1MOEDA CURSOR FOR SELECT VLCRUZAD, TIPO_MOEDA FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :MOED-COD-MOEDA AND DTINIVIG <= :MOED-DTINIVIG AND DTTERVIG >= :MOED-DTINIVIG AND SITUACAO = '0' END-EXEC. */
            V1MOEDA = new EM0904S_V1MOEDA(true);
            string GetQuery_V1MOEDA()
            {
                var query = @$"SELECT 
							VLCRUZAD
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
            /*" -213- EXEC SQL OPEN V1MOEDA END-EXEC. */

            V1MOEDA.Open();

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-FETCH-1 */
        public void A2000_LE_MOEDA_DB_FETCH_1()
        {
            /*" -225- EXEC SQL FETCH V1MOEDA INTO :MOED-VALOR, :MOED-TIPO-MOEDA END-EXEC. */

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
            /*" -239- EXEC SQL CLOSE V1MOEDA END-EXEC. */

            V1MOEDA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A2999_999_EXIT*/

        [StopWatch]
        /*" A3000-CALCULA-UNICO-SECTION */
        private void A3000_CALCULA_UNICO_SECTION()
        {
            /*" -246- MOVE VL-TARIFA TO VL-TAR-IX. */
            _.Move(CALCULOS.VL_TARIFA, CALCULOS.VL_TAR_IX);

            /*" -247- MOVE VL-DESCONTO TO VL-DESC-IX. */
            _.Move(CALCULOS.VL_DESCONTO, CALCULOS.VL_DESC_IX);

            /*" -248- MOVE VL-LIQUIDO TO VL-LIQ-IX. */
            _.Move(CALCULOS.VL_LIQUIDO, CALCULOS.VL_LIQ_IX);

            /*" -249- MOVE VL-ADICIONAL TO VL-ADIC-IX. */
            _.Move(CALCULOS.VL_ADICIONAL, CALCULOS.VL_ADIC_IX);

            /*" -250- MOVE VL-CUSTO TO VL-CUSTO-IX. */
            _.Move(CALCULOS.VL_CUSTO, CALCULOS.VL_CUSTO_IX);

            /*" -251- MOVE VL-IOF TO VL-IOF-IX. */
            _.Move(CALCULOS.VL_IOF, CALCULOS.VL_IOF_IX);

            /*" -252- MOVE VL-TOTAL TO VL-TOTAL-IX. */
            _.Move(CALCULOS.VL_TOTAL, CALCULOS.VL_TOTAL_IX);

            /*" -254- MOVE VL-PREMIO-BASE TO VL-TAR-IX. */
            _.Move(CALCULOS.VL_PREMIO_BASE, CALCULOS.VL_TAR_IX);

            /*" -257- COMPUTE VL-PRM-TARIF-BASE = VL-PREMIO-BASE - VL-PRM-COBER-ASSIST. */
            VL_PRM_TARIF_BASE.Value = CALCULOS.VL_PREMIO_BASE - CALCULOS.VL_PRM_COBER_ASSIST;

            /*" -258- IF PCDESCON-ADIC GREATER ZEROS */

            if (CALCULOS.PCDESCON_ADIC > 00)
            {

                /*" -262- COMPUTE VL-DESC-ADIC ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON-ADIC) / 100 */
                VL_DESC_ADIC.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON_ADIC) / 100f;

                /*" -265- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-ADIC. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_ADIC;
            }


            /*" -266- IF PCDESCON-BONUS GREATER ZEROS */

            if (CALCULOS.PCDESCON_BONUS > 00)
            {

                /*" -270- COMPUTE VL-DESC-BONUS ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON-BONUS) / 100 */
                VL_DESC_BONUS.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON_BONUS) / 100f;

                /*" -273- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-BONUS. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_BONUS;
            }


            /*" -274- IF PCDESCON GREATER ZEROS */

            if (CALCULOS.PCDESCON > 00)
            {

                /*" -278- COMPUTE VL-DESC-CORRETOR ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON) / 100 */
                VL_DESC_CORRETOR.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON) / 100f;

                /*" -281- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-CORRETOR. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_CORRETOR;
            }


            /*" -285- COMPUTE VL-DESC-IX = VL-DESC-ADIC + VL-DESC-BONUS + VL-DESC-CORRETOR. */
            CALCULOS.VL_DESC_IX.Value = VL_DESC_ADIC + VL_DESC_BONUS + VL_DESC_CORRETOR;

            /*" -293- COMPUTE VL-LIQ-IX = VL-PRM-TARIF-BASE + VL-PRM-COBER-ASSIST. */
            CALCULOS.VL_LIQ_IX.Value = VL_PRM_TARIF_BASE + CALCULOS.VL_PRM_COBER_ASSIST;

            /*" -299- COMPUTE VL-IOF-IX = ((VL-LIQ-IX + VL-CUSTO-IX + VL-ADIC-IX) * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = ((CALCULOS.VL_LIQ_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_ADIC_IX) * CALCULOS.PCIOF) / 100f;

            /*" -304- COMPUTE VL-TOTAL-IX = (VL-LIQ-IX + VL-CUSTO-IX + VL-ADIC-IX + VL-IOF-IX). */
            CALCULOS.VL_TOTAL_IX.Value = (CALCULOS.VL_LIQ_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_IOF_IX);

            /*" -307- COMPUTE VL-TARIFA = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -310- COMPUTE VL-DESCONTO = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -313- COMPUTE VL-ADICIONAL = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -316- COMPUTE VL-LIQUIDO = VL-LIQ-IX * MOED-VALOR. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_LIQ_IX * MOED_VALOR;

            /*" -319- COMPUTE VL-IOF = VL-IOF-IX * MOED-VALOR. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_IOF_IX * MOED_VALOR;

            /*" -320- COMPUTE VL-TOTAL = VL-TOTAL-IX * MOED-VALOR. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_TOTAL_IX * MOED_VALOR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_CALCULA_UNICO*/

        [StopWatch]
        /*" A4000-PRIMEIRA-PARCELA-SECTION */
        private void A4000_PRIMEIRA_PARCELA_SECTION()
        {
            /*" -327- MOVE VL-TARIFA TO VL-TAR-IX. */
            _.Move(CALCULOS.VL_TARIFA, CALCULOS.VL_TAR_IX);

            /*" -328- MOVE VL-DESCONTO TO VL-DESC-IX. */
            _.Move(CALCULOS.VL_DESCONTO, CALCULOS.VL_DESC_IX);

            /*" -329- MOVE VL-LIQUIDO TO VL-LIQ-IX. */
            _.Move(CALCULOS.VL_LIQUIDO, CALCULOS.VL_LIQ_IX);

            /*" -330- MOVE VL-ADICIONAL TO VL-ADIC-IX. */
            _.Move(CALCULOS.VL_ADICIONAL, CALCULOS.VL_ADIC_IX);

            /*" -331- MOVE VL-CUSTO TO VL-CUSTO-IX. */
            _.Move(CALCULOS.VL_CUSTO, CALCULOS.VL_CUSTO_IX);

            /*" -332- MOVE VL-IOF TO VL-IOF-IX. */
            _.Move(CALCULOS.VL_IOF, CALCULOS.VL_IOF_IX);

            /*" -334- MOVE VL-TOTAL TO VL-TOTAL-IX. */
            _.Move(CALCULOS.VL_TOTAL, CALCULOS.VL_TOTAL_IX);

            /*" -337- COMPUTE VL-PRM-TARIF-BASE = VL-PREMIO-BASE - VL-PRM-COBER-ASSIST. */
            VL_PRM_TARIF_BASE.Value = CALCULOS.VL_PREMIO_BASE - CALCULOS.VL_PRM_COBER_ASSIST;

            /*" -338- IF PCDESCON-ADIC GREATER ZEROS */

            if (CALCULOS.PCDESCON_ADIC > 00)
            {

                /*" -342- COMPUTE VL-DESC-ADIC ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON-ADIC) / 100 */
                VL_DESC_ADIC.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON_ADIC) / 100f;

                /*" -345- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-ADIC. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_ADIC;
            }


            /*" -346- IF PCDESCON-BONUS GREATER ZEROS */

            if (CALCULOS.PCDESCON_BONUS > 00)
            {

                /*" -350- COMPUTE VL-DESC-BONUS ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON-BONUS) / 100 */
                VL_DESC_BONUS.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON_BONUS) / 100f;

                /*" -353- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-BONUS. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_BONUS;
            }


            /*" -354- IF PCDESCON GREATER ZEROS */

            if (CALCULOS.PCDESCON > 00)
            {

                /*" -358- COMPUTE VL-DESC-CORRETOR ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON) / 100 */
                VL_DESC_CORRETOR.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON) / 100f;

                /*" -361- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-CORRETOR. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_CORRETOR;
            }


            /*" -365- COMPUTE VL-DESC-IX = VL-DESC-ADIC + VL-DESC-BONUS + VL-DESC-CORRETOR. */
            CALCULOS.VL_DESC_IX.Value = VL_DESC_ADIC + VL_DESC_BONUS + VL_DESC_CORRETOR;

            /*" -369- COMPUTE VL-LIQ-IX = (VL-PRM-TARIF-BASE + VL-PRM-COBER-ASSIST) / QTPARCEL. */
            CALCULOS.VL_LIQ_IX.Value = (VL_PRM_TARIF_BASE + CALCULOS.VL_PRM_COBER_ASSIST) / CALCULOS.QTPARCEL;

            /*" -377- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / QTPARCEL. */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / CALCULOS.QTPARCEL;

            /*" -380- COMPUTE VL-ADIC-IX = VL-ADICIONAL / QTPARCEL. */
            CALCULOS.VL_ADIC_IX.Value = CALCULOS.VL_ADICIONAL / CALCULOS.QTPARCEL;

            /*" -383- COMPUTE VL-DESC-IX = VL-DESC-IX / QTPARCEL. */
            CALCULOS.VL_DESC_IX.Value = CALCULOS.VL_DESC_IX / CALCULOS.QTPARCEL;

            /*" -389- COMPUTE VL-IOF-IX = ((VL-LIQ-IX + VL-CUSTO-IX + VL-ADIC-IX) * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = ((CALCULOS.VL_LIQ_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_ADIC_IX) * CALCULOS.PCIOF) / 100f;

            /*" -394- COMPUTE VL-TOTAL-IX = (VL-LIQ-IX + VL-CUSTO-IX + VL-ADIC-IX + VL-IOF-IX). */
            CALCULOS.VL_TOTAL_IX.Value = (CALCULOS.VL_LIQ_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_IOF_IX);

            /*" -397- COMPUTE VL-TARIFA = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -400- COMPUTE VL-DESCONTO = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -403- COMPUTE VL-ADICIONAL = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -406- COMPUTE VL-LIQUIDO = VL-LIQ-IX * MOED-VALOR. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_LIQ_IX * MOED_VALOR;

            /*" -409- COMPUTE VL-IOF = VL-IOF-IX * MOED-VALOR. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_IOF_IX * MOED_VALOR;

            /*" -410- COMPUTE VL-TOTAL = VL-TOTAL-IX * MOED-VALOR. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_TOTAL_IX * MOED_VALOR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4999_PRIMEIRA_PARCELA*/

        [StopWatch]
        /*" A5000-CALCULA-DEMAIS-SECTION */
        private void A5000_CALCULA_DEMAIS_SECTION()
        {
            /*" -418- MOVE VL-TARIFA TO VL-TAR-IX. */
            _.Move(CALCULOS.VL_TARIFA, CALCULOS.VL_TAR_IX);

            /*" -419- MOVE VL-DESCONTO TO VL-DESC-IX. */
            _.Move(CALCULOS.VL_DESCONTO, CALCULOS.VL_DESC_IX);

            /*" -420- MOVE VL-LIQUIDO TO VL-LIQ-IX. */
            _.Move(CALCULOS.VL_LIQUIDO, CALCULOS.VL_LIQ_IX);

            /*" -421- MOVE VL-ADICIONAL TO VL-ADIC-IX. */
            _.Move(CALCULOS.VL_ADICIONAL, CALCULOS.VL_ADIC_IX);

            /*" -423- MOVE ZEROS TO VL-CUSTO VL-CUSTO-IX. */
            _.Move(0, CALCULOS.VL_CUSTO, CALCULOS.VL_CUSTO_IX);

            /*" -424- MOVE VL-IOF TO VL-IOF-IX. */
            _.Move(CALCULOS.VL_IOF, CALCULOS.VL_IOF_IX);

            /*" -426- MOVE VL-TOTAL TO VL-TOTAL-IX. */
            _.Move(CALCULOS.VL_TOTAL, CALCULOS.VL_TOTAL_IX);

            /*" -429- COMPUTE VL-PRM-TARIF-BASE = VL-PREMIO-BASE - VL-PRM-COBER-ASSIST. */
            VL_PRM_TARIF_BASE.Value = CALCULOS.VL_PREMIO_BASE - CALCULOS.VL_PRM_COBER_ASSIST;

            /*" -430- IF PCDESCON-ADIC GREATER ZEROS */

            if (CALCULOS.PCDESCON_ADIC > 00)
            {

                /*" -434- COMPUTE VL-DESC-ADIC ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON-ADIC) / 100 */
                VL_DESC_ADIC.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON_ADIC) / 100f;

                /*" -437- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-ADIC. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_ADIC;
            }


            /*" -438- IF PCDESCON-BONUS GREATER ZEROS */

            if (CALCULOS.PCDESCON_BONUS > 00)
            {

                /*" -442- COMPUTE VL-DESC-BONUS ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON-BONUS) / 100 */
                VL_DESC_BONUS.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON_BONUS) / 100f;

                /*" -445- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-BONUS. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_BONUS;
            }


            /*" -446- IF PCDESCON GREATER ZEROS */

            if (CALCULOS.PCDESCON > 00)
            {

                /*" -450- COMPUTE VL-DESC-CORRETOR ROUNDED = (VL-PRM-TARIF-BASE * PCDESCON) / 100 */
                VL_DESC_CORRETOR.Value = (VL_PRM_TARIF_BASE * CALCULOS.PCDESCON) / 100f;

                /*" -453- COMPUTE VL-PRM-TARIF-BASE = VL-PRM-TARIF-BASE - VL-DESC-CORRETOR. */
                VL_PRM_TARIF_BASE.Value = VL_PRM_TARIF_BASE - VL_DESC_CORRETOR;
            }


            /*" -457- COMPUTE VL-DESC-IX = VL-DESC-ADIC + VL-DESC-BONUS + VL-DESC-CORRETOR. */
            CALCULOS.VL_DESC_IX.Value = VL_DESC_ADIC + VL_DESC_BONUS + VL_DESC_CORRETOR;

            /*" -461- COMPUTE VL-LIQ-IX = (VL-PRM-TARIF-BASE + VL-PRM-COBER-ASSIST) / QTPARCEL. */
            CALCULOS.VL_LIQ_IX.Value = (VL_PRM_TARIF_BASE + CALCULOS.VL_PRM_COBER_ASSIST) / CALCULOS.QTPARCEL;

            /*" -469- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / QTPARCEL. */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / CALCULOS.QTPARCEL;

            /*" -472- COMPUTE VL-ADIC-IX = VL-ADICIONAL / QTPARCEL. */
            CALCULOS.VL_ADIC_IX.Value = CALCULOS.VL_ADICIONAL / CALCULOS.QTPARCEL;

            /*" -475- COMPUTE VL-DESC-IX = VL-DESC-IX / QTPARCEL. */
            CALCULOS.VL_DESC_IX.Value = CALCULOS.VL_DESC_IX / CALCULOS.QTPARCEL;

            /*" -480- COMPUTE VL-IOF-IX = ((VL-LIQ-IX + VL-ADIC-IX) * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = ((CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX) * CALCULOS.PCIOF) / 100f;

            /*" -484- COMPUTE VL-TOTAL-IX = (VL-LIQ-IX + VL-ADIC-IX + VL-IOF-IX). */
            CALCULOS.VL_TOTAL_IX.Value = (CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_IOF_IX);

            /*" -487- COMPUTE VL-TARIFA = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -490- COMPUTE VL-DESCONTO = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -493- COMPUTE VL-ADICIONAL = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -496- COMPUTE VL-LIQUIDO = VL-LIQ-IX * MOED-VALOR. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_LIQ_IX * MOED_VALOR;

            /*" -499- COMPUTE VL-IOF = VL-IOF-IX * MOED-VALOR. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_IOF_IX * MOED_VALOR;

            /*" -500- COMPUTE VL-TOTAL = VL-TOTAL-IX * MOED-VALOR. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_TOTAL_IX * MOED_VALOR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A5999_CALCULA_DEMAIS*/
    }
}