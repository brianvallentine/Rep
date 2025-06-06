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
using Sias.Bilhetes.DB2.BI6017B;

namespace Code
{
    public class BI6017B
    {
        public bool IsCall { get; set; }

        public BI6017B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  SISTEMA ............: BILHETE CAIXA SEGURO FACIL              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ANALISTA............: PRODEXTER / PRODEXTER                   *      */
        /*"      *  DATA................: NOVEMBRO/2000                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  FUNCAO..............: EMISSAO DE CARTA DE AVISO DE CANCELA-   *      */
        /*"      *                        MENTO.                                  *      */
        /*"      *                        RENOVACAO BILHETE CAIXA SEGURO FACIL    *      */
        /*"      *                        *** RESIDENCIAL ***                     *      */
        /*"      * OBSERVACAO...........:                                         *      */
        /*"      * ESTE PROGRAMA ESTA USUANDO A DATA DO SISTEMA CO - PORQUE ESTE  *      */
        /*"      * NAO CONGELA SUA DATA.VIRGINIA 03/05/2001                       *      */
        /*"      * VIRG - 28/08/2002, FOI ALTERADO O JDE=SF05 BILHETE AP PARA     *      */
        /*"      *      JDE=SF06 BILHETE RD.                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                         VIEW                    ACESSO  *      */
        /*"      * ------------------------------ ----------------------- ------- *      */
        /*"      * SISTEMAS                       V1SISTEMA               INPUT   *      */
        /*"      * RELATORIOS                     V0RELATORIOS            I-O     *      */
        /*"      * FAIXA_CEP                      V0FAIXA_CEP             INPUT   *      */
        /*"      * MOVTO_DEBITOCC_CEF             V0MOVDEBCC_CEF          INPUT   *      */
        /*"      * BILHETES                       V0BILHETE               INPUT   *      */
        /*"      * CLIENTES                       V1CLIENTE               INPUT   *      */
        /*"      * ENDERECOS                      V1ENDERECOS             INPUT   *      */
        /*"      * ENDOSSOS                       ENDOSSOS                INPUT   *      */
        /*"      * OBJETOS ECT                    GEOBJECT                OUTPUT  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPRESSAO SAM         PRODEXTER(VANDO)        NOVEMBRO/2002    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO A5 > A4 / CIF POSTNET               FEVEREIRO/2004   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  13/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0808                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 29257 - EVITAR A REJEICAO DE CORRESPONDENCIAS, RECU-  *      */
        /*"      *   PERANDO O CEP NAS BASES DNE DOS CORREIOS PELO ENDERECO.      *      */
        /*"      *   BRSEG - OUTUBRO/2009 - VER: BR.V01                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *           - CONVERSAO DO DB2 PARA A VERSAO 10                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/09/2013 - ROGERIO PEREIRA                              *      */
        /*"      *                                      PROCURE POR V.02          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _BI6017B1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis BI6017B1
        {
            get
            {
                _.Move(BI6017B1_RECORD, _BI6017B1); VarBasis.RedefinePassValue(BI6017B1_RECORD, _BI6017B1, BI6017B1_RECORD); return _BI6017B1;
            }
        }
        public FileBasis _BI6017B2 { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis BI6017B2
        {
            get
            {
                _.Move(BI6017B2_RECORD, _BI6017B2); VarBasis.RedefinePassValue(BI6017B2_RECORD, _BI6017B2, BI6017B2_RECORD); return _BI6017B2;
            }
        }
        public SortBasis<BI6017B_REG_SBI6017B> SBI6017B { get; set; } = new SortBasis<BI6017B_REG_SBI6017B>(new BI6017B_REG_SBI6017B());
        /*"01            BI6017B1-RECORD.*/
        public BI6017B_BI6017B1_RECORD BI6017B1_RECORD { get; set; } = new BI6017B_BI6017B1_RECORD();
        public class BI6017B_BI6017B1_RECORD : VarBasis
        {
            /*"    05          REG-CEP.*/
            public BI6017B_REG_CEP REG_CEP { get; set; } = new BI6017B_REG_CEP();
            public class BI6017B_REG_CEP : VarBasis
            {
                /*"      10        REG-NUMCEP             PIC  9(0005).*/
                public IntBasis REG_NUMCEP { get; set; } = new IntBasis(new PIC("9", "5", "9(0005)."));
                /*"      10        REG-CMPCEP             PIC  9(0003).*/
                public IntBasis REG_CMPCEP { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"    05          REG-REGISTRO           PIC  9(0006).*/
            }
            public IntBasis REG_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
            /*"    05          REG-LINHANR            PIC  9(0003).*/
            public IntBasis REG_LINHANR { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
            /*"    05          REG-PRODUTO            PIC  9(0004).*/
            public IntBasis REG_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
            /*"    05          REG-BRANCO             PIC  X(0001).*/
            public StringBasis REG_BRANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"    05          REG-ATRIBUTOS          PIC  X(3478).*/
            public StringBasis REG_ATRIBUTOS { get; set; } = new StringBasis(new PIC("X", "3478", "X(3478)."), @"");
            /*"01            BI6017B2-RECORD     PIC X(132).*/
        }
        public StringBasis BI6017B2_RECORD { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01            REG-SBI6017B.*/
        public BI6017B_REG_SBI6017B REG_SBI6017B { get; set; } = new BI6017B_REG_SBI6017B();
        public class BI6017B_REG_SBI6017B : VarBasis
        {
            /*"    05        SBI-CEP-G           PIC  9(010).*/
            public IntBasis SBI_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        SBI-NUM-CEP.*/
            public BI6017B_SBI_NUM_CEP SBI_NUM_CEP { get; set; } = new BI6017B_SBI_NUM_CEP();
            public class BI6017B_SBI_NUM_CEP : VarBasis
            {
                /*"      15      SBI-CEP             PIC  9(005).*/
                public IntBasis SBI_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SBI-CEP-COMPL       PIC  9(003).*/
                public IntBasis SBI_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SBI-NOME-RAZAO      PIC  X(040).*/
            }
            public StringBasis SBI_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SBI-NUMBIL          PIC  9(012).*/
            public IntBasis SBI_NUMBIL { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05        SBI-PRODUTO         PIC  9(004).*/
            public IntBasis SBI_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SBI-NOME-CORREIO    PIC  X(046).*/
            public StringBasis SBI_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05        SBI-ENDERECO        PIC  X(072).*/
            public StringBasis SBI_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SBI-BAIRRO          PIC  X(072).*/
            public StringBasis SBI_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SBI-CIDADE          PIC  X(072).*/
            public StringBasis SBI_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SBI-UF              PIC  X(002).*/
            public StringBasis SBI_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05        SBI-NOMEFTE         PIC  X(040).*/
            public StringBasis SBI_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SBI-ENDERFTE        PIC  X(040).*/
            public StringBasis SBI_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SBI-BAIRRO-FTE      PIC  X(020).*/
            public StringBasis SBI_BAIRRO_FTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05        SBI-CIDADE-FTE      PIC  X(020).*/
            public StringBasis SBI_CIDADE_FTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05        SBI-UF-FTE          PIC  X(002).*/
            public StringBasis SBI_UF_FTE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05        SBI-NUM-CEP-FTE.*/
            public BI6017B_SBI_NUM_CEP_FTE SBI_NUM_CEP_FTE { get; set; } = new BI6017B_SBI_NUM_CEP_FTE();
            public class BI6017B_SBI_NUM_CEP_FTE : VarBasis
            {
                /*"      15      SBI-CEP-FTE         PIC  9(005).*/
                public IntBasis SBI_CEP_FTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SBI-COMP-FTE        PIC  9(003).*/
                public IntBasis SBI_COMP_FTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SBI-VIGENCIA        PIC  X(050).*/
            }
            public StringBasis SBI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"*/
        public IntBasis WWI1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WWO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77            SISTEMAS-MESREFER   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis SISTEMAS_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            SISTEMAS-ANOREFER   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis SISTEMAS_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-NRCOPIAS       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-PRODUTO        PIC S9(004)    VALUE +0 COMP*/
        public IntBasis VIND_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            INDEX-AUX           PIC S9(004)    VALUE +0 COMP*/
        public IntBasis INDEX_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public BI6017B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI6017B_AREA_DE_WORK();
        public class BI6017B_AREA_DE_WORK : VarBasis
        {
            /*"    05        LC01-LINHA01.*/
            public BI6017B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new BI6017B_LC01_LINHA01();
            public class BI6017B_LC01_LINHA01 : VarBasis
            {
                /*"      10      LC01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LC01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LC01-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LC01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(070)    VALUE             '$DJDE$ JDE=SF06,JDL=SF,FEED=MAIN,END;'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=SF06,JDL=SF,FEED=MAIN,END;");
                /*"    05        LC01-LINHA01-G.*/
            }
            public BI6017B_LC01_LINHA01_G LC01_LINHA01_G { get; set; } = new BI6017B_LC01_LINHA01_G();
            public class BI6017B_LC01_LINHA01_G : VarBasis
            {
                /*"      10      LC01-CANAL-G        PIC  X(001)    VALUE '+'.*/
                public StringBasis LC01_CANAL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LC01-FONTE-G        PIC  X(001)    VALUE ' '.*/
                public StringBasis LC01_FONTE_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(070)    VALUE             '$DJDE$ JDE=SF06,JDL=SF,FEED=MAIN,END;'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=SF06,JDL=SF,FEED=MAIN,END;");
                /*"    05        LC02-LINHA02.*/
            }
            public BI6017B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new BI6017B_LC02_LINHA02();
            public class BI6017B_LC02_LINHA02 : VarBasis
            {
                /*"      10      LC02-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LC02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(003)    VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LC02-NOME-RAZAO     PIC  X(040)    VALUE SPACES.*/
                public StringBasis LC02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      FILLER              PIC  X(012)    VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"      10      LC02-NUMBIL         PIC  Z999999999999.*/
                public IntBasis LC02_NUMBIL { get; set; } = new IntBasis(new PIC("9", "13", "Z999999999999."));
                /*"      10      FILLER              PIC  X(062)    VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "62", "X(062)"), @"");
                /*"    05        LC03-LINHA03.*/
            }
            public BI6017B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new BI6017B_LC03_LINHA03();
            public class BI6017B_LC03_LINHA03 : VarBasis
            {
                /*"      10      LC03-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LC03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LC03-FONTE          PIC  X(001)    VALUE '2'.*/
                public StringBasis LC03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LC03-NOMEFTE        PIC  X(038)    VALUE SPACES.*/
                public StringBasis LC03_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"      10      FILLER              PIC  X(090)    VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"    05        LC88-LINHA88.*/
            }
            public BI6017B_LC88_LINHA88 LC88_LINHA88 { get; set; } = new BI6017B_LC88_LINHA88();
            public class BI6017B_LC88_LINHA88 : VarBasis
            {
                /*"      10      LC88-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LC88_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        LC99-LINHA99.*/
            }
            public BI6017B_LC99_LINHA99 LC99_LINHA99 { get; set; } = new BI6017B_LC99_LINHA99();
            public class BI6017B_LC99_LINHA99 : VarBasis
            {
                /*"      10      LC99-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LC99_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LC99-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LC99_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(031)    VALUE            '$DJDE$ JDE=1VZ6,JDL=DFAULT,END;'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"$DJDE$ JDE=1VZ6,JDL=DFAULT,END;");
                /*"    05        LE00-LINHA00.*/
            }
            public BI6017B_LE00_LINHA00 LE00_LINHA00 { get; set; } = new BI6017B_LE00_LINHA00();
            public class BI6017B_LE00_LINHA00 : VarBasis
            {
                /*"      10      LE00-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LE00_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LE00-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE00_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(011)    VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      FILLER              PIC  X(119)    VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "119", "X(119)"), @"");
                /*"    05        LE01-LINHA01.*/
            }
            public BI6017B_LE01_LINHA01 LE01_LINHA01 { get; set; } = new BI6017B_LE01_LINHA01();
            public class BI6017B_LE01_LINHA01 : VarBasis
            {
                /*"      10      LE01-CANAL          PIC  X(001)    VALUE 'B'.*/
                public StringBasis LE01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"B");
                /*"      10      LE01-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LE01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(043)    VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"      10      LE01-DTPOSTAGEM     PIC  X(010).*/
                public StringBasis LE01_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LE01-SEQUENCIA      PIC  X(007)    VALUE  SPACES.*/
                public StringBasis LE01_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05        LE02-LINHA02.*/
            }
            public BI6017B_LE02_LINHA02 LE02_LINHA02 { get; set; } = new BI6017B_LE02_LINHA02();
            public class BI6017B_LE02_LINHA02 : VarBasis
            {
                /*"      10      LE02-CANAL          PIC  X(001)    VALUE 'B'.*/
                public StringBasis LE02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"B");
                /*"      10      LE02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LE02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LE02-NOME-RAZAO     PIC  X(040).*/
                public StringBasis LE02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LE03-LINHA03.*/
            }
            public BI6017B_LE03_LINHA03 LE03_LINHA03 { get; set; } = new BI6017B_LE03_LINHA03();
            public class BI6017B_LE03_LINHA03 : VarBasis
            {
                /*"      10      LE03-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE03-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LE03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LE03-ENDERECO       PIC  X(072).*/
                public StringBasis LE03_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        LE04-LINHA04.*/
            }
            public BI6017B_LE04_LINHA04 LE04_LINHA04 { get; set; } = new BI6017B_LE04_LINHA04();
            public class BI6017B_LE04_LINHA04 : VarBasis
            {
                /*"      10      LE04-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE04-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LE04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LE04-BAIRRO         PIC  X(072).*/
                public StringBasis LE04_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LE04-CIDADE         PIC  X(072).*/
                public StringBasis LE04_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10      FILLER              PIC  X(002)    VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      LE04-UF             PIC  X(002).*/
                public StringBasis LE04_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        LE05-LINHA05.*/
            }
            public BI6017B_LE05_LINHA05 LE05_LINHA05 { get; set; } = new BI6017B_LE05_LINHA05();
            public class BI6017B_LE05_LINHA05 : VarBasis
            {
                /*"      10      LE05-CANAL          PIC  X(001)    VALUE ' '.*/
                public StringBasis LE05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      LE05-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LE05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(010)    VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      LE05-CEP.*/
                public BI6017B_LE05_CEP LE05_CEP { get; set; } = new BI6017B_LE05_CEP();
                public class BI6017B_LE05_CEP : VarBasis
                {
                    /*"        15    LE05-CEP-NRO        PIC  99999.*/
                    public IntBasis LE05_CEP_NRO { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                    /*"        15    FILLER              PIC  X(001)    VALUE '-'.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15    LE05-CEP-COMPL      PIC  999.*/
                    public IntBasis LE05_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                    /*"    05        LF01-LINHA01.*/
                }
            }
            public BI6017B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new BI6017B_LF01_LINHA01();
            public class BI6017B_LF01_LINHA01 : VarBasis
            {
                /*"      10      LF01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LF01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LF01-FONTE          PIC  X(001)    VALUE ' '.*/
                public StringBasis LF01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"      10      FILLER              PIC  X(070)    VALUE             '$DJDE$ JDE=FACPEQ,JDL=ECT,FEED=AUX,END;'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=FACPEQ,JDL=ECT,FEED=AUX,END;");
                /*"    05        LF02-LINHA02.*/
            }
            public BI6017B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new BI6017B_LF02_LINHA02();
            public class BI6017B_LF02_LINHA02 : VarBasis
            {
                /*"      10      LF02-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LF02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LF02-NOME-FAIXA     PIC  X(072).*/
                public StringBasis LF02_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        LF03-LINHA03.*/
            }
            public BI6017B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new BI6017B_LF03_LINHA03();
            public class BI6017B_LF03_LINHA03 : VarBasis
            {
                /*"      10      LF03-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LF03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LF03-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LF03-FAIXA1         PIC  X(005).*/
                public StringBasis LF03_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LF03-FAIXA1C        PIC  X(003).*/
                public StringBasis LF03_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10      FILLER              PIC  X(005)    VALUE '  A '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                /*"      10      LF03-FAIXA2         PIC  X(005).*/
                public StringBasis LF03_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LF03-FAIXA2C        PIC  X(003).*/
                public StringBasis LF03_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05        LF04-LINHA04.*/
            }
            public BI6017B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new BI6017B_LF04_LINHA04();
            public class BI6017B_LF04_LINHA04 : VarBasis
            {
                /*"      10      LF04-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LF04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LF04-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(003)    VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LF04-QTD-OBJ        PIC  9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        LF05-LINHA05.*/
            }
            public BI6017B_LF05_LINHA05 LF05_LINHA05 { get; set; } = new BI6017B_LF05_LINHA05();
            public class BI6017B_LF05_LINHA05 : VarBasis
            {
                /*"      10      LF05-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LF05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LF05-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LF05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(003)    VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10      LF05-AMARRADO       PIC  ZZZ.999.*/
                public IntBasis LF05_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(013)    VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      LF05-SEQ-INICIAL    PIC  ZZZ.999.*/
                public IntBasis LF05_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LF05-SEQ-FINAL      PIC  ZZZ.999.*/
                public IntBasis LF05_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    05        LR01-LINHA01.*/
            }
            public BI6017B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new BI6017B_LR01_LINHA01();
            public class BI6017B_LR01_LINHA01 : VarBasis
            {
                /*"      10      LR01-CANAL          PIC  X(001)    VALUE '+'.*/
                public StringBasis LR01_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"      10      LR01-FONTE          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LR01_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      FILLER              PIC  X(070)    VALUE             '$DJDE$ JDE=FACLST,JDL=VIDAZ,END;'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"$DJDE$ JDE=FACLST,JDL=VIDAZ,END;");
                /*"    05        LR02-LINHA02.*/
            }
            public BI6017B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new BI6017B_LR02_LINHA02();
            public class BI6017B_LR02_LINHA02 : VarBasis
            {
                /*"      10      LR02-CANAL          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR02_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      LR02-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR02_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(090)    VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"      10      LR02-SEQ            PIC  ZZ9.*/
                public IntBasis LR02_SEQ { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                /*"      10      FILLER              PIC  X(003)    VALUE ' / '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" / ");
                /*"      10      LR02-MES            PIC  X(009).*/
                public StringBasis LR02_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"      10      FILLER              PIC  X(017)    VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"      10      LR02-PAGINA         PIC  999.*/
                public IntBasis LR02_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LR02-PAG-FINAL      PIC  999       VALUE 003.*/
                public IntBasis LR02_PAG_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "999"), 003);
                /*"    05        LR03-LINHA03.*/
            }
            public BI6017B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new BI6017B_LR03_LINHA03();
            public class BI6017B_LR03_LINHA03 : VarBasis
            {
                /*"      10      LR03-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LR03_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LR03-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR03_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(100)    VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"      10      LR03-TP-PGTO        PIC  X(038)    VALUE             'RENOVACAO DE BILHETE AP E RD'.*/
                public StringBasis LR03_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"RENOVACAO DE BILHETE AP E RD");
                /*"    05        LR04-LINHA04.*/
            }
            public BI6017B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new BI6017B_LR04_LINHA04();
            public class BI6017B_LR04_LINHA04 : VarBasis
            {
                /*"      10      LR04-CANAL          PIC  X(001)    VALUE '2'.*/
                public StringBasis LR04_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"2");
                /*"      10      LR04-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR04_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(086)    VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"");
                /*"      10      LR04-DATA           PIC  X(010).*/
                public StringBasis LR04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05        LR05-LINHA05.*/
            }
            public BI6017B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new BI6017B_LR05_LINHA05();
            public class BI6017B_LR05_LINHA05 : VarBasis
            {
                /*"      10      LR05-CANAL          PIC  X(001)    VALUE '3'.*/
                public StringBasis LR05_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"3");
                /*"      10      LR05-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR05_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      LR05-CEPI           PIC  9(005).*/
                public IntBasis LR05_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR05-COMPL-CEPI     PIC  9(003).*/
                public IntBasis LR05_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR05-CEPF           PIC  9(005).*/
                public IntBasis LR05_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR05-COMPL-CEPF     PIC  9(003).*/
                public IntBasis LR05_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR05-OBJI           PIC  ZZZ.999.*/
                public IntBasis LR05_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR05-OBJF           PIC  ZZZ.999.*/
                public IntBasis LR05_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR05-AMARI          PIC  ZZZ.999.*/
                public IntBasis LR05_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR05-AMARF          PIC  ZZZ.999.*/
                public IntBasis LR05_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR05-QTD-OBJ        PIC  ZZZ.999.*/
                public IntBasis LR05_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR05-QTD-AMAR       PIC  ZZZ.999.*/
                public IntBasis LR05_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(004)    VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LR05-OBS            PIC  X(023).*/
                public StringBasis LR05_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05        LR06-LINHA06.*/
            }
            public BI6017B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new BI6017B_LR06_LINHA06();
            public class BI6017B_LR06_LINHA06 : VarBasis
            {
                /*"      10      LR06-CANAL          PIC  X(001)    VALUE '0'.*/
                public StringBasis LR06_CANAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
                /*"      10      LR06-FONTE          PIC  X(001)    VALUE '1'.*/
                public StringBasis LR06_FONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"      10      FILLER              PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      LR06-CEPI           PIC  9(005).*/
                public IntBasis LR06_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR06-COMPL-CEPI     PIC  9(003).*/
                public IntBasis LR06_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR06-CEPF           PIC  9(005).*/
                public IntBasis LR06_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      LR06-COMPL-CEPF     PIC  9(003).*/
                public IntBasis LR06_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      FILLER              PIC  X(007)    VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      LR06-OBJI           PIC  ZZZ.999.*/
                public IntBasis LR06_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR06-OBJF           PIC  ZZZ.999.*/
                public IntBasis LR06_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR06-AMARI          PIC  ZZZ.999.*/
                public IntBasis LR06_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR06-AMARF          PIC  ZZZ.999.*/
                public IntBasis LR06_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(005)    VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10      LR06-QTD-OBJ        PIC  ZZZ.999.*/
                public IntBasis LR06_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(006)    VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      LR06-QTD-AMAR       PIC  ZZZ.999.*/
                public IntBasis LR06_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10      FILLER              PIC  X(004)    VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10      LR06-OBS            PIC  X(023).*/
                public StringBasis LR06_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05        WSL-SQLCODE         PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-LINHAS           PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05        WWORK-QTDE01.*/
            public BI6017B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new BI6017B_WWORK_QTDE01();
            public class BI6017B_WWORK_QTDE01 : VarBasis
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
            /*"    05        AC-PAGINA           PIC  9(002)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05        AC-CONTA1           PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-I-RELATORIOS     PIC S9(005)    COMP-3 VALUE +0*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05        WZEROS              PIC S9(003)    COMP-3 VALUE +0*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    05        WS-OCORR            PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-AMARRADO         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-OBJ              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ-INICIAL      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTD-OBJ          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-AMAR       PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-OBJ        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-200        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CEP-G-ANT        PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        WS-NOME-COR-ANT.*/
            public BI6017B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new BI6017B_WS_NOME_COR_ANT();
            public class BI6017B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10      WS-FAIXA1-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-FAIXA2-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-NOME-ANT         PIC  X(030).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05        WORK-CEP            PIC  9(008)    VALUE ZEROS.*/
            }
            public IntBasis WORK_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        FILLER              REDEFINES      WORK-CEP.*/
            private _REDEF_BI6017B_FILLER_58 _filler_58 { get; set; }
            public _REDEF_BI6017B_FILLER_58 FILLER_58
            {
                get { _filler_58 = new _REDEF_BI6017B_FILLER_58(); _.Move(WORK_CEP, _filler_58); VarBasis.RedefinePassValue(WORK_CEP, _filler_58, WORK_CEP); _filler_58.ValueChanged += () => { _.Move(_filler_58, WORK_CEP); }; return _filler_58; }
                set { VarBasis.RedefinePassValue(value, _filler_58, WORK_CEP); }
            }  //Redefines
            public class _REDEF_BI6017B_FILLER_58 : VarBasis
            {
                /*"      10      WORK-CEP-NUM        PIC  9(005).*/
                public IntBasis WORK_CEP_NUM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WORK-CEP-CPL        PIC  9(003).*/
                public IntBasis WORK_CEP_CPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-CEP-ANT          PIC  9(005).*/

