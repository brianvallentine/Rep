using Dapper;
using IA_ConverterCommons;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static Executor.Tester.Tests;
using static Executor.Tester.Tests.VG0020B_WS_AUXILIARES;
using static Executor.Tester.Tests.VG0020B_WS_AUXILIARES.VG0816B_WORK_TAB_RAMO_CONJ;
using _ = IA_ConverterCommons.Statements;

namespace Executor.Tester
{
    public class Tests
    {
        #region importedClasses

        #region testInfo
        public static VG0020B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VG0020B_WS_AUXILIARES();
        public class VG0020B_WS_AUXILIARES : VarBasis
        {
            public PROSOCU1_FILLER_1 FILLER_1 { get; set; } = new PROSOCU1_FILLER_1();
            public class PROSOCU1_FILLER_1 : VarBasis
            {
                /*"  03            WTB01-DIAS-JULIANO.*/
                public PROSOCU1_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PROSOCU1_WTB01_DIAS_JULIANO();
                public class PROSOCU1_WTB01_DIAS_JULIANO : VarBasis
                {
                    /*"    05          WTB1-1          PIC S9(003) COMP-3  VALUE  ZEROS*/
                    public IntBasis WTB1_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                    /*"    05          WTB1-2          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB1_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB1-3          PIC S9(003) COMP-3  VALUE +59.*/
                    public IntBasis WTB1_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                    /*"    05          WTB1-4          PIC S9(003) COMP-3  VALUE +90.*/
                    public IntBasis WTB1_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                    /*"    05          WTB1-5          PIC S9(003) COMP-3  VALUE +120.*/
                    public IntBasis WTB1_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                    /*"    05          WTB1-6          PIC S9(003) COMP-3  VALUE +151.*/
                    public IntBasis WTB1_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                    /*"    05          WTB1-7          PIC S9(003) COMP-3  VALUE +181.*/
                    public IntBasis WTB1_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                    /*"    05          WTB1-8          PIC S9(003) COMP-3  VALUE +212.*/
                    public IntBasis WTB1_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                    /*"    05          WTB1-9          PIC S9(003) COMP-3  VALUE +243.*/
                    public IntBasis WTB1_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                    /*"    05          WTB1-10         PIC S9(003) COMP-3  VALUE +273.*/
                    public IntBasis WTB1_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                    /*"    05          WTB1-11         PIC S9(003) COMP-3  VALUE +304.*/
                    public IntBasis WTB1_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                    /*"    05          WTB1-12         PIC S9(003) COMP-3  VALUE +334.*/
                    public IntBasis WTB1_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                    /*"  03            FILLER          REDEFINES                WTB01-DIAS-JULIANO.*/
                }
                private _REDEF_PROSOCU1_FILLER_2 _filler_2 { get; set; }
                public _REDEF_PROSOCU1_FILLER_2 FILLER_2
                {
                    get { _filler_2 = new _REDEF_PROSOCU1_FILLER_2(); _.Move(WTB01_DIAS_JULIANO, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_2, WTB01_DIAS_JULIANO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_JULIANO); }; return _filler_2; }
                    set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_JULIANO); }
                }  //Redefines
                public class _REDEF_PROSOCU1_FILLER_2 : VarBasis
                {
                    /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                    public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                    /*"  03            WTB02-DIAS-MES.*/

