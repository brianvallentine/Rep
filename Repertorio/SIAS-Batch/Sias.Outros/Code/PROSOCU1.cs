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
    public class PROSOCU1
    {
        public bool IsCall { get; set; }

        public PROSOCU1()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *REMARKS      MODIFICADO POR FLAVIO  EM 13/02/97                        */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  PARA INCLUIR NOVAS OCORRENCIAS DE FERIADO, ADICIONAR AS DATAS *      */
        /*"      *  NA TABELA INTERNA WTB04-DIAS-FERIADOS E VERIFICAR TODAS AS    *      */
        /*"      *  LINHAS COM O COMENTARIO "EDU>>>"                              *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROSOCU1   (SUBROTINA)             *      */
        /*"      *                                                                *      */
        /*"      *   AMBIENTE................  MVS-ESA/CICS-ESA/CSP-AE            *      */
        /*"      *                                     COBOL2                     *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  SOMAR NN DIAS A UMA DATA DDMMAAAA  *      */
        /*"      *                             E OBTER RESULTADO DATA DDMMAAAA    *      */
        /*"      *                             SE ESTA NAO FOR DIA UTIL CONTINUA  *      */
        /*"      *                             INCREMENTANDO DE 1 EM 1 ATE O PRI- *      */
        /*"      *                             MEIRO DIA UTIL APOS O RESULTADO..  *      */
        /*"      *                             OU SEJA ... OBTER O PROXIMO DIA    *      */
        /*"      *                             UTIL APOS NN  DIAS                 *      */
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
        /*"      * ALTERADO EM 13/02/97 - FLAVIO                                  *      */
        /*"      *                                                                *      */
        /*"      *   ATUALIZACAO DA TABELA DE FERIADOS PARA OS ANOS 1997 E 1998   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 06/01/1998.   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 28/01/99 - FONSECA                                 *      */
        /*"      *                                                                *      */
        /*"      *   ATUALIZACAO DA TABELA DE FERIADOS PARA OS ANOS 1999 E 2000   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 06/12/02 - EDUARDO (PRODEXTER)                     *      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO PARA CONSIDERAR O DIA 06/12/2002 COMO FERIADO       *      */
        /*"      *   (DEVIDO AO PROBLEMA DE ENERGIA ELETRICA NO CPD, NAO HOUVE    *      */
        /*"      *    ROTINA DIARIA PARA O DIA 05/12/2002, E ESTE CONTINUOU EM    *      */
        /*"      *    ABERTO ATE' DIA 07/06/2002) >>>>> VIDE WTB4-ESPECIAL        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 06/01/03 - EDUARDO (PRODEXTER)                     *      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO PARA INCLUIR OS FERIADOS PARA 2003                  *      */
        /*"      *                                                                *      */
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
        public PROSOCU1_FILLER_0 FILLER_0 { get; set; } = new PROSOCU1_FILLER_0();
        public class PROSOCU1_FILLER_0 : VarBasis
        {
            /*"  03            WSOMADI         PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WSOMADI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDSEM           PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WDSEM { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WX05            PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WX05 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIAS01         PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS01 { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WQUOCIENTE      PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WRESTO          PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIASREST       PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIASREST { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WANOS           PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WANOS { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WDIAS           PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WSOMBISXTO      PIC  9(001)         VALUE  ZEROS*/
            public IntBasis WSOMBISXTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01              FILLER.*/
        }
        public PROSOCU1_FILLER_1 FILLER_1 { get; set; } = new PROSOCU1_FILLER_1();
        public class PROSOCU1_FILLER_1 : VarBasis
        {
            /*"  03            WTB01-DIAS-JULIANO.*/
            public PROSOCU1_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PROSOCU1_WTB01_DIAS_JULIANO();
            public class PROSOCU1_WTB01_DIAS_JULIANO : VarBasis
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
            private _REDEF_PROSOCU1_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PROSOCU1_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PROSOCU1_FILLER_2(); _.Move(WTB01_DIAS_JULIANO, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_2, WTB01_DIAS_JULIANO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_JULIANO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROSOCU1_FILLER_2 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB02-DIAS-MES.*/

                public _REDEF_PROSOCU1_FILLER_2()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
            public PROSOCU1_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PROSOCU1_WTB02_DIAS_MES();
            public class PROSOCU1_WTB02_DIAS_MES : VarBasis
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
            private _REDEF_PROSOCU1_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PROSOCU1_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PROSOCU1_FILLER_3(); _.Move(WTB02_DIAS_MES, _filler_3); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_3, WTB02_DIAS_MES); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB02_DIAS_MES); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WTB02_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PROSOCU1_FILLER_3 : VarBasis
            {
                /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB03-DIAS-JULIANO.*/

                public _REDEF_PROSOCU1_FILLER_3()
                {
                    WTB02.ValueChanged += OnValueChanged;
                }

            }
            public PROSOCU1_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PROSOCU1_WTB03_DIAS_JULIANO();
            public class PROSOCU1_WTB03_DIAS_JULIANO : VarBasis
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
            private _REDEF_PROSOCU1_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PROSOCU1_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PROSOCU1_FILLER_4(); _.Move(WTB03_DIAS_JULIANO, _filler_4); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_4, WTB03_DIAS_JULIANO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB03_DIAS_JULIANO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTB03_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROSOCU1_FILLER_4 : VarBasis
            {
                /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              FILLER.*/

                public _REDEF_PROSOCU1_FILLER_4()
                {
                    WTB03.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROSOCU1_FILLER_5 FILLER_5 { get; set; } = new PROSOCU1_FILLER_5();
        public class PROSOCU1_FILLER_5 : VarBasis
        {
            /*"  03            WTB04-DIAS-FERIADOS.*/
            public PROSOCU1_WTB04_DIAS_FERIADOS WTB04_DIAS_FERIADOS { get; set; } = new PROSOCU1_WTB04_DIAS_FERIADOS();
            public class PROSOCU1_WTB04_DIAS_FERIADOS : VarBasis
            {
                /*"    05          WTB4-PRIMEIRO1  PIC  X(008) VALUE '01011999'.*/
                public StringBasis WTB4_PRIMEIRO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01011999");
                /*"    05          WTB4-CARNASEG1  PIC  X(008) VALUE '15021999'.*/
                public StringBasis WTB4_CARNASEG1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15021999");
                /*"    05          WTB4-CARNAVAL1  PIC  X(008) VALUE '16021999'.*/
                public StringBasis WTB4_CARNAVAL1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"16021999");
                /*"    05          WTB4-PAIXAO1    PIC  X(008) VALUE '02041999'.*/
                public StringBasis WTB4_PAIXAO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02041999");
                /*"    05          WTB4-TIRADEN1   PIC  X(008) VALUE '21041999'.*/
                public StringBasis WTB4_TIRADEN1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21041999");
                /*"    05          WTB4-TRABALHO1  PIC  X(008) VALUE '01051999'.*/
                public StringBasis WTB4_TRABALHO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01051999");
                /*"    05          WTB4-CORPUS1    PIC  X(008) VALUE '03061999'.*/
                public StringBasis WTB4_CORPUS1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"03061999");
                /*"    05          WTB4-INDEPENDE1 PIC  X(008) VALUE '07091999'.*/
                public StringBasis WTB4_INDEPENDE1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07091999");
                /*"    05          WTB4-PADROEIRA1 PIC  X(008) VALUE '12101999'.*/
                public StringBasis WTB4_PADROEIRA1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12101999");
                /*"    05          WTB4-FINADOS1   PIC  X(008) VALUE '02111999'.*/
                public StringBasis WTB4_FINADOS1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02111999");
                /*"    05          WTB4-REPUBLICA1 PIC  X(008) VALUE '15111999'.*/
                public StringBasis WTB4_REPUBLICA1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15111999");
                /*"    05          WTB4-NATAL1     PIC  X(008) VALUE '25121999'.*/
                public StringBasis WTB4_NATAL1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25121999");
                /*"    05          WTB4-PRIMEIRO2  PIC  X(008) VALUE '01012000'.*/
                public StringBasis WTB4_PRIMEIRO2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012000");
                /*"    05          WTB4-CARNASEG2  PIC  X(008) VALUE '06032000'.*/
                public StringBasis WTB4_CARNASEG2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"06032000");
                /*"    05          WTB4-CARNAVAL2  PIC  X(008) VALUE '07032000'.*/
                public StringBasis WTB4_CARNAVAL2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07032000");
                /*"    05          WTB4-PAIXAO2    PIC  X(008) VALUE '21042000'.*/
                public StringBasis WTB4_PAIXAO2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042000");
                /*"    05          WTB4-TIRADEN2   PIC  X(008) VALUE '21042000'.*/
                public StringBasis WTB4_TIRADEN2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042000");
                /*"    05          WTB4-TRABALHO2  PIC  X(008) VALUE '01052000'.*/
                public StringBasis WTB4_TRABALHO2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052000");
                /*"    05          WTB4-CORPUS2    PIC  X(008) VALUE '22062000'.*/
                public StringBasis WTB4_CORPUS2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"22062000");
                /*"    05          WTB4-INDEPENDE2 PIC  X(008) VALUE '07092000'.*/
                public StringBasis WTB4_INDEPENDE2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092000");
                /*"    05          WTB4-PADROEIRA2 PIC  X(008) VALUE '12102000'.*/
                public StringBasis WTB4_PADROEIRA2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102000");
                /*"    05          WTB4-FINADOS2   PIC  X(008) VALUE '02112000'.*/
                public StringBasis WTB4_FINADOS2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112000");
                /*"    05          WTB4-REPUBLICA2 PIC  X(008) VALUE '15112000'.*/
                public StringBasis WTB4_REPUBLICA2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112000");
                /*"    05          WTB4-NATAL2     PIC  X(008) VALUE '25122000'.*/
                public StringBasis WTB4_NATAL2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122000");
                /*"    05          WTB4-PRIMEIRO3  PIC  X(008) VALUE '01012001'.*/
                public StringBasis WTB4_PRIMEIRO3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012001");
                /*"    05          WTB4-CARNASEG3  PIC  X(008) VALUE '26022001'.*/
                public StringBasis WTB4_CARNASEG3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"26022001");
                /*"    05          WTB4-CARNAVAL3  PIC  X(008) VALUE '27022001'.*/
                public StringBasis WTB4_CARNAVAL3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"27022001");
                /*"    05          WTB4-PAIXAO3    PIC  X(008) VALUE '13042001'.*/
                public StringBasis WTB4_PAIXAO3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"13042001");
                /*"    05          WTB4-TIRADEN3   PIC  X(008) VALUE '21042001'.*/
                public StringBasis WTB4_TIRADEN3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042001");
                /*"    05          WTB4-TRABALHO3  PIC  X(008) VALUE '01052001'.*/
                public StringBasis WTB4_TRABALHO3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052001");
                /*"    05          WTB4-CORPUS3    PIC  X(008) VALUE '14062001'.*/
                public StringBasis WTB4_CORPUS3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"14062001");
                /*"    05          WTB4-INDEPENDE3 PIC  X(008) VALUE '07092001'.*/
                public StringBasis WTB4_INDEPENDE3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092001");
                /*"    05          WTB4-PADROEIRA3 PIC  X(008) VALUE '12102001'.*/
                public StringBasis WTB4_PADROEIRA3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102001");
                /*"    05          WTB4-FINADOS3   PIC  X(008) VALUE '02112001'.*/
                public StringBasis WTB4_FINADOS3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112001");
                /*"    05          WTB4-REPUBLICA3 PIC  X(008) VALUE '15112001'.*/
                public StringBasis WTB4_REPUBLICA3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112001");
                /*"    05          WTB4-NATAL3     PIC  X(008) VALUE '25122001'.*/
                public StringBasis WTB4_NATAL3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122001");
                /*"    05          WTB4-PRIMEIRO4  PIC  X(008) VALUE '01012002'.*/
                public StringBasis WTB4_PRIMEIRO4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012002");
                /*"    05          WTB4-CARNASEG4  PIC  X(008) VALUE '11022002'.*/
                public StringBasis WTB4_CARNASEG4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"11022002");
                /*"    05          WTB4-CARNAVAL4  PIC  X(008) VALUE '12022002'.*/
                public StringBasis WTB4_CARNAVAL4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12022002");
                /*"    05          WTB4-PAIXAO4    PIC  X(008) VALUE '29032002'.*/
                public StringBasis WTB4_PAIXAO4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"29032002");
                /*"    05          WTB4-TIRADEN4   PIC  X(008) VALUE '21042002'.*/
                public StringBasis WTB4_TIRADEN4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042002");
                /*"    05          WTB4-TRABALHO4  PIC  X(008) VALUE '01052002'.*/
                public StringBasis WTB4_TRABALHO4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052002");
                /*"    05          WTB4-CORPUS4    PIC  X(008) VALUE '30052002'.*/
                public StringBasis WTB4_CORPUS4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"30052002");
                /*"    05          WTB4-INDEPENDE4 PIC  X(008) VALUE '07092002'.*/
                public StringBasis WTB4_INDEPENDE4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092002");
                /*"    05          WTB4-PADROEIRA4 PIC  X(008) VALUE '12102002'.*/
                public StringBasis WTB4_PADROEIRA4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102002");
                /*"    05          WTB4-FINADOS4   PIC  X(008) VALUE '02112002'.*/
                public StringBasis WTB4_FINADOS4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112002");
                /*"    05          WTB4-REPUBLICA4 PIC  X(008) VALUE '15112002'.*/
                public StringBasis WTB4_REPUBLICA4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112002");
                /*"    05          WTB4-ESPECIAL   PIC  X(008) VALUE '06122002'.*/
                public StringBasis WTB4_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"06122002");
                /*"    05          WTB4-NATAL4     PIC  X(008) VALUE '25122002'.*/
                public StringBasis WTB4_NATAL4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122002");
                /*"    05          WTB4-PRIMEIRO5  PIC  X(008) VALUE '01012003'.*/
                public StringBasis WTB4_PRIMEIRO5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012003");
                /*"    05          WTB4-CARNASEG5  PIC  X(008) VALUE '03032003'.*/
                public StringBasis WTB4_CARNASEG5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"03032003");
                /*"    05          WTB4-CARNAVAL5  PIC  X(008) VALUE '04032003'.*/
                public StringBasis WTB4_CARNAVAL5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"04032003");
                /*"    05          WTB4-PAIXAO5    PIC  X(008) VALUE '18042003'.*/
                public StringBasis WTB4_PAIXAO5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"18042003");
                /*"    05          WTB4-TIRADEN5   PIC  X(008) VALUE '21042003'.*/
                public StringBasis WTB4_TIRADEN5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042003");
                /*"    05          WTB4-TRABALHO5  PIC  X(008) VALUE '01052003'.*/
                public StringBasis WTB4_TRABALHO5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052003");
                /*"    05          WTB4-INDETERM5  PIC  X(008) VALUE '19062003'.*/
                public StringBasis WTB4_INDETERM5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"19062003");
                /*"    05          WTB4-INDEPENDE5 PIC  X(008) VALUE '07092003'.*/
                public StringBasis WTB4_INDEPENDE5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092003");
                /*"    05          WTB4-PADROEIRA5 PIC  X(008) VALUE '12102003'.*/
                public StringBasis WTB4_PADROEIRA5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102003");
                /*"    05          WTB4-SECURITA5  PIC  X(008) VALUE '20102003'.*/
                public StringBasis WTB4_SECURITA5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"20102003");
                /*"    05          WTB4-FINADOS5   PIC  X(008) VALUE '02112003'.*/
                public StringBasis WTB4_FINADOS5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112003");
                /*"    05          WTB4-REPUBLICA5 PIC  X(008) VALUE '15112003'.*/
                public StringBasis WTB4_REPUBLICA5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112003");
                /*"    05          WTB4-NATAL5     PIC  X(008) VALUE '25122003'.*/
                public StringBasis WTB4_NATAL5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122003");
                /*"    05          WTB4-BANCARIO5  PIC  X(008) VALUE '31122003'.*/
                public StringBasis WTB4_BANCARIO5 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122003");
                /*"    05          WTB4-PRIMEIRO6  PIC  X(008) VALUE '01012004'.*/
                public StringBasis WTB4_PRIMEIRO6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012004");
                /*"    05          WTB4-CARNASEG6  PIC  X(008) VALUE '23022004'.*/
                public StringBasis WTB4_CARNASEG6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"23022004");
                /*"    05          WTB4-CARNAVAL6  PIC  X(008) VALUE '24022004'.*/
                public StringBasis WTB4_CARNAVAL6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"24022004");
                /*"    05          WTB4-PAIXAO6    PIC  X(008) VALUE '09042004'.*/
                public StringBasis WTB4_PAIXAO6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"09042004");
                /*"    05          WTB4-TIRADEN6   PIC  X(008) VALUE '21042004'.*/
                public StringBasis WTB4_TIRADEN6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042004");
                /*"    05          WTB4-TRABALHO6  PIC  X(008) VALUE '01052004'.*/
                public StringBasis WTB4_TRABALHO6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052004");
                /*"    05          WTB4-INDETERM6  PIC  X(008) VALUE '10062004'.*/
                public StringBasis WTB4_INDETERM6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"10062004");
                /*"    05          WTB4-INDEPENDE6 PIC  X(008) VALUE '07092004'.*/
                public StringBasis WTB4_INDEPENDE6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092004");
                /*"    05          WTB4-PADROEIRA6 PIC  X(008) VALUE '12102004'.*/
                public StringBasis WTB4_PADROEIRA6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102004");
                /*"    05          WTB4-SECURITA6  PIC  X(008) VALUE '18102004'.*/
                public StringBasis WTB4_SECURITA6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"18102004");
                /*"    05          WTB4-FINADOS6   PIC  X(008) VALUE '02112004'.*/
                public StringBasis WTB4_FINADOS6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112004");
                /*"    05          WTB4-REPUBLICA6 PIC  X(008) VALUE '15112004'.*/
                public StringBasis WTB4_REPUBLICA6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112004");
                /*"    05          WTB4-NATAL6     PIC  X(008) VALUE '25122004'.*/
                public StringBasis WTB4_NATAL6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122004");
                /*"    05          WTB4-BANCARIO6  PIC  X(008) VALUE '31122004'.*/
                public StringBasis WTB4_BANCARIO6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122004");
                /*"    05          WTB4-PRIMEIRO7  PIC  X(008) VALUE '01012005'.*/
                public StringBasis WTB4_PRIMEIRO7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012005");
                /*"    05          WTB4-CARNASEG7  PIC  X(008) VALUE '07022005'.*/
                public StringBasis WTB4_CARNASEG7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07022005");
                /*"    05          WTB4-CARNAVAL7  PIC  X(008) VALUE '08022005'.*/
                public StringBasis WTB4_CARNAVAL7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"08022005");
                /*"    05          WTB4-PAIXAO7    PIC  X(008) VALUE '25032005'.*/
                public StringBasis WTB4_PAIXAO7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25032005");
                /*"    05          WTB4-TIRADEN7   PIC  X(008) VALUE '21042005'.*/
                public StringBasis WTB4_TIRADEN7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042005");
                /*"    05          WTB4-TRABALHO7  PIC  X(008) VALUE '01052005'.*/
                public StringBasis WTB4_TRABALHO7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052005");
                /*"    05          WTB4-CORPUS7    PIC  X(008) VALUE '26052005'.*/
                public StringBasis WTB4_CORPUS7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"26052005");
                /*"    05          WTB4-INDEPENDE7 PIC  X(008) VALUE '07092005'.*/
                public StringBasis WTB4_INDEPENDE7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092005");
                /*"    05          WTB4-PADROEIRA7 PIC  X(008) VALUE '12102005'.*/
                public StringBasis WTB4_PADROEIRA7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102005");
                /*"    05          WTB4-FINADOS7   PIC  X(008) VALUE '02112005'.*/
                public StringBasis WTB4_FINADOS7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112005");
                /*"    05          WTB4-REPUBLICA7 PIC  X(008) VALUE '15112005'.*/
                public StringBasis WTB4_REPUBLICA7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112005");
                /*"    05          WTB4-NATAL7     PIC  X(008) VALUE '25122005'.*/
                public StringBasis WTB4_NATAL7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122005");
                /*"    05          WTB4-BANCARIO7  PIC  X(008) VALUE '31122005'.*/
                public StringBasis WTB4_BANCARIO7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122005");
                /*"    05          WTB4-PRIMEIRO8  PIC  X(008) VALUE '01012006'.*/
                public StringBasis WTB4_PRIMEIRO8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012006");
                /*"    05          WTB4-CARNASEG8  PIC  X(008) VALUE '27022006'.*/
                public StringBasis WTB4_CARNASEG8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"27022006");
                /*"    05          WTB4-CARNAVAL8  PIC  X(008) VALUE '28022006'.*/
                public StringBasis WTB4_CARNAVAL8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"28022006");
                /*"    05          WTB4-PAIXAO8    PIC  X(008) VALUE '14042006'.*/
                public StringBasis WTB4_PAIXAO8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"14042006");
                /*"    05          WTB4-PASCOA8    PIC  X(008) VALUE '16042006'.*/
                public StringBasis WTB4_PASCOA8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"16042006");
                /*"    05          WTB4-TIRADEN8   PIC  X(008) VALUE '21042006'.*/
                public StringBasis WTB4_TIRADEN8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042006");
                /*"    05          WTB4-TRABALHO8  PIC  X(008) VALUE '01052006'.*/
                public StringBasis WTB4_TRABALHO8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052006");
                /*"    05          WTB4-CORPUS8    PIC  X(008) VALUE '15062006'.*/
                public StringBasis WTB4_CORPUS8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15062006");
                /*"    05          WTB4-INDEPENDE8 PIC  X(008) VALUE '07092006'.*/
                public StringBasis WTB4_INDEPENDE8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092006");
                /*"    05          WTB4-PADROEIRA8 PIC  X(008) VALUE '12102006'.*/
                public StringBasis WTB4_PADROEIRA8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102006");
                /*"    05          WTB4-FINADOS8   PIC  X(008) VALUE '02112006'.*/
                public StringBasis WTB4_FINADOS8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112006");
                /*"    05          WTB4-REPUBLICA8 PIC  X(008) VALUE '15112006'.*/
                public StringBasis WTB4_REPUBLICA8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112006");
                /*"    05          WTB4-NATAL8     PIC  X(008) VALUE '25122006'.*/
                public StringBasis WTB4_NATAL8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122006");
                /*"    05          WTB4-BANCARIO8  PIC  X(008) VALUE '31122006'.*/
                public StringBasis WTB4_BANCARIO8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122006");
                /*"    05          WTB4-PRIMEIRO9  PIC  X(008) VALUE '01012007'.*/
                public StringBasis WTB4_PRIMEIRO9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012007");
                /*"    05          WTB4-CARNASEG9  PIC  X(008) VALUE '19022007'.*/
                public StringBasis WTB4_CARNASEG9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"19022007");
                /*"    05          WTB4-CARNAVAL9  PIC  X(008) VALUE '20022007'.*/
                public StringBasis WTB4_CARNAVAL9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"20022007");
                /*"    05          WTB4-PAIXAO9    PIC  X(008) VALUE '06042007'.*/
                public StringBasis WTB4_PAIXAO9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"06042007");
                /*"    05          WTB4-PASCOA9    PIC  X(008) VALUE '08042007'.*/
                public StringBasis WTB4_PASCOA9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"08042007");
                /*"    05          WTB4-TIRADEN9   PIC  X(008) VALUE '21042007'.*/
                public StringBasis WTB4_TIRADEN9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042007");
                /*"    05          WTB4-TRABALHO9  PIC  X(008) VALUE '01052007'.*/
                public StringBasis WTB4_TRABALHO9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052007");
                /*"    05          WTB4-CORPUS9    PIC  X(008) VALUE '07062007'.*/
                public StringBasis WTB4_CORPUS9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07062007");
                /*"    05          WTB4-INDEPENDE9 PIC  X(008) VALUE '07092007'.*/
                public StringBasis WTB4_INDEPENDE9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092007");
                /*"    05          WTB4-PADROEIRA9 PIC  X(008) VALUE '12102007'.*/
                public StringBasis WTB4_PADROEIRA9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102007");
                /*"    05          WTB4-FINADOS9   PIC  X(008) VALUE '02112007'.*/
                public StringBasis WTB4_FINADOS9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112007");
                /*"    05          WTB4-REPUBLICA9 PIC  X(008) VALUE '15112007'.*/
                public StringBasis WTB4_REPUBLICA9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112007");
                /*"    05          WTB4-NATAL9     PIC  X(008) VALUE '25122007'.*/
                public StringBasis WTB4_NATAL9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122007");
                /*"    05          WTB4-BANCARIO9  PIC  X(008) VALUE '31122007'.*/
                public StringBasis WTB4_BANCARIO9 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122007");
                /*"    05          WTB4-PRIMEIRO10  PIC  X(008) VALUE '01012008'.*/
                public StringBasis WTB4_PRIMEIRO10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012008");
                /*"    05          WTB4-CARNASEG10  PIC  X(008) VALUE '04022008'.*/
                public StringBasis WTB4_CARNASEG10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"04022008");
                /*"    05          WTB4-CARNAVAL10  PIC  X(008) VALUE '05022008'.*/
                public StringBasis WTB4_CARNAVAL10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"05022008");
                /*"    05          WTB4-PAIXAO10    PIC  X(008) VALUE '21032008'.*/
                public StringBasis WTB4_PAIXAO10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21032008");
                /*"    05          WTB4-PASCOA10    PIC  X(008) VALUE '08042008'.*/
                public StringBasis WTB4_PASCOA10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"08042008");
                /*"    05          WTB4-TIRADEN10   PIC  X(008) VALUE '21042008'.*/
                public StringBasis WTB4_TIRADEN10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042008");
                /*"    05          WTB4-TRABALHO10  PIC  X(008) VALUE '01052008'.*/
                public StringBasis WTB4_TRABALHO10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052008");
                /*"    05          WTB4-CORPUS10    PIC  X(008) VALUE '22052008'.*/
                public StringBasis WTB4_CORPUS10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"22052008");
                /*"    05          WTB4-INDEPENDE10 PIC  X(008) VALUE '07092008'.*/
                public StringBasis WTB4_INDEPENDE10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092008");
                /*"    05          WTB4-PADROEIRA10 PIC  X(008) VALUE '12102008'.*/
                public StringBasis WTB4_PADROEIRA10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102008");
                /*"    05          WTB4-FINADOS10   PIC  X(008) VALUE '02112008'.*/
                public StringBasis WTB4_FINADOS10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112008");
                /*"    05          WTB4-REPUBLICA10 PIC  X(008) VALUE '15112008'.*/
                public StringBasis WTB4_REPUBLICA10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112008");
                /*"    05          WTB4-NATAL10     PIC  X(008) VALUE '25122008'.*/
                public StringBasis WTB4_NATAL10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122008");
                /*"    05          WTB4-BANCARIO10  PIC  X(008) VALUE '31122008'.*/
                public StringBasis WTB4_BANCARIO10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122008");
                /*"    05          WTB4-PRIMEIRO11  PIC  X(008) VALUE '01012009'.*/
                public StringBasis WTB4_PRIMEIRO11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01012009");
                /*"    05          WTB4-CARNASEG11  PIC  X(008) VALUE '23022009'.*/
                public StringBasis WTB4_CARNASEG11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"23022009");
                /*"    05          WTB4-CARNAVAL11  PIC  X(008) VALUE '24022009'.*/
                public StringBasis WTB4_CARNAVAL11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"24022009");
                /*"    05          WTB4-PAIXAO11    PIC  X(008) VALUE '10042009'.*/
                public StringBasis WTB4_PAIXAO11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"10042009");
                /*"    05          WTB4-PASCOA11    PIC  X(008) VALUE '12042009'.*/
                public StringBasis WTB4_PASCOA11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12042009");
                /*"    05          WTB4-TIRADEN11   PIC  X(008) VALUE '21042009'.*/
                public StringBasis WTB4_TIRADEN11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"21042009");
                /*"    05          WTB4-TRABALHO11  PIC  X(008) VALUE '01052009'.*/
                public StringBasis WTB4_TRABALHO11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"01052009");
                /*"    05          WTB4-CORPUS11    PIC  X(008) VALUE '11062009'.*/
                public StringBasis WTB4_CORPUS11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"11062009");
                /*"    05          WTB4-INDEPENDE11 PIC  X(008) VALUE '07092009'.*/
                public StringBasis WTB4_INDEPENDE11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"07092009");
                /*"    05          WTB4-PADROEIRA11 PIC  X(008) VALUE '12102009'.*/
                public StringBasis WTB4_PADROEIRA11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"12102009");
                /*"    05          WTB4-FINADOS11   PIC  X(008) VALUE '02112009'.*/
                public StringBasis WTB4_FINADOS11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"02112009");
                /*"    05          WTB4-REPUBLICA11 PIC  X(008) VALUE '15112009'.*/
                public StringBasis WTB4_REPUBLICA11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"15112009");
                /*"    05          WTB4-NATAL11     PIC  X(008) VALUE '25122009'.*/
                public StringBasis WTB4_NATAL11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"25122009");
                /*"    05          WTB4-BANCARIO11  PIC  X(008) VALUE '31122009'.*/
                public StringBasis WTB4_BANCARIO11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"31122009");
                /*"  03            FILLER          REDEFINES                WTB04-DIAS-FERIADOS.*/
            }
            private _REDEF_PROSOCU1_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PROSOCU1_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PROSOCU1_FILLER_6(); _.Move(WTB04_DIAS_FERIADOS, _filler_6); VarBasis.RedefinePassValue(WTB04_DIAS_FERIADOS, _filler_6, WTB04_DIAS_FERIADOS); _filler_6.ValueChanged += () => { _.Move(_filler_6, WTB04_DIAS_FERIADOS); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WTB04_DIAS_FERIADOS); }
            }  //Redefines
            public class _REDEF_PROSOCU1_FILLER_6 : VarBasis
            {
                /*"    05          WTB4-FER        OCCURS     146                                PIC  9(008).*/
                public ListBasis<IntBasis, Int64> WTB4_FER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)."), 146);
                /*"01              LPARM.*/

                public _REDEF_PROSOCU1_FILLER_6()
                {
                    WTB4_FER.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROSOCU1_LPARM LPARM { get; set; } = new PROSOCU1_LPARM();
        public class PROSOCU1_LPARM : VarBasis
        {
            /*"    03          DATA1.*/
            public PROSOCU1_DATA1 DATA1 { get; set; } = new PROSOCU1_DATA1();
            public class PROSOCU1_DATA1 : VarBasis
            {
                /*"       05       DATA1-DD        PIC  9(002).*/
                public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA1-MM        PIC  9(002).*/
                public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA1-ANO.*/
                public PROSOCU1_DATA1_ANO DATA1_ANO { get; set; } = new PROSOCU1_DATA1_ANO();
                public class PROSOCU1_DATA1_ANO : VarBasis
                {
                    /*"         07     DATA1-AA        PIC  9(004).*/
                    public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    03          NDIAS           PIC S9(005)      COMP-3.*/
                }
            }
            public IntBasis NDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    03          DATA3.*/
            public PROSOCU1_DATA3 DATA3 { get; set; } = new PROSOCU1_DATA3();
            public class PROSOCU1_DATA3 : VarBasis
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
        public dynamic Execute(PROSOCU1_LPARM PROSOCU1_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROSOCU1_LPARM_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-INICIAL-SECTION */

                M_000_000_INICIAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-INICIAL-SECTION */
        private void M_000_000_INICIAL_SECTION()
        {
            /*" -346- PERFORM 000-000-PRINCIPAL. */

            M_000_000_PRINCIPAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_009_SAIDA*/

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -358- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_000_010_INICIALIZA_PARAMETROS */

            M_000_010_INICIALIZA_PARAMETROS();

        }

        [StopWatch]
        /*" M-000-010-INICIALIZA-PARAMETROS */
        private void M_000_010_INICIALIZA_PARAMETROS(bool isPerform = false)
        {
            /*" -360- PERFORM 800-000-INICIALIZA-PARAMETROS. */

            M_800_000_INICIALIZA_PARAMETROS_SECTION();

        }

        [StopWatch]
        /*" M-000-020-CONSISTENCIA-DATA */
        private void M_000_020_CONSISTENCIA_DATA(bool isPerform = false)
        {
            /*" -371- IF DATA1 NOT NUMERIC OR NDIAS NOT NUMERIC OR DATA1-MM LESS 1 OR DATA1-MM GREATER 12 */

            if (!LPARM.DATA1.IsNumeric() || !LPARM.NDIAS.IsNumeric() || LPARM.DATA1.DATA1_MM < 1 || LPARM.DATA1.DATA1_MM > 12)
            {

                /*" -374- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -376- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -378- DIVIDE DATA1-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.DATA1.DATA1_ANO.DATA1_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -379- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -381- MOVE +29 TO WTB02(2). */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);
            }


            /*" -383- IF DATA1-DD LESS 1 OR DATA1-DD GREATER WTB02(DATA1-MM) */

            if (LPARM.DATA1.DATA1_DD < 1 || LPARM.DATA1.DATA1_DD > FILLER_1.FILLER_3.WTB02[LPARM.DATA1.DATA1_MM])
            {

                /*" -386- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -386- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-030-CONVERTE-EM-NNNNN-DIAS */
        private void M_000_030_CONVERTE_EM_NNNNN_DIAS(bool isPerform = false)
        {
            /*" -395- MULTIPLY 365,25 BY DATA1-AA GIVING WDIAS. */
            _.Multiply(365.25, LPARM.DATA1.DATA1_ANO.DATA1_AA, FILLER_0.WDIAS);

            /*" -396- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -397- MOVE +29 TO WTB02(2) */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);

                /*" -407- ADD +1 TO WTB01(3) WTB01(4) WTB01(5) WTB01(6) WTB01(7) WTB01(8) WTB01(9) WTB01(10) WTB01(11) WTB01(12) */
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

                /*" -408- ELSE */
            }
            else
            {


                /*" -410- ADD +1 TO WDIAS. */
                FILLER_0.WDIAS.Value = FILLER_0.WDIAS + +1;
            }


            /*" -411- ADD WTB01(DATA1-MM) DATA1-DD TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + LPARM.DATA1.DATA1_DD;

        }

        [StopWatch]
        /*" M-000-040-SOMA-NN-DIAS */
        private void M_000_040_SOMA_NN_DIAS(bool isPerform = false)
        {
            /*" -417- ADD NDIAS TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + LPARM.NDIAS;

        }

        [StopWatch]
        /*" M-000-045-TESTE-PERIODO-SECULO */
        private void M_000_045_TESTE_PERIODO_SECULO(bool isPerform = false)
        {
            /*" -426- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -429- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -429- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-050-VERIFICA-DIA-UTIL */
        private void M_000_050_VERIFICA_DIA_UTIL(bool isPerform = false)
        {
            /*" -436- PERFORM 500-000-VERIFICA-DIA-UTIL. */

            M_500_000_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-000-055-TESTE-PERIODO-SECULO */
        private void M_000_055_TESTE_PERIODO_SECULO(bool isPerform = false)
        {
            /*" -442- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -445- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -445- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-060-VERIFICA-FERIADO */
        private void M_000_060_VERIFICA_FERIADO(bool isPerform = false)
        {
            /*" -452- PERFORM 700-000-CONVERTE-NNNNN-EM-DATA. */

            M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION();

            /*" -454- PERFORM 600-000-VERIFICA-FERIADOS. */

            M_600_000_VERIFICA_FERIADOS_SECTION();

            /*" -455- IF WX05 GREATER 146 */

            if (FILLER_0.WX05 > 146)
            {

                /*" -460- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -461- ADD 1 TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 1;

            /*" -461- GO TO 000-045-TESTE-PERIODO-SECULO. */

            M_000_045_TESTE_PERIODO_SECULO(); //GOTO
            return;

        }

        [StopWatch]
        /*" M-000-065-TESTE-PERIODO-SECULO */
        private void M_000_065_TESTE_PERIODO_SECULO(bool isPerform = false)
        {
            /*" -467- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -470- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -470- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-070-VERIFICA-SOMADI */
        private void M_000_070_VERIFICA_SOMADI(bool isPerform = false)
        {
            /*" -477- IF WSOMADI GREATER 0 */

            if (FILLER_0.WSOMADI > 0)
            {

                /*" -477- GO TO 000-100-CONVERTE-DATA3. */

                M_000_100_CONVERTE_DATA3(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-080-VERIFICA-DIA-UTIL */
        private void M_000_080_VERIFICA_DIA_UTIL(bool isPerform = false)
        {
            /*" -484- PERFORM 500-000-VERIFICA-DIA-UTIL. */

            M_500_000_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-000-085-TESTE-PERIODO-SECULO */
        private void M_000_085_TESTE_PERIODO_SECULO(bool isPerform = false)
        {
            /*" -490- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -493- MOVE ALL '9' TO DATA1 NDIAS DATA3 */
                _.MoveAll("9", LPARM.DATA1, LPARM.NDIAS, LPARM.DATA3);

                /*" -493- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-100-CONVERTE-DATA3 */
        private void M_000_100_CONVERTE_DATA3(bool isPerform = false)
        {
            /*" -498- PERFORM 700-000-CONVERTE-NNNNN-EM-DATA. */

            M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION();

            /*" -498- GO TO 900-000-RETORNA. */

            M_900_000_RETORNA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_SAIDA*/

        [StopWatch]
        /*" M-500-000-VERIFICA-DIA-UTIL-SECTION */
        private void M_500_000_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -511- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_500_010_CALCULA_DIA_SEMANA */

            M_500_010_CALCULA_DIA_SEMANA();

        }

        [StopWatch]
        /*" M-500-010-CALCULA-DIA-SEMANA */
        private void M_500_010_CALCULA_DIA_SEMANA(bool isPerform = false)
        {
            /*" -514- DIVIDE WDIAS BY 7 GIVING WQUOCIENTE REMAINDER WDSEM. */
            _.Divide(FILLER_0.WDIAS, 7, FILLER_0.WQUOCIENTE, FILLER_0.WDSEM);

        }

        [StopWatch]
        /*" M-500-020-VERIFICA-DIA-UTIL */
        private void M_500_020_VERIFICA_DIA_UTIL(bool isPerform = false)
        {
            /*" -525- IF WDSEM EQUAL 2 */

            if (FILLER_0.WDSEM == 2)
            {

                /*" -526- ADD 2 TO WDIAS */
                FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 2;

                /*" -527- ADD 2 TO WSOMADI */
                FILLER_0.WSOMADI.Value = FILLER_0.WSOMADI + 2;

                /*" -528- ELSE */
            }
            else
            {


                /*" -529- IF WDSEM EQUAL 3 */

                if (FILLER_0.WDSEM == 3)
                {

                    /*" -530- ADD 1 TO WDIAS */
                    FILLER_0.WDIAS.Value = FILLER_0.WDIAS + 1;

                    /*" -530- ADD 1 TO WSOMADI. */
                    FILLER_0.WSOMADI.Value = FILLER_0.WSOMADI + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_SAIDA*/

        [StopWatch]
        /*" M-600-000-VERIFICA-FERIADOS-SECTION */
        private void M_600_000_VERIFICA_FERIADOS_SECTION()
        {
            /*" -546- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_600_010_VERIFICA_FER */

            M_600_010_VERIFICA_FER();

        }

        [StopWatch]
        /*" M-600-010-VERIFICA-FER */
        private void M_600_010_VERIFICA_FER(bool isPerform = false)
        {
            /*" -548- MOVE ZEROS TO WX05. */
            _.Move(0, FILLER_0.WX05);

        }

        [StopWatch]
        /*" M-600-020-VER */
        private void M_600_020_VER(bool isPerform = false)
        {
            /*" -554- ADD 1 TO WX05 */
            FILLER_0.WX05.Value = FILLER_0.WX05 + 1;

            /*" -555- IF WX05 GREATER 146 */

            if (FILLER_0.WX05 > 146)
            {

                /*" -557- GO TO 600-999-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_SAIDA*/ //GOTO
                return;
            }


            /*" -558- IF DATA3 NOT EQUAL WTB4-FER(WX05) */

            if (LPARM.DATA3 != FILLER_5.FILLER_6.WTB4_FER[FILLER_0.WX05])
            {

                /*" -558- GO TO 600-020-VER. */
                new Task(() => M_600_020_VER()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_SAIDA*/

        [StopWatch]
        /*" M-700-000-CONVERTE-NNNNN-EM-DATA-SECTION */
        private void M_700_000_CONVERTE_NNNNN_EM_DATA_SECTION()
        {
            /*" -570- DIVIDE WDIAS BY 365,25 GIVING WANOS REMAINDER WDIASREST */
            _.Divide(FILLER_0.WDIAS, 365.25, FILLER_0.WANOS, FILLER_0.WDIASREST);

            /*" -571- IF WDIASREST EQUAL ZEROS */

            if (FILLER_0.WDIASREST == 00)
            {

                /*" -573- SUBTRACT 1 FROM WANOS GIVING DATA3-AA */
                LPARM.DATA3.DATA3_AA.Value = FILLER_0.WANOS - 1;

                /*" -574- MOVE 12 TO DATA3-MM */
                _.Move(12, LPARM.DATA3.DATA3_MM);

                /*" -575- MOVE 31 TO DATA3-DD */
                _.Move(31, LPARM.DATA3.DATA3_DD);

                /*" -576- GO TO 700-999-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_999_SAIDA*/ //GOTO
                return;
            }


            /*" -578- MOVE WANOS TO DATA3-AA. */
            _.Move(FILLER_0.WANOS, LPARM.DATA3.DATA3_AA);

            /*" -581- DIVIDE DATA3-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.DATA3.DATA3_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -582- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -592- ADD +1 TO WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12) */
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

                /*" -594- MOVE 1 TO WSOMBISXTO. */
                _.Move(1, FILLER_0.WSOMBISXTO);
            }


            /*" -595- SET I03 TO 1. */
            I03.Value = 1;

            /*" -597- SEARCH WTB03 AT END */
            void SearchAtEnd0()
            {

                /*" -598- MOVE 12 TO DATA3-MM */
                _.Move(12, LPARM.DATA3.DATA3_MM);

                /*" -600- SUBTRACT WTB03 (12) FROM WDIASREST GIVING DATA3-DD */
                LPARM.DATA3.DATA3_DD.Value = FILLER_0.WDIASREST - FILLER_1.FILLER_4.WTB03[12];

                /*" -601- WHEN WTB03 (I03) NOT LESS WDIASREST */
            };

            var mustSearchAtEnd0 = true;
            for (; I03 < FILLER_1.FILLER_4.WTB03.Items.Count; I03.Value++)
            {

                if (FILLER_1.FILLER_4.WTB03[I03] >= FILLER_0.WDIASREST)
                {

                    mustSearchAtEnd0 = false;

                    /*" -602- SET I03 DOWN BY 1 */
                    I03.Value -= 1;

                    /*" -603- SET DATA3-MM TO I03 */
                    LPARM.DATA3.DATA3_MM.Value = I03;

                    /*" -605- SUBTRACT WTB03 (I03) FROM WDIASREST GIVING DATA3-DD */
                    LPARM.DATA3.DATA3_DD.Value = FILLER_0.WDIASREST - FILLER_1.FILLER_4.WTB03[I03];

                    /*" -605- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

            /*" -608- IF WSOMBISXTO = 1 */

            if (FILLER_0.WSOMBISXTO == 1)
            {

                /*" -618- SUBTRACT +1 FROM WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12) */
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

                /*" -618- MOVE 0 TO WSOMBISXTO. */
                _.Move(0, FILLER_0.WSOMBISXTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_999_SAIDA*/

        [StopWatch]
        /*" M-800-000-INICIALIZA-PARAMETROS-SECTION */
        private void M_800_000_INICIALIZA_PARAMETROS_SECTION()
        {
            /*" -630- MOVE +0 TO WQUOCIENTE */
            _.Move(+0, FILLER_0.WQUOCIENTE);

            /*" -631- MOVE +0 TO WRESTO */
            _.Move(+0, FILLER_0.WRESTO);

            /*" -632- MOVE +0 TO WDIASREST */
            _.Move(+0, FILLER_0.WDIASREST);

            /*" -633- MOVE +0 TO WANOS */
            _.Move(+0, FILLER_0.WANOS);

            /*" -634- MOVE +0 TO WDIAS */
            _.Move(+0, FILLER_0.WDIAS);

            /*" -635- MOVE +0 TO WDIAS01 */
            _.Move(+0, FILLER_0.WDIAS01);

            /*" -637- MOVE +0 TO WSOMADI */
            _.Move(+0, FILLER_0.WSOMADI);

            /*" -638- MOVE +0 TO WTB1-1 */
            _.Move(+0, FILLER_1.WTB01_DIAS_JULIANO.WTB1_1);

            /*" -639- MOVE +31 TO WTB1-2 */
            _.Move(+31, FILLER_1.WTB01_DIAS_JULIANO.WTB1_2);

            /*" -640- MOVE +59 TO WTB1-3 */
            _.Move(+59, FILLER_1.WTB01_DIAS_JULIANO.WTB1_3);

            /*" -641- MOVE +90 TO WTB1-4 */
            _.Move(+90, FILLER_1.WTB01_DIAS_JULIANO.WTB1_4);

            /*" -642- MOVE +120 TO WTB1-5 */
            _.Move(+120, FILLER_1.WTB01_DIAS_JULIANO.WTB1_5);

            /*" -643- MOVE +151 TO WTB1-6 */
            _.Move(+151, FILLER_1.WTB01_DIAS_JULIANO.WTB1_6);

            /*" -644- MOVE +181 TO WTB1-7 */
            _.Move(+181, FILLER_1.WTB01_DIAS_JULIANO.WTB1_7);

            /*" -645- MOVE +212 TO WTB1-8 */
            _.Move(+212, FILLER_1.WTB01_DIAS_JULIANO.WTB1_8);

            /*" -646- MOVE +243 TO WTB1-9 */
            _.Move(+243, FILLER_1.WTB01_DIAS_JULIANO.WTB1_9);

            /*" -647- MOVE +273 TO WTB1-10 */
            _.Move(+273, FILLER_1.WTB01_DIAS_JULIANO.WTB1_10);

            /*" -648- MOVE +304 TO WTB1-11 */
            _.Move(+304, FILLER_1.WTB01_DIAS_JULIANO.WTB1_11);

            /*" -650- MOVE +334 TO WTB1-12 */
            _.Move(+334, FILLER_1.WTB01_DIAS_JULIANO.WTB1_12);

            /*" -652- MOVE +28 TO WTB2-2 */
            _.Move(+28, FILLER_1.WTB02_DIAS_MES.WTB2_2);

            /*" -653- MOVE +0 TO WTB3-1 */
            _.Move(+0, FILLER_1.WTB03_DIAS_JULIANO.WTB3_1);

            /*" -654- MOVE +31 TO WTB3-2 */
            _.Move(+31, FILLER_1.WTB03_DIAS_JULIANO.WTB3_2);

            /*" -655- MOVE +59 TO WTB3-3 */
            _.Move(+59, FILLER_1.WTB03_DIAS_JULIANO.WTB3_3);

            /*" -656- MOVE +90 TO WTB3-4 */
            _.Move(+90, FILLER_1.WTB03_DIAS_JULIANO.WTB3_4);

            /*" -657- MOVE +120 TO WTB3-5 */
            _.Move(+120, FILLER_1.WTB03_DIAS_JULIANO.WTB3_5);

            /*" -658- MOVE +151 TO WTB3-6 */
            _.Move(+151, FILLER_1.WTB03_DIAS_JULIANO.WTB3_6);

            /*" -659- MOVE +181 TO WTB3-7 */
            _.Move(+181, FILLER_1.WTB03_DIAS_JULIANO.WTB3_7);

            /*" -660- MOVE +212 TO WTB3-8 */
            _.Move(+212, FILLER_1.WTB03_DIAS_JULIANO.WTB3_8);

            /*" -661- MOVE +243 TO WTB3-9 */
            _.Move(+243, FILLER_1.WTB03_DIAS_JULIANO.WTB3_9);

            /*" -662- MOVE +273 TO WTB3-10 */
            _.Move(+273, FILLER_1.WTB03_DIAS_JULIANO.WTB3_10);

            /*" -663- MOVE +304 TO WTB3-11 */
            _.Move(+304, FILLER_1.WTB03_DIAS_JULIANO.WTB3_11);

            /*" -663- MOVE +334 TO WTB3-12. */
            _.Move(+334, FILLER_1.WTB03_DIAS_JULIANO.WTB3_12);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_SAIDA*/

        [StopWatch]
        /*" M-900-000-RETORNA-SECTION */
        private void M_900_000_RETORNA_SECTION()
        {
            /*" -672- GOBACK. */

            throw new GoBack();

        }
    }
}