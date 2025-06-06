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
using Sias.VidaEmGrupo.DB2.VG9545B;

namespace Code
{
    public class VG9545B
    {
        public bool IsCall { get; set; }

        public VG9545B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   AUTOR  .................  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   DATA   .................  09.12.2005.                        *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA MOVIMENTO DE CANCELAMENTO     *      */
        /*"      *                             PARA APOLICES SINDUSCON            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

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
        /*"77         HOST-NUM-APOLICE       PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis HOST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-IMPMORNATU      PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-PRMVG           PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPMORACID      PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-PRMAP           PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPINVPERM      PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPDIT          PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-DTINIVIG        PIC  X(010).*/
        public StringBasis V0COBA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DTTERVIG        PIC  X(010).*/
        public StringBasis V0COBA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         DATA-REFERENCIA        PIC  X(010).*/
        public StringBasis DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           WNATURALIDADE.*/
        public VG9545B_WNATURALIDADE WNATURALIDADE { get; set; } = new VG9545B_WNATURALIDADE();
        public class VG9545B_WNATURALIDADE : VarBasis
        {
            /*"  05         WNAT-MATRICULA    PIC  X(007).*/
            public StringBasis WNAT_MATRICULA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  05         WNAT-DATA         PIC  X(008).*/
            public StringBasis WNAT_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05         WNAT-TIPO         PIC  9(003).*/
            public IntBasis WNAT_TIPO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05         WNAT-BRANCOS      PIC  X(012).*/
            public StringBasis WNAT_BRANCOS { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"01           WDTNAS-FUNCICEF   PIC  9(009).*/
        }
        public IntBasis WDTNAS_FUNCICEF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01           WDTNAS-FUNCICEF-R REDEFINES WDTNAS-FUNCICEF.*/
        private _REDEF_VG9545B_WDTNAS_FUNCICEF_R _wdtnas_funcicef_r { get; set; }
        public _REDEF_VG9545B_WDTNAS_FUNCICEF_R WDTNAS_FUNCICEF_R
        {
            get { _wdtnas_funcicef_r = new _REDEF_VG9545B_WDTNAS_FUNCICEF_R(); _.Move(WDTNAS_FUNCICEF, _wdtnas_funcicef_r); VarBasis.RedefinePassValue(WDTNAS_FUNCICEF, _wdtnas_funcicef_r, WDTNAS_FUNCICEF); _wdtnas_funcicef_r.ValueChanged += () => { _.Move(_wdtnas_funcicef_r, WDTNAS_FUNCICEF); }; return _wdtnas_funcicef_r; }
            set { VarBasis.RedefinePassValue(value, _wdtnas_funcicef_r, WDTNAS_FUNCICEF); }
        }  //Redefines
        public class _REDEF_VG9545B_WDTNAS_FUNCICEF_R : VarBasis
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

            public _REDEF_VG9545B_WDTNAS_FUNCICEF_R()
            {
                ZZ_DTNAS_FCEF.ValueChanged += OnValueChanged;
                DD_DTNAS_FCEF.ValueChanged += OnValueChanged;
                MM_DTNAS_FCEF.ValueChanged += OnValueChanged;
                SS_DTNAS_FCEF.ValueChanged += OnValueChanged;
                AA_DTNAS_FCEF.ValueChanged += OnValueChanged;
            }

        }
        public VG9545B_WDATASQL WDATASQL { get; set; } = new VG9545B_WDATASQL();
        public class VG9545B_WDATASQL : VarBasis
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
        public VG9545B_WDATA_FILE WDATA_FILE { get; set; } = new VG9545B_WDATA_FILE();
        public class VG9545B_WDATA_FILE : VarBasis
        {
            /*"  05         DD-DATA-FILE      PIC  9(002).*/
            public IntBasis DD_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         MM-DATA-FILE      PIC  9(002).*/
            public IntBasis MM_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         SS-DATA-FILE      PIC  9(002).*/
            public IntBasis SS_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         AA-DATA-FILE      PIC  9(002).*/
            public IntBasis AA_DATA_FILE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WDTOPER           PIC  X(010).*/
        }
        public StringBasis WDTOPER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           WDTOP REDEFINES WDTOPER.*/
        private _REDEF_VG9545B_WDTOP _wdtop { get; set; }
        public _REDEF_VG9545B_WDTOP WDTOP
        {
            get { _wdtop = new _REDEF_VG9545B_WDTOP(); _.Move(WDTOPER, _wdtop); VarBasis.RedefinePassValue(WDTOPER, _wdtop, WDTOPER); _wdtop.ValueChanged += () => { _.Move(_wdtop, WDTOPER); }; return _wdtop; }
            set { VarBasis.RedefinePassValue(value, _wdtop, WDTOPER); }
        }  //Redefines
        public class _REDEF_VG9545B_WDTOP : VarBasis
        {
            /*"  05         SS-DATA-OPER      PIC  9(002).*/
            public IntBasis SS_DATA_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         AA-DATA-OPER      PIC  9(002).*/
            public IntBasis AA_DATA_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO01-OPER      PIC  X(001).*/
            public StringBasis TRACO01_OPER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         MM-DATA-OPER      PIC  9(002).*/
            public IntBasis MM_DATA_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         TRACO02-OPER      PIC  X(001).*/
            public StringBasis TRACO02_OPER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         DD-DATA-OPER      PIC  9(002).*/
            public IntBasis DD_DATA_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           WDTINIVIG.*/