                public _REDEF_BI6017B_FILLER_58()
                {
                    WORK_CEP_NUM.ValueChanged += OnValueChanged;
                    WORK_CEP_CPL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CEP_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-COMPL-ANT        PIC  9(003).*/
            public IntBasis WS_COMPL_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05        WS-INF              PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-SUP              PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WIND                PIC  9(005)    VALUE  ZEROS.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WIND1               PIC  9(005)    VALUE  ZEROS.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WS-CPF              PIC  9(015).*/
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CPF-R            REDEFINES              WS-CPF.*/
            private _REDEF_BI6017B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_BI6017B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_BI6017B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_BI6017B_WS_CPF_R : VarBasis
            {
                /*"      10      WS-NRCPF            PIC  9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-DVCPF            PIC  9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SQL.*/

                public _REDEF_BI6017B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public BI6017B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new BI6017B_WS_DATA_SQL();
            public class BI6017B_WS_DATA_SQL : VarBasis
            {
                /*"      10      WS-ANO-SQL          PIC  9(004).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-DATA-I.*/
            }
            public BI6017B_WS_DATA_I WS_DATA_I { get; set; } = new BI6017B_WS_DATA_I();
            public class BI6017B_WS_DATA_I : VarBasis
            {
                /*"      10      WS-DIA-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB1            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-MES-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB2            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-ANO-I            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05        WHORA-CURR          PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05        WWORK-DATA-DB2      PIC  X(010)   VALUE  SPACES.*/
            public StringBasis WWORK_DATA_DB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05        FILLER              REDEFINES     WWORK-DATA-DB2.*/
            private _REDEF_BI6017B_FILLER_61 _filler_61 { get; set; }
            public _REDEF_BI6017B_FILLER_61 FILLER_61
            {
                get { _filler_61 = new _REDEF_BI6017B_FILLER_61(); _.Move(WWORK_DATA_DB2, _filler_61); VarBasis.RedefinePassValue(WWORK_DATA_DB2, _filler_61, WWORK_DATA_DB2); _filler_61.ValueChanged += () => { _.Move(_filler_61, WWORK_DATA_DB2); }; return _filler_61; }
                set { VarBasis.RedefinePassValue(value, _filler_61, WWORK_DATA_DB2); }
            }  //Redefines
            public class _REDEF_BI6017B_FILLER_61 : VarBasis
            {
                /*"      10      WWORK-ANO-DB2       PIC  9(004).*/
                public IntBasis WWORK_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WWORK-MES-DB2       PIC  9(002).*/
                public IntBasis WWORK_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WWORK-DIA-DB2       PIC  9(002).*/
                public IntBasis WWORK_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWORK-DATA-VIG      PIC  X(023)   VALUE  SPACES.*/

                public _REDEF_BI6017B_FILLER_61()
                {
                    WWORK_ANO_DB2.ValueChanged += OnValueChanged;
                    FILLER_62.ValueChanged += OnValueChanged;
                    WWORK_MES_DB2.ValueChanged += OnValueChanged;
                    FILLER_63.ValueChanged += OnValueChanged;
                    WWORK_DIA_DB2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WWORK_DATA_VIG { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"    05        FILLER              REDEFINES     WWORK-DATA-VIG.*/
            private _REDEF_BI6017B_FILLER_64 _filler_64 { get; set; }
            public _REDEF_BI6017B_FILLER_64 FILLER_64
            {
                get { _filler_64 = new _REDEF_BI6017B_FILLER_64(); _.Move(WWORK_DATA_VIG, _filler_64); VarBasis.RedefinePassValue(WWORK_DATA_VIG, _filler_64, WWORK_DATA_VIG); _filler_64.ValueChanged += () => { _.Move(_filler_64, WWORK_DATA_VIG); }; return _filler_64; }
                set { VarBasis.RedefinePassValue(value, _filler_64, WWORK_DATA_VIG); }
            }  //Redefines
            public class _REDEF_BI6017B_FILLER_64 : VarBasis
            {
                /*"      10      WWORK-DIA-VIG       PIC  9(002).*/
                public IntBasis WWORK_DIA_VIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WWORK-LITERA1       PIC  X(004).*/
                public StringBasis WWORK_LITERA1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      10      WWORK-MES-VIG       PIC  X(009).*/
                public StringBasis WWORK_MES_VIG { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"      10      WWORK-LITERA2       PIC  X(004).*/
                public StringBasis WWORK_LITERA2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      10      WWORK-ANO-VIG       PIC  9(004).*/
                public IntBasis WWORK_ANO_VIG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WWORK-VIGENCIA      PIC  X(050)   VALUE  SPACES.*/

                public _REDEF_BI6017B_FILLER_64()
                {
                    WWORK_DIA_VIG.ValueChanged += OnValueChanged;
                    WWORK_LITERA1.ValueChanged += OnValueChanged;
                    WWORK_MES_VIG.ValueChanged += OnValueChanged;
                    WWORK_LITERA2.ValueChanged += OnValueChanged;
                    WWORK_ANO_VIG.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WWORK_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"    05        FILLER              REDEFINES     WWORK-VIGENCIA.*/
            private _REDEF_BI6017B_FILLER_65 _filler_65 { get; set; }
            public _REDEF_BI6017B_FILLER_65 FILLER_65
            {
                get { _filler_65 = new _REDEF_BI6017B_FILLER_65(); _.Move(WWORK_VIGENCIA, _filler_65); VarBasis.RedefinePassValue(WWORK_VIGENCIA, _filler_65, WWORK_VIGENCIA); _filler_65.ValueChanged += () => { _.Move(_filler_65, WWORK_VIGENCIA); }; return _filler_65; }
                set { VarBasis.RedefinePassValue(value, _filler_65, WWORK_VIGENCIA); }
            }  //Redefines
            public class _REDEF_BI6017B_FILLER_65 : VarBasis
            {
                /*"      10      WWORK-INI-VIG       PIC  X(023).*/
                public StringBasis WWORK_INI_VIG { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"      10      WWORK-LITERA3       PIC  X(003).*/
                public StringBasis WWORK_LITERA3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10      WWORK-TER-VIG       PIC  X(023).*/
                public StringBasis WWORK_TER_VIG { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"      10      WWORK-LITERA4       PIC  X(001).*/
                public StringBasis WWORK_LITERA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WW-INPUT            PIC  X(050)    VALUE SPACES.*/

                public _REDEF_BI6017B_FILLER_65()
                {
                    WWORK_INI_VIG.ValueChanged += OnValueChanged;
                    WWORK_LITERA3.ValueChanged += OnValueChanged;
                    WWORK_TER_VIG.ValueChanged += OnValueChanged;
                    WWORK_LITERA4.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WW_INPUT { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"    05          FILLER              REDEFINES      WW-INPUT                                  OCCURS         50                                  INDEXED  BY    WWI1.*/
            private ListBasis<_REDEF_BI6017B_FILLER_66> _filler_66 { get; set; }
            public ListBasis<_REDEF_BI6017B_FILLER_66> FILLER_66
            {
                get { _filler_66 = new ListBasis<_REDEF_BI6017B_FILLER_66>(50); _.Move(WW_INPUT, _filler_66); VarBasis.RedefinePassValue(WW_INPUT, _filler_66, WW_INPUT); _filler_66.ValueChanged += () => { _.Move(_filler_66, WW_INPUT); }; return _filler_66; }
                set { VarBasis.RedefinePassValue(value, _filler_66, WW_INPUT); }
            }  //Redefines
            public class _REDEF_BI6017B_FILLER_66 : VarBasis
            {
                /*"      10        WW-CCC-I            PIC  X(001).*/
                public StringBasis WW_CCC_I { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WW-OUTPUT           PIC  X(050)    VALUE SPACES.*/

                public _REDEF_BI6017B_FILLER_66()
                {
                    WW_CCC_I.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WW_OUTPUT { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"    05          FILLER              REDEFINES      WW-OUTPUT                                  OCCURS         50                                  INDEXED  BY    WWO1.*/
            private ListBasis<_REDEF_BI6017B_FILLER_67> _filler_67 { get; set; }
            public ListBasis<_REDEF_BI6017B_FILLER_67> FILLER_67
            {
                get { _filler_67 = new ListBasis<_REDEF_BI6017B_FILLER_67>(50); _.Move(WW_OUTPUT, _filler_67); VarBasis.RedefinePassValue(WW_OUTPUT, _filler_67, WW_OUTPUT); _filler_67.ValueChanged += () => { _.Move(_filler_67, WW_OUTPUT); }; return _filler_67; }
                set { VarBasis.RedefinePassValue(value, _filler_67, WW_OUTPUT); }
            }  //Redefines
            public class _REDEF_BI6017B_FILLER_67 : VarBasis
            {
                /*"      10        WW-CCC-O            PIC  X(001).*/
                public StringBasis WW_CCC_O { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05        WS-NOME-RAZAO.*/

                public _REDEF_BI6017B_FILLER_67()
                {
                    WW_CCC_O.ValueChanged += OnValueChanged;
                }

            }
            public BI6017B_WS_NOME_RAZAO WS_NOME_RAZAO { get; set; } = new BI6017B_WS_NOME_RAZAO();
            public class BI6017B_WS_NOME_RAZAO : VarBasis
            {
                /*"      10      WS-LETRA-NOME       OCCURS 41 TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_LETRA_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 41);
                /*"    05        WS-NUM-CEP-AUX      PIC  9(008).*/
            }
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-NUM-CEP-AUX-R    REDEFINES              WS-NUM-CEP-AUX.*/
            private _REDEF_BI6017B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_BI6017B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_BI6017B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_BI6017B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10      WS-CEP-AUX          PIC  9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CEP-COMPL-AUX    PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-NUM-CEP-AUX-R1   REDEFINES              WS-NUM-CEP-AUX.*/

                public _REDEF_BI6017B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_BI6017B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_BI6017B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_BI6017B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_BI6017B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10      WS-CEP-COMPL-AUX1   PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-CEP-AUX1         PIC  9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-NOME-FONTE.*/

                public _REDEF_BI6017B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public BI6017B_WS_NOME_FONTE WS_NOME_FONTE { get; set; } = new BI6017B_WS_NOME_FONTE();
            public class BI6017B_WS_NOME_FONTE : VarBasis
            {
                /*"      10      WS-LITERAL          PIC  X(007)    VALUE 'FILIAL'.*/
                public StringBasis WS_LITERAL { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"FILIAL");
                /*"      10      WS-NOMEFTE          PIC  X(033)    VALUE SPACES.*/
                public StringBasis WS_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    05        AC-LIDOS            PIC  9(009)    VALUE ZEROES.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-CONTA            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-IMPRESSOS        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        WFIM-SISTEMAS       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-FAIXACEP       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-MOVDEBCC       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVDEBCC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-SORT           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-TABELA         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-BILHETE        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-CLIENTE        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-ENDERECO       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-FONTES         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-ENDOSSOS       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_ENDOSSOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        LK-PROSOMU1.*/
            public BI6017B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new BI6017B_LK_PROSOMU1();
            public class BI6017B_LK_PROSOMU1 : VarBasis
            {
                /*"      10      LK-DATA-SOM         PIC  9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-SOM-R       REDEFINES              LK-DATA-SOM.*/
                private _REDEF_BI6017B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_BI6017B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_BI6017B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_BI6017B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15    LK-DIA-SOM          PIC  9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-SOM          PIC  9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-SOM          PIC  9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      LK-QTDIAS           PIC S9(005)    COMP-3 VALUE +1*/

                    public _REDEF_BI6017B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"      10      LK-DATA-CALC        PIC  9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-CALC-R      REDEFINES              LK-DATA-CALC.*/
                private _REDEF_BI6017B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_BI6017B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_BI6017B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_BI6017B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15    LK-DIA-CALC         PIC  9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-CALC         PIC  9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-CALC         PIC  9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01            TABELA-CEP.*/

                    public _REDEF_BI6017B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public BI6017B_TABELA_CEP TABELA_CEP { get; set; } = new BI6017B_TABELA_CEP();
        public class BI6017B_TABELA_CEP : VarBasis
        {
            /*"    05        CEP                 OCCURS 2000 TIMES.*/
            public ListBasis<BI6017B_CEP> CEP { get; set; } = new ListBasis<BI6017B_CEP>(2000);
            public class BI6017B_CEP : VarBasis
            {
                /*"      10      TAB-FX-CEP-G        PIC  9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TAB-FAIXAS.*/
                public BI6017B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new BI6017B_TAB_FAIXAS();
                public class BI6017B_TAB_FAIXAS : VarBasis
                {
                    /*"        15    TAB-FX-INI          PIC  9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-FIM          PIC  9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-NOME         PIC  X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15    TAB-FX-CENTR        PIC  X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-TOTAIS.*/
                }
            }
        }
        public BI6017B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new BI6017B_TABELA_TOTAIS();
        public class BI6017B_TABELA_TOTAIS : VarBasis
        {
            /*"    05        TAB-TOTAIS          OCCURS  2000 TIMES.*/
            public ListBasis<BI6017B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<BI6017B_TAB_TOTAIS>(2000);
            public class BI6017B_TAB_TOTAIS : VarBasis
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
                /*"01            TABELA-MESES.*/
            }
        }
        public BI6017B_TABELA_MESES TABELA_MESES { get; set; } = new BI6017B_TABELA_MESES();
        public class BI6017B_TABELA_MESES : VarBasis
        {
            /*"    05        TAB-MESES.*/
            public BI6017B_TAB_MESES TAB_MESES { get; set; } = new BI6017B_TAB_MESES();
            public class BI6017B_TAB_MESES : VarBasis
            {
                /*"      10      FILLER              PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10      FILLER              PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05        TAB-MESES-R         REDEFINES              TAB-MESES.*/
            }
            private _REDEF_BI6017B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_BI6017B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_BI6017B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_BI6017B_TAB_MESES_R : VarBasis
            {
                /*"      10      TAB-MES             OCCURS 12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01            TABELA-REGISTROS.*/

                public _REDEF_BI6017B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI6017B_TABELA_REGISTROS TABELA_REGISTROS { get; set; } = new BI6017B_TABELA_REGISTROS();
        public class BI6017B_TABELA_REGISTROS : VarBasis
        {
            /*"  03          TAB-REG             OCCURS 2 TIMES.*/
            public ListBasis<BI6017B_TAB_REG> TAB_REG { get; set; } = new ListBasis<BI6017B_TAB_REG>(2);
            public class BI6017B_TAB_REG : VarBasis
            {
                /*"    05        TBI-NUM-CEP.*/
                public BI6017B_TBI_NUM_CEP TBI_NUM_CEP { get; set; } = new BI6017B_TBI_NUM_CEP();
                public class BI6017B_TBI_NUM_CEP : VarBasis
                {
                    /*"      15      TBI-CEP             PIC  9(005).*/
                    public IntBasis TBI_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15      TBI-CEP-COMPL       PIC  9(003).*/
                    public IntBasis TBI_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"    05        TBI-NOME-RAZAO      PIC  X(040).*/
                }
                public StringBasis TBI_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        TBI-NUMBIL          PIC  9(013).*/
                public IntBasis TBI_NUMBIL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05        TBI-PRODUTO         PIC  9(004).*/
                public IntBasis TBI_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        TBI-ENDERECO        PIC  X(072).*/
                public StringBasis TBI_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        TBI-BAIRRO          PIC  X(072).*/
                public StringBasis TBI_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        TBI-CIDADE          PIC  X(072).*/
                public StringBasis TBI_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05        TBI-UF              PIC  X(002).*/
                public StringBasis TBI_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        TBI-NOMEFTE         PIC  X(040).*/
                public StringBasis TBI_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        TBI-ENDERFTE        PIC  X(040).*/
                public StringBasis TBI_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        TBI-BAIRRO-FTE      PIC  X(020).*/
                public StringBasis TBI_BAIRRO_FTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05        TBI-CIDADE-FTE      PIC  X(020).*/
                public StringBasis TBI_CIDADE_FTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05        TBI-UF-FTE          PIC  X(002).*/
                public StringBasis TBI_UF_FTE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05        TBI-NUM-CEP-FTE.*/
                public BI6017B_TBI_NUM_CEP_FTE TBI_NUM_CEP_FTE { get; set; } = new BI6017B_TBI_NUM_CEP_FTE();
                public class BI6017B_TBI_NUM_CEP_FTE : VarBasis
                {
                    /*"      15      TBI-CEP-FTE         PIC  9(005).*/
                    public IntBasis TBI_CEP_FTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15      TBI-COMP-FTE        PIC  9(003).*/
                    public IntBasis TBI_COMP_FTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"    05        TBI-VIGENCIA        PIC  X(050).*/
                }
                public StringBasis TBI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01          WABEND.*/
            }
        }
        public BI6017B_WABEND WABEND { get; set; } = new BI6017B_WABEND();
        public class BI6017B_WABEND : VarBasis
        {
            /*"    05    FILLER              PIC  X(010) VALUE         ' BI6017B'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI6017B");
            /*"    05    FILLER              PIC  X(026) VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    05    WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05    FILLER              PIC  X(013) VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    05    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01          IMPRESSAO-SAM.*/
        }
        public BI6017B_IMPRESSAO_SAM IMPRESSAO_SAM { get; set; } = new BI6017B_IMPRESSAO_SAM();
        public class BI6017B_IMPRESSAO_SAM : VarBasis
        {
            /*"    05        SF06-HEADER.*/
            public BI6017B_SF06_HEADER SF06_HEADER { get; set; } = new BI6017B_SF06_HEADER();
            public class BI6017B_SF06_HEADER : VarBasis
            {
                /*"      10    FILLER              PIC  X(104)      VALUE           'SEGURADO|BILHETE|DTVIGENCIA|REMETENTE|REMET-ENDERECO|           'REMET-BAIRRO|REMET-CIDADE|REMET-UF|REMET-CEP|DTPOST'*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "104", "X(104)"), @"SEGURADO|BILHETE|DTVIGENCIA|REMETENTE|REMET_ENDERECO|           ");
                /*"      10    FILLER              PIC  X(104)      VALUE           'AGEM|NUMOBJETO|DESTINATARIO|ENDERECO|BAIRRO|CIDADE|UF           '|CEP|POSTNET|CODIGO-CIF                            '*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "104", "X(104)"), @"AGEM|NUMOBJETO|DESTINATARIO|ENDERECO|BAIRRO|CIDADE|UF           ");
                /*"    05        SF06-REGISTRO.*/
            }
            public BI6017B_SF06_REGISTRO SF06_REGISTRO { get; set; } = new BI6017B_SF06_REGISTRO();
            public class BI6017B_SF06_REGISTRO : VarBasis
            {
                /*"      10      SF06-SEGURADO       PIC  X(040)      VALUE  SPACES*/
                public StringBasis SF06_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      SF06-SEPARA-001     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-BILHETE        PIC  X(013)      VALUE  SPACES*/
                public StringBasis SF06_BILHETE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      SF06-SEPARA-002     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_002 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-VIGENCIA       PIC  X(050)      VALUE  SPACES*/
                public StringBasis SF06_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"      10      SF06-SEPARA-003     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_003 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-REMETENTE      PIC  X(040)      VALUE  SPACES*/
                public StringBasis SF06_REMETENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      SF06-SEPARA-004     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_004 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-REM-ENDEREC    PIC  X(040)      VALUE  SPACES*/
                public StringBasis SF06_REM_ENDEREC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      SF06-SEPARA-005     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_005 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-REM-BAIRRO     PIC  X(020)      VALUE  SPACES*/
                public StringBasis SF06_REM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10      SF06-SEPARA-006     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_006 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-REM-CIDADE     PIC  X(020)      VALUE  SPACES*/
                public StringBasis SF06_REM_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10      SF06-SEPARA-007     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_007 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-REM-ESTADO     PIC  X(002)      VALUE  SPACES*/
                public StringBasis SF06_REM_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      SF06-SEPARA-008     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_008 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-REM-CEP        PIC  X(009)      VALUE  SPACES*/
                public StringBasis SF06_REM_CEP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SF06-SEPARA-009     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_009 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-DPOSTAGEM      PIC  X(010)      VALUE  SPACES*/
                public StringBasis SF06_DPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10      SF06-SEPARA-010     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_010 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-NUMOBJETO      PIC  X(007)      VALUE  SPACES*/
                public StringBasis SF06_NUMOBJETO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10      SF06-SEPARA-011     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_011 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-DESTINATAR     PIC  X(040)      VALUE  SPACES*/
                public StringBasis SF06_DESTINATAR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      SF06-SEPARA-012     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_012 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-ENDERECO       PIC  X(072)      VALUE  SPACES*/
                public StringBasis SF06_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"      10      SF06-SEPARA-013     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_013 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-BAIRRO         PIC  X(072)      VALUE  SPACES*/
                public StringBasis SF06_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"      10      SF06-SEPARA-014     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_014 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-CIDADE         PIC  X(072)      VALUE  SPACES*/
                public StringBasis SF06_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"      10      SF06-SEPARA-015     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_015 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-UF             PIC  X(002)      VALUE  SPACES*/
                public StringBasis SF06_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10      SF06-SEPARA-016     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_016 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-CEP            PIC  X(009)      VALUE  SPACES*/
                public StringBasis SF06_CEP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"      10      SF06-SEPARA-017     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_017 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-POSTNET        PIC  X(011)      VALUE  SPACES*/
                public StringBasis SF06_POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      SF06-SEPARA-018     PIC  X(001)      VALUE  SPACES*/
                public StringBasis SF06_SEPARA_018 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      10      SF06-CODIGO-CIF     PIC  X(034)      VALUE  SPACES*/
                public StringBasis SF06_CODIGO_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05        SF06-EOF            PIC  X(007)      VALUE '%%EOF'*/
            }
            public StringBasis SF06_EOF { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"%%EOF");
            /*"    05        ACC-REGISTRO        PIC  9(006)      VALUE  ZEROS.*/
            public IntBasis ACC_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        ATRIBUTOS-REGISTRO.*/
            public BI6017B_ATRIBUTOS_REGISTRO ATRIBUTOS_REGISTRO { get; set; } = new BI6017B_ATRIBUTOS_REGISTRO();
            public class BI6017B_ATRIBUTOS_REGISTRO : VarBasis
            {
                /*"      10      ATRIBUTOS-CONTROLE  PIC  X(0002)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_CONTROLE { get; set; } = new StringBasis(new PIC("X", "2", "X(0002)"), @"");
                /*"      10      ATRIBUTOS-FILLER    PIC  X(0001)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)"), @"");
                /*"      10      ATRIBUTOS-CONTRATO  PIC  X(0011)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_CONTRATO { get; set; } = new StringBasis(new PIC("X", "11", "X(0011)"), @"");
                /*"      10      ATRIBUTOS-FILLER    PIC  X(0001)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)"), @"");
                /*"      10      ATRIBUTOS-POSICAO   PIC  9(0004)     VALUE  ZEROS.*/
                public IntBasis ATRIBUTOS_POSICAO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)"));
                /*"      10      ATRIBUTOS-FILLER    PIC  X(0001)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)"), @"");
                /*"      10      ATRIBUTOS-EMPRESA   PIC  X(0040)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)"), @"");
                /*"      10      ATRIBUTOS-ENDERECO  PIC  X(0040)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)"), @"");
                /*"      10      ATRIBUTOS-PRODUTO   PIC  X(0040)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)"), @"");
                /*"      10      ATRIBUTOS-PROGRAMA  PIC  X(0008)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)"), @"");
                /*"      10      ATRIBUTOS-FORMULAR  PIC  X(0008)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_FORMULAR { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)"), @"");
                /*"      10      ATRIBUTOS-FILLER    PIC  X(0003)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)"), @"");
                /*"      10      ATRIBUTOS-QTDIAS    PIC  X(0002)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_QTDIAS { get; set; } = new StringBasis(new PIC("X", "2", "X(0002)"), @"");
                /*"      10      ATRIBUTOS-RESTO     PIC  X(3317)     VALUE  SPACES*/
                public StringBasis ATRIBUTOS_RESTO { get; set; } = new StringBasis(new PIC("X", "3317", "X(3317)"), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEFAICEP GEFAICEP { get; set; } = new Dclgens.GEFAICEP();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public BI6017B_CFAIXACEP CFAIXACEP { get; set; } = new BI6017B_CFAIXACEP();
        public BI6017B_MOVDEBCC MOVDEBCC { get; set; } = new BI6017B_MOVDEBCC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SBI6017B_FILE_NAME_P, string BI6017B1_FILE_NAME_P, string BI6017B2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SBI6017B.SetFile(SBI6017B_FILE_NAME_P);
                BI6017B1.SetFile(BI6017B1_FILE_NAME_P);
                BI6017B2.SetFile(BI6017B2_FILE_NAME_P);

                /*" -696- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -697- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -700- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -703- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -703- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -713- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -714- IF WFIM-SISTEMAS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMAS.IsEmpty())
            {

                /*" -716- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -717- PERFORM R0900-00-DECLARE-MOVDEBCC. */

            R0900_00_DECLARE_MOVDEBCC_SECTION();

            /*" -719- PERFORM R0910-00-FETCH-MOVDEBCC. */

            R0910_00_FETCH_MOVDEBCC_SECTION();

            /*" -720- IF WFIM-MOVDEBCC EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_MOVDEBCC == "S")
            {

                /*" -721- PERFORM R9800-00-ENCERRA-SEM-MOVTO */

                R9800_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -722- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -724- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -726- MOVE ZEROS TO TABELA-TOTAIS. */
            _.Move(0, TABELA_TOTAIS);

            /*" -728- PERFORM R0200-00-CARREGA-FAIXA-CEP. */

            R0200_00_CARREGA_FAIXA_CEP_SECTION();

            /*" -730- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -733- SORT SBI6017B ON ASCENDING KEY SBI-CEP-G SBI-NUM-CEP INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SBI6017B.Sort("SBI-CEP-G,SBI-NUM-CEP", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -736- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -737- DISPLAY '*** BI6017B *** PROBLEMAS NO SORT ' */
                _.Display($"*** BI6017B *** PROBLEMAS NO SORT ");

                /*" -738- DISPLAY '*** BI6017B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** BI6017B *** SORT-RETURN = {SORT_RETURN}");

                /*" -738- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -744- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -744- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -747- DISPLAY '*** BI6017B - ' */
            _.Display($"*** BI6017B - ");

            /*" -748- DISPLAY 'LIDOS RELATORIOS         ' AC-LIDOS. */
            _.Display($"LIDOS RELATORIOS         {AREA_DE_WORK.AC_LIDOS}");

            /*" -750- DISPLAY 'CARTAS IMPRESSAS         ' AC-IMPRESSOS. */
            _.Display($"CARTAS IMPRESSAS         {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -751- DISPLAY '*** BI6017B - TERMINO NORMAL ***' */
            _.Display($"*** BI6017B - TERMINO NORMAL ***");

            /*" -751- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -763- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-MOVDEBCC EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_MOVDEBCC == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -776- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -778- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -779- MOVE SPACES TO BI6017B1-RECORD */
            _.Move("", BI6017B1_RECORD);

            /*" -780- MOVE SPACES TO ATRIBUTOS-REGISTRO */
            _.Move("", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO);

            /*" -781- MOVE '%!' TO ATRIBUTOS-CONTROLE */
            _.Move("%!", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_CONTROLE);

            /*" -782- MOVE '100134700-6' TO ATRIBUTOS-CONTRATO */
            _.Move("100134700-6", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_CONTRATO);

            /*" -783- MOVE 133 TO ATRIBUTOS-POSICAO */
            _.Move(133, IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_POSICAO);

            /*" -785- MOVE 'SASSE - CIA NACIONAL DE SEGUROS GERAIS' TO ATRIBUTOS-EMPRESA */
            _.Move("SASSE - CIA NACIONAL DE SEGUROS GERAIS", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_EMPRESA);

            /*" -787- MOVE 'SCN Q 01 - Bl A - Ed. Number One, 17 and' TO ATRIBUTOS-ENDERECO */
            _.Move("SCN Q 01 - Bl A - Ed. Number One, 17 and", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_ENDERECO);

            /*" -789- MOVE 'RENOVACAO DE BILHETE AP E RD' TO ATRIBUTOS-PRODUTO */
            _.Move("RENOVACAO DE BILHETE AP E RD", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_PRODUTO);

            /*" -790- MOVE 'BI6017B ' TO ATRIBUTOS-PROGRAMA */
            _.Move("BI6017B ", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_PROGRAMA);

            /*" -791- MOVE 'SF06    ' TO ATRIBUTOS-FORMULAR */
            _.Move("SF06    ", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_FORMULAR);

            /*" -792- MOVE '01' TO ATRIBUTOS-QTDIAS */
            _.Move("01", IMPRESSAO_SAM.ATRIBUTOS_REGISTRO.ATRIBUTOS_QTDIAS);

            /*" -794- MOVE ATRIBUTOS-REGISTRO TO REG-ATRIBUTOS */
            _.Move(IMPRESSAO_SAM.ATRIBUTOS_REGISTRO, BI6017B1_RECORD.REG_ATRIBUTOS);

            /*" -795- MOVE ZEROS TO REG-CEP */
            _.Move(0, BI6017B1_RECORD.REG_CEP);

            /*" -796- MOVE ZEROS TO REG-REGISTRO */
            _.Move(0, BI6017B1_RECORD.REG_REGISTRO);

            /*" -797- MOVE 1 TO REG-LINHANR */
            _.Move(1, BI6017B1_RECORD.REG_LINHANR);

            /*" -798- MOVE ZEROS TO REG-PRODUTO */
            _.Move(0, BI6017B1_RECORD.REG_PRODUTO);

            /*" -799- MOVE SPACES TO REG-BRANCO */
            _.Move("", BI6017B1_RECORD.REG_BRANCO);

            /*" -801- WRITE BI6017B1-RECORD */
            BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());

            /*" -802- MOVE ZEROS TO REG-CEP */
            _.Move(0, BI6017B1_RECORD.REG_CEP);

            /*" -803- MOVE ZEROS TO REG-REGISTRO */
            _.Move(0, BI6017B1_RECORD.REG_REGISTRO);

            /*" -804- MOVE ZEROS TO REG-PRODUTO */
            _.Move(0, BI6017B1_RECORD.REG_PRODUTO);

            /*" -805- MOVE 2 TO REG-LINHANR */
            _.Move(2, BI6017B1_RECORD.REG_LINHANR);

            /*" -806- MOVE SPACES TO REG-ATRIBUTOS */
            _.Move("", BI6017B1_RECORD.REG_ATRIBUTOS);

            /*" -807- MOVE '(|) SETDBSEP' TO REG-ATRIBUTOS */
            _.Move("(|) SETDBSEP", BI6017B1_RECORD.REG_ATRIBUTOS);

            /*" -809- WRITE BI6017B1-RECORD */
            BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());

            /*" -810- MOVE ZEROS TO REG-CEP */
            _.Move(0, BI6017B1_RECORD.REG_CEP);

            /*" -811- MOVE ZEROS TO REG-REGISTRO */
            _.Move(0, BI6017B1_RECORD.REG_REGISTRO);

            /*" -812- MOVE ZEROS TO REG-PRODUTO */
            _.Move(0, BI6017B1_RECORD.REG_PRODUTO);

            /*" -813- MOVE 3 TO REG-LINHANR */
            _.Move(3, BI6017B1_RECORD.REG_LINHANR);

            /*" -814- MOVE '(sf06.dbm) STARTDBM' TO REG-ATRIBUTOS */
            _.Move("(sf06.dbm) STARTDBM", BI6017B1_RECORD.REG_ATRIBUTOS);

            /*" -816- WRITE BI6017B1-RECORD */
            BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());

            /*" -817- MOVE ZEROS TO REG-CEP */
            _.Move(0, BI6017B1_RECORD.REG_CEP);

            /*" -818- MOVE ZEROS TO REG-REGISTRO */
            _.Move(0, BI6017B1_RECORD.REG_REGISTRO);

            /*" -819- MOVE ZEROS TO REG-PRODUTO */
            _.Move(0, BI6017B1_RECORD.REG_PRODUTO);

            /*" -820- MOVE 4 TO REG-LINHANR */
            _.Move(4, BI6017B1_RECORD.REG_LINHANR);

            /*" -821- MOVE SF06-HEADER TO REG-ATRIBUTOS */
            _.Move(IMPRESSAO_SAM.SF06_HEADER, BI6017B1_RECORD.REG_ATRIBUTOS);

            /*" -823- WRITE BI6017B1-RECORD */
            BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());

            /*" -825- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -828- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -829- MOVE SPACES TO BI6017B1-RECORD */
            _.Move("", BI6017B1_RECORD);

            /*" -830- MOVE 99999999 TO REG-CEP */
            _.Move(99999999, BI6017B1_RECORD.REG_CEP);

            /*" -831- MOVE ZEROS TO REG-REGISTRO */
            _.Move(0, BI6017B1_RECORD.REG_REGISTRO);

            /*" -832- MOVE ZEROS TO REG-PRODUTO */
            _.Move(0, BI6017B1_RECORD.REG_PRODUTO);

            /*" -833- MOVE 9 TO REG-LINHANR */
            _.Move(9, BI6017B1_RECORD.REG_LINHANR);

            /*" -834- MOVE SF06-EOF TO REG-ATRIBUTOS */
            _.Move(IMPRESSAO_SAM.SF06_EOF, BI6017B1_RECORD.REG_ATRIBUTOS);

            /*" -838- WRITE BI6017B1-RECORD. */
            BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());

            /*" -838- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -851- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -860- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -863- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -864- DISPLAY 'BI6017B - SISTEMA CO NAO ESTA CADASTRADO' */
                _.Display($"BI6017B - SISTEMA CO NAO ESTA CADASTRADO");

                /*" -865- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                /*" -867- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -869- PERFORM R0300-00-OBTEM-NUMERACAO. */

            R0300_00_OBTEM_NUMERACAO_SECTION();

            /*" -870- MOVE RELATORI-NUM-COPIAS TO LR02-SEQ. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS, AREA_DE_WORK.LR02_LINHA02.LR02_SEQ);

            /*" -873- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -875- MOVE TAB-MES(WS-MES-SQL) TO LR02-MES */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR02_LINHA02.LR02_MES);

            /*" -876- MOVE WS-ANO-SQL TO LK-ANO-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -877- MOVE WS-MES-SQL TO LK-MES-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -879- MOVE WS-DIA-SQL TO LK-DIA-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

            /*" -881- PERFORM R0400-00-CALC-DIAS-UTEIS 1 TIMES. */

            for (int i = 0; i < 1; i++)
            {

                R0400_00_CALC_DIAS_UTEIS_SECTION();

            }

            /*" -882- MOVE LK-DIA-CALC TO WS-DIA-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -883- MOVE LK-MES-CALC TO WS-MES-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -884- MOVE LK-ANO-CALC TO WS-ANO-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC, AREA_DE_WORK.WS_DATA_I.WS_ANO_I);

            /*" -885- MOVE WS-DATA-I TO LR04-DATA LE01-DTPOSTAGEM. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LR04_LINHA04.LR04_DATA, AREA_DE_WORK.LE01_LINHA01.LE01_DTPOSTAGEM);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -860- EXEC SQL SELECT DATA_MOV_ABERTO, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-MESREFER, :SISTEMAS-ANOREFER FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_MESREFER, SISTEMAS_MESREFER);
                _.Move(executed_1.SISTEMAS_ANOREFER, SISTEMAS_ANOREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXA-CEP-SECTION */
        private void R0200_00_CARREGA_FAIXA_CEP_SECTION()
        {
            /*" -898- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -908- PERFORM R0200_00_CARREGA_FAIXA_CEP_DB_DECLARE_1 */

            R0200_00_CARREGA_FAIXA_CEP_DB_DECLARE_1();

            /*" -910- PERFORM R0200_00_CARREGA_FAIXA_CEP_DB_OPEN_1 */

            R0200_00_CARREGA_FAIXA_CEP_DB_OPEN_1();

            /*" -913- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -914- DISPLAY 'BI6017B - PROBLEMAS NO OPEN FAIXA_CEP' */
                _.Display($"BI6017B - PROBLEMAS NO OPEN FAIXA_CEP");

                /*" -916- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -917- PERFORM R0210-00-FETCH-FAIXACEP UNTIL WFIM-FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FAIXACEP == "S"))
            {

                R0210_00_FETCH_FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXA-CEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_FAIXA_CEP_DB_DECLARE_1()
        {
            /*" -908- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new BI6017B_CFAIXACEP(true);
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
        /*" R0200-00-CARREGA-FAIXA-CEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_FAIXA_CEP_DB_OPEN_1()
        {
            /*" -910- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-MOVDEBCC-DB-DECLARE-1 */
        public void R0900_00_DECLARE_MOVDEBCC_DB_DECLARE_1()
        {
            /*" -1091- EXEC SQL DECLARE MOVDEBCC CURSOR FOR SELECT NUM_APOLICE FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA = '3' AND DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND COD_CONVENIO = 6114 AND COD_RETORNO_CEF <> 0 END-EXEC. */
            MOVDEBCC = new BI6017B_MOVDEBCC(true);
            string GetQuery_MOVDEBCC()
            {
                var query = @$"SELECT NUM_APOLICE 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE SITUACAO_COBRANCA = '3' 
							AND DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND COD_CONVENIO = 6114 
							AND COD_RETORNO_CEF <> 0";

                return query;
            }
            MOVDEBCC.GetQueryEvent += GetQuery_MOVDEBCC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-SECTION */
        private void R0210_00_FETCH_FAIXACEP_SECTION()
        {
            /*" -928- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0210_10_FETCH */

            R0210_10_FETCH();

        }

        [StopWatch]
        /*" R0210-10-FETCH */
        private void R0210_10_FETCH(bool isPerform = false)
        {
            /*" -939- PERFORM R0210_10_FETCH_DB_FETCH_1 */

            R0210_10_FETCH_DB_FETCH_1();

            /*" -942- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -943- MOVE 'S' TO WFIM-FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_FAIXACEP);

                /*" -945- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -945- PERFORM R0210_10_FETCH_DB_CLOSE_1 */

                R0210_10_FETCH_DB_CLOSE_1();

                /*" -949- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -951- MOVE GEFAICEP-FAIXA TO TAB-FX-CEP-G (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FX_CEP_G);

            /*" -953- MOVE GEFAICEP-CEP-INICIAL TO TAB-FX-INI (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -955- MOVE GEFAICEP-CEP-FINAL TO TAB-FX-FIM (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -957- MOVE GEFAICEP-DESCRICAO-FAIXA TO TAB-FX-NOME (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -960- MOVE GEFAICEP-CENTRALIZADOR TO TAB-FX-CENTR (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -960- GO TO R0210-10-FETCH. */
            new Task(() => R0210_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-10-FETCH-DB-FETCH-1 */
        public void R0210_10_FETCH_DB_FETCH_1()
        {
            /*" -939- EXEC SQL FETCH CFAIXACEP INTO :GEFAICEP-FAIXA, :GEFAICEP-CEP-INICIAL, :GEFAICEP-CEP-FINAL, :GEFAICEP-DESCRICAO-FAIXA, :GEFAICEP-CENTRALIZADOR END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.GEFAICEP_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA);
                _.Move(CFAIXACEP.GEFAICEP_CEP_INICIAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL);
                _.Move(CFAIXACEP.GEFAICEP_CEP_FINAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL);
                _.Move(CFAIXACEP.GEFAICEP_DESCRICAO_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA);
                _.Move(CFAIXACEP.GEFAICEP_CENTRALIZADOR, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR);
            }

        }

        [StopWatch]
        /*" R0210-10-FETCH-DB-CLOSE-1 */
        public void R0210_10_FETCH_DB_CLOSE_1()
        {
            /*" -945- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-OBTEM-NUMERACAO-SECTION */
        private void R0300_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -973- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -974- DISPLAY 'DATA DO SISTEMA ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO SISTEMA {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -977- DISPLAY 'MES REFER =     ' SISTEMAS-MESREFER 'ANO REFER =     ' SISTEMAS-ANOREFER. */

            $"MES REFER =     {SISTEMAS_MESREFER}ANO REFER =     {SISTEMAS_ANOREFER}"
            .Display();

            /*" -984- PERFORM R0300_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R0300_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -988- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -989- MOVE ZEROS TO RELATORI-NUM-COPIAS */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                    /*" -990- ELSE */
                }
                else
                {


                    /*" -991- DISPLAY 'EM0600B - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"EM0600B - PROBLEMAS SELECT RELATORIOS");

                    /*" -993- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -994- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -996- MOVE ZEROS TO RELATORI-NUM-COPIAS. */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
            }


            /*" -996- DISPLAY ' NRCOPIAS = ' RELATORI-NUM-COPIAS. */
            _.Display($" NRCOPIAS = {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS}");

            /*" -0- FLUXCONTROL_PERFORM R0300_10_INCLUI_RELATORIO */

            R0300_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R0300-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R0300_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -984- EXEC SQL SELECT MAX(NUM_COPIAS) INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CARTAECT' AND MES_REFERENCIA = :SISTEMAS-MESREFER AND ANO_REFERENCIA = :SISTEMAS-ANOREFER END-EXEC. */

            var r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                SISTEMAS_MESREFER = SISTEMAS_MESREFER.ToString(),
                SISTEMAS_ANOREFER = SISTEMAS_ANOREFER.ToString(),
            };

            var executed_1 = R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R0300-10-INCLUI-RELATORIO */
        private void R0300_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -1002- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WABEND.WNR_EXEC_SQL);

            /*" -1002- ADD 1 TO RELATORI-NUM-COPIAS. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CALC-DIAS-UTEIS-SECTION */
        private void R0400_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -1069- MOVE LK-DATA-CALC TO LK-DATA-SOM. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_SOM);

            /*" -1069- CALL 'PROSOCU1' USING LK-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.LK_PROSOMU1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-MOVDEBCC-SECTION */
        private void R0900_00_DECLARE_MOVDEBCC_SECTION()
        {
            /*" -1082- MOVE '090' TO WNR-EXEC-SQL */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1084- DISPLAY 'INICIO DO DECLARE' */
            _.Display($"INICIO DO DECLARE");

            /*" -1091- PERFORM R0900_00_DECLARE_MOVDEBCC_DB_DECLARE_1 */

            R0900_00_DECLARE_MOVDEBCC_DB_DECLARE_1();

            /*" -1093- PERFORM R0900_00_DECLARE_MOVDEBCC_DB_OPEN_1 */

            R0900_00_DECLARE_MOVDEBCC_DB_OPEN_1();

            /*" -1096- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1097- DISPLAY 'BI6017B - ERRO NO OPEN (MOVDEBCC)' */
                _.Display($"BI6017B - ERRO NO OPEN (MOVDEBCC)");

                /*" -1099- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1099- DISPLAY 'FINAL  DO DECLARE' . */
            _.Display($"FINAL  DO DECLARE");

        }

        [StopWatch]
        /*" R0900-00-DECLARE-MOVDEBCC-DB-OPEN-1 */
        public void R0900_00_DECLARE_MOVDEBCC_DB_OPEN_1()
        {
            /*" -1093- EXEC SQL OPEN MOVDEBCC END-EXEC. */

            MOVDEBCC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-MOVDEBCC-SECTION */
        private void R0910_00_FETCH_MOVDEBCC_SECTION()
        {
            /*" -1112- MOVE '091' TO WNR-EXEC-SQL */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -1114- PERFORM R0910_00_FETCH_MOVDEBCC_DB_FETCH_1 */

            R0910_00_FETCH_MOVDEBCC_DB_FETCH_1();

            /*" -1117- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1118- MOVE 'S' TO WFIM-MOVDEBCC */
                _.Move("S", AREA_DE_WORK.WFIM_MOVDEBCC);

                /*" -1120- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -1120- PERFORM R0910_00_FETCH_MOVDEBCC_DB_CLOSE_1 */

                R0910_00_FETCH_MOVDEBCC_DB_CLOSE_1();

                /*" -1123- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1126- ADD 1 TO AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -1127- IF AC-CONTA > 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -1128- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1129- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1129- DISPLAY '**** LIDOS MOVDEBCC   ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS MOVDEBCC   {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-MOVDEBCC-DB-FETCH-1 */
        public void R0910_00_FETCH_MOVDEBCC_DB_FETCH_1()
        {
            /*" -1114- EXEC SQL FETCH MOVDEBCC INTO :MOVDEBCE-NUM-APOLICE END-EXEC. */

            if (MOVDEBCC.Fetch())
            {
                _.Move(MOVDEBCC.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-MOVDEBCC-DB-CLOSE-1 */
        public void R0910_00_FETCH_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -1120- EXEC SQL CLOSE MOVDEBCC END-EXEC */

            MOVDEBCC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1143- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1144- PERFORM R1100-00-SELECT-BILHETE */

            R1100_00_SELECT_BILHETE_SECTION();

            /*" -1145- IF WTEM-BILHETE EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_BILHETE == "N")
            {

                /*" -1146- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1148- ELSE */
            }
            else
            {


                /*" -1149- IF BILHETE-RAMO NOT EQUAL 72 AND 14 */

                if (!BILHETE.DCLBILHETE.BILHETE_RAMO.In("72", "14"))
                {

                    /*" -1151- GO TO R1000-10-NEXT. */

                    R1000_10_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1152- PERFORM R1200-00-SELECT-CLIENTES */

            R1200_00_SELECT_CLIENTES_SECTION();

            /*" -1153- IF WTEM-CLIENTE EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CLIENTE == "N")
            {

                /*" -1155- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1156- PERFORM R1300-00-SELECT-ENDERECOS */

            R1300_00_SELECT_ENDERECOS_SECTION();

            /*" -1157- IF WTEM-ENDERECO EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_ENDERECO == "N")
            {

                /*" -1159- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1160- PERFORM R1400-00-SELECT-FONTES */

            R1400_00_SELECT_FONTES_SECTION();

            /*" -1161- IF WTEM-FONTES EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_FONTES == "N")
            {

                /*" -1163- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1164- PERFORM R1500-00-SELECT-ENDOSSOS */

            R1500_00_SELECT_ENDOSSOS_SECTION();

            /*" -1165- IF WTEM-ENDOSSOS EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_ENDOSSOS == "N")
            {

                /*" -1167- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -1168- MOVE ENDERECO-ENDERECO TO SBI-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SBI6017B.SBI_ENDERECO);

            /*" -1169- MOVE ENDERECO-BAIRRO TO SBI-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SBI6017B.SBI_BAIRRO);

            /*" -1170- MOVE ENDERECO-CIDADE TO SBI-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SBI6017B.SBI_CIDADE);

            /*" -1171- MOVE ENDERECO-SIGLA-UF TO SBI-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SBI6017B.SBI_UF);

            /*" -1177- MOVE ENDERECO-CEP TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1178- MOVE WS-CEP-AUX TO SBI-CEP */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SBI6017B.SBI_NUM_CEP.SBI_CEP);

            /*" -1180- MOVE WS-CEP-COMPL-AUX TO SBI-CEP-COMPL. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SBI6017B.SBI_NUM_CEP.SBI_CEP_COMPL);

            /*" -1181- MOVE CLIENTES-NOME-RAZAO TO SBI-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SBI6017B.SBI_NOME_RAZAO);

            /*" -1182- MOVE BILHETE-NUM-BILHETE TO SBI-NUMBIL */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, REG_SBI6017B.SBI_NUMBIL);

            /*" -1184- MOVE APOLICES-COD-PRODUTO TO SBI-PRODUTO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, REG_SBI6017B.SBI_PRODUTO);

            /*" -1185- MOVE FONTES-NOME-FONTE TO WS-NOMEFTE */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, AREA_DE_WORK.WS_NOME_FONTE.WS_NOMEFTE);

            /*" -1186- MOVE WS-NOME-FONTE TO SBI-NOMEFTE */
            _.Move(AREA_DE_WORK.WS_NOME_FONTE, REG_SBI6017B.SBI_NOMEFTE);

            /*" -1187- MOVE FONTES-ENDERECO TO SBI-ENDERFTE */
            _.Move(FONTES.DCLFONTES.FONTES_ENDERECO, REG_SBI6017B.SBI_ENDERFTE);

            /*" -1188- MOVE FONTES-BAIRRO TO SBI-BAIRRO-FTE */
            _.Move(FONTES.DCLFONTES.FONTES_BAIRRO, REG_SBI6017B.SBI_BAIRRO_FTE);

            /*" -1189- MOVE FONTES-CIDADE TO SBI-CIDADE-FTE */
            _.Move(FONTES.DCLFONTES.FONTES_CIDADE, REG_SBI6017B.SBI_CIDADE_FTE);

            /*" -1190- MOVE FONTES-SIGLA-UF TO SBI-UF-FTE */
            _.Move(FONTES.DCLFONTES.FONTES_SIGLA_UF, REG_SBI6017B.SBI_UF_FTE);

            /*" -1192- MOVE FONTES-CEP TO WS-NUM-CEP-AUX. */
            _.Move(FONTES.DCLFONTES.FONTES_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1193- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -1194- MOVE WS-CEP-COMPL-AUX1 TO SBI-COMP-FTE */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SBI6017B.SBI_NUM_CEP_FTE.SBI_COMP_FTE);

                /*" -1195- MOVE WS-CEP-AUX1 TO SBI-CEP-FTE */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SBI6017B.SBI_NUM_CEP_FTE.SBI_CEP_FTE);

                /*" -1196- ELSE */
            }
            else
            {


                /*" -1197- MOVE WS-CEP-AUX TO SBI-CEP-FTE */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SBI6017B.SBI_NUM_CEP_FTE.SBI_CEP_FTE);

                /*" -1205- MOVE WS-CEP-COMPL-AUX TO SBI-COMP-FTE. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SBI6017B.SBI_NUM_CEP_FTE.SBI_COMP_FTE);
            }


            /*" -1206- MOVE SPACES TO SBI-NOME-CORREIO */
            _.Move("", REG_SBI6017B.SBI_NOME_CORREIO);

            /*" -1207- MOVE ENDOSSOS-DATA-INIVIGENCIA TO WWORK-DATA-DB2 */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, AREA_DE_WORK.WWORK_DATA_DB2);

            /*" -1208- MOVE WWORK-DIA-DB2 TO WWORK-DIA-VIG */
            _.Move(AREA_DE_WORK.FILLER_61.WWORK_DIA_DB2, AREA_DE_WORK.FILLER_64.WWORK_DIA_VIG);

            /*" -1209- MOVE ' DE ' TO WWORK-LITERA1 */
            _.Move(" DE ", AREA_DE_WORK.FILLER_64.WWORK_LITERA1);

            /*" -1210- MOVE TAB-MES(WWORK-MES-DB2) TO WWORK-MES-VIG */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.FILLER_61.WWORK_MES_DB2], AREA_DE_WORK.FILLER_64.WWORK_MES_VIG);

            /*" -1211- MOVE ' DE ' TO WWORK-LITERA2 */
            _.Move(" DE ", AREA_DE_WORK.FILLER_64.WWORK_LITERA2);

            /*" -1212- MOVE WWORK-ANO-DB2 TO WWORK-ANO-VIG */
            _.Move(AREA_DE_WORK.FILLER_61.WWORK_ANO_DB2, AREA_DE_WORK.FILLER_64.WWORK_ANO_VIG);

            /*" -1214- MOVE WWORK-DATA-VIG TO WWORK-INI-VIG */
            _.Move(AREA_DE_WORK.WWORK_DATA_VIG, AREA_DE_WORK.FILLER_65.WWORK_INI_VIG);

            /*" -1215- MOVE ENDOSSOS-DATA-TERVIGENCIA TO WWORK-DATA-DB2 */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, AREA_DE_WORK.WWORK_DATA_DB2);

            /*" -1216- MOVE WWORK-DIA-DB2 TO WWORK-DIA-VIG */
            _.Move(AREA_DE_WORK.FILLER_61.WWORK_DIA_DB2, AREA_DE_WORK.FILLER_64.WWORK_DIA_VIG);

            /*" -1217- MOVE TAB-MES(WWORK-MES-DB2) TO WWORK-MES-VIG */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.FILLER_61.WWORK_MES_DB2], AREA_DE_WORK.FILLER_64.WWORK_MES_VIG);

            /*" -1218- MOVE WWORK-ANO-DB2 TO WWORK-ANO-VIG */
            _.Move(AREA_DE_WORK.FILLER_61.WWORK_ANO_DB2, AREA_DE_WORK.FILLER_64.WWORK_ANO_VIG);

            /*" -1220- MOVE WWORK-DATA-VIG TO WWORK-TER-VIG */
            _.Move(AREA_DE_WORK.WWORK_DATA_VIG, AREA_DE_WORK.FILLER_65.WWORK_TER_VIG);

            /*" -1221- MOVE ' A ' TO WWORK-LITERA3 */
            _.Move(" A ", AREA_DE_WORK.FILLER_65.WWORK_LITERA3);

            /*" -1223- MOVE '.' TO WWORK-LITERA4 */
            _.Move(".", AREA_DE_WORK.FILLER_65.WWORK_LITERA4);

            /*" -1224- MOVE WWORK-VIGENCIA TO WW-INPUT */
            _.Move(AREA_DE_WORK.WWORK_VIGENCIA, AREA_DE_WORK.WW_INPUT);

            /*" -1225- PERFORM R1600-00-SUPRIME-BRANCOS */

            R1600_00_SUPRIME_BRANCOS_SECTION();

            /*" -1227- MOVE WW-OUTPUT TO SBI-VIGENCIA. */
            _.Move(AREA_DE_WORK.WW_OUTPUT, REG_SBI6017B.SBI_VIGENCIA);

            /*" -1227- RELEASE REG-SBI6017B. */
            SBI6017B.Release(REG_SBI6017B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1231- PERFORM R0910-00-FETCH-MOVDEBCC. */

            R0910_00_FETCH_MOVDEBCC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-BILHETE-SECTION */
        private void R1100_00_SELECT_BILHETE_SECTION()
        {
            /*" -1243- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -1245- MOVE 'S' TO WTEM-BILHETE. */
            _.Move("S", AREA_DE_WORK.WTEM_BILHETE);

            /*" -1247- MOVE MOVDEBCE-NUM-APOLICE TO BILHETE-NUM-BILHETE */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -1264- PERFORM R1100_00_SELECT_BILHETE_DB_SELECT_1 */

            R1100_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1268- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1273- MOVE 'N' TO WTEM-BILHETE */
                    _.Move("N", AREA_DE_WORK.WTEM_BILHETE);

                    /*" -1274- ELSE */
                }
                else
                {


                    /*" -1276- DISPLAY '*** BI6017B - PROBLEMAS NO ACESSO A BILHETE' */
                    _.Display($"*** BI6017B - PROBLEMAS NO ACESSO A BILHETE");

                    /*" -1277- DISPLAY 'BILHETE     ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE     {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1277- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R1100_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1264- EXEC SQL SELECT A.COD_CLIENTE , A.FONTE , A.RAMO , A.OCORR_ENDERECO, A.NUM_APOLICE, B.COD_PRODUTO INTO :BILHETE-COD-CLIENTE , :BILHETE-FONTE , :BILHETE-RAMO , :BILHETE-OCORR-ENDERECO, :BILHETE-NUM-APOLICE, :APOLICES-COD-PRODUTO FROM SEGUROS.BILHETE A, SEGUROS.APOLICES B WHERE A.NUM_BILHETE = :BILHETE-NUM-BILHETE AND A.NUM_APOLICE = B.NUM_APOLICE END-EXEC. */

            var r1100_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(executed_1.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-SECTION */
        private void R1200_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1289- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1291- MOVE 'S' TO WTEM-CLIENTE. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTE);

            /*" -1298- PERFORM R1200_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1200_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1302- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1308- MOVE 'N' TO WTEM-CLIENTE */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTE);

                    /*" -1309- ELSE */
                }
                else
                {


                    /*" -1311- DISPLAY '*** BI6017B - PROBLEMAS NO ACESSO A CLIENTES' */
                    _.Display($"*** BI6017B - PROBLEMAS NO ACESSO A CLIENTES");

                    /*" -1312- DISPLAY 'BILHETE     ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE     {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1313- DISPLAY 'CLIENTE     ' BILHETE-COD-CLIENTE */
                    _.Display($"CLIENTE     {BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE}");

                    /*" -1313- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1200_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1298- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :BILHETE-COD-CLIENTE END-EXEC. */

            var r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                BILHETE_COD_CLIENTE = BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECOS-SECTION */
        private void R1300_00_SELECT_ENDERECOS_SECTION()
        {
            /*" -1325- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1327- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDERECO);

            /*" -1341- PERFORM R1300_00_SELECT_ENDERECOS_DB_SELECT_1 */

            R1300_00_SELECT_ENDERECOS_DB_SELECT_1();

            /*" -1344- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1345- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1352- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                    /*" -1353- ELSE */
                }
                else
                {


                    /*" -1355- DISPLAY '*** BI6017B - PROBLEMAS NO ACESSO A ENDERECOS' */
                    _.Display($"*** BI6017B - PROBLEMAS NO ACESSO A ENDERECOS");

                    /*" -1356- DISPLAY 'BILHETE     ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE     {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1357- DISPLAY 'CLIENTE     ' BILHETE-COD-CLIENTE */
                    _.Display($"CLIENTE     {BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE}");

                    /*" -1358- DISPLAY 'OCORR ENDER ' BILHETE-OCORR-ENDERECO */
                    _.Display($"OCORR ENDER {BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO}");

                    /*" -1359- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1360- ELSE */
                }

            }
            else
            {


                /*" -1361- IF ENDERECO-CEP EQUAL ZEROS */

                if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
                {

                    /*" -1361- MOVE 'N' TO WTEM-ENDERECO. */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECOS-DB-SELECT-1 */
        public void R1300_00_SELECT_ENDERECOS_DB_SELECT_1()
        {
            /*" -1341- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :BILHETE-COD-CLIENTE AND OCORR_ENDERECO = :BILHETE-OCORR-ENDERECO END-EXEC. */

            var r1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 = new R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1()
            {
                BILHETE_OCORR_ENDERECO = BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO.ToString(),
                BILHETE_COD_CLIENTE = BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_ENDERECOS_DB_SELECT_1_Query1);
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
        /*" R1400-00-SELECT-FONTES-SECTION */
        private void R1400_00_SELECT_FONTES_SECTION()
        {
            /*" -1379- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -1381- MOVE 'S' TO WTEM-FONTES. */
            _.Move("S", AREA_DE_WORK.WTEM_FONTES);

            /*" -1396- PERFORM R1400_00_SELECT_FONTES_DB_SELECT_1 */

            R1400_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1399- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1400- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1406- MOVE 'N' TO WTEM-FONTES */
                    _.Move("N", AREA_DE_WORK.WTEM_FONTES);

                    /*" -1407- ELSE */
                }
                else
                {


                    /*" -1409- DISPLAY '*** BI6017B - PROBLEMAS NO ACESSO A FONTES' */
                    _.Display($"*** BI6017B - PROBLEMAS NO ACESSO A FONTES");

                    /*" -1410- DISPLAY 'BILHETE     ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE     {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1411- DISPLAY 'FONTE       ' BILHETE-FONTE */
                    _.Display($"FONTE       {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                    /*" -1411- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1400_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1396- EXEC SQL SELECT NOME_FONTE, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :FONTES-NOME-FONTE, :FONTES-ENDERECO, :FONTES-BAIRRO, :FONTES-CIDADE, :FONTES-SIGLA-UF, :FONTES-CEP FROM SEGUROS.FONTES WHERE COD_FONTE = :BILHETE-FONTE END-EXEC. */

            var r1400_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R1400_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
                _.Move(executed_1.FONTES_ENDERECO, FONTES.DCLFONTES.FONTES_ENDERECO);
                _.Move(executed_1.FONTES_BAIRRO, FONTES.DCLFONTES.FONTES_BAIRRO);
                _.Move(executed_1.FONTES_CIDADE, FONTES.DCLFONTES.FONTES_CIDADE);
                _.Move(executed_1.FONTES_SIGLA_UF, FONTES.DCLFONTES.FONTES_SIGLA_UF);
                _.Move(executed_1.FONTES_CEP, FONTES.DCLFONTES.FONTES_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-ENDOSSOS-SECTION */
        private void R1500_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1423- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1424- MOVE 'S' TO WTEM-ENDOSSOS. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDOSSOS);

            /*" -1426- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -1434- PERFORM R1500_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1500_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1438- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1444- MOVE 'N' TO WTEM-ENDOSSOS */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDOSSOS);

                    /*" -1445- ELSE */
                }
                else
                {


                    /*" -1447- DISPLAY '*** BI6017B - PROBLEMAS NO ACESSO A ENDOSSOS' */
                    _.Display($"*** BI6017B - PROBLEMAS NO ACESSO A ENDOSSOS");

                    /*" -1448- DISPLAY 'BILHETE     ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE     {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1449- DISPLAY 'APOLICE     ' BILHETE-NUM-APOLICE */
                    _.Display($"APOLICE     {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

                    /*" -1449- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1500_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1434- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SUPRIME-BRANCOS-SECTION */
        private void R1600_00_SUPRIME_BRANCOS_SECTION()
        {
            /*" -1461- MOVE SPACES TO WW-OUTPUT */
            _.Move("", AREA_DE_WORK.WW_OUTPUT);

            /*" -1462- SET WWO1 TO WZEROS. */
            WWO1.Value = AREA_DE_WORK.WZEROS;

            /*" -1462- SET WWI1 TO WZEROS. */
            WWI1.Value = AREA_DE_WORK.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM R1600_10_LOOP */

            R1600_10_LOOP();

        }

        [StopWatch]
        /*" R1600-10-LOOP */
        private void R1600_10_LOOP(bool isPerform = false)
        {
            /*" -1467- SET WWI1 UP BY +1 */
            WWI1.Value += +1;

            /*" -1468- IF WWI1 GREATER +50 */

            if (WWI1 > +50)
            {

                /*" -1470- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1471- IF WW-CCC-I(WWI1) NOT EQUAL SPACES */

            if (AREA_DE_WORK.FILLER_66[WWI1].WW_CCC_I != string.Empty)
            {

                /*" -1472- SET WWO1 UP BY +1 */
                WWO1.Value += +1;

                /*" -1473- MOVE WW-CCC-I(WWI1) TO WW-CCC-O(WWO1) */
                _.Move(AREA_DE_WORK.FILLER_66[WWI1].WW_CCC_I, AREA_DE_WORK.FILLER_67[WWO1].WW_CCC_O);

                /*" -1474- ELSE */
            }
            else
            {


                /*" -1475- MOVE WWI1 TO INDEX-AUX */
                _.Move(WWI1, INDEX_AUX);

                /*" -1476- SET INDEX-AUX UP BY +1 */
                INDEX_AUX.Value += +1;

                /*" -1478- IF WW-CCC-I(INDEX-AUX) EQUAL SPACES NEXT SENTENCE */

                if (AREA_DE_WORK.FILLER_66[INDEX_AUX].WW_CCC_I == string.Empty)
                {

                    /*" -1479- ELSE */
                }
                else
                {


                    /*" -1480- SET WWO1 UP BY +1 */
                    WWO1.Value += +1;

                    /*" -1482- MOVE WW-CCC-I(WWI1) TO WW-CCC-O(WWO1). */
                    _.Move(AREA_DE_WORK.FILLER_66[WWI1].WW_CCC_I, AREA_DE_WORK.FILLER_67[WWO1].WW_CCC_O);
                }

            }


            /*" -1482- GO TO R1600-10-LOOP. */
            new Task(() => R1600_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -1493- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -1498- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1501- DISPLAY '*** BI6017B CEP NAO ENCONTRADO ' BILHETE-NUM-BILHETE ' ' ENDERECO-CEP */

                $"*** BI6017B CEP NAO ENCONTRADO {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE} {ENDERECO.DCLENDERECOS.ENDERECO_CEP}"
                .Display();

                /*" -1502- MOVE 01 TO SBI-CEP-G */
                _.Move(01, REG_SBI6017B.SBI_CEP_G);

                /*" -1503- MOVE TAB-FAIXAS (01) TO SBI-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SBI6017B.SBI_NOME_CORREIO);

                /*" -1505- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1506- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -1508- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -1509- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -1511- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -1513- IF ENDERECO-CEP GREATER WS-INF AND ENDERECO-CEP LESS WS-SUP */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP > AREA_DE_WORK.WS_INF && ENDERECO.DCLENDERECOS.ENDERECO_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -1514- MOVE TAB-FX-CEP-G (WIND) TO SBI-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SBI6017B.SBI_CEP_G);

                /*" -1515- MOVE TAB-FAIXAS (WIND) TO SBI-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SBI6017B.SBI_NOME_CORREIO);

                /*" -1516- ELSE */
            }
            else
            {


                /*" -1517- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -1517- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1530- MOVE SBI-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SBI6017B.SBI_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -1531- MOVE SBI-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SBI6017B.SBI_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -1534- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -1535- MOVE TAB-FX-INI (SBI-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SBI6017B.SBI_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1536- MOVE WS-CEP-AUX TO LF03-FAIXA1. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF03_LINHA03.LF03_FAIXA1);

            /*" -1537- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA1C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF03_LINHA03.LF03_FAIXA1C);

            /*" -1538- MOVE TAB-FX-FIM (SBI-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SBI6017B.SBI_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1539- MOVE WS-CEP-AUX TO LF03-FAIXA2. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF03_LINHA03.LF03_FAIXA2);

            /*" -1542- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA2C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF03_LINHA03.LF03_FAIXA2C);

            /*" -1546- PERFORM R2100-00-PROCESSA-CEP UNTIL ((SBI-CEP-G NOT EQUAL WS-CEP-G-ANT) OR WFIM-SORT EQUAL 'S' ). */

            while (!(((REG_SBI6017B.SBI_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT) || AREA_DE_WORK.WFIM_SORT == "S")))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -1547- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARF);

            /*" -1547- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -1562- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -1567- PERFORM R2200-00-PROCESSA-FAC UNTIL ((SBI-CEP-G NOT EQUAL WS-CEP-G-ANT) OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199). */

            while (!(((REG_SBI6017B.SBI_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT) || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199)))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -1570- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR (WS-CEP-G-ANT). */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -1571- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -1572- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -1575- MOVE WS-AMARRADO TO TAB1-AMARI (WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -1576- MOVE WS-AMARRADO TO LF05-AMARRADO. */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF05_LINHA05.LF05_AMARRADO);

            /*" -1577- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -1578- MOVE WS-SEQ-INICIAL TO LF05-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF05_LINHA05.LF05_SEQ_INICIAL);

            /*" -1582- MOVE WS-SEQ TO LF05-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF05_LINHA05.LF05_SEQ_FINAL);

            /*" -1584- MOVE SPACES TO LF02-NOME-FAIXA. */
            _.Move("", AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA);

            /*" -1585- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -1587- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF02-NOME-FAIXA */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA);

                /*" -1588- ELSE */
            }
            else
            {


                /*" -1596- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF02-NOME-FAIXA. */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, AREA_DE_WORK.LF02_LINHA02.LF02_NOME_FAIXA);
            }


            /*" -1596- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -1612- MOVE ZEROS TO TABELA-REGISTROS. */
            _.Move(0, TABELA_REGISTROS);

            /*" -1618- PERFORM R2300-00-MONTA-LINHAS UNTIL ((SBI-CEP-G NOT EQUAL WS-CEP-G-ANT) OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 GREATER 199 OR WIND GREATER 1). */

            while (!(((REG_SBI6017B.SBI_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT) || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199 || AREA_DE_WORK.WIND > 1)))
            {

                R2300_00_MONTA_LINHAS_SECTION();
            }

            /*" -1620- PERFORM R2500-00-IMPRIME */

            R2500_00_IMPRIME_SECTION();

            /*" -1620- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-LINHAS-SECTION */
        private void R2300_00_MONTA_LINHAS_SECTION()
        {
            /*" -1632- ADD 1 TO WIND . */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1633- MOVE SBI-CEP TO TBI-CEP (WIND). */
            _.Move(REG_SBI6017B.SBI_NUM_CEP.SBI_CEP, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NUM_CEP.TBI_CEP);

            /*" -1634- MOVE SBI-CEP-COMPL TO TBI-CEP-COMPL (WIND). */
            _.Move(REG_SBI6017B.SBI_NUM_CEP.SBI_CEP_COMPL, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NUM_CEP.TBI_CEP_COMPL);

            /*" -1635- MOVE SBI-NOME-RAZAO TO TBI-NOME-RAZAO (WIND). */
            _.Move(REG_SBI6017B.SBI_NOME_RAZAO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NOME_RAZAO);

            /*" -1636- MOVE SBI-NUMBIL TO TBI-NUMBIL (WIND). */
            _.Move(REG_SBI6017B.SBI_NUMBIL, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NUMBIL);

            /*" -1637- MOVE SBI-PRODUTO TO TBI-PRODUTO (WIND). */
            _.Move(REG_SBI6017B.SBI_PRODUTO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_PRODUTO);

            /*" -1638- MOVE SBI-ENDERECO TO TBI-ENDERECO (WIND). */
            _.Move(REG_SBI6017B.SBI_ENDERECO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_ENDERECO);

            /*" -1639- MOVE SBI-BAIRRO TO TBI-BAIRRO (WIND). */
            _.Move(REG_SBI6017B.SBI_BAIRRO, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_BAIRRO);

            /*" -1640- MOVE SBI-CIDADE TO TBI-CIDADE (WIND). */
            _.Move(REG_SBI6017B.SBI_CIDADE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_CIDADE);

            /*" -1641- MOVE SBI-UF TO TBI-UF (WIND). */
            _.Move(REG_SBI6017B.SBI_UF, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_UF);

            /*" -1642- MOVE SBI-NOMEFTE TO TBI-NOMEFTE (WIND). */
            _.Move(REG_SBI6017B.SBI_NOMEFTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NOMEFTE);

            /*" -1643- MOVE SBI-ENDERFTE TO TBI-ENDERFTE (WIND). */
            _.Move(REG_SBI6017B.SBI_ENDERFTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_ENDERFTE);

            /*" -1644- MOVE SBI-BAIRRO-FTE TO TBI-BAIRRO-FTE (WIND). */
            _.Move(REG_SBI6017B.SBI_BAIRRO_FTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_BAIRRO_FTE);

            /*" -1645- MOVE SBI-CIDADE-FTE TO TBI-CIDADE-FTE (WIND). */
            _.Move(REG_SBI6017B.SBI_CIDADE_FTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_CIDADE_FTE);

            /*" -1646- MOVE SBI-UF-FTE TO TBI-UF-FTE (WIND). */
            _.Move(REG_SBI6017B.SBI_UF_FTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_UF_FTE);

            /*" -1647- MOVE SBI-CEP-FTE TO TBI-CEP-FTE (WIND). */
            _.Move(REG_SBI6017B.SBI_NUM_CEP_FTE.SBI_CEP_FTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NUM_CEP_FTE.TBI_CEP_FTE);

            /*" -1648- MOVE SBI-COMP-FTE TO TBI-COMP-FTE (WIND). */
            _.Move(REG_SBI6017B.SBI_NUM_CEP_FTE.SBI_COMP_FTE, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_NUM_CEP_FTE.TBI_COMP_FTE);

            /*" -1649- MOVE SBI-VIGENCIA TO TBI-VIGENCIA (WIND). */
            _.Move(REG_SBI6017B.SBI_VIGENCIA, TABELA_REGISTROS.TAB_REG[AREA_DE_WORK.WIND].TBI_VIGENCIA);

            /*" -1652- ADD 1 TO TAB1-QTD-OBJ (SBI-CEP-G) AC-QTD-OBJ WS-OBJ */
            TABELA_TOTAIS.TAB_TOTAIS[REG_SBI6017B.SBI_CEP_G].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[REG_SBI6017B.SBI_CEP_G].TAB1_QTD_OBJ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.WS_OBJ.Value = AREA_DE_WORK.WS_OBJ + 1;

            /*" -1653- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -1654- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -1656- MOVE WS-OBJ TO TAB1-OBJI (SBI-CEP-G) */
                _.Move(AREA_DE_WORK.WS_OBJ, TABELA_TOTAIS.TAB_TOTAIS[REG_SBI6017B.SBI_CEP_G].TAB1_OBJI);

                /*" -1657- END-IF */
            }


            /*" -1658- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -1659- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -1660- MOVE WS-SEQ TO WS-SEQ-INICIAL */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);

                /*" -1662- END-IF */
            }


            /*" -1662- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -1675- RETURN SBI6017B AT END */
            try
            {
                SBI6017B.Return(REG_SBI6017B, () =>
                {

                    /*" -1676- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -1678- GO TO R2400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1681- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -1682- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -1683- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1684- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -1684- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-IMPRIME-SECTION */
        private void R2500_00_IMPRIME_SECTION()
        {
            /*" -1698- MOVE SPACES TO LC02-NOME-RAZAO LC03-NOMEFTE */
            _.Move("", AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO, AREA_DE_WORK.LC03_LINHA03.LC03_NOMEFTE);

            /*" -1699- MOVE SPACES TO SF06-REGISTRO. */
            _.Move("", IMPRESSAO_SAM.SF06_REGISTRO);

            /*" -1710- MOVE '|' TO SF06-SEPARA-001 SF06-SEPARA-002 SF06-SEPARA-003 SF06-SEPARA-004 SF06-SEPARA-005 SF06-SEPARA-006 SF06-SEPARA-007 SF06-SEPARA-008 SF06-SEPARA-009 SF06-SEPARA-010 SF06-SEPARA-011 SF06-SEPARA-012 SF06-SEPARA-013 SF06-SEPARA-014 SF06-SEPARA-015 SF06-SEPARA-016 SF06-SEPARA-017 SF06-SEPARA-018. */
            _.Move("|", IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_001, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_002, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_003, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_004, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_005, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_006, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_007, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_008, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_009, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_010, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_011, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_012, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_013, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_014, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_015, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_016, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_017, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEPARA_018);

            /*" -1711- IF TAB-REG (1) NOT EQUAL ZEROS */

            if (TABELA_REGISTROS.TAB_REG[1] != 00)
            {

                /*" -1712- MOVE TBI-NUM-CEP-FTE(1) TO REG-NUMCEP */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP_FTE, BI6017B1_RECORD.REG_CEP.REG_NUMCEP);

                /*" -1713- MOVE TBI-COMP-FTE (1) TO REG-CMPCEP */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP_FTE.TBI_COMP_FTE, BI6017B1_RECORD.REG_CEP.REG_CMPCEP);

                /*" -1714- ADD 1 TO ACC-REGISTRO */
                IMPRESSAO_SAM.ACC_REGISTRO.Value = IMPRESSAO_SAM.ACC_REGISTRO + 1;

                /*" -1715- MOVE ACC-REGISTRO TO REG-REGISTRO */
                _.Move(IMPRESSAO_SAM.ACC_REGISTRO, BI6017B1_RECORD.REG_REGISTRO);

                /*" -1716- MOVE 5 TO REG-LINHANR */
                _.Move(5, BI6017B1_RECORD.REG_LINHANR);

                /*" -1717- MOVE TBI-PRODUTO (1) TO REG-PRODUTO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_PRODUTO, BI6017B1_RECORD.REG_PRODUTO);

                /*" -1718- MOVE SPACES TO REG-BRANCO */
                _.Move("", BI6017B1_RECORD.REG_BRANCO);

                /*" -1719- MOVE SPACES TO REG-ATRIBUTOS */
                _.Move("", BI6017B1_RECORD.REG_ATRIBUTOS);

                /*" -1720- MOVE TBI-NOME-RAZAO(1) TO WS-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NOME_RAZAO, AREA_DE_WORK.WS_NOME_RAZAO);

                /*" -1721- PERFORM R2900-00-FORMATA-NOME-RAZAO */

                R2900_00_FORMATA_NOME_RAZAO_SECTION();

                /*" -1722- MOVE WS-NOME-RAZAO TO LC02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO);

                /*" -1723- MOVE LC02-NOME-RAZAO TO SF06-SEGURADO */
                _.Move(AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEGURADO);

                /*" -1724- MOVE TBI-NUMBIL (1) TO LC02-NUMBIL */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUMBIL, AREA_DE_WORK.LC02_LINHA02.LC02_NUMBIL);

                /*" -1725- MOVE LC02-NUMBIL TO SF06-BILHETE */
                _.Move(AREA_DE_WORK.LC02_LINHA02.LC02_NUMBIL, IMPRESSAO_SAM.SF06_REGISTRO.SF06_BILHETE);

                /*" -1726- MOVE TBI-NOMEFTE (1) TO LC03-NOMEFTE */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NOMEFTE, AREA_DE_WORK.LC03_LINHA03.LC03_NOMEFTE);

                /*" -1727- MOVE LC03-NOMEFTE TO SF06-REMETENTE */
                _.Move(AREA_DE_WORK.LC03_LINHA03.LC03_NOMEFTE, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REMETENTE);

                /*" -1728- MOVE TBI-NOMEFTE (1) TO LE02-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NOMEFTE, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1729- MOVE TBI-NUM-CEP-FTE(1) TO LE05-CEP-NRO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP_FTE, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_NRO);

                /*" -1730- MOVE TBI-COMP-FTE (1) TO LE05-CEP-COMPL */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP_FTE.TBI_COMP_FTE, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_COMPL);

                /*" -1731- MOVE LE05-CEP TO SF06-REM-CEP */
                _.Move(AREA_DE_WORK.LE05_LINHA05.LE05_CEP, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_CEP);

                /*" -1732- MOVE TBI-ENDERFTE (1) TO LE03-ENDERECO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_ENDERFTE, AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO);

                /*" -1733- MOVE LE03-ENDERECO TO SF06-REM-ENDEREC */
                _.Move(AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_ENDEREC);

                /*" -1734- MOVE TBI-CIDADE-FTE (1) TO LE04-CIDADE */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_CIDADE_FTE, AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE);

                /*" -1735- MOVE LE04-CIDADE TO SF06-REM-CIDADE */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_CIDADE);

                /*" -1736- MOVE TBI-BAIRRO-FTE (1) TO LE04-BAIRRO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_BAIRRO_FTE, AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO);

                /*" -1737- MOVE LE04-BAIRRO TO SF06-REM-BAIRRO */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_BAIRRO);

                /*" -1738- MOVE TBI-UF-FTE (1) TO LE04-UF */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_UF_FTE, AREA_DE_WORK.LE04_LINHA04.LE04_UF);

                /*" -1739- MOVE LE04-UF TO SF06-REM-ESTADO */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_UF, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_ESTADO);

                /*" -1740- MOVE TBI-NOME-RAZAO(1) TO LE02-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1741- MOVE LE02-NOME-RAZAO TO SF06-DESTINATAR */
                _.Move(AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_DESTINATAR);

                /*" -1742- MOVE TBI-CEP (1) TO LE05-CEP-NRO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP.TBI_CEP, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_NRO);

                /*" -1743- MOVE TBI-CEP-COMPL (1) TO LE05-CEP-COMPL */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP.TBI_CEP_COMPL, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_COMPL);

                /*" -1744- MOVE LE05-CEP TO SF06-CEP */
                _.Move(AREA_DE_WORK.LE05_LINHA05.LE05_CEP, IMPRESSAO_SAM.SF06_REGISTRO.SF06_CEP);

                /*" -1745- MOVE TBI-ENDERECO (1) TO LE03-ENDERECO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_ENDERECO, AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO);

                /*" -1746- MOVE LE03-ENDERECO TO SF06-ENDERECO */
                _.Move(AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_ENDERECO);

                /*" -1747- MOVE TBI-CIDADE (1) TO LE04-CIDADE */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_CIDADE, AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE);

                /*" -1748- MOVE LE04-CIDADE TO SF06-CIDADE */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE, IMPRESSAO_SAM.SF06_REGISTRO.SF06_CIDADE);

                /*" -1749- MOVE TBI-BAIRRO (1) TO LE04-BAIRRO */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_BAIRRO, AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO);

                /*" -1750- MOVE LE04-BAIRRO TO SF06-BAIRRO */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_BAIRRO);

                /*" -1751- MOVE TBI-UF (1) TO LE04-UF */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_UF, AREA_DE_WORK.LE04_LINHA04.LE04_UF);

                /*" -1752- MOVE LE04-UF TO SF06-UF */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_UF, IMPRESSAO_SAM.SF06_REGISTRO.SF06_UF);

                /*" -1753- MOVE TBI-VIGENCIA (1) TO SF06-VIGENCIA */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_VIGENCIA, IMPRESSAO_SAM.SF06_REGISTRO.SF06_VIGENCIA);

                /*" -1754- MOVE 'XXX.XXX' TO LE01-SEQUENCIA */
                _.Move("XXX.XXX", AREA_DE_WORK.LE01_LINHA01.LE01_SEQUENCIA);

                /*" -1755- MOVE LE01-SEQUENCIA TO SF06-NUMOBJETO */
                _.Move(AREA_DE_WORK.LE01_LINHA01.LE01_SEQUENCIA, IMPRESSAO_SAM.SF06_REGISTRO.SF06_NUMOBJETO);

                /*" -1756- MOVE 'XX/XX/XXXX' TO SF06-DPOSTAGEM */
                _.Move("XX/XX/XXXX", IMPRESSAO_SAM.SF06_REGISTRO.SF06_DPOSTAGEM);

                /*" -1757- MOVE ALL '@' TO SF06-CODIGO-CIF */
                _.MoveAll("@", IMPRESSAO_SAM.SF06_REGISTRO.SF06_CODIGO_CIF);

                /*" -1758- MOVE ALL '#' TO SF06-POSTNET */
                _.MoveAll("#", IMPRESSAO_SAM.SF06_REGISTRO.SF06_POSTNET);

                /*" -1759- ADD 1 TO AC-CONTA */
                AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

                /*" -1760- ADD 1 TO AC-IMPRESSOS */
                AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

                /*" -1761- MOVE SF06-REGISTRO TO REG-ATRIBUTOS */
                _.Move(IMPRESSAO_SAM.SF06_REGISTRO, BI6017B1_RECORD.REG_ATRIBUTOS);

                /*" -1762- MOVE TBI-CEP (1) TO WORK-CEP-NUM */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP.TBI_CEP, AREA_DE_WORK.FILLER_58.WORK_CEP_NUM);

                /*" -1763- MOVE TBI-CEP-COMPL (1) TO WORK-CEP-CPL */
                _.Move(TABELA_REGISTROS.TAB_REG[1].TBI_NUM_CEP.TBI_CEP_COMPL, AREA_DE_WORK.FILLER_58.WORK_CEP_CPL);

                /*" -1764- PERFORM R9900-00-GRAVA-OBJETO */

                R9900_00_GRAVA_OBJETO_SECTION();

                /*" -1766- WRITE BI6017B1-RECORD. */
                BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());
            }


            /*" -1767- IF TAB-REG (2) NOT EQUAL ZEROS */

            if (TABELA_REGISTROS.TAB_REG[2] != 00)
            {

                /*" -1768- MOVE TBI-NUM-CEP-FTE(2) TO REG-NUMCEP */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP_FTE, BI6017B1_RECORD.REG_CEP.REG_NUMCEP);

                /*" -1769- MOVE TBI-COMP-FTE (2) TO REG-CMPCEP */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP_FTE.TBI_COMP_FTE, BI6017B1_RECORD.REG_CEP.REG_CMPCEP);

