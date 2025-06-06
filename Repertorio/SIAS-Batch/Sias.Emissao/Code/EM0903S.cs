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
using Sias.Emissao.DB2.EM0903S;

namespace Code
{
    public class EM0903S
    {
        public bool IsCall { get; set; }

        public EM0903S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *        FUNCAO.............. ROTINA DE CALCULO DE PARCELAS      *      */
        /*"      *        PROGRAMA............ EM0903S                            *      */
        /*"      *        ANALISTA............ PROCAS                             *      */
        /*"      *        PROGRAMADOR......... PROCAS/ALEX                        *      */
        /*"      *        DATA CODIFICACAO.... SETEMBRO/91                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *               A L T E R A C A O                                *      */
        /*"      ******************************************************************      */
        /*"      *        CUSTO DE APOLICE DE R$ 60,00                            *      */
        /*"V.02  ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   AUTO FACIL - DEZEMBRO/2012  - CADMUS 74582                   *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE V.02         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"BRSEG2*   VERSAO 02 - CAD 23614 - BRSEG - SAC 586 - 29/04/2009         *      */
        /*"BRSEG2*       NAO FORCAR CUSTO PARA ENDOSSOS RESTITUICAO E SEM MOVTO   *      */
        /*"      *                                                                *      */
        /*"      *   CAD 16427 - GEFAB                                            *      */
        /*"      *        CUSTO DE APOLICE DE R$ 35,00                            *      */
        /*"      *                                           PROCURE V.01         *      */
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
        /*"77  VL-BASECUSTO-IX             PIC S9(10)V9(5)  COMP-3 VALUE +0*/
        public DoubleBasis VL_BASECUSTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  WS-VALOR-DESC               PIC S9(10)V9(05) COMP-3 VALUE +0*/
        public DoubleBasis WS_VALOR_DESC { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  VLR-PRM-TOTAL               PIC S9(10)V9(02) COMP-3 VALUE +0*/
        public DoubleBasis VLR_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"77  VLR-PRM-TOTP                PIC S9(10)V9(02) COMP-3 VALUE +0*/
        public DoubleBasis VLR_PRM_TOTP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"77  VLR-PRM-LIQP                PIC S9(10)V9(02) COMP-3 VALUE +0*/
        public DoubleBasis VLR_PRM_LIQP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"77  VLR-IOFP                    PIC S9(10)V9(02) COMP-3 VALUE +0*/
        public DoubleBasis VLR_IOFP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(02)"), 2);
        /*"77  PC-IOF                      PIC S9(03)V9(05) COMP-3 VALUE +0*/
        public DoubleBasis PC_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(05)"), 5);
        /*"77  WDISP-VALOR                 PIC Z.ZZ9,99999-.*/
        public DoubleBasis WDISP_VALOR { get; set; } = new DoubleBasis(new PIC("9", "4", "Z.ZZ9V99999-."), 6);
        /*"01          WABEND.*/
        public EM0903S_WABEND WABEND { get; set; } = new EM0903S_WABEND();
        public class EM0903S_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' EM0903S  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0903S  ");
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
        public EM0903S_CALCULOS CALCULOS { get; set; } = new EM0903S_CALCULOS();
        public class EM0903S_CALCULOS : VarBasis
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
            public EM0903S_W01A0077 W01A0077 { get; set; } = new EM0903S_W01A0077();
            public class EM0903S_W01A0077 : VarBasis
            {
                /*"      05         W01A0077-LIT           PIC  X(77).*/
                public StringBasis W01A0077_LIT { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
                /*"      05         W01A0077-LITR REDEFINES W01A0077-LIT.*/
                private _REDEF_EM0903S_W01A0077_LITR _w01a0077_litr { get; set; }
                public _REDEF_EM0903S_W01A0077_LITR W01A0077_LITR
                {
                    get { _w01a0077_litr = new _REDEF_EM0903S_W01A0077_LITR(); _.Move(W01A0077_LIT, _w01a0077_litr); VarBasis.RedefinePassValue(W01A0077_LIT, _w01a0077_litr, W01A0077_LIT); _w01a0077_litr.ValueChanged += () => { _.Move(_w01a0077_litr, W01A0077_LIT); }; return _w01a0077_litr; }
                    set { VarBasis.RedefinePassValue(value, _w01a0077_litr, W01A0077_LIT); }
                }  //Redefines
                public class _REDEF_EM0903S_W01A0077_LITR : VarBasis
                {
                    /*"       07        FILLER                 PIC  X(06).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                    /*"       07        W01A0077-VERSAO        PIC  9(03).*/
                    public IntBasis W01A0077_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"       07        W01A0077-TIPCOB        PIC  9(01).*/
                    public IntBasis W01A0077_TIPCOB { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                    /*"       07        W01A0077-QTPARC        PIC  9(02).*/
                    public IntBasis W01A0077_QTPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"       07        W01A0077-CODPRO        PIC  9(04).*/
                    public IntBasis W01A0077_CODPRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"       07        W01A0077-INIVIG        PIC  X(10).*/
                    public StringBasis W01A0077_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       07        FILLER                 PIC  X(45).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)."), @"");
                    /*"       07        W01A0077-CODSQL        PIC  9(06).*/
                    public IntBasis W01A0077_CODSQL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"    03           NRRCAP                 PIC S9(09)       COMP.*/

                    public _REDEF_EM0903S_W01A0077_LITR()
                    {
                        FILLER_3.ValueChanged += OnValueChanged;
                        W01A0077_VERSAO.ValueChanged += OnValueChanged;
                        W01A0077_TIPCOB.ValueChanged += OnValueChanged;
                        W01A0077_QTPARC.ValueChanged += OnValueChanged;
                        W01A0077_CODPRO.ValueChanged += OnValueChanged;
                        W01A0077_INIVIG.ValueChanged += OnValueChanged;
                        FILLER_4.ValueChanged += OnValueChanged;
                        W01A0077_CODSQL.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03           VL-COBER-ASSIST        PIC S9(15)V99    COMP-3.*/
            public DoubleBasis VL_COBER_ASSIST { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"    03           PCDESCON-ADIC          PIC S9(03)V9999  COMP-3.*/
            public DoubleBasis PCDESCON_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
            /*"    03           PCDESCON-BONUS         PIC S9(03)V9999  COMP-3.*/
            public DoubleBasis PCDESCON_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        }


        public Dclgens.AU080 AU080 { get; set; } = new Dclgens.AU080();
        public EM0903S_V1MOEDA V1MOEDA { get; set; } = new EM0903S_V1MOEDA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0903S_CALCULOS EM0903S_CALCULOS_P) //PROCEDURE DIVISION USING 
        /*CALCULOS*/
        {
            try
            {
                this.CALCULOS = EM0903S_CALCULOS_P;

                /*" -158-  Removido na conversão: EXIT. */

                /*" -158- FLUXCONTROL_PERFORM M-0000-ROTINA-PRINCIPAL-SECTION */

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
            /*" -165- PERFORM A1000-INICIO */

            A1000_INICIO_SECTION();

            /*" -167- PERFORM A2000-LE-MOEDA */

            A2000_LE_MOEDA_SECTION();

            /*" -169- IF ((RAMO EQUAL 53) AND (W01A0077-CODPRO EQUAL 5302 OR 5303 OR 5304)) */

            if (((CALCULOS.RAMO == 53) && (CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODPRO.In("5302", "5303", "5304"))))
            {

                /*" -170- PERFORM R6000-00-PARCELA-AUTO-FACIL */

                R6000_00_PARCELA_AUTO_FACIL_SECTION();

                /*" -171- ELSE */
            }
            else
            {


                /*" -172- IF NRPARCEL EQUAL 0 */

                if (CALCULOS.NRPARCEL == 0)
                {

                    /*" -173- PERFORM A3000-CALCULA-UNICO */

                    A3000_CALCULA_UNICO_SECTION();

                    /*" -174- ELSE */
                }
                else
                {


                    /*" -175- IF NRPARCEL EQUAL 1 */

                    if (CALCULOS.NRPARCEL == 1)
                    {

                        /*" -176- PERFORM A4000-PRIMEIRA-PARCELA */

                        A4000_PRIMEIRA_PARCELA_SECTION();

                        /*" -177- ELSE */
                    }
                    else
                    {


                        /*" -180- PERFORM A5000-CALCULA-DEMAIS. */

                        A5000_CALCULA_DEMAIS_SECTION();
                    }

                }

            }


            /*" -181- IF MOED-TIPO-MOEDA EQUAL '0' */

            if (MOED_TIPO_MOEDA == "0")
            {

                /*" -182- MOVE VL-TARIFA TO VL-TAR-IX */
                _.Move(CALCULOS.VL_TARIFA, CALCULOS.VL_TAR_IX);

                /*" -183- MOVE VL-DESCONTO TO VL-DESC-IX */
                _.Move(CALCULOS.VL_DESCONTO, CALCULOS.VL_DESC_IX);

                /*" -184- MOVE VL-LIQUIDO TO VL-LIQ-IX */
                _.Move(CALCULOS.VL_LIQUIDO, CALCULOS.VL_LIQ_IX);

                /*" -185- MOVE VL-ADICIONAL TO VL-ADIC-IX */
                _.Move(CALCULOS.VL_ADICIONAL, CALCULOS.VL_ADIC_IX);

                /*" -186- MOVE VL-CUSTO TO VL-CUSTO-IX */
                _.Move(CALCULOS.VL_CUSTO, CALCULOS.VL_CUSTO_IX);

                /*" -187- MOVE VL-IOF TO VL-IOF-IX */
                _.Move(CALCULOS.VL_IOF, CALCULOS.VL_IOF_IX);

                /*" -189- MOVE VL-TOTAL TO VL-TOTAL-IX. */
                _.Move(CALCULOS.VL_TOTAL, CALCULOS.VL_TOTAL_IX);
            }


            /*" -191- MOVE SPACES TO W01A0077. */
            _.Move("", CALCULOS.W01A0077);

            /*" -191- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_999_EXIT*/

        [StopWatch]
        /*" A1000-INICIO-SECTION */
        private void A1000_INICIO_SECTION()
        {
            /*" -198- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -200- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -202- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1000_999_EXIT*/

        [StopWatch]
        /*" A2000-LE-MOEDA-SECTION */
        private void A2000_LE_MOEDA_SECTION()
        {
            /*" -209- MOVE 'A2000' TO WNR-EXEC-SQL */
            _.Move("A2000", WABEND.WNR_EXEC_SQL);

            /*" -210- MOVE COD-MOEDA TO MOED-COD-MOEDA */
            _.Move(CALCULOS.COD_MOEDA, MOED_COD_MOEDA);

            /*" -212- MOVE DTINIVIG-LK TO MOED-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, MOED_DTINIVIG);

            /*" -220- PERFORM A2000_LE_MOEDA_DB_DECLARE_1 */

            A2000_LE_MOEDA_DB_DECLARE_1();

            /*" -223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -225- MOVE ' ERRO ACESSO V1MOEDA 1' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA 1", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -227- MOVE SQLCODE TO W01A0077-CODSQL */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODSQL);

                /*" -229- GOBACK. */

                throw new GoBack();
            }


            /*" -229- PERFORM A2000_LE_MOEDA_DB_OPEN_1 */

            A2000_LE_MOEDA_DB_OPEN_1();

            /*" -232- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -234- MOVE ' ERRO ACESSO V1MOEDA 2' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA 2", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -236- MOVE SQLCODE TO W01A0077-CODSQL */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODSQL);

                /*" -238- GOBACK. */

                throw new GoBack();
            }


            /*" -241- PERFORM A2000_LE_MOEDA_DB_FETCH_1 */

            A2000_LE_MOEDA_DB_FETCH_1();

            /*" -244- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -246- MOVE 'MOEDA SEM COTACAO/INDISPONIVEL' TO W01A0077 */
                _.Move("MOEDA SEM COTACAO/INDISPONIVEL", CALCULOS.W01A0077);

                /*" -248- GOBACK. */

                throw new GoBack();
            }


            /*" -249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -251- MOVE ' ERRO ACESSO V1MOEDA' TO W01A0077-LIT */
                _.Move(" ERRO ACESSO V1MOEDA", CALCULOS.W01A0077.W01A0077_LIT);

                /*" -253- MOVE SQLCODE TO W01A0077-CODSQL */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODSQL);

                /*" -255- GOBACK. */

                throw new GoBack();
            }


            /*" -255- PERFORM A2000_LE_MOEDA_DB_CLOSE_1 */

            A2000_LE_MOEDA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-DECLARE-1 */
        public void A2000_LE_MOEDA_DB_DECLARE_1()
        {
            /*" -220- EXEC SQL DECLARE V1MOEDA CURSOR FOR SELECT VLCRUZAD, TIPO_MOEDA FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :MOED-COD-MOEDA AND DTINIVIG <= :MOED-DTINIVIG AND DTTERVIG >= :MOED-DTINIVIG AND SITUACAO = '0' END-EXEC. */
            V1MOEDA = new EM0903S_V1MOEDA(true);
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
            /*" -229- EXEC SQL OPEN V1MOEDA END-EXEC. */

            V1MOEDA.Open();

        }

        [StopWatch]
        /*" A2000-LE-MOEDA-DB-FETCH-1 */
        public void A2000_LE_MOEDA_DB_FETCH_1()
        {
            /*" -241- EXEC SQL FETCH V1MOEDA INTO :MOED-VALOR, :MOED-TIPO-MOEDA END-EXEC. */

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
            /*" -255- EXEC SQL CLOSE V1MOEDA END-EXEC. */

            V1MOEDA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A2999_999_EXIT*/

        [StopWatch]
        /*" A3000-CALCULA-UNICO-SECTION */
        private void A3000_CALCULA_UNICO_SECTION()
        {
            /*" -264- MOVE ZEROS TO FRAC-INDPRLIQ FRAC-INDADIC */
            _.Move(0, FRAC_INDPRLIQ, FRAC_INDADIC);

            /*" -265- IF PCJUROS NOT EQUAL ZEROS */

            if (CALCULOS.PCJUROS != 00)
            {

                /*" -266- PERFORM A4200-FRACIONA-OUTROS */

                A4200_FRACIONA_OUTROS_SECTION();

                /*" -268- GO TO A3000-10-CONTINUA. */

                A3000_10_CONTINUA(); //GOTO
                return;
            }


            /*" -268- MOVE VL-PREMIO-BASE TO VL-TAR-IX. */
            _.Move(CALCULOS.VL_PREMIO_BASE, CALCULOS.VL_TAR_IX);

            /*" -0- FLUXCONTROL_PERFORM A3000_10_CONTINUA */

            A3000_10_CONTINUA();

        }

        [StopWatch]
        /*" A3000-10-CONTINUA */
        private void A3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -277- COMPUTE VL-DESC-IX ROUNDED = (VL-TAR-IX * PCDESCON) / 100. */
            CALCULOS.VL_DESC_IX.Value = (CALCULOS.VL_TAR_IX * CALCULOS.PCDESCON) / 100f;

            /*" -282- COMPUTE VL-LIQ-IX ROUNDED = VL-TAR-IX - VL-DESC-IX. */
            CALCULOS.VL_LIQ_IX.Value = CALCULOS.VL_TAR_IX - CALCULOS.VL_DESC_IX;

            /*" -285- COMPUTE VL-TARIFA ROUNDED = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -288- COMPUTE VL-DESCONTO ROUNDED = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -303- COMPUTE VL-LIQUIDO = VL-TARIFA - VL-DESCONTO. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_TARIFA - CALCULOS.VL_DESCONTO;

            /*" -304- IF ISENTA-CUSTO EQUAL 'S' */

            if (CALCULOS.ISENTA_CUSTO == "S")
            {

                /*" -305- MOVE ZEROS TO VL-CUSTO */
                _.Move(0, CALCULOS.VL_CUSTO);

                /*" -306- ELSE */
            }
            else
            {


                /*" -307- IF VL-LIQUIDO NOT GREATER ZEROS */

                if (CALCULOS.VL_LIQUIDO <= 00)
                {

                    /*" -308- MOVE ZEROS TO VL-CUSTO */
                    _.Move(0, CALCULOS.VL_CUSTO);

                    /*" -309- ELSE */
                }
                else
                {


                    /*" -310- IF VL-CUSTO EQUAL ZEROS */

                    if (CALCULOS.VL_CUSTO == 00)
                    {

                        /*" -311- MOVE VL-LIQUIDO TO VL-BASECUSTO */
                        _.Move(CALCULOS.VL_LIQUIDO, VL_BASECUSTO);

                        /*" -312- PERFORM A6000-LE-CUSTO */

                        A6000_LE_CUSTO_SECTION();

                        /*" -314- MOVE CUST-VLCUSTO TO VL-CUSTO. */
                        _.Move(CUST_VLCUSTO, CALCULOS.VL_CUSTO);
                    }

                }

            }


            /*" -317- COMPUTE VL-CUSTO-IX ROUNDED = VL-CUSTO / MOED-VALOR. */
            CALCULOS.VL_CUSTO_IX.Value = CALCULOS.VL_CUSTO / MOED_VALOR;

            /*" -321- COMPUTE VL-IOF-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX. */
            CALCULOS.VL_IOF_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX;

            /*" -325- COMPUTE VL-IOF-IX = (VL-IOF-IX * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = (CALCULOS.VL_IOF_IX * CALCULOS.PCIOF) / 100f;

            /*" -332- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            CALCULOS.VL_TOTAL_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_IOF_IX;

            /*" -335- COMPUTE VL-ADICIONAL ROUNDED = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -339- COMPUTE VL-IOF ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-CUSTO. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_CUSTO;

            /*" -343- COMPUTE VL-IOF ROUNDED = (VL-IOF * PCIOF) / 100. */
            CALCULOS.VL_IOF.Value = (CALCULOS.VL_IOF * CALCULOS.PCIOF) / 100f;

            /*" -346- COMPUTE VL-TOTAL ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-IOF + VL-CUSTO. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF + CALCULOS.VL_CUSTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_CALCULA_UNICO*/

        [StopWatch]
        /*" A4000-PRIMEIRA-PARCELA-SECTION */
        private void A4000_PRIMEIRA_PARCELA_SECTION()
        {
            /*" -353- IF PCDESCON EQUAL ZEROS */

            if (CALCULOS.PCDESCON == 00)
            {

                /*" -354- MOVE VL-PREMIO-BASE TO VL-BASECUSTO-IX */
                _.Move(CALCULOS.VL_PREMIO_BASE, VL_BASECUSTO_IX);

                /*" -355- ELSE */
            }
            else
            {


                /*" -359- COMPUTE VL-BASECUSTO-IX = (VL-PREMIO-BASE * PCDESCON) / 100. */
                VL_BASECUSTO_IX.Value = (CALCULOS.VL_PREMIO_BASE * CALCULOS.PCDESCON) / 100f;
            }


            /*" -362- COMPUTE VL-BASECUSTO = VL-BASECUSTO-IX * MOED-VALOR */
            VL_BASECUSTO.Value = VL_BASECUSTO_IX * MOED_VALOR;

            /*" -365- MOVE ZEROS TO FRAC-INDPRLIQ FRAC-INDADIC */
            _.Move(0, FRAC_INDPRLIQ, FRAC_INDADIC);

            /*" -366- IF IND-FRAC EQUAL 'S' */

            if (CALCULOS.IND_FRAC == "S")
            {

                /*" -367- PERFORM A4100-FRACIONA-ESPECIAL */

                A4100_FRACIONA_ESPECIAL_SECTION();

                /*" -368- GO TO R4000-10-CONTINUA */

                R4000_10_CONTINUA(); //GOTO
                return;

                /*" -369- ELSE */
            }
            else
            {


                /*" -370- IF PCJUROS NOT EQUAL ZEROS */

                if (CALCULOS.PCJUROS != 00)
                {

                    /*" -371- PERFORM A4200-FRACIONA-OUTROS */

                    A4200_FRACIONA_OUTROS_SECTION();

                    /*" -373- GO TO R4000-10-CONTINUA. */

                    R4000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -374- IF PCENTRAD NOT EQUAL ZEROS */

            if (CALCULOS.PCENTRAD != 00)
            {

                /*" -377- COMPUTE VL-TAR-IX ROUNDED = (VL-PREMIO-BASE * PCENTRAD) / 100 */
                CALCULOS.VL_TAR_IX.Value = (CALCULOS.VL_PREMIO_BASE * CALCULOS.PCENTRAD) / 100f;

                /*" -378- ELSE */
            }
            else
            {


                /*" -379- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / QTPARCEL. */
                CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / CALCULOS.QTPARCEL;
            }


            /*" -0- FLUXCONTROL_PERFORM R4000_10_CONTINUA */

            R4000_10_CONTINUA();

        }

        [StopWatch]
        /*" R4000-10-CONTINUA */
        private void R4000_10_CONTINUA(bool isPerform = false)
        {
            /*" -387- COMPUTE VL-DESC-IX ROUNDED = (VL-TAR-IX * PCDESCON) / 100. */
            CALCULOS.VL_DESC_IX.Value = (CALCULOS.VL_TAR_IX * CALCULOS.PCDESCON) / 100f;

            /*" -390- COMPUTE VL-LIQ-IX ROUNDED = VL-TAR-IX - VL-DESC-IX. */
            CALCULOS.VL_LIQ_IX.Value = CALCULOS.VL_TAR_IX - CALCULOS.VL_DESC_IX;

            /*" -393- COMPUTE VL-TARIFA ROUNDED = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -396- COMPUTE VL-DESCONTO ROUNDED = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -399- COMPUTE VL-ADICIONAL ROUNDED = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -402- COMPUTE VL-LIQUIDO = VL-TARIFA - VL-DESCONTO. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_TARIFA - CALCULOS.VL_DESCONTO;

            /*" -403- IF ISENTA-CUSTO EQUAL 'N' */

            if (CALCULOS.ISENTA_CUSTO == "N")
            {

                /*" -404- IF VL-CUSTO EQUAL ZEROS */

                if (CALCULOS.VL_CUSTO == 00)
                {

                    /*" -405- PERFORM A6000-LE-CUSTO */

                    A6000_LE_CUSTO_SECTION();

                    /*" -406- MOVE CUST-VLCUSTO TO VL-CUSTO */
                    _.Move(CUST_VLCUSTO, CALCULOS.VL_CUSTO);

                    /*" -408- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -409- ELSE */
                }

            }
            else
            {


                /*" -411- MOVE ZEROS TO VL-CUSTO. */
                _.Move(0, CALCULOS.VL_CUSTO);
            }


            /*" -414- COMPUTE VL-CUSTO-IX ROUNDED = VL-CUSTO / MOED-VALOR. */
            CALCULOS.VL_CUSTO_IX.Value = CALCULOS.VL_CUSTO / MOED_VALOR;

            /*" -418- COMPUTE VL-IOF-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX. */
            CALCULOS.VL_IOF_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX;

            /*" -422- COMPUTE VL-IOF-IX = (VL-IOF-IX * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = (CALCULOS.VL_IOF_IX * CALCULOS.PCIOF) / 100f;

            /*" -427- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            CALCULOS.VL_TOTAL_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_IOF_IX;

            /*" -431- COMPUTE VL-IOF = VL-LIQUIDO + VL-ADICIONAL + VL-CUSTO. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_CUSTO;

            /*" -435- COMPUTE VL-IOF ROUNDED = (VL-IOF * PCIOF) / 100. */
            CALCULOS.VL_IOF.Value = (CALCULOS.VL_IOF * CALCULOS.PCIOF) / 100f;

            /*" -438- COMPUTE VL-TOTAL ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-IOF + VL-CUSTO. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF + CALCULOS.VL_CUSTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4999_PRIMEIRA_PARCELA*/

        [StopWatch]
        /*" A4100-FRACIONA-ESPECIAL-SECTION */
        private void A4100_FRACIONA_ESPECIAL_SECTION()
        {
            /*" -446- MOVE 'A4100' TO WNR-EXEC-SQL */
            _.Move("A4100", WABEND.WNR_EXEC_SQL);

            /*" -447- MOVE RAMO TO FRAC-RAMO */
            _.Move(CALCULOS.RAMO, FRAC_RAMO);

            /*" -448- MOVE DTINIVIG-LK TO FRAC-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, FRAC_DTINIVIG);

            /*" -449- MOVE NRPARCEL TO FRAC-NRPARCEL */
            _.Move(CALCULOS.NRPARCEL, FRAC_NRPARCEL);

            /*" -451- MOVE QTPARCEL TO FRAC-QTPARCEL */
            _.Move(CALCULOS.QTPARCEL, FRAC_QTPARCEL);

            /*" -461- PERFORM A4100_FRACIONA_ESPECIAL_DB_SELECT_1 */

            A4100_FRACIONA_ESPECIAL_DB_SELECT_1();

            /*" -464- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -465- DISPLAY 'ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS1' */
                _.Display($"ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS1");

                /*" -466- DISPLAY 'FRAC-RAMO     ' FRAC-RAMO */
                _.Display($"FRAC-RAMO     {FRAC_RAMO}");

                /*" -467- DISPLAY 'FRAC-DTINIVIG ' FRAC-DTINIVIG */
                _.Display($"FRAC-DTINIVIG {FRAC_DTINIVIG}");

                /*" -468- DISPLAY 'FRAC-NRPARCEL ' FRAC-NRPARCEL */
                _.Display($"FRAC-NRPARCEL {FRAC_NRPARCEL}");

                /*" -469- DISPLAY 'FRAC-QTPARCEL ' FRAC-QTPARCEL */
                _.Display($"FRAC-QTPARCEL {FRAC_QTPARCEL}");

                /*" -471- MOVE 'ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS1' TO W01A0077 */
                _.Move("ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS1", CALCULOS.W01A0077);

                /*" -473- GOBACK. */

                throw new GoBack();
            }


            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -476- MOVE 'ERRO ACESSO V1FRACIONAMENTO' TO W01A0077 */
                _.Move("ERRO ACESSO V1FRACIONAMENTO", CALCULOS.W01A0077);

                /*" -477- MOVE SQLCODE TO W01A0077-CODSQL */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODSQL);

                /*" -479- GOBACK. */

                throw new GoBack();
            }


            /*" -482- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / FRAC-QTPARCEL. */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / FRAC_QTPARCEL;

            /*" -486- COMPUTE WS-VALOR-DESC = 1 - ( PCDESCON / 100) */
            WS_VALOR_DESC.Value = 1 - (CALCULOS.PCDESCON / 100f);

            /*" -491- COMPUTE VL-ADIC-IX = ( VL-PREMIO-BASE * WS-VALOR-DESC) * ((( FRAC-INDPRLIQ * FRAC-QTPARCEL ) - 1 ) / FRAC-QTPARCEL ). */
            CALCULOS.VL_ADIC_IX.Value = (CALCULOS.VL_PREMIO_BASE * WS_VALOR_DESC) * (((FRAC_INDPRLIQ * FRAC_QTPARCEL) - 1) / FRAC_QTPARCEL);

        }

        [StopWatch]
        /*" A4100-FRACIONA-ESPECIAL-DB-SELECT-1 */
        public void A4100_FRACIONA_ESPECIAL_DB_SELECT_1()
        {
            /*" -461- EXEC SQL SELECT INDPRLIQ, INDADIC INTO :FRAC-INDPRLIQ, :FRAC-INDADIC FROM SEGUROS.V1FRACIONAMENTO WHERE RAMO = :FRAC-RAMO AND DTINIVIG <= :FRAC-DTINIVIG AND DTTERVIG >= :FRAC-DTINIVIG AND NRPARCEL = :FRAC-NRPARCEL AND QTPARCEL = :FRAC-QTPARCEL END-EXEC. */

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
            /*" -501- MOVE 'A4200' TO WNR-EXEC-SQL */
            _.Move("A4200", WABEND.WNR_EXEC_SQL);

            /*" -502- IF W01A0077-VERSAO GREATER 200 */

            if (CALCULOS.W01A0077.W01A0077_LITR.W01A0077_VERSAO > 200)
            {

                /*" -503- MOVE 31 TO FRAC-RAMO */
                _.Move(31, FRAC_RAMO);

                /*" -504- ELSE */
            }
            else
            {


                /*" -506- IF RAMO EQUAL 14 AND W01A0077-VERSAO EQUAL 111 */

                if (CALCULOS.RAMO == 14 && CALCULOS.W01A0077.W01A0077_LITR.W01A0077_VERSAO == 111)
                {

                    /*" -507- MOVE RAMO TO FRAC-RAMO */
                    _.Move(CALCULOS.RAMO, FRAC_RAMO);

                    /*" -508- ELSE */
                }
                else
                {


                    /*" -509- IF NRRCAP NOT EQUAL ZEROS */

                    if (CALCULOS.NRRCAP != 00)
                    {

                        /*" -510- MOVE ZEROS TO FRAC-RAMO */
                        _.Move(0, FRAC_RAMO);

                        /*" -511- ELSE */
                    }
                    else
                    {


                        /*" -513- MOVE 01 TO FRAC-RAMO. */
                        _.Move(01, FRAC_RAMO);
                    }

                }

            }


            /*" -515- MOVE DTINIVIG-LK TO FRAC-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, FRAC_DTINIVIG);

            /*" -516- IF QTPARCEL EQUAL ZEROS */

            if (CALCULOS.QTPARCEL == 00)
            {

                /*" -517- MOVE 1 TO FRAC-QTPARCEL */
                _.Move(1, FRAC_QTPARCEL);

                /*" -518- ELSE */
            }
            else
            {


                /*" -520- MOVE QTPARCEL TO FRAC-QTPARCEL. */
                _.Move(CALCULOS.QTPARCEL, FRAC_QTPARCEL);
            }


            /*" -522- MOVE FRAC-QTPARCEL TO FRAC-NRPARCEL */
            _.Move(FRAC_QTPARCEL, FRAC_NRPARCEL);

            /*" -532- PERFORM A4200_FRACIONA_OUTROS_DB_SELECT_1 */

            A4200_FRACIONA_OUTROS_DB_SELECT_1();

            /*" -535- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -537- MOVE 'ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS2' TO W01A0077 */
                _.Move("ADICIONAL FRAC. NAO EXISTE PARA PARAMETROS2", CALCULOS.W01A0077);

                /*" -539- GOBACK. */

                throw new GoBack();
            }


            /*" -540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -542- MOVE 'ERRO ACESSO V1FRACIONAMENTO' TO W01A0077 */
                _.Move("ERRO ACESSO V1FRACIONAMENTO", CALCULOS.W01A0077);

                /*" -543- MOVE SQLCODE TO W01A0077-CODSQL */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODSQL);

                /*" -545- GOBACK. */

                throw new GoBack();
            }


