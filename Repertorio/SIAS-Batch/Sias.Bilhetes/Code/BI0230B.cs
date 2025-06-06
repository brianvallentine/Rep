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
using Sias.Bilhetes.DB2.BI0230B;

namespace Code
{
    public class BI0230B
    {
        public bool IsCall { get; set; }

        public BI0230B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  BI0230B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  15/05/2018                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  - SUMARIZA PREMIOS PRODUTO VIAGEM  *      */
        /*"      *   ORIGEM 0016,  PARA GERACAO DE BOLETO:                        *      */
        /*"      *                                                                *      */
        /*"      *   GRAVA REGISTRO NA TABELA SEGUROS.GE_CONTROLE_EMISSAO_SIGCB   *      */
        /*"      *   SOLICITANDO O NOSSO NUMERO PARA O SAP.                       *      */
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
        /*"      *                                                                *      */
        /*"      *   EM 09/11/2018 ALTERA:                                        *      */
        /*"      *   VENCIMENTO: D+60 A DATA DE GERA��O DO BOLETO                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04   - DEMANDA 226662/TAREFA 247683                   *      */
        /*"      *               - DEPREZAR REGISTROS/BOLETOS EMITIDOS FORA DO    *      */
        /*"      *                 PERIODO                                        *      */
        /*"      *   EM 10/06/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVSIG01 { get; set; } = new FileBasis(new PIC("X", "0300", "X(0300)"));

        public FileBasis MOVSIG01
        {
            get
            {
                _.Move(REG_SIGDC01, _MOVSIG01); VarBasis.RedefinePassValue(REG_SIGDC01, _MOVSIG01, REG_SIGDC01); return _MOVSIG01;
            }
        }
        public FileBasis _MOVSIG02 { get; set; } = new FileBasis(new PIC("X", "0300", "X(0300)"));

        public FileBasis MOVSIG02
        {
            get
            {
                _.Move(REG_SIGDC02, _MOVSIG02); VarBasis.RedefinePassValue(REG_SIGDC02, _MOVSIG02, REG_SIGDC02); return _MOVSIG02;
            }
        }
        /*"01        REG-SIGDC01             PIC  X(0300).*/
        public StringBasis REG_SIGDC01 { get; set; } = new StringBasis(new PIC("X", "300", "X(0300)."), @"");
        /*"01        REG-SIGDC02             PIC  X(0300).*/
        public StringBasis REG_SIGDC02 { get; set; } = new StringBasis(new PIC("X", "300", "X(0300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-CLIENTE            PIC S9(009)     COMP.*/
        public IntBasis WSHOST_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-DTINIVIG           PIC  X(010).*/
        public StringBasis WSHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WH-DATA-VENCIMENTO        PIC  X(010) VALUE SPACES.*/
        public StringBasis WH_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  W.*/
        public BI0230B_W W { get; set; } = new BI0230B_W();
        public class BI0230B_W : VarBasis
        {
            /*"  03  WFIM-CBCONDEV             PIC  X(001)       VALUE 'N'.*/
            public StringBasis WFIM_CBCONDEV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WTEM-SOLICITACAO          PIC  X(001)       VALUE 'N'.*/
            public StringBasis WTEM_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-CBCONDEV               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis LD_CBCONDEV { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-CBCONDEV               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_CBCONDEV { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RELATORI               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-DATA                   PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_DATA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SITUACAO               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_SITUACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-ORIGEM                 PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DP_ORIGEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DU-MOVIMCOB               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis DU_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-MOVIMCOB               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis IN_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-GE403                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis IN_GE403 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-RELATORI               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis IN_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQ01                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis GV_ARQ01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-ARQ02                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis GV_ARQ02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-QTD16                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis AC_QTD16 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-VAL16                  PIC  9(013)V99    VALUE  ZEROS.*/
            public DoubleBasis AC_VAL16 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03  AC-IOF16                  PIC  9(013)V99    VALUE  ZEROS.*/
            public DoubleBasis AC_IOF16 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03  WS-NRCERT16               PIC  9(015)       VALUE  ZEROS.*/
            public IntBasis WS_NRCERT16 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03  AC-QTD17                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis AC_QTD17 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-VAL17                  PIC  9(013)V99    VALUE  ZEROS.*/
            public DoubleBasis AC_VAL17 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03  AC-IOF17                  PIC  9(013)V99    VALUE  ZEROS.*/
            public DoubleBasis AC_IOF17 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03  WS-NRCERT17               PIC  9(015)       VALUE  ZEROS.*/
            public IntBasis WS_NRCERT17 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI0230B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0230B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0230B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI0230B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0230B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0230B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0230B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0230B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0230B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_BI0230B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI0230B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0230B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0230B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0230B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI0230B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0230B_WTIME_DAYR();
                public class BI0230B_WTIME_DAYR : VarBasis
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

                    public BI0230B_WTIME_DAYR()
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

                public _REDEF_BI0230B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0230B_WS_TIME WS_TIME { get; set; } = new BI0230B_WS_TIME();
            public class BI0230B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-NRCERTIF        PIC  9(015)    VALUE   ZEROS.*/
            }
            public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03         FILLER             REDEFINES      WS-NRCERTIF.*/
            private _REDEF_BI0230B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_BI0230B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_BI0230B_FILLER_5(); _.Move(WS_NRCERTIF, _filler_5); VarBasis.RedefinePassValue(WS_NRCERTIF, _filler_5, WS_NRCERTIF); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_NRCERTIF); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_NRCERTIF); }
            }  //Redefines
            public class _REDEF_BI0230B_FILLER_5 : VarBasis
            {
                /*"      10     WS-CER-ANO         PIC  9(004).*/
                public IntBasis WS_CER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-CER-MES         PIC  9(002).*/
                public IntBasis WS_CER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CER-DIA         PIC  9(002).*/
                public IntBasis WS_CER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CER-NRSEQ       PIC  9(007).*/
                public IntBasis WS_CER_NRSEQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  03        WABEND.*/

