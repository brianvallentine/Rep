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
using Sias.VidaEmGrupo.DB2.VG9550B;

namespace Code
{
    public class VG9550B
    {
        public bool IsCall { get; set; }

        public VG9550B()
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
        /*"      *   FUNCAO ................A) GERA MOVIMENTO DE CANCELAMENTO     *      */
        /*"      *                             PARA APOLICES ESPECIFICAS          *      */
        /*"      *                                                                *      */
        /*"V.02  *                          B) ALTERAR OS ENDERECOS DOS SEGURADOS *      */
        /*"V.02  *                             VINCULADOS A APOLICE/SUBGRUPO DAS  *      */
        /*"V.02  *                             APOLICES ESPECIFICAS QUE TIVERAM   *      */
        /*"V.02  *                             SEUS ENDERECOS MODIFICADOS PELO    *      */
        /*"V.02  *                             ATALHO 04.02.05                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * UTILIZAR A MODALIDADE DE COBERTURA DA TABELA APOLICES PARA REA-*      */
        /*"      * LIZAR CONSULTA A TABELA APOLICE_COBERTURA.                     *      */
        /*"      * (HISTORIA 39.394)           - FRANK CARVALHO                   *      */
        /*"      *                                                                *      */
        /*"      * 18/06/2018                  - PROCURAR POR V.03                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERAR OS ENDERECOS DA SEGURADOS_VGAP QUANDO O SUBGRUPO TIVER *      */
        /*"      * SEU ENDERE�O MODIFICADO PELO ATALHO 04.02.05                   *      */
        /*"      * (CADMUS 125.892)            - ELIERMES OLIVEIRA                *      */
        /*"      *                                                                *      */
        /*"      * 15/04/2016                  - PROCURAR POR V.02                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PASSA A CONSIDERAR O TIPO DO SEGURADO NA GERACAO DO MOVIMENTO. *      */
        /*"      * (CADMUS 78.757)               LUIZ MARQUES     (FAST COMPUTER) *      */
        /*"      *                                                                *      */
        /*"      * 29/01/2013   - PROCURAR POR V.01                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 10/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
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
        /*"77         VIND-ORIG-PRODU        PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-I      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-F      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-MAX-OCOREND         PIC S9(4) USAGE COMP.*/
        public IntBasis WS_MAX_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
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
        /*"77         WS-GE-CLIENTE-OCOREND  PIC S9(4) USAGE COMP.*/
        public IntBasis WS_GE_CLIENTE_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         WS-V0APOL-MODALIDA     PIC S9(004)    COMP.*/
        public IntBasis WS_V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WNATURALIDADE.*/
        public VG9550B_WNATURALIDADE WNATURALIDADE { get; set; } = new VG9550B_WNATURALIDADE();
        public class VG9550B_WNATURALIDADE : VarBasis
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
        private _REDEF_VG9550B_WDTNAS_FUNCICEF_R _wdtnas_funcicef_r { get; set; }
        public _REDEF_VG9550B_WDTNAS_FUNCICEF_R WDTNAS_FUNCICEF_R
        {
            get { _wdtnas_funcicef_r = new _REDEF_VG9550B_WDTNAS_FUNCICEF_R(); _.Move(WDTNAS_FUNCICEF, _wdtnas_funcicef_r); VarBasis.RedefinePassValue(WDTNAS_FUNCICEF, _wdtnas_funcicef_r, WDTNAS_FUNCICEF); _wdtnas_funcicef_r.ValueChanged += () => { _.Move(_wdtnas_funcicef_r, WDTNAS_FUNCICEF); }; return _wdtnas_funcicef_r; }
            set { VarBasis.RedefinePassValue(value, _wdtnas_funcicef_r, WDTNAS_FUNCICEF); }
        }  //Redefines
        public class _REDEF_VG9550B_WDTNAS_FUNCICEF_R : VarBasis
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

            public _REDEF_VG9550B_WDTNAS_FUNCICEF_R()
            {
                ZZ_DTNAS_FCEF.ValueChanged += OnValueChanged;
                DD_DTNAS_FCEF.ValueChanged += OnValueChanged;
                MM_DTNAS_FCEF.ValueChanged += OnValueChanged;
                SS_DTNAS_FCEF.ValueChanged += OnValueChanged;
                AA_DTNAS_FCEF.ValueChanged += OnValueChanged;
            }

        }
        public VG9550B_WDATASQL WDATASQL { get; set; } = new VG9550B_WDATASQL();
        public class VG9550B_WDATASQL : VarBasis
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
        public VG9550B_WDATA_FILE WDATA_FILE { get; set; } = new VG9550B_WDATA_FILE();
        public class VG9550B_WDATA_FILE : VarBasis
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
        private _REDEF_VG9550B_WDTOP _wdtop { get; set; }
        public _REDEF_VG9550B_WDTOP WDTOP
        {
            get { _wdtop = new _REDEF_VG9550B_WDTOP(); _.Move(WDTOPER, _wdtop); VarBasis.RedefinePassValue(WDTOPER, _wdtop, WDTOPER); _wdtop.ValueChanged += () => { _.Move(_wdtop, WDTOPER); }; return _wdtop; }
            set { VarBasis.RedefinePassValue(value, _wdtop, WDTOPER); }
        }  //Redefines
        public class _REDEF_VG9550B_WDTOP : VarBasis
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

