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
using Sias.Cobranca.DB2.CB6249B;

namespace Code
{
    public class CB6249B
    {
        public bool IsCall { get; set; }

        public CB6249B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------- ----------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB6249B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  RILDO SICO                         *      */
        /*"      *   PROGRAMADOR ............  RILDO SICO                         *      */
        /*"      *   DATA CODIFICACAO .......  25/10/2018                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONSISTENCIA E CONTROLE DO         *      */
        /*"      *                             MOVIMENTO DE COBRANCA              *      */
        /*"      *                             CONVENIO DE ARRECADACAO - SICAP    *      */
        /*"      *                             CAIXA SEGURADORA - 912014.         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - DEMANDA 582106                                   *      */
        /*"      *             - COMECAR A PROCESSAR O CONVENIO 912085.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/08/2024 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 30/01/2024 *      */
        /*"      *   VERSAO 07               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
        /*"      *                             NA TABELA AVISO_CREDITO PARA FAZER *      */
        /*"      *                             A CONCILIACAO DOS AVISOS DE CREDITO*      */
        /*"      *                             MANUAL COM O DEPOSITO DE TERCEIRO  *      */
        /*"      *                             (DT) NO MCP-ZE.                    *      */
        /*"      *                           - ESTA COLUNA ASSUME COMO DEFAULT O  *      */
        /*"      *                             DOMINIO 'P' (CREDITO NAO CONSUMIDO)*      */
        /*"      *                             E SOMENTE OS PROGRAMAS DO SISTEMA  *      */
        /*"      *                             "ZE" EH QUE ATUALIZARAO A MESMA.   *      */
        /*"      *                           - JAZZ - DEMANDA - 569880            *      */
        /*"      *                                    TAREFA  - 569478            *      */
        /*"      *                           - PROCURAR POR V.07                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - DEMANDA 251127/ABEND 183014                      *      */
        /*"      *             - CORRIGIR O ACESSO A AVISO_CREDITO PARA O NOVO    *      */
        /*"      *               CONVENIO.                                        *      */
        /*"      *             - MOVE O INSERT NA AVISO_CREDITO PARA APOS O PROCES-      */
        /*"      *               SAMENTO DO TRAILLER, CASO O ARQUIVO CHEGAR COM   *      */
        /*"      *               DOIS HEADERS E DOIS TRAILLERS ELE ATUALIZA UM E  *      */
        /*"      *               DEPOIS OUTRO.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/07/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - DEMANDA 247278                                   *      */
        /*"      *             - PASSAR A PROCESSAR O CONVENIO 912087, QUE IRA    *      */
        /*"      *               SUBSTITUIR O CONVENIO 912014.                    *      */
        /*"      *             - A PRINCIPIO OS DOIS CONVENIOS VAO CONVIVER JUNTOS*      */
        /*"      *               MAS O OBJETIVO � QUE O CONVENIO 912014 NAO SEJA  *      */
        /*"      *               MAIS PROCESSADO.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/06/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - HISTORIA 226662                                  *      */
        /*"      *                                                                *      */
        /*"      *             - ACRESCENTAR CODIGOS DE CONVENIO CVP/JV1          *      */
        /*"      *               NO TRATAMENTO DO HEARDER DO ARQUIVO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - HISTORIA 234486                                  *      */
        /*"      *             - PASSAR A GRAVAR SEGUROS.AVISO_CREDITO E          *      */
        /*"      *               SEGUROS.AVISOS_SALDOS QUE ERA FEITO PELO CB6259B.*      */
        /*"      *               EM8009B ESTAVA GERANDO SEQUENCIAL DE ARQUIVO EM  *      */
        /*"      *               DUPLICIDADE.                                     *      */
        /*"      *             - PASSAR A ABENDAR EM CASO DE ARQUIVO JA PROCESSADO*      */
        /*"      *                                                                *      */
        /*"      *   EM 18/03/2020 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
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
        public CB6249B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new CB6249B_MOVCC_REGISTRO();
        public class CB6249B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-CTACOBRANCA.*/
            public CB6249B_MOVCC_CTACOBRANCA MOVCC_CTACOBRANCA { get; set; } = new CB6249B_MOVCC_CTACOBRANCA();
            public class CB6249B_MOVCC_CTACOBRANCA : VarBasis
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
            public CB6249B_MOVCC_DTPAGTO MOVCC_DTPAGTO { get; set; } = new CB6249B_MOVCC_DTPAGTO();
            public class CB6249B_MOVCC_DTPAGTO : VarBasis
            {
                /*"    10    MOVCC-ANOPAG       PIC  9(004).*/
                public IntBasis MOVCC_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESPAG       PIC  9(002).*/
                public IntBasis MOVCC_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIAPAG       PIC  9(002).*/
                public IntBasis MOVCC_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public CB6249B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new CB6249B_MOVCC_DTCREDITO();
            public class CB6249B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANOCRE       PIC  9(004).*/
                public IntBasis MOVCC_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESCRE       PIC  9(002).*/
                public IntBasis MOVCC_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIACRE       PIC  9(002).*/
                public IntBasis MOVCC_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-CODBARRA.*/
            }
            public CB6249B_MOVCC_CODBARRA MOVCC_CODBARRA { get; set; } = new CB6249B_MOVCC_CODBARRA();
            public class CB6249B_MOVCC_CODBARRA : VarBasis
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
            /*"  05      MOVCC-FORMAPAG     PIC  9(001).*/
            public IntBasis MOVCC_FORMAPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER             PIC  X(004).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
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
        /*"77    WSHOST-PRM-TOTAL          PIC S9(13)V9(2) COMP-3 VALUE +0.*/
        public DoubleBasis WSHOST_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77    WSHOST-PRM-LIQUIDO        PIC S9(13)V9(2) COMP-3 VALUE +0.*/
        public DoubleBasis WSHOST_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77    WSHOST-VAL-DESPESA        PIC S9(13)V9(2) COMP-3 VALUE +0.*/
        public DoubleBasis WSHOST_VAL_DESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77    WSHOST-VAL-TARIFA         PIC S9(13)V9(2) COMP-3 VALUE +0.*/
        public DoubleBasis WSHOST_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77    WSHOST-DATA-AVISO         PIC  X(10).*/
        public StringBasis WSHOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01        HEADER-REGISTRO.*/
        public CB6249B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new CB6249B_HEADER_REGISTRO();
        public class CB6249B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  9(006).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(014).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public CB6249B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new CB6249B_HEADER_DATGERACAO();
            public class CB6249B_HEADER_DATGERACAO : VarBasis
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
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public CB6249B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new CB6249B_TRAILL_REGISTRO();
        public class CB6249B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTPAG    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTPAG { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER              PIC  X(126).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public CB6249B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB6249B_AREA_DE_WORK();
        public class CB6249B_AREA_DE_WORK : VarBasis
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
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB6249B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_CB6249B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_CB6249B_FILLER_6(); _.Move(WDATA_REL, _filler_6); VarBasis.RedefinePassValue(WDATA_REL, _filler_6, WDATA_REL); _filler_6.ValueChanged += () => { _.Move(_filler_6, WDATA_REL); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_6 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-NRAVISO        PIC  9(009)    VALUE  ZEROS.*/

                public _REDEF_CB6249B_FILLER_6()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      WS-NRAVISO.*/
            private _REDEF_CB6249B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_CB6249B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_CB6249B_FILLER_9(); _.Move(WS_NRAVISO, _filler_9); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_9, WS_NRAVISO); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS_NRAVISO); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_9 : VarBasis
            {
                /*"      10     WS-AUXAVISO       PIC  9(004).*/
                public IntBasis WS_AUXAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-AUXNSAS        PIC  9(005).*/
                public IntBasis WS_AUXNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WS-NRTIT          PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_CB6249B_FILLER_9()
                {
                    WS_AUXAVISO.ValueChanged += OnValueChanged;
                    WS_AUXNSAS.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER            REDEFINES      WS-NRTIT.*/
            private _REDEF_CB6249B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_CB6249B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_CB6249B_FILLER_10(); _.Move(WS_NRTIT, _filler_10); VarBasis.RedefinePassValue(WS_NRTIT, _filler_10, WS_NRTIT); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_NRTIT); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_10 : VarBasis
            {
                /*"      10     WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10     WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MIN-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_CB6249B_FILLER_10()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_CB6249B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_CB6249B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_CB6249B_FILLER_11(); _.Move(WWORK_MIN_NRTIT, _filler_11); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_11, WWORK_MIN_NRTIT); _filler_11.ValueChanged += () => { _.Move(_filler_11, WWORK_MIN_NRTIT); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_11 : VarBasis
            {
                /*"    10       WWORK-MINNRO      PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MINDIG      PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MAX-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_CB6249B_FILLER_11()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_CB6249B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_CB6249B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_CB6249B_FILLER_12(); _.Move(WWORK_MAX_NRTIT, _filler_12); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_12, WWORK_MAX_NRTIT); _filler_12.ValueChanged += () => { _.Move(_filler_12, WWORK_MAX_NRTIT); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_12 : VarBasis
            {
                /*"    10       WWORK-MAXNRO      PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MAXDIG      PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03        WABEND.*/

                public _REDEF_CB6249B_FILLER_12()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public CB6249B_WABEND WABEND { get; set; } = new CB6249B_WABEND();
            public class CB6249B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' CB6249B'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB6249B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03        WSQLERR.*/
            }
            public CB6249B_WSQLERR WSQLERR { get; set; } = new CB6249B_WSQLERR();
            public class CB6249B_WSQLERR : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01             LPARM11X.*/
            }
        }
        public CB6249B_LPARM11X LPARM11X { get; set; } = new CB6249B_LPARM11X();
        public class CB6249B_LPARM11X : VarBasis
        {
            /*"  03           LPARM11            PIC  9(010).*/
            public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03           FILLER             REDEFINES   LPARM11.*/
            private _REDEF_CB6249B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_CB6249B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_CB6249B_FILLER_19(); _.Move(LPARM11, _filler_19); VarBasis.RedefinePassValue(LPARM11, _filler_19, LPARM11); _filler_19.ValueChanged += () => { _.Move(_filler_19, LPARM11); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, LPARM11); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_19 : VarBasis
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

