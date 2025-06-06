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
    public class RSGESSTR
    {
        public bool IsCall { get; set; }

        public RSGESSTR()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA ................  RSS - RENOVACAO DO SISTEMA DE SEGURO *      */
        /*"      * PROGRAMA ...............  RSGESSTR                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA ...............  HERVAL SOUZA                         *      */
        /*"      * PROGRAMADOR ............  HERVAL SOUZA                         *      */
        /*"      * DATA CODIFICACAO .......  Abr/2014                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO .................  a-ELIMINAR BRANCOS A ESQUERDA(Se STR)*      */
        /*"      *                           b-ELIMINAR CARACTERES INDEVIDOS      *      */
        /*"      *                           c-FORMATAR STRING/NUMERO             *      */
        /*"      *                           d-CALCULAR TAMANHO FINAL             *      */
        /*"      *                           e-Se numero, avaliar perda de signi- *      */
        /*"      *                                ficancia.                       *      */
        /*"      *                           f-Transformar em Maiusculo os        *      */
        /*"      *                             alfab�ticos.                       *      */
        /*"      *                                                                *      */
        /*"      * OBS.: A aplica��o trata unica e exclusivamente a pagina de c�di*      */
        /*"      *    go EBCDIC CPGID = 0037, que � a p�gina usada no TSO e no DB2*      */
        /*"      *                                                                       */
        /*"      *=========> FUN��O SOLICITADA.                                          */
        /*"      *==> INFORMA A FUN��O SOLICITADA AO M�DULO:                             */
        /*"      *==> 1 -ELIMINAR CARACTER INVALIDO EM STRING GENERICO.                  */
        /*"      *==> 2 -FORMATAR DADO NUMERICO.                                         */
        /*"      *==> 3 -FORMATAR NOME PESSOA.                                           */
        /*"      *==> 4 -FORMATAR NOME EMPRESA.                                          */
        /*"      *==> 5 -FORMATAR ENDERE�O.                                              */
        /*"      *==> 6 -FORMATAR EMAIL.                                                 */
        /*"      *==> 7 -FORMATAR STRING GENERICO                                        */
        /*"      *==> OBRIGATORIO: SIM                                                   */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                      TIPO        CODIGO        ACESSO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * EM: 26/08/2014 - Altera��es para efetuar o UPPER CASE das      *      */
        /*"      *                   a��es no tratamento de STRING.               *      */
        /*"      *                  Aumentar a STRING in/out para 2.000 bytes.    *      */
        /*"      *                  HERVAL SOUZA - MILLENIUM                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * EM: 13/08/2014 - ALTERA��ES PARA USO DA LOCAL-STORAGE NAS      *      */
        /*"      *                   VARI�VEIS INICIALIZADAS.                     *      */
        /*"      *                  HERVAL SOUZA - MILLENIUM                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01 WS-AREAS.*/
        public RSGESSTR_WS_AREAS WS_AREAS { get; set; } = new RSGESSTR_WS_AREAS();
        public class RSGESSTR_WS_AREAS : VarBasis
        {
            /*"  05  WS-PRIMEIRA-VEZ               PIC  X(003)  VALUE 'SIM'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"01 WS-FONTE-STR.*/
        }
        public RSGESSTR_WS_FONTE_STR WS_FONTE_STR { get; set; } = new RSGESSTR_WS_FONTE_STR();
        public class RSGESSTR_WS_FONTE_STR : VarBasis
        {
            /*"  05  WS-FONTE-STR-LGTH             PIC S9(004)  COMP-5 VALUE 0.*/
            public IntBasis WS_FONTE_STR_LGTH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WS-FONTE-STR-DATA             PIC  X(2000).*/
            public StringBasis WS_FONTE_STR_DATA { get; set; } = new StringBasis(new PIC("X", "2000", "X(2000)."), @"");
            /*"01 WS-FONTE-NUM.*/
        }
        public RSGESSTR_WS_FONTE_NUM WS_FONTE_NUM { get; set; } = new RSGESSTR_WS_FONTE_NUM();
        public class RSGESSTR_WS_FONTE_NUM : VarBasis
        {
            /*"  05  WS-FONTE-NUM-LGTH             PIC S9(004)  COMP-5 VALUE 0.*/
            public IntBasis WS_FONTE_NUM_LGTH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WS-FONTE-NUM-DATA             PIC  X(030).*/
            public StringBasis WS_FONTE_NUM_DATA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"01  WS-TAB-CONVERSAO.*/
        }
        public RSGESSTR_WS_TAB_CONVERSAO WS_TAB_CONVERSAO { get; set; } = new RSGESSTR_WS_TAB_CONVERSAO();
        public class RSGESSTR_WS_TAB_CONVERSAO : VarBasis
        {
            /*"  05   WS-CONV-01.*/
            public RSGESSTR_WS_CONV_01 WS_CONV_01 { get; set; } = new RSGESSTR_WS_CONV_01();
            public class RSGESSTR_WS_CONV_01 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '000102030405060708090A0B0C0D0E0F'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"000102030405060708090A0B0C0D0E0F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '101112131415161718191A1B1C1D1E1F'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"101112131415161718191A1B1C1D1E1F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '202122232425262728292A2B2C2D2E2F'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"202122232425262728292A2B2C2D2E2F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '303132333435363738393A3B3C3D3E3F'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"303132333435363738393A3B3C3D3E3F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '404142434445464748494A4B4C4D4E4F'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"404142434445464748494A4B4C4D4E4F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '505152535455565758595A5B5C5D5E5F'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"505152535455565758595A5B5C5D5E5F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '606162636465666768696A6B6C6D6E6F'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"606162636465666768696A6B6C6D6E6F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '707172737475767778797A7B7C7D7E7F'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"707172737475767778797A7B7C7D7E7F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '808182838485868788898A8B8C8D8E8F'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"808182838485868788898A8B8C8D8E8F");
                /*"    10  FILLER              PIC  X(16)   VALUE          '909192939495969798999A9B9C9D9E9F'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"909192939495969798999A9B9C9D9E9F");
                /*"    10  FILLER              PIC  X(16)   VALUE          'A0A1A2A3A4A5A6A7A8A9AAABACADAEAF'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"A0A1A2A3A4A5A6A7A8A9AAABACADAEAF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'B0B1B2B3B4B5B6B7B8B9BABBBCBDBEBF'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"B0B1B2B3B4B5B6B7B8B9BABBBCBDBEBF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'C0C1C2C3C4C5C6C7C8C9CACBCCCDCECF'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"C0C1C2C3C4C5C6C7C8C9CACBCCCDCECF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'D0D1D2D3D4D5D6D7D8D9DADBDCDDDEDF'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"D0D1D2D3D4D5D6D7D8D9DADBDCDDDEDF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'E0E1E2E3E4E5E6E7E8E9EAEBECEDEEEF'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"E0E1E2E3E4E5E6E7E8E9EAEBECEDEEEF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF");
                /*"  05   WS-CONV-ORIGEM       REDEFINES   WS-CONV-01                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_origem { get; set; }
            public _REDEF_StringBasis WS_CONV_ORIGEM
            {
                get { _ws_conv_origem = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_01, _ws_conv_origem); VarBasis.RedefinePassValue(WS_CONV_01, _ws_conv_origem, WS_CONV_01); _ws_conv_origem.ValueChanged += () => { _.Move(_ws_conv_origem, WS_CONV_01); }; return _ws_conv_origem; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_origem, WS_CONV_01); }
            }  //Redefines
            /*"  05   WS-CONV-02.*/
            public RSGESSTR_WS_CONV_02 WS_CONV_02 { get; set; } = new RSGESSTR_WS_CONV_02();
            public class RSGESSTR_WS_CONV_02 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404240444546404840404040404040'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404240444546404840404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40515240545540405840404040404040'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40515240545540405840404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40406240646566406840404040404040'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40406240646566406840404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40717240747540407840404040404040'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40717240747540407840404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40818283848586878889404040404040'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40818283848586878889404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40919293949596979899404040404040'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40919293949596979899404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040A2A3A4A5A6A7A8A9404040404040'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040A2A3A4A5A6A7A8A9404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40C1C2C3C4C5C6C7C8C940CB40CDCECF'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40C1C2C3C4C5C6C7C8C940CB40CDCECF");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40D1D2D3D4D5D6D7D8D94040DCDDDE40'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40D1D2D3D4D5D6D7D8D94040DCDDDE40");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040E2E3E4E5E6E7E8E940EB40EDEEEF'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040E2E3E4E5E6E7E8E940EB40EDEEEF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F94040FCFDFE40'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F94040FCFDFE40");
                /*"  05   WS-CONV-PESSOA       REDEFINES   WS-CONV-02                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_pessoa { get; set; }
            public _REDEF_StringBasis WS_CONV_PESSOA
            {
                get { _ws_conv_pessoa = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_02, _ws_conv_pessoa); VarBasis.RedefinePassValue(WS_CONV_02, _ws_conv_pessoa, WS_CONV_02); _ws_conv_pessoa.ValueChanged += () => { _.Move(_ws_conv_pessoa, WS_CONV_02); }; return _ws_conv_pessoa; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_pessoa, WS_CONV_02); }
            }  //Redefines
            /*"  05   WS-CONV-03.*/
            public RSGESSTR_WS_CONV_03 WS_CONV_03 { get; set; } = new RSGESSTR_WS_CONV_03();
            public class RSGESSTR_WS_CONV_03 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404240444546404840404B40404040'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404240444546404840404B40404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '50515240545540405840404040404040'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"50515240545540405840404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '404062406465664068404040406D4040'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"404062406465664068404040406D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4071724074754040784040407C404040'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4071724074754040784040407C404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40818283848586878889404040404040'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40818283848586878889404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40919293949596979899404040404040'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40919293949596979899404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040A2A3A4A5A6A7A8A9404040404040'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040A2A3A4A5A6A7A8A9404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40C1C2C3C4C5C6C7C8C940CB40CDCECF'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40C1C2C3C4C5C6C7C8C940CB40CDCECF");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40D1D2D3D4D5D6D7D8D94040DCDDDE40'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40D1D2D3D4D5D6D7D8D94040DCDDDE40");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040E2E3E4E5E6E7E8E9404040404040'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040E2E3E4E5E6E7E8E9404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F94040FCFDFE40'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F94040FCFDFE40");
                /*"  05   WS-CONV-ENDERECO     REDEFINES   WS-CONV-03                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_endereco { get; set; }
            public _REDEF_StringBasis WS_CONV_ENDERECO
            {
                get { _ws_conv_endereco = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_03, _ws_conv_endereco); VarBasis.RedefinePassValue(WS_CONV_03, _ws_conv_endereco, WS_CONV_03); _ws_conv_endereco.ValueChanged += () => { _.Move(_ws_conv_endereco, WS_CONV_03); }; return _ws_conv_endereco; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_endereco, WS_CONV_03); }
            }  //Redefines
            /*"  05   WS-CONV-04.*/
            public RSGESSTR_WS_CONV_04 WS_CONV_04 { get; set; } = new RSGESSTR_WS_CONV_04();
            public class RSGESSTR_WS_CONV_04 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404240444546404840404B40404040'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404240444546404840404B40404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '50515240545540405840404040404040'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"50515240545540405840404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '404062406465664068404040406D4040'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"404062406465664068404040406D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4071724074754040784040407C404040'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4071724074754040784040407C404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40818283848586878889404040404040'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40818283848586878889404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40919293949596979899404040404040'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40919293949596979899404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040A2A3A4A5A6A7A8A9404040404040'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040A2A3A4A5A6A7A8A9404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40C1C2C3C4C5C6C7C8C940CB40CDCECF'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40C1C2C3C4C5C6C7C8C940CB40CDCECF");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40D1D2D3D4D5D6D7D8D94040DCDDDE40'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40D1D2D3D4D5D6D7D8D94040DCDDDE40");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040E2E3E4E5E6E7E8E9404040404040'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040E2E3E4E5E6E7E8E9404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F94040FCFDFE40'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F94040FCFDFE40");
                /*"  05   WS-CONV-EMPRESA      REDEFINES   WS-CONV-04                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_empresa { get; set; }
            public _REDEF_StringBasis WS_CONV_EMPRESA
            {
                get { _ws_conv_empresa = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_04, _ws_conv_empresa); VarBasis.RedefinePassValue(WS_CONV_04, _ws_conv_empresa, WS_CONV_04); _ws_conv_empresa.ValueChanged += () => { _.Move(_ws_conv_empresa, WS_CONV_04); }; return _ws_conv_empresa; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_empresa, WS_CONV_04); }
            }  //Redefines
            /*"  05   WS-CONV-05.*/
            public RSGESSTR_WS_CONV_05 WS_CONV_05 { get; set; } = new RSGESSTR_WS_CONV_05();
            public class RSGESSTR_WS_CONV_05 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40408181818181818395404B40404040'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40408181818181818395404B40404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '50858585858989898940405B40404040'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"50858585858989898940405B40404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '604081818181818183954040406D4040'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"604081818181818183954040406D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40858585858989898940407B7C404040'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40858585858989898940407B7C404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40818283848586878889404040A84040'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40818283848586878889404040A84040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40919293949596979899404040404040'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40919293949596979899404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040A2A3A4A5A6A7A8A9404040A84040'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040A2A3A4A5A6A7A8A9404040A84040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40818283848586878889409696969696'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40818283848586878889409696969696");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4091929394959697989940A4A4A4A4A8'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4091929394959697989940A4A4A4A4A8");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040A2A3A4A5A6A7A8A9409696969696'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040A2A3A4A5A6A7A8A9409696969696");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F940A4A4A4A440'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F940A4A4A4A440");
                /*"  05   WS-CONV-EMAIL        REDEFINES   WS-CONV-05                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_email { get; set; }
            public _REDEF_StringBasis WS_CONV_EMAIL
            {
                get { _ws_conv_email = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_05, _ws_conv_email); VarBasis.RedefinePassValue(WS_CONV_05, _ws_conv_email, WS_CONV_05); _ws_conv_email.ValueChanged += () => { _.Move(_ws_conv_email, WS_CONV_05); }; return _ws_conv_email; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_email, WS_CONV_05); }
            }  //Redefines
            /*"  05   WS-CONV-06.*/
            public RSGESSTR_WS_CONV_06 WS_CONV_06 { get; set; } = new RSGESSTR_WS_CONV_06();
            public class RSGESSTR_WS_CONV_06 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '404062C1646566C16869404B404D4040'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"404062C1646566C16869404B404D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '507172C5C575C9C9C940405B405D4040'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"507172C5C575C9C9C940405B405D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '606162C1646566C168D5406B406D4040'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"606162C1646566C168D5406B406D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '407172C5C575C9C9C94040407C7D4040'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"407172C5C575C9C9C94040407C7D4040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40C1C2C3C4C5C6C7C8C9404040E84040'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40C1C2C3C4C5C6C7C8C9404040E84040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40D1D2D3D4D5D6D7D8D9404040404040'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40D1D2D3D4D5D6D7D8D9404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040E2E3E4E5E6E7E8E9404040E84040'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040E2E3E4E5E6E7E8E9404040E84040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40C1C2C3C4C5C6C7C8C940EBD6D6EEEF'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40C1C2C3C4C5C6C7C8C940EBD6D6EEEF");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40D1D2D3D4D5D6D7D8D940E4E4E4FEE8'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40D1D2D3D4D5D6D7D8D940E4E4E4FEE8");
                /*"    10  FILLER              PIC  X(16)   VALUE          '4040E2E3E4E5E6E7E8E940EBD6D6EEEF'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"4040E2E3E4E5E6E7E8E940EBD6D6EEEF");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F940E4E4E4FE40'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F940E4E4E4FE40");
                /*"  05   WS-CONV-GERAL        REDEFINES   WS-CONV-06                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_geral { get; set; }
            public _REDEF_StringBasis WS_CONV_GERAL
            {
                get { _ws_conv_geral = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_06, _ws_conv_geral); VarBasis.RedefinePassValue(WS_CONV_06, _ws_conv_geral, WS_CONV_06); _ws_conv_geral.ValueChanged += () => { _.Move(_ws_conv_geral, WS_CONV_06); }; return _ws_conv_geral; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_geral, WS_CONV_06); }
            }  //Redefines
            /*"  05   WS-CONV-07.*/
            public RSGESSTR_WS_CONV_07 WS_CONV_07 { get; set; } = new RSGESSTR_WS_CONV_07();
            public class RSGESSTR_WS_CONV_07 : VarBasis
            {
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          '40404040404040404040404040404040'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"40404040404040404040404040404040");
                /*"    10  FILLER              PIC  X(16)   VALUE          'F0F1F2F3F4F5F6F7F8F9404040404040'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"F0F1F2F3F4F5F6F7F8F9404040404040");
                /*"  05   WS-CONV-NUMERICO     REDEFINES   WS-CONV-07                            PIC  X(256).*/
            }
            private _REDEF_StringBasis _ws_conv_numerico { get; set; }
            public _REDEF_StringBasis WS_CONV_NUMERICO
            {
                get { _ws_conv_numerico = new _REDEF_StringBasis(new PIC("X", "256", "X(256).")); ; _.Move(WS_CONV_07, _ws_conv_numerico); VarBasis.RedefinePassValue(WS_CONV_07, _ws_conv_numerico, WS_CONV_07); _ws_conv_numerico.ValueChanged += () => { _.Move(_ws_conv_numerico, WS_CONV_07); }; return _ws_conv_numerico; }
                set { VarBasis.RedefinePassValue(value, _ws_conv_numerico, WS_CONV_07); }
            }  //Redefines
            /*"01  VARIAVEIS-APOIO.*/
        }
        public RSGESSTR_VARIAVEIS_APOIO VARIAVEIS_APOIO { get; set; } = new RSGESSTR_VARIAVEIS_APOIO();
        public class RSGESSTR_VARIAVEIS_APOIO : VarBasis
        {
            /*"  05   WS-INI                       PIC S9(004) COMP VALUE +0.*/
            public IntBasis WS_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WS-I-DEST                    PIC S9(004) COMP VALUE +0.*/
            public IntBasis WS_I_DEST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WS-QTD-BRANCOS               PIC S9(004) COMP VALUE +0.*/
            public IntBasis WS_QTD_BRANCOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WS-MOVE                      PIC  X(003) VALUE  'NAO'.*/
            public StringBasis WS_MOVE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05   WS-CONV-AUX                  PIC  X(256) VALUE   SPACES.*/
            public StringBasis WS_CONV_AUX { get; set; } = new StringBasis(new PIC("X", "256", "X(256)"), @"");
            /*"  05   WS-LGTH-STR                  PIC S9(004) COMP VALUE +2000*/
            public IntBasis WS_LGTH_STR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +2000);
            /*"  05   WS-LGTH-NUM                  PIC S9(004) COMP VALUE +030.*/
            public IntBasis WS_LGTH_NUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +030);
            /*"  05   WS-NUM-AUX                   PIC  X(030).*/
            public StringBasis WS_NUM_AUX { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05   WS-NUM-AUX-RIGHT             PIC  X(030) JUST RIGHT.*/
            public StringBasis WS_NUM_AUX_RIGHT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"  05   WS-NUM-MAX                   PIC  X(030) VALUE ALL '9'.*/
            public StringBasis WS_NUM_MAX { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"ALL");
            /*"  05   WS-LGTH-AUX                  PIC S9(004) COMP VALUE +0.*/
            public IntBasis WS_LGTH_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        }


        public Copies.RSGEWDTA RSGEWDTA { get; set; } = new Copies.RSGEWDTA();
        public Copies.RSGEWSTR RSGEWSTR { get; set; } = new Copies.RSGEWSTR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(RSGEWSTR RSGEWSTR_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_RSGEWSTR_FUNCAO
        LK_RSGEWSTR_INP_STR
        LK_RSGEWSTR_INP_NUM
        LK_RSGEWSTR_IND_ERRO
        LK_RSGEWSTR_OUT_STR
        LK_RSGEWSTR_OUT_NUM*/
        {
            try
            {
                this.RSGEWSTR = RSGEWSTR_P;

                /*" -0- FLUXCONTROL_PERFORM R0001-INICIO-SECTION */

                R0001_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { RSGEWSTR };
            return Result;
        }

        [StopWatch]
        /*" R0001-INICIO-SECTION */
        private void R0001_INICIO_SECTION()
        {
            /*" -510- INITIALIZE LK-RSGEWSTR-IND-ERRO LK-RSGEWSTR-OUT-STR LK-RSGEWSTR-OUT-NUM WS-FONTE-STR WS-NUM-AUX WS-NUM-AUX-RIGHT WS-FONTE-NUM. */
            _.Initialize(
                RSGEWSTR.LK_RSGEWSTR_IND_ERRO
                , RSGEWSTR.LK_RSGEWSTR_OUT_STR
                , RSGEWSTR.LK_RSGEWSTR_OUT_NUM
                , WS_FONTE_STR
                , VARIAVEIS_APOIO.WS_NUM_AUX
                , VARIAVEIS_APOIO.WS_NUM_AUX_RIGHT
                , WS_FONTE_NUM
            );

            /*" -510- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_DATE);

            /*" -510- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
            _.Move(_.WhenCompiled(), RSGEWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED);

            /*" -510- STRING WS-WHEN-ANO '-' WS-WHEN-MES '-' WS-WHEN-DIA ' ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG ',' WS-WHEN-DECSEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
            #region STRING
            var spl1 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_ANO.GetMoveValues();
            spl1 += "-";
            var spl2 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MES.GetMoveValues();
            spl2 += "-";
            var spl3 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DIA.GetMoveValues();
            spl3 += " ";
            var spl4 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_HORA.GetMoveValues();
            spl4 += ":";
            var spl5 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MIN.GetMoveValues();
            spl5 += ":";
            var spl6 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_SEG.GetMoveValues();
            spl6 += ",";
            var spl7 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DECSEG.GetMoveValues();
            var results8 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7;
            _.Move(results8, RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT);
            #endregion

            /*" -512- STRING WS-CDTE-ANO '-' WS-CDTE-MES '-' WS-CDTE-DIA ' ' WS-CDTE-HORA ':' WS-CDTE-MIN ':' WS-CDTE-SEG ',' WS-CDTE-DECSEG DELIMITED BY SIZE INTO WS-CURRENT-EDIT */
            #region STRING
            var spl8 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_ANO.GetMoveValues();
            spl8 += "-";
            var spl9 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MES.GetMoveValues();
            spl9 += "-";
            var spl10 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DIA.GetMoveValues();
            spl10 += " ";
            var spl11 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_HORA.GetMoveValues();
            spl11 += ":";
            var spl12 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MIN.GetMoveValues();
            spl12 += ":";
            var spl13 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_SEG.GetMoveValues();
            spl13 += ",";
            var spl14 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DECSEG.GetMoveValues();
            var results15 = spl8 + spl9 + spl10 + spl11 + spl12 + spl13 + spl14;
            _.Move(results15, RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT);
            #endregion

            /*" -514- IF WS_PRIMEIRA_VEZ = 'SIM' THEN */

            if (WS_AREAS.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -515- DISPLAY ' ' */
                _.Display($" ");

                /*" -517- DISPLAY '*========================================================*' */
                _.Display($"*========================================================*");

                /*" -519- DISPLAY '* Programa .....: RSGESSTR- Valida e formata uma  ' '       *' */
                _.Display($"* Programa .....: RSGESSTR- Valida e formata uma         *");

                /*" -521- DISPLAY '*                   sequencia STRING ou NUMERICA. ' '       *' */
                _.Display($"*                   sequencia STRING ou NUMERICA.        *");

                /*" -523- DISPLAY '* Criacao ......: ABR/2014                        ' '       *' */
                _.Display($"* Criacao ......: ABR/2014                               *");

                /*" -525- DISPLAY '* Alteracao.....: AGO/2014                        ' '       *' */
                _.Display($"* Alteracao.....: AGO/2014                               *");

                /*" -527- DISPLAY '* Versao........: 02.00                           ' '       *' */
                _.Display($"* Versao........: 02.00                                  *");

                /*" -529- DISPLAY '* Catalogacao...: ' WS-COMPILED-EDIT '                 *' */

                $"* Catalogacao...: {RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT}                 *"
                .Display();

                /*" -531- DISPLAY '* Execucao......: ' WS-CURRENT-EDIT '                 *' */

                $"* Execucao......: {RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT}                 *"
                .Display();

                /*" -533- DISPLAY '*========================================================*' */
                _.Display($"*========================================================*");

                /*" -534- DISPLAY ' ' */
                _.Display($" ");

                /*" -536- DISPLAY 'RSGESSTR - CATALOGADO EM:' WS-COMPILED-EDIT */
                _.Display($"RSGESSTR - CATALOGADO EM:{RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT}");

                /*" -538- MOVE 'NAO' TO WS_PRIMEIRA_VEZ */
                _.Move("NAO", WS_AREAS.WS_PRIMEIRA_VEZ);

                /*" -543- END-IF. */
            }


            /*" -545- IF LK-RSGEWSTR-FUNCAO NOT = 1 AND 2 AND 3 AND 4 AND 5 AND 6 AND 7 */

            if (!RSGEWSTR.LK_RSGEWSTR_FUNCAO.In("1", "2", "3", "4", "5", "6", "7"))
            {

                /*" -546- MOVE 2 TO LK-RSGEWSTR-IND-ERRO */
                _.Move(2, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

                /*" -547- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -551- END-IF. */
            }


            /*" -552- IF LK-RSGEWSTR-FUNCAO NOT = 1 AND 2 AND 6 AND 7 */

            if (!RSGEWSTR.LK_RSGEWSTR_FUNCAO.In("1", "2", "6", "7"))
            {

                /*" -553- MOVE 1 TO LK-RSGEWSTR-IND-ERRO */
                _.Move(1, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

                /*" -554- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -559- END-IF. */
            }


            /*" -565- IF (LK-RSGEWSTR-FUNCAO NOT = 2 AND (LK-RSGEWSTR-INP-STR-LGTH NOT > 0 OR LK-RSGEWSTR-INP-STR-LGTH > WS-LGTH-STR)) OR (LK-RSGEWSTR-FUNCAO = 2 AND (LK-RSGEWSTR-INP-NUM-LGTH NOT > 0 OR LK-RSGEWSTR-INP-NUM-LGTH > WS-LGTH-NUM)) */

            if ((RSGEWSTR.LK_RSGEWSTR_FUNCAO != 2 && (RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH <= 0 || RSGEWSTR.LK_RSGEWSTR_INP_STR.LK_RSGEWSTR_INP_STR_LGTH > VARIAVEIS_APOIO.WS_LGTH_STR)) || (RSGEWSTR.LK_RSGEWSTR_FUNCAO == 2 && (RSGEWSTR.LK_RSGEWSTR_INP_NUM.LK_RSGEWSTR_INP_NUM_LGTH <= 0 || RSGEWSTR.LK_RSGEWSTR_INP_NUM.LK_RSGEWSTR_INP_NUM_LGTH > VARIAVEIS_APOIO.WS_LGTH_NUM)))
            {

                /*" -566- MOVE 5 TO LK-RSGEWSTR-IND-ERRO */
                _.Move(5, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

                /*" -567- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -570- END-IF. */
            }


            /*" -572- MOVE LK-RSGEWSTR-INP-STR TO WS-FONTE-STR. */
            _.Move(RSGEWSTR.LK_RSGEWSTR_INP_STR, WS_FONTE_STR);

            /*" -586- MOVE LK-RSGEWSTR-INP-NUM TO WS-FONTE-NUM. */
            _.Move(RSGEWSTR.LK_RSGEWSTR_INP_NUM, WS_FONTE_NUM);

            /*" -587- EVALUATE LK-RSGEWSTR-FUNCAO */
            switch (RSGEWSTR.LK_RSGEWSTR_FUNCAO.Value)
            {

                /*" -588- WHEN       1 */
                case 1:

                    /*" -589- MOVE WS-CONV-GERAL TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_GERAL, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -590- WHEN       2 */
                    break;
                case 2:

                    /*" -591- MOVE WS-CONV-NUMERICO TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_NUMERICO, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -592- WHEN       3 */
                    break;
                case 3:

                    /*" -593- MOVE WS-CONV-PESSOA TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_PESSOA, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -594- WHEN       4 */
                    break;
                case 4:

                    /*" -595- MOVE WS-CONV-EMPRESA TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_EMPRESA, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -596- WHEN       5 */
                    break;
                case 5:

                    /*" -597- MOVE WS-CONV-ENDERECO TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_ENDERECO, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -598- WHEN       6 */
                    break;
                case 6:

                    /*" -599- MOVE WS-CONV-EMAIL TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_EMAIL, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -600- WHEN       7 */
                    break;
                case 7:

                    /*" -601- MOVE WS-CONV-GERAL TO WS-CONV-AUX */
                    _.Move(WS_TAB_CONVERSAO.WS_CONV_GERAL, VARIAVEIS_APOIO.WS_CONV_AUX);

                    /*" -602- WHEN OTHER */
                    break;
                default:

                    /*" -603- MOVE 2 TO LK-RSGEWSTR-IND-ERRO */
                    _.Move(2, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

                    /*" -604- GO TO R0001-99-FIM */

                    R0001_99_FIM(); //GOTO
                    return;

                    /*" -608- END-EVALUATE. */
                    break;
            }


            /*" -609- EVALUATE LK-RSGEWSTR-FUNCAO */
            switch (RSGEWSTR.LK_RSGEWSTR_FUNCAO.Value)
            {

                /*" -609- WHEN       1 */
                case 1:

                    /*" -609- PERFORM  R1000-CONVERTE-GERAL */

                    R1000_CONVERTE_GERAL_SECTION();

                    /*" -610- WHEN       2 */
                    break;
                case 2:

                    /*" -610- PERFORM  R2000-FORMATA-NUMERO */

                    R2000_FORMATA_NUMERO_SECTION();

                    /*" -611- WHEN       3 */
                    break;
                case 3:

                    /*" -611- PERFORM  R3000-FORMATA-PESSOA */

                    R3000_FORMATA_PESSOA_SECTION();

                    /*" -612- WHEN       4 */
                    break;
                case 4:

                    /*" -612- PERFORM  R4000-FORMATA-EMPRESA */

                    R4000_FORMATA_EMPRESA_SECTION();

                    /*" -613- WHEN       5 */
                    break;
                case 5:

                    /*" -613- PERFORM  R5000-FORMATA-ENDERECO */

                    R5000_FORMATA_ENDERECO_SECTION();

                    /*" -614- WHEN       6 */
                    break;
                case 6:

                    /*" -614- PERFORM  R6000-FORMATA-EMAIL */

                    R6000_FORMATA_EMAIL_SECTION();

                    /*" -615- WHEN       7 */
                    break;
                case 7:

                    /*" -615- PERFORM  R7000-FORMATA-GERAL */

                    R7000_FORMATA_GERAL_SECTION();

                    /*" -617- WHEN OTHER */
                    break;
                default:

                    /*" -618- MOVE 2 TO LK-RSGEWSTR-IND-ERRO */
                    _.Move(2, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

                    /*" -619- GO TO R0001-99-FIM */

                    R0001_99_FIM(); //GOTO
                    return;

                    /*" -619- END-EVALUATE. */
                    break;
            }


            /*" -0- FLUXCONTROL_PERFORM R0001_99_FIM */

            R0001_99_FIM();

        }

        [StopWatch]
        /*" R0001-99-FIM */
        private void R0001_99_FIM(bool isPerform = false)
        {
            /*" -625- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R1000-CONVERTE-GERAL-SECTION */
        private void R1000_CONVERTE_GERAL_SECTION()
        {
            /*" -636- INSPECT WS-FONTE-STR-DATA CONVERTING WS-CONV-ORIGEM TO WS-CONV-AUX. */
            WS_FONTE_STR.WS_FONTE_STR_DATA.Value = _.InspectConvert(WS_FONTE_STR.WS_FONTE_STR_DATA, WS_TAB_CONVERSAO.WS_CONV_ORIGEM, VARIAVEIS_APOIO.WS_CONV_AUX);

            /*" -641- MOVE WS-LGTH-STR TO WS-FONTE-STR-LGTH. */
            _.Move(VARIAVEIS_APOIO.WS_LGTH_STR, WS_FONTE_STR.WS_FONTE_STR_LGTH);

            /*" -642- MOVE ZEROS TO WS-QTD-BRANCOS. */
            _.Move(0, VARIAVEIS_APOIO.WS_QTD_BRANCOS);

            /*" -645- INSPECT FUNCTION REVERSE(WS-FONTE-STR-DATA) TALLYING WS-QTD-BRANCOS FOR LEADING SPACE. */
            VARIAVEIS_APOIO.WS_QTD_BRANCOS.Value = WS_FONTE_STR.WS_FONTE_STR_DATA.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -647- COMPUTE WS-FONTE-STR-LGTH = WS-LGTH-STR - WS-QTD-BRANCOS. */
            WS_FONTE_STR.WS_FONTE_STR_LGTH.Value = VARIAVEIS_APOIO.WS_LGTH_STR - VARIAVEIS_APOIO.WS_QTD_BRANCOS;

            /*" -647- MOVE WS-FONTE-STR TO LK-RSGEWSTR-OUT-STR. */
            _.Move(WS_FONTE_STR, RSGEWSTR.LK_RSGEWSTR_OUT_STR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_FIM*/

        [StopWatch]
        /*" R2000-FORMATA-NUMERO-SECTION */
        private void R2000_FORMATA_NUMERO_SECTION()
        {
            /*" -664- INSPECT WS-FONTE-NUM-DATA CONVERTING WS-CONV-ORIGEM TO WS-CONV-AUX */
            WS_FONTE_NUM.WS_FONTE_NUM_DATA.Value = _.InspectConvert(WS_FONTE_NUM.WS_FONTE_NUM_DATA, WS_TAB_CONVERSAO.WS_CONV_ORIGEM, VARIAVEIS_APOIO.WS_CONV_AUX);

            /*" -665- MOVE ZEROS TO WS-INI. */
            _.Move(0, VARIAVEIS_APOIO.WS_INI);

            /*" -667- MOVE WS-LGTH-NUM TO WS-FONTE-NUM-LGTH. */
            _.Move(VARIAVEIS_APOIO.WS_LGTH_NUM, WS_FONTE_NUM.WS_FONTE_NUM_LGTH);

            /*" -670- INSPECT WS-FONTE-NUM-DATA TALLYING WS-INI FOR LEADING SPACE. */
            VARIAVEIS_APOIO.WS_INI.Value = WS_FONTE_NUM.WS_FONTE_NUM_DATA.ToString().TakeWhile(x => x == ' ').Count();

            /*" -671- IF WS-INI IS LESS THAN WS-LGTH-NUM THEN */

            if (VARIAVEIS_APOIO.WS_INI < VARIAVEIS_APOIO.WS_LGTH_NUM)
            {

                /*" -673- MOVE WS-FONTE-NUM-DATA (WS-INI + 1 : WS-LGTH-NUM - WS-INI) TO WS-FONTE-NUM-DATA */
                _.Move(WS_FONTE_NUM.WS_FONTE_NUM_DATA.Substring(VARIAVEIS_APOIO.WS_INI + 1, VARIAVEIS_APOIO.WS_LGTH_NUM - VARIAVEIS_APOIO.WS_INI), WS_FONTE_NUM.WS_FONTE_NUM_DATA);

                /*" -677- END-IF. */
            }


            /*" -678- MOVE ZEROS TO WS-I-DEST. */
            _.Move(0, VARIAVEIS_APOIO.WS_I_DEST);

            /*" -681- PERFORM VARYING WS-INI FROM 1 BY 1 UNTIL WS-INI > WS-LGTH-NUM */

            for (VARIAVEIS_APOIO.WS_INI.Value = 1; !(VARIAVEIS_APOIO.WS_INI > VARIAVEIS_APOIO.WS_LGTH_NUM); VARIAVEIS_APOIO.WS_INI.Value += 1)
            {

                /*" -682- IF WS-FONTE-NUM-DATA(WS-INI:1) NOT = SPACE THEN */

                if (WS_FONTE_NUM.WS_FONTE_NUM_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1) != " ")
                {

                    /*" -683- ADD 1 TO WS-I-DEST */
                    VARIAVEIS_APOIO.WS_I_DEST.Value = VARIAVEIS_APOIO.WS_I_DEST + 1;

                    /*" -685- MOVE WS-FONTE-NUM-DATA(WS-INI:1) TO WS-NUM-AUX(WS-I-DEST:1) */
                    _.MoveAtPosition(WS_FONTE_NUM.WS_FONTE_NUM_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1), VARIAVEIS_APOIO.WS_NUM_AUX, VARIAVEIS_APOIO.WS_I_DEST, 1);

                    /*" -687- END-IF */
                }


                /*" -689- END-PERFORM. */
            }

            /*" -693- MOVE WS-I-DEST TO LK-RSGEWSTR-OUT-NUM-LGTH. */
            _.Move(VARIAVEIS_APOIO.WS_I_DEST, RSGEWSTR.LK_RSGEWSTR_OUT_NUM.LK_RSGEWSTR_OUT_NUM_LGTH);

            /*" -694- MOVE WS-NUM-AUX(1:WS-I-DEST) TO WS-NUM-AUX-RIGHT. */
            _.Move(VARIAVEIS_APOIO.WS_NUM_AUX.Substring(1, VARIAVEIS_APOIO.WS_I_DEST), VARIAVEIS_APOIO.WS_NUM_AUX_RIGHT);

            /*" -696- INSPECT WS-NUM-AUX-RIGHT CONVERTING SPACE TO ZEROS. */
            VARIAVEIS_APOIO.WS_NUM_AUX_RIGHT.Value = System.Text.RegularExpressions.Regex.Replace(VARIAVEIS_APOIO.WS_NUM_AUX_RIGHT, @" ", @"0");

            /*" -700- MOVE WS-NUM-AUX-RIGHT TO LK-RSGEWSTR-OUT-NUM-DATA. */
            _.Move(VARIAVEIS_APOIO.WS_NUM_AUX_RIGHT, RSGEWSTR.LK_RSGEWSTR_OUT_NUM.LK_RSGEWSTR_OUT_NUM_DATA);

            /*" -701- MOVE ALL '9' TO WS-NUM-MAX. */
            _.MoveAll("9", VARIAVEIS_APOIO.WS_NUM_MAX);

            /*" -703- MOVE ZEROS TO WS-NUM-MAX(1: WS-LGTH-NUM - LK-RSGEWSTR-INP-NUM-LGTH) */
            _.MoveAtPosition(0, VARIAVEIS_APOIO.WS_NUM_MAX, 1, VARIAVEIS_APOIO.WS_LGTH_NUM - RSGEWSTR.LK_RSGEWSTR_INP_NUM.LK_RSGEWSTR_INP_NUM_LGTH);

            /*" -704- IF LK-RSGEWSTR-OUT-NUM-DATA > WS-NUM-MAX THEN */

            if (RSGEWSTR.LK_RSGEWSTR_OUT_NUM.LK_RSGEWSTR_OUT_NUM_DATA > VARIAVEIS_APOIO.WS_NUM_MAX)
            {

                /*" -705- MOVE 4 TO LK-RSGEWSTR-IND-ERRO */
                _.Move(4, RSGEWSTR.LK_RSGEWSTR_IND_ERRO);

                /*" -705- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_FIM*/

        [StopWatch]
        /*" R3000-FORMATA-PESSOA-SECTION */
        private void R3000_FORMATA_PESSOA_SECTION()
        {
            /*" -714- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_FIM*/

        [StopWatch]
        /*" R4000-FORMATA-EMPRESA-SECTION */
        private void R4000_FORMATA_EMPRESA_SECTION()
        {
            /*" -721- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_FIM*/

        [StopWatch]
        /*" R5000-FORMATA-ENDERECO-SECTION */
        private void R5000_FORMATA_ENDERECO_SECTION()
        {
            /*" -728- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_FIM*/

        [StopWatch]
        /*" R6000-FORMATA-EMAIL-SECTION */
        private void R6000_FORMATA_EMAIL_SECTION()
        {
            /*" -741- INSPECT WS-FONTE-STR-DATA CONVERTING WS-CONV-ORIGEM TO WS-CONV-AUX. */
            WS_FONTE_STR.WS_FONTE_STR_DATA.Value = _.InspectConvert(WS_FONTE_STR.WS_FONTE_STR_DATA, WS_TAB_CONVERSAO.WS_CONV_ORIGEM, VARIAVEIS_APOIO.WS_CONV_AUX);

            /*" -742- MOVE ZEROS TO WS-INI. */
            _.Move(0, VARIAVEIS_APOIO.WS_INI);

            /*" -744- MOVE WS-LGTH-STR TO WS-FONTE-STR-LGTH. */
            _.Move(VARIAVEIS_APOIO.WS_LGTH_STR, WS_FONTE_STR.WS_FONTE_STR_LGTH);

            /*" -747- INSPECT WS-FONTE-STR-DATA TALLYING WS-INI FOR LEADING SPACE. */
            VARIAVEIS_APOIO.WS_INI.Value = WS_FONTE_STR.WS_FONTE_STR_DATA.ToString().TakeWhile(x => x == ' ').Count();

            /*" -748- IF WS-INI IS LESS THAN WS-LGTH-STR THEN */

            if (VARIAVEIS_APOIO.WS_INI < VARIAVEIS_APOIO.WS_LGTH_STR)
            {

                /*" -750- MOVE WS-FONTE-STR-DATA (WS-INI + 1 : WS-LGTH-STR - WS-INI) TO WS-FONTE-STR-DATA */
                _.Move(WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI + 1, VARIAVEIS_APOIO.WS_LGTH_STR - VARIAVEIS_APOIO.WS_INI), WS_FONTE_STR.WS_FONTE_STR_DATA);

                /*" -754- END-IF. */
            }


            /*" -755- MOVE ZEROS TO WS-I-DEST. */
            _.Move(0, VARIAVEIS_APOIO.WS_I_DEST);

            /*" -758- PERFORM VARYING WS-INI FROM 1 BY 1 UNTIL WS-INI > WS-LGTH-STR */

            for (VARIAVEIS_APOIO.WS_INI.Value = 1; !(VARIAVEIS_APOIO.WS_INI > VARIAVEIS_APOIO.WS_LGTH_STR); VARIAVEIS_APOIO.WS_INI.Value += 1)
            {

                /*" -760- IF WS-FONTE-STR-DATA(WS-INI:1) NOT = SPACE THEN */

                if (WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1) != " ")
                {

                    /*" -762- ADD 1 TO WS-I-DEST */
                    VARIAVEIS_APOIO.WS_I_DEST.Value = VARIAVEIS_APOIO.WS_I_DEST + 1;

                    /*" -765- MOVE WS-FONTE-STR-DATA(WS-INI:1) TO LK-RSGEWSTR-OUT-STR-DATA(WS-I-DEST:1) */
                    _.MoveAtPosition(WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1), RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_DATA, VARIAVEIS_APOIO.WS_I_DEST, 1);

                    /*" -767- END-IF */
                }


                /*" -769- END-PERFORM. */
            }

            /*" -769- COMPUTE LK-RSGEWSTR-OUT-STR-LGTH = WS-I-DEST. */
            RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_LGTH.Value = VARIAVEIS_APOIO.WS_I_DEST;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_FIM*/

        [StopWatch]
        /*" R7000-FORMATA-GERAL-SECTION */
        private void R7000_FORMATA_GERAL_SECTION()
        {
            /*" -785- INSPECT WS-FONTE-STR-DATA CONVERTING WS-CONV-ORIGEM TO WS-CONV-AUX. */
            WS_FONTE_STR.WS_FONTE_STR_DATA.Value = _.InspectConvert(WS_FONTE_STR.WS_FONTE_STR_DATA, WS_TAB_CONVERSAO.WS_CONV_ORIGEM, VARIAVEIS_APOIO.WS_CONV_AUX);

            /*" -786- MOVE ZEROS TO WS-INI. */
            _.Move(0, VARIAVEIS_APOIO.WS_INI);

            /*" -788- MOVE WS-LGTH-STR TO WS-FONTE-STR-LGTH. */
            _.Move(VARIAVEIS_APOIO.WS_LGTH_STR, WS_FONTE_STR.WS_FONTE_STR_LGTH);

            /*" -791- INSPECT WS-FONTE-STR-DATA TALLYING WS-INI FOR LEADING SPACE. */
            VARIAVEIS_APOIO.WS_INI.Value = WS_FONTE_STR.WS_FONTE_STR_DATA.ToString().TakeWhile(x => x == ' ').Count();

            /*" -792- IF WS-INI IS LESS THAN WS-LGTH-STR THEN */

            if (VARIAVEIS_APOIO.WS_INI < VARIAVEIS_APOIO.WS_LGTH_STR)
            {

                /*" -794- MOVE WS-FONTE-STR-DATA (WS-INI + 1 : WS-LGTH-STR - WS-INI) TO WS-FONTE-STR-DATA */
                _.Move(WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI + 1, VARIAVEIS_APOIO.WS_LGTH_STR - VARIAVEIS_APOIO.WS_INI), WS_FONTE_STR.WS_FONTE_STR_DATA);

                /*" -798- END-IF. */
            }


            /*" -799- MOVE ZEROS TO WS-I-DEST. */
            _.Move(0, VARIAVEIS_APOIO.WS_I_DEST);

            /*" -800- MOVE 'NAO' TO WS-MOVE. */
            _.Move("NAO", VARIAVEIS_APOIO.WS_MOVE);

            /*" -803- PERFORM VARYING WS-INI FROM 1 BY 1 UNTIL WS-INI > WS-LGTH-STR */

            for (VARIAVEIS_APOIO.WS_INI.Value = 1; !(VARIAVEIS_APOIO.WS_INI > VARIAVEIS_APOIO.WS_LGTH_STR); VARIAVEIS_APOIO.WS_INI.Value += 1)
            {

                /*" -807- IF (WS-FONTE-STR-DATA(WS-INI:1) = SPACE AND WS-MOVE = 'SIM' ) OR WS-FONTE-STR-DATA(WS-INI:1) NOT = SPACE THEN */

                if ((WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1) == " " && VARIAVEIS_APOIO.WS_MOVE == "SIM") || WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1) != " ")
                {

                    /*" -808- ADD 1 TO WS-I-DEST */
                    VARIAVEIS_APOIO.WS_I_DEST.Value = VARIAVEIS_APOIO.WS_I_DEST + 1;

                    /*" -810- MOVE 'SIM' TO WS-MOVE */
                    _.Move("SIM", VARIAVEIS_APOIO.WS_MOVE);

                    /*" -813- MOVE WS-FONTE-STR-DATA(WS-INI:1) TO LK-RSGEWSTR-OUT-STR-DATA(WS-I-DEST:1) */
                    _.MoveAtPosition(WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1), RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_DATA, VARIAVEIS_APOIO.WS_I_DEST, 1);

                    /*" -814- IF WS-FONTE-STR-DATA(WS-INI:1) = SPACE THEN */

                    if (WS_FONTE_STR.WS_FONTE_STR_DATA.Substring(VARIAVEIS_APOIO.WS_INI, 1) == " ")
                    {

                        /*" -815- MOVE 'NAO' TO WS-MOVE */
                        _.Move("NAO", VARIAVEIS_APOIO.WS_MOVE);

                        /*" -817- END-IF */
                    }


                    /*" -819- END-IF */
                }


                /*" -821- END-PERFORM. */
            }

            /*" -821- COMPUTE LK-RSGEWSTR-OUT-STR-LGTH = WS-I-DEST - 1. */
            RSGEWSTR.LK_RSGEWSTR_OUT_STR.LK_RSGEWSTR_OUT_STR_LGTH.Value = VARIAVEIS_APOIO.WS_I_DEST - 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_FIM*/
    }
}