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
using Sias.Bilhetes.DB2.BI0060B;

namespace Code
{
    public class BI0060B
    {
        public bool IsCall { get; set; }

        public BI0060B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------                                    */
        /*"      *                                                                       */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ BI                                  *      */
        /*"      *   PROGRAMA ............... BI0060B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SOLICITACAO ............ CAD - 19671                         *      */
        /*"      *   ANALISTA ............... WANGER C SILVA  (FAST COMPUTER)     *      */
        /*"      *   PROGRAMADOR ............ WANGER C SILVA  (FAST COMPUTER)     *      */
        /*"      *   DATA CODIFICACAO ....... junho / 2008                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   EMITE COMUNICADOS AOS SEGURADOS QUE POSSUEM BILHETE QUE tem  *      */
        /*"      *    direito A SORTEIO NA FEDERAL CAP.                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                   A L T E R A C A O                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 24.836/2009                                  *      */
        /*"      *               RETIRADO O ACESSO A TABELA                       *      */
        /*"      *               SEGUROS.MOVIMEN_FED_CAP_VA POR NAO TER           *      */
        /*"      *               NENHUMA COLUNA SENDO UTILIZADA NO CURSOR         *      */
        /*"      *               PRINCIPAL E PODER ESTAR GERANDO DUPLICIDADE      *      */
        /*"      *               NOS COMUNICADOS DE SORTEIO.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2009 - FAST COMPUTER            PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"BRSEG2* VERSAO 04 - SAC 328 - CAD15092 - BRSEG                         *      */
        /*"BRSEG2* alteracao: INCLUSAO PRODUTO E CENTRO DE CUSTO NO RELATORIO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"BRSEG1* VERSAO 03 - SAC 465 - CAD 18741                                *      */
        /*"BRSEG1* alteracao: formatacao campos codigo-cif e postnet/incl totais  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - SSI 18.471/2008                                  *      */
        /*"      *               alteracao efetuada conforme descrito na demanda  *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/12/2008 - wANGER (GEFAB)           PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - SSI 13.493/2008                                  *      */
        /*"      *               INCLUSAO DO PRODUTO 1405 PARA IMPRESSAO DE       *      */
        /*"      *               CARTA DA COMBINACAO DO SORTEIO ( CAPITALIZACAO)  *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - wANGER (FAST COMPUTER)   PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 29257 - EVITAR A REJEICAO DE CORRESPONDENCIAS, RECU-  *      */
        /*"      *   PERANDO O CEP NAS BASES DNE DOS CORREIOS PELO ENDERECO.      *      */
        /*"      *   BRSEG - SETEMBRO/2009 - VER: BR.V01                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RBI0060B { get; set; } = new FileBasis(new PIC("X", "3500", "X(3500)"));

        public FileBasis RBI0060B
        {
            get
            {
                _.Move(RBI0060B_RECORD, _RBI0060B); VarBasis.RedefinePassValue(RBI0060B_RECORD, _RBI0060B, RBI0060B_RECORD); return _RBI0060B;
            }
        }
        public FileBasis _FBI0060B { get; set; } = new FileBasis(new PIC("X", "133", "X(133)"));

        public FileBasis FBI0060B
        {
            get
            {
                _.Move(FBI0060B_RECORD, _FBI0060B); VarBasis.RedefinePassValue(FBI0060B_RECORD, _FBI0060B, FBI0060B_RECORD); return _FBI0060B;
            }
        }
        public SortBasis<BI0060B_REG_SBI0060B> SBI0060B { get; set; } = new SortBasis<BI0060B_REG_SBI0060B>(new BI0060B_REG_SBI0060B());
        /*"01            RBI0060B-RECORD     PIC X(3500).*/
        public StringBasis RBI0060B_RECORD { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");
        /*"01            FBI0060B-RECORD     PIC X(133).*/
        public StringBasis FBI0060B_RECORD { get; set; } = new StringBasis(new PIC("X", "133", "X(133)."), @"");
        /*"01            REG-SBI0060B.*/
        public BI0060B_REG_SBI0060B REG_SBI0060B { get; set; } = new BI0060B_REG_SBI0060B();
        public class BI0060B_REG_SBI0060B : VarBasis
        {
            /*"    05        SVA-CEP-G           PIC  9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        SVA-NUM-CEP.*/
            public BI0060B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new BI0060B_SVA_NUM_CEP();
            public class BI0060B_SVA_NUM_CEP : VarBasis
            {
                /*"      15      SVA-CEP             PIC  9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SVA-CEP-COMPL       PIC  9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SVA-NOME-RAZAO      PIC  X(040).*/
            }
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SVA-BILHETE         PIC  9(015).*/
            public IntBasis SVA_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-NRSORTEIO       PIC  9(009).*/
            public IntBasis SVA_NRSORTEIO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        SVA-ENDERECO        PIC  X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-BAIRRO          PIC  X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-CIDADE          PIC  X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-UF              PIC  X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05        SVA-NOME-CORREIO    PIC  X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05        SVA-FONTE           PIC  9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-PRODUTO         PIC  9(004).*/
            public IntBasis SVA_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            WHOST-DTMOVABE      PIC  X(010) VALUE SPACES.*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77            V1SIST-MESREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1SIST-ANOREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODUTO             PIC S9(004)    COMP VALUE  0.*/
        public IntBasis VIND_CODPRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            TONTO               PIC S9(004)    COMP VALUE  0.*/
        public IntBasis TONTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CLIE-IDTNASC      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis V0CLIE_IDTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-ORIG-PRODU     PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRCOPIAS       PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRTITCOMP      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            WHOST-NRCERTIF      PIC S9(015)    COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            WHOST-NRPARCEL      PIC S9(004)    COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRTIT         PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-NRTITCOMP     PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-OCORHIST      PIC S9(004)    COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-BILHETE       PIC S9(015)    COMP-3.*/
        public IntBasis WHOST_BILHETE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            WHOST-CODSUBES      PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODPRODU      PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODOPER       PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-APOLICE      PIC S9(013)    COMP-3.*/
        public IntBasis V0MENS_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0MENS-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-JDE          PIC  X(008).*/
        public StringBasis V0MENS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0MENS-JDL          PIC  X(008).*/
        public StringBasis V0MENS_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0FAIC-FAIXA        PIC S9(004)    COMP.*/
        public IntBasis V0FAIC_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0FAIC-CEPINI       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-CEPFIM       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPFIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-DESC-FAIXA   PIC  X(072).*/
        public StringBasis V0FAIC_DESC_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0FAIC-CENTRALIZA   PIC  X(072).*/
        public StringBasis V0FAIC_CENTRALIZA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0RELA-NRCOPIAS     PIC S9(004)    COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1MCEF-COD-FONTE    PIC S9(04)    COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1ACEF-COD-AGENCIA  PIC S9(04)    COMP.*/
        public IntBasis V1ACEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-ENDERFTE     PIC  X(040).*/
        public StringBasis V1FONT_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-BAIRRO       PIC  X(020).*/
        public StringBasis V1FONT_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-CIDADE       PIC  X(020).*/
        public StringBasis V1FONT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-UF           PIC  X(002).*/
        public StringBasis V1FONT_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V1FONT-CEP          PIC S9(009)    COMP.*/
        public IntBasis V1FONT_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77       CONTA-LINHAS             PIC  9(006)    VALUE 0.*/
        public IntBasis CONTA_LINHAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01 TODAS-AS-LINHAS.*/
        public BI0060B_TODAS_AS_LINHAS TODAS_AS_LINHAS { get; set; } = new BI0060B_TODAS_AS_LINHAS();
        public class BI0060B_TODAS_AS_LINHAS : VarBasis
        {
            /*"    05            LC08-LINHA08-ER.*/
            public BI0060B_LC08_LINHA08_ER LC08_LINHA08_ER { get; set; } = new BI0060B_LC08_LINHA08_ER();
            public class BI0060B_LC08_LINHA08_ER : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05 CEP-TOTAL            PIC 9(8).*/
            }
            public IntBasis CEP_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(8)."));
            /*"    05 CEP-LEGAL  REDEFINES CEP-TOTAL.*/
            private _REDEF_BI0060B_CEP_LEGAL _cep_legal { get; set; }
            public _REDEF_BI0060B_CEP_LEGAL CEP_LEGAL
            {
                get { _cep_legal = new _REDEF_BI0060B_CEP_LEGAL(); _.Move(CEP_TOTAL, _cep_legal); VarBasis.RedefinePassValue(CEP_TOTAL, _cep_legal, CEP_TOTAL); _cep_legal.ValueChanged += () => { _.Move(_cep_legal, CEP_TOTAL); }; return _cep_legal; }
                set { VarBasis.RedefinePassValue(value, _cep_legal, CEP_TOTAL); }
            }  //Redefines
            public class _REDEF_BI0060B_CEP_LEGAL : VarBasis
            {
                /*"      10  CEP-PARTE1      PIC 9(5).*/
                public IntBasis CEP_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(5)."));
                /*"      10  CEP-PARTE2      PIC 9(3).*/
                public IntBasis CEP_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
                /*"    05            LC09-LINHA09-ER.*/

                public _REDEF_BI0060B_CEP_LEGAL()
                {
                    CEP_PARTE1.ValueChanged += OnValueChanged;
                    CEP_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public BI0060B_LC09_LINHA09_ER LC09_LINHA09_ER { get; set; } = new BI0060B_LC09_LINHA09_ER();
            public class BI0060B_LC09_LINHA09_ER : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public BI0060B_LC09_FORM LC09_FORM { get; set; } = new BI0060B_LC09_FORM();
                public class BI0060B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE             PIC X(004).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"01  DBM-HEADER.*/
            }
        }
        public BI0060B_DBM_HEADER DBM_HEADER { get; set; } = new BI0060B_DBM_HEADER();
        public class BI0060B_DBM_HEADER : VarBasis
        {
            /*"  05      VA-WORK-00                PIC  X(026)  VALUE         'CODIGOPRODUTO|CENTROCUSTO|'.*/
            public StringBasis VA_WORK_00 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"CODIGOPRODUTO|CENTROCUSTO|");
            /*"  05      VA-WORK-01                PIC  X(102)  VALUE         'SEGURADO|BILHETE|NUMSORTEIO|DTPOSTAGEM|NUMOBJETO|DESTIN         'ATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|'.*/
            public StringBasis VA_WORK_01 { get; set; } = new StringBasis(new PIC("X", "102", "X(102)"), @"SEGURADO|BILHETE|NUMSORTEIO|DTPOSTAGEM|NUMOBJETO|DESTIN         ");
            /*"  05      VA-WORK-02                PIC  X(078)  VALUE         'REMET-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-UF|REMET         '-CEP|CODIGO-CIF|POSTNET'.*/
            public StringBasis VA_WORK_02 { get; set; } = new StringBasis(new PIC("X", "78", "X(078)"), @"REMET_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_UF|REMET         ");
            /*"01 CONTINUA-LINHA.*/
        }
        public BI0060B_CONTINUA_LINHA CONTINUA_LINHA { get; set; } = new BI0060B_CONTINUA_LINHA();
        public class BI0060B_CONTINUA_LINHA : VarBasis
        {
            /*"   05 LAISER-01       PIC X(02)     VALUE    '%!'.*/
            public StringBasis LAISER_01 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"%!");
            /*"   05 LAISER-02       PIC X(47)     VALUE    '%%DOCUMENTMEDIA: PAPEL1 595 842 75 WHITE NORMAL'.*/
            public StringBasis LAISER_02 { get; set; } = new StringBasis(new PIC("X", "47", "X(47)"), @"%%DOCUMENTMEDIA: PAPEL1 595 842 75 WHITE NORMAL");
            /*"   05 LAISER-03       PIC X(30)     VALUE    '%%+PAPEL2 595 842 75 BLUE AZUL'.*/
            public StringBasis LAISER_03 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"%%+PAPEL2 595 842 75 BLUE AZUL");
            /*"   05 LAISER-04       PIC X(25)     VALUE    '%%XRXREQUERIMENTS: DUPLEX'.*/
            public StringBasis LAISER_04 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"%%XRXREQUERIMENTS: DUPLEX");
            /*"   05 LAISER-05       PIC X(28)     VALUE    '%%BEGINFEATURE: *DUPLEX TRUE'.*/
            public StringBasis LAISER_05 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"%%BEGINFEATURE: *DUPLEX TRUE");
            /*"   05 LAISER-06       PIC X(30)     VALUE    '<</DUPLEX TRUE>> SETPAGEDEVICE'.*/
            public StringBasis LAISER_06 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"<</DUPLEX TRUE>> SETPAGEDEVICE");
            /*"   05 LAISER-07       PIC X(12)     VALUE    '%%ENDFEATURE'.*/
            public StringBasis LAISER_07 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"%%ENDFEATURE");
            /*"01  MAIS-LINHAS.*/
        }
        public BI0060B_MAIS_LINHAS MAIS_LINHAS { get; set; } = new BI0060B_MAIS_LINHAS();
        public class BI0060B_MAIS_LINHAS : VarBasis
        {
            /*"   05  LAISERFAC-FINAL  PIC X(05) VALUE    '%%EOF'.*/
            public StringBasis LAISERFAC_FINAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"%%EOF");
            /*"   05  FAC-01           PIC X(02) VALUE    '%!'.*/
            public StringBasis FAC_01 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"%!");
            /*"   05  FAC-02           PIC X(78) VALUE    '<</MEDIACOLOR (BLUE) /MEDIAWEIGHT 75/MEDIATYPE(AZUL)>> SETPA    'GEDEVICE'.*/
            public StringBasis FAC_02 { get; set; } = new StringBasis(new PIC("X", "78", "X(78)"), @"<</MEDIACOLOR (BLUE) /MEDIAWEIGHT 75/MEDIATYPE(AZUL)>> SETPA    ");
            /*"   05  FAC-04           PIC X(12) VALUE    '(|) SETDBSEP'.*/
            public StringBasis FAC_04 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"(|) SETDBSEP");
            /*"   05  FAC-05           PIC X(19) VALUE    '(CO41.DBM) STARTDBM'.*/
            public StringBasis FAC_05 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"(CO41.DBM) STARTDBM");
            /*"   05  FAC-HEADER       PIC X(43) VALUE    'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
            public StringBasis FAC_HEADER { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
            /*"   05  FAC-DETALHE.*/
            public BI0060B_FAC_DETALHE FAC_DETALHE { get; set; } = new BI0060B_FAC_DETALHE();
            public class BI0060B_FAC_DETALHE : VarBasis
            {
                /*"       10  CO04-DET-LOCALIDADE        PIC X(072).*/
                public StringBasis CO04_DET_LOCALIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10  SEPA-01                    PIC X(001).*/
                public StringBasis SEPA_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-FAIXA             PIC X(024).*/
                public StringBasis CO04_DET_FAIXA { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                /*"       10  SEPA-02                    PIC X(001).*/
                public StringBasis SEPA_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-OBJETOS           PIC X(003).*/
                public StringBasis CO04_DET_OBJETOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10  SEPA-03                    PIC X(001).*/
                public StringBasis SEPA_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-AMARRADO          PIC X(007).*/
                public StringBasis CO04_DET_AMARRADO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10  SEPA-04                    PIC X(001).*/
                public StringBasis SEPA_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  CO04-DET-SEQUENCIA         PIC X(015).*/
                public StringBasis CO04_DET_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   05  L1-JDT.*/
            }
            public BI0060B_L1_JDT L1_JDT { get; set; } = new BI0060B_L1_JDT();
            public class BI0060B_L1_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(02)  VALUE '%!'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"%!");
                /*"   05  L2-JDT.*/
            }
            public BI0060B_L2_JDT L2_JDT { get; set; } = new BI0060B_L2_JDT();
            public class BI0060B_L2_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(18)  VALUE '(CO05.JDT) STARTLM'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"(CO05.JDT) STARTLM");
                /*"   05  L3-JDT.*/
            }
            public BI0060B_L3_JDT L3_JDT { get; set; } = new BI0060B_L3_JDT();
            public class BI0060B_L3_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  CONTRATO-ECT  PIC X(11)  VALUE '100134700-6'.*/
                public StringBasis CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"100134700-6");
                /*"   05  L4-JDT.*/
            }
            public BI0060B_L4_JDT L4_JDT { get; set; } = new BI0060B_L4_JDT();
            public class BI0060B_L4_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  USUARIO       PIC X(13)  VALUE 'CAIXA SEGUROS'.*/
                public StringBasis USUARIO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CAIXA SEGUROS");
                /*"   05  L5-JDT.*/
            }
            public BI0060B_L5_JDT L5_JDT { get; set; } = new BI0060B_L5_JDT();
            public class BI0060B_L5_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  ENDERECO      PIC X(40)  VALUE    'SCN QUADRA 1 LOTE A ED.NUMBER ONE - 11 A'.*/
                public StringBasis ENDERECO_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"SCN QUADRA 1 LOTE A ED.NUMBER ONE - 11 A");
                /*"   05  L6-JDT.*/
            }
            public BI0060B_L6_JDT L6_JDT { get; set; } = new BI0060B_L6_JDT();
            public class BI0060B_L6_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  UNIDADE-DE-POSTAGEMT  PIC X(13) VALUE 'BRASILIA - DF'*/
                public StringBasis UNIDADE_DE_POSTAGEMT { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"BRASILIA - DF");
                /*"   05  L7-JDT.*/
            }
            public BI0060B_L7_JDT L7_JDT { get; set; } = new BI0060B_L7_JDT();
            public class BI0060B_L7_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  LISTAGEM-NUMERO        PIC X(15).*/
                public StringBasis LISTAGEM_NUMERO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"   05  L8-JDT.*/
            }
            public BI0060B_L8_JDT L8_JDT { get; set; } = new BI0060B_L8_JDT();
            public class BI0060B_L8_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  TIPO8-JDT  PIC X(29).*/
                public StringBasis TIPO8_JDT { get; set; } = new StringBasis(new PIC("X", "29", "X(29)."), @"");
                /*"   05  L9-JDT.*/
            }
            public BI0060B_L9_JDT L9_JDT { get; set; } = new BI0060B_L9_JDT();
            public class BI0060B_L9_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  DATA9-JDT     PIC X(10).*/
                public StringBasis DATA9_JDT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"   05  L10-JDT.*/
            }
            public BI0060B_L10_JDT L10_JDT { get; set; } = new BI0060B_L10_JDT();
            public class BI0060B_L10_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  NUCLEO        PIC X(13)  VALUE 'BRASILIA - DF'.*/
                public StringBasis NUCLEO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"BRASILIA - DF");
                /*"   05  L11-JDT.*/
            }
            public BI0060B_L11_JDT L11_JDT { get; set; } = new BI0060B_L11_JDT();
            public class BI0060B_L11_JDT : VarBasis
            {
                /*"       10  FILLER        PIC X(05)  VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       10  PAGINA11-JDT  PIC X(07).*/
                public StringBasis PAGINA11_JDT { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                /*"   05  SEPARA-JDT        PIC X(03)  VALUE '1  '.*/
            }
            public StringBasis SEPARA_JDT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"1  ");
            /*"01  DBM-DETALHE.*/
        }
        public BI0060B_DBM_DETALHE DBM_DETALHE { get; set; } = new BI0060B_DBM_DETALHE();
        public class BI0060B_DBM_DETALHE : VarBasis
        {
            /*"    02  FRENTE-ESQUERDA      PIC  X(195).*/
            public StringBasis FRENTE_ESQUERDA { get; set; } = new StringBasis(new PIC("X", "195", "X(195)."), @"");
            /*"    02  FRENTE-DIREITA       PIC  X(195).*/
            public StringBasis FRENTE_DIREITA { get; set; } = new StringBasis(new PIC("X", "195", "X(195)."), @"");
            /*"    02  VERSO-ESQUERDO       PIC  X(331).*/
            public StringBasis VERSO_ESQUERDO { get; set; } = new StringBasis(new PIC("X", "331", "X(331)."), @"");
            /*"    02  VERSO-DIREITO        PIC  X(331).*/
            public StringBasis VERSO_DIREITO { get; set; } = new StringBasis(new PIC("X", "331", "X(331)."), @"");
            /*"01  DBM-DET.*/
        }
        public BI0060B_DBM_DET DBM_DET { get; set; } = new BI0060B_DBM_DET();
        public class BI0060B_DBM_DET : VarBasis
        {
            /*"    05        LDET-FRENTE.*/
            public BI0060B_LDET_FRENTE LDET_FRENTE { get; set; } = new BI0060B_LDET_FRENTE();
            public class BI0060B_LDET_FRENTE : VarBasis
            {
                /*"      10      LDET-PRODUTO        PIC  X(004).*/
                public StringBasis LDET_PRODUTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LDET-CCUSTO         PIC  X(005).*/
                public StringBasis LDET_CCUSTO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LDET-NOME-RAZAO     PIC  X(042).*/
                public StringBasis LDET_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
                /*"      10      SEPARA-001          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LDET-BILHETE        PIC  9(015).*/
                public IntBasis LDET_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10      SEPARA-002          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_002 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LDET-NRSORTEIO      PIC  9(015).*/
                public IntBasis LDET_NRSORTEIO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10      SEPARA-003          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_003 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE01-DTPOSTAGEM     PIC  X(010).*/
                public StringBasis LE01_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10      SEPARA-004          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_004 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE01-SEQUENCIA      PIC  X(007).*/
                public StringBasis LE01_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"      10      SEPARA-005          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_005 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE02-NOME-RAZAO     PIC  X(040).*/
                public StringBasis LE02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      SEPARA-007          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_007 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE03-ENDERECO       PIC  X(072).*/
                public StringBasis LE03_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10      SEPARA-008          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_008 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE04-BAIRRO         PIC  X(072).*/
                public StringBasis LE04_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10      SEPARA-009          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_009 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE04-CIDADE         PIC  X(072).*/
                public StringBasis LE04_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10      SEPARA-010          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_010 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE04-UF             PIC  X(002).*/
                public StringBasis LE04_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      SEPARA-011          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_011 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE05-CEP            PIC  99999.*/
                public IntBasis LE05_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LE05-CEP-COMPL      PIC  999.*/
                public IntBasis LE05_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"      10      SEPARA-012          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_012 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE06-REMETENTE      PIC  X(031).*/
                public StringBasis LE06_REMETENTE { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"      10      SEPARA-013          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_013 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE07-ENDERECO       PIC  X(040).*/
                public StringBasis LE07_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      SEPARA-014          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_014 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE08-CIDADE         PIC  X(020).*/
                public StringBasis LE08_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      SEPARA-015          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_015 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE08-BAIRRO         PIC  X(020).*/
                public StringBasis LE08_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      SEPARA-016          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_016 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE08-UF             PIC  X(002).*/
                public StringBasis LE08_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      SEPARA-017          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_017 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LE09-CEP            PIC  99999.*/
                public IntBasis LE09_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LE09-CEP-COMPL      PIC  999.*/
                public IntBasis LE09_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"      10      SEPARA-018          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_018 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LP10-CODIGO-CIF     PIC  X(034).*/
                public StringBasis LP10_CODIGO_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                /*"      10      SEPARA-020          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_020 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      LP10-POSTNET        PIC  X(011).*/
                public StringBasis LP10_POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"01  DBM-BRANCO.*/
            }
        }
        public BI0060B_DBM_BRANCO DBM_BRANCO { get; set; } = new BI0060B_DBM_BRANCO();
        public class BI0060B_DBM_BRANCO : VarBasis
        {
            /*"    05        LCXX-FRENTE-BRANCA.*/
            public BI0060B_LCXX_FRENTE_BRANCA LCXX_FRENTE_BRANCA { get; set; } = new BI0060B_LCXX_FRENTE_BRANCA();
            public class BI0060B_LCXX_FRENTE_BRANCA : VarBasis
            {
                /*"      10      FILLER              PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      SEPARA-060          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_060 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(011)    VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      SEPARA-061          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_061 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      SEPARA-062          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_062 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(042)    VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"");
                /*"      10      SEPARA-063          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_063 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SEPARA-064          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_064 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SEPARA-065          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_065 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SEPARA-066          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_066 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SEPARA-067          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_067 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(011)    VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      SEPARA-068          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_068 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(059)    VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"");
                /*"      10      SEPARA-069          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_069 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SEPARA-070          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_070 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10      FILLER              PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SEPARA-071          PIC  X(001)    VALUE '|'.*/
                public StringBasis SEPARA_071 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"   05         LCXX-VERSO-BRANCO.*/
                public BI0060B_LCXX_VERSO_BRANCO LCXX_VERSO_BRANCO { get; set; } = new BI0060B_LCXX_VERSO_BRANCO();
                public class BI0060B_LCXX_VERSO_BRANCO : VarBasis
                {
                    /*"      10      FILLER              PIC  X(031)    VALUE SPACES.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                    /*"      10      SEPARA-072          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_072 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(072)    VALUE SPACES.*/
                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                    /*"      10      SEPARA-073          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_073 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(072)    VALUE SPACES.*/
                    public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                    /*"      10      SEPARA-074          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_074 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(072)    VALUE SPACES.*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                    /*"      10      SEPARA-075          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_075 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                    public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"      10      SEPARA-076          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_076 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(009)    VALUE SPACES.*/
                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                    /*"      10      SEPARA-077          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_077 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(010)    VALUE SPACES.*/
                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"      10      SEPARA-078          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_078 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                    /*"      10      SEPARA-079          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_079 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(040)    VALUE SPACES.*/
                    public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"      10      SEPARA-080          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_080 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(040)    VALUE SPACES.*/
                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"      10      SEPARA-081          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_081 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(020)    VALUE SPACES.*/
                    public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                    /*"      10      SEPARA-082          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_082 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(020)    VALUE SPACES.*/
                    public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                    /*"      10      SEPARA-083          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_083 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                    public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"      10      SEPARA-084          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_084 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(034)    VALUE SPACES.*/
                    public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                    /*"      10      SEPARA-086          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_086 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(011)    VALUE SPACES.*/
                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                    /*"      10      SEPARA-087          PIC  X(001)    VALUE '|'.*/
                    public StringBasis SEPARA_087 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                    /*"      10      FILLER              PIC  X(009)    VALUE SPACES.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                    /*"      10      SEPARA-085          PIC  X(001)    VALUE ' '.*/
                    public StringBasis SEPARA_085 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                    /*"01           AREA-DE-WORK.*/
                }
            }
        }
        public BI0060B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0060B_AREA_DE_WORK();
        public class BI0060B_AREA_DE_WORK : VarBasis
        {
            /*"    05        LC02-LINHA02.*/
            public BI0060B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new BI0060B_LC02_LINHA02();
            public class BI0060B_LC02_LINHA02 : VarBasis
            {
                /*"      10      LC02-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LC02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(029)    VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"      10      FILLER              PIC  X(008)    VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    05        LC03-LINHA03.*/
            }
            public BI0060B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new BI0060B_LC03_LINHA03();
            public class BI0060B_LC03_LINHA03 : VarBasis
            {
                /*"      10      LC03-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LC03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LC03-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(012)    VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05        LC04-LINHA04.*/
            }
            public BI0060B_LC04_LINHA04 LC04_LINHA04 { get; set; } = new BI0060B_LC04_LINHA04();
            public class BI0060B_LC04_LINHA04 : VarBasis
            {
                /*"      10      LC04-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LC04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LC04-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(004)    VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LC04-IMPMORNATU     PIC  ZZZZ.ZZ9,99.*/
                public DoubleBasis LC04_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LC04-IMPMORACID     PIC  ZZZZ.ZZ9,99.*/
                public DoubleBasis LC04_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LC04-IMPMORINVP     PIC  ZZZZ.ZZ9,99.*/
                public DoubleBasis LC04_IMPMORINVP { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LC04-IMPMORESPO     PIC  ZZZZ.ZZ9,99.*/
                public DoubleBasis LC04_IMPMORESPO { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"      10      LC04-IMPMORESPO-X   REDEFINES              LC04-IMPMORESPO     PIC  X(011).*/
                private _REDEF_StringBasis _lc04_impmorespo_x { get; set; }
                public _REDEF_StringBasis LC04_IMPMORESPO_X
                {
                    get { _lc04_impmorespo_x = new _REDEF_StringBasis(new PIC("X", "011", "X(011).")); ; _.Move(LC04_IMPMORESPO, _lc04_impmorespo_x); VarBasis.RedefinePassValue(LC04_IMPMORESPO, _lc04_impmorespo_x, LC04_IMPMORESPO); _lc04_impmorespo_x.ValueChanged += () => { _.Move(_lc04_impmorespo_x, LC04_IMPMORESPO); }; return _lc04_impmorespo_x; }
                    set { VarBasis.RedefinePassValue(value, _lc04_impmorespo_x, LC04_IMPMORESPO); }
                }  //Redefines
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LC04-IMPMORIN       PIC  ZZZZ.ZZ9,99.*/
                public DoubleBasis LC04_IMPMORIN { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99."), 2);
                /*"    05        LC05-LINHA05.*/
            }
            public BI0060B_LC05_LINHA05 LC05_LINHA05 { get; set; } = new BI0060B_LC05_LINHA05();
            public class BI0060B_LC05_LINHA05 : VarBasis
            {
                /*"      10      LC05-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LC05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LC05-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      LC05-OPCAOPAG       PIC  X(059)    VALUE SPACES.*/
                public StringBasis LC05_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"");
                /*"    05        LC88-LINHA88.*/
            }
            public BI0060B_LC88_LINHA88 LC88_LINHA88 { get; set; } = new BI0060B_LC88_LINHA88();
            public class BI0060B_LC88_LINHA88 : VarBasis
            {
                /*"      10      LC88-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC88_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LC89-LINHA89.*/
            }
            public BI0060B_LC89_LINHA89 LC89_LINHA89 { get; set; } = new BI0060B_LC89_LINHA89();
            public class BI0060B_LC89_LINHA89 : VarBasis
            {
                /*"      10      LC89-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LC89_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LC89-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC89_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LC99-LINHA99.*/
            }
            public BI0060B_LC99_LINHA99 LC99_LINHA99 { get; set; } = new BI0060B_LC99_LINHA99();
            public class BI0060B_LC99_LINHA99 : VarBasis
            {
                /*"      10      LC99-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LC99_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LC99-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LC99_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(031)    VALUE            '$DJDE$ JDE=1VZ6,JDL=DFAULT,END;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"$DJDE$ JDE=1VZ6,JDL=DFAULT,END;");
                /*"    05        LM01-LINHA01.*/
            }
            public BI0060B_LM01_LINHA01 LM01_LINHA01 { get; set; } = new BI0060B_LM01_LINHA01();
            public class BI0060B_LM01_LINHA01 : VarBasis
            {
                /*"      10      LM01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LM01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LM01-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LM01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(011)    VALUE             '$DJDE$ JDE='.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"$DJDE$ JDE=");
                /*"      10      LM01-JDE            PIC  X(006).*/
                public StringBasis LM01_JDE { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"      10      FILLER              PIC  X(005)    VALUE             ',JDL='.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @",JDL=");
                /*"      10      LM01-JDL            PIC  X(006).*/
                public StringBasis LM01_JDL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"      10      FILLER              PIC  X(015)    VALUE             ',FEED=MAIN,END;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @",FEED=MAIN,END;");
                /*"    05        LV08-LINHA01.*/
            }
            public BI0060B_LV08_LINHA01 LV08_LINHA01 { get; set; } = new BI0060B_LV08_LINHA01();
            public class BI0060B_LV08_LINHA01 : VarBasis
            {
                /*"      10      LV08-CANAL-1        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_CANAL_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LV08-FONTE-1        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_FONTE_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      FILLER              PIC  X(035)    VALUE  SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05        LV08-LINHA02.*/
            }
            public BI0060B_LV08_LINHA02 LV08_LINHA02 { get; set; } = new BI0060B_LV08_LINHA02();
            public class BI0060B_LV08_LINHA02 : VarBasis
            {
                /*"      10      LV08-CANAL-2        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_CANAL_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LV08-FONTE-2        PIC  X(001)    VALUE '3'.*/
                public StringBasis LV08_FONTE_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      FILLER              PIC  X(043)    VALUE  SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"    05        LV09-LINHA01.*/
            }
            public BI0060B_LV09_LINHA01 LV09_LINHA01 { get; set; } = new BI0060B_LV09_LINHA01();
            public class BI0060B_LV09_LINHA01 : VarBasis
            {
                /*"      10      LV09-CANAL          PIC  X(001)    VALUE '3'.*/
                public StringBasis LV09_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LV09-FONTE          PIC  X(001)    VALUE '3'.*/
                public StringBasis LV09_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      FILLER              PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05        LMF2-LINHAF2.*/
            }
            public BI0060B_LMF2_LINHAF2 LMF2_LINHAF2 { get; set; } = new BI0060B_LMF2_LINHAF2();
            public class BI0060B_LMF2_LINHAF2 : VarBasis
            {
                /*"      10      LMF2-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMF2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMF2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMF2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(013)    VALUE  SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF2-VLPRMANT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMF2_VLPRMANT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(029)    VALUE  SPACES.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF2-VLMULTA        PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMF2_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"    05        LMF3-LINHAF3.*/
            }
            public BI0060B_LMF3_LINHAF3 LMF3_LINHAF3 { get; set; } = new BI0060B_LMF3_LINHAF3();
            public class BI0060B_LMF3_LINHAF3 : VarBasis
            {
                /*"      10      LMF3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMF3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMF3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMF3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF3-VLDESPESA      PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMF3_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(032)    VALUE  SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMF3-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMF3_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMG2-LINHAG2.*/
            }
            public BI0060B_LMG2_LINHAG2 LMG2_LINHAG2 { get; set; } = new BI0060B_LMG2_LINHAG2();
            public class BI0060B_LMG2_LINHAG2 : VarBasis
            {
                /*"      10      LMG2-CANAL          PIC  X(001)    VALUE '3'.*/
                public StringBasis LMG2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LMG2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMG2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(013)    VALUE  SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG2-VLPRMANT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG2_VLPRMANT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(030)    VALUE  SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG2-VLMULTA        PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMG2_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"    05        LMG3-LINHAG3.*/
            }
            public BI0060B_LMG3_LINHAG3 LMG3_LINHAG3 { get; set; } = new BI0060B_LMG3_LINHAG3();
            public class BI0060B_LMG3_LINHAG3 : VarBasis
            {
                /*"      10      LMG3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMG3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMG3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMG3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG3-VLDESPESA      PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMG3_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(028)    VALUE  SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG3-VLPRMINT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG3_VLPRMINT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMG4-LINHAG4.*/
            }
            public BI0060B_LMG4_LINHAG4 LMG4_LINHAG4 { get; set; } = new BI0060B_LMG4_LINHAG4();
            public class BI0060B_LMG4_LINHAG4 : VarBasis
            {
                /*"      10      LMG4-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMG4_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMG4-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMG4_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(026)    VALUE  SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG4-VLPROXPAR      PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG4_VLPROXPAR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(024)    VALUE  SPACES.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMG4-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMG4_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMH2-LINHAH2.*/
            }
            public BI0060B_LMH2_LINHAH2 LMH2_LINHAH2 { get; set; } = new BI0060B_LMH2_LINHAH2();
            public class BI0060B_LMH2_LINHAH2 : VarBasis
            {
                /*"      10      LMH2-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMH2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMH2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMH2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(022)    VALUE  SPACES.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH2-VLPRMANT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH2_VLPRMANT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(021)    VALUE  SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH2-VLMULTA        PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH2_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMH3-LINHAH3.*/
            }
            public BI0060B_LMH3_LINHAH3 LMH3_LINHAH3 { get; set; } = new BI0060B_LMH3_LINHAH3();
            public class BI0060B_LMH3_LINHAH3 : VarBasis
            {
                /*"      10      LMH3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMH3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMH3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMH3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH3-VLDESPESA      PIC  ZZ.ZZ9,99.*/
                public DoubleBasis LMH3_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(029)    VALUE  SPACES.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH3-VLPRMINT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH3_VLPRMINT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMH4-LINHAH4.*/
            }
            public BI0060B_LMH4_LINHAH4 LMH4_LINHAH4 { get; set; } = new BI0060B_LMH4_LINHAH4();
            public class BI0060B_LMH4_LINHAH4 : VarBasis
            {
                /*"      10      LMH4-CANAL-1        PIC  X(001)    VALUE '2'.*/
                public StringBasis LMH4_CANAL_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMH4-FONTE-1        PIC  X(001)    VALUE '1'.*/
                public StringBasis LMH4_FONTE_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(034)    VALUE  SPACES.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH4-VLPROXPAR      PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH4_VLPROXPAR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(019)    VALUE  SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"      10      FILLER              PIC  X(003)    VALUE 'R$'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"R$");
                /*"      10      LMH4-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMH4_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMM2-LINHAM2.*/
            }
            public BI0060B_LMM2_LINHAM2 LMM2_LINHAM2 { get; set; } = new BI0060B_LMM2_LINHAM2();
            public class BI0060B_LMM2_LINHAM2 : VarBasis
            {
                /*"      10      LMM2-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMM2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMM2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMM2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(031)    VALUE  SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"      10      LMM2-VLPRMDIF       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMM2_VLPRMDIF { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMM3-LINHAM3.*/
            }
            public BI0060B_LMM3_LINHAM3 LMM3_LINHAM3 { get; set; } = new BI0060B_LMM3_LINHAM3();
            public class BI0060B_LMM3_LINHAM3 : VarBasis
            {
                /*"      10      LMM3-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMM3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMM3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMM3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(024)    VALUE  SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"      10      LMM3-VLPREMIO       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMM3_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMM4-LINHAM4.*/
            }
            public BI0060B_LMM4_LINHAM4 LMM4_LINHAM4 { get; set; } = new BI0060B_LMM4_LINHAM4();
            public class BI0060B_LMM4_LINHAM4 : VarBasis
            {
                /*"      10      LMM4-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LMM4_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LMM4-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMM4_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(011)    VALUE  SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      LMM4-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMM4_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LMN1-LINHAN1.*/
            }
            public BI0060B_LMN1_LINHAN1 LMN1_LINHAN1 { get; set; } = new BI0060B_LMN1_LINHAN1();
            public class BI0060B_LMN1_LINHAN1 : VarBasis
            {
                /*"      10      LMN1-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LMN1_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LMN1-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMN1_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE  SPACES.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      FILLER              PIC  X(030)    VALUE             'HISTORICO'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"HISTORICO");
                /*"      10      FILLER              PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      FILLER              PIC  X(010)    VALUE             'REFERENCIA'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"REFERENCIA");
                /*"      10      FILLER              PIC  X(006)    VALUE  SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      FILLER              PIC  X(010)    VALUE             '     VALOR'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"     VALOR");
                /*"    05        LMN2-LINHAN2.*/
            }
            public BI0060B_LMN2_LINHAN2 LMN2_LINHAN2 { get; set; } = new BI0060B_LMN2_LINHAN2();
            public class BI0060B_LMN2_LINHAN2 : VarBasis
            {
                /*"      10      LMN2-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LMN2_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LMN2-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMN2_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE  SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LMN2-HISTORICO      PIC  X(030).*/
                public StringBasis LMN2_HISTORICO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      FILLER              PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LMN2-MMREFER        PIC  9(002).*/
                public IntBasis LMN2_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LMN2-AAREFER        PIC  9(004).*/
                public IntBasis LMN2_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LMN2-MOEDA          PIC  X(002)    VALUE 'R$'.*/
                public StringBasis LMN2_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"R$");
                /*"      10      LMN2-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMN2_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC  X(001)    VALUE '('.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10      LMN2-SINAL          PIC  X(001).*/
                public StringBasis LMN2_SINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE ')'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @")");
                /*"    05        LMN3-LINHAN3.*/
            }
            public BI0060B_LMN3_LINHAN3 LMN3_LINHAN3 { get; set; } = new BI0060B_LMN3_LINHAN3();
            public class BI0060B_LMN3_LINHAN3 : VarBasis
            {
                /*"      10      LMN3-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LMN3_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LMN3-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LMN3_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE  SPACES.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LMN3-HISTORICO      PIC  X(030).*/
                public StringBasis LMN3_HISTORICO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      FILLER              PIC  X(018)    VALUE  SPACES.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      LMN3-MOEDA          PIC  X(002)    VALUE 'R$'.*/
                public StringBasis LMN3_MOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"R$");
                /*"      10      LMN3-VLPRMTOT       PIC  ZZZ.ZZ9,99.*/
                public DoubleBasis LMN3_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05        LM88-LINHA88.*/
            }
            public BI0060B_LM88_LINHA88 LM88_LINHA88 { get; set; } = new BI0060B_LM88_LINHA88();
            public class BI0060B_LM88_LINHA88 : VarBasis
            {
                /*"      10      LM88-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LM88_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LM88-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LM88_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LM89-LINHA89.*/
            }
            public BI0060B_LM89_LINHA89 LM89_LINHA89 { get; set; } = new BI0060B_LM89_LINHA89();
            public class BI0060B_LM89_LINHA89 : VarBasis
            {
                /*"      10      LM89-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LM89_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LM89-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LM89_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LE01-LINHA01.*/
            }
            public BI0060B_LE01_LINHA01 LE01_LINHA01 { get; set; } = new BI0060B_LE01_LINHA01();
            public class BI0060B_LE01_LINHA01 : VarBasis
            {
                /*"      10      LE01-CANAL          PIC  X(001)    VALUE 'C'.*/
                public StringBasis LE01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"      10      LE01-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(057)    VALUE SPACES.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"");
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05        LE02-LINHA02.*/
            }
            public BI0060B_LE02_LINHA02 LE02_LINHA02 { get; set; } = new BI0060B_LE02_LINHA02();
            public class BI0060B_LE02_LINHA02 : VarBasis
            {
                /*"      10      LE02-CANAL          PIC  X(001)    VALUE 'C'.*/
                public StringBasis LE02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"      10      LE02-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    05        LE03-LINHA03.*/
            }
            public BI0060B_LE03_LINHA03 LE03_LINHA03 { get; set; } = new BI0060B_LE03_LINHA03();
            public class BI0060B_LE03_LINHA03 : VarBasis
            {
                /*"      10      LE03-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE03-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    05        LE04-LINHA04.*/
            }
            public BI0060B_LE04_LINHA04 LE04_LINHA04 { get; set; } = new BI0060B_LE04_LINHA04();
            public class BI0060B_LE04_LINHA04 : VarBasis
            {
                /*"      10      LE04-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE04-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05        LE05-LINHA05.*/
            }
            public BI0060B_LE05_LINHA05 LE05_LINHA05 { get; set; } = new BI0060B_LE05_LINHA05();
            public class BI0060B_LE05_LINHA05 : VarBasis
            {
                /*"      10      LE05-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE05-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05        LE00-LINHA00.*/
            }
            public BI0060B_LE00_LINHA00 LE00_LINHA00 { get; set; } = new BI0060B_LE00_LINHA00();
            public class BI0060B_LE00_LINHA00 : VarBasis
            {
                /*"      10      LE00-CANAL          PIC  X(001)    VALUE 'C'.*/
                public StringBasis LE00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
                /*"      10      LE00-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE00_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(022)    VALUE SPACES.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"      10      FILLER              PIC  X(008)    VALUE                                 'GEPES - '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"      10      LE00-NOMPRODU       PIC  X(032).*/
                public StringBasis LE00_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"    05        LE06-LINHA06.*/
            }
            public BI0060B_LE06_LINHA06 LE06_LINHA06 { get; set; } = new BI0060B_LE06_LINHA06();
            public class BI0060B_LE06_LINHA06 : VarBasis
            {
                /*"      10      LE06-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE06-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE06_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      FILLER              PIC  X(009)    VALUE                                 'FILIAL - '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FILIAL - ");
                /*"    05        LE07-LINHA07.*/
            }
            public BI0060B_LE07_LINHA07 LE07_LINHA07 { get; set; } = new BI0060B_LE07_LINHA07();
            public class BI0060B_LE07_LINHA07 : VarBasis
            {
                /*"      10      LE07-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE07_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE07-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE07_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    05        LE08-LINHA08.*/
            }
            public BI0060B_LE08_LINHA08 LE08_LINHA08 { get; set; } = new BI0060B_LE08_LINHA08();
            public class BI0060B_LE08_LINHA08 : VarBasis
            {
                /*"      10      LE08-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE08_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE08-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE08_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05        LE09-LINHA09.*/
            }
            public BI0060B_LE09_LINHA09 LE09_LINHA09 { get; set; } = new BI0060B_LE09_LINHA09();
            public class BI0060B_LE09_LINHA09 : VarBasis
            {
                /*"      10      LE09-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE09_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE09-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LE09_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(014)    VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05        LF01-LINHA01.*/
            }
            public BI0060B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new BI0060B_LF01_LINHA01();
            public class BI0060B_LF01_LINHA01 : VarBasis
            {
                /*"      10      LF01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LF01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LF01-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LF01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(070)    VALUE             '$DJDE$ JDE=FACPEQ,JDL=VIDAZ,FEED=AUX,END;'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=FACPEQ,JDL=VIDAZ,FEED=AUX,END;");
                /*"    05        LF02-LINHA02.*/
            }
            public BI0060B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new BI0060B_LF02_LINHA02();
            public class BI0060B_LF02_LINHA02 : VarBasis
            {
                /*"      10      LF02-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LF02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LF02-NOME-FAIXA     PIC  X(072).*/
                public StringBasis LF02_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        LF03-LINHA03.*/
            }
            public BI0060B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new BI0060B_LF03_LINHA03();
            public class BI0060B_LF03_LINHA03 : VarBasis
            {
                /*"      10      LF03-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LF03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LF03-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      FAIXA-INT.*/
                public BI0060B_FAIXA_INT FAIXA_INT { get; set; } = new BI0060B_FAIXA_INT();
                public class BI0060B_FAIXA_INT : VarBasis
                {
                    /*"        15    LF03-FAIXA1         PIC  X(005).*/
                    public StringBasis LF03_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"        15    FILLER              PIC  X(001)    VALUE '-'.*/
                    public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15    LF03-FAIXA1C        PIC  X(003).*/
                    public StringBasis LF03_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"        15    FILLER              PIC  X(005)    VALUE '  A '.*/
                    public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                    /*"        15    LF03-FAIXA2         PIC  X(005).*/
                    public StringBasis LF03_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"        15    FILLER              PIC  X(001)    VALUE '-'.*/
                    public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15    LF03-FAIXA2C        PIC  X(003).*/
                    public StringBasis LF03_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"    05        LF04-LINHA04.*/
                }
            }
            public BI0060B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new BI0060B_LF04_LINHA04();
            public class BI0060B_LF04_LINHA04 : VarBasis
            {
                /*"      10      LF04-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LF04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LF04-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(003)    VALUE SPACES.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LF04-QTD-OBJ        PIC  9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        LF05-LINHA05.*/
            }
            public BI0060B_LF05_LINHA05 LF05_LINHA05 { get; set; } = new BI0060B_LF05_LINHA05();
            public class BI0060B_LF05_LINHA05 : VarBasis
            {
                /*"      10      LF05-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LF05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LF05-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(003)    VALUE SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LF05-AMARRADO       PIC  ZZZ.999.*/
                public IntBasis LF05_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      SEQ-INT.*/
                public BI0060B_SEQ_INT SEQ_INT { get; set; } = new BI0060B_SEQ_INT();
                public class BI0060B_SEQ_INT : VarBasis
                {
                    /*"         15   LF05-SEQ-INICIAL    PIC  ZZZ.999.*/
                    public IntBasis LF05_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                    /*"         15   FILLER              PIC  X(001)    VALUE '/'.*/
                    public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"         15   LF05-SEQ-FINAL      PIC  ZZZ.999.*/
                    public IntBasis LF05_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                    /*"    05        LR01-LINHA01.*/
                }
            }
            public BI0060B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new BI0060B_LR01_LINHA01();
            public class BI0060B_LR01_LINHA01 : VarBasis
            {
                /*"      10      LR01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LR01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LR01-FONTE          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LR01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      FILLER              PIC  X(070)    VALUE             '$DJDE$ JDE=FACLST,JDL=VIDAZ,FEED=MAIN,END;'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=FACLST,JDL=VIDAZ,FEED=MAIN,END;");
                /*"    05        LR02-LINHA02.*/
            }
            public BI0060B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new BI0060B_LR02_LINHA02();
            public class BI0060B_LR02_LINHA02 : VarBasis
            {
                /*"      10      LR02-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LR02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(090)    VALUE SPACES.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"      10      LISTAGEM-INT.*/
                public BI0060B_LISTAGEM_INT LISTAGEM_INT { get; set; } = new BI0060B_LISTAGEM_INT();
                public class BI0060B_LISTAGEM_INT : VarBasis
                {
                    /*"         15   LR02-SEQ            PIC  ZZ9.*/
                    public IntBasis LR02_SEQ { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                    /*"         15   FILLER              PIC  X(003)    VALUE ' / '.*/
                    public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" / ");
                    /*"         15   LR02-MES            PIC  X(009).*/
                    public StringBasis LR02_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                    /*"      10      FILLER              PIC  X(017)    VALUE SPACES.*/
                }
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"      10      LR02-PAG-INT.*/
                public BI0060B_LR02_PAG_INT LR02_PAG_INT { get; set; } = new BI0060B_LR02_PAG_INT();
                public class BI0060B_LR02_PAG_INT : VarBasis
                {
                    /*"        15    LR02-PAGINA         PIC  999.*/
                    public IntBasis LR02_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"        15    FILLER              PIC  X(001)    VALUE '/'.*/
                    public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15    LR02-PAG-FINAL      PIC  999       VALUE 003.*/
                    public IntBasis LR02_PAG_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "999"), 003);
                    /*"    05        LR03-LINHA03.*/
                }
            }
            public BI0060B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new BI0060B_LR03_LINHA03();
            public class BI0060B_LR03_LINHA03 : VarBasis
            {
                /*"      10      LR03-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LR03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LR03-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(100)    VALUE SPACES.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"      10      FILLER              PIC  X(008)    VALUE 'GEPES -'*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES -");
                /*"      10      LR03-TP-PGTO        PIC  X(022).*/
                public StringBasis LR03_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
                /*"    05        LR04-LINHA04.*/
            }
            public BI0060B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new BI0060B_LR04_LINHA04();
            public class BI0060B_LR04_LINHA04 : VarBasis
            {
                /*"      10      LR04-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LR04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LR04-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(086)    VALUE SPACES.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"");
                /*"      10      LR04-DATA           PIC  X(010).*/
                public StringBasis LR04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05        LR05-LINHA05.*/
            }
            public BI0060B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new BI0060B_LR05_LINHA05();
            public class BI0060B_LR05_LINHA05 : VarBasis
            {
                /*"      10      FILLER              PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      LR05-CEPI           PIC  9(005).*/
                public IntBasis LR05_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR05-COMPL-CEPI     PIC  9(003).*/
                public IntBasis LR05_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR05-CEPF           PIC  9(005).*/
                public IntBasis LR05_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR05-COMPL-CEPF     PIC  9(003).*/
                public IntBasis LR05_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR05-OBJI           PIC  ZZZ.999.*/
                public IntBasis LR05_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR05-OBJF           PIC  ZZZ.999.*/
                public IntBasis LR05_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR05-AMARI          PIC  ZZZ.999.*/
                public IntBasis LR05_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR05-AMARF          PIC  ZZZ.999.*/
                public IntBasis LR05_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR05-QTD-OBJ        PIC  ZZZ.999.*/
                public IntBasis LR05_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR05-QTD-AMAR       PIC  ZZZ.999.*/
                public IntBasis LR05_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(004)    VALUE SPACES.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LR05-OBS            PIC  X(023).*/
                public StringBasis LR05_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05        LR06-LINHA06.*/
            }
            public BI0060B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new BI0060B_LR06_LINHA06();
            public class BI0060B_LR06_LINHA06 : VarBasis
            {
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR06-CEPI           PIC  9(005).*/
                public IntBasis LR06_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR06-COMPL-CEPI     PIC  9(003).*/
                public IntBasis LR06_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR06-CEPF           PIC  9(005).*/
                public IntBasis LR06_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR06-COMPL-CEPF     PIC  9(003).*/
                public IntBasis LR06_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR06-OBJI           PIC  ZZZ.999.*/
                public IntBasis LR06_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR06-OBJF           PIC  ZZZ.999.*/
                public IntBasis LR06_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR06-AMARI          PIC  ZZZ.999.*/
                public IntBasis LR06_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR06-AMARF          PIC  ZZZ.999.*/
                public IntBasis LR06_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR06-QTD-OBJ        PIC  ZZZ.999.*/
                public IntBasis LR06_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR06-QTD-AMAR       PIC  ZZZ.999.*/
                public IntBasis LR06_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(004)    VALUE SPACES.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LR06-OBS            PIC  X(023).*/
                public StringBasis LR06_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05        LK-PROSOMU1.*/
            }
            public BI0060B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new BI0060B_LK_PROSOMU1();
            public class BI0060B_LK_PROSOMU1 : VarBasis
            {
                /*"      10      LK-DATA-SOM         PIC  9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-SOM-R       REDEFINES              LK-DATA-SOM.*/
                private _REDEF_BI0060B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_BI0060B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_BI0060B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_BI0060B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15    LK-DIA-SOM          PIC  9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-SOM          PIC  9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-SOM          PIC  9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      LK-QTDIAS           PIC S9(005)    COMP-3 VALUE +2*/

                    public _REDEF_BI0060B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +2);
                /*"      10      LK-DATA-CALC        PIC  9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-CALC-R      REDEFINES              LK-DATA-CALC.*/
                private _REDEF_BI0060B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_BI0060B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_BI0060B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_BI0060B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15    LK-DIA-CALC         PIC  9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-CALC         PIC  9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-CALC         PIC  9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05        WSL-SQLCODE         PIC  9(009)    VALUE ZEROS.*/

                    public _REDEF_BI0060B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-LINHAS           PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05        WWORK-QTDE01.*/
            public BI0060B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new BI0060B_WWORK_QTDE01();
            public class BI0060B_WWORK_QTDE01 : VarBasis
            {
                /*"       10     WWORK-QTDE11        PIC  9(004).*/
                public IntBasis WWORK_QTDE11 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10     WWORK-QTDE12        PIC  9(002).*/
                public IntBasis WWORK_QTDE12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWORK-QTDE  REDEFINES  WWORK-QTDE01                                  PIC S9(004)V99.*/
            }
            private _REDEF_DoubleBasis _wwork_qtde { get; set; }
            public _REDEF_DoubleBasis WWORK_QTDE
            {
                get { _wwork_qtde = new _REDEF_DoubleBasis(new PIC("S9", "004", "S9(004)V99."), 2); ; _.Move(WWORK_QTDE01, _wwork_qtde); VarBasis.RedefinePassValue(WWORK_QTDE01, _wwork_qtde, WWORK_QTDE01); _wwork_qtde.ValueChanged += () => { _.Move(_wwork_qtde, WWORK_QTDE01); }; return _wwork_qtde; }
                set { VarBasis.RedefinePassValue(value, _wwork_qtde, WWORK_QTDE01); }
            }  //Redefines
            /*"    05        WS-COUNT            PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05        WHOST-PROXIMA-DATA  PIC  X(010)    VALUE SPACES.*/
            public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05        AC-PAGINA           PIC  9(003)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        AC-CONTA1           PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA-910        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA_910 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-I-RELATORIOS     PIC S9(005)    COMP-3 VALUE +0*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05        WS-IMPMORACID       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-IMPMORESPO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORESPO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPRMTOT         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPREMIO         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLMULTA          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-CAR-CONJUGE      PIC  9(003)V99 VALUE ZEROS.*/
            public DoubleBasis WS_CAR_CONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
            /*"    05        WS-OCORR            PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-JDE-GER.*/
            public BI0060B_WS_JDE_GER WS_JDE_GER { get; set; } = new BI0060B_WS_JDE_GER();
            public class BI0060B_WS_JDE_GER : VarBasis
            {
                /*"      15      WS-JDE              PIC X(004).*/
                public StringBasis WS_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      15      FILLER              PIC X(001) VALUE '.'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      15      WS-DBM              PIC X(003).*/
                public StringBasis WS_DBM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05        WS-AMARRADO         PIC  9(006)    VALUE ZEROS.*/
            }
            public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ-INICIAL      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTD-OBJ          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTROLE         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-AMAR       PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-OBJ        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-200        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-IDSEXO           PIC  X(001).*/
            public StringBasis WS_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-CONTR-PRODU      PIC  X(001).*/
            public StringBasis WS_CONTR_PRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-JDE-ANT          PIC  X(006).*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05        WS-BILHETE-ANT      PIC  9(015).*/
            public IntBasis WS_BILHETE_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        WS-OPER-ANT         PIC  9(004).*/
            public IntBasis WS_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        WS-CEP-G-ANT        PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        WDESPREZA           PIC  X(001)   VALUE 'N'.*/
            public StringBasis WDESPREZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    05        WDESPREZA-PI        PIC  X(001)   VALUE 'N'.*/
            public StringBasis WDESPREZA_PI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    05        WS-NOME-COR-ANT.*/
            public BI0060B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new BI0060B_WS_NOME_COR_ANT();
            public class BI0060B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10      WS-FAIXA1-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-FAIXA2-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-NOME-ANT         PIC  X(072).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        WS-CEP-ANT          PIC  9(005).*/
            }
            public IntBasis WS_CEP_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-COMPL-ANT        PIC  9(003).*/
            public IntBasis WS_COMPL_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05        WS-INF              PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-SUP              PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-IND              PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND                PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDR               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND1               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDM               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDH               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND1            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND2            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        INF                 PIC S9(009)    COMP.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SUP                 PIC S9(009)    COMP.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        DEST-NUM-CEP.*/
            public BI0060B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new BI0060B_DEST_NUM_CEP();
            public class BI0060B_DEST_NUM_CEP : VarBasis
            {
                /*"      15      DEST-CEP            PIC  9(005)    VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15      DEST-CEP-COMPL      PIC  9(003)    VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05        WS-CPF              PIC  9(015).*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CPF-R            REDEFINES              WS-CPF.*/
            private _REDEF_BI0060B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_BI0060B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_BI0060B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_BI0060B_WS_CPF_R : VarBasis
            {
                /*"      10      WS-NRCPF            PIC  9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-DVCPF            PIC  9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SQL.*/

                public _REDEF_BI0060B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public BI0060B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new BI0060B_WS_DATA_SQL();
            public class BI0060B_WS_DATA_SQL : VarBasis
            {
                /*"      10      WS-ANO-SQL          PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-DATA.*/
            }
            public BI0060B_WS_DATA WS_DATA { get; set; } = new BI0060B_WS_DATA();
            public class BI0060B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-CERTIF           PIC  9(015).*/
            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CERTIF-R         REDEFINES WS-CERTIF.*/
            private _REDEF_BI0060B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_BI0060B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_BI0060B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_BI0060B_WS_CERTIF_R : VarBasis
            {
                /*"      10      WS-NRCERTIF         PIC  9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      WS-DVCERTIF         PIC  9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-TITULO           PIC  9(013).*/

                public _REDEF_BI0060B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-TITULO-R         REDEFINES WS-TITULO.*/
            private _REDEF_BI0060B_WS_TITULO_R _ws_titulo_r { get; set; }
            public _REDEF_BI0060B_WS_TITULO_R WS_TITULO_R
            {
                get { _ws_titulo_r = new _REDEF_BI0060B_WS_TITULO_R(); _.Move(WS_TITULO, _ws_titulo_r); VarBasis.RedefinePassValue(WS_TITULO, _ws_titulo_r, WS_TITULO); _ws_titulo_r.ValueChanged += () => { _.Move(_ws_titulo_r, WS_TITULO); }; return _ws_titulo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_titulo_r, WS_TITULO); }
            }  //Redefines
            public class _REDEF_BI0060B_WS_TITULO_R : VarBasis
            {
                /*"      10      WS-NRTIT            PIC  9(012).*/
                public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      10      WS-DVTITULO         PIC  9(001).*/
                public IntBasis WS_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-DATA-I.*/

                public _REDEF_BI0060B_WS_TITULO_R()
                {
                    WS_NRTIT.ValueChanged += OnValueChanged;
                    WS_DVTITULO.ValueChanged += OnValueChanged;
                }

            }
            public BI0060B_WS_DATA_I WS_DATA_I { get; set; } = new BI0060B_WS_DATA_I();
            public class BI0060B_WS_DATA_I : VarBasis
            {
                /*"      10      WS-DIA-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB1            PIC  X(001).*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB2            PIC  X(001).*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO-I            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05        WHORA-CURR          PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05        WS-NOME-RAZAO.*/
            public BI0060B_WS_NOME_RAZAO WS_NOME_RAZAO { get; set; } = new BI0060B_WS_NOME_RAZAO();
            public class BI0060B_WS_NOME_RAZAO : VarBasis
            {
                /*"      10      WS-LETRA-NOME       OCCURS 41 TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_LETRA_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 41);
                /*"    05        WS-NUM-CEP-AUX      PIC  9(008).*/
            }
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-NUM-CEP-AUX-R    REDEFINES              WS-NUM-CEP-AUX.*/
            private _REDEF_BI0060B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_BI0060B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_BI0060B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_BI0060B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10      WS-CEP-AUX          PIC  9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CEP-COMPL-AUX    PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-NUM-CEP-AUX-R1   REDEFINES              WS-NUM-CEP-AUX.*/

                public _REDEF_BI0060B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_BI0060B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_BI0060B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_BI0060B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_BI0060B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10      WS-CEP-COMPL-AUX1   PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-CEP-AUX1         PIC  9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-CHAVE            PIC  X(020).*/

                public _REDEF_BI0060B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_BI0060B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_BI0060B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_BI0060B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_BI0060B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-APOLICE          PIC  9(013).*/
                public IntBasis WS_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(004).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        AC-LIDOS            PIC  9(009)    VALUE ZEROES.*/

                public _REDEF_BI0060B_WS_CHAVE_R()
                {
                    WS_APOLICE.ValueChanged += OnValueChanged;
                    WS_CODSUBES.ValueChanged += OnValueChanged;
                    WS_CODOPER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        CT-LIDOS            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis CT_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        CT-DESPZ            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis CT_DESPZ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        CT-GRAVS            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis CT_GRAVS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        CT-SELEC            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis CT_SELEC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-CONTA            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-IMPRESSOS        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        WFIM-SISTEMAs       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SISTEMAs { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V1AGENCEF      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0FAIXACEP     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-APOLICES       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_APOLICES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0MSGCOBR      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MSGCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0PARCELVA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0DIFPARCEL    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0DIFPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-SORT           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-TABELA         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-MULTIMSG       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_MULTIMSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-CONDTEC        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_CONDTEC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01            TAB-FILIAL.*/
        }
        public BI0060B_TAB_FILIAL TAB_FILIAL { get; set; } = new BI0060B_TAB_FILIAL();
        public class BI0060B_TAB_FILIAL : VarBasis
        {
            /*"    05        FILLER              OCCURS 19 TIMES.*/
            public ListBasis<BI0060B_FILLER_181> FILLER_181 { get; set; } = new ListBasis<BI0060B_FILLER_181>(19);
            public class BI0060B_FILLER_181 : VarBasis
            {
                /*"      10      TAB-FONTE           PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      TAB-NOMEFTE         PIC  X(40).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-ENDERFTE        PIC  X(40).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-BAIRRO          PIC  X(20).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CIDADE          PIC  X(20).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CEP             PIC  9(08).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      TAB-UF              PIC  X(02).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"01            TABELA-REGISTROS.*/
            }
        }
        public BI0060B_TABELA_REGISTROS TABELA_REGISTROS { get; set; } = new BI0060B_TABELA_REGISTROS();
        public class BI0060B_TABELA_REGISTROS : VarBasis
        {
            /*"  03          TAB-REG             OCCURS 2 TIMES.*/
            public ListBasis<BI0060B_TAB_REG> TAB_REG { get; set; } = new ListBasis<BI0060B_TAB_REG>(2);
            public class BI0060B_TAB_REG : VarBasis
            {
                /*"    05        TVA-NUM-CEP.*/
                public BI0060B_TVA_NUM_CEP TVA_NUM_CEP { get; set; } = new BI0060B_TVA_NUM_CEP();
                public class BI0060B_TVA_NUM_CEP : VarBasis
                {
                    /*"      15      TVA-CEP             PIC  9(005).*/
                    public IntBasis TVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15      TVA-CEP-COMPL       PIC  9(003).*/
                    public IntBasis TVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"    05        TVA-NOME-RAZAO      PIC  X(040).*/
                }
                public StringBasis TVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        TVA-ENDERECO        PIC  X(072).*/
                public StringBasis TVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        TVA-BAIRRO          PIC  X(072).*/
                public StringBasis TVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        TVA-CIDADE          PIC  X(072).*/
                public StringBasis TVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        TVA-UF              PIC  X(002).*/
                public StringBasis TVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        TVA-BILHETE         PIC  9(015).*/
                public IntBasis TVA_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    05        TVA-FONTE           PIC  9(004).*/
                public IntBasis TVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        TVA-SORTEIO         PIC  9(009).*/
                public IntBasis TVA_SORTEIO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    05        TVA-PRODUTO         PIC  9(004).*/
                public IntBasis TVA_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01            TABELA-CEP.*/
            }
        }
        public BI0060B_TABELA_CEP TABELA_CEP { get; set; } = new BI0060B_TABELA_CEP();
        public class BI0060B_TABELA_CEP : VarBasis
        {
            /*"    05        CEP                 OCCURS 2000 TIMES.*/
            public ListBasis<BI0060B_CEP> CEP { get; set; } = new ListBasis<BI0060B_CEP>(2000);
            public class BI0060B_CEP : VarBasis
            {
                /*"      10      TAB-FX-CEP-G        PIC  9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TAB-FAIXAS.*/
                public BI0060B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new BI0060B_TAB_FAIXAS();
                public class BI0060B_TAB_FAIXAS : VarBasis
                {
                    /*"        15    TAB-FX-INI          PIC  9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-FIM          PIC  9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-NOME         PIC  X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15    TAB-FX-CENTR        PIC  X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-VALORES.*/
                }
            }
        }
        public BI0060B_TABELA_VALORES TABELA_VALORES { get; set; } = new BI0060B_TABELA_VALORES();
        public class BI0060B_TABELA_VALORES : VarBasis
        {
            /*"    05        TAB-VALORES         OCCURS    3 TIMES.*/
            public ListBasis<BI0060B_TAB_VALORES> TAB_VALORES { get; set; } = new ListBasis<BI0060B_TAB_VALORES>(3);
            public class BI0060B_TAB_VALORES : VarBasis
            {
                /*"      10      TAB-VLPRMTOT        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLPREMIO        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLMULTA         PIC  9(013)V99.*/
                public DoubleBasis TAB_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-HISTORICO.*/
            }
        }
        public BI0060B_TABELA_HISTORICO TABELA_HISTORICO { get; set; } = new BI0060B_TABELA_HISTORICO();
        public class BI0060B_TABELA_HISTORICO : VarBasis
        {
            /*"    05        TABH                OCCURS   10 TIMES.*/
            public ListBasis<BI0060B_TABH> TABH { get; set; } = new ListBasis<BI0060B_TABH>(10);
            public class BI0060B_TABH : VarBasis
            {
                /*"      10      TABH-DESCRICAO      PIC  X(030).*/
                public StringBasis TABH_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      TABH-MMREFER        PIC  9(002).*/
                public IntBasis TABH_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      TABH-AAREFER        PIC  9(004).*/
                public IntBasis TABH_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TABH-VLPRMTOT       PIC S9(013)V99.*/
                public DoubleBasis TABH_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
                /*"01            TABELA-TOTAIS.*/
            }
        }
        public BI0060B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new BI0060B_TABELA_TOTAIS();
        public class BI0060B_TABELA_TOTAIS : VarBasis
        {
            /*"    05        TAB-TOTAIS          OCCURS  2000 TIMES.*/
            public ListBasis<BI0060B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<BI0060B_TAB_TOTAIS>(2000);
            public class BI0060B_TAB_TOTAIS : VarBasis
            {
                /*"      10      TAB1-OBJI           PIC  9(006).*/
                public IntBasis TAB1_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-OBJF           PIC  9(006).*/
                public IntBasis TAB1_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARI          PIC  9(006).*/
                public IntBasis TAB1_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARF          PIC  9(006).*/
                public IntBasis TAB1_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-OBJ        PIC  9(006).*/
                public IntBasis TAB1_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-AMAR       PIC  9(006).*/
                public IntBasis TAB1_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01            TABELA-MSG.*/
            }
        }
        public BI0060B_TABELA_MSG TABELA_MSG { get; set; } = new BI0060B_TABELA_MSG();
        public class BI0060B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 2000  TIMES.*/
            public ListBasis<BI0060B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<BI0060B_TAB_MSG>(2000);
            public class BI0060B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(020).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_BI0060B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_BI0060B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_BI0060B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_BI0060B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-APOLICE        PIC  9(013).*/
                    public IntBasis TABJ_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(004).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_BI0060B_TABJ_CHAVE_R()
                    {
                        TABJ_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01            TABELA-MESES.*/
            }
        }
        public BI0060B_TABELA_MESES TABELA_MESES { get; set; } = new BI0060B_TABELA_MESES();
        public class BI0060B_TABELA_MESES : VarBasis
        {
            /*"    05        TAB-MESES.*/
            public BI0060B_TAB_MESES TAB_MESES { get; set; } = new BI0060B_TAB_MESES();
            public class BI0060B_TAB_MESES : VarBasis
            {
                /*"      10      FILLER              PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10      FILLER              PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05        TAB-MESES-R         REDEFINES              TAB-MESES.*/
            }
            private _REDEF_BI0060B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_BI0060B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_BI0060B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_BI0060B_TAB_MESES_R : VarBasis
            {
                /*"      10      TAB-MES             OCCURS 12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01          WABEND.*/

                public _REDEF_BI0060B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI0060B_WABEND WABEND { get; set; } = new BI0060B_WABEND();
        public class BI0060B_WABEND : VarBasis
        {
            /*"      05    FILLER              PIC  X(010) VALUE           ' BI0060B'.*/
            public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0060B");
            /*"      05    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05    WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05    FILLER              PIC  X(013) VALUE           ' SECTION '.*/
            public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" SECTION ");
            /*"      05    WNR-ROTINA          PIC  X(050) VALUE SPACES.*/
            public StringBasis WNR_ROTINA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"      05    FILLER              PIC  X(013) VALUE           ' SQLCODE = '.*/
            public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" SQLCODE = ");
            /*"      05    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public BI0060B_CFAIXACEP CFAIXACEP { get; set; } = new BI0060B_CFAIXACEP();
        public BI0060B_V1AGENCEF V1AGENCEF { get; set; } = new BI0060B_V1AGENCEF();
        public BI0060B_CAPOLICE CAPOLICE { get; set; } = new BI0060B_CAPOLICE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RBI0060B_FILE_NAME_P, string FBI0060B_FILE_NAME_P, string SBI0060B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RBI0060B.SetFile(RBI0060B_FILE_NAME_P);
                FBI0060B.SetFile(FBI0060B_FILE_NAME_P);
                SBI0060B.SetFile(SBI0060B_FILE_NAME_P);

                /*" -1264- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1267- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -1270- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1270- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1279- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WABEND.WNR_EXEC_SQL);

            /*" -1282- MOVE 'R0000-00-PRINCIPAL' TO WNR-ROTINA. */
            _.Move("R0000-00-PRINCIPAL", WABEND.WNR_ROTINA);

            /*" -1284- DISPLAY 'BI0060B - VERSAO V.05 - CADMUS 24.836' */
            _.Display($"BI0060B - VERSAO V.05 - CADMUS 24.836");

            /*" -1285- MOVE ZEROS TO TABELA-TOTAIS */
            _.Move(0, TABELA_TOTAIS);

            /*" -1287- INITIALIZE TAB-FILIAL. */
            _.Initialize(
                TAB_FILIAL
            );

            /*" -1289- PERFORM R0500-00-DECLARE-V1AGENCEF. */

            R0500_00_DECLARE_V1AGENCEF_SECTION();

            /*" -1291- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

            /*" -1292- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -1293- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -1295- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1300- PERFORM R0520-00-CARREGA-FILIAL VARYING IDX-IND1 FROM 1 BY 1 UNTIL IDX-IND1 > 19 OR WFIM-V1AGENCEF EQUAL 'S' . */

            for (AREA_DE_WORK.IDX_IND1.Value = 1; !(AREA_DE_WORK.IDX_IND1 > 19 || AREA_DE_WORK.WFIM_V1AGENCEF == "S"); AREA_DE_WORK.IDX_IND1.Value += 1)
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1302- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1303- IF WFIM-SISTEMAs NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMAs.IsEmpty())
            {

                /*" -1305- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1307- PERFORM R0900-00-DECLARE-APOLICES. */

            R0900_00_DECLARE_APOLICES_SECTION();

            /*" -1309- PERFORM R0910-00-FETCH-APOLICES. */

            R0910_00_FETCH_APOLICES_SECTION();

            /*" -1310- IF WFIM-APOLICES EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_APOLICES == "S")
            {

                /*" -1311- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1312- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1314- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1316- PERFORM R0200-00-CARREGA-V0FAIXACEP. */

            R0200_00_CARREGA_V0FAIXACEP_SECTION();

            /*" -1318- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1323- SORT SBI0060B ON ASCENDING KEY SVA-BILHETE SVA-CEP-G SVA-NUM-CEP INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SBI0060B.Sort("SVA-BILHETE,SVA-CEP-G,SVA-NUM-CEP", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1326- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1327- DISPLAY '*** BI0060B *** PROBLEMAS NO SORT ' */
                _.Display($"*** BI0060B *** PROBLEMAS NO SORT ");

                /*" -1328- DISPLAY '*** BI0060B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** BI0060B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1329- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1329- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1335- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1335- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1337- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1343- COMPUTE CT-DESPZ = CT-LIDOS - CT-GRAVS. */
            AREA_DE_WORK.CT_DESPZ.Value = AREA_DE_WORK.CT_LIDOS - AREA_DE_WORK.CT_GRAVS;

            /*" -1344- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1345- DISPLAY '*           TOTAIS DE CONTROLE               *' */
            _.Display($"*           TOTAIS DE CONTROLE               *");

            /*" -1346- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1348- DISPLAY '* REGISTROS LIDOS                = ' CT-LIDOS ' *' */

            $"* REGISTROS LIDOS                = {AREA_DE_WORK.CT_LIDOS} *"
            .Display();

            /*" -1350- DISPLAY '* REGISTROS INSERIDOS (GEOBJECT) = ' CT-GRAVS ' *' */

            $"* REGISTROS INSERIDOS (GEOBJECT) = {AREA_DE_WORK.CT_GRAVS} *"
            .Display();

            /*" -1352- DISPLAY '* REGISTROS REJEITADOS           = ' CT-DESPZ ' *' */

            $"* REGISTROS REJEITADOS           = {AREA_DE_WORK.CT_DESPZ} *"
            .Display();

            /*" -1354- DISPLAY '*---------* BI0060B - FIM NORMAL *-----------*' */
            _.Display($"*---------* BI0060B - FIM NORMAL *-----------*");

            /*" -1354- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1366- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WABEND.WNR_EXEC_SQL);

            /*" -1369- MOVE 'R0010-00-SELECIONA' TO WNR-ROTINA. */
            _.Move("R0010-00-SELECIONA", WABEND.WNR_ROTINA);

            /*" -1372- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-APOLICES EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_APOLICES == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -1372- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1384- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", WABEND.WNR_EXEC_SQL);

            /*" -1387- MOVE 'R0020-00-IMPRIME' TO WNR-ROTINA. */
            _.Move("R0020-00-IMPRIME", WABEND.WNR_ROTINA);

            /*" -1389- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1391- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -1397- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1397- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1409- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1414- MOVE 'R0100-00-SELECT-SISTEMAS' TO WNR-ROTINA. */
            _.Move("R0100-00-SELECT-SISTEMAS", WABEND.WNR_ROTINA);

            /*" -1425- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1428- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1429- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1430- DISPLAY 'BI0060B - SISTEMA EM NAO ESTA CADASTRADO' */
                    _.Display($"BI0060B - SISTEMA EM NAO ESTA CADASTRADO");

                    /*" -1431- MOVE 'S' TO WFIM-SISTEMAs */
                    _.Move("S", AREA_DE_WORK.WFIM_SISTEMAs);

                    /*" -1432- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1433- ELSE */
                }
                else
                {


                    /*" -1433- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1425- EXEC SQL SELECT DATA_MOV_ABERTO, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO), (DATA_MOV_ABERTO + 1 DAY) INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-MESREFER, :V1SIST-ANOREFER, :WHOST-DTMOVABE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.WHOST_DTMOVABE, WHOST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-SECTION */
        private void R0200_00_CARREGA_V0FAIXACEP_SECTION()
        {
            /*" -1445- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1450- MOVE 'R0200-00-CARREGA-V0FAIXACEP' TO WNR-ROTINA. */
            _.Move("R0200-00-CARREGA-V0FAIXACEP", WABEND.WNR_ROTINA);

            /*" -1460- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();

            /*" -1462- PERFORM R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1();

            /*" -1465- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1466- DISPLAY 'BI0060B - PROBLEMAS NA V0FAIXA_CEP' */
                _.Display($"BI0060B - PROBLEMAS NA V0FAIXA_CEP");

                /*" -1468- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1469- PERFORM R0210-00-FETCH-V0FAIXACEP UNTIL WFIM-V0FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0FAIXACEP == "S"))
            {

                R0210_00_FETCH_V0FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1()
        {
            /*" -1460- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new BI0060B_CFAIXACEP(true);
            string GetQuery_CFAIXACEP()
            {
                var query = @$"SELECT FAIXA
							, 
							CEP_INICIAL
							, 
							CEP_FINAL
							, 
							DESCRICAO_FAIXA
							, 
							CENTRALIZADOR 
							FROM SEGUROS.GE_FAIXA_CEP 
							WHERE DATA_INIVIGENCIA <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DATA_TERVIGENCIA >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY FAIXA";

                return query;
            }
            CFAIXACEP.GetQueryEvent += GetQuery_CFAIXACEP;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-V0FAIXACEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1()
        {
            /*" -1462- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -1544- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT DISTINCT B.COD_FONTE, C.NOMEFTE, C.ENDERFTE, C.BAIRRO, C.CIDADE, C.CEP, C.ESTADO FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B, SEGUROS.V1FONTE C WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE = C.FONTE ORDER BY B.COD_FONTE END-EXEC. */
            V1AGENCEF = new BI0060B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT DISTINCT B.COD_FONTE
							, 
							C.NOMEFTE
							, 
							C.ENDERFTE
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.CEP
							, 
							C.ESTADO 
							FROM SEGUROS.V1AGENCIACEF A
							, 
							SEGUROS.V1MALHACEF B
							, 
							SEGUROS.V1FONTE C 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							AND B.COD_FONTE = C.FONTE 
							ORDER BY B.COD_FONTE";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-SECTION */
        private void R0210_00_FETCH_V0FAIXACEP_SECTION()
        {
            /*" -1481- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -1486- MOVE 'R0210-00-FETCH-V0FAIXACEP' TO WNR-ROTINA. */
            _.Move("R0210-00-FETCH-V0FAIXACEP", WABEND.WNR_ROTINA);

            /*" -1493- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1();

            /*" -1496- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1497- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1498- MOVE 'S' TO WFIM-V0FAIXACEP */
                    _.Move("S", AREA_DE_WORK.WFIM_V0FAIXACEP);

                    /*" -1500- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                    _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                    /*" -1500- PERFORM R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1 */

                    R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1();

                    /*" -1502- GO TO R0210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;

                    /*" -1503- ELSE */
                }
                else
                {


                    /*" -1506- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1507- MOVE V0FAIC-FAIXA TO TAB-FX-CEP-G (V0FAIC-FAIXA). */
            _.Move(V0FAIC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FX_CEP_G);

            /*" -1508- MOVE V0FAIC-CEPINI TO TAB-FX-INI (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPINI, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1509- MOVE V0FAIC-CEPFIM TO TAB-FX-FIM (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPFIM, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1510- MOVE V0FAIC-DESC-FAIXA TO TAB-FX-NOME (V0FAIC-FAIXA). */
            _.Move(V0FAIC_DESC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1512- MOVE V0FAIC-CENTRALIZA TO TAB-FX-CENTR (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CENTRALIZA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1512- GO TO R0210-00-FETCH-V0FAIXACEP. */
            new Task(() => R0210_00_FETCH_V0FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_FETCH_1()
        {
            /*" -1493- EXEC SQL FETCH CFAIXACEP INTO :V0FAIC-FAIXA, :V0FAIC-CEPINI, :V0FAIC-CEPFIM, :V0FAIC-DESC-FAIXA, :V0FAIC-CENTRALIZA END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.V0FAIC_FAIXA, V0FAIC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CEPINI, V0FAIC_CEPINI);
                _.Move(CFAIXACEP.V0FAIC_CEPFIM, V0FAIC_CEPFIM);
                _.Move(CFAIXACEP.V0FAIC_DESC_FAIXA, V0FAIC_DESC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CENTRALIZA, V0FAIC_CENTRALIZA);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0FAIXACEP-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0FAIXACEP_DB_CLOSE_1()
        {
            /*" -1500- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-SECTION */
        private void R0500_00_DECLARE_V1AGENCEF_SECTION()
        {
            /*" -1524- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1528- MOVE 'R0500-00-DECLARE-V1AGENCEF' TO WNR-ROTINA. */
            _.Move("R0500-00-DECLARE-V1AGENCEF", WABEND.WNR_ROTINA);

            /*" -1544- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -1546- PERFORM R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -1549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1550- DISPLAY 'R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"R0500 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -1551- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1551- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -1546- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-APOLICES-DB-DECLARE-1 */
        public void R0900_00_DECLARE_APOLICES_DB_DECLARE_1()
        {
            /*" -1646- EXEC SQL DECLARE CAPOLICE CURSOR FOR SELECT A.NUM_BILHETE , A.COD_CLIENTE , B.COD_FONTE , B.OCORR_ENDERECO, B.AGE_RCAP , D.NRSORTEIO , A.COD_PRODUTO FROM SEGUROS.APOLICES A, SEGUROS.ENDOSSOS B, SEGUROS.TITULOS_FED_CAP_VA D WHERE A.COD_PRODUTO IN (1402, 1405) AND A.NUM_APOLICE = B.NUM_APOLICE AND B.NUM_ENDOSSO = 0 AND B.DATA_EMISSAO = :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_BILHETE = D.NUM_CERTIFICADO END-EXEC. */
            CAPOLICE = new BI0060B_CAPOLICE(true);
            string GetQuery_CAPOLICE()
            {
                var query = @$"SELECT A.NUM_BILHETE
							, 
							A.COD_CLIENTE
							, 
							B.COD_FONTE
							, 
							B.OCORR_ENDERECO
							, 
							B.AGE_RCAP
							, 
							D.NRSORTEIO
							, 
							A.COD_PRODUTO 
							FROM SEGUROS.APOLICES A
							, 
							SEGUROS.ENDOSSOS B
							, 
							SEGUROS.TITULOS_FED_CAP_VA D 
							WHERE A.COD_PRODUTO IN (1402
							, 1405) 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND B.NUM_ENDOSSO = 0 
							AND B.DATA_EMISSAO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_BILHETE = D.NUM_CERTIFICADO";

                return query;
            }
            CAPOLICE.GetQueryEvent += GetQuery_CAPOLICE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-SECTION */
        private void R0510_00_FETCH_V1AGENCEF_SECTION()
        {
            /*" -1563- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -1567- MOVE 'R0510-00-FETCH-V1AGENCEF' TO WNR-ROTINA. */
            _.Move("R0510-00-FETCH-V1AGENCEF", WABEND.WNR_ROTINA);

            /*" -1576- PERFORM R0510_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            R0510_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -1579- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1580- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1581- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AGENCEF);

                    /*" -1581- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -1583- ELSE */
                }
                else
                {


                    /*" -1583- PERFORM R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -1585- DISPLAY 'R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -1586- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1586- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -1576- EXEC SQL FETCH V1AGENCEF INTO :V1MCEF-COD-FONTE, :V1FONT-NOMEFTE, :V1FONT-ENDERFTE, :V1FONT-BAIRRO, :V1FONT-CIDADE, :V1FONT-CEP, :V1FONT-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
                _.Move(V1AGENCEF.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
                _.Move(V1AGENCEF.V1FONT_ENDERFTE, V1FONT_ENDERFTE);
                _.Move(V1AGENCEF.V1FONT_BAIRRO, V1FONT_BAIRRO);
                _.Move(V1AGENCEF.V1FONT_CIDADE, V1FONT_CIDADE);
                _.Move(V1AGENCEF.V1FONT_CEP, V1FONT_CEP);
                _.Move(V1AGENCEF.V1FONT_UF, V1FONT_UF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -1581- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -1583- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1598- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -1602- MOVE 'R0520-00-CARREGA-FILIAL' TO WNR-ROTINA. */
            _.Move("R0520-00-CARREGA-FILIAL", WABEND.WNR_ROTINA);

            /*" -1603- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(V1MCEF_COD_FONTE, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -1604- MOVE V1FONT-NOMEFTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(V1FONT_NOMEFTE, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -1605- MOVE V1FONT-ENDERFTE TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(V1FONT_ENDERFTE, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -1606- MOVE V1FONT-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(V1FONT_BAIRRO, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -1607- MOVE V1FONT-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(V1FONT_CIDADE, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -1608- MOVE V1FONT-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(V1FONT_CEP, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -1610- MOVE V1FONT-UF TO TAB-UF (IDX-IND1) */
            _.Move(V1FONT_UF, TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -1610- PERFORM R0510-00-FETCH-V1AGENCEF. */

            R0510_00_FETCH_V1AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-APOLICES-SECTION */
        private void R0900_00_DECLARE_APOLICES_SECTION()
        {
            /*" -1622- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -1626- MOVE 'R0900-00-DECLARE-APOLICES' TO WNR-ROTINA. */
            _.Move("R0900-00-DECLARE-APOLICES", WABEND.WNR_ROTINA);

            /*" -1646- PERFORM R0900_00_DECLARE_APOLICES_DB_DECLARE_1 */

            R0900_00_DECLARE_APOLICES_DB_DECLARE_1();

            /*" -1648- PERFORM R0900_00_DECLARE_APOLICES_DB_OPEN_1 */

            R0900_00_DECLARE_APOLICES_DB_OPEN_1();

            /*" -1651- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1652- DISPLAY 'R0900 - (PROBLEMAS NO OPEN  CAPOLICE) ..' */
                _.Display($"R0900 - (PROBLEMAS NO OPEN  CAPOLICE) ..");

                /*" -1653- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1653- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-APOLICES-DB-OPEN-1 */
        public void R0900_00_DECLARE_APOLICES_DB_OPEN_1()
        {
            /*" -1648- EXEC SQL OPEN CAPOLICE END-EXEC. */

            CAPOLICE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-APOLICES-SECTION */
        private void R0910_00_FETCH_APOLICES_SECTION()
        {
            /*" -1665- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -1669- MOVE 'R0910-00-FETCH-APOLICES' TO WNR-ROTINA. */
            _.Move("R0910-00-FETCH-APOLICES", WABEND.WNR_ROTINA);

            /*" -1678- PERFORM R0910_00_FETCH_APOLICES_DB_FETCH_1 */

            R0910_00_FETCH_APOLICES_DB_FETCH_1();

            /*" -1681- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1682- ADD 1 TO CT-LIDOS */
                AREA_DE_WORK.CT_LIDOS.Value = AREA_DE_WORK.CT_LIDOS + 1;

                /*" -1683- ELSE */
            }
            else
            {


                /*" -1684- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1685- MOVE 'S' TO WFIM-APOLICES */
                    _.Move("S", AREA_DE_WORK.WFIM_APOLICES);

                    /*" -1687- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                    _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                    /*" -1687- PERFORM R0910_00_FETCH_APOLICES_DB_CLOSE_1 */

                    R0910_00_FETCH_APOLICES_DB_CLOSE_1();

                    /*" -1689- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1690- ELSE */
                }
                else
                {


                    /*" -1692- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1696- ADD 1 TO AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1697- IF AC-CONTA > 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -1698- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1699- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1699- DISPLAY '**** LIDOS APOLICES ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS APOLICES {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-APOLICES-DB-FETCH-1 */
        public void R0910_00_FETCH_APOLICES_DB_FETCH_1()
        {
            /*" -1678- EXEC SQL FETCH CAPOLICE INTO :APOLICES-NUM-BILHETE , :APOLICES-COD-CLIENTE , :ENDOSSOS-COD-FONTE , :ENDOSSOS-OCORR-ENDERECO , :ENDOSSOS-AGE-RCAP , :TITFEDCA-NRSORTEIO , :APOLICES-COD-PRODUTO END-EXEC. */

            if (CAPOLICE.Fetch())
            {
                _.Move(CAPOLICE.APOLICES_NUM_BILHETE, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);
                _.Move(CAPOLICE.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(CAPOLICE.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(CAPOLICE.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(CAPOLICE.ENDOSSOS_AGE_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);
                _.Move(CAPOLICE.TITFEDCA_NRSORTEIO, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);
                _.Move(CAPOLICE.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-APOLICES-DB-CLOSE-1 */
        public void R0910_00_FETCH_APOLICES_DB_CLOSE_1()
        {
            /*" -1687- EXEC SQL CLOSE CAPOLICE END-EXEC */

            CAPOLICE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1711- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -1715- MOVE 'R1000-00-PROCESSA-INPUT' TO WNR-ROTINA. */
            _.Move("R1000-00-PROCESSA-INPUT", WABEND.WNR_ROTINA);

            /*" -1717- PERFORM R1200-00-SELECT-V0CLIENTE. */

            R1200_00_SELECT_V0CLIENTE_SECTION();

            /*" -1719- PERFORM R1300-00-SELECT-ENDERECO. */

            R1300_00_SELECT_ENDERECO_SECTION();

            /*" -1721- PERFORM R1500-00-SELECT-V1AGENCEF. */

            R1500_00_SELECT_V1AGENCEF_SECTION();

            /*" -1723- MOVE ENDOSSOS-COD-FONTE TO SVA-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, REG_SBI0060B.SVA_FONTE);

            /*" -1725- MOVE APOLICES-COD-PRODUTO TO SVA-PRODUTO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, REG_SBI0060B.SVA_PRODUTO);

            /*" -1726- MOVE CLIENTES-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SBI0060B.SVA_NOME_RAZAO);

            /*" -1727- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SBI0060B.SVA_ENDERECO);

            /*" -1728- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SBI0060B.SVA_BAIRRO);

            /*" -1729- MOVE ENDERECO-CIDADE TO SVA-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SBI0060B.SVA_CIDADE);

            /*" -1730- MOVE ENDERECO-SIGLA-UF TO SVA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SBI0060B.SVA_UF);

            /*" -1731- MOVE ENDERECO-CEP TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1732- MOVE APOLICES-NUM-BILHETE TO SVA-BILHETE. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE, REG_SBI0060B.SVA_BILHETE);

            /*" -1734- MOVE TITFEDCA-NRSORTEIO TO SVA-NRSORTEIO. */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO, REG_SBI0060B.SVA_NRSORTEIO);

            /*" -1735- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -1736- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SBI0060B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -1737- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SBI0060B.SVA_NUM_CEP.SVA_CEP);

                /*" -1738- ELSE */
            }
            else
            {


                /*" -1739- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SBI0060B.SVA_NUM_CEP.SVA_CEP);

                /*" -1741- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SBI0060B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -1742- IF ENDERECO-CEP EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
            {

                /*" -1743- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SBI0060B.SVA_CEP_G);

                /*" -1744- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SBI0060B.SVA_NOME_CORREIO);

                /*" -1745- ELSE */
            }
            else
            {


                /*" -1747- PERFORM R1900-00-LOCALIZA-CEP. */

                R1900_00_LOCALIZA_CEP_SECTION();
            }


            /*" -1748- RELEASE REG-SBI0060B. */
            SBI0060B.Release(REG_SBI0060B);

            /*" -1748- ADD 1 TO CT-SELEC. */
            AREA_DE_WORK.CT_SELEC.Value = AREA_DE_WORK.CT_SELEC + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1752- PERFORM R0910-00-FETCH-APOLICES. */

            R0910_00_FETCH_APOLICES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-SECTION */
        private void R1200_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -1764- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1768- MOVE 'R1200-00-SELECT-V0CLIENTE' TO WNR-ROTINA. */
            _.Move("R1200-00-SELECT-V0CLIENTE", WABEND.WNR_ROTINA);

            /*" -1773- PERFORM R1200_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1200_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1776- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1777- DISPLAY 'BI0060B - PROBLEMAS NO ACESSO A CLIENTES' */
                _.Display($"BI0060B - PROBLEMAS NO ACESSO A CLIENTES");

                /*" -1778- DISPLAY 'CLIENTE           => ' APOLICES-COD-CLIENTE */
                _.Display($"CLIENTE           => {APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE}");

                /*" -1778- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1200_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -1773- EXEC SQL SELECT NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :APOLICES-COD-CLIENTE END-EXEC. */

            var r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-SECTION */
        private void R1300_00_SELECT_ENDERECO_SECTION()
        {
            /*" -1790- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1794- MOVE 'R1300-00-SELECT-ENDERECO' TO WNR-ROTINA. */
            _.Move("R1300-00-SELECT-ENDERECO", WABEND.WNR_ROTINA);

            /*" -1808- PERFORM R1300_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -1811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1812- DISPLAY 'BI0060B - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"BI0060B - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -1813- DISPLAY 'CLIENTE           => ' APOLICES-COD-CLIENTE */
                _.Display($"CLIENTE           => {APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE}");

                /*" -1813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -1808- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :APOLICES-COD-CLIENTE AND OCORR_ENDERECO = :ENDOSSOS-OCORR-ENDERECO END-EXEC. */

            var r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-SECTION */
        private void R1500_00_SELECT_V1AGENCEF_SECTION()
        {
            /*" -1825- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1829- MOVE 'R1500-00-SELECT-V1AGENCEF' TO WNR-ROTINA. */
            _.Move("R1500-00-SELECT-V1AGENCEF", WABEND.WNR_ROTINA);

            /*" -1837- PERFORM R1500_00_SELECT_V1AGENCEF_DB_SELECT_1 */

            R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();

            /*" -1840- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1841- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1842- MOVE 005 TO V1MCEF-COD-FONTE */
                    _.Move(005, V1MCEF_COD_FONTE);

                    /*" -1843- ELSE */
                }
                else
                {


                    /*" -1844- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                    /*" -1845- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1845- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_V1AGENCEF_DB_SELECT_1()
        {
            /*" -1837- EXEC SQL SELECT B.COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :ENDOSSOS-AGE-RCAP END-EXEC. */

            var r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1()
            {
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -1857- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -1861- MOVE 'R1900-00-LOCALIZA-CEP' TO WNR-ROTINA. */
            _.Move("R1900-00-LOCALIZA-CEP", WABEND.WNR_ROTINA);

            /*" -1861- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -1866- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1869- DISPLAY '*** BI0060B CEP NAO ENCONTRADO ' ENDERECO-CEP ' ' APOLICES-NUM-BILHETE */

                $"*** BI0060B CEP NAO ENCONTRADO {ENDERECO.DCLENDERECOS.ENDERECO_CEP} {APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE}"
                .Display();

                /*" -1870- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SBI0060B.SVA_CEP_G);

                /*" -1871- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SBI0060B.SVA_NOME_CORREIO);

                /*" -1873- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1874- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -1876- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -1877- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -1879- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -1881- IF ENDERECO-CEP GREATER WS-INF AND ENDERECO-CEP LESS WS-SUP */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP > AREA_DE_WORK.WS_INF && ENDERECO.DCLENDERECOS.ENDERECO_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -1882- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SBI0060B.SVA_CEP_G);

                /*" -1883- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SBI0060B.SVA_NOME_CORREIO);

                /*" -1884- ELSE */
            }
            else
            {


                /*" -1885- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -1885- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1898- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1903- MOVE 'R2000-00-PROCESSA-OUTPUT' TO WNR-ROTINA. */
            _.Move("R2000-00-PROCESSA-OUTPUT", WABEND.WNR_ROTINA);

            /*" -1907- MOVE SVA-BILHETE TO WHOST-BILHETE LDET-BILHETE WS-BILHETE-ANT. */
            _.Move(REG_SBI0060B.SVA_BILHETE, WHOST_BILHETE, DBM_DET.LDET_FRENTE.LDET_BILHETE, AREA_DE_WORK.WS_BILHETE_ANT);

            /*" -1909- MOVE SVA-NRSORTEIO TO LDET-BILHETE */
            _.Move(REG_SBI0060B.SVA_NRSORTEIO, DBM_DET.LDET_FRENTE.LDET_BILHETE);

            /*" -1911- PERFORM R2900-00-TRATA-V0RELATORIOS. */

            R2900_00_TRATA_V0RELATORIOS_SECTION();

            /*" -1913- PERFORM R2010-00-PROCESSA-PRODUTO. */

            R2010_00_PROCESSA_PRODUTO_SECTION();

            /*" -1915- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -1917- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -1919- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -1930- MOVE ZEROS TO TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR WIND. */
            _.Move(0, TABELA_TOTAIS, AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ, AREA_DE_WORK.WS_CONTR_200, AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.WS_OCORR, AREA_DE_WORK.WIND);

            /*" -1931- IF WFIM-SORT NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SORT != "S")
            {

                /*" -1932- WRITE FBI0060B-RECORD FROM SEPARA-JDT */
                _.Move(MAIS_LINHAS.SEPARA_JDT.GetMoveValues(), FBI0060B_RECORD);

                FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

                /*" -1933- ELSE */
            }
            else
            {


                /*" -1933- WRITE FBI0060B-RECORD FROM LAISERFAC-FINAL. */
                _.Move(MAIS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), FBI0060B_RECORD);

                FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -1945- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", WABEND.WNR_EXEC_SQL);

            /*" -1952- MOVE 'R2010-00-PROCESSA-PRODUTO' TO WNR-ROTINA. */
            _.Move("R2010-00-PROCESSA-PRODUTO", WABEND.WNR_ROTINA);

            /*" -1953- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SBI0060B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -1954- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SBI0060B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -1957- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -1958- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SBI0060B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1959- MOVE WS-CEP-AUX TO LF03-FAIXA1. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA1);

            /*" -1960- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA1C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA1C);

            /*" -1961- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SBI0060B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1962- MOVE WS-CEP-AUX TO LF03-FAIXA2. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA2);

            /*" -1965- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA2C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF03_LINHA03.FAIXA_INT.LF03_FAIXA2C);

            /*" -1970- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-BILHETE NOT EQUAL WS-BILHETE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SBI0060B.SVA_BILHETE != AREA_DE_WORK.WS_BILHETE_ANT || REG_SBI0060B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -1971- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARF);

            /*" -1971- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -1983- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1988- MOVE 'R2100-00-PROCESSA-CEP' TO WNR-ROTINA. */
            _.Move("R2100-00-PROCESSA-CEP", WABEND.WNR_ROTINA);

            /*" -1992- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -1994- MOVE SVA-BILHETE TO WHOST-BILHETE LDET-BILHETE. */
            _.Move(REG_SBI0060B.SVA_BILHETE, WHOST_BILHETE, DBM_DET.LDET_FRENTE.LDET_BILHETE);

            /*" -1995- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -1996- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -1997- PERFORM R2600-00-IDENTIFICA-MSG. */

            R2600_00_IDENTIFICA_MSG_SECTION();

            /*" -1998- WRITE RBI0060B-RECORD FROM LC08-LINHA08-ER */
            _.Move(TODAS_AS_LINHAS.LC08_LINHA08_ER.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -1999- WRITE RBI0060B-RECORD FROM LC09-LINHA09-ER */
            _.Move(TODAS_AS_LINHAS.LC09_LINHA09_ER.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2000- WRITE RBI0060B-RECORD FROM DBM-HEADER */
            _.Move(DBM_HEADER.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2006- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-BILHETE NOT EQUAL WS-BILHETE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199. */

            while (!(REG_SBI0060B.SVA_BILHETE != AREA_DE_WORK.WS_BILHETE_ANT || REG_SBI0060B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -2009- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR (WS-CEP-G-ANT). */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -2010- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -2011- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -2014- MOVE WS-AMARRADO TO TAB1-AMARI (WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -2015- MOVE WS-AMARRADO TO LF05-AMARRADO. */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF05_LINHA05.LF05_AMARRADO);

            /*" -2016- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -2017- MOVE WS-SEQ-INICIAL TO LF05-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF05_LINHA05.SEQ_INT.LF05_SEQ_INICIAL);

            /*" -2019- MOVE WS-SEQ TO LF05-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF05_LINHA05.SEQ_INT.LF05_SEQ_FINAL);

            /*" -2020- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -2022- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF02-NOME-FAIXA */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA);

                /*" -2023- ELSE */
            }
            else
            {


                /*" -2026- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF02-NOME-FAIXA. */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA);
            }


            /*" -2027- MOVE LF02-NOME-FAIXA TO CO04-DET-LOCALIDADE */
            _.Move(AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA, MAIS_LINHAS.FAC_DETALHE.CO04_DET_LOCALIDADE);

            /*" -2028- MOVE LF04-QTD-OBJ TO CO04-DET-OBJETOS */
            _.Move(AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ, MAIS_LINHAS.FAC_DETALHE.CO04_DET_OBJETOS);

            /*" -2029- MOVE FAIXA-INT TO CO04-DET-FAIXA */
            _.Move(AREA_DE_WORK.LF03_LINHA03.FAIXA_INT, MAIS_LINHAS.FAC_DETALHE.CO04_DET_FAIXA);

            /*" -2030- MOVE LF05-AMARRADO TO CO04-DET-AMARRADO */
            _.Move(AREA_DE_WORK.LF05_LINHA05.LF05_AMARRADO, MAIS_LINHAS.FAC_DETALHE.CO04_DET_AMARRADO);

            /*" -2032- MOVE SEQ-INT TO CO04-DET-SEQUENCIA */
            _.Move(AREA_DE_WORK.LF05_LINHA05.SEQ_INT, MAIS_LINHAS.FAC_DETALHE.CO04_DET_SEQUENCIA);

            /*" -2033- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

            /*" -2034- MOVE 1 TO WS-CONTROLE. */
            _.Move(1, AREA_DE_WORK.WS_CONTROLE);

            /*" -2035- WRITE RBI0060B-RECORD FROM LAISERFAC-FINAL. */
            _.Move(MAIS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2036- WRITE RBI0060B-RECORD FROM FAC-01. */
            _.Move(MAIS_LINHAS.FAC_01.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2037- WRITE RBI0060B-RECORD FROM FAC-02. */
            _.Move(MAIS_LINHAS.FAC_02.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2038- WRITE RBI0060B-RECORD FROM FAC-04. */
            _.Move(MAIS_LINHAS.FAC_04.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2039- WRITE RBI0060B-RECORD FROM FAC-05 */
            _.Move(MAIS_LINHAS.FAC_05.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2040- WRITE RBI0060B-RECORD FROM FAC-HEADER. */
            _.Move(MAIS_LINHAS.FAC_HEADER.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2041- WRITE RBI0060B-RECORD FROM FAC-DETALHE. */
            _.Move(MAIS_LINHAS.FAC_DETALHE.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2042- IF WFIM-SORT NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SORT != "S")
            {

                /*" -2043- WRITE RBI0060B-RECORD FROM LAISERFAC-FINAL */
                _.Move(MAIS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RBI0060B_RECORD);

                RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

                /*" -2044- WRITE RBI0060B-RECORD FROM LAISER-01 */
                _.Move(CONTINUA_LINHA.LAISER_01.GetMoveValues(), RBI0060B_RECORD);

                RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

                /*" -2045- ELSE */
            }
            else
            {


                /*" -2045- WRITE RBI0060B-RECORD FROM LAISERFAC-FINAL. */
                _.Move(MAIS_LINHAS.LAISERFAC_FINAL.GetMoveValues(), RBI0060B_RECORD);

                RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -2057- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -2062- MOVE 'R2200-00-PROCESSA-FAC' TO WNR-ROTINA. */
            _.Move("R2200-00-PROCESSA-FAC", WABEND.WNR_ROTINA);

            /*" -2064- MOVE ZEROS TO TABELA-REGISTROS. */
            _.Move(0, TABELA_REGISTROS);

            /*" -2071- PERFORM R2300-00-MONTA-LINHAS UNTIL SVA-BILHETE NOT EQUAL WS-BILHETE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 GREATER 199 OR WINDR EQUAL 1. */

            while (!(REG_SBI0060B.SVA_BILHETE != AREA_DE_WORK.WS_BILHETE_ANT || REG_SBI0060B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199 || AREA_DE_WORK.WINDR == 1))
            {

                R2300_00_MONTA_LINHAS_SECTION();
            }

            /*" -2073- PERFORM R2500-00-IMPRIME. */

            R2500_00_IMPRIME_SECTION();

            /*" -2073- MOVE ZEROS TO WINDR. */
            _.Move(0, AREA_DE_WORK.WINDR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-SECTION */
        private void R2300_00_MONTA_LINHAS_SECTION()
        {
            /*" -2085- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -2090- MOVE 'R2300-00-MONTA-LINHAS' TO WNR-ROTINA. */
            _.Move("R2300-00-MONTA-LINHAS", WABEND.WNR_ROTINA);

            /*" -2091- ADD 1 TO WINDR. */
            AREA_DE_WORK.WINDR.Value = AREA_DE_WORK.WINDR + 1;

            /*" -2092- MOVE SVA-BILHETE TO TVA-BILHETE (WINDR). */
            _.Move(REG_SBI0060B.SVA_BILHETE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_BILHETE);

            /*" -2093- MOVE SVA-CEP TO TVA-CEP (WINDR). */
            _.Move(REG_SBI0060B.SVA_NUM_CEP.SVA_CEP, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_NUM_CEP.TVA_CEP);

            /*" -2094- MOVE SVA-CEP-COMPL TO TVA-CEP-COMPL (WINDR). */
            _.Move(REG_SBI0060B.SVA_NUM_CEP.SVA_CEP_COMPL, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_NUM_CEP.TVA_CEP_COMPL);

            /*" -2095- MOVE SVA-NOME-RAZAO TO TVA-NOME-RAZAO (WINDR). */
            _.Move(REG_SBI0060B.SVA_NOME_RAZAO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_NOME_RAZAO);

            /*" -2096- MOVE SVA-ENDERECO TO TVA-ENDERECO (WINDR). */
            _.Move(REG_SBI0060B.SVA_ENDERECO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_ENDERECO);

            /*" -2097- MOVE SVA-BAIRRO TO TVA-BAIRRO (WINDR). */
            _.Move(REG_SBI0060B.SVA_BAIRRO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_BAIRRO);

            /*" -2098- MOVE SVA-CIDADE TO TVA-CIDADE (WINDR). */
            _.Move(REG_SBI0060B.SVA_CIDADE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_CIDADE);

            /*" -2099- MOVE SVA-UF TO TVA-UF (WINDR). */
            _.Move(REG_SBI0060B.SVA_UF, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_UF);

            /*" -2100- MOVE SVA-FONTE TO TVA-FONTE (WINDR). */
            _.Move(REG_SBI0060B.SVA_FONTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_FONTE);

            /*" -2101- MOVE SVA-PRODUTO TO TVA-PRODUTO (WINDR). */
            _.Move(REG_SBI0060B.SVA_PRODUTO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_PRODUTO);

            /*" -2103- MOVE SVA-NRSORTEIO TO TVA-SORTEIO (WINDR). */
            _.Move(REG_SBI0060B.SVA_NRSORTEIO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WINDR].TVA_SORTEIO);

            /*" -2103- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -2115- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -2120- MOVE 'R2400-00-LE-SORT' TO WNR-ROTINA. */
            _.Move("R2400-00-LE-SORT", WABEND.WNR_ROTINA);

            /*" -2122- RETURN SBI0060B AT END */
            try
            {
                SBI0060B.Return(REG_SBI0060B, () =>
                {

                    /*" -2123- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -2125- GO TO R2400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2128- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -2129- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -2130- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -2131- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -2131- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-IMPRIME-SECTION */
        private void R2500_00_IMPRIME_SECTION()
        {
            /*" -2143- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -2147- MOVE 'R2500-00-IMPRIME' TO WNR-ROTINA. */
            _.Move("R2500-00-IMPRIME", WABEND.WNR_ROTINA);

            /*" -2148- IF TAB-REG (1) NOT EQUAL ZEROS */

            if (TABELA_REGISTROS.TAB_REG[1] != 00)
            {

                /*" -2151- MOVE TVA-BILHETE (1) TO WHOST-BILHETE LDET-BILHETE WS-APOLICE */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_BILHETE, WHOST_BILHETE, DBM_DET.LDET_FRENTE.LDET_BILHETE, AREA_DE_WORK.WS_CHAVE_R.WS_APOLICE);

                /*" -2152- MOVE TVA-SORTEIO (1) TO LDET-NRSORTEIO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_SORTEIO, DBM_DET.LDET_FRENTE.LDET_NRSORTEIO);

                /*" -2153- MOVE TVA-PRODUTO (1) TO LDET-PRODUTO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_PRODUTO, DBM_DET.LDET_FRENTE.LDET_PRODUTO);

                /*" -2155- MOVE 15340 TO LDET-CCUSTO */
                _.Move(15340, DBM_DET.LDET_FRENTE.LDET_CCUSTO);

                /*" -2156- MOVE 1 TO INF */
                _.Move(1, AREA_DE_WORK.INF);

                /*" -2157- MOVE WINDM TO SUP */
                _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

                /*" -2158- MOVE TVA-NOME-RAZAO(1) TO WS-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_NOME_RAZAO, AREA_DE_WORK.WS_NOME_RAZAO);

                /*" -2164- PERFORM R2700-00-FORMATA-NOME-RAZAO */

                R2700_00_FORMATA_NOME_RAZAO_SECTION();

                /*" -2165- MOVE TVA-NUM-CEP (1) TO LE05-CEP */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_NUM_CEP, DBM_DET.LDET_FRENTE.LE05_CEP);

                /*" -2166- MOVE TVA-CEP-COMPL (1) TO LE05-CEP-COMPL */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_NUM_CEP.TVA_CEP_COMPL, DBM_DET.LDET_FRENTE.LE05_CEP_COMPL);

                /*" -2167- MOVE TVA-CIDADE (1) TO LE04-CIDADE */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_CIDADE, DBM_DET.LDET_FRENTE.LE04_CIDADE);

                /*" -2168- MOVE TVA-BAIRRO (1) TO LE04-BAIRRO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_BAIRRO, DBM_DET.LDET_FRENTE.LE04_BAIRRO);

                /*" -2169- MOVE TVA-UF (1) TO LE04-UF */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_UF, DBM_DET.LDET_FRENTE.LE04_UF);

                /*" -2170- MOVE TVA-ENDERECO (1) TO LE03-ENDERECO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_ENDERECO, DBM_DET.LDET_FRENTE.LE03_ENDERECO);

                /*" -2174- ADD 1 TO WS-SEQ TAB1-QTD-OBJ (WS-CEP-G-ANT) AC-QTD-OBJ AC-CONTA1 */
                AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
                TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_OBJ + 1;
                AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
                AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

                /*" -2175- MOVE 'XXX.XXX' TO LE01-SEQUENCIA */
                _.Move("XXX.XXX", DBM_DET.LDET_FRENTE.LE01_SEQUENCIA);

                /*" -2176- IF WS-CONTR-OBJ EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
                {

                    /*" -2177- MOVE 1 TO WS-CONTR-OBJ */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                    /*" -2179- MOVE WS-SEQ TO TAB1-OBJI (WS-CEP-G-ANT) */
                    _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJI);

                    /*" -2180- END-IF */
                }


                /*" -2181- IF WS-CONTR-200 EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_200 == 00)
                {

                    /*" -2182- MOVE 1 TO WS-CONTR-200 */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                    /*" -2183- MOVE WS-SEQ TO WS-SEQ-INICIAL */
                    _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);

                    /*" -2191- END-IF */
                }


                /*" -2192- MOVE 1 TO IDX-IND2 */
                _.Move(1, AREA_DE_WORK.IDX_IND2);

                /*" -2204- PERFORM R2650-00-BUSCA-FONTE */

                R2650_00_BUSCA_FONTE_SECTION();

                /*" -2206- ADD 1 TO AC-IMPRESSOS. */
                AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;
            }


            /*" -2207- MOVE ALL '@' TO LP10-CODIGO-CIF */
            _.MoveAll("@", DBM_DET.LDET_FRENTE.LP10_CODIGO_CIF);

            /*" -2214- MOVE ALL '#' TO LP10-POSTNET */
            _.MoveAll("#", DBM_DET.LDET_FRENTE.LP10_POSTNET);

            /*" -2215- MOVE LDET-FRENTE TO DBM-DETALHE */
            _.Move(DBM_DET.LDET_FRENTE, DBM_DETALHE);

            /*" -2217- PERFORM R9900-00-GRAVA-OBJETO THRU R9900-99-SAIDA. */

            R9900_00_GRAVA_OBJETO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/


            /*" -2217- WRITE RBI0060B-RECORD FROM DBM-DETALHE. */
            _.Move(DBM_DETALHE.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-IDENTIFICA-MSG-SECTION */
        private void R2600_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -2229- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -2258- MOVE 'R2600-00-IDENTIFICA-MSG' TO WNR-ROTINA. */
            _.Move("R2600-00-IDENTIFICA-MSG", WABEND.WNR_ROTINA);

            /*" -2259- MOVE 'SF14' TO WS-JDE */
            _.Move("SF14", AREA_DE_WORK.WS_JDE_GER.WS_JDE);

            /*" -2260- MOVE 'DBM' TO WS-DBM */
            _.Move("DBM", AREA_DE_WORK.WS_JDE_GER.WS_DBM);

            /*" -2260- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LC09-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), TODAS_AS_LINHAS.LC09_LINHA09_ER.LC09_FORM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-SELECT-V0MULTIMENS-SECTION */
        private void R2610_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -2285- MOVE '2610' TO WNR-EXEC-SQL. */
            _.Move("2610", WABEND.WNR_EXEC_SQL);

            /*" -2289- MOVE 'R2610-00-SELECT-V0MULTIMENS' TO WNR-ROTINA. */
            _.Move("R2610-00-SELECT-V0MULTIMENS", WABEND.WNR_ROTINA);

            /*" -2291- MOVE '261' TO WNR-EXEC-SQL */
            _.Move("261", WABEND.WNR_EXEC_SQL);

            /*" -2301- PERFORM R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -2304- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2305- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2306- MOVE 'S' TO WDESPREZA */
                    _.Move("S", AREA_DE_WORK.WDESPREZA);

                    /*" -2307- ELSE */
                }
                else
                {


                    /*" -2308- DISPLAY 'BI0060B ERRO ACESSO  NA V0MSGCOBR   ' */
                    _.Display($"BI0060B ERRO ACESSO  NA V0MSGCOBR   ");

                    /*" -2309- DISPLAY '        APOLICE....... ' WHOST-BILHETE */
                    _.Display($"        APOLICE....... {WHOST_BILHETE}");

                    /*" -2310- DISPLAY '        SUBGRUPO...... ' WHOST-CODSUBES */
                    _.Display($"        SUBGRUPO...... {WHOST_CODSUBES}");

                    /*" -2311- DISPLAY '        OPERACAO...... ' WHOST-CODOPER */
                    _.Display($"        OPERACAO...... {WHOST_CODOPER}");

                    /*" -2311- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2610-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -2301- EXEC SQL SELECT JDE, JDL INTO :V0MENS-JDE, :V0MENS-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A5' AND NUM_APOLICE = :WHOST-BILHETE AND CODSUBES = :WHOST-CODSUBES AND COD_OPERACAO = :WHOST-CODOPER END-EXEC. */

            var r2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
                WHOST_BILHETE = WHOST_BILHETE.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            var executed_1 = R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1.Execute(r2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MENS_JDE, V0MENS_JDE);
                _.Move(executed_1.V0MENS_JDL, V0MENS_JDL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-BUSCA-FONTE-SECTION */
        private void R2650_00_BUSCA_FONTE_SECTION()
        {
            /*" -2323- MOVE '2650' TO WNR-EXEC-SQL. */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -2327- MOVE 'R2650-00-BUSCA-FONTE' TO WNR-ROTINA. */
            _.Move("R2650-00-BUSCA-FONTE", WABEND.WNR_ROTINA);

            /*" -2327- MOVE ZEROS TO IDX-IND1. */
            _.Move(0, AREA_DE_WORK.IDX_IND1);

            /*" -0- FLUXCONTROL_PERFORM R2650_LOOP */

            R2650_LOOP();

        }

        [StopWatch]
        /*" R2650-LOOP */
        private void R2650_LOOP(bool isPerform = false)
        {
            /*" -2333- ADD 1 TO IDX-IND1. */
            AREA_DE_WORK.IDX_IND1.Value = AREA_DE_WORK.IDX_IND1 + 1;

            /*" -2334- IF IDX-IND1 > 19 */

            if (AREA_DE_WORK.IDX_IND1 > 19)
            {

                /*" -2336- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2337- IF TVA-FONTE(IDX-IND2) = TAB-FONTE (IDX-IND1) */

            if (TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.IDX_IND2].TVA_FONTE == TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_FONTE)
            {

                /*" -2339- MOVE TAB-NOMEFTE (IDX-IND1) TO LE06-REMETENTE */
                _.Move(TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE, DBM_DET.LDET_FRENTE.LE06_REMETENTE);

                /*" -2341- MOVE TAB-ENDERFTE(IDX-IND1) TO LE07-ENDERECO */
                _.Move(TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE, DBM_DET.LDET_FRENTE.LE07_ENDERECO);

                /*" -2343- MOVE TAB-BAIRRO (IDX-IND1) TO LE08-BAIRRO */
                _.Move(TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO, DBM_DET.LDET_FRENTE.LE08_BAIRRO);

                /*" -2345- MOVE TAB-CIDADE (IDX-IND1) TO LE08-CIDADE */
                _.Move(TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_CIDADE, DBM_DET.LDET_FRENTE.LE08_CIDADE);

                /*" -2347- MOVE TAB-UF (IDX-IND1) TO LE08-UF */
                _.Move(TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_UF, DBM_DET.LDET_FRENTE.LE08_UF);

                /*" -2349- MOVE TAB-CEP (IDX-IND1) TO DEST-NUM-CEP */
                _.Move(TAB_FILIAL.FILLER_181[AREA_DE_WORK.IDX_IND1].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

                /*" -2350- MOVE DEST-CEP TO LE09-CEP */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, DBM_DET.LDET_FRENTE.LE09_CEP);

                /*" -2351- MOVE DEST-CEP-COMPL TO LE09-CEP-COMPL */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, DBM_DET.LDET_FRENTE.LE09_CEP_COMPL);

                /*" -2353- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2353- GO TO R2650-LOOP. */
            new Task(() => R2650_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-FORMATA-NOME-RAZAO-SECTION */
        private void R2700_00_FORMATA_NOME_RAZAO_SECTION()
        {
            /*" -2365- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -2370- MOVE 'R2700-00-FORMATA-NOME-RAZAO' TO WNR-ROTINA. */
            _.Move("R2700-00-FORMATA-NOME-RAZAO", WABEND.WNR_ROTINA);

            /*" -2371- IF WS-LETRA-NOME(40) NOT EQUAL SPACES */

            if (AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[40] != string.Empty)
            {

                /*" -2372- MOVE ',' TO WS-LETRA-NOME(41) */
                _.Move(",", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[41]);

                /*" -2373- MOVE WS-NOME-RAZAO TO LDET-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, DBM_DET.LDET_FRENTE.LDET_NOME_RAZAO);

                /*" -2374- MOVE ' ' TO WS-LETRA-NOME(41) */
                _.Move(" ", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[41]);

                /*" -2375- MOVE WS-NOME-RAZAO TO LE02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, DBM_DET.LDET_FRENTE.LE02_NOME_RAZAO);

                /*" -2377- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2377- MOVE 40 TO WIND1. */
            _.Move(40, AREA_DE_WORK.WIND1);

            /*" -0- FLUXCONTROL_PERFORM R2700_10_LOOP */

            R2700_10_LOOP();

        }

        [StopWatch]
        /*" R2700-10-LOOP */
        private void R2700_10_LOOP(bool isPerform = false)
        {
            /*" -2383- SUBTRACT 1 FROM WIND1. */
            AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 - 1;

            /*" -2384- IF WIND1 LESS 1 */

            if (AREA_DE_WORK.WIND1 < 1)
            {

                /*" -2386- MOVE SPACES TO LDET-NOME-RAZAO LE02-NOME-RAZAO */
                _.Move("", DBM_DET.LDET_FRENTE.LDET_NOME_RAZAO, DBM_DET.LDET_FRENTE.LE02_NOME_RAZAO);

                /*" -2388- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2389- IF WS-LETRA-NOME(WIND1) NOT EQUAL SPACES */

            if (AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1] != string.Empty)
            {

                /*" -2390- ADD 1 TO WIND1 */
                AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                /*" -2391- MOVE ',' TO WS-LETRA-NOME(WIND1) */
                _.Move(",", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1]);

                /*" -2392- MOVE WS-NOME-RAZAO TO LDET-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, DBM_DET.LDET_FRENTE.LDET_NOME_RAZAO);

                /*" -2393- MOVE ' ' TO WS-LETRA-NOME(WIND1) */
                _.Move(" ", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1]);

                /*" -2394- MOVE WS-NOME-RAZAO TO LE02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, DBM_DET.LDET_FRENTE.LE02_NOME_RAZAO);

                /*" -2396- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2396- GO TO R2700-10-LOOP. */
            new Task(() => R2700_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TRATA-V0RELATORIOS-SECTION */
        private void R2900_00_TRATA_V0RELATORIOS_SECTION()
        {
            /*" -2408- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -2412- MOVE 'R2900-00-TRATA-V0RELATORIOS' TO WNR-ROTINA. */
            _.Move("R2900-00-TRATA-V0RELATORIOS", WABEND.WNR_ROTINA);

            /*" -2414- PERFORM R2910-00-OBTEM-NUMERACAO. */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -2416- MOVE V0RELA-NRCOPIAS TO LR02-SEQ. */
            _.Move(V0RELA_NRCOPIAS, AREA_DE_WORK.LR02_LINHA02.LISTAGEM_INT.LR02_SEQ);

            /*" -2417- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2418- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -2419- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -2421- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -2423- MOVE TAB-MES(WS-MES-SQL) TO LR02-MES. */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR02_LINHA02.LISTAGEM_INT.LR02_MES);

            /*" -2428- MOVE LISTAGEM-INT TO LISTAGEM-NUMERO. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.LISTAGEM_INT, MAIS_LINHAS.L7_JDT.LISTAGEM_NUMERO);

            /*" -2429- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, AREA_DE_WORK.WS_COUNT);

            /*" -2431- MOVE WHOST-DTMOVABE TO WHOST-PROXIMA-DATA. */
            _.Move(WHOST_DTMOVABE, AREA_DE_WORK.WHOST_PROXIMA_DATA);

            /*" -2434- PERFORM R2920-00-CALC-DIAS-UTEIS UNTIL WS-COUNT EQUAL 2. */

            while (!(AREA_DE_WORK.WS_COUNT == 2))
            {

                R2920_00_CALC_DIAS_UTEIS_SECTION();
            }

            /*" -2435- MOVE CALENDAR-DATA-CALENDARIO TO WS-DATA-SQL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -2436- MOVE WS-ANO-SQL TO WS-ANO-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_ANO_I);

            /*" -2437- MOVE WS-MES-SQL TO WS-MES-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -2438- MOVE WS-DIA-SQL TO WS-DIA-I. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -2441- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -2442- MOVE WS-DATA-I TO LR04-DATA */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LR04_LINHA04.LR04_DATA);

            /*" -2443- MOVE LR04-DATA TO LE01-DTPOSTAGEM. */
            _.Move(AREA_DE_WORK.LR04_LINHA04.LR04_DATA, DBM_DET.LDET_FRENTE.LE01_DTPOSTAGEM);

            /*" -2444- MOVE 'XX/XX/XXXX' TO LE01-DTPOSTAGEM. */
            _.Move("XX/XX/XXXX", DBM_DET.LDET_FRENTE.LE01_DTPOSTAGEM);

            /*" -2444- MOVE LR04-DATA TO DATA9-JDT. */
            _.Move(AREA_DE_WORK.LR04_LINHA04.LR04_DATA, MAIS_LINHAS.L9_JDT.DATA9_JDT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -2456- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WABEND.WNR_EXEC_SQL);

            /*" -2460- MOVE 'R2910-00-OBTEM-NUMERACAO' TO WNR-ROTINA. */
            _.Move("R2910-00-OBTEM-NUMERACAO", WABEND.WNR_ROTINA);

            /*" -2467- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -2470- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2471- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2472- MOVE ZEROS TO V0RELA-NRCOPIAS */
                    _.Move(0, V0RELA_NRCOPIAS);

                    /*" -2473- ELSE */
                }
                else
                {


                    /*" -2474- DISPLAY 'BI0060B - PROBLEMAS SELECT V0RELATORIOS' */
                    _.Display($"BI0060B - PROBLEMAS SELECT V0RELATORIOS");

                    /*" -2476- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2477- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -2477- MOVE ZEROS TO V0RELA-NRCOPIAS. */
                _.Move(0, V0RELA_NRCOPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -2467- EXEC SQL SELECT MAX(NRCOPIAS) INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

            var r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRCOPIAS, V0RELA_NRCOPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO */
        private void R2910_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -2483- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -2538- ADD 1 TO V0RELA-NRCOPIAS. */
            V0RELA_NRCOPIAS.Value = V0RELA_NRCOPIAS + 1;

            /*" -2538- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-00-CALC-DIAS-UTEIS-SECTION */
        private void R2920_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -2550- MOVE '2920' TO WNR-EXEC-SQL. */
            _.Move("2920", WABEND.WNR_EXEC_SQL);

            /*" -2554- MOVE 'R2920-00-CALC-DIAS-UTEIS' TO WNR-ROTINA. */
            _.Move("R2920-00-CALC-DIAS-UTEIS", WABEND.WNR_ROTINA);

            /*" -2556- PERFORM R2930-00-CALCULA-DIA-UTIL. */

            R2930_00_CALCULA_DIA_UTIL_SECTION();

            /*" -2560- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -2561- ELSE */
            }
            else
            {


                /*" -2561- ADD 1 TO WS-COUNT. */
                AREA_DE_WORK.WS_COUNT.Value = AREA_DE_WORK.WS_COUNT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R2930-00-CALCULA-DIA-UTIL-SECTION */
        private void R2930_00_CALCULA_DIA_UTIL_SECTION()
        {
            /*" -2572- MOVE '2930' TO WNR-EXEC-SQL. */
            _.Move("2930", WABEND.WNR_EXEC_SQL);

            /*" -2576- MOVE 'R2930-00-CALCULA-DIA-UTIL' TO WNR-ROTINA. */
            _.Move("R2930-00-CALCULA-DIA-UTIL", WABEND.WNR_ROTINA);

            /*" -2590- PERFORM R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -2593- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2594- DISPLAY 'BI0060B - PROBLEMAS NO ACESSO A TABELA CALENDARIO' */
                _.Display($"BI0060B - PROBLEMAS NO ACESSO A TABELA CALENDARIO");

                /*" -2594- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2930-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -2590- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-PROXIMA-DATA END-EXEC. */

            var r2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = AREA_DE_WORK.WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(r2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, AREA_DE_WORK.WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2930_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -2604- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -2609- MOVE 'R3000-00-IMPRIME-LST' TO WNR-ROTINA. */
            _.Move("R3000-00-IMPRIME-LST", WABEND.WNR_ROTINA);

            /*" -2610- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -2610- MOVE 0 TO CONTA-LINHAS. */
            _.Move(0, CONTA_LINHAS);

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -2615- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2617- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -2619- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -2620- IF TAB1-QTD-OBJ (WIND) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ != 00)
            {

                /*" -2622- ADD 1 TO WS-OCORR. */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;
            }


            /*" -2623- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -2623- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -2628- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -2629- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -2631- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -2631- MOVE WWORK-QTDE11 TO LR02-PAG-FINAL. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR02_LINHA02.LR02_PAG_INT.LR02_PAG_FINAL);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -2656- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2657- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -2659- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2660- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -2661- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2663- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2664- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -2665- MOVE AC-PAGINA TO LR02-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR02_LINHA02.LR02_PAG_INT.LR02_PAGINA);

            /*" -2668- MOVE LR02-PAG-INT TO PAGINA11-JDT */
            _.Move(AREA_DE_WORK.LR02_LINHA02.LR02_PAG_INT, MAIS_LINHAS.L11_JDT.PAGINA11_JDT);

            /*" -2670- MOVE LR03-TP-PGTO TO TIPO8-JDT. */
            _.Move(AREA_DE_WORK.LR03_LINHA03.LR03_TP_PGTO, MAIS_LINHAS.L8_JDT.TIPO8_JDT);

            /*" -2672- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -2673- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2674- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_CEPI);

            /*" -2675- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_COMPL_CEPI);

            /*" -2676- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2677- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_CEPF);

            /*" -2678- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_COMPL_CEPF);

            /*" -2679- MOVE TAB1-OBJI (WIND) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR05_LINHA05.LR05_OBJI);

            /*" -2680- MOVE TAB1-OBJF (WIND) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR05_LINHA05.LR05_OBJF);

            /*" -2681- MOVE TAB1-AMARI (WIND) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR05_LINHA05.LR05_AMARI);

            /*" -2682- MOVE TAB1-AMARF (WIND) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR05_LINHA05.LR05_AMARF);

            /*" -2683- MOVE TAB1-QTD-OBJ (WIND) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR05_LINHA05.LR05_QTD_OBJ);

            /*" -2684- MOVE TAB1-QTD-AMAR(WIND) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR05_LINHA05.LR05_QTD_AMAR);

            /*" -2685- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR05_LINHA05.LR05_OBS);

            /*" -2686- WRITE FBI0060B-RECORD FROM L3-JDT. */
            _.Move(MAIS_LINHAS.L3_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2687- WRITE FBI0060B-RECORD FROM L4-JDT. */
            _.Move(MAIS_LINHAS.L4_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2688- WRITE FBI0060B-RECORD FROM L5-JDT. */
            _.Move(MAIS_LINHAS.L5_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2689- WRITE FBI0060B-RECORD FROM L6-JDT. */
            _.Move(MAIS_LINHAS.L6_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2690- WRITE FBI0060B-RECORD FROM L7-JDT. */
            _.Move(MAIS_LINHAS.L7_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2691- WRITE FBI0060B-RECORD FROM L8-JDT. */
            _.Move(MAIS_LINHAS.L8_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2692- WRITE FBI0060B-RECORD FROM L9-JDT. */
            _.Move(MAIS_LINHAS.L9_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2693- WRITE FBI0060B-RECORD FROM L10-JDT. */
            _.Move(MAIS_LINHAS.L10_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2694- WRITE FBI0060B-RECORD FROM L11-JDT. */
            _.Move(MAIS_LINHAS.L11_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2695- ADD 1 TO CONTA-LINHAS. */
            CONTA_LINHAS.Value = CONTA_LINHAS + 1;

            /*" -2695- WRITE FBI0060B-RECORD FROM LR05-LINHA05. */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -2701- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -2702- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2703- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -2705- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2706- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -2708- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2709- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2710- MOVE WS-CEP-AUX TO LR06-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_CEPI);

            /*" -2711- MOVE WS-CEP-COMPL-AUX TO LR06-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_COMPL_CEPI);

            /*" -2712- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2713- MOVE WS-CEP-AUX TO LR06-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_CEPF);

            /*" -2714- MOVE WS-CEP-COMPL-AUX TO LR06-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_COMPL_CEPF);

            /*" -2715- MOVE TAB1-OBJI (WIND) TO LR06-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR06_LINHA06.LR06_OBJI);

            /*" -2716- MOVE TAB1-OBJF (WIND) TO LR06-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR06_LINHA06.LR06_OBJF);

            /*" -2717- MOVE TAB1-AMARI (WIND) TO LR06-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR06_LINHA06.LR06_AMARI);

            /*" -2718- MOVE TAB1-AMARF (WIND) TO LR06-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR06_LINHA06.LR06_AMARF);

            /*" -2719- MOVE TAB1-QTD-OBJ (WIND) TO LR06-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR06_LINHA06.LR06_QTD_OBJ);

            /*" -2720- MOVE TAB1-QTD-AMAR(WIND) TO LR06-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR06_LINHA06.LR06_QTD_AMAR);

            /*" -2721- MOVE SPACES TO LR06-OBS. */
            _.Move("", AREA_DE_WORK.LR06_LINHA06.LR06_OBS);

            /*" -2722- WRITE FBI0060B-RECORD FROM LR06-LINHA06. */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2723- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -2725- ADD 1 TO CONTA-LINHAS. */
            CONTA_LINHAS.Value = CONTA_LINHAS + 1;

            /*" -2726- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -2727- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2728- PERFORM GRAVA-SEP-JDT */

                GRAVA_SEP_JDT_SECTION();

                /*" -2729- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -2730- ELSE */
            }
            else
            {


                /*" -2730- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" GRAVA-SEP-JDT-SECTION */
        private void GRAVA_SEP_JDT_SECTION()
        {
            /*" -2737- MOVE 'GRAV' TO WNR-EXEC-SQL. */
            _.Move("GRAV", WABEND.WNR_EXEC_SQL);

            /*" -2741- MOVE 'GRAVA-SEP-JDT' TO WNR-ROTINA. */
            _.Move("GRAVA-SEP-JDT", WABEND.WNR_ROTINA);

            /*" -2742- IF WS-OCORR NOT = CONTA-LINHAS */

            if (AREA_DE_WORK.WS_OCORR != CONTA_LINHAS)
            {

                /*" -2742- WRITE FBI0060B-RECORD FROM SEPARA-JDT. */
                _.Move(MAIS_LINHAS.SEPARA_JDT.GetMoveValues(), FBI0060B_RECORD);

                FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P_GRAVA_SEP_JDT*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -2754- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -2758- MOVE 'R8000-00-OPEN-ARQUIVOS' TO WNR-ROTINA. */
            _.Move("R8000-00-OPEN-ARQUIVOS", WABEND.WNR_ROTINA);

            /*" -2760- OPEN OUTPUT RBI0060B FBI0060B. */
            RBI0060B.Open(RBI0060B_RECORD);
            FBI0060B.Open(FBI0060B_RECORD);

            /*" -2761- WRITE RBI0060B-RECORD FROM LAISER-01. */
            _.Move(CONTINUA_LINHA.LAISER_01.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2762- WRITE RBI0060B-RECORD FROM LAISER-02. */
            _.Move(CONTINUA_LINHA.LAISER_02.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2763- WRITE RBI0060B-RECORD FROM LAISER-03. */
            _.Move(CONTINUA_LINHA.LAISER_03.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2764- WRITE RBI0060B-RECORD FROM LAISER-04. */
            _.Move(CONTINUA_LINHA.LAISER_04.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2765- WRITE RBI0060B-RECORD FROM LAISER-05. */
            _.Move(CONTINUA_LINHA.LAISER_05.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2766- WRITE RBI0060B-RECORD FROM LAISER-06. */
            _.Move(CONTINUA_LINHA.LAISER_06.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2767- WRITE RBI0060B-RECORD FROM LAISER-07. */
            _.Move(CONTINUA_LINHA.LAISER_07.GetMoveValues(), RBI0060B_RECORD);

            RBI0060B.Write(RBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2768- WRITE FBI0060B-RECORD FROM L1-JDT. */
            _.Move(MAIS_LINHAS.L1_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2769- WRITE FBI0060B-RECORD FROM L2-JDT. */
            _.Move(MAIS_LINHAS.L2_JDT.GetMoveValues(), FBI0060B_RECORD);

            FBI0060B.Write(FBI0060B_RECORD.GetMoveValues().ToString());

            /*" -2769- PERFORM LIMPA-DET-FAC. */

            LIMPA_DET_FAC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -2781- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -2785- MOVE 'R9000-00-CLOSE-ARQUIVOS' TO WNR-ROTINA. */
            _.Move("R9000-00-CLOSE-ARQUIVOS", WABEND.WNR_ROTINA);

            /*" -2786- CLOSE RBI0060B. */
            RBI0060B.Close();

            /*" -2786- CLOSE FBI0060B. */
            FBI0060B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -2800- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2801- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2802- DISPLAY '*   BI0060B - IMPRIME CORRESPONDENCIA      *' */
            _.Display($"*   BI0060B - IMPRIME CORRESPONDENCIA      *");

            /*" -2803- DISPLAY '*   -------   -----------------------      *' */
            _.Display($"*   -------   -----------------------      *");

            /*" -2804- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2805- DISPLAY '*             NAO EXISTE CORRESPONDENCIA   *' */
            _.Display($"*             NAO EXISTE CORRESPONDENCIA   *");

            /*" -2806- DISPLAY '*             PARA ESTA DATA               *' */
            _.Display($"*             PARA ESTA DATA               *");

            /*" -2807- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2807- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" LIMPA-DET-FAC-SECTION */
        private void LIMPA_DET_FAC_SECTION()
        {
            /*" -2815- MOVE 'LIMP' TO WNR-EXEC-SQL. */
            _.Move("LIMP", WABEND.WNR_EXEC_SQL);

            /*" -2819- MOVE 'LIMPA-DET-FAC' TO WNR-ROTINA. */
            _.Move("LIMPA-DET-FAC", WABEND.WNR_ROTINA);

            /*" -2820- MOVE SPACES TO FAC-DETALHE. */
            _.Move("", MAIS_LINHAS.FAC_DETALHE);

            /*" -2820- MOVE '|' TO SEPA-01 SEPA-02 SEPA-03 SEPA-04. */
            _.Move("|", MAIS_LINHAS.FAC_DETALHE.SEPA_01, MAIS_LINHAS.FAC_DETALHE.SEPA_02, MAIS_LINHAS.FAC_DETALHE.SEPA_03, MAIS_LINHAS.FAC_DETALHE.SEPA_04);

        }

        [StopWatch]
        /*" R9900-00-GRAVA-OBJETO-SECTION */
        private void R9900_00_GRAVA_OBJETO_SECTION()
        {
            /*" -2827- MOVE '9900' TO WNR-EXEC-SQL. */
            _.Move("9900", WABEND.WNR_EXEC_SQL);

            /*" -2844- MOVE 'R9900-00-GRAVA-OBJETO' TO WNR-ROTINA. */
            _.Move("R9900-00-GRAVA-OBJETO", WABEND.WNR_ROTINA);

            /*" -2846- MOVE FUNCTION UPPER-CASE (LC09-JDE) TO GEOBJECT-COD-FORMULARIO */
            _.Move(TODAS_AS_LINHAS.LC09_LINHA09_ER.LC09_FORM.LC09_JDE.ToString().ToUpper(), GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -2854- PERFORM R9900_00_GRAVA_OBJETO_DB_SELECT_1 */

            R9900_00_GRAVA_OBJETO_DB_SELECT_1();

            /*" -2858- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2859- PERFORM R9900-03-VALUES-DETALHE */

                R9900_03_VALUES_DETALHE_SECTION();

                /*" -2860- PERFORM R9900-02-INSERT-OBJETO */

                R9900_02_INSERT_OBJETO_SECTION();

                /*" -2861- ELSE */
            }
            else
            {


                /*" -2862- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2863- PERFORM R9900-01-VALUES-HEADER */

                    R9900_01_VALUES_HEADER_SECTION();

                    /*" -2864- PERFORM R9900-02-INSERT-OBJETO */

                    R9900_02_INSERT_OBJETO_SECTION();

                    /*" -2865- PERFORM R9900-03-VALUES-DETALHE */

                    R9900_03_VALUES_DETALHE_SECTION();

                    /*" -2866- PERFORM R9900-02-INSERT-OBJETO */

                    R9900_02_INSERT_OBJETO_SECTION();

                    /*" -2867- ELSE */
                }
                else
                {


                    /*" -2868- DISPLAY 'ERRO DE ACESSO A TABELA GE_OBJETO_ECT.' */
                    _.Display($"ERRO DE ACESSO A TABELA GE_OBJETO_ECT.");

                    /*" -2868- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R9900-00-GRAVA-OBJETO-DB-SELECT-1 */
        public void R9900_00_GRAVA_OBJETO_DB_SELECT_1()
        {
            /*" -2854- EXEC SQL SELECT QTD_PESO_GRAMAS INTO :GEOBJECT-QTD-PESO-GRAMAS FROM SEGUROS.GE_OBJETO_ECT WHERE NUM_CEP = 0 AND NOM_PROGRAMA = 'BI0060B' AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO AND STA_REGISTRO = 'H' END-EXEC. */

            var r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 = new R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1()
            {
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
            };

            var executed_1 = R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1.Execute(r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOBJECT_QTD_PESO_GRAMAS, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9900-02-INSERT-OBJETO-SECTION */
        private void R9900_02_INSERT_OBJETO_SECTION()
        {
            /*" -2877- MOVE '9902' TO WNR-EXEC-SQL. */
            _.Move("9902", WABEND.WNR_EXEC_SQL);

            /*" -2880- MOVE 'R9900-02-INSERT-OBJETO' TO WNR-ROTINA. */
            _.Move("R9900-02-INSERT-OBJETO", WABEND.WNR_ROTINA);

            /*" -2904- PERFORM R9900_02_INSERT_OBJETO_DB_INSERT_1 */

            R9900_02_INSERT_OBJETO_DB_INSERT_1();

            /*" -2907- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2908- IF GEOBJECT-STA-REGISTRO EQUAL 'D' */

                if (GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO == "D")
                {

                    /*" -2909- ADD 1 TO CT-GRAVS */
                    AREA_DE_WORK.CT_GRAVS.Value = AREA_DE_WORK.CT_GRAVS + 1;

                    /*" -2910- END-IF */
                }


                /*" -2911- ELSE */
            }
            else
            {


                /*" -2912- DISPLAY 'ERRO NO INSERT DA GE-OBJETO-ECT ' */
                _.Display($"ERRO NO INSERT DA GE-OBJETO-ECT ");

                /*" -2915- DISPLAY 'TIPO DE REGISTRO...... ' GEOBJECT-STA-REGISTRO ' (H = HEADER D = DETALHE)' */

                $"TIPO DE REGISTRO...... {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO} (H = HEADER D = DETALHE)"
                .Display();

                /*" -2916- DISPLAY 'PROGRAMA ............. BI0060B' */
                _.Display($"PROGRAMA ............. BI0060B");

                /*" -2918- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                /*" -2920- DISPLAY 'PRODUTO............... ' GEOBJECT-COD-PRODUTO */
                _.Display($"PRODUTO............... {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO}");

                /*" -2921- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2921- END-IF. */
            }


        }

        [StopWatch]
        /*" R9900-02-INSERT-OBJETO-DB-INSERT-1 */
        public void R9900_02_INSERT_OBJETO_DB_INSERT_1()
        {
            /*" -2904- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT ( NUM_CEP , NOM_PROGRAMA , COD_FORMULARIO , STA_REGISTRO , DTH_TIMESTAMP , COD_PRODUTO , NUM_INI_POS_VERSO , QTD_PESO_GRAMAS , VLR_DECLARADO , COD_IDENT_OBJETO , DES_OBJETO ) VALUES (:GEOBJECT-NUM-CEP, 'BI0060B' , 'SF14' , :GEOBJECT-STA-REGISTRO, CURRENT TIMESTAMP, :GEOBJECT-COD-PRODUTO:VIND-CODPRODUTO, :GEOBJECT-NUM-INI-POS-VERSO, :GEOBJECT-QTD-PESO-GRAMAS, :GEOBJECT-VLR-DECLARADO, :GEOBJECT-COD-IDENT-OBJETO, :GEOBJECT-DES-OBJETO ) END-EXEC. */

            var r9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1 = new R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                VIND_CODPRODUTO = VIND_CODPRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1.Execute(r9900_02_INSERT_OBJETO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_02_SAIDA*/

        [StopWatch]
        /*" R9900-01-VALUES-HEADER-SECTION */
        private void R9900_01_VALUES_HEADER_SECTION()
        {
            /*" -2929- MOVE '9901' TO WNR-EXEC-SQL. */
            _.Move("9901", WABEND.WNR_EXEC_SQL);

            /*" -2934- MOVE 'R9900-01-VALUES-HEADER' TO WNR-ROTINA. */
            _.Move("R9900-01-VALUES-HEADER", WABEND.WNR_ROTINA);

            /*" -2935- MOVE 0 TO GEOBJECT-NUM-CEP */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -2936- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
            _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -2937- MOVE -1 TO VIND-CODPRODUTO */
            _.Move(-1, VIND_CODPRODUTO);

            /*" -2938- MOVE TVA-PRODUTO(1) TO GEOBJECT-COD-PRODUTO */
            _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -2939- MOVE 391 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(391, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -2940- MOVE 0 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -2941- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -2942- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -2943- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -2943- MOVE DBM-HEADER TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(DBM_HEADER, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_01_SAIDA*/

        [StopWatch]
        /*" R9900-03-VALUES-DETALHE-SECTION */
        private void R9900_03_VALUES_DETALHE_SECTION()
        {
            /*" -2953- MOVE '9903' TO WNR-EXEC-SQL. */
            _.Move("9903", WABEND.WNR_EXEC_SQL);

            /*" -2958- MOVE 'R9900-03-VALUES-DETALHE' TO WNR-ROTINA. */
            _.Move("R9900-03-VALUES-DETALHE", WABEND.WNR_ROTINA);

            /*" -2959- MOVE LE05-CEP TO CEP-PARTE1 */
            _.Move(DBM_DET.LDET_FRENTE.LE05_CEP, TODAS_AS_LINHAS.CEP_LEGAL.CEP_PARTE1);

            /*" -2960- MOVE LE05-CEP-COMPL TO CEP-PARTE2 */
            _.Move(DBM_DET.LDET_FRENTE.LE05_CEP_COMPL, TODAS_AS_LINHAS.CEP_LEGAL.CEP_PARTE2);

            /*" -2961- MOVE CEP-TOTAL TO GEOBJECT-NUM-CEP */
            _.Move(TODAS_AS_LINHAS.CEP_TOTAL, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -2962- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -2963- MOVE +1 TO VIND-CODPRODUTO */
            _.Move(+1, VIND_CODPRODUTO);

            /*" -2964- MOVE TVA-PRODUTO(1) TO GEOBJECT-COD-PRODUTO */
            _.Move(TABELA_REGISTROS.TAB_REG[1].TVA_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -2965- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -2966- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -2967- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -2968- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -2969- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN. */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -2969- MOVE DBM-DET TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(DBM_DET, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_03_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2983- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2985- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -2985- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2987- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2991- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2991- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}