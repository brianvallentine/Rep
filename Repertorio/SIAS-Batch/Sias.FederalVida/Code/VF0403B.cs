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
using Sias.FederalVida.DB2.VF0403B;

namespace Code
{
    public class VF0403B
    {
        public bool IsCall { get; set; }

        public VF0403B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *       EMITE O RELATORIO DE VENDAS SEMANAIS DO FEDERAL CLUBE    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     * 14/10/1999 *   FONSECA    *                       *      */
        /*"      *            *            *              *                       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RVF0403B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVF0403B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVF0403B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVF0403B, REG_IMPRESSAO); return _RVF0403B;
            }
        }
        public SortBasis<VF0403B_REG_SVF0403B> SVF0403B { get; set; } = new SortBasis<VF0403B_REG_SVF0403B>(new VF0403B_REG_SVF0403B());
        /*"01            REG-SVF0403B.*/
        public VF0403B_REG_SVF0403B REG_SVF0403B { get; set; } = new VF0403B_REG_SVF0403B();
        public class VF0403B_REG_SVF0403B : VarBasis
        {
            /*"  05          S-CODGER            PIC S9(004)    COMP.*/
            public IntBasis S_CODGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05          S-FONTE             PIC S9(004)    COMP.*/
            public IntBasis S_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05          S-CODAST            PIC S9(004)    COMP.*/
            public IntBasis S_CODAST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05          S-CODSUBES          PIC S9(004)    COMP.*/
            public IntBasis S_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05          S-CODPDT            PIC S9(009)    COMP.*/
            public IntBasis S_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05          S-CODPRODU          PIC S9(004)    COMP.*/
            public IntBasis S_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05          S-NRCERTIF          PIC S9(015)    COMP-3.*/
            public IntBasis S_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05          S-NOMESEG           PIC  X(040).*/
            public StringBasis S_NOMESEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05          S-NUM-APOLICE       PIC S9(013)    COMP-3.*/
            public IntBasis S_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05          S-IMPMORNATU        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis S_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05          S-VLPREMIO          PIC S9(013)V99 COMP-3.*/
            public DoubleBasis S_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05          S-DTQITBCO          PIC  X(010).*/
            public StringBasis S_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01            REG-IMPRESSAO       PIC X(132).*/
        }
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            DTINISEM            PIC  X(10).*/
        public StringBasis DTINISEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            DTFIMSEM            PIC  X(10).*/
        public StringBasis DTFIMSEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTHOJE       PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RELA-SITUACAO     PIC  X(01).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0EVEN-NRCERTIF     PIC S9(15) COMP-3.*/
        public IntBasis V0EVEN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0EVEN-DTMOVTO      PIC  X(10).*/
        public StringBasis V0EVEN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0EVEN-VLPREMIO     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0EVEN_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PRVA-FONTE        PIC S9(04) COMP.*/
        public IntBasis V0PRVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PRVA-CODCLIEN     PIC S9(09) COMP.*/
        public IntBasis V0PRVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PRVA-CODPRODU     PIC S9(04) COMP.*/
        public IntBasis V0PRVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PRVA-NUM-APOLICE  PIC S9(13) COMP-3.*/
        public IntBasis V0PRVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PRVA-CODSUBES     PIC S9(04) COMP.*/
        public IntBasis V0PRVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PRVA-DTQITBCO     PIC  X(10).*/
        public StringBasis V0PRVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0COBP-IMPMORNATU   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0CLIE-NOME-RAZAO   PIC  X(40).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0FONT-FONTE        PIC S9(04) COMP.*/
        public IntBasis V0FONT_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0FONT-NOMEFTE      PIC  X(40).*/
        public StringBasis V0FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0GERE-CODGER       PIC S9(04) COMP.*/
        public IntBasis V0GERE_CODGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0GERE-NOMGER       PIC  X(40).*/
        public StringBasis V0GERE_NOMGER { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0SUBG-NUM-APOLICE  PIC S9(13) COMP-3.*/
        public IntBasis V0SUBG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0SUBG-CODSUBES     PIC S9(04) COMP.*/
        public IntBasis V0SUBG_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0SUBG-CODCLIEN     PIC S9(09) COMP.*/
        public IntBasis V0SUBG_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0SUBG-NOMSUB       PIC  X(40).*/
        public StringBasis V0SUBG_NOMSUB { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0ASST-CODAST       PIC S9(04) COMP.*/
        public IntBasis V0ASST_CODAST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0ASST-NOMAST       PIC  X(40).*/
        public StringBasis V0ASST_NOMAST { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PROD-NOMPDT       PIC  X(40).*/
        public StringBasis V0PROD_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PROD-CODPDT       PIC S9(09) COMP.*/
        public IntBasis V0PROD_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PDVG-CODPRODU     PIC S9(04) COMP.*/
        public IntBasis V0PDVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PDVG-NOMPRODU     PIC  X(40).*/
        public StringBasis V0PDVG_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PLCO-CODCOR       PIC S9(09) COMP.*/
        public IntBasis V0PLCO_CODCOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  WORK-AREA.*/
        public VF0403B_WORK_AREA WORK_AREA { get; set; } = new VF0403B_WORK_AREA();
        public class VF0403B_WORK_AREA : VarBasis
        {
            /*"    05        WS-NRCERTIF         PIC 9(15).*/
            public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    05        WS-NRCERTIF-R       REDEFINES              WS-NRCERTIF.*/
            private _REDEF_VF0403B_WS_NRCERTIF_R _ws_nrcertif_r { get; set; }
            public _REDEF_VF0403B_WS_NRCERTIF_R WS_NRCERTIF_R
            {
                get { _ws_nrcertif_r = new _REDEF_VF0403B_WS_NRCERTIF_R(); _.Move(WS_NRCERTIF, _ws_nrcertif_r); VarBasis.RedefinePassValue(WS_NRCERTIF, _ws_nrcertif_r, WS_NRCERTIF); _ws_nrcertif_r.ValueChanged += () => { _.Move(_ws_nrcertif_r, WS_NRCERTIF); }; return _ws_nrcertif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nrcertif_r, WS_NRCERTIF); }
            }  //Redefines
            public class _REDEF_VF0403B_WS_NRCERTIF_R : VarBasis
            {
                /*"      10      FILLER              PIC 9(04).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      WS-NRCERTIF-1       PIC 9(10).*/
                public IntBasis WS_NRCERTIF_1 { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                /*"      10      WS-NRCERTIF-2       PIC 9(01).*/
                public IntBasis WS_NRCERTIF_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    05        DATA-SQL.*/

                public _REDEF_VF0403B_WS_NRCERTIF_R()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_NRCERTIF_1.ValueChanged += OnValueChanged;
                    WS_NRCERTIF_2.ValueChanged += OnValueChanged;
                }

            }
            public VF0403B_DATA_SQL DATA_SQL { get; set; } = new VF0403B_DATA_SQL();
            public class VF0403B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DTINISEM.*/
            }
            public VF0403B_WS_DTINISEM WS_DTINISEM { get; set; } = new VF0403B_WS_DTINISEM();
            public class VF0403B_WS_DTINISEM : VarBasis
            {
                /*"      10      WS-ANO-IS           PIC  9(004).*/
                public IntBasis WS_ANO_IS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-IS           PIC  9(002).*/
                public IntBasis WS_MES_IS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-IS           PIC  9(002).*/
                public IntBasis WS_DIA_IS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DTFIMSEM.*/
            }
            public VF0403B_WS_DTFIMSEM WS_DTFIMSEM { get; set; } = new VF0403B_WS_DTFIMSEM();
            public class VF0403B_WS_DTFIMSEM : VarBasis
            {
                /*"      10      WS-ANO-FS           PIC  9(004).*/
                public IntBasis WS_ANO_FS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-FS           PIC  9(002).*/
                public IntBasis WS_MES_FS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-FS           PIC  9(002).*/
                public IntBasis WS_DIA_FS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA             PIC  9(008).*/
            }
            public IntBasis WS_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-DATA-R           REDEFINES              WS-DATA.*/
            private _REDEF_VF0403B_WS_DATA_R _ws_data_r { get; set; }
            public _REDEF_VF0403B_WS_DATA_R WS_DATA_R
            {
                get { _ws_data_r = new _REDEF_VF0403B_WS_DATA_R(); _.Move(WS_DATA, _ws_data_r); VarBasis.RedefinePassValue(WS_DATA, _ws_data_r, WS_DATA); _ws_data_r.ValueChanged += () => { _.Move(_ws_data_r, WS_DATA); }; return _ws_data_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_r, WS_DATA); }
            }  //Redefines
            public class _REDEF_VF0403B_WS_DATA_R : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-IAC              PIC  9(002).*/

                public _REDEF_VF0403B_WS_DATA_R()
                {
                    WS_DIA.ValueChanged += OnValueChanged;
                    WS_MES.ValueChanged += OnValueChanged;
                    WS_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_IAC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05        WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_VF0403B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VF0403B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VF0403B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VF0403B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WFIM-V0EVENTOSVF    PIC   X(01)  VALUE  ' '.*/

                public _REDEF_VF0403B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V0EVENTOSVF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V0RELATORIOS   PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-LINHA            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LINHA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-PAGINA           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-EXTRATOS         PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_EXTRATOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VIDAS-PRD        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_PRD { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-PRD     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_PRD { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-PRD   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_PRD { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VIDAS-VEN        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_VEN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-VEN     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_VEN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-VEN   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_VEN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VIDAS-SUB        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_SUB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-SUB     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_SUB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-SUB   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_SUB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VIDAS-AST        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_AST { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-AST     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_AST { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-AST   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_AST { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VIDAS-FIL        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_FIL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-FIL     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_FIL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-FIL   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_FIL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VIDAS-REP        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_REP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-REP     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_REP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-REP   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_REP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VIDAS-TOT        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_VIDAS_TOT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VLPREMIO-TOT     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLPREMIO_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPMORNATU-TOT   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_IMPMORNATU_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPREMIO-MED     PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPREMIO_MED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-IMPMORNATU-MED   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORNATU_MED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WABEND.*/
            public VF0403B_WABEND WABEND { get; set; } = new VF0403B_WABEND();
            public class VF0403B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VF0403B'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VF0403B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        LC01.*/
            }
            public VF0403B_LC01 LC01 { get; set; } = new VF0403B_LC01();
            public class VF0403B_LC01 : VarBasis
            {
                /*"      10      FILLER              PIC  X(008) VALUE 'VF0403B'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VF0403B");
                /*"      10      FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10      FILLER              PIC  X(040) VALUE             'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
                /*"      10      FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"      10      FILLER              PIC  X(013) VALUE 'PAGINA'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
                /*"      10      LC01-PAGINA         PIC  Z999.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"    05        LC02.*/
            }
            public VF0403B_LC02 LC02 { get; set; } = new VF0403B_LC02();
            public class VF0403B_LC02 : VarBasis
            {
                /*"      10      FILLER              PIC  X(115) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"");
                /*"      10      FILLER              PIC  X(007) VALUE 'DATA '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA ");
                /*"      10      LC02-DIA            PIC  9(02).*/
                public IntBasis LC02_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-MES            PIC  9(02).*/
                public IntBasis LC02_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-ANO            PIC  9(04).*/
                public IntBasis LC02_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC03.*/
            }
            public VF0403B_LC03 LC03 { get; set; } = new VF0403B_LC03();
            public class VF0403B_LC03 : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             'SEMANA DE '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SEMANA DE ");
                /*"      10      LC03-DIA-INI        PIC  9(002).*/
                public IntBasis LC03_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC03-MES-INI        PIC  9(002).*/
                public IntBasis LC03_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC03-ANO-INI        PIC  9(004).*/
                public IntBasis LC03_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(003) VALUE             ' A '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"      10      LC03-DIA-FIM        PIC  9(002).*/
                public IntBasis LC03_DIA_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC03-MES-FIM        PIC  9(002).*/
                public IntBasis LC03_MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC03-ANO-FIM        PIC  9(004).*/
                public IntBasis LC03_ANO_FIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(018) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"      10      FILLER              PIC  X(031) VALUE             'RELATORIO DE VENDAS SEMANAIS'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"RELATORIO DE VENDAS SEMANAIS");
                /*"      10      FILLER              PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"      10      FILLER              PIC  X(009) VALUE 'HORA '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"HORA ");
                /*"      10      LC03-HOR            PIC  9(002).*/
                public IntBasis LC03_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-MIN            PIC  9(002).*/
                public IntBasis LC03_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-SEG            PIC  9(002).*/
                public IntBasis LC03_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        LC04.*/
            }
            public VF0403B_LC04 LC04 { get; set; } = new VF0403B_LC04();
            public class VF0403B_LC04 : VarBasis
            {
                /*"      10      FILLER              PIC X(025) VALUE             'REPRESENTACAO '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"REPRESENTACAO ");
                /*"      10      LC04-CODGER         PIC ZZZZZ9.*/
                public IntBasis LC04_CODGER { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC04-NOMGER         PIC X(040).*/
                public StringBasis LC04_NOMGER { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC05.*/
            }
            public VF0403B_LC05 LC05 { get; set; } = new VF0403B_LC05();
            public class VF0403B_LC05 : VarBasis
            {
                /*"      10      FILLER              PIC  X(025) VALUE             'FONTE      '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"FONTE      ");
                /*"      10      LC05-FONTE          PIC  ZZZZZ9.*/
                public IntBasis LC05_FONTE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC05-NOMEFTE        PIC  X(040).*/
                public StringBasis LC05_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC06.*/
            }
            public VF0403B_LC06 LC06 { get; set; } = new VF0403B_LC06();
            public class VF0403B_LC06 : VarBasis
            {
                /*"      10      FILLER              PIC X(025) VALUE             'ASSISTENTE    '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"ASSISTENTE    ");
                /*"      10      LC06-CODAST         PIC ZZZZZ9.*/
                public IntBasis LC06_CODAST { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC06-NOMAST         PIC X(040).*/
                public StringBasis LC06_NOMAST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC07.*/
            }
            public VF0403B_LC07 LC07 { get; set; } = new VF0403B_LC07();
            public class VF0403B_LC07 : VarBasis
            {
                /*"      10      FILLER              PIC X(025) VALUE             'SUB-ESTIPULANTE'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"SUB-ESTIPULANTE");
                /*"      10      LC07-CODSUBES       PIC ZZZZZ9.*/
                public IntBasis LC07_CODSUBES { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC07-NOMSUB         PIC X(040).*/
                public StringBasis LC07_NOMSUB { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC08.*/
            }
            public VF0403B_LC08 LC08 { get; set; } = new VF0403B_LC08();
            public class VF0403B_LC08 : VarBasis
            {
                /*"      10      FILLER              PIC X(025) VALUE             'ANGARIADOR/CORRETOR '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"ANGARIADOR/CORRETOR ");
                /*"      10      LC08-CODPDT         PIC ZZZZZ9.*/
                public IntBasis LC08_CODPDT { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC08-NOMPDT         PIC X(040).*/
                public StringBasis LC08_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC09.*/
            }
            public VF0403B_LC09 LC09 { get; set; } = new VF0403B_LC09();
            public class VF0403B_LC09 : VarBasis
            {
                /*"      10      FILLER              PIC X(025) VALUE             'PRODUTO       '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"PRODUTO       ");
                /*"      10      LC09-CODPRODU       PIC ZZZZZ9.*/
                public IntBasis LC09_CODPRODU { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"      10      FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"      10      LC09-NOMPRODU       PIC X(040).*/
                public StringBasis LC09_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05        LC10.*/
            }
            public VF0403B_LC10 LC10 { get; set; } = new VF0403B_LC10();
            public class VF0403B_LC10 : VarBasis
            {
                /*"      10      FILLER              PIC X(012) VALUE      '  PROPOSTA  '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"  PROPOSTA  ");
                /*"      10      FILLER              PIC X(011) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      FILLER              PIC X(040) VALUE      'SEGURADO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SEGURADO");
                /*"      10      FILLER              PIC X(011) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      FILLER              PIC X(014) VALUE      '    CAPITAL   '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    CAPITAL   ");
                /*"      10      FILLER              PIC X(011) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      FILLER              PIC X(010) VALUE      ' PREMIO   '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PREMIO   ");
                /*"      10      FILLER              PIC X(012) VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"      10      FILLER              PIC X(011) VALUE      'CONTRATACAO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CONTRATACAO");
                /*"    05        LD01.*/
            }
            public VF0403B_LD01 LD01 { get; set; } = new VF0403B_LD01();
            public class VF0403B_LD01 : VarBasis
            {
                /*"      10      LD01-NRCERTIF-X.*/
                public VF0403B_LD01_NRCERTIF_X LD01_NRCERTIF_X { get; set; } = new VF0403B_LD01_NRCERTIF_X();
                public class VF0403B_LD01_NRCERTIF_X : VarBasis
                {
                    /*"        15    LD01-NRCERTIF-1     PIC 9(010).*/
                    public IntBasis LD01_NRCERTIF_1 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"        15    LD01-TRACO          PIC X(001).*/
                    public StringBasis LD01_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"        15    LD01-NRCERTIF-2     PIC 9(001).*/
                    public IntBasis LD01_NRCERTIF_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      10      FILLER              PIC X(011)  VALUE SPACES.*/
                }
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      LD01-NOMESEG        PIC X(040).*/
                public StringBasis LD01_NOMESEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      FILLER              PIC X(011)  VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      LD01-IMPMORNATU     PIC ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(011)  VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"      10      LD01-VLPREMIO       PIC ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(013)  VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"      10      LD01-DTQITBCO       PIC 99/99/9999.*/
                public IntBasis LD01_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
                /*"    05        LT01.*/
            }
            public VF0403B_LT01 LT01 { get; set; } = new VF0403B_LT01();
            public class VF0403B_LT01 : VarBasis
            {
                /*"      10      LT01-NOME           PIC X(031).*/
                public StringBasis LT01_NOME { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"      10      FILLER              PIC X(006) VALUE      'VIDAS '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"VIDAS ");
                /*"      10      LT01-VIDAS          PIC ZZZ.ZZ9.*/
                public IntBasis LT01_VIDAS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      10      FILLER              PIC X(008) VALUE      ' PREMIO '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" PREMIO ");
                /*"      10      LT01-VLPREMIO       PIC Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(009) VALUE      ' CAPITAL '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" CAPITAL ");
                /*"      10      LT01-IMPMORNATU     PIC ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(014) VALUE      ' PREMIO MEDIO '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" PREMIO MEDIO ");
                /*"      10      LT01-VLPREMIO-MED   PIC ZZ9,99.*/
                public DoubleBasis LT01_VLPREMIO_MED { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(015) VALUE      ' CAPITAL MEDIO '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" CAPITAL MEDIO ");
                /*"      10      LT01-IMPMORNATU-MED PIC ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_IMPMORNATU_MED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
            }
        }


        public VF0403B_CEVENT CEVENT { get; set; } = new VF0403B_CEVENT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVF0403B_FILE_NAME_P, string SVF0403B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVF0403B.SetFile(RVF0403B_FILE_NAME_P);
                SVF0403B.SetFile(SVF0403B_FILE_NAME_P);

                /*" -428- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -431- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -434- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -434- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -442- PERFORM R0010-00-SELECT-V1SISTEMA. */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -444- PERFORM R0005-00-SELECT-V0RELATORIOS. */

            R0005_00_SELECT_V0RELATORIOS_SECTION();

            /*" -445- IF WFIM-V0RELATORIOS EQUAL 'S' */

            if (WORK_AREA.WFIM_V0RELATORIOS == "S")
            {

                /*" -446- PERFORM R9700-00-SEM-SOLICITACAO */

                R9700_00_SEM_SOLICITACAO_SECTION();

                /*" -448- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -450- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -460- SORT SVF0403B ON ASCENDING KEY S-CODGER S-FONTE S-CODAST S-CODSUBES S-CODPDT S-CODPRODU S-DTQITBCO S-NOMESEG INPUT PROCEDURE R1000-00-SELECIONA THRU R1000-99-SAIDA OUTPUT PROCEDURE R2000-00-IMPRIME THRU R2000-99-SAIDA. */
            SORT_RETURN.Value = SVF0403B.Sort("S-CODGER,S-FONTE,S-CODAST,S-CODSUBES,S-CODPDT,S-CODPRODU,S-DTQITBCO,S-NOMESEG", () => R1000_00_SELECIONA_SECTION(), () => R2000_00_IMPRIME_SECTION());

            /*" -464- IF SORT-RETURN NOT EQUAL ZEROS AND WFIM-SORT EQUAL ' ' */

            if (SORT_RETURN != 00 && WORK_AREA.WFIM_SORT == " ")
            {

                /*" -465- DISPLAY '*** VF0403B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VF0403B *** PROBLEMAS NO SORT ");

                /*" -466- DISPLAY '*** VF0403B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VF0403B *** SORT-RETURN = {SORT_RETURN}");

                /*" -468- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -468- PERFORM R0020-00-UPDATE-V0RELATORIOS. */

            R0020_00_UPDATE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -472- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -475- DISPLAY '*** VF0403B LIDOS              ' AC-LIDOS. */
            _.Display($"*** VF0403B LIDOS              {WORK_AREA.AC_LIDOS}");

            /*" -477- DISPLAY ' ' . */
            _.Display($" ");

            /*" -479- DISPLAY '*** VF0403B - TERMINO NORMAL' . */
            _.Display($"*** VF0403B - TERMINO NORMAL");

            /*" -481- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -481- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0005-00-SELECT-V0RELATORIOS-SECTION */
        private void R0005_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -494- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -500- PERFORM R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -503- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -504- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -505- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", WORK_AREA.WFIM_V0RELATORIOS);

                    /*" -506- ELSE */
                }
                else
                {


                    /*" -506- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0005-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -500- EXEC SQL SELECT SITUACAO INTO :V0RELA-SITUACAO FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VF0403B' AND SITUACAO = '0' END-EXEC. */

            var r0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_SITUACAO, V0RELA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -519- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -528- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -531- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -533- DISPLAY 'VF0403B - SISTEMA VF NAO ESTA CADASTRADO ' SQLCODE */
                _.Display($"VF0403B - SISTEMA VF NAO ESTA CADASTRADO {DB.SQLCODE}");

                /*" -535- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -536- MOVE V1SIST-DTHOJE TO DATA-SQL. */
            _.Move(V1SIST_DTHOJE, WORK_AREA.DATA_SQL);

            /*" -537- MOVE ANO-SQL TO LC02-ANO. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC02.LC02_ANO);

            /*" -538- MOVE MES-SQL TO LC02-MES. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.LC02.LC02_MES);

            /*" -540- MOVE DIA-SQL TO LC02-DIA. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.LC02.LC02_DIA);

            /*" -541- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

            /*" -542- MOVE WS-HOR TO LC03-HOR. */
            _.Move(WORK_AREA.WS_TIME_R.WS_HOR, WORK_AREA.LC03.LC03_HOR);

            /*" -543- MOVE WS-MIN TO LC03-MIN. */
            _.Move(WORK_AREA.WS_TIME_R.WS_MIN, WORK_AREA.LC03.LC03_MIN);

            /*" -545- MOVE WS-SEG TO LC03-SEG. */
            _.Move(WORK_AREA.WS_TIME_R.WS_SEG, WORK_AREA.LC03.LC03_SEG);

            /*" -547- MOVE DTINISEM TO WS-DTINISEM. */
            _.Move(DTINISEM, WORK_AREA.WS_DTINISEM);

            /*" -548- MOVE WS-DIA-IS TO LC03-DIA-INI. */
            _.Move(WORK_AREA.WS_DTINISEM.WS_DIA_IS, WORK_AREA.LC03.LC03_DIA_INI);

            /*" -549- MOVE WS-MES-IS TO LC03-MES-INI. */
            _.Move(WORK_AREA.WS_DTINISEM.WS_MES_IS, WORK_AREA.LC03.LC03_MES_INI);

            /*" -551- MOVE WS-ANO-IS TO LC03-ANO-INI. */
            _.Move(WORK_AREA.WS_DTINISEM.WS_ANO_IS, WORK_AREA.LC03.LC03_ANO_INI);

            /*" -553- MOVE DTFIMSEM TO WS-DTFIMSEM. */
            _.Move(DTFIMSEM, WORK_AREA.WS_DTFIMSEM);

            /*" -554- MOVE WS-DIA-FS TO LC03-DIA-FIM. */
            _.Move(WORK_AREA.WS_DTFIMSEM.WS_DIA_FS, WORK_AREA.LC03.LC03_DIA_FIM);

            /*" -555- MOVE WS-MES-FS TO LC03-MES-FIM. */
            _.Move(WORK_AREA.WS_DTFIMSEM.WS_MES_FS, WORK_AREA.LC03.LC03_MES_FIM);

            /*" -555- MOVE WS-ANO-FS TO LC03-ANO-FIM. */
            _.Move(WORK_AREA.WS_DTFIMSEM.WS_ANO_FS, WORK_AREA.LC03.LC03_ANO_FIM);

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -528- EXEC SQL SELECT CURRENT DATE, DTMOVABE, DTMOVABE - 6 DAYS INTO :V1SIST-DTHOJE, :DTFIMSEM, :DTINISEM FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VF' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
                _.Move(executed_1.DTFIMSEM, DTFIMSEM);
                _.Move(executed_1.DTINISEM, DTINISEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-UPDATE-V0RELATORIOS-SECTION */
        private void R0020_00_UPDATE_V0RELATORIOS_SECTION()
        {
            /*" -568- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -573- PERFORM R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -576- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -576- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -573- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'VF0403B' AND SITUACAO = '0' END-EXEC. */

            var r0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
            };

            R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECIONA-SECTION */
        private void R1000_00_SELECIONA_SECTION()
        {
            /*" -589- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -601- PERFORM R1000_00_SELECIONA_DB_DECLARE_1 */

            R1000_00_SELECIONA_DB_DECLARE_1();

            /*" -603- PERFORM R1000_00_SELECIONA_DB_OPEN_1 */

            R1000_00_SELECIONA_DB_OPEN_1();

            /*" -607- PERFORM R1900-00-FETCH-V0EVENTOSVF. */

            R1900_00_FETCH_V0EVENTOSVF_SECTION();

            /*" -608- IF WFIM-V0EVENTOSVF EQUAL 'S' */

            if (WORK_AREA.WFIM_V0EVENTOSVF == "S")
            {

                /*" -609- MOVE SPACES TO REG-SVF0403B */
                _.Move("", REG_SVF0403B);

                /*" -610- RELEASE REG-SVF0403B */
                SVF0403B.Release(REG_SVF0403B);

                /*" -612- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -613- PERFORM R1100-00-MONTA-SORT UNTIL WFIM-V0EVENTOSVF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0EVENTOSVF == "S"))
            {

                R1100_00_MONTA_SORT_SECTION();
            }

        }

        [StopWatch]
        /*" R1000-00-SELECIONA-DB-DECLARE-1 */
        public void R1000_00_SELECIONA_DB_DECLARE_1()
        {
            /*" -601- EXEC SQL DECLARE CEVENT CURSOR FOR SELECT DISTINCT NRCERTIF, VLPREMIO FROM SEGUROS.V0EVENTOSVF WHERE CODEVEN IN (3,6,7) AND DTOPER >= :DTINISEM AND DTOPER <= :DTFIMSEM ORDER BY NRCERTIF, VLPREMIO END-EXEC. */
            CEVENT = new VF0403B_CEVENT(true);
            string GetQuery_CEVENT()
            {
                var query = @$"SELECT DISTINCT 
							NRCERTIF
							, 
							VLPREMIO 
							FROM SEGUROS.V0EVENTOSVF 
							WHERE CODEVEN IN (3
							,6
							,7) 
							AND DTOPER >= '{DTINISEM}' 
							AND DTOPER <= '{DTFIMSEM}' 
							ORDER BY 
							NRCERTIF
							, 
							VLPREMIO";

                return query;
            }
            CEVENT.GetQueryEvent += GetQuery_CEVENT;

        }

        [StopWatch]
        /*" R1000-00-SELECIONA-DB-OPEN-1 */
        public void R1000_00_SELECIONA_DB_OPEN_1()
        {
            /*" -603- EXEC SQL OPEN CEVENT END-EXEC. */

            CEVENT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MONTA-SORT-SECTION */
        private void R1100_00_MONTA_SORT_SECTION()
        {
            /*" -626- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -641- PERFORM R1100_00_MONTA_SORT_DB_SELECT_1 */

            R1100_00_MONTA_SORT_DB_SELECT_1();

            /*" -644- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -645- DISPLAY 'CERTIFICADO NAO ENCONTRADO = ' V0EVEN-NRCERTIF */
                _.Display($"CERTIFICADO NAO ENCONTRADO = {V0EVEN_NRCERTIF}");

                /*" -647- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -649- MOVE '111' TO WNR-EXEC-SQL. */
            _.Move("111", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -654- PERFORM R1100_00_MONTA_SORT_DB_SELECT_2 */

            R1100_00_MONTA_SORT_DB_SELECT_2();

            /*" -657- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -658- DISPLAY 'CLIENTE NAO ENCONTRADO = ' V0PRVA-CODCLIEN */
                _.Display($"CLIENTE NAO ENCONTRADO = {V0PRVA_CODCLIEN}");

                /*" -660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -662- MOVE '112' TO WNR-EXEC-SQL. */
            _.Move("112", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -667- PERFORM R1100_00_MONTA_SORT_DB_SELECT_3 */

            R1100_00_MONTA_SORT_DB_SELECT_3();

            /*" -670- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -672- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -674- MOVE '113' TO WNR-EXEC-SQL. */
            _.Move("113", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -679- PERFORM R1100_00_MONTA_SORT_DB_SELECT_4 */

            R1100_00_MONTA_SORT_DB_SELECT_4();

            /*" -682- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -684- MOVE 0 TO V0ASST-CODAST. */
                _.Move(0, V0ASST_CODAST);
            }


            /*" -686- MOVE '114' TO WNR-EXEC-SQL. */
            _.Move("114", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -693- PERFORM R1100_00_MONTA_SORT_DB_SELECT_5 */

            R1100_00_MONTA_SORT_DB_SELECT_5();

            /*" -696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -697- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -698- MOVE '115' TO WNR-EXEC-SQL */
                    _.Move("115", WORK_AREA.WABEND.WNR_EXEC_SQL);

                    /*" -705- PERFORM R1100_00_MONTA_SORT_DB_SELECT_6 */

                    R1100_00_MONTA_SORT_DB_SELECT_6();

                    /*" -707- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -709- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                        if (DB.SQLCODE == -811)
                        {

                            /*" -710- ELSE */
                        }
                        else
                        {


                            /*" -711- MOVE 0 TO V0PLCO-CODCOR */
                            _.Move(0, V0PLCO_CODCOR);

                            /*" -713- ELSE NEXT SENTENCE */
                        }

                    }
                    else
                    {


                        /*" -714- ELSE */
                    }

                }
                else
                {


                    /*" -716- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -717- ELSE */
                    }
                    else
                    {


                        /*" -719- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -721- MOVE '116' TO WNR-EXEC-SQL. */
            _.Move("116", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -727- PERFORM R1100_00_MONTA_SORT_DB_SELECT_7 */

            R1100_00_MONTA_SORT_DB_SELECT_7();

            /*" -730- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -732- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -733- MOVE V0PRVA-FONTE TO S-FONTE. */
            _.Move(V0PRVA_FONTE, REG_SVF0403B.S_FONTE);

            /*" -734- MOVE V0GERE-CODGER TO S-CODGER. */
            _.Move(V0GERE_CODGER, REG_SVF0403B.S_CODGER);

            /*" -735- MOVE V0ASST-CODAST TO S-CODAST. */
            _.Move(V0ASST_CODAST, REG_SVF0403B.S_CODAST);

            /*" -736- MOVE V0PLCO-CODCOR TO S-CODPDT. */
            _.Move(V0PLCO_CODCOR, REG_SVF0403B.S_CODPDT);

            /*" -737- MOVE V0PRVA-CODPRODU TO S-CODPRODU. */
            _.Move(V0PRVA_CODPRODU, REG_SVF0403B.S_CODPRODU);

            /*" -738- MOVE V0CLIE-NOME-RAZAO TO S-NOMESEG. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVF0403B.S_NOMESEG);

            /*" -739- MOVE V0EVEN-NRCERTIF TO S-NRCERTIF. */
            _.Move(V0EVEN_NRCERTIF, REG_SVF0403B.S_NRCERTIF);

            /*" -740- MOVE V0PRVA-DTQITBCO TO S-DTQITBCO. */
            _.Move(V0PRVA_DTQITBCO, REG_SVF0403B.S_DTQITBCO);

            /*" -741- MOVE V0PRVA-NUM-APOLICE TO S-NUM-APOLICE. */
            _.Move(V0PRVA_NUM_APOLICE, REG_SVF0403B.S_NUM_APOLICE);

            /*" -742- MOVE V0PRVA-CODSUBES TO S-CODSUBES. */
            _.Move(V0PRVA_CODSUBES, REG_SVF0403B.S_CODSUBES);

            /*" -743- MOVE V0COBP-IMPMORNATU TO S-IMPMORNATU. */
            _.Move(V0COBP_IMPMORNATU, REG_SVF0403B.S_IMPMORNATU);

            /*" -745- MOVE V0EVEN-VLPREMIO TO S-VLPREMIO. */
            _.Move(V0EVEN_VLPREMIO, REG_SVF0403B.S_VLPREMIO);

            /*" -745- RELEASE REG-SVF0403B. */
            SVF0403B.Release(REG_SVF0403B);

            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-1 */
        public void R1100_00_MONTA_SORT_DB_SELECT_1()
        {
            /*" -641- EXEC SQL SELECT FONTE, CODCLIEN, CODPRODU, NUM_APOLICE, CODSUBES, DTQITBCO INTO :V0PRVA-FONTE, :V0PRVA-CODCLIEN, :V0PRVA-CODPRODU, :V0PRVA-NUM-APOLICE, :V0PRVA-CODSUBES, :V0PRVA-DTQITBCO FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :V0EVEN-NRCERTIF END-EXEC. */

            var r1100_00_MONTA_SORT_DB_SELECT_1_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_1_Query1()
            {
                V0EVEN_NRCERTIF = V0EVEN_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_1_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRVA_FONTE, V0PRVA_FONTE);
                _.Move(executed_1.V0PRVA_CODCLIEN, V0PRVA_CODCLIEN);
                _.Move(executed_1.V0PRVA_CODPRODU, V0PRVA_CODPRODU);
                _.Move(executed_1.V0PRVA_NUM_APOLICE, V0PRVA_NUM_APOLICE);
                _.Move(executed_1.V0PRVA_CODSUBES, V0PRVA_CODSUBES);
                _.Move(executed_1.V0PRVA_DTQITBCO, V0PRVA_DTQITBCO);
            }


        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -749- PERFORM R1900-00-FETCH-V0EVENTOSVF. */

            R1900_00_FETCH_V0EVENTOSVF_SECTION();

        }

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-2 */
        public void R1100_00_MONTA_SORT_DB_SELECT_2()
        {
            /*" -654- EXEC SQL SELECT NOME_RAZAO INTO :V0CLIE-NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0PRVA-CODCLIEN END-EXEC. */

            var r1100_00_MONTA_SORT_DB_SELECT_2_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_2_Query1()
            {
                V0PRVA_CODCLIEN = V0PRVA_CODCLIEN.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_2_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-3 */
        public void R1100_00_MONTA_SORT_DB_SELECT_3()
        {
            /*" -667- EXEC SQL SELECT CODAST INTO :V0ASST-CODAST FROM SEGUROS.V0PROPOSTAVF WHERE NRCERTIF = :V0EVEN-NRCERTIF END-EXEC. */

            var r1100_00_MONTA_SORT_DB_SELECT_3_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_3_Query1()
            {
                V0EVEN_NRCERTIF = V0EVEN_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_3_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ASST_CODAST, V0ASST_CODAST);
            }


        }

        [StopWatch]
        /*" R1900-00-FETCH-V0EVENTOSVF-SECTION */
        private void R1900_00_FETCH_V0EVENTOSVF_SECTION()
        {
            /*" -762- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -766- PERFORM R1900_00_FETCH_V0EVENTOSVF_DB_FETCH_1 */

            R1900_00_FETCH_V0EVENTOSVF_DB_FETCH_1();

            /*" -769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -770- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -771- MOVE 'S' TO WFIM-V0EVENTOSVF */
                    _.Move("S", WORK_AREA.WFIM_V0EVENTOSVF);

                    /*" -771- PERFORM R1900_00_FETCH_V0EVENTOSVF_DB_CLOSE_1 */

                    R1900_00_FETCH_V0EVENTOSVF_DB_CLOSE_1();

                    /*" -773- GO TO R1900-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                    return;

                    /*" -774- ELSE */
                }
                else
                {


                    /*" -776- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -776- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1900-00-FETCH-V0EVENTOSVF-DB-FETCH-1 */
        public void R1900_00_FETCH_V0EVENTOSVF_DB_FETCH_1()
        {
            /*" -766- EXEC SQL FETCH CEVENT INTO :V0EVEN-NRCERTIF, :V0EVEN-VLPREMIO END-EXEC. */

            if (CEVENT.Fetch())
            {
                _.Move(CEVENT.V0EVEN_NRCERTIF, V0EVEN_NRCERTIF);
                _.Move(CEVENT.V0EVEN_VLPREMIO, V0EVEN_VLPREMIO);
            }

        }

        [StopWatch]
        /*" R1900-00-FETCH-V0EVENTOSVF-DB-CLOSE-1 */
        public void R1900_00_FETCH_V0EVENTOSVF_DB_CLOSE_1()
        {
            /*" -771- EXEC SQL CLOSE CEVENT END-EXEC */

            CEVENT.Close();

        }

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-4 */
        public void R1100_00_MONTA_SORT_DB_SELECT_4()
        {
            /*" -679- EXEC SQL SELECT CODGER INTO :V0GERE-CODGER FROM SEGUROS.V0ASSISTFC WHERE CODAST = :V0ASST-CODAST END-EXEC. */

            var r1100_00_MONTA_SORT_DB_SELECT_4_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_4_Query1()
            {
                V0ASST_CODAST = V0ASST_CODAST.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_4_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0GERE_CODGER, V0GERE_CODGER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-5 */
        public void R1100_00_MONTA_SORT_DB_SELECT_5()
        {
            /*" -693- EXEC SQL SELECT DISTINCT CODPDT INTO :V0PLCO-CODCOR FROM SEGUROS.V0PLANCOMISVF WHERE NRCERTIF = :V0EVEN-NRCERTIF AND TIPCOM = '1' ORDER BY CODPDT END-EXEC. */

            var r1100_00_MONTA_SORT_DB_SELECT_5_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_5_Query1()
            {
                V0EVEN_NRCERTIF = V0EVEN_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_5_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PLCO_CODCOR, V0PLCO_CODCOR);
            }


        }

        [StopWatch]
        /*" R2000-00-IMPRIME-SECTION */
        private void R2000_00_IMPRIME_SECTION()
        {
            /*" -793- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -796- RETURN SVF0403B AT END MOVE 'S' TO WFIM-SORT. */
            try
            {
                SVF0403B.Return(REG_SVF0403B, () =>
                {

                    /*" -797- IF WFIM-SORT EQUAL 'S' */

                    if (WORK_AREA.WFIM_SORT == "S")
                    {

                        /*" -798- PERFORM R9800-00-SEM-REGISTROS */

                        R9800_00_SEM_REGISTROS_SECTION();

                        /*" -800- GO TO R2000-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                        return;
                    }


                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -801- IF REG-SVF0403B EQUAL SPACES */

            if (REG_SVF0403B.IsEmpty())
            {

                /*" -802- MOVE 'S' TO WFIM-SORT */
                _.Move("S", WORK_AREA.WFIM_SORT);

                /*" -803- PERFORM R9800-00-SEM-REGISTROS */

                R9800_00_SEM_REGISTROS_SECTION();

                /*" -805- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -807- OPEN OUTPUT RVF0403B. */
            RVF0403B.Open(REG_IMPRESSAO);

            /*" -810- PERFORM R2100-00-IMPRIME-REPRESENTACAO UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                R2100_00_IMPRIME_REPRESENTACAO_SECTION();
            }

            /*" -812- MOVE 'TOTAL GERAL' TO LT01-NOME. */
            _.Move("TOTAL GERAL", WORK_AREA.LT01.LT01_NOME);

            /*" -813- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-TOT / AC-VIDAS-TOT. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_TOT / WORK_AREA.AC_VIDAS_TOT;

            /*" -815- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-TOT / AC-VIDAS-TOT. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_TOT / WORK_AREA.AC_VIDAS_TOT;

            /*" -816- MOVE AC-VIDAS-TOT TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_TOT, WORK_AREA.LT01.LT01_VIDAS);

            /*" -817- MOVE AC-VLPREMIO-TOT TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_TOT, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -818- MOVE AC-IMPMORNATU-TOT TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_TOT, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -819- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -821- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -822- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA. */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -823- WRITE REG-IMPRESSAO FROM LC02. */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -824- WRITE REG-IMPRESSAO FROM LC03. */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -826- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -826- CLOSE RVF0403B. */
            RVF0403B.Close();

        }

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-6 */
        public void R1100_00_MONTA_SORT_DB_SELECT_6()
        {
            /*" -705- EXEC SQL SELECT DISTINCT CODPDT INTO :V0PLCO-CODCOR FROM SEGUROS.V0PLANCOMISVF WHERE NRCERTIF = :V0EVEN-NRCERTIF AND TIPCOM = '2' ORDER BY 1 END-EXEC */

            var r1100_00_MONTA_SORT_DB_SELECT_6_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_6_Query1()
            {
                V0EVEN_NRCERTIF = V0EVEN_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_6_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PLCO_CODCOR, V0PLCO_CODCOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MONTA-SORT-DB-SELECT-7 */
        public void R1100_00_MONTA_SORT_DB_SELECT_7()
        {
            /*" -727- EXEC SQL SELECT IMPMORNATU INTO :V0COBP-IMPMORNATU FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0EVEN-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1100_00_MONTA_SORT_DB_SELECT_7_Query1 = new R1100_00_MONTA_SORT_DB_SELECT_7_Query1()
            {
                V0EVEN_NRCERTIF = V0EVEN_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_MONTA_SORT_DB_SELECT_7_Query1.Execute(r1100_00_MONTA_SORT_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_IMPMORNATU, V0COBP_IMPMORNATU);
            }


        }

        [StopWatch]
        /*" R2100-00-IMPRIME-REPRESENTACAO-SECTION */
        private void R2100_00_IMPRIME_REPRESENTACAO_SECTION()
        {
            /*" -843- MOVE +0 TO AC-VIDAS-REP AC-IMPMORNATU-REP AC-VLPREMIO-REP. */
            _.Move(+0, WORK_AREA.AC_VIDAS_REP, WORK_AREA.AC_IMPMORNATU_REP, WORK_AREA.AC_VLPREMIO_REP);

            /*" -845- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -848- MOVE S-CODGER TO V0GERE-CODGER LC04-CODGER. */
            _.Move(REG_SVF0403B.S_CODGER, V0GERE_CODGER, WORK_AREA.LC04.LC04_CODGER);

            /*" -853- PERFORM R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1 */

            R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1();

            /*" -856- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -858- MOVE 'NAO INFORMADO' TO V0GERE-NOMGER. */
                _.Move("NAO INFORMADO", V0GERE_NOMGER);
            }


            /*" -860- MOVE V0GERE-NOMGER TO LC04-NOMGER. */
            _.Move(V0GERE_NOMGER, WORK_AREA.LC04.LC04_NOMGER);

            /*" -864- PERFORM R2200-00-IMPRIME-FONTE UNTIL S-CODGER NOT EQUAL V0GERE-CODGER OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVF0403B.S_CODGER != V0GERE_CODGER || WORK_AREA.WFIM_SORT == "S"))
            {

                R2200_00_IMPRIME_FONTE_SECTION();
            }

            /*" -866- MOVE 'TOTAL DA REPRESENTACAO' TO LT01-NOME. */
            _.Move("TOTAL DA REPRESENTACAO", WORK_AREA.LT01.LT01_NOME);

            /*" -867- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-REP / AC-VIDAS-REP. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_REP / WORK_AREA.AC_VIDAS_REP;

            /*" -869- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-REP / AC-VIDAS-REP. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_REP / WORK_AREA.AC_VIDAS_REP;

            /*" -870- MOVE AC-VIDAS-REP TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_REP, WORK_AREA.LT01.LT01_VIDAS);

            /*" -871- MOVE AC-VLPREMIO-REP TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_REP, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -872- MOVE AC-IMPMORNATU-REP TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_REP, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -873- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -875- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -876- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -877- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -878- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -879- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -880- WRITE REG-IMPRESSAO FROM LC02 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -881- WRITE REG-IMPRESSAO FROM LC03 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -883- WRITE REG-IMPRESSAO FROM LC04 AFTER 2. */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());
            }


            /*" -883- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R2100-00-IMPRIME-REPRESENTACAO-DB-SELECT-1 */
        public void R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1()
        {
            /*" -853- EXEC SQL SELECT NOMGER INTO :V0GERE-NOMGER FROM SEGUROS.V0GEREGFC WHERE CODGER = :V0GERE-CODGER END-EXEC. */

            var r2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1 = new R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1()
            {
                V0GERE_CODGER = V0GERE_CODGER.ToString(),
            };

            var executed_1 = R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1.Execute(r2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0GERE_NOMGER, V0GERE_NOMGER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-IMPRIME-FONTE-SECTION */
        private void R2200_00_IMPRIME_FONTE_SECTION()
        {
            /*" -900- MOVE +0 TO AC-VIDAS-FIL AC-IMPMORNATU-FIL AC-VLPREMIO-FIL. */
            _.Move(+0, WORK_AREA.AC_VIDAS_FIL, WORK_AREA.AC_IMPMORNATU_FIL, WORK_AREA.AC_VLPREMIO_FIL);

            /*" -902- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -905- MOVE S-FONTE TO V0FONT-FONTE LC05-FONTE. */
            _.Move(REG_SVF0403B.S_FONTE, V0FONT_FONTE, WORK_AREA.LC05.LC05_FONTE);

            /*" -910- PERFORM R2200_00_IMPRIME_FONTE_DB_SELECT_1 */

            R2200_00_IMPRIME_FONTE_DB_SELECT_1();

            /*" -913- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -914- DISPLAY 'FONTE NAO ENCONTRADA = ' S-FONTE */
                _.Display($"FONTE NAO ENCONTRADA = {REG_SVF0403B.S_FONTE}");

                /*" -916- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -918- MOVE V0FONT-NOMEFTE TO LC05-NOMEFTE. */
            _.Move(V0FONT_NOMEFTE, WORK_AREA.LC05.LC05_NOMEFTE);

            /*" -923- PERFORM R2300-00-IMPRIME-ASSISTENTE UNTIL S-CODGER NOT EQUAL V0GERE-CODGER OR S-FONTE NOT EQUAL V0FONT-FONTE OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVF0403B.S_CODGER != V0GERE_CODGER || REG_SVF0403B.S_FONTE != V0FONT_FONTE || WORK_AREA.WFIM_SORT == "S"))
            {

                R2300_00_IMPRIME_ASSISTENTE_SECTION();
            }

            /*" -925- MOVE 'TOTAL DA FONTE ' TO LT01-NOME. */
            _.Move("TOTAL DA FONTE ", WORK_AREA.LT01.LT01_NOME);

            /*" -926- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-FIL / AC-VIDAS-FIL. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_FIL / WORK_AREA.AC_VIDAS_FIL;

            /*" -928- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-FIL / AC-VIDAS-FIL. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_FIL / WORK_AREA.AC_VIDAS_FIL;

            /*" -929- MOVE AC-VIDAS-FIL TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_FIL, WORK_AREA.LT01.LT01_VIDAS);

            /*" -930- MOVE AC-VLPREMIO-FIL TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_FIL, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -931- MOVE AC-IMPMORNATU-FIL TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_FIL, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -932- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -934- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -935- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -936- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -937- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -938- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -939- WRITE REG-IMPRESSAO FROM LC02 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -940- WRITE REG-IMPRESSAO FROM LC03 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -941- WRITE REG-IMPRESSAO FROM LC04 AFTER 2 */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -943- WRITE REG-IMPRESSAO FROM LC05. */
                _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());
            }


            /*" -943- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R2200-00-IMPRIME-FONTE-DB-SELECT-1 */
        public void R2200_00_IMPRIME_FONTE_DB_SELECT_1()
        {
            /*" -910- EXEC SQL SELECT NOMEFTE INTO :V0FONT-NOMEFTE FROM SEGUROS.V0FONTE WHERE FONTE = :V0FONT-FONTE END-EXEC. */

            var r2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1 = new R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1()
            {
                V0FONT_FONTE = V0FONT_FONTE.ToString(),
            };

            var executed_1 = R2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1.Execute(r2200_00_IMPRIME_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONT_NOMEFTE, V0FONT_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-IMPRIME-ASSISTENTE-SECTION */
        private void R2300_00_IMPRIME_ASSISTENTE_SECTION()
        {
            /*" -960- MOVE +0 TO AC-VIDAS-AST AC-IMPMORNATU-AST AC-VLPREMIO-AST. */
            _.Move(+0, WORK_AREA.AC_VIDAS_AST, WORK_AREA.AC_IMPMORNATU_AST, WORK_AREA.AC_VLPREMIO_AST);

            /*" -962- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -965- MOVE S-CODAST TO V0ASST-CODAST LC06-CODAST. */
            _.Move(REG_SVF0403B.S_CODAST, V0ASST_CODAST, WORK_AREA.LC06.LC06_CODAST);

            /*" -970- PERFORM R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1 */

            R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1();

            /*" -973- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -975- MOVE 'NAO INFORMADO' TO V0ASST-NOMAST. */
                _.Move("NAO INFORMADO", V0ASST_NOMAST);
            }


            /*" -977- MOVE V0ASST-NOMAST TO LC06-NOMAST. */
            _.Move(V0ASST_NOMAST, WORK_AREA.LC06.LC06_NOMAST);

            /*" -983- PERFORM R2400-00-IMPRIME-SUBESTIP UNTIL S-CODGER NOT EQUAL V0GERE-CODGER OR S-FONTE NOT EQUAL V0FONT-FONTE OR S-CODAST NOT EQUAL V0ASST-CODAST OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVF0403B.S_CODGER != V0GERE_CODGER || REG_SVF0403B.S_FONTE != V0FONT_FONTE || REG_SVF0403B.S_CODAST != V0ASST_CODAST || WORK_AREA.WFIM_SORT == "S"))
            {

                R2400_00_IMPRIME_SUBESTIP_SECTION();
            }

            /*" -985- MOVE 'TOTAL DO ASSISTENTE' TO LT01-NOME. */
            _.Move("TOTAL DO ASSISTENTE", WORK_AREA.LT01.LT01_NOME);

            /*" -986- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-AST / AC-VIDAS-AST. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_AST / WORK_AREA.AC_VIDAS_AST;

            /*" -988- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-AST / AC-VIDAS-AST. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_AST / WORK_AREA.AC_VIDAS_AST;

            /*" -989- MOVE AC-VIDAS-AST TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_AST, WORK_AREA.LT01.LT01_VIDAS);

            /*" -990- MOVE AC-VLPREMIO-AST TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_AST, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -991- MOVE AC-IMPMORNATU-AST TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_AST, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -992- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -994- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -995- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -996- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -997- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -998- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -999- WRITE REG-IMPRESSAO FROM LC02 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1000- WRITE REG-IMPRESSAO FROM LC03 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1001- WRITE REG-IMPRESSAO FROM LC04 AFTER 2 */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1002- WRITE REG-IMPRESSAO FROM LC05 */
                _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1004- WRITE REG-IMPRESSAO FROM LC06. */
                _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());
            }


            /*" -1004- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R2300-00-IMPRIME-ASSISTENTE-DB-SELECT-1 */
        public void R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1()
        {
            /*" -970- EXEC SQL SELECT NOMAST INTO :V0ASST-NOMAST FROM SEGUROS.V0ASSISTFC WHERE CODAST = :V0ASST-CODAST END-EXEC. */

            var r2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1 = new R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1()
            {
                V0ASST_CODAST = V0ASST_CODAST.ToString(),
            };

            var executed_1 = R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1.Execute(r2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ASST_NOMAST, V0ASST_NOMAST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-IMPRIME-SUBESTIP-SECTION */
        private void R2400_00_IMPRIME_SUBESTIP_SECTION()
        {
            /*" -1021- MOVE +0 TO AC-VIDAS-SUB AC-IMPMORNATU-SUB AC-VLPREMIO-SUB. */
            _.Move(+0, WORK_AREA.AC_VIDAS_SUB, WORK_AREA.AC_IMPMORNATU_SUB, WORK_AREA.AC_VLPREMIO_SUB);

            /*" -1023- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1024- MOVE S-NUM-APOLICE TO V0SUBG-NUM-APOLICE */
            _.Move(REG_SVF0403B.S_NUM_APOLICE, V0SUBG_NUM_APOLICE);

            /*" -1027- MOVE S-CODSUBES TO V0SUBG-CODSUBES LC07-CODSUBES. */
            _.Move(REG_SVF0403B.S_CODSUBES, V0SUBG_CODSUBES, WORK_AREA.LC07.LC07_CODSUBES);

            /*" -1033- PERFORM R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1 */

            R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1();

            /*" -1036- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1038- DISPLAY 'SUBGRUPO NAO ENCONTRADO = ' S-NUM-APOLICE ' ' S-CODSUBES */

                $"SUBGRUPO NAO ENCONTRADO = {REG_SVF0403B.S_NUM_APOLICE} {REG_SVF0403B.S_CODSUBES}"
                .Display();

                /*" -1040- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1042- MOVE '241' TO WNR-EXEC-SQL. */
            _.Move("241", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1047- PERFORM R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2 */

            R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2();

            /*" -1050- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1052- DISPLAY 'CLIENTE NAO ENCONTRADO = ' S-NUM-APOLICE ' ' S-CODSUBES ' ' V0SUBG-CODCLIEN */

                $"CLIENTE NAO ENCONTRADO = {REG_SVF0403B.S_NUM_APOLICE} {REG_SVF0403B.S_CODSUBES} {V0SUBG_CODCLIEN}"
                .Display();

                /*" -1054- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1056- MOVE V0SUBG-NOMSUB TO LC07-NOMSUB. */
            _.Move(V0SUBG_NOMSUB, WORK_AREA.LC07.LC07_NOMSUB);

            /*" -1063- PERFORM R2500-00-IMPRIME-VENDEDOR UNTIL S-CODGER NOT EQUAL V0GERE-CODGER OR S-FONTE NOT EQUAL V0FONT-FONTE OR S-CODAST NOT EQUAL V0ASST-CODAST OR S-CODSUBES NOT EQUAL V0SUBG-CODSUBES OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVF0403B.S_CODGER != V0GERE_CODGER || REG_SVF0403B.S_FONTE != V0FONT_FONTE || REG_SVF0403B.S_CODAST != V0ASST_CODAST || REG_SVF0403B.S_CODSUBES != V0SUBG_CODSUBES || WORK_AREA.WFIM_SORT == "S"))
            {

                R2500_00_IMPRIME_VENDEDOR_SECTION();
            }

            /*" -1065- MOVE 'TOTAL DO SUB-ESTIPULANTE    ' TO LT01-NOME. */
            _.Move("TOTAL DO SUB-ESTIPULANTE    ", WORK_AREA.LT01.LT01_NOME);

            /*" -1066- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-SUB / AC-VIDAS-SUB. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_SUB / WORK_AREA.AC_VIDAS_SUB;

            /*" -1068- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-SUB / AC-VIDAS-SUB. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_SUB / WORK_AREA.AC_VIDAS_SUB;

            /*" -1069- MOVE AC-VIDAS-SUB TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_SUB, WORK_AREA.LT01.LT01_VIDAS);

            /*" -1070- MOVE AC-VLPREMIO-SUB TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_SUB, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -1071- MOVE AC-IMPMORNATU-SUB TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_SUB, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -1072- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -1074- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -1075- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -1076- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -1077- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -1078- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1079- WRITE REG-IMPRESSAO FROM LC02 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1080- WRITE REG-IMPRESSAO FROM LC03 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1081- WRITE REG-IMPRESSAO FROM LC04 AFTER 2 */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1082- WRITE REG-IMPRESSAO FROM LC05 */
                _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1083- WRITE REG-IMPRESSAO FROM LC06 */
                _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1085- WRITE REG-IMPRESSAO FROM LC07. */
                _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());
            }


            /*" -1085- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R2400-00-IMPRIME-SUBESTIP-DB-SELECT-1 */
        public void R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1()
        {
            /*" -1033- EXEC SQL SELECT COD_CLIENTE INTO :V0SUBG-CODCLIEN FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V0SUBG-NUM-APOLICE AND COD_SUBGRUPO = :V0SUBG-CODSUBES END-EXEC. */

            var r2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1 = new R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1()
            {
                V0SUBG_NUM_APOLICE = V0SUBG_NUM_APOLICE.ToString(),
                V0SUBG_CODSUBES = V0SUBG_CODSUBES.ToString(),
            };

            var executed_1 = R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1.Execute(r2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_CODCLIEN, V0SUBG_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-IMPRIME-SUBESTIP-DB-SELECT-2 */
        public void R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2()
        {
            /*" -1047- EXEC SQL SELECT NOME_RAZAO INTO :V0SUBG-NOMSUB FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0SUBG-CODCLIEN END-EXEC. */

            var r2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1 = new R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1()
            {
                V0SUBG_CODCLIEN = V0SUBG_CODCLIEN.ToString(),
            };

            var executed_1 = R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1.Execute(r2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_NOMSUB, V0SUBG_NOMSUB);
            }


        }

        [StopWatch]
        /*" R2500-00-IMPRIME-VENDEDOR-SECTION */
        private void R2500_00_IMPRIME_VENDEDOR_SECTION()
        {
            /*" -1102- MOVE +0 TO AC-VIDAS-VEN AC-IMPMORNATU-VEN AC-VLPREMIO-VEN. */
            _.Move(+0, WORK_AREA.AC_VIDAS_VEN, WORK_AREA.AC_IMPMORNATU_VEN, WORK_AREA.AC_VLPREMIO_VEN);

            /*" -1104- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1107- MOVE S-CODPDT TO V0PROD-CODPDT LC08-CODPDT. */
            _.Move(REG_SVF0403B.S_CODPDT, V0PROD_CODPDT, WORK_AREA.LC08.LC08_CODPDT);

            /*" -1112- PERFORM R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1 */

            R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1();

            /*" -1115- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1117- MOVE 'NAO INFORMADO' TO V0PROD-NOMPDT. */
                _.Move("NAO INFORMADO", V0PROD_NOMPDT);
            }


            /*" -1119- MOVE V0PROD-NOMPDT TO LC08-NOMPDT. */
            _.Move(V0PROD_NOMPDT, WORK_AREA.LC08.LC08_NOMPDT);

            /*" -1127- PERFORM R2600-00-IMPRIME-PRODUTO UNTIL S-CODGER NOT EQUAL V0GERE-CODGER OR S-FONTE NOT EQUAL V0FONT-FONTE OR S-CODAST NOT EQUAL V0ASST-CODAST OR S-CODSUBES NOT EQUAL V0SUBG-CODSUBES OR S-CODPDT NOT EQUAL V0PROD-CODPDT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVF0403B.S_CODGER != V0GERE_CODGER || REG_SVF0403B.S_FONTE != V0FONT_FONTE || REG_SVF0403B.S_CODAST != V0ASST_CODAST || REG_SVF0403B.S_CODSUBES != V0SUBG_CODSUBES || REG_SVF0403B.S_CODPDT != V0PROD_CODPDT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2600_00_IMPRIME_PRODUTO_SECTION();
            }

            /*" -1129- MOVE 'TOTAL DO ANGARIADOR/CORRETOR' TO LT01-NOME. */
            _.Move("TOTAL DO ANGARIADOR/CORRETOR", WORK_AREA.LT01.LT01_NOME);

            /*" -1130- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-VEN / AC-VIDAS-VEN. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_VEN / WORK_AREA.AC_VIDAS_VEN;

            /*" -1132- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-VEN / AC-VIDAS-VEN. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_VEN / WORK_AREA.AC_VIDAS_VEN;

            /*" -1133- MOVE AC-VIDAS-VEN TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_VEN, WORK_AREA.LT01.LT01_VIDAS);

            /*" -1134- MOVE AC-VLPREMIO-VEN TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_VEN, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -1135- MOVE AC-IMPMORNATU-VEN TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_VEN, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -1136- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -1138- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -1139- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -1140- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -1141- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -1142- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1143- WRITE REG-IMPRESSAO FROM LC02 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1144- WRITE REG-IMPRESSAO FROM LC03 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1145- WRITE REG-IMPRESSAO FROM LC04 AFTER 2 */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1146- WRITE REG-IMPRESSAO FROM LC05 */
                _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1147- WRITE REG-IMPRESSAO FROM LC06 */
                _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1148- WRITE REG-IMPRESSAO FROM LC07 */
                _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1150- WRITE REG-IMPRESSAO FROM LC08. */
                _.Move(WORK_AREA.LC08.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());
            }


            /*" -1150- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R2500-00-IMPRIME-VENDEDOR-DB-SELECT-1 */
        public void R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1()
        {
            /*" -1112- EXEC SQL SELECT NOMPDT INTO :V0PROD-NOMPDT FROM SEGUROS.V0PRODUTOR WHERE CODPDT = :V0PROD-CODPDT END-EXEC. */

            var r2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1 = new R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1()
            {
                V0PROD_CODPDT = V0PROD_CODPDT.ToString(),
            };

            var executed_1 = R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1.Execute(r2500_00_IMPRIME_VENDEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_NOMPDT, V0PROD_NOMPDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-IMPRIME-PRODUTO-SECTION */
        private void R2600_00_IMPRIME_PRODUTO_SECTION()
        {
            /*" -1167- MOVE +0 TO AC-VIDAS-PRD AC-IMPMORNATU-PRD AC-VLPREMIO-PRD. */
            _.Move(+0, WORK_AREA.AC_VIDAS_PRD, WORK_AREA.AC_IMPMORNATU_PRD, WORK_AREA.AC_VLPREMIO_PRD);

            /*" -1169- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1172- MOVE S-CODPRODU TO V0PDVG-CODPRODU LC09-CODPRODU. */
            _.Move(REG_SVF0403B.S_CODPRODU, V0PDVG_CODPRODU, WORK_AREA.LC09.LC09_CODPRODU);

            /*" -1177- PERFORM R2600_00_IMPRIME_PRODUTO_DB_SELECT_1 */

            R2600_00_IMPRIME_PRODUTO_DB_SELECT_1();

            /*" -1180- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1181- DISPLAY 'PRODUTO NAO ENCONTRADO = ' S-CODPRODU */
                _.Display($"PRODUTO NAO ENCONTRADO = {REG_SVF0403B.S_CODPRODU}");

                /*" -1183- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1185- MOVE V0PDVG-NOMPRODU TO LC09-NOMPRODU. */
            _.Move(V0PDVG_NOMPRODU, WORK_AREA.LC09.LC09_NOMPRODU);

            /*" -1187- PERFORM R2800-00-IMPRIME-CABECALHO. */

            R2800_00_IMPRIME_CABECALHO_SECTION();

            /*" -1196- PERFORM R2700-00-IMPRIME-SEGURADOS UNTIL S-CODGER NOT EQUAL V0GERE-CODGER OR S-FONTE NOT EQUAL V0FONT-FONTE OR S-CODAST NOT EQUAL V0ASST-CODAST OR S-CODSUBES NOT EQUAL V0SUBG-CODSUBES OR S-CODPDT NOT EQUAL V0PROD-CODPDT OR S-CODPRODU NOT EQUAL V0PDVG-CODPRODU OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVF0403B.S_CODGER != V0GERE_CODGER || REG_SVF0403B.S_FONTE != V0FONT_FONTE || REG_SVF0403B.S_CODAST != V0ASST_CODAST || REG_SVF0403B.S_CODSUBES != V0SUBG_CODSUBES || REG_SVF0403B.S_CODPDT != V0PROD_CODPDT || REG_SVF0403B.S_CODPRODU != V0PDVG_CODPRODU || WORK_AREA.WFIM_SORT == "S"))
            {

                R2700_00_IMPRIME_SEGURADOS_SECTION();
            }

            /*" -1198- MOVE 'TOTAL DO PRODUTO' TO LT01-NOME. */
            _.Move("TOTAL DO PRODUTO", WORK_AREA.LT01.LT01_NOME);

            /*" -1199- COMPUTE WS-VLPREMIO-MED = AC-VLPREMIO-PRD / AC-VIDAS-PRD. */
            WORK_AREA.WS_VLPREMIO_MED.Value = WORK_AREA.AC_VLPREMIO_PRD / WORK_AREA.AC_VIDAS_PRD;

            /*" -1201- COMPUTE WS-IMPMORNATU-MED = AC-IMPMORNATU-PRD / AC-VIDAS-PRD. */
            WORK_AREA.WS_IMPMORNATU_MED.Value = WORK_AREA.AC_IMPMORNATU_PRD / WORK_AREA.AC_VIDAS_PRD;

            /*" -1202- MOVE AC-VIDAS-PRD TO LT01-VIDAS. */
            _.Move(WORK_AREA.AC_VIDAS_PRD, WORK_AREA.LT01.LT01_VIDAS);

            /*" -1203- MOVE AC-VLPREMIO-PRD TO LT01-VLPREMIO. */
            _.Move(WORK_AREA.AC_VLPREMIO_PRD, WORK_AREA.LT01.LT01_VLPREMIO);

            /*" -1204- MOVE AC-IMPMORNATU-PRD TO LT01-IMPMORNATU. */
            _.Move(WORK_AREA.AC_IMPMORNATU_PRD, WORK_AREA.LT01.LT01_IMPMORNATU);

            /*" -1205- MOVE WS-VLPREMIO-MED TO LT01-VLPREMIO-MED. */
            _.Move(WORK_AREA.WS_VLPREMIO_MED, WORK_AREA.LT01.LT01_VLPREMIO_MED);

            /*" -1207- MOVE WS-IMPMORNATU-MED TO LT01-IMPMORNATU-MED. */
            _.Move(WORK_AREA.WS_IMPMORNATU_MED, WORK_AREA.LT01.LT01_IMPMORNATU_MED);

            /*" -1208- IF AC-LINHA > 64 */

            if (WORK_AREA.AC_LINHA > 64)
            {

                /*" -1209- ADD 1 TO AC-PAGINA */
                WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

                /*" -1210- MOVE AC-PAGINA TO LC01-PAGINA */
                _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

                /*" -1211- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA */
                _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1212- WRITE REG-IMPRESSAO FROM LC02 */
                _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1213- WRITE REG-IMPRESSAO FROM LC03 */
                _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1214- WRITE REG-IMPRESSAO FROM LC04 AFTER 2 */
                _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1215- WRITE REG-IMPRESSAO FROM LC05 */
                _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1216- WRITE REG-IMPRESSAO FROM LC06 */
                _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1217- WRITE REG-IMPRESSAO FROM LC07 */
                _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1218- WRITE REG-IMPRESSAO FROM LC08 */
                _.Move(WORK_AREA.LC08.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

                /*" -1220- WRITE REG-IMPRESSAO FROM LC09. */
                _.Move(WORK_AREA.LC09.GetMoveValues(), REG_IMPRESSAO);

                RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());
            }


            /*" -1220- WRITE REG-IMPRESSAO FROM LT01 AFTER 2. */
            _.Move(WORK_AREA.LT01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R2600-00-IMPRIME-PRODUTO-DB-SELECT-1 */
        public void R2600_00_IMPRIME_PRODUTO_DB_SELECT_1()
        {
            /*" -1177- EXEC SQL SELECT DESCRPROD INTO :V0PDVG-NOMPRODU FROM SEGUROS.V0PRODUTO WHERE CODPRODU = :V0PDVG-CODPRODU END-EXEC. */

            var r2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1 = new R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1()
            {
                V0PDVG_CODPRODU = V0PDVG_CODPRODU.ToString(),
            };

            var executed_1 = R2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1.Execute(r2600_00_IMPRIME_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PDVG_NOMPRODU, V0PDVG_NOMPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-IMPRIME-SEGURADOS-SECTION */
        private void R2700_00_IMPRIME_SEGURADOS_SECTION()
        {
            /*" -1234- IF AC-LINHA GREATER 60 */

            if (WORK_AREA.AC_LINHA > 60)
            {

                /*" -1236- PERFORM R2800-00-IMPRIME-CABECALHO. */

                R2800_00_IMPRIME_CABECALHO_SECTION();
            }


            /*" -1237- MOVE S-NRCERTIF TO WS-NRCERTIF. */
            _.Move(REG_SVF0403B.S_NRCERTIF, WORK_AREA.WS_NRCERTIF);

            /*" -1238- MOVE WS-NRCERTIF-1 TO LD01-NRCERTIF-1. */
            _.Move(WORK_AREA.WS_NRCERTIF_R.WS_NRCERTIF_1, WORK_AREA.LD01.LD01_NRCERTIF_X.LD01_NRCERTIF_1);

            /*" -1239- MOVE '-' TO LD01-TRACO. */
            _.Move("-", WORK_AREA.LD01.LD01_NRCERTIF_X.LD01_TRACO);

            /*" -1240- MOVE WS-NRCERTIF-2 TO LD01-NRCERTIF-2. */
            _.Move(WORK_AREA.WS_NRCERTIF_R.WS_NRCERTIF_2, WORK_AREA.LD01.LD01_NRCERTIF_X.LD01_NRCERTIF_2);

            /*" -1242- MOVE S-NOMESEG TO LD01-NOMESEG. */
            _.Move(REG_SVF0403B.S_NOMESEG, WORK_AREA.LD01.LD01_NOMESEG);

            /*" -1243- MOVE S-DTQITBCO TO DATA-SQL. */
            _.Move(REG_SVF0403B.S_DTQITBCO, WORK_AREA.DATA_SQL);

            /*" -1244- MOVE DIA-SQL TO WS-DIA. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.WS_DATA_R.WS_DIA);

            /*" -1245- MOVE MES-SQL TO WS-MES. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.WS_DATA_R.WS_MES);

            /*" -1246- MOVE ANO-SQL TO WS-ANO. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.WS_DATA_R.WS_ANO);

            /*" -1248- MOVE WS-DATA TO LD01-DTQITBCO. */
            _.Move(WORK_AREA.WS_DATA, WORK_AREA.LD01.LD01_DTQITBCO);

            /*" -1249- MOVE S-VLPREMIO TO LD01-VLPREMIO. */
            _.Move(REG_SVF0403B.S_VLPREMIO, WORK_AREA.LD01.LD01_VLPREMIO);

            /*" -1251- MOVE S-IMPMORNATU TO LD01-IMPMORNATU */
            _.Move(REG_SVF0403B.S_IMPMORNATU, WORK_AREA.LD01.LD01_IMPMORNATU);

            /*" -1252- WRITE REG-IMPRESSAO FROM LD01. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1254- ADD 1 TO AC-LINHA. */
            WORK_AREA.AC_LINHA.Value = WORK_AREA.AC_LINHA + 1;

            /*" -1261- ADD 1 TO AC-VIDAS-PRD AC-VIDAS-VEN AC-VIDAS-AST AC-VIDAS-REP AC-VIDAS-FIL AC-VIDAS-SUB AC-VIDAS-TOT. */
            WORK_AREA.AC_VIDAS_PRD.Value = WORK_AREA.AC_VIDAS_PRD + 1;
            WORK_AREA.AC_VIDAS_VEN.Value = WORK_AREA.AC_VIDAS_VEN + 1;
            WORK_AREA.AC_VIDAS_AST.Value = WORK_AREA.AC_VIDAS_AST + 1;
            WORK_AREA.AC_VIDAS_REP.Value = WORK_AREA.AC_VIDAS_REP + 1;
            WORK_AREA.AC_VIDAS_FIL.Value = WORK_AREA.AC_VIDAS_FIL + 1;
            WORK_AREA.AC_VIDAS_SUB.Value = WORK_AREA.AC_VIDAS_SUB + 1;
            WORK_AREA.AC_VIDAS_TOT.Value = WORK_AREA.AC_VIDAS_TOT + 1;

            /*" -1268- ADD S-VLPREMIO TO AC-VLPREMIO-PRD AC-VLPREMIO-VEN AC-VLPREMIO-AST AC-VLPREMIO-REP AC-VLPREMIO-FIL AC-VLPREMIO-SUB AC-VLPREMIO-TOT. */
            WORK_AREA.AC_VLPREMIO_PRD.Value = WORK_AREA.AC_VLPREMIO_PRD + REG_SVF0403B.S_VLPREMIO;
            WORK_AREA.AC_VLPREMIO_VEN.Value = WORK_AREA.AC_VLPREMIO_VEN + REG_SVF0403B.S_VLPREMIO;
            WORK_AREA.AC_VLPREMIO_AST.Value = WORK_AREA.AC_VLPREMIO_AST + REG_SVF0403B.S_VLPREMIO;
            WORK_AREA.AC_VLPREMIO_REP.Value = WORK_AREA.AC_VLPREMIO_REP + REG_SVF0403B.S_VLPREMIO;
            WORK_AREA.AC_VLPREMIO_FIL.Value = WORK_AREA.AC_VLPREMIO_FIL + REG_SVF0403B.S_VLPREMIO;
            WORK_AREA.AC_VLPREMIO_SUB.Value = WORK_AREA.AC_VLPREMIO_SUB + REG_SVF0403B.S_VLPREMIO;
            WORK_AREA.AC_VLPREMIO_TOT.Value = WORK_AREA.AC_VLPREMIO_TOT + REG_SVF0403B.S_VLPREMIO;

            /*" -1276- ADD S-IMPMORNATU TO AC-IMPMORNATU-PRD AC-IMPMORNATU-VEN AC-IMPMORNATU-AST AC-IMPMORNATU-REP AC-IMPMORNATU-FIL AC-IMPMORNATU-SUB AC-IMPMORNATU-TOT. */
            WORK_AREA.AC_IMPMORNATU_PRD.Value = WORK_AREA.AC_IMPMORNATU_PRD + REG_SVF0403B.S_IMPMORNATU;
            WORK_AREA.AC_IMPMORNATU_VEN.Value = WORK_AREA.AC_IMPMORNATU_VEN + REG_SVF0403B.S_IMPMORNATU;
            WORK_AREA.AC_IMPMORNATU_AST.Value = WORK_AREA.AC_IMPMORNATU_AST + REG_SVF0403B.S_IMPMORNATU;
            WORK_AREA.AC_IMPMORNATU_REP.Value = WORK_AREA.AC_IMPMORNATU_REP + REG_SVF0403B.S_IMPMORNATU;
            WORK_AREA.AC_IMPMORNATU_FIL.Value = WORK_AREA.AC_IMPMORNATU_FIL + REG_SVF0403B.S_IMPMORNATU;
            WORK_AREA.AC_IMPMORNATU_SUB.Value = WORK_AREA.AC_IMPMORNATU_SUB + REG_SVF0403B.S_IMPMORNATU;
            WORK_AREA.AC_IMPMORNATU_TOT.Value = WORK_AREA.AC_IMPMORNATU_TOT + REG_SVF0403B.S_IMPMORNATU;

            /*" -1278- RETURN SVF0403B AT END */
            try
            {
                SVF0403B.Return(REG_SVF0403B, () =>
                {

                    /*" -1278- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-IMPRIME-CABECALHO-SECTION */
        private void R2800_00_IMPRIME_CABECALHO_SECTION()
        {
            /*" -1292- ADD 1 TO AC-PAGINA. */
            WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

            /*" -1294- MOVE AC-PAGINA TO LC01-PAGINA. */
            _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

            /*" -1296- WRITE REG-IMPRESSAO FROM LC01 AFTER SALTA-PAGINA. */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1297- WRITE REG-IMPRESSAO FROM LC02. */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1298- WRITE REG-IMPRESSAO FROM LC03. */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1299- WRITE REG-IMPRESSAO FROM LC04 AFTER 2. */
            _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1300- WRITE REG-IMPRESSAO FROM LC05. */
            _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1301- WRITE REG-IMPRESSAO FROM LC06. */
            _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1302- WRITE REG-IMPRESSAO FROM LC07. */
            _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1303- WRITE REG-IMPRESSAO FROM LC08. */
            _.Move(WORK_AREA.LC08.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1304- WRITE REG-IMPRESSAO FROM LC09. */
            _.Move(WORK_AREA.LC09.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1305- WRITE REG-IMPRESSAO FROM LC10 AFTER 2. */
            _.Move(WORK_AREA.LC10.GetMoveValues(), REG_IMPRESSAO);

            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1306- MOVE SPACES TO REG-IMPRESSAO. */
            _.Move("", REG_IMPRESSAO);

            /*" -1308- WRITE REG-IMPRESSAO. */
            RVF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1308- MOVE 12 TO AC-LINHA. */
            _.Move(12, WORK_AREA.AC_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R9700-00-SEM-SOLICITACAO-SECTION */
        private void R9700_00_SEM_SOLICITACAO_SECTION()
        {
            /*" -1322- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1323- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1324- DISPLAY '*   VF0403B - EMITE RELATORIO DE VENDAS    *' */
            _.Display($"*   VF0403B - EMITE RELATORIO DE VENDAS    *");

            /*" -1325- DISPLAY '*   -------   ----- --------- -- ------    *' */
            _.Display($"*   -------   ----- --------- -- ------    *");

            /*" -1326- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1327- DISPLAY '*             NAO HOUVE SOLICITACAO        *' */
            _.Display($"*             NAO HOUVE SOLICITACAO        *");

            /*" -1328- DISPLAY '*             RELATORIO NAO FOI PRODUZIDO  *' */
            _.Display($"*             RELATORIO NAO FOI PRODUZIDO  *");

            /*" -1329- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1329- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9700_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-SEM-REGISTROS-SECTION */
        private void R9800_00_SEM_REGISTROS_SECTION()
        {
            /*" -1343- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1344- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1345- DISPLAY '*   VF0403B - EMITE RELATORIO DE VENDAS    *' */
            _.Display($"*   VF0403B - EMITE RELATORIO DE VENDAS    *");

            /*" -1346- DISPLAY '*   -------   ----- --------- -- ------    *' */
            _.Display($"*   -------   ----- --------- -- ------    *");

            /*" -1347- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1348- DISPLAY '*             NENHUM MOVIMENTO ENCONTRADO, *' */
            _.Display($"*             NENHUM MOVIMENTO ENCONTRADO, *");

            /*" -1349- DISPLAY '*             RELATORIO NAO FOI PRODUZIDO  *' */
            _.Display($"*             RELATORIO NAO FOI PRODUZIDO  *");

            /*" -1350- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1350- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1364- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1366- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1366- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1368- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1372- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1372- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}