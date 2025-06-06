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
using Sias.PessoaFisica.DB2.PF0003B;

namespace Code
{
    public class PF0003B
    {
        public bool IsCall { get; set; }

        public PF0003B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  PF0003B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  01/06/2005                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONSISTENCIA E CONTROLE DO         *      */
        /*"      *                             MOVIMENTO DE COBRANCA              *      */
        /*"      *                            'CAIXA ECONOMICA FEDERAL (SIVPF)'.  *      */
        /*"      *                             SIGPF FINANCEIRO                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                       ALTERACOES                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 30/01/2024 *      */
        /*"      *   VERSAO 08               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
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
        /*"      *                           - PROCURAR POR V.08                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07   - TAREFA  267.521                                *      */
        /*"      *               - CORRECAO ABEND SQLCODE = 100 R02170-00         *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/11/2020 - HERVAL SOUZA       PROCURE POR V.07          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06   - TAREFA  265.132                                *      */
        /*"      *               - CORRIGIR ALTERACAO FEITA PELA FABRICA          *      */
        /*"      *                 TRATAMENTO BILHETE_COBERTURA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/11/2020 - HERVAL SOUZA       PROCURE POR V.06          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05   - HISTORIA 181017                                *      */
        /*"      *               - ALTERAR A APLICACAO PARA O TRATAMENTO DA NOVA  *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2019 - LUIZ FERNANDO      PROCURE POR V.05          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       13/05/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  FAST   EM 28/06/2011    V.03       *      */
        /*"      *                             CADMUS 54479.                      *      */
        /*"      *                             COLOCAR CLAUSULA WITH UR COMANDOS  *      */
        /*"      *                             SELECT DO DB2                      *      */
        /*"      *                             PROCURAR POR ===========>> C54479  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  FAST   EM 18/05/2009    V.02       *      */
        /*"      *                             CADMUS 24245.                      *      */
        /*"      *                             TRATA CODIGO RETORNO -803.         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   VERSAO DO PGM PF0002B ADAPTANDO LAYOUT DO SIGPF FINANCEIRO   *      */
        /*"      *   PARA SICOB.                                                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  CADMUS 51169 - AUMENTAR O TAMANHO DA TABELA INTERNA P/ 800    *      */
        /*"      *  08/12/2010     WELLINGTON VERAS - TE39902                     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO_COBRANCA { get; set; } = new FileBasis(new PIC("X", "420", "X(420)"));

        public FileBasis MOVIMENTO_COBRANCA
        {
            get
            {
                _.Move(REG_COBRANCA, _MOVIMENTO_COBRANCA); VarBasis.RedefinePassValue(REG_COBRANCA, _MOVIMENTO_COBRANCA, REG_COBRANCA); return _MOVIMENTO_COBRANCA;
            }
        }
        public SortBasis<PF0003B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<PF0003B_REG_ARQSORT>(new PF0003B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public PF0003B_REG_ARQSORT REG_ARQSORT { get; set; } = new PF0003B_REG_ARQSORT();
        public class PF0003B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-CODREGISTR      PIC  X(001).*/
            public StringBasis SOR_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-DETALHE         PIC  X(366).*/
            public StringBasis SOR_DETALHE { get; set; } = new StringBasis(new PIC("X", "366", "X(366)."), @"");
            /*"  05      SOR-CEDENTE         PIC  9(016).*/
            public IntBasis SOR_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      SOR-TIPO            PIC  9(001).*/
            public IntBasis SOR_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      SOR-CANAL           PIC  9(001).*/
            public IntBasis SOR_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      SOR-SPACES          PIC  X(015).*/
            public StringBasis SOR_SPACES { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"01        REG-COBRANCA.*/
        }
        public PF0003B_REG_COBRANCA REG_COBRANCA { get; set; } = new PF0003B_REG_COBRANCA();
        public class PF0003B_REG_COBRANCA : VarBasis
        {
            /*"  05      ENT-CODREGISTR      PIC  X(001).*/
            public StringBasis ENT_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      ENT-REGSICOB        PIC  X(400).*/
            public StringBasis ENT_REGSICOB { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
            /*"  05      FILLER              PIC  X(013).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  05      ENT-NRSEQ           PIC  9(006).*/
            public IntBasis ENT_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
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
        /*"77    VIND-CODEMP               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORIGAVISO            PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADT               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP VALUE +0.*/
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
        /*"77    WHOST-COUNT-AVS           PIC S9(004)     COMP.*/
        public IntBasis WHOST_COUNT_AVS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77    V0SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77    V0BCOB-DTINIVIG           PIC  X(010).*/
        public StringBasis V0BCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BCOB-DTTERVIG           PIC  X(010).*/
        public StringBasis V0BCOB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77    V0AVIS-SITDEPTER          PIC  X(001).*/
        public StringBasis V0AVIS_SITDEPTER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"77    V0CTIT-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0CTIT_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CTIT-NRTIT1             PIC S9(013)     COMP-3.*/
        public IntBasis V0CTIT_NRTIT1 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0CTIT-NRTIT2             PIC S9(013)     COMP-3.*/
        public IntBasis V0CTIT_NRTIT2 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0BILH-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-NUMAPOL            PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WS-AUX-ARQUIVO.*/
        public PF0003B_WS_AUX_ARQUIVO WS_AUX_ARQUIVO { get; set; } = new PF0003B_WS_AUX_ARQUIVO();
        public class PF0003B_WS_AUX_ARQUIVO : VarBasis
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
            /*"  03         AC-INSERT          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_INSERT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-HEADER          PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-HEADER1         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_HEADER1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-DETALHE         PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_DETALHE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
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
            /*"  03         WFIM-COBRANCA      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WCHV-ERRO          PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WCHV_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         FLG-GRAFICA        PIC  X(001)    VALUE   SPACES.*/
            public StringBasis FLG_GRAFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DE-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DE_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         NP-COBRANCA        PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis NP_COBRANCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
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
            /*"  03         DT-AMD             PIC  X(010)    VALUE   SPACES.*/
            public StringBasis DT_AMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER   REDEFINES DT-AMD.*/
            private _REDEF_PF0003B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0003B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0003B_FILLER_1(); _.Move(DT_AMD, _filler_1); VarBasis.RedefinePassValue(DT_AMD, _filler_1, DT_AMD); _filler_1.ValueChanged += () => { _.Move(_filler_1, DT_AMD); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, DT_AMD); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_1 : VarBasis
            {
                /*"    10       DT-AMD-AA          PIC  9(004).*/
                public IntBasis DT_AMD_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       DT-AMD-T1          PIC  X(001).*/
                public StringBasis DT_AMD_T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       DT-AMD-MM          PIC  9(002).*/
                public IntBasis DT_AMD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       DT-AMD-T2          PIC  X(001).*/
                public StringBasis DT_AMD_T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       DT-AMD-DD          PIC  9(002).*/
                public IntBasis DT_AMD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WWORK-MIN-NRTIT    PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0003B_FILLER_1()
                {
                    DT_AMD_AA.ValueChanged += OnValueChanged;
                    DT_AMD_T1.ValueChanged += OnValueChanged;
                    DT_AMD_MM.ValueChanged += OnValueChanged;
                    DT_AMD_T2.ValueChanged += OnValueChanged;
                    DT_AMD_DD.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_PF0003B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0003B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0003B_FILLER_2(); _.Move(WWORK_MIN_NRTIT, _filler_2); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_2, WWORK_MIN_NRTIT); _filler_2.ValueChanged += () => { _.Move(_filler_2, WWORK_MIN_NRTIT); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_2 : VarBasis
            {
                /*"    10       WWORK-MINNRO       PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MINDIG       PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MAX-NRTIT    PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0003B_FILLER_2()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_PF0003B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0003B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0003B_FILLER_3(); _.Move(WWORK_MAX_NRTIT, _filler_3); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_3, WWORK_MAX_NRTIT); _filler_3.ValueChanged += () => { _.Move(_filler_3, WWORK_MAX_NRTIT); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_3 : VarBasis
            {
                /*"    10       WWORK-MAXNRO       PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MAXDIG       PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-NSO-NUMERO   PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0003B_FILLER_3()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WWORK-NSO-NUMERO.*/
            private _REDEF_PF0003B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0003B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0003B_FILLER_4(); _.Move(WWORK_NSO_NUMERO, _filler_4); VarBasis.RedefinePassValue(WWORK_NSO_NUMERO, _filler_4, WWORK_NSO_NUMERO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WWORK_NSO_NUMERO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WWORK_NSO_NUMERO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_4 : VarBasis
            {
                /*"    10       WWORK-PRETIT       PIC  9(001).*/
                public IntBasis WWORK_PRETIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WWORK-NRRCAP       PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WWORK-DIGTIT       PIC  9(001).*/
                public IntBasis WWORK_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WS-NRTIT           PIC  9(011)    VALUE   ZEROS.*/

                public _REDEF_PF0003B_FILLER_4()
                {
                    WWORK_PRETIT.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    WWORK_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WS-NRTIT.*/
            private _REDEF_PF0003B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0003B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0003B_FILLER_5(); _.Move(WS_NRTIT, _filler_5); VarBasis.RedefinePassValue(WS_NRTIT, _filler_5, WS_NRTIT); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_NRTIT); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_5 : VarBasis
            {
                /*"      10     WS-NUMTIT          PIC  9(010).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10     WS-DIGTIT          PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-TIT-GRAFICA    PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_PF0003B_FILLER_5()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TIT_GRAFICA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-TIT-GRAFICA.*/
            private _REDEF_PF0003B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0003B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0003B_FILLER_6(); _.Move(AUX_TIT_GRAFICA, _filler_6); VarBasis.RedefinePassValue(AUX_TIT_GRAFICA, _filler_6, AUX_TIT_GRAFICA); _filler_6.ValueChanged += () => { _.Move(_filler_6, AUX_TIT_GRAFICA); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, AUX_TIT_GRAFICA); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_6 : VarBasis
            {
                /*"    10       FILLER             PIC  X(003).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10       AUX-NUM-GRAFICA    PIC  9(011).*/
                public IntBasis AUX_NUM_GRAFICA { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"  03         AUX-USO-EMPRESA.*/

                public _REDEF_PF0003B_FILLER_6()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    AUX_NUM_GRAFICA.ValueChanged += OnValueChanged;
                }

            }
            public PF0003B_AUX_USO_EMPRESA AUX_USO_EMPRESA { get; set; } = new PF0003B_AUX_USO_EMPRESA();
            public class PF0003B_AUX_USO_EMPRESA : VarBasis
            {
                /*"    10       AUX-OITO           PIC  X(001).*/
                public StringBasis AUX_OITO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-TITSIVPF       PIC  9(014).*/
                public IntBasis AUX_TITSIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10       AUX-ESPACOS        PIC  X(010).*/
                public StringBasis AUX_ESPACOS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03         AUX-NRO-SIVPF      PIC  9(014)    VALUE   ZEROS.*/
            }
            public IntBasis AUX_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-NRO-SIVPF.*/
            private _REDEF_PF0003B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0003B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0003B_FILLER_8(); _.Move(AUX_NRO_SIVPF, _filler_8); VarBasis.RedefinePassValue(AUX_NRO_SIVPF, _filler_8, AUX_NRO_SIVPF); _filler_8.ValueChanged += () => { _.Move(_filler_8, AUX_NRO_SIVPF); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, AUX_NRO_SIVPF); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_8 : VarBasis
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

                public _REDEF_PF0003B_FILLER_8()
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
            private _REDEF_PF0003B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_PF0003B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_PF0003B_FILLER_9(); _.Move(AUX_APOLICE, _filler_9); VarBasis.RedefinePassValue(AUX_APOLICE, _filler_9, AUX_APOLICE); _filler_9.ValueChanged += () => { _.Move(_filler_9, AUX_APOLICE); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, AUX_APOLICE); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_9 : VarBasis
            {
                /*"    10       AUX-NUMAPOL        PIC  9(013).*/
                public IntBasis AUX_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       AUX-DIGAPOL        PIC  9(001).*/
                public IntBasis AUX_DIGAPOL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-ENDOSLID.*/

                public _REDEF_PF0003B_FILLER_9()
                {
                    AUX_NUMAPOL.ValueChanged += OnValueChanged;
                    AUX_DIGAPOL.ValueChanged += OnValueChanged;
                }

            }
            public PF0003B_AUX_ENDOSLID AUX_ENDOSLID { get; set; } = new PF0003B_AUX_ENDOSLID();
            public class PF0003B_AUX_ENDOSLID : VarBasis
            {
                /*"    10       AUX-CODPRODU       PIC  9(004).*/
                public IntBasis AUX_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(011).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"  03         WS-TITULO          PIC  9(011).*/
            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  03         FILLER             REDEFINES      WS-TITULO.*/
            private _REDEF_PF0003B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_PF0003B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_PF0003B_FILLER_11(); _.Move(WS_TITULO, _filler_11); VarBasis.RedefinePassValue(WS_TITULO, _filler_11, WS_TITULO); _filler_11.ValueChanged += () => { _.Move(_filler_11, WS_TITULO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WS_TITULO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_11 : VarBasis
            {
                /*"    10       PRE-NRTIT          PIC  9(002).*/
                public IntBasis PRE_NRTIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       NRO-NUMERO         PIC  9(008).*/
                public IntBasis NRO_NUMERO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DIG-DIGITO         PIC  9(001).*/
                public IntBasis DIG_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-TITULO         PIC  9(011).*/

                public _REDEF_PF0003B_FILLER_11()
                {
                    PRE_NRTIT.ValueChanged += OnValueChanged;
                    NRO_NUMERO.ValueChanged += OnValueChanged;
                    DIG_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  03         FILLER             REDEFINES      AUX-TITULO.*/
            private _REDEF_PF0003B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_PF0003B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_PF0003B_FILLER_12(); _.Move(AUX_TITULO, _filler_12); VarBasis.RedefinePassValue(AUX_TITULO, _filler_12, AUX_TITULO); _filler_12.ValueChanged += () => { _.Move(_filler_12, AUX_TITULO); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, AUX_TITULO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_12 : VarBasis
            {
                /*"    10       AUX-NRTIT          PIC  9(002).*/
                public IntBasis AUX_NRTIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-NUMERO         PIC  9(008).*/
                public IntBasis AUX_NUMERO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       AUX-DIGITO11       PIC  9(001).*/
                public IntBasis AUX_DIGITO11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  WS-AUX-DATAS.*/

                public _REDEF_PF0003B_FILLER_12()
                {
                    AUX_NRTIT.ValueChanged += OnValueChanged;
                    AUX_NUMERO.ValueChanged += OnValueChanged;
                    AUX_DIGITO11.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0003B_WS_AUX_DATAS WS_AUX_DATAS { get; set; } = new PF0003B_WS_AUX_DATAS();
        public class PF0003B_WS_AUX_DATAS : VarBasis
        {
            /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_PF0003B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_PF0003B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_PF0003B_FILLER_13(); _.Move(WDATA_REL, _filler_13); VarBasis.RedefinePassValue(WDATA_REL, _filler_13, WDATA_REL); _filler_13.ValueChanged += () => { _.Move(_filler_13, WDATA_REL); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WDATA_REL); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_13 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDAT-REL-LIT.*/

                public _REDEF_PF0003B_FILLER_13()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public PF0003B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new PF0003B_WDAT_REL_LIT();
            public class PF0003B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA       PIC  9(002).*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES       PIC  9(002).*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO       PIC  9(004).*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-FITA.*/
            }
            public PF0003B_WDATA_FITA WDATA_FITA { get; set; } = new PF0003B_WDATA_FITA();
            public class PF0003B_WDATA_FITA : VarBasis
            {
                /*"    10       WDAT-FITA-DIA      PIC  X(002).*/
                public StringBasis WDAT_FITA_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-MES      PIC  X(002).*/
                public StringBasis WDAT_FITA_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-ANO.*/
                public PF0003B_WDAT_FITA_ANO WDAT_FITA_ANO { get; set; } = new PF0003B_WDAT_FITA_ANO();
                public class PF0003B_WDAT_FITA_ANO : VarBasis
                {
                    /*"      15     WDAT-FITA-ANO-A    PIC  X(001).*/
                    public StringBasis WDAT_FITA_ANO_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WDAT-FITA-ANO-D    PIC  X(001).*/
                    public StringBasis WDAT_FITA_ANO_D { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"  03         WDATA-TABELA.*/
                }
            }
            public PF0003B_WDATA_TABELA WDATA_TABELA { get; set; } = new PF0003B_WDATA_TABELA();
            public class PF0003B_WDATA_TABELA : VarBasis
            {
                /*"    10       WDAT-TAB-SEC       PIC  9(002).*/
                public IntBasis WDAT_TAB_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-TAB-ANO       PIC  9(002).*/
                public IntBasis WDAT_TAB_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-MES       PIC  9(002).*/
                public IntBasis WDAT_TAB_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-DIA       PIC  9(002).*/
                public IntBasis WDAT_TAB_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-SECULO       PIC  9(008)    VALUE   ZEROS.*/
            }
            public IntBasis WDATA_SECULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER             REDEFINES      WDATA-SECULO.*/
            private _REDEF_PF0003B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_PF0003B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_PF0003B_FILLER_20(); _.Move(WDATA_SECULO, _filler_20); VarBasis.RedefinePassValue(WDATA_SECULO, _filler_20, WDATA_SECULO); _filler_20.ValueChanged += () => { _.Move(_filler_20, WDATA_SECULO); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, WDATA_SECULO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_20 : VarBasis
            {
                /*"    10       WDAT-SEC-SEC       PIC  9(002).*/
                public IntBasis WDAT_SEC_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-ANO       PIC  9(002).*/
                public IntBasis WDAT_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-MES       PIC  9(002).*/
                public IntBasis WDAT_SEC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDAT-SEC-DIA       PIC  9(002).*/
                public IntBasis WDAT_SEC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         FILLER             REDEFINES      WDATA-SECULO.*/

                public _REDEF_PF0003B_FILLER_20()
                {
                    WDAT_SEC_SEC.ValueChanged += OnValueChanged;
                    WDAT_SEC_ANO.ValueChanged += OnValueChanged;
                    WDAT_SEC_MES.ValueChanged += OnValueChanged;
                    WDAT_SEC_DIA.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0003B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_PF0003B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_PF0003B_FILLER_21(); _.Move(WDATA_SECULO, _filler_21); VarBasis.RedefinePassValue(WDATA_SECULO, _filler_21, WDATA_SECULO); _filler_21.ValueChanged += () => { _.Move(_filler_21, WDATA_SECULO); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, WDATA_SECULO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_21 : VarBasis
            {
                /*"    10       WDAT-SEC-SSAA      PIC  9(004).*/
                public IntBasis WDAT_SEC_SSAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(004).*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  03         WS000-DATA         PIC  9(008)    VALUE   ZEROS.*/

                public _REDEF_PF0003B_FILLER_21()
                {
                    WDAT_SEC_SSAA.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS000_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER             REDEFINES      WS000-DATA.*/
            private _REDEF_PF0003B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_PF0003B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_PF0003B_FILLER_23(); _.Move(WS000_DATA, _filler_23); VarBasis.RedefinePassValue(WS000_DATA, _filler_23, WS000_DATA); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS000_DATA); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WS000_DATA); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_23 : VarBasis
            {
                /*"    10       WS000-DIA          PIC  9(002).*/
                public IntBasis WS000_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS000-MES          PIC  9(002).*/
                public IntBasis WS000_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS000-SEC          PIC  9(002).*/
                public IntBasis WS000_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS000-ANO          PIC  9(002).*/
                public IntBasis WS000_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_PF0003B_FILLER_23()
                {
                    WS000_DIA.ValueChanged += OnValueChanged;
                    WS000_MES.ValueChanged += OnValueChanged;
                    WS000_SEC.ValueChanged += OnValueChanged;
                    WS000_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_PF0003B_FILLER_24 _filler_24 { get; set; }
            public _REDEF_PF0003B_FILLER_24 FILLER_24
            {
                get { _filler_24 = new _REDEF_PF0003B_FILLER_24(); _.Move(WTIME_DAY, _filler_24); VarBasis.RedefinePassValue(WTIME_DAY, _filler_24, WTIME_DAY); _filler_24.ValueChanged += () => { _.Move(_filler_24, WTIME_DAY); }; return _filler_24; }
                set { VarBasis.RedefinePassValue(value, _filler_24, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_24 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public PF0003B_WTIME_DAYR WTIME_DAYR { get; set; } = new PF0003B_WTIME_DAYR();
                public class PF0003B_WTIME_DAYR : VarBasis
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

                    public PF0003B_WTIME_DAYR()
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

                public _REDEF_PF0003B_FILLER_24()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public PF0003B_WS_TIME WS_TIME { get; set; } = new PF0003B_WS_TIME();
            public class PF0003B_WS_TIME : VarBasis
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
        public PF0003B_WS_AUX_AVISO WS_AUX_AVISO { get; set; } = new PF0003B_WS_AUX_AVISO();
        public class PF0003B_WS_AUX_AVISO : VarBasis
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
            private _REDEF_PF0003B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_PF0003B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_PF0003B_FILLER_25(); _.Move(WWORK_CODEMPRE, _filler_25); VarBasis.RedefinePassValue(WWORK_CODEMPRE, _filler_25, WWORK_CODEMPRE); _filler_25.ValueChanged += () => { _.Move(_filler_25, WWORK_CODEMPRE); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WWORK_CODEMPRE); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_25 : VarBasis
            {
                /*"    10       WWORK-NRCTACED     PIC  9(015).*/
                public IntBasis WWORK_NRCTACED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER             PIC  9(001).*/
                public IntBasis FILLER_26 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-CEDENTE     PIC  9(016)    VALUE ZEROS.*/

                public _REDEF_PF0003B_FILLER_25()
                {
                    WWORK_NRCTACED.ValueChanged += OnValueChanged;
                    FILLER_26.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER            REDEFINES      WWORK-CEDENTE.*/
            private _REDEF_PF0003B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_PF0003B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_PF0003B_FILLER_27(); _.Move(WWORK_CEDENTE, _filler_27); VarBasis.RedefinePassValue(WWORK_CEDENTE, _filler_27, WWORK_CEDENTE); _filler_27.ValueChanged += () => { _.Move(_filler_27, WWORK_CEDENTE); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WWORK_CEDENTE); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_27 : VarBasis
            {
                /*"    10       WWORK-CED-AGE     PIC  9(004).*/
                public IntBasis WWORK_CED_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-CED-OPE     PIC  9(003).*/
                public IntBasis WWORK_CED_OPE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-CED-CTA1    PIC  9(005).*/
                public IntBasis WWORK_CED_CTA1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10       WWORK-CED-CTA2    PIC  9(003).*/
                public IntBasis WWORK_CED_CTA2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-CED-DIG     PIC  9(001).*/
                public IntBasis WWORK_CED_DIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-AGEAVISO    PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_PF0003B_FILLER_27()
                {
                    WWORK_CED_AGE.ValueChanged += OnValueChanged;
                    WWORK_CED_OPE.ValueChanged += OnValueChanged;
                    WWORK_CED_CTA1.ValueChanged += OnValueChanged;
                    WWORK_CED_CTA2.ValueChanged += OnValueChanged;
                    WWORK_CED_DIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         FILLER            REDEFINES      WWORK-AGEAVISO.*/
            private _REDEF_PF0003B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_PF0003B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_PF0003B_FILLER_28(); _.Move(WWORK_AGEAVISO, _filler_28); VarBasis.RedefinePassValue(WWORK_AGEAVISO, _filler_28, WWORK_AGEAVISO); _filler_28.ValueChanged += () => { _.Move(_filler_28, WWORK_AGEAVISO); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WWORK_AGEAVISO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_28 : VarBasis
            {
                /*"    10       WWORK-TIP-AGE     PIC  9(001).*/
                public IntBasis WWORK_TIP_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WWORK-COD-AGE     PIC  9(003).*/
                public IntBasis WWORK_COD_AGE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         WWORK-NRAVISO     PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_PF0003B_FILLER_28()
                {
                    WWORK_TIP_AGE.ValueChanged += OnValueChanged;
                    WWORK_COD_AGE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      WWORK-NRAVISO.*/
            private _REDEF_PF0003B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_PF0003B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_PF0003B_FILLER_29(); _.Move(WWORK_NRAVISO, _filler_29); VarBasis.RedefinePassValue(WWORK_NRAVISO, _filler_29, WWORK_NRAVISO); _filler_29.ValueChanged += () => { _.Move(_filler_29, WWORK_NRAVISO); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WWORK_NRAVISO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_29 : VarBasis
            {
                /*"    10       WWORK-AVS-AGE     PIC  9(004).*/
                public IntBasis WWORK_AVS_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-AVS-NRO     PIC  9(005).*/
                public IntBasis WWORK_AVS_NRO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WABEND.*/

                public _REDEF_PF0003B_FILLER_29()
                {
                    WWORK_AVS_AGE.ValueChanged += OnValueChanged;
                    WWORK_AVS_NRO.ValueChanged += OnValueChanged;
                }

            }
            public PF0003B_WABEND WABEND { get; set; } = new PF0003B_WABEND();
            public class PF0003B_WABEND : VarBasis
            {
                /*"    05       FILLER             PIC  X(010)    VALUE            ' PF0003B  '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PF0003B  ");
                /*"    05       FILLER             PIC  X(028)    VALUE            ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05       WNR-EXEC-SQL       PIC  X(004).*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    05       FILLER             PIC  X(014)    VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05       WSQLCODE           PIC  ZZZZZ999-.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
                /*"    05      FILLER              PIC  X(014)    VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05       WSQLERRD1          PIC  ZZZZZ999-.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
                /*"    05       FILLER             PIC  X(014)    VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05       WSQLERRD2          PIC  ZZZZZ999-.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
                /*"01        HEAD00-REGISTRO.*/
            }
        }
        public PF0003B_HEAD00_REGISTRO HEAD00_REGISTRO { get; set; } = new PF0003B_HEAD00_REGISTRO();
        public class PF0003B_HEAD00_REGISTRO : VarBasis
        {
            /*"  05      HEAD00-CODREGISTR   PIC  X(001).*/
            public StringBasis HEAD00_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEAD00-LITRETORNO   PIC  X(008).*/
            public StringBasis HEAD00_LITRETORNO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      HEAD00-NOMEMPRESA   PIC  X(013).*/
            public StringBasis HEAD00_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  05      HEAD00-DTCREDITO.*/
            public PF0003B_HEAD00_DTCREDITO HEAD00_DTCREDITO { get; set; } = new PF0003B_HEAD00_DTCREDITO();
            public class PF0003B_HEAD00_DTCREDITO : VarBasis
            {
                /*"    10    HEAD00-DIA          PIC  9(002).*/
                public IntBasis HEAD00_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEAD00-MES          PIC  9(002).*/
                public IntBasis HEAD00_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEAD00-SEC          PIC  9(002).*/
                public IntBasis HEAD00_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEAD00-ANO          PIC  9(002).*/
                public IntBasis HEAD00_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEAD00-NUMFITA      PIC  9(006).*/
            }
            public IntBasis HEAD00_NUMFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(378).*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "378", "X(378)."), @"");
            /*"  05      HEAD00-NRSEQ        PIC  9(006).*/
            public IntBasis HEAD00_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        HEAD01-REGISTRO.*/
        }
        public PF0003B_HEAD01_REGISTRO HEAD01_REGISTRO { get; set; } = new PF0003B_HEAD01_REGISTRO();
        public class PF0003B_HEAD01_REGISTRO : VarBasis
        {
            /*"  05      HEAD01-CODREGISTR   PIC  X(001).*/
            public StringBasis HEAD01_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEAD01-CODEMPRESA   PIC  9(016).*/
            public IntBasis HEAD01_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              REDEFINES     HEAD01-CODEMPRESA.*/
            private _REDEF_PF0003B_FILLER_36 _filler_36 { get; set; }
            public _REDEF_PF0003B_FILLER_36 FILLER_36
            {
                get { _filler_36 = new _REDEF_PF0003B_FILLER_36(); _.Move(HEAD01_CODEMPRESA, _filler_36); VarBasis.RedefinePassValue(HEAD01_CODEMPRESA, _filler_36, HEAD01_CODEMPRESA); _filler_36.ValueChanged += () => { _.Move(_filler_36, HEAD01_CODEMPRESA); }; return _filler_36; }
                set { VarBasis.RedefinePassValue(value, _filler_36, HEAD01_CODEMPRESA); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_36 : VarBasis
            {
                /*"    10    HEAD01-AGECEDE      PIC  9(004).*/
                public IntBasis HEAD01_AGECEDE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEAD01-OPECEDE      PIC  9(003).*/
                public IntBasis HEAD01_OPECEDE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    HEAD01-NUMCEDE      PIC  9(008).*/
                public IntBasis HEAD01_NUMCEDE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    HEAD01-DIGCEDE      PIC  9(001).*/
                public IntBasis HEAD01_DIGCEDE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      HEAD01-CONTACRED    PIC  9(016).*/

                public _REDEF_PF0003B_FILLER_36()
                {
                    HEAD01_AGECEDE.ValueChanged += OnValueChanged;
                    HEAD01_OPECEDE.ValueChanged += OnValueChanged;
                    HEAD01_NUMCEDE.ValueChanged += OnValueChanged;
                    HEAD01_DIGCEDE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis HEAD01_CONTACRED { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              REDEFINES     HEAD01-CONTACRED.*/
            private _REDEF_PF0003B_FILLER_37 _filler_37 { get; set; }
            public _REDEF_PF0003B_FILLER_37 FILLER_37
            {
                get { _filler_37 = new _REDEF_PF0003B_FILLER_37(); _.Move(HEAD01_CONTACRED, _filler_37); VarBasis.RedefinePassValue(HEAD01_CONTACRED, _filler_37, HEAD01_CONTACRED); _filler_37.ValueChanged += () => { _.Move(_filler_37, HEAD01_CONTACRED); }; return _filler_37; }
                set { VarBasis.RedefinePassValue(value, _filler_37, HEAD01_CONTACRED); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_37 : VarBasis
            {
                /*"    10    HEAD01-AGECRED      PIC  9(004).*/
                public IntBasis HEAD01_AGECRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEAD01-OPECRED      PIC  9(004).*/
                public IntBasis HEAD01_OPECRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEAD01-NUMCRED      PIC  9(012).*/
                public IntBasis HEAD01_NUMCRED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    HEAD01-DIGCRED      PIC  9(001).*/
                public IntBasis HEAD01_DIGCRED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      FILLER              PIC  X(381).*/

                public _REDEF_PF0003B_FILLER_37()
                {
                    HEAD01_AGECRED.ValueChanged += OnValueChanged;
                    HEAD01_OPECRED.ValueChanged += OnValueChanged;
                    HEAD01_NUMCRED.ValueChanged += OnValueChanged;
                    HEAD01_DIGCRED.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "381", "X(381)."), @"");
            /*"  05      HEAD01-NRSEQ        PIC  9(006).*/
            public IntBasis HEAD01_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        TRAI09-REGISTRO.*/
        }
        public PF0003B_TRAI09_REGISTRO TRAI09_REGISTRO { get; set; } = new PF0003B_TRAI09_REGISTRO();
        public class PF0003B_TRAI09_REGISTRO : VarBasis
        {
            /*"  05      TRAI09-CODREGISTR   PIC  X(001).*/
            public StringBasis TRAI09_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAI09-LITRETORNO   PIC  X(008).*/
            public StringBasis TRAI09_LITRETORNO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      TRAI09-NOMEMPRESA   PIC  X(013).*/
            public StringBasis TRAI09_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  05      TRAI09-QTDREG01     PIC  9(008).*/
            public IntBasis TRAI09_QTDREG01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      TRAI09-QTDREG02     PIC  9(008).*/
            public IntBasis TRAI09_QTDREG02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      FILLER              PIC  X(376).*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "376", "X(376)."), @"");
            /*"  05      TRAI09-NRSEQ        PIC  9(006).*/
            public IntBasis TRAI09_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        HEADER-REGISTRO.*/
        }
        public PF0003B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new PF0003B_HEADER_REGISTRO();
        public class PF0003B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTR   PIC  X(001).*/
            public StringBasis HEADER_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODRETORNO   PIC  X(001).*/
            public StringBasis HEADER_CODRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-LITRETORNO   PIC  X(007).*/
            public StringBasis HEADER_LITRETORNO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  05      HEADER-CODSERVICO   PIC  X(002).*/
            public StringBasis HEADER_CODSERVICO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-LITSERVICO   PIC  X(015).*/
            public StringBasis HEADER_LITSERVICO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-CODEMPRESA   PIC  9(016).*/
            public IntBasis HEADER_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              REDEFINES     HEADER-CODEMPRESA.*/
            private _REDEF_PF0003B_FILLER_40 _filler_40 { get; set; }
            public _REDEF_PF0003B_FILLER_40 FILLER_40
            {
                get { _filler_40 = new _REDEF_PF0003B_FILLER_40(); _.Move(HEADER_CODEMPRESA, _filler_40); VarBasis.RedefinePassValue(HEADER_CODEMPRESA, _filler_40, HEADER_CODEMPRESA); _filler_40.ValueChanged += () => { _.Move(_filler_40, HEADER_CODEMPRESA); }; return _filler_40; }
                set { VarBasis.RedefinePassValue(value, _filler_40, HEADER_CODEMPRESA); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_40 : VarBasis
            {
                /*"    10    HEADER-AGENCIA      PIC  9(004).*/
                public IntBasis HEADER_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-OPERACAO     PIC  9(003).*/
                public IntBasis HEADER_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    HEADER-NUMCONTA     PIC  9(008).*/
                public IntBasis HEADER_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    HEADER-DIGCONTA     PIC  9(001).*/
                public IntBasis HEADER_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      FILLER              PIC  X(004).*/

                public _REDEF_PF0003B_FILLER_40()
                {
                    HEADER_AGENCIA.ValueChanged += OnValueChanged;
                    HEADER_OPERACAO.ValueChanged += OnValueChanged;
                    HEADER_NUMCONTA.ValueChanged += OnValueChanged;
                    HEADER_DIGCONTA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(030).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMEBANCO    PIC  X(015).*/
            public StringBasis HEADER_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-DATAGRAVAC   PIC  9(008).*/
            public IntBasis HEADER_DATAGRAVAC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      FILLER              REDEFINES     HEADER-DATAGRAVAC.*/
            private _REDEF_PF0003B_FILLER_42 _filler_42 { get; set; }
            public _REDEF_PF0003B_FILLER_42 FILLER_42
            {
                get { _filler_42 = new _REDEF_PF0003B_FILLER_42(); _.Move(HEADER_DATAGRAVAC, _filler_42); VarBasis.RedefinePassValue(HEADER_DATAGRAVAC, _filler_42, HEADER_DATAGRAVAC); _filler_42.ValueChanged += () => { _.Move(_filler_42, HEADER_DATAGRAVAC); }; return _filler_42; }
                set { VarBasis.RedefinePassValue(value, _filler_42, HEADER_DATAGRAVAC); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_42 : VarBasis
            {
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-SEC          PIC  9(002).*/
                public IntBasis HEADER_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-ANO          PIC  9(002).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-MSGREJEIC    PIC  X(056).*/

                public _REDEF_PF0003B_FILLER_42()
                {
                    HEADER_DIA.ValueChanged += OnValueChanged;
                    HEADER_MES.ValueChanged += OnValueChanged;
                    HEADER_SEC.ValueChanged += OnValueChanged;
                    HEADER_ANO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HEADER_MSGREJEIC { get; set; } = new StringBasis(new PIC("X", "56", "X(056)."), @"");
            /*"  05      FILLER              PIC  X(205).*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "205", "X(205)."), @"");
            /*"  05      HEADER-AGEAVISO     PIC  9(004).*/
            public IntBasis HEADER_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      HEADER-CEDENTE      PIC  9(016).*/
            public IntBasis HEADER_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      HEADER-TIPO         PIC  9(001).*/
            public IntBasis HEADER_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CANAL        PIC  9(001).*/
            public IntBasis HEADER_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER              PIC  X(003).*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NUMFITA      PIC  9(006).*/
            public IntBasis HEADER_NUMFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-NRSEQ        PIC  9(006).*/
            public IntBasis HEADER_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        COBRAN-REGISTRO.*/
        }
        public PF0003B_COBRAN_REGISTRO COBRAN_REGISTRO { get; set; } = new PF0003B_COBRAN_REGISTRO();
        public class PF0003B_COBRAN_REGISTRO : VarBasis
        {
            /*"  05      COBRAN-CODREGISTR   PIC  X(001).*/
            public StringBasis COBRAN_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-INSCEMPRES   PIC  9(002).*/
            public IntBasis COBRAN_INSCEMPRES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-NUMINSCRIC   PIC  9(014).*/
            public IntBasis COBRAN_NUMINSCRIC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      COBRAN-CODEMPRESA   PIC  9(016).*/
            public IntBasis COBRAN_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      COBRAN-CONSISTE1    PIC  X(004).*/
            public StringBasis COBRAN_CONSISTE1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      COBRAN-USO-EMPRESA.*/
            public PF0003B_COBRAN_USO_EMPRESA COBRAN_USO_EMPRESA { get; set; } = new PF0003B_COBRAN_USO_EMPRESA();
            public class PF0003B_COBRAN_USO_EMPRESA : VarBasis
            {
                /*"    10    COBRAN-TITULO16     PIC  9(016).*/
                public IntBasis COBRAN_TITULO16 { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    COBRAN-CONSISTE2    PIC  X(009).*/
                public StringBasis COBRAN_CONSISTE2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"  05      COBRAN-NOSS-NUMERO  PIC  9(011).*/
            }
            public IntBasis COBRAN_NOSS_NUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05      COBRAN-FILLER2      PIC  X(006).*/
            public StringBasis COBRAN_FILLER2 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-CODREJEIC    PIC  9(003).*/
            public IntBasis COBRAN_CODREJEIC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-USO-BANCO    PIC  X(024).*/
            public StringBasis COBRAN_USO_BANCO { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
            /*"  05      COBRAN-CODCARTEIRA  PIC  X(002).*/
            public StringBasis COBRAN_CODCARTEIRA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      COBRAN-CODOCORRENC  PIC  9(002).*/
            public IntBasis COBRAN_CODOCORRENC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DATAOCORREN  PIC  9(006).*/
            public IntBasis COBRAN_DATAOCORREN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-SEU-NUMERO   PIC  X(010).*/
            public StringBasis COBRAN_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      COBRAN-FILLER3      PIC  X(020).*/
            public StringBasis COBRAN_FILLER3 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      COBRAN-DTVENCTO     PIC  9(006).*/
            public IntBasis COBRAN_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-VLR-CRS      PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_CRS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-BCO      PIC  9(003).*/
            public IntBasis COBRAN_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-AGE-BCO      PIC  9(005).*/
            public IntBasis COBRAN_AGE_BCO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      FILLER              REDEFINES     COBRAN-AGE-BCO.*/
            private _REDEF_PF0003B_FILLER_45 _filler_45 { get; set; }
            public _REDEF_PF0003B_FILLER_45 FILLER_45
            {
                get { _filler_45 = new _REDEF_PF0003B_FILLER_45(); _.Move(COBRAN_AGE_BCO, _filler_45); VarBasis.RedefinePassValue(COBRAN_AGE_BCO, _filler_45, COBRAN_AGE_BCO); _filler_45.ValueChanged += () => { _.Move(_filler_45, COBRAN_AGE_BCO); }; return _filler_45; }
                set { VarBasis.RedefinePassValue(value, _filler_45, COBRAN_AGE_BCO); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_45 : VarBasis
            {
                /*"    10    COBRAN-AGE-COBRAN   PIC  9(004).*/
                public IntBasis COBRAN_AGE_COBRAN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    COBRAN-AGE-DIGITO   PIC  9(001).*/
                public IntBasis COBRAN_AGE_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05      COBRAN-ESPECIE      PIC  X(002).*/

                public _REDEF_PF0003B_FILLER_45()
                {
                    COBRAN_AGE_COBRAN.ValueChanged += OnValueChanged;
                    COBRAN_AGE_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis COBRAN_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      COBRAN-DESPESAS     PIC  9(011)V99.*/
            public DoubleBasis COBRAN_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-FILLER4      PIC  X(026).*/
            public StringBasis COBRAN_FILLER4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"  05      COBRAN-IOF          PIC  9(011)V99.*/
            public DoubleBasis COBRAN_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-ABATIMENTO   PIC  9(011)V99.*/
            public DoubleBasis COBRAN_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-DESC-CONCED  PIC  9(011)V99.*/
            public DoubleBasis COBRAN_DESC_CONCED { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-PRINC    PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_PRINC { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-JUROS        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-MULTA        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_MULTA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-MOEDA    PIC  X(001).*/
            public StringBasis COBRAN_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-DATA-CRED    PIC  9(006).*/
            public IntBasis COBRAN_DATA_CRED { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-CC-INDICADOR PIC  X(028).*/
            public StringBasis COBRAN_CC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "28", "X(028)."), @"");
            /*"  05      FILLER              REDEFINES     COBRAN-CC-INDICADOR.*/
            private _REDEF_PF0003B_FILLER_46 _filler_46 { get; set; }
            public _REDEF_PF0003B_FILLER_46 FILLER_46
            {
                get { _filler_46 = new _REDEF_PF0003B_FILLER_46(); _.Move(COBRAN_CC_INDICADOR, _filler_46); VarBasis.RedefinePassValue(COBRAN_CC_INDICADOR, _filler_46, COBRAN_CC_INDICADOR); _filler_46.ValueChanged += () => { _.Move(_filler_46, COBRAN_CC_INDICADOR); }; return _filler_46; }
                set { VarBasis.RedefinePassValue(value, _filler_46, COBRAN_CC_INDICADOR); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_46 : VarBasis
            {
                /*"    10    COBRAN-AGE-INDIC    PIC  9(004).*/
                public IntBasis COBRAN_AGE_INDIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    COBRAN-OPER-INDIC   PIC  9(004).*/
                public IntBasis COBRAN_OPER_INDIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    COBRAN-CC-INDIC     PIC  9(012).*/
                public IntBasis COBRAN_CC_INDIC { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    COBRAN-DIG-INDIC    PIC  9(001).*/
                public IntBasis COBRAN_DIG_INDIC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    COBRAN-MATR-INDIC   PIC  9(007).*/
                public IntBasis COBRAN_MATR_INDIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05      FILLER              PIC  X(006).*/

                public _REDEF_PF0003B_FILLER_46()
                {
                    COBRAN_AGE_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_OPER_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_CC_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_DIG_INDIC.ValueChanged += OnValueChanged;
                    COBRAN_MATR_INDIC.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-CONCILIA     PIC  9(016).*/
            public IntBasis COBRAN_CONCILIA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              PIC  X(014).*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      COBRAN-CODPRODU     PIC  9(004).*/
            public IntBasis COBRAN_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      COBRAN-CEDENTE      PIC  9(016).*/
            public IntBasis COBRAN_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      COBRAN-TIPO         PIC  9(001).*/
            public IntBasis COBRAN_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-CANAL        PIC  9(001).*/
            public IntBasis COBRAN_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-SITUACAO     PIC  X(001).*/
            public StringBasis COBRAN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      FILLER              PIC  X(008).*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      COBRAN-NRSEQ        PIC  9(006).*/
            public IntBasis COBRAN_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public PF0003B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new PF0003B_TRAILL_REGISTRO();
        public class PF0003B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTR   PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-COD-RETORNO  PIC  9(001).*/
            public IntBasis TRAILL_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      TRAILL-COD-SERVICO  PIC  9(002).*/
            public IntBasis TRAILL_COD_SERVICO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      TRAILL-COD-BANCO    PIC  9(003).*/
            public IntBasis TRAILL_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      FILLER              PIC  X(360).*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "360", "X(360)."), @"");
            /*"  05      TRAILL-CEDENTE      PIC  9(016).*/
            public IntBasis TRAILL_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      TRAILL-TIPO         PIC  9(001).*/
            public IntBasis TRAILL_TIPO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      TRAILL-CANAL        PIC  9(001).*/
            public IntBasis TRAILL_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER              PIC  X(009).*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05      TRAILL-NRSEQ        PIC  9(006).*/
            public IntBasis TRAILL_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01             LPARM11X.*/
        }
        public PF0003B_LPARM11X LPARM11X { get; set; } = new PF0003B_LPARM11X();
        public class PF0003B_LPARM11X : VarBasis
        {
            /*"  03           LPARM11            PIC  9(010).*/
            public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03           FILLER             REDEFINES   LPARM11.*/
            private _REDEF_PF0003B_FILLER_52 _filler_52 { get; set; }
            public _REDEF_PF0003B_FILLER_52 FILLER_52
            {
                get { _filler_52 = new _REDEF_PF0003B_FILLER_52(); _.Move(LPARM11, _filler_52); VarBasis.RedefinePassValue(LPARM11, _filler_52, LPARM11); _filler_52.ValueChanged += () => { _.Move(_filler_52, LPARM11); }; return _filler_52; }
                set { VarBasis.RedefinePassValue(value, _filler_52, LPARM11); }
            }  //Redefines
            public class _REDEF_PF0003B_FILLER_52 : VarBasis
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

                public _REDEF_PF0003B_FILLER_52()
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
        public PF0003B_WS_AGENCIACEF WS_AGENCIACEF { get; set; } = new PF0003B_WS_AGENCIACEF();
        public class PF0003B_WS_AGENCIACEF : VarBasis
        {
            /*"  03          WACEF-AGENCIAS.*/
            public PF0003B_WACEF_AGENCIAS WACEF_AGENCIAS { get; set; } = new PF0003B_WACEF_AGENCIAS();
            public class PF0003B_WACEF_AGENCIAS : VarBasis
            {
                /*"    05        WACEF-OCORREAGE     OCCURS       4000  TIMES                                  INDEXED      BY    WS-AGE.*/
                public ListBasis<PF0003B_WACEF_OCORREAGE> WACEF_OCORREAGE { get; set; } = new ListBasis<PF0003B_WACEF_OCORREAGE>(4000);
                public class PF0003B_WACEF_OCORREAGE : VarBasis
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
            public PF0003B_WS_PRODUTOSIVPF WS_PRODUTOSIVPF { get; set; } = new PF0003B_WS_PRODUTOSIVPF();
            public class PF0003B_WS_PRODUTOSIVPF : VarBasis
            {
                /*"  03          WPROD-PRODUTOS.*/
                public PF0003B_WPROD_PRODUTOS WPROD_PRODUTOS { get; set; } = new PF0003B_WPROD_PRODUTOS();
                public class PF0003B_WPROD_PRODUTOS : VarBasis
                {
                    /*"    05        WPROD-OCORREPRD     OCCURS       300   TIMES                                  INDEXED      BY    WS-PRD.*/
                    public ListBasis<PF0003B_WPROD_OCORREPRD> WPROD_OCORREPRD { get; set; } = new ListBasis<PF0003B_WPROD_OCORREPRD>(300);
                    public class PF0003B_WPROD_OCORREPRD : VarBasis
                    {
                        /*"    10        WPROD-PRDSIVPF      PIC S9(004)        COMP.*/
                        public IntBasis WPROD_PRDSIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"    10        WPROD-CODPRODU      PIC S9(004)        COMP.*/
                        public IntBasis WPROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"01  AUX-TABELAS.*/
                    }
                }
                public PF0003B_AUX_TABELAS AUX_TABELAS { get; set; } = new PF0003B_AUX_TABELAS();
                public class PF0003B_AUX_TABELAS : VarBasis
                {
                    /*"  03          WTABG-VALORES.*/
                    public PF0003B_WTABG_VALORES WTABG_VALORES { get; set; } = new PF0003B_WTABG_VALORES();
                    public class PF0003B_WTABG_VALORES : VarBasis
                    {
                        /*"    05        WTABG-OCORREPRD     OCCURS       2000  TIMES                                  INDEXED      BY    WS-PRO.*/
                        public ListBasis<PF0003B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<PF0003B_WTABG_OCORREPRD>(2000);
                        public class PF0003B_WTABG_OCORREPRD : VarBasis
                        {
                            /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                            public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"      10      WTABG-OCORRETIP     OCCURS       005   TIMES                                  INDEXED      BY    WS-TIP.*/
                            public ListBasis<PF0003B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<PF0003B_WTABG_OCORRETIP>(005);
                            public class PF0003B_WTABG_OCORRETIP : VarBasis
                            {
                                /*"        15    WTABG-TIPO          PIC  X(001).*/
                                public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                                public ListBasis<PF0003B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<PF0003B_WTABG_OCORRESIT>(002);
                                public class PF0003B_WTABG_OCORRESIT : VarBasis
                                {
                                    /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                                    public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                                    /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                                    public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                                    /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                                    public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                                    /*"01  WS-COBERTURAS.*/
                                }
                            }
                        }
                    }
                }
                public PF0003B_WS_COBERTURAS WS_COBERTURAS { get; set; } = new PF0003B_WS_COBERTURAS();
                public class PF0003B_WS_COBERTURAS : VarBasis
                {
                    /*"  03          WCOBE-COBERTUR.*/
                    public PF0003B_WCOBE_COBERTUR WCOBE_COBERTUR { get; set; } = new PF0003B_WCOBE_COBERTUR();
                    public class PF0003B_WCOBE_COBERTUR : VarBasis
                    {
                        /*"    05        WCOBE-OCORRECOB     OCCURS       200   TIMES                                  INDEXED      BY    WS-COB.*/
                        public ListBasis<PF0003B_WCOBE_OCORRECOB> WCOBE_OCORRECOB { get; set; } = new ListBasis<PF0003B_WCOBE_OCORRECOB>(200);
                        public class PF0003B_WCOBE_OCORRECOB : VarBasis
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
                            /*"      10      WCOBE-DTINIVIG      PIC  X(010).*/
                            public StringBasis WCOBE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                            /*"      10      WCOBE-DTTERVIG      PIC  X(010).*/
                            public StringBasis WCOBE_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                            /*"01  WS-CEDENTES.*/
                        }
                    }
                }
                public PF0003B_WS_CEDENTES WS_CEDENTES { get; set; } = new PF0003B_WS_CEDENTES();
                public class PF0003B_WS_CEDENTES : VarBasis
                {
                    /*"  03          WCEDE-CCEDENTE.*/
                    public PF0003B_WCEDE_CCEDENTE WCEDE_CCEDENTE { get; set; } = new PF0003B_WCEDE_CCEDENTE();
                    public class PF0003B_WCEDE_CCEDENTE : VarBasis
                    {
                        /*"    05        WCEDE-OCORRECED     OCCURS       020   TIMES                                  INDEXED      BY    WS-CED.*/
                        public ListBasis<PF0003B_WCEDE_OCORRECED> WCEDE_OCORRECED { get; set; } = new ListBasis<PF0003B_WCEDE_OCORRECED>(020);
                        public class PF0003B_WCEDE_OCORRECED : VarBasis
                        {
                            /*"      10      WCEDE-CODEMPRESA    PIC  9(016).*/
                            public IntBasis WCEDE_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                            /*"      10      WCEDE-AGEAVISO      PIC  9(004).*/
                            public IntBasis WCEDE_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        }
                    }
                }
            }
        }


        public Copies.LBWPF004 LBWPF004 { get; set; } = new Copies.LBWPF004();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.BILHEFAI BILHEFAI { get; set; } = new Dclgens.BILHEFAI();
        public PF0003B_V0AGENCIAS V0AGENCIAS { get; set; } = new PF0003B_V0AGENCIAS();
        public PF0003B_V0PRDSIVPF V0PRDSIVPF { get; set; } = new PF0003B_V0PRDSIVPF();
        public PF0003B_V0PRODUTO V0PRODUTO { get; set; } = new PF0003B_V0PRODUTO();
        public PF0003B_V0BILCOBER V0BILCOBER { get; set; } = new PF0003B_V0BILCOBER();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string MOVIMENTO_COBRANCA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                MOVIMENTO_COBRANCA.SetFile(MOVIMENTO_COBRANCA_FILE_NAME_P);

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
            /*" -1052- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1053- DISPLAY '*               PROGRAMA  PF0003B              *' . */
            _.Display($"*               PROGRAMA  PF0003B              *");

            /*" -1054- DISPLAY '* VERSAO 06 - EM 27/11/2020    TAREFA 267.521  *' . */
            _.Display($"* VERSAO 06 - EM 27/11/2020    TAREFA 267.521  *");

            /*" -1055- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1056- DISPLAY '*' . */
            _.Display($"*");

            /*" -1064- DISPLAY 'PF0003B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"PF0003B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1066- DISPLAY '*' . */
            _.Display($"*");

            /*" -1068- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1069- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1071- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1073- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1079- PERFORM R0050-00-INICIALIZA. */

            R0050_00_INICIALIZA_SECTION();

            /*" -1089- SORT ARQSORT ON ASCENDING KEY SOR-CEDENTE SOR-TIPO SOR-CANAL INPUT PROCEDURE R0300-00-INPUT-SORT THRU R0300-99-SAIDA OUTPUT PROCEDURE R1500-00-OUTPUT-SORT THRU R1500-99-SAIDA. */
            ARQSORT.Sort("SOR-CEDENTE,SOR-TIPO,SOR-CANAL", () => R0300_00_INPUT_SORT_SECTION(), () => R1500_00_OUTPUT_SORT_SECTION());

            /*" -1092- GO TO R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIALIZA-SECTION */
        private void R0050_00_INICIALIZA_SECTION()
        {
            /*" -1105- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1108- OPEN INPUT MOVIMENTO-COBRANCA. */
            MOVIMENTO_COBRANCA.Open(REG_COBRANCA);

            /*" -1111- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -1112- SET WS-AGE TO 1. */
            WS_AGE.Value = 1;

            /*" -1113- MOVE SPACES TO WFIM-AGENCIAS */
            _.Move("", WS_AUX_ARQUIVO.WFIM_AGENCIAS);

            /*" -1115- PERFORM R0110-00-DECLARE-V0AGENCIAS. */

            R0110_00_DECLARE_V0AGENCIAS_SECTION();

            /*" -1119- PERFORM R0120-00-FETCH-V0AGENCIAS UNTIL WFIM-AGENCIAS NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_AGENCIAS.IsEmpty()))
            {

                R0120_00_FETCH_V0AGENCIAS_SECTION();
            }

            /*" -1125- MOVE 9999 TO V0ACEF-AGENCIA V0ACEF-ESCNEG V0ACEF-FONTE. */
            _.Move(9999, V0ACEF_AGENCIA, V0ACEF_ESCNEG, V0ACEF_FONTE);

            /*" -1126- SET WS-SUBS TO WS-AGE */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_AGE;

            /*" -1130- PERFORM R0130-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 4000. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 4000))
            {

                R0130_00_LIMPA_TABELA_SECTION();
            }

            /*" -1130- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1134- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -1135- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WS_AUX_ARQUIVO.WFIM_PRODUTO);

            /*" -1137- PERFORM R0150-00-DECLARE-V0PRDSIVPF. */

            R0150_00_DECLARE_V0PRDSIVPF_SECTION();

            /*" -1141- PERFORM R0160-00-FETCH-V0PRDSIVPF UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_PRODUTO.IsEmpty()))
            {

                R0160_00_FETCH_V0PRDSIVPF_SECTION();
            }

            /*" -1146- MOVE 9999 TO V0PRPF-CODSIVPF V0PRPF-CODPRODU. */
            _.Move(9999, V0PRPF_CODSIVPF, V0PRPF_CODPRODU);

            /*" -1147- SET WS-SUBS TO WS-PRD */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRD;

            /*" -1152- PERFORM R0170-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 300. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 300))
            {

                R0170_00_LIMPA_TABELA_SECTION();
            }

            /*" -1153- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -1156- PERFORM R0180-00-ZERA-CEDENTE 20 TIMES. */

            for (int i = 0; i < 20; i++)
            {

                R0180_00_ZERA_CEDENTE_SECTION();

            }

            /*" -1156- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1164- SET WS-PRO TO 1. */
            WS_PRO.Value = 1;

            /*" -1167- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -1170- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

            /*" -1171- MOVE 1 TO LD-PRODUTO */
            _.Move(1, WS_AUX_ARQUIVO.LD_PRODUTO);

            /*" -1172- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WS_AUX_ARQUIVO.WFIM_PRODUTO);

            /*" -1174- PERFORM R0200-00-DECLARE-V0PRODUTO. */

            R0200_00_DECLARE_V0PRODUTO_SECTION();

            /*" -1178- PERFORM R0210-00-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO_SECTION();
            }

            /*" -1182- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -1187- PERFORM R0220-00-MOVE-DADOS UNTIL WS-SUBS GREATER 2000. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS_SECTION();
            }

            /*" -1187- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1195- SET WS-COB TO 1. */
            WS_COB.Value = 1;

            /*" -1196- MOVE SPACES TO WFIM-BILCOBER */
            _.Move("", WS_AUX_ARQUIVO.WFIM_BILCOBER);

            /*" -1198- PERFORM R0265-00-DECLARE-V0BILCOBER. */

            R0265_00_DECLARE_V0BILCOBER_SECTION();

            /*" -1202- PERFORM R0270-00-FETCH-V0BILCOBER UNTIL WFIM-BILCOBER NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_BILCOBER.IsEmpty()))
            {

                R0270_00_FETCH_V0BILCOBER_SECTION();
            }

            /*" -1208- MOVE ZEROS TO V0BCOB-RAMOFR V0BCOB-CODOPCAO V0BCOB-VLPRMTAR V0BCOB-VLPRMTOT V0BCOB-PCIOCC. */
            _.Move(0, V0BCOB_RAMOFR, V0BCOB_CODOPCAO, V0BCOB_VLPRMTAR, V0BCOB_VLPRMTOT, V0BCOB_PCIOCC);

            /*" -1212- MOVE SPACES TO V0BCOB-DTINIVIG V0BCOB-DTTERVIG. */
            _.Move("", V0BCOB_DTINIVIG, V0BCOB_DTTERVIG);

            /*" -1213- SET WS-SUBS TO WS-COB */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_COB;

            /*" -1217- PERFORM R0280-00-LIMPA-TABELA UNTIL WS-SUBS GREATER 200. */

            while (!(WS_AUX_ARQUIVO.WS_SUBS > 200))
            {

                R0280_00_LIMPA_TABELA_SECTION();
            }

            /*" -1223- MOVE ZEROS TO AC-HEADER AC-HEADER1 AC-DETALHE AC-TRAILL. */
            _.Move(0, WS_AUX_ARQUIVO.AC_HEADER, WS_AUX_ARQUIVO.AC_HEADER1, WS_AUX_ARQUIVO.AC_DETALHE, WS_AUX_ARQUIVO.AC_TRAILL);

            /*" -1223- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1226- PERFORM R0290-00-SELECT-V0CEDENTE. */

            R0290_00_SELECT_V0CEDENTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -1239- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1245- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -1248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1249- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(V0SISTEMA)");

                /*" -1249- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -1245- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-DECLARE-V0AGENCIAS-SECTION */
        private void R0110_00_DECLARE_V0AGENCIAS_SECTION()
        {
            /*" -1262- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1275- PERFORM R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1 */

            R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1();

            /*" -1277- PERFORM R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1 */

            R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1();

            /*" -1281- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1282- DISPLAY 'R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)' */
                _.Display($"R0110-00 - PROBLEMAS DECLARE (V0AGENCIAS)");

                /*" -1282- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-DECLARE-V0AGENCIAS-DB-DECLARE-1 */
        public void R0110_00_DECLARE_V0AGENCIAS_DB_DECLARE_1()
        {
            /*" -1275- EXEC SQL DECLARE V0AGENCIAS CURSOR FOR SELECT A.COD_AGENCIA , A.COD_ESCNEG , B.COD_FONTE FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA > 0 AND A.COD_SUREG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            V0AGENCIAS = new PF0003B_V0AGENCIAS(false);
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
        /*" R0110-00-DECLARE-V0AGENCIAS-DB-OPEN-1 */
        public void R0110_00_DECLARE_V0AGENCIAS_DB_OPEN_1()
        {
            /*" -1277- EXEC SQL OPEN V0AGENCIAS END-EXEC. */

            V0AGENCIAS.Open();

        }

        [StopWatch]
        /*" R0150-00-DECLARE-V0PRDSIVPF-DB-DECLARE-1 */
        public void R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1()
        {
            /*" -1369- EXEC SQL DECLARE V0PRDSIVPF CURSOR FOR SELECT COD_PRODUTO_SIVPF, COD_PRODUTO FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 ORDER BY COD_PRODUTO_SIVPF WITH UR END-EXEC. */
            V0PRDSIVPF = new PF0003B_V0PRDSIVPF(false);
            string GetQuery_V0PRDSIVPF()
            {
                var query = @$"SELECT COD_PRODUTO_SIVPF
							, 
							COD_PRODUTO 
							FROM SEGUROS.PRODUTOS_SIVPF 
							WHERE COD_EMPRESA_SIVPF = 1 
							ORDER BY COD_PRODUTO_SIVPF";

                return query;
            }
            V0PRDSIVPF.GetQueryEvent += GetQuery_V0PRDSIVPF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-FETCH-V0AGENCIAS-SECTION */
        private void R0120_00_FETCH_V0AGENCIAS_SECTION()
        {
            /*" -1295- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1299- PERFORM R0120_00_FETCH_V0AGENCIAS_DB_FETCH_1 */

            R0120_00_FETCH_V0AGENCIAS_DB_FETCH_1();

            /*" -1303- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1303- PERFORM R0120_00_FETCH_V0AGENCIAS_DB_CLOSE_1 */

                R0120_00_FETCH_V0AGENCIAS_DB_CLOSE_1();

                /*" -1305- MOVE 'S' TO WFIM-AGENCIAS */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_AGENCIAS);

                /*" -1307- GO TO R0120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1308- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1309- DISPLAY 'R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ' */
                _.Display($"R0120-00 - PROBLEMAS FETCH (V0AGENCIAS)  ");

                /*" -1312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1315- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1318- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1322- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1322- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

        }

        [StopWatch]
        /*" R0120-00-FETCH-V0AGENCIAS-DB-FETCH-1 */
        public void R0120_00_FETCH_V0AGENCIAS_DB_FETCH_1()
        {
            /*" -1299- EXEC SQL FETCH V0AGENCIAS INTO :V0ACEF-AGENCIA , :V0ACEF-ESCNEG , :V0ACEF-FONTE END-EXEC. */

            if (V0AGENCIAS.Fetch())
            {
                _.Move(V0AGENCIAS.V0ACEF_AGENCIA, V0ACEF_AGENCIA);
                _.Move(V0AGENCIAS.V0ACEF_ESCNEG, V0ACEF_ESCNEG);
                _.Move(V0AGENCIAS.V0ACEF_FONTE, V0ACEF_FONTE);
            }

        }

        [StopWatch]
        /*" R0120-00-FETCH-V0AGENCIAS-DB-CLOSE-1 */
        public void R0120_00_FETCH_V0AGENCIAS_DB_CLOSE_1()
        {
            /*" -1303- EXEC SQL CLOSE V0AGENCIAS END-EXEC */

            V0AGENCIAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-LIMPA-TABELA-SECTION */
        private void R0130_00_LIMPA_TABELA_SECTION()
        {
            /*" -1335- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1338- MOVE V0ACEF-AGENCIA TO WACEF-AGENCIA(WS-AGE). */
            _.Move(V0ACEF_AGENCIA, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA);

            /*" -1341- MOVE V0ACEF-ESCNEG TO WACEF-ESCNEG(WS-AGE). */
            _.Move(V0ACEF_ESCNEG, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG);

            /*" -1345- MOVE V0ACEF-FONTE TO WACEF-FONTE(WS-AGE). */
            _.Move(V0ACEF_FONTE, WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_FONTE);

            /*" -1346- SET WS-AGE UP BY 1. */
            WS_AGE.Value += 1;

            /*" -1346- SET WS-SUBS TO WS-AGE. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_AGE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-DECLARE-V0PRDSIVPF-SECTION */
        private void R0150_00_DECLARE_V0PRDSIVPF_SECTION()
        {
            /*" -1359- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1369- PERFORM R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1 */

            R0150_00_DECLARE_V0PRDSIVPF_DB_DECLARE_1();

            /*" -1371- PERFORM R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1 */

            R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1();

            /*" -1375- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1376- DISPLAY 'R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)' */
                _.Display($"R0150-00 - PROBLEMAS DECLARE (V0PRDSIVPF)");

                /*" -1376- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-DECLARE-V0PRDSIVPF-DB-OPEN-1 */
        public void R0150_00_DECLARE_V0PRDSIVPF_DB_OPEN_1()
        {
            /*" -1371- EXEC SQL OPEN V0PRDSIVPF END-EXEC. */

            V0PRDSIVPF.Open();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -1474- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN (0, 10, 11) ORDER BY CODPRODU WITH UR END-EXEC. */
            V0PRODUTO = new PF0003B_V0PRODUTO(false);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-FETCH-V0PRDSIVPF-SECTION */
        private void R0160_00_FETCH_V0PRDSIVPF_SECTION()
        {
            /*" -1389- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1392- PERFORM R0160_00_FETCH_V0PRDSIVPF_DB_FETCH_1 */

            R0160_00_FETCH_V0PRDSIVPF_DB_FETCH_1();

            /*" -1396- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1396- PERFORM R0160_00_FETCH_V0PRDSIVPF_DB_CLOSE_1 */

                R0160_00_FETCH_V0PRDSIVPF_DB_CLOSE_1();

                /*" -1398- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_PRODUTO);

                /*" -1400- GO TO R0160-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1401- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1402- DISPLAY 'R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ' */
                _.Display($"R0160-00 - PROBLEMAS FETCH (V0PRDSIVPF)  ");

                /*" -1405- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1408- MOVE V0PRPF-CODSIVPF TO WPROD-PRDSIVPF(WS-PRD). */
            _.Move(V0PRPF_CODSIVPF, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF);

            /*" -1412- MOVE V0PRPF-CODPRODU TO WPROD-CODPRODU(WS-PRD). */
            _.Move(V0PRPF_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU);

            /*" -1412- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }

        [StopWatch]
        /*" R0160-00-FETCH-V0PRDSIVPF-DB-FETCH-1 */
        public void R0160_00_FETCH_V0PRDSIVPF_DB_FETCH_1()
        {
            /*" -1392- EXEC SQL FETCH V0PRDSIVPF INTO :V0PRPF-CODSIVPF , :V0PRPF-CODPRODU END-EXEC. */

            if (V0PRDSIVPF.Fetch())
            {
                _.Move(V0PRDSIVPF.V0PRPF_CODSIVPF, V0PRPF_CODSIVPF);
                _.Move(V0PRDSIVPF.V0PRPF_CODPRODU, V0PRPF_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0160-00-FETCH-V0PRDSIVPF-DB-CLOSE-1 */
        public void R0160_00_FETCH_V0PRDSIVPF_DB_CLOSE_1()
        {
            /*" -1396- EXEC SQL CLOSE V0PRDSIVPF END-EXEC */

            V0PRDSIVPF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-LIMPA-TABELA-SECTION */
        private void R0170_00_LIMPA_TABELA_SECTION()
        {
            /*" -1425- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1428- MOVE V0PRPF-CODSIVPF TO WPROD-PRDSIVPF(WS-PRD). */
            _.Move(V0PRPF_CODSIVPF, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF);

            /*" -1432- MOVE V0PRPF-CODPRODU TO WPROD-CODPRODU(WS-PRD). */
            _.Move(V0PRPF_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_CODPRODU);

            /*" -1433- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -1433- SET WS-SUBS TO WS-PRD. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-ZERA-CEDENTE-SECTION */
        private void R0180_00_ZERA_CEDENTE_SECTION()
        {
            /*" -1446- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1451- MOVE ZEROS TO WCEDE-AGEAVISO(WS-CED) WCEDE-CODEMPRESA(WS-CED). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_AGEAVISO, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA);

            /*" -1451- SET WS-CED UP BY 1. */
            WS_CED.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-SECTION */
        private void R0200_00_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -1464- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1474- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -1476- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -1480- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1481- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -1481- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -1476- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }

        [StopWatch]
        /*" R0265-00-DECLARE-V0BILCOBER-DB-DECLARE-1 */
        public void R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1()
        {
            /*" -1663- EXEC SQL DECLARE V0BILCOBER CURSOR FOR SELECT RAMOFR , COD_OPCAO , PRM_TARIFARIO_IX , VLPRMTOT , PCIOCC , DTINIVIG , DTTERVIG FROM SEGUROS.V0BILHETE_COBER WHERE RAMOFR IN (14,72,82) AND PCCOMCOR > 0 AND IDE_COBERTURA = '1' AND DTTERVIG = '9999-12-31' ORDER BY RAMOFR, COD_OPCAO WITH UR END-EXEC. */
            V0BILCOBER = new PF0003B_V0BILCOBER(false);
            string GetQuery_V0BILCOBER()
            {
                var query = @$"SELECT RAMOFR
							, 
							COD_OPCAO
							, 
							PRM_TARIFARIO_IX
							, 
							VLPRMTOT
							, 
							PCIOCC
							, 
							DTINIVIG
							, 
							DTTERVIG 
							FROM SEGUROS.V0BILHETE_COBER 
							WHERE RAMOFR IN (14
							,72
							,82) 
							AND PCCOMCOR > 0 
							AND IDE_COBERTURA = '1' 
							AND DTTERVIG = '9999-12-31' 
							ORDER BY RAMOFR
							, COD_OPCAO";

                return query;
            }
            V0BILCOBER.GetQueryEvent += GetQuery_V0BILCOBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-SECTION */
        private void R0210_00_FETCH_V0PRODUTO_SECTION()
        {
            /*" -1494- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1496- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -1500- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1500- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -1502- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_PRODUTO);

                /*" -1504- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1505- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1506- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -1509- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1512- ADD 1 TO LD-PRODUTO. */
            WS_AUX_ARQUIVO.LD_PRODUTO.Value = WS_AUX_ARQUIVO.LD_PRODUTO + 1;

            /*" -1514- IF LD-PRODUTO GREATER 2000 */

            if (WS_AUX_ARQUIVO.LD_PRODUTO > 2000)
            {

                /*" -1514- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -1516- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -1519- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1519- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -1496- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -1500- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -1514- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS-SECTION */
        private void R0220_00_MOVE_DADOS_SECTION()
        {
            /*" -1532- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1536- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRO). */
            _.Move(V0PROD_CODPRODU, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU);

            /*" -1537- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -1540- PERFORM R0250-00-MOVE-TIPO 05 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R0250_00_MOVE_TIPO_SECTION();

            }

            /*" -1541- SET WS-PRO UP BY 1. */
            WS_PRO.Value += 1;

            /*" -1541- SET WS-SUBS TO WS-PRO. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO-SECTION */
        private void R0250_00_MOVE_TIPO_SECTION()
        {
            /*" -1554- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1559- SET WS-SUBS1 TO WS-TIP. */
            WS_AUX_ARQUIVO.WS_SUBS1.Value = WS_TIP;

            /*" -1560- IF WS-SUBS1 EQUAL 1 */

            if (WS_AUX_ARQUIVO.WS_SUBS1 == 1)
            {

                /*" -1562- MOVE 'A' TO WTABG-TIPO(WS-PRO WS-TIP) */
                _.Move("A", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -1566- ELSE */
            }
            else
            {


                /*" -1567- IF WS-SUBS1 EQUAL 2 */

                if (WS_AUX_ARQUIVO.WS_SUBS1 == 2)
                {

                    /*" -1569- MOVE 'G' TO WTABG-TIPO(WS-PRO WS-TIP) */
                    _.Move("G", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -1573- ELSE */
                }
                else
                {


                    /*" -1574- IF WS-SUBS1 EQUAL 3 */

                    if (WS_AUX_ARQUIVO.WS_SUBS1 == 3)
                    {

                        /*" -1576- MOVE 'R' TO WTABG-TIPO(WS-PRO WS-TIP) */
                        _.Move("R", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                        /*" -1577- ELSE */
                    }
                    else
                    {


                        /*" -1581- IF WS-SUBS1 EQUAL 4 */

                        if (WS_AUX_ARQUIVO.WS_SUBS1 == 4)
                        {

                            /*" -1583- MOVE 'D' TO WTABG-TIPO(WS-PRO WS-TIP) */
                            _.Move("D", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                            /*" -1587- ELSE */
                        }
                        else
                        {


                            /*" -1591- MOVE 'M' TO WTABG-TIPO(WS-PRO WS-TIP). */
                            _.Move("M", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                        }

                    }

                }

            }


            /*" -1592- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -1595- PERFORM R0260-00-MOVE-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_00_MOVE_SITUACAO_SECTION();

            }

            /*" -1595- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO-SECTION */
        private void R0260_00_MOVE_SITUACAO_SECTION()
        {
            /*" -1608- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1617- MOVE ZEROS TO WTABG-QTDE(WS-PRO WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -1622- SET WS-SUBS2 TO WS-SIT. */
            WS_AUX_ARQUIVO.WS_SUBS2.Value = WS_SIT;

            /*" -1623- IF WS-SUBS2 EQUAL 1 */

            if (WS_AUX_ARQUIVO.WS_SUBS2 == 1)
            {

                /*" -1625- MOVE '0' TO WTABG-SITUACAO(WS-PRO WS-TIP WS-SIT) */
                _.Move("0", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -1629- ELSE */
            }
            else
            {


                /*" -1633- MOVE '2' TO WTABG-SITUACAO(WS-PRO WS-TIP WS-SIT). */
                _.Move("2", WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -1633- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0265-00-DECLARE-V0BILCOBER-SECTION */
        private void R0265_00_DECLARE_V0BILCOBER_SECTION()
        {
            /*" -1646- MOVE '0265' TO WNR-EXEC-SQL. */
            _.Move("0265", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1663- PERFORM R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1 */

            R0265_00_DECLARE_V0BILCOBER_DB_DECLARE_1();

            /*" -1665- PERFORM R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1 */

            R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1();

            /*" -1669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1670- DISPLAY 'R0265-00 - PROBLEMAS DECLARE (V0BILCOBER)' */
                _.Display($"R0265-00 - PROBLEMAS DECLARE (V0BILCOBER)");

                /*" -1670- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0265-00-DECLARE-V0BILCOBER-DB-OPEN-1 */
        public void R0265_00_DECLARE_V0BILCOBER_DB_OPEN_1()
        {
            /*" -1665- EXEC SQL OPEN V0BILCOBER END-EXEC. */

            V0BILCOBER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0265_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-FETCH-V0BILCOBER-SECTION */
        private void R0270_00_FETCH_V0BILCOBER_SECTION()
        {
            /*" -1683- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1691- PERFORM R0270_00_FETCH_V0BILCOBER_DB_FETCH_1 */

            R0270_00_FETCH_V0BILCOBER_DB_FETCH_1();

            /*" -1695- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1695- PERFORM R0270_00_FETCH_V0BILCOBER_DB_CLOSE_1 */

                R0270_00_FETCH_V0BILCOBER_DB_CLOSE_1();

                /*" -1697- MOVE 'S' TO WFIM-BILCOBER */
                _.Move("S", WS_AUX_ARQUIVO.WFIM_BILCOBER);

                /*" -1699- GO TO R0270-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1701- DISPLAY 'R0270-00 - PROBLEMAS FETCH (V0BILCOBER)  ' */
                _.Display($"R0270-00 - PROBLEMAS FETCH (V0BILCOBER)  ");

                /*" -1704- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1705- IF VIND-VLPRMTOT LESS ZEROS */

            if (VIND_VLPRMTOT < 00)
            {

                /*" -1707- MOVE ZEROS TO V0BCOB-VLPRMTOT. */
                _.Move(0, V0BCOB_VLPRMTOT);
            }


            /*" -1708- IF VIND-PCIOCC LESS ZEROS */

            if (VIND_PCIOCC < 00)
            {

                /*" -1711- MOVE ZEROS TO V0BCOB-PCIOCC. */
                _.Move(0, V0BCOB_PCIOCC);
            }


            /*" -1713- MOVE V0BCOB-RAMOFR TO WCOBE-RAMOFR(WS-COB). */
            _.Move(V0BCOB_RAMOFR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_RAMOFR);

            /*" -1715- MOVE V0BCOB-CODOPCAO TO WCOBE-CODOPCAO(WS-COB). */
            _.Move(V0BCOB_CODOPCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_CODOPCAO);

            /*" -1717- MOVE V0BCOB-VLPRMTAR TO WCOBE-VLPRMTAR(WS-COB). */
            _.Move(V0BCOB_VLPRMTAR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTAR);

            /*" -1719- MOVE V0BCOB-VLPRMTOT TO WCOBE-VLPRMTOT(WS-COB). */
            _.Move(V0BCOB_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTOT);

            /*" -1721- MOVE V0BCOB-PCIOCC TO WCOBE-PCIOCC(WS-COB). */
            _.Move(V0BCOB_PCIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_PCIOCC);

            /*" -1723- MOVE V0BCOB-DTINIVIG TO WCOBE-DTINIVIG(WS-COB). */
            _.Move(V0BCOB_DTINIVIG, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_DTINIVIG);

            /*" -1726- MOVE V0BCOB-DTTERVIG TO WCOBE-DTTERVIG(WS-COB). */
            _.Move(V0BCOB_DTTERVIG, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_DTTERVIG);

            /*" -1726- SET WS-COB UP BY 1. */
            WS_COB.Value += 1;

        }

        [StopWatch]
        /*" R0270-00-FETCH-V0BILCOBER-DB-FETCH-1 */
        public void R0270_00_FETCH_V0BILCOBER_DB_FETCH_1()
        {
            /*" -1691- EXEC SQL FETCH V0BILCOBER INTO :V0BCOB-RAMOFR , :V0BCOB-CODOPCAO , :V0BCOB-VLPRMTAR , :V0BCOB-VLPRMTOT:VIND-VLPRMTOT , :V0BCOB-PCIOCC:VIND-PCIOCC , :V0BCOB-DTINIVIG , :V0BCOB-DTTERVIG END-EXEC. */

            if (V0BILCOBER.Fetch())
            {
                _.Move(V0BILCOBER.V0BCOB_RAMOFR, V0BCOB_RAMOFR);
                _.Move(V0BILCOBER.V0BCOB_CODOPCAO, V0BCOB_CODOPCAO);
                _.Move(V0BILCOBER.V0BCOB_VLPRMTAR, V0BCOB_VLPRMTAR);
                _.Move(V0BILCOBER.V0BCOB_VLPRMTOT, V0BCOB_VLPRMTOT);
                _.Move(V0BILCOBER.VIND_VLPRMTOT, VIND_VLPRMTOT);
                _.Move(V0BILCOBER.V0BCOB_PCIOCC, V0BCOB_PCIOCC);
                _.Move(V0BILCOBER.VIND_PCIOCC, VIND_PCIOCC);
                _.Move(V0BILCOBER.V0BCOB_DTINIVIG, V0BCOB_DTINIVIG);
                _.Move(V0BILCOBER.V0BCOB_DTTERVIG, V0BCOB_DTTERVIG);
            }

        }

        [StopWatch]
        /*" R0270-00-FETCH-V0BILCOBER-DB-CLOSE-1 */
        public void R0270_00_FETCH_V0BILCOBER_DB_CLOSE_1()
        {
            /*" -1695- EXEC SQL CLOSE V0BILCOBER END-EXEC */

            V0BILCOBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-LIMPA-TABELA-SECTION */
        private void R0280_00_LIMPA_TABELA_SECTION()
        {
            /*" -1739- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1741- MOVE V0BCOB-RAMOFR TO WCOBE-RAMOFR(WS-COB). */
            _.Move(V0BCOB_RAMOFR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_RAMOFR);

            /*" -1743- MOVE V0BCOB-CODOPCAO TO WCOBE-CODOPCAO(WS-COB). */
            _.Move(V0BCOB_CODOPCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_CODOPCAO);

            /*" -1745- MOVE V0BCOB-VLPRMTAR TO WCOBE-VLPRMTAR(WS-COB). */
            _.Move(V0BCOB_VLPRMTAR, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTAR);

            /*" -1747- MOVE V0BCOB-VLPRMTOT TO WCOBE-VLPRMTOT(WS-COB). */
            _.Move(V0BCOB_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTOT);

            /*" -1749- MOVE V0BCOB-PCIOCC TO WCOBE-PCIOCC(WS-COB). */
            _.Move(V0BCOB_PCIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_PCIOCC);

            /*" -1751- MOVE V0BCOB-DTINIVIG TO WCOBE-DTINIVIG(WS-COB). */
            _.Move(V0BCOB_DTINIVIG, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_DTINIVIG);

            /*" -1755- MOVE V0BCOB-DTTERVIG TO WCOBE-DTTERVIG(WS-COB). */
            _.Move(V0BCOB_DTTERVIG, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_DTTERVIG);

            /*" -1756- SET WS-COB UP BY 1. */
            WS_COB.Value += 1;

            /*" -1756- SET WS-SUBS TO WS-COB. */
            WS_AUX_ARQUIVO.WS_SUBS.Value = WS_COB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-SELECT-V0CEDENTE-SECTION */
        private void R0290_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -1769- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1777- PERFORM R0290_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0290_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -1781- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1782- DISPLAY 'R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($"R0290-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -1785- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1786- MOVE V0CEDE-NUMTIT TO WWORK-MIN-NRTIT */
            _.Move(V0CEDE_NUMTIT, WS_AUX_ARQUIVO.WWORK_MIN_NRTIT);

            /*" -1786- MOVE V0CEDE-NUMTITMAX TO WWORK-MAX-NRTIT. */
            _.Move(V0CEDE_NUMTITMAX, WS_AUX_ARQUIVO.WWORK_MAX_NRTIT);

        }

        [StopWatch]
        /*" R0290-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0290_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -1777- EXEC SQL SELECT NUMTIT , NUMTITMAX INTO :V0CEDE-NUMTIT , :V0CEDE-NUMTITMAX FROM SEGUROS.V0CEDENTE WHERE CODCDT = 26 WITH UR END-EXEC. */

            var r0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r0290_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CEDE_NUMTIT, V0CEDE_NUMTIT);
                _.Move(executed_1.V0CEDE_NUMTITMAX, V0CEDE_NUMTITMAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-INPUT-SORT-SECTION */
        private void R0300_00_INPUT_SORT_SECTION()
        {
            /*" -1799- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1800- MOVE SPACES TO WFIM-COBRANCA. */
            _.Move("", WS_AUX_ARQUIVO.WFIM_COBRANCA);

            /*" -1803- PERFORM R0310-00-LE-COBRANCA. */

            R0310_00_LE_COBRANCA_SECTION();

            /*" -1804- IF WFIM-COBRANCA NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WFIM_COBRANCA.IsEmpty())
            {

                /*" -1805- DISPLAY '****** ARQUIVO VAZIO ******' */
                _.Display($"****** ARQUIVO VAZIO ******");

                /*" -1806- PERFORM R9800-00-ENCERRA-SEM-MOVTO */

                R9800_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1809- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -1810- IF ENT-CODREGISTR NOT EQUAL '0' */

            if (REG_COBRANCA.ENT_CODREGISTR != "0")
            {

                /*" -1811- DISPLAY '****** ARQUIVO SEM HEADER ******' */
                _.Display($"****** ARQUIVO SEM HEADER ******");

                /*" -1814- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1818- PERFORM R0350-00-GRAVA-SORT UNTIL WFIM-COBRANCA NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_COBRANCA.IsEmpty()))
            {

                R0350_00_GRAVA_SORT_SECTION();
            }

            /*" -1819- IF AC-HEADER NOT EQUAL AC-TRAILL */

            if (WS_AUX_ARQUIVO.AC_HEADER != WS_AUX_ARQUIVO.AC_TRAILL)
            {

                /*" -1820- DISPLAY '****** ARQUIVO SEM TRAILLER ******' */
                _.Display($"****** ARQUIVO SEM TRAILLER ******");

                /*" -1820- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-LE-COBRANCA-SECTION */
        private void R0310_00_LE_COBRANCA_SECTION()
        {
            /*" -1833- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1834- READ MOVIMENTO-COBRANCA AT END */
            try
            {
                MOVIMENTO_COBRANCA.Read(() =>
                {

                    /*" -1836- MOVE 'S' TO WFIM-COBRANCA */
                    _.Move("S", WS_AUX_ARQUIVO.WFIM_COBRANCA);

                    /*" -1838- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO_COBRANCA.Value, REG_COBRANCA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1845- ADD 1 TO LD-COBRANCA. */
            WS_AUX_ARQUIVO.LD_COBRANCA.Value = WS_AUX_ARQUIVO.LD_COBRANCA + 1;

            /*" -1846- IF REG-COBRANCA EQUAL SPACES */

            if (REG_COBRANCA.IsEmpty())
            {

                /*" -1847- ADD 1 TO DP-COBRANCA */
                WS_AUX_ARQUIVO.DP_COBRANCA.Value = WS_AUX_ARQUIVO.DP_COBRANCA + 1;

                /*" -1847- GO TO R0310-00-LE-COBRANCA. */
                new Task(() => R0310_00_LE_COBRANCA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-GRAVA-SORT-SECTION */
        private void R0350_00_GRAVA_SORT_SECTION()
        {
            /*" -1860- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1861- IF ENT-CODREGISTR EQUAL '0' */

            if (REG_COBRANCA.ENT_CODREGISTR == "0")
            {

                /*" -1862- ADD 1 TO AC-HEADER */
                WS_AUX_ARQUIVO.AC_HEADER.Value = WS_AUX_ARQUIVO.AC_HEADER + 1;

                /*" -1863- MOVE REG-COBRANCA TO HEAD00-REGISTRO */
                _.Move(MOVIMENTO_COBRANCA?.Value, HEAD00_REGISTRO);

                /*" -1864- PERFORM R0360-00-TRATA-HEADER00 */

                R0360_00_TRATA_HEADER00_SECTION();

                /*" -1865- GO TO R0350-90-LEITURA */

                R0350_90_LEITURA(); //GOTO
                return;

                /*" -1866- ELSE */
            }
            else
            {


                /*" -1867- IF ENT-CODREGISTR EQUAL '1' */

                if (REG_COBRANCA.ENT_CODREGISTR == "1")
                {

                    /*" -1868- ADD 1 TO AC-HEADER1 */
                    WS_AUX_ARQUIVO.AC_HEADER1.Value = WS_AUX_ARQUIVO.AC_HEADER1 + 1;

                    /*" -1869- MOVE REG-COBRANCA TO HEAD01-REGISTRO */
                    _.Move(MOVIMENTO_COBRANCA?.Value, HEAD01_REGISTRO);

                    /*" -1870- PERFORM R0365-00-TRATA-HEADER01 */

                    R0365_00_TRATA_HEADER01_SECTION();

                    /*" -1871- GO TO R0350-90-LEITURA */

                    R0350_90_LEITURA(); //GOTO
                    return;

                    /*" -1872- ELSE */
                }
                else
                {


                    /*" -1873- IF ENT-CODREGISTR EQUAL '9' */

                    if (REG_COBRANCA.ENT_CODREGISTR == "9")
                    {

                        /*" -1874- ADD 1 TO AC-TRAILL */
                        WS_AUX_ARQUIVO.AC_TRAILL.Value = WS_AUX_ARQUIVO.AC_TRAILL + 1;

                        /*" -1875- MOVE REG-COBRANCA TO TRAI09-REGISTRO */
                        _.Move(MOVIMENTO_COBRANCA?.Value, TRAI09_REGISTRO);

                        /*" -1876- PERFORM R0370-00-TRATA-TRAILLER */

                        R0370_00_TRATA_TRAILLER_SECTION();

                        /*" -1877- GO TO R0350-90-LEITURA */

                        R0350_90_LEITURA(); //GOTO
                        return;

                        /*" -1878- ELSE */
                    }
                    else
                    {


                        /*" -1879- IF ENT-CODREGISTR NOT EQUAL '2' */

                        if (REG_COBRANCA.ENT_CODREGISTR != "2")
                        {

                            /*" -1880- ADD 1 TO NP-COBRANCA */
                            WS_AUX_ARQUIVO.NP_COBRANCA.Value = WS_AUX_ARQUIVO.NP_COBRANCA + 1;

                            /*" -1881- GO TO R0350-90-LEITURA */

                            R0350_90_LEITURA(); //GOTO
                            return;

                            /*" -1882- ELSE */
                        }
                        else
                        {


                            /*" -1883- ADD 1 TO AC-DETALHE */
                            WS_AUX_ARQUIVO.AC_DETALHE.Value = WS_AUX_ARQUIVO.AC_DETALHE + 1;

                            /*" -1886- MOVE ENT-REGSICOB TO COBRAN-REGISTRO. */
                            _.Move(REG_COBRANCA.ENT_REGSICOB, COBRAN_REGISTRO);
                        }

                    }

                }

            }


            /*" -1888- ADD 1 TO DE-COBRANCA. */
            WS_AUX_ARQUIVO.DE_COBRANCA.Value = WS_AUX_ARQUIVO.DE_COBRANCA + 1;

            /*" -1889- IF COBRAN-CODEMPRESA NOT EQUAL HEAD01-CODEMPRESA */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA != HEAD01_REGISTRO.HEAD01_CODEMPRESA)
            {

                /*" -1890- DISPLAY 'CEDENTE NAO PREVISTO - VER ARQUIVO' */
                _.Display($"CEDENTE NAO PREVISTO - VER ARQUIVO");

                /*" -1893- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1895- IF COBRAN-CONSISTE1 NOT EQUAL SPACES OR COBRAN-CONSISTE2 NOT EQUAL SPACES */

            if (!COBRAN_REGISTRO.COBRAN_CONSISTE1.IsEmpty() || !COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_CONSISTE2.IsEmpty())
            {

                /*" -1896- DISPLAY 'TITULO FORA DA POSICAO ' LD-COBRANCA */
                _.Display($"TITULO FORA DA POSICAO {WS_AUX_ARQUIVO.LD_COBRANCA}");

                /*" -1899- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1902- MOVE SPACES TO COBRAN-SITUACAO. */
            _.Move("", COBRAN_REGISTRO.COBRAN_SITUACAO);

            /*" -1903- IF COBRAN-MATR-INDIC NOT NUMERIC */

            if (!COBRAN_REGISTRO.FILLER_46.COBRAN_MATR_INDIC.IsNumeric())
            {

                /*" -1905- MOVE ZEROS TO COBRAN-MATR-INDIC. */
                _.Move(0, COBRAN_REGISTRO.FILLER_46.COBRAN_MATR_INDIC);
            }


            /*" -1906- IF COBRAN-TITULO16 NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16.IsNumeric())
            {

                /*" -1909- MOVE ZEROS TO COBRAN-TITULO16. */
                _.Move(0, COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16);
            }


            /*" -1911- IF COBRAN-CODEMPRESA EQUAL 630870000000334 OR 630870000000610 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA.In("630870000000334", "630870000000610"))
            {

                /*" -1914- MOVE ZEROS TO COBRAN-ABATIMENTO. */
                _.Move(0, COBRAN_REGISTRO.COBRAN_ABATIMENTO);
            }


            /*" -1915- IF COBRAN-TITULO16 EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 == 00)
            {

                /*" -1917- IF COBRAN-CODEMPRESA NOT EQUAL 630003000002224 AND COBRAN-CODEMPRESA NOT EQUAL 630003000003336 */

                if (COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630003000002224 && COBRAN_REGISTRO.COBRAN_CODEMPRESA != 630003000003336)
                {

                    /*" -1918- PERFORM R0400-00-TRATA-NRTIT-ZERO */

                    R0400_00_TRATA_NRTIT_ZERO_SECTION();

                    /*" -1919- ELSE */
                }
                else
                {


                    /*" -1922- PERFORM R0940-00-SELECT-V0CONTROLE. */

                    R0940_00_SELECT_V0CONTROLE_SECTION();
                }

            }


            /*" -1923- MOVE COBRAN-USO-EMPRESA TO AUX-USO-EMPRESA */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -1926- MOVE AUX-TITSIVPF TO AUX-NRO-SIVPF AUX-TIT-GRAFICA. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_NRO_SIVPF, WS_AUX_ARQUIVO.AUX_TIT_GRAFICA);

            /*" -1927- MOVE COBRAN-CODEMPRESA TO COBRAN-CEDENTE */
            _.Move(COBRAN_REGISTRO.COBRAN_CODEMPRESA, COBRAN_REGISTRO.COBRAN_CEDENTE);

            /*" -1928- MOVE COBRAN-CODREGISTR TO COBRAN-TIPO */
            _.Move(COBRAN_REGISTRO.COBRAN_CODREGISTR, COBRAN_REGISTRO.COBRAN_TIPO);

            /*" -1929- MOVE AUX-CANAL TO COBRAN-CANAL */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.AUX_CANAL, COBRAN_REGISTRO.COBRAN_CANAL);

            /*" -1936- MOVE ZEROS TO COBRAN-CODPRODU. */
            _.Move(0, COBRAN_REGISTRO.COBRAN_CODPRODU);

            /*" -1938- IF COBRAN-CANAL EQUAL ZEROS AND COBRAN-TITULO16 NOT EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_CANAL == 00 && COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 != 00)
            {

                /*" -1939- MOVE AUX-NUM-GRAFICA TO V0SFRC-NRTIT */
                _.Move(WS_AUX_ARQUIVO.FILLER_6.AUX_NUM_GRAFICA, V0SFRC_NRTIT);

                /*" -1940- PERFORM R0700-00-SELECT-SICOB-FAIXA */

                R0700_00_SELECT_SICOB_FAIXA_SECTION();

                /*" -1941- ELSE */
            }
            else
            {


                /*" -1943- IF COBRAN-CODEMPRESA EQUAL 630003000002224 OR COBRAN-CODEMPRESA EQUAL 630003000003336 */

                if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630003000002224 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630003000003336)
                {

                    /*" -1946- PERFORM R1030-00-SELECT-BILHEFAI. */

                    R1030_00_SELECT_BILHEFAI_SECTION();
                }

            }


            /*" -1947- IF COBRAN-CODPRODU EQUAL 8201 */

            if (COBRAN_REGISTRO.COBRAN_CODPRODU == 8201)
            {

                /*" -1948- MOVE 8202 TO COBRAN-CODPRODU */
                _.Move(8202, COBRAN_REGISTRO.COBRAN_CODPRODU);

                /*" -1949- ELSE */
            }
            else
            {


                /*" -1951- IF COBRAN-CODPRODU EQUAL 7106 OR 7108 */

                if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("7106", "7108"))
                {

                    /*" -1954- MOVE 1402 TO COBRAN-CODPRODU. */
                    _.Move(1402, COBRAN_REGISTRO.COBRAN_CODPRODU);
                }

            }


            /*" -1955- MOVE COBRAN-REGISTRO TO REG-ARQSORT */
            _.Move(COBRAN_REGISTRO, REG_ARQSORT);

            /*" -1955- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -1960- PERFORM R0310-00-LE-COBRANCA. */

            R0310_00_LE_COBRANCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-TRATA-HEADER00-SECTION */
        private void R0360_00_TRATA_HEADER00_SECTION()
        {
            /*" -1972- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -1975- MOVE SPACES TO WCHV-ERRO. */
            _.Move("", WS_AUX_ARQUIVO.WCHV_ERRO);

            /*" -1976- IF HEAD00-CODREGISTR NOT EQUAL '0' */

            if (HEAD00_REGISTRO.HEAD00_CODREGISTR != "0")
            {

                /*" -1977- DISPLAY 'TIPO DE REGISTRO INVALIDO PARA O HEADER ' */
                _.Display($"TIPO DE REGISTRO INVALIDO PARA O HEADER ");

                /*" -1979- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -1980- IF HEAD00-LITRETORNO NOT EQUAL 'REPASSE' */

            if (HEAD00_REGISTRO.HEAD00_LITRETORNO != "REPASSE")
            {

                /*" -1981- DISPLAY 'NOME DO ARQUIVO INVALIDO PARA O HEADER ' */
                _.Display($"NOME DO ARQUIVO INVALIDO PARA O HEADER ");

                /*" -1983- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -1984- IF HEAD00-NOMEMPRESA NOT EQUAL 'SEGUROS' */

            if (HEAD00_REGISTRO.HEAD00_NOMEMPRESA != "SEGUROS")
            {

                /*" -1985- DISPLAY 'NOME DA EMPRESA INVALIDA PARA O HEADER ' */
                _.Display($"NOME DA EMPRESA INVALIDA PARA O HEADER ");

                /*" -1987- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -1988- IF HEAD00-DTCREDITO EQUAL SPACES */

            if (HEAD00_REGISTRO.HEAD00_DTCREDITO.IsEmpty())
            {

                /*" -1989- DISPLAY 'DATA DO CREDITO INVALIDA PARA O HEADER ' */
                _.Display($"DATA DO CREDITO INVALIDA PARA O HEADER ");

                /*" -1991- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -1992- IF HEAD00-NUMFITA NOT NUMERIC */

            if (!HEAD00_REGISTRO.HEAD00_NUMFITA.IsNumeric())
            {

                /*" -1993- DISPLAY 'SEQUENCIAL FILE INVALIDO PARA O HEADER ' */
                _.Display($"SEQUENCIAL FILE INVALIDO PARA O HEADER ");

                /*" -1994- MOVE '*' TO WCHV-ERRO */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);

                /*" -1995- ELSE */
            }
            else
            {


                /*" -1996- IF HEAD00-NUMFITA EQUAL ZEROS */

                if (HEAD00_REGISTRO.HEAD00_NUMFITA == 00)
                {

                    /*" -1997- DISPLAY 'SEQUENCIAL FILE INVALIDO PARA O HEADER ' */
                    _.Display($"SEQUENCIAL FILE INVALIDO PARA O HEADER ");

                    /*" -2000- MOVE '*' TO WCHV-ERRO. */
                    _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
                }

            }


            /*" -2003- IF AC-HEADER1 NOT EQUAL ZEROS OR AC-DETALHE NOT EQUAL ZEROS OR AC-TRAILL NOT EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.AC_HEADER1 != 00 || WS_AUX_ARQUIVO.AC_DETALHE != 00 || WS_AUX_ARQUIVO.AC_TRAILL != 00)
            {

                /*" -2004- DISPLAY 'HEADER NAO E O PRIMEIRO REGISTRO       ' */
                _.Display($"HEADER NAO E O PRIMEIRO REGISTRO       ");

                /*" -2006- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2007- IF AC-HEADER NOT EQUAL 1 */

            if (WS_AUX_ARQUIVO.AC_HEADER != 1)
            {

                /*" -2008- DISPLAY 'ARQUIVO COM MAIS DE UM HEADER          ' */
                _.Display($"ARQUIVO COM MAIS DE UM HEADER          ");

                /*" -2011- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2012- IF WCHV-ERRO NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WCHV_ERRO.IsEmpty())
            {

                /*" -2018- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2020- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -2022- MOVE '0' TO HEADER-CODREGISTR. */
            _.Move("0", HEADER_REGISTRO.HEADER_CODREGISTR);

            /*" -2024- MOVE '2' TO HEADER-CODRETORNO. */
            _.Move("2", HEADER_REGISTRO.HEADER_CODRETORNO);

            /*" -2026- MOVE 'RETORNO' TO HEADER-LITRETORNO. */
            _.Move("RETORNO", HEADER_REGISTRO.HEADER_LITRETORNO);

            /*" -2028- MOVE '01' TO HEADER-CODSERVICO. */
            _.Move("01", HEADER_REGISTRO.HEADER_CODSERVICO);

            /*" -2030- MOVE 'COBRANCA' TO HEADER-LITSERVICO. */
            _.Move("COBRANCA", HEADER_REGISTRO.HEADER_LITSERVICO);

            /*" -2036- MOVE ZEROS TO HEADER-CODEMPRESA HEADER-CEDENTE HEADER-TIPO HEADER-CANAL HEADER-NRSEQ. */
            _.Move(0, HEADER_REGISTRO.HEADER_CODEMPRESA, HEADER_REGISTRO.HEADER_CEDENTE, HEADER_REGISTRO.HEADER_TIPO, HEADER_REGISTRO.HEADER_CANAL, HEADER_REGISTRO.HEADER_NRSEQ);

            /*" -2038- MOVE '104' TO HEADER-CODBANCO. */
            _.Move("104", HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -2041- MOVE 'C ECON FEDERAL' TO HEADER-NOMEBANCO. */
            _.Move("C ECON FEDERAL", HEADER_REGISTRO.HEADER_NOMEBANCO);

            /*" -2043- MOVE HEAD00-DIA TO WS000-DIA. */
            _.Move(HEAD00_REGISTRO.HEAD00_DTCREDITO.HEAD00_DIA, WS_AUX_DATAS.FILLER_23.WS000_DIA);

            /*" -2045- MOVE HEAD00-MES TO WS000-MES. */
            _.Move(HEAD00_REGISTRO.HEAD00_DTCREDITO.HEAD00_MES, WS_AUX_DATAS.FILLER_23.WS000_MES);

            /*" -2047- MOVE HEAD00-SEC TO WS000-SEC. */
            _.Move(HEAD00_REGISTRO.HEAD00_DTCREDITO.HEAD00_SEC, WS_AUX_DATAS.FILLER_23.WS000_SEC);

            /*" -2049- MOVE HEAD00-ANO TO WS000-ANO. */
            _.Move(HEAD00_REGISTRO.HEAD00_DTCREDITO.HEAD00_ANO, WS_AUX_DATAS.FILLER_23.WS000_ANO);

            /*" -2051- MOVE WS000-DATA TO HEADER-DATAGRAVAC. */
            _.Move(WS_AUX_DATAS.WS000_DATA, HEADER_REGISTRO.HEADER_DATAGRAVAC);

            /*" -2052- MOVE HEAD00-NUMFITA TO HEADER-NUMFITA. */
            _.Move(HEAD00_REGISTRO.HEAD00_NUMFITA, HEADER_REGISTRO.HEADER_NUMFITA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0365-00-TRATA-HEADER01-SECTION */
        private void R0365_00_TRATA_HEADER01_SECTION()
        {
            /*" -2065- MOVE '0365' TO WNR-EXEC-SQL. */
            _.Move("0365", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2068- DISPLAY ' CEDENTE  =  ' HEAD01-CODEMPRESA. */
            _.Display($" CEDENTE  =  {HEAD01_REGISTRO.HEAD01_CODEMPRESA}");

            /*" -2071- MOVE SPACES TO WCHV-ERRO. */
            _.Move("", WS_AUX_ARQUIVO.WCHV_ERRO);

            /*" -2072- IF AC-HEADER EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.AC_HEADER == 00)
            {

                /*" -2073- DISPLAY 'ARQUIVO SEM HEADER                     ' */
                _.Display($"ARQUIVO SEM HEADER                     ");

                /*" -2076- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2077- IF HEAD01-CODREGISTR NOT EQUAL '1' */

            if (HEAD01_REGISTRO.HEAD01_CODREGISTR != "1")
            {

                /*" -2078- DISPLAY 'TIPO DE REGISTRO INVALIDO PARA O REPASSE' */
                _.Display($"TIPO DE REGISTRO INVALIDO PARA O REPASSE");

                /*" -2081- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2092- IF HEAD01-CODEMPRESA NOT EQUAL 630870000000113 AND HEAD01-CODEMPRESA NOT EQUAL 630870000000318 AND HEAD01-CODEMPRESA NOT EQUAL 630870000000334 AND HEAD01-CODEMPRESA NOT EQUAL 630870000000342 AND HEAD01-CODEMPRESA NOT EQUAL 630870000000601 AND HEAD01-CODEMPRESA NOT EQUAL 630870000000610 AND HEAD01-CODEMPRESA NOT EQUAL 630870000000750 AND HEAD01-CODEMPRESA NOT EQUAL 630870000001004 AND HEAD01-CODEMPRESA NOT EQUAL 630870000001136 AND HEAD01-CODEMPRESA NOT EQUAL 630003000002224 AND HEAD01-CODEMPRESA NOT EQUAL 630003000003336 */

            if (HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000113 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000318 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000334 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000342 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000601 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000610 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000000750 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000001004 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630870000001136 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630003000002224 && HEAD01_REGISTRO.HEAD01_CODEMPRESA != 630003000003336)
            {

                /*" -2093- DISPLAY 'CEDENTE NAO PREVISTO - VER ARQUIVO' */
                _.Display($"CEDENTE NAO PREVISTO - VER ARQUIVO");

                /*" -2096- MOVE '*' TO WCHV-ERRO. */
                _.Move("*", WS_AUX_ARQUIVO.WCHV_ERRO);
            }


            /*" -2097- IF WCHV-ERRO NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WCHV_ERRO.IsEmpty())
            {

                /*" -2100- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2101- MOVE HEAD01-CONTACRED TO WWORK-CEDENTE. */
            _.Move(HEAD01_REGISTRO.HEAD01_CONTACRED, WS_AUX_AVISO.WWORK_CEDENTE);

            /*" -2102- MOVE 7 TO WWORK-TIP-AGE. */
            _.Move(7, WS_AUX_AVISO.FILLER_28.WWORK_TIP_AGE);

            /*" -2105- MOVE WWORK-CED-CTA2 TO WWORK-COD-AGE. */
            _.Move(WS_AUX_AVISO.FILLER_27.WWORK_CED_CTA2, WS_AUX_AVISO.FILLER_28.WWORK_COD_AGE);

            /*" -2106- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -2107- SEARCH WCEDE-OCORRECED */
            for (; WS_CED < WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED.Items.Count; WS_CED.Value++)
            {

                /*" -2111- WHEN (HEAD01-CODEMPRESA EQUAL WCEDE-CODEMPRESA(WS-CED) OR WCEDE-CODEMPRESA(WS-CED) EQUAL ZEROS) */

                if ((HEAD01_REGISTRO.HEAD01_CODEMPRESA == WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA || WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA == 00))
                {


                    /*" -2113- MOVE HEAD01-CODEMPRESA TO WCEDE-CODEMPRESA(WS-CED) */
                    _.Move(HEAD01_REGISTRO.HEAD01_CODEMPRESA, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA);

                    /*" -2114- MOVE WWORK-AGEAVISO TO WCEDE-AGEAVISO(WS-CED)  END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0365_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-TRATA-TRAILLER-SECTION */
        private void R0370_00_TRATA_TRAILLER_SECTION()
        {
            /*" -2127- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2128- SET WS-CED TO 1 */
            WS_CED.Value = 1;

            /*" -2128- PERFORM R0380-00-GRAVA-HEADTRAI 20 TIMES. */

            for (int i = 0; i < 20; i++)
            {

                R0380_00_GRAVA_HEADTRAI_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0380-00-GRAVA-HEADTRAI-SECTION */
        private void R0380_00_GRAVA_HEADTRAI_SECTION()
        {
            /*" -2141- MOVE '0380' TO WNR-EXEC-SQL. */
            _.Move("0380", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2142- IF WCEDE-CODEMPRESA(WS-CED) EQUAL ZEROS */

            if (WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA == 00)
            {

                /*" -2143- SET WS-CED UP BY 1 */
                WS_CED.Value += 1;

                /*" -2149- GO TO R0380-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2151- MOVE WCEDE-AGEAVISO(WS-CED) TO HEADER-AGEAVISO */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_AGEAVISO, HEADER_REGISTRO.HEADER_AGEAVISO);

            /*" -2154- MOVE WCEDE-CODEMPRESA(WS-CED) TO HEADER-CODEMPRESA HEADER-CEDENTE. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA, HEADER_REGISTRO.HEADER_CODEMPRESA, HEADER_REGISTRO.HEADER_CEDENTE);

            /*" -2158- MOVE HEADER-CODREGISTR TO HEADER-TIPO HEADER-CANAL. */
            _.Move(HEADER_REGISTRO.HEADER_CODREGISTR, HEADER_REGISTRO.HEADER_TIPO, HEADER_REGISTRO.HEADER_CANAL);

            /*" -2159- MOVE HEADER-REGISTRO TO REG-ARQSORT */
            _.Move(HEADER_REGISTRO, REG_ARQSORT);

            /*" -2165- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -2166- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -2168- MOVE TRAI09-CODREGISTR TO TRAILL-CODREGISTR. */
            _.Move(TRAI09_REGISTRO.TRAI09_CODREGISTR, TRAILL_REGISTRO.TRAILL_CODREGISTR);

            /*" -2170- MOVE 2 TO TRAILL-COD-RETORNO. */
            _.Move(2, TRAILL_REGISTRO.TRAILL_COD_RETORNO);

            /*" -2172- MOVE 01 TO TRAILL-COD-SERVICO. */
            _.Move(01, TRAILL_REGISTRO.TRAILL_COD_SERVICO);

            /*" -2174- MOVE 104 TO TRAILL-COD-BANCO. */
            _.Move(104, TRAILL_REGISTRO.TRAILL_COD_BANCO);

            /*" -2177- MOVE ZEROS TO TRAILL-NRSEQ. */
            _.Move(0, TRAILL_REGISTRO.TRAILL_NRSEQ);

            /*" -2179- MOVE WCEDE-CODEMPRESA(WS-CED) TO TRAILL-CEDENTE */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA, TRAILL_REGISTRO.TRAILL_CEDENTE);

            /*" -2183- MOVE TRAILL-CODREGISTR TO TRAILL-TIPO TRAILL-CANAL. */
            _.Move(TRAILL_REGISTRO.TRAILL_CODREGISTR, TRAILL_REGISTRO.TRAILL_TIPO, TRAILL_REGISTRO.TRAILL_CANAL);

            /*" -2184- MOVE TRAILL-REGISTRO TO REG-ARQSORT */
            _.Move(TRAILL_REGISTRO, REG_ARQSORT);

            /*" -2187- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -2191- MOVE ZEROS TO WCEDE-CODEMPRESA(WS-CED). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_CEDENTES.WCEDE_CCEDENTE.WCEDE_OCORRECED[WS_CED].WCEDE_CODEMPRESA);

            /*" -2191- SET WS-CED UP BY 1. */
            WS_CED.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-TRATA-NRTIT-ZERO-SECTION */
        private void R0400_00_TRATA_NRTIT_ZERO_SECTION()
        {
            /*" -2204- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2205- MOVE COBRAN-NOSS-NUMERO TO WS-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WS_AUX_ARQUIVO.WS_NRTIT);

            /*" -2207- PERFORM R0410-00-CONFERE-TITULO. */

            R0410_00_CONFERE_TITULO_SECTION();

            /*" -2208- IF COBRAN-NOSS-NUMERO NOT EQUAL WS-NRTIT */

            if (COBRAN_REGISTRO.COBRAN_NOSS_NUMERO != WS_AUX_ARQUIVO.WS_NRTIT)
            {

                /*" -2211- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2212- MOVE COBRAN-NOSS-NUMERO TO V0SFRC-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, V0SFRC_NRTIT);

            /*" -2214- PERFORM R0450-00-SELECT-SICOB-FAIXA. */

            R0450_00_SELECT_SICOB_FAIXA_SECTION();

            /*" -2215- IF V0SFRC-NRTIT EQUAL ZEROS */

            if (V0SFRC_NRTIT == 00)
            {

                /*" -2218- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2219- MOVE '8' TO AUX-OITO */
            _.Move("8", WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_OITO);

            /*" -2220- MOVE COBRAN-NOSS-NUMERO TO AUX-TITSIVPF */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF);

            /*" -2221- MOVE '0         ' TO AUX-ESPACOS */
            _.Move("0         ", WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_ESPACOS);

            /*" -2225- MOVE AUX-USO-EMPRESA TO COBRAN-USO-EMPRESA. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA, COBRAN_REGISTRO.COBRAN_USO_EMPRESA);

            /*" -2225- ADD 1 TO AC-SALVA. */
            WS_AUX_ARQUIVO.AC_SALVA.Value = WS_AUX_ARQUIVO.AC_SALVA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-CONFERE-TITULO-SECTION */
        private void R0410_00_CONFERE_TITULO_SECTION()
        {
            /*" -2238- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2241- MOVE WS-NUMTIT TO LPARM11. */
            _.Move(WS_AUX_ARQUIVO.FILLER_5.WS_NUMTIT, LPARM11X.LPARM11);

            /*" -2252- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            WS_AUX_ARQUIVO.WPARM11_AUX.Value = LPARM11X.FILLER_52.LPARM11_1 * 3 + LPARM11X.FILLER_52.LPARM11_2 * 2 + LPARM11X.FILLER_52.LPARM11_3 * 9 + LPARM11X.FILLER_52.LPARM11_4 * 8 + LPARM11X.FILLER_52.LPARM11_5 * 7 + LPARM11X.FILLER_52.LPARM11_6 * 6 + LPARM11X.FILLER_52.LPARM11_7 * 5 + LPARM11X.FILLER_52.LPARM11_8 * 4 + LPARM11X.FILLER_52.LPARM11_9 * 3 + LPARM11X.FILLER_52.LPARM11_10 * 2;

            /*" -2255- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(WS_AUX_ARQUIVO.WPARM11_AUX, 11, WS_AUX_ARQUIVO.WS_RESULT, WS_AUX_ARQUIVO.WS_RESTO);

            /*" -2256- IF WS-RESTO EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.WS_RESTO == 00)
            {

                /*" -2257- MOVE 0 TO WS-DIGTIT */
                _.Move(0, WS_AUX_ARQUIVO.FILLER_5.WS_DIGTIT);

                /*" -2258- ELSE */
            }
            else
            {


                /*" -2259- SUBTRACT WS-RESTO FROM 11 GIVING WS-DIGTIT. */
                WS_AUX_ARQUIVO.FILLER_5.WS_DIGTIT.Value = 11 - WS_AUX_ARQUIVO.WS_RESTO;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-SICOB-FAIXA-SECTION */
        private void R0450_00_SELECT_SICOB_FAIXA_SECTION()
        {
            /*" -2272- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2279- PERFORM R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1 */

            R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1();

            /*" -2282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2283- MOVE ZEROS TO V0SFRC-NRTIT */
                _.Move(0, V0SFRC_NRTIT);

                /*" -2284- ELSE */
            }
            else
            {


                /*" -2285- IF VIND-NRTIT LESS ZEROS */

                if (VIND_NRTIT < 00)
                {

                    /*" -2285- MOVE ZEROS TO V0SFRC-NRTIT. */
                    _.Move(0, V0SFRC_NRTIT);
                }

            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-SICOB-FAIXA-DB-SELECT-1 */
        public void R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1()
        {
            /*" -2279- EXEC SQL SELECT NUM_SICOB_INI INTO :V0SFRC-NRTIT:VIND-NRTIT FROM SEGUROS.SICOB_FAIXA_RCAP WHERE NUM_SICOB_INI <= :V0SFRC-NRTIT AND NUM_SICOB_FIM >= :V0SFRC-NRTIT WITH UR END-EXEC. */

            var r0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 = new R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1()
            {
                V0SFRC_NRTIT = V0SFRC_NRTIT.ToString(),
            };

            var executed_1 = R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SFRC_NRTIT, V0SFRC_NRTIT);
                _.Move(executed_1.VIND_NRTIT, VIND_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-SICOB-FAIXA-SECTION */
        private void R0700_00_SELECT_SICOB_FAIXA_SECTION()
        {
            /*" -2298- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2305- PERFORM R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1 */

            R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1();

            /*" -2308- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2309- ADD 1 TO DP-GRAFICA */
                WS_AUX_ARQUIVO.DP_GRAFICA.Value = WS_AUX_ARQUIVO.DP_GRAFICA + 1;

                /*" -2310- MOVE ZEROS TO COBRAN-CODPRODU */
                _.Move(0, COBRAN_REGISTRO.COBRAN_CODPRODU);

                /*" -2311- ELSE */
            }
            else
            {


                /*" -2312- ADD 1 TO AC-GRAFICA */
                WS_AUX_ARQUIVO.AC_GRAFICA.Value = WS_AUX_ARQUIVO.AC_GRAFICA + 1;

                /*" -2315- IF V0SFRC-CODPRODU EQUAL 400 OR 401 OR 402 */

                if (V0SFRC_CODPRODU.In("400", "401", "402"))
                {

                    /*" -2316- MOVE 004 TO COBRAN-CODPRODU */
                    _.Move(004, COBRAN_REGISTRO.COBRAN_CODPRODU);

                    /*" -2317- ELSE */
                }
                else
                {


                    /*" -2317- MOVE V0SFRC-CODPRODU TO COBRAN-CODPRODU. */
                    _.Move(V0SFRC_CODPRODU, COBRAN_REGISTRO.COBRAN_CODPRODU);
                }

            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-SICOB-FAIXA-DB-SELECT-1 */
        public void R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1()
        {
            /*" -2305- EXEC SQL SELECT COD_PRODUTO INTO :V0SFRC-CODPRODU FROM SEGUROS.SICOB_FAIXA_RCAP WHERE NUM_SICOB_INI <= :V0SFRC-NRTIT AND NUM_SICOB_FIM >= :V0SFRC-NRTIT WITH UR END-EXEC. */

            var r0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 = new R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1()
            {
                V0SFRC_NRTIT = V0SFRC_NRTIT.ToString(),
            };

            var executed_1 = R0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SFRC_CODPRODU, V0SFRC_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0940-00-SELECT-V0CONTROLE-SECTION */
        private void R0940_00_SELECT_V0CONTROLE_SECTION()
        {
            /*" -2330- MOVE '0940' TO WNR-EXEC-SQL. */
            _.Move("0940", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2333- MOVE COBRAN-NOSS-NUMERO TO WS-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WS_AUX_ARQUIVO.WS_TITULO);

            /*" -2334- IF PRE-NRTIT NOT EQUAL 81 */

            if (WS_AUX_ARQUIVO.FILLER_11.PRE_NRTIT != 81)
            {

                /*" -2337- GO TO R0940-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0940_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2338- MOVE WS-TITULO TO AUX-TITULO */
            _.Move(WS_AUX_ARQUIVO.WS_TITULO, WS_AUX_ARQUIVO.AUX_TITULO);

            /*" -2339- MOVE 85 TO AUX-NRTIT */
            _.Move(85, WS_AUX_ARQUIVO.FILLER_12.AUX_NRTIT);

            /*" -2340- MOVE ZEROS TO AUX-DIGITO11 */
            _.Move(0, WS_AUX_ARQUIVO.FILLER_12.AUX_DIGITO11);

            /*" -2341- MOVE AUX-TITULO TO V0CTIT-NRTIT1 */
            _.Move(WS_AUX_ARQUIVO.AUX_TITULO, V0CTIT_NRTIT1);

            /*" -2342- MOVE 9 TO AUX-DIGITO11 */
            _.Move(9, WS_AUX_ARQUIVO.FILLER_12.AUX_DIGITO11);

            /*" -2345- MOVE AUX-TITULO TO V0CTIT-NRTIT2. */
            _.Move(WS_AUX_ARQUIVO.AUX_TITULO, V0CTIT_NRTIT2);

            /*" -2352- PERFORM R0940_00_SELECT_V0CONTROLE_DB_SELECT_1 */

            R0940_00_SELECT_V0CONTROLE_DB_SELECT_1();

            /*" -2356- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2356- MOVE V0CTIT-NRTIT TO COBRAN-NOSS-NUMERO. */
                _.Move(V0CTIT_NRTIT, COBRAN_REGISTRO.COBRAN_NOSS_NUMERO);
            }


        }

        [StopWatch]
        /*" R0940-00-SELECT-V0CONTROLE-DB-SELECT-1 */
        public void R0940_00_SELECT_V0CONTROLE_DB_SELECT_1()
        {
            /*" -2352- EXEC SQL SELECT NUM_TITULO INTO :V0CTIT-NRTIT FROM SEGUROS.CONTROLE_TITULO WHERE NUM_TITULO >= :V0CTIT-NRTIT1 AND NUM_TITULO <= :V0CTIT-NRTIT2 WITH UR END-EXEC. */

            var r0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1 = new R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1()
            {
                V0CTIT_NRTIT1 = V0CTIT_NRTIT1.ToString(),
                V0CTIT_NRTIT2 = V0CTIT_NRTIT2.ToString(),
            };

            var executed_1 = R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1.Execute(r0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CTIT_NRTIT, V0CTIT_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0940_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-BILHEFAI-SECTION */
        private void R1030_00_SELECT_BILHEFAI_SECTION()
        {
            /*" -2369- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2372- MOVE COBRAN-NOSS-NUMERO TO BILHEFAI-NUMBIL-INI. */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, BILHEFAI.DCLBILHETE_FAIXA.BILHEFAI_NUMBIL_INI);

            /*" -2379- PERFORM R1030_00_SELECT_BILHEFAI_DB_SELECT_1 */

            R1030_00_SELECT_BILHEFAI_DB_SELECT_1();

            /*" -2383- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2384- MOVE '1' TO COBRAN-SITUACAO */
                _.Move("1", COBRAN_REGISTRO.COBRAN_SITUACAO);

                /*" -2385- MOVE ZEROS TO COBRAN-CODPRODU */
                _.Move(0, COBRAN_REGISTRO.COBRAN_CODPRODU);

                /*" -2386- ELSE */
            }
            else
            {


                /*" -2387- IF BILHEFAI-COD-RAMO EQUAL 82 */

                if (BILHEFAI.DCLBILHETE_FAIXA.BILHEFAI_COD_RAMO == 82)
                {

                    /*" -2388- MOVE 8202 TO COBRAN-CODPRODU */
                    _.Move(8202, COBRAN_REGISTRO.COBRAN_CODPRODU);

                    /*" -2389- ELSE */
                }
                else
                {


                    /*" -2389- MOVE 1402 TO COBRAN-CODPRODU. */
                    _.Move(1402, COBRAN_REGISTRO.COBRAN_CODPRODU);
                }

            }


        }

        [StopWatch]
        /*" R1030-00-SELECT-BILHEFAI-DB-SELECT-1 */
        public void R1030_00_SELECT_BILHEFAI_DB_SELECT_1()
        {
            /*" -2379- EXEC SQL SELECT COD_RAMO INTO :BILHEFAI-COD-RAMO FROM SEGUROS.BILHETE_FAIXA WHERE NUMBIL_INI <= :BILHEFAI-NUMBIL-INI AND NUMBIL_FIM >= :BILHEFAI-NUMBIL-INI WITH UR END-EXEC. */

            var r1030_00_SELECT_BILHEFAI_DB_SELECT_1_Query1 = new R1030_00_SELECT_BILHEFAI_DB_SELECT_1_Query1()
            {
                BILHEFAI_NUMBIL_INI = BILHEFAI.DCLBILHETE_FAIXA.BILHEFAI_NUMBIL_INI.ToString(),
            };

            var executed_1 = R1030_00_SELECT_BILHEFAI_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_BILHEFAI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHEFAI_COD_RAMO, BILHEFAI.DCLBILHETE_FAIXA.BILHEFAI_COD_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-OUTPUT-SORT-SECTION */
        private void R1500_00_OUTPUT_SORT_SECTION()
        {
            /*" -2402- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2403- MOVE SPACES TO WFIM-SORT. */
            _.Move("", WS_AUX_ARQUIVO.WFIM_SORT);

            /*" -2406- PERFORM R1510-00-LE-ARQSORT. */

            R1510_00_LE_ARQSORT_SECTION();

            /*" -2407- IF WFIM-SORT NOT EQUAL SPACES */

            if (!WS_AUX_ARQUIVO.WFIM_SORT.IsEmpty())
            {

                /*" -2410- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2414- PERFORM R1550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!WS_AUX_ARQUIVO.WFIM_SORT.IsEmpty()))
            {

                R1550_00_PROCESSA_SORT_SECTION();
            }

            /*" -2414- PERFORM R7500-00-UPDATE-V0CEDENTE. */

            R7500_00_UPDATE_V0CEDENTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-LE-ARQSORT-SECTION */
        private void R1510_00_LE_ARQSORT_SECTION()
        {
            /*" -2427- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2429- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -2429- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WS_AUX_ARQUIVO.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-PROCESSA-SORT-SECTION */
        private void R1550_00_PROCESSA_SORT_SECTION()
        {
            /*" -2442- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2443- IF SOR-CODREGISTR EQUAL '0' */

            if (REG_ARQSORT.SOR_CODREGISTR == "0")
            {

                /*" -2444- MOVE REG-ARQSORT TO HEADER-REGISTRO */
                _.Move(REG_ARQSORT, HEADER_REGISTRO);

                /*" -2445- PERFORM R2350-00-CONSISTE-HEADER */

                R2350_00_CONSISTE_HEADER_SECTION();

                /*" -2446- GO TO R1550-90-LEITURA */

                R1550_90_LEITURA(); //GOTO
                return;

                /*" -2447- ELSE */
            }
            else
            {


                /*" -2448- IF SOR-CODREGISTR EQUAL '9' */

                if (REG_ARQSORT.SOR_CODREGISTR == "9")
                {

                    /*" -2449- MOVE REG-ARQSORT TO TRAILL-REGISTRO */
                    _.Move(REG_ARQSORT, TRAILL_REGISTRO);

                    /*" -2450- PERFORM R4500-00-TRATA-TRAILLER */

                    R4500_00_TRATA_TRAILLER_SECTION();

                    /*" -2451- GO TO R1550-90-LEITURA */

                    R1550_90_LEITURA(); //GOTO
                    return;

                    /*" -2452- ELSE */
                }
                else
                {


                    /*" -2455- MOVE REG-ARQSORT TO COBRAN-REGISTRO. */
                    _.Move(REG_ARQSORT, COBRAN_REGISTRO);
                }

            }


            /*" -2464- ADD 1 TO V0CNAB-QTDREG. */
            V0CNAB_QTDREG.Value = V0CNAB_QTDREG + 1;

            /*" -2465- IF COBRAN-DATAOCORREN NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_DATAOCORREN.IsNumeric())
            {

                /*" -2466- MOVE ZEROS TO WDATA-SECULO */
                _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                /*" -2467- ELSE */
            }
            else
            {


                /*" -2468- IF COBRAN-DATAOCORREN EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_DATAOCORREN == 00)
                {

                    /*" -2469- MOVE ZEROS TO WDATA-SECULO */
                    _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                    /*" -2470- ELSE */
                }
                else
                {


                    /*" -2471- MOVE COBRAN-DATAOCORREN TO WDATA-FITA */
                    _.Move(COBRAN_REGISTRO.COBRAN_DATAOCORREN, WS_AUX_DATAS.WDATA_FITA);

                    /*" -2472- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA);

                    /*" -2473- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES);

                    /*" -2474- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO);

                    /*" -2475- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

                    if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
                    {

                        /*" -2476- MOVE 19 TO WDAT-SEC-SEC */
                        _.Move(19, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);

                        /*" -2477- ELSE */
                    }
                    else
                    {


                        /*" -2479- MOVE 20 TO WDAT-SEC-SEC. */
                        _.Move(20, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);
                    }

                }

            }


            /*" -2481- MOVE WDATA-SECULO TO CONVEN-DATAOCORREN. */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_ARQUIVO.CONVEN_DATAOCORREN);

            /*" -2482- IF COBRAN-DTVENCTO NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_DTVENCTO.IsNumeric())
            {

                /*" -2483- MOVE ZEROS TO WDATA-SECULO */
                _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                /*" -2484- ELSE */
            }
            else
            {


                /*" -2485- IF COBRAN-DTVENCTO EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_DTVENCTO == 00)
                {

                    /*" -2486- MOVE ZEROS TO WDATA-SECULO */
                    _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                    /*" -2487- ELSE */
                }
                else
                {


                    /*" -2488- MOVE COBRAN-DTVENCTO TO WDATA-FITA */
                    _.Move(COBRAN_REGISTRO.COBRAN_DTVENCTO, WS_AUX_DATAS.WDATA_FITA);

                    /*" -2489- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA);

                    /*" -2490- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES);

                    /*" -2491- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO);

                    /*" -2492- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

                    if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
                    {

                        /*" -2493- MOVE 19 TO WDAT-SEC-SEC */
                        _.Move(19, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);

                        /*" -2494- ELSE */
                    }
                    else
                    {


                        /*" -2496- MOVE 20 TO WDAT-SEC-SEC. */
                        _.Move(20, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);
                    }

                }

            }


            /*" -2499- MOVE WDATA-SECULO TO CONVEN-DTVENCTO. */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_ARQUIVO.CONVEN_DTVENCTO);

            /*" -2500- IF COBRAN-DATA-CRED NOT NUMERIC */

            if (!COBRAN_REGISTRO.COBRAN_DATA_CRED.IsNumeric())
            {

                /*" -2501- MOVE ZEROS TO WDATA-SECULO */
                _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                /*" -2502- ELSE */
            }
            else
            {


                /*" -2503- IF COBRAN-DATA-CRED EQUAL ZEROS */

                if (COBRAN_REGISTRO.COBRAN_DATA_CRED == 00)
                {

                    /*" -2504- MOVE ZEROS TO WDATA-SECULO */
                    _.Move(0, WS_AUX_DATAS.WDATA_SECULO);

                    /*" -2505- ELSE */
                }
                else
                {


                    /*" -2506- MOVE COBRAN-DATA-CRED TO WDATA-FITA */
                    _.Move(COBRAN_REGISTRO.COBRAN_DATA_CRED, WS_AUX_DATAS.WDATA_FITA);

                    /*" -2507- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA);

                    /*" -2508- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES);

                    /*" -2509- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
                    _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO);

                    /*" -2510- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

                    if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
                    {

                        /*" -2511- MOVE 19 TO WDAT-SEC-SEC */
                        _.Move(19, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);

                        /*" -2512- ELSE */
                    }
                    else
                    {


                        /*" -2514- MOVE 20 TO WDAT-SEC-SEC. */
                        _.Move(20, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);
                    }

                }

            }


            /*" -2517- MOVE WDATA-SECULO TO CONVEN-DATA-CRED. */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_ARQUIVO.CONVEN_DATA_CRED);

            /*" -2519- MOVE '-' TO DT-AMD-T1 DT-AMD-T2 */
            _.Move("-", WS_AUX_ARQUIVO.FILLER_1.DT_AMD_T1);
            _.Move("-", WS_AUX_ARQUIVO.FILLER_1.DT_AMD_T2);


            /*" -2520- MOVE WDAT-SEC-SSAA TO DT-AMD-AA */
            _.Move(WS_AUX_DATAS.FILLER_21.WDAT_SEC_SSAA, WS_AUX_ARQUIVO.FILLER_1.DT_AMD_AA);

            /*" -2521- MOVE WDAT-SEC-MES TO DT-AMD-MM */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_ARQUIVO.FILLER_1.DT_AMD_MM);

            /*" -2524- MOVE WDAT-SEC-DIA TO DT-AMD-DD */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_ARQUIVO.FILLER_1.DT_AMD_DD);

            /*" -2525- MOVE ZEROS TO CONVEN-FONTE */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_FONTE);

            /*" -2526- MOVE 9999 TO CONVEN-ESCNEG */
            _.Move(9999, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

            /*" -2531- MOVE COBRAN-AGE-COBRAN TO V0RCAP-AGECOBR CONVEN-AGECOBR. */
            _.Move(COBRAN_REGISTRO.FILLER_45.COBRAN_AGE_COBRAN, V0RCAP_AGECOBR, WS_AUX_ARQUIVO.CONVEN_AGECOBR);

            /*" -2532- SET WS-AGE TO 1 */
            WS_AGE.Value = 1;

            /*" -2533- SEARCH WACEF-OCORREAGE */
            for (; WS_AGE < WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE.Items.Count; WS_AGE.Value++)
            {

                /*" -2535- WHEN V0RCAP-AGECOBR EQUAL WACEF-AGENCIA(WS-AGE) */

                if (V0RCAP_AGECOBR == WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_AGENCIA)
                {


                    /*" -2537- MOVE WACEF-ESCNEG(WS-AGE) TO CONVEN-ESCNEG */
                    _.Move(WS_AGENCIACEF.WACEF_AGENCIAS.WACEF_OCORREAGE[WS_AGE].WACEF_ESCNEG, WS_AUX_ARQUIVO.CONVEN_ESCNEG);

                    /*" -2538- MOVE WACEF-FONTE(WS-AGE) TO CONVEN-FONTE  END-SEARCH. */
                    break;
                }
            }


            /*" -2541- PERFORM R2600-00-PROCESSA-RCAP. */

            R2600_00_PROCESSA_RCAP_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1550_90_LEITURA */

            R1550_90_LEITURA();

        }

        [StopWatch]
        /*" R1550-90-LEITURA */
        private void R1550_90_LEITURA(bool isPerform = false)
        {
            /*" -2546- PERFORM R1510-00-LE-ARQSORT. */

            R1510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-CONSISTE-HEADER-SECTION */
        private void R2350_00_CONSISTE_HEADER_SECTION()
        {
            /*" -2559- MOVE '2350' TO WNR-EXEC-SQL. */
            _.Move("2350", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2562- MOVE HEADER-CODEMPRESA TO WWORK-CODEMPRE WWORK-CEDENTE. */
            _.Move(HEADER_REGISTRO.HEADER_CODEMPRESA, WS_AUX_AVISO.WWORK_CODEMPRE, WS_AUX_AVISO.WWORK_CEDENTE);

            /*" -2563- MOVE HEADER-CODBANCO TO WWORK-BCOAVISO */
            _.Move(HEADER_REGISTRO.HEADER_CODBANCO, WS_AUX_AVISO.WWORK_BCOAVISO);

            /*" -2565- MOVE HEADER-NUMFITA TO WWORK-NUMFITA. */
            _.Move(HEADER_REGISTRO.HEADER_NUMFITA, WS_AUX_AVISO.WWORK_NUMFITA);

            /*" -2567- PERFORM R2450-00-MONTA-CONTROLE. */

            R2450_00_MONTA_CONTROLE_SECTION();

            /*" -2569- PERFORM R2500-00-SELECT-V0AVISOCRED. */

            R2500_00_SELECT_V0AVISOCRED_SECTION();

            /*" -2570- IF WHOST-COUNT-AVS NOT EQUAL ZEROS */

            if (WHOST_COUNT_AVS != 00)
            {

                /*" -2572- DISPLAY 'AVISO DE CREDITO JA CADASTRADO         ' WWORK-AGEAVISO ' ' WWORK-NRAVISO */

                $"AVISO DE CREDITO JA CADASTRADO         {WS_AUX_AVISO.WWORK_AGEAVISO} {WS_AUX_AVISO.WWORK_NRAVISO}"
                .Display();

                /*" -2572- GO TO R9900-00-ENCERRA-COM-ERRO. */

                R9900_00_ENCERRA_COM_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-MONTA-CONTROLE-SECTION */
        private void R2450_00_MONTA_CONTROLE_SECTION()
        {
            /*" -2584- MOVE '2450' TO WNR-EXEC-SQL. */
            _.Move("2450", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2586- MOVE HEADER-DIA TO WDAT-TAB-DIA WDAT-SEC-DIA. */
            _.Move(HEADER_REGISTRO.FILLER_42.HEADER_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA, WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA);

            /*" -2588- MOVE HEADER-MES TO WDAT-TAB-MES WDAT-SEC-MES. */
            _.Move(HEADER_REGISTRO.FILLER_42.HEADER_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES, WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES);

            /*" -2590- MOVE HEADER-SEC TO WDAT-TAB-SEC WDAT-SEC-SEC. */
            _.Move(HEADER_REGISTRO.FILLER_42.HEADER_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);

            /*" -2593- MOVE HEADER-ANO TO WDAT-TAB-ANO WDAT-SEC-ANO. */
            _.Move(HEADER_REGISTRO.FILLER_42.HEADER_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO, WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO);

            /*" -2594- MOVE WDATA-SECULO TO WWORK-DATCEF */
            _.Move(WS_AUX_DATAS.WDATA_SECULO, WS_AUX_AVISO.WWORK_DATCEF);

            /*" -2600- MOVE WDATA-TABELA TO WWORK-DTAVISO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, WS_AUX_AVISO.WWORK_DTAVISO);

            /*" -2601- MOVE ZEROS TO V0CNAB-COD-EMP */
            _.Move(0, V0CNAB_COD_EMP);

            /*" -2602- MOVE ZEROS TO V0CNAB-ORGAO */
            _.Move(0, V0CNAB_ORGAO);

            /*" -2603- MOVE 'A' TO V0CNAB-TIPOCOB */
            _.Move("A", V0CNAB_TIPOCOB);

            /*" -2604- MOVE WWORK-NRCTACED TO V0CNAB-NRCTACED */
            _.Move(WS_AUX_AVISO.FILLER_25.WWORK_NRCTACED, V0CNAB_NRCTACED);

            /*" -2605- MOVE V0SIST-DTMOVABE TO V0CNAB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0CNAB_DTMOVTO);

            /*" -2606- MOVE WWORK-DTAVISO TO V0CNAB-DATCEF */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0CNAB_DATCEF);

            /*" -2607- MOVE WWORK-NUMFITA TO V0CNAB-NRSEQ */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0CNAB_NRSEQ);

            /*" -2613- MOVE ZEROS TO V0CNAB-QTDREG. */
            _.Move(0, V0CNAB_QTDREG);

            /*" -2614- MOVE 4 TO WWORK-TIP-AGE */
            _.Move(4, WS_AUX_AVISO.FILLER_28.WWORK_TIP_AGE);

            /*" -2615- MOVE WWORK-CED-CTA2 TO WWORK-COD-AGE */
            _.Move(WS_AUX_AVISO.FILLER_27.WWORK_CED_CTA2, WS_AUX_AVISO.FILLER_28.WWORK_COD_AGE);

            /*" -2616- MOVE WWORK-AGEAVISO TO WWORK-AVS-AGE */
            _.Move(WS_AUX_AVISO.WWORK_AGEAVISO, WS_AUX_AVISO.FILLER_29.WWORK_AVS_AGE);

            /*" -2618- MOVE WWORK-NUMFITA TO WWORK-AVS-NRO. */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, WS_AUX_AVISO.FILLER_29.WWORK_AVS_NRO);

            /*" -2619- MOVE HEADER-AGEAVISO TO WWORK-AGEAVISO */
            _.Move(HEADER_REGISTRO.HEADER_AGEAVISO, WS_AUX_AVISO.WWORK_AGEAVISO);

            /*" -2624- MOVE 'R' TO WWORK-TIPAVI. */
            _.Move("R", WS_AUX_AVISO.WWORK_TIPAVI);

            /*" -2627- IF WWORK-CODEMPRE EQUAL 630870000000113 OR WWORK-CODEMPRE EQUAL 630003000002224 OR WWORK-CODEMPRE EQUAL 630003000003336 */

            if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000113 || WS_AUX_AVISO.WWORK_CODEMPRE == 630003000002224 || WS_AUX_AVISO.WWORK_CODEMPRE == 630003000003336)
            {

                /*" -2628- MOVE 0011 TO WWORK-ORIGAVISO */
                _.Move(0011, WS_AUX_AVISO.WWORK_ORIGAVISO);

                /*" -2632- ELSE */
            }
            else
            {


                /*" -2634- IF WWORK-CODEMPRE EQUAL 630870000000601 OR 630870000000610 */

                if (WS_AUX_AVISO.WWORK_CODEMPRE.In("630870000000601", "630870000000610"))
                {

                    /*" -2635- MOVE 0014 TO WWORK-ORIGAVISO */
                    _.Move(0014, WS_AUX_AVISO.WWORK_ORIGAVISO);

                    /*" -2639- ELSE */
                }
                else
                {


                    /*" -2640- IF WWORK-CODEMPRE EQUAL 630870000000750 */

                    if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000750)
                    {

                        /*" -2641- MOVE 0002 TO WWORK-ORIGAVISO */
                        _.Move(0002, WS_AUX_AVISO.WWORK_ORIGAVISO);

                        /*" -2645- ELSE */
                    }
                    else
                    {


                        /*" -2649- IF WWORK-CODEMPRE EQUAL 630870000000318 OR WWORK-CODEMPRE EQUAL 630870000000342 OR WWORK-CODEMPRE EQUAL 630870000001004 OR WWORK-CODEMPRE EQUAL 630870000001136 */

                        if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000318 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000342 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000001004 || WS_AUX_AVISO.WWORK_CODEMPRE == 630870000001136)
                        {

                            /*" -2650- MOVE 0008 TO WWORK-ORIGAVISO */
                            _.Move(0008, WS_AUX_AVISO.WWORK_ORIGAVISO);

                            /*" -2654- ELSE */
                        }
                        else
                        {


                            /*" -2655- IF WWORK-CODEMPRE EQUAL 630870000000334 */

                            if (WS_AUX_AVISO.WWORK_CODEMPRE == 630870000000334)
                            {

                                /*" -2656- MOVE 0002 TO WWORK-ORIGAVISO */
                                _.Move(0002, WS_AUX_AVISO.WWORK_ORIGAVISO);

                                /*" -2657- ELSE */
                            }
                            else
                            {


                                /*" -2660- MOVE 0002 TO WWORK-ORIGAVISO. */
                                _.Move(0002, WS_AUX_AVISO.WWORK_ORIGAVISO);
                            }

                        }

                    }

                }

            }


            /*" -2661- MOVE WWORK-BCOAVISO TO V0AVIS-BCOAVISO */
            _.Move(WS_AUX_AVISO.WWORK_BCOAVISO, V0AVIS_BCOAVISO);

            /*" -2662- MOVE WWORK-AGEAVISO TO V0AVIS-AGEAVISO */
            _.Move(WS_AUX_AVISO.WWORK_AGEAVISO, V0AVIS_AGEAVISO);

            /*" -2663- MOVE WWORK-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WS_AUX_AVISO.WWORK_NRAVISO, V0AVIS_NRAVISO);

            /*" -2664- MOVE 1 TO V0AVIS-NRSEQ */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -2665- MOVE V0SIST-DTMOVABE TO V0AVIS-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -2666- MOVE 100 TO V0AVIS-OPERACAO */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -2667- MOVE WWORK-TIPAVI TO V0AVIS-TIPAVI */
            _.Move(WS_AUX_AVISO.WWORK_TIPAVI, V0AVIS_TIPAVI);

            /*" -2668- MOVE WWORK-DTAVISO TO V0AVIS-DTAVISO */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0AVIS_DTAVISO);

            /*" -2673- MOVE ZEROS TO V0AVIS-VLIOCC V0AVIS-VLDESPES V0AVIS-PRECED V0AVIS-VLPRMLIQ V0AVIS-VLPRMTOT */
            _.Move(0, V0AVIS_VLIOCC, V0AVIS_VLDESPES, V0AVIS_PRECED, V0AVIS_VLPRMLIQ, V0AVIS_VLPRMTOT);

            /*" -2674- MOVE '0' TO V0AVIS-SITCONTB */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -2675- MOVE ZEROS TO V0AVIS-CODEMP */
            _.Move(0, V0AVIS_CODEMP);

            /*" -2676- MOVE WWORK-ORIGAVISO TO V0AVIS-ORIGAVISO */
            _.Move(WS_AUX_AVISO.WWORK_ORIGAVISO, V0AVIS_ORIGAVISO);

            /*" -2678- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -2684- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -2685- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -2686- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -2687- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -2688- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -2689- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -2690- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -2691- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -2692- MOVE '0' TO V0SALD-SITUACAO */
            _.Move("0", V0SALD_SITUACAO);

            /*" -2694- MOVE ZEROS TO V0SALD-SDOATU AD-QTDEBIL AD-VLRABIL. */
            _.Move(0, V0SALD_SDOATU, WS_AUX_ARQUIVO.AD_QTDEBIL, WS_AUX_ARQUIVO.AD_VLRABIL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-V0AVISOCRED-SECTION */
        private void R2500_00_SELECT_V0AVISOCRED_SECTION()
        {
            /*" -2705- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2713- PERFORM R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1 */

            R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1();

            /*" -2716- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2717- MOVE ZEROS TO WHOST-COUNT-AVS */
                _.Move(0, WHOST_COUNT_AVS);

                /*" -2718- ELSE */
            }
            else
            {


                /*" -2719- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2720- DISPLAY 'R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)' */
                    _.Display($"R2500-00 - PROBLEMAS NO SELECT(V0AVISOCRED)");

                    /*" -2721- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2722- ELSE */
                }
                else
                {


                    /*" -2723- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -2723- MOVE ZEROS TO WHOST-COUNT-AVS. */
                        _.Move(0, WHOST_COUNT_AVS);
                    }

                }

            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-V0AVISOCRED-DB-SELECT-1 */
        public void R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1()
        {
            /*" -2713- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT-AVS:VIND-COUNT FROM SEGUROS.V0AVISOCRED WHERE AGEAVISO = :V0AVIS-AGEAVISO AND NRAVISO = :V0AVIS-NRAVISO AND NRSEQ = :V0AVIS-NRSEQ WITH UR END-EXEC. */

            var r2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1 = new R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1()
            {
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
            };

            var executed_1 = R2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_V0AVISOCRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT_AVS, WHOST_COUNT_AVS);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-PROCESSA-RCAP-SECTION */
        private void R2600_00_PROCESSA_RCAP_SECTION()
        {
            /*" -2734- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2738- MOVE 'N' TO FLG-GRAFICA. */
            _.Move("N", WS_AUX_ARQUIVO.FLG_GRAFICA);

            /*" -2739- MOVE ZEROS TO WSHOST-CODPRODU */
            _.Move(0, WSHOST_CODPRODU);

            /*" -2741- MOVE COBRAN-NOSS-NUMERO TO WSHOST-NRCERTIF */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WSHOST_NRCERTIF);

            /*" -2742- MOVE COBRAN-VLR-PRINC TO WSHOST-VLPRMTOT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, WSHOST_VLPRMTOT);

            /*" -2743- MOVE COBRAN-DESPESAS TO WSHOST-VLTARIFA */
            _.Move(COBRAN_REGISTRO.COBRAN_DESPESAS, WSHOST_VLTARIFA);

            /*" -2744- MOVE COBRAN-ABATIMENTO TO WSHOST-VLBALCAO */
            _.Move(COBRAN_REGISTRO.COBRAN_ABATIMENTO, WSHOST_VLBALCAO);

            /*" -2745- MOVE COBRAN-IOF TO WSHOST-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, WSHOST_VLIOCC);

            /*" -2746- MOVE COBRAN-DESC-CONCED TO WSHOST-VLDESCON */
            _.Move(COBRAN_REGISTRO.COBRAN_DESC_CONCED, WSHOST_VLDESCON);

            /*" -2750- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -2752- ADD COBRAN-VLR-PRINC TO V0AVIS-VLPRMTOT V0SALD-SDOATU */
            V0AVIS_VLPRMTOT.Value = V0AVIS_VLPRMTOT + COBRAN_REGISTRO.COBRAN_VLR_PRINC;
            V0SALD_SDOATU.Value = V0SALD_SDOATU + COBRAN_REGISTRO.COBRAN_VLR_PRINC;

            /*" -2753- ADD COBRAN-IOF TO V0AVIS-VLIOCC */
            V0AVIS_VLIOCC.Value = V0AVIS_VLIOCC + COBRAN_REGISTRO.COBRAN_IOF;

            /*" -2754- ADD COBRAN-DESPESAS TO V0AVIS-VLDESPES */
            V0AVIS_VLDESPES.Value = V0AVIS_VLDESPES + COBRAN_REGISTRO.COBRAN_DESPESAS;

            /*" -2758- ADD COBRAN-ABATIMENTO TO V0AVIS-VLDESPES. */
            V0AVIS_VLDESPES.Value = V0AVIS_VLDESPES + COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -2759- MOVE COBRAN-USO-EMPRESA TO AUX-USO-EMPRESA */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -2762- MOVE AUX-TITSIVPF TO AUX-NRO-SIVPF V0FILT-NUMSIVPF. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_NRO_SIVPF, V0FILT_NUMSIVPF);

            /*" -2763- MOVE COBRAN-USO-EMPRESA TO AUX-USO-EMPRESA */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA, WS_AUX_ARQUIVO.AUX_USO_EMPRESA);

            /*" -2766- MOVE AUX-TITSIVPF TO AUX-APOLICE AUX-TIT-GRAFICA AUX-NRO-SIVPF */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, WS_AUX_ARQUIVO.AUX_APOLICE, WS_AUX_ARQUIVO.AUX_TIT_GRAFICA, WS_AUX_ARQUIVO.AUX_NRO_SIVPF);

            /*" -2769- MOVE ZEROS TO WWORK-NSO-NUMERO. */
            _.Move(0, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

            /*" -2771- IF COBRAN-CODEMPRESA EQUAL 630003000002224 OR COBRAN-CODEMPRESA EQUAL 630003000003336 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630003000002224 || COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630003000003336)
            {

                /*" -2772- PERFORM R2650-00-TRATA-CEDENTE003 */

                R2650_00_TRATA_CEDENTE003_SECTION();

                /*" -2773- ELSE */
            }
            else
            {


                /*" -2773- PERFORM R2750-00-TRATA-CEDENTE870. */

                R2750_00_TRATA_CEDENTE870_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-TRATA-CEDENTE003-SECTION */
        private void R2650_00_TRATA_CEDENTE003_SECTION()
        {
            /*" -2785- MOVE '2650' TO WNR-EXEC-SQL. */
            _.Move("2650", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2786- IF COBRAN-SITUACAO NOT EQUAL SPACES */

            if (!COBRAN_REGISTRO.COBRAN_SITUACAO.IsEmpty())
            {

                /*" -2787- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -2789- MOVE 'TITULO INVALIDO PARA CEDENTE ' TO V0MCOB-NOME */
                _.Move("TITULO INVALIDO PARA CEDENTE ", V0MCOB_NOME);

                /*" -2791- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -2792- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -2795- GO TO R2650-90-DESPESAS. */

                R2650_90_DESPESAS(); //GOTO
                return;
            }


            /*" -2797- MOVE ZEROS TO V1RCAP-NRTIT. */
            _.Move(0, V1RCAP_NRTIT);

            /*" -2799- MOVE COBRAN-NOSS-NUMERO TO WWORK-NSO-NUMERO AUX-TITSIVPF. */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO, WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF);

            /*" -2802- MOVE COBRAN-CODPRODU TO CONVEN-CODPRODU WSHOST-CODPRODU. */
            _.Move(COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

            /*" -2803- IF COBRAN-CODPRODU EQUAL 8201 */

            if (COBRAN_REGISTRO.COBRAN_CODPRODU == 8201)
            {

                /*" -2806- MOVE 8202 TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(8202, COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -2807- ELSE */
            }
            else
            {


                /*" -2809- IF COBRAN-CODPRODU EQUAL 7106 OR 7108 */

                if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("7106", "7108"))
                {

                    /*" -2814- MOVE 1402 TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU. */
                    _.Move(1402, COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);
                }

            }


            /*" -2815- MOVE WWORK-NRRCAP TO V0RCAP-NRRCAP */
            _.Move(WS_AUX_ARQUIVO.FILLER_4.WWORK_NRRCAP, V0RCAP_NRRCAP);

            /*" -2817- MOVE COBRAN-VLR-PRINC TO V0RCAP-VLRCAP V0RCAP-VALPRI. */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0RCAP_VLRCAP, V0RCAP_VALPRI);

            /*" -2819- MOVE WWORK-NSO-NUMERO TO V0RCAP-NRTIT V0RCAP-NRCERTIF. */
            _.Move(WS_AUX_ARQUIVO.WWORK_NSO_NUMERO, V0RCAP_NRTIT, V0RCAP_NRCERTIF);

            /*" -2822- MOVE CONVEN-CODPRODU TO V0RCAP-CODPRODU. */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0RCAP_CODPRODU);

            /*" -2825- PERFORM R3700-00-INSERT-V0RCAP. */

            R3700_00_INSERT_V0RCAP_SECTION();

            /*" -2826- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -2827- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -2829- MOVE 'TITULO DUPLICADO RCAP     ' TO V0MCOB-NOME */
                _.Move("TITULO DUPLICADO RCAP     ", V0MCOB_NOME);

                /*" -2830- MOVE WWORK-NRRCAP TO V0FOLL-NRRCAP */
                _.Move(WS_AUX_ARQUIVO.FILLER_4.WWORK_NRRCAP, V0FOLL_NRRCAP);

                /*" -2831- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -2834- GO TO R2650-90-DESPESAS. */

                R2650_90_DESPESAS(); //GOTO
                return;
            }


            /*" -2837- PERFORM R3750-00-INSERT-V0RCAPCOMP. */

            R3750_00_INSERT_V0RCAPCOMP_SECTION();

            /*" -2840- PERFORM R6000-00-TRATA-BILHETES. */

            R6000_00_TRATA_BILHETES_SECTION();

            /*" -2840- PERFORM R6500-00-TARIFA-BALCAO. */

            R6500_00_TARIFA_BALCAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2650_90_DESPESAS */

            R2650_90_DESPESAS();

        }

        [StopWatch]
        /*" R2650-90-DESPESAS */
        private void R2650_90_DESPESAS(bool isPerform = false)
        {
            /*" -2846- PERFORM R8000-00-TRATA-DESPESAS. */

            R8000_00_TRATA_DESPESAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-TRATA-CEDENTE870-SECTION */
        private void R2750_00_TRATA_CEDENTE870_SECTION()
        {
            /*" -2859- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -2860- IF COBRAN-TITULO16 EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16 == 00)
            {

                /*" -2861- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -2863- MOVE 'COBRANCA SEM TITULO INFORMADO' TO V0MCOB-NOME */
                _.Move("COBRANCA SEM TITULO INFORMADO", V0MCOB_NOME);

                /*" -2865- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -2866- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -2869- GO TO R2750-90-DESPESAS. */

                R2750_90_DESPESAS(); //GOTO
                return;
            }


            /*" -2871- IF COBRAN-CANAL EQUAL ZEROS AND COBRAN-CODPRODU EQUAL ZEROS */

            if (COBRAN_REGISTRO.COBRAN_CANAL == 00 && COBRAN_REGISTRO.COBRAN_CODPRODU == 00)
            {

                /*" -2872- MOVE 'S' TO FLG-GRAFICA */
                _.Move("S", WS_AUX_ARQUIVO.FLG_GRAFICA);

                /*" -2873- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -2875- MOVE 'TITULO GRAFICA SEM IDENTIFICACAO' TO V0MCOB-NOME */
                _.Move("TITULO GRAFICA SEM IDENTIFICACAO", V0MCOB_NOME);

                /*" -2877- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -2878- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -2881- GO TO R2750-90-DESPESAS. */

                R2750_90_DESPESAS(); //GOTO
                return;
            }


            /*" -2886- IF COBRAN-CANAL NOT EQUAL ZEROS AND COBRAN-CANAL NOT EQUAL 1 AND COBRAN-CANAL NOT EQUAL 6 AND COBRAN-CANAL NOT EQUAL 8 AND COBRAN-CANAL NOT EQUAL 9 */

            if (COBRAN_REGISTRO.COBRAN_CANAL != 00 && COBRAN_REGISTRO.COBRAN_CANAL != 1 && COBRAN_REGISTRO.COBRAN_CANAL != 6 && COBRAN_REGISTRO.COBRAN_CANAL != 8 && COBRAN_REGISTRO.COBRAN_CANAL != 9)
            {

                /*" -2887- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -2889- MOVE 'CANAL DE VENDA NAO PREVISTO  ' TO V0MCOB-NOME */
                _.Move("CANAL DE VENDA NAO PREVISTO  ", V0MCOB_NOME);

                /*" -2891- MOVE ZEROS TO V0FOLL-NRRCAP */
                _.Move(0, V0FOLL_NRRCAP);

                /*" -2892- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -2899- GO TO R2750-90-DESPESAS. */

                R2750_90_DESPESAS(); //GOTO
                return;
            }


            /*" -2900- MOVE 1 TO V0FILT-CODEMP */
            _.Move(1, V0FILT_CODEMP);

            /*" -2901- MOVE AUX-PRDSIVPF TO V0FILT-CODSIVPF */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.AUX_PRDSIVPF, V0FILT_CODSIVPF);

            /*" -2902- MOVE CONVEN-AGECOBR TO V0FILT-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0FILT_AGECOBR);

            /*" -2903- MOVE V0SIST-DTMOVABE TO V0FILT-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0FILT_DTMOVTO);

            /*" -2904- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -2905- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -2906- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -2907- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -2908- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -2909- MOVE WDATA-TABELA TO V0FILT-DTQITBCO */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0FILT_DTQITBCO);

            /*" -2910- MOVE COBRAN-VLR-PRINC TO V0FILT-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0FILT_VLRCAP);

            /*" -2912- MOVE 'PF0003B' TO V0FILT-CODUSU. */
            _.Move("PF0003B", V0FILT_CODUSU);

            /*" -2914- MOVE ZEROS TO V1RCAP-NRTIT. */
            _.Move(0, V1RCAP_NRTIT);

            /*" -2918- IF COBRAN-CANAL EQUAL 1 OR 6 OR 8 OR 9 */

            if (COBRAN_REGISTRO.COBRAN_CANAL.In("1", "6", "8", "9"))
            {

                /*" -2919- PERFORM R2800-00-LER-CONVERSAO */

                R2800_00_LER_CONVERSAO_SECTION();

                /*" -2920- IF V0FILT-COUNT NOT EQUAL ZEROS */

                if (V0FILT_COUNT != 00)
                {

                    /*" -2922- MOVE CONVSICOB-NR-SICOB TO V0RCAP-NRTIT WWORK-NSO-NUMERO */
                    _.Move(CONVSICOB_NR_SICOB, V0RCAP_NRTIT, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                    /*" -2923- PERFORM R3710-00-SELECT-V1RCAP */

                    R3710_00_SELECT_V1RCAP_SECTION();

                    /*" -2924- IF V1RCAP-NRTIT EQUAL 9999999 */

                    if (V1RCAP_NRTIT == 9999999)
                    {

                        /*" -2925- MOVE '1' TO V0FOLL-CDERRO02 */
                        _.Move("1", V0FOLL_CDERRO02);

                        /*" -2927- MOVE 'TITULO DUPLICADO CONVERSAO' TO V0MCOB-NOME */
                        _.Move("TITULO DUPLICADO CONVERSAO", V0MCOB_NOME);

                        /*" -2928- MOVE ZEROS TO V0FOLL-NRRCAP */
                        _.Move(0, V0FOLL_NRRCAP);

                        /*" -2929- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                        R3900_00_MONTA_V0FOLLOWUP_SECTION();

                        /*" -2930- GO TO R2750-90-DESPESAS */

                        R2750_90_DESPESAS(); //GOTO
                        return;

                        /*" -2932- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2933- ELSE */
                    }

                }
                else
                {


                    /*" -2934- PERFORM R3000-00-TRATA-SIVPF */

                    R3000_00_TRATA_SIVPF_SECTION();

                    /*" -2935- ELSE */
                }

            }
            else
            {


                /*" -2936- MOVE 'S' TO FLG-GRAFICA */
                _.Move("S", WS_AUX_ARQUIVO.FLG_GRAFICA);

                /*" -2937- MOVE AUX-NUM-GRAFICA TO WWORK-NSO-NUMERO */
                _.Move(WS_AUX_ARQUIVO.FILLER_6.AUX_NUM_GRAFICA, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

                /*" -2939- MOVE COBRAN-CODPRODU TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -2940- IF COBRAN-CODPRODU EQUAL 8201 */

                if (COBRAN_REGISTRO.COBRAN_CODPRODU == 8201)
                {

                    /*" -2943- MOVE 8202 TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU */
                    _.Move(8202, COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                    /*" -2944- ELSE */
                }
                else
                {


                    /*" -2946- IF COBRAN-CODPRODU EQUAL 7106 OR 7108 */

                    if (COBRAN_REGISTRO.COBRAN_CODPRODU.In("7106", "7108"))
                    {

                        /*" -2951- MOVE 1402 TO COBRAN-CODPRODU CONVEN-CODPRODU WSHOST-CODPRODU. */
                        _.Move(1402, COBRAN_REGISTRO.COBRAN_CODPRODU, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);
                    }

                }

            }


            /*" -2952- MOVE WWORK-NRRCAP TO V0RCAP-NRRCAP */
            _.Move(WS_AUX_ARQUIVO.FILLER_4.WWORK_NRRCAP, V0RCAP_NRRCAP);

            /*" -2954- MOVE COBRAN-VLR-PRINC TO V0RCAP-VLRCAP V0RCAP-VALPRI */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0RCAP_VLRCAP, V0RCAP_VALPRI);

            /*" -2955- MOVE WWORK-NSO-NUMERO TO V0RCAP-NRTIT */
            _.Move(WS_AUX_ARQUIVO.WWORK_NSO_NUMERO, V0RCAP_NRTIT);

            /*" -2957- MOVE CONVEN-CODPRODU TO V0RCAP-CODPRODU */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0RCAP_CODPRODU);

            /*" -2959- MOVE AUX-TITSIVPF TO V0RCAP-NRCERTIF. */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0RCAP_NRCERTIF);

            /*" -2961- PERFORM R3700-00-INSERT-V0RCAP. */

            R3700_00_INSERT_V0RCAP_SECTION();

            /*" -2962- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -2963- MOVE '1' TO V0FOLL-CDERRO02 */
                _.Move("1", V0FOLL_CDERRO02);

                /*" -2965- MOVE 'TITULO DUPLICADO RCAP     ' TO V0MCOB-NOME */
                _.Move("TITULO DUPLICADO RCAP     ", V0MCOB_NOME);

                /*" -2967- MOVE WWORK-NRRCAP TO V0FOLL-NRRCAP */
                _.Move(WS_AUX_ARQUIVO.FILLER_4.WWORK_NRRCAP, V0FOLL_NRRCAP);

                /*" -2968- PERFORM R3900-00-MONTA-V0FOLLOWUP */

                R3900_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -2971- GO TO R2750-90-DESPESAS. */

                R2750_90_DESPESAS(); //GOTO
                return;
            }


            /*" -2974- PERFORM R3750-00-INSERT-V0RCAPCOMP. */

            R3750_00_INSERT_V0RCAPCOMP_SECTION();

            /*" -2978- IF COBRAN-CANAL EQUAL 1 OR 6 OR 8 OR 9 */

            if (COBRAN_REGISTRO.COBRAN_CANAL.In("1", "6", "8", "9"))
            {

                /*" -2979- IF V0FILT-COUNT EQUAL ZEROS */

                if (V0FILT_COUNT == 00)
                {

                    /*" -2980- PERFORM R3800-00-INSERT-CONVERSAO */

                    R3800_00_INSERT_CONVERSAO_SECTION();

                    /*" -2981- ELSE */
                }
                else
                {


                    /*" -2984- PERFORM R3950-00-UPDATE-CONVERSAO. */

                    R3950_00_UPDATE_CONVERSAO_SECTION();
                }

            }


            /*" -2985- IF COBRAN-CODEMPRESA EQUAL 630870000000113 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000113)
            {

                /*" -2991- PERFORM R6000-00-TRATA-BILHETES. */

                R6000_00_TRATA_BILHETES_SECTION();
            }


            /*" -2992- IF COBRAN-CODEMPRESA EQUAL 630870000000601 */

            if (COBRAN_REGISTRO.COBRAN_CODEMPRESA == 630870000000601)
            {

                /*" -2995- PERFORM R8800-00-TRATA-AZULCAR. */

                R8800_00_TRATA_AZULCAR_SECTION();
            }


            /*" -2995- PERFORM R6500-00-TARIFA-BALCAO. */

            R6500_00_TARIFA_BALCAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2750_90_DESPESAS */

            R2750_90_DESPESAS();

        }

        [StopWatch]
        /*" R2750-90-DESPESAS */
        private void R2750_90_DESPESAS(bool isPerform = false)
        {
            /*" -3001- PERFORM R8000-00-TRATA-DESPESAS. */

            R8000_00_TRATA_DESPESAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-LER-CONVERSAO-SECTION */
        private void R2800_00_LER_CONVERSAO_SECTION()
        {
            /*" -3014- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3015- MOVE ZEROS TO CONVEN-CODPRODU. */
            _.Move(0, WS_AUX_ARQUIVO.CONVEN_CODPRODU);

            /*" -3018- MOVE AUX-PRDSIVPF TO V0PRPF-CODSIVPF. */
            _.Move(WS_AUX_ARQUIVO.FILLER_8.AUX_PRDSIVPF, V0PRPF_CODSIVPF);

            /*" -3019- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -3020- SEARCH WPROD-OCORREPRD */
            for (; WS_PRD < WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -3022- WHEN V0PRPF-CODSIVPF EQUAL WPROD-PRDSIVPF(WS-PRD) */

                if (V0PRPF_CODSIVPF == WS_AGENCIACEF.WS_PRODUTOSIVPF.WPROD_PRODUTOS.WPROD_OCORREPRD[WS_PRD].WPROD_PRDSIVPF)
                {


                    /*" -3024- MOVE WPROD-CODPRODU(WS-PRD) TO CONVEN-CODPRODU WSHOST-CODPRODU  END-SEARCH. */
                    break;
                }
            }


            /*" -3028- IF CONVEN-CODPRODU EQUAL 8201 */

            if (WS_AUX_ARQUIVO.CONVEN_CODPRODU == 8201)
            {

                /*" -3030- MOVE 8202 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                _.Move(8202, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                /*" -3031- ELSE */
            }
            else
            {


                /*" -3033- IF CONVEN-CODPRODU EQUAL 7106 OR 7108 */

                if (WS_AUX_ARQUIVO.CONVEN_CODPRODU.In("7106", "7108"))
                {

                    /*" -3041- MOVE 1402 TO CONVEN-CODPRODU WSHOST-CODPRODU. */
                    _.Move(1402, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);
                }

            }


            /*" -3043- IF V0PRPF-CODSIVPF EQUAL 11 OR V0PRPF-CODSIVPF EQUAL 16 */

            if (V0PRPF_CODSIVPF == 11 || V0PRPF_CODSIVPF == 16)
            {

                /*" -3044- ADD 1 TO TT-OPCAO */
                WS_AUX_ARQUIVO.TT_OPCAO.Value = WS_AUX_ARQUIVO.TT_OPCAO + 1;

                /*" -3046- MOVE AUX-TITSIVPF TO OPCPAGVI-NUM-CERTIFICADO */
                _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

                /*" -3053- PERFORM R2850-00-SELECT-OPCPAGVI. */

                R2850_00_SELECT_OPCPAGVI_SECTION();
            }


            /*" -3054- MOVE AUX-TITSIVPF TO V0FILT-NUMSIVPF */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0FILT_NUMSIVPF);

            /*" -3054- PERFORM R2900-00-SELECT-CONVERSAO. */

            R2900_00_SELECT_CONVERSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2850-00-SELECT-OPCPAGVI-SECTION */
        private void R2850_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -3066- MOVE '2850' TO WNR-EXEC-SQL. */
            _.Move("2850", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3073- PERFORM R2850_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R2850_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -3077- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3078- ADD 1 TO DP-OPCAO */
                WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                /*" -3079- ELSE */
            }
            else
            {


                /*" -3080- IF V0PRPF-CODSIVPF EQUAL 11 */

                if (V0PRPF_CODSIVPF == 11)
                {

                    /*" -3081- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 01 */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 01)
                    {

                        /*" -3084- MOVE 9318 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                        _.Move(9318, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                        /*" -3085- ELSE */
                    }
                    else
                    {


                        /*" -3086- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 12 */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12)
                        {

                            /*" -3089- MOVE 9319 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(9319, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3090- ELSE */
                        }
                        else
                        {


                            /*" -3091- ADD 1 TO DP-OPCAO */
                            WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;

                            /*" -3092- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -3093- IF V0PRPF-CODSIVPF EQUAL 16 */

                    if (V0PRPF_CODSIVPF == 16)
                    {

                        /*" -3094- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 01 */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 01)
                        {

                            /*" -3097- MOVE 9322 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                            _.Move(9322, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                            /*" -3098- ELSE */
                        }
                        else
                        {


                            /*" -3099- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 02 */

                            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 02)
                            {

                                /*" -3102- MOVE 9323 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                _.Move(9323, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                /*" -3103- ELSE */
                            }
                            else
                            {


                                /*" -3104- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 03 */

                                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 03)
                                {

                                    /*" -3107- MOVE 9324 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                    _.Move(9324, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                    /*" -3108- ELSE */
                                }
                                else
                                {


                                    /*" -3109- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 06 */

                                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 06)
                                    {

                                        /*" -3112- MOVE 9325 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                        _.Move(9325, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                        /*" -3113- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3114- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 12 */

                                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12)
                                        {

                                            /*" -3117- MOVE 9326 TO CONVEN-CODPRODU WSHOST-CODPRODU */
                                            _.Move(9326, WS_AUX_ARQUIVO.CONVEN_CODPRODU, WSHOST_CODPRODU);

                                            /*" -3118- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3118- ADD 1 TO DP-OPCAO. */
                                            WS_AUX_ARQUIVO.DP_OPCAO.Value = WS_AUX_ARQUIVO.DP_OPCAO + 1;
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R2850-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R2850_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -3073- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r2850_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-SELECT-CONVERSAO-SECTION */
        private void R2900_00_SELECT_CONVERSAO_SECTION()
        {
            /*" -3130- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3144- PERFORM R2900_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R2900_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -3147- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -3148- MOVE 1 TO V0FILT-COUNT */
                _.Move(1, V0FILT_COUNT);

                /*" -3149- ELSE */
            }
            else
            {


                /*" -3150- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3151- MOVE ZEROS TO V0FILT-COUNT */
                    _.Move(0, V0FILT_COUNT);

                    /*" -3152- ELSE */
                }
                else
                {


                    /*" -3154- DISPLAY 'R2900-00 - PROBLEMAS NO SELECT(CONVERSAO)  ' SQLCODE '  ' V0FILT-NUMSIVPF */

                    $"R2900-00 - PROBLEMAS NO SELECT(CONVERSAO)  {DB.SQLCODE}  {V0FILT_NUMSIVPF}"
                    .Display();

                    /*" -3154- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2900-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R2900_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -3144- EXEC SQL SELECT NUM_SICOB, AGEPGTO, DATA_QUITACAO, VAL_RCAP, COD_USUARIO INTO :CONVSICOB-NR-SICOB, :CONVSICOB-AGEPGTO, :CONVSICOB-DTQITBCO, :CONVSICOB-VAL-RCAP, :CONVSICOB-COD-USUARIO FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF WITH UR END-EXEC. */

            var r2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            var executed_1 = R2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r2900_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVSICOB_NR_SICOB, CONVSICOB_NR_SICOB);
                _.Move(executed_1.CONVSICOB_AGEPGTO, CONVSICOB_AGEPGTO);
                _.Move(executed_1.CONVSICOB_DTQITBCO, CONVSICOB_DTQITBCO);
                _.Move(executed_1.CONVSICOB_VAL_RCAP, CONVSICOB_VAL_RCAP);
                _.Move(executed_1.CONVSICOB_COD_USUARIO, CONVSICOB_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TRATA-SIVPF-SECTION */
        private void R3000_00_TRATA_SIVPF_SECTION()
        {
            /*" -3165- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3167- PERFORM R3100-00-CALCULA-TITULO. */

            R3100_00_CALCULA_TITULO_SECTION();

            /*" -3168- MOVE WWORK-MIN-NRTIT TO V0FILT-NUMSICOB WWORK-NSO-NUMERO. */
            _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0FILT_NUMSICOB, WS_AUX_ARQUIVO.WWORK_NSO_NUMERO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-CALCULA-TITULO-SECTION */
        private void R3100_00_CALCULA_TITULO_SECTION()
        {
            /*" -3180- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3181- ADD 1 TO WWORK-MINNRO */
            WS_AUX_ARQUIVO.FILLER_2.WWORK_MINNRO.Value = WS_AUX_ARQUIVO.FILLER_2.WWORK_MINNRO + 1;

            /*" -3184- MOVE WWORK-MINNRO TO LPARM11. */
            _.Move(WS_AUX_ARQUIVO.FILLER_2.WWORK_MINNRO, LPARM11X.LPARM11);

            /*" -3195- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            WS_AUX_ARQUIVO.WPARM11_AUX.Value = LPARM11X.FILLER_52.LPARM11_1 * 3 + LPARM11X.FILLER_52.LPARM11_2 * 2 + LPARM11X.FILLER_52.LPARM11_3 * 9 + LPARM11X.FILLER_52.LPARM11_4 * 8 + LPARM11X.FILLER_52.LPARM11_5 * 7 + LPARM11X.FILLER_52.LPARM11_6 * 6 + LPARM11X.FILLER_52.LPARM11_7 * 5 + LPARM11X.FILLER_52.LPARM11_8 * 4 + LPARM11X.FILLER_52.LPARM11_9 * 3 + LPARM11X.FILLER_52.LPARM11_10 * 2;

            /*" -3198- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(WS_AUX_ARQUIVO.WPARM11_AUX, 11, WS_AUX_ARQUIVO.WS_RESULT, WS_AUX_ARQUIVO.WS_RESTO);

            /*" -3199- IF WS-RESTO EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.WS_RESTO == 00)
            {

                /*" -3200- MOVE 0 TO WWORK-MINDIG */
                _.Move(0, WS_AUX_ARQUIVO.FILLER_2.WWORK_MINDIG);

                /*" -3201- ELSE */
            }
            else
            {


                /*" -3205- SUBTRACT WS-RESTO FROM 11 GIVING WWORK-MINDIG. */
                WS_AUX_ARQUIVO.FILLER_2.WWORK_MINDIG.Value = 11 - WS_AUX_ARQUIVO.WS_RESTO;
            }


            /*" -3206- IF WWORK-MIN-NRTIT GREATER WWORK-MAX-NRTIT */

            if (WS_AUX_ARQUIVO.WWORK_MIN_NRTIT > WS_AUX_ARQUIVO.WWORK_MAX_NRTIT)
            {

                /*" -3207- DISPLAY '*- PF0003B - ABEND CONTROLADO -------------*' */
                _.Display($"*- PF0003B - ABEND CONTROLADO -------------*");

                /*" -3208- DISPLAY '*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    *' */
                _.Display($"*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    *");

                /*" -3209- DISPLAY '    ' WWORK-MIN-NRTIT */
                _.Display($"    {WS_AUX_ARQUIVO.WWORK_MIN_NRTIT}");

                /*" -3209- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERT-V0RCAP-SECTION */
        private void R3700_00_INSERT_V0RCAP_SECTION()
        {
            /*" -3222- MOVE '3700' TO WNR-EXEC-SQL. */
            _.Move("3700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3223- MOVE CONVEN-FONTE TO V0RCAP-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0RCAP_FONTE);

            /*" -3224- MOVE ZEROS TO V0RCAP-NRPROPOS */
            _.Move(0, V0RCAP_NRPROPOS);

            /*" -3225- MOVE SPACES TO V0RCAP-NOME */
            _.Move("", V0RCAP_NOME);

            /*" -3226- MOVE WWORK-DTAVISO TO V0RCAP-DTCADAST */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0RCAP_DTCADAST);

            /*" -3227- MOVE V0SIST-DTMOVABE TO V0RCAP-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0RCAP_DTMOVTO);

            /*" -3228- MOVE '0' TO V0RCAP-SITUACAO */
            _.Move("0", V0RCAP_SITUACAO);

            /*" -3229- MOVE 110 TO V0RCAP-OPERACAO */
            _.Move(110, V0RCAP_OPERACAO);

            /*" -3233- MOVE ZEROS TO V0RCAP-CODEMP V0RCAP-NUMAPOL V0RCAP-NRENDOS V0RCAP-NRPARCEL */
            _.Move(0, V0RCAP_CODEMP, V0RCAP_NUMAPOL, V0RCAP_NRENDOS, V0RCAP_NRPARCEL);

            /*" -3234- MOVE COBRAN-AGE-COBRAN TO V0RCAP-AGECOBR */
            _.Move(COBRAN_REGISTRO.FILLER_45.COBRAN_AGE_COBRAN, V0RCAP_AGECOBR);

            /*" -3235- MOVE SPACES TO V0RCAP-RECUPERA */
            _.Move("", V0RCAP_RECUPERA);

            /*" -3237- MOVE ZEROS TO V0RCAP-ACRESCIMO. */
            _.Move(0, V0RCAP_ACRESCIMO);

            /*" -3243- MOVE ZEROS TO VIND-CODEMP VIND-NRTIT VIND-CODPRODU VIND-AGECOBR VIND-NRCERTIF. */
            _.Move(0, VIND_CODEMP, VIND_NRTIT, VIND_CODPRODU, VIND_AGECOBR, VIND_NRCERTIF);

            /*" -3252- MOVE -1 TO VIND-NUMAPOL VIND-NRENDOS VIND-NRPARCEL VIND-RECUPERA VIND-ACRESCIMO. */
            _.Move(-1, VIND_NUMAPOL, VIND_NRENDOS, VIND_NRPARCEL, VIND_RECUPERA, VIND_ACRESCIMO);

            /*" -3253- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -3255- GO TO R3700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3257- PERFORM R3710-00-SELECT-V1RCAP. */

            R3710_00_SELECT_V1RCAP_SECTION();

            /*" -3258- IF V1RCAP-NRTIT EQUAL 9999999 */

            if (V1RCAP_NRTIT == 9999999)
            {

                /*" -3260- GO TO R3700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3283- PERFORM R3700_00_INSERT_V0RCAP_DB_INSERT_1 */

            R3700_00_INSERT_V0RCAP_DB_INSERT_1();

            /*" -3286- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3287- MOVE 9999999 TO V1RCAP-NRTIT */
                _.Move(9999999, V1RCAP_NRTIT);

                /*" -3288- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -3289- ELSE */
            }
            else
            {


                /*" -3290- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3291- DISPLAY 'R3700-00 - PROBLEMAS INSERT (V0RCAP)     ' */
                    _.Display($"R3700-00 - PROBLEMAS INSERT (V0RCAP)     ");

                    /*" -3294- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3294- ADD 1 TO IN-V0RCAP. */
            WS_AUX_ARQUIVO.IN_V0RCAP.Value = WS_AUX_ARQUIVO.IN_V0RCAP + 1;

        }

        [StopWatch]
        /*" R3700-00-INSERT-V0RCAP-DB-INSERT-1 */
        public void R3700_00_INSERT_V0RCAP_DB_INSERT_1()
        {
            /*" -3283- EXEC SQL INSERT INTO SEGUROS.V0RCAP VALUES (:V0RCAP-FONTE , :V0RCAP-NRRCAP , :V0RCAP-NRPROPOS , :V0RCAP-NOME , :V0RCAP-VLRCAP , :V0RCAP-VALPRI , :V0RCAP-DTCADAST , :V0RCAP-DTMOVTO , :V0RCAP-SITUACAO , :V0RCAP-OPERACAO , :V0RCAP-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0RCAP-NUMAPOL:VIND-NUMAPOL , :V0RCAP-NRENDOS:VIND-NRENDOS , :V0RCAP-NRPARCEL:VIND-NRPARCEL , :V0RCAP-NRTIT:VIND-NRTIT , :V0RCAP-CODPRODU:VIND-CODPRODU , :V0RCAP-AGECOBR:VIND-AGECOBR , :V0RCAP-RECUPERA:VIND-RECUPERA , :V0RCAP-ACRESCIMO:VIND-ACRESCIMO, :V0RCAP-NRCERTIF:VIND-NRCERTIF) END-EXEC. */

            var r3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1 = new R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1()
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

            R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1.Execute(r3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R3710-00-SELECT-V1RCAP-SECTION */
        private void R3710_00_SELECT_V1RCAP_SECTION()
        {
            /*" -3306- MOVE '3710' TO WNR-EXEC-SQL. */
            _.Move("3710", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3312- PERFORM R3710_00_SELECT_V1RCAP_DB_SELECT_1 */

            R3710_00_SELECT_V1RCAP_DB_SELECT_1();

            /*" -3316- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3317- DISPLAY 'R3710-00 - PROBLEMAS NO SELECT(V1RCAP)   ' */
                _.Display($"R3710-00 - PROBLEMAS NO SELECT(V1RCAP)   ");

                /*" -3318- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3319- ELSE */
            }
            else
            {


                /*" -3320- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3321- MOVE 9999999 TO V1RCAP-NRTIT */
                    _.Move(9999999, V1RCAP_NRTIT);

                    /*" -3322- ELSE */
                }
                else
                {


                    /*" -3322- MOVE ZEROS TO V1RCAP-NRTIT. */
                    _.Move(0, V1RCAP_NRTIT);
                }

            }


        }

        [StopWatch]
        /*" R3710-00-SELECT-V1RCAP-DB-SELECT-1 */
        public void R3710_00_SELECT_V1RCAP_DB_SELECT_1()
        {
            /*" -3312- EXEC SQL SELECT NRTIT INTO :V1RCAP-NRTIT FROM SEGUROS.V1RCAP WHERE NRTIT = :V0RCAP-NRTIT WITH UR END-EXEC. */

            var r3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1 = new R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1.Execute(r3710_00_SELECT_V1RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAP_NRTIT, V1RCAP_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3710_99_SAIDA*/

        [StopWatch]
        /*" R3750-00-INSERT-V0RCAPCOMP-SECTION */
        private void R3750_00_INSERT_V0RCAPCOMP_SECTION()
        {
            /*" -3335- MOVE '3750' TO WNR-EXEC-SQL. */
            _.Move("3750", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3336- MOVE V0RCAP-FONTE TO V0RCOM-FONTE */
            _.Move(V0RCAP_FONTE, V0RCOM_FONTE);

            /*" -3337- MOVE V0RCAP-NRRCAP TO V0RCOM-NRRCAP */
            _.Move(V0RCAP_NRRCAP, V0RCOM_NRRCAP);

            /*" -3338- MOVE 0 TO V0RCOM-NRRCAPCO */
            _.Move(0, V0RCOM_NRRCAPCO);

            /*" -3339- MOVE V0RCAP-OPERACAO TO V0RCOM-OPERACAO */
            _.Move(V0RCAP_OPERACAO, V0RCOM_OPERACAO);

            /*" -3340- MOVE V0RCAP-DTMOVTO TO V0RCOM-DTMOVTO */
            _.Move(V0RCAP_DTMOVTO, V0RCOM_DTMOVTO);

            /*" -3342- MOVE V0RCAP-SITUACAO TO V0RCOM-SITUACAO */
            _.Move(V0RCAP_SITUACAO, V0RCOM_SITUACAO);

            /*" -3343- MOVE V0AVIS-BCOAVISO TO V0RCOM-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0RCOM_BCOAVISO);

            /*" -3344- MOVE V0AVIS-AGEAVISO TO V0RCOM-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0RCOM_AGEAVISO);

            /*" -3346- MOVE V0AVIS-NRAVISO TO V0RCOM-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0RCOM_NRAVISO);

            /*" -3347- MOVE V0RCAP-VLRCAP TO V0RCOM-VLRCAP */
            _.Move(V0RCAP_VLRCAP, V0RCOM_VLRCAP);

            /*" -3348- MOVE V0RCAP-DTCADAST TO V0RCOM-DTCADAST */
            _.Move(V0RCAP_DTCADAST, V0RCOM_DTCADAST);

            /*" -3349- MOVE '0' TO V0RCOM-SITCONTB */
            _.Move("0", V0RCOM_SITCONTB);

            /*" -3351- MOVE V0RCAP-CODEMP TO V0RCOM-CODEMP. */
            _.Move(V0RCAP_CODEMP, V0RCOM_CODEMP);

            /*" -3352- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -3353- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA);

            /*" -3354- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_2PT1);

            /*" -3355- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU);

            /*" -3356- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_2PT2);

            /*" -3357- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU);

            /*" -3359- MOVE WTIME-DAYR TO V0RCOM-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_24.WTIME_DAYR, V0RCOM_HORAOPER);

            /*" -3360- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3361- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3362- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3363- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3364- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3367- MOVE WDATA-TABELA TO V0RCOM-DATARCAP. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0RCOM_DATARCAP);

            /*" -3385- PERFORM R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -3388- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3389- DISPLAY 'R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ' */
                _.Display($"R3750-00 - PROBLEMAS INSERT (V0RCAPCOMP) ");

                /*" -3389- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3750-00-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -3385- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V0RCOM-FONTE , :V0RCOM-NRRCAP , :V0RCOM-NRRCAPCO , :V0RCOM-OPERACAO , :V0RCOM-DTMOVTO , :V0RCOM-HORAOPER , :V0RCOM-SITUACAO , :V0RCOM-BCOAVISO , :V0RCOM-AGEAVISO , :V0RCOM-NRAVISO , :V0RCOM-VLRCAP , :V0RCOM-DATARCAP , :V0RCOM-DTCADAST , :V0RCOM-SITCONTB , :V0RCOM-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
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

            R3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3750_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-INSERT-CONVERSAO-SECTION */
        private void R3800_00_INSERT_CONVERSAO_SECTION()
        {
            /*" -3400- MOVE '3800' TO WNR-EXEC-SQL. */
            _.Move("3800", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3412- PERFORM R3800_00_INSERT_CONVERSAO_DB_INSERT_1 */

            R3800_00_INSERT_CONVERSAO_DB_INSERT_1();

            /*" -3415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3416- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3417- PERFORM R3850-00-TRATA-DUPLICI-SICOB */

                    R3850_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -3418- ELSE */
                }
                else
                {


                    /*" -3419- DISPLAY 'R3800-00 - PROBLEMAS INSERT (CONVERSAO)  ' */
                    _.Display($"R3800-00 - PROBLEMAS INSERT (CONVERSAO)  ");

                    /*" -3421- DISPLAY '           TITULO......................  ' V0FILT-NUMSIVPF */
                    _.Display($"           TITULO......................  {V0FILT_NUMSIVPF}");

                    /*" -3423- DISPLAY '           SICOB.......................  ' V0FILT-NUMSICOB */
                    _.Display($"           SICOB.......................  {V0FILT_NUMSICOB}");

                    /*" -3425- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3425- ADD 1 TO IN-CONVERSAO. */
            WS_AUX_ARQUIVO.IN_CONVERSAO.Value = WS_AUX_ARQUIVO.IN_CONVERSAO + 1;

        }

        [StopWatch]
        /*" R3800-00-INSERT-CONVERSAO-DB-INSERT-1 */
        public void R3800_00_INSERT_CONVERSAO_DB_INSERT_1()
        {
            /*" -3412- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:V0FILT-NUMSIVPF , :V0FILT-NUMSICOB , :V0FILT-CODEMP , :V0FILT-CODSIVPF , :V0FILT-AGECOBR , :V0FILT-DTMOVTO , :V0FILT-DTQITBCO , :V0FILT-VLRCAP , :V0FILT-CODUSU , CURRENT TIMESTAMP) END-EXEC. */

            var r3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1 = new R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1()
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

            R3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1.Execute(r3800_00_INSERT_CONVERSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R3850-00-TRATA-DUPLICI-SICOB-SECTION */
        private void R3850_00_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -3435- MOVE '3850' TO WNR-EXEC-SQL. */
            _.Move("3850", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3436- PERFORM R3000-00-TRATA-SIVPF */

            R3000_00_TRATA_SIVPF_SECTION();

            /*" -3437- PERFORM R3800-00-INSERT-CONVERSAO. */

            R3800_00_INSERT_CONVERSAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-MONTA-V0FOLLOWUP-SECTION */
        private void R3900_00_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -3448- MOVE '3900' TO WNR-EXEC-SQL. */
            _.Move("3900", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3450- MOVE '2' TO WSHOST-SITUACAO. */
            _.Move("2", WSHOST_SITUACAO);

            /*" -3451- MOVE COBRAN-NOSS-NUMERO TO V0MCOB-NRTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_NOSS_NUMERO, V0MCOB_NRTIT);

            /*" -3452- MOVE COBRAN-VLR-PRINC TO V0MCOB-VALTIT */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0MCOB_VALTIT);

            /*" -3453- MOVE COBRAN-IOF TO V0MCOB-VLIOCC */
            _.Move(COBRAN_REGISTRO.COBRAN_IOF, V0MCOB_VLIOCC);

            /*" -3454- MOVE ZEROS TO V0MCOB-VALCDT */
            _.Move(0, V0MCOB_VALCDT);

            /*" -3460- COMPUTE V0MCOB-VALCDT EQUAL COBRAN-VLR-PRINC - COBRAN-IOF - COBRAN-DESPESAS - COBRAN-ABATIMENTO. */
            V0MCOB_VALCDT.Value = COBRAN_REGISTRO.COBRAN_VLR_PRINC - COBRAN_REGISTRO.COBRAN_IOF - COBRAN_REGISTRO.COBRAN_DESPESAS - COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -3462- PERFORM R4050-00-INSERT-V0MOVICOB. */

            R4050_00_INSERT_V0MOVICOB_SECTION();

            /*" -3468- MOVE SPACES TO V0FOLL-CDERRO01 V0FOLL-CDERRO03 V0FOLL-CDERRO04 V0FOLL-CDERRO05 V0FOLL-CDERRO06. */
            _.Move("", V0FOLL_CDERRO01, V0FOLL_CDERRO03, V0FOLL_CDERRO04, V0FOLL_CDERRO05, V0FOLL_CDERRO06);

            /*" -3470- MOVE ZEROS TO AC-DUPLICA. */
            _.Move(0, WS_AUX_ARQUIVO.AC_DUPLICA);

            /*" -3470- PERFORM R4100-00-INSERT-V0FOLLOWUP. */

            R4100_00_INSERT_V0FOLLOWUP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R3950-00-UPDATE-CONVERSAO-SECTION */
        private void R3950_00_UPDATE_CONVERSAO_SECTION()
        {
            /*" -3481- MOVE '3950' TO WNR-EXEC-SQL. */
            _.Move("3950", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3482- IF CONVSICOB-AGEPGTO EQUAL ZEROS */

            if (CONVSICOB_AGEPGTO == 00)
            {

                /*" -3484- MOVE V0FILT-AGECOBR TO CONVSICOB-AGEPGTO. */
                _.Move(V0FILT_AGECOBR, CONVSICOB_AGEPGTO);
            }


            /*" -3485- IF CONVSICOB-DTQITBCO EQUAL '0001-01-01' */

            if (CONVSICOB_DTQITBCO == "0001-01-01")
            {

                /*" -3487- MOVE V0FILT-DTQITBCO TO CONVSICOB-DTQITBCO. */
                _.Move(V0FILT_DTQITBCO, CONVSICOB_DTQITBCO);
            }


            /*" -3489- MOVE V0FILT-VLRCAP TO CONVSICOB-VAL-RCAP. */
            _.Move(V0FILT_VLRCAP, CONVSICOB_VAL_RCAP);

            /*" -3495- PERFORM R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1 */

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1();

            /*" -3498- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3499- DISPLAY 'R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ' */
                _.Display($"R3950-00 - PROBLEMAS UPDATE (CONVERSAO)  ");

                /*" -3501- DISPLAY '           PROPOSTA SIVPF..............  ' V0FILT-NUMSIVPF */
                _.Display($"           PROPOSTA SIVPF..............  {V0FILT_NUMSIVPF}");

                /*" -3503- DISPLAY '           SICOB.......................  ' V0FILT-NUMSICOB */
                _.Display($"           SICOB.......................  {V0FILT_NUMSICOB}");

                /*" -3506- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3513- PERFORM R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2 */

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2();

            /*" -3516- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3517- DISPLAY 'R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ' */
                _.Display($"R3950-00 - PROBLEMAS UPDATE PROPOSTA FIDELIZ");

                /*" -3519- DISPLAY '           PROPOSTA SIVPF..............  ' V0FILT-NUMSIVPF */
                _.Display($"           PROPOSTA SIVPF..............  {V0FILT_NUMSIVPF}");

                /*" -3519- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3950-00-UPDATE-CONVERSAO-DB-UPDATE-1 */
        public void R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1()
        {
            /*" -3495- EXEC SQL UPDATE SEGUROS.CONVERSAO_SICOB SET AGEPGTO = :CONVSICOB-AGEPGTO , DATA_QUITACAO = :CONVSICOB-DTQITBCO , VAL_RCAP = :CONVSICOB-VAL-RCAP WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF END-EXEC. */

            var r3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1 = new R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1()
            {
                CONVSICOB_DTQITBCO = CONVSICOB_DTQITBCO.ToString(),
                CONVSICOB_VAL_RCAP = CONVSICOB_VAL_RCAP.ToString(),
                CONVSICOB_AGEPGTO = CONVSICOB_AGEPGTO.ToString(),
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1.Execute(r3950_00_UPDATE_CONVERSAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3950_99_SAIDA*/

        [StopWatch]
        /*" R3950-00-UPDATE-CONVERSAO-DB-UPDATE-2 */
        public void R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2()
        {
            /*" -3513- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DATA_CREDITO = :V0RCOM-DTMOVTO , AGEPGTO = :CONVSICOB-AGEPGTO , DTQITBCO = :CONVSICOB-DTQITBCO , VAL_PAGO = :CONVSICOB-VAL-RCAP WHERE NUM_PROPOSTA_SIVPF = :V0FILT-NUMSIVPF END-EXEC. */

            var r3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1 = new R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1()
            {
                CONVSICOB_DTQITBCO = CONVSICOB_DTQITBCO.ToString(),
                CONVSICOB_VAL_RCAP = CONVSICOB_VAL_RCAP.ToString(),
                CONVSICOB_AGEPGTO = CONVSICOB_AGEPGTO.ToString(),
                V0RCOM_DTMOVTO = V0RCOM_DTMOVTO.ToString(),
                V0FILT_NUMSIVPF = V0FILT_NUMSIVPF.ToString(),
            };

            R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1.Execute(r3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R4050-00-INSERT-V0MOVICOB-SECTION */
        private void R4050_00_INSERT_V0MOVICOB_SECTION()
        {
            /*" -3530- MOVE '4050' TO WNR-EXEC-SQL. */
            _.Move("4050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3531- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -3532- MOVE COBRAN-CODOCORRENC TO V0MCOB-CODMOV */
            _.Move(COBRAN_REGISTRO.COBRAN_CODOCORRENC, V0MCOB_CODMOV);

            /*" -3533- MOVE V0AVIS-BCOAVISO TO V0MCOB-BANCO */
            _.Move(V0AVIS_BCOAVISO, V0MCOB_BANCO);

            /*" -3534- MOVE V0AVIS-AGEAVISO TO V0MCOB-AGENCIA */
            _.Move(V0AVIS_AGEAVISO, V0MCOB_AGENCIA);

            /*" -3535- MOVE V0AVIS-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0MCOB_NRAVISO);

            /*" -3536- MOVE WWORK-NUMFITA TO V0MCOB-NUMFITA */
            _.Move(WS_AUX_AVISO.WWORK_NUMFITA, V0MCOB_NUMFITA);

            /*" -3537- MOVE V0SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -3539- MOVE ZEROS TO V0MCOB-NRENDOS V0MCOB-NRPARCEL */
            _.Move(0, V0MCOB_NRENDOS, V0MCOB_NRPARCEL);

            /*" -3540- MOVE '2' TO V0MCOB-SITUACAO */
            _.Move("2", V0MCOB_SITUACAO);

            /*" -3542- MOVE '1' TO V0MCOB-TIPOMOV. */
            _.Move("1", V0MCOB_TIPOMOV);

            /*" -3543- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -3544- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -3545- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -3546- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -3547- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -3549- MOVE WDATA-TABELA TO V0MCOB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0MCOB_DTQITBCO);

            /*" -3550- IF AUX-APOLICE LESS 10000000000000 */

            if (WS_AUX_ARQUIVO.AUX_APOLICE < 10000000000000)
            {

                /*" -3551- MOVE AUX-APOLICE TO V0MCOB-NUMAPOL */
                _.Move(WS_AUX_ARQUIVO.AUX_APOLICE, V0MCOB_NUMAPOL);

                /*" -3552- ELSE */
            }
            else
            {


                /*" -3554- MOVE AUX-NUMAPOL TO V0MCOB-NUMAPOL. */
                _.Move(WS_AUX_ARQUIVO.FILLER_9.AUX_NUMAPOL, V0MCOB_NUMAPOL);
            }


            /*" -3557- MOVE COBRAN-TITULO16 TO V0MCOB-NUM-NOSSO-TITULO. */
            _.Move(COBRAN_REGISTRO.COBRAN_USO_EMPRESA.COBRAN_TITULO16, V0MCOB_NUM_NOSSO_TITULO);

            /*" -3599- PERFORM R4050_00_INSERT_V0MOVICOB_DB_INSERT_1 */

            R4050_00_INSERT_V0MOVICOB_DB_INSERT_1();

            /*" -3602- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3603- DISPLAY 'R4050-00 - PROBLEMAS INSERT (V0MOVICOB)  ' */
                _.Display($"R4050-00 - PROBLEMAS INSERT (V0MOVICOB)  ");

                /*" -3603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4050-00-INSERT-V0MOVICOB-DB-INSERT-1 */
        public void R4050_00_INSERT_V0MOVICOB_DB_INSERT_1()
        {
            /*" -3599- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , :V0MCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1 = new R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1()
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

            R4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1.Execute(r4050_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-INSERT-V0FOLLOWUP-SECTION */
        private void R4100_00_INSERT_V0FOLLOWUP_SECTION()
        {
            /*" -3616- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3617- IF V0MCOB-NUMAPOL EQUAL ZEROS */

            if (V0MCOB_NUMAPOL == 00)
            {

                /*" -3618- MOVE V0MCOB-NRTIT TO V0FOLL-NUMAPOL */
                _.Move(V0MCOB_NRTIT, V0FOLL_NUMAPOL);

                /*" -3619- ELSE */
            }
            else
            {


                /*" -3621- MOVE V0MCOB-NUMAPOL TO V0FOLL-NUMAPOL. */
                _.Move(V0MCOB_NUMAPOL, V0FOLL_NUMAPOL);
            }


            /*" -3622- MOVE V0MCOB-NRENDOS TO V0FOLL-NRENDOS */
            _.Move(V0MCOB_NRENDOS, V0FOLL_NRENDOS);

            /*" -3623- MOVE V0MCOB-NRPARCEL TO V0FOLL-NRPARCEL */
            _.Move(V0MCOB_NRPARCEL, V0FOLL_NRPARCEL);

            /*" -3624- MOVE SPACES TO V0FOLL-DACPARC */
            _.Move("", V0FOLL_DACPARC);

            /*" -3625- MOVE V0MCOB-DTMOVTO TO V0FOLL-DTMOVTO */
            _.Move(V0MCOB_DTMOVTO, V0FOLL_DTMOVTO);

            /*" -3626- MOVE V0MCOB-VALTIT TO V0FOLL-VLPREMIO */
            _.Move(V0MCOB_VALTIT, V0FOLL_VLPREMIO);

            /*" -3627- MOVE V0MCOB-BANCO TO V0FOLL-BCOAVISO */
            _.Move(V0MCOB_BANCO, V0FOLL_BCOAVISO);

            /*" -3628- MOVE V0MCOB-AGENCIA TO V0FOLL-AGEAVISO */
            _.Move(V0MCOB_AGENCIA, V0FOLL_AGEAVISO);

            /*" -3629- MOVE V0MCOB-NRAVISO TO V0FOLL-NRAVISO */
            _.Move(V0MCOB_NRAVISO, V0FOLL_NRAVISO);

            /*" -3630- MOVE 30 TO V0FOLL-CODBAIXA */
            _.Move(30, V0FOLL_CODBAIXA);

            /*" -3631- MOVE '0' TO V0FOLL-SITUACAO */
            _.Move("0", V0FOLL_SITUACAO);

            /*" -3632- MOVE SPACES TO V0FOLL-SITCONTB */
            _.Move("", V0FOLL_SITCONTB);

            /*" -3633- MOVE 103 TO V0FOLL-OPERACAO */
            _.Move(103, V0FOLL_OPERACAO);

            /*" -3634- MOVE SPACES TO V0FOLL-DTLIBER */
            _.Move("", V0FOLL_DTLIBER);

            /*" -3635- MOVE V0MCOB-DTQITBCO TO V0FOLL-DTQITBCO */
            _.Move(V0MCOB_DTQITBCO, V0FOLL_DTQITBCO);

            /*" -3636- MOVE ZEROS TO V0FOLL-CODEMP */
            _.Move(0, V0FOLL_CODEMP);

            /*" -3637- MOVE '1' TO V0FOLL-TIPSGU */
            _.Move("1", V0FOLL_TIPSGU);

            /*" -3638- MOVE ZEROS TO V0FOLL-ORDLIDER */
            _.Move(0, V0FOLL_ORDLIDER);

            /*" -3639- MOVE COBRAN-AGE-COBRAN TO V0FOLL-CODLIDER */
            _.Move(COBRAN_REGISTRO.FILLER_45.COBRAN_AGE_COBRAN, V0FOLL_CODLIDER);

            /*" -3640- MOVE CONVEN-FONTE TO V0FOLL-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0FOLL_FONTE);

            /*" -3642- MOVE SPACES TO V0FOLL-APOLIDER. */
            _.Move("", V0FOLL_APOLIDER);

            /*" -3643- MOVE WSHOST-CODPRODU TO AUX-CODPRODU */
            _.Move(WSHOST_CODPRODU, WS_AUX_ARQUIVO.AUX_ENDOSLID.AUX_CODPRODU);

            /*" -3646- MOVE AUX-ENDOSLID TO V0FOLL-ENDOSLID. */
            _.Move(WS_AUX_ARQUIVO.AUX_ENDOSLID, V0FOLL_ENDOSLID);

            /*" -3650- MOVE V0MCOB-NUM-NOSSO-TITULO TO V0FOLL-NUM-NOSSO-TITULO. */
            _.Move(V0MCOB_NUM_NOSSO_TITULO, V0FOLL_NUM_NOSSO_TITULO);

            /*" -3651- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -3652- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA);

            /*" -3653- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_2PT1);

            /*" -3654- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU);

            /*" -3655- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_2PT2);

            /*" -3656- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU);

            /*" -3659- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_24.WTIME_DAYR, V0FOLL_HORAOPER);

            /*" -3663- MOVE ZEROS TO VIND-CODEMP VIND-TIPSGU VIND-ENDOSLID. */
            _.Move(0, VIND_CODEMP, VIND_TIPSGU, VIND_ENDOSLID);

            /*" -3667- MOVE -1 TO VIND-DTLIBER VIND-ORDLIDER VIND-APOLIDER. */
            _.Move(-1, VIND_DTLIBER, VIND_ORDLIDER, VIND_APOLIDER);

            /*" -3668- IF V0FOLL-CODLIDER NOT EQUAL ZEROS */

            if (V0FOLL_CODLIDER != 00)
            {

                /*" -3669- MOVE ZEROS TO VIND-CODLIDER */
                _.Move(0, VIND_CODLIDER);

                /*" -3670- ELSE */
            }
            else
            {


                /*" -3672- MOVE -1 TO VIND-CODLIDER. */
                _.Move(-1, VIND_CODLIDER);
            }


            /*" -3673- IF V0FOLL-DTQITBCO NOT EQUAL SPACES */

            if (!V0FOLL_DTQITBCO.IsEmpty())
            {

                /*" -3674- MOVE ZEROS TO VIND-DTQITBCO */
                _.Move(0, VIND_DTQITBCO);

                /*" -3675- ELSE */
            }
            else
            {


                /*" -3677- MOVE -1 TO VIND-DTQITBCO. */
                _.Move(-1, VIND_DTQITBCO);
            }


            /*" -3678- IF V0FOLL-FONTE NOT EQUAL ZEROS */

            if (V0FOLL_FONTE != 00)
            {

                /*" -3679- MOVE ZEROS TO VIND-FONTE */
                _.Move(0, VIND_FONTE);

                /*" -3680- ELSE */
            }
            else
            {


                /*" -3682- MOVE -1 TO VIND-FONTE. */
                _.Move(-1, VIND_FONTE);
            }


            /*" -3683- IF V0FOLL-NRRCAP NOT EQUAL ZEROS */

            if (V0FOLL_NRRCAP != 00)
            {

                /*" -3684- MOVE ZEROS TO VIND-NRRCAP */
                _.Move(0, VIND_NRRCAP);

                /*" -3685- ELSE */
            }
            else
            {


                /*" -3685- MOVE -1 TO VIND-NRRCAP. */
                _.Move(-1, VIND_NRRCAP);
            }


            /*" -0- FLUXCONTROL_PERFORM R4100_00_INSERT */

            R4100_00_INSERT();

        }

        [StopWatch]
        /*" R4100-00-INSERT */
        private void R4100_00_INSERT(bool isPerform = false)
        {
            /*" -3725- PERFORM R4100_00_INSERT_DB_INSERT_1 */

            R4100_00_INSERT_DB_INSERT_1();

            /*" -3728- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3729- ADD 1 TO AC-DUPLICA */
                WS_AUX_ARQUIVO.AC_DUPLICA.Value = WS_AUX_ARQUIVO.AC_DUPLICA + 1;

                /*" -3730- IF AC-DUPLICA LESS 10 */

                if (WS_AUX_ARQUIVO.AC_DUPLICA < 10)
                {

                    /*" -3731- PERFORM R4110-00-ADICIONA-TIME */

                    R4110_00_ADICIONA_TIME_SECTION();

                    /*" -3732- GO TO R4100-00-INSERT */
                    new Task(() => R4100_00_INSERT()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3733- ELSE */
                }
                else
                {


                    /*" -3738- DISPLAY 'R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) ' V0FOLL-NUMAPOL '  ' V0FOLL-NRENDOS '  ' V0FOLL-NRPARCEL '  ' V0FOLL-NRAVISO */

                    $"R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) {V0FOLL_NUMAPOL}  {V0FOLL_NRENDOS}  {V0FOLL_NRPARCEL}  {V0FOLL_NRAVISO}"
                    .Display();

                    /*" -3739- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3740- ELSE */
                }

            }
            else
            {


                /*" -3741- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3746- DISPLAY 'R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) ' V0FOLL-NUMAPOL '  ' V0FOLL-NRENDOS '  ' V0FOLL-NRPARCEL '  ' V0FOLL-NRAVISO */

                    $"R4100-00 - PROBLEMAS INSERT (V0FOLLOWUP) {V0FOLL_NUMAPOL}  {V0FOLL_NRENDOS}  {V0FOLL_NRPARCEL}  {V0FOLL_NRAVISO}"
                    .Display();

                    /*" -3749- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3749- ADD 1 TO IN-FOLLOWUP. */
            WS_AUX_ARQUIVO.IN_FOLLOWUP.Value = WS_AUX_ARQUIVO.IN_FOLLOWUP + 1;

        }

        [StopWatch]
        /*" R4100-00-INSERT-DB-INSERT-1 */
        public void R4100_00_INSERT_DB_INSERT_1()
        {
            /*" -3725- EXEC SQL INSERT INTO SEGUROS.V0FOLLOWUP VALUES (:V0FOLL-NUMAPOL , :V0FOLL-NRENDOS , :V0FOLL-NRPARCEL , :V0FOLL-DACPARC , :V0FOLL-DTMOVTO , :V0FOLL-HORAOPER , :V0FOLL-VLPREMIO , :V0FOLL-BCOAVISO , :V0FOLL-AGEAVISO , :V0FOLL-NRAVISO , :V0FOLL-CODBAIXA , :V0FOLL-CDERRO01 , :V0FOLL-CDERRO02 , :V0FOLL-CDERRO03 , :V0FOLL-CDERRO04 , :V0FOLL-CDERRO05 , :V0FOLL-CDERRO06 , :V0FOLL-SITUACAO , :V0FOLL-SITCONTB , :V0FOLL-OPERACAO , :V0FOLL-DTLIBER:VIND-DTLIBER , :V0FOLL-DTQITBCO:VIND-DTQITBCO , :V0FOLL-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0FOLL-ORDLIDER:VIND-ORDLIDER , :V0FOLL-TIPSGU:VIND-TIPSGU , :V0FOLL-APOLIDER:VIND-APOLIDER , :V0FOLL-ENDOSLID:VIND-ENDOSLID , :V0FOLL-CODLIDER:VIND-CODLIDER , :V0FOLL-FONTE:VIND-FONTE , :V0FOLL-NRRCAP:VIND-NRRCAP , :V0FOLL-NUM-NOSSO-TITULO) END-EXEC. */

            var r4100_00_INSERT_DB_INSERT_1_Insert1 = new R4100_00_INSERT_DB_INSERT_1_Insert1()
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

            R4100_00_INSERT_DB_INSERT_1_Insert1.Execute(r4100_00_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4110-00-ADICIONA-TIME-SECTION */
        private void R4110_00_ADICIONA_TIME_SECTION()
        {
            /*" -3762- MOVE '4110' TO WNR-EXEC-SQL. */
            _.Move("4110", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3764- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU > 00 && WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -3765- ADD 1 TO WTIME-SEGU */
                WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU.Value = WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -3766- ELSE */
            }
            else
            {


                /*" -3768- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU > 00 && WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -3769- ADD 1 TO WTIME-MINU */
                    WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU.Value = WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -3770- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU);

                    /*" -3771- ELSE */
                }
                else
                {


                    /*" -3773- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA > 00 && WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -3774- ADD 1 TO WTIME-HORA */
                        WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA.Value = WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -3776- MOVE 1 TO WTIME-MINU WTIME-SEGU */
                        _.Move(1, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU);
                        _.Move(1, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU);


                        /*" -3777- ELSE */
                    }
                    else
                    {


                        /*" -3782- MOVE 01 TO WTIME-HORA WTIME-MINU WTIME-SEGU. */
                        _.Move(01, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA);
                        _.Move(01, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU);
                        _.Move(01, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU);

                    }

                }

            }


            /*" -3782- MOVE WTIME-DAYR TO V0FOLL-HORAOPER. */
            _.Move(WS_AUX_DATAS.FILLER_24.WTIME_DAYR, V0FOLL_HORAOPER);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4110_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-TRATA-TRAILLER-SECTION */
        private void R4500_00_TRATA_TRAILLER_SECTION()
        {
            /*" -3794- MOVE '4500' TO WNR-EXEC-SQL. */
            _.Move("4500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3795- IF V0AVIS-VLPRMTOT NOT EQUAL ZEROS */

            if (V0AVIS_VLPRMTOT != 00)
            {

                /*" -3796- PERFORM R4550-00-INSERT-V0AVISOCRED */

                R4550_00_INSERT_V0AVISOCRED_SECTION();

                /*" -3798- PERFORM R4600-00-INSERT-V0AVISOSALDO. */

                R4600_00_INSERT_V0AVISOSALDO_SECTION();
            }


            /*" -3800- PERFORM R4650-00-INSERT-V0CONTROCNAB. */

            R4650_00_INSERT_V0CONTROCNAB_SECTION();

            /*" -3801- IF AD-QTDEBIL NOT EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.AD_QTDEBIL != 00)
            {

                /*" -3803- PERFORM R7000-00-TRATA-ADIANTA. */

                R7000_00_TRATA_ADIANTA_SECTION();
            }


            /*" -3804- IF V0AVIS-VLPRMTOT NOT EQUAL ZEROS */

            if (V0AVIS_VLPRMTOT != 00)
            {

                /*" -3806- SET WS-PRO TO 1 */
                WS_PRO.Value = 1;

                /*" -3806- PERFORM R8500-00-GRAVA-DESPESAS 2000 TIMES. */

                for (int i = 0; i < 2000; i++)
                {

                    R8500_00_GRAVA_DESPESAS_SECTION();

                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4550-00-INSERT-V0AVISOCRED-SECTION */
        private void R4550_00_INSERT_V0AVISOCRED_SECTION()
        {
            /*" -3817- MOVE '4550' TO WNR-EXEC-SQL. */
            _.Move("4550", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3822- COMPUTE V0AVIS-VLPRMLIQ EQUAL V0AVIS-VLPRMTOT - V0AVIS-VLIOCC - V0AVIS-VLDESPES - V0AVIS-VALADT. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT - V0AVIS_VLIOCC - V0AVIS_VLDESPES - V0AVIS_VALADT;

            /*" -3824- MOVE 'P' TO V0AVIS-SITDEPTER. */
            _.Move("P", V0AVIS_SITDEPTER);

            /*" -3864- PERFORM R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1 */

            R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1();

            /*" -3867- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3868- DISPLAY 'R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)' */
                _.Display($"R4550-00 - PROBLEMAS INSERT (V0AVISOCRED)");

                /*" -3868- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4550-00-INSERT-V0AVISOCRED-DB-INSERT-1 */
        public void R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1()
        {
            /*" -3864- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED ( BCOAVISO, AGEAVISO, NRAVISO, NRSEQ, DTMOVTO, OPERACAO, TIPAVI, DTAVISO, VLIOCC, VLDESPES, PRECED, VLPRMLIQ, VLPRMTOT, SITCONTB, COD_EMPRESA, TIMESTAMP, ORIGAVISO, VALADT, SITDEPTER) VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO:VIND-ORIGAVISO , :V0AVIS-VALADT:VIND-VALADT , :V0AVIS-SITDEPTER) END-EXEC. */

            var r4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1 = new R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1()
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

            R4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1.Execute(r4550_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4550_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INSERT-V0AVISOSALDO-SECTION */
        private void R4600_00_INSERT_V0AVISOSALDO_SECTION()
        {
            /*" -3879- MOVE '4600' TO WNR-EXEC-SQL. */
            _.Move("4600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3901- PERFORM R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1 */

            R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1();

            /*" -3904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3905- DISPLAY 'R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)' */
                _.Display($"R4600-00 - PROBLEMAS INSERT (V0AVISOSALD)");

                /*" -3905- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4600-00-INSERT-V0AVISOSALDO-DB-INSERT-1 */
        public void R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1()
        {
            /*" -3901- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS ( COD_EMPRESA, BCOAVISO, AGEAVISO, TIPSGU, NRAVISO, DTAVISO, DTMOVTO, SDOATU, SITUACAO, TIMESTAMP ) VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1 = new R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1()
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

            R4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1.Execute(r4600_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4650-00-INSERT-V0CONTROCNAB-SECTION */
        private void R4650_00_INSERT_V0CONTROCNAB_SECTION()
        {
            /*" -3917- MOVE '4650' TO WNR-EXEC-SQL. */
            _.Move("4650", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3928- PERFORM R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1 */

            R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1();

            /*" -3931- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3936- DISPLAY 'R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB)' ' ' V0CNAB-ORGAO ' ' V0CNAB-NRCTACED ' ' V0CNAB-TIPOCOB ' ' V0CNAB-DTMOVTO */

                $"R4650-00 - REGISTRO DUPLICADO (V0CONTROCNAB) {V0CNAB_ORGAO} {V0CNAB_NRCTACED} {V0CNAB_TIPOCOB} {V0CNAB_DTMOVTO}"
                .Display();

                /*" -3938- GO TO R4650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3939- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3944- DISPLAY 'R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB)' ' ' V0CNAB-ORGAO ' ' V0CNAB-NRCTACED ' ' V0CNAB-TIPOCOB ' ' V0CNAB-DTMOVTO */

                $"R4650-00 - PROBLEMAS NO INSERT(V0CONTROCNAB) {V0CNAB_ORGAO} {V0CNAB_NRCTACED} {V0CNAB_TIPOCOB} {V0CNAB_DTMOVTO}"
                .Display();

                /*" -3944- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4650-00-INSERT-V0CONTROCNAB-DB-INSERT-1 */
        public void R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1()
        {
            /*" -3928- EXEC SQL INSERT INTO SEGUROS.V0CONTROCNAB VALUES (:V0CNAB-COD-EMP , :V0CNAB-ORGAO , :V0CNAB-NRCTACED , :V0CNAB-TIPOCOB , :V0CNAB-DTMOVTO , :V0CNAB-DATCEF , :V0CNAB-NRSEQ , :V0CNAB-QTDREG , CURRENT TIMESTAMP) END-EXEC. */

            var r4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1 = new R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1()
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

            R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1.Execute(r4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4650_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-TRATA-BILHETES-SECTION */
        private void R6000_00_TRATA_BILHETES_SECTION()
        {
            /*" -3961- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -3962- IF V0AVIS-DTAVISO LESS '2000-10-01' */

            if (V0AVIS_DTAVISO < "2000-10-01")
            {

                /*" -3963- ADD 1 TO AD-QTDEBIL */
                WS_AUX_ARQUIVO.AD_QTDEBIL.Value = WS_AUX_ARQUIVO.AD_QTDEBIL + 1;

                /*" -3964- ELSE */
            }
            else
            {


                /*" -3967- PERFORM R6050-00-CALCULA-ADIANTA. */

                R6050_00_CALCULA_ADIANTA_SECTION();
            }


            /*" -3970- MOVE COBRAN-DESC-CONCED TO WS-VALADT. */
            _.Move(COBRAN_REGISTRO.COBRAN_DESC_CONCED, WS_AUX_ARQUIVO.WS_VALADT);

            /*" -3974- COMPUTE V0AVIS-VALADT EQUAL V0AVIS-VALADT + WS-VALADT. */
            V0AVIS_VALADT.Value = V0AVIS_VALADT + WS_AUX_ARQUIVO.WS_VALADT;

            /*" -3976- MOVE ZEROS TO V0CFEN-CODEMP */
            _.Move(0, V0CFEN_CODEMP);

            /*" -3978- MOVE AUX-TITSIVPF TO V0CFEN-NUMBIL */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0CFEN_NUMBIL);

            /*" -3979- MOVE CONVEN-AGECOBR TO V0CFEN-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0CFEN_AGECOBR);

            /*" -3980- MOVE WS-VALADT TO V0CFEN-VALADT */
            _.Move(WS_AUX_ARQUIVO.WS_VALADT, V0CFEN_VALADT);

            /*" -3985- MOVE ZEROS TO V0CFEN-NRMATRVEN V0CFEN-AGECTAVEN V0CFEN-OPRCTAVEN V0CFEN-NUMCTAVEN V0CFEN-DIGCTAVEN */
            _.Move(0, V0CFEN_NRMATRVEN, V0CFEN_AGECTAVEN, V0CFEN_OPRCTAVEN, V0CFEN_NUMCTAVEN, V0CFEN_DIGCTAVEN);

            /*" -3989- MOVE ZEROS TO V0CFEN-AGECTADEB V0CFEN-OPRCTADEB V0CFEN-NUMCTADEB V0CFEN-DIGCTADEB */
            _.Move(0, V0CFEN_AGECTADEB, V0CFEN_OPRCTADEB, V0CFEN_NUMCTADEB, V0CFEN_DIGCTADEB);

            /*" -3990- MOVE SPACES TO V0CFEN-SINDICO */
            _.Move("", V0CFEN_SINDICO);

            /*" -3991- MOVE COBRAN-VLR-PRINC TO V0CFEN-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0CFEN_VLRCAP);

            /*" -3992- MOVE V0SIST-DTMOVABE TO V0CFEN-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0CFEN_DTMOVTO);

            /*" -3993- MOVE '0' TO V0CFEN-SITUACAO */
            _.Move("0", V0CFEN_SITUACAO);

            /*" -3997- MOVE ZEROS TO V0CFEN-NRMATRGER V0CFEN-VALADTGER V0CFEN-NRMATRSUN V0CFEN-VALADTSUN */
            _.Move(0, V0CFEN_NRMATRGER, V0CFEN_VALADTGER, V0CFEN_NRMATRSUN, V0CFEN_VALADTSUN);

            /*" -4001- MOVE SPACES TO V0CFEN-DTPAGGER V0CFEN-DTCANCEL V0CFEN-DTPAGSUN. */
            _.Move("", V0CFEN_DTPAGGER, V0CFEN_DTCANCEL, V0CFEN_DTPAGSUN);

            /*" -4002- MOVE COBRAN-DATA-CRED TO WDATA-FITA */
            _.Move(COBRAN_REGISTRO.COBRAN_DATA_CRED, WS_AUX_DATAS.WDATA_FITA);

            /*" -4003- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA);

            /*" -4004- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES);

            /*" -4005- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO);

            /*" -4006- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

            if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
            {

                /*" -4007- MOVE 19 TO WDAT-SEC-SEC */
                _.Move(19, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);

                /*" -4008- ELSE */
            }
            else
            {


                /*" -4010- MOVE 20 TO WDAT-SEC-SEC. */
                _.Move(20, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);
            }


            /*" -4011- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4012- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4013- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4014- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4016- MOVE WDATA-TABELA TO V0CFEN-DTCREDITO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0CFEN_DTCREDITO);

            /*" -4017- MOVE COBRAN-DATAOCORREN TO WDATA-FITA */
            _.Move(COBRAN_REGISTRO.COBRAN_DATAOCORREN, WS_AUX_DATAS.WDATA_FITA);

            /*" -4018- MOVE WDAT-FITA-DIA TO WDAT-SEC-DIA */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_DIA, WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA);

            /*" -4019- MOVE WDAT-FITA-MES TO WDAT-SEC-MES */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_MES, WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES);

            /*" -4020- MOVE WDAT-FITA-ANO TO WDAT-SEC-ANO */
            _.Move(WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO, WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO);

            /*" -4021- IF WDAT-FITA-ANO-A EQUAL '7' OR '8' OR '9' */

            if (WS_AUX_DATAS.WDATA_FITA.WDAT_FITA_ANO.WDAT_FITA_ANO_A.In("7", "8", "9"))
            {

                /*" -4022- MOVE 19 TO WDAT-SEC-SEC */
                _.Move(19, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);

                /*" -4023- ELSE */
            }
            else
            {


                /*" -4025- MOVE 20 TO WDAT-SEC-SEC. */
                _.Move(20, WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC);
            }


            /*" -4026- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4027- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4028- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4029- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4031- MOVE WDATA-TABELA TO V0CFEN-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0CFEN_DTQITBCO);

            /*" -4040- MOVE -1 TO VIND-NRMATRGER VIND-VALADTGER VIND-DTPAGGER VIND-DTCANCEL VIND-NRMATRSUN VIND-VALADTSUN VIND-DTPAGSUN. */
            _.Move(-1, VIND_NRMATRGER, VIND_VALADTGER, VIND_DTPAGGER, VIND_DTCANCEL, VIND_NRMATRSUN, VIND_VALADTSUN, VIND_DTPAGSUN);

            /*" -4046- PERFORM R6100-00-INSERT-V0COMISFENAE. */

            R6100_00_INSERT_V0COMISFENAE_SECTION();

            /*" -4047- MOVE V0CFEN-NUMBIL TO V0VEND-NUMBIL */
            _.Move(V0CFEN_NUMBIL, V0VEND_NUMBIL);

            /*" -4048- MOVE V0CFEN-AGECOBR TO V0VEND-AGECOBR */
            _.Move(V0CFEN_AGECOBR, V0VEND_AGECOBR);

            /*" -4049- MOVE V0CFEN-VLRCAP TO V0VEND-VLRCAP */
            _.Move(V0CFEN_VLRCAP, V0VEND_VLRCAP);

            /*" -4050- MOVE WWORK-DTAVISO TO V0VEND-DTMOVTO */
            _.Move(WS_AUX_AVISO.WWORK_DTAVISO, V0VEND_DTMOVTO);

            /*" -4053- MOVE V0CFEN-DTQITBCO TO V0VEND-DTQITBCO. */
            _.Move(V0CFEN_DTQITBCO, V0VEND_DTQITBCO);

            /*" -4053- PERFORM R6200-00-INSERT-V0VENDASBIL. */

            R6200_00_INSERT_V0VENDASBIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6050-00-CALCULA-ADIANTA-SECTION */
        private void R6050_00_CALCULA_ADIANTA_SECTION()
        {
            /*" -4066- MOVE '6050' TO WNR-EXEC-SQL. */
            _.Move("6050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4067- MOVE ZEROS TO WS-SUBS */
            _.Move(0, WS_AUX_ARQUIVO.WS_SUBS);

            /*" -4069- SET WS-COB TO 1. */
            WS_COB.Value = 1;

            /*" -4070- SEARCH WCOBE-OCORRECOB */
            for (; WS_COB < WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB.Items.Count; WS_COB.Value++)
            {

                /*" -4073- WHEN V0RCOM-VLRCAP = WCOBE-VLPRMTOT(WS-COB) AND DT-AMD >= WCOBE-DTINIVIG(WS-COB) AND DT-AMD <= WCOBE-DTTERVIG(WS-COB) */

                if (V0RCOM_VLRCAP == WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTOT && WS_AUX_ARQUIVO.DT_AMD >= WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_DTINIVIG && WS_AUX_ARQUIVO.DT_AMD <= WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_DTTERVIG)
                {


                    /*" -4073- SET WS-SUBS TO WS-COB  END-SEARCH. */
                    WS_AUX_ARQUIVO.WS_SUBS.Value = WS_COB;
                    break;
                }
            }


            /*" -4077- IF WS-SUBS EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.WS_SUBS == 00)
            {

                /*" -4084- GO TO R6050-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6050_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4087- MOVE WCOBE-VLPRMTAR(WS-COB) TO WS-VLPRMTAR. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.WS_COBERTURAS.WCOBE_COBERTUR.WCOBE_OCORRECOB[WS_COB].WCOBE_VLPRMTAR, WS_AUX_ARQUIVO.WS_VLPRMTAR);

            /*" -4090- COMPUTE WS-VLPRMTAR EQUAL WS-VLPRMTAR * 0,005. */
            WS_AUX_ARQUIVO.WS_VLPRMTAR.Value = WS_AUX_ARQUIVO.WS_VLPRMTAR * 0.005;

            /*" -4094- COMPUTE WS-VLPRMTAR EQUAL WS-VLPRMTAR * 0,90. */
            WS_AUX_ARQUIVO.WS_VLPRMTAR.Value = WS_AUX_ARQUIVO.WS_VLPRMTAR * 0.90;

            /*" -4095- IF WS-VLPRMTAR GREATER ZEROS */

            if (WS_AUX_ARQUIVO.WS_VLPRMTAR > 00)
            {

                /*" -4096- ADD 1 TO AD-QTDEBIL */
                WS_AUX_ARQUIVO.AD_QTDEBIL.Value = WS_AUX_ARQUIVO.AD_QTDEBIL + 1;

                /*" -4096- ADD WS-VLPRMTAR TO AD-VLRABIL. */
                WS_AUX_ARQUIVO.AD_VLRABIL.Value = WS_AUX_ARQUIVO.AD_VLRABIL + WS_AUX_ARQUIVO.WS_VLPRMTAR;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6050_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-INSERT-V0COMISFENAE-SECTION */
        private void R6100_00_INSERT_V0COMISFENAE_SECTION()
        {
            /*" -4109- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4138- PERFORM R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1 */

            R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1();

            /*" -4141- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4143- DISPLAY 'R6100-00 - REGISTRO DUPLICADO     ' V0CFEN-NUMBIL */
                _.Display($"R6100-00 - REGISTRO DUPLICADO     {V0CFEN_NUMBIL}");

                /*" -4144- ELSE */
            }
            else
            {


                /*" -4145- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4146- DISPLAY 'R6100-00 - PROBLEMAS INSERT (V0COMISFENAE)' */
                    _.Display($"R6100-00 - PROBLEMAS INSERT (V0COMISFENAE)");

                    /*" -4146- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6100-00-INSERT-V0COMISFENAE-DB-INSERT-1 */
        public void R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1()
        {
            /*" -4138- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO_FENAE VALUES (:V0CFEN-CODEMP , :V0CFEN-NUMBIL , :V0CFEN-AGECOBR , :V0CFEN-VALADT , :V0CFEN-DTCREDITO , :V0CFEN-NRMATRVEN , :V0CFEN-AGECTAVEN , :V0CFEN-OPRCTAVEN , :V0CFEN-NUMCTAVEN , :V0CFEN-DIGCTAVEN , :V0CFEN-AGECTADEB , :V0CFEN-OPRCTADEB , :V0CFEN-NUMCTADEB , :V0CFEN-DIGCTADEB , :V0CFEN-SINDICO , :V0CFEN-DTQITBCO , :V0CFEN-VLRCAP , :V0CFEN-DTMOVTO , :V0CFEN-SITUACAO , CURRENT TIMESTAMP , :V0CFEN-NRMATRGER:VIND-NRMATRGER , :V0CFEN-VALADTGER:VIND-VALADTGER , :V0CFEN-DTPAGGER:VIND-DTPAGGER , :V0CFEN-DTCANCEL:VIND-DTCANCEL , :V0CFEN-NRMATRSUN:VIND-NRMATRSUN , :V0CFEN-VALADTSUN:VIND-VALADTSUN , :V0CFEN-DTPAGSUN:VIND-DTPAGSUN) END-EXEC. */

            var r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1 = new R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1()
            {
                V0CFEN_CODEMP = V0CFEN_CODEMP.ToString(),
                V0CFEN_NUMBIL = V0CFEN_NUMBIL.ToString(),
                V0CFEN_AGECOBR = V0CFEN_AGECOBR.ToString(),
                V0CFEN_VALADT = V0CFEN_VALADT.ToString(),
                V0CFEN_DTCREDITO = V0CFEN_DTCREDITO.ToString(),
                V0CFEN_NRMATRVEN = V0CFEN_NRMATRVEN.ToString(),
                V0CFEN_AGECTAVEN = V0CFEN_AGECTAVEN.ToString(),
                V0CFEN_OPRCTAVEN = V0CFEN_OPRCTAVEN.ToString(),
                V0CFEN_NUMCTAVEN = V0CFEN_NUMCTAVEN.ToString(),
                V0CFEN_DIGCTAVEN = V0CFEN_DIGCTAVEN.ToString(),
                V0CFEN_AGECTADEB = V0CFEN_AGECTADEB.ToString(),
                V0CFEN_OPRCTADEB = V0CFEN_OPRCTADEB.ToString(),
                V0CFEN_NUMCTADEB = V0CFEN_NUMCTADEB.ToString(),
                V0CFEN_DIGCTADEB = V0CFEN_DIGCTADEB.ToString(),
                V0CFEN_SINDICO = V0CFEN_SINDICO.ToString(),
                V0CFEN_DTQITBCO = V0CFEN_DTQITBCO.ToString(),
                V0CFEN_VLRCAP = V0CFEN_VLRCAP.ToString(),
                V0CFEN_DTMOVTO = V0CFEN_DTMOVTO.ToString(),
                V0CFEN_SITUACAO = V0CFEN_SITUACAO.ToString(),
                V0CFEN_NRMATRGER = V0CFEN_NRMATRGER.ToString(),
                VIND_NRMATRGER = VIND_NRMATRGER.ToString(),
                V0CFEN_VALADTGER = V0CFEN_VALADTGER.ToString(),
                VIND_VALADTGER = VIND_VALADTGER.ToString(),
                V0CFEN_DTPAGGER = V0CFEN_DTPAGGER.ToString(),
                VIND_DTPAGGER = VIND_DTPAGGER.ToString(),
                V0CFEN_DTCANCEL = V0CFEN_DTCANCEL.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                V0CFEN_NRMATRSUN = V0CFEN_NRMATRSUN.ToString(),
                VIND_NRMATRSUN = VIND_NRMATRSUN.ToString(),
                V0CFEN_VALADTSUN = V0CFEN_VALADTSUN.ToString(),
                VIND_VALADTSUN = VIND_VALADTSUN.ToString(),
                V0CFEN_DTPAGSUN = V0CFEN_DTPAGSUN.ToString(),
                VIND_DTPAGSUN = VIND_DTPAGSUN.ToString(),
            };

            R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1.Execute(r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-INSERT-V0VENDASBIL-SECTION */
        private void R6200_00_INSERT_V0VENDASBIL_SECTION()
        {
            /*" -4159- MOVE '6200' TO WNR-EXEC-SQL. */
            _.Move("6200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4166- PERFORM R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1 */

            R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1();

            /*" -4169- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4171- DISPLAY 'R6200-00 - REGISTRO DUPLICADO     ' V0VEND-NUMBIL */
                _.Display($"R6200-00 - REGISTRO DUPLICADO     {V0VEND_NUMBIL}");

                /*" -4172- ELSE */
            }
            else
            {


                /*" -4173- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4174- DISPLAY 'R6200-00 - PROBLEMAS INSERT (V0VENDASBIL) ' */
                    _.Display($"R6200-00 - PROBLEMAS INSERT (V0VENDASBIL) ");

                    /*" -4174- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6200-00-INSERT-V0VENDASBIL-DB-INSERT-1 */
        public void R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1()
        {
            /*" -4166- EXEC SQL INSERT INTO SEGUROS.V0VENDAS_BILHETES VALUES (:V0VEND-NUMBIL , :V0VEND-AGECOBR , :V0VEND-DTQITBCO , :V0VEND-VLRCAP , :V0VEND-DTMOVTO) END-EXEC. */

            var r6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1 = new R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1()
            {
                V0VEND_NUMBIL = V0VEND_NUMBIL.ToString(),
                V0VEND_AGECOBR = V0VEND_AGECOBR.ToString(),
                V0VEND_DTQITBCO = V0VEND_DTQITBCO.ToString(),
                V0VEND_VLRCAP = V0VEND_VLRCAP.ToString(),
                V0VEND_DTMOVTO = V0VEND_DTMOVTO.ToString(),
            };

            R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1.Execute(r6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-TARIFA-BALCAO-SECTION */
        private void R6500_00_TARIFA_BALCAO_SECTION()
        {
            /*" -4187- MOVE '6500' TO WNR-EXEC-SQL. */
            _.Move("6500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4188- MOVE ZEROS TO V0TRBL-CODEMP */
            _.Move(0, V0TRBL_CODEMP);

            /*" -4189- MOVE 9999999 TO V0TRBL-MATRICULA */
            _.Move(9999999, V0TRBL_MATRICULA);

            /*" -4191- MOVE '5' TO V0TRBL-TIPOFUNC */
            _.Move("5", V0TRBL_TIPOFUNC);

            /*" -4193- MOVE AUX-TITSIVPF TO V0TRBL-NRCERTIF */
            _.Move(WS_AUX_ARQUIVO.AUX_USO_EMPRESA.AUX_TITSIVPF, V0TRBL_NRCERTIF);

            /*" -4194- MOVE V0SIST-DTMOVABE TO V0TRBL-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0TRBL_DTMOVTO);

            /*" -4195- MOVE CONVEN-CODPRODU TO V0TRBL-CODPRODU */
            _.Move(WS_AUX_ARQUIVO.CONVEN_CODPRODU, V0TRBL_CODPRODU);

            /*" -4196- MOVE '0' TO V0TRBL-SITUACAO */
            _.Move("0", V0TRBL_SITUACAO);

            /*" -4197- MOVE V0AVIS-BCOAVISO TO V0TRBL-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0TRBL_BCOAVISO);

            /*" -4198- MOVE V0AVIS-AGEAVISO TO V0TRBL-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0TRBL_AGEAVISO);

            /*" -4200- MOVE V0AVIS-NRAVISO TO V0TRBL-NRAVISO. */
            _.Move(V0AVIS_NRAVISO, V0TRBL_NRAVISO);

            /*" -4201- MOVE CONVEN-FONTE TO V0TRBL-FONTE */
            _.Move(WS_AUX_ARQUIVO.CONVEN_FONTE, V0TRBL_FONTE);

            /*" -4202- MOVE CONVEN-AGECOBR TO V0TRBL-AGECOBR */
            _.Move(WS_AUX_ARQUIVO.CONVEN_AGECOBR, V0TRBL_AGECOBR);

            /*" -4207- MOVE CONVEN-ESCNEG TO V0TRBL-ESCNEG. */
            _.Move(WS_AUX_ARQUIVO.CONVEN_ESCNEG, V0TRBL_ESCNEG);

            /*" -4208- MOVE COBRAN-DESPESAS TO V0TRBL-TARIFA */
            _.Move(COBRAN_REGISTRO.COBRAN_DESPESAS, V0TRBL_TARIFA);

            /*" -4211- MOVE COBRAN-ABATIMENTO TO V0TRBL-BALCAO. */
            _.Move(COBRAN_REGISTRO.COBRAN_ABATIMENTO, V0TRBL_BALCAO);

            /*" -4213- IF V0TRBL-BALCAO NOT EQUAL ZEROS OR V0TRBL-TARIFA NOT EQUAL ZEROS */

            if (V0TRBL_BALCAO != 00 || V0TRBL_TARIFA != 00)
            {

                /*" -4213- PERFORM R6700-00-INSERT-TARIFA-BALCAO. */

                R6700_00_INSERT_TARIFA_BALCAO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" R6700-00-INSERT-TARIFA-BALCAO-SECTION */
        private void R6700_00_INSERT_TARIFA_BALCAO_SECTION()
        {
            /*" -4226- MOVE '6700' TO WNR-EXEC-SQL. */
            _.Move("6700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4244- PERFORM R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1 */

            R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1();

            /*" -4247- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4248- DISPLAY 'R6700-00 - PROBLEMAS INSERT (TARIFA)     ' */
                _.Display($"R6700-00 - PROBLEMAS INSERT (TARIFA)     ");

                /*" -4248- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6700-00-INSERT-TARIFA-BALCAO-DB-INSERT-1 */
        public void R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1()
        {
            /*" -4244- EXEC SQL INSERT INTO SEGUROS.TARIFA_BALCAO_CEF VALUES (:V0TRBL-CODEMP , :V0TRBL-MATRICULA , :V0TRBL-TIPOFUNC , :V0TRBL-NRCERTIF , :V0TRBL-DTMOVTO , :V0TRBL-CODPRODU , :V0TRBL-SITUACAO , :V0TRBL-FONTE , :V0TRBL-ESCNEG , :V0TRBL-AGECOBR , :V0TRBL-BCOAVISO , :V0TRBL-AGEAVISO , :V0TRBL-NRAVISO , :V0TRBL-TARIFA , :V0TRBL-BALCAO , CURRENT TIMESTAMP) END-EXEC. */

            var r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1 = new R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1()
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

            R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1.Execute(r6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6700_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-ADIANTA-SECTION */
        private void R7000_00_TRATA_ADIANTA_SECTION()
        {
            /*" -4283- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4284- IF AD-VLRABIL EQUAL ZEROS */

            if (WS_AUX_ARQUIVO.AD_VLRABIL == 00)
            {

                /*" -4286- COMPUTE V0ADIA-VALADT EQUAL AD-QTDEBIL * 3,10 */
                V0ADIA_VALADT.Value = WS_AUX_ARQUIVO.AD_QTDEBIL * 3.10;

                /*" -4287- MOVE '4' TO V0ADIA-TIPO */
                _.Move("4", V0ADIA_TIPO);

                /*" -4288- ELSE */
            }
            else
            {


                /*" -4289- MOVE AD-VLRABIL TO V0ADIA-VALADT */
                _.Move(WS_AUX_ARQUIVO.AD_VLRABIL, V0ADIA_VALADT);

                /*" -4292- MOVE '5' TO V0ADIA-TIPO. */
                _.Move("5", V0ADIA_TIPO);
            }


            /*" -4293- MOVE 17256 TO V0ADIA-CODPDT */
            _.Move(17256, V0ADIA_CODPDT);

            /*" -4294- MOVE 10 TO V0ADIA-FONTE */
            _.Move(10, V0ADIA_FONTE);

            /*" -4295- MOVE V0AVIS-NRAVISO TO V0ADIA-NUMOPG */
            _.Move(V0AVIS_NRAVISO, V0ADIA_NUMOPG);

            /*" -4296- MOVE 1 TO V0ADIA-QTPRESTA */
            _.Move(1, V0ADIA_QTPRESTA);

            /*" -4300- MOVE ZEROS TO V0ADIA-NRPROPOS V0ADIA-NUMAPOL V0ADIA-NRENDOS V0ADIA-NRPARCEL */
            _.Move(0, V0ADIA_NRPROPOS, V0ADIA_NUMAPOL, V0ADIA_NRENDOS, V0ADIA_NRPARCEL);

            /*" -4301- MOVE V0SIST-DTMOVABE TO V0ADIA-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0ADIA_DTMOVTO);

            /*" -4302- MOVE '0' TO V0ADIA-SITUACAO */
            _.Move("0", V0ADIA_SITUACAO);

            /*" -4304- MOVE AD-QTDEBIL TO V0ADIA-CODEMP. */
            _.Move(WS_AUX_ARQUIVO.AD_QTDEBIL, V0ADIA_CODEMP);

            /*" -4308- MOVE ZEROS TO VIND-CODEMP VIND-TIPO. */
            _.Move(0, VIND_CODEMP, VIND_TIPO);

            /*" -4311- PERFORM R7100-00-INSERT-V0ADIANTA. */

            R7100_00_INSERT_V0ADIANTA_SECTION();

            /*" -4312- MOVE V0ADIA-CODPDT TO V0FREC-CODPDT */
            _.Move(V0ADIA_CODPDT, V0FREC_CODPDT);

            /*" -4313- MOVE V0ADIA-FONTE TO V0FREC-FONTE */
            _.Move(V0ADIA_FONTE, V0FREC_FONTE);

            /*" -4314- MOVE V0ADIA-NUMOPG TO V0FREC-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0FREC_NUMOPG);

            /*" -4315- MOVE V0ADIA-NRPROPOS TO V0FREC-NRPROPOS */
            _.Move(V0ADIA_NRPROPOS, V0FREC_NRPROPOS);

            /*" -4316- MOVE V0ADIA-NUMAPOL TO V0FREC-NUMAPOL */
            _.Move(V0ADIA_NUMAPOL, V0FREC_NUMAPOL);

            /*" -4317- MOVE V0ADIA-NRENDOS TO V0FREC-NRENDOS */
            _.Move(V0ADIA_NRENDOS, V0FREC_NRENDOS);

            /*" -4318- MOVE V0ADIA-NRPARCEL TO V0FREC-NRPARCEL */
            _.Move(V0ADIA_NRPARCEL, V0FREC_NRPARCEL);

            /*" -4319- MOVE 1 TO V0FREC-NUMPTC */
            _.Move(1, V0FREC_NUMPTC);

            /*" -4320- MOVE V0ADIA-VALADT TO V0FREC-VALRCP */
            _.Move(V0ADIA_VALADT, V0FREC_VALRCP);

            /*" -4321- MOVE ZEROS TO V0FREC-PCGACM */
            _.Move(0, V0FREC_PCGACM);

            /*" -4322- MOVE '0' TO V0FREC-SITUACAO */
            _.Move("0", V0FREC_SITUACAO);

            /*" -4323- MOVE V0ADIA-VALADT TO V0FREC-VALSDO */
            _.Move(V0ADIA_VALADT, V0FREC_VALSDO);

            /*" -4324- MOVE V0SIST-DTMOVABE TO V0FREC-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0FREC_DTMOVTO);

            /*" -4325- MOVE SPACES TO V0FREC-DTVENCTO */
            _.Move("", V0FREC_DTVENCTO);

            /*" -4327- MOVE V0ADIA-CODEMP TO V0FREC-CODEMP. */
            _.Move(V0ADIA_CODEMP, V0FREC_CODEMP);

            /*" -4328- MOVE ZEROS TO VIND-CODEMP */
            _.Move(0, VIND_CODEMP);

            /*" -4331- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -4334- PERFORM R7200-00-INSERT-V0FORMAREC. */

            R7200_00_INSERT_V0FORMAREC_SECTION();

            /*" -4335- MOVE V0ADIA-CODPDT TO V0HREC-CODPDT */
            _.Move(V0ADIA_CODPDT, V0HREC_CODPDT);

            /*" -4336- MOVE V0ADIA-FONTE TO V0HREC-FONTE */
            _.Move(V0ADIA_FONTE, V0HREC_FONTE);

            /*" -4337- MOVE V0ADIA-NUMOPG TO V0HREC-NUMOPG */
            _.Move(V0ADIA_NUMOPG, V0HREC_NUMOPG);

            /*" -4338- MOVE V0ADIA-NRPROPOS TO V0HREC-NRPROPOS */
            _.Move(V0ADIA_NRPROPOS, V0HREC_NRPROPOS);

            /*" -4339- MOVE V0ADIA-NUMAPOL TO V0HREC-NUMAPOL */
            _.Move(V0ADIA_NUMAPOL, V0HREC_NUMAPOL);

            /*" -4340- MOVE V0ADIA-NRENDOS TO V0HREC-NRENDOS */
            _.Move(V0ADIA_NRENDOS, V0HREC_NRENDOS);

            /*" -4341- MOVE V0ADIA-NRPARCEL TO V0HREC-NRPARCEL */
            _.Move(V0ADIA_NRPARCEL, V0HREC_NRPARCEL);

            /*" -4342- MOVE 1 TO V0HREC-NUMPTC */
            _.Move(1, V0HREC_NUMPTC);

            /*" -4343- MOVE V0ADIA-VALADT TO V0HREC-VALRCP */
            _.Move(V0ADIA_VALADT, V0HREC_VALRCP);

            /*" -4344- MOVE ZEROS TO V0HREC-NUMREC */
            _.Move(0, V0HREC_NUMREC);

            /*" -4345- MOVE V0SIST-DTMOVABE TO V0HREC-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0HREC_DTMOVTO);

            /*" -4346- MOVE 1401 TO V0HREC-OPERACAO */
            _.Move(1401, V0HREC_OPERACAO);

            /*" -4348- MOVE V0ADIA-CODEMP TO V0HREC-CODEMP. */
            _.Move(V0ADIA_CODEMP, V0HREC_CODEMP);

            /*" -4349- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUX_DATAS.WS_TIME);

            /*" -4350- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_HH_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_HORA);

            /*" -4351- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_2PT1);

            /*" -4352- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_MM_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_MINU);

            /*" -4353- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_2PT2);

            /*" -4354- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_AUX_DATAS.WS_TIME.WS_SS_TIME, WS_AUX_DATAS.FILLER_24.WTIME_DAYR.WTIME_SEGU);

            /*" -4356- MOVE WTIME-DAYR TO V0HREC-HORSIS. */
            _.Move(WS_AUX_DATAS.FILLER_24.WTIME_DAYR, V0HREC_HORSIS);

            /*" -4359- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -4359- PERFORM R7300-00-INSERT-V0HISTOREC. */

            R7300_00_INSERT_V0HISTOREC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-INSERT-V0ADIANTA-SECTION */
        private void R7100_00_INSERT_V0ADIANTA_SECTION()
        {
            /*" -4372- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4389- PERFORM R7100_00_INSERT_V0ADIANTA_DB_INSERT_1 */

            R7100_00_INSERT_V0ADIANTA_DB_INSERT_1();

            /*" -4393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4394- DISPLAY 'R7100-00 - PROBLEMAS NO INSERT(V0ADIANTA) ' */
                _.Display($"R7100-00 - PROBLEMAS NO INSERT(V0ADIANTA) ");

                /*" -4394- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7100-00-INSERT-V0ADIANTA-DB-INSERT-1 */
        public void R7100_00_INSERT_V0ADIANTA_DB_INSERT_1()
        {
            /*" -4389- EXEC SQL INSERT INTO SEGUROS.V0ADIANTA VALUES (:V0ADIA-CODPDT , :V0ADIA-FONTE , :V0ADIA-NUMOPG , :V0ADIA-VALADT , :V0ADIA-QTPRESTA , :V0ADIA-NRPROPOS , :V0ADIA-NUMAPOL , :V0ADIA-NRENDOS , :V0ADIA-NRPARCEL , :V0ADIA-DTMOVTO , :V0ADIA-SITUACAO , :V0ADIA-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0ADIA-TIPO:VIND-TIPO) END-EXEC. */

            var r7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1 = new R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1()
            {
                V0ADIA_CODPDT = V0ADIA_CODPDT.ToString(),
                V0ADIA_FONTE = V0ADIA_FONTE.ToString(),
                V0ADIA_NUMOPG = V0ADIA_NUMOPG.ToString(),
                V0ADIA_VALADT = V0ADIA_VALADT.ToString(),
                V0ADIA_QTPRESTA = V0ADIA_QTPRESTA.ToString(),
                V0ADIA_NRPROPOS = V0ADIA_NRPROPOS.ToString(),
                V0ADIA_NUMAPOL = V0ADIA_NUMAPOL.ToString(),
                V0ADIA_NRENDOS = V0ADIA_NRENDOS.ToString(),
                V0ADIA_NRPARCEL = V0ADIA_NRPARCEL.ToString(),
                V0ADIA_DTMOVTO = V0ADIA_DTMOVTO.ToString(),
                V0ADIA_SITUACAO = V0ADIA_SITUACAO.ToString(),
                V0ADIA_CODEMP = V0ADIA_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0ADIA_TIPO = V0ADIA_TIPO.ToString(),
                VIND_TIPO = VIND_TIPO.ToString(),
            };

            R7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1.Execute(r7100_00_INSERT_V0ADIANTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-INSERT-V0FORMAREC-SECTION */
        private void R7200_00_INSERT_V0FORMAREC_SECTION()
        {
            /*" -4407- MOVE '7200' TO WNR-EXEC-SQL. */
            _.Move("7200", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4426- PERFORM R7200_00_INSERT_V0FORMAREC_DB_INSERT_1 */

            R7200_00_INSERT_V0FORMAREC_DB_INSERT_1();

            /*" -4430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4431- DISPLAY 'R7200-00 - PROBLEMAS NO INSERT(V0FORMAREC)' */
                _.Display($"R7200-00 - PROBLEMAS NO INSERT(V0FORMAREC)");

                /*" -4431- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7200-00-INSERT-V0FORMAREC-DB-INSERT-1 */
        public void R7200_00_INSERT_V0FORMAREC_DB_INSERT_1()
        {
            /*" -4426- EXEC SQL INSERT INTO SEGUROS.V0FORMAREC VALUES (:V0FREC-CODPDT , :V0FREC-FONTE , :V0FREC-NUMOPG , :V0FREC-NRPROPOS , :V0FREC-NUMAPOL , :V0FREC-NRENDOS , :V0FREC-NRPARCEL , :V0FREC-NUMPTC , :V0FREC-VALRCP , :V0FREC-PCGACM , :V0FREC-SITUACAO , :V0FREC-VALSDO , :V0FREC-DTMOVTO , :V0FREC-DTVENCTO:VIND-DTVENCTO , :V0FREC-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1 = new R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1()
            {
                V0FREC_CODPDT = V0FREC_CODPDT.ToString(),
                V0FREC_FONTE = V0FREC_FONTE.ToString(),
                V0FREC_NUMOPG = V0FREC_NUMOPG.ToString(),
                V0FREC_NRPROPOS = V0FREC_NRPROPOS.ToString(),
                V0FREC_NUMAPOL = V0FREC_NUMAPOL.ToString(),
                V0FREC_NRENDOS = V0FREC_NRENDOS.ToString(),
                V0FREC_NRPARCEL = V0FREC_NRPARCEL.ToString(),
                V0FREC_NUMPTC = V0FREC_NUMPTC.ToString(),
                V0FREC_VALRCP = V0FREC_VALRCP.ToString(),
                V0FREC_PCGACM = V0FREC_PCGACM.ToString(),
                V0FREC_SITUACAO = V0FREC_SITUACAO.ToString(),
                V0FREC_VALSDO = V0FREC_VALSDO.ToString(),
                V0FREC_DTMOVTO = V0FREC_DTMOVTO.ToString(),
                V0FREC_DTVENCTO = V0FREC_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0FREC_CODEMP = V0FREC_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1.Execute(r7200_00_INSERT_V0FORMAREC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7300-00-INSERT-V0HISTOREC-SECTION */
        private void R7300_00_INSERT_V0HISTOREC_SECTION()
        {
            /*" -4444- MOVE '7300' TO WNR-EXEC-SQL. */
            _.Move("7300", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4462- PERFORM R7300_00_INSERT_V0HISTOREC_DB_INSERT_1 */

            R7300_00_INSERT_V0HISTOREC_DB_INSERT_1();

            /*" -4466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4467- DISPLAY 'R7300-00 - PROBLEMAS NO INSERT(V0HISTOREC)' */
                _.Display($"R7300-00 - PROBLEMAS NO INSERT(V0HISTOREC)");

                /*" -4467- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7300-00-INSERT-V0HISTOREC-DB-INSERT-1 */
        public void R7300_00_INSERT_V0HISTOREC_DB_INSERT_1()
        {
            /*" -4462- EXEC SQL INSERT INTO SEGUROS.V0HISTOREC VALUES (:V0HREC-CODPDT , :V0HREC-FONTE , :V0HREC-NUMOPG , :V0HREC-NRPROPOS , :V0HREC-NUMAPOL , :V0HREC-NRENDOS , :V0HREC-NRPARCEL , :V0HREC-NUMPTC , :V0HREC-VALRCP , :V0HREC-NUMREC , :V0HREC-DTMOVTO , :V0HREC-OPERACAO , :V0HREC-HORSIS , :V0HREC-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1 = new R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1()
            {
                V0HREC_CODPDT = V0HREC_CODPDT.ToString(),
                V0HREC_FONTE = V0HREC_FONTE.ToString(),
                V0HREC_NUMOPG = V0HREC_NUMOPG.ToString(),
                V0HREC_NRPROPOS = V0HREC_NRPROPOS.ToString(),
                V0HREC_NUMAPOL = V0HREC_NUMAPOL.ToString(),
                V0HREC_NRENDOS = V0HREC_NRENDOS.ToString(),
                V0HREC_NRPARCEL = V0HREC_NRPARCEL.ToString(),
                V0HREC_NUMPTC = V0HREC_NUMPTC.ToString(),
                V0HREC_VALRCP = V0HREC_VALRCP.ToString(),
                V0HREC_NUMREC = V0HREC_NUMREC.ToString(),
                V0HREC_DTMOVTO = V0HREC_DTMOVTO.ToString(),
                V0HREC_OPERACAO = V0HREC_OPERACAO.ToString(),
                V0HREC_HORSIS = V0HREC_HORSIS.ToString(),
                V0HREC_CODEMP = V0HREC_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1.Execute(r7300_00_INSERT_V0HISTOREC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7300_99_SAIDA*/

        [StopWatch]
        /*" R7500-00-UPDATE-V0CEDENTE-SECTION */
        private void R7500_00_UPDATE_V0CEDENTE_SECTION()
        {
            /*" -4479- MOVE '7500' TO WNR-EXEC-SQL. */
            _.Move("7500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4481- MOVE WWORK-MIN-NRTIT TO V0CEDE-NUMTIT. */
            _.Move(WS_AUX_ARQUIVO.WWORK_MIN_NRTIT, V0CEDE_NUMTIT);

            /*" -4485- PERFORM R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1 */

            R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1();

            /*" -4488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4489- DISPLAY 'R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' */
                _.Display($"R7500-00 - PROBLEMAS UPDATE (V0CEDENTE)   ");

                /*" -4489- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7500-00-UPDATE-V0CEDENTE-DB-UPDATE-1 */
        public void R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -4485- EXEC SQL UPDATE SEGUROS.V0CEDENTE SET NUMTIT = :V0CEDE-NUMTIT WHERE CODCDT = 26 END-EXEC. */

            var r7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 = new R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                V0CEDE_NUMTIT = V0CEDE_NUMTIT.ToString(),
            };

            R7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r7500_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-DESPESAS-SECTION */
        private void R8000_00_TRATA_DESPESAS_SECTION()
        {
            /*" -4502- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4503- MOVE ZEROS TO WS-SUBS. */
            _.Move(0, WS_AUX_ARQUIVO.WS_SUBS);

            /*" -4504- SET WS-PRO TO 1 */
            WS_PRO.Value = 1;

            /*" -4505- SEARCH WTABG-OCORREPRD */
            for (; WS_PRO < WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD.Items.Count; WS_PRO.Value++)
            {

                /*" -4507- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-PRO) */

                if (WSHOST_CODPRODU == WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU)
                {


                    /*" -4507- SET WS-SUBS TO WS-PRO  END-SEARCH. */
                    WS_AUX_ARQUIVO.WS_SUBS.Value = WS_PRO;
                    break;
                }
            }


            /*" -4513- IF WS-SUBS EQUAL ZEROS OR WS-SUBS GREATER 2000 */

            if (WS_AUX_ARQUIVO.WS_SUBS == 00 || WS_AUX_ARQUIVO.WS_SUBS > 2000)
            {

                /*" -4516- SET WS-PRO TO 1. */
                WS_PRO.Value = 1;
            }


            /*" -4516- PERFORM R8050-00-VERIFICA-TIPO. */

            R8050_00_VERIFICA_TIPO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8050-00-VERIFICA-TIPO-SECTION */
        private void R8050_00_VERIFICA_TIPO_SECTION()
        {
            /*" -4532- MOVE '8050' TO WNR-EXEC-SQL. */
            _.Move("8050", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4533- IF FLG-GRAFICA EQUAL 'S' */

            if (WS_AUX_ARQUIVO.FLG_GRAFICA == "S")
            {

                /*" -4534- SET WS-TIP TO 2 */
                WS_TIP.Value = 2;

                /*" -4538- ELSE */
            }
            else
            {


                /*" -4539- IF WSHOST-CODPRODU EQUAL ZEROS */

                if (WSHOST_CODPRODU == 00)
                {

                    /*" -4540- SET WS-TIP TO 4 */
                    WS_TIP.Value = 4;

                    /*" -4544- ELSE */
                }
                else
                {


                    /*" -4549- IF WSHOST-CODPRODU EQUAL 7106 OR 7108 OR 1402 OR 8201 OR 8202 */

                    if (WSHOST_CODPRODU.In("7106", "7108", "1402", "8201", "8202"))
                    {

                        /*" -4550- SET WS-TIP TO 1 */
                        WS_TIP.Value = 1;

                        /*" -4551- MOVE WSHOST-NRCERTIF TO V0BILH-NUMBIL */
                        _.Move(WSHOST_NRCERTIF, V0BILH_NUMBIL);

                        /*" -4552- PERFORM R8150-00-SELECT-V0BILHETE */

                        R8150_00_SELECT_V0BILHETE_SECTION();

                        /*" -4556- ELSE */
                    }
                    else
                    {


                        /*" -4562- SET WS-TIP TO 1. */
                        WS_TIP.Value = 1;
                    }

                }

            }


            /*" -4563- IF WSHOST-SITUACAO EQUAL '0' */

            if (WSHOST_SITUACAO == "0")
            {

                /*" -4564- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -4568- ELSE */
            }
            else
            {


                /*" -4571- SET WS-SIT TO 2. */
                WS_SIT.Value = 2;
            }


            /*" -4574- ADD 1 TO WTABG-QTDE(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -4577- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -4580- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -4583- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -4586- ADD WSHOST-VLIOCC TO WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -4587- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT). */
            WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

        [StopWatch]
        /*" R8150-00-SELECT-V0BILHETE-SECTION */
        private void R8150_00_SELECT_V0BILHETE_SECTION()
        {
            /*" -4599- MOVE '8150' TO WNR-EXEC-SQL. */
            _.Move("8150", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4605- PERFORM R8150_00_SELECT_V0BILHETE_DB_SELECT_1 */

            R8150_00_SELECT_V0BILHETE_DB_SELECT_1();

            /*" -4609- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4610- IF V0BILH-NUMAPOL NOT EQUAL ZEROS */

                if (V0BILH_NUMAPOL != 00)
                {

                    /*" -4610- SET WS-TIP TO 3. */
                    WS_TIP.Value = 3;
                }

            }


        }

        [StopWatch]
        /*" R8150-00-SELECT-V0BILHETE-DB-SELECT-1 */
        public void R8150_00_SELECT_V0BILHETE_DB_SELECT_1()
        {
            /*" -4605- EXEC SQL SELECT NUM_APOL_ANTERIOR INTO :V0BILH-NUMAPOL FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V0BILH-NUMBIL WITH UR END-EXEC. */

            var r8150_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 = new R8150_00_SELECT_V0BILHETE_DB_SELECT_1_Query1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            var executed_1 = R8150_00_SELECT_V0BILHETE_DB_SELECT_1_Query1.Execute(r8150_00_SELECT_V0BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_NUMAPOL, V0BILH_NUMAPOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8150_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-GRAVA-DESPESAS-SECTION */
        private void R8500_00_GRAVA_DESPESAS_SECTION()
        {
            /*" -4623- MOVE '8500' TO WNR-EXEC-SQL. */
            _.Move("8500", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4624- IF WTABG-CODPRODU(WS-PRO) EQUAL 9999 */

            if (WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU == 9999)
            {

                /*" -4625- SET WS-PRO UP BY 1 */
                WS_PRO.Value += 1;

                /*" -4628- GO TO R8500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4631- MOVE WTABG-CODPRODU(WS-PRO) TO V0DPCF-CODPRODU. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_CODPRODU, V0DPCF_CODPRODU);

            /*" -4632- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -4633- MOVE V0AVIS-BCOAVISO TO V0DPCF-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0DPCF_BCOAVISO);

            /*" -4634- MOVE V0AVIS-AGEAVISO TO V0DPCF-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0DPCF_AGEAVISO);

            /*" -4635- MOVE V0AVIS-NRAVISO TO V0DPCF-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0DPCF_NRAVISO);

            /*" -4636- MOVE '0' TO V0DPCF-TIPOCOB */
            _.Move("0", V0DPCF_TIPOCOB);

            /*" -4637- MOVE V0AVIS-DTMOVTO TO V0DPCF-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0DPCF_DTMOVTO);

            /*" -4638- MOVE V0AVIS-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0DPCF_DTAVISO);

            /*" -4641- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -4642- MOVE V0AVIS-DTAVISO TO WDATA-REL */
            _.Move(V0AVIS_DTAVISO, WS_AUX_DATAS.WDATA_REL);

            /*" -4643- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -4646- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -4647- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -4650- PERFORM R8550-00-GRAVA-TIPO 05 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R8550_00_GRAVA_TIPO_SECTION();

            }

            /*" -4650- SET WS-PRO UP BY 1. */
            WS_PRO.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-TIPO-SECTION */
        private void R8550_00_GRAVA_TIPO_SECTION()
        {
            /*" -4663- MOVE '8550' TO WNR-EXEC-SQL. */
            _.Move("8550", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4667- MOVE WTABG-TIPO(WS-PRO WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -4668- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -4671- PERFORM R8600-00-GRAVA-REGISTRO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R8600_00_GRAVA_REGISTRO_SECTION();

            }

            /*" -4671- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-GRAVA-REGISTRO-SECTION */
        private void R8600_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -4684- MOVE '8600' TO WNR-EXEC-SQL. */
            _.Move("8600", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4686- MOVE WTABG-SITUACAO(WS-PRO WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -4688- MOVE WTABG-QTDE(WS-PRO WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -4690- MOVE WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -4692- MOVE WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -4694- MOVE WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -4696- MOVE WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -4700- MOVE WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -4707- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT - V0DPCF-VLTARIFA - V0DPCF-VLBALCAO - V0DPCF-VLIOCC - V0DPCF-VLDESCON - V0DPCF-VLJUROS - V0DPCF-VLMULTA). */
            V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT - V0DPCF_VLTARIFA - V0DPCF_VLBALCAO - V0DPCF_VLIOCC - V0DPCF_VLDESCON - V0DPCF_VLJUROS - V0DPCF_VLMULTA);

            /*" -4712- IF V0DPCF-QTDREG EQUAL ZEROS AND V0DPCF-VLPRMTOT EQUAL ZEROS AND V0DPCF-VLPRMLIQ EQUAL ZEROS AND V0DPCF-VLTARIFA EQUAL ZEROS AND V0DPCF-VLBALCAO EQUAL ZEROS */

            if (V0DPCF_QTDREG == 00 && V0DPCF_VLPRMTOT == 00 && V0DPCF_VLPRMLIQ == 00 && V0DPCF_VLTARIFA == 00 && V0DPCF_VLBALCAO == 00)
            {

                /*" -4713- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -4716- GO TO R8600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4719- PERFORM R8700-00-INSERT-DESPESAS. */

            R8700_00_INSERT_DESPESAS_SECTION();

            /*" -4728- MOVE ZEROS TO WTABG-QTDE(WS-PRO WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRO WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRO WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRO WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRO WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRO WS-TIP WS-SIT). */
            _.Move(0, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, WS_AGENCIACEF.WS_PRODUTOSIVPF.AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRO].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -4728- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-SECTION */
        private void R8700_00_INSERT_DESPESAS_SECTION()
        {
            /*" -4741- MOVE '8700' TO WNR-EXEC-SQL. */
            _.Move("8700", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4787- PERFORM R8700_00_INSERT_DESPESAS_DB_INSERT_1 */

            R8700_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -4791- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4792- DISPLAY 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"R8700-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -4793- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4794- ELSE */
            }
            else
            {


                /*" -4794- ADD 1 TO AC-INSERT. */
                WS_AUX_ARQUIVO.AC_INSERT.Value = WS_AUX_ARQUIVO.AC_INSERT + 1;
            }


        }

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R8700_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -4787- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA, ANO_REFERENCIA, MES_REFERENCIA, BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, COD_PRODUTO, TIPO_REGISTRO, SITUACAO, TIPO_COBRANCA, DATA_MOVIMENTO, DATA_AVISO, QTD_REGISTROS, PRM_TOTAL, PRM_LIQUIDO, VAL_TARIFA, VAL_BALCAO, VAL_IOCC, VAL_DESCONTO, VAL_JUROS, VAL_MULTA, TIMESTAMP) VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
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

            R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/

        [StopWatch]
        /*" R8800-00-TRATA-AZULCAR-SECTION */
        private void R8800_00_TRATA_AZULCAR_SECTION()
        {
            /*" -4810- MOVE '8800' TO WNR-EXEC-SQL. */
            _.Move("8800", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4811- MOVE ZEROS TO V0SICB-CODEMP */
            _.Move(0, V0SICB_CODEMP);

            /*" -4812- MOVE V0RCAP-FONTE TO V0SICB-FONTE */
            _.Move(V0RCAP_FONTE, V0SICB_FONTE);

            /*" -4813- MOVE V0RCAP-NRRCAP TO V0SICB-NRRCAP */
            _.Move(V0RCAP_NRRCAP, V0SICB_NRRCAP);

            /*" -4814- MOVE ZEROS TO V0SICB-NUMBIL */
            _.Move(0, V0SICB_NUMBIL);

            /*" -4815- MOVE COBRAN-AGE-COBRAN TO V0SICB-AGECOBR */
            _.Move(COBRAN_REGISTRO.FILLER_45.COBRAN_AGE_COBRAN, V0SICB_AGECOBR);

            /*" -4816- MOVE COBRAN-MATR-INDIC TO V0SICB-NRMATRVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_MATR_INDIC, V0SICB_NRMATRVEN);

            /*" -4817- MOVE COBRAN-AGE-INDIC TO V0SICB-AGECTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_AGE_INDIC, V0SICB_AGECTAVEN);

            /*" -4818- MOVE COBRAN-OPER-INDIC TO V0SICB-OPRCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_OPER_INDIC, V0SICB_OPRCTAVEN);

            /*" -4819- MOVE COBRAN-CC-INDIC TO V0SICB-NUMCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_CC_INDIC, V0SICB_NUMCTAVEN);

            /*" -4820- MOVE COBRAN-DIG-INDIC TO V0SICB-DIGCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_DIG_INDIC, V0SICB_DIGCTAVEN);

            /*" -4821- MOVE COBRAN-DESC-CONCED TO V0SICB-VLCOMIS */
            _.Move(COBRAN_REGISTRO.COBRAN_DESC_CONCED, V0SICB_VLCOMIS);

            /*" -4822- MOVE V0SIST-DTMOVABE TO V0SICB-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0SICB_DTMOVTO);

            /*" -4823- MOVE COBRAN-VLR-PRINC TO V0SICB-VLRCAP */
            _.Move(COBRAN_REGISTRO.COBRAN_VLR_PRINC, V0SICB_VLRCAP);

            /*" -4830- MOVE ' ' TO V0SICB-SITUACAO. */
            _.Move(" ", V0SICB_SITUACAO);

            /*" -4832- MOVE CONVEN-DATA-CRED TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATA_CRED, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4833- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4834- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4835- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4836- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4843- MOVE WDATA-TABELA TO V0SICB-DTCREDITO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0SICB_DTCREDITO);

            /*" -4845- MOVE CONVEN-DATAOCORREN TO WDATA-SECULO */
            _.Move(WS_AUX_ARQUIVO.CONVEN_DATAOCORREN, WS_AUX_DATAS.WDATA_SECULO);

            /*" -4846- MOVE WDAT-SEC-DIA TO WDAT-TAB-DIA */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_DIA, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_DIA);

            /*" -4847- MOVE WDAT-SEC-MES TO WDAT-TAB-MES */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_MES, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_MES);

            /*" -4848- MOVE WDAT-SEC-ANO TO WDAT-TAB-ANO */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_ANO, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_ANO);

            /*" -4849- MOVE WDAT-SEC-SEC TO WDAT-TAB-SEC */
            _.Move(WS_AUX_DATAS.FILLER_20.WDAT_SEC_SEC, WS_AUX_DATAS.WDATA_TABELA.WDAT_TAB_SEC);

            /*" -4852- MOVE WDATA-TABELA TO V0SICB-DTQITBCO. */
            _.Move(WS_AUX_DATAS.WDATA_TABELA, V0SICB_DTQITBCO);

            /*" -4856- COMPUTE V0AVIS-VALADT EQUAL V0AVIS-VALADT + COBRAN-DESC-CONCED. */
            V0AVIS_VALADT.Value = V0AVIS_VALADT + COBRAN_REGISTRO.COBRAN_DESC_CONCED;

            /*" -4862- PERFORM R8850-00-INSERT-V0COMISICOB. */

            R8850_00_INSERT_V0COMISICOB_SECTION();

            /*" -4863- MOVE 9999999 TO V0SICB-NRMATRVEN */
            _.Move(9999999, V0SICB_NRMATRVEN);

            /*" -4864- MOVE COBRAN-AGE-INDIC TO V0SICB-AGECTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_AGE_INDIC, V0SICB_AGECTAVEN);

            /*" -4865- MOVE COBRAN-OPER-INDIC TO V0SICB-OPRCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_OPER_INDIC, V0SICB_OPRCTAVEN);

            /*" -4866- MOVE COBRAN-CC-INDIC TO V0SICB-NUMCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_CC_INDIC, V0SICB_NUMCTAVEN);

            /*" -4867- MOVE COBRAN-DIG-INDIC TO V0SICB-DIGCTAVEN */
            _.Move(COBRAN_REGISTRO.FILLER_46.COBRAN_DIG_INDIC, V0SICB_DIGCTAVEN);

            /*" -4868- MOVE COBRAN-DESPESAS TO V0SICB-VLCOMIS */
            _.Move(COBRAN_REGISTRO.COBRAN_DESPESAS, V0SICB_VLCOMIS);

            /*" -4870- ADD COBRAN-ABATIMENTO TO V0SICB-VLCOMIS. */
            V0SICB_VLCOMIS.Value = V0SICB_VLCOMIS + COBRAN_REGISTRO.COBRAN_ABATIMENTO;

            /*" -4870- PERFORM R8850-00-INSERT-V0COMISICOB. */

            R8850_00_INSERT_V0COMISICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" R8850-00-INSERT-V0COMISICOB-SECTION */
        private void R8850_00_INSERT_V0COMISICOB_SECTION()
        {
            /*" -4881- MOVE '8850' TO WNR-EXEC-SQL. */
            _.Move("8850", WS_AUX_AVISO.WABEND.WNR_EXEC_SQL);

            /*" -4900- PERFORM R8850_00_INSERT_V0COMISICOB_DB_INSERT_1 */

            R8850_00_INSERT_V0COMISICOB_DB_INSERT_1();

            /*" -4903- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4904- DISPLAY 'R8850-00 - PROBLEMAS INSERT (V0COMISICOB)' */
                _.Display($"R8850-00 - PROBLEMAS INSERT (V0COMISICOB)");

                /*" -4904- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8850-00-INSERT-V0COMISICOB-DB-INSERT-1 */
        public void R8850_00_INSERT_V0COMISICOB_DB_INSERT_1()
        {
            /*" -4900- EXEC SQL INSERT INTO SEGUROS.V0COMIS_SICOB VALUES (:V0SICB-CODEMP , :V0SICB-FONTE , :V0SICB-NRRCAP , :V0SICB-NUMBIL , :V0SICB-AGECOBR , :V0SICB-NRMATRVEN , :V0SICB-AGECTAVEN , :V0SICB-OPRCTAVEN , :V0SICB-NUMCTAVEN , :V0SICB-DIGCTAVEN , :V0SICB-VLCOMIS , :V0SICB-DTCREDITO , :V0SICB-DTQITBCO , :V0SICB-DTMOVTO , :V0SICB-VLRCAP , :V0SICB-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1 = new R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1()
            {
                V0SICB_CODEMP = V0SICB_CODEMP.ToString(),
                V0SICB_FONTE = V0SICB_FONTE.ToString(),
                V0SICB_NRRCAP = V0SICB_NRRCAP.ToString(),
                V0SICB_NUMBIL = V0SICB_NUMBIL.ToString(),
                V0SICB_AGECOBR = V0SICB_AGECOBR.ToString(),
                V0SICB_NRMATRVEN = V0SICB_NRMATRVEN.ToString(),
                V0SICB_AGECTAVEN = V0SICB_AGECTAVEN.ToString(),
                V0SICB_OPRCTAVEN = V0SICB_OPRCTAVEN.ToString(),
                V0SICB_NUMCTAVEN = V0SICB_NUMCTAVEN.ToString(),
                V0SICB_DIGCTAVEN = V0SICB_DIGCTAVEN.ToString(),
                V0SICB_VLCOMIS = V0SICB_VLCOMIS.ToString(),
                V0SICB_DTCREDITO = V0SICB_DTCREDITO.ToString(),
                V0SICB_DTQITBCO = V0SICB_DTQITBCO.ToString(),
                V0SICB_DTMOVTO = V0SICB_DTMOVTO.ToString(),
                V0SICB_VLRCAP = V0SICB_VLRCAP.ToString(),
                V0SICB_SITUACAO = V0SICB_SITUACAO.ToString(),
            };

            R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1.Execute(r8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8850_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -4915- DISPLAY ' ' */
            _.Display($" ");

            /*" -4916- DISPLAY 'PF0003B - FIM NORMAL' . */
            _.Display($"PF0003B - FIM NORMAL");

            /*" -4917- DISPLAY ' ' */
            _.Display($" ");

            /*" -4918- DISPLAY 'LIDOS COBRANCA ........ ' LD-COBRANCA */
            _.Display($"LIDOS COBRANCA ........ {WS_AUX_ARQUIVO.LD_COBRANCA}");

            /*" -4919- DISPLAY 'DESPREZADOS COBRANCA .. ' DP-COBRANCA */
            _.Display($"DESPREZADOS COBRANCA .. {WS_AUX_ARQUIVO.DP_COBRANCA}");

            /*" -4920- DISPLAY 'OUTRAS COBRANCAS ...... ' NP-COBRANCA */
            _.Display($"OUTRAS COBRANCAS ...... {WS_AUX_ARQUIVO.NP_COBRANCA}");

            /*" -4921- DISPLAY 'MOVIMENTO   COBRANCA .. ' DE-COBRANCA */
            _.Display($"MOVIMENTO   COBRANCA .. {WS_AUX_ARQUIVO.DE_COBRANCA}");

            /*" -4922- DISPLAY ' ' */
            _.Display($" ");

            /*" -4923- DISPLAY 'CONVERSAO SIVPF ....... ' IN-CONVERSAO */
            _.Display($"CONVERSAO SIVPF ....... {WS_AUX_ARQUIVO.IN_CONVERSAO}");

            /*" -4924- DISPLAY 'COBRANCA GRAFICA ...... ' AC-GRAFICA */
            _.Display($"COBRANCA GRAFICA ...... {WS_AUX_ARQUIVO.AC_GRAFICA}");

            /*" -4925- DISPLAY 'COBRANCA GRAFICA (DP) . ' DP-GRAFICA */
            _.Display($"COBRANCA GRAFICA (DP) . {WS_AUX_ARQUIVO.DP_GRAFICA}");

            /*" -4926- DISPLAY 'SALVA TITULO ZERO ..... ' AC-SALVA */
            _.Display($"SALVA TITULO ZERO ..... {WS_AUX_ARQUIVO.AC_SALVA}");

            /*" -4927- DISPLAY ' ' */
            _.Display($" ");

            /*" -4928- DISPLAY 'V0RCAP ................ ' IN-V0RCAP */
            _.Display($"V0RCAP ................ {WS_AUX_ARQUIVO.IN_V0RCAP}");

            /*" -4929- DISPLAY 'V0FOLLOWUP ............ ' IN-FOLLOWUP */
            _.Display($"V0FOLLOWUP ............ {WS_AUX_ARQUIVO.IN_FOLLOWUP}");

            /*" -4930- DISPLAY ' ' */
            _.Display($" ");

            /*" -4931- DISPLAY 'INSERT DESPESAS ....... ' AC-INSERT */
            _.Display($"INSERT DESPESAS ....... {WS_AUX_ARQUIVO.AC_INSERT}");

            /*" -4932- DISPLAY ' ' */
            _.Display($" ");

            /*" -4933- DISPLAY 'TRATA OPCAO VIDAZUL ... ' TT-OPCAO */
            _.Display($"TRATA OPCAO VIDAZUL ... {WS_AUX_ARQUIVO.TT_OPCAO}");

            /*" -4934- DISPLAY 'DESPR OPCAO VIDAZUL ... ' DP-OPCAO */
            _.Display($"DESPR OPCAO VIDAZUL ... {WS_AUX_ARQUIVO.DP_OPCAO}");

            /*" -4935- DISPLAY ' ' */
            _.Display($" ");

            /*" -4938- DISPLAY 'PF0003B - FIM NORMAL' . */
            _.Display($"PF0003B - FIM NORMAL");

            /*" -4940- CLOSE MOVIMENTO-COBRANCA. */
            MOVIMENTO_COBRANCA.Close();

            /*" -4940- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -4944- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -4944- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9800_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -4952- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_DATAS.WDATA_REL);

            /*" -4953- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_DIA, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -4954- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_MES, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -4957- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_ANO, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -4958- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4959- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4960- DISPLAY '*   PF0003B - PROCESSA FILE RETORNO SIVPF  *' */
            _.Display($"*   PF0003B - PROCESSA FILE RETORNO SIVPF  *");

            /*" -4961- DISPLAY '*   -------   -------- ---- ------- -----  *' */
            _.Display($"*   -------   -------- ---- ------- -----  *");

            /*" -4962- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4963- DISPLAY '*    NAO HOUVE MOVIMENTACAO NESTA DATA     *' */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NESTA DATA     *");

            /*" -4965- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {WS_AUX_DATAS.WDAT_REL_LIT}                   *"
            .Display();

            /*" -4966- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4966- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-COM-ERRO-SECTION */
        private void R9900_00_ENCERRA_COM_ERRO_SECTION()
        {
            /*" -4978- MOVE V0SIST-DTMOVABE TO WDATA-REL */
            _.Move(V0SIST_DTMOVABE, WS_AUX_DATAS.WDATA_REL);

            /*" -4979- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_DIA, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -4980- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_MES, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -4983- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(WS_AUX_DATAS.FILLER_13.WDAT_REL_ANO, WS_AUX_DATAS.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -4984- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4985- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4986- DISPLAY '*   PF0003B - PROCESSA FILE RETORNO SIVPF  *' */
            _.Display($"*   PF0003B - PROCESSA FILE RETORNO SIVPF  *");

            /*" -4987- DISPLAY '*   -------   -------- ---- ------- -----  *' */
            _.Display($"*   -------   -------- ---- ------- -----  *");

            /*" -4988- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4989- DISPLAY '*    PROCESSAMENTO COM ERRO NESTA DATA     *' */
            _.Display($"*    PROCESSAMENTO COM ERRO NESTA DATA     *");

            /*" -4991- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {WS_AUX_DATAS.WDAT_REL_LIT}                   *"
            .Display();

            /*" -4992- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4994- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -4995- DISPLAY '*' . */
            _.Display($"*");

            /*" -5003- DISPLAY 'PF0003B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"PF0003B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -5005- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -5007- CLOSE MOVIMENTO-COBRANCA. */
            MOVIMENTO_COBRANCA.Close();

            /*" -5007- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5011- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5011- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5019- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WS_AUX_AVISO.WABEND.WSQLCODE);

            /*" -5020- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WS_AUX_AVISO.WABEND.WSQLERRD1);

            /*" -5021- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WS_AUX_AVISO.WABEND.WSQLERRD2);

            /*" -5023- DISPLAY WABEND. */
            _.Display(WS_AUX_AVISO.WABEND);

            /*" -5025- CLOSE MOVIMENTO-COBRANCA. */
            MOVIMENTO_COBRANCA.Close();

            /*" -5025- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5029- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5029- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}