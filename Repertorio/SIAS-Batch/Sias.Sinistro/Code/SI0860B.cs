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
using Sias.Sinistro.DB2.SI0860B;

namespace Code
{
    public class SI0860B
    {
        public bool IsCall { get; set; }

        public SI0860B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *  *-------------------------------------------------------------*      */
        /*"      *  *                                                             *      */
        /*"      *  *     SISTEMA............. SINISTROS                          *      */
        /*"      *  *     PROGRAMA............ SI0860B                            *      */
        /*"      *  *     ANALISTA/PROGRAMADOR PRODEXTER                          *      */
        /*"      *  *                                                             *      */
        /*"      *  *     FUNCAO.............. GERA ARQUIVO DE CESTA BASICA       *      */
        /*"      *  *                          DE INCLUSAO E ESTORNOS             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO - RILDO SICO - 03/07/2001 - PROCURAR RS001            *      */
        /*"      *            INCLUIDO NO ARQUIVO SEGURADO, DDD, FONE, OBS E DATA *      */
        /*"      *            DE INDENIZACAO.                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 01/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SI0860BA { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0860BA
        {
            get
            {
                _.Move(REG_SI0860BA, _SI0860BA); VarBasis.RedefinePassValue(REG_SI0860BA, _SI0860BA, REG_SI0860BA); return _SI0860BA;
            }
        }
        /*"01              REG-SI0860BA.*/
        public SI0860B_REG_SI0860BA REG_SI0860BA { get; set; } = new SI0860B_REG_SI0860BA();
        public class SI0860B_REG_SI0860BA : VarBasis
        {
            /*"  05            FILLER                PIC  X(360).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "360", "X(360)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77              V1SIST-DTCURRENT  PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77              HOST-HISTSINI   PIC  S9(09)   COMP VALUE ZEROS.*/
        public IntBasis HOST_HISTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01              AREA-DE-WORK.*/
        public SI0860B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0860B_AREA_DE_WORK();
        public class SI0860B_AREA_DE_WORK : VarBasis
        {
            /*"  05            FILLER          PIC  X(035)    VALUE                'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"  05            WS-CT-LD-INCL   PIC  9(005)   VALUE   ZEROS.*/
            public IntBasis WS_CT_LD_INCL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WS-CT-LD-EST    PIC  9(005)   VALUE   ZEROS.*/
            public IntBasis WS_CT_LD_EST { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WS-CT-GR-INCL   PIC  9(005)   VALUE   ZEROS.*/
            public IntBasis WS_CT_GR_INCL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WS-CT-GR-EST    PIC  9(005)   VALUE   ZEROS.*/
            public IntBasis WS_CT_GR_EST { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WFIM-CBASICA    PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_CBASICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-ESTORNO    PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_ESTORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-SISTEMAS   PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-MSGERRO.*/
            public SI0860B_WS_MSGERRO WS_MSGERRO { get; set; } = new SI0860B_WS_MSGERRO();
            public class SI0860B_WS_MSGERRO : VarBasis
            {
                /*"    10      WS-PARAGRAFO         PIC  X(040)   VALUE SPACES.*/
                public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10      WS-NOME-TABELA       PIC  X(020)   VALUE SPACES.*/
                public StringBasis WS_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10      WS-INSTRUCAO         PIC  X(020)   VALUE SPACES.*/
                public StringBasis WS_INSTRUCAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10      WS-SQLCODE           PIC    ---9   VALUE ZEROS.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9"));
                /*"    10      WS-MENSAGEM          PIC  X(050)   VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10      WS-CHAVE             PIC  X(050)   VALUE SPACES.*/
                public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"01              LC01.*/
            }
        }
        public SI0860B_LC01 LC01 { get; set; } = new SI0860B_LC01();
        public class SI0860B_LC01 : VarBasis
        {
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(014)  VALUE                'SI0860B - RELA'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"SI0860B - RELA");
            /*"  05            FILLER                PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05            FILLER                PIC  X(015)  VALUE                'CAO DOS BENEFIC'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CAO DOS BENEFIC");
            /*"  05            FILLER                PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05            FILLER                PIC  X(017)  VALUE                'IARIOS CESTA BASI'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"IARIOS CESTA BASI");
            /*"  05            FILLER                PIC  X(001)  VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05            FILLER                PIC  X(006)  VALUE                'ICA - '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ICA - ");
            /*"  05            LC01-TITULO           PIC  X(010)  VALUE SPACES.*/
            public StringBasis LC01_TITULO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05            FILLER                PIC  X(025)  VALUE SPACES.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(040)  VALUE SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(008)  VALUE                ' DATA : '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" DATA : ");
            /*"  05            LC01-DATA             PIC  X(012)  VALUE SPACES.*/
            public StringBasis LC01_DATA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(020)  VALUE                '             '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"             ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(002)  VALUE                '  '.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(009)  VALUE SPACES.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(010)  VALUE                '          '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"          ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(010)  VALUE                '      '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"      ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"01              LC02.*/
        }
        public SI0860B_LC02 LC02 { get; set; } = new SI0860B_LC02();
        public class SI0860B_LC02 : VarBasis
        {
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(013)  VALUE                '  APOLICE '.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"  APOLICE ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(013)  VALUE                ' SINISTRO '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" SINISTRO ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(015)  VALUE                ' BILHETE  '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" BILHETE  ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(040)  VALUE                ' BENEFICIARIO'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" BENEFICIARIO");
            /*"  05            FILLER                PIC  X(011)  VALUE                ' CPF'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" CPF");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(040)  VALUE                ' ENDERECO    '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" ENDERECO    ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(020)  VALUE                ' BAIRRO      '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @" BAIRRO      ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(020)  VALUE                ' CIDADE      '.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @" CIDADE      ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(002)  VALUE                'UF'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(009)  VALUE                ' CEP  '.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" CEP  ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(010)  VALUE                ' SITUACAO '.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SITUACAO ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            FILLER                PIC  X(010)  VALUE                ' DATA '.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" DATA ");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 FILLER                           PIC  X(040)  VALUE     'SEGURADO'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 FILLER                           PIC  X(003)  VALUE     'DDD'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DDD");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 FILLER                           PIC  X(008)  VALUE     'FONE'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"FONE");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 FILLER                           PIC  X(040)  VALUE     'OBSERVACAO'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"OBSERVACAO");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 FILLER                           PIC  X(010)  VALUE     'DT.INDENIZ'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT.INDENIZ");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"01              LD01.*/
        }
        public SI0860B_LD01 LD01 { get; set; } = new SI0860B_LD01();
        public class SI0860B_LD01 : VarBasis
        {
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-NUM-APOLICE      PIC  9(013).*/
            public IntBasis LD01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-NUM-SINISTRO     PIC  9(013).*/
            public IntBasis LD01_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-NUM-BILHETE      PIC  9(015).*/
            public IntBasis LD01_NUM_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-NOME-BENEF       PIC  X(040).*/
            public StringBasis LD01_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-CPF              PIC  9(011).*/
            public IntBasis LD01_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-ENDERECO         PIC  X(040).*/
            public StringBasis LD01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-BAIRRO           PIC  X(020).*/
            public StringBasis LD01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-CIDADE           PIC  X(020).*/
            public StringBasis LD01_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-SIGLA-UF         PIC  X(002).*/
            public StringBasis LD01_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-CEP              PIC  9(009).*/
            public IntBasis LD01_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-SIT-REGISTRO     PIC  X(010).*/
            public StringBasis LD01_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05            LD01-DTMOVTO          PIC  X(010).*/
            public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            FILLER                PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 LD01-NOME-SEGURADO               PIC  X(040).*/
            public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 LD01-DDD                         PIC  9(003).*/
            public IntBasis LD01_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 LD01-FONE                        PIC  9(008).*/
            public IntBasis LD01_FONE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 LD01-OBS                         PIC  X(040).*/
            public StringBasis LD01_OBS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
            /*"  05 LD01-DATA-INDENIZACAO            PIC  X(010).*/
            public StringBasis LD01_DATA_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05 FILLER                           PIC  X(003)  VALUE ' ; '.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ; ");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINBENCB SINBENCB { get; set; } = new Dclgens.SINBENCB();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public SI0860B_CBASICA CBASICA { get; set; } = new SI0860B_CBASICA();
        public SI0860B_CESTORNO CESTORNO { get; set; } = new SI0860B_CESTORNO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0860BA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0860BA.SetFile(SI0860BA_FILE_NAME_P);

