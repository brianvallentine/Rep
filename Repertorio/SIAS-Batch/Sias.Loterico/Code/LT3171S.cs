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
    public class LT3171S
    {
        public bool IsCall { get; set; }

        public LT3171S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  LOTERICOS                          *      */
        /*"      *   PROGRAMA ...............  LT3171S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JOSE G OLIVEIRA/GUILHERME CORREIA  *      */
        /*"      *   PROGRAMADOR ............  GUILHERME CORREIA                  *      */
        /*"      *   DATA CODIFICACAO .......  JUN/2013                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CONTROLE DAS ALTERACOES:   PROCURE POR WS-VERSAO                    */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  SUBROTINA PARA VERIFICAR PRODUTO   *      */
        /*"      *                             1803 (LOTERICO) OU 1805 (CCA)      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PARAMETROS INFORMADOS:   COD-LOTERICO                                 */
        /*"      *                                                                       */
        /*"      *   SE PRIMEIRA POSICAO DO CODIGO FOR 9 SIGNIFICA QUE O PRODUTO         */
        /*"      *   EH CORRESPONDENTES CAIXA AQUI (CCA) - 1805                          */
        /*"      *                                                                       */
        /*"      *   SE NAO O PRODUTO EH LOTERICO - 1803                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01   WS-VERIFICA-CODIGO.*/
        public LT3171S_WS_VERIFICA_CODIGO WS_VERIFICA_CODIGO { get; set; } = new LT3171S_WS_VERIFICA_CODIGO();
        public class LT3171S_WS_VERIFICA_CODIGO : VarBasis
        {
            /*"  05 WS-COD-LOTERICO             PIC +9(10)  VALUE ZEROS.*/
            public IntBasis WS_COD_LOTERICO { get; set; } = new IntBasis(new PIC("+9", "10", "+9(10)"));
            /*"  05 FILLER                      REDEFINES WS-COD-LOTERICO.*/
            private _REDEF_LT3171S_FILLER_0 _filler_0 { get; set; }
            public _REDEF_LT3171S_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_LT3171S_FILLER_0(); _.Move(WS_COD_LOTERICO, _filler_0); VarBasis.RedefinePassValue(WS_COD_LOTERICO, _filler_0, WS_COD_LOTERICO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_COD_LOTERICO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_COD_LOTERICO); }
            }  //Redefines
            public class _REDEF_LT3171S_FILLER_0 : VarBasis
            {
                /*"    10 FILLER                    PIC X(02).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    10 WS-COD-VERIFICADOR        PIC 9(01).*/
                public IntBasis WS_COD_VERIFICADOR { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 WS-NUM-LOTERICO           PIC 9(08).*/
                public IntBasis WS_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));

                public _REDEF_LT3171S_FILLER_0()
                {
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_COD_VERIFICADOR.ValueChanged += OnValueChanged;
                    WS_NUM_LOTERICO.ValueChanged += OnValueChanged;
                }

            }
        }


        public Copies.LBLT3171 LBLT3171 { get; set; } = new Copies.LBLT3171();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3171_LT3171_AREA_PARAMETROS LBLT3171_LT3171_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3171_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3171.LT3171_AREA_PARAMETROS = LBLT3171_LT3171_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3171.LT3171_AREA_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -68- INITIALIZE LT3171-MSG-RETORNO LT3171-COD-RETORNO LT3171-PRODUTO */
            _.Initialize(
                LBLT3171.LT3171_AREA_PARAMETROS.LT3171_MSG_RETORNO
                , LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO
                , LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO
            );

            /*" -70- PERFORM R1000-00-PROCESSA-REGISTRO */

            R1000_00_PROCESSA_REGISTRO_SECTION();

            /*" -71- PERFORM R9900-00-ROT-RETORNO */

            R9900_00_ROT_RETORNO_SECTION();

            /*" -71- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -83- IF LT3171-NUM-LOTERICO NOT NUMERIC */

            if (!LBLT3171.LT3171_AREA_PARAMETROS.LT3171_NUM_LOTERICO.IsNumeric())
            {

                /*" -85- MOVE 'R1000- CODIGO INFORMADO INVALIDO' TO LT3171-MSG-RETORNO */
                _.Move("R1000- CODIGO INFORMADO INVALIDO", LBLT3171.LT3171_AREA_PARAMETROS.LT3171_MSG_RETORNO);

                /*" -86- MOVE 120 TO LT3171-COD-RETORNO */
                _.Move(120, LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO);

                /*" -87- PERFORM R9900-00-ROT-RETORNO */

                R9900_00_ROT_RETORNO_SECTION();

                /*" -89- END-IF */
            }


            /*" -90- IF LT3171-NUM-LOTERICO EQUAL ZEROS */

            if (LBLT3171.LT3171_AREA_PARAMETROS.LT3171_NUM_LOTERICO == 00)
            {

                /*" -92- MOVE 'R1000- CODIGO INFORMADO ZERADO' TO LT3171-MSG-RETORNO */
                _.Move("R1000- CODIGO INFORMADO ZERADO", LBLT3171.LT3171_AREA_PARAMETROS.LT3171_MSG_RETORNO);

                /*" -93- MOVE 120 TO LT3171-COD-RETORNO */
                _.Move(120, LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO);

                /*" -94- PERFORM R9900-00-ROT-RETORNO */

                R9900_00_ROT_RETORNO_SECTION();

                /*" -96- END-IF */
            }


            /*" -98- MOVE LT3171-NUM-LOTERICO TO WS-COD-LOTERICO */
            _.Move(LBLT3171.LT3171_AREA_PARAMETROS.LT3171_NUM_LOTERICO, WS_VERIFICA_CODIGO.WS_COD_LOTERICO);

            /*" -99- IF WS-COD-VERIFICADOR EQUAL 9 */

            if (WS_VERIFICA_CODIGO.FILLER_0.WS_COD_VERIFICADOR == 9)
            {

                /*" -100- MOVE 1805 TO LT3171-PRODUTO */
                _.Move(1805, LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO);

                /*" -101- ELSE */
            }
            else
            {


                /*" -102- MOVE 1803 TO LT3171-PRODUTO */
                _.Move(1803, LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO);

                /*" -104- END-IF */
            }


            /*" -106- DISPLAY 'LT3171S - SAIDA - LOT=' LT3171-NUM-LOTERICO ' PRODUTO =' LT3171-PRODUTO */

            $"LT3171S - SAIDA - LOT={LBLT3171.LT3171_AREA_PARAMETROS.LT3171_NUM_LOTERICO} PRODUTO ={LBLT3171.LT3171_AREA_PARAMETROS.LT3171_PRODUTO}"
            .Display();

            /*" -106- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ROT-RETORNO-SECTION */
        private void R9900_00_ROT_RETORNO_SECTION()
        {
            /*" -114- IF LT3171-COD-RETORNO NOT EQUAL ZEROES */

            if (LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO != 00)
            {

                /*" -115- DISPLAY 'R9900-REJEITADO LOT=' LT3171-NUM-LOTERICO */
                _.Display($"R9900-REJEITADO LOT={LBLT3171.LT3171_AREA_PARAMETROS.LT3171_NUM_LOTERICO}");

                /*" -116- DISPLAY 'COD RETORNO =' LT3171-COD-RETORNO */
                _.Display($"COD RETORNO ={LBLT3171.LT3171_AREA_PARAMETROS.LT3171_COD_RETORNO}");

                /*" -117- DISPLAY 'MSG-RETORNO =' LT3171-MSG-RETORNO */
                _.Display($"MSG-RETORNO ={LBLT3171.LT3171_AREA_PARAMETROS.LT3171_MSG_RETORNO}");

                /*" -119- END-IF */
            }


            /*" -120- GOBACK */

            throw new GoBack();

            /*" -120- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/
    }
}