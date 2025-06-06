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
using Sias.PessoaFisica.DB2.PF2002B;

namespace Code
{
    public class PF2002B
    {
        public bool IsCall { get; set; }

        public PF2002B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  PF2002B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  ELIERMES                           *      */
        /*"      *   DATA CODIFICACAO .......  14/10/2016                         *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CONSISTENCIA E CONTROLE DO         *      */
        /*"      *                             MOVIMENTO DE COBRANCA DE BOLETOS   *      */
        /*"      *                             REGISTRADOS DA CAIXA - SIGCB.      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      ALTERACOES                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 30/01/2024 *      */
        /*"      *   VERSAO 33               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
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
        /*"      *                           - PROCURAR POR V.33                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 32             INCLUSAO TRATAMENTO SQLCODE=-803 NO      *      */
        /*"      *                       INSERT DA SEGUROS.CONTROL_DESPES_CEF.    *      */
        /*"      * ATENDE INCIDENTE 433607                                        *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.32          BRICE HO                                 *      */
        /*"      *                       06/10/2022                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 31             INCLUSAO TRATAMENTO CANAL 7              *      */
        /*"      * ATENDE DEMANDA 418888                                          *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.31          BRICE HO                                 *      */
        /*"      *                       30/09/2022                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 30             INCLUSAO DAS NOVAS AGENCIA NO SELECT MAX *      */
        /*"      *                       DA TABELA SEGUROS.V0MOVICOB PARA RETIRADA*      */
        /*"      *                       ABEND -803 NA TABELA CONTROL_DESPES_CEF  *      */
        /*"      * ATENDE abend 318035                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.30          EVILASIO SILVA                           *      */
        /*"      *                       17/09/2021                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * DEMAIS ALTERACOES: VIDE HISTORICO NO FINAL DO PROGRAMA         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO_COBRANCA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis MOVIMENTO_COBRANCA
        {
            get
            {
                _.Move(REG_COBRANCA, _MOVIMENTO_COBRANCA); VarBasis.RedefinePassValue(REG_COBRANCA, _MOVIMENTO_COBRANCA, REG_COBRANCA); return _MOVIMENTO_COBRANCA;
            }
        }
        public FileBasis _PF2002B1 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis PF2002B1
        {
            get
            {
                _.Move(REG_PF2002B1, _PF2002B1); VarBasis.RedefinePassValue(REG_PF2002B1, _PF2002B1, REG_PF2002B1); return _PF2002B1;
            }
        }
        public SortBasis<PF2002B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<PF2002B_REG_ARQSORT>(new PF2002B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public PF2002B_REG_ARQSORT REG_ARQSORT { get; set; } = new PF2002B_REG_ARQSORT();
        public class PF2002B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-DETALHE         PIC  X(370).*/
            public StringBasis SOR_DETALHE { get; set; } = new StringBasis(new PIC("X", "370", "X(370)."), @"");
            /*"  05      SOR-AGE-AVISO       PIC  9(004).*/
            public IntBasis SOR_AGE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-TIPO-AVISO      PIC  X(001).*/
            public StringBasis SOR_TIPO_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-TIPO-MOVIMENTO  PIC  X(001).*/
            public StringBasis SOR_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-CANAL-VENDA     PIC  9(001).*/
            public IntBasis SOR_CANAL_VENDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      SOR-PROD-SIVPF      PIC  9(002).*/
            public IntBasis SOR_PROD_SIVPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01        REG-COBRANCA.*/
        }
        public PF2002B_REG_COBRANCA REG_COBRANCA { get; set; } = new PF2002B_REG_COBRANCA();
        public class PF2002B_REG_COBRANCA : VarBasis
        {
            /*"  05      ENT-CODREGISTR      PIC  X(001).*/
            public StringBasis ENT_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      ENT-DETALHE         PIC  X(399).*/
            public StringBasis ENT_DETALHE { get; set; } = new StringBasis(new PIC("X", "399", "X(399)."), @"");
            /*"01  REG-PF2002B1                 PIC  X(400).*/
        }
        public StringBasis REG_PF2002B1 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_CDT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_PRO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_CED { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  PF2002B-SYSIN.*/
        public PF2002B_PF2002B_SYSIN PF2002B_SYSIN { get; set; } = new PF2002B_PF2002B_SYSIN();
        public class PF2002B_PF2002B_SYSIN : VarBasis
        {
            /*"    03 PF2002B-TRACE              PIC X(003) VALUE SPACES.*/
            public StringBasis PF2002B_TRACE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    03 FILLER                     PIC X(077).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"77  W-PROGRAMA-CHAMADOR           PIC X(007) VALUE 'PF2002B'.*/
        }
        public StringBasis W_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PF2002B");
        /*"01  W-CT-TRACE                    PIC X(003) VALUE 'SIM'.*/

        public SelectorBasis W_CT_TRACE { get; set; } = new SelectorBasis("003", "SIM")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 W-CT-TRACE-ON              VALUE 'SIM'. */
							new SelectorItemBasis("W_CT_TRACE_ON", "SIM"),
							/*" 88 W-CT-TRACE-DET-ON          VALUE 'SIM'. */
							new SelectorItemBasis("W_CT_TRACE_DET_ON", "SIM")
                }
        };

        /*"77  W-PROG-OK                     PIC X(003) VALUE 'SIM'.*/
        public StringBasis W_PROG_OK { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
        /*"77  W-MENSAGEM-ERRO               PIC X(080) VALUE SPACES.*/
        public StringBasis W_MENSAGEM_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"77  W-COUNT-INSERT                PIC 9(009) VALUE 0.*/
        public IntBasis W_COUNT_INSERT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77 WS-FLAG-CCA-LOT                PIC 9(01) VALUE 0.*/
        public IntBasis WS_FLAG_CCA_LOT { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77    VIND-CODEMP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORIGAVISO            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADT               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMAPOL              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRENDOS              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRPARCEL             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRTIT                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RECUPERA             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_RECUPERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ACRESCIMO            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ACRESCIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRGER            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTGER            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADTGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGGER             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTPAGGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCANCEL             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRSUN            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTSUN            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADTSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGSUN             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTPAGSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPO                 PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_TIPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL01               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)      COMP   VALUE +0*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-COUNT-AVS           PIC S9(004)     COMP.*/
        public IntBasis WHOST_COUNT_AVS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-CODPRODU            PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    WW-NRRCAP-X.*/
        public PF2002B_WW_NRRCAP_X WW_NRRCAP_X { get; set; } = new PF2002B_WW_NRRCAP_X();
        public class PF2002B_WW_NRRCAP_X : VarBasis
        {
            /*"  03  WW-NRRCAP-9               PIC 9(010) VALUE ZEROS.*/
            public IntBasis WW_NRRCAP_9 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"77    V0SIST-DTMOVABE           PIC  X(010).*/
        }
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0AGEN-BANCO              PIC S9(004)    COMP.*/
        public IntBasis V0AGEN_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AGEN-AGENCIA            PIC S9(004)    COMP.*/
        public IntBasis V0AGEN_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AGEN-ESTADO             PIC  X(002).*/
        public StringBasis V0AGEN_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77    V0ACEF-AGENCIA            PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-ESCNEG             PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ACEF-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0ACEF_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PRPF-CODSIVPF           PIC S9(004)    COMP.*/
        public IntBasis V0PRPF_CODSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PRPF-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0PRPF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PROD-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SFRC-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0SFRC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SFRC-NRTIT              PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0SFRC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MSIN-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis V0MSIN_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MSIN-NUMAPOL            PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0MSIN_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MSIN-NUM-APOL-SINISTRO  PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0MSIN_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MSIN-NUM-NOSSO-TITULO   PIC S9(016)    VALUE +0   COMP-3*/
        public IntBasis V0MSIN_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77    V0MSIN-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0MSIN_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MSIN-ACORDO             PIC S9(009)    COMP.*/
        public IntBasis V0MSIN_ACORDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0BCOB-RAMOFR             PIC S9(004)     COMP.*/
        public IntBasis V0BCOB_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BCOB-CODOPCAO           PIC S9(004)     COMP.*/
        public IntBasis V0BCOB_CODOPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BCOB-VLPRMTAR           PIC S9(010)V9(5)     COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77    V0BCOB-VLPRMTOT           PIC S9(013)V99       COMP-3.*/
        public DoubleBasis V0BCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BCOB-PCIOCC             PIC S9(003)V99       COMP-3.*/
        public DoubleBasis V0BCOB_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77    VIND-VLPRMTOT             PIC S9(004)     COMP.*/
        public IntBasis VIND_VLPRMTOT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-PCIOCC               PIC S9(004)     COMP.*/
        public IntBasis VIND_PCIOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CEDE-NUMTIT             PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0CEDE_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CEDE-NUMTITMAX          PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0CEDE_NUMTITMAX { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CNAB-COD-EMP            PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-ORGAO              PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CNAB-NRCTACED           PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis V0CNAB_NRCTACED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CNAB-TIPOCOB            PIC  X(001).*/
        public StringBasis V0CNAB_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CNAB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CNAB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-DATCEF             PIC  X(010).*/
        public StringBasis V0CNAB_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-NRSEQ              PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-QTDREG             PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_QTDREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0AVIS-NRSEQ              PIC S9(009)     COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0AVIS-DTMOVTO            PIC  X(010).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0AVIS-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-TIPAVI             PIC  X(001).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0AVIS-DTAVISO            PIC  X(010).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0AVIS-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-VLDESPES           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-PRECED             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-SITCONTB           PIC  X(001).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0AVIS-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0AVIS_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0AVIS-ORIGAVISO          PIC S9(004)     COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0AVIS-VALADT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0AVIS-SITDEPTER          PIC  X(01).*/
        public StringBasis V0AVIS_SITDEPTER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77    V0SALD-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0SALD_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SALD-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0SALD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SALD-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0SALD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SALD-TIPSGU             PIC  X(001).*/
        public StringBasis V0SALD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0SALD-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0SALD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SALD-DTAVISO            PIC  X(010).*/
        public StringBasis V0SALD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SALD-DTMOVTO            PIC  X(010).*/
        public StringBasis V0SALD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SALD-SDOATU             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0SALD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SALD-SITUACAO           PIC  X(001).*/
        public StringBasis V0SALD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0SICB-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0SICB_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SICB-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0SICB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0SICB_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SICB-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0SICB_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0SICB-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0SICB_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-NRMATRVEN          PIC S9(015)     COMP-3.*/
        public IntBasis V0SICB_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0SICB-AGECTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0SICB_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-OPRCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0SICB_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-NUMCTAVEN          PIC S9(009)     COMP.*/
        public IntBasis V0SICB_NUMCTAVEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0SICB-DIGCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0SICB_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0SICB-VLCOMIS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0SICB_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SICB-DTCREDITO          PIC  X(010).*/
        public StringBasis V0SICB_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SICB-DTQITBCO           PIC  X(010).*/
        public StringBasis V0SICB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SICB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0SICB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0SICB-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0SICB_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0SICB-SITUACAO           PIC  X(001).*/
        public StringBasis V0SICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FILT-NUMSIVPF           PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis V0FILT_NUMSIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FILT-NUMSICOB           PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis V0FILT_NUMSICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FILT-CODEMP             PIC S9(004)    COMP.*/
        public IntBasis V0FILT_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-CODSIVPF           PIC S9(004)    COMP.*/
        public IntBasis V0FILT_CODSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-AGECOBR            PIC S9(004)    COMP.*/
        public IntBasis V0FILT_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FILT_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FILT-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FILT_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FILT-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FILT_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FILT-CODUSU             PIC  X(008).*/
        public StringBasis V0FILT_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FILT-COUNT              PIC S9(004)     COMP.*/
        public IntBasis V0FILT_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FILT-COUNT2             PIC S9(004)     COMP.*/
        public IntBasis V0FILT_COUNT2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CONVSICOB-NUM-PROP-SIVPF  PIC S9(15)     USAGE COMP-3.*/
        public IntBasis CONVSICOB_NUM_PROP_SIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77    CONVSICOB-NR-SICOB        PIC S9(015)    VALUE +0   COMP-3*/
        public IntBasis CONVSICOB_NR_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    CONVSICOB-AGEPGTO         PIC S9(004)               COMP.*/
        public IntBasis CONVSICOB_AGEPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    CONVSICOB-DTQITBCO        PIC  X(010).*/
        public StringBasis CONVSICOB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    CONVSICOB-VAL-RCAP        PIC S9(015)V99 VALUE +0   COMP-3*/
        public DoubleBasis CONVSICOB_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77    CONVSICOB-COD-USUARIO      PIC X(08).*/
        public StringBasis CONVSICOB_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77    V0PARC-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0PARC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0PARC-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0PARC-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0PARC-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V1ENDO-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-CODMOV             PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_CODMOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-BANCO              PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-AGENCIA            PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-NUMFITA            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NUMFITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0MCOB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MCOB-DTQITBCO           PIC  X(010).*/
        public StringBasis V0MCOB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MCOB-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0MCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MCOB-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0MCOB_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MCOB-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-VALTIT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VALTIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-VALCDT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VALCDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-SITUACAO           PIC  X(001).*/
        public StringBasis V0MCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MCOB-NOME               PIC  X(040).*/
        public StringBasis V0MCOB_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0MCOB-TIPOMOV            PIC  X(001).*/
        public StringBasis V0MCOB_TIPOMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MCOB-NUM-NOSSO-TITULO   PIC S9(16)  COMP-3 VALUE +0.*/
        public IntBasis V0MCOB_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77    V0FOLL-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0FOLL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FOLL-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DACPARC            PIC  X(001).*/
        public StringBasis V0FOLL_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FOLL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-HORAOPER           PIC  X(008).*/
        public StringBasis V0FOLL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FOLL-VLPREMIO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FOLL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FOLL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-CODBAIXA           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-CDERRO01           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO02           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO03           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO04           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO05           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO06           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITUACAO           PIC  X(001).*/
        public StringBasis V0FOLL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITCONTB           PIC  X(001).*/
        public StringBasis V0FOLL_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DTLIBER            PIC  X(010).*/
        public StringBasis V0FOLL_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FOLL_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-ORDLIDER           PIC S9(015)     COMP-3.*/
        public IntBasis V0FOLL_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FOLL-TIPSGU             PIC  X(001).*/
        public StringBasis V0FOLL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-APOLIDER           PIC  X(015).*/
        public StringBasis V0FOLL_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-ENDOSLID           PIC  X(015).*/
        public StringBasis V0FOLL_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-CODLIDER           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NUM-NOSSO-TITULO   PIC S9(16)  COMP-3 VALUE +0.*/
        public IntBasis V0FOLL_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"77    V0RCAP-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NRPROPOS           PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NOME               PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0RCAP-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-VALPRI             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-DTMOVTO            PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCAP-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCAP-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0RCAP_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCAP-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0RCAP-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0RCAP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCAP-RECUPERA           PIC  X(001).*/
        public StringBasis V0RCAP_RECUPERA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCAP-ACRESCIMO          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCAP_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCAP-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis V0RCAP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0RCOM-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-NRRCAPCO           PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-DTMOVTO            PIC  X(010).*/
        public StringBasis V0RCOM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-HORAOPER           PIC  X(010).*/
        public StringBasis V0RCOM_HORAOPER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITUACAO           PIC  X(001).*/
        public StringBasis V0RCOM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCOM-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0RCOM_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0RCOM-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0RCOM-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0RCOM_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0RCOM-DATARCAP           PIC  X(010).*/
        public StringBasis V0RCOM_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-DTCADAST           PIC  X(010).*/
        public StringBasis V0RCOM_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0RCOM-SITCONTB           PIC  X(001).*/
        public StringBasis V0RCOM_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0RCOM-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0RCOM_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V1RCAP-NRTIT              PIC S9(013) VALUE +0  COMP-3.*/
        public IntBasis V1RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CFEN-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-VALADT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTCREDITO          PIC  X(010).*/
        public StringBasis V0CFEN_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-NRMATRVEN          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-AGECTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-OPRCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-NUMCTAVEN          PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_NUMCTAVEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-DIGCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-AGECTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-OPRCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-NUMCTADEB          PIC S9(009)     COMP.*/
        public IntBasis V0CFEN_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CFEN-DIGCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0CFEN_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CFEN-SINDICO            PIC  X(040).*/
        public StringBasis V0CFEN_SINDICO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0CFEN-DTQITBCO           PIC  X(010).*/
        public StringBasis V0CFEN_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CFEN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-SITUACAO           PIC  X(001).*/
        public StringBasis V0CFEN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CFEN-NRMATRGER          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-VALADTGER          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADTGER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTPAGGER           PIC  X(010).*/
        public StringBasis V0CFEN_DTPAGGER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-DTCANCEL           PIC  X(010).*/
        public StringBasis V0CFEN_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CFEN-NRMATRSUN          PIC S9(015)     COMP-3.*/
        public IntBasis V0CFEN_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0CFEN-VALADTSUN          PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0CFEN_VALADTSUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0CFEN-DTPAGSUN           PIC  X(010).*/
        public StringBasis V0CFEN_DTPAGSUN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0VEND-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0VEND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0VEND-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0VEND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0VEND-DTQITBCO           PIC  X(010).*/
        public StringBasis V0VEND_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0VEND-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0VEND_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0VEND-DTMOVTO            PIC  X(010).*/
        public StringBasis V0VEND_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TRBL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0TRBL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TRBL-MATRICULA          PIC S9(015)     COMP-3.*/
        public IntBasis V0TRBL_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0TRBL-TIPOFUNC           PIC  X(001).*/
        public StringBasis V0TRBL_TIPOFUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0TRBL-NRCERTIF           PIC S9(015)     COMP-3.*/
        public IntBasis V0TRBL_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0TRBL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0TRBL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0TRBL-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-SITUACAO           PIC  X(001).*/
        public StringBasis V0TRBL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0TRBL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-ESCNEG             PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0TRBL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0TRBL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0TRBL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0TRBL-TARIFA             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0TRBL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0TRBL-BALCAO             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0TRBL_BALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0ADIA-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0ADIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ADIA-NUMOPG             PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-VALADT             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0ADIA_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0ADIA-QTPRESTA           PIC S9(004)    COMP.*/
        public IntBasis V0ADIA_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ADIA-NRPROPOS           PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0ADIA_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0ADIA-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0ADIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0ADIA-DTMOVTO            PIC  X(010).*/
        public StringBasis V0ADIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0ADIA-SITUACAO           PIC  X(001).*/
        public StringBasis V0ADIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0ADIA-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0ADIA_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0ADIA-TIPO               PIC  X(001).*/
        public StringBasis V0ADIA_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FREC-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0FREC_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0FREC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FREC-NUMOPG             PIC S9(009)    COMP.*/
        public IntBasis V0FREC_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-NRPROPOS           PIC S9(009)    COMP.*/
        public IntBasis V0FREC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0FREC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FREC-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0FREC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FREC-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0FREC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FREC-NUMPTC             PIC S9(004)    COMP.*/
        public IntBasis V0FREC_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FREC-VALRCP             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0FREC_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FREC-PCGACM             PIC S9(002)V999 COMP-3.*/
        public DoubleBasis V0FREC_PCGACM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V999"), 3);
        /*"77    V0FREC-SITUACAO           PIC  X(001).*/
        public StringBasis V0FREC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FREC-VALSDO             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0FREC_VALSDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FREC-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FREC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FREC-DTVENCTO           PIC  X(010).*/
        public StringBasis V0FREC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FREC-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0FREC_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0HREC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-NUMOPG             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-NRPROPOS           PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0HREC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0HREC-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0HREC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-NUMPTC             PIC S9(004)    COMP.*/
        public IntBasis V0HREC_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-VALRCP             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HREC_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0HREC-NUMREC             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0HREC-DTMOVTO            PIC  X(010).*/
        public StringBasis V0HREC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0HREC-OPERACAO           PIC S9(004)    COMP.*/
        public IntBasis V0HREC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0HREC-HORSIS             PIC  X(008).*/
        public StringBasis V0HREC_HORSIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0HREC-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0HREC_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-ANOREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_ANOREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-MESREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_MESREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-TIPOREG            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-SITUACAO           PIC  X(001).*/
        public StringBasis V0DPCF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-TIPOCOB            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-DTMOVTO            PIC  X(010).*/
        public StringBasis V0DPCF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0DPCF-DTAVISO            PIC  X(010).*/
        public StringBasis V0DPCF_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0DPCF-QTDREG             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLJUROS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLMULTA            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-QTDREG-TOT         PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG_TOT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-VLPRMTOT-TOT       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLPRMLIQ-TOT       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLPRMLI-TOT        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLI_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLTARIFA-TOT       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLBALCAO-TOT       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLIOCC-TOT         PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLDESCON-TOT       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLJUROS-TOT        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLMULTA-TOT        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*" 01        REG-SIGC13.*/
        public PF2002B_REG_SIGC13 REG_SIGC13 { get; set; } = new PF2002B_REG_SIGC13();
        public class PF2002B_REG_SIGC13 : VarBasis
        {
            /*"   05      SIGC13-DETALHE.*/
            public PF2002B_SIGC13_DETALHE SIGC13_DETALHE { get; set; } = new PF2002B_SIGC13_DETALHE();
            public class PF2002B_SIGC13_DETALHE : VarBasis
            {
                /*"      10   SIGC13-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SIGC13_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      10   SIGC13-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SIGC13_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"      10   SIGC13-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SIGC13_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10   SIGC13-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SIGC13_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10   SIGC13-NSAC              PIC  9(005) VALUE ZEROS.*/
                public IntBasis SIGC13_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      10   SIGC13-NUM-PROPOSTA      PIC  9(016) VALUE ZEROS.*/
                public IntBasis SIGC13_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
                /*"      10   SIGC13-NUM-BOL-INTERNO   PIC  X(010) VALUE SPACES.*/
                public StringBasis SIGC13_NUM_BOL_INTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10   SIGC13-NN-REGISTRADO     PIC  9(018) VALUE ZEROS.*/
                public IntBasis SIGC13_NN_REGISTRADO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
                /*"      10   SIGC13-LNHA-DIGITAVEL    PIC  X(054) VALUE SPACES.*/
                public StringBasis SIGC13_LNHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
                /*"      10   SIGC13-COD-AG-CEDENTE    PIC  X(020).*/
                public StringBasis SIGC13_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10   SIGC13-CEDENTE-R REDEFINES SIGC13-COD-AG-CEDENTE.*/
                private _REDEF_PF2002B_SIGC13_CEDENTE_R _sigc13_cedente_r { get; set; }
                public _REDEF_PF2002B_SIGC13_CEDENTE_R SIGC13_CEDENTE_R
                {
                    get { _sigc13_cedente_r = new _REDEF_PF2002B_SIGC13_CEDENTE_R(); _.Move(SIGC13_COD_AG_CEDENTE, _sigc13_cedente_r); VarBasis.RedefinePassValue(SIGC13_COD_AG_CEDENTE, _sigc13_cedente_r, SIGC13_COD_AG_CEDENTE); _sigc13_cedente_r.ValueChanged += () => { _.Move(_sigc13_cedente_r, SIGC13_COD_AG_CEDENTE); }; return _sigc13_cedente_r; }
                    set { VarBasis.RedefinePassValue(value, _sigc13_cedente_r, SIGC13_COD_AG_CEDENTE); }
                }  //Redefines
                public class _REDEF_PF2002B_SIGC13_CEDENTE_R : VarBasis
                {
                    /*"         15  FILLER                 PIC  X(007).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15  SIGC13-COD-AGE-CED     PIC  9(004).*/
                    public IntBasis SIGC13_COD_AGE_CED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15  FILLER                 PIC  X(001).*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15  SIGC13-COD-CEDENTE     PIC  9(006).*/
                    public IntBasis SIGC13_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"         15  FILLER                 PIC  X(001).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15  SIGC13-DV-CEDENTE      PIC  9(001).*/
                    public IntBasis SIGC13_DV_CEDENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      10   SIGC13-NUM-BCO-RECEB     PIC  9(003) VALUE ZEROS.*/

                    public _REDEF_PF2002B_SIGC13_CEDENTE_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                        SIGC13_COD_AGE_CED.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                        SIGC13_COD_CEDENTE.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                        SIGC13_DV_CEDENTE.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis SIGC13_NUM_BCO_RECEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"      10   SIGC13-NUM-AGE-RECEB     PIC  9(005) VALUE ZEROS.*/
                public IntBasis SIGC13_NUM_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      10   SIGC13-DV-AGE-RECEB      PIC  9(001) VALUE ZEROS.*/
                public IntBasis SIGC13_DV_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10   SIGC13-DTA-VENCIMENTO.*/
                public PF2002B_SIGC13_DTA_VENCIMENTO SIGC13_DTA_VENCIMENTO { get; set; } = new PF2002B_SIGC13_DTA_VENCIMENTO();
                public class PF2002B_SIGC13_DTA_VENCIMENTO : VarBasis
                {
                    /*"         15 SIGC13-DIA-VENCIMENFTO  PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_DIA_VENCIMENFTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-MES-VENCIMENTO   PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_MES_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-ANO-VENCIMENTO   PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_ANO_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10   SIGC13-DTA-PAGAMENTO.*/
                }
                public PF2002B_SIGC13_DTA_PAGAMENTO SIGC13_DTA_PAGAMENTO { get; set; } = new PF2002B_SIGC13_DTA_PAGAMENTO();
                public class PF2002B_SIGC13_DTA_PAGAMENTO : VarBasis
                {
                    /*"         15 SIGC13-DIA-PAGAMENTO    PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_DIA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-MES-PAGAMENTO    PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_MES_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-ANO-PAGAMENTO    PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_ANO_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10   SIGC13-DTA-CREDITO.*/
                }
                public PF2002B_SIGC13_DTA_CREDITO SIGC13_DTA_CREDITO { get; set; } = new PF2002B_SIGC13_DTA_CREDITO();
                public class PF2002B_SIGC13_DTA_CREDITO : VarBasis
                {
                    /*"         15 SIGC13-DIA-CREDITO      PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_DIA_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-MES-CREDITO      PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_MES_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-ANO-CREDITO      PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_ANO_CREDITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10   SIGC13-DTA-DEB-TARIFA.*/
                }
                public PF2002B_SIGC13_DTA_DEB_TARIFA SIGC13_DTA_DEB_TARIFA { get; set; } = new PF2002B_SIGC13_DTA_DEB_TARIFA();
                public class PF2002B_SIGC13_DTA_DEB_TARIFA : VarBasis
                {
                    /*"         15 SIGC13-DIA-DEB-TARIFA   PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_DIA_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-MES-DEB-TARIFA   PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_MES_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-ANO-DEB-TARIFA   PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_ANO_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10   SIGC13-VLR-ACRESCIMO     PIC  9(015) VALUE ZEROS.*/
                }
                public IntBasis SIGC13_VLR_ACRESCIMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-VLR-DESCONTO      PIC  9(015) VALUE ZEROS.*/
                public IntBasis SIGC13_VLR_DESCONTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-VLR-ABATIMENTO    PIC  9(015) VALUE ZEROS.*/
                public IntBasis SIGC13_VLR_ABATIMENTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-VLR-IOF           PIC  9(015) VALUE ZEROS.*/
                public IntBasis SIGC13_VLR_IOF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-VLR-PAGO          PIC  9(015) VALUE ZEROS.*/
                public IntBasis SIGC13_VLR_PAGO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-VLR-LIQUIDO       PIC  9(015) VALUE ZEROS.*/
                public IntBasis SIGC13_VLR_LIQUIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-VLR-TARIFA        PIC  9(015) VALUE ZEROS.*/
                public IntBasis SIGC13_VLR_TARIFA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      10   SIGC13-COD-MOVIMENTO     PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGC13_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10   SIGC13-COD-REJEICAO      PIC  X(010) VALUE SPACES.*/
                public StringBasis SIGC13_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"      10   SIGC13-NUM-TITULO        PIC  9(016) VALUE ZEROS.*/
                public IntBasis SIGC13_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
                /*"      10   SIGC13-COD-SISTEMA       PIC  X(003) VALUE SPACES.*/
                public StringBasis SIGC13_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"      10   SIGC13-NUM-PARCELA       PIC  9(003) VALUE ZEROS.*/
                public IntBasis SIGC13_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"      10   SIGC13-COD-PRODUTO       PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGC13_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10   SIGC13-DTA-GERACAO.*/
                public PF2002B_SIGC13_DTA_GERACAO SIGC13_DTA_GERACAO { get; set; } = new PF2002B_SIGC13_DTA_GERACAO();
                public class PF2002B_SIGC13_DTA_GERACAO : VarBasis
                {
                    /*"         15 SIGC13-DIA-GERACAO      PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_DIA_GERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-MES-GERACAO      PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_MES_GERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"         15 SIGC13-ANO-GERACAO      PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_ANO_GERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"   05      FILLER                   PIC  X(030) VALUE SPACES.*/
                }
            }
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"01  WS-AUX-ARQUIVO.*/
        }
        public PF2002B_WS_AUX_ARQUIVO WS_AUX_ARQUIVO { get; set; } = new PF2002B_WS_AUX_ARQUIVO();
        public class PF2002B_WS_AUX_ARQUIVO : VarBasis
        {
            /*"  03         WFIM-AGENCIAS      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_AGENCIAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WFIM-PRODUTO       PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WFIM-BILCOBER      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_BILCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WFIM-SORT          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WS-SUBS            PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         WS-SUBS1           PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         WS-SUBS2           PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         WS-SUBS3           PIC  9(005)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03         AC-INSERT          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_INSERT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-HEADER          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-TRAILL          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_TRAILL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-GRAFICA         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_GRAFICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-GRAFICA         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_GRAFICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         TT-OPCAO           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_OPCAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-OPCAO           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_OPCAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-SALVA           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SALVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-SALVA1          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_SALVA1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WFIM-COBRANCA      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WCHV-ERRO          PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WCHV_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         FLG-GRAFICA        PIC  X(001)    VALUE   SPACES.*/
            public StringBasis FLG_GRAFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         FLG-MALA           PIC  X(001)    VALUE   SPACES.*/
            public StringBasis FLG_MALA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DE-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DE_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-CED-DIRVI       PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_CED_DIRVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-CED-DIRID       PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_CED_DIRID { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-CED-RESSARC     PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_CED_RESSARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-CED-DISEF       PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_CED_DISEF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-CED-DESCONHECIDO PIC  9(007)   VALUE   ZEROS.*/
            public IntBasis LD_CED_DESCONHECIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         W-SORT-OUTPUT-RETC PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis W_SORT_OUTPUT_RETC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         W-SORT-TOT-GRAV    PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis W_SORT_TOT_GRAV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         W-SORT-TOT-LIDOS   PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis W_SORT_TOT_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         NP-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis NP_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         IN-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-MOVICOB         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis UP_MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AD-QTDEBIL         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AD_QTDEBIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AD-VLRABIL         PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AD_VLRABIL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WS-VLPRMTAR        PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         IN-V0RCAP          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_V0RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         IN-CONVERSAO       PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_CONVERSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-PRODUTO         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WS-VALADT          PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WS-RESULT          PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         WS-RESTO           PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WPARM11-AUX        PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM11_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03         CONVEN-DATAOCORREN PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis CONVEN_DATAOCORREN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         CONVEN-DTVENCTO    PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis CONVEN_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         CONVEN-DATA-CRED   PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis CONVEN_DATA_CRED { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         CONVEN-FONTE       PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         CONVEN-AGECOBR     PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         CONVEN-ESCNEG      PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         CONVEN-CODPRODU    PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis CONVEN_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         IN-FOLLOWUP        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis IN_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AUX-NRENDOS        PIC S9(009)    COMP.*/
            public IntBasis AUX_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         AC-DUPLICA         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-CREDITO         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_CREDITO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-CED1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_CED1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-CAN1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_CAN1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-AGE1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_AGE1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-SFR1144         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_SFR1144 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-SIES            PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_SIES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WTEM-SIES          PIC  X(001)    VALUE  'N'.*/
            public StringBasis WTEM_SIES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WTEM-PROPOSTA      PIC  X(003)    VALUE  'NAO'.*/
            public StringBasis WTEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_PF2002B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF2002B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF2002B_FILLER_5(); _.Move(AC_LIDOS, _filler_5); VarBasis.RedefinePassValue(AC_LIDOS, _filler_5, AC_LIDOS); _filler_5.ValueChanged += () => { _.Move(_filler_5, AC_LIDOS); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_5 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         AUX-NOME.*/

                public _REDEF_PF2002B_FILLER_5()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public PF2002B_AUX_NOME AUX_NOME { get; set; } = new PF2002B_AUX_NOME();
            public class PF2002B_AUX_NOME : VarBasis
            {
                /*"    10       AUX-DESCRICAO      PIC  X(040).*/
                public StringBasis AUX_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10       AUX-DTVEN-DD       PIC  9(002).*/
                public IntBasis AUX_DTVEN_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-01       PIC  X(001).*/
                public StringBasis AUX_DTVEN_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-DTVEN-MM       PIC  9(002).*/
                public IntBasis AUX_DTVEN_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-02       PIC  X(001).*/
                public StringBasis AUX_DTVEN_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-DTVEN-A1       PIC  9(002).*/
                public IntBasis AUX_DTVEN_A1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-A2       PIC  9(002).*/
                public IntBasis AUX_DTVEN_A2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS1-IDLG.*/
            }
            public PF2002B_WS1_IDLG WS1_IDLG { get; set; } = new PF2002B_WS1_IDLG();
            public class PF2002B_WS1_IDLG : VarBasis
            {
                /*"    10       WS1-CONVENIO       PIC  9(006).*/
                public IntBasis WS1_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WS1-NSAS           PIC  9(006).*/
                public IntBasis WS1_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WS1-ENDOSSO        PIC  9(008).*/
                public IntBasis WS1_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       WS1-BRANCOS        PIC  X(020).*/
                public StringBasis WS1_BRANCOS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  03         WS2-IDLG.*/
            }
            public PF2002B_WS2_IDLG WS2_IDLG { get; set; } = new PF2002B_WS2_IDLG();
            public class PF2002B_WS2_IDLG : VarBasis
            {
                /*"    10       WS2-NRCERTIF       PIC  9(015).*/
                public IntBasis WS2_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       WS2-NRPARCEL       PIC  9(004).*/
                public IntBasis WS2_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS2-NRTIT          PIC  9(013).*/
                public IntBasis WS2_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WS2-BRANCOS        PIC  X(008).*/
                public StringBasis WS2_BRANCOS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  03         WS-NN-REG          PIC  9(018)    VALUE   ZEROS.*/
            }
            public IntBasis WS_NN_REG { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"  03         FILLER             REDEFINES      WS-NN-REG.*/
            private _REDEF_PF2002B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF2002B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF2002B_FILLER_6(); _.Move(WS_NN_REG, _filler_6); VarBasis.RedefinePassValue(WS_NN_REG, _filler_6, WS_NN_REG); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_NN_REG); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_NN_REG); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_6 : VarBasis
            {
                /*"    10       WS-NN-REG-2        PIC  9(002).*/
                public IntBasis WS_NN_REG_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-NN-REG-TP-PARC  PIC  9(001).*/
                public IntBasis WS_NN_REG_TP_PARC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS-NN-REG-14P      PIC  9(014).*/
                public IntBasis WS_NN_REG_14P { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10       FILLER             PIC  9(001).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         FILLER             REDEFINES      WS-NN-REG.*/

                public _REDEF_PF2002B_FILLER_6()
                {
                    WS_NN_REG_2.ValueChanged += OnValueChanged;
                    WS_NN_REG_TP_PARC.ValueChanged += OnValueChanged;
                    WS_NN_REG_14P.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF2002B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF2002B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF2002B_FILLER_8(); _.Move(WS_NN_REG, _filler_8); VarBasis.RedefinePassValue(WS_NN_REG, _filler_8, WS_NN_REG); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_NN_REG); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_NN_REG); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_8 : VarBasis
            {
                /*"    10       FILLER             PIC  9(002).*/
                public IntBasis FILLER_9 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-NN-REG-16P      PIC  9(016).*/
                public IntBasis WS_NN_REG_16P { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"  03         WS-PRODUTO         PIC  9(04)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_8()
                {
                    FILLER_9.ValueChanged += OnValueChanged;
                    WS_NN_REG_16P.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  03         FILLER             REDEFINES     WS-PRODUTO.*/
            private _REDEF_PF2002B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_PF2002B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_PF2002B_FILLER_10(); _.Move(WS_PRODUTO, _filler_10); VarBasis.RedefinePassValue(WS_PRODUTO, _filler_10, WS_PRODUTO); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_PRODUTO); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WS_PRODUTO); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_10 : VarBasis
            {
                /*"    10       WS-RAMO-PROD       PIC  9(002).*/
                public IntBasis WS_RAMO_PROD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  9(002).*/
                public IntBasis FILLER_11 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-NUM-PROPOSTA    PIC S9(015)    VALUE +0 COMP-3.*/

                public _REDEF_PF2002B_FILLER_10()
                {
                    WS_RAMO_PROD.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03         WS-NR-SICOB        PIC 9(016)   VALUE ZEROS.*/
            public IntBasis WS_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER             REDEFINES     WS-NR-SICOB.*/
            private _REDEF_PF2002B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_PF2002B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_PF2002B_FILLER_12(); _.Move(WS_NR_SICOB, _filler_12); VarBasis.RedefinePassValue(WS_NR_SICOB, _filler_12, WS_NR_SICOB); _filler_12.ValueChanged += () => { _.Move(_filler_12, WS_NR_SICOB); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WS_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_12 : VarBasis
            {
                /*"    10       WS-NR-1POS         PIC  9(001).*/
                public IntBasis WS_NR_1POS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS-NR-SICOB-T      PIC  9(015).*/
                public IntBasis WS_NR_SICOB_T { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"  03         WWORK-MIN-NRTIT    PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_12()
                {
                    WS_NR_1POS.ValueChanged += OnValueChanged;
                    WS_NR_SICOB_T.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_PF2002B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_PF2002B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_PF2002B_FILLER_13(); _.Move(WWORK_MIN_NRTIT, _filler_13); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_13, WWORK_MIN_NRTIT); _filler_13.ValueChanged += () => { _.Move(_filler_13, WWORK_MIN_NRTIT); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_13 : VarBasis
            {
                /*"    10       WWORK-MINNRO       PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MINDIG       PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MAX-NRTIT    PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_13()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_PF2002B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_PF2002B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_PF2002B_FILLER_14(); _.Move(WWORK_MAX_NRTIT, _filler_14); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_14, WWORK_MAX_NRTIT); _filler_14.ValueChanged += () => { _.Move(_filler_14, WWORK_MAX_NRTIT); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_14 : VarBasis
            {
                /*"    10       WWORK-MAXNRO       PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MAXDIG       PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-NSO-NUMERO   PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_14()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-NSO-NUMERO.*/
            private _REDEF_PF2002B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_PF2002B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_PF2002B_FILLER_15(); _.Move(WWORK_NSO_NUMERO, _filler_15); VarBasis.RedefinePassValue(WWORK_NSO_NUMERO, _filler_15, WWORK_NSO_NUMERO); _filler_15.ValueChanged += () => { _.Move(_filler_15, WWORK_NSO_NUMERO); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WWORK_NSO_NUMERO); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_15 : VarBasis
            {
                /*"    10       WWORK-PRETIT       PIC  9(001).*/
                public IntBasis WWORK_PRETIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WWORK-NRRCAP       PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WWORK-DIGTIT       PIC  9(001).*/
                public IntBasis WWORK_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WS-NRTIT           PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_15()
                {
                    WWORK_PRETIT.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    WWORK_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WS-NRTIT.*/
            private _REDEF_PF2002B_FILLER_16 _filler_16 { get; set; }
            public _REDEF_PF2002B_FILLER_16 FILLER_16
            {
                get { _filler_16 = new _REDEF_PF2002B_FILLER_16(); _.Move(WS_NRTIT, _filler_16); VarBasis.RedefinePassValue(WS_NRTIT, _filler_16, WS_NRTIT); _filler_16.ValueChanged += () => { _.Move(_filler_16, WS_NRTIT); }; return _filler_16; }
                set { VarBasis.RedefinePassValue(value, _filler_16, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_16 : VarBasis
            {
                /*"      10     WS-NUMTIT          PIC  9(010).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10     WS-DIGTIT          PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-TIT-CED1144    PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_PF2002B_FILLER_16()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TIT_CED1144 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-TIT-CED1144.*/
            private _REDEF_PF2002B_FILLER_17 _filler_17 { get; set; }
            public _REDEF_PF2002B_FILLER_17 FILLER_17
            {
                get { _filler_17 = new _REDEF_PF2002B_FILLER_17(); _.Move(AUX_TIT_CED1144, _filler_17); VarBasis.RedefinePassValue(AUX_TIT_CED1144, _filler_17, AUX_TIT_CED1144); _filler_17.ValueChanged += () => { _.Move(_filler_17, AUX_TIT_CED1144); }; return _filler_17; }
                set { VarBasis.RedefinePassValue(value, _filler_17, AUX_TIT_CED1144); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_17 : VarBasis
            {
                /*"    10       FILLER             PIC  X(004).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       AUX-NUM-CED1144    PIC  9(010).*/
                public IntBasis AUX_NUM_CED1144 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"  03         AUX-TIT-GRAFICA    PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_PF2002B_FILLER_17()
                {
                    FILLER_18.ValueChanged += OnValueChanged;
                    AUX_NUM_CED1144.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TIT_GRAFICA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-TIT-GRAFICA.*/
            private _REDEF_PF2002B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_PF2002B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_PF2002B_FILLER_19(); _.Move(AUX_TIT_GRAFICA, _filler_19); VarBasis.RedefinePassValue(AUX_TIT_GRAFICA, _filler_19, AUX_TIT_GRAFICA); _filler_19.ValueChanged += () => { _.Move(_filler_19, AUX_TIT_GRAFICA); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, AUX_TIT_GRAFICA); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_19 : VarBasis
            {
                /*"    10       FILLER             PIC  X(003).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10       AUX-NUM-GRAFICA    PIC  9(011).*/
                public IntBasis AUX_NUM_GRAFICA { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"  03         AUX-AGE-AVISO.*/

                public _REDEF_PF2002B_FILLER_19()
                {
                    FILLER_20.ValueChanged += OnValueChanged;
                    AUX_NUM_GRAFICA.ValueChanged += OnValueChanged;
                }

            }
            public PF2002B_AUX_AGE_AVISO AUX_AGE_AVISO { get; set; } = new PF2002B_AUX_AGE_AVISO();
            public class PF2002B_AUX_AGE_AVISO : VarBasis
            {
                /*"    10       AUX-AGE-TP-AVISO   PIC  9(001).*/
                public IntBasis AUX_AGE_TP_AVISO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       AUX-AGE-RESTO      PIC  9(003).*/
                public IntBasis AUX_AGE_RESTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         AUX-USO-EMPRESA.*/
            }
            public PF2002B_AUX_USO_EMPRESA AUX_USO_EMPRESA { get; set; } = new PF2002B_AUX_USO_EMPRESA();
            public class PF2002B_AUX_USO_EMPRESA : VarBasis
            {
                /*"    10       AUX-OITO           PIC  X(002).*/
                public StringBasis AUX_OITO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       AUX-TITSIVPF       PIC  9(014).*/
                public IntBasis AUX_TITSIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"  03         AUX-USO-EMPRESA2.*/
            }
            public PF2002B_AUX_USO_EMPRESA2 AUX_USO_EMPRESA2 { get; set; } = new PF2002B_AUX_USO_EMPRESA2();
            public class PF2002B_AUX_USO_EMPRESA2 : VarBasis
            {
                /*"    10       AUX-OITO2          PIC  X(002).*/
                public StringBasis AUX_OITO2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       AUX-TITSIVPF2      PIC  9(014).*/
                public IntBasis AUX_TITSIVPF2 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"  03         AUX-NRO-SIVPF      PIC  9(014)    VALUE   ZEROS.*/
            }
            public IntBasis AUX_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-NRO-SIVPF.*/
            private _REDEF_PF2002B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_PF2002B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_PF2002B_FILLER_21(); _.Move(AUX_NRO_SIVPF, _filler_21); VarBasis.RedefinePassValue(AUX_NRO_SIVPF, _filler_21, AUX_NRO_SIVPF); _filler_21.ValueChanged += () => { _.Move(_filler_21, AUX_NRO_SIVPF); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, AUX_NRO_SIVPF); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_21 : VarBasis
            {
                /*"    10       AUX-CANAL          PIC  9(001).*/
                public IntBasis AUX_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       AUX-AGENCIA        PIC  9(004).*/
                public IntBasis AUX_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       AUX-PRDSIVPF       PIC  9(002).*/
                public IntBasis AUX_PRDSIVPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-NRSEQ          PIC  9(006).*/
                public IntBasis AUX_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       AUX-DIGITO         PIC  9(001).*/
                public IntBasis AUX_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-APOLICE        PIC  9(014)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_21()
                {
                    AUX_CANAL.ValueChanged += OnValueChanged;
                    AUX_AGENCIA.ValueChanged += OnValueChanged;
                    AUX_PRDSIVPF.ValueChanged += OnValueChanged;
                    AUX_NRSEQ.ValueChanged += OnValueChanged;
                    AUX_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_APOLICE { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-APOLICE.*/
            private _REDEF_PF2002B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_PF2002B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_PF2002B_FILLER_22(); _.Move(AUX_APOLICE, _filler_22); VarBasis.RedefinePassValue(AUX_APOLICE, _filler_22, AUX_APOLICE); _filler_22.ValueChanged += () => { _.Move(_filler_22, AUX_APOLICE); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, AUX_APOLICE); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_22 : VarBasis
            {
                /*"    10       AUX-NUMAPOL        PIC  9(013).*/
                public IntBasis AUX_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       AUX-DIGAPOL        PIC  9(001).*/
                public IntBasis AUX_DIGAPOL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-ENDOSLID.*/

                public _REDEF_PF2002B_FILLER_22()
                {
                    AUX_NUMAPOL.ValueChanged += OnValueChanged;
                    AUX_DIGAPOL.ValueChanged += OnValueChanged;
                }

            }
            public PF2002B_AUX_ENDOSLID AUX_ENDOSLID { get; set; } = new PF2002B_AUX_ENDOSLID();
            public class PF2002B_AUX_ENDOSLID : VarBasis
            {
                /*"    10       AUX-CODPRODU       PIC  9(004).*/
                public IntBasis AUX_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       AUX-CODPRODU-SPACE PIC  X(011).*/
                public StringBasis AUX_CODPRODU_SPACE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"  03         AUX-NRO-RESSA      PIC  9(014)    VALUE   ZEROS.*/
            }
            public IntBasis AUX_NRO_RESSA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-NRO-RESSA.*/
            private _REDEF_PF2002B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_PF2002B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_PF2002B_FILLER_23(); _.Move(AUX_NRO_RESSA, _filler_23); VarBasis.RedefinePassValue(AUX_NRO_RESSA, _filler_23, AUX_NRO_RESSA); _filler_23.ValueChanged += () => { _.Move(_filler_23, AUX_NRO_RESSA); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, AUX_NRO_RESSA); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_23 : VarBasis
            {
                /*"    10       AUX-NRO-APOL       PIC  9(010).*/
                public IntBasis AUX_NRO_APOL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       AUX-NRO-PARC       PIC  9(004).*/
                public IntBasis AUX_NRO_PARC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         RES-APOLICE        PIC  9(013)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_23()
                {
                    AUX_NRO_APOL.ValueChanged += OnValueChanged;
                    AUX_NRO_PARC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis RES_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      RES-APOLICE.*/
            private _REDEF_PF2002B_FILLER_24 _filler_24 { get; set; }
            public _REDEF_PF2002B_FILLER_24 FILLER_24
            {
                get { _filler_24 = new _REDEF_PF2002B_FILLER_24(); _.Move(RES_APOLICE, _filler_24); VarBasis.RedefinePassValue(RES_APOLICE, _filler_24, RES_APOLICE); _filler_24.ValueChanged += () => { _.Move(_filler_24, RES_APOLICE); }; return _filler_24; }
                set { VarBasis.RedefinePassValue(value, _filler_24, RES_APOLICE); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_24 : VarBasis
            {
                /*"    10       RES-PREAPOL        PIC  9(003).*/
                public IntBasis RES_PREAPOL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       RES-NUMAPOL        PIC  9(010).*/
                public IntBasis RES_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"  03         SIN-NRO-RESSA      PIC  9(014)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_24()
                {
                    RES_PREAPOL.ValueChanged += OnValueChanged;
                    RES_NUMAPOL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SIN_NRO_RESSA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      SIN-NRO-RESSA.*/
            private _REDEF_PF2002B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_PF2002B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_PF2002B_FILLER_25(); _.Move(SIN_NRO_RESSA, _filler_25); VarBasis.RedefinePassValue(SIN_NRO_RESSA, _filler_25, SIN_NRO_RESSA); _filler_25.ValueChanged += () => { _.Move(_filler_25, SIN_NRO_RESSA); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, SIN_NRO_RESSA); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_25 : VarBasis
            {
                /*"    10       SIN-NRO-RAMO       PIC  9(002).*/
                public IntBasis SIN_NRO_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-NRO-APOL       PIC  9(006).*/
                public IntBasis SIN_NRO_APOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       FILLER             PIC  9(006).*/
                public IntBasis FILLER_26 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  03         SIN-APOLICE        PIC  9(013)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_25()
                {
                    SIN_NRO_RAMO.ValueChanged += OnValueChanged;
                    SIN_NRO_APOL.ValueChanged += OnValueChanged;
                    FILLER_26.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SIN_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      SIN-APOLICE.*/
            private _REDEF_PF2002B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_PF2002B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_PF2002B_FILLER_27(); _.Move(SIN_APOLICE, _filler_27); VarBasis.RedefinePassValue(SIN_APOLICE, _filler_27, SIN_APOLICE); _filler_27.ValueChanged += () => { _.Move(_filler_27, SIN_APOLICE); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, SIN_APOLICE); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_27 : VarBasis
            {
                /*"    10       SIN-AUX-ORGAO      PIC  9(003).*/
                public IntBasis SIN_AUX_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       SIN-AUX-RAMO       PIC  9(002).*/
                public IntBasis SIN_AUX_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-AUX-ZERO       PIC  9(002).*/
                public IntBasis SIN_AUX_ZERO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-AUX-APOL       PIC  9(006).*/
                public IntBasis SIN_AUX_APOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01  WS-AUX-DATAS.*/

                public _REDEF_PF2002B_FILLER_27()
                {
                    SIN_AUX_ORGAO.ValueChanged += OnValueChanged;
                    SIN_AUX_RAMO.ValueChanged += OnValueChanged;
                    SIN_AUX_ZERO.ValueChanged += OnValueChanged;
                    SIN_AUX_APOL.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF2002B_WS_AUX_DATAS WS_AUX_DATAS { get; set; } = new PF2002B_WS_AUX_DATAS();
        public class PF2002B_WS_AUX_DATAS : VarBasis
        {
            /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_PF2002B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_PF2002B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_PF2002B_FILLER_28(); _.Move(WDATA_REL, _filler_28); VarBasis.RedefinePassValue(WDATA_REL, _filler_28, WDATA_REL); _filler_28.ValueChanged += () => { _.Move(_filler_28, WDATA_REL); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WDATA_REL); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_28 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WDAT-FILLER-1      PIC  X(001).*/
                public StringBasis WDAT_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-FILLER-2      PIC  X(001).*/
                public StringBasis WDAT_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDAT-REL-LIT.*/

                public _REDEF_PF2002B_FILLER_28()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    WDAT_FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    WDAT_FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public PF2002B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new PF2002B_WDAT_REL_LIT();
            public class PF2002B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA       PIC  9(002).*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES       PIC  9(002).*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO       PIC  9(004).*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-FITA.*/
            }
            public PF2002B_WDATA_FITA WDATA_FITA { get; set; } = new PF2002B_WDATA_FITA();
            public class PF2002B_WDATA_FITA : VarBasis
            {
                /*"    10       WDAT-FITA-DIA      PIC  X(002).*/
                public StringBasis WDAT_FITA_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-MES      PIC  X(002).*/
                public StringBasis WDAT_FITA_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-ANO.*/
                public PF2002B_WDAT_FITA_ANO WDAT_FITA_ANO { get; set; } = new PF2002B_WDAT_FITA_ANO();
                public class PF2002B_WDAT_FITA_ANO : VarBasis
                {
                    /*"      15     WDAT-FITA-ANO-A    PIC  X(001).*/
                    public StringBasis WDAT_FITA_ANO_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WDAT-FITA-ANO-D    PIC  X(001).*/
                    public StringBasis WDAT_FITA_ANO_D { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"  03         WDATA-TABELA.*/
                }
            }
            public PF2002B_WDATA_TABELA WDATA_TABELA { get; set; } = new PF2002B_WDATA_TABELA();
            public class PF2002B_WDATA_TABELA : VarBasis
            {
                /*"    10       WDAT-TAB-SEC       PIC  9(002).*/
                public IntBasis WDAT_TAB_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-TAB-ANO       PIC  9(002).*/
                public IntBasis WDAT_TAB_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-MES       PIC  9(002).*/
                public IntBasis WDAT_TAB_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-DIA       PIC  9(002).*/
                public IntBasis WDAT_TAB_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-TABELA1.*/
            }
            public PF2002B_WDATA_TABELA1 WDATA_TABELA1 { get; set; } = new PF2002B_WDATA_TABELA1();
            public class PF2002B_WDATA_TABELA1 : VarBasis
            {
                /*"    10       WDAT-TAB-ANO1      PIC  9(004).*/
                public IntBasis WDAT_TAB_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-MES1      PIC  9(002).*/
                public IntBasis WDAT_TAB_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-DIA1      PIC  9(002).*/
                public IntBasis WDAT_TAB_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-SECULO       PIC  9(008)    VALUE   ZEROS.*/
            }
            public IntBasis WDATA_SECULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER             REDEFINES      WDATA-SECULO.*/
            private _REDEF_PF2002B_FILLER_35 _filler_35 { get; set; }
            public _REDEF_PF2002B_FILLER_35 FILLER_35
            {
                get { _filler_35 = new _REDEF_PF2002B_FILLER_35(); _.Move(WDATA_SECULO, _filler_35); VarBasis.RedefinePassValue(WDATA_SECULO, _filler_35, WDATA_SECULO); _filler_35.ValueChanged += () => { _.Move(_filler_35, WDATA_SECULO); }; return _filler_35; }
                set { VarBasis.RedefinePassValue(value, _filler_35, WDATA_SECULO); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_35 : VarBasis
            {
                /*"    10       WDAT-SEC-DIA       PIC  9(002).*/
                public IntBasis WDAT_SEC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-MES       PIC  9(002).*/
                public IntBasis WDAT_SEC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-SEC       PIC  9(002).*/
                public IntBasis WDAT_SEC_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-ANO       PIC  9(002).*/
                public IntBasis WDAT_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS000-DATA         PIC  9(008)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_35()
                {
                    WDAT_SEC_DIA.ValueChanged += OnValueChanged;
                    WDAT_SEC_MES.ValueChanged += OnValueChanged;
                    WDAT_SEC_SEC.ValueChanged += OnValueChanged;
                    WDAT_SEC_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS000_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER             REDEFINES      WS000-DATA.*/
            private _REDEF_PF2002B_FILLER_36 _filler_36 { get; set; }
            public _REDEF_PF2002B_FILLER_36 FILLER_36
            {
                get { _filler_36 = new _REDEF_PF2002B_FILLER_36(); _.Move(WS000_DATA, _filler_36); VarBasis.RedefinePassValue(WS000_DATA, _filler_36, WS000_DATA); _filler_36.ValueChanged += () => { _.Move(_filler_36, WS000_DATA); }; return _filler_36; }
                set { VarBasis.RedefinePassValue(value, _filler_36, WS000_DATA); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_36 : VarBasis
            {
                /*"    10       WS000-ANO          PIC  9(004).*/
                public IntBasis WS000_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS000-MES          PIC  9(002).*/
                public IntBasis WS000_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS000-DIA          PIC  9(002).*/
                public IntBasis WS000_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  X(011).*/

                public _REDEF_PF2002B_FILLER_36()
                {
                    WS000_ANO.ValueChanged += OnValueChanged;
                    WS000_MES.ValueChanged += OnValueChanged;
                    WS000_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WTIME_DAY { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_PF2002B_FILLER_37 _filler_37 { get; set; }
            public _REDEF_PF2002B_FILLER_37 FILLER_37
            {
                get { _filler_37 = new _REDEF_PF2002B_FILLER_37(); _.Move(WTIME_DAY, _filler_37); VarBasis.RedefinePassValue(WTIME_DAY, _filler_37, WTIME_DAY); _filler_37.ValueChanged += () => { _.Move(_filler_37, WTIME_DAY); }; return _filler_37; }
                set { VarBasis.RedefinePassValue(value, _filler_37, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_37 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public PF2002B_WTIME_DAYR WTIME_DAYR { get; set; } = new PF2002B_WTIME_DAYR();
                public class PF2002B_WTIME_DAYR : VarBasis
                {
                    /*"      10     WTIME-HORA         PIC  9(002).*/
                    public IntBasis WTIME_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-MINU         PIC  9(002).*/
                    public IntBasis WTIME_MINU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-SEGU         PIC  9(002).*/
                    public IntBasis WTIME_SEGU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WTIME-2PT3         PIC  X(001).*/

                    public PF2002B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WTIME-CCSE         PIC  9(002).*/
                public IntBasis WTIME_CCSE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-TIME.*/

                public _REDEF_PF2002B_FILLER_37()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public PF2002B_WS_TIME WS_TIME { get; set; } = new PF2002B_WS_TIME();
            public class PF2002B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  WS-AUX-AVISO.*/
            }
        }
        public PF2002B_WS_AUX_AVISO WS_AUX_AVISO { get; set; } = new PF2002B_WS_AUX_AVISO();
        public class PF2002B_WS_AUX_AVISO : VarBasis
        {
            /*"  03  WWORK-BCOAVISO            PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WWORK_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WWORK-NUMFITA             PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WWORK_NUMFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WWORK-DATCEF              PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis WWORK_DATCEF { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03  WWORK-DATCEF1             PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WWORK_DATCEF1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WWORK-DTAVISO             PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WWORK_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03  WWORK-ORIGAVISO           PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WWORK_ORIGAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WWORK-TIPAVI              PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WWORK_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WWORK-CODMOV              PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WWORK_CODMOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WWORK-SITUACAO            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WWORK_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WWORK-CODEMPRE     PIC  9(016)    VALUE   ZEROS.*/
            public IntBasis WWORK_CODEMPRE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER             REDEFINES      WWORK-CODEMPRE.*/
            private _REDEF_PF2002B_FILLER_38 _filler_38 { get; set; }
            public _REDEF_PF2002B_FILLER_38 FILLER_38
            {
                get { _filler_38 = new _REDEF_PF2002B_FILLER_38(); _.Move(WWORK_CODEMPRE, _filler_38); VarBasis.RedefinePassValue(WWORK_CODEMPRE, _filler_38, WWORK_CODEMPRE); _filler_38.ValueChanged += () => { _.Move(_filler_38, WWORK_CODEMPRE); }; return _filler_38; }
                set { VarBasis.RedefinePassValue(value, _filler_38, WWORK_CODEMPRE); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_38 : VarBasis
            {
                /*"    10       WWORK-NRCTACED     PIC  9(015).*/
                public IntBasis WWORK_NRCTACED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER             PIC  9(001).*/
                public IntBasis FILLER_39 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  WS-AGE-AVISO             PIC  9(004)    VALUE   ZEROS.*/

                public _REDEF_PF2002B_FILLER_38()
                {
                    WWORK_NRCTACED.ValueChanged += OnValueChanged;
                    FILLER_39.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_AGE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"   03 WS-NUMERO-TITULO            PIC 9(16) VALUE ZEROS.*/
            public IntBasis WS_NUMERO_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
            /*"   03 FILLER REDEFINES WS-NUMERO-TITULO.*/
            private _REDEF_PF2002B_FILLER_40 _filler_40 { get; set; }
            public _REDEF_PF2002B_FILLER_40 FILLER_40
            {
                get { _filler_40 = new _REDEF_PF2002B_FILLER_40(); _.Move(WS_NUMERO_TITULO, _filler_40); VarBasis.RedefinePassValue(WS_NUMERO_TITULO, _filler_40, WS_NUMERO_TITULO); _filler_40.ValueChanged += () => { _.Move(_filler_40, WS_NUMERO_TITULO); }; return _filler_40; }
                set { VarBasis.RedefinePassValue(value, _filler_40, WS_NUMERO_TITULO); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_40 : VarBasis
            {
                /*"      10 FILLER                   PIC 9(03).*/
                public IntBasis FILLER_41 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRO-TIT               PIC 9(13).*/
                public IntBasis WS_NRO_TIT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"   03 WS-COD-IDLG                 PIC X(40) VALUE SPACES.*/

                public _REDEF_PF2002B_FILLER_40()
                {
                    FILLER_41.ValueChanged += OnValueChanged;
                    WS_NRO_TIT.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"   03 FILLER REDEFINES WS-COD-IDLG.*/
            private _REDEF_PF2002B_FILLER_42 _filler_42 { get; set; }
            public _REDEF_PF2002B_FILLER_42 FILLER_42
            {
                get { _filler_42 = new _REDEF_PF2002B_FILLER_42(); _.Move(WS_COD_IDLG, _filler_42); VarBasis.RedefinePassValue(WS_COD_IDLG, _filler_42, WS_COD_IDLG); _filler_42.ValueChanged += () => { _.Move(_filler_42, WS_COD_IDLG); }; return _filler_42; }
                set { VarBasis.RedefinePassValue(value, _filler_42, WS_COD_IDLG); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_42 : VarBasis
            {
                /*"      10 WS-IDLG-EMP-SIST-TIPO    PIC X(13).*/
                public StringBasis WS_IDLG_EMP_SIST_TIPO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"      10 WS-IDLG-ID               PIC X(01).*/
                public StringBasis WS_IDLG_ID { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WS-IDLG-PROD             PIC X(03).*/
                public StringBasis WS_IDLG_PROD { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"      10 FILLER                   PIC X(23).*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
                /*"   03 WS-COD-IDLG-1                PIC X(40).*/

                public _REDEF_PF2002B_FILLER_42()
                {
                    WS_IDLG_EMP_SIST_TIPO.ValueChanged += OnValueChanged;
                    WS_IDLG_ID.ValueChanged += OnValueChanged;
                    WS_IDLG_PROD.ValueChanged += OnValueChanged;
                    FILLER_43.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_COD_IDLG_1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   03 FILLER REDEFINES WS-COD-IDLG-1.*/
            private _REDEF_PF2002B_FILLER_44 _filler_44 { get; set; }
            public _REDEF_PF2002B_FILLER_44 FILLER_44
            {
                get { _filler_44 = new _REDEF_PF2002B_FILLER_44(); _.Move(WS_COD_IDLG_1, _filler_44); VarBasis.RedefinePassValue(WS_COD_IDLG_1, _filler_44, WS_COD_IDLG_1); _filler_44.ValueChanged += () => { _.Move(_filler_44, WS_COD_IDLG_1); }; return _filler_44; }
                set { VarBasis.RedefinePassValue(value, _filler_44, WS_COD_IDLG_1); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_44 : VarBasis
            {
                /*"      10 WS-IDLG1-EMP-SIST-TIPO    PIC X(13).*/
                public StringBasis WS_IDLG1_EMP_SIST_TIPO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"      10 WS-IDLG1-APO-END          PIC X(27).*/
                public StringBasis WS_IDLG1_APO_END { get; set; } = new StringBasis(new PIC("X", "27", "X(27)."), @"");
                /*"      10 FILLER REDEFINES WS-IDLG1-APO-END.*/
                private _REDEF_PF2002B_FILLER_45 _filler_45 { get; set; }
                public _REDEF_PF2002B_FILLER_45 FILLER_45
                {
                    get { _filler_45 = new _REDEF_PF2002B_FILLER_45(); _.Move(WS_IDLG1_APO_END, _filler_45); VarBasis.RedefinePassValue(WS_IDLG1_APO_END, _filler_45, WS_IDLG1_APO_END); _filler_45.ValueChanged += () => { _.Move(_filler_45, WS_IDLG1_APO_END); }; return _filler_45; }
                    set { VarBasis.RedefinePassValue(value, _filler_45, WS_IDLG1_APO_END); }
                }  //Redefines
                public class _REDEF_PF2002B_FILLER_45 : VarBasis
                {
                    /*"         15 WS-IDLG1-APO-NUM       PIC 9(13).*/
                    public IntBasis WS_IDLG1_APO_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15  FILLER REDEFINES    WS-IDLG1-APO-NUM.*/
                    private _REDEF_PF2002B_FILLER_46 _filler_46 { get; set; }
                    public _REDEF_PF2002B_FILLER_46 FILLER_46
                    {
                        get { _filler_46 = new _REDEF_PF2002B_FILLER_46(); _.Move(WS_IDLG1_APO_NUM, _filler_46); VarBasis.RedefinePassValue(WS_IDLG1_APO_NUM, _filler_46, WS_IDLG1_APO_NUM); _filler_46.ValueChanged += () => { _.Move(_filler_46, WS_IDLG1_APO_NUM); }; return _filler_46; }
                        set { VarBasis.RedefinePassValue(value, _filler_46, WS_IDLG1_APO_NUM); }
                    }  //Redefines
                    public class _REDEF_PF2002B_FILLER_46 : VarBasis
                    {
                        /*"            20 WS-IDLG1-APO-NUM-ID PIC 9(01).*/
                        public IntBasis WS_IDLG1_APO_NUM_ID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG1-APO-NUM-RE PIC 9(12).*/
                        public IntBasis WS_IDLG1_APO_NUM_RE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                        /*"         15 WS-IDLG1-APO-PAR       PIC 9(02).*/

                        public _REDEF_PF2002B_FILLER_46()
                        {
                            WS_IDLG1_APO_NUM_ID.ValueChanged += OnValueChanged;
                            WS_IDLG1_APO_NUM_RE.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_IDLG1_APO_PAR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER                 PIC X(12).*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
                    /*"      10 FILLER REDEFINES WS-IDLG1-APO-END.*/

                    public _REDEF_PF2002B_FILLER_45()
                    {
                        WS_IDLG1_APO_NUM.ValueChanged += OnValueChanged;
                        FILLER_46.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF2002B_FILLER_48 _filler_48 { get; set; }
                public _REDEF_PF2002B_FILLER_48 FILLER_48
                {
                    get { _filler_48 = new _REDEF_PF2002B_FILLER_48(); _.Move(WS_IDLG1_APO_END, _filler_48); VarBasis.RedefinePassValue(WS_IDLG1_APO_END, _filler_48, WS_IDLG1_APO_END); _filler_48.ValueChanged += () => { _.Move(_filler_48, WS_IDLG1_APO_END); }; return _filler_48; }
                    set { VarBasis.RedefinePassValue(value, _filler_48, WS_IDLG1_APO_END); }
                }  //Redefines
                public class _REDEF_PF2002B_FILLER_48 : VarBasis
                {
                    /*"         15 WS-IDLG1-END-APO       PIC 9(13).*/
                    public IntBasis WS_IDLG1_END_APO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG1-END-NUM       PIC 9(04).*/
                    public IntBasis WS_IDLG1_END_NUM { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"         15 WS-IDLG1-END-PAR       PIC 9(02).*/
                    public IntBasis WS_IDLG1_END_PAR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG1-END-PAR.*/
                    private _REDEF_PF2002B_FILLER_49 _filler_49 { get; set; }
                    public _REDEF_PF2002B_FILLER_49 FILLER_49
                    {
                        get { _filler_49 = new _REDEF_PF2002B_FILLER_49(); _.Move(WS_IDLG1_END_PAR, _filler_49); VarBasis.RedefinePassValue(WS_IDLG1_END_PAR, _filler_49, WS_IDLG1_END_PAR); _filler_49.ValueChanged += () => { _.Move(_filler_49, WS_IDLG1_END_PAR); }; return _filler_49; }
                        set { VarBasis.RedefinePassValue(value, _filler_49, WS_IDLG1_END_PAR); }
                    }  //Redefines
                    public class _REDEF_PF2002B_FILLER_49 : VarBasis
                    {
                        /*"            20 WS-IDLG1-END-PAR-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG1_END_PAR_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG1-END-PAR-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG1_END_PAR_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                 PIC X(08).*/

                        public _REDEF_PF2002B_FILLER_49()
                        {
                            WS_IDLG1_END_PAR_P1.ValueChanged += OnValueChanged;
                            WS_IDLG1_END_PAR_P2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                    /*"      10 FILLER REDEFINES WS-IDLG1-APO-END.*/

                    public _REDEF_PF2002B_FILLER_48()
                    {
                        WS_IDLG1_END_APO.ValueChanged += OnValueChanged;
                        WS_IDLG1_END_NUM.ValueChanged += OnValueChanged;
                        WS_IDLG1_END_PAR.ValueChanged += OnValueChanged;
                        FILLER_49.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF2002B_FILLER_51 _filler_51 { get; set; }
                public _REDEF_PF2002B_FILLER_51 FILLER_51
                {
                    get { _filler_51 = new _REDEF_PF2002B_FILLER_51(); _.Move(WS_IDLG1_APO_END, _filler_51); VarBasis.RedefinePassValue(WS_IDLG1_APO_END, _filler_51, WS_IDLG1_APO_END); _filler_51.ValueChanged += () => { _.Move(_filler_51, WS_IDLG1_APO_END); }; return _filler_51; }
                    set { VarBasis.RedefinePassValue(value, _filler_51, WS_IDLG1_APO_END); }
                }  //Redefines
                public class _REDEF_PF2002B_FILLER_51 : VarBasis
                {
                    /*"         15 WS-IDLG1-END-APO-R3    PIC 9(13).*/
                    public IntBasis WS_IDLG1_END_APO_R3 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG1-END-NUM-R3    PIC 9(04).*/
                    public IntBasis WS_IDLG1_END_NUM_R3 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"         15 WS-IDLG1-END-PAR-R3    PIC 9(03).*/
                    public IntBasis WS_IDLG1_END_PAR_R3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 FILLER REDEFINES WS-IDLG1-END-PAR-R3.*/
                    private _REDEF_PF2002B_FILLER_52 _filler_52 { get; set; }
                    public _REDEF_PF2002B_FILLER_52 FILLER_52
                    {
                        get { _filler_52 = new _REDEF_PF2002B_FILLER_52(); _.Move(WS_IDLG1_END_PAR_R3, _filler_52); VarBasis.RedefinePassValue(WS_IDLG1_END_PAR_R3, _filler_52, WS_IDLG1_END_PAR_R3); _filler_52.ValueChanged += () => { _.Move(_filler_52, WS_IDLG1_END_PAR_R3); }; return _filler_52; }
                        set { VarBasis.RedefinePassValue(value, _filler_52, WS_IDLG1_END_PAR_R3); }
                    }  //Redefines
                    public class _REDEF_PF2002B_FILLER_52 : VarBasis
                    {
                        /*"            20 WS-IDLG1-END-PAR-R3-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG1_END_PAR_R3_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG1-END-PAR-R3-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG1_END_PAR_R3_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG1-END-PAR-R3-P3 PIC 9(01).*/
                        public IntBasis WS_IDLG1_END_PAR_R3_P3 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                 PIC X(07).*/

                        public _REDEF_PF2002B_FILLER_52()
                        {
                            WS_IDLG1_END_PAR_R3_P1.ValueChanged += OnValueChanged;
                            WS_IDLG1_END_PAR_R3_P2.ValueChanged += OnValueChanged;
                            WS_IDLG1_END_PAR_R3_P3.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                    /*"      10 FILLER REDEFINES WS-IDLG1-APO-END.*/

                    public _REDEF_PF2002B_FILLER_51()
                    {
                        WS_IDLG1_END_APO_R3.ValueChanged += OnValueChanged;
                        WS_IDLG1_END_NUM_R3.ValueChanged += OnValueChanged;
                        WS_IDLG1_END_PAR_R3.ValueChanged += OnValueChanged;
                        FILLER_52.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF2002B_FILLER_54 _filler_54 { get; set; }
                public _REDEF_PF2002B_FILLER_54 FILLER_54
                {
                    get { _filler_54 = new _REDEF_PF2002B_FILLER_54(); _.Move(WS_IDLG1_APO_END, _filler_54); VarBasis.RedefinePassValue(WS_IDLG1_APO_END, _filler_54, WS_IDLG1_APO_END); _filler_54.ValueChanged += () => { _.Move(_filler_54, WS_IDLG1_APO_END); }; return _filler_54; }
                    set { VarBasis.RedefinePassValue(value, _filler_54, WS_IDLG1_APO_END); }
                }  //Redefines
                public class _REDEF_PF2002B_FILLER_54 : VarBasis
                {
                    /*"         15 WS-IDLG1-END-APO-R4    PIC 9(13).*/
                    public IntBasis WS_IDLG1_END_APO_R4 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG1-END-NUM-R4    PIC 9(03).*/
                    public IntBasis WS_IDLG1_END_NUM_R4 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 WS-IDLG1-END-PAR-R4    PIC 9(02).*/
                    public IntBasis WS_IDLG1_END_PAR_R4 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER                 PIC X(09).*/
                    public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                    /*"   03 FILLER REDEFINES WS-COD-IDLG-1.*/

                    public _REDEF_PF2002B_FILLER_54()
                    {
                        WS_IDLG1_END_APO_R4.ValueChanged += OnValueChanged;
                        WS_IDLG1_END_NUM_R4.ValueChanged += OnValueChanged;
                        WS_IDLG1_END_PAR_R4.ValueChanged += OnValueChanged;
                        FILLER_55.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF2002B_FILLER_44()
                {
                    WS_IDLG1_EMP_SIST_TIPO.ValueChanged += OnValueChanged;
                    WS_IDLG1_APO_END.ValueChanged += OnValueChanged;
                    FILLER_45.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF2002B_FILLER_56 _filler_56 { get; set; }
            public _REDEF_PF2002B_FILLER_56 FILLER_56
            {
                get { _filler_56 = new _REDEF_PF2002B_FILLER_56(); _.Move(WS_COD_IDLG_1, _filler_56); VarBasis.RedefinePassValue(WS_COD_IDLG_1, _filler_56, WS_COD_IDLG_1); _filler_56.ValueChanged += () => { _.Move(_filler_56, WS_COD_IDLG_1); }; return _filler_56; }
                set { VarBasis.RedefinePassValue(value, _filler_56, WS_COD_IDLG_1); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_56 : VarBasis
            {
                /*"      10 WS-IDLG2-EMP-SIST-TIPO    PIC X(14).*/
                public StringBasis WS_IDLG2_EMP_SIST_TIPO { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
                /*"      10 WS-IDLG2-NUM-APOLICE      PIC 9(13).*/
                public IntBasis WS_IDLG2_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"      10 WS-IDLG2-NUM-ENDOSSO      PIC 9(04).*/
                public IntBasis WS_IDLG2_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 WS-IDLG2-NUM-PARCELA      PIC 9(03).*/
                public IntBasis WS_IDLG2_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-IDLG2-FILLER           PIC 9(06).*/
                public IntBasis WS_IDLG2_FILLER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"  03         WWORK-AGEAVISO    PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_PF2002B_FILLER_56()
                {
                    WS_IDLG2_EMP_SIST_TIPO.ValueChanged += OnValueChanged;
                    WS_IDLG2_NUM_APOLICE.ValueChanged += OnValueChanged;
                    WS_IDLG2_NUM_ENDOSSO.ValueChanged += OnValueChanged;
                    WS_IDLG2_NUM_PARCELA.ValueChanged += OnValueChanged;
                    WS_IDLG2_FILLER.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WWORK_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03         FILLER            REDEFINES      WWORK-AGEAVISO.*/
        private _REDEF_PF2002B_FILLER_57 _filler_57 { get; set; }
        public _REDEF_PF2002B_FILLER_57 FILLER_57
        {
            get { _filler_57 = new _REDEF_PF2002B_FILLER_57(); _.Move(WWORK_AGEAVISO, _filler_57); VarBasis.RedefinePassValue(WWORK_AGEAVISO, _filler_57, WWORK_AGEAVISO); _filler_57.ValueChanged += () => { _.Move(_filler_57, WWORK_AGEAVISO); }; return _filler_57; }
            set { VarBasis.RedefinePassValue(value, _filler_57, WWORK_AGEAVISO); }
        }  //Redefines
        public class _REDEF_PF2002B_FILLER_57 : VarBasis
        {
            /*"    10       WWORK-TIP-AGE     PIC  9(001).*/
            public IntBasis WWORK_TIP_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    10       WWORK-COD-AGE     PIC  9(003).*/
            public IntBasis WWORK_COD_AGE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03         WWORK-NRAVISO     PIC  9(009)    VALUE ZEROS.*/

            public _REDEF_PF2002B_FILLER_57()
            {
                WWORK_TIP_AGE.ValueChanged += OnValueChanged;
                WWORK_COD_AGE.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WWORK_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"  03         FILLER            REDEFINES      WWORK-NRAVISO.*/
        private _REDEF_PF2002B_FILLER_58 _filler_58 { get; set; }
        public _REDEF_PF2002B_FILLER_58 FILLER_58
        {
            get { _filler_58 = new _REDEF_PF2002B_FILLER_58(); _.Move(WWORK_NRAVISO, _filler_58); VarBasis.RedefinePassValue(WWORK_NRAVISO, _filler_58, WWORK_NRAVISO); _filler_58.ValueChanged += () => { _.Move(_filler_58, WWORK_NRAVISO); }; return _filler_58; }
            set { VarBasis.RedefinePassValue(value, _filler_58, WWORK_NRAVISO); }
        }  //Redefines
        public class _REDEF_PF2002B_FILLER_58 : VarBasis
        {
            /*"    10       WWORK-AVS-AGE     PIC  9(004).*/
            public IntBasis WWORK_AVS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WWORK-AVS-NRO     PIC  9(005).*/
            public IntBasis WWORK_AVS_NRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  03         WS-AGE-CEDENTE    PIC  9(006)    VALUE ZEROS.*/

            public _REDEF_PF2002B_FILLER_58()
            {
                WWORK_AVS_AGE.ValueChanged += OnValueChanged;
                WWORK_AVS_NRO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_AGE_CEDENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"  03         FILLER            REDEFINES      WS-AGE-CEDENTE.*/
        private _REDEF_PF2002B_FILLER_59 _filler_59 { get; set; }
        public _REDEF_PF2002B_FILLER_59 FILLER_59
        {
            get { _filler_59 = new _REDEF_PF2002B_FILLER_59(); _.Move(WS_AGE_CEDENTE, _filler_59); VarBasis.RedefinePassValue(WS_AGE_CEDENTE, _filler_59, WS_AGE_CEDENTE); _filler_59.ValueChanged += () => { _.Move(_filler_59, WS_AGE_CEDENTE); }; return _filler_59; }
            set { VarBasis.RedefinePassValue(value, _filler_59, WS_AGE_CEDENTE); }
        }  //Redefines
        public class _REDEF_PF2002B_FILLER_59 : VarBasis
        {
            /*"    10       FILLER            PIC  9(002).*/
            public IntBasis FILLER_60 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WS-CEDENTE        PIC  9(004).*/
            public IntBasis WS_CEDENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03         WABEND.*/

            public _REDEF_PF2002B_FILLER_59()
            {
                FILLER_60.ValueChanged += OnValueChanged;
                WS_CEDENTE.ValueChanged += OnValueChanged;
            }

        }
        public PF2002B_WABEND WABEND { get; set; } = new PF2002B_WABEND();
        public class PF2002B_WABEND : VarBasis
        {
            /*"    05       FILLER             PIC  X(010)    VALUE            ' PF2002B  '.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PF2002B  ");
            /*"    05       FILLER             PIC  X(028)    VALUE            ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05       WNR-EXEC-SQL       PIC  X(005).*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"    05       FILLER             PIC  X(013)    VALUE            '   SQLCODE = '.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"   SQLCODE = ");
            /*"    05       WSQLCODE           PIC  ZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
            /*"    05      FILLER              PIC  X(014)    VALUE           '   SQLERRD1 = '.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05       WSQLERRD1          PIC  ZZZZZ999-.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
            /*"    05       FILLER             PIC  X(014)    VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05       WSQLERRD2          PIC  ZZZZZ999-.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
            /*"  03    COBRAN-REGISTRO.*/
        }
        public PF2002B_COBRAN_REGISTRO COBRAN_REGISTRO { get; set; } = new PF2002B_COBRAN_REGISTRO();
        public class PF2002B_COBRAN_REGISTRO : VarBasis
        {
            /*"      10   COBRAN-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
            public StringBasis COBRAN_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"      10   COBRAN-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
            public IntBasis COBRAN_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"      10   COBRAN-IDLG              PIC  X(040) VALUE SPACES.*/
            public StringBasis COBRAN_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"      10   COBRAN-BUKRS             PIC  X(004) VALUE SPACES.*/
            public StringBasis COBRAN_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"      10   COBRAN-NSAC              PIC  9(005) VALUE ZEROS.*/
            public IntBasis COBRAN_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"      10   COBRAN-NUM-PROPOSTA      PIC  9(016) VALUE ZEROS.*/
            public IntBasis COBRAN_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"      10   COBRAN-NUM-BOL-INTERNO   PIC  X(010) VALUE SPACES.*/
            public StringBasis COBRAN_NUM_BOL_INTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"      10   COBRAN-NN-REGISTRADO     PIC  9(018) VALUE ZEROS.*/
            public IntBasis COBRAN_NN_REGISTRADO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"      10   COBRAN-LNHA-DIGITAVEL    PIC  X(054) VALUE SPACES.*/
            public StringBasis COBRAN_LNHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
            /*"      10   COBRAN-COD-AG-CEDENTE    PIC  X(020).*/
            public StringBasis COBRAN_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      10   COBRAN-CEDENTE-R REDEFINES COBRAN-COD-AG-CEDENTE.*/
            private _REDEF_PF2002B_COBRAN_CEDENTE_R _cobran_cedente_r { get; set; }
            public _REDEF_PF2002B_COBRAN_CEDENTE_R COBRAN_CEDENTE_R
            {
                get { _cobran_cedente_r = new _REDEF_PF2002B_COBRAN_CEDENTE_R(); _.Move(COBRAN_COD_AG_CEDENTE, _cobran_cedente_r); VarBasis.RedefinePassValue(COBRAN_COD_AG_CEDENTE, _cobran_cedente_r, COBRAN_COD_AG_CEDENTE); _cobran_cedente_r.ValueChanged += () => { _.Move(_cobran_cedente_r, COBRAN_COD_AG_CEDENTE); }; return _cobran_cedente_r; }
                set { VarBasis.RedefinePassValue(value, _cobran_cedente_r, COBRAN_COD_AG_CEDENTE); }
            }  //Redefines
            public class _REDEF_PF2002B_COBRAN_CEDENTE_R : VarBasis
            {
                /*"         15  FILLER                 PIC  X(012).*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"         15  COBRAN-COD-CEDENTE.*/
                public PF2002B_COBRAN_COD_CEDENTE COBRAN_COD_CEDENTE { get; set; } = new PF2002B_COBRAN_COD_CEDENTE();
                public class PF2002B_COBRAN_COD_CEDENTE : VarBasis
                {
                    /*"            20  FILLER              PIC  9(002).*/
                    public IntBasis FILLER_67 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            20  COBRAN-COD-AGE-CED  PIC  9(004).*/
                    public IntBasis COBRAN_COD_AGE_CED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15  FILLER         REDEFINES COBRAN-COD-CEDENTE.*/

                    public PF2002B_COBRAN_COD_CEDENTE()
                    {
                        FILLER_67.ValueChanged += OnValueChanged;
                        COBRAN_COD_AGE_CED.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF2002B_FILLER_68 _filler_68 { get; set; }
                public _REDEF_PF2002B_FILLER_68 FILLER_68
                {
                    get { _filler_68 = new _REDEF_PF2002B_FILLER_68(); _.Move(COBRAN_COD_CEDENTE, _filler_68); VarBasis.RedefinePassValue(COBRAN_COD_CEDENTE, _filler_68, COBRAN_COD_CEDENTE); _filler_68.ValueChanged += () => { _.Move(_filler_68, COBRAN_COD_CEDENTE); }; return _filler_68; }
                    set { VarBasis.RedefinePassValue(value, _filler_68, COBRAN_COD_CEDENTE); }
                }  //Redefines
                public class _REDEF_PF2002B_FILLER_68 : VarBasis
                {
                    /*"            20  COBRAN-COD-CEDENTE-N PIC 9(006).*/
                    public IntBasis COBRAN_COD_CEDENTE_N { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"         15  FILLER                 PIC  X(001).*/

                    public _REDEF_PF2002B_FILLER_68()
                    {
                        COBRAN_COD_CEDENTE_N.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         15  COBRAN-DV-CEDENTE      PIC  9(001).*/
                public IntBasis COBRAN_DV_CEDENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10   COBRAN-NUM-BCO-RECEB     PIC  9(003) VALUE ZEROS.*/

                public _REDEF_PF2002B_COBRAN_CEDENTE_R()
                {
                    FILLER_66.ValueChanged += OnValueChanged;
                    COBRAN_COD_CEDENTE.ValueChanged += OnValueChanged;
                    FILLER_68.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis COBRAN_NUM_BCO_RECEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"      10   COBRAN-NUM-AGE-RECEB     PIC  9(005) VALUE ZEROS.*/
            public IntBasis COBRAN_NUM_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"      10   COBRAN-DV-AGE-RECEB      PIC  9(001) VALUE ZEROS.*/
            public IntBasis COBRAN_DV_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"      10   COBRAN-DTA-VENCIMENTO.*/
            public PF2002B_COBRAN_DTA_VENCIMENTO COBRAN_DTA_VENCIMENTO { get; set; } = new PF2002B_COBRAN_DTA_VENCIMENTO();
            public class PF2002B_COBRAN_DTA_VENCIMENTO : VarBasis
            {
                /*"         15 COBRAN-DIA-VENCIMENFTO  PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_DIA_VENCIMENFTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-MES-VENCIMENTO   PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_MES_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-ANO-VENCIMENTO   PIC  9(004) VALUE ZEROS.*/
                public IntBasis COBRAN_ANO_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10   COBRAN-DTA-PAGAMENTO.*/
            }
            public PF2002B_COBRAN_DTA_PAGAMENTO COBRAN_DTA_PAGAMENTO { get; set; } = new PF2002B_COBRAN_DTA_PAGAMENTO();
            public class PF2002B_COBRAN_DTA_PAGAMENTO : VarBasis
            {
                /*"         15 COBRAN-DIA-PAGAMENTO    PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_DIA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-MES-PAGAMENTO    PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_MES_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-ANO-PAGAMENTO    PIC  9(004) VALUE ZEROS.*/
                public IntBasis COBRAN_ANO_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10   COBRAN-DTA-CREDITO.*/
            }
            public PF2002B_COBRAN_DTA_CREDITO COBRAN_DTA_CREDITO { get; set; } = new PF2002B_COBRAN_DTA_CREDITO();
            public class PF2002B_COBRAN_DTA_CREDITO : VarBasis
            {
                /*"         15 COBRAN-DIA-CREDITO      PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_DIA_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-MES-CREDITO      PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_MES_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-ANO-CREDITO      PIC  9(004) VALUE ZEROS.*/
                public IntBasis COBRAN_ANO_CREDITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10   COBRAN-DTA-DEB-TARIFA.*/
            }
            public PF2002B_COBRAN_DTA_DEB_TARIFA COBRAN_DTA_DEB_TARIFA { get; set; } = new PF2002B_COBRAN_DTA_DEB_TARIFA();
            public class PF2002B_COBRAN_DTA_DEB_TARIFA : VarBasis
            {
                /*"         15 COBRAN-DIA-DEB-TARIFA   PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_DIA_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-MES-DEB-TARIFA   PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_MES_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-ANO-DEB-TARIFA   PIC  9(004) VALUE ZEROS.*/
                public IntBasis COBRAN_ANO_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10   COBRAN-VLR-ACRESCIMO     PIC  9(013)V99 VALUE ZEROS.*/
            }
            public DoubleBasis COBRAN_VLR_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-VLR-DESCONTO      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis COBRAN_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-VLR-ABATIMENTO    PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis COBRAN_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-VLR-IOF           PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis COBRAN_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-VLR-PAGO          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis COBRAN_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-VLR-LIQUIDO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis COBRAN_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-VLR-TARIFA        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis COBRAN_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"      10   COBRAN-COD-MOVIMENTO     PIC  9(002) VALUE ZEROS.*/
            public IntBasis COBRAN_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10   COBRAN-COD-REJEICAO      PIC  X(010) VALUE SPACES.*/
            public StringBasis COBRAN_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"      10   COBRAN-NUM-TITULO        PIC  9(016) VALUE ZEROS.*/
            public IntBasis COBRAN_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"      10   COBRAN-COD-SISTEMA       PIC  X(003) VALUE SPACES.*/
            public StringBasis COBRAN_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"      10   COBRAN-NUM-PARCELA       PIC  9(003) VALUE ZEROS.*/
            public IntBasis COBRAN_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"      10   COBRAN-COD-PRODUTO       PIC  9(004) VALUE ZEROS.*/
            public IntBasis COBRAN_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"      10   COBRAN-DTA-GERACAO.*/
            public PF2002B_COBRAN_DTA_GERACAO COBRAN_DTA_GERACAO { get; set; } = new PF2002B_COBRAN_DTA_GERACAO();
            public class PF2002B_COBRAN_DTA_GERACAO : VarBasis
            {
                /*"         15 COBRAN-DIA-GERACAO      PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_DIA_GERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-MES-GERACAO      PIC  9(002) VALUE ZEROS.*/
                public IntBasis COBRAN_MES_GERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"         15 COBRAN-ANO-GERACAO      PIC  9(004) VALUE ZEROS.*/
                public IntBasis COBRAN_ANO_GERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10   COBRAN-AGE-AVISO         PIC  9(004) VALUE ZEROS.*/
            }
            public IntBasis COBRAN_AGE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"      10   COBRAN-TIPO-AVISO        PIC  X(001) VALUE SPACES.*/
            public StringBasis COBRAN_TIPO_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      10   COBRAN-TIPO-MOVIMENTO    PIC  X(001) VALUE SPACES.*/
            public StringBasis COBRAN_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"      10   COBRAN-CANAL-VENDA       PIC  9(001) VALUE ZEROS.*/
            public IntBasis COBRAN_CANAL_VENDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"      10   COBRAN-PROD-SIVPF        PIC  9(002) VALUE ZEROS.*/
            public IntBasis COBRAN_PROD_SIVPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"      10   FILLER                   PIC  X(021) VALUE SPACES.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"01             WS-TIT-AUTO.*/
        }
        public PF2002B_WS_TIT_AUTO WS_TIT_AUTO { get; set; } = new PF2002B_WS_TIT_AUTO();
        public class PF2002B_WS_TIT_AUTO : VarBasis
        {
            /*"  03           WS-TIT-AUTO-16     PIC  9(016).*/
            public IntBasis WS_TIT_AUTO_16 { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  03           FILLER             REDEFINES   WS-TIT-AUTO-16.*/
            private _REDEF_PF2002B_FILLER_71 _filler_71 { get; set; }
            public _REDEF_PF2002B_FILLER_71 FILLER_71
            {
                get { _filler_71 = new _REDEF_PF2002B_FILLER_71(); _.Move(WS_TIT_AUTO_16, _filler_71); VarBasis.RedefinePassValue(WS_TIT_AUTO_16, _filler_71, WS_TIT_AUTO_16); _filler_71.ValueChanged += () => { _.Move(_filler_71, WS_TIT_AUTO_16); }; return _filler_71; }
                set { VarBasis.RedefinePassValue(value, _filler_71, WS_TIT_AUTO_16); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_71 : VarBasis
            {
                /*"    05         WS-1-POS           PIC  9(001).*/
                public IntBasis WS_1_POS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         WS-CANAL-AUTO      PIC  9(001).*/
                public IntBasis WS_CANAL_AUTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         WS-AGE-COB-AUTO    PIC  9(004).*/
                public IntBasis WS_AGE_COB_AUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05         WS-PROD-AUTO       PIC  9(002).*/
                public IntBasis WS_PROD_AUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05         RESTO-TIT-AUTO     PIC  X(008).*/
                public StringBasis RESTO_TIT_AUTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01             LPARM11X.*/

                public _REDEF_PF2002B_FILLER_71()
                {
                    WS_1_POS.ValueChanged += OnValueChanged;
                    WS_CANAL_AUTO.ValueChanged += OnValueChanged;
                    WS_AGE_COB_AUTO.ValueChanged += OnValueChanged;
                    WS_PROD_AUTO.ValueChanged += OnValueChanged;
                    RESTO_TIT_AUTO.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF2002B_LPARM11X LPARM11X { get; set; } = new PF2002B_LPARM11X();
        public class PF2002B_LPARM11X : VarBasis
        {
            /*"  03           LPARM11            PIC  9(010).*/
            public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03           FILLER             REDEFINES   LPARM11.*/
            private _REDEF_PF2002B_FILLER_72 _filler_72 { get; set; }
            public _REDEF_PF2002B_FILLER_72 FILLER_72
            {
                get { _filler_72 = new _REDEF_PF2002B_FILLER_72(); _.Move(LPARM11, _filler_72); VarBasis.RedefinePassValue(LPARM11, _filler_72, LPARM11); _filler_72.ValueChanged += () => { _.Move(_filler_72, LPARM11); }; return _filler_72; }
                set { VarBasis.RedefinePassValue(value, _filler_72, LPARM11); }
            }  //Redefines
            public class _REDEF_PF2002B_FILLER_72 : VarBasis
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
                /*"01  WS-AGENCIACEF.*/

                public _REDEF_PF2002B_FILLER_72()
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
        public PF2002B_WS_AGENCIACEF WS_AGENCIACEF { get; set; } = new PF2002B_WS_AGENCIACEF();
        public class PF2002B_WS_AGENCIACEF : VarBasis
        {
            /*"  03          WACEF-AGENCIAS.*/
            public PF2002B_WACEF_AGENCIAS WACEF_AGENCIAS { get; set; } = new PF2002B_WACEF_AGENCIAS();
            public class PF2002B_WACEF_AGENCIAS : VarBasis
            {
                /*"    05        WACEF-OCORREAGE     OCCURS       6000  TIMES                                  INDEXED      BY    WS-AGE.*/
                public ListBasis<PF2002B_WACEF_OCORREAGE> WACEF_OCORREAGE { get; set; } = new ListBasis<PF2002B_WACEF_OCORREAGE>(6000);
                public class PF2002B_WACEF_OCORREAGE : VarBasis
                {
                    /*"    10        WACEF-AGENCIA       PIC S9(004)        COMP.*/
                    public IntBasis WACEF_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-ESCNEG        PIC S9(004)        COMP.*/
                    public IntBasis WACEF_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"    10        WACEF-FONTE         PIC S9(004)        COMP.*/
                    public IntBasis WACEF_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"01  WS-PRODUTOSIVPF.*/
                }
            }
            public PF2002B_WS_PRODUTOSIVPF WS_PRODUTOSIVPF { get; set; } = new PF2002B_WS_PRODUTOSIVPF();
            public class PF2002B_WS_PRODUTOSIVPF : VarBasis
            {
                /*"  03          WPROD-PRODUTOS.*/
                public PF2002B_WPROD_PRODUTOS WPROD_PRODUTOS { get; set; } = new PF2002B_WPROD_PRODUTOS();
                public class PF2002B_WPROD_PRODUTOS : VarBasis
                {
                    /*"    05        WPROD-OCORREPRD     OCCURS       100   TIMES                                  INDEXED      BY    WS-PRD.*/
                    public ListBasis<PF2002B_WPROD_OCORREPRD> WPROD_OCORREPRD { get; set; } = new ListBasis<PF2002B_WPROD_OCORREPRD>(100);
                    public class PF2002B_WPROD_OCORREPRD : VarBasis
                    {
                        /*"    10        WPROD-PRDSIVPF      PIC S9(004)        COMP.*/
                        public IntBasis WPROD_PRDSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"    10        WPROD-CODPRODU      PIC S9(004)        COMP.*/
                        public IntBasis WPROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"01  AUX-TABELAS.*/
                    }
                }
                public PF2002B_AUX_TABELAS AUX_TABELAS { get; set; } = new PF2002B_AUX_TABELAS();
                public class PF2002B_AUX_TABELAS : VarBasis
                {
                    /*"  03          WTABG-VALORES.*/
                    public PF2002B_WTABG_VALORES WTABG_VALORES { get; set; } = new PF2002B_WTABG_VALORES();
                    public class PF2002B_WTABG_VALORES : VarBasis
                    {
                        /*"    05        WTABG-OCORRECED     OCCURS      18     TIMES                                  INDEXED      BY    WS-CDT.*/
                        public ListBasis<PF2002B_WTABG_OCORRECED> WTABG_OCORRECED { get; set; } = new ListBasis<PF2002B_WTABG_OCORRECED>(18);
                        public class PF2002B_WTABG_OCORRECED : VarBasis
                        {
                            /*"        10    WTABG-CODAGEAVISO   PIC S9(004)        COMP.*/
                            public IntBasis WTABG_CODAGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"        10    WTABG-ORIGAVISO     PIC S9(004)        COMP.*/
                            public IntBasis WTABG_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"        10    WTABG-OCORREPRD     OCCURS      2000   TIMES                                  INDEXED      BY    WS-PRO.*/
                            public ListBasis<PF2002B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<PF2002B_WTABG_OCORREPRD>(2000);
                            public class PF2002B_WTABG_OCORREPRD : VarBasis
                            {
                                /*"           20 WTABG-CODPRODU      PIC S9(004)        COMP.*/
                                public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                                /*"           20 WTABG-OCORRETIP     OCCURS       005   TIMES                                  INDEXED      BY    WS-TIP.*/
                                public ListBasis<PF2002B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<PF2002B_WTABG_OCORRETIP>(005);
                                public class PF2002B_WTABG_OCORRETIP : VarBasis
                                {
                                    /*"             25  WTABG-TIPO          PIC  X(001).*/
                                    public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                    /*"             25  WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                                    public ListBasis<PF2002B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<PF2002B_WTABG_OCORRESIT>(002);
                                    public class PF2002B_WTABG_OCORRESIT : VarBasis
                                    {
                                        /*"               30  WTABG-SITUACAO      PIC  X(001).*/
                                        public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                        /*"               30  WTABG-QTDE          PIC S9(009)        COMP.*/
                                        public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                                        /*"               30  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3*/
                                        public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                        /*"               30  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3*/
                                        public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                        /*"               30  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3*/
                                        public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                        /*"               30  WTABG-VLIOCC        PIC S9(013)V99     COMP-3*/
                                        public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                        /*"               30  WTABG-VLDESCON      PIC S9(013)V99     COMP-3*/
                                        public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                        /*"01  WS-COBERTURAS.*/
                                    }
                                }
                            }
                        }
                    }
                }
                public PF2002B_WS_COBERTURAS WS_COBERTURAS { get; set; } = new PF2002B_WS_COBERTURAS();
                public class PF2002B_WS_COBERTURAS : VarBasis
                {
                    /*"  03          WCOBE-COBERTUR.*/
                    public PF2002B_WCOBE_COBERTUR WCOBE_COBERTUR { get; set; } = new PF2002B_WCOBE_COBERTUR();
                    public class PF2002B_WCOBE_COBERTUR : VarBasis
                    {
                        /*"    05        WCOBE-OCORRECOB     OCCURS       100   TIMES                                  INDEXED      BY    WS-COB.*/
                        public ListBasis<PF2002B_WCOBE_OCORRECOB> WCOBE_OCORRECOB { get; set; } = new ListBasis<PF2002B_WCOBE_OCORRECOB>(100);
                        public class PF2002B_WCOBE_OCORRECOB : VarBasis
                        {
                            /*"      10      WCOBE-RAMOFR        PIC S9(004)        COMP.*/
                            public IntBasis WCOBE_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"      10      WCOBE-CODOPCAO      PIC S9(004)        COMP.*/
                            public IntBasis WCOBE_CODOPCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"      10      WCOBE-VLPRMTAR      PIC S9(010)V9(05)  COMP-3.*/
                            public DoubleBasis WCOBE_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
                            /*"      10      WCOBE-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WCOBE_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"      10      WCOBE-PCIOCC        PIC S9(003)V99     COMP-3.*/
                            public DoubleBasis WCOBE_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
                            /*"01  WS-CEDENTES.*/
                        }
                    }
                }
                public PF2002B_WS_CEDENTES WS_CEDENTES { get; set; } = new PF2002B_WS_CEDENTES();
                public class PF2002B_WS_CEDENTES : VarBasis
                {
                    /*"  03          WCEDE-CCEDENTE.*/
                    public PF2002B_WCEDE_CCEDENTE WCEDE_CCEDENTE { get; set; } = new PF2002B_WCEDE_CCEDENTE();
                    public class PF2002B_WCEDE_CCEDENTE : VarBasis
                    {
                        /*"    05        WCEDE-OCORRECED     OCCURS       010   TIMES                                  INDEXED      BY    WS-CED.*/
                        public ListBasis<PF2002B_WCEDE_OCORRECED> WCEDE_OCORRECED { get; set; } = new ListBasis<PF2002B_WCEDE_OCORRECED>(010);
                        public class PF2002B_WCEDE_OCORRECED : VarBasis
                        {
                            /*"      10      WCEDE-CODEMPRESA    PIC  9(016).*/
                            public IntBasis WCEDE_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                            /*"01     W88-NUM-PROPOSTA                    PIC 9(014).*/
                        }
                    }
                }
                public IntBasis W88_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"01     CANAL   REDEFINES W88-NUM-PROPOSTA.*/
                private _REDEF_PF2002B_CANAL _canal { get; set; }
                public _REDEF_PF2002B_CANAL CANAL
                {
                    get { _canal = new _REDEF_PF2002B_CANAL(); _.Move(W88_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W88_NUM_PROPOSTA, _canal, W88_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W88_NUM_PROPOSTA); }; return _canal; }
                    set { VarBasis.RedefinePassValue(value, _canal, W88_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF2002B_CANAL : VarBasis
                {
                    /*"       05 W88-CANAL-PROPOSTA                  PIC 9(001).*/

                    public SelectorBasis W88_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                    {
                        Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-GRAFICA                  VALUE 0, 6. */
							new SelectorItemBasis("CANAL_VENDA_GRAFICA", "0,6"),
							/*" 88 CANAL-VENDA-CAIXA                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CAIXA", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-CORREIO                  VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_CORREIO", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                    };

                    /*"      05  FILLER                             PIC 9(013).*/
                    public IntBasis FILLER_73 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));

                    public _REDEF_PF2002B_CANAL()
                    {
                        W88_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                        FILLER_73.ValueChanged += OnValueChanged;
                    }

                }
            }
        }


        public Copies.JVBKINCL JVBKINCL { get; set; } = new Copies.JVBKINCL();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOSTA PROPOSTA { get; set; } = new Dclgens.PROPOSTA();
        public Dclgens.MR028 MR028 { get; set; } = new Dclgens.MR028();
        public Dclgens.PROPOAUT PROPOAUT { get; set; } = new Dclgens.PROPOAUT();
        public Dclgens.PF087 PF087 { get; set; } = new Dclgens.PF087();
        public PF2002B_V0AGENCIAS V0AGENCIAS { get; set; } = new PF2002B_V0AGENCIAS();
        public PF2002B_V0PRDSIVPF V0PRDSIVPF { get; set; } = new PF2002B_V0PRDSIVPF();
        public PF2002B_V0PRODUTO V0PRODUTO { get; set; } = new PF2002B_V0PRODUTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PF2002B_PF2002B_SYSIN PF2002B_PF2002B_SYSIN_P, string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P, string PF2002B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.PF2002B_SYSIN = PF2002B_PF2002B_SYSIN_P;
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                MOVIMENTO_COBRANCA.SetFile(MOVIMENTO_COBRANCA_FILE_NAME_P);
                PF2002B1.SetFile(PF2002B1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-PRINCIPAL-SECTION */

                R0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { PF2002B_SYSIN, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-PRINCIPAL-SECTION */
        private void R0000_PRINCIPAL_SECTION()
        {
            /*" -1258- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -1259- DISPLAY ' ' */
            _.Display($" ");

            /*" -1261- DISPLAY '***************************************************' '***************************************************' */
            _.Display($"******************************************************************************************************");

            /*" -1269- DISPLAY 'PROGRAMA PF2002BX- VERSAO V.31 - DEMANDA 418888 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA PF2002BX- VERSAO V.31 - DEMANDA 418888 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1271- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1272- DISPLAY 'CONSISTENCIA E CONTROLE DO MOV. COBRANCA' */
            _.Display($"CONSISTENCIA E CONTROLE DO MOV. COBRANCA");

            /*" -1274- DISPLAY '***************************************************' '***************************************************' */
            _.Display($"******************************************************************************************************");

            /*" -1275- DISPLAY ' ' */
            _.Display($" ");

            /*" -1283- DISPLAY 'PF2002B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"PF2002B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1286- DISPLAY ' ' */
            _.Display($" ");

            /*" -1288- PERFORM R0050-INICIALIZA. */

            R0050_INICIALIZA_SECTION();

            /*" -1295- SORT ARQSORT ON ASCENDING KEY SOR-AGE-AVISO SOR-TIPO-AVISO SOR-TIPO-MOVIMENTO INPUT PROCEDURE R0300-INPUT-SORT THRU R0300-INPUT-SORT-EXIT OUTPUT PROCEDURE R1500-OUTPUT-SORT THRU R1500-OUTPUT-SORT-EXIT. */
            ARQSORT.Sort("SOR-AGE-AVISO,SOR-TIPO-AVISO,SOR-TIPO-MOVIMENTO", () => R0300_INPUT_SORT_SECTION(), () => R1500_OUTPUT_SORT_SECTION());

            /*" -1298- IF W-SORT-OUTPUT-RETC NOT = 0 */

            if (WS_AUX_ARQUIVO.W_SORT_OUTPUT_RETC != 0)
            {

                /*" -1299- DISPLAY ' ' */
                _.Display($" ");

                /*" -1301- DISPLAY '################################################' '################################################' */
                _.Display($"################################################################################################");

                /*" -1303- DISPLAY 'R0000-PROBLEMAS NO PROCESSAMENTO DA ' 'OUTPUT PROCEDURE' */
                _.Display($"R0000-PROBLEMAS NO PROCESSAMENTO DA OUTPUT PROCEDURE");

                /*" -1304- DISPLAY 'RETC=' W-SORT-OUTPUT-RETC */
                _.Display($"RETC={WS_AUX_ARQUIVO.W_SORT_OUTPUT_RETC}");

                /*" -1306- DISPLAY '################################################' '################################################' */
                _.Display($"################################################################################################");

                /*" -1307- GO TO R9900-ENCERRA-COM-ERRO */

                R9900_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;

                /*" -1310- END-IF */
            }


            /*" -1311- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1313- DISPLAY W-PROGRAMA-CHAMADOR '-R0000-PRINCIPAL' '-VAI PROCESSAR R8450' */

                $"{W_PROGRAMA_CHAMADOR}-R0000-PRINCIPAL-VAI PROCESSAR R8450"
                .Display();

                /*" -1315- END-IF */
            }


            /*" -1316- SET WS-CDT TO 1 */
            WS_CDT.Value = 1;

            /*" -1318- PERFORM R8450-GRAVA-AVISOS 18 TIMES */

            for (int i = 0; i < 18; i++)
            {

                R8450_GRAVA_AVISOS_SECTION();

            }

            /*" -1318- GO TO R9000-FINALIZA. */

            R9000_FINALIZA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_PRINCIPAL_EXIT*/

        [StopWatch]
        /*" R0050-INICIALIZA-SECTION */
        private void R0050_INICIALIZA_SECTION()
        {
            /*" -1332- INITIALIZE PF2002B-TRACE */
            _.Initialize(
                PF2002B_SYSIN.PF2002B_TRACE
            );

            /*" -1333- ACCEPT PF2002B-SYSIN FROM SYSIN */
            /*-Accept convertido para parametro de entrada...*/

            /*" -1335- MOVE PF2002B-TRACE TO W-CT-TRACE */
            _.Move(PF2002B_SYSIN.PF2002B_TRACE, W_CT_TRACE);

            /*" -1336- DISPLAY W-PROGRAMA-CHAMADOR '-R0050-INICIALIZA' */
            _.Display($"{W_PROGRAMA_CHAMADOR}-R0050-INICIALIZA");

            /*" -1338- DISPLAY 'PARAMETRO TRACE SYSIN ACESSADO <' PF2002B-TRACE '>' */

            $"PARAMETRO TRACE SYSIN ACESSADO <{PF2002B_SYSIN.PF2002B_TRACE}>"
            .Display();

            /*" -1340- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WABEND.WNR_EXEC_SQL);

            /*" -1342- INITIALIZE W-SORT-OUTPUT-RETC */
            _.Initialize(
                WS_AUX_ARQUIVO.W_SORT_OUTPUT_RETC
            );

            /*" -1343- OPEN INPUT MOVIMENTO-COBRANCA */
            MOVIMENTO_COBRANCA.Open(REG_COBRANCA);

            /*" -1345- OUTPUT PF2002B1. */
            PF2002B1.Open(REG_PF2002B1);

            /*" -1347- PERFORM R0100-SELECT-V0SISTEMA. */

            R0100_SELECT_V0SISTEMA_SECTION();

            /*" -1349- PERFORM R0105-SELECT-V0RELATORIOS. */

            R0105_SELECT_V0RELATORIOS_SECTION();

            /*" -1350- SET WS-AGE TO 1. */
            WS_AGE.Value = 1;

            /*" -1351- MOVE SPACES TO WFIM-AGENCIAS */
            _.Move("", WS_AUX_ARQUIVO.WFIM_AGENCIAS);

            /*" -1353- PERFORM R0110-DECLARE-V0AGENCIAS. */

            R0110_DECLARE_V0AGENCIAS_SECTION();

            /*" -1354- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1356- DISPLAY W-PROGRAMA-CHAMADOR '-R0050-INICIALIZA' '-VAI PROCESSAR R0120' */

                $"{W_PROGRAMA_CHAMADOR}-R0050-INICIALIZA-VAI PROCESSAR R0120"
                .Display();

                /*" -1359- END-IF */
            }


            /*" -1362- PERFORM R0120-FETCH-V0AGENCIAS UNTIL WFIM-AGENCIAS NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_AGENCIAS.IsEmpty()))
            {

                R0120_FETCH_V0AGENCIAS_SECTION();
            }

            /*" -1366- MOVE 9999 TO V0ACEF-AGENCIA V0ACEF-ESCNEG V0ACEF-FONTE. */
            _.Move(9999, V0ACEF_AGENCIA, V0ACEF_ESCNEG, V0ACEF_FONTE);

            /*" -1367- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1369- DISPLAY W-PROGRAMA-CHAMADOR '-R0050-INICIALIZA' '-VAI PROCESSAR R0130' */

                $"{W_PROGRAMA_CHAMADOR}-R0050-INICIALIZA-VAI PROCESSAR R0130"
                .Display();

                /*" -1372- END-IF */
            }


            /*" -1373- SET WS-SUBS TO WS-AGE */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_AGE;

            /*" -1376- PERFORM R0130-LIMPA-TABELA UNTIL WS-SUBS GREATER 6000. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 6000))
            {

                R0130_LIMPA_TABELA_SECTION();
            }

            /*" -1377- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1379- DISPLAY W-PROGRAMA-CHAMADOR '-R0050-INICIALIZA' '-PROCESSOU     R0130' */

                $"{W_PROGRAMA_CHAMADOR}-R0050-INICIALIZA-PROCESSOU     R0130"
                .Display();

                /*" -1388- END-IF */
            }


            /*" -1389- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -1390- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WS_AUX_ARQUIVO.WFIM_PRODUTO);

            /*" -1392- PERFORM R0150-DECLARE-V0PRDSIVPF. */

            R0150_DECLARE_V0PRDSIVPF_SECTION();

            /*" -1395- PERFORM R0160-FETCH-V0PRDSIVPF UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_PRODUTO.IsEmpty()))
            {

                R0160_FETCH_V0PRDSIVPF_SECTION();
            }

            /*" -1399- MOVE 9999 TO V0PRPF-CODSIVPF V0PRPF-CODPRODU. */
            _.Move(9999, V0PRPF_CODSIVPF, V0PRPF_CODPRODU);

            /*" -1400- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1402- DISPLAY W-PROGRAMA-CHAMADOR '-R0050-INICIALIZA' '-VAI PROCESSAR R0170' */

                $"{W_PROGRAMA_CHAMADOR}-R0050-INICIALIZA-VAI PROCESSAR R0170"
                .Display();

                /*" -1404- END-IF */
            }


            /*" -1405- SET WS-SUBS TO WS-PRD */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRD;

            /*" -1408- PERFORM R0170-LIMPA-TABELA UNTIL WS-SUBS GREATER 100. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 100))
            {

                R0170_LIMPA_TABELA_SECTION();
            }

            /*" -1410- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -1411- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1413- DISPLAY W-PROGRAMA-CHAMADOR '-R0050-INICIALIZA' '-VAI PROCESSAR R0180' */

                $"{W_PROGRAMA_CHAMADOR}-R0050-INICIALIZA-VAI PROCESSAR R0180"
                .Display();

                /*" -1415- END-IF */
            }


            /*" -1422- PERFORM R0180-ZERA-CEDENTE 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R0180_ZERA_CEDENTE_SECTION();

            }

            /*" -1423- SET WS-CDT TO 1. */
            WS_CDT.Value = 1;

            /*" -1427- PERFORM R0215-MOVE-TAB-AVISOS 18 TIMES. */

            for (int i = 0; i < 18; i++)
            {

                R0215_MOVE_TAB_AVISOS_SECTION();

            }

            /*" -1427- PERFORM R0290-SELECT-MAX-TITULO. */

            R0290_SELECT_MAX_TITULO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_INICIALIZA_EXIT*/

        [StopWatch]
        /*" R0100-SELECT-V0SISTEMA-SECTION */
        private void R0100_SELECT_V0SISTEMA_SECTION()
        {
            /*" -1437- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1438- DISPLAY W-PROGRAMA-CHAMADOR '-R0100-SELECT-V0SISTEMA' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0100-SELECT-V0SISTEMA");

                /*" -1442- END-IF */
            }


            /*" -1444- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1450- PERFORM R0100_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -1453- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1454- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)");

                /*" -1456- MOVE 'R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)' TO W-MENSAGEM-ERRO */
                _.Move("R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)", W_MENSAGEM_ERRO);

                /*" -1457- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1459- END-IF. */
            }


            /*" -1459- DISPLAY 'DATA DO MOVIMENTO CB -> ' V0SIST-DTMOVABE. */
            _.Display($"DATA DO MOVIMENTO CB -> {V0SIST_DTMOVABE}");

        }

        [StopWatch]
        /*" R0100-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -1450- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SELECT_V0SISTEMA_EXIT*/

        [StopWatch]
        /*" R0105-SELECT-V0RELATORIOS-SECTION */
        private void R0105_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -1468- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1470- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R0105-SELECT-V0RELATORIOS' */

                $"{W_PROGRAMA_CHAMADOR}-R0105-SELECT-V0RELATORIOS"
                .Display();

                /*" -1474- END-IF */
            }


            /*" -1476- MOVE '0105' TO WNR-EXEC-SQL. */
            _.Move("0105", WABEND.WNR_EXEC_SQL);

            /*" -1483- PERFORM R0105_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0105_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -1486- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1487- DISPLAY 'R0105-00 - PROBLEMAS NO SELECT(RELATORIOS)' */
                _.Display($"R0105-00 - PROBLEMAS NO SELECT(RELATORIOS)");

                /*" -1489- MOVE 'R0105-00 - PROBLEMAS NO SELECT(RELATORIOS)' TO W-MENSAGEM-ERRO */
                _.Move("R0105-00 - PROBLEMAS NO SELECT(RELATORIOS)", W_MENSAGEM_ERRO);

                /*" -1490- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1490- END-IF. */
            }


        }

        [StopWatch]
        /*" R0105-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0105_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -1483- EXEC SQL SELECT DATA_REFERENCIA INTO :RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'CB' AND COD_RELATORIO = 'CB7300B1' WITH UR END-EXEC. */

            var r0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_SELECT_V0RELATORIOS_EXIT*/

        [StopWatch]
        /*" R0110-DECLARE-V0AGENCIAS-SECTION */
        private void R0110_DECLARE_V0AGENCIAS_SECTION()
        {
            /*" -1499- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1500- DISPLAY W-PROGRAMA-CHAMADOR '-R0110-DECLARE-V0AGENCIAS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0110-DECLARE-V0AGENCIAS");

                /*" -1504- END-IF */
            }


            /*" -1506- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", WABEND.WNR_EXEC_SQL);

            /*" -1516- PERFORM R0110_DECLARE_V0AGENCIAS_DB_DECLARE_1 */

            R0110_DECLARE_V0AGENCIAS_DB_DECLARE_1();

            /*" -1518- PERFORM R0110_DECLARE_V0AGENCIAS_DB_OPEN_1 */

            R0110_DECLARE_V0AGENCIAS_DB_OPEN_1();

            /*" -1521- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1522- DISPLAY 'R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)' */
                _.Display($"R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)");

                /*" -1524- MOVE 'R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)' TO W-MENSAGEM-ERRO */
                _.Move("R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)", W_MENSAGEM_ERRO);

                /*" -1525- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1525- END-IF. */
            }


        }

        [StopWatch]
        /*" R0110-DECLARE-V0AGENCIAS-DB-DECLARE-1 */
        public void R0110_DECLARE_V0AGENCIAS_DB_DECLARE_1()
        {
            /*" -1516- EXEC SQL DECLARE V0AGENCIAS CURSOR FOR SELECT A.COD_AGENCIA , A.COD_ESCNEG , B.COD_FONTE FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA > 0 AND A.COD_SUREG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            V0AGENCIAS = new PF2002B_V0AGENCIAS(false);
            string GetQuery_V0AGENCIAS()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							A.COD_ESCNEG
							, 
							B.COD_FONTE 
							FROM SEGUROS.V0AGENCIACEF A
							, 
							SEGUROS.V0MALHACEF B 
							WHERE A.COD_AGENCIA > 0 
							AND A.COD_SUREG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            V0AGENCIAS.GetQueryEvent += GetQuery_V0AGENCIAS;

        }

        [StopWatch]
        /*" R0110-DECLARE-V0AGENCIAS-DB-OPEN-1 */
        public void R0110_DECLARE_V0AGENCIAS_DB_OPEN_1()
        {
            /*" -1518- EXEC SQL OPEN V0AGENCIAS END-EXEC. */

            V0AGENCIAS.Open();

        }

        [StopWatch]
        /*" R0150-DECLARE-V0PRDSIVPF-DB-DECLARE-1 */
        public void R0150_DECLARE_V0PRDSIVPF_DB_DECLARE_1()
        {
            /*" -1611- EXEC SQL DECLARE V0PRDSIVPF CURSOR FOR SELECT COD_PRODUTO_SIVPF ,MAX(COD_PRODUTO) FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 GROUP BY COD_PRODUTO_SIVPF ORDER BY COD_PRODUTO_SIVPF WITH UR END-EXEC. */
            V0PRDSIVPF = new PF2002B_V0PRDSIVPF(false);
            string GetQuery_V0PRDSIVPF()
            {
                var query = @$"SELECT COD_PRODUTO_SIVPF 
							,MAX(COD_PRODUTO) 
							FROM SEGUROS.PRODUTOS_SIVPF 
							WHERE COD_EMPRESA_SIVPF = 1 
							GROUP BY COD_PRODUTO_SIVPF 
							ORDER BY COD_PRODUTO_SIVPF";

                return query;
            }
            V0PRDSIVPF.GetQueryEvent += GetQuery_V0PRDSIVPF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_DECLARE_V0AGENCIAS_EXIT*/

        [StopWatch]
        /*" R0120-FETCH-V0AGENCIAS-SECTION */
        private void R0120_FETCH_V0AGENCIAS_SECTION()
        {
            /*" -1535- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", WABEND.WNR_EXEC_SQL);

            /*" -1539- INITIALIZE V0ACEF-AGENCIA V0ACEF-ESCNEG V0ACEF-FONTE */
            _.Initialize(
                V0ACEF_AGENCIA
                , V0ACEF_ESCNEG
                , V0ACEF_FONTE
            );

            /*" -1543- PERFORM R0120_FETCH_V0AGENCIAS_DB_FETCH_1 */

            R0120_FETCH_V0AGENCIAS_DB_FETCH_1();

            /*" -1546- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -1546- PERFORM R0120_FETCH_V0AGENCIAS_DB_CLOSE_1 */

                R0120_FETCH_V0AGENCIAS_DB_CLOSE_1();

                /*" -1548- MOVE 'S' TO WFIM-AGENCIAS */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_AGENCIAS);

                /*" -1549- GO TO R0120-FETCH-V0AGENCIAS-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_FETCH_V0AGENCIAS_EXIT*/ //GOTO
                return;

                /*" -1551- END-IF. */
            }


            /*" -1552- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1553- DISPLAY 'R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ' */
                _.Display($"R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ");

                /*" -1555- MOVE 'R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ' TO W-MENSAGEM-ERRO */
                _.Move("R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ", W_MENSAGEM_ERRO);

                /*" -1556- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1558- END-IF. */
            }


            /*" -1559- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1560- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1562- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1564- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

            /*" -1565- IF (WS-AGE > 6000) */

            if ((WS_AGE > 6000))
            {

                /*" -1566- DISPLAY 'R0120-00 - ESTOUROU TABELA WACEF-AGENCIAS' */
                _.Display($"R0120-00 - ESTOUROU TABELA WACEF-AGENCIAS");

                /*" -1568- MOVE 'R0120-00 - ESTOUROU TABELA WACEF-AGENCIAS' TO W-MENSAGEM-ERRO */
                _.Move("R0120-00 - ESTOUROU TABELA WACEF-AGENCIAS", W_MENSAGEM_ERRO);

                /*" -1569- GO TO R9900-ENCERRA-COM-ERRO */

                R9900_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;

                /*" -1569- END-IF. */
            }


        }

        [StopWatch]
        /*" R0120-FETCH-V0AGENCIAS-DB-FETCH-1 */
        public void R0120_FETCH_V0AGENCIAS_DB_FETCH_1()
        {
            /*" -1543- EXEC SQL FETCH V0AGENCIAS INTO :V0ACEF-AGENCIA , :V0ACEF-ESCNEG , :V0ACEF-FONTE END-EXEC. */

            if (V0AGENCIAS.Fetch())
            {
                _.Move(V0AGENCIAS.V0ACEF_AGENCIA, V0ACEF_AGENCIA);
                _.Move(V0AGENCIAS.V0ACEF_ESCNEG, V0ACEF_ESCNEG);
                _.Move(V0AGENCIAS.V0ACEF_FONTE, V0ACEF_FONTE);
            }

        }

        [StopWatch]
        /*" R0120-FETCH-V0AGENCIAS-DB-CLOSE-1 */
        public void R0120_FETCH_V0AGENCIAS_DB_CLOSE_1()
        {
            /*" -1546- EXEC SQL CLOSE V0AGENCIAS END-EXEC */

            V0AGENCIAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_FETCH_V0AGENCIAS_EXIT*/

        [StopWatch]
        /*" R0130-LIMPA-TABELA-SECTION */
        private void R0130_LIMPA_TABELA_SECTION()
        {
            /*" -1581- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", WABEND.WNR_EXEC_SQL);

            /*" -1582- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1583- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1585- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1586- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

            /*" -1586- SET WS-SUBS TO WS-AGE. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_AGE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_LIMPA_TABELA_EXIT*/

        [StopWatch]
        /*" R0150-DECLARE-V0PRDSIVPF-SECTION */
        private void R0150_DECLARE_V0PRDSIVPF_SECTION()
        {
            /*" -1596- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1597- DISPLAY W-PROGRAMA-CHAMADOR '-R0150-DECLARE-V0PRDSIVPF' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0150-DECLARE-V0PRDSIVPF");

                /*" -1601- END-IF */
            }


            /*" -1603- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -1611- PERFORM R0150_DECLARE_V0PRDSIVPF_DB_DECLARE_1 */

            R0150_DECLARE_V0PRDSIVPF_DB_DECLARE_1();

            /*" -1613- PERFORM R0150_DECLARE_V0PRDSIVPF_DB_OPEN_1 */

            R0150_DECLARE_V0PRDSIVPF_DB_OPEN_1();

            /*" -1616- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1617- DISPLAY 'R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)' */
                _.Display($"R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)");

                /*" -1619- MOVE 'R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)' TO W-MENSAGEM-ERRO */
                _.Move("R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)", W_MENSAGEM_ERRO);

                /*" -1620- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1620- END-IF. */
            }


        }

        [StopWatch]
        /*" R0150-DECLARE-V0PRDSIVPF-DB-OPEN-1 */
        public void R0150_DECLARE_V0PRDSIVPF_DB_OPEN_1()
        {
            /*" -1613- EXEC SQL OPEN V0PRDSIVPF END-EXEC. */

            V0PRDSIVPF.Open();

        }

        [StopWatch]
        /*" R0200-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -1708- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN (0, 10, 11) ORDER BY CODPRODU WITH UR END-EXEC. */
            V0PRODUTO = new PF2002B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA IN (0
							, 10
							, 11) 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_DECLARE_V0PRDSIVPF_EXIT*/

        [StopWatch]
        /*" R0160-FETCH-V0PRDSIVPF-SECTION */
        private void R0160_FETCH_V0PRDSIVPF_SECTION()
        {
            /*" -1629- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1630- DISPLAY W-PROGRAMA-CHAMADOR '-R0160-FETCH-V0PRDSIVPF' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0160-FETCH-V0PRDSIVPF");

                /*" -1633- END-IF */
            }


            /*" -1636- INITIALIZE V0PRPF-CODSIVPF V0PRPF-CODPRODU */
            _.Initialize(
                V0PRPF_CODSIVPF
                , V0PRPF_CODPRODU
            );

            /*" -1638- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WABEND.WNR_EXEC_SQL);

            /*" -1641- PERFORM R0160_FETCH_V0PRDSIVPF_DB_FETCH_1 */

            R0160_FETCH_V0PRDSIVPF_DB_FETCH_1();

            /*" -1644- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -1644- PERFORM R0160_FETCH_V0PRDSIVPF_DB_CLOSE_1 */

                R0160_FETCH_V0PRDSIVPF_DB_CLOSE_1();

                /*" -1646- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_PRODUTO);

                /*" -1647- GO TO R0160-FETCH-V0PRDSIVPF-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_FETCH_V0PRDSIVPF_EXIT*/ //GOTO
                return;

                /*" -1649- END-IF. */
            }


            /*" -1650- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1651- DISPLAY 'R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ' */
                _.Display($"R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ");

                /*" -1653- MOVE 'R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ' TO W-MENSAGEM-ERRO */
                _.Move("R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ", W_MENSAGEM_ERRO);

                /*" -1654- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1656- END-IF. */
            }


            /*" -1657- MOVE V0PRPF-CODSIVPF TO WPROD-PRDSIVPF(WS-PRD). */
            _.Move(V0PRPF_CODSIVPF, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF);

            /*" -1659- MOVE V0PRPF-CODPRODU TO WPROD-CODPRODU(WS-PRD). */
            _.Move(V0PRPF_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU);

            /*" -1659- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }

        [StopWatch]
        /*" R0160-FETCH-V0PRDSIVPF-DB-FETCH-1 */
        public void R0160_FETCH_V0PRDSIVPF_DB_FETCH_1()
        {
            /*" -1641- EXEC SQL FETCH V0PRDSIVPF INTO :V0PRPF-CODSIVPF ,:V0PRPF-CODPRODU END-EXEC. */

            if (V0PRDSIVPF.Fetch())
            {
                _.Move(V0PRDSIVPF.V0PRPF_CODSIVPF, V0PRPF_CODSIVPF);
                _.Move(V0PRDSIVPF.V0PRPF_CODPRODU, V0PRPF_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0160-FETCH-V0PRDSIVPF-DB-CLOSE-1 */
        public void R0160_FETCH_V0PRDSIVPF_DB_CLOSE_1()
        {
            /*" -1644- EXEC SQL CLOSE V0PRDSIVPF END-EXEC */

            V0PRDSIVPF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_FETCH_V0PRDSIVPF_EXIT*/

        [StopWatch]
        /*" R0170-LIMPA-TABELA-SECTION */
        private void R0170_LIMPA_TABELA_SECTION()
        {
            /*" -1669- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", WABEND.WNR_EXEC_SQL);

            /*" -1670- MOVE V0PRPF-CODSIVPF TO WPROD-PRDSIVPF(WS-PRD). */
            _.Move(V0PRPF_CODSIVPF, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF);

            /*" -1672- MOVE V0PRPF-CODPRODU TO WPROD-CODPRODU(WS-PRD). */
            _.Move(V0PRPF_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU);

            /*" -1673- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -1673- SET WS-SUBS TO WS-PRD. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_LIMPA_TABELA_EXIT*/

        [StopWatch]
        /*" R0180-ZERA-CEDENTE-SECTION */
        private void R0180_ZERA_CEDENTE_SECTION()
        {
            /*" -1683- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", WABEND.WNR_EXEC_SQL);

            /*" -1685- MOVE ZEROS TO WCEDE-CODEMPRESA(WS-CED). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA);

            /*" -1685- SET WS-CED UP BY 1. */
            WS_CED.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_ZERA_CEDENTE_EXIT*/

        [StopWatch]
        /*" R0200-DECLARE-V0PRODUTO-SECTION */
        private void R0200_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -1695- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1696- DISPLAY W-PROGRAMA-CHAMADOR '-R0200-DECLARE-V0PRODUTO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0200-DECLARE-V0PRODUTO");

                /*" -1700- END-IF */
            }


            /*" -1702- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1708- PERFORM R0200_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -1710- PERFORM R0200_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -1713- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1714- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -1716- MOVE 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' TO W-MENSAGEM-ERRO */
                _.Move("R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ", W_MENSAGEM_ERRO);

                /*" -1717- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1717- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -1710- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_DECLARE_V0PRODUTO_EXIT*/

        [StopWatch]
        /*" R0210-FETCH-V0PRODUTO-SECTION */
        private void R0210_FETCH_V0PRODUTO_SECTION()
        {
            /*" -1727- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1728- DISPLAY W-PROGRAMA-CHAMADOR '-R0210-FETCH-V0PRODUTO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0210-FETCH-V0PRODUTO");

                /*" -1732- END-IF */
            }


            /*" -1734- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -1736- INITIALIZE V0PROD-CODPRODU */
            _.Initialize(
                V0PROD_CODPRODU
            );

            /*" -1739- PERFORM R0210_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -1742- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -1742- PERFORM R0210_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -1744- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_PRODUTO);

                /*" -1745- GO TO R0210-FETCH-V0PRODUTO-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_FETCH_V0PRODUTO_EXIT*/ //GOTO
                return;

                /*" -1747- END-IF. */
            }


            /*" -1748- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1749- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -1751- MOVE 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' TO W-MENSAGEM-ERRO */
                _.Move("R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ", W_MENSAGEM_ERRO);

                /*" -1752- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1754- END-IF. */
            }


            /*" -1756- ADD 1 TO LD-PRODUTO. */
            WS_AUX_ARQUIVO.LD_PRODUTO.Value = WS_AUX_ARQUIVO.LD_PRODUTO + 1;

            /*" -1757- IF (LD-PRODUTO > 2000) */

            if ((WS_AUX_ARQUIVO.LD_PRODUTO > 2000))
            {

                /*" -1757- PERFORM R0210_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -1759- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -1761- MOVE 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' TO W-MENSAGEM-ERRO */
                _.Move("R0210-00 - ESTOURO TABELA INTERNA PRODUTO", W_MENSAGEM_ERRO);

                /*" -1762- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1765- END-IF. */
            }


            /*" -1766- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1768- DISPLAY W-PROGRAMA-CHAMADOR '-R0210-FETCH-V0PRODUTO' '-VAI PROCESSAR R0220' */

                $"{W_PROGRAMA_CHAMADOR}-R0210-FETCH-V0PRODUTO-VAI PROCESSAR R0220"
                .Display();

                /*" -1770- END-IF */
            }


            /*" -1770- PERFORM R0220-MOVE-TAB-PRODUTO. */

            R0220_MOVE_TAB_PRODUTO_SECTION();

        }

        [StopWatch]
        /*" R0210-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -1739- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -1742- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_FETCH_V0PRODUTO_EXIT*/

        [StopWatch]
        /*" R0210-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -1757- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0215-MOVE-TAB-AVISOS-SECTION */
        private void R0215_MOVE_TAB_AVISOS_SECTION()
        {
            /*" -1780- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1781- DISPLAY W-PROGRAMA-CHAMADOR '-R0215-MOVE-TAB-AVISOS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0215-MOVE-TAB-AVISOS");

                /*" -1784- END-IF */
            }


            /*" -1786- MOVE '0215' TO WNR-EXEC-SQL. */
            _.Move("0215", WABEND.WNR_EXEC_SQL);

            /*" -1824- SET WS-SUBS3 TO WS-CDT. */
            WS_AUX_ARQUIVO.WS_SUBS3.Value = WS_CDT;

            /*" -1827- EVALUATE WS-SUBS3 */
            switch (WS_AUX_ARQUIVO.WS_SUBS3.Value)
            {

                /*" -1828- WHEN 1 */
                case 1:

                    /*" -1829- MOVE '8996' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("8996", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1832- MOVE 0008 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0008, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1833- WHEN 2 */
                    break;
                case 2:

                    /*" -1834- COMPUTE WS-AGE-AVISO = 8000 + CVPAG-996 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 8000 + JVBKINCL.JV_AGE_AVISO.CVPAG_996;

                    /*" -1835- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1838- MOVE 0008 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0008, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1839- WHEN 3 */
                    break;
                case 3:

                    /*" -1840- COMPUTE WS-AGE-AVISO = 8000 + JVPAG-996 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 8000 + JVBKINCL.JV_AGE_AVISO.JVPAG_996;

                    /*" -1841- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1844- MOVE 0008 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0008, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1845- WHEN 4 */
                    break;
                case 4:

                    /*" -1846- MOVE '8001' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("8001", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1849- MOVE 0001 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0001, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1850- WHEN 5 */
                    break;
                case 5:

                    /*" -1851- MOVE '8003' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("8003", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1854- MOVE 0001 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0001, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1855- WHEN 6 */
                    break;
                case 6:

                    /*" -1856- MOVE '8005' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("8005", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1859- MOVE 0018 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0018, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1860- WHEN 7 */
                    break;
                case 7:

                    /*" -1861- COMPUTE WS-AGE-AVISO = 8000 + CVPAG-005 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 8000 + JVBKINCL.JV_AGE_AVISO.CVPAG_005;

                    /*" -1862- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1865- MOVE 0018 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0018, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1866- WHEN 8 */
                    break;
                case 8:

                    /*" -1867- COMPUTE WS-AGE-AVISO = 8000 + JVPAG-005 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 8000 + JVBKINCL.JV_AGE_AVISO.JVPAG_005;

                    /*" -1868- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1871- MOVE 0018 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0018, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1872- WHEN 9 */
                    break;
                case 9:

                    /*" -1873- MOVE '8999' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("8999", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1876- MOVE 0001 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0001, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1877- WHEN 10 */
                    break;
                case 10:

                    /*" -1878- MOVE '9996' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("9996", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1881- MOVE 0008 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0008, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1882- WHEN 11 */
                    break;
                case 11:

                    /*" -1883- COMPUTE WS-AGE-AVISO = 9000 + CVPAG-996 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 9000 + JVBKINCL.JV_AGE_AVISO.CVPAG_996;

                    /*" -1884- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1887- MOVE 0008 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0008, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1888- WHEN 12 */
                    break;
                case 12:

                    /*" -1889- COMPUTE WS-AGE-AVISO = 9000 + JVPAG-996 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 9000 + JVBKINCL.JV_AGE_AVISO.JVPAG_996;

                    /*" -1890- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1893- MOVE 0008 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0008, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1894- WHEN 13 */
                    break;
                case 13:

                    /*" -1895- MOVE '9001' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("9001", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1898- MOVE 0014 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0014, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1899- WHEN 14 */
                    break;
                case 14:

                    /*" -1900- MOVE '9003' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("9003", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1903- MOVE 0014 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0014, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1904- WHEN 15 */
                    break;
                case 15:

                    /*" -1905- MOVE '9005' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("9005", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1908- MOVE 0018 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0018, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1909- WHEN 16 */
                    break;
                case 16:

                    /*" -1910- COMPUTE WS-AGE-AVISO = 9000 + CVPAG-005 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 9000 + JVBKINCL.JV_AGE_AVISO.CVPAG_005;

                    /*" -1911- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1914- MOVE 0018 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0018, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1915- WHEN 17 */
                    break;
                case 17:

                    /*" -1916- COMPUTE WS-AGE-AVISO = 9000 + JVPAG-005 */
                    WS_AUX_AVISO.WS_AGE_AVISO.Value = 9000 + JVBKINCL.JV_AGE_AVISO.JVPAG_005;

                    /*" -1917- MOVE WS-AGE-AVISO TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move(WS_AUX_AVISO.WS_AGE_AVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1920- MOVE 0018 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0018, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1921- WHEN 18 */
                    break;
                case 18:

                    /*" -1922- MOVE '9999' TO WTABG-CODAGEAVISO(WS-CDT) */
                    _.Move("9999", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO);

                    /*" -1923- MOVE 0001 TO WTABG-ORIGAVISO(WS-CDT) */
                    _.Move(0001, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO);

                    /*" -1925- END-EVALUATE */
                    break;
            }


            /*" -1926- SET WS-PRO TO 1. */
            WS_PRO.Value = 1;

            /*" -1929- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -1930- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1932- DISPLAY W-PROGRAMA-CHAMADOR '-R0215-MOVE-TAB-AVISOS' '-VAI PROCESSAR R0220' */

                $"{W_PROGRAMA_CHAMADOR}-R0215-MOVE-TAB-AVISOS-VAI PROCESSAR R0220"
                .Display();

                /*" -1934- END-IF */
            }


            /*" -1936- PERFORM R0220-MOVE-TAB-PRODUTO. */

            R0220_MOVE_TAB_PRODUTO_SECTION();

            /*" -1937- MOVE 1 TO LD-PRODUTO */
            _.Move(1, WS_AUX_ARQUIVO.LD_PRODUTO);

            /*" -1938- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WS_AUX_ARQUIVO.WFIM_PRODUTO);

            /*" -1940- PERFORM R0200-DECLARE-V0PRODUTO. */

            R0200_DECLARE_V0PRODUTO_SECTION();

            /*" -1943- PERFORM R0210-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_FETCH_V0PRODUTO_SECTION();
            }

            /*" -1946- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -1947- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -1949- DISPLAY W-PROGRAMA-CHAMADOR '-R0215-MOVE-TAB-AVISOS' '-VAI PROCESSAR R0220 B' */

                $"{W_PROGRAMA_CHAMADOR}-R0215-MOVE-TAB-AVISOS-VAI PROCESSAR R0220 B"
                .Display();

                /*" -1951- END-IF */
            }


            /*" -1954- PERFORM R0220-MOVE-TAB-PRODUTO UNTIL WS-SUBS GREATER 2000. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 2000))
            {

                R0220_MOVE_TAB_PRODUTO_SECTION();
            }

            /*" -1954- SET WS-CDT UP BY 1. */
            WS_CDT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_MOVE_TAB_AVISOS_EXIT*/

        [StopWatch]
        /*" R0220-MOVE-TAB-PRODUTO-SECTION */
        private void R0220_MOVE_TAB_PRODUTO_SECTION()
        {
            /*" -1965- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WABEND.WNR_EXEC_SQL);

            /*" -1968- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-CDT WS-PRO) */
            _.Move(V0PROD_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU);

            /*" -1969- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -1971- PERFORM R0250-MOVE-TAB-TIPO 05 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R0250_MOVE_TAB_TIPO_SECTION();

            }

            /*" -1972- SET WS-PRO UP BY 1. */
            WS_PRO.Value += 1;

            /*" -1972- SET WS-SUBS TO WS-PRO. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_MOVE_TAB_PRODUTO_EXIT*/

        [StopWatch]
        /*" R0250-MOVE-TAB-TIPO-SECTION */
        private void R0250_MOVE_TAB_TIPO_SECTION()
        {
            /*" -1983- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -1993- SET WS-SUBS1 TO WS-TIP. */
            WS_AUX_ARQUIVO.WS_SUBS1.Value = WS_TIP;

            /*" -1994- EVALUATE WS-SUBS1 */
            switch (WS_AUX_ARQUIVO.WS_SUBS1.Value)
            {

                /*" -1995- WHEN 1 */
                case 1:

                    /*" -1997- MOVE 'A' TO WTABG-TIPO(WS-CDT WS-PRO WS-TIP) */
                    _.Move("A", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -1998- WHEN 2 */
                    break;
                case 2:

                    /*" -2000- MOVE 'G' TO WTABG-TIPO(WS-CDT WS-PRO WS-TIP) */
                    _.Move("G", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -2001- WHEN 3 */
                    break;
                case 3:

                    /*" -2003- MOVE '2' TO WTABG-TIPO(WS-CDT WS-PRO WS-TIP) */
                    _.Move("2", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -2004- WHEN 4 */
                    break;
                case 4:

                    /*" -2006- MOVE 'D' TO WTABG-TIPO(WS-CDT WS-PRO WS-TIP) */
                    _.Move("D", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -2007- WHEN OTHER */
                    break;
                default:

                    /*" -2009- MOVE 'M' TO WTABG-TIPO(WS-CDT WS-PRO WS-TIP) */
                    _.Move("M", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -2011- END-EVALUATE */
                    break;
            }


            /*" -2013- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -2015- PERFORM R0260-MOVE-TAB-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_MOVE_TAB_SITUACAO_SECTION();

            }

            /*" -2015- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_MOVE_TAB_TIPO_EXIT*/

        [StopWatch]
        /*" R0260-MOVE-TAB-SITUACAO-SECTION */
        private void R0260_MOVE_TAB_SITUACAO_SECTION()
        {
            /*" -2026- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WABEND.WNR_EXEC_SQL);

            /*" -2028- SET WS-SUBS2 TO WS-SIT. */
            WS_AUX_ARQUIVO.WS_SUBS2.Value = WS_SIT;

            /*" -2041- MOVE ZEROS TO WTABG-QTDE (WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLTARIFA(WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLBALCAO(WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLIOCC (WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLDESCON(WS-CDT WS-PRO WS-TIP WS-SIT) */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -2042- IF (WS-SUBS2 EQUAL 1) */

            if ((WS_AUX_ARQUIVO.WS_SUBS2 == 1))
            {

                /*" -2044- MOVE '0' TO WTABG-SITUACAO(WS-CDT WS-PRO WS-TIP WS-SIT) */
                _.Move("0", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -2045- ELSE */
            }
            else
            {


                /*" -2047- MOVE '2' TO WTABG-SITUACAO(WS-CDT WS-PRO WS-TIP WS-SIT) */
                _.Move("2", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -2049- END-IF. */
            }


            /*" -2049- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_MOVE_TAB_SITUACAO_EXIT*/

        [StopWatch]
        /*" R0290-SELECT-MAX-TITULO-SECTION */
        private void R0290_SELECT_MAX_TITULO_SECTION()
        {
            /*" -2059- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2060- DISPLAY W-PROGRAMA-CHAMADOR '-R0290-SELECT-MAX-TITULO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0290-SELECT-MAX-TITULO");

                /*" -2064- END-IF */
            }


            /*" -2066- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", WABEND.WNR_EXEC_SQL);

            /*" -2074- PERFORM R0290_SELECT_MAX_TITULO_DB_SELECT_1 */

            R0290_SELECT_MAX_TITULO_DB_SELECT_1();

            /*" -2077- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2078- DISPLAY 'R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($"R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -2080- MOVE 'R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)' TO W-MENSAGEM-ERRO */
                _.Move("R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)", W_MENSAGEM_ERRO);

                /*" -2081- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2083- END-IF. */
            }


            /*" -2084- MOVE V0CEDE-NUMTIT TO WWORK-MIN-NRTIT */
            _.Move(V0CEDE_NUMTIT, WS_AUX_ARQUIVO.WWORK_MIN_NRTIT);

            /*" -2090- MOVE V0CEDE-NUMTITMAX TO WWORK-MAX-NRTIT. */
            _.Move(V0CEDE_NUMTITMAX, WS_AUX_ARQUIVO.WWORK_MAX_NRTIT);

            /*" -2091- IF (V0CEDE-NUMTIT < 95322401400) */

            if ((V0CEDE_NUMTIT < 95322401400))
            {

                /*" -2092- DISPLAY 'R0290-00 - PROBLEMAS NO SELECT (V0CEDENTE)' */
                _.Display($"R0290-00 - PROBLEMAS NO SELECT (V0CEDENTE)");

                /*" -2093- DISPLAY '*- PF2002B - ABEND CONTROLADO -----------*' */
                _.Display($"*- PF2002B - ABEND CONTROLADO -----------*");

                /*" -2094- DISPLAY '*  FAIXA NUMERACAO INVALIDA CEDENTE = 26 *' */
                _.Display($"*  FAIXA NUMERACAO INVALIDA CEDENTE = 26 *");

                /*" -2095- DISPLAY ' TITULO ' V0CEDE-NUMTIT */
                _.Display($" TITULO {V0CEDE_NUMTIT}");

                /*" -2097- MOVE 'R0290-00 - PROBLEMAS NO SELECT (V0CEDENTE)' TO W-MENSAGEM-ERRO */
                _.Move("R0290-00 - PROBLEMAS NO SELECT (V0CEDENTE)", W_MENSAGEM_ERRO);

                /*" -2098- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2098- END-IF. */
            }


        }

        [StopWatch]
        /*" R0290-SELECT-MAX-TITULO-DB-SELECT-1 */
        public void R0290_SELECT_MAX_TITULO_DB_SELECT_1()
        {
            /*" -2074- EXEC SQL SELECT NUMTIT , NUMTITMAX INTO :V0CEDE-NUMTIT , :V0CEDE-NUMTITMAX FROM SEGUROS.V0CEDENTE WHERE CODCDT = 26 WITH UR END-EXEC. */

            var r0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1 = new R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1.Execute(r0290_SELECT_MAX_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CEDE_NUMTIT, V0CEDE_NUMTIT);
                _.Move(executed_1.V0CEDE_NUMTITMAX, V0CEDE_NUMTITMAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_SELECT_MAX_TITULO_EXIT*/

        [StopWatch]
        /*" R0300-INPUT-SORT-SECTION */
        private void R0300_INPUT_SORT_SECTION()
        {
            /*" -2108- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2109- DISPLAY W-PROGRAMA-CHAMADOR '-R0300-INPUT-SORT' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0300-INPUT-SORT");

                /*" -2113- END-IF */
            }


            /*" -2116- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -2117- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -2118- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA);

            /*" -2119- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT1);

            /*" -2120- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);

            /*" -2121- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT2);

            /*" -2122- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

            /*" -2125- DISPLAY 'R0300-INPUT-SORT  ' WTIME-DAYR. */
            _.Display($"R0300-INPUT-SORT  {WS_AUX_DATAS.FILLER_37.WTIME_DAYR}");

            /*" -2127- MOVE SPACES TO WFIM-COBRANCA. */
            _.Move("", WS_AUX_ARQUIVO.WFIM_COBRANCA);

            /*" -2129- PERFORM R0310-LE-COBRANCA. */

            R0310_LE_COBRANCA_SECTION();

            /*" -2130- IF (WFIM-COBRANCA NOT EQUAL SPACES) */

            if ((!WS_AUX_ARQUIVO.WFIM_COBRANCA.IsEmpty()))
            {

                /*" -2131- DISPLAY '****** ARQUIVO BOLETO REGISTRADO VAZIO ******' */
                _.Display($"****** ARQUIVO BOLETO REGISTRADO VAZIO ******");

                /*" -2132- PERFORM R9800-ENCERRA-SEM-MOVTO */

                R9800_ENCERRA_SEM_MOVTO_SECTION();

                /*" -2133- GO TO R9000-FINALIZA */

                R9000_FINALIZA_SECTION(); //GOTO
                return;

                /*" -2135- END-IF. */
            }


            /*" -2139- PERFORM R0350-GRAVA-SORT UNTIL WFIM-COBRANCA NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_COBRANCA.IsEmpty()))
            {

                R0350_GRAVA_SORT_SECTION();
            }

            /*" -2140- DISPLAY 'LIDOS ARQUIVO ............... ' LD-COBRANCA */
            _.Display($"LIDOS ARQUIVO ............... {WS_AUX_ARQUIVO.LD_COBRANCA}");

            /*" -2141- DISPLAY 'GRAVADOS SORT ............... ' W-SORT-TOT-GRAV */
            _.Display($"GRAVADOS SORT ............... {WS_AUX_ARQUIVO.W_SORT_TOT_GRAV}");

            /*" -2141- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_INPUT_SORT_EXIT*/

        [StopWatch]
        /*" R0310-LE-COBRANCA-SECTION */
        private void R0310_LE_COBRANCA_SECTION()
        {
            /*" -2151- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2152- DISPLAY W-PROGRAMA-CHAMADOR '-R0310-LE-COBRANCA' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0310-LE-COBRANCA");

                /*" -2155- END-IF */
            }


            /*" -2157- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -2158- READ MOVIMENTO-COBRANCA AT END */
            try
            {
                MOVIMENTO_COBRANCA.Read(() =>
                {

                    /*" -2160- MOVE 'S' TO WFIM-COBRANCA */
                    _.Move("S", WS_AUX_ARQUIVO.WFIM_COBRANCA);

                    /*" -2161- NOT AT END */
                }, () =>
                {

                    /*" -2162- MOVE REG-COBRANCA TO REG-SIGC13 */
                    _.Move(MOVIMENTO_COBRANCA?.Value, REG_SIGC13);

                    /*" -2163- ADD 1 TO LD-COBRANCA */
                    WS_AUX_ARQUIVO.LD_COBRANCA.Value = WS_AUX_ARQUIVO.LD_COBRANCA + 1;

                    /*" -2164- END-READ */
                });

                _.Move(MOVIMENTO_COBRANCA.Value, REG_COBRANCA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2164- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_LE_COBRANCA_EXIT*/

        [StopWatch]
        /*" R0350-GRAVA-SORT-SECTION */
        private void R0350_GRAVA_SORT_SECTION()
        {
            /*" -2173- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2174- DISPLAY W-PROGRAMA-CHAMADOR '-R0350-GRAVA-SORT' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R0350-GRAVA-SORT");

                /*" -2178- END-IF */
            }


            /*" -2180- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", WABEND.WNR_EXEC_SQL);

            /*" -2182- ADD 1 TO DE-COBRANCA. */
            WS_AUX_ARQUIVO.DE_COBRANCA.Value = WS_AUX_ARQUIVO.DE_COBRANCA + 1;

            /*" -2183- IF (DE-COBRANCA EQUAL 1) */

            if ((WS_AUX_ARQUIVO.DE_COBRANCA == 1))
            {

                /*" -2184- PERFORM R8455-SELECT-MAX-AVISO */

                R8455_SELECT_MAX_AVISO_SECTION();

                /*" -2186- END-IF */
            }


            /*" -2187- MOVE V0MCOB-NUMFITA TO SIGC13-NSAC */
            _.Move(V0MCOB_NUMFITA, REG_SIGC13.SIGC13_DETALHE.SIGC13_NSAC);

            /*" -2189- MOVE SIGC13-DETALHE TO SOR-DETALHE */
            _.Move(REG_SIGC13.SIGC13_DETALHE, REG_ARQSORT.SOR_DETALHE);

            /*" -2191- MOVE SIGC13-NUM-PROPOSTA TO AUX-NRO-SIVPF */
            _.Move(REG_SIGC13.SIGC13_DETALHE.SIGC13_NUM_PROPOSTA, WS_AUX_ARQUIVO.AUX_NRO_SIVPF);

            /*" -2192- MOVE AUX-CANAL TO SOR-CANAL-VENDA */
            _.Move(WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL, REG_ARQSORT.SOR_CANAL_VENDA);

            /*" -2193- MOVE AUX-PRDSIVPF TO SOR-PROD-SIVPF */
            _.Move(WS_AUX_ARQUIVO.FILLER_21.AUX_PRDSIVPF, REG_ARQSORT.SOR_PROD_SIVPF);

            /*" -2194- MOVE SIGC13-NN-REGISTRADO TO WS-NN-REG. */
            _.Move(REG_SIGC13.SIGC13_DETALHE.SIGC13_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -2222- MOVE SIGC13-COD-CEDENTE TO WS-AGE-CEDENTE */
            _.Move(REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE, WS_AGE_CEDENTE);

            /*" -2223-  EVALUATE SIGC13-COD-CEDENTE  */

            /*" -2224-  WHEN 695996  */

            /*" -2224- IF   SIGC13-COD-CEDENTE EQUALS  695996 */

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == 695996)
            {

                /*" -2225- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2226- MOVE '3' TO SOR-TIPO-MOVIMENTO */
                _.Move("3", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2227- ADD 1 TO LD-CED-DIRVI */
                WS_AUX_ARQUIVO.LD_CED_DIRVI.Value = WS_AUX_ARQUIVO.LD_CED_DIRVI + 1;

                /*" -2228-  WHEN CVPCV-695996  */

                /*" -2228- ELSE IF   SIGC13-COD-CEDENTE EQUALS  CVPCV-695996 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == JVBKINCL.JV_CONVENIOS.CVPCV_695996)
            {

                /*" -2229- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2230- MOVE '3' TO SOR-TIPO-MOVIMENTO */
                _.Move("3", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2231- ADD 1 TO LD-CED-DIRVI */
                WS_AUX_ARQUIVO.LD_CED_DIRVI.Value = WS_AUX_ARQUIVO.LD_CED_DIRVI + 1;

                /*" -2232-  WHEN JV1CV-695996  */

                /*" -2232- ELSE IF   SIGC13-COD-CEDENTE EQUALS  JV1CV-695996 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == JVBKINCL.JV_CONVENIOS.JV1CV_695996)
            {

                /*" -2233- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2234- MOVE '3' TO SOR-TIPO-MOVIMENTO */
                _.Move("3", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2235- ADD 1 TO LD-CED-DIRVI */
                WS_AUX_ARQUIVO.LD_CED_DIRVI.Value = WS_AUX_ARQUIVO.LD_CED_DIRVI + 1;

                /*" -2236-  WHEN 696001  */

                /*" -2236- ELSE IF   SIGC13-COD-CEDENTE EQUALS  696001 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == 696001)
            {

                /*" -2237- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2238- MOVE '1' TO SOR-TIPO-MOVIMENTO */
                _.Move("1", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2239- ADD 1 TO LD-CED-DIRID */
                WS_AUX_ARQUIVO.LD_CED_DIRID.Value = WS_AUX_ARQUIVO.LD_CED_DIRID + 1;

                /*" -2240- MOVE SIGC13-IDLG TO WS-COD-IDLG */
                _.Move(REG_SIGC13.SIGC13_DETALHE.SIGC13_IDLG, WS_AUX_AVISO.WS_COD_IDLG);

                /*" -2241- MOVE SIGC13-COD-PRODUTO TO WS-PRODUTO */
                _.Move(REG_SIGC13.SIGC13_DETALHE.SIGC13_COD_PRODUTO, WS_AUX_ARQUIVO.WS_PRODUTO);

                /*" -2242-  WHEN 696003  */

                /*" -2242- ELSE IF   SIGC13-COD-CEDENTE EQUALS  696003 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == 696003)
            {

                /*" -2243- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2244- MOVE '1' TO SOR-TIPO-MOVIMENTO */
                _.Move("1", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2245- ADD 1 TO LD-CED-DISEF */
                WS_AUX_ARQUIVO.LD_CED_DISEF.Value = WS_AUX_ARQUIVO.LD_CED_DISEF + 1;

                /*" -2246-  WHEN 696005  */

                /*" -2246- ELSE IF   SIGC13-COD-CEDENTE EQUALS  696005 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == 696005)
            {

                /*" -2247- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2248- MOVE '7' TO SOR-TIPO-MOVIMENTO */
                _.Move("7", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2249- ADD 1 TO LD-CED-RESSARC */
                WS_AUX_ARQUIVO.LD_CED_RESSARC.Value = WS_AUX_ARQUIVO.LD_CED_RESSARC + 1;

                /*" -2250-  WHEN CVPCV-696005  */

                /*" -2250- ELSE IF   SIGC13-COD-CEDENTE EQUALS  CVPCV-696005 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == JVBKINCL.JV_CONVENIOS.CVPCV_696005)
            {

                /*" -2251- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2252- MOVE '7' TO SOR-TIPO-MOVIMENTO */
                _.Move("7", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2253- ADD 1 TO LD-CED-RESSARC */
                WS_AUX_ARQUIVO.LD_CED_RESSARC.Value = WS_AUX_ARQUIVO.LD_CED_RESSARC + 1;

                /*" -2254-  WHEN JV1CV-696005  */

                /*" -2254- ELSE IF   SIGC13-COD-CEDENTE EQUALS  JV1CV-696005 */
            }
            else

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == JVBKINCL.JV_CONVENIOS.JV1CV_696005)
            {

                /*" -2255- MOVE WS-CEDENTE TO SOR-AGE-AVISO */
                _.Move(FILLER_59.WS_CEDENTE, REG_ARQSORT.SOR_AGE_AVISO);

                /*" -2256- MOVE '7' TO SOR-TIPO-MOVIMENTO */
                _.Move("7", REG_ARQSORT.SOR_TIPO_MOVIMENTO);

                /*" -2257- ADD 1 TO LD-CED-RESSARC */
                WS_AUX_ARQUIVO.LD_CED_RESSARC.Value = WS_AUX_ARQUIVO.LD_CED_RESSARC + 1;

                /*" -2258-  WHEN OTHER  */

                /*" -2258- ELSE */
            }
            else
            {


                /*" -2260- DISPLAY 'CEDENTE DESCONHECIDO ->> ' SIGC13-COD-AG-CEDENTE */
                _.Display($"CEDENTE DESCONHECIDO ->> {REG_SIGC13.SIGC13_DETALHE.SIGC13_COD_AG_CEDENTE}");

                /*" -2261- ADD 1 TO LD-CED-DESCONHECIDO */
                WS_AUX_ARQUIVO.LD_CED_DESCONHECIDO.Value = WS_AUX_ARQUIVO.LD_CED_DESCONHECIDO + 1;

                /*" -2262- PERFORM R0310-LE-COBRANCA */

                R0310_LE_COBRANCA_SECTION();

                /*" -2263- GO TO R0350-GRAVA-SORT-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_GRAVA_SORT_EXIT*/ //GOTO
                return;

                /*" -2265-  END-EVALUATE.  */

                /*" -2265- END-IF. */
            }


            /*" -2268- MOVE SOR-AGE-AVISO TO AUX-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_AGE_AVISO, WS_AUX_ARQUIVO.AUX_AGE_AVISO);

            /*" -2269- IF WS-NN-REG-TP-PARC = 8 */

            if (WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_TP_PARC == 8)
            {

                /*" -2270- MOVE 'R' TO SOR-TIPO-AVISO */
                _.Move("R", REG_ARQSORT.SOR_TIPO_AVISO);

                /*" -2271- MOVE 8 TO AUX-AGE-TP-AVISO */
                _.Move(8, WS_AUX_ARQUIVO.AUX_AGE_AVISO.AUX_AGE_TP_AVISO);

                /*" -2272- ELSE */
            }
            else
            {


                /*" -2273- MOVE 'C' TO SOR-TIPO-AVISO */
                _.Move("C", REG_ARQSORT.SOR_TIPO_AVISO);

                /*" -2274- MOVE 9 TO AUX-AGE-TP-AVISO */
                _.Move(9, WS_AUX_ARQUIVO.AUX_AGE_AVISO.AUX_AGE_TP_AVISO);

                /*" -2276- END-IF */
            }


            /*" -2278- IF SIGC13-COD-CEDENTE = 696001 AND WS-NN-REG-TP-PARC NOT = 8 */

            if (REG_SIGC13.SIGC13_DETALHE.SIGC13_CEDENTE_R.SIGC13_COD_CEDENTE == 696001 && WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_TP_PARC != 8)
            {

                /*" -2280- MOVE 9 TO AUX-AGE-TP-AVISO */
                _.Move(9, WS_AUX_ARQUIVO.AUX_AGE_AVISO.AUX_AGE_TP_AVISO);

                /*" -2281- IF WS-IDLG-EMP-SIST-TIPO = 'C000SASONLINE' */

                if (WS_AUX_AVISO.FILLER_42.WS_IDLG_EMP_SIST_TIPO == "C000SASONLINE")
                {

                    /*" -2282- IF WS-IDLG-ID = 1 */

                    if (WS_AUX_AVISO.FILLER_42.WS_IDLG_ID == 1)
                    {

                        /*" -2283- MOVE 'C' TO SOR-TIPO-AVISO */
                        _.Move("C", REG_ARQSORT.SOR_TIPO_AVISO);

                        /*" -2284- ELSE */
                    }
                    else
                    {


                        /*" -2285- MOVE 'R' TO SOR-TIPO-AVISO */
                        _.Move("R", REG_ARQSORT.SOR_TIPO_AVISO);

                        /*" -2286- END-IF */
                    }


                    /*" -2287- ELSE */
                }
                else
                {


                    /*" -2288- IF WS-IDLG-EMP-SIST-TIPO = 'C000AICONLINE' */

                    if (WS_AUX_AVISO.FILLER_42.WS_IDLG_EMP_SIST_TIPO == "C000AICONLINE")
                    {

                        /*" -2289- MOVE 'R' TO SOR-TIPO-AVISO */
                        _.Move("R", REG_ARQSORT.SOR_TIPO_AVISO);

                        /*" -2290- ELSE */
                    }
                    else
                    {


                        /*" -2291- MOVE 'C' TO SOR-TIPO-AVISO */
                        _.Move("C", REG_ARQSORT.SOR_TIPO_AVISO);

                        /*" -2292- END-IF */
                    }


                    /*" -2294- END-IF */
                }


                /*" -2297- IF (WS-IDLG-EMP-SIST-TIPO = 'C000SIASONLIN' OR SPACES) AND (WS-IDLG-PROD = 'CCA' OR 'LOT' ) */

                if ((WS_AUX_AVISO.FILLER_42.WS_IDLG_EMP_SIST_TIPO.In("C000SIASONLIN", string.Empty)) && (WS_AUX_AVISO.FILLER_42.WS_IDLG_PROD.In("CCA", "LOT")))
                {

                    /*" -2298- MOVE 'R' TO SOR-TIPO-AVISO */
                    _.Move("R", REG_ARQSORT.SOR_TIPO_AVISO);

                    /*" -2300- END-IF */
                }


                /*" -2302- END-IF */
            }


            /*" -2304- MOVE AUX-AGE-AVISO TO SOR-AGE-AVISO. */
            _.Move(WS_AUX_ARQUIVO.AUX_AGE_AVISO, REG_ARQSORT.SOR_AGE_AVISO);

            /*" -2306- RELEASE REG-ARQSORT */
            ARQSORT.Release(REG_ARQSORT);

            /*" -2308- ADD 1 TO W-SORT-TOT-GRAV */
            WS_AUX_ARQUIVO.W_SORT_TOT_GRAV.Value = WS_AUX_ARQUIVO.W_SORT_TOT_GRAV + 1;

            /*" -2308- PERFORM R0310-LE-COBRANCA. */

            R0310_LE_COBRANCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_GRAVA_SORT_EXIT*/

        [StopWatch]
        /*" R1500-OUTPUT-SORT-SECTION */
        private void R1500_OUTPUT_SORT_SECTION()
        {
            /*" -2317- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2318- DISPLAY W-PROGRAMA-CHAMADOR '-R1500-OUTPUT-SORT' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1500-OUTPUT-SORT");

                /*" -2322- END-IF */
            }


            /*" -2324- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2325- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -2326- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA);

            /*" -2327- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT1);

            /*" -2328- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);

            /*" -2329- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT2);

            /*" -2330- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

            /*" -2333- DISPLAY 'R1500-OUTPUT-SORT  ' WTIME-DAYR. */
            _.Display($"R1500-OUTPUT-SORT  {WS_AUX_DATAS.FILLER_37.WTIME_DAYR}");

            /*" -2334- MOVE SPACES TO WFIM-SORT. */
            _.Move("", WS_AUX_ARQUIVO.WFIM_SORT);

            /*" -2336- PERFORM R1510-LE-ARQSORT. */

            R1510_LE_ARQSORT_SECTION();

            /*" -2337- IF (WFIM-SORT NOT EQUAL SPACES) */

            if ((!WS_AUX_ARQUIVO.WFIM_SORT.IsEmpty()))
            {

                /*" -2338- GO TO R1500-OUTPUT-SORT-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_OUTPUT_SORT_EXIT*/ //GOTO
                return;

                /*" -2340- END-IF. */
            }


            /*" -2342- PERFORM UNTIL (WFIM-SORT NOT = SPACES) OR (W-SORT-OUTPUT-RETC NOT = 0) */

            while (!((!WS_AUX_ARQUIVO.WFIM_SORT.IsEmpty()) || (WS_AUX_ARQUIVO.W_SORT_OUTPUT_RETC != 0)))
            {

                /*" -2345- PERFORM R1550-PROCESSA-SORT */

                R1550_PROCESSA_SORT_SECTION();

                /*" -2346- PERFORM R1510-LE-ARQSORT */

                R1510_LE_ARQSORT_SECTION();

                /*" -2348- END-PERFORM */
            }

            /*" -2349- IF W-SORT-OUTPUT-RETC = 0 */

            if (WS_AUX_ARQUIVO.W_SORT_OUTPUT_RETC == 0)
            {

                /*" -2350- PERFORM R7500-UPDATE-V0CEDENTE */

                R7500_UPDATE_V0CEDENTE_SECTION();

                /*" -2351- END-IF */
            }


            /*" -2351- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_OUTPUT_SORT_EXIT*/

        [StopWatch]
        /*" R1510-LE-ARQSORT-SECTION */
        private void R1510_LE_ARQSORT_SECTION()
        {
            /*" -2359- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2360- DISPLAY W-PROGRAMA-CHAMADOR '-R1510-LE-ARQSORT' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1510-LE-ARQSORT");

                /*" -2364- END-IF */
            }


            /*" -2366- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WABEND.WNR_EXEC_SQL);

            /*" -2368- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -2369- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WS_AUX_ARQUIVO.WFIM_SORT);

                    /*" -2370- ACCEPT WS-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

                    /*" -2371- MOVE WS-HH-TIME TO WTIME-HORA */
                    _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA);

                    /*" -2372- MOVE '.' TO WTIME-2PT1 */
                    _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT1);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2373- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);

            /*" -2374- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT2);

            /*" -2375- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

            /*" -2377- DISPLAY 'WFIM-SORT          ' WFIM-SORT '    ' WTIME-DAYR */

            $"WFIM-SORT          {WS_AUX_ARQUIVO.WFIM_SORT}    {WS_AUX_DATAS.FILLER_37.WTIME_DAYR}"
            .Display();

            /*" -2380- GO TO R1510-LE-ARQSORT-EXIT END-RETURN */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_LE_ARQSORT_EXIT*/ //GOTO
            return;


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_LE_ARQSORT_EXIT*/

        [StopWatch]
        /*" R1550-PROCESSA-SORT-SECTION */
        private void R1550_PROCESSA_SORT_SECTION()
        {
            /*" -2436- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2437- DISPLAY W-PROGRAMA-CHAMADOR '-R1550-PROCESSA-SORT' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1550-PROCESSA-SORT");

                /*" -2440- END-IF */
            }


            /*" -2442- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", WABEND.WNR_EXEC_SQL);

            /*" -2444- MOVE 'N' TO FLG-GRAFICA FLG-MALA. */
            _.Move("N", WS_AUX_ARQUIVO.FLG_GRAFICA, WS_AUX_ARQUIVO.FLG_MALA);

            /*" -2446- MOVE REG-ARQSORT TO COBRAN-REGISTRO. */
            _.Move(REG_ARQSORT, COBRAN_REGISTRO);

            /*" -2449- MOVE 104 TO V0DPCF-BCOAVISO WWORK-BCOAVISO V0AVIS-BCOAVISO */
            _.Move(104, V0DPCF_BCOAVISO, WS_AUX_AVISO.WWORK_BCOAVISO, V0AVIS_BCOAVISO);

            /*" -2452- MOVE SPACES TO AUX-DESCRICAO V0MCOB-NOME */
            _.Move("", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO, V0MCOB_NOME);

            /*" -2454- ADD 1 TO V0CNAB-QTDREG. */
            V0CNAB_QTDREG.Value = V0CNAB_QTDREG + 1;

            /*" -2457- MOVE COBRAN-NUM-AGE-RECEB TO V0RCAP-AGECOBR CONVEN-AGECOBR */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB, V0RCAP_AGECOBR, WS_AUX_ARQUIVO.CONVEN_AGECOBR);

            /*" -2459- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -2460- MOVE COBRAN-AGE-AVISO TO WWORK-AVS-AGE */
            _.Move(COBRAN_REGISTRO.COBRAN_AGE_AVISO, FILLER_58.WWORK_AVS_AGE);

            /*" -2463- MOVE COBRAN-NSAC TO WWORK-AVS-NRO V0MCOB-NUMFITA */
            _.Move(COBRAN_REGISTRO.COBRAN_NSAC, FILLER_58.WWORK_AVS_NRO);
            _.Move(COBRAN_REGISTRO.COBRAN_NSAC, V0MCOB_NUMFITA);


            /*" -2464- MOVE WWORK-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(WWORK_NRAVISO, V0MCOB_NRAVISO);

            /*" -2465- MOVE WWORK-AVS-AGE TO WWORK-AGEAVISO */
            _.Move(FILLER_58.WWORK_AVS_AGE, WWORK_AGEAVISO);

            /*" -2466- MOVE 7 TO WWORK-TIP-AGE */
            _.Move(7, FILLER_57.WWORK_TIP_AGE);

            /*" -2468- MOVE WWORK-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(WWORK_AGEAVISO, V0MCOB_AGENCIA);

            /*" -2469- MOVE WWORK-BCOAVISO TO V0AVIS-BCOAVISO */
            _.Move(WS_AUX_AVISO.WWORK_BCOAVISO, V0AVIS_BCOAVISO);

            /*" -2470- MOVE WWORK-AGEAVISO TO V0AVIS-AGEAVISO */
            _.Move(WWORK_AGEAVISO, V0AVIS_AGEAVISO);

            /*" -2472- MOVE WWORK-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WWORK_NRAVISO, V0AVIS_NRAVISO);

            /*" -2473- MOVE COBRAN-DIA-GERACAO TO WDAT-TAB-DIA1 */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_GERACAO.COBRAN_DIA_GERACAO, WS_AUX_DATAS.WDATA_TABELA1.WDAT_TAB_DIA1);

            /*" -2474- MOVE COBRAN-MES-GERACAO TO WDAT-TAB-MES1 */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_GERACAO.COBRAN_MES_GERACAO, WS_AUX_DATAS.WDATA_TABELA1.WDAT_TAB_MES1);

            /*" -2476- MOVE COBRAN-ANO-GERACAO TO WDAT-TAB-ANO1 */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_GERACAO.COBRAN_ANO_GERACAO, WS_AUX_DATAS.WDATA_TABELA1.WDAT_TAB_ANO1);

            /*" -2478- MOVE WDATA-TABELA1 TO WWORK-DTAVISO */
            _.Move(WS_AUX_DATAS.WDATA_TABELA1, WS_AUX_AVISO.WWORK_DTAVISO);

            /*" -2479- IF (COBRAN-NUM-BCO-RECEB EQUAL 104) */

            if ((COBRAN_REGISTRO.COBRAN_NUM_BCO_RECEB == 104))
            {

                /*" -2480- PERFORM R1560-VERIFICA-CEF */

                R1560_VERIFICA_CEF_SECTION();

                /*" -2481- ELSE */
            }
            else
            {


                /*" -2482- PERFORM R1700-VERIFICA-OUTROS */

                R1700_VERIFICA_OUTROS_SECTION();

                /*" -2484- END-IF. */
            }


            /*" -2486- MOVE COBRAN-NUM-AGE-RECEB TO CONVEN-AGECOBR */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB, WS_AUX_ARQUIVO.CONVEN_AGECOBR);

            /*" -2488- MOVE ZEROS TO WSHOST-CODPRODU */
            _.Move(0, WSHOST_CODPRODU);

            /*" -2489- MOVE COBRAN-VLR-PAGO TO WSHOST-VLPRMTOT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, WSHOST_VLPRMTOT);

            /*" -2490- MOVE COBRAN-VLR-TARIFA TO WSHOST-VLTARIFA */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_TARIFA, WSHOST_VLTARIFA);

            /*" -2491- MOVE COBRAN-VLR-ABATIMENTO TO WSHOST-VLBALCAO */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO, WSHOST_VLBALCAO);

            /*" -2492- MOVE COBRAN-VLR-IOF TO WSHOST-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, WSHOST_VLIOCC);

            /*" -2493- MOVE COBRAN-VLR-DESCONTO TO WSHOST-VLDESCON */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_DESCONTO, WSHOST_VLDESCON);

            /*" -2495- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -2497- MOVE COBRAN-IDLG TO WS-COD-IDLG WS-COD-IDLG-1 */
            _.Move(COBRAN_REGISTRO.COBRAN_IDLG, WS_AUX_AVISO.WS_COD_IDLG, WS_AUX_AVISO.WS_COD_IDLG_1);

            /*" -2499- MOVE 0 TO WS-FLAG-CCA-LOT */
            _.Move(0, WS_FLAG_CCA_LOT);

            /*" -2502- IF (WS-IDLG-EMP-SIST-TIPO = 'C000SIASONLIN' OR SPACES) AND (WS-IDLG-PROD = 'CCA' OR 'LOT' ) */

            if ((WS_AUX_AVISO.FILLER_42.WS_IDLG_EMP_SIST_TIPO.In("C000SIASONLIN", string.Empty)) && (WS_AUX_AVISO.FILLER_42.WS_IDLG_PROD.In("CCA", "LOT")))
            {

                /*" -2503- MOVE 1 TO WS-FLAG-CCA-LOT */
                _.Move(1, WS_FLAG_CCA_LOT);

                /*" -2505- END-IF */
            }


            /*" -2506- IF COBRAN-COD-CEDENTE = 696001 AND WS-FLAG-CCA-LOT = 0 */

            if (COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001 && WS_FLAG_CCA_LOT == 0)
            {

                /*" -2508- PERFORM R2650-VERIFICA-SIES */

                R2650_VERIFICA_SIES_SECTION();

                /*" -2509- IF (WTEM-SIES EQUAL 'S' ) */

                if ((WS_AUX_ARQUIVO.WTEM_SIES == "S"))
                {

                    /*" -2510- MOVE 'SIES' TO V0MCOB-NOME */
                    _.Move("SIES", V0MCOB_NOME);

                    /*" -2511- PERFORM R2680-GRAVA-MOVIMCOB-SIES */

                    R2680_GRAVA_MOVIMCOB_SIES_SECTION();

                    /*" -2512- GO TO R1550-PROCESSA-SORT-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_PROCESSA_SORT_EXIT*/ //GOTO
                    return;

                    /*" -2513- END-IF */
                }


                /*" -2515- END-IF. */
            }


            /*" -2517- IF (COBRAN-COD-CEDENTE-N EQUAL 696005 OR = CVPCV-696005 OR = JV1CV-696005 ) */

            if ((COBRAN_REGISTRO.COBRAN_CEDENTE_R.FILLER_68.COBRAN_COD_CEDENTE_N.In("696005", JVBKINCL.JV_CONVENIOS.CVPCV_696005.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_696005.ToString())))
            {

                /*" -2518- PERFORM R2700-TRATA-RESSARCIMENTO */

                R2700_TRATA_RESSARCIMENTO_SECTION();

                /*" -2519- SET WS-TIP TO 3 */
                WS_TIP.Value = 3;

                /*" -2520- ELSE */
            }
            else
            {


                /*" -2521- IF (COBRAN-TIPO-AVISO EQUAL 'C' ) */

                if ((COBRAN_REGISTRO.COBRAN_TIPO_AVISO == "C"))
                {

                    /*" -2522- PERFORM R3200-TRATA-DEMAIS-PARCELAS */

                    R3200_TRATA_DEMAIS_PARCELAS_SECTION();

                    /*" -2523- SET WS-TIP TO 4 */
                    WS_TIP.Value = 4;

                    /*" -2524- ELSE */
                }
                else
                {


                    /*" -2525- PERFORM R3500-TRATA-ADESAO */

                    R3500_TRATA_ADESAO_SECTION();

                    /*" -2526- SET WS-TIP TO 1 */
                    WS_TIP.Value = 1;

                    /*" -2527- END-IF */
                }


                /*" -2529- END-IF. */
            }


            /*" -2530- PERFORM R8000-SUMARIZA-AVISOS */

            R8000_SUMARIZA_AVISOS_SECTION();

            /*" -2530- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_PROCESSA_SORT_EXIT*/

        [StopWatch]
        /*" R1560-VERIFICA-CEF-SECTION */
        private void R1560_VERIFICA_CEF_SECTION()
        {
            /*" -2538- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2539- DISPLAY W-PROGRAMA-CHAMADOR '-R1560-VERIFICA-CEF' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1560-VERIFICA-CEF");

                /*" -2543- END-IF */
            }


            /*" -2545- MOVE '1560' TO WNR-EXEC-SQL. */
            _.Move("1560", WABEND.WNR_EXEC_SQL);

            /*" -2547- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2548- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2549- WHEN V0RCAP-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0RCAP_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2550- MOVE WACEF-ESCNEG(WS-AGE) TO CONVEN-ESCNEG */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

                    /*" -2551- MOVE WACEF-FONTE(WS-AGE) TO CONVEN-FONTE */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2551- END-SEARCH. */
                    break;
                }
            }


            /*" -2554- IF (CONVEN-ESCNEG EQUAL 9999) */

            if ((WS_AUX_ARQUIVO.CONVEN_ESCNEG == 9999))
            {

                /*" -2555- PERFORM R1600-PESQUISA-AGENCIA */

                R1600_PESQUISA_AGENCIA_SECTION();

                /*" -2556- ELSE */
            }
            else
            {


                /*" -2557- MOVE V0RCAP-AGECOBR TO COBRAN-NUM-AGE-RECEB */
                _.Move(V0RCAP_AGECOBR, COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB);

                /*" -2557- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1560_VERIFICA_CEF_EXIT*/

        [StopWatch]
        /*" R1600-PESQUISA-AGENCIA-SECTION */
        private void R1600_PESQUISA_AGENCIA_SECTION()
        {
            /*" -2566- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2567- DISPLAY W-PROGRAMA-CHAMADOR '-R1600-PESQUISA-AGENCIA' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1600-PESQUISA-AGENCIA");

                /*" -2571- END-IF */
            }


            /*" -2573- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -2574- MOVE ZEROS TO CONVEN-FONTE */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_FONTE);

            /*" -2575- MOVE 9999 TO CONVEN-ESCNEG */
            _.Move(9999, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

            /*" -2578- MOVE COBRAN-NUM-AGE-RECEB TO V0RCAP-AGECOBR CONVEN-AGECOBR. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB, V0RCAP_AGECOBR, WS_AUX_ARQUIVO.CONVEN_AGECOBR);

            /*" -2580- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2581- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2582- WHEN V0RCAP-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0RCAP_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2583- MOVE WACEF-ESCNEG(WS-AGE) TO CONVEN-ESCNEG */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

                    /*" -2584- MOVE WACEF-FONTE(WS-AGE) TO CONVEN-FONTE */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2584- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_PESQUISA_AGENCIA_EXIT*/

        [StopWatch]
        /*" R1700-VERIFICA-OUTROS-SECTION */
        private void R1700_VERIFICA_OUTROS_SECTION()
        {
            /*" -2593- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2594- DISPLAY W-PROGRAMA-CHAMADOR '-R1700-VERIFICA-OUTROS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1700-VERIFICA-OUTROS");

                /*" -2598- END-IF */
            }


            /*" -2600- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -2601- MOVE COBRAN-NUM-BCO-RECEB TO V0AGEN-BANCO */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_BCO_RECEB, V0AGEN_BANCO);

            /*" -2603- MOVE COBRAN-NUM-AGE-RECEB TO V0AGEN-AGENCIA */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB, V0AGEN_AGENCIA);

            /*" -2605- PERFORM R1750-SELECT-V0AGENCIAS. */

            R1750_SELECT_V0AGENCIAS_SECTION();

            /*" -2606- EVALUATE V0AGEN-ESTADO */
            switch (V0AGEN_ESTADO.Value.Trim())
            {

                /*" -2607- WHEN 'RJ' */
                case "RJ":

                    /*" -2608- MOVE 01 TO CONVEN-FONTE */
                    _.Move(01, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2609- WHEN 'BA' */
                    break;
                case "BA":

                    /*" -2610- MOVE 04 TO CONVEN-FONTE */
                    _.Move(04, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2611- WHEN 'CE' */
                    break;
                case "CE":

                    /*" -2612- MOVE 06 TO CONVEN-FONTE */
                    _.Move(06, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2613- WHEN 'ES' */
                    break;
                case "ES":

                    /*" -2614- MOVE 07 TO CONVEN-FONTE */
                    _.Move(07, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2615- WHEN 'GO' */
                    break;
                case "GO":

                    /*" -2616- MOVE 09 TO CONVEN-FONTE */
                    _.Move(09, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2617- WHEN 'MG' */
                    break;
                case "MG":

                    /*" -2618- MOVE 12 TO CONVEN-FONTE */
                    _.Move(12, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2619- WHEN 'PA' */
                    break;
                case "PA":

                    /*" -2620- MOVE 13 TO CONVEN-FONTE */
                    _.Move(13, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2621- WHEN 'PR' */
                    break;
                case "PR":

                    /*" -2622- MOVE 15 TO CONVEN-FONTE */
                    _.Move(15, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2623- WHEN 'PE' */
                    break;
                case "PE":

                    /*" -2624- MOVE 16 TO CONVEN-FONTE */
                    _.Move(16, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2625- WHEN 'RS' */
                    break;
                case "RS":

                    /*" -2626- MOVE 19 TO CONVEN-FONTE */
                    _.Move(19, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2627- WHEN 'SC' */
                    break;
                case "SC":

                    /*" -2628- MOVE 20 TO CONVEN-FONTE */
                    _.Move(20, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2629- WHEN 'SP' */
                    break;
                case "SP":

                    /*" -2630- MOVE 21 TO CONVEN-FONTE */
                    _.Move(21, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2631- WHEN 'MS' */
                    break;
                case "MS":

                    /*" -2632- MOVE 23 TO CONVEN-FONTE */
                    _.Move(23, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2633- WHEN OTHER */
                    break;
                default:

                    /*" -2634- MOVE 10 TO CONVEN-FONTE */
                    _.Move(10, WS_AUX_ARQUIVO.CONVEN_FONTE);

                    /*" -2634- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_VERIFICA_OUTROS_EXIT*/

        [StopWatch]
        /*" R1750-SELECT-V0AGENCIAS-SECTION */
        private void R1750_SELECT_V0AGENCIAS_SECTION()
        {
            /*" -2643- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2644- DISPLAY W-PROGRAMA-CHAMADOR '-R1750-SELECT-V0AGENCIAS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R1750-SELECT-V0AGENCIAS");

                /*" -2647- END-IF */
            }


            /*" -2649- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", WABEND.WNR_EXEC_SQL);

            /*" -2651- INITIALIZE V0AGEN-ESTADO */
            _.Initialize(
                V0AGEN_ESTADO
            );

            /*" -2658- PERFORM R1750_SELECT_V0AGENCIAS_DB_SELECT_1 */

            R1750_SELECT_V0AGENCIAS_DB_SELECT_1();

            /*" -2661- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -2662- MOVE 'DF' TO V0AGEN-ESTADO */
                _.Move("DF", V0AGEN_ESTADO);

                /*" -2663- ELSE */
            }
            else
            {


                /*" -2664- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2665- DISPLAY 'R1750-00 - PROBLEMAS NO SELECT(V0AGENCIAS)' */
                    _.Display($"R1750-00 - PROBLEMAS NO SELECT(V0AGENCIAS)");

                    /*" -2667- MOVE 'R1750-00 - PROBLEMAS NO SELECT(V0AGENCIAS)' TO W-MENSAGEM-ERRO */
                    _.Move("R1750-00 - PROBLEMAS NO SELECT(V0AGENCIAS)", W_MENSAGEM_ERRO);

                    /*" -2668- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2669- END-IF */
                }


                /*" -2669- END-IF. */
            }


        }

        [StopWatch]
        /*" R1750-SELECT-V0AGENCIAS-DB-SELECT-1 */
        public void R1750_SELECT_V0AGENCIAS_DB_SELECT_1()
        {
            /*" -2658- EXEC SQL SELECT ESTADO INTO :V0AGEN-ESTADO FROM SEGUROS.V0AGENCIAS WHERE BANCO = :V0AGEN-BANCO AND AGENCIA = :V0AGEN-AGENCIA WITH UR END-EXEC. */

            var r1750_SELECT_V0AGENCIAS_DB_SELECT_1_Query1 = new R1750_SELECT_V0AGENCIAS_DB_SELECT_1_Query1()
            {
                V0AGEN_AGENCIA = V0AGEN_AGENCIA.ToString(),
                V0AGEN_BANCO = V0AGEN_BANCO.ToString(),
            };

            var executed_1 = R1750_SELECT_V0AGENCIAS_DB_SELECT_1_Query1.Execute(r1750_SELECT_V0AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AGEN_ESTADO, V0AGEN_ESTADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_SELECT_V0AGENCIAS_EXIT*/

        [StopWatch]
        /*" R2500-SELECT-V0AVISOCRED-SECTION */
        private void R2500_SELECT_V0AVISOCRED_SECTION()
        {
            /*" -2678- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2679- DISPLAY W-PROGRAMA-CHAMADOR '-R2500-SELECT-V0AVISOCRED' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2500-SELECT-V0AVISOCRED");

                /*" -2682- END-IF */
            }


            /*" -2684- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -2686- INITIALIZE WHOST-COUNT-AVS. */
            _.Initialize(
                WHOST_COUNT_AVS
            );

            /*" -2694- PERFORM R2500_SELECT_V0AVISOCRED_DB_SELECT_1 */

            R2500_SELECT_V0AVISOCRED_DB_SELECT_1();

            /*" -2697- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2701- DISPLAY 'R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)' ' ' V0AVIS-AGEAVISO ' ' V0AVIS-NRAVISO ' ' V0AVIS-NRSEQ */

                $"R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED) {V0AVIS_AGEAVISO} {V0AVIS_NRAVISO} {V0AVIS_NRSEQ}"
                .Display();

                /*" -2703- MOVE 'R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)' TO W-MENSAGEM-ERRO */
                _.Move("R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)", W_MENSAGEM_ERRO);

                /*" -2704- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2704- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-SELECT-V0AVISOCRED-DB-SELECT-1 */
        public void R2500_SELECT_V0AVISOCRED_DB_SELECT_1()
        {
            /*" -2694- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WHOST-COUNT-AVS FROM SEGUROS.V0AVISOCRED WHERE AGEAVISO = :V0AVIS-AGEAVISO AND NRAVISO = :V0AVIS-NRAVISO AND NRSEQ = :V0AVIS-NRSEQ WITH UR END-EXEC. */

            var r2500_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 = new R2500_SELECT_V0AVISOCRED_DB_SELECT_1_Query1()
            {
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
            };

            var executed_1 = R2500_SELECT_V0AVISOCRED_DB_SELECT_1_Query1.Execute(r2500_SELECT_V0AVISOCRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT_AVS, WHOST_COUNT_AVS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_SELECT_V0AVISOCRED_EXIT*/

        [StopWatch]
        /*" R2650-VERIFICA-SIES-SECTION */
        private void R2650_VERIFICA_SIES_SECTION()
        {
            /*" -2714- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2715- DISPLAY W-PROGRAMA-CHAMADOR '-R2650-VERIFICA-SIES' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2650-VERIFICA-SIES");

                /*" -2718- END-IF */
            }


            /*" -2720- MOVE '2650' TO WNR-EXEC-SQL. */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -2722- MOVE 'N' TO WTEM-SIES */
            _.Move("N", WS_AUX_ARQUIVO.WTEM_SIES);

            /*" -2723- IF (COBRAN-IDLG(05:04) EQUAL 'SIES' ) */

            if ((COBRAN_REGISTRO.COBRAN_IDLG.Substring(05, 04) == "SIES"))
            {

                /*" -2724- MOVE 'S' TO WTEM-SIES */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -2725- GO TO R2650-VERIFICA-SIES-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_VERIFICA_SIES_EXIT*/ //GOTO
                return;

                /*" -2727- END-IF */
            }


            /*" -2729- IF (COBRAN-NUM-PROPOSTA > 8071000000000000) AND (COBRAN-NUM-PROPOSTA < 8072000000000000) */

            if ((COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA > 8071000000000000) && (COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA < 8072000000000000))
            {

                /*" -2730- MOVE 'S' TO WTEM-SIES */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -2731- GO TO R2650-VERIFICA-SIES-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_VERIFICA_SIES_EXIT*/ //GOTO
                return;

                /*" -2733- END-IF */
            }


            /*" -2734- MOVE COBRAN-NUM-PROPOSTA TO AUX-USO-EMPRESA. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -2736- MOVE AUX-TITSIVPF TO AUX-NRO-SIVPF. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_NRO_SIVPF);

            /*" -2738- IF (AUX-CANAL NOT EQUAL ZEROS) AND (AUX-PRDSIVPF EQUAL 10 OR 50 OR 71 OR 72) */

            if ((WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL != 00) && (WS_AUX_ARQUIVO.FILLER_21.AUX_PRDSIVPF.In("10", "50", "71", "72")))
            {

                /*" -2739- MOVE 'S' TO WTEM-SIES */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -2740- GO TO R2650-VERIFICA-SIES-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_VERIFICA_SIES_EXIT*/ //GOTO
                return;

                /*" -2742- END-IF */
            }


            /*" -2743- MOVE ZEROS TO CONVEN-CODPRODU. */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_CODPRODU);

            /*" -2745- MOVE AUX-PRDSIVPF TO V0PRPF-CODSIVPF. */
            _.Move(WS_AUX_ARQUIVO.FILLER_21.AUX_PRDSIVPF, V0PRPF_CODSIVPF);

            /*" -2747- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -2748- SEARCH WPROD-OCORREPRD */
            for (; WS_PRD < WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -2749- WHEN V0PRPF-CODSIVPF EQUAL WPROD-PRDSIVPF(WS-PRD) */

                if (V0PRPF_CODSIVPF == WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF)
                {


                    /*" -2751- MOVE WPROD-CODPRODU(WS-PRD) TO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -2751- END-SEARCH. */
                    break;
                }
            }


            /*" -2754- IF (CONVEN-CODPRODU EQUAL 1403 OR 1404) */

            if ((WS_AUX_ARQUIVO.CONVEN_CODPRODU.In("1403", "1404")))
            {

                /*" -2755- PERFORM R2670-SELECT-RENOVACAO */

                R2670_SELECT_RENOVACAO_SECTION();

                /*" -2756- ELSE */
            }
            else
            {


                /*" -2758- IF (CONVEN-CODPRODU EQUAL 1402 OR 1405 OR 1804 OR 1802 OR 7114) */

                if ((WS_AUX_ARQUIVO.CONVEN_CODPRODU.In("1402", "1405", "1804", "1802", "7114")))
                {

                    /*" -2759- MOVE 'S' TO WTEM-SIES */
                    _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                    /*" -2760- GO TO R2650-VERIFICA-SIES-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_VERIFICA_SIES_EXIT*/ //GOTO
                    return;

                    /*" -2761- END-IF */
                }


                /*" -2761- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_VERIFICA_SIES_EXIT*/

        [StopWatch]
        /*" R2670-SELECT-RENOVACAO-SECTION */
        private void R2670_SELECT_RENOVACAO_SECTION()
        {
            /*" -2769- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2770- DISPLAY W-PROGRAMA-CHAMADOR '-R2670-SELECT-RENOVACAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2670-SELECT-RENOVACAO");

                /*" -2774- END-IF */
            }


            /*" -2776- MOVE '2670' TO WNR-EXEC-SQL. */
            _.Move("2670", WABEND.WNR_EXEC_SQL);

            /*" -2778- MOVE AUX-TITSIVPF TO MR028-NUM-TITULO. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, MR028.DCLMR_PROP_RENOVACAO.MR028_NUM_TITULO);

            /*" -2780- INITIALIZE PROPOSTA-DATA-INIVIGENCIA */
            _.Initialize(
                PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA
            );

            /*" -2789- PERFORM R2670_SELECT_RENOVACAO_DB_SELECT_1 */

            R2670_SELECT_RENOVACAO_DB_SELECT_1();

            /*" -2792- IF (SQLCODE EQUAL -911 OR -913) */

            if ((DB.SQLCODE.In("-911", "-913")))
            {

                /*" -2793- DISPLAY 'R2670-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' */
                _.Display($"R2670-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT");

                /*" -2795- MOVE 'R2670-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' TO W-MENSAGEM-ERRO */
                _.Move("R2670-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT", W_MENSAGEM_ERRO);

                /*" -2796- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2798- END-IF */
            }


            /*" -2799- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -2801- DISPLAY 'R2670-01 - PROBLEMAS SELECT MR_PROP_RENOVACAO ' 'E PROPOSTAS.' */
                _.Display($"R2670-01 - PROBLEMAS SELECT MR_PROP_RENOVACAO E PROPOSTAS.");

                /*" -2803- MOVE 'R2670-01 - PROBLEMAS SELECT MR_PROP_RENOVACAO ' TO W-MENSAGEM-ERRO */
                _.Move("R2670-01 - PROBLEMAS SELECT MR_PROP_RENOVACAO ", W_MENSAGEM_ERRO);

                /*" -2804- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2806- END-IF */
            }


            /*" -2808- IF (SQLCODE EQUAL ZEROS) AND (PROPOSTA-DATA-INIVIGENCIA < '2009-10-01' ) */

            if ((DB.SQLCODE == 00) && (PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA < "2009-10-01"))
            {

                /*" -2809- MOVE 'N' TO WTEM-SIES */
                _.Move("N", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -2810- ELSE */
            }
            else
            {


                /*" -2811- MOVE 'S' TO WTEM-SIES */
                _.Move("S", WS_AUX_ARQUIVO.WTEM_SIES);

                /*" -2811- END-IF. */
            }


        }

        [StopWatch]
        /*" R2670-SELECT-RENOVACAO-DB-SELECT-1 */
        public void R2670_SELECT_RENOVACAO_DB_SELECT_1()
        {
            /*" -2789- EXEC SQL SELECT B.DATA_INIVIGENCIA INTO :PROPOSTA-DATA-INIVIGENCIA FROM SEGUROS.MR_PROP_RENOVACAO A, SEGUROS.PROPOSTAS B WHERE A.NUM_TITULO = :MR028-NUM-TITULO AND B.COD_FONTE = A.COD_FONTE AND B.NUM_PROPOSTA = A.NUM_PROPOSTA WITH UR END-EXEC. */

            var r2670_SELECT_RENOVACAO_DB_SELECT_1_Query1 = new R2670_SELECT_RENOVACAO_DB_SELECT_1_Query1()
            {
                MR028_NUM_TITULO = MR028.DCLMR_PROP_RENOVACAO.MR028_NUM_TITULO.ToString(),
            };

            var executed_1 = R2670_SELECT_RENOVACAO_DB_SELECT_1_Query1.Execute(r2670_SELECT_RENOVACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_DATA_INIVIGENCIA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2670_SELECT_RENOVACAO_EXIT*/

        [StopWatch]
        /*" R2680-GRAVA-MOVIMCOB-SIES-SECTION */
        private void R2680_GRAVA_MOVIMCOB_SIES_SECTION()
        {
            /*" -2820- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2822- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R2680-GRAVA-MOVIMCOB-SIES' */

                $"{W_PROGRAMA_CHAMADOR}-R2680-GRAVA-MOVIMCOB-SIES"
                .Display();

                /*" -2826- END-IF */
            }


            /*" -2828- MOVE '2680' TO WNR-EXEC-SQL. */
            _.Move("2680", WABEND.WNR_EXEC_SQL);

            /*" -2829- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -2830- MOVE COBRAN-COD-MOVIMENTO TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_COD_MOVIMENTO, V0MCOB_CODMOV);

            /*" -2832- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -2833- MOVE WWORK-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(WWORK_NRAVISO, V0MCOB_NRAVISO);

            /*" -2834- MOVE WWORK-AVS-AGE TO WWORK-AGEAVISO */
            _.Move(FILLER_58.WWORK_AVS_AGE, WWORK_AGEAVISO);

            /*" -2835- MOVE 7 TO WWORK-TIP-AGE */
            _.Move(7, FILLER_57.WWORK_TIP_AGE);

            /*" -2837- MOVE WWORK-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(WWORK_AGEAVISO, V0MCOB_AGENCIA);

            /*" -2838- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -2839- MOVE COBRAN-NUM-PROPOSTA TO V0MCOB-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, V0MCOB_NRTIT);

            /*" -2840- MOVE COBRAN-VLR-PAGO TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0MCOB_VALTIT);

            /*" -2841- MOVE COBRAN-VLR-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, V0MCOB_VLIOCC);

            /*" -2843- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -2846- COMPUTE V0MCOB-VALCDT = COBRAN-VLR-PAGO - COBRAN-VLR-IOF - COBRAN-VLR-DESCONTO - COBRAN-VLR-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PAGO - COBRAN_REGISTRO.COBRAN_VLR_IOF - COBRAN_REGISTRO.COBRAN_VLR_DESCONTO - COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO;

            /*" -2849- MOVE ZEROS TO V0MCOB-NUMAPOL V0MCOB-NRENDOS V0MCOB-NRPARCEL */
            _.Move(0, V0MCOB_NUMAPOL, V0MCOB_NRENDOS, V0MCOB_NRPARCEL);

            /*" -2850- MOVE 'SIES' TO V0MCOB-NOME */
            _.Move("SIES", V0MCOB_NOME);

            /*" -2851- MOVE '*' TO V0MCOB-SITUACAO */
            _.Move("*", V0MCOB_SITUACAO);

            /*" -2853- MOVE '*' TO V0MCOB-TIPOMOV. */
            _.Move("*", V0MCOB_TIPOMOV);

            /*" -2854- MOVE COBRAN-DTA-PAGAMENTO TO WDATA-SECULO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_PAGAMENTO, WS_AUX_DATAS.WDATA_SECULO);

            /*" -2855- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -2856- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -2857- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -2858- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -2860- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -2861- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -2862- MOVE WS-NN-REG-16P TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.WS_NN_REG_16P, V0MCOB_NUM_NOSSO_TITULO);

            /*" -2864- ADD 1 TO DP-SIES */
            WS_AUX_ARQUIVO.DP_SIES.Value = WS_AUX_ARQUIVO.DP_SIES + 1;

            /*" -2864- PERFORM R2690-INCLUI-V0MOVICOB. */

            R2690_INCLUI_V0MOVICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2680_GRAVA_MOVIMCOB_SIES_EXIT*/

        [StopWatch]
        /*" R2690-INCLUI-V0MOVICOB-SECTION */
        private void R2690_INCLUI_V0MOVICOB_SECTION()
        {
            /*" -2871- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2872- DISPLAY W-PROGRAMA-CHAMADOR '-R2690-INCLUI-V0MOVICOB' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2690-INCLUI-V0MOVICOB");

                /*" -2873- DISPLAY 'V0MCOB-TIPOMOV = ' V0MCOB-TIPOMOV */
                _.Display($"V0MCOB-TIPOMOV = {V0MCOB_TIPOMOV}");

                /*" -2877- END-IF */
            }


            /*" -2880- MOVE '2690' TO WNR-EXEC-SQL. */
            _.Move("2690", WABEND.WNR_EXEC_SQL);

            /*" -2881- IF V0MCOB-TIPOMOV EQUAL '3' */

            if (V0MCOB_TIPOMOV == "3")
            {

                /*" -2882- PERFORM R3222-SELECT-COBHISVI */

                R3222_SELECT_COBHISVI_SECTION();

                /*" -2884- END-IF */
            }


            /*" -2926- PERFORM R2690_INCLUI_V0MOVICOB_DB_INSERT_1 */

            R2690_INCLUI_V0MOVICOB_DB_INSERT_1();

            /*" -2929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2930- DISPLAY 'R2690-00 - PROBLEMAS INSERT (V0MOVICOB)' */
                _.Display($"R2690-00 - PROBLEMAS INSERT (V0MOVICOB)");

                /*" -2931- DISPLAY 'V0MCOB-CODEMP  : ' V0MCOB-CODEMP */
                _.Display($"V0MCOB-CODEMP  : {V0MCOB_CODEMP}");

                /*" -2932- DISPLAY 'V0MCOB-CODMOV  : ' V0MCOB-CODMOV */
                _.Display($"V0MCOB-CODMOV  : {V0MCOB_CODMOV}");

                /*" -2933- DISPLAY 'V0MCOB-BANCO   : ' V0MCOB-BANCO */
                _.Display($"V0MCOB-BANCO   : {V0MCOB_BANCO}");

                /*" -2934- DISPLAY 'V0MCOB-AGENCIA : ' V0MCOB-AGENCIA */
                _.Display($"V0MCOB-AGENCIA : {V0MCOB_AGENCIA}");

                /*" -2935- DISPLAY 'V0MCOB-NRAVISO : ' V0MCOB-NRAVISO */
                _.Display($"V0MCOB-NRAVISO : {V0MCOB_NRAVISO}");

                /*" -2936- DISPLAY 'V0MCOB-NUMFITA : ' V0MCOB-NUMFITA */
                _.Display($"V0MCOB-NUMFITA : {V0MCOB_NUMFITA}");

                /*" -2937- DISPLAY 'V0MCOB-DTMOVTO : ' V0MCOB-DTMOVTO */
                _.Display($"V0MCOB-DTMOVTO : {V0MCOB_DTMOVTO}");

                /*" -2938- DISPLAY 'V0MCOB-DTQITBCO: ' V0MCOB-DTQITBCO */
                _.Display($"V0MCOB-DTQITBCO: {V0MCOB_DTQITBCO}");

                /*" -2939- DISPLAY 'V0MCOB-NRTIT   : ' V0MCOB-NRTIT */
                _.Display($"V0MCOB-NRTIT   : {V0MCOB_NRTIT}");

                /*" -2940- DISPLAY 'V0MCOB-NUMAPOL : ' V0MCOB-NUMAPOL */
                _.Display($"V0MCOB-NUMAPOL : {V0MCOB_NUMAPOL}");

                /*" -2941- DISPLAY 'V0MCOB-NRENDOS : ' V0MCOB-NRENDOS */
                _.Display($"V0MCOB-NRENDOS : {V0MCOB_NRENDOS}");

                /*" -2942- DISPLAY 'V0MCOB-NRPARCEL: ' V0MCOB-NRPARCEL */
                _.Display($"V0MCOB-NRPARCEL: {V0MCOB_NRPARCEL}");

                /*" -2943- DISPLAY 'V0MCOB-VALTIT  : ' V0MCOB-VALTIT */
                _.Display($"V0MCOB-VALTIT  : {V0MCOB_VALTIT}");

                /*" -2944- DISPLAY 'V0MCOB-VLIOCC  : ' V0MCOB-VLIOCC */
                _.Display($"V0MCOB-VLIOCC  : {V0MCOB_VLIOCC}");

                /*" -2945- DISPLAY 'V0MCOB-VALCDT  : ' V0MCOB-VALCDT */
                _.Display($"V0MCOB-VALCDT  : {V0MCOB_VALCDT}");

                /*" -2946- DISPLAY 'V0MCOB-SITUACAO: ' V0MCOB-SITUACAO */
                _.Display($"V0MCOB-SITUACAO: {V0MCOB_SITUACAO}");

                /*" -2947- DISPLAY 'V0MCOB-NOME    : ' V0MCOB-NOME */
                _.Display($"V0MCOB-NOME    : {V0MCOB_NOME}");

                /*" -2948- DISPLAY 'V0MCOB-TIPOMOV : ' V0MCOB-TIPOMOV */
                _.Display($"V0MCOB-TIPOMOV : {V0MCOB_TIPOMOV}");

                /*" -2949- DISPLAY 'V0MCOB-NN      : ' V0MCOB-NUM-NOSSO-TITULO */
                _.Display($"V0MCOB-NN      : {V0MCOB_NUM_NOSSO_TITULO}");

                /*" -2951- MOVE 'R2690-00 - PROBLEMAS INSERT (V0MOVICOB)' TO W-MENSAGEM-ERRO */
                _.Move("R2690-00 - PROBLEMAS INSERT (V0MOVICOB)", W_MENSAGEM_ERRO);

                /*" -2952- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2952- END-IF. */
            }


        }

        [StopWatch]
        /*" R2690-INCLUI-V0MOVICOB-DB-INSERT-1 */
        public void R2690_INCLUI_V0MOVICOB_DB_INSERT_1()
        {
            /*" -2926- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , :V0MCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1 = new R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1()
            {
                V0MCOB_CODEMP = V0MCOB_CODEMP.ToString(),
                V0MCOB_CODMOV = V0MCOB_CODMOV.ToString(),
                V0MCOB_BANCO = V0MCOB_BANCO.ToString(),
                V0MCOB_AGENCIA = V0MCOB_AGENCIA.ToString(),
                V0MCOB_NRAVISO = V0MCOB_NRAVISO.ToString(),
                V0MCOB_NUMFITA = V0MCOB_NUMFITA.ToString(),
                V0MCOB_DTMOVTO = V0MCOB_DTMOVTO.ToString(),
                V0MCOB_DTQITBCO = V0MCOB_DTQITBCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
                V0MCOB_NUMAPOL = V0MCOB_NUMAPOL.ToString(),
                V0MCOB_NRENDOS = V0MCOB_NRENDOS.ToString(),
                V0MCOB_NRPARCEL = V0MCOB_NRPARCEL.ToString(),
                V0MCOB_VALTIT = V0MCOB_VALTIT.ToString(),
                V0MCOB_VLIOCC = V0MCOB_VLIOCC.ToString(),
                V0MCOB_VALCDT = V0MCOB_VALCDT.ToString(),
                V0MCOB_SITUACAO = V0MCOB_SITUACAO.ToString(),
                V0MCOB_NOME = V0MCOB_NOME.ToString(),
                V0MCOB_TIPOMOV = V0MCOB_TIPOMOV.ToString(),
                V0MCOB_NUM_NOSSO_TITULO = V0MCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1.Execute(r2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2690_INCLUI_V0MOVICOB_EXIT*/

        [StopWatch]
        /*" R2700-TRATA-RESSARCIMENTO-SECTION */
        private void R2700_TRATA_RESSARCIMENTO_SECTION()
        {
            /*" -2958- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -2960- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R2700-TRATA-RESSARCIMENTO' */

                $"{W_PROGRAMA_CHAMADOR}-R2700-TRATA-RESSARCIMENTO"
                .Display();

                /*" -2964- END-IF */
            }


            /*" -2966- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -2973- MOVE SPACES TO V0FOLL-CDERRO01 V0FOLL-CDERRO02 V0FOLL-CDERRO03 V0FOLL-CDERRO04 V0FOLL-CDERRO05 V0FOLL-CDERRO06. */
            _.Move("", V0FOLL_CDERRO01, V0FOLL_CDERRO02, V0FOLL_CDERRO03, V0FOLL_CDERRO04, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -2975- PERFORM R2710-SELECT-V0MESTSINI. */

            R2710_SELECT_V0MESTSINI_SECTION();

            /*" -2977- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -2978- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -2979- MOVE COBRAN-COD-MOVIMENTO TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_COD_MOVIMENTO, V0MCOB_CODMOV);

            /*" -2980- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -2981- MOVE WWORK-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(WWORK_NRAVISO, V0MCOB_NRAVISO);

            /*" -2982- MOVE WWORK-AVS-AGE TO WWORK-AGEAVISO */
            _.Move(FILLER_58.WWORK_AVS_AGE, WWORK_AGEAVISO);

            /*" -2983- MOVE 7 TO WWORK-TIP-AGE */
            _.Move(7, FILLER_57.WWORK_TIP_AGE);

            /*" -2985- MOVE WWORK-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(WWORK_AGEAVISO, V0MCOB_AGENCIA);

            /*" -2986- MOVE COBRAN-NSAC TO V0MCOB-NUMFITA */
            _.Move(COBRAN_REGISTRO.COBRAN_NSAC, V0MCOB_NUMFITA);

            /*" -2987- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -2989- MOVE ZEROS TO V0MCOB-NRTIT */
            _.Move(0, V0MCOB_NRTIT);

            /*" -2992- IF (COBRAN-COD-CEDENTE-N EQUAL 696005 OR = CVPCV-696005 OR = JV1CV-696005 ) */

            if ((COBRAN_REGISTRO.COBRAN_CEDENTE_R.FILLER_68.COBRAN_COD_CEDENTE_N.In("696005", JVBKINCL.JV_CONVENIOS.CVPCV_696005.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_696005.ToString())))
            {

                /*" -2993- MOVE COBRAN-NUM-TITULO TO WS-NUMERO-TITULO */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_AVISO.WS_NUMERO_TITULO);

                /*" -2994- MOVE WS-NRO-TIT TO V0MCOB-NRTIT */
                _.Move(WS_AUX_AVISO.FILLER_40.WS_NRO_TIT, V0MCOB_NRTIT);

                /*" -2996- END-IF. */
            }


            /*" -2997- MOVE COBRAN-VLR-PAGO TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0MCOB_VALTIT);

            /*" -2998- MOVE COBRAN-VLR-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, V0MCOB_VLIOCC);

            /*" -3000- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -3003- COMPUTE V0MCOB-VALCDT = COBRAN-VLR-PAGO - COBRAN-VLR-IOF - COBRAN-VLR-DESCONTO - COBRAN-VLR-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PAGO - COBRAN_REGISTRO.COBRAN_VLR_IOF - COBRAN_REGISTRO.COBRAN_VLR_DESCONTO - COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO;

            /*" -3004- MOVE V0MSIN-NUM-APOL-SINISTRO TO V0MCOB-NUMAPOL */
            _.Move(V0MSIN_NUM_APOL_SINISTRO, V0MCOB_NUMAPOL);

            /*" -3005- MOVE AUX-NRENDOS TO V0MCOB-NRENDOS */
            _.Move(WS_AUX_ARQUIVO.AUX_NRENDOS, V0MCOB_NRENDOS);

            /*" -3006- MOVE AUX-NRO-PARC TO V0MCOB-NRPARCEL */
            _.Move(WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC, V0MCOB_NRPARCEL);

            /*" -3007- MOVE AUX-NOME TO V0MCOB-NOME */
            _.Move(WS_AUX_ARQUIVO.AUX_NOME, V0MCOB_NOME);

            /*" -3008- MOVE ' ' TO V0MCOB-SITUACAO */
            _.Move(" ", V0MCOB_SITUACAO);

            /*" -3010- MOVE '7' TO V0MCOB-TIPOMOV. */
            _.Move("7", V0MCOB_TIPOMOV);

            /*" -3011- MOVE COBRAN-DTA-PAGAMENTO TO WDATA-SECULO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_PAGAMENTO, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3012- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3013- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3014- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3015- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3017- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -3018- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -3021- MOVE V0MSIN-NUM-NOSSO-TITULO TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(V0MSIN_NUM_NOSSO_TITULO, V0MCOB_NUM_NOSSO_TITULO);

            /*" -3023- IF (V0FOLL-CDERRO01 NOT EQUAL SPACES) OR (V0FOLL-CDERRO02 NOT EQUAL SPACES) */

            if ((!V0FOLL_CDERRO01.IsEmpty()) || (!V0FOLL_CDERRO02.IsEmpty()))
            {

                /*" -3025- MOVE '2' TO V0MCOB-SITUACAO WSHOST-SITUACAO */
                _.Move("2", V0MCOB_SITUACAO, WSHOST_SITUACAO);

                /*" -3027- MOVE ZEROS TO AC-DUPLICA V0FOLL-NRRCAP */
                _.Move(0, WS_AUX_ARQUIVO.AC_DUPLICA, V0FOLL_NRRCAP);

                /*" -3028- PERFORM R4000-MONTA-V0FOLLOWUP */

                R4000_MONTA_V0FOLLOWUP_SECTION();

                /*" -3029- PERFORM R4100-INCLUI-V0FOLLOWUP */

                R4100_INCLUI_V0FOLLOWUP_SECTION();

                /*" -3031- END-IF. */
            }


            /*" -3033- PERFORM R2690-INCLUI-V0MOVICOB. */

            R2690_INCLUI_V0MOVICOB_SECTION();

            /*" -3035- MOVE COBRAN-REGISTRO TO REG-PF2002B1 */
            _.Move(COBRAN_REGISTRO, REG_PF2002B1);

            /*" -3037- WRITE REG-PF2002B1. */
            PF2002B1.Write(REG_PF2002B1.GetMoveValues().ToString());

            /*" -3037- ADD 1 TO IN-COBRANCA. */
            WS_AUX_ARQUIVO.IN_COBRANCA.Value = WS_AUX_ARQUIVO.IN_COBRANCA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_TRATA_RESSARCIMENTO_EXIT*/

        [StopWatch]
        /*" R2710-SELECT-V0MESTSINI-SECTION */
        private void R2710_SELECT_V0MESTSINI_SECTION()
        {
            /*" -3046- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3047- DISPLAY W-PROGRAMA-CHAMADOR '-R2710-SELECT-V0MESTSINI' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2710-SELECT-V0MESTSINI");

                /*" -3051- END-IF */
            }


            /*" -3053- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WABEND.WNR_EXEC_SQL);

            /*" -3054- MOVE COBRAN-NN-REGISTRADO TO SI111-NUM-TITULO-SIGCB */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB);

            /*" -3056- MOVE COBRAN-NUM-PROPOSTA TO SI111-NUM-APOL-SINISTRO */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);

            /*" -3060- MOVE ZEROS TO AUX-NRENDOS AUX-NRO-PARC V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(0, WS_AUX_ARQUIVO.AUX_NRENDOS, WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC, V0MSIN_NUM_APOL_SINISTRO);

            /*" -3062- MOVE SPACES TO AUX-DESCRICAO. */
            _.Move("", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

            /*" -3068- INITIALIZE V0MSIN-CODPRODU V0MSIN-NUM-APOL-SINISTRO V0MSIN-ACORDO V0MSIN-NRPARCEL V0MSIN-NUM-NOSSO-TITULO */
            _.Initialize(
                V0MSIN_CODPRODU
                , V0MSIN_NUM_APOL_SINISTRO
                , V0MSIN_ACORDO
                , V0MSIN_NRPARCEL
                , V0MSIN_NUM_NOSSO_TITULO
            );

            /*" -3086- PERFORM R2710_SELECT_V0MESTSINI_DB_SELECT_1 */

            R2710_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -3089- IF (SQLCODE EQUAL -911 OR -913) */

            if ((DB.SQLCODE.In("-911", "-913")))
            {

                /*" -3090- DISPLAY 'R2710 - PROBLEMAS COM DEADLOCK OU TIMEOUT' */
                _.Display($"R2710 - PROBLEMAS COM DEADLOCK OU TIMEOUT");

                /*" -3091- DISPLAY ' NUM_APOL_SINISTRO=' SI111-NUM-APOL-SINISTRO */
                _.Display($" NUM_APOL_SINISTRO={SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -3092- DISPLAY ' NUM_TITULO_SIGCB=' SI111-NUM-TITULO-SIGCB */
                _.Display($" NUM_TITULO_SIGCB={SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB}");

                /*" -3094- MOVE 'R2710 - PROBLEMAS COM DEADLOCK OU TIMEOUT' TO W-MENSAGEM-ERRO */
                _.Move("R2710 - PROBLEMAS COM DEADLOCK OU TIMEOUT", W_MENSAGEM_ERRO);

                /*" -3095- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3097- END-IF */
            }


            /*" -3098- IF SQLCODE NOT = 000 AND -811 AND +100 */

            if (!DB.SQLCODE.In("000", "-811", "+100"))
            {

                /*" -3099- DISPLAY 'R2710 - PROBLEMAS NO SELECT(MESTSINI)' */
                _.Display($"R2710 - PROBLEMAS NO SELECT(MESTSINI)");

                /*" -3100- DISPLAY ' NUM_APOL_SINISTRO=' SI111-NUM-APOL-SINISTRO */
                _.Display($" NUM_APOL_SINISTRO={SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -3101- DISPLAY ' NUM_TITULO_SIGCB=' SI111-NUM-TITULO-SIGCB */
                _.Display($" NUM_TITULO_SIGCB={SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB}");

                /*" -3103- MOVE 'R2710 - PROBLEMAS NO SELECT(MESTSINI)' TO W-MENSAGEM-ERRO */
                _.Move("R2710 - PROBLEMAS NO SELECT(MESTSINI)", W_MENSAGEM_ERRO);

                /*" -3104- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3106- END-IF. */
            }


            /*" -3107- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -3108- MOVE V0MSIN-ACORDO TO AUX-NRENDOS */
                _.Move(V0MSIN_ACORDO, WS_AUX_ARQUIVO.AUX_NRENDOS);

                /*" -3109- MOVE V0MSIN-NRPARCEL TO AUX-NRO-PARC */
                _.Move(V0MSIN_NRPARCEL, WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC);

                /*" -3110- MOVE V0MSIN-CODPRODU TO WSHOST-CODPRODU */
                _.Move(V0MSIN_CODPRODU, WSHOST_CODPRODU);

                /*" -3111- GO TO R2710-SELECT-V0MESTSINI-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_SELECT_V0MESTSINI_EXIT*/ //GOTO
                return;

                /*" -3112- END-IF. */
            }


            /*" -3114- MOVE COBRAN-NUM-PROPOSTA TO V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, V0MSIN_NUM_APOL_SINISTRO);

            /*" -3118- MOVE ZEROS TO WSHOST-CODPRODU AUX-NRENDOS AUX-NRO-PARC. */
            _.Move(0, WSHOST_CODPRODU, WS_AUX_ARQUIVO.AUX_NRENDOS, WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC);

            /*" -3119- IF (SQLCODE EQUAL -811) */

            if ((DB.SQLCODE == -811))
            {

                /*" -3120- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -3121- MOVE 'TITULO DUPLICADO RESSARC. ' TO AUX-DESCRICAO */
                _.Move("TITULO DUPLICADO RESSARC. ", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                /*" -3123- END-IF */
            }


            /*" -3124- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -3125- PERFORM R2720-SELECT-V0MESTSINI */

                R2720_SELECT_V0MESTSINI_SECTION();

                /*" -3126- GO TO R2710-SELECT-V0MESTSINI-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_SELECT_V0MESTSINI_EXIT*/ //GOTO
                return;

                /*" -3127- END-IF */
            }


            /*" -3127- . */

        }

        [StopWatch]
        /*" R2710-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R2710_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -3086- EXEC SQL SELECT M.COD_PRODUTO , M.NUM_APOL_SINISTRO , P.NUM_RESSARC , P.NUM_PARCELA , P.NUM_NOSSO_TITULO INTO :V0MSIN-CODPRODU , :V0MSIN-NUM-APOL-SINISTRO , :V0MSIN-ACORDO , :V0MSIN-NRPARCEL , :V0MSIN-NUM-NOSSO-TITULO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND P.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND P.COD_OPERACAO = 4000 AND P.NUM_TITULO_SIGCB = :SI111-NUM-TITULO-SIGCB WITH UR END-EXEC. */

            var r2710_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R2710_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_NUM_TITULO_SIGCB = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB.ToString(),
            };

            var executed_1 = R2710_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r2710_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_CODPRODU, V0MSIN_CODPRODU);
                _.Move(executed_1.V0MSIN_NUM_APOL_SINISTRO, V0MSIN_NUM_APOL_SINISTRO);
                _.Move(executed_1.V0MSIN_ACORDO, V0MSIN_ACORDO);
                _.Move(executed_1.V0MSIN_NRPARCEL, V0MSIN_NRPARCEL);
                _.Move(executed_1.V0MSIN_NUM_NOSSO_TITULO, V0MSIN_NUM_NOSSO_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_SELECT_V0MESTSINI_EXIT*/

        [StopWatch]
        /*" R2720-SELECT-V0MESTSINI-SECTION */
        private void R2720_SELECT_V0MESTSINI_SECTION()
        {
            /*" -3135- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3136- DISPLAY W-PROGRAMA-CHAMADOR '-R2720-SELECT-V0MESTSINI' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2720-SELECT-V0MESTSINI");

                /*" -3140- END-IF */
            }


            /*" -3142- MOVE '2720' TO WNR-EXEC-SQL. */
            _.Move("2720", WABEND.WNR_EXEC_SQL);

            /*" -3143- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -3145- MOVE WS-NN-REG-16P TO SI111-NUM-NOSSO-TITULO */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.WS_NN_REG_16P, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);

            /*" -3151- INITIALIZE V0MSIN-CODPRODU V0MSIN-NUM-APOL-SINISTRO V0MSIN-ACORDO V0MSIN-NRPARCEL V0MSIN-NUM-NOSSO-TITULO */
            _.Initialize(
                V0MSIN_CODPRODU
                , V0MSIN_NUM_APOL_SINISTRO
                , V0MSIN_ACORDO
                , V0MSIN_NRPARCEL
                , V0MSIN_NUM_NOSSO_TITULO
            );

            /*" -3168- PERFORM R2720_SELECT_V0MESTSINI_DB_SELECT_1 */

            R2720_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -3171- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -3172- MOVE V0MSIN-ACORDO TO AUX-NRENDOS */
                _.Move(V0MSIN_ACORDO, WS_AUX_ARQUIVO.AUX_NRENDOS);

                /*" -3173- MOVE V0MSIN-NRPARCEL TO AUX-NRO-PARC */
                _.Move(V0MSIN_NRPARCEL, WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC);

                /*" -3174- MOVE V0MSIN-CODPRODU TO WSHOST-CODPRODU */
                _.Move(V0MSIN_CODPRODU, WSHOST_CODPRODU);

                /*" -3175- GO TO R2720-SELECT-V0MESTSINI-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_SELECT_V0MESTSINI_EXIT*/ //GOTO
                return;

                /*" -3176- END-IF. */
            }


            /*" -3178- MOVE COBRAN-NUM-PROPOSTA TO V0MSIN-NUM-APOL-SINISTRO. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, V0MSIN_NUM_APOL_SINISTRO);

            /*" -3181- MOVE ZEROS TO WSHOST-CODPRODU AUX-NRENDOS AUX-NRO-PARC. */
            _.Move(0, WSHOST_CODPRODU, WS_AUX_ARQUIVO.AUX_NRENDOS, WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC);

            /*" -3182- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -3183- MOVE '1' TO V0FOLL-CDERRO01 */
                _.Move("1", V0FOLL_CDERRO01);

                /*" -3185- MOVE 'T�TULO N�O CADASTRADO COMO RESSARCIMENTO' TO AUX-DESCRICAO */
                _.Move("T�TULO N�O CADASTRADO COMO RESSARCIMENTO", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                /*" -3187- END-IF. */
            }


            /*" -3188- IF (SQLCODE NOT EQUAL +100 AND -811) */

            if ((!DB.SQLCODE.In("+100", "-811")))
            {

                /*" -3189- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -3190- MOVE 'OUTRAS DIVERGENCIAS RESSARC.' TO AUX-DESCRICAO */
                _.Move("OUTRAS DIVERGENCIAS RESSARC.", WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO);

                /*" -3191- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3191- END-IF. */
            }


        }

        [StopWatch]
        /*" R2720-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R2720_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -3168- EXEC SQL SELECT M.COD_PRODUTO , M.NUM_APOL_SINISTRO , P.NUM_RESSARC , P.NUM_PARCELA , P.NUM_NOSSO_TITULO INTO :V0MSIN-CODPRODU , :V0MSIN-NUM-APOL-SINISTRO , :V0MSIN-ACORDO , :V0MSIN-NRPARCEL , :V0MSIN-NUM-NOSSO-TITULO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_NOSSO_TITULO = :SI111-NUM-NOSSO-TITULO AND P.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND P.COD_OPERACAO = 4000 WITH UR END-EXEC. */

            var r2720_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R2720_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                SI111_NUM_NOSSO_TITULO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R2720_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r2720_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_CODPRODU, V0MSIN_CODPRODU);
                _.Move(executed_1.V0MSIN_NUM_APOL_SINISTRO, V0MSIN_NUM_APOL_SINISTRO);
                _.Move(executed_1.V0MSIN_ACORDO, V0MSIN_ACORDO);
                _.Move(executed_1.V0MSIN_NRPARCEL, V0MSIN_NRPARCEL);
                _.Move(executed_1.V0MSIN_NUM_NOSSO_TITULO, V0MSIN_NUM_NOSSO_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_SELECT_V0MESTSINI_EXIT*/

        [StopWatch]
        /*" R2800-LER-CONVERSAO-SECTION */
        private void R2800_LER_CONVERSAO_SECTION()
        {
            /*" -3198- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3199- DISPLAY W-PROGRAMA-CHAMADOR '-R2800-LER-CONVERSAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2800-LER-CONVERSAO");

                /*" -3203- END-IF */
            }


            /*" -3204- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -3205- MOVE ZEROS TO CONVEN-CODPRODU. */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_CODPRODU);

            /*" -3210- MOVE COBRAN-PROD-SIVPF TO V0PRPF-CODSIVPF. */
            _.Move(COBRAN_REGISTRO.COBRAN_PROD_SIVPF, V0PRPF_CODSIVPF);

            /*" -3212- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -3213- SEARCH WPROD-OCORREPRD */
            for (; WS_PRD < WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -3214- WHEN V0PRPF-CODSIVPF EQUAL WPROD-PRDSIVPF(WS-PRD) */

                if (V0PRPF_CODSIVPF == WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF)
                {


                    /*" -3216- MOVE WPROD-CODPRODU(WS-PRD) TO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -3216- END-SEARCH. */
                    break;
                }
            }


            /*" -3223- IF (V0PRPF-CODSIVPF EQUAL 33 OR 34 OR 36 OR 38 OR 42 OR 44 OR 45) */

            if ((V0PRPF_CODSIVPF.In("33", "34", "36", "38", "42", "44", "45")))
            {

                /*" -3225- MOVE COBRAN-NUM-TITULO TO PROPOAUT-NUM-PROPOSTA-CONV */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV);

                /*" -3227- PERFORM R7050-SELECT-PROPOSTA */

                R7050_SELECT_PROPOSTA_SECTION();

                /*" -3228- IF WTEM-PROPOSTA EQUAL 'SIM' */

                if (WS_AUX_ARQUIVO.WTEM_PROPOSTA == "SIM")
                {

                    /*" -3230- MOVE PROPOSTA-COD-PRODUTO TO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -3231- ELSE */
                }
                else
                {


                    /*" -3232- EVALUATE V0PRPF-CODSIVPF */
                    switch (V0PRPF_CODSIVPF.Value)
                    {

                        /*" -3233- WHEN 33 */
                        case 33:

                            /*" -3235- MOVE 3173 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3173, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3236- WHEN 34 */
                            break;
                        case 34:

                            /*" -3238- MOVE 3172 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3172, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3239- WHEN 36 */
                            break;
                        case 36:

                            /*" -3241- MOVE 3174 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3174, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3242- WHEN 38 */
                            break;
                        case 38:

                            /*" -3244- MOVE 3175 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3175, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3245- WHEN 42 */
                            break;
                        case 42:

                            /*" -3247- MOVE 3176 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3176, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3248- WHEN 44 */
                            break;
                        case 44:

                            /*" -3250- MOVE 3180 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3180, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3251- WHEN 45 */
                            break;
                        case 45:

                            /*" -3253- MOVE 3181 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(3181, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3254- END-EVALUATE */
                            break;
                    }


                    /*" -3255- END-IF */
                }


                /*" -3257- END-IF. */
            }


            /*" -3258- IF (CONVEN-CODPRODU EQUAL 8201) */

            if ((WS_AUX_ARQUIVO.CONVEN_CODPRODU == 8201))
            {

                /*" -3260- MOVE 8202 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(8202, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -3261- END-IF */
            }


            /*" -3262- IF (CONVEN-CODPRODU EQUAL 7106 OR 7108) */

            if ((WS_AUX_ARQUIVO.CONVEN_CODPRODU.In("7106", "7108")))
            {

                /*" -3264- MOVE 1402 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(1402, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -3270- END-IF */
            }


            /*" -3271- IF (V0PRPF-CODSIVPF EQUAL 11 OR 16) */

            if ((V0PRPF_CODSIVPF.In("11", "16")))
            {

                /*" -3272- ADD 1 TO TT-OPCAO */
                WS_AUX_ARQUIVO.TT_OPCAO.Value = WS_AUX_ARQUIVO.TT_OPCAO + 1;

                /*" -3273- MOVE COBRAN-NUM-TITULO TO OPCPAGVI-NUM-CERTIFICADO */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

                /*" -3274- PERFORM R2850-SELECT-OPCPAGVI */

                R2850_SELECT_OPCPAGVI_SECTION();

                /*" -3280- END-IF. */
            }


            /*" -3282- IF (AUX-CANAL EQUAL 2) AND (V0PRPF-CODSIVPF NOT EQUAL 48) */

            if ((WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL == 2) && (V0PRPF_CODSIVPF != 48))
            {

                /*" -3284- MOVE COBRAN-NUM-TITULO(2:4) TO V0FILT-CODSIVPF WSHOST-CODPRODU */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO.Substring(2, 4), V0FILT_CODSIVPF, WSHOST_CODPRODU);

                /*" -3286- END-IF. */
            }


            /*" -3288- MOVE COBRAN-NUM-TITULO TO V0FILT-NUMSIVPF */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, V0FILT_NUMSIVPF);

            /*" -3288- PERFORM R2900-SELECT-CONVERSAO. */

            R2900_SELECT_CONVERSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_LER_CONVERSAO_EXIT*/

        [StopWatch]
        /*" R2850-SELECT-OPCPAGVI-SECTION */
        private void R2850_SELECT_OPCPAGVI_SECTION()
        {
            /*" -3297- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3298- DISPLAY W-PROGRAMA-CHAMADOR '-R2850-SELECT-OPCPAGVI' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2850-SELECT-OPCPAGVI");

                /*" -3302- END-IF */
            }


            /*" -3304- MOVE '2850' TO WNR-EXEC-SQL. */
            _.Move("2850", WABEND.WNR_EXEC_SQL);

            /*" -3306- INITIALIZE OPCPAGVI-PERI-PAGAMENTO */
            _.Initialize(
                OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO
            );

            /*" -3313- PERFORM R2850_SELECT_OPCPAGVI_DB_SELECT_1 */

            R2850_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -3316- IF (SQLCODE EQUAL -911 OR -913) */

            if ((DB.SQLCODE.In("-911", "-913")))
            {

                /*" -3317- DISPLAY 'R2850-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' */
                _.Display($"R2850-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT");

                /*" -3319- MOVE 'R2850-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' TO W-MENSAGEM-ERRO */
                _.Move("R2850-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT", W_MENSAGEM_ERRO);

                /*" -3320- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3322- END-IF. */
            }


            /*" -3323- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -3324- DISPLAY 'R2850-00 - PROBLEMAS NO SELECT(OPCAOVID)' */
                _.Display($"R2850-00 - PROBLEMAS NO SELECT(OPCAOVID)");

                /*" -3326- MOVE 'R2850-00 - PROBLEMAS NO SELECT(OPCAOVID)' TO W-MENSAGEM-ERRO */
                _.Move("R2850-00 - PROBLEMAS NO SELECT(OPCAOVID)", W_MENSAGEM_ERRO);

                /*" -3327- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3329- END-IF. */
            }


            /*" -3330- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3331- ADD 1 TO DP-OPCAO */
                WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                /*" -3332- ELSE */
            }
            else
            {


                /*" -3333- IF (V0PRPF-CODSIVPF EQUAL 11) */

                if ((V0PRPF_CODSIVPF == 11))
                {

                    /*" -3334- IF (OPCPAGVI-PERI-PAGAMENTO EQUAL 01) */

                    if ((OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 01))
                    {

                        /*" -3336- MOVE 9318 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                        _.Move(9318, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                        /*" -3337- ELSE */
                    }
                    else
                    {


                        /*" -3338- IF (OPCPAGVI-PERI-PAGAMENTO EQUAL 12) */

                        if ((OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12))
                        {

                            /*" -3340- MOVE 9319 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(9319, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3341- ELSE */
                        }
                        else
                        {


                            /*" -3342- ADD 1 TO DP-OPCAO */
                            WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                            /*" -3343- END-IF */
                        }


                        /*" -3344- END-IF */
                    }


                    /*" -3345- ELSE */
                }
                else
                {


                    /*" -3346- IF (V0PRPF-CODSIVPF EQUAL 16) */

                    if ((V0PRPF_CODSIVPF == 16))
                    {

                        /*" -3347- EVALUATE OPCPAGVI-PERI-PAGAMENTO */
                        switch (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO.Value)
                        {

                            /*" -3348- WHEN 01 */
                            case 01:

                                /*" -3350- MOVE 9322 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9322, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -3351- WHEN 02 */
                                break;
                            case 02:

                                /*" -3353- MOVE 9323 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9323, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -3354- WHEN 03 */
                                break;
                            case 03:

                                /*" -3356- MOVE 9324 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9324, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -3357- WHEN 06 */
                                break;
                            case 06:

                                /*" -3359- MOVE 9325 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9325, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -3360- WHEN 12 */
                                break;
                            case 12:

                                /*" -3362- MOVE 9326 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9326, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -3363- WHEN OTHER */
                                break;
                            default:

                                /*" -3364- ADD 1 TO DP-OPCAO */
                                WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                                /*" -3365- END-EVALUATE */
                                break;
                        }


                        /*" -3366- END-IF */
                    }


                    /*" -3367- END-IF */
                }


                /*" -3367- END-IF. */
            }


        }

        [StopWatch]
        /*" R2850-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R2850_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -3313- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r2850_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R2850_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2850_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r2850_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_SELECT_OPCPAGVI_EXIT*/

        [StopWatch]
        /*" R2900-SELECT-CONVERSAO-SECTION */
        private void R2900_SELECT_CONVERSAO_SECTION()
        {
            /*" -3376- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3377- DISPLAY W-PROGRAMA-CHAMADOR '-R2900-SELECT-CONVERSAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2900-SELECT-CONVERSAO");

                /*" -3380- END-IF */
            }


            /*" -3382- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -3388- INITIALIZE CONVSICOB-NR-SICOB CONVSICOB-AGEPGTO CONVSICOB-DTQITBCO CONVSICOB-VAL-RCAP CONVSICOB-COD-USUARIO */
            _.Initialize(
                CONVSICOB_NR_SICOB
                , CONVSICOB_AGEPGTO
                , CONVSICOB_DTQITBCO
                , CONVSICOB_VAL_RCAP
                , CONVSICOB_COD_USUARIO
            );

            /*" -3402- PERFORM R2900_SELECT_CONVERSAO_DB_SELECT_1 */

            R2900_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -3405- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -3406- MOVE 1 TO V0FILT-COUNT */
                _.Move(1, V0FILT_COUNT);

                /*" -3407- ELSE */
            }
            else
            {


                /*" -3408- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3409- MOVE ZEROS TO V0FILT-COUNT */
                    _.Move(0, V0FILT_COUNT);

                    /*" -3410- ELSE */
                }
                else
                {


                    /*" -3412- DISPLAY 'R2900-00-PROBLEMAS SELECT(CONVERSAO). ' 'NUMSIVPF=' V0FILT-NUMSIVPF */

                    $"R2900-00-PROBLEMAS SELECT(CONVERSAO). NUMSIVPF={V0FILT_NUMSIVPF}"
                    .Display();

                    /*" -3414- MOVE 'R2900-00-PROBLEMAS SELECT(CONVERSAO)  ' TO W-MENSAGEM-ERRO */
                    _.Move("R2900-00-PROBLEMAS SELECT(CONVERSAO)  ", W_MENSAGEM_ERRO);

                    /*" -3415- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3416- END-IF */
                }


                /*" -3416- END-IF. */
            }


        }

        [StopWatch]
        /*" R2900-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R2900_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -3402- EXEC SQL SELECT NUM_SICOB, AGEPGTO, DATA_QUITACAO, VAL_RCAP, COD_USUARIO INTO :CONVSICOB-NR-SICOB, :CONVSICOB-AGEPGTO, :CONVSICOB-DTQITBCO, :CONVSICOB-VAL-RCAP, :CONVSICOB-COD-USUARIO FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF WITH UR END-EXEC. */

            var r2900_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R2900_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            var executed_1 = R2900_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r2900_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVSICOB_NR_SICOB, CONVSICOB_NR_SICOB);
                _.Move(executed_1.CONVSICOB_AGEPGTO, CONVSICOB_AGEPGTO);
                _.Move(executed_1.CONVSICOB_DTQITBCO, CONVSICOB_DTQITBCO);
                _.Move(executed_1.CONVSICOB_VAL_RCAP, CONVSICOB_VAL_RCAP);
                _.Move(executed_1.CONVSICOB_COD_USUARIO, CONVSICOB_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_SELECT_CONVERSAO_EXIT*/

        [StopWatch]
        /*" R2901-SELECT-CONVERSAO2-SECTION */
        private void R2901_SELECT_CONVERSAO2_SECTION()
        {
            /*" -3425- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3426- DISPLAY W-PROGRAMA-CHAMADOR '-R2901-SELECT-CONVERSAO2' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R2901-SELECT-CONVERSAO2");

                /*" -3429- END-IF */
            }


            /*" -3431- MOVE '2901' TO WNR-EXEC-SQL. */
            _.Move("2901", WABEND.WNR_EXEC_SQL);

            /*" -3438- INITIALIZE CONVSICOB-NR-SICOB CONVSICOB-AGEPGTO CONVSICOB-DTQITBCO CONVSICOB-VAL-RCAP CONVSICOB-COD-USUARIO CONVSICOB-NUM-PROP-SIVPF */
            _.Initialize(
                CONVSICOB_NR_SICOB
                , CONVSICOB_AGEPGTO
                , CONVSICOB_DTQITBCO
                , CONVSICOB_VAL_RCAP
                , CONVSICOB_COD_USUARIO
                , CONVSICOB_NUM_PROP_SIVPF
            );

            /*" -3454- PERFORM R2901_SELECT_CONVERSAO2_DB_SELECT_1 */

            R2901_SELECT_CONVERSAO2_DB_SELECT_1();

            /*" -3457- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -3458- MOVE 1 TO V0FILT-COUNT2 */
                _.Move(1, V0FILT_COUNT2);

                /*" -3459- ELSE */
            }
            else
            {


                /*" -3460- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3461- MOVE ZEROS TO V0FILT-COUNT2 */
                    _.Move(0, V0FILT_COUNT2);

                    /*" -3462- ELSE */
                }
                else
                {


                    /*" -3464- DISPLAY 'R2901-00-PROBLEMAS SELECT(CONVERSAO)2 ' 'NUMSIVPF=' V0FILT-NUMSIVPF */

                    $"R2901-00-PROBLEMAS SELECT(CONVERSAO)2 NUMSIVPF={V0FILT_NUMSIVPF}"
                    .Display();

                    /*" -3466- MOVE 'R2901-00-PROBLEMAS SELECT(CONVERSAO)2 ' TO W-MENSAGEM-ERRO */
                    _.Move("R2901-00-PROBLEMAS SELECT(CONVERSAO)2 ", W_MENSAGEM_ERRO);

                    /*" -3467- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3468- END-IF */
                }


                /*" -3468- END-IF. */
            }


        }

        [StopWatch]
        /*" R2901-SELECT-CONVERSAO2-DB-SELECT-1 */
        public void R2901_SELECT_CONVERSAO2_DB_SELECT_1()
        {
            /*" -3454- EXEC SQL SELECT NUM_SICOB, AGEPGTO, DATA_QUITACAO, VAL_RCAP, COD_USUARIO, NUM_PROPOSTA_SIVPF INTO :CONVSICOB-NR-SICOB, :CONVSICOB-AGEPGTO, :CONVSICOB-DTQITBCO, :CONVSICOB-VAL-RCAP, :CONVSICOB-COD-USUARIO, :CONVSICOB-NUM-PROP-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB= :V0FILT-NUMSICOB WITH UR END-EXEC. */

            var r2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1 = new R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1()
            {
                V0FILT_NUMSICOB = V0FILT_NUMSICOB.ToString(),
            };

            var executed_1 = R2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1.Execute(r2901_SELECT_CONVERSAO2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVSICOB_NR_SICOB, CONVSICOB_NR_SICOB);
                _.Move(executed_1.CONVSICOB_AGEPGTO, CONVSICOB_AGEPGTO);
                _.Move(executed_1.CONVSICOB_DTQITBCO, CONVSICOB_DTQITBCO);
                _.Move(executed_1.CONVSICOB_VAL_RCAP, CONVSICOB_VAL_RCAP);
                _.Move(executed_1.CONVSICOB_COD_USUARIO, CONVSICOB_COD_USUARIO);
                _.Move(executed_1.CONVSICOB_NUM_PROP_SIVPF, CONVSICOB_NUM_PROP_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2901_SELECT_CONVERSAO2_EXIT*/

        [StopWatch]
        /*" R3100-CALCULA-TITULO-SECTION */
        private void R3100_CALCULA_TITULO_SECTION()
        {
            /*" -3476- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3477- DISPLAY W-PROGRAMA-CHAMADOR '-R3100-CALCULA-TITULO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3100-CALCULA-TITULO");

                /*" -3480- END-IF */
            }


            /*" -3482- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -3483- ADD 1 TO WWORK-MINNRO */
            WS_AUX_ARQUIVO.FILLER_13.WWORK_MINNRO.Value = WS_AUX_ARQUIVO.FILLER_13.WWORK_MINNRO + 1;

            /*" -3485- MOVE WWORK-MINNRO TO LPARM11. */
            _.Move(WS_AUX_ARQUIVO.FILLER_13.WWORK_MINNRO, LPARM11X.LPARM11);

            /*" -3496- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            WS_AUX_ARQUIVO.WPARM11_AUX.Value = LPARM11X.FILLER_72.LPARM11_1 * 3 + LPARM11X.FILLER_72.LPARM11_2 * 2 + LPARM11X.FILLER_72.LPARM11_3 * 9 + LPARM11X.FILLER_72.LPARM11_4 * 8 + LPARM11X.FILLER_72.LPARM11_5 * 7 + LPARM11X.FILLER_72.LPARM11_6 * 6 + LPARM11X.FILLER_72.LPARM11_7 * 5 + LPARM11X.FILLER_72.LPARM11_8 * 4 + LPARM11X.FILLER_72.LPARM11_9 * 3 + LPARM11X.FILLER_72.LPARM11_10 * 2;

            /*" -3499- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(WS_AUX_ARQUIVO.WPARM11_AUX, 11, WS_AUX_ARQUIVO.WS_RESULT, WS_AUX_ARQUIVO.WS_RESTO);

            /*" -3500- IF (WS-RESTO EQUAL ZEROS) */

            if ((WS_AUX_ARQUIVO.WS_RESTO == 00))
            {

                /*" -3501- MOVE ZEROS TO WWORK-MINDIG */
                _.Move(0, WS_AUX_ARQUIVO.FILLER_13.WWORK_MINDIG);

                /*" -3502- ELSE */
            }
            else
            {


                /*" -3503- SUBTRACT WS-RESTO FROM 11 GIVING WWORK-MINDIG */
                WS_AUX_ARQUIVO.FILLER_13.WWORK_MINDIG.Value = 11 - WS_AUX_ARQUIVO.WS_RESTO;

                /*" -3505- END-IF. */
            }


            /*" -3506- IF (WWORK-MIN-NRTIT > WWORK-MAX-NRTIT) */

            if ((WS_AUX_ARQUIVO.WWORK_MIN_NRTIT > WS_AUX_ARQUIVO.WWORK_MAX_NRTIT))
            {

                /*" -3507- DISPLAY '*- PF2002B - ABEND CONTROLADO -------------*' */
                _.Display($"*- PF2002B - ABEND CONTROLADO -------------*");

                /*" -3508- DISPLAY '*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    *' */
                _.Display($"*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    *");

                /*" -3509- DISPLAY '    ' WWORK-MIN-NRTIT */
                _.Display($"    {WS_AUX_ARQUIVO.WWORK_MIN_NRTIT}");

                /*" -3512- STRING 'R3100-ABEND CONTROLADO: ' 'ESTOURO FAIXA NUMERACAO CEDENTE = 26' DELIMITED BY SIZE INTO W-MENSAGEM-ERRO */
                #region STRING
                var spl1 = "R3100-ABEND CONTROLADO: " + "ESTOURO FAIXA NUMERACAO CEDENTE = 26";
                _.Move(spl1, W_MENSAGEM_ERRO);
                #endregion

                /*" -3513- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3513- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_CALCULA_TITULO_EXIT*/

        [StopWatch]
        /*" R3200-TRATA-DEMAIS-PARCELAS-SECTION */
        private void R3200_TRATA_DEMAIS_PARCELAS_SECTION()
        {
            /*" -3521- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3523- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R3200-TRATA-DEMAIS-PARCELAS' */

                $"{W_PROGRAMA_CHAMADOR}-R3200-TRATA-DEMAIS-PARCELAS"
                .Display();

                /*" -3524- DISPLAY 'COBRAN-IDLG       = ' COBRAN-IDLG */
                _.Display($"COBRAN-IDLG       = {COBRAN_REGISTRO.COBRAN_IDLG}");

                /*" -3525- DISPLAY 'COBRAN-NUM-TITULO = ' COBRAN-NUM-TITULO */
                _.Display($"COBRAN-NUM-TITULO = {COBRAN_REGISTRO.COBRAN_NUM_TITULO}");

                /*" -3529- END-IF */
            }


            /*" -3531- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -3533- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -3534- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -3535- MOVE COBRAN-COD-MOVIMENTO TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_COD_MOVIMENTO, V0MCOB_CODMOV);

            /*" -3537- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -3538- MOVE WWORK-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(WWORK_NRAVISO, V0MCOB_NRAVISO);

            /*" -3539- MOVE WWORK-AVS-AGE TO WWORK-AGEAVISO */
            _.Move(FILLER_58.WWORK_AVS_AGE, WWORK_AGEAVISO);

            /*" -3540- MOVE 7 TO WWORK-TIP-AGE */
            _.Move(7, FILLER_57.WWORK_TIP_AGE);

            /*" -3542- MOVE WWORK-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(WWORK_AGEAVISO, V0MCOB_AGENCIA);

            /*" -3543- MOVE COBRAN-NSAC TO V0MCOB-NUMFITA */
            _.Move(COBRAN_REGISTRO.COBRAN_NSAC, V0MCOB_NUMFITA);

            /*" -3544- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -3545- MOVE COBRAN-NUM-TITULO TO V0MCOB-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, V0MCOB_NRTIT);

            /*" -3546- MOVE COBRAN-VLR-PAGO TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0MCOB_VALTIT);

            /*" -3547- MOVE COBRAN-VLR-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, V0MCOB_VLIOCC);

            /*" -3549- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -3552- COMPUTE V0MCOB-VALCDT = COBRAN-VLR-PAGO - COBRAN-VLR-IOF - COBRAN-VLR-DESCONTO - COBRAN-VLR-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PAGO - COBRAN_REGISTRO.COBRAN_VLR_IOF - COBRAN_REGISTRO.COBRAN_VLR_DESCONTO - COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO;

            /*" -3553- MOVE ZEROS TO V0MCOB-NUMAPOL */
            _.Move(0, V0MCOB_NUMAPOL);

            /*" -3554- MOVE ZEROS TO V0MCOB-NRENDOS */
            _.Move(0, V0MCOB_NRENDOS);

            /*" -3555- MOVE COBRAN-NUM-PARCELA TO V0MCOB-NRPARCEL */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PARCELA, V0MCOB_NRPARCEL);

            /*" -3556- MOVE SPACES TO V0MCOB-NOME */
            _.Move("", V0MCOB_NOME);

            /*" -3557- MOVE SPACES TO V0MCOB-SITUACAO */
            _.Move("", V0MCOB_SITUACAO);

            /*" -3559- MOVE COBRAN-TIPO-MOVIMENTO TO V0MCOB-TIPOMOV. */
            _.Move(COBRAN_REGISTRO.COBRAN_TIPO_MOVIMENTO, V0MCOB_TIPOMOV);

            /*" -3560- MOVE COBRAN-DTA-PAGAMENTO TO WDATA-SECULO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_PAGAMENTO, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3561- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3562- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3563- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3564- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3566- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -3567- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -3570- MOVE WS-NN-REG-16P TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.WS_NN_REG_16P, V0MCOB_NUM_NOSSO_TITULO);

            /*" -3571- IF COBRAN-COD-CEDENTE = 696001 */

            if (COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001)
            {

                /*" -3572- MOVE COBRAN-NUM-PROPOSTA TO V0MCOB-NUM-NOSSO-TITULO */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, V0MCOB_NUM_NOSSO_TITULO);

                /*" -3574- MOVE WS-IDLG1-APO-NUM TO V0MCOB-NUMAPOL */
                _.Move(WS_AUX_AVISO.FILLER_44.FILLER_45.WS_IDLG1_APO_NUM, V0MCOB_NUMAPOL);

                /*" -3575- IF WS-IDLG1-APO-NUM-ID = 1 */

                if (WS_AUX_AVISO.FILLER_44.FILLER_45.FILLER_46.WS_IDLG1_APO_NUM_ID == 1)
                {

                    /*" -3577- IF WS-IDLG1-APO-PAR = 0 */

                    if (WS_AUX_AVISO.FILLER_44.FILLER_45.WS_IDLG1_APO_PAR == 0)
                    {

                        /*" -3578- IF WS-IDLG1-END-PAR-R3-P3 NUMERIC */

                        if (WS_AUX_AVISO.FILLER_44.FILLER_51.FILLER_52.WS_IDLG1_END_PAR_R3_P3.IsNumeric())
                        {

                            /*" -3580- MOVE WS-IDLG1-END-NUM-R3 TO V0MCOB-NRENDOS */
                            _.Move(WS_AUX_AVISO.FILLER_44.FILLER_51.WS_IDLG1_END_NUM_R3, V0MCOB_NRENDOS);

                            /*" -3581- ELSE */
                        }
                        else
                        {


                            /*" -3582- IF WS-IDLG1-END-PAR-P2 NUMERIC */

                            if (WS_AUX_AVISO.FILLER_44.FILLER_48.FILLER_49.WS_IDLG1_END_PAR_P2.IsNumeric())
                            {

                                /*" -3584- MOVE WS-IDLG1-END-NUM TO V0MCOB-NRENDOS */
                                _.Move(WS_AUX_AVISO.FILLER_44.FILLER_48.WS_IDLG1_END_NUM, V0MCOB_NRENDOS);

                                /*" -3585- ELSE */
                            }
                            else
                            {


                                /*" -3587- MOVE WS-IDLG1-END-NUM-R4 TO V0MCOB-NRENDOS */
                                _.Move(WS_AUX_AVISO.FILLER_44.FILLER_54.WS_IDLG1_END_NUM_R4, V0MCOB_NRENDOS);

                                /*" -3588- END-IF */
                            }


                            /*" -3589- END-IF */
                        }


                        /*" -3590- ELSE */
                    }
                    else
                    {


                        /*" -3591- MOVE 0 TO V0MCOB-NRENDOS */
                        _.Move(0, V0MCOB_NRENDOS);

                        /*" -3592- END-IF */
                    }


                    /*" -3594- END-IF */
                }


                /*" -3595- IF WS-IDLG2-EMP-SIST-TIPO = 'C000SIASONLINE' */

                if (WS_AUX_AVISO.FILLER_56.WS_IDLG2_EMP_SIST_TIPO == "C000SIASONLINE")
                {

                    /*" -3596- MOVE WS-IDLG2-NUM-APOLICE TO V0MCOB-NUMAPOL */
                    _.Move(WS_AUX_AVISO.FILLER_56.WS_IDLG2_NUM_APOLICE, V0MCOB_NUMAPOL);

                    /*" -3597- MOVE WS-IDLG2-NUM-ENDOSSO TO V0MCOB-NRENDOS */
                    _.Move(WS_AUX_AVISO.FILLER_56.WS_IDLG2_NUM_ENDOSSO, V0MCOB_NRENDOS);

                    /*" -3599- END-IF */
                }


                /*" -3601- END-IF */
            }


            /*" -3603- IF COBRAN-COD-CEDENTE-N EQUAL 695996 OR = CVPCV-695996 OR = JV1CV-695996 */

            if (COBRAN_REGISTRO.COBRAN_CEDENTE_R.FILLER_68.COBRAN_COD_CEDENTE_N.In("695996", JVBKINCL.JV_CONVENIOS.CVPCV_695996.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_695996.ToString()))
            {

                /*" -3604- PERFORM R3210-VER-MOVIMENTO */

                R3210_VER_MOVIMENTO_SECTION();

                /*" -3607- END-IF */
            }


            /*" -3609- PERFORM R2690-INCLUI-V0MOVICOB. */

            R2690_INCLUI_V0MOVICOB_SECTION();

            /*" -3611- ADD 1 TO IN-COBRANCA. */
            WS_AUX_ARQUIVO.IN_COBRANCA.Value = WS_AUX_ARQUIVO.IN_COBRANCA + 1;

            /*" -3611- PERFORM R3250-SELECT-V1ENDOSSO. */

            R3250_SELECT_V1ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_TRATA_DEMAIS_PARCEL_EXIT*/

        [StopWatch]
        /*" R3210-VER-MOVIMENTO-SECTION */
        private void R3210_VER_MOVIMENTO_SECTION()
        {
            /*" -3619- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3620- DISPLAY W-PROGRAMA-CHAMADOR '-R3210-VER-MOVIMENTO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3210-VER-MOVIMENTO");

                /*" -3624- END-IF */
            }


            /*" -3626- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", WABEND.WNR_EXEC_SQL);

            /*" -3628- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG GE403-NUM-NOSSO-NUMERO-SAP. */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

            /*" -3634- INITIALIZE MOVIMCOB-NUM-APOLICE MOVIMCOB-NUM-ENDOSSO MOVIMCOB-NUM-PARCELA MOVIMCOB-TIPO-MOVIMENTO MOVIMCOB-NUM-NOSSO-TITULO */
            _.Initialize(
                MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE
                , MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO
                , MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA
                , MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO
                , MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO
            );

            /*" -3651- PERFORM R3210_VER_MOVIMENTO_DB_SELECT_1 */

            R3210_VER_MOVIMENTO_DB_SELECT_1();

            /*" -3654- IF SQLCODE NOT = 000 AND +100 AND -811 */

            if (!DB.SQLCODE.In("000", "+100", "-811"))
            {

                /*" -3656- DISPLAY 'R3210-00 - PROBLEMAS SELECT ' 'GE_CONTROLE_EMISSAO_SIGCB E MOVIMENTO_COBRANCA' */
                _.Display($"R3210-00 - PROBLEMAS SELECT GE_CONTROLE_EMISSAO_SIGCB E MOVIMENTO_COBRANCA");

                /*" -3658- MOVE 'R3210-00 - PROBLEMAS SELECT GE_CONTR X MOV_COBR' TO W-MENSAGEM-ERRO */
                _.Move("R3210-00 - PROBLEMAS SELECT GE_CONTR X MOV_COBR", W_MENSAGEM_ERRO);

                /*" -3659- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3661- END-IF. */
            }


            /*" -3662- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3664- MOVE '*' TO MOVIMCOB-TIPO-MOVIMENTO */
                _.Move("*", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

                /*" -3665- GO TO R3210-VER-MOVIMENTO-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_VER_MOVIMENTO_EXIT*/ //GOTO
                return;

                /*" -3667- END-IF */
            }


            /*" -3669- MOVE MOVIMCOB-NUM-APOLICE TO V0MCOB-NUMAPOL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, V0MCOB_NUMAPOL);

            /*" -3671- MOVE MOVIMCOB-NUM-ENDOSSO TO V0MCOB-NRENDOS. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, V0MCOB_NRENDOS);

            /*" -3673- MOVE MOVIMCOB-NUM-PARCELA TO V0MCOB-NRPARCEL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, V0MCOB_NRPARCEL);

            /*" -3675- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, V0MCOB_NUM_NOSSO_TITULO);

            /*" -3675- MOVE 'B' TO V0MCOB-TIPOMOV. */
            _.Move("B", V0MCOB_TIPOMOV);

        }

        [StopWatch]
        /*" R3210-VER-MOVIMENTO-DB-SELECT-1 */
        public void R3210_VER_MOVIMENTO_DB_SELECT_1()
        {
            /*" -3651- EXEC SQL SELECT B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.NUM_PARCELA ,B.TIPO_MOVIMENTO ,B.NUM_NOSSO_TITULO INTO :MOVIMCOB-NUM-APOLICE ,:MOVIMCOB-NUM-ENDOSSO ,:MOVIMCOB-NUM-PARCELA ,:MOVIMCOB-TIPO-MOVIMENTO ,:MOVIMCOB-NUM-NOSSO-TITULO FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A ,SEGUROS.MOVIMENTO_COBRANCA B WHERE A.NUM_NOSSO_NUMERO_SAP = :GE403-NUM-NOSSO-NUMERO-SAP AND A.NUM_PROPOSTA = B.NUM_NOSSO_TITULO WITH UR END-EXEC. */

            var r3210_VER_MOVIMENTO_DB_SELECT_1_Query1 = new R3210_VER_MOVIMENTO_DB_SELECT_1_Query1()
            {
                GE403_NUM_NOSSO_NUMERO_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.ToString(),
            };

            var executed_1 = R3210_VER_MOVIMENTO_DB_SELECT_1_Query1.Execute(r3210_VER_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(executed_1.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(executed_1.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(executed_1.MOVIMCOB_TIPO_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);
                _.Move(executed_1.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_VER_MOVIMENTO_EXIT*/

        [StopWatch]
        /*" R3222-SELECT-COBHISVI-SECTION */
        private void R3222_SELECT_COBHISVI_SECTION()
        {
            /*" -3682- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3684- DISPLAY W-PROGRAMA-CHAMADOR '-R3222-SELECT-COBHISVI' ' NUM_TITULO=' V0MCOB-NRTIT */

                $"{W_PROGRAMA_CHAMADOR}-R3222-SELECT-COBHISVI NUM_TITULO={V0MCOB_NRTIT}"
                .Display();

                /*" -3687- END-IF */
            }


            /*" -3689- MOVE '3222' TO WNR-EXEC-SQL. */
            _.Move("3222", WABEND.WNR_EXEC_SQL);

            /*" -3691- INITIALIZE COBHISVI-NUM-TITULO */
            _.Initialize(
                COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO
            );

            /*" -3698- PERFORM R3222_SELECT_COBHISVI_DB_SELECT_1 */

            R3222_SELECT_COBHISVI_DB_SELECT_1();

            /*" -3700- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -3701- DISPLAY 'R3222-00 - PROBLEMAS NO SELECT(BILHETE)' */
                _.Display($"R3222-00 - PROBLEMAS NO SELECT(BILHETE)");

                /*" -3702- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3704- END-IF */
            }


            /*" -3705- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3706- PERFORM R3224-SELECT-GE403 */

                R3224_SELECT_GE403_SECTION();

                /*" -3707- END-IF */
            }


            /*" -3707- . */

        }

        [StopWatch]
        /*" R3222-SELECT-COBHISVI-DB-SELECT-1 */
        public void R3222_SELECT_COBHISVI_DB_SELECT_1()
        {
            /*" -3698- EXEC SQL SELECT NUM_TITULO INTO :COBHISVI-NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_TITULO = :V0MCOB-NRTIT FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3222_SELECT_COBHISVI_DB_SELECT_1_Query1 = new R3222_SELECT_COBHISVI_DB_SELECT_1_Query1()
            {
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3222_SELECT_COBHISVI_DB_SELECT_1_Query1.Execute(r3222_SELECT_COBHISVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3222_SELECT_COBHISVI_EXIT*/

        [StopWatch]
        /*" R3224-SELECT-GE403-SECTION */
        private void R3224_SELECT_GE403_SECTION()
        {
            /*" -3715- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3716- DISPLAY W-PROGRAMA-CHAMADOR '-R3224-SELECT-GE403' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3224-SELECT-GE403");

                /*" -3719- END-IF */
            }


            /*" -3721- MOVE '3224' TO WNR-EXEC-SQL. */
            _.Move("3224", WABEND.WNR_EXEC_SQL);

            /*" -3725- INITIALIZE GE403-NUM-APOLICE GE403-NUM-ENDOSSO GE403-NUM-IDLG GE403-NUM-NOSSO-NUMERO-SAP */
            _.Initialize(
                GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE
                , GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO
                , GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG
                , GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP
            );

            /*" -3728- MOVE -1 TO VIND-NULL01 VIND-NULL02 */
            _.Move(-1, VIND_NULL01, VIND_NULL02);

            /*" -3743- PERFORM R3224_SELECT_GE403_DB_SELECT_1 */

            R3224_SELECT_GE403_DB_SELECT_1();

            /*" -3746- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -3747- DISPLAY 'R3224-00 - PROBLEMAS NO SELECT(GE403).' */
                _.Display($"R3224-00 - PROBLEMAS NO SELECT(GE403).");

                /*" -3749- DISPLAY ' NUM_NOSSO_NUMERO_SAP=' V0MCOB-NUM-NOSSO-TITULO ' + 140000000000000000' */

                $" NUM_NOSSO_NUMERO_SAP={V0MCOB_NUM_NOSSO_TITULO} + 140000000000000000"
                .Display();

                /*" -3750- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3752- END-IF */
            }


            /*" -3754- IF GE403-NUM-APOLICE NOT EQUAL ZEROS AND GE403-NUM-ENDOSSO NOT EQUAL ZEROS */

            if (GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE != 00 && GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO != 00)
            {

                /*" -3755- PERFORM R3226-SELECT-PARCELAS */

                R3226_SELECT_PARCELAS_SECTION();

                /*" -3756- GO TO R3224-SELECT-GE403-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3224_SELECT_GE403_EXIT*/ //GOTO
                return;

                /*" -3758- END-IF */
            }


            /*" -3759- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -3761- MOVE SPACES TO GE403-NUM-IDLG */
                _.Move("", GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);

                /*" -3763- END-IF */
            }


            /*" -3764- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -3766- MOVE ZEROS TO GE403-NUM-NOSSO-NUMERO-SAP */
                _.Move(0, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

                /*" -3768- END-IF */
            }


            /*" -3769- IF GE403-NUM-IDLG EQUAL SPACES */

            if (GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG.IsEmpty())
            {

                /*" -3770- GO TO R3224-SELECT-GE403-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3224_SELECT_GE403_EXIT*/ //GOTO
                return;

                /*" -3772- END-IF */
            }


            /*" -3775- MOVE GE403-NUM-IDLG TO WS1-IDLG WS2-IDLG. */
            _.Move(GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG, WS_AUX_ARQUIVO.WS1_IDLG, WS_AUX_ARQUIVO.WS2_IDLG);

            /*" -3776- IF WS1-BRANCOS EQUAL SPACES */

            if (WS_AUX_ARQUIVO.WS1_IDLG.WS1_BRANCOS.IsEmpty())
            {

                /*" -3778- MOVE WS1-CONVENIO TO MOVDEBCE-COD-CONVENIO */
                _.Move(WS_AUX_ARQUIVO.WS1_IDLG.WS1_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -3780- MOVE WS1-NSAS TO MOVDEBCE-NSAS */
                _.Move(WS_AUX_ARQUIVO.WS1_IDLG.WS1_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                /*" -3782- MOVE WS1-ENDOSSO TO MOVDEBCE-NUM-ENDOSSO */
                _.Move(WS_AUX_ARQUIVO.WS1_IDLG.WS1_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                /*" -3783- PERFORM R3228-SELECT-MOVDEBCE */

                R3228_SELECT_MOVDEBCE_SECTION();

                /*" -3784- ELSE */
            }
            else
            {


                /*" -3786- MOVE WS2-NRCERTIF TO COBHISVI-NUM-CERTIFICADO */
                _.Move(WS_AUX_ARQUIVO.WS2_IDLG.WS2_NRCERTIF, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

                /*" -3788- MOVE WS2-NRPARCEL TO COBHISVI-NUM-PARCELA */
                _.Move(WS_AUX_ARQUIVO.WS2_IDLG.WS2_NRPARCEL, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

                /*" -3789- PERFORM R3230-SELECT-COBHISVI */

                R3230_SELECT_COBHISVI_SECTION();

                /*" -3789- END-IF. */
            }


        }

        [StopWatch]
        /*" R3224-SELECT-GE403-DB-SELECT-1 */
        public void R3224_SELECT_GE403_DB_SELECT_1()
        {
            /*" -3743- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_IDLG ,NUM_NOSSO_NUMERO_SAP INTO :GE403-NUM-APOLICE ,:GE403-NUM-ENDOSSO ,:GE403-NUM-IDLG:VIND-NULL01 ,:GE403-NUM-NOSSO-NUMERO-SAP:VIND-NULL02 FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB WHERE NUM_NOSSO_NUMERO_SAP = (:V0MCOB-NUM-NOSSO-TITULO + 140000000000000000) AND COD_SITUACAO = 'F' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3224_SELECT_GE403_DB_SELECT_1_Query1 = new R3224_SELECT_GE403_DB_SELECT_1_Query1()
            {
                V0MCOB_NUM_NOSSO_TITULO = V0MCOB_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R3224_SELECT_GE403_DB_SELECT_1_Query1.Execute(r3224_SELECT_GE403_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_NUM_APOLICE, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);
                _.Move(executed_1.GE403_NUM_ENDOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);
                _.Move(executed_1.GE403_NUM_IDLG, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_IDLG);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.GE403_NUM_NOSSO_NUMERO_SAP, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3224_SELECT_GE403_EXIT*/

        [StopWatch]
        /*" R3226-SELECT-PARCELAS-SECTION */
        private void R3226_SELECT_PARCELAS_SECTION()
        {
            /*" -3797- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3798- DISPLAY W-PROGRAMA-CHAMADOR '-R3226-SELECT-PARCELAS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3226-SELECT-PARCELAS");

                /*" -3801- END-IF */
            }


            /*" -3803- MOVE '3226' TO WNR-EXEC-SQL. */
            _.Move("3226", WABEND.WNR_EXEC_SQL);

            /*" -3805- INITIALIZE PARCELAS-NUM-TITULO */
            _.Initialize(
                PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO
            );

            /*" -3813- PERFORM R3226_SELECT_PARCELAS_DB_SELECT_1 */

            R3226_SELECT_PARCELAS_DB_SELECT_1();

            /*" -3816- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -3817- DISPLAY 'R3226-00 - PROBLEMAS NO SELECT(PARCELAS).' */
                _.Display($"R3226-00 - PROBLEMAS NO SELECT(PARCELAS).");

                /*" -3818- DISPLAY ' NUM_APOLICE=' GE403-NUM-APOLICE */
                _.Display($" NUM_APOLICE={GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}");

                /*" -3819- DISPLAY ' NUM_ENDOSSO=' GE403-NUM-ENDOSSO */
                _.Display($" NUM_ENDOSSO={GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                /*" -3820- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3822- END-IF */
            }


            /*" -3823- IF PARCELAS-NUM-TITULO NOT EQUAL ZEROS */

            if (PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO != 00)
            {

                /*" -3825- MOVE PARCELAS-NUM-TITULO TO V0MCOB-NRTIT */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO, V0MCOB_NRTIT);

                /*" -3826- MOVE '1' TO V0MCOB-TIPOMOV */
                _.Move("1", V0MCOB_TIPOMOV);

                /*" -3826- END-IF. */
            }


        }

        [StopWatch]
        /*" R3226-SELECT-PARCELAS-DB-SELECT-1 */
        public void R3226_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -3813- EXEC SQL SELECT NUM_TITULO INTO :PARCELAS-NUM-TITULO FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :GE403-NUM-APOLICE AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3226_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R3226_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R3226_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r3226_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_NUM_TITULO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3226_SELECT_PARCELAS_EXIT*/

        [StopWatch]
        /*" R3228-SELECT-MOVDEBCE-SECTION */
        private void R3228_SELECT_MOVDEBCE_SECTION()
        {
            /*" -3834- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3835- DISPLAY W-PROGRAMA-CHAMADOR '-R3228-SELECT-MOVDEBCE' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3228-SELECT-MOVDEBCE");

                /*" -3838- END-IF */
            }


            /*" -3840- MOVE '3228' TO WNR-EXEC-SQL. */
            _.Move("3228", WABEND.WNR_EXEC_SQL);

            /*" -3842- INITIALIZE MOVDEBCE-NUM-PARCELA MOVDEBCE-NUM-CARTAO */
            _.Initialize(
                MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA
                , MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO
            );

            /*" -3844- MOVE -1 TO VIND-NULL01 */
            _.Move(-1, VIND_NULL01);

            /*" -3855- PERFORM R3228_SELECT_MOVDEBCE_DB_SELECT_1 */

            R3228_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -3859- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3860- GO TO R3228-SELECT-MOVDEBCE-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3228_SELECT_MOVDEBCE_EXIT*/ //GOTO
                return;

                /*" -3862- END-IF */
            }


            /*" -3863- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3864- DISPLAY 'R3228-00 - PROBLEMAS NO SELECT(MOVDEBCE)' */
                _.Display($"R3228-00 - PROBLEMAS NO SELECT(MOVDEBCE)");

                /*" -3866- GO TO R9999-ROT-ERRO. */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3867- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -3868- GO TO R3228-SELECT-MOVDEBCE-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3228_SELECT_MOVDEBCE_EXIT*/ //GOTO
                return;

                /*" -3870- END-IF */
            }


            /*" -3872- MOVE MOVDEBCE-NUM-CARTAO TO COBHISVI-NUM-CERTIFICADO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -3875- MOVE MOVDEBCE-NUM-PARCELA TO COBHISVI-NUM-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -3875- PERFORM R3230-SELECT-COBHISVI. */

            R3230_SELECT_COBHISVI_SECTION();

        }

        [StopWatch]
        /*" R3228-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R3228_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -3855- EXEC SQL SELECT NUM_PARCELA ,NUM_CARTAO INTO :MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-NUM-CARTAO:VIND-NULL01 FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r3228_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3228_SELECT_MOVDEBCE_EXIT*/

        [StopWatch]
        /*" R3230-SELECT-COBHISVI-SECTION */
        private void R3230_SELECT_COBHISVI_SECTION()
        {
            /*" -3882- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3883- DISPLAY W-PROGRAMA-CHAMADOR '-R3230-SELECT-COBHISVI' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3230-SELECT-COBHISVI");

                /*" -3886- END-IF */
            }


            /*" -3888- MOVE '3230' TO WNR-EXEC-SQL. */
            _.Move("3230", WABEND.WNR_EXEC_SQL);

            /*" -3890- INITIALIZE COBHISVI-NUM-TITULO */
            _.Initialize(
                COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO
            );

            /*" -3898- PERFORM R3230_SELECT_COBHISVI_DB_SELECT_1 */

            R3230_SELECT_COBHISVI_DB_SELECT_1();

            /*" -3901- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -3902- DISPLAY 'R3230-00 - PROBLEMAS NO SELECT(COBHISVI).' */
                _.Display($"R3230-00 - PROBLEMAS NO SELECT(COBHISVI).");

                /*" -3903- DISPLAY ' NUM_CERTIFICADO=' COBHISVI-NUM-CERTIFICADO */
                _.Display($" NUM_CERTIFICADO={COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO}");

                /*" -3904- DISPLAY ' NUM_PARCELA    =' COBHISVI-NUM-PARCELA */
                _.Display($" NUM_PARCELA    ={COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA}");

                /*" -3905- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3907- END-IF */
            }


            /*" -3908- IF COBHISVI-NUM-TITULO NOT EQUAL ZEROS */

            if (COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO != 00)
            {

                /*" -3910- MOVE COBHISVI-NUM-TITULO TO V0MCOB-NRTIT */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, V0MCOB_NRTIT);

                /*" -3910- END-IF. */
            }


        }

        [StopWatch]
        /*" R3230-SELECT-COBHISVI-DB-SELECT-1 */
        public void R3230_SELECT_COBHISVI_DB_SELECT_1()
        {
            /*" -3898- EXEC SQL SELECT NUM_TITULO INTO :COBHISVI-NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3230_SELECT_COBHISVI_DB_SELECT_1_Query1 = new R3230_SELECT_COBHISVI_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3230_SELECT_COBHISVI_DB_SELECT_1_Query1.Execute(r3230_SELECT_COBHISVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_SELECT_COBHISVI_EXIT*/

        [StopWatch]
        /*" R3250-SELECT-V1ENDOSSO-SECTION */
        private void R3250_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -3918- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3919- DISPLAY W-PROGRAMA-CHAMADOR '-R3250-SELECT-V1ENDOSSO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3250-SELECT-V1ENDOSSO");

                /*" -3922- END-IF */
            }


            /*" -3924- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", WABEND.WNR_EXEC_SQL);

            /*" -3928- INITIALIZE V0PARC-NUMAPOL V0PARC-NRENDOS V0PARC-NRPARCEL V1ENDO-CODPRODU */
            _.Initialize(
                V0PARC_NUMAPOL
                , V0PARC_NRENDOS
                , V0PARC_NRPARCEL
                , V1ENDO_CODPRODU
            );

            /*" -3930- MOVE -1 TO VIND-CODPRODU */
            _.Move(-1, VIND_CODPRODU);

            /*" -3945- PERFORM R3250_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R3250_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -3947- IF (SQLCODE EQUAL -911 OR -913) */

            if ((DB.SQLCODE.In("-911", "-913")))
            {

                /*" -3948- DISPLAY 'R3250-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' */
                _.Display($"R3250-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT");

                /*" -3950- MOVE 'R3250-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' TO W-MENSAGEM-ERRO */
                _.Move("R3250-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT", W_MENSAGEM_ERRO);

                /*" -3951- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3953- END-IF. */
            }


            /*" -3954- IF SQLCODE NOT = 000 AND +100 AND -811 */

            if (!DB.SQLCODE.In("000", "+100", "-811"))
            {

                /*" -3955- DISPLAY 'R3250-00 - PROBLEMAS SELECT V0PARCELA V1ENDOSSO' */
                _.Display($"R3250-00 - PROBLEMAS SELECT V0PARCELA V1ENDOSSO");

                /*" -3956- DISPLAY ' NRTIT=' V0MCOB-NRTIT */
                _.Display($" NRTIT={V0MCOB_NRTIT}");

                /*" -3958- MOVE 'R3250-00 - PROBLEMAS SELECT V0PARCELA V1ENDOSSO' TO W-MENSAGEM-ERRO */
                _.Move("R3250-00 - PROBLEMAS SELECT V0PARCELA V1ENDOSSO", W_MENSAGEM_ERRO);

                /*" -3959- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3961- END-IF. */
            }


            /*" -3962- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3963- MOVE ZEROS TO WSHOST-CODPRODU */
                _.Move(0, WSHOST_CODPRODU);

                /*" -3964- ELSE */
            }
            else
            {


                /*" -3965- IF (VIND-CODPRODU < ZEROS) */

                if ((VIND_CODPRODU < 00))
                {

                    /*" -3966- MOVE ZEROS TO WSHOST-CODPRODU */
                    _.Move(0, WSHOST_CODPRODU);

                    /*" -3967- ELSE */
                }
                else
                {


                    /*" -3968- MOVE V1ENDO-CODPRODU TO WSHOST-CODPRODU */
                    _.Move(V1ENDO_CODPRODU, WSHOST_CODPRODU);

                    /*" -3969- PERFORM R3300-SELECT-CBMALPAR */

                    R3300_SELECT_CBMALPAR_SECTION();

                    /*" -3970- END-IF */
                }


                /*" -3972- END-IF. */
            }


            /*" -3973- IF (WSHOST-CODPRODU EQUAL ZEROS) */

            if ((WSHOST_CODPRODU == 00))
            {

                /*" -3974- PERFORM R3400-SELECT-V0PROPOSTAVA */

                R3400_SELECT_V0PROPOSTAVA_SECTION();

                /*" -3974- END-IF. */
            }


        }

        [StopWatch]
        /*" R3250-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R3250_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -3945- EXEC SQL SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , B.CODPRODU INTO :V0PARC-NUMAPOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V1ENDO-CODPRODU :VIND-CODPRODU FROM SEGUROS.V0PARCELA A, SEGUROS.V1ENDOSSO B WHERE A.NRTIT = :V0MCOB-NRTIT AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NRENDOS = A.NRENDOS WITH UR END-EXEC. */

            var r3250_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R3250_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3250_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r3250_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NUMAPOL, V0PARC_NUMAPOL);
                _.Move(executed_1.V0PARC_NRENDOS, V0PARC_NRENDOS);
                _.Move(executed_1.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_SELECT_V1ENDOSSO_EXIT*/

        [StopWatch]
        /*" R3300-SELECT-CBMALPAR-SECTION */
        private void R3300_SELECT_CBMALPAR_SECTION()
        {
            /*" -3982- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -3983- DISPLAY W-PROGRAMA-CHAMADOR '-R3300-SELECT-CBMALPAR' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3300-SELECT-CBMALPAR");

                /*" -3987- END-IF */
            }


            /*" -3989- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", WABEND.WNR_EXEC_SQL);

            /*" -3991- INITIALIZE V0PARC-NRTIT */
            _.Initialize(
                V0PARC_NRTIT
            );

            /*" -4005- PERFORM R3300_SELECT_CBMALPAR_DB_SELECT_1 */

            R3300_SELECT_CBMALPAR_DB_SELECT_1();

            /*" -4008- IF (SQLCODE EQUAL -911 OR -913) */

            if ((DB.SQLCODE.In("-911", "-913")))
            {

                /*" -4009- DISPLAY 'R3300-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' */
                _.Display($"R3300-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT");

                /*" -4011- MOVE 'R3300-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' TO W-MENSAGEM-ERRO */
                _.Move("R3300-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT", W_MENSAGEM_ERRO);

                /*" -4012- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4014- END-IF. */
            }


            /*" -4015- IF SQLCODE NOT = 000 AND +100 AND -305 */

            if (!DB.SQLCODE.In("000", "+100", "-305"))
            {

                /*" -4017- DISPLAY 'R3300-00 - PROBLEMAS SELECT ' 'CB_MALA_PARCATRASO ' */
                _.Display($"R3300-00 - PROBLEMAS SELECT CB_MALA_PARCATRASO ");

                /*" -4018- DISPLAY ' NRTIT=' V0MCOB-NRTIT */
                _.Display($" NRTIT={V0MCOB_NRTIT}");

                /*" -4020- MOVE 'R3300-00 - PROBLEMAS SELECT CB_MALA_PARCATRASO ' TO W-MENSAGEM-ERRO */
                _.Move("R3300-00 - PROBLEMAS SELECT CB_MALA_PARCATRASO ", W_MENSAGEM_ERRO);

                /*" -4021- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4023- END-IF. */
            }


            /*" -4024- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -4025- IF (V0MCOB-NRTIT EQUAL V0PARC-NRTIT) */

                if ((V0MCOB_NRTIT == V0PARC_NRTIT))
                {

                    /*" -4026- MOVE 'S' TO FLG-MALA */
                    _.Move("S", WS_AUX_ARQUIVO.FLG_MALA);

                    /*" -4027- END-IF */
                }


                /*" -4027- END-IF. */
            }


        }

        [StopWatch]
        /*" R3300-SELECT-CBMALPAR-DB-SELECT-1 */
        public void R3300_SELECT_CBMALPAR_DB_SELECT_1()
        {
            /*" -4005- EXEC SQL SELECT VALUE(A.NUM_TITULO,0) INTO :V0PARC-NRTIT FROM SEGUROS.CB_MALA_PARCATRASO A WHERE A.NUM_APOLICE = :V0PARC-NUMAPOL AND A.NUM_ENDOSSO = :V0PARC-NRENDOS AND A.NUM_PARCELA = :V0PARC-NRPARCEL AND A.DATA_MOVIMENTO = (SELECT MAX(B.DATA_MOVIMENTO) FROM SEGUROS.CB_MALA_PARCATRASO B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA) WITH UR END-EXEC. */

            var r3300_SELECT_CBMALPAR_DB_SELECT_1_Query1 = new R3300_SELECT_CBMALPAR_DB_SELECT_1_Query1()
            {
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_NUMAPOL = V0PARC_NUMAPOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3300_SELECT_CBMALPAR_DB_SELECT_1_Query1.Execute(r3300_SELECT_CBMALPAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NRTIT, V0PARC_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SELECT_CBMALPAR_EXIT*/

        [StopWatch]
        /*" R3400-SELECT-V0PROPOSTAVA-SECTION */
        private void R3400_SELECT_V0PROPOSTAVA_SECTION()
        {
            /*" -4035- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4037- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R3400-SELECT-V0PROPOSTAVA' */

                $"{W_PROGRAMA_CHAMADOR}-R3400-SELECT-V0PROPOSTAVA"
                .Display();

                /*" -4040- END-IF */
            }


            /*" -4042- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", WABEND.WNR_EXEC_SQL);

            /*" -4044- INITIALIZE V1ENDO-CODPRODU */
            _.Initialize(
                V1ENDO_CODPRODU
            );

            /*" -4052- PERFORM R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1 */

            R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1();

            /*" -4055- IF (SQLCODE EQUAL -911 OR -913) */

            if ((DB.SQLCODE.In("-911", "-913")))
            {

                /*" -4056- DISPLAY 'R3400-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' */
                _.Display($"R3400-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT");

                /*" -4058- MOVE 'R3400-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT' TO W-MENSAGEM-ERRO */
                _.Move("R3400-00 - PROBLEMAS COM DEADLOCK OU TIMEOUT", W_MENSAGEM_ERRO);

                /*" -4059- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4061- END-IF. */
            }


            /*" -4062- IF SQLCODE NOT = 000 AND +100 AND -811 */

            if (!DB.SQLCODE.In("000", "+100", "-811"))
            {

                /*" -4063- DISPLAY 'R3400-00 - PROBLEMAS NO SELECT(PROPOSTAVA)' */
                _.Display($"R3400-00 - PROBLEMAS NO SELECT(PROPOSTAVA)");

                /*" -4065- MOVE 'R3400-00 - PROBLEMAS NO SELECT(PROPOSTAVA)' TO W-MENSAGEM-ERRO */
                _.Move("R3400-00 - PROBLEMAS NO SELECT(PROPOSTAVA)", W_MENSAGEM_ERRO);

                /*" -4066- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4068- END-IF. */
            }


            /*" -4069- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -4070- MOVE V1ENDO-CODPRODU TO WSHOST-CODPRODU */
                _.Move(V1ENDO_CODPRODU, WSHOST_CODPRODU);

                /*" -4070- END-IF. */
            }


        }

        [StopWatch]
        /*" R3400-SELECT-V0PROPOSTAVA-DB-SELECT-1 */
        public void R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1()
        {
            /*" -4052- EXEC SQL SELECT B.CODPRODU INTO :V1ENDO-CODPRODU FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PROPOSTAVA B WHERE A.NRTIT = :V0MCOB-NRTIT AND B.NRCERTIF = A.NRCERTIF WITH UR END-EXEC. */

            var r3400_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 = new R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1()
            {
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3400_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1.Execute(r3400_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_SELECT_V0PROPOSTAVA_EXIT*/

        [StopWatch]
        /*" R3500-TRATA-ADESAO-SECTION */
        private void R3500_TRATA_ADESAO_SECTION()
        {
            /*" -4078- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4079- DISPLAY W-PROGRAMA-CHAMADOR '-R3500-TRATA-ADESAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3500-TRATA-ADESAO");

                /*" -4082- END-IF */
            }


            /*" -4084- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", WABEND.WNR_EXEC_SQL);

            /*" -4085- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -4086- MOVE WS-NN-REG-16P TO V0MCOB-NUM-NOSSO-TITULO */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.WS_NN_REG_16P, V0MCOB_NUM_NOSSO_TITULO);

            /*" -4087- MOVE ZEROS TO AUX-USO-EMPRESA2 */
            _.Move(0, WS_AUX_ARQUIVO.AUX_USO_EMPRESA2);

            /*" -4088- MOVE COBRAN-NUM-PROPOSTA TO AUX-USO-EMPRESA2 */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA2);

            /*" -4090- MOVE AUX-TITSIVPF2 TO AUX-APOLICE */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA2.AUX_TITSIVPF2, WS_AUX_ARQUIVO.AUX_APOLICE);

            /*" -4092- IF (COBRAN-NUM-TITULO EQUAL ZEROS) OR (COBRAN-NUM-TITULO NOT EQUAL WS-NN-REG-14P) */

            if ((COBRAN_REGISTRO.COBRAN_NUM_TITULO == 00) || (COBRAN_REGISTRO.COBRAN_NUM_TITULO != WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_14P))
            {

                /*" -4095- IF (COBRAN-COD-CEDENTE EQUAL 696001 AND WS-NN-REG-TP-PARC EQUAL 9 AND (COBRAN-NUM-TITULO NOT EQUAL ZEROS)) */

                if ((COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001 && WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_TP_PARC == 9 && (COBRAN_REGISTRO.COBRAN_NUM_TITULO != 00)))
                {

                    /*" -4096- CONTINUE */

                    /*" -4097- ELSE */
                }
                else
                {


                    /*" -4098- MOVE WS-NN-REG-14P TO COBRAN-NUM-TITULO */
                    _.Move(WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_14P, COBRAN_REGISTRO.COBRAN_NUM_TITULO);

                    /*" -4099- END-IF */
                }


                /*" -4101- END-IF */
            }


            /*" -4103- IF (WS-NN-REG-TP-PARC EQUAL 9 AND COBRAN-COD-CEDENTE EQUAL 696001) */

            if ((WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_TP_PARC == 9 && COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001))
            {

                /*" -4104- MOVE COBRAN-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, WS_AUX_ARQUIVO.WS_NUM_PROPOSTA);

                /*" -4105- MOVE WS-NUM-PROPOSTA TO V0FILT-NUMSIVPF */
                _.Move(WS_AUX_ARQUIVO.WS_NUM_PROPOSTA, V0FILT_NUMSIVPF);

                /*" -4107- PERFORM R2900-SELECT-CONVERSAO */

                R2900_SELECT_CONVERSAO_SECTION();

                /*" -4108- IF (V0FILT-COUNT NOT EQUAL ZEROS) */

                if ((V0FILT_COUNT != 00))
                {

                    /*" -4109- MOVE CONVSICOB-NR-SICOB TO COBRAN-NUM-TITULO */
                    _.Move(CONVSICOB_NR_SICOB, COBRAN_REGISTRO.COBRAN_NUM_TITULO);

                    /*" -4110- MOVE COBRAN-NUM-TITULO TO AUX-USO-EMPRESA2 */
                    _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_ARQUIVO.AUX_USO_EMPRESA2);

                    /*" -4111- MOVE AUX-TITSIVPF2 TO AUX-APOLICE */
                    _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA2.AUX_TITSIVPF2, WS_AUX_ARQUIVO.AUX_APOLICE);

                    /*" -4112- ELSE */
                }
                else
                {


                    /*" -4113- MOVE COBRAN-NUM-TITULO TO WS-NR-SICOB */
                    _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_ARQUIVO.WS_NR_SICOB);

                    /*" -4114- MOVE WS-NR-SICOB-T TO V0FILT-NUMSICOB */
                    _.Move(WS_AUX_ARQUIVO.FILLER_12.WS_NR_SICOB_T, V0FILT_NUMSICOB);

                    /*" -4116- PERFORM R2901-SELECT-CONVERSAO2 */

                    R2901_SELECT_CONVERSAO2_SECTION();

                    /*" -4117- IF (V0FILT-COUNT2 NOT EQUAL ZEROS) */

                    if ((V0FILT_COUNT2 != 00))
                    {

                        /*" -4118- MOVE CONVSICOB-NUM-PROP-SIVPF TO COBRAN-NUM-TITULO */
                        _.Move(CONVSICOB_NUM_PROP_SIVPF, COBRAN_REGISTRO.COBRAN_NUM_TITULO);

                        /*" -4119- MOVE COBRAN-NUM-TITULO TO AUX-USO-EMPRESA2 */
                        _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_ARQUIVO.AUX_USO_EMPRESA2);

                        /*" -4120- MOVE AUX-TITSIVPF2 TO AUX-APOLICE */
                        _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA2.AUX_TITSIVPF2, WS_AUX_ARQUIVO.AUX_APOLICE);

                        /*" -4121- ELSE */
                    }
                    else
                    {


                        /*" -4122- MOVE COBRAN-NUM-PROPOSTA TO COBRAN-NUM-TITULO */
                        _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, COBRAN_REGISTRO.COBRAN_NUM_TITULO);

                        /*" -4123- END-IF */
                    }


                    /*" -4124- END-IF */
                }


                /*" -4126- END-IF. */
            }


            /*" -4128- MOVE COBRAN-NUM-TITULO TO AUX-NRO-SIVPF. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_ARQUIVO.AUX_NRO_SIVPF);

            /*" -4130- IF (AUX-CANAL EQUAL ZEROS) AND (AUX-PRDSIVPF EQUAL ZEROS) */

            if ((WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL == 00) && (WS_AUX_ARQUIVO.FILLER_21.AUX_PRDSIVPF == 00))
            {

                /*" -4131- MOVE 'S' TO FLG-GRAFICA */
                _.Move("S", WS_AUX_ARQUIVO.FLG_GRAFICA);

                /*" -4132- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -4134- MOVE 'TITULO GRAFICA SEM IDENTIFICACAO' TO V0MCOB-NOME */
                _.Move("TITULO GRAFICA SEM IDENTIFICACAO", V0MCOB_NOME);

                /*" -4136- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -4138- PERFORM R3900-MONTA-V0FOLLOWUP */

                R3900_MONTA_V0FOLLOWUP_SECTION();

                /*" -4139- GO TO R3500-TRATA-ADESAO-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_TRATA_ADESAO_EXIT*/ //GOTO
                return;

                /*" -4141- END-IF */
            }


            /*" -4144- IF (AUX-CANAL NOT EQUAL 0 AND 1 AND 2 AND 3 AND 5 AND 6 AND 7 AND 8 AND 9) */

            if ((!WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL.In("0", "1", "2", "3", "5", "6", "7", "8", "9")))
            {

                /*" -4145- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -4147- MOVE 'CANAL DE VENDA NAO PREVISTO' TO V0MCOB-NOME */
                _.Move("CANAL DE VENDA NAO PREVISTO", V0MCOB_NOME);

                /*" -4149- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -4151- PERFORM R3900-MONTA-V0FOLLOWUP */

                R3900_MONTA_V0FOLLOWUP_SECTION();

                /*" -4152- GO TO R3500-TRATA-ADESAO-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_TRATA_ADESAO_EXIT*/ //GOTO
                return;

                /*" -4156- END-IF */
            }


            /*" -4157- MOVE 1 TO V0FILT-CODEMP */
            _.Move(1, V0FILT_CODEMP);

            /*" -4158- MOVE AUX-PRDSIVPF TO V0FILT-CODSIVPF */
            _.Move(WS_AUX_ARQUIVO.FILLER_21.AUX_PRDSIVPF, V0FILT_CODSIVPF);

            /*" -4159- MOVE COBRAN-NUM-AGE-RECEB TO V0FILT-AGECOBR */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB, V0FILT_AGECOBR);

            /*" -4161- MOVE V0SIST-DTMOVABE TO V0FILT-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0FILT_DTMOVTO);

            /*" -4162- MOVE COBRAN-DTA-PAGAMENTO TO WDATA-SECULO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_PAGAMENTO, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4163- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4164- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4165- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4166- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4168- MOVE WDATA-TABELA TO V0FILT-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0FILT_DTQITBCO);

            /*" -4169- MOVE COBRAN-VLR-PAGO TO V0FILT-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0FILT_VLRCAP);

            /*" -4171- MOVE COBRAN-VLR-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, V0MCOB_VLIOCC);

            /*" -4173- MOVE 'PF2002B' TO V0FILT-CODUSU. */
            _.Move("PF2002B", V0FILT_CODUSU);

            /*" -4176- MOVE ZEROS TO V1RCAP-NRTIT. */
            _.Move(0, V1RCAP_NRTIT);

            /*" -4177- IF (AUX-CANAL NOT EQUAL 0) */

            if ((WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL != 0))
            {

                /*" -4179- PERFORM R2800-LER-CONVERSAO */

                R2800_LER_CONVERSAO_SECTION();

                /*" -4180- IF (V0FILT-COUNT NOT EQUAL ZEROS) */

                if ((V0FILT_COUNT != 00))
                {

                    /*" -4182- MOVE CONVSICOB-NR-SICOB TO V0RCAP-NRTIT WWORK-NSO-NUMERO */
                    _.Move(CONVSICOB_NR_SICOB, V0RCAP_NRTIT, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                    /*" -4184- PERFORM R3710-SELECT-V1RCAP */

                    R3710_SELECT_V1RCAP_SECTION();

                    /*" -4185- IF (V1RCAP-NRTIT EQUAL 9999999) */

                    if ((V1RCAP_NRTIT == 9999999))
                    {

                        /*" -4186- MOVE '1' TO V0FOLL-CDERRO02 */
                        _.Move("1", V0FOLL_CDERRO02);

                        /*" -4188- MOVE 'TITULO DUPLICADO CONVERSAO' TO V0MCOB-NOME */
                        _.Move("TITULO DUPLICADO CONVERSAO", V0MCOB_NOME);

                        /*" -4189- MOVE ZEROS TO V0FOLL-NRRCAP */
                        _.Move(0, V0FOLL_NRRCAP);

                        /*" -4191- MOVE WWORK-NSO-NUMERO TO V0FOLL-NRRCAP */
                        _.Move(WS_AUX_ARQUIVO.WWORK_NSO_NUMERO, V0FOLL_NRRCAP);

                        /*" -4193- PERFORM R3900-MONTA-V0FOLLOWUP */

                        R3900_MONTA_V0FOLLOWUP_SECTION();

                        /*" -4194- GO TO R3500-TRATA-ADESAO-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_TRATA_ADESAO_EXIT*/ //GOTO
                        return;

                        /*" -4195- END-IF */
                    }


                    /*" -4196- ELSE */
                }
                else
                {


                    /*" -4198- PERFORM R3100-CALCULA-TITULO */

                    R3100_CALCULA_TITULO_SECTION();

                    /*" -4200- MOVE WWORK-MIN-NRTIT TO V0FILT-NUMSICOB WWORK-NSO-NUMERO */
                    _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0FILT_NUMSICOB, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                    /*" -4201- END-IF */
                }


                /*" -4202- ELSE */
            }
            else
            {


                /*" -4204- MOVE 'S' TO FLG-GRAFICA */
                _.Move("S", WS_AUX_ARQUIVO.FLG_GRAFICA);

                /*" -4205- IF COBRAN-COD-CEDENTE = 696001 */

                if (COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001)
                {

                    /*" -4206- MOVE COBRAN-NUM-TITULO TO AUX-NUM-GRAFICA */
                    _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_ARQUIVO.FILLER_19.AUX_NUM_GRAFICA);

                    /*" -4208- END-IF */
                }


                /*" -4211- MOVE AUX-NUM-GRAFICA TO WWORK-NSO-NUMERO */
                _.Move(WS_AUX_ARQUIVO.FILLER_19.AUX_NUM_GRAFICA, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                /*" -4214- MOVE COBRAN-COD-PRODUTO TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(COBRAN_REGISTRO.COBRAN_COD_PRODUTO, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -4215- IF (COBRAN-COD-PRODUTO EQUAL 8201) */

                if ((COBRAN_REGISTRO.COBRAN_COD_PRODUTO == 8201))
                {

                    /*" -4218- MOVE 8202 TO COBRAN-COD-PRODUTO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(8202, COBRAN_REGISTRO.COBRAN_COD_PRODUTO, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -4220- END-IF */
                }


                /*" -4221- IF (COBRAN-COD-PRODUTO EQUAL 7106 OR 7108) */

                if ((COBRAN_REGISTRO.COBRAN_COD_PRODUTO.In("7106", "7108")))
                {

                    /*" -4224- MOVE 1402 TO COBRAN-COD-PRODUTO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(1402, COBRAN_REGISTRO.COBRAN_COD_PRODUTO, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -4226- END-IF */
                }


                /*" -4228- IF (AUX-CANAL EQUAL 2) AND (V0PRPF-CODSIVPF NOT EQUAL 48) */

                if ((WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL == 2) && (V0PRPF_CODSIVPF != 48))
                {

                    /*" -4231- MOVE AUX-AGENCIA TO COBRAN-COD-PRODUTO CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(WS_AUX_ARQUIVO.FILLER_21.AUX_AGENCIA, COBRAN_REGISTRO.COBRAN_COD_PRODUTO, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -4232- END-IF */
                }


                /*" -4235- END-IF. */
            }


            /*" -4242- MOVE COBRAN-NUM-PROPOSTA TO PF087-NUM-PROPOSTA. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);

            /*" -4252- PERFORM R3500_TRATA_ADESAO_DB_SELECT_1 */

            R3500_TRATA_ADESAO_DB_SELECT_1();

            /*" -4255- IF SQLCODE NOT = 000 AND +100 AND -811 */

            if (!DB.SQLCODE.In("000", "+100", "-811"))
            {

                /*" -4256- DISPLAY 'R3500 - PROBLEMAS SELECT PF_PROC_PROPOSTA' */
                _.Display($"R3500 - PROBLEMAS SELECT PF_PROC_PROPOSTA");

                /*" -4257- DISPLAY 'NUM_PROPOSTA=' PF087-NUM-PROPOSTA */
                _.Display($"NUM_PROPOSTA={PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                /*" -4259- MOVE 'R3500 - PROBLEMAS SELECT PF_PROC_PROPOSTA' TO W-MENSAGEM-ERRO */
                _.Move("R3500 - PROBLEMAS SELECT PF_PROC_PROPOSTA", W_MENSAGEM_ERRO);

                /*" -4260- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4262- END-IF. */
            }


            /*" -4263- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4266- STRING WWORK-NRRCAP WWORK-DIGTIT DELIMITED BY SIZE INTO WW-NRRCAP-X */
                #region STRING
                var spl2 = WS_AUX_ARQUIVO.FILLER_15.WWORK_NRRCAP.GetMoveValues();
                var spl3 = WS_AUX_ARQUIVO.FILLER_15.WWORK_DIGTIT.GetMoveValues();
                var results4 = spl2 + spl3;
                _.Move(results4, WW_NRRCAP_X);
                #endregion

                /*" -4267- MOVE WW-NRRCAP-9 TO V0RCAP-NRRCAP */
                _.Move(WW_NRRCAP_X.WW_NRRCAP_9, V0RCAP_NRRCAP);

                /*" -4268- ELSE */
            }
            else
            {


                /*" -4269- MOVE WWORK-NRRCAP TO V0RCAP-NRRCAP */
                _.Move(WS_AUX_ARQUIVO.FILLER_15.WWORK_NRRCAP, V0RCAP_NRRCAP);

                /*" -4286- END-IF. */
            }


            /*" -4288- MOVE COBRAN-VLR-PAGO TO V0RCAP-VLRCAP V0RCAP-VALPRI */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0RCAP_VLRCAP, V0RCAP_VALPRI);

            /*" -4289- MOVE WWORK-NSO-NUMERO TO V0RCAP-NRTIT */
            _.Move(WS_AUX_ARQUIVO.WWORK_NSO_NUMERO, V0RCAP_NRTIT);

            /*" -4291- MOVE CONVEN-CODPRODU TO V0RCAP-CODPRODU */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0RCAP_CODPRODU);

            /*" -4293- MOVE COBRAN-NUM-TITULO TO V0RCAP-NRCERTIF. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, V0RCAP_NRCERTIF);

            /*" -4294- IF COBRAN-COD-CEDENTE = 696001 */

            if (COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001)
            {

                /*" -4295- IF AUX-AGE-TP-AVISO EQUAL 9 */

                if (WS_AUX_ARQUIVO.AUX_AGE_AVISO.AUX_AGE_TP_AVISO == 9)
                {

                    /*" -4296- MOVE COBRAN-NUM-PROPOSTA TO AUX-USO-EMPRESA */
                    _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

                    /*" -4297- MOVE AUX-TITSIVPF TO V0RCAP-NRCERTIF */
                    _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0RCAP_NRCERTIF);

                    /*" -4298- ELSE */
                }
                else
                {


                    /*" -4299- MOVE WS-NN-REG-14P TO V0RCAP-NRCERTIF */
                    _.Move(WS_AUX_ARQUIVO.FILLER_6.WS_NN_REG_14P, V0RCAP_NRCERTIF);

                    /*" -4300- END-IF */
                }


                /*" -4302- END-IF. */
            }


            /*" -4304- PERFORM R3700-INCLUI-V0RCAP */

            R3700_INCLUI_V0RCAP_SECTION();

            /*" -4305- IF (AUX-CANAL EQUAL 1 OR 2 OR 3 OR 5 OR 6 OR 8 OR 9) */

            if ((WS_AUX_ARQUIVO.FILLER_21.AUX_CANAL.In("1", "2", "3", "5", "6", "8", "9")))
            {

                /*" -4306- IF (V0FILT-COUNT EQUAL ZEROS) */

                if ((V0FILT_COUNT == 00))
                {

                    /*" -4307- INITIALIZE W-COUNT-INSERT */
                    _.Initialize(
                        W_COUNT_INSERT
                    );

                    /*" -4308- PERFORM R3800-INCLUI-CONVERSAO */

                    R3800_INCLUI_CONVERSAO_SECTION();

                    /*" -4309- PERFORM R3850-TRATA-DUPLICI-SICOB UNTIL SQLCODE = 000 */

                    while (!(DB.SQLCODE == 000))
                    {

                        R3850_TRATA_DUPLICI_SICOB_SECTION();
                    }

                    /*" -4310- ELSE */
                }
                else
                {


                    /*" -4311- PERFORM R3950-UPDATE-CONVERSAO */

                    R3950_UPDATE_CONVERSAO_SECTION();

                    /*" -4312- END-IF */
                }


                /*" -4314- END-IF. */
            }


            /*" -4316- IF (COBRAN-VLR-TARIFA NOT EQUAL ZEROS) OR (COBRAN-VLR-ABATIMENTO NOT EQUAL ZEROS) */

            if ((COBRAN_REGISTRO.COBRAN_VLR_TARIFA != 00) || (COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO != 00))
            {

                /*" -4317- PERFORM R6500-TARIFA-BALCAO */

                R6500_TARIFA_BALCAO_SECTION();

                /*" -4317- END-IF. */
            }


        }

        [StopWatch]
        /*" R3500-TRATA-ADESAO-DB-SELECT-1 */
        public void R3500_TRATA_ADESAO_DB_SELECT_1()
        {
            /*" -4252- EXEC SQL SELECT SIGLA_ARQUIVO , NUM_PROPOSTA INTO :PF087-SIGLA-ARQUIVO , :PF087-NUM-PROPOSTA FROM SEGUROS.PF_PROC_PROPOSTA WHERE SIGLA_ARQUIVO = 'PORTALPJ' AND NUM_PROPOSTA = :PF087-NUM-PROPOSTA FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r3500_TRATA_ADESAO_DB_SELECT_1_Query1 = new R3500_TRATA_ADESAO_DB_SELECT_1_Query1()
            {
                PF087_NUM_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = R3500_TRATA_ADESAO_DB_SELECT_1_Query1.Execute(r3500_TRATA_ADESAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF087_SIGLA_ARQUIVO, PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO);
                _.Move(executed_1.PF087_NUM_PROPOSTA, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_TRATA_ADESAO_EXIT*/

        [StopWatch]
        /*" R3700-INCLUI-V0RCAP-SECTION */
        private void R3700_INCLUI_V0RCAP_SECTION()
        {
            /*" -4325- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4326- DISPLAY W-PROGRAMA-CHAMADOR '-R3700-INCLUI-V0RCAP' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3700-INCLUI-V0RCAP");

                /*" -4329- END-IF */
            }


            /*" -4331- MOVE '3700' TO WNR-EXEC-SQL. */
            _.Move("3700", WABEND.WNR_EXEC_SQL);

            /*" -4332- MOVE CONVEN-FONTE TO V0RCAP-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0RCAP_FONTE);

            /*" -4333- MOVE ZEROS TO V0RCAP-NRPROPOS */
            _.Move(0, V0RCAP_NRPROPOS);

            /*" -4335- MOVE SPACES TO V0RCAP-NOME */
            _.Move("", V0RCAP_NOME);

            /*" -4336- MOVE COBRAN-DIA-GERACAO TO WDAT-REL-DIA */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_GERACAO.COBRAN_DIA_GERACAO, WS_AUX_DATAS.FILLER_28.WDAT_REL_DIA);

            /*" -4337- MOVE COBRAN-MES-GERACAO TO WDAT-REL-MES */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_GERACAO.COBRAN_MES_GERACAO, WS_AUX_DATAS.FILLER_28.WDAT_REL_MES);

            /*" -4338- MOVE COBRAN-ANO-GERACAO TO WDAT-REL-ANO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_GERACAO.COBRAN_ANO_GERACAO, WS_AUX_DATAS.FILLER_28.WDAT_REL_ANO);

            /*" -4340- MOVE '-' TO WDAT-FILLER-1 WDAT-FILLER-2 */
            _.Move("-", WS_AUX_DATAS.FILLER_28.WDAT_FILLER_1);
            _.Move("-", WS_AUX_DATAS.FILLER_28.WDAT_FILLER_2);


            /*" -4342- MOVE WDATA-REL TO V0RCAP-DTCADAST */
            _.Move(WS_AUX_DATAS.WDATA_REL, V0RCAP_DTCADAST);

            /*" -4343- MOVE V0SIST-DTMOVABE TO V0RCAP-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0RCAP_DTMOVTO);

            /*" -4344- MOVE '0' TO V0RCAP-SITUACAO */
            _.Move("0", V0RCAP_SITUACAO);

            /*" -4345- MOVE 110 TO V0RCAP-OPERACAO */
            _.Move(110, V0RCAP_OPERACAO);

            /*" -4349- MOVE ZEROS TO V0RCAP-CODEMP V0RCAP-NUMAPOL V0RCAP-NRENDOS V0RCAP-NRPARCEL */
            _.Move(0, V0RCAP_CODEMP, V0RCAP_NUMAPOL, V0RCAP_NRENDOS, V0RCAP_NRPARCEL);

            /*" -4350- MOVE COBRAN-NUM-AGE-RECEB TO V0RCAP-AGECOBR */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_AGE_RECEB, V0RCAP_AGECOBR);

            /*" -4351- MOVE SPACES TO V0RCAP-RECUPERA */
            _.Move("", V0RCAP_RECUPERA);

            /*" -4353- MOVE ZEROS TO V0RCAP-ACRESCIMO. */
            _.Move(0, V0RCAP_ACRESCIMO);

            /*" -4359- MOVE ZEROS TO VIND-CODEMP VIND-NRTIT VIND-CODPRODU VIND-AGECOBR VIND-NRCERTIF. */
            _.Move(0, VIND_CODEMP, VIND_NRTIT, VIND_CODPRODU, VIND_AGECOBR, VIND_NRCERTIF);

            /*" -4369- MOVE -1 TO VIND-NUMAPOL VIND-NRENDOS VIND-NRPARCEL VIND-RECUPERA VIND-ACRESCIMO. */
            _.Move(-1, VIND_NUMAPOL, VIND_NRENDOS, VIND_NRPARCEL, VIND_RECUPERA, VIND_ACRESCIMO);

            /*" -4371- PERFORM R3710-SELECT-V1RCAP. */

            R3710_SELECT_V1RCAP_SECTION();

            /*" -4372- IF (V1RCAP-NRTIT EQUAL 9999999) */

            if ((V1RCAP_NRTIT == 9999999))
            {

                /*" -4373- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -4375- MOVE 'TITULO DUPLICADO RCAP' TO V0MCOB-NOME */
                _.Move("TITULO DUPLICADO RCAP", V0MCOB_NOME);

                /*" -4376- MOVE WWORK-NRRCAP TO V0FOLL-NRRCAP */
                _.Move(WS_AUX_ARQUIVO.FILLER_15.WWORK_NRRCAP, V0FOLL_NRRCAP);

                /*" -4377- PERFORM R3900-MONTA-V0FOLLOWUP */

                R3900_MONTA_V0FOLLOWUP_SECTION();

                /*" -4378- GO TO R3700-INCLUI-V0RCAP-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_INCLUI_V0RCAP_EXIT*/ //GOTO
                return;

                /*" -4381- END-IF */
            }


            /*" -4404- PERFORM R3700_INCLUI_V0RCAP_DB_INSERT_1 */

            R3700_INCLUI_V0RCAP_DB_INSERT_1();

            /*" -4413- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4414- DISPLAY 'R3700-00 - PROBLEMAS INSERT (V0RCAP) ' */
                _.Display($"R3700-00 - PROBLEMAS INSERT (V0RCAP) ");

                /*" -4415- DISPLAY 'NUM RCAP     = ' V0RCAP-NRRCAP */
                _.Display($"NUM RCAP     = {V0RCAP_NRRCAP}");

                /*" -4416- DISPLAY 'NUM PROPOSTA = ' COBRAN-NUM-PROPOSTA */
                _.Display($"NUM PROPOSTA = {COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA}");

                /*" -4417- DISPLAY 'NUM SICOB    = ' CONVSICOB-NR-SICOB */
                _.Display($"NUM SICOB    = {CONVSICOB_NR_SICOB}");

                /*" -4419- MOVE 'R3700-00 - PROBLEMAS INSERT (V0RCAP) ' TO W-MENSAGEM-ERRO */
                _.Move("R3700-00 - PROBLEMAS INSERT (V0RCAP) ", W_MENSAGEM_ERRO);

                /*" -4421- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4422- ELSE */
            }
            else
            {


                /*" -4423- PERFORM R3750-INCLUI-V0RCAPCOMP */

                R3750_INCLUI_V0RCAPCOMP_SECTION();

                /*" -4425- END-IF. */
            }


            /*" -4425- ADD 1 TO IN-V0RCAP. */
            WS_AUX_ARQUIVO.IN_V0RCAP.Value = WS_AUX_ARQUIVO.IN_V0RCAP + 1;

        }

        [StopWatch]
        /*" R3700-INCLUI-V0RCAP-DB-INSERT-1 */
        public void R3700_INCLUI_V0RCAP_DB_INSERT_1()
        {
            /*" -4404- EXEC SQL INSERT INTO SEGUROS.V0RCAP VALUES (:V0RCAP-FONTE , :V0RCAP-NRRCAP , :V0RCAP-NRPROPOS , :V0RCAP-NOME , :V0RCAP-VLRCAP , :V0RCAP-VALPRI , :V0RCAP-DTCADAST , :V0RCAP-DTMOVTO , :V0RCAP-SITUACAO , :V0RCAP-OPERACAO , :V0RCAP-CODEMP :VIND-CODEMP , CURRENT TIMESTAMP , :V0RCAP-NUMAPOL :VIND-NUMAPOL , :V0RCAP-NRENDOS :VIND-NRENDOS , :V0RCAP-NRPARCEL :VIND-NRPARCEL , :V0RCAP-NRTIT :VIND-NRTIT , :V0RCAP-CODPRODU :VIND-CODPRODU , :V0RCAP-AGECOBR :VIND-AGECOBR , :V0RCAP-RECUPERA :VIND-RECUPERA , :V0RCAP-ACRESCIMO:VIND-ACRESCIMO, :V0RCAP-NRCERTIF :VIND-NRCERTIF) END-EXEC. */

            var r3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1 = new R3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1()
            {
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_NRPROPOS = V0RCAP_NRPROPOS.ToString(),
                V0RCAP_NOME = V0RCAP_NOME.ToString(),
                V0RCAP_VLRCAP = V0RCAP_VLRCAP.ToString(),
                V0RCAP_VALPRI = V0RCAP_VALPRI.ToString(),
                V0RCAP_DTCADAST = V0RCAP_DTCADAST.ToString(),
                V0RCAP_DTMOVTO = V0RCAP_DTMOVTO.ToString(),
                V0RCAP_SITUACAO = V0RCAP_SITUACAO.ToString(),
                V0RCAP_OPERACAO = V0RCAP_OPERACAO.ToString(),
                V0RCAP_CODEMP = V0RCAP_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0RCAP_NUMAPOL = V0RCAP_NUMAPOL.ToString(),
                VIND_NUMAPOL = VIND_NUMAPOL.ToString(),
                V0RCAP_NRENDOS = V0RCAP_NRENDOS.ToString(),
                VIND_NRENDOS = VIND_NRENDOS.ToString(),
                V0RCAP_NRPARCEL = V0RCAP_NRPARCEL.ToString(),
                VIND_NRPARCEL = VIND_NRPARCEL.ToString(),
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
                VIND_NRTIT = VIND_NRTIT.ToString(),
                V0RCAP_CODPRODU = V0RCAP_CODPRODU.ToString(),
                VIND_CODPRODU = VIND_CODPRODU.ToString(),
                V0RCAP_AGECOBR = V0RCAP_AGECOBR.ToString(),
                VIND_AGECOBR = VIND_AGECOBR.ToString(),
                V0RCAP_RECUPERA = V0RCAP_RECUPERA.ToString(),
                VIND_RECUPERA = VIND_RECUPERA.ToString(),
                V0RCAP_ACRESCIMO = V0RCAP_ACRESCIMO.ToString(),
                VIND_ACRESCIMO = VIND_ACRESCIMO.ToString(),
                V0RCAP_NRCERTIF = V0RCAP_NRCERTIF.ToString(),
                VIND_NRCERTIF = VIND_NRCERTIF.ToString(),
            };

            R3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1.Execute(r3700_INCLUI_V0RCAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_INCLUI_V0RCAP_EXIT*/

        [StopWatch]
        /*" R3710-SELECT-V1RCAP-SECTION */
        private void R3710_SELECT_V1RCAP_SECTION()
        {
            /*" -4433- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4434- DISPLAY W-PROGRAMA-CHAMADOR '-R3710-SELECT-V1RCAP' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3710-SELECT-V1RCAP");

                /*" -4437- END-IF */
            }


            /*" -4439- MOVE '3710' TO WNR-EXEC-SQL. */
            _.Move("3710", WABEND.WNR_EXEC_SQL);

            /*" -4441- INITIALIZE V1RCAP-NRTIT */
            _.Initialize(
                V1RCAP_NRTIT
            );

            /*" -4447- PERFORM R3710_SELECT_V1RCAP_DB_SELECT_1 */

            R3710_SELECT_V1RCAP_DB_SELECT_1();

            /*" -4450- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -4452- DISPLAY 'R3710-00 - PROBLEMAS NO SELECT(V1RCAP) ' V0RCAP-NRTIT */
                _.Display($"R3710-00 - PROBLEMAS NO SELECT(V1RCAP) {V0RCAP_NRTIT}");

                /*" -4454- MOVE 'R3710-00 - PROBLEMAS NO SELECT(V1RCAP) ' TO W-MENSAGEM-ERRO */
                _.Move("R3710-00 - PROBLEMAS NO SELECT(V1RCAP) ", W_MENSAGEM_ERRO);

                /*" -4455- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4456- ELSE */
            }
            else
            {


                /*" -4457- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -4458- MOVE 9999999 TO V1RCAP-NRTIT */
                    _.Move(9999999, V1RCAP_NRTIT);

                    /*" -4459- ELSE */
                }
                else
                {


                    /*" -4460- MOVE ZEROS TO V1RCAP-NRTIT */
                    _.Move(0, V1RCAP_NRTIT);

                    /*" -4461- END-IF */
                }


                /*" -4461- END-IF. */
            }


        }

        [StopWatch]
        /*" R3710-SELECT-V1RCAP-DB-SELECT-1 */
        public void R3710_SELECT_V1RCAP_DB_SELECT_1()
        {
            /*" -4447- EXEC SQL SELECT NRTIT INTO :V1RCAP-NRTIT FROM SEGUROS.V1RCAP WHERE NRTIT = :V0RCAP-NRTIT WITH UR END-EXEC. */

            var r3710_SELECT_V1RCAP_DB_SELECT_1_Query1 = new R3710_SELECT_V1RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R3710_SELECT_V1RCAP_DB_SELECT_1_Query1.Execute(r3710_SELECT_V1RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAP_NRTIT, V1RCAP_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3710_SELECT_V1RCAP_EXIT*/

        [StopWatch]
        /*" R3750-INCLUI-V0RCAPCOMP-SECTION */
        private void R3750_INCLUI_V0RCAPCOMP_SECTION()
        {
            /*" -4469- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4470- DISPLAY W-PROGRAMA-CHAMADOR '-R3750-INCLUI-V0RCAPCOMP' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3750-INCLUI-V0RCAPCOMP");

                /*" -4473- END-IF */
            }


            /*" -4475- MOVE '3750' TO WNR-EXEC-SQL. */
            _.Move("3750", WABEND.WNR_EXEC_SQL);

            /*" -4476- MOVE V0RCAP-FONTE TO V0RCOM-FONTE */
            _.Move(V0RCAP_FONTE, V0RCOM_FONTE);

            /*" -4477- MOVE V0RCAP-NRRCAP TO V0RCOM-NRRCAP */
            _.Move(V0RCAP_NRRCAP, V0RCOM_NRRCAP);

            /*" -4478- MOVE 0 TO V0RCOM-NRRCAPCO */
            _.Move(0, V0RCOM_NRRCAPCO);

            /*" -4479- MOVE V0RCAP-OPERACAO TO V0RCOM-OPERACAO */
            _.Move(V0RCAP_OPERACAO, V0RCOM_OPERACAO);

            /*" -4480- MOVE V0RCAP-DTMOVTO TO V0RCOM-DTMOVTO */
            _.Move(V0RCAP_DTMOVTO, V0RCOM_DTMOVTO);

            /*" -4482- MOVE V0RCAP-SITUACAO TO V0RCOM-SITUACAO */
            _.Move(V0RCAP_SITUACAO, V0RCOM_SITUACAO);

            /*" -4483- MOVE V0AVIS-BCOAVISO TO V0RCOM-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0RCOM_BCOAVISO);

            /*" -4484- MOVE WWORK-AGEAVISO TO V0RCOM-AGEAVISO */
            _.Move(WWORK_AGEAVISO, V0RCOM_AGEAVISO);

            /*" -4486- MOVE WWORK-NRAVISO TO V0RCOM-NRAVISO */
            _.Move(WWORK_NRAVISO, V0RCOM_NRAVISO);

            /*" -4487- MOVE V0RCAP-VLRCAP TO V0RCOM-VLRCAP */
            _.Move(V0RCAP_VLRCAP, V0RCOM_VLRCAP);

            /*" -4488- MOVE V0RCAP-DTCADAST TO V0RCOM-DTCADAST */
            _.Move(V0RCAP_DTCADAST, V0RCOM_DTCADAST);

            /*" -4489- MOVE '0' TO V0RCOM-SITCONTB */
            _.Move("0", V0RCOM_SITCONTB);

            /*" -4491- MOVE V0RCAP-CODEMP TO V0RCOM-CODEMP. */
            _.Move(V0RCAP_CODEMP, V0RCOM_CODEMP);

            /*" -4492- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -4493- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA);

            /*" -4494- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT1);

            /*" -4495- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);

            /*" -4496- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT2);

            /*" -4497- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

            /*" -4499- MOVE WTIME-DAYR TO V0RCOM-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_37.WTIME_DAYR, V0RCOM_HORAOPER);

            /*" -4500- MOVE COBRAN-DTA-PAGAMENTO TO WDATA-SECULO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_PAGAMENTO, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4501- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4502- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4503- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4504- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4506- MOVE WDATA-TABELA TO V0RCOM-DATARCAP. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0RCOM_DATARCAP);

            /*" -4524- PERFORM R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1 */

            R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1();

            /*" -4527- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4528- DISPLAY 'R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ' */
                _.Display($"R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ");

                /*" -4530- MOVE 'R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ' TO W-MENSAGEM-ERRO */
                _.Move("R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ", W_MENSAGEM_ERRO);

                /*" -4531- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4531- END-IF. */
            }


        }

        [StopWatch]
        /*" R3750-INCLUI-V0RCAPCOMP-DB-INSERT-1 */
        public void R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -4524- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-NRRCAPCO , :V0RCOM-OPERACAO , :V0RCOM-DTMOVTO , :V0RCOM-HORAOPER , :V0RCOM-SITUACAO , :V0RCOM-BCOAVISO , :V0RCOM-AGEAVISO , :V0RCOM-NRAVISO , :V0RCOM-VLRCAP , :V0RCOM-DATARCAP , :V0RCOM-DTCADAST , :V0RCOM-SITCONTB , :V0RCOM-CODEMP :VIND-CODEMP, CURRENT TIMESTAMP) END-EXEC. */

            var r3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V0RCOM_FONTE = V0RCOM_FONTE.ToString(),
                V0RCOM_NRRCAP = V0RCOM_NRRCAP.ToString(),
                V0RCOM_NRRCAPCO = V0RCOM_NRRCAPCO.ToString(),
                V0RCOM_OPERACAO = V0RCOM_OPERACAO.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0RCOM_HORAOPER = V0RCOM_HORAOPER.ToString(),
                V0RCOM_SITUACAO = V0RCOM_SITUACAO.ToString(),
                V0RCOM_BCOAVISO = V0RCOM_BCOAVISO.ToString(),
                V0RCOM_AGEAVISO = V0RCOM_AGEAVISO.ToString(),
                V0RCOM_NRAVISO = V0RCOM_NRAVISO.ToString(),
                V0RCOM_VLRCAP = V0RCOM_VLRCAP.ToString(),
                V0RCOM_DATARCAP = V0RCOM_DATARCAP.ToString(),
                V0RCOM_DTCADAST = V0RCOM_DTCADAST.ToString(),
                V0RCOM_SITCONTB = V0RCOM_SITCONTB.ToString(),
                V0RCOM_CODEMP = V0RCOM_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3750_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_INCLUI_V0RCAPCOMP_EXIT*/

        [StopWatch]
        /*" R3800-INCLUI-CONVERSAO-SECTION */
        private void R3800_INCLUI_CONVERSAO_SECTION()
        {
            /*" -4540- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4541- DISPLAY W-PROGRAMA-CHAMADOR '-R3800-INCLUI-CONVERSAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3800-INCLUI-CONVERSAO");

                /*" -4544- END-IF */
            }


            /*" -4546- MOVE '3800' TO WNR-EXEC-SQL. */
            _.Move("3800", WABEND.WNR_EXEC_SQL);

            /*" -4568- PERFORM R3800_INCLUI_CONVERSAO_DB_INSERT_1 */

            R3800_INCLUI_CONVERSAO_DB_INSERT_1();

            /*" -4571- IF SQLCODE NOT = 000 AND -803 */

            if (!DB.SQLCODE.In("000", "-803"))
            {

                /*" -4572- DISPLAY 'R3800-PROBLEMAS INSERT (CONVERSAO)  ' */
                _.Display($"R3800-PROBLEMAS INSERT (CONVERSAO)  ");

                /*" -4573- DISPLAY 'NUM_PROPOSTA_SIVPF=' V0FILT-NUMSIVPF */
                _.Display($"NUM_PROPOSTA_SIVPF={V0FILT_NUMSIVPF}");

                /*" -4574- DISPLAY 'NUM_SICOB         =' V0FILT-NUMSICOB */
                _.Display($"NUM_SICOB         ={V0FILT_NUMSICOB}");

                /*" -4576- MOVE 'R3800-PROBLEMAS INSERT (CONVERSAO)  ' TO W-MENSAGEM-ERRO */
                _.Move("R3800-PROBLEMAS INSERT (CONVERSAO)  ", W_MENSAGEM_ERRO);

                /*" -4577- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4579- END-IF */
            }


            /*" -4580- IF SQLCODE = -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4584- DISPLAY 'R3800-INSERT CONVERSAO_SICOB = -803.' ' SQLERRMC=' SQLERRMC(1:20) ' NUM_PROPOSTA_SIVPF=' V0FILT-NUMSIVPF ' NUM_SICOB=' V0FILT-NUMSICOB */

                $"R3800-INSERT CONVERSAO_SICOB = -803. SQLERRMC=SQLERRMC(1:20) NUM_PROPOSTA_SIVPF={V0FILT_NUMSIVPF} NUM_SICOB={V0FILT_NUMSICOB}"
                .Display();

                /*" -4585- ADD 1 TO W-COUNT-INSERT */
                W_COUNT_INSERT.Value = W_COUNT_INSERT + 1;

                /*" -4586- IF W-COUNT-INSERT > 500 */

                if (W_COUNT_INSERT > 500)
                {

                    /*" -4588- DISPLAY 'R3800-PROGRAMA CANCELADO, MAIS DE 500 ' 'TENTATIVAS NO INSERT' */
                    _.Display($"R3800-PROGRAMA CANCELADO, MAIS DE 500 TENTATIVAS NO INSERT");

                    /*" -4590- MOVE 'R3800-INSERT CONVERSAO_SICOB = -803' TO W-MENSAGEM-ERRO */
                    _.Move("R3800-INSERT CONVERSAO_SICOB = -803", W_MENSAGEM_ERRO);

                    /*" -4591- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4592- END-IF */
                }


                /*" -4594- END-IF */
            }


            /*" -4595- IF SQLCODE = 000 */

            if (DB.SQLCODE == 000)
            {

                /*" -4596- ADD 1 TO IN-CONVERSAO */
                WS_AUX_ARQUIVO.IN_CONVERSAO.Value = WS_AUX_ARQUIVO.IN_CONVERSAO + 1;

                /*" -4597- END-IF */
            }


            /*" -4597- . */

        }

        [StopWatch]
        /*" R3800-INCLUI-CONVERSAO-DB-INSERT-1 */
        public void R3800_INCLUI_CONVERSAO_DB_INSERT_1()
        {
            /*" -4568- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB ( NUM_PROPOSTA_SIVPF , NUM_SICOB , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , AGEPGTO , DATA_OPERACAO , DATA_QUITACAO , VAL_RCAP , COD_USUARIO , TIMESTAMP ) VALUES (:V0FILT-NUMSIVPF , :V0FILT-NUMSICOB , :V0FILT-CODEMP , :V0FILT-CODSIVPF , :V0FILT-AGECOBR , :V0FILT-DTMOVTO , :V0FILT-DTQITBCO , :V0FILT-VLRCAP , :V0FILT-CODUSU , CURRENT TIMESTAMP) END-EXEC. */

            var r3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1 = new R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1()
            {
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
                V0FILT_NUMSICOB = V0FILT_NUMSICOB.ToString(),
                V0FILT_CODEMP = V0FILT_CODEMP.ToString(),
                V0FILT_CODSIVPF = V0FILT_CODSIVPF.ToString(),
                V0FILT_AGECOBR = V0FILT_AGECOBR.ToString(),
                V0FILT_DTMOVTO = V0FILT_DTMOVTO.ToString(),
                V0FILT_DTQITBCO = V0FILT_DTQITBCO.ToString(),
                V0FILT_VLRCAP = V0FILT_VLRCAP.ToString(),
                V0FILT_CODUSU = V0FILT_CODUSU.ToString(),
            };

            R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1.Execute(r3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_INCLUI_CONVERSAO_EXIT*/

        [StopWatch]
        /*" R3850-TRATA-DUPLICI-SICOB-SECTION */
        private void R3850_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -4605- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4607- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R3850-TRATA-DUPLICI-SICOB' */

                $"{W_PROGRAMA_CHAMADOR}-R3850-TRATA-DUPLICI-SICOB"
                .Display();

                /*" -4610- END-IF */
            }


            /*" -4612- MOVE '3850' TO WNR-EXEC-SQL */
            _.Move("3850", WABEND.WNR_EXEC_SQL);

            /*" -4614- PERFORM R3100-CALCULA-TITULO */

            R3100_CALCULA_TITULO_SECTION();

            /*" -4616- MOVE WWORK-MIN-NRTIT TO V0FILT-NUMSICOB WWORK-NSO-NUMERO */
            _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0FILT_NUMSICOB, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

            /*" -4618- PERFORM R3800-INCLUI-CONVERSAO */

            R3800_INCLUI_CONVERSAO_SECTION();

            /*" -4619- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4620- PERFORM R3860-UPDATE-V0RCAP THRU R3860-UPDATE-V0RCAP-EXIT */

                R3860_UPDATE_V0RCAP_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3860_UPDATE_V0RCAP_EXIT*/


                /*" -4620- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_TRATA_DUPLICI_SICOB_EXIT*/

        [StopWatch]
        /*" R3860-UPDATE-V0RCAP-SECTION */
        private void R3860_UPDATE_V0RCAP_SECTION()
        {
            /*" -4629- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4631- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R3860-UPDATE-V0RCAP' */

                $"{W_PROGRAMA_CHAMADOR}-R3860-UPDATE-V0RCAP"
                .Display();

                /*" -4634- END-IF */
            }


            /*" -4636- MOVE '3860' TO WNR-EXEC-SQL */
            _.Move("3860", WABEND.WNR_EXEC_SQL);

            /*" -4637- MOVE V0FILT-NUMSICOB TO V0RCAP-NRTIT. */
            _.Move(V0FILT_NUMSICOB, V0RCAP_NRTIT);

            /*" -4641- MOVE WWORK-NRRCAP TO V0RCAP-NRRCAP. */
            _.Move(WS_AUX_ARQUIVO.FILLER_15.WWORK_NRRCAP, V0RCAP_NRRCAP);

            /*" -4668- PERFORM R3860_UPDATE_V0RCAP_DB_INSERT_1 */

            R3860_UPDATE_V0RCAP_DB_INSERT_1();

            /*" -4671- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4672- DISPLAY 'R3860-00 - PROBLEMAS INSERT (V0RCAP) ' */
                _.Display($"R3860-00 - PROBLEMAS INSERT (V0RCAP) ");

                /*" -4674- MOVE 'R3860-00 - PROBLEMAS INSERT (V0RCAP) ' TO W-MENSAGEM-ERRO */
                _.Move("R3860-00 - PROBLEMAS INSERT (V0RCAP) ", W_MENSAGEM_ERRO);

                /*" -4675- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4679- END-IF. */
            }


            /*" -4684- PERFORM R3860_UPDATE_V0RCAP_DB_UPDATE_1 */

            R3860_UPDATE_V0RCAP_DB_UPDATE_1();

            /*" -4687- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4688- DISPLAY 'R3860-00 - PROBLEMAS UPDATE (V0RCAPCOMP) ' */
                _.Display($"R3860-00 - PROBLEMAS UPDATE (V0RCAPCOMP) ");

                /*" -4690- MOVE 'R3860-00 - PROBLEMAS UPDATE (V0RCAPCOMP) ' TO W-MENSAGEM-ERRO */
                _.Move("R3860-00 - PROBLEMAS UPDATE (V0RCAPCOMP) ", W_MENSAGEM_ERRO);

                /*" -4691- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4695- END-IF. */
            }


            /*" -4699- PERFORM R3860_UPDATE_V0RCAP_DB_DELETE_1 */

            R3860_UPDATE_V0RCAP_DB_DELETE_1();

            /*" -4702- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4703- DISPLAY 'R3860-00 - PROBLEMAS DELETE (V0RCAP) ' */
                _.Display($"R3860-00 - PROBLEMAS DELETE (V0RCAP) ");

                /*" -4705- MOVE 'R3860-00 - PROBLEMAS DELETE (V0RCAP) ' TO W-MENSAGEM-ERRO */
                _.Move("R3860-00 - PROBLEMAS DELETE (V0RCAP) ", W_MENSAGEM_ERRO);

                /*" -4706- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4708- END-IF. */
            }


            /*" -4708- MOVE V0RCAP-NRRCAP TO V0RCOM-NRRCAP. */
            _.Move(V0RCAP_NRRCAP, V0RCOM_NRRCAP);

        }

        [StopWatch]
        /*" R3860-UPDATE-V0RCAP-DB-INSERT-1 */
        public void R3860_UPDATE_V0RCAP_DB_INSERT_1()
        {
            /*" -4668- EXEC SQL INSERT INTO SEGUROS.V0RCAP (SELECT FONTE , :V0RCAP-NRRCAP , NRPROPOS , NOME , VLRCAP , VALPRI , DTCADAST , DTMOVTO , SITUACAO , OPERACAO , COD_EMPRESA , CURRENT TIMESTAMP , NUM_APOLICE , NRENDOS , NRPARCEL , :V0RCAP-NRTIT , CODPRODU , AGECOBR , RECUPERA , VLACRESCIMO , NRCERTIF FROM SEGUROS.V0RCAP WHERE FONTE = :V0RCOM-FONTE AND NRRCAP = :V0RCOM-NRRCAP) END-EXEC. */

            var r3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1 = new R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
                V0RCOM_FONTE = V0RCOM_FONTE.ToString(),
                V0RCOM_NRRCAP = V0RCOM_NRRCAP.ToString(),
            };

            R3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1.Execute(r3860_UPDATE_V0RCAP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R3860-UPDATE-V0RCAP-DB-UPDATE-1 */
        public void R3860_UPDATE_V0RCAP_DB_UPDATE_1()
        {
            /*" -4684- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET NRRCAP = :V0RCAP-NRRCAP WHERE FONTE = :V0RCOM-FONTE AND NRRCAP = :V0RCOM-NRRCAP END-EXEC. */

            var r3860_UPDATE_V0RCAP_DB_UPDATE_1_Update1 = new R3860_UPDATE_V0RCAP_DB_UPDATE_1_Update1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCOM_NRRCAP = V0RCOM_NRRCAP.ToString(),
                V0RCOM_FONTE = V0RCOM_FONTE.ToString(),
            };

            R3860_UPDATE_V0RCAP_DB_UPDATE_1_Update1.Execute(r3860_UPDATE_V0RCAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3860-UPDATE-V0RCAP-DB-DELETE-1 */
        public void R3860_UPDATE_V0RCAP_DB_DELETE_1()
        {
            /*" -4699- EXEC SQL DELETE FROM SEGUROS.V0RCAP WHERE FONTE = :V0RCOM-FONTE AND NRRCAP = :V0RCOM-NRRCAP END-EXEC. */

            var r3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1 = new R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1()
            {
                V0RCOM_FONTE = V0RCOM_FONTE.ToString(),
                V0RCOM_NRRCAP = V0RCOM_NRRCAP.ToString(),
            };

            R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1.Execute(r3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3860_UPDATE_V0RCAP_EXIT*/

        [StopWatch]
        /*" R3900-MONTA-V0FOLLOWUP-SECTION */
        private void R3900_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -4717- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4718- DISPLAY W-PROGRAMA-CHAMADOR '-R3900-MONTA-V0FOLLOWUP' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3900-MONTA-V0FOLLOWUP");

                /*" -4722- END-IF */
            }


            /*" -4724- MOVE '3900' TO WNR-EXEC-SQL. */
            _.Move("3900", WABEND.WNR_EXEC_SQL);

            /*" -4727- MOVE '2' TO WSHOST-SITUACAO. */
            _.Move("2", WSHOST_SITUACAO);

            /*" -4728- MOVE COBRAN-NUM-PROPOSTA TO V0MCOB-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, V0MCOB_NRTIT);

            /*" -4729- MOVE COBRAN-VLR-PAGO TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0MCOB_VALTIT);

            /*" -4730- MOVE COBRAN-VLR-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, V0MCOB_VLIOCC);

            /*" -4732- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -4738- COMPUTE V0MCOB-VALCDT = COBRAN-VLR-PAGO - COBRAN-VLR-IOF - COBRAN-VLR-DESCONTO - COBRAN-VLR-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PAGO - COBRAN_REGISTRO.COBRAN_VLR_IOF - COBRAN_REGISTRO.COBRAN_VLR_DESCONTO - COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO;

            /*" -4740- PERFORM R4050-INCLUI-V0MOVICOB. */

            R4050_INCLUI_V0MOVICOB_SECTION();

            /*" -4746- MOVE SPACES TO V0FOLL-CDERRO01 V0FOLL-CDERRO03 V0FOLL-CDERRO04 V0FOLL-CDERRO05 V0FOLL-CDERRO06. */
            _.Move("", V0FOLL_CDERRO01, V0FOLL_CDERRO03, V0FOLL_CDERRO04, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -4748- MOVE ZEROS TO AC-DUPLICA. */
            _.Move(0, WS_AUX_ARQUIVO.AC_DUPLICA);

            /*" -4750- PERFORM R4000-MONTA-V0FOLLOWUP. */

            R4000_MONTA_V0FOLLOWUP_SECTION();

            /*" -4750- PERFORM R4100-INCLUI-V0FOLLOWUP. */

            R4100_INCLUI_V0FOLLOWUP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_MONTA_V0FOLLOWUP_EXIT*/

        [StopWatch]
        /*" R3950-UPDATE-CONVERSAO-SECTION */
        private void R3950_UPDATE_CONVERSAO_SECTION()
        {
            /*" -4758- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4759- DISPLAY W-PROGRAMA-CHAMADOR '-R3950-UPDATE-CONVERSAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R3950-UPDATE-CONVERSAO");

                /*" -4763- END-IF */
            }


            /*" -4765- MOVE '3950' TO WNR-EXEC-SQL. */
            _.Move("3950", WABEND.WNR_EXEC_SQL);

            /*" -4766- IF (CONVSICOB-AGEPGTO EQUAL ZEROS) */

            if ((CONVSICOB_AGEPGTO == 00))
            {

                /*" -4767- MOVE V0FILT-AGECOBR TO CONVSICOB-AGEPGTO */
                _.Move(V0FILT_AGECOBR, CONVSICOB_AGEPGTO);

                /*" -4769- END-IF. */
            }


            /*" -4770- IF (CONVSICOB-DTQITBCO EQUAL '0001-01-01' ) */

            if ((CONVSICOB_DTQITBCO == "0001-01-01"))
            {

                /*" -4771- MOVE V0FILT-DTQITBCO TO CONVSICOB-DTQITBCO */
                _.Move(V0FILT_DTQITBCO, CONVSICOB_DTQITBCO);

                /*" -4773- END-IF. */
            }


            /*" -4775- MOVE V0FILT-VLRCAP TO CONVSICOB-VAL-RCAP. */
            _.Move(V0FILT_VLRCAP, CONVSICOB_VAL_RCAP);

            /*" -4781- PERFORM R3950_UPDATE_CONVERSAO_DB_UPDATE_1 */

            R3950_UPDATE_CONVERSAO_DB_UPDATE_1();

            /*" -4784- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4785- DISPLAY 'R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ' */
                _.Display($"R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ");

                /*" -4786- DISPLAY 'PROPOSTA SIVPF.........  ' V0FILT-NUMSIVPF */
                _.Display($"PROPOSTA SIVPF.........  {V0FILT_NUMSIVPF}");

                /*" -4787- DISPLAY 'SICOB..................  ' V0FILT-NUMSICOB */
                _.Display($"SICOB..................  {V0FILT_NUMSICOB}");

                /*" -4789- MOVE 'R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ' TO W-MENSAGEM-ERRO */
                _.Move("R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ", W_MENSAGEM_ERRO);

                /*" -4790- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4792- END-IF. */
            }


            /*" -4799- PERFORM R3950_UPDATE_CONVERSAO_DB_UPDATE_2 */

            R3950_UPDATE_CONVERSAO_DB_UPDATE_2();

            /*" -4802- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -4803- DISPLAY 'R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ ' */
                _.Display($"R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ ");

                /*" -4804- DISPLAY 'PROPOSTA SIVPF.........  ' V0FILT-NUMSIVPF */
                _.Display($"PROPOSTA SIVPF.........  {V0FILT_NUMSIVPF}");

                /*" -4805- DISPLAY 'SICOB..................  ' V0FILT-NUMSICOB */
                _.Display($"SICOB..................  {V0FILT_NUMSICOB}");

                /*" -4807- MOVE 'R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ ' TO W-MENSAGEM-ERRO */
                _.Move("R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ ", W_MENSAGEM_ERRO);

                /*" -4808- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4808- END-IF. */
            }


        }

        [StopWatch]
        /*" R3950-UPDATE-CONVERSAO-DB-UPDATE-1 */
        public void R3950_UPDATE_CONVERSAO_DB_UPDATE_1()
        {
            /*" -4781- EXEC SQL UPDATE SEGUROS.CONVERSAO_SICOB SET AGEPGTO = :CONVSICOB-AGEPGTO , DATA_QUITACAO = :CONVSICOB-DTQITBCO , VAL_RCAP = :CONVSICOB-VAL-RCAP WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF END-EXEC. */

            var r3950_UPDATE_CONVERSAO_DB_UPDATE_1_Update1 = new R3950_UPDATE_CONVERSAO_DB_UPDATE_1_Update1()
            {
                CONVSICOB_DTQITBCO = CONVSICOB_DTQITBCO.ToString(),
                CONVSICOB_VAL_RCAP = CONVSICOB_VAL_RCAP.ToString(),
                CONVSICOB_AGEPGTO = CONVSICOB_AGEPGTO.ToString(),
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            R3950_UPDATE_CONVERSAO_DB_UPDATE_1_Update1.Execute(r3950_UPDATE_CONVERSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3950_UPDATE_CONVERSAO_EXIT*/

        [StopWatch]
        /*" R3950-UPDATE-CONVERSAO-DB-UPDATE-2 */
        public void R3950_UPDATE_CONVERSAO_DB_UPDATE_2()
        {
            /*" -4799- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DATA_CREDITO = :V0RCOM-DTMOVTO , AGEPGTO = :CONVSICOB-AGEPGTO , DTQITBCO = :CONVSICOB-DTQITBCO , VAL_PAGO = :CONVSICOB-VAL-RCAP WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF END-EXEC. */

            var r3950_UPDATE_CONVERSAO_DB_UPDATE_2_Update1 = new R3950_UPDATE_CONVERSAO_DB_UPDATE_2_Update1()
            {
                CONVSICOB_DTQITBCO = CONVSICOB_DTQITBCO.ToString(),
                CONVSICOB_VAL_RCAP = CONVSICOB_VAL_RCAP.ToString(),
                CONVSICOB_AGEPGTO = CONVSICOB_AGEPGTO.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            R3950_UPDATE_CONVERSAO_DB_UPDATE_2_Update1.Execute(r3950_UPDATE_CONVERSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R4050-INCLUI-V0MOVICOB-SECTION */
        private void R4050_INCLUI_V0MOVICOB_SECTION()
        {
            /*" -4816- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4817- DISPLAY W-PROGRAMA-CHAMADOR '-R4050-INCLUI-V0MOVICOB' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R4050-INCLUI-V0MOVICOB");

                /*" -4821- END-IF */
            }


            /*" -4823- MOVE '4050' TO WNR-EXEC-SQL. */
            _.Move("4050", WABEND.WNR_EXEC_SQL);

            /*" -4824- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -4825- MOVE COBRAN-COD-MOVIMENTO TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_COD_MOVIMENTO, V0MCOB_CODMOV);

            /*" -4827- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -4828- MOVE WWORK-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(WWORK_NRAVISO, V0MCOB_NRAVISO);

            /*" -4829- MOVE WWORK-AVS-AGE TO WWORK-AGEAVISO */
            _.Move(FILLER_58.WWORK_AVS_AGE, WWORK_AGEAVISO);

            /*" -4830- MOVE 7 TO WWORK-TIP-AGE */
            _.Move(7, FILLER_57.WWORK_TIP_AGE);

            /*" -4832- MOVE WWORK-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(WWORK_AGEAVISO, V0MCOB_AGENCIA);

            /*" -4833- MOVE COBRAN-NSAC TO V0MCOB-NUMFITA */
            _.Move(COBRAN_REGISTRO.COBRAN_NSAC, V0MCOB_NUMFITA);

            /*" -4835- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -4836- MOVE COBRAN-VLR-PAGO TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PAGO, V0MCOB_VALTIT);

            /*" -4837- MOVE COBRAN-VLR-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_IOF, V0MCOB_VLIOCC);

            /*" -4839- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -4844- COMPUTE V0MCOB-VALCDT = COBRAN-VLR-PAGO - COBRAN-VLR-IOF - COBRAN-VLR-DESCONTO - COBRAN-VLR-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PAGO - COBRAN_REGISTRO.COBRAN_VLR_IOF - COBRAN_REGISTRO.COBRAN_VLR_DESCONTO - COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO;

            /*" -4845- MOVE AUX-NRENDOS TO V0MCOB-NRENDOS */
            _.Move(WS_AUX_ARQUIVO.AUX_NRENDOS, V0MCOB_NRENDOS);

            /*" -4846- MOVE AUX-NRO-PARC TO V0MCOB-NRPARCEL */
            _.Move(WS_AUX_ARQUIVO.FILLER_23.AUX_NRO_PARC, V0MCOB_NRPARCEL);

            /*" -4847- IF AUX-DESCRICAO NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.AUX_NOME.AUX_DESCRICAO.IsEmpty())
            {

                /*" -4848- MOVE AUX-NOME TO V0MCOB-NOME */
                _.Move(WS_AUX_ARQUIVO.AUX_NOME, V0MCOB_NOME);

                /*" -4849- END-IF */
            }


            /*" -4850- MOVE '2' TO V0MCOB-SITUACAO */
            _.Move("2", V0MCOB_SITUACAO);

            /*" -4852- MOVE COBRAN-TIPO-MOVIMENTO TO V0MCOB-TIPOMOV. */
            _.Move(COBRAN_REGISTRO.COBRAN_TIPO_MOVIMENTO, V0MCOB_TIPOMOV);

            /*" -4853- MOVE COBRAN-DTA-PAGAMENTO TO WDATA-SECULO */
            _.Move(COBRAN_REGISTRO.COBRAN_DTA_PAGAMENTO, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4854- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4855- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4856- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4857- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_35.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4859- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -4860- MOVE COBRAN-NN-REGISTRADO TO WS-NN-REG */
            _.Move(COBRAN_REGISTRO.COBRAN_NN_REGISTRADO, WS_AUX_ARQUIVO.WS_NN_REG);

            /*" -4862- MOVE WS-NN-REG-16P TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.WS_NN_REG_16P, V0MCOB_NUM_NOSSO_TITULO);

            /*" -4863- IF COBRAN-COD-CEDENTE = 696001 */

            if (COBRAN_REGISTRO.COBRAN_CEDENTE_R.COBRAN_COD_CEDENTE == 696001)
            {

                /*" -4864- MOVE ZEROS TO WS-NUMERO-TITULO */
                _.Move(0, WS_AUX_AVISO.WS_NUMERO_TITULO);

                /*" -4865- MOVE COBRAN-NUM-TITULO TO WS-NUMERO-TITULO */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_TITULO, WS_AUX_AVISO.WS_NUMERO_TITULO);

                /*" -4866- MOVE WS-NRO-TIT TO V0MCOB-NRTIT */
                _.Move(WS_AUX_AVISO.FILLER_40.WS_NRO_TIT, V0MCOB_NRTIT);

                /*" -4867- MOVE COBRAN-NUM-PROPOSTA TO V0MCOB-NUM-NOSSO-TITULO */
                _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, V0MCOB_NUM_NOSSO_TITULO);

                /*" -4869- END-IF */
            }


            /*" -4870- IF (AUX-APOLICE < 10000000000000) */

            if ((WS_AUX_ARQUIVO.AUX_APOLICE < 10000000000000))
            {

                /*" -4871- MOVE AUX-APOLICE TO V0MCOB-NUMAPOL */
                _.Move(WS_AUX_ARQUIVO.AUX_APOLICE, V0MCOB_NUMAPOL);

                /*" -4872- ELSE */
            }
            else
            {


                /*" -4873- MOVE AUX-NUMAPOL TO V0MCOB-NUMAPOL */
                _.Move(WS_AUX_ARQUIVO.FILLER_22.AUX_NUMAPOL, V0MCOB_NUMAPOL);

                /*" -4875- END-IF. */
            }


            /*" -4877- PERFORM R2690-INCLUI-V0MOVICOB. */

            R2690_INCLUI_V0MOVICOB_SECTION();

            /*" -4877- ADD 1 TO IN-COBRANCA. */
            WS_AUX_ARQUIVO.IN_COBRANCA.Value = WS_AUX_ARQUIVO.IN_COBRANCA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_INCLUI_V0MOVICOB_EXIT*/

        [StopWatch]
        /*" R4000-MONTA-V0FOLLOWUP-SECTION */
        private void R4000_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -4886- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4887- DISPLAY W-PROGRAMA-CHAMADOR '-R4000-MONTA-V0FOLLOWUP' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R4000-MONTA-V0FOLLOWUP");

                /*" -4891- END-IF */
            }


            /*" -4893- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -4894- IF (V0MCOB-NUMAPOL EQUAL ZEROS) */

            if ((V0MCOB_NUMAPOL == 00))
            {

                /*" -4895- MOVE V0MCOB-NRTIT TO V0FOLL-NUMAPOL */
                _.Move(V0MCOB_NRTIT, V0FOLL_NUMAPOL);

                /*" -4896- ELSE */
            }
            else
            {


                /*" -4897- MOVE V0MCOB-NUMAPOL TO V0FOLL-NUMAPOL */
                _.Move(V0MCOB_NUMAPOL, V0FOLL_NUMAPOL);

                /*" -4899- END-IF. */
            }


            /*" -4900- MOVE V0MCOB-NRENDOS TO V0FOLL-NRENDOS */
            _.Move(V0MCOB_NRENDOS, V0FOLL_NRENDOS);

            /*" -4901- MOVE V0MCOB-NRPARCEL TO V0FOLL-NRPARCEL */
            _.Move(V0MCOB_NRPARCEL, V0FOLL_NRPARCEL);

            /*" -4902- MOVE SPACES TO V0FOLL-DACPARC */
            _.Move("", V0FOLL_DACPARC);

            /*" -4903- MOVE V0MCOB-DTMOVTO TO V0FOLL-DTMOVTO */
            _.Move(V0MCOB_DTMOVTO, V0FOLL_DTMOVTO);

            /*" -4904- MOVE V0MCOB-VALTIT TO V0FOLL-VLPREMIO */
            _.Move(V0MCOB_VALTIT, V0FOLL_VLPREMIO);

            /*" -4905- MOVE V0MCOB-BANCO TO V0FOLL-BCOAVISO */
            _.Move(V0MCOB_BANCO, V0FOLL_BCOAVISO);

            /*" -4906- MOVE WWORK-AGEAVISO TO V0FOLL-AGEAVISO */
            _.Move(WWORK_AGEAVISO, V0FOLL_AGEAVISO);

            /*" -4907- MOVE V0MCOB-NRAVISO TO V0FOLL-NRAVISO */
            _.Move(V0MCOB_NRAVISO, V0FOLL_NRAVISO);

            /*" -4908- MOVE 30 TO V0FOLL-CODBAIXA */
            _.Move(30, V0FOLL_CODBAIXA);

            /*" -4909- MOVE '0' TO V0FOLL-SITUACAO */
            _.Move("0", V0FOLL_SITUACAO);

            /*" -4910- MOVE SPACES TO V0FOLL-SITCONTB */
            _.Move("", V0FOLL_SITCONTB);

            /*" -4911- MOVE 103 TO V0FOLL-OPERACAO */
            _.Move(103, V0FOLL_OPERACAO);

            /*" -4912- MOVE SPACES TO V0FOLL-DTLIBER */
            _.Move("", V0FOLL_DTLIBER);

            /*" -4913- MOVE V0MCOB-DTQITBCO TO V0FOLL-DTQITBCO */
            _.Move(V0MCOB_DTQITBCO, V0FOLL_DTQITBCO);

            /*" -4914- MOVE ZEROS TO V0FOLL-CODEMP */
            _.Move(0, V0FOLL_CODEMP);

            /*" -4915- MOVE '1' TO V0FOLL-TIPSGU */
            _.Move("1", V0FOLL_TIPSGU);

            /*" -4916- MOVE ZEROS TO V0FOLL-ORDLIDER */
            _.Move(0, V0FOLL_ORDLIDER);

            /*" -4917- MOVE V0MCOB-AGENCIA TO V0FOLL-CODLIDER */
            _.Move(V0MCOB_AGENCIA, V0FOLL_CODLIDER);

            /*" -4918- MOVE CONVEN-FONTE TO V0FOLL-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0FOLL_FONTE);

            /*" -4920- MOVE SPACES TO V0FOLL-APOLIDER. */
            _.Move("", V0FOLL_APOLIDER);

            /*" -4921- MOVE COBRAN-COD-PRODUTO TO AUX-CODPRODU */
            _.Move(COBRAN_REGISTRO.COBRAN_COD_PRODUTO, WS_AUX_ARQUIVO.AUX_ENDOSLID.AUX_CODPRODU);

            /*" -4922- MOVE SPACES TO AUX-CODPRODU-SPACE */
            _.Move("", WS_AUX_ARQUIVO.AUX_ENDOSLID.AUX_CODPRODU_SPACE);

            /*" -4924- MOVE AUX-ENDOSLID TO V0FOLL-ENDOSLID. */
            _.Move(WS_AUX_ARQUIVO.AUX_ENDOSLID, V0FOLL_ENDOSLID);

            /*" -4926- MOVE V0MCOB-NUM-NOSSO-TITULO TO V0FOLL-NUM-NOSSO-TITULO. */
            _.Move(V0MCOB_NUM_NOSSO_TITULO, V0FOLL_NUM_NOSSO_TITULO);

            /*" -4927- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -4928- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA);

            /*" -4929- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT1);

            /*" -4930- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);

            /*" -4931- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_2PT2);

            /*" -4932- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

            /*" -4934- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_37.WTIME_DAYR, V0FOLL_HORAOPER);

            /*" -4938- MOVE ZEROS TO VIND-CODEMP VIND-TIPSGU VIND-ENDOSLID. */
            _.Move(0, VIND_CODEMP, VIND_TIPSGU, VIND_ENDOSLID);

            /*" -4942- MOVE -1 TO VIND-DTLIBER VIND-ORDLIDER VIND-APOLIDER. */
            _.Move(-1, VIND_DTLIBER, VIND_ORDLIDER, VIND_APOLIDER);

            /*" -4943- IF (V0FOLL-CODLIDER NOT EQUAL ZEROS) */

            if ((V0FOLL_CODLIDER != 00))
            {

                /*" -4944- MOVE ZEROS TO VIND-CODLIDER */
                _.Move(0, VIND_CODLIDER);

                /*" -4945- ELSE */
            }
            else
            {


                /*" -4946- MOVE -1 TO VIND-CODLIDER */
                _.Move(-1, VIND_CODLIDER);

                /*" -4948- END-IF. */
            }


            /*" -4949- IF (V0FOLL-DTQITBCO NOT EQUAL ZEROS) */

            if ((V0FOLL_DTQITBCO != 00))
            {

                /*" -4950- MOVE ZEROS TO VIND-DTQITBCO */
                _.Move(0, VIND_DTQITBCO);

                /*" -4951- ELSE */
            }
            else
            {


                /*" -4952- MOVE -1 TO VIND-DTQITBCO */
                _.Move(-1, VIND_DTQITBCO);

                /*" -4954- END-IF. */
            }


            /*" -4955- IF (V0FOLL-FONTE NOT EQUAL ZEROS) */

            if ((V0FOLL_FONTE != 00))
            {

                /*" -4956- MOVE ZEROS TO VIND-FONTE */
                _.Move(0, VIND_FONTE);

                /*" -4957- ELSE */
            }
            else
            {


                /*" -4958- MOVE -1 TO VIND-FONTE */
                _.Move(-1, VIND_FONTE);

                /*" -4960- END-IF. */
            }


            /*" -4961- IF (V0FOLL-NRRCAP NOT EQUAL ZEROS) */

            if ((V0FOLL_NRRCAP != 00))
            {

                /*" -4962- MOVE ZEROS TO VIND-NRRCAP */
                _.Move(0, VIND_NRRCAP);

                /*" -4963- ELSE */
            }
            else
            {


                /*" -4964- MOVE -1 TO VIND-NRRCAP */
                _.Move(-1, VIND_NRRCAP);

                /*" -4964- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_MONTA_V0FOLLOWUP_EXIT*/

        [StopWatch]
        /*" R4100-INCLUI-V0FOLLOWUP-SECTION */
        private void R4100_INCLUI_V0FOLLOWUP_SECTION()
        {
            /*" -4973- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -4974- DISPLAY W-PROGRAMA-CHAMADOR '-R4100-INCLUI-V0FOLLOWUP' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R4100-INCLUI-V0FOLLOWUP");

                /*" -4978- END-IF */
            }


            /*" -4981- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WABEND.WNR_EXEC_SQL);

            /*" -5015- PERFORM R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1 */

            R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1();

            /*" -5018- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -5019- ADD 1 TO AC-DUPLICA */
                WS_AUX_ARQUIVO.AC_DUPLICA.Value = WS_AUX_ARQUIVO.AC_DUPLICA + 1;

                /*" -5020- IF (AC-DUPLICA < 10) */

                if ((WS_AUX_ARQUIVO.AC_DUPLICA < 10))
                {

                    /*" -5025- DISPLAY 'INSERT FOLLOW -803' AC-DUPLICA ' APOL ' V0FOLL-NUMAPOL ' ENDOS ' V0FOLL-NRENDOS ' NRPARC ' V0FOLL-NRPARCEL ' FONTE ' V0FOLL-FONTE */

                    $"INSERT FOLLOW -803{WS_AUX_ARQUIVO.AC_DUPLICA} APOL {V0FOLL_NUMAPOL} ENDOS {V0FOLL_NRENDOS} NRPARC {V0FOLL_NRPARCEL} FONTE {V0FOLL_FONTE}"
                    .Display();

                    /*" -5028- DISPLAY ' NRRCAP ' V0FOLL-NRRCAP ' NN ' V0FOLL-NUM-NOSSO-TITULO ' TIME ' V0FOLL-HORAOPER */

                    $" NRRCAP {V0FOLL_NRRCAP} NN {V0FOLL_NUM_NOSSO_TITULO} TIME {V0FOLL_HORAOPER}"
                    .Display();

                    /*" -5029- PERFORM R4110-ADICIONA-TIME */

                    R4110_ADICIONA_TIME_SECTION();

                    /*" -5030- GO TO R4100-INCLUI-V0FOLLOWUP */
                    new Task(() => R4100_INCLUI_V0FOLLOWUP_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -5031- ELSE */
                }
                else
                {


                    /*" -5036- DISPLAY 'R4100-01-PROBLEMA INSERT (V0FOLLOWUP) ' V0FOLL-NUMAPOL '  ' V0FOLL-NRENDOS '  ' V0FOLL-NRPARCEL '  ' V0FOLL-NRAVISO */

                    $"R4100-01-PROBLEMA INSERT (V0FOLLOWUP) {V0FOLL_NUMAPOL}  {V0FOLL_NRENDOS}  {V0FOLL_NRPARCEL}  {V0FOLL_NRAVISO}"
                    .Display();

                    /*" -5038- MOVE 'R4100-01-PROBLEMA INSERT (V0FOLLOWUP) ' TO W-MENSAGEM-ERRO */
                    _.Move("R4100-01-PROBLEMA INSERT (V0FOLLOWUP) ", W_MENSAGEM_ERRO);

                    /*" -5039- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5040- END-IF */
                }


                /*" -5041- ELSE */
            }
            else
            {


                /*" -5042- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -5047- DISPLAY 'R4100-02-PROBLEMA INSERT (V0FOLLOWUP) ' V0FOLL-NUMAPOL '  ' V0FOLL-NRENDOS '  ' V0FOLL-NRPARCEL '  ' V0FOLL-NRAVISO */

                    $"R4100-02-PROBLEMA INSERT (V0FOLLOWUP) {V0FOLL_NUMAPOL}  {V0FOLL_NRENDOS}  {V0FOLL_NRPARCEL}  {V0FOLL_NRAVISO}"
                    .Display();

                    /*" -5049- MOVE 'R4100-02-PROBLEMA INSERT (V0FOLLOWUP) ' TO W-MENSAGEM-ERRO */
                    _.Move("R4100-02-PROBLEMA INSERT (V0FOLLOWUP) ", W_MENSAGEM_ERRO);

                    /*" -5050- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5051- END-IF */
                }


                /*" -5053- END-IF. */
            }


            /*" -5053- ADD 1 TO IN-FOLLOWUP. */
            WS_AUX_ARQUIVO.IN_FOLLOWUP.Value = WS_AUX_ARQUIVO.IN_FOLLOWUP + 1;

        }

        [StopWatch]
        /*" R4100-INCLUI-V0FOLLOWUP-DB-INSERT-1 */
        public void R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1()
        {
            /*" -5015- EXEC SQL INSERT INTO SEGUROS.V0FOLLOWUP VALUES (:V0FOLL-NUMAPOL , :V0FOLL-NRENDOS , :V0FOLL-NRPARCEL , :V0FOLL-DACPARC , :V0FOLL-DTMOVTO , :V0FOLL-HORAOPER , :V0FOLL-VLPREMIO , :V0FOLL-BCOAVISO , :V0FOLL-AGEAVISO , :V0FOLL-NRAVISO , :V0FOLL-CODBAIXA , :V0FOLL-CDERRO01 , :V0FOLL-CDERRO02 , :V0FOLL-CDERRO03 , :V0FOLL-CDERRO04 , :V0FOLL-CDERRO05 , :V0FOLL-CDERRO06 , :V0FOLL-SITUACAO , :V0FOLL-SITCONTB , :V0FOLL-OPERACAO , :V0FOLL-DTLIBER :VIND-DTLIBER , :V0FOLL-DTQITBCO :VIND-DTQITBCO , :V0FOLL-CODEMP :VIND-CODEMP , CURRENT TIMESTAMP , :V0FOLL-ORDLIDER :VIND-ORDLIDER , :V0FOLL-TIPSGU :VIND-TIPSGU , :V0FOLL-APOLIDER :VIND-APOLIDER , :V0FOLL-ENDOSLID :VIND-ENDOSLID , :V0FOLL-CODLIDER :VIND-CODLIDER , :V0FOLL-FONTE :VIND-FONTE , :V0FOLL-NRRCAP :VIND-NRRCAP , :V0FOLL-NUM-NOSSO-TITULO) END-EXEC. */

            var r4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1 = new R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1()
            {
                V0FOLL_NUMAPOL = V0FOLL_NUMAPOL.ToString(),
                V0FOLL_NRENDOS = V0FOLL_NRENDOS.ToString(),
                V0FOLL_NRPARCEL = V0FOLL_NRPARCEL.ToString(),
                V0FOLL_DACPARC = V0FOLL_DACPARC.ToString(),
                V0FOLL_DTMOVTO = V0FOLL_DTMOVTO.ToString(),
                V0FOLL_HORAOPER = V0FOLL_HORAOPER.ToString(),
                V0FOLL_VLPREMIO = V0FOLL_VLPREMIO.ToString(),
                V0FOLL_BCOAVISO = V0FOLL_BCOAVISO.ToString(),
                V0FOLL_AGEAVISO = V0FOLL_AGEAVISO.ToString(),
                V0FOLL_NRAVISO = V0FOLL_NRAVISO.ToString(),
                V0FOLL_CODBAIXA = V0FOLL_CODBAIXA.ToString(),
                V0FOLL_CDERRO01 = V0FOLL_CDERRO01.ToString(),
                V0FOLL_CDERRO02 = V0FOLL_CDERRO02.ToString(),
                V0FOLL_CDERRO03 = V0FOLL_CDERRO03.ToString(),
                V0FOLL_CDERRO04 = V0FOLL_CDERRO04.ToString(),
                V0FOLL_CDERRO05 = V0FOLL_CDERRO05.ToString(),
                V0FOLL_CDERRO06 = V0FOLL_CDERRO06.ToString(),
                V0FOLL_SITUACAO = V0FOLL_SITUACAO.ToString(),
                V0FOLL_SITCONTB = V0FOLL_SITCONTB.ToString(),
                V0FOLL_OPERACAO = V0FOLL_OPERACAO.ToString(),
                V0FOLL_DTLIBER = V0FOLL_DTLIBER.ToString(),
                VIND_DTLIBER = VIND_DTLIBER.ToString(),
                V0FOLL_DTQITBCO = V0FOLL_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0FOLL_CODEMP = V0FOLL_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0FOLL_ORDLIDER = V0FOLL_ORDLIDER.ToString(),
                VIND_ORDLIDER = VIND_ORDLIDER.ToString(),
                V0FOLL_TIPSGU = V0FOLL_TIPSGU.ToString(),
                VIND_TIPSGU = VIND_TIPSGU.ToString(),
                V0FOLL_APOLIDER = V0FOLL_APOLIDER.ToString(),
                VIND_APOLIDER = VIND_APOLIDER.ToString(),
                V0FOLL_ENDOSLID = V0FOLL_ENDOSLID.ToString(),
                VIND_ENDOSLID = VIND_ENDOSLID.ToString(),
                V0FOLL_CODLIDER = V0FOLL_CODLIDER.ToString(),
                VIND_CODLIDER = VIND_CODLIDER.ToString(),
                V0FOLL_FONTE = V0FOLL_FONTE.ToString(),
                VIND_FONTE = VIND_FONTE.ToString(),
                V0FOLL_NRRCAP = V0FOLL_NRRCAP.ToString(),
                VIND_NRRCAP = VIND_NRRCAP.ToString(),
                V0FOLL_NUM_NOSSO_TITULO = V0FOLL_NUM_NOSSO_TITULO.ToString(),
            };

            R4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1.Execute(r4100_INCLUI_V0FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_INCLUI_V0FOLLOWUP_EXIT*/

        [StopWatch]
        /*" R4110-ADICIONA-TIME-SECTION */
        private void R4110_ADICIONA_TIME_SECTION()
        {
            /*" -5064- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5065- DISPLAY W-PROGRAMA-CHAMADOR '-R4110-ADICIONA-TIME' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R4110-ADICIONA-TIME");

                /*" -5069- END-IF */
            }


            /*" -5071- MOVE '4110' TO WNR-EXEC-SQL. */
            _.Move("4110", WABEND.WNR_EXEC_SQL);

            /*" -5073- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU > 00 && WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -5074- ADD 1 TO WTIME-SEGU */
                WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU.Value = WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -5075- ELSE */
            }
            else
            {


                /*" -5077- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU > 00 && WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -5078- ADD 1 TO WTIME-MINU */
                    WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU.Value = WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -5079- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

                    /*" -5080- ELSE */
                }
                else
                {


                    /*" -5082- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA > 00 && WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -5083- ADD 1 TO WTIME-HORA */
                        WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA.Value = WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -5085- MOVE 1 TO WTIME-MINU WTIME-SEGU */
                        _.Move(1, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);
                        _.Move(1, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);


                        /*" -5086- ELSE */
                    }
                    else
                    {


                        /*" -5090- MOVE 01 TO WTIME-HORA WTIME-MINU WTIME-SEGU. */
                        _.Move(01, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_HORA);
                        _.Move(01, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_MINU);
                        _.Move(01, WS_AUX_DATAS.FILLER_37.WTIME_DAYR.WTIME_SEGU);

                    }

                }

            }


            /*" -5090- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_37.WTIME_DAYR, V0FOLL_HORAOPER);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4110_ADICIONA_TIME_EXIT*/

        [StopWatch]
        /*" R4550-INCLUI-V0AVISOCRED-SECTION */
        private void R4550_INCLUI_V0AVISOCRED_SECTION()
        {
            /*" -5101- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5102- DISPLAY W-PROGRAMA-CHAMADOR '-R4550-INCLUI-V0AVISOCRED' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R4550-INCLUI-V0AVISOCRED");

                /*" -5105- END-IF */
            }


            /*" -5107- MOVE '4550' TO WNR-EXEC-SQL. */
            _.Move("4550", WABEND.WNR_EXEC_SQL);

            /*" -5111- MOVE WTABG-CODAGEAVISO(WS-CDT) TO WWORK-AVS-AGE WWORK-AGEAVISO AUX-AGE-AVISO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO, FILLER_58.WWORK_AVS_AGE);
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO, WWORK_AGEAVISO);
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO, WS_AUX_ARQUIVO.AUX_AGE_AVISO);


            /*" -5112- MOVE WTABG-ORIGAVISO(WS-CDT) TO WWORK-ORIGAVISO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_ORIGAVISO, WS_AUX_AVISO.WWORK_ORIGAVISO);

            /*" -5114- MOVE ZEROS TO V0DPCF-CODEMP. */
            _.Move(0, V0DPCF_CODEMP);

            /*" -5118- MOVE 104 TO V0DPCF-BCOAVISO WWORK-BCOAVISO V0AVIS-BCOAVISO. */
            _.Move(104, V0DPCF_BCOAVISO, WS_AUX_AVISO.WWORK_BCOAVISO, V0AVIS_BCOAVISO);

            /*" -5120- MOVE V0DPCF-AGEAVISO TO V0AVIS-AGEAVISO. */
            _.Move(V0DPCF_AGEAVISO, V0AVIS_AGEAVISO);

            /*" -5123- MOVE WWORK-NRAVISO TO V0DPCF-NRAVISO V0AVIS-NRAVISO. */
            _.Move(WWORK_NRAVISO, V0DPCF_NRAVISO, V0AVIS_NRAVISO);

            /*" -5124- MOVE '0' TO V0DPCF-TIPOCOB. */
            _.Move("0", V0DPCF_TIPOCOB);

            /*" -5125- MOVE V0SIST-DTMOVABE TO V0DPCF-DTMOVTO. */
            _.Move(V0SIST_DTMOVABE, V0DPCF_DTMOVTO);

            /*" -5127- MOVE WWORK-DTAVISO TO V0DPCF-DTAVISO. */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0DPCF_DTAVISO);

            /*" -5130- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -5131- MOVE WWORK-DTAVISO TO WDATA-REL. */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, WS_AUX_DATAS.WDATA_REL);

            /*" -5132- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF. */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -5134- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -5135- MOVE 1 TO V0AVIS-NRSEQ. */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -5136- MOVE V0SIST-DTMOVABE TO V0AVIS-DTMOVTO. */
            _.Move(V0SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -5138- MOVE 100 TO V0AVIS-OPERACAO. */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -5140- PERFORM R2500-SELECT-V0AVISOCRED. */

            R2500_SELECT_V0AVISOCRED_SECTION();

            /*" -5142- MOVE WWORK-AVS-AGE TO WWORK-AGEAVISO. */
            _.Move(FILLER_58.WWORK_AVS_AGE, WWORK_AGEAVISO);

            /*" -5143- IF (WWORK-TIP-AGE EQUAL 8) */

            if ((FILLER_57.WWORK_TIP_AGE == 8))
            {

                /*" -5144- MOVE 'R' TO WWORK-TIPAVI */
                _.Move("R", WS_AUX_AVISO.WWORK_TIPAVI);

                /*" -5145- ELSE */
            }
            else
            {


                /*" -5146- MOVE 'C' TO WWORK-TIPAVI */
                _.Move("C", WS_AUX_AVISO.WWORK_TIPAVI);

                /*" -5148- END-IF. */
            }


            /*" -5149- MOVE WWORK-TIPAVI TO V0AVIS-TIPAVI. */
            _.Move(WS_AUX_AVISO.WWORK_TIPAVI, V0AVIS_TIPAVI);

            /*" -5151- MOVE WWORK-DTAVISO TO V0AVIS-DTAVISO. */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0AVIS_DTAVISO);

            /*" -5157- MOVE ZEROS TO V0AVIS-VLIOCC V0AVIS-VLPRMTOT V0AVIS-VLPRMLIQ V0AVIS-VLDESPES V0AVIS-PRECED. */
            _.Move(0, V0AVIS_VLIOCC, V0AVIS_VLPRMTOT, V0AVIS_VLPRMLIQ, V0AVIS_VLDESPES, V0AVIS_PRECED);

            /*" -5158- MOVE V0DPCF-VLIOCC-TOT TO V0AVIS-VLIOCC. */
            _.Move(V0DPCF_VLIOCC_TOT, V0AVIS_VLIOCC);

            /*" -5159- MOVE V0DPCF-VLPRMTOT-TOT TO V0AVIS-VLPRMTOT. */
            _.Move(V0DPCF_VLPRMTOT_TOT, V0AVIS_VLPRMTOT);

            /*" -5160- MOVE V0DPCF-VLPRMLIQ-TOT TO V0AVIS-VLPRMLIQ. */
            _.Move(V0DPCF_VLPRMLIQ_TOT, V0AVIS_VLPRMLIQ);

            /*" -5162- MOVE V0DPCF-VLTARIFA-TOT TO V0AVIS-VLDESPES. */
            _.Move(V0DPCF_VLTARIFA_TOT, V0AVIS_VLDESPES);

            /*" -5163- MOVE '0' TO V0AVIS-SITCONTB. */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -5164- MOVE ZEROS TO V0AVIS-CODEMP. */
            _.Move(0, V0AVIS_CODEMP);

            /*" -5165- MOVE WWORK-ORIGAVISO TO V0AVIS-ORIGAVISO. */
            _.Move(WS_AUX_AVISO.WWORK_ORIGAVISO, V0AVIS_ORIGAVISO);

            /*" -5167- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -5171- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -5176- COMPUTE V0AVIS-VLPRMLIQ = V0AVIS-VLPRMTOT - V0AVIS-VLIOCC - V0AVIS-VLDESPES - V0AVIS-VALADT. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT - V0AVIS_VLIOCC - V0AVIS_VLDESPES - V0AVIS_VALADT;

            /*" -5178- MOVE 'P' TO V0AVIS-SITDEPTER. */
            _.Move("P", V0AVIS_SITDEPTER);

            /*" -5218- PERFORM R4550_INCLUI_V0AVISOCRED_DB_INSERT_1 */

            R4550_INCLUI_V0AVISOCRED_DB_INSERT_1();

            /*" -5221- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5222- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -5223- DISPLAY 'R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)' */
                _.Display($"R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)");

                /*" -5224- DISPLAY '--- PF2002B --- SQLCODE = ' WSQLCODE */
                _.Display($"--- PF2002B --- SQLCODE = {WABEND.WSQLCODE}");

                /*" -5235- DISPLAY 'BCAVSO ' V0AVIS-BCOAVISO ' AGAVSO ' V0AVIS-AGEAVISO ' NRAVSO ' V0AVIS-NRAVISO ' NRSEQ ' V0AVIS-NRSEQ ' DTMVTO ' V0AVIS-DTMOVTO ' OPER ' V0AVIS-OPERACAO ' TPAVI ' V0AVIS-TIPAVI ' DTAVI ' V0AVIS-DTAVISO ' VLIOC ' V0AVIS-VLIOCC ' VLDESP ' V0AVIS-VLDESPES ' PRECED ' V0AVIS-PRECED */

                $"BCAVSO {V0AVIS_BCOAVISO} AGAVSO {V0AVIS_AGEAVISO} NRAVSO {V0AVIS_NRAVISO} NRSEQ {V0AVIS_NRSEQ} DTMVTO {V0AVIS_DTMOVTO} OPER {V0AVIS_OPERACAO} TPAVI {V0AVIS_TIPAVI} DTAVI {V0AVIS_DTAVISO} VLIOC {V0AVIS_VLIOCC} VLDESP {V0AVIS_VLDESPES} PRECED {V0AVIS_PRECED}"
                .Display();

                /*" -5236- IF (SQLCODE NOT EQUAL -803) */

                if ((DB.SQLCODE != -803))
                {

                    /*" -5238- MOVE 'R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)' TO W-MENSAGEM-ERRO */
                    _.Move("R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)", W_MENSAGEM_ERRO);

                    /*" -5239- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5240- END-IF */
                }


                /*" -5240- END-IF. */
            }


        }

        [StopWatch]
        /*" R4550-INCLUI-V0AVISOCRED-DB-INSERT-1 */
        public void R4550_INCLUI_V0AVISOCRED_DB_INSERT_1()
        {
            /*" -5218- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED ( BCOAVISO, AGEAVISO, NRAVISO, NRSEQ, DTMOVTO, OPERACAO, TIPAVI, DTAVISO, VLIOCC, VLDESPES, PRECED, VLPRMLIQ, VLPRMTOT, SITCONTB, COD_EMPRESA, TIMESTAMP, ORIGAVISO, VALADT, SITDEPTER) VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP :VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO :VIND-ORIGAVISO , :V0AVIS-VALADT :VIND-VALADT , :V0AVIS-SITDEPTER) END-EXEC. */

            var r4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1 = new R4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
                V0AVIS_DTMOVTO = V0AVIS_DTMOVTO.ToString(),
                V0AVIS_OPERACAO = V0AVIS_OPERACAO.ToString(),
                V0AVIS_TIPAVI = V0AVIS_TIPAVI.ToString(),
                V0AVIS_DTAVISO = V0AVIS_DTAVISO.ToString(),
                V0AVIS_VLIOCC = V0AVIS_VLIOCC.ToString(),
                V0AVIS_VLDESPES = V0AVIS_VLDESPES.ToString(),
                V0AVIS_PRECED = V0AVIS_PRECED.ToString(),
                V0AVIS_VLPRMLIQ = V0AVIS_VLPRMLIQ.ToString(),
                V0AVIS_VLPRMTOT = V0AVIS_VLPRMTOT.ToString(),
                V0AVIS_SITCONTB = V0AVIS_SITCONTB.ToString(),
                V0AVIS_CODEMP = V0AVIS_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0AVIS_ORIGAVISO = V0AVIS_ORIGAVISO.ToString(),
                VIND_ORIGAVISO = VIND_ORIGAVISO.ToString(),
                V0AVIS_VALADT = V0AVIS_VALADT.ToString(),
                VIND_VALADT = VIND_VALADT.ToString(),
                V0AVIS_SITDEPTER = V0AVIS_SITDEPTER.ToString(),
            };

            R4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1.Execute(r4550_INCLUI_V0AVISOCRED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4550_INCLUI_V0AVISOCRED_EXIT*/

        [StopWatch]
        /*" R4600-INCLUI-V0AVISOSALDO-SECTION */
        private void R4600_INCLUI_V0AVISOSALDO_SECTION()
        {
            /*" -5250- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5252- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R4600-INCLUI-V0AVISOSALDO' */

                $"{W_PROGRAMA_CHAMADOR}-R4600-INCLUI-V0AVISOSALDO"
                .Display();

                /*" -5256- END-IF */
            }


            /*" -5258- MOVE '4600' TO WNR-EXEC-SQL. */
            _.Move("4600", WABEND.WNR_EXEC_SQL);

            /*" -5259- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -5260- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -5261- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -5262- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -5263- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -5264- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -5265- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -5266- MOVE '0' TO V0SALD-SITUACAO */
            _.Move("0", V0SALD_SITUACAO);

            /*" -5267- MOVE V0AVIS-VLPRMTOT TO V0SALD-SDOATU */
            _.Move(V0AVIS_VLPRMTOT, V0SALD_SDOATU);

            /*" -5271- MOVE ZEROS TO AD-QTDEBIL AD-VLRABIL. */
            _.Move(0, WS_AUX_ARQUIVO.AD_QTDEBIL, WS_AUX_ARQUIVO.AD_VLRABIL);

            /*" -5293- PERFORM R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1 */

            R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1();

            /*" -5296- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -5297- DISPLAY 'R4600-00 - REGISTRO DUPLICADO (V0AVISOSALD)' */
                _.Display($"R4600-00 - REGISTRO DUPLICADO (V0AVISOSALD)");

                /*" -5306- DISPLAY ' EMP ' V0SALD-CODEMP ' BCOAVSO ' V0SALD-BCOAVISO ' AGEAVSO ' V0SALD-AGEAVISO ' TPSGU ' V0SALD-TIPSGU ' NRAVIS ' V0SALD-NRAVISO ' DTAVIS ' V0SALD-DTAVISO ' DTMVTO ' V0SALD-DTMOVTO ' SLDO ' V0SALD-SDOATU ' SIT ' V0SALD-SITUACAO */

                $" EMP {V0SALD_CODEMP} BCOAVSO {V0SALD_BCOAVISO} AGEAVSO {V0SALD_AGEAVISO} TPSGU {V0SALD_TIPSGU} NRAVIS {V0SALD_NRAVISO} DTAVIS {V0SALD_DTAVISO} DTMVTO {V0SALD_DTMOVTO} SLDO {V0SALD_SDOATU} SIT {V0SALD_SITUACAO}"
                .Display();

                /*" -5307- GO TO R4600-INCLUI-V0AVISOSALDO-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_INCLUI_V0AVISOSALDO_EXIT*/ //GOTO
                return;

                /*" -5309- END-IF. */
            }


            /*" -5310- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5311- DISPLAY 'R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)' */
                _.Display($"R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)");

                /*" -5320- DISPLAY ' EMP ' V0SALD-CODEMP ' BCOAVSO ' V0SALD-BCOAVISO ' AGEAVSO ' V0SALD-AGEAVISO ' TPSGU ' V0SALD-TIPSGU ' NRAVIS ' V0SALD-NRAVISO ' DTAVIS ' V0SALD-DTAVISO ' DTMVTO ' V0SALD-DTMOVTO ' SLDO ' V0SALD-SDOATU ' SIT ' V0SALD-SITUACAO */

                $" EMP {V0SALD_CODEMP} BCOAVSO {V0SALD_BCOAVISO} AGEAVSO {V0SALD_AGEAVISO} TPSGU {V0SALD_TIPSGU} NRAVIS {V0SALD_NRAVISO} DTAVIS {V0SALD_DTAVISO} DTMVTO {V0SALD_DTMOVTO} SLDO {V0SALD_SDOATU} SIT {V0SALD_SITUACAO}"
                .Display();

                /*" -5322- MOVE 'R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)' TO W-MENSAGEM-ERRO */
                _.Move("R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)", W_MENSAGEM_ERRO);

                /*" -5323- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5323- END-IF. */
            }


        }

        [StopWatch]
        /*" R4600-INCLUI-V0AVISOSALDO-DB-INSERT-1 */
        public void R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1()
        {
            /*" -5293- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS (COD_EMPRESA , BCOAVISO , AGEAVISO , TIPSGU , NRAVISO , DTAVISO , DTMOVTO , SDOATU , SITUACAO , TIMESTAMP ) VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1 = new R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1()
            {
                V0SALD_CODEMP = V0SALD_CODEMP.ToString(),
                V0SALD_BCOAVISO = V0SALD_BCOAVISO.ToString(),
                V0SALD_AGEAVISO = V0SALD_AGEAVISO.ToString(),
                V0SALD_TIPSGU = V0SALD_TIPSGU.ToString(),
                V0SALD_NRAVISO = V0SALD_NRAVISO.ToString(),
                V0SALD_DTAVISO = V0SALD_DTAVISO.ToString(),
                V0SALD_DTMOVTO = V0SALD_DTMOVTO.ToString(),
                V0SALD_SDOATU = V0SALD_SDOATU.ToString(),
                V0SALD_SITUACAO = V0SALD_SITUACAO.ToString(),
            };

            R4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1.Execute(r4600_INCLUI_V0AVISOSALDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_INCLUI_V0AVISOSALDO_EXIT*/

        [StopWatch]
        /*" R4650-INCLUI-V0CONTROCNAB-SECTION */
        private void R4650_INCLUI_V0CONTROCNAB_SECTION()
        {
            /*" -5333- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5335- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R4650-INCLUI-V0CONTROCNAB' */

                $"{W_PROGRAMA_CHAMADOR}-R4650-INCLUI-V0CONTROCNAB"
                .Display();

                /*" -5339- END-IF */
            }


            /*" -5341- MOVE '4650' TO WNR-EXEC-SQL. */
            _.Move("4650", WABEND.WNR_EXEC_SQL);

            /*" -5342- MOVE ZEROS TO V0CNAB-COD-EMP */
            _.Move(0, V0CNAB_COD_EMP);

            /*" -5343- MOVE ZEROS TO V0CNAB-ORGAO */
            _.Move(0, V0CNAB_ORGAO);

            /*" -5344- MOVE 'A' TO V0CNAB-TIPOCOB */
            _.Move("A", V0CNAB_TIPOCOB);

            /*" -5345- MOVE WWORK-NRAVISO TO V0CNAB-NRCTACED */
            _.Move(WWORK_NRAVISO, V0CNAB_NRCTACED);

            /*" -5346- MOVE V0SIST-DTMOVABE TO V0CNAB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0CNAB_DTMOVTO);

            /*" -5347- MOVE WWORK-DTAVISO TO V0CNAB-DATCEF */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0CNAB_DATCEF);

            /*" -5348- MOVE WWORK-AVS-NRO TO V0CNAB-NRSEQ */
            _.Move(FILLER_58.WWORK_AVS_NRO, V0CNAB_NRSEQ);

            /*" -5351- MOVE V0DPCF-QTDREG-TOT TO V0CNAB-QTDREG. */
            _.Move(V0DPCF_QTDREG_TOT, V0CNAB_QTDREG);

            /*" -5363- PERFORM R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1 */

            R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1();

            /*" -5366- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -5371- DISPLAY 'R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB)' ' ' V0CNAB-ORGAO ' ' V0CNAB-NRCTACED ' ' V0CNAB-TIPOCOB ' ' V0CNAB-DTMOVTO */

                $"R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB) {V0CNAB_ORGAO} {V0CNAB_NRCTACED} {V0CNAB_TIPOCOB} {V0CNAB_DTMOVTO}"
                .Display();

                /*" -5373- MOVE 'R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB)' TO W-MENSAGEM-ERRO */
                _.Move("R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB)", W_MENSAGEM_ERRO);

                /*" -5374- GO TO R4650-INCLUI-V0CONTROCNAB-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4650_INCLUI_V0CONTROCNAB_EXIT*/ //GOTO
                return;

                /*" -5376- END-IF. */
            }


            /*" -5377- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5382- DISPLAY 'R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB)' ' ' V0CNAB-ORGAO ' ' V0CNAB-NRCTACED ' ' V0CNAB-TIPOCOB ' ' V0CNAB-DTMOVTO */

                $"R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB) {V0CNAB_ORGAO} {V0CNAB_NRCTACED} {V0CNAB_TIPOCOB} {V0CNAB_DTMOVTO}"
                .Display();

                /*" -5384- MOVE 'R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB)' TO W-MENSAGEM-ERRO */
                _.Move("R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB)", W_MENSAGEM_ERRO);

                /*" -5385- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5385- END-IF. */
            }


        }

        [StopWatch]
        /*" R4650-INCLUI-V0CONTROCNAB-DB-INSERT-1 */
        public void R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1()
        {
            /*" -5363- EXEC SQL INSERT INTO SEGUROS.V0CONTROCNAB VALUES (:V0CNAB-COD-EMP , :V0CNAB-ORGAO , :V0CNAB-NRCTACED , :V0CNAB-TIPOCOB , :V0CNAB-DTMOVTO , :V0CNAB-DATCEF , :V0CNAB-NRSEQ , :V0CNAB-QTDREG , CURRENT TIMESTAMP) END-EXEC. */

            var r4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1 = new R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1()
            {
                V0CNAB_COD_EMP = V0CNAB_COD_EMP.ToString(),
                V0CNAB_ORGAO = V0CNAB_ORGAO.ToString(),
                V0CNAB_NRCTACED = V0CNAB_NRCTACED.ToString(),
                V0CNAB_TIPOCOB = V0CNAB_TIPOCOB.ToString(),
                V0CNAB_DTMOVTO = V0CNAB_DTMOVTO.ToString(),
                V0CNAB_DATCEF = V0CNAB_DATCEF.ToString(),
                V0CNAB_NRSEQ = V0CNAB_NRSEQ.ToString(),
                V0CNAB_QTDREG = V0CNAB_QTDREG.ToString(),
            };

            R4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1.Execute(r4650_INCLUI_V0CONTROCNAB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4650_INCLUI_V0CONTROCNAB_EXIT*/

        [StopWatch]
        /*" R6500-TARIFA-BALCAO-SECTION */
        private void R6500_TARIFA_BALCAO_SECTION()
        {
            /*" -5395- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5396- DISPLAY W-PROGRAMA-CHAMADOR '-R6500-TARIFA-BALCAO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R6500-TARIFA-BALCAO");

                /*" -5400- END-IF */
            }


            /*" -5402- MOVE '6500' TO WNR-EXEC-SQL. */
            _.Move("6500", WABEND.WNR_EXEC_SQL);

            /*" -5403- MOVE ZEROS TO V0TRBL-CODEMP */
            _.Move(0, V0TRBL_CODEMP);

            /*" -5404- MOVE 9999999 TO V0TRBL-MATRICULA */
            _.Move(9999999, V0TRBL_MATRICULA);

            /*" -5406- MOVE '5' TO V0TRBL-TIPOFUNC */
            _.Move("5", V0TRBL_TIPOFUNC);

            /*" -5408- MOVE COBRAN-NUM-PROPOSTA TO AUX-USO-EMPRESA. */
            _.Move(COBRAN_REGISTRO.COBRAN_NUM_PROPOSTA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -5410- MOVE AUX-TITSIVPF TO V0TRBL-NRCERTIF */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0TRBL_NRCERTIF);

            /*" -5411- MOVE V0SIST-DTMOVABE TO V0TRBL-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0TRBL_DTMOVTO);

            /*" -5412- MOVE CONVEN-CODPRODU TO V0TRBL-CODPRODU */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0TRBL_CODPRODU);

            /*" -5413- MOVE '0' TO V0TRBL-SITUACAO */
            _.Move("0", V0TRBL_SITUACAO);

            /*" -5414- MOVE V0AVIS-BCOAVISO TO V0TRBL-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0TRBL_BCOAVISO);

            /*" -5415- MOVE V0AVIS-AGEAVISO TO V0TRBL-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0TRBL_AGEAVISO);

            /*" -5416- MOVE V0AVIS-NRAVISO TO V0TRBL-NRAVISO. */
            _.Move(V0AVIS_NRAVISO, V0TRBL_NRAVISO);

            /*" -5417- MOVE CONVEN-FONTE TO V0TRBL-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0TRBL_FONTE);

            /*" -5418- MOVE CONVEN-AGECOBR TO V0TRBL-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0TRBL_AGECOBR);

            /*" -5420- MOVE CONVEN-ESCNEG TO V0TRBL-ESCNEG. */
            _.Move(WS_AUX_ARQUIVO.CONVEN_ESCNEG, V0TRBL_ESCNEG);

            /*" -5421- MOVE COBRAN-VLR-TARIFA TO V0TRBL-TARIFA */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_TARIFA, V0TRBL_TARIFA);

            /*" -5423- MOVE COBRAN-VLR-ABATIMENTO TO V0TRBL-BALCAO. */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO, V0TRBL_BALCAO);

            /*" -5423- PERFORM R6700-INCLUI-TARIFA-BALCAO. */

            R6700_INCLUI_TARIFA_BALCAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_TARIFA_BALCAO_EXIT*/

        [StopWatch]
        /*" R6700-INCLUI-TARIFA-BALCAO-SECTION */
        private void R6700_INCLUI_TARIFA_BALCAO_SECTION()
        {
            /*" -5433- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5435- DISPLAY W-PROGRAMA-CHAMADOR '-' 'R6700-INCLUI-TARIFA-BALCAO' */

                $"{W_PROGRAMA_CHAMADOR}-R6700-INCLUI-TARIFA-BALCAO"
                .Display();

                /*" -5439- END-IF */
            }


            /*" -5442- MOVE '6700' TO WNR-EXEC-SQL. */
            _.Move("6700", WABEND.WNR_EXEC_SQL);

            /*" -5460- PERFORM R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1 */

            R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1();

            /*" -5464- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5465- DISPLAY 'R6700-00 - PROBLEMAS INSERT (TARIFA)     ' */
                _.Display($"R6700-00 - PROBLEMAS INSERT (TARIFA)     ");

                /*" -5466- DISPLAY ' V0TRBL-CODEMP     ' V0TRBL-CODEMP */
                _.Display($" V0TRBL-CODEMP     {V0TRBL_CODEMP}");

                /*" -5467- DISPLAY ' V0TRBL-MATRICULA  ' V0TRBL-MATRICULA */
                _.Display($" V0TRBL-MATRICULA  {V0TRBL_MATRICULA}");

                /*" -5468- DISPLAY ' V0TRBL-TIPOFUNC   ' V0TRBL-TIPOFUNC */
                _.Display($" V0TRBL-TIPOFUNC   {V0TRBL_TIPOFUNC}");

                /*" -5469- DISPLAY ' V0TRBL-NRCERTIF   ' V0TRBL-NRCERTIF */
                _.Display($" V0TRBL-NRCERTIF   {V0TRBL_NRCERTIF}");

                /*" -5470- DISPLAY ' V0TRBL-DTMOVTO    ' V0TRBL-DTMOVTO */
                _.Display($" V0TRBL-DTMOVTO    {V0TRBL_DTMOVTO}");

                /*" -5471- DISPLAY ' V0TRBL-CODPRODU   ' V0TRBL-CODPRODU */
                _.Display($" V0TRBL-CODPRODU   {V0TRBL_CODPRODU}");

                /*" -5472- DISPLAY ' V0TRBL-SITUACAO   ' V0TRBL-SITUACAO */
                _.Display($" V0TRBL-SITUACAO   {V0TRBL_SITUACAO}");

                /*" -5473- DISPLAY ' V0TRBL-FONTE      ' V0TRBL-FONTE */
                _.Display($" V0TRBL-FONTE      {V0TRBL_FONTE}");

                /*" -5474- DISPLAY ' V0TRBL-ESCNEG     ' V0TRBL-ESCNEG */
                _.Display($" V0TRBL-ESCNEG     {V0TRBL_ESCNEG}");

                /*" -5475- DISPLAY ' V0TRBL-AGECOBR    ' V0TRBL-AGECOBR */
                _.Display($" V0TRBL-AGECOBR    {V0TRBL_AGECOBR}");

                /*" -5476- DISPLAY ' V0TRBL-BCOAVISO   ' V0TRBL-BCOAVISO */
                _.Display($" V0TRBL-BCOAVISO   {V0TRBL_BCOAVISO}");

                /*" -5477- DISPLAY ' V0TRBL-AGEAVISO   ' V0TRBL-AGEAVISO */
                _.Display($" V0TRBL-AGEAVISO   {V0TRBL_AGEAVISO}");

                /*" -5478- DISPLAY ' V0TRBL-NRAVISO    ' V0TRBL-NRAVISO */
                _.Display($" V0TRBL-NRAVISO    {V0TRBL_NRAVISO}");

                /*" -5479- DISPLAY ' V0TRBL-TARIFA     ' V0TRBL-TARIFA */
                _.Display($" V0TRBL-TARIFA     {V0TRBL_TARIFA}");

                /*" -5480- DISPLAY ' V0TRBL-BALCAO     ' V0TRBL-BALCAO */
                _.Display($" V0TRBL-BALCAO     {V0TRBL_BALCAO}");

                /*" -5481- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5481- END-IF. */
            }


        }

        [StopWatch]
        /*" R6700-INCLUI-TARIFA-BALCAO-DB-INSERT-1 */
        public void R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1()
        {
            /*" -5460- EXEC SQL INSERT INTO SEGUROS.TARIFA_BALCAO_CEF VALUES (:V0TRBL-CODEMP , :V0TRBL-MATRICULA , :V0TRBL-TIPOFUNC , :V0TRBL-NRCERTIF , :V0TRBL-DTMOVTO , :V0TRBL-CODPRODU , :V0TRBL-SITUACAO , :V0TRBL-FONTE , :V0TRBL-ESCNEG , :V0TRBL-AGECOBR , :V0TRBL-BCOAVISO , :V0TRBL-AGEAVISO , :V0TRBL-NRAVISO , :V0TRBL-TARIFA , :V0TRBL-BALCAO , CURRENT TIMESTAMP) END-EXEC. */

            var r6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1 = new R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1()
            {
                V0TRBL_CODEMP = V0TRBL_CODEMP.ToString(),
                V0TRBL_MATRICULA = V0TRBL_MATRICULA.ToString(),
                V0TRBL_TIPOFUNC = V0TRBL_TIPOFUNC.ToString(),
                V0TRBL_NRCERTIF = V0TRBL_NRCERTIF.ToString(),
                V0TRBL_DTMOVTO = V0TRBL_DTMOVTO.ToString(),
                V0TRBL_CODPRODU = V0TRBL_CODPRODU.ToString(),
                V0TRBL_SITUACAO = V0TRBL_SITUACAO.ToString(),
                V0TRBL_FONTE = V0TRBL_FONTE.ToString(),
                V0TRBL_ESCNEG = V0TRBL_ESCNEG.ToString(),
                V0TRBL_AGECOBR = V0TRBL_AGECOBR.ToString(),
                V0TRBL_BCOAVISO = V0TRBL_BCOAVISO.ToString(),
                V0TRBL_AGEAVISO = V0TRBL_AGEAVISO.ToString(),
                V0TRBL_NRAVISO = V0TRBL_NRAVISO.ToString(),
                V0TRBL_TARIFA = V0TRBL_TARIFA.ToString(),
                V0TRBL_BALCAO = V0TRBL_BALCAO.ToString(),
            };

            R6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1.Execute(r6700_INCLUI_TARIFA_BALCAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6700_INCLUI_TARIFA_BALC_EXIT*/

        [StopWatch]
        /*" R7000-TRATA-ADIANTA-SECTION */
        private void R7000_TRATA_ADIANTA_SECTION()
        {
            /*" -5488- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5489- DISPLAY W-PROGRAMA-CHAMADOR '-R7000-TRATA-ADIANTA' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R7000-TRATA-ADIANTA");

                /*" -5492- END-IF */
            }


            /*" -5498- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", WABEND.WNR_EXEC_SQL);

            /*" -5498- GO TO R7000-TRATA-ADIANTA-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_TRATA_ADIANTA_EXIT*/ //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_TRATA_ADIANTA_EXIT*/

        [StopWatch]
        /*" R7050-SELECT-PROPOSTA-SECTION */
        private void R7050_SELECT_PROPOSTA_SECTION()
        {
            /*" -5609- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5610- DISPLAY W-PROGRAMA-CHAMADOR '-R7050-SELECT-PROPOSTA' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R7050-SELECT-PROPOSTA");

                /*" -5613- END-IF */
            }


            /*" -5615- MOVE '7050' TO WNR-EXEC-SQL. */
            _.Move("7050", WABEND.WNR_EXEC_SQL);

            /*" -5617- MOVE 'NAO' TO WTEM-PROPOSTA. */
            _.Move("NAO", WS_AUX_ARQUIVO.WTEM_PROPOSTA);

            /*" -5619- INITIALIZE PROPOSTA-COD-PRODUTO */
            _.Initialize(
                PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO
            );

            /*" -5629- PERFORM R7050_SELECT_PROPOSTA_DB_SELECT_1 */

            R7050_SELECT_PROPOSTA_DB_SELECT_1();

            /*" -5632- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5633- MOVE 'SIM' TO WTEM-PROPOSTA */
                _.Move("SIM", WS_AUX_ARQUIVO.WTEM_PROPOSTA);

                /*" -5634- GO TO R7050-SELECT-PROPOSTA-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_SELECT_PROPOSTA_EXIT*/ //GOTO
                return;

                /*" -5635- ELSE */
            }
            else
            {


                /*" -5636- IF (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 100))
                {

                    /*" -5637- DISPLAY '-----------------------' */
                    _.Display($"-----------------------");

                    /*" -5639- DISPLAY 'R7050-00 - PROPOSTA (1) ' 'PROPOSTA : ' PROPOAUT-NUM-PROPOSTA-CONV */

                    $"R7050-00 - PROPOSTA (1) PROPOSTA : {PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV}"
                    .Display();

                    /*" -5640- DISPLAY '-----------------------' */
                    _.Display($"-----------------------");

                    /*" -5642- MOVE 'R7050-00 - PROPOSTA (1) ' TO W-MENSAGEM-ERRO */
                    _.Move("R7050-00 - PROPOSTA (1) ", W_MENSAGEM_ERRO);

                    /*" -5643- GO TO R9999-ROT-ERRO */

                    R9999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5645- END-IF */
                }


                /*" -5651- PERFORM R7050_SELECT_PROPOSTA_DB_SELECT_2 */

                R7050_SELECT_PROPOSTA_DB_SELECT_2();

                /*" -5654- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -5655- MOVE 'SIM' TO WTEM-PROPOSTA */
                    _.Move("SIM", WS_AUX_ARQUIVO.WTEM_PROPOSTA);

                    /*" -5656- ELSE */
                }
                else
                {


                    /*" -5657- IF (SQLCODE NOT EQUAL 100) */

                    if ((DB.SQLCODE != 100))
                    {

                        /*" -5658- DISPLAY '-----------------------' */
                        _.Display($"-----------------------");

                        /*" -5660- DISPLAY 'R7050-00 - PROPOSTA (2) ' 'PROPOSTA : ' PROPOAUT-NUM-PROPOSTA-CONV */

                        $"R7050-00 - PROPOSTA (2) PROPOSTA : {PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV}"
                        .Display();

                        /*" -5661- DISPLAY '-----------------------' */
                        _.Display($"-----------------------");

                        /*" -5663- MOVE 'R7050-00 - PROPOSTA (2) ' TO W-MENSAGEM-ERRO */
                        _.Move("R7050-00 - PROPOSTA (2) ", W_MENSAGEM_ERRO);

                        /*" -5664- GO TO R9999-ROT-ERRO */

                        R9999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5665- END-IF */
                    }


                    /*" -5666- END-IF */
                }


                /*" -5666- END-IF. */
            }


        }

        [StopWatch]
        /*" R7050-SELECT-PROPOSTA-DB-SELECT-1 */
        public void R7050_SELECT_PROPOSTA_DB_SELECT_1()
        {
            /*" -5629- EXEC SQL SELECT P.COD_PRODUTO INTO :PROPOSTA-COD-PRODUTO FROM SEGUROS.PROPOSTA_AUTO A, SEGUROS.PROPOSTAS P WHERE A.NUM_PROPOSTA_CONV = :PROPOAUT-NUM-PROPOSTA-CONV AND P.NUM_PROPOSTA = A.NUM_PROPOSTA AND P.COD_FONTE = A.COD_FONTE AND A.NUM_ITEM = 101 WITH UR END-EXEC. */

            var r7050_SELECT_PROPOSTA_DB_SELECT_1_Query1 = new R7050_SELECT_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOAUT_NUM_PROPOSTA_CONV = PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV.ToString(),
            };

            var executed_1 = R7050_SELECT_PROPOSTA_DB_SELECT_1_Query1.Execute(r7050_SELECT_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_COD_PRODUTO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_SELECT_PROPOSTA_EXIT*/

        [StopWatch]
        /*" R7050-SELECT-PROPOSTA-DB-SELECT-2 */
        public void R7050_SELECT_PROPOSTA_DB_SELECT_2()
        {
            /*" -5651- EXEC SQL SELECT P.COD_PRODUTO INTO :PROPOSTA-COD-PRODUTO FROM SEGUROS.AU_VENDA_ONLINE P WHERE P.NUM_PROPOSTA_CONV = :PROPOAUT-NUM-PROPOSTA-CONV WITH UR END-EXEC */

            var r7050_SELECT_PROPOSTA_DB_SELECT_2_Query1 = new R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPOAUT_NUM_PROPOSTA_CONV = PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV.ToString(),
            };

            var executed_1 = R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1.Execute(r7050_SELECT_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_COD_PRODUTO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R7500-UPDATE-V0CEDENTE-SECTION */
        private void R7500_UPDATE_V0CEDENTE_SECTION()
        {
            /*" -5787- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5788- DISPLAY W-PROGRAMA-CHAMADOR '-R7500-UPDATE-V0CEDENTE' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R7500-UPDATE-V0CEDENTE");

                /*" -5792- END-IF */
            }


            /*" -5794- MOVE '7500' TO WNR-EXEC-SQL. */
            _.Move("7500", WABEND.WNR_EXEC_SQL);

            /*" -5796- MOVE WWORK-MIN-NRTIT TO V0CEDE-NUMTIT. */
            _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0CEDE_NUMTIT);

            /*" -5800- PERFORM R7500_UPDATE_V0CEDENTE_DB_UPDATE_1 */

            R7500_UPDATE_V0CEDENTE_DB_UPDATE_1();

            /*" -5803- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5804- DISPLAY 'R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' */
                _.Display($"R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ");

                /*" -5806- MOVE 'R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' TO W-MENSAGEM-ERRO */
                _.Move("R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ", W_MENSAGEM_ERRO);

                /*" -5807- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5807- END-IF. */
            }


        }

        [StopWatch]
        /*" R7500-UPDATE-V0CEDENTE-DB-UPDATE-1 */
        public void R7500_UPDATE_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -5800- EXEC SQL UPDATE SEGUROS.V0CEDENTE SET NUMTIT = :V0CEDE-NUMTIT WHERE CODCDT = 26 END-EXEC. */

            var r7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 = new R7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                V0CEDE_NUMTIT = V0CEDE_NUMTIT.ToString(),
            };

            R7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r7500_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_UPDATE_V0CEDENTE_EXIT*/

        [StopWatch]
        /*" R8000-SUMARIZA-AVISOS-SECTION */
        private void R8000_SUMARIZA_AVISOS_SECTION()
        {
            /*" -5816- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5817- DISPLAY W-PROGRAMA-CHAMADOR '-R8000-SUMARIZA-AVISOS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R8000-SUMARIZA-AVISOS");

                /*" -5821- END-IF */
            }


            /*" -5823- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -5824- MOVE ZEROS TO WS-SUBS3 */
            _.Move(0, WS_AUX_ARQUIVO.WS_SUBS3);

            /*" -5826- SET WS-CDT TO 1 */
            WS_CDT.Value = 1;

            /*" -5827- SEARCH WTABG-OCORRECED */
            for (; WS_CDT < WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED.Items.Count; WS_CDT.Value++)
            {

                /*" -5828- WHEN COBRAN-AGE-AVISO EQUAL WTABG-CODAGEAVISO(WS-CDT) */

                if (COBRAN_REGISTRO.COBRAN_AGE_AVISO == WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO)
                {


                    /*" -5829- SET WS-SUBS3 TO WS-CDT */
                    WS_AUX_ARQUIVO.WS_SUBS3.Value = WS_CDT;

                    /*" -5829- END-SEARCH. */
                    break;
                }
            }


            /*" -5832- IF (WS-SUBS3 EQUAL ZEROS) */

            if ((WS_AUX_ARQUIVO.WS_SUBS3 == 00))
            {

                /*" -5833- SET WS-CDT TO 18 */
                WS_CDT.Value = 18;

                /*" -5835- END-IF. */
            }


            /*" -5836- MOVE ZEROS TO WS-SUBS. */
            _.Move(0, WS_AUX_ARQUIVO.WS_SUBS);

            /*" -5838- SET WS-PRO TO 1 */
            WS_PRO.Value = 1;

            /*" -5839- SEARCH WTABG-OCORREPRD */
            for (; WS_PRO < WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD.Items.Count; WS_PRO.Value++)
            {

                /*" -5840- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-CDT WS-PRO) */

                if (WSHOST_CODPRODU == WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU)
                {


                    /*" -5841- SET WS-SUBS TO WS-PRO */
                    WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRO;

                    /*" -5841- END-SEARCH. */
                    break;
                }
            }


            /*" -5845- IF (WS-SUBS EQUAL ZEROS) OR (WS-SUBS > 2000) */

            if ((WS_AUX_ARQUIVO.WS_SUBS == 00) || (WS_AUX_ARQUIVO.WS_SUBS > 2000))
            {

                /*" -5846- SET WS-PRO TO 1 */
                WS_PRO.Value = 1;

                /*" -5849- END-IF. */
            }


            /*" -5850- IF (FLG-MALA EQUAL 'S' ) */

            if ((WS_AUX_ARQUIVO.FLG_MALA == "S"))
            {

                /*" -5851- SET WS-TIP TO 5 */
                WS_TIP.Value = 5;

                /*" -5854- END-IF */
            }


            /*" -5855- IF (FLG-GRAFICA EQUAL 'S' ) */

            if ((WS_AUX_ARQUIVO.FLG_GRAFICA == "S"))
            {

                /*" -5856- SET WS-TIP TO 2 */
                WS_TIP.Value = 2;

                /*" -5859- END-IF */
            }


            /*" -5860- IF (WSHOST-SITUACAO EQUAL '0' ) */

            if ((WSHOST_SITUACAO == "0"))
            {

                /*" -5861- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -5864- END-IF */
            }


            /*" -5865- IF (WSHOST-SITUACAO NOT EQUAL '0' ) */

            if ((WSHOST_SITUACAO != "0"))
            {

                /*" -5866- SET WS-SIT TO 2 */
                WS_SIT.Value = 2;

                /*" -5868- END-IF */
            }


            /*" -5870- ADD 1 TO WTABG-QTDE (WS-CDT WS-PRO WS-TIP WS-SIT) */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -5872- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-CDT WS-PRO WS-TIP WS-SIT) */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -5874- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-CDT WS-PRO WS-TIP WS-SIT) */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -5876- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-CDT WS-PRO WS-TIP WS-SIT) */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -5878- ADD WSHOST-VLIOCC TO WTABG-VLIOCC (WS-CDT WS-PRO WS-TIP WS-SIT) */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -5880- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-CDT WS-PRO WS-TIP WS-SIT) */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

            /*" -5880- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_SUMARIZA_AVISOS_EXIT*/

        [StopWatch]
        /*" R8450-GRAVA-AVISOS-SECTION */
        private void R8450_GRAVA_AVISOS_SECTION()
        {
            /*" -5889- MOVE '8450' TO WNR-EXEC-SQL. */
            _.Move("8450", WABEND.WNR_EXEC_SQL);

            /*" -5896- MOVE ZEROS TO V0DPCF-QTDREG-TOT V0DPCF-VLPRMTOT-TOT V0DPCF-VLPRMLIQ-TOT V0DPCF-VLTARIFA-TOT V0DPCF-VLBALCAO-TOT V0DPCF-VLIOCC-TOT */
            _.Move(0, V0DPCF_QTDREG_TOT, V0DPCF_VLPRMTOT_TOT, V0DPCF_VLPRMLIQ_TOT, V0DPCF_VLTARIFA_TOT, V0DPCF_VLBALCAO_TOT, V0DPCF_VLIOCC_TOT);

            /*" -5898- MOVE WTABG-CODAGEAVISO(WS-CDT) TO WWORK-AVS-AGE WWORK-AGEAVISO */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO, FILLER_58.WWORK_AVS_AGE);
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_CODAGEAVISO, WWORK_AGEAVISO);


            /*" -5900- MOVE 7 TO WWORK-TIP-AGE */
            _.Move(7, FILLER_57.WWORK_TIP_AGE);

            /*" -5901- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -5903- MOVE V0MCOB-BANCO TO V0DPCF-BCOAVISO */
            _.Move(V0MCOB_BANCO, V0DPCF_BCOAVISO);

            /*" -5905- MOVE WWORK-NRAVISO TO V0DPCF-NRAVISO V0AVIS-NRAVISO */
            _.Move(WWORK_NRAVISO, V0DPCF_NRAVISO, V0AVIS_NRAVISO);

            /*" -5907- MOVE WWORK-AGEAVISO TO V0DPCF-AGEAVISO */
            _.Move(WWORK_AGEAVISO, V0DPCF_AGEAVISO);

            /*" -5908- MOVE '0' TO V0DPCF-TIPOCOB */
            _.Move("0", V0DPCF_TIPOCOB);

            /*" -5909- MOVE V0SIST-DTMOVABE TO V0DPCF-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0DPCF_DTMOVTO);

            /*" -5910- MOVE WWORK-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0DPCF_DTAVISO);

            /*" -5913- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -5914- MOVE WWORK-DTAVISO TO WDATA-REL */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, WS_AUX_DATAS.WDATA_REL);

            /*" -5915- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -5917- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -5918- SET WS-PRO TO 1 */
            WS_PRO.Value = 1;

            /*" -5920- PERFORM R8500-GRAVA-PRODUTOS 2000 TIMES */

            for (int i = 0; i < 2000; i++)
            {

                R8500_GRAVA_PRODUTOS_SECTION();

            }

            /*" -5921- IF (V0DPCF-VLPRMTOT-TOT NOT EQUAL ZEROS) */

            if ((V0DPCF_VLPRMTOT_TOT != 00))
            {

                /*" -5922- PERFORM R4550-INCLUI-V0AVISOCRED */

                R4550_INCLUI_V0AVISOCRED_SECTION();

                /*" -5923- PERFORM R4600-INCLUI-V0AVISOSALDO */

                R4600_INCLUI_V0AVISOSALDO_SECTION();

                /*" -5924- PERFORM R4650-INCLUI-V0CONTROCNAB */

                R4650_INCLUI_V0CONTROCNAB_SECTION();

                /*" -5926- END-IF. */
            }


            /*" -5926- SET WS-CDT UP BY 1. */
            WS_CDT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8450_GRAVA_AVISOS_EXIT*/

        [StopWatch]
        /*" R8455-SELECT-MAX-AVISO-SECTION */
        private void R8455_SELECT_MAX_AVISO_SECTION()
        {
            /*" -5934- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -5935- DISPLAY W-PROGRAMA-CHAMADOR '-R8455-SELECT-MAX-AVISO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R8455-SELECT-MAX-AVISO");

                /*" -5938- END-IF */
            }


            /*" -5940- MOVE '8455' TO WNR-EXEC-SQL. */
            _.Move("8455", WABEND.WNR_EXEC_SQL);

            /*" -5942- INITIALIZE V0MCOB-NUMFITA */
            _.Initialize(
                V0MCOB_NUMFITA
            );

            /*" -5950- PERFORM R8455_SELECT_MAX_AVISO_DB_SELECT_1 */

            R8455_SELECT_MAX_AVISO_DB_SELECT_1();

            /*" -5953- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5954- DISPLAY 'R8455-00 - PROBLEMAS SELECT MAX V0MOVICOB' */
                _.Display($"R8455-00 - PROBLEMAS SELECT MAX V0MOVICOB");

                /*" -5956- MOVE 'R8455-00 - PROBLEMAS SELECT MAX V0MOVICOB' TO W-MENSAGEM-ERRO */
                _.Move("R8455-00 - PROBLEMAS SELECT MAX V0MOVICOB", W_MENSAGEM_ERRO);

                /*" -5957- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5957- END-IF. */
            }


        }

        [StopWatch]
        /*" R8455-SELECT-MAX-AVISO-DB-SELECT-1 */
        public void R8455_SELECT_MAX_AVISO_DB_SELECT_1()
        {
            /*" -5950- EXEC SQL SELECT VALUE(MAX(NUMFITA) + 1, 1) INTO :V0MCOB-NUMFITA FROM SEGUROS.V0MOVICOB WHERE DTMOVTO > '2016-12-01' AND AGENCIA IN (7001, 7005, 7996, 7003, 7800, 7828) WITH UR END-EXEC. */

            var r8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1 = new R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1.Execute(r8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MCOB_NUMFITA, V0MCOB_NUMFITA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8455_SELECT_MAX_AVISO_EXIT*/

        [StopWatch]
        /*" R8500-GRAVA-PRODUTOS-SECTION */
        private void R8500_GRAVA_PRODUTOS_SECTION()
        {
            /*" -5965- MOVE '8500' TO WNR-EXEC-SQL. */
            _.Move("8500", WABEND.WNR_EXEC_SQL);

            /*" -5966- IF (WTABG-CODPRODU(WS-CDT WS-PRO) EQUAL 9999) */

            if ((WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU == 9999))
            {

                /*" -5967- SET WS-PRO UP BY 1 */
                WS_PRO.Value += 1;

                /*" -5968- ELSE */
            }
            else
            {


                /*" -5970- MOVE WTABG-CODPRODU(WS-CDT WS-PRO) TO V0DPCF-CODPRODU */
                _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU, V0DPCF_CODPRODU);

                /*" -5971- SET WS-TIP TO 1 */
                WS_TIP.Value = 1;

                /*" -5973- PERFORM R8550-GRAVA-TIPO 05 TIMES */

                for (int i = 0; i < 5; i++)
                {

                    R8550_GRAVA_TIPO_SECTION();

                }

                /*" -5974- SET WS-PRO UP BY 1 */
                WS_PRO.Value += 1;

                /*" -5974- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_GRAVA_PRODUTOS_EXIT*/

        [StopWatch]
        /*" R8550-GRAVA-TIPO-SECTION */
        private void R8550_GRAVA_TIPO_SECTION()
        {
            /*" -5982- MOVE '8550' TO WNR-EXEC-SQL. */
            _.Move("8550", WABEND.WNR_EXEC_SQL);

            /*" -5984- MOVE WTABG-TIPO(WS-CDT WS-PRO WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -5985- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -5987- PERFORM R8600-GRAVA-CONTROL-DESPES 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R8600_GRAVA_CONTROL_DESPES_SECTION();

            }

            /*" -5987- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_GRAVA_TIPO_EXIT*/

        [StopWatch]
        /*" R8600-GRAVA-CONTROL-DESPES-SECTION */
        private void R8600_GRAVA_CONTROL_DESPES_SECTION()
        {
            /*" -5995- MOVE '8600' TO WNR-EXEC-SQL. */
            _.Move("8600", WABEND.WNR_EXEC_SQL);

            /*" -5997- MOVE WTABG-SITUACAO (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -5999- MOVE WTABG-QTDE (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -6001- MOVE WTABG-VLPRMTOT (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -6003- MOVE WTABG-VLTARIFA (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -6005- MOVE WTABG-VLBALCAO (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -6007- MOVE WTABG-VLIOCC (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -6009- MOVE WTABG-VLDESCON (WS-CDT WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -6015- COMPUTE V0DPCF-VLPRMLIQ = (V0DPCF-VLPRMTOT - V0DPCF-VLTARIFA - V0DPCF-VLBALCAO - V0DPCF-VLIOCC - V0DPCF-VLDESCON - V0DPCF-VLJUROS - V0DPCF-VLMULTA). */
            V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT - V0DPCF_VLTARIFA - V0DPCF_VLBALCAO - V0DPCF_VLIOCC - V0DPCF_VLDESCON - V0DPCF_VLJUROS - V0DPCF_VLMULTA);

            /*" -6018- IF (V0DPCF-VLPRMTOT > ZEROS) OR (V0DPCF-QTDREG > ZEROS) OR (V0DPCF-VLTARIFA > ZEROS) OR (V0DPCF-VLBALCAO > ZEROS) OR (V0DPCF-VLIOCC > ZEROS) OR (V0DPCF-VLDESCON > ZEROS) */

            if ((V0DPCF_VLPRMTOT > 00) || (V0DPCF_QTDREG > 00) || (V0DPCF_VLTARIFA > 00) || (V0DPCF_VLBALCAO > 00) || (V0DPCF_VLIOCC > 00) || (V0DPCF_VLDESCON > 00))
            {

                /*" -6019- PERFORM R8700-INCLUI-DESPESAS */

                R8700_INCLUI_DESPESAS_SECTION();

                /*" -6021- END-IF. */
            }


            /*" -6023- COMPUTE V0DPCF-QTDREG-TOT = V0DPCF-QTDREG-TOT + V0DPCF-QTDREG */
            V0DPCF_QTDREG_TOT.Value = V0DPCF_QTDREG_TOT + V0DPCF_QTDREG;

            /*" -6025- COMPUTE V0DPCF-VLPRMTOT-TOT = V0DPCF-VLPRMTOT-TOT + V0DPCF-VLPRMTOT */
            V0DPCF_VLPRMTOT_TOT.Value = V0DPCF_VLPRMTOT_TOT + V0DPCF_VLPRMTOT;

            /*" -6027- COMPUTE V0DPCF-VLPRMLIQ-TOT = V0DPCF-VLPRMLIQ-TOT + V0DPCF-VLPRMLIQ */
            V0DPCF_VLPRMLIQ_TOT.Value = V0DPCF_VLPRMLIQ_TOT + V0DPCF_VLPRMLIQ;

            /*" -6029- COMPUTE V0DPCF-VLTARIFA-TOT = V0DPCF-VLTARIFA-TOT + V0DPCF-VLTARIFA */
            V0DPCF_VLTARIFA_TOT.Value = V0DPCF_VLTARIFA_TOT + V0DPCF_VLTARIFA;

            /*" -6031- COMPUTE V0DPCF-VLBALCAO-TOT = V0DPCF-VLBALCAO-TOT + V0DPCF-VLBALCAO */
            V0DPCF_VLBALCAO_TOT.Value = V0DPCF_VLBALCAO_TOT + V0DPCF_VLBALCAO;

            /*" -6034- COMPUTE V0DPCF-VLIOCC-TOT = V0DPCF-VLIOCC-TOT + V0DPCF-VLIOCC */
            V0DPCF_VLIOCC_TOT.Value = V0DPCF_VLIOCC_TOT + V0DPCF_VLIOCC;

            /*" -6042- MOVE ZEROS TO WTABG-QTDE (WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLTARIFA(WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLBALCAO(WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLIOCC (WS-CDT WS-PRO WS-TIP WS-SIT) WTABG-VLDESCON(WS-CDT WS-PRO WS-TIP WS-SIT) */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORRECED[WS_CDT].WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -6042- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_GRAVA_CONTROL_DESP_EXIT*/

        [StopWatch]
        /*" R8700-INCLUI-DESPESAS-SECTION */
        private void R8700_INCLUI_DESPESAS_SECTION()
        {
            /*" -6050- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -6051- DISPLAY W-PROGRAMA-CHAMADOR '-R8700-INCLUI-DESPESAS' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R8700-INCLUI-DESPESAS");

                /*" -6054- END-IF */
            }


            /*" -6056- MOVE '8700' TO WNR-EXEC-SQL. */
            _.Move("8700", WABEND.WNR_EXEC_SQL);

            /*" -6103- PERFORM R8700_INCLUI_DESPESAS_DB_INSERT_1 */

            R8700_INCLUI_DESPESAS_DB_INSERT_1();

            /*" -6107- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -6109- DISPLAY 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"R8700-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -6110- DISPLAY 'V0DPCF-CODEMP   = ' V0DPCF-CODEMP */
                _.Display($"V0DPCF-CODEMP   = {V0DPCF_CODEMP}");

                /*" -6111- DISPLAY 'V0DPCF-ANOREF   = ' V0DPCF-ANOREF */
                _.Display($"V0DPCF-ANOREF   = {V0DPCF_ANOREF}");

                /*" -6112- DISPLAY 'V0DPCF-MESREF   = ' V0DPCF-MESREF */
                _.Display($"V0DPCF-MESREF   = {V0DPCF_MESREF}");

                /*" -6113- DISPLAY 'V0DPCF-BCOAVISO = ' V0DPCF-BCOAVISO */
                _.Display($"V0DPCF-BCOAVISO = {V0DPCF_BCOAVISO}");

                /*" -6114- DISPLAY 'V0DPCF-AGEAVISO = ' V0DPCF-AGEAVISO */
                _.Display($"V0DPCF-AGEAVISO = {V0DPCF_AGEAVISO}");

                /*" -6115- DISPLAY 'V0DPCF-NRAVISO  = ' V0DPCF-NRAVISO */
                _.Display($"V0DPCF-NRAVISO  = {V0DPCF_NRAVISO}");

                /*" -6116- DISPLAY 'V0DPCF-CODPRODU = ' V0DPCF-CODPRODU */
                _.Display($"V0DPCF-CODPRODU = {V0DPCF_CODPRODU}");

                /*" -6117- DISPLAY 'V0DPCF-TIPOREG  = ' V0DPCF-TIPOREG */
                _.Display($"V0DPCF-TIPOREG  = {V0DPCF_TIPOREG}");

                /*" -6118- DISPLAY 'V0DPCF-SITUACAO = ' V0DPCF-SITUACAO */
                _.Display($"V0DPCF-SITUACAO = {V0DPCF_SITUACAO}");

                /*" -6119- DISPLAY 'V0DPCF-TIPOCOB  = ' V0DPCF-TIPOCOB */
                _.Display($"V0DPCF-TIPOCOB  = {V0DPCF_TIPOCOB}");

                /*" -6120- DISPLAY 'V0DPCF-DTMOVTO  = ' V0DPCF-DTMOVTO */
                _.Display($"V0DPCF-DTMOVTO  = {V0DPCF_DTMOVTO}");

                /*" -6121- DISPLAY 'V0DPCF-DTAVISO  = ' V0DPCF-DTAVISO */
                _.Display($"V0DPCF-DTAVISO  = {V0DPCF_DTAVISO}");

                /*" -6122- DISPLAY 'V0DPCF-QTDREG   = ' V0DPCF-QTDREG */
                _.Display($"V0DPCF-QTDREG   = {V0DPCF_QTDREG}");

                /*" -6123- DISPLAY 'V0DPCF-VLPRMTOT = ' V0DPCF-VLPRMTOT */
                _.Display($"V0DPCF-VLPRMTOT = {V0DPCF_VLPRMTOT}");

                /*" -6124- DISPLAY 'V0DPCF-VLPRMLIQ = ' V0DPCF-VLPRMLIQ */
                _.Display($"V0DPCF-VLPRMLIQ = {V0DPCF_VLPRMLIQ}");

                /*" -6125- DISPLAY 'V0DPCF-VLTARIFA = ' V0DPCF-VLTARIFA */
                _.Display($"V0DPCF-VLTARIFA = {V0DPCF_VLTARIFA}");

                /*" -6126- DISPLAY 'V0DPCF-VLBALCAO = ' V0DPCF-VLBALCAO */
                _.Display($"V0DPCF-VLBALCAO = {V0DPCF_VLBALCAO}");

                /*" -6127- DISPLAY 'V0DPCF-VLIOCC   = ' V0DPCF-VLIOCC */
                _.Display($"V0DPCF-VLIOCC   = {V0DPCF_VLIOCC}");

                /*" -6128- DISPLAY 'V0DPCF-VLDESCON = ' V0DPCF-VLDESCON */
                _.Display($"V0DPCF-VLDESCON = {V0DPCF_VLDESCON}");

                /*" -6129- DISPLAY 'V0DPCF-VLJUROS  = ' V0DPCF-VLJUROS */
                _.Display($"V0DPCF-VLJUROS  = {V0DPCF_VLJUROS}");

                /*" -6130- DISPLAY 'V0DPCF-VLMULTA  = ' V0DPCF-VLMULTA */
                _.Display($"V0DPCF-VLMULTA  = {V0DPCF_VLMULTA}");

                /*" -6132- MOVE 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' TO W-MENSAGEM-ERRO */
                _.Move("R8700-00 - PROBLEMAS INSERT (DESPESAS)   ", W_MENSAGEM_ERRO);

                /*" -6133- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6135- END-IF */
            }


            /*" -6136- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6137- ADD 1 TO AC-INSERT */
                WS_AUX_ARQUIVO.AC_INSERT.Value = WS_AUX_ARQUIVO.AC_INSERT + 1;

                /*" -6138- ELSE */
            }
            else
            {


                /*" -6139- DISPLAY '        ' */
                _.Display($"        ");

                /*" -6140- DISPLAY 'DESPESA DESPREZADO POR -803' */
                _.Display($"DESPESA DESPREZADO POR -803");

                /*" -6141- DISPLAY 'V0DPCF-CODEMP   = ' V0DPCF-CODEMP */
                _.Display($"V0DPCF-CODEMP   = {V0DPCF_CODEMP}");

                /*" -6142- DISPLAY 'V0DPCF-ANOREF   = ' V0DPCF-ANOREF */
                _.Display($"V0DPCF-ANOREF   = {V0DPCF_ANOREF}");

                /*" -6143- DISPLAY 'V0DPCF-MESREF   = ' V0DPCF-MESREF */
                _.Display($"V0DPCF-MESREF   = {V0DPCF_MESREF}");

                /*" -6144- DISPLAY 'V0DPCF-BCOAVISO = ' V0DPCF-BCOAVISO */
                _.Display($"V0DPCF-BCOAVISO = {V0DPCF_BCOAVISO}");

                /*" -6145- DISPLAY 'V0DPCF-AGEAVISO = ' V0DPCF-AGEAVISO */
                _.Display($"V0DPCF-AGEAVISO = {V0DPCF_AGEAVISO}");

                /*" -6146- DISPLAY 'V0DPCF-NRAVISO  = ' V0DPCF-NRAVISO */
                _.Display($"V0DPCF-NRAVISO  = {V0DPCF_NRAVISO}");

                /*" -6147- DISPLAY 'V0DPCF-CODPRODU = ' V0DPCF-CODPRODU */
                _.Display($"V0DPCF-CODPRODU = {V0DPCF_CODPRODU}");

                /*" -6148- DISPLAY 'V0DPCF-TIPOREG  = ' V0DPCF-TIPOREG */
                _.Display($"V0DPCF-TIPOREG  = {V0DPCF_TIPOREG}");

                /*" -6149- DISPLAY 'V0DPCF-SITUACAO = ' V0DPCF-SITUACAO */
                _.Display($"V0DPCF-SITUACAO = {V0DPCF_SITUACAO}");

                /*" -6150- DISPLAY 'V0DPCF-TIPOCOB  = ' V0DPCF-TIPOCOB */
                _.Display($"V0DPCF-TIPOCOB  = {V0DPCF_TIPOCOB}");

                /*" -6151- DISPLAY 'V0DPCF-DTMOVTO  = ' V0DPCF-DTMOVTO */
                _.Display($"V0DPCF-DTMOVTO  = {V0DPCF_DTMOVTO}");

                /*" -6152- DISPLAY 'V0DPCF-DTAVISO  = ' V0DPCF-DTAVISO */
                _.Display($"V0DPCF-DTAVISO  = {V0DPCF_DTAVISO}");

                /*" -6153- DISPLAY 'V0DPCF-QTDREG   = ' V0DPCF-QTDREG */
                _.Display($"V0DPCF-QTDREG   = {V0DPCF_QTDREG}");

                /*" -6154- DISPLAY 'V0DPCF-VLPRMTOT = ' V0DPCF-VLPRMTOT */
                _.Display($"V0DPCF-VLPRMTOT = {V0DPCF_VLPRMTOT}");

                /*" -6155- DISPLAY 'V0DPCF-VLPRMLIQ = ' V0DPCF-VLPRMLIQ */
                _.Display($"V0DPCF-VLPRMLIQ = {V0DPCF_VLPRMLIQ}");

                /*" -6156- DISPLAY 'V0DPCF-VLTARIFA = ' V0DPCF-VLTARIFA */
                _.Display($"V0DPCF-VLTARIFA = {V0DPCF_VLTARIFA}");

                /*" -6157- DISPLAY 'V0DPCF-VLBALCAO = ' V0DPCF-VLBALCAO */
                _.Display($"V0DPCF-VLBALCAO = {V0DPCF_VLBALCAO}");

                /*" -6158- DISPLAY 'V0DPCF-VLIOCC   = ' V0DPCF-VLIOCC */
                _.Display($"V0DPCF-VLIOCC   = {V0DPCF_VLIOCC}");

                /*" -6159- DISPLAY 'V0DPCF-VLDESCON = ' V0DPCF-VLDESCON */
                _.Display($"V0DPCF-VLDESCON = {V0DPCF_VLDESCON}");

                /*" -6160- DISPLAY 'V0DPCF-VLJUROS  = ' V0DPCF-VLJUROS */
                _.Display($"V0DPCF-VLJUROS  = {V0DPCF_VLJUROS}");

                /*" -6161- DISPLAY 'V0DPCF-VLMULTA  = ' V0DPCF-VLMULTA */
                _.Display($"V0DPCF-VLMULTA  = {V0DPCF_VLMULTA}");

                /*" -6163- END-IF */
            }


            /*" -6163- . */

        }

        [StopWatch]
        /*" R8700-INCLUI-DESPESAS-DB-INSERT-1 */
        public void R8700_INCLUI_DESPESAS_DB_INSERT_1()
        {
            /*" -6103- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA, ANO_REFERENCIA, MES_REFERENCIA, BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, COD_PRODUTO, TIPO_REGISTRO, SITUACAO, TIPO_COBRANCA, DATA_MOVIMENTO, DATA_AVISO, QTD_REGISTROS, PRM_TOTAL, PRM_LIQUIDO, VAL_TARIFA, VAL_BALCAO, VAL_IOCC, VAL_DESCONTO, VAL_JUROS, VAL_MULTA, TIMESTAMP) VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1 = new R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1()
            {
                V0DPCF_CODEMP = V0DPCF_CODEMP.ToString(),
                V0DPCF_ANOREF = V0DPCF_ANOREF.ToString(),
                V0DPCF_MESREF = V0DPCF_MESREF.ToString(),
                V0DPCF_BCOAVISO = V0DPCF_BCOAVISO.ToString(),
                V0DPCF_AGEAVISO = V0DPCF_AGEAVISO.ToString(),
                V0DPCF_NRAVISO = V0DPCF_NRAVISO.ToString(),
                V0DPCF_CODPRODU = V0DPCF_CODPRODU.ToString(),
                V0DPCF_TIPOREG = V0DPCF_TIPOREG.ToString(),
                V0DPCF_SITUACAO = V0DPCF_SITUACAO.ToString(),
                V0DPCF_TIPOCOB = V0DPCF_TIPOCOB.ToString(),
                V0DPCF_DTMOVTO = V0DPCF_DTMOVTO.ToString(),
                V0DPCF_DTAVISO = V0DPCF_DTAVISO.ToString(),
                V0DPCF_QTDREG = V0DPCF_QTDREG.ToString(),
                V0DPCF_VLPRMTOT = V0DPCF_VLPRMTOT.ToString(),
                V0DPCF_VLPRMLIQ = V0DPCF_VLPRMLIQ.ToString(),
                V0DPCF_VLTARIFA = V0DPCF_VLTARIFA.ToString(),
                V0DPCF_VLBALCAO = V0DPCF_VLBALCAO.ToString(),
                V0DPCF_VLIOCC = V0DPCF_VLIOCC.ToString(),
                V0DPCF_VLDESCON = V0DPCF_VLDESCON.ToString(),
                V0DPCF_VLJUROS = V0DPCF_VLJUROS.ToString(),
                V0DPCF_VLMULTA = V0DPCF_VLMULTA.ToString(),
            };

            R8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1.Execute(r8700_INCLUI_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_INCLUI_DESPESAS_EXIT*/

        [StopWatch]
        /*" R9000-FINALIZA-SECTION */
        private void R9000_FINALIZA_SECTION()
        {
            /*" -6171- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -6172- DISPLAY W-PROGRAMA-CHAMADOR '-R9000-FINALIZA' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R9000-FINALIZA");

                /*" -6175- END-IF */
            }


            /*" -6176- DISPLAY ' ' */
            _.Display($" ");

            /*" -6177- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -6178- DISPLAY '             PF2002B - FIM NORMAL' . */
            _.Display($"             PF2002B - FIM NORMAL");

            /*" -6179- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -6180- DISPLAY 'QUANT LIDOS COBRANCA ........ ' LD-COBRANCA */
            _.Display($"QUANT LIDOS COBRANCA ........ {WS_AUX_ARQUIVO.LD_COBRANCA}");

            /*" -6181- DISPLAY 'QUANT LIDOS CED DIRVI........ ' LD-CED-DIRVI */
            _.Display($"QUANT LIDOS CED DIRVI........ {WS_AUX_ARQUIVO.LD_CED_DIRVI}");

            /*" -6182- DISPLAY 'QUANT LIDOS CED DIRID........ ' LD-CED-DIRID */
            _.Display($"QUANT LIDOS CED DIRID........ {WS_AUX_ARQUIVO.LD_CED_DIRID}");

            /*" -6183- DISPLAY 'QUANT LIDOS CED DISEF........ ' LD-CED-DISEF */
            _.Display($"QUANT LIDOS CED DISEF........ {WS_AUX_ARQUIVO.LD_CED_DISEF}");

            /*" -6184- DISPLAY 'QUANT LIDOS CED RESSARC...... ' LD-CED-RESSARC */
            _.Display($"QUANT LIDOS CED RESSARC...... {WS_AUX_ARQUIVO.LD_CED_RESSARC}");

            /*" -6185- DISPLAY 'QUANT LIDOS CED DESCONHECIDO. ' LD-CED-DESCONHECIDO */
            _.Display($"QUANT LIDOS CED DESCONHECIDO. {WS_AUX_ARQUIVO.LD_CED_DESCONHECIDO}");

            /*" -6186- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -6187- DISPLAY 'MOVIMENTO COBRANCA .......... ' DE-COBRANCA */
            _.Display($"MOVIMENTO COBRANCA .......... {WS_AUX_ARQUIVO.DE_COBRANCA}");

            /*" -6188- DISPLAY 'INSERIDOS COBRANCA .......... ' IN-COBRANCA */
            _.Display($"INSERIDOS COBRANCA .......... {WS_AUX_ARQUIVO.IN_COBRANCA}");

            /*" -6189- DISPLAY ' ' */
            _.Display($" ");

            /*" -6190- DISPLAY 'CONVERSAO SIVPF ............. ' IN-CONVERSAO */
            _.Display($"CONVERSAO SIVPF ............. {WS_AUX_ARQUIVO.IN_CONVERSAO}");

            /*" -6191- DISPLAY 'DESPREZA SIES................ ' DP-SIES. */
            _.Display($"DESPREZA SIES................ {WS_AUX_ARQUIVO.DP_SIES}");

            /*" -6192- DISPLAY ' ' */
            _.Display($" ");

            /*" -6193- DISPLAY 'V0RCAP ...................... ' IN-V0RCAP */
            _.Display($"V0RCAP ...................... {WS_AUX_ARQUIVO.IN_V0RCAP}");

            /*" -6194- DISPLAY 'V0FOLLOWUP .................. ' IN-FOLLOWUP */
            _.Display($"V0FOLLOWUP .................. {WS_AUX_ARQUIVO.IN_FOLLOWUP}");

            /*" -6195- DISPLAY ' ' */
            _.Display($" ");

            /*" -6196- DISPLAY 'INSERT DESPESAS ............. ' AC-INSERT */
            _.Display($"INSERT DESPESAS ............. {WS_AUX_ARQUIVO.AC_INSERT}");

            /*" -6197- DISPLAY ' ' */
            _.Display($" ");

            /*" -6198- DISPLAY 'TRATA OPCAO VIDAZUL ......... ' TT-OPCAO */
            _.Display($"TRATA OPCAO VIDAZUL ......... {WS_AUX_ARQUIVO.TT_OPCAO}");

            /*" -6199- DISPLAY 'DESPR OPCAO VIDAZUL ......... ' DP-OPCAO */
            _.Display($"DESPR OPCAO VIDAZUL ......... {WS_AUX_ARQUIVO.DP_OPCAO}");

            /*" -6200- DISPLAY ' ' */
            _.Display($" ");

            /*" -6201- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -6202- DISPLAY '             PF2002B - FIM NORMAL' . */
            _.Display($"             PF2002B - FIM NORMAL");

            /*" -6204- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -6205- CLOSE MOVIMENTO-COBRANCA */
            MOVIMENTO_COBRANCA.Close();

            /*" -6207- CLOSE PF2002B1. */
            PF2002B1.Close();

            /*" -6208- IF PF2002B-TRACE EQUAL 'SIM' */

            if (PF2002B_SYSIN.PF2002B_TRACE == "SIM")
            {

                /*" -6208- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -6210- DISPLAY '*** PF2002B - ROLLBACK EFETUADO ***' */
                _.Display($"*** PF2002B - ROLLBACK EFETUADO ***");

                /*" -6211- ELSE */
            }
            else
            {


                /*" -6211- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -6213- DISPLAY '*** PF2002B - COMMIT   EFETUADO ***' */
                _.Display($"*** PF2002B - COMMIT   EFETUADO ***");

                /*" -6215- END-IF. */
            }


            /*" -6217- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -6217- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9800-ENCERRA-SEM-MOVTO-SECTION */
        private void R9800_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -6225- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -6226- DISPLAY W-PROGRAMA-CHAMADOR '-R9800-ENCERRA-SEM-MOVTO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R9800-ENCERRA-SEM-MOVTO");

                /*" -6229- END-IF */
            }


            /*" -6230- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_DATAS.WDATA_REL);

            /*" -6231- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_DIA, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -6232- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_MES, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -6234- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_ANO, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -6235- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -6236- DISPLAY '*   PF2002B - PROCESSA FITA RETORNO SIVPF  *' */
            _.Display($"*   PF2002B - PROCESSA FITA RETORNO SIVPF  *");

            /*" -6237- DISPLAY '*   -------   -------- ---- ------- -----  *' */
            _.Display($"*   -------   -------- ---- ------- -----  *");

            /*" -6238- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6239- DISPLAY '*    NAO HOUVE MOVIMENTACAO NESTA DATA     *' */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NESTA DATA     *");

            /*" -6241- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {WS_AUX_DATAS.WDAT_REL_LIT}                   *"
            .Display();

            /*" -6241- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_ENCERRA_SEM_MOVTO_EXIT*/

        [StopWatch]
        /*" R9900-ENCERRA-COM-ERRO-SECTION */
        private void R9900_ENCERRA_COM_ERRO_SECTION()
        {
            /*" -6248- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -6249- DISPLAY W-PROGRAMA-CHAMADOR '-R9900-ENCERRA-COM-ERRO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R9900-ENCERRA-COM-ERRO");

                /*" -6252- END-IF */
            }


            /*" -6253- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_DATAS.WDATA_REL);

            /*" -6254- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_DIA, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -6255- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_MES, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -6257- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(WS_AUX_DATAS.FILLER_28.WDAT_REL_ANO, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -6258- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -6259- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6260- DISPLAY '*   PF2002B - PROCESSA FITA RETORNO SIVPF  *' */
            _.Display($"*   PF2002B - PROCESSA FITA RETORNO SIVPF  *");

            /*" -6261- DISPLAY '*   -------   -------- ---- ------- -----  *' */
            _.Display($"*   -------   -------- ---- ------- -----  *");

            /*" -6262- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6263- DISPLAY '*    PROCESSAMENTO COM ERRO NESTA DATA     *' */
            _.Display($"*    PROCESSAMENTO COM ERRO NESTA DATA     *");

            /*" -6265- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {WS_AUX_DATAS.WDAT_REL_LIT}                   *"
            .Display();

            /*" -6266- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6268- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -6269- CLOSE MOVIMENTO-COBRANCA */
            MOVIMENTO_COBRANCA.Close();

            /*" -6271- CLOSE PF2002B1. */
            PF2002B1.Close();

            /*" -6271- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6275- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -6275- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-ROT-ERRO-SECTION */
        private void R9999_ROT_ERRO_SECTION()
        {
            /*" -6282- IF W-CT-TRACE-DET-ON */

            if (W_CT_TRACE["W_CT_TRACE_DET_ON"])
            {

                /*" -6283- DISPLAY W-PROGRAMA-CHAMADOR '-R9999-ROT-ERRO' */
                _.Display($"{W_PROGRAMA_CHAMADOR}-R9999-ROT-ERRO");

                /*" -6286- END-IF */
            }


            /*" -6287- DISPLAY ' ' */
            _.Display($" ");

            /*" -6289- DISPLAY '###################################################' '###################################################' */
            _.Display($"######################################################################################################");

            /*" -6290- DISPLAY 'MENSAGEM:' */
            _.Display($"MENSAGEM:");

            /*" -6292- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -6293- DISPLAY W-MENSAGEM-ERRO */
            _.Display(W_MENSAGEM_ERRO);

            /*" -6295- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -6296- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -6297- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -6298- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -6299- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -6300- DISPLAY 'SQLERRMC<' SQLERRMC '>' */

            $"SQLERRMC<{DB.SQLERRMC}>"
            .Display();

            /*" -6303- DISPLAY '###################################################' '###################################################' */
            _.Display($"######################################################################################################");

            /*" -6306- CLOSE MOVIMENTO-COBRANCA PF2002B1. */
            MOVIMENTO_COBRANCA.Close();
            PF2002B1.Close();

            /*" -6306- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6310- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -6310- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}