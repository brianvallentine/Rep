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
using Sias.Bilhetes.DB2.BI0229B;

namespace Code
{
    public class BI0229B
    {
        public bool IsCall { get; set; }

        public BI0229B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  BI0229B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  14/05/2018                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  - GERA MOVIMENTO   PRODUTO VIAGEM  *      */
        /*"      *   ORIGEM 0016,  PARA GERACAO DE BOLETO:                        *      */
        /*"      *                                                                *      */
        /*"      *   ESTIPULANTE: ELO SERVI�OS S.A                                *      */
        /*"      *   CNPJ ESTIPULANTE: 009.227.084/0001-75                        *      */
        /*"      *   ENDERE�O: ALAMEDA XINGU, N� 512, 5� ANDAR                    *      */
        /*"      *   CEP ESTIPULANTE: 06455-030                                   *      */
        /*"      *   CIDADE ESTIPULANTE: BARUERI                                  *      */
        /*"      *   ESTADO ESTIPULANTE: SP                                       *      */
        /*"      *   AG�NCIA OPERADORA: 0630                                      *      */
        /*"      *   AP�LICE: 108199999998                                        *      */
        /*"      *   EMISS�O: DATA EM QUE O BOLETO FOR GERADO.                    *      */
        /*"      *   VENCIMENTO: D+20 A DATA DE GERA��O DO BOLETO                 *      */
        /*"      *                                                                *      */
        /*"      *                               HISTORIA 26310.                  *      */
        /*"      *                               TAREFA   28990.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   DATA ALTERACAO .........  04/06/2018                         *      */
        /*"      *   FUNCAO .................  - INCLUI MOVIMENTO PRODUTO VIAGEM  *      */
        /*"      *   ORIGEM 0017,  PARA GERACAO DE BOLETO:                        *      */
        /*"      *                                                                *      */
        /*"      *   ESTIPULANTE: WEB PR�MIOS TURISMO E REPRESENTA��ES LTDA       *      */
        /*"      *   CNPJ ESTIPULANTE: 16.912.596/0001-36                         *      */
        /*"      *   ENDERE�O: ALAMEDA RIO NEGRO, N� 585 - BLOCO C - CONJUNTO 71  *      */
        /*"      *   CEP ESTIPULANTE: 06454-000                                   *      */
        /*"      *   CIDADE ESTIPULANTE: BARUERI                                  *      */
        /*"      *   ESTADO ESTIPULANTE: SP                                       *      */
        /*"      *   AG�NCIA OPERADORA: 0630                                      *      */
        /*"      *   AP�LICE: 108199999998                                        *      */
        /*"      *   EMISS�O: DATA EM QUE O BOLETO FOR GERADO.                    *      */
        /*"      *   VENCIMENTO: D+20 A DATA DE GERA��O DO BOLETO                 *      */
        /*"      *                                                                *      */
        /*"      *                               TAREFA   161281.                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public SortBasis<BI0229B_REG_SBI0229B> SBI0229B { get; set; } = new SortBasis<BI0229B_REG_SBI0229B>(new BI0229B_REG_SBI0229B());
        /*"01         REG-SBI0229B.*/
        public BI0229B_REG_SBI0229B REG_SBI0229B { get; set; } = new BI0229B_REG_SBI0229B();
        public class BI0229B_REG_SBI0229B : VarBasis
        {
            /*"    05     SVA-NUM-APOLICE       PIC  9(013).*/
            public IntBasis SVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05     SVA-NUM-ENDOSSO       PIC  9(009).*/
            public IntBasis SVA_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05     SVA-NUM-PARCELA       PIC  9(005).*/
            public IntBasis SVA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05     SVA-NUM-TITULO        PIC  9(013).*/
            public IntBasis SVA_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05     SVA-NUM-PROPSIVPF     PIC  9(015).*/
            public IntBasis SVA_NUM_PROPSIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05     SVA-COD-SUBGRUPO      PIC  9(008).*/
            public IntBasis SVA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05     SVA-COD-FONTE         PIC  9(005).*/
            public IntBasis SVA_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05     SVA-RAMO-EMISSOR      PIC  9(005).*/
            public IntBasis SVA_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05     SVA-COD-PRODUTO       PIC  9(007).*/
            public IntBasis SVA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"    05     SVA-COD-FAVORECIDO    PIC  9(009).*/
            public IntBasis SVA_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05     SVA-COD-ENDERECO      PIC  9(005).*/
            public IntBasis SVA_COD_ENDERECO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05     SVA-OCORR-ENDERECO    PIC  9(005).*/
            public IntBasis SVA_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05     SVA-DATA-QUITACAO     PIC  X(010).*/
            public StringBasis SVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05     SVA-VAL-TITULO        PIC  9(013)V99.*/
            public DoubleBasis SVA_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     SVA-VAL-IOCC          PIC  9(013)V99.*/
            public DoubleBasis SVA_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     SVA-VAL-OPERACAO      PIC  9(013)V99.*/
            public DoubleBasis SVA_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     SVA-ORIGEM            PIC  9(005).*/
            public IntBasis SVA_ORIGEM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NRSEQ                PIC S9(004)     COMP.*/
        public IntBasis VIND_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-DTINIVIG           PIC  X(010).*/
        public StringBasis WSHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-DTTERVIG           PIC  X(010).*/
        public StringBasis WSHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-IOF                PIC S9(015)V9(002)    COMP-3.*/
        public DoubleBasis WSHOST_IOF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(002)"), 2);
        /*"01  W.*/
        public BI0229B_W W { get; set; } = new BI0229B_W();
        public class BI0229B_W : VarBasis
        {
            /*"  03  WFIM-ENDOSSOS             PIC  X(001)       VALUE 'N'.*/
            public StringBasis WFIM_ENDOSSOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-SORT                 PIC  X(001)       VALUE  SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-ENDOSSOS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis LD_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-SORT                   PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-TIPOSEG                PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_TIPOSEG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-TIPOEND                PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_TIPOEND { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-SORT                   PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-CBCONDEV               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis IN_CBCONDEV { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DU-CBCONDEV               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DU_CBCONDEV { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-ORIGEM16               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis TT_ORIGEM16 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-ORIGEM17               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis TT_ORIGEM17 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)       VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES         AC-LIDOS.*/
            private _REDEF_BI0229B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0229B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0229B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI0229B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WS-CHAVE-ATU.*/

                public _REDEF_BI0229B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public BI0229B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new BI0229B_WS_CHAVE_ATU();
            public class BI0229B_WS_CHAVE_ATU : VarBasis
            {
                /*"    05       ATU-NUM-APOLICE    PIC  9(013).*/
                public IntBasis ATU_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05       ATU-NUM-ENDOSSO    PIC  9(009).*/
                public IntBasis ATU_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    05       ATU-NUM-PARCELA    PIC  9(005).*/
                public IntBasis ATU_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WS-CHAVE-ANT.*/
            }
            public BI0229B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new BI0229B_WS_CHAVE_ANT();
            public class BI0229B_WS_CHAVE_ANT : VarBasis
            {
                /*"    05       ANT-NUM-APOLICE    PIC  9(013).*/
                public IntBasis ANT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05       ANT-NUM-ENDOSSO    PIC  9(009).*/
                public IntBasis ANT_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    05       ANT-NUM-PARCELA    PIC  9(005).*/
                public IntBasis ANT_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WDATA-REL          PIC  X(010)       VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES         WDATA-REL.*/
            private _REDEF_BI0229B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0229B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0229B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0229B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_BI0229B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES         WTIME-DAY.*/
            private _REDEF_BI0229B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0229B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0229B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0229B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI0229B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0229B_WTIME_DAYR();
                public class BI0229B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public BI0229B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_BI0229B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0229B_WS_TIME WS_TIME { get; set; } = new BI0229B_WS_TIME();
            public class BI0229B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WABEND.*/
            }
            public BI0229B_WABEND WABEND { get; set; } = new BI0229B_WABEND();
            public class BI0229B_WABEND : VarBasis
            {
                /*"    05       FILLER             PIC  X(010)       VALUE            ' BI0229B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0229B  ");
                /*"    05       FILLER             PIC  X(028)       VALUE            ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05       WNR-EXEC-SQL       PIC  X(004)       VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05       FILLER             PIC  X(014)       VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05       WSQLCODE           PIC  ZZZZZ999-    VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05       FILLER             PIC  X(014)       VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05       WSQLERRD1          PIC  ZZZZZ999-    VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05       FILLER             PIC  X(014)       VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999-    VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public BI0229B_V0ENDOSSO V0ENDOSSO { get; set; } = new BI0229B_V0ENDOSSO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SBI0229B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SBI0229B.SetFile(SBI0229B_FILE_NAME_P);

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
            /*" -199- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -200- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -202- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -204- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -207- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -208- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -209- DISPLAY 'PROGRAMA EM EXECUCAO BI0229B      ' */
            _.Display($"PROGRAMA EM EXECUCAO BI0229B      ");

            /*" -210- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -211- DISPLAY 'VERSAO V.00 - 16/05/2018          ' */
            _.Display($"VERSAO V.00 - 16/05/2018          ");

            /*" -212- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -213- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -216- DISPLAY ' ' . */
            _.Display($" ");

            /*" -218- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -229- SORT SBI0229B ON ASCENDING KEY SVA-ORIGEM SVA-NUM-APOLICE SVA-NUM-ENDOSSO SVA-NUM-PARCELA INPUT PROCEDURE R0290-00-TRATA-ENDOSSOS THRU R0290-99-SAIDA OUTPUT PROCEDURE R1000-00-PROCESSA-SORT THRU R1000-99-SAIDA. */
            SBI0229B.Sort("SVA-ORIGEM,SVA-NUM-APOLICE,SVA-NUM-ENDOSSO,SVA-NUM-PARCELA", () => R0290_00_TRATA_ENDOSSOS_SECTION(), () => R1000_00_PROCESSA_SORT_SECTION());

            /*" -233- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -234- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -235- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -236- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -237- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -238- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -238- DISPLAY 'FIM    BI0229B    ' WTIME-DAYR. */
            _.Display($"FIM    BI0229B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -243- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -248- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -249- DISPLAY ' ' */
            _.Display($" ");

            /*" -250- DISPLAY 'BI0229B - FIM NORMAL' */
            _.Display($"BI0229B - FIM NORMAL");

            /*" -253- DISPLAY ' ' */
            _.Display($" ");

            /*" -253- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -262- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -263- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -264- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -265- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -266- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -267- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -268- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -271- DISPLAY 'INICIO BI0229B    ' WTIME-DAYR. */
            _.Display($"INICIO BI0229B    {W.FILLER_4.WTIME_DAYR}");

            /*" -274- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -275- DISPLAY ' ' . */
            _.Display($" ");

            /*" -277- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -279- DISPLAY 'DATA INICIO ........... ' WSHOST-DTINIVIG. */
            _.Display($"DATA INICIO ........... {WSHOST_DTINIVIG}");

            /*" -281- DISPLAY 'DATA TERMINO .......... ' WSHOST-DTTERVIG. */
            _.Display($"DATA TERMINO .......... {WSHOST_DTTERVIG}");

            /*" -284- DISPLAY ' ' . */
            _.Display($" ");

            /*" -284- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -297- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -304- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -308- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -309- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -314- MOVE SISTEMAS-DATA-MOV-ABERTO TO WSHOST-DTINIVIG WSHOST-DTTERVIG. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WSHOST_DTINIVIG, WSHOST_DTTERVIG);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -304- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-TRATA-ENDOSSOS-SECTION */
        private void R0290_00_TRATA_ENDOSSOS_SECTION()
        {
            /*" -327- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", W.WABEND.WNR_EXEC_SQL);

            /*" -328- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -329- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -330- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -331- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -332- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -333- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -336- DISPLAY 'DECLARE ENDOSSOS  ' WTIME-DAYR. */
            _.Display($"DECLARE ENDOSSOS  {W.FILLER_4.WTIME_DAYR}");

            /*" -338- MOVE SPACES TO WFIM-ENDOSSOS. */
            _.Move("", W.WFIM_ENDOSSOS);

            /*" -339- PERFORM R0300-00-DECLARE-V0ENDOSSO. */

            R0300_00_DECLARE_V0ENDOSSO_SECTION();

            /*" -341- PERFORM R0310-00-FETCH-V0ENDOSSO. */

            R0310_00_FETCH_V0ENDOSSO_SECTION();

            /*" -345- PERFORM R0320-00-PROCESSA-V0ENDOSSO UNTIL WFIM-ENDOSSOS NOT EQUAL SPACES. */

            while (!(!W.WFIM_ENDOSSOS.IsEmpty()))
            {

                R0320_00_PROCESSA_V0ENDOSSO_SECTION();
            }

            /*" -345- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -348- DISPLAY ' ' . */
            _.Display($" ");

            /*" -349- DISPLAY 'LIDOS ENDOSSOS ............. ' LD-ENDOSSOS */
            _.Display($"LIDOS ENDOSSOS ............. {W.LD_ENDOSSOS}");

            /*" -350- DISPLAY 'DESPREZA TIPO SEGURO ....... ' DP-TIPOSEG */
            _.Display($"DESPREZA TIPO SEGURO ....... {W.DP_TIPOSEG}");

            /*" -351- DISPLAY 'DESPREZA TIPO ENDOSSO ...... ' DP-TIPOEND */
            _.Display($"DESPREZA TIPO ENDOSSO ...... {W.DP_TIPOEND}");

            /*" -352- DISPLAY ' ' . */
            _.Display($" ");

            /*" -353- DISPLAY 'GRAVADOS SORT ............. ' GV-SORT */
            _.Display($"GRAVADOS SORT ............. {W.GV_SORT}");

            /*" -353- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0ENDOSSO-SECTION */
        private void R0300_00_DECLARE_V0ENDOSSO_SECTION()
        {
            /*" -366- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -406- PERFORM R0300_00_DECLARE_V0ENDOSSO_DB_DECLARE_1 */

            R0300_00_DECLARE_V0ENDOSSO_DB_DECLARE_1();

            /*" -408- PERFORM R0300_00_DECLARE_V0ENDOSSO_DB_OPEN_1 */

            R0300_00_DECLARE_V0ENDOSSO_DB_OPEN_1();

            /*" -411- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -412- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (V0ENDOSSO)  ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (V0ENDOSSO)  ");

                /*" -415- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -416- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -417- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -418- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -419- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -420- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -421- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -421- DISPLAY 'FETCH   ENDOSSOS  ' WTIME-DAYR. */
            _.Display($"FETCH   ENDOSSOS  {W.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0ENDOSSO-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0ENDOSSO_DB_DECLARE_1()
        {
            /*" -406- EXEC SQL DECLARE V0ENDOSSO CURSOR WITH HOLD FOR SELECT C.NUM_APOLICE ,C.NUM_ENDOSSO ,C.NUM_PARCELA ,C.VAL_IOCC ,C.PRM_TOTAL ,A.RAMO_EMISSOR ,A.COD_PRODUTO ,A.COD_SUBGRUPO ,A.COD_FONTE ,A.TIPO_ENDOSSO ,A.OCORR_ENDERECO ,B.COD_CLIENTE ,B.NUM_BILHETE ,B.TIPO_SEGURO ,E.NUM_PROPOSTA_SIVPF ,E.ORIGEM_PROPOSTA ,F.DATA_QUITACAO FROM SEGUROS.ENDOSSOS A ,SEGUROS.APOLICES B ,SEGUROS.PARCELA_HISTORICO C ,SEGUROS.PARCELAS D ,SEGUROS.PROPOSTA_FIDELIZ E ,SEGUROS.BILHETE F WHERE A.DATA_EMISSAO >= :WSHOST-DTINIVIG AND A.DATA_EMISSAO <= :WSHOST-DTTERVIG AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_BILHETE = F.NUM_BILHETE AND E.NUM_SICOB = B.NUM_BILHETE AND E.ORIGEM_PROPOSTA IN (16,17) AND C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_ENDOSSO = D.NUM_ENDOSSO AND C.NUM_PARCELA = D.NUM_PARCELA AND C.OCORR_HISTORICO = D.OCORR_HISTORICO AND C.PRM_TOTAL > 0 WITH UR END-EXEC. */
            V0ENDOSSO = new BI0229B_V0ENDOSSO(true);
            string GetQuery_V0ENDOSSO()
            {
                var query = @$"SELECT C.NUM_APOLICE 
							,C.NUM_ENDOSSO 
							,C.NUM_PARCELA 
							,C.VAL_IOCC 
							,C.PRM_TOTAL 
							,A.RAMO_EMISSOR 
							,A.COD_PRODUTO 
							,A.COD_SUBGRUPO 
							,A.COD_FONTE 
							,A.TIPO_ENDOSSO 
							,A.OCORR_ENDERECO 
							,B.COD_CLIENTE 
							,B.NUM_BILHETE 
							,B.TIPO_SEGURO 
							,E.NUM_PROPOSTA_SIVPF 
							,E.ORIGEM_PROPOSTA 
							,F.DATA_QUITACAO 
							FROM SEGUROS.ENDOSSOS A 
							,SEGUROS.APOLICES B 
							,SEGUROS.PARCELA_HISTORICO C 
							,SEGUROS.PARCELAS D 
							,SEGUROS.PROPOSTA_FIDELIZ E 
							,SEGUROS.BILHETE F 
							WHERE A.DATA_EMISSAO >= '{WSHOST_DTINIVIG}' 
							AND A.DATA_EMISSAO <= '{WSHOST_DTTERVIG}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_BILHETE = F.NUM_BILHETE 
							AND E.NUM_SICOB = B.NUM_BILHETE 
							AND E.ORIGEM_PROPOSTA IN (16
							,17) 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_ENDOSSO = D.NUM_ENDOSSO 
							AND C.NUM_PARCELA = D.NUM_PARCELA 
							AND C.OCORR_HISTORICO = D.OCORR_HISTORICO 
							AND C.PRM_TOTAL > 0";

                return query;
            }
            V0ENDOSSO.GetQueryEvent += GetQuery_V0ENDOSSO;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0ENDOSSO-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0ENDOSSO_DB_OPEN_1()
        {
            /*" -408- EXEC SQL OPEN V0ENDOSSO END-EXEC. */

            V0ENDOSSO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0ENDOSSO-SECTION */
        private void R0310_00_FETCH_V0ENDOSSO_SECTION()
        {
            /*" -434- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -452- PERFORM R0310_00_FETCH_V0ENDOSSO_DB_FETCH_1 */

            R0310_00_FETCH_V0ENDOSSO_DB_FETCH_1();

            /*" -456- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -456- PERFORM R0310_00_FETCH_V0ENDOSSO_DB_CLOSE_1 */

                R0310_00_FETCH_V0ENDOSSO_DB_CLOSE_1();

                /*" -458- MOVE 'S' TO WFIM-ENDOSSOS */
                _.Move("S", W.WFIM_ENDOSSOS);

                /*" -460- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -461- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -465- DISPLAY 'R0310-00 - PROBLEMAS FETCH (V0ENDOSSO)    ' ' APOLICE    ' PARCEHIS-NUM-APOLICE ' ENDOSSO    ' PARCEHIS-NUM-ENDOSSO ' PARCELA    ' PARCEHIS-NUM-PARCELA */

                $"R0310-00 - PROBLEMAS FETCH (V0ENDOSSO)     APOLICE    {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO    {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA    {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -468- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -470- ADD 1 TO LD-ENDOSSOS. */
            W.LD_ENDOSSOS.Value = W.LD_ENDOSSOS + 1;

            /*" -472- MOVE LD-ENDOSSOS TO AC-LIDOS. */
            _.Move(W.LD_ENDOSSOS, W.AC_LIDOS);

            /*" -474- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -475- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -476- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -477- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -478- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -479- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -480- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -481- DISPLAY 'LIDOS ENDOSSOS     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS ENDOSSOS     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-V0ENDOSSO-DB-FETCH-1 */
        public void R0310_00_FETCH_V0ENDOSSO_DB_FETCH_1()
        {
            /*" -452- EXEC SQL FETCH V0ENDOSSO INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-TIPO-ENDOSSO ,:ENDOSSOS-OCORR-ENDERECO ,:APOLICES-COD-CLIENTE ,:APOLICES-NUM-BILHETE ,:APOLICES-TIPO-SEGURO ,:PROPOFID-NUM-PROPOSTA-SIVPF ,:PROPOFID-ORIGEM-PROPOSTA ,:BILHETE-DATA-QUITACAO END-EXEC. */

            if (V0ENDOSSO.Fetch())
            {
                _.Move(V0ENDOSSO.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(V0ENDOSSO.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(V0ENDOSSO.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(V0ENDOSSO.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(V0ENDOSSO.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(V0ENDOSSO.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(V0ENDOSSO.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(V0ENDOSSO.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(V0ENDOSSO.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(V0ENDOSSO.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(V0ENDOSSO.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(V0ENDOSSO.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(V0ENDOSSO.APOLICES_NUM_BILHETE, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);
                _.Move(V0ENDOSSO.APOLICES_TIPO_SEGURO, APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO);
                _.Move(V0ENDOSSO.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(V0ENDOSSO.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(V0ENDOSSO.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0ENDOSSO-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0ENDOSSO_DB_CLOSE_1()
        {
            /*" -456- EXEC SQL CLOSE V0ENDOSSO END-EXEC */

            V0ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-V0ENDOSSO-SECTION */
        private void R0320_00_PROCESSA_V0ENDOSSO_SECTION()
        {
            /*" -494- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.WABEND.WNR_EXEC_SQL);

            /*" -495- IF APOLICES-TIPO-SEGURO NOT EQUAL '1' */

            if (APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO != "1")
            {

                /*" -496- ADD 1 TO DP-TIPOSEG */
                W.DP_TIPOSEG.Value = W.DP_TIPOSEG + 1;

                /*" -499- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -501- IF ENDOSSOS-TIPO-ENDOSSO NOT EQUAL '0' AND ENDOSSOS-TIPO-ENDOSSO NOT EQUAL '1' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO != "0" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO != "1")
            {

                /*" -502- ADD 1 TO DP-TIPOEND */
                W.DP_TIPOEND.Value = W.DP_TIPOEND + 1;

                /*" -505- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -506- MOVE SPACES TO REG-SBI0229B. */
            _.Move("", REG_SBI0229B);

            /*" -508- MOVE PARCEHIS-NUM-APOLICE TO SVA-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, REG_SBI0229B.SVA_NUM_APOLICE);

            /*" -510- MOVE PARCEHIS-NUM-ENDOSSO TO SVA-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, REG_SBI0229B.SVA_NUM_ENDOSSO);

            /*" -512- MOVE PARCEHIS-NUM-PARCELA TO SVA-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, REG_SBI0229B.SVA_NUM_PARCELA);

            /*" -514- MOVE APOLICES-NUM-BILHETE TO SVA-NUM-TITULO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE, REG_SBI0229B.SVA_NUM_TITULO);

            /*" -516- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO SVA-NUM-PROPSIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, REG_SBI0229B.SVA_NUM_PROPSIVPF);

            /*" -518- MOVE PROPOFID-ORIGEM-PROPOSTA TO SVA-ORIGEM. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, REG_SBI0229B.SVA_ORIGEM);

            /*" -520- MOVE ENDOSSOS-COD-SUBGRUPO TO SVA-COD-SUBGRUPO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, REG_SBI0229B.SVA_COD_SUBGRUPO);

            /*" -522- MOVE ENDOSSOS-COD-FONTE TO SVA-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, REG_SBI0229B.SVA_COD_FONTE);

            /*" -524- MOVE ENDOSSOS-RAMO-EMISSOR TO SVA-RAMO-EMISSOR. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, REG_SBI0229B.SVA_RAMO_EMISSOR);

            /*" -526- MOVE ENDOSSOS-COD-PRODUTO TO SVA-COD-PRODUTO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, REG_SBI0229B.SVA_COD_PRODUTO);

            /*" -528- MOVE APOLICES-COD-CLIENTE TO SVA-COD-FAVORECIDO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, REG_SBI0229B.SVA_COD_FAVORECIDO);

            /*" -530- MOVE ENDOSSOS-OCORR-ENDERECO TO SVA-OCORR-ENDERECO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO, REG_SBI0229B.SVA_OCORR_ENDERECO);

            /*" -532- MOVE BILHETE-DATA-QUITACAO TO SVA-DATA-QUITACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, REG_SBI0229B.SVA_DATA_QUITACAO);

            /*" -534- MOVE PARCEHIS-PRM-TOTAL TO SVA-VAL-TITULO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, REG_SBI0229B.SVA_VAL_TITULO);

            /*" -536- MOVE PARCEHIS-VAL-IOCC TO SVA-VAL-IOCC. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC, REG_SBI0229B.SVA_VAL_IOCC);

            /*" -540- MOVE PARCEHIS-PRM-TOTAL TO SVA-VAL-OPERACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, REG_SBI0229B.SVA_VAL_OPERACAO);

            /*" -543- PERFORM R0410-00-SELECT-ENDERECOS. */

            R0410_00_SELECT_ENDERECOS_SECTION();

            /*" -544- RELEASE REG-SBI0229B. */
            SBI0229B.Release(REG_SBI0229B);

            /*" -544- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0320_90_LEITURA */

            R0320_90_LEITURA();

        }

        [StopWatch]
        /*" R0320-90-LEITURA */
        private void R0320_90_LEITURA(bool isPerform = false)
        {
            /*" -549- PERFORM R0310-00-FETCH-V0ENDOSSO. */

            R0310_00_FETCH_V0ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-SELECT-ENDERECOS-SECTION */
        private void R0410_00_SELECT_ENDERECOS_SECTION()
        {
            /*" -560- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -568- PERFORM R0410_00_SELECT_ENDERECOS_DB_SELECT_1 */

            R0410_00_SELECT_ENDERECOS_DB_SELECT_1();

            /*" -571- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -573- MOVE ZEROS TO SVA-COD-ENDERECO */
                _.Move(0, REG_SBI0229B.SVA_COD_ENDERECO);

                /*" -574- ELSE */
            }
            else
            {


                /*" -575- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -576- DISPLAY 'R0410-00 - PROBLEMAS NO SELECT(ENDERECOS)' */
                    _.Display($"R0410-00 - PROBLEMAS NO SELECT(ENDERECOS)");

                    /*" -577- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -578- ELSE */
                }
                else
                {


                    /*" -579- MOVE ENDERECO-SIGLA-UF TO SVA-COD-ENDERECO. */
                    _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SBI0229B.SVA_COD_ENDERECO);
                }

            }


        }

        [StopWatch]
        /*" R0410-00-SELECT-ENDERECOS-DB-SELECT-1 */
        public void R0410_00_SELECT_ENDERECOS_DB_SELECT_1()
        {
            /*" -568- EXEC SQL SELECT COD_ENDERECO INTO :ENDERECO-COD-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :APOLICES-COD-CLIENTE AND OCORR_ENDERECO = :ENDOSSOS-OCORR-ENDERECO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 = new R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1.Execute(r0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SORT-SECTION */
        private void R1000_00_PROCESSA_SORT_SECTION()
        {
            /*" -592- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -599- MOVE ZEROS TO ATU-NUM-APOLICE ATU-NUM-ENDOSSO ATU-NUM-PARCELA ANT-NUM-APOLICE ANT-NUM-ENDOSSO ANT-NUM-PARCELA. */
            _.Move(0, W.WS_CHAVE_ATU.ATU_NUM_APOLICE, W.WS_CHAVE_ATU.ATU_NUM_ENDOSSO, W.WS_CHAVE_ATU.ATU_NUM_PARCELA, W.WS_CHAVE_ANT.ANT_NUM_APOLICE, W.WS_CHAVE_ANT.ANT_NUM_ENDOSSO, W.WS_CHAVE_ANT.ANT_NUM_PARCELA);

            /*" -601- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -603- PERFORM R1010-00-LER-SORT. */

            R1010_00_LER_SORT_SECTION();

            /*" -604- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -607- GO TO R1000-90-DISPLAY. */

                R1000_90_DISPLAY(); //GOTO
                return;
            }


            /*" -610- PERFORM R1020-00-SELECT-CBCONDEV. */

            R1020_00_SELECT_CBCONDEV_SECTION();

            /*" -611- PERFORM R1050-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R1050_00_PROCESSA_SORT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R1000_90_DISPLAY */

            R1000_90_DISPLAY();

        }

        [StopWatch]
        /*" R1000-90-DISPLAY */
        private void R1000_90_DISPLAY(bool isPerform = false)
        {
            /*" -617- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -621- DISPLAY ' ' . */
            _.Display($" ");

            /*" -622- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -623- DISPLAY ' ' . */
            _.Display($" ");

            /*" -624- DISPLAY 'TRATA ORIGEM 16 ........... ' TT-ORIGEM16 */
            _.Display($"TRATA ORIGEM 16 ........... {W.TT_ORIGEM16}");

            /*" -625- DISPLAY 'TRATA ORIGEM 17 ........... ' TT-ORIGEM17 */
            _.Display($"TRATA ORIGEM 17 ........... {W.TT_ORIGEM17}");

            /*" -626- DISPLAY ' ' . */
            _.Display($" ");

            /*" -627- DISPLAY 'INSERT  CBCONDEV .......... ' IN-CBCONDEV */
            _.Display($"INSERT  CBCONDEV .......... {W.IN_CBCONDEV}");

            /*" -628- DISPLAY 'DUPLICA CBCONDEV .......... ' DU-CBCONDEV */
            _.Display($"DUPLICA CBCONDEV .......... {W.DU_CBCONDEV}");

            /*" -628- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-LER-SORT-SECTION */
        private void R1010_00_LER_SORT_SECTION()
        {
            /*" -641- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", W.WABEND.WNR_EXEC_SQL);

            /*" -643- RETURN SBI0229B AT END */
            try
            {
                SBI0229B.Return(REG_SBI0229B, () =>
                {

                    /*" -644- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -647- MOVE ZEROS TO ATU-NUM-APOLICE ATU-NUM-ENDOSSO ATU-NUM-PARCELA */
                    _.Move(0, W.WS_CHAVE_ATU.ATU_NUM_APOLICE, W.WS_CHAVE_ATU.ATU_NUM_ENDOSSO, W.WS_CHAVE_ATU.ATU_NUM_PARCELA);

                    /*" -650- GO TO R1010-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -653- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -655- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -657- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -658- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -659- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -660- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -661- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -662- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -663- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -667- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


            /*" -668- MOVE SVA-NUM-APOLICE TO ATU-NUM-APOLICE. */
            _.Move(REG_SBI0229B.SVA_NUM_APOLICE, W.WS_CHAVE_ATU.ATU_NUM_APOLICE);

            /*" -669- MOVE SVA-NUM-ENDOSSO TO ATU-NUM-ENDOSSO. */
            _.Move(REG_SBI0229B.SVA_NUM_ENDOSSO, W.WS_CHAVE_ATU.ATU_NUM_ENDOSSO);

            /*" -669- MOVE SVA-NUM-PARCELA TO ATU-NUM-PARCELA. */
            _.Move(REG_SBI0229B.SVA_NUM_PARCELA, W.WS_CHAVE_ATU.ATU_NUM_PARCELA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-CBCONDEV-SECTION */
        private void R1020_00_SELECT_CBCONDEV_SECTION()
        {
            /*" -681- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", W.WABEND.WNR_EXEC_SQL);

            /*" -687- PERFORM R1020_00_SELECT_CBCONDEV_DB_SELECT_1 */

            R1020_00_SELECT_CBCONDEV_DB_SELECT_1();

            /*" -690- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -692- MOVE ZEROS TO CBCONDEV-NUM-SEQUENCIA */
                _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);

                /*" -693- ELSE */
            }
            else
            {


                /*" -694- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -695- DISPLAY 'R1020-00 - PROBLEMAS NO SELECT(CBCONDEV) ' */
                    _.Display($"R1020-00 - PROBLEMAS NO SELECT(CBCONDEV) ");

                    /*" -696- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -697- ELSE */
                }
                else
                {


                    /*" -698- IF VIND-NRSEQ LESS ZEROS */

                    if (VIND_NRSEQ < 00)
                    {

                        /*" -699- MOVE ZEROS TO CBCONDEV-NUM-SEQUENCIA. */
                        _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);
                    }

                }

            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-CBCONDEV-DB-SELECT-1 */
        public void R1020_00_SELECT_CBCONDEV_DB_SELECT_1()
        {
            /*" -687- EXEC SQL SELECT MAX(NUM_SEQUENCIA) INTO :CBCONDEV-NUM-SEQUENCIA:VIND-NRSEQ FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var r1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 = new R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBCONDEV_NUM_SEQUENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);
                _.Move(executed_1.VIND_NRSEQ, VIND_NRSEQ);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-PROCESSA-SORT-SECTION */
        private void R1050_00_PROCESSA_SORT_SECTION()
        {
            /*" -712- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", W.WABEND.WNR_EXEC_SQL);

            /*" -713- IF WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT */

            if (W.WS_CHAVE_ATU != W.WS_CHAVE_ANT)
            {

                /*" -714- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

                /*" -714- PERFORM R1100-00-MOVE-DADOS. */

                R1100_00_MOVE_DADOS_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1050_90_LEITURA */

            R1050_90_LEITURA();

        }

        [StopWatch]
        /*" R1050-90-LEITURA */
        private void R1050_90_LEITURA(bool isPerform = false)
        {
            /*" -719- PERFORM R1010-00-LER-SORT. */

            R1010_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MOVE-DADOS-SECTION */
        private void R1100_00_MOVE_DADOS_SECTION()
        {
            /*" -731- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", W.WABEND.WNR_EXEC_SQL);

            /*" -733- MOVE ZEROS TO CBCONDEV-COD-EMPRESA. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA);

            /*" -735- MOVE 'A' TO CBCONDEV-TIPO-MOVIMENTO. */
            _.Move("A", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);

            /*" -738- MOVE ZEROS TO CBCONDEV-NUM-CHEQUE-INTERNO CBCONDEV-DIG-CHEQUE-INTERNO. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

            /*" -740- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBCONDEV-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO);

            /*" -742- ADD 1 TO CBCONDEV-NUM-SEQUENCIA. */
            CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA.Value = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA + 1;

            /*" -744- MOVE SVA-NUM-TITULO TO CBCONDEV-NUM-TITULO. */
            _.Move(REG_SBI0229B.SVA_NUM_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO);

            /*" -746- MOVE SVA-COD-FONTE TO CBCONDEV-COD-FONTE. */
            _.Move(REG_SBI0229B.SVA_COD_FONTE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE);

            /*" -749- MOVE ZEROS TO CBCONDEV-NUM-RCAP CBCONDEV-NUM-RCAP-COMPLEMEN. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN);

            /*" -751- MOVE SVA-NUM-APOLICE TO CBCONDEV-NUM-APOLICE. */
            _.Move(REG_SBI0229B.SVA_NUM_APOLICE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE);

            /*" -753- MOVE SVA-NUM-ENDOSSO TO CBCONDEV-NUM-ENDOSSO. */
            _.Move(REG_SBI0229B.SVA_NUM_ENDOSSO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO);

            /*" -755- MOVE SVA-NUM-PARCELA TO CBCONDEV-NUM-PARCELA. */
            _.Move(REG_SBI0229B.SVA_NUM_PARCELA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA);

            /*" -757- MOVE SVA-COD-SUBGRUPO TO CBCONDEV-COD-SUBGRUPO. */
            _.Move(REG_SBI0229B.SVA_COD_SUBGRUPO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO);

            /*" -759- MOVE ZEROS TO CBCONDEV-NUM-CERTIFICADO. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -761- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBCONDEV-DATA-OCORRENCIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA);

            /*" -763- MOVE SVA-NUM-PROPSIVPF TO CBCONDEV-NUM-MATRICULA. */
            _.Move(REG_SBI0229B.SVA_NUM_PROPSIVPF, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA);

            /*" -765- MOVE SVA-RAMO-EMISSOR TO CBCONDEV-RAMO-EMISSOR. */
            _.Move(REG_SBI0229B.SVA_RAMO_EMISSOR, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR);

            /*" -767- MOVE SVA-COD-PRODUTO TO CBCONDEV-COD-PRODUTO. */
            _.Move(REG_SBI0229B.SVA_COD_PRODUTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO);

            /*" -771- MOVE ZEROS TO CBCONDEV-COD-FILIAL CBCONDEV-COD-ESCNEG CBCONDEV-AGE-COBRANCA. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA);

            /*" -773- MOVE '2' TO CBCONDEV-TIPO-FAVORECIDO. */
            _.Move("2", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO);

            /*" -775- MOVE SVA-COD-FAVORECIDO TO CBCONDEV-COD-FAVORECIDO. */
            _.Move(REG_SBI0229B.SVA_COD_FAVORECIDO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO);

            /*" -777- MOVE SVA-COD-ENDERECO TO CBCONDEV-COD-ENDERECO. */
            _.Move(REG_SBI0229B.SVA_COD_ENDERECO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO);

            /*" -779- MOVE SVA-OCORR-ENDERECO TO CBCONDEV-OCORR-ENDERECO. */
            _.Move(REG_SBI0229B.SVA_OCORR_ENDERECO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO);

            /*" -784- MOVE ZEROS TO CBCONDEV-COD-AGENCIA CBCONDEV-OPERACAO-CONTA CBCONDEV-NUM-CONTA CBCONDEV-DIG-CONTA. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA);

            /*" -786- MOVE '0' TO CBCONDEV-SIT-REGISTRO. */
            _.Move("0", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);

            /*" -789- MOVE SVA-DATA-QUITACAO TO CBCONDEV-DATA-QUITACAO. */
            _.Move(REG_SBI0229B.SVA_DATA_QUITACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO);

            /*" -790- IF SVA-VAL-IOCC EQUAL ZEROS */

            if (REG_SBI0229B.SVA_VAL_IOCC == 00)
            {

                /*" -792- COMPUTE WSHOST-IOF ROUNDED EQUAL (SVA-VAL-TITULO * 0,38 / 100) */
                WSHOST_IOF.Value = (REG_SBI0229B.SVA_VAL_TITULO * 0.38 / 100f);

                /*" -794- MOVE WSHOST-IOF TO SVA-VAL-IOCC. */
                _.Move(WSHOST_IOF, REG_SBI0229B.SVA_VAL_IOCC);
            }


            /*" -796- MOVE SVA-VAL-TITULO TO CBCONDEV-VAL-TITULO. */
            _.Move(REG_SBI0229B.SVA_VAL_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO);

            /*" -798- MOVE SVA-VAL-IOCC TO CBCONDEV-VAL-DESCONTO. */
            _.Move(REG_SBI0229B.SVA_VAL_IOCC, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO);

            /*" -800- MOVE SVA-VAL-OPERACAO TO CBCONDEV-VAL-OPERACAO. */
            _.Move(REG_SBI0229B.SVA_VAL_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO);

            /*" -802- MOVE 1204 TO CBCONDEV-COD-DESPESA. */
            _.Move(1204, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA);

            /*" -805- MOVE 1 TO CBCONDEV-COD-DEVOLUCAO. */
            _.Move(1, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO);

            /*" -806- IF SVA-ORIGEM EQUAL 16 */

            if (REG_SBI0229B.SVA_ORIGEM == 16)
            {

                /*" -807- ADD 1 TO TT-ORIGEM16 */
                W.TT_ORIGEM16.Value = W.TT_ORIGEM16 + 1;

                /*" -809- MOVE 6 TO CBCONDEV-COD-SISTEMA */
                _.Move(6, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);

                /*" -810- ELSE */
            }
            else
            {


                /*" -811- ADD 1 TO TT-ORIGEM16 */
                W.TT_ORIGEM16.Value = W.TT_ORIGEM16 + 1;

                /*" -814- MOVE 7 TO CBCONDEV-COD-SISTEMA. */
                _.Move(7, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);
            }


            /*" -816- MOVE 'BI0229B1' TO CBCONDEV-COD-USU-SOLICITA. */
            _.Move("BI0229B1", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA);

            /*" -819- MOVE SPACES TO CBCONDEV-DATA-CANCELAMENTO CBCONDEV-COD-USU-CANCELA. */
            _.Move("", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA);

            /*" -824- MOVE -1 TO VIND-NULL01 VIND-NULL02. */
            _.Move(-1, VIND_NULL01, VIND_NULL02);

            /*" -824- PERFORM R1250-00-INSERT-CBCONDEV. */

            R1250_00_INSERT_CBCONDEV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-INSERT-CBCONDEV-SECTION */
        private void R1250_00_INSERT_CBCONDEV_SECTION()
        {
            /*" -837- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", W.WABEND.WNR_EXEC_SQL);

            /*" -926- PERFORM R1250_00_INSERT_CBCONDEV_DB_INSERT_1 */

            R1250_00_INSERT_CBCONDEV_DB_INSERT_1();

            /*" -929- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -930- DISPLAY 'R1250- DUPLICIDADE CBCONDEV' */
                _.Display($"R1250- DUPLICIDADE CBCONDEV");

                /*" -931- DISPLAY 'NUM_APOLICE     = ' CBCONDEV-NUM-APOLICE */
                _.Display($"NUM_APOLICE     = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE}");

                /*" -932- DISPLAY 'NUM_ENDOSSO     = ' CBCONDEV-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO     = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO}");

                /*" -933- DISPLAY 'NUM_PARCELA     = ' CBCONDEV-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}");

                /*" -934- ADD 1 TO DU-CBCONDEV */
                W.DU_CBCONDEV.Value = W.DU_CBCONDEV + 1;

                /*" -935- ELSE */
            }
            else
            {


                /*" -936- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -937- DISPLAY 'R1250- ERRO INSERT CBCONDEV' */
                    _.Display($"R1250- ERRO INSERT CBCONDEV");

                    /*" -938- DISPLAY 'NUM_APOLICE     = ' CBCONDEV-NUM-APOLICE */
                    _.Display($"NUM_APOLICE     = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE}");

                    /*" -939- DISPLAY 'NUM_ENDOSSO     = ' CBCONDEV-NUM-ENDOSSO */
                    _.Display($"NUM_ENDOSSO     = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO}");

                    /*" -940- DISPLAY 'NUM_PARCELA     = ' CBCONDEV-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}");

                    /*" -941- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -942- ELSE */
                }
                else
                {


                    /*" -942- ADD 1 TO IN-CBCONDEV. */
                    W.IN_CBCONDEV.Value = W.IN_CBCONDEV + 1;
                }

            }


        }

        [StopWatch]
        /*" R1250-00-INSERT-CBCONDEV-DB-INSERT-1 */
        public void R1250_00_INSERT_CBCONDEV_DB_INSERT_1()
        {
            /*" -926- EXEC SQL INSERT INTO SEGUROS.CB_CONTR_DEVPREMIO (COD_EMPRESA ,TIPO_MOVIMENTO ,NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,DATA_MOVIMENTO ,NUM_SEQUENCIA ,NUM_TITULO ,COD_FONTE ,NUM_RCAP ,NUM_RCAP_COMPLEMEN ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,COD_SUBGRUPO ,NUM_CERTIFICADO ,DATA_OCORRENCIA ,HORA_OPERACAO ,NUM_MATRICULA ,RAMO_EMISSOR ,COD_PRODUTO ,COD_FILIAL ,COD_ESCNEG ,AGE_COBRANCA ,TIPO_FAVORECIDO ,COD_FAVORECIDO ,COD_ENDERECO ,OCORR_ENDERECO ,COD_AGENCIA ,OPERACAO_CONTA ,NUM_CONTA ,DIG_CONTA ,SIT_REGISTRO ,DATA_QUITACAO ,VAL_TITULO ,VAL_DESCONTO ,VAL_OPERACAO ,COD_DESPESA ,COD_DEVOLUCAO ,COD_SISTEMA ,COD_USU_SOLICITA ,TIMESTAMP ,DATA_CANCELAMENTO ,COD_USU_CANCELA) VALUES (:CBCONDEV-COD-EMPRESA ,:CBCONDEV-TIPO-MOVIMENTO ,:CBCONDEV-NUM-CHEQUE-INTERNO ,:CBCONDEV-DIG-CHEQUE-INTERNO ,:CBCONDEV-DATA-MOVIMENTO ,:CBCONDEV-NUM-SEQUENCIA ,:CBCONDEV-NUM-TITULO ,:CBCONDEV-COD-FONTE ,:CBCONDEV-NUM-RCAP ,:CBCONDEV-NUM-RCAP-COMPLEMEN ,:CBCONDEV-NUM-APOLICE ,:CBCONDEV-NUM-ENDOSSO ,:CBCONDEV-NUM-PARCELA ,:CBCONDEV-COD-SUBGRUPO ,:CBCONDEV-NUM-CERTIFICADO ,:CBCONDEV-DATA-OCORRENCIA , CURRENT TIME ,:CBCONDEV-NUM-MATRICULA ,:CBCONDEV-RAMO-EMISSOR ,:CBCONDEV-COD-PRODUTO ,:CBCONDEV-COD-FILIAL ,:CBCONDEV-COD-ESCNEG ,:CBCONDEV-AGE-COBRANCA ,:CBCONDEV-TIPO-FAVORECIDO ,:CBCONDEV-COD-FAVORECIDO ,:CBCONDEV-COD-ENDERECO ,:CBCONDEV-OCORR-ENDERECO ,:CBCONDEV-COD-AGENCIA ,:CBCONDEV-OPERACAO-CONTA ,:CBCONDEV-NUM-CONTA ,:CBCONDEV-DIG-CONTA ,:CBCONDEV-SIT-REGISTRO ,:CBCONDEV-DATA-QUITACAO ,:CBCONDEV-VAL-TITULO ,:CBCONDEV-VAL-DESCONTO ,:CBCONDEV-VAL-OPERACAO ,:CBCONDEV-COD-DESPESA ,:CBCONDEV-COD-DEVOLUCAO ,:CBCONDEV-COD-SISTEMA ,:CBCONDEV-COD-USU-SOLICITA , CURRENT TIMESTAMP ,:CBCONDEV-DATA-CANCELAMENTO:VIND-NULL01 ,:CBCONDEV-COD-USU-CANCELA:VIND-NULL02) END-EXEC. */

            var r1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1 = new R1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1()
            {
                CBCONDEV_COD_EMPRESA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA.ToString(),
                CBCONDEV_TIPO_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO.ToString(),
                CBCONDEV_NUM_CHEQUE_INTERNO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO.ToString(),
                CBCONDEV_DIG_CHEQUE_INTERNO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO.ToString(),
                CBCONDEV_DATA_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.ToString(),
                CBCONDEV_NUM_SEQUENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA.ToString(),
                CBCONDEV_NUM_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO.ToString(),
                CBCONDEV_COD_FONTE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE.ToString(),
                CBCONDEV_NUM_RCAP = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP.ToString(),
                CBCONDEV_NUM_RCAP_COMPLEMEN = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN.ToString(),
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
                CBCONDEV_COD_SUBGRUPO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO.ToString(),
                CBCONDEV_NUM_CERTIFICADO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO.ToString(),
                CBCONDEV_DATA_OCORRENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA.ToString(),
                CBCONDEV_NUM_MATRICULA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA.ToString(),
                CBCONDEV_RAMO_EMISSOR = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR.ToString(),
                CBCONDEV_COD_PRODUTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO.ToString(),
                CBCONDEV_COD_FILIAL = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL.ToString(),
                CBCONDEV_COD_ESCNEG = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG.ToString(),
                CBCONDEV_AGE_COBRANCA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA.ToString(),
                CBCONDEV_TIPO_FAVORECIDO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO.ToString(),
                CBCONDEV_COD_FAVORECIDO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO.ToString(),
                CBCONDEV_COD_ENDERECO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO.ToString(),
                CBCONDEV_OCORR_ENDERECO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO.ToString(),
                CBCONDEV_COD_AGENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA.ToString(),
                CBCONDEV_OPERACAO_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA.ToString(),
                CBCONDEV_NUM_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA.ToString(),
                CBCONDEV_DIG_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA.ToString(),
                CBCONDEV_SIT_REGISTRO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO.ToString(),
                CBCONDEV_DATA_QUITACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO.ToString(),
                CBCONDEV_VAL_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO.ToString(),
                CBCONDEV_VAL_DESCONTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO.ToString(),
                CBCONDEV_VAL_OPERACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO.ToString(),
                CBCONDEV_COD_DESPESA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA.ToString(),
                CBCONDEV_COD_DEVOLUCAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO.ToString(),
                CBCONDEV_COD_SISTEMA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA.ToString(),
                CBCONDEV_COD_USU_SOLICITA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA.ToString(),
                CBCONDEV_DATA_CANCELAMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                CBCONDEV_COD_USU_CANCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1.Execute(r1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -953- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -954- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -955- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -957- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -957- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -962- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -962- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}