                /*" -1770- ADD 1 TO ACC-REGISTRO */
                IMPRESSAO_SAM.ACC_REGISTRO.Value = IMPRESSAO_SAM.ACC_REGISTRO + 1;

                /*" -1771- MOVE ACC-REGISTRO TO REG-REGISTRO */
                _.Move(IMPRESSAO_SAM.ACC_REGISTRO, BI6017B1_RECORD.REG_REGISTRO);

                /*" -1772- MOVE 5 TO REG-LINHANR */
                _.Move(5, BI6017B1_RECORD.REG_LINHANR);

                /*" -1773- MOVE TBI-PRODUTO (2) TO REG-PRODUTO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_PRODUTO, BI6017B1_RECORD.REG_PRODUTO);

                /*" -1774- MOVE SPACES TO REG-BRANCO */
                _.Move("", BI6017B1_RECORD.REG_BRANCO);

                /*" -1775- MOVE SPACES TO REG-ATRIBUTOS */
                _.Move("", BI6017B1_RECORD.REG_ATRIBUTOS);

                /*" -1776- MOVE TBI-NOME-RAZAO(2) TO WS-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NOME_RAZAO, AREA_DE_WORK.WS_NOME_RAZAO);

                /*" -1777- PERFORM R2900-00-FORMATA-NOME-RAZAO */

