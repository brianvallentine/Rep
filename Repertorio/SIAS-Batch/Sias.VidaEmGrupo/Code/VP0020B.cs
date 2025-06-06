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
using Sias.VidaEmGrupo.DB2.VP0020B;

namespace Code
{
    public class VP0020B
    {
        public bool IsCall { get; set; }

        public VP0020B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VP0020B.                           *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  ATUALIZA O CADASTRO DE FUNCIONARIOS*      */
        /*"      *                             DA CEF A PARTIR DA FITA ENVIDA     *      */
        /*"      *                             MENSALMENTE PELA CEF.              *      */
        /*"      *                             (FUNCIONARIOS CEF ATIVOS)          *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  ALEXANDRE FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO EM 04/05/95 - ALEXANDRE F FONSECA                   *      */
        /*"      *       NOVO LAYOUT DA FITA EM FUNCAO DA ENTRADA DO SRH.         *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO EM 31/10/95 - VIRGINIA                              *      */
        /*"      *       O CAMPO SUREG FICA ALTERADO PARA 3 POSICOES              *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO EM 06/03/96 - VIRGINIA, C/ AUTORIZACAO DO LIDER     *      */
        /*"      *  DE GRUPO EDSON EM FUNCAO DA MIGRACAO DO SISTEMA.              *      */
        /*"      *  FOI TIRADO O 'FOR UPDATE OF'DO SELECT DA V0FUNCIOCEF          *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO EM 12/01/2004 - TERCIO CARVALHO - PASSA A ALTERAR   *      */
        /*"      *  O TIPO DE VINCULO PARA 'INATIVO' PARA O VINCULO 'EMPRECADO CEF*      */
        /*"      *  PARA ATUALIZACAO DO MESMO A CADA REGISTRO PROCESSADO.(TL0401) *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.              MARCEL   07/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CADCEF { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis CADCEF
        {
            get
            {
                _.Move(CADCEF_RECORD, _CADCEF); VarBasis.RedefinePassValue(CADCEF_RECORD, _CADCEF, CADCEF_RECORD); return _CADCEF;
            }
        }
        /*"01  CADCEF-RECORD.*/
        public VP0020B_CADCEF_RECORD CADCEF_RECORD { get; set; } = new VP0020B_CADCEF_RECORD();
        public class VP0020B_CADCEF_RECORD : VarBasis
        {
            /*"    03 CADCEF-MATRICULA    PIC 9(7).*/
            public IntBasis CADCEF_MATRICULA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"    03 CADCEF-NOME-FUNC    PIC X(40).*/
            public StringBasis CADCEF_NOME_FUNC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    03 CADCEF-FILIAL       PIC 9(3).*/
            public IntBasis CADCEF_FILIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
            /*"    03 CADCEF-LOTACAO      PIC 9(4).*/
            public IntBasis CADCEF_LOTACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 CADCEF-DV           PIC 9(1).*/
            public IntBasis CADCEF_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
            /*"    03 CADCEF-AGENCIA      PIC 9(4).*/
            public IntBasis CADCEF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 CADCEF-OPERACAO     PIC 9(4).*/
            public IntBasis CADCEF_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 CADCEF-CONTA        PIC 9(12).*/
            public IntBasis CADCEF_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    03 CADCEF-DV-CONTA     PIC X(1).*/
            public StringBasis CADCEF_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    03 CADCEF-CPF          PIC 9(11).*/
            public IntBasis CADCEF_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"    03 CADCEF-ENDERECO     PIC X(70).*/
            public StringBasis CADCEF_ENDERECO { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
            /*"    03 CADCEF-CEP          PIC 9(8).*/
            public IntBasis CADCEF_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(8)."));
            /*"    03 CADCEF-CIDADE       PIC X(22).*/
            public StringBasis CADCEF_CIDADE { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
            /*"    03 CADCEF-UF           PIC X(2).*/
            public StringBasis CADCEF_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"    03 CADCEF-DTNASC.*/
            public VP0020B_CADCEF_DTNASC CADCEF_DTNASC { get; set; } = new VP0020B_CADCEF_DTNASC();
            public class VP0020B_CADCEF_DTNASC : VarBasis
            {
                /*"       05 CADCEF-DIA-NASC  PIC 9(02).*/
                public IntBasis CADCEF_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER           PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 CADCEF-MES-NASC  PIC 9(02).*/
                public IntBasis CADCEF_MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER           PIC X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 CADCEF-ANO-NASC  PIC 9(04).*/
                public IntBasis CADCEF_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            }
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WCEP                   PIC S9(09) COMP.*/
        public IntBasis WCEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  SQL-DERAR              PIC S9(4)       COMP.*/
        public IntBasis SQL_DERAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-SUREG              PIC S9(4)       COMP.*/
        public IntBasis SQL_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-UNIDADE            PIC S9(4)       COMP.*/
        public IntBasis SQL_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-UNID-ORIG          PIC S9(4)       COMP.*/
        public IntBasis SQL_UNID_ORIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-DV                 PIC S9(4)       COMP.*/
        public IntBasis SQL_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-NOME-UNID          PIC X(40).*/
        public StringBasis SQL_NOME_UNID { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  SQLCEF-NOME-UNID       PIC X(40).*/
        public StringBasis SQLCEF_NOME_UNID { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  SQL-MATRICULA          PIC S9(15)      COMP-3.*/
        public IntBasis SQL_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SQL-NOME-FUNC          PIC X(40).*/
        public StringBasis SQL_NOME_FUNC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  SQL-TIPO-VINC          PIC X(13).*/
        public StringBasis SQL_TIPO_VINC { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
        /*"01  SQL-DATA-NASC          PIC S9(9)       COMP-3.*/
        public IntBasis SQL_DATA_NASC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  SQL-CPF                PIC S9(11)      COMP-3.*/
        public IntBasis SQL_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"01  SQL-ENDERECO           PIC X(49).*/
        public StringBasis SQL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "49", "X(49)."), @"");
        /*"01  SQL-CIDADE             PIC X(22).*/
        public StringBasis SQL_CIDADE { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
        /*"01  SQL-UF                 PIC X(2).*/
        public StringBasis SQL_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"01  SQL-CEP                PIC S9(9)       COMP-3.*/
        public IntBasis SQL_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  SQL-AGENCIA            PIC S9(4)       COMP.*/
        public IntBasis SQL_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-NOVA-AGENCIA       PIC S9(4)       COMP.*/
        public IntBasis SQL_NOVA_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-OPERACAO           PIC S9(4)       COMP.*/
        public IntBasis SQL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-CONTA              PIC S9(13)      COMP-3.*/
        public IntBasis SQL_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  SQL-DV-CONTA           PIC S9(4)       COMP.*/
        public IntBasis SQL_DV_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-RUBRICA            PIC S9(4)       COMP.*/
        public IntBasis SQL_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-TIPO1              PIC S9(4)       COMP.*/
        public IntBasis SQL_TIPO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-TIPO2              PIC S9(4)       COMP.*/
        public IntBasis SQL_TIPO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-TIPO3              PIC S9(4)       COMP.*/
        public IntBasis SQL_TIPO3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-VALOR1             PIC S9(7)V99    COMP-3.*/
        public DoubleBasis SQL_VALOR1 { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V99"), 2);
        /*"01  SQL-VALOR2             PIC S9(7)V99    COMP-3.*/
        public DoubleBasis SQL_VALOR2 { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V99"), 2);
        /*"01  SQL-VALOR3             PIC S9(7)V99    COMP-3.*/
        public DoubleBasis SQL_VALOR3 { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V99"), 2);
        /*"01  SQL-MES-VIG            PIC S9(4)       COMP.*/
        public IntBasis SQL_MES_VIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-ANGARIADOR         PIC S9(9)       COMP.*/
        public IntBasis SQL_ANGARIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  SQL-CERTIF-PREF        PIC S9(11)      COMP-3.*/
        public IntBasis SQL_CERTIF_PREF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"01  SQL-STATUS731          PIC X(1).*/
        public StringBasis SQL_STATUS731 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  SQL-PREMIO731          PIC S9(5)V99    COMP-3.*/
        public DoubleBasis SQL_PREMIO731 { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V99"), 2);
        /*"01  WSQL-NULL              PIC S9(4)       COMP   VALUE -1.*/
        public IntBasis WSQL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), -1);
        /*"01  SQL-NOT-NULL           PIC S9(4)       COMP   VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), +1);
        /*"01  SQL-IND-ANGAR          PIC S9(4)       COMP.*/
        public IntBasis SQL_IND_ANGAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-EOF                          PIC 9 VALUE 0.*/
        public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
        /*"01  WS-FLAG-ALT                     PIC 9 VALUE 0.*/
        public IntBasis WS_FLAG_ALT { get; set; } = new IntBasis(new PIC("9", "1", "9"));
        /*"01  WS-ACC-INC                      PIC 9(6) VALUE 0.*/
        public IntBasis WS_ACC_INC { get; set; } = new IntBasis(new PIC("9", "6", "9(6)"));
        /*"01  WS-ACC-ALT                      PIC 9(6) VALUE 0.*/
        public IntBasis WS_ACC_ALT { get; set; } = new IntBasis(new PIC("9", "6", "9(6)"));
        /*"01  WS-ACC-NAO-ALT                  PIC 9(6) VALUE 0.*/
        public IntBasis WS_ACC_NAO_ALT { get; set; } = new IntBasis(new PIC("9", "6", "9(6)"));
        /*"01  WS-ACC-COMMIT                   PIC 9(6) VALUE 0.*/
        public IntBasis WS_ACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "6", "9(6)"));
        /*"01  WS-DATA-NASC-9                  PIC 9(09).*/
        public IntBasis WS_DATA_NASC_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
        /*"01  WS-DATA-NASC                    PIC 9(09) VALUE 0.*/
        public IntBasis WS_DATA_NASC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  WS-DATA-NASC-R                  REDEFINES    WS-DATA-NASC .*/
        private _REDEF_VP0020B_WS_DATA_NASC_R _ws_data_nasc_r { get; set; }
        public _REDEF_VP0020B_WS_DATA_NASC_R WS_DATA_NASC_R
        {
            get { _ws_data_nasc_r = new _REDEF_VP0020B_WS_DATA_NASC_R(); _.Move(WS_DATA_NASC, _ws_data_nasc_r); VarBasis.RedefinePassValue(WS_DATA_NASC, _ws_data_nasc_r, WS_DATA_NASC); _ws_data_nasc_r.ValueChanged += () => { _.Move(_ws_data_nasc_r, WS_DATA_NASC); }; return _ws_data_nasc_r; }
            set { VarBasis.RedefinePassValue(value, _ws_data_nasc_r, WS_DATA_NASC); }
        }  //Redefines
        public class _REDEF_VP0020B_WS_DATA_NASC_R : VarBasis
        {
            /*"    03 FILLER                       PIC X(1).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    03 WS-DIA-NASC                  PIC 9(2).*/
            public IntBasis WS_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
            /*"    03 WS-MES-NASC                  PIC 9(2).*/
            public IntBasis WS_MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
            /*"    03 WS-ANO-NASC                  PIC 9(4).*/
            public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"01  WS-CONTA-FUNC.*/

            public _REDEF_VP0020B_WS_DATA_NASC_R()
            {
                FILLER_2.ValueChanged += OnValueChanged;
                WS_DIA_NASC.ValueChanged += OnValueChanged;
                WS_MES_NASC.ValueChanged += OnValueChanged;
                WS_ANO_NASC.ValueChanged += OnValueChanged;
            }

        }
        public VP0020B_WS_CONTA_FUNC WS_CONTA_FUNC { get; set; } = new VP0020B_WS_CONTA_FUNC();
        public class VP0020B_WS_CONTA_FUNC : VarBasis
        {
            /*"    03 WS-AGENCIA-F                 PIC 9(4).*/
            public IntBasis WS_AGENCIA_F { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 WS-OPERACAO-F                PIC 9(4).*/
            public IntBasis WS_OPERACAO_F { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 WS-CONTA-F                   PIC 9(12).*/
            public IntBasis WS_CONTA_F { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    03 WS-DV-CONTA-F                PIC 9(1).*/
            public IntBasis WS_DV_CONTA_F { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
            /*"01  WS-CONTA-MOV.*/
        }
        public VP0020B_WS_CONTA_MOV WS_CONTA_MOV { get; set; } = new VP0020B_WS_CONTA_MOV();
        public class VP0020B_WS_CONTA_MOV : VarBasis
        {
            /*"    03 WS-AGENCIA-M                 PIC 9(4).*/
            public IntBasis WS_AGENCIA_M { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 WS-OPERACAO-M                PIC 9(4).*/
            public IntBasis WS_OPERACAO_M { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 WS-CONTA-M                   PIC 9(12).*/
            public IntBasis WS_CONTA_M { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    03 WS-DV-CONTA-M                PIC 9(1).*/
            public IntBasis WS_DV_CONTA_M { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
            /*"01  WS-SUREG                        PIC 9(2).*/
        }
        public IntBasis WS_SUREG { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
        /*"01  WS-UNIDADE                      PIC 9(4).*/
        public IntBasis WS_UNIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
        /*"01  WS-DV                           PIC 9(1).*/
        public IntBasis WS_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
        /*"01  WS-NOME-UNID                    PIC X(35).*/
        public StringBasis WS_NOME_UNID { get; set; } = new StringBasis(new PIC("X", "35", "X(35)."), @"");
        /*"01  WS-NOME-FUNC                    PIC X(40).*/
        public StringBasis WS_NOME_FUNC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  WS-TIPO-VINC                    PIC X(13).*/
        public StringBasis WS_TIPO_VINC { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
        /*"01  WS-CPF                          PIC 9(11).*/
        public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
        /*"01  WS-ENDERECO                     PIC X(49).*/
        public StringBasis WS_ENDERECO { get; set; } = new StringBasis(new PIC("X", "49", "X(49)."), @"");
        /*"01  WS-CIDADE                       PIC X(22).*/
        public StringBasis WS_CIDADE { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
        /*"01  WS-UF                           PIC X(2).*/
        public StringBasis WS_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"01  WS-AGENCIA                      PIC 9(4).*/
        public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
        /*"01  WS-OPERACAO                     PIC 9(4).*/
        public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
        /*"01  WS-CONTA                        PIC 9(12).*/
        public IntBasis WS_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
        /*"01  WS-DV-CONTA                     PIC 9(1).*/
        public IntBasis WS_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(1)."));
        /*"01  WABEND.*/
        public VP0020B_WABEND WABEND { get; set; } = new VP0020B_WABEND();
        public class VP0020B_WABEND : VarBasis
        {
            /*"    03 FILLER       PIC X(010) VALUE 'VP0020B '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VP0020B ");
            /*"    03 FILLER       PIC X(026) VALUE '*** ERRO EXEC SQL NUMERO '*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"    03 WNR-EXEC-SQL PIC X(005) VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    03 FILLER       PIC X(013) VALUE ' *** SQLCODE '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    03 WSQLCODE     PIC ZZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-."));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CADCEF_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CADCEF.SetFile(CADCEF_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-INICIO */

                M_0000_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-INICIO */
        private void M_0000_INICIO(bool isPerform = false)
        {
            /*" -212- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -212- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -213- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -214- EXEC SQL WHENEVER SQLERROR GO TO 9999-ROT-ERRO END-EXEC. */

            /*" -218- OPEN INPUT CADCEF. */
            CADCEF.Open(CADCEF_RECORD);

            /*" -219- READ CADCEF AT END */
            try
            {
                CADCEF.Read(() =>
                {

                    /*" -220- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -221- DISPLAY '*** VP0020B *** NAO EXISTE FITA CEF  ***' */
                    _.Display($"*** VP0020B *** NAO EXISTE FITA CEF  ***");

                    /*" -222- DISPLAY '*** VP0020B *** TERMINO NORMAL       ***' */
                    _.Display($"*** VP0020B *** TERMINO NORMAL       ***");

                    /*" -223- CLOSE CADCEF */
                    CADCEF.Close();

                    /*" -224- MOVE 0 TO RETURN-CODE */
                    _.Move(0, RETURN_CODE);

                    /*" -230- STOP RUN. */

                    throw new GoBack();   // => STOP RUN.
                });

                _.Move(CADCEF.Value, CADCEF_RECORD);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -231- DISPLAY ' ' . */
            _.Display($" ");

            /*" -233- DISPLAY '*** VP0020B *** PROCESSANDO ...' . */
            _.Display($"*** VP0020B *** PROCESSANDO ...");

            /*" -235- PERFORM 1230-UPDATE-FUNC THRU 1230-FIM. */

            M_1230_UPDATE_FUNC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1230_FIM*/


            /*" -241- PERFORM 1000-PROCESSA THRU 1000-FIM UNTIL WS-EOF = 1. */

            while (!(WS_EOF == 1))
            {

                M_1000_PROCESSA(true);

                M_1000_LE_OUTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -242- DISPLAY ' ' . */
            _.Display($" ");

            /*" -243- DISPLAY '*** VP0020B *** COMMITING ...' . */
            _.Display($"*** VP0020B *** COMMITING ...");

            /*" -244- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", WABEND.WNR_EXEC_SQL);

            /*" -244- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -248- CLOSE CADCEF. */
            CADCEF.Close();

            /*" -249- DISPLAY ' ' . */
            _.Display($" ");

            /*" -250- DISPLAY '*** VP0020B *** INCLUIDOS .......: ' WS-ACC-INC. */
            _.Display($"*** VP0020B *** INCLUIDOS .......: {WS_ACC_INC}");

            /*" -251- DISPLAY '*** VP0020B *** ALTERADOS .......: ' WS-ACC-ALT. */
            _.Display($"*** VP0020B *** ALTERADOS .......: {WS_ACC_ALT}");

            /*" -252- DISPLAY '*** VP0020B *** NAO-ALTERADOS ...: ' WS-ACC-NAO-ALT. */
            _.Display($"*** VP0020B *** NAO-ALTERADOS ...: {WS_ACC_NAO_ALT}");

            /*" -253- DISPLAY ' ' . */
            _.Display($" ");

            /*" -254- DISPLAY '*** VP0020B *** TERMINO NORMAL ***' . */
            _.Display($"*** VP0020B *** TERMINO NORMAL ***");

            /*" -256- DISPLAY ' ' . */
            _.Display($" ");

            /*" -257- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -257- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-1000-PROCESSA */
        private void M_1000_PROCESSA(bool isPerform = false)
        {
            /*" -267- MOVE CADCEF-MATRICULA TO SQL-MATRICULA. */
            _.Move(CADCEF_RECORD.CADCEF_MATRICULA, SQL_MATRICULA);

            /*" -268- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", WABEND.WNR_EXEC_SQL);

            /*" -306- PERFORM M_1000_PROCESSA_DB_SELECT_1 */

            M_1000_PROCESSA_DB_SELECT_1();

            /*" -309- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -310- PERFORM 1100-INCLUSAO THRU 1100-FIM */

                M_1100_INCLUSAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


                /*" -311- ELSE */
            }
            else
            {


                /*" -312- IF SQLCODE = 0 */

                if (DB.SQLCODE == 0)
                {

                    /*" -313- PERFORM 1200-ALTERACAO THRU 1200-FIM */

                    M_1200_ALTERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


                    /*" -314- ELSE */
                }
                else
                {


                    /*" -315- DISPLAY 'ERRO SQL ' */
                    _.Display($"ERRO SQL ");

                    /*" -315- GO TO 9999-ROT-ERRO. */

                    M_9999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-1 */
        public void M_1000_PROCESSA_DB_SELECT_1()
        {
            /*" -306- EXEC SQL SELECT COD_SUREG, COD_UNIDADE, DIG_UNIDADE, NOME_UNIDADE, NOME_FUNCIONARIO, TIPO_VINCULO, NASCIMENTO, NUM_CPF, ENDERECO_CEF, CIDADE_CEF, SIGLA_UF, CEP, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA, COD_ANGARIADOR INTO :SQL-SUREG, :SQL-UNIDADE, :SQL-DV, :SQLCEF-NOME-UNID, :SQL-NOME-FUNC, :SQL-TIPO-VINC, :SQL-DATA-NASC, :SQL-CPF, :SQL-ENDERECO, :SQL-CIDADE, :SQL-UF, :SQL-CEP, :SQL-AGENCIA, :SQL-OPERACAO, :SQL-CONTA, :SQL-DV-CONTA, :SQL-ANGARIADOR:SQL-IND-ANGAR FROM SEGUROS.V0FUNCIOCEF WHERE NUM_MATRICULA = :SQL-MATRICULA END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_1_Query1 = new M_1000_PROCESSA_DB_SELECT_1_Query1()
            {
                SQL_MATRICULA = SQL_MATRICULA.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_SUREG, SQL_SUREG);
                _.Move(executed_1.SQL_UNIDADE, SQL_UNIDADE);
                _.Move(executed_1.SQL_DV, SQL_DV);
                _.Move(executed_1.SQLCEF_NOME_UNID, SQLCEF_NOME_UNID);
                _.Move(executed_1.SQL_NOME_FUNC, SQL_NOME_FUNC);
                _.Move(executed_1.SQL_TIPO_VINC, SQL_TIPO_VINC);
                _.Move(executed_1.SQL_DATA_NASC, SQL_DATA_NASC);
                _.Move(executed_1.SQL_CPF, SQL_CPF);
                _.Move(executed_1.SQL_ENDERECO, SQL_ENDERECO);
                _.Move(executed_1.SQL_CIDADE, SQL_CIDADE);
                _.Move(executed_1.SQL_UF, SQL_UF);
                _.Move(executed_1.SQL_CEP, SQL_CEP);
                _.Move(executed_1.SQL_AGENCIA, SQL_AGENCIA);
                _.Move(executed_1.SQL_OPERACAO, SQL_OPERACAO);
                _.Move(executed_1.SQL_CONTA, SQL_CONTA);
                _.Move(executed_1.SQL_DV_CONTA, SQL_DV_CONTA);
                _.Move(executed_1.SQL_ANGARIADOR, SQL_ANGARIADOR);
                _.Move(executed_1.SQL_IND_ANGAR, SQL_IND_ANGAR);
            }


        }

        [StopWatch]
        /*" M-1000-LE-OUTRO */
        private void M_1000_LE_OUTRO(bool isPerform = false)
        {
            /*" -319- READ CADCEF AT END */
            try
            {
                CADCEF.Read(() =>
                {

                    /*" -319- MOVE 1 TO WS-EOF. */
                    _.Move(1, WS_EOF);
                });

                _.Move(CADCEF.Value, CADCEF_RECORD);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-INCLUSAO */
        private void M_1100_INCLUSAO(bool isPerform = false)
        {
            /*" -329- MOVE CADCEF-FILIAL TO SQL-SUREG. */
            _.Move(CADCEF_RECORD.CADCEF_FILIAL, SQL_SUREG);

            /*" -330- MOVE CADCEF-LOTACAO TO SQL-UNIDADE. */
            _.Move(CADCEF_RECORD.CADCEF_LOTACAO, SQL_UNIDADE);

            /*" -331- MOVE CADCEF-DV TO SQL-DV. */
            _.Move(CADCEF_RECORD.CADCEF_DV, SQL_DV);

            /*" -332- MOVE CADCEF-NOME-FUNC TO SQL-NOME-FUNC. */
            _.Move(CADCEF_RECORD.CADCEF_NOME_FUNC, SQL_NOME_FUNC);

            /*" -333- MOVE CADCEF-CPF TO SQL-CPF. */
            _.Move(CADCEF_RECORD.CADCEF_CPF, SQL_CPF);

            /*" -334- MOVE CADCEF-ENDERECO TO SQL-ENDERECO. */
            _.Move(CADCEF_RECORD.CADCEF_ENDERECO, SQL_ENDERECO);

            /*" -335- MOVE CADCEF-CIDADE TO SQL-CIDADE. */
            _.Move(CADCEF_RECORD.CADCEF_CIDADE, SQL_CIDADE);

            /*" -336- MOVE CADCEF-UF TO SQL-UF. */
            _.Move(CADCEF_RECORD.CADCEF_UF, SQL_UF);

            /*" -337- MOVE CADCEF-CEP TO SQL-CEP. */
            _.Move(CADCEF_RECORD.CADCEF_CEP, SQL_CEP);

            /*" -338- MOVE CADCEF-OPERACAO TO SQL-OPERACAO. */
            _.Move(CADCEF_RECORD.CADCEF_OPERACAO, SQL_OPERACAO);

            /*" -339- MOVE CADCEF-AGENCIA TO SQL-AGENCIA. */
            _.Move(CADCEF_RECORD.CADCEF_AGENCIA, SQL_AGENCIA);

            /*" -340- MOVE CADCEF-CONTA TO SQL-CONTA. */
            _.Move(CADCEF_RECORD.CADCEF_CONTA, SQL_CONTA);

            /*" -342- MOVE CADCEF-DV-CONTA TO SQL-DV-CONTA. */
            _.Move(CADCEF_RECORD.CADCEF_DV_CONTA, SQL_DV_CONTA);

            /*" -343- IF SQL-UNIDADE EQUAL ZEROES */

            if (SQL_UNIDADE == 00)
            {

                /*" -344- COMPUTE SQL-UNID-ORIG = 10000 + SQL-SUREG */
                SQL_UNID_ORIG.Value = 10000 + SQL_SUREG;

                /*" -345- ELSE */
            }
            else
            {


                /*" -347- MOVE SQL-UNIDADE TO SQL-UNID-ORIG. */
                _.Move(SQL_UNIDADE, SQL_UNID_ORIG);
            }


            /*" -348- MOVE CADCEF-DIA-NASC TO WS-DIA-NASC. */
            _.Move(CADCEF_RECORD.CADCEF_DTNASC.CADCEF_DIA_NASC, WS_DATA_NASC_R.WS_DIA_NASC);

            /*" -349- MOVE CADCEF-MES-NASC TO WS-MES-NASC. */
            _.Move(CADCEF_RECORD.CADCEF_DTNASC.CADCEF_MES_NASC, WS_DATA_NASC_R.WS_MES_NASC);

            /*" -350- MOVE CADCEF-ANO-NASC TO WS-ANO-NASC. */
            _.Move(CADCEF_RECORD.CADCEF_DTNASC.CADCEF_ANO_NASC, WS_DATA_NASC_R.WS_ANO_NASC);

            /*" -352- MOVE WS-DATA-NASC TO SQL-DATA-NASC. */
            _.Move(WS_DATA_NASC, SQL_DATA_NASC);

            /*" -353- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -359- PERFORM M_1100_INCLUSAO_DB_SELECT_1 */

            M_1100_INCLUSAO_DB_SELECT_1();

            /*" -362- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -364- MOVE SPACES TO SQL-NOME-UNID. */
                _.Move("", SQL_NOME_UNID);
            }


            /*" -365- MOVE '1101' TO WNR-EXEC-SQL. */
            _.Move("1101", WABEND.WNR_EXEC_SQL);

            /*" -435- PERFORM M_1100_INCLUSAO_DB_INSERT_1 */

            M_1100_INCLUSAO_DB_INSERT_1();

            /*" -438- IF CADCEF-AGENCIA > 0 */

            if (CADCEF_RECORD.CADCEF_AGENCIA > 0)
            {

                /*" -439- MOVE '1101' TO WNR-EXEC-SQL */
                _.Move("1101", WABEND.WNR_EXEC_SQL);

                /*" -444- PERFORM M_1100_INCLUSAO_DB_SELECT_2 */

                M_1100_INCLUSAO_DB_SELECT_2();

                /*" -446- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -447- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -450- DISPLAY 'AGENCIA DE CONTA NAO CADASTRADA ' CADCEF-AGENCIA ' MATRICULA ' CADCEF-MATRICULA. */

                    $"AGENCIA DE CONTA NAO CADASTRADA {CADCEF_RECORD.CADCEF_AGENCIA} MATRICULA {CADCEF_RECORD.CADCEF_MATRICULA}"
                    .Display();
                }

            }


            /*" -450- ADD 1 TO WS-ACC-INC. */
            WS_ACC_INC.Value = WS_ACC_INC + 1;

        }

        [StopWatch]
        /*" M-1100-INCLUSAO-DB-SELECT-1 */
        public void M_1100_INCLUSAO_DB_SELECT_1()
        {
            /*" -359- EXEC SQL SELECT NOME_UNIDADE INTO :SQL-NOME-UNID FROM SEGUROS.V0UNIDADECEF WHERE COD_SUREG = :SQL-SUREG AND COD_UNIDADE = :SQL-UNIDADE END-EXEC. */

            var m_1100_INCLUSAO_DB_SELECT_1_Query1 = new M_1100_INCLUSAO_DB_SELECT_1_Query1()
            {
                SQL_UNIDADE = SQL_UNIDADE.ToString(),
                SQL_SUREG = SQL_SUREG.ToString(),
            };

            var executed_1 = M_1100_INCLUSAO_DB_SELECT_1_Query1.Execute(m_1100_INCLUSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_NOME_UNID, SQL_NOME_UNID);
            }


        }

        [StopWatch]
        /*" M-1100-INCLUSAO-DB-INSERT-1 */
        public void M_1100_INCLUSAO_DB_INSERT_1()
        {
            /*" -435- EXEC SQL INSERT INTO SEGUROS.V0FUNCIOCEF (COD_SUREG, COD_UNIDADE, DIG_UNIDADE, NOME_UNIDADE, NUM_MATRICULA, NOME_FUNCIONARIO, TIPO_VINCULO, NASCIMENTO, NUM_CPF, ENDERECO_CEF, CIDADE_CEF, SIGLA_UF, CEP, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA, COD_RUBRICA, TIPO1, TIPO2, TIPO3, VALOR1, VALOR2, VALOR3, MES_VIGENCIA, COD_ANGARIADOR, CERTIF_PREF, STATUS731, PREMIO731, PCT_AUMENTO, UNIDADE_ORIGEM, CLASSE_ORIGEM, SITUACAO) VALUES (:SQL-SUREG, :SQL-UNIDADE, :SQL-DV, :SQL-NOME-UNID, :SQL-MATRICULA, :SQL-NOME-FUNC, 'EMPREGADO CEF' , :SQL-DATA-NASC, :SQL-CPF, :SQL-ENDERECO, :SQL-CIDADE, :SQL-UF, :SQL-CEP, :SQL-AGENCIA, :SQL-OPERACAO, :SQL-CONTA, :SQL-DV-CONTA, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, :SQL-UNID-ORIG:SQL-NOT-NULL, 'A' , '0' ) END-EXEC. */

            var m_1100_INCLUSAO_DB_INSERT_1_Insert1 = new M_1100_INCLUSAO_DB_INSERT_1_Insert1()
            {
                SQL_SUREG = SQL_SUREG.ToString(),
                SQL_UNIDADE = SQL_UNIDADE.ToString(),
                SQL_DV = SQL_DV.ToString(),
                SQL_NOME_UNID = SQL_NOME_UNID.ToString(),
                SQL_MATRICULA = SQL_MATRICULA.ToString(),
                SQL_NOME_FUNC = SQL_NOME_FUNC.ToString(),
                SQL_DATA_NASC = SQL_DATA_NASC.ToString(),
                SQL_CPF = SQL_CPF.ToString(),
                SQL_ENDERECO = SQL_ENDERECO.ToString(),
                SQL_CIDADE = SQL_CIDADE.ToString(),
                SQL_UF = SQL_UF.ToString(),
                SQL_CEP = SQL_CEP.ToString(),
                SQL_AGENCIA = SQL_AGENCIA.ToString(),
                SQL_OPERACAO = SQL_OPERACAO.ToString(),
                SQL_CONTA = SQL_CONTA.ToString(),
                SQL_DV_CONTA = SQL_DV_CONTA.ToString(),
                SQL_UNID_ORIG = SQL_UNID_ORIG.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
            };

            M_1100_INCLUSAO_DB_INSERT_1_Insert1.Execute(m_1100_INCLUSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1100-INCLUSAO-DB-SELECT-2 */
        public void M_1100_INCLUSAO_DB_SELECT_2()
        {
            /*" -444- EXEC SQL SELECT COD_AGENCIA INTO :SQL-AGENCIA FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :SQL-AGENCIA END-EXEC */

            var m_1100_INCLUSAO_DB_SELECT_2_Query1 = new M_1100_INCLUSAO_DB_SELECT_2_Query1()
            {
                SQL_AGENCIA = SQL_AGENCIA.ToString(),
            };

            var executed_1 = M_1100_INCLUSAO_DB_SELECT_2_Query1.Execute(m_1100_INCLUSAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_AGENCIA, SQL_AGENCIA);
            }


        }

        [StopWatch]
        /*" M-1200-ALTERACAO */
        private void M_1200_ALTERACAO(bool isPerform = false)
        {
            /*" -461- MOVE 0 TO WS-FLAG-ALT. */
            _.Move(0, WS_FLAG_ALT);

            /*" -462- MOVE SQL-AGENCIA TO WS-AGENCIA-F. */
            _.Move(SQL_AGENCIA, WS_CONTA_FUNC.WS_AGENCIA_F);

            /*" -463- MOVE SQL-OPERACAO TO WS-OPERACAO-F. */
            _.Move(SQL_OPERACAO, WS_CONTA_FUNC.WS_OPERACAO_F);

            /*" -464- MOVE SQL-CONTA TO WS-CONTA-F. */
            _.Move(SQL_CONTA, WS_CONTA_FUNC.WS_CONTA_F);

            /*" -465- MOVE SQL-DV-CONTA TO WS-DV-CONTA-F. */
            _.Move(SQL_DV_CONTA, WS_CONTA_FUNC.WS_DV_CONTA_F);

            /*" -467- MOVE SQL-DATA-NASC TO WS-DATA-NASC-9. */
            _.Move(SQL_DATA_NASC, WS_DATA_NASC_9);

            /*" -468- MOVE CADCEF-AGENCIA TO WS-AGENCIA-M. */
            _.Move(CADCEF_RECORD.CADCEF_AGENCIA, WS_CONTA_MOV.WS_AGENCIA_M);

            /*" -469- MOVE CADCEF-OPERACAO TO WS-OPERACAO-M. */
            _.Move(CADCEF_RECORD.CADCEF_OPERACAO, WS_CONTA_MOV.WS_OPERACAO_M);

            /*" -470- MOVE CADCEF-CONTA TO WS-CONTA-M. */
            _.Move(CADCEF_RECORD.CADCEF_CONTA, WS_CONTA_MOV.WS_CONTA_M);

            /*" -471- MOVE CADCEF-DV-CONTA TO WS-DV-CONTA-M. */
            _.Move(CADCEF_RECORD.CADCEF_DV_CONTA, WS_CONTA_MOV.WS_DV_CONTA_M);

            /*" -473- MOVE '9' TO WS-DV-CONTA-M. */
            _.Move("9", WS_CONTA_MOV.WS_DV_CONTA_M);

            /*" -474- MOVE CADCEF-DIA-NASC TO WS-DIA-NASC. */
            _.Move(CADCEF_RECORD.CADCEF_DTNASC.CADCEF_DIA_NASC, WS_DATA_NASC_R.WS_DIA_NASC);

            /*" -475- MOVE CADCEF-MES-NASC TO WS-MES-NASC. */
            _.Move(CADCEF_RECORD.CADCEF_DTNASC.CADCEF_MES_NASC, WS_DATA_NASC_R.WS_MES_NASC);

            /*" -479- MOVE CADCEF-ANO-NASC TO WS-ANO-NASC. */
            _.Move(CADCEF_RECORD.CADCEF_DTNASC.CADCEF_ANO_NASC, WS_DATA_NASC_R.WS_ANO_NASC);

            /*" -480- IF WS-CONTA-FUNC NOT EQUAL WS-CONTA-MOV */

            if (WS_CONTA_FUNC != WS_CONTA_MOV)
            {

                /*" -482- PERFORM M-1210-ALTERA-AGENCIA THRU 1210-FIM. */

                M_1210_ALTERA_AGENCIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1210_FIM*/

            }


            /*" -483- MOVE SQL-SUREG TO WS-SUREG. */
            _.Move(SQL_SUREG, WS_SUREG);

            /*" -484- MOVE SQL-UNIDADE TO WS-UNIDADE. */
            _.Move(SQL_UNIDADE, WS_UNIDADE);

            /*" -485- MOVE SQL-DV TO WS-DV. */
            _.Move(SQL_DV, WS_DV);

            /*" -486- MOVE SQL-NOME-FUNC TO WS-NOME-FUNC. */
            _.Move(SQL_NOME_FUNC, WS_NOME_FUNC);

            /*" -487- MOVE SQL-CPF TO WS-CPF. */
            _.Move(SQL_CPF, WS_CPF);

            /*" -488- MOVE SQL-ENDERECO TO WS-ENDERECO. */
            _.Move(SQL_ENDERECO, WS_ENDERECO);

            /*" -489- MOVE SQL-CIDADE TO WS-CIDADE. */
            _.Move(SQL_CIDADE, WS_CIDADE);

            /*" -491- MOVE SQL-UF TO WS-UF. */
            _.Move(SQL_UF, WS_UF);

            /*" -492- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM M_1200_ALTERACAO_DB_SELECT_1 */

            M_1200_ALTERACAO_DB_SELECT_1();

            /*" -500- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -502- MOVE SPACES TO SQL-NOME-UNID. */
                _.Move("", SQL_NOME_UNID);
            }


            /*" -503- IF CADCEF-FILIAL NOT EQUAL WS-SUREG */

            if (CADCEF_RECORD.CADCEF_FILIAL != WS_SUREG)
            {

                /*" -504- MOVE CADCEF-FILIAL TO SQL-SUREG */
                _.Move(CADCEF_RECORD.CADCEF_FILIAL, SQL_SUREG);

                /*" -506- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -507- IF CADCEF-LOTACAO NOT EQUAL WS-UNIDADE */

            if (CADCEF_RECORD.CADCEF_LOTACAO != WS_UNIDADE)
            {

                /*" -508- MOVE CADCEF-LOTACAO TO SQL-UNIDADE */
                _.Move(CADCEF_RECORD.CADCEF_LOTACAO, SQL_UNIDADE);

                /*" -510- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -511- IF CADCEF-DV NOT EQUAL WS-DV */

            if (CADCEF_RECORD.CADCEF_DV != WS_DV)
            {

                /*" -512- MOVE CADCEF-DV TO SQL-DV */
                _.Move(CADCEF_RECORD.CADCEF_DV, SQL_DV);

                /*" -514- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -515- IF SQLCEF-NOME-UNID NOT EQUAL SQL-NOME-UNID */

            if (SQLCEF_NOME_UNID != SQL_NOME_UNID)
            {

                /*" -516- MOVE SQL-NOME-UNID TO SQLCEF-NOME-UNID */
                _.Move(SQL_NOME_UNID, SQLCEF_NOME_UNID);

                /*" -518- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -519- IF CADCEF-NOME-FUNC NOT EQUAL WS-NOME-FUNC */

            if (CADCEF_RECORD.CADCEF_NOME_FUNC != WS_NOME_FUNC)
            {

                /*" -520- MOVE CADCEF-NOME-FUNC TO SQL-NOME-FUNC */
                _.Move(CADCEF_RECORD.CADCEF_NOME_FUNC, SQL_NOME_FUNC);

                /*" -527- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -529- IF CADCEF-CPF NOT EQUAL WS-CPF */

            if (CADCEF_RECORD.CADCEF_CPF != WS_CPF)
            {

                /*" -530- MOVE CADCEF-CPF TO SQL-CPF */
                _.Move(CADCEF_RECORD.CADCEF_CPF, SQL_CPF);

                /*" -532- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -533- IF CADCEF-ENDERECO NOT EQUAL WS-ENDERECO */

            if (CADCEF_RECORD.CADCEF_ENDERECO != WS_ENDERECO)
            {

                /*" -534- MOVE CADCEF-ENDERECO TO SQL-ENDERECO */
                _.Move(CADCEF_RECORD.CADCEF_ENDERECO, SQL_ENDERECO);

                /*" -536- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -537- IF CADCEF-CIDADE NOT EQUAL WS-CIDADE */

            if (CADCEF_RECORD.CADCEF_CIDADE != WS_CIDADE)
            {

                /*" -538- MOVE CADCEF-CIDADE TO SQL-CIDADE */
                _.Move(CADCEF_RECORD.CADCEF_CIDADE, SQL_CIDADE);

                /*" -540- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -541- IF CADCEF-UF NOT EQUAL WS-UF */

            if (CADCEF_RECORD.CADCEF_UF != WS_UF)
            {

                /*" -542- MOVE CADCEF-UF TO SQL-UF */
                _.Move(CADCEF_RECORD.CADCEF_UF, SQL_UF);

                /*" -544- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -546- MOVE CADCEF-CEP TO WCEP. */
            _.Move(CADCEF_RECORD.CADCEF_CEP, WCEP);

            /*" -547- IF WCEP NOT EQUAL SQL-CEP */

            if (WCEP != SQL_CEP)
            {

                /*" -548- MOVE WCEP TO SQL-CEP */
                _.Move(WCEP, SQL_CEP);

                /*" -550- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -551- IF WS-DATA-NASC NOT EQUAL WS-DATA-NASC-9 */

            if (WS_DATA_NASC != WS_DATA_NASC_9)
            {

                /*" -552- MOVE WS-DATA-NASC TO SQL-DATA-NASC */
                _.Move(WS_DATA_NASC, SQL_DATA_NASC);

                /*" -555- MOVE 1 TO WS-FLAG-ALT. */
                _.Move(1, WS_FLAG_ALT);
            }


            /*" -556- PERFORM 1220-UPDATE-FUNC THRU 1220-FIM */

            M_1220_UPDATE_FUNC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1220_FIM*/


            /*" -556- ADD 1 TO WS-ACC-ALT. */
            WS_ACC_ALT.Value = WS_ACC_ALT + 1;

        }

        [StopWatch]
        /*" M-1200-ALTERACAO-DB-SELECT-1 */
        public void M_1200_ALTERACAO_DB_SELECT_1()
        {
            /*" -497- EXEC SQL SELECT NOME_UNIDADE INTO :SQL-NOME-UNID FROM SEGUROS.V0UNIDADECEF WHERE COD_UNIDADE = :SQL-UNIDADE END-EXEC. */

            var m_1200_ALTERACAO_DB_SELECT_1_Query1 = new M_1200_ALTERACAO_DB_SELECT_1_Query1()
            {
                SQL_UNIDADE = SQL_UNIDADE.ToString(),
            };

            var executed_1 = M_1200_ALTERACAO_DB_SELECT_1_Query1.Execute(m_1200_ALTERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_NOME_UNID, SQL_NOME_UNID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1210-ALTERA-AGENCIA */
        private void M_1210_ALTERA_AGENCIA(bool isPerform = false)
        {
            /*" -570- MOVE CADCEF-AGENCIA TO SQL-NOVA-AGENCIA. */
            _.Move(CADCEF_RECORD.CADCEF_AGENCIA, SQL_NOVA_AGENCIA);

            /*" -571- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -576- PERFORM M_1210_ALTERA_AGENCIA_DB_SELECT_1 */

            M_1210_ALTERA_AGENCIA_DB_SELECT_1();

            /*" -579- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -580- DISPLAY ' ' */
                _.Display($" ");

                /*" -581- DISPLAY 'AGENCIA DA CONTA NAO CADASTRADA ' */
                _.Display($"AGENCIA DA CONTA NAO CADASTRADA ");

                /*" -582- DISPLAY 'IMPOSSIVEL ALTERAR CONTA-SALARIO' */
                _.Display($"IMPOSSIVEL ALTERAR CONTA-SALARIO");

                /*" -583- DISPLAY CADCEF-RECORD */
                _.Display(CADCEF_RECORD);

                /*" -585- GO TO 1210-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1210_FIM*/ //GOTO
                return;
            }


            /*" -586- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", WABEND.WNR_EXEC_SQL);

            /*" -597- PERFORM M_1210_ALTERA_AGENCIA_DB_INSERT_1 */

            M_1210_ALTERA_AGENCIA_DB_INSERT_1();

            /*" -600- MOVE 1 TO WS-FLAG-ALT. */
            _.Move(1, WS_FLAG_ALT);

            /*" -601- MOVE CADCEF-AGENCIA TO SQL-AGENCIA. */
            _.Move(CADCEF_RECORD.CADCEF_AGENCIA, SQL_AGENCIA);

            /*" -602- MOVE CADCEF-OPERACAO TO SQL-OPERACAO. */
            _.Move(CADCEF_RECORD.CADCEF_OPERACAO, SQL_OPERACAO);

            /*" -603- MOVE CADCEF-CONTA TO SQL-CONTA. */
            _.Move(CADCEF_RECORD.CADCEF_CONTA, SQL_CONTA);

            /*" -603- MOVE CADCEF-DV-CONTA TO SQL-DV-CONTA. */
            _.Move(CADCEF_RECORD.CADCEF_DV_CONTA, SQL_DV_CONTA);

        }

        [StopWatch]
        /*" M-1210-ALTERA-AGENCIA-DB-SELECT-1 */
        public void M_1210_ALTERA_AGENCIA_DB_SELECT_1()
        {
            /*" -576- EXEC SQL SELECT COD_SUREG INTO :SQL-SUREG FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :SQL-NOVA-AGENCIA END-EXEC. */

            var m_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1 = new M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1()
            {
                SQL_NOVA_AGENCIA = SQL_NOVA_AGENCIA.ToString(),
            };

            var executed_1 = M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1.Execute(m_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_SUREG, SQL_SUREG);
            }


        }

        [StopWatch]
        /*" M-1210-ALTERA-AGENCIA-DB-INSERT-1 */
        public void M_1210_ALTERA_AGENCIA_DB_INSERT_1()
        {
            /*" -597- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVEND VALUES (:SQL-AGENCIA, :SQL-OPERACAO, :SQL-CONTA, :SQL-DV-CONTA, :SQL-MATRICULA, :SQL-CPF, CURRENT DATE, CURRENT TIME, 'VP0020B' ) END-EXEC. */

            var m_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1 = new M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1()
            {
                SQL_AGENCIA = SQL_AGENCIA.ToString(),
                SQL_OPERACAO = SQL_OPERACAO.ToString(),
                SQL_CONTA = SQL_CONTA.ToString(),
                SQL_DV_CONTA = SQL_DV_CONTA.ToString(),
                SQL_MATRICULA = SQL_MATRICULA.ToString(),
                SQL_CPF = SQL_CPF.ToString(),
            };

            M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1.Execute(m_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1210_FIM*/

        [StopWatch]
        /*" M-1220-UPDATE-FUNC */
        private void M_1220_UPDATE_FUNC(bool isPerform = false)
        {
            /*" -613- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", WABEND.WNR_EXEC_SQL);

            /*" -633- PERFORM M_1220_UPDATE_FUNC_DB_UPDATE_1 */

            M_1220_UPDATE_FUNC_DB_UPDATE_1();

        }

        [StopWatch]
        /*" M-1220-UPDATE-FUNC-DB-UPDATE-1 */
        public void M_1220_UPDATE_FUNC_DB_UPDATE_1()
        {
            /*" -633- EXEC SQL UPDATE SEGUROS.V0FUNCIOCEF SET COD_SUREG = :SQL-SUREG, COD_UNIDADE = :SQL-UNIDADE, DIG_UNIDADE = :SQL-DV, NOME_UNIDADE = :SQLCEF-NOME-UNID, TIPO_VINCULO = 'EMPREGADO CEF' , NOME_FUNCIONARIO = :SQL-NOME-FUNC, NASCIMENTO = :SQL-DATA-NASC, NUM_CPF = :SQL-CPF, ENDERECO_CEF = :SQL-ENDERECO, CIDADE_CEF = :SQL-CIDADE, SIGLA_UF = :SQL-UF, CEP = :SQL-CEP, COD_AGENCIA = :SQL-AGENCIA, OPERACAO_CONTA = :SQL-OPERACAO, NUM_CONTA = :SQL-CONTA, DIG_CONTA = :SQL-DV-CONTA WHERE NUM_MATRICULA = :SQL-MATRICULA END-EXEC. */

            var m_1220_UPDATE_FUNC_DB_UPDATE_1_Update1 = new M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1()
            {
                SQLCEF_NOME_UNID = SQLCEF_NOME_UNID.ToString(),
                SQL_NOME_FUNC = SQL_NOME_FUNC.ToString(),
                SQL_DATA_NASC = SQL_DATA_NASC.ToString(),
                SQL_ENDERECO = SQL_ENDERECO.ToString(),
                SQL_OPERACAO = SQL_OPERACAO.ToString(),
                SQL_DV_CONTA = SQL_DV_CONTA.ToString(),
                SQL_UNIDADE = SQL_UNIDADE.ToString(),
                SQL_AGENCIA = SQL_AGENCIA.ToString(),
                SQL_CIDADE = SQL_CIDADE.ToString(),
                SQL_SUREG = SQL_SUREG.ToString(),
                SQL_CONTA = SQL_CONTA.ToString(),
                SQL_CPF = SQL_CPF.ToString(),
                SQL_CEP = SQL_CEP.ToString(),
                SQL_DV = SQL_DV.ToString(),
                SQL_UF = SQL_UF.ToString(),
                SQL_MATRICULA = SQL_MATRICULA.ToString(),
            };

            M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1.Execute(m_1220_UPDATE_FUNC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1220_FIM*/

        [StopWatch]
        /*" M-1230-UPDATE-FUNC */
        private void M_1230_UPDATE_FUNC(bool isPerform = false)
        {
            /*" -643- MOVE '1230' TO WNR-EXEC-SQL. */
            _.Move("1230", WABEND.WNR_EXEC_SQL);

            /*" -648- PERFORM M_1230_UPDATE_FUNC_DB_UPDATE_1 */

            M_1230_UPDATE_FUNC_DB_UPDATE_1();

        }

        [StopWatch]
        /*" M-1230-UPDATE-FUNC-DB-UPDATE-1 */
        public void M_1230_UPDATE_FUNC_DB_UPDATE_1()
        {
            /*" -648- EXEC SQL UPDATE SEGUROS.V0FUNCIOCEF SET TIPO_VINCULO = 'INATIVO' WHERE TIPO_VINCULO = 'EMPREGADO CEF' END-EXEC. */

            var m_1230_UPDATE_FUNC_DB_UPDATE_1_Update1 = new M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1()
            {
            };

            M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1.Execute(m_1230_UPDATE_FUNC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1230_FIM*/

        [StopWatch]
        /*" M-9999-ROT-ERRO */
        private void M_9999_ROT_ERRO(bool isPerform = false)
        {
            /*" -658- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -659- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -659- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -661- DISPLAY 'CADCEF RECORD ==>' */
            _.Display($"CADCEF RECORD ==>");

            /*" -662- DISPLAY CADCEF-RECORD. */
            _.Display(CADCEF_RECORD);

            /*" -663- CLOSE CADCEF */
            CADCEF.Close();

            /*" -664- MOVE 999 TO RETURN-CODE. */
            _.Move(999, RETURN_CODE);

            /*" -664- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}