                /*" -239- PERFORM R0100-00-INICIO. */

                R0100_00_INICIO_SECTION();

                /*" -240- MOVE SPACES TO WFIM-CBASICA. */
                _.Move("", AREA_DE_WORK.WFIM_CBASICA);

                /*" -241- PERFORM R0210-00-DECLARA-CBASICA. */

                R0210_00_DECLARA_CBASICA_SECTION();

                /*" -242- PERFORM R0215-00-FETCH-CBASICA. */

                R0215_00_FETCH_CBASICA_SECTION();

                /*" -243- IF WFIM-CBASICA EQUAL 'S' */

                if (AREA_DE_WORK.WFIM_CBASICA == "S")
                {

                    /*" -244- DISPLAY '*---------------------------*' */
                    _.Display($"*---------------------------*");

                    /*" -245- DISPLAY '* --  SI0860B - INCLUSAO -- *' */
                    _.Display($"* --  SI0860B - INCLUSAO -- *");

                    /*" -246- DISPLAY '* --     SEM MOVIMENTO   -- *' */
                    _.Display($"* --     SEM MOVIMENTO   -- *");

                    /*" -247- DISPLAY '*---------------------------*' */
                    _.Display($"*---------------------------*");

                    /*" -249- END-IF. */
                }


                /*" -252- PERFORM R0200-00-PROCESSA-INCLUSAO UNTIL WFIM-CBASICA EQUAL 'S' . */

                while (!(AREA_DE_WORK.WFIM_CBASICA == "S"))
                {

                    R0200_00_PROCESSA_INCLUSAO_SECTION();
                }

                /*" -253- MOVE SPACES TO WFIM-ESTORNO. */
                _.Move("", AREA_DE_WORK.WFIM_ESTORNO);

                /*" -254- PERFORM R0310-00-DECLARA-ESTORNO. */

                R0310_00_DECLARA_ESTORNO_SECTION();

                /*" -255- PERFORM R0315-00-FETCH-ESTORNO. */

                R0315_00_FETCH_ESTORNO_SECTION();

                /*" -256- IF WFIM-ESTORNO EQUAL 'S' */

                if (AREA_DE_WORK.WFIM_ESTORNO == "S")
                {

                    /*" -257- DISPLAY '*---------------------------*' */
                    _.Display($"*---------------------------*");

                    /*" -258- DISPLAY '* --  SI0860B - ESTORNOS -- *' */
                    _.Display($"* --  SI0860B - ESTORNOS -- *");

                    /*" -259- DISPLAY '* --     SEM MOVIMENTO   -- *' */
                    _.Display($"* --     SEM MOVIMENTO   -- *");

                    /*" -260- DISPLAY '*---------------------------*' */
                    _.Display($"*---------------------------*");

                    /*" -262- END-IF. */
                }


                /*" -265- PERFORM R0300-00-PROCESSA-ESTORNO UNTIL WFIM-ESTORNO EQUAL 'S' . */

                while (!(AREA_DE_WORK.WFIM_ESTORNO == "S"))
                {

                    R0300_00_PROCESSA_ESTORNO_SECTION();
                }

                /*" -267- PERFORM R0600-00-ENCERRA. */

                R0600_00_ENCERRA_SECTION();

                /*" -267- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_EXIT*/

        [StopWatch]
        /*" R0100-00-INICIO-SECTION */
        private void R0100_00_INICIO_SECTION()
        {
            /*" -276- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -277- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -278- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -282- OPEN OUTPUT SI0860BA. */
            SI0860BA.Open(REG_SI0860BA);

            /*" -284- PERFORM R0110-00-SELECT-SISTEMAS. */

            R0110_00_SELECT_SISTEMAS_SECTION();

            /*" -284- MOVE SISTEMAS-DATA-MOV-ABERTO TO LC01-DATA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LC01.LC01_DATA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_EXIT*/

        [StopWatch]
        /*" R0110-00-SELECT-SISTEMAS-SECTION */
        private void R0110_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -302- PERFORM R0110_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0110_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -306- DISPLAY 'PROBLEMAS ACESSO SISTEMAS' */
                _.Display($"PROBLEMAS ACESSO SISTEMAS");

                /*" -307- MOVE 'R0110-00-SELECT-SISTEMA' TO WS-PARAGRAFO */
                _.Move("R0110-00-SELECT-SISTEMA", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -308- MOVE 'SEGUROS.SISTEMAS' TO WS-NOME-TABELA */
                _.Move("SEGUROS.SISTEMAS", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -309- MOVE 'SELECT ' TO WS-INSTRUCAO */
                _.Move("SELECT ", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -310- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -311- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -311- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0110_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -302- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_EXIT*/

        [StopWatch]
        /*" R0200-00-PROCESSA-INCLUSAO-SECTION */
        private void R0200_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -321- MOVE ZEROS TO HOST-HISTSINI */
            _.Move(0, HOST_HISTSINI);

            /*" -322- PERFORM R0220-00-ACESSA-HISTSINI */

            R0220_00_ACESSA_HISTSINI_SECTION();

            /*" -323- IF HOST-HISTSINI = 0 */

            if (HOST_HISTSINI == 0)
            {

                /*" -325- GO TO R0200-LEITURA. */

                R0200_LEITURA(); //GOTO
                return;
            }


            /*" -326- MOVE SINBENCB-NUM-APOLICE TO LD01-NUM-APOLICE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE, LD01.LD01_NUM_APOLICE);

            /*" -327- MOVE SINBENCB-NUM-SINISTRO TO LD01-NUM-SINISTRO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO, LD01.LD01_NUM_SINISTRO);

            /*" -328- MOVE SINBENCB-NUM-BILHETE TO LD01-NUM-BILHETE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE, LD01.LD01_NUM_BILHETE);

            /*" -329- MOVE SINBENCB-NOME-BENEFICIARIO TO LD01-NOME-BENEF */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NOME_BENEFICIARIO, LD01.LD01_NOME_BENEF);

            /*" -330- MOVE SINBENCB-NUM-CPF TO LD01-CPF */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_CPF, LD01.LD01_CPF);

            /*" -331- MOVE SINBENCB-ENDERECO TO LD01-ENDERECO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_ENDERECO, LD01.LD01_ENDERECO);

            /*" -332- MOVE SINBENCB-BAIRRO TO LD01-BAIRRO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_BAIRRO, LD01.LD01_BAIRRO);

            /*" -333- MOVE SINBENCB-CIDADE TO LD01-CIDADE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CIDADE, LD01.LD01_CIDADE);

            /*" -334- MOVE SINBENCB-SIGLA-UF TO LD01-SIGLA-UF */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIGLA_UF, LD01.LD01_SIGLA_UF);

            /*" -335- MOVE SINBENCB-CEP TO LD01-CEP */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP, LD01.LD01_CEP);