                public _REDEF_CB6249B_FILLER_19()
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
        public CB6249B_LPARM13X LPARM13X { get; set; } = new CB6249B_LPARM13X();
        public class CB6249B_LPARM13X : VarBasis
        {
            /*"  03           LPARM13            PIC  9(013).*/
            public IntBasis LPARM13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  03           FILLER             REDEFINES   LPARM13.*/
            private _REDEF_CB6249B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_CB6249B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_CB6249B_FILLER_20(); _.Move(LPARM13, _filler_20); VarBasis.RedefinePassValue(LPARM13, _filler_20, LPARM13); _filler_20.ValueChanged += () => { _.Move(_filler_20, LPARM13); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, LPARM13); }
            }  //Redefines
            public class _REDEF_CB6249B_FILLER_20 : VarBasis
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

                public _REDEF_CB6249B_FILLER_20()
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
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
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
            /*" -334- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -337- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -340- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -343- DISPLAY ' ---------------------------------------' */
            _.Display($" ---------------------------------------");

            /*" -344- DISPLAY ' PROGRAMA EM EXECUCAO CB6249B           ' */
            _.Display($" PROGRAMA EM EXECUCAO CB6249B           ");

            /*" -345- DISPLAY '                                        ' */
            _.Display($"                                        ");

            /*" -346- DISPLAY ' COMPILADO EM: ' FUNCTION WHEN-COMPILED */

            $" COMPILADO EM: FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -347- DISPLAY '                                        ' */
            _.Display($"                                        ");

            /*" -348- DISPLAY ' VERSAO V.08 - DEM. 582.106 - 16/08/2024' */
            _.Display($" VERSAO V.08 - DEM. 582.106 - 16/08/2024");

            /*" -349- DISPLAY ' ---------------------------------------' . */
            _.Display($" ---------------------------------------");

            /*" -351- DISPLAY ' ' . */
            _.Display($" ");

            /*" -353- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -353- PERFORM R0300-00-SELECIONA. */

