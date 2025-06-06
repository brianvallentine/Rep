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
    public class PF0112B
    {
        public bool IsCall { get; set; }

        public PF0112B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA.................  SISTEMA DE PRODUTOS DE FIDELIZACAO *      */
        /*"      *   OBJETIVO ...............  ------ ARQUIVO DE PROPOSTAS ------ *      */
        /*"      *                             LEITURA DE UM ARQUIVO DE PROPOSTAS *      */
        /*"      *                             VINDO DA CAIXA - MJUNMOV           *      */
        /*"      *                                                                *      */
        /*"      *                             - GERAR UM ARQUIVO DE SAIDA COM AS *      */
        /*"      *                               PROPOSTAS DO PRODUTO 0056 - VIDA *      */
        /*"      *                               INDIVIDUAL PARA O SISTEMA SSVIDA *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO.....  REGINALDO SILVA                    *      */
        /*"      *   PROGRAMA ...............  PF0112B                            *      */
        /*"      *   DATA ...................  20/05/2024.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-------------------   M A N U T E N C O E S   ------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.01  * VERSAO 01             INCIDENTE 605152 - IGNORAR PROPOSTAS REJ *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.01          CANETTA                11/09/2024        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO XX             XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      * ATENDE CADMUS 999999  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                                                                *      */
        /*"      * PROCURE XXXXX         REGINALDO SILVA                          *      */
        /*"      *                       20/05/2024                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------*                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MVJUNMOV { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MVJUNMOV
        {
            get
            {
                _.Move(REG_MVJUNMOV, _MVJUNMOV); VarBasis.RedefinePassValue(REG_MVJUNMOV, _MVJUNMOV, REG_MVJUNMOV); return _MVJUNMOV;
            }
        }
        public FileBasis _BILHETES { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis BILHETES
        {
            get
            {
                _.Move(REG_BILHETES, _BILHETES); VarBasis.RedefinePassValue(REG_BILHETES, _BILHETES, REG_BILHETES); return _BILHETES;
            }
        }
        /*"01   REG-MVJUNMOV                 PIC X(300).*/
        public StringBasis REG_MVJUNMOV { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-BILHETES                 PIC X(300).*/
        public StringBasis REG_BILHETES { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-ACHEI-HEADER                   PIC X(001) VALUE 'N'   .*/
        public StringBasis WS_ACHEI_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-ACHEI-TRAILER                  PIC X(001) VALUE 'N'   .*/
        public StringBasis WS_ACHEI_TRAILER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-CONT-REG-LIDOS                 PIC 9(009) VALUE ZEROS .*/
        public IntBasis WS_CONT_REG_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-CONT-HEADER                    PIC 9(003) VALUE ZEROS .*/
        public IntBasis WS_CONT_HEADER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77  WS-CONT-TRAILER                   PIC 9(003) VALUE ZEROS .*/
        public IntBasis WS_CONT_TRAILER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77  WS-QTDE-GRAV-BILHETES             PIC 9(009) VALUE ZEROS .*/
        public IntBasis WS_QTDE_GRAV_BILHETES { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-QTDE-PROP-56                   PIC 9(009) VALUE ZEROS .*/
        public IntBasis WS_QTDE_PROP_56 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-TOT-GERAL-PROP                 PIC 9(009) VALUE ZEROS .*/
        public IntBasis WS_TOT_GERAL_PROP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-FIM-MOVTO                      PIC X(003) VALUE SPACES.*/
        public StringBasis WS_FIM_MOVTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-PARAGRAFO                      PIC X(050) VALUE SPACES.*/
        public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"77  WS-COMANDO                        PIC X(050) VALUE SPACES.*/
        public StringBasis WS_COMANDO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"77  WS-REGPROBLEMA                    PIC 9(007) VALUE ZEROS .*/
        public IntBasis WS_REGPROBLEMA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  WS-INDCRIT                        PIC 9(003) VALUE ZEROS .*/
        public IntBasis WS_INDCRIT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77  WS-INDMENS                        PIC 9(003) VALUE ZEROS .*/
        public IntBasis WS_INDMENS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77  WS-INDPROP                        PIC 9(003) VALUE ZEROS .*/
        public IntBasis WS_INDPROP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77  WS-INDGRAVA                       PIC 9(003) VALUE ZEROS .*/
        public IntBasis WS_INDGRAVA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77  WS-FLAG-SO1VEZ                    PIC X(002) VALUE 'S'   .*/
        public StringBasis WS_FLAG_SO1VEZ { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"S");
        /*"77  WS-ACHOU-HEADER-1REG              PIC X(002) VALUE 'S'   .*/
        public StringBasis WS_ACHOU_HEADER_1REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"S");
        /*"77  WS-NOME-HT                        PIC X(008) VALUE SPACES.*/
        public StringBasis WS_NOME_HT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WS-NOME-HT-ATUAL                  PIC X(008) VALUE SPACES.*/
        public StringBasis WS_NOME_HT_ATUAL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WS-NOME-HT-ANT                    PIC X(008) VALUE SPACES.*/
        public StringBasis WS_NOME_HT_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WS-TIP-ARQ                        PIC 9(001) VALUE ZEROS.*/
        public IntBasis WS_TIP_ARQ { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77  WS-NOME-LK-CRITICA                PIC X(040) VALUE SPACES.*/
        public StringBasis WS_NOME_LK_CRITICA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77  WS-TEM-PROPCRIT                   PIC X(001) VALUE 'N'.*/
        public StringBasis WS_TEM_PROPCRIT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-TEM-IND-ESTOUROU               PIC X(001) VALUE 'N'.*/
        public StringBasis WS_TEM_IND_ESTOUROU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-ACHEI-HEADER-ANT               PIC X(001) VALUE 'N'.*/
        public StringBasis WS_ACHEI_HEADER_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-NUM-PROPOSTA-ANT               PIC 9(014) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"77  WS-REG-ENTRADA-LIDO               PIC X(300) VALUE SPACES.*/
        public StringBasis WS_REG_ENTRADA_LIDO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)"), @"");
        /*"77  WS-QTDE-REG-TIPO0                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO1                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO2                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO3                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO4                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO5                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO6                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO7                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO8                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPO9                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPO9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOA                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOB                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOB { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOC                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOD                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOE                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOF                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOF { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOG                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOH                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOH { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOI                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOJ                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOJ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOK                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOL                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOM                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPON                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPON { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOU                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOU { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOV                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOV { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOX                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOY                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOY { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOZ                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOZ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TIPOW                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TIPOW { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"77  WS-QTDE-REG-TOTAL                 PIC 9(008) VALUE ZEROS.*/
        public IntBasis WS_QTDE_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01  WS-REG-ENTRADA.*/
        public PF0112B_WS_REG_ENTRADA WS_REG_ENTRADA { get; set; } = new PF0112B_WS_REG_ENTRADA();
        public class PF0112B_WS_REG_ENTRADA : VarBasis
        {
            /*"    02  REG-TIPO-REGISTRO.*/
            public PF0112B_REG_TIPO_REGISTRO REG_TIPO_REGISTRO { get; set; } = new PF0112B_REG_TIPO_REGISTRO();
            public class PF0112B_REG_TIPO_REGISTRO : VarBasis
            {
                /*"        03  REG-TIPOREG               PIC X(001).*/
                public StringBasis REG_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        03  REG-NUM-PROPOSTA          PIC X(014).*/
                public StringBasis REG_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                /*"        03  FILLER    REDEFINES     REG-NUM-PROPOSTA.*/
                private _REDEF_PF0112B_FILLER_0 _filler_0 { get; set; }
                public _REDEF_PF0112B_FILLER_0 FILLER_0
                {
                    get { _filler_0 = new _REDEF_PF0112B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                    set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF0112B_FILLER_0 : VarBasis
                {
                    /*"            05  REG-NUM-PROPOSTA-A    PIC X(014).*/
                    public StringBasis REG_NUM_PROPOSTA_A { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                    /*"        03  FILLER    REDEFINES     REG-NUM-PROPOSTA.*/

                    public _REDEF_PF0112B_FILLER_0()
                    {
                        REG_NUM_PROPOSTA_A.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF0112B_FILLER_1 _filler_1 { get; set; }
                public _REDEF_PF0112B_FILLER_1 FILLER_1
                {
                    get { _filler_1 = new _REDEF_PF0112B_FILLER_1(); _.Move(REG_NUM_PROPOSTA, _filler_1); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_1, REG_NUM_PROPOSTA); _filler_1.ValueChanged += () => { _.Move(_filler_1, REG_NUM_PROPOSTA); }; return _filler_1; }
                    set { VarBasis.RedefinePassValue(value, _filler_1, REG_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF0112B_FILLER_1 : VarBasis
                {
                    /*"            05  REG-NOME-HT           PIC X(008).*/
                    public StringBasis REG_NOME_HT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"            05  FILLER   REDEFINES   REG-NOME-HT.*/
                    private _REDEF_PF0112B_FILLER_2 _filler_2 { get; set; }
                    public _REDEF_PF0112B_FILLER_2 FILLER_2
                    {
                        get { _filler_2 = new _REDEF_PF0112B_FILLER_2(); _.Move(REG_NOME_HT, _filler_2); VarBasis.RedefinePassValue(REG_NOME_HT, _filler_2, REG_NOME_HT); _filler_2.ValueChanged += () => { _.Move(_filler_2, REG_NOME_HT); }; return _filler_2; }
                        set { VarBasis.RedefinePassValue(value, _filler_2, REG_NOME_HT); }
                    }  //Redefines
                    public class _REDEF_PF0112B_FILLER_2 : VarBasis
                    {
                        /*"                07  FILLER            PIC X(005).*/
                        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                        /*"                07  REG-COD-PRODUTO   PIC X(002).*/
                        public StringBasis REG_COD_PRODUTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"                07  FILLER            PIC X(001).*/
                        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"            05  REG-RESTO             PIC X(006).*/

                        public _REDEF_PF0112B_FILLER_2()
                        {
                            FILLER_3.ValueChanged += OnValueChanged;
                            REG_COD_PRODUTO.ValueChanged += OnValueChanged;
                            FILLER_4.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis REG_RESTO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"        03  REG-COD-PRODUTO-SIVPF     PIC X(004).*/

                    public _REDEF_PF0112B_FILLER_1()
                    {
                        REG_NOME_HT.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis REG_COD_PRODUTO_SIVPF { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"        03  FILLER                    PIC X(006).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"        03  REG-TIP-ARQ               PIC X(001).*/
                public StringBasis REG_TIP_ARQ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        03  FILLER                    PIC X(250).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
                /*"        03  REG-ORIGEM-PROPOSTA       PIC X(002).*/
                public StringBasis REG_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"        03  FILLER                    PIC X(022).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
                /*"    02  FILLER   REDEFINES  REG-TIPO-REGISTRO.*/
            }
            private _REDEF_PF0112B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0112B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0112B_FILLER_8(); _.Move(REG_TIPO_REGISTRO, _filler_8); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_8, REG_TIPO_REGISTRO); _filler_8.ValueChanged += () => { _.Move(_filler_8, REG_TIPO_REGISTRO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF0112B_FILLER_8 : VarBasis
            {
                /*"        04  RS3-TIPO-SASSE.*/
                public PF0112B_RS3_TIPO_SASSE RS3_TIPO_SASSE { get; set; } = new PF0112B_RS3_TIPO_SASSE();
                public class PF0112B_RS3_TIPO_SASSE : VarBasis
                {
                    /*"            05  RS3-TIPOREG           PIC X(001).*/
                    public StringBasis RS3_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-NUM-PROPOSTA      PIC 9(014).*/
                    public IntBasis RS3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  RS3-COD-PRODUTO       PIC 9(004).*/
                    public IntBasis RS3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-COD-AGENCIA       PIC 9(004).*/
                    public IntBasis RS3_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-DATA-PROPOSTA     PIC 9(008).*/
                    public IntBasis RS3_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05   FILLER REDEFINES    RS3-DATA-PROPOSTA.*/
                    private _REDEF_PF0112B_FILLER_9 _filler_9 { get; set; }
                    public _REDEF_PF0112B_FILLER_9 FILLER_9
                    {
                        get { _filler_9 = new _REDEF_PF0112B_FILLER_9(); _.Move(RS3_DATA_PROPOSTA, _filler_9); VarBasis.RedefinePassValue(RS3_DATA_PROPOSTA, _filler_9, RS3_DATA_PROPOSTA); _filler_9.ValueChanged += () => { _.Move(_filler_9, RS3_DATA_PROPOSTA); }; return _filler_9; }
                        set { VarBasis.RedefinePassValue(value, _filler_9, RS3_DATA_PROPOSTA); }
                    }  //Redefines
                    public class _REDEF_PF0112B_FILLER_9 : VarBasis
                    {
                        /*"                06 RS3-DIA-PROP       PIC 9(002).*/
                        public IntBasis RS3_DIA_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"                06 RS3-MES-PROP       PIC 9(002).*/
                        public IntBasis RS3_MES_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"                06 RS3-ANO-PROP       PIC 9(004).*/
                        public IntBasis RS3_ANO_PROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"            05  RS3-TIPO-PAGTO        PIC 9(001).*/

                        public _REDEF_PF0112B_FILLER_9()
                        {
                            RS3_DIA_PROP.ValueChanged += OnValueChanged;
                            RS3_MES_PROP.ValueChanged += OnValueChanged;
                            RS3_ANO_PROP.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis RS3_TIPO_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RS3-AGENCIA           PIC 9(004).*/
                    public IntBasis RS3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-OPERACAO          PIC 9(003).*/
                    public IntBasis RS3_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RS3-CONTA             PIC 9(008).*/
                    public IntBasis RS3_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-DV                PIC 9(001).*/
                    public IntBasis RS3_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RS3-DEC-PESS-TIT      PIC X(007).*/
                    public StringBasis RS3_DEC_PESS_TIT { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"            05  RS3-DEC-PESS-CONJ     PIC X(007).*/
                    public StringBasis RS3_DEC_PESS_CONJ { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"            05  RS3-MATRIC-VENDEDOR   PIC 9(008).*/
                    public IntBasis RS3_MATRIC_VENDEDOR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-VAL-PREMIO-LIQ    PIC 9(016).*/
                    public IntBasis RS3_VAL_PREMIO_LIQ { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"            05  RS3-APOS-INVALIDEZ    PIC X(001).*/
                    public StringBasis RS3_APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-RENOV-AUTOMATICA  PIC X(001).*/
                    public StringBasis RS3_RENOV_AUTOMATICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-DIA-VENC          PIC 9(002).*/
                    public IntBasis RS3_DIA_VENC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RS3-PERC-DESCONTO     PIC 9(005).*/
                    public IntBasis RS3_PERC_DESCONTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"            05  RS3-EMP-CONVEN        PIC X(040).*/
                    public StringBasis RS3_EMP_CONVEN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"            05  RS3-CNPJ-EMP-CONVEN   PIC 9(014).*/
                    public IntBasis RS3_CNPJ_EMP_CONVEN { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  RS3-MATRIC-CONVEN     PIC 9(008).*/
                    public IntBasis RS3_MATRIC_CONVEN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-SIT-PROPOSTA      PIC X(003).*/
                    public StringBasis RS3_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RS3-SIT-COBRANCA      PIC X(003).*/
                    public StringBasis RS3_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RS3-MOTIVO-SITUACAO   PIC 9(003).*/
                    public IntBasis RS3_MOTIVO_SITUACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RS3-OPCAO-COBERTURA   PIC X(001).*/
                    public StringBasis RS3_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-COD-PLANO         PIC 9(004).*/
                    public IntBasis RS3_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-DT-QUIT-BCO       PIC 9(008).*/
                    public IntBasis RS3_DT_QUIT_BCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-VAL-PAGO-SICOB    PIC 9(015).*/
                    public IntBasis RS3_VAL_PAGO_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RS3-COD-AGENC-PAGTO   PIC 9(004).*/
                    public IntBasis RS3_COD_AGENC_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-TARIFA-COBRANCA   PIC 9(015).*/
                    public IntBasis RS3_TARIFA_COBRANCA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RS3-DT-CREDITO-SEG    PIC 9(008).*/
                    public IntBasis RS3_DT_CREDITO_SEG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-VAL-COMISSAO      PIC 9(015).*/
                    public IntBasis RS3_VAL_COMISSAO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RS3-PERIODIC-PAGTO    PIC 9(002).*/
                    public IntBasis RS3_PERIODIC_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RS3-OPCAO-CONJUGE     PIC X(001).*/
                    public StringBasis RS3_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-TIPO-RESIDENCIA   PIC 9(001).*/
                    public IntBasis RS3_TIPO_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RS3-VAL-IOF           PIC 9(008).*/
                    public IntBasis RS3_VAL_IOF { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-CUSTO-APOLICE     PIC 9(008).*/
                    public IntBasis RS3_CUSTO_APOLICE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  FILLER                PIC X(005).*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"            05  RS3-NUM-SICOB         PIC 9(013).*/
                    public IntBasis RS3_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"            05  RS3-ORIGEM-PROPOSTA   PIC X(004).*/
                    public StringBasis RS3_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"            05   FILLER REDEFINES    RS3-ORIGEM-PROPOSTA.*/
                    private _REDEF_PF0112B_FILLER_11 _filler_11 { get; set; }
                    public _REDEF_PF0112B_FILLER_11 FILLER_11
                    {
                        get { _filler_11 = new _REDEF_PF0112B_FILLER_11(); _.Move(RS3_ORIGEM_PROPOSTA, _filler_11); VarBasis.RedefinePassValue(RS3_ORIGEM_PROPOSTA, _filler_11, RS3_ORIGEM_PROPOSTA); _filler_11.ValueChanged += () => { _.Move(_filler_11, RS3_ORIGEM_PROPOSTA); }; return _filler_11; }
                        set { VarBasis.RedefinePassValue(value, _filler_11, RS3_ORIGEM_PROPOSTA); }
                    }  //Redefines
                    public class _REDEF_PF0112B_FILLER_11 : VarBasis
                    {
                        /*"                06 RS3-ORIGEM-1A2     PIC X(002).*/
                        public StringBasis RS3_ORIGEM_1A2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"                06 RS3-ORIGEM-AIC     PIC 9(002).*/
                        public IntBasis RS3_ORIGEM_AIC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"            05  RS3-NSAS              PIC 9(006).*/

                        public _REDEF_PF0112B_FILLER_11()
                        {
                            RS3_ORIGEM_1A2.ValueChanged += OnValueChanged;
                            RS3_ORIGEM_AIC.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis RS3_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"            05  RS3-NSL               PIC 9(006).*/
                    public IntBasis RS3_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"            05  RS3-PRAZO-VIGENCIA    PIC 9(002).*/
                    public IntBasis RS3_PRAZO_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RS3-USO-RESERVADO     PIC 9(008).*/
                    public IntBasis RS3_USO_RESERVADO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    02  FILLER   REDEFINES  REG-TIPO-REGISTRO.*/

                    public PF0112B_RS3_TIPO_SASSE()
                    {
                        RS3_TIPOREG.ValueChanged += OnValueChanged;
                        RS3_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                        RS3_COD_PRODUTO.ValueChanged += OnValueChanged;
                        RS3_COD_AGENCIA.ValueChanged += OnValueChanged;
                        RS3_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF0112B_FILLER_8()
                {
                    RS3_TIPO_SASSE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0112B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_PF0112B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_PF0112B_FILLER_12(); _.Move(REG_TIPO_REGISTRO, _filler_12); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_12, REG_TIPO_REGISTRO); _filler_12.ValueChanged += () => { _.Move(_filler_12, REG_TIPO_REGISTRO); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF0112B_FILLER_12 : VarBasis
            {
                /*"        04  RP3-TIPOREGS-INICIO.*/
                public PF0112B_RP3_TIPOREGS_INICIO RP3_TIPOREGS_INICIO { get; set; } = new PF0112B_RP3_TIPOREGS_INICIO();
                public class PF0112B_RP3_TIPOREGS_INICIO : VarBasis
                {
                    /*"            05 RP3-TIPOREG            PIC X(001).*/
                    public StringBasis RP3_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05 RP3-NUM-PROPOSTA       PIC 9(014).*/
                    public IntBasis RP3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05 RP3-COD-PRODUTO        PIC 9(004).*/
                    public IntBasis RP3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05 RP3-COD-AGENCIA        PIC 9(004).*/
                    public IntBasis RP3_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05 RP3-TIPO-APOSENT       PIC 9(002).*/
                    public IntBasis RP3_TIPO_APOSENT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05 RP3-DATA-PROPOSTA      PIC 9(008).*/
                    public IntBasis RP3_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05 RP3-IND-SIMULACAO      PIC X(001).*/
                    public StringBasis RP3_IND_SIMULACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05 RP3-PRAZO-PERCEPCAO    PIC 9(004).*/
                    public IntBasis RP3_PRAZO_PERCEPCAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05 RP3-PRAZO-DIFER        PIC 9(004).*/
                    public IntBasis RP3_PRAZO_DIFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05 RP3-TIPO-CONTRIB       PIC X(001).*/
                    public StringBasis RP3_TIPO_CONTRIB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05 RP3-VAL-CONTRIB-APOS   PIC 9(015).*/
                    public IntBasis RP3_VAL_CONTRIB_APOS { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05 RP3-VAL-RESERVA-INIC   PIC X(015).*/
                    public StringBasis RP3_VAL_RESERVA_INIC { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"            05 RP3-DIA-VENCIMENTO     PIC 9(002).*/
                    public IntBasis RP3_DIA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05 RP3-FORMA-PAGTO        PIC 9(001).*/
                    public IntBasis RP3_FORMA_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05 RP3-AGENCIA            PIC 9(004).*/
                    public IntBasis RP3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05 RP3-OPERACAO           PIC 9(003).*/
                    public IntBasis RP3_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05 RP3-CONTA              PIC 9(008).*/
                    public IntBasis RP3_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05 RP3-DV                 PIC 9(001).*/
                    public IntBasis RP3_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05 RP3-MATRIC-VENDEDOR    PIC X(008).*/
                    public StringBasis RP3_MATRIC_VENDEDOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"            05 RP3-DECLARACAO-SAUDE   PIC X(006).*/
                    public StringBasis RP3_DECLARACAO_SAUDE { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"            05 RP3-PORTABILIDADE      PIC X(001).*/
                    public StringBasis RP3_PORTABILIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05 RP3-FILLER-ALTERA      PIC X(009).*/
                    public StringBasis RP3_FILLER_ALTERA { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                    /*"            05 RP3-PERCENT-DESCONTO   PIC 9(005).*/
                    public IntBasis RP3_PERCENT_DESCONTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"            05 RP3-EMPR-CONVEN        PIC X(040).*/
                    public StringBasis RP3_EMPR_CONVEN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"            05 RP3-CNPJ-EMP-CONVEN    PIC X(014).*/
                    public StringBasis RP3_CNPJ_EMP_CONVEN { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                    /*"            05 RP3-MATR-CONVEN        PIC 9(008).*/
                    public IntBasis RP3_MATR_CONVEN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05 RP3-SITUACAO-PROPOSTA  PIC X(003).*/
                    public StringBasis RP3_SITUACAO_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05 RP3-SITUACAO-COBRANCA  PIC X(003).*/
                    public StringBasis RP3_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05 RP3-MOTIVO-SITUACAO    PIC X(003).*/
                    public StringBasis RP3_MOTIVO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05 FILLER                 PIC X(065).*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
                    /*"            05 RP3-CODIGO-FUNDO       PIC 9(002).*/
                    public IntBasis RP3_CODIGO_FUNDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05 RP3-PORCENT-REVERSAO   PIC 9(005).*/
                    public IntBasis RP3_PORCENT_REVERSAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"            05 RP3-INDIC-RES-INICIAL  PIC 9(001).*/
                    public IntBasis RP3_INDIC_RES_INICIAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05 RP3-INDIC-APOS         PIC X(001).*/
                    public StringBasis RP3_INDIC_APOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05 RP3-TIPO-TRIBUTACAO    PIC 9(001).*/
                    public IntBasis RP3_TIPO_TRIBUTACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05 RP3-TAXA-CARREGAMENTO  PIC 9(004).*/
                    public IntBasis RP3_TAXA_CARREGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05 FILLER                 PIC X(005).*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"            05 RP3-ORIGEM-PROPOSTA    PIC 9(002).*/
                    public IntBasis RP3_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05 RP3-SEQ-ARQUIVO        PIC X(006).*/
                    public StringBasis RP3_SEQ_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"            05 RP3-SEQ-REGISTRO       PIC X(006).*/
                    public StringBasis RP3_SEQ_REGISTRO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"            05 RP3-USO-RESERVADO      PIC X(010).*/
                    public StringBasis RP3_USO_RESERVADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"    02  FILLER   REDEFINES  REG-TIPO-REGISTRO.*/

                    public PF0112B_RP3_TIPOREGS_INICIO()
                    {
                        RP3_TIPOREG.ValueChanged += OnValueChanged;
                        RP3_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                        RP3_COD_PRODUTO.ValueChanged += OnValueChanged;
                        RP3_COD_AGENCIA.ValueChanged += OnValueChanged;
                        RP3_TIPO_APOSENT.ValueChanged += OnValueChanged;
                        RP3_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                        RP3_IND_SIMULACAO.ValueChanged += OnValueChanged;
                        RP3_PRAZO_PERCEPCAO.ValueChanged += OnValueChanged;
                        RP3_PRAZO_DIFER.ValueChanged += OnValueChanged;
                        RP3_TIPO_CONTRIB.ValueChanged += OnValueChanged;
                        RP3_VAL_CONTRIB_APOS.ValueChanged += OnValueChanged;
                        RP3_VAL_RESERVA_INIC.ValueChanged += OnValueChanged;
                        RP3_DIA_VENCIMENTO.ValueChanged += OnValueChanged;
                        RP3_FORMA_PAGTO.ValueChanged += OnValueChanged;
                        RP3_AGENCIA.ValueChanged += OnValueChanged;
                        RP3_OPERACAO.ValueChanged += OnValueChanged;
                        RP3_CONTA.ValueChanged += OnValueChanged;
                        RP3_DV.ValueChanged += OnValueChanged;
                        RP3_MATRIC_VENDEDOR.ValueChanged += OnValueChanged;
                        RP3_DECLARACAO_SAUDE.ValueChanged += OnValueChanged;
                        RP3_PORTABILIDADE.ValueChanged += OnValueChanged;
                        RP3_FILLER_ALTERA.ValueChanged += OnValueChanged;
                        RP3_PERCENT_DESCONTO.ValueChanged += OnValueChanged;
                        RP3_EMPR_CONVEN.ValueChanged += OnValueChanged;
                        RP3_CNPJ_EMP_CONVEN.ValueChanged += OnValueChanged;
                        RP3_MATR_CONVEN.ValueChanged += OnValueChanged;
                        RP3_SITUACAO_PROPOSTA.ValueChanged += OnValueChanged;
                        RP3_SITUACAO_COBRANCA.ValueChanged += OnValueChanged;
                        RP3_MOTIVO_SITUACAO.ValueChanged += OnValueChanged;
                        FILLER_13.ValueChanged += OnValueChanged;
                        RP3_CODIGO_FUNDO.ValueChanged += OnValueChanged;
                        RP3_PORCENT_REVERSAO.ValueChanged += OnValueChanged;
                        RP3_INDIC_RES_INICIAL.ValueChanged += OnValueChanged;
                        RP3_INDIC_APOS.ValueChanged += OnValueChanged;
                        RP3_TIPO_TRIBUTACAO.ValueChanged += OnValueChanged;
                        RP3_TAXA_CARREGAMENTO.ValueChanged += OnValueChanged;
                        FILLER_14.ValueChanged += OnValueChanged;
                        RP3_ORIGEM_PROPOSTA.ValueChanged += OnValueChanged;
                        RP3_SEQ_ARQUIVO.ValueChanged += OnValueChanged;
                        RP3_SEQ_REGISTRO.ValueChanged += OnValueChanged;
                        RP3_USO_RESERVADO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF0112B_FILLER_12()
                {
                    RP3_TIPOREGS_INICIO.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0112B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_PF0112B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_PF0112B_FILLER_15(); _.Move(REG_TIPO_REGISTRO, _filler_15); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_15, REG_TIPO_REGISTRO); _filler_15.ValueChanged += () => { _.Move(_filler_15, REG_TIPO_REGISTRO); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF0112B_FILLER_15 : VarBasis
            {
                /*"        04  RC3-TIPOREGS-INICIO.*/
                public PF0112B_RC3_TIPOREGS_INICIO RC3_TIPOREGS_INICIO { get; set; } = new PF0112B_RC3_TIPOREGS_INICIO();
                public class PF0112B_RC3_TIPOREGS_INICIO : VarBasis
                {
                    /*"            05  RC3-TIPOREG           PIC X(001).*/
                    public StringBasis RC3_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RC3-NUM-PROPOSTA      PIC 9(014).*/
                    public IntBasis RC3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  RC3-DATA-PROPOSTA     PIC 9(008).*/
                    public IntBasis RC3_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RC3-COD-PRODUTO       PIC 9(004).*/
                    public IntBasis RC3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RC3-COD-AGENCIA       PIC 9(004).*/
                    public IntBasis RC3_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RC3-DIA-PAGAMENTO     PIC 9(002).*/
                    public IntBasis RC3_DIA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RC3-TIPO-PAGTO        PIC 9(001).*/
                    public IntBasis RC3_TIPO_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RC3-AGENCIA           PIC 9(004).*/
                    public IntBasis RC3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RC3-OPERACAO          PIC 9(003).*/
                    public IntBasis RC3_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RC3-CONTA             PIC 9(008).*/
                    public IntBasis RC3_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RC3-DV                PIC 9(001).*/
                    public IntBasis RC3_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RC3-TIPO-TITULAR      PIC 9(001).*/
                    public IntBasis RC3_TIPO_TITULAR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RC3-VALOR-MENSALID    PIC 9(015).*/
                    public IntBasis RC3_VALOR_MENSALID { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RC3-QTDE-TITULOS      PIC 9(003).*/
                    public IntBasis RC3_QTDE_TITULOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RC3-VAL-TOTAL-PROP    PIC 9(015).*/
                    public IntBasis RC3_VAL_TOTAL_PROP { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RC3-PERC-DESCONTO     PIC 9(005).*/
                    public IntBasis RC3_PERC_DESCONTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"            05  RC3-MATRIC-VENDEDOR   PIC 9(008).*/
                    public IntBasis RC3_MATRIC_VENDEDOR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RC3-COD-SUB-PRODUTO   PIC X(004).*/
                    public StringBasis RC3_COD_SUB_PRODUTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"            05  RC3-FILLER            PIC X(012).*/
                    public StringBasis RC3_FILLER { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                    /*"            05  RC3-CNPJ-EMP-CONV     PIC 9(014).*/
                    public IntBasis RC3_CNPJ_EMP_CONV { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  RC3-EMPRESA-CONV      PIC X(040).*/
                    public StringBasis RC3_EMPRESA_CONV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"            05  RC3-MATRIC            PIC 9(007).*/
                    public IntBasis RC3_MATRIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                    /*"            05  FILLER                PIC X(001).*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RC3-SIT-PROPOSTA      PIC X(003).*/
                    public StringBasis RC3_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RC3-SIT-COBRANCA      PIC X(003).*/
                    public StringBasis RC3_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RC3-MOTIVO-SITUACAO   PIC X(003).*/
                    public StringBasis RC3_MOTIVO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RC3-COD-PLANO         PIC 9(003).*/
                    public IntBasis RC3_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RC3-DATA-AUTENTIC     PIC 9(008).*/
                    public IntBasis RC3_DATA_AUTENTIC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RC3-VAL-PAGO-SICOB    PIC 9(015).*/
                    public IntBasis RC3_VAL_PAGO_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RC3-COD-AGENC-PAGTO   PIC 9(004).*/
                    public IntBasis RC3_COD_AGENC_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RC3-VAL-TARIFA-COB    PIC 9(015).*/
                    public IntBasis RC3_VAL_TARIFA_COB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RC3-DATA-CRED-CAP     PIC 9(008).*/
                    public IntBasis RC3_DATA_CRED_CAP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RC3-VAL-COMISSAO      PIC 9(015).*/
                    public IntBasis RC3_VAL_COMISSAO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  FILLER                PIC X(012).*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                    /*"            05  RC3-TIT-ORIG-REVENDA  PIC 9(012).*/
                    public IntBasis RC3_TIT_ORIG_REVENDA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"            05  RC3-ORIGEM-PROP       PIC 9(002).*/
                    public IntBasis RC3_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RC3-NSAS              PIC 9(006).*/
                    public IntBasis RC3_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"            05  RC3-NSL               PIC 9(006).*/
                    public IntBasis RC3_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"            05  RC3-USO-RESERVADO     PIC X(010).*/
                    public StringBasis RC3_USO_RESERVADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"    02  FILLER   REDEFINES  REG-TIPO-REGISTRO.*/

                    public PF0112B_RC3_TIPOREGS_INICIO()
                    {
                        RC3_TIPOREG.ValueChanged += OnValueChanged;
                        RC3_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                        RC3_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                        RC3_COD_PRODUTO.ValueChanged += OnValueChanged;
                        RC3_COD_AGENCIA.ValueChanged += OnValueChanged;
                        RC3_DIA_PAGAMENTO.ValueChanged += OnValueChanged;
                        RC3_TIPO_PAGTO.ValueChanged += OnValueChanged;
                        RC3_AGENCIA.ValueChanged += OnValueChanged;
                        RC3_OPERACAO.ValueChanged += OnValueChanged;
                        RC3_CONTA.ValueChanged += OnValueChanged;
                        RC3_DV.ValueChanged += OnValueChanged;
                        RC3_TIPO_TITULAR.ValueChanged += OnValueChanged;
                        RC3_VALOR_MENSALID.ValueChanged += OnValueChanged;
                        RC3_QTDE_TITULOS.ValueChanged += OnValueChanged;
                        RC3_VAL_TOTAL_PROP.ValueChanged += OnValueChanged;
                        RC3_PERC_DESCONTO.ValueChanged += OnValueChanged;
                        RC3_MATRIC_VENDEDOR.ValueChanged += OnValueChanged;
                        RC3_COD_SUB_PRODUTO.ValueChanged += OnValueChanged;
                        RC3_FILLER.ValueChanged += OnValueChanged;
                        RC3_CNPJ_EMP_CONV.ValueChanged += OnValueChanged;
                        RC3_EMPRESA_CONV.ValueChanged += OnValueChanged;
                        RC3_MATRIC.ValueChanged += OnValueChanged;
                        FILLER_16.ValueChanged += OnValueChanged;
                        RC3_SIT_PROPOSTA.ValueChanged += OnValueChanged;
                        RC3_SIT_COBRANCA.ValueChanged += OnValueChanged;
                        RC3_MOTIVO_SITUACAO.ValueChanged += OnValueChanged;
                        RC3_COD_PLANO.ValueChanged += OnValueChanged;
                        RC3_DATA_AUTENTIC.ValueChanged += OnValueChanged;
                        RC3_VAL_PAGO_SICOB.ValueChanged += OnValueChanged;
                        RC3_COD_AGENC_PAGTO.ValueChanged += OnValueChanged;
                        RC3_VAL_TARIFA_COB.ValueChanged += OnValueChanged;
                        RC3_DATA_CRED_CAP.ValueChanged += OnValueChanged;
                        RC3_VAL_COMISSAO.ValueChanged += OnValueChanged;
                        FILLER_17.ValueChanged += OnValueChanged;
                        RC3_TIT_ORIG_REVENDA.ValueChanged += OnValueChanged;
                        RC3_ORIGEM_PROP.ValueChanged += OnValueChanged;
                        RC3_NSAS.ValueChanged += OnValueChanged;
                        RC3_NSL.ValueChanged += OnValueChanged;
                        RC3_USO_RESERVADO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF0112B_FILLER_15()
                {
                    RC3_TIPOREGS_INICIO.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0112B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_PF0112B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_PF0112B_FILLER_18(); _.Move(REG_TIPO_REGISTRO, _filler_18); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_18, REG_TIPO_REGISTRO); _filler_18.ValueChanged += () => { _.Move(_filler_18, REG_TIPO_REGISTRO); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF0112B_FILLER_18 : VarBasis
            {
                /*"        04  RTT-TIPO-TRAILER.*/
                public PF0112B_RTT_TIPO_TRAILER RTT_TIPO_TRAILER { get; set; } = new PF0112B_RTT_TIPO_TRAILER();
                public class PF0112B_RTT_TIPO_TRAILER : VarBasis
                {
                    /*"            05  RTT-IDENTIFICACAO     PIC X(01).*/
                    public StringBasis RTT_IDENTIFICACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"            05  RTT-NOME-ARQUIVO      PIC X(08).*/
                    public StringBasis RTT_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                    /*"            05  RTT-QTDE-TIPO0        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO1        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO2        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO3        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO4        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO5        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO6        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO7        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO8        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPO9        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPO9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOA        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOB        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOB { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOC        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOC { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOD        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOD { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOE        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOF        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOF { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOG        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOG { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOH        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOH { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOI        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOI { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOJ        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOJ { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOK        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOK { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOL        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOM        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOM { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPON        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPON { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOU        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOU { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOV        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOV { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOX        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOX { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOY        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOZ        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOZ { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-QTDE-TIPOW        PIC 9(08).*/
                    public IntBasis RTT_QTDE_TIPOW { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-FILLER1           PIC X(01).*/
                    public StringBasis RTT_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"            05  RTT-QTDE-TOTAL-REG    PIC 9(08).*/
                    public IntBasis RTT_QTDE_TOTAL_REG { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"            05  RTT-FILLER2           PIC X(42).*/
                    public StringBasis RTT_FILLER2 { get; set; } = new StringBasis(new PIC("X", "42", "X(42)."), @"");
                    /*"01  WS-AUX-ENTRADA.*/

                    public PF0112B_RTT_TIPO_TRAILER()
                    {
                        RTT_IDENTIFICACAO.ValueChanged += OnValueChanged;
                        RTT_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO0.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO1.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO2.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO3.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO4.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO5.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO6.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO7.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO8.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPO9.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOA.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOB.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOC.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOD.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOE.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOF.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOG.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOH.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOI.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOJ.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOK.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOL.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOM.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPON.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOU.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOV.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOX.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOY.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOZ.ValueChanged += OnValueChanged;
                        RTT_QTDE_TIPOW.ValueChanged += OnValueChanged;
                        RTT_FILLER1.ValueChanged += OnValueChanged;
                        RTT_QTDE_TOTAL_REG.ValueChanged += OnValueChanged;
                        RTT_FILLER2.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF0112B_FILLER_18()
                {
                    RTT_TIPO_TRAILER.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0112B_WS_AUX_ENTRADA WS_AUX_ENTRADA { get; set; } = new PF0112B_WS_AUX_ENTRADA();
        public class PF0112B_WS_AUX_ENTRADA : VarBasis
        {
            /*"    02  AUX-TIPOREGS.*/
            public PF0112B_AUX_TIPOREGS AUX_TIPOREGS { get; set; } = new PF0112B_AUX_TIPOREGS();
            public class PF0112B_AUX_TIPOREGS : VarBasis
            {
                /*"        03  AUX-TIPOREG               PIC X(001).*/
                public StringBasis AUX_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        03  AUX-NUM-PROPOSTA          PIC 9(014).*/
                public IntBasis AUX_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"        03  FILLER                    PIC X(285).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "285", "X(285)."), @"");
                /*"01 WS-MENSAGEM.*/
            }
        }
        public PF0112B_WS_MENSAGEM WS_MENSAGEM { get; set; } = new PF0112B_WS_MENSAGEM();
        public class PF0112B_WS_MENSAGEM : VarBasis
        {
            /*"   05 WS-MENS      OCCURS 20 TIMES   PIC X(040).*/
            public ListBasis<StringBasis, string> WS_MENS { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "40", "X(040)."), 20);
            /*"01 WS-REGPROBLEMAS.*/
        }
        public PF0112B_WS_REGPROBLEMAS WS_REGPROBLEMAS { get; set; } = new PF0112B_WS_REGPROBLEMAS();
        public class PF0112B_WS_REGPROBLEMAS : VarBasis
        {
            /*"   05 WS-NREG      OCCURS 20 TIMES   PIC 9(007).*/
            public ListBasis<IntBasis, Int64> WS_NREG { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "7", "9(007)."), 20);
            /*"   05 WS-PROP      OCCURS 20 TIMES   PIC 9(014).*/
            public ListBasis<IntBasis, Int64> WS_PROP { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "9(014)."), 20);
            /*"01 WS-REGS-MESMA-PROPOSTA.*/
        }
        public PF0112B_WS_REGS_MESMA_PROPOSTA WS_REGS_MESMA_PROPOSTA { get; set; } = new PF0112B_WS_REGS_MESMA_PROPOSTA();
        public class PF0112B_WS_REGS_MESMA_PROPOSTA : VarBasis
        {
            /*"   05 WS-PROP-OCORR  OCCURS 200 TIMES PIC X(300).*/
            public ListBasis<StringBasis, string> WS_PROP_OCORR { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "300", "X(300)."), 200);
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MVJUNMOV_FILE_NAME_P, string BILHETES_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MVJUNMOV.SetFile(MVJUNMOV_FILE_NAME_P);
                BILHETES.SetFile(BILHETES_FILE_NAME_P);

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
            /*" -420- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -421- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -422- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -443- PERFORM R0100-00-INICIALIZAR. */

            R0100_00_INICIALIZAR_SECTION();

            /*" -446- PERFORM R0200-00-LER-ARQ-MOVTO UNTIL WS-FIM-MOVTO EQUAL 'FIM' . */

            while (!(WS_FIM_MOVTO == "FIM"))
            {

                R0200_00_LER_ARQ_MOVTO_SECTION();
            }

            /*" -448- PERFORM R0300-00-FINALIZAR. */

            R0300_00_FINALIZAR_SECTION();

            /*" -448- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZAR-SECTION */
        private void R0100_00_INICIALIZAR_SECTION()
        {
            /*" -456- MOVE 'R0100-00-INICIALIZAR' TO WS-PARAGRAFO. */
            _.Move("R0100-00-INICIALIZAR", WS_PARAGRAFO);

            /*" -459- MOVE 'PERFORM' TO WS-COMANDO. */
            _.Move("PERFORM", WS_COMANDO);

            /*" -465- MOVE ZEROS TO RETURN-CODE, WS-REGPROBLEMAS, WS-INDMENS, WS-INDPROP, WS-INDCRIT, WS-INDGRAVA. */
            _.Move(0, RETURN_CODE, WS_REGPROBLEMAS, WS_INDMENS, WS_INDPROP, WS_INDCRIT, WS_INDGRAVA);

            /*" -470- MOVE SPACES TO WS-MENSAGEM, WS-REGS-MESMA-PROPOSTA, WS-REG-ENTRADA, WS-REG-ENTRADA-LIDO. */
            _.Move("", WS_MENSAGEM, WS_REGS_MESMA_PROPOSTA, WS_REG_ENTRADA, WS_REG_ENTRADA_LIDO);

            /*" -470- PERFORM R0110-00-ABRIR-ARQUIVOS. */

            R0110_00_ABRIR_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-ABRIR-ARQUIVOS-SECTION */
        private void R0110_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -480- MOVE 'R0110-00-ABRIR-ARQUIVOS' TO WS-PARAGRAFO. */
            _.Move("R0110-00-ABRIR-ARQUIVOS", WS_PARAGRAFO);

            /*" -483- MOVE 'OPEN' TO WS-COMANDO. */
            _.Move("OPEN", WS_COMANDO);

            /*" -484- OPEN INPUT MVJUNMOV, */
            MVJUNMOV.Open(REG_MVJUNMOV);

            /*" -484- OUTPUT BILHETES. */
            BILHETES.Open(REG_BILHETES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-ARQ-MOVTO-SECTION */
        private void R0200_00_LER_ARQ_MOVTO_SECTION()
        {
            /*" -494- MOVE 'R0200-00-LER-ARQ-MOVTO' TO WS-PARAGRAFO. */
            _.Move("R0200-00-LER-ARQ-MOVTO", WS_PARAGRAFO);

            /*" -497- MOVE 'READ' TO WS-COMANDO. */
            _.Move("READ", WS_COMANDO);

            /*" -498- READ MVJUNMOV INTO WS-REG-ENTRADA AT END */
            try
            {
                MVJUNMOV.Read(() =>
                {

                    /*" -500- MOVE 'FIM' TO WS-FIM-MOVTO */
                    _.Move("FIM", WS_FIM_MOVTO);

                    /*" -502- GO TO R0200-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                    return;

                    /*" -504- NOT AT END */
                }, () =>
                {

                    /*" -505- ADD 1 TO WS-CONT-REG-LIDOS */
                    WS_CONT_REG_LIDOS.Value = WS_CONT_REG_LIDOS + 1;

                    /*" -508- END-READ. */
                });

                _.Move(MVJUNMOV.Value, WS_REG_ENTRADA); _.Move(MVJUNMOV.Value, REG_MVJUNMOV);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -510- IF WS-CONT-REG-LIDOS EQUAL 1 AND REG-TIPOREG NOT EQUAL 'H' */

            if (WS_CONT_REG_LIDOS == 1 && WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG != "H")
            {

                /*" -511- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -512- MOVE 'N' TO WS-ACHOU-HEADER-1REG */
                _.Move("N", WS_ACHOU_HEADER_1REG);

                /*" -513- ADD 1 TO WS-INDMENS */
                WS_INDMENS.Value = WS_INDMENS + 1;

                /*" -516- MOVE '* HEADER NAO FOI ENCONTRADO NO REG 1 *' TO WS-MENS (WS-INDMENS) WS-NOME-LK-CRITICA */
                _.Move("* HEADER NAO FOI ENCONTRADO NO REG 1 *", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                /*" -517- MOVE WS-CONT-REG-LIDOS TO WS-NREG (WS-INDMENS) */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMAS.WS_NREG[WS_INDMENS]);

                /*" -518- MOVE ZEROS TO WS-PROP (WS-INDMENS) */
                _.Move(0, WS_REGPROBLEMAS.WS_PROP[WS_INDMENS]);

                /*" -520- MOVE 'S' TO WS-TEM-PROPCRIT */
                _.Move("S", WS_TEM_PROPCRIT);

                /*" -521- MOVE 'FIM' TO WS-FIM-MOVTO */
                _.Move("FIM", WS_FIM_MOVTO);

                /*" -522- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -526- END-IF */
            }


            /*" -527- IF REG-TIPOREG EQUAL 'H' */

            if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG == "H")
            {

                /*" -530- MOVE REG-NOME-HT TO WS-NOME-HT, WS-NOME-HT-ATUAL WS-NOME-HT-ANT */
                _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.FILLER_1.REG_NOME_HT, WS_NOME_HT, WS_NOME_HT_ATUAL, WS_NOME_HT_ANT);

                /*" -532- MOVE REG-TIP-ARQ TO WS-TIP-ARQ */
                _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIP_ARQ, WS_TIP_ARQ);

                /*" -534- END-IF */
            }


            /*" -535- IF REG-TIPOREG EQUAL 'T' */

            if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG == "T")
            {

                /*" -536- MOVE 0 TO WS-INDGRAVA */
                _.Move(0, WS_INDGRAVA);

                /*" -539- PERFORM R0210-00-TRATAR-PROPOSTA UNTIL WS-INDGRAVA >= WS-INDPROP */

                while (!(WS_INDGRAVA >= WS_INDPROP))
                {

                    R0210_00_TRATAR_PROPOSTA_SECTION();
                }

                /*" -540- IF REG-NOME-HT NOT EQUAL WS-NOME-HT-ANT */

                if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.FILLER_1.REG_NOME_HT != WS_NOME_HT_ANT)
                {

                    /*" -541- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -542- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                    _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                    /*" -543- ADD 1 TO WS-INDMENS */
                    WS_INDMENS.Value = WS_INDMENS + 1;

                    /*" -546- MOVE '* HEADER E TRAILER SAO DIFERENTES-GRAVE*' TO WS-MENS (WS-INDMENS) WS-NOME-LK-CRITICA */
                    _.Move("* HEADER E TRAILER SAO DIFERENTES-GRAVE*", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                    /*" -547- MOVE WS-CONT-REG-LIDOS TO WS-NREG (WS-INDMENS) */
                    _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMAS.WS_NREG[WS_INDMENS]);

                    /*" -550- MOVE ZEROS TO WS-PROP (WS-INDMENS) */
                    _.Move(0, WS_REGPROBLEMAS.WS_PROP[WS_INDMENS]);

                    /*" -551- MOVE 'S' TO WS-TEM-PROPCRIT */
                    _.Move("S", WS_TEM_PROPCRIT);

                    /*" -552- MOVE 'FIM' TO WS-FIM-MOVTO */
                    _.Move("FIM", WS_FIM_MOVTO);

                    /*" -553- GO TO R0200-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                    return;

                    /*" -554- END-IF */
                }


                /*" -559- END-IF */
            }


            /*" -561- IF WS-NOME-HT EQUAL 'PRPSASSE' AND WS-TIP-ARQ EQUAL 1 */

            if (WS_NOME_HT == "PRPSASSE" && WS_TIP_ARQ == 1)
            {

                /*" -562- CONTINUE */

                /*" -563- ELSE */
            }
            else
            {


                /*" -564- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -568- END-IF */
            }


            /*" -569- IF REG-TIPOREG EQUAL 'H' */

            if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG == "H")
            {

                /*" -570- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                /*" -571- MOVE 'S' TO WS-ACHEI-HEADER */
                _.Move("S", WS_ACHEI_HEADER);

                /*" -572- ADD 1 TO WS-CONT-HEADER */
                WS_CONT_HEADER.Value = WS_CONT_HEADER + 1;

                /*" -573- PERFORM R0220-00-GRAVA-HEADER */

                R0220_00_GRAVA_HEADER_SECTION();

                /*" -574- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -578- END-IF */
            }


            /*" -579- IF REG-TIPOREG EQUAL 'T' */

            if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG == "T")
            {

                /*" -580- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                /*" -581- MOVE 'S' TO WS-ACHEI-TRAILER */
                _.Move("S", WS_ACHEI_TRAILER);

                /*" -582- ADD 1 TO WS-CONT-TRAILER */
                WS_CONT_TRAILER.Value = WS_CONT_TRAILER + 1;

                /*" -583- PERFORM R0230-00-GRAVA-TRAILLER */

                R0230_00_GRAVA_TRAILLER_SECTION();

                /*" -584- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -586- END-IF */
            }


            /*" -587- IF WS-FLAG-SO1VEZ EQUAL 'S' */

            if (WS_FLAG_SO1VEZ == "S")
            {

                /*" -588- MOVE REG-NUM-PROPOSTA TO WS-NUM-PROPOSTA-ANT */
                _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA, WS_NUM_PROPOSTA_ANT);

                /*" -589- MOVE 'N' TO WS-FLAG-SO1VEZ */
                _.Move("N", WS_FLAG_SO1VEZ);

                /*" -595- END-IF */
            }


            /*" -599- IF WS-CONT-REG-LIDOS GREATER 1 AND REG-TIPOREG NOT EQUAL 'H' AND REG-TIPOREG NOT EQUAL 'T' */

            if (WS_CONT_REG_LIDOS > 1 && WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG != "H" && WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG != "T")
            {

                /*" -602- IF REG-NUM-PROPOSTA EQUAL WS-NUM-PROPOSTA-ANT */

                if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA == WS_NUM_PROPOSTA_ANT)
                {

                    /*" -603- IF WS-INDPROP GREATER 198 */

                    if (WS_INDPROP > 198)
                    {

                        /*" -604- MOVE 99 TO RETURN-CODE */
                        _.Move(99, RETURN_CODE);

                        /*" -605- MOVE 'S' TO WS-TEM-PROPCRIT */
                        _.Move("S", WS_TEM_PROPCRIT);

                        /*" -606- MOVE 'S' TO WS-TEM-IND-ESTOUROU */
                        _.Move("S", WS_TEM_IND_ESTOUROU);

                        /*" -607- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                        _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                        /*" -608- ADD 1 TO WS-INDMENS */
                        WS_INDMENS.Value = WS_INDMENS + 1;

                        /*" -610- MOVE '*INDPROP - ESTOUROU NRO REG MESMA PROP *' TO WS-MENS (WS-INDMENS), WS-NOME-LK-CRITICA */
                        _.Move("*INDPROP - ESTOUROU NRO REG MESMA PROP *", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                        /*" -611- MOVE WS-CONT-REG-LIDOS TO WS-NREG (WS-INDMENS) */
                        _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMAS.WS_NREG[WS_INDMENS]);

                        /*" -612- MOVE REG-NUM-PROPOSTA TO WS-PROP (WS-INDMENS) */
                        _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA, WS_REGPROBLEMAS.WS_PROP[WS_INDMENS]);

                        /*" -614- ELSE */
                    }
                    else
                    {


                        /*" -615- ADD 1 TO WS-INDPROP */
                        WS_INDPROP.Value = WS_INDPROP + 1;

                        /*" -619- MOVE WS-REG-ENTRADA TO WS-PROP-OCORR (WS-INDPROP) */
                        _.Move(WS_REG_ENTRADA, WS_REGS_MESMA_PROPOSTA.WS_PROP_OCORR[WS_INDPROP]);

                        /*" -620- END-IF */
                    }


                    /*" -622- ELSE */
                }
                else
                {


                    /*" -623- MOVE 0 TO WS-INDGRAVA */
                    _.Move(0, WS_INDGRAVA);

                    /*" -625- PERFORM R0210-00-TRATAR-PROPOSTA UNTIL WS-INDGRAVA >= WS-INDPROP */

                    while (!(WS_INDGRAVA >= WS_INDPROP))
                    {

                        R0210_00_TRATAR_PROPOSTA_SECTION();
                    }

                    /*" -626- END-IF */
                }


                /*" -626- END-IF */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0210-00-TRATAR-PROPOSTA-SECTION */
        private void R0210_00_TRATAR_PROPOSTA_SECTION()
        {
            /*" -637- MOVE 'R0210-00-TRATAR-PROPOSTA' TO WS-PARAGRAFO. */
            _.Move("R0210-00-TRATAR-PROPOSTA", WS_PARAGRAFO);

            /*" -640- MOVE 'PERFORM' TO WS-COMANDO. */
            _.Move("PERFORM", WS_COMANDO);

            /*" -641- MOVE WS-REG-ENTRADA TO WS-REG-ENTRADA-LIDO. */
            _.Move(WS_REG_ENTRADA, WS_REG_ENTRADA_LIDO);

            /*" -642- MOVE SPACES TO WS-REG-ENTRADA. */
            _.Move("", WS_REG_ENTRADA);

            /*" -644- MOVE 0 TO WS-INDCRIT. */
            _.Move(0, WS_INDCRIT);

            /*" -645- PERFORM UNTIL WS-INDCRIT >= WS-INDPROP */

            while (!(WS_INDCRIT >= WS_INDPROP))
            {

                /*" -646- ADD 1 TO WS-INDCRIT */
                WS_INDCRIT.Value = WS_INDCRIT + 1;

                /*" -650- MOVE WS-PROP-OCORR (WS-INDCRIT) TO WS-REG-ENTRADA */
                _.Move(WS_REGS_MESMA_PROPOSTA.WS_PROP_OCORR[WS_INDCRIT], WS_REG_ENTRADA);

                /*" -652- IF REG-TIPOREG EQUAL '3' */

                if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG == "3")
                {

                    /*" -655- IF RS3-COD-PRODUTO EQUAL 0056 */

                    if (WS_REG_ENTRADA.FILLER_8.RS3_TIPO_SASSE.RS3_COD_PRODUTO == 0056)
                    {

                        /*" -659- ADD 1 TO WS-QTDE-PROP-56 */
                        WS_QTDE_PROP_56.Value = WS_QTDE_PROP_56 + 1;

                        /*" -660- MOVE 0 TO WS-INDGRAVA */
                        _.Move(0, WS_INDGRAVA);

                        /*" -663- PERFORM R0240-00-GRAVA-ARQ-REGS-SELEC UNTIL WS-INDGRAVA >= WS-INDPROP */

                        while (!(WS_INDGRAVA >= WS_INDPROP))
                        {

                            R0240_00_GRAVA_ARQ_REGS_SELEC_SECTION();
                        }

                        /*" -664- MOVE WS-INDPROP TO WS-INDCRIT, WS-INDGRAVA */
                        _.Move(WS_INDPROP, WS_INDCRIT, WS_INDGRAVA);

                        /*" -665- ELSE */
                    }
                    else
                    {


                        /*" -666- MOVE WS-INDPROP TO WS-INDCRIT, WS-INDGRAVA */
                        _.Move(WS_INDPROP, WS_INDCRIT, WS_INDGRAVA);

                        /*" -668- END-IF */
                    }


                    /*" -670- END-IF */
                }


                /*" -672- END-PERFORM */
            }

            /*" -678- MOVE SPACES TO WS-REGS-MESMA-PROPOSTA. */
            _.Move("", WS_REGS_MESMA_PROPOSTA);

            /*" -679- MOVE ZEROS TO WS-INDCRIT. */
            _.Move(0, WS_INDCRIT);

            /*" -680- MOVE 1 TO WS-INDPROP. */
            _.Move(1, WS_INDPROP);

            /*" -681- MOVE 1 TO WS-INDGRAVA. */
            _.Move(1, WS_INDGRAVA);

            /*" -683- MOVE 'N' TO WS-TEM-PROPCRIT. */
            _.Move("N", WS_TEM_PROPCRIT);

            /*" -685- MOVE WS-REG-ENTRADA-LIDO TO WS-REG-ENTRADA, WS-PROP-OCORR (WS-INDPROP). */
            _.Move(WS_REG_ENTRADA_LIDO, WS_REG_ENTRADA, WS_REGS_MESMA_PROPOSTA.WS_PROP_OCORR[WS_INDPROP]);

            /*" -685- MOVE REG-NUM-PROPOSTA TO WS-NUM-PROPOSTA-ANT. */
            _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA, WS_NUM_PROPOSTA_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R0220-00-GRAVA-HEADER-SECTION */
        private void R0220_00_GRAVA_HEADER_SECTION()
        {
            /*" -695- MOVE 'R0220-00-GRAVA-HEADER ' TO WS-PARAGRAFO. */
            _.Move("R0220-00-GRAVA-HEADER ", WS_PARAGRAFO);

            /*" -698- MOVE 'WRITE' TO WS-COMANDO. */
            _.Move("WRITE", WS_COMANDO);

            /*" -701- MOVE WS-REG-ENTRADA TO REG-BILHETES. */
            _.Move(WS_REG_ENTRADA, REG_BILHETES);

            /*" -702- WRITE REG-BILHETES. */
            BILHETES.Write(REG_BILHETES.GetMoveValues().ToString());

            /*" -704- ADD 1 TO WS-QTDE-GRAV-BILHETES. */
            WS_QTDE_GRAV_BILHETES.Value = WS_QTDE_GRAV_BILHETES + 1;

            /*" -705- MOVE SPACES TO WS-REG-ENTRADA. */
            _.Move("", WS_REG_ENTRADA);

            /*" -705- MOVE 'N' TO WS-TEM-PROPCRIT. */
            _.Move("N", WS_TEM_PROPCRIT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/

        [StopWatch]
        /*" R0230-00-GRAVA-TRAILLER-SECTION */
        private void R0230_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -715- MOVE 'R0230-00-GRAVA-TRAILLER' TO WS-PARAGRAFO. */
            _.Move("R0230-00-GRAVA-TRAILLER", WS_PARAGRAFO);

            /*" -718- MOVE 'WRITE' TO WS-COMANDO. */
            _.Move("WRITE", WS_COMANDO);

            /*" -724- MOVE WS-REG-ENTRADA TO REG-BILHETES, RTT-TIPO-TRAILER. */
            _.Move(WS_REG_ENTRADA, REG_BILHETES);
            _.Move(WS_REG_ENTRADA, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER);


            /*" -725- MOVE WS-QTDE-REG-TIPO0 TO RTT-QTDE-TIPO0. */
            _.Move(WS_QTDE_REG_TIPO0, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO0);

            /*" -726- MOVE WS-QTDE-REG-TIPO1 TO RTT-QTDE-TIPO1. */
            _.Move(WS_QTDE_REG_TIPO1, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO1);

            /*" -727- MOVE WS-QTDE-REG-TIPO2 TO RTT-QTDE-TIPO2. */
            _.Move(WS_QTDE_REG_TIPO2, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO2);

            /*" -728- MOVE WS-QTDE-REG-TIPO3 TO RTT-QTDE-TIPO3. */
            _.Move(WS_QTDE_REG_TIPO3, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO3);

            /*" -729- MOVE WS-QTDE-REG-TIPO4 TO RTT-QTDE-TIPO4. */
            _.Move(WS_QTDE_REG_TIPO4, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO4);

            /*" -730- MOVE WS-QTDE-REG-TIPO5 TO RTT-QTDE-TIPO5. */
            _.Move(WS_QTDE_REG_TIPO5, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO5);

            /*" -731- MOVE WS-QTDE-REG-TIPO6 TO RTT-QTDE-TIPO6. */
            _.Move(WS_QTDE_REG_TIPO6, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO6);

            /*" -732- MOVE WS-QTDE-REG-TIPO7 TO RTT-QTDE-TIPO7. */
            _.Move(WS_QTDE_REG_TIPO7, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO7);

            /*" -733- MOVE WS-QTDE-REG-TIPO8 TO RTT-QTDE-TIPO8. */
            _.Move(WS_QTDE_REG_TIPO8, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO8);

            /*" -734- MOVE WS-QTDE-REG-TIPO9 TO RTT-QTDE-TIPO9. */
            _.Move(WS_QTDE_REG_TIPO9, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPO9);

            /*" -735- MOVE WS-QTDE-REG-TIPOA TO RTT-QTDE-TIPOA. */
            _.Move(WS_QTDE_REG_TIPOA, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOA);

            /*" -736- MOVE WS-QTDE-REG-TIPOB TO RTT-QTDE-TIPOB. */
            _.Move(WS_QTDE_REG_TIPOB, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOB);

            /*" -737- MOVE WS-QTDE-REG-TIPOC TO RTT-QTDE-TIPOC. */
            _.Move(WS_QTDE_REG_TIPOC, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOC);

            /*" -738- MOVE WS-QTDE-REG-TIPOD TO RTT-QTDE-TIPOD. */
            _.Move(WS_QTDE_REG_TIPOD, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOD);

            /*" -739- MOVE WS-QTDE-REG-TIPOE TO RTT-QTDE-TIPOE. */
            _.Move(WS_QTDE_REG_TIPOE, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOE);

            /*" -740- MOVE WS-QTDE-REG-TIPOF TO RTT-QTDE-TIPOF. */
            _.Move(WS_QTDE_REG_TIPOF, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOF);

            /*" -741- MOVE WS-QTDE-REG-TIPOG TO RTT-QTDE-TIPOG. */
            _.Move(WS_QTDE_REG_TIPOG, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOG);

            /*" -742- MOVE WS-QTDE-REG-TIPOH TO RTT-QTDE-TIPOH. */
            _.Move(WS_QTDE_REG_TIPOH, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOH);

            /*" -743- MOVE WS-QTDE-REG-TIPOI TO RTT-QTDE-TIPOI. */
            _.Move(WS_QTDE_REG_TIPOI, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOI);

            /*" -744- MOVE WS-QTDE-REG-TIPOJ TO RTT-QTDE-TIPOJ. */
            _.Move(WS_QTDE_REG_TIPOJ, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOJ);

            /*" -745- MOVE WS-QTDE-REG-TIPOK TO RTT-QTDE-TIPOK. */
            _.Move(WS_QTDE_REG_TIPOK, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOK);

            /*" -746- MOVE WS-QTDE-REG-TIPOL TO RTT-QTDE-TIPOL. */
            _.Move(WS_QTDE_REG_TIPOL, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOL);

            /*" -747- MOVE WS-QTDE-REG-TIPOM TO RTT-QTDE-TIPOM. */
            _.Move(WS_QTDE_REG_TIPOM, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOM);

            /*" -748- MOVE WS-QTDE-REG-TIPON TO RTT-QTDE-TIPON. */
            _.Move(WS_QTDE_REG_TIPON, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPON);

            /*" -749- MOVE WS-QTDE-REG-TIPOU TO RTT-QTDE-TIPOU. */
            _.Move(WS_QTDE_REG_TIPOU, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOU);

            /*" -750- MOVE WS-QTDE-REG-TIPOV TO RTT-QTDE-TIPOV. */
            _.Move(WS_QTDE_REG_TIPOV, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOV);

            /*" -751- MOVE WS-QTDE-REG-TIPOX TO RTT-QTDE-TIPOX. */
            _.Move(WS_QTDE_REG_TIPOX, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOX);

            /*" -752- MOVE WS-QTDE-REG-TIPOY TO RTT-QTDE-TIPOY. */
            _.Move(WS_QTDE_REG_TIPOY, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOY);

            /*" -753- MOVE WS-QTDE-REG-TIPOZ TO RTT-QTDE-TIPOZ. */
            _.Move(WS_QTDE_REG_TIPOZ, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOZ);

            /*" -754- MOVE WS-QTDE-REG-TIPOW TO RTT-QTDE-TIPOW. */
            _.Move(WS_QTDE_REG_TIPOW, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TIPOW);

            /*" -757- MOVE SPACES TO RTT-FILLER1, RTT-FILLER2. */
            _.Move("", WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_FILLER1);
            _.Move("", WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_FILLER2);


            /*" -774- COMPUTE WS-QTDE-REG-TOTAL = ( WS-QTDE-REG-TOTAL + WS-QTDE-REG-TIPO0 + WS-QTDE-REG-TIPO1 + WS-QTDE-REG-TIPO2 + WS-QTDE-REG-TIPO3 + WS-QTDE-REG-TIPO4 + WS-QTDE-REG-TIPO5 + WS-QTDE-REG-TIPO6 + WS-QTDE-REG-TIPO7 + WS-QTDE-REG-TIPO8 + WS-QTDE-REG-TIPO9 + WS-QTDE-REG-TIPOA + WS-QTDE-REG-TIPOB + WS-QTDE-REG-TIPOC + WS-QTDE-REG-TIPOD + WS-QTDE-REG-TIPOE + WS-QTDE-REG-TIPOF + WS-QTDE-REG-TIPOG + WS-QTDE-REG-TIPOH + WS-QTDE-REG-TIPOI + WS-QTDE-REG-TIPOJ + WS-QTDE-REG-TIPOK + WS-QTDE-REG-TIPOL + WS-QTDE-REG-TIPOM + WS-QTDE-REG-TIPON + WS-QTDE-REG-TIPOU + WS-QTDE-REG-TIPOV + WS-QTDE-REG-TIPOX + WS-QTDE-REG-TIPOY + WS-QTDE-REG-TIPOZ + WS-QTDE-REG-TIPOW ). */
            WS_QTDE_REG_TOTAL.Value = (WS_QTDE_REG_TOTAL + WS_QTDE_REG_TIPO0 + WS_QTDE_REG_TIPO1 + WS_QTDE_REG_TIPO2 + WS_QTDE_REG_TIPO3 + WS_QTDE_REG_TIPO4 + WS_QTDE_REG_TIPO5 + WS_QTDE_REG_TIPO6 + WS_QTDE_REG_TIPO7 + WS_QTDE_REG_TIPO8 + WS_QTDE_REG_TIPO9 + WS_QTDE_REG_TIPOA + WS_QTDE_REG_TIPOB + WS_QTDE_REG_TIPOC + WS_QTDE_REG_TIPOD + WS_QTDE_REG_TIPOE + WS_QTDE_REG_TIPOF + WS_QTDE_REG_TIPOG + WS_QTDE_REG_TIPOH + WS_QTDE_REG_TIPOI + WS_QTDE_REG_TIPOJ + WS_QTDE_REG_TIPOK + WS_QTDE_REG_TIPOL + WS_QTDE_REG_TIPOM + WS_QTDE_REG_TIPON + WS_QTDE_REG_TIPOU + WS_QTDE_REG_TIPOV + WS_QTDE_REG_TIPOX + WS_QTDE_REG_TIPOY + WS_QTDE_REG_TIPOZ + WS_QTDE_REG_TIPOW);

            /*" -778- MOVE WS-QTDE-REG-TOTAL TO RTT-QTDE-TOTAL-REG. */
            _.Move(WS_QTDE_REG_TOTAL, WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER.RTT_QTDE_TOTAL_REG);

            /*" -779- MOVE RTT-TIPO-TRAILER TO REG-BILHETES. */
            _.Move(WS_REG_ENTRADA.FILLER_18.RTT_TIPO_TRAILER, REG_BILHETES);

            /*" -780- ADD 1 TO WS-QTDE-GRAV-BILHETES. */
            WS_QTDE_GRAV_BILHETES.Value = WS_QTDE_GRAV_BILHETES + 1;

            /*" -782- WRITE REG-BILHETES. */
            BILHETES.Write(REG_BILHETES.GetMoveValues().ToString());

            /*" -799- MOVE ZEROS TO WS-QTDE-REG-TOTAL , WS-QTDE-REG-TIPO0 , WS-QTDE-REG-TIPO1 , WS-QTDE-REG-TIPO2 , WS-QTDE-REG-TIPO3 , WS-QTDE-REG-TIPO4 , WS-QTDE-REG-TIPO5 , WS-QTDE-REG-TIPO6 , WS-QTDE-REG-TIPO7 , WS-QTDE-REG-TIPO8 , WS-QTDE-REG-TIPO9 , WS-QTDE-REG-TIPOA , WS-QTDE-REG-TIPOB , WS-QTDE-REG-TIPOC , WS-QTDE-REG-TIPOD , WS-QTDE-REG-TIPOE , WS-QTDE-REG-TIPOF , WS-QTDE-REG-TIPOG , WS-QTDE-REG-TIPOH , WS-QTDE-REG-TIPOI , WS-QTDE-REG-TIPOJ , WS-QTDE-REG-TIPOK , WS-QTDE-REG-TIPOL , WS-QTDE-REG-TIPOM , WS-QTDE-REG-TIPON , WS-QTDE-REG-TIPOU , WS-QTDE-REG-TIPOV , WS-QTDE-REG-TIPOX , WS-QTDE-REG-TIPOY , WS-QTDE-REG-TIPOZ , WS-QTDE-REG-TIPOW . */
            _.Move(0, WS_QTDE_REG_TOTAL, WS_QTDE_REG_TIPO0, WS_QTDE_REG_TIPO1, WS_QTDE_REG_TIPO2, WS_QTDE_REG_TIPO3, WS_QTDE_REG_TIPO4, WS_QTDE_REG_TIPO5, WS_QTDE_REG_TIPO6, WS_QTDE_REG_TIPO7, WS_QTDE_REG_TIPO8, WS_QTDE_REG_TIPO9, WS_QTDE_REG_TIPOA, WS_QTDE_REG_TIPOB, WS_QTDE_REG_TIPOC, WS_QTDE_REG_TIPOD, WS_QTDE_REG_TIPOE, WS_QTDE_REG_TIPOF, WS_QTDE_REG_TIPOG, WS_QTDE_REG_TIPOH, WS_QTDE_REG_TIPOI, WS_QTDE_REG_TIPOJ, WS_QTDE_REG_TIPOK, WS_QTDE_REG_TIPOL, WS_QTDE_REG_TIPOM, WS_QTDE_REG_TIPON, WS_QTDE_REG_TIPOU, WS_QTDE_REG_TIPOV, WS_QTDE_REG_TIPOX, WS_QTDE_REG_TIPOY, WS_QTDE_REG_TIPOZ, WS_QTDE_REG_TIPOW);

            /*" -801- MOVE SPACES TO WS-MENSAGEM, WS-REG-ENTRADA, WS-REG-ENTRADA-LIDO. */
            _.Move("", WS_MENSAGEM, WS_REG_ENTRADA, WS_REG_ENTRADA_LIDO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R0240-00-GRAVA-ARQ-REGS-SELEC-SECTION */
        private void R0240_00_GRAVA_ARQ_REGS_SELEC_SECTION()
        {
            /*" -810- MOVE 'R0240-00-GRAVA-ARQ-REGS-SELEC' TO WS-PARAGRAFO. */
            _.Move("R0240-00-GRAVA-ARQ-REGS-SELEC", WS_PARAGRAFO);

            /*" -813- MOVE 'WRITE' TO WS-COMANDO. */
            _.Move("WRITE", WS_COMANDO);

            /*" -814- ADD 1 TO WS-INDGRAVA. */
            WS_INDGRAVA.Value = WS_INDGRAVA + 1;

            /*" -817- MOVE WS-PROP-OCORR (WS-INDGRAVA) TO WS-AUX-ENTRADA, REG-BILHETES. */
            _.Move(WS_REGS_MESMA_PROPOSTA.WS_PROP_OCORR[WS_INDGRAVA], WS_AUX_ENTRADA, REG_BILHETES);

            /*" -820- IF AUX-TIPOREG EQUAL 'H' OR AUX-TIPOREG EQUAL 'T' NEXT SENTENCE */

            if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "H" || WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "T")
            {

                /*" -821- ELSE */
            }
            else
            {


                /*" -822- ADD 1 TO WS-QTDE-GRAV-BILHETES */
                WS_QTDE_GRAV_BILHETES.Value = WS_QTDE_GRAV_BILHETES + 1;

                /*" -823- WRITE REG-BILHETES */
                BILHETES.Write(REG_BILHETES.GetMoveValues().ToString());

                /*" -827- END-IF. */
            }


            /*" -828- IF AUX-TIPOREG NOT EQUAL ' ' */

            if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG != " ")
            {

                /*" -829-  EVALUATE TRUE  */

                /*" -830-  WHEN   AUX-TIPOREG  =  '0'  */

                /*" -830- IF   AUX-TIPOREG  =  '0' */

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "0")
                {

                    /*" -831- ADD 1 TO WS-QTDE-REG-TIPO0 */
                    WS_QTDE_REG_TIPO0.Value = WS_QTDE_REG_TIPO0 + 1;

                    /*" -832-  WHEN   AUX-TIPOREG  =  '1'  */

                    /*" -832- ELSE IF   AUX-TIPOREG  =  '1' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "1")
                {

                    /*" -833- ADD 1 TO WS-QTDE-REG-TIPO1 */
                    WS_QTDE_REG_TIPO1.Value = WS_QTDE_REG_TIPO1 + 1;

                    /*" -834-  WHEN   AUX-TIPOREG  =  '2'  */

                    /*" -834- ELSE IF   AUX-TIPOREG  =  '2' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "2")
                {

                    /*" -835- ADD 1 TO WS-QTDE-REG-TIPO2 */
                    WS_QTDE_REG_TIPO2.Value = WS_QTDE_REG_TIPO2 + 1;

                    /*" -836-  WHEN   AUX-TIPOREG  =  '3'  */

                    /*" -836- ELSE IF   AUX-TIPOREG  =  '3' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "3")
                {

                    /*" -837- ADD 1 TO WS-QTDE-REG-TIPO3 */
                    WS_QTDE_REG_TIPO3.Value = WS_QTDE_REG_TIPO3 + 1;

                    /*" -838-  WHEN   AUX-TIPOREG  =  '4'  */

                    /*" -838- ELSE IF   AUX-TIPOREG  =  '4' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "4")
                {

                    /*" -839- ADD 1 TO WS-QTDE-REG-TIPO4 */
                    WS_QTDE_REG_TIPO4.Value = WS_QTDE_REG_TIPO4 + 1;

                    /*" -840-  WHEN   AUX-TIPOREG  =  '5'  */

                    /*" -840- ELSE IF   AUX-TIPOREG  =  '5' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "5")
                {

                    /*" -841- ADD 1 TO WS-QTDE-REG-TIPO5 */
                    WS_QTDE_REG_TIPO5.Value = WS_QTDE_REG_TIPO5 + 1;

                    /*" -842-  WHEN   AUX-TIPOREG  =  '6'  */

                    /*" -842- ELSE IF   AUX-TIPOREG  =  '6' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "6")
                {

                    /*" -843- ADD 1 TO WS-QTDE-REG-TIPO6 */
                    WS_QTDE_REG_TIPO6.Value = WS_QTDE_REG_TIPO6 + 1;

                    /*" -844-  WHEN   AUX-TIPOREG  =  '7'  */

                    /*" -844- ELSE IF   AUX-TIPOREG  =  '7' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "7")
                {

                    /*" -845- ADD 1 TO WS-QTDE-REG-TIPO7 */
                    WS_QTDE_REG_TIPO7.Value = WS_QTDE_REG_TIPO7 + 1;

                    /*" -846-  WHEN   AUX-TIPOREG  =  '8'  */

                    /*" -846- ELSE IF   AUX-TIPOREG  =  '8' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "8")
                {

                    /*" -847- ADD 1 TO WS-QTDE-REG-TIPO8 */
                    WS_QTDE_REG_TIPO8.Value = WS_QTDE_REG_TIPO8 + 1;

                    /*" -848-  WHEN   AUX-TIPOREG  =  '9'  */

                    /*" -848- ELSE IF   AUX-TIPOREG  =  '9' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "9")
                {

                    /*" -849- ADD 1 TO WS-QTDE-REG-TIPO9 */
                    WS_QTDE_REG_TIPO9.Value = WS_QTDE_REG_TIPO9 + 1;

                    /*" -850-  WHEN   AUX-TIPOREG  =  'A'  */

                    /*" -850- ELSE IF   AUX-TIPOREG  =  'A' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "A")
                {

                    /*" -851- ADD 1 TO WS-QTDE-REG-TIPOA */
                    WS_QTDE_REG_TIPOA.Value = WS_QTDE_REG_TIPOA + 1;

                    /*" -852-  WHEN   AUX-TIPOREG  =  'B'  */

                    /*" -852- ELSE IF   AUX-TIPOREG  =  'B' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "B")
                {

                    /*" -853- ADD 1 TO WS-QTDE-REG-TIPOB */
                    WS_QTDE_REG_TIPOB.Value = WS_QTDE_REG_TIPOB + 1;

                    /*" -854-  WHEN   AUX-TIPOREG  =  'C'  */

                    /*" -854- ELSE IF   AUX-TIPOREG  =  'C' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "C")
                {

                    /*" -855- ADD 1 TO WS-QTDE-REG-TIPOC */
                    WS_QTDE_REG_TIPOC.Value = WS_QTDE_REG_TIPOC + 1;

                    /*" -856-  WHEN   AUX-TIPOREG  =  'D'  */

                    /*" -856- ELSE IF   AUX-TIPOREG  =  'D' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "D")
                {

                    /*" -857- ADD 1 TO WS-QTDE-REG-TIPOD */
                    WS_QTDE_REG_TIPOD.Value = WS_QTDE_REG_TIPOD + 1;

                    /*" -858-  WHEN   AUX-TIPOREG  =  'E'  */

                    /*" -858- ELSE IF   AUX-TIPOREG  =  'E' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "E")
                {

                    /*" -859- ADD 1 TO WS-QTDE-REG-TIPOE */
                    WS_QTDE_REG_TIPOE.Value = WS_QTDE_REG_TIPOE + 1;

                    /*" -860-  WHEN   AUX-TIPOREG  =  'F'  */

                    /*" -860- ELSE IF   AUX-TIPOREG  =  'F' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "F")
                {

                    /*" -861- ADD 1 TO WS-QTDE-REG-TIPOF */
                    WS_QTDE_REG_TIPOF.Value = WS_QTDE_REG_TIPOF + 1;

                    /*" -862-  WHEN   AUX-TIPOREG  =  'G'  */

                    /*" -862- ELSE IF   AUX-TIPOREG  =  'G' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "G")
                {

                    /*" -863- ADD 1 TO WS-QTDE-REG-TIPOG */
                    WS_QTDE_REG_TIPOG.Value = WS_QTDE_REG_TIPOG + 1;

                    /*" -864-  WHEN   AUX-TIPOREG  =  'H'  */

                    /*" -864- ELSE IF   AUX-TIPOREG  =  'H' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "H")
                {

                    /*" -865- ADD 1 TO WS-QTDE-REG-TIPOH */
                    WS_QTDE_REG_TIPOH.Value = WS_QTDE_REG_TIPOH + 1;

                    /*" -866-  WHEN   AUX-TIPOREG  =  'I'  */

                    /*" -866- ELSE IF   AUX-TIPOREG  =  'I' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "I")
                {

                    /*" -867- ADD 1 TO WS-QTDE-REG-TIPOI */
                    WS_QTDE_REG_TIPOI.Value = WS_QTDE_REG_TIPOI + 1;

                    /*" -868-  WHEN   AUX-TIPOREG  =  'J'  */

                    /*" -868- ELSE IF   AUX-TIPOREG  =  'J' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "J")
                {

                    /*" -869- ADD 1 TO WS-QTDE-REG-TIPOJ */
                    WS_QTDE_REG_TIPOJ.Value = WS_QTDE_REG_TIPOJ + 1;

                    /*" -870-  WHEN   AUX-TIPOREG  =  'K'  */

                    /*" -870- ELSE IF   AUX-TIPOREG  =  'K' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "K")
                {

                    /*" -871- ADD 1 TO WS-QTDE-REG-TIPOK */
                    WS_QTDE_REG_TIPOK.Value = WS_QTDE_REG_TIPOK + 1;

                    /*" -872-  WHEN   AUX-TIPOREG  =  'L'  */

                    /*" -872- ELSE IF   AUX-TIPOREG  =  'L' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "L")
                {

                    /*" -873- ADD 1 TO WS-QTDE-REG-TIPOL */
                    WS_QTDE_REG_TIPOL.Value = WS_QTDE_REG_TIPOL + 1;

                    /*" -874-  WHEN   AUX-TIPOREG  =  'M'  */

                    /*" -874- ELSE IF   AUX-TIPOREG  =  'M' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "M")
                {

                    /*" -875- ADD 1 TO WS-QTDE-REG-TIPOM */
                    WS_QTDE_REG_TIPOM.Value = WS_QTDE_REG_TIPOM + 1;

                    /*" -876-  WHEN   AUX-TIPOREG  =  'N'  */

                    /*" -876- ELSE IF   AUX-TIPOREG  =  'N' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "N")
                {

                    /*" -877- ADD 1 TO WS-QTDE-REG-TIPON */
                    WS_QTDE_REG_TIPON.Value = WS_QTDE_REG_TIPON + 1;

                    /*" -878-  WHEN   AUX-TIPOREG  =  'U'  */

                    /*" -878- ELSE IF   AUX-TIPOREG  =  'U' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "U")
                {

                    /*" -879- ADD 1 TO WS-QTDE-REG-TIPOU */
                    WS_QTDE_REG_TIPOU.Value = WS_QTDE_REG_TIPOU + 1;

                    /*" -880-  WHEN   AUX-TIPOREG  =  'V'  */

                    /*" -880- ELSE IF   AUX-TIPOREG  =  'V' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "V")
                {

                    /*" -881- ADD 1 TO WS-QTDE-REG-TIPOV */
                    WS_QTDE_REG_TIPOV.Value = WS_QTDE_REG_TIPOV + 1;

                    /*" -882-  WHEN   AUX-TIPOREG  =  'X'  */

                    /*" -882- ELSE IF   AUX-TIPOREG  =  'X' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "X")
                {

                    /*" -883- ADD 1 TO WS-QTDE-REG-TIPOX */
                    WS_QTDE_REG_TIPOX.Value = WS_QTDE_REG_TIPOX + 1;

                    /*" -884-  WHEN   AUX-TIPOREG  =  'Y'  */

                    /*" -884- ELSE IF   AUX-TIPOREG  =  'Y' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "Y")
                {

                    /*" -885- ADD 1 TO WS-QTDE-REG-TIPOY */
                    WS_QTDE_REG_TIPOY.Value = WS_QTDE_REG_TIPOY + 1;

                    /*" -886-  WHEN   AUX-TIPOREG  =  'Z'  */

                    /*" -886- ELSE IF   AUX-TIPOREG  =  'Z' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "Z")
                {

                    /*" -887- ADD 1 TO WS-QTDE-REG-TIPOZ */
                    WS_QTDE_REG_TIPOZ.Value = WS_QTDE_REG_TIPOZ + 1;

                    /*" -888-  WHEN   AUX-TIPOREG  =  'W'  */

                    /*" -888- ELSE IF   AUX-TIPOREG  =  'W' */
                }
                else

                if (WS_AUX_ENTRADA.AUX_TIPOREGS.AUX_TIPOREG == "W")
                {

                    /*" -889- ADD 1 TO WS-QTDE-REG-TIPOW */
                    WS_QTDE_REG_TIPOW.Value = WS_QTDE_REG_TIPOW + 1;

                    /*" -890-  END-EVALUATE  */

                    /*" -890- END-IF */
                }


                /*" -890- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_SAIDA*/

        [StopWatch]
        /*" R0300-00-FINALIZAR-SECTION */
        private void R0300_00_FINALIZAR_SECTION()
        {
            /*" -903- MOVE 'R0300-00-FINALIZAR' TO WS-PARAGRAFO. */
            _.Move("R0300-00-FINALIZAR", WS_PARAGRAFO);

            /*" -906- MOVE 'PERFORM' TO WS-COMANDO. */
            _.Move("PERFORM", WS_COMANDO);

            /*" -907- IF WS-CONT-REG-LIDOS EQUAL ZEROS */

            if (WS_CONT_REG_LIDOS == 00)
            {

                /*" -908- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -909- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                /*" -910- ADD 1 TO WS-INDMENS */
                WS_INDMENS.Value = WS_INDMENS + 1;

                /*" -913- MOVE '* ARQUIVO VAZIO,FAVOR ANALISAR URGENTE *' TO WS-MENS (WS-INDMENS) WS-NOME-LK-CRITICA */
                _.Move("* ARQUIVO VAZIO,FAVOR ANALISAR URGENTE *", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                /*" -915- END-IF. */
            }


            /*" -917- IF WS-ACHEI-HEADER EQUAL 'N' AND WS-ACHEI-TRAILER EQUAL 'S' */

            if (WS_ACHEI_HEADER == "N" && WS_ACHEI_TRAILER == "S")
            {

                /*" -918- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -919- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                /*" -920- ADD 1 TO WS-INDMENS */
                WS_INDMENS.Value = WS_INDMENS + 1;

                /*" -921- MOVE 'S' TO WS-TEM-PROPCRIT */
                _.Move("S", WS_TEM_PROPCRIT);

                /*" -924- MOVE '* TRAILER OK, MAS NAO TEM  HEADER *' TO WS-MENS (WS-INDMENS) WS-NOME-LK-CRITICA */
                _.Move("* TRAILER OK, MAS NAO TEM  HEADER *", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                /*" -925- MOVE WS-CONT-REG-LIDOS TO WS-NREG (WS-INDMENS) */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMAS.WS_NREG[WS_INDMENS]);

                /*" -926- MOVE ZEROS TO WS-PROP (WS-INDMENS) */
                _.Move(0, WS_REGPROBLEMAS.WS_PROP[WS_INDMENS]);

                /*" -928- END-IF. */
            }


            /*" -929- IF WS-CONT-TRAILER LESS WS-CONT-HEADER */

            if (WS_CONT_TRAILER < WS_CONT_HEADER)
            {

                /*" -930- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -931- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                /*" -932- ADD 1 TO WS-INDMENS */
                WS_INDMENS.Value = WS_INDMENS + 1;

                /*" -935- MOVE '* FALTA REG TRAILLER ** ERRO GRAVISSIMO *' TO WS-MENS (WS-INDMENS) WS-NOME-LK-CRITICA */
                _.Move("* FALTA REG TRAILLER ** ERRO GRAVISSIMO *", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                /*" -936- MOVE WS-CONT-REG-LIDOS TO WS-NREG (WS-INDMENS) */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMAS.WS_NREG[WS_INDMENS]);

                /*" -937- MOVE ZEROS TO WS-PROP (WS-INDMENS) */
                _.Move(0, WS_REGPROBLEMAS.WS_PROP[WS_INDMENS]);

                /*" -939- END-IF. */
            }


            /*" -943- IF WS-ACHEI-HEADER EQUAL 'N' AND WS-ACHEI-TRAILER EQUAL 'N' AND WS-CONT-HEADER EQUAL ZEROS AND WS-CONT-TRAILER EQUAL ZEROS */

            if (WS_ACHEI_HEADER == "N" && WS_ACHEI_TRAILER == "N" && WS_CONT_HEADER == 00 && WS_CONT_TRAILER == 00)
            {

                /*" -944- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -945- MOVE WS-CONT-REG-LIDOS TO WS-REGPROBLEMA */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMA);

                /*" -946- ADD 1 TO WS-INDMENS */
                WS_INDMENS.Value = WS_INDMENS + 1;

                /*" -949- MOVE '* HEADER E TRAILER INEXISTENTES--GRAVE *' TO WS-MENS (WS-INDMENS) WS-NOME-LK-CRITICA */
                _.Move("* HEADER E TRAILER INEXISTENTES--GRAVE *", WS_MENSAGEM.WS_MENS[WS_INDMENS], WS_NOME_LK_CRITICA);

                /*" -950- MOVE WS-CONT-REG-LIDOS TO WS-NREG (WS-INDMENS) */
                _.Move(WS_CONT_REG_LIDOS, WS_REGPROBLEMAS.WS_NREG[WS_INDMENS]);

                /*" -951- MOVE ZEROS TO WS-PROP (WS-INDMENS) */
                _.Move(0, WS_REGPROBLEMAS.WS_PROP[WS_INDMENS]);

                /*" -953- END-IF. */
            }


            /*" -955- IF WS-FIM-MOVTO = 'FIM' AND RETURN-CODE = ZEROS */

            if (WS_FIM_MOVTO == "FIM" && RETURN_CODE == 00)
            {

                /*" -959- COMPUTE WS-TOT-GERAL-PROP = ( WS-TOT-GERAL-PROP + WS-QTDE-PROP-56 ) */
                WS_TOT_GERAL_PROP.Value = (WS_TOT_GERAL_PROP + WS_QTDE_PROP_56);

                /*" -961- DISPLAY '*************************************************' '******************************' */
                _.Display($"*******************************************************************************");

                /*" -963- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -965- DISPLAY '*                   PF0112B - GERANDO O ARQUIVO D' 'E BILHETES                   *' */
                _.Display($"*                   PF0112B - GERANDO O ARQUIVO DE BILHETES                   *");

                /*" -967- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -969- DISPLAY '*                    RETURN-CODE = 000 - ARQUIVO ' 'GERADO OK                    *' */
                _.Display($"*                    RETURN-CODE = 000 - ARQUIVO GERADO OK                    *");

                /*" -971- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -973- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -975- DISPLAY '*              QTDE DE REGS LIDOS NO ARQ MJUNMOV.' '..... ' WS-CONT-REG-LIDOS '              *' */

                $"*              QTDE DE REGS LIDOS NO ARQ MJUNMOV...... {WS_CONT_REG_LIDOS}              *"
                .Display();

                /*" -977- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -979- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -981- DISPLAY '*              QTDE DE REGS GERADOS NO ARQ BILHET' 'ES... ' WS-QTDE-GRAV-BILHETES '              *' */

                $"*              QTDE DE REGS GERADOS NO ARQ BILHETES... {WS_QTDE_GRAV_BILHETES}              *"
                .Display();

                /*" -983- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -985- DISPLAY '*              QTDE DE PROPOSTAS DO PRODUTO 56...' '..... ' WS-QTDE-PROP-56 '              *' */

                $"*              QTDE DE PROPOSTAS DO PRODUTO 56........ {WS_QTDE_PROP_56}              *"
                .Display();

                /*" -987- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -989- DISPLAY '*              TOTAL GERAL DE PROPOSTAS GERADAS..' '..... ' WS-TOT-GERAL-PROP '              *' */

                $"*              TOTAL GERAL DE PROPOSTAS GERADAS....... {WS_TOT_GERAL_PROP}              *"
                .Display();

                /*" -991- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -993- DISPLAY '*************************************************' '******************************' */
                _.Display($"*******************************************************************************");

                /*" -995- DISPLAY '*                               TERMINO  NORMAL  ' '                             *' */
                _.Display($"*                               TERMINO  NORMAL                               *");

                /*" -997- DISPLAY '*************************************************' '******************************' */
                _.Display($"*******************************************************************************");

                /*" -998- DISPLAY '*' */
                _.Display($"*");

                /*" -999- ELSE */
            }
            else
            {


                /*" -1001- DISPLAY RETURN-CODE */
                _.Display(RETURN_CODE);

                /*" -1003- DISPLAY '*************************************************' '******************************' */
                _.Display($"*******************************************************************************");

                /*" -1005- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1007- DISPLAY '*                      PF0112B - VIDA --> LENDO O' ' MJUNMOV                     *' */
                _.Display($"*                      PF0112B - VIDA --> LENDO O MJUNMOV                     *");

                /*" -1009- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1011- DISPLAY '*              O ARQUIVO GERADO PELA EQUIPE SIGPF' ' CONTEM CRITICAS             *' */
                _.Display($"*              O ARQUIVO GERADO PELA EQUIPE SIGPF CONTEM CRITICAS             *");

                /*" -1013- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1015- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1017- DISPLAY '*************************************************' '******************************' */
                _.Display($"*******************************************************************************");

                /*" -1019- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1021- DISPLAY '*               ----------   PROBLEMAS ENCONTRADO' 'S   ----------               *' */
                _.Display($"*               ----------   PROBLEMAS ENCONTRADOS   ----------               *");

                /*" -1025- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1026- IF WS-NREG (1) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[1] > 00)
                {

                    /*" -1028- DISPLAY '* PROP/REG = ' WS-PROP (1) ' ' WS-NREG (1) ' (' WS-MENS (1) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[1]} {WS_REGPROBLEMAS.WS_NREG[1]} ({WS_MENSAGEM.WS_MENS[1]})*"
                    .Display();

                    /*" -1029- END-IF */
                }


                /*" -1030- IF WS-NREG (2) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[2] > 00)
                {

                    /*" -1032- DISPLAY '* PROP/REG = ' WS-PROP (2) ' ' WS-NREG (2) ' (' WS-MENS (2) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[2]} {WS_REGPROBLEMAS.WS_NREG[2]} ({WS_MENSAGEM.WS_MENS[2]})*"
                    .Display();

                    /*" -1033- END-IF */
                }


                /*" -1034- IF WS-NREG (3) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[3] > 00)
                {

                    /*" -1036- DISPLAY '* PROP/REG = ' WS-PROP (3) ' ' WS-NREG (3) ' (' WS-MENS (3) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[3]} {WS_REGPROBLEMAS.WS_NREG[3]} ({WS_MENSAGEM.WS_MENS[3]})*"
                    .Display();

                    /*" -1037- END-IF */
                }


                /*" -1038- IF WS-NREG (4) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[4] > 00)
                {

                    /*" -1040- DISPLAY '* PROP/REG = ' WS-PROP (4) ' ' WS-NREG (4) ' (' WS-MENS (4) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[4]} {WS_REGPROBLEMAS.WS_NREG[4]} ({WS_MENSAGEM.WS_MENS[4]})*"
                    .Display();

                    /*" -1041- END-IF */
                }


                /*" -1042- IF WS-NREG (5) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[5] > 00)
                {

                    /*" -1044- DISPLAY '* PROP/REG = ' WS-PROP (5) ' ' WS-NREG (5) ' (' WS-MENS (5) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[5]} {WS_REGPROBLEMAS.WS_NREG[5]} ({WS_MENSAGEM.WS_MENS[5]})*"
                    .Display();

                    /*" -1045- END-IF */
                }


                /*" -1046- IF WS-NREG (6) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[6] > 00)
                {

                    /*" -1048- DISPLAY '* PROP/REG = ' WS-PROP (6) ' ' WS-NREG (6) ' (' WS-MENS (6) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[6]} {WS_REGPROBLEMAS.WS_NREG[6]} ({WS_MENSAGEM.WS_MENS[6]})*"
                    .Display();

                    /*" -1049- END-IF */
                }


                /*" -1050- IF WS-NREG (7) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[7] > 00)
                {

                    /*" -1052- DISPLAY '* PROP/REG = ' WS-PROP (7) ' ' WS-NREG (7) ' (' WS-MENS (7) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[7]} {WS_REGPROBLEMAS.WS_NREG[7]} ({WS_MENSAGEM.WS_MENS[7]})*"
                    .Display();

                    /*" -1053- END-IF */
                }


                /*" -1054- IF WS-NREG (8) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[8] > 00)
                {

                    /*" -1056- DISPLAY '* PROP/REG = ' WS-PROP (8) ' ' WS-NREG (8) ' (' WS-MENS (8) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[8]} {WS_REGPROBLEMAS.WS_NREG[8]} ({WS_MENSAGEM.WS_MENS[8]})*"
                    .Display();

                    /*" -1057- END-IF */
                }


                /*" -1058- IF WS-NREG (9) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[9] > 00)
                {

                    /*" -1060- DISPLAY '* PROP/REG = ' WS-PROP (9) ' ' WS-NREG (9) ' (' WS-MENS (9) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[9]} {WS_REGPROBLEMAS.WS_NREG[9]} ({WS_MENSAGEM.WS_MENS[9]})*"
                    .Display();

                    /*" -1061- END-IF */
                }


                /*" -1062- IF WS-NREG (10) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[10] > 00)
                {

                    /*" -1064- DISPLAY '* PROP/REG = ' WS-PROP (10) ' ' WS-NREG (10) ' (' WS-MENS (10) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[10]} {WS_REGPROBLEMAS.WS_NREG[10]} ({WS_MENSAGEM.WS_MENS[10]})*"
                    .Display();

                    /*" -1065- END-IF */
                }


                /*" -1066- IF WS-NREG (11) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[11] > 00)
                {

                    /*" -1068- DISPLAY '* PROP/REG = ' WS-PROP (11) ' ' WS-NREG (11) ' (' WS-MENS (11) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[11]} {WS_REGPROBLEMAS.WS_NREG[11]} ({WS_MENSAGEM.WS_MENS[11]})*"
                    .Display();

                    /*" -1069- END-IF */
                }


                /*" -1070- IF WS-NREG (12) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[12] > 00)
                {

                    /*" -1072- DISPLAY '* PROP/REG = ' WS-PROP (12) ' ' WS-NREG (12) ' (' WS-MENS (12) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[12]} {WS_REGPROBLEMAS.WS_NREG[12]} ({WS_MENSAGEM.WS_MENS[12]})*"
                    .Display();

                    /*" -1073- END-IF */
                }


                /*" -1074- IF WS-NREG (13) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[13] > 00)
                {

                    /*" -1076- DISPLAY '* PROP/REG = ' WS-PROP (13) ' ' WS-NREG (13) ' (' WS-MENS (13) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[13]} {WS_REGPROBLEMAS.WS_NREG[13]} ({WS_MENSAGEM.WS_MENS[13]})*"
                    .Display();

                    /*" -1077- END-IF */
                }


                /*" -1078- IF WS-NREG (14) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[14] > 00)
                {

                    /*" -1080- DISPLAY '* PROP/REG = ' WS-PROP (14) ' ' WS-NREG (14) ' (' WS-MENS (14) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[14]} {WS_REGPROBLEMAS.WS_NREG[14]} ({WS_MENSAGEM.WS_MENS[14]})*"
                    .Display();

                    /*" -1081- END-IF */
                }


                /*" -1082- IF WS-NREG (15) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[15] > 00)
                {

                    /*" -1084- DISPLAY '* PROP/REG = ' WS-PROP (15) ' ' WS-NREG (15) ' (' WS-MENS (15) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[15]} {WS_REGPROBLEMAS.WS_NREG[15]} ({WS_MENSAGEM.WS_MENS[15]})*"
                    .Display();

                    /*" -1085- END-IF */
                }


                /*" -1086- IF WS-NREG (16) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[16] > 00)
                {

                    /*" -1088- DISPLAY '* PROP/REG = ' WS-PROP (16) ' ' WS-NREG (16) ' (' WS-MENS (16) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[16]} {WS_REGPROBLEMAS.WS_NREG[16]} ({WS_MENSAGEM.WS_MENS[16]})*"
                    .Display();

                    /*" -1089- END-IF */
                }


                /*" -1090- IF WS-NREG (17) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[17] > 00)
                {

                    /*" -1092- DISPLAY '* PROP/REG = ' WS-PROP (17) ' ' WS-NREG (17) ' (' WS-MENS (17) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[17]} {WS_REGPROBLEMAS.WS_NREG[17]} ({WS_MENSAGEM.WS_MENS[17]})*"
                    .Display();

                    /*" -1093- END-IF */
                }


                /*" -1094- IF WS-NREG (18) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[18] > 00)
                {

                    /*" -1096- DISPLAY '* PROP/REG = ' WS-PROP (18) ' ' WS-NREG (18) ' (' WS-MENS (18) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[18]} {WS_REGPROBLEMAS.WS_NREG[18]} ({WS_MENSAGEM.WS_MENS[18]})*"
                    .Display();

                    /*" -1097- END-IF */
                }


                /*" -1098- IF WS-NREG (19) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[19] > 00)
                {

                    /*" -1100- DISPLAY '* PROP/REG = ' WS-PROP (19) ' ' WS-NREG (19) ' (' WS-MENS (19) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[19]} {WS_REGPROBLEMAS.WS_NREG[19]} ({WS_MENSAGEM.WS_MENS[19]})*"
                    .Display();

                    /*" -1101- END-IF */
                }


                /*" -1102- IF WS-NREG (20) GREATER ZEROS */

                if (WS_REGPROBLEMAS.WS_NREG[20] > 00)
                {

                    /*" -1104- DISPLAY '* PROP/REG = ' WS-PROP (20) ' ' WS-NREG (20) ' (' WS-MENS (20) ')*' */

                    $"* PROP/REG = {WS_REGPROBLEMAS.WS_PROP[20]} {WS_REGPROBLEMAS.WS_NREG[20]} ({WS_MENSAGEM.WS_MENS[20]})*"
                    .Display();

                    /*" -1106- END-IF */
                }


                /*" -1108- END-IF. */
            }


            /*" -1109- IF WS-NREG (1) GREATER ZEROS */

            if (WS_REGPROBLEMAS.WS_NREG[1] > 00)
            {

                /*" -1111- DISPLAY '*                                                ' '                             *' */
                _.Display($"*                                                                             *");

                /*" -1113- DISPLAY '*************************************************' '******************************' */
                _.Display($"*******************************************************************************");

                /*" -1116- END-IF. */
            }


            /*" -1116- CLOSE MVJUNMOV, BILHETES. */
            MVJUNMOV.Close();
            BILHETES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/
    }
}