            /*" -548- COMPUTE VL-TAR-IX = VL-PREMIO-BASE / FRAC-QTPARCEL. */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / FRAC_QTPARCEL;

            /*" -552- COMPUTE WS-VALOR-DESC = 1 - ( PCDESCON / 100) */
            WS_VALOR_DESC.Value = 1 - (CALCULOS.PCDESCON / 100f);

            /*" -557- COMPUTE VL-ADIC-IX = ( VL-PREMIO-BASE * WS-VALOR-DESC) * ((( FRAC-INDPRLIQ * FRAC-QTPARCEL ) - 1 ) / FRAC-QTPARCEL ). */
            CALCULOS.VL_ADIC_IX.Value = (CALCULOS.VL_PREMIO_BASE * WS_VALOR_DESC) * (((FRAC_INDPRLIQ * FRAC_QTPARCEL) - 1) / FRAC_QTPARCEL);

        }

        [StopWatch]
        /*" A4200-FRACIONA-OUTROS-DB-SELECT-1 */
        public void A4200_FRACIONA_OUTROS_DB_SELECT_1()
        {
            /*" -532- EXEC SQL SELECT INDPRLIQ, INDADIC INTO :FRAC-INDPRLIQ, :FRAC-INDADIC FROM SEGUROS.V1FRACIONAMENTO WHERE RAMO = :FRAC-RAMO AND DTINIVIG <= :FRAC-DTINIVIG AND DTTERVIG >= :FRAC-DTINIVIG AND NRPARCEL = :FRAC-NRPARCEL AND QTPARCEL = :FRAC-QTPARCEL END-EXEC. */

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
            /*" -568- MOVE ZEROS TO FRAC-INDPRLIQ FRAC-INDADIC */
            _.Move(0, FRAC_INDPRLIQ, FRAC_INDADIC);

            /*" -569- IF IND-FRAC EQUAL 'S' */

            if (CALCULOS.IND_FRAC == "S")
            {

                /*" -570- PERFORM A4100-FRACIONA-ESPECIAL */

                A4100_FRACIONA_ESPECIAL_SECTION();

                /*" -571- GO TO R5000-10-CONTINUA */

                R5000_10_CONTINUA(); //GOTO
                return;

                /*" -572- ELSE */
            }
            else
            {


                /*" -573- IF PCJUROS NOT EQUAL ZEROS */

                if (CALCULOS.PCJUROS != 00)
                {

                    /*" -574- PERFORM A4200-FRACIONA-OUTROS */

                    A4200_FRACIONA_OUTROS_SECTION();

                    /*" -576- GO TO R5000-10-CONTINUA. */

                    R5000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -577- COMPUTE VL-TAR-IX ROUNDED = VL-PREMIO-BASE / (QTPARCEL - 1). */
            CALCULOS.VL_TAR_IX.Value = CALCULOS.VL_PREMIO_BASE / (CALCULOS.QTPARCEL - 1);

            /*" -0- FLUXCONTROL_PERFORM R5000_10_CONTINUA */

            R5000_10_CONTINUA();

        }

        [StopWatch]
        /*" R5000-10-CONTINUA */
        private void R5000_10_CONTINUA(bool isPerform = false)
        {
            /*" -585- COMPUTE VL-DESC-IX ROUNDED = (VL-TAR-IX * PCDESCON) / 100. */
            CALCULOS.VL_DESC_IX.Value = (CALCULOS.VL_TAR_IX * CALCULOS.PCDESCON) / 100f;

            /*" -588- COMPUTE VL-LIQ-IX ROUNDED = VL-TAR-IX - VL-DESC-IX. */
            CALCULOS.VL_LIQ_IX.Value = CALCULOS.VL_TAR_IX - CALCULOS.VL_DESC_IX;

            /*" -590- MOVE ZEROS TO VL-CUSTO-IX */
            _.Move(0, CALCULOS.VL_CUSTO_IX);

            /*" -594- COMPUTE VL-IOF-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX. */
            CALCULOS.VL_IOF_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX;

            /*" -598- COMPUTE VL-IOF-IX = (VL-IOF-IX * PCIOF) / 100. */
            CALCULOS.VL_IOF_IX.Value = (CALCULOS.VL_IOF_IX * CALCULOS.PCIOF) / 100f;

            /*" -603- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            CALCULOS.VL_TOTAL_IX.Value = CALCULOS.VL_LIQ_IX + CALCULOS.VL_ADIC_IX + CALCULOS.VL_CUSTO_IX + CALCULOS.VL_IOF_IX;

            /*" -606- COMPUTE VL-TARIFA ROUNDED = VL-TAR-IX * MOED-VALOR. */
            CALCULOS.VL_TARIFA.Value = CALCULOS.VL_TAR_IX * MOED_VALOR;

            /*" -609- COMPUTE VL-DESCONTO ROUNDED = VL-DESC-IX * MOED-VALOR. */
            CALCULOS.VL_DESCONTO.Value = CALCULOS.VL_DESC_IX * MOED_VALOR;

            /*" -612- COMPUTE VL-ADICIONAL ROUNDED = VL-ADIC-IX * MOED-VALOR. */
            CALCULOS.VL_ADICIONAL.Value = CALCULOS.VL_ADIC_IX * MOED_VALOR;

            /*" -615- COMPUTE VL-LIQUIDO = VL-TARIFA - VL-DESCONTO. */
            CALCULOS.VL_LIQUIDO.Value = CALCULOS.VL_TARIFA - CALCULOS.VL_DESCONTO;

            /*" -617- MOVE ZEROS TO VL-CUSTO */
            _.Move(0, CALCULOS.VL_CUSTO);

            /*" -621- COMPUTE VL-IOF = VL-LIQUIDO + VL-ADICIONAL + VL-CUSTO. */
            CALCULOS.VL_IOF.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_CUSTO;

            /*" -625- COMPUTE VL-IOF ROUNDED = (VL-IOF * PCIOF) / 100. */
            CALCULOS.VL_IOF.Value = (CALCULOS.VL_IOF * CALCULOS.PCIOF) / 100f;

            /*" -628- COMPUTE VL-TOTAL ROUNDED = VL-LIQUIDO + VL-ADICIONAL + VL-IOF + VL-CUSTO. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF + CALCULOS.VL_CUSTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A5999_CALCULA_DEMAIS*/

        [StopWatch]
        /*" A6000-LE-CUSTO-SECTION */
        private void A6000_LE_CUSTO_SECTION()
        {
            /*" -633- MOVE 'A6000' TO WNR-EXEC-SQL */
            _.Move("A6000", WABEND.WNR_EXEC_SQL);

            /*" -634- MOVE DTINIVIG-LK TO CUST-DTINIVIG */
            _.Move(CALCULOS.DTINIVIG_LK, CUST_DTINIVIG);

            /*" -659- MOVE VL-BASECUSTO TO CUST-VLINIFAI */
            _.Move(VL_BASECUSTO, CUST_VLINIFAI);

            /*" -659- MOVE 35 TO CUST-VLCUSTO. */
            _.Move(35, CUST_VLCUSTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A6999_999_EXIT*/

        [StopWatch]
        /*" R6000-00-PARCELA-AUTO-FACIL-SECTION */
        private void R6000_00_PARCELA_AUTO_FACIL_SECTION()
        {
            /*" -670- PERFORM R6010-00-SELECT-AU-PLANO. */

            R6010_00_SELECT_AU_PLANO_SECTION();

            /*" -672- MOVE VL-PREMIO-BASE TO VLR-PRM-TOTAL */
            _.Move(CALCULOS.VL_PREMIO_BASE, VLR_PRM_TOTAL);

            /*" -673- MOVE VL-IOF-IX TO PC-IOF */
            _.Move(CALCULOS.VL_IOF_IX, PC_IOF);

            /*" -675- COMPUTE VL-PREMIO-BASE = VLR-PRM-TOTAL / W01A0077-QTPARC */
            CALCULOS.VL_PREMIO_BASE.Value = VLR_PRM_TOTAL / CALCULOS.W01A0077.W01A0077_LITR.W01A0077_QTPARC;

            /*" -677- MOVE VL-PREMIO-BASE TO VLR-PRM-TOTP */
            _.Move(CALCULOS.VL_PREMIO_BASE, VLR_PRM_TOTP);

            /*" -680- COMPUTE VLR-PRM-LIQP ROUNDED = VLR-PRM-TOTP / (1+(PC-IOF)) */
            VLR_PRM_LIQP.Value = VLR_PRM_TOTP / (1 + (PC_IOF));

            /*" -683- COMPUTE VLR-IOFP ROUNDED = VLR-PRM-LIQP * PC-IOF */
            VLR_IOFP.Value = VLR_PRM_LIQP * PC_IOF;

            /*" -686- COMPUTE VLR-PRM-TOTP = VLR-PRM-LIQP + VLR-IOFP. */
            VLR_PRM_TOTP.Value = VLR_PRM_LIQP + VLR_IOFP;

            /*" -687- MOVE VLR-PRM-LIQP TO VL-LIQUIDO */
            _.Move(VLR_PRM_LIQP, CALCULOS.VL_LIQUIDO);

            /*" -688- MOVE VLR-PRM-LIQP TO VL-TARIFA */
            _.Move(VLR_PRM_LIQP, CALCULOS.VL_TARIFA);

            /*" -689- MOVE ZEROS TO VL-DESCONTO */
            _.Move(0, CALCULOS.VL_DESCONTO);

            /*" -690- MOVE ZEROS TO VL-CUSTO */
            _.Move(0, CALCULOS.VL_CUSTO);

            /*" -691- MOVE ZEROS TO VL-ADICIONAL */
            _.Move(0, CALCULOS.VL_ADICIONAL);

            /*" -693- MOVE VLR-IOFP TO VL-IOF */
            _.Move(VLR_IOFP, CALCULOS.VL_IOF);

            /*" -698- COMPUTE VL-ADICIONAL = (VL-LIQUIDO + VL-CUSTO) * AU080-PCT-TOTAL-ENCARGO / 100 */
            CALCULOS.VL_ADICIONAL.Value = (CALCULOS.VL_LIQUIDO + CALCULOS.VL_CUSTO) * AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_PCT_TOTAL_ENCARGO / 100f;

            /*" -702- COMPUTE VL-TOTAL = VL-LIQUIDO + VL-DESCONTO + VL-CUSTO + VL-ADICIONAL + VL-IOF. */
            CALCULOS.VL_TOTAL.Value = CALCULOS.VL_LIQUIDO + CALCULOS.VL_DESCONTO + CALCULOS.VL_CUSTO + CALCULOS.VL_ADICIONAL + CALCULOS.VL_IOF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_EXIT*/

        [StopWatch]
        /*" R6010-00-SELECT-AU-PLANO-SECTION */
        private void R6010_00_SELECT_AU_PLANO_SECTION()
        {
            /*" -712- IF W01A0077-QTPARC EQUAL ZEROS */

            if (CALCULOS.W01A0077.W01A0077_LITR.W01A0077_QTPARC == 00)
            {

                /*" -714- MOVE 1 TO W01A0077-QTPARC. */
                _.Move(1, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_QTPARC);
            }


            /*" -715- MOVE W01A0077-TIPCOB TO AU080-IND-FORMA-PGTO */
            _.Move(CALCULOS.W01A0077.W01A0077_LITR.W01A0077_TIPCOB, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO);

            /*" -716- MOVE W01A0077-QTPARC TO AU080-QTD-PARCELA */
            _.Move(CALCULOS.W01A0077.W01A0077_LITR.W01A0077_QTPARC, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA);

            /*" -717- MOVE W01A0077-CODPRO TO AU080-COD-PRODUTO */
            _.Move(CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODPRO, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO);

            /*" -719- MOVE W01A0077-INIVIG TO AU080-DTA-INI-VIGENCIA */
            _.Move(CALCULOS.W01A0077.W01A0077_LITR.W01A0077_INIVIG, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA);

            /*" -728- PERFORM R6010_00_SELECT_AU_PLANO_DB_SELECT_1 */

            R6010_00_SELECT_AU_PLANO_DB_SELECT_1();

            /*" -731- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -733- MOVE 'PRODUTO SEM PLANO CADASTRADO ' TO W01A0077 */
                _.Move("PRODUTO SEM PLANO CADASTRADO ", CALCULOS.W01A0077);

                /*" -735- GOBACK. */

                throw new GoBack();
            }


            /*" -736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -738- MOVE 'ERRO ACESSO AU_PARAM_PLANO_PRDTO' TO W01A0077 */
                _.Move("ERRO ACESSO AU_PARAM_PLANO_PRDTO", CALCULOS.W01A0077);

                /*" -739- MOVE SQLCODE TO W01A0077-CODSQL */
                _.Move(DB.SQLCODE, CALCULOS.W01A0077.W01A0077_LITR.W01A0077_CODSQL);

                /*" -739- GOBACK. */

                throw new GoBack();
            }


        }

        [StopWatch]
        /*" R6010-00-SELECT-AU-PLANO-DB-SELECT-1 */
        public void R6010_00_SELECT_AU_PLANO_DB_SELECT_1()
        {
            /*" -728- EXEC SQL SELECT VALUE(PCT_TOTAL_ENCARGO, 0) INTO :AU080-PCT-TOTAL-ENCARGO FROM SEGUROS.AU_PARAM_PLANO_PRDTO WHERE QTD_PARCELA = :AU080-QTD-PARCELA AND COD_PRODUTO = :AU080-COD-PRODUTO AND IND_FORMA_PGTO = :AU080-IND-FORMA-PGTO AND DTA_INI_VIGENCIA <= :AU080-DTA-INI-VIGENCIA AND DTA_FIM_VIGENCIA >= :AU080-DTA-INI-VIGENCIA END-EXEC. */

            var r6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1 = new R6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1()
            {
                AU080_DTA_INI_VIGENCIA = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA.ToString(),
                AU080_IND_FORMA_PGTO = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO.ToString(),
                AU080_QTD_PARCELA = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA.ToString(),
                AU080_COD_PRODUTO = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO.ToString(),
            };

            var executed_1 = R6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1.Execute(r6010_00_SELECT_AU_PLANO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU080_PCT_TOTAL_ENCARGO, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_PCT_TOTAL_ENCARGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_EXIT*/
    }
}