            public _REDEF_VG9550B_WDTOP()
            {
                SS_DATA_OPER.ValueChanged += OnValueChanged;
                AA_DATA_OPER.ValueChanged += OnValueChanged;
                TRACO01_OPER.ValueChanged += OnValueChanged;
                MM_DATA_OPER.ValueChanged += OnValueChanged;
                TRACO02_OPER.ValueChanged += OnValueChanged;
                DD_DATA_OPER.ValueChanged += OnValueChanged;
            }

        }
        public VG9550B_WDTINIVIG WDTINIVIG { get; set; } = new VG9550B_WDTINIVIG();
        public class VG9550B_WDTINIVIG : VarBasis
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
        public VG9550B_WDTTERVIG WDTTERVIG { get; set; } = new VG9550B_WDTTERVIG();
        public class VG9550B_WDTTERVIG : VarBasis
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
        public VG9550B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG9550B_AREA_DE_WORK();
        public class VG9550B_AREA_DE_WORK : VarBasis
        {
            /*"  05   WS-DATA-BASE.*/
            public VG9550B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VG9550B_WS_DATA_BASE();
            public class VG9550B_WS_DATA_BASE : VarBasis
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
            public VG9550B_WDTNAS_REG WDTNAS_REG { get; set; } = new VG9550B_WDTNAS_REG();
            public class VG9550B_WDTNAS_REG : VarBasis
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
            public VG9550B_W02DTSQL W02DTSQL { get; set; } = new VG9550B_W02DTSQL();
            public class VG9550B_W02DTSQL : VarBasis
            {
                /*"       10  W02AAMMSQL.*/
                public VG9550B_W02AAMMSQL W02AAMMSQL { get; set; } = new VG9550B_W02AAMMSQL();
                public class VG9550B_W02AAMMSQL : VarBasis
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
            public VG9550B_W03DTSQL W03DTSQL { get; set; } = new VG9550B_W03DTSQL();
            public class VG9550B_W03DTSQL : VarBasis
            {
                /*"       10  W03AAMMSQL.*/
                public VG9550B_W03AAMMSQL W03AAMMSQL { get; set; } = new VG9550B_W03AAMMSQL();
                public class VG9550B_W03AAMMSQL : VarBasis
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
            /*"  05         WS-CONT-APOL         PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WS_CONT_APOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-CONT-UPDT-APOL    PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WS_CONT_UPDT_APOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-CONT-SEG          PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WS_CONT_SEG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-CONT-UPDT-SEG     PIC  9(006)       VALUE  ZEROS*/
            public IntBasis WS_CONT_UPDT_SEG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-ENTRADA      PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_ENTRADA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-SEGURADO     PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
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
            /*"  05       WTEM-APOLICOB          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_APOLICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WABEND.*/
            public VG9550B_WABEND WABEND { get; set; } = new VG9550B_WABEND();
            public class VG9550B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG9550B '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG9550B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01  REGISTRO-LINKAGE-GE0510S.*/
            }
        }
        public VG9550B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG9550B_REGISTRO_LINKAGE_GE0510S();
        public class VG9550B_REGISTRO_LINKAGE_GE0510S : VarBasis
        {
            /*"    10 LK-GE510-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    10 LK-GE510-COD-SUBGRUPO      PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE510-COD-MODALIDADE    PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE510_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE510-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE510_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE510-MENSAGEM.*/
            public VG9550B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG9550B_LK_GE510_MENSAGEM();
            public class VG9550B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
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
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public VG9550B_CCURSOR CCURSOR { get; set; } = new VG9550B_CCURSOR();
        public VG9550B_CENDSBG CENDSBG { get; set; } = new VG9550B_CENDSBG();
        public VG9550B_CSEGURD CSEGURD { get; set; } = new VG9550B_CSEGURD();
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
            /*" -306- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -309- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -312- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -316- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -317- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -318- DISPLAY 'PROGRAMA EM EXECUCAO VG9550B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VG9550B   ");

            /*" -319- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -321- DISPLAY 'VERSAO V.03  39.394 18/06/2018 ' */
            _.Display($"VERSAO V.03  39.394 18/06/2018 ");

            /*" -323- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -329- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -332- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -333- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -335- END-IF. */
            }


            /*" -336- DISPLAY '  ' */
            _.Display($"  ");

            /*" -337- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -338- DISPLAY 'DATA DO SISTEMA VG --> ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO SISTEMA VG --> {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -339- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -341- DISPLAY '  ' */
            _.Display($"  ");

            /*" -342- MOVE SISTEMAS-DATA-MOV-ABERTO TO DATA-REFERENCIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, DATA_REFERENCIA);

            /*" -344- MOVE '01' TO DATA-REFERENCIA (9:2). */
            _.MoveAtPosition("01", DATA_REFERENCIA, 9, 2);

            /*" -346- PERFORM R0040-00-VERIFICA-APOLICE. */

            R0040_00_VERIFICA_APOLICE_SECTION();

            /*" -348- PERFORM R0010-00-PROC-CANCELAMENTOS */

            R0010_00_PROC_CANCELAMENTOS_SECTION();

            /*" -350- PERFORM R1000-00-ALT-END-SEGURADOS. */

            R1000_00_ALT_END_SEGURADOS_SECTION();

            /*" -352- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -352- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -329- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-PROC-CANCELAMENTOS-SECTION */
        private void R0010_00_PROC_CANCELAMENTOS_SECTION()
        {
            /*" -364- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -383- PERFORM R0010_00_PROC_CANCELAMENTOS_DB_DECLARE_1 */

            R0010_00_PROC_CANCELAMENTOS_DB_DECLARE_1();

            /*" -385- PERFORM R0010_00_PROC_CANCELAMENTOS_DB_OPEN_1 */

            R0010_00_PROC_CANCELAMENTOS_DB_OPEN_1();

            /*" -389- PERFORM R0030-00-FETCH-SEGURVGA */

            R0030_00_FETCH_SEGURVGA_SECTION();

            /*" -392- PERFORM R0050-00-PROCESSA-REGISTRO UNTIL WFIM-ENTRADA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ENTRADA.IsEmpty()))
            {

                R0050_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -393- DISPLAY ' ' */
            _.Display($" ");

            /*" -394- DISPLAY '*------  VG9550B - PRIMEIRA PARTE -------*' */
            _.Display($"*------  VG9550B - PRIMEIRA PARTE -------*");

            /*" -395- DISPLAY ' ' */
            _.Display($" ");

            /*" -396- DISPLAY 'TOTAL DE SEGUROS LIDOS      ... ' WACC-LIDOS */
            _.Display($"TOTAL DE SEGUROS LIDOS      ... {AREA_DE_WORK.WACC_LIDOS}");

            /*" -397- DISPLAY 'TOTAL DE SEGUROS CANCELADOS ... ' WACC-CANCELADOS */
            _.Display($"TOTAL DE SEGUROS CANCELADOS ... {AREA_DE_WORK.WACC_CANCELADOS}");

            /*" -398- DISPLAY ' ' */
            _.Display($" ");

            /*" -399- DISPLAY '*----------------------------------------*' */
            _.Display($"*----------------------------------------*");

            /*" -401- DISPLAY ' ' */
            _.Display($" ");

            /*" -401- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" R0010-00-PROC-CANCELAMENTOS-DB-DECLARE-1 */
        public void R0010_00_PROC_CANCELAMENTOS_DB_DECLARE_1()
        {
            /*" -383- EXEC SQL DECLARE CCURSOR CURSOR FOR SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, COD_FONTE, SIT_REGISTRO, COD_CLIENTE, NUM_MATRICULA, DATA_INIVIGENCIA, NATURALIDADE, OCORR_ENDERECO, TIPO_SEGURADO FROM SEGUROS.SEGURADOS_VGAP A WHERE SIT_REGISTRO IN ( '0' , '1' ) AND COD_PROFISSAO = 7777 END-EXEC. */
            CCURSOR = new VG9550B_CCURSOR(false);
            string GetQuery_CCURSOR()
            {
                var query = @$"SELECT TIPO_INCLUSAO
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
							, 
							TIPO_SEGURADO 
							FROM SEGUROS.SEGURADOS_VGAP A 
							WHERE SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND COD_PROFISSAO = 7777";

                return query;
            }
            CCURSOR.GetQueryEvent += GetQuery_CCURSOR;

        }

        [StopWatch]
        /*" R0010-00-PROC-CANCELAMENTOS-DB-OPEN-1 */
        public void R0010_00_PROC_CANCELAMENTOS_DB_OPEN_1()
        {
            /*" -385- EXEC SQL OPEN CCURSOR END-EXEC. */

            CCURSOR.Open();

        }

        [StopWatch]
        /*" R1000-00-ALT-END-SEGURADOS-DB-DECLARE-1 */
        public void R1000_00_ALT_END_SEGURADOS_DB_DECLARE_1()
        {
            /*" -890- EXEC SQL DECLARE CENDSBG CURSOR FOR SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.COD_CLIENTE , A.SIT_REGISTRO , A.OCOREND , D.ENDERECO , D.BAIRRO , D.CIDADE , D.SIGLA_UF , D.CEP , D.DDD , D.TELEFONE , D.FAX , D.TELEX FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B, SEGUROS.GE_CLIENTES_MOVTO C, SEGUROS.ENDERECOS D WHERE A.SIT_REGISTRO IN ( '3' , '6' ) AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND B.ORIG_PRODU IN ( 'ESPEC' , 'ESPE1' ) AND A.COD_CLIENTE = C.COD_CLIENTE AND A.OCOREND = C.OCORR_ENDERECO AND A.COD_CLIENTE = D.COD_CLIENTE AND A.OCOREND = D.OCORR_ENDERECO AND C.DATA_ULT_MANUTEN >= :SISTEMAS-DATA-MOV-ABERTO AND C.COD_USUARIO <> 'VG9550B' WITH UR END-EXEC. */
            CENDSBG = new VG9550B_CENDSBG(true);
            string GetQuery_CENDSBG()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_CERTIFICADO
							, 
							A.COD_CLIENTE
							, 
							A.SIT_REGISTRO
							, 
							A.OCOREND
							, 
							D.ENDERECO
							, 
							D.BAIRRO
							, 
							D.CIDADE
							, 
							D.SIGLA_UF
							, 
							D.CEP
							, 
							D.DDD
							, 
							D.TELEFONE
							, 
							D.FAX
							, 
							D.TELEX 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.GE_CLIENTES_MOVTO C
							, 
							SEGUROS.ENDERECOS D 
							WHERE A.SIT_REGISTRO IN ( '3'
							, '6' ) 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND B.ORIG_PRODU IN ( 'ESPEC'
							, 'ESPE1' ) 
							AND A.COD_CLIENTE = C.COD_CLIENTE 
							AND A.OCOREND = C.OCORR_ENDERECO 
							AND A.COD_CLIENTE = D.COD_CLIENTE 
							AND A.OCOREND = D.OCORR_ENDERECO 
							AND C.DATA_ULT_MANUTEN >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.COD_USUARIO <> 'VG9550B'";

                return query;
            }
            CENDSBG.GetQueryEvent += GetQuery_CENDSBG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-FETCH-SEGURVGA-SECTION */
        private void R0030_00_FETCH_SEGURVGA_SECTION()
        {
            /*" -412- MOVE '0030' TO WNR-EXEC-SQL. */
            _.Move("0030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -428- PERFORM R0030_00_FETCH_SEGURVGA_DB_FETCH_1 */

            R0030_00_FETCH_SEGURVGA_DB_FETCH_1();

            /*" -431- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -432- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -433- MOVE 'S' TO WFIM-ENTRADA */
                    _.Move("S", AREA_DE_WORK.WFIM_ENTRADA);

                    /*" -433- PERFORM R0030_00_FETCH_SEGURVGA_DB_CLOSE_1 */

                    R0030_00_FETCH_SEGURVGA_DB_CLOSE_1();

                    /*" -435- ELSE */
                }
                else
                {


                    /*" -436- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -437- END-IF */
                }


                /*" -437- END-IF. */
            }


        }

        [StopWatch]
        /*" R0030-00-FETCH-SEGURVGA-DB-FETCH-1 */
        public void R0030_00_FETCH_SEGURVGA_DB_FETCH_1()
        {
            /*" -428- EXEC SQL FETCH CCURSOR INTO :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-AGENCIADOR, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-COD-FONTE, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-DATA-INIVIGENCIA, :SEGURVGA-NATURALIDADE, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-TIPO-SEGURADO END-EXEC. */

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
                _.Move(CCURSOR.SEGURVGA_TIPO_SEGURADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO);
            }

        }

        [StopWatch]
        /*" R0030-00-FETCH-SEGURVGA-DB-CLOSE-1 */
        public void R0030_00_FETCH_SEGURVGA_DB_CLOSE_1()
        {
            /*" -433- EXEC SQL CLOSE CCURSOR END-EXEC */

            CCURSOR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0040-00-VERIFICA-APOLICE-SECTION */
        private void R0040_00_VERIFICA_APOLICE_SECTION()
        {
            /*" -449- MOVE '0040' TO WNR-EXEC-SQL. */
            _.Move("0040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -460- PERFORM R0040_00_VERIFICA_APOLICE_DB_SELECT_1 */

            R0040_00_VERIFICA_APOLICE_DB_SELECT_1();

            /*" -463- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -464- DISPLAY 'ERRO SELECT PARAMETROS_RAMOS' */
                _.Display($"ERRO SELECT PARAMETROS_RAMOS");

                /*" -465- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -465- END-IF. */
            }


        }

        [StopWatch]
        /*" R0040-00-VERIFICA-APOLICE-DB-SELECT-1 */
        public void R0040_00_VERIFICA_APOLICE_DB_SELECT_1()
        {
            /*" -460- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WHERE 1 = 1 END-EXEC. */

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
            /*" -476- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -478- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

            /*" -480- PERFORM R0060-00-CANCELA-SEGURO. */

            R0060_00_CANCELA_SEGURO_SECTION();

            /*" -480- PERFORM R0030-00-FETCH-SEGURVGA. */

            R0030_00_FETCH_SEGURVGA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-CANCELA-SEGURO-SECTION */
        private void R0060_00_CANCELA_SEGURO_SECTION()
        {
            /*" -491- MOVE 1 TO MOVIMVGA-PERI-PAGAMENTO */
            _.Move(1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -494- INITIALIZE V0COBA-IMPMORNATU , V0COBA-PRMVG */
            _.Initialize(
                V0COBA_IMPMORNATU
                , V0COBA_PRMVG
            );

            /*" -498- PERFORM R0077-CONS-MODALIDADE-APOL */

            R0077_CONS_MODALIDADE_APOL_SECTION();

            /*" -500- MOVE '6025' TO WNR-EXEC-SQL */
            _.Move("6025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -515- PERFORM R0060_00_CANCELA_SEGURO_DB_SELECT_1 */

            R0060_00_CANCELA_SEGURO_DB_SELECT_1();

            /*" -518- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -520- MOVE 0 TO V0COBA-IMPMORNATU V0COBA-PRMVG */
                _.Move(0, V0COBA_IMPMORNATU, V0COBA_PRMVG);

                /*" -522- END-IF */
            }


            /*" -524- MOVE '6030' TO WNR-EXEC-SQL. */
            _.Move("6030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -538- PERFORM R0060_00_CANCELA_SEGURO_DB_SELECT_2 */

            R0060_00_CANCELA_SEGURO_DB_SELECT_2();

            /*" -541- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -543- MOVE 0 TO V0COBA-IMPMORACID V0COBA-PRMAP */
                _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);

                /*" -545- END-IF */
            }


            /*" -547- MOVE '6035' TO WNR-EXEC-SQL */
            _.Move("6035", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -559- PERFORM R0060_00_CANCELA_SEGURO_DB_SELECT_3 */

            R0060_00_CANCELA_SEGURO_DB_SELECT_3();

            /*" -562- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -563- MOVE 0 TO V0COBA-IMPINVPERM */
                _.Move(0, V0COBA_IMPINVPERM);

                /*" -565- END-IF */
            }


            /*" -567- MOVE '6040' TO WNR-EXEC-SQL */
            _.Move("6040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -579- PERFORM R0060_00_CANCELA_SEGURO_DB_SELECT_4 */

            R0060_00_CANCELA_SEGURO_DB_SELECT_4();

            /*" -582- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -583- MOVE 0 TO V0COBA-IMPDIT */
                _.Move(0, V0COBA_IMPDIT);

                /*" -585- END-IF */
            }


            /*" -587- MOVE '6045' TO WNR-EXEC-SQL */
            _.Move("6045", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -596- PERFORM R0060_00_CANCELA_SEGURO_DB_SELECT_5 */

            R0060_00_CANCELA_SEGURO_DB_SELECT_5();

            /*" -599- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -600- MOVE ZEROS TO CONTACOR-COD-AGENCIA */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);

                /*" -601- MOVE ZEROS TO CONTACOR-NUM-CTA-CORRENTE */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);

                /*" -602- MOVE SPACES TO CONTACOR-DAC-CTA-CORRENTE */
                _.Move("", CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);

                /*" -604- END-IF */
            }


            /*" -605- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-MOVIMENTO MOVIMVGA-DATA-OPERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

            /*" -0- FLUXCONTROL_PERFORM R0060_10_CONTINUA */

            R0060_10_CONTINUA();

        }

        [StopWatch]
        /*" R0060-00-CANCELA-SEGURO-DB-SELECT-1 */
        public void R0060_00_CANCELA_SEGURO_DB_SELECT_1()
        {
            /*" -515- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (:PARAMRAM-NUM-RAMO-PRSTMISTA, :PARAMRAM-RAMO-VG) AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA AND COD_COBERTURA = 11 END-EXEC */

            var r0060_00_CANCELA_SEGURO_DB_SELECT_1_Query1 = new R0060_00_CANCELA_SEGURO_DB_SELECT_1_Query1()
            {
                PARAMRAM_NUM_RAMO_PRSTMISTA = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA.ToString(),
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                WS_V0APOL_MODALIDA = WS_V0APOL_MODALIDA.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_VG = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(),
            };

            var executed_1 = R0060_00_CANCELA_SEGURO_DB_SELECT_1_Query1.Execute(r0060_00_CANCELA_SEGURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, V0COBA_PRMVG);
            }


        }

        [StopWatch]
        /*" R0060-10-CONTINUA */
        private void R0060_10_CONTINUA(bool isPerform = false)
        {
            /*" -614- MOVE '6050' TO WNR-EXEC-SQL */
            _.Move("6050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -619- PERFORM R0060_10_CONTINUA_DB_SELECT_1 */

            R0060_10_CONTINUA_DB_SELECT_1();

            /*" -622- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -623- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -625- END-IF */
            }


            /*" -628- COMPUTE FONTES-ULT-PROP-AUTOMAT = FONTES-ULT-PROP-AUTOMAT + 1 */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -630- MOVE '6055' TO WNR-EXEC-SQL */
            _.Move("6055", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -635- PERFORM R0060_10_CONTINUA_DB_UPDATE_1 */

            R0060_10_CONTINUA_DB_UPDATE_1();

            /*" -638- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -639- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -643- END-IF */
            }


            /*" -645- MOVE '6090' TO WNR-EXEC-SQL. */
            _.Move("6090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -798- PERFORM R0060_10_CONTINUA_DB_INSERT_1 */

            R0060_10_CONTINUA_DB_INSERT_1();

            /*" -801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -802- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -803- GO TO R0060-10-CONTINUA */
                    new Task(() => R0060_10_CONTINUA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -804- ELSE */
                }
                else
                {


                    /*" -805- DISPLAY 'R0060-00 (ERRO - INSERT V0MOVIMENTO  )' */
                    _.Display($"R0060-00 (ERRO - INSERT V0MOVIMENTO  )");

                    /*" -808- DISPLAY 'CERTIF: ' SEGURVGA-NUM-CERTIFICADO ' ' 'FONTE:  ' SEGURVGA-COD-FONTE ' ' 'PROPOS: ' FONTES-ULT-PROP-AUTOMAT */

                    $"CERTIF: {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} FONTE:  {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE} PROPOS: {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}"
                    .Display();

                    /*" -809- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -810- END-IF */
                }


                /*" -812- END-IF. */
            }


            /*" -812- ADD 1 TO WACC-CANCELADOS. */
            AREA_DE_WORK.WACC_CANCELADOS.Value = AREA_DE_WORK.WACC_CANCELADOS + 1;

        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-SELECT-1 */
        public void R0060_10_CONTINUA_DB_SELECT_1()
        {
            /*" -619- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC */

            var r0060_10_CONTINUA_DB_SELECT_1_Query1 = new R0060_10_CONTINUA_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            var executed_1 = R0060_10_CONTINUA_DB_SELECT_1_Query1.Execute(r0060_10_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }

        [StopWatch]
        /*" R0060-10-CONTINUA-DB-UPDATE-1 */
        public void R0060_10_CONTINUA_DB_UPDATE_1()
        {
            /*" -635- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC */

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
            /*" -798- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES (:SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :FONTES-ULT-PROP-AUTOMAT, :SEGURVGA-TIPO-SEGURADO, :SEGURVGA-NUM-CERTIFICADO, ' ' , :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-COD-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :MOVIMVGA-PERI-PAGAMENTO, 12, ' ' , ' ' , ' ' , 0, :SEGURVGA-NATURALIDADE, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-OCORR-ENDERECO, 104, :CONTACOR-COD-AGENCIA, ' ' , :SEGURVGA-NUM-MATRICULA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, 401, :SISTEMAS-DATA-MOV-ABERTO, 0, '1' , 'VG9550B' , :MOVIMVGA-DATA-OPERACAO, NULL, NULL, NULL, NULL, :DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO, NULL, NULL) END-EXEC. */

            var r0060_10_CONTINUA_DB_INSERT_1_Insert1 = new R0060_10_CONTINUA_DB_INSERT_1_Insert1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_TIPO_SEGURADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO.ToString(),
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

            R0060_10_CONTINUA_DB_INSERT_1_Insert1.Execute(r0060_10_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0060-00-CANCELA-SEGURO-DB-SELECT-2 */
        public void R0060_00_CANCELA_SEGURO_DB_SELECT_2()
        {
            /*" -538- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA AND COD_COBERTURA = 1 END-EXEC */

            var r0060_00_CANCELA_SEGURO_DB_SELECT_2_Query1 = new R0060_00_CANCELA_SEGURO_DB_SELECT_2_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                WS_V0APOL_MODALIDA = WS_V0APOL_MODALIDA.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R0060_00_CANCELA_SEGURO_DB_SELECT_2_Query1.Execute(r0060_00_CANCELA_SEGURO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-CANCELA-SEGURO-DB-SELECT-3 */
        public void R0060_00_CANCELA_SEGURO_DB_SELECT_3()
        {
            /*" -559- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA AND COD_COBERTURA = 2 END-EXEC */

            var r0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1 = new R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                WS_V0APOL_MODALIDA = WS_V0APOL_MODALIDA.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1.Execute(r0060_00_CANCELA_SEGURO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }

        [StopWatch]
        /*" R0077-CONS-MODALIDADE-APOL-SECTION */
        private void R0077_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -823- MOVE '0077' TO WNR-EXEC-SQL */
            _.Move("0077", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -825- INITIALIZE REGISTRO-LINKAGE-GE0510S */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -826- MOVE SEGURVGA-NUM-APOLICE TO LK-GE510-NUM-APOLICE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -828- MOVE SEGURVGA-COD-SUBGRUPO TO LK-GE510-COD-SUBGRUPO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -830- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -831- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -832- MOVE LK-GE510-COD-MODALIDADE TO WS-V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, WS_V0APOL_MODALIDA);

                /*" -833- ELSE */
            }
            else
            {


                /*" -834- DISPLAY ' ' */
                _.Display($" ");

                /*" -835- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -836- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -837- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -838- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -839- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -840- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -841- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -842- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -843- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -844- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -845- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -846- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -847- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -847- END-IF. */
            }


        }

        [StopWatch]
        /*" R0060-00-CANCELA-SEGURO-DB-SELECT-4 */
        public void R0060_00_CANCELA_SEGURO_DB_SELECT_4()
        {
            /*" -579- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82, :PARAMRAM-RAMO-AP) AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA AND COD_COBERTURA = 5 END-EXEC */

            var r0060_00_CANCELA_SEGURO_DB_SELECT_4_Query1 = new R0060_00_CANCELA_SEGURO_DB_SELECT_4_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                WS_V0APOL_MODALIDA = WS_V0APOL_MODALIDA.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                PARAMRAM_RAMO_AP = PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(),
            };

            var executed_1 = R0060_00_CANCELA_SEGURO_DB_SELECT_4_Query1.Execute(r0060_00_CANCELA_SEGURO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0077_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-CANCELA-SEGURO-DB-SELECT-5 */
        public void R0060_00_CANCELA_SEGURO_DB_SELECT_5()
        {
            /*" -596- EXEC SQL SELECT COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :CONTACOR-COD-AGENCIA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE FROM SEGUROS.CONTA_CORRENTE WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO END-EXEC */

            var r0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1 = new R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1.Execute(r0060_00_CANCELA_SEGURO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_COD_AGENCIA, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);
                _.Move(executed_1.CONTACOR_NUM_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);
                _.Move(executed_1.CONTACOR_DAC_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


        }

        [StopWatch]
        /*" R1000-00-ALT-END-SEGURADOS-SECTION */
        private void R1000_00_ALT_END_SEGURADOS_SECTION()
        {
            /*" -857- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -859- MOVE 'N' TO WFIM-ENTRADA */
            _.Move("N", AREA_DE_WORK.WFIM_ENTRADA);

            /*" -890- PERFORM R1000_00_ALT_END_SEGURADOS_DB_DECLARE_1 */

            R1000_00_ALT_END_SEGURADOS_DB_DECLARE_1();

            /*" -892- PERFORM R1000_00_ALT_END_SEGURADOS_DB_OPEN_1 */

            R1000_00_ALT_END_SEGURADOS_DB_OPEN_1();

            /*" -896- PERFORM R1030-00-FETCH-ENDERECO */

            R1030_00_FETCH_ENDERECO_SECTION();

            /*" -899- PERFORM R1050-00-PROCESSA-ENDERECO UNTIL WFIM-ENTRADA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_ENTRADA == "S"))
            {

                R1050_00_PROCESSA_ENDERECO_SECTION();
            }

            /*" -900- DISPLAY ' ' */
            _.Display($" ");

            /*" -901- DISPLAY '*-----  VG9550B - ATUALIZA ENDERECO -----*' */
            _.Display($"*-----  VG9550B - ATUALIZA ENDERECO -----*");

            /*" -902- DISPLAY ' ' */
            _.Display($" ");

            /*" -903- DISPLAY 'TOTAL APOL/SUBG LIDOS     ... ' WS-CONT-APOL */
            _.Display($"TOTAL APOL/SUBG LIDOS     ... {AREA_DE_WORK.WS_CONT_APOL}");

            /*" -904- DISPLAY 'TOTAL APOL/SUBG ALTERADOS ... ' WS-CONT-UPDT-APOL */
            _.Display($"TOTAL APOL/SUBG ALTERADOS ... {AREA_DE_WORK.WS_CONT_UPDT_APOL}");

            /*" -905- DISPLAY 'TOTAL SEGURADOS LIDOS     ... ' WS-CONT-SEG */
            _.Display($"TOTAL SEGURADOS LIDOS     ... {AREA_DE_WORK.WS_CONT_SEG}");

            /*" -906- DISPLAY 'TOTAL SEGURADOS ALTERADOS ... ' WS-CONT-UPDT-SEG */
            _.Display($"TOTAL SEGURADOS ALTERADOS ... {AREA_DE_WORK.WS_CONT_UPDT_SEG}");

            /*" -907- DISPLAY ' ' */
            _.Display($" ");

            /*" -908- DISPLAY '*---------  VG9550B - FIM NORMAL --------*' */
            _.Display($"*---------  VG9550B - FIM NORMAL --------*");

            /*" -910- DISPLAY ' ' */
            _.Display($" ");

            /*" -910- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" R1000-00-ALT-END-SEGURADOS-DB-OPEN-1 */
        public void R1000_00_ALT_END_SEGURADOS_DB_OPEN_1()
        {
            /*" -892- EXEC SQL OPEN CENDSBG END-EXEC. */

            CENDSBG.Open();

        }

        [StopWatch]
        /*" R1050-00-PROCESSA-ENDERECO-DB-DECLARE-1 */
        public void R1050_00_PROCESSA_ENDERECO_DB_DECLARE_1()
        {
            /*" -970- EXEC SQL DECLARE CSEGURD CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, COD_CLIENTE, OCORR_ENDERECO, OCORR_END_COBRAN FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO WITH UR END-EXEC. */
            CSEGURD = new VG9550B_CSEGURD(true);
            string GetQuery_CSEGURD()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							COD_CLIENTE
							, 
							OCORR_ENDERECO
							, 
							OCORR_END_COBRAN 
							FROM SEGUROS.SEGURADOS_VGAP 
							WHERE NUM_APOLICE = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}'";

                return query;
            }
            CSEGURD.GetQueryEvent += GetQuery_CSEGURD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-FETCH-ENDERECO-SECTION */
        private void R1030_00_FETCH_ENDERECO_SECTION()
        {
            /*" -920- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -936- PERFORM R1030_00_FETCH_ENDERECO_DB_FETCH_1 */

            R1030_00_FETCH_ENDERECO_DB_FETCH_1();

            /*" -939- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -940- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -941- MOVE 'S' TO WFIM-ENTRADA */
                    _.Move("S", AREA_DE_WORK.WFIM_ENTRADA);

                    /*" -941- PERFORM R1030_00_FETCH_ENDERECO_DB_CLOSE_1 */

                    R1030_00_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -943- ELSE */
                }
                else
                {


                    /*" -944- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -945- END-IF */
                }


                /*" -946- ELSE */
            }
            else
            {


                /*" -947- ADD 1 TO WS-CONT-APOL */
                AREA_DE_WORK.WS_CONT_APOL.Value = AREA_DE_WORK.WS_CONT_APOL + 1;

                /*" -947- END-IF. */
            }


        }

        [StopWatch]
        /*" R1030-00-FETCH-ENDERECO-DB-FETCH-1 */
        public void R1030_00_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -936- EXEC SQL FETCH CENDSBG INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-CLIENTE , :PROPOVA-SIT-REGISTRO , :PROPOVA-OCOREND , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-TELEX END-EXEC. */

            if (CENDSBG.Fetch())
            {
                _.Move(CENDSBG.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CENDSBG.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CENDSBG.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CENDSBG.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CENDSBG.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CENDSBG.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(CENDSBG.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(CENDSBG.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(CENDSBG.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(CENDSBG.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(CENDSBG.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(CENDSBG.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(CENDSBG.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(CENDSBG.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(CENDSBG.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
            }

        }

        [StopWatch]
        /*" R1030-00-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R1030_00_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -941- EXEC SQL CLOSE CENDSBG END-EXEC */

            CENDSBG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-PROCESSA-ENDERECO-SECTION */
        private void R1050_00_PROCESSA_ENDERECO_SECTION()
        {
            /*" -957- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -959- MOVE 'N' TO WFIM-SEGURADO */
            _.Move("N", AREA_DE_WORK.WFIM_SEGURADO);

            /*" -970- PERFORM R1050_00_PROCESSA_ENDERECO_DB_DECLARE_1 */

            R1050_00_PROCESSA_ENDERECO_DB_DECLARE_1();

            /*" -972- PERFORM R1050_00_PROCESSA_ENDERECO_DB_OPEN_1 */

            R1050_00_PROCESSA_ENDERECO_DB_OPEN_1();

            /*" -976- PERFORM R2030-00-FETCH-SEGURADO */

            R2030_00_FETCH_SEGURADO_SECTION();

            /*" -979- PERFORM R2050-00-PROCESSA-SEGURADO UNTIL WFIM-SEGURADO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SEGURADO == "S"))
            {

                R2050_00_PROCESSA_SEGURADO_SECTION();
            }

            /*" -981- PERFORM R1060-00-UPDT-GE-CLIENTE-MOVTO. */

            R1060_00_UPDT_GE_CLIENTE_MOVTO();

            /*" -981- PERFORM R1030-00-FETCH-ENDERECO. */

            R1030_00_FETCH_ENDERECO_SECTION();

        }

        [StopWatch]
        /*" R1050-00-PROCESSA-ENDERECO-DB-OPEN-1 */
        public void R1050_00_PROCESSA_ENDERECO_DB_OPEN_1()
        {
            /*" -972- EXEC SQL OPEN CSEGURD END-EXEC. */

            CSEGURD.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-UPDT-GE-CLIENTE-MOVTO */
        private void R1060_00_UPDT_GE_CLIENTE_MOVTO(bool isPerform = false)
        {
            /*" -991- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -997- PERFORM R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1 */

            R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1();

            /*" -1000- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1004- DISPLAY 'R1060-00 (ERRO-UPDATE GE_CLIENTES_MOVTO )' ' CLIENTE ' PROPOVA-COD-CLIENTE ' OCOREND ' PROPOVA-OCOREND ' SQL ' SQLCODE */

                $"R1060-00 (ERRO-UPDATE GE_CLIENTES_MOVTO ) CLIENTE {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE} OCOREND {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND} SQL {DB.SQLCODE}"
                .Display();

                /*" -1005- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1006- ELSE */
            }
            else
            {


                /*" -1007- ADD 1 TO WS-CONT-UPDT-APOL */
                AREA_DE_WORK.WS_CONT_UPDT_APOL.Value = AREA_DE_WORK.WS_CONT_UPDT_APOL + 1;

                /*" -1007- END-IF. */
            }


        }

        [StopWatch]
        /*" R1060-00-UPDT-GE-CLIENTE-MOVTO-DB-UPDATE-1 */
        public void R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1()
        {
            /*" -997- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET COD_USUARIO = 'VG9550B' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1 = new R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1.Execute(r1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-FETCH-SEGURADO-SECTION */
        private void R2030_00_FETCH_SEGURADO_SECTION()
        {
            /*" -1018- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1025- PERFORM R2030_00_FETCH_SEGURADO_DB_FETCH_1 */

            R2030_00_FETCH_SEGURADO_DB_FETCH_1();

            /*" -1028- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1029- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1030- MOVE 'S' TO WFIM-SEGURADO */
                    _.Move("S", AREA_DE_WORK.WFIM_SEGURADO);

                    /*" -1030- PERFORM R2030_00_FETCH_SEGURADO_DB_CLOSE_1 */

                    R2030_00_FETCH_SEGURADO_DB_CLOSE_1();

                    /*" -1032- ELSE */
                }
                else
                {


                    /*" -1033- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1034- END-IF */
                }


                /*" -1035- ELSE */
            }
            else
            {


                /*" -1036- ADD 1 TO WS-CONT-SEG */
                AREA_DE_WORK.WS_CONT_SEG.Value = AREA_DE_WORK.WS_CONT_SEG + 1;

                /*" -1036- END-IF. */
            }


        }

        [StopWatch]
        /*" R2030-00-FETCH-SEGURADO-DB-FETCH-1 */
        public void R2030_00_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1025- EXEC SQL FETCH CSEGURD INTO :SEGURVGA-NUM-APOLICE , :SEGURVGA-COD-SUBGRUPO , :SEGURVGA-NUM-CERTIFICADO , :SEGURVGA-COD-CLIENTE , :SEGURVGA-OCORR-ENDERECO , :SEGURVGA-OCORR-END-COBRAN END-EXEC. */

            if (CSEGURD.Fetch())
            {
                _.Move(CSEGURD.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(CSEGURD.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(CSEGURD.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(CSEGURD.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(CSEGURD.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(CSEGURD.SEGURVGA_OCORR_END_COBRAN, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_END_COBRAN);
            }

        }

        [StopWatch]
        /*" R2030-00-FETCH-SEGURADO-DB-CLOSE-1 */
        public void R2030_00_FETCH_SEGURADO_DB_CLOSE_1()
        {
            /*" -1030- EXEC SQL CLOSE CSEGURD END-EXEC */

            CSEGURD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-PROCESSA-SEGURADO-SECTION */
        private void R2050_00_PROCESSA_SEGURADO_SECTION()
        {
            /*" -1047- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1049- PERFORM R2060-00-SELECT-MAX-OCOREND. */

            R2060_00_SELECT_MAX_OCOREND_SECTION();

            /*" -1051- PERFORM R2070-00-INSERT-ENDERECO-SEG. */

            R2070_00_INSERT_ENDERECO_SEG_SECTION();

            /*" -1053- PERFORM R2080-00-UPDATE-ENDERECO-SEG. */

            R2080_00_UPDATE_ENDERECO_SEG_SECTION();

            /*" -1053- PERFORM R2030-00-FETCH-SEGURADO. */

            R2030_00_FETCH_SEGURADO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2060-00-SELECT-MAX-OCOREND-SECTION */
        private void R2060_00_SELECT_MAX_OCOREND_SECTION()
        {
            /*" -1065- MOVE '2060' TO WNR-EXEC-SQL. */
            _.Move("2060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1071- PERFORM R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1 */

            R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1();

            /*" -1074- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1077- DISPLAY 'R2060-00 (ERRO-SELECT MAX OCORR ENDERECO )' ' CLIENTE ' SEGURVGA-COD-CLIENTE ' SQL ' SQLCODE */

                $"R2060-00 (ERRO-SELECT MAX OCORR ENDERECO ) CLIENTE {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE} SQL {DB.SQLCODE}"
                .Display();

                /*" -1078- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1079- ELSE */
            }
            else
            {


                /*" -1080- ADD 1 TO WS-MAX-OCOREND */
                WS_MAX_OCOREND.Value = WS_MAX_OCOREND + 1;

                /*" -1080- END-IF. */
            }


        }

        [StopWatch]
        /*" R2060-00-SELECT-MAX-OCOREND-DB-SELECT-1 */
        public void R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1()
        {
            /*" -1071- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO), 0) INTO :WS-MAX-OCOREND FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE WITH UR END-EXEC. */

            var r2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1 = new R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1.Execute(r2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCOREND, WS_MAX_OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_99_SAIDA*/

        [StopWatch]
        /*" R2070-00-INSERT-ENDERECO-SEG-SECTION */
        private void R2070_00_INSERT_ENDERECO_SEG_SECTION()
        {
            /*" -1091- MOVE '2070' TO WNR-EXEC-SQL. */
            _.Move("2070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1108- PERFORM R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1 */

            R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1();

            /*" -1111- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1115- DISPLAY 'R2070-00 (ERRO-INSERT ENDERECO )' ' CLIENTE ' SEGURVGA-COD-CLIENTE ' OCORR ' WS-MAX-OCOREND ' SQL ' SQLCODE */

                $"R2070-00 (ERRO-INSERT ENDERECO ) CLIENTE {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE} OCORR {WS_MAX_OCOREND} SQL {DB.SQLCODE}"
                .Display();

                /*" -1116- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1116- END-IF. */
            }


        }

        [StopWatch]
        /*" R2070-00-INSERT-ENDERECO-SEG-DB-INSERT-1 */
        public void R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1()
        {
            /*" -1108- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:SEGURVGA-COD-CLIENTE , 2 , :WS-MAX-OCOREND , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-TELEX , '0' , 0 , NULL) END-EXEC. */

            var r2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1 = new R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                WS_MAX_OCOREND = WS_MAX_OCOREND.ToString(),
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
                ENDERECO_CEP = ENDERECO.DCLENDERECOS.ENDERECO_CEP.ToString(),
                ENDERECO_DDD = ENDERECO.DCLENDERECOS.ENDERECO_DDD.ToString(),
                ENDERECO_TELEFONE = ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.ToString(),
                ENDERECO_FAX = ENDERECO.DCLENDERECOS.ENDERECO_FAX.ToString(),
                ENDERECO_TELEX = ENDERECO.DCLENDERECOS.ENDERECO_TELEX.ToString(),
            };

            R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1.Execute(r2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2070_99_SAIDA*/

        [StopWatch]
        /*" R2080-00-UPDATE-ENDERECO-SEG-SECTION */
        private void R2080_00_UPDATE_ENDERECO_SEG_SECTION()
        {
            /*" -1126- MOVE '2080' TO WNR-EXEC-SQL. */
            _.Move("2080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1131- PERFORM R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1 */

            R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1();

            /*" -1134- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1138- DISPLAY 'R2080-00 (ERRO-UPDATE SEGURADOS_VGAP )' ' CERTIF ' SEGURVGA-NUM-CERTIFICADO ' OCOREND ' WS-MAX-OCOREND ' SQL ' SQLCODE */

                $"R2080-00 (ERRO-UPDATE SEGURADOS_VGAP ) CERTIF {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} OCOREND {WS_MAX_OCOREND} SQL {DB.SQLCODE}"
                .Display();

                /*" -1139- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1141- END-IF. */
            }


            /*" -1141- ADD 1 TO WS-CONT-UPDT-SEG. */
            AREA_DE_WORK.WS_CONT_UPDT_SEG.Value = AREA_DE_WORK.WS_CONT_UPDT_SEG + 1;

        }

        [StopWatch]
        /*" R2080-00-UPDATE-ENDERECO-SEG-DB-UPDATE-1 */
        public void R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1()
        {
            /*" -1131- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET OCORR_ENDERECO = :WS-MAX-OCOREND , OCORR_END_COBRAN = :WS-MAX-OCOREND WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO END-EXEC. */

            var r2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1 = new R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1()
            {
                WS_MAX_OCOREND = WS_MAX_OCOREND.ToString(),
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1.Execute(r2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2080_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1154- DISPLAY ' ' */
            _.Display($" ");

            /*" -1155- DISPLAY '------- SEGUROS CANCELADOS  ----------' */
            _.Display($"------- SEGUROS CANCELADOS  ----------");

            /*" -1156- DISPLAY SEGURVGA-NUM-APOLICE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -1157- DISPLAY SEGURVGA-COD-SUBGRUPO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -1158- DISPLAY SEGURVGA-COD-FONTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);

            /*" -1159- DISPLAY FONTES-ULT-PROP-AUTOMAT */
            _.Display(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);

            /*" -1160- DISPLAY SEGURVGA-TIPO-SEGURADO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO);

            /*" -1161- DISPLAY SEGURVGA-NUM-CERTIFICADO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

            /*" -1162- DISPLAY SEGURVGA-COD-CLIENTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

            /*" -1163- DISPLAY MOVIMVGA-COD-AGENCIADOR */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -1164- DISPLAY MOVIMVGA-NUM-MATRICULA */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -1165- DISPLAY MOVIMVGA-VAL-SALARIO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -1166- DISPLAY MOVIMVGA-TIPO-SALARIO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -1167- DISPLAY MOVIMVGA-TIPO-PLANO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -1168- DISPLAY MOVIMVGA-QTD-SAL-MORNATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -1169- DISPLAY MOVIMVGA-TAXA-VG */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -1170- DISPLAY MOVIMVGA-IMP-MORNATU-ANT */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -1171- DISPLAY MOVIMVGA-IMP-MORNATU-ATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -1172- DISPLAY MOVIMVGA-PRM-VG-ANT */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -1173- DISPLAY MOVIMVGA-PRM-VG-ATU */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -1174- DISPLAY MOVIMVGA-COD-OPERACAO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -1176- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -1177- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -1178- DISPLAY CLIENTES-DATA-NASCIMENTO */
            _.Display(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -1179- DISPLAY FATURCON-DATA-REFERENCIA */
            _.Display(FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);

            /*" -1180- DISPLAY MOVIMVGA-DATA-AVERBACAO */
            _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -1181- DISPLAY SEGURVGA-DATA-INIVIGENCIA */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);

            /*" -1182- DISPLAY 'LIDOS  ' WACC-LIDOS */
            _.Display($"LIDOS  {AREA_DE_WORK.WACC_LIDOS}");

            /*" -1183- DISPLAY '  ' */
            _.Display($"  ");

            /*" -1184- DISPLAY '  ' */
            _.Display($"  ");

            /*" -1185- DISPLAY '------- PROPOSTAS_VA --------' */
            _.Display($"------- PROPOSTAS_VA --------");

            /*" -1186- DISPLAY PROPOVA-NUM-APOLICE */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);

            /*" -1187- DISPLAY PROPOVA-COD-SUBGRUPO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);

            /*" -1188- DISPLAY PROPOVA-NUM-CERTIFICADO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -1189- DISPLAY PROPOVA-COD-CLIENTE */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);

            /*" -1190- DISPLAY PROPOVA-SIT-REGISTRO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

            /*" -1191- DISPLAY PROPOVA-OCOREND */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);

            /*" -1192- DISPLAY ENDERECO-ENDERECO */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -1193- DISPLAY ENDERECO-BAIRRO */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -1194- DISPLAY ENDERECO-CIDADE */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -1195- DISPLAY ENDERECO-SIGLA-UF */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -1196- DISPLAY ENDERECO-CEP */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -1197- DISPLAY ENDERECO-DDD */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -1198- DISPLAY ENDERECO-TELEFONE */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -1199- DISPLAY ENDERECO-FAX */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_FAX);

            /*" -1200- DISPLAY ENDERECO-TELEX */
            _.Display(ENDERECO.DCLENDERECOS.ENDERECO_TELEX);

            /*" -1202- DISPLAY ' ' */
            _.Display($" ");

            /*" -1203- DISPLAY '------- SEGURADO ----------' */
            _.Display($"------- SEGURADO ----------");

            /*" -1204- DISPLAY SEGURVGA-NUM-APOLICE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -1205- DISPLAY SEGURVGA-COD-SUBGRUPO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -1206- DISPLAY SEGURVGA-NUM-CERTIFICADO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

            /*" -1207- DISPLAY SEGURVGA-COD-CLIENTE */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

            /*" -1208- DISPLAY SEGURVGA-OCORR-ENDERECO */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);

            /*" -1210- DISPLAY SEGURVGA-OCORR-END-COBRAN */
            _.Display(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_END_COBRAN);

            /*" -1212- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1214- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1214- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1216- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1221- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1221- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}