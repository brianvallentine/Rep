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
using Sias.VidaEmpresarial.DB2.VE0029B;

namespace Code
{
    public class VE0029B
    {
        public bool IsCall { get; set; }

        public VE0029B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  EMPRESARIAL                        *      */
        /*"      *   PROGRAMA ...............  VE0029B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  LUIZ CARLOS                        *      */
        /*"      *   PROGRAMADOR ............  LUIZ CARLOS                        *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/1999                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ............  GERA SOLICITACAO DE CANCELAMENTO PARA OS*      */
        /*"      *                        SUBGRUPOS DO EMPRESARIAL CONFORME CRITE-*      */
        /*"      *                        RIOS ABAIXO:                            *      */
        /*"      *                                                                *      */
        /*"      *                        SEGURO COM VENCIMENTO MENSAL/BIMESTRAL: *      */
        /*"      *                               CANCELA OS SEGUROS COM TRES OU   *      */
        /*"      *                               MAIS PARCELAS EM ATRASO. (A ULTI-*      */
        /*"      *                               MA PARCELA TERAH TOLERANCIA  DE  *      */
        /*"      *                               CINCO (5) DIAS, APOS O VENCIMENTO*      */
        /*"      *                                                                *      */
        /*"      *                        SEGURO COM VENCIMENTO TRIMESTRAL/SEMES- *      */
        /*"      *                               TRAL/ANUAL:                      *      */
        /*"      *                               CANCELA OS SEGUROS COM UMA PARCE-*      */
        /*"      *                               LAS EM ATRASO. A  PARCELA  SERAH *      */
        /*"      *                               CANCELA APOS TOLERANCIA DE CINCO *      */
        /*"      *                               DIAS APOS O VENCIMENTO.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *VERSAO V.05-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04     EM 01/07/2019                                    *      */
        /*"      *    PARA ATENDER DEMANDA JAZZ 199509 - VINCULO ERRADO           *      */
        /*"      *    INCLUIR DUAS APOLICES: 0108211323063 E 0108211323064        *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.04       CANETTA        EM 10/07/2019         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 -  ADAILTON DIAS                                   *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 07/02/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 10/06/2008 - EDIVALDO ( FAST COMPUTER )                 *      */
        /*"      *  CAD 11.205                                                    *      */
        /*"      *                  PROCESSAR TAMBEM AS APOLICES:                 *      */
        /*"      *                  010930000959, 0108208874329 E 0109300000672.  *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PARCELAS                            V1PARCELA         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSOS        INPUT    *      */
        /*"      * RELATORIOS                          VORELATORIOS      OUTPUT   *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-DTVENCTO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-QTD-PGTO       PIC S9(004)                COMP.*/
        public IntBasis VIND_QTD_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-NUM-APOLICE           PIC S9(013)   COMP-3.*/
        public IntBasis V0TERMO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0TERMO-NUM-TERMO             PIC S9(011)   COMP-3.*/
        public IntBasis V0TERMO_NUM_TERMO { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77          V0TERMO-COD-SUBG              PIC S9(004)   COMP.*/
        public IntBasis V0TERMO_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-PERIPGTO              PIC S9(004)   COMP.*/
        public IntBasis V0TERMO_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0TERMO-SITUACAO              PIC  X(001).*/
        public StringBasis V0TERMO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0PEND-NUM-APOL                PIC S9(013)  COMP-3.*/
        public IntBasis V0PEND_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          V0PEND-COD-SUBG                PIC S9(004)  COMP.*/
        public IntBasis V0PEND_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          V0PEND-NRENDOS                 PIC S9(009)  COMP.*/
        public IntBasis V0PEND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          V0PEND-DTVENCTO                PIC  X(010).*/
        public StringBasis V0PEND_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          V0PEND-TP-ENDOSSO              PIC  X(001).*/
        public StringBasis V0PEND_TP_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          V0PEND-SITUACAO                PIC  X(001).*/
        public StringBasis V0PEND_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-IDSISTEM     PIC  X(002).*/
        public StringBasis V1SIST_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1ENDO-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-DTVENCTO    PIC  X(010).*/
        public StringBasis V1ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-QTD-PGTO    PIC S9(004)               COMP-3.*/
        public IntBasis V0ENDO_QTD_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-NRPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-OCORHIST    PIC S9(004)                 COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1REL-SITUACAO      PIC  X(001).*/
        public StringBasis V1REL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1REL-IDSISTEM      PIC  X(002).*/
        public StringBasis V1REL_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1REL-CODRELAT      PIC  X(008).*/
        public StringBasis V1REL_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HISP-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HISP-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VE0029B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VE0029B_AREA_DE_WORK();
        public class VE0029B_AREA_DE_WORK : VarBasis
        {
            /*"  05         W-TIME                      PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"  05         W-TIME-EDIT                 PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         WS-IND-TAB                  PIC S9(004)    COMP.*/
            public IntBasis WS_IND_TAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         AC-L-V0PENDENTE             PIC  9(007) VALUE ZEROS*/
            public IntBasis AC_L_V0PENDENTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0HISTOPARC            PIC  9(007) VALUE ZEROS*/
            public IntBasis AC_C_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-INST-V1RELATOR           PIC  9(007) VALUE ZEROS*/
            public IntBasis AC_INST_V1RELATOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1SISTEMA              PIC X(001) VALUE SPACES*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0PENDENTE             PIC X(001) VALUE SPACES*/
            public StringBasis WFIM_V0PENDENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WHOUVE-PGTO-FUTURO          PIC X(003) VALUE SPACES*/
            public StringBasis WHOUVE_PGTO_FUTURO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         EXISTE-TERMOADESAO          PIC X(003) VALUE SPACES*/
            public StringBasis EXISTE_TERMOADESAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         EXISTE-SOLICITACAO          PIC X(003) VALUE SPACES*/
            public StringBasis EXISTE_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WHOUVE-PGTO                 PIC X(003) VALUE SPACES*/
            public StringBasis WHOUVE_PGTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WPARCELA-PAGA               PIC X(003) VALUE SPACES*/
            public StringBasis WPARCELA_PAGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WHISTORICO-PAGO             PIC X(003) VALUE SPACES*/
            public StringBasis WHISTORICO_PAGO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WCURSOR-FECHADO             PIC X(003) VALUE SPACES*/
            public StringBasis WCURSOR_FECHADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WDATA-REL                   PIC X(010) VALUE SPACES*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VE0029B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VE0029B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VE0029B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VE0029B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO                PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER                      PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES                PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER                      PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA                PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_VE0029B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VE0029B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VE0029B_WDAT_REL_LIT();
            public class VE0029B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA                PIC  9(002) VALUE ZEROS*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER                      PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES                PIC  9(002) VALUE ZEROS*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER                      PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO                PIC  9(004) VALUE ZEROS*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WEMIS-DATA                  PIC  X(010) VALUE ZEROS*/
            }
            public StringBasis WEMIS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WEMIS-DATA.*/
            private _REDEF_VE0029B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VE0029B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VE0029B_FILLER_5(); _.Move(WEMIS_DATA, _filler_5); VarBasis.RedefinePassValue(WEMIS_DATA, _filler_5, WEMIS_DATA); _filler_5.ValueChanged += () => { _.Move(_filler_5, WEMIS_DATA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WEMIS_DATA); }
            }  //Redefines
            public class _REDEF_VE0029B_FILLER_5 : VarBasis
            {
                /*"    10       WEMIS-ANOMES.*/
                public VE0029B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new VE0029B_WEMIS_ANOMES();
                public class VE0029B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15     WEMI-ANO                    PIC  9(004).*/
                    public IntBasis WEMI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER                      PIC  X(001).*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WEMI-MES                    PIC  9(002).*/
                    public IntBasis WEMI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER                      PIC  X(001).*/