            public _REDEF_VG9545B_WDTOP()
            {
                SS_DATA_OPER.ValueChanged += OnValueChanged;
                AA_DATA_OPER.ValueChanged += OnValueChanged;
                TRACO01_OPER.ValueChanged += OnValueChanged;
                MM_DATA_OPER.ValueChanged += OnValueChanged;
                TRACO02_OPER.ValueChanged += OnValueChanged;
                DD_DATA_OPER.ValueChanged += OnValueChanged;
            }

        }
        public VG9545B_WDTINIVIG WDTINIVIG { get; set; } = new VG9545B_WDTINIVIG();
        public class VG9545B_WDTINIVIG : VarBasis
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
        public VG9545B_WDTTERVIG WDTTERVIG { get; set; } = new VG9545B_WDTTERVIG();
        public class VG9545B_WDTTERVIG : VarBasis
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
        public VG9545B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG9545B_AREA_DE_WORK();
        public class VG9545B_AREA_DE_WORK : VarBasis
        {
            /*"  05   WS-DATA-BASE.*/
            public VG9545B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VG9545B_WS_DATA_BASE();
            public class VG9545B_WS_DATA_BASE : VarBasis
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
            public VG9545B_WDTNAS_REG WDTNAS_REG { get; set; } = new VG9545B_WDTNAS_REG();
            public class VG9545B_WDTNAS_REG : VarBasis
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
            public VG9545B_W02DTSQL W02DTSQL { get; set; } = new VG9545B_W02DTSQL();
            public class VG9545B_W02DTSQL : VarBasis
            {
                /*"       10  W02AAMMSQL.*/
                public VG9545B_W02AAMMSQL W02AAMMSQL { get; set; } = new VG9545B_W02AAMMSQL();
                public class VG9545B_W02AAMMSQL : VarBasis
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
            public VG9545B_W03DTSQL W03DTSQL { get; set; } = new VG9545B_W03DTSQL();
            public class VG9545B_W03DTSQL : VarBasis
            {
                /*"       10  W03AAMMSQL.*/
                public VG9545B_W03AAMMSQL W03AAMMSQL { get; set; } = new VG9545B_W03AAMMSQL();
                public class VG9545B_W03AAMMSQL : VarBasis
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
            /*"  05         WS-SQLCODE        PIC  -----------9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "12", "-----------9."));
            /*"  05         WACC-LIDOS           PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-JA-TEM-SEGURO   PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_JA_TEM_SEGURO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-NAO-TEM-SEGURO  PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_NAO_TEM_SEGURO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-INCLUIDOS       PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_INCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-CANCELADOS      PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WACC_CANCELADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            /*"  05       WTEM-SEGURAVG          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WABEND.*/
            public VG9545B_WABEND WABEND { get; set; } = new VG9545B_WABEND();
            public class VG9545B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG9545B '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG9545B ");
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
        public Dclgens.CONTACOR CONTACOR { get; set; } = new Dclgens.CONTACOR();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public VG9545B_CCURSOR CCURSOR { get; set; } = new VG9545B_CCURSOR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -251- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -254- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -257- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -261- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -267- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -272- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -274- MOVE SISTEMAS-DATA-MOV-ABERTO TO DATA-REFERENCIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, DATA_REFERENCIA);

