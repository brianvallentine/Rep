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
using Sias.Emissao.DB2.EM8010B;

namespace Code
{
    public class EM8010B
    {
        public bool IsCall { get; set; }

        public EM8010B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8010B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA DE REQUISITOS..  CLOVIS/DANIELA MARTINO             *      */
        /*"      *   PROGRAMADOR ............  WANGER C SILVA                     *      */
        /*"      *   CADMUS .... ............  XX.XXX    (PROJETO VISAO)          *      */
        /*"      *   DATA CODIFICACAO .......  11/10/2010                         *      */
        /*"      *   DATA REVISAO ...........  09/12/2010 - CLOVIS                *      */
        /*"      *   DATA REVISAO ...........  21/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DE ARQUIVOS DO LAYOUT      *      */
        /*"      *                             ARQUIVO H PARA O CNAB ( ATM )      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/01/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis ENTRADA
        {
            get
            {
                _.Move(REG_ENTRADA, _ENTRADA); VarBasis.RedefinePassValue(REG_ENTRADA, _ENTRADA, REG_ENTRADA); return _ENTRADA;
            }
        }
        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "420", "X(420)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public SortBasis<EM8010B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<EM8010B_REG_ARQSORT>(new EM8010B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public EM8010B_REG_ARQSORT REG_ARQSORT { get; set; } = new EM8010B_REG_ARQSORT();
        public class EM8010B_REG_ARQSORT : VarBasis
        {
            /*"  10      SOR-TIPO-ARQUIVO         PIC  X(010).*/
            public StringBasis SOR_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10      SOR-CONVENIO             PIC  9(006).*/
            public IntBasis SOR_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-NSAC                 PIC  9(005).*/
            public IntBasis SOR_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10      SOR-DTGERACAO.*/
            public EM8010B_SOR_DTGERACAO SOR_DTGERACAO { get; set; } = new EM8010B_SOR_DTGERACAO();
            public class EM8010B_SOR_DTGERACAO : VarBasis
            {
                /*"    15    SOR-ANO-HEADER           PIC  9(004).*/
                public IntBasis SOR_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    15    SOR-MES-HEADER           PIC  9(002).*/
                public IntBasis SOR_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-DIA-HEADER           PIC  9(002).*/
                public IntBasis SOR_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-COD-REGISTRO         PIC  9(001).*/
            }
            public IntBasis SOR_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-NUM-SIVPF            PIC  9(014).*/
            public IntBasis SOR_NUM_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  10      SOR-AGENCIA              PIC  9(004).*/
            public IntBasis SOR_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-OPERACAO             PIC  9(004).*/
            public IntBasis SOR_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-NUM-CONTA            PIC  9(012).*/
            public IntBasis SOR_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  10      SOR-DIG-CONTA            PIC  9(001).*/
            public IntBasis SOR_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-VALOR-PAGO           PIC  9(012)V99.*/
            public DoubleBasis SOR_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  10      SOR-VALOR-BALCAO         PIC  9(012)V99.*/
            public DoubleBasis SOR_VALOR_BALCAO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  10      SOR-VALOR-TARIFA         PIC  9(012)V99.*/
            public DoubleBasis SOR_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  10      SOR-DATA-PAGTO.*/
            public EM8010B_SOR_DATA_PAGTO SOR_DATA_PAGTO { get; set; } = new EM8010B_SOR_DATA_PAGTO();
            public class EM8010B_SOR_DATA_PAGTO : VarBasis
            {
                /*"    15    SOR-ANO-PAGTO            PIC  9(004).*/
                public IntBasis SOR_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    15    SOR-MES-PAGTO            PIC  9(002).*/
                public IntBasis SOR_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-DIA-PAGTO            PIC  9(002).*/
                public IntBasis SOR_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-DATA-CREDITO.*/
            }
            public EM8010B_SOR_DATA_CREDITO SOR_DATA_CREDITO { get; set; } = new EM8010B_SOR_DATA_CREDITO();
            public class EM8010B_SOR_DATA_CREDITO : VarBasis
            {
                /*"    15    SOR-ANO-CRED             PIC  9(004).*/
                public IntBasis SOR_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    15    SOR-MES-CRED             PIC  9(002).*/
                public IntBasis SOR_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-DIA-CRED             PIC  9(002).*/
                public IntBasis SOR_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01        REG-ENTRADA              PIC  X(300).*/
            }
        }
        public StringBasis REG_ENTRADA { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA01                 PIC  X(420).*/
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "420", "X(420)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  W.*/
        public EM8010B_W W { get; set; } = new EM8010B_W();
        public class EM8010B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ATU-CONVENIO              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis ATU_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  ANT-CONVENIO              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis ANT_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-GRAV-SAIDA01           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-NRSEQ                  PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         WDATA-CABEC.*/
            public EM8010B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8010B_WDATA_CABEC();
            public class EM8010B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_EM8010B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_EM8010B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_EM8010B_FILLER_2(); _.Move(WDATA_REL, _filler_2); VarBasis.RedefinePassValue(WDATA_REL, _filler_2, WDATA_REL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_REL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8010B_FILLER_2 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  ABEN.*/

                public _REDEF_EM8010B_FILLER_2()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8010B_ABEN ABEN { get; set; } = new EM8010B_ABEN();
        public class EM8010B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8010B_WABEND WABEND { get; set; } = new EM8010B_WABEND();
            public class EM8010B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8010B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8010B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8010B_WABEND1 WABEND1 { get; set; } = new EM8010B_WABEND1();
            public class EM8010B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public EM8010B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8010B_HEADER_REGISTRO();
        public class EM8010B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-NOMEARQUIVO  PIC  X(008).*/
            public StringBasis HEADER_NOMEARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(013).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public EM8010B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new EM8010B_HEADER_DATGERACAO();
            public class EM8010B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-ANO          PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05      HEADER-NSA          PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(378).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "378", "X(378)."), @"");
            /*"  05      HEADER-NRSEQ        PIC  9(006).*/
            public IntBasis HEADER_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        MOVCC-REGISTRO.*/
        }
        public EM8010B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new EM8010B_MOVCC_REGISTRO();
        public class EM8010B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-NUMSIVPF     PIC  9(014).*/
            public IntBasis MOVCC_NUMSIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      MOVCC-CTACOBRANCA.*/
            public EM8010B_MOVCC_CTACOBRANCA MOVCC_CTACOBRANCA { get; set; } = new EM8010B_MOVCC_CTACOBRANCA();
            public class EM8010B_MOVCC_CTACOBRANCA : VarBasis
            {
                /*"    10    MOVCC-AGENCIA      PIC  9(004).*/
                public IntBasis MOVCC_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPERACAO     PIC  9(004).*/
                public IntBasis MOVCC_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCTA       PIC  9(012).*/
                public IntBasis MOVCC_NUMCTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCTA       PIC  9(001).*/
                public IntBasis MOVCC_DIGCTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      MOVCC-VLRPAGO      PIC  9(012)V99.*/
            }
            public DoubleBasis MOVCC_VLRPAGO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  05      MOVCC-VLRBALCAO    PIC  9(012)V99.*/
            public DoubleBasis MOVCC_VLRBALCAO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  05      MOVCC-VLRTARIFA    PIC  9(012)V99.*/
            public DoubleBasis MOVCC_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  05      MOVCC-DTPAGTO.*/
            public EM8010B_MOVCC_DTPAGTO MOVCC_DTPAGTO { get; set; } = new EM8010B_MOVCC_DTPAGTO();
            public class EM8010B_MOVCC_DTPAGTO : VarBasis
            {
                /*"    10    MOVCC-DIAPAG       PIC  9(002).*/
                public IntBasis MOVCC_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-MESPAG       PIC  9(002).*/
                public IntBasis MOVCC_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-ANOPAG       PIC  9(004).*/
                public IntBasis MOVCC_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public EM8010B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new EM8010B_MOVCC_DTCREDITO();
            public class EM8010B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-DIACRE       PIC  9(002).*/
                public IntBasis MOVCC_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-MESCRE       PIC  9(002).*/
                public IntBasis MOVCC_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-ANOCRE       PIC  9(004).*/
                public IntBasis MOVCC_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05      FILLER             PIC  X(320).*/
            }
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "320", "X(320)."), @"");
            /*"  05      MOVCC-NRSEQ        PIC  9(006).*/
            public IntBasis MOVCC_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8010B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8010B_TRAILL_REGISTRO();
        public class EM8010B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-NOMEARQUIVO  PIC  X(008).*/
            public StringBasis TRAILL_NOMEARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      TRAILL-NOMEMPRESA   PIC  X(013).*/
            public StringBasis TRAILL_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  05      TRAILL-QTREG01      PIC  9(008).*/
            public IntBasis TRAILL_QTREG01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      TRAILL-QTREG02      PIC  9(008).*/
            public IntBasis TRAILL_QTREG02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      TRAILL-QTREG03      PIC  9(008).*/
            public IntBasis TRAILL_QTREG03 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      FILLER              PIC  X(368).*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "368", "X(368)."), @"");
            /*"  05      TRAILL-NRSEQ        PIC  9(006).*/
            public IntBasis TRAILL_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                ENTRADA.SetFile(ENTRADA_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -227- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -228- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -230- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -232- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -237- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -247- SORT ARQSORT ON ASCENDING KEY SOR-CONVENIO SOR-NSAC INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0500-00-OUTPUT-SORT THRU R0500-99-SAIDA. */
            ARQSORT.Sort("SOR-CONVENIO,SOR-NSAC", () => R0200_00_INPUT_SORT_SECTION(), () => R0500_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -252- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -257- CLOSE ENTRADA SAIDA01. */
            ENTRADA.Close();
            SAIDA01.Close();

            /*" -259- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -260- DISPLAY ' ' */
            _.Display($" ");

            /*" -261- DISPLAY 'EM8010B - FIM NORMAL' . */
            _.Display($"EM8010B - FIM NORMAL");

            /*" -263- DISPLAY ' ' . */
            _.Display($" ");

            /*" -263- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -276- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -277- OPEN INPUT ENTRADA */
            ENTRADA.Open(REG_ENTRADA);

            /*" -280- OUTPUT SAIDA01. */
            SAIDA01.Open(REG_SAIDA01);

            /*" -282- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -283- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -286- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -287- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -287- GO TO R9990-00-SEM-MOVIMENTO. */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -300- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -308- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -311- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -312- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -308- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INPUT-SORT-SECTION */
        private void R0200_00_INPUT_SORT_SECTION()
        {
            /*" -325- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -329- PERFORM R0350-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -330- DISPLAY ' ' */
            _.Display($" ");

            /*" -331- DISPLAY 'LIDOS MOVIMENTO ....... ' LD-MOVIMENTO */
            _.Display($"LIDOS MOVIMENTO ....... {W.LD_MOVIMENTO}");

            /*" -332- DISPLAY 'DESPREZA MOVIMENTO .... ' DP-MOVIMENTO */
            _.Display($"DESPREZA MOVIMENTO .... {W.DP_MOVIMENTO}");

            /*" -333- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT */
            _.Display($"GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -333- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -346- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -347- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -349- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -352- GO TO R0300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ENTRADA.Value, REG_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -352- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0350_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -365- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -368- MOVE REG-ENTRADA TO REG-ARQSORT. */
            _.Move(ENTRADA?.Value, REG_ARQSORT);

            /*" -369- RELEASE REG-ARQSORT */
            ARQSORT.Release(REG_ARQSORT);

            /*" -369- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -374- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-OUTPUT-SORT-SECTION */
        private void R0500_00_OUTPUT_SORT_SECTION()
        {
            /*" -386- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -387- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -390- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

            /*" -394- PERFORM R0550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_SORT_SECTION();
            }

            /*" -395- DISPLAY ' ' */
            _.Display($" ");

            /*" -396- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -397- DISPLAY 'GRAVADOS SIGPF ATM .... ' AC-GRAV-SAIDA01. */
            _.Display($"GRAVADOS SIGPF ATM .... {W.AC_GRAV_SAIDA01}");

            /*" -397- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LE-ARQSORT-SECTION */
        private void R0510_00_LE_ARQSORT_SECTION()
        {
            /*" -410- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -412- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -413- MOVE ZEROS TO ATU-CONVENIO */
                    _.Move(0, W.ATU_CONVENIO);

                    /*" -414- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -417- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -419- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -419- MOVE SOR-CONVENIO TO ATU-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, W.ATU_CONVENIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-SORT-SECTION */
        private void R0550_00_PROCESSA_SORT_SECTION()
        {
            /*" -432- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -434- MOVE ATU-CONVENIO TO ANT-CONVENIO. */
            _.Move(W.ATU_CONVENIO, W.ANT_CONVENIO);

            /*" -437- PERFORM R1100-00-GRAVA-HEADER. */

            R1100_00_GRAVA_HEADER_SECTION();

            /*" -441- PERFORM R1000-00-PROCESSA-DETALHE UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_DETALHE_SECTION();
            }

            /*" -441- PERFORM R1200-00-GRAVA-TRAILLER. */

            R1200_00_GRAVA_TRAILLER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DETALHE-SECTION */
        private void R1000_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -454- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -456- MOVE SPACES TO MOVCC-REGISTRO. */
            _.Move("", MOVCC_REGISTRO);

            /*" -458- MOVE '3' TO MOVCC-CODREGISTRO. */
            _.Move("3", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -460- MOVE SOR-AGENCIA TO MOVCC-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_AGENCIA, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_AGENCIA);

            /*" -462- MOVE SOR-OPERACAO TO MOVCC-OPERACAO */
            _.Move(REG_ARQSORT.SOR_OPERACAO, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_OPERACAO);

            /*" -464- MOVE SOR-NUM-CONTA TO MOVCC-NUMCTA. */
            _.Move(REG_ARQSORT.SOR_NUM_CONTA, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_NUMCTA);

            /*" -466- MOVE SOR-DIG-CONTA TO MOVCC-DIGCTA. */
            _.Move(REG_ARQSORT.SOR_DIG_CONTA, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_DIGCTA);

            /*" -468- MOVE SOR-NUM-SIVPF TO MOVCC-NUMSIVPF. */
            _.Move(REG_ARQSORT.SOR_NUM_SIVPF, MOVCC_REGISTRO.MOVCC_NUMSIVPF);

            /*" -470- MOVE SOR-VALOR-PAGO TO MOVCC-VLRPAGO. */
            _.Move(REG_ARQSORT.SOR_VALOR_PAGO, MOVCC_REGISTRO.MOVCC_VLRPAGO);

            /*" -472- MOVE SOR-VALOR-TARIFA TO MOVCC-VLRTARIFA. */
            _.Move(REG_ARQSORT.SOR_VALOR_TARIFA, MOVCC_REGISTRO.MOVCC_VLRTARIFA);

            /*" -474- MOVE SOR-ANO-PAGTO TO MOVCC-ANOPAG. */
            _.Move(REG_ARQSORT.SOR_DATA_PAGTO.SOR_ANO_PAGTO, MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_ANOPAG);

            /*" -476- MOVE SOR-MES-PAGTO TO MOVCC-MESPAG. */
            _.Move(REG_ARQSORT.SOR_DATA_PAGTO.SOR_MES_PAGTO, MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_MESPAG);

            /*" -478- MOVE SOR-DIA-PAGTO TO MOVCC-DIAPAG. */
            _.Move(REG_ARQSORT.SOR_DATA_PAGTO.SOR_DIA_PAGTO, MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_DIAPAG);

            /*" -480- MOVE SOR-ANO-CRED TO MOVCC-ANOCRE. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO.SOR_ANO_CRED, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANOCRE);

            /*" -482- MOVE SOR-MES-CRED TO MOVCC-MESCRE. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO.SOR_MES_CRED, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MESCRE);

            /*" -485- MOVE SOR-DIA-CRED TO MOVCC-DIACRE. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO.SOR_DIA_CRED, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIACRE);

            /*" -486- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

            /*" -490- MOVE WS-NRSEQ TO MOVCC-NRSEQ. */
            _.Move(W.WS_NRSEQ, MOVCC_REGISTRO.MOVCC_NRSEQ);

            /*" -491- WRITE REG-SAIDA01 FROM MOVCC-REGISTRO */
            _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -491- ADD 1 TO AC-GRAV-SAIDA01. */
            W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -496- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-HEADER-SECTION */
        private void R1100_00_GRAVA_HEADER_SECTION()
        {
            /*" -508- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -510- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -512- MOVE '0' TO HEADER-CODREGISTRO. */
            _.Move("0", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -514- MOVE 'REPASSE' TO HEADER-NOMEARQUIVO. */
            _.Move("REPASSE", HEADER_REGISTRO.HEADER_NOMEARQUIVO);

            /*" -516- MOVE 'SEGUROS' TO HEADER-NOMEMPRESA. */
            _.Move("SEGUROS", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -518- MOVE SOR-ANO-HEADER TO HEADER-ANO. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_ANO_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_ANO);

            /*" -520- MOVE SOR-MES-HEADER TO HEADER-MES. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_MES_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_MES);

            /*" -522- MOVE SOR-DIA-HEADER TO HEADER-DIA. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_DIA_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_DIA);

            /*" -524- MOVE SOR-NSAC TO HEADER-NSA. */
            _.Move(REG_ARQSORT.SOR_NSAC, HEADER_REGISTRO.HEADER_NSA);

            /*" -525- MOVE 1 TO WS-NRSEQ. */
            _.Move(1, W.WS_NRSEQ);

            /*" -529- MOVE WS-NRSEQ TO HEADER-NRSEQ. */
            _.Move(W.WS_NRSEQ, HEADER_REGISTRO.HEADER_NRSEQ);

            /*" -530- WRITE REG-SAIDA01 FROM HEADER-REGISTRO */
            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -530- ADD 1 TO AC-GRAV-SAIDA01. */
            W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TRAILLER-SECTION */
        private void R1200_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -543- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -545- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -547- MOVE '9' TO TRAILL-CODREGISTRO. */
            _.Move("9", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -549- MOVE 'REPASSE' TO TRAILL-NOMEARQUIVO. */
            _.Move("REPASSE", TRAILL_REGISTRO.TRAILL_NOMEARQUIVO);

            /*" -551- MOVE 'SEGUROS' TO TRAILL-NOMEMPRESA. */
            _.Move("SEGUROS", TRAILL_REGISTRO.TRAILL_NOMEMPRESA);

            /*" -555- MOVE ZEROS TO TRAILL-QTREG01 TRAILL-QTREG02 */
            _.Move(0, TRAILL_REGISTRO.TRAILL_QTREG01, TRAILL_REGISTRO.TRAILL_QTREG02);

            /*" -556- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

            /*" -558- MOVE WS-NRSEQ TO TRAILL-NRSEQ. */
            _.Move(W.WS_NRSEQ, TRAILL_REGISTRO.TRAILL_NRSEQ);

            /*" -560- COMPUTE WS-NRSEQ EQUAL (WS-NRSEQ - 2). */
            W.WS_NRSEQ.Value = (W.WS_NRSEQ - 2);

            /*" -564- MOVE WS-NRSEQ TO TRAILL-QTREG03. */
            _.Move(W.WS_NRSEQ, TRAILL_REGISTRO.TRAILL_QTREG03);

            /*" -565- WRITE REG-SAIDA01 FROM TRAILL-REGISTRO */
            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -565- ADD 1 TO AC-GRAV-SAIDA01. */
            W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -577- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -578- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -579- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -581- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC. */
            _.Move(W.FILLER_2.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -583- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' WDATA-CABEC. */
            _.Display($"SEM MOVIMENTO NESTA DATA  {W.WDATA_CABEC}");

            /*" -586- CLOSE ENTRADA SAIDA01. */
            ENTRADA.Close();
            SAIDA01.Close();

            /*" -588- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -588- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -595- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -596- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -597- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -598- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -600- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -600- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -605- CLOSE ENTRADA SAIDA01. */
            ENTRADA.Close();
            SAIDA01.Close();

            /*" -607- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -607- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}