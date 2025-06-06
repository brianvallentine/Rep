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
    public class PROCONV
    {
        public bool IsCall { get; set; }

        public PROCONV()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA DE LOTERICO - FENAL        *      */
        /*"      *   PROGRAMA ...............  PROCONV                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JEFFERSON                          *      */
        /*"      *   PROGRAMADOR ............  JEFFERSON                          *      */
        /*"      *   DATA CODIFICACAO .......  JULHO/2001                                */
        /*"      *----------------------------------------------------------------       */
        /*"      *   FUNCAO .................  CONVERTER/MANTER CARACTERES NAO           */
        /*"      *                             ALFABETICOS PARA ALFABETICO               */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01      AREA-DE-WORK.*/
        public PROCONV_AREA_DE_WORK AREA_DE_WORK { get; set; } = new PROCONV_AREA_DE_WORK();
        public class PROCONV_AREA_DE_WORK : VarBasis
        {
            /*"  05    WIND                   PIC  9(002)   VALUE  ZEROS.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05    WIND-TAM               PIC  9(002)   VALUE  ZEROS.*/
            public IntBasis WIND_TAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05    WCAMPO                 VALUE SPACES.*/
            public PROCONV_WCAMPO WCAMPO { get; set; } = new PROCONV_WCAMPO();
            public class PROCONV_WCAMPO : VarBasis
            {
                /*"    10  WCPO                   OCCURS 50 TIMES                               PIC X(001).*/
                public ListBasis<StringBasis, string> WCPO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 50);
                /*"01      LK-CONVERSAO.*/
            }
        }
        public PROCONV_LK_CONVERSAO LK_CONVERSAO { get; set; } = new PROCONV_LK_CONVERSAO();
        public class PROCONV_LK_CONVERSAO : VarBasis
        {
            /*"  05    LK-TAM-CAMPO             PIC 9(003).*/
            public IntBasis LK_TAM_CAMPO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05    LK-CAMPO-ENTRADA         PIC X(100).*/
            public StringBasis LK_CAMPO_ENTRADA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05    LK-CAMPO-SAIDA           PIC X(100).*/
            public StringBasis LK_CAMPO_SAIDA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05    LK-CONVER-MAIUSCULA      PIC X(001).*/
            public StringBasis LK_CONVER_MAIUSCULA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROCONV_LK_CONVERSAO PROCONV_LK_CONVERSAO_P) //PROCEDURE DIVISION USING 
        /*LK_CONVERSAO*/
        {
            try
            {
                this.LK_CONVERSAO = PROCONV_LK_CONVERSAO_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-CONVERTE-CARACATER-SECTION */

                R0000_00_CONVERTE_CARACATER_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_CONVERSAO };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-CONVERTE-CARACATER-SECTION */
        private void R0000_00_CONVERTE_CARACATER_SECTION()
        {
            /*" -61- MOVE ZEROS TO AREA-DE-WORK. */
            _.Move(0, AREA_DE_WORK);

            /*" -63- MOVE SPACES TO WCAMPO. */
            _.Move("", AREA_DE_WORK.WCAMPO);

            /*" -64- IF LK-CAMPO-ENTRADA NOT ALPHABETIC */

            if (!_.IsAlphabetic(LK_CONVERSAO.LK_CAMPO_ENTRADA!))
            {

                /*" -65- MOVE LK-TAM-CAMPO TO WIND-TAM */
                _.Move(LK_CONVERSAO.LK_TAM_CAMPO, AREA_DE_WORK.WIND_TAM);

                /*" -66- MOVE LK-CAMPO-ENTRADA TO WCAMPO */
                _.Move(LK_CONVERSAO.LK_CAMPO_ENTRADA, AREA_DE_WORK.WCAMPO);

                /*" -67- PERFORM R0001-00-VERIFICA-CONTEUDO */

                R0001_00_VERIFICA_CONTEUDO_SECTION();

                /*" -68- MOVE WCAMPO TO LK-CAMPO-ENTRADA */
                _.Move(AREA_DE_WORK.WCAMPO, LK_CONVERSAO.LK_CAMPO_ENTRADA);

                /*" -70- MOVE WCAMPO TO LK-CAMPO-SAIDA. */
                _.Move(AREA_DE_WORK.WCAMPO, LK_CONVERSAO.LK_CAMPO_SAIDA);
            }


            /*" -71- IF LK-CONVER-MAIUSCULA = 'S' */

            if (LK_CONVERSAO.LK_CONVER_MAIUSCULA == "S")
            {

                /*" -74- MOVE FUNCTION UPPER-CASE(LK-CAMPO-ENTRADA) TO LK-CAMPO-SAIDA. */
                _.Move(LK_CONVERSAO.LK_CAMPO_ENTRADA.ToString().ToUpper(), LK_CONVERSAO.LK_CAMPO_SAIDA);
            }


            /*" -74- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0001-00-VERIFICA-CONTEUDO-SECTION */
        private void R0001_00_VERIFICA_CONTEUDO_SECTION()
        {
            /*" -79- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R0001_10_LOOP */

            R0001_10_LOOP();

        }

        [StopWatch]
        /*" R0001-10-LOOP */
        private void R0001_10_LOOP(bool isPerform = false)
        {
            /*" -85- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -86- IF WIND > WIND-TAM */

            if (AREA_DE_WORK.WIND > AREA_DE_WORK.WIND_TAM)
            {

                /*" -88- GO TO R0001-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/ //GOTO
                return;
            }


            /*" -89- IF WCPO(WIND) IS ALPHABETIC */

            if (_.IsAlphabetic(AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]))
            {

                /*" -91- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -92- IF WCPO(WIND) IS NUMERIC */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].IsNumeric())
            {

                /*" -94- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -99- IF WCPO(WIND) = '-' OR ',' OR '.' OR '/' OR '"' OR '!' OR '@' OR '&' OR '#' OR '%' OR '*' OR '(' OR ')' OR '_' OR '?' OR '|' OR '$' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("-", " , ", ".", "/", "\"", "!", "@", "&", "#", "%", "*", " ( ".ToString(), " )", "_".ToString(), "?", "|", "$"))
            {

                /*" -101- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -102- IF WCPO(WIND) = ':' OR '=' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In(":", "="))
            {

                /*" -103- MOVE '.' TO WCPO(WIND) */
                _.Move(".", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -105- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -106- IF WCPO(WIND) = ';' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND] == ";")
            {

                /*" -107- MOVE ',' TO WCPO(WIND) */
                _.Move(",", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -109- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -110- IF WCPO(WIND) = '�' OR '�' OR '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�", "�", "�"))
            {

                /*" -111- MOVE 'a' TO wcpo(wind) */
                _.Move("a", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -113- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -114- IF WCPO(WIND) = '�' OR '�' OR '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�", "�", "�"))
            {

                /*" -115- MOVE 'A' TO WCPO(WIND) */
                _.Move("A", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -117- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -118- IF wcpo(wind) = '�' OR '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�", "�"))
            {

                /*" -119- MOVE 'o' TO wcpo(wind) */
                _.Move("o", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -121- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -122- IF WCPO(WIND) = '�' OR '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�", "�"))
            {

                /*" -123- MOVE 'O' TO WCPO(WIND) */
                _.Move("O", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -125- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -126- IF wcpo(wind) = '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�"))
            {

                /*" -127- MOVE 'e' TO wcpo(wind) */
                _.Move("e", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -129- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -130- IF WCPO(WIND) = '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�"))
            {

                /*" -131- MOVE 'E' TO WCPO(WIND) */
                _.Move("E", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -133- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -134- IF wcpo(wind) = '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND] == "�")
            {

                /*" -135- MOVE 'i' TO wcpo(wind) */
                _.Move("i", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -137- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -138- IF WCPO(WIND) = '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND] == "�")
            {

                /*" -139- MOVE 'I' TO WCPO(WIND) */
                _.Move("I", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -141- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -142- IF wcpo(wind) = '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�"))
            {

                /*" -143- MOVE 'u' TO wcpo(wind) */
                _.Move("u", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -145- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -146- IF WCPO(WIND) = '�' OR '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND].In("�", "�"))
            {

                /*" -147- MOVE 'U' TO WCPO(WIND) */
                _.Move("U", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -149- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -150- IF WCPO(WIND) = '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND] == "�")
            {

                /*" -151- MOVE 'c' TO WCPO(WIND) */
                _.Move("c", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -153- GO TO R0001-10-LOOP. */
                new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -154- IF WCPO(WIND) = '�' */

            if (AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND] == "�")
            {

                /*" -155- MOVE 'C' TO WCPO(WIND) */
                _.Move("C", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);

                /*" -156- ELSE */
            }
            else
            {


                /*" -158- MOVE SPACES TO WCPO(WIND). */
                _.Move("", AREA_DE_WORK.WCAMPO.WCPO[AREA_DE_WORK.WIND]);
            }


            /*" -158- GO TO R0001-10-LOOP. */
            new Task(() => R0001_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/
    }
}