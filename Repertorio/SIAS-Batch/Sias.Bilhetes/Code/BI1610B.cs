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
using Sias.Bilhetes.DB2.BI1610B;

namespace Code
{
    public class BI1610B
    {
        public bool IsCall { get; set; }

        public BI1610B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  BI - BILHETES                      *      */
        /*"      *   PROGRAMA ...............  BI1610B.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  CANETTA                            *      */
        /*"      *   PROGRAMADOR ............  CANETTA                            *      */
        /*"      *   DATA CODIFICACAO .......  04/2024                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  TRATAR PROPOSTAS DE BILHETES       *      */
        /*"      *                                                                *      */
        /*"      *   BI1610I1 ...............  ARQUIVO DE PROPOSTAS (ARQ.BILHETES)*      */
        /*"      *   BI1610O1 ...............  ARQUIVO DE PROPOSTAS REJEITADAS    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACOES                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.02  *  VERSAO 02  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/08/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.01  * VERSAO 01 EM 08/07/2024 - JAZZ 575159                          *      */
        /*"      *        TRATAR REGISTRO TIPO "D" - NOME SOCIAL                  *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.01                        CANETTA             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.00  * VERSAO XX EM XX/XXXX - JAZZ XXXXXX                             *      */
        /*"      *   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.00                        XXXXXXX             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _BI1610I1 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis BI1610I1
        {
            get
            {
                _.Move(BI1610I1_REGISTRO, _BI1610I1); VarBasis.RedefinePassValue(BI1610I1_REGISTRO, _BI1610I1, BI1610I1_REGISTRO); return _BI1610I1;
            }
        }
        public FileBasis _BI1610O1 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis BI1610O1
        {
            get
            {
                _.Move(BI1610O1_REGISTRO, _BI1610O1); VarBasis.RedefinePassValue(BI1610O1_REGISTRO, _BI1610O1, BI1610O1_REGISTRO); return _BI1610O1;
            }
        }
        /*"01           BI1610I1-REGISTRO.*/
        public BI1610B_BI1610I1_REGISTRO BI1610I1_REGISTRO { get; set; } = new BI1610B_BI1610I1_REGISTRO();
        public class BI1610B_BI1610I1_REGISTRO : VarBasis
        {
            /*"  03         BI1610I1-TIP-REG            PIC  X(001).*/

            public SelectorBasis BI1610I1_TIP_REG { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       BI1610I1-HEADER             VALUE 'H'. */
							new SelectorItemBasis("BI1610I1_HEADER", "H"),
							/*" 88       BI1610I1-TRAILLER           VALUE 'T'. */
							new SelectorItemBasis("BI1610I1_TRAILLER", "T"),
							/*" 88       BI1610I1-PGTO-AVULSO        VALUE '0'. */
							new SelectorItemBasis("BI1610I1_PGTO_AVULSO", "0"),
							/*" 88       BI1610I1-CLIENTE            VALUE '1'. */
							new SelectorItemBasis("BI1610I1_CLIENTE", "1"),
							/*" 88       BI1610I1-ENDERECO           VALUE '2'. */
							new SelectorItemBasis("BI1610I1_ENDERECO", "2"),
							/*" 88       BI1610I1-PROPOSTA           VALUE '3'. */
							new SelectorItemBasis("BI1610I1_PROPOSTA", "3"),
							/*" 88       BI1610I1-BENEFICIARIO       VALUE '4'. */
							new SelectorItemBasis("BI1610I1_BENEFICIARIO", "4"),
							/*" 88       BI1610I1-DADOS-AUTO         VALUE '4'. */
							new SelectorItemBasis("BI1610I1_DADOS_AUTO", "4"),
							/*" 88       BI1610I1-INFO-COMPLEMENTAR  VALUE '5'. */
							new SelectorItemBasis("BI1610I1_INFO_COMPLEMENTAR", "5"),
							/*" 88       BI1610I1-REGISTRO-DIVERSOS  VALUE '6'. */
							new SelectorItemBasis("BI1610I1_REGISTRO_DIVERSOS", "6"),
							/*" 88       BI1610I1-TIPO-A             VALUE 'A'. */
							new SelectorItemBasis("BI1610I1_TIPO_A", "A"),
							/*" 88       BI1610I1-TIPO-B             VALUE 'B'. */
							new SelectorItemBasis("BI1610I1_TIPO_B", "B"),
							/*" 88       BI1610I1-TIPO-C             VALUE 'C'. */
							new SelectorItemBasis("BI1610I1_TIPO_C", "C"),
							/*" 88       BI1610I1-TIPO-D             VALUE 'D'. */
							new SelectorItemBasis("BI1610I1_TIPO_D", "D")
                }
            };