                    public _REDEF_PROSOCU1_FILLER_2()
                    {
                        WTB01.ValueChanged += OnValueChanged;
                    }

                }
                public PROSOCU1_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PROSOCU1_WTB02_DIAS_MES();
                public class PROSOCU1_WTB02_DIAS_MES : VarBasis
                {
                    /*"    05          WTB2-1          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB2-2          PIC S9(003) COMP-3  VALUE +28.*/
                    public IntBasis WTB2_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +28);
                    /*"    05          WTB2-3          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB2-4          PIC S9(003) COMP-3  VALUE +30.*/
                    public IntBasis WTB2_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                    /*"    05          WTB2-5          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB2-6          PIC S9(003) COMP-3  VALUE +30.*/
                    public IntBasis WTB2_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                    /*"    05          WTB2-7          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB2-8          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB2-9          PIC S9(003) COMP-3  VALUE +30.*/
                    public IntBasis WTB2_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                    /*"    05          WTB2-10         PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB2-11         PIC S9(003) COMP-3  VALUE +30.*/
                    public IntBasis WTB2_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                    /*"    05          WTB2-12         PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB2_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"  03            FILLER          REDEFINES                WTB02-DIAS-MES.*/
                }
                private _REDEF_PROSOCU1_FILLER_3 _filler_3 { get; set; }
                public _REDEF_PROSOCU1_FILLER_3 FILLER_3
                {
                    get { _filler_3 = new _REDEF_PROSOCU1_FILLER_3(); _.Move(WTB02_DIAS_MES, _filler_3); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_3, WTB02_DIAS_MES); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB02_DIAS_MES); }; return _filler_3; }
                    set { VarBasis.RedefinePassValue(value, _filler_3, WTB02_DIAS_MES); }
                }  //Redefines
                public class _REDEF_PROSOCU1_FILLER_3 : VarBasis
                {
                    /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                    public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                    /*"  03            WTB03-DIAS-JULIANO.*/

                    public _REDEF_PROSOCU1_FILLER_3()
                    {
                        WTB02.ValueChanged += OnValueChanged;
                    }

                }
                public PROSOCU1_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PROSOCU1_WTB03_DIAS_JULIANO();
                public class PROSOCU1_WTB03_DIAS_JULIANO : VarBasis
                {
                    /*"    05          WTB3-1          PIC S9(003) COMP-3  VALUE  ZEROS*/
                    public IntBasis WTB3_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                    /*"    05          WTB3-2          PIC S9(003) COMP-3  VALUE +31.*/
                    public IntBasis WTB3_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                    /*"    05          WTB3-3          PIC S9(003) COMP-3  VALUE +59.*/
                    public IntBasis WTB3_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                    /*"    05          WTB3-4          PIC S9(003) COMP-3  VALUE +90.*/
                    public IntBasis WTB3_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                    /*"    05          WTB3-5          PIC S9(003) COMP-3  VALUE +120.*/
                    public IntBasis WTB3_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                    /*"    05          WTB3-6          PIC S9(003) COMP-3  VALUE +151.*/
                    public IntBasis WTB3_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                    /*"    05          WTB3-7          PIC S9(003) COMP-3  VALUE +181.*/
                    public IntBasis WTB3_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                    /*"    05          WTB3-8          PIC S9(003) COMP-3  VALUE +212.*/
                    public IntBasis WTB3_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                    /*"    05          WTB3-9          PIC S9(003) COMP-3  VALUE +243.*/
                    public IntBasis WTB3_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                    /*"    05          WTB3-10         PIC S9(003) COMP-3  VALUE +273.*/
                    public IntBasis WTB3_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                    /*"    05          WTB3-11         PIC S9(003) COMP-3  VALUE +304.*/
                    public IntBasis WTB3_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                    /*"    05          WTB3-12         PIC S9(003) COMP-3  VALUE +334.*/
                    public IntBasis WTB3_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                    /*"  03            FILLER          REDEFINES                WTB03-DIAS-JULIANO.*/
                }
                private _REDEF_PROSOCU1_FILLER_4 _filler_4 { get; set; }
                public _REDEF_PROSOCU1_FILLER_4 FILLER_4
                {
                    get { _filler_4 = new _REDEF_PROSOCU1_FILLER_4(); _.Move(WTB03_DIAS_JULIANO, _filler_4); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_4, WTB03_DIAS_JULIANO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB03_DIAS_JULIANO); }; return _filler_4; }
                    set { VarBasis.RedefinePassValue(value, _filler_4, WTB03_DIAS_JULIANO); }
                }  //Redefines
                public class _REDEF_PROSOCU1_FILLER_4 : VarBasis
                {
                    /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                    public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                    /*"01              FILLER.*/

                    public _REDEF_PROSOCU1_FILLER_4()
                    {
                        WTB03.ValueChanged += OnValueChanged;
                    }

                }
            }

            public VG0816B_WORK_TAB_RAMO_CONJ WORK_TAB_RAMO_CONJ { get; set; } = new VG0816B_WORK_TAB_RAMO_CONJ();
            public class VG0816B_WORK_TAB_RAMO_CONJ : VarBasis
            {
                /*"    05  N5WORK-TAB-RAMO-CONJ    OCCURS 30 TIMES.*/
                public ListBasis<VG0816B_N5WORK_TAB_RAMO_CONJ> N5WORK_TAB_RAMO_CONJ { get; set; } = new ListBasis<VG0816B_N5WORK_TAB_RAMO_CONJ>(5);
                public class VG0816B_N5WORK_TAB_RAMO_CONJ : VarBasis
                {
                    /*"      10  TB-GRUPO-SUSEP              PIC S9(004) COMP.*/
                    public IntBasis TB_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "004", "S9(004)"));
                    /*"      10  TB-RAMO-CONJ                PIC S9(004) COMP.*/
                    public IntBasis TB_RAMO_CONJ { get; set; } = new IntBasis(new PIC("S9", "004", "S9(004)"));
                    /*"      10  TB-TAXA-RAMO-CONJ           PIC S9(003)V9(4) COMP-3.*/
                    public DoubleBasis TB_TAXA_RAMO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "003", "S9(003)V9(4)"), 4);
                    /*"01  WORK-RAMO-CONJ.*/
                }
            }
            /*"  03            WANO-BISSEXTO       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"  03            WS-IDADE            PIC S9(004)  COMP.*/
            public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "004", "S9(004)"));
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "009", "S9(009)"));
            /*"  03            AC-GRAVA            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "007", "9(007)"));
            /*"  03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "N");
            /*"  03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "N");
            /*"  03            WAPOLICE-ATU        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ATU { get; set; } = new IntBasis(new PIC("S9", "013", "S9(013)"));
            /*"  03            WAPOLICE-ANT        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "013", "S9(013)"));
            /*"  03            WTEM-MOVIMENTO      PIC  X(001) VALUE  'N'.*/
            public StringBasis WTEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "N");
            /*"  03            WTEM-OCORHIST       PIC  X(001) VALUE  'N'.*/
            public StringBasis WTEM_OCORHIST { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "N");
            /*"  03         WK-DATA1.*/
            public VG0020B_WK_DATA1 WK_DATA1 { get; set; } = new VG0020B_WK_DATA1();
            public class VG0020B_WK_DATA1 : VarBasis
            {
                /*"    05       WK-ANO1            PIC  9(004).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"    05       WK-MES1            PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"    05       WK-DIA1            PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"  03         WK-DATA2.*/
            }
            public VG0020B_WK_DATA2 WK_DATA2 { get; set; } = new VG0020B_WK_DATA2();
            public class VG0020B_WK_DATA2 : VarBasis
            {
                /*"    05       WK-ANO2            PIC  9(004).*/
                public IntBasis WK_ANO2 { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"    05       WK-MES2            PIC  9(002).*/
                public IntBasis WK_MES2 { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"    05       WK-DIA2            PIC  9(002).*/
                public IntBasis WK_DIA2 { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"  03            WS-W01DTTRAB.*/
            }
            public VG0020B_WS_W01DTTRAB WS_W01DTTRAB { get; set; } = new VG0020B_WS_W01DTTRAB();
            public class VG0020B_WS_W01DTTRAB : VarBasis
            {
                /*"    05          WS-W01AATRAB        PIC  9(004).*/
                public IntBasis WS_W01AATRAB { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"    05          WS-W01T1TRAB        PIC  X(001).*/
                public StringBasis WS_W01T1TRAB { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"    05          WS-W01MMTRAB        PIC  9(002).*/
                public IntBasis WS_W01MMTRAB { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05          WS-W01T2TRAB        PIC  X(001).*/
                public StringBasis WS_W01T2TRAB { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"    05          WS-W01DDTRAB        PIC  9(002).*/
                public IntBasis WS_W01DDTRAB { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"  03            WHORA-OPERACAO-WORK.*/
            }
            public VG0020B_WHORA_OPERACAO_WORK WHORA_OPERACAO_WORK { get; set; } = new VG0020B_WHORA_OPERACAO_WORK();
            public class VG0020B_WHORA_OPERACAO_WORK : VarBasis
            {
                /*"    05          WHORA-HORA          PIC  X(002).*/
                public StringBasis WHORA_HORA { get; set; } = new StringBasis(new PIC("X", "002", "X(002)."), "");
                /*"    05          FILLER              PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), ".");
                /*"    05          WHORA-MINU          PIC  X(002).*/
                public StringBasis WHORA_MINU { get; set; } = new StringBasis(new PIC("X", "002", "X(002)."), "");
                /*"    05          FILLER              PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), ".");
                /*"    05          WHORA-SEGU          PIC  X(002).*/
                public StringBasis WHORA_SEGU { get; set; } = new StringBasis(new PIC("X", "002", "X(002)."), "");
                /*"  03            WHORA-OPERACAO-WORK-R    REDEFINES                WHORA-OPERACAO-WORK      PIC  X(008).*/
            }
            private StringBasis _whora_operacao_work_r { get; set; }
            public StringBasis WHORA_OPERACAO_WORK_R
            {
                get { _whora_operacao_work_r = new StringBasis(new PIC("X", "008", "X(008).")); ; _.Move(WHORA_OPERACAO_WORK, _whora_operacao_work_r); VarBasis.RedefinePassValue(WHORA_OPERACAO_WORK, _whora_operacao_work_r, WHORA_OPERACAO_WORK); _whora_operacao_work_r.ValueChanged += () => { _.Move(_whora_operacao_work_r, WHORA_OPERACAO_WORK); }; return _whora_operacao_work_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_work_r, WHORA_OPERACAO_WORK); }
            }  //Redefines
            /*"  03            WS-W01DTSQL.*/
            public VG0020B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0020B_WS_W01DTSQL();
            public class VG0020B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01AASQL         PIC  9(004).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"    05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"  03            WHORA-OPERACAO.*/
            }
            public VG0020B_WHORA_OPERACAO WHORA_OPERACAO { get; set; } = new VG0020B_WHORA_OPERACAO();
            public class VG0020B_WHORA_OPERACAO : VarBasis
            {
                /*"    05          WHORA-HORA-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_HORA_W { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
                /*"    05          WHORA-MINU-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_MINU_W { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
                /*"    05          WHORA-SEGU-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_SEGU_W { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
                /*"  03            WHORA-OPERACAO-R    REDEFINES                WHORA-OPERACAO      PIC  9(006).*/
            }
            public IntBasis _whora_operacao_r { get; set; }
            public IntBasis WHORA_OPERACAO_R
            {
                get { _whora_operacao_r = new IntBasis(new PIC("9", "006", "9(006).")); ; _.Move(WHORA_OPERACAO, _whora_operacao_r); VarBasis.RedefinePassValue(WHORA_OPERACAO, _whora_operacao_r, WHORA_OPERACAO); _whora_operacao_r.ValueChanged += () => { _.Move(_whora_operacao_r, WHORA_OPERACAO); }; return _whora_operacao_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_r, WHORA_OPERACAO); }
            }  //Redefines
            /*"  03            WHORA-OPERACAO-1    PIC 9(08).*/
            public IntBasis WHORA_OPERACAO_1 { get; set; } = new IntBasis(new PIC("9", "08", "9(08)."));
            /*"  03            WHORA-PER-X REDEFINES WHORA-OPERACAO-1.*/
            private _REDEF_VG0020B_WHORA_PER_X _whora_per_x { get; set; }
            public _REDEF_VG0020B_WHORA_PER_X WHORA_PER_X
            {
                get { _whora_per_x = new _REDEF_VG0020B_WHORA_PER_X(); _.Move(WHORA_OPERACAO_1, _whora_per_x); VarBasis.RedefinePassValue(WHORA_OPERACAO_1, _whora_per_x, WHORA_OPERACAO_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, WHORA_OPERACAO_1); }; return _whora_per_x; }
                set { VarBasis.RedefinePassValue(value, _whora_per_x, WHORA_OPERACAO_1); }
            }  //Redefines
            public class _REDEF_VG0020B_WHORA_PER_X : VarBasis
            {
                /*"         10  WHORA-OPERACAO-2       PIC 9(06).*/
                public IntBasis WHORA_OPERACAO_2 { get; set; } = new IntBasis(new PIC("9", "06", "9(06)."));
                /*"         10  FILLER                 PIC 9(02).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "02", "9(02)."));
                /*"  03            WPRMTOT             PIC S9(013)V99                                        VALUE +0 COMP-3.*/

                public _REDEF_VG0020B_WHORA_PER_X()
                {
                    WHORA_OPERACAO_2.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "013", "S9(013)V99"), 2);
            /*"  03        WABEND.*/
            public VG0020B_WABEND WABEND { get; set; } = new VG0020B_WABEND();
            public class VG0020B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VG0020B'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "010", "X(010)"), " VG0020B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "028", "X(028)"), " *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "003", "X(003)"), "000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "017", "X(017)"), " *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "030", "X(030)"), "");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "014", "X(014)"), "    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "ZZZZZZ999-", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "014", "X(014)"), "    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "ZZZZZZ999-", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "014", "X(014)"), "    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "ZZZZZZ999-", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }

        #endregion

        #region testInfo

        public static CB0111B_DETALHE_REGISTRO DETALHE_REGISTRO { get; set; } = new CB0111B_DETALHE_REGISTRO();
        public class CB0111B_DETALHE_REGISTRO : VarBasis
        {
            /*"  05      DETALHE-TIPO-REGISTRO   PIC  9(003).*/
            public IntBasis DETALHE_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "003", "9(003)."));
            /*"  05      DETALHE-NUM-CERTIFICADO PIC  9(015).*/
            public IntBasis DETALHE_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "015", "9(015)."));
            /*"  05      DETALHE-NUM-TITULO      PIC  9(013).*/
            public IntBasis DETALHE_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "013", "9(013)."));
            /*"  05      DETALHE-DATA-TRANSACAO.*/
            public CB0111B_DETALHE_DATA_TRANSACAO DETALHE_DATA_TRANSACAO { get; set; } = new CB0111B_DETALHE_DATA_TRANSACAO();
            public class CB0111B_DETALHE_DATA_TRANSACAO : VarBasis
            {
                /*"    10    DETALHE-ANO             PIC  9(004).*/
                public IntBasis DETALHE_ANO { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"    10    DETALHE-MES             PIC  9(002).*/
                public IntBasis DETALHE_MES { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    10    DETALHE-DIA             PIC  9(002).*/
                public IntBasis DETALHE_DIA { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"  05      DETALHE-VLR-TRANSACAO   PIC  9(013)V99.*/
            }
            public DoubleBasis DETALHE_VLR_TRANSACAO { get; set; } = new DoubleBasis(new PIC("9", "013", "9(013)V99."), 2);
            /*"  05      DETALHE-COD-TRANSACAO   PIC  9(003).*/
            public IntBasis DETALHE_COD_TRANSACAO { get; set; } = new IntBasis(new PIC("9", "003", "9(003)."));
            /*"  05      DETALHE-QTD-PARCELA     PIC  9(003).*/
            public IntBasis DETALHE_QTD_PARCELA { get; set; } = new IntBasis(new PIC("9", "003", "9(003)."));
            /*"  05      DETALHE-NUM-PARCELA     PIC  9(003).*/
            public IntBasis DETALHE_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "003", "9(003)."));
            /*"  05      DETALHE-TIPO-LANCAMEN   PIC  9(004).*/
            public IntBasis DETALHE_TIPO_LANCAMEN { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
            /*"  05      FILLER                  PIC  9(004).*/
            public IntBasis FILLER_55 { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
            /*"  05      DETALHE-REFERENCIA      PIC  9(009).*/
            public IntBasis DETALHE_REFERENCIA { get; set; } = new IntBasis(new PIC("9", "009", "9(009)."));
            /*"  05      FILLER                  PIC  X(040).*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "040", "X(040)."), "");
            /*"01        TRAILER-REGISTRO.*/
        }
        public static CB0111B_SU1_DATA2 SU1_DATA2 { get; set; } = new CB0111B_SU1_DATA2();
        public class CB0111B_SU1_DATA2 : VarBasis
        {
            /*"       15 SU1-DD2               PIC  99.*/
            public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "99", "99."));
            /*"       15 SU1-MM2               PIC  99.*/
            public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "99", "99."));
            /*"       15 SU1-AA2               PIC  9999.*/
            public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "9999", "9999."));
            /*"01            AUX-RELATORIO.*/
        }
        #endregion

        #region testInfo
        public static VG0020B_WS_AUXILIARES1 WS_AUXILIARES_1 { get; set; } = new VG0020B_WS_AUXILIARES1();
        public class VG0020B_WS_AUXILIARES1 : VarBasis
        {
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "010", "X(010)."), "");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0619B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0619B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0619B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0619B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_PF0619B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }
            }

            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "008", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0619B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0619B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0619B_FILLER_2(); _.Move(W_DATA_TRABALHO, _filler_2); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_2, W_DATA_TRABALHO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_TRABALHO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0619B_FILLER_2()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
        }
        #endregion

        #region testArea
        public static VA0469B_WORK_AREA WORK_AREA { get; set; } = new VA0469B_WORK_AREA();
        public class VA0469B_WORK_AREA : VarBasis
        {
            /*"    05      WS-OPC-PAGTO        PIC  X(001) VALUE 'S'.*/
            public StringBasis WS_OPC_PAGTO { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "S");
            /*"    05      WULTDIA             PIC  9(002) VALUE ZEROES.*/
            public IntBasis WULTDIA { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
            /*"    05      WDIAS-AUX           PIC  9(004) VALUE ZEROES.*/
            public IntBasis WDIAS_AUX { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"    05      WINI-MES            PIC  9(002) VALUE ZEROES.*/
            public IntBasis WINI_MES { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
            /*"    05      WDATA-INI.*/
            public VA0469B_WDATA_INI WDATA_INI { get; set; } = new VA0469B_WDATA_INI();
            public class VA0469B_WDATA_INI : VarBasis
            {
                /*"      10    WANO-INI            PIC  9(004) VALUE ZEROES.*/
                public IntBasis WANO_INI { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
                /*"      10    FILLER              PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"      10    WMES-INI            PIC  9(002) VALUE ZEROES.*/
                public IntBasis WMES_INI { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
                /*"      10    FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"      10    WDIA-INI            PIC  9(002) VALUE ZEROES.*/
                public IntBasis WDIA_INI { get; set; } = new IntBasis(new PIC("9", "002", "9(002)"));
                /*"    05      IND1                PIC  9(003) VALUE ZEROS.*/
            }
            public IntBasis IND1 { get; set; } = new IntBasis(new PIC("9", "003", "9(003)"));
            /*"    05      IND2                PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND2 { get; set; } = new IntBasis(new PIC("9", "003", "9(003)"));
            /*"    05      IND4                PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND4 { get; set; } = new IntBasis(new PIC("9", "003", "9(003)"));
            /*"    05      MOEDA               PIC  9(003) VALUE ZEROS.*/
            public IntBasis MOEDA { get; set; } = new IntBasis(new PIC("9", "003", "9(003)"));
            /*"    05      AA-ATU              PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_ATU { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"    05      AA-INI              PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_INI { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"    05      MM-INI              PIC  9(004) VALUE ZEROS.*/
            public IntBasis MM_INI { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"    05      AA-MOE              PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_MOE { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"    05      WS-IGPM-ACUM        PIC S9(6)V9(9) VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WS_IGPM_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"    05      WMOEDA-ANT          PIC  9(004) VALUE ZEROS.*/
            public IntBasis WMOEDA_ANT { get; set; } = new IntBasis(new PIC("9", "004", "9(004)"));
            /*"    05      WVAL-VENDA          PIC S9(006)V9(09) COMP-3.*/
            public DoubleBasis WVAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "006", "S9(006)V9(09)"), 9);
            /*"    05      WPRM-TOTAL          PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WPRM-VG             PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WPRM-AP             PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WJUROS              PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      APOLICE-ATU         PIC  9(15) VALUE ZEROES.*/
            public IntBasis APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05      SUBGRUPO-ATU        PIC  9(04) VALUE ZEROES.*/
            public IntBasis SUBGRUPO_ATU { get; set; } = new IntBasis(new PIC("9", "04", "9(04)"));
            /*"    05      APOLICE-ANT         PIC  9(15) VALUE ZEROES.*/
            public IntBasis APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05      SUBGRUPO-ANT        PIC  9(04) VALUE ZEROES.*/
            public IntBasis SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "04", "9(04)"));
            /*"    05      WS-RETORNO-SAP      PIC  X(01) VALUE SPACE.*/

            public SelectorBasis WS_RETORNO_SAP { get; set; } = new SelectorBasis("01", "SPACE")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88   WS-SIM-RETORNOU-SAP            VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_RETORNOU_SAP", "S"),
							/*" 88   WS-NAO-RETORNOU-SAP            VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_RETORNOU_SAP", "N")
                }
            };

            /*"    05      W04DTSQL.*/
            public VA0469B_W04DTSQL W04DTSQL { get; set; } = new VA0469B_W04DTSQL();
            public class VA0469B_W04DTSQL : VarBasis
            {
                /*"      10    W04AASQL            PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"      10    W04T1SQL            PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"      10    W04MMSQL            PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"      10    W04T2SQL            PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "001", "X(001)."), "");
                /*"      10    W04DDSQL            PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05      WS-DATA-AUX         PIC X(010).*/
            }
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "010", "X(010)."), "");
            /*"    05      PARM-PROSOMU1.*/
            public VA0469B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0469B_PARM_PROSOMU1();
            public class VA0469B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10    SU1-DATA1.*/
                public VA0469B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0469B_SU1_DATA1();
                public class VA0469B_SU1_DATA1 : VarBasis
                {
                    /*"        15  SU1-DD1             PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "99", "99."));
                    /*"        15  SU1-MM1             PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "99", "99."));
                    /*"        15  SU1-AA1             PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "9999", "9999."));
                    /*"      10    SU1-NRDIAS          PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      10    SU1-DATA2.*/
                public VA0469B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0469B_SU1_DATA2();
                public class VA0469B_SU1_DATA2 : VarBasis
                {
                    /*"        15  SU1-DD2             PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "99", "99."));
                    /*"        15  SU1-MM2             PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "99", "99."));
                    /*"        15  SU1-AA2             PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "9999", "9999."));
                    /*"    05      DATA-SQL.*/
                }
            }
            public VA0469B_DATA_SQL DATA_SQL { get; set; } = new VA0469B_DATA_SQL();
            public class VA0469B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05      WS-DT8-AMD.*/
            }
            public VA0469B_WS_DT8_AMD WS_DT8_AMD { get; set; } = new VA0469B_WS_DT8_AMD();
            public class VA0469B_WS_DT8_AMD : VarBasis
            {
                /*"      10    WS-ANO-AMD             PIC  9(004).*/
                public IntBasis WS_ANO_AMD { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"      10    WS-MES-AMD             PIC  9(002).*/
                public IntBasis WS_MES_AMD { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"      10    WS-DIA-AMD             PIC  9(002).*/
                public IntBasis WS_DIA_AMD { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05      DATA-INI.*/
            }
            public VA0469B_DATA_INI DATA_INI { get; set; } = new VA0469B_DATA_INI();
            public class VA0469B_DATA_INI : VarBasis
            {
                /*"      10    ANO-INI             PIC  9(004).*/
                public IntBasis ANO_INI { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    MES-INI             PIC  9(002).*/
                public IntBasis MES_INI { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    DIA-INI             PIC  9(002).*/
                public IntBasis DIA_INI { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05      DATA-INI-R  REDEFINES DATA-INI.*/
            }
            private _REDEF_VA0469B_DATA_INI_R _data_ini_r { get; set; }
            public _REDEF_VA0469B_DATA_INI_R DATA_INI_R
            {
                get { _data_ini_r = new _REDEF_VA0469B_DATA_INI_R(); _.Move(DATA_INI, _data_ini_r); VarBasis.RedefinePassValue(DATA_INI, _data_ini_r, DATA_INI); _data_ini_r.ValueChanged += () => { _.Move(_data_ini_r, DATA_INI); }; return _data_ini_r; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r, DATA_INI); }
            }  //Redefines
            public class _REDEF_VA0469B_DATA_INI_R : VarBasis
            {
                /*"      10    AAMM-INI            PIC  X(007).*/
                public StringBasis AAMM_INI { get; set; } = new StringBasis(new PIC("X", "007", "X(007)."), "");
                /*"      10    REST-INI            PIC  X(003).*/
                public StringBasis REST_INI { get; set; } = new StringBasis(new PIC("X", "003", "X(003)."), "");
                /*"    05      DATA-INI-DEC.*/

                public _REDEF_VA0469B_DATA_INI_R()
                {
                    AAMM_INI.ValueChanged += OnValueChanged;
                    REST_INI.ValueChanged += OnValueChanged;
                }

            }
            public VA0469B_DATA_INI_DEC DATA_INI_DEC { get; set; } = new VA0469B_DATA_INI_DEC();
            public class VA0469B_DATA_INI_DEC : VarBasis
            {
                /*"      10    ANO-INI-DEC         PIC  9(004).*/
                public IntBasis ANO_INI_DEC { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    MES-INI-DEC         PIC  9(002).*/
                public IntBasis MES_INI_DEC { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    DIA-INI-DEC         PIC  9(002).*/
                public IntBasis DIA_INI_DEC { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05      DATA-INI-R  REDEFINES DATA-INI-DEC.*/
            }
            private _REDEF_VA0469B_DATA_INI_R_0 _data_ini_r_0 { get; set; }
            public _REDEF_VA0469B_DATA_INI_R_0 DATA_INI_R_0
            {
                get { _data_ini_r_0 = new _REDEF_VA0469B_DATA_INI_R_0(); _.Move(DATA_INI_DEC, _data_ini_r_0); VarBasis.RedefinePassValue(DATA_INI_DEC, _data_ini_r_0, DATA_INI_DEC); _data_ini_r_0.ValueChanged += () => { _.Move(_data_ini_r_0, DATA_INI_DEC); }; return _data_ini_r_0; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r_0, DATA_INI_DEC); }
            }  //Redefines
            public class _REDEF_VA0469B_DATA_INI_R_0 : VarBasis
            {
                /*"      10    AAMM-INI-DEC        PIC  X(007).*/
                public StringBasis AAMM_INI_DEC { get; set; } = new StringBasis(new PIC("X", "007", "X(007)."), "");
                /*"      10    REST-INI-DEC        PIC  X(003).*/
                public StringBasis REST_INI_DEC { get; set; } = new StringBasis(new PIC("X", "003", "X(003)."), "");
                /*"    05      DATA-FIM.*/

                public _REDEF_VA0469B_DATA_INI_R_0()
                {
                    AAMM_INI_DEC.ValueChanged += OnValueChanged;
                    REST_INI_DEC.ValueChanged += OnValueChanged;
                }

            }
            public VA0469B_DATA_FIM DATA_FIM { get; set; } = new VA0469B_DATA_FIM();
            public class VA0469B_DATA_FIM : VarBasis
            {
                /*"      10    ANO-FIM             PIC  9(004).*/
                public IntBasis ANO_FIM { get; set; } = new IntBasis(new PIC("9", "004", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    MES-FIM             PIC  9(002).*/
                public IntBasis MES_FIM { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "-");
                /*"      10    DIA-FIM             PIC  9(002).*/
                public IntBasis DIA_FIM { get; set; } = new IntBasis(new PIC("9", "002", "9(002)."));
                /*"    05      DATA-FIM-R  REDEFINES DATA-FIM.*/
            }
            private _REDEF_VA0469B_DATA_FIM_R _data_fim_r { get; set; }
            public _REDEF_VA0469B_DATA_FIM_R DATA_FIM_R
            {
                get { _data_fim_r = new _REDEF_VA0469B_DATA_FIM_R(); _.Move(DATA_FIM, _data_fim_r); VarBasis.RedefinePassValue(DATA_FIM, _data_fim_r, DATA_FIM); _data_fim_r.ValueChanged += () => { _.Move(_data_fim_r, DATA_FIM); }; return _data_fim_r; }
                set { VarBasis.RedefinePassValue(value, _data_fim_r, DATA_FIM); }
            }  //Redefines
            public class _REDEF_VA0469B_DATA_FIM_R : VarBasis
            {
                /*"      10    AAMM-FIM            PIC  X(007).*/
                public StringBasis AAMM_FIM { get; set; } = new StringBasis(new PIC("X", "007", "X(007)."), "");
                /*"      10    REST-FIM            PIC  X(003).*/
                public StringBasis REST_FIM { get; set; } = new StringBasis(new PIC("X", "003", "X(003)."), "");
                /*"    05      WFIM-RELATORIOS     PIC  X(001)  VALUE  ' '.*/

                public _REDEF_VA0469B_DATA_FIM_R()
                {
                    AAMM_FIM.ValueChanged += OnValueChanged;
                    REST_FIM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), " ");
            /*"    05      WFIM-SISTEMAS       PIC  X(001)  VALUE  ' '.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), " ");
            /*"    05      WFIM-MOEDACOT       PIC  X(001)  VALUE  ' '.*/
            public StringBasis WFIM_MOEDACOT { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), " ");
            /*"    05      WTEM-ALCADA         PIC  X(001)  VALUE  'N'.*/
            public StringBasis WTEM_ALCADA { get; set; } = new StringBasis(new PIC("X", "001", "X(001)"), "N");
            /*"01          ACUMULADORES.*/
        }

        public static COBHISVIS COBHISVI { get; set; } = new COBHISVIS();
        public class COBHISVIS : VarBasis
        {
            /*"01  DCLCOBER-HIST-VIDAZUL.*/
            public COBHISVI_DCLCOBER_HIST_VIDAZUL DCLCOBER_HIST_VIDAZUL { get; set; } = new COBHISVI_DCLCOBER_HIST_VIDAZUL();
            public class COBHISVI_DCLCOBER_HIST_VIDAZUL : VarBasis
            {
                /*"    10 COBHISVI-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
                public DoubleBasis COBHISVI_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
                /*"    10 COBHISVI-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
                public IntBasis COBHISVI_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"    10 COBHISVI-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
                public DoubleBasis COBHISVI_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
                /*"    10 COBHISVI-DATA-VENCIMENTO  PIC X(10).*/
                public StringBasis COBHISVI_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), "");
                /*"    10 COBHISVI-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
                public DoubleBasis COBHISVI_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"    10 COBHISVI-OPCAO-PAGAMENTO  PIC X(1).*/
                public StringBasis COBHISVI_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), "");
                /*"    10 COBHISVI-SIT-REGISTRO  PIC X(1).*/
                public StringBasis COBHISVI_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), "");
                /*"    10 COBHISVI-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
                public IntBasis COBHISVI_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"    10 COBHISVI-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
                public IntBasis COBHISVI_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"    10 COBHISVI-COD-DEVOLUCAO  PIC S9(4) USAGE COMP.*/
                public IntBasis COBHISVI_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"    10 COBHISVI-BCO-AVISO   PIC S9(4) USAGE COMP.*/
                public IntBasis COBHISVI_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"    10 COBHISVI-AGE-AVISO   PIC S9(4) USAGE COMP.*/
                public IntBasis COBHISVI_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"    10 COBHISVI-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
                public IntBasis COBHISVI_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                /*"    10 COBHISVI-NUM-TITULO-COMP  PIC S9(13)V USAGE COMP-3.*/
                public DoubleBasis COBHISVI_NUM_TITULO_COMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
                /*"*/
            }

        }
        #endregion

        #endregion

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(-4)]
        [InlineData(1234)]
        [InlineData(-123)]
        [InlineData(-123.12)]
        [InlineData(-123.23)]
        [InlineData(0123.23)]
        [InlineData(1231.23)]
        [InlineData(0.01)]
        [InlineData(0.11)]
        [InlineData(0.10)]
        [InlineData(0.15)]
        [InlineData(1.15)]
        [InlineData(-000.01)]
        [InlineData(9999.99)]
        [InlineData(-999.99)]
        public static void Teste_Move_Dot(double value)
        {
            var picS9_4 = new DoubleBasis(new PIC("S9", "4", "S9(4)V99"), 2);

            _.Move(value, picS9_4);
            Assert.True(picS9_4 == value);
        }

        [Theory]
        [InlineData("STRING TESTE 1 ")] // teste com 15
        [InlineData("STRING")] // teste com menos que 15
        public static void Teste_Move_Str(string value)
        {
            var picX15 = new StringBasis(new PIC("X", "15", "X(15)"));

            _.Move(value, picX15);
            Assert.True(picX15 == value);
        }

        [Fact]
        public static void Teste_MoveRedefines()
        {
            //var currTime = "12131415";
            var currTime = _.AcceptDate("TIME");

            /*" -1660- ACCEPT WHORA-OPERACAO-1 FROM TIME */
            _.Move(currTime, WS_AUXILIARES.WHORA_OPERACAO_1);
            Assert.True(currTime == WS_AUXILIARES.WHORA_OPERACAO_1.ToString());

            /*" -1661- MOVE WHORA-OPERACAO-2 TO WHORA-OPERACAO-R */
            _.Move(WS_AUXILIARES.WHORA_PER_X.WHORA_OPERACAO_2, WS_AUXILIARES.WHORA_OPERACAO_R);
            var a = WS_AUXILIARES._whora_operacao_r;
            Assert.True(currTime.Substring(0, 6) == WS_AUXILIARES.WHORA_OPERACAO_R.ToString());

            /*" -1662- MOVE WHORA-HORA-W TO WHORA-HORA */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_HORA_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_HORA);
            Assert.True(currTime.Substring(0, 2) == WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_HORA.ToString());

            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_MINU_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_MINU);
            Assert.True(currTime.Substring(2, 2) == WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_MINU.ToString());

            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_SEGU_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_SEGU);
            Assert.True(currTime.Substring(4, 2) == WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_SEGU.ToString());

            Assert.True($"{currTime.Substring(0, 2)}.{currTime.Substring(2, 2)}.{currTime.Substring(4, 2)}" == WS_AUXILIARES.WHORA_OPERACAO_WORK.GetMoveValues());


            var compare = new DateTime(2020, 01, 01);
            _.Move(compare.ToString("yyyy-MM-dd"), WS_AUXILIARES_1.W_DTMOVABE1);
            Assert.True(compare.ToString("yyyy-MM-dd") == WS_AUXILIARES_1.W_DTMOVABE1.GetMoveValues());

            /*" -1200- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move("01", WS_AUXILIARES_1.FILLER_2.W_DIA_TRABALHO);
            Assert.True(WS_AUXILIARES_1.FILLER_2.W_DIA_TRABALHO.GetMoveValues() == "01");

            /*" -1201- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WS_AUXILIARES_1.W_DTMOVABE1.W_MES_MOVABE, WS_AUXILIARES_1.FILLER_2.W_MES_TRABALHO);

            /*" -1203- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WS_AUXILIARES_1.W_DTMOVABE1.W_ANO_MOVABE, WS_AUXILIARES_1.FILLER_2.W_ANO_TRABALHO);

            Assert.True(WS_AUXILIARES_1.W_DATA_TRABALHO == compare.ToString("ddMMyyyy"));
        }

        [Fact]
        public static void Teste_MoveList()
        {
            var compare = "123456789876543";
            _.Move(compare, WS_AUXILIARES.WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[1]);
            Assert.True(compare == WS_AUXILIARES.WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[1].GetMoveValues());

            var tst = new VG0816B_N5WORK_TAB_RAMO_CONJ();
            tst.TB_GRUPO_SUSEP.Value = 12;
            tst.TB_RAMO_CONJ.Value = 123;
            tst.TB_TAXA_RAMO_CONJ.Value = -12.9875;

            _.Move(tst, WS_AUXILIARES.WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[2]);
            Assert.True(tst == WS_AUXILIARES.WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[2]);

            _.Move(1, WS_AUXILIARES.WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[2].TB_TAXA_RAMO_CONJ);
            _.Move(1, tst);
            Assert.True(tst == WS_AUXILIARES.WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[2]);

            var movevar = 7;
            _.Move(movevar, WS_AUXILIARES.FILLER_1.FILLER_3.WTB02[2]);
            Assert.True(movevar == WS_AUXILIARES.FILLER_1.FILLER_3.WTB02[2]);
        }

        [Fact]
        public static void Teste_MoveProblems()
        {
            var DVLCRUZAD_IMP = new DoubleBasis(new PIC("S9", "010", "S9(010)V9(5)"), 5);
            _.Move("1,000000000", DVLCRUZAD_IMP);

            _.Move(0, SU1_DATA2);
            Assert.True(SU1_DATA2.GetMoveValues() == "00000000");

            _.Move(1, SU1_DATA2.SU1_DD2);
            Assert.True(SU1_DATA2.GetMoveValues() == "01000000");

            _.Move("", DETALHE_REGISTRO);

            Assert.True(DETALHE_REGISTRO.DETALHE_TIPO_REGISTRO?.Pic?.Length == 3);
            Assert.True(DETALHE_REGISTRO.DETALHE_NUM_CERTIFICADO?.Pic?.Length == 15);
            Assert.True(DETALHE_REGISTRO.DETALHE_NUM_TITULO?.Pic?.Length == 13);
            Assert.True(DETALHE_REGISTRO.DETALHE_DATA_TRANSACAO.DETALHE_ANO?.Pic?.Length == 4);
            Assert.True(DETALHE_REGISTRO.DETALHE_DATA_TRANSACAO.DETALHE_MES?.Pic?.Length == 2);
            Assert.True(DETALHE_REGISTRO.DETALHE_DATA_TRANSACAO.DETALHE_DIA?.Pic?.Length == 2);
            Assert.True(DETALHE_REGISTRO.DETALHE_VLR_TRANSACAO?.Pic?.Length == 13);
            Assert.True(DETALHE_REGISTRO.DETALHE_COD_TRANSACAO?.Pic?.Length == 3);
            Assert.True(DETALHE_REGISTRO.DETALHE_QTD_PARCELA?.Pic?.Length == 3);
            Assert.True(DETALHE_REGISTRO.DETALHE_NUM_PARCELA?.Pic?.Length == 3);
            Assert.True(DETALHE_REGISTRO.DETALHE_TIPO_LANCAMEN?.Pic?.Length == 4);
            Assert.True(DETALHE_REGISTRO.FILLER_55?.Pic?.Length == 4);
            Assert.True(DETALHE_REGISTRO.DETALHE_REFERENCIA?.Pic?.Length == 9);
            Assert.True(DETALHE_REGISTRO.FILLER_56?.Pic?.Length == 40);

            var compare = "00000000000000000000000000000000000000000000000000000000000000000000000000000000                                        ";
            Assert.True(DETALHE_REGISTRO.GetMoveValues() == compare);

            _.Move("1", DETALHE_REGISTRO.DETALHE_TIPO_REGISTRO);
            _.Move("1333", DETALHE_REGISTRO.FILLER_56);
            compare = "001000000000000000000000000000000000000000000000000000000000000000000000000000001333                                    ";
            Assert.True(DETALHE_REGISTRO.GetMoveValues() == compare);

            var intBS = new IntBasis(new PIC("9", "005", "9(005)"), 1);
            _.Move("", intBS);
            Assert.True(intBS == "00000");

            _.Move(1, intBS);
            var intBD = new IntBasis(new PIC("S9", "004", "S9(004)"));

            _.Move(intBS, intBD);

            Assert.True(intBS == intBD);
        }


        [Fact]
        public static void Teste_InitializeProblems()
        {
            _.Initialize(
                WORK_AREA.WS_RETORNO_SAP
                , COBHISVI.DCLCOBER_HIST_VIDAZUL
            );
        }

        [Fact]
        public static void Teste_VariableCreationPicLengthCheck()
        {
            var intBS = new IntBasis(new PIC("9", "9", "9"), 1);
            Assert.True(intBS?.Pic?.Length == 1);

            //intBS = new IntBasis(new PIC("9", "-Z(012)9,99", "-Z(012)9,99"), 1);
            //Assert.True(intBS?.Pic?.Length == 15);

            intBS = new IntBasis(new PIC("9", "99", "99"), 1);
            Assert.True(intBS?.Pic?.Length == 2);

            intBS = new IntBasis(new PIC("9", "999", "999"), 1);
            Assert.True(intBS?.Pic?.Length == 3);

            intBS = new IntBasis(new PIC("9", "9", "S9(9)"), 1);
            Assert.True(intBS?.Pic?.Length == 9);

            intBS = new IntBasis(new PIC("9", "9", "SZ9(9)"), 1);
            Assert.True(intBS?.Pic?.Length == 10);

            var intBS1 = new DoubleBasis(new PIC("9", "ZZ.ZZZ.ZZ9,99", "ZZ.ZZZ.ZZ9,99"), 0);
            Assert.True(intBS1?.Pic?.Length == 8);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "--.---.---.---.--9V99", "--.---.---.---.--9V99"), 1);
            Assert.True(intBS1?.Pic?.Length == 14);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "999999999V99", "999999999V99"), 0);
            Assert.True(intBS1?.Pic?.Length == 9);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "99V99", "99V99"), 1);
            Assert.True(intBS1?.Pic?.Length == 2);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "999V99", "999V99"), 1);
            Assert.True(intBS1?.Pic?.Length == 3);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "S99V99", "S99V99"), 1);
            Assert.True(intBS1?.Pic?.Length == 2);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "S9(9)V99", "S9(9)V99"), 1);
            Assert.True(intBS1?.Pic?.Length == 9);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "SZ9(9)V99", "SZ9(9)V99"), 1);
            Assert.True(intBS1?.Pic?.Length == 10);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "9V9(2)", "9V9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 1);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "99V9(2)", "99V9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 2);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "999V9(2)", "999V9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 3);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "S9(9)V9(2)", "S9(9)V9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 9);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "SZ9(9)V9(2)", "SZ9(9)V9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 10);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "ZZ.ZZ.99V9", "ZZ.ZZ.99V9"), 1);
            Assert.True(intBS1?.Pic?.Length == 6);
            Assert.True(intBS1?.Precision == 1);

            intBS1 = new DoubleBasis(new PIC("9", "ZZ.ZZ.99,9", "ZZ.ZZ.99,9"), 1);
            Assert.True(intBS1?.Pic?.Length == 6);
            Assert.True(intBS1?.Precision == 1);

            intBS1 = new DoubleBasis(new PIC("9", "ZZ.ZZ.99V9(2)", "ZZ.ZZ.99V9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 6);
            Assert.True(intBS1?.Precision == 2);

            intBS1 = new DoubleBasis(new PIC("9", "ZZ.ZZ.99,9(2)", "ZZ.ZZ.99,9(2)"), 1);
            Assert.True(intBS1?.Pic?.Length == 6);
            Assert.True(intBS1?.Precision == 2);

        }


        [Fact]
        public static void Teste_MoveAll()
        {
            var intBS = new DoubleBasis(new PIC("9", "ZZ.ZZ.99,9(2)", "ZZ.ZZ.99,9(2)"), 2);
            var intBS1 = new DoubleBasis(new PIC("9", "ZZ.ZZ.99V9(2)", "ZZ.ZZ.99V9(2)"), 2);
            _.MoveAll("9", intBS, intBS1);
            Assert.True(intBS == 999999.99);
            Assert.True(intBS1 == 999999.99);
            Assert.True(intBS == intBS1);

            var intiS = new IntBasis(new PIC("9", "99", "99"));
            var intiS1 = new IntBasis(new PIC("9", "9(2)", "9(2)"));
            _.MoveAll("9", intiS, intiS1);
            Assert.True(intiS == 99);
            Assert.True(intiS1 == 99);
            Assert.True(intiS == intiS1);

            var stringB = new StringBasis(new PIC("X", "99", "X(99)"));
            var stringB1 = new StringBasis(new PIC("X", "55", "X(55)"));
            _.MoveAll("*", stringB, stringB1);
            Assert.True(stringB == new string('*', 99));
            Assert.True(stringB1 == new string('*', 55));
            Assert.True(stringB1 != stringB);
        }
    }
}