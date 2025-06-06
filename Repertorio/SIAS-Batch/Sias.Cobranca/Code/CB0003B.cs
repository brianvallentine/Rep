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
using Sias.Cobranca.DB2.CB0003B;

namespace Code
{
    public class CB0003B
    {
        public bool IsCall { get; set; }

        public CB0003B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0003B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1993                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  BAIXA MOVIMENTO COBRANCA DIARIA    *      */
        /*"      *                             UTILIZA NOTAS DE CREDITO           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  * VERSAO 07...: DEMANDA 323720                                   *      */
        /*"      *               INSERIR COD_USUARIO NA PARCELA_HISTORICO         *      */
        /*"      * DATA .......: 23/05/2022                                       *      */
        /*"      * RESPONSAVEL.: ELIERMES OLIVEIRA                                *      */
        /*"      *                                                   PROCURE V.07 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  * ALTERADO EM 22/04/2020 - HERVAL SOUZA                          *      */
        /*"JV01  *                                                                *      */
        /*"      * TAREFA 242124:   RESOLVER ABEND -811 NA TABELA                 *      */
        /*"      *                 PARAMETROS_GERAIS, DEVIDO A CVP.  'JV01'       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * ALTERADO EM 15/02/2018 - LISIANE BRAGANCA SOARES               *      */
        /*"      *                                                                *      */
        /*"      * CADMUS 157310 - VALIDAR VALOR DE MULTA E JUROS PARA RETORNO    *      */
        /*"      *                 DE PAGAMENTO DOS PRODUTOS AUTO                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * ALTERADO EM 14/08/2017 - CLOVIS                 -  V.04        *      */
        /*"      * QUANDO NAO ENCONTRAR TITULO NA TABELA SEGUROS.PARCELAS         *      */
        /*"      * BUSCA REGISTRO NA TABELA SEGUROS.GE_CONTROLE_EMISSAO_SIGCB     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * ALTERADO EM 30/09/2011 - CLOVIS                 -  V.03        *      */
        /*"      * VERIFICA SE VENCIMENTO DIA UTIL - CADMUS 61764                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * ALTERADO EM 13/09/2011 - CLOVIS                 -  V.02        *      */
        /*"      * ATENDIMENTO DO PROJETO AUTO SAS - CADMUS 59702                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * ALTERADO EM 26/07/2011 - CLOVIS                 -  V.01        *      */
        /*"      * ATENDIMENTO DO PROJETO AUTO SAS - CADMUS 59702                 *      */
        /*"      * PERMITIR QUE AS PARCELAS PAGAS DE FORMA INVERTIDA              *      */
        /*"      * (AUTO-SAS), SEJAM CADASTRADAS EM FOLLOW-UP.                    *      */
        /*"      * EXEMPLO:                                                       *      */
        /*"      * SE O SEGURADO PAGAR A TERCEIRA PARCELA E A SEGUNDA ESTIVER     *      */
        /*"      * PENDENTE, CADASTRAR O REGISTRO EM FOLLOW-UP, OU SEJA,          *      */
        /*"      * SE EXISTIR PARCELA ANTERIOR PENDENTE, NAO EFETUAR A BAIXA.     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO                 CLOVIS  08/05/2007                 *      */
        /*"      *                             CONFORME SOLICITADO ATRAVES DA     *      */
        /*"      *                             SSI 12294/2006, QUANDO NUMERO      *      */
        /*"      *                             DO TITULO ESTIVER NA FAIXA         *      */
        /*"      *                             3100000000000 A 3199999999999      *      */
        /*"      *                             E NAO ESTIVER CADASTRADO NA TABELA *      */
        /*"      *                             PARCELA ALTERAR O PREFIXO 31 PARA  *      */
        /*"      *                             55 E VERIFICAR SE EXISTE.          *      */
        /*"      *                             A MAPFRE ESTA GERANDO SEGUNDA VIA  *      */
        /*"      *                             SEM OBEDECER A NUMERACAO CORRETA.  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * COTACAO MOEDAS                      V1MOEDA           INPUT    *      */
        /*"      * MOVIMENTO COBRANCA                  V1MOVICOB         INPUT    *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         I-O      *      */
        /*"      * PARCELAS                            V1PARCELA         I-O      *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       I-O      *      */
        /*"      * NOTAS DE CREDITO                    V1NOTASCRED       INPUT    *      */
        /*"      * PARCELA_DEVEDOR                     V0PARCELA_DEVEDOR INPUT    *      */
        /*"      * HISTORICO DE NOTAS DE CREDITO       V0HISTNOTCRE      I-O      *      */
        /*"      * SALDO DE AVISOS                     V0AVISOS_SALDOS   OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4           07/06/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           07/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-FLAG-AUTO                PIC 9(01)        VALUE ZEROS.*/
        public IntBasis WS_FLAG_AUTO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77 WS-QT-REG                   PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis WS_QT_REG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-QTD-DIAS                 PIC S9(04)       VALUE +0 COMP.*/
        public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-VL-JUROS                 PIC S9(13)V9(04) VALUE +0 COMP-3.*/
        public DoubleBasis WS_VL_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4);
        /*"77 WS-VL-MULTA                 PIC S9(13)V9(04) VALUE +0 COMP-3.*/
        public DoubleBasis WS_VL_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(04)"), 4);
        /*"77           WHOST-COD-MOEDA   PIC S9(004)                COMP.*/
        public IntBasis WHOST_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WHOST-QTDDOC      PIC S9(004)                COMP.*/
        public IntBasis WHOST_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WHOST-DTINIVIG    PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WHOST-DTTERVIG    PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W1HISP-DTVENCTO   PIC  X(010).*/
        public StringBasis W1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           W1MCOB-SITUACAO   PIC  X(001).*/
        public StringBasis W1MCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           W1MCOB-NOME       PIC  X(040).*/
        public StringBasis W1MCOB_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           AC-LIDOS          PIC S9(007)      VALUE +0 COMP-3.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
        /*"77           WOCORHIST         PIC S9(004)                COMP.*/
        public IntBasis WOCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           W0-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W0-VAL-DES        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W0-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W0-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W0-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W0-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W0-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W0_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VAL-DES        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W1_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-VAL-DES        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W2-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W2_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-PRM-TAR        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-VAL-DES        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-VLPRMLIQ       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-VLADIFRA       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-VLCUSEMI       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-VLIOCC         PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W3-VLPRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis W3_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           W1-VALCREDR       PIC S9(013)V99 VALUE +0   COMP-3.*/
        public DoubleBasis W1_VALCREDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         VIND-DATA-SORT      PIC S9(004)                COMP.*/
        public IntBasis VIND_DATA_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DATARCAP       PIC S9(004)                COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)                COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)                COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ISENTA-CST     PIC S9(004)                COMP.*/
        public IntBasis VIND_ISENTA_CST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODPRODU       PIC S9(004)                COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-QUANTIDADE     PIC S9(004)                COMP.*/
        public IntBasis VIND_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         SQL-VALCREDR        PIC S9(004)                COMP.*/
        public IntBasis SQL_VALCREDR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1-COUNT            PIC S9(004)                COMP.*/
        public IntBasis W1_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PARM-DIFPRM       PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1PARM_DIFPRM { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARM-CODUNIMO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARM_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-VGAPC   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-VG      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-AP      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-SAUDE   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARR-RAMO-EDUCA   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PARR_RAMO_EDUCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-CODUNIMO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1MOED_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-VLCRUZAD     PIC S9(006)V9(9) VALUE +0  COMP-3*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1MOED-DTINIVIG     PIC  X(010).*/
        public StringBasis V1MOED_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MOED-DTTERVIG     PIC  X(010).*/
        public StringBasis V1MOED_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MCOB-COD-EMP      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MCOB-CODMOV       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_CODMOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MCOB-BANCO        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MCOB-AGENCIA      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MCOB-NRAVISO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MCOB-NUMFITA      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_NUMFITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MCOB-DTMOVTO      PIC  X(010).*/
        public StringBasis V1MCOB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MCOB-DTQITBCO     PIC  X(010).*/
        public StringBasis V1MCOB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MCOB-NRTIT        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1MCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1MCOB-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1MCOB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1MCOB-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1MCOB-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1MCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MCOB-VALTIT       PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1MCOB_VALTIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1MCOB-VLIOCC       PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1MCOB_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1MCOB-VALCDT       PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1MCOB_VALCDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1MCOB-SITUACAO     PIC  X(001).*/
        public StringBasis V1MCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1MCOB-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1MCOB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1MCOB-NOME         PIC  X(040).*/
        public StringBasis V1MCOB_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1MCOB-NUM-NOSSO    PIC S9(016)      VALUE +0  COMP-3*/
        public IntBasis V1MCOB_NUM_NOSSO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77         V0MCOB-NRTIT        PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0MCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ASAL-COD-EMP      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1ASAL_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ASAL-BCOAVISO     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ASAL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ASAL-AGEAVISO     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ASAL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ASAL-TIPSGU       PIC  X(001)    VALUE  SPACES.*/
        public StringBasis V1ASAL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1ASAL-NRAVISO      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1ASAL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ASAL-DTAVISO      PIC  X(010)    VALUE  SPACES.*/
        public StringBasis V1ASAL_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1ASAL-DTMOVTO      PIC  X(010)    VALUE  SPACES.*/
        public StringBasis V1ASAL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1ASAL-SDOATU       PIC S9(013)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1ASAL_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ASAL-SITUACAO     PIC  X(001)    VALUE  SPACES.*/
        public StringBasis V1ASAL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1NOTA-NRENDOSR     PIC S9(009)       VALUE +0   COMP*/
        public IntBasis V1NOTA_NRENDOSR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1NOTA-NRPARCELR    PIC S9(004)       VALUE +0   COMP*/
        public IntBasis V1NOTA_NRPARCELR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1NOTA-DTVENCTO     PIC  X(010).*/
        public StringBasis V1NOTA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1NOTA-VALCREDR-IX  PIC S9(010)V9(05) VALUE +0 COMP-3*/
        public DoubleBasis V1NOTA_VALCREDR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         HNOTCRE-COD-EMP     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis HNOTCRE_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         HNOTCRE-OCORHIST    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis HNOTCRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         HNOTCRE-OPERACAO    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis HNOTCRE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         HNOTCRE-HORAOPER    PIC  X(008).*/
        public StringBasis HNOTCRE_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         HNOTCRE-SITCONTB    PIC  X(001).*/
        public StringBasis HNOTCRE_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         HNOTCRE-VALCREDR    PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis HNOTCRE_VALCREDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         HNOTCRE-VLPAGTO     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis HNOTCRE_VLPAGTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         HNOTCRE-NUMCHQ      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis HNOTCRE_NUMCHQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-CODCLIEN    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-NUM-APOL    PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NRENDOS     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-NUM-ITEM    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-CODSUBES    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MODALIDA    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-ORGAO       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO        PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NUM-APOLANT PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V1ENDO_NUM_APOLANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-FONTE       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NRPROPOS    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-DATPRO      PIC  X(010).*/
        public StringBasis V1ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DATA-LIB    PIC  X(010).*/
        public StringBasis V1ENDO_DATA_LIB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-NUMBIL      PIC S9(015)       VALUE +0  COMP-3*/
        public IntBasis V1ENDO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1ENDO-TIPSEGU     PIC  X(001).*/
        public StringBasis V1ENDO_TIPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TIPAPO      PIC  X(001).*/
        public StringBasis V1ENDO_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TIPCALC     PIC  X(001).*/
        public StringBasis V1ENDO_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-PODPUBL     PIC  X(001).*/
        public StringBasis V1ENDO_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-NUM-ATA     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-ANO-ATA     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-IDEMAN      PIC  X(001).*/
        public StringBasis V1ENDO_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-NRRCAP      PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-VLRCAP      PIC S9(013)V99    VALUE +0  COMP-3*/
        public DoubleBasis V1ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1ENDO-BCORCAP     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-AGERCAP     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DACRCAP     PIC  X(001).*/
        public StringBasis V1ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-IDRCAP      PIC  X(001).*/
        public StringBasis V1ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-BCOCOBR     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-AGECOBR     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-DACCOBR     PIC  X(001).*/
        public StringBasis V1ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-CDFRACIO    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-PRESTA1     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-QTPARCEL    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-QTPRESTA    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-QTITENS     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODTXT      PIC  X(003).*/
        public StringBasis V1ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1ENDO-CDACEITA    PIC  X(001).*/
        public StringBasis V1ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-MOEDA-IMP   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-PRM   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-TIPO-END    PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_END { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TPCOSCED    PIC  X(001).*/
        public StringBasis V1ENDO_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-QTCOSSEG    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-PCTCED      PIC S9(004)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1ENDO_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1ENDO-OCORR-END   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODPRODU    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-COD-USUAR   PIC  X(008)       VALUE 'CB0003B'.*/
        public StringBasis V1ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CB0003B");
        /*"77         V1ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-DATA-SORT   PIC  X(010).*/
        public StringBasis V1ENDO_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DATARCAP    PIC  X(010).*/
        public StringBasis V1ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-COD-EMP     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1ENDO_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-ISENTA-CST  PIC  X(001).*/
        public StringBasis V1ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-NUM-APOL    PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V1PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-NRENDOS     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-NRPARCEL    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-DACPARC     PIC  X(001).*/
        public StringBasis V1PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-FONTE       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-NRTIT       PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PARC-PRM-TAR     PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-VAL-DES     PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNPRLIQ    PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNADFRA    PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNCUSTO    PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNIOF      PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OTNTOTAL    PIC S9(010)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V1PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-OCORHIST    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-QTDDOC      PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PARC-COD-EMP     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V1PARC_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PARC-QUANTIDADE  PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1PARC_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PARC-COUNT       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V1PARC_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COUNT         PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DACPARC      PIC  X(001).*/
        public StringBasis V1HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V1HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-PRM-TAR      PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VAL-DESC     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPRMLIQ     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLADIFRA     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLCUSEMI     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLIOCC       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPRMTOT     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-VLPREMIO     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V1HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V1HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V1HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1HISP-COD-USUARIO  PIC  X(008).*/
        public StringBasis V1HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1HISP-RNUDOC       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1HISP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-HORAOPER     PIC  X(008).*/
        public StringBasis V0HISP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-PRM-TAR      PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VAL-DESC     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPRMLIQ     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLADIFRA     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLCUSEMI     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLIOCC       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPRMTOT     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-VLPREMIO     PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISP-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0HISP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISP-RNUDOC       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0FOLP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FOLP-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-DACPARC      PIC  X(001).*/
        public StringBasis V0FOLP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0FOLP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FOLP-HORAOPER     PIC  X(008).*/
        public StringBasis V0FOLP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0FOLP-VLPREMIO     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0FOLP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FOLP-BCOAVISO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-AGEAVISO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-NRAVISO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-CODBAIXA     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-CDERRO01     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO02     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO03     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO04     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO05     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO06     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-SITUACAO     PIC  X(001).*/
        public StringBasis V0FOLP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-SITCONTB     PIC  X(001).*/
        public StringBasis V0FOLP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-OPERACAO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-DTLIBER      PIC  X(010).*/
        public StringBasis V0FOLP_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FOLP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0FOLP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FOLP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0FOLP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0FOLP-NRRCAP      PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-NUM-NOSSO    PIC S9(016)      VALUE +0  COMP-3*/
        public IntBasis V0FOLP_NUM_NOSSO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77         V0PDEV-NUM-APOL    PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V0PDEV_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PDEV-NRENDOS     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0PDEV_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PDEV-NRPARCEL    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0PDEV_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PDEV-VLACRESCIMO PIC S9(013)V99    VALUE +0  COMP-3*/
        public DoubleBasis V0PDEV_VLACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01           AREA-DE-WORK.*/
        public CB0003B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0003B_AREA_DE_WORK();
        public class CB0003B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WRESTO            PIC S9(003)    VALUE +0   COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WHORA             PIC  99.99.99.*/
            public IntBasis WHORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"  05         WTIME             PIC  99.99.99.*/
            public IntBasis WTIME { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"  05         WCH-TIPOINSERT    PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WCH_TIPOINSERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-PARCELADEV   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_PARCELADEV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-NRTIT55      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_NRTIT55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WVALOR-TITULO     PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis WVALOR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WVALOR-DIFEREN    PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis WVALOR_DIFEREN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WVALOR-DIFEREN2   PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis WVALOR_DIFEREN2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WVALOR-ACEITA     PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis WVALOR_ACEITA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WVALOR-DIFERSIN   PIC  9(013)V99 VALUE  ZEROS.*/
            public DoubleBasis WVALOR_DIFERSIN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         WVALOR-DIFERSIN2  PIC  9(013)V99 VALUE  ZEROS.*/
            public DoubleBasis WVALOR_DIFERSIN2 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         W-VALCREDR        PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis W_VALCREDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         W3-VALCREDR       PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis W3_VALCREDR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WVALOR            PIC S9(013)V99 VALUE +0   COMP-3.*/
            public DoubleBasis WVALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WCHV-BAIXA        PIC  X(001)    VALUE SPACES.*/

            public SelectorBasis WCHV_BAIXA { get; set; } = new SelectorBasis("001", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  BAIXA-OK          VALUE  ' '. */
							new SelectorItemBasis("BAIXA_OK", " "),
							/*" 88  BAIXA-FOLLOW      VALUE  '*'. */
							new SelectorItemBasis("BAIXA_FOLLOW", "*"),
							/*" 88  BAIXA-DIF-MA-0    VALUE  '1'. */
							new SelectorItemBasis("BAIXA_DIF_MA_0", "1"),
							/*" 88  BAIXA-DIF-ME-0    VALUE  '2'. */
							new SelectorItemBasis("BAIXA_DIF_ME_0", "2")
                }
            };

            /*"  05         FLAG-BAIXA        PIC  X(001)    VALUE SPACES.*/
            public StringBasis FLAG_BAIXA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-L-V1MOVICOB    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-R-V1MOVICOB    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_R_V1MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-P-V1MOVICOB    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_P_V1MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1PARCELA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0PARCELA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0HISTOPARC  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0FOLLOWUP   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0NOTASCRED  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0NOTASCRED { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0HISTNOTCRE PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTNOTCRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1AVISALDOS  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1AVISALDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0AVISALDOS  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0AVISALDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-AU071        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_AU071 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CALENDARIO   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOVICOB    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1MOVICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOEDA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1ENDOSSO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-NOTACRED     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_NOTACRED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-V1PARCELA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_V1PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         EXISTE-NOTA       PIC  X(001)    VALUE SPACES.*/
            public StringBasis EXISTE_NOTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-FAIXA55        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_FAIXA55 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-TITANT         PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WS_TITANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         WS-TITULO         PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WS-TITULO.*/
            private _REDEF_CB0003B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB0003B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB0003B_FILLER_0(); _.Move(WS_TITULO, _filler_0); VarBasis.RedefinePassValue(WS_TITULO, _filler_0, WS_TITULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_TITULO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_TITULO); }
            }  //Redefines
            public class _REDEF_CB0003B_FILLER_0 : VarBasis
            {
                /*"    10       WS-TITPRE         PIC  9(002).*/
                public IntBasis WS_TITPRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-TITNRO         PIC  9(011).*/
                public IntBasis WS_TITNRO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"  05         DATA-NOVA         PIC  X(010).*/

                public _REDEF_CB0003B_FILLER_0()
                {
                    WS_TITPRE.ValueChanged += OnValueChanged;
                    WS_TITNRO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis DATA_NOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         W01N0600.*/
            public CB0003B_W01N0600 W01N0600 { get; set; } = new CB0003B_W01N0600();
            public class CB0003B_W01N0600 : VarBasis
            {
                /*"    10       W01N0200          PIC  9(002).*/
                public IntBasis W01N0200 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02N0200          PIC  9(002).*/
                public IntBasis W02N0200 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W03N0200          PIC  9(004).*/
                public IntBasis W03N0200 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WDATA.*/
            }
            public CB0003B_WDATA WDATA { get; set; } = new CB0003B_WDATA();
            public class CB0003B_WDATA : VarBasis
            {
                /*"    10       WDATA-ANO         PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MES         PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DIA         PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-CURR.*/
            }
            public CB0003B_WDATA_CURR WDATA_CURR { get; set; } = new CB0003B_WDATA_CURR();
            public class CB0003B_WDATA_CURR : VarBasis
            {
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-TIME.*/
            }
            public CB0003B_WS_TIME WS_TIME { get; set; } = new CB0003B_WS_TIME();
            public class CB0003B_WS_TIME : VarBasis
            {
                /*"    10       WS-HH-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MM-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-SS-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-CC-TIME        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0003B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_CB0003B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_CB0003B_FILLER_5(); _.Move(WDATA_REL, _filler_5); VarBasis.RedefinePassValue(WDATA_REL, _filler_5, WDATA_REL); _filler_5.ValueChanged += () => { _.Move(_filler_5, WDATA_REL); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0003B_FILLER_5 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_CB0003B_FILLER_5()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0003B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new CB0003B_WDAT_REL_LIT();
            public class CB0003B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WUNIM-DATA        PIC  X(010)    VALUE ZEROS.*/
            }
            public StringBasis WUNIM_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WEMIS-DATA        PIC  X(010)    VALUE ZEROS.*/
            public StringBasis WEMIS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WEMIS-DATA.*/
            private _REDEF_CB0003B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_CB0003B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_CB0003B_FILLER_10(); _.Move(WEMIS_DATA, _filler_10); VarBasis.RedefinePassValue(WEMIS_DATA, _filler_10, WEMIS_DATA); _filler_10.ValueChanged += () => { _.Move(_filler_10, WEMIS_DATA); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WEMIS_DATA); }
            }  //Redefines
            public class _REDEF_CB0003B_FILLER_10 : VarBasis
            {
                /*"    10       WEMIS-ANOMES.*/
                public CB0003B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new CB0003B_WEMIS_ANOMES();
                public class CB0003B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15     WEMI-ANO          PIC  9(004).*/
                    public IntBasis WEMI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WEMI-MES          PIC  9(002).*/
                    public IntBasis WEMI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public CB0003B_WEMIS_ANOMES()
                    {
                        WEMI_ANO.ValueChanged += OnValueChanged;
                        FILLER_11.ValueChanged += OnValueChanged;
                        WEMI_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WEMI-DIA          PIC  9(002).*/
                public IntBasis WEMI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSIST-DATA        PIC  X(010)    VALUE ZEROS.*/

                public _REDEF_CB0003B_FILLER_10()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    WEMI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSIST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WSIST-DATA.*/
            private _REDEF_CB0003B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_CB0003B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_CB0003B_FILLER_13(); _.Move(WSIST_DATA, _filler_13); VarBasis.RedefinePassValue(WSIST_DATA, _filler_13, WSIST_DATA); _filler_13.ValueChanged += () => { _.Move(_filler_13, WSIST_DATA); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WSIST_DATA); }
            }  //Redefines
            public class _REDEF_CB0003B_FILLER_13 : VarBasis
            {
                /*"    10       WSIST-ANOMES.*/
                public CB0003B_WSIST_ANOMES WSIST_ANOMES { get; set; } = new CB0003B_WSIST_ANOMES();
                public class CB0003B_WSIST_ANOMES : VarBasis
                {
                    /*"      15     WSIS-ANO          PIC  9(004).*/
                    public IntBasis WSIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WSIS-MES          PIC  9(002).*/
                    public IntBasis WSIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       FILLER            PIC  X(001).*/

                    public CB0003B_WSIST_ANOMES()
                    {
                        WSIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_14.ValueChanged += OnValueChanged;
                        WSIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSIS-DIA          PIC  9(002).*/
                public IntBasis WSIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WTIME-DAY.*/

                public _REDEF_CB0003B_FILLER_13()
                {
                    WSIST_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                    WSIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0003B_WTIME_DAY WTIME_DAY { get; set; } = new CB0003B_WTIME_DAY();
            public class CB0003B_WTIME_DAY : VarBasis
            {
                /*"    10       WS-HORA           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WS-MINUTO         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MINUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WS-SEGUNDO        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_SEGUNDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         LK1-PARM.*/
            }
            public CB0003B_LK1_PARM LK1_PARM { get; set; } = new CB0003B_LK1_PARM();
            public class CB0003B_LK1_PARM : VarBasis
            {
                /*"    10       LK1-DATA          PIC  9(008)          VALUE ZEROS.*/
                public IntBasis LK1_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"    10       LK1-QTDIA         PIC S9(005)  COMP-3  VALUE +0.*/
                public IntBasis LK1_QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    10       LK1-DATA-NOVA     PIC  9(008)          VALUE ZEROS.*/
                public IntBasis LK1_DATA_NOVA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"  05        WABEND.*/
            }
            public CB0003B_WABEND WABEND { get; set; } = new CB0003B_WABEND();
            public class CB0003B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE           'CB0003B '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CB0003B ");
                /*"    10      FILLER              PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LD99-ABEND.*/
            }
        }
        public CB0003B_LD99_ABEND LD99_ABEND { get; set; } = new CB0003B_LD99_ABEND();
        public class CB0003B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
        }


        public Dclgens.AU071 AU071 { get; set; } = new Dclgens.AU071();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CBAPOVIG CBAPOVIG { get; set; } = new Dclgens.CBAPOVIG();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public CB0003B_V1MOVICOB V1MOVICOB { get; set; } = new CB0003B_V1MOVICOB();
        public CB0003B_V1NOTACRED V1NOTACRED { get; set; } = new CB0003B_V1NOTACRED();
        public CB0003B_C1AU071 C1AU071 { get; set; } = new CB0003B_C1AU071();
        public CB0003B_V0CALENDARIO V0CALENDARIO { get; set; } = new CB0003B_V0CALENDARIO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -681- MOVE '0001' TO WNR-EXEC-SQL. */
                _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -681- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -683- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -685- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -685- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -692- DISPLAY ' ' */
            _.Display($" ");

            /*" -693- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -695- DISPLAY 'CB0003B: VERSAO V.07 - DEMANDA 323712 ' */
            _.Display($"CB0003B: VERSAO V.07 - DEMANDA 323712 ");

            /*" -702- DISPLAY 'CB0003B: COMPILACAO: ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"CB0003B: COMPILACAO: FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -704- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -706- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -707- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -709- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -711- PERFORM R0200-00-SELECT-V1PARAMRAMO */

            R0200_00_SELECT_V1PARAMRAMO_SECTION();

            /*" -713- PERFORM R0900-00-DECLARE-V1MOVICOB */

            R0900_00_DECLARE_V1MOVICOB_SECTION();

            /*" -715- PERFORM R0910-00-FETCH-V1MOVICOB */

            R0910_00_FETCH_V1MOVICOB_SECTION();

            /*" -716- IF WFIM-V1MOVICOB NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1MOVICOB.IsEmpty())
            {

                /*" -717- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -719- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -722- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1MOVICOB NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1MOVICOB.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -722- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -726- IF V1SIST-DTMOVABE EQUAL '2007-06-20' */

            if (V1SIST_DTMOVABE == "2007-06-20")
            {

                /*" -726- PERFORM R7000-00-TRATA-SALDOS. */

                R7000_00_TRATA_SALDOS_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -732- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -733- DISPLAY 'MOVTO COBRANCA LIDOS.... ' AC-L-V1MOVICOB */
            _.Display($"MOVTO COBRANCA LIDOS.... {AREA_DE_WORK.AC_L_V1MOVICOB}");

            /*" -734- DISPLAY '          REJEITADOS.... ' AC-R-V1MOVICOB */
            _.Display($"          REJEITADOS.... {AREA_DE_WORK.AC_R_V1MOVICOB}");

            /*" -735- DISPLAY '         PROCESSADOS.... ' AC-P-V1MOVICOB */
            _.Display($"         PROCESSADOS.... {AREA_DE_WORK.AC_P_V1MOVICOB}");

            /*" -736- DISPLAY 'PARCELAS ATUALIZADAS.... ' AC-U-V0PARCELA */
            _.Display($"PARCELAS ATUALIZADAS.... {AREA_DE_WORK.AC_U_V0PARCELA}");

            /*" -737- DISPLAY 'ENDOSSOS ATUALIZADOS.... ' AC-U-V0ENDOSSO */
            _.Display($"ENDOSSOS ATUALIZADOS.... {AREA_DE_WORK.AC_U_V0ENDOSSO}");

            /*" -738- DISPLAY 'HISTORICOS INSERIDOS.... ' AC-I-V0HISTOPARC */
            _.Display($"HISTORICOS INSERIDOS.... {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -739- DISPLAY 'FOLLOW-UP INSERIDOS..... ' AC-I-V0FOLLOWUP */
            _.Display($"FOLLOW-UP INSERIDOS..... {AREA_DE_WORK.AC_I_V0FOLLOWUP}");

            /*" -740- DISPLAY 'NOTAS CREDITO BAIXADAS.. ' AC-U-V0NOTASCRED */
            _.Display($"NOTAS CREDITO BAIXADAS.. {AREA_DE_WORK.AC_U_V0NOTASCRED}");

            /*" -741- DISPLAY 'HIST. NOTAS INCLUIDOS .. ' AC-I-V0HISTNOTCRE */
            _.Display($"HIST. NOTAS INCLUIDOS .. {AREA_DE_WORK.AC_I_V0HISTNOTCRE}");

            /*" -742- DISPLAY 'SALDO AVISOS ALTERADOS . ' AC-U-V0AVISALDOS */
            _.Display($"SALDO AVISOS ALTERADOS . {AREA_DE_WORK.AC_U_V0AVISALDOS}");

            /*" -743- DISPLAY '                         ' AC-U-V0AVISALDOS */
            _.Display($"                         {AREA_DE_WORK.AC_U_V0AVISALDOS}");

            /*" -745- DISPLAY 'FAIXA 31 PARA 55 ....... ' AC-FAIXA55. */
            _.Display($"FAIXA 31 PARA 55 ....... {AREA_DE_WORK.AC_FAIXA55}");

            /*" -747- DISPLAY 'CB0003B - FIM NORMAL' */
            _.Display($"CB0003B - FIM NORMAL");

            /*" -747- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -755- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -761- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -764- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -765- DISPLAY 'CB0003B - SISTEMA DE COBRANCA NAO CADASTRADO' */
                _.Display($"CB0003B - SISTEMA DE COBRANCA NAO CADASTRADO");

                /*" -766- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -768- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -770- DISPLAY 'R0100-00 (PROBLEMAS SELECT V1SISTEMA) ... ' */
                _.Display($"R0100-00 (PROBLEMAS SELECT V1SISTEMA) ... ");

                /*" -774- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -774- MOVE V1SIST-DTMOVABE TO WSIST-DATA. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WSIST_DATA);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -761- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V1PARAMRAMO-SECTION */
        private void R0200_00_SELECT_V1PARAMRAMO_SECTION()
        {
            /*" -785- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -798- PERFORM R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1 */

            R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1();

            /*" -801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -802- DISPLAY 'CB0003B - ERRO ACESSO V1PARAMRAMO' */
                _.Display($"CB0003B - ERRO ACESSO V1PARAMRAMO");

                /*" -802- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V1PARAMRAMO-DB-SELECT-1 */
        public void R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -798- EXEC SQL SELECT RAMO_VGAPC , RAMO_VG , RAMO_AP , RAMO_SAUDE , RAMO_EDUCACAO INTO :V1PARR-RAMO-VGAPC, :V1PARR-RAMO-VG , :V1PARR-RAMO-AP , :V1PARR-RAMO-SAUDE, :V1PARR-RAMO-EDUCA FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

            var r0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARR_RAMO_VGAPC, V1PARR_RAMO_VGAPC);
                _.Move(executed_1.V1PARR_RAMO_VG, V1PARR_RAMO_VG);
                _.Move(executed_1.V1PARR_RAMO_AP, V1PARR_RAMO_AP);
                _.Move(executed_1.V1PARR_RAMO_SAUDE, V1PARR_RAMO_SAUDE);
                _.Move(executed_1.V1PARR_RAMO_EDUCA, V1PARR_RAMO_EDUCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1MOVICOB-SECTION */
        private void R0900_00_DECLARE_V1MOVICOB_SECTION()
        {
            /*" -813- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -840- PERFORM R0900_00_DECLARE_V1MOVICOB_DB_DECLARE_1 */

            R0900_00_DECLARE_V1MOVICOB_DB_DECLARE_1();

            /*" -843- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -844- DISPLAY 'ERRO DECLARE V1MOVICOB' */
                _.Display($"ERRO DECLARE V1MOVICOB");

                /*" -846- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -846- PERFORM R0900_00_DECLARE_V1MOVICOB_DB_OPEN_1 */

            R0900_00_DECLARE_V1MOVICOB_DB_OPEN_1();

            /*" -849- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -850- DISPLAY 'ERRO CLOSE V1MOVICOB' */
                _.Display($"ERRO CLOSE V1MOVICOB");

                /*" -850- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1MOVICOB-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1MOVICOB_DB_DECLARE_1()
        {
            /*" -840- EXEC SQL DECLARE V1MOVICOB CURSOR FOR SELECT CODMOV ,BANCO ,AGENCIA ,NRAVISO ,NUMFITA ,DTMOVTO ,DTQITBCO ,NRTIT ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,VALTIT ,VLIOCC ,VALCDT ,SITUACAO ,NOME ,NUM_NOSSO_TITULO FROM SEGUROS.V1MOVICOB WHERE SITUACAO = ' ' AND TIPO_MOVIMENTO = '1' ORDER BY BANCO ,AGENCIA ,NRTIT WITH UR END-EXEC. */
            V1MOVICOB = new CB0003B_V1MOVICOB(false);
            string GetQuery_V1MOVICOB()
            {
                var query = @$"SELECT CODMOV 
							,BANCO 
							,AGENCIA 
							,NRAVISO 
							,NUMFITA 
							,DTMOVTO 
							,DTQITBCO 
							,NRTIT 
							,NUM_APOLICE 
							,NRENDOS 
							,NRPARCEL 
							,VALTIT 
							,VLIOCC 
							,VALCDT 
							,SITUACAO 
							,NOME 
							,NUM_NOSSO_TITULO 
							FROM SEGUROS.V1MOVICOB 
							WHERE SITUACAO = ' ' 
							AND TIPO_MOVIMENTO = '1' 
							ORDER BY BANCO 
							,AGENCIA 
							,NRTIT";

                return query;
            }
            V1MOVICOB.GetQueryEvent += GetQuery_V1MOVICOB;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1MOVICOB-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1MOVICOB_DB_OPEN_1()
        {
            /*" -846- EXEC SQL OPEN V1MOVICOB END-EXEC. */

            V1MOVICOB.Open();

        }

        [StopWatch]
        /*" R1760-00-DECLARE-NOTASCRED-DB-DECLARE-1 */
        public void R1760_00_DECLARE_NOTASCRED_DB_DECLARE_1()
        {
            /*" -1817- EXEC SQL DECLARE V1NOTACRED CURSOR FOR SELECT NRENDOSR , NRPARCELR , DTVENCTO , VALCREDR_IX FROM SEGUROS.V1NOTASCRED WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOSC = :V1PARC-NRENDOS AND NRPARCELC = :V1PARC-NRPARCEL AND SITUACAO = '0' WITH UR END-EXEC. */
            V1NOTACRED = new CB0003B_V1NOTACRED(true);
            string GetQuery_V1NOTACRED()
            {
                var query = @$"SELECT NRENDOSR
							, 
							NRPARCELR
							, 
							DTVENCTO
							, 
							VALCREDR_IX 
							FROM SEGUROS.V1NOTASCRED 
							WHERE NUM_APOLICE = '{V1PARC_NUM_APOL}' 
							AND NRENDOSC = '{V1PARC_NRENDOS}' 
							AND NRPARCELC = '{V1PARC_NRPARCEL}' 
							AND SITUACAO = '0'";

                return query;
            }
            V1NOTACRED.GetQueryEvent += GetQuery_V1NOTACRED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1MOVICOB-SECTION */
        private void R0910_00_FETCH_V1MOVICOB_SECTION()
        {
            /*" -861- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -879- PERFORM R0910_00_FETCH_V1MOVICOB_DB_FETCH_1 */

            R0910_00_FETCH_V1MOVICOB_DB_FETCH_1();

            /*" -882- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -883- MOVE 'S' TO WFIM-V1MOVICOB */
                _.Move("S", AREA_DE_WORK.WFIM_V1MOVICOB);

                /*" -883- PERFORM R0910_00_FETCH_V1MOVICOB_DB_CLOSE_1 */

                R0910_00_FETCH_V1MOVICOB_DB_CLOSE_1();

                /*" -886- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -887- ADD 1 TO AC-L-V1MOVICOB. */
            AREA_DE_WORK.AC_L_V1MOVICOB.Value = AREA_DE_WORK.AC_L_V1MOVICOB + 1;

            /*" -889- ADD 1 TO AC-LIDOS */
            AC_LIDOS.Value = AC_LIDOS + 1;

            /*" -890- IF AC-LIDOS GREATER 100 */

            if (AC_LIDOS > 100)
            {

                /*" -891- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -892- MOVE WS-HH-TIME TO WS-HORA */
                _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

                /*" -893- MOVE WS-MM-TIME TO WS-MINUTO */
                _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

                /*" -894- MOVE WS-SS-TIME TO WS-SEGUNDO */
                _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

                /*" -896- DISPLAY 'LIDOS ATE AGORA ... ' AC-L-V1MOVICOB ' ' WTIME-DAY */

                $"LIDOS ATE AGORA ... {AREA_DE_WORK.AC_L_V1MOVICOB} {AREA_DE_WORK.WTIME_DAY}"
                .Display();

                /*" -896- MOVE ZEROS TO AC-LIDOS. */
                _.Move(0, AC_LIDOS);
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V1MOVICOB-DB-FETCH-1 */
        public void R0910_00_FETCH_V1MOVICOB_DB_FETCH_1()
        {
            /*" -879- EXEC SQL FETCH V1MOVICOB INTO :V1MCOB-CODMOV ,:V1MCOB-BANCO ,:V1MCOB-AGENCIA ,:V1MCOB-NRAVISO ,:V1MCOB-NUMFITA ,:V1MCOB-DTMOVTO ,:V1MCOB-DTQITBCO ,:V1MCOB-NRTIT ,:V1MCOB-NUM-APOL ,:V1MCOB-NRENDOS ,:V1MCOB-NRPARCEL ,:V1MCOB-VALTIT ,:V1MCOB-VLIOCC ,:V1MCOB-VALCDT ,:V1MCOB-SITUACAO ,:V1MCOB-NOME ,:V1MCOB-NUM-NOSSO END-EXEC. */

            if (V1MOVICOB.Fetch())
            {
                _.Move(V1MOVICOB.V1MCOB_CODMOV, V1MCOB_CODMOV);
                _.Move(V1MOVICOB.V1MCOB_BANCO, V1MCOB_BANCO);
                _.Move(V1MOVICOB.V1MCOB_AGENCIA, V1MCOB_AGENCIA);
                _.Move(V1MOVICOB.V1MCOB_NRAVISO, V1MCOB_NRAVISO);
                _.Move(V1MOVICOB.V1MCOB_NUMFITA, V1MCOB_NUMFITA);
                _.Move(V1MOVICOB.V1MCOB_DTMOVTO, V1MCOB_DTMOVTO);
                _.Move(V1MOVICOB.V1MCOB_DTQITBCO, V1MCOB_DTQITBCO);
                _.Move(V1MOVICOB.V1MCOB_NRTIT, V1MCOB_NRTIT);
                _.Move(V1MOVICOB.V1MCOB_NUM_APOL, V1MCOB_NUM_APOL);
                _.Move(V1MOVICOB.V1MCOB_NRENDOS, V1MCOB_NRENDOS);
                _.Move(V1MOVICOB.V1MCOB_NRPARCEL, V1MCOB_NRPARCEL);
                _.Move(V1MOVICOB.V1MCOB_VALTIT, V1MCOB_VALTIT);
                _.Move(V1MOVICOB.V1MCOB_VLIOCC, V1MCOB_VLIOCC);
                _.Move(V1MOVICOB.V1MCOB_VALCDT, V1MCOB_VALCDT);
                _.Move(V1MOVICOB.V1MCOB_SITUACAO, V1MCOB_SITUACAO);
                _.Move(V1MOVICOB.V1MCOB_NOME, V1MCOB_NOME);
                _.Move(V1MOVICOB.V1MCOB_NUM_NOSSO, V1MCOB_NUM_NOSSO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1MOVICOB-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1MOVICOB_DB_CLOSE_1()
        {
            /*" -883- EXEC SQL CLOSE V1MOVICOB END-EXEC */

            V1MOVICOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -917- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -920- MOVE ZEROS TO V1PARC-QTDDOC WS-FLAG-AUTO */
            _.Move(0, V1PARC_QTDDOC, WS_FLAG_AUTO);

            /*" -932- MOVE SPACES TO V0FOLP-CDERRO01 V0FOLP-CDERRO02 V0FOLP-CDERRO03 V0FOLP-CDERRO04 V0FOLP-CDERRO05 V0FOLP-CDERRO06 WFIM-V1PARCELA WCHV-BAIXA W1MCOB-NOME. */
            _.Move("", V0FOLP_CDERRO01, V0FOLP_CDERRO02, V0FOLP_CDERRO03, V0FOLP_CDERRO04, V0FOLP_CDERRO05, V0FOLP_CDERRO06, AREA_DE_WORK.WFIM_V1PARCELA, AREA_DE_WORK.WCHV_BAIXA, W1MCOB_NOME);

            /*" -934- MOVE SPACES TO WTEM-NRTIT55. */
            _.Move("", AREA_DE_WORK.WTEM_NRTIT55);

            /*" -937- MOVE V1MCOB-NRTIT TO WS-TITANT WS-TITULO. */
            _.Move(V1MCOB_NRTIT, AREA_DE_WORK.WS_TITANT, AREA_DE_WORK.WS_TITULO);

            /*" -939- PERFORM R3150-00-SELECT-V1PARCELA. */

            R3150_00_SELECT_V1PARCELA_SECTION();

            /*" -949- MOVE V1PARC-QTDDOC TO WHOST-QTDDOC */
            _.Move(V1PARC_QTDDOC, WHOST_QTDDOC);

            /*" -950- IF SQLCODE EQUAL -810 OR -811 */

            if (DB.SQLCODE.In("-810", "-811"))
            {

                /*" -951- MOVE '1' TO V0FOLP-CDERRO02 */
                _.Move("1", V0FOLP_CDERRO02);

                /*" -952- PERFORM R4300-00-MONTA-V0FOLLOWUP */

                R4300_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -953- MOVE ZEROS TO V1ENDO-FONTE */
                _.Move(0, V1ENDO_FONTE);

                /*" -954- MOVE ZEROS TO V1ENDO-NRRCAP */
                _.Move(0, V1ENDO_NRRCAP);

                /*" -955- PERFORM R5200-00-INSERT-V0FOLLOWUP */

                R5200_00_INSERT_V0FOLLOWUP_SECTION();

                /*" -956- MOVE '2' TO W1MCOB-SITUACAO */
                _.Move("2", W1MCOB_SITUACAO);

                /*" -958- MOVE 'TITULO EM DUPLICIDADE' TO W1MCOB-NOME */
                _.Move("TITULO EM DUPLICIDADE", W1MCOB_NOME);

                /*" -959- PERFORM R6300-00-UPDATE-V0MOVICOB */

                R6300_00_UPDATE_V0MOVICOB_SECTION();

                /*" -960- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -961- ELSE */
            }
            else
            {


                /*" -962- IF WFIM-V1PARCELA NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1PARCELA.IsEmpty())
                {

                    /*" -963- MOVE '1' TO V0FOLP-CDERRO01 */
                    _.Move("1", V0FOLP_CDERRO01);

                    /*" -964- PERFORM R4300-00-MONTA-V0FOLLOWUP */

                    R4300_00_MONTA_V0FOLLOWUP_SECTION();

                    /*" -965- MOVE ZEROS TO V1ENDO-FONTE */
                    _.Move(0, V1ENDO_FONTE);

                    /*" -966- MOVE ZEROS TO V1ENDO-NRRCAP */
                    _.Move(0, V1ENDO_NRRCAP);

                    /*" -967- PERFORM R5200-00-INSERT-V0FOLLOWUP */

                    R5200_00_INSERT_V0FOLLOWUP_SECTION();

                    /*" -968- MOVE '2' TO W1MCOB-SITUACAO */
                    _.Move("2", W1MCOB_SITUACAO);

                    /*" -969- PERFORM R6300-00-UPDATE-V0MOVICOB */

                    R6300_00_UPDATE_V0MOVICOB_SECTION();

                    /*" -971- GO TO R1000-90-LEITURA. */

                    R1000_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -973- PERFORM R2100-00-SELECT-V1ENDOSSO */

            R2100_00_SELECT_V1ENDOSSO_SECTION();

            /*" -974- IF WCHV-BAIXA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WCHV_BAIXA.IsEmpty())
            {

                /*" -975- PERFORM R4250-00-MONTA-V0FOLLOWUP */

                R4250_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -976- PERFORM R5200-00-INSERT-V0FOLLOWUP */

                R5200_00_INSERT_V0FOLLOWUP_SECTION();

                /*" -977- MOVE '2' TO W1MCOB-SITUACAO */
                _.Move("2", W1MCOB_SITUACAO);

                /*" -978- PERFORM R6300-00-UPDATE-V0MOVICOB */

                R6300_00_UPDATE_V0MOVICOB_SECTION();

                /*" -980- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -982- PERFORM R3500-00-SELECT-CBAPOVIG. */

            R3500_00_SELECT_CBAPOVIG_SECTION();

            /*" -983- IF CBAPOVIG-SITUACAO EQUAL 'V' */

            if (CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO == "V")
            {

                /*" -984- MOVE '1' TO V0FOLP-CDERRO04 */
                _.Move("1", V0FOLP_CDERRO04);

                /*" -985- PERFORM R4250-00-MONTA-V0FOLLOWUP */

                R4250_00_MONTA_V0FOLLOWUP_SECTION();

                /*" -986- PERFORM R5200-00-INSERT-V0FOLLOWUP */

                R5200_00_INSERT_V0FOLLOWUP_SECTION();

                /*" -987- MOVE '2' TO W1MCOB-SITUACAO */
                _.Move("2", W1MCOB_SITUACAO);

                /*" -988- MOVE SPACES TO W1MCOB-NOME */
                _.Move("", W1MCOB_NOME);

                /*" -989- PERFORM R6300-00-UPDATE-V0MOVICOB */

                R6300_00_UPDATE_V0MOVICOB_SECTION();

                /*" -996- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -997- IF V1ENDO-ORGAO EQUAL 110 */

            if (V1ENDO_ORGAO == 110)
            {

                /*" -1000- IF V1ENDO-CODPRODU GREATER 3099 AND V1ENDO-CODPRODU LESS 3200 */

                if (V1ENDO_CODPRODU > 3099 && V1ENDO_CODPRODU < 3200)
                {

                    /*" -1002- PERFORM R3600-00-SELECT-V1PARCELA */

                    R3600_00_SELECT_V1PARCELA_SECTION();

                    /*" -1003- IF V1PARC-COUNT NOT EQUAL ZEROS */

                    if (V1PARC_COUNT != 00)
                    {

                        /*" -1004- MOVE '1' TO V0FOLP-CDERRO02 */
                        _.Move("1", V0FOLP_CDERRO02);

                        /*" -1005- PERFORM R4300-00-MONTA-V0FOLLOWUP */

                        R4300_00_MONTA_V0FOLLOWUP_SECTION();

                        /*" -1006- MOVE ZEROS TO V1ENDO-FONTE */
                        _.Move(0, V1ENDO_FONTE);

                        /*" -1007- MOVE ZEROS TO V1ENDO-NRRCAP */
                        _.Move(0, V1ENDO_NRRCAP);

                        /*" -1008- PERFORM R5200-00-INSERT-V0FOLLOWUP */

                        R5200_00_INSERT_V0FOLLOWUP_SECTION();

                        /*" -1009- MOVE '2' TO W1MCOB-SITUACAO */
                        _.Move("2", W1MCOB_SITUACAO);

                        /*" -1011- MOVE 'PARCELA ANTERIOR PENDENTE' TO W1MCOB-NOME */
                        _.Move("PARCELA ANTERIOR PENDENTE", W1MCOB_NOME);

                        /*" -1012- PERFORM R6300-00-UPDATE-V0MOVICOB */

                        R6300_00_UPDATE_V0MOVICOB_SECTION();

                        /*" -1014- GO TO R1000-90-LEITURA. */

                        R1000_90_LEITURA(); //GOTO
                        return;
                    }

                }

            }


            /*" -1016- PERFORM R1200-00-TRATAMENTO-TITULO */

            R1200_00_TRATAMENTO_TITULO_SECTION();

            /*" -1017- IF WCHV-BAIXA EQUAL ' ' */

            if (AREA_DE_WORK.WCHV_BAIXA == " ")
            {

                /*" -1018- PERFORM R3000-00-CALCULA-CORRECAO */

                R3000_00_CALCULA_CORRECAO_SECTION();

                /*" -1019- PERFORM R4100-00-MONTA-CORRECAO */

                R4100_00_MONTA_CORRECAO_SECTION();

                /*" -1020- PERFORM R5100-00-INSERT-V0HISTOPARC */

                R5100_00_INSERT_V0HISTOPARC_SECTION();

                /*" -1021- PERFORM R4200-00-MONTA-COBRANCA */

                R4200_00_MONTA_COBRANCA_SECTION();

                /*" -1022- PERFORM R5100-00-INSERT-V0HISTOPARC */

                R5100_00_INSERT_V0HISTOPARC_SECTION();

                /*" -1023- PERFORM R6100-00-UPDATE-V0PARCELA */

                R6100_00_UPDATE_V0PARCELA_SECTION();

                /*" -1024- PERFORM R6110-00-INCLUI-AUTO-COMPL */

                R6110_00_INCLUI_AUTO_COMPL_SECTION();

                /*" -1025- PERFORM R6200-00-UPDATE-V0ENDOSSO */

                R6200_00_UPDATE_V0ENDOSSO_SECTION();

                /*" -1026- ADD 1 TO AC-P-V1MOVICOB */
                AREA_DE_WORK.AC_P_V1MOVICOB.Value = AREA_DE_WORK.AC_P_V1MOVICOB + 1;

                /*" -1027- MOVE '1' TO W1MCOB-SITUACAO */
                _.Move("1", W1MCOB_SITUACAO);

                /*" -1028- PERFORM R6300-00-UPDATE-V0MOVICOB */

                R6300_00_UPDATE_V0MOVICOB_SECTION();

                /*" -1029- PERFORM R6400-00-UPDATE-V0AVISALDOS */

                R6400_00_UPDATE_V0AVISALDOS_SECTION();

                /*" -1030- ELSE */
            }
            else
            {


                /*" -1031- IF WCHV-BAIXA EQUAL '*' */

                if (AREA_DE_WORK.WCHV_BAIXA == "*")
                {

                    /*" -1032- PERFORM R4250-00-MONTA-V0FOLLOWUP */

                    R4250_00_MONTA_V0FOLLOWUP_SECTION();

                    /*" -1033- PERFORM R5200-00-INSERT-V0FOLLOWUP */

                    R5200_00_INSERT_V0FOLLOWUP_SECTION();

                    /*" -1034- MOVE '2' TO W1MCOB-SITUACAO */
                    _.Move("2", W1MCOB_SITUACAO);

                    /*" -1034- PERFORM R6300-00-UPDATE-V0MOVICOB. */

                    R6300_00_UPDATE_V0MOVICOB_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1040- PERFORM R0910-00-FETCH-V1MOVICOB. */

            R0910_00_FETCH_V1MOVICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-TRATAMENTO-TITULO-SECTION */
        private void R1200_00_TRATAMENTO_TITULO_SECTION()
        {
            /*" -1053- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1056- MOVE SPACES TO WCHV-BAIXA FLAG-BAIXA */
            _.Move("", AREA_DE_WORK.WCHV_BAIXA, AREA_DE_WORK.FLAG_BAIXA);

            /*" -1061- IF V1ENDO-RAMO NOT EQUAL V1PARR-RAMO-VGAPC AND V1PARR-RAMO-VG AND V1PARR-RAMO-AP AND V1PARR-RAMO-SAUDE AND V1PARR-RAMO-EDUCA */

            if (!V1ENDO_RAMO.In(V1PARR_RAMO_VGAPC.ToString(), V1PARR_RAMO_VG.ToString(), V1PARR_RAMO_AP.ToString(), V1PARR_RAMO_SAUDE.ToString(), V1PARR_RAMO_EDUCA.ToString()))
            {

                /*" -1062- PERFORM R1300-00-CALCULA-VALORES */

                R1300_00_CALCULA_VALORES_SECTION();

                /*" -1063- GO TO R1200-10-VERIFICA */

                R1200_10_VERIFICA(); //GOTO
                return;

                /*" -1064- ELSE */
            }
            else
            {


                /*" -1065- IF V1ENDO-CODPRODU NOT EQUAL ZEROS */

                if (V1ENDO_CODPRODU != 00)
                {

                    /*" -1066- PERFORM R1300-00-CALCULA-VALORES */

                    R1300_00_CALCULA_VALORES_SECTION();

                    /*" -1070- GO TO R1200-10-VERIFICA. */

                    R1200_10_VERIFICA(); //GOTO
                    return;
                }

            }


            /*" -1076- IF V1ENDO-CORRECAO EQUAL '1' */

            if (V1ENDO_CORRECAO == "1")
            {

                /*" -1077- PERFORM R1270-00-OBTEM-VALOR-NOMINAL */

                R1270_00_OBTEM_VALOR_NOMINAL_SECTION();

                /*" -1078- ELSE */
            }
            else
            {


                /*" -1078- PERFORM R1300-00-CALCULA-VALORES. */

                R1300_00_CALCULA_VALORES_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1200_10_VERIFICA */

            R1200_10_VERIFICA();

        }

        [StopWatch]
        /*" R1200-10-VERIFICA */
        private void R1200_10_VERIFICA(bool isPerform = false)
        {
            /*" -1083- IF WCHV-BAIXA EQUAL '2' */

            if (AREA_DE_WORK.WCHV_BAIXA == "2")
            {

                /*" -1084- PERFORM R1400-00-DIF-IGUAL-ZERO */

                R1400_00_DIF_IGUAL_ZERO_SECTION();

                /*" -1085- ELSE */
            }
            else
            {


                /*" -1086- IF WCHV-BAIXA EQUAL '1' */

                if (AREA_DE_WORK.WCHV_BAIXA == "1")
                {

                    /*" -1087- PERFORM R1500-00-DIF-MENOR-ZERO */

                    R1500_00_DIF_MENOR_ZERO_SECTION();

                    /*" -1088- ELSE */
                }
                else
                {


                    /*" -1088- PERFORM R1600-00-DIF-MAIOR-ZERO. */

                    R1600_00_DIF_MAIOR_ZERO_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1270-00-OBTEM-VALOR-NOMINAL-SECTION */
        private void R1270_00_OBTEM_VALOR_NOMINAL_SECTION()
        {
            /*" -1150- MOVE '1270' TO WNR-EXEC-SQL. */
            _.Move("1270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1151- MOVE V1PARC-PRM-TAR TO W0-PRM-TAR */
            _.Move(V1PARC_PRM_TAR, W0_PRM_TAR);

            /*" -1153- MOVE V1PARC-VAL-DES TO W0-VAL-DES */
            _.Move(V1PARC_VAL_DES, W0_VAL_DES);

            /*" -1155- COMPUTE W0-VLPRMLIQ = W0-PRM-TAR - W0-VAL-DES */
            W0_VLPRMLIQ.Value = W0_PRM_TAR - W0_VAL_DES;

            /*" -1156- MOVE V1PARC-OTNADFRA TO W0-VLADIFRA */
            _.Move(V1PARC_OTNADFRA, W0_VLADIFRA);

            /*" -1157- MOVE V1PARC-OTNCUSTO TO W0-VLCUSEMI */
            _.Move(V1PARC_OTNCUSTO, W0_VLCUSEMI);

            /*" -1159- MOVE V1PARC-OTNIOF TO W0-VLIOCC */
            _.Move(V1PARC_OTNIOF, W0_VLIOCC);

            /*" -1163- COMPUTE W0-VLPRMTOT = W0-VLPRMLIQ + W0-VLADIFRA + W0-VLCUSEMI + W0-VLIOCC */
            W0_VLPRMTOT.Value = W0_VLPRMLIQ + W0_VLADIFRA + W0_VLCUSEMI + W0_VLIOCC;

            /*" -1165- COMPUTE WVALOR-DIFEREN = V1MCOB-VALTIT - W0-VLPRMTOT */
            AREA_DE_WORK.WVALOR_DIFEREN.Value = V1MCOB_VALTIT - W0_VLPRMTOT;

            /*" -1166- IF WVALOR-DIFEREN EQUAL +0 */

            if (AREA_DE_WORK.WVALOR_DIFEREN == +0)
            {

                /*" -1167- MOVE '2' TO WCHV-BAIXA */
                _.Move("2", AREA_DE_WORK.WCHV_BAIXA);

                /*" -1168- ELSE */
            }
            else
            {


                /*" -1169- IF WVALOR-DIFEREN GREATER +0 */

                if (AREA_DE_WORK.WVALOR_DIFEREN > +0)
                {

                    /*" -1170- MOVE '3' TO WCHV-BAIXA */
                    _.Move("3", AREA_DE_WORK.WCHV_BAIXA);

                    /*" -1171- ELSE */
                }
                else
                {


                    /*" -1171- MOVE '1' TO WCHV-BAIXA. */
                    _.Move("1", AREA_DE_WORK.WCHV_BAIXA);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1270_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CALCULA-VALORES-SECTION */
        private void R1300_00_CALCULA_VALORES_SECTION()
        {
            /*" -1189- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1194- IF V1ENDO-RAMO EQUAL V1PARR-RAMO-VGAPC OR V1PARR-RAMO-VG OR V1PARR-RAMO-AP OR V1PARR-RAMO-SAUDE OR V1PARR-RAMO-EDUCA */

            if (V1ENDO_RAMO.In(V1PARR_RAMO_VGAPC.ToString(), V1PARR_RAMO_VG.ToString(), V1PARR_RAMO_AP.ToString(), V1PARR_RAMO_SAUDE.ToString(), V1PARR_RAMO_EDUCA.ToString()))
            {

                /*" -1195- IF V1ENDO-CODPRODU EQUAL ZEROS */

                if (V1ENDO_CODPRODU == 00)
                {

                    /*" -1196- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
                    _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

                    /*" -1197- ELSE */
                }
                else
                {


                    /*" -1198- PERFORM R1350-00-PRE-FIXADO */

                    R1350_00_PRE_FIXADO_SECTION();

                    /*" -1199- ELSE */
                }

            }
            else
            {


                /*" -1201- PERFORM R1350-00-PRE-FIXADO. */

                R1350_00_PRE_FIXADO_SECTION();
            }


            /*" -1203- MOVE V1MCOB-DTQITBCO TO WHOST-DTINIVIG */
            _.Move(V1MCOB_DTQITBCO, WHOST_DTINIVIG);

            /*" -1205- PERFORM R2200-00-SELECT-V1MOEDA */

            R2200_00_SELECT_V1MOEDA_SECTION();

            /*" -1208- COMPUTE W0-PRM-TAR ROUNDED = V1PARC-PRM-TAR * V1MOED-VLCRUZAD */
            W0_PRM_TAR.Value = V1PARC_PRM_TAR * V1MOED_VLCRUZAD;

            /*" -1211- COMPUTE W0-VAL-DES ROUNDED = V1PARC-VAL-DES * V1MOED-VLCRUZAD */
            W0_VAL_DES.Value = V1PARC_VAL_DES * V1MOED_VLCRUZAD;

            /*" -1213- COMPUTE W0-VLPRMLIQ = W0-PRM-TAR - W0-VAL-DES */
            W0_VLPRMLIQ.Value = W0_PRM_TAR - W0_VAL_DES;

            /*" -1216- COMPUTE W0-VLADIFRA ROUNDED = V1PARC-OTNADFRA * V1MOED-VLCRUZAD */
            W0_VLADIFRA.Value = V1PARC_OTNADFRA * V1MOED_VLCRUZAD;

            /*" -1219- COMPUTE W0-VLCUSEMI ROUNDED = V1PARC-OTNCUSTO * V1MOED-VLCRUZAD */
            W0_VLCUSEMI.Value = V1PARC_OTNCUSTO * V1MOED_VLCRUZAD;

            /*" -1222- COMPUTE W0-VLIOCC ROUNDED = V1PARC-OTNIOF * V1MOED-VLCRUZAD */
            W0_VLIOCC.Value = V1PARC_OTNIOF * V1MOED_VLCRUZAD;

            /*" -1230- COMPUTE W0-VLPRMTOT = W0-VLPRMLIQ + W0-VLADIFRA + W0-VLCUSEMI + W0-VLIOCC */
            W0_VLPRMTOT.Value = W0_VLPRMLIQ + W0_VLADIFRA + W0_VLCUSEMI + W0_VLIOCC;

            /*" -1236- MOVE 'N' TO WTEM-PARCELADEV. */
            _.Move("N", AREA_DE_WORK.WTEM_PARCELADEV);

            /*" -1237- IF V1ENDO-ORGAO EQUAL 110 */

            if (V1ENDO_ORGAO == 110)
            {

                /*" -1239- IF V1ENDO-CODPRODU GREATER 3099 AND V1ENDO-CODPRODU LESS 3200 */

                if (V1ENDO_CODPRODU > 3099 && V1ENDO_CODPRODU < 3200)
                {

                    /*" -1240- PERFORM R3440-00-TRATA-AUTOSAS */

                    R3440_00_TRATA_AUTOSAS_SECTION();

                    /*" -1241- ELSE */
                }
                else
                {


                    /*" -1242- PERFORM R3300-00-ACESSA-PARCELADEV */

                    R3300_00_ACESSA_PARCELADEV_SECTION();

                    /*" -1243- ELSE */
                }

            }
            else
            {


                /*" -1245- PERFORM R3300-00-ACESSA-PARCELADEV. */

                R3300_00_ACESSA_PARCELADEV_SECTION();
            }


            /*" -1246- IF WTEM-PARCELADEV EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_PARCELADEV == "N")
            {

                /*" -1247- COMPUTE WVALOR-DIFEREN = V1MCOB-VALTIT - W0-VLPRMTOT */
                AREA_DE_WORK.WVALOR_DIFEREN.Value = V1MCOB_VALTIT - W0_VLPRMTOT;

                /*" -1248- ELSE */
            }
            else
            {


                /*" -1252- COMPUTE WVALOR-DIFEREN = V1MCOB-VALTIT - V0PDEV-VLACRESCIMO - W0-VLPRMTOT. */
                AREA_DE_WORK.WVALOR_DIFEREN.Value = V1MCOB_VALTIT - V0PDEV_VLACRESCIMO - W0_VLPRMTOT;
            }


            /*" -1253- IF WVALOR-DIFEREN EQUAL +0 */

            if (AREA_DE_WORK.WVALOR_DIFEREN == +0)
            {

                /*" -1254- MOVE '2' TO WCHV-BAIXA */
                _.Move("2", AREA_DE_WORK.WCHV_BAIXA);

                /*" -1255- ELSE */
            }
            else
            {


                /*" -1256- IF WVALOR-DIFEREN GREATER +0 */

                if (AREA_DE_WORK.WVALOR_DIFEREN > +0)
                {

                    /*" -1257- MOVE '3' TO WCHV-BAIXA */
                    _.Move("3", AREA_DE_WORK.WCHV_BAIXA);

                    /*" -1258- ELSE */
                }
                else
                {


                    /*" -1258- MOVE '1' TO WCHV-BAIXA. */
                    _.Move("1", AREA_DE_WORK.WCHV_BAIXA);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-PRE-FIXADO-SECTION */
        private void R1350_00_PRE_FIXADO_SECTION()
        {
            /*" -1275- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1277- PERFORM R3100-00-SELECT-VENCIMENTO. */

            R3100_00_SELECT_VENCIMENTO_SECTION();

            /*" -1279- IF (V1ENDO-CORRECAO NOT EQUAL '3' ) OR (V1MCOB-DTQITBCO NOT GREATER W1HISP-DTVENCTO) */

            if ((V1ENDO_CORRECAO != "3") || (V1MCOB_DTQITBCO <= W1HISP_DTVENCTO))
            {

                /*" -1280- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
                _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

                /*" -1284- GO TO R1350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1285- MOVE W1HISP-DTVENCTO TO WDATA */
            _.Move(W1HISP_DTVENCTO, AREA_DE_WORK.WDATA);

            /*" -1286- MOVE WDATA-DIA TO W01N0200 */
            _.Move(AREA_DE_WORK.WDATA.WDATA_DIA, AREA_DE_WORK.W01N0600.W01N0200);

            /*" -1287- MOVE WDATA-MES TO W02N0200 */
            _.Move(AREA_DE_WORK.WDATA.WDATA_MES, AREA_DE_WORK.W01N0600.W02N0200);

            /*" -1288- MOVE WDATA-ANO TO W03N0200 */
            _.Move(AREA_DE_WORK.WDATA.WDATA_ANO, AREA_DE_WORK.W01N0600.W03N0200);

            /*" -1289- MOVE W01N0600 TO LK1-DATA */
            _.Move(AREA_DE_WORK.W01N0600, AREA_DE_WORK.LK1_PARM.LK1_DATA);

            /*" -1290- MOVE +0 TO LK1-QTDIA */
            _.Move(+0, AREA_DE_WORK.LK1_PARM.LK1_QTDIA);

            /*" -1292- MOVE ZEROS TO LK1-DATA-NOVA */
            _.Move(0, AREA_DE_WORK.LK1_PARM.LK1_DATA_NOVA);

            /*" -1294- CALL 'PROVERC1' USING LK1-PARM. */
            _.Call("PROVERC1", AREA_DE_WORK.LK1_PARM);

            /*" -1295- IF LK1-DATA EQUAL 55555555 */

            if (AREA_DE_WORK.LK1_PARM.LK1_DATA == 55555555)
            {

                /*" -1296- MOVE W1HISP-DTVENCTO TO WDATA */
                _.Move(W1HISP_DTVENCTO, AREA_DE_WORK.WDATA);

                /*" -1297- MOVE WDATA-DIA TO W01N0200 */
                _.Move(AREA_DE_WORK.WDATA.WDATA_DIA, AREA_DE_WORK.W01N0600.W01N0200);

                /*" -1298- MOVE WDATA-MES TO W02N0200 */
                _.Move(AREA_DE_WORK.WDATA.WDATA_MES, AREA_DE_WORK.W01N0600.W02N0200);

                /*" -1299- MOVE WDATA-ANO TO W03N0200 */
                _.Move(AREA_DE_WORK.WDATA.WDATA_ANO, AREA_DE_WORK.W01N0600.W03N0200);

                /*" -1300- MOVE W01N0600 TO LK1-DATA */
                _.Move(AREA_DE_WORK.W01N0600, AREA_DE_WORK.LK1_PARM.LK1_DATA);

                /*" -1301- MOVE +1 TO LK1-QTDIA */
                _.Move(+1, AREA_DE_WORK.LK1_PARM.LK1_QTDIA);

                /*" -1302- MOVE ZEROS TO LK1-DATA-NOVA */
                _.Move(0, AREA_DE_WORK.LK1_PARM.LK1_DATA_NOVA);

                /*" -1303- CALL 'PROSOCU1' USING LK1-PARM */
                _.Call("PROSOCU1", AREA_DE_WORK.LK1_PARM);

                /*" -1304- MOVE LK1-DATA-NOVA TO W01N0600 */
                _.Move(AREA_DE_WORK.LK1_PARM.LK1_DATA_NOVA, AREA_DE_WORK.W01N0600);

                /*" -1305- MOVE W01N0200 TO WDATA-DIA */
                _.Move(AREA_DE_WORK.W01N0600.W01N0200, AREA_DE_WORK.WDATA.WDATA_DIA);

                /*" -1306- MOVE W02N0200 TO WDATA-MES */
                _.Move(AREA_DE_WORK.W01N0600.W02N0200, AREA_DE_WORK.WDATA.WDATA_MES);

                /*" -1307- MOVE W03N0200 TO WDATA-ANO */
                _.Move(AREA_DE_WORK.W01N0600.W03N0200, AREA_DE_WORK.WDATA.WDATA_ANO);

                /*" -1308- MOVE WDATA TO DATA-NOVA */
                _.Move(AREA_DE_WORK.WDATA, AREA_DE_WORK.DATA_NOVA);

                /*" -1309- IF V1MCOB-DTQITBCO NOT GREATER DATA-NOVA */

                if (V1MCOB_DTQITBCO <= AREA_DE_WORK.DATA_NOVA)
                {

                    /*" -1310- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
                    _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

                    /*" -1312- GO TO R1350-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1328- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

            /*" -1328- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA. */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-DIF-IGUAL-ZERO-SECTION */
        private void R1400_00_DIF_IGUAL_ZERO_SECTION()
        {
            /*" -1345- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1346- MOVE SPACES TO WCHV-BAIXA FLAG-BAIXA. */
            _.Move("", AREA_DE_WORK.WCHV_BAIXA, AREA_DE_WORK.FLAG_BAIXA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-DIF-MENOR-ZERO-SECTION */
        private void R1500_00_DIF_MENOR_ZERO_SECTION()
        {
            /*" -1361- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1363- PERFORM R2300-00-SELECT-V1PARAMETRO */

            R2300_00_SELECT_V1PARAMETRO_SECTION();

            /*" -1364- MOVE V1MCOB-DTQITBCO TO WHOST-DTINIVIG */
            _.Move(V1MCOB_DTQITBCO, WHOST_DTINIVIG);

            /*" -1366- MOVE V1PARM-CODUNIMO TO WHOST-COD-MOEDA */
            _.Move(V1PARM_CODUNIMO, WHOST_COD_MOEDA);

            /*" -1370- PERFORM R2200-00-SELECT-V1MOEDA */

            R2200_00_SELECT_V1MOEDA_SECTION();

            /*" -1376- COMPUTE WVALOR-ACEITA = V1PARM-DIFPRM * V1MOED-VLCRUZAD */
            AREA_DE_WORK.WVALOR_ACEITA.Value = V1PARM_DIFPRM * V1MOED_VLCRUZAD;

            /*" -1378- MOVE WVALOR-DIFEREN TO WVALOR-DIFERSIN */
            _.Move(AREA_DE_WORK.WVALOR_DIFEREN, AREA_DE_WORK.WVALOR_DIFERSIN);

            /*" -1379- IF WVALOR-DIFERSIN NOT GREATER WVALOR-ACEITA */

            if (AREA_DE_WORK.WVALOR_DIFERSIN <= AREA_DE_WORK.WVALOR_ACEITA)
            {

                /*" -1381- MOVE ' ' TO WCHV-BAIXA FLAG-BAIXA */
                _.Move(" ", AREA_DE_WORK.WCHV_BAIXA, AREA_DE_WORK.FLAG_BAIXA);

                /*" -1382- ELSE */
            }
            else
            {


                /*" -1383- MOVE '1' TO V0FOLP-CDERRO06 */
                _.Move("1", V0FOLP_CDERRO06);

                /*" -1384- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -1386- MOVE 'VALOR DIVERGENTE     ' TO W1MCOB-NOME */
                _.Move("VALOR DIVERGENTE     ", W1MCOB_NOME);

                /*" -1386- PERFORM R1700-00-TRATA-CREDITO-RESTIT. */

                R1700_00_TRATA_CREDITO_RESTIT_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-DIF-MAIOR-ZERO-SECTION */
        private void R1600_00_DIF_MAIOR_ZERO_SECTION()
        {
            /*" -1403- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1405- PERFORM R2300-00-SELECT-V1PARAMETRO */

            R2300_00_SELECT_V1PARAMETRO_SECTION();

            /*" -1406- MOVE V1MCOB-DTQITBCO TO WHOST-DTINIVIG */
            _.Move(V1MCOB_DTQITBCO, WHOST_DTINIVIG);

            /*" -1408- MOVE V1PARM-CODUNIMO TO WHOST-COD-MOEDA */
            _.Move(V1PARM_CODUNIMO, WHOST_COD_MOEDA);

            /*" -1410- PERFORM R2200-00-SELECT-V1MOEDA */

            R2200_00_SELECT_V1MOEDA_SECTION();

            /*" -1412- COMPUTE WVALOR-ACEITA = V1PARM-DIFPRM * V1MOED-VLCRUZAD */
            AREA_DE_WORK.WVALOR_ACEITA.Value = V1PARM_DIFPRM * V1MOED_VLCRUZAD;

            /*" -1424- MOVE WVALOR-DIFEREN TO WVALOR-DIFERSIN */
            _.Move(AREA_DE_WORK.WVALOR_DIFEREN, AREA_DE_WORK.WVALOR_DIFERSIN);

            /*" -1425- MOVE ' ' TO WCHV-BAIXA FLAG-BAIXA. */
            _.Move(" ", AREA_DE_WORK.WCHV_BAIXA, AREA_DE_WORK.FLAG_BAIXA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-TRATA-CREDITO-RESTIT-SECTION */
        private void R1700_00_TRATA_CREDITO_RESTIT_SECTION()
        {
            /*" -1441- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1443- PERFORM R1705-00-SUMARIZA-NOTASCRED. */

            R1705_00_SUMARIZA_NOTASCRED_SECTION();

            /*" -1444- IF V1NOTA-VALCREDR-IX EQUAL ZEROS */

            if (V1NOTA_VALCREDR_IX == 00)
            {

                /*" -1445- MOVE ' ' TO FLAG-BAIXA */
                _.Move(" ", AREA_DE_WORK.FLAG_BAIXA);

                /*" -1445- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1700_10_CALCULA_NOTA */

            R1700_10_CALCULA_NOTA();

        }

        [StopWatch]
        /*" R1700-10-CALCULA-NOTA */
        private void R1700_10_CALCULA_NOTA(bool isPerform = false)
        {
            /*" -1450- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

            /*" -1452- MOVE V1MCOB-DTQITBCO TO WHOST-DTINIVIG */
            _.Move(V1MCOB_DTQITBCO, WHOST_DTINIVIG);

            /*" -1454- PERFORM R2200-00-SELECT-V1MOEDA */

            R2200_00_SELECT_V1MOEDA_SECTION();

            /*" -1462- COMPUTE W-VALCREDR ROUNDED = V1NOTA-VALCREDR-IX * V1MOED-VLCRUZAD */
            AREA_DE_WORK.W_VALCREDR.Value = V1NOTA_VALCREDR_IX * V1MOED_VLCRUZAD;

            /*" -1463- IF WVALOR-DIFERSIN EQUAL W-VALCREDR */

            if (AREA_DE_WORK.WVALOR_DIFERSIN == AREA_DE_WORK.W_VALCREDR)
            {

                /*" -1465- COMPUTE V1MCOB-VALTIT = V1MCOB-VALTIT + W-VALCREDR */
                V1MCOB_VALTIT.Value = V1MCOB_VALTIT + AREA_DE_WORK.W_VALCREDR;

                /*" -1467- PERFORM R1750-00-BAIXA-CREDITO-RESTIT */

                R1750_00_BAIXA_CREDITO_RESTIT_SECTION();

                /*" -1468- MOVE ' ' TO WCHV-BAIXA */
                _.Move(" ", AREA_DE_WORK.WCHV_BAIXA);

                /*" -1469- MOVE 'S' TO FLAG-BAIXA */
                _.Move("S", AREA_DE_WORK.FLAG_BAIXA);

                /*" -1469- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1700-20-VERIFICA-LIMITE */
        private void R1700_20_VERIFICA_LIMITE(bool isPerform = false)
        {
            /*" -1475- COMPUTE WVALOR-DIFEREN2 = WVALOR-DIFERSIN - W-VALCREDR */
            AREA_DE_WORK.WVALOR_DIFEREN2.Value = AREA_DE_WORK.WVALOR_DIFERSIN - AREA_DE_WORK.W_VALCREDR;

            /*" -1479- MOVE WVALOR-DIFEREN2 TO WVALOR-DIFERSIN2 */
            _.Move(AREA_DE_WORK.WVALOR_DIFEREN2, AREA_DE_WORK.WVALOR_DIFERSIN2);

            /*" -1480- IF WVALOR-DIFERSIN2 NOT GREATER WVALOR-ACEITA */

            if (AREA_DE_WORK.WVALOR_DIFERSIN2 <= AREA_DE_WORK.WVALOR_ACEITA)
            {

                /*" -1482- COMPUTE V1MCOB-VALTIT = V1MCOB-VALTIT + W-VALCREDR */
                V1MCOB_VALTIT.Value = V1MCOB_VALTIT + AREA_DE_WORK.W_VALCREDR;

                /*" -1483- PERFORM R1750-00-BAIXA-CREDITO-RESTIT */

                R1750_00_BAIXA_CREDITO_RESTIT_SECTION();

                /*" -1484- MOVE 'C' TO FLAG-BAIXA */
                _.Move("C", AREA_DE_WORK.FLAG_BAIXA);

                /*" -1484- MOVE ' ' TO WCHV-BAIXA. */
                _.Move(" ", AREA_DE_WORK.WCHV_BAIXA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1705-00-SUMARIZA-NOTASCRED-SECTION */
        private void R1705_00_SUMARIZA_NOTASCRED_SECTION()
        {
            /*" -1495- MOVE '1705' TO WNR-EXEC-SQL. */
            _.Move("1705", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1506- PERFORM R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1 */

            R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1();

            /*" -1509- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1513- DISPLAY 'R1705-00 (ERRO NAO PREVISTO-SUMARIZA NOTASCRED)' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R1705-00 (ERRO NAO PREVISTO-SUMARIZA NOTASCRED) {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -1515- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1516- IF SQL-VALCREDR LESS ZEROS */

            if (SQL_VALCREDR < 00)
            {

                /*" -1516- MOVE ZEROS TO V1NOTA-VALCREDR-IX. */
                _.Move(0, V1NOTA_VALCREDR_IX);
            }


        }

        [StopWatch]
        /*" R1705-00-SUMARIZA-NOTASCRED-DB-SELECT-1 */
        public void R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1()
        {
            /*" -1506- EXEC SQL SELECT SUM(VALCREDR_IX), COUNT(*) INTO :V1NOTA-VALCREDR-IX:SQL-VALCREDR, :W1-COUNT FROM SEGUROS.V1NOTASCRED WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOSC = :V1PARC-NRENDOS AND NRPARCELC = :V1PARC-NRPARCEL AND SITUACAO = '0' WITH UR END-EXEC. */

            var r1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1 = new R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1.Execute(r1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NOTA_VALCREDR_IX, V1NOTA_VALCREDR_IX);
                _.Move(executed_1.SQL_VALCREDR, SQL_VALCREDR);
                _.Move(executed_1.W1_COUNT, W1_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1705_99_SAIDA*/

        [StopWatch]
        /*" R1715-00-CORRECAO-NOTACRED-SECTION */
        private void R1715_00_CORRECAO_NOTACRED_SECTION()
        {
            /*" -1527- MOVE '1715' TO WNR-EXEC-SQL. */
            _.Move("1715", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1538- PERFORM R1715_00_CORRECAO_NOTACRED_DB_SELECT_1 */

            R1715_00_CORRECAO_NOTACRED_DB_SELECT_1();

            /*" -1541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1547- DISPLAY 'R1715-00 (ERRO SOMATORIO DA V1HISTNOTCRE)...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL ' ' V1NOTA-NRENDOSR ' ' V1NOTA-NRPARCELR ' ' */

                $"R1715-00 (ERRO SOMATORIO DA V1HISTNOTCRE)...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL} {V1NOTA_NRENDOSR} {V1NOTA_NRPARCELR} "
                .Display();

                /*" -1549- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1550- IF SQL-VALCREDR LESS ZEROS */

            if (SQL_VALCREDR < 00)
            {

                /*" -1550- MOVE ZEROS TO W1-VALCREDR. */
                _.Move(0, W1_VALCREDR);
            }


            /*" -0- FLUXCONTROL_PERFORM R1715_20_VALOR_CORRECAO */

            R1715_20_VALOR_CORRECAO();

        }

        [StopWatch]
        /*" R1715-00-CORRECAO-NOTACRED-DB-SELECT-1 */
        public void R1715_00_CORRECAO_NOTACRED_DB_SELECT_1()
        {
            /*" -1538- EXEC SQL SELECT SUM(VALCREDR) INTO :W1-VALCREDR:SQL-VALCREDR FROM SEGUROS.V1HISTNOTCRE WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOSC = :V1PARC-NRENDOS AND NRPARCELC = :V1PARC-NRPARCEL AND NRENDOSR = :V1NOTA-NRENDOSR AND NRPARCELR = :V1NOTA-NRPARCELR AND OPERACAO IN (101 , 801) WITH UR END-EXEC. */

            var r1715_00_CORRECAO_NOTACRED_DB_SELECT_1_Query1 = new R1715_00_CORRECAO_NOTACRED_DB_SELECT_1_Query1()
            {
                V1NOTA_NRPARCELR = V1NOTA_NRPARCELR.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1NOTA_NRENDOSR = V1NOTA_NRENDOSR.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R1715_00_CORRECAO_NOTACRED_DB_SELECT_1_Query1.Execute(r1715_00_CORRECAO_NOTACRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1_VALCREDR, W1_VALCREDR);
                _.Move(executed_1.SQL_VALCREDR, SQL_VALCREDR);
            }


        }

        [StopWatch]
        /*" R1715-20-VALOR-CORRECAO */
        private void R1715_20_VALOR_CORRECAO(bool isPerform = false)
        {
            /*" -1557- COMPUTE W3-VALCREDR = W-VALCREDR - W1-VALCREDR. */
            AREA_DE_WORK.W3_VALCREDR.Value = AREA_DE_WORK.W_VALCREDR - W1_VALCREDR;

            /*" -1559- PERFORM R1730-00-ACESSA-HISTNOTCRE */

            R1730_00_ACESSA_HISTNOTCRE_SECTION();

            /*" -1562- COMPUTE HNOTCRE-OCORHIST = HNOTCRE-OCORHIST + 1. */
            HNOTCRE_OCORHIST.Value = HNOTCRE_OCORHIST + 1;

            /*" -1564- MOVE ZEROS TO HNOTCRE-COD-EMP */
            _.Move(0, HNOTCRE_COD_EMP);

            /*" -1565- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1566- MOVE WS-HH-TIME TO WS-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

            /*" -1567- MOVE WS-MM-TIME TO WS-MINUTO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

            /*" -1570- MOVE WS-SS-TIME TO WS-SEGUNDO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

            /*" -1572- MOVE WTIME-DAY TO HNOTCRE-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAY, HNOTCRE_HORAOPER);

            /*" -1573- MOVE W3-VALCREDR TO HNOTCRE-VALCREDR */
            _.Move(AREA_DE_WORK.W3_VALCREDR, HNOTCRE_VALCREDR);

            /*" -1574- MOVE ZEROS TO HNOTCRE-VLPAGTO */
            _.Move(0, HNOTCRE_VLPAGTO);

            /*" -1575- MOVE '0' TO HNOTCRE-SITCONTB */
            _.Move("0", HNOTCRE_SITCONTB);

            /*" -1576- MOVE 0 TO HNOTCRE-NUMCHQ */
            _.Move(0, HNOTCRE_NUMCHQ);

            /*" -1578- MOVE 802 TO HNOTCRE-OPERACAO. */
            _.Move(802, HNOTCRE_OPERACAO);

            /*" -1578- PERFORM R1715-30-INSERE-CORRECAO */

            R1715_30_INSERE_CORRECAO(true);

        }

        [StopWatch]
        /*" R1715-30-INSERE-CORRECAO */
        private void R1715_30_INSERE_CORRECAO(bool isPerform = false)
        {
            /*" -1584- MOVE '1715' TO WNR-EXEC-SQL. */
            _.Move("1715", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1585- IF HNOTCRE-VALCREDR EQUAL ZEROS */

            if (HNOTCRE_VALCREDR == 00)
            {

                /*" -1587- COMPUTE HNOTCRE-OCORHIST = HNOTCRE-OCORHIST - 1 */
                HNOTCRE_OCORHIST.Value = HNOTCRE_OCORHIST - 1;

                /*" -1596- GO TO R1715-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1715_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1616- PERFORM R1715_30_INSERE_CORRECAO_DB_INSERT_1 */

            R1715_30_INSERE_CORRECAO_DB_INSERT_1();

            /*" -1619- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1624- DISPLAY 'R1715-30 (REGISTRO DUPLICADO) ... ' ' ' V1MCOB-NUM-APOL ' ' V1MCOB-NRENDOS ' ' V1MCOB-NRPARCEL ' ' HNOTCRE-OCORHIST */

                $"R1715-30 (REGISTRO DUPLICADO) ...  {V1MCOB_NUM_APOL} {V1MCOB_NRENDOS} {V1MCOB_NRPARCEL} {HNOTCRE_OCORHIST}"
                .Display();

                /*" -1626- COMPUTE HNOTCRE-OCORHIST = HNOTCRE-OCORHIST - 1 */
                HNOTCRE_OCORHIST.Value = HNOTCRE_OCORHIST - 1;

                /*" -1628- GO TO R1715-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1715_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1629- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1634- DISPLAY 'R1715-30 (PROBLEMAS NA INSERCAO) ... ' ' ' V1MCOB-NUM-APOL ' ' V1MCOB-NRENDOS ' ' V1MCOB-NRPARCEL ' ' HNOTCRE-OCORHIST */

                $"R1715-30 (PROBLEMAS NA INSERCAO) ...  {V1MCOB_NUM_APOL} {V1MCOB_NRENDOS} {V1MCOB_NRPARCEL} {HNOTCRE_OCORHIST}"
                .Display();

                /*" -1636- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1636- ADD 1 TO AC-I-V0HISTNOTCRE. */
            AREA_DE_WORK.AC_I_V0HISTNOTCRE.Value = AREA_DE_WORK.AC_I_V0HISTNOTCRE + 1;

        }

        [StopWatch]
        /*" R1715-30-INSERE-CORRECAO-DB-INSERT-1 */
        public void R1715_30_INSERE_CORRECAO_DB_INSERT_1()
        {
            /*" -1616- EXEC SQL INSERT INTO SEGUROS.V0HISTNOTCRE VALUES (:HNOTCRE-COD-EMP , :V1MCOB-NUM-APOL , :V1NOTA-NRENDOSR , :V1NOTA-NRPARCELR , :V1MCOB-NRENDOS , :V1MCOB-NRPARCEL , :HNOTCRE-OCORHIST , :HNOTCRE-OPERACAO , :V1SIST-DTMOVABE , :HNOTCRE-HORAOPER , :HNOTCRE-VALCREDR , :HNOTCRE-VLPAGTO , :V1NOTA-DTVENCTO , :HNOTCRE-SITCONTB , :V1MCOB-BANCO , :V1MCOB-AGENCIA , :HNOTCRE-NUMCHQ , CURRENT TIMESTAMP) END-EXEC. */

            var r1715_30_INSERE_CORRECAO_DB_INSERT_1_Insert1 = new R1715_30_INSERE_CORRECAO_DB_INSERT_1_Insert1()
            {
                HNOTCRE_COD_EMP = HNOTCRE_COD_EMP.ToString(),
                V1MCOB_NUM_APOL = V1MCOB_NUM_APOL.ToString(),
                V1NOTA_NRENDOSR = V1NOTA_NRENDOSR.ToString(),
                V1NOTA_NRPARCELR = V1NOTA_NRPARCELR.ToString(),
                V1MCOB_NRENDOS = V1MCOB_NRENDOS.ToString(),
                V1MCOB_NRPARCEL = V1MCOB_NRPARCEL.ToString(),
                HNOTCRE_OCORHIST = HNOTCRE_OCORHIST.ToString(),
                HNOTCRE_OPERACAO = HNOTCRE_OPERACAO.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                HNOTCRE_HORAOPER = HNOTCRE_HORAOPER.ToString(),
                HNOTCRE_VALCREDR = HNOTCRE_VALCREDR.ToString(),
                HNOTCRE_VLPAGTO = HNOTCRE_VLPAGTO.ToString(),
                V1NOTA_DTVENCTO = V1NOTA_DTVENCTO.ToString(),
                HNOTCRE_SITCONTB = HNOTCRE_SITCONTB.ToString(),
                V1MCOB_BANCO = V1MCOB_BANCO.ToString(),
                V1MCOB_AGENCIA = V1MCOB_AGENCIA.ToString(),
                HNOTCRE_NUMCHQ = HNOTCRE_NUMCHQ.ToString(),
            };

            R1715_30_INSERE_CORRECAO_DB_INSERT_1_Insert1.Execute(r1715_30_INSERE_CORRECAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1715_99_SAIDA*/

        [StopWatch]
        /*" R1720-00-ATUALIZA-NOTASCRED-SECTION */
        private void R1720_00_ATUALIZA_NOTASCRED_SECTION()
        {
            /*" -1649- MOVE '1720' TO WNR-EXEC-SQL. */
            _.Move("1720", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1659- PERFORM R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1 */

            R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1();

            /*" -1662- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1666- DISPLAY 'R1720-00 (PROBLEMAS UPDATE V0NOTASCRED).. ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R1720-00 (PROBLEMAS UPDATE V0NOTASCRED)..  {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -1668- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1668- ADD 1 TO AC-U-V0NOTASCRED. */
            AREA_DE_WORK.AC_U_V0NOTASCRED.Value = AREA_DE_WORK.AC_U_V0NOTASCRED + 1;

        }

        [StopWatch]
        /*" R1720-00-ATUALIZA-NOTASCRED-DB-UPDATE-1 */
        public void R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1()
        {
            /*" -1659- EXEC SQL UPDATE SEGUROS.V0NOTASCRED SET SITUACAO = '1' , OCORHIST = :HNOTCRE-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOSC = :V1PARC-NRENDOS AND NRPARCELC = :V1PARC-NRPARCEL AND NRENDOSR = :V1NOTA-NRENDOSR AND NRPARCELR = :V1NOTA-NRPARCELR END-EXEC. */

            var r1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1 = new R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1()
            {
                HNOTCRE_OCORHIST = HNOTCRE_OCORHIST.ToString(),
                V1NOTA_NRPARCELR = V1NOTA_NRPARCELR.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1NOTA_NRENDOSR = V1NOTA_NRENDOSR.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1.Execute(r1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1720_99_SAIDA*/

        [StopWatch]
        /*" R1730-00-ACESSA-HISTNOTCRE-SECTION */
        private void R1730_00_ACESSA_HISTNOTCRE_SECTION()
        {
            /*" -1679- MOVE '1730' TO WNR-EXEC-SQL. */
            _.Move("1730", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1689- PERFORM R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1 */

            R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1();

            /*" -1692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1699- DISPLAY 'R1730-00 (ERRO NAO PREVISTO-SELECT HISTNOTCRE ') ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL ' ' V1NOTA-NRENDOSR ' ' V1NOTA-NRPARCELR ' ' */

                $"R1730-00 (ERRO NAO PREVISTO-SELECT HISTNOTCRE ) V1PARC-NUM-APOL  V1PARC-NRENDOS  V1PARC-NRPARCEL  V1NOTA-NRENDOSR  V1NOTA-NRPARCELR "
                .Display();

                /*" -1699- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1730-00-ACESSA-HISTNOTCRE-DB-SELECT-1 */
        public void R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1()
        {
            /*" -1689- EXEC SQL SELECT VALUE(MAX(OCORHIST),0) INTO :HNOTCRE-OCORHIST FROM SEGUROS.V1HISTNOTCRE WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOSC = :V1PARC-NRENDOS AND NRPARCELC = :V1PARC-NRPARCEL AND NRENDOSR = :V1NOTA-NRENDOSR AND NRPARCELR = :V1NOTA-NRPARCELR WITH UR END-EXEC. */

            var r1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1 = new R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1()
            {
                V1NOTA_NRPARCELR = V1NOTA_NRPARCELR.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1NOTA_NRENDOSR = V1NOTA_NRENDOSR.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1.Execute(r1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HNOTCRE_OCORHIST, HNOTCRE_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1730_99_SAIDA*/

        [StopWatch]
        /*" R1740-00-INSERI-HISTNOTCRE-SECTION */
        private void R1740_00_INSERI_HISTNOTCRE_SECTION()
        {
            /*" -1710- MOVE '1740' TO WNR-EXEC-SQL. */
            _.Move("1740", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1713- COMPUTE HNOTCRE-OCORHIST = HNOTCRE-OCORHIST + 1 */
            HNOTCRE_OCORHIST.Value = HNOTCRE_OCORHIST + 1;

            /*" -1715- MOVE ZEROS TO HNOTCRE-COD-EMP */
            _.Move(0, HNOTCRE_COD_EMP);

            /*" -1716- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1717- MOVE WS-HH-TIME TO WS-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

            /*" -1718- MOVE WS-MM-TIME TO WS-MINUTO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

            /*" -1721- MOVE WS-SS-TIME TO WS-SEGUNDO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

            /*" -1723- MOVE WTIME-DAY TO HNOTCRE-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAY, HNOTCRE_HORAOPER);

            /*" -1724- MOVE W-VALCREDR TO HNOTCRE-VALCREDR */
            _.Move(AREA_DE_WORK.W_VALCREDR, HNOTCRE_VALCREDR);

            /*" -1725- MOVE '0' TO HNOTCRE-SITCONTB */
            _.Move("0", HNOTCRE_SITCONTB);

            /*" -1734- MOVE 0 TO HNOTCRE-NUMCHQ */
            _.Move(0, HNOTCRE_NUMCHQ);

            /*" -1754- PERFORM R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1 */

            R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1();

            /*" -1757- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1762- DISPLAY 'R1740-00 (REGISTRO DUPLICADO) ... ' ' ' V1MCOB-NUM-APOL ' ' V1MCOB-NRENDOS ' ' V1MCOB-NRPARCEL ' ' HNOTCRE-OCORHIST */

                $"R1740-00 (REGISTRO DUPLICADO) ...  {V1MCOB_NUM_APOL} {V1MCOB_NRENDOS} {V1MCOB_NRPARCEL} {HNOTCRE_OCORHIST}"
                .Display();

                /*" -1764- COMPUTE HNOTCRE-OCORHIST = HNOTCRE-OCORHIST - 1 */
                HNOTCRE_OCORHIST.Value = HNOTCRE_OCORHIST - 1;

                /*" -1766- GO TO R1740-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1740_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1767- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1772- DISPLAY 'R1740-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1MCOB-NUM-APOL ' ' V1MCOB-NRENDOS ' ' V1MCOB-NRPARCEL ' ' HNOTCRE-OCORHIST */

                $"R1740-00 (PROBLEMAS NA INSERCAO) ...  {V1MCOB_NUM_APOL} {V1MCOB_NRENDOS} {V1MCOB_NRPARCEL} {HNOTCRE_OCORHIST}"
                .Display();

                /*" -1774- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1774- ADD 1 TO AC-I-V0HISTNOTCRE. */
            AREA_DE_WORK.AC_I_V0HISTNOTCRE.Value = AREA_DE_WORK.AC_I_V0HISTNOTCRE + 1;

            /*" -0- FLUXCONTROL_PERFORM R1740_90_ATUALIZA */

            R1740_90_ATUALIZA();

        }

        [StopWatch]
        /*" R1740-00-INSERI-HISTNOTCRE-DB-INSERT-1 */
        public void R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1()
        {
            /*" -1754- EXEC SQL INSERT INTO SEGUROS.V0HISTNOTCRE VALUES (:HNOTCRE-COD-EMP , :V1MCOB-NUM-APOL , :V1NOTA-NRENDOSR , :V1NOTA-NRPARCELR , :V1MCOB-NRENDOS , :V1MCOB-NRPARCEL , :HNOTCRE-OCORHIST , :HNOTCRE-OPERACAO , :V1SIST-DTMOVABE , :HNOTCRE-HORAOPER , :HNOTCRE-VALCREDR , :HNOTCRE-VLPAGTO , :V1NOTA-DTVENCTO , :HNOTCRE-SITCONTB , :V1MCOB-BANCO , :V1MCOB-AGENCIA , :HNOTCRE-NUMCHQ , CURRENT TIMESTAMP) END-EXEC. */

            var r1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1 = new R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1()
            {
                HNOTCRE_COD_EMP = HNOTCRE_COD_EMP.ToString(),
                V1MCOB_NUM_APOL = V1MCOB_NUM_APOL.ToString(),
                V1NOTA_NRENDOSR = V1NOTA_NRENDOSR.ToString(),
                V1NOTA_NRPARCELR = V1NOTA_NRPARCELR.ToString(),
                V1MCOB_NRENDOS = V1MCOB_NRENDOS.ToString(),
                V1MCOB_NRPARCEL = V1MCOB_NRPARCEL.ToString(),
                HNOTCRE_OCORHIST = HNOTCRE_OCORHIST.ToString(),
                HNOTCRE_OPERACAO = HNOTCRE_OPERACAO.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                HNOTCRE_HORAOPER = HNOTCRE_HORAOPER.ToString(),
                HNOTCRE_VALCREDR = HNOTCRE_VALCREDR.ToString(),
                HNOTCRE_VLPAGTO = HNOTCRE_VLPAGTO.ToString(),
                V1NOTA_DTVENCTO = V1NOTA_DTVENCTO.ToString(),
                HNOTCRE_SITCONTB = HNOTCRE_SITCONTB.ToString(),
                V1MCOB_BANCO = V1MCOB_BANCO.ToString(),
                V1MCOB_AGENCIA = V1MCOB_AGENCIA.ToString(),
                HNOTCRE_NUMCHQ = HNOTCRE_NUMCHQ.ToString(),
            };

            R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1.Execute(r1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1740-90-ATUALIZA */
        private void R1740_90_ATUALIZA(bool isPerform = false)
        {
            /*" -1778- PERFORM R1720-00-ATUALIZA-NOTASCRED. */

            R1720_00_ATUALIZA_NOTASCRED_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1740_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-BAIXA-CREDITO-RESTIT-SECTION */
        private void R1750_00_BAIXA_CREDITO_RESTIT_SECTION()
        {
            /*" -1789- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1791- PERFORM R1760-00-DECLARE-NOTASCRED. */

            R1760_00_DECLARE_NOTASCRED_SECTION();

            /*" -1793- PERFORM R1770-00-FETCH-NOTASCRED. */

            R1770_00_FETCH_NOTASCRED_SECTION();

            /*" -1794- PERFORM R1800-00-PROCESSA-NOTASCRED UNTIL WFIM-NOTACRED NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_NOTACRED.IsEmpty()))
            {

                R1800_00_PROCESSA_NOTASCRED_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R1760-00-DECLARE-NOTASCRED-SECTION */
        private void R1760_00_DECLARE_NOTASCRED_SECTION()
        {
            /*" -1804- MOVE '1760' TO WNR-EXEC-SQL. */
            _.Move("1760", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1806- MOVE SPACES TO WFIM-NOTACRED. */
            _.Move("", AREA_DE_WORK.WFIM_NOTACRED);

            /*" -1817- PERFORM R1760_00_DECLARE_NOTASCRED_DB_DECLARE_1 */

            R1760_00_DECLARE_NOTASCRED_DB_DECLARE_1();

            /*" -1819- PERFORM R1760_00_DECLARE_NOTASCRED_DB_OPEN_1 */

            R1760_00_DECLARE_NOTASCRED_DB_OPEN_1();

            /*" -1822- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1826- DISPLAY 'R1760-00 (ERRO NAO PREVISTO-DECLARE NOTASCRED)' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R1760-00 (ERRO NAO PREVISTO-DECLARE NOTASCRED) {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -1826- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1760-00-DECLARE-NOTASCRED-DB-OPEN-1 */
        public void R1760_00_DECLARE_NOTASCRED_DB_OPEN_1()
        {
            /*" -1819- EXEC SQL OPEN V1NOTACRED END-EXEC. */

            V1NOTACRED.Open();

        }

        [StopWatch]
        /*" R3450-00-DECLARE-AU071-DB-DECLARE-1 */
        public void R3450_00_DECLARE_AU071_DB_DECLARE_1()
        {
            /*" -2777- EXEC SQL DECLARE C1AU071 CURSOR FOR SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.DTA_VENCTO ,A.NUM_VENCTO ,A.VLR_JUROS ,A.VLR_MULTA ,B.DIA_SEMANA ,B.FERIADO FROM SEGUROS.PARCELA_AUTO_COMPL A ,SEGUROS.CALENDARIO B WHERE A.NUM_APOLICE = :V1PARC-NUM-APOL AND A.NUM_ENDOSSO = :V1PARC-NRENDOS AND A.NUM_PARCELA = :V1PARC-NRPARCEL AND A.DTA_VENCTO = B.DATA_CALENDARIO ORDER BY A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.NUM_VENCTO WITH UR END-EXEC. */
            C1AU071 = new CB0003B_C1AU071(true);
            string GetQuery_C1AU071()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.DTA_VENCTO 
							,A.NUM_VENCTO 
							,A.VLR_JUROS 
							,A.VLR_MULTA 
							,B.DIA_SEMANA 
							,B.FERIADO 
							FROM SEGUROS.PARCELA_AUTO_COMPL A 
							,SEGUROS.CALENDARIO B 
							WHERE A.NUM_APOLICE = '{V1PARC_NUM_APOL}' 
							AND A.NUM_ENDOSSO = '{V1PARC_NRENDOS}' 
							AND A.NUM_PARCELA = '{V1PARC_NRPARCEL}' 
							AND A.DTA_VENCTO = B.DATA_CALENDARIO 
							ORDER BY A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.NUM_VENCTO";

                return query;
            }
            C1AU071.GetQueryEvent += GetQuery_C1AU071;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1760_99_SAIDA*/

        [StopWatch]
        /*" R1770-00-FETCH-NOTASCRED-SECTION */
        private void R1770_00_FETCH_NOTASCRED_SECTION()
        {
            /*" -1837- MOVE '1770' TO WNR-EXEC-SQL. */
            _.Move("1770", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1842- PERFORM R1770_00_FETCH_NOTASCRED_DB_FETCH_1 */

            R1770_00_FETCH_NOTASCRED_DB_FETCH_1();

            /*" -1845- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1845- PERFORM R1770_00_FETCH_NOTASCRED_DB_CLOSE_1 */

                R1770_00_FETCH_NOTASCRED_DB_CLOSE_1();

                /*" -1847- MOVE 'S' TO WFIM-NOTACRED */
                _.Move("S", AREA_DE_WORK.WFIM_NOTACRED);

                /*" -1849- GO TO R1770-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1770_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1850- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1854- DISPLAY 'R1770-00 (ERRO NAO PREVISTO-FETCH  NOTASCRED)' ' ' V1MCOB-NUM-APOL ' ' V1MCOB-NRENDOS ' ' V1MCOB-NRPARCEL */

                $"R1770-00 (ERRO NAO PREVISTO-FETCH  NOTASCRED) {V1MCOB_NUM_APOL} {V1MCOB_NRENDOS} {V1MCOB_NRPARCEL}"
                .Display();

                /*" -1854- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1770-00-FETCH-NOTASCRED-DB-FETCH-1 */
        public void R1770_00_FETCH_NOTASCRED_DB_FETCH_1()
        {
            /*" -1842- EXEC SQL FETCH V1NOTACRED INTO :V1NOTA-NRENDOSR , :V1NOTA-NRPARCELR , :V1NOTA-DTVENCTO , :V1NOTA-VALCREDR-IX END-EXEC. */

            if (V1NOTACRED.Fetch())
            {
                _.Move(V1NOTACRED.V1NOTA_NRENDOSR, V1NOTA_NRENDOSR);
                _.Move(V1NOTACRED.V1NOTA_NRPARCELR, V1NOTA_NRPARCELR);
                _.Move(V1NOTACRED.V1NOTA_DTVENCTO, V1NOTA_DTVENCTO);
                _.Move(V1NOTACRED.V1NOTA_VALCREDR_IX, V1NOTA_VALCREDR_IX);
            }

        }

        [StopWatch]
        /*" R1770-00-FETCH-NOTASCRED-DB-CLOSE-1 */
        public void R1770_00_FETCH_NOTASCRED_DB_CLOSE_1()
        {
            /*" -1845- EXEC SQL CLOSE V1NOTACRED END-EXEC */

            V1NOTACRED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1770_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-PROCESSA-NOTASCRED-SECTION */
        private void R1800_00_PROCESSA_NOTASCRED_SECTION()
        {
            /*" -1865- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1866- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

            /*" -1867- MOVE V1MCOB-DTQITBCO TO WHOST-DTINIVIG */
            _.Move(V1MCOB_DTQITBCO, WHOST_DTINIVIG);

            /*" -1869- PERFORM R2200-00-SELECT-V1MOEDA */

            R2200_00_SELECT_V1MOEDA_SECTION();

            /*" -1872- COMPUTE W-VALCREDR ROUNDED = V1NOTA-VALCREDR-IX * V1MOED-VLCRUZAD. */
            AREA_DE_WORK.W_VALCREDR.Value = V1NOTA_VALCREDR_IX * V1MOED_VLCRUZAD;

            /*" -1876- PERFORM R1715-00-CORRECAO-NOTACRED. */

            R1715_00_CORRECAO_NOTACRED_SECTION();

            /*" -1877- IF WVALOR-DIFERSIN EQUAL W-VALCREDR */

            if (AREA_DE_WORK.WVALOR_DIFERSIN == AREA_DE_WORK.W_VALCREDR)
            {

                /*" -1878- MOVE 0231 TO HNOTCRE-OPERACAO */
                _.Move(0231, HNOTCRE_OPERACAO);

                /*" -1879- MOVE W-VALCREDR TO HNOTCRE-VLPAGTO */
                _.Move(AREA_DE_WORK.W_VALCREDR, HNOTCRE_VLPAGTO);

                /*" -1880- PERFORM R1740-00-INSERI-HISTNOTCRE */

                R1740_00_INSERI_HISTNOTCRE_SECTION();

                /*" -1881- MOVE 'S' TO WFIM-NOTACRED */
                _.Move("S", AREA_DE_WORK.WFIM_NOTACRED);

                /*" -1881- PERFORM R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_1 */

                R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_1();

                /*" -1886- GO TO R1800-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1887- IF WVALOR-DIFERSIN LESS W-VALCREDR */

            if (AREA_DE_WORK.WVALOR_DIFERSIN < AREA_DE_WORK.W_VALCREDR)
            {

                /*" -1888- MOVE 0241 TO HNOTCRE-OPERACAO */
                _.Move(0241, HNOTCRE_OPERACAO);

                /*" -1889- MOVE WVALOR-DIFERSIN TO HNOTCRE-VLPAGTO */
                _.Move(AREA_DE_WORK.WVALOR_DIFERSIN, HNOTCRE_VLPAGTO);

                /*" -1890- PERFORM R1740-00-INSERI-HISTNOTCRE */

                R1740_00_INSERI_HISTNOTCRE_SECTION();

                /*" -1891- MOVE 'S' TO WFIM-NOTACRED */
                _.Move("S", AREA_DE_WORK.WFIM_NOTACRED);

                /*" -1891- PERFORM R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_2 */

                R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_2();

                /*" -1896- GO TO R1800-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1897- IF W1-COUNT GREATER 1 */

            if (W1_COUNT > 1)
            {

                /*" -1898- MOVE 0231 TO HNOTCRE-OPERACAO */
                _.Move(0231, HNOTCRE_OPERACAO);

                /*" -1899- MOVE W-VALCREDR TO HNOTCRE-VLPAGTO */
                _.Move(AREA_DE_WORK.W_VALCREDR, HNOTCRE_VLPAGTO);

                /*" -1900- PERFORM R1740-00-INSERI-HISTNOTCRE */

                R1740_00_INSERI_HISTNOTCRE_SECTION();

                /*" -1902- COMPUTE WVALOR-DIFERSIN = WVALOR-DIFERSIN - W-VALCREDR */
                AREA_DE_WORK.WVALOR_DIFERSIN.Value = AREA_DE_WORK.WVALOR_DIFERSIN - AREA_DE_WORK.W_VALCREDR;

                /*" -1903- COMPUTE W1-COUNT = W1-COUNT - 1 */
                W1_COUNT.Value = W1_COUNT - 1;

                /*" -1907- ELSE */
            }
            else
            {


                /*" -1908- MOVE 0241 TO HNOTCRE-OPERACAO */
                _.Move(0241, HNOTCRE_OPERACAO);

                /*" -1909- MOVE WVALOR-DIFERSIN TO HNOTCRE-VLPAGTO */
                _.Move(AREA_DE_WORK.WVALOR_DIFERSIN, HNOTCRE_VLPAGTO);

                /*" -1910- PERFORM R1740-00-INSERI-HISTNOTCRE */

                R1740_00_INSERI_HISTNOTCRE_SECTION();

                /*" -1911- MOVE 'S' TO WFIM-NOTACRED */
                _.Move("S", AREA_DE_WORK.WFIM_NOTACRED);

                /*" -1911- PERFORM R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_3 */

                R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_3();

                /*" -1912- GO TO R1800-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1800_90_LEITURA */

            R1800_90_LEITURA();

        }

        [StopWatch]
        /*" R1800-00-PROCESSA-NOTASCRED-DB-CLOSE-1 */
        public void R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_1()
        {
            /*" -1881- EXEC SQL CLOSE V1NOTACRED END-EXEC */

            V1NOTACRED.Close();

        }

        [StopWatch]
        /*" R1800-90-LEITURA */
        private void R1800_90_LEITURA(bool isPerform = false)
        {
            /*" -1918- PERFORM R1770-00-FETCH-NOTASCRED. */

            R1770_00_FETCH_NOTASCRED_SECTION();

        }

        [StopWatch]
        /*" R1800-00-PROCESSA-NOTASCRED-DB-CLOSE-2 */
        public void R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_2()
        {
            /*" -1891- EXEC SQL CLOSE V1NOTACRED END-EXEC */

            V1NOTACRED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-PROCESSA-NOTASCRED-DB-CLOSE-3 */
        public void R1800_00_PROCESSA_NOTASCRED_DB_CLOSE_3()
        {
            /*" -1911- EXEC SQL CLOSE V1NOTACRED END-EXEC */

            V1NOTACRED.Close();

        }

        [StopWatch]
        /*" R2100-00-SELECT-V1ENDOSSO-SECTION */
        private void R2100_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -1929- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1971- PERFORM R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -1974- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1977- DISPLAY 'R2100-00 (NAO EXISTE NA V1ENDOSSO) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R2100-00 (NAO EXISTE NA V1ENDOSSO) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -1979- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1980- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1983- DISPLAY 'R2100-00 (ERRO NAO PREVISTO-SELECT ENDOSSO)' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R2100-00 (ERRO NAO PREVISTO-SELECT ENDOSSO) {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -1985- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1986- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -1986- MOVE ZEROS TO V1ENDO-CODPRODU. */
                _.Move(0, V1ENDO_CODPRODU);
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -1971- EXEC SQL SELECT ORGAO , RAMO , DTEMIS , DTINIVIG , DTTERVIG , COD_MOEDA_IMP , COD_MOEDA_PRM , BCORCAP , AGERCAP , DACRCAP , BCOCOBR , AGECOBR , DACCOBR , CORRECAO , CODPRODU , FONTE , NRRCAP , QTPARCEL INTO :V1ENDO-ORGAO , :V1ENDO-RAMO , :V1ENDO-DTEMIS , :V1ENDO-DTINIVIG , :V1ENDO-DTTERVIG , :V1ENDO-MOEDA-IMP , :V1ENDO-MOEDA-PRM , :V1ENDO-BCORCAP , :V1ENDO-AGERCAP , :V1ENDO-DACRCAP , :V1ENDO-BCOCOBR , :V1ENDO-AGECOBR , :V1ENDO-DACCOBR , :V1ENDO-CORRECAO , :V1ENDO-CODPRODU:VIND-CODPRODU, :V1ENDO-FONTE , :V1ENDO-NRRCAP , :V1ENDO-QTPARCEL FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS WITH UR END-EXEC. */

            var r2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_ORGAO, V1ENDO_ORGAO);
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_DTEMIS, V1ENDO_DTEMIS);
                _.Move(executed_1.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(executed_1.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(executed_1.V1ENDO_MOEDA_IMP, V1ENDO_MOEDA_IMP);
                _.Move(executed_1.V1ENDO_MOEDA_PRM, V1ENDO_MOEDA_PRM);
                _.Move(executed_1.V1ENDO_BCORCAP, V1ENDO_BCORCAP);
                _.Move(executed_1.V1ENDO_AGERCAP, V1ENDO_AGERCAP);
                _.Move(executed_1.V1ENDO_DACRCAP, V1ENDO_DACRCAP);
                _.Move(executed_1.V1ENDO_BCOCOBR, V1ENDO_BCOCOBR);
                _.Move(executed_1.V1ENDO_AGECOBR, V1ENDO_AGECOBR);
                _.Move(executed_1.V1ENDO_DACCOBR, V1ENDO_DACCOBR);
                _.Move(executed_1.V1ENDO_CORRECAO, V1ENDO_CORRECAO);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(executed_1.V1ENDO_FONTE, V1ENDO_FONTE);
                _.Move(executed_1.V1ENDO_NRRCAP, V1ENDO_NRRCAP);
                _.Move(executed_1.V1ENDO_QTPARCEL, V1ENDO_QTPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-V1MOEDA-SECTION */
        private void R2200_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -1997- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2005- PERFORM R2200_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R2200_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -2008- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2013- DISPLAY 'R2200-00 (NAO EXISTE NA V1MOEDA) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' WHOST-COD-MOEDA ' ' WHOST-DTINIVIG */

                $"R2200-00 (NAO EXISTE NA V1MOEDA) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {WHOST_COD_MOEDA} {WHOST_DTINIVIG}"
                .Display();

                /*" -2015- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2017- DISPLAY 'R2200-00 (PROBLEMAS SELECT V1MOEDA) ... ' */
                _.Display($"R2200-00 (PROBLEMAS SELECT V1MOEDA) ... ");

                /*" -2017- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R2200_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -2005- EXEC SQL SELECT VLCRUZAD INTO :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-COD-MOEDA AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG WITH UR END-EXEC. */

            var r2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                WHOST_COD_MOEDA = WHOST_COD_MOEDA.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-V1PARAMETRO-SECTION */
        private void R2300_00_SELECT_V1PARAMETRO_SECTION()
        {
            /*" -2028- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2029- IF V1ENDO-CODPRODU = ZEROS */

            if (V1ENDO_CODPRODU == 00)
            {

                /*" -2030- DISPLAY 'CB0003B: ENDOSSO SEM PRODUTO.' */
                _.Display($"CB0003B: ENDOSSO SEM PRODUTO.");

                /*" -2031- DISPLAY 'APOLICE = ' V1ENDO-NUM-APOL */
                _.Display($"APOLICE = {V1ENDO_NUM_APOL}");

                /*" -2032- DISPLAY 'ENDOSSO = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO = {V1ENDO_NRENDOS}");

                /*" -2033- DISPLAY 'PRODUTO = ' V1ENDO-CODPRODU */
                _.Display($"PRODUTO = {V1ENDO_CODPRODU}");

                /*" -2034- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2036- END-IF. */
            }


            /*" -2047- PERFORM R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1 */

            R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1();

            /*" -2050- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2053- DISPLAY 'R2300-00 (NAO EXISTE NA V1PARAMETRO) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R2300-00 (NAO EXISTE NA V1PARAMETRO) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -2055- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2056- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2057- DISPLAY 'R2300-00 (PROBLEMAS SELECT V1PARAMETRO) ' */
                _.Display($"R2300-00 (PROBLEMAS SELECT V1PARAMETRO) ");

                /*" -2057- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-V1PARAMETRO-DB-SELECT-1 */
        public void R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1()
        {
            /*" -2047- EXEC SQL SELECT A.CODUNIMO ,A.DIFPRM INTO :V1PARM-CODUNIMO ,:V1PARM-DIFPRM FROM SEGUROS.V1PARAMETRO A ,SEGUROS.PRODUTO B WHERE B.COD_PRODUTO = :V1ENDO-CODPRODU AND A.COD_EMPRESA = B.COD_EMPRESA WITH UR END-EXEC. */

            var r2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1 = new R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1()
            {
                V1ENDO_CODPRODU = V1ENDO_CODPRODU.ToString(),
            };

            var executed_1 = R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARM_CODUNIMO, V1PARM_CODUNIMO);
                _.Move(executed_1.V1PARM_DIFPRM, V1PARM_DIFPRM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CALCULA-CORRECAO-SECTION */
        private void R3000_00_CALCULA_CORRECAO_SECTION()
        {
            /*" -2071- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2092- PERFORM R3000_00_CALCULA_CORRECAO_DB_SELECT_1 */

            R3000_00_CALCULA_CORRECAO_DB_SELECT_1();

            /*" -2095- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2099- DISPLAY 'R3000-00 (ERRO SOMATORIO DA V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL ' ' */

                $"R3000-00 (ERRO SOMATORIO DA V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL} "
                .Display();

                /*" -2099- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R3000_20_VALOR_CORRECAO */

            R3000_20_VALOR_CORRECAO();

        }

        [StopWatch]
        /*" R3000-00-CALCULA-CORRECAO-DB-SELECT-1 */
        public void R3000_00_CALCULA_CORRECAO_DB_SELECT_1()
        {
            /*" -2092- EXEC SQL SELECT SUM(PRM_TARIFARIO), SUM(VAL_DESCONTO) , SUM(VLPRMLIQ) , SUM(VLADIFRA) , SUM(VLCUSEMI) , SUM(VLIOCC) , SUM(VLPRMTOT) INTO :W1-PRM-TAR , :W1-VAL-DES , :W1-VLPRMLIQ , :W1-VLADIFRA , :W1-VLCUSEMI , :W1-VLIOCC , :W1-VLPRMTOT FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL AND OPERACAO IN (101 , 801) WITH UR END-EXEC. */

            var r3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1 = new R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1.Execute(r3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1_PRM_TAR, W1_PRM_TAR);
                _.Move(executed_1.W1_VAL_DES, W1_VAL_DES);
                _.Move(executed_1.W1_VLPRMLIQ, W1_VLPRMLIQ);
                _.Move(executed_1.W1_VLADIFRA, W1_VLADIFRA);
                _.Move(executed_1.W1_VLCUSEMI, W1_VLCUSEMI);
                _.Move(executed_1.W1_VLIOCC, W1_VLIOCC);
                _.Move(executed_1.W1_VLPRMTOT, W1_VLPRMTOT);
            }


        }

        [StopWatch]
        /*" R3000-20-VALOR-CORRECAO */
        private void R3000_20_VALOR_CORRECAO(bool isPerform = false)
        {
            /*" -2105- COMPUTE W3-PRM-TAR = W0-PRM-TAR - W1-PRM-TAR */
            W3_PRM_TAR.Value = W0_PRM_TAR - W1_PRM_TAR;

            /*" -2107- COMPUTE W3-VAL-DES = W0-VAL-DES - W1-VAL-DES */
            W3_VAL_DES.Value = W0_VAL_DES - W1_VAL_DES;

            /*" -2109- COMPUTE W3-VLPRMLIQ = W0-VLPRMLIQ - W1-VLPRMLIQ */
            W3_VLPRMLIQ.Value = W0_VLPRMLIQ - W1_VLPRMLIQ;

            /*" -2111- COMPUTE W3-VLADIFRA = W0-VLADIFRA - W1-VLADIFRA */
            W3_VLADIFRA.Value = W0_VLADIFRA - W1_VLADIFRA;

            /*" -2113- COMPUTE W3-VLCUSEMI = W0-VLCUSEMI - W1-VLCUSEMI */
            W3_VLCUSEMI.Value = W0_VLCUSEMI - W1_VLCUSEMI;

            /*" -2115- COMPUTE W3-VLIOCC = W0-VLIOCC - W1-VLIOCC */
            W3_VLIOCC.Value = W0_VLIOCC - W1_VLIOCC;

            /*" -2116- COMPUTE W3-VLPRMTOT = W0-VLPRMTOT - W1-VLPRMTOT. */
            W3_VLPRMTOT.Value = W0_VLPRMTOT - W1_VLPRMTOT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SELECT-VENCIMENTO-SECTION */
        private void R3100_00_SELECT_VENCIMENTO_SECTION()
        {
            /*" -2127- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2136- PERFORM R3100_00_SELECT_VENCIMENTO_DB_SELECT_1 */

            R3100_00_SELECT_VENCIMENTO_DB_SELECT_1();

            /*" -2140- IF SQLCODE EQUAL -810 OR -811 NEXT SENTENCE */

            if (DB.SQLCODE.In("-810", "-811"))
            {

                /*" -2141- ELSE */
            }
            else
            {


                /*" -2142- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2146- DISPLAY 'R3100-00 (PROBLEMAS ACESSO V1HISTOPARC) ...' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL ' ' */

                    $"R3100-00 (PROBLEMAS ACESSO V1HISTOPARC) ...{V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL} "
                    .Display();

                    /*" -2147- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2148- ELSE */
                }
                else
                {


                    /*" -2149- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2150- DISPLAY 'R2300-00 (PROBLEMAS SELECT V1PARAMETRO) ' */
                        _.Display($"R2300-00 (PROBLEMAS SELECT V1PARAMETRO) ");

                        /*" -2150- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R3100-00-SELECT-VENCIMENTO-DB-SELECT-1 */
        public void R3100_00_SELECT_VENCIMENTO_DB_SELECT_1()
        {
            /*" -2136- EXEC SQL SELECT DTVENCTO INTO :W1HISP-DTVENCTO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL AND OPERACAO = 101 WITH UR END-EXEC. */

            var r3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1 = new R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1.Execute(r3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1HISP_DTVENCTO, W1HISP_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-SELECT-V1PARCELA-SECTION */
        private void R3150_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -2161- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2199- PERFORM R3150_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R3150_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -2202- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2203- PERFORM R3200-00-SELECT-V1PARCELA */

                R3200_00_SELECT_V1PARCELA_SECTION();

                /*" -2205- GO TO R3150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2206- IF SQLCODE EQUAL -810 OR -811 */

            if (DB.SQLCODE.In("-810", "-811"))
            {

                /*" -2208- GO TO R3150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2209- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2214- DISPLAY 'R3150-00 (ERRO - LEITURA DA V1PARCELA)...' 'TITULO         ' V1MCOB-NRTIT 'APOLICE        ' V1MCOB-NUM-APOL 'ENDOSSO        ' V1MCOB-NRENDOS 'PARCELA        ' V1MCOB-NRPARCEL */

                $"R3150-00 (ERRO - LEITURA DA V1PARCELA)...TITULO         {V1MCOB_NRTIT}APOLICE        {V1MCOB_NUM_APOL}ENDOSSO        {V1MCOB_NRENDOS}PARCELA        {V1MCOB_NRPARCEL}"
                .Display();

                /*" -2216- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2217- IF V1PARC-SITUACAO EQUAL '1' */

            if (V1PARC_SITUACAO == "1")
            {

                /*" -2218- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2219- MOVE '1' TO V0FOLP-CDERRO03 */
                _.Move("1", V0FOLP_CDERRO03);

                /*" -2221- MOVE 'PARCELA/TITULO JA QUITADO ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO JA QUITADO ", W1MCOB_NOME);

                /*" -2223- GO TO R3150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2224- IF V1PARC-SITUACAO EQUAL '2' */

            if (V1PARC_SITUACAO == "2")
            {

                /*" -2225- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2226- MOVE '1' TO V0FOLP-CDERRO04 */
                _.Move("1", V0FOLP_CDERRO04);

                /*" -2228- MOVE 'PARCELA/TITULO CANCELADO  ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO CANCELADO  ", W1MCOB_NOME);

                /*" -2230- GO TO R3150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2230- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

        }

        [StopWatch]
        /*" R3150-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R3150_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -2199- EXEC SQL SELECT NUM_APOLICE ,NRENDOS ,NRPARCEL ,DACPARC ,FONTE ,NRTIT ,PRM_TARIFARIO_IX ,VAL_DESCONTO_IX ,OTNPRLIQ ,OTNADFRA ,OTNCUSTO ,OTNIOF ,OTNTOTAL ,OCORHIST ,QTDDOC ,SITUACAO INTO :V1PARC-NUM-APOL ,:V1PARC-NRENDOS ,:V1PARC-NRPARCEL ,:V1PARC-DACPARC ,:V1PARC-FONTE ,:V1PARC-NRTIT ,:V1PARC-PRM-TAR ,:V1PARC-VAL-DES ,:V1PARC-OTNPRLIQ ,:V1PARC-OTNADFRA ,:V1PARC-OTNCUSTO ,:V1PARC-OTNIOF ,:V1PARC-OTNTOTAL ,:V1PARC-OCORHIST ,:V1PARC-QTDDOC ,:V1PARC-SITUACAO FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1MCOB-NUM-APOL AND NRENDOS = :V1MCOB-NRENDOS AND NRPARCEL = :V1MCOB-NRPARCEL WITH UR END-EXEC. */

            var r3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1MCOB_NUM_APOL = V1MCOB_NUM_APOL.ToString(),
                V1MCOB_NRPARCEL = V1MCOB_NRPARCEL.ToString(),
                V1MCOB_NRENDOS = V1MCOB_NRENDOS.ToString(),
            };

            var executed_1 = R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(executed_1.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(executed_1.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(executed_1.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(executed_1.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-SELECT-V1PARCELA-SECTION */
        private void R3200_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -2241- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2263- IF V1MCOB-NRTIT EQUAL 82021176773 OR 82021296086 OR 82021439456 OR 82022189291 OR 82022189372 OR 82040027370 OR 82040227388 OR 82040227469 OR 82040227540 OR 82040317450 OR 82040361866 OR 82040446853 OR 82050033705 OR 82050093520 OR 82050154502 OR 82051106145 OR 82051115721 OR 82051153224 OR 82051229069 OR 82051231802 OR 82051242839 OR 82051368778 OR 82051474101 OR 82051525709 OR 82051888003 OR 82051906699 OR 82051986510 OR 82060018008 OR 82060018008 OR 82060109747 OR 82060143090 OR 82061140524 OR 82061166914 OR 82061211138 OR 82061331974 OR 82061349911 OR 82061367731 OR 82061368207 OR 82061407547 OR 82061442962 OR 82080100176 OR 82080200200 OR 82080210940 OR 82080213965 OR 82080278900 OR 82080281456 OR 82080306971 OR 82080460385 OR 82080461608 OR 82080463724 OR 82080488719 OR 82080490020 OR 82080501839 OR 82100002875 OR 82100002956 OR 82100041854 OR 82100206950 OR 82100211105 OR 82100223880 OR 82100223960 OR 82100228091 OR 82100228172 OR 82100228253 */

            if (V1MCOB_NRTIT.In("82021176773", "82021296086", "82021439456", "82022189291", "82022189372", "82040027370", "82040227388", "82040227469", "82040227540", "82040317450", "82040361866", "82040446853", "82050033705", "82050093520", "82050154502", "82051106145", "82051115721", "82051153224", "82051229069", "82051231802", "82051242839", "82051368778", "82051474101", "82051525709", "82051888003", "82051906699", "82051986510", "82060018008", "82060018008", "82060109747", "82060143090", "82061140524", "82061166914", "82061211138", "82061331974", "82061349911", "82061367731", "82061368207", "82061407547", "82061442962", "82080100176", "82080200200", "82080210940", "82080213965", "82080278900", "82080281456", "82080306971", "82080460385", "82080461608", "82080463724", "82080488719", "82080490020", "82080501839", "82100002875", "82100002956", "82100041854", "82100206950", "82100211105", "82100223880", "82100223960", "82100228091", "82100228172", "82100228253"))
            {

                /*" -2269- PERFORM R3200_00_SELECT_V1PARCELA_DB_SELECT_1 */

                R3200_00_SELECT_V1PARCELA_DB_SELECT_1();

                /*" -2307- PERFORM R3200_00_SELECT_V1PARCELA_DB_SELECT_2 */

                R3200_00_SELECT_V1PARCELA_DB_SELECT_2();

                /*" -2309- ELSE */
            }
            else
            {


                /*" -2345- PERFORM R3200_00_SELECT_V1PARCELA_DB_SELECT_3 */

                R3200_00_SELECT_V1PARCELA_DB_SELECT_3();

                /*" -2349- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2350- PERFORM R3220-00-SELECT-V1PARCELA */

                    R3220_00_SELECT_V1PARCELA_SECTION();

                    /*" -2352- GO TO R3200-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2353- IF SQLCODE EQUAL -810 OR -811 */

            if (DB.SQLCODE.In("-810", "-811"))
            {

                /*" -2355- GO TO R3200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2356- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2358- DISPLAY 'R3200-00 (ERRO - LEITURA DA V1PARCELA)...' ' ' V1MCOB-NRTIT */

                $"R3200-00 (ERRO - LEITURA DA V1PARCELA)... {V1MCOB_NRTIT}"
                .Display();

                /*" -2360- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2361- IF V1PARC-SITUACAO EQUAL '1' */

            if (V1PARC_SITUACAO == "1")
            {

                /*" -2362- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2363- MOVE '1' TO V0FOLP-CDERRO03 */
                _.Move("1", V0FOLP_CDERRO03);

                /*" -2365- MOVE 'PARCELA/TITULO JA QUITADO ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO JA QUITADO ", W1MCOB_NOME);

                /*" -2367- GO TO R3200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2368- IF V1PARC-SITUACAO EQUAL '2' */

            if (V1PARC_SITUACAO == "2")
            {

                /*" -2369- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2370- MOVE '1' TO V0FOLP-CDERRO04 */
                _.Move("1", V0FOLP_CDERRO04);

                /*" -2372- MOVE 'PARCELA/TITULO CANCELADO  ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO CANCELADO  ", W1MCOB_NOME);

                /*" -2374- GO TO R3200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2374- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

        }

        [StopWatch]
        /*" R3200-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R3200_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -2269- EXEC SQL SELECT MIN(NRPARCEL) INTO :V1PARC-NRPARCEL FROM SEGUROS.V0PARCELA WHERE NRTIT = :V1MCOB-NRTIT AND SITUACAO = '0' END-EXEC */

            var r3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1MCOB_NRTIT = V1MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-SELECT-V1PARCELA-DB-SELECT-2 */
        public void R3200_00_SELECT_V1PARCELA_DB_SELECT_2()
        {
            /*" -2307- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , FONTE , NRTIT , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , OTNCUSTO , OTNIOF , OTNTOTAL , OCORHIST , QTDDOC , SITUACAO INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNPRLIQ , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO , :V1PARC-OTNIOF , :V1PARC-OTNTOTAL , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO FROM SEGUROS.V1PARCELA WHERE NRTIT = :V1MCOB-NRTIT AND NRPARCEL = :V1PARC-NRPARCEL WITH UR END-EXEC */

            var r3200_00_SELECT_V1PARCELA_DB_SELECT_2_Query1 = new R3200_00_SELECT_V1PARCELA_DB_SELECT_2_Query1()
            {
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1MCOB_NRTIT = V1MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3200_00_SELECT_V1PARCELA_DB_SELECT_2_Query1.Execute(r3200_00_SELECT_V1PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(executed_1.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(executed_1.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(executed_1.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(executed_1.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
            }


        }

        [StopWatch]
        /*" R3220-00-SELECT-V1PARCELA-SECTION */
        private void R3220_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -2385- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2425- PERFORM R3220_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R3220_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -2428- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2429- PERFORM R3250-00-SELECT-V1PARCELA */

                R3250_00_SELECT_V1PARCELA_SECTION();

                /*" -2431- GO TO R3220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2432- IF SQLCODE EQUAL -810 OR -811 */

            if (DB.SQLCODE.In("-810", "-811"))
            {

                /*" -2434- GO TO R3220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2435- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2440- DISPLAY 'R3220-00 (ERRO - LEITURA DA V1PARCELA)...' 'TITULO         ' V1MCOB-NRTIT 'APOLICE        ' V1MCOB-NUM-APOL 'ENDOSSO        ' V1MCOB-NRENDOS 'PARCELA        ' V1MCOB-NRPARCEL */

                $"R3220-00 (ERRO - LEITURA DA V1PARCELA)...TITULO         {V1MCOB_NRTIT}APOLICE        {V1MCOB_NUM_APOL}ENDOSSO        {V1MCOB_NRENDOS}PARCELA        {V1MCOB_NRPARCEL}"
                .Display();

                /*" -2442- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2443- IF V1PARC-SITUACAO EQUAL '1' */

            if (V1PARC_SITUACAO == "1")
            {

                /*" -2444- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2445- MOVE '1' TO V0FOLP-CDERRO03 */
                _.Move("1", V0FOLP_CDERRO03);

                /*" -2447- MOVE 'PARCELA/TITULO JA QUITADO ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO JA QUITADO ", W1MCOB_NOME);

                /*" -2449- GO TO R3220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2450- IF V1PARC-SITUACAO EQUAL '2' */

            if (V1PARC_SITUACAO == "2")
            {

                /*" -2451- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2452- MOVE '1' TO V0FOLP-CDERRO04 */
                _.Move("1", V0FOLP_CDERRO04);

                /*" -2454- MOVE 'PARCELA/TITULO CANCELADO  ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO CANCELADO  ", W1MCOB_NOME);

                /*" -2456- GO TO R3220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2456- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

        }

        [StopWatch]
        /*" R3220-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R3220_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -2425- EXEC SQL SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.DACPARC , A.FONTE , A.NRTIT , A.PRM_TARIFARIO_IX , A.VAL_DESCONTO_IX , A.OTNPRLIQ , A.OTNADFRA , A.OTNCUSTO , A.OTNIOF , A.OTNTOTAL , A.OCORHIST , A.QTDDOC , A.SITUACAO INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNPRLIQ , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO , :V1PARC-OTNIOF , :V1PARC-OTNTOTAL , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO FROM SEGUROS.V1PARCELA A, SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_TITULO = :V1MCOB-NRTIT AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NRENDOS AND B.NUM_PARCELA = A.NRPARCEL WITH UR END-EXEC. */

            var r3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1MCOB_NRTIT = V1MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(executed_1.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(executed_1.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(executed_1.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(executed_1.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
            }


        }

        [StopWatch]
        /*" R3200-00-SELECT-V1PARCELA-DB-SELECT-3 */
        public void R3200_00_SELECT_V1PARCELA_DB_SELECT_3()
        {
            /*" -2345- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , FONTE , NRTIT , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , OTNCUSTO , OTNIOF , OTNTOTAL , OCORHIST , QTDDOC , SITUACAO INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNPRLIQ , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO , :V1PARC-OTNIOF , :V1PARC-OTNTOTAL , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO FROM SEGUROS.V1PARCELA WHERE NRTIT = :V1MCOB-NRTIT WITH UR END-EXEC. */

            var r3200_00_SELECT_V1PARCELA_DB_SELECT_3_Query1 = new R3200_00_SELECT_V1PARCELA_DB_SELECT_3_Query1()
            {
                V1MCOB_NRTIT = V1MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3200_00_SELECT_V1PARCELA_DB_SELECT_3_Query1.Execute(r3200_00_SELECT_V1PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(executed_1.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(executed_1.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(executed_1.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(executed_1.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-SELECT-V1PARCELA-SECTION */
        private void R3250_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -2468- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2469- IF WS-TITPRE EQUAL 31 */

            if (AREA_DE_WORK.FILLER_0.WS_TITPRE == 31)
            {

                /*" -2470- MOVE 55 TO WS-TITPRE */
                _.Move(55, AREA_DE_WORK.FILLER_0.WS_TITPRE);

                /*" -2471- MOVE WS-TITULO TO V1MCOB-NRTIT */
                _.Move(AREA_DE_WORK.WS_TITULO, V1MCOB_NRTIT);

                /*" -2472- ELSE */
            }
            else
            {


                /*" -2473- MOVE '*' TO WFIM-V1PARCELA */
                _.Move("*", AREA_DE_WORK.WFIM_V1PARCELA);

                /*" -2474- MOVE '1' TO V0FOLP-CDERRO01 */
                _.Move("1", V0FOLP_CDERRO01);

                /*" -2476- MOVE 'DOCUMENTO NAO EMITIDO ' TO W1MCOB-NOME */
                _.Move("DOCUMENTO NAO EMITIDO ", W1MCOB_NOME);

                /*" -2479- GO TO R3250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2515- PERFORM R3250_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R3250_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -2519- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2520- MOVE '*' TO WFIM-V1PARCELA */
                _.Move("*", AREA_DE_WORK.WFIM_V1PARCELA);

                /*" -2521- MOVE '1' TO V0FOLP-CDERRO01 */
                _.Move("1", V0FOLP_CDERRO01);

                /*" -2523- MOVE 'DOCUMENTO NAO EMITIDO ' TO W1MCOB-NOME */
                _.Move("DOCUMENTO NAO EMITIDO ", W1MCOB_NOME);

                /*" -2524- MOVE WS-TITANT TO V1MCOB-NRTIT */
                _.Move(AREA_DE_WORK.WS_TITANT, V1MCOB_NRTIT);

                /*" -2527- GO TO R3250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2528- IF SQLCODE EQUAL -810 OR -811 */

            if (DB.SQLCODE.In("-810", "-811"))
            {

                /*" -2529- MOVE WS-TITANT TO V1MCOB-NRTIT */
                _.Move(AREA_DE_WORK.WS_TITANT, V1MCOB_NRTIT);

                /*" -2531- GO TO R3250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2534- DISPLAY 'R3250-00 (ERRO - LEITURA DA V1PARCELA)...' ' ' V1MCOB-NRTIT */

                $"R3250-00 (ERRO - LEITURA DA V1PARCELA)... {V1MCOB_NRTIT}"
                .Display();

                /*" -2536- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2537- IF V1PARC-SITUACAO EQUAL '1' */

            if (V1PARC_SITUACAO == "1")
            {

                /*" -2538- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2539- MOVE '1' TO V0FOLP-CDERRO03 */
                _.Move("1", V0FOLP_CDERRO03);

                /*" -2541- MOVE 'PARCELA/TITULO JA QUITADO ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO JA QUITADO ", W1MCOB_NOME);

                /*" -2542- MOVE WS-TITANT TO V1MCOB-NRTIT */
                _.Move(AREA_DE_WORK.WS_TITANT, V1MCOB_NRTIT);

                /*" -2544- GO TO R3250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2545- IF V1PARC-SITUACAO EQUAL '2' */

            if (V1PARC_SITUACAO == "2")
            {

                /*" -2546- MOVE '*' TO WCHV-BAIXA */
                _.Move("*", AREA_DE_WORK.WCHV_BAIXA);

                /*" -2547- MOVE '1' TO V0FOLP-CDERRO04 */
                _.Move("1", V0FOLP_CDERRO04);

                /*" -2549- MOVE 'PARCELA/TITULO CANCELADO  ' TO W1MCOB-NOME */
                _.Move("PARCELA/TITULO CANCELADO  ", W1MCOB_NOME);

                /*" -2550- MOVE WS-TITANT TO V1MCOB-NRTIT */
                _.Move(AREA_DE_WORK.WS_TITANT, V1MCOB_NRTIT);

                /*" -2553- GO TO R3250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2554- ADD 1 TO AC-FAIXA55. */
            AREA_DE_WORK.AC_FAIXA55.Value = AREA_DE_WORK.AC_FAIXA55 + 1;

            /*" -2557- MOVE 'S' TO WTEM-NRTIT55. */
            _.Move("S", AREA_DE_WORK.WTEM_NRTIT55);

            /*" -2557- MOVE V1PARC-OCORHIST TO WOCORHIST. */
            _.Move(V1PARC_OCORHIST, WOCORHIST);

        }

        [StopWatch]
        /*" R3250-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R3250_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -2515- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , FONTE , NRTIT , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , OTNCUSTO , OTNIOF , OTNTOTAL , OCORHIST , QTDDOC , SITUACAO INTO :V1PARC-NUM-APOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-DACPARC , :V1PARC-FONTE , :V1PARC-NRTIT , :V1PARC-PRM-TAR , :V1PARC-VAL-DES , :V1PARC-OTNPRLIQ , :V1PARC-OTNADFRA , :V1PARC-OTNCUSTO , :V1PARC-OTNIOF , :V1PARC-OTNTOTAL , :V1PARC-OCORHIST , :V1PARC-QTDDOC , :V1PARC-SITUACAO FROM SEGUROS.V1PARCELA WHERE NRTIT = :V1MCOB-NRTIT WITH UR END-EXEC. */

            var r3250_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R3250_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1MCOB_NRTIT = V1MCOB_NRTIT.ToString(),
            };

            var executed_1 = R3250_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r3250_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUM_APOL, V1PARC_NUM_APOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_DACPARC, V1PARC_DACPARC);
                _.Move(executed_1.V1PARC_FONTE, V1PARC_FONTE);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_PRM_TAR, V1PARC_PRM_TAR);
                _.Move(executed_1.V1PARC_VAL_DES, V1PARC_VAL_DES);
                _.Move(executed_1.V1PARC_OTNPRLIQ, V1PARC_OTNPRLIQ);
                _.Move(executed_1.V1PARC_OTNADFRA, V1PARC_OTNADFRA);
                _.Move(executed_1.V1PARC_OTNCUSTO, V1PARC_OTNCUSTO);
                _.Move(executed_1.V1PARC_OTNIOF, V1PARC_OTNIOF);
                _.Move(executed_1.V1PARC_OTNTOTAL, V1PARC_OTNTOTAL);
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
                _.Move(executed_1.V1PARC_QTDDOC, V1PARC_QTDDOC);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-ACESSA-PARCELADEV-SECTION */
        private void R3300_00_ACESSA_PARCELADEV_SECTION()
        {
            /*" -2569- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2577- PERFORM R3300_00_ACESSA_PARCELADEV_DB_SELECT_1 */

            R3300_00_ACESSA_PARCELADEV_DB_SELECT_1();

            /*" -2580- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2581- MOVE 'S' TO WTEM-PARCELADEV */
                _.Move("S", AREA_DE_WORK.WTEM_PARCELADEV);

                /*" -2582- ELSE */
            }
            else
            {


                /*" -2583- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2584- MOVE 'N' TO WTEM-PARCELADEV */
                    _.Move("N", AREA_DE_WORK.WTEM_PARCELADEV);

                    /*" -2585- PERFORM R3400-00-ACESSA-CBMALPAR */

                    R3400_00_ACESSA_CBMALPAR_SECTION();

                    /*" -2586- ELSE */
                }
                else
                {


                    /*" -2587- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2591- DISPLAY 'R3300-00 (ERRO - LEITURA DA PARCELADEV)..' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                        $"R3300-00 (ERRO - LEITURA DA PARCELADEV).. {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                        .Display();

                        /*" -2591- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R3300-00-ACESSA-PARCELADEV-DB-SELECT-1 */
        public void R3300_00_ACESSA_PARCELADEV_DB_SELECT_1()
        {
            /*" -2577- EXEC SQL SELECT VLACRESCIMO INTO :V0PDEV-VLACRESCIMO FROM SEGUROS.V0PARCELA_DEVEDOR WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL WITH UR END-EXEC. */

            var r3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1 = new R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1.Execute(r3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PDEV_VLACRESCIMO, V0PDEV_VLACRESCIMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-ACESSA-CBMALPAR-SECTION */
        private void R3400_00_ACESSA_CBMALPAR_SECTION()
        {
            /*" -2602- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2619- PERFORM R3400_00_ACESSA_CBMALPAR_DB_SELECT_1 */

            R3400_00_ACESSA_CBMALPAR_DB_SELECT_1();

            /*" -2622- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2623- MOVE 'S' TO WTEM-PARCELADEV */
                _.Move("S", AREA_DE_WORK.WTEM_PARCELADEV);

                /*" -2624- ELSE */
            }
            else
            {


                /*" -2625- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2626- MOVE 'N' TO WTEM-PARCELADEV */
                    _.Move("N", AREA_DE_WORK.WTEM_PARCELADEV);

                    /*" -2627- ELSE */
                }
                else
                {


                    /*" -2628- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2632- DISPLAY 'R3400-00 (ERRO - LEITURA CB_MALA_PARCATRASO' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                        $"R3400-00 (ERRO - LEITURA CB_MALA_PARCATRASO {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                        .Display();

                        /*" -2632- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R3400-00-ACESSA-CBMALPAR-DB-SELECT-1 */
        public void R3400_00_ACESSA_CBMALPAR_DB_SELECT_1()
        {
            /*" -2619- EXEC SQL SELECT VALUE(A.VALOR_ACRESCIMO,0) + VALUE(A.VALOR_TARIFA,0) + VALUE(A.VALOR_VISTORIA,0) INTO :V0PDEV-VLACRESCIMO FROM SEGUROS.CB_MALA_PARCATRASO A WHERE A.NUM_APOLICE = :V1PARC-NUM-APOL AND A.NUM_ENDOSSO = :V1PARC-NRENDOS AND A.NUM_PARCELA = :V1PARC-NRPARCEL AND A.DATA_MOVIMENTO = (SELECT MAX(B.DATA_MOVIMENTO) FROM SEGUROS.CB_MALA_PARCATRASO B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA) WITH UR END-EXEC. */

            var r3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1 = new R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1.Execute(r3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PDEV_VLACRESCIMO, V0PDEV_VLACRESCIMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3440-00-TRATA-AUTOSAS-SECTION */
        private void R3440_00_TRATA_AUTOSAS_SECTION()
        {
            /*" -2645- MOVE '3440' TO WNR-EXEC-SQL. */
            _.Move("3440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2646- MOVE ZEROS TO V0PDEV-VLACRESCIMO. */
            _.Move(0, V0PDEV_VLACRESCIMO);

            /*" -2647- MOVE SPACES TO WFIM-AU071. */
            _.Move("", AREA_DE_WORK.WFIM_AU071);

            /*" -2649- MOVE 1 TO WS-FLAG-AUTO */
            _.Move(1, WS_FLAG_AUTO);

            /*" -2651- PERFORM R3450-00-DECLARE-AU071. */

            R3450_00_DECLARE_AU071_SECTION();

            /*" -2656- PERFORM R3460-00-FETCH-AU071 UNTIL WFIM-AU071 NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_AU071.IsEmpty()))
            {

                R3460_00_FETCH_AU071_SECTION();
            }

            /*" -2660- PERFORM R3441-00-CALCULA-JUROS-MULTA */

            R3441_00_CALCULA_JUROS_MULTA_SECTION();

            /*" -2661- IF V0PDEV-VLACRESCIMO EQUAL ZEROS */

            if (V0PDEV_VLACRESCIMO == 00)
            {

                /*" -2661- PERFORM R3300-00-ACESSA-PARCELADEV. */

                R3300_00_ACESSA_PARCELADEV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3440_99_SAIDA*/

        [StopWatch]
        /*" R3441-00-CALCULA-JUROS-MULTA-SECTION */
        private void R3441_00_CALCULA_JUROS_MULTA_SECTION()
        {
            /*" -2672- INITIALIZE DCLGE-CONTROLE-EMISSAO-SIGCB */
            _.Initialize(
                GE403.DCLGE_CONTROLE_EMISSAO_SIGCB
            );

            /*" -2673- MOVE V1MCOB-NUM-APOL TO GE403-NUM-APOLICE */
            _.Move(V1MCOB_NUM_APOL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE);

            /*" -2674- MOVE V1MCOB-NRENDOS TO GE403-NUM-ENDOSSO */
            _.Move(V1MCOB_NRENDOS, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO);

            /*" -2675- MOVE V1MCOB-NRPARCEL TO GE403-NUM-PARCELA */
            _.Move(V1MCOB_NRPARCEL, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA);

            /*" -2677- MOVE V1MCOB-NUM-NOSSO TO GE403-NUM-PROPOSTA */
            _.Move(V1MCOB_NUM_NOSSO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

            /*" -2696- PERFORM R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1 */

            R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1();

            /*" -2699- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -2700- DISPLAY 'ERRO CONSULTA TABELA .GE_CONTROLE_EMISSAO_SIGCB' */
                _.Display($"ERRO CONSULTA TABELA .GE_CONTROLE_EMISSAO_SIGCB");

                /*" -2701- DISPLAY 'PROPOSTA    ' GE403-NUM-PROPOSTA */
                _.Display($"PROPOSTA    {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA}");

                /*" -2702- DISPLAY 'CERTIFICADO ' GE403-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO}");

                /*" -2703- DISPLAY 'PARCELA     ' GE403-NUM-PARCELA */
                _.Display($"PARCELA     {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA}");

                /*" -2704- DISPLAY 'APOLICE     ' GE403-NUM-APOLICE */
                _.Display($"APOLICE     {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}");

                /*" -2705- DISPLAY 'ENDOSSO     ' GE403-NUM-ENDOSSO */
                _.Display($"ENDOSSO     {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                /*" -2706- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2711- END-IF */
            }


            /*" -2715- MOVE 0 TO WS-QTD-DIAS WS-VL-JUROS WS-VL-MULTA */
            _.Move(0, WS_QTD_DIAS, WS_VL_JUROS, WS_VL_MULTA);

            /*" -2718- IF (GE403-DTA-VENCIMENTO NOT = SPACES) AND (V1MCOB-DTQITBCO > GE403-DTA-VENCIMENTO) */

            if ((!GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO.IsEmpty()) && (V1MCOB_DTQITBCO > GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO))
            {

                /*" -2723- PERFORM R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2 */

                R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2();

                /*" -2726- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -2727- DISPLAY 'ERRO CALCULO QTD DIAS' */
                    _.Display($"ERRO CALCULO QTD DIAS");

                    /*" -2728- DISPLAY 'PROPOSTA    ' GE403-NUM-PROPOSTA */
                    _.Display($"PROPOSTA    {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA}");

                    /*" -2729- DISPLAY 'APOLICE     ' GE403-NUM-APOLICE */
                    _.Display($"APOLICE     {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE}");

                    /*" -2730- DISPLAY 'ENDOSSO     ' GE403-NUM-ENDOSSO */
                    _.Display($"ENDOSSO     {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO}");

                    /*" -2731- DISPLAY 'PARCELA     ' GE403-NUM-PARCELA */
                    _.Display($"PARCELA     {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA}");

                    /*" -2732- DISPLAY 'DATA VENC   ' GE403-DTA-VENCIMENTO */
                    _.Display($"DATA VENC   {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO}");

                    /*" -2733- DISPLAY 'DATA QUITAC ' V1MCOB-DTQITBCO */
                    _.Display($"DATA QUITAC {V1MCOB_DTQITBCO}");

                    /*" -2734- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2736- END-IF */
                }


                /*" -2739- COMPUTE WS-VL-JUROS = V1PARC-OTNTOTAL * WS-QTD-DIAS * 0,0003 */
                WS_VL_JUROS.Value = V1PARC_OTNTOTAL * WS_QTD_DIAS * 0.0003;

                /*" -2741- COMPUTE WS-VL-MULTA = V1PARC-OTNTOTAL * 0,0965 */
                WS_VL_MULTA.Value = V1PARC_OTNTOTAL * 0.0965;

                /*" -2744- COMPUTE V0PDEV-VLACRESCIMO = WS-VL-JUROS + WS-VL-MULTA */
                V0PDEV_VLACRESCIMO.Value = WS_VL_JUROS + WS_VL_MULTA;

                /*" -2745- MOVE 'S' TO WTEM-PARCELADEV */
                _.Move("S", AREA_DE_WORK.WTEM_PARCELADEV);

                /*" -2745- END-IF. */
            }


        }

        [StopWatch]
        /*" R3441-00-CALCULA-JUROS-MULTA-DB-SELECT-1 */
        public void R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1()
        {
            /*" -2696- EXEC SQL SELECT DTA_VENCIMENTO INTO :GE403-DTA-VENCIMENTO FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A WHERE A.NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND A.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND A.NUM_PARCELA = :GE403-NUM-PARCELA AND A.NUM_APOLICE = :GE403-NUM-APOLICE AND A.NUM_ENDOSSO = :GE403-NUM-ENDOSSO AND A.SEQ_CONTROLE_SIGCB = ( SELECT MAX(B.SEQ_CONTROLE_SIGCB) FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_PROPOSTA = :GE403-NUM-PROPOSTA AND B.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO AND B.NUM_PARCELA = :GE403-NUM-PARCELA AND B.NUM_APOLICE = :GE403-NUM-APOLICE AND B.NUM_ENDOSSO = :GE403-NUM-ENDOSSO ) WITH UR END-EXEC */

            var r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1 = new R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1()
            {
                GE403_NUM_CERTIFICADO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_CERTIFICADO.ToString(),
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
                GE403_NUM_PARCELA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PARCELA.ToString(),
                GE403_NUM_APOLICE = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_APOLICE.ToString(),
                GE403_NUM_ENDOSSO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1.Execute(r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_DTA_VENCIMENTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3441_99_SAIDA*/

        [StopWatch]
        /*" R3441-00-CALCULA-JUROS-MULTA-DB-SELECT-2 */
        public void R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2()
        {
            /*" -2723- EXEC SQL SELECT (DAYS(:V1MCOB-DTQITBCO) - DAYS(:GE403-DTA-VENCIMENTO)) INTO :WS-QTD-DIAS FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1 = new R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1()
            {
                GE403_DTA_VENCIMENTO = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO.ToString(),
                V1MCOB_DTQITBCO = V1MCOB_DTQITBCO.ToString(),
            };

            var executed_1 = R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1.Execute(r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_DIAS, WS_QTD_DIAS);
            }


        }

        [StopWatch]
        /*" R3450-00-DECLARE-AU071-SECTION */
        private void R3450_00_DECLARE_AU071_SECTION()
        {
            /*" -2756- MOVE '3450' TO WNR-EXEC-SQL. */
            _.Move("3450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2777- PERFORM R3450_00_DECLARE_AU071_DB_DECLARE_1 */

            R3450_00_DECLARE_AU071_DB_DECLARE_1();

            /*" -2779- PERFORM R3450_00_DECLARE_AU071_DB_OPEN_1 */

            R3450_00_DECLARE_AU071_DB_OPEN_1();

            /*" -2782- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2783- DISPLAY 'R3450 - ERRO DECLARE AU071' */
                _.Display($"R3450 - ERRO DECLARE AU071");

                /*" -2783- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3450-00-DECLARE-AU071-DB-OPEN-1 */
        public void R3450_00_DECLARE_AU071_DB_OPEN_1()
        {
            /*" -2779- EXEC SQL OPEN C1AU071 END-EXEC. */

            C1AU071.Open();

        }

        [StopWatch]
        /*" R3480-00-DECLARE-V0CALENDARIO-DB-DECLARE-1 */
        public void R3480_00_DECLARE_V0CALENDARIO_DB_DECLARE_1()
        {
            /*" -2869- EXEC SQL DECLARE V0CALENDARIO CURSOR FOR SELECT DATA_CALENDARIO , DIA_SEMANA , FERIADO FROM SEGUROS.V0CALENDARIO WHERE DATA_CALENDARIO > :AU071-DTA-VENCTO AND DATA_CALENDARIO <= :V1SIST-DTMOVABE ORDER BY DATA_CALENDARIO END-EXEC. */
            V0CALENDARIO = new CB0003B_V0CALENDARIO(true);
            string GetQuery_V0CALENDARIO()
            {
                var query = @$"SELECT DATA_CALENDARIO
							, 
							DIA_SEMANA
							, 
							FERIADO 
							FROM SEGUROS.V0CALENDARIO 
							WHERE DATA_CALENDARIO > '{AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO}' 
							AND DATA_CALENDARIO <= '{V1SIST_DTMOVABE}' 
							ORDER BY DATA_CALENDARIO";

                return query;
            }
            V0CALENDARIO.GetQueryEvent += GetQuery_V0CALENDARIO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3450_99_SAIDA*/

        [StopWatch]
        /*" R3460-00-FETCH-AU071-SECTION */
        private void R3460_00_FETCH_AU071_SECTION()
        {
            /*" -2794- MOVE '3460' TO WNR-EXEC-SQL. */
            _.Move("3460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2805- PERFORM R3460_00_FETCH_AU071_DB_FETCH_1 */

            R3460_00_FETCH_AU071_DB_FETCH_1();

            /*" -2808- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2809- MOVE 'S' TO WFIM-AU071 */
                _.Move("S", AREA_DE_WORK.WFIM_AU071);

                /*" -2809- PERFORM R3460_00_FETCH_AU071_DB_CLOSE_1 */

                R3460_00_FETCH_AU071_DB_CLOSE_1();

                /*" -2812- END-IF. */
            }


            /*" -2813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2814- DISPLAY 'R3460- ERRO FETCH AU071' */
                _.Display($"R3460- ERRO FETCH AU071");

                /*" -2816- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2819- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO NOT EQUAL SPACES */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || !CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO.IsEmpty())
            {

                /*" -2820- PERFORM R3470-00-TRATA-DIAUTIL */

                R3470_00_TRATA_DIAUTIL_SECTION();

                /*" -2822- END-IF. */
            }


            /*" -2823- IF V1MCOB-DTQITBCO NOT GREATER AU071-DTA-VENCTO */

            if (V1MCOB_DTQITBCO <= AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO)
            {

                /*" -2826- COMPUTE V0PDEV-VLACRESCIMO EQUAL (AU071-VLR-JUROS + AU071-VLR-MULTA) */
                V0PDEV_VLACRESCIMO.Value = (AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS + AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);

                /*" -2827- MOVE 'S' TO WTEM-PARCELADEV */
                _.Move("S", AREA_DE_WORK.WTEM_PARCELADEV);

                /*" -2828- MOVE 'S' TO WFIM-AU071 */
                _.Move("S", AREA_DE_WORK.WFIM_AU071);

                /*" -2828- PERFORM R3460_00_FETCH_AU071_DB_CLOSE_2 */

                R3460_00_FETCH_AU071_DB_CLOSE_2();

                /*" -2829- END-IF. */
            }


        }

        [StopWatch]
        /*" R3460-00-FETCH-AU071-DB-FETCH-1 */
        public void R3460_00_FETCH_AU071_DB_FETCH_1()
        {
            /*" -2805- EXEC SQL FETCH C1AU071 INTO :AU071-NUM-APOLICE ,:AU071-NUM-ENDOSSO ,:AU071-NUM-PARCELA ,:AU071-DTA-VENCTO ,:AU071-NUM-VENCTO ,:AU071-VLR-JUROS ,:AU071-VLR-MULTA ,:CALENDAR-DIA-SEMANA ,:CALENDAR-FERIADO END-EXEC. */

            if (C1AU071.Fetch())
            {
                _.Move(C1AU071.AU071_NUM_APOLICE, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE);
                _.Move(C1AU071.AU071_NUM_ENDOSSO, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO);
                _.Move(C1AU071.AU071_NUM_PARCELA, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA);
                _.Move(C1AU071.AU071_DTA_VENCTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);
                _.Move(C1AU071.AU071_NUM_VENCTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);
                _.Move(C1AU071.AU071_VLR_JUROS, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS);
                _.Move(C1AU071.AU071_VLR_MULTA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);
                _.Move(C1AU071.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(C1AU071.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }

        [StopWatch]
        /*" R3460-00-FETCH-AU071-DB-CLOSE-1 */
        public void R3460_00_FETCH_AU071_DB_CLOSE_1()
        {
            /*" -2809- EXEC SQL CLOSE C1AU071 END-EXEC */

            C1AU071.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3460_99_SAIDA*/

        [StopWatch]
        /*" R3460-00-FETCH-AU071-DB-CLOSE-2 */
        public void R3460_00_FETCH_AU071_DB_CLOSE_2()
        {
            /*" -2828- EXEC SQL CLOSE C1AU071 END-EXEC */

            C1AU071.Close();

        }

        [StopWatch]
        /*" R3470-00-TRATA-DIAUTIL-SECTION */
        private void R3470_00_TRATA_DIAUTIL_SECTION()
        {
            /*" -2841- MOVE '3470' TO WNR-EXEC-SQL. */
            _.Move("3470", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2843- MOVE SPACES TO WFIM-CALENDARIO. */
            _.Move("", AREA_DE_WORK.WFIM_CALENDARIO);

            /*" -2845- PERFORM R3480-00-DECLARE-V0CALENDARIO. */

            R3480_00_DECLARE_V0CALENDARIO_SECTION();

            /*" -2846- PERFORM R3490-00-FETCH-V0CALENDARIO UNTIL WFIM-CALENDARIO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CALENDARIO.IsEmpty()))
            {

                R3490_00_FETCH_V0CALENDARIO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3470_99_SAIDA*/

        [StopWatch]
        /*" R3480-00-DECLARE-V0CALENDARIO-SECTION */
        private void R3480_00_DECLARE_V0CALENDARIO_SECTION()
        {
            /*" -2859- MOVE '3480' TO WNR-EXEC-SQL. */
            _.Move("3480", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2869- PERFORM R3480_00_DECLARE_V0CALENDARIO_DB_DECLARE_1 */

            R3480_00_DECLARE_V0CALENDARIO_DB_DECLARE_1();

            /*" -2871- PERFORM R3480_00_DECLARE_V0CALENDARIO_DB_OPEN_1 */

            R3480_00_DECLARE_V0CALENDARIO_DB_OPEN_1();

            /*" -2875- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2876- DISPLAY 'R3480-00 - PROBLEMAS DECLARE (CALENDARIO)' */
                _.Display($"R3480-00 - PROBLEMAS DECLARE (CALENDARIO)");

                /*" -2878- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3480-00-DECLARE-V0CALENDARIO-DB-OPEN-1 */
        public void R3480_00_DECLARE_V0CALENDARIO_DB_OPEN_1()
        {
            /*" -2871- EXEC SQL OPEN V0CALENDARIO END-EXEC. */

            V0CALENDARIO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3480_99_SAIDA*/

        [StopWatch]
        /*" R3490-00-FETCH-V0CALENDARIO-SECTION */
        private void R3490_00_FETCH_V0CALENDARIO_SECTION()
        {
            /*" -2889- MOVE '3490' TO WNR-EXEC-SQL. */
            _.Move("3490", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2893- PERFORM R3490_00_FETCH_V0CALENDARIO_DB_FETCH_1 */

            R3490_00_FETCH_V0CALENDARIO_DB_FETCH_1();

            /*" -2897- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2897- PERFORM R3490_00_FETCH_V0CALENDARIO_DB_CLOSE_1 */

                R3490_00_FETCH_V0CALENDARIO_DB_CLOSE_1();

                /*" -2899- MOVE 'S' TO WFIM-CALENDARIO */
                _.Move("S", AREA_DE_WORK.WFIM_CALENDARIO);

                /*" -2901- GO TO R3490-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3490_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2902- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2903- DISPLAY 'R3490-00 - PROBLEMAS FETCH (V0CALENDARIO)' */
                _.Display($"R3490-00 - PROBLEMAS FETCH (V0CALENDARIO)");

                /*" -2906- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2910- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO NOT EQUAL SPACES NEXT SENTENCE */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || !CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO.IsEmpty())
            {

                /*" -2911- ELSE */
            }
            else
            {


                /*" -2911- PERFORM R3490_00_FETCH_V0CALENDARIO_DB_CLOSE_2 */

                R3490_00_FETCH_V0CALENDARIO_DB_CLOSE_2();

                /*" -2913- MOVE 'S' TO WFIM-CALENDARIO */
                _.Move("S", AREA_DE_WORK.WFIM_CALENDARIO);

                /*" -2916- MOVE CALENDAR-DATA-CALENDARIO TO AU071-DTA-VENCTO. */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);
            }


        }

        [StopWatch]
        /*" R3490-00-FETCH-V0CALENDARIO-DB-FETCH-1 */
        public void R3490_00_FETCH_V0CALENDARIO_DB_FETCH_1()
        {
            /*" -2893- EXEC SQL FETCH V0CALENDARIO INTO :CALENDAR-DATA-CALENDARIO, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO END-EXEC. */

            if (V0CALENDARIO.Fetch())
            {
                _.Move(V0CALENDARIO.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(V0CALENDARIO.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(V0CALENDARIO.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }

        [StopWatch]
        /*" R3490-00-FETCH-V0CALENDARIO-DB-CLOSE-1 */
        public void R3490_00_FETCH_V0CALENDARIO_DB_CLOSE_1()
        {
            /*" -2897- EXEC SQL CLOSE V0CALENDARIO END-EXEC */

            V0CALENDARIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3490_99_SAIDA*/

        [StopWatch]
        /*" R3490-00-FETCH-V0CALENDARIO-DB-CLOSE-2 */
        public void R3490_00_FETCH_V0CALENDARIO_DB_CLOSE_2()
        {
            /*" -2911- EXEC SQL CLOSE V0CALENDARIO END-EXEC */

            V0CALENDARIO.Close();

        }

        [StopWatch]
        /*" R3500-00-SELECT-CBAPOVIG-SECTION */
        private void R3500_00_SELECT_CBAPOVIG_SECTION()
        {
            /*" -2926- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2939- PERFORM R3500_00_SELECT_CBAPOVIG_DB_SELECT_1 */

            R3500_00_SELECT_CBAPOVIG_DB_SELECT_1();

            /*" -2943- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL +100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != +100)
            {

                /*" -2947- DISPLAY 'R3500-00 (ERRO-LEITURA DA CB_APOLICE_VIGPROP)' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS ' ' V1PARC-NRPARCEL */

                $"R3500-00 (ERRO-LEITURA DA CB_APOLICE_VIGPROP) {V1PARC_NUM_APOL} {V1PARC_NRENDOS} {V1PARC_NRPARCEL}"
                .Display();

                /*" -2949- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2950- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -2950- MOVE SPACES TO CBAPOVIG-SITUACAO. */
                _.Move("", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R3500-00-SELECT-CBAPOVIG-DB-SELECT-1 */
        public void R3500_00_SELECT_CBAPOVIG_DB_SELECT_1()
        {
            /*" -2939- EXEC SQL SELECT T1.SITUACAO INTO :CBAPOVIG-SITUACAO FROM SEGUROS.CB_APOLICE_VIGPROP T1 WHERE T1.NUM_APOLICE = :V1PARC-NUM-APOL AND T1.NUM_ENDOSSO = :V1PARC-NRENDOS AND T1.SITUACAO = 'V' AND T1.NUM_PARCELA = (SELECT MIN(T2.NUM_PARCELA) FROM SEGUROS.CB_APOLICE_VIGPROP T2 WHERE T2.NUM_APOLICE = T1.NUM_APOLICE AND T2.NUM_ENDOSSO = T1.NUM_ENDOSSO) WITH UR END-EXEC. */

            var r3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1 = new R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1.Execute(r3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBAPOVIG_SITUACAO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-SELECT-V1PARCELA-SECTION */
        private void R3600_00_SELECT_V1PARCELA_SECTION()
        {
            /*" -2962- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2977- PERFORM R3600_00_SELECT_V1PARCELA_DB_SELECT_1 */

            R3600_00_SELECT_V1PARCELA_DB_SELECT_1();

            /*" -2980- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2981- MOVE ZEROS TO V1PARC-COUNT */
                _.Move(0, V1PARC_COUNT);

                /*" -2982- ELSE */
            }
            else
            {


                /*" -2983- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2984- DISPLAY 'R3600-00 (ERRO - LEITURA DA V1PARCELA)...' */
                    _.Display($"R3600-00 (ERRO - LEITURA DA V1PARCELA)...");

                    /*" -2985- DISPLAY 'TITULO         ' V1MCOB-NRTIT */
                    _.Display($"TITULO         {V1MCOB_NRTIT}");

                    /*" -2986- DISPLAY 'APOLICE        ' V1PARC-NUM-APOL */
                    _.Display($"APOLICE        {V1PARC_NUM_APOL}");

                    /*" -2987- DISPLAY 'ENDOSSO        ' V1PARC-NRENDOS */
                    _.Display($"ENDOSSO        {V1PARC_NRENDOS}");

                    /*" -2988- DISPLAY 'PARCELA        ' V1PARC-NRPARCEL */
                    _.Display($"PARCELA        {V1PARC_NRPARCEL}");

                    /*" -2989- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2990- ELSE */
                }
                else
                {


                    /*" -2991- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -2991- MOVE ZEROS TO V1PARC-COUNT. */
                        _.Move(0, V1PARC_COUNT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R3600-00-SELECT-V1PARCELA-DB-SELECT-1 */
        public void R3600_00_SELECT_V1PARCELA_DB_SELECT_1()
        {
            /*" -2977- EXEC SQL SELECT COUNT(*) INTO :V1PARC-COUNT:VIND-COUNT FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL < :V1PARC-NRPARCEL AND SITUACAO = '0' WITH UR END-EXEC. */

            var r3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 = new R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1.Execute(r3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_COUNT, V1PARC_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-MONTA-CORRECAO-SECTION */
        private void R4100_00_MONTA_CORRECAO_SECTION()
        {
            /*" -3002- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3004- MOVE '1' TO WCH-TIPOINSERT */
            _.Move("1", AREA_DE_WORK.WCH_TIPOINSERT);

            /*" -3005- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3006- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3007- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3008- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -3009- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -3011- MOVE 0802 TO V0HISP-OPERACAO */
            _.Move(0802, V0HISP_OPERACAO);

            /*" -3012- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -3014- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -3015- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -3016- MOVE WS-HH-TIME TO WS-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

            /*" -3017- MOVE WS-MM-TIME TO WS-MINUTO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

            /*" -3020- MOVE WS-SS-TIME TO WS-SEGUNDO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

            /*" -3022- MOVE WTIME-DAY TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAY, V0HISP_HORAOPER);

            /*" -3023- PERFORM R3100-00-SELECT-VENCIMENTO */

            R3100_00_SELECT_VENCIMENTO_SECTION();

            /*" -3024- MOVE W1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(W1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -3025- MOVE V1MCOB-BANCO TO V0HISP-BCOCOBR */
            _.Move(V1MCOB_BANCO, V0HISP_BCOCOBR);

            /*" -3026- MOVE V1MCOB-AGENCIA TO V0HISP-AGECOBR */
            _.Move(V1MCOB_AGENCIA, V0HISP_AGECOBR);

            /*" -3027- MOVE V1MCOB-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1MCOB_NRAVISO, V0HISP_NRAVISO);

            /*" -3028- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3029- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3030- MOVE V1ENDO-COD-USUAR TO V0HISP-COD-USUARIO */
            _.Move(V1ENDO_COD_USUAR, V0HISP_COD_USUARIO);

            /*" -3031- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3032- MOVE V1MCOB-DTQITBCO TO V0HISP-DTQITBCO */
            _.Move(V1MCOB_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3033- MOVE 0 TO VIND-DTQITBCO */
            _.Move(0, VIND_DTQITBCO);

            /*" -3035- MOVE ZEROS TO V0HISP-COD-EMPRESA */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3036- MOVE W3-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(W3_PRM_TAR, V0HISP_PRM_TAR);

            /*" -3037- MOVE W3-VAL-DES TO V0HISP-VAL-DESC */
            _.Move(W3_VAL_DES, V0HISP_VAL_DESC);

            /*" -3038- MOVE W3-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(W3_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -3039- MOVE W3-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(W3_VLADIFRA, V0HISP_VLADIFRA);

            /*" -3040- MOVE W3-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(W3_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -3041- MOVE W3-VLIOCC TO V0HISP-VLIOCC */
            _.Move(W3_VLIOCC, V0HISP_VLIOCC);

            /*" -3042- MOVE W3-VLPRMTOT TO V0HISP-VLPRMTOT V0HISP-VLPREMIO. */
            _.Move(W3_VLPRMTOT, V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-MONTA-COBRANCA-SECTION */
        private void R4200_00_MONTA_COBRANCA_SECTION()
        {
            /*" -3053- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3055- MOVE '2' TO WCH-TIPOINSERT */
            _.Move("2", AREA_DE_WORK.WCH_TIPOINSERT);

            /*" -3056- MOVE V1PARC-NUM-APOL TO V0HISP-NUM-APOL */
            _.Move(V1PARC_NUM_APOL, V0HISP_NUM_APOL);

            /*" -3057- MOVE V1PARC-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0HISP_NRENDOS);

            /*" -3058- MOVE V1PARC-NRPARCEL TO V0HISP-NRPARCEL */
            _.Move(V1PARC_NRPARCEL, V0HISP_NRPARCEL);

            /*" -3059- MOVE V1PARC-DACPARC TO V0HISP-DACPARC */
            _.Move(V1PARC_DACPARC, V0HISP_DACPARC);

            /*" -3066- MOVE V1SIST-DTMOVABE TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0HISP_DTMOVTO);

            /*" -3067- IF FLAG-BAIXA EQUAL ' ' */

            if (AREA_DE_WORK.FLAG_BAIXA == " ")
            {

                /*" -3068- IF WVALOR-DIFEREN EQUAL ZEROS */

                if (AREA_DE_WORK.WVALOR_DIFEREN == 00)
                {

                    /*" -3069- MOVE 0231 TO V0HISP-OPERACAO */
                    _.Move(0231, V0HISP_OPERACAO);

                    /*" -3070- ELSE */
                }
                else
                {


                    /*" -3071- MOVE 0241 TO V0HISP-OPERACAO */
                    _.Move(0241, V0HISP_OPERACAO);

                    /*" -3072- ELSE */
                }

            }
            else
            {


                /*" -3073- IF FLAG-BAIXA EQUAL 'S' */

                if (AREA_DE_WORK.FLAG_BAIXA == "S")
                {

                    /*" -3074- MOVE 0234 TO V0HISP-OPERACAO */
                    _.Move(0234, V0HISP_OPERACAO);

                    /*" -3075- ELSE */
                }
                else
                {


                    /*" -3077- MOVE 0244 TO V0HISP-OPERACAO. */
                    _.Move(0244, V0HISP_OPERACAO);
                }

            }


            /*" -3078- ADD +1 TO WOCORHIST */
            WOCORHIST.Value = WOCORHIST + +1;

            /*" -3080- MOVE WOCORHIST TO V0HISP-OCORHIST */
            _.Move(WOCORHIST, V0HISP_OCORHIST);

            /*" -3081- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -3082- MOVE WS-HH-TIME TO WS-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

            /*" -3083- MOVE WS-MM-TIME TO WS-MINUTO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

            /*" -3086- MOVE WS-SS-TIME TO WS-SEGUNDO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

            /*" -3088- MOVE WTIME-DAY TO V0HISP-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAY, V0HISP_HORAOPER);

            /*" -3089- PERFORM R3100-00-SELECT-VENCIMENTO */

            R3100_00_SELECT_VENCIMENTO_SECTION();

            /*" -3090- MOVE W1HISP-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(W1HISP_DTVENCTO, V0HISP_DTVENCTO);

            /*" -3091- MOVE V1MCOB-BANCO TO V0HISP-BCOCOBR */
            _.Move(V1MCOB_BANCO, V0HISP_BCOCOBR);

            /*" -3092- MOVE V1MCOB-AGENCIA TO V0HISP-AGECOBR */
            _.Move(V1MCOB_AGENCIA, V0HISP_AGECOBR);

            /*" -3093- MOVE V1MCOB-NRAVISO TO V0HISP-NRAVISO */
            _.Move(V1MCOB_NRAVISO, V0HISP_NRAVISO);

            /*" -3094- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3095- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3096- MOVE V1ENDO-COD-USUAR TO V0HISP-COD-USUARIO */
            _.Move(V1ENDO_COD_USUAR, V0HISP_COD_USUARIO);

            /*" -3097- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3098- MOVE V1MCOB-DTQITBCO TO V0HISP-DTQITBCO */
            _.Move(V1MCOB_DTQITBCO, V0HISP_DTQITBCO);

            /*" -3099- MOVE 0 TO VIND-DTQITBCO */
            _.Move(0, VIND_DTQITBCO);

            /*" -3101- MOVE ZEROS TO V0HISP-COD-EMPRESA */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3102- MOVE W0-PRM-TAR TO V0HISP-PRM-TAR */
            _.Move(W0_PRM_TAR, V0HISP_PRM_TAR);

            /*" -3103- MOVE W0-VAL-DES TO V0HISP-VAL-DESC */
            _.Move(W0_VAL_DES, V0HISP_VAL_DESC);

            /*" -3104- MOVE W0-VLPRMLIQ TO V0HISP-VLPRMLIQ */
            _.Move(W0_VLPRMLIQ, V0HISP_VLPRMLIQ);

            /*" -3105- MOVE W0-VLADIFRA TO V0HISP-VLADIFRA */
            _.Move(W0_VLADIFRA, V0HISP_VLADIFRA);

            /*" -3106- MOVE W0-VLCUSEMI TO V0HISP-VLCUSEMI */
            _.Move(W0_VLCUSEMI, V0HISP_VLCUSEMI);

            /*" -3107- MOVE W0-VLIOCC TO V0HISP-VLIOCC */
            _.Move(W0_VLIOCC, V0HISP_VLIOCC);

            /*" -3108- MOVE W0-VLPRMTOT TO V0HISP-VLPRMTOT */
            _.Move(W0_VLPRMTOT, V0HISP_VLPRMTOT);

            /*" -3108- MOVE V1MCOB-VALTIT TO V0HISP-VLPREMIO. */
            _.Move(V1MCOB_VALTIT, V0HISP_VLPREMIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4250-00-MONTA-V0FOLLOWUP-SECTION */
        private void R4250_00_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -3119- MOVE '4250' TO WNR-EXEC-SQL. */
            _.Move("4250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3120- MOVE V1PARC-NUM-APOL TO V0FOLP-NUM-APOL. */
            _.Move(V1PARC_NUM_APOL, V0FOLP_NUM_APOL);

            /*" -3121- MOVE V1PARC-NRENDOS TO V0FOLP-NRENDOS */
            _.Move(V1PARC_NRENDOS, V0FOLP_NRENDOS);

            /*" -3122- MOVE V1PARC-NRPARCEL TO V0FOLP-NRPARCEL */
            _.Move(V1PARC_NRPARCEL, V0FOLP_NRPARCEL);

            /*" -3123- MOVE V1PARC-DACPARC TO V0FOLP-DACPARC */
            _.Move(V1PARC_DACPARC, V0FOLP_DACPARC);

            /*" -3125- MOVE V1SIST-DTMOVABE TO V0FOLP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0FOLP_DTMOVTO);

            /*" -3126- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -3127- MOVE WS-HH-TIME TO WS-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

            /*" -3128- MOVE WS-MM-TIME TO WS-MINUTO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

            /*" -3131- MOVE WS-SS-TIME TO WS-SEGUNDO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

            /*" -3133- MOVE WTIME-DAY TO V0FOLP-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAY, V0FOLP_HORAOPER);

            /*" -3134- MOVE V1MCOB-VALTIT TO V0FOLP-VLPREMIO */
            _.Move(V1MCOB_VALTIT, V0FOLP_VLPREMIO);

            /*" -3135- MOVE V1MCOB-BANCO TO V0FOLP-BCOAVISO */
            _.Move(V1MCOB_BANCO, V0FOLP_BCOAVISO);

            /*" -3136- MOVE V1MCOB-AGENCIA TO V0FOLP-AGEAVISO */
            _.Move(V1MCOB_AGENCIA, V0FOLP_AGEAVISO);

            /*" -3137- MOVE V1MCOB-NRAVISO TO V0FOLP-NRAVISO */
            _.Move(V1MCOB_NRAVISO, V0FOLP_NRAVISO);

            /*" -3138- MOVE 30 TO V0FOLP-CODBAIXA */
            _.Move(30, V0FOLP_CODBAIXA);

            /*" -3139- MOVE '0' TO V0FOLP-SITUACAO */
            _.Move("0", V0FOLP_SITUACAO);

            /*" -3140- MOVE '0' TO V0FOLP-SITCONTB */
            _.Move("0", V0FOLP_SITCONTB);

            /*" -3141- MOVE 103 TO V0FOLP-OPERACAO */
            _.Move(103, V0FOLP_OPERACAO);

            /*" -3142- MOVE -1 TO VIND-DTLIBER */
            _.Move(-1, VIND_DTLIBER);

            /*" -3143- MOVE V1MCOB-DTQITBCO TO V0FOLP-DTQITBCO */
            _.Move(V1MCOB_DTQITBCO, V0FOLP_DTQITBCO);

            /*" -3143- MOVE ZEROS TO V0FOLP-COD-EMPRESA. */
            _.Move(0, V0FOLP_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4250_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-MONTA-V0FOLLOWUP-SECTION */
        private void R4300_00_MONTA_V0FOLLOWUP_SECTION()
        {
            /*" -3154- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3155- IF V1MCOB-NUM-APOL EQUAL ZEROS */

            if (V1MCOB_NUM_APOL == 00)
            {

                /*" -3156- MOVE V1MCOB-NRTIT TO V0FOLP-NUM-APOL */
                _.Move(V1MCOB_NRTIT, V0FOLP_NUM_APOL);

                /*" -3157- ELSE */
            }
            else
            {


                /*" -3159- MOVE V1MCOB-NUM-APOL TO V0FOLP-NUM-APOL. */
                _.Move(V1MCOB_NUM_APOL, V0FOLP_NUM_APOL);
            }


            /*" -3160- MOVE V1MCOB-NRENDOS TO V0FOLP-NRENDOS */
            _.Move(V1MCOB_NRENDOS, V0FOLP_NRENDOS);

            /*" -3161- MOVE V1MCOB-NRPARCEL TO V0FOLP-NRPARCEL */
            _.Move(V1MCOB_NRPARCEL, V0FOLP_NRPARCEL);

            /*" -3162- MOVE ZEROS TO V0FOLP-DACPARC */
            _.Move(0, V0FOLP_DACPARC);

            /*" -3164- MOVE V1SIST-DTMOVABE TO V0FOLP-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0FOLP_DTMOVTO);

            /*" -3165- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -3166- MOVE WS-HH-TIME TO WS-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAY.WS_HORA);

            /*" -3167- MOVE WS-MM-TIME TO WS-MINUTO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAY.WS_MINUTO);

            /*" -3170- MOVE WS-SS-TIME TO WS-SEGUNDO */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAY.WS_SEGUNDO);

            /*" -3172- MOVE WTIME-DAY TO V0FOLP-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAY, V0FOLP_HORAOPER);

            /*" -3173- MOVE V1MCOB-VALTIT TO V0FOLP-VLPREMIO */
            _.Move(V1MCOB_VALTIT, V0FOLP_VLPREMIO);

            /*" -3174- MOVE V1MCOB-BANCO TO V0FOLP-BCOAVISO */
            _.Move(V1MCOB_BANCO, V0FOLP_BCOAVISO);

            /*" -3175- MOVE V1MCOB-AGENCIA TO V0FOLP-AGEAVISO */
            _.Move(V1MCOB_AGENCIA, V0FOLP_AGEAVISO);

            /*" -3176- MOVE V1MCOB-NRAVISO TO V0FOLP-NRAVISO */
            _.Move(V1MCOB_NRAVISO, V0FOLP_NRAVISO);

            /*" -3177- MOVE 30 TO V0FOLP-CODBAIXA */
            _.Move(30, V0FOLP_CODBAIXA);

            /*" -3178- MOVE '0' TO V0FOLP-SITUACAO */
            _.Move("0", V0FOLP_SITUACAO);

            /*" -3179- MOVE '0' TO V0FOLP-SITCONTB */
            _.Move("0", V0FOLP_SITCONTB);

            /*" -3180- MOVE 103 TO V0FOLP-OPERACAO */
            _.Move(103, V0FOLP_OPERACAO);

            /*" -3181- MOVE -1 TO VIND-DTLIBER */
            _.Move(-1, VIND_DTLIBER);

            /*" -3182- MOVE V1MCOB-DTQITBCO TO V0FOLP-DTQITBCO */
            _.Move(V1MCOB_DTQITBCO, V0FOLP_DTQITBCO);

            /*" -3182- MOVE ZEROS TO V0FOLP-COD-EMPRESA. */
            _.Move(0, V0FOLP_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-INSERT-V0HISTOPARC-SECTION */
        private void R5100_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3193- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3194- IF WCH-TIPOINSERT EQUAL '1' */

            if (AREA_DE_WORK.WCH_TIPOINSERT == "1")
            {

                /*" -3195- IF W3-VLPRMTOT EQUAL ZEROS */

                if (W3_VLPRMTOT == 00)
                {

                    /*" -3213- GO TO R5100-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3242- PERFORM R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3245- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3249- DISPLAY 'R5100-00 (REGISTRO DUPLICADO) ... ' ' ' V0HISP-NUM-APOL ' ' V0HISP-NRENDOS ' ' V0HISP-NRPARCEL */

                $"R5100-00 (REGISTRO DUPLICADO) ...  {V0HISP_NUM_APOL} {V0HISP_NRENDOS} {V0HISP_NRPARCEL}"
                .Display();

                /*" -3251- GO TO R5100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3252- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3256- DISPLAY 'R5100-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0HISP-NUM-APOL ' ' V0HISP-NRENDOS ' ' V0HISP-NRPARCEL */

                $"R5100-00 (PROBLEMAS NA INSERCAO) ...  {V0HISP_NUM_APOL} {V0HISP_NRENDOS} {V0HISP_NRPARCEL}"
                .Display();

                /*" -3258- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3258- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R5100-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3242- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , :V0HISP-HORAOPER , :V0HISP-OCORHIST , :V0HISP-PRM-TAR , :V0HISP-VAL-DESC , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUARIO , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO, :V0HISP-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_HORAOPER = V0HISP_HORAOPER.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TAR = V0HISP_PRM_TAR.ToString(),
                V0HISP_VAL_DESC = V0HISP_VAL_DESC.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUARIO = V0HISP_COD_USUARIO.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-INSERT-V0FOLLOWUP-SECTION */
        private void R5200_00_INSERT_V0FOLLOWUP_SECTION()
        {
            /*" -3269- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3271- MOVE V1MCOB-NUM-NOSSO TO V0FOLP-NUM-NOSSO. */
            _.Move(V1MCOB_NUM_NOSSO, V0FOLP_NUM_NOSSO);

            /*" -3272- IF V0FOLP-NRPARCEL EQUAL ( 0 OR 1) */

            if (V0FOLP_NRPARCEL.In("0", "1"))
            {

                /*" -3273- MOVE V1ENDO-NRRCAP TO V0FOLP-NRRCAP */
                _.Move(V1ENDO_NRRCAP, V0FOLP_NRRCAP);

                /*" -3274- ELSE */
            }
            else
            {


                /*" -3289- MOVE ZEROS TO V0FOLP-NRRCAP. */
                _.Move(0, V0FOLP_NRRCAP);
            }


            /*" -3323- PERFORM R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1 */

            R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1();

            /*" -3326- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3330- DISPLAY 'R5200-00 (REGISTRO DUPLICADO) ... ' ' ' V0FOLP-NUM-APOL ' ' V0FOLP-NRENDOS ' ' V0FOLP-NRPARCEL */

                $"R5200-00 (REGISTRO DUPLICADO) ...  {V0FOLP_NUM_APOL} {V0FOLP_NRENDOS} {V0FOLP_NRPARCEL}"
                .Display();

                /*" -3332- GO TO R5200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3337- DISPLAY 'R5200-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0FOLP-NUM-APOL ' ' V0FOLP-NRENDOS ' ' V0FOLP-NRPARCEL */

                $"R5200-00 (PROBLEMAS NA INSERCAO) ...  {V0FOLP_NUM_APOL} {V0FOLP_NRENDOS} {V0FOLP_NRPARCEL}"
                .Display();

                /*" -3339- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3340- IF W1MCOB-NOME NOT EQUAL 'TITULO EM DUPLICIDADE' */

            if (W1MCOB_NOME != "TITULO EM DUPLICIDADE")
            {

                /*" -3342- PERFORM R6150-00-UPDATE-V0PARCELA. */

                R6150_00_UPDATE_V0PARCELA_SECTION();
            }


            /*" -3342- ADD +1 TO AC-I-V0FOLLOWUP. */
            AREA_DE_WORK.AC_I_V0FOLLOWUP.Value = AREA_DE_WORK.AC_I_V0FOLLOWUP + +1;

        }

        [StopWatch]
        /*" R5200-00-INSERT-V0FOLLOWUP-DB-INSERT-1 */
        public void R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1()
        {
            /*" -3323- EXEC SQL INSERT INTO SEGUROS.V0FOLLOWUP VALUES (:V0FOLP-NUM-APOL, :V0FOLP-NRENDOS, :V0FOLP-NRPARCEL, :V0FOLP-DACPARC, :V0FOLP-DTMOVTO, :V0FOLP-HORAOPER, :V0FOLP-VLPREMIO, :V0FOLP-BCOAVISO, :V0FOLP-AGEAVISO, :V0FOLP-NRAVISO, :V0FOLP-CODBAIXA, :V0FOLP-CDERRO01, :V0FOLP-CDERRO02, :V0FOLP-CDERRO03, :V0FOLP-CDERRO04, :V0FOLP-CDERRO05, :V0FOLP-CDERRO06, :V0FOLP-SITUACAO, :V0FOLP-SITCONTB, :V0FOLP-OPERACAO, :V0FOLP-DTLIBER:VIND-DTLIBER, :V0FOLP-DTQITBCO, :V0FOLP-COD-EMPRESA, CURRENT TIMESTAMP, NULL, '1' , NULL, NULL, NULL, :V1ENDO-FONTE, :V0FOLP-NRRCAP, :V0FOLP-NUM-NOSSO) END-EXEC. */

            var r5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 = new R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1()
            {
                V0FOLP_NUM_APOL = V0FOLP_NUM_APOL.ToString(),
                V0FOLP_NRENDOS = V0FOLP_NRENDOS.ToString(),
                V0FOLP_NRPARCEL = V0FOLP_NRPARCEL.ToString(),
                V0FOLP_DACPARC = V0FOLP_DACPARC.ToString(),
                V0FOLP_DTMOVTO = V0FOLP_DTMOVTO.ToString(),
                V0FOLP_HORAOPER = V0FOLP_HORAOPER.ToString(),
                V0FOLP_VLPREMIO = V0FOLP_VLPREMIO.ToString(),
                V0FOLP_BCOAVISO = V0FOLP_BCOAVISO.ToString(),
                V0FOLP_AGEAVISO = V0FOLP_AGEAVISO.ToString(),
                V0FOLP_NRAVISO = V0FOLP_NRAVISO.ToString(),
                V0FOLP_CODBAIXA = V0FOLP_CODBAIXA.ToString(),
                V0FOLP_CDERRO01 = V0FOLP_CDERRO01.ToString(),
                V0FOLP_CDERRO02 = V0FOLP_CDERRO02.ToString(),
                V0FOLP_CDERRO03 = V0FOLP_CDERRO03.ToString(),
                V0FOLP_CDERRO04 = V0FOLP_CDERRO04.ToString(),
                V0FOLP_CDERRO05 = V0FOLP_CDERRO05.ToString(),
                V0FOLP_CDERRO06 = V0FOLP_CDERRO06.ToString(),
                V0FOLP_SITUACAO = V0FOLP_SITUACAO.ToString(),
                V0FOLP_SITCONTB = V0FOLP_SITCONTB.ToString(),
                V0FOLP_OPERACAO = V0FOLP_OPERACAO.ToString(),
                V0FOLP_DTLIBER = V0FOLP_DTLIBER.ToString(),
                VIND_DTLIBER = VIND_DTLIBER.ToString(),
                V0FOLP_DTQITBCO = V0FOLP_DTQITBCO.ToString(),
                V0FOLP_COD_EMPRESA = V0FOLP_COD_EMPRESA.ToString(),
                V1ENDO_FONTE = V1ENDO_FONTE.ToString(),
                V0FOLP_NRRCAP = V0FOLP_NRRCAP.ToString(),
                V0FOLP_NUM_NOSSO = V0FOLP_NUM_NOSSO.ToString(),
            };

            R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1.Execute(r5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-UPDATE-V0PARCELA-SECTION */
        private void R6100_00_UPDATE_V0PARCELA_SECTION()
        {
            /*" -3355- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3367- PERFORM R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -3370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3371- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3372- DISPLAY 'R6100-00 (PARCELA NAO ENCONTRADA) ...' */
                    _.Display($"R6100-00 (PARCELA NAO ENCONTRADA) ...");

                    /*" -3373- DISPLAY 'APOLICE ' V1PARC-NUM-APOL */
                    _.Display($"APOLICE {V1PARC_NUM_APOL}");

                    /*" -3374- DISPLAY 'ENDOSSO ' V1PARC-NRENDOS */
                    _.Display($"ENDOSSO {V1PARC_NRENDOS}");

                    /*" -3375- DISPLAY 'PARCELA ' V1PARC-NRPARCEL */
                    _.Display($"PARCELA {V1PARC_NRPARCEL}");

                    /*" -3376- DISPLAY 'TITULO  ' V1MCOB-NRTIT */
                    _.Display($"TITULO  {V1MCOB_NRTIT}");

                    /*" -3377- GO TO R6100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/ //GOTO
                    return;

                    /*" -3378- ELSE */
                }
                else
                {


                    /*" -3380- DISPLAY 'R6100-00 (PROBLEMAS UPDATE V0PARCELA) ... ' ' ' V1MCOB-NRTIT */

                    $"R6100-00 (PROBLEMAS UPDATE V0PARCELA) ...  {V1MCOB_NRTIT}"
                    .Display();

                    /*" -3382- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3382- ADD +1 TO AC-U-V0PARCELA. */
            AREA_DE_WORK.AC_U_V0PARCELA.Value = AREA_DE_WORK.AC_U_V0PARCELA + +1;

        }

        [StopWatch]
        /*" R6100-00-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -3367- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = :WOCORHIST, SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL END-EXEC. */

            var r6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WOCORHIST = WOCORHIST.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-INCLUI-AUTO-COMPL-SECTION */
        private void R6110_00_INCLUI_AUTO_COMPL_SECTION()
        {
            /*" -3392- IF WS-FLAG-AUTO NOT = 1 */

            if (WS_FLAG_AUTO != 1)
            {

                /*" -3393- GO TO R6110-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/ //GOTO
                return;

                /*" -3395- END-IF */
            }


            /*" -3396- MOVE V1PARC-NUM-APOL TO AU071-NUM-APOLICE */
            _.Move(V1PARC_NUM_APOL, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE);

            /*" -3397- MOVE V1PARC-NRENDOS TO AU071-NUM-ENDOSSO */
            _.Move(V1PARC_NRENDOS, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO);

            /*" -3398- MOVE V1PARC-NRPARCEL TO AU071-NUM-PARCELA */
            _.Move(V1PARC_NRPARCEL, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA);

            /*" -3399- MOVE 2 TO AU071-NUM-VENCTO */
            _.Move(2, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

            /*" -3401- MOVE 0 TO WS-QT-REG */
            _.Move(0, WS_QT_REG);

            /*" -3410- PERFORM R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1 */

            R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1();

            /*" -3413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3414- DISPLAY 'PROBLEMA NA LEITURA .PARCELA_AUTO_COMPL' */
                _.Display($"PROBLEMA NA LEITURA .PARCELA_AUTO_COMPL");

                /*" -3415- DISPLAY 'APOLICE  ' AU071-NUM-APOLICE */
                _.Display($"APOLICE  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE}");

                /*" -3416- DISPLAY 'ENDOSSO  ' AU071-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO}");

                /*" -3417- DISPLAY 'PARCELA  ' AU071-NUM-PARCELA */
                _.Display($"PARCELA  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA}");

                /*" -3418- DISPLAY 'NUMERO   ' AU071-NUM-VENCTO */
                _.Display($"NUMERO   {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO}");

                /*" -3419- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3421- END-IF */
            }


            /*" -3422- IF WS-QT-REG > 0 */

            if (WS_QT_REG > 0)
            {

                /*" -3423- MOVE 3 TO AU071-NUM-VENCTO */
                _.Move(3, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

                /*" -3425- MOVE 0 TO WS-QT-REG */
                _.Move(0, WS_QT_REG);

                /*" -3434- PERFORM R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2 */

                R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2();

                /*" -3437- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3438- DISPLAY 'PROBLEMA NA 2 LEITURA .PARCELA_AUTO_COMPL' */
                    _.Display($"PROBLEMA NA 2 LEITURA .PARCELA_AUTO_COMPL");

                    /*" -3439- DISPLAY 'APOLICE  ' AU071-NUM-APOLICE */
                    _.Display($"APOLICE  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE}");

                    /*" -3440- DISPLAY 'ENDOSSO  ' AU071-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO}");

                    /*" -3441- DISPLAY 'PARCELA  ' AU071-NUM-PARCELA */
                    _.Display($"PARCELA  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA}");

                    /*" -3442- DISPLAY 'NUMERO   ' AU071-NUM-VENCTO */
                    _.Display($"NUMERO   {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO}");

                    /*" -3443- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3445- END-IF */
                }


                /*" -3446- IF WS-QT-REG > 0 */

                if (WS_QT_REG > 0)
                {

                    /*" -3447- GO TO R6110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/ //GOTO
                    return;

                    /*" -3448- ELSE */
                }
                else
                {


                    /*" -3449- MOVE 2 TO AU071-NUM-VENCTO */
                    _.Move(2, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

                    /*" -3451- END-IF */
                }


                /*" -3457- PERFORM R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1 */

                R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1();

                /*" -3460- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3461- DISPLAY 'PROBLEMA NA DELECAO .PARCELA_AUTO_COMPL' */
                    _.Display($"PROBLEMA NA DELECAO .PARCELA_AUTO_COMPL");

                    /*" -3462- DISPLAY 'APOLICE  ' AU071-NUM-APOLICE */
                    _.Display($"APOLICE  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE}");

                    /*" -3463- DISPLAY 'ENDOSSO  ' AU071-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO}");

                    /*" -3464- DISPLAY 'PARCELA  ' AU071-NUM-PARCELA */
                    _.Display($"PARCELA  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA}");

                    /*" -3465- DISPLAY 'NUMERO   ' AU071-NUM-VENCTO */
                    _.Display($"NUMERO   {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO}");

                    /*" -3466- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3467- END-IF */
                }


                /*" -3469- END-IF */
            }


            /*" -3470- MOVE V1PARC-NRTIT TO AU071-NUM-RECIBO-CONV */
            _.Move(V1PARC_NRTIT, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_RECIBO_CONV);

            /*" -3471- MOVE V0HISP-DTQITBCO TO AU071-DTA-VENCTO */
            _.Move(V0HISP_DTQITBCO, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);

            /*" -3472- MOVE V1PARC-OTNPRLIQ TO AU071-VLR-PREMIO-LIQUIDO */
            _.Move(V1PARC_OTNPRLIQ, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO);

            /*" -3473- MOVE V1PARC-OTNADFRA TO AU071-VLR-ADIC-FRAC */
            _.Move(V1PARC_OTNADFRA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC);

            /*" -3474- MOVE V1PARC-OTNCUSTO TO AU071-VLR-CUSTO */
            _.Move(V1PARC_OTNCUSTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO);

            /*" -3475- MOVE V1PARC-OTNIOF TO AU071-VLR-IOF */
            _.Move(V1PARC_OTNIOF, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF);

            /*" -3476- MOVE WS-VL-JUROS TO AU071-VLR-JUROS */
            _.Move(WS_VL_JUROS, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS);

            /*" -3478- MOVE WS-VL-MULTA TO AU071-VLR-MULTA */
            _.Move(WS_VL_MULTA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);

            /*" -3498- COMPUTE AU071-VLR-PREMIO-TOTAL = V1PARC-OTNPRLIQ + V1PARC-OTNADFRA + V1PARC-OTNCUSTO + V1PARC-OTNIOF + WS-VL-JUROS + WS-VL-MULTA */
            AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL.Value = V1PARC_OTNPRLIQ + V1PARC_OTNADFRA + V1PARC_OTNCUSTO + V1PARC_OTNIOF + WS_VL_JUROS + WS_VL_MULTA;

            /*" -3531- PERFORM R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1 */

            R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1();

            /*" -3534- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3535- DISPLAY 'PROBLEMA NA INCLUSAO .PARCELA_AUTO_COMPL' */
                _.Display($"PROBLEMA NA INCLUSAO .PARCELA_AUTO_COMPL");

                /*" -3536- DISPLAY 'APOLICE  ' AU071-NUM-APOLICE */
                _.Display($"APOLICE  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE}");

                /*" -3537- DISPLAY 'ENDOSSO  ' AU071-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO}");

                /*" -3538- DISPLAY 'PARCELA  ' AU071-NUM-PARCELA */
                _.Display($"PARCELA  {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA}");

                /*" -3539- DISPLAY 'RECIBO   ' AU071-NUM-RECIBO-CONV */
                _.Display($"RECIBO   {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_RECIBO_CONV}");

                /*" -3540- DISPLAY 'NUMERO   ' AU071-NUM-VENCTO */
                _.Display($"NUMERO   {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO}");

                /*" -3541- DISPLAY 'DATA     ' AU071-DTA-VENCTO */
                _.Display($"DATA     {AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO}");

                /*" -3542- DISPLAY 'VL LIQ   ' AU071-VLR-PREMIO-LIQUIDO */
                _.Display($"VL LIQ   {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO}");

                /*" -3543- DISPLAY 'VL ADIC  ' AU071-VLR-ADIC-FRAC */
                _.Display($"VL ADIC  {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC}");

                /*" -3544- DISPLAY 'VL CUSTO ' AU071-VLR-CUSTO */
                _.Display($"VL CUSTO {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO}");

                /*" -3545- DISPLAY 'VL IOF   ' AU071-VLR-IOF */
                _.Display($"VL IOF   {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF}");

                /*" -3546- DISPLAY 'VL JUROS ' AU071-VLR-JUROS */
                _.Display($"VL JUROS {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS}");

                /*" -3547- DISPLAY 'VL MULTA ' AU071-VLR-MULTA */
                _.Display($"VL MULTA {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA}");

                /*" -3548- DISPLAY 'VL TOTAL ' AU071-VLR-PREMIO-TOTAL */
                _.Display($"VL TOTAL {AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL}");

                /*" -3549- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3549- END-IF. */
            }


        }

        [StopWatch]
        /*" R6110-00-INCLUI-AUTO-COMPL-DB-SELECT-1 */
        public void R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1()
        {
            /*" -3410- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-QT-REG FROM SEGUROS.PARCELA_AUTO_COMPL WHERE NUM_APOLICE = :AU071-NUM-APOLICE AND NUM_ENDOSSO = :AU071-NUM-ENDOSSO AND NUM_PARCELA = :AU071-NUM-PARCELA AND NUM_VENCTO = :AU071-NUM-VENCTO WITH UR END-EXEC */

            var r6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1_Query1 = new R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1_Query1()
            {
                AU071_NUM_APOLICE = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE.ToString(),
                AU071_NUM_ENDOSSO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO.ToString(),
                AU071_NUM_PARCELA = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA.ToString(),
                AU071_NUM_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO.ToString(),
            };

            var executed_1 = R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1_Query1.Execute(r6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_REG, WS_QT_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-INCLUI-AUTO-COMPL-DB-DELETE-1 */
        public void R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1()
        {
            /*" -3457- EXEC SQL DELETE FROM SEGUROS.PARCELA_AUTO_COMPL WHERE NUM_APOLICE = :AU071-NUM-APOLICE AND NUM_ENDOSSO = :AU071-NUM-ENDOSSO AND NUM_PARCELA = :AU071-NUM-PARCELA AND NUM_VENCTO = :AU071-NUM-VENCTO END-EXEC */

            var r6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1 = new R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1()
            {
                AU071_NUM_APOLICE = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE.ToString(),
                AU071_NUM_ENDOSSO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO.ToString(),
                AU071_NUM_PARCELA = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA.ToString(),
                AU071_NUM_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO.ToString(),
            };

            R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1.Execute(r6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" R6110-00-INCLUI-AUTO-COMPL-DB-INSERT-1 */
        public void R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1()
        {
            /*" -3531- EXEC SQL INSERT INTO SEGUROS.PARCELA_AUTO_COMPL ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DTA_VENCTO , NUM_VENCTO , VLR_PREMIO_LIQUIDO , VLR_JUROS , VLR_ADIC_FRAC , VLR_MULTA , VLR_CUSTO , VLR_IOF , VLR_PREMIO_TOTAL , NUM_RECIBO_CONV , COD_USUARIO , DTH_TIMESTAMP ) VALUES ( :AU071-NUM-APOLICE , :AU071-NUM-ENDOSSO , :AU071-NUM-PARCELA , :AU071-DTA-VENCTO , :AU071-NUM-VENCTO , :AU071-VLR-PREMIO-LIQUIDO , :AU071-VLR-JUROS , :AU071-VLR-ADIC-FRAC , :AU071-VLR-MULTA , :AU071-VLR-CUSTO , :AU071-VLR-IOF , :AU071-VLR-PREMIO-TOTAL , :AU071-NUM-RECIBO-CONV , 'CB0003B' , CURRENT TIMESTAMP ) END-EXEC. */

            var r6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1_Insert1 = new R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1_Insert1()
            {
                AU071_NUM_APOLICE = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE.ToString(),
                AU071_NUM_ENDOSSO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO.ToString(),
                AU071_NUM_PARCELA = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA.ToString(),
                AU071_DTA_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO.ToString(),
                AU071_NUM_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO.ToString(),
                AU071_VLR_PREMIO_LIQUIDO = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO.ToString(),
                AU071_VLR_JUROS = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS.ToString(),
                AU071_VLR_ADIC_FRAC = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC.ToString(),
                AU071_VLR_MULTA = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA.ToString(),
                AU071_VLR_CUSTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO.ToString(),
                AU071_VLR_IOF = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF.ToString(),
                AU071_VLR_PREMIO_TOTAL = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL.ToString(),
                AU071_NUM_RECIBO_CONV = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_RECIBO_CONV.ToString(),
            };

            R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1_Insert1.Execute(r6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R6110-00-INCLUI-AUTO-COMPL-DB-SELECT-2 */
        public void R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2()
        {
            /*" -3434- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-QT-REG FROM SEGUROS.PARCELA_AUTO_COMPL WHERE NUM_APOLICE = :AU071-NUM-APOLICE AND NUM_ENDOSSO = :AU071-NUM-ENDOSSO AND NUM_PARCELA = :AU071-NUM-PARCELA AND NUM_VENCTO = :AU071-NUM-VENCTO WITH UR END-EXEC */

            var r6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1 = new R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1()
            {
                AU071_NUM_APOLICE = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE.ToString(),
                AU071_NUM_ENDOSSO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO.ToString(),
                AU071_NUM_PARCELA = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA.ToString(),
                AU071_NUM_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO.ToString(),
            };

            var executed_1 = R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1.Execute(r6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_REG, WS_QT_REG);
            }


        }

        [StopWatch]
        /*" R6150-00-UPDATE-V0PARCELA-SECTION */
        private void R6150_00_UPDATE_V0PARCELA_SECTION()
        {
            /*" -3560- MOVE '6150' TO WNR-EXEC-SQL. */
            _.Move("6150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3564- ADD 1 TO WHOST-QTDDOC */
            WHOST_QTDDOC.Value = WHOST_QTDDOC + 1;

            /*" -3575- PERFORM R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -3579- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3580- PERFORM R6160-00-UPDATE-V0PARCELA */

                R6160_00_UPDATE_V0PARCELA_SECTION();

                /*" -3581- ELSE */
            }
            else
            {


                /*" -3582- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3583- DISPLAY 'R6150-00 (PROBLEMAS UPDATE V0PARCELA)   ' */
                    _.Display($"R6150-00 (PROBLEMAS UPDATE V0PARCELA)   ");

                    /*" -3583- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6150-00-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -3575- EXEC SQL UPDATE SEGUROS.V0PARCELA SET QTDDOC = :WHOST-QTDDOC, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND NRPARCEL = :V1PARC-NRPARCEL END-EXEC. */

            var r6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WHOST_QTDDOC = WHOST_QTDDOC.ToString(),
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_99_SAIDA*/

        [StopWatch]
        /*" R6160-00-UPDATE-V0PARCELA-SECTION */
        private void R6160_00_UPDATE_V0PARCELA_SECTION()
        {
            /*" -3596- MOVE '6160' TO WNR-EXEC-SQL. */
            _.Move("6160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3602- PERFORM R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -3605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3606- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3608- DISPLAY 'R6160-00 (PARCELA NAO ENCONTRADA) ...' ' ' V1MCOB-NRTIT */

                    $"R6160-00 (PARCELA NAO ENCONTRADA) ... {V1MCOB_NRTIT}"
                    .Display();

                    /*" -3609- ELSE */
                }
                else
                {


                    /*" -3611- DISPLAY 'R6160-00 (PROBLEMAS UPDATE V0PARCELA) ... ' ' ' V1MCOB-NRTIT */

                    $"R6160-00 (PROBLEMAS UPDATE V0PARCELA) ...  {V1MCOB_NRTIT}"
                    .Display();

                    /*" -3611- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6160-00-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -3602- EXEC SQL UPDATE SEGUROS.V0PARCELA SET QTDDOC = :WHOST-QTDDOC, TIMESTAMP = CURRENT TIMESTAMP WHERE NRTIT = :V1MCOB-NRTIT AND NRPARCEL = :V1PARC-NRPARCEL END-EXEC. */

            var r6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                WHOST_QTDDOC = WHOST_QTDDOC.ToString(),
                V1PARC_NRPARCEL = V1PARC_NRPARCEL.ToString(),
                V1MCOB_NRTIT = V1MCOB_NRTIT.ToString(),
            };

            R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6160_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-UPDATE-V0ENDOSSO-SECTION */
        private void R6200_00_UPDATE_V0ENDOSSO_SECTION()
        {
            /*" -3622- MOVE '6200' TO WNR-EXEC-SQL. */
            _.Move("6200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3624- PERFORM R6210-00-VERIFICA-PARCELAS */

            R6210_00_VERIFICA_PARCELAS_SECTION();

            /*" -3625- IF V1PARC-QUANTIDADE GREATER 0 */

            if (V1PARC_QUANTIDADE > 0)
            {

                /*" -3629- GO TO R6200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3635- PERFORM R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1 */

            R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1();

            /*" -3638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3641- DISPLAY 'R6200-00 (PROBLEMAS UPDATE V0PARCELA) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R6200-00 (PROBLEMAS UPDATE V0PARCELA) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -3643- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3643- ADD +1 TO AC-U-V0ENDOSSO. */
            AREA_DE_WORK.AC_U_V0ENDOSSO.Value = AREA_DE_WORK.AC_U_V0ENDOSSO + +1;

        }

        [StopWatch]
        /*" R6200-00-UPDATE-V0ENDOSSO-DB-UPDATE-1 */
        public void R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -3635- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS END-EXEC. */

            var r6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 = new R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-VERIFICA-PARCELAS-SECTION */
        private void R6210_00_VERIFICA_PARCELAS_SECTION()
        {
            /*" -3654- MOVE '6210' TO WNR-EXEC-SQL. */
            _.Move("6210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3662- PERFORM R6210_00_VERIFICA_PARCELAS_DB_SELECT_1 */

            R6210_00_VERIFICA_PARCELAS_DB_SELECT_1();

            /*" -3666- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3669- DISPLAY 'R6210-00 (PROBLEMAS SELECT V1PARCELA) ... ' ' ' V1PARC-NUM-APOL ' ' V1PARC-NRENDOS */

                $"R6210-00 (PROBLEMAS SELECT V1PARCELA) ...  {V1PARC_NUM_APOL} {V1PARC_NRENDOS}"
                .Display();

                /*" -3671- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3672- IF VIND-QUANTIDADE EQUAL -1 */

            if (VIND_QUANTIDADE == -1)
            {

                /*" -3672- MOVE 99 TO V1PARC-QUANTIDADE. */
                _.Move(99, V1PARC_QUANTIDADE);
            }


        }

        [StopWatch]
        /*" R6210-00-VERIFICA-PARCELAS-DB-SELECT-1 */
        public void R6210_00_VERIFICA_PARCELAS_DB_SELECT_1()
        {
            /*" -3662- EXEC SQL SELECT COUNT(*) INTO :V1PARC-QUANTIDADE:VIND-QUANTIDADE FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1PARC-NUM-APOL AND NRENDOS = :V1PARC-NRENDOS AND SITUACAO = '0' WITH UR END-EXEC. */

            var r6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1 = new R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1()
            {
                V1PARC_NUM_APOL = V1PARC_NUM_APOL.ToString(),
                V1PARC_NRENDOS = V1PARC_NRENDOS.ToString(),
            };

            var executed_1 = R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1.Execute(r6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_QUANTIDADE, V1PARC_QUANTIDADE);
                _.Move(executed_1.VIND_QUANTIDADE, VIND_QUANTIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6210_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-UPDATE-V0MOVICOB-SECTION */
        private void R6300_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -3683- MOVE '6300' TO WNR-EXEC-SQL. */
            _.Move("6300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3684- IF WTEM-NRTIT55 NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WTEM_NRTIT55.IsEmpty())
            {

                /*" -3685- MOVE WS-TITANT TO V0MCOB-NRTIT */
                _.Move(AREA_DE_WORK.WS_TITANT, V0MCOB_NRTIT);

                /*" -3686- ELSE */
            }
            else
            {


                /*" -3692- MOVE V1MCOB-NRTIT TO V0MCOB-NRTIT. */
                _.Move(V1MCOB_NRTIT, V0MCOB_NRTIT);
            }


            /*" -3705- PERFORM R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -3708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3710- DISPLAY 'R6300-00 (PROBLEMAS UPDATE V0MOVICOB) ... ' ' ' V1MCOB-NRTIT */

                $"R6300-00 (PROBLEMAS UPDATE V0MOVICOB) ...  {V1MCOB_NRTIT}"
                .Display();

                /*" -3710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6300-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -3705- EXEC SQL UPDATE SEGUROS.V0MOVICOB SET SITUACAO = :W1MCOB-SITUACAO, NOME = :W1MCOB-NOME, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = :V1MCOB-BANCO AND AGENCIA = :V1MCOB-AGENCIA AND NRAVISO = :V1MCOB-NRAVISO AND NRTIT = :V0MCOB-NRTIT AND NUM_APOLICE = :V1MCOB-NUM-APOL AND NRENDOS = :V1MCOB-NRENDOS AND NRPARCEL = :V1MCOB-NRPARCEL END-EXEC. */

            var r6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1()
            {
                W1MCOB_SITUACAO = W1MCOB_SITUACAO.ToString(),
                W1MCOB_NOME = W1MCOB_NOME.ToString(),
                V1MCOB_NUM_APOL = V1MCOB_NUM_APOL.ToString(),
                V1MCOB_NRPARCEL = V1MCOB_NRPARCEL.ToString(),
                V1MCOB_AGENCIA = V1MCOB_AGENCIA.ToString(),
                V1MCOB_NRAVISO = V1MCOB_NRAVISO.ToString(),
                V1MCOB_NRENDOS = V1MCOB_NRENDOS.ToString(),
                V1MCOB_BANCO = V1MCOB_BANCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
            };

            R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/

        [StopWatch]
        /*" R6400-00-UPDATE-V0AVISALDOS-SECTION */
        private void R6400_00_UPDATE_V0AVISALDOS_SECTION()
        {
            /*" -3723- MOVE '6400' TO WNR-EXEC-SQL. */
            _.Move("6400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3730- PERFORM R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1 */

            R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1();

            /*" -3733- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3738- DISPLAY 'R6400-00 (PROBLEMAS UPDATE V0AVISOS_SALDOS)' ' ' V1MCOB-NRTIT ' ' V1MCOB-BANCO ' ' V1MCOB-AGENCIA ' ' V1MCOB-NRAVISO */

                $"R6400-00 (PROBLEMAS UPDATE V0AVISOS_SALDOS) {V1MCOB_NRTIT} {V1MCOB_BANCO} {V1MCOB_AGENCIA} {V1MCOB_NRAVISO}"
                .Display();

                /*" -3740- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3740- ADD +1 TO AC-U-V0AVISALDOS. */
            AREA_DE_WORK.AC_U_V0AVISALDOS.Value = AREA_DE_WORK.AC_U_V0AVISALDOS + +1;

        }

        [StopWatch]
        /*" R6400-00-UPDATE-V0AVISALDOS-DB-UPDATE-1 */
        public void R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1()
        {
            /*" -3730- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1MCOB-VALTIT) , TIMESTAMP = CURRENT TIMESTAMP WHERE BCOAVISO = :V1MCOB-BANCO AND AGEAVISO = :V1MCOB-AGENCIA AND NRAVISO = :V1MCOB-NRAVISO END-EXEC. */

            var r6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1 = new R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1()
            {
                V1MCOB_VALTIT = V1MCOB_VALTIT.ToString(),
                V1MCOB_AGENCIA = V1MCOB_AGENCIA.ToString(),
                V1MCOB_NRAVISO = V1MCOB_NRAVISO.ToString(),
                V1MCOB_BANCO = V1MCOB_BANCO.ToString(),
            };

            R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1.Execute(r6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-SALDOS-SECTION */
        private void R7000_00_TRATA_SALDOS_SECTION()
        {
            /*" -3751- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3753- PERFORM R7200-00-UPDATE-V0FOLLOW. */

            R7200_00_UPDATE_V0FOLLOW_SECTION();

            /*" -3755- PERFORM R7250-00-UPDATE-V0FOLLOW. */

            R7250_00_UPDATE_V0FOLLOW_SECTION();

            /*" -3755- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-UPDATE-V0FOLLOW-SECTION */
        private void R7200_00_UPDATE_V0FOLLOW_SECTION()
        {
            /*" -3768- MOVE '7200' TO WNR-EXEC-SQL. */
            _.Move("7200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3784- PERFORM R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1 */

            R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1();

            /*" -3788- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3789- DISPLAY 'R7200-00 (PROBLEMAS UPDATE V0FOLLOWUP)  ' */
                _.Display($"R7200-00 (PROBLEMAS UPDATE V0FOLLOWUP)  ");

                /*" -3789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7200-00-UPDATE-V0FOLLOW-DB-UPDATE-1 */
        public void R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1()
        {
            /*" -3784- EXEC SQL UPDATE SEGUROS.V0FOLLOWUP SET NUM_APOLICE = 0104800188097, NRENDOS = 2 , NRPARCEL = 2 , DTLIBER = '2007-06-19' , SITUACAO = '1' , OPERACAO = 201 WHERE NUM_APOLICE = 0104800188097 AND NRENDOS = 2 AND NRPARCEL = 1 AND BCOAVISO = 104 AND AGEAVISO = 7003 AND NRAVISO = 804401735 AND SITUACAO = '0' AND VLPREMIO = 191.82 END-EXEC. */

            var r7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1 = new R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1()
            {
            };

            R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1.Execute(r7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7250-00-UPDATE-V0FOLLOW-SECTION */
        private void R7250_00_UPDATE_V0FOLLOW_SECTION()
        {
            /*" -3800- MOVE '7250' TO WNR-EXEC-SQL. */
            _.Move("7250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3816- PERFORM R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1 */

            R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1();

            /*" -3820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3821- DISPLAY 'R7250-00 (PROBLEMAS UPDATE V0FOLLOWUP)  ' */
                _.Display($"R7250-00 (PROBLEMAS UPDATE V0FOLLOWUP)  ");

                /*" -3821- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7250-00-UPDATE-V0FOLLOW-DB-UPDATE-1 */
        public void R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1()
        {
            /*" -3816- EXEC SQL UPDATE SEGUROS.V0FOLLOWUP SET NUM_APOLICE = 0104800093128, NRENDOS = 5 , NRPARCEL = 3 , DTLIBER = '2007-06-20' , SITUACAO = '1' , OPERACAO = 201 WHERE NUM_APOLICE = 0104800093128 AND NRENDOS = 5 AND NRPARCEL = 2 AND BCOAVISO = 104 AND AGEAVISO = 7003 AND NRAVISO = 804401732 AND SITUACAO = '0' AND VLPREMIO = 148.73 END-EXEC. */

            var r7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1 = new R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1()
            {
            };

            R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1.Execute(r7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7250_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3835- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -3836- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_5.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -3837- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_5.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -3839- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_5.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -3840- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3841- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3842- DISPLAY '*   CB0003B - BAIXA MOVIMENTO DE COBRANCA  *' */
            _.Display($"*   CB0003B - BAIXA MOVIMENTO DE COBRANCA  *");

            /*" -3843- DISPLAY '*   -------   ----- --------- -- --------  *' */
            _.Display($"*   -------   ----- --------- -- --------  *");

            /*" -3844- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3845- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA    *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA    *");

            /*" -3847- DISPLAY '*              ' WDAT-REL-LIT '                    *' */

            $"*              {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -3848- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3848- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3863- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -3865- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -3865- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3867- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3871- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3873- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -3873- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}