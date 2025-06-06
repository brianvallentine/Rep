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
using Sias.VidaEmGrupo.DB2.VG0134B;

namespace Code
{
    public class VG0134B
    {
        public bool IsCall { get; set; }

        public VG0134B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL MULTIPREMIADO              *      */
        /*"      *   PROGRAMA ...............  VG0134B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MANOEL MESSIAS                     *      */
        /*"      *   PROGRAMADOR ............  MANOEL MESSIAS                     *      */
        /*"      *   DATA CODIFICACAO .......  17/06/2004                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONTROLAR A APLICACAO DE REMISSAO  *      */
        /*"      *                             OU SUSPENSAO DE REMISSAO DE  PAGA- *      */
        /*"      *                             TO DE PREMIO POR  OCORRENCIA  DE   *      */
        /*"      *                             C.D.G.                             *      */
        /*"      *                             INICIALMENTE PARA AS APOLICES:     *      */
        /*"      *          ================>  109300000566 (FENAE)               *      */
        /*"      *                             109300000680 (APGCS)               *      */
        /*"      *                             109300000559 (EXCLUSIVO)           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - DEMANDA 181629                                   *      */
        /*"      *                                                                *      */
        /*"      *          - COLOCAR UM MES A MAIS NA DATA DE PROXIMO VENCIMENTO.*      */
        /*"      *                                                                *      */
        /*"      *   EM 18/01/2019 -  CLAUDETE RADEL                              *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 149.263                                      *      */
        /*"      *                                                                *      */
        /*"      *          - CORRECAO DE ABEND DEVIDO AO CALCULO RESULTA EM UMA  *      */
        /*"      *            DATA INVALIDA. SQLCODE -180.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/03/2017 -  FRANK CARVALHO                              *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 90728                                        *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE PARA CORRECAO DE REMISSAO PRD VIDA MULHER    *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/02/2015 -  JONNY ANDERSON C.SARAIVA                    *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 07/05/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                     A L T E R A C O E S                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 21/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DATA: 27/04/2007  -   MARCO PAIVA                            *      */
        /*"      *                                                                *      */
        /*"      *   A (DATA DO VENCIMENTO E DO PROXIMO VENCIMENTO) + ANO_REMISSAO*      */
        /*"      *      VAI PEGAR COMO REFERENCIA A COLUNA DATA_REFERENCIA DA     *      */
        /*"      *      DA RELATORIOS.                                            *      */
        /*"      *                                       PROCURAR  V.02           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DATA: 26/06/2006  -   MARCO PAIVA                            *      */
        /*"      *                                                                *      */
        /*"      *   O SEGURO TEM DIREITO A REMISS�O DE PREMIO INDEPENDENTE DE TER*      */
        /*"      *   PAGO OU NAO O SINISTRO            - PROCURAR   V.01          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PRODUTOS_VG                         V0PRODUTOSVG      INPUT    *      */
        /*"      * HIS_COBER_PROPOST                   V0COBERPROPVA     INPUT    *      */
        /*"      * PROPOSTAS_VA                        V0PROPOSTAVA      INPUT    *      */
        /*"      * CLIENTES                            V0CLIENTE         INPUT    *      */
        /*"      * SINISTRO_MESTRE                     V0MESTSINI        INPUT    *      */
        /*"      * SINISTRO_HISTORICO                  V1HISTSINI        INPUT    *      */
        /*"      * SINISTRO_CAUSA                      V0SINICAUSA       INPUT    *      */
        /*"      * PARAMETR_OPER_SINI                  V0SINI_OPER_FUNCAO INPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           VIND-REMISSAO         PIC S9(004)  VALUE +0  COMP.*/
        public IntBasis VIND_REMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1SIST-DTCURRENT      PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           HOST-QTD-ANOS         PIC S9(004)  VALUE +0  COMP.*/
        public IntBasis HOST_QTD_ANOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         HOST-QTD-ANO-REMISSAO PIC S9(004)V99 VALUE +0  COMP.*/
        public DoubleBasis HOST_QTD_ANO_REMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V99"), 2);
        /*"77           V0PROP-ANO            PIC S9(004)  VALUE +0  COMP.*/
        public IntBasis V0PROP_ANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V0PARC-ANO            PIC S9(004)  VALUE +0  COMP.*/
        public IntBasis V0PARC_ANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           HOST-VALOR-PAGO       PIC S9(013)V99                                                VALUE +0  COMP-3*/
        public DoubleBasis HOST_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           HOST-IMP-SEGURADA-IX  PIC S9(013)V99                                                VALUE +0  COMP-3*/
        public DoubleBasis HOST_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01                AREA-DE-WORK.*/
        public VG0134B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0134B_AREA_DE_WORK();
        public class VG0134B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WS-DATA-REFERENCIA         PIC  X(010)  VALUE SPACES.*/
            public StringBasis WS_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  FILLER  REDEFINES  WS-DATA-REFERENCIA.*/
            private _REDEF_VG0134B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG0134B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG0134B_FILLER_0(); _.Move(WS_DATA_REFERENCIA, _filler_0); VarBasis.RedefinePassValue(WS_DATA_REFERENCIA, _filler_0, WS_DATA_REFERENCIA); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_DATA_REFERENCIA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_DATA_REFERENCIA); }
            }  //Redefines
            public class _REDEF_VG0134B_FILLER_0 : VarBasis
            {
                /*"      10   WS-REFERENCIA-ANO     PIC  9(004).*/
                public IntBasis WS_REFERENCIA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10   FILLER                PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10   WS-REFERENCIA-MES     PIC  9(002).*/
                public IntBasis WS_REFERENCIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10   FILLER                PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10   WS-REFERENCIA-DIA     PIC  9(002).*/
                public IntBasis WS_REFERENCIA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  WS-DATA-AUX                PIC  X(010)  VALUE SPACES.*/

                public _REDEF_VG0134B_FILLER_0()
                {
                    WS_REFERENCIA_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_REFERENCIA_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_REFERENCIA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  FILLER  REDEFINES  WS-DATA-AUX.*/
            private _REDEF_VG0134B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_VG0134B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_VG0134B_FILLER_3(); _.Move(WS_DATA_AUX, _filler_3); VarBasis.RedefinePassValue(WS_DATA_AUX, _filler_3, WS_DATA_AUX); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_DATA_AUX); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WS_DATA_AUX); }
            }  //Redefines
            public class _REDEF_VG0134B_FILLER_3 : VarBasis
            {
                /*"      10   WS-DT-AUX-ANO         PIC  9(004).*/
                public IntBasis WS_DT_AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10   FILLER                PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10   WS-DT-AUX-MES         PIC  9(002).*/
                public IntBasis WS_DT_AUX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10   FILLER                PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10   WS-DT-AUX-DIA         PIC  9(002).*/
                public IntBasis WS_DT_AUX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05              WSL-SQLCODE      PIC  9(009)  VALUE ZEROES.*/

                public _REDEF_VG0134B_FILLER_3()
                {
                    WS_DT_AUX_ANO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_DT_AUX_MES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_DT_AUX_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05              WFIM-V0RELATORIOS PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05              AC-ANOS          PIC  9(004)  VALUE ZEROES.*/
            public IntBasis AC_ANOS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05              AC-L-RELATORIOS  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_L_RELATORIOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05              AC-U-PROPOSTA-C  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPOSTA_C { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05              AC-U-PROPOSTA-G  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPOSTA_G { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05              WABEND.*/
            public VG0134B_WABEND WABEND { get; set; } = new VG0134B_WABEND();
            public class VG0134B_WABEND : VarBasis
            {
                /*"    10            FILLER           PIC X(008)   VALUE                 'VG0134B '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0134B ");
                /*"    10            FILLER           PIC X(025)   VALUE                 '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10            WNR-EXEC-SQL     PIC X(004)   VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10            FILLER           PIC X(013)   VALUE                 ' *** SQLCODE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10            WSQLCODE         PIC ZZZZZZ999-                                                VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG0134B_WS_HORAS WS_HORAS { get; set; } = new VG0134B_WS_HORAS();
        public class VG0134B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG0134B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG0134B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG0134B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG0134B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VG0134B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG0134B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG0134B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG0134B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG0134B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VG0134B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VG0134B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG0134B_TOTAIS_ROT();
        public class VG0134B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 08 TIMES.*/
            public ListBasis<VG0134B_FILLER_9> FILLER_9 { get; set; } = new ListBasis<VG0134B_FILLER_9>(08);
            public class VG0134B_FILLER_9 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.PAROPESI PAROPESI { get; set; } = new Dclgens.PAROPESI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public VG0134B_CRELAT CRELAT { get; set; } = new VG0134B_CRELAT();
        public VG0134B_C_SINI C_SINI { get; set; } = new VG0134B_C_SINI();
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
            /*" -245- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -248- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -251- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -254- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -255- DISPLAY '          PROGRAMA EM EXECUCAO VG0134B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VG0134B          ");

            /*" -256- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -257- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -259- DISPLAY 'VERSAO V.06: ' FUNCTION WHEN-COMPILED ' - 181629 ' */

            $"VERSAO V.06: FUNCTION{_.WhenCompiled()} - 181629 "
            .Display();

            /*" -260- DISPLAY ' ' */
            _.Display($" ");

            /*" -267- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -268- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -270- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -272- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -274- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -275- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -276- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -284- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -287- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -290- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -292- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -293- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -295- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -308- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -311- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -313- DISPLAY 'VG0134B - ABRINDO CURSOR ...' . */
            _.Display($"VG0134B - ABRINDO CURSOR ...");

            /*" -314- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -314- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -317- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -318- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -320- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -322- DISPLAY 'PROCESSANDO . .......... ' . */
            _.Display($"PROCESSANDO . .......... ");

            /*" -324- PERFORM R0910-00-FETCH-RELATORIOS. */

            R0910_00_FETCH_RELATORIOS_SECTION();

            /*" -325- IF WFIM-V0RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty())
            {

                /*" -326- DISPLAY 'VG0134B - NENHUMA SOLICITACAO ENCONTRADA' */
                _.Display($"VG0134B - NENHUMA SOLICITACAO ENCONTRADA");

                /*" -328- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -331- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -333- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -335- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -336- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -336- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -339- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -339- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -284- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -308- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT ANO_REFERENCIA , NUM_APOLICE , NUM_CERTIFICADO, DATA_REFERENCIA, DATA_REFERENCIA - 01 MONTH, COD_SUBGRUPO, COD_PLANO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VG0134B' AND SIT_REGISTRO = '0' FOR UPDATE OF SIT_REGISTRO END-EXEC. */
            CRELAT = new VG0134B_CRELAT(false);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT ANO_REFERENCIA
							, 
							NUM_APOLICE
							, 
							NUM_CERTIFICADO
							, 
							DATA_REFERENCIA
							, 
							DATA_REFERENCIA - 01 MONTH
							, 
							COD_SUBGRUPO
							, 
							COD_PLANO 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_RELATORIO = 'VG0134B' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -314- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R1300-00-OBTEM-VALOR-PAGO-DB-DECLARE-1 */
        public void R1300_00_OBTEM_VALOR_PAGO_DB_DECLARE_1()
        {
            /*" -788- EXEC SQL DECLARE C_SINI CURSOR FOR SELECT H.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_CAUSA S, SEGUROS.GE_OPERACAO O WHERE M.NUM_APOLICE = :RELATORI-NUM-APOLICE AND M.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND M.COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO AND M.TIPO_SEGURADO = '1' AND S.RAMO_EMISSOR = M.RAMO AND S.COD_CAUSA = M.COD_CAUSA AND S.GRUPO_CAUSAS = 'C.D.G.' AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.IND_TIPO_FUNCAO IN ( 'IN' , 'JUR-INDENI' ) GROUP BY H.NUM_APOL_SINISTRO ORDER BY H.NUM_APOL_SINISTRO WITH UR END-EXEC. */
            C_SINI = new VG0134B_C_SINI(true);
            string GetQuery_C_SINI()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_CAUSA S
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE M.NUM_APOLICE = '{RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}' 
							AND M.NUM_CERTIFICADO = '{RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}' 
							AND M.COD_SUBGRUPO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}' 
							AND M.TIPO_SEGURADO = '1' 
							AND S.RAMO_EMISSOR = M.RAMO 
							AND S.COD_CAUSA = M.COD_CAUSA 
							AND S.GRUPO_CAUSAS = 'C.D.G.' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.IND_TIPO_FUNCAO IN ( 'IN'
							, 'JUR-INDENI' ) 
							GROUP BY H.NUM_APOL_SINISTRO 
							ORDER BY H.NUM_APOL_SINISTRO";

                return query;
            }
            C_SINI.GetQueryEvent += GetQuery_C_SINI;

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -345- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -346- DISPLAY ' ' . */
            _.Display($" ");

            /*" -348- DISPLAY '*--------  VG0134B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VG0134B - FIM NORMAL  --------*");

            /*" -348- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORIOS-SECTION */
        private void R0910_00_FETCH_RELATORIOS_SECTION()
        {
            /*" -359- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -367- PERFORM R0910_00_FETCH_RELATORIOS_DB_FETCH_1 */

            R0910_00_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -371- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -371- PERFORM R0910_00_FETCH_RELATORIOS_DB_CLOSE_1 */

                    R0910_00_FETCH_RELATORIOS_DB_CLOSE_1();

                    /*" -373- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0RELATORIOS);

                    /*" -374- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -375- ELSE */
                }
                else
                {


                    /*" -377- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -378- MOVE RELATORI-DATA-REFERENCIA TO WS-DATA-REFERENCIA. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, AREA_DE_WORK.WS_DATA_REFERENCIA);

            /*" -378- ADD 1 TO AC-L-RELATORIOS. */
            AREA_DE_WORK.AC_L_RELATORIOS.Value = AREA_DE_WORK.AC_L_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORIOS-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -367- EXEC SQL FETCH CRELAT INTO :RELATORI-ANO-REFERENCIA , :RELATORI-NUM-APOLICE , :RELATORI-NUM-CERTIFICADO , :RELATORI-DATA-REFERENCIA , :WS-DATA-AUX, :RELATORI-COD-SUBGRUPO , :RELATORI-COD-PLANO END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.RELATORI_ANO_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);
                _.Move(CRELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(CRELAT.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(CRELAT.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(CRELAT.WS_DATA_AUX, AREA_DE_WORK.WS_DATA_AUX);
                _.Move(CRELAT.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(CRELAT.RELATORI_COD_PLANO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORIOS-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORIOS_DB_CLOSE_1()
        {
            /*" -371- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -388- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -389- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -400- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -408- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -411- IF HOST-IMP-SEGURADA-IX NOT EQUAL ZEROES */

            if (HOST_IMP_SEGURADA_IX != 00)
            {

                /*" -412- IF HOST-IMP-SEGURADA-IX > 11 */

                if (HOST_IMP_SEGURADA_IX > 11)
                {

                    /*" -414- COMPUTE HOST-QTD-ANO-REMISSAO = HOST-IMP-SEGURADA-IX / 12 */
                    HOST_QTD_ANO_REMISSAO.Value = HOST_IMP_SEGURADA_IX / 12f;

                    /*" -415- ELSE */
                }
                else
                {


                    /*" -416- MOVE HOST-IMP-SEGURADA-IX TO HOST-QTD-ANO-REMISSAO */
                    _.Move(HOST_IMP_SEGURADA_IX, HOST_QTD_ANO_REMISSAO);

                    /*" -417- END-IF */
                }


                /*" -418- ELSE */
            }
            else
            {


                /*" -419- MOVE HOST-IMP-SEGURADA-IX TO HOST-QTD-ANO-REMISSAO */
                _.Move(HOST_IMP_SEGURADA_IX, HOST_QTD_ANO_REMISSAO);

                /*" -421- END-IF */
            }


            /*" -423- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -425- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -426- DISPLAY 'SQLCODE...' SQLCODE */
                    _.Display($"SQLCODE...{DB.SQLCODE}");

                    /*" -430- DISPLAY 'APOLICE NAO CADASTRADA (VG_COBERTURAS_SUBG)' RELATORI-NUM-APOLICE ' ' RELATORI-COD-SUBGRUPO ' ' RELATORI-COD-PLANO */

                    $"APOLICE NAO CADASTRADA (VG_COBERTURAS_SUBG){RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO} {RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO}"
                    .Display();

                    /*" -431- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -432- ELSE */
                }
                else
                {


                    /*" -433- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -434- END-IF */
                }


                /*" -443- END-IF */
            }


            /*" -446- MOVE HOST-QTD-ANO-REMISSAO TO HOST-QTD-ANOS */
            _.Move(HOST_QTD_ANO_REMISSAO, HOST_QTD_ANOS);

            /*" -447- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -449- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -460- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -463- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -464- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -465- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -467- DISPLAY 'CERTIFICADO NAO CADASTRADO (PROPOSTAS_VA)' RELATORI-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO NAO CADASTRADO (PROPOSTAS_VA){RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -468- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -469- ELSE */
                }
                else
                {


                    /*" -471- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -472- MOVE 05 TO SII. */
            _.Move(05, WS_HORAS.SII);

            /*" -474- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -483- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -486- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -488- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -490- DISPLAY 'CERTIFICADO NAO CADASTRADO (PARCELAS_VIDAZUL)' RELATORI-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO NAO CADASTRADO (PARCELAS_VIDAZUL){RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -491- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -492- ELSE */
                }
                else
                {


                    /*" -497- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -498- MOVE ZEROS TO HOST-VALOR-PAGO. */
            _.Move(0, HOST_VALOR_PAGO);

            /*" -501- PERFORM R1300-00-OBTEM-VALOR-PAGO */

            R1300_00_OBTEM_VALOR_PAGO_SECTION();

            /*" -503- COMPUTE AC-ANOS = V0PROP-ANO - V0PARC-ANO. */
            AREA_DE_WORK.AC_ANOS.Value = V0PROP_ANO - V0PARC_ANO;

            /*" -504- DISPLAY 'RELATORI-ANO-REFERENCIA...' RELATORI-ANO-REFERENCIA */
            _.Display($"RELATORI-ANO-REFERENCIA...{RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA}");

            /*" -506- DISPLAY 'HOST-QTD-ANO-REMISSAO.....' HOST-QTD-ANO-REMISSAO */
            _.Display($"HOST-QTD-ANO-REMISSAO.....{HOST_QTD_ANO_REMISSAO}");

            /*" -512- IF RELATORI-ANO-REFERENCIA EQUAL ZEROES AND AC-ANOS EQUAL HOST-QTD-ANO-REMISSAO */

            if (RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA == 00 && AREA_DE_WORK.AC_ANOS == HOST_QTD_ANO_REMISSAO)
            {

                /*" -513- IF HOST-IMP-SEGURADA-IX > 11 */

                if (HOST_IMP_SEGURADA_IX > 11)
                {

                    /*" -514- PERFORM R1100-00-CANCELA-REMISSAO */

                    R1100_00_CANCELA_REMISSAO_SECTION();

                    /*" -515- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -516- ELSE */
                }
                else
                {


                    /*" -517- PERFORM R1101-00-CANCELA-REMISSAO-MES */

                    R1101_00_CANCELA_REMISSAO_MES_SECTION();

                    /*" -518- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -519- END-IF */
                }


                /*" -520- ELSE */
            }
            else
            {


                /*" -526- IF RELATORI-ANO-REFERENCIA GREATER ZEROES AND RELATORI-ANO-REFERENCIA EQUAL HOST-QTD-ANO-REMISSAO */

                if (RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA > 00 && RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA == HOST_QTD_ANO_REMISSAO)
                {

                    /*" -527- IF HOST-IMP-SEGURADA-IX > 11 */

                    if (HOST_IMP_SEGURADA_IX > 11)
                    {

                        /*" -528- PERFORM R1200-00-GERA-REMISSAO */

                        R1200_00_GERA_REMISSAO_SECTION();

                        /*" -529- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -530- ELSE */
                    }
                    else
                    {


                        /*" -531- PERFORM R1201-00-GERA-REMISSAO-MES */

                        R1201_00_GERA_REMISSAO_MES_SECTION();

                        /*" -532- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -533- END-IF */
                    }


                    /*" -538- ELSE */
                }
                else
                {


                    /*" -540- GO TO R1000-10-NEXT. */

                    R1000_10_NEXT(); //GOTO
                    return;
                }

            }


            /*" -544- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -547- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -548- DISPLAY ' ERRO UPDATE CURSOR ' */
                _.Display($" ERRO UPDATE CURSOR ");

                /*" -548- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -408- EXEC SQL SELECT IMP_SEGURADA_IX INTO :HOST-IMP-SEGURADA-IX FROM SEGUROS.VG_COBERTURAS_SUBG WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO AND COD_COBERTURA = :RELATORI-COD-PLANO WITH UR END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_IMP_SEGURADA_IX, HOST_IMP_SEGURADA_IX);
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -552- PERFORM R0910-00-FETCH-RELATORIOS. */

            R0910_00_FETCH_RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -460- EXEC SQL SELECT NUM_PARCELA , YEAR(DTPROXVEN), DTPROXVEN , DATA_VENCIMENTO INTO :PROPOVA-NUM-PARCELA, :V0PROP-ANO, :PROPOVA-DTPROXVEN, :PROPOVA-DATA-VENCIMENTO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(executed_1.V0PROP_ANO, V0PROP_ANO);
                _.Move(executed_1.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(executed_1.PROPOVA_DATA_VENCIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -544- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE CURRENT OF CRELAT END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1(CRELAT)
            {
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -483- EXEC SQL SELECT YEAR(DATA_VENCIMENTO), DATA_VENCIMENTO INTO :V0PARC-ANO, :PARCEVID-DATA-VENCIMENTO FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA WITH UR END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_ANO, V0PARC_ANO);
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
            }


        }

        [StopWatch]
        /*" R1100-00-CANCELA-REMISSAO-SECTION */
        private void R1100_00_CANCELA_REMISSAO_SECTION()
        {
            /*" -564- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -565- MOVE 07 TO SII. */
            _.Move(07, WS_HORAS.SII);

            /*" -567- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -577- PERFORM R1100_00_CANCELA_REMISSAO_DB_UPDATE_1 */

            R1100_00_CANCELA_REMISSAO_DB_UPDATE_1();

            /*" -581- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -583- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -585- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -587- ADD 1 TO AC-U-PROPOSTA-C. */
            AREA_DE_WORK.AC_U_PROPOSTA_C.Value = AREA_DE_WORK.AC_U_PROPOSTA_C + 1;

            /*" -591- PERFORM R1100_00_CANCELA_REMISSAO_DB_UPDATE_2 */

            R1100_00_CANCELA_REMISSAO_DB_UPDATE_2();

            /*" -594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -595- DISPLAY ' ERRO UPDATE CURSOR ' */
                _.Display($" ERRO UPDATE CURSOR ");

                /*" -595- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-CANCELA-REMISSAO-DB-UPDATE-1 */
        public void R1100_00_CANCELA_REMISSAO_DB_UPDATE_1()
        {
            /*" -577- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET DTPROXVEN = DTPROXVEN - :HOST-QTD-ANOS YEARS, DATA_VENCIMENTO = DATA_VENCIMENTO - :HOST-QTD-ANOS YEARS , COD_USUARIO = 'VG0134B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1 = new R1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1()
            {
                HOST_QTD_ANOS = HOST_QTD_ANOS.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            R1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1.Execute(r1100_00_CANCELA_REMISSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CANCELA-REMISSAO-DB-UPDATE-2 */
        public void R1100_00_CANCELA_REMISSAO_DB_UPDATE_2()
        {
            /*" -591- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE CURRENT OF CRELAT END-EXEC. */

            var r1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1 = new R1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1(CRELAT)
            {
            };

            R1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1.Execute(r1100_00_CANCELA_REMISSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1101-00-CANCELA-REMISSAO-MES-SECTION */
        private void R1101_00_CANCELA_REMISSAO_MES_SECTION()
        {
            /*" -607- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -608- MOVE 07 TO SII. */
            _.Move(07, WS_HORAS.SII);

            /*" -611- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -621- PERFORM R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1 */

            R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1();

            /*" -625- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -627- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -629- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -631- ADD 1 TO AC-U-PROPOSTA-C. */
            AREA_DE_WORK.AC_U_PROPOSTA_C.Value = AREA_DE_WORK.AC_U_PROPOSTA_C + 1;

            /*" -635- PERFORM R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2 */

            R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2();

            /*" -638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -639- DISPLAY ' ERRO UPDATE CURSOR ' */
                _.Display($" ERRO UPDATE CURSOR ");

                /*" -639- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1101-00-CANCELA-REMISSAO-MES-DB-UPDATE-1 */
        public void R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1()
        {
            /*" -621- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET DTPROXVEN = DTPROXVEN - :HOST-QTD-ANOS MONTH, DATA_VENCIMENTO = DATA_VENCIMENTO - :HOST-QTD-ANOS MONTH , COD_USUARIO = 'VG0134B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1_Update1 = new R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1_Update1()
            {
                HOST_QTD_ANOS = HOST_QTD_ANOS.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1_Update1.Execute(r1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1101_99_SAIDA*/

        [StopWatch]
        /*" R1101-00-CANCELA-REMISSAO-MES-DB-UPDATE-2 */
        public void R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2()
        {
            /*" -635- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE CURRENT OF CRELAT END-EXEC. */

            var r1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2_Update1 = new R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2_Update1(CRELAT)
            {
            };

            R1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2_Update1.Execute(r1101_00_CANCELA_REMISSAO_MES_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1200-00-GERA-REMISSAO-SECTION */
        private void R1200_00_GERA_REMISSAO_SECTION()
        {
            /*" -654- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -655- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -666- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -677- PERFORM R1200_00_GERA_REMISSAO_DB_UPDATE_1 */

            R1200_00_GERA_REMISSAO_DB_UPDATE_1();

            /*" -687- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -689- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -691- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -693- ADD 1 TO AC-U-PROPOSTA-G. */
            AREA_DE_WORK.AC_U_PROPOSTA_G.Value = AREA_DE_WORK.AC_U_PROPOSTA_G + 1;

            /*" -697- PERFORM R1200_00_GERA_REMISSAO_DB_UPDATE_2 */

            R1200_00_GERA_REMISSAO_DB_UPDATE_2();

            /*" -700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -701- DISPLAY ' ERRO UPDATE CURSOR ' */
                _.Display($" ERRO UPDATE CURSOR ");

                /*" -701- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-GERA-REMISSAO-DB-UPDATE-1 */
        public void R1200_00_GERA_REMISSAO_DB_UPDATE_1()
        {
            /*" -677- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET DTPROXVEN = DATE(:WS-DATA-REFERENCIA) + :HOST-QTD-ANOS YEARS + 01 MONTH , DATA_VENCIMENTO = DATE(:WS-DATA-AUX) + :HOST-QTD-ANOS YEARS + 01 MONTH , COD_USUARIO = 'VG0134B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC */

            var r1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1 = new R1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1()
            {
                WS_DATA_REFERENCIA = AREA_DE_WORK.WS_DATA_REFERENCIA.ToString(),
                HOST_QTD_ANOS = HOST_QTD_ANOS.ToString(),
                WS_DATA_AUX = AREA_DE_WORK.WS_DATA_AUX.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            R1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1.Execute(r1200_00_GERA_REMISSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GERA-REMISSAO-DB-UPDATE-2 */
        public void R1200_00_GERA_REMISSAO_DB_UPDATE_2()
        {
            /*" -697- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE CURRENT OF CRELAT END-EXEC. */

            var r1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1 = new R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1(CRELAT)
            {
            };

            R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1.Execute(r1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1201-00-GERA-REMISSAO-MES-SECTION */
        private void R1201_00_GERA_REMISSAO_MES_SECTION()
        {
            /*" -717- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -718- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -726- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -737- PERFORM R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1 */

            R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1();

            /*" -741- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -743- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -745- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -747- ADD 1 TO AC-U-PROPOSTA-G. */
            AREA_DE_WORK.AC_U_PROPOSTA_G.Value = AREA_DE_WORK.AC_U_PROPOSTA_G + 1;

            /*" -751- PERFORM R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2 */

            R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2();

            /*" -754- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -755- DISPLAY ' ERRO UPDATE CURSOR ' */
                _.Display($" ERRO UPDATE CURSOR ");

                /*" -755- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1201-00-GERA-REMISSAO-MES-DB-UPDATE-1 */
        public void R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1()
        {
            /*" -737- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET DTPROXVEN = DATE(:WS-DATA-REFERENCIA) + :HOST-QTD-ANOS MONTHS + 01 MONTH , DATA_VENCIMENTO = DATE(:WS-DATA-AUX) + :HOST-QTD-ANOS MONTHS + 01 MONTH , COD_USUARIO = 'VG0134B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC */

            var r1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1 = new R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1()
            {
                WS_DATA_REFERENCIA = AREA_DE_WORK.WS_DATA_REFERENCIA.ToString(),
                HOST_QTD_ANOS = HOST_QTD_ANOS.ToString(),
                WS_DATA_AUX = AREA_DE_WORK.WS_DATA_AUX.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            R1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1.Execute(r1201_00_GERA_REMISSAO_MES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1201_99_SAIDA*/

        [StopWatch]
        /*" R1201-00-GERA-REMISSAO-MES-DB-UPDATE-2 */
        public void R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2()
        {
            /*" -751- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE CURRENT OF CRELAT END-EXEC. */

            var r1201_00_GERA_REMISSAO_MES_DB_UPDATE_2_Update1 = new R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2_Update1(CRELAT)
            {
            };

            R1201_00_GERA_REMISSAO_MES_DB_UPDATE_2_Update1.Execute(r1201_00_GERA_REMISSAO_MES_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1300-00-OBTEM-VALOR-PAGO-SECTION */
        private void R1300_00_OBTEM_VALOR_PAGO_SECTION()
        {
            /*" -766- MOVE 06 TO SII. */
            _.Move(06, WS_HORAS.SII);

            /*" -768- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -788- PERFORM R1300_00_OBTEM_VALOR_PAGO_DB_DECLARE_1 */

            R1300_00_OBTEM_VALOR_PAGO_DB_DECLARE_1();

            /*" -790- PERFORM R1300_00_OBTEM_VALOR_PAGO_DB_OPEN_1 */

            R1300_00_OBTEM_VALOR_PAGO_DB_OPEN_1();

            /*" -792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -793- DISPLAY 'ERRO OPEN DECLARE C_SINI' */
                _.Display($"ERRO OPEN DECLARE C_SINI");

                /*" -795- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -795- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1300_10_FETCH */

            R1300_10_FETCH();

        }

        [StopWatch]
        /*" R1300-00-OBTEM-VALOR-PAGO-DB-OPEN-1 */
        public void R1300_00_OBTEM_VALOR_PAGO_DB_OPEN_1()
        {
            /*" -790- EXEC SQL OPEN C_SINI END-EXEC. */

            C_SINI.Open();

        }

        [StopWatch]
        /*" R1300-10-FETCH */
        private void R1300_10_FETCH(bool isPerform = false)
        {
            /*" -801- PERFORM R1300_10_FETCH_DB_FETCH_1 */

            R1300_10_FETCH_DB_FETCH_1();

            /*" -804- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -805- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -805- PERFORM R1300_10_FETCH_DB_CLOSE_1 */

                    R1300_10_FETCH_DB_CLOSE_1();

                    /*" -807- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -808- ELSE */
                }
                else
                {


                    /*" -809- DISPLAY 'ERRO FETCH C_SINI' */
                    _.Display($"ERRO FETCH C_SINI");

                    /*" -813- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -815- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -817- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -819- CALL 'SI1018S' USING SI1001S-PARAMETROS */
            _.Call("SI1018S", LBSI1001.SI1001S_PARAMETROS);

            /*" -820- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -822- DISPLAY 'PROBLEMA CALL SI1018S ' ' ' SINISHIS-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI1018S  {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -823- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -824- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -825- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -826- ELSE */
            }
            else
            {


                /*" -828- ADD SI1001S-VALOR-CALCULADO TO HOST-VALOR-PAGO. */
                HOST_VALOR_PAGO.Value = HOST_VALOR_PAGO + LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO;
            }


            /*" -828- GO TO R1300-10-FETCH. */
            new Task(() => R1300_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1300-10-FETCH-DB-FETCH-1 */
        public void R1300_10_FETCH_DB_FETCH_1()
        {
            /*" -801- EXEC SQL FETCH C_SINI INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (C_SINI.Fetch())
            {
                _.Move(C_SINI.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R1300-10-FETCH-DB-CLOSE-1 */
        public void R1300_10_FETCH_DB_CLOSE_1()
        {
            /*" -805- EXEC SQL CLOSE C_SINI END-EXEC */

            C_SINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -841- DISPLAY 'LIDOS  RELATORIOS        ' AC-L-RELATORIOS. */
            _.Display($"LIDOS  RELATORIOS        {AREA_DE_WORK.AC_L_RELATORIOS}");

            /*" -842- DISPLAY 'UPDATE PROPOSTAS (CANCE) ' AC-U-PROPOSTA-C. */
            _.Display($"UPDATE PROPOSTAS (CANCE) {AREA_DE_WORK.AC_U_PROPOSTA_C}");

            /*" -842- DISPLAY 'UPDATE PROPOSTAS (GRAVA) ' AC-U-PROPOSTA-G. */
            _.Display($"UPDATE PROPOSTAS (GRAVA) {AREA_DE_WORK.AC_U_PROPOSTA_G}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -851- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -852- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -861- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -862- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -863- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -864- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_9[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_9[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -865- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_9[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_9[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -874- DISPLAY ' ' . */
            _.Display($" ");

            /*" -875- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -880- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -881- IF SII < 09 */

            if (WS_HORAS.SII < 09)
            {

                /*" -884- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_9[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -886- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -887- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -899- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -900- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -901- DISPLAY 'CERTIFICADO ' RELATORI-NUM-CERTIFICADO. */
            _.Display($"CERTIFICADO {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

            /*" -903- DISPLAY 'LIDOS       ' AC-L-RELATORIOS. */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_RELATORIOS}");

            /*" -904- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -906- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -906- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -908- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -912- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -912- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}