            /*"  03         BI1610I1-NUM-PRO            PIC  9(014).*/
            public IntBasis BI1610I1_NUM_PRO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  03         FILLER                      PIC  X(285).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "285", "X(285)."), @"");
            /*"01           BI1610O1-REGISTRO  PIC  X(300).*/
        }
        public StringBasis BI1610O1_REGISTRO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           WS-WORKING.*/
        public BI1610B_WS_WORKING WS_WORKING { get; set; } = new BI1610B_WS_WORKING();
        public class BI1610B_WS_WORKING : VarBasis
        {
            /*"  03         AC-CONTADORES.*/
            public BI1610B_AC_CONTADORES AC_CONTADORES { get; set; } = new BI1610B_AC_CONTADORES();
            public class BI1610B_AC_CONTADORES : VarBasis
            {
                /*"    05       AC-BI1610I1-LID    PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BI1610I1_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-BI1610I1-TRA    PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BI1610I1_TRA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-BI1610I1-DES    PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BI1610I1_DES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-BI1610I1-HEA    PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BI1610I1_HEA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-BI1610I1-ERR    PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BI1610I1_ERR { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-BI1610O1-GRV    PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BI1610O1_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-PRO-LID     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_PRO_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-PRO-FID     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_PRO_FID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-PRO-GRV     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_PRO_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-CSI-GRV     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_CSI_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-HPF-GRV     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_HPF_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-SAS-GRV     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_SAS_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-BEN-GRV     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_BEN_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-NSO-GRV     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_NSO_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-NSO-IGN     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_NSO_IGN { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-END         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_END { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-BEN         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_BEN { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-NSO         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_NSO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-REG-IGN     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_REG_IGN { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-REG-TP3     PIC S9(009)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_REG_TP3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       AC-QTD-PCR         PIC S9(009)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_PCR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  03         WS-AUXILIARES.*/
            }
            public BI1610B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new BI1610B_WS_AUXILIARES();
            public class BI1610B_WS_AUXILIARES : VarBasis
            {
                /*"    05       WS-FIM-ARQUIVO     PIC   9(002)   VALUE ZEROS*/
                public IntBasis WS_FIM_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       WS-SQLCODE         PIC   ---9.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05       WS-NUM-PRO-ANT     PIC S9(014)    VALUE +0  COMP-3.*/
                public IntBasis WS_NUM_PRO_ANT { get; set; } = new IntBasis(new PIC("S9", "14", "S9(014)"));
                /*"    05       WS-COD-PESSOA      PIC  9(009)    VALUE ZEROS.*/
                public IntBasis WS_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    05       WS-NUM-SICOB       PIC S9(015)    VALUE +0  COMP-3.*/
                public IntBasis WS_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"    05       WS-PDT-LID-ANT     PIC S9(004)    VALUE +0  COMP-3.*/
                public IntBasis WS_PDT_LID_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-PGM-CALL        PIC  X(008)    VALUE SPACES.*/
                public StringBasis WS_PGM_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05       VIND-DAT-ESP       PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_DAT_ESP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-CBO-CON       PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_CBO_CON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-RCA-AGE       PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_RCA_AGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-DAT-NAS       PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_DAT_NAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-DATA-PROC-AUX   PIC  X(010)    VALUE SPACES.*/
                public StringBasis WS_DATA_PROC_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       WS-DATA-PROC       PIC  X(010)    VALUE SPACES.*/
                public StringBasis WS_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-PROC.*/
                private _REDEF_BI1610B_FILLER_1 _filler_1 { get; set; }
                public _REDEF_BI1610B_FILLER_1 FILLER_1
                {
                    get { _filler_1 = new _REDEF_BI1610B_FILLER_1(); _.Move(WS_DATA_PROC, _filler_1); VarBasis.RedefinePassValue(WS_DATA_PROC, _filler_1, WS_DATA_PROC); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_DATA_PROC); }; return _filler_1; }
                    set { VarBasis.RedefinePassValue(value, _filler_1, WS_DATA_PROC); }
                }  //Redefines
                public class _REDEF_BI1610B_FILLER_1 : VarBasis
                {
                    /*"      07     WS-ANO-PROC        PIC  9(004).*/
                    public IntBasis WS_ANO_PROC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-PROC        PIC  9(002).*/
                    public IntBasis WS_MES_PROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-PROC        PIC  9(002).*/
                    public IntBasis WS_DIA_PROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-AAAAMMDD   PIC  9(008).*/

                    public _REDEF_BI1610B_FILLER_1()
                    {
                        WS_ANO_PROC.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                        WS_MES_PROC.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                        WS_DIA_PROC.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WS_DATA_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05       FILLER  REDEFINES  WS-DATA-AAAAMMDD.*/
                private _REDEF_BI1610B_FILLER_4 _filler_4 { get; set; }
                public _REDEF_BI1610B_FILLER_4 FILLER_4
                {
                    get { _filler_4 = new _REDEF_BI1610B_FILLER_4(); _.Move(WS_DATA_AAAAMMDD, _filler_4); VarBasis.RedefinePassValue(WS_DATA_AAAAMMDD, _filler_4, WS_DATA_AAAAMMDD); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_DATA_AAAAMMDD); }; return _filler_4; }
                    set { VarBasis.RedefinePassValue(value, _filler_4, WS_DATA_AAAAMMDD); }
                }  //Redefines
                public class _REDEF_BI1610B_FILLER_4 : VarBasis
                {
                    /*"      07     WS-ANO-AAAAMMDD    PIC  9(004).*/
                    public IntBasis WS_ANO_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     WS-MES-AAAAMMDD    PIC  9(002).*/
                    public IntBasis WS_MES_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-DIA-AAAAMMDD    PIC  9(002).*/
                    public IntBasis WS_DIA_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-DDMMAAAA   PIC  9(008).*/

                    public _REDEF_BI1610B_FILLER_4()
                    {
                        WS_ANO_AAAAMMDD.ValueChanged += OnValueChanged;
                        WS_MES_AAAAMMDD.ValueChanged += OnValueChanged;
                        WS_DIA_AAAAMMDD.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WS_DATA_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05       FILLER  REDEFINES  WS-DATA-DDMMAAAA.*/
                private _REDEF_BI1610B_FILLER_5 _filler_5 { get; set; }
                public _REDEF_BI1610B_FILLER_5 FILLER_5
                {
                    get { _filler_5 = new _REDEF_BI1610B_FILLER_5(); _.Move(WS_DATA_DDMMAAAA, _filler_5); VarBasis.RedefinePassValue(WS_DATA_DDMMAAAA, _filler_5, WS_DATA_DDMMAAAA); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_DATA_DDMMAAAA); }; return _filler_5; }
                    set { VarBasis.RedefinePassValue(value, _filler_5, WS_DATA_DDMMAAAA); }
                }  //Redefines
                public class _REDEF_BI1610B_FILLER_5 : VarBasis
                {
                    /*"      07     WS-DIA-DDMMAAAA    PIC  9(002).*/
                    public IntBasis WS_DIA_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-MES-DDMMAAAA    PIC  9(002).*/
                    public IntBasis WS_MES_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-ANO-DDMMAAAA    PIC  9(004).*/
                    public IntBasis WS_ANO_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05       WS-DATA-DB2        PIC  X(010)   VALUE '0000-00-00'*/

                    public _REDEF_BI1610B_FILLER_5()
                    {
                        WS_DIA_DDMMAAAA.ValueChanged += OnValueChanged;
                        WS_MES_DDMMAAAA.ValueChanged += OnValueChanged;
                        WS_ANO_DDMMAAAA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_DB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0000-00-00");
                /*"    05       FILLER  REDEFINES  WS-DATA-DB2.*/
                private _REDEF_BI1610B_FILLER_6 _filler_6 { get; set; }
                public _REDEF_BI1610B_FILLER_6 FILLER_6
                {
                    get { _filler_6 = new _REDEF_BI1610B_FILLER_6(); _.Move(WS_DATA_DB2, _filler_6); VarBasis.RedefinePassValue(WS_DATA_DB2, _filler_6, WS_DATA_DB2); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_DATA_DB2); }; return _filler_6; }
                    set { VarBasis.RedefinePassValue(value, _filler_6, WS_DATA_DB2); }
                }  //Redefines
                public class _REDEF_BI1610B_FILLER_6 : VarBasis
                {
                    /*"      07     WS-ANO-DB2         PIC  9(004).*/
                    public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-DB2         PIC  9(002).*/
                    public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-DB2         PIC  9(002).*/
                    public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-ORIGEM-PROPOSTA PIC  9(002).*/

                    public _REDEF_BI1610B_FILLER_6()
                    {
                        WS_ANO_DB2.ValueChanged += OnValueChanged;
                        FILLER_7.ValueChanged += OnValueChanged;
                        WS_MES_DB2.ValueChanged += OnValueChanged;
                        FILLER_8.ValueChanged += OnValueChanged;
                        WS_DIA_DB2.ValueChanged += OnValueChanged;
                    }

                }

                public SelectorBasis WS_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("002")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     ORIGEM-SIGPF                      VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88     ORIIGEM-CAIXA-PREV                VALUE 02. */
							new SelectorItemBasis("ORIIGEM_CAIXA_PREV", "02"),
							/*" 88     ORIGEM-SIGAT                      VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88     ORIGEM-SASSE                      VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88     ORIGEM-CAIXA-CAP                  VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88     ORIGEM-MANUAL                     VALUE 06. */
							new SelectorItemBasis("ORIGEM_MANUAL", "06"),
							/*" 88     ORIGEM-REMOTA                     VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88     ORIGEM-INTRANET                   VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88     ORIGEM-INTERNET                   VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09"),
							/*" 88     ORIGEM-CORRET-VIT                 VALUE 10. */
							new SelectorItemBasis("ORIGEM_CORRET_VIT", "10"),
							/*" 88     ORIGEM-FILIAL                     VALUE 11. */
							new SelectorItemBasis("ORIGEM_FILIAL", "11"),
							/*" 88     ORIGEM-MARSH                      VALUE 12. */
							new SelectorItemBasis("ORIGEM_MARSH", "12"),
							/*" 88     ORIGEM-LOTERICO                   VALUE 13. */
							new SelectorItemBasis("ORIGEM_LOTERICO", "13"),
							/*" 88     ORIGEM-CORRESPOND                 VALUE 14. */
							new SelectorItemBasis("ORIGEM_CORRESPOND", "14"),
							/*" 88     ORIGEM-LOTERICO-SISPL             VALUE 15. */
							new SelectorItemBasis("ORIGEM_LOTERICO_SISPL", "15"),
							/*" 88     ORIGEM-CCA                        VALUE 22. */
							new SelectorItemBasis("ORIGEM_CCA", "22"),
							/*" 88     ORIGEM-SIPEN-CAIXATEM             VALUE 17. */
							new SelectorItemBasis("ORIGEM_SIPEN_CAIXATEM", "17"),
							/*" 88     ORIGEM-ATM                        VALUE 34. */
							new SelectorItemBasis("ORIGEM_ATM", "34")
                }
                };

                /*"    05       WS-NUM-PROPOSTA    PIC 9(014).*/
                public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    05       CANAL  REDEFINES   WS-NUM-PROPOSTA.*/
                private _REDEF_BI1610B_CANAL _canal { get; set; }
                public _REDEF_BI1610B_CANAL CANAL
                {
                    get { _canal = new _REDEF_BI1610B_CANAL(); _.Move(WS_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _canal, WS_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, WS_NUM_PROPOSTA); }; return _canal; }
                    set { VarBasis.RedefinePassValue(value, _canal, WS_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_BI1610B_CANAL : VarBasis
                {
                    /*"      07     WS-CANAL-PROPOSTA  PIC 9(001).*/

                    public SelectorBasis WS_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                    {
                        Items = new List<SelectorItemBasis> {
                            /*" 88   CANAL-VENDA-PAPEL                 VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88   CANAL-VENDA-CEF                   VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88   CANAL-VENDA-SASSE                 VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88   CANAL-VENDA-CORRETOR              VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88   CANAL-VENDA-ATM                   VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88   CANAL-VENDA-GITEL                 VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88   CANAL-VENDA-INTERNET              VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88   CANAL-VENDA-INTRANET              VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                    };

                    /*"      07     FILLER             PIC  9(013).*/
                    public IntBasis FILLER_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"    05       WS-NUM-TIT-CED     PIC  9(013)    VALUE ZEROS.*/

                    public _REDEF_BI1610B_CANAL()
                    {
                        WS_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WS_NUM_TIT_CED { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05       FILLER  REDEFINES  WS-NUM-TIT-CED.*/
                private _REDEF_BI1610B_FILLER_10 _filler_10 { get; set; }
                public _REDEF_BI1610B_FILLER_10 FILLER_10
                {
                    get { _filler_10 = new _REDEF_BI1610B_FILLER_10(); _.Move(WS_NUM_TIT_CED, _filler_10); VarBasis.RedefinePassValue(WS_NUM_TIT_CED, _filler_10, WS_NUM_TIT_CED); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_NUM_TIT_CED); }; return _filler_10; }
                    set { VarBasis.RedefinePassValue(value, _filler_10, WS_NUM_TIT_CED); }
                }  //Redefines
                public class _REDEF_BI1610B_FILLER_10 : VarBasis
                {
                    /*"      07     FILLER             PIC  9(002).*/
                    public IntBasis FILLER_11 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-SEQ-TIT-CED     PIC  9(010).*/
                    public IntBasis WS_SEQ_TIT_CED { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"      07     WS-DIG-TIT-CED     PIC  9(001).*/
                    public IntBasis WS_DIG_TIT_CED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"  03         INDEXADORES.*/

                    public _REDEF_BI1610B_FILLER_10()
                    {
                        FILLER_11.ValueChanged += OnValueChanged;
                        WS_SEQ_TIT_CED.ValueChanged += OnValueChanged;
                        WS_DIG_TIT_CED.ValueChanged += OnValueChanged;
                    }

                }
            }
            public BI1610B_INDEXADORES INDEXADORES { get; set; } = new BI1610B_INDEXADORES();
            public class BI1610B_INDEXADORES : VarBasis
            {
                /*"    05       IND-PRO            PIC S9(003)    VALUE     +0.*/
                public IntBasis IND_PRO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05       IND-TAB            PIC S9(003)    VALUE     +0.*/
                public IntBasis IND_TAB { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05       IND-TEL            PIC S9(003)    VALUE     +0.*/
                public IntBasis IND_TEL { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05       IND-SIC            PIC S9(003)    VALUE     +0.*/
                public IntBasis IND_SIC { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05       IND-DES            PIC S9(003)    VALUE     +0.*/
                public IntBasis IND_DES { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"  03         WS-NIVEIS-88.*/
            }
            public BI1610B_WS_NIVEIS_88 WS_NIVEIS_88 { get; set; } = new BI1610B_WS_NIVEIS_88();
            public class BI1610B_WS_NIVEIS_88 : VarBasis
            {
                /*"    05       N88-BI1610I1-STATUS PIC  9(002)   VALUE     ZEROS.*/

                public SelectorBasis N88_BI1610I1_STATUS { get; set; } = new SelectorBasis("002", "ZEROS")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     BI1610I1-NORMAL                   VALUE     ZEROS. */
							new SelectorItemBasis("BI1610I1_NORMAL", "ZEROS"),
							/*" 88     BI1610I1-ERRO                     VALUE 01 THRU 99. */
							new SelectorItemBasis("BI1610I1_ERRO", "01 THRU 99"),
							/*" 88     BI1610I1-ENDFILE                  VALUE     10. */
							new SelectorItemBasis("BI1610I1_ENDFILE", "10")
                }
                };

                /*"    05       N88-BI1610O1-STATUS PIC  9(002)   VALUE     ZEROS.*/

                public SelectorBasis N88_BI1610O1_STATUS { get; set; } = new SelectorBasis("002", "ZEROS")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     BI1610O1-NORMAL                   VALUE     ZEROS. */
							new SelectorItemBasis("BI1610O1_NORMAL", "ZEROS"),
							/*" 88     BI1610O1-ERRO                     VALUE 01 THRU 99. */
							new SelectorItemBasis("BI1610O1_ERRO", "01 THRU 99"),
							/*" 88     BI1610O1-ENDFILE                  VALUE     10. */
							new SelectorItemBasis("BI1610O1_ENDFILE", "10")
                }
                };

                /*"    05       N88-RCAP           PIC  9(001)    VALUE     ZEROS.*/

                public SelectorBasis N88_RCAP { get; set; } = new SelectorBasis("001", "ZEROS")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     SEM-RCAP                          VALUE     ZEROS. */
							new SelectorItemBasis("SEM_RCAP", "ZEROS"),
							/*" 88     TEM-RCAP                          VALUE     01. */
							new SelectorItemBasis("TEM_RCAP", "01"),
							/*" 88     TEM-RCAP-COMP                     VALUE     02. */
							new SelectorItemBasis("TEM_RCAP_COMP", "02")
                }
                };

                /*"    05       N88-GRAVOU-SICOB   PIC  X(001)    VALUE     '*'.*/

                public SelectorBasis N88_GRAVOU_SICOB { get; set; } = new SelectorBasis("001", "*")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     GRAVOU-SICOB                      VALUE     'S'. */
							new SelectorItemBasis("GRAVOU_SICOB", "S")
                }
                };

                /*"    05       N88-TEM-RISCO      PIC  X(001)    VALUE     '*'.*/

                public SelectorBasis N88_TEM_RISCO { get; set; } = new SelectorBasis("001", "*")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-RISCO                         VALUE     'S'. */
							new SelectorItemBasis("TEM_RISCO", "S")
                }
                };

                /*"    05       N88-TIP-REGISTRO            PIC X(001)   VALUE '@'.*/

                public SelectorBasis N88_TIP_REGISTRO { get; set; } = new SelectorBasis("001", "@")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     REGISTRO-HEADER             VALUE 'H'. */
							new SelectorItemBasis("REGISTRO_HEADER", "H"),
							/*" 88     REGISTRO-TRAILLER           VALUE 'T'. */
							new SelectorItemBasis("REGISTRO_TRAILLER", "T"),
							/*" 88     REGISTRO-PGTO-AVULSO        VALUE '0'. */
							new SelectorItemBasis("REGISTRO_PGTO_AVULSO", "0"),
							/*" 88     REGISTRO-CLIENTE            VALUE '1'. */
							new SelectorItemBasis("REGISTRO_CLIENTE", "1"),
							/*" 88     REGISTRO-ENDERECO           VALUE '2'. */
							new SelectorItemBasis("REGISTRO_ENDERECO", "2"),
							/*" 88     REGISTRO-PROPOSTA           VALUE '3'. */
							new SelectorItemBasis("REGISTRO_PROPOSTA", "3"),
							/*" 88     REGISTRO-BENEFICIARIO       VALUE '4'. */
							new SelectorItemBasis("REGISTRO_BENEFICIARIO", "4"),
							/*" 88     REGISTRO-DADOS-AUTO         VALUE '4'. */
							new SelectorItemBasis("REGISTRO_DADOS_AUTO", "4"),
							/*" 88     REGISTRO-INFO-COMPLEMENTAR  VALUE '5'. */
							new SelectorItemBasis("REGISTRO_INFO_COMPLEMENTAR", "5"),
							/*" 88     REGISTRO-REGISTRO-DIVERSOS  VALUE '6'. */
							new SelectorItemBasis("REGISTRO_REGISTRO_DIVERSOS", "6"),
							/*" 88     REGISTRO-TIPO-A             VALUE 'A'. */
							new SelectorItemBasis("REGISTRO_TIPO_A", "A"),
							/*" 88     REGISTRO-TIPO-B             VALUE 'B'. */
							new SelectorItemBasis("REGISTRO_TIPO_B", "B"),
							/*" 88     REGISTRO-TIPO-C             VALUE 'C'. */
							new SelectorItemBasis("REGISTRO_TIPO_C", "C"),
							/*" 88     REGISTRO-TIPO-D             VALUE 'D'. */
							new SelectorItemBasis("REGISTRO_TIPO_D", "D"),
							/*" 88     REGISTRO-TIPO-W             VALUE 'W'. */
							new SelectorItemBasis("REGISTRO_TIPO_W", "W")
                }
                };

                /*"01           DISPLAY-ABEND.*/
            }
        }
        public BI1610B_DISPLAY_ABEND DISPLAY_ABEND { get; set; } = new BI1610B_DISPLAY_ABEND();
        public class BI1610B_DISPLAY_ABEND : VarBasis
        {
            /*"  03         FILLER             PIC  X(010)    VALUE             'BI1610B  '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"BI1610B  ");
            /*"  03         FILLER             PIC  X(028)    VALUE             ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"  03         FILLER             PIC  X(014)    VALUE             '    SQLCODE = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"  03         WSQLCODE           PIC  ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03         FILLER             PIC  X(014)    VALUE             '   SQLERRD1 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"  03         WSQLERRD1          PIC  ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03         FILLER             PIC  X(014)    VALUE             '   SQLERRD2 = '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"  03         WSQLERRD2          PIC  ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03         FILLER             PIC  X(014)    VALUE             '   SQLERRD2 = '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"  03         LOCALIZA-ABEND-1.*/
            public BI1610B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new BI1610B_LOCALIZA_ABEND_1();
            public class BI1610B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"    05       FILLER             PIC  X(012)    VALUE             'PARAGRAFO = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"    05       PARAGRAFO          PIC  X(040)    VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03         LOCALIZA-ABEND-2.*/
            }
            public BI1610B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new BI1610B_LOCALIZA_ABEND_2();
            public class BI1610B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"    05       FILLER             PIC  X(012)    VALUE             'COMANDO   = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"    05       COMANDO            PIC  X(060)    VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"  03         WSQLERRO.*/
            }
            public BI1610B_WSQLERRO WSQLERRO { get; set; } = new BI1610B_WSQLERRO();
            public class BI1610B_WSQLERRO : VarBasis
            {
                /*"    05       FILLER             PIC  X(014)    VALUE             ' *** SQLERRMC '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05       WSQLERRMC          PIC  X(070)    VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01           TABELA-BENEFICIARIOS.*/
            }
        }
        public BI1610B_TABELA_BENEFICIARIOS TABELA_BENEFICIARIOS { get; set; } = new BI1610B_TABELA_BENEFICIARIOS();
        public class BI1610B_TABELA_BENEFICIARIOS : VarBasis
        {
            /*"  03         FILLER             PIC  X(030)    VALUE 'CONJUGE'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CONJUGE");
            /*"  03         FILLER             PIC  X(030)    VALUE                                          'COMPANHEIRO(A)'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"COMPANHEIRO(A)");
            /*"  03         FILLER             PIC  X(030)    VALUE 'FILHOS '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"FILHOS ");
            /*"  03         FILLER             PIC  X(030)    VALUE 'PAIS   '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"PAIS   ");
            /*"  03         FILLER             PIC  X(030)    VALUE 'IRMAOS '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"IRMAOS ");
            /*"  03         FILLER             PIC  X(030)    VALUE 'OUTROS '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"OUTROS ");
            /*"  03         FILLER             PIC  X(030)    VALUE                                          'HERDEIROS LEGAIS'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"HERDEIROS LEGAIS");
            /*"01           FILLER  REDEFINES  TABELA-BENEFICIARIOS.*/
        }
        private _REDEF_BI1610B_FILLER_28 _filler_28 { get; set; }
        public _REDEF_BI1610B_FILLER_28 FILLER_28
        {
            get { _filler_28 = new _REDEF_BI1610B_FILLER_28(); _.Move(TABELA_BENEFICIARIOS, _filler_28); VarBasis.RedefinePassValue(TABELA_BENEFICIARIOS, _filler_28, TABELA_BENEFICIARIOS); _filler_28.ValueChanged += () => { _.Move(_filler_28, TABELA_BENEFICIARIOS); }; return _filler_28; }
            set { VarBasis.RedefinePassValue(value, _filler_28, TABELA_BENEFICIARIOS); }
        }  //Redefines
        public class _REDEF_BI1610B_FILLER_28 : VarBasis
        {
            /*"  03         TAB-LIT-BEN        PIC  X(030)    OCCURS 007 TIMES.*/
            public ListBasis<StringBasis, string> TAB_LIT_BEN { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "30", "X(030)"), 007);
            /*"01           TABELA-PROPOSTA.*/

            public _REDEF_BI1610B_FILLER_28()
            {
                TAB_LIT_BEN.ValueChanged += OnValueChanged;
            }

        }
        public BI1610B_TABELA_PROPOSTA TABELA_PROPOSTA { get; set; } = new BI1610B_TABELA_PROPOSTA();
        public class BI1610B_TABELA_PROPOSTA : VarBasis
        {
            /*"  03         TAB-REG-PROPOSTA   OCCURS    030  TIMES.*/
            public ListBasis<BI1610B_TAB_REG_PROPOSTA> TAB_REG_PROPOSTA { get; set; } = new ListBasis<BI1610B_TAB_REG_PROPOSTA>(030);
            public class BI1610B_TAB_REG_PROPOSTA : VarBasis
            {
                /*"    05       TAB-TIP-REG-PRO    PIC  X(001).*/
                public StringBasis TAB_TIP_REG_PRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       TAB-NUM-PRO        PIC  9(014).*/
                public IntBasis TAB_NUM_PRO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    05       FILLER             PIC  X(285).*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "285", "X(285)."), @"");
                /*"01           DPARM01X.*/
            }
        }
        public BI1610B_DPARM01X DPARM01X { get; set; } = new BI1610B_DPARM01X();
        public class BI1610B_DPARM01X : VarBasis
        {
            /*"  03         DPARM01            PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03         DPARM01-R          REDEFINES   DPARM01.*/
            private _REDEF_BI1610B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_BI1610B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_BI1610B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_BI1610B_DPARM01_R : VarBasis
            {
                /*"    05       DPARM01-1          PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-2          PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-3          PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-4          PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-5          PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-6          PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-7          PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-8          PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-9          PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       DPARM01-10         PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         DPARM01-D1         PIC  9(001).*/

                public _REDEF_BI1610B_DPARM01_R()
                {
                    DPARM01_1.ValueChanged += OnValueChanged;
                    DPARM01_2.ValueChanged += OnValueChanged;
                    DPARM01_3.ValueChanged += OnValueChanged;
                    DPARM01_4.ValueChanged += OnValueChanged;
                    DPARM01_5.ValueChanged += OnValueChanged;
                    DPARM01_6.ValueChanged += OnValueChanged;
                    DPARM01_7.ValueChanged += OnValueChanged;
                    DPARM01_8.ValueChanged += OnValueChanged;
                    DPARM01_9.ValueChanged += OnValueChanged;
                    DPARM01_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         DPARM01-RC         PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01     BI0003L-LINKAGE.*/
        }
        public BI1610B_BI0003L_LINKAGE BI0003L_LINKAGE { get; set; } = new BI1610B_BI0003L_LINKAGE();
        public class BI1610B_BI0003L_LINKAGE : VarBasis
        {
            /*" 03    BI0003L-E-CONTROLE.*/
            public BI1610B_BI0003L_E_CONTROLE BI0003L_E_CONTROLE { get; set; } = new BI1610B_BI0003L_E_CONTROLE();
            public class BI1610B_BI0003L_E_CONTROLE : VarBasis
            {
                /*"  05   BI0003L-E-COD-USU      PIC  X(008)         VALUE ZEROS.*/
                public StringBasis BI0003L_E_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05   BI0003L-E-DAT-SIS      PIC  X(010)         VALUE ZEROS.*/
                public StringBasis BI0003L_E_DAT_SIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*" 03    BI0003L-E-PESSOA.*/
            }
            public BI1610B_BI0003L_E_PESSOA BI0003L_E_PESSOA { get; set; } = new BI1610B_BI0003L_E_PESSOA();
            public class BI1610B_BI0003L_E_PESSOA : VarBasis
            {
                /*"  05   BI0003L-E-NOM-PES        PIC  X(040).*/
                public StringBasis BI0003L_E_NOM_PES { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-TIP-PES        PIC S9(001) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_TIP_PES { get; set; } = new IntBasis(new PIC("S9", "1", "S9(001)"));
                /*" 03    BI0003L-E-FISICA.*/
            }
            public BI1610B_BI0003L_E_FISICA BI0003L_E_FISICA { get; set; } = new BI1610B_BI0003L_E_FISICA();
            public class BI1610B_BI0003L_E_FISICA : VarBasis
            {
                /*"  05   BI0003L-E-NUM-CPF        PIC S9(011) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                /*"  05   BI0003L-E-DAT-NAS        PIC  X(010).*/
                public StringBasis BI0003L_E_DAT_NAS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05   BI0003L-E-SEX            PIC  X(001).*/
                public StringBasis BI0003L_E_SEX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05   BI0003L-E-EST-CIV        PIC  X(001).*/
                public StringBasis BI0003L_E_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05   BI0003L-E-NUM-IDE        PIC  X(015).*/
                public StringBasis BI0003L_E_NUM_IDE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05   BI0003L-E-ORG-EXP        PIC  X(005).*/
                public StringBasis BI0003L_E_ORG_EXP { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"  05   BI0003L-E-UF-EXP         PIC  X(002).*/
                public StringBasis BI0003L_E_UF_EXP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05   BI0003L-E-DAT-EXP        PIC  X(010).*/
                public StringBasis BI0003L_E_DAT_EXP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05   BI0003L-E-COD-CBO        PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*" 03    BI0003L-E-JURIDICA.*/
            }
            public BI1610B_BI0003L_E_JURIDICA BI0003L_E_JURIDICA { get; set; } = new BI1610B_BI0003L_E_JURIDICA();
            public class BI1610B_BI0003L_E_JURIDICA : VarBasis
            {
                /*"  05   BI0003L-E-NUM-CGC        PIC S9(015) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_NUM_CGC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"  05   BI0003L-E-NOM-FAN        PIC  X(040).*/
                public StringBasis BI0003L_E_NOM_FAN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*" 03    BI0003L-E-TELEFONE       OCCURS    003       TIMES.*/
            }
            public ListBasis<BI1610B_BI0003L_E_TELEFONE> BI0003L_E_TELEFONE { get; set; } = new ListBasis<BI1610B_BI0003L_E_TELEFONE>(003);
            public class BI1610B_BI0003L_E_TELEFONE : VarBasis
            {
                /*"  05   BI0003L-E-DDI            PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0003L-E-DDD            PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0003L-E-NUM-FON        PIC S9(011) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_NUM_FON { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                /*"  05   BI0003L-E-SIT-FON        PIC  X(001).*/
                public StringBasis BI0003L_E_SIT_FON { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*" 03    BI0003L-E-EMAIL.*/
            }
            public BI1610B_BI0003L_E_EMAIL BI0003L_E_EMAIL { get; set; } = new BI1610B_BI0003L_E_EMAIL();
            public class BI1610B_BI0003L_E_EMAIL : VarBasis
            {
                /*"  05   BI0003L-E-LIT-EMA        PIC  X(040).*/
                public StringBasis BI0003L_E_LIT_EMA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-SIT-EMA        PIC  X(001).*/
                public StringBasis BI0003L_E_SIT_EMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*" 03    BI0003L-E-ENDERECO-FIS.*/
            }
            public BI1610B_BI0003L_E_ENDERECO_FIS BI0003L_E_ENDERECO_FIS { get; set; } = new BI1610B_BI0003L_E_ENDERECO_FIS();
            public class BI1610B_BI0003L_E_ENDERECO_FIS : VarBasis
            {
                /*"  05   BI0003L-E-LIT-END-F      PIC  X(040).*/
                public StringBasis BI0003L_E_LIT_END_F { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-COM-END-F      PIC  X(015).*/
                public StringBasis BI0003L_E_COM_END_F { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05   BI0003L-E-LIT-BAI-F      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_BAI_F { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-COD-CEP-F      PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_COD_CEP_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0003L-E-LIT-CID-F      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_CID_F { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-SIG-UF-F       PIC  X(002).*/
                public StringBasis BI0003L_E_SIG_UF_F { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*" 03    BI0003L-E-ENDERECO-JUR.*/
            }
            public BI1610B_BI0003L_E_ENDERECO_JUR BI0003L_E_ENDERECO_JUR { get; set; } = new BI1610B_BI0003L_E_ENDERECO_JUR();
            public class BI1610B_BI0003L_E_ENDERECO_JUR : VarBasis
            {
                /*"  05   BI0003L-E-LIT-END-J      PIC  X(040).*/
                public StringBasis BI0003L_E_LIT_END_J { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-COM-END-J      PIC  X(015).*/
                public StringBasis BI0003L_E_COM_END_J { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05   BI0003L-E-LIT-BAI-J      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_BAI_J { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-COD-CEP-J      PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_COD_CEP_J { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0003L-E-LIT-CID-J      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_CID_J { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-SIG-UF-J       PIC  X(002).*/
                public StringBasis BI0003L_E_SIG_UF_J { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*" 03    BI0003L-SAIDA.*/
            }
            public BI1610B_BI0003L_SAIDA BI0003L_SAIDA { get; set; } = new BI1610B_BI0003L_SAIDA();
            public class BI1610B_BI0003L_SAIDA : VarBasis
            {
                /*"  05   BI0003L-S-COD-ERR        PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_S_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0003L-S-COD-SQL        PIC   ---9.*/
                public IntBasis BI0003L_S_COD_SQL { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"  05   BI0003L-S-LIT-ERR        PIC  X(030).*/
                public StringBasis BI0003L_S_LIT_ERR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05   BI0003L-S-COD-PES        PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_S_COD_PES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0003L-S-OCO-END        PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_S_OCO_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01     BI0004L-LINKAGE.*/
            }
        }
        public BI1610B_BI0004L_LINKAGE BI0004L_LINKAGE { get; set; } = new BI1610B_BI0004L_LINKAGE();
        public class BI1610B_BI0004L_LINKAGE : VarBasis
        {
            /*" 03    BI0004L-E-PESSOA.*/
            public BI1610B_BI0004L_E_PESSOA BI0004L_E_PESSOA { get; set; } = new BI1610B_BI0004L_E_PESSOA();
            public class BI1610B_BI0004L_E_PESSOA : VarBasis
            {
                /*"  05   BI0004L-E-COD-PES        PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_E_COD_PES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0004L-E-COD-PRD-SIG    PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_E_COD_PRD_SIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0004L-E-DAT-SIS        PIC  X(010)         VALUE SPACES*/
                public StringBasis BI0004L_E_DAT_SIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05   BI0004L-E-COD-USU        PIC  X(008)         VALUE SPACES*/
                public StringBasis BI0004L_E_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*" 03    BI0004L-SAIDA.*/
            }
            public BI1610B_BI0004L_SAIDA BI0004L_SAIDA { get; set; } = new BI1610B_BI0004L_SAIDA();
            public class BI1610B_BI0004L_SAIDA : VarBasis
            {
                /*"  05   BI0004L-S-COD-ERR        PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_S_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0004L-S-COD-SQL        PIC   ---9.*/
                public IntBasis BI0004L_S_COD_SQL { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"  05   BI0004L-S-DES-ERR        PIC  X(030).*/
                public StringBasis BI0004L_S_DES_ERR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05   BI0004L-S-COD-IDE        PIC S9(015) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_S_COD_IDE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF000 LBFPF000 { get; set; } = new Copies.LBFPF000();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF015 LBFPF015 { get; set; } = new Copies.LBFPF015();
        public Copies.LBFPF016 LBFPF016 { get; set; } = new Copies.LBFPF016();
        public Copies.LBFPF160 LBFPF160 { get; set; } = new Copies.LBFPF160();
        public Copies.LBFPF161 LBFPF161 { get; set; } = new Copies.LBFPF161();
        public Copies.LBFPF162 LBFPF162 { get; set; } = new Copies.LBFPF162();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LXFPF003 LXFPF003 { get; set; } = new Copies.LXFPF003();
        public Copies.LXFPF004 LXFPF004 { get; set; } = new Copies.LXFPF004();
        public Copies.LXFPF024 LXFPF024 { get; set; } = new Copies.LXFPF024();
        public Copies.LXFPF027 LXFPF027 { get; set; } = new Copies.LXFPF027();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBFPF026 LBFPF026 { get; set; } = new Copies.LBFPF026();
        public Copies.BIEMPCOM BIEMPCOM { get; set; } = new Copies.BIEMPCOM();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Copies.LXFPF028 LXFPF028 { get; set; } = new Copies.LXFPF028();
        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.PFACOPRO PFACOPRO { get; set; } = new Dclgens.PFACOPRO();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.TPRELAC TPRELAC { get; set; } = new Dclgens.TPRELAC();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.GETPMOIM GETPMOIM { get; set; } = new Dclgens.GETPMOIM();
        public Dclgens.GE372 GE372 { get; set; } = new Dclgens.GE372();
        public Dclgens.GE085 GE085 { get; set; } = new Dclgens.GE085();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string BI1610I1_FILE_NAME_P, string BI1610O1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                BI1610I1.SetFile(BI1610I1_FILE_NAME_P);
                BI1610O1.SetFile(BI1610O1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-00-BI1610B-SECTION */

                M_0000_00_BI1610B_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-00-BI1610B-SECTION */
        private void M_0000_00_BI1610B_SECTION()
        {
            /*" -522- MOVE '0000-00-BI1610B        ' TO PARAGRAFO */
            _.Move("0000-00-BI1610B        ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -523- MOVE '7000' TO COMANDO */
            _.Move("7000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -526- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -529- PERFORM 70000-00-INICIAL THRU 70000-99-SAIDA */

            M_70000_00_INICIAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/


            /*" -533- PERFORM 10000-00-TRATA-PROPOSTAS THRU 10000-99-SAIDA UNTIL WS-FIM-ARQUIVO = 10 */

            while (!(WS_WORKING.WS_AUXILIARES.WS_FIM_ARQUIVO == 10))
            {

                M_10000_00_TRATA_PROPOSTAS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

            }

            /*" -535- PERFORM 80000-00-FINAL THRU 80000-99-SAIDA */

            M_80000_00_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_80000_99_SAIDA*/


            /*" -535- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-INICIAL-SECTION */
        private void M_70000_00_INICIAL_SECTION()
        {
            /*" -545- MOVE '70000-00-INICIAL       ' TO PARAGRAFO */
            _.Move("70000-00-INICIAL       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -546- MOVE '70000' TO COMANDO */
            _.Move("70000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -548- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -549- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -550- DISPLAY ' BI1610B - TRATA PROPOSTAS BILHETES - V.00.1     ' */
            _.Display($" BI1610B - TRATA PROPOSTAS BILHETES - V.00.1     ");

            /*" -551- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -557- DISPLAY ' VERSAO DE : ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $" VERSAO DE : FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -558- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -566- DISPLAY ' DATA DE PROCESSAMENTO: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $" DATA DE PROCESSAMENTO: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -568- OPEN INPUT BI1610I1 */
            BI1610I1.Open(BI1610I1_REGISTRO, WS_WORKING.WS_NIVEIS_88.N88_BI1610I1_STATUS);

            /*" -570- OPEN OUTPUT BI1610O1 */
            BI1610O1.Open(BI1610O1_REGISTRO, WS_WORKING.WS_NIVEIS_88.N88_BI1610O1_STATUS);

            /*" -571- INITIALIZE DCLSISTEMAS */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
            );

            /*" -579- PERFORM M_70000_00_INICIAL_DB_SELECT_1 */

            M_70000_00_INICIAL_DB_SELECT_1();

            /*" -582- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -583- DISPLAY ' DATA DE MOVIMENTO: ' WS-DATA-PROC */
                _.Display($" DATA DE MOVIMENTO: {WS_WORKING.WS_AUXILIARES.WS_DATA_PROC}");

                /*" -584- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -585- ELSE */
            }
            else
            {


                /*" -586- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -587- DISPLAY 'BI1610B - NAO CONSTA REGISTRO SEGUROS.SISTEMAS' */
                    _.Display($"BI1610B - NAO CONSTA REGISTRO SEGUROS.SISTEMAS");

                    /*" -588- DISPLAY 'IDSISTEM =  BI ' */
                    _.Display($"IDSISTEM =  BI ");

                    /*" -589- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -590- ELSE */
                }
                else
                {


                    /*" -591- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -592- DISPLAY 'BI1610B - ERRO NA LEITURA NA SEGUROS.SISTEMAS' */
                    _.Display($"BI1610B - ERRO NA LEITURA NA SEGUROS.SISTEMAS");

                    /*" -593- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_WORKING.WS_AUXILIARES.WS_SQLCODE}");

                    /*" -594- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -595- END-IF */
                }


                /*" -597- END-IF */
            }


            /*" -599- MOVE 9999 TO PRDSIVPF-COD-PRODUTO-SIVPF */
            _.Move(9999, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -599- . */

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-SELECT-1 */
        public void M_70000_00_INICIAL_DB_SELECT_1()
        {
            /*" -579- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO INTO :WS-DATA-PROC , :WS-DATA-PROC-AUX FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' WITH UR END-EXEC */

            var m_70000_00_INICIAL_DB_SELECT_1_Query1 = new M_70000_00_INICIAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_70000_00_INICIAL_DB_SELECT_1_Query1.Execute(m_70000_00_INICIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_PROC, WS_WORKING.WS_AUXILIARES.WS_DATA_PROC);
                _.Move(executed_1.WS_DATA_PROC_AUX, WS_WORKING.WS_AUXILIARES.WS_DATA_PROC_AUX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/

        [StopWatch]
        /*" M-10000-00-TRATA-PROPOSTAS-SECTION */
        private void M_10000_00_TRATA_PROPOSTAS_SECTION()
        {
            /*" -609- MOVE '10000-00-TRATA-PROPOSTAS' TO PARAGRAFO */
            _.Move("10000-00-TRATA-PROPOSTAS", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -610- MOVE 'READ' TO COMANDO */
            _.Move("READ", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -612- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -612- READ BI1610I1 AT END */
            try
            {
                BI1610I1.Read(() =>
                {

                    /*" -614- MOVE 10 TO WS-FIM-ARQUIVO */
                    _.Move(10, WS_WORKING.WS_AUXILIARES.WS_FIM_ARQUIVO);

                    /*" -616- GO TO 10000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(BI1610I1.Value, BI1610I1_REGISTRO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -617- ADD 001 TO AC-BI1610I1-LID */
            WS_WORKING.AC_CONTADORES.AC_BI1610I1_LID.Value = WS_WORKING.AC_CONTADORES.AC_BI1610I1_LID + 001;

            /*" -620- DISPLAY 'LEU: ' BI1610I1-NUM-PRO '/' BI1610I1-TIP-REG */

            $"LEU: {BI1610I1_REGISTRO.BI1610I1_NUM_PRO}/{BI1610I1_REGISTRO.BI1610I1_TIP_REG}"
            .Display();

            /*" -621-  EVALUATE TRUE  */

            /*" -622-  WHEN BI1610I1-HEADER  */

            /*" -622- IF BI1610I1-HEADER */

            if (BI1610I1_REGISTRO.BI1610I1_TIP_REG["BI1610I1_HEADER"])
            {

                /*" -623- PERFORM 11000-00-TRATA-HEADER THRU 11000-99-SAIDA */

                M_11000_00_TRATA_HEADER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_11000_99_SAIDA*/


                /*" -624- GO TO 10000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/ //GOTO
                return;

                /*" -625-  WHEN BI1610I1-TRAILLER  */

                /*" -625- ELSE IF BI1610I1-TRAILLER */
            }
            else

            if (BI1610I1_REGISTRO.BI1610I1_TIP_REG["BI1610I1_TRAILLER"])
            {

                /*" -626- WRITE BI1610O1-REGISTRO FROM BI1610I1-REGISTRO */
                _.Move(BI1610I1_REGISTRO.GetMoveValues(), BI1610O1_REGISTRO);

                BI1610O1.Write(BI1610O1_REGISTRO.GetMoveValues().ToString());

                /*" -628- ADD 001 TO AC-BI1610O1-GRV AC-BI1610I1-TRA */
                WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV.Value = WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV + 001;
                WS_WORKING.AC_CONTADORES.AC_BI1610I1_TRA.Value = WS_WORKING.AC_CONTADORES.AC_BI1610I1_TRA + 001;

                /*" -629- MOVE 999988887777 TO WS-NUM-PRO-ANT */
                _.Move(999988887777, WS_WORKING.WS_AUXILIARES.WS_NUM_PRO_ANT);

                /*" -632-  END-EVALUATE  */

                /*" -632- END-IF */
            }


            /*" -633- IF BI1610I1-NUM-PRO NOT EQUAL WS-NUM-PRO-ANT */

            if (BI1610I1_REGISTRO.BI1610I1_NUM_PRO != WS_WORKING.WS_AUXILIARES.WS_NUM_PRO_ANT)
            {

                /*" -634- IF WS-NUM-PRO-ANT GREATER ZEROS */

                if (WS_WORKING.WS_AUXILIARES.WS_NUM_PRO_ANT > 00)
                {

                    /*" -638- PERFORM 13000-00-TRATA-PROPOSTA THRU 13000-99-SAIDA VARYING IND-PRO FROM 001 BY 001 UNTIL IND-PRO GREATER 030 OR TAB-TIP-REG-PRO(IND-PRO) EQUAL SPACES */

                    for (WS_WORKING.INDEXADORES.IND_PRO.Value = 001; !(WS_WORKING.INDEXADORES.IND_PRO > 030 || TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO].TAB_TIP_REG_PRO == string.Empty); WS_WORKING.INDEXADORES.IND_PRO.Value += 001)
                    {

                        M_13000_00_TRATA_PROPOSTA_SECTION();
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13000_99_SAIDA*/

                    }

                    /*" -639- END-IF */
                }


                /*" -640- DISPLAY 'INICIALIZA VARIAVEIS' */
                _.Display($"INICIALIZA VARIAVEIS");

                /*" -641- MOVE ZEROS TO IND-TAB */
                _.Move(0, WS_WORKING.INDEXADORES.IND_TAB);

                /*" -642- MOVE SPACES TO TABELA-PROPOSTA */
                _.Move("", TABELA_PROPOSTA);

                /*" -643- INITIALIZE BI0003L-LINKAGE */
                _.Initialize(
                    BI0003L_LINKAGE
                );

                /*" -644- IF BI1610I1-TIP-REG EQUAL 'T' */

                if (BI1610I1_REGISTRO.BI1610I1_TIP_REG == "T")
                {

                    /*" -645- MOVE ZEROS TO WS-NUM-PRO-ANT */
                    _.Move(0, WS_WORKING.WS_AUXILIARES.WS_NUM_PRO_ANT);

                    /*" -646- GO TO 10000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/ //GOTO
                    return;

                    /*" -647- ELSE */
                }
                else
                {


                    /*" -648- MOVE BI1610I1-NUM-PRO TO WS-NUM-PRO-ANT */
                    _.Move(BI1610I1_REGISTRO.BI1610I1_NUM_PRO, WS_WORKING.WS_AUXILIARES.WS_NUM_PRO_ANT);

                    /*" -649- END-IF */
                }


                /*" -651- END-IF */
            }


            /*" -652- ADD 001 TO IND-TAB */
            WS_WORKING.INDEXADORES.IND_TAB.Value = WS_WORKING.INDEXADORES.IND_TAB + 001;

            /*" -653- MOVE BI1610I1-REGISTRO TO TAB-REG-PROPOSTA(IND-TAB) */
            _.Move(BI1610I1?.Value, TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_TAB]);

            /*" -656- DISPLAY 'CARREGOU: ' TAB-TIP-REG-PRO(IND-TAB) '/' TAB-NUM-PRO(IND-TAB) */

            $"CARREGOU: {TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_TAB]}/{TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_TAB]}"
            .Display();

            /*" -656- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

        [StopWatch]
        /*" M-11000-00-TRATA-HEADER-SECTION */
        private void M_11000_00_TRATA_HEADER_SECTION()
        {
            /*" -666- MOVE '11000-00-TRATA-HEADER   ' TO PARAGRAFO */
            _.Move("11000-00-TRATA-HEADER   ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -667- MOVE '11000' TO COMANDO */
            _.Move("11000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -670- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -672- MOVE BI1610I1-REGISTRO TO REG-HEADER */
            _.Move(BI1610I1?.Value, LXFPF990.REG_HEADER);

            /*" -673- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -676- DISPLAY ' DATA DE MOVTO: ' RH-DATA-GERACAO ' SEQUENCIA ARQ: ' RH-NSAS */

            $" DATA DE MOVTO: {LXFPF990.REG_HEADER.RH_DATA_GERACAO} SEQUENCIA ARQ: {LXFPF990.REG_HEADER.RH_NSAS}"
            .Display();

            /*" -678- WRITE BI1610O1-REGISTRO FROM BI1610I1-REGISTRO */
            _.Move(BI1610I1_REGISTRO.GetMoveValues(), BI1610O1_REGISTRO);

            BI1610O1.Write(BI1610O1_REGISTRO.GetMoveValues().ToString());

            /*" -679- IF BI1610O1-NORMAL */

            if (WS_WORKING.WS_NIVEIS_88.N88_BI1610O1_STATUS["BI1610O1_NORMAL"])
            {

                /*" -681- ADD 001 TO AC-BI1610O1-GRV AC-BI1610I1-HEA */
                WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV.Value = WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV + 001;
                WS_WORKING.AC_CONTADORES.AC_BI1610I1_HEA.Value = WS_WORKING.AC_CONTADORES.AC_BI1610I1_HEA + 001;

                /*" -682- MOVE ZEROS TO WS-NUM-PRO-ANT */
                _.Move(0, WS_WORKING.WS_AUXILIARES.WS_NUM_PRO_ANT);

                /*" -683- ELSE */
            }
            else
            {


                /*" -684- DISPLAY '***' */
                _.Display($"***");

                /*" -685- DISPLAY '11000-00-TRATA-HEADER ' */
                _.Display($"11000-00-TRATA-HEADER ");

                /*" -686- DISPLAY ' ERRO WRITE BI1610O1 ST = ' N88-BI1610O1-STATUS */
                _.Display($" ERRO WRITE BI1610O1 ST = {WS_WORKING.WS_NIVEIS_88.N88_BI1610O1_STATUS}");

                /*" -687- DISPLAY '***' */
                _.Display($"***");

                /*" -688- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -690- END-IF */
            }


            /*" -690- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_11000_99_SAIDA*/

        [StopWatch]
        /*" M-13000-00-TRATA-PROPOSTA-SECTION */
        private void M_13000_00_TRATA_PROPOSTA_SECTION()
        {
            /*" -700- MOVE '13000-00-TRATA-PROPOSTA     ' TO PARAGRAFO */
            _.Move("13000-00-TRATA-PROPOSTA     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -701- MOVE '13000' TO COMANDO */
            _.Move("13000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -704- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -705- MOVE TAB-TIP-REG-PRO(IND-PRO) TO N88-TIP-REGISTRO */
            _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO].TAB_TIP_REG_PRO, WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO);

            /*" -708- DISPLAY 'LEU TABELA: ' TAB-TIP-REG-PRO(IND-PRO) '/' TAB-NUM-PRO(IND-PRO) */

            $"LEU TABELA: {TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO]}/{TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO]}"
            .Display();

            /*" -709-  EVALUATE TRUE  */

            /*" -710-  WHEN REGISTRO-CLIENTE  */

            /*" -710- IF REGISTRO-CLIENTE */

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_CLIENTE"])
            {

                /*" -711- PERFORM 13100-00-CLIENTE */

                M_13100_00_CLIENTE_SECTION();

                /*" -712-  WHEN REGISTRO-ENDERECO  */

                /*" -712- ELSE IF REGISTRO-ENDERECO */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_ENDERECO"])
            {

                /*" -713- PERFORM 13300-00-ENDERECO */

                M_13300_00_ENDERECO_SECTION();

                /*" -714-  WHEN REGISTRO-PROPOSTA  */

                /*" -714- ELSE IF REGISTRO-PROPOSTA */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_PROPOSTA"])
            {

                /*" -715- ADD 001 TO AC-QTD-REG-TP3 */
                WS_WORKING.AC_CONTADORES.AC_QTD_REG_TP3.Value = WS_WORKING.AC_CONTADORES.AC_QTD_REG_TP3 + 001;

                /*" -716- PERFORM 13500-00-TRATA-PROPOSTA */

                M_13500_00_TRATA_PROPOSTA_SECTION();

                /*" -717-  WHEN REGISTRO-BENEFICIARIO  */

                /*" -717- ELSE IF REGISTRO-BENEFICIARIO */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_BENEFICIARIO"])
            {

                /*" -718- ADD 001 TO AC-QTD-BEN */
                WS_WORKING.AC_CONTADORES.AC_QTD_BEN.Value = WS_WORKING.AC_CONTADORES.AC_QTD_BEN + 001;

                /*" -719- PERFORM 13700-00-BENEFICIARIO */

                M_13700_00_BENEFICIARIO_SECTION();

                /*" -720-  WHEN REGISTRO-TIPO-D  */

                /*" -720- ELSE IF REGISTRO-TIPO-D */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_TIPO_D"])
            {

                /*" -721- ADD 001 TO AC-QTD-NSO */
                WS_WORKING.AC_CONTADORES.AC_QTD_NSO.Value = WS_WORKING.AC_CONTADORES.AC_QTD_NSO + 001;

                /*" -722- PERFORM 13900-00-NOME-SOCIAL */

                M_13900_00_NOME_SOCIAL_SECTION();

                /*" -723-  WHEN REGISTRO-TIPO-A  */

                /*" -723- ELSE IF REGISTRO-TIPO-A */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_TIPO_A"])
            {

                /*" -724- ADD 001 TO AC-QTD-REG-IGN */
                WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN.Value = WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN + 001;

                /*" -725-  WHEN REGISTRO-TIPO-B  */

                /*" -725- ELSE IF REGISTRO-TIPO-B */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_TIPO_B"])
            {

                /*" -726- ADD 001 TO AC-QTD-REG-IGN */
                WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN.Value = WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN + 001;

                /*" -727-  WHEN REGISTRO-TIPO-W  */

                /*" -727- ELSE IF REGISTRO-TIPO-W */
            }
            else

            if (WS_WORKING.WS_NIVEIS_88.N88_TIP_REGISTRO["REGISTRO_TIPO_W"])
            {

                /*" -728- ADD 001 TO AC-QTD-REG-IGN */
                WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN.Value = WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN + 001;

                /*" -729-  WHEN OTHER  */

                /*" -729- ELSE */
            }
            else
            {


                /*" -730- DISPLAY 'BI1610B - FIM ANORMAL' */
                _.Display($"BI1610B - FIM ANORMAL");

                /*" -731- DISPLAY '  TIPO REGISTRO NAO ESPERADO' */
                _.Display($"  TIPO REGISTRO NAO ESPERADO");

                /*" -733- DISPLAY '  TIPO DE REGISTRO........  ' TAB-TIP-REG-PRO(IND-PRO) */
                _.Display($"  TIPO DE REGISTRO........  {TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO]}");

                /*" -735- DISPLAY '  NUMERO DA PROPOSTA ..... ' TAB-NUM-PRO(IND-PRO) */
                _.Display($"  NUMERO DA PROPOSTA ..... {TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO]}");

                /*" -736- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -738-  END-EVALUATE  */

                /*" -738- END-IF */
            }


            /*" -738- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13000_99_SAIDA*/

        [StopWatch]
        /*" M-13100-00-CLIENTE-SECTION */
        private void M_13100_00_CLIENTE_SECTION()
        {
            /*" -748- MOVE '13100-00-CLIENTE        ' TO PARAGRAFO */
            _.Move("13100-00-CLIENTE        ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -749- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -752- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -753- DISPLAY 'IND-PRO: ' IND-PRO */
            _.Display($"IND-PRO: {WS_WORKING.INDEXADORES.IND_PRO}");

            /*" -754- MOVE TAB-REG-PROPOSTA(IND-PRO) TO REG-CLIENTES */
            _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO], LBFPF011.REG_CLIENTES);

            /*" -755- ADD 001 TO AC-QTD-PRO-LID */
            WS_WORKING.AC_CONTADORES.AC_QTD_PRO_LID.Value = WS_WORKING.AC_CONTADORES.AC_QTD_PRO_LID + 001;

            /*" -757- MOVE R1-NUM-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -763- PERFORM M_13100_00_CLIENTE_DB_SELECT_1 */

            M_13100_00_CLIENTE_DB_SELECT_1();

            /*" -768- DISPLAY 'SEL FIDELIZ: ' PROPOFID-NUM-PROPOSTA-SIVPF '/' SQLCODE */

            $"SEL FIDELIZ: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}/{DB.SQLCODE}"
            .Display();

            /*" -769- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -770- PERFORM 13110-00-DESCARTA-PROPOSTA THRU 13110-99-SAIDA */

                M_13110_00_DESCARTA_PROPOSTA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13110_99_SAIDA*/


                /*" -771- GO TO 13100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13100_99_SAIDA*/ //GOTO
                return;

                /*" -772- ELSE */
            }
            else
            {


                /*" -773- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -774- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -775- DISPLAY '***' */
                    _.Display($"***");

                    /*" -776- DISPLAY ' 13100-00-CLIENTE              ' */
                    _.Display($" 13100-00-CLIENTE              ");

                    /*" -777- DISPLAY ' ERRO SEL FIDELIZ (' WS-SQLCODE ')' */

                    $" ERRO SEL FIDELIZ ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -778- DISPLAY '***' */
                    _.Display($"***");

                    /*" -779- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -780- END-IF */
                }


                /*" -783- END-IF */
            }


            /*" -786- PERFORM 13130-00-CBO THRU 13130-99-SAIDA */

            M_13130_00_CBO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13130_99_SAIDA*/


            /*" -787- MOVE 'BI1610B' TO BI0003L-E-COD-USU */
            _.Move("BI1610B", BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU);

            /*" -789- MOVE WS-DATA-PROC TO BI0003L-E-DAT-SIS */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_PROC, BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_DAT_SIS);

            /*" -790- MOVE R1-NOME-PESSOA TO BI0003L-E-NOM-PES */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_NOM_PES);

            /*" -793- MOVE R1-TIPO-PESSOA TO BI0003L-E-TIP-PES */
            _.Move(LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA, BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES);

            /*" -794- DISPLAY 'R1-TIPO-PESSOA: ' R1-TIPO-PESSOA */
            _.Display($"R1-TIPO-PESSOA: {LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA}");

            /*" -795- IF R1-TIPO-PESSOA EQUAL 001 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 001)
            {

                /*" -796- MOVE R1-CGC-CPF TO BI0003L-E-NUM-CPF */
                _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF);

                /*" -797- MOVE R1-DATA-NASCIMENTO TO WS-DATA-DDMMAAAA */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

                /*" -798- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

                /*" -799- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

                /*" -800- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

                /*" -801- MOVE WS-DATA-DB2 TO BI0003L-E-DAT-NAS */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_NAS);

                /*" -802- IF R1-IDE-SEXO EQUAL 001 */

                if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 001)
                {

                    /*" -803- MOVE 'M' TO BI0003L-E-SEX */
                    _.Move("M", BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_SEX);

                    /*" -804- ELSE */
                }
                else
                {


                    /*" -805- MOVE 'F' TO BI0003L-E-SEX */
                    _.Move("F", BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_SEX);

                    /*" -807- END-IF */
                }


                /*" -808- IF R1-ESTADO-CIVIL EQUAL 001 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 001)
                {

                    /*" -809- MOVE 'S' TO BI0003L-E-EST-CIV */
                    _.Move("S", BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV);

                    /*" -810- ELSE */
                }
                else
                {


                    /*" -811- IF R1-ESTADO-CIVIL EQUAL 002 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 002)
                    {

                        /*" -812- MOVE 'C' TO BI0003L-E-EST-CIV */
                        _.Move("C", BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV);

                        /*" -813- ELSE */
                    }
                    else
                    {


                        /*" -814- IF R1-ESTADO-CIVIL EQUAL 003 */

                        if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 003)
                        {

                            /*" -815- MOVE 'V' TO BI0003L-E-EST-CIV */
                            _.Move("V", BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV);

                            /*" -816- ELSE */
                        }
                        else
                        {


                            /*" -817- MOVE 'O' TO BI0003L-E-EST-CIV */
                            _.Move("O", BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV);

                            /*" -818- END-IF */
                        }


                        /*" -819- END-IF */
                    }


                    /*" -820- END-IF */
                }


                /*" -821- MOVE R1-NUM-IDENTIDADE TO BI0003L-E-NUM-IDE */
                _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_IDE);

                /*" -822- MOVE R1-ORGAO-EXPEDIDOR TO BI0003L-E-ORG-EXP */
                _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_ORG_EXP);

                /*" -823- MOVE R1-UF-EXPEDIDORA TO BI0003L-E-UF-EXP */
                _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_UF_EXP);

                /*" -824- MOVE R1-DATA-EXPEDICAO-RG TO WS-DATA-DDMMAAAA */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

                /*" -825- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

                /*" -826- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

                /*" -827- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

                /*" -828- MOVE WS-DATA-DB2 TO BI0003L-E-DAT-EXP */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_EXP);

                /*" -829- MOVE R1-COD-CBO TO BI0003L-E-COD-CBO */
                _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_COD_CBO);

                /*" -830- ELSE */
            }
            else
            {


                /*" -831- MOVE R1-CGC-CPF TO BI0003L-E-NUM-CGC */
                _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC);

                /*" -832- MOVE R1-NOME-PESSOA TO BI0003L-E-NOM-FAN */
                _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NOM_FAN);

                /*" -835- END-IF */
            }


            /*" -838- PERFORM VARYING IND-TEL FROM 001 BY 001 UNTIL IND-TEL GREATER 003 */

            for (WS_WORKING.INDEXADORES.IND_TEL.Value = 001; !(WS_WORKING.INDEXADORES.IND_TEL > 003); WS_WORKING.INDEXADORES.IND_TEL.Value += 001)
            {

                /*" -839- IF R1-DDD(IND-TEL) GREATER ZEROS */

                if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].R1_DDD > 00)
                {

                    /*" -840- MOVE 055 TO BI0003L-E-DDI(IND-TEL) */
                    _.Move(055, BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].BI0003L_E_DDI);

                    /*" -841- ELSE */
                }
                else
                {


                    /*" -842- MOVE ZEROS TO BI0003L-E-DDI(IND-TEL) */
                    _.Move(0, BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].BI0003L_E_DDI);

                    /*" -843- END-IF */
                }


                /*" -844- MOVE R1-DDD(IND-TEL) TO BI0003L-E-DDD(IND-TEL) */
                _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].R1_DDD, BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].BI0003L_E_DDD);

                /*" -846- MOVE R1-NUM-FONE(IND-TEL) TO BI0003L-E-NUM-FON(IND-TEL) */
                _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].R1_NUM_FONE, BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].BI0003L_E_NUM_FON);

                /*" -849- END-PERFORM */
            }

            /*" -851- MOVE R1-EMAIL TO BI0003L-E-LIT-EMA */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA);

            /*" -852- IF PRODUTOS-VIDA-INDIVIDUAL */

            if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA_INDIVIDUAL"])
            {

                /*" -854- MOVE 'P' TO BI0003L-E-SIT-EMA BI0003L-E-SIT-FON(IND-TEL) */
                _.Move("P", BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_SIT_EMA, BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].BI0003L_E_SIT_FON);

                /*" -855- ELSE */
            }
            else
            {


                /*" -857- MOVE 'A' TO BI0003L-E-SIT-EMA BI0003L-E-SIT-FON(IND-TEL) */
                _.Move("A", BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_SIT_EMA, BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.INDEXADORES.IND_TEL].BI0003L_E_SIT_FON);

                /*" -859- END-IF */
            }


            /*" -859- . */

        }

        [StopWatch]
        /*" M-13100-00-CLIENTE-DB-SELECT-1 */
        public void M_13100_00_CLIENTE_DB_SELECT_1()
        {
            /*" -763- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC */

            var m_13100_00_CLIENTE_DB_SELECT_1_Query1 = new M_13100_00_CLIENTE_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_13100_00_CLIENTE_DB_SELECT_1_Query1.Execute(m_13100_00_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13100_99_SAIDA*/

        [StopWatch]
        /*" M-13110-00-DESCARTA-PROPOSTA-SECTION */
        private void M_13110_00_DESCARTA_PROPOSTA_SECTION()
        {
            /*" -869- MOVE '13110-00-DESCARTA-PROPOS' TO PARAGRAFO */
            _.Move("13110-00-DESCARTA-PROPOS", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -870- MOVE '13110' TO COMANDO */
            _.Move("13110", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -873- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -877- PERFORM VARYING IND-DES FROM 001 BY 001 UNTIL IND-DES GREATER 030 OR TAB-TIP-REG-PRO(IND-DES) EQUAL SPACES */

            for (WS_WORKING.INDEXADORES.IND_DES.Value = 001; !(WS_WORKING.INDEXADORES.IND_DES > 030 || TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_DES].TAB_TIP_REG_PRO == string.Empty); WS_WORKING.INDEXADORES.IND_DES.Value += 001)
            {

                /*" -878- WRITE BI1610O1-REGISTRO FROM TAB-REG-PROPOSTA(IND-DES) */
                _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_DES].GetMoveValues(), BI1610O1_REGISTRO);

                BI1610O1.Write(BI1610O1_REGISTRO.GetMoveValues().ToString());

                /*" -879- ADD 001 TO AC-BI1610O1-GRV */
                WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV.Value = WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV + 001;

                /*" -881- END-PERFORM */
            }

            /*" -882- MOVE 088 TO IND-PRO */
            _.Move(088, WS_WORKING.INDEXADORES.IND_PRO);

            /*" -884- ADD 001 TO AC-BI1610I1-DES */
            WS_WORKING.AC_CONTADORES.AC_BI1610I1_DES.Value = WS_WORKING.AC_CONTADORES.AC_BI1610I1_DES + 001;

            /*" -884- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13110_99_SAIDA*/

        [StopWatch]
        /*" M-13130-00-CBO-SECTION */
        private void M_13130_00_CBO_SECTION()
        {
            /*" -895- MOVE '13130-00-CBO           ' TO PARAGRAFO */
            _.Move("13130-00-CBO           ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -896- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -899- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -901- MOVE R1-COD-CBO TO CBO-COD-CBO */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);

            /*" -907- PERFORM M_13130_00_CBO_DB_SELECT_1 */

            M_13130_00_CBO_DB_SELECT_1();

            /*" -912- DISPLAY 'SEL CBO: ' CBO-COD-CBO '/' SQLCODE */

            $"SEL CBO: {CBO.DCLCBO.CBO_COD_CBO}/{DB.SQLCODE}"
            .Display();

            /*" -913- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -915- MOVE CBO-DESCR-CBO TO R1-DESCRICAO-PROFISSAO */
                _.Move(CBO.DCLCBO.CBO_DESCR_CBO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                /*" -916- ELSE */
            }
            else
            {


                /*" -917- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -919- MOVE 'PROFISSAO NAO CADASTRADA' TO R1-DESCRICAO-PROFISSAO */
                    _.Move("PROFISSAO NAO CADASTRADA", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -920- ELSE */
                }
                else
                {


                    /*" -921- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -922- MOVE SQLCODE TO WS-SQLCODE */
                        _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                        /*" -923- DISPLAY '***' */
                        _.Display($"***");

                        /*" -924- DISPLAY ' 13130-00-CBO          ' */
                        _.Display($" 13130-00-CBO          ");

                        /*" -925- DISPLAY ' ERRO SEL CBO (' WS-SQLCODE ')' */

                        $" ERRO SEL CBO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                        .Display();

                        /*" -926- DISPLAY ' COD CBO: ' CBO-COD-CBO */
                        _.Display($" COD CBO: {CBO.DCLCBO.CBO_COD_CBO}");

                        /*" -927- DISPLAY '***' */
                        _.Display($"***");

                        /*" -928- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -929- END-IF */
                    }


                    /*" -930- END-IF */
                }


                /*" -933- END-IF */
            }


            /*" -935- IF R1-DESCRICAO-PROFISSAO EQUAL 'OUTROS' OR 'SERVIDOR PUBLICO' */

            if (LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO.In("OUTROS", "SERVIDOR PUBLICO"))
            {

                /*" -936- IF R1-DESCRICAO-PROFISSAO EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO.IsEmpty())
                {

                    /*" -938- MOVE 'PROFISSAO NAO QUALIFICADA' TO R1-DESCRICAO-PROFISSAO */
                    _.Move("PROFISSAO NAO QUALIFICADA", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -939- END-IF */
                }


                /*" -942- END-IF */
            }


            /*" -943- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -944- MOVE R1-NUM-PROPOSTA TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -945- MOVE R1-COD-CBO TO PF062-COD-CBO */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PF062.DCLPF_CBO.PF062_COD_CBO);

            /*" -947- MOVE R1-DESCRICAO-PROFISSAO TO PF062-DES-CBO */
            _.Move(LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO, PF062.DCLPF_CBO.PF062_DES_CBO);

            /*" -952- PERFORM M_13130_00_CBO_DB_INSERT_1 */

            M_13130_00_CBO_DB_INSERT_1();

            /*" -956- DISPLAY 'INS PF-CBO: ' PF062-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"INS PF-CBO: {PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -957- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -958- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -959- DISPLAY '***' */
                _.Display($"***");

                /*" -960- DISPLAY ' 13130-00-CBO              ' */
                _.Display($" 13130-00-CBO              ");

                /*" -961- DISPLAY ' ERRO INS CBO (' WS-SQLCODE ')' */

                $" ERRO INS CBO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -962- DISPLAY ' COD CBO: ' CBO-COD-CBO */
                _.Display($" COD CBO: {CBO.DCLCBO.CBO_COD_CBO}");

                /*" -963- DISPLAY '***' */
                _.Display($"***");

                /*" -964- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -966- END-IF */
            }


            /*" -966- . */

        }

        [StopWatch]
        /*" M-13130-00-CBO-DB-SELECT-1 */
        public void M_13130_00_CBO_DB_SELECT_1()
        {
            /*" -907- EXEC SQL SELECT DESCR_CBO INTO :CBO-DESCR-CBO FROM SEGUROS.CBO WHERE COD_CBO = :CBO-COD-CBO WITH UR END-EXEC */

            var m_13130_00_CBO_DB_SELECT_1_Query1 = new M_13130_00_CBO_DB_SELECT_1_Query1()
            {
                CBO_COD_CBO = CBO.DCLCBO.CBO_COD_CBO.ToString(),
            };

            var executed_1 = M_13130_00_CBO_DB_SELECT_1_Query1.Execute(m_13130_00_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }


        }

        [StopWatch]
        /*" M-13130-00-CBO-DB-INSERT-1 */
        public void M_13130_00_CBO_DB_INSERT_1()
        {
            /*" -952- EXEC SQL INSERT INTO SEGUROS.PF_CBO VALUES (:PF062-NUM-PROPOSTA-SIVPF, :PF062-COD-CBO , :PF062-DES-CBO) END-EXEC. */

            var m_13130_00_CBO_DB_INSERT_1_Insert1 = new M_13130_00_CBO_DB_INSERT_1_Insert1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
                PF062_COD_CBO = PF062.DCLPF_CBO.PF062_COD_CBO.ToString(),
                PF062_DES_CBO = PF062.DCLPF_CBO.PF062_DES_CBO.ToString(),
            };

            M_13130_00_CBO_DB_INSERT_1_Insert1.Execute(m_13130_00_CBO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13130_99_SAIDA*/

        [StopWatch]
        /*" M-13300-00-ENDERECO-SECTION */
        private void M_13300_00_ENDERECO_SECTION()
        {
            /*" -976- MOVE '13300-00-ENDERECO      ' TO PARAGRAFO */
            _.Move("13300-00-ENDERECO      ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -977- MOVE '13300.0' TO COMANDO */
            _.Move("13300.0", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -980- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -982- MOVE TAB-REG-PROPOSTA(IND-PRO) TO REG-ENDERECO */
            _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO], LBFPF012.REG_ENDERECO);

            /*" -983- IF R2-TIPO-ENDER EQUAL '1' */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == "1")
            {

                /*" -984- MOVE R2-ENDERECO TO BI0003L-E-LIT-END-F */
                _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_END_F);

                /*" -985- MOVE SPACES TO BI0003L-E-COM-END-F */
                _.Move("", BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COM_END_F);

                /*" -986- MOVE R2-BAIRRO TO BI0003L-E-LIT-BAI-F */
                _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_BAI_F);

                /*" -987- MOVE R2-CEP TO BI0003L-E-COD-CEP-F */
                _.Move(LBFPF012.REG_ENDERECO.R2_CEP, BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F);

                /*" -988- MOVE R2-CIDADE TO BI0003L-E-LIT-CID-F */
                _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_CID_F);

                /*" -989- MOVE R2-SIGLA-UF TO BI0003L-E-SIG-UF-F */
                _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_SIG_UF_F);

                /*" -990- ELSE */
            }
            else
            {


                /*" -991- MOVE R2-ENDERECO TO BI0003L-E-LIT-END-J */
                _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_END_J);

                /*" -992- MOVE SPACES TO BI0003L-E-COM-END-J */
                _.Move("", BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COM_END_J);

                /*" -993- MOVE R2-BAIRRO TO BI0003L-E-LIT-BAI-J */
                _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_BAI_J);

                /*" -994- MOVE R2-CEP TO BI0003L-E-COD-CEP-J */
                _.Move(LBFPF012.REG_ENDERECO.R2_CEP, BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COD_CEP_J);

                /*" -995- MOVE R2-CIDADE TO BI0003L-E-LIT-CID-J */
                _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_CID_J);

                /*" -996- MOVE R2-SIGLA-UF TO BI0003L-E-SIG-UF-J */
                _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_SIG_UF_J);

                /*" -998- END-IF */
            }


            /*" -998- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13300_99_SAIDA*/

        [StopWatch]
        /*" M-13500-00-TRATA-PROPOSTA-SECTION */
        private void M_13500_00_TRATA_PROPOSTA_SECTION()
        {
            /*" -1008- MOVE '13500-00-TRATA-PROPOSTA       ' TO PARAGRAFO */
            _.Move("13500-00-TRATA-PROPOSTA       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1009- MOVE '13500' TO COMANDO */
            _.Move("13500", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1012- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1014- MOVE TAB-REG-PROPOSTA(IND-PRO) TO REG-PROPOSTA-SASSE */
            _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO], LXFCT004.REG_PROPOSTA_SASSE);

            /*" -1016- PERFORM 13510-00-VERIFICA-PRODUTO THRU 13510-99-SAIDA */

            M_13510_00_VERIFICA_PRODUTO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13510_99_SAIDA*/


            /*" -1018- PERFORM 13530-00-PARAMETRIZACAO THRU 13530-99-SAIDA */

            M_13530_00_PARAMETRIZACAO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13530_99_SAIDA*/


            /*" -1020- PERFORM 13550-00-TRATA-PESSOA THRU 13550-99-SAIDA */

            M_13550_00_TRATA_PESSOA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13550_99_SAIDA*/


            /*" -1022- PERFORM 13570-00-TRATA-RELAC THRU 13570-99-SAIDA */

            M_13570_00_TRATA_RELAC_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13570_99_SAIDA*/


            /*" -1024- PERFORM 13590-00-VERIFICA-EMPRESA THRU 13590-99-SAIDA */

            M_13590_00_VERIFICA_EMPRESA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13590_99_SAIDA*/


            /*" -1026- PERFORM 135B0-00-PROPOSTA-FIDEL THRU 135B0-99-SAIDA */

            M_135B0_00_PROPOSTA_FIDEL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B0_99_SAIDA*/


            /*" -1028- PERFORM 135D0-00-SASSE-BIL THRU 135D0-99-SAIDA */

            M_135D0_00_SASSE_BIL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135D0_99_SAIDA*/


            /*" -1030- PERFORM 135F0-00-HIST-FIDELIZACAO THRU 135F0-99-SAIDA */

            M_135F0_00_HIST_FIDELIZACAO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135F0_99_SAIDA*/


            /*" -1030- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13500_99_SAIDA*/

        [StopWatch]
        /*" M-13510-00-VERIFICA-PRODUTO-SECTION */
        private void M_13510_00_VERIFICA_PRODUTO_SECTION()
        {
            /*" -1040- MOVE '13510-00-VERIFICA-PRODU' TO PARAGRAFO */
            _.Move("13510-00-VERIFICA-PRODU", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1041- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1044- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1045- MOVE R3-COD-PRODUTO TO PRDSIVPF-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -1047- MOVE R3-COD-PLANO TO PRDSIVPF-COD-PLANO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO);

            /*" -1058- PERFORM M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1 */

            M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1();

            /*" -1066- DISPLAY 'SEL PRODUTOS_SIVPF: ' PRDSIVPF-COD-PRODUTO-SIVPF '/' PRDSIVPF-COD-PLANO '*' PRDSIVPF-COD-PRODUTO '*' PRDSIVPF-COD-PLANO ' SQLCODE: ' SQLCODE */

            $"SEL PRODUTOS_SIVPF: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}/{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO}*{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}*{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1067- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1068- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1069- DISPLAY '***' */
                _.Display($"***");

                /*" -1070- DISPLAY '13510-00-VERIFICA-PRODU' */
                _.Display($"13510-00-VERIFICA-PRODU");

                /*" -1071- DISPLAY ' ERRO SEL PRODUTOS_SIVPF (' WS-SQLCODE ')' */

                $" ERRO SEL PRODUTOS_SIVPF ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1072- DISPLAY ' COD PRODUTO: ' PRDSIVPF-COD-PRODUTO-SIVPF */
                _.Display($" COD PRODUTO: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -1073- DISPLAY ' COD PLANO: ' PRDSIVPF-COD-PLANO */
                _.Display($" COD PLANO: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO}");

                /*" -1074- DISPLAY '***' */
                _.Display($"***");

                /*" -1075- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1077- END-IF */
            }


            /*" -1077- . */

        }

        [StopWatch]
        /*" M-13510-00-VERIFICA-PRODUTO-DB-SELECT-1 */
        public void M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1()
        {
            /*" -1058- EXEC SQL SELECT VALUE(COD_PRODUTO, 0) , VALUE(COD_PLANO, 0) INTO :PRDSIVPF-COD-PRODUTO , :PRDSIVPF-COD-PLANO FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO_SIVPF = :PRDSIVPF-COD-PRODUTO-SIVPF AND DTH_FIM_VIGENCIA = '9999-12-31' AND COD_PLANO = :PRDSIVPF-COD-PLANO WITH UR END-EXEC */

            var m_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1 = new M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
                PRDSIVPF_COD_PLANO = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO.ToString(),
            };

            var executed_1 = M_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1.Execute(m_13510_00_VERIFICA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);
                _.Move(executed_1.PRDSIVPF_COD_PLANO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13510_99_SAIDA*/

        [StopWatch]
        /*" M-13530-00-PARAMETRIZACAO-SECTION */
        private void M_13530_00_PARAMETRIZACAO_SECTION()
        {
            /*" -1087- MOVE '13530-00-PARAMETRIZACAO' TO PARAGRAFO */
            _.Move("13530-00-PARAMETRIZACAO", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1088- MOVE '13510' TO COMANDO */
            _.Move("13510", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1091- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1092- IF PRDSIVPF-COD-PRODUTO EQUAL WS-PDT-LID-ANT */

            if (PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO == WS_WORKING.WS_AUXILIARES.WS_PDT_LID_ANT)
            {

                /*" -1093- GO TO 13530-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13530_99_SAIDA*/ //GOTO
                return;

                /*" -1094- ELSE */
            }
            else
            {


                /*" -1095- MOVE PRDSIVPF-COD-PRODUTO TO WS-PDT-LID-ANT */
                _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO, WS_WORKING.WS_AUXILIARES.WS_PDT_LID_ANT);

                /*" -1098- END-IF */
            }


            /*" -1099- MOVE 'S' TO LK-0070-E-TRACE */
            _.Move("S", GE0070W.LK_0070_E_TRACE);

            /*" -1100- MOVE 'BATCH' TO LK-0070-E-COD-USUARIO */
            _.Move("BATCH", GE0070W.LK_0070_E_COD_USUARIO);

            /*" -1101- MOVE 'BI1610B' TO LK-0070-E-NOM-PROGRAMA */
            _.Move("BI1610B", GE0070W.LK_0070_E_NOM_PROGRAMA);

            /*" -1102- MOVE 001 TO LK-0070-E-ACAO */
            _.Move(001, GE0070W.LK_0070_E_ACAO);

            /*" -1103- MOVE PRDSIVPF-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -1104- MOVE ZEROS TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(0, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -1105- MOVE R3-DATA-PROPOSTA TO WS-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

            /*" -1106- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

            /*" -1107- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

            /*" -1108- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

            /*" -1110- MOVE WS-DATA-DB2 TO LK-0070-I-DTA-PROPOSTA */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, GE0070W.LK_0070_I_DTA_PROPOSTA);

            /*" -1111- MOVE 'GE0070S' TO WS-PGM-CALL */
            _.Move("GE0070S", WS_WORKING.WS_AUXILIARES.WS_PGM_CALL);

            /*" -1153- CALL WS-PGM-CALL USING LK-0070-E-TRACE LK-0070-E-COD-USUARIO LK-0070-E-NOM-PROGRAMA LK-0070-E-ACAO LK-0070-I-COD-PRODUTO LK-0070-I-SEQ-PRODUTO-VRS LK-0070-I-DTA-PROPOSTA LK-0070-S-DTA-INI-VIGENCIA LK-0070-S-DTA-FIM-VIGENCIA LK-0070-S-IND-FLUXO-PARAM LK-0070-S-COD-PERIOD-VIGENCIA LK-0070-S-QTD-PERIOD-VIGENCIA LK-0070-S-COD-MOEDA LK-0070-S-IND-RENOVA LK-0070-S-IND-RENOVA-AUTOMAT LK-0070-S-QTD-RENOVA-AUTOMAT LK-0070-S-IND-DPS LK-0070-S-IND-REENQUADRA-PREM LK-0070-S-IND-REAJUSTE-PREMIO LK-0070-S-COD-INDICE-REAJUSTE LK-0070-S-COD-PERIOD-REAJUSTE LK-0070-S-COD-INDC-DEVOLUCAO LK-0070-S-PCT-JUROS-DEVOLUCAO LK-0070-S-PCT-MULTA-DEVOLUCAO LK-0070-S-IND-FLUXO-COMISSAO LK-0070-S-IND-ACOPLADO LK-0070-S-IND-FLUXO-SINISTRO LK-0070-S-IND-CONJUGE LK-0070-S-COD-USUARIO LK-0070-S-NOM-PROGRAMA LK-0070-S-DTH-CADASTRAMENTO LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE */
            _.Call(WS_WORKING.WS_AUXILIARES.WS_PGM_CALL, GE0070W);

            /*" -1154- IF LK-0070-IND-ERRO NOT EQUAL ZEROS */

            if (GE0070W.LK_0070_IND_ERRO != 00)
            {

                /*" -1155- DISPLAY '***' */
                _.Display($"***");

                /*" -1156- DISPLAY ' 13530-00-PARAMETRIZACAO   ' */
                _.Display($" 13530-00-PARAMETRIZACAO   ");

                /*" -1157- DISPLAY ' CALL GE0070S ' */
                _.Display($" CALL GE0070S ");

                /*" -1158- DISPLAY ' ERRO CALL GE0070S(' LK-0070-IND-ERRO ')' */

                $" ERRO CALL GE0070S({GE0070W.LK_0070_IND_ERRO})"
                .Display();

                /*" -1159- DISPLAY ' LK-0070-E-TRACE  : ' LK-0070-E-TRACE */
                _.Display($" LK-0070-E-TRACE  : {GE0070W.LK_0070_E_TRACE}");

                /*" -1160- DISPLAY ' LK-0070-E-COD-USU: ' LK-0070-E-COD-USUARIO */
                _.Display($" LK-0070-E-COD-USU: {GE0070W.LK_0070_E_COD_USUARIO}");

                /*" -1161- DISPLAY ' LK-0070-E-NOM-PRO: ' LK-0070-E-NOM-PROGRAMA */
                _.Display($" LK-0070-E-NOM-PRO: {GE0070W.LK_0070_E_NOM_PROGRAMA}");

                /*" -1162- DISPLAY ' LK-0070-E-ACAO   : ' LK-0070-E-ACAO */
                _.Display($" LK-0070-E-ACAO   : {GE0070W.LK_0070_E_ACAO}");

                /*" -1163- DISPLAY ' LK-0070-I-COD-PRO: ' LK-0070-I-COD-PRODUTO */
                _.Display($" LK-0070-I-COD-PRO: {GE0070W.LK_0070_I_COD_PRODUTO}");

                /*" -1164- DISPLAY ' LK-0070-I-SEQ-PRO: ' LK-0070-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0070-I-SEQ-PRO: {GE0070W.LK_0070_I_SEQ_PRODUTO_VRS}");

                /*" -1165- DISPLAY ' LK-0070-I-DTA-PRO: ' LK-0070-I-DTA-PROPOSTA */
                _.Display($" LK-0070-I-DTA-PRO: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

                /*" -1166- DISPLAY '***' */
                _.Display($"***");

                /*" -1167- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1170- END-IF */
            }


            /*" -1171- IF LK-0070-S-IND-FLUXO-PARAM NOT EQUAL 'S' */

            if (GE0070W.LK_0070_S_IND_FLUXO_PARAM != "S")
            {

                /*" -1172- DISPLAY ' 13530-00-PARAMETRIZACAO   ' */
                _.Display($" 13530-00-PARAMETRIZACAO   ");

                /*" -1173- DISPLAY ' CALL GE0070S ' */
                _.Display($" CALL GE0070S ");

                /*" -1175- DISPLAY ' PRODUTO NAO CADASTRADO: ' LK-0070-S-IND-FLUXO-PARAM */
                _.Display($" PRODUTO NAO CADASTRADO: {GE0070W.LK_0070_S_IND_FLUXO_PARAM}");

                /*" -1176- DISPLAY ' LK-0070-I-COD-PRO: ' LK-0070-I-COD-PRODUTO */
                _.Display($" LK-0070-I-COD-PRO: {GE0070W.LK_0070_I_COD_PRODUTO}");

                /*" -1177- DISPLAY ' LK-0070-I-SEQ-PRO: ' LK-0070-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0070-I-SEQ-PRO: {GE0070W.LK_0070_I_SEQ_PRODUTO_VRS}");

                /*" -1178- DISPLAY ' LK-0070-I-DTA-PRO: ' LK-0070-I-DTA-PROPOSTA */
                _.Display($" LK-0070-I-DTA-PRO: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

                /*" -1179- DISPLAY '***' */
                _.Display($"***");

                /*" -1180- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1182- END-IF */
            }


            /*" -1182- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13530_99_SAIDA*/

        [StopWatch]
        /*" M-13550-00-TRATA-PESSOA-SECTION */
        private void M_13550_00_TRATA_PESSOA_SECTION()
        {
            /*" -1192- MOVE '13550-00-TRATA-PESSOA  ' TO PARAGRAFO */
            _.Move("13550-00-TRATA-PESSOA  ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1193- MOVE 'CALL' TO COMANDO */
            _.Move("CALL", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1196- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1197- DISPLAY 'CALL BI0003S' */
            _.Display($"CALL BI0003S");

            /*" -1199- CALL 'BI0003S' USING BI0003L-LINKAGE */
            _.Call("BI0003S", BI0003L_LINKAGE);

            /*" -1200- IF BI0003L-S-COD-ERR NOT EQUAL ZEROS */

            if (BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR != 00)
            {

                /*" -1201- DISPLAY '***' */
                _.Display($"***");

                /*" -1202- DISPLAY ' 13550-00-TRATA-PESSOA     ' */
                _.Display($" 13550-00-TRATA-PESSOA     ");

                /*" -1203- DISPLAY ' ERRO ACESSO BI0003S       ' */
                _.Display($" ERRO ACESSO BI0003S       ");

                /*" -1204- DISPLAY ' BI0003L-ERRO: ' BI0003L-S-COD-ERR */
                _.Display($" BI0003L-ERRO: {BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR}");

                /*" -1205- DISPLAY ' BI0003L-SQL: ' BI0003L-S-COD-SQL */
                _.Display($" BI0003L-SQL: {BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL}");

                /*" -1206- DISPLAY ' BI0003L-DESCRICAO: ' BI0003L-S-LIT-ERR */
                _.Display($" BI0003L-DESCRICAO: {BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR}");

                /*" -1207- DISPLAY '***' */
                _.Display($"***");

                /*" -1208- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1209- END-IF */
            }


            /*" -1211- DISPLAY 'VOLTA CALL BI0003S' */
            _.Display($"VOLTA CALL BI0003S");

            /*" -1211- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13550_99_SAIDA*/

        [StopWatch]
        /*" M-13570-00-TRATA-RELAC-SECTION */
        private void M_13570_00_TRATA_RELAC_SECTION()
        {
            /*" -1221- MOVE '13570-00-TRATA-RELAC   ' TO PARAGRAFO */
            _.Move("13570-00-TRATA-RELAC   ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1222- MOVE 'CALL' TO COMANDO */
            _.Move("CALL", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1225- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1226- DISPLAY 'BI0003L-S-COD-PES: ' BI0003L-S-COD-PES */
            _.Display($"BI0003L-S-COD-PES: {BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_PES}");

            /*" -1227- INITIALIZE BI0004L-LINKAGE */
            _.Initialize(
                BI0004L_LINKAGE
            );

            /*" -1228- MOVE BI0003L-S-COD-PES TO BI0004L-E-COD-PES */
            _.Move(BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_PES, BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PES);

            /*" -1230- MOVE R3-COD-PRODUTO TO BI0004L-E-COD-PRD-SIG W-PRODUTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG, LBWPF002.W_PRODUTO);

            /*" -1231- MOVE WS-DATA-PROC TO BI0004L-E-DAT-SIS */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_PROC, BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_DAT_SIS);

            /*" -1233- MOVE 'BI1610B' TO BI0004L-E-COD-USU */
            _.Move("BI1610B", BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_USU);

            /*" -1234- DISPLAY 'CALL BI0004S' */
            _.Display($"CALL BI0004S");

            /*" -1236- CALL 'BI0004S' USING BI0004L-LINKAGE */
            _.Call("BI0004S", BI0004L_LINKAGE);

            /*" -1237- IF BI0004L-S-COD-ERR NOT EQUAL ZEROS */

            if (BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR != 00)
            {

                /*" -1238- DISPLAY '***' */
                _.Display($"***");

                /*" -1239- DISPLAY ' 13570-00-TRATA-RELAC      ' */
                _.Display($" 13570-00-TRATA-RELAC      ");

                /*" -1240- DISPLAY ' ERRO ACESSO BI0004S       ' */
                _.Display($" ERRO ACESSO BI0004S       ");

                /*" -1241- DISPLAY ' BI0004L-ERRO: ' BI0004L-S-COD-ERR */
                _.Display($" BI0004L-ERRO: {BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR}");

                /*" -1242- DISPLAY ' BI0004L-SQL: ' BI0004L-S-COD-SQL */
                _.Display($" BI0004L-SQL: {BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL}");

                /*" -1243- DISPLAY ' BI0004L-DESCRICAO: ' BI0004L-S-DES-ERR */
                _.Display($" BI0004L-DESCRICAO: {BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR}");

                /*" -1244- DISPLAY '***' */
                _.Display($"***");

                /*" -1245- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1246- END-IF */
            }


            /*" -1248- DISPLAY 'VOLTA CALL BI0004S' */
            _.Display($"VOLTA CALL BI0004S");

            /*" -1248- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13570_99_SAIDA*/

        [StopWatch]
        /*" M-13590-00-VERIFICA-EMPRESA-SECTION */
        private void M_13590_00_VERIFICA_EMPRESA_SECTION()
        {
            /*" -1258- MOVE '13590-00-VERIFICA-EMPRE' TO PARAGRAFO */
            _.Move("13590-00-VERIFICA-EMPRE", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1259- MOVE 'DISTINCT' TO COMANDO */
            _.Move("DISTINCT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1266- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1270- MOVE R3-COD-PRODUTO TO PRDSIVPF-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -1278- PERFORM M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1 */

            M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1();

            /*" -1284- DISPLAY 'SEL PRODUTOS_SIVPF: ' PRDSIVPF-COD-PRODUTO-SIVPF '/' PRDSIVPF-COD-EMPRESA-SIVPF ' SQLCODE: ' SQLCODE */

            $"SEL PRODUTOS_SIVPF: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}/{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1285- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1286- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1287- DISPLAY '***' */
                _.Display($"***");

                /*" -1288- DISPLAY '13590-00-VERIFICA-EMPRE' */
                _.Display($"13590-00-VERIFICA-EMPRE");

                /*" -1289- DISPLAY ' ERRO SEL PRODUTOS_SIVPF (' WS-SQLCODE ')' */

                $" ERRO SEL PRODUTOS_SIVPF ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1290- DISPLAY ' COD PRODUTO: ' PRDSIVPF-COD-PRODUTO-SIVPF */
                _.Display($" COD PRODUTO: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -1291- DISPLAY '***' */
                _.Display($"***");

                /*" -1292- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1294- END-IF */
            }


            /*" -1294- . */

        }

        [StopWatch]
        /*" M-13590-00-VERIFICA-EMPRESA-DB-SELECT-1 */
        public void M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1()
        {
            /*" -1278- EXEC SQL SELECT DISTINCT COD_EMPRESA_SIVPF INTO :PRDSIVPF-COD-EMPRESA-SIVPF FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_PRODUTO_SIVPF = :PRDSIVPF-COD-PRODUTO-SIVPF AND DTH_FIM_VIGENCIA = '9999-12-31' ORDER BY COD_EMPRESA_SIVPF WITH UR END-EXEC */

            var m_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1 = new M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = M_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1.Execute(m_13590_00_VERIFICA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_EMPRESA_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13590_99_SAIDA*/

        [StopWatch]
        /*" M-135B0-00-PROPOSTA-FIDEL-SECTION */
        private void M_135B0_00_PROPOSTA_FIDEL_SECTION()
        {
            /*" -1304- MOVE '135B0-00-PROPOSTA-FIDEL' TO PARAGRAFO */
            _.Move("135B0-00-PROPOSTA-FIDEL", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1305- MOVE '135B0' TO COMANDO */
            _.Move("135B0", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1308- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1310- MOVE R3-NUM-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF WS-NUM-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_WORKING.WS_AUXILIARES.WS_NUM_PROPOSTA);

            /*" -1311- MOVE SPACES TO PROPOFID-SITUACAO-ENVIO */
            _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -1312- MOVE WS-CANAL-PROPOSTA TO PROPOFID-CANAL-PROPOSTA */
            _.Move(WS_WORKING.WS_AUXILIARES.CANAL.WS_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

            /*" -1313- MOVE R3-ORIGEM-PROPOSTA TO PROPOFID-ORIGEM-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_SIV.R3_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -1315- MOVE ZEROS TO WS-NUM-SICOB */
            _.Move(0, WS_WORKING.WS_AUXILIARES.WS_NUM_SICOB);

            /*" -1316- IF R3-VAL-TARIFA NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA.IsNumeric())
            {

                /*" -1317- MOVE ZEROS TO R3-VAL-TARIFA */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

                /*" -1318- END-IF */
            }


            /*" -1319- IF R3-VAL-COMISSAO NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.IsNumeric())
            {

                /*" -1320- MOVE ZEROS TO R3-VAL-COMISSAO */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO);

                /*" -1322- END-IF */
            }


            /*" -1324- PERFORM 135B1-00-RCAPS THRU 135B1-99-SAIDA */

            M_135B1_00_RCAPS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B1_99_SAIDA*/


            /*" -1325- IF TEM-RCAP */

            if (WS_WORKING.WS_NIVEIS_88.N88_RCAP["TEM_RCAP"])
            {

                /*" -1326- PERFORM 135B3-00-RCAPS-COMP THRU 135B3-99-SAIDA */

                M_135B3_00_RCAPS_COMP_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B3_99_SAIDA*/


                /*" -1327- IF TEM-RCAP-COMP */

                if (WS_WORKING.WS_NIVEIS_88.N88_RCAP["TEM_RCAP_COMP"])
                {

                    /*" -1328- MOVE RCAPCOMP-DATA-RCAP TO WS-DATA-DB2 */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, WS_WORKING.WS_AUXILIARES.WS_DATA_DB2);

                    /*" -1329- MOVE WS-DIA-DB2 TO WS-DIA-DDMMAAAA */
                    _.Move(WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2, WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA);

                    /*" -1330- MOVE WS-MES-DB2 TO WS-MES-DDMMAAAA */
                    _.Move(WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2, WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA);

                    /*" -1331- MOVE WS-ANO-DB2 TO WS-ANO-DDMMAAAA */
                    _.Move(WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2, WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA);

                    /*" -1333- MOVE WS-DATA-DDMMAAAA TO R3-DTQITBCO */
                    _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                    /*" -1334- MOVE RCAPCOMP-DATA-MOVIMENTO TO WS-DATA-DB2 */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, WS_WORKING.WS_AUXILIARES.WS_DATA_DB2);

                    /*" -1335- MOVE WS-DIA-DB2 TO WS-DIA-DDMMAAAA */
                    _.Move(WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2, WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA);

                    /*" -1336- MOVE WS-MES-DB2 TO WS-MES-DDMMAAAA */
                    _.Move(WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2, WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA);

                    /*" -1337- MOVE WS-ANO-DB2 TO WS-ANO-DDMMAAAA */
                    _.Move(WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2, WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA);

                    /*" -1339- MOVE WS-DATA-DDMMAAAA TO R3-DATA-CREDITO */
                    _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -1341- MOVE RCAPCOMP-VAL-RCAP TO R3-VAL-PAGO */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                    /*" -1342- MOVE RCAPS-AGE-COBRANCA TO R3-AGECOBR */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

                    /*" -1343- ELSE */
                }
                else
                {


                    /*" -1344- MOVE '01010001' TO R3-DATA-CREDITO */
                    _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -1345- IF R3-DTQITBCO EQUAL ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 00)
                    {

                        /*" -1346- MOVE '01010001' TO R3-DTQITBCO */
                        _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                        /*" -1347- END-IF */
                    }


                    /*" -1348- END-IF */
                }


                /*" -1349- ELSE */
            }
            else
            {


                /*" -1350- MOVE '01010001' TO R3-DATA-CREDITO */
                _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                /*" -1351- IF R3-DTQITBCO EQUAL ZEROS */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 00)
                {

                    /*" -1352- MOVE '01010001' TO R3-DTQITBCO */
                    _.Move("01010001", LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                    /*" -1353- END-IF */
                }


                /*" -1356- END-IF */
            }


            /*" -1357- MOVE '&' TO N88-GRAVOU-SICOB */
            _.Move("&", WS_WORKING.WS_NIVEIS_88.N88_GRAVOU_SICOB);

            /*" -1362- PERFORM 135B5-00-OBTER-SICOB THRU 135B5-99-SAIDA VARYING IND-SIC FROM 001 BY 001 UNTIL IND-SIC GREATER 010 OR GRAVOU-SICOB */

            for (WS_WORKING.INDEXADORES.IND_SIC.Value = 001; !(WS_WORKING.INDEXADORES.IND_SIC > 010 || WS_WORKING.WS_NIVEIS_88.N88_GRAVOU_SICOB["GRAVOU_SICOB"]); WS_WORKING.INDEXADORES.IND_SIC.Value += 001)
            {

                M_135B5_00_OBTER_SICOB_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B5_99_SAIDA*/

            }

            /*" -1363- IF IND-SIC GREATER 010 */

            if (WS_WORKING.INDEXADORES.IND_SIC > 010)
            {

                /*" -1364- DISPLAY '***' */
                _.Display($"***");

                /*" -1365- DISPLAY ' 135B0-00-PROPOSTA-FIDEL ' */
                _.Display($" 135B0-00-PROPOSTA-FIDEL ");

                /*" -1366- DISPLAY ' ESTOURO NUM OCORRENCIAS IND-SIC' */
                _.Display($" ESTOURO NUM OCORRENCIAS IND-SIC");

                /*" -1367- DISPLAY ' PROPOSTA: ' R3-NUM-PROPOSTA */
                _.Display($" PROPOSTA: {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -1368- DISPLAY '***' */
                _.Display($"***");

                /*" -1369- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1372- END-IF */
            }


            /*" -1375- MOVE WS-NUM-SICOB TO R3-NUM-SICOB PROPOFID-NUM-SICOB */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_NUM_SICOB, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -1377- MOVE BI0004L-S-COD-IDE TO PROPOFID-NUM-IDENTIFICACAO */
            _.Move(BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_IDE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -1378- MOVE R3-DATA-PROPOSTA TO WS-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

            /*" -1379- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

            /*" -1380- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

            /*" -1381- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

            /*" -1383- MOVE WS-DATA-DB2 TO PROPOFID-DATA-PROPOSTA */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -1385- MOVE R3-COD-PRODUTO TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -1388- MOVE PRDSIVPF-COD-EMPRESA-SIVPF TO PROPOFID-COD-EMPRESA-SIVPF */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -1391- MOVE R3-AGECOBR TO PROPOFID-AGECOBR */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -1392- IF R3-DIA-DEBITO GREATER ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO > 00)
            {

                /*" -1393- IF R3-OPCAOPAG EQUAL 003 */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 003)
                {

                    /*" -1394- IF R3-DIA-DEBITO LESS 029 */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO < 029)
                    {

                        /*" -1395- MOVE R3-DIA-DEBITO TO PROPOFID-DIA-DEBITO */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                        /*" -1396- ELSE */
                    }
                    else
                    {


                        /*" -1397- MOVE 28 TO PROPOFID-DIA-DEBITO */
                        _.Move(28, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                        /*" -1398- END-IF */
                    }


                    /*" -1399- ELSE */
                }
                else
                {


                    /*" -1400- MOVE R3-DIA-DEBITO TO PROPOFID-DIA-DEBITO */
                    _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                    /*" -1401- END-IF */
                }


                /*" -1402- ELSE */
            }
            else
            {


                /*" -1403- MOVE R3-DIA-DEBITO TO PROPOFID-DIA-DEBITO */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

                /*" -1405- END-IF */
            }


            /*" -1407- MOVE R3-OPCAOPAG TO PROPOFID-OPCAOPAG */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -1409- MOVE R3-AGECTADEB TO PROPOFID-AGECTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -1411- MOVE R3-OPRCTADEB TO PROPOFID-OPRCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -1413- MOVE R3-NUMCTADEB TO PROPOFID-NUMCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -1415- MOVE R3-DIGCTADEB TO PROPOFID-DIGCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -1417- MOVE R3-PCT-DESCONTO TO PROPOFID-PERC-DESCONTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -1419- MOVE R3-NRMATRVEN TO PROPOFID-NRMATRVEN */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -1424- MOVE ZEROS TO PROPOFID-AGECTAVEN PROPOFID-OPRCTAVEN PROPOFID-NUMCTAVEN PROPOFID-DIGCTAVEN */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -1426- MOVE R3-CGC-CONVENENTE TO PROPOFID-CGC-CONVENENTE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -1428- MOVE R3-NOME-CONVENENTE TO PROPOFID-NOME-CONVENENTE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -1430- MOVE ZEROS TO PROPOFID-NRMATRCON */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

            /*" -1431- MOVE R3-DTQITBCO TO WS-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

            /*" -1432- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

            /*" -1433- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

            /*" -1434- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

            /*" -1436- MOVE WS-DATA-DB2 TO PROPOFID-DTQITBCO */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -1438- MOVE R3-VAL-PAGO TO PROPOFID-VAL-PAGO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -1440- MOVE R3-VALOR-PREMIO-TOTAL TO PROPOFID-VAL-PAGO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -1442- MOVE R3-AGEPGTO TO PROPOFID-AGEPGTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -1444- MOVE R3-VAL-TARIFA TO PROPOFID-VAL-TARIFA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -1446- MOVE ZEROS TO PROPOFID-VAL-IOF */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -1447- MOVE R3-DATA-CREDITO TO WS-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

            /*" -1448- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

            /*" -1449- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

            /*" -1450- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

            /*" -1452- MOVE WS-DATA-DB2 TO PROPOFID-DATA-CREDITO */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -1454- MOVE R3-VAL-COMISSAO TO PROPOFID-VAL-COMISSAO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -1456- MOVE R3-SIT-PROPOSTA TO PROPOFID-SIT-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -1458- MOVE 'BI1610B' TO PROPOFID-COD-USUARIO */
            _.Move("BI1610B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -1460- MOVE ZEROS TO PROPOFID-NSAS-SIVPF */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -1462- MOVE AC-QTD-REG-TP3 TO PROPOFID-NSL */
            _.Move(WS_WORKING.AC_CONTADORES.AC_QTD_REG_TP3, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -1464- MOVE RH-NSAS TO PROPOFID-NSAC-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -1466- MOVE BI0003L-S-COD-PES TO PROPOFID-COD-PESSOA */
            _.Move(BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_PES, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -1468- MOVE R3-OPCAO-COBER TO PROPOFID-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -1470- MOVE R3-COD-PLANO TO PROPOFID-COD-PLANO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

            /*" -1472- MOVE R1-NOME-CONJUGE TO PROPOFID-NOME-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -1474- IF R1-DTNASC-CONJUGE EQUAL 01010001 OR R1-DTNASC-CONJUGE EQUAL ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE == 01010001 || LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE == 00)
            {

                /*" -1475- MOVE -001 TO VIND-DAT-NAS */
                _.Move(-001, WS_WORKING.WS_AUXILIARES.VIND_DAT_NAS);

                /*" -1476- ELSE */
            }
            else
            {


                /*" -1477- MOVE R1-DTNASC-CONJUGE TO WS-DATA-DDMMAAAA */
                _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

                /*" -1478- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

                /*" -1479- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

                /*" -1480- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

                /*" -1481- MOVE WS-DATA-DB2 TO PROPOFID-DATA-NASC-CONJUGE */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);

                /*" -1483- END-IF */
            }


            /*" -1484- MOVE R1-CBO-CONJUGE TO PROPOFID-PROFISSAO-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -1485- IF R1-RENDA-INDIVIDUAL NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL.IsNumeric())
            {

                /*" -1486- MOVE '0' TO PROPOFID-FAIXA-RENDA-IND */
                _.Move("0", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

                /*" -1487- ELSE */
            }
            else
            {


                /*" -1488- MOVE R1-RENDA-INDIVIDUAL TO PROPOFID-FAIXA-RENDA-IND */
                _.Move(LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

                /*" -1489- END-IF */
            }


            /*" -1490- IF R1-RENDA-FAMILIAR NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR.IsNumeric())
            {

                /*" -1491- MOVE '0' TO PROPOFID-FAIXA-RENDA-FAM */
                _.Move("0", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

                /*" -1492- ELSE */
            }
            else
            {


                /*" -1493- MOVE R1-RENDA-FAMILIAR TO PROPOFID-FAIXA-RENDA-FAM */
                _.Move(LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

                /*" -1494- END-IF */
            }


            /*" -1496- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -1498- PERFORM 135B7-00-AVALIACAO-RISCO THRU 135B7-99-SAIDA */

            M_135B7_00_AVALIACAO_RISCO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B7_99_SAIDA*/


            /*" -1499- IF NOT TEM-RISCO */

            if (!WS_WORKING.WS_NIVEIS_88.N88_TEM_RISCO["TEM_RISCO"])
            {

                /*" -1500- MOVE 'PCR' TO PROPOFID-SIT-PROPOSTA */
                _.Move("PCR", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                /*" -1501- ADD 001 TO AC-QTD-PCR */
                WS_WORKING.AC_CONTADORES.AC_QTD_PCR.Value = WS_WORKING.AC_CONTADORES.AC_QTD_PCR + 001;

                /*" -1504- END-IF */
            }


            /*" -1505- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1612- PERFORM M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1 */

            M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1();

            /*" -1617- DISPLAY 'INS PROPOSTA_FIDELIZ: ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' SQLCODE: ' SQLCODE */

            $"INS PROPOSTA_FIDELIZ: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1618- DISPLAY 'NUM-PROPOSTA-SIVPF: ' PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Display($"NUM-PROPOSTA-SIVPF: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

            /*" -1619- DISPLAY 'NUM-IDENTIFICACAO : ' PROPOFID-NUM-IDENTIFICACAO */
            _.Display($"NUM-IDENTIFICACAO : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

            /*" -1620- DISPLAY 'COD-EMPRESA-SIVPF : ' PROPOFID-COD-EMPRESA-SIVPF */
            _.Display($"COD-EMPRESA-SIVPF : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}");

            /*" -1621- DISPLAY 'COD-PESSOA        : ' PROPOFID-COD-PESSOA */
            _.Display($"COD-PESSOA        : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

            /*" -1622- DISPLAY 'NUM-SICOB         : ' PROPOFID-NUM-SICOB */
            _.Display($"NUM-SICOB         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

            /*" -1623- DISPLAY 'DATA-PROPOSTA     : ' PROPOFID-DATA-PROPOSTA */
            _.Display($"DATA-PROPOSTA     : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}");

            /*" -1624- DISPLAY 'COD-PRODUTO-SIVPF : ' PROPOFID-COD-PRODUTO-SIVPF */
            _.Display($"COD-PRODUTO-SIVPF : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

            /*" -1625- DISPLAY 'AGECOBR           : ' PROPOFID-AGECOBR */
            _.Display($"AGECOBR           : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}");

            /*" -1626- DISPLAY 'DIA-DEBITO        : ' PROPOFID-DIA-DEBITO */
            _.Display($"DIA-DEBITO        : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO}");

            /*" -1627- DISPLAY 'OPCAOPAG          : ' PROPOFID-OPCAOPAG */
            _.Display($"OPCAOPAG          : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG}");

            /*" -1628- DISPLAY 'AGECTADEB         : ' PROPOFID-AGECTADEB */
            _.Display($"AGECTADEB         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB}");

            /*" -1629- DISPLAY 'OPRCTADEB         : ' PROPOFID-OPRCTADEB */
            _.Display($"OPRCTADEB         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB}");

            /*" -1630- DISPLAY 'NUMCTADEB         : ' PROPOFID-NUMCTADEB */
            _.Display($"NUMCTADEB         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB}");

            /*" -1631- DISPLAY 'DIGCTADEB         : ' PROPOFID-DIGCTADEB */
            _.Display($"DIGCTADEB         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB}");

            /*" -1632- DISPLAY 'PERC-DESCONTO     : ' PROPOFID-PERC-DESCONTO */
            _.Display($"PERC-DESCONTO     : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO}");

            /*" -1633- DISPLAY 'NRMATRVEN         : ' PROPOFID-NRMATRVEN */
            _.Display($"NRMATRVEN         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN}");

            /*" -1634- DISPLAY 'AGECTAVEN         : ' PROPOFID-AGECTAVEN */
            _.Display($"AGECTAVEN         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN}");

            /*" -1635- DISPLAY 'OPRCTAVEN         : ' PROPOFID-OPRCTAVEN */
            _.Display($"OPRCTAVEN         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN}");

            /*" -1636- DISPLAY 'NUMCTAVEN         : ' PROPOFID-NUMCTAVEN */
            _.Display($"NUMCTAVEN         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN}");

            /*" -1637- DISPLAY 'DIGCTAVEN         : ' PROPOFID-DIGCTAVEN */
            _.Display($"DIGCTAVEN         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN}");

            /*" -1638- DISPLAY 'CGC-CONVENENTE    : ' PROPOFID-CGC-CONVENENTE */
            _.Display($"CGC-CONVENENTE    : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE}");

            /*" -1639- DISPLAY 'NOME-CONVENENTE   : ' PROPOFID-NOME-CONVENENTE */
            _.Display($"NOME-CONVENENTE   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE}");

            /*" -1640- DISPLAY 'NRMATRCON         : ' PROPOFID-NRMATRCON */
            _.Display($"NRMATRCON         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON}");

            /*" -1641- DISPLAY 'DTQITBCO          : ' PROPOFID-DTQITBCO */
            _.Display($"DTQITBCO          : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

            /*" -1642- DISPLAY 'VAL-PAGO          : ' PROPOFID-VAL-PAGO */
            _.Display($"VAL-PAGO          : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO}");

            /*" -1643- DISPLAY 'AGEPGTO           : ' PROPOFID-AGEPGTO */
            _.Display($"AGEPGTO           : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO}");

            /*" -1644- DISPLAY 'VAL-TARIFA        : ' PROPOFID-VAL-TARIFA */
            _.Display($"VAL-TARIFA        : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA}");

            /*" -1645- DISPLAY 'VAL-IOF           : ' PROPOFID-VAL-IOF */
            _.Display($"VAL-IOF           : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF}");

            /*" -1646- DISPLAY 'DATA-CREDITO      : ' PROPOFID-DATA-CREDITO */
            _.Display($"DATA-CREDITO      : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO}");

            /*" -1647- DISPLAY 'VAL-COMISSAO      : ' PROPOFID-VAL-COMISSAO */
            _.Display($"VAL-COMISSAO      : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO}");

            /*" -1648- DISPLAY 'SIT-PROPOSTA      : ' PROPOFID-SIT-PROPOSTA */
            _.Display($"SIT-PROPOSTA      : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA}");

            /*" -1649- DISPLAY 'COD-USUARIO       : ' PROPOFID-COD-USUARIO */
            _.Display($"COD-USUARIO       : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO}");

            /*" -1650- DISPLAY 'CANAL-PROPOSTA    : ' PROPOFID-CANAL-PROPOSTA */
            _.Display($"CANAL-PROPOSTA    : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA}");

            /*" -1651- DISPLAY 'NSAS-SIVPF        : ' PROPOFID-NSAS-SIVPF */
            _.Display($"NSAS-SIVPF        : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF}");

            /*" -1652- DISPLAY 'ORIGEM-PROPOSTA   : ' PROPOFID-ORIGEM-PROPOSTA */
            _.Display($"ORIGEM-PROPOSTA   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA}");

            /*" -1653- DISPLAY 'NSL               : ' PROPOFID-NSL */
            _.Display($"NSL               : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL}");

            /*" -1654- DISPLAY 'NSAC-SIVPF        : ' PROPOFID-NSAC-SIVPF */
            _.Display($"NSAC-SIVPF        : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF}");

            /*" -1655- DISPLAY 'SITUACAO-ENVIO    : ' PROPOFID-SITUACAO-ENVIO */
            _.Display($"SITUACAO-ENVIO    : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO}");

            /*" -1656- DISPLAY 'OPCAO-COBER       : ' PROPOFID-OPCAO-COBER */
            _.Display($"OPCAO-COBER       : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}");

            /*" -1657- DISPLAY 'COD-PLANO         : ' PROPOFID-COD-PLANO */
            _.Display($"COD-PLANO         : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO}");

            /*" -1658- DISPLAY 'NOME-CONJUGE      : ' PROPOFID-NOME-CONJUGE */
            _.Display($"NOME-CONJUGE      : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE}");

            /*" -1659- DISPLAY 'DATA-NASC-CONJUGE : ' PROPOFID-DATA-NASC-CONJUGE */
            _.Display($"DATA-NASC-CONJUGE : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE}");

            /*" -1660- DISPLAY 'PROFISSAO-CONJUGE : ' PROPOFID-PROFISSAO-CONJUGE */
            _.Display($"PROFISSAO-CONJUGE : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE}");

            /*" -1661- DISPLAY 'FAIXA-RENDA-IND   : ' PROPOFID-FAIXA-RENDA-IND */
            _.Display($"FAIXA-RENDA-IND   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND}");

            /*" -1662- DISPLAY 'FAIXA-RENDA-FAM   : ' PROPOFID-FAIXA-RENDA-FAM */
            _.Display($"FAIXA-RENDA-FAM   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM}");

            /*" -1664- DISPLAY 'IND-TIPO-CONTA    : ' PROPOFID-IND-TIPO-CONTA */
            _.Display($"IND-TIPO-CONTA    : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA}");

            /*" -1665- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1666- ADD 001 TO AC-QTD-PRO-FID */
                WS_WORKING.AC_CONTADORES.AC_QTD_PRO_FID.Value = WS_WORKING.AC_CONTADORES.AC_QTD_PRO_FID + 001;

                /*" -1667- ELSE */
            }
            else
            {


                /*" -1668- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1669- DISPLAY '***' */
                _.Display($"***");

                /*" -1670- DISPLAY ' 135B0-00-PROPOSTA-FIDEL ' */
                _.Display($" 135B0-00-PROPOSTA-FIDEL ");

                /*" -1671- DISPLAY ' ERRO INS FIDELIZ (' WS-SQLCODE ')' */

                $" ERRO INS FIDELIZ ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1672- DISPLAY ' PROPOSTA: ' R3-NUM-PROPOSTA */
                _.Display($" PROPOSTA: {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -1673- DISPLAY '***' */
                _.Display($"***");

                /*" -1674- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1676- END-IF */
            }


            /*" -1676- . */

        }

        [StopWatch]
        /*" M-135B0-00-PROPOSTA-FIDEL-DB-INSERT-1 */
        public void M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1()
        {
            /*" -1612- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , IND_TP_PROPOSTA , IND_TIPO_CONTA ) VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO, :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DAT-NAS, :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE :VIND-CBO-CON, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA) END-EXEC */

            var m_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1 = new M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_OPCAOPAG = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPOFID_PERC_DESCONTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE.ToString(),
                PROPOFID_NRMATRCON = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_VAL_TARIFA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA.ToString(),
                PROPOFID_VAL_IOF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_VAL_COMISSAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_CANAL_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DAT_NAS = WS_WORKING.WS_AUXILIARES.VIND_DAT_NAS.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                VIND_CBO_CON = WS_WORKING.WS_AUXILIARES.VIND_CBO_CON.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            M_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1.Execute(m_135B0_00_PROPOSTA_FIDEL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B0_99_SAIDA*/

        [StopWatch]
        /*" M-135B1-00-RCAPS-SECTION */
        private void M_135B1_00_RCAPS_SECTION()
        {
            /*" -1686- MOVE '135B1-00-RCAPS          ' TO PARAGRAFO */
            _.Move("135B1-00-RCAPS          ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1687- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1690- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1691- MOVE R3-NUM-PROPOSTA TO RCAPS-NUM-CERTIFICADO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1694- MOVE ZEROS TO N88-RCAP WS-NUM-SICOB */
            _.Move(0, WS_WORKING.WS_NIVEIS_88.N88_RCAP, WS_WORKING.WS_AUXILIARES.WS_NUM_SICOB);

            /*" -1707- PERFORM M_135B1_00_RCAPS_DB_SELECT_1 */

            M_135B1_00_RCAPS_DB_SELECT_1();

            /*" -1713- DISPLAY 'SEL RCAPS: ' RCAPS-NUM-TITULO OF DCLRCAPS ' SQLCODE: ' SQLCODE */

            $"SEL RCAPS: {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1714- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -1715- MOVE 001 TO N88-RCAP */
                _.Move(001, WS_WORKING.WS_NIVEIS_88.N88_RCAP);

                /*" -1716- MOVE RCAPS-NUM-RCAP TO WS-NUM-SICOB */
                _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, WS_WORKING.WS_AUXILIARES.WS_NUM_SICOB);

                /*" -1717- DISPLAY 'RCAPS-NUM-RCAP: ' RCAPS-NUM-RCAP */
                _.Display($"RCAPS-NUM-RCAP: {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                /*" -1718- IF VIND-RCA-AGE LESS ZEROS */

                if (WS_WORKING.WS_AUXILIARES.VIND_RCA_AGE < 00)
                {

                    /*" -1719- MOVE ZEROS TO RCAPS-AGE-COBRANCA */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                    /*" -1720- END-IF */
                }


                /*" -1721- ELSE */
            }
            else
            {


                /*" -1722- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1723- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1724- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1725- DISPLAY ' 135B1-00-RCAPS          ' */
                    _.Display($" 135B1-00-RCAPS          ");

                    /*" -1726- DISPLAY ' ERRO SEL RCAPS (' WS-SQLCODE ')' */

                    $" ERRO SEL RCAPS ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1727- DISPLAY ' PROPOSTA: ' R3-NUM-PROPOSTA */
                    _.Display($" PROPOSTA: {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                    /*" -1728- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1729- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1730- END-IF */
                }


                /*" -1732- END-IF */
            }


            /*" -1732- . */

        }

        [StopWatch]
        /*" M-135B1-00-RCAPS-DB-SELECT-1 */
        public void M_135B1_00_RCAPS_DB_SELECT_1()
        {
            /*" -1707- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP, AGE_COBRANCA INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-AGE-COBRANCA:VIND-RCA-AGE FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC */

            var m_135B1_00_RCAPS_DB_SELECT_1_Query1 = new M_135B1_00_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_135B1_00_RCAPS_DB_SELECT_1_Query1.Execute(m_135B1_00_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_RCA_AGE, WS_WORKING.WS_AUXILIARES.VIND_RCA_AGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B1_99_SAIDA*/

        [StopWatch]
        /*" M-135B3-00-RCAPS-COMP-SECTION */
        private void M_135B3_00_RCAPS_COMP_SECTION()
        {
            /*" -1742- MOVE '135B3-00-RCAPS-COMP     ' TO PARAGRAFO */
            _.Move("135B3-00-RCAPS-COMP     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1743- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1746- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1764- PERFORM M_135B3_00_RCAPS_COMP_DB_SELECT_1 */

            M_135B3_00_RCAPS_COMP_DB_SELECT_1();

            /*" -1771- DISPLAY 'SEL RCAP_COMPLEMENTAR: ' RCAPS-NUM-RCAP '/' RCAPS-NUM-RCAP ' SQLCODE: ' SQLCODE */

            $"SEL RCAP_COMPLEMENTAR: {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}/{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1772- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1773- MOVE 002 TO N88-RCAP */
                _.Move(002, WS_WORKING.WS_NIVEIS_88.N88_RCAP);

                /*" -1774- GO TO 135B3-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B3_99_SAIDA*/ //GOTO
                return;

                /*" -1775- ELSE */
            }
            else
            {


                /*" -1776- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1777- GO TO 135B3-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B3_99_SAIDA*/ //GOTO
                    return;

                    /*" -1778- ELSE */
                }
                else
                {


                    /*" -1779- IF SQLCODE NOT EQUAL -811 */

                    if (DB.SQLCODE != -811)
                    {

                        /*" -1780- MOVE SQLCODE TO WS-SQLCODE */
                        _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                        /*" -1781- DISPLAY '***' */
                        _.Display($"***");

                        /*" -1782- DISPLAY ' 135B3-00-RCAPS-COMP     ' */
                        _.Display($" 135B3-00-RCAPS-COMP     ");

                        /*" -1783- DISPLAY ' ERRO SEL RCAP_COMPLE(1) (' WS-SQLCODE ')' */

                        $" ERRO SEL RCAP_COMPLE(1) ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                        .Display();

                        /*" -1784- DISPLAY ' FONTE: ' RCAPS-COD-FONTE */
                        _.Display($" FONTE: {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -1785- DISPLAY ' NUM RCAPS: ' RCAPS-NUM-RCAP */
                        _.Display($" NUM RCAPS: {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1786- DISPLAY '***' */
                        _.Display($"***");

                        /*" -1787- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1788- END-IF */
                    }


                    /*" -1789- END-IF */
                }


                /*" -1792- END-IF */
            }


            /*" -1793- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1812- PERFORM M_135B3_00_RCAPS_COMP_DB_SELECT_2 */

            M_135B3_00_RCAPS_COMP_DB_SELECT_2();

            /*" -1815- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1816- MOVE 002 TO N88-RCAP */
                _.Move(002, WS_WORKING.WS_NIVEIS_88.N88_RCAP);

                /*" -1817- ELSE */
            }
            else
            {


                /*" -1818- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1819- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1820- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1821- DISPLAY ' 135B3-00-RCAPS-COMP     ' */
                    _.Display($" 135B3-00-RCAPS-COMP     ");

                    /*" -1822- DISPLAY ' ERRO SEL RCAP_COMPLE(2) (' WS-SQLCODE ')' */

                    $" ERRO SEL RCAP_COMPLE(2) ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1823- DISPLAY ' FONTE: ' RCAPS-COD-FONTE */
                    _.Display($" FONTE: {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                    /*" -1824- DISPLAY ' NUM RCAPS: ' RCAPS-NUM-RCAP */
                    _.Display($" NUM RCAPS: {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                    /*" -1825- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1826- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1827- END-IF */
                }


                /*" -1829- END-IF */
            }


            /*" -1829- . */

        }

        [StopWatch]
        /*" M-135B3-00-RCAPS-COMP-DB-SELECT-1 */
        public void M_135B3_00_RCAPS_COMP_DB_SELECT_1()
        {
            /*" -1764- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, VAL_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-VAL-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC */

            var m_135B3_00_RCAPS_COMP_DB_SELECT_1_Query1 = new M_135B3_00_RCAPS_COMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = M_135B3_00_RCAPS_COMP_DB_SELECT_1_Query1.Execute(m_135B3_00_RCAPS_COMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B3_99_SAIDA*/

        [StopWatch]
        /*" M-135B3-00-RCAPS-COMP-DB-SELECT-2 */
        public void M_135B3_00_RCAPS_COMP_DB_SELECT_2()
        {
            /*" -1812- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, VAL_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-VAL-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC */

            var m_135B3_00_RCAPS_COMP_DB_SELECT_2_Query1 = new M_135B3_00_RCAPS_COMP_DB_SELECT_2_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = M_135B3_00_RCAPS_COMP_DB_SELECT_2_Query1.Execute(m_135B3_00_RCAPS_COMP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
            }


        }

        [StopWatch]
        /*" M-135B5-00-OBTER-SICOB-SECTION */
        private void M_135B5_00_OBTER_SICOB_SECTION()
        {
            /*" -1839- MOVE '135B5-00-OBTER-SICOB' TO PARAGRAFO */
            _.Move("135B5-00-OBTER-SICOB", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1840- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1843- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1844- DISPLAY 'IND-SIC: ' IND-SIC */
            _.Display($"IND-SIC: {WS_WORKING.INDEXADORES.IND_SIC}");

            /*" -1847- MOVE R3-NUM-PROPOSTA TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -1860- PERFORM M_135B5_00_OBTER_SICOB_DB_SELECT_1 */

            M_135B5_00_OBTER_SICOB_DB_SELECT_1();

            /*" -1866- DISPLAY 'SEL CONVERSAO_SICOB: ' R3-NUM-PROPOSTA '/' NUM-SICOB OF DCLCONVERSAO-SICOB ' SQLCODE: ' SQLCODE */

            $"SEL CONVERSAO_SICOB: {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}/{COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1867- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1868- DISPLAY 'NUM-SICOB: ' NUM-SICOB OF DCLCONVERSAO-SICOB */
                _.Display($"NUM-SICOB: {COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB}");

                /*" -1870- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO WS-NUM-SICOB */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, WS_WORKING.WS_AUXILIARES.WS_NUM_SICOB);

                /*" -1871- MOVE 'S' TO N88-GRAVOU-SICOB */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_GRAVOU_SICOB);

                /*" -1872- GO TO 135B5-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B5_99_SAIDA*/ //GOTO
                return;

                /*" -1873- ELSE */
            }
            else
            {


                /*" -1874- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1875- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1876- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1877- DISPLAY ' 135B5-00-OBTER-SICOB    ' */
                    _.Display($" 135B5-00-OBTER-SICOB    ");

                    /*" -1878- DISPLAY ' ERRO SEL CONVERSAO_SICO (' WS-SQLCODE ')' */

                    $" ERRO SEL CONVERSAO_SICO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1879- DISPLAY ' PROPOSTA: ' R3-NUM-PROPOSTA */
                    _.Display($" PROPOSTA: {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                    /*" -1880- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1881- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1882- END-IF */
                }


                /*" -1885- END-IF */
            }


            /*" -1886- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1894- PERFORM M_135B5_00_OBTER_SICOB_DB_SELECT_2 */

            M_135B5_00_OBTER_SICOB_DB_SELECT_2();

            /*" -1899- DISPLAY 'SEL CEDENTE: 26 ' '/' CEDENTE-NUM-TITULO OF DCLCEDENTE ' SQLCODE: ' SQLCODE */

            $"SEL CEDENTE: 26 /{CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1901- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1902- DISPLAY '***' */
                _.Display($"***");

                /*" -1903- DISPLAY ' 135B5-00-OBTER-SICOB    ' */
                _.Display($" 135B5-00-OBTER-SICOB    ");

                /*" -1904- DISPLAY ' ERRO SEL CEDENTE (' WS-SQLCODE ')' */

                $" ERRO SEL CEDENTE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1905- DISPLAY ' CEDENTE: 26' */
                _.Display($" CEDENTE: 26");

                /*" -1906- DISPLAY '***' */
                _.Display($"***");

                /*" -1907- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1910- END-IF */
            }


            /*" -1911- MOVE CEDENTE-NUM-TITULO TO WS-NUM-TIT-CED */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WS_WORKING.WS_AUXILIARES.WS_NUM_TIT_CED);

            /*" -1912- ADD 001 TO WS-SEQ-TIT-CED */
            WS_WORKING.WS_AUXILIARES.FILLER_10.WS_SEQ_TIT_CED.Value = WS_WORKING.WS_AUXILIARES.FILLER_10.WS_SEQ_TIT_CED + 001;

            /*" -1914- MOVE WS-SEQ-TIT-CED TO DPARM01 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_10.WS_SEQ_TIT_CED, DPARM01X.DPARM01);

            /*" -1915- DISPLAY 'CALL PROTIT01' */
            _.Display($"CALL PROTIT01");

            /*" -1916- MOVE 'CALL' TO COMANDO */
            _.Move("CALL", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1918- CALL 'PROTIT01' USING DPARM01X */
            _.Call("PROTIT01", DPARM01X);

            /*" -1919- IF DPARM01-RC NOT EQUAL ZEROS */

            if (DPARM01X.DPARM01_RC != 00)
            {

                /*" -1920- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1921- DISPLAY '***' */
                _.Display($"***");

                /*" -1922- DISPLAY ' 135B5-00-OBTER-SICOB      ' */
                _.Display($" 135B5-00-OBTER-SICOB      ");

                /*" -1923- DISPLAY ' ERRO CALL PROTIT01 (' DPARM01-RC ')' */

                $" ERRO CALL PROTIT01 ({DPARM01X.DPARM01_RC})"
                .Display();

                /*" -1924- DISPLAY ' SEQUENCIA: ' WS-SEQ-TIT-CED */
                _.Display($" SEQUENCIA: {WS_WORKING.WS_AUXILIARES.FILLER_10.WS_SEQ_TIT_CED}");

                /*" -1925- DISPLAY '***' */
                _.Display($"***");

                /*" -1926- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1927- END-IF */
            }


            /*" -1929- DISPLAY 'VOLTA CALL PROTIT01' */
            _.Display($"VOLTA CALL PROTIT01");

            /*" -1932- MOVE DPARM01-D1 TO WS-DIG-TIT-CED */
            _.Move(DPARM01X.DPARM01_D1, WS_WORKING.WS_AUXILIARES.FILLER_10.WS_DIG_TIT_CED);

            /*" -1933- DISPLAY 'NOVO TITULO: ' WS-NUM-TIT-CED */
            _.Display($"NOVO TITULO: {WS_WORKING.WS_AUXILIARES.WS_NUM_TIT_CED}");

            /*" -1935- IF WS-NUM-TIT-CED LESS CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */

            if (WS_WORKING.WS_AUXILIARES.WS_NUM_TIT_CED < CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX)
            {

                /*" -1937- MOVE WS-NUM-TIT-CED TO CEDENTE-NUM-TITULO OF DCLCEDENTE */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_NUM_TIT_CED, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

                /*" -1938- ELSE */
            }
            else
            {


                /*" -1939- DISPLAY '***' */
                _.Display($"***");

                /*" -1940- DISPLAY ' 135B5-00-OBTER-SICOB      ' */
                _.Display($" 135B5-00-OBTER-SICOB      ");

                /*" -1941- DISPLAY ' ERRO CALCULO TIT DO CEDENTE' */
                _.Display($" ERRO CALCULO TIT DO CEDENTE");

                /*" -1942- DISPLAY ' NOVO TITULO: ' WS-NUM-TIT-CED */
                _.Display($" NOVO TITULO: {WS_WORKING.WS_AUXILIARES.WS_NUM_TIT_CED}");

                /*" -1944- DISPLAY ' MAX  TITULO: ' CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */
                _.Display($" MAX  TITULO: {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX}");

                /*" -1945- DISPLAY '***' */
                _.Display($"***");

                /*" -1946- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1949- END-IF */
            }


            /*" -1950- MOVE 'UPDATE' TO COMANDO */
            _.Move("UPDATE", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1954- PERFORM M_135B5_00_OBTER_SICOB_DB_UPDATE_1 */

            M_135B5_00_OBTER_SICOB_DB_UPDATE_1();

            /*" -1959- DISPLAY 'UPD CEDENTE: 26 ' '/' CEDENTE-NUM-TITULO OF DCLCEDENTE ' SQLCODE: ' SQLCODE */

            $"UPD CEDENTE: 26 /{CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1960- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1961- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1962- DISPLAY '***' */
                _.Display($"***");

                /*" -1963- DISPLAY ' 135B5-00-OBTER-SICOB    ' */
                _.Display($" 135B5-00-OBTER-SICOB    ");

                /*" -1964- DISPLAY ' ERRO UPD CEDENTE (' WS-SQLCODE ')' */

                $" ERRO UPD CEDENTE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1965- DISPLAY ' CEDENTE: 26' */
                _.Display($" CEDENTE: 26");

                /*" -1966- DISPLAY '***' */
                _.Display($"***");

                /*" -1967- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1971- END-IF */
            }


            /*" -1973- MOVE R3-NUM-PROPOSTA TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -1975- MOVE R3-COD-PRODUTO TO PRODUTO-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF);

            /*" -1976- MOVE R3-DTQITBCO TO WS-DATA-DDMMAAAA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

            /*" -1977- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

            /*" -1978- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

            /*" -1979- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
            _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

            /*" -1982- MOVE WS-DATA-DB2 TO DATA-QUITACAO OF DCLCONVERSAO-SICOB */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);

            /*" -1985- MOVE R3-AGEPGTO TO AGEPGTO OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO);

            /*" -1988- MOVE R3-VAL-PAGO TO VAL-RCAP OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);

            /*" -1991- MOVE PRDSIVPF-COD-EMPRESA-SIVPF TO COD-EMPRESA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF);

            /*" -1994- MOVE WS-DATA-PROC TO DATA-OPERACAO OF DCLCONVERSAO-SICOB */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_PROC, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);

            /*" -1997- MOVE 'BI1610B' TO COD-USUARIO OF DCLCONVERSAO-SICOB */
            _.Move("BI1610B", COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO);

            /*" -2001- MOVE WS-NUM-TIT-CED TO WS-NUM-SICOB NUM-SICOB OF DCLCONVERSAO-SICOB */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_NUM_TIT_CED, WS_WORKING.WS_AUXILIARES.WS_NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

            /*" -2002- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2014- PERFORM M_135B5_00_OBTER_SICOB_DB_INSERT_1 */

            M_135B5_00_OBTER_SICOB_DB_INSERT_1();

            /*" -2021- DISPLAY 'INS CONVERSAO_SICOB: ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB '/' NUM-SICOB OF DCLCONVERSAO-SICOB ' SQLCODE: ' SQLCODE */

            $"INS CONVERSAO_SICOB: {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}/{COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2022- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2023- ADD 001 TO AC-QTD-CSI-GRV */
                WS_WORKING.AC_CONTADORES.AC_QTD_CSI_GRV.Value = WS_WORKING.AC_CONTADORES.AC_QTD_CSI_GRV + 001;

                /*" -2024- MOVE 'S' TO N88-GRAVOU-SICOB */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_GRAVOU_SICOB);

                /*" -2025- ELSE */
            }
            else
            {


                /*" -2026- IF SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != -803)
                {

                    /*" -2027- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -2028- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2029- DISPLAY ' 135B5-00-OBTER-SICOB     ' */
                    _.Display($" 135B5-00-OBTER-SICOB     ");

                    /*" -2030- DISPLAY ' ERRO INS CONVERSAO_SICOB (' WS-SQLCODE ')' */

                    $" ERRO INS CONVERSAO_SICOB ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -2031- DISPLAY ' PROPOSTA: ' R3-NUM-PROPOSTA */
                    _.Display($" PROPOSTA: {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                    /*" -2032- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2033- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2034- END-IF */
                }


                /*" -2036- END-IF */
            }


            /*" -2036- . */

        }

        [StopWatch]
        /*" M-135B5-00-OBTER-SICOB-DB-SELECT-1 */
        public void M_135B5_00_OBTER_SICOB_DB_SELECT_1()
        {
            /*" -1860- EXEC SQL SELECT VALUE(NUM_SICOB,0) DATA_OPERACAO, DATA_QUITACAO, VAL_RCAP INTO :DCLCONVERSAO-SICOB.NUM-SICOB , :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF WITH UR END-EXEC */

            var m_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1 = new M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1.Execute(m_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);
                _.Move(executed_1.DATA_OPERACAO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);
                _.Move(executed_1.DATA_QUITACAO, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);
                _.Move(executed_1.VAL_RCAP, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B5_99_SAIDA*/

        [StopWatch]
        /*" M-135B5-00-OBTER-SICOB-DB-UPDATE-1 */
        public void M_135B5_00_OBTER_SICOB_DB_UPDATE_1()
        {
            /*" -1954- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :DCLCEDENTE.CEDENTE-NUM-TITULO WHERE COD_CEDENTE = 026 END-EXEC. */

            var m_135B5_00_OBTER_SICOB_DB_UPDATE_1_Update1 = new M_135B5_00_OBTER_SICOB_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
            };

            M_135B5_00_OBTER_SICOB_DB_UPDATE_1_Update1.Execute(m_135B5_00_OBTER_SICOB_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-135B5-00-OBTER-SICOB-DB-INSERT-1 */
        public void M_135B5_00_OBTER_SICOB_DB_INSERT_1()
        {
            /*" -2014- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF, :DCLCONVERSAO-SICOB.NUM-SICOB, :DCLCONVERSAO-SICOB.COD-EMPRESA-SIVPF, :DCLCONVERSAO-SICOB.PRODUTO-SIVPF, :DCLCONVERSAO-SICOB.AGEPGTO, :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP, :DCLCONVERSAO-SICOB.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var m_135B5_00_OBTER_SICOB_DB_INSERT_1_Insert1 = new M_135B5_00_OBTER_SICOB_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
                NUM_SICOB = COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB.ToString(),
                COD_EMPRESA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF.ToString(),
                PRODUTO_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF.ToString(),
                AGEPGTO = COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO.ToString(),
                DATA_OPERACAO = COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO.ToString(),
                DATA_QUITACAO = COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO.ToString(),
                VAL_RCAP = COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP.ToString(),
                COD_USUARIO = COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO.ToString(),
            };

            M_135B5_00_OBTER_SICOB_DB_INSERT_1_Insert1.Execute(m_135B5_00_OBTER_SICOB_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-135B5-00-OBTER-SICOB-DB-SELECT-2 */
        public void M_135B5_00_OBTER_SICOB_DB_SELECT_2()
        {
            /*" -1894- EXEC SQL SELECT NUM_TITULO, NUM_TITULO_MAX INTO :DCLCEDENTE.CEDENTE-NUM-TITULO, :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 026 WITH UR END-EXEC */

            var m_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1 = new M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1.Execute(m_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
                _.Move(executed_1.CEDENTE_NUM_TITULO_MAX, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX);
            }


        }

        [StopWatch]
        /*" M-135B7-00-AVALIACAO-RISCO-SECTION */
        private void M_135B7_00_AVALIACAO_RISCO_SECTION()
        {
            /*" -2046- MOVE '135B7-00-AVALIACAO-RIS' TO PARAGRAFO */
            _.Move("135B7-00-AVALIACAO-RIS", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2047- MOVE '135B7' TO COMANDO */
            _.Move("135B7", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2050- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2051- MOVE '%' TO N88-TEM-RISCO */
            _.Move("%", WS_WORKING.WS_NIVEIS_88.N88_TEM_RISCO);

            /*" -2052- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -2054- MOVE 'BI1610B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("BI1610B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -2055- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -2057- MOVE R3-NUM-PROPOSTA TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -2059- MOVE ZEROS TO LK-VG009-IND-ERRO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO, SPVG009W.LK_VG009_SQLCODE);

            /*" -2063- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA, SPVG009W.LK_VG009_SQLERRMC);

            /*" -2065- MOVE 'SPBVG009' TO WS-PGM-CALL */
            _.Move("SPBVG009", WS_WORKING.WS_AUXILIARES.WS_PGM_CALL);

            /*" -2066- MOVE 'CALL' TO COMANDO */
            _.Move("CALL", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2087- CALL WS-PGM-CALL USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_WORKING.WS_AUXILIARES.WS_PGM_CALL, SPVG009W);

            /*" -2088- IF LK-VG009-IND-ERRO EQUAL ZEROS */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -2089- MOVE 'S' TO N88-TEM-RISCO */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_TEM_RISCO);

                /*" -2090- ELSE */
            }
            else
            {


                /*" -2092- IF LK-VG009-IND-ERRO EQUAL 1 AND LK-VG009-SQLCODE EQUAL +100 */

                if (SPVG009W.LK_VG009_IND_ERRO == 1 && SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -2093- MOVE 'N' TO N88-TEM-RISCO */
                    _.Move("N", WS_WORKING.WS_NIVEIS_88.N88_TEM_RISCO);

                    /*" -2094- ELSE */
                }
                else
                {


                    /*" -2095- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -2096- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2097- DISPLAY ' 135B7-00-AVALIACAO-RIS ' */
                    _.Display($" 135B7-00-AVALIACAO-RIS ");

                    /*" -2098- DISPLAY ' ERRO ACESSO SPBVG009 (' WS-SQLCODE ')' */

                    $" ERRO ACESSO SPBVG009 ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -2099- DISPLAY ' IND ERRO: ' LK-VG009-IND-ERRO */
                    _.Display($" IND ERRO: {SPVG009W.LK_VG009_IND_ERRO}");

                    /*" -2100- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2101- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2102- END-IF */
                }


                /*" -2104- END-IF */
            }


            /*" -2104- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135B7_99_SAIDA*/

        [StopWatch]
        /*" M-135D0-00-SASSE-BIL-SECTION */
        private void M_135D0_00_SASSE_BIL_SECTION()
        {
            /*" -2114- MOVE '135D0-00-SASSE-BIL     ' TO PARAGRAFO */
            _.Move("135D0-00-SASSE-BIL     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2115- MOVE '135D0' TO COMANDO */
            _.Move("135D0", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2118- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2121- MOVE R3-TIPO-RESIDENCIA TO GETPMOIM-NUM-TP-MORA-IMOVEL */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_RESIDENCIA, GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL);

            /*" -2122- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2128- PERFORM M_135D0_00_SASSE_BIL_DB_SELECT_1 */

            M_135D0_00_SASSE_BIL_DB_SELECT_1();

            /*" -2133- DISPLAY 'SEL GE_TP_MORAD_IMOVEL: ' GETPMOIM-NUM-TP-MORA-IMOVEL ' SQLCODE: ' SQLCODE */

            $"SEL GE_TP_MORAD_IMOVEL: {GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2134- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2135- MOVE ZEROS TO GETPMOIM-NUM-TP-MORA-IMOVEL */
                _.Move(0, GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL);

                /*" -2136- ELSE */
            }
            else
            {


                /*" -2137- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2138- DISPLAY '***' */
                _.Display($"***");

                /*" -2139- DISPLAY ' 135D0-00-SASSE-BIL        ' */
                _.Display($" 135D0-00-SASSE-BIL        ");

                /*" -2140- DISPLAY ' ERRO SEL GE_TP_MORAD_IMOVEL (' WS-SQLCODE ')' */

                $" ERRO SEL GE_TP_MORAD_IMOVEL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2141- DISPLAY ' TIPO RESIDENCIA: ' R3-TIPO-RESIDENCIA */
                _.Display($" TIPO RESIDENCIA: {LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_RESIDENCIA}");

                /*" -2142- DISPLAY '***' */
                _.Display($"***");

                /*" -2143- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2146- END-IF */
            }


            /*" -2148- MOVE BI0004L-S-COD-IDE TO PROPSSBI-NUM-IDENTIFICACAO */
            _.Move(BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_IDE, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO);

            /*" -2151- MOVE R3-RENOVACAO-AUTOM TO PROPSSBI-RENOVACAO-AUTOM */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM);

            /*" -2152- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2160- PERFORM M_135D0_00_SASSE_BIL_DB_INSERT_1 */

            M_135D0_00_SASSE_BIL_DB_INSERT_1();

            /*" -2165- DISPLAY 'INS PROP_SASSE_BILHETE: ' PROPSSBI-NUM-IDENTIFICACAO ' SQLCODE: ' SQLCODE */

            $"INS PROP_SASSE_BILHETE: {PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2166- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2167- ADD 001 TO AC-QTD-SAS-GRV */
                WS_WORKING.AC_CONTADORES.AC_QTD_SAS_GRV.Value = WS_WORKING.AC_CONTADORES.AC_QTD_SAS_GRV + 001;

                /*" -2168- ELSE */
            }
            else
            {


                /*" -2169- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2170- DISPLAY '***' */
                _.Display($"***");

                /*" -2171- DISPLAY ' 135D0-00-SASSE-BIL        ' */
                _.Display($" 135D0-00-SASSE-BIL        ");

                /*" -2172- DISPLAY ' ERRO INS PROP_SASSE_BILHETE (' WS-SQLCODE ')' */

                $" ERRO INS PROP_SASSE_BILHETE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2173- DISPLAY ' IDENTIFICACAO: ' PROPSSBI-NUM-IDENTIFICACAO */
                _.Display($" IDENTIFICACAO: {PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO}");

                /*" -2174- DISPLAY '***' */
                _.Display($"***");

                /*" -2175- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2177- END-IF */
            }


            /*" -2177- . */

        }

        [StopWatch]
        /*" M-135D0-00-SASSE-BIL-DB-SELECT-1 */
        public void M_135D0_00_SASSE_BIL_DB_SELECT_1()
        {
            /*" -2128- EXEC SQL SELECT DES_TP_MORA_IMOVEL INTO :GETPMOIM-DES-TP-MORA-IMOVEL FROM SEGUROS.GE_TP_MORAD_IMOVEL WHERE NUM_TP_MORA_IMOVEL = :GETPMOIM-NUM-TP-MORA-IMOVEL WITH UR END-EXEC */

            var m_135D0_00_SASSE_BIL_DB_SELECT_1_Query1 = new M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1()
            {
                GETPMOIM_NUM_TP_MORA_IMOVEL = GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL.ToString(),
            };

            var executed_1 = M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1.Execute(m_135D0_00_SASSE_BIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GETPMOIM_DES_TP_MORA_IMOVEL, GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_DES_TP_MORA_IMOVEL);
            }


        }

        [StopWatch]
        /*" M-135D0-00-SASSE-BIL-DB-INSERT-1 */
        public void M_135D0_00_SASSE_BIL_DB_INSERT_1()
        {
            /*" -2160- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES (:DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-IDENTIFICACAO , :DCLPROP-SASSE-BILHETE.PROPSSBI-RENOVACAO-AUTOM , 'BI1610B' , CURRENT TIMESTAMP , NULL , :GETPMOIM-NUM-TP-MORA-IMOVEL ) END-EXEC */

            var m_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1 = new M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1()
            {
                PROPSSBI_NUM_IDENTIFICACAO = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO.ToString(),
                PROPSSBI_RENOVACAO_AUTOM = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM.ToString(),
                GETPMOIM_NUM_TP_MORA_IMOVEL = GETPMOIM.DCLGE_TP_MORAD_IMOVEL.GETPMOIM_NUM_TP_MORA_IMOVEL.ToString(),
            };

            M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1.Execute(m_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135D0_99_SAIDA*/

        [StopWatch]
        /*" M-135F0-00-HIST-FIDELIZACAO-SECTION */
        private void M_135F0_00_HIST_FIDELIZACAO_SECTION()
        {
            /*" -2187- MOVE '135F0-00-HIST-FIDELIZAC' TO PARAGRAFO */
            _.Move("135F0-00-HIST-FIDELIZAC", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2188- MOVE '135D0' TO COMANDO */
            _.Move("135D0", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2191- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2193- MOVE BI0004L-S-COD-IDE TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_IDE, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -2194- MOVE WS-DATA-PROC TO PROPFIDH-DATA-SITUACAO */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_PROC, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -2195- MOVE RH-NSAS TO PROPFIDH-NSAS-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -2196- MOVE AC-QTD-REG-TP3 TO PROPFIDH-NSL */
            _.Move(WS_WORKING.AC_CONTADORES.AC_QTD_REG_TP3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -2197- MOVE R3-SIT-PROPOSTA TO PROPFIDH-SIT-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -2198- MOVE R3-SIT-COBRANCA TO PROPFIDH-SIT-COBRANCA-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -2199- MOVE R3-SIT-MOTIVO TO PROPFIDH-SIT-MOTIVO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -2200- MOVE R3-COD-PRODUTO TO PROPFIDH-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -2203- MOVE 001 TO PROPFIDH-COD-EMPRESA-SIVPF */
            _.Move(001, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -2204- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2225- PERFORM M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1 */

            M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -2231- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2232- ADD 001 TO AC-QTD-HPF-GRV */
                WS_WORKING.AC_CONTADORES.AC_QTD_HPF_GRV.Value = WS_WORKING.AC_CONTADORES.AC_QTD_HPF_GRV + 001;

                /*" -2233- ELSE */
            }
            else
            {


                /*" -2234- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2235- DISPLAY '***' */
                _.Display($"***");

                /*" -2236- DISPLAY ' 135F0-00-HIST-FIDELIZACAO ' */
                _.Display($" 135F0-00-HIST-FIDELIZACAO ");

                /*" -2237- DISPLAY ' ERRO INS HIST_PROP_FIDELIZ  (' WS-SQLCODE ')' */

                $" ERRO INS HIST_PROP_FIDELIZ  ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2238- DISPLAY ' IDENTIFICACAO: ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($" IDENTIFICACAO: {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -2239- DISPLAY '***' */
                _.Display($"***");

                /*" -2240- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2242- END-IF */
            }


            /*" -2242- . */

        }

        [StopWatch]
        /*" M-135F0-00-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -2225- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ ( NUM_IDENTIFICACAO , DATA_SITUACAO , NSAS_SIVPF , NSL , SIT_PROPOSTA , SIT_COBRANCA_SIVPF , SIT_MOTIVO_SIVPF , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF ) VALUES (:PROPFIDH-NUM-IDENTIFICACAO, :PROPFIDH-DATA-SITUACAO, :PROPFIDH-NSAS-SIVPF, :PROPFIDH-NSL, :PROPFIDH-SIT-PROPOSTA, :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF, :PROPFIDH-COD-EMPRESA-SIVPF, :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC */

            var m_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_COD_EMPRESA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF.ToString(),
                PROPFIDH_COD_PRODUTO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF.ToString(),
            };

            M_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(m_135F0_00_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135F0_99_SAIDA*/

        [StopWatch]
        /*" M-13700-00-BENEFICIARIO-SECTION */
        private void M_13700_00_BENEFICIARIO_SECTION()
        {
            /*" -2252- MOVE '13700-00-BENEFICIARIOS ' TO PARAGRAFO */
            _.Move("13700-00-BENEFICIARIOS ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2253- MOVE 'SELECT' TO COMANDO */
            _.Move("SELECT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2256- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2258- MOVE TAB-REG-PROPOSTA(IND-PRO) TO REG-BENEFIC */
            _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO], LBFPF014.REG_BENEFIC);

            /*" -2261- MOVE R3-NUM-SICOB TO NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL);

            /*" -2268- PERFORM M_13700_00_BENEFICIARIO_DB_SELECT_1 */

            M_13700_00_BENEFICIARIO_DB_SELECT_1();

            /*" -2272- DISPLAY 'SEL MAX BENEF_PROP_AZUL ' R3-NUM-SICOB ' SQLCODE: ' SQLCODE */

            $"SEL MAX BENEF_PROP_AZUL {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2273- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2274- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2275- DISPLAY '***' */
                _.Display($"***");

                /*" -2276- DISPLAY ' 13700-00-BENEFICIARIO  ' */
                _.Display($" 13700-00-BENEFICIARIO  ");

                /*" -2277- DISPLAY ' ERRO MAX BENEF_PROP_AZUL (' WS-SQLCODE ')' */

                $" ERRO MAX BENEF_PROP_AZUL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2278- DISPLAY '***' */
                _.Display($"***");

                /*" -2279- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2282- END-IF */
            }


            /*" -2285- ADD 001 TO NUM-BENEFICIARIO OF DCLBENEF-PROP-AZUL */
            BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO.Value = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO + 001;

            /*" -2288- MOVE R4-NOME TO NOME-BENEFICIARIO OF DCLBENEF-PROP-AZUL */
            _.Move(LBFPF014.REG_BENEFIC.R4_NOME, BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO);

            /*" -2290- IF R4-GRAU-PARENTESCO LESS 001 OR R4-GRAU-PARENTESCO GREATER 007 */

            if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO < 001 || LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO > 007)
            {

                /*" -2292- MOVE 'ERRO PF' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                _.Move("ERRO PF", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                /*" -2293- ELSE */
            }
            else
            {


                /*" -2295- MOVE TAB-LIT-BEN(R4-GRAU-PARENTESCO) TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                _.Move(FILLER_28.TAB_LIT_BEN[LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO], BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                /*" -2296- IF R4-GRAU-PARENTESCO EQUAL 006 */

                if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 006)
                {

                    /*" -2297- IF R4-DESCR-PARENTESCO NOT EQUAL SPACES */

                    if (!LBFPF014.REG_BENEFIC.R4_DESCR_PARENTESCO.IsEmpty())
                    {

                        /*" -2299- MOVE R4-DESCR-PARENTESCO TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                        _.Move(LBFPF014.REG_BENEFIC.R4_DESCR_PARENTESCO, BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                        /*" -2300- END-IF */
                    }


                    /*" -2301- END-IF */
                }


                /*" -2303- END-IF */
            }


            /*" -2306- MOVE R4-PCT-PARTICIP TO PCT-PART-BENEFICIA OF DCLBENEF-PROP-AZUL */
            _.Move(LBFPF014.REG_BENEFIC.R4_PCT_PARTICIP, BENPROPZ.DCLBENEF_PROP_AZUL.PCT_PART_BENEFICIA);

            /*" -2307- IF R4-DATA-NASCIMENTO EQUAL ZEROS */

            if (LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO == 00)
            {

                /*" -2308- MOVE -001 TO VIND-DAT-NAS */
                _.Move(-001, WS_WORKING.WS_AUXILIARES.VIND_DAT_NAS);

                /*" -2309- ELSE */
            }
            else
            {


                /*" -2310- MOVE R4-DATA-NASCIMENTO TO WS-DATA-DDMMAAAA */
                _.Move(LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO, WS_WORKING.WS_AUXILIARES.WS_DATA_DDMMAAAA);

                /*" -2311- MOVE WS-DIA-DDMMAAAA TO WS-DIA-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_DIA_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_DIA_DB2);

                /*" -2312- MOVE WS-MES-DDMMAAAA TO WS-MES-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_MES_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_MES_DB2);

                /*" -2313- MOVE WS-ANO-DDMMAAAA TO WS-ANO-DB2 */
                _.Move(WS_WORKING.WS_AUXILIARES.FILLER_5.WS_ANO_DDMMAAAA, WS_WORKING.WS_AUXILIARES.FILLER_6.WS_ANO_DB2);

                /*" -2315- MOVE WS-DATA-DB2 TO DATA-NASCIMENTO OF DCLBENEF-PROP-AZUL */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_DATA_DB2, BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO);

                /*" -2317- END-IF */
            }


            /*" -2318- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2330- PERFORM M_13700_00_BENEFICIARIO_DB_INSERT_1 */

            M_13700_00_BENEFICIARIO_DB_INSERT_1();

            /*" -2335- DISPLAY 'INS BENEF_PROP_AZUL: ' NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL ' SQLCODE: ' SQLCODE */

            $"INS BENEF_PROP_AZUL: {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2336- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2337- ADD 001 TO AC-QTD-BEN-GRV */
                WS_WORKING.AC_CONTADORES.AC_QTD_BEN_GRV.Value = WS_WORKING.AC_CONTADORES.AC_QTD_BEN_GRV + 001;

                /*" -2338- ELSE */
            }
            else
            {


                /*" -2339- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2340- DISPLAY '***' */
                _.Display($"***");

                /*" -2341- DISPLAY ' 13700-00-BENEFICIARIO  ' */
                _.Display($" 13700-00-BENEFICIARIO  ");

                /*" -2342- DISPLAY ' ERRO INS BENEF_PROP_AZUL (' WS-SQLCODE ')' */

                $" ERRO INS BENEF_PROP_AZUL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2344- DISPLAY ' PROPOSTA: ' NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL */
                _.Display($" PROPOSTA: {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL}");

                /*" -2345- DISPLAY '***' */
                _.Display($"***");

                /*" -2346- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2348- END-IF */
            }


            /*" -2348- . */

        }

        [StopWatch]
        /*" M-13700-00-BENEFICIARIO-DB-SELECT-1 */
        public void M_13700_00_BENEFICIARIO_DB_SELECT_1()
        {
            /*" -2268- EXEC SQL SELECT VALUE(MAX(NUM_BENEFICIARIO),0) INTO :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO FROM SEGUROS.BENEF_PROP_AZUL WHERE NUM_PROPOSTA_AZUL = :DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL WITH UR END-EXEC */

            var m_13700_00_BENEFICIARIO_DB_SELECT_1_Query1 = new M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_AZUL = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL.ToString(),
            };

            var executed_1 = M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1.Execute(m_13700_00_BENEFICIARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_BENEFICIARIO, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO);
            }


        }

        [StopWatch]
        /*" M-13700-00-BENEFICIARIO-DB-INSERT-1 */
        public void M_13700_00_BENEFICIARIO_DB_INSERT_1()
        {
            /*" -2330- EXEC SQL INSERT INTO SEGUROS.BENEF_PROP_AZUL VALUES (:DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL, :DCLBENEF-PROP-AZUL.COD-AGENCIA-LOTE, :DCLBENEF-PROP-AZUL.DATA-LOTE, :DCLBENEF-PROP-AZUL.NUM-LOTE, :DCLBENEF-PROP-AZUL.NUM-SEQ-LOTE, :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO, :DCLBENEF-PROP-AZUL.NOME-BENEFICIARIO, :DCLBENEF-PROP-AZUL.GRAU-PARENTESCO, :DCLBENEF-PROP-AZUL.PCT-PART-BENEFICIA, :DCLBENEF-PROP-AZUL.DATA-NASCIMENTO:VIND-DAT-NAS) END-EXEC */

            var m_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1 = new M_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_AZUL = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL.ToString(),
                COD_AGENCIA_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.COD_AGENCIA_LOTE.ToString(),
                DATA_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.DATA_LOTE.ToString(),
                NUM_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_LOTE.ToString(),
                NUM_SEQ_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_SEQ_LOTE.ToString(),
                NUM_BENEFICIARIO = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO.ToString(),
                NOME_BENEFICIARIO = BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO.ToString(),
                GRAU_PARENTESCO = BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO.ToString(),
                PCT_PART_BENEFICIA = BENPROPZ.DCLBENEF_PROP_AZUL.PCT_PART_BENEFICIA.ToString(),
                DATA_NASCIMENTO = BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO.ToString(),
                VIND_DAT_NAS = WS_WORKING.WS_AUXILIARES.VIND_DAT_NAS.ToString(),
            };

            M_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1.Execute(m_13700_00_BENEFICIARIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13700_99_SAIDA*/

        [StopWatch]
        /*" M-13900-00-NOME-SOCIAL-SECTION */
        private void M_13900_00_NOME_SOCIAL_SECTION()
        {
            /*" -2358- MOVE '13900-00-NOME-SOCIAL   ' TO PARAGRAFO */
            _.Move("13900-00-NOME-SOCIAL   ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2359- MOVE 'INSERT' TO COMANDO */
            _.Move("INSERT", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2362- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2364- MOVE TAB-REG-PROPOSTA(IND-PRO) TO REG-TIPO-D */
            _.Move(TABELA_PROPOSTA.TAB_REG_PROPOSTA[WS_WORKING.INDEXADORES.IND_PRO], LXFPF028.REG_TIPO_D);

            /*" -2367- IF RSD-NOME-SOCIAL EQUAL SPACES OR RSD-NOME-SOCIAL EQUAL LOW-VALUES OR RSD-NOME-SOCIAL EQUAL HIGH-VALUES */

            if (LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL.IsEmpty() || LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL.IsLowValues() || LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL.IsHighValues)
            {

                /*" -2368- ADD 001 TO AC-QTD-NSO-IGN */
                WS_WORKING.AC_CONTADORES.AC_QTD_NSO_IGN.Value = WS_WORKING.AC_CONTADORES.AC_QTD_NSO_IGN + 001;

                /*" -2369- GO TO 13900-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13900_99_SAIDA*/ //GOTO
                return;

                /*" -2372- END-IF */
            }


            /*" -2373- MOVE '*' TO LK-GE053-E-TRACE */
            _.Move("*", SPGE053W.LK_GE053_E_TRACE);

            /*" -2374- MOVE 'PF' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("PF", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -2375- MOVE 1 TO LK-GE053-E-IND-OPERACAO */
            _.Move(1, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -2376- MOVE R1-CGC-CPF TO LK-GE053-I-NUM-CPF */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -2378- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-OPERACAO */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_OPERACAO);

            /*" -2379- MOVE RSD-NOME-SOCIAL TO LK-GE053-I-NOM-SOCIAL */
            _.Move(LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL, SPGE053W.LK_GE053_I_NOM_SOCIAL);

            /*" -2380- MOVE 'I' TO LK-GE053-I-IND-TIPO-ACAO */
            _.Move("I", SPGE053W.LK_GE053_I_IND_TIPO_ACAO);

            /*" -2381- MOVE 'S' TO LK-GE053-I-IND-USA-NOME-SOCIAL */
            _.Move("S", SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL);

            /*" -2382- MOVE 1 TO LK-GE053-I-COD-TP-PES-NEGOCIO */
            _.Move(1, SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO);

            /*" -2383- MOVE RSD-NUM-PROPOSTA TO LK-GE053-I-NUM-PROPOSTA */
            _.Move(LXFPF028.REG_TIPO_D.RSD_NUM_PROPOSTA, SPGE053W.LK_GE053_I_NUM_PROPOSTA);

            /*" -2385- MOVE RSD-NUM-PROPOSTA(1:1) TO LK-GE053-I-COD-CANAL-ORIGEM */
            _.Move(LXFPF028.REG_TIPO_D.RSD_NUM_PROPOSTA.Substring(1, 1), SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM);

            /*" -2386- MOVE 'BI1610B' TO LK-GE053-I-NUM-MATRICULA */
            _.Move("BI1610B", SPGE053W.LK_GE053_I_NUM_MATRICULA);

            /*" -2387- MOVE SPACES TO LK-GE053-I-NOM-PROGRAMA */
            _.Move("", SPGE053W.LK_GE053_I_NOM_PROGRAMA);

            /*" -2390- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-CADASTRAMENTO */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO);

            /*" -2412- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE. */
            _.Call("SPBGE053", SPGE053W);

            /*" -2413- IF LK-GE053-IND-ERRO EQUAL ZEROS */

            if (SPGE053W.LK_GE053_IND_ERRO == 00)
            {

                /*" -2414- ADD 001 TO AC-QTD-NSO-GRV */
                WS_WORKING.AC_CONTADORES.AC_QTD_NSO_GRV.Value = WS_WORKING.AC_CONTADORES.AC_QTD_NSO_GRV + 001;

                /*" -2415- ELSE */
            }
            else
            {


                /*" -2416- DISPLAY '***' */
                _.Display($"***");

                /*" -2417- DISPLAY ' 13900-00-NOME-SOCIAL   ' */
                _.Display($" 13900-00-NOME-SOCIAL   ");

                /*" -2418- DISPLAY ' ERRO SPBGE053 (' LK-GE053-IND-ERRO ' )' */

                $" ERRO SPBGE053 ({SPGE053W.LK_GE053_IND_ERRO} )"
                .Display();

                /*" -2420- DISPLAY ' PROPOSTA: ' NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL */
                _.Display($" PROPOSTA: {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL}");

                /*" -2421- DISPLAY 'LK-GE053-IND-ERRO: ' LK-GE053-IND-ERRO */
                _.Display($"LK-GE053-IND-ERRO: {SPGE053W.LK_GE053_IND_ERRO}");

                /*" -2422- DISPLAY 'LK-GE053-ID-ERRO : ' LK-GE053-ID-ERRO */
                _.Display($"LK-GE053-ID-ERRO : {SPGE053W.LK_GE053_ID_ERRO}");

                /*" -2423- DISPLAY 'LK-GE053-MENSAGEM: ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM: {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -2424- DISPLAY '***' */
                _.Display($"***");

                /*" -2425- IF LK-GE053-SQLCODE NOT EQUAL ZEROS */

                if (SPGE053W.LK_GE053_SQLCODE != 00)
                {

                    /*" -2426- DISPLAY 'LK-GE053-NOM-TABELA: ' LK-GE053-NOM-TABELA */
                    _.Display($"LK-GE053-NOM-TABELA: {SPGE053W.LK_GE053_NOM_TABELA}");

                    /*" -2427- DISPLAY 'LK-GE053-SQLCODE   : ' LK-GE053-SQLCODE */
                    _.Display($"LK-GE053-SQLCODE   : {SPGE053W.LK_GE053_SQLCODE}");

                    /*" -2428- DISPLAY 'LK-GE053-SQLERRMC  : ' LK-GE053-SQLERRMC */
                    _.Display($"LK-GE053-SQLERRMC  : {SPGE053W.LK_GE053_SQLERRMC}");

                    /*" -2429- DISPLAY 'LK-GE053-SQLSTATE  : ' LK-GE053-SQLSTATE */
                    _.Display($"LK-GE053-SQLSTATE  : {SPGE053W.LK_GE053_SQLSTATE}");

                    /*" -2430- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2431- END-IF */
                }


                /*" -2432- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2433- END-IF */
            }


            /*" -2437- DISPLAY 'INS NOME SOCIAL ' NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL ' LK-GE053-IND-ERRO: ' LK-GE053-IND-ERRO */

            $"INS NOME SOCIAL {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL} LK-GE053-IND-ERRO: {SPGE053W.LK_GE053_IND_ERRO}"
            .Display();

            /*" -2437- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13900_99_SAIDA*/

        [StopWatch]
        /*" M-80000-00-FINAL-SECTION */
        private void M_80000_00_FINAL_SECTION()
        {
            /*" -2448- WRITE BI1610O1-REGISTRO FROM BI1610I1-REGISTRO */
            _.Move(BI1610I1_REGISTRO.GetMoveValues(), BI1610O1_REGISTRO);

            BI1610O1.Write(BI1610O1_REGISTRO.GetMoveValues().ToString());

            /*" -2449- IF BI1610O1-NORMAL */

            if (WS_WORKING.WS_NIVEIS_88.N88_BI1610O1_STATUS["BI1610O1_NORMAL"])
            {

                /*" -2450- ADD 001 TO AC-BI1610O1-GRV */
                WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV.Value = WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV + 001;

                /*" -2451- ELSE */
            }
            else
            {


                /*" -2452- DISPLAY '***' */
                _.Display($"***");

                /*" -2453- DISPLAY ' 80000-00-FINAL ' */
                _.Display($" 80000-00-FINAL ");

                /*" -2454- DISPLAY ' ERRO WRITE BI1610O1 ST = ' N88-BI1610O1-STATUS */
                _.Display($" ERRO WRITE BI1610O1 ST = {WS_WORKING.WS_NIVEIS_88.N88_BI1610O1_STATUS}");

                /*" -2455- DISPLAY '***' */
                _.Display($"***");

                /*" -2456- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2458- END-IF */
            }


            /*" -2460- CLOSE BI1610I1 BI1610O1 */
            BI1610I1.Close();
            BI1610O1.Close();

            /*" -2460- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2463- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -2465- DISPLAY ' BI1610I1 LIDOS ..........................: ' AC-BI1610I1-LID */
            _.Display($" BI1610I1 LIDOS ..........................: {WS_WORKING.AC_CONTADORES.AC_BI1610I1_LID}");

            /*" -2467- DISPLAY ' PROPOSTAS LIDAS .........................: ' AC-QTD-PRO-LID */
            _.Display($" PROPOSTAS LIDAS .........................: {WS_WORKING.AC_CONTADORES.AC_QTD_PRO_LID}");

            /*" -2468- DISPLAY ' ***' */
            _.Display($" ***");

            /*" -2470- DISPLAY ' PROPOSTAS FIDELIZ GRAVADAS ..............: ' AC-QTD-PRO-FID */
            _.Display($" PROPOSTAS FIDELIZ GRAVADAS ..............: {WS_WORKING.AC_CONTADORES.AC_QTD_PRO_FID}");

            /*" -2472- DISPLAY ' CONVERSAO SICOB GRAVADAS ................: ' AC-QTD-CSI-GRV */
            _.Display($" CONVERSAO SICOB GRAVADAS ................: {WS_WORKING.AC_CONTADORES.AC_QTD_CSI_GRV}");

            /*" -2474- DISPLAY ' SASSE BILHETE GRAVADAS ..................: ' AC-QTD-SAS-GRV */
            _.Display($" SASSE BILHETE GRAVADAS ..................: {WS_WORKING.AC_CONTADORES.AC_QTD_SAS_GRV}");

            /*" -2476- DISPLAY ' HIS PROPOSTA FIDELIZ GRAVADAS ...........: ' AC-QTD-HPF-GRV */
            _.Display($" HIS PROPOSTA FIDELIZ GRAVADAS ...........: {WS_WORKING.AC_CONTADORES.AC_QTD_HPF_GRV}");

            /*" -2478- DISPLAY ' BENEFICIARIOS GRAVADOS ..................: ' AC-QTD-BEN-GRV */
            _.Display($" BENEFICIARIOS GRAVADOS ..................: {WS_WORKING.AC_CONTADORES.AC_QTD_BEN_GRV}");

            /*" -2480- DISPLAY ' NOME SOCIAL GRAVADOS ....................: ' AC-QTD-NSO-GRV */
            _.Display($" NOME SOCIAL GRAVADOS ....................: {WS_WORKING.AC_CONTADORES.AC_QTD_NSO_GRV}");

            /*" -2482- DISPLAY ' NOME SOCIAL IGNORADO ....................: ' AC-QTD-NSO-IGN */
            _.Display($" NOME SOCIAL IGNORADO ....................: {WS_WORKING.AC_CONTADORES.AC_QTD_NSO_IGN}");

            /*" -2484- DISPLAY ' TIPO A E TIPO B IGNORADOS ...............: ' AC-QTD-REG-IGN */
            _.Display($" TIPO A E TIPO B IGNORADOS ...............: {WS_WORKING.AC_CONTADORES.AC_QTD_REG_IGN}");

            /*" -2486- DISPLAY ' BI1610I1 COM ERRO .......................: ' AC-BI1610I1-ERR */
            _.Display($" BI1610I1 COM ERRO .......................: {WS_WORKING.AC_CONTADORES.AC_BI1610I1_ERR}");

            /*" -2488- DISPLAY ' BI1610O1 GRAVADOS .......................: ' AC-BI1610O1-GRV */
            _.Display($" BI1610O1 GRAVADOS .......................: {WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV}");

            /*" -2489- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -2491- ADD 001 TO AC-QTD-SAS-GRV */
            WS_WORKING.AC_CONTADORES.AC_QTD_SAS_GRV.Value = WS_WORKING.AC_CONTADORES.AC_QTD_SAS_GRV + 001;

            /*" -2493- GOBACK */

            throw new GoBack();

            /*" -2493- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_80000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2502- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -2503- DISPLAY ' ************* PROGRAMA  CANCELADO ************* ' */
            _.Display($" ************* PROGRAMA  CANCELADO ************* ");

            /*" -2504- DISPLAY ' *************       ROLLBACK      ************* ' */
            _.Display($" *************       ROLLBACK      ************* ");

            /*" -2505- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -2506- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2507- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, DISPLAY_ABEND.WSQLCODE);

                /*" -2508- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], DISPLAY_ABEND.WSQLERRD1);

                /*" -2509- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], DISPLAY_ABEND.WSQLERRD2);

                /*" -2510- DISPLAY DISPLAY-ABEND */
                _.Display(DISPLAY_ABEND);

                /*" -2511- DISPLAY 'BI1610I1 LIDOS   = ' AC-BI1610I1-LID */
                _.Display($"BI1610I1 LIDOS   = {WS_WORKING.AC_CONTADORES.AC_BI1610I1_LID}");

                /*" -2512- DISPLAY 'BI161001 GRAVA   = ' AC-BI1610O1-GRV */
                _.Display($"BI161001 GRAVA   = {WS_WORKING.AC_CONTADORES.AC_BI1610O1_GRV}");

                /*" -2514- DISPLAY 'ULTIMO REG. LIDO = ' BI1610I1-NUM-PRO */
                _.Display($"ULTIMO REG. LIDO = {BI1610I1_REGISTRO.BI1610I1_NUM_PRO}");

                /*" -2516- END-IF */
            }


            /*" -2516- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2520- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2522- GOBACK */

            throw new GoBack();

            /*" -2522- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}