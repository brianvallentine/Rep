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
using Sias.VidaAzul.DB2.VA1300B;

namespace Code
{
    public class VA1300B
    {
        public bool IsCall { get; set; }

        public VA1300B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  GERA FITA COM LANCAMENTOS DE CREDITO DE DEVOLUCAO DE VIDA     *      */
        /*"      *  PARA CR�DITO EM CONTA CORRENTE DE BANCOS DIFERENTE DE CAIXA   *      */
        /*"      *  FOI CRIADO O CONVENIO 1313 PARA IDENTIFICAR ESTE MOVIMENTO.   *      */
        /*"      *  ESTE CONVENIO VAI SERVIR APENAS PARA OS PROGRAMAS DO CLOVIS   *      */
        /*"      *  DIFERENCIAR O CONVENIO 921286 E O 6090 QUE � GERADO PELO SICOV*      */
        /*"      *  LE O ARQUIVO OUTORSBC GERADO PELO VA0341B                     *      */
        /*"      *                                                                *      */
        /*"      *  DESENVOLVEDORES: CLOVIS, HEIDER, MICHELE                      *      */
        /*"      *  DATA: NOVEMBRO 2012                                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - JAZZ 210766 - DUPLICIDADE DE REGISTRO NO ARQUIVO *      */
        /*"      *                              DE ENTRADA                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/07/2019 - CANETTA                 PROCURE POR V.08     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 148793 - EVOLUCAO NO PROCESSO DE RESTITUICAO *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2017 - MARCUS VALERIO                               *      */
        /*"      *                                           PROCURE POR V.07     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - DUPLICIDADE DE REGISTRO NO ARQUIVO CAUSANDO      *      */
        /*"      *               ABEND NO PARAGRAFO R300-SELECT-HISTLAN           *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/04/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CORRECAO DO ABEND -811 NO PARAGRAFO              *      */
        /*"      *               R300-SELECT-HISLANCT                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 3                                                    *      */
        /*"      * MOTIVO  : ERRO PEGAR ENDERECO NA OD_PESSOA_ENDERECO            *      */
        /*"      * CADMUS  : 107205 - ABEND NA ROTINA JPVAD01 DIA 16/12/2014      *      */
        /*"      * DATA    : 16/12/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.3                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 2                                                    *      */
        /*"      * MOTIVO  : ERRO PEGAR ENDERECO NA OD_PESSOA_ENDERECO            *      */
        /*"      * CADMUS  : 106326 - ABEND NA ROTINA JPVAD01 DIA 22/11/2014      *      */
        /*"      * DATA    : 24/11/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.2                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.01                                               *      */
        /*"      *  CADMUS...: 94416           PROGRAMADOR: FRANK CARVALHO        *      */
        /*"      *  DATA ....: 25/02/2014                                         *      */
        /*"      *  DESCRICAO: CORRIGIR ENVIO DO DIGITO DA CONTA ALFANUMERICO     *      */
        /*"      *             PARA ATENDER DEVOLUCAO NO BANCO DO BRASIL COM O    *      */
        /*"      *             CONVENIO 001313.                                   *      */
        /*"      *             PROCURE V.01                                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _OUTROSBC { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis OUTROSBC
        {
            get
            {
                _.Move(MOVIMENTO_OUTROSBC, _OUTROSBC); VarBasis.RedefinePassValue(MOVIMENTO_OUTROSBC, _OUTROSBC, MOVIMENTO_OUTROSBC); return _OUTROSBC;
            }
        }
        public FileBasis _SAIDA { get; set; } = new FileBasis(new PIC("X", "240", "X(240)"));

        public FileBasis SAIDA
        {
            get
            {
                _.Move(REG_MOV1313, _SAIDA); VarBasis.RedefinePassValue(REG_MOV1313, _SAIDA, REG_MOV1313); return _SAIDA;
            }
        }
        public FileBasis _RELAT { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis RELAT
        {
            get
            {
                _.Move(REG_RELAT, _RELAT); VarBasis.RedefinePassValue(REG_RELAT, _RELAT, REG_RELAT); return _RELAT;
            }
        }
        public SortBasis<VA1300B_REG_SORTWK01> SORTWK01 { get; set; } = new SortBasis<VA1300B_REG_SORTWK01>(new VA1300B_REG_SORTWK01());
        /*"01  REG-SORTWK01.*/
        public VA1300B_REG_SORTWK01 REG_SORTWK01 { get; set; } = new VA1300B_REG_SORTWK01();
        public class VA1300B_REG_SORTWK01 : VarBasis
        {
            /*"    05 REG-SORT-NUM-SEQUENCIA        PIC 9(09).*/
            public IntBasis REG_SORT_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 REG-SORT-COD-BANCO            PIC 9(03).*/
            public IntBasis REG_SORT_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 REG-SORT-NUM-OCORR-MOVTO      PIC 9(09).*/
            public IntBasis REG_SORT_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 REG-SORT-NUM-CERTIFICADO      PIC 9(15).*/
            public IntBasis REG_SORT_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    05 REG-SORT-NUM-PARCELA          PIC 9(05).*/
            public IntBasis REG_SORT_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 REG-SORT-NUM-TITULO           PIC 9(13).*/
            public IntBasis REG_SORT_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 REG-SORT-NUM-PESSOA           PIC 9(09).*/
            public IntBasis REG_SORT_NUM_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 REG-SORT-DATA-VENCIMENTO      PIC X(10).*/
            public StringBasis REG_SORT_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 REG-SORT-NSA                  PIC 9(06).*/
            public IntBasis REG_SORT_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"01  MOVIMENTO-OUTROSBC  PIC X(100).*/
        }
        public StringBasis MOVIMENTO_OUTROSBC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01  REG-MOV1313         PIC X(240).*/
        public StringBasis REG_MOV1313 { get; set; } = new StringBasis(new PIC("X", "240", "X(240)."), @"");
        /*"01  REG-RELAT           PIC X(500).*/
        public StringBasis REG_RELAT { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  HOST-CURRENT-DATE                PIC X(10).*/
        public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WFIM-ENTRADA                     PIC X(03)  VALUE 'NAO'.*/
        public StringBasis WFIM_ENTRADA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"01  W-CHAVE-LOTE-BANCO-BRASIL        PIC X(03)  VALUE 'NAO'.*/
        public StringBasis W_CHAVE_LOTE_BANCO_BRASIL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"01  W-BANCO-ANTERIOR                 PIC 9(05)  VALUE 0.*/
        public IntBasis W_BANCO_ANTERIOR { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
        /*"01  SIST-DTCREDITO                   PIC X(10).*/
        public StringBasis SIST_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PARM-CODCONV                     PIC S9(9)  VALUE 0.*/
        public IntBasis PARM_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PARM-NSA                         PIC S9(4)     COMP.*/
        public IntBasis PARM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARM-VERSAO                      PIC S9(4)     COMP.*/
        public IntBasis PARM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SITUACAO                         PIC X(1).*/
        public StringBasis SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  NSAS                             PIC S9(4)     COMP.*/
        public IntBasis NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NSL                              PIC S9(9)     COMP.*/
        public IntBasis NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-NSL                       PIC S9(9)     COMP.*/
        public IntBasis FITSAS_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-REG                       PIC S9(9)     COMP.*/
        public IntBasis FITSAS_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  FITSAS-VALOR                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FITSAS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SQL-NOT-NULL                     PIC S9(4) COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), +1);
        /*"01  SQL-MAYBE-NULL                   PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-MAYBE-NULL1                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SQL-MAYBE-NULL2                  PIC S9(4)     COMP.*/
        public IntBasis SQL_MAYBE_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-SQLCODE                       PIC ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01  WORK-AREA.*/
        public VA1300B_WORK_AREA WORK_AREA { get; set; } = new VA1300B_WORK_AREA();
        public class VA1300B_WORK_AREA : VarBasis
        {
            /*"  05 W-EDICAO                      PIC  ZZZ.ZZ9.*/
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
            /*"  05 W-LIDOS-ARQUIVO               PIC  9(06).*/
            public IntBasis W_LIDOS_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"  05 WS-CONT-REG-DUPLIC            PIC  9(06).*/
            public IntBasis WS_CONT_REG_DUPLIC { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"  05 W-LIDOS-SORT                  PIC  9(06).*/
            public IntBasis W_LIDOS_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"  05 W-DATA-AAAA-MM-DD.*/
            public VA1300B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new VA1300B_W_DATA_AAAA_MM_DD();
            public class VA1300B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"      10 W-DATA-AAAA-MM-DD-AAAA     PIC  9(004).*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DATA-AAAA-MM-DD-MM       PIC  9(002).*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 W-DATA-AAAA-MM-DD-DD       PIC  9(002).*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 W-DATA-DD-MM-AAAA.*/
            }
            public VA1300B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new VA1300B_W_DATA_DD_MM_AAAA();
            public class VA1300B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"      10 W-DATA-DD-MM-AAAA-DD       PIC  9(002).*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 FILLER                     PIC  X(001)  VALUE  '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10 W-DATA-DD-MM-AAAA-MM       PIC  9(002).*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 FILLER                     PIC  X(001)  VALUE  '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10 W-DATA-DD-MM-AAAA-AAAA     PIC  9(004).*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WS-CPF             PIC  9(014)  VALUE   ZEROS.*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER             REDEFINES    WS-CPF.*/
            private _REDEF_VA1300B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA1300B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA1300B_FILLER_4(); _.Move(WS_CPF, _filler_4); VarBasis.RedefinePassValue(WS_CPF, _filler_4, WS_CPF); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_CPF); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WS_CPF); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_4 : VarBasis
            {
                /*"      10       WS-NUM-CPF         PIC  9(012).*/
                public IntBasis WS_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      10       WS-DIG-CPF         PIC  9(002).*/
                public IntBasis WS_DIG_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WS-CNPJ            PIC  9(014)  VALUE   ZEROS.*/

                public _REDEF_VA1300B_FILLER_4()
                {
                    WS_NUM_CPF.ValueChanged += OnValueChanged;
                    WS_DIG_CPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER             REDEFINES    WS-CNPJ.*/
            private _REDEF_VA1300B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA1300B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA1300B_FILLER_5(); _.Move(WS_CNPJ, _filler_5); VarBasis.RedefinePassValue(WS_CNPJ, _filler_5, WS_CNPJ); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_CNPJ); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_CNPJ); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_5 : VarBasis
            {
                /*"      10       WS-NUM-CNPJ        PIC  9(008).*/
                public IntBasis WS_NUM_CNPJ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10       WS-NUM-FILIAL      PIC  9(004).*/
                public IntBasis WS_NUM_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10       WS-DIG-CNPJ        PIC  9(002).*/
                public IntBasis WS_DIG_CNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  WVALOR-AUX                PIC S9(004) COMP-3  VALUE  ZEROS*/

                public _REDEF_VA1300B_FILLER_5()
                {
                    WS_NUM_CNPJ.ValueChanged += OnValueChanged;
                    WS_NUM_FILIAL.ValueChanged += OnValueChanged;
                    WS_DIG_CNPJ.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WVALOR_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WQUOCIENTE                PIC S9(004) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  WRESTO                    PIC S9(004) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_VA1300B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VA1300B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VA1300B_FILLER_6(); _.Move(WDATA_REL, _filler_6); VarBasis.RedefinePassValue(WDATA_REL, _filler_6, WDATA_REL); _filler_6.ValueChanged += () => { _.Move(_filler_6, WDATA_REL); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_6 : VarBasis
            {
                /*"      10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WHORA-CURR.*/

                public _REDEF_VA1300B_FILLER_6()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA1300B_WHORA_CURR WHORA_CURR { get; set; } = new VA1300B_WHORA_CURR();
            public class VA1300B_WHORA_CURR : VarBasis
            {
                /*"      10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05 WS-DIGCTA                 PIC  X(003)    VALUE SPACES.*/
            }
            public StringBasis WS_DIGCTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 FILLER            REDEFINES      WS-DIGCTA.*/
            private _REDEF_VA1300B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VA1300B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VA1300B_FILLER_9(); _.Move(WS_DIGCTA, _filler_9); VarBasis.RedefinePassValue(WS_DIGCTA, _filler_9, WS_DIGCTA); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_DIGCTA); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_DIGCTA); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_9 : VarBasis
            {
                /*"      10 WS-DIGCTA1             PIC  X(001).*/
                public StringBasis WS_DIGCTA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 WS-DIGCTA2             PIC  X(001).*/
                public StringBasis WS_DIGCTA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 WS-DIGCTA3             PIC  X(001).*/
                public StringBasis WS_DIGCTA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05 WS-NUMERO                       PIC  9(016)  VALUE   ZEROS.*/

                public _REDEF_VA1300B_FILLER_9()
                {
                    WS_DIGCTA1.ValueChanged += OnValueChanged;
                    WS_DIGCTA2.ValueChanged += OnValueChanged;
                    WS_DIGCTA3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUMERO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  05 FILLER            REDEFINES    WS-NUMERO.*/
            private _REDEF_VA1300B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_VA1300B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_VA1300B_FILLER_10(); _.Move(WS_NUMERO, _filler_10); VarBasis.RedefinePassValue(WS_NUMERO, _filler_10, WS_NUMERO); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_NUMERO); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WS_NUMERO); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_10 : VarBasis
            {
                /*"      10 WS-OPERACAO                  PIC  9(004).*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-NUMCONTA                  PIC  9(012).*/
                public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"  05 W-SORT-NUM-CERTIFICADO       PIC 9(15)        VALUE ZEROS.*/

                public _REDEF_VA1300B_FILLER_10()
                {
                    WS_OPERACAO.ValueChanged += OnValueChanged;
                    WS_NUMCONTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_SORT_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"  05 W-SORT-NUM-PARCELA           PIC 9(05)        VALUE ZEROS.*/
            public IntBasis W_SORT_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"  05 W-SORT-NUM-TITULO            PIC 9(13)        VALUE ZEROS.*/
            public IntBasis W_SORT_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  05 W-CONTA-DIAS-UTEIS           PIC 9(02)        VALUE ZEROS.*/
            public IntBasis W_CONTA_DIAS_UTEIS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"  05 W-CONTA-PRX-DIA-UTIL-CREDITO PIC 9(02)        VALUE ZEROS.*/
            public IntBasis W_CONTA_PRX_DIA_UTIL_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"  05 W-CONTA-PRX-DIA-UTIL-DEBITO  PIC 9(02)        VALUE ZEROS.*/
            public IntBasis W_CONTA_PRX_DIA_UTIL_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"  05 W-DATA-PRX-DIA-UTIL-CREDITO  PIC X(10)       VALUE SPACES.*/
            public StringBasis W_DATA_PRX_DIA_UTIL_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-PRX-DIA-UTIL-DEBITO   PIC X(10)       VALUE SPACES.*/
            public StringBasis W_DATA_PRX_DIA_UTIL_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 AC-REGISTROS                  PIC  9(009) VALUE 1.*/
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 1);
            /*"  05 AC-VALOR                      PIC S9(013)V99 VALUE +0.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05 WS-AGENCIA-ANT                PIC S9(004) COMP.*/
            public IntBasis WS_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05 WS-NSL                        PIC  9(008) VALUE 0.*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05 WS-EOF                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05 WS-DISPLAY-QUANT              PIC  ZZZ.ZZZ.ZZ9.*/
            public IntBasis WS_DISPLAY_QUANT { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"  05 WS-DISPLAY-VALOR              PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WS_DISPLAY_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05 WS-DISPLAY-NSA                PIC  9(05).*/
            public IntBasis WS_DISPLAY_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 WS-PRM-TOT                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 WS-PRM-DIF                    PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W04DTSQL.*/
            public VA1300B_W04DTSQL W04DTSQL { get; set; } = new VA1300B_W04DTSQL();
            public class VA1300B_W04DTSQL : VarBasis
            {
                /*"      10  W04AASQL                  PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10  W04T1SQL                  PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 PARM-PROSOMU1.*/
            }
            public VA1300B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA1300B_PARM_PROSOMU1();
            public class VA1300B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10 SU1-DATA1.*/
                public VA1300B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA1300B_SU1_DATA1();
                public class VA1300B_SU1_DATA1 : VarBasis
                {
                    /*"         15 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"         15 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"         15 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      10 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      10 SU1-DATA2.*/
                public VA1300B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA1300B_SU1_DATA2();
                public class VA1300B_SU1_DATA2 : VarBasis
                {
                    /*"         15 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"         15 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"         15 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"  05      WABEND.*/
                }
            }
            public VA1300B_WABEND WABEND { get; set; } = new VA1300B_WABEND();
            public class VA1300B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA1300B  '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1300B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10 FILLER              PIC  X(005) VALUE ' '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ");
                /*"      10 FILLER              PIC  X(035) VALUE         ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"      10 WNR-EXEC-SQL        PIC  X(010) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"000");
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"  05      LOCALIZA-ABEND-1.*/
            }
            public VA1300B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1300B_LOCALIZA_ABEND_1();
            public class VA1300B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05      LOCALIZA-ABEND-2.*/
            }
            public VA1300B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1300B_LOCALIZA_ABEND_2();
            public class VA1300B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  MOV-OUTROS-BANCOS.*/
            }
        }
        public VA1300B_MOV_OUTROS_BANCOS MOV_OUTROS_BANCOS { get; set; } = new VA1300B_MOV_OUTROS_BANCOS();
        public class VA1300B_MOV_OUTROS_BANCOS : VarBasis
        {
            /*"  05 MOV-OUTROBC-NUM-SEQUENCIA     PIC 9(01).*/
            public IntBasis MOV_OUTROBC_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-COD-BANCO         PIC 9(03).*/
            public IntBasis MOV_OUTROBC_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-NUM-OCORR-MOVTO   PIC 9(09).*/
            public IntBasis MOV_OUTROBC_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-NUM-CERTIFICADO   PIC 9(15).*/
            public IntBasis MOV_OUTROBC_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-NUM-PARCELA       PIC 9(05).*/
            public IntBasis MOV_OUTROBC_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-NUM-TITULO        PIC 9(13).*/
            public IntBasis MOV_OUTROBC_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-NUM-PESSOA        PIC 9(09).*/
            public IntBasis MOV_OUTROBC_NUM_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-DATA-VENCIMENTO   PIC X(10).*/
            public StringBasis MOV_OUTROBC_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05 FILLER                        PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"  05 MOV-OUTROBC-NSA               PIC 9(06).*/
            public IntBasis MOV_OUTROBC_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"01          ARQHEA-REGISTRO.*/
        }
        public VA1300B_ARQHEA_REGISTRO ARQHEA_REGISTRO { get; set; } = new VA1300B_ARQHEA_REGISTRO();
        public class VA1300B_ARQHEA_REGISTRO : VarBasis
        {
            /*"  05        ARQHEA-CONTROLE.*/
            public VA1300B_ARQHEA_CONTROLE ARQHEA_CONTROLE { get; set; } = new VA1300B_ARQHEA_CONTROLE();
            public class VA1300B_ARQHEA_CONTROLE : VarBasis
            {
                /*"      10      ARQHEA-BANCO           PIC  9(003).*/
                public IntBasis ARQHEA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      ARQHEA-LOTSER          PIC  9(004).*/
                public IntBasis ARQHEA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      ARQHEA-TIPOREG         PIC  9(001).*/
                public IntBasis ARQHEA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        ARQHEA-EMPRESA.*/
            public VA1300B_ARQHEA_EMPRESA ARQHEA_EMPRESA { get; set; } = new VA1300B_ARQHEA_EMPRESA();
            public class VA1300B_ARQHEA_EMPRESA : VarBasis
            {
                /*"      10      ARQHEA-INSCRICAO.*/
                public VA1300B_ARQHEA_INSCRICAO ARQHEA_INSCRICAO { get; set; } = new VA1300B_ARQHEA_INSCRICAO();
                public class VA1300B_ARQHEA_INSCRICAO : VarBasis
                {
                    /*"        15    ARQHEA-TIPINSC         PIC  9(001).*/
                    public IntBasis ARQHEA_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    ARQHEA-NROINSC         PIC  9(014).*/
                    public IntBasis ARQHEA_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"      10      ARQHEA-CONVENIO        PIC  X(020).*/
                }
                public StringBasis ARQHEA_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      ARQHEA-CONTA.*/
                public VA1300B_ARQHEA_CONTA ARQHEA_CONTA { get; set; } = new VA1300B_ARQHEA_CONTA();
                public class VA1300B_ARQHEA_CONTA : VarBasis
                {
                    /*"        15    ARQHEA-AGECONTA        PIC  9(005).*/
                    public IntBasis ARQHEA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    ARQHEA-DIGAGENC        PIC  X(001).*/
                    public StringBasis ARQHEA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"        15    ARQHEA-NUMCONTA        PIC  9(016).*/
                    public IntBasis ARQHEA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"        15    ARQHEA-DIGCONTA        PIC  X(001).*/
                    public StringBasis ARQHEA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"        15    ARQHEA-DIGAGECTA       PIC  X(001).*/
                    public StringBasis ARQHEA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10      ARQHEA-NOMEMPRESA      PIC  X(030).*/
                }
                public StringBasis ARQHEA_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        ARQHEA-NOMEBANCO       PIC  X(030).*/
            }
            public StringBasis ARQHEA_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05        FILLER                 PIC  X(006).*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05        ARQHEA-ARQUIVO.*/
            public VA1300B_ARQHEA_ARQUIVO ARQHEA_ARQUIVO { get; set; } = new VA1300B_ARQHEA_ARQUIVO();
            public class VA1300B_ARQHEA_ARQUIVO : VarBasis
            {
                /*"      10      ARQHEA-REMESSA         PIC  9(001).*/
                public IntBasis ARQHEA_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      ARQHEA-DATAGERACAO.*/
                public VA1300B_ARQHEA_DATAGERACAO ARQHEA_DATAGERACAO { get; set; } = new VA1300B_ARQHEA_DATAGERACAO();
                public class VA1300B_ARQHEA_DATAGERACAO : VarBasis
                {
                    /*"        15    ARQHEA-DIAGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_DIAGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    ARQHEA-MESGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_MESGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    ARQHEA-ANOGERA         PIC  9(004).*/
                    public IntBasis ARQHEA_ANOGERA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      ARQHEA-HORAGERACAO.*/
                }
                public VA1300B_ARQHEA_HORAGERACAO ARQHEA_HORAGERACAO { get; set; } = new VA1300B_ARQHEA_HORAGERACAO();
                public class VA1300B_ARQHEA_HORAGERACAO : VarBasis
                {
                    /*"        15    ARQHEA-HORGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_HORGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    ARQHEA-MINGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_MINGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    ARQHEA-SEGGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_SEGGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10      ARQHEA-NSA             PIC  9(006).*/
                }
                public IntBasis ARQHEA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      ARQHEA-VERSAO          PIC  9(003).*/
                public IntBasis ARQHEA_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      ARQHEA-DENSIDADE       PIC  9(005).*/
                public IntBasis ARQHEA_DENSIDADE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05        ARQHEA-USOBANCO        PIC  X(020).*/
            }
            public StringBasis ARQHEA_USOBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        ARQHEA-USOEMPRESA      PIC  X(020).*/
            public StringBasis ARQHEA_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        FILLER                 PIC  X(029).*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)."), @"");
            /*"01          ARQTRA-REGISTRO.*/
        }
        public VA1300B_ARQTRA_REGISTRO ARQTRA_REGISTRO { get; set; } = new VA1300B_ARQTRA_REGISTRO();
        public class VA1300B_ARQTRA_REGISTRO : VarBasis
        {
            /*"  05        ARQTRA-CONTROLE.*/
            public VA1300B_ARQTRA_CONTROLE ARQTRA_CONTROLE { get; set; } = new VA1300B_ARQTRA_CONTROLE();
            public class VA1300B_ARQTRA_CONTROLE : VarBasis
            {
                /*"    10      ARQTRA-BANCO           PIC  9(003).*/
                public IntBasis ARQTRA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      ARQTRA-LOTSER          PIC  9(004).*/
                public IntBasis ARQTRA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      ARQTRA-TIPOREG         PIC  9(001).*/
                public IntBasis ARQTRA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        ARQTRA-TOTAIS.*/
            public VA1300B_ARQTRA_TOTAIS ARQTRA_TOTAIS { get; set; } = new VA1300B_ARQTRA_TOTAIS();
            public class VA1300B_ARQTRA_TOTAIS : VarBasis
            {
                /*"    10      ARQTRA-QTDELOTE        PIC  9(006).*/
                public IntBasis ARQTRA_QTDELOTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQTRA-QTDEREG         PIC  9(006).*/
                public IntBasis ARQTRA_QTDEREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQTRA-QTDECONTA       PIC  9(006).*/
                public IntBasis ARQTRA_QTDECONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05        FILLER                 PIC  X(205).*/
            }
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "205", "X(205)."), @"");
            /*"01          LOTHEA-REGISTRO.*/
        }
        public VA1300B_LOTHEA_REGISTRO LOTHEA_REGISTRO { get; set; } = new VA1300B_LOTHEA_REGISTRO();
        public class VA1300B_LOTHEA_REGISTRO : VarBasis
        {
            /*"  05        LOTHEA-CONTROLE.*/
            public VA1300B_LOTHEA_CONTROLE LOTHEA_CONTROLE { get; set; } = new VA1300B_LOTHEA_CONTROLE();
            public class VA1300B_LOTHEA_CONTROLE : VarBasis
            {
                /*"    10      LOTHEA-BANCO           PIC  9(003).*/
                public IntBasis LOTHEA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      LOTHEA-LOTSER          PIC  9(004).*/
                public IntBasis LOTHEA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTHEA-TIPOREG         PIC  9(001).*/
                public IntBasis LOTHEA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        LOTHEA-SERVICO.*/
            }
            public VA1300B_LOTHEA_SERVICO LOTHEA_SERVICO { get; set; } = new VA1300B_LOTHEA_SERVICO();
            public class VA1300B_LOTHEA_SERVICO : VarBasis
            {
                /*"    10      LOTHEA-OPERACAO        PIC  X(001).*/
                public StringBasis LOTHEA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      LOTHEA-TIPSER          PIC  9(002).*/
                public IntBasis LOTHEA_TIPSER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      LOTHEA-FORMA           PIC  9(002).*/
                public IntBasis LOTHEA_FORMA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      LOTHEA-VERSAO          PIC  9(003).*/
                public IntBasis LOTHEA_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05        FILLER                 PIC  X(001).*/
            }
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05        LOTHEA-EMPRESA.*/
            public VA1300B_LOTHEA_EMPRESA LOTHEA_EMPRESA { get; set; } = new VA1300B_LOTHEA_EMPRESA();
            public class VA1300B_LOTHEA_EMPRESA : VarBasis
            {
                /*"    10      LOTHEA-INSCRICAO.*/
                public VA1300B_LOTHEA_INSCRICAO LOTHEA_INSCRICAO { get; set; } = new VA1300B_LOTHEA_INSCRICAO();
                public class VA1300B_LOTHEA_INSCRICAO : VarBasis
                {
                    /*"      15    LOTHEA-TIPINSC         PIC  9(001).*/
                    public IntBasis LOTHEA_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LOTHEA-NROINSC         PIC  9(014).*/
                    public IntBasis LOTHEA_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    10      LOTHEA-CONVENIO        PIC  X(020).*/
                }
                public StringBasis LOTHEA_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10      LOTHEA-CONTA.*/
                public VA1300B_LOTHEA_CONTA LOTHEA_CONTA { get; set; } = new VA1300B_LOTHEA_CONTA();
                public class VA1300B_LOTHEA_CONTA : VarBasis
                {
                    /*"      15    LOTHEA-AGECONTA        PIC  9(005).*/
                    public IntBasis LOTHEA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    LOTHEA-DIGAGENC        PIC  X(001).*/
                    public StringBasis LOTHEA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LOTHEA-NUMCONTA        PIC  9(016).*/
                    public IntBasis LOTHEA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"      15    LOTHEA-DIGCONTA        PIC  X(001).*/
                    public StringBasis LOTHEA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LOTHEA-DIGAGECTA       PIC  X(001).*/
                    public StringBasis LOTHEA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      LOTHEA-NOMEMPRESA      PIC  X(030).*/
                }
                public StringBasis LOTHEA_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        LOTHEA-MENSAGEM        PIC  X(040).*/
            }
            public StringBasis LOTHEA_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        LOTHEA-ENDERECO.*/
            public VA1300B_LOTHEA_ENDERECO LOTHEA_ENDERECO { get; set; } = new VA1300B_LOTHEA_ENDERECO();
            public class VA1300B_LOTHEA_ENDERECO : VarBasis
            {
                /*"    10      LOTHEA-LOGRADOURO      PIC  X(030).*/
                public StringBasis LOTHEA_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10      LOTHEA-NUMERO          PIC  9(005).*/
                public IntBasis LOTHEA_NUMERO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      LOTHEA-COMPLOGRA       PIC  X(015).*/
                public StringBasis LOTHEA_COMPLOGRA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    10      LOTHEA-CIDADE          PIC  X(020).*/
                public StringBasis LOTHEA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10      LOTHEA-CEP             PIC  9(005).*/
                public IntBasis LOTHEA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      LOTHEA-COMPLCEP        PIC  X(003).*/
                public StringBasis LOTHEA_COMPLCEP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10      LOTHEA-SIGLAUF         PIC  X(002).*/
                public StringBasis LOTHEA_SIGLAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05        FILLER                 PIC  X(004).*/
            }
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05        LOTHEA-OCORRENCIA      PIC  X(010).*/
            public StringBasis LOTHEA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          LOTTRA-REGISTRO.*/
        }
        public VA1300B_LOTTRA_REGISTRO LOTTRA_REGISTRO { get; set; } = new VA1300B_LOTTRA_REGISTRO();
        public class VA1300B_LOTTRA_REGISTRO : VarBasis
        {
            /*"  05        LOTTRA-CONTROLE.*/
            public VA1300B_LOTTRA_CONTROLE LOTTRA_CONTROLE { get; set; } = new VA1300B_LOTTRA_CONTROLE();
            public class VA1300B_LOTTRA_CONTROLE : VarBasis
            {
                /*"    10      LOTTRA-BANCO           PIC  9(003).*/
                public IntBasis LOTTRA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      LOTTRA-LOTSER          PIC  9(004).*/
                public IntBasis LOTTRA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTTRA-TIPOREG         PIC  9(001).*/
                public IntBasis LOTTRA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        LOTTRA-TOTAIS.*/
            public VA1300B_LOTTRA_TOTAIS LOTTRA_TOTAIS { get; set; } = new VA1300B_LOTTRA_TOTAIS();
            public class VA1300B_LOTTRA_TOTAIS : VarBasis
            {
                /*"    10      LOTTRA-QTDEREG         PIC  9(006).*/
                public IntBasis LOTTRA_QTDEREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      LOTTRA-VALOR           PIC  9(016)V99.*/
                public DoubleBasis LOTTRA_VALOR { get; set; } = new DoubleBasis(new PIC("9", "16", "9(016)V99."), 2);
                /*"    10      LOTTRA-QTDEMOEDA       PIC  9(013)V99999.*/
                public DoubleBasis LOTTRA_QTDEMOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99999."), 5);
                /*"  05        LOTTRA-NRAVISO         PIC  9(006).*/
            }
            public IntBasis LOTTRA_NRAVISO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05        FILLER                 PIC  X(165).*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "165", "X(165)."), @"");
            /*"  05        LOTTRA-OCORRENCIA      PIC  X(010).*/
            public StringBasis LOTTRA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          DETSEGA-REGISTRO.*/
        }
        public VA1300B_DETSEGA_REGISTRO DETSEGA_REGISTRO { get; set; } = new VA1300B_DETSEGA_REGISTRO();
        public class VA1300B_DETSEGA_REGISTRO : VarBasis
        {
            /*"  05        DETSEGA-CONTROLE.*/
            public VA1300B_DETSEGA_CONTROLE DETSEGA_CONTROLE { get; set; } = new VA1300B_DETSEGA_CONTROLE();
            public class VA1300B_DETSEGA_CONTROLE : VarBasis
            {
                /*"    10      DETSEGA-BANCO          PIC  9(003).*/
                public IntBasis DETSEGA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGA-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGA-SERVICO.*/
            }
            public VA1300B_DETSEGA_SERVICO DETSEGA_SERVICO { get; set; } = new VA1300B_DETSEGA_SERVICO();
            public class VA1300B_DETSEGA_SERVICO : VarBasis
            {
                /*"    10      DETSEGA-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGA_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGA-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGA_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DETSEGA-MOVIMENTO.*/
                public VA1300B_DETSEGA_MOVIMENTO DETSEGA_MOVIMENTO { get; set; } = new VA1300B_DETSEGA_MOVIMENTO();
                public class VA1300B_DETSEGA_MOVIMENTO : VarBasis
                {
                    /*"      15    DETSEGA-TIPOMOV        PIC  9(001).*/
                    public IntBasis DETSEGA_TIPOMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    DETSEGA-INSTRUCAO      PIC  9(002).*/
                    public IntBasis DETSEGA_INSTRUCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05        DETSEGA-FAVORECIDO.*/
                }
            }
            public VA1300B_DETSEGA_FAVORECIDO DETSEGA_FAVORECIDO { get; set; } = new VA1300B_DETSEGA_FAVORECIDO();
            public class VA1300B_DETSEGA_FAVORECIDO : VarBasis
            {
                /*"    10      DETSEGA-CAMARA         PIC  9(003).*/
                public IntBasis DETSEGA_CAMARA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-BANCOFAV       PIC  9(003).*/
                public IntBasis DETSEGA_BANCOFAV { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-CONTA.*/
                public VA1300B_DETSEGA_CONTA DETSEGA_CONTA { get; set; } = new VA1300B_DETSEGA_CONTA();
                public class VA1300B_DETSEGA_CONTA : VarBasis
                {
                    /*"      15    DETSEGA-AGECONTA       PIC  9(005).*/
                    public IntBasis DETSEGA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    DETSEGA-DIGAGENC       PIC  X(001).*/
                    public StringBasis DETSEGA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    DETSEGA-NUMCONTA       PIC  9(016).*/
                    public IntBasis DETSEGA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"      15    DETSEGA-DIGCONTA       PIC  X(001).*/
                    public StringBasis DETSEGA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    DETSEGA-DIGAGECTA      PIC  X(001).*/
                    public StringBasis DETSEGA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      DETSEGA-NOMEFAV        PIC  X(017).*/
                }
                public StringBasis DETSEGA_NOMEFAV { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"    10      DETSEGA-NUMPESSOA      PIC  9(009).*/
                public IntBasis DETSEGA_NUMPESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10      DETSEGA-SEQCTABANC     PIC  9(004).*/
                public IntBasis DETSEGA_SEQCTABANC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05        DETSEGA-CREDITO.*/
            }
            public VA1300B_DETSEGA_CREDITO DETSEGA_CREDITO { get; set; } = new VA1300B_DETSEGA_CREDITO();
            public class VA1300B_DETSEGA_CREDITO : VarBasis
            {
                /*"    10      DETSEGA-NROEMPRE.*/
                public VA1300B_DETSEGA_NROEMPRE DETSEGA_NROEMPRE { get; set; } = new VA1300B_DETSEGA_NROEMPRE();
                public class VA1300B_DETSEGA_NROEMPRE : VarBasis
                {
                    /*"      15    DETSEGA-NRSEQ01        PIC  9(009).*/
                    public IntBasis DETSEGA_NRSEQ01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"      15    DETSEGA-NRSEQ02        PIC  9(011).*/
                    public IntBasis DETSEGA_NRSEQ02 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                    /*"    10      DETSEGA-DATAPAGTO.*/
                }
                public VA1300B_DETSEGA_DATAPAGTO DETSEGA_DATAPAGTO { get; set; } = new VA1300B_DETSEGA_DATAPAGTO();
                public class VA1300B_DETSEGA_DATAPAGTO : VarBasis
                {
                    /*"      15    DETSEGA-DIAPAG         PIC  9(002).*/
                    public IntBasis DETSEGA_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-MESPAG         PIC  9(002).*/
                    public IntBasis DETSEGA_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-ANOPAG         PIC  9(004).*/
                    public IntBasis DETSEGA_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      DETSEGA-MOEDA.*/
                }
                public VA1300B_DETSEGA_MOEDA DETSEGA_MOEDA { get; set; } = new VA1300B_DETSEGA_MOEDA();
                public class VA1300B_DETSEGA_MOEDA : VarBasis
                {
                    /*"      15    DETSEGA-TIPOMOEDA      PIC  X(003).*/
                    public StringBasis DETSEGA_TIPOMOEDA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"      15    DETSEGA-QTDEMOEDA      PIC  9(010)V99999.*/
                    public DoubleBasis DETSEGA_QTDEMOEDA { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99999."), 5);
                    /*"    10      DETSEGA-VALPAGTO       PIC  9(013)V99.*/
                }
                public DoubleBasis DETSEGA_VALPAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10      DETSEGA-NROBANCO       PIC  X(020).*/
                public StringBasis DETSEGA_NROBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10      DETSEGA-DATAREAL.*/
                public VA1300B_DETSEGA_DATAREAL DETSEGA_DATAREAL { get; set; } = new VA1300B_DETSEGA_DATAREAL();
                public class VA1300B_DETSEGA_DATAREAL : VarBasis
                {
                    /*"      15    DETSEGA-DIAREA         PIC  9(002).*/
                    public IntBasis DETSEGA_DIAREA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-MESREA         PIC  9(002).*/
                    public IntBasis DETSEGA_MESREA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-ANOREA         PIC  9(004).*/
                    public IntBasis DETSEGA_ANOREA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      DETSEGA-VALREAL        PIC  9(013)V99.*/
                }
                public DoubleBasis DETSEGA_VALREAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"  05  DETSEGA-INFORMA-VAI-VOLTA    PIC  X(040).*/
            }
            public StringBasis DETSEGA_INFORMA_VAI_VOLTA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05  DETSEGA-IDENTIFICA-VIDA1  REDEFINES                                   DETSEGA-INFORMA-VAI-VOLTA.*/
            private _REDEF_VA1300B_DETSEGA_IDENTIFICA_VIDA1 _detsega_identifica_vida1 { get; set; }
            public _REDEF_VA1300B_DETSEGA_IDENTIFICA_VIDA1 DETSEGA_IDENTIFICA_VIDA1
            {
                get { _detsega_identifica_vida1 = new _REDEF_VA1300B_DETSEGA_IDENTIFICA_VIDA1(); _.Move(DETSEGA_INFORMA_VAI_VOLTA, _detsega_identifica_vida1); VarBasis.RedefinePassValue(DETSEGA_INFORMA_VAI_VOLTA, _detsega_identifica_vida1, DETSEGA_INFORMA_VAI_VOLTA); _detsega_identifica_vida1.ValueChanged += () => { _.Move(_detsega_identifica_vida1, DETSEGA_INFORMA_VAI_VOLTA); }; return _detsega_identifica_vida1; }
                set { VarBasis.RedefinePassValue(value, _detsega_identifica_vida1, DETSEGA_INFORMA_VAI_VOLTA); }
            }  //Redefines
            public class _REDEF_VA1300B_DETSEGA_IDENTIFICA_VIDA1 : VarBasis
            {
                /*"      10  DETSEGA-NUM-CERTIFICADO-VIDA1   PIC 9(15).*/
                public IntBasis DETSEGA_NUM_CERTIFICADO_VIDA1 { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10  DETSEGA-NUM-PARCELA-VIDA1       PIC 9(04).*/
                public IntBasis DETSEGA_NUM_PARCELA_VIDA1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10  DETSEGA-NUM-OCORR-MOVTO-VIDA1   PIC 9(08).*/
                public IntBasis DETSEGA_NUM_OCORR_MOVTO_VIDA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10  DETSEGA-NUM-TITULO-VIDA1        PIC 9(13).*/
                public IntBasis DETSEGA_NUM_TITULO_VIDA1 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"  05        DETSEGA-CODFINAL       PIC  X(002).*/

                public _REDEF_VA1300B_DETSEGA_IDENTIFICA_VIDA1()
                {
                    DETSEGA_NUM_CERTIFICADO_VIDA1.ValueChanged += OnValueChanged;
                    DETSEGA_NUM_PARCELA_VIDA1.ValueChanged += OnValueChanged;
                    DETSEGA_NUM_OCORR_MOVTO_VIDA1.ValueChanged += OnValueChanged;
                    DETSEGA_NUM_TITULO_VIDA1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis DETSEGA_CODFINAL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        FILLER                 PIC  X(010).*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        DETSEGA-AVISO          PIC  9(001).*/
            public IntBasis DETSEGA_AVISO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05        DETSEGA-OCORRENCIA     PIC  X(010).*/
            public StringBasis DETSEGA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          DETSEGB-REGISTRO.*/
        }
        public VA1300B_DETSEGB_REGISTRO DETSEGB_REGISTRO { get; set; } = new VA1300B_DETSEGB_REGISTRO();
        public class VA1300B_DETSEGB_REGISTRO : VarBasis
        {
            /*"  05        DETSEGB-CONTROLE.*/
            public VA1300B_DETSEGB_CONTROLE DETSEGB_CONTROLE { get; set; } = new VA1300B_DETSEGB_CONTROLE();
            public class VA1300B_DETSEGB_CONTROLE : VarBasis
            {
                /*"    10      DETSEGB-BANCO          PIC  9(003).*/
                public IntBasis DETSEGB_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGB-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGB_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGB-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGB_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGB-SERVICO.*/
            }
            public VA1300B_DETSEGB_SERVICO DETSEGB_SERVICO { get; set; } = new VA1300B_DETSEGB_SERVICO();
            public class VA1300B_DETSEGB_SERVICO : VarBasis
            {
                /*"    10      DETSEGB-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGB_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGB-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGB_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05        FILLER                 PIC  X(003).*/
            }
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05        DETSEGB-COMPLEMENTO.*/
            public VA1300B_DETSEGB_COMPLEMENTO DETSEGB_COMPLEMENTO { get; set; } = new VA1300B_DETSEGB_COMPLEMENTO();
            public class VA1300B_DETSEGB_COMPLEMENTO : VarBasis
            {
                /*"    10      DETSEGB-FAVORECIDO.*/
                public VA1300B_DETSEGB_FAVORECIDO DETSEGB_FAVORECIDO { get; set; } = new VA1300B_DETSEGB_FAVORECIDO();
                public class VA1300B_DETSEGB_FAVORECIDO : VarBasis
                {
                    /*"      15    DETSEGB-INSCRICAO.*/
                    public VA1300B_DETSEGB_INSCRICAO DETSEGB_INSCRICAO { get; set; } = new VA1300B_DETSEGB_INSCRICAO();
                    public class VA1300B_DETSEGB_INSCRICAO : VarBasis
                    {
                        /*"        20  DETSEGB-TIPINSC        PIC  9(001).*/
                        public IntBasis DETSEGB_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                        /*"        20  DETSEGB-NROINSC        PIC  9(014).*/
                        public IntBasis DETSEGB_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                        /*"      15    DETSEGB-LOGRADOURO     PIC  X(030).*/
                    }
                    public StringBasis DETSEGB_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"      15    DETSEGB-NUMERO         PIC  9(005).*/
                    public IntBasis DETSEGB_NUMERO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    DETSEGB-COMPLOGRA      PIC  X(015).*/
                    public StringBasis DETSEGB_COMPLOGRA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"      15    DETSEGB-BAIRRO         PIC  X(015).*/
                    public StringBasis DETSEGB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"      15    DETSEGB-CIDADE         PIC  X(020).*/
                    public StringBasis DETSEGB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                    /*"      15    DETSEGB-CEP            PIC  X(008).*/
                    public StringBasis DETSEGB_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"      15    DETSEGB-SIGLAUF        PIC  X(002).*/
                    public StringBasis DETSEGB_SIGLAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10      DETSEGB-PAGTO.*/
                }
                public VA1300B_DETSEGB_PAGTO DETSEGB_PAGTO { get; set; } = new VA1300B_DETSEGB_PAGTO();
                public class VA1300B_DETSEGB_PAGTO : VarBasis
                {
                    /*"      15    DETSEGB-DATAVENCTO.*/
                    public VA1300B_DETSEGB_DATAVENCTO DETSEGB_DATAVENCTO { get; set; } = new VA1300B_DETSEGB_DATAVENCTO();
                    public class VA1300B_DETSEGB_DATAVENCTO : VarBasis
                    {
                        /*"        20  DETSEGB-DIAVEN         PIC  9(002).*/
                        public IntBasis DETSEGB_DIAVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        20  DETSEGB-MESVEN         PIC  9(002).*/
                        public IntBasis DETSEGB_MESVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        20  DETSEGB-ANOVEN         PIC  9(004).*/
                        public IntBasis DETSEGB_ANOVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"      15    DETSEGB-VALNOMIN       PIC  9(013)V99.*/
                    }
                    public DoubleBasis DETSEGB_VALNOMIN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALABAT        PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALABAT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALDESC        PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALDESC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALMORA        PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALMORA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALMULTA       PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"    10      DETSEGB-DOCFAV         PIC  X(015).*/
                }
                public StringBasis DETSEGB_DOCFAV { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05        FILLER                 PIC  X(015).*/
            }
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"01          DETSEGC-REGISTRO.*/
        }
        public VA1300B_DETSEGC_REGISTRO DETSEGC_REGISTRO { get; set; } = new VA1300B_DETSEGC_REGISTRO();
        public class VA1300B_DETSEGC_REGISTRO : VarBasis
        {
            /*"  05        DETSEGC-CONTROLE.*/
            public VA1300B_DETSEGC_CONTROLE DETSEGC_CONTROLE { get; set; } = new VA1300B_DETSEGC_CONTROLE();
            public class VA1300B_DETSEGC_CONTROLE : VarBasis
            {
                /*"    10      DETSEGC-BANCO          PIC  9(003).*/
                public IntBasis DETSEGC_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGC-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGC_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGC-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGC_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGC-SERVICO.*/
            }
            public VA1300B_DETSEGC_SERVICO DETSEGC_SERVICO { get; set; } = new VA1300B_DETSEGC_SERVICO();
            public class VA1300B_DETSEGC_SERVICO : VarBasis
            {
                /*"    10      DETSEGC-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGC_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGC-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGC_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05        FILLER                 PIC  X(003).*/
            }
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05        DETSEGC-COMPLEMENTO.*/
            public VA1300B_DETSEGC_COMPLEMENTO DETSEGC_COMPLEMENTO { get; set; } = new VA1300B_DETSEGC_COMPLEMENTO();
            public class VA1300B_DETSEGC_COMPLEMENTO : VarBasis
            {
                /*"    10      DETSEGC-PAGTO.*/
                public VA1300B_DETSEGC_PAGTO DETSEGC_PAGTO { get; set; } = new VA1300B_DETSEGC_PAGTO();
                public class VA1300B_DETSEGC_PAGTO : VarBasis
                {
                    /*"      15    DETSEGC-VALIRF         PIC  9(013)V99.*/
                    public DoubleBasis DETSEGC_VALIRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGC-VALISS         PIC  9(013)V99.*/
                    public DoubleBasis DETSEGC_VALISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGC-VALIOF         PIC  9(013)V99.*/
                    public DoubleBasis DETSEGC_VALIOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGC-VALDEDUC       PIC  9(013)V99.*/
                    public DoubleBasis DETSEGC_VALDEDUC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGC-VALACRES       PIC  9(013)V99.*/
                    public DoubleBasis DETSEGC_VALACRES { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"  05        DETSEGC-SUBSTITUTA.*/
                }
            }
            public VA1300B_DETSEGC_SUBSTITUTA DETSEGC_SUBSTITUTA { get; set; } = new VA1300B_DETSEGC_SUBSTITUTA();
            public class VA1300B_DETSEGC_SUBSTITUTA : VarBasis
            {
                /*"    10      DETSEGC-AGECONTA       PIC  9(005).*/
                public IntBasis DETSEGC_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGC-DIGAGENC       PIC  X(001).*/
                public StringBasis DETSEGC_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DETSEGC-NUMCONTA       PIC  9(016).*/
                public IntBasis DETSEGC_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10      DETSEGC-DIGCONTA       PIC  X(001).*/
                public StringBasis DETSEGC_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DETSEGC-DIGAGECTA      PIC  X(001).*/
                public StringBasis DETSEGC_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05        DETSEGC-VALINSS        PIC  9(013)V99.*/
            }
            public DoubleBasis DETSEGC_VALINSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05        FILLER                 PIC  X(109).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"1 W-RELATORIOS.*/
        }
        public VA1300B_W_RELATORIOS W_RELATORIOS { get; set; } = new VA1300B_W_RELATORIOS();
        public class VA1300B_W_RELATORIOS : VarBasis
        {
            /*"  03 LC01.*/
            public VA1300B_LC01 LC01 { get; set; } = new VA1300B_LC01();
            public class VA1300B_LC01 : VarBasis
            {
                /*"     10        FILLER              PIC  X(007)  VALUE             'VA1300B'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VA1300B");
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  03 LC02.*/
            }
            public VA1300B_LC02 LC02 { get; set; } = new VA1300B_LC02();
            public class VA1300B_LC02 : VarBasis
            {
                /*"     10        FILLER              PIC  X(006)  VALUE             'DATA: '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DATA: ");
                /*"     10        LC02-DATA           PIC  X(010).*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  03 LC03.*/
            }
            public VA1300B_LC03 LC03 { get; set; } = new VA1300B_LC03();
            public class VA1300B_LC03 : VarBasis
            {
                /*"     10        FILLER              PIC  X(047)  VALUE         'MOV. RESTITUICAO DE VIDA PARA OUTROS BANCOS EM '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"MOV. RESTITUICAO DE VIDA PARA OUTROS BANCOS EM ");
                /*"     10        LC03-DTMOVTO        PIC  X(010).*/
                public StringBasis LC03_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  03 LC04.*/
            }
            public VA1300B_LC04 LC04 { get; set; } = new VA1300B_LC04();
            public class VA1300B_LC04 : VarBasis
            {
                /*"     10        FILLER              PIC  X(010)  VALUE             'CONVENIO: '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CONVENIO: ");
                /*"     10        LC04-CONVENIO       PIC  9(004).*/
                public IntBasis LC04_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10        FILLER              PIC  X(015)  VALUE             'NSAS DE ENVIO: '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NSAS DE ENVIO: ");
                /*"     10        LC04-NSAS           PIC  ZZZZZ9.*/
                public IntBasis LC04_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10        FILLER              PIC  X(19)  VALUE             'DATA PARA CREDIRO: '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA PARA CREDIRO: ");
                /*"     10        LC04-DTVENCTO1      PIC  X(010).*/
                public StringBasis LC04_DTVENCTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  03 LC05.*/
            }
            public VA1300B_LC05 LC05 { get; set; } = new VA1300B_LC05();
            public class VA1300B_LC05 : VarBasis
            {
                /*"     10        FILLER              PIC  X(132)  VALUE ALL '-'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"     10 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  03 LC06.*/
            }
            public VA1300B_LC06 LC06 { get; set; } = new VA1300B_LC06();
            public class VA1300B_LC06 : VarBasis
            {
                /*"     05 FILLER                       PIC  X(11)  VALUE        'CERTIFICADO'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(07)  VALUE        'PARCELA'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PARCELA");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(06)  VALUE        'TITULO'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TITULO");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(20)  VALUE        'OCORR.MOV. RED. CHQ.'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"OCORR.MOV. RED. CHQ.");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(04)  VALUE        'NOME'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NOME");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(03)  VALUE        'CPF'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(05)  VALUE        'BANCO'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"BANCO");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(07)  VALUE        'AGENCIA'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(05)  VALUE        'CONTA'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CONTA");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(10)  VALUE        'OPE. CAIXA'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"OPE. CAIXA");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(13)  VALUE        'VALOR CREDITO'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"VALOR CREDITO");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 FILLER                       PIC  X(14)  VALUE        '** MENSAGEM **'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"** MENSAGEM **");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  03          LC08.*/
            }
            public VA1300B_LC08 LC08 { get; set; } = new VA1300B_LC08();
            public class VA1300B_LC08 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03 LD01.*/
            }
            public VA1300B_LD01 LD01 { get; set; } = new VA1300B_LD01();
            public class VA1300B_LD01 : VarBasis
            {
                /*"     05 LD01-NUM-CERTIFICADO     PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-NUM-PARCELA         PIC  ZZ9.*/
                public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-NUM-TITULO          PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-OCORR-MOVTO         PIC  ZZZZZZZZ9.*/
                public IntBasis LD01_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-NOME-SEGURADO       PIC  X(40)   VALUE SPACES.*/
                public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-CPF-CNPJ            PIC  X(18).*/
                public StringBasis LD01_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
                /*"     05 LD01-CPF-NUM  REDEFINES  LD01-CPF-CNPJ.*/
                private _REDEF_VA1300B_LD01_CPF_NUM _ld01_cpf_num { get; set; }
                public _REDEF_VA1300B_LD01_CPF_NUM LD01_CPF_NUM
                {
                    get { _ld01_cpf_num = new _REDEF_VA1300B_LD01_CPF_NUM(); _.Move(LD01_CPF_CNPJ, _ld01_cpf_num); VarBasis.RedefinePassValue(LD01_CPF_CNPJ, _ld01_cpf_num, LD01_CPF_CNPJ); _ld01_cpf_num.ValueChanged += () => { _.Move(_ld01_cpf_num, LD01_CPF_CNPJ); }; return _ld01_cpf_num; }
                    set { VarBasis.RedefinePassValue(value, _ld01_cpf_num, LD01_CPF_CNPJ); }
                }  //Redefines
                public class _REDEF_VA1300B_LD01_CPF_NUM : VarBasis
                {
                    /*"        10 FILLER                    PIC X(04).*/
                    public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                    /*"        10 LD01-NUM-CPF-OD002        PIC ZZZ.ZZZ.ZZZ.*/
                    public StringBasis LD01_NUM_CPF_OD002 { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ.ZZZ."), @"");
                    /*"        10 LD01-FILLER1              PIC X(01).*/
                    public StringBasis LD01_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10 LD01-DV-CPF-OD002         PIC 99.*/
                    public IntBasis LD01_DV_CPF_OD002 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"     05 LD01-CNPJ-NUM  REDEFINES  LD01-CPF-CNPJ.*/

                    public _REDEF_VA1300B_LD01_CPF_NUM()
                    {
                        FILLER_87.ValueChanged += OnValueChanged;
                        LD01_NUM_CPF_OD002.ValueChanged += OnValueChanged;
                        LD01_FILLER1.ValueChanged += OnValueChanged;
                        LD01_DV_CPF_OD002.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_VA1300B_LD01_CNPJ_NUM _ld01_cnpj_num { get; set; }
                public _REDEF_VA1300B_LD01_CNPJ_NUM LD01_CNPJ_NUM
                {
                    get { _ld01_cnpj_num = new _REDEF_VA1300B_LD01_CNPJ_NUM(); _.Move(LD01_CPF_CNPJ, _ld01_cnpj_num); VarBasis.RedefinePassValue(LD01_CPF_CNPJ, _ld01_cnpj_num, LD01_CPF_CNPJ); _ld01_cnpj_num.ValueChanged += () => { _.Move(_ld01_cnpj_num, LD01_CPF_CNPJ); }; return _ld01_cnpj_num; }
                    set { VarBasis.RedefinePassValue(value, _ld01_cnpj_num, LD01_CPF_CNPJ); }
                }  //Redefines
                public class _REDEF_VA1300B_LD01_CNPJ_NUM : VarBasis
                {
                    /*"        10 LD01-NUM-CNPJ-OD003       PIC ZZ.ZZZ.ZZZ.*/
                    public StringBasis LD01_NUM_CNPJ_OD003 { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZ."), @"");
                    /*"        10 LD01-FILLER2              PIC X(01).*/
                    public StringBasis LD01_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10 LD01-NUM-FILIAL-OD003     PIC 9999.*/
                    public IntBasis LD01_NUM_FILIAL_OD003 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"        10 LD01-FILLER3              PIC X(01).*/
                    public StringBasis LD01_FILLER3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10 LD01-DV-CNPJ-OD003        PIC 99.*/
                    public IntBasis LD01_DV_CNPJ_OD003 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/

                    public _REDEF_VA1300B_LD01_CNPJ_NUM()
                    {
                        LD01_NUM_CNPJ_OD003.ValueChanged += OnValueChanged;
                        LD01_FILLER2.ValueChanged += OnValueChanged;
                        LD01_NUM_FILIAL_OD003.ValueChanged += OnValueChanged;
                        LD01_FILLER3.ValueChanged += OnValueChanged;
                        LD01_DV_CNPJ_OD003.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-COD-BANCO           PIC  9(003).*/
                public IntBasis LD01_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-COD-AGENCIA-DEBITO  PIC  9(005).*/
                public IntBasis LD01_COD_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-NUM-CONTA-DEBITO    PIC  ZZZZZZZZZZZ9.*/
                public IntBasis LD01_NUM_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "ZZZZZZZZZZZ9."));
                /*"     05 FILLER                   PIC  X(001)  VALUE '-'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     05 LD01-DIG-CONTA-DEBITO    PIC  X(001).*/
                public StringBasis LD01_DIG_CONTA_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-OPE-CONTA-DEBITO    PIC ZZZZ.*/
                public StringBasis LD01_OPE_CONTA_DEBITO { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZ."), @"");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-VALOR               PIC  ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-."), 3);
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     05 LD01-MENSAGEM            PIC  X(036).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
                /*"     05 FILLER                       PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"01 W-AREAS-CB1061B.*/
            }
        }
        public VA1300B_W_AREAS_CB1061B W_AREAS_CB1061B { get; set; } = new VA1300B_W_AREAS_CB1061B();
        public class VA1300B_W_AREAS_CB1061B : VarBasis
        {
            /*"  03  WFIM-SORT                 PIC  X(003)    VALUE  'NAO'.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  03  LD-V0MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_V0MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-V0MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_V0MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERRO                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_ERRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-QTDLOTE                PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_QTDLOTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-QTDREGARQ              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_QTDREGARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-QTDREGLOT              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_QTDREGLOT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-NRSEQ                  PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-VLRTOTCRE              PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis AC_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AC-VLRTOTAL               PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis AC_VLRTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  ANT-SEQSORT               PIC  9(002)    VALUE   ZEROS.*/
            public IntBasis ANT_SEQSORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03  ATU-SEQSORT               PIC  9(002)    VALUE   ZEROS.*/
            public IntBasis ATU_SEQSORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03  AC-PAGINA                 PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AC-LINHAS                 PIC  9(003)    VALUE 100.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 100);
            /*"  03  WS-QTD-DIAS               PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-IND1                   PIC S9(009)  COMP  VALUE ZEROS.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WS-IND2                   PIC S9(009)  COMP  VALUE ZEROS.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  W-CHAVE-EH-SINISTRO-TUTELA PIC X(003) VALUE SPACES.*/
            public StringBasis W_CHAVE_EH_SINISTRO_TUTELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  HOST-COUNT                PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03  W-CHAVE-EH-PAGTO-SINISTRO  PIC X(003) VALUE SPACES.*/
            public StringBasis W_CHAVE_EH_PAGTO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  WS-CONTA10                PIC  X(15)    VALUE  SPACES.*/
            public StringBasis WS_CONTA10 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
            /*"  03  FILLER                    REDEFINES     WS-CONTA10.*/
            private _REDEF_VA1300B_FILLER_96 _filler_96 { get; set; }
            public _REDEF_VA1300B_FILLER_96 FILLER_96
            {
                get { _filler_96 = new _REDEF_VA1300B_FILLER_96(); _.Move(WS_CONTA10, _filler_96); VarBasis.RedefinePassValue(WS_CONTA10, _filler_96, WS_CONTA10); _filler_96.ValueChanged += () => { _.Move(_filler_96, WS_CONTA10); }; return _filler_96; }
                set { VarBasis.RedefinePassValue(value, _filler_96, WS_CONTA10); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_96 : VarBasis
            {
                /*"    10 CHAR10 OCCURS 15 TIMES  PIC  X(01).*/
                public ListBasis<StringBasis, string> CHAR10 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)."), 15);
                /*"  03  WS-CONTA20                PIC  9(15).*/

                public _REDEF_VA1300B_FILLER_96()
                {
                    CHAR10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CONTA20 { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"  03  FILLER                    REDEFINES     WS-CONTA20.*/
            private _REDEF_VA1300B_FILLER_97 _filler_97 { get; set; }
            public _REDEF_VA1300B_FILLER_97 FILLER_97
            {
                get { _filler_97 = new _REDEF_VA1300B_FILLER_97(); _.Move(WS_CONTA20, _filler_97); VarBasis.RedefinePassValue(WS_CONTA20, _filler_97, WS_CONTA20); _filler_97.ValueChanged += () => { _.Move(_filler_97, WS_CONTA20); }; return _filler_97; }
                set { VarBasis.RedefinePassValue(value, _filler_97, WS_CONTA20); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_97 : VarBasis
            {
                /*"    10 CHAR20 OCCURS 15 TIMES  PIC  X(01).*/
                public ListBasis<StringBasis, string> CHAR20 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)."), 15);
                /*"  03  WS-AGENCIA-BB             PIC  9(04).*/

                public _REDEF_VA1300B_FILLER_97()
                {
                    CHAR20.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_AGENCIA_BB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"  03  FILLER                    REDEFINES     WS-AGENCIA-BB.*/
            private _REDEF_VA1300B_FILLER_98 _filler_98 { get; set; }
            public _REDEF_VA1300B_FILLER_98 FILLER_98
            {
                get { _filler_98 = new _REDEF_VA1300B_FILLER_98(); _.Move(WS_AGENCIA_BB, _filler_98); VarBasis.RedefinePassValue(WS_AGENCIA_BB, _filler_98, WS_AGENCIA_BB); _filler_98.ValueChanged += () => { _.Move(_filler_98, WS_AGENCIA_BB); }; return _filler_98; }
                set { VarBasis.RedefinePassValue(value, _filler_98, WS_AGENCIA_BB); }
            }  //Redefines
            public class _REDEF_VA1300B_FILLER_98 : VarBasis
            {
                /*"    10 LAGEN01-1                PIC  9(01).*/
                public IntBasis LAGEN01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 LAGEN01-2                PIC  9(01).*/
                public IntBasis LAGEN01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 LAGEN01-3                PIC  9(01).*/
                public IntBasis LAGEN01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 LAGEN01-4                PIC  9(01).*/
                public IntBasis LAGEN01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"  03  WS-DV-BB                  PIC  9(01).*/

                public _REDEF_VA1300B_FILLER_98()
                {
                    LAGEN01_1.ValueChanged += OnValueChanged;
                    LAGEN01_2.ValueChanged += OnValueChanged;
                    LAGEN01_3.ValueChanged += OnValueChanged;
                    LAGEN01_4.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DV_BB { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"  03  WS-DV-BB-X                REDEFINES     WS-DV-BB                                PIC  X(01).*/
            private _REDEF_StringBasis _ws_dv_bb_x { get; set; }
            public _REDEF_StringBasis WS_DV_BB_X
            {
                get { _ws_dv_bb_x = new _REDEF_StringBasis(new PIC("X", "01", "X(01).")); ; _.Move(WS_DV_BB, _ws_dv_bb_x); VarBasis.RedefinePassValue(WS_DV_BB, _ws_dv_bb_x, WS_DV_BB); _ws_dv_bb_x.ValueChanged += () => { _.Move(_ws_dv_bb_x, WS_DV_BB); }; return _ws_dv_bb_x; }
                set { VarBasis.RedefinePassValue(value, _ws_dv_bb_x, WS_DV_BB); }
            }  //Redefines
        }


        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.CONFITSA CONFITSA { get; set; } = new Dclgens.CONFITSA();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CONVESUC CONVESUC { get; set; } = new Dclgens.CONVESUC();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.OD007 OD007 { get; set; } = new Dclgens.OD007();
        public Dclgens.OD009 OD009 { get; set; } = new Dclgens.OD009();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.ADPROGRA ADPROGRA { get; set; } = new Dclgens.ADPROGRA();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.GE354 GE354 { get; set; } = new Dclgens.GE354();
        public Dclgens.CB039 CB039 { get; set; } = new Dclgens.CB039();
        public Dclgens.CB040 CB040 { get; set; } = new Dclgens.CB040();
        public Dclgens.CB041 CB041 { get; set; } = new Dclgens.CB041();
        public Dclgens.VG079 VG079 { get; set; } = new Dclgens.VG079();
        public Dclgens.GE366 GE366 { get; set; } = new Dclgens.GE366();
        public Dclgens.GE367 GE367 { get; set; } = new Dclgens.GE367();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SORTWK01_FILE_NAME_P, string OUTROSBC_FILE_NAME_P, string SAIDA_FILE_NAME_P, string RELAT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SORTWK01.SetFile(SORTWK01_FILE_NAME_P);
                OUTROSBC.SetFile(OUTROSBC_FILE_NAME_P);
                SAIDA.SetFile(SAIDA_FILE_NAME_P);
                RELAT.SetFile(RELAT_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -873- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -874- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -875- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -878- DISPLAY '--------------------------------' */
            _.Display($"--------------------------------");

            /*" -879- DISPLAY '  PROGRAMA EM EXECUCAO VA1300B  ' */
            _.Display($"  PROGRAMA EM EXECUCAO VA1300B  ");

            /*" -880- DISPLAY '                                ' */
            _.Display($"                                ");

            /*" -881- DISPLAY '  VERSAO V.07        05/09/2017 ' */
            _.Display($"  VERSAO V.07        05/09/2017 ");

            /*" -882- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -884- DISPLAY '   ' */
            _.Display($"   ");

            /*" -892- DISPLAY 'INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -893- DISPLAY '   ' */
            _.Display($"   ");

            /*" -894- DISPLAY '------------------------------------' */
            _.Display($"------------------------------------");

            /*" -895- DISPLAY '* CODIGO DO CONVENIO DE PROCESSAMENTO' */
            _.Display($"* CODIGO DO CONVENIO DE PROCESSAMENTO");

            /*" -897- DISPLAY '* CONVENIO: 1313 ======   609000' */
            _.Display($"* CONVENIO: 1313 ======   609000");

            /*" -898- DISPLAY '------------------------------------' */
            _.Display($"------------------------------------");

            /*" -900- DISPLAY '   ' */
            _.Display($"   ");

            /*" -902- PERFORM R003-LE-SISTEMA THRU R003-EXIT. */

            R003_LE_SISTEMA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R003_EXIT*/


            /*" -903- OPEN INPUT OUTROSBC. */
            OUTROSBC.Open(MOVIMENTO_OUTROSBC);

            /*" -905- OPEN OUTPUT SAIDA RELAT. */
            SAIDA.Open(REG_MOV1313);
            RELAT.Open(REG_RELAT);

            /*" -912- SORT SORTWK01 ON ASCENDING KEY REG-SORT-NUM-SEQUENCIA REG-SORT-COD-BANCO REG-SORT-NUM-OCORR-MOVTO INPUT PROCEDURE R010-SORT-ENTRADA THRU R010-EXIT OUTPUT PROCEDURE R100-SORT-SAIDA THRU R100-EXIT. */
            SORTWK01.Sort("REG-SORT-NUM-SEQUENCIA,REG-SORT-COD-BANCO,REG-SORT-NUM-OCORR-MOVTO", () => R010_SORT_ENTRADA(true), () => R100_SORT_SAIDA(true));

        }

        [StopWatch]
        /*" M-0000-FINALIZACAO */
        private void M_0000_FINALIZACAO(bool isPerform = false)
        {
            /*" -918- DISPLAY ' ' */
            _.Display($" ");

            /*" -920- DISPLAY 'DATA DE VENCIMENTO PARA TODOS OS MOVIMENTO - ' REG-SORT-DATA-VENCIMENTO */
            _.Display($"DATA DE VENCIMENTO PARA TODOS OS MOVIMENTO - {REG_SORTWK01.REG_SORT_DATA_VENCIMENTO}");

            /*" -921- DISPLAY ' ' */
            _.Display($" ");

            /*" -922- DISPLAY 'NSA GERADO PELO VA0341B: ' REG-SORT-NSA */
            _.Display($"NSA GERADO PELO VA0341B: {REG_SORTWK01.REG_SORT_NSA}");

            /*" -923- MOVE W-LIDOS-ARQUIVO TO W-EDICAO. */
            _.Move(WORK_AREA.W_LIDOS_ARQUIVO, WORK_AREA.W_EDICAO);

            /*" -924- DISPLAY ' ' */
            _.Display($" ");

            /*" -925- DISPLAY 'QTD. REGISTROS LIDOS NA ENTRADA: ' W-EDICAO */
            _.Display($"QTD. REGISTROS LIDOS NA ENTRADA: {WORK_AREA.W_EDICAO}");

            /*" -926- MOVE W-LIDOS-SORT TO W-EDICAO. */
            _.Move(WORK_AREA.W_LIDOS_SORT, WORK_AREA.W_EDICAO);

            /*" -927- DISPLAY ' ' */
            _.Display($" ");

            /*" -928- DISPLAY 'QTD. REGISTROS LIDOS DO SORT   : ' W-EDICAO */
            _.Display($"QTD. REGISTROS LIDOS DO SORT   : {WORK_AREA.W_EDICAO}");

            /*" -930- DISPLAY ' ' */
            _.Display($" ");

            /*" -932- PERFORM R10000-GRAVA-RELATORIOS THRU R10000-EXIT. */

            R10000_GRAVA_RELATORIOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/


            /*" -934- CLOSE SAIDA RELAT OUTROSBC. */
            SAIDA.Close();
            RELAT.Close();
            OUTROSBC.Close();

            /*" -934- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -937- DISPLAY '*************************************' */
            _.Display($"*************************************");

            /*" -938- DISPLAY '*                                   *' */
            _.Display($"*                                   *");

            /*" -939- DISPLAY '*           VA1300B                 *' */
            _.Display($"*           VA1300B                 *");

            /*" -940- DISPLAY '*                                   *' */
            _.Display($"*                                   *");

            /*" -941- DISPLAY '*          FIM NORMAL               *' */
            _.Display($"*          FIM NORMAL               *");

            /*" -942- DISPLAY '*                                   *' */
            _.Display($"*                                   *");

            /*" -944- DISPLAY '*************************************' */
            _.Display($"*************************************");

            /*" -946- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -946- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" R003-LE-SISTEMA */
        private void R003_LE_SISTEMA(bool isPerform = false)
        {
            /*" -954- MOVE 'R003' TO WNR-EXEC-SQL. */
            _.Move("R003", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -956- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -963- PERFORM R003_LE_SISTEMA_DB_SELECT_1 */

            R003_LE_SISTEMA_DB_SELECT_1();

            /*" -966- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -967- DISPLAY 'ERRO SELECT NA SISTEMAS' */
                _.Display($"ERRO SELECT NA SISTEMAS");

                /*" -969- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -970- MOVE HOST-CURRENT-DATE TO W-DATA-AAAA-MM-DD. */
            _.Move(HOST_CURRENT_DATE, WORK_AREA.W_DATA_AAAA_MM_DD);

            /*" -971- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -972- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -974- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -975- DISPLAY '*** VA1300B ***' */
            _.Display($"*** VA1300B ***");

            /*" -978- DISPLAY '=> DATA DE GERACAO DA FITA: ' W-DATA-DD-MM-AAAA ' CURRENT DATE' . */

            $"=> DATA DE GERACAO DA FITA: {WORK_AREA.W_DATA_DD_MM_AAAA} CURRENT DATE"
            .Display();

            /*" -979- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DATA_AAAA_MM_DD);

            /*" -980- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -981- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -983- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -986- DISPLAY '=> DATA DO SISTEMA VA: ' W-DATA-DD-MM-AAAA. */
            _.Display($"=> DATA DO SISTEMA VA: {WORK_AREA.W_DATA_DD_MM_AAAA}");

            /*" -986- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA LC03-DTMOVTO. */
            _.Move(WORK_AREA.W_DATA_DD_MM_AAAA, W_RELATORIOS.LC02.LC02_DATA, W_RELATORIOS.LC03.LC03_DTMOVTO);

        }

        [StopWatch]
        /*" R003-LE-SISTEMA-DB-SELECT-1 */
        public void R003_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -963- EXEC SQL SELECT CURRENT DATE, DATA_MOV_ABERTO INTO :HOST-CURRENT-DATE , :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var r003_LE_SISTEMA_DB_SELECT_1_Query1 = new R003_LE_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R003_LE_SISTEMA_DB_SELECT_1_Query1.Execute(r003_LE_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_CURRENT_DATE, HOST_CURRENT_DATE);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R003_EXIT*/

        [StopWatch]
        /*" R010-SORT-ENTRADA */
        private void R010_SORT_ENTRADA(bool isPerform = false)
        {
            /*" -994- MOVE 'NAO' TO WFIM-ENTRADA. */
            _.Move("NAO", WFIM_ENTRADA);

            /*" -996- PERFORM R015-LE-ARQUIVO THRU R015-EXIT. */

            R015_LE_ARQUIVO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/


            /*" -997- IF WFIM-ENTRADA EQUAL 'SIM' */

            if (WFIM_ENTRADA == "SIM")
            {

                /*" -998- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -999- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1000- DISPLAY '*           VA1300B                 *' */
                _.Display($"*           VA1300B                 *");

                /*" -1001- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1002- DISPLAY '*  NAO FOI GERADO PELO PROGRAMA     *' */
                _.Display($"*  NAO FOI GERADO PELO PROGRAMA     *");

                /*" -1003- DISPLAY '*  VA0341B DEVOLUCAO DE VIDA PARA   *' */
                _.Display($"*  VA0341B DEVOLUCAO DE VIDA PARA   *");

                /*" -1004- DISPLAY '*  OUTROS BANCOS NA DATA DE HOJE    *' */
                _.Display($"*  OUTROS BANCOS NA DATA DE HOJE    *");

                /*" -1005- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1006- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1008- MOVE '**  ==> SEM MOVIMENTO NA DATA DE HOJE <== **' TO LC06 */
                _.Move("**  ==> SEM MOVIMENTO NA DATA DE HOJE <== **", W_RELATORIOS.LC06);

                /*" -1009- DISPLAY ' ' */
                _.Display($" ");

                /*" -1011- GO TO 0000-FINALIZACAO. */

                M_0000_FINALIZACAO(); //GOTO
                return;
            }


            /*" -1012- PERFORM R020-PROCESSA-ENTRADA THRU R020-EXIT UNTIL WFIM-ENTRADA EQUAL 'SIM' . */

            while (!(WFIM_ENTRADA == "SIM"))
            {

                R020_PROCESSA_ENTRADA(true);

                R020_LER_ARQUIVO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R015-LE-ARQUIVO */
        private void R015_LE_ARQUIVO(bool isPerform = false)
        {
            /*" -1018- READ OUTROSBC AT END */
            try
            {
                OUTROSBC.Read(() =>
                {

                    /*" -1020- MOVE 'SIM' TO WFIM-ENTRADA */
                    _.Move("SIM", WFIM_ENTRADA);

                    /*" -1022- GO TO R015-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/ //GOTO
                    return;
                });

                _.Move(OUTROSBC.Value, MOVIMENTO_OUTROSBC);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1024- ADD 1 TO W-LIDOS-ARQUIVO. */
            WORK_AREA.W_LIDOS_ARQUIVO.Value = WORK_AREA.W_LIDOS_ARQUIVO + 1;

            /*" -1024- MOVE MOVIMENTO-OUTROSBC TO MOV-OUTROS-BANCOS . */
            _.Move(OUTROSBC?.Value, MOV_OUTROS_BANCOS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/

        [StopWatch]
        /*" R020-PROCESSA-ENTRADA */
        private void R020_PROCESSA_ENTRADA(bool isPerform = false)
        {
            /*" -1031- IF (W-LIDOS-ARQUIVO > 1) */

            if ((WORK_AREA.W_LIDOS_ARQUIVO > 1))
            {

                /*" -1037- IF ((MOV-OUTROBC-NUM-CERTIFICADO EQUAL REG-SORT-NUM-CERTIFICADO) AND (MOV-OUTROBC-NUM-PARCELA EQUAL REG-SORT-NUM-PARCELA) AND (MOV-OUTROBC-NUM-TITULO EQUAL REG-SORT-NUM-TITULO)) */

                if (((MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_CERTIFICADO == REG_SORTWK01.REG_SORT_NUM_CERTIFICADO) && (MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_PARCELA == REG_SORTWK01.REG_SORT_NUM_PARCELA) && (MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_TITULO == REG_SORTWK01.REG_SORT_NUM_TITULO)))
                {

                    /*" -1038- ADD 1 TO WS-CONT-REG-DUPLIC */
                    WORK_AREA.WS_CONT_REG_DUPLIC.Value = WORK_AREA.WS_CONT_REG_DUPLIC + 1;

                    /*" -1039- GO TO R020-LER-ARQUIVO */

                    R020_LER_ARQUIVO(); //GOTO
                    return;

                    /*" -1040- END-IF */
                }


                /*" -1042- END-IF. */
            }


            /*" -1044- MOVE MOV-OUTROBC-NUM-SEQUENCIA TO REG-SORT-NUM-SEQUENCIA. */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_SEQUENCIA, REG_SORTWK01.REG_SORT_NUM_SEQUENCIA);

            /*" -1046- MOVE MOV-OUTROBC-COD-BANCO TO REG-SORT-COD-BANCO . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_COD_BANCO, REG_SORTWK01.REG_SORT_COD_BANCO);

            /*" -1048- MOVE MOV-OUTROBC-NUM-OCORR-MOVTO TO REG-SORT-NUM-OCORR-MOVTO . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_OCORR_MOVTO, REG_SORTWK01.REG_SORT_NUM_OCORR_MOVTO);

            /*" -1050- MOVE MOV-OUTROBC-NUM-CERTIFICADO TO REG-SORT-NUM-CERTIFICADO . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_CERTIFICADO, REG_SORTWK01.REG_SORT_NUM_CERTIFICADO);

            /*" -1052- MOVE MOV-OUTROBC-NUM-PARCELA TO REG-SORT-NUM-PARCELA . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_PARCELA, REG_SORTWK01.REG_SORT_NUM_PARCELA);

            /*" -1054- MOVE MOV-OUTROBC-NUM-TITULO TO REG-SORT-NUM-TITULO . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_TITULO, REG_SORTWK01.REG_SORT_NUM_TITULO);

            /*" -1056- MOVE MOV-OUTROBC-NUM-PESSOA TO REG-SORT-NUM-PESSOA . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NUM_PESSOA, REG_SORTWK01.REG_SORT_NUM_PESSOA);

            /*" -1058- MOVE MOV-OUTROBC-DATA-VENCIMENTO TO REG-SORT-DATA-VENCIMENTO . */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_DATA_VENCIMENTO, REG_SORTWK01.REG_SORT_DATA_VENCIMENTO);

            /*" -1061- MOVE MOV-OUTROBC-NSA TO REG-SORT-NSA. */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NSA, REG_SORTWK01.REG_SORT_NSA);

            /*" -1061- RELEASE REG-SORTWK01. */
            SORTWK01.Release(REG_SORTWK01);

        }

        [StopWatch]
        /*" R020-LER-ARQUIVO */
        private void R020_LER_ARQUIVO(bool isPerform = false)
        {
            /*" -1064- PERFORM R015-LE-ARQUIVO THRU R015-EXIT. */

            R015_LE_ARQUIVO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R100-SORT-SAIDA */
        private void R100_SORT_SAIDA(bool isPerform = false)
        {
            /*" -1071- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1072- MOVE 'R100-SORT-SAIDA        ' TO PARAGRAFO. */
            _.Move("R100-SORT-SAIDA        ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1074- MOVE 'PROCESSA SORT SAIDA    ' TO COMANDO. */
            _.Move("PROCESSA SORT SAIDA    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1076- DISPLAY 'INICIO DA LEITURA DO SORT' */
            _.Display($"INICIO DA LEITURA DO SORT");

            /*" -1078- MOVE 'NAO' TO WFIM-SORT. */
            _.Move("NAO", W_AREAS_CB1061B.WFIM_SORT);

            /*" -1080- PERFORM R110-LE-SORT THRU R110-EXIT. */

            R110_LE_SORT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -1081- IF WFIM-SORT EQUAL 'SIM' */

            if (W_AREAS_CB1061B.WFIM_SORT == "SIM")
            {

                /*" -1082- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1083- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1084- DISPLAY '*           VA1300B                 *' */
                _.Display($"*           VA1300B                 *");

                /*" -1085- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1086- DISPLAY '*  ERRO DE LEITURA NO ARQUIVO SORT  *' */
                _.Display($"*  ERRO DE LEITURA NO ARQUIVO SORT  *");

                /*" -1087- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -1088- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1090- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1091- MOVE REG-SORT-DATA-VENCIMENTO TO W-DATA-AAAA-MM-DD. */
            _.Move(REG_SORTWK01.REG_SORT_DATA_VENCIMENTO, WORK_AREA.W_DATA_AAAA_MM_DD);

            /*" -1092- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -1093- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -1094- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(WORK_AREA.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, WORK_AREA.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -1096- MOVE W-DATA-DD-MM-AAAA TO LC04-DTVENCTO1 */
            _.Move(WORK_AREA.W_DATA_DD_MM_AAAA, W_RELATORIOS.LC04.LC04_DTVENCTO1);

            /*" -1098- MOVE REG-SORT-NSA TO LC04-NSAS */
            _.Move(REG_SORTWK01.REG_SORT_NSA, W_RELATORIOS.LC04.LC04_NSAS);

            /*" -1100- MOVE 1313 TO LC04-CONVENIO. */
            _.Move(1313, W_RELATORIOS.LC04.LC04_CONVENIO);

            /*" -1101- WRITE REG-RELAT FROM LC01. */
            _.Move(W_RELATORIOS.LC01.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1102- WRITE REG-RELAT FROM LC02. */
            _.Move(W_RELATORIOS.LC02.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1103- WRITE REG-RELAT FROM LC03. */
            _.Move(W_RELATORIOS.LC03.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1104- WRITE REG-RELAT FROM LC04. */
            _.Move(W_RELATORIOS.LC04.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1105- WRITE REG-RELAT FROM LC05. */
            _.Move(W_RELATORIOS.LC05.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1109- WRITE REG-RELAT FROM LC06. */
            _.Move(W_RELATORIOS.LC06.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1119- PERFORM R3000-00-HEADER-ARQUIVO THRU R3000-EXIT. */

            R3000_00_HEADER_ARQUIVO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/


            /*" -1121- IF REG-SORT-NUM-SEQUENCIA EQUAL 1 AND REG-SORT-COD-BANCO EQUAL 1 */

            if (REG_SORTWK01.REG_SORT_NUM_SEQUENCIA == 1 && REG_SORTWK01.REG_SORT_COD_BANCO == 1)
            {

                /*" -1122- MOVE 'SIM' TO W-CHAVE-LOTE-BANCO-BRASIL */
                _.Move("SIM", W_CHAVE_LOTE_BANCO_BRASIL);

                /*" -1124- PERFORM R200-MOVIMENTO-BANCO-BRASIL THRU R200-EXIT. */

                R200_MOVIMENTO_BANCO_BRASIL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

            }


            /*" -1128- MOVE 'NAO' TO W-CHAVE-LOTE-BANCO-BRASIL. */
            _.Move("NAO", W_CHAVE_LOTE_BANCO_BRASIL);

            /*" -1130- PERFORM R3200-00-HEADER-LOTE THRU R3200-EXIT */

            R3200_00_HEADER_LOTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/


            /*" -1135- PERFORM R1010-MONTA-REGISTRO-240 THRU R1010-EXIT UNTIL WFIM-SORT EQUAL 'SIM' . */

            while (!(W_AREAS_CB1061B.WFIM_SORT == "SIM"))
            {

                R1010_MONTA_REGISTRO_240(true);

                R1010_LE_NOVO_REGISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

            }

            /*" -1139- PERFORM R3300-00-TRAILLER-LOTE THRU R3300-EXIT . */

            R3300_00_TRAILLER_LOTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/


            /*" -1139- PERFORM R3100-00-TRAILLER-ARQUIVO THRU R3100-EXIT. */

            R3100_00_TRAILLER_ARQUIVO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-LE-SORT */
        private void R110_LE_SORT(bool isPerform = false)
        {
            /*" -1146- RETURN SORTWK01 AT END */
            try
            {
                SORTWK01.Return(REG_SORTWK01, () =>
                {

                    /*" -1147- MOVE 'SIM' TO WFIM-SORT */
                    _.Move("SIM", W_AREAS_CB1061B.WFIM_SORT);

                    /*" -1149- GO TO R110-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1151- ADD 1 TO W-LIDOS-SORT. */
            WORK_AREA.W_LIDOS_SORT.Value = WORK_AREA.W_LIDOS_SORT + 1;

            /*" -1157- IF (REG-SORT-NUM-CERTIFICADO EQUAL W-SORT-NUM-CERTIFICADO) AND (REG-SORT-NUM-PARCELA EQUAL W-SORT-NUM-PARCELA) AND (REG-SORT-NUM-TITULO EQUAL W-SORT-NUM-TITULO) */

            if ((REG_SORTWK01.REG_SORT_NUM_CERTIFICADO == WORK_AREA.W_SORT_NUM_CERTIFICADO) && (REG_SORTWK01.REG_SORT_NUM_PARCELA == WORK_AREA.W_SORT_NUM_PARCELA) && (REG_SORTWK01.REG_SORT_NUM_TITULO == WORK_AREA.W_SORT_NUM_TITULO))
            {

                /*" -1158- ADD 001 TO WS-CONT-REG-DUPLIC */
                WORK_AREA.WS_CONT_REG_DUPLIC.Value = WORK_AREA.WS_CONT_REG_DUPLIC + 001;

                /*" -1159- GO TO R110-LE-SORT */
                new Task(() => R110_LE_SORT()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1160- ELSE */
            }
            else
            {


                /*" -1161- MOVE REG-SORT-NUM-CERTIFICADO TO W-SORT-NUM-CERTIFICADO */
                _.Move(REG_SORTWK01.REG_SORT_NUM_CERTIFICADO, WORK_AREA.W_SORT_NUM_CERTIFICADO);

                /*" -1162- MOVE REG-SORT-NUM-PARCELA TO W-SORT-NUM-PARCELA */
                _.Move(REG_SORTWK01.REG_SORT_NUM_PARCELA, WORK_AREA.W_SORT_NUM_PARCELA);

                /*" -1163- MOVE REG-SORT-NUM-TITULO TO W-SORT-NUM-TITULO */
                _.Move(REG_SORTWK01.REG_SORT_NUM_TITULO, WORK_AREA.W_SORT_NUM_TITULO);

                /*" -1163- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R200-MOVIMENTO-BANCO-BRASIL */
        private void R200_MOVIMENTO_BANCO_BRASIL(bool isPerform = false)
        {
            /*" -1170- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1171- MOVE 'R200-MOVIMENTO-BANCO   ' TO PARAGRAFO. */
            _.Move("R200-MOVIMENTO-BANCO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1175- MOVE 'MOVIMENTO BANCO DO BRAS' TO COMANDO. */
            _.Move("MOVIMENTO BANCO DO BRAS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1177- PERFORM R3200-00-HEADER-LOTE THRU R3200-EXIT */

            R3200_00_HEADER_LOTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/


            /*" -1179- MOVE REG-SORT-COD-BANCO TO W-BANCO-ANTERIOR */
            _.Move(REG_SORTWK01.REG_SORT_COD_BANCO, W_BANCO_ANTERIOR);

            /*" -1185- PERFORM R1010-MONTA-REGISTRO-240 THRU R1010-EXIT UNTIL WFIM-SORT EQUAL 'SIM' OR REG-SORT-COD-BANCO NOT EQUAL W-BANCO-ANTERIOR. */

            while (!(W_AREAS_CB1061B.WFIM_SORT == "SIM" || REG_SORTWK01.REG_SORT_COD_BANCO != W_BANCO_ANTERIOR))
            {

                R1010_MONTA_REGISTRO_240(true);

                R1010_LE_NOVO_REGISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

            }

            /*" -1187- PERFORM R3300-00-TRAILLER-LOTE THRU R3300-EXIT */

            R3300_00_TRAILLER_LOTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/


            /*" -1187- MOVE ZEROS TO AC-NRSEQ AC-QTDREGLOT AC-VLRTOTCRE. */
            _.Move(0, W_AREAS_CB1061B.AC_NRSEQ, W_AREAS_CB1061B.AC_QTDREGLOT, W_AREAS_CB1061B.AC_VLRTOTCRE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R1010-MONTA-REGISTRO-240 */
        private void R1010_MONTA_REGISTRO_240(bool isPerform = false)
        {
            /*" -1196- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1197- MOVE 'R1100-MONTA-REGISTRO   ' TO PARAGRAFO. */
            _.Move("R1100-MONTA-REGISTRO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1199- MOVE 'PROCESSA REGISTRO 240  ' TO COMANDO. */
            _.Move("PROCESSA REGISTRO 240  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1200- MOVE REG-SORT-NUM-OCORR-MOVTO TO VG079-NUM-OCORR-MOVTO. */
            _.Move(REG_SORTWK01.REG_SORT_NUM_OCORR_MOVTO, VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO);

            /*" -1201- MOVE REG-SORT-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO. */
            _.Move(REG_SORTWK01.REG_SORT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -1202- MOVE REG-SORT-NUM-PARCELA TO HISLANCT-NUM-PARCELA. */
            _.Move(REG_SORTWK01.REG_SORT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -1203- MOVE REG-SORT-NSA TO HISLANCT-NSAS. */
            _.Move(REG_SORTWK01.REG_SORT_NSA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

            /*" -1204- MOVE REG-SORT-NUM-TITULO TO COBHISVI-NUM-TITULO. */
            _.Move(REG_SORTWK01.REG_SORT_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);

            /*" -1207- MOVE REG-SORT-NUM-PESSOA TO GE368-NUM-PESSOA */
            _.Move(REG_SORTWK01.REG_SORT_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);

            /*" -1210- PERFORM R300-SELECT-HISLANCT THRU R300-EXIT. */

            R300_SELECT_HISLANCT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


            /*" -1213- PERFORM R1100-LE-PESSOA THRU R1100-EXIT. */

            R1100_LE_PESSOA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1217- PERFORM R1200-LE-ENDERECO THRU R1200-EXIT. */

            R1200_LE_ENDERECO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -1218- MOVE HISLANCT-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, W_RELATORIOS.LD01.LD01_NUM_CERTIFICADO);

            /*" -1219- MOVE HISLANCT-NUM-PARCELA TO LD01-NUM-PARCELA */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, W_RELATORIOS.LD01.LD01_NUM_PARCELA);

            /*" -1220- MOVE ZEROS TO LD01-NUM-TITULO. */
            _.Move(0, W_RELATORIOS.LD01.LD01_NUM_TITULO);

            /*" -1221- MOVE HISLANCT-PRM-TOTAL TO LD01-VALOR */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, W_RELATORIOS.LD01.LD01_VALOR);

            /*" -1222- MOVE HISLANCT-CODCONV TO LC04-CONVENIO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV, W_RELATORIOS.LC04.LC04_CONVENIO);

            /*" -1223- MOVE GE368-NUM-OCORR-MOVTO TO LD01-OCORR-MOVTO */
            _.Move(GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO, W_RELATORIOS.LD01.LD01_OCORR_MOVTO);

            /*" -1225- MOVE 'ENVIADO COM SUCESSO AO SAP' TO LD01-MENSAGEM */
            _.Move("ENVIADO COM SUCESSO AO SAP", W_RELATORIOS.LD01.LD01_MENSAGEM);

            /*" -1226- MOVE OD009-COD-BANCO TO LD01-COD-BANCO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, W_RELATORIOS.LD01.LD01_COD_BANCO);

            /*" -1227- MOVE OD009-COD-AGENCIA TO LD01-COD-AGENCIA-DEBITO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, W_RELATORIOS.LD01.LD01_COD_AGENCIA_DEBITO);

            /*" -1228- MOVE OD009-NUM-CONTA TO LD01-NUM-CONTA-DEBITO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, W_RELATORIOS.LD01.LD01_NUM_CONTA_DEBITO);

            /*" -1229- MOVE OD009-NUM-DV-CONTA TO LD01-DIG-CONTA-DEBITO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA, W_RELATORIOS.LD01.LD01_DIG_CONTA_DEBITO);

            /*" -1247- MOVE OD009-NUM-OPERACAO-CONTA TO LD01-OPE-CONTA-DEBITO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, W_RELATORIOS.LD01.LD01_OPE_CONTA_DEBITO);

            /*" -1249- IF OD009-COD-BANCO EQUAL 031 OR 244 OR 275 OR 085 OR 291 OR 641 */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO.In("031", "244", "275", "085", "291", "641"))
            {

                /*" -1252- MOVE 'BANCO INVALIDO. BANCO DO BRASIL NAO ACEITA. REJEITADO' TO LD01-MENSAGEM */
                _.Move("BANCO INVALIDO. BANCO DO BRASIL NAO ACEITA. REJEITADO", W_RELATORIOS.LD01.LD01_MENSAGEM);

                /*" -1253- ADD 1 TO AC-ERRO */
                W_AREAS_CB1061B.AC_ERRO.Value = W_AREAS_CB1061B.AC_ERRO + 1;

                /*" -1254- PERFORM R1900-IMPRIME-RELAT THRU R1900-EXIT */

                R1900_IMPRIME_RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/


                /*" -1255- GO TO R1010-LE-NOVO-REGISTRO */

                R1010_LE_NOVO_REGISTRO(); //GOTO
                return;

                /*" -1257- END-IF. */
            }


            /*" -1259- IF OD009-COD-AGENCIA EQUAL 0 OR OD009-NUM-CONTA EQUAL 0 */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA == 0 || OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA == 0)
            {

                /*" -1262- MOVE 'CONTA INVALIDA. AGENCIA, NUM. OU DV ZERADO. REJEITADO' TO LD01-MENSAGEM */
                _.Move("CONTA INVALIDA. AGENCIA, NUM. OU DV ZERADO. REJEITADO", W_RELATORIOS.LD01.LD01_MENSAGEM);

                /*" -1263- ADD 1 TO AC-ERRO */
                W_AREAS_CB1061B.AC_ERRO.Value = W_AREAS_CB1061B.AC_ERRO + 1;

                /*" -1264- PERFORM R1900-IMPRIME-RELAT THRU R1900-EXIT */

                R1900_IMPRIME_RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/


                /*" -1265- GO TO R1010-LE-NOVO-REGISTRO */

                R1010_LE_NOVO_REGISTRO(); //GOTO
                return;

                /*" -1267- END-IF. */
            }


            /*" -1269- IF OD009-COD-BANCO EQUAL 104 AND OD009-NUM-OPERACAO-CONTA EQUAL 0 */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO == 104 && OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA == 0)
            {

                /*" -1271- MOVE 'OPERACAO DA CONTA CAIXA ZERADA' TO LD01-MENSAGEM */
                _.Move("OPERACAO DA CONTA CAIXA ZERADA", W_RELATORIOS.LD01.LD01_MENSAGEM);

                /*" -1272- ADD 1 TO AC-ERRO */
                W_AREAS_CB1061B.AC_ERRO.Value = W_AREAS_CB1061B.AC_ERRO + 1;

                /*" -1273- PERFORM R1900-IMPRIME-RELAT THRU R1900-EXIT */

                R1900_IMPRIME_RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/


                /*" -1274- GO TO R1010-LE-NOVO-REGISTRO */

                R1010_LE_NOVO_REGISTRO(); //GOTO
                return;

                /*" -1277- END-IF. */
            }


            /*" -1278- IF HISLANCT-PRM-TOTAL NOT GREATER 0 */

            if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL <= 0)
            {

                /*" -1280- MOVE 'VALOR ZERADO OU NEGATIVO. REJEITADO' TO LD01-MENSAGEM */
                _.Move("VALOR ZERADO OU NEGATIVO. REJEITADO", W_RELATORIOS.LD01.LD01_MENSAGEM);

                /*" -1281- ADD 1 TO AC-ERRO */
                W_AREAS_CB1061B.AC_ERRO.Value = W_AREAS_CB1061B.AC_ERRO + 1;

                /*" -1282- PERFORM R1900-IMPRIME-RELAT THRU R1900-EXIT */

                R1900_IMPRIME_RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/


                /*" -1283- GO TO R1010-LE-NOVO-REGISTRO */

                R1010_LE_NOVO_REGISTRO(); //GOTO
                return;

                /*" -1286- END-IF. */
            }


            /*" -1289- PERFORM R1400-00-SEGMENTO-A THRU R1400-EXIT. */

            R1400_00_SEGMENTO_A(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/


            /*" -1291- PERFORM R1500-00-SEGMENTO-B THRU R1500-EXIT. */

            R1500_00_SEGMENTO_B(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/


            /*" -1293- MOVE W-DATA-PRX-DIA-UTIL-CREDITO TO HISLANCT-DATA-VENCIMENTO */
            _.Move(WORK_AREA.W_DATA_PRX_DIA_UTIL_CREDITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);

            /*" -1295- MOVE 002 TO GE366-IND-EVENTO. */
            _.Move(002, GE366.DCLGE_MOVIMENTO.GE366_IND_EVENTO);

            /*" -1297- MOVE GE368-NUM-OCORR-MOVTO TO GE366-NUM-OCORR-MOVTO. */
            _.Move(GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO, GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO);

            /*" -1299- PERFORM R1600-00-UPDATE-GE366 THRU R1600-EXIT . */

            R1600_00_UPDATE_GE366(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/


            /*" -1299- PERFORM R1900-IMPRIME-RELAT THRU R1900-EXIT . */

            R1900_IMPRIME_RELAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/


        }

        [StopWatch]
        /*" R1010-LE-NOVO-REGISTRO */
        private void R1010_LE_NOVO_REGISTRO(bool isPerform = false)
        {
            /*" -1305- PERFORM R110-LE-SORT THRU R110-EXIT. */

            R110_LE_SORT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1100-LE-PESSOA */
        private void R1100_LE_PESSOA(bool isPerform = false)
        {
            /*" -1314- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1315- MOVE 'R1100-00-LER-PESSOA    ' TO PARAGRAFO. */
            _.Move("R1100-00-LER-PESSOA    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1317- MOVE 'LEITURA DE PESSOA      ' TO COMANDO. */
            _.Move("LEITURA DE PESSOA      ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1324- PERFORM R1100_LE_PESSOA_DB_SELECT_1 */

            R1100_LE_PESSOA_DB_SELECT_1();

            /*" -1327- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1328- DISPLAY 'VA1300B - ERRO ACESSO ODS.OD_PESSOA' */
                _.Display($"VA1300B - ERRO ACESSO ODS.OD_PESSOA");

                /*" -1330- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1331- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -1332- PERFORM R1120-00-SELECT-OD002 THRU R1120-EXIT */

                R1120_00_SELECT_OD002(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_EXIT*/


                /*" -1333- ELSE */
            }
            else
            {


                /*" -1334- PERFORM R1140-00-SELECT-OD003 THRU R1140-EXIT */

                R1140_00_SELECT_OD003(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_EXIT*/


                /*" -1334- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-LE-PESSOA-DB-SELECT-1 */
        public void R1100_LE_PESSOA_DB_SELECT_1()
        {
            /*" -1324- EXEC SQL SELECT NUM_PESSOA , IND_PESSOA INTO :OD001-NUM-PESSOA , :OD001-IND-PESSOA FROM ODS.OD_PESSOA WHERE NUM_PESSOA = :GE368-NUM-PESSOA END-EXEC. */

            var r1100_LE_PESSOA_DB_SELECT_1_Query1 = new R1100_LE_PESSOA_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1100_LE_PESSOA_DB_SELECT_1_Query1.Execute(r1100_LE_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/

        [StopWatch]
        /*" R1120-00-SELECT-OD002 */
        private void R1120_00_SELECT_OD002(bool isPerform = false)
        {
            /*" -1343- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1344- MOVE 'R1120-00-SELECT-OD002  ' TO PARAGRAFO. */
            _.Move("R1120-00-SELECT-OD002  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1346- MOVE 'SELECT OD002           ' TO COMANDO. */
            _.Move("SELECT OD002           ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1348- MOVE SPACES TO OD002-NOM-PESSOA-TEXT. */
            _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT);

            /*" -1359- PERFORM R1120_00_SELECT_OD002_DB_SELECT_1 */

            R1120_00_SELECT_OD002_DB_SELECT_1();

            /*" -1362- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1363- DISPLAY 'ERRO DE ACESSO - R1120-00-SELECT-OD002' */
                _.Display($"ERRO DE ACESSO - R1120-00-SELECT-OD002");

                /*" -1364- DISPLAY 'TABELA - ODS.OD_PESSOA_FISICA' */
                _.Display($"TABELA - ODS.OD_PESSOA_FISICA");

                /*" -1365- DISPLAY 'GE368-NUM-PESSOA - ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1367- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1369- MOVE SPACES TO LD01-CPF-NUM LD01-CNPJ-NUM. */
            _.Move("", W_RELATORIOS.LD01.LD01_CPF_NUM, W_RELATORIOS.LD01.LD01_CNPJ_NUM);

            /*" -1370- MOVE OD002-NOM-PESSOA-TEXT TO LD01-NOME-SEGURADO. */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, W_RELATORIOS.LD01.LD01_NOME_SEGURADO);

            /*" -1371- MOVE OD002-NUM-CPF TO LD01-NUM-CPF-OD002 . */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, W_RELATORIOS.LD01.LD01_CPF_NUM.LD01_NUM_CPF_OD002);

            /*" -1372- MOVE OD002-NUM-DV-CPF TO LD01-DV-CPF-OD002 . */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, W_RELATORIOS.LD01.LD01_CPF_NUM.LD01_DV_CPF_OD002);

            /*" -1372- MOVE '-' TO LD01-FILLER1 . */
            _.Move("-", W_RELATORIOS.LD01.LD01_CPF_NUM.LD01_FILLER1);

        }

        [StopWatch]
        /*" R1120-00-SELECT-OD002-DB-SELECT-1 */
        public void R1120_00_SELECT_OD002_DB_SELECT_1()
        {
            /*" -1359- EXEC SQL SELECT NUM_PESSOA , NUM_CPF , NUM_DV_CPF , NOM_PESSOA INTO :OD002-NUM-PESSOA , :OD002-NUM-CPF , :OD002-NUM-DV-CPF , :OD002-NOM-PESSOA FROM ODS.OD_PESSOA_FISICA WHERE NUM_PESSOA = :GE368-NUM-PESSOA END-EXEC. */

            var r1120_00_SELECT_OD002_DB_SELECT_1_Query1 = new R1120_00_SELECT_OD002_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1120_00_SELECT_OD002_DB_SELECT_1_Query1.Execute(r1120_00_SELECT_OD002_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD002_NUM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA);
                _.Move(executed_1.OD002_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);
                _.Move(executed_1.OD002_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);
                _.Move(executed_1.OD002_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_EXIT*/

        [StopWatch]
        /*" R1140-00-SELECT-OD003 */
        private void R1140_00_SELECT_OD003(bool isPerform = false)
        {
            /*" -1381- MOVE '1140' TO WNR-EXEC-SQL. */
            _.Move("1140", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1382- MOVE 'R1140-00-SELECT-OD003  ' TO PARAGRAFO. */
            _.Move("R1140-00-SELECT-OD003  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1384- MOVE 'SELECT OD003           ' TO COMANDO. */
            _.Move("SELECT OD003           ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1386- MOVE SPACES TO OD003-NOM-RAZAO-SOCIAL-TEXT. */
            _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT);

            /*" -1399- PERFORM R1140_00_SELECT_OD003_DB_SELECT_1 */

            R1140_00_SELECT_OD003_DB_SELECT_1();

            /*" -1402- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1403- DISPLAY 'ERRO DE ACESSO - R1140-00-SELECT-OD003' */
                _.Display($"ERRO DE ACESSO - R1140-00-SELECT-OD003");

                /*" -1404- DISPLAY 'TABELA - ODS.OD_PESSOA_JURIDICA' */
                _.Display($"TABELA - ODS.OD_PESSOA_JURIDICA");

                /*" -1405- DISPLAY 'GE368-NUM-PESSOA - ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1407- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1409- MOVE SPACES TO LD01-CPF-NUM LD01-CNPJ-NUM. */
            _.Move("", W_RELATORIOS.LD01.LD01_CPF_NUM, W_RELATORIOS.LD01.LD01_CNPJ_NUM);

            /*" -1410- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO LD01-NOME-SEGURADO. */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, W_RELATORIOS.LD01.LD01_NOME_SEGURADO);

            /*" -1411- MOVE OD003-NUM-CNPJ TO LD01-NUM-CNPJ-OD003 . */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ, W_RELATORIOS.LD01.LD01_CNPJ_NUM.LD01_NUM_CNPJ_OD003);

            /*" -1412- MOVE OD003-NUM-FILIAL TO LD01-NUM-FILIAL-OD003 . */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL, W_RELATORIOS.LD01.LD01_CNPJ_NUM.LD01_NUM_FILIAL_OD003);

            /*" -1413- MOVE OD003-NUM-DV-CNPJ TO LD01-DV-CNPJ-OD003 . */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ, W_RELATORIOS.LD01.LD01_CNPJ_NUM.LD01_DV_CNPJ_OD003);

            /*" -1414- MOVE '/' TO LD01-FILLER2. */
            _.Move("/", W_RELATORIOS.LD01.LD01_CNPJ_NUM.LD01_FILLER2);

            /*" -1414- MOVE '-' TO LD01-FILLER3. */
            _.Move("-", W_RELATORIOS.LD01.LD01_CNPJ_NUM.LD01_FILLER3);

        }

        [StopWatch]
        /*" R1140-00-SELECT-OD003-DB-SELECT-1 */
        public void R1140_00_SELECT_OD003_DB_SELECT_1()
        {
            /*" -1399- EXEC SQL SELECT NUM_PESSOA , NUM_CNPJ , NUM_FILIAL , NUM_DV_CNPJ , NOM_RAZAO_SOCIAL INTO :OD003-NUM-PESSOA , :OD003-NUM-CNPJ , :OD003-NUM-FILIAL , :OD003-NUM-DV-CNPJ , :OD003-NOM-RAZAO-SOCIAL FROM ODS.OD_PESSOA_JURIDICA WHERE NUM_PESSOA = :GE368-NUM-PESSOA END-EXEC. */

            var r1140_00_SELECT_OD003_DB_SELECT_1_Query1 = new R1140_00_SELECT_OD003_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1140_00_SELECT_OD003_DB_SELECT_1_Query1.Execute(r1140_00_SELECT_OD003_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD003_NUM_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA);
                _.Move(executed_1.OD003_NUM_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ);
                _.Move(executed_1.OD003_NUM_FILIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL);
                _.Move(executed_1.OD003_NUM_DV_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ);
                _.Move(executed_1.OD003_NOM_RAZAO_SOCIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_EXIT*/

        [StopWatch]
        /*" R1200-LE-ENDERECO */
        private void R1200_LE_ENDERECO(bool isPerform = false)
        {
            /*" -1423- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1424- MOVE 'R1200-LE-ENDERECO      ' TO PARAGRAFO. */
            _.Move("R1200-LE-ENDERECO      ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1426- MOVE 'LER ENDERECO           ' TO COMANDO. */
            _.Move("LER ENDERECO           ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1449- PERFORM R1200_LE_ENDERECO_DB_SELECT_1 */

            R1200_LE_ENDERECO_DB_SELECT_1();

            /*" -1452- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1453- PERFORM R1210-TRATAR-ENDERECO THRU R1210-EXIT */

                R1210_TRATAR_ENDERECO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_EXIT*/


                /*" -1455- END-IF */
            }


            /*" -1456- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1457- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -1458- DISPLAY '----------------------------------------' */
                _.Display($"----------------------------------------");

                /*" -1461- DISPLAY 'VA1300B - SELECT ODS.OD_PESSOA_ENDERECO => SQLCODE = ' WS-SQLCODE */
                _.Display($"VA1300B - SELECT ODS.OD_PESSOA_ENDERECO => SQLCODE = {WS_SQLCODE}");

                /*" -1462- DISPLAY 'NUM_OCORR_MOVTO = ' GE368-NUM-OCORR-MOVTO */
                _.Display($"NUM_OCORR_MOVTO = {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO}");

                /*" -1463- DISPLAY 'NUM_PESSOA      = ' GE368-NUM-PESSOA */
                _.Display($"NUM_PESSOA      = {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1464- DISPLAY '----------------------------------------' */
                _.Display($"----------------------------------------");

                /*" -1464- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-LE-ENDERECO-DB-SELECT-1 */
        public void R1200_LE_ENDERECO_DB_SELECT_1()
        {
            /*" -1449- EXEC SQL SELECT X.NOM_LOGRADOURO, X.DES_NUM_IMOVEL, X.DES_COMPL_ENDERECO, X.NOM_BAIRRO, X.NOM_CIDADE, X.COD_CEP, X.COD_UF INTO :OD007-NOM-LOGRADOURO, :OD007-DES-NUM-IMOVEL, :OD007-DES-COMPL-ENDERECO, :OD007-NOM-BAIRRO, :OD007-NOM-CIDADE, :OD007-COD-CEP, :OD007-COD-UF FROM SEGUROS.GE_LEG_PESS_EVENTO E, ODS.OD_PESSOA_ENDERECO X WHERE E.NUM_OCORR_MOVTO = :GE368-NUM-OCORR-MOVTO AND E.IND_ENTIDADE = 1 AND X.NUM_PESSOA = E.NUM_PESSOA AND X.SEQ_ENDERECO = E.SEQ_ENTIDADE END-EXEC. */

            var r1200_LE_ENDERECO_DB_SELECT_1_Query1 = new R1200_LE_ENDERECO_DB_SELECT_1_Query1()
            {
                GE368_NUM_OCORR_MOVTO = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R1200_LE_ENDERECO_DB_SELECT_1_Query1.Execute(r1200_LE_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD007_NOM_LOGRADOURO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
                _.Move(executed_1.OD007_DES_NUM_IMOVEL, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
                _.Move(executed_1.OD007_DES_COMPL_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
                _.Move(executed_1.OD007_NOM_BAIRRO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
                _.Move(executed_1.OD007_NOM_CIDADE, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
                _.Move(executed_1.OD007_COD_CEP, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
                _.Move(executed_1.OD007_COD_UF, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

        [StopWatch]
        /*" R1210-TRATAR-ENDERECO */
        private void R1210_TRATAR_ENDERECO(bool isPerform = false)
        {
            /*" -1471- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1472- MOVE 'R1210-TRATA-ENDERECO   ' TO PARAGRAFO. */
            _.Move("R1210-TRATA-ENDERECO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1474- MOVE 'TRATA ENDERECO         ' TO COMANDO. */
            _.Move("TRATA ENDERECO         ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1475- MOVE GE368-NUM-PESSOA TO OD007-NUM-PESSOA */
            _.Move(GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA, OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA);

            /*" -1476- MOVE 1 TO OD007-SEQ-ENDERECO */
            _.Move(1, OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO);

            /*" -1477- MOVE 'C' TO OD007-IND-ENDERECO */
            _.Move("C", OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO);

            /*" -1478- MOVE 'A' TO OD007-STA-ENDERECO */
            _.Move("A", OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO);

            /*" -1480- MOVE 'SCN QUADRA 01 BLOCO A ED. NUMBER ONE 14. ANDAR' TO OD007-NOM-LOGRADOURO */
            _.Move("SCN QUADRA 01 BLOCO A ED. NUMBER ONE 14. ANDAR", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);

            /*" -1481- MOVE SPACES TO OD007-DES-NUM-IMOVEL */
            _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);

            /*" -1482- MOVE SPACES TO OD007-DES-COMPL-ENDERECO */
            _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);

            /*" -1483- MOVE 'ASA NORTE' TO OD007-NOM-BAIRRO */
            _.Move("ASA NORTE", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);

            /*" -1484- MOVE 'BRASILIA' TO OD007-NOM-CIDADE */
            _.Move("BRASILIA", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);

            /*" -1485- MOVE '70711900' TO OD007-COD-CEP */
            _.Move("70711900", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);

            /*" -1486- MOVE 'DF' TO OD007-COD-UF */
            _.Move("DF", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);

            /*" -1487- MOVE 'N' TO OD007-STA-CORRESPONDER */
            _.Move("N", OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER);

            /*" -1489- MOVE 'N' TO OD007-STA-PROPAGANDA */
            _.Move("N", OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA);

            /*" -1505- PERFORM R1210_TRATAR_ENDERECO_DB_INSERT_1 */

            R1210_TRATAR_ENDERECO_DB_INSERT_1();

            /*" -1508- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1509- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -1510- DISPLAY '----------------------------------------' */
                _.Display($"----------------------------------------");

                /*" -1513- DISPLAY 'VA1300B - INSERT ODS.OD_PESSOA_ENDERECO => SQLCODE = ' WS-SQLCODE */
                _.Display($"VA1300B - INSERT ODS.OD_PESSOA_ENDERECO => SQLCODE = {WS_SQLCODE}");

                /*" -1514- DISPLAY 'NUM_PESSOA         = ' OD007-NUM-PESSOA */
                _.Display($"NUM_PESSOA         = {OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA}");

                /*" -1515- DISPLAY 'SEQ_ENDERECO       = ' OD007-SEQ-ENDERECO */
                _.Display($"SEQ_ENDERECO       = {OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO}");

                /*" -1516- DISPLAY 'IND_ENDERECO       = ' OD007-IND-ENDERECO */
                _.Display($"IND_ENDERECO       = {OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO}");

                /*" -1517- DISPLAY 'STA_ENDERECO       = ' OD007-STA-ENDERECO */
                _.Display($"STA_ENDERECO       = {OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO}");

                /*" -1518- DISPLAY 'NOM_LOGRADOURO     = ' OD007-NOM-LOGRADOURO */
                _.Display($"NOM_LOGRADOURO     = {OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO}");

                /*" -1519- DISPLAY 'DES_NUM_IMOVEL     = ' OD007-DES-NUM-IMOVEL */
                _.Display($"DES_NUM_IMOVEL     = {OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL}");

                /*" -1520- DISPLAY 'DES_COMPL_ENDERECO = ' OD007-DES-COMPL-ENDERECO */
                _.Display($"DES_COMPL_ENDERECO = {OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO}");

                /*" -1521- DISPLAY 'NOM_BAIRRO         = ' OD007-NOM-BAIRRO */
                _.Display($"NOM_BAIRRO         = {OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO}");

                /*" -1522- DISPLAY 'NOM_CIDADE         = ' OD007-NOM-CIDADE */
                _.Display($"NOM_CIDADE         = {OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE}");

                /*" -1523- DISPLAY 'COD_CEP            = ' OD007-COD-CEP */
                _.Display($"COD_CEP            = {OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP}");

                /*" -1524- DISPLAY 'COD_UF             = ' OD007-COD-UF */
                _.Display($"COD_UF             = {OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF}");

                /*" -1525- DISPLAY 'STA_CORRESPONDER   = ' OD007-STA-CORRESPONDER */
                _.Display($"STA_CORRESPONDER   = {OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER}");

                /*" -1526- DISPLAY 'STA_PROPAGANDA     = ' OD007-STA-PROPAGANDA */
                _.Display($"STA_PROPAGANDA     = {OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA}");

                /*" -1527- DISPLAY '----------------------------------------' */
                _.Display($"----------------------------------------");

                /*" -1528- GO TO R99999-ROT-ERRO */

                R99999_ROT_ERRO(); //GOTO
                return;

                /*" -1529- END-IF */
            }


            /*" -1529- . */

        }

        [StopWatch]
        /*" R1210-TRATAR-ENDERECO-DB-INSERT-1 */
        public void R1210_TRATAR_ENDERECO_DB_INSERT_1()
        {
            /*" -1505- EXEC SQL INSERT INTO ODS.OD_PESSOA_ENDERECO VALUES ( :OD007-NUM-PESSOA ,:OD007-SEQ-ENDERECO , CURRENT TIMESTAMP ,:OD007-IND-ENDERECO ,:OD007-STA-ENDERECO ,:OD007-NOM-LOGRADOURO ,:OD007-DES-NUM-IMOVEL ,:OD007-DES-COMPL-ENDERECO ,:OD007-NOM-BAIRRO ,:OD007-NOM-CIDADE ,:OD007-COD-CEP ,:OD007-COD-UF ,:OD007-STA-CORRESPONDER ,:OD007-STA-PROPAGANDA ) END-EXEC */

            var r1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1 = new R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1()
            {
                OD007_NUM_PESSOA = OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA.ToString(),
                OD007_SEQ_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO.ToString(),
                OD007_IND_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO.ToString(),
                OD007_STA_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO.ToString(),
                OD007_NOM_LOGRADOURO = OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO.ToString(),
                OD007_DES_NUM_IMOVEL = OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL.ToString(),
                OD007_DES_COMPL_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO.ToString(),
                OD007_NOM_BAIRRO = OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO.ToString(),
                OD007_NOM_CIDADE = OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE.ToString(),
                OD007_COD_CEP = OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.ToString(),
                OD007_COD_UF = OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF.ToString(),
                OD007_STA_CORRESPONDER = OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER.ToString(),
                OD007_STA_PROPAGANDA = OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA.ToString(),
            };

            R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1.Execute(r1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_EXIT*/

        [StopWatch]
        /*" R1400-00-SEGMENTO-A */
        private void R1400_00_SEGMENTO_A(bool isPerform = false)
        {
            /*" -1537- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1538- MOVE 'R1400-00-SEGMENTO-A    ' TO PARAGRAFO. */
            _.Move("R1400-00-SEGMENTO-A    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1540- MOVE 'PROCESSA SEGMENTO A    ' TO COMANDO. */
            _.Move("PROCESSA SEGMENTO A    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1542- MOVE SPACES TO DETSEGA-REGISTRO. */
            _.Move("", DETSEGA_REGISTRO);

            /*" -1544- ADD 1 TO AC-NRSEQ AC-QTDREGLOT AC-QTDREGARQ. */
            W_AREAS_CB1061B.AC_NRSEQ.Value = W_AREAS_CB1061B.AC_NRSEQ + 1;
            W_AREAS_CB1061B.AC_QTDREGLOT.Value = W_AREAS_CB1061B.AC_QTDREGLOT + 1;
            W_AREAS_CB1061B.AC_QTDREGARQ.Value = W_AREAS_CB1061B.AC_QTDREGARQ + 1;

            /*" -1545- MOVE 001 TO DETSEGA-BANCO. */
            _.Move(001, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_BANCO);

            /*" -1546- MOVE AC-QTDLOTE TO DETSEGA-LOTSER. */
            _.Move(W_AREAS_CB1061B.AC_QTDLOTE, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_LOTSER);

            /*" -1547- MOVE 3 TO DETSEGA-TIPOREG. */
            _.Move(3, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_TIPOREG);

            /*" -1548- MOVE AC-NRSEQ TO DETSEGA-NUMREG. */
            _.Move(W_AREAS_CB1061B.AC_NRSEQ, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_NUMREG);

            /*" -1549- MOVE 'A' TO DETSEGA-SEGMENTO. */
            _.Move("A", DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_SEGMENTO);

            /*" -1550- MOVE ZEROS TO DETSEGA-TIPOMOV. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_MOVIMENTO.DETSEGA_TIPOMOV);

            /*" -1551- MOVE ZEROS TO DETSEGA-INSTRUCAO. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_MOVIMENTO.DETSEGA_INSTRUCAO);

            /*" -1553- MOVE 018 TO DETSEGA-CAMARA. */
            _.Move(018, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CAMARA);

            /*" -1554- MOVE OD009-COD-BANCO TO DETSEGA-BANCOFAV */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_BANCOFAV);

            /*" -1556- MOVE OD009-COD-AGENCIA TO DETSEGA-AGECONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

            /*" -1557- IF OD009-COD-BANCO EQUAL 001 */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO == 001)
            {

                /*" -1558- PERFORM R1410-00-CALCULA-DV-BB THRU R1410-EXIT */

                R1410_00_CALCULA_DV_BB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_EXIT*/


                /*" -1560- MOVE WS-DV-BB-X TO DETSEGA-DIGAGENC. */
                _.Move(W_AREAS_CB1061B.WS_DV_BB_X, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGAGENC);
            }


            /*" -1561- IF OD009-COD-BANCO EQUAL 104 */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO == 104)
            {

                /*" -1562- MOVE OD009-NUM-OPERACAO-CONTA TO WS-OPERACAO */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, WORK_AREA.FILLER_10.WS_OPERACAO);

                /*" -1563- MOVE OD009-NUM-CONTA TO WS-NUMCONTA */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, WORK_AREA.FILLER_10.WS_NUMCONTA);

                /*" -1564- MOVE WS-NUMERO TO DETSEGA-NUMCONTA */
                _.Move(WORK_AREA.WS_NUMERO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_NUMCONTA);

                /*" -1565- ELSE */
            }
            else
            {


                /*" -1567- MOVE OD009-NUM-CONTA TO DETSEGA-NUMCONTA. */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_NUMCONTA);
            }


            /*" -1570- MOVE OD009-NUM-DV-CONTA TO WS-DIGCTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA, WORK_AREA.WS_DIGCTA);

            /*" -1571- IF WS-DIGCTA1 NOT EQUAL SPACES */

            if (!WORK_AREA.FILLER_9.WS_DIGCTA1.IsEmpty())
            {

                /*" -1572- MOVE WS-DIGCTA1 TO DETSEGA-DIGCONTA */
                _.Move(WORK_AREA.FILLER_9.WS_DIGCTA1, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                /*" -1574- ELSE */
            }
            else
            {


                /*" -1575- IF WS-DIGCTA2 NOT EQUAL SPACES */

                if (!WORK_AREA.FILLER_9.WS_DIGCTA2.IsEmpty())
                {

                    /*" -1576- MOVE WS-DIGCTA2 TO DETSEGA-DIGCONTA */
                    _.Move(WORK_AREA.FILLER_9.WS_DIGCTA2, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                    /*" -1577- END-IF */
                }


                /*" -1579- END-IF */
            }


            /*" -1580- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -1581- MOVE OD002-NOM-PESSOA-TEXT TO DETSEGA-NOMEFAV */
                _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

                /*" -1582- ELSE */
            }
            else
            {


                /*" -1584- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO DETSEGA-NOMEFAV. */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);
            }


            /*" -1585- MOVE OD009-NUM-PESSOA TO DETSEGA-NUMPESSOA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NUMPESSOA);

            /*" -1587- MOVE OD009-SEQ-CONTA-BANCARIA TO DETSEGA-SEQCTABANC. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_SEQCTABANC);

            /*" -1588- MOVE ZEROS TO DETSEGA-NRSEQ01. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NROEMPRE.DETSEGA_NRSEQ01);

            /*" -1590- MOVE GE368-NUM-OCORR-MOVTO TO DETSEGA-NRSEQ02. */
            _.Move(GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NROEMPRE.DETSEGA_NRSEQ02);

            /*" -1591- MOVE REG-SORT-DATA-VENCIMENTO(9:2) TO DETSEGA-DIAPAG. */
            _.Move(REG_SORTWK01.REG_SORT_DATA_VENCIMENTO.Substring(9, 2), DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_DIAPAG);

            /*" -1592- MOVE REG-SORT-DATA-VENCIMENTO(6:2) TO DETSEGA-MESPAG. */
            _.Move(REG_SORTWK01.REG_SORT_DATA_VENCIMENTO.Substring(6, 2), DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_MESPAG);

            /*" -1594- MOVE REG-SORT-DATA-VENCIMENTO(1:4) TO DETSEGA-ANOPAG. */
            _.Move(REG_SORTWK01.REG_SORT_DATA_VENCIMENTO.Substring(1, 4), DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_ANOPAG);

            /*" -1595- MOVE 'BRL' TO DETSEGA-TIPOMOEDA. */
            _.Move("BRL", DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_MOEDA.DETSEGA_TIPOMOEDA);

            /*" -1596- MOVE ZEROS TO DETSEGA-QTDEMOEDA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_MOEDA.DETSEGA_QTDEMOEDA);

            /*" -1598- MOVE HISLANCT-PRM-TOTAL TO DETSEGA-VALPAGTO. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALPAGTO);

            /*" -1600- ADD HISLANCT-PRM-TOTAL TO AC-VLRTOTCRE AC-VLRTOTAL. */
            W_AREAS_CB1061B.AC_VLRTOTCRE.Value = W_AREAS_CB1061B.AC_VLRTOTCRE + HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL;
            W_AREAS_CB1061B.AC_VLRTOTAL.Value = W_AREAS_CB1061B.AC_VLRTOTAL + HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL;

            /*" -1602- MOVE ZEROS TO DETSEGA-DIAREA DETSEGA-MESREA DETSEGA-ANOREA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_DIAREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_MESREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_ANOREA);

            /*" -1603- MOVE ZEROS TO DETSEGA-VALREAL. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALREAL);

            /*" -1608- MOVE ZEROS TO DETSEGA-AVISO. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_AVISO);

            /*" -1609- MOVE ZEROS TO DETSEGA-IDENTIFICA-VIDA1 */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_IDENTIFICA_VIDA1);

            /*" -1611- MOVE HISLANCT-NUM-CERTIFICADO TO DETSEGA-NUM-CERTIFICADO-VIDA1. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, DETSEGA_REGISTRO.DETSEGA_IDENTIFICA_VIDA1.DETSEGA_NUM_CERTIFICADO_VIDA1);

            /*" -1613- MOVE HISLANCT-NUM-PARCELA TO DETSEGA-NUM-PARCELA-VIDA1. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, DETSEGA_REGISTRO.DETSEGA_IDENTIFICA_VIDA1.DETSEGA_NUM_PARCELA_VIDA1);

            /*" -1615- MOVE VG079-NUM-OCORR-MOVTO TO DETSEGA-NUM-OCORR-MOVTO-VIDA1. */
            _.Move(VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO, DETSEGA_REGISTRO.DETSEGA_IDENTIFICA_VIDA1.DETSEGA_NUM_OCORR_MOVTO_VIDA1);

            /*" -1618- MOVE ZEROS TO DETSEGA-NUM-TITULO-VIDA1. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_IDENTIFICA_VIDA1.DETSEGA_NUM_TITULO_VIDA1);

            /*" -1620- MOVE DETSEGA-REGISTRO TO REG-MOV1313 */
            _.Move(DETSEGA_REGISTRO, REG_MOV1313);

            /*" -1620- WRITE REG-MOV1313. */
            SAIDA.Write(REG_MOV1313.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/

        [StopWatch]
        /*" R1410-00-CALCULA-DV-BB */
        private void R1410_00_CALCULA_DV_BB(bool isPerform = false)
        {
            /*" -1629- MOVE '1410' TO WNR-EXEC-SQL. */
            _.Move("1410", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1630- MOVE 'R1410-00-CALCULA-DV-BB ' TO PARAGRAFO. */
            _.Move("R1410-00-CALCULA-DV-BB ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1632- MOVE 'CALCULA DV BB          ' TO COMANDO. */
            _.Move("CALCULA DV BB          ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1635- MOVE OD009-COD-AGENCIA TO WS-AGENCIA-BB */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, W_AREAS_CB1061B.WS_AGENCIA_BB);

            /*" -1641- COMPUTE WVALOR-AUX = LAGEN01-1 * 5 + LAGEN01-2 * 4 + LAGEN01-3 * 3 + LAGEN01-4 * 2 */
            WORK_AREA.WVALOR_AUX.Value = W_AREAS_CB1061B.FILLER_98.LAGEN01_1 * 5 + W_AREAS_CB1061B.FILLER_98.LAGEN01_2 * 4 + W_AREAS_CB1061B.FILLER_98.LAGEN01_3 * 3 + W_AREAS_CB1061B.FILLER_98.LAGEN01_4 * 2;

            /*" -1645- DIVIDE WVALOR-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(WORK_AREA.WVALOR_AUX, 11, WORK_AREA.WQUOCIENTE, WORK_AREA.WRESTO);

            /*" -1646- IF WRESTO EQUAL 0 */

            if (WORK_AREA.WRESTO == 0)
            {

                /*" -1647- MOVE '0' TO WS-DV-BB-X */
                _.Move("0", W_AREAS_CB1061B.WS_DV_BB_X);

                /*" -1648- ELSE */
            }
            else
            {


                /*" -1649- IF WRESTO EQUAL 1 */

                if (WORK_AREA.WRESTO == 1)
                {

                    /*" -1650- MOVE 'X' TO WS-DV-BB-X */
                    _.Move("X", W_AREAS_CB1061B.WS_DV_BB_X);

                    /*" -1651- ELSE */
                }
                else
                {


                    /*" -1651- SUBTRACT WRESTO FROM 11 GIVING WS-DV-BB. */
                    W_AREAS_CB1061B.WS_DV_BB.Value = 11 - WORK_AREA.WRESTO;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_EXIT*/

        [StopWatch]
        /*" R1500-00-SEGMENTO-B */
        private void R1500_00_SEGMENTO_B(bool isPerform = false)
        {
            /*" -1660- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1661- MOVE 'R1500-00-SEGMENTO-B    ' TO PARAGRAFO. */
            _.Move("R1500-00-SEGMENTO-B    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1664- MOVE 'PROCESSA SEGMENTO B    ' TO COMANDO. */
            _.Move("PROCESSA SEGMENTO B    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1668- ADD 1 TO AC-NRSEQ AC-QTDREGLOT AC-QTDREGARQ. */
            W_AREAS_CB1061B.AC_NRSEQ.Value = W_AREAS_CB1061B.AC_NRSEQ + 1;
            W_AREAS_CB1061B.AC_QTDREGLOT.Value = W_AREAS_CB1061B.AC_QTDREGLOT + 1;
            W_AREAS_CB1061B.AC_QTDREGARQ.Value = W_AREAS_CB1061B.AC_QTDREGARQ + 1;

            /*" -1671- MOVE SPACES TO DETSEGB-REGISTRO. */
            _.Move("", DETSEGB_REGISTRO);

            /*" -1673- MOVE 001 TO DETSEGB-BANCO. */
            _.Move(001, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_BANCO);

            /*" -1675- MOVE AC-QTDLOTE TO DETSEGB-LOTSER. */
            _.Move(W_AREAS_CB1061B.AC_QTDLOTE, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_LOTSER);

            /*" -1677- MOVE 3 TO DETSEGB-TIPOREG. */
            _.Move(3, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_TIPOREG);

            /*" -1679- MOVE AC-NRSEQ TO DETSEGB-NUMREG. */
            _.Move(W_AREAS_CB1061B.AC_NRSEQ, DETSEGB_REGISTRO.DETSEGB_SERVICO.DETSEGB_NUMREG);

            /*" -1682- MOVE 'B' TO DETSEGB-SEGMENTO. */
            _.Move("B", DETSEGB_REGISTRO.DETSEGB_SERVICO.DETSEGB_SEGMENTO);

            /*" -1683- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -1685- MOVE 1 TO DETSEGB-TIPINSC */
                _.Move(1, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);

                /*" -1687- MOVE OD002-NUM-CPF TO WS-NUM-CPF */
                _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, WORK_AREA.FILLER_4.WS_NUM_CPF);

                /*" -1689- MOVE OD002-NUM-DV-CPF TO WS-DIG-CPF */
                _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, WORK_AREA.FILLER_4.WS_DIG_CPF);

                /*" -1691- MOVE WS-CPF TO DETSEGB-NROINSC */
                _.Move(WORK_AREA.WS_CPF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_NROINSC);

                /*" -1692- ELSE */
            }
            else
            {


                /*" -1694- MOVE 2 TO DETSEGB-TIPINSC */
                _.Move(2, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);

                /*" -1696- MOVE OD003-NUM-CNPJ TO WS-NUM-CNPJ */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ, WORK_AREA.FILLER_5.WS_NUM_CNPJ);

                /*" -1698- MOVE OD003-NUM-FILIAL TO WS-NUM-FILIAL */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL, WORK_AREA.FILLER_5.WS_NUM_FILIAL);

                /*" -1700- MOVE OD003-NUM-DV-CNPJ TO WS-DIG-CNPJ */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ, WORK_AREA.FILLER_5.WS_DIG_CNPJ);

                /*" -1703- MOVE WS-CNPJ TO DETSEGB-NROINSC. */
                _.Move(WORK_AREA.WS_CNPJ, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_NROINSC);
            }


            /*" -1705- MOVE OD007-NOM-LOGRADOURO TO DETSEGB-LOGRADOURO. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_LOGRADOURO);

            /*" -1707- MOVE ZEROS TO DETSEGB-NUMERO. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_NUMERO);

            /*" -1709- MOVE OD007-DES-COMPL-ENDERECO TO DETSEGB-COMPLOGRA. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_COMPLOGRA);

            /*" -1711- MOVE OD007-NOM-BAIRRO TO DETSEGB-BAIRRO. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_BAIRRO);

            /*" -1713- MOVE OD007-NOM-CIDADE TO DETSEGB-CIDADE. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CIDADE);

            /*" -1715- MOVE OD007-COD-CEP TO DETSEGB-CEP. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CEP);

            /*" -1718- MOVE OD007-COD-UF TO DETSEGB-SIGLAUF. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_SIGLAUF);

            /*" -1720- MOVE DETSEGA-DIAPAG TO DETSEGB-DIAVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_DIAPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_DIAVEN);

            /*" -1722- MOVE DETSEGA-MESPAG TO DETSEGB-MESVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_MESPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_MESVEN);

            /*" -1724- MOVE DETSEGA-ANOPAG TO DETSEGB-ANOVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_ANOPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_ANOVEN);

            /*" -1726- MOVE DETSEGA-VALPAGTO TO DETSEGB-VALNOMIN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALPAGTO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALNOMIN);

            /*" -1732- MOVE ZEROS TO DETSEGB-VALABAT DETSEGB-VALDESC DETSEGB-VALMORA DETSEGB-VALMULTA. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALABAT, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALDESC, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALMORA, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALMULTA);

            /*" -1734- MOVE DETSEGB-REGISTRO TO REG-MOV1313 */
            _.Move(DETSEGB_REGISTRO, REG_MOV1313);

            /*" -1734- WRITE REG-MOV1313. */
            SAIDA.Write(REG_MOV1313.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/

        [StopWatch]
        /*" R3000-00-HEADER-ARQUIVO */
        private void R3000_00_HEADER_ARQUIVO(bool isPerform = false)
        {
            /*" -1744- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1745- MOVE 'R3000-00-HEADER-ARQU   ' TO PARAGRAFO. */
            _.Move("R3000-00-HEADER-ARQU   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1747- MOVE 'WRITE HEADER           ' TO COMANDO. */
            _.Move("WRITE HEADER           ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1749- ADD 1 TO AC-QTDREGARQ. */
            W_AREAS_CB1061B.AC_QTDREGARQ.Value = W_AREAS_CB1061B.AC_QTDREGARQ + 1;

            /*" -1752- MOVE SPACES TO ARQHEA-REGISTRO. */
            _.Move("", ARQHEA_REGISTRO);

            /*" -1754- MOVE 001 TO ARQHEA-BANCO. */
            _.Move(001, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_BANCO);

            /*" -1756- MOVE ZEROS TO ARQHEA-LOTSER. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_LOTSER);

            /*" -1758- MOVE ZEROS TO ARQHEA-TIPOREG. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_TIPOREG);

            /*" -1760- MOVE 2 TO ARQHEA-TIPINSC. */
            _.Move(2, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_INSCRICAO.ARQHEA_TIPINSC);

            /*" -1762- MOVE 34020354000110 TO ARQHEA-NROINSC. */
            _.Move(34020354000110, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_INSCRICAO.ARQHEA_NROINSC);

            /*" -1764- MOVE '00000000000000001313' TO ARQHEA-CONVENIO. */
            _.Move("00000000000000001313", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONVENIO);

            /*" -1766- MOVE 03307 TO ARQHEA-AGECONTA. */
            _.Move(03307, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_AGECONTA);

            /*" -1768- MOVE '3' TO ARQHEA-DIGAGENC. */
            _.Move("3", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGAGENC);

            /*" -1770- MOVE 000000069498 TO ARQHEA-NUMCONTA. */
            _.Move(000000069498, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_NUMCONTA);

            /*" -1772- MOVE '3' TO ARQHEA-DIGCONTA. */
            _.Move("3", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGCONTA);

            /*" -1774- MOVE SPACES TO ARQHEA-DIGAGECTA. */
            _.Move("", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGAGECTA);

            /*" -1776- MOVE 'CAIXA SEGURADORA SA' TO ARQHEA-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_NOMEMPRESA);

            /*" -1778- MOVE 'BANCO DO BRASIL    ' TO ARQHEA-NOMEBANCO. */
            _.Move("BANCO DO BRASIL    ", ARQHEA_REGISTRO.ARQHEA_NOMEBANCO);

            /*" -1781- MOVE 1 TO ARQHEA-REMESSA. */
            _.Move(1, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_REMESSA);

            /*" -1783- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.WDATA_REL);

            /*" -1785- MOVE WDAT-REL-DIA TO ARQHEA-DIAGERA. */
            _.Move(WORK_AREA.FILLER_6.WDAT_REL_DIA, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_DIAGERA);

            /*" -1787- MOVE WDAT-REL-MES TO ARQHEA-MESGERA. */
            _.Move(WORK_AREA.FILLER_6.WDAT_REL_MES, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_MESGERA);

            /*" -1790- MOVE WDAT-REL-ANO TO ARQHEA-ANOGERA. */
            _.Move(WORK_AREA.FILLER_6.WDAT_REL_ANO, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_ANOGERA);

            /*" -1791- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WHORA_CURR);

            /*" -1793- MOVE WHORA-HH-CURR TO ARQHEA-HORGERA. */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_HH_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_HORGERA);

            /*" -1795- MOVE WHORA-MM-CURR TO ARQHEA-MINGERA. */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_MM_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_MINGERA);

            /*" -1801- MOVE WHORA-SS-CURR TO ARQHEA-SEGGERA. */
            _.Move(WORK_AREA.WHORA_CURR.WHORA_SS_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_SEGGERA);

            /*" -1804- MOVE MOV-OUTROBC-NSA TO ARQHEA-NSA. */
            _.Move(MOV_OUTROS_BANCOS.MOV_OUTROBC_NSA, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_NSA);

            /*" -1806- MOVE 030 TO ARQHEA-VERSAO. */
            _.Move(030, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_VERSAO);

            /*" -1808- MOVE ZEROS TO ARQHEA-DENSIDADE. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DENSIDADE);

            /*" -1812- MOVE 'ENVIO SEGURADORA    ' TO ARQHEA-USOEMPRESA. */
            _.Move("ENVIO SEGURADORA    ", ARQHEA_REGISTRO.ARQHEA_USOEMPRESA);

            /*" -1814- MOVE ARQHEA-REGISTRO TO REG-MOV1313. */
            _.Move(ARQHEA_REGISTRO, REG_MOV1313);

            /*" -1814- WRITE REG-MOV1313. */
            SAIDA.Write(REG_MOV1313.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/

        [StopWatch]
        /*" R3100-00-TRAILLER-ARQUIVO */
        private void R3100_00_TRAILLER_ARQUIVO(bool isPerform = false)
        {
            /*" -1823- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1824- MOVE 'R3100-00-TRAILLER-ARQ  ' TO PARAGRAFO. */
            _.Move("R3100-00-TRAILLER-ARQ  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1826- MOVE 'WRITE TRAILLER         ' TO COMANDO. */
            _.Move("WRITE TRAILLER         ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1828- ADD 1 TO AC-QTDREGARQ. */
            W_AREAS_CB1061B.AC_QTDREGARQ.Value = W_AREAS_CB1061B.AC_QTDREGARQ + 1;

            /*" -1829- MOVE SPACES TO ARQTRA-REGISTRO. */
            _.Move("", ARQTRA_REGISTRO);

            /*" -1830- MOVE 001 TO ARQTRA-BANCO. */
            _.Move(001, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_BANCO);

            /*" -1831- MOVE 9999 TO ARQTRA-LOTSER. */
            _.Move(9999, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_LOTSER);

            /*" -1832- MOVE 9 TO ARQTRA-TIPOREG. */
            _.Move(9, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_TIPOREG);

            /*" -1833- MOVE AC-QTDLOTE TO ARQTRA-QTDELOTE */
            _.Move(W_AREAS_CB1061B.AC_QTDLOTE, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDELOTE);

            /*" -1834- MOVE AC-QTDREGARQ TO ARQTRA-QTDEREG. */
            _.Move(W_AREAS_CB1061B.AC_QTDREGARQ, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDEREG);

            /*" -1835- MOVE ZEROS TO ARQTRA-QTDECONTA. */
            _.Move(0, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDECONTA);

            /*" -1837- MOVE ARQTRA-REGISTRO TO REG-MOV1313. */
            _.Move(ARQTRA_REGISTRO, REG_MOV1313);

            /*" -1837- WRITE REG-MOV1313. */
            SAIDA.Write(REG_MOV1313.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/

        [StopWatch]
        /*" R3200-00-HEADER-LOTE */
        private void R3200_00_HEADER_LOTE(bool isPerform = false)
        {
            /*" -1845- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1846- MOVE 'R3200-00-HEADER-LOTE   ' TO PARAGRAFO. */
            _.Move("R3200-00-HEADER-LOTE   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1848- MOVE 'WRITE REGISTRO         ' TO COMANDO. */
            _.Move("WRITE REGISTRO         ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1850- ADD 1 TO AC-QTDLOTE AC-QTDREGLOT AC-QTDREGARQ. */
            W_AREAS_CB1061B.AC_QTDLOTE.Value = W_AREAS_CB1061B.AC_QTDLOTE + 1;
            W_AREAS_CB1061B.AC_QTDREGLOT.Value = W_AREAS_CB1061B.AC_QTDREGLOT + 1;
            W_AREAS_CB1061B.AC_QTDREGARQ.Value = W_AREAS_CB1061B.AC_QTDREGARQ + 1;

            /*" -1851- MOVE SPACES TO LOTHEA-REGISTRO. */
            _.Move("", LOTHEA_REGISTRO);

            /*" -1852- MOVE 001 TO LOTHEA-BANCO. */
            _.Move(001, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_BANCO);

            /*" -1853- MOVE AC-QTDLOTE TO LOTHEA-LOTSER. */
            _.Move(W_AREAS_CB1061B.AC_QTDLOTE, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_LOTSER);

            /*" -1854- MOVE 1 TO LOTHEA-TIPOREG. */
            _.Move(1, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_TIPOREG);

            /*" -1855- MOVE 'C' TO LOTHEA-OPERACAO. */
            _.Move("C", LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_OPERACAO);

            /*" -1856- MOVE 98 TO LOTHEA-TIPSER. */
            _.Move(98, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_TIPSER);

            /*" -1858- MOVE 020 TO LOTHEA-VERSAO. */
            _.Move(020, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_VERSAO);

            /*" -1859- IF W-CHAVE-LOTE-BANCO-BRASIL EQUAL 'SIM' */

            if (W_CHAVE_LOTE_BANCO_BRASIL == "SIM")
            {

                /*" -1860- MOVE 01 TO LOTHEA-FORMA */
                _.Move(01, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_FORMA);

                /*" -1861- ELSE */
            }
            else
            {


                /*" -1863- MOVE 03 TO LOTHEA-FORMA. */
                _.Move(03, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_FORMA);
            }


            /*" -1864- MOVE 2 TO LOTHEA-TIPINSC. */
            _.Move(2, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_INSCRICAO.LOTHEA_TIPINSC);

            /*" -1865- MOVE 34020354000110 TO LOTHEA-NROINSC. */
            _.Move(34020354000110, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_INSCRICAO.LOTHEA_NROINSC);

            /*" -1866- MOVE '00000000000000001313' TO LOTHEA-CONVENIO. */
            _.Move("00000000000000001313", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONVENIO);

            /*" -1867- MOVE 03307 TO LOTHEA-AGECONTA. */
            _.Move(03307, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_AGECONTA);

            /*" -1868- MOVE '3' TO LOTHEA-DIGAGENC. */
            _.Move("3", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGAGENC);

            /*" -1869- MOVE 000000069498 TO LOTHEA-NUMCONTA. */
            _.Move(000000069498, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_NUMCONTA);

            /*" -1870- MOVE '3' TO LOTHEA-DIGCONTA. */
            _.Move("3", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGCONTA);

            /*" -1871- MOVE SPACES TO LOTHEA-DIGAGECTA. */
            _.Move("", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGAGECTA);

            /*" -1872- MOVE 'CAIXA SEGURADORA SA' TO LOTHEA-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_NOMEMPRESA);

            /*" -1874- MOVE 'SCN - QUADRA 01 - BLOCO A     ' TO LOTHEA-LOGRADOURO. */
            _.Move("SCN - QUADRA 01 - BLOCO A     ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_LOGRADOURO);

            /*" -1875- MOVE 00001 TO LOTHEA-NUMERO. */
            _.Move(00001, LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_NUMERO);

            /*" -1876- MOVE 'ED. NUMBER ONE ' TO LOTHEA-COMPLOGRA. */
            _.Move("ED. NUMBER ONE ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_COMPLOGRA);

            /*" -1877- MOVE 'BRASILIA            ' TO LOTHEA-CIDADE. */
            _.Move("BRASILIA            ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_CIDADE);

            /*" -1878- MOVE 70710 TO LOTHEA-CEP. */
            _.Move(70710, LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_CEP);

            /*" -1879- MOVE '500' TO LOTHEA-COMPLCEP. */
            _.Move("500", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_COMPLCEP);

            /*" -1881- MOVE 'DF' TO LOTHEA-SIGLAUF. */
            _.Move("DF", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_SIGLAUF);

            /*" -1883- MOVE LOTHEA-REGISTRO TO REG-MOV1313. */
            _.Move(LOTHEA_REGISTRO, REG_MOV1313);

            /*" -1883- WRITE REG-MOV1313. */
            SAIDA.Write(REG_MOV1313.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/

        [StopWatch]
        /*" R3300-00-TRAILLER-LOTE */
        private void R3300_00_TRAILLER_LOTE(bool isPerform = false)
        {
            /*" -1892- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1893- MOVE ' R3300-00-TRAILLER     ' TO PARAGRAFO. */
            _.Move(" R3300-00-TRAILLER     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1895- MOVE 'SELECT HISTLANCCTA     ' TO COMANDO. */
            _.Move("SELECT HISTLANCCTA     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1897- ADD 1 TO AC-QTDREGLOT AC-QTDREGARQ. */
            W_AREAS_CB1061B.AC_QTDREGLOT.Value = W_AREAS_CB1061B.AC_QTDREGLOT + 1;
            W_AREAS_CB1061B.AC_QTDREGARQ.Value = W_AREAS_CB1061B.AC_QTDREGARQ + 1;

            /*" -1898- MOVE SPACES TO LOTTRA-REGISTRO. */
            _.Move("", LOTTRA_REGISTRO);

            /*" -1899- MOVE 001 TO LOTTRA-BANCO. */
            _.Move(001, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_BANCO);

            /*" -1900- MOVE AC-QTDLOTE TO LOTTRA-LOTSER. */
            _.Move(W_AREAS_CB1061B.AC_QTDLOTE, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_LOTSER);

            /*" -1901- MOVE 5 TO LOTTRA-TIPOREG. */
            _.Move(5, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_TIPOREG);

            /*" -1902- MOVE AC-QTDREGLOT TO LOTTRA-QTDEREG */
            _.Move(W_AREAS_CB1061B.AC_QTDREGLOT, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_QTDEREG);

            /*" -1903- MOVE AC-VLRTOTCRE TO LOTTRA-VALOR. */
            _.Move(W_AREAS_CB1061B.AC_VLRTOTCRE, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_VALOR);

            /*" -1904- MOVE ZEROS TO LOTTRA-QTDEMOEDA. */
            _.Move(0, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_QTDEMOEDA);

            /*" -1906- MOVE ZEROS TO LOTTRA-NRAVISO. */
            _.Move(0, LOTTRA_REGISTRO.LOTTRA_NRAVISO);

            /*" -1908- MOVE LOTTRA-REGISTRO TO REG-MOV1313. */
            _.Move(LOTTRA_REGISTRO, REG_MOV1313);

            /*" -1908- WRITE REG-MOV1313. */
            SAIDA.Write(REG_MOV1313.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/

        [StopWatch]
        /*" R10000-GRAVA-RELATORIOS */
        private void R10000_GRAVA_RELATORIOS(bool isPerform = false)
        {
            /*" -1917- MOVE '10000' TO WNR-EXEC-SQL. */
            _.Move("10000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1918- MOVE 'R1000-GRAVA-RELATOR' TO PARAGRAFO. */
            _.Move("R1000-GRAVA-RELATOR", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1923- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1966- PERFORM R10000_GRAVA_RELATORIOS_DB_INSERT_1 */

            R10000_GRAVA_RELATORIOS_DB_INSERT_1();

            /*" -1969- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1970- DISPLAY 'VA1300B - PROBLEMAS NA INCLUSAO VA0473B' */
                _.Display($"VA1300B - PROBLEMAS NA INCLUSAO VA0473B");

                /*" -1970- GO TO R99999-ROT-ERRO. */

                R99999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R10000-GRAVA-RELATORIOS-DB-INSERT-1 */
        public void R10000_GRAVA_RELATORIOS_DB_INSERT_1()
        {
            /*" -1966- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA1300B' , :HOST-CURRENT-DATE, 'VA' , 'VA0473B' , :PARM-NSA, 0, :HOST-CURRENT-DATE, :HOST-CURRENT-DATE, :HOST-CURRENT-DATE, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 = new R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1()
            {
                HOST_CURRENT_DATE = HOST_CURRENT_DATE.ToString(),
                PARM_NSA = PARM_NSA.ToString(),
            };

            R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1.Execute(r10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/

        [StopWatch]
        /*" R1900-IMPRIME-RELAT */
        private void R1900_IMPRIME_RELAT(bool isPerform = false)
        {
            /*" -1980- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1980- WRITE REG-RELAT FROM LD01. */
            _.Move(W_RELATORIOS.LD01.GetMoveValues(), REG_RELAT);

            RELAT.Write(REG_RELAT.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/

        [StopWatch]
        /*" R300-SELECT-HISLANCT */
        private void R300_SELECT_HISLANCT(bool isPerform = false)
        {
            /*" -1989- MOVE 'R300' TO WNR-EXEC-SQL. */
            _.Move("R300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1990- MOVE 'R300-SELECT-HISTLAN    ' TO PARAGRAFO. */
            _.Move("R300-SELECT-HISTLAN    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1992- MOVE 'SELECT HISTLANCCTA     ' TO COMANDO. */
            _.Move("SELECT HISTLANCCTA     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2059- PERFORM R300_SELECT_HISLANCT_DB_SELECT_1 */

            R300_SELECT_HISLANCT_DB_SELECT_1();

            /*" -2062- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2063- DISPLAY 'VA1300B - ERRO LEITURA HISLANCT' */
                _.Display($"VA1300B - ERRO LEITURA HISLANCT");

                /*" -2064- DISPLAY 'NUM_OCORR_MOVTO     = ' VG079-NUM-OCORR-MOVTO */
                _.Display($"NUM_OCORR_MOVTO     = {VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO}");

                /*" -2065- DISPLAY 'NUM_CERTIFICADO     = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -2066- DISPLAY 'NUM_PARCELA         = ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM_PARCELA         = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -2067- DISPLAY 'NUM_TITULO          = ' COBHISVI-NUM-TITULO */
                _.Display($"NUM_TITULO          = {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO}");

                /*" -2068- DISPLAY 'NSAS                = ' HISLANCT-NSAS */
                _.Display($"NSAS                = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS}");

                /*" -2069- DISPLAY 'NUM_PESSOA          = ' GE368-NUM-PESSOA */
                _.Display($"NUM_PESSOA          = {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -2070- DISPLAY 'SQLCODE             = ' SQLCODE */
                _.Display($"SQLCODE             = {DB.SQLCODE}");

                /*" -2071- GO TO R99999-ROT-ERRO */

                R99999_ROT_ERRO(); //GOTO
                return;

                /*" -2071- END-IF. */
            }


        }

        [StopWatch]
        /*" R300-SELECT-HISLANCT-DB-SELECT-1 */
        public void R300_SELECT_HISLANCT_DB_SELECT_1()
        {
            /*" -2059- EXEC SQL SELECT H.NUM_CERTIFICADO, H.NUM_PARCELA, C.NUM_TITULO, H.PRM_TOTAL, H.SIT_REGISTRO, H.DATA_VENCIMENTO, H.NSAS, H.NSL, H.CODCONV, P.NUM_OCORR_MOVTO, B.COD_BANCO, B.COD_AGENCIA, B.NUM_CONTA, B.NUM_DV_CONTA, B.NUM_OPERACAO_CONTA, B.NUM_PESSOA, B.SEQ_CONTA_BANCARIA, E.NUM_OCORR_MOVTO, E.NUM_PESSOA INTO :HISLANCT-NUM-CERTIFICADO, :HISLANCT-NUM-PARCELA, :COBHISVI-NUM-TITULO, :HISLANCT-PRM-TOTAL, :HISLANCT-SIT-REGISTRO, :HISLANCT-DATA-VENCIMENTO, :HISLANCT-NSAS:SQL-MAYBE-NULL1, :HISLANCT-NSL:SQL-MAYBE-NULL2, :HISLANCT-CODCONV, :VG079-NUM-OCORR-MOVTO, :OD009-COD-BANCO, :OD009-COD-AGENCIA, :OD009-NUM-CONTA, :OD009-NUM-DV-CONTA, :OD009-NUM-OPERACAO-CONTA, :OD009-NUM-PESSOA, :OD009-SEQ-CONTA-BANCARIA, :GE368-NUM-OCORR-MOVTO, :GE368-NUM-PESSOA FROM SEGUROS.VG_PESS_PARCELA P, SEGUROS.GE_MOVIMENTO M, SEGUROS.GE_LEG_PESS_EVENTO E, ODS.OD_PESS_CONTA_BANC B, SEGUROS.HIST_LANC_CTA H, SEGUROS.COBER_HIST_VIDAZUL C WHERE P.NUM_OCORR_MOVTO = :VG079-NUM-OCORR-MOVTO AND P.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND P.NUM_PARCELA = :HISLANCT-NUM-PARCELA AND M.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO AND M.IND_EVENTO = 1 AND H.NUM_CERTIFICADO = P.NUM_CERTIFICADO AND H.NUM_PARCELA = P.NUM_PARCELA AND H.NSAS = :HISLANCT-NSAS AND H.PRM_TOTAL <> 0 AND C.NUM_CERTIFICADO = P.NUM_CERTIFICADO AND C.NUM_PARCELA = P.NUM_PARCELA AND C.NUM_TITULO = :COBHISVI-NUM-TITULO AND E.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO AND E.NUM_PESSOA = :GE368-NUM-PESSOA AND E.IND_ENTIDADE = 3 AND B.NUM_PESSOA = E.NUM_PESSOA AND B.SEQ_CONTA_BANCARIA = E.SEQ_ENTIDADE AND B.COD_BANCO <> 104 FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r300_SELECT_HISLANCT_DB_SELECT_1_Query1 = new R300_SELECT_HISLANCT_DB_SELECT_1_Query1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                VG079_NUM_OCORR_MOVTO = VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
                HISLANCT_NSAS = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.ToString(),
            };

            var executed_1 = R300_SELECT_HISLANCT_DB_SELECT_1_Query1.Execute(r300_SELECT_HISLANCT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(executed_1.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(executed_1.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(executed_1.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(executed_1.HISLANCT_NSAS, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);
                _.Move(executed_1.SQL_MAYBE_NULL1, SQL_MAYBE_NULL1);
                _.Move(executed_1.HISLANCT_NSL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL);
                _.Move(executed_1.SQL_MAYBE_NULL2, SQL_MAYBE_NULL2);
                _.Move(executed_1.HISLANCT_CODCONV, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);
                _.Move(executed_1.VG079_NUM_OCORR_MOVTO, VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO);
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
                _.Move(executed_1.OD009_NUM_DV_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.OD009_NUM_PESSOA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA);
                _.Move(executed_1.OD009_SEQ_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA);
                _.Move(executed_1.GE368_NUM_OCORR_MOVTO, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R1600-00-UPDATE-GE366 */
        private void R1600_00_UPDATE_GE366(bool isPerform = false)
        {
            /*" -2080- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2082- MOVE 'UPDATE GE-MOVIMENTO     ' TO COMANDO. */
            _.Move("UPDATE GE-MOVIMENTO     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2086- PERFORM R1600_00_UPDATE_GE366_DB_UPDATE_1 */

            R1600_00_UPDATE_GE366_DB_UPDATE_1();

            /*" -2089- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2091- DISPLAY 'R1600-00 - PROBLEMAS UPDATE (GE366) ' SQLCODE */
                _.Display($"R1600-00 - PROBLEMAS UPDATE (GE366) {DB.SQLCODE}");

                /*" -2092- GO TO R99999-ROT-ERRO */

                R99999_ROT_ERRO(); //GOTO
                return;

                /*" -2092- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-UPDATE-GE366-DB-UPDATE-1 */
        public void R1600_00_UPDATE_GE366_DB_UPDATE_1()
        {
            /*" -2086- EXEC SQL UPDATE SEGUROS.GE_MOVIMENTO SET IND_EVENTO = :GE366-IND-EVENTO WHERE NUM_OCORR_MOVTO = :GE366-NUM-OCORR-MOVTO END-EXEC. */

            var r1600_00_UPDATE_GE366_DB_UPDATE_1_Update1 = new R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1()
            {
                GE366_IND_EVENTO = GE366.DCLGE_MOVIMENTO.GE366_IND_EVENTO.ToString(),
                GE366_NUM_OCORR_MOVTO = GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO.ToString(),
            };

            R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1.Execute(r1600_00_UPDATE_GE366_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/

        [StopWatch]
        /*" R99999-ROT-ERRO */
        private void R99999_ROT_ERRO(bool isPerform = false)
        {
            /*" -2104- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -2105- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -2106- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -2107- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -2108- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -2110- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -2110- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2112- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2116- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2118- CLOSE SAIDA RELAT OUTROSBC. */
            SAIDA.Close();
            RELAT.Close();
            OUTROSBC.Close();

            /*" -2118- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_EXIT*/
    }
}