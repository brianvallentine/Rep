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

namespace Code
{
    public class PF0110B
    {
        public bool IsCall { get; set; }

        public PF0110B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  LER MOVIMENTO  ENVIADO PELO SIGPF  *      */
        /*"      *                             MJUNMOV E SEPARA AS PROPOSTAS POR  *      */
        /*"      *                             BU (PRESTAMISTA, VIDA EM GRUPO, E  *      */
        /*"      *                             OUTROS).                           *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS / REGINALDO SILVA      *      */
        /*"      *   PROGRAMA ...............  PF0110B                            *      */
        /*"      *   DATA ...................  07/08/2009.                        *      */
        /*"      *   CADMUS .................  27301.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             NAO GRAVAR O PRODUTO 56 - VIDA JUNTOS  + *      */
        /*"      *                       FUTURO, NO ARQUIVO ARDESP; O MESMO E TRA *      */
        /*"      *                       TADO NO ARQUIVO DE BILHETES.             *      */
        /*"      *                                                                *      */
        /*"      * ATENDE JAZZ 520072                                             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE M.13          REGINALDO SILVA                          *      */
        /*"      *                       01/07/2024                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             ADICIONANDO O PRODUTO 37-VIDA EXECUTIVO  *      */
        /*"      *                                                                *      */
        /*"      * ATENDE JAZZ 520072                                             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.12          REGINALDO SILVA                          *      */
        /*"      *                       28/11/2023                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11             CRIACAO DO ARQUIVO ARQDESP COM AS PROPOS *      */
        /*"      * ATENDE JAZZ 334451    TAS DESPREZADAS  NA  LEITURA DO  MJUNMOV *      */
        /*"      *                       NO HEADER 'SEGINFDB' COM A  SIT PROPOSTA *      */
        /*"      *                       IGUAL A TDA (TENTATIVA DEBITO ADESAO).   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.11          HUSNI ALI HUSNI / REGINALDO SILVA        *      */
        /*"      *                       05/11/2021                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10             PRODUTO 06--VIDA EXCLUSIVO, SERA TRATADO *      */
        /*"      * ATENDE REDMINE 3443   NO ARQVG, SOLICITADO PELA CLAUDETE.      *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.10          REGINALDO SILVA                          *      */
        /*"      *                       30/07/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09             PRODUTO 09 - VOLTA A SER GRAVADO NO      *      */
        /*"      * ATENDE CADMUS 152120  ARQESP - ASTERISCA VERSAO V.06           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.09          FRANK CARVALHO                           *      */
        /*"      *                       21/07/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08             NOVO PRODUTO PRESTAMISTA_PJ CODIGO 0076  *      */
        /*"      * ATENDE CADMUS 124191  ARQVP                                    *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.08          REGINALDO SILVA                          *      */
        /*"      *                       13/11/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 07             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       25/06/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             AJUSTE NO PRODUTO 09 BILHETES EM FUNCAO  *      */
        /*"      * ATENDE CADMUS 99532   DA NUMERACAO DAS PROPOSTAS (000847100..) *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.06          REGINALDO DA SILVA                       *      */
        /*"      *                       24/06/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05 - CAD 81704                                          *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A SEPARAR ARQUIVO COM ORIGEM DE PROPOSTA *      */
        /*"      *                 80 - CRESCER                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/07/2013 - FAST COMPUTER - TERCIO CARVALHO              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 40.915                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A GERAR TRAILLER PARA O ARQUIVO ESP.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/04/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 36.414                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUIR ARQUIVO DE SAIDA PARA PROPOSTAS        *      */
        /*"      *                 DE PRODUTOS NAO IDENTIFICADOS                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/02/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 31.471                                       *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERACAO PARA PROCESSAR AS INFORMACOES        *      */
        /*"      *                 PROVENIENTES DO SISTEMA AIC.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/11/2009 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 30.297                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PROGRAMA EM LOOP.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2009 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_SIGAT { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_SIGAT
        {
            get
            {
                _.Move(REG_SIGAT, _MOV_SIGAT); VarBasis.RedefinePassValue(REG_SIGAT, _MOV_SIGAT, REG_SIGAT); return _MOV_SIGAT;
            }
        }
        public FileBasis _MOV_ESP { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_ESP
        {
            get
            {
                _.Move(REG_MOV_ESP, _MOV_ESP); VarBasis.RedefinePassValue(REG_MOV_ESP, _MOV_ESP, REG_MOV_ESP); return _MOV_ESP;
            }
        }
        public FileBasis _MOV_VP { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_VP
        {
            get
            {
                _.Move(REG_MOV_VP, _MOV_VP); VarBasis.RedefinePassValue(REG_MOV_VP, _MOV_VP, REG_MOV_VP); return _MOV_VP;
            }
        }
        public FileBasis _MOV_VG { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_VG
        {
            get
            {
                _.Move(REG_MOV_VG, _MOV_VG); VarBasis.RedefinePassValue(REG_MOV_VG, _MOV_VG, REG_MOV_VG); return _MOV_VG;
            }
        }
        public FileBasis _MOV_DESP { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_DESP
        {
            get
            {
                _.Move(REG_MOV_DESP, _MOV_DESP); VarBasis.RedefinePassValue(REG_MOV_DESP, _MOV_DESP, REG_MOV_DESP); return _MOV_DESP;
            }
        }
        public FileBasis _MOV_CRESCER { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_CRESCER
        {
            get
            {
                _.Move(REG_MOV_CRESCER, _MOV_CRESCER); VarBasis.RedefinePassValue(REG_MOV_CRESCER, _MOV_CRESCER, REG_MOV_CRESCER); return _MOV_CRESCER;
            }
        }
        /*"01   REG-SIGAT.*/
        public PF0110B_REG_SIGAT REG_SIGAT { get; set; } = new PF0110B_REG_SIGAT();
        public class PF0110B_REG_SIGAT : VarBasis
        {
            /*"     10  REG-TIPO-SIGAT                  PIC X(001).*/
            public StringBasis REG_TIPO_SIGAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA-TOP-RED        PIC X(014).*/
            public StringBasis REG_NUM_PROPOSTA_TOP_RED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014)           REDEFINES REG-NUM-PROPOSTA-TOP-RED.*/
            private _REDEF_IntBasis _reg_num_proposta { get; set; }
            public _REDEF_IntBasis REG_NUM_PROPOSTA
            {
                get { _reg_num_proposta = new _REDEF_IntBasis(new PIC("9", "014", "9(014)")); ; _.Move(REG_NUM_PROPOSTA_TOP_RED, _reg_num_proposta); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA_TOP_RED, _reg_num_proposta, REG_NUM_PROPOSTA_TOP_RED); _reg_num_proposta.ValueChanged += () => { _.Move(_reg_num_proposta, REG_NUM_PROPOSTA_TOP_RED); }; return _reg_num_proposta; }
                set { VarBasis.RedefinePassValue(value, _reg_num_proposta, REG_NUM_PROPOSTA_TOP_RED); }
            }  //Redefines
            /*"     10  FILLER      REDEFINES      REG-NUM-PROPOSTA-TOP-RED.*/
            private _REDEF_PF0110B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0110B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0110B_FILLER_0(); _.Move(REG_NUM_PROPOSTA_TOP_RED, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA_TOP_RED, _filler_0, REG_NUM_PROPOSTA_TOP_RED); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA_TOP_RED); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA_TOP_RED); }
            }  //Redefines
            public class _REDEF_PF0110B_FILLER_0 : VarBasis
            {
                /*"         15  REG-NOME-ARQUIVO            PIC X(008).*/
                public StringBasis REG_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"         15  FILLER                      PIC X(006).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"     10  FILLER                          PIC X(261).*/

                public _REDEF_PF0110B_FILLER_0()
                {
                    REG_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "261", "X(261)."), @"");
            /*"     10  REG-ORIGEM-RED                  PIC X(002).*/
            public StringBasis REG_ORIGEM_RED { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10  REG-ORIGEM REDEFINES REG-ORIGEM-RED       PIC 9(002).*/
            private _REDEF_IntBasis _reg_origem { get; set; }
            public _REDEF_IntBasis REG_ORIGEM
            {
                get { _reg_origem = new _REDEF_IntBasis(new PIC("9", "002", "9(002).")); ; _.Move(REG_ORIGEM_RED, _reg_origem); VarBasis.RedefinePassValue(REG_ORIGEM_RED, _reg_origem, REG_ORIGEM_RED); _reg_origem.ValueChanged += () => { _.Move(_reg_origem, REG_ORIGEM_RED); }; return _reg_origem; }
                set { VarBasis.RedefinePassValue(value, _reg_origem, REG_ORIGEM_RED); }
            }  //Redefines
            /*"     10  FILLER                          PIC X(022).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
            /*"01   REG-MOV-ESP                         PIC X(300).*/
        }
        public StringBasis REG_MOV_ESP { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-MOV-VP                          PIC X(300).*/
        public StringBasis REG_MOV_VP { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-MOV-VG                          PIC X(300).*/
        public StringBasis REG_MOV_VG { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-MOV-DESP                        PIC X(300).*/
        public StringBasis REG_MOV_DESP { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-MOV-CRESCER                     PIC X(300).*/
        public StringBasis REG_MOV_CRESCER { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"77      AC-LIDOS-MOV-SIGAT     PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_LIDOS_MOV_SIGAT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-MOV-ESP        PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_MOV_ESP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-MOV-VP         PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_MOV_VP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-MOV-VG         PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_MOV_VG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-MOV-DESP       PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_MOV_DESP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-MOV-CRESCER    PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_MOV_CRESCER { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-PRP-ESP        PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_PRP_ESP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-PRP-VP         PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_PRP_VP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-PRP-VG         PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_PRP_VG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-PRP-DESP       PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_PRP_DESP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-GRAV-PRP-CRESCER    PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_GRAV_PRP_CRESCER { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      AC-REGS-LIDOS-56       PIC  9(09) VALUE ZEROS.*/
        public IntBasis AC_REGS_LIDOS_56 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77      WIND                   PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77      WIND1                  PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01      AUX.*/
        public PF0110B_AUX AUX { get; set; } = new PF0110B_AUX();
        public class PF0110B_AUX : VarBasis
        {
            /*"   05   WS-PROPOSTA-ANT        PIC  X(14) VALUE ZEROS.*/
            public StringBasis WS_PROPOSTA_ANT { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
            /*"   05   WTEM-DESP              PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_DESP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WTEM-CRESCER           PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_CRESCER { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WTEM-VP                PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_VP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WTEM-VG                PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_VG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WTEM-PRPAIC            PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_PRPAIC { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WTEM-PRPSASSE          PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_PRPSASSE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WEH-TDA                PIC  X(03) VALUE SPACES.*/
            public StringBasis WEH_TDA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WTEM-HEADER-ESP        PIC  X(03) VALUE SPACES.*/
            public StringBasis WTEM_HEADER_ESP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WFIM-ARQUIVO           PIC  X(03) VALUE SPACES.*/
            public StringBasis WFIM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05   WS-PARAGRAFO           PIC  X(10) VALUE SPACES.*/
            public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05   WSTIPO-ARQ             PIC  X(08) VALUE SPACES.*/
            public StringBasis WSTIPO_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05   WS-ORIGEM-ANT          PIC  X(01) VALUE SPACES.*/
            public StringBasis WS_ORIGEM_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"01      WTAB-REGISTRO.*/
        }
        public PF0110B_WTAB_REGISTRO WTAB_REGISTRO { get; set; } = new PF0110B_WTAB_REGISTRO();
        public class PF0110B_WTAB_REGISTRO : VarBasis
        {
            /*"   05   WTAB-REG1 OCCURS       200 TIMES.*/
            public ListBasis<PF0110B_WTAB_REG1> WTAB_REG1 { get; set; } = new ListBasis<PF0110B_WTAB_REG1>(200);
            public class PF0110B_WTAB_REG1 : VarBasis
            {
                /*"    10  WTAB-REG               PIC  X(300).*/
                public StringBasis WTAB_REG { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                /*"01      WREG-TRAILLER          PIC  X(300) VALUE SPACES.*/
            }
        }
        public StringBasis WREG_TRAILLER { get; set; } = new StringBasis(new PIC("X", "300", "X(300)"), @"");
        /*"01      WREG-TRAILLER-DESP     PIC  X(300) VALUE SPACES.*/
        public StringBasis WREG_TRAILLER_DESP { get; set; } = new StringBasis(new PIC("X", "300", "X(300)"), @"");
        /*"01         REG-PROPOSTA-SASSE.*/
        public PF0110B_REG_PROPOSTA_SASSE REG_PROPOSTA_SASSE { get; set; } = new PF0110B_REG_PROPOSTA_SASSE();
        public class PF0110B_REG_PROPOSTA_SASSE : VarBasis
        {
            /*"     10    R3-TIPO-REG                 PIC  X(001).*/
            public StringBasis R3_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10    R3-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10    R3-COD-PRODUTO              PIC  9(004).*/
            public IntBasis R3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10    R3-AGECOBR                  PIC  9(004).*/
            public IntBasis R3_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10    R3-DATA-PROPOSTA            PIC  9(008).*/
            public IntBasis R3_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10    R3-OPCAOPAG                 PIC  9(001).*/
            public IntBasis R3_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10    R3-CONTA-DEBITO.*/
            public PF0110B_R3_CONTA_DEBITO R3_CONTA_DEBITO { get; set; } = new PF0110B_R3_CONTA_DEBITO();
            public class PF0110B_R3_CONTA_DEBITO : VarBasis
            {
                /*"       15  R3-AGECTADEB                PIC  9(004).*/
                public IntBasis R3_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       15  R3-OPRCTADEB                PIC  9(004).*/
                public IntBasis R3_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       15  R3-NUMCTADEB                PIC  9(012).*/
                public IntBasis R3_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       15  R3-DIGCTADEB                PIC  9(001).*/
                public IntBasis R3_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10    R3-CARTAO   REDEFINES   R3-CONTA-DEBITO.*/
            }
            private _REDEF_PF0110B_R3_CARTAO _r3_cartao { get; set; }
            public _REDEF_PF0110B_R3_CARTAO R3_CARTAO
            {
                get { _r3_cartao = new _REDEF_PF0110B_R3_CARTAO(); _.Move(R3_CONTA_DEBITO, _r3_cartao); VarBasis.RedefinePassValue(R3_CONTA_DEBITO, _r3_cartao, R3_CONTA_DEBITO); _r3_cartao.ValueChanged += () => { _.Move(_r3_cartao, R3_CONTA_DEBITO); }; return _r3_cartao; }
                set { VarBasis.RedefinePassValue(value, _r3_cartao, R3_CONTA_DEBITO); }
            }  //Redefines
            public class _REDEF_PF0110B_R3_CARTAO : VarBasis
            {
                /*"       15  FILLER                      PIC  X(005).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"       15  R3-NUM-CARTAO               PIC  9(016).*/
                public IntBasis R3_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"     10    R3-DPS-TITULAR              PIC  X(007).*/

                public _REDEF_PF0110B_R3_CARTAO()
                {
                    FILLER_4.ValueChanged += OnValueChanged;
                    R3_NUM_CARTAO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis R3_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"     10    R3-DPS-CONJUGE              PIC  X(007).*/
            public StringBasis R3_DPS_CONJUGE { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"     10    R3-NRMATRVEN                PIC  9(008).*/
            public IntBasis R3_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10    R3-VALOR-PREMIO-TOTAL       PIC  9(014)V99.*/
            public DoubleBasis R3_VALOR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "14", "9(014)V99."), 2);
            /*"     10    R3-APOS-INVALIDEZ           PIC  X(001).*/
            public StringBasis R3_APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10    R3-RENOVACAO-AUTOM          PIC  X(001).*/
            public StringBasis R3_RENOVACAO_AUTOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10    R3-DIA-DEBITO               PIC  9(002).*/
            public IntBasis R3_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10    R3-PCT-DESCONTO             PIC  9(003)V99.*/
            public DoubleBasis R3_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"     10    R3-NOME-CONVENENTE          PIC  X(040).*/
            public StringBasis R3_NOME_CONVENENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10    R3-CGC-CONVENENTE           PIC  9(014).*/
            public IntBasis R3_CGC_CONVENENTE { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10    FILLER                      PIC  X(003).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"     10    R3-SIT-PROPOSTA             PIC  X(003).*/
            public StringBasis R3_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"     10    R3-SIT-COBRANCA             PIC  X(003).*/
            public StringBasis R3_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"     10    R3-SIT-MOTIVO               PIC  9(003).*/
            public IntBasis R3_SIT_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10    R3-OPCAO-COBER              PIC  X(001).*/
            public StringBasis R3_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10    R3-OPCAO-COBER-R  REDEFINES R3-OPCAO-COBER.*/
            private _REDEF_PF0110B_R3_OPCAO_COBER_R _r3_opcao_cober_r { get; set; }
            public _REDEF_PF0110B_R3_OPCAO_COBER_R R3_OPCAO_COBER_R
            {
                get { _r3_opcao_cober_r = new _REDEF_PF0110B_R3_OPCAO_COBER_R(); _.Move(R3_OPCAO_COBER, _r3_opcao_cober_r); VarBasis.RedefinePassValue(R3_OPCAO_COBER, _r3_opcao_cober_r, R3_OPCAO_COBER); _r3_opcao_cober_r.ValueChanged += () => { _.Move(_r3_opcao_cober_r, R3_OPCAO_COBER); }; return _r3_opcao_cober_r; }
                set { VarBasis.RedefinePassValue(value, _r3_opcao_cober_r, R3_OPCAO_COBER); }
            }  //Redefines
            public class _REDEF_PF0110B_R3_OPCAO_COBER_R : VarBasis
            {
                /*"       15  R3-COBERTURA                PIC  9(001).*/
                public IntBasis R3_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10    R3-COD-PLANO                PIC  9(004).*/

                public _REDEF_PF0110B_R3_OPCAO_COBER_R()
                {
                    R3_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis R3_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10    R3-DTQITBCO                 PIC  9(008).*/
            public IntBasis R3_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10    R3-VAL-PAGO                 PIC  9(013)V99.*/
            public DoubleBasis R3_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"     10    R3-AGEPGTO                  PIC  9(004).*/
            public IntBasis R3_AGEPGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10    R3-VAL-TARIFA               PIC  9(013)V99.*/
            public DoubleBasis R3_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"     10    R3-DATA-CREDITO             PIC  9(008).*/
            public IntBasis R3_DATA_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10    R3-VAL-COMISSAO             PIC  9(013)V99.*/
            public DoubleBasis R3_VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"     10    R3-PERIPGTO                 PIC  9(002).*/
            public IntBasis R3_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10    R3-OPCAO-CONJUGE            PIC  X(001).*/
            public StringBasis R3_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10    R3-TIPO-RESIDENCIA          PIC  9(001).*/
            public IntBasis R3_TIPO_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10    R3-VALOR-IOF                PIC  9(006)V99.*/
            public DoubleBasis R3_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "6", "9(006)V99."), 2);
            /*"     10    R3-CUSTO-APOLICE            PIC  9(006)V99.*/
            public DoubleBasis R3_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("9", "6", "9(006)V99."), 2);
            /*"     10    R3-SPACES                   PIC  X(005).*/
            public StringBasis R3_SPACES { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"     10    R3-NUM-SICOB                PIC  9(013).*/
            public IntBasis R3_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10    R3-ORIGEM-PROPOSTA-AIC      PIC  9(004).*/
            public IntBasis R3_ORIGEM_PROPOSTA_AIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10    R3-ORIGEM-PROPOSTA-SIV      REDEFINES           R3-ORIGEM-PROPOSTA-AIC.*/
            private _REDEF_PF0110B_R3_ORIGEM_PROPOSTA_SIV _r3_origem_proposta_siv { get; set; }
            public _REDEF_PF0110B_R3_ORIGEM_PROPOSTA_SIV R3_ORIGEM_PROPOSTA_SIV
            {
                get { _r3_origem_proposta_siv = new _REDEF_PF0110B_R3_ORIGEM_PROPOSTA_SIV(); _.Move(R3_ORIGEM_PROPOSTA_AIC, _r3_origem_proposta_siv); VarBasis.RedefinePassValue(R3_ORIGEM_PROPOSTA_AIC, _r3_origem_proposta_siv, R3_ORIGEM_PROPOSTA_AIC); _r3_origem_proposta_siv.ValueChanged += () => { _.Move(_r3_origem_proposta_siv, R3_ORIGEM_PROPOSTA_AIC); }; return _r3_origem_proposta_siv; }
                set { VarBasis.RedefinePassValue(value, _r3_origem_proposta_siv, R3_ORIGEM_PROPOSTA_AIC); }
            }  //Redefines
            public class _REDEF_PF0110B_R3_ORIGEM_PROPOSTA_SIV : VarBasis
            {
                /*"       15  FILLER                      PIC  X(002).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       15  R3-ORIGEM-PROPOSTA          PIC  9(002).*/
                public IntBasis R3_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10    R3-NSAS                     PIC  9(006).*/

                public _REDEF_PF0110B_R3_ORIGEM_PROPOSTA_SIV()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    R3_ORIGEM_PROPOSTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis R3_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10    R3-NSL                      PIC  9(006).*/
            public IntBasis R3_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10    R3-PRAZO-VIGENCIA           PIC  9(002).*/
            public IntBasis R3_PRAZO_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10    FILLER                      PIC  X(008).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_SIGAT_FILE_NAME_P, string MOV_ESP_FILE_NAME_P, string MOV_VP_FILE_NAME_P, string MOV_VG_FILE_NAME_P, string MOV_DESP_FILE_NAME_P, string MOV_CRESCER_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_SIGAT.SetFile(MOV_SIGAT_FILE_NAME_P);
                MOV_ESP.SetFile(MOV_ESP_FILE_NAME_P);
                MOV_VP.SetFile(MOV_VP_FILE_NAME_P);
                MOV_VG.SetFile(MOV_VG_FILE_NAME_P);
                MOV_DESP.SetFile(MOV_DESP_FILE_NAME_P);
                MOV_CRESCER.SetFile(MOV_CRESCER_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -338- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -339- DISPLAY '*               PROGRAMA PF0110B               *' . */
            _.Display($"*               PROGRAMA PF0110B               *");

            /*" -340- DISPLAY '*  LER O ARQUIVO MOVIMENTO DO SIGPF SEPARANDO  *' . */
            _.Display($"*  LER O ARQUIVO MOVIMENTO DO SIGPF SEPARANDO  *");

            /*" -341- DISPLAY '*  ESTE MOVIMENTO EM VARIOS ARQS PARA  AS BUS  *' . */
            _.Display($"*  ESTE MOVIMENTO EM VARIOS ARQS PARA  AS BUS  *");

            /*" -342- DISPLAY '*    VERSAO: 13 - TRATAR PROD 56   01/07/24    *' . */
            _.Display($"*    VERSAO: 13 - TRATAR PROD 56   01/07/24    *");

            /*" -343- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -351- DISPLAY '*  PF0110B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0110B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -364- DISPLAY '*' . */
            _.Display($"*");

            /*" -365- OPEN INPUT MOV-SIGAT */
            MOV_SIGAT.Open(REG_SIGAT);

            /*" -366- OPEN OUTPUT MOV-ESP */
            MOV_ESP.Open(REG_MOV_ESP);

            /*" -367- OPEN OUTPUT MOV-VP */
            MOV_VP.Open(REG_MOV_VP);

            /*" -368- OPEN OUTPUT MOV-VG . */
            MOV_VG.Open(REG_MOV_VG);

            /*" -369- OPEN OUTPUT MOV-DESP. */
            MOV_DESP.Open(REG_MOV_DESP);

            /*" -394- OPEN OUTPUT MOV-CRESCER. */
            MOV_CRESCER.Open(REG_MOV_CRESCER);

            /*" -396- PERFORM R0910-00-LE. */

            R0910_00_LE_SECTION();

            /*" -414- PERFORM R1000-00-PROCESSA-PROPOSTA UNTIL WFIM-ARQUIVO EQUAL 'SIM' . */

            while (!(AUX.WFIM_ARQUIVO == "SIM"))
            {

                R1000_00_PROCESSA_PROPOSTA_SECTION();
            }

            /*" -415- CLOSE MOV-SIGAT. */
            MOV_SIGAT.Close();

            /*" -416- CLOSE MOV-ESP. */
            MOV_ESP.Close();

            /*" -417- CLOSE MOV-VP. */
            MOV_VP.Close();

            /*" -418- CLOSE MOV-VG. */
            MOV_VG.Close();

            /*" -419- CLOSE MOV-DESP. */
            MOV_DESP.Close();

            /*" -421- CLOSE MOV-CRESCER. */
            MOV_CRESCER.Close();

            /*" -422- DISPLAY '*  LIDOS MOV-SIGAT........ ' AC-LIDOS-MOV-SIGAT */
            _.Display($"*  LIDOS MOV-SIGAT........ {AC_LIDOS_MOV_SIGAT}");

            /*" -423- DISPLAY '*' */
            _.Display($"*");

            /*" -424- DISPLAY '*  GRAVADOS MOV-ESP....... ' AC-GRAV-MOV-ESP */
            _.Display($"*  GRAVADOS MOV-ESP....... {AC_GRAV_MOV_ESP}");

            /*" -425- DISPLAY '*  GRAVADOS MOV-VP........ ' AC-GRAV-MOV-VP */
            _.Display($"*  GRAVADOS MOV-VP........ {AC_GRAV_MOV_VP}");

            /*" -426- DISPLAY '*  GRAVADOS MOV-VG........ ' AC-GRAV-MOV-VG */
            _.Display($"*  GRAVADOS MOV-VG........ {AC_GRAV_MOV_VG}");

            /*" -427- DISPLAY '*  GRAVADOS MOV-DESP...... ' AC-GRAV-MOV-DESP */
            _.Display($"*  GRAVADOS MOV-DESP...... {AC_GRAV_MOV_DESP}");

            /*" -428- DISPLAY '*  GRAVADOS MOV-CRESCER... ' AC-GRAV-MOV-CRESCER */
            _.Display($"*  GRAVADOS MOV-CRESCER... {AC_GRAV_MOV_CRESCER}");

            /*" -429- DISPLAY '*' */
            _.Display($"*");

            /*" -430- DISPLAY '*  PROPOSTAS ESP.......... ' AC-GRAV-PRP-ESP */
            _.Display($"*  PROPOSTAS ESP.......... {AC_GRAV_PRP_ESP}");

            /*" -431- DISPLAY '*  PROPOSTAS VP........... ' AC-GRAV-PRP-VP */
            _.Display($"*  PROPOSTAS VP........... {AC_GRAV_PRP_VP}");

            /*" -432- DISPLAY '*  PROPOSTAS VG........... ' AC-GRAV-PRP-VG */
            _.Display($"*  PROPOSTAS VG........... {AC_GRAV_PRP_VG}");

            /*" -433- DISPLAY '*  PROPOSTAS DESP......... ' AC-GRAV-PRP-DESP */
            _.Display($"*  PROPOSTAS DESP......... {AC_GRAV_PRP_DESP}");

            /*" -434- DISPLAY '*  PROPOSTAS CRESCER...... ' AC-GRAV-PRP-CRESCER */
            _.Display($"*  PROPOSTAS CRESCER...... {AC_GRAV_PRP_CRESCER}");

            /*" -435- DISPLAY '*' */
            _.Display($"*");

            /*" -436- DISPLAY '*' */
            _.Display($"*");

            /*" -437- DISPLAY '*  ------ PRODUTO TRATADO NO ARQ BILHETES ------' */
            _.Display($"*  ------ PRODUTO TRATADO NO ARQ BILHETES ------");

            /*" -438- DISPLAY '*' */
            _.Display($"*");

            /*" -439- DISPLAY '*  PROPOSTAS PRODUTO 56... ' AC-REGS-LIDOS-56 */
            _.Display($"*  PROPOSTAS PRODUTO 56... {AC_REGS_LIDOS_56}");

            /*" -440- DISPLAY '*' */
            _.Display($"*");

            /*" -441- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -442- DISPLAY '*                TERMINO NORMAL                *' */
            _.Display($"*                TERMINO NORMAL                *");

            /*" -443- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -444- DISPLAY '.' */
            _.Display($".");

            /*" -444- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0910-00-LE-SECTION */
        private void R0910_00_LE_SECTION()
        {
            /*" -455- MOVE 'R0910' TO WS-PARAGRAFO. */
            _.Move("R0910", AUX.WS_PARAGRAFO);

            /*" -456- READ MOV-SIGAT AT END */
            try
            {
                MOV_SIGAT.Read(() =>
                {

                    /*" -458- MOVE 'SIM' TO WFIM-ARQUIVO */
                    _.Move("SIM", AUX.WFIM_ARQUIVO);

                    /*" -460- GO TO R0910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOV_SIGAT.Value, REG_SIGAT);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -462- ADD 1 TO AC-LIDOS-MOV-SIGAT. */
            AC_LIDOS_MOV_SIGAT.Value = AC_LIDOS_MOV_SIGAT + 1;

            /*" -464- IF REG-SIGAT(1:9) EQUAL 'TPRPSASSE' OR REG-SIGAT(1:9) EQUAL 'TPRPAIC  ' */

            if (REG_SIGAT.Substring(1, 9) == "TPRPSASSE" || REG_SIGAT.Substring(1, 9) == "TPRPAIC  ")
            {

                /*" -465- MOVE REG-SIGAT TO WREG-TRAILLER */
                _.Move(MOV_SIGAT?.Value, WREG_TRAILLER);

                /*" -466- MOVE REG-SIGAT TO WREG-TRAILLER-DESP */
                _.Move(MOV_SIGAT?.Value, WREG_TRAILLER_DESP);

                /*" -468- END-IF. */
            }


            /*" -469- IF REG-SIGAT(01:01) EQUAL 'H' */

            if (REG_SIGAT.Substring(01, 01) == "H")
            {

                /*" -469- PERFORM R0950-00-TRATA-HEADER. */

                R0950_00_TRATA_HEADER_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-TRATA-HEADER-SECTION */
        private void R0950_00_TRATA_HEADER_SECTION()
        {
            /*" -482- MOVE 'R0950' TO WS-PARAGRAFO. */
            _.Move("R0950", AUX.WS_PARAGRAFO);

            /*" -484- IF WREG-TRAILLER(1:9) EQUAL 'TPRPSASSE' AND REG-SIGAT(1:9) EQUAL 'HPRPSASSE' */

            if (WREG_TRAILLER.Substring(1, 9) == "TPRPSASSE" && REG_SIGAT.Substring(1, 9) == "HPRPSASSE")
            {

                /*" -485- WRITE REG-MOV-ESP FROM WREG-TRAILLER */
                _.Move(WREG_TRAILLER.GetMoveValues(), REG_MOV_ESP);

                MOV_ESP.Write(REG_MOV_ESP.GetMoveValues().ToString());

                /*" -487- END-IF. */
            }


            /*" -489- IF WSTIPO-ARQ EQUAL 'DESPREZA' OR 'PRPESP  ' */

            if (AUX.WSTIPO_ARQ.In("DESPREZA", "PRPESP "))
            {

                /*" -490- MOVE SPACES TO WREG-TRAILLER */
                _.Move("", WREG_TRAILLER);

                /*" -492- END-IF. */
            }


            /*" -494- IF REG-SIGAT(18:01) EQUAL '9' OR REG-SIGAT(2:8) EQUAL 'PRPAIC  ' */

            if (REG_SIGAT.Substring(18, 01) == "9" || REG_SIGAT.Substring(2, 8) == "PRPAIC  ")
            {

                /*" -495- MOVE 'SIM' TO WTEM-PRPAIC */
                _.Move("SIM", AUX.WTEM_PRPAIC);

                /*" -496- WRITE REG-MOV-DESP FROM REG-SIGAT */
                _.Move(REG_SIGAT.GetMoveValues(), REG_MOV_DESP);

                MOV_DESP.Write(REG_MOV_DESP.GetMoveValues().ToString());

                /*" -497- ADD 1 TO AC-GRAV-MOV-DESP */
                AC_GRAV_MOV_DESP.Value = AC_GRAV_MOV_DESP + 1;

                /*" -499- MOVE SPACES TO WSTIPO-ARQ WREG-TRAILLER-DESP */
                _.Move("", AUX.WSTIPO_ARQ, WREG_TRAILLER_DESP);

                /*" -500- ELSE */
            }
            else
            {


                /*" -501- MOVE 'NAO' TO WTEM-PRPAIC */
                _.Move("NAO", AUX.WTEM_PRPAIC);

                /*" -503- END-IF. */
            }


            /*" -504- IF REG-SIGAT(18:01) NOT EQUAL WS-ORIGEM-ANT */

            if (REG_SIGAT.Substring(18, 01) != AUX.WS_ORIGEM_ANT)
            {

                /*" -505- MOVE 'NAO' TO WTEM-PRPSASSE */
                _.Move("NAO", AUX.WTEM_PRPSASSE);

                /*" -506- MOVE REG-SIGAT(18:01) TO WS-ORIGEM-ANT */
                _.Move(REG_SIGAT.Substring(18, 1), AUX.WS_ORIGEM_ANT);

                /*" -508- END-IF. */
            }


            /*" -509- IF WREG-TRAILLER NOT EQUAL SPACES */

            if (!WREG_TRAILLER.IsEmpty())
            {

                /*" -510- MOVE 'PRPVP   ' TO WREG-TRAILLER(2:8) */
                _.MoveAtPosition("PRPVP   ", WREG_TRAILLER, 2, 8);

                /*" -511- WRITE REG-MOV-VP FROM WREG-TRAILLER */
                _.Move(WREG_TRAILLER.GetMoveValues(), REG_MOV_VP);

                MOV_VP.Write(REG_MOV_VP.GetMoveValues().ToString());

                /*" -512- ADD 1 TO AC-GRAV-MOV-VP */
                AC_GRAV_MOV_VP.Value = AC_GRAV_MOV_VP + 1;

                /*" -513- MOVE 'PRPVG   ' TO WREG-TRAILLER(2:8) */
                _.MoveAtPosition("PRPVG   ", WREG_TRAILLER, 2, 8);

                /*" -514- WRITE REG-MOV-VG FROM WREG-TRAILLER */
                _.Move(WREG_TRAILLER.GetMoveValues(), REG_MOV_VG);

                MOV_VG.Write(REG_MOV_VG.GetMoveValues().ToString());

                /*" -515- ADD 1 TO AC-GRAV-MOV-VG */
                AC_GRAV_MOV_VG.Value = AC_GRAV_MOV_VG + 1;

                /*" -516- MOVE 'PRPCRESC' TO WREG-TRAILLER(2:8) */
                _.MoveAtPosition("PRPCRESC", WREG_TRAILLER, 2, 8);

                /*" -517- WRITE REG-MOV-CRESCER FROM WREG-TRAILLER */
                _.Move(WREG_TRAILLER.GetMoveValues(), REG_MOV_CRESCER);

                MOV_CRESCER.Write(REG_MOV_CRESCER.GetMoveValues().ToString());

                /*" -518- ADD 1 TO AC-GRAV-MOV-CRESCER */
                AC_GRAV_MOV_CRESCER.Value = AC_GRAV_MOV_CRESCER + 1;

                /*" -520- END-IF. */
            }


            /*" -522- IF REG-SIGAT(2:8) EQUAL 'PRPSASSE' OR REG-SIGAT(2:8) EQUAL 'PRPAIC  ' */

            if (REG_SIGAT.Substring(2, 8) == "PRPSASSE" || REG_SIGAT.Substring(2, 8) == "PRPAIC  ")
            {

                /*" -523- MOVE 'PRPSASSE' TO WSTIPO-ARQ */
                _.Move("PRPSASSE", AUX.WSTIPO_ARQ);

                /*" -524- IF WTEM-PRPSASSE EQUAL 'SIM' */

                if (AUX.WTEM_PRPSASSE == "SIM")
                {

                    /*" -525- IF REG-SIGAT(18:01) EQUAL '1' */

                    if (REG_SIGAT.Substring(18, 01) == "1")
                    {

                        /*" -526- MOVE 'DESPREZA' TO WSTIPO-ARQ */
                        _.Move("DESPREZA", AUX.WSTIPO_ARQ);

                        /*" -527- END-IF */
                    }


                    /*" -528- ELSE */
                }
                else
                {


                    /*" -529- IF REG-SIGAT(18:01) EQUAL '1' */

                    if (REG_SIGAT.Substring(18, 01) == "1")
                    {

                        /*" -530- MOVE 'SIM' TO WTEM-PRPSASSE */
                        _.Move("SIM", AUX.WTEM_PRPSASSE);

                        /*" -531- END-IF */
                    }


                    /*" -532- IF WTEM-PRPAIC EQUAL 'NAO' */

                    if (AUX.WTEM_PRPAIC == "NAO")
                    {

                        /*" -533- WRITE REG-MOV-ESP FROM REG-SIGAT */
                        _.Move(REG_SIGAT.GetMoveValues(), REG_MOV_ESP);

                        MOV_ESP.Write(REG_MOV_ESP.GetMoveValues().ToString());

                        /*" -534- ADD 1 TO AC-GRAV-MOV-ESP */
                        AC_GRAV_MOV_ESP.Value = AC_GRAV_MOV_ESP + 1;

                        /*" -535- MOVE 'SIM' TO WTEM-HEADER-ESP */
                        _.Move("SIM", AUX.WTEM_HEADER_ESP);

                        /*" -536- END-IF */
                    }


                    /*" -537- MOVE REG-SIGAT TO REG-MOV-VP */
                    _.Move(MOV_SIGAT?.Value, REG_MOV_VP);

                    /*" -538- MOVE 'PRPVP   ' TO REG-MOV-VP(2:8) */
                    _.MoveAtPosition("PRPVP   ", REG_MOV_VP, 2, 8);

                    /*" -539- WRITE REG-MOV-VP */
                    MOV_VP.Write(REG_MOV_VP.GetMoveValues().ToString());

                    /*" -540- ADD 1 TO AC-GRAV-MOV-VP */
                    AC_GRAV_MOV_VP.Value = AC_GRAV_MOV_VP + 1;

                    /*" -541- MOVE REG-SIGAT TO REG-MOV-VG */
                    _.Move(MOV_SIGAT?.Value, REG_MOV_VG);

                    /*" -542- MOVE 'PRPVG   ' TO REG-MOV-VG(2:8) */
                    _.MoveAtPosition("PRPVG   ", REG_MOV_VG, 2, 8);

                    /*" -543- WRITE REG-MOV-VG */
                    MOV_VG.Write(REG_MOV_VG.GetMoveValues().ToString());

                    /*" -544- ADD 1 TO AC-GRAV-MOV-VG */
                    AC_GRAV_MOV_VG.Value = AC_GRAV_MOV_VG + 1;

                    /*" -545- MOVE REG-SIGAT TO REG-MOV-CRESCER */
                    _.Move(MOV_SIGAT?.Value, REG_MOV_CRESCER);

                    /*" -546- MOVE 'PRPCRESC' TO REG-MOV-CRESCER(2:8) */
                    _.MoveAtPosition("PRPCRESC", REG_MOV_CRESCER, 2, 8);

                    /*" -547- WRITE REG-MOV-CRESCER */
                    MOV_CRESCER.Write(REG_MOV_CRESCER.GetMoveValues().ToString());

                    /*" -548- ADD 1 TO AC-GRAV-MOV-CRESCER */
                    AC_GRAV_MOV_CRESCER.Value = AC_GRAV_MOV_CRESCER + 1;

                    /*" -549- END-IF */
                }


                /*" -550- ELSE */
            }
            else
            {


                /*" -551- MOVE 'PRPESP' TO WSTIPO-ARQ */
                _.Move("PRPESP", AUX.WSTIPO_ARQ);

                /*" -552- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-PROPOSTA-SECTION */
        private void R1000_00_PROCESSA_PROPOSTA_SECTION()
        {
            /*" -564- MOVE 'R1000' TO WS-PARAGRAFO. */
            _.Move("R1000", AUX.WS_PARAGRAFO);

            /*" -565- IF WSTIPO-ARQ EQUAL 'DESPREZA' */

            if (AUX.WSTIPO_ARQ == "DESPREZA")
            {

                /*" -568- PERFORM R0910-00-LE UNTIL WFIM-ARQUIVO EQUAL 'SIM' OR WSTIPO-ARQ NOT EQUAL 'DESPREZA' */

                while (!(AUX.WFIM_ARQUIVO == "SIM" || AUX.WSTIPO_ARQ != "DESPREZA"))
                {

                    R0910_00_LE_SECTION();
                }

                /*" -569- IF WFIM-ARQUIVO EQUAL 'SIM' */

                if (AUX.WFIM_ARQUIVO == "SIM")
                {

                    /*" -571- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -572- IF WSTIPO-ARQ EQUAL 'PRPESP' */

            if (AUX.WSTIPO_ARQ == "PRPESP")
            {

                /*" -575- PERFORM R9000-00-PROCESSA-INICIO UNTIL WFIM-ARQUIVO EQUAL 'SIM' OR WSTIPO-ARQ NOT EQUAL 'PRPESP' */

                while (!(AUX.WFIM_ARQUIVO == "SIM" || AUX.WSTIPO_ARQ != "PRPESP"))
                {

                    R9000_00_PROCESSA_INICIO_SECTION();
                }

                /*" -576- IF WFIM-ARQUIVO EQUAL 'SIM' */

                if (AUX.WFIM_ARQUIVO == "SIM")
                {

                    /*" -582- GO TO R1000-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -587- MOVE 'NAO' TO WTEM-VP WTEM-VG WTEM-DESP WTEM-CRESCER */
            _.Move("NAO", AUX.WTEM_VP, AUX.WTEM_VG, AUX.WTEM_DESP, AUX.WTEM_CRESCER);

            /*" -589- MOVE ZEROS TO WTAB-REGISTRO. */
            _.Move(0, WTAB_REGISTRO);

            /*" -591- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

            /*" -593- MOVE REG-SIGAT(02:14) TO WS-PROPOSTA-ANT */
            _.Move(REG_SIGAT.Substring(2, 14), AUX.WS_PROPOSTA_ANT);

            /*" -597- PERFORM R2000-00-PROCESSA-REGISTRO UNTIL WFIM-ARQUIVO EQUAL 'SIM' OR REG-SIGAT(02:14) NOT EQUAL WS-PROPOSTA-ANT. */

            while (!(AUX.WFIM_ARQUIVO == "SIM" || REG_SIGAT.Substring(02, 14) != AUX.WS_PROPOSTA_ANT))
            {

                R2000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -600- IF WTEM-DESP EQUAL 'NAO' AND WTEM-PRPAIC EQUAL 'SIM' AND WS-PROPOSTA-ANT IS NUMERIC */

            if (AUX.WTEM_DESP == "NAO" && AUX.WTEM_PRPAIC == "SIM" && AUX.WS_PROPOSTA_ANT.IsNumeric())
            {

                /*" -602- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                {

                    /*" -603- WRITE REG-MOV-DESP FROM WTAB-REG (WIND1) */
                    _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_DESP);

                    MOV_DESP.Write(REG_MOV_DESP.GetMoveValues().ToString());

                    /*" -604- ADD 1 TO AC-GRAV-MOV-DESP */
                    AC_GRAV_MOV_DESP.Value = AC_GRAV_MOV_DESP + 1;

                    /*" -605- END-PERFORM */
                }

                /*" -606- ADD 1 TO AC-GRAV-PRP-DESP */
                AC_GRAV_PRP_DESP.Value = AC_GRAV_PRP_DESP + 1;

                /*" -607- ELSE */
            }
            else
            {


                /*" -608- IF WTEM-CRESCER EQUAL 'SIM' */

                if (AUX.WTEM_CRESCER == "SIM")
                {

                    /*" -610- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                    for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                    {

                        /*" -611- WRITE REG-MOV-CRESCER FROM WTAB-REG (WIND1) */
                        _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_CRESCER);

                        MOV_CRESCER.Write(REG_MOV_CRESCER.GetMoveValues().ToString());

                        /*" -612- ADD 1 TO AC-GRAV-MOV-CRESCER */
                        AC_GRAV_MOV_CRESCER.Value = AC_GRAV_MOV_CRESCER + 1;

                        /*" -613- END-PERFORM */
                    }

                    /*" -614- ADD 1 TO AC-GRAV-PRP-CRESCER */
                    AC_GRAV_PRP_CRESCER.Value = AC_GRAV_PRP_CRESCER + 1;

                    /*" -615- ELSE */
                }
                else
                {


                    /*" -616- IF WTEM-VP EQUAL 'SIM' */

                    if (AUX.WTEM_VP == "SIM")
                    {

                        /*" -618- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                        for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                        {

                            /*" -619- WRITE REG-MOV-VP FROM WTAB-REG (WIND1) */
                            _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_VP);

                            MOV_VP.Write(REG_MOV_VP.GetMoveValues().ToString());

                            /*" -620- ADD 1 TO AC-GRAV-MOV-VP */
                            AC_GRAV_MOV_VP.Value = AC_GRAV_MOV_VP + 1;

                            /*" -621- END-PERFORM */
                        }

                        /*" -622- ADD 1 TO AC-GRAV-PRP-VP */
                        AC_GRAV_PRP_VP.Value = AC_GRAV_PRP_VP + 1;

                        /*" -623- ELSE */
                    }
                    else
                    {


                        /*" -624- IF WTEM-VG EQUAL 'SIM' */

                        if (AUX.WTEM_VG == "SIM")
                        {

                            /*" -626- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                            for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                            {

                                /*" -627- WRITE REG-MOV-VG FROM WTAB-REG (WIND1) */
                                _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_VG);

                                MOV_VG.Write(REG_MOV_VG.GetMoveValues().ToString());

                                /*" -628- ADD 1 TO AC-GRAV-MOV-VG */
                                AC_GRAV_MOV_VG.Value = AC_GRAV_MOV_VG + 1;

                                /*" -629- END-PERFORM */
                            }

                            /*" -630- ADD 1 TO AC-GRAV-PRP-VG */
                            AC_GRAV_PRP_VG.Value = AC_GRAV_PRP_VG + 1;

                            /*" -631- ELSE */
                        }
                        else
                        {


                            /*" -632- IF WTEM-PRPAIC EQUAL 'NAO' */

                            if (AUX.WTEM_PRPAIC == "NAO")
                            {

                                /*" -638- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                                for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                                {

                                    /*" -639- IF R3-COD-PRODUTO EQUAL 56 */

                                    if (REG_PROPOSTA_SASSE.R3_COD_PRODUTO == 56)
                                    {

                                        /*" -642- ADD 1 TO AC-REGS-LIDOS-56 */
                                        AC_REGS_LIDOS_56.Value = AC_REGS_LIDOS_56 + 1;

                                        /*" -643- GO TO R1000-99-SAIDA */
                                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                                        return;

                                        /*" -646- END-IF */
                                    }


                                    /*" -647- WRITE REG-MOV-ESP FROM WTAB-REG (WIND1) */
                                    _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_ESP);

                                    MOV_ESP.Write(REG_MOV_ESP.GetMoveValues().ToString());

                                    /*" -648- ADD 1 TO AC-GRAV-MOV-ESP */
                                    AC_GRAV_MOV_ESP.Value = AC_GRAV_MOV_ESP + 1;

                                    /*" -649- END-PERFORM */
                                }

                                /*" -650- ADD 1 TO AC-GRAV-PRP-ESP */
                                AC_GRAV_PRP_ESP.Value = AC_GRAV_PRP_ESP + 1;

                                /*" -651- END-IF */
                            }


                            /*" -653- END-IF. */
                        }

                    }

                }

            }


            /*" -654- IF WTEM-PRPAIC EQUAL 'SIM' */

            if (AUX.WTEM_PRPAIC == "SIM")
            {

                /*" -656- IF WREG-TRAILLER-DESP(1:9) EQUAL 'TPRPAIC  ' OR 'TPRPSASSE' */

                if (WREG_TRAILLER_DESP.Substring(1, 9).In("TPRPAIC ", "TPRPSASSE"))
                {

                    /*" -657- WRITE REG-MOV-DESP FROM WREG-TRAILLER-DESP */
                    _.Move(WREG_TRAILLER_DESP.GetMoveValues(), REG_MOV_DESP);

                    MOV_DESP.Write(REG_MOV_DESP.GetMoveValues().ToString());

                    /*" -658- MOVE SPACES TO WREG-TRAILLER-DESP */
                    _.Move("", WREG_TRAILLER_DESP);

                    /*" -659- ADD 1 TO AC-GRAV-MOV-DESP */
                    AC_GRAV_MOV_DESP.Value = AC_GRAV_MOV_DESP + 1;

                    /*" -659- END-IF. */
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-REGISTRO-SECTION */
        private void R2000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -672- MOVE 'R2000' TO WS-PARAGRAFO. */
            _.Move("R2000", AUX.WS_PARAGRAFO);

            /*" -673- IF REG-SIGAT (01:1) EQUAL '3' */

            if (REG_SIGAT.Substring(01, 1) == "3")
            {

                /*" -674- MOVE 'SIM' TO WTEM-DESP */
                _.Move("SIM", AUX.WTEM_DESP);

                /*" -676- MOVE REG-SIGAT TO REG-PROPOSTA-SASSE */
                _.Move(MOV_SIGAT?.Value, REG_PROPOSTA_SASSE);

                /*" -678- END-IF. */
            }


            /*" -681- IF (REG-SIGAT (01:1) EQUAL '3' ) AND ((REG-SIGAT (18:2) EQUAL '77' OR '76' ) OR (REG-SIGAT (16:2) EQUAL '77' OR '76' )) */

            if ((REG_SIGAT.Substring(01, 1) == "3") && ((REG_SIGAT.Substring(18, 2).In("77", "76")) || (REG_SIGAT.Substring(16, 2).In("77", "76"))))
            {

                /*" -682- MOVE 'SIM' TO WTEM-VP */
                _.Move("SIM", AUX.WTEM_VP);

                /*" -683- ELSE */
            }
            else
            {


                /*" -689- IF (REG-SIGAT (01:1) EQUAL '3' ) AND ((REG-SIGAT (18:2) EQUAL '07' OR '11' OR '13' OR '16' OR '46' OR '06' OR '37' ) OR (REG-SIGAT (16:2) EQUAL '81' OR '93' )) */

                if ((REG_SIGAT.Substring(01, 1) == "3") && ((REG_SIGAT.Substring(18, 2).In("07", "11", "13", "16", "46", "06", "37")) || (REG_SIGAT.Substring(16, 2).In("81", "93"))))
                {

                    /*" -690- MOVE 'SIM' TO WTEM-VG */
                    _.Move("SIM", AUX.WTEM_VG);

                    /*" -691- ELSE */
                }
                else
                {


                    /*" -694- IF REG-SIGAT (01:1) EQUAL '3' AND REG-SIGAT (18:2) EQUAL '09' AND REG-SIGAT (277:2) EQUAL '80' */

                    if (REG_SIGAT.Substring(01, 1) == "3" && REG_SIGAT.Substring(18, 2) == "09" && REG_SIGAT.Substring(277, 2) == "80")
                    {

                        /*" -702- MOVE 'SIM' TO WTEM-CRESCER */
                        _.Move("SIM", AUX.WTEM_CRESCER);

                        /*" -703- END-IF */
                    }


                    /*" -704- END-IF */
                }


                /*" -706- END-IF */
            }


            /*" -707- IF REG-SIGAT (01:1) NOT EQUAL 'H' AND 'T' */

            if (!REG_SIGAT.Substring(01, 1).In("H", "T"))
            {

                /*" -708- ADD 1 TO WIND */
                WIND.Value = WIND + 1;

                /*" -710- MOVE REG-SIGAT TO WTAB-REG (WIND). */
                _.Move(MOV_SIGAT?.Value, WTAB_REGISTRO.WTAB_REG1[WIND].WTAB_REG);
            }


            /*" -710- PERFORM R0910-00-LE. */

            R0910_00_LE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-PROCESSA-INICIO-SECTION */
        private void R9000_00_PROCESSA_INICIO_SECTION()
        {
            /*" -723- IF REG-SIGAT(1:1) = 'H' OR = 'T' */

            if (REG_SIGAT.Substring(1, 1).In("H", "T"))
            {

                /*" -724- WRITE REG-MOV-ESP FROM REG-SIGAT */
                _.Move(REG_SIGAT.GetMoveValues(), REG_MOV_ESP);

                MOV_ESP.Write(REG_MOV_ESP.GetMoveValues().ToString());

                /*" -725- ADD 1 TO AC-GRAV-MOV-ESP */
                AC_GRAV_MOV_ESP.Value = AC_GRAV_MOV_ESP + 1;

                /*" -726- PERFORM R0910-00-LE */

                R0910_00_LE_SECTION();

                /*" -727- ELSE */
            }
            else
            {


                /*" -728- MOVE REG-SIGAT(02:14) TO WS-PROPOSTA-ANT */
                _.Move(REG_SIGAT.Substring(2, 14), AUX.WS_PROPOSTA_ANT);

                /*" -729- MOVE 'NAO' TO WEH-TDA */
                _.Move("NAO", AUX.WEH_TDA);

                /*" -730- MOVE 0 TO WIND */
                _.Move(0, WIND);

                /*" -733- PERFORM R9001-00-PROCESSA-PROPOSTA UNTIL REG-SIGAT(02:14) NOT = WS-PROPOSTA-ANT OR WFIM-ARQUIVO = 'SIM' */

                while (!(REG_SIGAT.Substring(02, 14) != AUX.WS_PROPOSTA_ANT || AUX.WFIM_ARQUIVO == "SIM"))
                {

                    R9001_00_PROCESSA_PROPOSTA_SECTION();
                }

                /*" -734- IF WFIM-ARQUIVO = 'SIM' */

                if (AUX.WFIM_ARQUIVO == "SIM")
                {

                    /*" -735- GO TO R9000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/ //GOTO
                    return;

                    /*" -739- END-IF */
                }


                /*" -740- IF WEH-TDA = 'SIM' */

                if (AUX.WEH_TDA == "SIM")
                {

                    /*" -742- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                    for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                    {

                        /*" -743- WRITE REG-MOV-DESP FROM WTAB-REG (WIND1) */
                        _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_DESP);

                        MOV_DESP.Write(REG_MOV_DESP.GetMoveValues().ToString());

                        /*" -747- ADD 1 TO AC-GRAV-MOV-DESP */
                        AC_GRAV_MOV_DESP.Value = AC_GRAV_MOV_DESP + 1;

                        /*" -748- END-PERFORM */
                    }

                    /*" -749- ELSE */
                }
                else
                {


                    /*" -751- PERFORM VARYING WIND1 FROM 1 BY 1 UNTIL WIND1 GREATER WIND */

                    for (WIND1.Value = 1; !(WIND1 > WIND); WIND1.Value += 1)
                    {

                        /*" -752- WRITE REG-MOV-ESP FROM WTAB-REG (WIND1) */
                        _.Move(WTAB_REGISTRO.WTAB_REG1[WIND1].WTAB_REG.GetMoveValues(), REG_MOV_ESP);

                        MOV_ESP.Write(REG_MOV_ESP.GetMoveValues().ToString());

                        /*" -756- ADD 1 TO AC-GRAV-MOV-ESP */
                        AC_GRAV_MOV_ESP.Value = AC_GRAV_MOV_ESP + 1;

                        /*" -757- END-PERFORM */
                    }

                    /*" -758- END-IF */
                }


                /*" -760- END-IF */
            }


            /*" -760- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9001-00-PROCESSA-PROPOSTA-SECTION */
        private void R9001_00_PROCESSA_PROPOSTA_SECTION()
        {
            /*" -768- IF NOT ( REG-SIGAT(1:1) = 'H' OR = 'T' ) */

            if (!(REG_SIGAT.Substring(1, 1).In("H", "T")))
            {

                /*" -769- ADD 1 TO WIND */
                WIND.Value = WIND + 1;

                /*" -770- MOVE REG-SIGAT TO WTAB-REG (WIND) */
                _.Move(MOV_SIGAT?.Value, WTAB_REGISTRO.WTAB_REG1[WIND].WTAB_REG);

                /*" -772- END-IF */
            }


            /*" -773- IF REG-SIGAT(01:1) = '3' */

            if (REG_SIGAT.Substring(01, 1) == "3")
            {

                /*" -774- ADD 1 TO AC-GRAV-PRP-DESP */
                AC_GRAV_PRP_DESP.Value = AC_GRAV_PRP_DESP + 1;

                /*" -775- IF REG-SIGAT(158:3) = 'TDA' */

                if (REG_SIGAT.Substring(158, 3) == "TDA")
                {

                    /*" -776- MOVE 'SIM' TO WEH-TDA */
                    _.Move("SIM", AUX.WEH_TDA);

                    /*" -777- END-IF */
                }


                /*" -779- END-IF */
            }


            /*" -780- PERFORM R0910-00-LE. */

            R0910_00_LE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9001_99_SAIDA*/
    }
}