                R2900_00_FORMATA_NOME_RAZAO_SECTION();

                /*" -1778- MOVE WS-NOME-RAZAO TO LC02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO);

                /*" -1779- MOVE LC02-NOME-RAZAO TO SF06-SEGURADO */
                _.Move(AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_SEGURADO);

                /*" -1780- MOVE TBI-NUMBIL (2) TO LC02-NUMBIL */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUMBIL, AREA_DE_WORK.LC02_LINHA02.LC02_NUMBIL);

                /*" -1781- MOVE LC02-NUMBIL TO SF06-BILHETE */
                _.Move(AREA_DE_WORK.LC02_LINHA02.LC02_NUMBIL, IMPRESSAO_SAM.SF06_REGISTRO.SF06_BILHETE);

                /*" -1782- MOVE TBI-NOMEFTE (2) TO LC03-NOMEFTE */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NOMEFTE, AREA_DE_WORK.LC03_LINHA03.LC03_NOMEFTE);

                /*" -1783- MOVE LC03-NOMEFTE TO SF06-REMETENTE */
                _.Move(AREA_DE_WORK.LC03_LINHA03.LC03_NOMEFTE, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REMETENTE);

                /*" -1784- MOVE TBI-NOMEFTE (2) TO LE02-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NOMEFTE, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1785- MOVE TBI-NUM-CEP-FTE(2) TO LE05-CEP-NRO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP_FTE, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_NRO);

                /*" -1786- MOVE TBI-COMP-FTE (2) TO LE05-CEP-COMPL */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP_FTE.TBI_COMP_FTE, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_COMPL);

                /*" -1787- MOVE LE05-CEP TO SF06-REM-CEP */
                _.Move(AREA_DE_WORK.LE05_LINHA05.LE05_CEP, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_CEP);

                /*" -1788- MOVE TBI-ENDERFTE (2) TO LE03-ENDERECO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_ENDERFTE, AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO);

                /*" -1789- MOVE LE03-ENDERECO TO SF06-REM-ENDEREC */
                _.Move(AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_ENDEREC);

                /*" -1790- MOVE TBI-CIDADE-FTE (2) TO LE04-CIDADE */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_CIDADE_FTE, AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE);

                /*" -1791- MOVE LE04-CIDADE TO SF06-REM-CIDADE */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_CIDADE);

                /*" -1792- MOVE TBI-BAIRRO-FTE (2) TO LE04-BAIRRO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_BAIRRO_FTE, AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO);

                /*" -1793- MOVE LE04-BAIRRO TO SF06-REM-BAIRRO */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_BAIRRO);

                /*" -1794- MOVE TBI-UF-FTE (2) TO LE04-UF */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_UF_FTE, AREA_DE_WORK.LE04_LINHA04.LE04_UF);

                /*" -1795- MOVE LE04-UF TO SF06-REM-ESTADO */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_UF, IMPRESSAO_SAM.SF06_REGISTRO.SF06_REM_ESTADO);

                /*" -1796- MOVE TBI-NOME-RAZAO(2) TO LE02-NOME-RAZAO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1797- MOVE LE02-NOME-RAZAO TO SF06-DESTINATAR */
                _.Move(AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_DESTINATAR);

                /*" -1798- MOVE TBI-CEP (2) TO LE05-CEP-NRO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP.TBI_CEP, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_NRO);

                /*" -1799- MOVE TBI-CEP-COMPL (2) TO LE05-CEP-COMPL */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP.TBI_CEP_COMPL, AREA_DE_WORK.LE05_LINHA05.LE05_CEP.LE05_CEP_COMPL);

                /*" -1800- MOVE LE05-CEP TO SF06-CEP */
                _.Move(AREA_DE_WORK.LE05_LINHA05.LE05_CEP, IMPRESSAO_SAM.SF06_REGISTRO.SF06_CEP);

                /*" -1801- MOVE TBI-ENDERECO (2) TO LE03-ENDERECO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_ENDERECO, AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO);

                /*" -1802- MOVE LE03-ENDERECO TO SF06-ENDERECO */
                _.Move(AREA_DE_WORK.LE03_LINHA03.LE03_ENDERECO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_ENDERECO);

                /*" -1803- MOVE TBI-CIDADE (2) TO LE04-CIDADE */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_CIDADE, AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE);

                /*" -1804- MOVE LE04-CIDADE TO SF06-CIDADE */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_CIDADE, IMPRESSAO_SAM.SF06_REGISTRO.SF06_CIDADE);

                /*" -1805- MOVE TBI-BAIRRO (2) TO LE04-BAIRRO */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_BAIRRO, AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO);

                /*" -1806- MOVE LE04-BAIRRO TO SF06-BAIRRO */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_BAIRRO, IMPRESSAO_SAM.SF06_REGISTRO.SF06_BAIRRO);

                /*" -1807- MOVE TBI-UF (2) TO LE04-UF */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_UF, AREA_DE_WORK.LE04_LINHA04.LE04_UF);

                /*" -1808- MOVE LE04-UF TO SF06-UF */
                _.Move(AREA_DE_WORK.LE04_LINHA04.LE04_UF, IMPRESSAO_SAM.SF06_REGISTRO.SF06_UF);

                /*" -1809- MOVE TBI-VIGENCIA (2) TO SF06-VIGENCIA */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_VIGENCIA, IMPRESSAO_SAM.SF06_REGISTRO.SF06_VIGENCIA);

                /*" -1810- MOVE 'XXX.XXX' TO LE01-SEQUENCIA */
                _.Move("XXX.XXX", AREA_DE_WORK.LE01_LINHA01.LE01_SEQUENCIA);

                /*" -1811- MOVE LE01-SEQUENCIA TO SF06-NUMOBJETO */
                _.Move(AREA_DE_WORK.LE01_LINHA01.LE01_SEQUENCIA, IMPRESSAO_SAM.SF06_REGISTRO.SF06_NUMOBJETO);

                /*" -1812- MOVE 'XX/XX/XXXX' TO SF06-DPOSTAGEM */
                _.Move("XX/XX/XXXX", IMPRESSAO_SAM.SF06_REGISTRO.SF06_DPOSTAGEM);

                /*" -1813- MOVE ALL '@' TO SF06-CODIGO-CIF */
                _.MoveAll("@", IMPRESSAO_SAM.SF06_REGISTRO.SF06_CODIGO_CIF);

                /*" -1814- MOVE ALL '#' TO SF06-POSTNET */
                _.MoveAll("#", IMPRESSAO_SAM.SF06_REGISTRO.SF06_POSTNET);

                /*" -1815- ADD 1 TO AC-CONTA */
                AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

                /*" -1816- ADD 1 TO AC-IMPRESSOS */
                AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

                /*" -1817- MOVE SF06-REGISTRO TO REG-ATRIBUTOS */
                _.Move(IMPRESSAO_SAM.SF06_REGISTRO, BI6017B1_RECORD.REG_ATRIBUTOS);

                /*" -1818- MOVE TBI-CEP (2) TO WORK-CEP-NUM */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP.TBI_CEP, AREA_DE_WORK.FILLER_58.WORK_CEP_NUM);

                /*" -1819- MOVE TBI-CEP-COMPL (2) TO WORK-CEP-CPL */
                _.Move(TABELA_REGISTROS.TAB_REG[2].TBI_NUM_CEP.TBI_CEP_COMPL, AREA_DE_WORK.FILLER_58.WORK_CEP_CPL);

                /*" -1820- PERFORM R9900-00-GRAVA-OBJETO */

                R9900_00_GRAVA_OBJETO_SECTION();

                /*" -1820- WRITE BI6017B1-RECORD. */
                BI6017B1.Write(BI6017B1_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-FORMATA-NOME-RAZAO-SECTION */
        private void R2900_00_FORMATA_NOME_RAZAO_SECTION()
        {
            /*" -1832- IF WS-LETRA-NOME(40) NOT EQUAL SPACES */

            if (AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[40] != string.Empty)
            {

                /*" -1833- MOVE ',' TO WS-LETRA-NOME(41) */
                _.Move(",", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[41]);

                /*" -1834- MOVE WS-NOME-RAZAO TO LC02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO);

                /*" -1835- MOVE ' ' TO WS-LETRA-NOME(41) */
                _.Move(" ", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[41]);

                /*" -1836- MOVE WS-NOME-RAZAO TO LE02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1838- GO TO R2900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1838- MOVE 40 TO WIND1. */
            _.Move(40, AREA_DE_WORK.WIND1);

            /*" -0- FLUXCONTROL_PERFORM R2900_10_LOOP */

            R2900_10_LOOP();

        }

        [StopWatch]
        /*" R2900-10-LOOP */
        private void R2900_10_LOOP(bool isPerform = false)
        {
            /*" -1844- SUBTRACT 1 FROM WIND1. */
            AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 - 1;

            /*" -1845- IF WIND1 LESS 1 */

            if (AREA_DE_WORK.WIND1 < 1)
            {

                /*" -1847- MOVE SPACES TO LC02-NOME-RAZAO LE02-NOME-RAZAO */
                _.Move("", AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1849- GO TO R2900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1850- IF WS-LETRA-NOME(WIND1) NOT EQUAL SPACES */

            if (AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1] != string.Empty)
            {

                /*" -1851- ADD 1 TO WIND1 */
                AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                /*" -1852- MOVE ',' TO WS-LETRA-NOME(WIND1) */
                _.Move(",", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1]);

                /*" -1853- MOVE WS-NOME-RAZAO TO LC02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LC02_LINHA02.LC02_NOME_RAZAO);

                /*" -1854- MOVE ' ' TO WS-LETRA-NOME(WIND1) */
                _.Move(" ", AREA_DE_WORK.WS_NOME_RAZAO.WS_LETRA_NOME[AREA_DE_WORK.WIND1]);

                /*" -1855- MOVE WS-NOME-RAZAO TO LE02-NOME-RAZAO */
                _.Move(AREA_DE_WORK.WS_NOME_RAZAO, AREA_DE_WORK.LE02_LINHA02.LE02_NOME_RAZAO);

                /*" -1857- GO TO R2900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1857- GO TO R2900-10-LOOP. */
            new Task(() => R2900_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -1868- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -1873- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1874- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -1875- WRITE BI6017B2-RECORD FROM LR01-LINHA01 */
                _.Move(AREA_DE_WORK.LR01_LINHA01.GetMoveValues(), BI6017B2_RECORD);

                BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

                /*" -1877- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -1878- IF TAB1-QTD-OBJ (WIND) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ != 00)
            {

                /*" -1880- ADD 1 TO WS-OCORR. */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;
            }


            /*" -1881- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1881- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -1886- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -1887- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -1889- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -1889- MOVE WWORK-QTDE11 TO LR02-PAG-FINAL. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR02_LINHA02.LR02_PAG_FINAL);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -1914- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1915- WRITE BI6017B2-RECORD FROM LC99-LINHA99 */
                _.Move(AREA_DE_WORK.LC99_LINHA99.GetMoveValues(), BI6017B2_RECORD);

                BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

                /*" -1916- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -1918- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1919- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -1920- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -1922- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1923- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -1924- MOVE AC-PAGINA TO LR02-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR02_LINHA02.LR02_PAGINA);

            /*" -1925- WRITE BI6017B2-RECORD FROM LR02-LINHA02. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.GetMoveValues(), BI6017B2_RECORD);

            BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

            /*" -1926- WRITE BI6017B2-RECORD FROM LR03-LINHA03. */
            _.Move(AREA_DE_WORK.LR03_LINHA03.GetMoveValues(), BI6017B2_RECORD);

            BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

            /*" -1927- WRITE BI6017B2-RECORD FROM LR04-LINHA04. */
            _.Move(AREA_DE_WORK.LR04_LINHA04.GetMoveValues(), BI6017B2_RECORD);

            BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

            /*" -1929- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -1930- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1931- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_CEPI);

            /*" -1932- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_COMPL_CEPI);

            /*" -1933- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1934- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_CEPF);

            /*" -1935- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR05_LINHA05.LR05_COMPL_CEPF);

            /*" -1936- MOVE TAB1-OBJI (WIND) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR05_LINHA05.LR05_OBJI);

            /*" -1937- MOVE TAB1-OBJF (WIND) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR05_LINHA05.LR05_OBJF);

            /*" -1938- MOVE TAB1-AMARI (WIND) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR05_LINHA05.LR05_AMARI);

            /*" -1939- MOVE TAB1-AMARF (WIND) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR05_LINHA05.LR05_AMARF);

            /*" -1940- MOVE TAB1-QTD-OBJ (WIND) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR05_LINHA05.LR05_QTD_OBJ);

            /*" -1941- MOVE TAB1-QTD-AMAR(WIND) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR05_LINHA05.LR05_QTD_AMAR);

            /*" -1942- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR05_LINHA05.LR05_OBS);

            /*" -1942- WRITE BI6017B2-RECORD FROM LR05-LINHA05. */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), BI6017B2_RECORD);

            BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -1948- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1949- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -1950- WRITE BI6017B2-RECORD FROM LC99-LINHA99 */
                _.Move(AREA_DE_WORK.LC99_LINHA99.GetMoveValues(), BI6017B2_RECORD);

                BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

                /*" -1951- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -1953- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1954- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -1956- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1957- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1958- MOVE WS-CEP-AUX TO LR06-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_CEPI);

            /*" -1959- MOVE WS-CEP-COMPL-AUX TO LR06-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_COMPL_CEPI);

            /*" -1960- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -1961- MOVE WS-CEP-AUX TO LR06-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_CEPF);

            /*" -1962- MOVE WS-CEP-COMPL-AUX TO LR06-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR06_LINHA06.LR06_COMPL_CEPF);

            /*" -1963- MOVE TAB1-OBJI (WIND) TO LR06-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR06_LINHA06.LR06_OBJI);

            /*" -1964- MOVE TAB1-OBJF (WIND) TO LR06-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR06_LINHA06.LR06_OBJF);

            /*" -1965- MOVE TAB1-AMARI (WIND) TO LR06-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR06_LINHA06.LR06_AMARI);

            /*" -1966- MOVE TAB1-AMARF (WIND) TO LR06-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR06_LINHA06.LR06_AMARF);

            /*" -1967- MOVE TAB1-QTD-OBJ (WIND) TO LR06-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR06_LINHA06.LR06_QTD_OBJ);

            /*" -1968- MOVE TAB1-QTD-AMAR(WIND) TO LR06-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR06_LINHA06.LR06_QTD_AMAR);

            /*" -1969- MOVE SPACES TO LR06-OBS. */
            _.Move("", AREA_DE_WORK.LR06_LINHA06.LR06_OBS);

            /*" -1970- WRITE BI6017B2-RECORD FROM LR06-LINHA06. */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), BI6017B2_RECORD);

            BI6017B2.Write(BI6017B2_RECORD.GetMoveValues().ToString());

            /*" -1972- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -1973- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -1974- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -1975- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -1976- ELSE */
            }
            else
            {


                /*" -1976- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -1988- OPEN OUTPUT BI6017B1. */
            BI6017B1.Open(BI6017B1_RECORD);

            /*" -1988- OPEN OUTPUT BI6017B2. */
            BI6017B2.Open(BI6017B2_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -2000- CLOSE BI6017B1. */
            BI6017B1.Close();

            /*" -2000- CLOSE BI6017B2. */
            BI6017B2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9800_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2014- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2015- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2016- DISPLAY '*   BI6017B - CARTA AVISO DE CANCELAMENTO  *' */
            _.Display($"*   BI6017B - CARTA AVISO DE CANCELAMENTO  *");

            /*" -2017- DISPLAY '*   -------   ----- ----- -- ------------  *' */
            _.Display($"*   -------   ----- ----- -- ------------  *");

            /*" -2018- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2019- DISPLAY '*   NAO HOUVE MOVIMENTACAO PARA EMISSAO DE *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO PARA EMISSAO DE *");

            /*" -2020- DISPLAY '*   CARTA AVISO DE CANCELAMENTO.           *' */
            _.Display($"*   CARTA AVISO DE CANCELAMENTO.           *");

            /*" -2021- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2021- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-GRAVA-OBJETO-SECTION */
        private void R9900_00_GRAVA_OBJETO_SECTION()
        {
            /*" -2033- MOVE 'SF06' TO GEOBJECT-COD-FORMULARIO. */
            _.Move("SF06", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -2043- PERFORM R9900_00_GRAVA_OBJETO_DB_SELECT_1 */

            R9900_00_GRAVA_OBJETO_DB_SELECT_1();

            /*" -2046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2047- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2048- PERFORM R9900-01-MONTA-HEADER */

                    R9900_01_MONTA_HEADER_SECTION();

                    /*" -2049- PERFORM R9900-03-INSERT-OBJETO */

                    R9900_03_INSERT_OBJETO_SECTION();

                    /*" -2050- ELSE */
                }
                else
                {


                    /*" -2051- DISPLAY 'ERRO DE ACESSO A TABELA GE_OBJETO_ECT.' */
                    _.Display($"ERRO DE ACESSO A TABELA GE_OBJETO_ECT.");

                    /*" -2052- DISPLAY 'SQLCODE............... ' SQLCODE */
                    _.Display($"SQLCODE............... {DB.SQLCODE}");

                    /*" -2054- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2055- PERFORM R9900-02-MONTA-DETALHE */

            R9900_02_MONTA_DETALHE_SECTION();

            /*" -2055- PERFORM R9900-03-INSERT-OBJETO. */

            R9900_03_INSERT_OBJETO_SECTION();

        }

        [StopWatch]
        /*" R9900-00-GRAVA-OBJETO-DB-SELECT-1 */
        public void R9900_00_GRAVA_OBJETO_DB_SELECT_1()
        {
            /*" -2043- EXEC SQL SELECT DISTINCT STA_REGISTRO INTO :GEOBJECT-STA-REGISTRO FROM SEGUROS.GE_OBJETO_ECT WHERE NUM_CEP = 0 AND NOM_PROGRAMA = 'BI6017B' AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO AND STA_REGISTRO = 'H' AND DATE(DTH_TIMESTAMP) <> '9999-12-31' ORDER BY STA_REGISTRO END-EXEC. */

            var r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 = new R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1()
            {
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
            };

            var executed_1 = R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1.Execute(r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOBJECT_STA_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9900-01-MONTA-HEADER-SECTION */
        private void R9900_01_MONTA_HEADER_SECTION()
        {
            /*" -2063- MOVE 0 TO GEOBJECT-NUM-CEP */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -2064- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
            _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -2065- MOVE -1 TO VIND-PRODUTO */
            _.Move(-1, VIND_PRODUTO);

            /*" -2066- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -2067- MOVE 0 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -2068- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -2069- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -2070- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -2070- MOVE SF06-HEADER TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(IMPRESSAO_SAM.SF06_HEADER, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_01_SAIDA*/

        [StopWatch]
        /*" R9900-02-MONTA-DETALHE-SECTION */
        private void R9900_02_MONTA_DETALHE_SECTION()
        {
            /*" -2078- MOVE WORK-CEP TO GEOBJECT-NUM-CEP */
            _.Move(AREA_DE_WORK.WORK_CEP, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -2079- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -2080- MOVE REG-PRODUTO TO GEOBJECT-COD-PRODUTO */
            _.Move(BI6017B1_RECORD.REG_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -2081- MOVE ZEROS TO VIND-PRODUTO */
            _.Move(0, VIND_PRODUTO);

            /*" -2082- MOVE 0 TO GEOBJECT-NUM-INI-POS-VERSO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO);

            /*" -2083- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -2084- MOVE 0 TO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -2085- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
            _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

            /*" -2086- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN. */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -2086- MOVE SF06-REGISTRO TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(IMPRESSAO_SAM.SF06_REGISTRO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_02_SAIDA*/

        [StopWatch]
        /*" R9900-03-INSERT-OBJETO-SECTION */
        private void R9900_03_INSERT_OBJETO_SECTION()
        {
            /*" -2106- PERFORM R9900_03_INSERT_OBJETO_DB_INSERT_1 */

            R9900_03_INSERT_OBJETO_DB_INSERT_1();

            /*" -2109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2110- DISPLAY 'ERRO NO INSERT DA GE-OBJETO-ECT ' */
                _.Display($"ERRO NO INSERT DA GE-OBJETO-ECT ");

                /*" -2112- DISPLAY 'H = HEADER D = DETALHE.' GEOBJECT-STA-REGISTRO */
                _.Display($"H = HEADER D = DETALHE.{GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}");

                /*" -2113- DISPLAY 'PROGRAMA BI6017B.......' */
                _.Display($"PROGRAMA BI6017B.......");

                /*" -2115- DISPLAY 'FORMULARIO............ ' GEOBJECT-COD-FORMULARIO */
                _.Display($"FORMULARIO............ {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO}");

                /*" -2116- DISPLAY 'SQLCODE............... ' SQLCODE */
                _.Display($"SQLCODE............... {DB.SQLCODE}");

                /*" -2116- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9900-03-INSERT-OBJETO-DB-INSERT-1 */
        public void R9900_03_INSERT_OBJETO_DB_INSERT_1()
        {
            /*" -2106- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT VALUES (:GEOBJECT-NUM-CEP, 'BI6017B' , :GEOBJECT-COD-FORMULARIO, :GEOBJECT-STA-REGISTRO, CURRENT TIMESTAMP, :GEOBJECT-COD-PRODUTO:VIND-PRODUTO, :GEOBJECT-NUM-INI-POS-VERSO, :GEOBJECT-QTD-PESO-GRAMAS, :GEOBJECT-VLR-DECLARADO, :GEOBJECT-COD-IDENT-OBJETO, :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1 = new R9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1()
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

            R9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1.Execute(r9900_03_INSERT_OBJETO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_03_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2131- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2133- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -2133- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2135- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2139- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2139- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}