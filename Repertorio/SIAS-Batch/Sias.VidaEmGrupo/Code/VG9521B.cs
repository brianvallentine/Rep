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
using Sias.VidaEmGrupo.DB2.VG9521B;

namespace Code
{
    public class VG9521B
    {
        public bool IsCall { get; set; }

        public VG9521B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   AUTOR  .................  FREDERICO FONSECA.                 *      */
        /*"      *                                                                *      */
        /*"      *   DATA   .................  13.03.2001.                        *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  INCLUI / ALTERA SEGURADOS CONSTAN- *      */
        /*"      *                             TES NO ARQUIVO ENVIADO P/ FUNCEF.  *      */
        /*"      *                             ** APOLICE CONSIGNACAO FUNCEF **   *      */
        /*"      *                             **        093605000853        **   *      */
        /*"      *                             - MORNATU - MORACID - INVPERM      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *             A L T E R A C O E S                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   001 - MANOEL MESSIAS - 12/09/2001 --->> PROCURE POR MM0901   *      */
        /*"      *                                                                *      */
        /*"      *       PASSA A CRITICAR O PREMIO, POIS, RECEBEMOS UM ARQUIVO COM*      */
        /*"      *  ALGUNS PREMIOS CHEGANDO AA CASA DOS TRILHOES, PROVOCANDO, PRO-*      */
        /*"      *  BLEMAS NA RESERVA E NO FATURAMENTO.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA { get; set; } = new FileBasis(new PIC("X", "145", "X(145)"));

        public FileBasis ENTRADA
        {
            get
            {
                _.Move(RECORD_ENTRADA, _ENTRADA); VarBasis.RedefinePassValue(RECORD_ENTRADA, _ENTRADA, RECORD_ENTRADA); return _ENTRADA;
            }
        }
        /*"01  RECORD-ENTRADA.*/
        public VG9521B_RECORD_ENTRADA RECORD_ENTRADA { get; set; } = new VG9521B_RECORD_ENTRADA();
        public class VG9521B_RECORD_ENTRADA : VarBasis
        {
            /*"    05 MATRICULA-REG                 PIC 9(07).*/
            public IntBasis MATRICULA_REG { get; set; } = new IntBasis(new PIC("9", "7", "9(07)."));
            /*"    05 NOME-REG                      PIC X(40).*/
            public StringBasis NOME_REG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 CPF-REG                       PIC 9(11).*/
            public IntBasis CPF_REG { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"    05 DTINIVIG-REG                  PIC X(06).*/
            public StringBasis DTINIVIG_REG { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
            /*"    05 DTTERVIG-REG                  PIC X(06).*/
            public StringBasis DTTERVIG_REG { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
            /*"    05 VAL-EMP-REG                   PIC 9(13)V99.*/
            public DoubleBasis VAL_EMP_REG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 VAL-PRM-REG                   PIC 9(13)V99.*/
            public DoubleBasis VAL_PRM_REG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 VAL-COM-REG                   PIC 9(13)V99.*/
            public DoubleBasis VAL_COM_REG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 VAL-DEV-REG                   PIC 9(13)V99.*/
            public DoubleBasis VAL_DEV_REG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 VAL-ANT-REG                   PIC 9(13)V99.*/
            public DoubleBasis VAL_ANT_REG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-NOME-RAZAO        PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIPO-PESSOA       PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDE-SEXO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-EST-CIVIL         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OCORR-END         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ENDERECO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-BAIRRO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CIDADE            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIGLA-UF          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CEP               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DDD               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TELEFONE          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-FAX               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CGCCPF            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTNASC            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODUSU            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-I      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-F      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WDTNAS-FUNCICEF   PIC  9(009).*/
        public IntBasis WDTNAS_FUNCICEF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01           WDTNAS-FUNCICEF-R REDEFINES WDTNAS-FUNCICEF.*/
        private _REDEF_VG9521B_WDTNAS_FUNCICEF_R _wdtnas_funcicef_r { get; set; }
        public _REDEF_VG9521B_WDTNAS_FUNCICEF_R WDTNAS_FUNCICEF_R
        {
            get { _wdtnas_funcicef_r = new _REDEF_VG9521B_WDTNAS_FUNCICEF_R(); _.Move(WDTNAS_FUNCICEF, _wdtnas_funcicef_r); VarBasis.RedefinePassValue(WDTNAS_FUNCICEF, _wdtnas_funcicef_r, WDTNAS_FUNCICEF); _wdtnas_funcicef_r.ValueChanged += () => { _.Move(_wdtnas_funcicef_r, WDTNAS_FUNCICEF); }; return _wdtnas_funcicef_r; }
            set { VarBasis.RedefinePassValue(value, _wdtnas_funcicef_r, WDTNAS_FUNCICEF); }
        }  //Redefines
        public class _REDEF_VG9521B_WDTNAS_FUNCICEF_R : VarBasis
        {
            /*"  05         ZZ-DTNAS-FCEF     PIC  9(001).*/
            public IntBasis ZZ_DTNAS_FCEF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05         DD-DTNAS-FCEF     PIC  9(002).*/
            public IntBasis DD_DTNAS_FCEF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         MM-DTNAS-FCEF     PIC  9(002).*/
            public IntBasis MM_DTNAS_FCEF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         SS-DTNAS-FCEF     PIC  9(002).*/
            public IntBasis SS_DTNAS_FCEF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         AA-DTNAS-FCEF     PIC  9(002).*/
            public IntBasis AA_DTNAS_FCEF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WDATASQL.*/

            public _REDEF_VG9521B_WDTNAS_FUNCICEF_R()
            {
                ZZ_DTNAS_FCEF.ValueChanged += OnValueChanged;
                DD_DTNAS_FCEF.ValueChanged += OnValueChanged;
                MM_DTNAS_FCEF.ValueChanged += OnValueChanged;
                SS_DTNAS_FCEF.ValueChanged += OnValueChanged;
                AA_DTNAS_FCEF.ValueChanged += OnValueChanged;
            }

        }
        public VG9521B_WDATASQL WDATASQL { get; set; } = new VG9521B_WDATASQL();
        public class VG9521B_WDATASQL : VarBasis
        {
            /*"  05         SS-DATA-SQL       PIC  9(002).*/
            public IntBasis SS_DATA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         AA-DATA-SQL       PIC  9(002).*/
            public IntBasis AA_DATA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO-SQL1        PIC  X(001).*/
            public StringBasis TRACO_SQL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         MM-DATA-SQL       PIC  9(002).*/
            public IntBasis MM_DATA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO-SQL2        PIC  X(001).*/
            public StringBasis TRACO_SQL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         DD-DATA-SQL       PIC  9(002).*/
            public IntBasis DD_DATA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WDATA-FILE.*/
        }
        public VG9521B_WDATA_FILE WDATA_FILE { get; set; } = new VG9521B_WDATA_FILE();
        public class VG9521B_WDATA_FILE : VarBasis
        {
            /*"  05         AA-DATA-FILE      PIC  9(002).*/
            public IntBasis AA_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         MM-DATA-FILE      PIC  9(002).*/
            public IntBasis MM_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         DD-DATA-FILE      PIC  9(002).*/
            public IntBasis DD_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WDTINIVIG.*/
        }
        public VG9521B_WDTINIVIG WDTINIVIG { get; set; } = new VG9521B_WDTINIVIG();
        public class VG9521B_WDTINIVIG : VarBasis
        {
            /*"  05         SS-DATA-INIV      PIC  9(002).*/
            public IntBasis SS_DATA_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         AA-DATA-INIV      PIC  9(002).*/
            public IntBasis AA_DATA_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO01-INIV      PIC  X(001).*/
            public StringBasis TRACO01_INIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         MM-DATA-INIV      PIC  9(002).*/
            public IntBasis MM_DATA_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO02-INIV      PIC  X(001).*/
            public StringBasis TRACO02_INIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         DD-DATA-INIV      PIC  9(002).*/
            public IntBasis DD_DATA_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WDTTERVIG.*/
        }
        public VG9521B_WDTTERVIG WDTTERVIG { get; set; } = new VG9521B_WDTTERVIG();
        public class VG9521B_WDTTERVIG : VarBasis
        {
            /*"  05         SS-DATA-TERV      PIC  9(002).*/
            public IntBasis SS_DATA_TERV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         AA-DATA-TERV      PIC  9(002).*/
            public IntBasis AA_DATA_TERV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO01-TERV      PIC  X(001).*/
            public StringBasis TRACO01_TERV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         MM-DATA-TERV      PIC  9(002).*/
            public IntBasis MM_DATA_TERV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO02-TERV      PIC  X(001).*/
            public StringBasis TRACO02_TERV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         DD-DATA-TERV      PIC  9(002).*/
            public IntBasis DD_DATA_TERV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           AREA-DE-WORK.*/
        }
        public VG9521B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG9521B_AREA_DE_WORK();
        public class VG9521B_AREA_DE_WORK : VarBasis
        {
            /*"  05   WS-DATA-BASE.*/
            public VG9521B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VG9521B_WS_DATA_BASE();
            public class VG9521B_WS_DATA_BASE : VarBasis
            {
                /*"       10 WS-ANO-BASE                PIC  9(004).*/
                public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MES-BASE                PIC  9(002).*/
                public IntBasis WS_MES_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DIA-BASE                PIC  9(002).*/
                public IntBasis WS_DIA_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   WDTNAS-REG.*/
            }
            public VG9521B_WDTNAS_REG WDTNAS_REG { get; set; } = new VG9521B_WDTNAS_REG();
            public class VG9521B_WDTNAS_REG : VarBasis
            {
                /*"       10 ANO-NASC                   PIC 9(04).*/
                public IntBasis ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 MES-NASC                   PIC 9(02).*/
                public IntBasis MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 DIA-NASC                   PIC 9(02).*/
                public IntBasis DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05   W02DTSQL.*/
            }
            public VG9521B_W02DTSQL W02DTSQL { get; set; } = new VG9521B_W02DTSQL();
            public class VG9521B_W02DTSQL : VarBasis
            {
                /*"       10  W02AAMMSQL.*/
                public VG9521B_W02AAMMSQL W02AAMMSQL { get; set; } = new VG9521B_W02AAMMSQL();
                public class VG9521B_W02AAMMSQL : VarBasis
                {
                    /*"           15  W02AASQL              PIC 9(004).*/
                    public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           15  W02T1SQL              PIC X(001).*/
                    public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           15  W02MMSQL              PIC 9(002).*/
                    public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10  W02T2SQL                  PIC X(001).*/
                }
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   W03DTSQL.*/
            }
            public VG9521B_W03DTSQL W03DTSQL { get; set; } = new VG9521B_W03DTSQL();
            public class VG9521B_W03DTSQL : VarBasis
            {
                /*"       10  W03AAMMSQL.*/
                public VG9521B_W03AAMMSQL W03AAMMSQL { get; set; } = new VG9521B_W03AAMMSQL();
                public class VG9521B_W03AAMMSQL : VarBasis
                {
                    /*"           15  W03AASQL              PIC 9(004).*/
                    public IntBasis W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           15  W03T1SQL              PIC X(001).*/
                    public StringBasis W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           15  W03MMSQL              PIC 9(002).*/
                    public IntBasis W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10  W03T2SQL                  PIC X(001).*/
                }
                public StringBasis W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10  W03DDSQL                  PIC 9(002).*/
                public IntBasis W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS           PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-JA-TEM-SEGURO   PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_JA_TEM_SEGURO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-NAO-TEM-SEGURO  PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_NAO_TEM_SEGURO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-ATIVOS          PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_ATIVOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-ALTERADOS       PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_ALTERADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-ENTRADA      PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_ENTRADA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PLANOS       PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_PLANOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         IDX               PIC 9(002)  VALUE ZEROS.*/
            public IntBasis IDX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WTEM-GECLIMOV          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WABEND.*/
            public VG9521B_WABEND WABEND { get; set; } = new VG9521B_WABEND();
            public class VG9521B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG9521B '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG9521B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public VG9521B_C01_GECLIMOV C01_GECLIMOV { get; set; } = new VG9521B_C01_GECLIMOV();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ENTRADA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ENTRADA.SetFile(ENTRADA_FILE_NAME_P);

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
            /*" -265- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -268- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -271- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -275- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -281- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -286- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -288- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -295- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -298- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -300- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -302- OPEN INPUT ENTRADA. */
            ENTRADA.Open(RECORD_ENTRADA);

            /*" -302- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -305- MOVE 'S' TO WFIM-ENTRADA. */
                    _.Move("S", AREA_DE_WORK.WFIM_ENTRADA);
                });

                _.Move(ENTRADA.Value, RECORD_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -306- IF WFIM-ENTRADA NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_ENTRADA != "S")
            {

                /*" -307- MOVE 93605000853 TO SEGURVGA-NUM-APOLICE */
                _.Move(93605000853, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

                /*" -308- MOVE 0001 TO SEGURVGA-COD-SUBGRUPO */
                _.Move(0001, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

                /*" -309- MOVE '0003' TO WNR-EXEC-SQL */
                _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -315- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_1 */

                R0000_00_PRINCIPAL_DB_UPDATE_1();

                /*" -317- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -318- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -320- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -323- PERFORM R0050-00-PROCESSA-REGISTRO UNTIL WFIM-ENTRADA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ENTRADA.IsEmpty()))
            {

                R0050_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -325- CLOSE ENTRADA. */
            ENTRADA.Close();

            /*" -326- DISPLAY ' ' */
            _.Display($" ");

            /*" -327- DISPLAY '*--------  VG9521B - FIM NORMAL  --------*' */
            _.Display($"*--------  VG9521B - FIM NORMAL  --------*");

            /*" -328- DISPLAY ' ' */
            _.Display($" ");

            /*" -329- DISPLAY 'TOTAL LIDOS ARQ. ENTRADA    ..... ' WACC-LIDOS. */
            _.Display($"TOTAL LIDOS ARQ. ENTRADA    ..... {AREA_DE_WORK.WACC_LIDOS}");

            /*" -331- DISPLAY 'TOTAL DE SEGUROS EXISTENTES ..... ' WACC-JA-TEM-SEGURO */
            _.Display($"TOTAL DE SEGUROS EXISTENTES ..... {AREA_DE_WORK.WACC_JA_TEM_SEGURO}");

            /*" -333- DISPLAY 'TOTAL DE SEGUROS INEXISTENTES ... ' WACC-NAO-TEM-SEGURO. */
            _.Display($"TOTAL DE SEGUROS INEXISTENTES ... {AREA_DE_WORK.WACC_NAO_TEM_SEGURO}");

            /*" -335- DISPLAY 'TOTAL DE SEGUROS ATIVOS       ... ' WACC-ATIVOS */
            _.Display($"TOTAL DE SEGUROS ATIVOS       ... {AREA_DE_WORK.WACC_ATIVOS}");

            /*" -338- DISPLAY 'TOTAL DE SEGUROS ALTERADOS    ... ' WACC-ALTERADOS */
            _.Display($"TOTAL DE SEGUROS ALTERADOS    ... {AREA_DE_WORK.WACC_ALTERADOS}");

            /*" -339- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -339- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -281- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -345- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -345- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-1 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -315- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET COD_PROFISSAO = 0 WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC */

            var r0000_00_PRINCIPAL_DB_UPDATE_1_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_1_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -295- EXEC SQL SELECT DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = 93605000853 AND NUM_ENDOSSO = 0 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCESSA-REGISTRO-SECTION */
        private void R0050_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -357- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

            /*" -358- IF MATRICULA-REG NOT NUMERIC */

            if (!RECORD_ENTRADA.MATRICULA_REG.IsNumeric())
            {

                /*" -360- GO TO R0050-90-NEXT. */

                R0050_90_NEXT(); //GOTO
                return;
            }


            /*" -362- IF VAL-EMP-REG EQUAL ZEROS OR VAL-PRM-REG EQUAL ZEROS */

            if (RECORD_ENTRADA.VAL_EMP_REG == 00 || RECORD_ENTRADA.VAL_PRM_REG == 00)
            {

                /*" -364- GO TO R0050-90-NEXT. */

                R0050_90_NEXT(); //GOTO
                return;
            }


            /*" -365- IF VAL-PRM-REG > 10000,00 */

            if (RECORD_ENTRADA.VAL_PRM_REG > 10000.00)
            {

                /*" -366- DISPLAY 'EMPRESTIMO COM VALOR INVALIDO > 10000,00 ' */
                _.Display($"EMPRESTIMO COM VALOR INVALIDO > 10000,00 ");

                /*" -367- DISPLAY RECORD-ENTRADA */
                _.Display(RECORD_ENTRADA);

                /*" -369- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -370- IF VAL-EMP-REG GREATER 100000,00 */

            if (RECORD_ENTRADA.VAL_EMP_REG > 100000.00)
            {

                /*" -371- DISPLAY 'EMPRESTIMO COM VALOR INVALIDO > 100000 ' */
                _.Display($"EMPRESTIMO COM VALOR INVALIDO > 100000 ");

                /*" -372- DISPLAY RECORD-ENTRADA */
                _.Display(RECORD_ENTRADA);

                /*" -374- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -375- MOVE 093605000853 TO SEGURVGA-NUM-APOLICE. */
            _.Move(093605000853, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -376- MOVE 0001 TO SEGURVGA-COD-SUBGRUPO. */
            _.Move(0001, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -378- MOVE MATRICULA-REG TO SEGURVGA-NUM-MATRICULA. */
            _.Move(RECORD_ENTRADA.MATRICULA_REG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);

            /*" -380- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -402- PERFORM R0050_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R0050_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -405- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -406- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -407- MOVE 093605000853 TO SEGURVGA-NUM-APOLICE */
                    _.Move(093605000853, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

                    /*" -408- MOVE 0001 TO SEGURVGA-COD-SUBGRUPO */
                    _.Move(0001, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

                    /*" -409- PERFORM R0060-00-INTEGRA-VG */

                    R0060_00_INTEGRA_VG_SECTION();

                    /*" -410- ADD 1 TO WACC-NAO-TEM-SEGURO */
                    AREA_DE_WORK.WACC_NAO_TEM_SEGURO.Value = AREA_DE_WORK.WACC_NAO_TEM_SEGURO + 1;

                    /*" -411- GO TO R0050-90-NEXT */

                    R0050_90_NEXT(); //GOTO
                    return;

                    /*" -412- ELSE */
                }
                else
                {


                    /*" -413- IF SQLCODE = -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -414- ADD 1 TO WACC-JA-TEM-SEGURO */
                        AREA_DE_WORK.WACC_JA_TEM_SEGURO.Value = AREA_DE_WORK.WACC_JA_TEM_SEGURO + 1;

                        /*" -415- DISPLAY 'R0050-00 (ERRO - SELECT V0SEGURAVG )' */
                        _.Display($"R0050-00 (ERRO - SELECT V0SEGURAVG )");

                        /*" -416- DISPLAY 'R0050-00   -   SQLCODE  ' SQLCODE */
                        _.Display($"R0050-00   -   SQLCODE  {DB.SQLCODE}");

                        /*" -417- DISPLAY 'NOME                    ' NOME-REG */
                        _.Display($"NOME                    {RECORD_ENTRADA.NOME_REG}");

                        /*" -420- DISPLAY 'CERTIFICADO             ' SEGURVGA-NUM-CERTIFICADO ' ' SEGURVGA-NUM-MATRICULA */

                        $"CERTIFICADO             {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA}"
                        .Display();

                        /*" -421- ADD 1 TO WACC-ATIVOS */
                        AREA_DE_WORK.WACC_ATIVOS.Value = AREA_DE_WORK.WACC_ATIVOS + 1;

                        /*" -422- MOVE '0052' TO WNR-EXEC-SQL */
                        _.Move("0052", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -428- PERFORM R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

                        R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1();

                        /*" -430- IF SQLCODE NOT EQUAL ZEROS */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -431- IF SQLCODE NOT EQUAL 100 */

                            if (DB.SQLCODE != 100)
                            {

                                /*" -432- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -433- END-IF */
                            }


                            /*" -434- END-IF */
                        }


                        /*" -435- IF SEGURVGA-SIT-REGISTRO = '0' OR '1' */

                        if (SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO.In("0", "1"))
                        {

                            /*" -436- PERFORM R6666-00-AUMENTA-REDUZ-VG */

                            R6666_00_AUMENTA_REDUZ_VG_SECTION();

                            /*" -437- END-IF */
                        }


                        /*" -438- ELSE */
                    }
                    else
                    {


                        /*" -439- DISPLAY 'R0050-00 (ERRO - SELECT V0SEGURAVG )' */
                        _.Display($"R0050-00 (ERRO - SELECT V0SEGURAVG )");

                        /*" -440- DISPLAY 'R0050-00   -   SQLCODE  ' SQLCODE */
                        _.Display($"R0050-00   -   SQLCODE  {DB.SQLCODE}");

                        /*" -441- DISPLAY 'NOME                    ' NOME-REG */
                        _.Display($"NOME                    {RECORD_ENTRADA.NOME_REG}");

                        /*" -442- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -443- ELSE */
                    }

                }

            }
            else
            {


                /*" -444- ADD 1 TO WACC-JA-TEM-SEGURO */
                AREA_DE_WORK.WACC_JA_TEM_SEGURO.Value = AREA_DE_WORK.WACC_JA_TEM_SEGURO + 1;

                /*" -446- DISPLAY 'SEGURADO EXISTENTE - NRCERTIF ' SEGURVGA-NUM-CERTIFICADO ' ' SEGURVGA-SIT-REGISTRO */

                $"SEGURADO EXISTENTE - NRCERTIF {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO}"
                .Display();

                /*" -448- DISPLAY 'NOME                          ' NOME-REG */
                _.Display($"NOME                          {RECORD_ENTRADA.NOME_REG}");

                /*" -449- MOVE '0053' TO WNR-EXEC-SQL */
                _.Move("0053", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -455- PERFORM R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2 */

                R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2();

                /*" -457- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -458- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -459- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -460- END-IF */
                    }


                    /*" -461- END-IF */
                }


                /*" -462- IF SEGURVGA-SIT-REGISTRO = '0' OR '1' */

                if (SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO.In("0", "1"))
                {

                    /*" -463- PERFORM R6666-00-AUMENTA-REDUZ-VG */

                    R6666_00_AUMENTA_REDUZ_VG_SECTION();

                    /*" -463- ADD 1 TO WACC-ATIVOS. */
                    AREA_DE_WORK.WACC_ATIVOS.Value = AREA_DE_WORK.WACC_ATIVOS + 1;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0050_90_NEXT */

            R0050_90_NEXT();

        }

        [StopWatch]
        /*" R0050-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R0050_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -402- EXEC SQL SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_CERTIFICADO, A.NUM_ITEM, A.OCORR_HISTORICO, A.COD_CLIENTE, A.SIT_REGISTRO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-SIT-REGISTRO FROM SEGUROS.SEGURADOS_VGAP A WHERE A.NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND A.COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO AND A.NUM_MATRICULA = :SEGURVGA-NUM-MATRICULA AND A.TIPO_SEGURADO = '1' AND A.SIT_REGISTRO IN ( '0' , '1' ) END-EXEC. */

            var r0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_MATRICULA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R0050-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -428- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET COD_PROFISSAO = 9521 WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC */

            var r0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0050-90-NEXT */
        private void R0050_90_NEXT(bool isPerform = false)
        {
            /*" -466- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -467- MOVE 'S' TO WFIM-ENTRADA. */
                    _.Move("S", AREA_DE_WORK.WFIM_ENTRADA);
                });

                _.Move(ENTRADA.Value, RECORD_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
        }

        [StopWatch]
        /*" R0050-00-PROCESSA-REGISTRO-DB-UPDATE-2 */
        public void R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2()
        {
            /*" -455- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET COD_PROFISSAO = 9521 WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC */

            var r0050_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 = new R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1.Execute(r0050_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-INTEGRA-VG-SECTION */
        private void R0060_00_INTEGRA_VG_SECTION()
        {
            /*" -478- MOVE MATRICULA-REG TO FUNCICEF-NUM-MATRICULA. */
            _.Move(RECORD_ENTRADA.MATRICULA_REG, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA);

            /*" -480- MOVE '0960' TO WNR-EXEC-SQL. */
            _.Move("0960", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -488- PERFORM R0060_00_INTEGRA_VG_DB_SELECT_1 */

            R0060_00_INTEGRA_VG_DB_SELECT_1();

            /*" -491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -492- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -493- MOVE '096A' TO WNR-EXEC-SQL */
                    _.Move("096A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -494- MOVE CPF-REG TO CLIENTES-CGCCPF */
                    _.Move(RECORD_ENTRADA.CPF_REG, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                    /*" -495- MOVE NOME-REG TO CLIENTES-NOME-RAZAO */
                    _.Move(RECORD_ENTRADA.NOME_REG, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -505- PERFORM R0060_00_INTEGRA_VG_DB_SELECT_2 */

                    R0060_00_INTEGRA_VG_DB_SELECT_2();

                    /*" -507- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -508- MOVE '1900-01-01' TO WDATASQL */
                        _.Move("1900-01-01", WDATASQL);

                        /*" -509- GO TO R0060-01-CLIENTE */

                        R0060_01_CLIENTE(); //GOTO
                        return;

                        /*" -510- ELSE */
                    }
                    else
                    {


                        /*" -511- MOVE CLIENTES-DATA-NASCIMENTO TO WDATASQL */
                        _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, WDATASQL);

                        /*" -512- GO TO R0060-01-CLIENTE */

                        R0060_01_CLIENTE(); //GOTO
                        return;

                        /*" -513- ELSE */
                    }

                }
                else
                {


                    /*" -514- DISPLAY 'ERRO ACESSO FUNCIOCEF ' SQLCODE */
                    _.Display($"ERRO ACESSO FUNCIOCEF {DB.SQLCODE}");

                    /*" -516- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -518- MOVE FUNCICEF-NASCIMENTO TO WDTNAS-FUNCICEF. */
            _.Move(FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NASCIMENTO, WDTNAS_FUNCICEF);

            /*" -519- MOVE DD-DTNAS-FCEF TO DD-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.DD_DTNAS_FCEF, WDATASQL.DD_DATA_SQL);

            /*" -520- MOVE MM-DTNAS-FCEF TO MM-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.MM_DTNAS_FCEF, WDATASQL.MM_DATA_SQL);

            /*" -521- MOVE SS-DTNAS-FCEF TO SS-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.SS_DTNAS_FCEF, WDATASQL.SS_DATA_SQL);

            /*" -522- MOVE AA-DTNAS-FCEF TO AA-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.AA_DTNAS_FCEF, WDATASQL.AA_DATA_SQL);

            /*" -523- MOVE '-' TO TRACO-SQL1. */
            _.Move("-", WDATASQL.TRACO_SQL1);

            /*" -523- MOVE '-' TO TRACO-SQL2. */
            _.Move("-", WDATASQL.TRACO_SQL2);

            /*" -0- FLUXCONTROL_PERFORM R0060_01_CLIENTE */

            R0060_01_CLIENTE();

        }

        [StopWatch]
        /*" R0060-00-INTEGRA-VG-DB-SELECT-1 */
        public void R0060_00_INTEGRA_VG_DB_SELECT_1()
        {
            /*" -488- EXEC SQL SELECT NASCIMENTO INTO :FUNCICEF-NASCIMENTO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA END-EXEC. */

            var r0060_00_INTEGRA_VG_DB_SELECT_1_Query1 = new R0060_00_INTEGRA_VG_DB_SELECT_1_Query1()
            {
                FUNCICEF_NUM_MATRICULA = FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R0060_00_INTEGRA_VG_DB_SELECT_1_Query1.Execute(r0060_00_INTEGRA_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NASCIMENTO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NASCIMENTO);
            }


        }

        [StopWatch]
        /*" R0060-01-CLIENTE */
        private void R0060_01_CLIENTE(bool isPerform = false)
        {
            /*" -528- MOVE WDATASQL TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(WDATASQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -530- MOVE '9992' TO WNR-EXEC-SQL. */
            _.Move("9992", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -543- PERFORM R0060_01_CLIENTE_DB_SELECT_1 */

            R0060_01_CLIENTE_DB_SELECT_1();

            /*" -546- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -547- DISPLAY 'ERRO ACESSO SUBGRUPO ' SQLCODE */
                _.Display($"ERRO ACESSO SUBGRUPO {DB.SQLCODE}");

                /*" -549- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -551- MOVE '0060' TO WNR-EXEC-SQL. */
            _.Move("0060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -553- MOVE WDATASQL TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(WDATASQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -555- MOVE CPF-REG TO CLIENTES-CGCCPF. */
            _.Move(RECORD_ENTRADA.CPF_REG, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -556- IF CLIENTES-CGCCPF EQUAL ZEROS OR 191 */

            if (CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.In("00", "191"))
            {

                /*" -557- MOVE ZEROS TO SEGURVGA-COD-CLIENTE */
                _.Move(0, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

                /*" -559- GO TO R0060-09-CRIA-CLIENTE. */

                R0060_09_CRIA_CLIENTE(); //GOTO
                return;
            }


            /*" -561- MOVE '0171' TO WNR-EXEC-SQL. */
            _.Move("0171", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -569- PERFORM R0060_01_CLIENTE_DB_SELECT_2 */

            R0060_01_CLIENTE_DB_SELECT_2();

            /*" -572- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -574- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -575- IF SEGURVGA-COD-CLIENTE NOT EQUAL ZEROS */

            if (SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE != 00)
            {

                /*" -576- MOVE WDATASQL TO CLIENTES-DATA-NASCIMENTO */
                _.Move(WDATASQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -576- GO TO R0060-10-CONTINUA. */

                R0060_10_CONTINUA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0060-01-CLIENTE-DB-SELECT-1 */
        public void R0060_01_CLIENTE_DB_SELECT_1()
        {
            /*" -543- EXEC SQL SELECT COD_CLIENTE, COD_FONTE, OCORR_ENDERECO INTO :SUBGVGAP-COD-CLIENTE, :SUBGVGAP-COD-FONTE, :SUBGVGAP-OCORR-ENDERECO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r0060_01_CLIENTE_DB_SELECT_1_Query1 = new R0060_01_CLIENTE_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0060_01_CLIENTE_DB_SELECT_1_Query1.Execute(r0060_01_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R0060-00-INTEGRA-VG-DB-SELECT-2 */
        public void R0060_00_INTEGRA_VG_DB_SELECT_2()
        {
            /*" -505- EXEC SQL SELECT MAX( VALUE(DATA_NASCIMENTO, DATE( '1900-01-01' ))) INTO CLIENTES-DATA-NASCIMENTO FROM SEGUROS.CLIENTES WHERE NOME_RAZAO = :CLIENTES-NOME-RAZAO AND CGCCPF = :CLIENTES-CGCCPF END-EXEC */

            var r0060_00_INTEGRA_VG_DB_SELECT_2_Query1 = new R0060_00_INTEGRA_VG_DB_SELECT_2_Query1()
            {
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R0060_00_INTEGRA_VG_DB_SELECT_2_Query1.Execute(r0060_00_INTEGRA_VG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
            }


        }

        [StopWatch]
        /*" R0060-01-CLIENTE-DB-SELECT-2 */
        public void R0060_01_CLIENTE_DB_SELECT_2()
        {
            /*" -569- EXEC SQL SELECT VALUE(MAX(COD_CLIENTE),0) INTO :SEGURVGA-COD-CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :CLIENTES-CGCCPF AND DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO END-EXEC. */

            var r0060_01_CLIENTE_DB_SELECT_2_Query1 = new R0060_01_CLIENTE_DB_SELECT_2_Query1()
            {
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R0060_01_CLIENTE_DB_SELECT_2_Query1.Execute(r0060_01_CLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0060-09-CRIA-CLIENTE */
        private void R0060_09_CRIA_CLIENTE(bool isPerform = false)
        {
            /*" -582- MOVE '0062' TO WNR-EXEC-SQL. */
            _.Move("0062", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -587- PERFORM R0060_09_CRIA_CLIENTE_DB_SELECT_1 */

            R0060_09_CRIA_CLIENTE_DB_SELECT_1();

            /*" -590- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -592- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -594- COMPUTE SEGURVGA-COD-CLIENTE = SEGURVGA-COD-CLIENTE + 1. */
            SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.Value = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE + 1;

            /*" -596- MOVE '0063' TO WNR-EXEC-SQL. */
            _.Move("0063", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -601- PERFORM R0060_09_CRIA_CLIENTE_DB_UPDATE_1 */

            R0060_09_CRIA_CLIENTE_DB_UPDATE_1();

            /*" -604- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -606- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -608- MOVE '0064' TO WNR-EXEC-SQL. */
            _.Move("0064", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -610- MOVE WDATASQL TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(WDATASQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -612- MOVE CPF-REG TO CLIENTES-CGCCPF. */
            _.Move(RECORD_ENTRADA.CPF_REG, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -614- MOVE NOME-REG TO CLIENTES-NOME-RAZAO. */
            _.Move(RECORD_ENTRADA.NOME_REG, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -651- PERFORM R0060_09_CRIA_CLIENTE_DB_INSERT_1 */

            R0060_09_CRIA_CLIENTE_DB_INSERT_1();

            /*" -656- MOVE '9993' TO WNR-EXEC-SQL. */
            _.Move("9993", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R0060_09_CRIA_CLIENTE_DB_SELECT_2 */

            R0060_09_CRIA_CLIENTE_DB_SELECT_2();

            /*" -676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- DISPLAY 'ERRO ACESSO ENDERECO ' SQLCODE */
                _.Display($"ERRO ACESSO ENDERECO {DB.SQLCODE}");

                /*" -680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -682- MOVE '0065' TO WNR-EXEC-SQL. */
            _.Move("0065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -713- PERFORM R0060_09_CRIA_CLIENTE_DB_INSERT_2 */

            R0060_09_CRIA_CLIENTE_DB_INSERT_2();

            /*" -716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -718- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -718- PERFORM R7300-00-TRATA-MOVTO-CLIENTE. */

            R7300_00_TRATA_MOVTO_CLIENTE_SECTION();

        }

        [StopWatch]
        /*" R0060-09-CRIA-CLIENTE-DB-SELECT-1 */
        public void R0060_09_CRIA_CLIENTE_DB_SELECT_1()
        {
            /*" -587- EXEC SQL SELECT NUM_CLIENTE INTO :SEGURVGA-COD-CLIENTE FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1 = new R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1.Execute(r0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0060-09-CRIA-CLIENTE-DB-UPDATE-1 */
        public void R0060_09_CRIA_CLIENTE_DB_UPDATE_1()
        {
            /*" -601- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :SEGURVGA-COD-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1 = new R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1.Execute(r0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0060-09-CRIA-CLIENTE-DB-INSERT-1 */
        public void R0060_09_CRIA_CLIENTE_DB_INSERT_1()
        {
            /*" -651- EXEC SQL INSERT INTO SEGUROS.CLIENTES ( COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:SEGURVGA-COD-CLIENTE, :CLIENTES-NOME-RAZAO, 'F' , :CLIENTES-CGCCPF, '0' , :CLIENTES-DATA-NASCIMENTO, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1 = new R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
            };

            R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1.Execute(r0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0060-10-CONTINUA */
        private void R0060_10_CONTINUA(bool isPerform = false)
        {
            /*" -723- MOVE SUBGVGAP-COD-FONTE TO SEGURVGA-COD-FONTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);

            /*" -724- MOVE 093605000853 TO SEGURVGA-NUM-APOLICE */
            _.Move(093605000853, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -726- MOVE 0001 TO SEGURVGA-COD-SUBGRUPO */
            _.Move(0001, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -727- MOVE DTINIVIG-REG TO WDATA-FILE. */
            _.Move(RECORD_ENTRADA.DTINIVIG_REG, WDATA_FILE);

            /*" -728- MOVE 20 TO SS-DATA-INIV. */
            _.Move(20, WDTINIVIG.SS_DATA_INIV);

            /*" -729- MOVE AA-DATA-FILE TO AA-DATA-INIV. */
            _.Move(WDATA_FILE.AA_DATA_FILE, WDTINIVIG.AA_DATA_INIV);

            /*" -730- MOVE '-' TO TRACO01-INIV. */
            _.Move("-", WDTINIVIG.TRACO01_INIV);

            /*" -731- MOVE MM-DATA-FILE TO MM-DATA-INIV. */
            _.Move(WDATA_FILE.MM_DATA_FILE, WDTINIVIG.MM_DATA_INIV);

            /*" -732- MOVE '-' TO TRACO02-INIV. */
            _.Move("-", WDTINIVIG.TRACO02_INIV);

            /*" -734- MOVE DD-DATA-FILE TO DD-DATA-INIV. */
            _.Move(WDATA_FILE.DD_DATA_FILE, WDTINIVIG.DD_DATA_INIV);

            /*" -735- MOVE DTTERVIG-REG TO WDATA-FILE. */
            _.Move(RECORD_ENTRADA.DTTERVIG_REG, WDATA_FILE);

            /*" -736- MOVE 20 TO SS-DATA-TERV. */
            _.Move(20, WDTTERVIG.SS_DATA_TERV);

            /*" -737- MOVE AA-DATA-FILE TO AA-DATA-TERV. */
            _.Move(WDATA_FILE.AA_DATA_FILE, WDTTERVIG.AA_DATA_TERV);

            /*" -738- MOVE '-' TO TRACO01-TERV. */
            _.Move("-", WDTTERVIG.TRACO01_TERV);

            /*" -739- MOVE MM-DATA-FILE TO MM-DATA-TERV. */
            _.Move(WDATA_FILE.MM_DATA_FILE, WDTTERVIG.MM_DATA_TERV);

            /*" -740- MOVE '-' TO TRACO02-TERV. */
            _.Move("-", WDTTERVIG.TRACO02_TERV);

            /*" -742- MOVE DD-DATA-FILE TO DD-DATA-TERV. */
            _.Move(WDATA_FILE.DD_DATA_FILE, WDTTERVIG.DD_DATA_TERV);

            /*" -744- MOVE WDTINIVIG TO WS-DATA-BASE. */
            _.Move(WDTINIVIG, AREA_DE_WORK.WS_DATA_BASE);

            /*" -746- MOVE WDTINIVIG TO SEGURVGA-DATA-INIVIGENCIA. */
            _.Move(WDTINIVIG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);

            /*" -748- MOVE WDTTERVIG TO MOVIMVGA-DATA-AVERBACAO. */
            _.Move(WDTTERVIG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -749- IF ENDOSSOS-DATA-TERVIGENCIA LESS WDTINIVIG */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA < WDTINIVIG)
            {

                /*" -751- DISPLAY 'VIGENCIA DA APOLICE EXPIRADA - PRORROGAR   ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"VIGENCIA DA APOLICE EXPIRADA - PRORROGAR   {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -752- DISPLAY 'DTTERVIG APOL.  ' ENDOSSOS-DATA-TERVIGENCIA */
                _.Display($"DTTERVIG APOL.  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}");

                /*" -753- DISPLAY 'DTINIVIG FUNCEF ' WDTINIVIG */
                _.Display($"DTINIVIG FUNCEF {WDTINIVIG}");

                /*" -755- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -757- MOVE '0072' TO WNR-EXEC-SQL. */
            _.Move("0072", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -763- PERFORM R0060_10_CONTINUA_DB_SELECT_1 */

            R0060_10_CONTINUA_DB_SELECT_1();

            /*" -766- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -767- MOVE '0073' TO WNR-EXEC-SQL */
                _.Move("0073", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -773- PERFORM R0060_10_CONTINUA_DB_SELECT_2 */

                R0060_10_CONTINUA_DB_SELECT_2();

                /*" -775- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -777- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -778- MOVE SEGURVGA-DATA-INIVIGENCIA TO W02DTSQL. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, AREA_DE_WORK.W02DTSQL);

            /*" -780- MOVE FATURCON-DATA-REFERENCIA TO W03DTSQL. */
            _.Move(FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA, AREA_DE_WORK.W03DTSQL);

            /*" -781- IF W02AAMMSQL > W03AAMMSQL */

            if (AREA_DE_WORK.W02DTSQL.W02AAMMSQL > AREA_DE_WORK.W03DTSQL.W03AAMMSQL)
            {

                /*" -782- MOVE 01 TO W02DDSQL */
                _.Move(01, AREA_DE_WORK.W02DTSQL.W02DDSQL);

                /*" -784- MOVE W02DTSQL TO FATURCON-DATA-REFERENCIA. */
                _.Move(AREA_DE_WORK.W02DTSQL, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


            /*" -786- MOVE MATRICULA-REG TO MOVIMVGA-NUM-MATRICULA. */
            _.Move(RECORD_ENTRADA.MATRICULA_REG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -788- MOVE '0078' TO WNR-EXEC-SQL. */
            _.Move("0078", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -793- PERFORM R0060_10_CONTINUA_DB_SELECT_3 */

            R0060_10_CONTINUA_DB_SELECT_3();

            /*" -796- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -798- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -801- COMPUTE FONTES-ULT-PROP-AUTOMAT = FONTES-ULT-PROP-AUTOMAT + 1. */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -803- MOVE '0079' TO WNR-EXEC-SQL. */
            _.Move("0079", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -808- PERFORM R0060_10_CONTINUA_DB_UPDATE_1 */

            R0060_10_CONTINUA_DB_UPDATE_1();

            /*" -811- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -814- MOVE VAL-EMP-REG TO MOVIMVGA-IMP-MORNATU-ATU. */
            _.Move(RECORD_ENTRADA.VAL_EMP_REG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -815- MOVE ZEROS TO MOVIMVGA-IMP-MORACID-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -817- MOVE ZEROS TO MOVIMVGA-IMP-INVPERM-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -819- MOVE VAL-PRM-REG TO MOVIMVGA-PRM-VG-ATU. */
            _.Move(RECORD_ENTRADA.VAL_PRM_REG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -821- MOVE 999105 TO MOVIMVGA-COD-AGENCIADOR. */
            _.Move(999105, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -823- MOVE ZEROS TO MOVIMVGA-VAL-SALARIO. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -825- MOVE SPACES TO MOVIMVGA-TIPO-SALARIO. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -827- MOVE SPACES TO MOVIMVGA-TIPO-PLANO. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -829- MOVE ZEROS TO MOVIMVGA-TAXA-VG. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -831- MOVE ZEROS TO MOVIMVGA-QTD-SAL-MORNATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -833- MOVE SPACES TO MOVIMVGA-IDE-SEXO. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);

            /*" -835- MOVE SPACES TO MOVIMVGA-ESTADO-CIVIL. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);

            /*" -837- MOVE '0080' TO WNR-EXEC-SQL. */
            _.Move("0080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -989- PERFORM R0060_10_CONTINUA_DB_INSERT_1 */

            R0060_10_CONTINUA_DB_INSERT_1();

            /*" -992- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -992- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-SELECT-1 */
        public void R0060_10_CONTINUA_DB_SELECT_1()
        {
            /*" -763- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r0060_10_CONTINUA_DB_SELECT_1_Query1 = new R0060_10_CONTINUA_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0060_10_CONTINUA_DB_SELECT_1_Query1.Execute(r0060_10_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" R0060-09-CRIA-CLIENTE-DB-SELECT-2 */
        public void R0060_09_CRIA_CLIENTE_DB_SELECT_2()
        {
            /*" -673- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SUBGVGAP-COD-CLIENTE AND OCORR_ENDERECO = :SUBGVGAP-OCORR-ENDERECO END-EXEC. */

            var r0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1 = new R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1()
            {
                SUBGVGAP_OCORR_ENDERECO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1.Execute(r0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-SELECT-2 */
        public void R0060_10_CONTINUA_DB_SELECT_2()
        {
            /*" -773- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = 0 END-EXEC */

            var r0060_10_CONTINUA_DB_SELECT_2_Query1 = new R0060_10_CONTINUA_DB_SELECT_2_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0060_10_CONTINUA_DB_SELECT_2_Query1.Execute(r0060_10_CONTINUA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-UPDATE-1 */
        public void R0060_10_CONTINUA_DB_UPDATE_1()
        {
            /*" -808- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r0060_10_CONTINUA_DB_UPDATE_1_Update1 = new R0060_10_CONTINUA_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            R0060_10_CONTINUA_DB_UPDATE_1_Update1.Execute(r0060_10_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-INSERT-1 */
        public void R0060_10_CONTINUA_DB_INSERT_1()
        {
            /*" -989- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES (:SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :FONTES-ULT-PROP-AUTOMAT, '1' , 0, ' ' , '1' , :SEGURVGA-COD-CLIENTE, :MOVIMVGA-COD-AGENCIADOR, 0, 0, 0, 1, 'S' , 'N' , 1, 12, ' ' , :MOVIMVGA-ESTADO-CIVIL, :MOVIMVGA-IDE-SEXO, 9521, ' ' , 1, 1, 104, 0, ' ' , :MOVIMVGA-NUM-MATRICULA, 0, ' ' , :MOVIMVGA-VAL-SALARIO, :MOVIMVGA-TIPO-SALARIO, :MOVIMVGA-TIPO-PLANO, 0, 0, :MOVIMVGA-QTD-SAL-MORNATU, 0, 0, 0, 0, 0, 0, 0, :MOVIMVGA-TAXA-VG, 0, :MOVIMVGA-IMP-MORNATU-ATU, 0, :MOVIMVGA-IMP-MORACID-ATU, 0, :MOVIMVGA-IMP-INVPERM-ATU, 0, 0, 0, 0, 0, 0, 0, :MOVIMVGA-PRM-VG-ATU, 0, 0, 102, :SISTEMAS-DATA-MOV-ABERTO, 0, '1' , 'VG9521B' , :MOVIMVGA-DATA-AVERBACAO, NULL, NULL, :CLIENTES-DATA-NASCIMENTO, NULL, :FATURCON-DATA-REFERENCIA, :SEGURVGA-DATA-INIVIGENCIA, NULL, NULL) END-EXEC. */

            var r0060_10_CONTINUA_DB_INSERT_1_Insert1 = new R0060_10_CONTINUA_DB_INSERT_1_Insert1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                MOVIMVGA_COD_AGENCIADOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_ESTADO_CIVIL = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL.ToString(),
                MOVIMVGA_IDE_SEXO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO.ToString(),
                MOVIMVGA_NUM_MATRICULA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA.ToString(),
                MOVIMVGA_VAL_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO.ToString(),
                MOVIMVGA_TIPO_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO.ToString(),
                MOVIMVGA_TIPO_PLANO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO.ToString(),
                MOVIMVGA_QTD_SAL_MORNATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU.ToString(),
                MOVIMVGA_TAXA_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG.ToString(),
                MOVIMVGA_IMP_MORNATU_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.ToString(),
                MOVIMVGA_IMP_MORACID_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.ToString(),
                MOVIMVGA_IMP_INVPERM_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.ToString(),
                MOVIMVGA_PRM_VG_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVIMVGA_DATA_AVERBACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.ToString(),
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                FATURCON_DATA_REFERENCIA = FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.ToString(),
                SEGURVGA_DATA_INIVIGENCIA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA.ToString(),
            };

            R0060_10_CONTINUA_DB_INSERT_1_Insert1.Execute(r0060_10_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0060-09-CRIA-CLIENTE-DB-INSERT-2 */
        public void R0060_09_CRIA_CLIENTE_DB_INSERT_2()
        {
            /*" -713- EXEC SQL INSERT INTO SEGUROS.ENDERECOS ( COD_CLIENTE, COD_ENDERECO, OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE, FAX, TELEX, SIT_REGISTRO, COD_EMPRESA) VALUES (:SEGURVGA-COD-CLIENTE, 1, 1, :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, 0, 0, 0, 0, '0' , NULL) END-EXEC. */

            var r0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1 = new R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
                ENDERECO_CEP = ENDERECO.DCLENDERECOS.ENDERECO_CEP.ToString(),
            };

            R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1.Execute(r0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-SELECT-3 */
        public void R0060_10_CONTINUA_DB_SELECT_3()
        {
            /*" -793- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r0060_10_CONTINUA_DB_SELECT_3_Query1 = new R0060_10_CONTINUA_DB_SELECT_3_Query1()
            {
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            var executed_1 = R0060_10_CONTINUA_DB_SELECT_3_Query1.Execute(r0060_10_CONTINUA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-SECTION */
        private void R6666_00_AUMENTA_REDUZ_VG_SECTION()
        {
            /*" -1003- MOVE MATRICULA-REG TO FUNCICEF-NUM-MATRICULA. */
            _.Move(RECORD_ENTRADA.MATRICULA_REG, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA);

            /*" -1005- MOVE '6969' TO WNR-EXEC-SQL. */
            _.Move("6969", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1013- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1();

            /*" -1016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1017- DISPLAY 'ERRO ACESSO FUNCIOCEF ' SQLCODE */
                _.Display($"ERRO ACESSO FUNCIOCEF {DB.SQLCODE}");

                /*" -1019- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1021- MOVE FUNCICEF-NASCIMENTO TO WDTNAS-FUNCICEF. */
            _.Move(FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NASCIMENTO, WDTNAS_FUNCICEF);

            /*" -1022- MOVE DD-DTNAS-FCEF TO DD-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.DD_DTNAS_FCEF, WDATASQL.DD_DATA_SQL);

            /*" -1023- MOVE MM-DTNAS-FCEF TO MM-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.MM_DTNAS_FCEF, WDATASQL.MM_DATA_SQL);

            /*" -1024- MOVE SS-DTNAS-FCEF TO SS-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.SS_DTNAS_FCEF, WDATASQL.SS_DATA_SQL);

            /*" -1025- MOVE AA-DTNAS-FCEF TO AA-DATA-SQL. */
            _.Move(WDTNAS_FUNCICEF_R.AA_DTNAS_FCEF, WDATASQL.AA_DATA_SQL);

            /*" -1026- MOVE '-' TO TRACO-SQL1. */
            _.Move("-", WDATASQL.TRACO_SQL1);

            /*" -1028- MOVE '-' TO TRACO-SQL2. */
            _.Move("-", WDATASQL.TRACO_SQL2);

            /*" -1030- MOVE '6666' TO WNR-EXEC-SQL. */
            _.Move("6666", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1031- MOVE WDATASQL TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(WDATASQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -1032- MOVE 093605000853 TO SEGURVGA-NUM-APOLICE. */
            _.Move(093605000853, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -1036- MOVE 0001 TO SEGURVGA-COD-SUBGRUPO. */
            _.Move(0001, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -1037- MOVE DTINIVIG-REG TO WDATA-FILE. */
            _.Move(RECORD_ENTRADA.DTINIVIG_REG, WDATA_FILE);

            /*" -1038- MOVE 20 TO SS-DATA-INIV. */
            _.Move(20, WDTINIVIG.SS_DATA_INIV);

            /*" -1039- MOVE AA-DATA-FILE TO AA-DATA-INIV. */
            _.Move(WDATA_FILE.AA_DATA_FILE, WDTINIVIG.AA_DATA_INIV);

            /*" -1040- MOVE '-' TO TRACO01-INIV. */
            _.Move("-", WDTINIVIG.TRACO01_INIV);

            /*" -1041- MOVE MM-DATA-FILE TO MM-DATA-INIV. */
            _.Move(WDATA_FILE.MM_DATA_FILE, WDTINIVIG.MM_DATA_INIV);

            /*" -1042- MOVE '-' TO TRACO02-INIV. */
            _.Move("-", WDTINIVIG.TRACO02_INIV);

            /*" -1044- MOVE DD-DATA-FILE TO DD-DATA-INIV. */
            _.Move(WDATA_FILE.DD_DATA_FILE, WDTINIVIG.DD_DATA_INIV);

            /*" -1045- MOVE DTTERVIG-REG TO WDATA-FILE. */
            _.Move(RECORD_ENTRADA.DTTERVIG_REG, WDATA_FILE);

            /*" -1046- MOVE 20 TO SS-DATA-TERV. */
            _.Move(20, WDTTERVIG.SS_DATA_TERV);

            /*" -1047- MOVE AA-DATA-FILE TO AA-DATA-TERV. */
            _.Move(WDATA_FILE.AA_DATA_FILE, WDTTERVIG.AA_DATA_TERV);

            /*" -1048- MOVE '-' TO TRACO01-TERV. */
            _.Move("-", WDTTERVIG.TRACO01_TERV);

            /*" -1049- MOVE MM-DATA-FILE TO MM-DATA-TERV. */
            _.Move(WDATA_FILE.MM_DATA_FILE, WDTTERVIG.MM_DATA_TERV);

            /*" -1050- MOVE '-' TO TRACO02-TERV. */
            _.Move("-", WDTTERVIG.TRACO02_TERV);

            /*" -1052- MOVE DD-DATA-FILE TO DD-DATA-TERV. */
            _.Move(WDATA_FILE.DD_DATA_FILE, WDTTERVIG.DD_DATA_TERV);

            /*" -1054- MOVE WDTINIVIG TO SEGURVGA-DATA-INIVIGENCIA. */
            _.Move(WDTINIVIG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);

            /*" -1056- MOVE WDTTERVIG TO MOVIMVGA-DATA-AVERBACAO. */
            _.Move(WDTTERVIG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -1057- IF ENDOSSOS-DATA-TERVIGENCIA LESS WDTINIVIG */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA < WDTINIVIG)
            {

                /*" -1059- DISPLAY 'VIGENCIA DA APOLICE EXPIRADA - PRORROGAR   ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"VIGENCIA DA APOLICE EXPIRADA - PRORROGAR   {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -1060- DISPLAY 'DTTERVIG APOL.  ' ENDOSSOS-DATA-TERVIGENCIA */
                _.Display($"DTTERVIG APOL.  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}");

                /*" -1061- DISPLAY 'DTINIVIG FUNCEF ' WDTINIVIG */
                _.Display($"DTINIVIG FUNCEF {WDTINIVIG}");

                /*" -1063- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1076- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2();

            /*" -1079- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1080- DISPLAY 'ERRO ACESSO SUBGRUPO ' SQLCODE */
                _.Display($"ERRO ACESSO SUBGRUPO {DB.SQLCODE}");

                /*" -1082- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1084- MOVE SUBGVGAP-COD-FONTE TO SEGURVGA-COD-FONTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);

            /*" -1086- MOVE '6667' TO WNR-EXEC-SQL. */
            _.Move("6667", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1101- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3();

            /*" -1104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1106- DISPLAY ' - PROBLEMAS SELECT V1COBERAPOL..' SEGURVGA-NUM-CERTIFICADO ' ' SQLCODE */

                $" - PROBLEMAS SELECT V1COBERAPOL..{SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} {DB.SQLCODE}"
                .Display();

                /*" -1109- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1110- MOVE APOLICOB-IMP-SEGURADA-IX TO MOVIMVGA-IMP-MORNATU-ANT. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -1112- MOVE APOLICOB-PRM-TARIFARIO-IX TO MOVIMVGA-PRM-VG-ANT. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -1113- IF APOLICOB-DATA-INIVIGENCIA NOT LESS WDTINIVIG */

            if (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA >= WDTINIVIG)
            {

                /*" -1115- DISPLAY 'EXISTE MOVIM. < OU = AO INICIO DE VIGENCIA ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"EXISTE MOVIM. < OU = AO INICIO DE VIGENCIA {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -1116- DISPLAY 'DTINIVIG SASSE  ' APOLICOB-DATA-INIVIGENCIA */
                _.Display($"DTINIVIG SASSE  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA}");

                /*" -1117- DISPLAY 'DTINIVIG FUNCEF ' WDTINIVIG */
                _.Display($"DTINIVIG FUNCEF {WDTINIVIG}");

                /*" -1119- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1121- MOVE '6668' TO WNR-EXEC-SQL. */
            _.Move("6668", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1132- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4();

            /*" -1135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1136- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1137- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

                    /*" -1138- ELSE */
                }
                else
                {


                    /*" -1140- DISPLAY ' - PROBLEMAS SELECT V1COBERAPOL..- AP ' SEGURVGA-NUM-CERTIFICADO ' ' SQLCODE */

                    $" - PROBLEMAS SELECT V1COBERAPOL..- AP {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} {DB.SQLCODE}"
                    .Display();

                    /*" -1142- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1143- MOVE APOLICOB-IMP-SEGURADA-IX TO MOVIMVGA-IMP-MORACID-ANT. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);

            /*" -1145- MOVE ZEROS TO MOVIMVGA-PRM-AP-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -1147- MOVE '6669' TO WNR-EXEC-SQL. */
            _.Move("6669", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1158- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5();

            /*" -1161- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1162- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1163- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

                    /*" -1164- ELSE */
                }
                else
                {


                    /*" -1166- DISPLAY ' - PROBLEMAS SELECT V1COBERAPOL..- IP ' SEGURVGA-NUM-CERTIFICADO ' ' SQLCODE */

                    $" - PROBLEMAS SELECT V1COBERAPOL..- IP {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} {DB.SQLCODE}"
                    .Display();

                    /*" -1168- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1170- MOVE APOLICOB-IMP-SEGURADA-IX TO MOVIMVGA-IMP-INVPERM-ANT. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

            /*" -1172- MOVE '6672' TO WNR-EXEC-SQL. */
            _.Move("6672", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1178- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6();

            /*" -1181- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1182- MOVE '6673' TO WNR-EXEC-SQL */
                _.Move("6673", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1188- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7 */

                R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7();

                /*" -1190- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1192- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1193- MOVE SEGURVGA-DATA-INIVIGENCIA TO W02DTSQL. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, AREA_DE_WORK.W02DTSQL);

            /*" -1195- MOVE FATURCON-DATA-REFERENCIA TO W03DTSQL. */
            _.Move(FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA, AREA_DE_WORK.W03DTSQL);

            /*" -1196- IF W02AAMMSQL > W03AAMMSQL */

            if (AREA_DE_WORK.W02DTSQL.W02AAMMSQL > AREA_DE_WORK.W03DTSQL.W03AAMMSQL)
            {

                /*" -1197- MOVE 01 TO W02DDSQL */
                _.Move(01, AREA_DE_WORK.W02DTSQL.W02DDSQL);

                /*" -1199- MOVE W02DTSQL TO FATURCON-DATA-REFERENCIA. */
                _.Move(AREA_DE_WORK.W02DTSQL, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


            /*" -1201- MOVE MATRICULA-REG TO MOVIMVGA-NUM-MATRICULA. */
            _.Move(RECORD_ENTRADA.MATRICULA_REG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -1202- MOVE VAL-EMP-REG TO MOVIMVGA-IMP-MORNATU-ATU. */
            _.Move(RECORD_ENTRADA.VAL_EMP_REG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -1203- MOVE ZEROS TO MOVIMVGA-IMP-MORACID-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -1205- MOVE ZEROS TO MOVIMVGA-IMP-INVPERM-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -1207- MOVE VAL-PRM-REG TO MOVIMVGA-PRM-VG-ATU. */
            _.Move(RECORD_ENTRADA.VAL_PRM_REG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -1209- MOVE 850 TO MOVIMVGA-COD-OPERACAO. */
            _.Move(850, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -1211- MOVE '6678' TO WNR-EXEC-SQL. */
            _.Move("6678", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1216- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8 */

            R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8();

            /*" -1219- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1221- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1224- COMPUTE FONTES-ULT-PROP-AUTOMAT = FONTES-ULT-PROP-AUTOMAT + 1. */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -1226- MOVE '6679' TO WNR-EXEC-SQL. */
            _.Move("6679", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1231- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1 */

            R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1();

            /*" -1234- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1236- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1238- MOVE 999105 TO MOVIMVGA-COD-AGENCIADOR. */
            _.Move(999105, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -1240- MOVE ZEROS TO MOVIMVGA-VAL-SALARIO. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -1242- MOVE SPACES TO MOVIMVGA-TIPO-SALARIO. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -1244- MOVE SPACES TO MOVIMVGA-TIPO-PLANO. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -1246- MOVE ZEROS TO MOVIMVGA-TAXA-VG. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -1248- MOVE ZEROS TO MOVIMVGA-QTD-SAL-MORNATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -1250- MOVE '6680' TO WNR-EXEC-SQL. */
            _.Move("6680", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1402- PERFORM R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1 */

            R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1();

            /*" -1405- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1407- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1407- ADD 1 TO WACC-ALTERADOS. */
            AREA_DE_WORK.WACC_ALTERADOS.Value = AREA_DE_WORK.WACC_ALTERADOS + 1;

        }

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-1 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1()
        {
            /*" -1013- EXEC SQL SELECT NASCIMENTO INTO :FUNCICEF-NASCIMENTO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1_Query1()
            {
                FUNCICEF_NUM_MATRICULA = FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NASCIMENTO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6666_99_SAIDA*/

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-2 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2()
        {
            /*" -1076- EXEC SQL SELECT COD_CLIENTE, COD_FONTE, OCORR_ENDERECO INTO :SUBGVGAP-COD-CLIENTE, :SUBGVGAP-COD-FONTE, :SUBGVGAP-OCORR-ENDERECO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R7300-00-TRATA-MOVTO-CLIENTE-SECTION */
        private void R7300_00_TRATA_MOVTO_CLIENTE_SECTION()
        {
            /*" -1420- MOVE '7300' TO WNR-EXEC-SQL */
            _.Move("7300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1421- MOVE CLIENTES-COD-CLIENTE TO WWORK-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, AREA_DE_WORK.WWORK_COD_CLIENTE);

            /*" -1422- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
            _.Move("I", AREA_DE_WORK.WWORK_TIPO_MOVIMENTO);

            /*" -1423- MOVE SISTEMAS-DATA-MOV-ABERTO TO WWORK-DATA-ULT-MANUTEN */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WWORK_DATA_ULT_MANUTEN);

            /*" -1424- MOVE CLIENTES-NOME-RAZAO TO WWORK-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.WWORK_NOME_RAZAO);

            /*" -1425- MOVE 'F' TO WWORK-TIPO-PESSOA */
            _.Move("F", AREA_DE_WORK.WWORK_TIPO_PESSOA);

            /*" -1426- MOVE SPACES TO WWORK-IDE-SEXO */
            _.Move("", AREA_DE_WORK.WWORK_IDE_SEXO);

            /*" -1427- MOVE SPACES TO WWORK-ESTADO-CIVIL */
            _.Move("", AREA_DE_WORK.WWORK_ESTADO_CIVIL);

            /*" -1428- MOVE 1 TO WWORK-OCORR-ENDERECO */
            _.Move(1, AREA_DE_WORK.WWORK_OCORR_ENDERECO);

            /*" -1429- MOVE 1 TO WWORK-ENDERECO */
            _.Move(1, AREA_DE_WORK.WWORK_ENDERECO);

            /*" -1430- MOVE ENDERECO-BAIRRO TO WWORK-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, AREA_DE_WORK.WWORK_BAIRRO);

            /*" -1431- MOVE ENDERECO-CIDADE TO WWORK-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, AREA_DE_WORK.WWORK_CIDADE);

            /*" -1432- MOVE ENDERECO-SIGLA-UF TO WWORK-SIGLA-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, AREA_DE_WORK.WWORK_SIGLA_UF);

            /*" -1433- MOVE ENDERECO-CEP TO WWORK-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, AREA_DE_WORK.WWORK_CEP);

            /*" -1434- MOVE ZEROS TO WWORK-DDD */
            _.Move(0, AREA_DE_WORK.WWORK_DDD);

            /*" -1435- MOVE ZEROS TO WWORK-TELEFONE */
            _.Move(0, AREA_DE_WORK.WWORK_TELEFONE);

            /*" -1436- MOVE ZEROS TO WWORK-FAX */
            _.Move(0, AREA_DE_WORK.WWORK_FAX);

            /*" -1437- MOVE CLIENTES-CGCCPF TO WWORK-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.WWORK_CGCCPF);

            /*" -1439- MOVE CLIENTES-DATA-NASCIMENTO TO WWORK-DATA-NASCIMENTO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, AREA_DE_WORK.WWORK_DATA_NASCIMENTO);

            /*" -1440- MOVE WWORK-COD-CLIENTE TO GECLIMOV-COD-CLIENTE */
            _.Move(AREA_DE_WORK.WWORK_COD_CLIENTE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE);

            /*" -1441- MOVE WWORK-OCORR-ENDERECO TO GECLIMOV-OCORR-ENDERECO */
            _.Move(AREA_DE_WORK.WWORK_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);

            /*" -1443- MOVE WWORK-TIPO-MOVIMENTO TO GECLIMOV-TIPO-MOVIMENTO */
            _.Move(AREA_DE_WORK.WWORK_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);

            /*" -1448- MOVE WWORK-DATA-ULT-MANUTEN TO GECLIMOV-DATA-ULT-MANUTEN */
            _.Move(AREA_DE_WORK.WWORK_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);

            /*" -1449- PERFORM R7310-00-MAX-GECLIMOV */

            R7310_00_MAX_GECLIMOV_SECTION();

            /*" -1451- ADD 1 TO GECLIMOV-OCORR-HIST */
            GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST + 1;

            /*" -1452- IF GECLIMOV-OCORR-ENDERECO EQUAL ZEROS */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO == 00)
            {

                /*" -1453- MOVE 0 TO WHOST-OCORR-END-I */
                _.Move(0, WHOST_OCORR_END_I);

                /*" -1454- MOVE 9999 TO WHOST-OCORR-END-F */
                _.Move(9999, WHOST_OCORR_END_F);

                /*" -1455- ELSE */
            }
            else
            {


                /*" -1458- MOVE GECLIMOV-OCORR-ENDERECO TO WHOST-OCORR-END-I WHOST-OCORR-END-F. */
                _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO, WHOST_OCORR_END_I, WHOST_OCORR_END_F);
            }


            /*" -1460- PERFORM R7320-00-SELECT-GECLIMOV */

            R7320_00_SELECT_GECLIMOV_SECTION();

            /*" -1461- IF WWORK-NOME-RAZAO EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_NOME_RAZAO.IsEmpty())
            {

                /*" -1462- MOVE -1 TO VIND-NOME-RAZAO */
                _.Move(-1, VIND_NOME_RAZAO);

                /*" -1463- ELSE */
            }
            else
            {


                /*" -1464- MOVE +0 TO VIND-NOME-RAZAO */
                _.Move(+0, VIND_NOME_RAZAO);

                /*" -1466- MOVE WWORK-NOME-RAZAO TO GECLIMOV-NOME-RAZAO. */
                _.Move(AREA_DE_WORK.WWORK_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
            }


            /*" -1467- IF WWORK-TIPO-PESSOA EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_TIPO_PESSOA.IsEmpty())
            {

                /*" -1468- MOVE -1 TO VIND-TIPO-PESSOA */
                _.Move(-1, VIND_TIPO_PESSOA);

                /*" -1469- ELSE */
            }
            else
            {


                /*" -1470- MOVE +0 TO VIND-TIPO-PESSOA */
                _.Move(+0, VIND_TIPO_PESSOA);

                /*" -1472- MOVE WWORK-TIPO-PESSOA TO GECLIMOV-TIPO-PESSOA. */
                _.Move(AREA_DE_WORK.WWORK_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
            }


            /*" -1473- IF WWORK-IDE-SEXO EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_IDE_SEXO.IsEmpty())
            {

                /*" -1474- MOVE -1 TO VIND-IDE-SEXO */
                _.Move(-1, VIND_IDE_SEXO);

                /*" -1475- ELSE */
            }
            else
            {


                /*" -1476- MOVE +0 TO VIND-IDE-SEXO */
                _.Move(+0, VIND_IDE_SEXO);

                /*" -1478- MOVE WWORK-IDE-SEXO TO GECLIMOV-IDE-SEXO. */
                _.Move(AREA_DE_WORK.WWORK_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
            }


            /*" -1479- IF WWORK-ESTADO-CIVIL EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_ESTADO_CIVIL.IsEmpty())
            {

                /*" -1480- MOVE -1 TO VIND-EST-CIVIL */
                _.Move(-1, VIND_EST_CIVIL);

                /*" -1481- ELSE */
            }
            else
            {


                /*" -1482- MOVE +0 TO VIND-EST-CIVIL */
                _.Move(+0, VIND_EST_CIVIL);

                /*" -1484- MOVE WWORK-ESTADO-CIVIL TO GECLIMOV-ESTADO-CIVIL. */
                _.Move(AREA_DE_WORK.WWORK_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
            }


            /*" -1485- IF WWORK-OCORR-ENDERECO EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_OCORR_ENDERECO == 00)
            {

                /*" -1486- MOVE -1 TO VIND-OCORR-END */
                _.Move(-1, VIND_OCORR_END);

                /*" -1487- ELSE */
            }
            else
            {


                /*" -1489- MOVE +0 TO VIND-OCORR-END. */
                _.Move(+0, VIND_OCORR_END);
            }


            /*" -1490- IF WWORK-ENDERECO EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_ENDERECO.IsEmpty())
            {

                /*" -1491- MOVE -1 TO VIND-ENDERECO */
                _.Move(-1, VIND_ENDERECO);

                /*" -1492- ELSE */
            }
            else
            {


                /*" -1493- MOVE +0 TO VIND-ENDERECO */
                _.Move(+0, VIND_ENDERECO);

                /*" -1495- MOVE WWORK-ENDERECO TO GECLIMOV-ENDERECO. */
                _.Move(AREA_DE_WORK.WWORK_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
            }


            /*" -1496- IF WWORK-BAIRRO EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_BAIRRO.IsEmpty())
            {

                /*" -1497- MOVE -1 TO VIND-BAIRRO */
                _.Move(-1, VIND_BAIRRO);

                /*" -1498- ELSE */
            }
            else
            {


                /*" -1499- MOVE +0 TO VIND-BAIRRO */
                _.Move(+0, VIND_BAIRRO);

                /*" -1501- MOVE WWORK-BAIRRO TO GECLIMOV-BAIRRO. */
                _.Move(AREA_DE_WORK.WWORK_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
            }


            /*" -1502- IF WWORK-CIDADE EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_CIDADE.IsEmpty())
            {

                /*" -1503- MOVE -1 TO VIND-CIDADE */
                _.Move(-1, VIND_CIDADE);

                /*" -1504- ELSE */
            }
            else
            {


                /*" -1505- MOVE +0 TO VIND-CIDADE */
                _.Move(+0, VIND_CIDADE);

                /*" -1507- MOVE WWORK-CIDADE TO GECLIMOV-CIDADE. */
                _.Move(AREA_DE_WORK.WWORK_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
            }


            /*" -1508- IF WWORK-SIGLA-UF EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_SIGLA_UF.IsEmpty())
            {

                /*" -1509- MOVE -1 TO VIND-SIGLA-UF */
                _.Move(-1, VIND_SIGLA_UF);

                /*" -1510- ELSE */
            }
            else
            {


                /*" -1511- MOVE +0 TO VIND-SIGLA-UF */
                _.Move(+0, VIND_SIGLA_UF);

                /*" -1513- MOVE WWORK-SIGLA-UF TO GECLIMOV-SIGLA-UF. */
                _.Move(AREA_DE_WORK.WWORK_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
            }


            /*" -1514- IF WWORK-CEP EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_CEP == 00)
            {

                /*" -1515- MOVE -1 TO VIND-CEP */
                _.Move(-1, VIND_CEP);

                /*" -1516- ELSE */
            }
            else
            {


                /*" -1517- MOVE +0 TO VIND-CEP */
                _.Move(+0, VIND_CEP);

                /*" -1519- MOVE WWORK-CEP TO GECLIMOV-CEP. */
                _.Move(AREA_DE_WORK.WWORK_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
            }


            /*" -1520- IF WWORK-DDD EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_DDD == 00)
            {

                /*" -1521- MOVE -1 TO VIND-DDD */
                _.Move(-1, VIND_DDD);

                /*" -1522- ELSE */
            }
            else
            {


                /*" -1523- MOVE +0 TO VIND-DDD */
                _.Move(+0, VIND_DDD);

                /*" -1525- MOVE WWORK-DDD TO GECLIMOV-DDD. */
                _.Move(AREA_DE_WORK.WWORK_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
            }


            /*" -1526- IF WWORK-TELEFONE EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_TELEFONE == 00)
            {

                /*" -1527- MOVE -1 TO VIND-TELEFONE */
                _.Move(-1, VIND_TELEFONE);

                /*" -1528- ELSE */
            }
            else
            {


                /*" -1529- MOVE +0 TO VIND-TELEFONE */
                _.Move(+0, VIND_TELEFONE);

                /*" -1531- MOVE WWORK-TELEFONE TO GECLIMOV-TELEFONE. */
                _.Move(AREA_DE_WORK.WWORK_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
            }


            /*" -1532- IF WWORK-FAX EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_FAX == 00)
            {

                /*" -1533- MOVE -1 TO VIND-FAX */
                _.Move(-1, VIND_FAX);

                /*" -1534- ELSE */
            }
            else
            {


                /*" -1535- MOVE +0 TO VIND-FAX */
                _.Move(+0, VIND_FAX);

                /*" -1537- MOVE WWORK-FAX TO GECLIMOV-FAX. */
                _.Move(AREA_DE_WORK.WWORK_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
            }


            /*" -1538- IF WWORK-CGCCPF EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_CGCCPF == 00)
            {

                /*" -1539- MOVE -1 TO VIND-CGCCPF */
                _.Move(-1, VIND_CGCCPF);

                /*" -1540- ELSE */
            }
            else
            {


                /*" -1541- MOVE +0 TO VIND-CGCCPF */
                _.Move(+0, VIND_CGCCPF);

                /*" -1543- MOVE WWORK-CGCCPF TO GECLIMOV-CGCCPF. */
                _.Move(AREA_DE_WORK.WWORK_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
            }


            /*" -1544- IF WWORK-DATA-NASCIMENTO EQUAL SPACES */

            if (AREA_DE_WORK.WWORK_DATA_NASCIMENTO.IsEmpty())
            {

                /*" -1545- MOVE -1 TO VIND-DTNASC */
                _.Move(-1, VIND_DTNASC);

                /*" -1546- ELSE */
            }
            else
            {


                /*" -1547- MOVE +0 TO VIND-DTNASC */
                _.Move(+0, VIND_DTNASC);

                /*" -1549- MOVE WWORK-DATA-NASCIMENTO TO GECLIMOV-DATA-NASCIMENTO. */
                _.Move(AREA_DE_WORK.WWORK_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
            }


            /*" -1551- MOVE 'VG9521B' TO GECLIMOV-COD-USUARIO */
            _.Move("VG9521B", GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO);

            /*" -1552- IF WTEM-GECLIMOV EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_GECLIMOV == "N")
            {

                /*" -1568- IF VIND-NOME-RAZAO LESS ZEROS AND VIND-TIPO-PESSOA LESS ZEROS AND VIND-IDE-SEXO LESS ZEROS AND VIND-EST-CIVIL LESS ZEROS AND VIND-OCORR-END LESS ZEROS AND VIND-ENDERECO LESS ZEROS AND VIND-BAIRRO LESS ZEROS AND VIND-CIDADE LESS ZEROS AND VIND-SIGLA-UF LESS ZEROS AND VIND-CEP LESS ZEROS AND VIND-DDD LESS ZEROS AND VIND-TELEFONE LESS ZEROS AND VIND-FAX LESS ZEROS AND VIND-CGCCPF LESS ZEROS AND VIND-DTNASC LESS ZEROS NEXT SENTENCE */

                if (VIND_NOME_RAZAO < 00 && VIND_TIPO_PESSOA < 00 && VIND_IDE_SEXO < 00 && VIND_EST_CIVIL < 00 && VIND_OCORR_END < 00 && VIND_ENDERECO < 00 && VIND_BAIRRO < 00 && VIND_CIDADE < 00 && VIND_SIGLA_UF < 00 && VIND_CEP < 00 && VIND_DDD < 00 && VIND_TELEFONE < 00 && VIND_FAX < 00 && VIND_CGCCPF < 00 && VIND_DTNASC < 00)
                {

                    /*" -1569- ELSE */
                }
                else
                {


                    /*" -1570- PERFORM R7400-00-INSERT-GECLIMOV */

                    R7400_00_INSERT_GECLIMOV_SECTION();

                    /*" -1571- ELSE */
                }

            }
            else
            {


                /*" -1571- PERFORM R7450-00-UPDATE-GECLIMOV. */

                R7450_00_UPDATE_GECLIMOV_SECTION();
            }


        }

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-3 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3()
        {
            /*" -1101- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, DATA_INIVIGENCIA INTO :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-DATA-INIVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = 93 AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 11 END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7300_99_SAIDA*/

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-4 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4()
        {
            /*" -1132- EXEC SQL SELECT IMP_SEGURADA_IX INTO :APOLICOB-IMP-SEGURADA-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = 81 AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 01 END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
            }


        }

        [StopWatch]
        /*" R7310-00-MAX-GECLIMOV-SECTION */
        private void R7310_00_MAX_GECLIMOV_SECTION()
        {
            /*" -1584- MOVE '7310' TO WNR-EXEC-SQL */
            _.Move("7310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1589- PERFORM R7310_00_MAX_GECLIMOV_DB_SELECT_1 */

            R7310_00_MAX_GECLIMOV_DB_SELECT_1();

            /*" -1592- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1593- DISPLAY 'PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ' */
                _.Display($"PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ");

                /*" -1594- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -1594- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7310-00-MAX-GECLIMOV-DB-SELECT-1 */
        public void R7310_00_MAX_GECLIMOV_DB_SELECT_1()
        {
            /*" -1589- EXEC SQL SELECT VALUE(MAX(OCORR_HIST), 0) INTO :GECLIMOV-OCORR-HIST FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE END-EXEC. */

            var r7310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 = new R7310_00_MAX_GECLIMOV_DB_SELECT_1_Query1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
            };

            var executed_1 = R7310_00_MAX_GECLIMOV_DB_SELECT_1_Query1.Execute(r7310_00_MAX_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
            }


        }

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-UPDATE-1 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1()
        {
            /*" -1231- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1_Update1 = new R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1_Update1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-INSERT-1 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1()
        {
            /*" -1402- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES (:SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :FONTES-ULT-PROP-AUTOMAT, '1' , :SEGURVGA-NUM-CERTIFICADO, ' ' , '1' , :SEGURVGA-COD-CLIENTE, :MOVIMVGA-COD-AGENCIADOR, 0, 0, 0, 1, 'S' , 'N' , 1, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , :MOVIMVGA-NUM-MATRICULA, 0, ' ' , :MOVIMVGA-VAL-SALARIO, :MOVIMVGA-TIPO-SALARIO, :MOVIMVGA-TIPO-PLANO, 0, 0, :MOVIMVGA-QTD-SAL-MORNATU, 0, 0, 0, 0, 0, 0, 0, :MOVIMVGA-TAXA-VG, :MOVIMVGA-IMP-MORNATU-ANT, :MOVIMVGA-IMP-MORNATU-ATU, :MOVIMVGA-IMP-MORACID-ANT, :MOVIMVGA-IMP-MORACID-ATU, :MOVIMVGA-IMP-INVPERM-ANT, :MOVIMVGA-IMP-INVPERM-ATU, 0, 0, 0, 0, 0, 0, :MOVIMVGA-PRM-VG-ANT, :MOVIMVGA-PRM-VG-ATU, 0, 0, :MOVIMVGA-COD-OPERACAO, :SISTEMAS-DATA-MOV-ABERTO, 0, '1' , 'VG9521B' , :MOVIMVGA-DATA-AVERBACAO, NULL, NULL, :CLIENTES-DATA-NASCIMENTO, NULL, :FATURCON-DATA-REFERENCIA, :SEGURVGA-DATA-INIVIGENCIA, NULL, NULL) END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1 = new R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                MOVIMVGA_COD_AGENCIADOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_NUM_MATRICULA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA.ToString(),
                MOVIMVGA_VAL_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO.ToString(),
                MOVIMVGA_TIPO_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO.ToString(),
                MOVIMVGA_TIPO_PLANO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO.ToString(),
                MOVIMVGA_QTD_SAL_MORNATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU.ToString(),
                MOVIMVGA_TAXA_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG.ToString(),
                MOVIMVGA_IMP_MORNATU_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT.ToString(),
                MOVIMVGA_IMP_MORNATU_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.ToString(),
                MOVIMVGA_IMP_MORACID_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT.ToString(),
                MOVIMVGA_IMP_MORACID_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.ToString(),
                MOVIMVGA_IMP_INVPERM_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT.ToString(),
                MOVIMVGA_IMP_INVPERM_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.ToString(),
                MOVIMVGA_PRM_VG_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT.ToString(),
                MOVIMVGA_PRM_VG_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.ToString(),
                MOVIMVGA_COD_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVIMVGA_DATA_AVERBACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.ToString(),
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                FATURCON_DATA_REFERENCIA = FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.ToString(),
                SEGURVGA_DATA_INIVIGENCIA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA.ToString(),
            };

            R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-5 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5()
        {
            /*" -1158- EXEC SQL SELECT IMP_SEGURADA_IX INTO :APOLICOB-IMP-SEGURADA-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = 81 AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 02 END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7310_99_SAIDA*/

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-6 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6()
        {
            /*" -1178- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" R7320-00-SELECT-GECLIMOV-SECTION */
        private void R7320_00_SELECT_GECLIMOV_SECTION()
        {
            /*" -1607- MOVE '7320' TO WNR-EXEC-SQL */
            _.Move("7320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1631- PERFORM R7320_00_SELECT_GECLIMOV_DB_DECLARE_1 */

            R7320_00_SELECT_GECLIMOV_DB_DECLARE_1();

            /*" -1633- PERFORM R7320_00_SELECT_GECLIMOV_DB_OPEN_1 */

            R7320_00_SELECT_GECLIMOV_DB_OPEN_1();

            /*" -1636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1637- DISPLAY 'PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ");

                /*" -1638- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -1639- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                /*" -1640- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                /*" -1642- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1661- PERFORM R7320_00_SELECT_GECLIMOV_DB_FETCH_1 */

            R7320_00_SELECT_GECLIMOV_DB_FETCH_1();

            /*" -1664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1665- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1665- PERFORM R7320_00_SELECT_GECLIMOV_DB_CLOSE_1 */

                    R7320_00_SELECT_GECLIMOV_DB_CLOSE_1();

                    /*" -1667- MOVE 'N' TO WTEM-GECLIMOV */
                    _.Move("N", AREA_DE_WORK.WTEM_GECLIMOV);

                    /*" -1668- ELSE */
                }
                else
                {


                    /*" -1669- DISPLAY 'PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ' */
                    _.Display($"PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ");

                    /*" -1670- DISPLAY 'CODCLIEN    ' GECLIMOV-COD-CLIENTE */
                    _.Display($"CODCLIEN    {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                    /*" -1671- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                    _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                    /*" -1672- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                    _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                    /*" -1673- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1674- ELSE */
                }

            }
            else
            {


                /*" -1675- MOVE 'S' TO WTEM-GECLIMOV */
                _.Move("S", AREA_DE_WORK.WTEM_GECLIMOV);

                /*" -1675- PERFORM R7320_00_SELECT_GECLIMOV_DB_CLOSE_2 */

                R7320_00_SELECT_GECLIMOV_DB_CLOSE_2();

                /*" -1676- END-IF. */
            }


        }

        [StopWatch]
        /*" R7320-00-SELECT-GECLIMOV-DB-DECLARE-1 */
        public void R7320_00_SELECT_GECLIMOV_DB_DECLARE_1()
        {
            /*" -1631- EXEC SQL DECLARE C01_GECLIMOV CURSOR FOR SELECT TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_ENDERECO BETWEEN :WHOST-OCORR-END-I AND :WHOST-OCORR-END-F ORDER BY OCORR_HIST DESC END-EXEC. */
            C01_GECLIMOV = new VG9521B_C01_GECLIMOV(true);
            string GetQuery_C01_GECLIMOV()
            {
                var query = @$"SELECT TIPO_MOVIMENTO
							, 
							DATA_ULT_MANUTEN
							, 
							NOME_RAZAO
							, 
							TIPO_PESSOA
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OCORR_ENDERECO
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
							DDD
							, 
							TELEFONE
							, 
							FAX
							, 
							OCORR_HIST
							, 
							CGCCPF
							, 
							DATA_NASCIMENTO 
							FROM SEGUROS.GE_CLIENTES_MOVTO 
							WHERE COD_CLIENTE = '{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}' 
							AND OCORR_ENDERECO BETWEEN '{WHOST_OCORR_END_I}' 
							AND '{WHOST_OCORR_END_F}' 
							ORDER BY OCORR_HIST DESC";

                return query;
            }
            C01_GECLIMOV.GetQueryEvent += GetQuery_C01_GECLIMOV;

        }

        [StopWatch]
        /*" R7320-00-SELECT-GECLIMOV-DB-OPEN-1 */
        public void R7320_00_SELECT_GECLIMOV_DB_OPEN_1()
        {
            /*" -1633- EXEC SQL OPEN C01_GECLIMOV END-EXEC. */

            C01_GECLIMOV.Open();

        }

        [StopWatch]
        /*" R7320-00-SELECT-GECLIMOV-DB-FETCH-1 */
        public void R7320_00_SELECT_GECLIMOV_DB_FETCH_1()
        {
            /*" -1661- EXEC SQL FETCH C01_GECLIMOV INTO :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC END-EXEC. */

            if (C01_GECLIMOV.Fetch())
            {
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);
                _.Move(C01_GECLIMOV.GECLIMOV_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
                _.Move(C01_GECLIMOV.VIND_NOME_RAZAO, VIND_NOME_RAZAO);
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.VIND_TIPO_PESSOA, VIND_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.GECLIMOV_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
                _.Move(C01_GECLIMOV.VIND_IDE_SEXO, VIND_IDE_SEXO);
                _.Move(C01_GECLIMOV.GECLIMOV_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
                _.Move(C01_GECLIMOV.VIND_EST_CIVIL, VIND_EST_CIVIL);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_OCORR_END, VIND_OCORR_END);
                _.Move(C01_GECLIMOV.GECLIMOV_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_ENDERECO, VIND_ENDERECO);
                _.Move(C01_GECLIMOV.GECLIMOV_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
                _.Move(C01_GECLIMOV.VIND_BAIRRO, VIND_BAIRRO);
                _.Move(C01_GECLIMOV.GECLIMOV_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
                _.Move(C01_GECLIMOV.VIND_CIDADE, VIND_CIDADE);
                _.Move(C01_GECLIMOV.GECLIMOV_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
                _.Move(C01_GECLIMOV.VIND_SIGLA_UF, VIND_SIGLA_UF);
                _.Move(C01_GECLIMOV.GECLIMOV_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
                _.Move(C01_GECLIMOV.VIND_CEP, VIND_CEP);
                _.Move(C01_GECLIMOV.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
                _.Move(C01_GECLIMOV.VIND_DDD, VIND_DDD);
                _.Move(C01_GECLIMOV.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
                _.Move(C01_GECLIMOV.VIND_TELEFONE, VIND_TELEFONE);
                _.Move(C01_GECLIMOV.GECLIMOV_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
                _.Move(C01_GECLIMOV.VIND_FAX, VIND_FAX);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
                _.Move(C01_GECLIMOV.GECLIMOV_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
                _.Move(C01_GECLIMOV.VIND_CGCCPF, VIND_CGCCPF);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
                _.Move(C01_GECLIMOV.VIND_DTNASC, VIND_DTNASC);
            }

        }

        [StopWatch]
        /*" R7320-00-SELECT-GECLIMOV-DB-CLOSE-1 */
        public void R7320_00_SELECT_GECLIMOV_DB_CLOSE_1()
        {
            /*" -1665- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-7 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7()
        {
            /*" -1188- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = 0 END-EXEC */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" R7320-00-SELECT-GECLIMOV-DB-CLOSE-2 */
        public void R7320_00_SELECT_GECLIMOV_DB_CLOSE_2()
        {
            /*" -1675- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7320_99_SAIDA*/

        [StopWatch]
        /*" R6666-00-AUMENTA-REDUZ-VG-DB-SELECT-8 */
        public void R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8()
        {
            /*" -1216- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1 = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1()
            {
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            var executed_1 = R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1.Execute(r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }

        [StopWatch]
        /*" R7400-00-INSERT-GECLIMOV-SECTION */
        private void R7400_00_INSERT_GECLIMOV_SECTION()
        {
            /*" -1689- MOVE '7400' TO WNR-EXEC-SQL */
            _.Move("7400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1733- PERFORM R7400_00_INSERT_GECLIMOV_DB_INSERT_1 */

            R7400_00_INSERT_GECLIMOV_DB_INSERT_1();

            /*" -1736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1737- DISPLAY 'PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ");

                /*" -1738- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -1739- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -1739- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7400-00-INSERT-GECLIMOV-DB-INSERT-1 */
        public void R7400_00_INSERT_GECLIMOV_DB_INSERT_1()
        {
            /*" -1733- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP) VALUES (:GECLIMOV-COD-CLIENTE , :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC , :GECLIMOV-COD-USUARIO:VIND-CODUSU , CURRENT TIMESTAMP) END-EXEC. */

            var r7400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 = new R7400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            R7400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1.Execute(r7400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7400_99_SAIDA*/

        [StopWatch]
        /*" R7450-00-UPDATE-GECLIMOV-SECTION */
        private void R7450_00_UPDATE_GECLIMOV_SECTION()
        {
            /*" -1752- MOVE '7450' TO WNR-EXEC-SQL */
            _.Move("7450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1776- PERFORM R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1 */

            R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1();

            /*" -1779- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1780- DISPLAY 'PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ");

                /*" -1781- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -1782- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -1782- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7450-00-UPDATE-GECLIMOV-DB-UPDATE-1 */
        public void R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1()
        {
            /*" -1776- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET TIPO_MOVIMENTO = :GECLIMOV-TIPO-MOVIMENTO, DATA_ULT_MANUTEN = :GECLIMOV-DATA-ULT-MANUTEN, NOME_RAZAO = :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO, TIPO_PESSOA = :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA, IDE_SEXO = :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO, ESTADO_CIVIL = :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL, OCORR_ENDERECO = :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END, ENDERECO = :GECLIMOV-ENDERECO:VIND-ENDERECO, BAIRRO = :GECLIMOV-BAIRRO:VIND-BAIRRO, CIDADE = :GECLIMOV-CIDADE:VIND-CIDADE, SIGLA_UF = :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF, CEP = :GECLIMOV-CEP:VIND-CEP , DDD = :GECLIMOV-DDD:VIND-DDD , TELEFONE = :GECLIMOV-TELEFONE:VIND-TELEFONE , FAX = :GECLIMOV-FAX:VIND-FAX , CGCCPF = :GECLIMOV-CGCCPF:VIND-CGCCPF , DATA_NASCIMENTO = :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC, COD_USUARIO = :GECLIMOV-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_HIST = :GECLIMOV-OCORR-HIST END-EXEC. */

            var r7450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 = new R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1()
            {
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
            };

            R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1.Execute(r7450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7450_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1794- DISPLAY ' ' */
            _.Display($" ");

            /*" -1795- DISPLAY 'NOME          ' NOME-REG. */
            _.Display($"NOME          {RECORD_ENTRADA.NOME_REG}");

            /*" -1797- DISPLAY 'MATRICULA     ' MATRICULA-REG. */
            _.Display($"MATRICULA     {RECORD_ENTRADA.MATRICULA_REG}");

            /*" -1798- DISPLAY SEGURVGA-NUM-APOLICE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -1799- DISPLAY SEGURVGA-COD-SUBGRUPO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -1800- DISPLAY SEGURVGA-COD-FONTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);

            /*" -1801- DISPLAY FONTES-ULT-PROP-AUTOMAT */
            _.Display(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);

            /*" -1802- DISPLAY SEGURVGA-NUM-CERTIFICADO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

            /*" -1803- DISPLAY SEGURVGA-COD-CLIENTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

            /*" -1804- DISPLAY MOVIMVGA-COD-AGENCIADOR */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -1805- DISPLAY MOVIMVGA-NUM-MATRICULA */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -1806- DISPLAY MOVIMVGA-VAL-SALARIO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -1807- DISPLAY MOVIMVGA-TIPO-SALARIO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -1808- DISPLAY MOVIMVGA-TIPO-PLANO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -1809- DISPLAY MOVIMVGA-QTD-SAL-MORNATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -1810- DISPLAY MOVIMVGA-TAXA-VG */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -1811- DISPLAY MOVIMVGA-IMP-MORNATU-ANT */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -1812- DISPLAY MOVIMVGA-IMP-MORNATU-ATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -1813- DISPLAY MOVIMVGA-PRM-VG-ANT */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -1814- DISPLAY MOVIMVGA-PRM-VG-ATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -1815- DISPLAY MOVIMVGA-COD-OPERACAO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -1816- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -1817- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -1818- DISPLAY CLIENTES-DATA-NASCIMENTO */
            _.Display(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -1819- DISPLAY FATURCON-DATA-REFERENCIA */
            _.Display(FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);

            /*" -1820- DISPLAY MOVIMVGA-DATA-AVERBACAO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -1822- DISPLAY SEGURVGA-DATA-INIVIGENCIA. */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);

            /*" -1824- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1826- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1826- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1828- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1832- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1834- CLOSE ENTRADA. */
            ENTRADA.Close();

            /*" -1834- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}