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
using Sias.Sinistro.DB2.SI0863B;

namespace Code
{
    public class SI0863B
    {
        public bool IsCall { get; set; }

        public SI0863B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *  *-------------------------------------------------------------*      */
        /*"      *  *                                                             *      */
        /*"      *  *     SISTEMA............. SINISTROS                          *      */
        /*"      *  *     PROGRAMA............ SI0863B                            *      */
        /*"      *  *     ANALISTA/PROGRAMADOR HEIDER                             *      */
        /*"      *  *                                                             *      */
        /*"      *  *     FUNCAO.............. GERA DA CARTA DE AVISO DE SINISTRO *      */
        /*"      *  *     DE VIDA, ENDERECADA AO RECLAMANTE DO SINISTRO           *      */
        /*"      *  *-------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM JULHO/2004 - PRODEXTER (VANDO)                    *      */
        /*"      * CONVERSAO A5 PARA A4 - TRATAMENTO CIF/POSTNET                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *---------------------                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0863BA { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0863BA
        {
            get
            {
                _.Move(REG_SI0863BA, _SI0863BA); VarBasis.RedefinePassValue(REG_SI0863BA, _SI0863BA, REG_SI0863BA); return _SI0863BA;
            }
        }
        /*"01  REG-SI0863BA.*/
        public SI0863B_REG_SI0863BA REG_SI0863BA { get; set; } = new SI0863B_REG_SI0863BA();
        public class SI0863B_REG_SI0863BA : VarBasis
        {
            /*"    05 FILLER                         PIC X(3500).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1SIST-DTCURRENT                 PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  VIND-PRODUTO                     PIC S9(04) COMP   VALUE +0.*/
        public IntBasis VIND_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-HISTSINI                    PIC S9(09) COMP   VALUE +0.*/
        public IntBasis HOST_HISTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01              AREA-DE-WORK.*/
        public SI0863B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0863B_AREA_DE_WORK();
        public class SI0863B_AREA_DE_WORK : VarBasis
        {
            /*"    05 FILLER          PIC  X(035)    VALUE       'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"    05 WFIM-CARTA-AVISO              PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_CARTA_AVISO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-SEQUENCIA                   PIC 9(06) VALUE ZEROS.*/
            public IntBasis W_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 W-CONTA-REG-GERADOS           PIC 9(06) VALUE ZEROS.*/
            public IntBasis W_CONTA_REG_GERADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 W-CEP-INTEIRO                 PIC 9(08).*/
            public IntBasis W_CEP_INTEIRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05 W-CEP-FILLER    REDEFINES  W-CEP-INTEIRO.*/
            private _REDEF_SI0863B_W_CEP_FILLER _w_cep_filler { get; set; }
            public _REDEF_SI0863B_W_CEP_FILLER W_CEP_FILLER
            {
                get { _w_cep_filler = new _REDEF_SI0863B_W_CEP_FILLER(); _.Move(W_CEP_INTEIRO, _w_cep_filler); VarBasis.RedefinePassValue(W_CEP_INTEIRO, _w_cep_filler, W_CEP_INTEIRO); _w_cep_filler.ValueChanged += () => { _.Move(_w_cep_filler, W_CEP_INTEIRO); }; return _w_cep_filler; }
                set { VarBasis.RedefinePassValue(value, _w_cep_filler, W_CEP_INTEIRO); }
            }  //Redefines
            public class _REDEF_SI0863B_W_CEP_FILLER : VarBasis
            {
                /*"       10 W-CEP-PARTE-1              PIC 9(05).*/
                public IntBasis W_CEP_PARTE_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"       10 W-CEP-PARTE-2              PIC 9(03).*/
                public IntBasis W_CEP_PARTE_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"  05        WABEND.*/
                public SI0863B_WABEND WABEND { get; set; } = new SI0863B_WABEND();
                public class SI0863B_WABEND : VarBasis
                {
                    /*"    10      FILLER              PIC  X(010) VALUE ' SI0510B'.*/
                }