            /*" -277- MOVE '01' TO DATA-REFERENCIA (9:2). */
            _.MoveAtPosition("01", DATA_REFERENCIA, 9, 2);

            /*" -279- PERFORM R0040-00-VERIFICA-APOLICE. */

            R0040_00_VERIFICA_APOLICE_SECTION();

            /*" -290- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -295- DISPLAY 'ERRO COUNT MOVIMENTO_VGAP ' HOST-NUM-APOLICE */
                _.Display($"ERRO COUNT MOVIMENTO_VGAP {HOST_NUM_APOLICE}");

                /*" -302- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -304- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -324- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -326- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -330- PERFORM R0030-00-FETCH-SEGURVGA */

            R0030_00_FETCH_SEGURVGA_SECTION();

            /*" -333- PERFORM R0050-00-PROCESSA-REGISTRO UNTIL WFIM-ENTRADA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ENTRADA.IsEmpty()))
            {

                R0050_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -334- DISPLAY ' ' */
            _.Display($" ");

            /*" -335- DISPLAY '*--------  VG9545B - FIM NORMAL  --------*' */
            _.Display($"*--------  VG9545B - FIM NORMAL  --------*");

            /*" -336- DISPLAY ' ' */
            _.Display($" ");

            /*" -339- DISPLAY 'TOTAL DE SEGUROS CANCELADOS   ... ' WACC-CANCELADOS */
            _.Display($"TOTAL DE SEGUROS CANCELADOS   ... {AREA_DE_WORK.WACC_CANCELADOS}");

            /*" -340- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -340- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -267- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

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
            /*" -346- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -346- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -324- EXEC SQL DECLARE CCURSOR CURSOR FOR SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, COD_FONTE, SIT_REGISTRO, COD_CLIENTE, NUM_MATRICULA, DATA_INIVIGENCIA, NATURALIDADE, OCORR_ENDERECO FROM SEGUROS.SEGURADOS_VGAP A WHERE NUM_APOLICE = 0109300000799 AND SIT_REGISTRO IN ( '0' , '1' ) AND COD_PROFISSAO = 0 END-EXEC. */
            CCURSOR = new VG9545B_CCURSOR(false);
            string GetQuery_CCURSOR()
            {
                var query = @$"SELECT 
							TIPO_INCLUSAO
							, 
							COD_AGENCIADOR
							, 
							NUM_ITEM
							, 
							OCORR_HISTORICO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							COD_FONTE
							, 
							SIT_REGISTRO
							, 
							COD_CLIENTE
							, 
							NUM_MATRICULA
							, 
							DATA_INIVIGENCIA
							, 
							NATURALIDADE
							, 
							OCORR_ENDERECO 
							FROM SEGUROS.SEGURADOS_VGAP A 
							WHERE NUM_APOLICE = 0109300000799 
							AND SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND COD_PROFISSAO = 0";

                return query;
            }
            CCURSOR.GetQueryEvent += GetQuery_CCURSOR;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -326- EXEC SQL OPEN CCURSOR END-EXEC. */

