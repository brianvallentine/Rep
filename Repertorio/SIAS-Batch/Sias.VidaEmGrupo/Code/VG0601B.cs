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
using Sias.VidaEmGrupo.DB2.VG0601B;

namespace Code
{
    public class VG0601B
    {
        public bool IsCall { get; set; }

        public VG0601B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ...............  VIDA                                *      */
        /*"      *   PROGRAMA ..............  VG0601B                             *      */
        /*"      *   ANALISTA ..............  BRSEG                               *      */
        /*"      *   PROGRAMADOR ...........  BRSEG                               *      */
        /*"      *   DATA CODIFICACAO ......  JULHO / 2008                        *      */
        /*"      *   FUNCAO ................  PROPOSTAS VENDIDAS                  *      */
        /*"      *                            - ANALITICO MENSAL (QUADRO 11)      *      */
        /*"      *                              POR PRODUTO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA           DATA     DESCRICAO                          *      */
        /*"      *                                                                *      */
        /*"      * BRSEG           01/07/2008  DESENVOLVIMENTO                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 18/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 03 - CADMUS 166293 - INCIDENTE 161398 (JAZZ)         *      */
        /*"      *                FOI AUMENTADO O NUMERO DE OCORRENCIAS DA TABELA *      */
        /*"      *                INTERNA PARA 500 OCORRENCIAS.                   *      */
        /*"      *                                                                *      */
        /*"      *    05/06/2018 - RIBAMAR MARQUES                                *      */
        /*"      *                                              PROCURE POR V.03  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ARQUIVO_QUADRO11 { get; set; } = new FileBasis(new PIC("X", "330", "X(330)"));

        public FileBasis ARQUIVO_QUADRO11
        {
            get
            {
                _.Move(REG_SAIDA, _ARQUIVO_QUADRO11); VarBasis.RedefinePassValue(REG_SAIDA, _ARQUIVO_QUADRO11, REG_SAIDA); return _ARQUIVO_QUADRO11;
            }
        }
        /*"01              REG-SAIDA          PIC  X(330).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "330", "X(330)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis IXF1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77              FILLER          PIC X(25) VALUE                'VG0601B INICIO DA WORKING'.*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"VG0601B INICIO DA WORKING");
        /*"01           AREA-DE-WORK.*/
        public VG0601B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0601B_AREA_DE_WORK();
        public class VG0601B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-STATUS           PIC  X(002)    VALUE '00'.*/
            public StringBasis WS_STATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"  05         WS-IXF2             PIC S9(008)    VALUE +100 COMP.*/
            public IntBasis WS_IXF2 { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"), +100);
            /*"  05         WZEROS              PIC S9(003)    VALUE +0  COMP-3*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WRESTO              PIC S9(003)    VALUE +0  COMP-3*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WHOST-4ZEROS        PIC S9(004)    VALUE +0  COMP.*/
            public IntBasis WHOST_4ZEROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WHOST-9ZEROS        PIC S9(009)    VALUE +0  COMP.*/
            public IntBasis WHOST_9ZEROS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WOCORRENCIA         PIC  9(004)    VALUE  ZEROS.*/
            public IntBasis WOCORRENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WORK-RESULTADO      PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WORK_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WORK-RESTO          PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WORK_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WHOST-DATA-INI      PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WHOST_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WHOST-DATA-TER      PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WHOST_DATA_TER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WFIM-FONTES         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PROPOVA        PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         ACLID-PROPOVA       PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis ACLID_PROPOVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         ACREJ-PROPOVA       PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis ACREJ_PROPOVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         ACSEL-PROPOVA       PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis ACSEL_PROPOVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         ACGRA-QUADRO11      PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis ACGRA_QUADRO11 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-ERRO-PARM        PIC  X(003)    VALUE  'NAO'.*/
            public StringBasis WS_ERRO_PARM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05         WS-PROD-ATU.*/
            public VG0601B_WS_PROD_ATU WS_PROD_ATU { get; set; } = new VG0601B_WS_PROD_ATU();
            public class VG0601B_WS_PROD_ATU : VarBasis
            {
                /*"    10       WS-APOL-ATU         PIC  9(013)    VALUE  ZEROS.*/
                public IntBasis WS_APOL_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       WS-SUBG-ATU         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_SUBG_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-PROD-ANT.*/
            }
            public VG0601B_WS_PROD_ANT WS_PROD_ANT { get; set; } = new VG0601B_WS_PROD_ANT();
            public class VG0601B_WS_PROD_ANT : VarBasis
            {
                /*"    10       WS-APOL-ANT         PIC  9(013)    VALUE  ZEROS.*/
                public IntBasis WS_APOL_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10       WS-SUBG-ANT         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_SUBG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-DATA-AUX.*/
            }
            public VG0601B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG0601B_WS_DATA_AUX();
            public class VG0601B_WS_DATA_AUX : VarBasis
            {
                /*"    10       WS-DATA-ANO         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_DATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WS-DATA-MES         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-DATA-DIA         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-ACCEPT.*/
            }
            public VG0601B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new VG0601B_WS_DATA_ACCEPT();
            public class VG0601B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10       WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-HORA-ACCEPT.*/
            }
            public VG0601B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new VG0601B_WS_HORA_ACCEPT();
            public class VG0601B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10       WS-HOR-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MIN-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-SEG-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-CURR.*/
            }
            public VG0601B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new VG0601B_WS_DATA_CURR();
            public class VG0601B_WS_DATA_CURR : VarBasis
            {
                /*"    10       WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-HORA-CURR.*/
            }
            public VG0601B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new VG0601B_WS_HORA_CURR();
            public class VG0601B_WS_HORA_CURR : VarBasis
            {
                /*"    10       WS-HOR-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MIN-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-SEG-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-DB2.*/
            }
            public VG0601B_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new VG0601B_WS_DATA_DB2();
            public class VG0601B_WS_DATA_DB2 : VarBasis
            {
                /*"    10       WS-ANO-DB2          PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MES-DB2          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-DIA-DB2          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-EDITADA.*/
            }
            public VG0601B_WS_DATA_EDITADA WS_DATA_EDITADA { get; set; } = new VG0601B_WS_DATA_EDITADA();
            public class VG0601B_WS_DATA_EDITADA : VarBasis
            {
                /*"    10       WS-DIA-EDIT         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MES-EDIT         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-ANO-EDIT         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_EDIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WS-DTH-CONSISTE     PIC  9(008).*/
            }
            public IntBasis WS_DTH_CONSISTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05        WS-DTH-CONSISTE-R   REDEFINES      WS-DTH-CONSISTE.*/
            private _REDEF_VG0601B_WS_DTH_CONSISTE_R _ws_dth_consiste_r { get; set; }
            public _REDEF_VG0601B_WS_DTH_CONSISTE_R WS_DTH_CONSISTE_R
            {
                get { _ws_dth_consiste_r = new _REDEF_VG0601B_WS_DTH_CONSISTE_R(); _.Move(WS_DTH_CONSISTE, _ws_dth_consiste_r); VarBasis.RedefinePassValue(WS_DTH_CONSISTE, _ws_dth_consiste_r, WS_DTH_CONSISTE); _ws_dth_consiste_r.ValueChanged += () => { _.Move(_ws_dth_consiste_r, WS_DTH_CONSISTE); }; return _ws_dth_consiste_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_consiste_r, WS_DTH_CONSISTE); }
            }  //Redefines
            public class _REDEF_VG0601B_WS_DTH_CONSISTE_R : VarBasis
            {
                /*"    10      WS-CONSISTE-ANO     PIC  9(004).*/
                public IntBasis WS_CONSISTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-CONSISTE-MES     PIC  9(002).*/
                public IntBasis WS_CONSISTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-CONSISTE-DIA     PIC  9(002).*/
                public IntBasis WS_CONSISTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-DTH-INICIO       PIC  9(008).*/

                public _REDEF_VG0601B_WS_DTH_CONSISTE_R()
                {
                    WS_CONSISTE_ANO.ValueChanged += OnValueChanged;
                    WS_CONSISTE_MES.ValueChanged += OnValueChanged;
                    WS_CONSISTE_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTH_INICIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05        WS-DTH-INICIO-R     REDEFINES      WS-DTH-INICIO.*/
            private _REDEF_VG0601B_WS_DTH_INICIO_R _ws_dth_inicio_r { get; set; }
            public _REDEF_VG0601B_WS_DTH_INICIO_R WS_DTH_INICIO_R
            {
                get { _ws_dth_inicio_r = new _REDEF_VG0601B_WS_DTH_INICIO_R(); _.Move(WS_DTH_INICIO, _ws_dth_inicio_r); VarBasis.RedefinePassValue(WS_DTH_INICIO, _ws_dth_inicio_r, WS_DTH_INICIO); _ws_dth_inicio_r.ValueChanged += () => { _.Move(_ws_dth_inicio_r, WS_DTH_INICIO); }; return _ws_dth_inicio_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_inicio_r, WS_DTH_INICIO); }
            }  //Redefines
            public class _REDEF_VG0601B_WS_DTH_INICIO_R : VarBasis
            {
                /*"    10      WS-INICIO-ANO       PIC  9(004).*/
                public IntBasis WS_INICIO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-INICIO-MES       PIC  9(002).*/
                public IntBasis WS_INICIO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-INICIO-DIA       PIC  9(002).*/
                public IntBasis WS_INICIO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-DTH-TERMINO      PIC  9(008).*/

                public _REDEF_VG0601B_WS_DTH_INICIO_R()
                {
                    WS_INICIO_ANO.ValueChanged += OnValueChanged;
                    WS_INICIO_MES.ValueChanged += OnValueChanged;
                    WS_INICIO_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTH_TERMINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05        WS-DTH-TERMINO-R    REDEFINES      WS-DTH-TERMINO.*/
            private _REDEF_VG0601B_WS_DTH_TERMINO_R _ws_dth_termino_r { get; set; }
            public _REDEF_VG0601B_WS_DTH_TERMINO_R WS_DTH_TERMINO_R
            {
                get { _ws_dth_termino_r = new _REDEF_VG0601B_WS_DTH_TERMINO_R(); _.Move(WS_DTH_TERMINO, _ws_dth_termino_r); VarBasis.RedefinePassValue(WS_DTH_TERMINO, _ws_dth_termino_r, WS_DTH_TERMINO); _ws_dth_termino_r.ValueChanged += () => { _.Move(_ws_dth_termino_r, WS_DTH_TERMINO); }; return _ws_dth_termino_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_termino_r, WS_DTH_TERMINO); }
            }  //Redefines
            public class _REDEF_VG0601B_WS_DTH_TERMINO_R : VarBasis
            {
                /*"    10      WS-TERMINO-ANO      PIC  9(004).*/
                public IntBasis WS_TERMINO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-TERMINO-MES      PIC  9(002).*/
                public IntBasis WS_TERMINO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-TERMINO-DIA      PIC  9(002).*/
                public IntBasis WS_TERMINO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01         WPARM-PARAMETRO.*/

                public _REDEF_VG0601B_WS_DTH_TERMINO_R()
                {
                    WS_TERMINO_ANO.ValueChanged += OnValueChanged;
                    WS_TERMINO_MES.ValueChanged += OnValueChanged;
                    WS_TERMINO_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public VG0601B_WPARM_PARAMETRO WPARM_PARAMETRO { get; set; } = new VG0601B_WPARM_PARAMETRO();
        public class VG0601B_WPARM_PARAMETRO : VarBasis
        {
            /*"  05       WPARM-ROTINA        PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WPARM_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WPARM-DATINI        PIC  X(008)    VALUE  SPACES.*/
            public StringBasis WPARM_DATINI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05       WPARM-DATTER        PIC  X(008)    VALUE  SPACES.*/
            public StringBasis WPARM_DATTER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05         WREL-CAB.*/
            public VG0601B_WREL_CAB WREL_CAB { get; set; } = new VG0601B_WREL_CAB();
            public class VG0601B_WREL_CAB : VarBasis
            {
                /*"    10       FILLER              PIC  X(007) VALUE 'PRODUTO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(010) VALUE 'COD FILIAL'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"COD FILIAL");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(006) VALUE 'FILIAL' .*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"FILIAL");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(006) VALUE 'COD SR'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"COD SR");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(002) VALUE 'SR'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"SR");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(007) VALUE 'AGENCIA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AGENCIA");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(009) VALUE 'MATRICULA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MATRICULA");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(009) VALUE 'INDICADOR'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"INDICADOR");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILER               PIC  X(011) VALUE                                             'CERTIFICADO'.*/
                public StringBasis FILER { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(004) VALUE 'NOME'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NOME");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(003) VALUE 'CPF'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"CPF");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(011) VALUE 'DT QUITACAO'*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"DT QUITACAO");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(006) VALUE 'PREMIO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       FILLER              PIC  X(008) VALUE 'IMP.SEG.'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"IMP.SEG.");
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05         WREL-DET.*/
            }
            public VG0601B_WREL_DET WREL_DET { get; set; } = new VG0601B_WREL_DET();
            public class VG0601B_WREL_DET : VarBasis
            {
                /*"    10       WREL-PRODUTO         PIC  X(040).*/
                public StringBasis WREL_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-COD-FONTE       PIC  9(004).*/
                public IntBasis WREL_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-FONTE           PIC  X(040).*/
                public StringBasis WREL_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-COD-SR          PIC  9(004).*/
                public IntBasis WREL_COD_SR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-SR              PIC  X(040).*/
                public StringBasis WREL_SR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-AGE-COBRANCA    PIC  9(004).*/
                public IntBasis WREL_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-MATR-INDIC      PIC  9(015).*/
                public IntBasis WREL_MATR_INDIC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-INDICADOR       PIC  X(040).*/
                public StringBasis WREL_INDICADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-NUM-CERTIFICADO PIC  9(013).*/
                public IntBasis WREL_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-NOME            PIC  X(040).*/
                public StringBasis WREL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-CPF             PIC  9(014).*/
                public IntBasis WREL_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10       FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-QUITACAO.*/
                public VG0601B_WREL_QUITACAO WREL_QUITACAO { get; set; } = new VG0601B_WREL_QUITACAO();
                public class VG0601B_WREL_QUITACAO : VarBasis
                {
                    /*"      15     WREL-DD-QIT         PIC  9(002).*/
                    public IntBasis WREL_DD_QIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      15     WREL-MM-QIT         PIC  9(002).*/
                    public IntBasis WREL_MM_QIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      15     WREL-AA-QIT         PIC  9(004).*/
                    public IntBasis WREL_AA_QIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                }
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-VLPREMIO       PIC  ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WREL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10       WREL-IMPSEGUR       PIC  ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WREL_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10       FILLER              PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05         TABELA-MESES.*/
            }
            public VG0601B_TABELA_MESES TABELA_MESES { get; set; } = new VG0601B_TABELA_MESES();
            public class VG0601B_TABELA_MESES : VarBasis
            {
                /*"    10       FILLER               PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"    10       FILLER               PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    10       FILLER               PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"    10       FILLER               PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"    10       FILLER               PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"    10       FILLER               PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"    10       FILLER               PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"    10       FILLER               PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"    10       FILLER               PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"    10       FILLER               PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"    10       FILLER               PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"    10       FILLER               PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"  05         FILLER               REDEFINES    TABELA-MESES.*/
            }
            private _REDEF_VG0601B_FILLER_64 _filler_64 { get; set; }
            public _REDEF_VG0601B_FILLER_64 FILLER_64
            {
                get { _filler_64 = new _REDEF_VG0601B_FILLER_64(); _.Move(TABELA_MESES, _filler_64); VarBasis.RedefinePassValue(TABELA_MESES, _filler_64, TABELA_MESES); _filler_64.ValueChanged += () => { _.Move(_filler_64, TABELA_MESES); }; return _filler_64; }
                set { VarBasis.RedefinePassValue(value, _filler_64, TABELA_MESES); }
            }  //Redefines
            public class _REDEF_VG0601B_FILLER_64 : VarBasis
            {
                /*"    10       TAB-MESES            OCCURS       12.*/
                public ListBasis<VG0601B_TAB_MESES> TAB_MESES { get; set; } = new ListBasis<VG0601B_TAB_MESES>(12);
                public class VG0601B_TAB_MESES : VarBasis
                {
                    /*"      15     TAB-MES              PIC  X(009).*/
                    public StringBasis TAB_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                    /*"  05         TAB-FONTES           OCCURS  500                                  INDEXED BY  IXF1.*/

                    public VG0601B_TAB_MESES()
                    {
                        TAB_MES.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VG0601B_FILLER_64()
                {
                    TAB_MESES.ValueChanged += OnValueChanged;
                }

            }
            public ListBasis<VG0601B_TAB_FONTES> TAB_FONTES { get; set; } = new ListBasis<VG0601B_TAB_FONTES>(500);
            public class VG0601B_TAB_FONTES : VarBasis
            {
                /*"    10       TAB-COD-FONTE        PIC  9(004).*/
                public IntBasis TAB_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       TAB-NOM-FONTE        PIC  X(040).*/
                public StringBasis TAB_NOM_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05        WABEND.*/
            }
            public VG0601B_WABEND WABEND { get; set; } = new VG0601B_WABEND();
            public class VG0601B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC X(010) VALUE           ' VG0601B'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0601B");
                /*"    10      FILLER              PIC X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC X(005) VALUE '00000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
                /*"    10      FILLER              PIC X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05        WSQLERRO.*/
            }
            public VG0601B_WSQLERRO WSQLERRO { get; set; } = new VG0601B_WSQLERRO();
            public class VG0601B_WSQLERRO : VarBasis
            {
                /*"    10      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    10      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.SUREGSAS SUREGSAS { get; set; } = new Dclgens.SUREGSAS();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public VG0601B_C01_FONTES C01_FONTES { get; set; } = new VG0601B_C01_FONTES();
        public VG0601B_C01_PROPOVA C01_PROPOVA { get; set; } = new VG0601B_C01_PROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VG0601B_WPARM_PARAMETRO VG0601B_WPARM_PARAMETRO_P, string ARQUIVO_QUADRO11_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WPARM_PARAMETRO = VG0601B_WPARM_PARAMETRO_P;
                ARQUIVO_QUADRO11.SetFile(ARQUIVO_QUADRO11_FILE_NAME_P);

                /*" -331- MOVE 'R0000' TO WNR-EXEC-SQL. */
                _.Move("R0000", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                /*" -331- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -332- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -333- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -337- PERFORM R0100-00-PROCESSO-INICIAL */

                R0100_00_PROCESSO_INICIAL_SECTION();

                /*" -339- PERFORM R1000-00-PROCESSO-PRINCIPAL */

                R1000_00_PROCESSO_PRINCIPAL_SECTION();

                /*" -341- PERFORM R0200-00-PROCESSO-FINAL */

                R0200_00_PROCESSO_FINAL_SECTION();

                /*" -341- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WPARM_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0100-00-PROCESSO-INICIAL-SECTION */
        private void R0100_00_PROCESSO_INICIAL_SECTION()
        {
            /*" -351- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -352- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -353- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -354- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -355- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -356- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -358- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -359- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -360- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -361- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -362- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -364- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -366- DISPLAY 'VG0601B - INICIO DA EXECUCAO ' WS-DATA-CURR ' - ' WS-HORA-CURR */

            $"VG0601B - INICIO DA EXECUCAO {AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR}"
            .Display();

            /*" -368- DISPLAY '   ' . */
            _.Display($"   ");

            /*" -369- MOVE '00/00/0000' TO WS-DATA-EDITADA */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDITADA);

            /*" -372- MOVE +0 TO WHOST-4ZEROS WHOST-9ZEROS. */
            _.Move(+0, AREA_DE_WORK.WHOST_4ZEROS, AREA_DE_WORK.WHOST_9ZEROS);

            /*" -373- PERFORM R0110-00-SELECT-EMPRESAS. */

            R0110_00_SELECT_EMPRESAS_SECTION();

            /*" -374- PERFORM R0120-00-SELECT-SISTEMAS. */

            R0120_00_SELECT_SISTEMAS_SECTION();

            /*" -375- PERFORM R0130-00-OBTEM-PARAMETROS. */

            R0130_00_OBTEM_PARAMETROS_SECTION();

            /*" -376- PERFORM R0140-00-OPEN-ARQUIVOS. */

            R0140_00_OPEN_ARQUIVOS_SECTION();

            /*" -376- PERFORM R0160-00-CARREGA-FONTES. */

            R0160_00_CARREGA_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-SELECT-EMPRESAS-SECTION */
        private void R0110_00_SELECT_EMPRESAS_SECTION()
        {
            /*" -393- PERFORM R0110_00_SELECT_EMPRESAS_DB_SELECT_1 */

            R0110_00_SELECT_EMPRESAS_DB_SELECT_1();

            /*" -396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -397- MOVE 'R0110' TO WNR-EXEC-SQL */
                _.Move("R0110", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                /*" -398- DISPLAY 'R0110 - PROBLEMAS SELECT EMPRESAS' */
                _.Display($"R0110 - PROBLEMAS SELECT EMPRESAS");

                /*" -398- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-SELECT-EMPRESAS-DB-SELECT-1 */
        public void R0110_00_SELECT_EMPRESAS_DB_SELECT_1()
        {
            /*" -393- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1 = new R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-SELECT-SISTEMAS-SECTION */
        private void R0120_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -415- PERFORM R0120_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0120_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -418- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -419- MOVE 'R0120' TO WNR-EXEC-SQL */
                _.Move("R0120", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                /*" -420- DISPLAY 'R0120 - PROBLEMAS SELECT SISTEMAS (RG)' */
                _.Display($"R0120 - PROBLEMAS SELECT SISTEMAS (RG)");

                /*" -420- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0120_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -415- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'RG' END-EXEC. */

            var r0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-OBTEM-PARAMETROS-SECTION */
        private void R0130_00_OBTEM_PARAMETROS_SECTION()
        {
            /*" -433- ACCEPT WPARM-PARAMETRO FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -434- PERFORM R0131-00-CONSISTE-PARAMETRO */

            R0131_00_CONSISTE_PARAMETRO_SECTION();

            /*" -435- IF WS-ERRO-PARM EQUAL 'SIM' */

            if (AREA_DE_WORK.WS_ERRO_PARM == "SIM")
            {

                /*" -436- MOVE 'R0130' TO WNR-EXEC-SQL */
                _.Move("R0130", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                /*" -437- DISPLAY 'RAAAAMMDDAAAAMMDD' */
                _.Display($"RAAAAMMDDAAAAMMDD");

                /*" -438- DISPLAY 'Onde: R-Rotina (M-mensal / E-eventual)' */
                _.Display($"Onde: R-Rotina (M-mensal / E-eventual)");

                /*" -439- DISPLAY '      AAAAMMDD  Periodo de Selecao' */
                _.Display($"      AAAAMMDD  Periodo de Selecao");

                /*" -440- DISPLAY '               (A-ano M-mes D-dia)' */
                _.Display($"               (A-ano M-mes D-dia)");

                /*" -442- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -445- MOVE '0000-00-00' TO WHOST-DATA-INI WHOST-DATA-TER */
            _.Move("0000-00-00", AREA_DE_WORK.WHOST_DATA_INI, AREA_DE_WORK.WHOST_DATA_TER);

            /*" -446- IF WPARM-ROTINA EQUAL 'M' */

            if (WPARM_PARAMETRO.WPARM_ROTINA == "M")
            {

                /*" -447- PERFORM R0133-00-ROTINA-MENSAL */

                R0133_00_ROTINA_MENSAL_SECTION();

                /*" -448- ELSE */
            }
            else
            {


                /*" -450- PERFORM R0134-00-ROTINA-EVENTUAL. */

                R0134_00_ROTINA_EVENTUAL_SECTION();
            }


            /*" -452- DISPLAY 'DATA DO SISTEMA ...... : ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO SISTEMA ...... : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -453- DISPLAY 'TIPO DE ROTINA ....... : ' WPARM-ROTINA */
            _.Display($"TIPO DE ROTINA ....... : {WPARM_PARAMETRO.WPARM_ROTINA}");

            /*" -455- DISPLAY 'PERIODO DE SELECAO - DE: ' WHOST-DATA-INI ' A ' WHOST-DATA-TER. */

            $"PERIODO DE SELECAO - DE: {AREA_DE_WORK.WHOST_DATA_INI} A {AREA_DE_WORK.WHOST_DATA_TER}"
            .Display();

            /*" -455- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0131-00-CONSISTE-PARAMETRO-SECTION */
        private void R0131_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -468- MOVE 'R0131' TO WNR-EXEC-SQL. */
            _.Move("R0131", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -469- IF WPARM-ROTINA NOT EQUAL 'E' AND 'M' */

            if (!WPARM_PARAMETRO.WPARM_ROTINA.In("E", "M"))
            {

                /*" -470- DISPLAY '*** TIPO DE ROTINA INVALIDA' */
                _.Display($"*** TIPO DE ROTINA INVALIDA");

                /*" -471- MOVE 'SIM' TO WS-ERRO-PARM */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                /*" -473- GO TO R0131-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0131_99_SAIDA*/ //GOTO
                return;
            }


            /*" -474- IF WPARM-ROTINA EQUAL 'M' */

            if (WPARM_PARAMETRO.WPARM_ROTINA == "M")
            {

                /*" -475- GO TO R0131-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0131_99_SAIDA*/ //GOTO
                return;

                /*" -477- END-IF. */
            }


            /*" -479- IF WPARM-DATINI EQUAL '00000000' AND WPARM-DATTER EQUAL '00000000' */

            if (WPARM_PARAMETRO.WPARM_DATINI == "00000000" && WPARM_PARAMETRO.WPARM_DATTER == "00000000")
            {

                /*" -480- DISPLAY '*** NAO HOUVE SOLICITACAO' */
                _.Display($"*** NAO HOUVE SOLICITACAO");

                /*" -481- MOVE 'SIM' TO WS-ERRO-PARM */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                /*" -482- GO TO R0131-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0131_99_SAIDA*/ //GOTO
                return;

                /*" -484- END-IF. */
            }


            /*" -485- MOVE WPARM-DATINI TO WS-DTH-CONSISTE-R */
            _.Move(WPARM_PARAMETRO.WPARM_DATINI, AREA_DE_WORK.WS_DTH_CONSISTE_R);

            /*" -487- PERFORM R0132-00-CONSISTE-DATA */

            R0132_00_CONSISTE_DATA_SECTION();

            /*" -488- MOVE WPARM-DATTER TO WS-DTH-CONSISTE-R */
            _.Move(WPARM_PARAMETRO.WPARM_DATTER, AREA_DE_WORK.WS_DTH_CONSISTE_R);

            /*" -490- PERFORM R0132-00-CONSISTE-DATA. */

            R0132_00_CONSISTE_DATA_SECTION();

            /*" -491- IF WS-ERRO-PARM EQUAL 'SIM' */

            if (AREA_DE_WORK.WS_ERRO_PARM == "SIM")
            {

                /*" -492- DISPLAY 'DATA(S) INVALIDA(S)' */
                _.Display($"DATA(S) INVALIDA(S)");

                /*" -493- GO TO R0131-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0131_99_SAIDA*/ //GOTO
                return;

                /*" -495- END-IF. */
            }


            /*" -496- MOVE WPARM-DATINI TO WS-DTH-INICIO-R */
            _.Move(WPARM_PARAMETRO.WPARM_DATINI, AREA_DE_WORK.WS_DTH_INICIO_R);

            /*" -496- MOVE WPARM-DATTER TO WS-DTH-TERMINO-R. */
            _.Move(WPARM_PARAMETRO.WPARM_DATTER, AREA_DE_WORK.WS_DTH_TERMINO_R);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0131_99_SAIDA*/

        [StopWatch]
        /*" R0132-00-CONSISTE-DATA-SECTION */
        private void R0132_00_CONSISTE_DATA_SECTION()
        {
            /*" -509- MOVE 'R0132' TO WNR-EXEC-SQL. */
            _.Move("R0132", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -511- IF WS-CONSISTE-ANO EQUAL ZEROS OR WS-CONSISTE-ANO IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_ANO == 00 || !AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_ANO.IsNumeric())
            {

                /*" -512- MOVE 'SIM' TO WS-ERRO-PARM */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                /*" -514- GO TO R0132-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                return;
            }


            /*" -517- IF WS-CONSISTE-MES EQUAL ZEROS OR WS-CONSISTE-MES GREATER 12 OR WS-CONSISTE-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES == 00 || AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES > 12 || !AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES.IsNumeric())
            {

                /*" -518- MOVE 'SIM' TO WS-ERRO-PARM */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                /*" -520- GO TO R0132-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                return;
            }


            /*" -522- IF WS-CONSISTE-DIA EQUAL ZEROS OR WS-CONSISTE-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_DIA == 00 || !AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES.IsNumeric())
            {

                /*" -523- MOVE 'SIM' TO WS-ERRO-PARM */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                /*" -525- GO TO R0132-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                return;
            }


            /*" -528- IF WS-CONSISTE-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -529- IF WS-CONSISTE-DIA GREATER 31 */

                if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_DIA > 31)
                {

                    /*" -530- MOVE 'SIM' TO WS-ERRO-PARM */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                    /*" -532- GO TO R0132-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -534- IF WS-CONSISTE-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES.In("04", "06", "09", "11"))
            {

                /*" -535- IF WS-CONSISTE-DIA GREATER 30 */

                if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_DIA > 30)
                {

                    /*" -536- MOVE 'SIM' TO WS-ERRO-PARM */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                    /*" -538- GO TO R0132-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -539- IF WS-CONSISTE-MES EQUAL 02 */

            if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_MES == 02)
            {

                /*" -541- DIVIDE WS-CONSISTE-ANO BY 4 GIVING WORK-RESULTADO REMAINDER WORK-RESTO */
                _.Divide(AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_ANO, 4, AREA_DE_WORK.WORK_RESULTADO, AREA_DE_WORK.WORK_RESTO);

                /*" -542- IF WORK-RESTO EQUAL ZEROS */

                if (AREA_DE_WORK.WORK_RESTO == 00)
                {

                    /*" -543- IF WS-CONSISTE-DIA GREATER 29 */

                    if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_DIA > 29)
                    {

                        /*" -544- MOVE 'SIM' TO WS-ERRO-PARM */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                        /*" -545- GO TO R0132-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                        return;

                        /*" -546- END-IF */
                    }


                    /*" -547- ELSE */
                }
                else
                {


                    /*" -548- IF WS-CONSISTE-DIA GREATER 28 */

                    if (AREA_DE_WORK.WS_DTH_CONSISTE_R.WS_CONSISTE_DIA > 28)
                    {

                        /*" -549- MOVE 'SIM' TO WS-ERRO-PARM */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_PARM);

                        /*" -549- GO TO R0132-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0132_99_SAIDA*/

        [StopWatch]
        /*" R0133-00-ROTINA-MENSAL-SECTION */
        private void R0133_00_ROTINA_MENSAL_SECTION()
        {
            /*" -562- MOVE 'R0133' TO WNR-EXEC-SQL. */
            _.Move("R0133", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -564- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-DB2 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_DB2);

            /*" -565- COMPUTE WS-MES-DB2 = WS-MES-DB2 - 1 */
            AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2.Value = AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2 - 1;

            /*" -566- IF WS-MES-DB2 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2 == 00)
            {

                /*" -567- MOVE 12 TO WS-MES-DB2 */
                _.Move(12, AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2);

                /*" -569- COMPUTE WS-ANO-DB2 = WS-ANO-DB2 - 1. */
                AREA_DE_WORK.WS_DATA_DB2.WS_ANO_DB2.Value = AREA_DE_WORK.WS_DATA_DB2.WS_ANO_DB2 - 1;
            }


            /*" -571- IF WS-MES-DB2 EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2.In("04", "06", "09", "11"))
            {

                /*" -572- MOVE 30 TO WS-DIA-DB2 */
                _.Move(30, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

                /*" -573- ELSE */
            }
            else
            {


                /*" -574- IF WS-MES-DB2 EQUAL 02 */

                if (AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2 == 02)
                {

                    /*" -577- COMPUTE WRESTO = WS-DIA-DB2 - (WS-DIA-DB2 / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2 - (AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2 / 4 * 4);

                    /*" -578- IF WRESTO EQUAL ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -579- MOVE 29 TO WS-DIA-DB2 */
                        _.Move(29, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

                        /*" -580- ELSE */
                    }
                    else
                    {


                        /*" -581- MOVE 28 TO WS-DIA-DB2 */
                        _.Move(28, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

                        /*" -582- ELSE */
                    }

                }
                else
                {


                    /*" -584- MOVE 31 TO WS-DIA-DB2. */
                    _.Move(31, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);
                }

            }


            /*" -585- MOVE WS-DATA-DB2 TO WHOST-DATA-TER */
            _.Move(AREA_DE_WORK.WS_DATA_DB2, AREA_DE_WORK.WHOST_DATA_TER);

            /*" -586- MOVE 01 TO WS-DIA-DB2 */
            _.Move(01, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

            /*" -586- MOVE WS-DATA-DB2 TO WHOST-DATA-INI. */
            _.Move(AREA_DE_WORK.WS_DATA_DB2, AREA_DE_WORK.WHOST_DATA_INI);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0133_99_SAIDA*/

        [StopWatch]
        /*" R0134-00-ROTINA-EVENTUAL-SECTION */
        private void R0134_00_ROTINA_EVENTUAL_SECTION()
        {
            /*" -599- MOVE 'R0134' TO WNR-EXEC-SQL. */
            _.Move("R0134", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -601- MOVE '0000-00-00' TO WS-DATA-DB2 */
            _.Move("0000-00-00", AREA_DE_WORK.WS_DATA_DB2);

            /*" -602- MOVE WPARM-DATINI TO WS-DATA-AUX */
            _.Move(WPARM_PARAMETRO.WPARM_DATINI, AREA_DE_WORK.WS_DATA_AUX);

            /*" -603- MOVE WS-DATA-ANO TO WS-ANO-DB2 */
            _.Move(AREA_DE_WORK.WS_DATA_AUX.WS_DATA_ANO, AREA_DE_WORK.WS_DATA_DB2.WS_ANO_DB2);

            /*" -604- MOVE WS-DATA-MES TO WS-MES-DB2 */
            _.Move(AREA_DE_WORK.WS_DATA_AUX.WS_DATA_MES, AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2);

            /*" -605- MOVE WS-DATA-DIA TO WS-DIA-DB2 */
            _.Move(AREA_DE_WORK.WS_DATA_AUX.WS_DATA_DIA, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

            /*" -607- MOVE WS-DATA-DB2 TO WHOST-DATA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_DB2, AREA_DE_WORK.WHOST_DATA_INI);

            /*" -608- MOVE WPARM-DATTER TO WS-DATA-AUX */
            _.Move(WPARM_PARAMETRO.WPARM_DATTER, AREA_DE_WORK.WS_DATA_AUX);

            /*" -609- MOVE WS-DATA-ANO TO WS-ANO-DB2 */
            _.Move(AREA_DE_WORK.WS_DATA_AUX.WS_DATA_ANO, AREA_DE_WORK.WS_DATA_DB2.WS_ANO_DB2);

            /*" -610- MOVE WS-DATA-MES TO WS-MES-DB2 */
            _.Move(AREA_DE_WORK.WS_DATA_AUX.WS_DATA_MES, AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2);

            /*" -611- MOVE WS-DATA-DIA TO WS-DIA-DB2 */
            _.Move(AREA_DE_WORK.WS_DATA_AUX.WS_DATA_DIA, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

            /*" -611- MOVE WS-DATA-DB2 TO WHOST-DATA-TER. */
            _.Move(AREA_DE_WORK.WS_DATA_DB2, AREA_DE_WORK.WHOST_DATA_TER);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0134_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-OPEN-ARQUIVOS-SECTION */
        private void R0140_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -624- MOVE 'R0140' TO WNR-EXEC-SQL. */
            _.Move("R0140", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -625- OPEN OUTPUT ARQUIVO-QUADRO11 */
            ARQUIVO_QUADRO11.Open(REG_SAIDA, AREA_DE_WORK.WS_STATUS);

            /*" -626- IF WS-STATUS NOT EQUAL '00' */

            if (AREA_DE_WORK.WS_STATUS != "00")
            {

                /*" -627- DISPLAY 'R0140 ERRO OPEN ARQUIVO QUADRO11 ' */
                _.Display($"R0140 ERRO OPEN ARQUIVO QUADRO11 ");

                /*" -628- DISPLAY 'STATUS = ' WS-STATUS */
                _.Display($"STATUS = {AREA_DE_WORK.WS_STATUS}");

                /*" -628- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CARREGA-FONTES-SECTION */
        private void R0160_00_CARREGA_FONTES_SECTION()
        {
            /*" -642- MOVE SPACES TO WFIM-FONTES */
            _.Move("", AREA_DE_WORK.WFIM_FONTES);

            /*" -643- PERFORM R0161-00-DECLARE-FONTES */

            R0161_00_DECLARE_FONTES_SECTION();

            /*" -644- PERFORM R0162-00-FETCH-FONTES */

            R0162_00_FETCH_FONTES_SECTION();

            /*" -645- PERFORM R0163-00-PROCESSA-FONTES UNTIL WFIM-FONTES NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_FONTES.IsEmpty()))
            {

                R0163_00_PROCESSA_FONTES_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0161-00-DECLARE-FONTES-SECTION */
        private void R0161_00_DECLARE_FONTES_SECTION()
        {
            /*" -663- PERFORM R0161_00_DECLARE_FONTES_DB_DECLARE_1 */

            R0161_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -665- PERFORM R0161_00_DECLARE_FONTES_DB_OPEN_1 */

            R0161_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -667- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -668- MOVE 'R0161' TO WNR-EXEC-SQL */
                _.Move("R0161", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                /*" -669- DISPLAY 'R0161 - PROBLEMAS OPEN CURSOR FONTES ' */
                _.Display($"R0161 - PROBLEMAS OPEN CURSOR FONTES ");

                /*" -669- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0161-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R0161_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -663- EXEC SQL DECLARE C01_FONTES CURSOR WITH HOLD FOR SELECT COD_FONTE , NOME_FONTE FROM SEGUROS.FONTES ORDER BY COD_FONTE WITH UR END-EXEC. */
            C01_FONTES = new VG0601B_C01_FONTES(false);
            string GetQuery_C01_FONTES()
            {
                var query = @$"SELECT COD_FONTE
							, 
							NOME_FONTE 
							FROM SEGUROS.FONTES 
							ORDER BY COD_FONTE";

                return query;
            }
            C01_FONTES.GetQueryEvent += GetQuery_C01_FONTES;

        }

        [StopWatch]
        /*" R0161-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R0161_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -665- EXEC SQL OPEN C01_FONTES END-EXEC. */

            C01_FONTES.Open();

        }

        [StopWatch]
        /*" R1100-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R1100_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -816- EXEC SQL DECLARE C01_PROPOVA CURSOR FOR SELECT A.NUM_CERTIFICADO , A.NUM_APOLICE , A.COD_SUBGRUPO , A.COD_FONTE , A.SIT_REGISTRO , A.AGE_COBRANCA , A.DATA_QUITACAO, A.NUM_MATRI_VENDEDOR , B.VLPREMIO , B.IMPSEGUR FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.HIS_COBER_PROPOST B WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.DATA_QUITACAO >= :WHOST-DATA-INI AND A.DATA_QUITACAO <= :WHOST-DATA-TER AND B.OCORR_HISTORICO = 1 ORDER BY A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_FONTE END-EXEC. */
            C01_PROPOVA = new VG0601B_C01_PROPOVA(true);
            string GetQuery_C01_PROPOVA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_FONTE
							, 
							A.SIT_REGISTRO
							, 
							A.AGE_COBRANCA
							, 
							A.DATA_QUITACAO
							, 
							A.NUM_MATRI_VENDEDOR
							, 
							B.VLPREMIO
							, 
							B.IMPSEGUR 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.HIS_COBER_PROPOST B 
							WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND A.DATA_QUITACAO >= '{AREA_DE_WORK.WHOST_DATA_INI}' 
							AND A.DATA_QUITACAO <= '{AREA_DE_WORK.WHOST_DATA_TER}' 
							AND B.OCORR_HISTORICO = 1 
							ORDER BY A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_FONTE";

                return query;
            }
            C01_PROPOVA.GetQueryEvent += GetQuery_C01_PROPOVA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0161_99_SAIDA*/

        [StopWatch]
        /*" R0162-00-FETCH-FONTES-SECTION */
        private void R0162_00_FETCH_FONTES_SECTION()
        {
            /*" -684- PERFORM R0162_00_FETCH_FONTES_DB_FETCH_1 */

            R0162_00_FETCH_FONTES_DB_FETCH_1();

            /*" -687- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -688- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -689- MOVE '*' TO WFIM-FONTES */
                    _.Move("*", AREA_DE_WORK.WFIM_FONTES);

                    /*" -689- PERFORM R0162_00_FETCH_FONTES_DB_CLOSE_1 */

                    R0162_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -691- GO TO R0162-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0162_99_SAIDA*/ //GOTO
                    return;

                    /*" -692- ELSE */
                }
                else
                {


                    /*" -693- MOVE 'R0162' TO WNR-EXEC-SQL */
                    _.Move("R0162", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -694- DISPLAY 'R0162 - PROBLEMAS FETCH CURSOR FONTES ... ' */
                    _.Display($"R0162 - PROBLEMAS FETCH CURSOR FONTES ... ");

                    /*" -694- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0162-00-FETCH-FONTES-DB-FETCH-1 */
        public void R0162_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -684- EXEC SQL FETCH C01_FONTES INTO :FONTES-COD-FONTE , :FONTES-NOME-FONTE END-EXEC. */

            if (C01_FONTES.Fetch())
            {
                _.Move(C01_FONTES.FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(C01_FONTES.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }

        }

        [StopWatch]
        /*" R0162-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R0162_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -689- EXEC SQL CLOSE C01_FONTES END-EXEC */

            C01_FONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0162_99_SAIDA*/

        [StopWatch]
        /*" R0163-00-PROCESSA-FONTES-SECTION */
        private void R0163_00_PROCESSA_FONTES_SECTION()
        {
            /*" -706- IF FONTES-COD-FONTE GREATER +500 */

            if (FONTES.DCLFONTES.FONTES_COD_FONTE > +500)
            {

                /*" -707- ADD 1 TO WS-IXF2 */
                AREA_DE_WORK.WS_IXF2.Value = AREA_DE_WORK.WS_IXF2 + 1;

                /*" -708- SET IXF1 TO WS-IXF2 */
                IXF1.Value = AREA_DE_WORK.WS_IXF2;

                /*" -709- ELSE */
            }
            else
            {


                /*" -712- SET IXF1 TO FONTES-COD-FONTE. */
                IXF1.Value = FONTES.DCLFONTES.FONTES_COD_FONTE;
            }


            /*" -713- MOVE FONTES-COD-FONTE TO TAB-COD-FONTE(IXF1) */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, WPARM_PARAMETRO.TAB_FONTES[IXF1].TAB_COD_FONTE);

            /*" -715- MOVE FONTES-NOME-FONTE TO TAB-NOM-FONTE(IXF1) */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, WPARM_PARAMETRO.TAB_FONTES[IXF1].TAB_NOM_FONTE);

            /*" -715- PERFORM R0162-00-FETCH-FONTES. */

            R0162_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0163_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSO-FINAL-SECTION */
        private void R0200_00_PROCESSO_FINAL_SECTION()
        {
            /*" -728- PERFORM R0210-00-CLOSE-ARQUIVOS */

            R0210_00_CLOSE_ARQUIVOS_SECTION();

            /*" -729- DISPLAY ' ' */
            _.Display($" ");

            /*" -730- DISPLAY 'REGISTROS LIDOS ....... ' ACLID-PROPOVA */
            _.Display($"REGISTROS LIDOS ....... {AREA_DE_WORK.ACLID_PROPOVA}");

            /*" -731- DISPLAY 'SELECIONADOS .......... ' ACSEL-PROPOVA */
            _.Display($"SELECIONADOS .......... {AREA_DE_WORK.ACSEL_PROPOVA}");

            /*" -732- DISPLAY 'GRAVADOS                ' */
            _.Display($"GRAVADOS                ");

            /*" -733- DISPLAY '- QUADRO 11             ' ACGRA-QUADRO11 */
            _.Display($"- QUADRO 11             {AREA_DE_WORK.ACGRA_QUADRO11}");

            /*" -735- DISPLAY ' ' */
            _.Display($" ");

            /*" -736- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -737- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -738- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -739- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -740- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -742- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -743- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -744- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -745- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -746- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -748- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -749- DISPLAY '   ' */
            _.Display($"   ");

            /*" -750- DISPLAY 'VG0601B - FIM NORMAL  ' WS-DATA-CURR ' - ' WS-HORA-CURR. */

            $"VG0601B - FIM NORMAL  {AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-CLOSE-ARQUIVOS-SECTION */
        private void R0210_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -763- MOVE 'R0210' TO WNR-EXEC-SQL. */
            _.Move("R0210", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

            /*" -764- CLOSE ARQUIVO-QUADRO11 */
            ARQUIVO_QUADRO11.Close();

            /*" -765- IF WS-STATUS NOT EQUAL '00' */

            if (AREA_DE_WORK.WS_STATUS != "00")
            {

                /*" -765- DISPLAY 'ERRO CLOSE ARQUIVO QUADRO11 .. ' WS-STATUS. */
                _.Display($"ERRO CLOSE ARQUIVO QUADRO11 .. {AREA_DE_WORK.WS_STATUS}");
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R1000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -778- MOVE SPACES TO WFIM-PROPOVA */
            _.Move("", AREA_DE_WORK.WFIM_PROPOVA);

            /*" -780- WRITE REG-SAIDA FROM WREL-CAB. */
            _.Move(WPARM_PARAMETRO.WREL_CAB.GetMoveValues(), REG_SAIDA);

            ARQUIVO_QUADRO11.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -781- PERFORM R1100-00-DECLARE-PROPOVA */

            R1100_00_DECLARE_PROPOVA_SECTION();

            /*" -782- PERFORM R1300-00-FETCH-PROPOVA */

            R1300_00_FETCH_PROPOVA_SECTION();

            /*" -783- PERFORM R1200-00-PROCESSA-PROPOVA UNTIL WFIM-PROPOVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PROPOVA.IsEmpty()))
            {

                R1200_00_PROCESSA_PROPOVA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DECLARE-PROPOVA-SECTION */
        private void R1100_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -816- PERFORM R1100_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R1100_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -818- PERFORM R1100_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R1100_00_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -821- MOVE 'R1100' TO WNR-EXEC-SQL */
                _.Move("R1100", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                /*" -822- DISPLAY 'R1100 - PROBLEMAS OPEN CURSOR PROPOVA ' */
                _.Display($"R1100 - PROBLEMAS OPEN CURSOR PROPOVA ");

                /*" -822- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R1100_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -818- EXEC SQL OPEN C01_PROPOVA END-EXEC. */

            C01_PROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-PROPOVA-SECTION */
        private void R1200_00_PROCESSA_PROPOVA_SECTION()
        {
            /*" -835- IF WS-PROD-ATU NOT = WS-PROD-ANT */

            if (AREA_DE_WORK.WS_PROD_ATU != AREA_DE_WORK.WS_PROD_ANT)
            {

                /*" -836- PERFORM R1500-00-LE-PRODUTO */

                R1500_00_LE_PRODUTO_SECTION();

                /*" -837- MOVE PRODUVG-NOME-PRODUTO TO WREL-PRODUTO */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, WPARM_PARAMETRO.WREL_DET.WREL_PRODUTO);

                /*" -838- MOVE WS-PROD-ATU TO WS-PROD-ANT */
                _.Move(AREA_DE_WORK.WS_PROD_ATU, AREA_DE_WORK.WS_PROD_ANT);

                /*" -840- END-IF. */
            }


            /*" -843- IF PRODUVG-ORIG-PRODU NOT = ( 'MULT' AND 'VIDAZUL' AND 'CAMP' ) */

            if (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("MULT", "VIDAZUL", "CAMP"))
            {

                /*" -846- PERFORM R1300-00-FETCH-PROPOVA UNTIL WS-PROD-ATU NOT = WS-PROD-ANT */

                while (!(AREA_DE_WORK.WS_PROD_ATU != AREA_DE_WORK.WS_PROD_ANT))
                {

                    R1300_00_FETCH_PROPOVA_SECTION();
                }

                /*" -847- GO TO R1200-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_EXIT*/ //GOTO
                return;

                /*" -849- END-IF. */
            }


            /*" -850- ADD 1 TO ACSEL-PROPOVA */
            AREA_DE_WORK.ACSEL_PROPOVA.Value = AREA_DE_WORK.ACSEL_PROPOVA + 1;

            /*" -852- MOVE PROPOVA-NUM-CERTIFICADO TO WREL-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WPARM_PARAMETRO.WREL_DET.WREL_NUM_CERTIFICADO);

            /*" -853- MOVE PROPOVA-COD-FONTE TO WREL-COD-FONTE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, WPARM_PARAMETRO.WREL_DET.WREL_COD_FONTE);

            /*" -854- IF PROPOVA-COD-FONTE LESS 101 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE < 101)
            {

                /*" -856- MOVE TAB-NOM-FONTE(PROPOVA-COD-FONTE) TO WREL-FONTE */
                _.Move(WPARM_PARAMETRO.TAB_FONTES[PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE].TAB_NOM_FONTE, WPARM_PARAMETRO.WREL_DET.WREL_FONTE);

                /*" -857- ELSE */
            }
            else
            {


                /*" -858- PERFORM R0500-00-SEARCH-FONTE */

                R0500_00_SEARCH_FONTE_SECTION();

                /*" -859- MOVE TAB-NOM-FONTE(IXF1) TO WREL-FONTE */
                _.Move(WPARM_PARAMETRO.TAB_FONTES[IXF1].TAB_NOM_FONTE, WPARM_PARAMETRO.WREL_DET.WREL_FONTE);

                /*" -861- END-IF. */
            }


            /*" -863- MOVE PROPOVA-AGE-COBRANCA TO WREL-AGE-COBRANCA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, WPARM_PARAMETRO.WREL_DET.WREL_AGE_COBRANCA);

            /*" -864- MOVE PROPOVA-DATA-QUITACAO TO WS-DATA-DB2 */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, AREA_DE_WORK.WS_DATA_DB2);

            /*" -865- MOVE WS-DIA-DB2 TO WREL-DD-QIT */
            _.Move(AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2, WPARM_PARAMETRO.WREL_DET.WREL_QUITACAO.WREL_DD_QIT);

            /*" -866- MOVE WS-MES-DB2 TO WREL-MM-QIT */
            _.Move(AREA_DE_WORK.WS_DATA_DB2.WS_MES_DB2, WPARM_PARAMETRO.WREL_DET.WREL_QUITACAO.WREL_MM_QIT);

            /*" -867- MOVE WS-ANO-DB2 TO WREL-AA-QIT */
            _.Move(AREA_DE_WORK.WS_DATA_DB2.WS_ANO_DB2, WPARM_PARAMETRO.WREL_DET.WREL_QUITACAO.WREL_AA_QIT);

            /*" -868- MOVE HISCOBPR-IMPSEGUR TO WREL-IMPSEGUR */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, WPARM_PARAMETRO.WREL_DET.WREL_IMPSEGUR);

            /*" -870- MOVE HISCOBPR-VLPREMIO TO WREL-VLPREMIO */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, WPARM_PARAMETRO.WREL_DET.WREL_VLPREMIO);

            /*" -871- PERFORM R2000-00-LE-SUREG */

            R2000_00_LE_SUREG_SECTION();

            /*" -872- MOVE MALHACEF-COD-SUREG-SASSE TO WREL-COD-SR */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_SUREG_SASSE, WPARM_PARAMETRO.WREL_DET.WREL_COD_SR);

            /*" -873- MOVE SUREGSAS-NOME-SUREG-SASSE TO WREL-SR */
            _.Move(SUREGSAS.DCLSUREG_SASSE.SUREGSAS_NOME_SUREG_SASSE, WPARM_PARAMETRO.WREL_DET.WREL_SR);

            /*" -874- PERFORM R2100-00-LE-FUNCEF */

            R2100_00_LE_FUNCEF_SECTION();

            /*" -875- MOVE FUNCICEF-NOME-FUNCIONARIO TO WREL-INDICADOR */
            _.Move(FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO, WPARM_PARAMETRO.WREL_DET.WREL_INDICADOR);

            /*" -877- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO WREL-MATR-INDIC */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, WPARM_PARAMETRO.WREL_DET.WREL_MATR_INDIC);

            /*" -878- PERFORM R1400-00-LE-CLIENTE */

            R1400_00_LE_CLIENTE_SECTION();

            /*" -879- MOVE CLIENTES-CGCCPF TO WREL-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WPARM_PARAMETRO.WREL_DET.WREL_CPF);

            /*" -881- MOVE CLIENTES-NOME-RAZAO TO WREL-NOME. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WPARM_PARAMETRO.WREL_DET.WREL_NOME);

            /*" -883- WRITE REG-SAIDA FROM WREL-DET. */
            _.Move(WPARM_PARAMETRO.WREL_DET.GetMoveValues(), REG_SAIDA);

            ARQUIVO_QUADRO11.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -885- ADD 1 TO ACGRA-QUADRO11. */
            AREA_DE_WORK.ACGRA_QUADRO11.Value = AREA_DE_WORK.ACGRA_QUADRO11 + 1;

            /*" -885- PERFORM R1300-00-FETCH-PROPOVA. */

            R1300_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_EXIT*/

        [StopWatch]
        /*" R1300-00-FETCH-PROPOVA-SECTION */
        private void R1300_00_FETCH_PROPOVA_SECTION()
        {
            /*" -907- PERFORM R1300_00_FETCH_PROPOVA_DB_FETCH_1 */

            R1300_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -910- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -911- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -912- MOVE '*' TO WFIM-PROPOVA */
                    _.Move("*", AREA_DE_WORK.WFIM_PROPOVA);

                    /*" -913- MOVE ALL '9' TO WS-PROD-ATU */
                    _.MoveAll("9", AREA_DE_WORK.WS_PROD_ATU);

                    /*" -913- PERFORM R1300_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R1300_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -915- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -916- ELSE */
                }
                else
                {


                    /*" -917- MOVE 'R1300' TO WNR-EXEC-SQL */
                    _.Move("R1300", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -918- DISPLAY 'R1300 - PROBLEMAS FETCH CURSOR PROPOVA ... ' */
                    _.Display($"R1300 - PROBLEMAS FETCH CURSOR PROPOVA ... ");

                    /*" -919- DISPLAY 'APOLICE ....... ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE ....... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -920- DISPLAY 'SUBGRUPO ...... ' PROPOVA-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO ...... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                    /*" -921- DISPLAY 'CERTIFICADO ... ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO ... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -922- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -924- END-IF. */
                }

            }


            /*" -925- MOVE PROPOVA-NUM-APOLICE TO WS-APOL-ATU */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AREA_DE_WORK.WS_PROD_ATU.WS_APOL_ATU);

            /*" -927- MOVE PROPOVA-COD-SUBGRUPO TO WS-SUBG-ATU */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, AREA_DE_WORK.WS_PROD_ATU.WS_SUBG_ATU);

            /*" -927- ADD 1 TO ACLID-PROPOVA. */
            AREA_DE_WORK.ACLID_PROPOVA.Value = AREA_DE_WORK.ACLID_PROPOVA + 1;

        }

        [StopWatch]
        /*" R1300-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R1300_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -907- EXEC SQL FETCH C01_PROPOVA INTO :PROPOVA-NUM-CERTIFICADO , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-COD-FONTE , :PROPOVA-SIT-REGISTRO , :PROPOVA-AGE-COBRANCA , :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-MATRI-VENDEDOR, :HISCOBPR-VLPREMIO , :HISCOBPR-IMPSEGUR END-EXEC. */

            if (C01_PROPOVA.Fetch())
            {
                _.Move(C01_PROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(C01_PROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(C01_PROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(C01_PROPOVA.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(C01_PROPOVA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(C01_PROPOVA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(C01_PROPOVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(C01_PROPOVA.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(C01_PROPOVA.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(C01_PROPOVA.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
            }

        }

        [StopWatch]
        /*" R1300-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R1300_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -913- EXEC SQL CLOSE C01_PROPOVA END-EXEC */

            C01_PROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-LE-CLIENTE-SECTION */
        private void R1400_00_LE_CLIENTE_SECTION()
        {
            /*" -946- PERFORM R1400_00_LE_CLIENTE_DB_SELECT_1 */

            R1400_00_LE_CLIENTE_DB_SELECT_1();

            /*" -949- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -950- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -956- MOVE ZEROS TO CLIENTES-COD-CLIENTE */
                    _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

                    /*" -957- ELSE */
                }
                else
                {


                    /*" -958- DISPLAY 'R1400 - PROBLEMAS LEITURA SEGURADOS_VGAP' */
                    _.Display($"R1400 - PROBLEMAS LEITURA SEGURADOS_VGAP");

                    /*" -960- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -967- PERFORM R1400_00_LE_CLIENTE_DB_SELECT_2 */

            R1400_00_LE_CLIENTE_DB_SELECT_2();

            /*" -970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -971- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -972- MOVE ZEROS TO CLIENTES-CGCCPF */
                    _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                    /*" -973- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -974- ELSE */
                }
                else
                {


                    /*" -975- DISPLAY 'R1400 - PROBLEMAS LEITURA CLIENTES ' */
                    _.Display($"R1400 - PROBLEMAS LEITURA CLIENTES ");

                    /*" -976- DISPLAY 'COD-CLIENTE     = ' CLIENTES-COD-CLIENTE */
                    _.Display($"COD-CLIENTE     = {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                    /*" -976- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-LE-CLIENTE-DB-SELECT-1 */
        public void R1400_00_LE_CLIENTE_DB_SELECT_1()
        {
            /*" -946- EXEC SQL SELECT COD_CLIENTE INTO :CLIENTES-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1400_00_LE_CLIENTE_DB_SELECT_1_Query1 = new R1400_00_LE_CLIENTE_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_LE_CLIENTE_DB_SELECT_1_Query1.Execute(r1400_00_LE_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-LE-CLIENTE-DB-SELECT-2 */
        public void R1400_00_LE_CLIENTE_DB_SELECT_2()
        {
            /*" -967- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :CLIENTES-CGCCPF, :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r1400_00_LE_CLIENTE_DB_SELECT_2_Query1 = new R1400_00_LE_CLIENTE_DB_SELECT_2_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1400_00_LE_CLIENTE_DB_SELECT_2_Query1.Execute(r1400_00_LE_CLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }

        [StopWatch]
        /*" R1500-00-LE-PRODUTO-SECTION */
        private void R1500_00_LE_PRODUTO_SECTION()
        {
            /*" -993- PERFORM R1500_00_LE_PRODUTO_DB_SELECT_1 */

            R1500_00_LE_PRODUTO_DB_SELECT_1();

            /*" -996- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1000- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1002- MOVE SPACES TO PRODUVG-NOME-PRODUTO PRODUVG-ORIG-PRODU */
                    _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

                    /*" -1003- ELSE */
                }
                else
                {


                    /*" -1004- MOVE 'R1500' TO WNR-EXEC-SQL */
                    _.Move("R1500", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -1005- DISPLAY 'R1500 - PROBLEMAS LEITURA PRODUTOS_VG ' */
                    _.Display($"R1500 - PROBLEMAS LEITURA PRODUTOS_VG ");

                    /*" -1005- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-LE-PRODUTO-DB-SELECT-1 */
        public void R1500_00_LE_PRODUTO_DB_SELECT_1()
        {
            /*" -993- EXEC SQL SELECT NOME_PRODUTO, ORIG_PRODU INTO :PRODUVG-NOME-PRODUTO, :PRODUVG-ORIG-PRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r1500_00_LE_PRODUTO_DB_SELECT_1_Query1 = new R1500_00_LE_PRODUTO_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_00_LE_PRODUTO_DB_SELECT_1_Query1.Execute(r1500_00_LE_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(executed_1.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-LE-SUREG-SECTION */
        private void R2000_00_LE_SUREG_SECTION()
        {
            /*" -1021- PERFORM R2000_00_LE_SUREG_DB_SELECT_1 */

            R2000_00_LE_SUREG_DB_SELECT_1();

            /*" -1024- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1025- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1027- MOVE SPACES TO SUREGSAS-NOME-SUREG-SASSE */
                    _.Move("", SUREGSAS.DCLSUREG_SASSE.SUREGSAS_NOME_SUREG_SASSE);

                    /*" -1028- GO TO R2000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;

                    /*" -1029- ELSE */
                }
                else
                {


                    /*" -1030- MOVE 'R2000' TO WNR-EXEC-SQL */
                    _.Move("R2000", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -1031- DISPLAY 'R2000 - PROBLEMAS LEITURA AGENCIAS_CEF' */
                    _.Display($"R2000 - PROBLEMAS LEITURA AGENCIAS_CEF");

                    /*" -1033- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1038- PERFORM R2000_00_LE_SUREG_DB_SELECT_2 */

            R2000_00_LE_SUREG_DB_SELECT_2();

            /*" -1041- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1042- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1044- MOVE SPACES TO SUREGSAS-NOME-SUREG-SASSE */
                    _.Move("", SUREGSAS.DCLSUREG_SASSE.SUREGSAS_NOME_SUREG_SASSE);

                    /*" -1045- GO TO R2000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;

                    /*" -1046- ELSE */
                }
                else
                {


                    /*" -1047- MOVE 'R2000' TO WNR-EXEC-SQL */
                    _.Move("R2000", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -1048- DISPLAY 'R2000 - PROBLEMAS LEITURA SUREG_SASSE' */
                    _.Display($"R2000 - PROBLEMAS LEITURA SUREG_SASSE");

                    /*" -1049- DISPLAY 'COD_ESCNEG      = ' AGENCCEF-COD-ESCNEG */
                    _.Display($"COD_ESCNEG      = {AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG}");

                    /*" -1051- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1056- PERFORM R2000_00_LE_SUREG_DB_SELECT_3 */

            R2000_00_LE_SUREG_DB_SELECT_3();

            /*" -1059- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1060- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1062- MOVE SPACES TO SUREGSAS-NOME-SUREG-SASSE */
                    _.Move("", SUREGSAS.DCLSUREG_SASSE.SUREGSAS_NOME_SUREG_SASSE);

                    /*" -1063- ELSE */
                }
                else
                {


                    /*" -1064- MOVE 'R2000' TO WNR-EXEC-SQL */
                    _.Move("R2000", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -1065- DISPLAY 'R2000 - PROBLEMAS LEITURA SUREG_SASSE' */
                    _.Display($"R2000 - PROBLEMAS LEITURA SUREG_SASSE");

                    /*" -1066- DISPLAY 'COD_ESCNEG      = ' AGENCCEF-COD-ESCNEG */
                    _.Display($"COD_ESCNEG      = {AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG}");

                    /*" -1067- DISPLAY 'COD_SUREG_SASSE = ' MALHACEF-COD-SUREG-SASSE */
                    _.Display($"COD_SUREG_SASSE = {MALHACEF.DCLMALHA_CEF.MALHACEF_COD_SUREG_SASSE}");

                    /*" -1067- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2000-00-LE-SUREG-DB-SELECT-1 */
        public void R2000_00_LE_SUREG_DB_SELECT_1()
        {
            /*" -1021- EXEC SQL SELECT COD_ESCNEG INTO :AGENCCEF-COD-ESCNEG FROM SEGUROS.AGENCIAS_CEF WHERE COD_AGENCIA = :PROPOVA-AGE-COBRANCA END-EXEC. */

            var r2000_00_LE_SUREG_DB_SELECT_1_Query1 = new R2000_00_LE_SUREG_DB_SELECT_1_Query1()
            {
                PROPOVA_AGE_COBRANCA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA.ToString(),
            };

            var executed_1 = R2000_00_LE_SUREG_DB_SELECT_1_Query1.Execute(r2000_00_LE_SUREG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-LE-SUREG-DB-SELECT-2 */
        public void R2000_00_LE_SUREG_DB_SELECT_2()
        {
            /*" -1038- EXEC SQL SELECT COD_SUREG_SASSE INTO :MALHACEF-COD-SUREG-SASSE FROM SEGUROS.MALHA_CEF WHERE COD_SUREG = :AGENCCEF-COD-ESCNEG END-EXEC. */

            var r2000_00_LE_SUREG_DB_SELECT_2_Query1 = new R2000_00_LE_SUREG_DB_SELECT_2_Query1()
            {
                AGENCCEF_COD_ESCNEG = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG.ToString(),
            };

            var executed_1 = R2000_00_LE_SUREG_DB_SELECT_2_Query1.Execute(r2000_00_LE_SUREG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MALHACEF_COD_SUREG_SASSE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_SUREG_SASSE);
            }


        }

        [StopWatch]
        /*" R2100-00-LE-FUNCEF-SECTION */
        private void R2100_00_LE_FUNCEF_SECTION()
        {
            /*" -1086- PERFORM R2100_00_LE_FUNCEF_DB_SELECT_1 */

            R2100_00_LE_FUNCEF_DB_SELECT_1();

            /*" -1089- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1090- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1092- MOVE SPACES TO FUNCICEF-NOME-FUNCIONARIO */
                    _.Move("", FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);

                    /*" -1093- ELSE */
                }
                else
                {


                    /*" -1094- MOVE 'R2100' TO WNR-EXEC-SQL */
                    _.Move("R2100", WPARM_PARAMETRO.WABEND.WNR_EXEC_SQL);

                    /*" -1095- DISPLAY 'R2100 - PROBLEMAS LEITURA TAB.FUNCIOCEF' */
                    _.Display($"R2100 - PROBLEMAS LEITURA TAB.FUNCIOCEF");

                    /*" -1097- DISPLAY 'NUM-MATRI-VENDEDOR = ' PROPOVA-NUM-MATRI-VENDEDOR */
                    _.Display($"NUM-MATRI-VENDEDOR = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR}");

                    /*" -1097- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2100-00-LE-FUNCEF-DB-SELECT-1 */
        public void R2100_00_LE_FUNCEF_DB_SELECT_1()
        {
            /*" -1086- EXEC SQL SELECT NOME_FUNCIONARIO INTO :FUNCICEF-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :PROPOVA-NUM-MATRI-VENDEDOR END-EXEC. */

            var r2100_00_LE_FUNCEF_DB_SELECT_1_Query1 = new R2100_00_LE_FUNCEF_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_MATRI_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR.ToString(),
            };

            var executed_1 = R2100_00_LE_FUNCEF_DB_SELECT_1_Query1.Execute(r2100_00_LE_FUNCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NOME_FUNCIONARIO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);
            }


        }

        [StopWatch]
        /*" R2000-00-LE-SUREG-DB-SELECT-3 */
        public void R2000_00_LE_SUREG_DB_SELECT_3()
        {
            /*" -1056- EXEC SQL SELECT NOME_SUREG_SASSE INTO :SUREGSAS-NOME-SUREG-SASSE FROM SEGUROS.SUREG_SASSE WHERE COD_SUREG_SASSE = :MALHACEF-COD-SUREG-SASSE END-EXEC. */

            var r2000_00_LE_SUREG_DB_SELECT_3_Query1 = new R2000_00_LE_SUREG_DB_SELECT_3_Query1()
            {
                MALHACEF_COD_SUREG_SASSE = MALHACEF.DCLMALHA_CEF.MALHACEF_COD_SUREG_SASSE.ToString(),
            };

            var executed_1 = R2000_00_LE_SUREG_DB_SELECT_3_Query1.Execute(r2000_00_LE_SUREG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUREGSAS_NOME_SUREG_SASSE, SUREGSAS.DCLSUREG_SASSE.SUREGSAS_NOME_SUREG_SASSE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SEARCH-FONTE-SECTION */
        private void R0500_00_SEARCH_FONTE_SECTION()
        {
            /*" -1112- SET IXF1 TO 100. */
            IXF1.Value = 100;

            /*" -1114- SEARCH TAB-FONTES AT END */
            void SearchAtEnd0()
            {

                /*" -1115- DISPLAY 'R0500 - ERRO SEARCH TAB FONTES' */
                _.Display($"R0500 - ERRO SEARCH TAB FONTES");

                /*" -1116- DISPLAY 'FONTE = ' PROPOVA-COD-FONTE */
                _.Display($"FONTE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE}");

                /*" -1117- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1118- WHEN TAB-COD-FONTE (IXF1) = PROPOVA-COD-FONTE NEXT SENTENCE  END-SEARCH. */
            };

            var mustSearchAtEnd0 = true;
            for (; IXF1 < WPARM_PARAMETRO.TAB_FONTES.Items.Count; IXF1.Value++)
            {

                if (WPARM_PARAMETRO.TAB_FONTES[IXF1].TAB_COD_FONTE == PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE)
                {

                    mustSearchAtEnd0 = false;
                    continue;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1134- CLOSE ARQUIVO-QUADRO11 */
            ARQUIVO_QUADRO11.Close();

            /*" -1135- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WPARM_PARAMETRO.WABEND.WSQLCODE);

            /*" -1137- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WPARM_PARAMETRO.WSQLERRO.WSQLERRMC);

            /*" -1138- DISPLAY WABEND */
            _.Display(WPARM_PARAMETRO.WABEND);

            /*" -1139- DISPLAY WSQLERRO */
            _.Display(WPARM_PARAMETRO.WSQLERRO);

            /*" -1140- DISPLAY '----------------' */
            _.Display($"----------------");

            /*" -1141- DISPLAY 'ULTIMO REGISTRO LIDO ' */
            _.Display($"ULTIMO REGISTRO LIDO ");

            /*" -1142- DISPLAY 'NUM-CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
            _.Display($"NUM-CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -1143- DISPLAY 'NUM-APOLICE     ' PROPOVA-NUM-APOLICE */
            _.Display($"NUM-APOLICE     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

            /*" -1144- DISPLAY 'COD-SUBGRUPO    ' PROPOVA-COD-SUBGRUPO */
            _.Display($"COD-SUBGRUPO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

            /*" -1145- DISPLAY 'COD-FONTE       ' PROPOVA-COD-FONTE */
            _.Display($"COD-FONTE       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE}");

            /*" -1146- DISPLAY 'SIT-REGISTRO    ' PROPOVA-SIT-REGISTRO */
            _.Display($"SIT-REGISTRO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}");

            /*" -1147- DISPLAY 'AGE-COBRANCA    ' PROPOVA-AGE-COBRANCA */
            _.Display($"AGE-COBRANCA    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA}");

            /*" -1148- DISPLAY 'DATA-QUITACAO   ' PROPOVA-DATA-QUITACAO */
            _.Display($"DATA-QUITACAO   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO}");

            /*" -1149- DISPLAY 'VLPREMIO        ' HISCOBPR-VLPREMIO */
            _.Display($"VLPREMIO        {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO}");

            /*" -1151- DISPLAY 'IMPSEGUR        ' HISCOBPR-IMPSEGUR. */
            _.Display($"IMPSEGUR        {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR}");

            /*" -1151- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1155- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1155- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}