                public _REDEF_BI0230B_FILLER_5()
                {
                    WS_CER_ANO.ValueChanged += OnValueChanged;
                    WS_CER_MES.ValueChanged += OnValueChanged;
                    WS_CER_DIA.ValueChanged += OnValueChanged;
                    WS_CER_NRSEQ.ValueChanged += OnValueChanged;
                }

            }
            public BI0230B_WABEND WABEND { get; set; } = new BI0230B_WABEND();
            public class BI0230B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI0230B  '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0230B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  ARQUIVOS-SAIDA.*/
            }
        }
        public BI0230B_ARQUIVOS_SAIDA ARQUIVOS_SAIDA { get; set; } = new BI0230B_ARQUIVOS_SAIDA();
        public class BI0230B_ARQUIVOS_SAIDA : VarBasis
        {
            /*"  03    LC01.*/
            public BI0230B_LC01 LC01 { get; set; } = new BI0230B_LC01();
            public class BI0230B_LC01 : VarBasis
            {
                /*"        10  FILLER          PIC  X(007) VALUE                          'PRODUTO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040) VALUE                          'NOME PRODUTO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"NOME PRODUTO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(013) VALUE                          '      APOLICE'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"      APOLICE");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(016) VALUE                          '  PROPOSTA SIVPF'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"  PROPOSTA SIVPF");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(011) VALUE                          'BILHETE'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"BILHETE");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(004) VALUE                          'RAMO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'QUITACAO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"QUITACAO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(015) VALUE                          '         CGCCPF'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"         CGCCPF");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040) VALUE                          'SEGURADO '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(002) VALUE                          'UF'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(014) VALUE                          '         VALOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"         VALOR");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'INICIO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"INICIO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'TERMINO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TERMINO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040) VALUE                          'OBSERVA'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"OBSERVA");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(026)           VALUE    ' '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" ");
                /*"  03        LD01.*/
            }
            public BI0230B_LD01 LD01 { get; set; } = new BI0230B_LD01();
            public class BI0230B_LD01 : VarBasis
            {
                /*"        10  LD01-CODPRODU   PIC  9(007).*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DESPRODU   PIC  X(040).*/
                public StringBasis LD01_DESPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-NUMAPOL    PIC  9(013).*/
                public IntBasis LD01_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-PROPOSTA   PIC  9(016).*/
                public IntBasis LD01_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-NUMBIL     PIC  9(011).*/
                public IntBasis LD01_NUMBIL { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-RAMO       PIC  9(004).*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTQITBCO   PIC  X(010).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-CGCCPF     PIC  9(015).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-SEGURADO   PIC  X(040).*/
                public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-SIGLAUF    PIC  X(002).*/
                public StringBasis LD01_SIGLAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-VALOR      PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTINIVIG   PIC  X(010).*/
                public StringBasis LD01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTTERVIG   PIC  X(010).*/
                public StringBasis LD01_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-OBSERVA    PIC  X(040).*/
                public StringBasis LD01_OBSERVA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(026)           VALUE    ' '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" ");
                /*"  03        LD09.*/
            }
            public BI0230B_LD09 LD09 { get; set; } = new BI0230B_LD09();
            public class BI0230B_LD09 : VarBasis
            {
                /*"        10  FILLER          PIC  X(007)           VALUE    ' '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040)           VALUE                          'TOTAL PARCELAS EMITIDAS'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL PARCELAS EMITIDAS");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD09-QTDE       PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD09_QTDE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(016)           VALUE    ' '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(011)           VALUE    ' '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(004)           VALUE    ' '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD09-DTVENCTO   PIC  X(010).*/
                public StringBasis LD09_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(015)           VALUE    ' '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040)           VALUE    ' '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(002)           VALUE    ' '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD09-VALOR      PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD09_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010)           VALUE    ' '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010)           VALUE    ' '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040)           VALUE    ' '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @" ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(026)           VALUE    ' '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" ");
                /*"01     LK-PARAM.*/
            }
        }
        public BI0230B_LK_PARAM LK_PARAM { get; set; } = new BI0230B_LK_PARAM();
        public class BI0230B_LK_PARAM : VarBasis
        {
            /*" 05    FILLER                        PIC  X(002).*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*" 05    LK-P-DATA-VENCIMENTO          PIC  X(010).*/
            public StringBasis LK_P_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public BI0230B_V0CBCONDEV V0CBCONDEV { get; set; } = new BI0230B_V0CBCONDEV();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(BI0230B_LK_PARAM BI0230B_LK_PARAM_P, string MOVSIG01_FILE_NAME_P, string MOVSIG02_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAM*/
        {
            try
            {
                this.LK_PARAM = BI0230B_LK_PARAM_P;
                MOVSIG01.SetFile(MOVSIG01_FILE_NAME_P);
                MOVSIG02.SetFile(MOVSIG02_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAM, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -353- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -354- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -356- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -358- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -361- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -362- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -363- DISPLAY 'PROGRAMA EM EXECUCAO BI0230B      ' */
            _.Display($"PROGRAMA EM EXECUCAO BI0230B      ");

            /*" -364- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -365- DISPLAY 'VERSAO V.00 - 16/05/2018          ' */
            _.Display($"VERSAO V.00 - 16/05/2018          ");

            /*" -366- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -367- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -370- DISPLAY ' ' . */
            _.Display($" ");

            /*" -372- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -375- PERFORM R0290-00-TRATA-CBCONDEV. */

            R0290_00_TRATA_CBCONDEV_SECTION();

            /*" -376- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -377- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -378- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -379- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -380- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -381- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -381- DISPLAY 'FIM    BI0230B    ' WTIME-DAYR. */
            _.Display($"FIM    BI0230B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -386- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -391- CLOSE MOVSIG01 MOVSIG02. */
            MOVSIG01.Close();
            MOVSIG02.Close();

            /*" -393- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -394- DISPLAY ' ' */
            _.Display($" ");

            /*" -395- DISPLAY 'BI0230B - FIM NORMAL' */
            _.Display($"BI0230B - FIM NORMAL");

            /*" -398- DISPLAY ' ' */
            _.Display($" ");

            /*" -398- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -407- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -408- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -409- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -410- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -411- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -412- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -413- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -416- DISPLAY 'INICIO BI0230B    ' WTIME-DAYR. */
            _.Display($"INICIO BI0230B    {W.FILLER_4.WTIME_DAYR}");

            /*" -420- OPEN OUTPUT MOVSIG01 MOVSIG02. */
            MOVSIG01.Open(REG_SIGDC01);
            MOVSIG02.Open(REG_SIGDC02);

            /*" -422- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -424- PERFORM R0101-00-VALIDAR-LINKAGE. */

            R0101_00_VALIDAR_LINKAGE_SECTION();

            /*" -426- PERFORM R0150-00-SELECT-V0RELATORIOS. */

            R0150_00_SELECT_V0RELATORIOS_SECTION();

            /*" -427- IF WTEM-SOLICITACAO NOT EQUAL 'S' */

            if (W.WTEM_SOLICITACAO != "S")
            {

                /*" -430- GO TO R9100-00-SEM-SOLICITACAO. */

                R9100_00_SEM_SOLICITACAO_SECTION(); //GOTO
                return;
            }


            /*" -433- PERFORM R0160-00-SELECT-V0CALENDAR. */

            R0160_00_SELECT_V0CALENDAR_SECTION();

            /*" -434- DISPLAY ' ' . */
            _.Display($" ");

            /*" -436- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -438- DISPLAY 'DATA INICIO ........... ' RELATORI-PERI-INICIAL. */
            _.Display($"DATA INICIO ........... {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

            /*" -440- DISPLAY 'DATA TERMINO .......... ' RELATORI-PERI-FINAL. */
            _.Display($"DATA TERMINO .......... {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

            /*" -442- DISPLAY 'DATA VENCIMENTO ....... ' RELATORI-DATA-REFERENCIA. */
            _.Display($"DATA VENCIMENTO ....... {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

            /*" -445- DISPLAY ' ' . */
            _.Display($" ");

            /*" -446- MOVE ZEROS TO WS-NRCERTIF. */
            _.Move(0, W.WS_NRCERTIF);

            /*" -448- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -449- MOVE WDAT-REL-ANO TO WS-CER-ANO. */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.FILLER_5.WS_CER_ANO);

            /*" -450- MOVE WDAT-REL-MES TO WS-CER-MES. */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.FILLER_5.WS_CER_MES);

            /*" -451- MOVE WDAT-REL-DIA TO WS-CER-DIA. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.FILLER_5.WS_CER_DIA);

            /*" -452- MOVE 16 TO WS-CER-NRSEQ. */
            _.Move(16, W.FILLER_5.WS_CER_NRSEQ);

            /*" -454- MOVE WS-NRCERTIF TO WS-NRCERT16. */
            _.Move(W.WS_NRCERTIF, W.WS_NRCERT16);

            /*" -455- MOVE 17 TO WS-CER-NRSEQ. */
            _.Move(17, W.FILLER_5.WS_CER_NRSEQ);

            /*" -458- MOVE WS-NRCERTIF TO WS-NRCERT17. */
            _.Move(W.WS_NRCERTIF, W.WS_NRCERT17);

            /*" -459- WRITE REG-SIGDC01 FROM LC01. */
            _.Move(ARQUIVOS_SAIDA.LC01.GetMoveValues(), REG_SIGDC01);

            MOVSIG01.Write(REG_SIGDC01.GetMoveValues().ToString());

            /*" -462- WRITE REG-SIGDC02 FROM LC01. */
            _.Move(ARQUIVOS_SAIDA.LC01.GetMoveValues(), REG_SIGDC02);

            MOVSIG02.Write(REG_SIGDC02.GetMoveValues().ToString());

            /*" -462- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -475- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -482- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -486- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -487- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -487- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -482- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

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
        /*" R0101-00-VALIDAR-LINKAGE-SECTION */
        private void R0101_00_VALIDAR_LINKAGE_SECTION()
        {
            /*" -498- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", W.WABEND.WNR_EXEC_SQL);

            /*" -499- IF LK-P-DATA-VENCIMENTO = SPACES */

            if (LK_PARAM.LK_P_DATA_VENCIMENTO.IsEmpty())
            {

                /*" -500- DISPLAY 'R0101-00 - INFORMAR DATA DE VENCIMENTO ' */
                _.Display($"R0101-00 - INFORMAR DATA DE VENCIMENTO ");

                /*" -501- DISPLAY '           VIA LINKAGE ' */
                _.Display($"           VIA LINKAGE ");

                /*" -502- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -503- ELSE */
            }
            else
            {


                /*" -511- IF NOT ( ( LK-P-DATA-VENCIMENTO(1:4) >= '1900' AND LK-P-DATA-VENCIMENTO(1:4) <= '9999' ) AND ( LK-P-DATA-VENCIMENTO(5:1) = '-' ) AND ( LK-P-DATA-VENCIMENTO(6:2) >= '01' AND LK-P-DATA-VENCIMENTO(6:2) <= '12' ) AND ( LK-P-DATA-VENCIMENTO(8:1) = '-' ) AND ( LK-P-DATA-VENCIMENTO(9:2) >= '01' AND LK-P-DATA-VENCIMENTO(9:2) <= '31' ) ) */

                if (!((LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(1, 4) >= "1900" && LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(1, 4) <= "9999") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(5, 1) == "-") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(6, 2) >= "01" && LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(6, 2) <= "12") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(8, 1) == "-") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(9, 2) >= "01" && LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(9, 2) <= "31")))
                {

                    /*" -512- DISPLAY 'R0101-00 - DATA DE VENCIMENTO INVALIDA ' */
                    _.Display($"R0101-00 - DATA DE VENCIMENTO INVALIDA ");

                    /*" -513- DISPLAY '         - ' LK-P-DATA-VENCIMENTO */
                    _.Display($"         - {LK_PARAM.LK_P_DATA_VENCIMENTO}");

                    /*" -514- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -515- ELSE */
                }
                else
                {


                    /*" -516- MOVE LK-P-DATA-VENCIMENTO TO WH-DATA-VENCIMENTO */
                    _.Move(LK_PARAM.LK_P_DATA_VENCIMENTO, WH_DATA_VENCIMENTO);

                    /*" -517- END-IF */
                }


                /*" -519- END-IF */
            }


            /*" -521- DISPLAY 'LINKAGE - DATA VENCIMENTO = ' WH-DATA-VENCIMENTO */
            _.Display($"LINKAGE - DATA VENCIMENTO = {WH_DATA_VENCIMENTO}");

            /*" -521- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-V0RELATORIOS-SECTION */
        private void R0150_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -533- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", W.WABEND.WNR_EXEC_SQL);

            /*" -621- PERFORM R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -624- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -625- MOVE 'N' TO WTEM-SOLICITACAO */
                _.Move("N", W.WTEM_SOLICITACAO);

                /*" -626- ELSE */
            }
            else
            {


                /*" -627- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -628- DISPLAY 'R0150-00 - PROBLEMAS NO SELECT(RELATORIOS)' */
                    _.Display($"R0150-00 - PROBLEMAS NO SELECT(RELATORIOS)");

                    /*" -629- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -630- ELSE */
                }
                else
                {


                    /*" -632- IF SISTEMAS-DATA-MOV-ABERTO GREATER RELATORI-PERI-FINAL */

                    if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO > RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL)
                    {

                        /*" -633- MOVE 'S' TO WTEM-SOLICITACAO */
                        _.Move("S", W.WTEM_SOLICITACAO);

                        /*" -634- ELSE */
                    }
                    else
                    {


                        /*" -634- MOVE 'N' TO WTEM-SOLICITACAO. */
                        _.Move("N", W.WTEM_SOLICITACAO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -621- EXEC SQL SELECT COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL ,(PERI_FINAL + 01 DAYS) , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO INTO :RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:WSHOST-DTINIVIG ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA:VIND-NULL01 ,:RELATORI-PERI-RENOVACAO:VIND-NULL02 ,:RELATORI-PCT-AUMENTO:VIND-NULL03 FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'BI' AND COD_RELATORIO = 'BI0230B1' AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(executed_1.RELATORI_IDE_SISTEMA, RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);
                _.Move(executed_1.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(executed_1.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(executed_1.RELATORI_QUANTIDADE, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(executed_1.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(executed_1.WSHOST_DTINIVIG, WSHOST_DTINIVIG);
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(executed_1.RELATORI_MES_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);
                _.Move(executed_1.RELATORI_ANO_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);
                _.Move(executed_1.RELATORI_ORGAO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR);
                _.Move(executed_1.RELATORI_COD_FONTE, RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE);
                _.Move(executed_1.RELATORI_COD_PRODUTOR, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);
                _.Move(executed_1.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(executed_1.RELATORI_COD_MODALIDADE, RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE);
                _.Move(executed_1.RELATORI_COD_CONGENERE, RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE);
                _.Move(executed_1.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(executed_1.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(executed_1.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(executed_1.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(executed_1.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(executed_1.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(executed_1.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(executed_1.RELATORI_COD_PLANO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);
                _.Move(executed_1.RELATORI_OCORR_HISTORICO, RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO);
                _.Move(executed_1.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
                _.Move(executed_1.RELATORI_ENDOS_LIDER, RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER);
                _.Move(executed_1.RELATORI_NUM_PARC_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER);
                _.Move(executed_1.RELATORI_NUM_SINISTRO, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO);
                _.Move(executed_1.RELATORI_NUM_SINI_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER);
                _.Move(executed_1.RELATORI_NUM_ORDEM, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);
                _.Move(executed_1.RELATORI_COD_MOEDA, RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA);
                _.Move(executed_1.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(executed_1.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
                _.Move(executed_1.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(executed_1.RELATORI_IND_ANAL_RESUMO, RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);
                _.Move(executed_1.RELATORI_COD_EMPRESA, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.RELATORI_PERI_RENOVACAO, RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.RELATORI_PCT_AUMENTO, RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-SELECT-V0CALENDAR-SECTION */
        private void R0160_00_SELECT_V0CALENDAR_SECTION()
        {
            /*" -646- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", W.WABEND.WNR_EXEC_SQL);

            /*" -652- PERFORM R0160_00_SELECT_V0CALENDAR_DB_SELECT_1 */

            R0160_00_SELECT_V0CALENDAR_DB_SELECT_1();

            /*" -655- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -656- DISPLAY 'R0160-00 - PROBLEMAS NO SELECT(CALENDAR)  ' */
                _.Display($"R0160-00 - PROBLEMAS NO SELECT(CALENDAR)  ");

                /*" -656- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0160-00-SELECT-V0CALENDAR-DB-SELECT-1 */
        public void R0160_00_SELECT_V0CALENDAR_DB_SELECT_1()
        {
            /*" -652- EXEC SQL SELECT DTH_ULT_DIA_MES INTO :CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WSHOST-DTINIVIG WITH UR END-EXEC. */

            var r0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 = new R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1()
            {
                WSHOST_DTINIVIG = WSHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1.Execute(r0160_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-TRATA-CBCONDEV-SECTION */
        private void R0290_00_TRATA_CBCONDEV_SECTION()
        {
            /*" -669- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", W.WABEND.WNR_EXEC_SQL);

            /*" -670- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -671- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -672- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -673- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -674- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -675- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -678- DISPLAY 'DECLARE CBCONDEV  ' WTIME-DAYR. */
            _.Display($"DECLARE CBCONDEV  {W.FILLER_4.WTIME_DAYR}");

            /*" -680- MOVE RELATORI-DATA-REFERENCIA TO LD09-DTVENCTO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, ARQUIVOS_SAIDA.LD09.LD09_DTVENCTO);

            /*" -687- MOVE ZEROS TO AC-QTD16 AC-VAL16 AC-IOF16 AC-QTD17 AC-VAL17 AC-IOF17. */
            _.Move(0, W.AC_QTD16, W.AC_VAL16, W.AC_IOF16, W.AC_QTD17, W.AC_VAL17, W.AC_IOF17);

            /*" -689- MOVE SPACES TO WFIM-CBCONDEV. */
            _.Move("", W.WFIM_CBCONDEV);

            /*" -690- PERFORM R0300-00-DECLARE-CBCONDEV. */

            R0300_00_DECLARE_CBCONDEV_SECTION();

            /*" -692- PERFORM R0310-00-FETCH-CBCONDEV. */

            R0310_00_FETCH_CBCONDEV_SECTION();

            /*" -696- PERFORM R0320-00-PROCESSA-CBCONDEV UNTIL WFIM-CBCONDEV NOT EQUAL SPACES. */

            while (!(!W.WFIM_CBCONDEV.IsEmpty()))
            {

                R0320_00_PROCESSA_CBCONDEV_SECTION();
            }

            /*" -697- IF AC-VAL16 NOT EQUAL ZEROS */

            if (W.AC_VAL16 != 00)
            {

                /*" -700- PERFORM R1000-00-SOLICITA-BOLETO-ELO. */

                R1000_00_SOLICITA_BOLETO_ELO_SECTION();
            }


            /*" -701- IF AC-VAL17 NOT EQUAL ZEROS */

            if (W.AC_VAL17 != 00)
            {

                /*" -703- PERFORM R1050-00-SOLICITA-BOLETO-WEB. */

                R1050_00_SOLICITA_BOLETO_WEB_SECTION();
            }


            /*" -705- IF AC-VAL16 NOT EQUAL ZEROS OR AC-VAL17 NOT EQUAL ZEROS */

            if (W.AC_VAL16 != 00 || W.AC_VAL17 != 00)
            {

                /*" -708- PERFORM R1300-00-TRATA-RELATORI. */

                R1300_00_TRATA_RELATORI_SECTION();
            }


            /*" -708- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -711- DISPLAY ' ' . */
            _.Display($" ");

            /*" -712- DISPLAY 'LIDOS CBCONDEV ............. ' LD-CBCONDEV */
            _.Display($"LIDOS CBCONDEV ............. {W.LD_CBCONDEV}");

            /*" -713- DISPLAY 'DESPREZA DATA .............. ' DP-DATA */
            _.Display($"DESPREZA DATA .............. {W.DP_DATA}");

            /*" -714- DISPLAY 'DESPREZA SITUACAO .......... ' DP-SITUACAO */
            _.Display($"DESPREZA SITUACAO .......... {W.DP_SITUACAO}");

            /*" -715- DISPLAY 'DESPREZA ORIGEM ............ ' DP-ORIGEM */
            _.Display($"DESPREZA ORIGEM ............ {W.DP_ORIGEM}");

            /*" -716- DISPLAY 'ALTERA CBCONDEV ............ ' UP-CBCONDEV */
            _.Display($"ALTERA CBCONDEV ............ {W.UP_CBCONDEV}");

            /*" -717- DISPLAY 'INSERE MOVIMCOB ............ ' IN-MOVIMCOB */
            _.Display($"INSERE MOVIMCOB ............ {W.IN_MOVIMCOB}");

            /*" -718- DISPLAY 'DUPLICA MOVIMCOB ........... ' DU-MOVIMCOB */
            _.Display($"DUPLICA MOVIMCOB ........... {W.DU_MOVIMCOB}");

            /*" -719- DISPLAY 'INSERE GE403 ............... ' IN-GE403 */
            _.Display($"INSERE GE403 ............... {W.IN_GE403}");

            /*" -720- DISPLAY 'ALTERA RELATORI ............ ' UP-RELATORI */
            _.Display($"ALTERA RELATORI ............ {W.UP_RELATORI}");

            /*" -721- DISPLAY 'INSERE RELATORI ............ ' IN-RELATORI */
            _.Display($"INSERE RELATORI ............ {W.IN_RELATORI}");

            /*" -722- DISPLAY ' ' . */
            _.Display($" ");

            /*" -723- DISPLAY 'GRAVA ARQUIVO ELO ......... ' GV-ARQ01 */
            _.Display($"GRAVA ARQUIVO ELO ......... {W.GV_ARQ01}");

            /*" -724- DISPLAY 'GRAVA ARQUIVO WEB ......... ' GV-ARQ02 */
            _.Display($"GRAVA ARQUIVO WEB ......... {W.GV_ARQ02}");

            /*" -724- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-CBCONDEV-SECTION */
        private void R0300_00_DECLARE_CBCONDEV_SECTION()
        {
            /*" -739- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -775- PERFORM R0300_00_DECLARE_CBCONDEV_DB_DECLARE_1 */

            R0300_00_DECLARE_CBCONDEV_DB_DECLARE_1();

            /*" -777- PERFORM R0300_00_DECLARE_CBCONDEV_DB_OPEN_1 */

            R0300_00_DECLARE_CBCONDEV_DB_OPEN_1();

            /*" -780- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -781- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (CBCONDEV)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (CBCONDEV)   ");

                /*" -784- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -785- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -786- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -787- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -788- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -789- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -790- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -790- DISPLAY 'FETCH   CBCONDEV  ' WTIME-DAYR. */
            _.Display($"FETCH   CBCONDEV  {W.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R0300-00-DECLARE-CBCONDEV-DB-DECLARE-1 */
        public void R0300_00_DECLARE_CBCONDEV_DB_DECLARE_1()
        {
            /*" -775- EXEC SQL DECLARE V0CBCONDEV CURSOR WITH HOLD FOR SELECT COD_EMPRESA ,TIPO_MOVIMENTO ,NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,DATA_MOVIMENTO ,NUM_SEQUENCIA ,NUM_TITULO ,COD_FONTE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,COD_SUBGRUPO ,NUM_CERTIFICADO ,NUM_MATRICULA ,RAMO_EMISSOR ,COD_PRODUTO ,TIPO_FAVORECIDO ,COD_FAVORECIDO ,COD_ENDERECO ,OCORR_ENDERECO ,SIT_REGISTRO ,DATA_QUITACAO ,VAL_TITULO ,VAL_DESCONTO ,VAL_OPERACAO ,COD_SISTEMA FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE COD_EMPRESA = 0 AND TIPO_MOVIMENTO = 'A' AND NUM_CHEQUE_INTERNO = 0 AND DIG_CHEQUE_INTERNO = 0 FOR UPDATE OF NUM_CHEQUE_INTERNO ,NUM_CERTIFICADO ,SIT_REGISTRO END-EXEC. */
            V0CBCONDEV = new BI0230B_V0CBCONDEV(false);
            string GetQuery_V0CBCONDEV()
            {
                var query = @$"SELECT COD_EMPRESA 
							,TIPO_MOVIMENTO 
							,NUM_CHEQUE_INTERNO 
							,DIG_CHEQUE_INTERNO 
							,DATA_MOVIMENTO 
							,NUM_SEQUENCIA 
							,NUM_TITULO 
							,COD_FONTE 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,COD_SUBGRUPO 
							,NUM_CERTIFICADO 
							,NUM_MATRICULA 
							,RAMO_EMISSOR 
							,COD_PRODUTO 
							,TIPO_FAVORECIDO 
							,COD_FAVORECIDO 
							,COD_ENDERECO 
							,OCORR_ENDERECO 
							,SIT_REGISTRO 
							,DATA_QUITACAO 
							,VAL_TITULO 
							,VAL_DESCONTO 
							,VAL_OPERACAO 
							,COD_SISTEMA 
							FROM SEGUROS.CB_CONTR_DEVPREMIO 
							WHERE COD_EMPRESA = 0 
							AND TIPO_MOVIMENTO = 'A' 
							AND NUM_CHEQUE_INTERNO = 0 
							AND DIG_CHEQUE_INTERNO = 0";

                return query;
            }
            V0CBCONDEV.GetQueryEvent += GetQuery_V0CBCONDEV;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-CBCONDEV-DB-OPEN-1 */
        public void R0300_00_DECLARE_CBCONDEV_DB_OPEN_1()
        {
            /*" -777- EXEC SQL OPEN V0CBCONDEV END-EXEC. */

            V0CBCONDEV.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-CBCONDEV-SECTION */
        private void R0310_00_FETCH_CBCONDEV_SECTION()
        {
            /*" -803- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -830- PERFORM R0310_00_FETCH_CBCONDEV_DB_FETCH_1 */

            R0310_00_FETCH_CBCONDEV_DB_FETCH_1();

            /*" -834- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -834- PERFORM R0310_00_FETCH_CBCONDEV_DB_CLOSE_1 */

                R0310_00_FETCH_CBCONDEV_DB_CLOSE_1();

                /*" -836- MOVE 'S' TO WFIM-CBCONDEV */
                _.Move("S", W.WFIM_CBCONDEV);

                /*" -838- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -843- DISPLAY 'R0310-00 - PROBLEMAS FETCH (CBCONDEV)     ' ' APOLICE    ' CBCONDEV-NUM-APOLICE ' ENDOSSO    ' CBCONDEV-NUM-ENDOSSO ' PARCELA    ' CBCONDEV-NUM-PARCELA */

                $"R0310-00 - PROBLEMAS FETCH (CBCONDEV)      APOLICE    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE} ENDOSSO    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO} PARCELA    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}"
                .Display();

                /*" -846- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -848- ADD 1 TO LD-CBCONDEV. */
            W.LD_CBCONDEV.Value = W.LD_CBCONDEV + 1;

            /*" -850- MOVE LD-CBCONDEV TO AC-LIDOS. */
            _.Move(W.LD_CBCONDEV, W.AC_LIDOS);

            /*" -852- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -853- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -854- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -855- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -856- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -857- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -858- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -859- DISPLAY 'LIDOS CBCONDEV     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS CBCONDEV     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-CBCONDEV-DB-FETCH-1 */
        public void R0310_00_FETCH_CBCONDEV_DB_FETCH_1()
        {
            /*" -830- EXEC SQL FETCH V0CBCONDEV INTO :CBCONDEV-COD-EMPRESA ,:CBCONDEV-TIPO-MOVIMENTO ,:CBCONDEV-NUM-CHEQUE-INTERNO ,:CBCONDEV-DIG-CHEQUE-INTERNO ,:CBCONDEV-DATA-MOVIMENTO ,:CBCONDEV-NUM-SEQUENCIA ,:CBCONDEV-NUM-TITULO ,:CBCONDEV-COD-FONTE ,:CBCONDEV-NUM-APOLICE ,:CBCONDEV-NUM-ENDOSSO ,:CBCONDEV-NUM-PARCELA ,:CBCONDEV-COD-SUBGRUPO ,:CBCONDEV-NUM-CERTIFICADO ,:CBCONDEV-NUM-MATRICULA ,:CBCONDEV-RAMO-EMISSOR ,:CBCONDEV-COD-PRODUTO ,:CBCONDEV-TIPO-FAVORECIDO ,:CBCONDEV-COD-FAVORECIDO ,:CBCONDEV-COD-ENDERECO ,:CBCONDEV-OCORR-ENDERECO ,:CBCONDEV-SIT-REGISTRO ,:CBCONDEV-DATA-QUITACAO ,:CBCONDEV-VAL-TITULO ,:CBCONDEV-VAL-DESCONTO ,:CBCONDEV-VAL-OPERACAO ,:CBCONDEV-COD-SISTEMA END-EXEC. */

            if (V0CBCONDEV.Fetch())
            {
                _.Move(V0CBCONDEV.CBCONDEV_COD_EMPRESA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA);
                _.Move(V0CBCONDEV.CBCONDEV_TIPO_MOVIMENTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);
                _.Move(V0CBCONDEV.CBCONDEV_DIG_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);
                _.Move(V0CBCONDEV.CBCONDEV_DATA_MOVIMENTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_SEQUENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO);
                _.Move(V0CBCONDEV.CBCONDEV_COD_FONTE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_APOLICE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_ENDOSSO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_PARCELA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA);
                _.Move(V0CBCONDEV.CBCONDEV_COD_SUBGRUPO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_CERTIFICADO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_MATRICULA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA);
                _.Move(V0CBCONDEV.CBCONDEV_RAMO_EMISSOR, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR);
                _.Move(V0CBCONDEV.CBCONDEV_COD_PRODUTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO);
                _.Move(V0CBCONDEV.CBCONDEV_TIPO_FAVORECIDO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO);
                _.Move(V0CBCONDEV.CBCONDEV_COD_FAVORECIDO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO);
                _.Move(V0CBCONDEV.CBCONDEV_COD_ENDERECO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO);
                _.Move(V0CBCONDEV.CBCONDEV_OCORR_ENDERECO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO);
                _.Move(V0CBCONDEV.CBCONDEV_SIT_REGISTRO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);
                _.Move(V0CBCONDEV.CBCONDEV_DATA_QUITACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO);
                _.Move(V0CBCONDEV.CBCONDEV_VAL_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO);
                _.Move(V0CBCONDEV.CBCONDEV_VAL_DESCONTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO);
                _.Move(V0CBCONDEV.CBCONDEV_VAL_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO);
                _.Move(V0CBCONDEV.CBCONDEV_COD_SISTEMA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-CBCONDEV-DB-CLOSE-1 */
        public void R0310_00_FETCH_CBCONDEV_DB_CLOSE_1()
        {
            /*" -834- EXEC SQL CLOSE V0CBCONDEV END-EXEC */

            V0CBCONDEV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-CBCONDEV-SECTION */
        private void R0320_00_PROCESSA_CBCONDEV_SECTION()
        {
            /*" -874- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.WABEND.WNR_EXEC_SQL);

            /*" -876- IF CBCONDEV-DATA-QUITACAO GREATER WH-DATA-VENCIMENTO */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO > WH_DATA_VENCIMENTO)
            {

                /*" -877- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -880- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -882- IF CBCONDEV-DATA-QUITACAO GREATER RELATORI-PERI-FINAL */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO > RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL)
            {

                /*" -883- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -886- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -887- IF CBCONDEV-SIT-REGISTRO NOT EQUAL '0' */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO != "0")
            {

                /*" -888- ADD 1 TO DP-SITUACAO */
                W.DP_SITUACAO.Value = W.DP_SITUACAO + 1;

                /*" -891- GO TO R0320-90-LEITURA. */

                R0320_90_LEITURA(); //GOTO
                return;
            }


            /*" -895- MOVE CBCONDEV-COD-FAVORECIDO TO WSHOST-CLIENTE. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO, WSHOST_CLIENTE);

            /*" -896- IF CBCONDEV-COD-SISTEMA EQUAL 6 */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA == 6)
            {

                /*" -897- PERFORM R0360-00-TRATA-ELOSERVICOS */

                R0360_00_TRATA_ELOSERVICOS_SECTION();

                /*" -898- ELSE */
            }
            else
            {


                /*" -899- IF CBCONDEV-COD-SISTEMA EQUAL 7 */

                if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA == 7)
                {

                    /*" -900- PERFORM R0370-00-TRATA-WEBTURISMO */

                    R0370_00_TRATA_WEBTURISMO_SECTION();

                    /*" -901- ELSE */
                }
                else
                {


                    /*" -902- ADD 1 TO DP-ORIGEM */
                    W.DP_ORIGEM.Value = W.DP_ORIGEM + 1;

                    /*" -905- GO TO R0320-90-LEITURA. */

                    R0320_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -905- PERFORM R0450-00-UPDATE-CBCONDEV. */

            R0450_00_UPDATE_CBCONDEV_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_90_LEITURA */

            R0320_90_LEITURA();

        }

        [StopWatch]
        /*" R0320-90-LEITURA */
        private void R0320_90_LEITURA(bool isPerform = false)
        {
            /*" -910- PERFORM R0310-00-FETCH-CBCONDEV. */

            R0310_00_FETCH_CBCONDEV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-TRATA-ELOSERVICOS-SECTION */
        private void R0360_00_TRATA_ELOSERVICOS_SECTION()
        {
            /*" -922- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", W.WABEND.WNR_EXEC_SQL);

            /*" -925- MOVE WS-NRCERT16 TO CBCONDEV-NUM-CERTIFICADO. */
            _.Move(W.WS_NRCERT16, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -926- ADD 1 TO AC-QTD16. */
            W.AC_QTD16.Value = W.AC_QTD16 + 1;

            /*" -928- ADD CBCONDEV-VAL-TITULO TO AC-VAL16. */
            W.AC_VAL16.Value = W.AC_VAL16 + CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO;

            /*" -932- ADD CBCONDEV-VAL-DESCONTO TO AC-IOF16. */
            W.AC_IOF16.Value = W.AC_IOF16 + CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO;

            /*" -935- PERFORM R2000-00-TRATA-ARQUIVO. */

            R2000_00_TRATA_ARQUIVO_SECTION();

            /*" -936- WRITE REG-SIGDC01 FROM LD01. */
            _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SIGDC01);

            MOVSIG01.Write(REG_SIGDC01.GetMoveValues().ToString());

            /*" -936- ADD 1 TO GV-ARQ01. */
            W.GV_ARQ01.Value = W.GV_ARQ01 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-TRATA-WEBTURISMO-SECTION */
        private void R0370_00_TRATA_WEBTURISMO_SECTION()
        {
            /*" -949- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", W.WABEND.WNR_EXEC_SQL);

            /*" -952- MOVE WS-NRCERT17 TO CBCONDEV-NUM-CERTIFICADO. */
            _.Move(W.WS_NRCERT17, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -953- ADD 1 TO AC-QTD17. */
            W.AC_QTD17.Value = W.AC_QTD17 + 1;

            /*" -955- ADD CBCONDEV-VAL-TITULO TO AC-VAL17. */
            W.AC_VAL17.Value = W.AC_VAL17 + CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO;

            /*" -959- ADD CBCONDEV-VAL-DESCONTO TO AC-IOF17. */
            W.AC_IOF17.Value = W.AC_IOF17 + CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO;

            /*" -962- PERFORM R2000-00-TRATA-ARQUIVO. */

            R2000_00_TRATA_ARQUIVO_SECTION();

            /*" -963- WRITE REG-SIGDC02 FROM LD01. */
            _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SIGDC02);

            MOVSIG02.Write(REG_SIGDC02.GetMoveValues().ToString());

            /*" -963- ADD 1 TO GV-ARQ02. */
            W.GV_ARQ02.Value = W.GV_ARQ02 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-UPDATE-CBCONDEV-SECTION */
        private void R0450_00_UPDATE_CBCONDEV_SECTION()
        {
            /*" -976- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -983- PERFORM R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1 */

            R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1();

            /*" -987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -988- DISPLAY 'R0450-00 - PROBLEMAS NO UPDATE(CBCONDEV) ' */
                _.Display($"R0450-00 - PROBLEMAS NO UPDATE(CBCONDEV) ");

                /*" -991- DISPLAY ' APOLICE = ' CBCONDEV-NUM-APOLICE ' ENDOSSO = ' CBCONDEV-NUM-ENDOSSO ' PARCELA = ' CBCONDEV-NUM-PARCELA */

                $" APOLICE = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE} ENDOSSO = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO} PARCELA = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}"
                .Display();

                /*" -992- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -993- ELSE */
            }
            else
            {


                /*" -993- ADD 1 TO UP-CBCONDEV. */
                W.UP_CBCONDEV.Value = W.UP_CBCONDEV + 1;
            }


        }

        [StopWatch]
        /*" R0450-00-UPDATE-CBCONDEV-DB-UPDATE-1 */
        public void R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1()
        {
            /*" -983- EXEC SQL UPDATE SEGUROS.CB_CONTR_DEVPREMIO SET NUM_CHEQUE_INTERNO = 1 ,NUM_CERTIFICADO = :CBCONDEV-NUM-CERTIFICADO ,SIT_REGISTRO = '1' WHERE CURRENT OF V0CBCONDEV END-EXEC. */

            var r0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1 = new R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1(V0CBCONDEV)
            {
                CBCONDEV_NUM_CERTIFICADO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO.ToString(),
            };

            R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1.Execute(r0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SOLICITA-BOLETO-ELO-SECTION */
        private void R1000_00_SOLICITA_BOLETO_ELO_SECTION()
        {
            /*" -1006- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1007- MOVE AC-QTD16 TO LD09-QTDE. */
            _.Move(W.AC_QTD16, ARQUIVOS_SAIDA.LD09.LD09_QTDE);

            /*" -1009- MOVE AC-VAL16 TO LD09-VALOR MOVIMCOB-VAL-TITULO. */
            _.Move(W.AC_VAL16, ARQUIVOS_SAIDA.LD09.LD09_VALOR, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -1012- MOVE AC-IOF16 TO MOVIMCOB-VAL-IOCC. */
            _.Move(W.AC_IOF16, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

            /*" -1015- WRITE REG-SIGDC01 FROM LD09. */
            _.Move(ARQUIVOS_SAIDA.LD09.GetMoveValues(), REG_SIGDC01);

            MOVSIG01.Write(REG_SIGDC01.GetMoveValues().ToString());

            /*" -1017- MOVE ZEROS TO MOVIMCOB-COD-EMPRESA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -1019- MOVE ZEROS TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -1021- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -1023- MOVE 630 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(630, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -1025- MOVE ZEROS TO MOVIMCOB-NUM-AVISO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -1027- MOVE ZEROS TO MOVIMCOB-NUM-FITA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -1029- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMCOB-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -1031- MOVE RELATORI-DATA-REFERENCIA TO MOVIMCOB-DATA-QUITACAO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

            /*" -1033- MOVE ZEROS TO MOVIMCOB-NUM-TITULO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1035- MOVE RELATORI-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -1037- MOVE RELATORI-NUM-ENDOSSO TO MOVIMCOB-NUM-ENDOSSO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);

            /*" -1039- MOVE RELATORI-NUM-PARCELA TO MOVIMCOB-NUM-PARCELA. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -1041- MOVE ZEROS TO MOVIMCOB-VAL-CREDITO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -1043- MOVE ' ' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move(" ", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1045- MOVE '009227084000175ELO SERVICOS S.A' TO MOVIMCOB-NOME-SEGURADO. */
            _.Move("009227084000175ELO SERVICOS S.A", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -1047- MOVE 'A' TO MOVIMCOB-TIPO-MOVIMENTO. */
            _.Move("A", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

            /*" -1051- MOVE WS-NRCERT16 TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(W.WS_NRCERT16, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1052- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -1054- MOVE 6920 TO LK-GE350-COD-PRODUTO. */
            _.Move(6920, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -1056- PERFORM R1100-00-CHAMA-GE0350S. */

            R1100_00_CHAMA_GE0350S_SECTION();

            /*" -1056- PERFORM R1250-00-INSERT-MOVIMCOB. */

            R1250_00_INSERT_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SOLICITA-BOLETO-WEB-SECTION */
        private void R1050_00_SOLICITA_BOLETO_WEB_SECTION()
        {
            /*" -1069- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", W.WABEND.WNR_EXEC_SQL);

            /*" -1070- MOVE AC-QTD17 TO LD09-QTDE. */
            _.Move(W.AC_QTD17, ARQUIVOS_SAIDA.LD09.LD09_QTDE);

            /*" -1072- MOVE AC-VAL17 TO LD09-VALOR MOVIMCOB-VAL-TITULO. */
            _.Move(W.AC_VAL17, ARQUIVOS_SAIDA.LD09.LD09_VALOR, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -1075- MOVE AC-IOF17 TO MOVIMCOB-VAL-IOCC. */
            _.Move(W.AC_IOF17, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

            /*" -1078- WRITE REG-SIGDC02 FROM LD09. */
            _.Move(ARQUIVOS_SAIDA.LD09.GetMoveValues(), REG_SIGDC02);

            MOVSIG02.Write(REG_SIGDC02.GetMoveValues().ToString());

            /*" -1080- MOVE ZEROS TO MOVIMCOB-COD-EMPRESA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -1082- MOVE ZEROS TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -1084- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -1086- MOVE 630 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(630, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -1088- MOVE ZEROS TO MOVIMCOB-NUM-AVISO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -1090- MOVE ZEROS TO MOVIMCOB-NUM-FITA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -1092- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMCOB-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -1094- MOVE RELATORI-DATA-REFERENCIA TO MOVIMCOB-DATA-QUITACAO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

            /*" -1096- MOVE ZEROS TO MOVIMCOB-NUM-TITULO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1098- MOVE RELATORI-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -1100- MOVE RELATORI-NUM-ENDOSSO TO MOVIMCOB-NUM-ENDOSSO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);

            /*" -1102- MOVE RELATORI-NUM-PARCELA TO MOVIMCOB-NUM-PARCELA. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -1104- MOVE ZEROS TO MOVIMCOB-VAL-CREDITO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -1106- MOVE ' ' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move(" ", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1108- MOVE '016912596000136WEB PREMIOS TURISMO' TO MOVIMCOB-NOME-SEGURADO. */
            _.Move("016912596000136WEB PREMIOS TURISMO", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -1110- MOVE 'A' TO MOVIMCOB-TIPO-MOVIMENTO. */
            _.Move("A", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

            /*" -1114- MOVE WS-NRCERT17 TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(W.WS_NRCERT17, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1115- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -1117- MOVE 6922 TO LK-GE350-COD-PRODUTO. */
            _.Move(6922, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -1119- PERFORM R1100-00-CHAMA-GE0350S. */

            R1100_00_CHAMA_GE0350S_SECTION();

            /*" -1119- PERFORM R1250-00-INSERT-MOVIMCOB. */

            R1250_00_INSERT_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CHAMA-GE0350S-SECTION */
        private void R1100_00_CHAMA_GE0350S_SECTION()
        {
            /*" -1135- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", W.WABEND.WNR_EXEC_SQL);

            /*" -1137- MOVE 02 TO LK-GE350-COD-FUNCAO. */
            _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -1139- MOVE MOVIMCOB-NUM-APOLICE TO LK-GE350-NUM-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -1141- MOVE MOVIMCOB-NUM-ENDOSSO TO LK-GE350-NUM-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -1143- MOVE MOVIMCOB-NUM-PARCELA TO LK-GE350-NUM-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -1145- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-GE350-DTA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -1147- MOVE ZEROS TO LK-GE350-NUM-OCORR-MOVTO. */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

            /*" -1149- MOVE MOVIMCOB-DATA-QUITACAO TO LK-GE350-DTA-VENCIMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -1151- MOVE MOVIMCOB-VAL-TITULO TO LK-GE350-VLR-PREMIO-TOTAL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

            /*" -1153- MOVE MOVIMCOB-VAL-IOCC TO LK-GE350-VLR-IOF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

            /*" -1155- MOVE 01 TO LK-GE350-QTD-PARCELA. */
            _.Move(01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

            /*" -1157- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA. */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -1159- MOVE 'BI' TO LK-GE350-IDE-SISTEMA. */
            _.Move("BI", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -1161- MOVE 'BI0230B1' TO LK-GE350-COD-USUARIO. */
            _.Move("BI0230B1", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -1163- MOVE 'P' TO LK-GE350-COD-SITUACAO. */
            _.Move("P", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -1167- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LK-GE350-NUM-CERTIFICADO LK-GE350-NUM-TITULO LK-GE350-NUM-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -1171- MOVE WSHOST-CLIENTE TO LK-GE350-COD-CLIENTE. */
            _.Move(WSHOST_CLIENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -1173- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -1174- IF LK-GE350-COD-RETORNO NOT EQUAL '0' */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
            {

                /*" -1175- DISPLAY ' ' */
                _.Display($" ");

                /*" -1176- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1177- DISPLAY '*    R1100-00-                          *' */
                _.Display($"*    R1100-00-                          *");

                /*" -1178- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -1179- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1180- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -1181- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -1182- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -1183- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1186- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1186- ADD 1 TO IN-GE403. */
            W.IN_GE403.Value = W.IN_GE403 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-INSERT-MOVIMCOB-SECTION */
        private void R1250_00_INSERT_MOVIMCOB_SECTION()
        {
            /*" -1199- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", W.WABEND.WNR_EXEC_SQL);

            /*" -1242- PERFORM R1250_00_INSERT_MOVIMCOB_DB_INSERT_1 */

            R1250_00_INSERT_MOVIMCOB_DB_INSERT_1();

            /*" -1245- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1246- DISPLAY 'R1250- ERRO INSERT MOVIMCOB' */
                _.Display($"R1250- ERRO INSERT MOVIMCOB");

                /*" -1247- DISPLAY 'NUM_APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM_APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1248- DISPLAY 'NUM_ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1249- DISPLAY 'NUM_PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1250- ADD 1 TO DU-MOVIMCOB */
                W.DU_MOVIMCOB.Value = W.DU_MOVIMCOB + 1;

                /*" -1251- ELSE */
            }
            else
            {


                /*" -1252- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1253- DISPLAY 'R1250- ERRO INSERT MOVIMCOB' */
                    _.Display($"R1250- ERRO INSERT MOVIMCOB");

                    /*" -1254- DISPLAY 'NUM_APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                    _.Display($"NUM_APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                    /*" -1255- DISPLAY 'NUM_ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                    _.Display($"NUM_ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                    /*" -1256- DISPLAY 'NUM_PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                    /*" -1257- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1258- ELSE */
                }
                else
                {


                    /*" -1258- ADD 1 TO IN-MOVIMCOB. */
                    W.IN_MOVIMCOB.Value = W.IN_MOVIMCOB + 1;
                }

            }


        }

        [StopWatch]
        /*" R1250-00-INSERT-MOVIMCOB-DB-INSERT-1 */
        public void R1250_00_INSERT_MOVIMCOB_DB_INSERT_1()
        {
            /*" -1242- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_COBRANCA (COD_EMPRESA ,COD_MOVIMENTO ,COD_BANCO ,COD_AGENCIA ,NUM_AVISO ,NUM_FITA ,DATA_MOVIMENTO ,DATA_QUITACAO ,NUM_TITULO ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,VAL_TITULO ,VAL_IOCC ,VAL_CREDITO ,SIT_REGISTRO ,TIMESTAMP ,NOME_SEGURADO ,TIPO_MOVIMENTO ,NUM_NOSSO_TITULO) VALUES (:MOVIMCOB-COD-EMPRESA ,:MOVIMCOB-COD-MOVIMENTO ,:MOVIMCOB-COD-BANCO ,:MOVIMCOB-COD-AGENCIA ,:MOVIMCOB-NUM-AVISO ,:MOVIMCOB-NUM-FITA ,:MOVIMCOB-DATA-MOVIMENTO ,:MOVIMCOB-DATA-QUITACAO ,:MOVIMCOB-NUM-TITULO ,:MOVIMCOB-NUM-APOLICE ,:MOVIMCOB-NUM-ENDOSSO ,:MOVIMCOB-NUM-PARCELA ,:MOVIMCOB-VAL-TITULO ,:MOVIMCOB-VAL-IOCC ,:MOVIMCOB-VAL-CREDITO ,:MOVIMCOB-SIT-REGISTRO , CURRENT TIMESTAMP ,:MOVIMCOB-NOME-SEGURADO ,:MOVIMCOB-TIPO-MOVIMENTO ,:MOVIMCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1 = new R1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1()
            {
                MOVIMCOB_COD_EMPRESA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA.ToString(),
                MOVIMCOB_COD_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_FITA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA.ToString(),
                MOVIMCOB_DATA_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.ToString(),
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_VAL_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.ToString(),
                MOVIMCOB_VAL_IOCC = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC.ToString(),
                MOVIMCOB_VAL_CREDITO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.ToString(),
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_NOME_SEGURADO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO.ToString(),
                MOVIMCOB_TIPO_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1.Execute(r1250_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-TRATA-RELATORI-SECTION */
        private void R1300_00_TRATA_RELATORI_SECTION()
        {
            /*" -1271- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", W.WABEND.WNR_EXEC_SQL);

            /*" -1274- PERFORM R1350-00-UPDATE-RELATORI. */

            R1350_00_UPDATE_RELATORI_SECTION();

            /*" -1276- ADD 1 TO RELATORI-NUM-ENDOSSO. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO + 1;

            /*" -1278- MOVE '0' TO RELATORI-SIT-REGISTRO. */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -1281- MOVE WSHOST-DTINIVIG TO RELATORI-PERI-INICIAL. */
            _.Move(WSHOST_DTINIVIG, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);

            /*" -1282- IF RELATORI-PERI-FINAL EQUAL '2018-03-31' */

            if (RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL == "2018-03-31")
            {

                /*" -1284- MOVE '2018-05-31' TO RELATORI-PERI-FINAL */
                _.Move("2018-05-31", RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);

                /*" -1285- ELSE */
            }
            else
            {


                /*" -1292- MOVE CALENDAR-DTH-ULT-DIA-MES TO RELATORI-PERI-FINAL. */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
            }


            /*" -1295- PERFORM R1360-00-SELECT-V0CALENDAR. */

            R1360_00_SELECT_V0CALENDAR_SECTION();

            /*" -1295- PERFORM R5000-00-INSERT-RELATORI. */

            R5000_00_INSERT_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-UPDATE-RELATORI-SECTION */
        private void R1350_00_UPDATE_RELATORI_SECTION()
        {
            /*" -1308- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", W.WABEND.WNR_EXEC_SQL);

            /*" -1315- PERFORM R1350_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R1350_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -1319- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1320- DISPLAY 'R1350-00 - PROBLEMAS NO UPDATE(RELATORI) ' */
                _.Display($"R1350-00 - PROBLEMAS NO UPDATE(RELATORI) ");

                /*" -1322- DISPLAY ' SISTEMA  = ' RELATORI-IDE-SISTEMA ' RELATORI = ' RELATORI-COD-RELATORIO */

                $" SISTEMA  = {RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA} RELATORI = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}"
                .Display();

                /*" -1323- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1324- ELSE */
            }
            else
            {


                /*" -1324- ADD 1 TO UP-RELATORI. */
                W.UP_RELATORI.Value = W.UP_RELATORI + 1;
            }


        }

        [StopWatch]
        /*" R1350-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R1350_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -1315- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE IDE_SISTEMA = 'BI' AND COD_RELATORIO = 'BI0230B1' AND SIT_REGISTRO = '0' END-EXEC. */

            var r1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
            };

            R1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r1350_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1360-00-SELECT-V0CALENDAR-SECTION */
        private void R1360_00_SELECT_V0CALENDAR_SECTION()
        {
            /*" -1336- MOVE '1360' TO WNR-EXEC-SQL. */
            _.Move("1360", W.WABEND.WNR_EXEC_SQL);

            /*" -1342- PERFORM R1360_00_SELECT_V0CALENDAR_DB_SELECT_1 */

            R1360_00_SELECT_V0CALENDAR_DB_SELECT_1();

            /*" -1345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1346- DISPLAY 'R1360-00 - PROBLEMAS NO SELECT(CALENDAR)  ' */
                _.Display($"R1360-00 - PROBLEMAS NO SELECT(CALENDAR)  ");

                /*" -1346- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1360-00-SELECT-V0CALENDAR-DB-SELECT-1 */
        public void R1360_00_SELECT_V0CALENDAR_DB_SELECT_1()
        {
            /*" -1342- EXEC SQL SELECT (DATA_CALENDARIO + 60 DAYS) INTO :RELATORI-DATA-REFERENCIA FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :RELATORI-PERI-FINAL WITH UR END-EXEC. */

            var r1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1 = new R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1()
            {
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
            };

            var executed_1 = R1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1.Execute(r1360_00_SELECT_V0CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1360_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-TRATA-ARQUIVO-SECTION */
        private void R2000_00_TRATA_ARQUIVO_SECTION()
        {
            /*" -1359- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -1361- MOVE SPACES TO LD01-OBSERVA. */
            _.Move("", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

            /*" -1363- MOVE CBCONDEV-NUM-APOLICE TO LD01-NUMAPOL. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUMAPOL);

            /*" -1365- MOVE CBCONDEV-COD-PRODUTO TO LD01-CODPRODU. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_CODPRODU);

            /*" -1367- MOVE CBCONDEV-NUM-CERTIFICADO TO LD01-PROPOSTA. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO, ARQUIVOS_SAIDA.LD01.LD01_PROPOSTA);

            /*" -1369- MOVE CBCONDEV-NUM-TITULO TO LD01-NUMBIL. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO, ARQUIVOS_SAIDA.LD01.LD01_NUMBIL);

            /*" -1371- MOVE CBCONDEV-RAMO-EMISSOR TO LD01-RAMO. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR, ARQUIVOS_SAIDA.LD01.LD01_RAMO);

            /*" -1373- MOVE CBCONDEV-DATA-QUITACAO TO LD01-DTQITBCO. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO, ARQUIVOS_SAIDA.LD01.LD01_DTQITBCO);

            /*" -1377- MOVE CBCONDEV-VAL-TITULO TO LD01-VALOR. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO, ARQUIVOS_SAIDA.LD01.LD01_VALOR);

            /*" -1379- MOVE CBCONDEV-COD-FAVORECIDO TO ENDERECO-COD-CLIENTE. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1381- MOVE CBCONDEV-COD-ENDERECO TO ENDERECO-COD-ENDERECO. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);

            /*" -1384- MOVE CBCONDEV-OCORR-ENDERECO TO ENDERECO-OCORR-ENDERECO. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -1386- PERFORM R2410-00-SELECT-ENDERECOS. */

            R2410_00_SELECT_ENDERECOS_SECTION();

            /*" -1389- MOVE ENDERECO-SIGLA-UF TO LD01-SIGLAUF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, ARQUIVOS_SAIDA.LD01.LD01_SIGLAUF);

            /*" -1391- PERFORM R2420-00-SELECT-CLIENTES. */

            R2420_00_SELECT_CLIENTES_SECTION();

            /*" -1393- MOVE CLIENTES-NOME-RAZAO TO LD01-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, ARQUIVOS_SAIDA.LD01.LD01_SEGURADO);

            /*" -1396- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, ARQUIVOS_SAIDA.LD01.LD01_CGCCPF);

            /*" -1398- PERFORM R2430-00-SELECT-PRODUTO. */

            R2430_00_SELECT_PRODUTO_SECTION();

            /*" -1401- MOVE PRODUTO-DESCR-PRODUTO TO LD01-DESPRODU. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_DESPRODU);

            /*" -1403- PERFORM R2450-00-SELECT-ENDOSSOS. */

            R2450_00_SELECT_ENDOSSOS_SECTION();

            /*" -1405- MOVE ENDOSSOS-DATA-INIVIGENCIA TO LD01-DTINIVIG. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

            /*" -1406- MOVE ENDOSSOS-DATA-TERVIGENCIA TO LD01-DTTERVIG. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DTTERVIG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-SELECT-ENDERECOS-SECTION */
        private void R2410_00_SELECT_ENDERECOS_SECTION()
        {
            /*" -1418- MOVE '2410' TO WNR-EXEC-SQL. */
            _.Move("2410", W.WABEND.WNR_EXEC_SQL);

            /*" -1429- PERFORM R2410_00_SELECT_ENDERECOS_DB_SELECT_1 */

            R2410_00_SELECT_ENDERECOS_DB_SELECT_1();

            /*" -1432- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1434- MOVE 'DF' TO ENDERECO-SIGLA-UF */
                _.Move("DF", ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

                /*" -1435- ELSE */
            }
            else
            {


                /*" -1436- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1437- DISPLAY 'R2410-00 - PROBLEMAS NO SELECT(ENDERECOS)' */
                    _.Display($"R2410-00 - PROBLEMAS NO SELECT(ENDERECOS)");

                    /*" -1437- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2410-00-SELECT-ENDERECOS-DB-SELECT-1 */
        public void R2410_00_SELECT_ENDERECOS_DB_SELECT_1()
        {
            /*" -1429- EXEC SQL SELECT COD_ENDERECO ,SIGLA_UF INTO :ENDERECO-COD-ENDERECO ,:ENDERECO-SIGLA-UF FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE AND COD_ENDERECO = :ENDERECO-COD-ENDERECO AND OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1 = new R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_COD_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO.ToString(),
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1.Execute(r2410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2420-00-SELECT-CLIENTES-SECTION */
        private void R2420_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1449- MOVE '2420' TO WNR-EXEC-SQL. */
            _.Move("2420", W.WABEND.WNR_EXEC_SQL);

            /*" -1460- PERFORM R2420_00_SELECT_CLIENTES_DB_SELECT_1 */

            R2420_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1463- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1465- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1467- MOVE ZEROS TO CLIENTES-CGCCPF */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                /*" -1468- ELSE */
            }
            else
            {


                /*" -1469- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1470- DISPLAY 'R2420-00 - PROBLEMAS NO SELECT(CLIENTES) ' */
                    _.Display($"R2420-00 - PROBLEMAS NO SELECT(CLIENTES) ");

                    /*" -1470- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2420-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R2420_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1460- EXEC SQL SELECT UCASE(NOME_RAZAO) ,UCASE(TIPO_PESSOA) ,CGCCPF INTO :CLIENTES-NOME-RAZAO ,:CLIENTES-TIPO-PESSOA ,:CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2420_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R2420_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2420_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r2420_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2430-00-SELECT-PRODUTO-SECTION */
        private void R2430_00_SELECT_PRODUTO_SECTION()
        {
            /*" -1482- MOVE '2430' TO WNR-EXEC-SQL. */
            _.Move("2430", W.WABEND.WNR_EXEC_SQL);

            /*" -1489- PERFORM R2430_00_SELECT_PRODUTO_DB_SELECT_1 */

            R2430_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -1492- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1494- MOVE SPACES TO PRODUTO-DESCR-PRODUTO */
                _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);

                /*" -1495- ELSE */
            }
            else
            {


                /*" -1496- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1497- DISPLAY 'R2430-00 - PROBLEMAS NO SELECT(PRODUTO)  ' */
                    _.Display($"R2430-00 - PROBLEMAS NO SELECT(PRODUTO)  ");

                    /*" -1497- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2430-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R2430_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -1489- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :CBCONDEV-COD-PRODUTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2430_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R2430_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                CBCONDEV_COD_PRODUTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO.ToString(),
            };

            var executed_1 = R2430_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r2430_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2430_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-SELECT-ENDOSSOS-SECTION */
        private void R2450_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1509- MOVE '2450' TO WNR-EXEC-SQL. */
            _.Move("2450", W.WABEND.WNR_EXEC_SQL);

            /*" -1519- PERFORM R2450_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R2450_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1523- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1526- MOVE SPACES TO ENDOSSOS-DATA-INIVIGENCIA ENDOSSOS-DATA-TERVIGENCIA */
                _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                /*" -1527- ELSE */
            }
            else
            {


                /*" -1528- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1529- DISPLAY 'R2450-00 - PROBLEMAS NO SELECT(ENDOSSOS) ' */
                    _.Display($"R2450-00 - PROBLEMAS NO SELECT(ENDOSSOS) ");

                    /*" -1529- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2450-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R2450_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1519- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :CBCONDEV-NUM-APOLICE AND NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r2450_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERT-RELATORI-SECTION */
        private void R5000_00_INSERT_RELATORI_SECTION()
        {
            /*" -1542- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", W.WABEND.WNR_EXEC_SQL);

            /*" -1627- PERFORM R5000_00_INSERT_RELATORI_DB_INSERT_1 */

            R5000_00_INSERT_RELATORI_DB_INSERT_1();

            /*" -1630- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1631- DISPLAY 'R5000- ERRO INSERT CBCONDEV' */
                _.Display($"R5000- ERRO INSERT CBCONDEV");

                /*" -1632- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1633- ELSE */
            }
            else
            {


                /*" -1633- ADD 1 TO IN-RELATORI. */
                W.IN_RELATORI.Value = W.IN_RELATORI + 1;
            }


        }

        [StopWatch]
        /*" R5000-00-INSERT-RELATORI-DB-INSERT-1 */
        public void R5000_00_INSERT_RELATORI_DB_INSERT_1()
        {
            /*" -1627- EXEC SQL INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO ,DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,NUM_COPIAS ,QUANTIDADE ,PERI_INICIAL ,PERI_FINAL ,DATA_REFERENCIA ,MES_REFERENCIA ,ANO_REFERENCIA ,ORGAO_EMISSOR ,COD_FONTE ,COD_PRODUTOR ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_CONGENERE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_TITULO ,COD_SUBGRUPO ,COD_OPERACAO ,COD_PLANO ,OCORR_HISTORICO ,NUM_APOL_LIDER ,ENDOS_LIDER ,NUM_PARC_LIDER ,NUM_SINISTRO ,NUM_SINI_LIDER ,NUM_ORDEM ,COD_MOEDA ,TIPO_CORRECAO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO ,COD_EMPRESA ,PERI_RENOVACAO ,PCT_AUMENTO ,TIMESTAMP) VALUES (:RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA:VIND-NULL01 ,:RELATORI-PERI-RENOVACAO:VIND-NULL02 ,:RELATORI-PCT-AUMENTO:VIND-NULL03 , CURRENT TIMESTAMP) END-EXEC. */

            var r5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1 = new R5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
            };

            R5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1.Execute(r5000_00_INSERT_RELATORI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-SEM-SOLICITACAO-SECTION */
        private void R9100_00_SEM_SOLICITACAO_SECTION()
        {
            /*" -1647- CLOSE MOVSIG01 MOVSIG02. */
            MOVSIG01.Close();
            MOVSIG02.Close();

            /*" -1647- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1651- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1652- DISPLAY ' ' */
            _.Display($" ");

            /*" -1653- DISPLAY 'BI0230B - SEM SOLICITACAO ' . */
            _.Display($"BI0230B - SEM SOLICITACAO ");

            /*" -1655- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1657- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1657- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1664- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1665- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1666- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1668- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1671- CLOSE MOVSIG01 MOVSIG02. */
            MOVSIG01.Close();
            MOVSIG02.Close();

            /*" -1671- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1675- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1675- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}