                public _REDEF_SI0863B_W_CEP_FILLER()
                {
                    W_CEP_PARTE_1.ValueChanged += OnValueChanged;
                    W_CEP_PARTE_2.ValueChanged += OnValueChanged;
                    WABEND.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0510B");
            /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    10      FILLER              PIC  X(013) VALUE ' *** SQLCODE'*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE");
            /*"    10      WSQLCODE            PIC -------999 VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
            /*"01  LC01.*/
        }
        public SI0863B_LC01 LC01 { get; set; } = new SI0863B_LC01();
        public class SI0863B_LC01 : VarBasis
        {
            /*"    05 LC01-CEP-CONTROLE             PIC 9(08) VALUE ZEROS.*/
            public IntBasis LC01_CEP_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 LC01-SEQ-CONTROLE             PIC 9(06) VALUE ZEROS.*/
            public IntBasis LC01_SEQ_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 LC01-CARTAO-CONTROLE          PIC 9(03) VALUE 1.*/
            public IntBasis LC01_CARTAO_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 1);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FILLER                        PIC X(14) VALUE       '%! 100134700-6'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"%! 100134700-6");
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 LC01-POSICAO-REMETENTE        PIC 9(04) VALUE 101.*/
            public IntBasis LC01_POSICAO_REMETENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 101);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FILLER                        PIC X(40) VALUE       'CAIXA SEGUROS - GEPES'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"CAIXA SEGUROS - GEPES");
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FILLER                        PIC X(30) VALUE       'EDIFICIO NUMBER ONE 12. ANDAR'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"EDIFICIO NUMBER ONE 12. ANDAR");
            /*"01  LC02.*/
        }
        public SI0863B_LC02 LC02 { get; set; } = new SI0863B_LC02();
        public class SI0863B_LC02 : VarBasis
        {
            /*"    05 LC02-CEP-CONTROLE             PIC 9(08) VALUE ZEROS.*/
            public IntBasis LC02_CEP_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 LC02-SEQ-CONTROLE             PIC 9(06) VALUE ZEROS.*/
            public IntBasis LC02_SEQ_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 LC02-CARTAO-CONTROLE          PIC 9(03) VALUE 2.*/
            public IntBasis LC02_CARTAO_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 2);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FILLER                        PIC X(12) VALUE       '(|) SETDBSEP'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"(|) SETDBSEP");
            /*"01  LC03.*/
        }
        public SI0863B_LC03 LC03 { get; set; } = new SI0863B_LC03();
        public class SI0863B_LC03 : VarBasis
        {
            /*"    05 LC03-CEP-CONTROLE             PIC 9(08) VALUE ZEROS.*/
            public IntBasis LC03_CEP_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 LC03-SEQ-CONTROLE             PIC 9(06) VALUE ZEROS.*/
            public IntBasis LC03_SEQ_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 LC03-CARTAO-CONTROLE          PIC 9(03) VALUE 3.*/
            public IntBasis LC03_CARTAO_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 3);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FILLER                        PIC X(19) VALUE       '(va40.dbm) STARTDBM'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"(va40.dbm) STARTDBM");
            /*"01  LC04.*/
        }
        public SI0863B_LC04 LC04 { get; set; } = new SI0863B_LC04();
        public class SI0863B_LC04 : VarBasis
        {
            /*"    05 LC04-CEP-CONTROLE             PIC 9(08) VALUE ZEROS.*/
            public IntBasis LC04_CEP_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 LC04-SEQ-CONTROLE             PIC 9(06) VALUE ZEROS.*/
            public IntBasis LC04_SEQ_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 LC04-CARTAO-CONTROLE          PIC 9(03) VALUE 4.*/
            public IntBasis LC04_CARTAO_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 4);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 VA40-HEADER.*/
            public SI0863B_VA40_HEADER VA40_HEADER { get; set; } = new SI0863B_VA40_HEADER();
            public class SI0863B_VA40_HEADER : VarBasis
            {
                /*"       10 FILLER                     PIC X(99) VALUE       'CLIENTE|DTPOSTAGEM|NUMOBJETO|DESTINATARIO|ENDERECO|BAIRRO       '|CIDADE|UF|CEP|REMETENTE|REMET-ENDERECO|RE'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "99", "X(99)"), @"CLIENTE|DTPOSTAGEM|NUMOBJETO|DESTINATARIO|ENDERECO|BAIRRO       ");
                /*"       10 FILLER                     PIC X(99) VALUE       'MET-BAIRRO|REMET-CIDADE|REMET-UF|REMET-CEP|CODIGO-CIF|POS       'TNET'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "99", "X(99)"), @"MET_BAIRRO|REMET_CIDADE|REMET_UF|REMET_CEP|CODIGO_CIF|POS       ");
                /*"01  LD01.*/
            }
        }
        public SI0863B_LD01 LD01 { get; set; } = new SI0863B_LD01();
        public class SI0863B_LD01 : VarBasis
        {
            /*"    05 LD01-CEP-CONTROLE             PIC 9(08) VALUE ZEROS.*/
            public IntBasis LD01_CEP_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 LD01-SEQ-CONTROLE             PIC 9(06) VALUE ZEROS.*/
            public IntBasis LD01_SEQ_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 LD01-CARTAO-CONTROLE          PIC 9(03) VALUE 5.*/
            public IntBasis LD01_CARTAO_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 5);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 VA40-REGISTRO.*/
            public SI0863B_VA40_REGISTRO VA40_REGISTRO { get; set; } = new SI0863B_VA40_REGISTRO();
            public class SI0863B_VA40_REGISTRO : VarBasis
            {
                /*"       10 LD01-CLIENTE-ES            PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_CLIENTE_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-REMETENTE-ES          PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_REMETENTE_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-REMET-ENDERECO-ES     PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_REMET_ENDERECO_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-REMET-BAIRRO-ES       PIC X(20) VALUE SPACES.*/
                public StringBasis LD01_REMET_BAIRRO_ES { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-REMET-CIDADE-ES       PIC X(20) VALUE SPACES.*/
                public StringBasis LD01_REMET_CIDADE_ES { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-REMET-UF-ES           PIC X(02) VALUE SPACES.*/
                public StringBasis LD01_REMET_UF_ES { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-REMET-CEP-ES.*/
                public SI0863B_LD01_REMET_CEP_ES LD01_REMET_CEP_ES { get; set; } = new SI0863B_LD01_REMET_CEP_ES();
                public class SI0863B_LD01_REMET_CEP_ES : VarBasis
                {
                    /*"          15 LD01-REMET-ES-PARTE-1   PIC 99999.*/
                    public IntBasis LD01_REMET_ES_PARTE_1 { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                    /*"          15 FILLER                  PIC X(01) VALUE '-'.*/
                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                    /*"          15 LD01-REMET-ES-PARTE-2   PIC 999.*/
                    public IntBasis LD01_REMET_ES_PARTE_2 { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                }
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-DTPOSTAGEM-ES         PIC X(10) VALUE          'XX/XX/XXXX'.*/
                public StringBasis LD01_DTPOSTAGEM_ES { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"XX/XX/XXXX");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-NUMOBJETO-ES          PIC X(07) VALUE          'XXX.XXX'.*/
                public StringBasis LD01_NUMOBJETO_ES { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"XXX.XXX");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-DESTINATARIO-ES       PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_DESTINATARIO_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-ENDERECO-ES           PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_ENDERECO_ES { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-BAIRRO-ES             PIC X(20) VALUE SPACES.*/
                public StringBasis LD01_BAIRRO_ES { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-CIDADE-ES             PIC X(20) VALUE SPACES.*/
                public StringBasis LD01_CIDADE_ES { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-UF-ES                 PIC X(02) VALUE SPACES.*/
                public StringBasis LD01_UF_ES { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-CEP-ES.*/
                public SI0863B_LD01_CEP_ES LD01_CEP_ES { get; set; } = new SI0863B_LD01_CEP_ES();
                public class SI0863B_LD01_CEP_ES : VarBasis
                {
                    /*"          15 LD01-CEP-ES-PARTE-1     PIC 99999.*/
                    public IntBasis LD01_CEP_ES_PARTE_1 { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                    /*"          15 FILLER                  PIC X(01) VALUE '-'.*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                    /*"          15 LD01-CEP-ES-PARTE-2     PIC 999.*/
                    public IntBasis LD01_CEP_ES_PARTE_2 { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                }
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-CODIGO-CIF-ES         PIC X(34) VALUE SPACES.*/
                public StringBasis LD01_CODIGO_CIF_ES { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"       10 LD01-POSTNET-ES            PIC X(11) VALUE SPACES.*/
                public StringBasis LD01_POSTNET_ES { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
                /*"01  LR01.*/
            }
        }
        public SI0863B_LR01 LR01 { get; set; } = new SI0863B_LR01();
        public class SI0863B_LR01 : VarBasis
        {
            /*"    05 LR01-CEP-CONTROLE             PIC 9(08) VALUE 99999999.*/
            public IntBasis LR01_CEP_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"), 99999999);
            /*"    05 LR01-SEQ-CONTROLE             PIC 9(06) VALUE ZEROS.*/
            public IntBasis LR01_SEQ_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 LR01-CARTAO-CONTROLE          PIC 9(03) VALUE 6.*/
            public IntBasis LR01_CARTAO_CONTROLE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 6);
            /*"    05 FILLER                        PIC X(01) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FILLER                        PIC X(05) VALUE       '%%EOF'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"%%EOF");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINBENCB SINBENCB { get; set; } = new Dclgens.SINBENCB();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.PAROPESI PAROPESI { get; set; } = new Dclgens.PAROPESI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public SI0863B_CARTA_AVISO CARTA_AVISO { get; set; } = new SI0863B_CARTA_AVISO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0863BA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0863BA.SetFile(SI0863BA_FILE_NAME_P);

                /*" -326- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -327- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -328- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -332- PERFORM R010-SELECT-SISTEMAS THRU R010-EXIT. */

                R010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -333- MOVE 'NAO' TO WFIM-CARTA-AVISO. */
                _.Move("NAO", AREA_DE_WORK.WFIM_CARTA_AVISO);

                /*" -334- PERFORM R020-DECLARE-CARTA-SINISTRO THRU R020-EXIT. */

                R020_DECLARE_CARTA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -336- PERFORM R021-FETCH-CARTA-SINISTRO THRU R021-EXIT. */

                R021_FETCH_CARTA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -337- IF WFIM-CARTA-AVISO EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_CARTA_AVISO == "SIM")
                {

                    /*" -338- DISPLAY '********************************' */
                    _.Display($"********************************");

                    /*" -339- DISPLAY '*                              *' */
                    _.Display($"*                              *");

                    /*" -340- DISPLAY '*      PROGRAMA - SI0863B      *' */
                    _.Display($"*      PROGRAMA - SI0863B      *");

                    /*" -341- DISPLAY '*                              *' */
                    _.Display($"*                              *");

                    /*" -342- DISPLAY '*        FIM NORMAL            *' */
                    _.Display($"*        FIM NORMAL            *");

                    /*" -343- DISPLAY '*                              *' */
                    _.Display($"*                              *");

                    /*" -344- DISPLAY '*  NAO HOUVE MOVIMENTO PARA    *' */
                    _.Display($"*  NAO HOUVE MOVIMENTO PARA    *");

                    /*" -345- DISPLAY '*       PROCESSAMENTO          *' */
                    _.Display($"*       PROCESSAMENTO          *");

                    /*" -346- DISPLAY '*                              *' */
                    _.Display($"*                              *");

                    /*" -347- DISPLAY '********************************' */
                    _.Display($"********************************");

                    /*" -349- GO TO M-999-FINALIZACAO. */

                    M_999_FINALIZACAO(); //GOTO
                    return Result;
                }


                /*" -351- OPEN OUTPUT SI0863BA. */
                SI0863BA.Open(REG_SI0863BA);

                /*" -352- WRITE REG-SI0863BA FROM LC01. */
                _.Move(LC01.GetMoveValues(), REG_SI0863BA);

                SI0863BA.Write(REG_SI0863BA.GetMoveValues().ToString());

                /*" -353- WRITE REG-SI0863BA FROM LC02. */
                _.Move(LC02.GetMoveValues(), REG_SI0863BA);

                SI0863BA.Write(REG_SI0863BA.GetMoveValues().ToString());

                /*" -354- WRITE REG-SI0863BA FROM LC03. */
                _.Move(LC03.GetMoveValues(), REG_SI0863BA);

                SI0863BA.Write(REG_SI0863BA.GetMoveValues().ToString());

                /*" -356- WRITE REG-SI0863BA FROM LC04. */
                _.Move(LC04.GetMoveValues(), REG_SI0863BA);

                SI0863BA.Write(REG_SI0863BA.GetMoveValues().ToString());

                /*" -359- PERFORM R100-PROCESSA-CARTA-AVISO THRU R100-EXIT UNTIL WFIM-CARTA-AVISO EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_CARTA_AVISO == "SIM"))
                {

                    R100_PROCESSA_CARTA_AVISO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -361- WRITE REG-SI0863BA FROM LR01. */
                _.Move(LR01.GetMoveValues(), REG_SI0863BA);

                SI0863BA.Write(REG_SI0863BA.GetMoveValues().ToString());

                /*" -361- CLOSE SI0863BA. */
                SI0863BA.Close();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-999-FINALIZACAO */
        private void M_999_FINALIZACAO(bool isPerform = false)
        {
            /*" -366- DISPLAY ' ' . */
            _.Display($" ");

            /*" -367- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -368- DISPLAY '*  TERMINO NORMAL DO PROGRAMA SI0863B   *' . */
            _.Display($"*  TERMINO NORMAL DO PROGRAMA SI0863B   *");

            /*" -369- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -370- DISPLAY ' ' . */
            _.Display($" ");

            /*" -372- DISPLAY 'DOC. LIDOS / GERADOS = ' W-CONTA-REG-GERADOS. */
            _.Display($"DOC. LIDOS / GERADOS = {AREA_DE_WORK.W_CONTA_REG_GERADOS}");

            /*" -372- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -377- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -377- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMAS */
        private void R010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -384- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -389- PERFORM R010_SELECT_SISTEMAS_DB_SELECT_1 */

            R010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- DISPLAY 'ERRO SELECT SISTEMAS' */
                _.Display($"ERRO SELECT SISTEMAS");

                /*" -393- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -389- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R010_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-DECLARE-CARTA-SINISTRO */
        private void R020_DECLARE_CARTA_SINISTRO(bool isPerform = false)
        {
            /*" -405- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -428- PERFORM R020_DECLARE_CARTA_SINISTRO_DB_DECLARE_1 */

            R020_DECLARE_CARTA_SINISTRO_DB_DECLARE_1();

            /*" -430- PERFORM R020_DECLARE_CARTA_SINISTRO_DB_OPEN_1 */

            R020_DECLARE_CARTA_SINISTRO_DB_OPEN_1();

            /*" -433- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -434- DISPLAY 'ERRO NO OPEN DO DECLARE CARTA_AVISO' */
                _.Display($"ERRO NO OPEN DO DECLARE CARTA_AVISO");

                /*" -434- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R020-DECLARE-CARTA-SINISTRO-DB-DECLARE-1 */
        public void R020_DECLARE_CARTA_SINISTRO_DB_DECLARE_1()
        {
            /*" -428- EXEC SQL DECLARE CARTA_AVISO CURSOR FOR SELECT A.NUM_APOLICE, A.NUM_SINISTRO, A.NUM_BILHETE, A.OCORR_HISTORICO, A.DTMOVTO, A.NOME_BENEFICIARIO, A.ENDERECO, A.BAIRRO, A.CIDADE, A.SIGLA_UF, A.CEP, M.COD_PRODUTO FROM SEGUROS.SINI_BENEF_CBASICA A, SEGUROS.SINISTRO_MESTRE M WHERE A.SIT_REGISTRO = 'A' AND M.NUM_APOL_SINISTRO = A.NUM_SINISTRO END-EXEC. */
            CARTA_AVISO = new SI0863B_CARTA_AVISO(false);
            string GetQuery_CARTA_AVISO()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_SINISTRO
							, 
							A.NUM_BILHETE
							, 
							A.OCORR_HISTORICO
							, 
							A.DTMOVTO
							, 
							A.NOME_BENEFICIARIO
							, 
							A.ENDERECO
							, 
							A.BAIRRO
							, 
							A.CIDADE
							, 
							A.SIGLA_UF
							, 
							A.CEP
							, 
							M.COD_PRODUTO 
							FROM SEGUROS.SINI_BENEF_CBASICA A
							, 
							SEGUROS.SINISTRO_MESTRE M 
							WHERE A.SIT_REGISTRO = 'A' 
							AND M.NUM_APOL_SINISTRO = A.NUM_SINISTRO";

                return query;
            }
            CARTA_AVISO.GetQueryEvent += GetQuery_CARTA_AVISO;

        }

        [StopWatch]
        /*" R020-DECLARE-CARTA-SINISTRO-DB-OPEN-1 */
        public void R020_DECLARE_CARTA_SINISTRO_DB_OPEN_1()
        {
            /*" -430- EXEC SQL OPEN CARTA_AVISO END-EXEC. */

            CARTA_AVISO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-CARTA-SINISTRO */
        private void R021_FETCH_CARTA_SINISTRO(bool isPerform = false)
        {
            /*" -442- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -455- PERFORM R021_FETCH_CARTA_SINISTRO_DB_FETCH_1 */

            R021_FETCH_CARTA_SINISTRO_DB_FETCH_1();

            /*" -458- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -460- ADD 1 TO W-CONTA-REG-GERADOS. */
                AREA_DE_WORK.W_CONTA_REG_GERADOS.Value = AREA_DE_WORK.W_CONTA_REG_GERADOS + 1;
            }


            /*" -461- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -462- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -463- MOVE 'SIM' TO WFIM-CARTA-AVISO */
                    _.Move("SIM", AREA_DE_WORK.WFIM_CARTA_AVISO);

                    /*" -463- PERFORM R021_FETCH_CARTA_SINISTRO_DB_CLOSE_1 */

                    R021_FETCH_CARTA_SINISTRO_DB_CLOSE_1();

                    /*" -465- ELSE */
                }
                else
                {


                    /*" -466- DISPLAY 'ERRO FETCH SINI_BENEF_CBASICA' */
                    _.Display($"ERRO FETCH SINI_BENEF_CBASICA");

                    /*" -467- DISPLAY 'SINISTRO =  ' SINBENCB-NUM-SINISTRO */
                    _.Display($"SINISTRO =  {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

                    /*" -468- DISPLAY 'BILHETE  =  ' SINBENCB-NUM-BILHETE */
                    _.Display($"BILHETE  =  {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE}");

                    /*" -469- DISPLAY 'OCORHIST =  ' SINBENCB-OCORR-HISTORICO */
                    _.Display($"OCORHIST =  {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO}");

                    /*" -469- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R021-FETCH-CARTA-SINISTRO-DB-FETCH-1 */
        public void R021_FETCH_CARTA_SINISTRO_DB_FETCH_1()
        {
            /*" -455- EXEC SQL FETCH CARTA_AVISO INTO :SINBENCB-NUM-APOLICE, :SINBENCB-NUM-SINISTRO, :SINBENCB-NUM-BILHETE, :SINBENCB-OCORR-HISTORICO, :SINBENCB-DTMOVTO, :SINBENCB-NOME-BENEFICIARIO, :SINBENCB-ENDERECO, :SINBENCB-BAIRRO, :SINBENCB-CIDADE, :SINBENCB-SIGLA-UF, :SINBENCB-CEP, :SINISMES-COD-PRODUTO END-EXEC. */

            if (CARTA_AVISO.Fetch())
            {
                _.Move(CARTA_AVISO.SINBENCB_NUM_APOLICE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE);
                _.Move(CARTA_AVISO.SINBENCB_NUM_SINISTRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO);
                _.Move(CARTA_AVISO.SINBENCB_NUM_BILHETE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE);
                _.Move(CARTA_AVISO.SINBENCB_OCORR_HISTORICO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO);
                _.Move(CARTA_AVISO.SINBENCB_DTMOVTO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DTMOVTO);
                _.Move(CARTA_AVISO.SINBENCB_NOME_BENEFICIARIO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NOME_BENEFICIARIO);
                _.Move(CARTA_AVISO.SINBENCB_ENDERECO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_ENDERECO);
                _.Move(CARTA_AVISO.SINBENCB_BAIRRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_BAIRRO);
                _.Move(CARTA_AVISO.SINBENCB_CIDADE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CIDADE);
                _.Move(CARTA_AVISO.SINBENCB_SIGLA_UF, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIGLA_UF);
                _.Move(CARTA_AVISO.SINBENCB_CEP, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP);
                _.Move(CARTA_AVISO.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R021-FETCH-CARTA-SINISTRO-DB-CLOSE-1 */
        public void R021_FETCH_CARTA_SINISTRO_DB_CLOSE_1()
        {
            /*" -463- EXEC SQL CLOSE CARTA_AVISO END-EXEC */

            CARTA_AVISO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-CARTA-AVISO */
        private void R100_PROCESSA_CARTA_AVISO(bool isPerform = false)
        {
            /*" -478- MOVE 'CAIXA SEGUROS - GEPES' TO LD01-REMETENTE-ES. */
            _.Move("CAIXA SEGUROS - GEPES", LD01.VA40_REGISTRO.LD01_REMETENTE_ES);

            /*" -480- MOVE 'SCN QUADRA 01 BL. A ED. NUMBER 1 13 AND' TO LD01-REMET-ENDERECO-ES. */
            _.Move("SCN QUADRA 01 BL. A ED. NUMBER 1 13 AND", LD01.VA40_REGISTRO.LD01_REMET_ENDERECO_ES);

            /*" -481- MOVE 'SETOR AUTARQ. NORTE' TO LD01-REMET-BAIRRO-ES. */
            _.Move("SETOR AUTARQ. NORTE", LD01.VA40_REGISTRO.LD01_REMET_BAIRRO_ES);

            /*" -482- MOVE 'BRASILIA' TO LD01-REMET-CIDADE-ES. */
            _.Move("BRASILIA", LD01.VA40_REGISTRO.LD01_REMET_CIDADE_ES);

            /*" -483- MOVE 'DF' TO LD01-REMET-UF-ES. */
            _.Move("DF", LD01.VA40_REGISTRO.LD01_REMET_UF_ES);

            /*" -484- MOVE 70711 TO LD01-REMET-ES-PARTE-1. */
            _.Move(70711, LD01.VA40_REGISTRO.LD01_REMET_CEP_ES.LD01_REMET_ES_PARTE_1);

            /*" -486- MOVE 900 TO LD01-REMET-ES-PARTE-2. */
            _.Move(900, LD01.VA40_REGISTRO.LD01_REMET_CEP_ES.LD01_REMET_ES_PARTE_2);

            /*" -488- MOVE SINBENCB-NOME-BENEFICIARIO TO LD01-CLIENTE-ES LD01-DESTINATARIO-ES. */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NOME_BENEFICIARIO, LD01.VA40_REGISTRO.LD01_CLIENTE_ES, LD01.VA40_REGISTRO.LD01_DESTINATARIO_ES);

            /*" -489- MOVE SINBENCB-ENDERECO TO LD01-ENDERECO-ES. */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_ENDERECO, LD01.VA40_REGISTRO.LD01_ENDERECO_ES);

            /*" -490- MOVE SINBENCB-BAIRRO TO LD01-BAIRRO-ES. */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_BAIRRO, LD01.VA40_REGISTRO.LD01_BAIRRO_ES);

            /*" -491- MOVE SINBENCB-CIDADE TO LD01-CIDADE-ES. */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CIDADE, LD01.VA40_REGISTRO.LD01_CIDADE_ES);

            /*" -493- MOVE SINBENCB-SIGLA-UF TO LD01-UF-ES. */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIGLA_UF, LD01.VA40_REGISTRO.LD01_UF_ES);

            /*" -495- MOVE SINBENCB-CEP TO LD01-CEP-CONTROLE W-CEP-INTEIRO. */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP, LD01.LD01_CEP_CONTROLE, AREA_DE_WORK.W_CEP_INTEIRO);

            /*" -496- MOVE W-CEP-PARTE-1 TO LD01-CEP-ES-PARTE-1. */
            _.Move(AREA_DE_WORK.W_CEP_FILLER.W_CEP_PARTE_1, LD01.VA40_REGISTRO.LD01_CEP_ES.LD01_CEP_ES_PARTE_1);

            /*" -502- MOVE W-CEP-PARTE-2 TO LD01-CEP-ES-PARTE-2. */
            _.Move(AREA_DE_WORK.W_CEP_FILLER.W_CEP_PARTE_2, LD01.VA40_REGISTRO.LD01_CEP_ES.LD01_CEP_ES_PARTE_2);

            /*" -503- ADD 1 TO W-SEQUENCIA. */
            AREA_DE_WORK.W_SEQUENCIA.Value = AREA_DE_WORK.W_SEQUENCIA + 1;

            /*" -505- MOVE W-SEQUENCIA TO LD01-SEQ-CONTROLE. */
            _.Move(AREA_DE_WORK.W_SEQUENCIA, LD01.LD01_SEQ_CONTROLE);

            /*" -506- WRITE REG-SI0863BA FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SI0863BA);

            SI0863BA.Write(REG_SI0863BA.GetMoveValues().ToString());

            /*" -508- PERFORM R300-GERA-OBJETO */

            R300_GERA_OBJETO(true);

            /*" -510- PERFORM R200-UPDATE-SITUACAO THRU R200-EXIT. */

            R200_UPDATE_SITUACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -510- PERFORM R021-FETCH-CARTA-SINISTRO THRU R021-EXIT. */

            R021_FETCH_CARTA_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R200-UPDATE-SITUACAO */
        private void R200_UPDATE_SITUACAO(bool isPerform = false)
        {
            /*" -518- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -525- PERFORM R200_UPDATE_SITUACAO_DB_UPDATE_1 */

            R200_UPDATE_SITUACAO_DB_UPDATE_1();

            /*" -528- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -529- DISPLAY 'ERRO UPDATE SINI_BENEF_CBASICA' */
                _.Display($"ERRO UPDATE SINI_BENEF_CBASICA");

                /*" -530- DISPLAY 'SINISTRO =  ' SINBENCB-NUM-SINISTRO */
                _.Display($"SINISTRO =  {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

                /*" -531- DISPLAY 'BILHETE  =  ' SINBENCB-NUM-BILHETE */
                _.Display($"BILHETE  =  {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE}");

                /*" -532- DISPLAY 'OCORHIST =  ' SINBENCB-OCORR-HISTORICO */
                _.Display($"OCORHIST =  {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO}");

                /*" -532- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R200-UPDATE-SITUACAO-DB-UPDATE-1 */
        public void R200_UPDATE_SITUACAO_DB_UPDATE_1()
        {
            /*" -525- EXEC SQL UPDATE SEGUROS.SINI_BENEF_CBASICA SET SIT_REGISTRO = 'B' WHERE NUM_APOLICE = :SINBENCB-NUM-APOLICE AND NUM_SINISTRO = :SINBENCB-NUM-SINISTRO AND NUM_BILHETE = :SINBENCB-NUM-BILHETE AND OCORR_HISTORICO = :SINBENCB-OCORR-HISTORICO END-EXEC. */

            var r200_UPDATE_SITUACAO_DB_UPDATE_1_Update1 = new R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1()
            {
                SINBENCB_OCORR_HISTORICO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO.ToString(),
                SINBENCB_NUM_SINISTRO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO.ToString(),
                SINBENCB_NUM_APOLICE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE.ToString(),
                SINBENCB_NUM_BILHETE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE.ToString(),
            };

            R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1.Execute(r200_UPDATE_SITUACAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R300-GERA-OBJETO */
        private void R300_GERA_OBJETO(bool isPerform = false)
        {
            /*" -540- MOVE 'VA40' TO GEOBJECT-COD-FORMULARIO. */
            _.Move("VA40", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -550- PERFORM R300_GERA_OBJETO_DB_SELECT_1 */

            R300_GERA_OBJETO_DB_SELECT_1();

            /*" -553- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -554- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -555- PERFORM R301-MONTA-HEADER */

                    R301_MONTA_HEADER(true);

                    /*" -556- PERFORM R303-INSERT-OBJETO */

                    R303_INSERT_OBJETO(true);

                    /*" -557- ELSE */
                }
                else
                {


                    /*" -558- DISPLAY 'ERRO DE ACESSO A TABELA GE_OBJETO_ECT.' */
                    _.Display($"ERRO DE ACESSO A TABELA GE_OBJETO_ECT.");

                    /*" -559- DISPLAY 'SQLCODE............... ' SQLCODE */
                    _.Display($"SQLCODE............... {DB.SQLCODE}");

                    /*" -561- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -562- PERFORM R302-MONTA-DETALHE */

            R302_MONTA_DETALHE(true);

            /*" -562- PERFORM R303-INSERT-OBJETO. */

            R303_INSERT_OBJETO(true);

        }

        [StopWatch]
        /*" R300-GERA-OBJETO-DB-SELECT-1 */
        public void R300_GERA_OBJETO_DB_SELECT_1()
        {
            /*" -550- EXEC SQL SELECT DISTINCT STA_REGISTRO INTO :GEOBJECT-STA-REGISTRO FROM SEGUROS.GE_OBJETO_ECT WHERE NUM_CEP = 0 AND NOM_PROGRAMA = 'SI0863B' AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO AND STA_REGISTRO = 'H' AND DATE(DTH_TIMESTAMP) <> '9999-12-31' ORDER BY STA_REGISTRO END-EXEC. */

            var r300_GERA_OBJETO_DB_SELECT_1_Query1 = new R300_GERA_OBJETO_DB_SELECT_1_Query1()
            {
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
            };

            var executed_1 = R300_GERA_OBJETO_DB_SELECT_1_Query1.Execute(r300_GERA_OBJETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOBJECT_STA_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R301-MONTA-HEADER */
        private void R301_MONTA_HEADER(bool isPerform = false)
        {
            /*" -569- MOVE 0 TO GEOBJECT-NUM-CEP */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -570- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
            _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -571- MOVE -1 TO VIND-PRODUTO */
            _.Move(-1, VIND_PRODUTO);

            /*" -572- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -573- MOVE 0 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -574- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -575- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -576- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -576- MOVE VA40-HEADER TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(LC04.VA40_HEADER, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R301_EXIT*/

        [StopWatch]
        /*" R302-MONTA-DETALHE */
        private void R302_MONTA_DETALHE(bool isPerform = false)
        {
            /*" -583- MOVE SINBENCB-CEP TO GEOBJECT-NUM-CEP */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -584- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -585- MOVE SINISMES-COD-PRODUTO TO GEOBJECT-COD-PRODUTO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -586- MOVE 1 TO VIND-PRODUTO */
            _.Move(1, VIND_PRODUTO);

            /*" -587- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -588- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -589- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -590- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -591- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -591- MOVE VA40-REGISTRO TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(LD01.VA40_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R302_EXIT*/

        [StopWatch]
        /*" R303-INSERT-OBJETO */
        private void R303_INSERT_OBJETO(bool isPerform = false)
        {
            /*" -614- PERFORM R303_INSERT_OBJETO_DB_INSERT_1 */

            R303_INSERT_OBJETO_DB_INSERT_1();

            /*" -617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -618- DISPLAY 'ERRO NO INSERT DA GE-OBJETO-ECT ' */
                _.Display($"ERRO NO INSERT DA GE-OBJETO-ECT ");

                /*" -620- DISPLAY 'H = HEADER D = DETALHE.' GEOBJECT-STA-REGISTRO */
                _.Display($"H = HEADER D = DETALHE.{GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}");

                /*" -621- DISPLAY 'PROGRAMA SI0863B.......' */
                _.Display($"PROGRAMA SI0863B.......");

                /*" -623- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                /*" -624- DISPLAY 'SQLCODE............... ' SQLCODE */
                _.Display($"SQLCODE............... {DB.SQLCODE}");

                /*" -624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R303-INSERT-OBJETO-DB-INSERT-1 */
        public void R303_INSERT_OBJETO_DB_INSERT_1()
        {
            /*" -614- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT VALUES (:GEOBJECT-NUM-CEP, 'SI0863B' , :GEOBJECT-COD-FORMULARIO, :GEOBJECT-STA-REGISTRO, CURRENT TIMESTAMP, :GEOBJECT-COD-PRODUTO:VIND-PRODUTO, :GEOBJECT-NUM-INI-POS-VERSO, :GEOBJECT-QTD-PESO-GRAMAS, :GEOBJECT-VLR-DECLARADO, :GEOBJECT-COD-IDENT-OBJETO, :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r303_INSERT_OBJETO_DB_INSERT_1_Insert1 = new R303_INSERT_OBJETO_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                VIND_PRODUTO = VIND_PRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R303_INSERT_OBJETO_DB_INSERT_1_Insert1.Execute(r303_INSERT_OBJETO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R303_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -635- DISPLAY ' ' . */
            _.Display($" ");

            /*" -636- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -637- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0863B  *' . */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0863B  *");

            /*" -638- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -639- DISPLAY ' ' . */
            _.Display($" ");

            /*" -641- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

            /*" -643- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.W_CEP_FILLER.WABEND);

            /*" -645- CLOSE SI0863BA. */
            SI0863BA.Close();

            /*" -645- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -649- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -649- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}