                    public VE0029B_WEMIS_ANOMES()
                    {
                        WEMI_ANO.ValueChanged += OnValueChanged;
                        FILLER_6.ValueChanged += OnValueChanged;
                        WEMI_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WEMI-DIA                    PIC  9(002).*/
                public IntBasis WEMI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSIST-DATA                  PIC  X(010) VALUE ZEROS*/

                public _REDEF_VE0029B_FILLER_5()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WEMI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA.*/
            private _REDEF_VE0029B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VE0029B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VE0029B_FILLER_8(); _.Move(WSIST_DATA, _filler_8); VarBasis.RedefinePassValue(WSIST_DATA, _filler_8, WSIST_DATA); _filler_8.ValueChanged += () => { _.Move(_filler_8, WSIST_DATA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_VE0029B_FILLER_8 : VarBasis
            {
                /*"    10       WSIST-ANOMES.*/
                public VE0029B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new VE0029B_WSIST_ANOMES();
                public class VE0029B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO                    PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER                      PIC  X(001).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WSIS-MES                    PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER                      PIC  X(001).*/

                    public VE0029B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DIA                    PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W-DATA.*/

                public _REDEF_VE0029B_FILLER_8()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VE0029B_W_DATA W_DATA { get; set; } = new VE0029B_W_DATA();
            public class VE0029B_W_DATA : VarBasis
            {
                /*"    07  W-DD                             PIC  9(02).*/
                public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  W-MM                             PIC  9(02).*/
                public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  W-AA                             PIC  9(04).*/
                public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05  W-DATA-EDITADA.*/
            }
            public VE0029B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new VE0029B_W_DATA_EDITADA();
            public class VE0029B_W_DATA_EDITADA : VarBasis
            {
                /*"    07  W-ANO                            PIC  9(04).*/
                public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    07  FILLER                           PIC  X(01).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    07  W-MES                            PIC  9(02).*/
                public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    07  FILLER                           PIC  X(01).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    07  W-DIA                            PIC  9(02).*/
                public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05         WTIME-DAY                   PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_VE0029B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VE0029B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VE0029B_FILLER_13(); _.Move(WTIME_DAY, _filler_13); VarBasis.RedefinePassValue(WTIME_DAY, _filler_13, WTIME_DAY); _filler_13.ValueChanged += () => { _.Move(_filler_13, WTIME_DAY); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VE0029B_FILLER_13 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VE0029B_WTIME_DAYR WTIME_DAYR { get; set; } = new VE0029B_WTIME_DAYR();
                public class VE0029B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA                  PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1                  PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU                  PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2                  PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU                  PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3                  PIC  X(001).*/

                    public VE0029B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSG                  PIC  X(002).*/
                public StringBasis WTIME_CCSG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05        WABEND.*/

                public _REDEF_VE0029B_FILLER_13()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
            public VE0029B_WABEND WABEND { get; set; } = new VE0029B_WABEND();
            public class VE0029B_WABEND : VarBasis
            {
                /*"    10      FILLER                       PIC  X(009) VALUE           'VE0029B '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"VE0029B ");
                /*"    10      FILLER                       PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL                 PIC  X(003) VALUE '000'*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER                       PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE                     PIC ZZZZZ999-                                             VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01    WS-HORAS.*/
            }
        }
        public VE0029B_WS_HORAS WS_HORAS { get; set; } = new VE0029B_WS_HORAS();
        public class VE0029B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VE0029B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VE0029B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VE0029B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VE0029B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VE0029B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VE0029B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VE0029B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VE0029B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VE0029B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_VE0029B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VE0029B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VE0029B_TOTAIS_ROT();
        public class VE0029B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 16 TIMES.*/
            public ListBasis<VE0029B_FILLER_17> FILLER_17 { get; set; } = new ListBasis<VE0029B_FILLER_17>(16);
            public class VE0029B_FILLER_17 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public VE0029B_V0PENDENTE V0PENDENTE { get; set; } = new VE0029B_V0PENDENTE();
        public VE0029B_V0ENDOSSO V0ENDOSSO { get; set; } = new VE0029B_V0ENDOSSO();
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
            /*" -277- DISPLAY ' ' */
            _.Display($" ");

            /*" -279- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -287- DISPLAY 'PROGRAMA EM EXECUCAO VE0029B-' 'VERSAO V.05- DEMANDA 281754 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VE0029B-VERSAO V.05- DEMANDA 281754 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -289- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -291- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -294- INITIALIZE TOTAIS-ROT */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -295- ACCEPT W-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.W_TIME);

            /*" -296- MOVE W-TIME TO W-TIME-EDIT */
            _.Move(AREA_DE_WORK.W_TIME, AREA_DE_WORK.W_TIME_EDIT);

            /*" -297- DISPLAY 'INICIO  PROCESSAMENTO VE0029B   ' W-TIME-EDIT. */
            _.Display($"INICIO  PROCESSAMENTO VE0029B   {AREA_DE_WORK.W_TIME_EDIT}");

            /*" -299- DISPLAY ' ' . */
            _.Display($" ");

            /*" -300- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -301- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -303- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -305- PERFORM R0200-00-DECLER-V0ENDOSSO. */

            R0200_00_DECLER_V0ENDOSSO_SECTION();

            /*" -306- PERFORM R0210-00-FETCH-V0PENDENTE */

            R0210_00_FETCH_V0PENDENTE_SECTION();

            /*" -307- IF WFIM-V0PENDENTE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0PENDENTE.IsEmpty())
            {

                /*" -308- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -310- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -313- PERFORM R0220-00-PROCESSA-V0PENDENTE UNTIL WFIM-V0PENDENTE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0PENDENTE.IsEmpty()))
            {

                R0220_00_PROCESSA_V0PENDENTE_SECTION();
            }

            /*" -315- PERFORM R9998-00-MONITOR. */

            R9998_00_MONITOR_SECTION();

            /*" -316- DISPLAY ' ' */
            _.Display($" ");

            /*" -317- DISPLAY 'VE0029B - TERMINO PROCESSAMENTO NORMAL' */
            _.Display($"VE0029B - TERMINO PROCESSAMENTO NORMAL");

            /*" -319- DISPLAY '          SUBGRUPOS PROCESSADOS.... ' AC-L-V0PENDENTE */
            _.Display($"          SUBGRUPOS PROCESSADOS.... {AREA_DE_WORK.AC_L_V0PENDENTE}");

            /*" -322- DISPLAY '          SOLICITACOES GERADAS..... ' AC-INST-V1RELATOR. */
            _.Display($"          SOLICITACOES GERADAS..... {AREA_DE_WORK.AC_INST_V1RELATOR}");

            /*" -323- ACCEPT W-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.W_TIME);

            /*" -324- MOVE W-TIME TO W-TIME-EDIT */
            _.Move(AREA_DE_WORK.W_TIME, AREA_DE_WORK.W_TIME_EDIT);

            /*" -325- DISPLAY ' ' . */
            _.Display($" ");

            /*" -326- DISPLAY 'TERMINO PROCESSAMENTO VE0029B   ' W-TIME-EDIT. */
            _.Display($"TERMINO PROCESSAMENTO VE0029B   {AREA_DE_WORK.W_TIME_EDIT}");

            /*" -326- DISPLAY ' ' . */
            _.Display($" ");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -332- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -335- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -336- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -337- DISPLAY 'PROBLEMAS NO COMMIT DO PROGRAMA VE0029B ' SQLCODE */
                _.Display($"PROBLEMAS NO COMMIT DO PROGRAMA VE0029B {DB.SQLCODE}");

                /*" -339- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -341- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -341- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -353- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -355- MOVE 'VE' TO V1SIST-IDSISTEM. */
            _.Move("VE", V1SIST_IDSISTEM);

            /*" -360- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -364- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -365- DISPLAY 'VE0029B - SISTEMA DE COBRANCA NAO CADASTRADO' */
                    _.Display($"VE0029B - SISTEMA DE COBRANCA NAO CADASTRADO");

                    /*" -366- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -367- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -368- ELSE */
                }
                else
                {


                    /*" -369- DISPLAY 'PROBLEMAS SELECT V1SISTEMA ... ' */
                    _.Display($"PROBLEMAS SELECT V1SISTEMA ... ");

                    /*" -371- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -373- MOVE V1SIST-DTMOVABE TO WSIST-DATA WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA, AREA_DE_WORK.WDATA_REL);

            /*" -374- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -375- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -375- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -360- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = :V1SIST-IDSISTEM END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
                V1SIST_IDSISTEM = V1SIST_IDSISTEM.ToString(),
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLER-V0ENDOSSO-SECTION */
        private void R0200_00_DECLER_V0ENDOSSO_SECTION()
        {
            /*" -392- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -393- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -397- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -398- MOVE '1' TO V0PEND-TP-ENDOSSO. */
            _.Move("1", V0PEND_TP_ENDOSSO);

            /*" -400- MOVE '0' TO V0PEND-SITUACAO. */
            _.Move("0", V0PEND_SITUACAO);

            /*" -423- PERFORM R0200_00_DECLER_V0ENDOSSO_DB_DECLARE_1 */

            R0200_00_DECLER_V0ENDOSSO_DB_DECLARE_1();

            /*" -427- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -428- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -429- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -430- ADD SFT TO STT(01) */
            TOTAIS_ROT.FILLER_17[01].STT.Value = TOTAIS_ROT.FILLER_17[01].STT + WS_HORAS.SFT;

            /*" -436- ADD 1 TO SQT(01) */
            TOTAIS_ROT.FILLER_17[01].SQT.Value = TOTAIS_ROT.FILLER_17[01].SQT + 1;

            /*" -437- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -440- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -440- PERFORM R0200_00_DECLER_V0ENDOSSO_DB_OPEN_1 */

            R0200_00_DECLER_V0ENDOSSO_DB_OPEN_1();

            /*" -444- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -445- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -446- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -447- ADD SFT TO STT(02) */
            TOTAIS_ROT.FILLER_17[02].STT.Value = TOTAIS_ROT.FILLER_17[02].STT + WS_HORAS.SFT;

            /*" -450- ADD 1 TO SQT(02). */
            TOTAIS_ROT.FILLER_17[02].SQT.Value = TOTAIS_ROT.FILLER_17[02].SQT + 1;

            /*" -451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -453- DISPLAY 'R0200  PROBLEMAS OPEN V0PENDENTE...  ' SQLCODE */
                _.Display($"R0200  PROBLEMAS OPEN V0PENDENTE...  {DB.SQLCODE}");

                /*" -453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLER-V0ENDOSSO-DB-DECLARE-1 */
        public void R0200_00_DECLER_V0ENDOSSO_DB_DECLARE_1()
        {
            /*" -423- EXEC SQL DECLARE V0PENDENTE CURSOR FOR SELECT NUM_APOLICE, CODSUBES, MAX(NRENDOS), MAX(DTVENCTO) FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE IN (0097010000889, 0010930000959, 0108208874329, 3008208874329, 3008218874329, 0109300000672, 0108211323063, 0108211323064) AND CODSUBES > 0 AND TIPO_ENDOSSO = :V0PEND-TP-ENDOSSO AND SITUACAO = :V0PEND-SITUACAO AND DTVENCTO + 5 DAYS < :V1SIST-DTMOVABE GROUP BY NUM_APOLICE, CODSUBES ORDER BY NUM_APOLICE, CODSUBES END-EXEC. */
            V0PENDENTE = new VE0029B_V0PENDENTE(true);
            string GetQuery_V0PENDENTE()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							MAX(NRENDOS)
							, 
							MAX(DTVENCTO) 
							FROM SEGUROS.V0ENDOSSO 
							WHERE NUM_APOLICE IN (0097010000889
							, 
							0010930000959
							, 
							0108208874329
							, 
							3008208874329
							, 
							3008218874329
							, 
							0109300000672
							, 
							0108211323063
							, 
							0108211323064) 
							AND CODSUBES > 0 
							AND TIPO_ENDOSSO = '{V0PEND_TP_ENDOSSO}' 
							AND SITUACAO = '{V0PEND_SITUACAO}' 
							AND DTVENCTO + 5 DAYS < '{V1SIST_DTMOVABE}' 
							GROUP BY NUM_APOLICE
							, CODSUBES 
							ORDER BY NUM_APOLICE
							, CODSUBES";

                return query;
            }
            V0PENDENTE.GetQueryEvent += GetQuery_V0PENDENTE;

        }

        [StopWatch]
        /*" R0200-00-DECLER-V0ENDOSSO-DB-OPEN-1 */
        public void R0200_00_DECLER_V0ENDOSSO_DB_OPEN_1()
        {
            /*" -440- EXEC SQL OPEN V0PENDENTE END-EXEC. */

            V0PENDENTE.Open();

        }

        [StopWatch]
        /*" R0235-00-SEL-PERCELAS-ANT-DB-DECLARE-1 */
        public void R0235_00_SEL_PERCELAS_ANT_DB_DECLARE_1()
        {
            /*" -720- EXEC SQL DECLARE V0ENDOSSO CURSOR FOR SELECT NRENDOS, SITUACAO, DTVENCTO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0PEND-NUM-APOL AND CODSUBES = :V0PEND-COD-SUBG AND TIPO_ENDOSSO = :V0PEND-TP-ENDOSSO AND DTVENCTO < :V0PEND-DTVENCTO ORDER BY DTVENCTO DESC END-EXEC. */
            V0ENDOSSO = new VE0029B_V0ENDOSSO(true);
            string GetQuery_V0ENDOSSO()
            {
                var query = @$"SELECT NRENDOS
							, 
							SITUACAO
							, 
							DTVENCTO 
							FROM SEGUROS.V0ENDOSSO 
							WHERE NUM_APOLICE = '{V0PEND_NUM_APOL}' 
							AND CODSUBES = '{V0PEND_COD_SUBG}' 
							AND TIPO_ENDOSSO = '{V0PEND_TP_ENDOSSO}' 
							AND DTVENCTO < '{V0PEND_DTVENCTO}' 
							ORDER BY DTVENCTO DESC";

                return query;
            }
            V0ENDOSSO.GetQueryEvent += GetQuery_V0ENDOSSO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PENDENTE-SECTION */
        private void R0210_00_FETCH_V0PENDENTE_SECTION()
        {
            /*" -467- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -468- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -471- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -476- PERFORM R0210_00_FETCH_V0PENDENTE_DB_FETCH_1 */

            R0210_00_FETCH_V0PENDENTE_DB_FETCH_1();

            /*" -480- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -481- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -482- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -483- ADD SFT TO STT(03) */
            TOTAIS_ROT.FILLER_17[03].STT.Value = TOTAIS_ROT.FILLER_17[03].STT + WS_HORAS.SFT;

            /*" -487- ADD 1 TO SQT(03) */
            TOTAIS_ROT.FILLER_17[03].SQT.Value = TOTAIS_ROT.FILLER_17[03].SQT + 1;

            /*" -488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -489- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -492- MOVE 'S' TO WFIM-V0PENDENTE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0PENDENTE);

                    /*" -493- ACCEPT WS-HORA-INI FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

                    /*" -496- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
                    WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

                    /*" -496- PERFORM R0210_00_FETCH_V0PENDENTE_DB_CLOSE_1 */

                    R0210_00_FETCH_V0PENDENTE_DB_CLOSE_1();

                    /*" -500- ACCEPT WS-HORA-FIM FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

                    /*" -501- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
                    WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

                    /*" -502- SUBTRACT SIT FROM SFT */
                    WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

                    /*" -503- ADD SFT TO STT(04) */
                    TOTAIS_ROT.FILLER_17[04].STT.Value = TOTAIS_ROT.FILLER_17[04].STT + WS_HORAS.SFT;

                    /*" -506- ADD 1 TO SQT(04) */
                    TOTAIS_ROT.FILLER_17[04].SQT.Value = TOTAIS_ROT.FILLER_17[04].SQT + 1;

                    /*" -507- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -508- DISPLAY 'R0210 ERRO CLOSE CURSOR V0PENDENTE  ' SQLCODE */
                        _.Display($"R0210 ERRO CLOSE CURSOR V0PENDENTE  {DB.SQLCODE}");

                        /*" -509- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -511- END-IF */
                    }


                    /*" -512- ELSE */
                }
                else
                {


                    /*" -513- DISPLAY 'R0210 - PROBLEMAS FETCH V0PENDENTE..... ' */
                    _.Display($"R0210 - PROBLEMAS FETCH V0PENDENTE..... ");

                    /*" -514- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -516- ELSE */
                }

            }
            else
            {


                /*" -522- IF (V0PEND-COD-SUBG = 1 OR 1948 OR 1949 OR 1950 OR 1951 OR 2910 OR 3603 OR 4150 OR 4190 OR 3077 OR 3200 OR 5274 OR 1283) AND V0PEND-NUM-APOL = 97010000889 */

                if ((V0PEND_COD_SUBG.In("1", "1948", "1949", "1950", "1951", "2910", "3603", "4150", "4190", "3077", "3200", "5274", "1283")) && V0PEND_NUM_APOL == 97010000889)
                {

                    /*" -523- GO TO R0210-00-FETCH-V0PENDENTE */
                    new Task(() => R0210_00_FETCH_V0PENDENTE_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -524- ELSE */
                }
                else
                {


                    /*" -524- ADD 1 TO AC-L-V0PENDENTE. */
                    AREA_DE_WORK.AC_L_V0PENDENTE.Value = AREA_DE_WORK.AC_L_V0PENDENTE + 1;
                }

            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PENDENTE-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PENDENTE_DB_FETCH_1()
        {
            /*" -476- EXEC SQL FETCH V0PENDENTE INTO :V0PEND-NUM-APOL, :V0PEND-COD-SUBG, :V0PEND-NRENDOS, :V0PEND-DTVENCTO:VIND-DTVENCTO END-EXEC. */

            if (V0PENDENTE.Fetch())
            {
                _.Move(V0PENDENTE.V0PEND_NUM_APOL, V0PEND_NUM_APOL);
                _.Move(V0PENDENTE.V0PEND_COD_SUBG, V0PEND_COD_SUBG);
                _.Move(V0PENDENTE.V0PEND_NRENDOS, V0PEND_NRENDOS);
                _.Move(V0PENDENTE.V0PEND_DTVENCTO, V0PEND_DTVENCTO);
                _.Move(V0PENDENTE.VIND_DTVENCTO, VIND_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PENDENTE-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PENDENTE_DB_CLOSE_1()
        {
            /*" -496- EXEC SQL CLOSE V0PENDENTE END-EXEC */

            V0PENDENTE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-V0PENDENTE-SECTION */
        private void R0220_00_PROCESSA_V0PENDENTE_SECTION()
        {
            /*" -536- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -538- MOVE SPACES TO WHOUVE-PGTO-FUTURO. */
            _.Move("", AREA_DE_WORK.WHOUVE_PGTO_FUTURO);

            /*" -540- MOVE 'NAO' TO WCURSOR-FECHADO. */
            _.Move("NAO", AREA_DE_WORK.WCURSOR_FECHADO);

            /*" -542- PERFORM R0225-00-LER-V0TERMOADESAO. */

            R0225_00_LER_V0TERMOADESAO_SECTION();

            /*" -543- IF EXISTE-TERMOADESAO EQUAL 'SIM' */

            if (AREA_DE_WORK.EXISTE_TERMOADESAO == "SIM")
            {

                /*" -544- PERFORM R0230-00-HOUVE-PGTO-FUTURO */

                R0230_00_HOUVE_PGTO_FUTURO_SECTION();

                /*" -545- IF WHOUVE-PGTO-FUTURO EQUAL 'NAO' */

                if (AREA_DE_WORK.WHOUVE_PGTO_FUTURO == "NAO")
                {

                    /*" -546- MOVE SPACES TO WHOUVE-PGTO */
                    _.Move("", AREA_DE_WORK.WHOUVE_PGTO);

                    /*" -547- MOVE 1 TO WS-IND-TAB */
                    _.Move(1, AREA_DE_WORK.WS_IND_TAB);

                    /*" -549- MOVE V0PEND-DTVENCTO TO V1ENDO-DTVENCTO */
                    _.Move(V0PEND_DTVENCTO, V1ENDO_DTVENCTO);

                    /*" -554- PERFORM R0235-00-SEL-PERCELAS-ANT */

                    R0235_00_SEL_PERCELAS_ANT_SECTION();

                    /*" -555- IF V0TERMO-PERIPGTO GREATER 2 */

                    if (V0TERMO_PERIPGTO > 2)
                    {

                        /*" -556- MOVE 'NAO' TO WHOUVE-PGTO */
                        _.Move("NAO", AREA_DE_WORK.WHOUVE_PGTO);

                        /*" -557- MOVE 5 TO WS-IND-TAB */
                        _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                        /*" -558- PERFORM R0245-00-CLOSE-CURSOR */

                        R0245_00_CLOSE_CURSOR_SECTION();

                        /*" -559- ELSE */
                    }
                    else
                    {


                        /*" -561- PERFORM R0240-00-VERIFICAR-PENDENCIA UNTIL WS-IND-TAB GREATER 3 */

                        while (!(AREA_DE_WORK.WS_IND_TAB > 3))
                        {

                            R0240_00_VERIFICAR_PENDENCIA_SECTION();
                        }

                        /*" -563- END-IF */
                    }


                    /*" -565- MOVE 'SIM' TO EXISTE-SOLICITACAO */
                    _.Move("SIM", AREA_DE_WORK.EXISTE_SOLICITACAO);

                    /*" -566- IF WHOUVE-PGTO EQUAL 'NAO' */

                    if (AREA_DE_WORK.WHOUVE_PGTO == "NAO")
                    {

                        /*" -567- PERFORM R0275-00-VERIFICA-SOLICITACAO */

                        R0275_00_VERIFICA_SOLICITACAO_SECTION();

                        /*" -568- IF EXISTE-SOLICITACAO EQUAL 'NAO' */

                        if (AREA_DE_WORK.EXISTE_SOLICITACAO == "NAO")
                        {

                            /*" -568- PERFORM R0280-00-GERA-SOL-CANCELAMENTO. */

                            R0280_00_GERA_SOL_CANCELAMENTO_SECTION();
                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0220_00_LER_PROXIMO */

            R0220_00_LER_PROXIMO();

        }

        [StopWatch]
        /*" R0220-00-LER-PROXIMO */
        private void R0220_00_LER_PROXIMO(bool isPerform = false)
        {
            /*" -572- PERFORM R0210-00-FETCH-V0PENDENTE. */

            R0210_00_FETCH_V0PENDENTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0225-00-LER-V0TERMOADESAO-SECTION */
        private void R0225_00_LER_V0TERMOADESAO_SECTION()
        {
            /*" -589- MOVE '225' TO WNR-EXEC-SQL. */
            _.Move("225", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -590- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -593- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -605- PERFORM R0225_00_LER_V0TERMOADESAO_DB_SELECT_1 */

            R0225_00_LER_V0TERMOADESAO_DB_SELECT_1();

            /*" -610- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -611- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -612- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -613- ADD SFT TO STT(05) */
            TOTAIS_ROT.FILLER_17[05].STT.Value = TOTAIS_ROT.FILLER_17[05].STT + WS_HORAS.SFT;

            /*" -616- ADD 1 TO SQT(05) */
            TOTAIS_ROT.FILLER_17[05].SQT.Value = TOTAIS_ROT.FILLER_17[05].SQT + 1;

            /*" -617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -618- DISPLAY ' ' */
                _.Display($" ");

                /*" -619- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -620- DISPLAY 'R0225-00 - TERMOADESAO NAO CADASTRADO' */
                    _.Display($"R0225-00 - TERMOADESAO NAO CADASTRADO");

                    /*" -621- DISPLAY 'APOLICE......  ' V0PEND-NUM-APOL */
                    _.Display($"APOLICE......  {V0PEND_NUM_APOL}");

                    /*" -622- DISPLAY 'SUBGRUPO.....  ' V0PEND-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V0PEND_COD_SUBG}");

                    /*" -623- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -624- MOVE 'NAO' TO EXISTE-TERMOADESAO */
                    _.Move("NAO", AREA_DE_WORK.EXISTE_TERMOADESAO);

                    /*" -625- ELSE */
                }
                else
                {


                    /*" -626- DISPLAY 'R0225-00 - PROBLEMAS ACESSO V0TERMOADESAO' */
                    _.Display($"R0225-00 - PROBLEMAS ACESSO V0TERMOADESAO");

                    /*" -627- DISPLAY 'APOLICE......  ' V0PEND-NUM-APOL */
                    _.Display($"APOLICE......  {V0PEND_NUM_APOL}");

                    /*" -628- DISPLAY 'SUBGRUPO.....  ' V0PEND-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V0PEND_COD_SUBG}");

                    /*" -629- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -630- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -631- ELSE */
                }

            }
            else
            {


                /*" -631- MOVE 'SIM' TO EXISTE-TERMOADESAO. */
                _.Move("SIM", AREA_DE_WORK.EXISTE_TERMOADESAO);
            }


        }

        [StopWatch]
        /*" R0225-00-LER-V0TERMOADESAO-DB-SELECT-1 */
        public void R0225_00_LER_V0TERMOADESAO_DB_SELECT_1()
        {
            /*" -605- EXEC SQL SELECT NUM_TERMO, COD_SUBGRUPO, PERI_PAGAMENTO, SITUACAO INTO :V0TERMO-NUM-TERMO, :V0TERMO-COD-SUBG, :V0TERMO-PERIPGTO, :V0TERMO-SITUACAO FROM SEGUROS.V0TERMOADESAO WHERE NUM_APOLICE = :V0PEND-NUM-APOL AND COD_SUBGRUPO = :V0PEND-COD-SUBG END-EXEC. */

            var r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 = new R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1()
            {
                V0PEND_NUM_APOL = V0PEND_NUM_APOL.ToString(),
                V0PEND_COD_SUBG = V0PEND_COD_SUBG.ToString(),
            };

            var executed_1 = R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1.Execute(r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0TERMO_NUM_TERMO, V0TERMO_NUM_TERMO);
                _.Move(executed_1.V0TERMO_COD_SUBG, V0TERMO_COD_SUBG);
                _.Move(executed_1.V0TERMO_PERIPGTO, V0TERMO_PERIPGTO);
                _.Move(executed_1.V0TERMO_SITUACAO, V0TERMO_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0225_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-HOUVE-PGTO-FUTURO-SECTION */
        private void R0230_00_HOUVE_PGTO_FUTURO_SECTION()
        {
            /*" -647- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -648- MOVE '1' TO V0PEND-SITUACAO. */
            _.Move("1", V0PEND_SITUACAO);

            /*" -651- MOVE '1' TO V0PEND-TP-ENDOSSO. */
            _.Move("1", V0PEND_TP_ENDOSSO);

            /*" -652- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -655- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -664- PERFORM R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1 */

            R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1();

            /*" -668- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -669- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -670- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -671- ADD SFT TO STT(06) */
            TOTAIS_ROT.FILLER_17[06].STT.Value = TOTAIS_ROT.FILLER_17[06].STT + WS_HORAS.SFT;

            /*" -674- ADD 1 TO SQT(06) */
            TOTAIS_ROT.FILLER_17[06].SQT.Value = TOTAIS_ROT.FILLER_17[06].SQT + 1;

            /*" -675- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- IF SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

                if (DB.SQLCODE != 100 && DB.SQLCODE != -811)
                {

                    /*" -678- DISPLAY 'R0230-00 - PROBLEMAS SELECT V0ENDOSSO' */
                    _.Display($"R0230-00 - PROBLEMAS SELECT V0ENDOSSO");

                    /*" -679- DISPLAY 'R0230-00 - VERIFICA  PGTO FUTURO' */
                    _.Display($"R0230-00 - VERIFICA  PGTO FUTURO");

                    /*" -680- DISPLAY 'APOLICE......  ' V0PEND-NUM-APOL */
                    _.Display($"APOLICE......  {V0PEND_NUM_APOL}");

                    /*" -681- DISPLAY 'SUBGRUPO.....  ' V0PEND-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V0PEND_COD_SUBG}");

                    /*" -682- DISPLAY 'DTMOVABE.....  ' V0PEND-DTVENCTO */
                    _.Display($"DTMOVABE.....  {V0PEND_DTVENCTO}");

                    /*" -683- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -685- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -686- IF V0ENDO-QTD-PGTO EQUAL ZERO */

            if (V0ENDO_QTD_PGTO == 00)
            {

                /*" -687- MOVE 'NAO' TO WHOUVE-PGTO-FUTURO */
                _.Move("NAO", AREA_DE_WORK.WHOUVE_PGTO_FUTURO);

                /*" -688- ELSE */
            }
            else
            {


                /*" -688- MOVE 'SIM' TO WHOUVE-PGTO-FUTURO. */
                _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO_FUTURO);
            }


        }

        [StopWatch]
        /*" R0230-00-HOUVE-PGTO-FUTURO-DB-SELECT-1 */
        public void R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1()
        {
            /*" -664- EXEC SQL SELECT COUNT(*) INTO :V0ENDO-QTD-PGTO:VIND-QTD-PGTO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0PEND-NUM-APOL AND CODSUBES = :V0PEND-COD-SUBG AND SITUACAO = :V0PEND-SITUACAO AND TIPO_ENDOSSO = :V0PEND-TP-ENDOSSO AND DTVENCTO > :V0PEND-DTVENCTO END-EXEC. */

            var r0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1 = new R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1()
            {
                V0PEND_TP_ENDOSSO = V0PEND_TP_ENDOSSO.ToString(),
                V0PEND_NUM_APOL = V0PEND_NUM_APOL.ToString(),
                V0PEND_COD_SUBG = V0PEND_COD_SUBG.ToString(),
                V0PEND_SITUACAO = V0PEND_SITUACAO.ToString(),
                V0PEND_DTVENCTO = V0PEND_DTVENCTO.ToString(),
            };

            var executed_1 = R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1.Execute(r0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_QTD_PGTO, V0ENDO_QTD_PGTO);
                _.Move(executed_1.VIND_QTD_PGTO, VIND_QTD_PGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0235-00-SEL-PERCELAS-ANT-SECTION */
        private void R0235_00_SEL_PERCELAS_ANT_SECTION()
        {
            /*" -703- MOVE '235' TO WNR-EXEC-SQL. */
            _.Move("235", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -706- MOVE '1' TO V0PEND-TP-ENDOSSO. */
            _.Move("1", V0PEND_TP_ENDOSSO);

            /*" -707- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -710- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -720- PERFORM R0235_00_SEL_PERCELAS_ANT_DB_DECLARE_1 */

            R0235_00_SEL_PERCELAS_ANT_DB_DECLARE_1();

            /*" -724- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -725- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -726- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -727- ADD SFT TO STT(07) */
            TOTAIS_ROT.FILLER_17[07].STT.Value = TOTAIS_ROT.FILLER_17[07].STT + WS_HORAS.SFT;

            /*" -732- ADD 1 TO SQT(07) */
            TOTAIS_ROT.FILLER_17[07].SQT.Value = TOTAIS_ROT.FILLER_17[07].SQT + 1;

            /*" -733- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -736- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -736- PERFORM R0235_00_SEL_PERCELAS_ANT_DB_OPEN_1 */

            R0235_00_SEL_PERCELAS_ANT_DB_OPEN_1();

            /*" -740- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -741- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -742- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -743- ADD SFT TO STT(08) */
            TOTAIS_ROT.FILLER_17[08].STT.Value = TOTAIS_ROT.FILLER_17[08].STT + WS_HORAS.SFT;

            /*" -746- ADD 1 TO SQT(08). */
            TOTAIS_ROT.FILLER_17[08].SQT.Value = TOTAIS_ROT.FILLER_17[08].SQT + 1;

            /*" -747- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -749- DISPLAY 'R0235  PROBLEMAS OPEN V0ENDOSSO...  ' SQLCODE */
                _.Display($"R0235  PROBLEMAS OPEN V0ENDOSSO...  {DB.SQLCODE}");

                /*" -749- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0235-00-SEL-PERCELAS-ANT-DB-OPEN-1 */
        public void R0235_00_SEL_PERCELAS_ANT_DB_OPEN_1()
        {
            /*" -736- EXEC SQL OPEN V0ENDOSSO END-EXEC. */

            V0ENDOSSO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0235_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-VERIFICAR-PENDENCIA-SECTION */
        private void R0240_00_VERIFICAR_PENDENCIA_SECTION()
        {
            /*" -763- PERFORM R0250-00-VERIFICA-PGTO-PARCELA */

            R0250_00_VERIFICA_PGTO_PARCELA_SECTION();

            /*" -764- IF WPARCELA-PAGA EQUAL 'NAO' */

            if (AREA_DE_WORK.WPARCELA_PAGA == "NAO")
            {

                /*" -765- PERFORM R0260-00-VERIFICA-PGTO-HISPARC */

                R0260_00_VERIFICA_PGTO_HISPARC_SECTION();

                /*" -766- IF WHISTORICO-PAGO EQUAL 'NAO' */

                if (AREA_DE_WORK.WHISTORICO_PAGO == "NAO")
                {

                    /*" -767- PERFORM R0270-00-ACESSA-PARCELA-ANT */

                    R0270_00_ACESSA_PARCELA_ANT_SECTION();

                    /*" -768- ELSE */
                }
                else
                {


                    /*" -769- MOVE 'SIM' TO WHOUVE-PGTO */
                    _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                    /*" -770- MOVE 5 TO WS-IND-TAB */
                    _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                    /*" -771- ELSE */
                }

            }
            else
            {


                /*" -772- MOVE 5 TO WS-IND-TAB */
                _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                /*" -774- MOVE 'SIM' TO WHOUVE-PGTO. */
                _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);
            }


            /*" -776- IF WS-IND-TAB GREATER 3 OR WHOUVE-PGTO EQUAL 'SIM' */

            if (AREA_DE_WORK.WS_IND_TAB > 3 || AREA_DE_WORK.WHOUVE_PGTO == "SIM")
            {

                /*" -779- IF WCURSOR-FECHADO EQUAL 'NAO' */

                if (AREA_DE_WORK.WCURSOR_FECHADO == "NAO")
                {

                    /*" -780- ACCEPT WS-HORA-INI FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

                    /*" -783- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
                    WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

                    /*" -783- PERFORM R0240_00_VERIFICAR_PENDENCIA_DB_CLOSE_1 */

                    R0240_00_VERIFICAR_PENDENCIA_DB_CLOSE_1();

                    /*" -788- ACCEPT WS-HORA-FIM FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

                    /*" -789- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
                    WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

                    /*" -790- SUBTRACT SIT FROM SFT */
                    WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

                    /*" -791- ADD SFT TO STT(09) */
                    TOTAIS_ROT.FILLER_17[09].STT.Value = TOTAIS_ROT.FILLER_17[09].STT + WS_HORAS.SFT;

                    /*" -794- ADD 1 TO SQT(09) */
                    TOTAIS_ROT.FILLER_17[09].SQT.Value = TOTAIS_ROT.FILLER_17[09].SQT + 1;

                    /*" -795- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -796- DISPLAY 'R0240 ERRO CLOSE CURSOR V0ENDOSSO ' SQLCODE */
                        _.Display($"R0240 ERRO CLOSE CURSOR V0ENDOSSO {DB.SQLCODE}");

                        /*" -796- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0240-00-VERIFICAR-PENDENCIA-DB-CLOSE-1 */
        public void R0240_00_VERIFICAR_PENDENCIA_DB_CLOSE_1()
        {
            /*" -783- EXEC SQL CLOSE V0ENDOSSO END-EXEC */

            V0ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0245-00-CLOSE-CURSOR-SECTION */
        private void R0245_00_CLOSE_CURSOR_SECTION()
        {
            /*" -807- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -810- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -810- PERFORM R0245_00_CLOSE_CURSOR_DB_CLOSE_1 */

            R0245_00_CLOSE_CURSOR_DB_CLOSE_1();

            /*" -814- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -815- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -816- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -817- ADD SFT TO STT(10) */
            TOTAIS_ROT.FILLER_17[10].STT.Value = TOTAIS_ROT.FILLER_17[10].STT + WS_HORAS.SFT;

            /*" -820- ADD 1 TO SQT(10). */
            TOTAIS_ROT.FILLER_17[10].SQT.Value = TOTAIS_ROT.FILLER_17[10].SQT + 1;

            /*" -821- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -822- DISPLAY 'R0245 ERRO CLOSE CURSOR V0ENDOSSO ' SQLCODE */
                _.Display($"R0245 ERRO CLOSE CURSOR V0ENDOSSO {DB.SQLCODE}");

                /*" -822- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0245-00-CLOSE-CURSOR-DB-CLOSE-1 */
        public void R0245_00_CLOSE_CURSOR_DB_CLOSE_1()
        {
            /*" -810- EXEC SQL CLOSE V0ENDOSSO END-EXEC. */

            V0ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0245_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-VERIFICA-PGTO-PARCELA-SECTION */
        private void R0250_00_VERIFICA_PGTO_PARCELA_SECTION()
        {
            /*" -836- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -837- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -840- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -852- PERFORM R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1 */

            R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1();

            /*" -856- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -857- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -858- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -859- ADD SFT TO STT(11) */
            TOTAIS_ROT.FILLER_17[11].STT.Value = TOTAIS_ROT.FILLER_17[11].STT + WS_HORAS.SFT;

            /*" -862- ADD 1 TO SQT(11) */
            TOTAIS_ROT.FILLER_17[11].SQT.Value = TOTAIS_ROT.FILLER_17[11].SQT + 1;

            /*" -863- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -864- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -865- DISPLAY 'R0260-00 - PROBLEMAS SELECT V0PARCELA' */
                    _.Display($"R0260-00 - PROBLEMAS SELECT V0PARCELA");

                    /*" -866- DISPLAY 'ENDOSSO......  ' V0PEND-NRENDOS */
                    _.Display($"ENDOSSO......  {V0PEND_NRENDOS}");

                    /*" -867- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -869- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -870- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -871- DISPLAY 'ENDOSSO NAO CADASTRADO NA V1PARCELA' */
                _.Display($"ENDOSSO NAO CADASTRADO NA V1PARCELA");

                /*" -872- DISPLAY 'ENDOSSO......  ' V0PEND-NRENDOS */
                _.Display($"ENDOSSO......  {V0PEND_NRENDOS}");

                /*" -873- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -874- MOVE 5 TO WS-IND-TAB */
                _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                /*" -875- ELSE */
            }
            else
            {


                /*" -876- IF V1PARC-SITUACAO EQUAL '1' */

                if (V1PARC_SITUACAO == "1")
                {

                    /*" -877- DISPLAY 'ENDOSSO PAGO NA V1PARCELA' */
                    _.Display($"ENDOSSO PAGO NA V1PARCELA");

                    /*" -878- DISPLAY 'SITUACAO.....  ' V1PARC-SITUACAO */
                    _.Display($"SITUACAO.....  {V1PARC_SITUACAO}");

                    /*" -879- MOVE 'SIM' TO WHOUVE-PGTO */
                    _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                    /*" -880- MOVE 'SIM' TO WPARCELA-PAGA */
                    _.Move("SIM", AREA_DE_WORK.WPARCELA_PAGA);

                    /*" -881- MOVE 5 TO WS-IND-TAB */
                    _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                    /*" -882- ELSE */
                }
                else
                {


                    /*" -883- IF V1PARC-SITUACAO EQUAL '2' */

                    if (V1PARC_SITUACAO == "2")
                    {

                        /*" -884- DISPLAY 'ENDOSSO CANCELADO NA V0PARCELA' */
                        _.Display($"ENDOSSO CANCELADO NA V0PARCELA");

                        /*" -885- DISPLAY 'SITUACAO.....  ' V1PARC-SITUACAO */
                        _.Display($"SITUACAO.....  {V1PARC_SITUACAO}");

                        /*" -886- MOVE 'SIM' TO WHOUVE-PGTO */
                        _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                        /*" -887- MOVE 'SIM' TO WPARCELA-PAGA */
                        _.Move("SIM", AREA_DE_WORK.WPARCELA_PAGA);

                        /*" -888- MOVE 5 TO WS-IND-TAB */
                        _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                        /*" -889- ELSE */
                    }
                    else
                    {


                        /*" -890- MOVE 'NAO' TO WHOUVE-PGTO */
                        _.Move("NAO", AREA_DE_WORK.WHOUVE_PGTO);

                        /*" -890- MOVE 'NAO' TO WPARCELA-PAGA. */
                        _.Move("NAO", AREA_DE_WORK.WPARCELA_PAGA);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0250-00-VERIFICA-PGTO-PARCELA-DB-SELECT-1 */
        public void R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1()
        {
            /*" -852- EXEC SQL SELECT NUM_APOLICE, NRENDOS, SITUACAO, OCORHIST INTO :V1PARC-NUM-APOL, :V1PARC-NRENDOS, :V1PARC-SITUACAO, :V1PARC-OCORHIST FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V0PEND-NUM-APOL AND NRENDOS = :V0PEND-NRENDOS END-EXEC. */

            var r0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1 = new R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1()
            {
                V0PEND_NUM_APOL = V0PEND_NUM_APOL.ToString(),
                V0PEND_NRENDOS = V0PEND_NRENDOS.ToString(),
            };

            var executed_1 = R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1.Execute(r0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-VERIFICA-PGTO-HISPARC-SECTION */
        private void R0260_00_VERIFICA_PGTO_HISPARC_SECTION()
        {
            /*" -905- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -906- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -909- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -920- PERFORM R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1 */

            R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1();

            /*" -924- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -925- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -926- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -927- ADD SFT TO STT(12) */
            TOTAIS_ROT.FILLER_17[12].STT.Value = TOTAIS_ROT.FILLER_17[12].STT + WS_HORAS.SFT;

            /*" -930- ADD 1 TO SQT(12) */
            TOTAIS_ROT.FILLER_17[12].SQT.Value = TOTAIS_ROT.FILLER_17[12].SQT + 1;

            /*" -931- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -932- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -933- DISPLAY 'R0250-00 - PROBLEMAS SELECT V0HISTOPARC' */
                    _.Display($"R0250-00 - PROBLEMAS SELECT V0HISTOPARC");

                    /*" -934- DISPLAY 'APOLICE......  ' V0PEND-NUM-APOL */
                    _.Display($"APOLICE......  {V0PEND_NUM_APOL}");

                    /*" -935- DISPLAY 'ENDOSSO......  ' V1PARC-NRENDOS */
                    _.Display($"ENDOSSO......  {V1PARC_NRENDOS}");

                    /*" -936- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -938- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -939- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -940- DISPLAY 'ENDOSSO NAO CADASTRADO NA V0HISTOPARC' */
                _.Display($"ENDOSSO NAO CADASTRADO NA V0HISTOPARC");

                /*" -941- DISPLAY 'ENDOSSO......  ' V1PARC-NRENDOS */
                _.Display($"ENDOSSO......  {V1PARC_NRENDOS}");

                /*" -942- DISPLAY 'OCORHIST.....  ' V1PARC-OCORHIST */
                _.Display($"OCORHIST.....  {V1PARC_OCORHIST}");

                /*" -943- MOVE 5 TO WS-IND-TAB */
                _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                /*" -944- ELSE */
            }
            else
            {


                /*" -946- IF V1HISP-OPERACAO GREATER 200 AND V1HISP-OPERACAO LESS 300 */

                if (V1HISP_OPERACAO > 200 && V1HISP_OPERACAO < 300)
                {

                    /*" -947- DISPLAY 'ENDOSSO PAGO NA V0HISTOPARC' */
                    _.Display($"ENDOSSO PAGO NA V0HISTOPARC");

                    /*" -948- DISPLAY 'OPERACAO.....  ' V1HISP-OPERACAO */
                    _.Display($"OPERACAO.....  {V1HISP_OPERACAO}");

                    /*" -949- MOVE 'SIM' TO WHOUVE-PGTO */
                    _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                    /*" -950- MOVE 'SIM' TO WHISTORICO-PAGO */
                    _.Move("SIM", AREA_DE_WORK.WHISTORICO_PAGO);

                    /*" -951- MOVE 5 TO WS-IND-TAB */
                    _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                    /*" -952- ELSE */
                }
                else
                {


                    /*" -954- IF V1HISP-OPERACAO GREATER 400 AND V1HISP-OPERACAO LESS 500 */

                    if (V1HISP_OPERACAO > 400 && V1HISP_OPERACAO < 500)
                    {

                        /*" -955- DISPLAY 'ENDOSSO CANCELADO NA V0HISTOPARC' */
                        _.Display($"ENDOSSO CANCELADO NA V0HISTOPARC");

                        /*" -956- DISPLAY 'OPERACAO.....  ' V1HISP-OPERACAO */
                        _.Display($"OPERACAO.....  {V1HISP_OPERACAO}");

                        /*" -957- MOVE 'SIM' TO WHOUVE-PGTO */
                        _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                        /*" -958- MOVE 'SIM' TO WHISTORICO-PAGO */
                        _.Move("SIM", AREA_DE_WORK.WHISTORICO_PAGO);

                        /*" -959- MOVE 5 TO WS-IND-TAB */
                        _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                        /*" -960- ELSE */
                    }
                    else
                    {


                        /*" -961- MOVE 'NAO' TO WHOUVE-PGTO */
                        _.Move("NAO", AREA_DE_WORK.WHOUVE_PGTO);

                        /*" -961- MOVE 'NAO' TO WHISTORICO-PAGO. */
                        _.Move("NAO", AREA_DE_WORK.WHISTORICO_PAGO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0260-00-VERIFICA-PGTO-HISPARC-DB-SELECT-1 */
        public void R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1()
        {
            /*" -920- EXEC SQL SELECT NUM_APOLICE, NRENDOS, OPERACAO INTO :V1HISP-NUM-APOL, :V1HISP-NRENDOS, :V1HISP-OPERACAO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V0PEND-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND OCORHIST = :V1PARC-OCORHIST END-EXEC. */

            var r0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1 = new R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1()
            {
                V0PEND_NUM_APOL = V0PEND_NUM_APOL.ToString(),
                V1PARC_OCORHIST = V1PARC_OCORHIST.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1.Execute(r0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HISP_NUM_APOL, V1HISP_NUM_APOL);
                _.Move(executed_1.V1HISP_NRENDOS, V1HISP_NRENDOS);
                _.Move(executed_1.V1HISP_OPERACAO, V1HISP_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-ACESSA-PARCELA-ANT-SECTION */
        private void R0270_00_ACESSA_PARCELA_ANT_SECTION()
        {
            /*" -977- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -979- ADD 1 TO WS-IND-TAB */
            AREA_DE_WORK.WS_IND_TAB.Value = AREA_DE_WORK.WS_IND_TAB + 1;

            /*" -982- MOVE V1ENDO-DTVENCTO TO V0PEND-DTVENCTO */
            _.Move(V1ENDO_DTVENCTO, V0PEND_DTVENCTO);

            /*" -983- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -986- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -990- PERFORM R0270_00_ACESSA_PARCELA_ANT_DB_FETCH_1 */

            R0270_00_ACESSA_PARCELA_ANT_DB_FETCH_1();

            /*" -994- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -995- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -996- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -997- ADD SFT TO STT(13) */
            TOTAIS_ROT.FILLER_17[13].STT.Value = TOTAIS_ROT.FILLER_17[13].STT + WS_HORAS.SFT;

            /*" -1000- ADD 1 TO SQT(13) */
            TOTAIS_ROT.FILLER_17[13].SQT.Value = TOTAIS_ROT.FILLER_17[13].SQT + 1;

            /*" -1001- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1002- IF V1ENDO-SITUACAO EQUAL '0' */

                if (V1ENDO_SITUACAO == "0")
                {

                    /*" -1003- MOVE 'NAO' TO WHOUVE-PGTO */
                    _.Move("NAO", AREA_DE_WORK.WHOUVE_PGTO);

                    /*" -1004- ELSE */
                }
                else
                {


                    /*" -1005- MOVE 'SIM' TO WHOUVE-PGTO */
                    _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                    /*" -1006- MOVE 5 TO WS-IND-TAB */
                    _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                    /*" -1007- ELSE */
                }

            }
            else
            {


                /*" -1008- IF WHOUVE-PGTO EQUAL 'NAO' */

                if (AREA_DE_WORK.WHOUVE_PGTO == "NAO")
                {

                    /*" -1009- SUBTRACT 1 FROM WS-IND-TAB */
                    AREA_DE_WORK.WS_IND_TAB.Value = AREA_DE_WORK.WS_IND_TAB - 1;

                    /*" -1010- IF WS-IND-TAB LESS 3 */

                    if (AREA_DE_WORK.WS_IND_TAB < 3)
                    {

                        /*" -1011- MOVE 5 TO WS-IND-TAB */
                        _.Move(5, AREA_DE_WORK.WS_IND_TAB);

                        /*" -1012- MOVE 'SIM' TO WHOUVE-PGTO */
                        _.Move("SIM", AREA_DE_WORK.WHOUVE_PGTO);

                        /*" -1013- ELSE */
                    }
                    else
                    {


                        /*" -1014- IF WS-IND-TAB EQUAL 3 */

                        if (AREA_DE_WORK.WS_IND_TAB == 3)
                        {

                            /*" -1016- MOVE 5 TO WS-IND-TAB. */
                            _.Move(5, AREA_DE_WORK.WS_IND_TAB);
                        }

                    }

                }

            }


            /*" -1018- MOVE V1ENDO-NRENDOS TO V0PEND-NRENDOS. */
            _.Move(V1ENDO_NRENDOS, V0PEND_NRENDOS);

            /*" -1019- IF WS-IND-TAB GREATER 3 */

            if (AREA_DE_WORK.WS_IND_TAB > 3)
            {

                /*" -1022- MOVE 'SIM' TO WCURSOR-FECHADO */
                _.Move("SIM", AREA_DE_WORK.WCURSOR_FECHADO);

                /*" -1023- ACCEPT WS-HORA-INI FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

                /*" -1026- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
                WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

                /*" -1026- PERFORM R0270_00_ACESSA_PARCELA_ANT_DB_CLOSE_1 */

                R0270_00_ACESSA_PARCELA_ANT_DB_CLOSE_1();

                /*" -1031- ACCEPT WS-HORA-FIM FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

                /*" -1032- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
                WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

                /*" -1033- SUBTRACT SIT FROM SFT */
                WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

                /*" -1034- ADD SFT TO STT(14) */
                TOTAIS_ROT.FILLER_17[14].STT.Value = TOTAIS_ROT.FILLER_17[14].STT + WS_HORAS.SFT;

                /*" -1038- ADD 1 TO SQT(14) */
                TOTAIS_ROT.FILLER_17[14].SQT.Value = TOTAIS_ROT.FILLER_17[14].SQT + 1;

                /*" -1039- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -1040- DISPLAY 'R0270 ERRO CLOSE CURSOR V0ENDOSSO  ' SQLCODE */
                    _.Display($"R0270 ERRO CLOSE CURSOR V0ENDOSSO  {DB.SQLCODE}");

                    /*" -1040- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0270-00-ACESSA-PARCELA-ANT-DB-FETCH-1 */
        public void R0270_00_ACESSA_PARCELA_ANT_DB_FETCH_1()
        {
            /*" -990- EXEC SQL FETCH V0ENDOSSO INTO :V1ENDO-NRENDOS, :V1ENDO-SITUACAO, :V1ENDO-DTVENCTO:VIND-DTVENCTO END-EXEC. */

            if (V0ENDOSSO.Fetch())
            {
                _.Move(V0ENDOSSO.V1ENDO_NRENDOS, V1ENDO_NRENDOS);
                _.Move(V0ENDOSSO.V1ENDO_SITUACAO, V1ENDO_SITUACAO);
                _.Move(V0ENDOSSO.V1ENDO_DTVENCTO, V1ENDO_DTVENCTO);
                _.Move(V0ENDOSSO.VIND_DTVENCTO, VIND_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R0270-00-ACESSA-PARCELA-ANT-DB-CLOSE-1 */
        public void R0270_00_ACESSA_PARCELA_ANT_DB_CLOSE_1()
        {
            /*" -1026- EXEC SQL CLOSE V0ENDOSSO END-EXEC */

            V0ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0275-00-VERIFICA-SOLICITACAO-SECTION */
        private void R0275_00_VERIFICA_SOLICITACAO_SECTION()
        {
            /*" -1054- MOVE '275' TO WNR-EXEC-SQL. */
            _.Move("275", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1055- MOVE '0' TO V1REL-SITUACAO. */
            _.Move("0", V1REL_SITUACAO);

            /*" -1056- MOVE 'VE' TO V1REL-IDSISTEM. */
            _.Move("VE", V1REL_IDSISTEM);

            /*" -1059- MOVE 'VE0030B' TO V1REL-CODRELAT. */
            _.Move("VE0030B", V1REL_CODRELAT);

            /*" -1060- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1063- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1072- PERFORM R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1 */

            R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1();

            /*" -1076- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1077- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1078- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1079- ADD SFT TO STT(15) */
            TOTAIS_ROT.FILLER_17[15].STT.Value = TOTAIS_ROT.FILLER_17[15].STT + WS_HORAS.SFT;

            /*" -1083- ADD 1 TO SQT(15) */
            TOTAIS_ROT.FILLER_17[15].SQT.Value = TOTAIS_ROT.FILLER_17[15].SQT + 1;

            /*" -1084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1085- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1086- MOVE 'SIM' TO EXISTE-SOLICITACAO */
                    _.Move("SIM", AREA_DE_WORK.EXISTE_SOLICITACAO);

                    /*" -1087- ELSE */
                }
                else
                {


                    /*" -1088- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1089- MOVE 'NAO' TO EXISTE-SOLICITACAO */
                        _.Move("NAO", AREA_DE_WORK.EXISTE_SOLICITACAO);

                        /*" -1090- ELSE */
                    }
                    else
                    {


                        /*" -1091- DISPLAY 'R0280-00 - PROBLEMAS ACESSO V0RELATORIOS' */
                        _.Display($"R0280-00 - PROBLEMAS ACESSO V0RELATORIOS");

                        /*" -1092- DISPLAY 'APOLICE......  ' V0PEND-NUM-APOL */
                        _.Display($"APOLICE......  {V0PEND_NUM_APOL}");

                        /*" -1093- DISPLAY 'SUBGRUPO.....  ' V0PEND-COD-SUBG */
                        _.Display($"SUBGRUPO.....  {V0PEND_COD_SUBG}");

                        /*" -1094- DISPLAY 'SQLCODE......  ' SQLCODE */
                        _.Display($"SQLCODE......  {DB.SQLCODE}");

                        /*" -1095- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1096- ELSE */
                    }

                }

            }
            else
            {


                /*" -1096- MOVE 'SIM' TO EXISTE-SOLICITACAO. */
                _.Move("SIM", AREA_DE_WORK.EXISTE_SOLICITACAO);
            }


        }

        [StopWatch]
        /*" R0275-00-VERIFICA-SOLICITACAO-DB-SELECT-1 */
        public void R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1()
        {
            /*" -1072- EXEC SQL SELECT SITUACAO INTO :V1REL-SITUACAO FROM SEGUROS.V1RELATORIOS WHERE NUM_APOLICE = :V0PEND-NUM-APOL AND CODSUBES = :V0PEND-COD-SUBG AND CODRELAT = :V1REL-CODRELAT AND IDSISTEM = :V1REL-IDSISTEM AND SITUACAO = :V1REL-SITUACAO END-EXEC. */

            var r0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1 = new R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1()
            {
                V0PEND_NUM_APOL = V0PEND_NUM_APOL.ToString(),
                V0PEND_COD_SUBG = V0PEND_COD_SUBG.ToString(),
                V1REL_CODRELAT = V1REL_CODRELAT.ToString(),
                V1REL_IDSISTEM = V1REL_IDSISTEM.ToString(),
                V1REL_SITUACAO = V1REL_SITUACAO.ToString(),
            };

            var executed_1 = R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1.Execute(r0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1REL_SITUACAO, V1REL_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0275_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-GERA-SOL-CANCELAMENTO-SECTION */
        private void R0280_00_GERA_SOL_CANCELAMENTO_SECTION()
        {
            /*" -1112- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1113- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1116- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1159- PERFORM R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1 */

            R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1();

            /*" -1163- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1164- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1165- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1166- ADD SFT TO STT(16) */
            TOTAIS_ROT.FILLER_17[16].STT.Value = TOTAIS_ROT.FILLER_17[16].STT + WS_HORAS.SFT;

            /*" -1170- ADD 1 TO SQT(16) */
            TOTAIS_ROT.FILLER_17[16].SQT.Value = TOTAIS_ROT.FILLER_17[16].SQT + 1;

            /*" -1171- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1172- IF SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != -803)
                {

                    /*" -1173- DISPLAY 'R0280-00 - PROBLEMAS INSERT V0RELATORIOS.. ' */
                    _.Display($"R0280-00 - PROBLEMAS INSERT V0RELATORIOS.. ");

                    /*" -1174- DISPLAY 'APOLICE......  ' V0PEND-NUM-APOL */
                    _.Display($"APOLICE......  {V0PEND_NUM_APOL}");

                    /*" -1175- DISPLAY 'SUBGRUPO.....  ' V0PEND-COD-SUBG */
                    _.Display($"SUBGRUPO.....  {V0PEND_COD_SUBG}");

                    /*" -1176- DISPLAY 'SQLCODE......  ' SQLCODE */
                    _.Display($"SQLCODE......  {DB.SQLCODE}");

                    /*" -1178- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1178- ADD 1 TO AC-INST-V1RELATOR. */
            AREA_DE_WORK.AC_INST_V1RELATOR.Value = AREA_DE_WORK.AC_INST_V1RELATOR + 1;

        }

        [StopWatch]
        /*" R0280-00-GERA-SOL-CANCELAMENTO-DB-INSERT-1 */
        public void R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1()
        {
            /*" -1159- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VE0029B' , :V1SIST-DTMOVABE, 'VE' , 'VE0030B' , 0, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, 0, 0, 0, 0, 0, 0, 0, 0, :V0PEND-NUM-APOL, 0, 0, 0, 0, :V0PEND-COD-SUBG, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1 = new R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PEND_NUM_APOL = V0PEND_NUM_APOL.ToString(),
                V0PEND_COD_SUBG = V0PEND_COD_SUBG.ToString(),
            };

            R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1.Execute(r0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1191- DISPLAY ' ' */
            _.Display($" ");

            /*" -1192- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1193- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1194- DISPLAY '*   VE0029B - CANCELAMENTO DE ENDOSSOS     *' */
            _.Display($"*   VE0029B - CANCELAMENTO DE ENDOSSOS     *");

            /*" -1195- DISPLAY '*   -------   ------------ -----------     *' */
            _.Display($"*   -------   ------------ -----------     *");

            /*" -1196- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1197- DISPLAY '*          NAO HOUVE SOLICITACAO           *' */
            _.Display($"*          NAO HOUVE SOLICITACAO           *");

            /*" -1198- DISPLAY '*          --- ----- -----------           *' */
            _.Display($"*          --- ----- -----------           *");

            /*" -1198- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -1208- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1208- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -1211- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -1212- IF SII < 17 */

            if (WS_HORAS.SII < 17)
            {

                /*" -1213- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_17[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -1215- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_17[WS_HORAS.SII]}"
                .Display();

                /*" -1216- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1216- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1227- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -1228- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1229- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1231- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1232- DISPLAY ' ' */
            _.Display($" ");

            /*" -1233- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1234- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1235- DISPLAY '*   VE0029B - CANCELAMENTO AUTOMATICO      *' */
            _.Display($"*   VE0029B - CANCELAMENTO AUTOMATICO      *");

            /*" -1236- DISPLAY '*   -------   ------------ ----------      *' */
            _.Display($"*   -------   ------------ ----------      *");

            /*" -1237- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1238- DISPLAY '*      Nao houve parcelas em atraso        *' */
            _.Display($"*      Nao houve parcelas em atraso        *");

            /*" -1239- DISPLAY '*          ate a data informada            *' */
            _.Display($"*          ate a data informada            *");

            /*" -1241- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {AREA_DE_WORK.WDAT_REL_LIT}                   *"
            .Display();

            /*" -1242- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1242- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1254- DISPLAY ' ' */
            _.Display($" ");

            /*" -1255- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1256- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1257- DISPLAY '*       ABEND OCORRIDO NO PGM VE0029B      *' */
            _.Display($"*       ABEND OCORRIDO NO PGM VE0029B      *");

            /*" -1258- DISPLAY '*       -----------------------------      *' */
            _.Display($"*       -----------------------------      *");

            /*" -1259- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1260- DISPLAY '*          NAO EXECUTAR PGM VE0030B        *' */
            _.Display($"*          NAO EXECUTAR PGM VE0030B        *");

            /*" -1261- DISPLAY '*          ------------------------        *' */
            _.Display($"*          ------------------------        *");

            /*" -1262- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1264- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1266- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1268- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1268- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1270- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1274- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1274- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}