            /*" -336- MOVE 'INCLUSAO' TO LD01-SIT-REGISTRO */
            _.Move("INCLUSAO", LD01.LD01_SIT_REGISTRO);

            /*" -338- MOVE SINBENCB-DTMOVTO TO LD01-DTMOVTO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DTMOVTO, LD01.LD01_DTMOVTO);

            /*" -340- PERFORM R0221-00-NOME-SEGURADO */

            R0221_00_NOME_SEGURADO_SECTION();

            /*" -341- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_NOME_SEGURADO);

            /*" -342- MOVE SINBENCB-DDD-BENEF-CBASICA TO LD01-DDD */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DDD_BENEF_CBASICA, LD01.LD01_DDD);

            /*" -343- MOVE SINBENCB-FONE-BENEF-CBASICA TO LD01-FONE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_FONE_BENEF_CBASICA, LD01.LD01_FONE);

            /*" -345- MOVE SINBENCB-OBS-BENEF-CBASICA TO LD01-OBS */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OBS_BENEF_CBASICA, LD01.LD01_OBS);

            /*" -346- PERFORM R0222-00-DATA-PRIMEIRA-IND */

            R0222_00_DATA_PRIMEIRA_IND_SECTION();

            /*" -347- MOVE SINISHIS-DATA-MOVIMENTO TO SINBENCB-DATA-INDENIZACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DATA_INDENIZACAO);

            /*" -349- MOVE SINBENCB-DATA-INDENIZACAO TO LD01-DATA-INDENIZACAO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DATA_INDENIZACAO, LD01.LD01_DATA_INDENIZACAO);

            /*" -350- IF WS-CT-GR-INCL = ZEROS */

            if (AREA_DE_WORK.WS_CT_GR_INCL == 00)
            {

                /*" -351- MOVE 'INCLUSAO' TO LC01-TITULO */
                _.Move("INCLUSAO", LC01.LC01_TITULO);

                /*" -352- WRITE REG-SI0860BA FROM LC01 */
                _.Move(LC01.GetMoveValues(), REG_SI0860BA);

                SI0860BA.Write(REG_SI0860BA.GetMoveValues().ToString());

                /*" -353- WRITE REG-SI0860BA FROM LC02 */
                _.Move(LC02.GetMoveValues(), REG_SI0860BA);

                SI0860BA.Write(REG_SI0860BA.GetMoveValues().ToString());

                /*" -355- END-IF */
            }


            /*" -357- PERFORM R0230-00-GRAVA. */

            R0230_00_GRAVA_SECTION();

            /*" -357- PERFORM R0250-00-UPDATE-CBASICA. */

            R0250_00_UPDATE_CBASICA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0200_LEITURA */

            R0200_LEITURA();

        }