            R0300_00_SELECIONA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -358- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -362- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -364- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -364- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -377- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -380- OPEN INPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVCC_REGISTRO);

            /*" -380- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -394- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -400- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -404- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -405- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -408- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -412- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL);

            /*" -414- DISPLAY ' DATA DO PROCESSAMENTO ...... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -414- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -400- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

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
            /*" -433- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -434- DISPLAY ' CONVENIO 912087/912085 (C.E.F./SICAP) - RETORNO ' */
            _.Display($" CONVENIO 912087/912085 (C.E.F./SICAP) - RETORNO ");

            /*" -436- DISPLAY ' ' . */
            _.Display($" ");

            /*" -438- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -440- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

            /*" -441- PERFORM R0320-00-PROCESSA-ENTRADA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

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
            /*" -456- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -456- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -458- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -461- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, MOVCC_REGISTRO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -461- ADD 1 TO LD-ENTRADA. */
            AREA_DE_WORK.LD_ENTRADA.Value = AREA_DE_WORK.LD_ENTRADA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-ENTRADA-SECTION */
        private void R0320_00_PROCESSA_ENTRADA_SECTION()
        {
            /*" -474- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -475- IF MOVCC-CODREGISTRO EQUAL 'A' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO == "A")
            {

                /*" -476- ADD 1 TO LD-HEADER */
                AREA_DE_WORK.LD_HEADER.Value = AREA_DE_WORK.LD_HEADER + 1;

                /*" -477- MOVE MOVCC-REGISTRO TO HEADER-REGISTRO */
                _.Move(MOVIMENTO?.Value, HEADER_REGISTRO);

                /*" -478- PERFORM R0330-00-TRATA-HEADER */

                R0330_00_TRATA_HEADER_SECTION();

                /*" -481- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -482- IF MOVCC-CODREGISTRO EQUAL 'Z' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO == "Z")
            {

                /*" -483- ADD 1 TO LD-TRAILLER */
                AREA_DE_WORK.LD_TRAILLER.Value = AREA_DE_WORK.LD_TRAILLER + 1;

                /*" -484- MOVE MOVCC-REGISTRO TO TRAILL-REGISTRO */
                _.Move(MOVIMENTO?.Value, TRAILL_REGISTRO);

                /*" -485- PERFORM R0350-00-TRATA-TRAILLER */

                R0350_00_TRATA_TRAILLER_SECTION();

                /*" -486- PERFORM R4500-00-TRATA-AVISO-CREDITO */

                R4500_00_TRATA_AVISO_CREDITO_SECTION();

                /*" -487- PERFORM R4800-00-TRATA-AVISO-SALDOS */

                R4800_00_TRATA_AVISO_SALDOS_SECTION();

                /*" -490- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -491- IF MOVCC-CODREGISTRO NOT EQUAL 'G' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO != "G")
            {

                /*" -493- DISPLAY 'DESPREZA  COD-REGISTRO   ' MOVCC-REGISTRO */
                _.Display($"DESPREZA  COD-REGISTRO   {MOVCC_REGISTRO}");

                /*" -494- ADD 1 TO DP-ENTRADA */
                AREA_DE_WORK.DP_ENTRADA.Value = AREA_DE_WORK.DP_ENTRADA + 1;

                /*" -497- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -497- PERFORM R0400-00-PROCESSA-DETALHE. */

            R0400_00_PROCESSA_DETALHE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_50_LEITURA */

            R0320_50_LEITURA();

        }

        [StopWatch]
        /*" R0320-50-LEITURA */
        private void R0320_50_LEITURA(bool isPerform = false)
        {
            /*" -502- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-TRATA-HEADER-SECTION */
        private void R0330_00_TRATA_HEADER_SECTION()
        {
            /*" -519- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -521- IF NOT (HEADER-CODCONVENIO EQUAL 912085 OR 912087) */

            if (!(HEADER_REGISTRO.HEADER_CODCONVENIO.In("912085", "912087")))
            {

                /*" -523- DISPLAY 'R0330-00 - CONVENIO NAO PREVISTO         ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CONVENIO NAO PREVISTO         {HEADER_REGISTRO}");

                /*" -526- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -527- IF HEADER-CODREMESSA NOT EQUAL 2 */

            if (HEADER_REGISTRO.HEADER_CODREMESSA != 2)
            {

                /*" -529- DISPLAY 'R0330-00 - CODIGO REMESSA INVALIDO       ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CODIGO REMESSA INVALIDO       {HEADER_REGISTRO}");

                /*" -532- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -533- IF HEADER-CODBANCO NOT EQUAL 104 */

            if (HEADER_REGISTRO.HEADER_CODBANCO != 104)
            {

                /*" -535- DISPLAY 'R0330-00 - CODIGO BANCO   INVALIDO       ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CODIGO BANCO   INVALIDO       {HEADER_REGISTRO}");

                /*" -539- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -547- MOVE ZEROS TO WS-NRAVISO. */
            _.Move(0, AREA_DE_WORK.WS_NRAVISO);

            /*" -548- EVALUATE HEADER-CODCONVENIO */
            switch (HEADER_REGISTRO.HEADER_CODCONVENIO.Value)
            {

                /*" -549- WHEN 912087 */
                case 912087:

                    /*" -550- MOVE 9087 TO WS-AUXAVISO */
                    _.Move(9087, AREA_DE_WORK.FILLER_9.WS_AUXAVISO);

                    /*" -551- WHEN 912085 */
                    break;
                case 912085:

                    /*" -552- MOVE 9085 TO WS-AUXAVISO */
                    _.Move(9085, AREA_DE_WORK.FILLER_9.WS_AUXAVISO);

                    /*" -553- WHEN OTHER */
                    break;
                default:

                    /*" -554- MOVE 9014 TO WS-AUXAVISO */
                    _.Move(9014, AREA_DE_WORK.FILLER_9.WS_AUXAVISO);

                    /*" -556- END-EVALUATE */
                    break;
            }


            /*" -559- MOVE HEADER-NSA TO WS-AUXNSAS. */
            _.Move(HEADER_REGISTRO.HEADER_NSA, AREA_DE_WORK.FILLER_9.WS_AUXNSAS);

            /*" -560- DISPLAY ' SEQUENCIA ARQUIVO ..........  ' HEADER-NSA. */
            _.Display($" SEQUENCIA ARQUIVO ..........  {HEADER_REGISTRO.HEADER_NSA}");

            /*" -563- DISPLAY ' ' . */
            _.Display($" ");

            /*" -565- PERFORM R0340-00-SELECT-MOVIMCOB. */

            R0340_00_SELECT_MOVIMCOB_SECTION();

            /*" -566- IF WSHOST-COUNT NOT EQUAL ZEROS */

            if (WSHOST_COUNT != 00)
            {

                /*" -569- DISPLAY ' SEQUENCIA DE ARQUIVO ' WS-NRAVISO ' JA PROCESSADO ' */

                $" SEQUENCIA DE ARQUIVO {AREA_DE_WORK.WS_NRAVISO} JA PROCESSADO "
                .Display();

                /*" -570- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -570- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-SELECT-MOVIMCOB-SECTION */
        private void R0340_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -583- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -585- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -587- MOVE 8010 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(8010, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -590- MOVE WS-NRAVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(AREA_DE_WORK.WS_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -601- PERFORM R0340_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0340_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -605- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -607- MOVE ZEROS TO WSHOST-COUNT */
                _.Move(0, WSHOST_COUNT);

                /*" -608- ELSE */
            }
            else
            {


                /*" -609- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -611- MOVE 1 TO WSHOST-COUNT */
                    _.Move(1, WSHOST_COUNT);

                    /*" -612- ELSE */
                }
                else
                {


                    /*" -613- IF VIND-NULL02 LESS ZEROS */

                    if (VIND_NULL02 < 00)
                    {

                        /*" -614- MOVE ZEROS TO WSHOST-COUNT. */
                        _.Move(0, WSHOST_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0340-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0340_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -601- EXEC SQL SELECT COUNT(*) INTO :WSHOST-COUNT:VIND-NULL02 FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO WITH UR END-EXEC. */

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
            /*" -627- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -628- DISPLAY ' ' . */
            _.Display($" ");

            /*" -629- DISPLAY ' LIDOS    ENTRADA ........... ' LD-ENTRADA. */
            _.Display($" LIDOS    ENTRADA ........... {AREA_DE_WORK.LD_ENTRADA}");

            /*" -630- DISPLAY ' LIDOS    HEADER ............ ' LD-HEADER. */
            _.Display($" LIDOS    HEADER ............ {AREA_DE_WORK.LD_HEADER}");

            /*" -631- DISPLAY ' LIDOS    TRAILLER .......... ' LD-TRAILLER. */
            _.Display($" LIDOS    TRAILLER .......... {AREA_DE_WORK.LD_TRAILLER}");

            /*" -632- DISPLAY ' DESPREZA ENTRADA ........... ' DP-ENTRADA. */
            _.Display($" DESPREZA ENTRADA ........... {AREA_DE_WORK.DP_ENTRADA}");

            /*" -633- DISPLAY ' ' . */
            _.Display($" ");

            /*" -634- DISPLAY ' LIDOS DETALHE .............. ' LD-DETALHE. */
            _.Display($" LIDOS DETALHE .............. {AREA_DE_WORK.LD_DETALHE}");

            /*" -635- DISPLAY ' CADASTRA CONVERSAO ......... ' AC-CONVERSI. */
            _.Display($" CADASTRA CONVERSAO ......... {AREA_DE_WORK.AC_CONVERSI}");

            /*" -636- DISPLAY ' ' . */
            _.Display($" ");

            /*" -637- DISPLAY ' CADASTRADOS MOVIMENTO....... ' AC-MOVIMCOB. */
            _.Display($" CADASTRADOS MOVIMENTO....... {AREA_DE_WORK.AC_MOVIMCOB}");

            /*" -640- DISPLAY ' ' . */
            _.Display($" ");

            /*" -647- MOVE ZEROS TO LD-ENTRADA LD-HEADER LD-TRAILLER LD-DETALHE DP-ENTRADA AC-CONVERSI AC-MOVIMCOB. */
            _.Move(0, AREA_DE_WORK.LD_ENTRADA, AREA_DE_WORK.LD_HEADER, AREA_DE_WORK.LD_TRAILLER, AREA_DE_WORK.LD_DETALHE, AREA_DE_WORK.DP_ENTRADA, AREA_DE_WORK.AC_CONVERSI, AREA_DE_WORK.AC_MOVIMCOB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-DETALHE-SECTION */
        private void R0400_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -660- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -662- ADD 1 TO LD-DETALHE. */
            AREA_DE_WORK.LD_DETALHE.Value = AREA_DE_WORK.LD_DETALHE + 1;

            /*" -667- PERFORM R0410-00-MONTA-MOVIMCOB. */

            R0410_00_MONTA_MOVIMCOB_SECTION();

            /*" -672- PERFORM R0420-00-SELECT-CONVERSI. */

            R0420_00_SELECT_CONVERSI_SECTION();

            /*" -677- PERFORM R0450-00-SELECT-MOVIMCOB. */

            R0450_00_SELECT_MOVIMCOB_SECTION();

            /*" -678- IF MOVIMCOB-SIT-REGISTRO NOT EQUAL SPACES */

            if (!MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.IsEmpty())
            {

                /*" -680- DISPLAY ' REGISTRO JA CADASTRADO MOVIMCOB         ' MOVCC-REGISTRO */
                _.Display($" REGISTRO JA CADASTRADO MOVIMCOB         {MOVCC_REGISTRO}");

                /*" -683- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


            /*" -685- PERFORM R4000-00-INSERT-MOVIMCOB. */

            R4000_00_INSERT_MOVIMCOB_SECTION();

            /*" -686- ADD MOVIMCOB-VAL-TITULO TO WSHOST-PRM-TOTAL. */
            WSHOST_PRM_TOTAL.Value = WSHOST_PRM_TOTAL + MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO;

            /*" -687- ADD MOVCC-VLRTARIFA TO WSHOST-VAL-TARIFA. */
            WSHOST_VAL_TARIFA.Value = WSHOST_VAL_TARIFA + MOVCC_REGISTRO.MOVCC_VLRTARIFA;

            /*" -688- ADD MOVIMCOB-VAL-IOCC TO WSHOST-VAL-DESPESA. */
            WSHOST_VAL_DESPESA.Value = WSHOST_VAL_DESPESA + MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC;

            /*" -688- ADD MOVIMCOB-VAL-CREDITO TO WSHOST-PRM-LIQUIDO. */
            WSHOST_PRM_LIQUIDO.Value = WSHOST_PRM_LIQUIDO + MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-MONTA-MOVIMCOB-SECTION */
        private void R0410_00_MONTA_MOVIMCOB_SECTION()
        {
            /*" -700- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -702- MOVE ZEROS TO MOVIMCOB-COD-EMPRESA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -704- MOVE MOVCC-NRSEQREG TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(MOVCC_REGISTRO.MOVCC_NRSEQREG, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -706- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -708- MOVE 8010 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(8010, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -710- MOVE WS-NRAVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(AREA_DE_WORK.WS_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -712- MOVE WS-AUXNSAS TO MOVIMCOB-NUM-FITA. */
            _.Move(AREA_DE_WORK.FILLER_9.WS_AUXNSAS, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -717- MOVE ZEROS TO MOVIMCOB-NUM-TITULO MOVIMCOB-NUM-APOLICE MOVIMCOB-NUM-ENDOSSO MOVIMCOB-NUM-PARCELA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -719- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -721- MOVE MOVCC-BARRA01 TO MOVIMCOB-NOME-SEGURADO. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_BARRA01, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -723- MOVE 'G' TO MOVIMCOB-TIPO-MOVIMENTO. */
            _.Move("G", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

            /*" -726- MOVE MOVCC-NUMSIVPF TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUMSIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -731- MOVE MOVCC-VLRPAGO TO MOVIMCOB-VAL-TITULO. */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRPAGO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -739- MOVE ZEROS TO MOVIMCOB-VAL-IOCC. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

            /*" -743- COMPUTE MOVIMCOB-VAL-CREDITO EQUAL MOVCC-VLRPAGO - MOVCC-VLRTARIFA */
            MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.Value = MOVCC_REGISTRO.MOVCC_VLRPAGO - MOVCC_REGISTRO.MOVCC_VLRTARIFA;

            /*" -744- MOVE MOVCC-ANOCRE TO WDAT-REL-ANO */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANOCRE, AREA_DE_WORK.FILLER_6.WDAT_REL_ANO);

            /*" -745- MOVE MOVCC-MESCRE TO WDAT-REL-MES */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MESCRE, AREA_DE_WORK.FILLER_6.WDAT_REL_MES);

            /*" -746- MOVE MOVCC-DIACRE TO WDAT-REL-DIA */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIACRE, AREA_DE_WORK.FILLER_6.WDAT_REL_DIA);

            /*" -750- MOVE WDATA-REL TO WSHOST-DATA-AVISO MOVIMCOB-DATA-MOVIMENTO. */
            _.Move(AREA_DE_WORK.WDATA_REL, WSHOST_DATA_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -751- MOVE MOVCC-ANOPAG TO WDAT-REL-ANO */
            _.Move(MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_ANOPAG, AREA_DE_WORK.FILLER_6.WDAT_REL_ANO);

            /*" -752- MOVE MOVCC-MESPAG TO WDAT-REL-MES */
            _.Move(MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_MESPAG, AREA_DE_WORK.FILLER_6.WDAT_REL_MES);

            /*" -753- MOVE MOVCC-DIAPAG TO WDAT-REL-DIA */
            _.Move(MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_DIAPAG, AREA_DE_WORK.FILLER_6.WDAT_REL_DIA);

            /*" -754- MOVE WDATA-REL TO MOVIMCOB-DATA-QUITACAO. */
            _.Move(AREA_DE_WORK.WDATA_REL, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-CONVERSI-SECTION */
        private void R0420_00_SELECT_CONVERSI_SECTION()
        {
            /*" -765- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -768- MOVE MOVCC-NUMSIVPF TO CONVERSI-NUM-PROPOSTA-SIVPF */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUMSIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -777- PERFORM R0420_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0420_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -780- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -781- MOVE BILHETE-NUM-BILHETE TO MOVIMCOB-NUM-TITULO */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

                /*" -782- ELSE */
            }
            else
            {


                /*" -783- IF SQLCODE = +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -784- MOVE ZEROS TO MOVIMCOB-NUM-TITULO */
                    _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

                    /*" -785- END-IF */
                }


                /*" -785- END-IF. */
            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0420_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -777- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , A.NUM_SICOB INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :BILHETE-NUM-BILHETE FROM SEGUROS.CONVERSAO_SICOB A WHERE A.NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-MOVIMCOB-SECTION */
        private void R0450_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -802- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -823- PERFORM R0450_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0450_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -827- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -829- MOVE '*' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("*", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -830- ELSE */
            }
            else
            {


                /*" -831- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0450_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -823- EXEC SQL SELECT SIT_REGISTRO INTO :MOVIMCOB-SIT-REGISTRO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO AND NUM_TITULO = :MOVIMCOB-NUM-TITULO AND NUM_APOLICE = :MOVIMCOB-NUM-APOLICE AND NUM_ENDOSSO = :MOVIMCOB-NUM-ENDOSSO AND NUM_PARCELA = :MOVIMCOB-NUM-PARCELA AND NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO WITH UR END-EXEC. */

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
            /*" -844- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -847- PERFORM R0510-00-SELECT-V0CEDENTE. */

            R0510_00_SELECT_V0CEDENTE_SECTION();

            /*" -850- PERFORM R0530-00-CALCULA-TITULO. */

            R0530_00_CALCULA_TITULO_SECTION();

            /*" -850- PERFORM R0550-00-UPDATE-V0CEDENTE. */

            R0550_00_UPDATE_V0CEDENTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-SELECT-V0CEDENTE-SECTION */
        private void R0510_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -862- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -869- PERFORM R0510_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0510_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -873- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -874- DISPLAY ' R0510-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($" R0510-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -877- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -879- MOVE CEDENTE-NUM-TITULO TO WWORK-MIN-NRTIT. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, AREA_DE_WORK.WWORK_MIN_NRTIT);

            /*" -880- MOVE CEDENTE-NUM-TITULO-MAX TO WWORK-MAX-NRTIT. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX, AREA_DE_WORK.WWORK_MAX_NRTIT);

        }

        [StopWatch]
        /*" R0510-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0510_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -869- EXEC SQL SELECT NUM_TITULO , NUM_TITULO_MAX INTO :CEDENTE-NUM-TITULO , :CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 26 END-EXEC. */

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
            /*" -893- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -894- ADD 1 TO WWORK-MINNRO */
            AREA_DE_WORK.FILLER_11.WWORK_MINNRO.Value = AREA_DE_WORK.FILLER_11.WWORK_MINNRO + 1;

            /*" -897- MOVE WWORK-MINNRO TO LPARM11. */
            _.Move(AREA_DE_WORK.FILLER_11.WWORK_MINNRO, LPARM11X.LPARM11);

            /*" -908- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            AREA_DE_WORK.WPARM11_AUX.Value = LPARM11X.FILLER_19.LPARM11_1 * 3 + LPARM11X.FILLER_19.LPARM11_2 * 2 + LPARM11X.FILLER_19.LPARM11_3 * 9 + LPARM11X.FILLER_19.LPARM11_4 * 8 + LPARM11X.FILLER_19.LPARM11_5 * 7 + LPARM11X.FILLER_19.LPARM11_6 * 6 + LPARM11X.FILLER_19.LPARM11_7 * 5 + LPARM11X.FILLER_19.LPARM11_8 * 4 + LPARM11X.FILLER_19.LPARM11_9 * 3 + LPARM11X.FILLER_19.LPARM11_10 * 2;

            /*" -911- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(AREA_DE_WORK.WPARM11_AUX, 11, AREA_DE_WORK.WS_RESULT, AREA_DE_WORK.WS_RESTO);

            /*" -912- IF WS-RESTO EQUAL ZEROS */

            if (AREA_DE_WORK.WS_RESTO == 00)
            {

                /*" -913- MOVE 0 TO WWORK-MINDIG */
                _.Move(0, AREA_DE_WORK.FILLER_11.WWORK_MINDIG);

                /*" -914- ELSE */
            }
            else
            {


                /*" -918- SUBTRACT WS-RESTO FROM 11 GIVING WWORK-MINDIG. */
                AREA_DE_WORK.FILLER_11.WWORK_MINDIG.Value = 11 - AREA_DE_WORK.WS_RESTO;
            }


            /*" -919- IF WWORK-MIN-NRTIT GREATER WWORK-MAX-NRTIT */

            if (AREA_DE_WORK.WWORK_MIN_NRTIT > AREA_DE_WORK.WWORK_MAX_NRTIT)
            {

                /*" -920- DISPLAY 'R0530-00 - ABEND CONTROLADO                ' */
                _.Display($"R0530-00 - ABEND CONTROLADO                ");

                /*" -921- DISPLAY '*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    ' */
                _.Display($"*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    ");

                /*" -922- DISPLAY '    ' WWORK-MIN-NRTIT */
                _.Display($"    {AREA_DE_WORK.WWORK_MIN_NRTIT}");

                /*" -922- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-UPDATE-V0CEDENTE-SECTION */
        private void R0550_00_UPDATE_V0CEDENTE_SECTION()
        {
            /*" -935- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -938- MOVE WWORK-MIN-NRTIT TO CEDENTE-NUM-TITULO. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -942- PERFORM R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1 */

            R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1();

            /*" -945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -946- DISPLAY 'R0550-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' */
                _.Display($"R0550-00 - PROBLEMAS UPDATE (V0CEDENTE)   ");

                /*" -946- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0550-00-UPDATE-V0CEDENTE-DB-UPDATE-1 */
        public void R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -942- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO WHERE COD_CEDENTE = 26 END-EXEC. */

            var r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 = new R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
            };

            R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-CONVERSI-SECTION */
        private void R1100_00_INSERT_CONVERSI_SECTION()
        {
            /*" -959- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -961- MOVE WWORK-MIN-NRTIT TO CONVERSI-NUM-SICOB. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

            /*" -963- MOVE 1 TO CONVERSI-COD-EMPRESA-SIVPF. */
            _.Move(1, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF);

            /*" -965- MOVE 8144 TO CONVERSI-COD-PRODUTO-SIVPF. */
            _.Move(8144, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);

            /*" -967- MOVE BILHETE-AGE-COBRANCA TO CONVERSI-AGEPGTO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO);

            /*" -969- MOVE BILHETE-DATA-VENDA TO CONVERSI-DATA-OPERACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO);

            /*" -971- MOVE BILHETE-DATA-QUITACAO TO CONVERSI-DATA-QUITACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO);

            /*" -973- MOVE BILHETE-VAL-RCAP TO CONVERSI-VAL-RCAP. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP);

            /*" -977- MOVE BILHETE-COD-USUARIO TO CONVERSI-COD-USUARIO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_USUARIO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO);

            /*" -1000- PERFORM R1100_00_INSERT_CONVERSI_DB_INSERT_1 */

            R1100_00_INSERT_CONVERSI_DB_INSERT_1();

            /*" -1004- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1005- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1006- PERFORM R1150-00-TRATA-DUPLICI-SICOB */

                    R1150_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -1007- ELSE */
                }
                else
                {


                    /*" -1010- DISPLAY 'R1100-00 - PROBLEMAS NO INSERT(CONVERSI) ' '   ' CONVERSI-NUM-PROPOSTA-SIVPF '   ' CONVERSI-NUM-SICOB */

                    $"R1100-00 - PROBLEMAS NO INSERT(CONVERSI)    {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF}   {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB}"
                    .Display();

                    /*" -1010- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-INSERT-CONVERSI-DB-INSERT-1 */
        public void R1100_00_INSERT_CONVERSI_DB_INSERT_1()
        {
            /*" -1000- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB (NUM_PROPOSTA_SIVPF , NUM_SICOB , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , AGEPGTO , DATA_OPERACAO , DATA_QUITACAO , VAL_RCAP , COD_USUARIO , TIMESTAMP) VALUES (:CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-NUM-SICOB , :CONVERSI-COD-EMPRESA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF , :CONVERSI-AGEPGTO , :CONVERSI-DATA-OPERACAO , :CONVERSI-DATA-QUITACAO , :CONVERSI-VAL-RCAP , :CONVERSI-COD-USUARIO , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -1022- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1023- PERFORM R0530-00-CALCULA-TITULO */

            R0530_00_CALCULA_TITULO_SECTION();

            /*" -1024- PERFORM R0550-00-UPDATE-V0CEDENTE */

            R0550_00_UPDATE_V0CEDENTE_SECTION();

            /*" -1024- PERFORM R1100-00-INSERT-CONVERSI. */

            R1100_00_INSERT_CONVERSI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-MOVIMCOB-SECTION */
        private void R4000_00_INSERT_MOVIMCOB_SECTION()
        {
            /*" -1035- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1078- PERFORM R4000_00_INSERT_MOVIMCOB_DB_INSERT_1 */

            R4000_00_INSERT_MOVIMCOB_DB_INSERT_1();

            /*" -1082- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1087- DISPLAY 'R4000-00 - PROBLEMAS NO INSERT(MOVIMCOB)   ' '   ' MOVCC-REGISTRO '   ' MOVIMCOB-NUM-AVISO '   ' MOVIMCOB-NUM-TITULO '   ' MOVIMCOB-NUM-NOSSO-TITULO */

                $"R4000-00 - PROBLEMAS NO INSERT(MOVIMCOB)      {MOVCC_REGISTRO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                .Display();

                /*" -1090- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1090- ADD 1 TO AC-MOVIMCOB. */
            AREA_DE_WORK.AC_MOVIMCOB.Value = AREA_DE_WORK.AC_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R4000-00-INSERT-MOVIMCOB-DB-INSERT-1 */
        public void R4000_00_INSERT_MOVIMCOB_DB_INSERT_1()
        {
            /*" -1078- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_COBRANCA (COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_IOCC , VAL_CREDITO , SIT_REGISTRO , TIMESTAMP , NOME_SEGURADO , TIPO_MOVIMENTO , NUM_NOSSO_TITULO) VALUES (:MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , CURRENT TIMESTAMP , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-TIPO-MOVIMENTO , :MOVIMCOB-NUM-NOSSO-TITULO) END-EXEC. */

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
        /*" R4500-00-TRATA-AVISO-CREDITO-SECTION */
        private void R4500_00_TRATA_AVISO_CREDITO_SECTION()
        {
            /*" -1102- MOVE '4500' TO WNR-EXEC-SQL. */
            _.Move("4500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1104- MOVE 104 TO AVISOCRE-BCO-AVISO */
            _.Move(104, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

            /*" -1106- MOVE 8010 TO AVISOCRE-AGE-AVISO */
            _.Move(8010, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

            /*" -1108- MOVE WS-NRAVISO TO AVISOCRE-NUM-AVISO-CREDITO */
            _.Move(AREA_DE_WORK.WS_NRAVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

            /*" -1110- MOVE 1 TO AVISOCRE-NUM-SEQUENCIA */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);

            /*" -1112- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOCRE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO);

            /*" -1115- MOVE 100 TO AVISOCRE-COD-OPERACAO. */
            _.Move(100, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO);

            /*" -1117- PERFORM R4600-LER-AVISO-CREDITO. */

            R4600_LER_AVISO_CREDITO_SECTION();

            /*" -1118- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1119- PERFORM R4700-00-UPDATE-AVISOCRED */

                R4700_00_UPDATE_AVISOCRED_SECTION();

                /*" -1123- GO TO R4500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1125- MOVE 'R' TO AVISOCRE-TIPO-AVISO */
            _.Move("R", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);

            /*" -1127- MOVE WSHOST-DATA-AVISO TO AVISOCRE-DATA-AVISO */
            _.Move(WSHOST_DATA_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);

            /*" -1129- MOVE ZEROS TO AVISOCRE-VAL-IOCC */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC);

            /*" -1131- MOVE WSHOST-VAL-DESPESA TO AVISOCRE-VAL-DESPESA */
            _.Move(WSHOST_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);

            /*" -1133- MOVE ZEROS TO AVISOCRE-PRM-COSSEGURO-CED */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED);

            /*" -1135- MOVE WSHOST-PRM-LIQUIDO TO AVISOCRE-PRM-LIQUIDO */
            _.Move(WSHOST_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO);

            /*" -1137- MOVE WSHOST-PRM-TOTAL TO AVISOCRE-PRM-TOTAL */
            _.Move(WSHOST_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL);

            /*" -1139- MOVE '0' TO AVISOCRE-SIT-CONTABIL */
            _.Move("0", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL);

            /*" -1141- MOVE ZEROS TO AVISOCRE-COD-EMPRESA */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA);

            /*" -1143- MOVE 1 TO AVISOCRE-ORIGEM-AVISO */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);

            /*" -1146- MOVE ZEROS TO AVISOCRE-VAL-ADIANTAMENTO. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO);

            /*" -1148- MOVE 'P' TO AVISOCRE-STA-DEPOSITO-TER. */
            _.Move("P", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER);

            /*" -1189- PERFORM R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1 */

            R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1();

            /*" -1192- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1193- DISPLAY 'R4500-00 - PROBLEMAS NO INSERT(AVISOCRE) ' */
                _.Display($"R4500-00 - PROBLEMAS NO INSERT(AVISOCRE) ");

                /*" -1193- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4500-00-TRATA-AVISO-CREDITO-DB-INSERT-1 */
        public void R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1()
        {
            /*" -1189- EXEC SQL INSERT INTO SEGUROS.AVISO_CREDITO (BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , COD_OPERACAO , TIPO_AVISO , DATA_AVISO , VAL_IOCC , VAL_DESPESA , PRM_COSSEGURO_CED , PRM_LIQUIDO , PRM_TOTAL , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP , ORIGEM_AVISO , VAL_ADIANTAMENTO , STA_DEPOSITO_TER) VALUES (:AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-COD-OPERACAO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-IOCC , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-COSSEGURO-CED , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-SIT-CONTABIL , :AVISOCRE-COD-EMPRESA , CURRENT TIMESTAMP , :AVISOCRE-ORIGEM-AVISO , :AVISOCRE-VAL-ADIANTAMENTO , :AVISOCRE-STA-DEPOSITO-TER) END-EXEC. */

            var r4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1_Insert1 = new R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1_Insert1()
            {
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_NUM_SEQUENCIA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA.ToString(),
                AVISOCRE_DATA_MOVIMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.ToString(),
                AVISOCRE_COD_OPERACAO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO.ToString(),
                AVISOCRE_TIPO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO.ToString(),
                AVISOCRE_DATA_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.ToString(),
                AVISOCRE_VAL_IOCC = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC.ToString(),
                AVISOCRE_VAL_DESPESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.ToString(),
                AVISOCRE_PRM_COSSEGURO_CED = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED.ToString(),
                AVISOCRE_PRM_LIQUIDO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.ToString(),
                AVISOCRE_PRM_TOTAL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.ToString(),
                AVISOCRE_SIT_CONTABIL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL.ToString(),
                AVISOCRE_COD_EMPRESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA.ToString(),
                AVISOCRE_ORIGEM_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO.ToString(),
                AVISOCRE_VAL_ADIANTAMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO.ToString(),
                AVISOCRE_STA_DEPOSITO_TER = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER.ToString(),
            };

            R4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1_Insert1.Execute(r4500_00_TRATA_AVISO_CREDITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-LER-AVISO-CREDITO-SECTION */
        private void R4600_LER_AVISO_CREDITO_SECTION()
        {
            /*" -1204- MOVE '4600' TO WNR-EXEC-SQL. */
            _.Move("4600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1225- PERFORM R4600_LER_AVISO_CREDITO_DB_SELECT_1 */

            R4600_LER_AVISO_CREDITO_DB_SELECT_1();

            /*" -1228- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1229- DISPLAY 'R4600-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                _.Display($"R4600-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                /*" -1229- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4600-LER-AVISO-CREDITO-DB-SELECT-1 */
        public void R4600_LER_AVISO_CREDITO_DB_SELECT_1()
        {
            /*" -1225- EXEC SQL SELECT VAL_DESPESA , PRM_LIQUIDO , PRM_TOTAL INTO :AVISOCRE-VAL-DESPESA ,:AVISOCRE-PRM-LIQUIDO ,:AVISOCRE-PRM-TOTAL FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOCRE-NUM-AVISO-CREDITO AND NUM_SEQUENCIA = :AVISOCRE-NUM-SEQUENCIA AND DATA_MOVIMENTO = :AVISOCRE-DATA-MOVIMENTO AND COD_OPERACAO = :AVISOCRE-COD-OPERACAO WITH UR END-EXEC. */

            var r4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1 = new R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1()
            {
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_DATA_MOVIMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.ToString(),
                AVISOCRE_NUM_SEQUENCIA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA.ToString(),
                AVISOCRE_COD_OPERACAO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO.ToString(),
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            var executed_1 = R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1.Execute(r4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);
                _.Move(executed_1.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO);
                _.Move(executed_1.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4700-00-UPDATE-AVISOCRED-SECTION */
        private void R4700_00_UPDATE_AVISOCRED_SECTION()
        {
            /*" -1240- MOVE '4700' TO WNR-EXEC-SQL. */
            _.Move("4700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1243- COMPUTE AVISOCRE-VAL-DESPESA = AVISOCRE-VAL-DESPESA + WSHOST-VAL-DESPESA. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA + WSHOST_VAL_DESPESA;

            /*" -1246- COMPUTE AVISOCRE-PRM-LIQUIDO = AVISOCRE-PRM-LIQUIDO + WSHOST-PRM-LIQUIDO. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO + WSHOST_PRM_LIQUIDO;

            /*" -1249- COMPUTE AVISOCRE-PRM-TOTAL = AVISOCRE-PRM-TOTAL + WSHOST-PRM-TOTAL. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL + WSHOST_PRM_TOTAL;

            /*" -1269- PERFORM R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1 */

            R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1();

            /*" -1272- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1273- DISPLAY 'R4700-00 - PROBLEMAS UPDATE (AVISOCRE)   ' */
                _.Display($"R4700-00 - PROBLEMAS UPDATE (AVISOCRE)   ");

                /*" -1273- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4700-00-UPDATE-AVISOCRED-DB-UPDATE-1 */
        public void R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1()
        {
            /*" -1269- EXEC SQL UPDATE SEGUROS.AVISO_CREDITO SET VAL_DESPESA = :AVISOCRE-VAL-DESPESA , PRM_LIQUIDO = :AVISOCRE-PRM-LIQUIDO , PRM_TOTAL = :AVISOCRE-PRM-TOTAL WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOCRE-NUM-AVISO-CREDITO AND NUM_SEQUENCIA = :AVISOCRE-NUM-SEQUENCIA AND DATA_MOVIMENTO = :AVISOCRE-DATA-MOVIMENTO AND COD_OPERACAO = :AVISOCRE-COD-OPERACAO END-EXEC. */

            var r4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1 = new R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1()
            {
                AVISOCRE_VAL_DESPESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.ToString(),
                AVISOCRE_PRM_LIQUIDO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.ToString(),
                AVISOCRE_PRM_TOTAL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.ToString(),
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_DATA_MOVIMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.ToString(),
                AVISOCRE_NUM_SEQUENCIA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA.ToString(),
                AVISOCRE_COD_OPERACAO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO.ToString(),
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1.Execute(r4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4700_99_SAIDA*/

        [StopWatch]
        /*" R4800-00-TRATA-AVISO-SALDOS-SECTION */
        private void R4800_00_TRATA_AVISO_SALDOS_SECTION()
        {
            /*" -1284- MOVE '4800' TO WNR-EXEC-SQL. */
            _.Move("4800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1286- MOVE ZEROS TO AVISOSAL-COD-EMPRESA */
            _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA);

            /*" -1288- MOVE 104 TO AVISOSAL-BCO-AVISO */
            _.Move(104, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -1290- MOVE 8010 TO AVISOSAL-AGE-AVISO */
            _.Move(8010, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -1292- MOVE '1' TO AVISOSAL-TIPO-SEGURO */
            _.Move("1", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO);

            /*" -1294- MOVE WS-NRAVISO TO AVISOSAL-NUM-AVISO-CREDITO */
            _.Move(AREA_DE_WORK.WS_NRAVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -1297- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOSAL-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO);

            /*" -1299- PERFORM R4900-LER-AVISOS-SALDOS. */

            R4900_LER_AVISOS_SALDOS_SECTION();

            /*" -1300- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1301- PERFORM R5000-00-UPDATE-AVISOSAL */

                R5000_00_UPDATE_AVISOSAL_SECTION();

                /*" -1305- GO TO R4800-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4800_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1307- MOVE WSHOST-DATA-AVISO TO AVISOSAL-DATA-AVISO */
            _.Move(WSHOST_DATA_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO);

            /*" -1309- MOVE WSHOST-PRM-TOTAL TO AVISOSAL-SALDO-ATUAL */
            _.Move(WSHOST_PRM_TOTAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

            /*" -1312- MOVE '0' TO AVISOSAL-SIT-REGISTRO. */
            _.Move("0", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);

            /*" -1335- PERFORM R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1 */

            R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1();

            /*" -1338- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1339- DISPLAY 'R4800-00 - PROBLEMAS NO INSERT(AVISOSAL) ' */
                _.Display($"R4800-00 - PROBLEMAS NO INSERT(AVISOSAL) ");

                /*" -1339- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4800-00-TRATA-AVISO-SALDOS-DB-INSERT-1 */
        public void R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1()
        {
            /*" -1335- EXEC SQL INSERT INTO SEGUROS.AVISOS_SALDOS (COD_EMPRESA , BCO_AVISO , AGE_AVISO , TIPO_SEGURO , NUM_AVISO_CREDITO , DATA_AVISO , DATA_MOVIMENTO , SALDO_ATUAL , SIT_REGISTRO , TIMESTAMP) VALUES (:AVISOSAL-COD-EMPRESA , :AVISOSAL-BCO-AVISO , :AVISOSAL-AGE-AVISO , :AVISOSAL-TIPO-SEGURO , :AVISOSAL-NUM-AVISO-CREDITO , :AVISOSAL-DATA-AVISO , :AVISOSAL-DATA-MOVIMENTO , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO , CURRENT TIMESTAMP) END-EXEC. */

            var r4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1_Insert1 = new R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1_Insert1()
            {
                AVISOSAL_COD_EMPRESA = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
                AVISOSAL_TIPO_SEGURO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO.ToString(),
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_DATA_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.ToString(),
                AVISOSAL_DATA_MOVIMENTO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.ToString(),
                AVISOSAL_SALDO_ATUAL = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.ToString(),
                AVISOSAL_SIT_REGISTRO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO.ToString(),
            };

            R4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1_Insert1.Execute(r4800_00_TRATA_AVISO_SALDOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4800_99_SAIDA*/

        [StopWatch]
        /*" R4900-LER-AVISOS-SALDOS-SECTION */
        private void R4900_LER_AVISOS_SALDOS_SECTION()
        {
            /*" -1350- MOVE '4900' TO WNR-EXEC-SQL. */
            _.Move("4900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1363- PERFORM R4900_LER_AVISOS_SALDOS_DB_SELECT_1 */

            R4900_LER_AVISOS_SALDOS_DB_SELECT_1();

            /*" -1366- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1367- DISPLAY 'R4900-00 - PROBLEMAS NO SELECT(AVISOSAL)' */
                _.Display($"R4900-00 - PROBLEMAS NO SELECT(AVISOSAL)");

                /*" -1367- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4900-LER-AVISOS-SALDOS-DB-SELECT-1 */
        public void R4900_LER_AVISOS_SALDOS_DB_SELECT_1()
        {
            /*" -1363- EXEC SQL SELECT SALDO_ATUAL INTO :AVISOSAL-SALDO-ATUAL FROM SEGUROS.AVISOS_SALDOS WHERE AGE_AVISO = :AVISOSAL-AGE-AVISO AND TIPO_SEGURO = :AVISOSAL-TIPO-SEGURO AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO AND DATA_MOVIMENTO = :AVISOSAL-DATA-MOVIMENTO WITH UR END-EXEC. */

            var r4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1 = new R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1()
            {
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_DATA_MOVIMENTO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.ToString(),
                AVISOSAL_TIPO_SEGURO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
            };

            var executed_1 = R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1.Execute(r4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4900_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-UPDATE-AVISOSAL-SECTION */
        private void R5000_00_UPDATE_AVISOSAL_SECTION()
        {
            /*" -1378- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1381- COMPUTE AVISOSAL-SALDO-ATUAL = AVISOSAL-SALDO-ATUAL + WSHOST-PRM-TOTAL. */
            AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.Value = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL + WSHOST_PRM_TOTAL;

            /*" -1393- PERFORM R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1 */

            R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1();

            /*" -1396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1397- DISPLAY 'R5000-00 - PROBLEMAS UPDATE (AVISOSAL)   ' */
                _.Display($"R5000-00 - PROBLEMAS UPDATE (AVISOSAL)   ");

                /*" -1397- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-UPDATE-AVISOSAL-DB-UPDATE-1 */
        public void R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1()
        {
            /*" -1393- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = :AVISOSAL-SALDO-ATUAL WHERE AGE_AVISO = :AVISOSAL-AGE-AVISO AND TIPO_SEGURO = :AVISOSAL-TIPO-SEGURO AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO AND DATA_MOVIMENTO = :AVISOSAL-DATA-MOVIMENTO END-EXEC. */

            var r5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 = new R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1()
            {
                AVISOSAL_SALDO_ATUAL = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.ToString(),
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_DATA_MOVIMENTO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.ToString(),
                AVISOSAL_TIPO_SEGURO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
            };

            R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1.Execute(r5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1407- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1408- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLERRD1);

            /*" -1409- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLERRD2);

            /*" -1411- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERR.WSQLERRMC);

            /*" -1412- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1414- DISPLAY WSQLERR. */
            _.Display(AREA_DE_WORK.WSQLERR);

            /*" -1414- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1418- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -1420- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1420- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}