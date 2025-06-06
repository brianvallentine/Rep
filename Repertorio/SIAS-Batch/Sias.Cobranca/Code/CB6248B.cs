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
using Sias.Cobranca.DB2.CB6248B;

namespace Code
{
    public class CB6248B
    {
        public bool IsCall { get; set; }

        public CB6248B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB6248B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST                               *      */
        /*"      *   PROGRAMADOR ............  FAST                               *      */
        /*"      *   DATA CODIFICACAO .......  24/09/2010                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONSISTENCIA E CONTROLE DO         *      */
        /*"      *                             MOVIMENTO DE COBRANCA              *      */
        /*"      *                             CONVENIO DE ARRECADACAO - SICAP    *      */
        /*"      *                             CAIXA SEGURADORA - 911334.         *      */
        /*"      *                             SAF LOTERICO - 8105                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                         ALTERACAO                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - DEMANDA 245802                                   *      */
        /*"      *             - PASSA A PROCESSAR O CONVENIO 912090, DE PROPOSTAS*      */
        /*"      *               VENDIDAS NO CAIXA TEM (PRODUTO 3716).            *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/07/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - DEMANDA 247278                                   *      */
        /*"      *             - PASSAR A PROCESSAR O CONVENIO 912086, QUE IRA    *      */
        /*"      *               SUBSTITUIR O CONVENIO 911334.                    *      */
        /*"      *             - A PRINCIPIO OS DOIS CONVENIOS VAO CONVIVER JUNTOS*      */
        /*"      *               MAS O OBJETIVO � QUE O CONVENIO 911334 NAO SEJA  *      */
        /*"      *               MAIS PROCESSADO.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/06/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05   - HISTORIA 181.367                               *      */
        /*"      *               - ALTERAR A APLICACAO PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - LUIZ FERNANDO      PROCURE POR V.05          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACOES:                                                           */
        /*"      * RETIRADA A EXECUCAO DA R6000-00-ATUALIZA-LOTERICO                     */
        /*"      * PROCURAR V.02                                                         */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/05/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOVCC_REGISTRO, _MOVIMENTO); VarBasis.RedefinePassValue(MOVCC_REGISTRO, _MOVIMENTO, MOVCC_REGISTRO); return _MOVIMENTO;
            }
        }
        /*"01        MOVCC-REGISTRO.*/
        public CB6248B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new CB6248B_MOVCC_REGISTRO();
        public class CB6248B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-CTACOBRANCA.*/
            public CB6248B_MOVCC_CTACOBRANCA MOVCC_CTACOBRANCA { get; set; } = new CB6248B_MOVCC_CTACOBRANCA();
            public class CB6248B_MOVCC_CTACOBRANCA : VarBasis
            {
                /*"    10    MOVCC-AGENCIA      PIC  9(004).*/
                public IntBasis MOVCC_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPERACAO     PIC  9(004).*/
                public IntBasis MOVCC_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCTA       PIC  9(012).*/
                public IntBasis MOVCC_NUMCTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCTA       PIC  9(001).*/
                public IntBasis MOVCC_DIGCTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER             PIC  X(004).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      MOVCC-DTPAGTO.*/
            }
            public CB6248B_MOVCC_DTPAGTO MOVCC_DTPAGTO { get; set; } = new CB6248B_MOVCC_DTPAGTO();
            public class CB6248B_MOVCC_DTPAGTO : VarBasis
            {
                /*"    10    MOVCC-ANOPAG       PIC  9(004).*/
                public IntBasis MOVCC_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESPAG       PIC  9(002).*/
                public IntBasis MOVCC_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIAPAG       PIC  9(002).*/
                public IntBasis MOVCC_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public CB6248B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new CB6248B_MOVCC_DTCREDITO();
            public class CB6248B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANOCRE       PIC  9(004).*/
                public IntBasis MOVCC_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESCRE       PIC  9(002).*/
                public IntBasis MOVCC_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIACRE       PIC  9(002).*/
                public IntBasis MOVCC_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-CODBARRA.*/
            }
            public CB6248B_MOVCC_CODBARRA MOVCC_CODBARRA { get; set; } = new CB6248B_MOVCC_CODBARRA();
            public class CB6248B_MOVCC_CODBARRA : VarBasis
            {
                /*"    10    MOVCC-BARRA01      PIC  X(016).*/
                public StringBasis MOVCC_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    10    MOVCC-BANCO        PIC  9(003).*/
                public IntBasis MOVCC_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    MOVCC-BARRA02      PIC  X(004).*/
                public StringBasis MOVCC_BARRA02 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10    MOVCC-NUMSIVPF     PIC  9(014).*/
                public IntBasis MOVCC_NUMSIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10    MOVCC-BARRA03      PIC  X(007).*/
                public StringBasis MOVCC_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"  05      MOVCC-VLRPAGO      PIC  9(010)V99.*/
            }
            public DoubleBasis MOVCC_VLRPAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      MOVCC-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis MOVCC_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      MOVCC-NRSEQREG     PIC  9(008).*/
            public IntBasis MOVCC_NRSEQREG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-PTOVENDA     PIC  9(004).*/
            public IntBasis MOVCC_PTOVENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER             PIC  X(004).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      MOVCC-ANEXO1       PIC  X(001).*/
            public StringBasis MOVCC_ANEXO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-ANEXO2       PIC  X(023).*/
            public StringBasis MOVCC_ANEXO2 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"  05  FILLER            REDEFINES   MOVCC-ANEXO2.*/
            private _REDEF_CB6248B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_CB6248B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_CB6248B_FILLER_2(); _.Move(MOVCC_ANEXO2, _filler_2); VarBasis.RedefinePassValue(MOVCC_ANEXO2, _filler_2, MOVCC_ANEXO2); _filler_2.ValueChanged += () => { _.Move(_filler_2, MOVCC_ANEXO2); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, MOVCC_ANEXO2); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_2 : VarBasis
            {
                /*"      10  MOVCC-NUM-LOTER    PIC  9(008).*/
                public IntBasis MOVCC_NUM_LOTER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10  FILLER             PIC  X(015).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05      MOVCC-FORMAPAG     PIC  9(001).*/

                public _REDEF_CB6248B_FILLER_2()
                {
                    MOVCC_NUM_LOTER.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis MOVCC_FORMAPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER             PIC  X(004).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NUMSIV01           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-NUMSIV02           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV02 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-COUNT              PIC S9(009)     COMP VALUE +0.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01        HEADER-REGISTRO.*/
        public CB6248B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new CB6248B_HEADER_REGISTRO();
        public class CB6248B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  9(006).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(014).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public CB6248B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new CB6248B_HEADER_DATGERACAO();
            public class CB6248B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO          PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSA          PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER              PIC  X(069).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public CB6248B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new CB6248B_TRAILL_REGISTRO();
        public class CB6248B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTPAG    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTPAG { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER              PIC  X(126).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public CB6248B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB6248B_AREA_DE_WORK();
        public class CB6248B_AREA_DE_WORK : VarBasis
        {
            /*"  03         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-ENTRADA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-HEADER         PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-TRAILLER       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_TRAILLER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-DETALHE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_DETALHE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-ENTRADA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         NT-BILHETE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-MOVIMCOB       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-CONVERSI       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_CONVERSI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WS-RESULT         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         WS-RESTO          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WPARM13-AUX       PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM13_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03         WPARM11-AUX       PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM11_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03    WWORK-CODBARRA.*/
            public CB6248B_WWORK_CODBARRA WWORK_CODBARRA { get; set; } = new CB6248B_WWORK_CODBARRA();
            public class CB6248B_WWORK_CODBARRA : VarBasis
            {
                /*"        05 WWORK-PART01        PIC X(023).*/
                public StringBasis WWORK_PART01 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"        05 WWORK-PROPOSTA      PIC 9(014).*/
                public IntBasis WWORK_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"        05 WWORK-PART02        PIC X(007).*/
                public StringBasis WWORK_PART02 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB6248B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_CB6248B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_CB6248B_FILLER_8(); _.Move(WDATA_REL, _filler_8); VarBasis.RedefinePassValue(WDATA_REL, _filler_8, WDATA_REL); _filler_8.ValueChanged += () => { _.Move(_filler_8, WDATA_REL); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_8 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-NRAVISO        PIC  9(009)    VALUE  ZEROS.*/

                public _REDEF_CB6248B_FILLER_8()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      WS-NRAVISO.*/
            private _REDEF_CB6248B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_CB6248B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_CB6248B_FILLER_11(); _.Move(WS_NRAVISO, _filler_11); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_11, WS_NRAVISO); _filler_11.ValueChanged += () => { _.Move(_filler_11, WS_NRAVISO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_11 : VarBasis
            {
                /*"      10     WS-AUXAVISO       PIC  9(004).*/
                public IntBasis WS_AUXAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-AUXNSAS        PIC  9(005).*/
                public IntBasis WS_AUXNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WS-NRTIT          PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_CB6248B_FILLER_11()
                {
                    WS_AUXAVISO.ValueChanged += OnValueChanged;
                    WS_AUXNSAS.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER            REDEFINES      WS-NRTIT.*/
            private _REDEF_CB6248B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_CB6248B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_CB6248B_FILLER_12(); _.Move(WS_NRTIT, _filler_12); VarBasis.RedefinePassValue(WS_NRTIT, _filler_12, WS_NRTIT); _filler_12.ValueChanged += () => { _.Move(_filler_12, WS_NRTIT); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_12 : VarBasis
            {
                /*"      10     WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10     WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MIN-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_CB6248B_FILLER_12()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_CB6248B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_CB6248B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_CB6248B_FILLER_13(); _.Move(WWORK_MIN_NRTIT, _filler_13); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_13, WWORK_MIN_NRTIT); _filler_13.ValueChanged += () => { _.Move(_filler_13, WWORK_MIN_NRTIT); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_13 : VarBasis
            {
                /*"    10       WWORK-MINNRO      PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MINDIG      PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MAX-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_CB6248B_FILLER_13()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_CB6248B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_CB6248B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_CB6248B_FILLER_14(); _.Move(WWORK_MAX_NRTIT, _filler_14); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_14, WWORK_MAX_NRTIT); _filler_14.ValueChanged += () => { _.Move(_filler_14, WWORK_MAX_NRTIT); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_14 : VarBasis
            {
                /*"    10       WWORK-MAXNRO      PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MAXDIG      PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03        WABEND.*/

                public _REDEF_CB6248B_FILLER_14()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public CB6248B_WABEND WABEND { get; set; } = new CB6248B_WABEND();
            public class CB6248B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' CB6248B'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB6248B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03        WSQLERR.*/
            }
            public CB6248B_WSQLERR WSQLERR { get; set; } = new CB6248B_WSQLERR();
            public class CB6248B_WSQLERR : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01             LPARM11X.*/
            }
        }
        public CB6248B_LPARM11X LPARM11X { get; set; } = new CB6248B_LPARM11X();
        public class CB6248B_LPARM11X : VarBasis
        {
            /*"  03           LPARM11            PIC  9(010).*/
            public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03           FILLER             REDEFINES   LPARM11.*/
            private _REDEF_CB6248B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_CB6248B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_CB6248B_FILLER_21(); _.Move(LPARM11, _filler_21); VarBasis.RedefinePassValue(LPARM11, _filler_21, LPARM11); _filler_21.ValueChanged += () => { _.Move(_filler_21, LPARM11); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, LPARM11); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_21 : VarBasis
            {
                /*"    05         LPARM11-1          PIC  9(001).*/
                public IntBasis LPARM11_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-2          PIC  9(001).*/
                public IntBasis LPARM11_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-3          PIC  9(001).*/
                public IntBasis LPARM11_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-4          PIC  9(001).*/
                public IntBasis LPARM11_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-5          PIC  9(001).*/
                public IntBasis LPARM11_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-6          PIC  9(001).*/
                public IntBasis LPARM11_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-7          PIC  9(001).*/
                public IntBasis LPARM11_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-8          PIC  9(001).*/
                public IntBasis LPARM11_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-9          PIC  9(001).*/
                public IntBasis LPARM11_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-10         PIC  9(001).*/
                public IntBasis LPARM11_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01             LPARM13X.*/

                public _REDEF_CB6248B_FILLER_21()
                {
                    LPARM11_1.ValueChanged += OnValueChanged;
                    LPARM11_2.ValueChanged += OnValueChanged;
                    LPARM11_3.ValueChanged += OnValueChanged;
                    LPARM11_4.ValueChanged += OnValueChanged;
                    LPARM11_5.ValueChanged += OnValueChanged;
                    LPARM11_6.ValueChanged += OnValueChanged;
                    LPARM11_7.ValueChanged += OnValueChanged;
                    LPARM11_8.ValueChanged += OnValueChanged;
                    LPARM11_9.ValueChanged += OnValueChanged;
                    LPARM11_10.ValueChanged += OnValueChanged;
                }

            }
        }
        public CB6248B_LPARM13X LPARM13X { get; set; } = new CB6248B_LPARM13X();
        public class CB6248B_LPARM13X : VarBasis
        {
            /*"  03           LPARM13            PIC  9(013).*/
            public IntBasis LPARM13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  03           FILLER             REDEFINES   LPARM13.*/
            private _REDEF_CB6248B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_CB6248B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_CB6248B_FILLER_22(); _.Move(LPARM13, _filler_22); VarBasis.RedefinePassValue(LPARM13, _filler_22, LPARM13); _filler_22.ValueChanged += () => { _.Move(_filler_22, LPARM13); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, LPARM13); }
            }  //Redefines
            public class _REDEF_CB6248B_FILLER_22 : VarBasis
            {
                /*"    05         LPARM13-1          PIC  9(001).*/
                public IntBasis LPARM13_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-2          PIC  9(001).*/
                public IntBasis LPARM13_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-3          PIC  9(001).*/
                public IntBasis LPARM13_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-4          PIC  9(001).*/
                public IntBasis LPARM13_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-5          PIC  9(001).*/
                public IntBasis LPARM13_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-6          PIC  9(001).*/
                public IntBasis LPARM13_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-7          PIC  9(001).*/
                public IntBasis LPARM13_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-8          PIC  9(001).*/
                public IntBasis LPARM13_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-9          PIC  9(001).*/
                public IntBasis LPARM13_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-10         PIC  9(001).*/
                public IntBasis LPARM13_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-11         PIC  9(001).*/
                public IntBasis LPARM13_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-12         PIC  9(001).*/
                public IntBasis LPARM13_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-13         PIC  9(001).*/
                public IntBasis LPARM13_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));

                public _REDEF_CB6248B_FILLER_22()
                {
                    LPARM13_1.ValueChanged += OnValueChanged;
                    LPARM13_2.ValueChanged += OnValueChanged;
                    LPARM13_3.ValueChanged += OnValueChanged;
                    LPARM13_4.ValueChanged += OnValueChanged;
                    LPARM13_5.ValueChanged += OnValueChanged;
                    LPARM13_6.ValueChanged += OnValueChanged;
                    LPARM13_7.ValueChanged += OnValueChanged;
                    LPARM13_8.ValueChanged += OnValueChanged;
                    LPARM13_9.ValueChanged += OnValueChanged;
                    LPARM13_10.ValueChanged += OnValueChanged;
                    LPARM13_11.ValueChanged += OnValueChanged;
                    LPARM13_12.ValueChanged += OnValueChanged;
                    LPARM13_13.ValueChanged += OnValueChanged;
                }

            }
        }


        public Copies.JVBKINCL JVBKINCL { get; set; } = new Copies.JVBKINCL();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);

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
            /*" -319- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -322- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -325- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -328- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -329- DISPLAY 'PROGRAMA EM EXECUCAO CB6248B  ' */
            _.Display($"PROGRAMA EM EXECUCAO CB6248B  ");

            /*" -330- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -331- DISPLAY 'VERSAO V.07 245802 - 27/07/2020 ' */
            _.Display($"VERSAO V.07 245802 - 27/07/2020 ");

            /*" -332- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -334- DISPLAY ' ' . */
            _.Display($" ");

            /*" -337- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -337- PERFORM R0300-00-SELECIONA. */

            R0300_00_SELECIONA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -342- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -347- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -350- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -350- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -363- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -366- OPEN INPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVCC_REGISTRO);

            /*" -366- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -380- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -386- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -390- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -391- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -394- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -398- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL);

            /*" -400- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -400- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -386- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECIONA-SECTION */
        private void R0300_00_SELECIONA_SECTION()
        {
            /*" -413- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -414- DISPLAY ' CONVENIOS 912086/912090 (C.E.F. -SICAP) - RETORNO' */
            _.Display($" CONVENIOS 912086/912090 (C.E.F. -SICAP) - RETORNO");

            /*" -417- DISPLAY ' ' . */
            _.Display($" ");

            /*" -419- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -421- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

            /*" -422- PERFORM R0320-00-PROCESSA-ENTRADA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0320_00_PROCESSA_ENTRADA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-LER-ENTRADA-SECTION */
        private void R0310_00_LER_ENTRADA_SECTION()
        {
            /*" -435- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -435- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -437- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -440- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, MOVCC_REGISTRO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -440- ADD 1 TO LD-ENTRADA. */
            AREA_DE_WORK.LD_ENTRADA.Value = AREA_DE_WORK.LD_ENTRADA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-ENTRADA-SECTION */
        private void R0320_00_PROCESSA_ENTRADA_SECTION()
        {
            /*" -453- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -454- IF MOVCC-CODREGISTRO EQUAL 'A' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO == "A")
            {

                /*" -455- ADD 1 TO LD-HEADER */
                AREA_DE_WORK.LD_HEADER.Value = AREA_DE_WORK.LD_HEADER + 1;

                /*" -456- MOVE MOVCC-REGISTRO TO HEADER-REGISTRO */
                _.Move(MOVIMENTO?.Value, HEADER_REGISTRO);

                /*" -457- PERFORM R0330-00-TRATA-HEADER */

                R0330_00_TRATA_HEADER_SECTION();

                /*" -460- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -461- IF MOVCC-CODREGISTRO EQUAL 'Z' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO == "Z")
            {

                /*" -462- ADD 1 TO LD-TRAILLER */
                AREA_DE_WORK.LD_TRAILLER.Value = AREA_DE_WORK.LD_TRAILLER + 1;

                /*" -463- MOVE MOVCC-REGISTRO TO TRAILL-REGISTRO */
                _.Move(MOVIMENTO?.Value, TRAILL_REGISTRO);

                /*" -464- PERFORM R0350-00-TRATA-TRAILLER */

                R0350_00_TRATA_TRAILLER_SECTION();

                /*" -467- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -468- IF MOVCC-CODREGISTRO NOT EQUAL 'G' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO != "G")
            {

                /*" -470- DISPLAY 'DESPREZA  CODREGISTRO    ' MOVCC-REGISTRO */
                _.Display($"DESPREZA  CODREGISTRO    {MOVCC_REGISTRO}");

                /*" -471- ADD 1 TO DP-ENTRADA */
                AREA_DE_WORK.DP_ENTRADA.Value = AREA_DE_WORK.DP_ENTRADA + 1;

                /*" -474- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -474- PERFORM R0400-00-PROCESSA-DETALHE. */

            R0400_00_PROCESSA_DETALHE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_50_LEITURA */

            R0320_50_LEITURA();

        }

        [StopWatch]
        /*" R0320-50-LEITURA */
        private void R0320_50_LEITURA(bool isPerform = false)
        {
            /*" -479- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-TRATA-HEADER-SECTION */
        private void R0330_00_TRATA_HEADER_SECTION()
        {
            /*" -491- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -494- IF HEADER-CODCONVENIO NOT EQUAL 912090 AND CVPCV-911334 AND JV1CV-911334 */

            if (!HEADER_REGISTRO.HEADER_CODCONVENIO.In("912090", JVBKINCL.JV_CONVENIOS.CVPCV_911334.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_911334.ToString()))
            {

                /*" -496- DISPLAY 'R0330-00 - CONVENIO NAO PREVISTO         ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CONVENIO NAO PREVISTO         {HEADER_REGISTRO}");

                /*" -499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -500- IF HEADER-CODREMESSA NOT EQUAL 2 */

            if (HEADER_REGISTRO.HEADER_CODREMESSA != 2)
            {

                /*" -502- DISPLAY 'R0330-00 - CODIGO REMESSA INVALIDO       ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CODIGO REMESSA INVALIDO       {HEADER_REGISTRO}");

                /*" -505- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -506- IF HEADER-CODBANCO NOT EQUAL 104 */

            if (HEADER_REGISTRO.HEADER_CODBANCO != 104)
            {

                /*" -508- DISPLAY 'R0330-00 - CODIGO BANCO   INVALIDO       ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CODIGO BANCO   INVALIDO       {HEADER_REGISTRO}");

                /*" -514- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -515- MOVE ZEROS TO WS-NRAVISO. */
            _.Move(0, AREA_DE_WORK.WS_NRAVISO);

            /*" -517- MOVE HEADER-NSA TO WS-AUXNSAS. */
            _.Move(HEADER_REGISTRO.HEADER_NSA, AREA_DE_WORK.FILLER_11.WS_AUXNSAS);

            /*" -518-  EVALUATE HEADER-CODCONVENIO  */

            /*" -519-  WHEN CVPCV-911334  */

            /*" -519- IF   HEADER-CODCONVENIO EQUALS  CVPCV-911334 */

            if (HEADER_REGISTRO.HEADER_CODCONVENIO == JVBKINCL.JV_CONVENIOS.CVPCV_911334)
            {

                /*" -520- MOVE 9086 TO WS-AUXAVISO */
                _.Move(9086, AREA_DE_WORK.FILLER_11.WS_AUXAVISO);

                /*" -521-  WHEN 912090  */

                /*" -521- ELSE IF   HEADER-CODCONVENIO EQUALS  912090 */
            }
            else

            if (HEADER_REGISTRO.HEADER_CODCONVENIO == 912090)
            {

                /*" -522- MOVE 9090 TO WS-AUXAVISO */
                _.Move(9090, AREA_DE_WORK.FILLER_11.WS_AUXAVISO);

                /*" -523-  WHEN OTHER  */

                /*" -523- ELSE */
            }
            else
            {


                /*" -524- MOVE 9334 TO WS-AUXAVISO */
                _.Move(9334, AREA_DE_WORK.FILLER_11.WS_AUXAVISO);

                /*" -527-  END-EVALUATE.  */

                /*" -527- END-IF. */
            }


            /*" -528- DISPLAY ' SEQUENCIA ARQUIVO .... ' HEADER-NSA. */
            _.Display($" SEQUENCIA ARQUIVO .... {HEADER_REGISTRO.HEADER_NSA}");

            /*" -531- DISPLAY ' CONVENIO ............. ' HEADER-CODCONVENIO. */
            _.Display($" CONVENIO ............. {HEADER_REGISTRO.HEADER_CODCONVENIO}");

            /*" -533- PERFORM R0340-00-SELECT-MOVIMCOB. */

            R0340_00_SELECT_MOVIMCOB_SECTION();

            /*" -534- IF WSHOST-COUNT NOT EQUAL ZEROS */

            if (WSHOST_COUNT != 00)
            {

                /*" -535- DISPLAY ' SEQUENCIA DE ARQUIVO JA PROCESSADO      ' */
                _.Display($" SEQUENCIA DE ARQUIVO JA PROCESSADO      ");

                /*" -535- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-SELECT-MOVIMCOB-SECTION */
        private void R0340_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -548- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -550- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -552- MOVE 8010 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(8010, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -555- MOVE WS-NRAVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(AREA_DE_WORK.WS_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -566- PERFORM R0340_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0340_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -570- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -572- MOVE ZEROS TO WSHOST-COUNT */
                _.Move(0, WSHOST_COUNT);

                /*" -573- ELSE */
            }
            else
            {


                /*" -574- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -576- MOVE 1 TO WSHOST-COUNT */
                    _.Move(1, WSHOST_COUNT);

                    /*" -577- ELSE */
                }
                else
                {


                    /*" -578- IF VIND-NULL02 LESS ZEROS */

                    if (VIND_NULL02 < 00)
                    {

                        /*" -581- MOVE ZEROS TO WSHOST-COUNT. */
                        _.Move(0, WSHOST_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0340-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0340_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -566- EXEC SQL SELECT COUNT(*) INTO :WSHOST-COUNT:VIND-NULL02 FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO WITH UR END-EXEC. */

            var r0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            var executed_1 = R0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r0340_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_COUNT, WSHOST_COUNT);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-TRATA-TRAILLER-SECTION */
        private void R0350_00_TRATA_TRAILLER_SECTION()
        {
            /*" -592- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -593- DISPLAY ' ' . */
            _.Display($" ");

            /*" -594- DISPLAY ' LIDOS    ENTRADA ...... ' LD-ENTRADA. */
            _.Display($" LIDOS    ENTRADA ...... {AREA_DE_WORK.LD_ENTRADA}");

            /*" -595- DISPLAY ' LIDOS    HEADER ....... ' LD-HEADER. */
            _.Display($" LIDOS    HEADER ....... {AREA_DE_WORK.LD_HEADER}");

            /*" -596- DISPLAY ' LIDOS    TRAILLER ..... ' LD-TRAILLER. */
            _.Display($" LIDOS    TRAILLER ..... {AREA_DE_WORK.LD_TRAILLER}");

            /*" -597- DISPLAY ' DESPREZA ENTRADA ...... ' DP-ENTRADA. */
            _.Display($" DESPREZA ENTRADA ...... {AREA_DE_WORK.DP_ENTRADA}");

            /*" -598- DISPLAY ' ' . */
            _.Display($" ");

            /*" -599- DISPLAY ' LIDOS DETALHE ......... ' LD-DETALHE. */
            _.Display($" LIDOS DETALHE ......... {AREA_DE_WORK.LD_DETALHE}");

            /*" -600- DISPLAY ' BILHETE NAO CADASTRADO. ' NT-BILHETE. */
            _.Display($" BILHETE NAO CADASTRADO. {AREA_DE_WORK.NT_BILHETE}");

            /*" -601- DISPLAY ' CADASTRA CONVERSAO .... ' AC-CONVERSI. */
            _.Display($" CADASTRA CONVERSAO .... {AREA_DE_WORK.AC_CONVERSI}");

            /*" -602- DISPLAY ' ' . */
            _.Display($" ");

            /*" -603- DISPLAY ' CADASTRADOS MOVIMENTO . ' AC-MOVIMCOB. */
            _.Display($" CADASTRADOS MOVIMENTO . {AREA_DE_WORK.AC_MOVIMCOB}");

            /*" -606- DISPLAY ' ' . */
            _.Display($" ");

            /*" -614- MOVE ZEROS TO LD-ENTRADA LD-HEADER LD-TRAILLER LD-DETALHE DP-ENTRADA NT-BILHETE AC-CONVERSI AC-MOVIMCOB. */
            _.Move(0, AREA_DE_WORK.LD_ENTRADA, AREA_DE_WORK.LD_HEADER, AREA_DE_WORK.LD_TRAILLER, AREA_DE_WORK.LD_DETALHE, AREA_DE_WORK.DP_ENTRADA, AREA_DE_WORK.NT_BILHETE, AREA_DE_WORK.AC_CONVERSI, AREA_DE_WORK.AC_MOVIMCOB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-DETALHE-SECTION */
        private void R0400_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -628- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -631- ADD 1 TO LD-DETALHE. */
            AREA_DE_WORK.LD_DETALHE.Value = AREA_DE_WORK.LD_DETALHE + 1;

            /*" -637- PERFORM R0410-00-MONTA-MOVIMCOB. */

            R0410_00_MONTA_MOVIMCOB_SECTION();

            /*" -643- PERFORM R0420-00-SELECT-CONVERSI. */

            R0420_00_SELECT_CONVERSI_SECTION();

            /*" -649- PERFORM R0450-00-SELECT-MOVIMCOB. */

            R0450_00_SELECT_MOVIMCOB_SECTION();

            /*" -650- IF MOVIMCOB-SIT-REGISTRO NOT EQUAL SPACES */

            if (!MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.IsEmpty())
            {

                /*" -652- DISPLAY ' REGISTRO JA CADASTRADO MOVIMCOB         ' MOVCC-REGISTRO */
                _.Display($" REGISTRO JA CADASTRADO MOVIMCOB         {MOVCC_REGISTRO}");

                /*" -657- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


            /*" -657- PERFORM R4000-00-INSERT-MOVIMCOB. */

            R4000_00_INSERT_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-MONTA-MOVIMCOB-SECTION */
        private void R0410_00_MONTA_MOVIMCOB_SECTION()
        {
            /*" -672- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -674- MOVE ZEROS TO MOVIMCOB-COD-EMPRESA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -676- MOVE MOVCC-NRSEQREG TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(MOVCC_REGISTRO.MOVCC_NRSEQREG, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -678- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -680- MOVE 8010 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(8010, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -682- MOVE WS-NRAVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(AREA_DE_WORK.WS_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -684- MOVE WS-AUXNSAS TO MOVIMCOB-NUM-FITA. */
            _.Move(AREA_DE_WORK.FILLER_11.WS_AUXNSAS, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -686- MOVE ZEROS TO MOVIMCOB-VAL-IOCC. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

            /*" -688- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -691- MOVE 'L' TO MOVIMCOB-TIPO-MOVIMENTO. */
            _.Move("L", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

            /*" -693- MOVE MOVCC-VLRPAGO TO MOVIMCOB-VAL-TITULO. */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRPAGO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -696- MOVE MOVCC-VLRTARIFA TO MOVIMCOB-VAL-CREDITO. */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRTARIFA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -700- COMPUTE MOVIMCOB-VAL-CREDITO EQUAL (MOVIMCOB-VAL-TITULO - MOVIMCOB-VAL-CREDITO). */
            MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.Value = (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO - MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -701- MOVE MOVCC-ANOCRE TO WDAT-REL-ANO */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANOCRE, AREA_DE_WORK.FILLER_8.WDAT_REL_ANO);

            /*" -702- MOVE MOVCC-MESCRE TO WDAT-REL-MES */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MESCRE, AREA_DE_WORK.FILLER_8.WDAT_REL_MES);

            /*" -703- MOVE MOVCC-DIACRE TO WDAT-REL-DIA */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIACRE, AREA_DE_WORK.FILLER_8.WDAT_REL_DIA);

            /*" -706- MOVE WDATA-REL TO MOVIMCOB-DATA-MOVIMENTO. */
            _.Move(AREA_DE_WORK.WDATA_REL, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -707- MOVE MOVCC-ANOPAG TO WDAT-REL-ANO */
            _.Move(MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_ANOPAG, AREA_DE_WORK.FILLER_8.WDAT_REL_ANO);

            /*" -708- MOVE MOVCC-MESPAG TO WDAT-REL-MES */
            _.Move(MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_MESPAG, AREA_DE_WORK.FILLER_8.WDAT_REL_MES);

            /*" -709- MOVE MOVCC-DIAPAG TO WDAT-REL-DIA */
            _.Move(MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_DIAPAG, AREA_DE_WORK.FILLER_8.WDAT_REL_DIA);

            /*" -712- MOVE WDATA-REL TO MOVIMCOB-DATA-QUITACAO. */
            _.Move(AREA_DE_WORK.WDATA_REL, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

            /*" -715- MOVE MOVCC-NUMSIVPF TO MOVIMCOB-NUM-APOLICE. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUMSIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -721- MOVE ZEROS TO MOVIMCOB-NUM-TITULO MOVIMCOB-NUM-ENDOSSO MOVIMCOB-NUM-PARCELA MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -724- MOVE SPACES TO MOVIMCOB-NOME-SEGURADO. */
            _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -725- MOVE MOVCC-BARRA01 TO MOVIMCOB-NOME-SEGURADO. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_BARRA01, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-CONVERSI-SECTION */
        private void R0420_00_SELECT_CONVERSI_SECTION()
        {
            /*" -745- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -749- MOVE MOVCC-NUMSIVPF TO CONVERSI-NUM-PROPOSTA-SIVPF */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUMSIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -767- PERFORM R0420_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0420_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -771- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -772- PERFORM R0430-00-SELECT-BILHETE */

                R0430_00_SELECT_BILHETE_SECTION();

                /*" -774- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -776- MOVE BILHETE-NUM-BILHETE TO MOVIMCOB-NUM-TITULO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -778- MOVE BILHETE-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -779- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

        }

        [StopWatch]
        /*" R0420-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0420_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -767- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , B.NUM_BILHETE , B.NUM_APOLICE INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE FROM SEGUROS.CONVERSAO_SICOB A , SEGUROS.BILHETE B WHERE A.NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF AND A.NUM_SICOB = B.NUM_BILHETE WITH UR END-EXEC. */

            var r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-SELECT-BILHETE-SECTION */
        private void R0430_00_SELECT_BILHETE_SECTION()
        {
            /*" -792- MOVE '0430' TO WNR-EXEC-SQL. */
            _.Move("0430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -865- PERFORM R0430_00_SELECT_BILHETE_DB_SELECT_1 */

            R0430_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -869- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -870- PERFORM R0440-00-CALCULA-PROPOSTA */

                R0440_00_CALCULA_PROPOSTA_SECTION();

                /*" -873- GO TO R0430-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/ //GOTO
                return;
            }


            /*" -873- PERFORM R0500-00-TRATA-PROPOSTA. */

            R0500_00_TRATA_PROPOSTA_SECTION();

        }

        [StopWatch]
        /*" R0430-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0430_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -865- EXEC SQL SELECT NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM INTO :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-FONTE , :BILHETE-AGE-COBRANCA , :BILHETE-NUM-MATRICULA , :BILHETE-COD-AGENCIA , :BILHETE-OPERACAO-CONTA , :BILHETE-NUM-CONTA , :BILHETE-DIG-CONTA , :BILHETE-COD-CLIENTE , :BILHETE-PROFISSAO , :BILHETE-IDE-SEXO , :BILHETE-ESTADO-CIVIL , :BILHETE-OCORR-ENDERECO , :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB , :BILHETE-OPC-COBERTURA , :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-RAMO , :BILHETE-DATA-VENDA , :BILHETE-DATA-MOVIMENTO , :BILHETE-NUM-APOL-ANTERIOR , :BILHETE-SITUACAO , :BILHETE-TIP-CANCELAMENTO , :BILHETE-SIT-SINISTRO , :BILHETE-COD-USUARIO , :BILHETE-TIMESTAMP , :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 , :BILHETE-BI-FAIXA-RENDA-IND , :BILHETE-BI-FAIXA-RENDA-FAM FROM SEGUROS.BILHETE WHERE NUM_BILHETE >= :WSHOST-NUMSIV01 AND NUM_BILHETE <= :WSHOST-NUMSIV02 WITH UR END-EXEC. */

            var r0430_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0430_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(executed_1.BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(executed_1.BILHETE_NUM_MATRICULA, BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA);
                _.Move(executed_1.BILHETE_COD_AGENCIA, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA);
                _.Move(executed_1.BILHETE_NUM_CONTA, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA);
                _.Move(executed_1.BILHETE_DIG_CONTA, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);
                _.Move(executed_1.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(executed_1.BILHETE_PROFISSAO, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);
                _.Move(executed_1.BILHETE_IDE_SEXO, BILHETE.DCLBILHETE.BILHETE_IDE_SEXO);
                _.Move(executed_1.BILHETE_ESTADO_CIVIL, BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL);
                _.Move(executed_1.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(executed_1.BILHETE_COD_AGENCIA_DEB, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB);
                _.Move(executed_1.BILHETE_NUM_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB);
                _.Move(executed_1.BILHETE_DIG_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB);
                _.Move(executed_1.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(executed_1.BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(executed_1.BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(executed_1.BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(executed_1.BILHETE_SIT_SINISTRO, BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO);
                _.Move(executed_1.BILHETE_COD_USUARIO, BILHETE.DCLBILHETE.BILHETE_COD_USUARIO);
                _.Move(executed_1.BILHETE_TIMESTAMP, BILHETE.DCLBILHETE.BILHETE_TIMESTAMP);
                _.Move(executed_1.BILHETE_DATA_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.BILHETE_BI_FAIXA_RENDA_IND, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);
                _.Move(executed_1.BILHETE_BI_FAIXA_RENDA_FAM, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-CALCULA-PROPOSTA-SECTION */
        private void R0440_00_CALCULA_PROPOSTA_SECTION()
        {
            /*" -917- MOVE '0440' TO WNR-EXEC-SQL. */
            _.Move("0440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -921- MOVE MOVCC-NUMSIVPF TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUMSIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -921- ADD 1 TO NT-BILHETE. */
            AREA_DE_WORK.NT_BILHETE.Value = AREA_DE_WORK.NT_BILHETE + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-MOVIMCOB-SECTION */
        private void R0450_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -934- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -955- PERFORM R0450_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0450_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -959- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -961- MOVE '*' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("*", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -962- ELSE */
            }
            else
            {


                /*" -963- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0450_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -955- EXEC SQL SELECT SIT_REGISTRO INTO :MOVIMCOB-SIT-REGISTRO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO AND NUM_TITULO = :MOVIMCOB-NUM-TITULO AND NUM_APOLICE = :MOVIMCOB-NUM-APOLICE AND NUM_ENDOSSO = :MOVIMCOB-NUM-ENDOSSO AND NUM_PARCELA = :MOVIMCOB-NUM-PARCELA AND NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO WITH UR END-EXEC. */

            var r0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            var executed_1 = R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-TRATA-PROPOSTA-SECTION */
        private void R0500_00_TRATA_PROPOSTA_SECTION()
        {
            /*" -976- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -979- PERFORM R0510-00-SELECT-V0CEDENTE. */

            R0510_00_SELECT_V0CEDENTE_SECTION();

            /*" -982- PERFORM R0530-00-CALCULA-TITULO. */

            R0530_00_CALCULA_TITULO_SECTION();

            /*" -985- PERFORM R0550-00-UPDATE-V0CEDENTE. */

            R0550_00_UPDATE_V0CEDENTE_SECTION();

            /*" -988- PERFORM R1000-00-DELETE-BILHETE. */

            R1000_00_DELETE_BILHETE_SECTION();

            /*" -991- PERFORM R1100-00-INSERT-CONVERSI. */

            R1100_00_INSERT_CONVERSI_SECTION();

            /*" -994- PERFORM R1200-00-INSERT-BILHETE. */

            R1200_00_INSERT_BILHETE_SECTION();

            /*" -996- MOVE BILHETE-NUM-BILHETE TO MOVIMCOB-NUM-TITULO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -998- MOVE BILHETE-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -1002- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1002- ADD 1 TO AC-CONVERSI. */
            AREA_DE_WORK.AC_CONVERSI.Value = AREA_DE_WORK.AC_CONVERSI + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-SELECT-V0CEDENTE-SECTION */
        private void R0510_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -1015- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1022- PERFORM R0510_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0510_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -1026- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1027- DISPLAY 'R0510-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($"R0510-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -1030- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1032- MOVE CEDENTE-NUM-TITULO TO WWORK-MIN-NRTIT. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, AREA_DE_WORK.WWORK_MIN_NRTIT);

            /*" -1033- MOVE CEDENTE-NUM-TITULO-MAX TO WWORK-MAX-NRTIT. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX, AREA_DE_WORK.WWORK_MAX_NRTIT);

        }

        [StopWatch]
        /*" R0510-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0510_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -1022- EXEC SQL SELECT NUM_TITULO , NUM_TITULO_MAX INTO :CEDENTE-NUM-TITULO , :CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 26 END-EXEC. */

            var r0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
                _.Move(executed_1.CEDENTE_NUM_TITULO_MAX, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-CALCULA-TITULO-SECTION */
        private void R0530_00_CALCULA_TITULO_SECTION()
        {
            /*" -1046- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1047- ADD 1 TO WWORK-MINNRO */
            AREA_DE_WORK.FILLER_13.WWORK_MINNRO.Value = AREA_DE_WORK.FILLER_13.WWORK_MINNRO + 1;

            /*" -1050- MOVE WWORK-MINNRO TO LPARM11. */
            _.Move(AREA_DE_WORK.FILLER_13.WWORK_MINNRO, LPARM11X.LPARM11);

            /*" -1061- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            AREA_DE_WORK.WPARM11_AUX.Value = LPARM11X.FILLER_21.LPARM11_1 * 3 + LPARM11X.FILLER_21.LPARM11_2 * 2 + LPARM11X.FILLER_21.LPARM11_3 * 9 + LPARM11X.FILLER_21.LPARM11_4 * 8 + LPARM11X.FILLER_21.LPARM11_5 * 7 + LPARM11X.FILLER_21.LPARM11_6 * 6 + LPARM11X.FILLER_21.LPARM11_7 * 5 + LPARM11X.FILLER_21.LPARM11_8 * 4 + LPARM11X.FILLER_21.LPARM11_9 * 3 + LPARM11X.FILLER_21.LPARM11_10 * 2;

            /*" -1064- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(AREA_DE_WORK.WPARM11_AUX, 11, AREA_DE_WORK.WS_RESULT, AREA_DE_WORK.WS_RESTO);

            /*" -1065- IF WS-RESTO EQUAL ZEROS */

            if (AREA_DE_WORK.WS_RESTO == 00)
            {

                /*" -1066- MOVE 0 TO WWORK-MINDIG */
                _.Move(0, AREA_DE_WORK.FILLER_13.WWORK_MINDIG);

                /*" -1067- ELSE */
            }
            else
            {


                /*" -1071- SUBTRACT WS-RESTO FROM 11 GIVING WWORK-MINDIG. */
                AREA_DE_WORK.FILLER_13.WWORK_MINDIG.Value = 11 - AREA_DE_WORK.WS_RESTO;
            }


            /*" -1072- IF WWORK-MIN-NRTIT GREATER WWORK-MAX-NRTIT */

            if (AREA_DE_WORK.WWORK_MIN_NRTIT > AREA_DE_WORK.WWORK_MAX_NRTIT)
            {

                /*" -1073- DISPLAY 'R0530-00 - ABEND CONTROLADO                ' */
                _.Display($"R0530-00 - ABEND CONTROLADO                ");

                /*" -1074- DISPLAY '*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    ' */
                _.Display($"*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    ");

                /*" -1075- DISPLAY '    ' WWORK-MIN-NRTIT */
                _.Display($"    {AREA_DE_WORK.WWORK_MIN_NRTIT}");

                /*" -1075- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-UPDATE-V0CEDENTE-SECTION */
        private void R0550_00_UPDATE_V0CEDENTE_SECTION()
        {
            /*" -1088- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1091- MOVE WWORK-MIN-NRTIT TO CEDENTE-NUM-TITULO. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -1095- PERFORM R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1 */

            R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1();

            /*" -1098- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1099- DISPLAY 'R0550-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' */
                _.Display($"R0550-00 - PROBLEMAS UPDATE (V0CEDENTE)   ");

                /*" -1099- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0550-00-UPDATE-V0CEDENTE-DB-UPDATE-1 */
        public void R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -1095- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO WHERE COD_CEDENTE = 26 END-EXEC. */

            var r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 = new R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
            };

            R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-DELETE-BILHETE-SECTION */
        private void R1000_00_DELETE_BILHETE_SECTION()
        {
            /*" -1112- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1116- PERFORM R1000_00_DELETE_BILHETE_DB_DELETE_1 */

            R1000_00_DELETE_BILHETE_DB_DELETE_1();

            /*" -1120- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1121- DISPLAY 'R1000-00 - PROBLEMAS DELETE (BILHETE)     ' */
                _.Display($"R1000-00 - PROBLEMAS DELETE (BILHETE)     ");

                /*" -1121- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-00-DELETE-BILHETE-DB-DELETE-1 */
        public void R1000_00_DELETE_BILHETE_DB_DELETE_1()
        {
            /*" -1116- EXEC SQL DELETE FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1 = new R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1.Execute(r1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-CONVERSI-SECTION */
        private void R1100_00_INSERT_CONVERSI_SECTION()
        {
            /*" -1134- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1137- MOVE BILHETE-NUM-BILHETE TO CONVERSI-NUM-PROPOSTA-SIVPF. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -1139- MOVE WWORK-MIN-NRTIT TO CONVERSI-NUM-SICOB. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

            /*" -1141- MOVE 1 TO CONVERSI-COD-EMPRESA-SIVPF. */
            _.Move(1, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF);

            /*" -1143- MOVE 8105 TO CONVERSI-COD-PRODUTO-SIVPF. */
            _.Move(8105, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);

            /*" -1145- MOVE BILHETE-AGE-COBRANCA TO CONVERSI-AGEPGTO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO);

            /*" -1147- MOVE BILHETE-DATA-VENDA TO CONVERSI-DATA-OPERACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO);

            /*" -1149- MOVE BILHETE-DATA-QUITACAO TO CONVERSI-DATA-QUITACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO);

            /*" -1151- MOVE BILHETE-VAL-RCAP TO CONVERSI-VAL-RCAP. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP);

            /*" -1155- MOVE BILHETE-COD-USUARIO TO CONVERSI-COD-USUARIO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_USUARIO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO);

            /*" -1178- PERFORM R1100_00_INSERT_CONVERSI_DB_INSERT_1 */

            R1100_00_INSERT_CONVERSI_DB_INSERT_1();

            /*" -1182- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1183- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1184- PERFORM R1150-00-TRATA-DUPLICI-SICOB */

                    R1150_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -1185- ELSE */
                }
                else
                {


                    /*" -1188- DISPLAY 'R1100-00 - PROBLEMAS NO INSERT(CONVERSI) ' '   ' CONVERSI-NUM-PROPOSTA-SIVPF '   ' CONVERSI-NUM-SICOB */

                    $"R1100-00 - PROBLEMAS NO INSERT(CONVERSI)    {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF}   {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB}"
                    .Display();

                    /*" -1188- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-INSERT-CONVERSI-DB-INSERT-1 */
        public void R1100_00_INSERT_CONVERSI_DB_INSERT_1()
        {
            /*" -1178- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB (NUM_PROPOSTA_SIVPF , NUM_SICOB , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , AGEPGTO , DATA_OPERACAO , DATA_QUITACAO , VAL_RCAP , COD_USUARIO , TIMESTAMP) VALUES (:CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-NUM-SICOB , :CONVERSI-COD-EMPRESA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF , :CONVERSI-AGEPGTO , :CONVERSI-DATA-OPERACAO , :CONVERSI-DATA-QUITACAO , :CONVERSI-VAL-RCAP , :CONVERSI-COD-USUARIO , CURRENT TIMESTAMP) END-EXEC. */

            var r1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1 = new R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
                CONVERSI_COD_EMPRESA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF.ToString(),
                CONVERSI_COD_PRODUTO_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF.ToString(),
                CONVERSI_AGEPGTO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO.ToString(),
                CONVERSI_DATA_OPERACAO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO.ToString(),
                CONVERSI_DATA_QUITACAO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO.ToString(),
                CONVERSI_VAL_RCAP = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP.ToString(),
                CONVERSI_COD_USUARIO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO.ToString(),
            };

            R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1.Execute(r1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-TRATA-DUPLICI-SICOB-SECTION */
        private void R1150_00_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -1200- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1201- PERFORM R0530-00-CALCULA-TITULO */

            R0530_00_CALCULA_TITULO_SECTION();

            /*" -1202- PERFORM R0550-00-UPDATE-V0CEDENTE */

            R0550_00_UPDATE_V0CEDENTE_SECTION();

            /*" -1203- PERFORM R1100-00-INSERT-CONVERSI. */

            R1100_00_INSERT_CONVERSI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INSERT-BILHETE-SECTION */
        private void R1200_00_INSERT_BILHETE_SECTION()
        {
            /*" -1214- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1217- MOVE WWORK-MIN-NRTIT TO BILHETE-NUM-BILHETE. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -1286- PERFORM R1200_00_INSERT_BILHETE_DB_INSERT_1 */

            R1200_00_INSERT_BILHETE_DB_INSERT_1();

            /*" -1290- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1292- DISPLAY 'R1200-00 - PROBLEMAS NO INSERT(BILHETE)   ' '   ' BILHETE-NUM-BILHETE */

                $"R1200-00 - PROBLEMAS NO INSERT(BILHETE)      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}"
                .Display();

                /*" -1292- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-INSERT-BILHETE-DB-INSERT-1 */
        public void R1200_00_INSERT_BILHETE_DB_INSERT_1()
        {
            /*" -1286- EXEC SQL INSERT INTO SEGUROS.BILHETE (NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM) VALUES (:BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-FONTE , :BILHETE-AGE-COBRANCA , :BILHETE-NUM-MATRICULA , :BILHETE-COD-AGENCIA , :BILHETE-OPERACAO-CONTA , :BILHETE-NUM-CONTA , :BILHETE-DIG-CONTA , :BILHETE-COD-CLIENTE , :BILHETE-PROFISSAO , :BILHETE-IDE-SEXO , :BILHETE-ESTADO-CIVIL , :BILHETE-OCORR-ENDERECO , :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB , :BILHETE-OPC-COBERTURA , :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-RAMO , :BILHETE-DATA-VENDA , :BILHETE-DATA-MOVIMENTO , :BILHETE-NUM-APOL-ANTERIOR , :BILHETE-SITUACAO , :BILHETE-TIP-CANCELAMENTO , :BILHETE-SIT-SINISTRO , :BILHETE-COD-USUARIO , :BILHETE-TIMESTAMP , :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 , :BILHETE-BI-FAIXA-RENDA-IND , :BILHETE-BI-FAIXA-RENDA-FAM) END-EXEC. */

            var r1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1 = new R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
                BILHETE_AGE_COBRANCA = BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA.ToString(),
                BILHETE_NUM_MATRICULA = BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA.ToString(),
                BILHETE_COD_AGENCIA = BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA.ToString(),
                BILHETE_OPERACAO_CONTA = BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA.ToString(),
                BILHETE_NUM_CONTA = BILHETE.DCLBILHETE.BILHETE_NUM_CONTA.ToString(),
                BILHETE_DIG_CONTA = BILHETE.DCLBILHETE.BILHETE_DIG_CONTA.ToString(),
                BILHETE_COD_CLIENTE = BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE.ToString(),
                BILHETE_PROFISSAO = BILHETE.DCLBILHETE.BILHETE_PROFISSAO.ToString(),
                BILHETE_IDE_SEXO = BILHETE.DCLBILHETE.BILHETE_IDE_SEXO.ToString(),
                BILHETE_ESTADO_CIVIL = BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL.ToString(),
                BILHETE_OCORR_ENDERECO = BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO.ToString(),
                BILHETE_COD_AGENCIA_DEB = BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB.ToString(),
                BILHETE_OPERACAO_CONTA_DEB = BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB.ToString(),
                BILHETE_NUM_CONTA_DEB = BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB.ToString(),
                BILHETE_DIG_CONTA_DEB = BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB.ToString(),
                BILHETE_OPC_COBERTURA = BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA.ToString(),
                BILHETE_DATA_QUITACAO = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.ToString(),
                BILHETE_VAL_RCAP = BILHETE.DCLBILHETE.BILHETE_VAL_RCAP.ToString(),
                BILHETE_RAMO = BILHETE.DCLBILHETE.BILHETE_RAMO.ToString(),
                BILHETE_DATA_VENDA = BILHETE.DCLBILHETE.BILHETE_DATA_VENDA.ToString(),
                BILHETE_DATA_MOVIMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO.ToString(),
                BILHETE_NUM_APOL_ANTERIOR = BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR.ToString(),
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_TIP_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO.ToString(),
                BILHETE_SIT_SINISTRO = BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO.ToString(),
                BILHETE_COD_USUARIO = BILHETE.DCLBILHETE.BILHETE_COD_USUARIO.ToString(),
                BILHETE_TIMESTAMP = BILHETE.DCLBILHETE.BILHETE_TIMESTAMP.ToString(),
                BILHETE_DATA_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                BILHETE_BI_FAIXA_RENDA_IND = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND.ToString(),
                BILHETE_BI_FAIXA_RENDA_FAM = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM.ToString(),
            };

            R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1.Execute(r1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-MOVIMCOB-SECTION */
        private void R4000_00_INSERT_MOVIMCOB_SECTION()
        {
            /*" -1304- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1347- PERFORM R4000_00_INSERT_MOVIMCOB_DB_INSERT_1 */

            R4000_00_INSERT_MOVIMCOB_DB_INSERT_1();

            /*" -1352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1357- DISPLAY 'R4000-00 - PROBLEMAS NO INSERT(MOVIMCOB)   ' '   ' MOVCC-REGISTRO '   ' MOVIMCOB-NUM-AVISO '   ' MOVIMCOB-NUM-TITULO '   ' MOVIMCOB-NUM-NOSSO-TITULO */

                $"R4000-00 - PROBLEMAS NO INSERT(MOVIMCOB)      {MOVCC_REGISTRO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                .Display();

                /*" -1360- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1360- ADD 1 TO AC-MOVIMCOB. */
            AREA_DE_WORK.AC_MOVIMCOB.Value = AREA_DE_WORK.AC_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R4000-00-INSERT-MOVIMCOB-DB-INSERT-1 */
        public void R4000_00_INSERT_MOVIMCOB_DB_INSERT_1()
        {
            /*" -1347- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_COBRANCA (COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_IOCC , VAL_CREDITO , SIT_REGISTRO , TIMESTAMP , NOME_SEGURADO , TIPO_MOVIMENTO , NUM_NOSSO_TITULO) VALUES (:MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , CURRENT TIMESTAMP , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-TIPO-MOVIMENTO , :MOVIMCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1 = new R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1()
            {
                MOVIMCOB_COD_EMPRESA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA.ToString(),
                MOVIMCOB_COD_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_FITA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA.ToString(),
                MOVIMCOB_DATA_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.ToString(),
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_VAL_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.ToString(),
                MOVIMCOB_VAL_IOCC = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC.ToString(),
                MOVIMCOB_VAL_CREDITO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.ToString(),
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_NOME_SEGURADO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO.ToString(),
                MOVIMCOB_TIPO_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1.Execute(r4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-ATUALIZA-LOTERICO-SECTION */
        private void R6000_00_ATUALIZA_LOTERICO_SECTION()
        {
            /*" -1371- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1372- MOVE MOVCC-CODBARRA TO WWORK-CODBARRA. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA, AREA_DE_WORK.WWORK_CODBARRA);

            /*" -1374- MOVE WWORK-PROPOSTA TO CONVERSI-NUM-PROPOSTA-SIVPF */
            _.Move(AREA_DE_WORK.WWORK_CODBARRA.WWORK_PROPOSTA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -1380- PERFORM R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1 */

            R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1();

            /*" -1383- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1384- DISPLAY 'R6000-00 - PROBLEMAS AO RECUPERAR O BILHETE.' */
                _.Display($"R6000-00 - PROBLEMAS AO RECUPERAR O BILHETE.");

                /*" -1385- DISPLAY 'NUMERO DA PROPOST ' WWORK-PROPOSTA */
                _.Display($"NUMERO DA PROPOST {AREA_DE_WORK.WWORK_CODBARRA.WWORK_PROPOSTA}");

                /*" -1387- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1389- MOVE MOVCC-NUM-LOTER TO BILHETE-NUM-MATRICULA */
            _.Move(MOVCC_REGISTRO.FILLER_2.MOVCC_NUM_LOTER, BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA);

            /*" -1393- PERFORM R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1 */

            R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1();

            /*" -1396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1397- DISPLAY 'R6000-00 - PROBLEMAS NA ATUALIZACAO DA LOTERICA.' */
                _.Display($"R6000-00 - PROBLEMAS NA ATUALIZACAO DA LOTERICA.");

                /*" -1398- DISPLAY 'NUMERO DO BILHETE ' BILHETE-NUM-BILHETE */
                _.Display($"NUMERO DO BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1399- DISPLAY 'NUMERO DA PROPOST ' WWORK-PROPOSTA */
                _.Display($"NUMERO DA PROPOST {AREA_DE_WORK.WWORK_CODBARRA.WWORK_PROPOSTA}");

                /*" -1399- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6000-00-ATUALIZA-LOTERICO-DB-SELECT-1 */
        public void R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1()
        {
            /*" -1380- EXEC SQL SELECT NUM_SICOB INTO :BILHETE-NUM-BILHETE FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1 = new R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1.Execute(r6000_00_ATUALIZA_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
            }


        }

        [StopWatch]
        /*" R6000-00-ATUALIZA-LOTERICO-DB-UPDATE-1 */
        public void R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1()
        {
            /*" -1393- EXEC SQL UPDATE SEGUROS.BILHETE SET NUM_MATRICULA = :BILHETE-NUM-MATRICULA WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1 = new R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1()
            {
                BILHETE_NUM_MATRICULA = BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1.Execute(r6000_00_ATUALIZA_LOTERICO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1408- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1409- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLERRD1);

            /*" -1410- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLERRD2);

            /*" -1412- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERR.WSQLERRMC);

            /*" -1413- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1415- DISPLAY WSQLERR. */
            _.Display(AREA_DE_WORK.WSQLERR);

            /*" -1415- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1419- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -1421- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1421- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}