        [StopWatch]
        /*" R0200-LEITURA */
        private void R0200_LEITURA(bool isPerform = false)
        {
            /*" -360- PERFORM R0215-00-FETCH-CBASICA. */

            R0215_00_FETCH_CBASICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-DECLARA-CBASICA-SECTION */
        private void R0210_00_DECLARA_CBASICA_SECTION()
        {
            /*" -389- PERFORM R0210_00_DECLARA_CBASICA_DB_DECLARE_1 */

            R0210_00_DECLARA_CBASICA_DB_DECLARE_1();

            /*" -391- PERFORM R0210_00_DECLARA_CBASICA_DB_OPEN_1 */

            R0210_00_DECLARA_CBASICA_DB_OPEN_1();

            /*" -394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -395- MOVE 'R0210-00-DECLARA-CURSOR' TO WS-PARAGRAFO */
                _.Move("R0210-00-DECLARA-CURSOR", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -396- MOVE 'SINI_BENEF_CBASICA' TO WS-NOME-TABELA */
                _.Move("SINI_BENEF_CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -397- MOVE 'DECLARE' TO WS-INSTRUCAO */
                _.Move("DECLARE", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -398- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -399- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -399- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-DECLARA-CBASICA-DB-DECLARE-1 */
        public void R0210_00_DECLARA_CBASICA_DB_DECLARE_1()
        {
            /*" -389- EXEC SQL DECLARE CBASICA CURSOR FOR SELECT NUM_APOLICE, NUM_SINISTRO, NUM_BILHETE, OCORR_HISTORICO, NOME_BENEFICIARIO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, SIT_REGISTRO, DTMOVTO, DDD_BENEF_CBASICA, FONE_BENEF_CBASICA, OBS_BENEF_CBASICA, DATA_INDENIZACAO, NUM_CPF FROM SEGUROS.SINI_BENEF_CBASICA WHERE SIT_REGISTRO = '0' END-EXEC */
            CBASICA = new SI0860B_CBASICA(false);
            string GetQuery_CBASICA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NUM_SINISTRO
							, 
							NUM_BILHETE
							, 
							OCORR_HISTORICO
							, 
							NOME_BENEFICIARIO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							CEP
							, 
							SIT_REGISTRO
							, 
							DTMOVTO
							, 
							DDD_BENEF_CBASICA
							, 
							FONE_BENEF_CBASICA
							, 
							OBS_BENEF_CBASICA
							, 
							DATA_INDENIZACAO
							, 
							NUM_CPF 
							FROM SEGUROS.SINI_BENEF_CBASICA 
							WHERE SIT_REGISTRO = '0'";

                return query;
            }
            CBASICA.GetQueryEvent += GetQuery_CBASICA;

        }

        [StopWatch]
        /*" R0210-00-DECLARA-CBASICA-DB-OPEN-1 */
        public void R0210_00_DECLARA_CBASICA_DB_OPEN_1()
        {
            /*" -391- EXEC SQL OPEN CBASICA END-EXEC. */

            CBASICA.Open();

        }

        [StopWatch]
        /*" R0310-00-DECLARA-ESTORNO-DB-DECLARE-1 */
        public void R0310_00_DECLARA_ESTORNO_DB_DECLARE_1()
        {
            /*" -627- EXEC SQL DECLARE CESTORNO CURSOR FOR SELECT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO P WHERE P.COD_OPERACAO = H.COD_OPERACAO AND P.IDE_SISTEMA = 'SI' AND P.IND_TIPO_FUNCAO = 'IN' AND P.DES_OPERACAO = 'ESTORNO DE INDENIZACAO' AND H.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND NUM_APOL_SINISTRO BETWEEN 108200000000 AND 108299999999 END-EXEC. */
            CESTORNO = new SI0860B_CESTORNO(true);
            string GetQuery_CESTORNO()
            {
                var query = @$"SELECT 
							NUM_APOL_SINISTRO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_OPERACAO P 
							WHERE 
							P.COD_OPERACAO = H.COD_OPERACAO 
							AND P.IDE_SISTEMA = 'SI' 
							AND P.IND_TIPO_FUNCAO = 'IN' 
							AND P.DES_OPERACAO = 'ESTORNO DE INDENIZACAO' 
							AND H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND NUM_APOL_SINISTRO BETWEEN 108200000000 
							AND 108299999999";

                return query;
            }
            CESTORNO.GetQueryEvent += GetQuery_CESTORNO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0215-00-FETCH-CBASICA-SECTION */
        private void R0215_00_FETCH_CBASICA_SECTION()
        {
            /*" -426- PERFORM R0215_00_FETCH_CBASICA_DB_FETCH_1 */

            R0215_00_FETCH_CBASICA_DB_FETCH_1();

            /*" -429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -430- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -431- MOVE 'S' TO WFIM-CBASICA */
                    _.Move("S", AREA_DE_WORK.WFIM_CBASICA);

                    /*" -431- PERFORM R0215_00_FETCH_CBASICA_DB_CLOSE_1 */

                    R0215_00_FETCH_CBASICA_DB_CLOSE_1();

                    /*" -433- ELSE */
                }
                else
                {


                    /*" -434- MOVE 'R0215-00-FETCH-CBASICA' TO WS-PARAGRAFO */
                    _.Move("R0215-00-FETCH-CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                    /*" -435- MOVE 'SINI_BENEF_CBASICA' TO WS-NOME-TABELA */
                    _.Move("SINI_BENEF_CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                    /*" -436- MOVE 'FETCH' TO WS-INSTRUCAO */
                    _.Move("FETCH", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                    /*" -437- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                    /*" -438- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                    _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                    /*" -439- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -440- END-IF */
                }


                /*" -441- ELSE */
            }
            else
            {


                /*" -442- ADD 1 TO WS-CT-LD-INCL */
                AREA_DE_WORK.WS_CT_LD_INCL.Value = AREA_DE_WORK.WS_CT_LD_INCL + 1;

                /*" -442- END-IF. */
            }


        }

        [StopWatch]
        /*" R0215-00-FETCH-CBASICA-DB-FETCH-1 */
        public void R0215_00_FETCH_CBASICA_DB_FETCH_1()
        {
            /*" -426- EXEC SQL FETCH CBASICA INTO :SINBENCB-NUM-APOLICE, :SINBENCB-NUM-SINISTRO, :SINBENCB-NUM-BILHETE, :SINBENCB-OCORR-HISTORICO, :SINBENCB-NOME-BENEFICIARIO, :SINBENCB-ENDERECO, :SINBENCB-BAIRRO, :SINBENCB-CIDADE, :SINBENCB-SIGLA-UF, :SINBENCB-CEP, :SINBENCB-SIT-REGISTRO, :SINBENCB-DTMOVTO, :SINBENCB-DDD-BENEF-CBASICA, :SINBENCB-FONE-BENEF-CBASICA, :SINBENCB-OBS-BENEF-CBASICA, :SINBENCB-DATA-INDENIZACAO, :SINBENCB-NUM-CPF END-EXEC */

            if (CBASICA.Fetch())
            {
                _.Move(CBASICA.SINBENCB_NUM_APOLICE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE);
                _.Move(CBASICA.SINBENCB_NUM_SINISTRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO);
                _.Move(CBASICA.SINBENCB_NUM_BILHETE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE);
                _.Move(CBASICA.SINBENCB_OCORR_HISTORICO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO);
                _.Move(CBASICA.SINBENCB_NOME_BENEFICIARIO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NOME_BENEFICIARIO);
                _.Move(CBASICA.SINBENCB_ENDERECO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_ENDERECO);
                _.Move(CBASICA.SINBENCB_BAIRRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_BAIRRO);
                _.Move(CBASICA.SINBENCB_CIDADE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CIDADE);
                _.Move(CBASICA.SINBENCB_SIGLA_UF, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIGLA_UF);
                _.Move(CBASICA.SINBENCB_CEP, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP);
                _.Move(CBASICA.SINBENCB_SIT_REGISTRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIT_REGISTRO);
                _.Move(CBASICA.SINBENCB_DTMOVTO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DTMOVTO);
                _.Move(CBASICA.SINBENCB_DDD_BENEF_CBASICA, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DDD_BENEF_CBASICA);
                _.Move(CBASICA.SINBENCB_FONE_BENEF_CBASICA, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_FONE_BENEF_CBASICA);
                _.Move(CBASICA.SINBENCB_OBS_BENEF_CBASICA, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OBS_BENEF_CBASICA);
                _.Move(CBASICA.SINBENCB_DATA_INDENIZACAO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DATA_INDENIZACAO);
                _.Move(CBASICA.SINBENCB_NUM_CPF, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_CPF);
            }

        }

        [StopWatch]
        /*" R0215-00-FETCH-CBASICA-DB-CLOSE-1 */
        public void R0215_00_FETCH_CBASICA_DB_CLOSE_1()
        {
            /*" -431- EXEC SQL CLOSE CBASICA END-EXEC */

            CBASICA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-ACESSA-HISTSINI-SECTION */
        private void R0220_00_ACESSA_HISTSINI_SECTION()
        {
            /*" -463- PERFORM R0220_00_ACESSA_HISTSINI_DB_SELECT_1 */

            R0220_00_ACESSA_HISTSINI_DB_SELECT_1();

            /*" -466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -467- DISPLAY 'APOL-SINISTRO = ' SINBENCB-NUM-SINISTRO */
                _.Display($"APOL-SINISTRO = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

                /*" -468- MOVE 'R0220-00-ACESSA-HISTSINI' TO WS-PARAGRAFO */
                _.Move("R0220-00-ACESSA-HISTSINI", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -469- MOVE 'V0HISTSINI        ' TO WS-NOME-TABELA */
                _.Move("V0HISTSINI        ", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -470- MOVE 'SELECT ' TO WS-INSTRUCAO */
                _.Move("SELECT ", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -471- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -472- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -472- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0220-00-ACESSA-HISTSINI-DB-SELECT-1 */
        public void R0220_00_ACESSA_HISTSINI_DB_SELECT_1()
        {
            /*" -463- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-HISTSINI FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO P WHERE H.NUM_APOL_SINISTRO = :SINBENCB-NUM-SINISTRO AND P.COD_OPERACAO = H.COD_OPERACAO AND P.IND_TIPO_FUNCAO = 'IN' AND P.IDE_SISTEMA = 'SI' AND P.FUNCAO_OPERACAO = 'IND' AND H.SIT_REGISTRO IN ( '0' , '1' ) END-EXEC. */

            var r0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1 = new R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1()
            {
                SINBENCB_NUM_SINISTRO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO.ToString(),
            };

            var executed_1 = R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1.Execute(r0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_HISTSINI, HOST_HISTSINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_EXIT*/

        [StopWatch]
        /*" R0221-00-NOME-SEGURADO-SECTION */
        private void R0221_00_NOME_SEGURADO_SECTION()
        {
            /*" -482- MOVE 'R0221-00-NOME-SEGURADO' TO WS-PARAGRAFO */
            _.Move("R0221-00-NOME-SEGURADO", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

            /*" -490- PERFORM R0221_00_NOME_SEGURADO_DB_SELECT_1 */

            R0221_00_NOME_SEGURADO_DB_SELECT_1();

            /*" -493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -494- DISPLAY '//////////////////////////////////////////////' */
                _.Display($"//////////////////////////////////////////////");

                /*" -495- DISPLAY 'APOL-SINISTRO = ' SINBENCB-NUM-SINISTRO */
                _.Display($"APOL-SINISTRO = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

                /*" -496- DISPLAY 'ERROR NA TABELA DE CLIENTE ' */
                _.Display($"ERROR NA TABELA DE CLIENTE ");

                /*" -497- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -497- END-IF. */
            }


        }

        [StopWatch]
        /*" R0221-00-NOME-SEGURADO-DB-SELECT-1 */
        public void R0221_00_NOME_SEGURADO_DB_SELECT_1()
        {
            /*" -490- EXEC SQL SELECT C.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.APOLICES A, SEGUROS.CLIENTES C WHERE A.NUM_APOLICE = :SINBENCB-NUM-APOLICE AND A.COD_CLIENTE = C.COD_CLIENTE END-EXEC */

            var r0221_00_NOME_SEGURADO_DB_SELECT_1_Query1 = new R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1()
            {
                SINBENCB_NUM_APOLICE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1.Execute(r0221_00_NOME_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0221_99_EXIT*/

        [StopWatch]
        /*" R0222-00-DATA-PRIMEIRA-IND-SECTION */
        private void R0222_00_DATA_PRIMEIRA_IND_SECTION()
        {
            /*" -507- MOVE 'R0222-00-DATA-PRIMEIRA-IND' TO WS-PARAGRAFO */
            _.Move("R0222-00-DATA-PRIMEIRA-IND", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

            /*" -517- PERFORM R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1 */

            R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1();

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY '//////////////////////////////////////////////' */
                _.Display($"//////////////////////////////////////////////");

                /*" -522- DISPLAY 'APOL-SINISTRO = ' SINBENCB-NUM-SINISTRO */
                _.Display($"APOL-SINISTRO = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

                /*" -523- DISPLAY 'ERROR NA DATA DE INDENIZACAO.' */
                _.Display($"ERROR NA DATA DE INDENIZACAO.");

                /*" -524- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -524- END-IF. */
            }


        }

        [StopWatch]
        /*" R0222-00-DATA-PRIMEIRA-IND-DB-SELECT-1 */
        public void R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1()
        {
            /*" -517- EXEC SQL SELECT VALUE(MIN(H.DATA_MOVIMENTO),DATE( '9999-12-30' )) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO P WHERE H.NUM_APOL_SINISTRO = :SINBENCB-NUM-SINISTRO AND H.SIT_REGISTRO <> '2' AND P.COD_OPERACAO = H.COD_OPERACAO AND P.IDE_SISTEMA = 'SI' AND P.FUNCAO_OPERACAO = 'IND' END-EXEC */

            var r0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1 = new R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1()
            {
                SINBENCB_NUM_SINISTRO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO.ToString(),
            };

            var executed_1 = R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1.Execute(r0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0222_99_EXIT*/

        [StopWatch]
        /*" R0230-00-GRAVA-SECTION */
        private void R0230_00_GRAVA_SECTION()
        {
            /*" -535- WRITE REG-SI0860BA FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0860BA);

            SI0860BA.Write(REG_SI0860BA.GetMoveValues().ToString());

            /*" -535- ADD 1 TO WS-CT-GR-INCL. */
            AREA_DE_WORK.WS_CT_GR_INCL.Value = AREA_DE_WORK.WS_CT_GR_INCL + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-UPDATE-CBASICA-SECTION */
        private void R0250_00_UPDATE_CBASICA_SECTION()
        {
            /*" -553- PERFORM R0250_00_UPDATE_CBASICA_DB_UPDATE_1 */

            R0250_00_UPDATE_CBASICA_DB_UPDATE_1();

            /*" -556- DISPLAY 'TERM UPDATE ' SQLCODE */
            _.Display($"TERM UPDATE {DB.SQLCODE}");

            /*" -557- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -558- MOVE 'R0250-00-UPDATE-CBASICA' TO WS-PARAGRAFO */
                _.Move("R0250-00-UPDATE-CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -559- MOVE 'SINI_BENEF_CBASICA' TO WS-NOME-TABELA */
                _.Move("SINI_BENEF_CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -560- MOVE 'UPDATE' TO WS-INSTRUCAO */
                _.Move("UPDATE", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -561- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -562- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -562- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0250-00-UPDATE-CBASICA-DB-UPDATE-1 */
        public void R0250_00_UPDATE_CBASICA_DB_UPDATE_1()
        {
            /*" -553- EXEC SQL UPDATE SEGUROS.SINI_BENEF_CBASICA SET SIT_REGISTRO = '1' , DATA_INDENIZACAO = :SINBENCB-DATA-INDENIZACAO WHERE NUM_APOLICE = :SINBENCB-NUM-APOLICE AND NUM_SINISTRO = :SINBENCB-NUM-SINISTRO AND NUM_BILHETE = :SINBENCB-NUM-BILHETE AND OCORR_HISTORICO = :SINBENCB-OCORR-HISTORICO END-EXEC */

            var r0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1 = new R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1()
            {
                SINBENCB_DATA_INDENIZACAO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DATA_INDENIZACAO.ToString(),
                SINBENCB_OCORR_HISTORICO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO.ToString(),
                SINBENCB_NUM_SINISTRO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO.ToString(),
                SINBENCB_NUM_APOLICE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE.ToString(),
                SINBENCB_NUM_BILHETE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE.ToString(),
            };

            R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1.Execute(r0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-ESTORNO-SECTION */
        private void R0300_00_PROCESSA_ESTORNO_SECTION()
        {
            /*" -572- MOVE ZEROS TO HOST-HISTSINI */
            _.Move(0, HOST_HISTSINI);

            /*" -573- PERFORM R0320-00-ACESSA-HISTSINI */

            R0320_00_ACESSA_HISTSINI_SECTION();

            /*" -574- IF HOST-HISTSINI NOT = 0 */

            if (HOST_HISTSINI != 0)
            {

                /*" -576- GO TO R0300-LEITURA. */

                R0300_LEITURA(); //GOTO
                return;
            }


            /*" -577- MOVE SPACES TO WFIM-CBASICA. */
            _.Move("", AREA_DE_WORK.WFIM_CBASICA);

            /*" -578- PERFORM R0330-00-SELECT-CBASICA. */

            R0330_00_SELECT_CBASICA_SECTION();

            /*" -579- IF WFIM-CBASICA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_CBASICA == "S")
            {

                /*" -581- GO TO R0300-LEITURA. */

                R0300_LEITURA(); //GOTO
                return;
            }


            /*" -582- MOVE SINBENCB-NUM-APOLICE TO LD01-NUM-APOLICE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE, LD01.LD01_NUM_APOLICE);

            /*" -583- MOVE SINBENCB-NUM-SINISTRO TO LD01-NUM-SINISTRO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO, LD01.LD01_NUM_SINISTRO);

            /*" -584- MOVE SINBENCB-NUM-BILHETE TO LD01-NUM-BILHETE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE, LD01.LD01_NUM_BILHETE);

            /*" -585- MOVE SINBENCB-NOME-BENEFICIARIO TO LD01-NOME-BENEF */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NOME_BENEFICIARIO, LD01.LD01_NOME_BENEF);

            /*" -586- MOVE SINBENCB-ENDERECO TO LD01-ENDERECO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_ENDERECO, LD01.LD01_ENDERECO);

            /*" -587- MOVE SINBENCB-BAIRRO TO LD01-BAIRRO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_BAIRRO, LD01.LD01_BAIRRO);

            /*" -588- MOVE SINBENCB-CIDADE TO LD01-CIDADE */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CIDADE, LD01.LD01_CIDADE);

            /*" -589- MOVE SINBENCB-SIGLA-UF TO LD01-SIGLA-UF */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIGLA_UF, LD01.LD01_SIGLA_UF);

            /*" -590- MOVE SINBENCB-CEP TO LD01-CEP */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP, LD01.LD01_CEP);

            /*" -591- MOVE 'SUSPENDER' TO LD01-SIT-REGISTRO */
            _.Move("SUSPENDER", LD01.LD01_SIT_REGISTRO);

            /*" -593- MOVE SINBENCB-DTMOVTO TO LD01-DTMOVTO */
            _.Move(SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DTMOVTO, LD01.LD01_DTMOVTO);

            /*" -594- IF WS-CT-GR-EST = ZEROS */

            if (AREA_DE_WORK.WS_CT_GR_EST == 00)
            {

                /*" -595- MOVE 'SUSPENDER' TO LC01-TITULO */
                _.Move("SUSPENDER", LC01.LC01_TITULO);

                /*" -596- WRITE REG-SI0860BA FROM LC01 */
                _.Move(LC01.GetMoveValues(), REG_SI0860BA);

                SI0860BA.Write(REG_SI0860BA.GetMoveValues().ToString());

                /*" -597- WRITE REG-SI0860BA FROM LC02 */
                _.Move(LC02.GetMoveValues(), REG_SI0860BA);

                SI0860BA.Write(REG_SI0860BA.GetMoveValues().ToString());

                /*" -599- END-IF. */
            }


            /*" -601- PERFORM R0340-00-GRAVA. */

            R0340_00_GRAVA_SECTION();

            /*" -601- PERFORM R0350-00-UPDATE-CBASICA. */

            R0350_00_UPDATE_CBASICA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0300_LEITURA */

            R0300_LEITURA();

        }

        [StopWatch]
        /*" R0300-LEITURA */
        private void R0300_LEITURA(bool isPerform = false)
        {
            /*" -604- PERFORM R0315-00-FETCH-ESTORNO. */

            R0315_00_FETCH_ESTORNO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-DECLARA-ESTORNO-SECTION */
        private void R0310_00_DECLARA_ESTORNO_SECTION()
        {
            /*" -627- PERFORM R0310_00_DECLARA_ESTORNO_DB_DECLARE_1 */

            R0310_00_DECLARA_ESTORNO_DB_DECLARE_1();

            /*" -629- PERFORM R0310_00_DECLARA_ESTORNO_DB_OPEN_1 */

            R0310_00_DECLARA_ESTORNO_DB_OPEN_1();

            /*" -632- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -633- MOVE 'R0310-00-DECLARA-ESTORNO' TO WS-PARAGRAFO */
                _.Move("R0310-00-DECLARA-ESTORNO", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -634- MOVE 'SINISTRO_HISTORICO' TO WS-NOME-TABELA */
                _.Move("SINISTRO_HISTORICO", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -635- MOVE 'DECLARE' TO WS-INSTRUCAO */
                _.Move("DECLARE", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -636- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -637- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -637- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-DECLARA-ESTORNO-DB-OPEN-1 */
        public void R0310_00_DECLARA_ESTORNO_DB_OPEN_1()
        {
            /*" -629- EXEC SQL OPEN CESTORNO END-EXEC. */

            CESTORNO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0315-00-FETCH-ESTORNO-SECTION */
        private void R0315_00_FETCH_ESTORNO_SECTION()
        {
            /*" -648- PERFORM R0315_00_FETCH_ESTORNO_DB_FETCH_1 */

            R0315_00_FETCH_ESTORNO_DB_FETCH_1();

            /*" -651- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -652- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -653- MOVE 'S' TO WFIM-ESTORNO */
                    _.Move("S", AREA_DE_WORK.WFIM_ESTORNO);

                    /*" -653- PERFORM R0315_00_FETCH_ESTORNO_DB_CLOSE_1 */

                    R0315_00_FETCH_ESTORNO_DB_CLOSE_1();

                    /*" -655- ELSE */
                }
                else
                {


                    /*" -656- MOVE 'R0315-00-FETCH-ESTORNO' TO WS-PARAGRAFO */
                    _.Move("R0315-00-FETCH-ESTORNO", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                    /*" -657- MOVE 'SINISTRO_HISTORICO' TO WS-NOME-TABELA */
                    _.Move("SINISTRO_HISTORICO", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                    /*" -658- MOVE 'FETCH' TO WS-INSTRUCAO */
                    _.Move("FETCH", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                    /*" -659- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                    /*" -660- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                    _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                    /*" -661- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -662- END-IF */
                }


                /*" -663- ELSE */
            }
            else
            {


                /*" -664- ADD 1 TO WS-CT-LD-EST */
                AREA_DE_WORK.WS_CT_LD_EST.Value = AREA_DE_WORK.WS_CT_LD_EST + 1;

                /*" -664- END-IF. */
            }


        }

        [StopWatch]
        /*" R0315-00-FETCH-ESTORNO-DB-FETCH-1 */
        public void R0315_00_FETCH_ESTORNO_DB_FETCH_1()
        {
            /*" -648- EXEC SQL FETCH CESTORNO INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (CESTORNO.Fetch())
            {
                _.Move(CESTORNO.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0315-00-FETCH-ESTORNO-DB-CLOSE-1 */
        public void R0315_00_FETCH_ESTORNO_DB_CLOSE_1()
        {
            /*" -653- EXEC SQL CLOSE CESTORNO END-EXEC */

            CESTORNO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-ACESSA-HISTSINI-SECTION */
        private void R0320_00_ACESSA_HISTSINI_SECTION()
        {
            /*" -688- PERFORM R0320_00_ACESSA_HISTSINI_DB_SELECT_1 */

            R0320_00_ACESSA_HISTSINI_DB_SELECT_1();

            /*" -691- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -692- DISPLAY 'APOL-SINISTRO = ' SINBENCB-NUM-SINISTRO */
                _.Display($"APOL-SINISTRO = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

                /*" -693- MOVE 'R0320-00-ACESSA-HISTSINI' TO WS-PARAGRAFO */
                _.Move("R0320-00-ACESSA-HISTSINI", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -694- MOVE 'V0HISTSINI        ' TO WS-NOME-TABELA */
                _.Move("V0HISTSINI        ", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -695- MOVE 'SELECT ' TO WS-INSTRUCAO */
                _.Move("SELECT ", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -696- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -697- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -697- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0320-00-ACESSA-HISTSINI-DB-SELECT-1 */
        public void R0320_00_ACESSA_HISTSINI_DB_SELECT_1()
        {
            /*" -688- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-HISTSINI FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO P WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.SIT_REGISTRO <> '2' AND P.COD_OPERACAO = H.COD_OPERACAO AND P.IND_TIPO_FUNCAO = 'IN' AND P.DES_OPERACAO = 'INDENIZACAO DE SINISTRO' AND P.IDE_SISTEMA = 'SI' END-EXEC. */

            var r0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1 = new R0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1.Execute(r0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_HISTSINI, HOST_HISTSINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_EXIT*/

        [StopWatch]
        /*" R0330-00-SELECT-CBASICA-SECTION */
        private void R0330_00_SELECT_CBASICA_SECTION()
        {
            /*" -745- PERFORM R0330_00_SELECT_CBASICA_DB_SELECT_1 */

            R0330_00_SELECT_CBASICA_DB_SELECT_1();

            /*" -748- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -749- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -750- MOVE 'S' TO WFIM-CBASICA */
                    _.Move("S", AREA_DE_WORK.WFIM_CBASICA);

                    /*" -751- ELSE */
                }
                else
                {


                    /*" -753- DISPLAY 'APOL-SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"APOL-SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -754- MOVE 'R0330-00-SELECT-CBASICA' TO WS-PARAGRAFO */
                    _.Move("R0330-00-SELECT-CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                    /*" -755- MOVE 'SINI_BENEF_CBASIC ' TO WS-NOME-TABELA */
                    _.Move("SINI_BENEF_CBASIC ", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                    /*" -756- MOVE 'SELECT ' TO WS-INSTRUCAO */
                    _.Move("SELECT ", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                    /*" -757- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                    /*" -758- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                    _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                    /*" -759- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -760- END-IF */
                }


                /*" -760- END-IF. */
            }


        }

        [StopWatch]
        /*" R0330-00-SELECT-CBASICA-DB-SELECT-1 */
        public void R0330_00_SELECT_CBASICA_DB_SELECT_1()
        {
            /*" -745- EXEC SQL SELECT NUM_APOLICE, NUM_SINISTRO, NUM_BILHETE, OCORR_HISTORICO, NOME_BENEFICIARIO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, SIT_REGISTRO, DTMOVTO, DDD_BENEF_CBASICA, FONE_BENEF_CBASICA, OBS_BENEF_CBASICA, DATA_INDENIZACAO INTO :SINBENCB-NUM-APOLICE, :SINBENCB-NUM-SINISTRO, :SINBENCB-NUM-BILHETE, :SINBENCB-OCORR-HISTORICO, :SINBENCB-NOME-BENEFICIARIO, :SINBENCB-ENDERECO, :SINBENCB-BAIRRO, :SINBENCB-CIDADE, :SINBENCB-SIGLA-UF, :SINBENCB-CEP, :SINBENCB-SIT-REGISTRO, :SINBENCB-DTMOVTO, :SINBENCB-DDD-BENEF-CBASICA, :SINBENCB-FONE-BENEF-CBASICA, :SINBENCB-OBS-BENEF-CBASICA, :SINBENCB-DATA-INDENIZACAO FROM SEGUROS.SINI_BENEF_CBASICA WHERE SIT_REGISTRO = '1' AND NUM_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r0330_00_SELECT_CBASICA_DB_SELECT_1_Query1 = new R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_CBASICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINBENCB_NUM_APOLICE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE);
                _.Move(executed_1.SINBENCB_NUM_SINISTRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO);
                _.Move(executed_1.SINBENCB_NUM_BILHETE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE);
                _.Move(executed_1.SINBENCB_OCORR_HISTORICO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO);
                _.Move(executed_1.SINBENCB_NOME_BENEFICIARIO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NOME_BENEFICIARIO);
                _.Move(executed_1.SINBENCB_ENDERECO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_ENDERECO);
                _.Move(executed_1.SINBENCB_BAIRRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_BAIRRO);
                _.Move(executed_1.SINBENCB_CIDADE, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CIDADE);
                _.Move(executed_1.SINBENCB_SIGLA_UF, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIGLA_UF);
                _.Move(executed_1.SINBENCB_CEP, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_CEP);
                _.Move(executed_1.SINBENCB_SIT_REGISTRO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_SIT_REGISTRO);
                _.Move(executed_1.SINBENCB_DTMOVTO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DTMOVTO);
                _.Move(executed_1.SINBENCB_DDD_BENEF_CBASICA, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DDD_BENEF_CBASICA);
                _.Move(executed_1.SINBENCB_FONE_BENEF_CBASICA, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_FONE_BENEF_CBASICA);
                _.Move(executed_1.SINBENCB_OBS_BENEF_CBASICA, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OBS_BENEF_CBASICA);
                _.Move(executed_1.SINBENCB_DATA_INDENIZACAO, SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_DATA_INDENIZACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_EXIT*/

        [StopWatch]
        /*" R0340-00-GRAVA-SECTION */
        private void R0340_00_GRAVA_SECTION()
        {
            /*" -771- WRITE REG-SI0860BA FROM LD01 */
            _.Move(LD01.GetMoveValues(), REG_SI0860BA);

            SI0860BA.Write(REG_SI0860BA.GetMoveValues().ToString());

            /*" -771- ADD 1 TO WS-CT-GR-EST. */
            AREA_DE_WORK.WS_CT_GR_EST.Value = AREA_DE_WORK.WS_CT_GR_EST + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-UPDATE-CBASICA-SECTION */
        private void R0350_00_UPDATE_CBASICA_SECTION()
        {
            /*" -791- PERFORM R0350_00_UPDATE_CBASICA_DB_UPDATE_1 */

            R0350_00_UPDATE_CBASICA_DB_UPDATE_1();

            /*" -794- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -795- MOVE 'R0350-00-UPDATE-CBASICA' TO WS-PARAGRAFO */
                _.Move("R0350-00-UPDATE-CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO);

                /*" -796- MOVE 'SINI_BENEF_CBASICA' TO WS-NOME-TABELA */
                _.Move("SINI_BENEF_CBASICA", AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA);

                /*" -797- MOVE 'UPDATE' TO WS-INSTRUCAO */
                _.Move("UPDATE", AREA_DE_WORK.WS_MSGERRO.WS_INSTRUCAO);

                /*" -798- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE);

                /*" -799- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM);

                /*" -799- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0350-00-UPDATE-CBASICA-DB-UPDATE-1 */
        public void R0350_00_UPDATE_CBASICA_DB_UPDATE_1()
        {
            /*" -791- EXEC SQL UPDATE SEGUROS.SINI_BENEF_CBASICA SET SIT_REGISTRO = '2' WHERE SIT_REGISTRO = '1' AND NUM_APOLICE = :SINBENCB-NUM-APOLICE AND NUM_SINISTRO = :SINBENCB-NUM-SINISTRO AND NUM_BILHETE = :SINBENCB-NUM-BILHETE AND OCORR_HISTORICO = :SINBENCB-OCORR-HISTORICO END-EXEC. */

            var r0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1 = new R0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1()
            {
                SINBENCB_OCORR_HISTORICO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO.ToString(),
                SINBENCB_NUM_SINISTRO = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO.ToString(),
                SINBENCB_NUM_APOLICE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE.ToString(),
                SINBENCB_NUM_BILHETE = SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE.ToString(),
            };

            R0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1.Execute(r0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-ENCERRA-SECTION */
        private void R0600_00_ENCERRA_SECTION()
        {
            /*" -809- DISPLAY ' ' . */
            _.Display($" ");

            /*" -810- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -811- DISPLAY '*  TERMINO NORMAL DO PROGRAMA SI0860B   *' . */
            _.Display($"*  TERMINO NORMAL DO PROGRAMA SI0860B   *");

            /*" -812- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -813- DISPLAY ' ' . */
            _.Display($" ");

            /*" -814- DISPLAY 'DOCUMENTOS LIDOS    INCL      = ' WS-CT-LD-INCL. */
            _.Display($"DOCUMENTOS LIDOS    INCL      = {AREA_DE_WORK.WS_CT_LD_INCL}");

            /*" -815- DISPLAY 'DOCUMENTOS GRAVADOS INCL      = ' WS-CT-GR-INCL. */
            _.Display($"DOCUMENTOS GRAVADOS INCL      = {AREA_DE_WORK.WS_CT_GR_INCL}");

            /*" -816- DISPLAY ' ' . */
            _.Display($" ");

            /*" -817- DISPLAY 'DOCUMENTOS LIDOS    SUSPENSAO = ' WS-CT-LD-EST. */
            _.Display($"DOCUMENTOS LIDOS    SUSPENSAO = {AREA_DE_WORK.WS_CT_LD_EST}");

            /*" -819- DISPLAY 'DOCUMENTOS GRAVADOS SUSPENSAO = ' WS-CT-GR-EST. */
            _.Display($"DOCUMENTOS GRAVADOS SUSPENSAO = {AREA_DE_WORK.WS_CT_GR_EST}");

            /*" -821- CLOSE SI0860BA. */
            SI0860BA.Close();

            /*" -825- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -825- DISPLAY 'SI0860B - FIM NORMAL' . */
            _.Display($"SI0860B - FIM NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -839- DISPLAY ' ' . */
            _.Display($" ");

            /*" -840- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -841- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0860B  *' . */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0860B  *");

            /*" -842- DISPLAY '*---------------------------------------*' . */
            _.Display($"*---------------------------------------*");

            /*" -843- DISPLAY ' ' . */
            _.Display($" ");

            /*" -844- DISPLAY 'PARAGRFO        = ' WS-PARAGRAFO. */
            _.Display($"PARAGRFO        = {AREA_DE_WORK.WS_MSGERRO.WS_PARAGRAFO}");

            /*" -845- DISPLAY 'TABELA          = ' WS-NOME-TABELA. */
            _.Display($"TABELA          = {AREA_DE_WORK.WS_MSGERRO.WS_NOME_TABELA}");

            /*" -846- DISPLAY 'SQLCODE         = ' WS-SQLCODE. */
            _.Display($"SQLCODE         = {AREA_DE_WORK.WS_MSGERRO.WS_SQLCODE}");

            /*" -847- DISPLAY 'MENSAGEM        = ' WS-MENSAGEM. */
            _.Display($"MENSAGEM        = {AREA_DE_WORK.WS_MSGERRO.WS_MENSAGEM}");

            /*" -848- DISPLAY 'NUM-APOLICE     = ' SINBENCB-NUM-APOLICE. */
            _.Display($"NUM-APOLICE     = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_APOLICE}");

            /*" -849- DISPLAY 'NUM-SINISTRO    = ' SINBENCB-NUM-SINISTRO. */
            _.Display($"NUM-SINISTRO    = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_SINISTRO}");

            /*" -850- DISPLAY 'NUM-BILHETE     = ' SINBENCB-NUM-BILHETE. */
            _.Display($"NUM-BILHETE     = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_NUM_BILHETE}");

            /*" -852- DISPLAY 'OCORR-HISTORICO = ' SINBENCB-OCORR-HISTORICO. */
            _.Display($"OCORR-HISTORICO = {SINBENCB.DCLSINI_BENEF_CBASICA.SINBENCB_OCORR_HISTORICO}");

            /*" -852- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -855- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -857- CLOSE SI0860BA */
            SI0860BA.Close();

            /*" -857- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -859- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -861- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}