            CCURSOR.Open();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -290- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :MOVIMVGA-NUM-PROPOSTA FROM SEGUROS.MOVIMENTO_VGAP WHERE DATA_INCLUSAO IS NULL AND DATA_AVERBACAO IS NOT NULL AND NUM_APOLICE = 0109300000799 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_NUM_PROPOSTA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-FETCH-SEGURVGA-SECTION */
        private void R0030_00_FETCH_SEGURVGA_SECTION()
        {
            /*" -358- MOVE '0030' TO WNR-EXEC-SQL. */
            _.Move("0030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -373- PERFORM R0030_00_FETCH_SEGURVGA_DB_FETCH_1 */

            R0030_00_FETCH_SEGURVGA_DB_FETCH_1();

            /*" -375- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -376- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -377- MOVE 'S' TO WFIM-ENTRADA */
                    _.Move("S", AREA_DE_WORK.WFIM_ENTRADA);

                    /*" -377- PERFORM R0030_00_FETCH_SEGURVGA_DB_CLOSE_1 */

                    R0030_00_FETCH_SEGURVGA_DB_CLOSE_1();

                    /*" -379- ELSE */
                }
                else
                {


                    /*" -379- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0030-00-FETCH-SEGURVGA-DB-FETCH-1 */
        public void R0030_00_FETCH_SEGURVGA_DB_FETCH_1()
        {
            /*" -373- EXEC SQL FETCH CCURSOR INTO :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-AGENCIADOR, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-COD-FONTE, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-DATA-INIVIGENCIA, :SEGURVGA-NATURALIDADE, :SEGURVGA-OCORR-ENDERECO END-EXEC. */

            if (CCURSOR.Fetch())
            {
                _.Move(CCURSOR.SEGURVGA_TIPO_INCLUSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO);
                _.Move(CCURSOR.SEGURVGA_COD_AGENCIADOR, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR);
                _.Move(CCURSOR.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(CCURSOR.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(CCURSOR.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(CCURSOR.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(CCURSOR.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(CCURSOR.SEGURVGA_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);
                _.Move(CCURSOR.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(CCURSOR.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(CCURSOR.SEGURVGA_NUM_MATRICULA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);
                _.Move(CCURSOR.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(CCURSOR.SEGURVGA_NATURALIDADE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NATURALIDADE);
                _.Move(CCURSOR.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
            }

        }

        [StopWatch]
        /*" R0030-00-FETCH-SEGURVGA-DB-CLOSE-1 */
        public void R0030_00_FETCH_SEGURVGA_DB_CLOSE_1()
        {
            /*" -377- EXEC SQL CLOSE CCURSOR END-EXEC */

            CCURSOR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0040-00-VERIFICA-APOLICE-SECTION */
        private void R0040_00_VERIFICA_APOLICE_SECTION()
        {
            /*" -391- MOVE '0040' TO WNR-EXEC-SQL. */
            _.Move("0040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -406- PERFORM R0040_00_VERIFICA_APOLICE_DB_SELECT_1 */

            R0040_00_VERIFICA_APOLICE_DB_SELECT_1();

            /*" -409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -410- DISPLAY 'ERRO SELECT PARAMETROS_RAMOS' */
                _.Display($"ERRO SELECT PARAMETROS_RAMOS");

                /*" -410- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0040-00-VERIFICA-APOLICE-DB-SELECT-1 */
        public void R0040_00_VERIFICA_APOLICE_DB_SELECT_1()
        {
            /*" -406- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WHERE 1 = 1 END-EXEC. */

            var r0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1 = new R0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1.Execute(r0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VGAPC, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC);
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
                _.Move(executed_1.PARAMRAM_NUM_RAMO_PRSTMISTA, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCESSA-REGISTRO-SECTION */
        private void R0050_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -423- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

            /*" -423- PERFORM R6000-00-CANCELA-SEGURO. */

            R6000_00_CANCELA_SEGURO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0050_90_NEXT */

            R0050_90_NEXT();

        }

        [StopWatch]
        /*" R0050-90-NEXT */
        private void R0050_90_NEXT(bool isPerform = false)
        {
            /*" -427- PERFORM R0030-00-FETCH-SEGURVGA. */

            R0030_00_FETCH_SEGURVGA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-SECTION */
        private void R6000_00_CANCELA_SEGURO_SECTION()
        {
            /*" -443- MOVE '6005' TO WNR-EXEC-SQL. */
            _.Move("6005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -448- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_1 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_1();

            /*" -451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -456- COMPUTE FONTES-ULT-PROP-AUTOMAT = FONTES-ULT-PROP-AUTOMAT + 1. */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -458- MOVE '6010' TO WNR-EXEC-SQL. */
            _.Move("6010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -463- PERFORM R6000_00_CANCELA_SEGURO_DB_UPDATE_1 */

            R6000_00_CANCELA_SEGURO_DB_UPDATE_1();

            /*" -466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -468- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -472- MOVE 1 TO MOVIMVGA-PERI-PAGAMENTO. */
            _.Move(1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -474- MOVE '6025' TO WNR-EXEC-SQL. */
            _.Move("6025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -488- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_2 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_2();

            /*" -491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -492- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -493- DISPLAY 'R6000-00 (ERRO - SELECT APOLICE_COBERTURAS)' */
                    _.Display($"R6000-00 (ERRO - SELECT APOLICE_COBERTURAS)");

                    /*" -494- DISPLAY 'R6000-00 (COD_COBERTURA 11 - VG OU PST    )' */
                    _.Display($"R6000-00 (COD_COBERTURA 11 - VG OU PST    )");

                    /*" -496- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -498- MOVE '6030' TO WNR-EXEC-SQL. */
            _.Move("6030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -511- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_3 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_3();

            /*" -514- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -517- MOVE 0 TO V0COBA-IMPMORACID V0COBA-PRMAP. */
                _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);
            }


            /*" -519- MOVE '6035' TO WNR-EXEC-SQL. */
            _.Move("6035", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -530- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_4 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_4();

            /*" -533- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -535- MOVE 0 TO V0COBA-IMPINVPERM. */
                _.Move(0, V0COBA_IMPINVPERM);
            }


            /*" -537- MOVE '6040' TO WNR-EXEC-SQL. */
            _.Move("6040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -548- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_5 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_5();

            /*" -551- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -553- MOVE 0 TO V0COBA-IMPDIT. */
                _.Move(0, V0COBA_IMPDIT);
            }


            /*" -555- MOVE '6045' TO WNR-EXEC-SQL. */
            _.Move("6045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -564- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_6 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_6();

            /*" -567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -568- MOVE ZEROS TO CONTACOR-COD-AGENCIA */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);

                /*" -569- MOVE ZEROS TO CONTACOR-NUM-CTA-CORRENTE */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);

                /*" -571- MOVE SPACES TO CONTACOR-DAC-CTA-CORRENTE. */
                _.Move("", CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


            /*" -578- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-MOVIMENTO MOVIMVGA-DATA-OPERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

            /*" -580- MOVE '6090' TO WNR-EXEC-SQL. */
            _.Move("6090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -732- PERFORM R6000_00_CANCELA_SEGURO_DB_INSERT_1 */

            R6000_00_CANCELA_SEGURO_DB_INSERT_1();

            /*" -735- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -736- DISPLAY 'R6000-00 (ERRO - INSERT V0MOVIMENTO  )' */
                _.Display($"R6000-00 (ERRO - INSERT V0MOVIMENTO  )");

                /*" -739- DISPLAY 'CERTIF: ' SEGURVGA-NUM-CERTIFICADO ' ' 'FONTE:  ' SEGURVGA-COD-FONTE ' ' 'PROPOS: ' FONTES-ULT-PROP-AUTOMAT */

                $"CERTIF: {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} FONTE:  {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE} PROPOS: {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}"
                .Display();

                /*" -741- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -741- ADD 1 TO WACC-CANCELADOS. */
            AREA_DE_WORK.WACC_CANCELADOS.Value = AREA_DE_WORK.WACC_CANCELADOS + 1;

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-1 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_1()
        {
            /*" -448- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-UPDATE-1 */
        public void R6000_00_CANCELA_SEGURO_DB_UPDATE_1()
        {
            /*" -463- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1 = new R6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            R6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1.Execute(r6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-2 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_2()
        {
            /*" -488- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (:PARAMRAM-NUM-RAMO-PRSTMISTA, :PARAMRAM-RAMO-VG) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 11 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1()
            {
                PARAMRAM_NUM_RAMO_PRSTMISTA = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA.ToString(),
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_VG = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, V0COBA_PRMVG);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -754- DISPLAY ' ' */
            _.Display($" ");

            /*" -755- DISPLAY SEGURVGA-NUM-APOLICE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -756- DISPLAY SEGURVGA-COD-SUBGRUPO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -757- DISPLAY SEGURVGA-COD-FONTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);

            /*" -758- DISPLAY FONTES-ULT-PROP-AUTOMAT */
            _.Display(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);

            /*" -759- DISPLAY SEGURVGA-NUM-CERTIFICADO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

            /*" -760- DISPLAY SEGURVGA-COD-CLIENTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

            /*" -761- DISPLAY MOVIMVGA-COD-AGENCIADOR */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -762- DISPLAY MOVIMVGA-NUM-MATRICULA */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -763- DISPLAY MOVIMVGA-VAL-SALARIO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -764- DISPLAY MOVIMVGA-TIPO-SALARIO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -765- DISPLAY MOVIMVGA-TIPO-PLANO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -766- DISPLAY MOVIMVGA-QTD-SAL-MORNATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -767- DISPLAY MOVIMVGA-TAXA-VG */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -768- DISPLAY MOVIMVGA-IMP-MORNATU-ANT */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -769- DISPLAY MOVIMVGA-IMP-MORNATU-ATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -770- DISPLAY MOVIMVGA-PRM-VG-ANT */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -771- DISPLAY MOVIMVGA-PRM-VG-ATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -772- DISPLAY MOVIMVGA-COD-OPERACAO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -773- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -774- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -775- DISPLAY CLIENTES-DATA-NASCIMENTO */
            _.Display(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -776- DISPLAY FATURCON-DATA-REFERENCIA */
            _.Display(FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);

            /*" -777- DISPLAY MOVIMVGA-DATA-AVERBACAO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -778- DISPLAY SEGURVGA-DATA-INIVIGENCIA */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);

            /*" -780- DISPLAY 'LIDOS  ' WACC-LIDOS */
            _.Display($"LIDOS  {AREA_DE_WORK.WACC_LIDOS}");

            /*" -782- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -784- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -784- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -786- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -791- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -791- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-3 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_3()
        {
            /*" -511- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 1 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-4 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_4()
        {
            /*" -530- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 2 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-INSERT-1 */
        public void R6000_00_CANCELA_SEGURO_DB_INSERT_1()
        {
            /*" -732- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES (:SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :FONTES-ULT-PROP-AUTOMAT, '1' , :SEGURVGA-NUM-CERTIFICADO, ' ' , :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-COD-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :MOVIMVGA-PERI-PAGAMENTO, 12, ' ' , ' ' , ' ' , 0, :SEGURVGA-NATURALIDADE, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-OCORR-ENDERECO, 104, :CONTACOR-COD-AGENCIA, ' ' , :SEGURVGA-NUM-MATRICULA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, 401, :SISTEMAS-DATA-MOV-ABERTO, 0, '1' , 'VG9545B' , :MOVIMVGA-DATA-OPERACAO, NULL, NULL, NULL, NULL, :DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO, NULL, NULL) END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1 = new R6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_TIPO_INCLUSAO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                SEGURVGA_COD_AGENCIADOR = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_PERI_PAGAMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO.ToString(),
                SEGURVGA_NATURALIDADE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NATURALIDADE.ToString(),
                SEGURVGA_OCORR_ENDERECO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO.ToString(),
                CONTACOR_COD_AGENCIA = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA.ToString(),
                SEGURVGA_NUM_MATRICULA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA.ToString(),
                CONTACOR_NUM_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE.ToString(),
                CONTACOR_DAC_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE.ToString(),
                V0COBA_IMPMORNATU = V0COBA_IMPMORNATU.ToString(),
                V0COBA_IMPMORACID = V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = V0COBA_IMPDIT.ToString(),
                V0COBA_PRMVG = V0COBA_PRMVG.ToString(),
                V0COBA_PRMAP = V0COBA_PRMAP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVIMVGA_DATA_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.ToString(),
                DATA_REFERENCIA = DATA_REFERENCIA.ToString(),
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
            };

            R6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1.Execute(r6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-5 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_5()
        {
            /*" -548- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 5 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-6 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_6()
        {
            /*" -564- EXEC SQL SELECT COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :CONTACOR-COD-AGENCIA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE FROM SEGUROS.CONTA_CORRENTE WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_COD_AGENCIA, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);
                _.Move(executed_1.CONTACOR_NUM_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);
                _.Move(executed_1.CONTACOR_DAC_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


        }
    }
}