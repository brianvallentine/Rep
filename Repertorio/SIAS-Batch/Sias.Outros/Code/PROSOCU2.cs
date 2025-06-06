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
    public class PROSOCU2
    {
        public bool IsCall { get; set; }

        public PROSOCU2()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *REMARKS        MODIFICADO POR FONSECA EM 12/07/96                      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROSOCU2   (SUBROTINA)             *      */
        /*"      *                                                                *      */
        /*"      *   AMBIENTE................  MVS-ESA/BATCH/ OU VM-ESA/BATCH     *      */
        /*"      *                                    COBOL2                      *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  SOMAR NN DIAS A UMA DATA DDMMAAAA  *      */
        /*"      *                             E OBTER RESULTADO DATA DDMMAAAA    *      */
        /*"      *                             SE ESTA NAO FOR DIA UTIL CONTINUA  *      */
        /*"      *                             INCREMENTANDO DE 1 EM 1 ATE O PRI- *      */
        /*"      *                             MEIRO DIA UTIL APOS O RESULTADO..  *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  BUENO                              *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  ENRICO                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  DEZEMBRO/92                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERADO EM 12/07/96 - FONSECA                                 *      */
        /*"      *                                                                *      */
        /*"      *   O PROGRAMA CHAMA A ROTINA 700-000-CONVERTE-NNNNN-EM-DATA     *      */
        /*"      *   UMA 2A VEZ QUANDO ENCONTRA UM FERIADO. NESSA ROTINA,         *      */
        /*"      *   E' SOMADO 1 AO NUMERO DE DIAS-JULIANOS DA TABELA TAB03,      *      */
        /*"      *   QUANDO O ANO E' BISSEXTO.                                    *      */
        /*"      *   QUANDO A ROTINA ERA ATIVADA A 2A VEZ, NOVAMENTE ERA          *      */
        /*"      *   EXECUTADA A SOMA, O QUE DISTORCIA A DATA-RESULTADO.          *      */
        /*"      *   FOI IMPLEMENTADO UM CONTROLE DE SE DIMINUIR 1 DA TABELA      *      */
        /*"      *   TAB03, APOS O CALCULO DA DATA, DENTRO DA ROTINA.             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 26/01/1998.   *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I03 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01              FILLER.*/
        public PROSOCU2_FILLER_0 FILLER_0 { get; set; } = new PROSOCU2_FILLER_0();
        public class PROSOCU2_FILLER_0 : VarBasis
        {
            /*"  03            WSOMADI         PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WSOMADI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDSEM           PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WDSEM { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WX05            PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WX05 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIAS01         PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS01 { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WQUOCIENTE      PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WRESTO          PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIASREST       PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIASREST { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WANOS           PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WANOS { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WDIAS           PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WSOMBISXTO      PIC  9(001)         VALUE  ZEROS*/
            public IntBasis WSOMBISXTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01              FILLER.*/
        }
        public PROSOCU2_FILLER_1 FILLER_1 { get; set; } = new PROSOCU2_FILLER_1();
        public class PROSOCU2_FILLER_1 : VarBasis
        {
            /*"  03            WTB01-DIAS-JULIANO.*/
            public PROSOCU2_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PROSOCU2_WTB01_DIAS_JULIANO();
            public class PROSOCU2_WTB01_DIAS_JULIANO : VarBasis
            {
                /*"    05          WTB1-1          PIC S9(003) COMP-3  VALUE  ZEROS*/
                public IntBasis WTB1_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05          WTB1-2          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB1_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB1-3          PIC S9(003) COMP-3  VALUE +59.*/
                public IntBasis WTB1_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                /*"    05          WTB1-4          PIC S9(003) COMP-3  VALUE +90.*/
                public IntBasis WTB1_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                /*"    05          WTB1-5          PIC S9(003) COMP-3  VALUE +120.*/
                public IntBasis WTB1_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                /*"    05          WTB1-6          PIC S9(003) COMP-3  VALUE +151.*/
                public IntBasis WTB1_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                /*"    05          WTB1-7          PIC S9(003) COMP-3  VALUE +181.*/
                public IntBasis WTB1_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                /*"    05          WTB1-8          PIC S9(003) COMP-3  VALUE +212.*/
                public IntBasis WTB1_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                /*"    05          WTB1-9          PIC S9(003) COMP-3  VALUE +243.*/
                public IntBasis WTB1_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                /*"    05          WTB1-10         PIC S9(003) COMP-3  VALUE +273.*/
                public IntBasis WTB1_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                /*"    05          WTB1-11         PIC S9(003) COMP-3  VALUE +304.*/
                public IntBasis WTB1_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                /*"    05          WTB1-12         PIC S9(003) COMP-3  VALUE +334.*/
                public IntBasis WTB1_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                /*"  03            FILLER          REDEFINES                WTB01-DIAS-JULIANO.*/
            }
            private _REDEF_PROSOCU2_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PROSOCU2_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PROSOCU2_FILLER_2(); _.Move(WTB01_DIAS_JULIANO, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_2, WTB01_DIAS_JULIANO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_JULIANO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROSOCU2_FILLER_2 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB02-DIAS-MES.*/

                public _REDEF_PROSOCU2_FILLER_2()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
            public PROSOCU2_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PROSOCU2_WTB02_DIAS_MES();
            public class PROSOCU2_WTB02_DIAS_MES : VarBasis
            {
                /*"    05          WTB2-1          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-2          PIC S9(003) COMP-3  VALUE +28.*/
                public IntBasis WTB2_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +28);
                /*"    05          WTB2-3          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-4          PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-5          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-6          PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-7          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-8          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-9          PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-10         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-11         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-12         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"  03            FILLER          REDEFINES                WTB02-DIAS-MES.*/
            }
            private _REDEF_PROSOCU2_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PROSOCU2_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PROSOCU2_FILLER_3(); _.Move(WTB02_DIAS_MES, _filler_3); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_3, WTB02_DIAS_MES); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB02_DIAS_MES); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WTB02_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PROSOCU2_FILLER_3 : VarBasis
            {
                /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB03-DIAS-JULIANO.*/

                public _REDEF_PROSOCU2_FILLER_3()
                {
                    WTB02.ValueChanged += OnValueChanged;
                }

            }
            public PROSOCU2_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PROSOCU2_WTB03_DIAS_JULIANO();
            public class PROSOCU2_WTB03_DIAS_JULIANO : VarBasis
            {
                /*"    05          WTB3-1          PIC S9(003) COMP-3  VALUE  ZEROS*/
                public IntBasis WTB3_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05          WTB3-2          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB3_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB3-3          PIC S9(003) COMP-3  VALUE +59.*/
                public IntBasis WTB3_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                /*"    05          WTB3-4          PIC S9(003) COMP-3  VALUE +90.*/
                public IntBasis WTB3_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                /*"    05          WTB3-5          PIC S9(003) COMP-3  VALUE +120.*/
                public IntBasis WTB3_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                /*"    05          WTB3-6          PIC S9(003) COMP-3  VALUE +151.*/
                public IntBasis WTB3_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                /*"    05          WTB3-7          PIC S9(003) COMP-3  VALUE +181.*/
                public IntBasis WTB3_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                /*"    05          WTB3-8          PIC S9(003) COMP-3  VALUE +212.*/
                public IntBasis WTB3_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                /*"    05          WTB3-9          PIC S9(003) COMP-3  VALUE +243.*/
                public IntBasis WTB3_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                /*"    05          WTB3-10         PIC S9(003) COMP-3  VALUE +273.*/
                public IntBasis WTB3_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                /*"    05          WTB3-11         PIC S9(003) COMP-3  VALUE +304.*/
                public IntBasis WTB3_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                /*"    05          WTB3-12         PIC S9(003) COMP-3  VALUE +334.*/
                public IntBasis WTB3_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                /*"  03            FILLER          REDEFINES                WTB03-DIAS-JULIANO.*/
            }
            private _REDEF_PROSOCU2_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PROSOCU2_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PROSOCU2_FILLER_4(); _.Move(WTB03_DIAS_JULIANO, _filler_4); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_4, WTB03_DIAS_JULIANO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB03_DIAS_JULIANO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTB03_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROSOCU2_FILLER_4 : VarBasis
            {
                /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              FILLER.*/

                public _REDEF_PROSOCU2_FILLER_4()
                {
                    WTB03.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROSOCU2_FILLER_5 FILLER_5 { get; set; } = new PROSOCU2_FILLER_5();
        public class PROSOCU2_FILLER_5 : VarBasis
        {
            /*"  03            WTB04-DIAS-FERIADOS.*/
            public PROSOCU2_WTB04_DIAS_FERIADOS WTB04_DIAS_FERIADOS { get; set; } = new PROSOCU2_WTB04_DIAS_FERIADOS();
            public class PROSOCU2_WTB04_DIAS_FERIADOS : VarBasis
            {
                /*"    05          WTB4-PRIMEIROX  PIC  X(008) VALUE '01011992'.*/
                public StringBasis WTB4_PRIMEIROX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01011992");
                /*"    05          WTB4-SAOPAULOX  PIC  X(008) VALUE '25011992'.*/
                public StringBasis WTB4_SAOPAULOX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25011992");
                /*"    05          WTB4-CARNAVALX  PIC  X(008) VALUE '23021992'.*/
                public StringBasis WTB4_CARNAVALX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"23021992");
                /*"    05          WTB4-PAIXAOX    PIC  X(008) VALUE '09041992'.*/
                public StringBasis WTB4_PAIXAOX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"09041992");
                /*"    05          WTB4-TIRADENX   PIC  X(008) VALUE '21041992'.*/
                public StringBasis WTB4_TIRADENX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21041992");
                /*"    05          WTB4-TRABALHOX  PIC  X(008) VALUE '01051992'.*/
                public StringBasis WTB4_TRABALHOX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01051992");
                /*"    05          WTB4-CORPUSX    PIC  X(008) VALUE '10061992'.*/
                public StringBasis WTB4_CORPUSX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"10061992");
                /*"    05          WTB4-INDEPENDEX PIC  X(008) VALUE '07091992'.*/
                public StringBasis WTB4_INDEPENDEX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07091992");
                /*"    05          WTB4-PADROEIRAX PIC  X(008) VALUE '12101992'.*/
                public StringBasis WTB4_PADROEIRAX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12101992");
                /*"    05          WTB4-SECURITARX PIC  X(008) VALUE '18101992'.*/
                public StringBasis WTB4_SECURITARX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"18101992");
                /*"    05          WTB4-FINADOSX   PIC  X(008) VALUE '02111992'.*/
                public StringBasis WTB4_FINADOSX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02111992");
                /*"    05          WTB4-REPUBLICAX PIC  X(008) VALUE '15111992'.*/
                public StringBasis WTB4_REPUBLICAX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15111992");
                /*"    05          WTB4-NATALX     PIC  X(008) VALUE '25121992'.*/
                public StringBasis WTB4_NATALX { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25121992");
                /*"    05          WTB4-PRIMEIRO   PIC  X(008) VALUE '01011993'.*/
                public StringBasis WTB4_PRIMEIRO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01011993");
                /*"    05          WTB4-SAOPAULO   PIC  X(008) VALUE '25011993'.*/
                public StringBasis WTB4_SAOPAULO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25011993");
                /*"    05          WTB4-CARNAVAL   PIC  X(008) VALUE '23021993'.*/
                public StringBasis WTB4_CARNAVAL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"23021993");
                /*"    05          WTB4-PAIXAO     PIC  X(008) VALUE '09041993'.*/
                public StringBasis WTB4_PAIXAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"09041993");
                /*"    05          WTB4-TIRADEN    PIC  X(008) VALUE '21041993'.*/
                public StringBasis WTB4_TIRADEN { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21041993");
                /*"    05          WTB4-TRABALHO   PIC  X(008) VALUE '01051993'.*/
                public StringBasis WTB4_TRABALHO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01051993");
                /*"    05          WTB4-CORPUS     PIC  X(008) VALUE '10061993'.*/
                public StringBasis WTB4_CORPUS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"10061993");
                /*"    05          WTB4-INDEPENDEN PIC  X(008) VALUE '07091993'.*/
                public StringBasis WTB4_INDEPENDEN { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07091993");
                /*"    05          WTB4-PADROEIRA  PIC  X(008) VALUE '12101993'.*/
                public StringBasis WTB4_PADROEIRA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12101993");
                /*"    05          WTB4-SECURITARI PIC  X(008) VALUE '18101993'.*/
                public StringBasis WTB4_SECURITARI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"18101993");
                /*"    05          WTB4-FINADOS    PIC  X(008) VALUE '02111993'.*/
                public StringBasis WTB4_FINADOS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02111993");
                /*"    05          WTB4-REPUBLICA  PIC  X(008) VALUE '15111993'.*/
                public StringBasis WTB4_REPUBLICA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15111993");
                /*"    05          WTB4-NATAL      PIC  X(008) VALUE '25121993'.*/
                public StringBasis WTB4_NATAL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25121993");
                /*"    05          WTB4-ULTIMO     PIC  X(008) VALUE '31121993'.*/
                public StringBasis WTB4_ULTIMO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31121993");
                /*"    05          WTB4-PRIMEIROY  PIC  X(008) VALUE '01011994'.*/
                public StringBasis WTB4_PRIMEIROY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01011994");
                /*"    05          WTB4-DIACOMP1Y  PIC  X(008) VALUE '24011994'.*/
                public StringBasis WTB4_DIACOMP1Y { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"24011994");
                /*"    05          WTB4-SAOPAULOY  PIC  X(008) VALUE '25011994'.*/
                public StringBasis WTB4_SAOPAULOY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25011994");
                /*"    05          WTB4-DIACOMP2Y  PIC  X(008) VALUE '14021994'.*/
                public StringBasis WTB4_DIACOMP2Y { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"14021994");
                /*"    05          WTB4-CARNAVALY  PIC  X(008) VALUE '15021994'.*/
                public StringBasis WTB4_CARNAVALY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15021994");
                /*"    05          WTB4-PTFACUY    PIC  X(008) VALUE '31031994'.*/
                public StringBasis WTB4_PTFACUY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31031994");
                /*"    05          WTB4-PAIXAOY    PIC  X(008) VALUE '01041994'.*/
                public StringBasis WTB4_PAIXAOY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01041994");
                /*"    05          WTB4-TIRADENY   PIC  X(008) VALUE '21041994'.*/
                public StringBasis WTB4_TIRADENY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21041994");
                /*"    05          WTB4-DIACOMP3Y  PIC  X(008) VALUE '22041994'.*/
                public StringBasis WTB4_DIACOMP3Y { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"22041994");
                /*"    05          WTB4-TRABALHOY  PIC  X(008) VALUE '01051994'.*/
                public StringBasis WTB4_TRABALHOY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01051994");
                /*"    05          WTB4-CORPUSY    PIC  X(008) VALUE '02061994'.*/
                public StringBasis WTB4_CORPUSY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02061994");
                /*"    05          WTB4-DIACOMP4Y  PIC  X(008) VALUE '03061994'.*/
                public StringBasis WTB4_DIACOMP4Y { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"03061994");
                /*"    05          WTB4-INDEPENDEY PIC  X(008) VALUE '07091994'.*/
                public StringBasis WTB4_INDEPENDEY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07091994");
                /*"    05          WTB4-PADROEIRAY PIC  X(008) VALUE '12101994'.*/
                public StringBasis WTB4_PADROEIRAY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12101994");
                /*"    05          WTB4-SECURITARY PIC  X(008) VALUE '18101994'.*/
                public StringBasis WTB4_SECURITARY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"18101994");
                /*"    05          WTB4-FINADOSY   PIC  X(008) VALUE '02111994'.*/
                public StringBasis WTB4_FINADOSY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02111994");
                /*"    05          WTB4-DIACOMP5Y  PIC  X(008) VALUE '14111994'.*/
                public StringBasis WTB4_DIACOMP5Y { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"14111994");
                /*"    05          WTB4-REPUBLICAY PIC  X(008) VALUE '15111994'.*/
                public StringBasis WTB4_REPUBLICAY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15111994");
                /*"    05          WTB4-NATALY     PIC  X(008) VALUE '25121994'.*/
                public StringBasis WTB4_NATALY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25121994");
                /*"    05          WTB4-ULTIMOY    PIC  X(008) VALUE '31121994'.*/
                public StringBasis WTB4_ULTIMOY { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31121994");
                /*"  03            FILLER          REDEFINES                WTB04-DIAS-FERIADOS.*/
            }
            private _REDEF_PROSOCU2_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PROSOCU2_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PROSOCU2_FILLER_6(); _.Move(WTB04_DIAS_FERIADOS, _filler_6); VarBasis.RedefinePassValue(WTB04_DIAS_FERIADOS, _filler_6, WTB04_DIAS_FERIADOS); _filler_6.ValueChanged += () => { _.Move(_filler_6, WTB04_DIAS_FERIADOS); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WTB04_DIAS_FERIADOS); }
            }  //Redefines
            public class _REDEF_PROSOCU2_FILLER_6 : VarBasis
            {
                /*"    05          WTB4-FER        OCCURS      47                                PIC  9(008).*/
                public ListBasis<IntBasis, Int64> WTB4_FER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)."), 47);
                /*"01              LPARM.*/

                public _REDEF_PROSOCU2_FILLER_6()
                {
                    WTB4_FER.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROSOCU2_LPARM LPARM { get; set; } = new PROSOCU2_LPARM();
        public class PROSOCU2_LPARM : VarBasis
        {
            /*"    03          DATA1.*/
            public PROSOCU2_DATA1 DATA1 { get; set; } = new PROSOCU2_DATA1();
            public class PROSOCU2_DATA1 : VarBasis
            {
                /*"       05       DATA1-DD        PIC  9(002).*/
                public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA1-MM        PIC  9(002).*/
                public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA1-AA        PIC  9(004).*/
                public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          NDIAS           PIC S9(005)      COMP-3.*/
            }
            public IntBasis NDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    03          DATA3.*/
            public PROSOCU2_DATA3 DATA3 { get; set; } = new PROSOCU2_DATA3();
            public class PROSOCU2_DATA3 : VarBasis
            {
                /*"       05       DATA3-DD        PIC  9(002).*/
                public IntBasis DATA3_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA3-MM        PIC  9(002).*/
                public IntBasis DATA3_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA3-AA        PIC  9(004).*/
                public IntBasis DATA3_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROSOCU2_LPARM PROSOCU2_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROSOCU2_LPARM_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -190- PERFORM 000-010-INICIALIZA-PARAMETROS. */

            M_000_010_INICIALIZA_PARAMETROS_SECTION();

            /*" -191- PERFORM 000-020-CONSISTENCIA-DATA. */

            M_000_020_CONSISTENCIA_DATA_SECTION();

            /*" -192- PERFORM 000-030-CONVERTE-EM-NNNNN-DIAS. */

            M_000_030_CONVERTE_EM_NNNNN_DIAS_SECTION();

            /*" -193- PERFORM 000-040-SOMA-NN-DIAS. */

            M_000_040_SOMA_NN_DIAS_SECTION();

            /*" -194- PERFORM 000-045-TESTE-PERIODO-SECULO. */

            M_000_045_TESTE_PERIODO_SECULO_SECTION();

            /*" -195- PERFORM 000-050-VERIFICA-DIA-UTIL. */

            M_000_050_VERIFICA_DIA_UTIL_SECTION();

            /*" -196- PERFORM 000-055-TESTE-PERIODO-SECULO. */

            M_000_055_TESTE_PERIODO_SECULO_SECTION();

            /*" -197- PERFORM 000-060-VERIFICA-FERIADO. */

            M_000_060_VERIFICA_FERIADO_SECTION();

            /*" -198- PERFORM 000-065-TESTE-PERIODO-SECULO. */

            M_000_065_TESTE_PERIODO_SECULO_SECTION();

            /*" -199- PERFORM 000-070-VERIFICA-SOMADI. */

            M_000_070_VERIFICA_SOMADI_SECTION();

            /*" -200- PERFORM 000-080-VERIFICA-DIA-UTIL. */

            M_000_080_VERIFICA_DIA_UTIL_SECTION();

            /*" -201- PERFORM 000-085-TESTE-PERIODO-SECULO. */

            M_000_085_TESTE_PERIODO_SECULO_SECTION();

            /*" -201- PERFORM 000-100-CONVERTE-DATA3 */

            M_000_100_CONVERTE_DATA3_SECTION();

        }

        [StopWatch]
        /*" M-000-010-INICIALIZA-PARAMETROS-SECTION */
        private void M_000_010_INICIALIZA_PARAMETROS_SECTION()
        {
            /*" -208- PERFORM 800-000-INICIALIZA-PARAMETROS. */

            M_800_000_INICIALIZA_PARAMETROS_SECTION();

        }

        [StopWatch]
        /*" M-000-020-CONSISTENCIA-DATA-SECTION */
        private void M_000_020_CONSISTENCIA_DATA_SECTION()
        {
            /*" -219- IF DATA1 NOT NUMERIC OR NDIAS NOT NUMERIC OR DATA1-MM LESS 1 OR DATA1-MM GREATER 12 */

            if (!LPARM.DATA1.IsNumeric() || !LPARM.NDIAS.IsNumeric() || LPARM.DATA1.DATA1_MM < 1 || LPARM.DATA1.DATA1_MM > 12)
            {

                /*" -222- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -224- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -226- DIVIDE DATA1-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.DATA1.DATA1_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -227- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -229- MOVE +29 TO WTB02(2). */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);
            }


            /*" -231- IF DATA1-DD LESS 1 OR DATA1-DD GREATER WTB02(DATA1-MM) */

            if (LPARM.DATA1.DATA1_DD < 1 || LPARM.DATA1.DATA1_DD > FILLER_1.FILLER_3.WTB02[LPARM.DATA1.DATA1_MM])
            {

                /*" -234- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -234- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-030-CONVERTE-EM-NNNNN-DIAS-SECTION */
        private void M_000_030_CONVERTE_EM_NNNNN_DIAS_SECTION()
        {
            /*" -243- MULTIPLY 365,25 BY DATA1-AA GIVING WDIAS. */
            _.Multiply(365.25, LPARM.DATA1.DATA1_AA, FILLER_0.WDIAS);

            /*" -244- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -245- MOVE +29 TO WTB02(2) */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);

                /*" -255- ADD +1 TO WTB01(3) WTB01(4) WTB01(5) WTB01(6) WTB01(7) WTB01(8) WTB01(9) WTB01(10) WTB01(11) WTB01(12) */
                FILLER_1.FILLER_2.WTB01[3].Value = FILLER_1.FILLER_2.WTB01[3] + +1;
                FILLER_1.FILLER_2.WTB01[4].Value = FILLER_1.FILLER_2.WTB01[4] + +1;
                FILLER_1.FILLER_2.WTB01[5].Value = FILLER_1.FILLER_2.WTB01[5] + +1;
                FILLER_1.FILLER_2.WTB01[6].Value = FILLER_1.FILLER_2.WTB01[6] + +1;
                FILLER_1.FILLER_2.WTB01[7].Value = FILLER_1.FILLER_2.WTB01[7] + +1;
                FILLER_1.FILLER_2.WTB01[8].Value = FILLER_1.FILLER_2.WTB01[8] + +1;
                FILLER_1.FILLER_2.WTB01[9].Value = FILLER_1.FILLER_2.WTB01[9] + +1;
                FILLER_1.FILLER_2.WTB01[10].Value = FILLER_1.FILLER_2.WTB01[10] + +1;
                FILLER_1.FILLER_2.WTB01[11].Value = FILLER_1.FILLER_2.WTB01[11] + +1;
                FILLER_1.FILLER_2.WTB01[12].Value = FILLER_1.FILLER_2.WTB01[12] + +1;

                /*" -256- ELSE */
            }
            else
            {


                /*" -258- ADD +1 TO WDIAS. */
                FILLER_0.WDIAS.Value = FILLER_0.WDIAS + +1;
            }


            /*" -259- ADD WTB01(DATA1-MM) DATA1-DD TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + LPARM.DATA1.DATA1_DD;

        }

        [StopWatch]
        /*" M-000-040-SOMA-NN-DIAS-SECTION */
        private void M_000_040_SOMA_NN_DIAS_SECTION()
        {
            /*" -265- ADD NDIAS TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + LPARM.NDIAS;

        }

        [StopWatch]
        /*" M-000-045-TESTE-PERIODO-SECULO-SECTION */
        private void M_000_045_TESTE_PERIODO_SECULO_SECTION()
        {
            /*" -273- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -276- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -276- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-050-VERIFICA-DIA-UTIL-SECTION */
        private void M_000_050_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -283- PERFORM 500-000-VERIFICA-DIA-UTIL. */

            M_500_000_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-000-055-TESTE-PERIODO-SECULO-SECTION */
        private void M_000_055_TESTE_PERIODO_SECULO_SECTION()
        {
            /*" -289- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -292- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -292- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-060-VERIFICA-FERIADO-SECTION */
        private void M_000_060_VERIFICA_FERIADO_SECTION()
        {
            /*" -299- PERFORM 700-000-CONVERTE-NNNNN-EM-DATA. */

            M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION();

            /*" -301- PERFORM 600-000-VERIFICA-FERIADOS. */

            M_600_000_VERIFICA_FERIADOS_SECTION();

            /*" -302- IF WX05 GREATER 47 */

            if (FILLER_0.WX05 > 47)
            {

                /*" -307- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -309- ADD 1 TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 1;

            /*" -310- PERFORM 700-000-CONVERTE-NNNNN-EM-DATA. */

            M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION();

            /*" -312- PERFORM 600-000-VERIFICA-FERIADOS. */

            M_600_000_VERIFICA_FERIADOS_SECTION();

            /*" -313- IF WX05 GREATER 47 */

            if (FILLER_0.WX05 > 47)
            {

                /*" -314- PERFORM 500-000-VERIFICA-DIA-UTIL */

                M_500_000_VERIFICA_DIA_UTIL_SECTION();

                /*" -315- PERFORM 700-000-CONVERTE-NNNNN-EM-DATA */

                M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION();

                /*" -320- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -322- ADD 1 TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 1;

            /*" -322- PERFORM 500-000-VERIFICA-DIA-UTIL. */

            M_500_000_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-000-065-TESTE-PERIODO-SECULO-SECTION */
        private void M_000_065_TESTE_PERIODO_SECULO_SECTION()
        {
            /*" -328- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -331- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -331- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-070-VERIFICA-SOMADI-SECTION */
        private void M_000_070_VERIFICA_SOMADI_SECTION()
        {
            /*" -338- IF WSOMADI GREATER 0 */

            if (FILLER_0.WSOMADI > 0)
            {

                /*" -338- GO TO 000-100-CONVERTE-DATA3. */

                M_000_100_CONVERTE_DATA3_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-080-VERIFICA-DIA-UTIL-SECTION */
        private void M_000_080_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -345- PERFORM 500-000-VERIFICA-DIA-UTIL. */

            M_500_000_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-000-085-TESTE-PERIODO-SECULO-SECTION */
        private void M_000_085_TESTE_PERIODO_SECULO_SECTION()
        {
            /*" -351- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -354- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -354- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-100-CONVERTE-DATA3-SECTION */
        private void M_000_100_CONVERTE_DATA3_SECTION()
        {
            /*" -360- PERFORM 800-000-INICIALIZA-PARAMETROS. */

            M_800_000_INICIALIZA_PARAMETROS_SECTION();

            /*" -361- PERFORM 700-000-CONVERTE-NNNNN-EM-DATA. */

            M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION();

            /*" -361- GO TO 900-000-RETORNA. */

            M_900_000_RETORNA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_SAIDA*/

        [StopWatch]
        /*" M-500-000-VERIFICA-DIA-UTIL-SECTION */
        private void M_500_000_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -369- PERFORM 500-010-CALCULA-DIA-SEMANA. */

            M_500_010_CALCULA_DIA_SEMANA_SECTION();

            /*" -369- PERFORM 500-020-VERIFICA-DIA-UTIL. */

            M_500_020_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-500-010-CALCULA-DIA-SEMANA-SECTION */
        private void M_500_010_CALCULA_DIA_SEMANA_SECTION()
        {
            /*" -379- DIVIDE WDIAS BY 7 GIVING WQUOCIENTE REMAINDER WDSEM. */
            _.Divide(FILLER_0.WDIAS, 7, FILLER_0.WQUOCIENTE, FILLER_0.WDSEM);

        }

        [StopWatch]
        /*" M-500-020-VERIFICA-DIA-UTIL-SECTION */
        private void M_500_020_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -389- IF WDSEM EQUAL 0 */

            if (FILLER_0.WDSEM == 0)
            {

                /*" -390- ADD 2 TO WDIAS */
                FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 2;

                /*" -391- ADD 2 TO WSOMADI */
                FILLER_0.WSOMADI.Value = FILLER_0.WSOMADI + 2;

                /*" -392- ELSE */
            }
            else
            {


                /*" -393- IF WDSEM EQUAL 1 */

                if (FILLER_0.WDSEM == 1)
                {

                    /*" -394- ADD 1 TO WDIAS */
                    FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 1;

                    /*" -394- ADD 1 TO WSOMADI. */
                    FILLER_0.WSOMADI.Value = FILLER_0.WSOMADI + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_SAIDA*/

        [StopWatch]
        /*" M-600-000-VERIFICA-FERIADOS-SECTION */
        private void M_600_000_VERIFICA_FERIADOS_SECTION()
        {
            /*" -410- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_600_010_VERIFICA_FER */

            M_600_010_VERIFICA_FER();

        }

        [StopWatch]
        /*" M-600-010-VERIFICA-FER */
        private void M_600_010_VERIFICA_FER(bool isPerform = false)
        {
            /*" -412- MOVE ZEROS TO WX05. */
            _.Move(0, FILLER_0.WX05);

        }

        [StopWatch]
        /*" M-600-020-VER */
        private void M_600_020_VER(bool isPerform = false)
        {
            /*" -418- ADD 1 TO WX05 */
            FILLER_0.WX05.Value = FILLER_0.WX05 + 1;

            /*" -419- IF WX05 GREATER 47 */

            if (FILLER_0.WX05 > 47)
            {

                /*" -421- GO TO 600-999-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_SAIDA*/ //GOTO
                return;
            }


            /*" -422- IF DATA3 NOT EQUAL WTB4-FER(WX05) */

            if (LPARM.DATA3 != FILLER_5.FILLER_6.WTB4_FER[FILLER_0.WX05])
            {

                /*" -422- GO TO 600-020-VER. */
                new Task(() => M_600_020_VER()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_SAIDA*/

        [StopWatch]
        /*" M-700-000-CONVERTE-NNNNN-EM-DATA-SECTION */
        private void M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION()
        {
            /*" -434- DIVIDE WDIAS BY 365,25 GIVING WANOS REMAINDER WDIASREST */
            _.Divide(FILLER_0.WDIAS, 365.25, FILLER_0.WANOS, FILLER_0.WDIASREST);

            /*" -435- IF WDIASREST EQUAL ZEROS */

            if (FILLER_0.WDIASREST == 00)
            {

                /*" -437- SUBTRACT 1 FROM WANOS GIVING DATA3-AA */
                LPARM.DATA3.DATA3_AA.Value = FILLER_0.WANOS - 1;

                /*" -438- MOVE 12 TO DATA3-MM */
                _.Move(12, LPARM.DATA3.DATA3_MM);

                /*" -439- MOVE 31 TO DATA3-DD */
                _.Move(31, LPARM.DATA3.DATA3_DD);

                /*" -440- GO TO 700-999-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_999_SAIDA*/ //GOTO
                return;
            }


            /*" -442- MOVE WANOS TO DATA3-AA. */
            _.Move(FILLER_0.WANOS, LPARM.DATA3.DATA3_AA);

            /*" -445- DIVIDE DATA3-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.DATA3.DATA3_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -446- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -456- ADD +1 TO WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12) */
                FILLER_1.FILLER_4.WTB03[3].Value = FILLER_1.FILLER_4.WTB03[3] + +1;
                FILLER_1.FILLER_4.WTB03[4].Value = FILLER_1.FILLER_4.WTB03[4] + +1;
                FILLER_1.FILLER_4.WTB03[5].Value = FILLER_1.FILLER_4.WTB03[5] + +1;
                FILLER_1.FILLER_4.WTB03[6].Value = FILLER_1.FILLER_4.WTB03[6] + +1;
                FILLER_1.FILLER_4.WTB03[7].Value = FILLER_1.FILLER_4.WTB03[7] + +1;
                FILLER_1.FILLER_4.WTB03[8].Value = FILLER_1.FILLER_4.WTB03[8] + +1;
                FILLER_1.FILLER_4.WTB03[9].Value = FILLER_1.FILLER_4.WTB03[9] + +1;
                FILLER_1.FILLER_4.WTB03[10].Value = FILLER_1.FILLER_4.WTB03[10] + +1;
                FILLER_1.FILLER_4.WTB03[11].Value = FILLER_1.FILLER_4.WTB03[11] + +1;
                FILLER_1.FILLER_4.WTB03[12].Value = FILLER_1.FILLER_4.WTB03[12] + +1;

                /*" -458- MOVE 1 TO WSOMBISXTO. */
                _.Move(1, FILLER_0.WSOMBISXTO);
            }


            /*" -459- SET I03 TO 1. */
            I03.Value = 1;

            /*" -461- SEARCH WTB03 AT END */
            void SearchAtEnd0()
            {

                /*" -462- MOVE 12 TO DATA3-MM */
                _.Move(12, LPARM.DATA3.DATA3_MM);

                /*" -464- SUBTRACT WTB03 (12) FROM WDIASREST GIVING DATA3-DD */
                LPARM.DATA3.DATA3_DD.Value = FILLER_0.WDIASREST - FILLER_1.FILLER_4.WTB03[12];

                /*" -466- WHEN WTB03 (I03) NOT LESS WDIASREST */
            };

            var mustSearchAtEnd0 = true;
            for (; I03 < FILLER_1.FILLER_4.WTB03.Items.Count; I03.Value++)
            {

                if (FILLER_1.FILLER_4.WTB03[I03] >= FILLER_0.WDIASREST)
                {

                    mustSearchAtEnd0 = false;

                    /*" -467- SET I03 DOWN BY 1 */
                    I03.Value -= 1;

                    /*" -468- SET DATA3-MM TO I03 */
                    LPARM.DATA3.DATA3_MM.Value = I03;

                    /*" -471- SUBTRACT WTB03 (I03) FROM WDIASREST GIVING DATA3-DD */
                    LPARM.DATA3.DATA3_DD.Value = FILLER_0.WDIASREST - FILLER_1.FILLER_4.WTB03[I03];

                    /*" -472- IF WSOMBISXTO = 1 */

                    if (FILLER_0.WSOMBISXTO == 1)
                    {

                        /*" -482- SUBTRACT +1 FROM WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12) */
                        FILLER_1.FILLER_4.WTB03[3].Value = FILLER_1.FILLER_4.WTB03[3] - +1;
                        FILLER_1.FILLER_4.WTB03[4].Value = FILLER_1.FILLER_4.WTB03[4] - +1;
                        FILLER_1.FILLER_4.WTB03[5].Value = FILLER_1.FILLER_4.WTB03[5] - +1;
                        FILLER_1.FILLER_4.WTB03[6].Value = FILLER_1.FILLER_4.WTB03[6] - +1;
                        FILLER_1.FILLER_4.WTB03[7].Value = FILLER_1.FILLER_4.WTB03[7] - +1;
                        FILLER_1.FILLER_4.WTB03[8].Value = FILLER_1.FILLER_4.WTB03[8] - +1;
                        FILLER_1.FILLER_4.WTB03[9].Value = FILLER_1.FILLER_4.WTB03[9] - +1;
                        FILLER_1.FILLER_4.WTB03[10].Value = FILLER_1.FILLER_4.WTB03[10] - +1;
                        FILLER_1.FILLER_4.WTB03[11].Value = FILLER_1.FILLER_4.WTB03[11] - +1;
                        FILLER_1.FILLER_4.WTB03[12].Value = FILLER_1.FILLER_4.WTB03[12] - +1;

                        /*" -482- MOVE 0 TO WSOMBISXTO  END-SEARCH. */
                    }

                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_999_SAIDA*/

        [StopWatch]
        /*" M-800-000-INICIALIZA-PARAMETROS-SECTION */
        private void M_800_000_INICIALIZA_PARAMETROS_SECTION()
        {
            /*" -493- MOVE +0 TO WQUOCIENTE */
            _.Move(+0, FILLER_0.WQUOCIENTE);

            /*" -494- MOVE +0 TO WRESTO */
            _.Move(+0, FILLER_0.WRESTO);

            /*" -495- MOVE +0 TO WDIASREST */
            _.Move(+0, FILLER_0.WDIASREST);

            /*" -496- MOVE +0 TO WANOS */
            _.Move(+0, FILLER_0.WANOS);

            /*" -497- MOVE +0 TO WDIAS01 */
            _.Move(+0, FILLER_0.WDIAS01);

            /*" -499- MOVE +0 TO WSOMADI */
            _.Move(+0, FILLER_0.WSOMADI);

            /*" -500- MOVE +0 TO WTB1-1 */
            _.Move(+0, FILLER_1.WTB01_DIAS_JULIANO.WTB1_1);

            /*" -501- MOVE +31 TO WTB1-2 */
            _.Move(+31, FILLER_1.WTB01_DIAS_JULIANO.WTB1_2);

            /*" -502- MOVE +59 TO WTB1-3 */
            _.Move(+59, FILLER_1.WTB01_DIAS_JULIANO.WTB1_3);

            /*" -503- MOVE +90 TO WTB1-4 */
            _.Move(+90, FILLER_1.WTB01_DIAS_JULIANO.WTB1_4);

            /*" -504- MOVE +120 TO WTB1-5 */
            _.Move(+120, FILLER_1.WTB01_DIAS_JULIANO.WTB1_5);

            /*" -505- MOVE +151 TO WTB1-6 */
            _.Move(+151, FILLER_1.WTB01_DIAS_JULIANO.WTB1_6);

            /*" -506- MOVE +181 TO WTB1-7 */
            _.Move(+181, FILLER_1.WTB01_DIAS_JULIANO.WTB1_7);

            /*" -507- MOVE +212 TO WTB1-8 */
            _.Move(+212, FILLER_1.WTB01_DIAS_JULIANO.WTB1_8);

            /*" -508- MOVE +243 TO WTB1-9 */
            _.Move(+243, FILLER_1.WTB01_DIAS_JULIANO.WTB1_9);

            /*" -509- MOVE +273 TO WTB1-10 */
            _.Move(+273, FILLER_1.WTB01_DIAS_JULIANO.WTB1_10);

            /*" -510- MOVE +304 TO WTB1-11 */
            _.Move(+304, FILLER_1.WTB01_DIAS_JULIANO.WTB1_11);

            /*" -512- MOVE +334 TO WTB1-12 */
            _.Move(+334, FILLER_1.WTB01_DIAS_JULIANO.WTB1_12);

            /*" -514- MOVE +28 TO WTB2-2 */
            _.Move(+28, FILLER_1.WTB02_DIAS_MES.WTB2_2);

            /*" -515- MOVE +0 TO WTB3-1 */
            _.Move(+0, FILLER_1.WTB03_DIAS_JULIANO.WTB3_1);

            /*" -516- MOVE +31 TO WTB3-2 */
            _.Move(+31, FILLER_1.WTB03_DIAS_JULIANO.WTB3_2);

            /*" -517- MOVE +59 TO WTB3-3 */
            _.Move(+59, FILLER_1.WTB03_DIAS_JULIANO.WTB3_3);

            /*" -518- MOVE +90 TO WTB3-4 */
            _.Move(+90, FILLER_1.WTB03_DIAS_JULIANO.WTB3_4);

            /*" -519- MOVE +120 TO WTB3-5 */
            _.Move(+120, FILLER_1.WTB03_DIAS_JULIANO.WTB3_5);

            /*" -520- MOVE +151 TO WTB3-6 */
            _.Move(+151, FILLER_1.WTB03_DIAS_JULIANO.WTB3_6);

            /*" -521- MOVE +181 TO WTB3-7 */
            _.Move(+181, FILLER_1.WTB03_DIAS_JULIANO.WTB3_7);

            /*" -522- MOVE +212 TO WTB3-8 */
            _.Move(+212, FILLER_1.WTB03_DIAS_JULIANO.WTB3_8);

            /*" -523- MOVE +243 TO WTB3-9 */
            _.Move(+243, FILLER_1.WTB03_DIAS_JULIANO.WTB3_9);

            /*" -524- MOVE +273 TO WTB3-10 */
            _.Move(+273, FILLER_1.WTB03_DIAS_JULIANO.WTB3_10);

            /*" -525- MOVE +304 TO WTB3-11 */
            _.Move(+304, FILLER_1.WTB03_DIAS_JULIANO.WTB3_11);

            /*" -525- MOVE +334 TO WTB3-12. */
            _.Move(+334, FILLER_1.WTB03_DIAS_JULIANO.WTB3_12);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_SAIDA*/

        [StopWatch]
        /*" M-900-000-RETORNA-SECTION */
        private void M_900_000_RETORNA_SECTION()
        {
            /*" -534- GOBACK. */

            throw new GoBack();

        }
    }
}