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
using Sias.Cosseguro.DB2.AC0077B;

namespace Code
{
    public class AC0077B
    {
        public bool IsCall { get; set; }

        public AC0077B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------                                       */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0077B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/2018                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZAR DB DE COSSEGURO CEDIDO   *      */
        /*"      *                             DE SINISTROS PARA O SMART          *      */
        /*"      *                             COPIA DO PROGRAMA AC0017B          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA           INPUT  *      */
        /*"      * MESTRE DE SINISTROS                 V1MESTSINI          INPUT  *      */
        /*"      * HISTORICO DE SINISTROS              V1HISTSINI          INPUT  *      */
        /*"      * OPERACOES DE SINISTROS              PARAMETR_OPER_SINI  INPUT  *      */
        /*"      * APOLICES                            V0APOLICE           INPUT  *      */
        /*"      * COTACAO DE MOEDAS                   V0COTACAO           INPUT  *      */
        /*"      * APOLICE COSSEGURO CEDIDO            V1APOLCOSCED        INPUT  *      */
        /*"      * PREMIOS DE COSSEGURO (SINISTRO)     V0COSSEG_SINI       I-O    *      */
        /*"      * HISTORICO DE COSSEGURO (SINISTRO)   V0COSSEG_HISTSIN    OUTPUT *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR A ROTINA PARA DESPREZAR AS OPERACOES DE   *      */
        /*"      *              INTERFACE COM O FINANCEIRO DE DESPESA E HONORARIO *      */
        /*"      * 04/02/2022 - GILSON PINTO DA SILVA      JAZZ - TAREFA - 361534 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-QTDE-REG      PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          WHOST-OPERACAO      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis WHOST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-SITUACAO      PIC  X(001)     VALUE SPACES.*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          WHOST-DTINIMOV      PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DTINIMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-DTTERMOV      PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DTTERMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-DATA-AVS      PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DATA_AVS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-DTMOVTO       PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-VAL-OPER      PIC S9(013)V99  VALUE +0 COMP-3.*/
        public DoubleBasis WHOST_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          VIND-SIT-LIBR       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-SIT-REGT       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_SIT_REGT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-TIP-SEGR       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_TIP_SEGR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V1MSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1MSIN-TIPREG       PIC  X(001).*/
        public StringBasis V1MSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1MSIN-FONTE        PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-RAMO         PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-NUM-APOL     PIC S9(013)              COMP-3.*/
        public IntBasis V1MSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1MSIN-NRENDOS      PIC S9(009)              COMP.*/
        public IntBasis V1MSIN_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1MSIN-CODSUBES     PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-NRCERTIF     PIC S9(015)              COMP-3.*/
        public IntBasis V1MSIN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V1MSIN-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-CODLIDER     PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-SINLID       PIC  X(015).*/
        public StringBasis V1MSIN_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77          V1MSIN-DATCMD       PIC  X(010).*/
        public StringBasis V1MSIN_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-DATORR       PIC  X(010).*/
        public StringBasis V1MSIN_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-DATTEC       PIC  X(010).*/
        public StringBasis V1MSIN_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-CODCAU       PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-COD-MOEDA    PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-SDOPAGBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDOPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTPAGBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-SDORCPBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDORCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTRCPBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-SDORSABT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDORSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTRSDBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTRSDBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTDSABT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTDSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTHONBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTHONBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-SDOADTBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDOADTBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-ADTRCPBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_ADTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-VALSEGBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-PCPARTIC     PIC S9(004)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1MSIN-PCTRES       PIC S9(004)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1MSIN-DTULTMOV     PIC  X(010).*/
        public StringBasis V1MSIN_DTULTMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1MSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V1HSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1HSIN-TIPREG       PIC  X(001).*/
        public StringBasis V1HSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HSIN-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V1HSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HSIN-OPERACAO     PIC S9(004)              COMP.*/
        public IntBasis V1HSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HSIN-VAL-OPER     PIC S9(013)V99           COMP-3.*/
        public DoubleBasis V1HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1HSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V2HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2HSIN-VAL-OPER     PIC S9(013)V99           COMP-3.*/
        public DoubleBasis V2HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0APOL-NUM-APOL     PIC S9(013)              COMP-3.*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0APOL-TIPSGU       PIC  X(001).*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0APOL-ORGAO        PIC S9(004)              COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0APOL-RAMO         PIC S9(004)              COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COTA-VL-VENDA     PIC S9(006)V9(9)         COMP-3.*/
        public DoubleBasis V0COTA_VL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77          V1COTA-VL-VENDA     PIC S9(006)V9(9)         COMP-3.*/
        public DoubleBasis V1COTA_VL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77          V0CSIN-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V0CSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CSIN-TIPSGU       PIC  X(001).*/
        public StringBasis V0CSIN_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CSIN-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V0CSIN_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V0CSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CSIN-VAL-OPER     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V0CSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V0CSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CSIN-SIT-CONG     PIC  X(001).*/
        public StringBasis V0CSIN_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0CSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V1CSIN-TIPSGU       PIC  X(001).*/
        public StringBasis V1CSIN_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1CSIN-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V1CSIN_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1CSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V1CSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CSIN-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V2CSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CSIN-TIPSGU       PIC  X(001).*/
        public StringBasis V2CSIN_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CSIN-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V2CSIN_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V2CSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CSIN-VAL-OPER     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V2CSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V2CSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CSIN-SIT-CONG     PIC  X(001).*/
        public StringBasis V2CSIN_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V2CSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CHSI-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V0CHSI_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHSI-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V0CHSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHSI-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V0CHSI_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CHSI-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V0CHSI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHSI-OPERACAO     PIC S9(004)              COMP.*/
        public IntBasis V0CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHSI-SITUACAO     PIC  X(001).*/
        public StringBasis V0CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHSI-DTMOVTO      PIC  X(010).*/
        public StringBasis V0CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHSI-VAL-OPER     PIC S9(013)V9(2)         COMP-3.*/
        public DoubleBasis V0CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77          V0CHSI-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0CHSI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CHSI-TIPSGU       PIC  X(001).*/
        public StringBasis V0CHSI_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHSI-SIT-LIBRC    PIC  X(001).*/
        public StringBasis V0CHSI_SIT_LIBRC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHSI-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V2CHSI_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CHSI-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V2CHSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHSI-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V2CHSI_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CHSI-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V2CHSI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHSI-OPERACAO     PIC S9(004)              COMP.*/
        public IntBasis V2CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHSI-SITUACAO     PIC  X(001).*/
        public StringBasis V2CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHSI-DTMOVTO      PIC  X(010).*/
        public StringBasis V2CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2CHSI-VAL-OPER     PIC S9(013)V9(2)         COMP-3.*/
        public DoubleBasis V2CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77          V2CHSI-TIPSGU       PIC  X(001).*/
        public StringBasis V2CHSI_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHSI-SIT-LIBRC    PIC  X(001).*/
        public StringBasis V2CHSI_SIT_LIBRC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          AREA-DE-WORK.*/
        public AC0077B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0077B_AREA_DE_WORK();
        public class AC0077B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WSL-SQLCODE         PIC  9(009)  VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-COUNT            PIC S9(005)  VALUE +0 COMP-3.*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05        WFIM-V1MESTSINI     PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1MESTSINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-SX-APOLCOSG    PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_SX_APOLCOSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-V1COSSEGSINI   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V1COSSEGSINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-L-V1MESTSINI     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_V1MESTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-V0COSSEGSINI   PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_V0COSSEGSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGSINI   PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGHSIN   PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGHSIN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WNUM-SINI-ANT       PIC S9(013)  VALUE +0 COMP-3.*/
            public IntBasis WNUM_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05        WNUM-SINISTRO       PIC  9(013)  VALUE ZEROS.*/
            public IntBasis WNUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05        WNUM-SINI-R         REDEFINES    WNUM-SINISTRO.*/
            private _REDEF_AC0077B_WNUM_SINI_R _wnum_sini_r { get; set; }
            public _REDEF_AC0077B_WNUM_SINI_R WNUM_SINI_R
            {
                get { _wnum_sini_r = new _REDEF_AC0077B_WNUM_SINI_R(); _.Move(WNUM_SINISTRO, _wnum_sini_r); VarBasis.RedefinePassValue(WNUM_SINISTRO, _wnum_sini_r, WNUM_SINISTRO); _wnum_sini_r.ValueChanged += () => { _.Move(_wnum_sini_r, WNUM_SINISTRO); }; return _wnum_sini_r; }
                set { VarBasis.RedefinePassValue(value, _wnum_sini_r, WNUM_SINISTRO); }
            }  //Redefines
            public class _REDEF_AC0077B_WNUM_SINI_R : VarBasis
            {
                /*"    10      WORG-SINI           PIC  9(003).*/
                public IntBasis WORG_SINI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WRMO-SINI           PIC  9(002).*/
                public IntBasis WRMO_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WSEQ-SINI           PIC  9(008).*/
                public IntBasis WSEQ_SINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05        W0MSIN-VAL-OPER     PIC S9(013)V9(5)      COMP-3.*/

                public _REDEF_AC0077B_WNUM_SINI_R()
                {
                    WORG_SINI.ValueChanged += OnValueChanged;
                    WRMO_SINI.ValueChanged += OnValueChanged;
                    WSEQ_SINI.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis W0MSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05        W0HSIN-VAL-OPER     PIC S9(015)V99        COMP-3.*/
            public DoubleBasis W0HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        W0VLR-RESSEG        PIC S9(015)V99        COMP-3.*/
            public DoubleBasis W0VLR_RESSEG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        W2MSIN-VAL-OPER     PIC S9(013)V9(5)      COMP-3.*/
            public DoubleBasis W2MSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05        W2HSIN-VAL-OPER     PIC S9(015)V99        COMP-3.*/
            public DoubleBasis W2HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_AC0077B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_AC0077B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_AC0077B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_AC0077B_FILLER_0 : VarBasis
            {
                /*"    10      WDAT-REL-ANO        PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-SQL           PIC  X(010)  VALUE SPACES.*/

                public _REDEF_AC0077B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES    WDATA-SQL.*/
            private _REDEF_AC0077B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_AC0077B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_AC0077B_FILLER_3(); _.Move(WDATA_SQL, _filler_3); VarBasis.RedefinePassValue(WDATA_SQL, _filler_3, WDATA_SQL); _filler_3.ValueChanged += () => { _.Move(_filler_3, WDATA_SQL); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_AC0077B_FILLER_3 : VarBasis
            {
                /*"    10      WDATA-SQL-ANO       PIC  9(004).*/
                public IntBasis WDATA_SQL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-SQL-MES       PIC  9(002).*/
                public IntBasis WDATA_SQL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-SQL-DIA       PIC  9(002).*/
                public IntBasis WDATA_SQL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDAT-REL-LIT.*/

                public _REDEF_AC0077B_FILLER_3()
                {
                    WDATA_SQL_ANO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDATA_SQL_MES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDATA_SQL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public AC0077B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new AC0077B_WDAT_REL_LIT();
            public class AC0077B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-ANO        PIC  9(004)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WHORA-ACCEPT.*/
            }
            public AC0077B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0077B_WHORA_ACCEPT();
            public class AC0077B_WHORA_ACCEPT : VarBasis
            {
                /*"    10      WHH-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WMM-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WSS-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WCC-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WHORA-CABEC.*/
            }
            public AC0077B_WHORA_CABEC WHORA_CABEC { get; set; } = new AC0077B_WHORA_CABEC();
            public class AC0077B_WHORA_CABEC : VarBasis
            {
                /*"    10      WHORA-HH-CABEC      PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE ':'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WHORA-MM-CABEC      PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE ':'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WHORA-SS-CABEC      PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01          WABEND.*/
            }
        }
        public AC0077B_WABEND WABEND { get; set; } = new AC0077B_WABEND();
        public class AC0077B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)    VALUE           ' AC0077B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0077B");
            /*"  05        FILLER              PIC  X(026)    VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(003)    VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05        FILLER              PIC  X(013)    VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SX010 SX010 { get; set; } = new Dclgens.SX010();
        public Dclgens.SX011 SX011 { get; set; } = new Dclgens.SX011();
        public Dclgens.SX017 SX017 { get; set; } = new Dclgens.SX017();
        public Dclgens.SX118 SX118 { get; set; } = new Dclgens.SX118();
        public AC0077B_V1MESTSINI V1MESTSINI { get; set; } = new AC0077B_V1MESTSINI();
        public AC0077B_SX_APOLCOSG SX_APOLCOSG { get; set; } = new AC0077B_SX_APOLCOSG();
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
            /*" -327- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -328- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -331- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -334- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -340- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -342- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -344- PERFORM R0200-00-CHECA-EXECUCAO. */

            R0200_00_CHECA_EXECUCAO_SECTION();

            /*" -345- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -346- DISPLAY 'AC0077B - DUPLICIDADE DE PROCESSAMENTO' */
                _.Display($"AC0077B - DUPLICIDADE DE PROCESSAMENTO");

                /*" -347- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -349- END-IF. */
            }


            /*" -350- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -351- MOVE WHH-ACCEPT TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -352- MOVE WMM-ACCEPT TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -354- MOVE WSS-ACCEPT TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -356- DISPLAY 'INICIO DECLARE V1MESTSINI' WHORA-CABEC. */
            _.Display($"INICIO DECLARE V1MESTSINI{AREA_DE_WORK.WHORA_CABEC}");

            /*" -358- PERFORM R0400-00-DECLARE-V1MESTSINI. */

            R0400_00_DECLARE_V1MESTSINI_SECTION();

            /*" -359- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -360- MOVE WHH-ACCEPT TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -361- MOVE WMM-ACCEPT TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -363- MOVE WSS-ACCEPT TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -365- DISPLAY 'FINAL  DECLARE V1MESTSINI' WHORA-CABEC. */
            _.Display($"FINAL  DECLARE V1MESTSINI{AREA_DE_WORK.WHORA_CABEC}");

            /*" -367- PERFORM R0500-00-FETCH-V1MESTSINI. */

            R0500_00_FETCH_V1MESTSINI_SECTION();

            /*" -368- IF WFIM-V1MESTSINI NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1MESTSINI.IsEmpty())
            {

                /*" -369- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -370- ELSE */
            }
            else
            {


                /*" -372- PERFORM R0600-00-PROCESSA-REGISTRO UNTIL WFIM-V1MESTSINI NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1MESTSINI.IsEmpty()))
                {

                    R0600_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -372- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -377- DISPLAY 'SINISTROS LIDOS           - ' AC-L-V1MESTSINI. */
            _.Display($"SINISTROS LIDOS           - {AREA_DE_WORK.AC_L_V1MESTSINI}");

            /*" -378- DISPLAY 'SINISTROS COSSEG GRAVADOS - ' AC-I-V0COSSEGSINI. */
            _.Display($"SINISTROS COSSEG GRAVADOS - {AREA_DE_WORK.AC_I_V0COSSEGSINI}");

            /*" -379- DISPLAY 'SINISTROS COSSEG ATUALIZ. - ' AC-U-V0COSSEGSINI. */
            _.Display($"SINISTROS COSSEG ATUALIZ. - {AREA_DE_WORK.AC_U_V0COSSEGSINI}");

            /*" -381- DISPLAY 'HIST SINI COSSEG GRAVADOS - ' AC-I-V0COSSEGHSIN. */
            _.Display($"HIST SINI COSSEG GRAVADOS - {AREA_DE_WORK.AC_I_V0COSSEGHSIN}");

            /*" -381- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -385- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -385- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -398- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -403- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -406- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -407- DISPLAY 'R0100 - ERRO NO SELECT DA V1SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V1SISTEMA");

                /*" -408- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -409- ELSE */
            }
            else
            {


                /*" -410- DISPLAY 'DATA DO SISTEMA AC - ' V1SIST-DTMOVABE */
                _.Display($"DATA DO SISTEMA AC - {V1SIST_DTMOVABE}");

                /*" -410- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -403- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

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
        /*" R0200-00-CHECA-EXECUCAO-SECTION */
        private void R0200_00_CHECA_EXECUCAO_SECTION()
        {
            /*" -423- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -434- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -438- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -439- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -440- ELSE */
                }
                else
                {


                    /*" -441- DISPLAY 'R0200 - ERRO NO SELECT DA V1COSSEG-HISTSIN' */
                    _.Display($"R0200 - ERRO NO SELECT DA V1COSSEG-HISTSIN");

                    /*" -442- DISPLAY 'DATA MOVTO - ' V1SIST-DTMOVABE */
                    _.Display($"DATA MOVTO - {V1SIST_DTMOVABE}");

                    /*" -443- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -444- END-IF */
                }


                /*" -444- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -434- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_OPERACAO B WHERE A.DTMOVTO = :V1SIST-DTMOVABE AND A.TIPSGU = '1' AND A.NUM_SINISTRO BETWEEN 1400000000000 AND 1409999999999 AND B.COD_OPERACAO = A.OPERACAO AND B.IDE_SISTEMA = 'SI' END-EXEC. */

            var r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1.Execute(r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_REG, WHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-V1MESTSINI-SECTION */
        private void R0400_00_DECLARE_V1MESTSINI_SECTION()
        {
            /*" -457- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -487- PERFORM R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1 */

            R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1();

            /*" -489- PERFORM R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1 */

            R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1();

            /*" -492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -493- DISPLAY 'R0400 - ERRO NO DECLARE DA V1MESTSINI' */
                _.Display($"R0400 - ERRO NO DECLARE DA V1MESTSINI");

                /*" -494- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -495- ELSE */
            }
            else
            {


                /*" -496- MOVE ZEROS TO WNUM-SINI-ANT */
                _.Move(0, AREA_DE_WORK.WNUM_SINI_ANT);

                /*" -497- MOVE SPACES TO WFIM-V1MESTSINI */
                _.Move("", AREA_DE_WORK.WFIM_V1MESTSINI);

                /*" -497- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-V1MESTSINI-DB-DECLARE-1 */
        public void R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1()
        {
            /*" -487- EXEC SQL DECLARE V1MESTSINI CURSOR FOR SELECT A.NUM_APOL_SINISTRO, A.NUM_APOLICE, A.NRENDOS, A.COD_MOEDA_SINI, A.TIPREG, A.RAMO, A.CODCAU, A.DATORR, A.PCTRES, B.OCORHIST, B.OPERACAO, B.DTMOVTO, B.VAL_OPERACAO, B.TIPREG, B.SITUACAO, C.FUNCAO_OPERACAO, C.IND_TIPO_FUNCAO FROM SEGUROS.V1MESTSINI A, SEGUROS.V1HISTSINI B, SEGUROS.GE_OPERACAO C WHERE B.DTMOVTO = :V1SIST-DTMOVABE AND B.TIPREG = '1' AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND C.IDE_SISTEMA = 'SI' AND C.COD_OPERACAO = B.OPERACAO ORDER BY A.NUM_APOL_SINISTRO, B.OCORHIST, B.OPERACAO END-EXEC. */
            V1MESTSINI = new AC0077B_V1MESTSINI(true);
            string GetQuery_V1MESTSINI()
            {
                var query = @$"SELECT A.NUM_APOL_SINISTRO
							, 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.COD_MOEDA_SINI
							, 
							A.TIPREG
							, 
							A.RAMO
							, 
							A.CODCAU
							, 
							A.DATORR
							, 
							A.PCTRES
							, 
							B.OCORHIST
							, 
							B.OPERACAO
							, 
							B.DTMOVTO
							, 
							B.VAL_OPERACAO
							, 
							B.TIPREG
							, 
							B.SITUACAO
							, 
							C.FUNCAO_OPERACAO
							, 
							C.IND_TIPO_FUNCAO 
							FROM SEGUROS.V1MESTSINI A
							, 
							SEGUROS.V1HISTSINI B
							, 
							SEGUROS.GE_OPERACAO C 
							WHERE B.DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND B.TIPREG = '1' 
							AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND C.IDE_SISTEMA = 'SI' 
							AND C.COD_OPERACAO = B.OPERACAO 
							ORDER BY 
							A.NUM_APOL_SINISTRO
							, 
							B.OCORHIST
							, 
							B.OPERACAO";

                return query;
            }
            V1MESTSINI.GetQueryEvent += GetQuery_V1MESTSINI;

        }

        [StopWatch]
        /*" R0400-00-DECLARE-V1MESTSINI-DB-OPEN-1 */
        public void R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1()
        {
            /*" -489- EXEC SQL OPEN V1MESTSINI END-EXEC. */

            V1MESTSINI.Open();

        }

        [StopWatch]
        /*" R1200-00-DECLARE-SX118-DB-DECLARE-1 */
        public void R1200_00_DECLARE_SX118_DB_DECLARE_1()
        {
            /*" -864- EXEC SQL DECLARE SX_APOLCOSG CURSOR FOR SELECT VALUE (A.NUM_APOLICE,+0), B.COD_CONGENERE, B.PCT_PARTICIPACAO FROM SEGUROS.SX_APOLICE A, SEGUROS.SX_APOL_COSSEGURO B WHERE A.NUM_APOLICE = :V1MSIN-NUM-APOL AND A.STA_APOLICE = 'A' AND B.SEQ_APOLICE = A.SEQ_PROP_APOL AND B.IND_LIDER = 'N' AND B.PCT_PARTICIPACAO >= 0 AND (:V1MSIN-DATORR BETWEEN B.DTA_INI_VIGENCIA AND VALUE(B.DTA_FIM_VIGENCIA,DATE( '9999-12-31' ))) ORDER BY B.COD_CONGENERE END-EXEC. */
            SX_APOLCOSG = new AC0077B_SX_APOLCOSG(true);
            string GetQuery_SX_APOLCOSG()
            {
                var query = @$"SELECT 
							VALUE (A.NUM_APOLICE
							,+0)
							, 
							B.COD_CONGENERE
							, 
							B.PCT_PARTICIPACAO 
							FROM SEGUROS.SX_APOLICE A
							, 
							SEGUROS.SX_APOL_COSSEGURO B 
							WHERE A.NUM_APOLICE = '{V1MSIN_NUM_APOL}' 
							AND A.STA_APOLICE = 'A' 
							AND B.SEQ_APOLICE = A.SEQ_PROP_APOL 
							AND B.IND_LIDER = 'N' 
							AND B.PCT_PARTICIPACAO >= 0 
							AND ('{V1MSIN_DATORR}' BETWEEN B.DTA_INI_VIGENCIA 
							AND VALUE(B.DTA_FIM_VIGENCIA
							,DATE( '9999-12-31' ))) 
							ORDER BY 
							B.COD_CONGENERE";

                return query;
            }
            SX_APOLCOSG.GetQueryEvent += GetQuery_SX_APOLCOSG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-FETCH-V1MESTSINI-SECTION */
        private void R0500_00_FETCH_V1MESTSINI_SECTION()
        {
            /*" -508- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0500_10_LER_V1MESTSINI */

            R0500_10_LER_V1MESTSINI();

        }

        [StopWatch]
        /*" R0500-10-LER-V1MESTSINI */
        private void R0500_10_LER_V1MESTSINI(bool isPerform = false)
        {
            /*" -530- PERFORM R0500_10_LER_V1MESTSINI_DB_FETCH_1 */

            R0500_10_LER_V1MESTSINI_DB_FETCH_1();

            /*" -533- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -534- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -535- MOVE 'S' TO WFIM-V1MESTSINI */
                    _.Move("S", AREA_DE_WORK.WFIM_V1MESTSINI);

                    /*" -535- PERFORM R0500_10_LER_V1MESTSINI_DB_CLOSE_1 */

                    R0500_10_LER_V1MESTSINI_DB_CLOSE_1();

                    /*" -537- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -538- ELSE */
                }
                else
                {


                    /*" -539- DISPLAY 'R0500 - ERRO NO FETCH DA V1MESTSINI' */
                    _.Display($"R0500 - ERRO NO FETCH DA V1MESTSINI");

                    /*" -540- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -541- END-IF */
                }


                /*" -542- ELSE */
            }
            else
            {


                /*" -543- IF GEOPERAC-FUNCAO-OPERACAO = 'FINAN' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "FINAN")
                {

                    /*" -544- GO TO R0500-10-LER-V1MESTSINI */
                    new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -545- ELSE */
                }
                else
                {


                    /*" -550- IF GEOPERAC-IND-TIPO-FUNCAO = 'PE' OR 'R1' OR GEOPERAC-IND-TIPO-FUNCAO = 'IN-REGIST' OR GEOPERAC-IND-TIPO-FUNCAO = 'EST-REGIST' OR GEOPERAC-IND-TIPO-FUNCAO = 'PRE-REGIST' OR GEOPERAC-IND-TIPO-FUNCAO = 'JUR-DEP' OR 'JUR-FINAL' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("PE", "R1") || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "IN-REGIST" || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "EST-REGIST" || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "PRE-REGIST" || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("JUR-DEP", "JUR-FINAL"))
                    {

                        /*" -551- GO TO R0500-10-LER-V1MESTSINI */
                        new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -552- ELSE */
                    }
                    else
                    {


                        /*" -553- MOVE V1MSIN-NUM-SINI TO WNUM-SINISTRO */
                        _.Move(V1MSIN_NUM_SINI, AREA_DE_WORK.WNUM_SINISTRO);

                        /*" -555- IF WORG-SINI = 140 NEXT SENTENCE */

                        if (AREA_DE_WORK.WNUM_SINI_R.WORG_SINI == 140)
                        {

                            /*" -556- ELSE */
                        }
                        else
                        {


                            /*" -557- GO TO R0500-10-LER-V1MESTSINI */
                            new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -558- END-IF */
                        }


                        /*" -559- END-IF */
                    }


                    /*" -560- END-IF */
                }


                /*" -564- END-IF. */
            }


            /*" -569- ADD 1 TO AC-COUNT AC-L-V1MESTSINI. */
            AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + 1;
            AREA_DE_WORK.AC_L_V1MESTSINI.Value = AREA_DE_WORK.AC_L_V1MESTSINI + 1;

            /*" -570- IF AC-COUNT = 5000 */

            if (AREA_DE_WORK.AC_COUNT == 5000)
            {

                /*" -571- MOVE +0 TO AC-COUNT */
                _.Move(+0, AREA_DE_WORK.AC_COUNT);

                /*" -572- ACCEPT WHORA-ACCEPT FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

                /*" -573- MOVE WHH-ACCEPT TO WHORA-HH-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

                /*" -574- MOVE WMM-ACCEPT TO WHORA-MM-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

                /*" -575- MOVE WSS-ACCEPT TO WHORA-SS-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

                /*" -577- DISPLAY AC-L-V1MESTSINI ' LIDOS NA V1MESTSINI ' WHORA-CABEC */

                $"{AREA_DE_WORK.AC_L_V1MESTSINI} LIDOS NA V1MESTSINI {AREA_DE_WORK.WHORA_CABEC}"
                .Display();

                /*" -577- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-10-LER-V1MESTSINI-DB-FETCH-1 */
        public void R0500_10_LER_V1MESTSINI_DB_FETCH_1()
        {
            /*" -530- EXEC SQL FETCH V1MESTSINI INTO :V1MSIN-NUM-SINI , :V1MSIN-NUM-APOL , :V1MSIN-NRENDOS , :V1MSIN-COD-MOEDA , :V1MSIN-TIPREG , :V1MSIN-RAMO , :V1MSIN-CODCAU , :V1MSIN-DATORR , :V1MSIN-PCTRES , :V1HSIN-OCORHIST , :V1HSIN-OPERACAO , :V1HSIN-DTMOVTO , :V1HSIN-VAL-OPER , :V1HSIN-TIPREG , :V1HSIN-SITUACAO , :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-IND-TIPO-FUNCAO END-EXEC. */

            if (V1MESTSINI.Fetch())
            {
                _.Move(V1MESTSINI.V1MSIN_NUM_SINI, V1MSIN_NUM_SINI);
                _.Move(V1MESTSINI.V1MSIN_NUM_APOL, V1MSIN_NUM_APOL);
                _.Move(V1MESTSINI.V1MSIN_NRENDOS, V1MSIN_NRENDOS);
                _.Move(V1MESTSINI.V1MSIN_COD_MOEDA, V1MSIN_COD_MOEDA);
                _.Move(V1MESTSINI.V1MSIN_TIPREG, V1MSIN_TIPREG);
                _.Move(V1MESTSINI.V1MSIN_RAMO, V1MSIN_RAMO);
                _.Move(V1MESTSINI.V1MSIN_CODCAU, V1MSIN_CODCAU);
                _.Move(V1MESTSINI.V1MSIN_DATORR, V1MSIN_DATORR);
                _.Move(V1MESTSINI.V1MSIN_PCTRES, V1MSIN_PCTRES);
                _.Move(V1MESTSINI.V1HSIN_OCORHIST, V1HSIN_OCORHIST);
                _.Move(V1MESTSINI.V1HSIN_OPERACAO, V1HSIN_OPERACAO);
                _.Move(V1MESTSINI.V1HSIN_DTMOVTO, V1HSIN_DTMOVTO);
                _.Move(V1MESTSINI.V1HSIN_VAL_OPER, V1HSIN_VAL_OPER);
                _.Move(V1MESTSINI.V1HSIN_TIPREG, V1HSIN_TIPREG);
                _.Move(V1MESTSINI.V1HSIN_SITUACAO, V1HSIN_SITUACAO);
                _.Move(V1MESTSINI.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(V1MESTSINI.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }

        }

        [StopWatch]
        /*" R0500-10-LER-V1MESTSINI-DB-CLOSE-1 */
        public void R0500_10_LER_V1MESTSINI_DB_CLOSE_1()
        {
            /*" -535- EXEC SQL CLOSE V1MESTSINI END-EXEC */

            V1MESTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROCESSA-REGISTRO-SECTION */
        private void R0600_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -603- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -607- PERFORM R0800-00-SELECT-GESISFUO. */

            R0800_00_SELECT_GESISFUO_SECTION();

            /*" -609- PERFORM R0900-00-SELECT-V0APOLICE. */

            R0900_00_SELECT_V0APOLICE_SECTION();

            /*" -610- IF GEOPERAC-IND-TIPO-FUNCAO = 'DS' OR 'HS' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("DS", "HS"))
            {

                /*" -612- IF V0APOL-RAMO = 48 NEXT SENTENCE */

                if (V0APOL_RAMO == 48)
                {

                    /*" -613- ELSE */
                }
                else
                {


                    /*" -614- GO TO R0600-90-LER-REGISTRO */

                    R0600_90_LER_REGISTRO(); //GOTO
                    return;

                    /*" -615- END-IF */
                }


                /*" -617- END-IF. */
            }


            /*" -619- IF V0APOL-TIPSGU = '1' AND V0APOL-ORGAO = 10 */

            if (V0APOL_TIPSGU == "1" && V0APOL_ORGAO == 10)
            {

                /*" -620- PERFORM R1100-00-SELECT-V0COTACAO */

                R1100_00_SELECT_V0COTACAO_SECTION();

                /*" -621- PERFORM R1200-00-DECLARE-SX118 */

                R1200_00_DECLARE_SX118_SECTION();

                /*" -622- PERFORM R1300-00-FETCH-SX118 */

                R1300_00_FETCH_SX118_SECTION();

                /*" -623- IF WFIM-SX-APOLCOSG = SPACES */

                if (AREA_DE_WORK.WFIM_SX_APOLCOSG.IsEmpty())
                {

                    /*" -625- PERFORM R1400-00-GRAVA-REGISTRO UNTIL WFIM-SX-APOLCOSG NOT EQUAL SPACES */

                    while (!(!AREA_DE_WORK.WFIM_SX_APOLCOSG.IsEmpty()))
                    {

                        R1400_00_GRAVA_REGISTRO_SECTION();
                    }

                    /*" -626- END-IF */
                }


                /*" -626- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0600_90_LER_REGISTRO */

            R0600_90_LER_REGISTRO();

        }

        [StopWatch]
        /*" R0600-90-LER-REGISTRO */
        private void R0600_90_LER_REGISTRO(bool isPerform = false)
        {
            /*" -632- PERFORM R0500-00-FETCH-V1MESTSINI. */

            R0500_00_FETCH_V1MESTSINI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-DATA-AVISO-SECTION */
        private void R0700_00_SELECT_DATA_AVISO_SECTION()
        {
            /*" -645- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -652- PERFORM R0700_00_SELECT_DATA_AVISO_DB_SELECT_1 */

            R0700_00_SELECT_DATA_AVISO_DB_SELECT_1();

            /*" -655- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -656- DISPLAY 'R0700 - ERRO NO SELECT DA V0HISTSINI' */
                _.Display($"R0700 - ERRO NO SELECT DA V0HISTSINI");

                /*" -657- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -658- DISPLAY 'OC. HIST - 01' */
                _.Display($"OC. HIST - 01");

                /*" -659- DISPLAY 'OPERACAO - 0101' */
                _.Display($"OPERACAO - 0101");

                /*" -660- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -660- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-DATA-AVISO-DB-SELECT-1 */
        public void R0700_00_SELECT_DATA_AVISO_DB_SELECT_1()
        {
            /*" -652- EXEC SQL SELECT DTMOVTO INTO :WHOST-DATA-AVS FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND OCORHIST = 01 AND OPERACAO = 0101 END-EXEC. */

            var r0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1 = new R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
            };

            var executed_1 = R0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_AVS, WHOST_DATA_AVS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-GESISFUO-SECTION */
        private void R0800_00_SELECT_GESISFUO_SECTION()
        {
            /*" -673- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -708- PERFORM R0800_00_SELECT_GESISFUO_DB_SELECT_1 */

            R0800_00_SELECT_GESISFUO_DB_SELECT_1();

            /*" -711- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -712- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -713- MOVE ZEROS TO GESISFUO-NUM-FATOR */
                    _.Move(0, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                    /*" -714- MOVE ZEROS TO GESISFUO-COD-FUNCAO */
                    _.Move(0, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);

                    /*" -715- MOVE SPACES TO GESISFUO-IDE-SISTEMA */
                    _.Move("", GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);

                    /*" -716- MOVE SPACES TO GESISFUO-IDE-SISTEMA-OPER */
                    _.Move("", GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);

                    /*" -717- ELSE */
                }
                else
                {


                    /*" -718- DISPLAY 'R0800 - ERRO NO SELECT DA GE-SIS-FUNCAO-OPER' */
                    _.Display($"R0800 - ERRO NO SELECT DA GE-SIS-FUNCAO-OPER");

                    /*" -719- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                    /*" -720- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                    _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                    /*" -721- DISPLAY 'DT. MOVT - ' V1HSIN-DTMOVTO */
                    _.Display($"DT. MOVT - {V1HSIN_DTMOVTO}");

                    /*" -722- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                    _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                    /*" -723- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -724- END-IF */
                }


                /*" -724- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-GESISFUO-DB-SELECT-1 */
        public void R0800_00_SELECT_GESISFUO_DB_SELECT_1()
        {
            /*" -708- EXEC SQL SELECT IDE_SISTEMA, COD_FUNCAO, IDE_SISTEMA_OPER, NUM_FATOR INTO :GESISFUO-IDE-SISTEMA, :GESISFUO-COD-FUNCAO, :GESISFUO-IDE-SISTEMA-OPER, :GESISFUO-NUM-FATOR FROM SEGUROS.GE_SIS_FUNCAO_OPER WHERE IDE_SISTEMA = 'SI' AND COD_FUNCAO IN (02,05,06,08,12,15, 16,17,18,20,21,22, 24,25,26,34) AND IDE_SISTEMA_OPER = IDE_SISTEMA AND COD_OPERACAO = :V1HSIN-OPERACAO END-EXEC. */

            var r0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1 = new R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1()
            {
                V1HSIN_OPERACAO = V1HSIN_OPERACAO.ToString(),
            };

            var executed_1 = R0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_GESISFUO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISFUO_IDE_SISTEMA, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);
                _.Move(executed_1.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(executed_1.GESISFUO_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);
                _.Move(executed_1.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-V0APOLICE-SECTION */
        private void R0900_00_SELECT_V0APOLICE_SECTION()
        {
            /*" -737- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -748- PERFORM R0900_00_SELECT_V0APOLICE_DB_SELECT_1 */

            R0900_00_SELECT_V0APOLICE_DB_SELECT_1();

            /*" -751- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -752- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -753- PERFORM R1000-00-SELECT-SX010 */

                    R1000_00_SELECT_SX010_SECTION();

                    /*" -754- ELSE */
                }
                else
                {


                    /*" -755- DISPLAY 'R0900 - ERRO NO SELECT DA V0APOLICE' */
                    _.Display($"R0900 - ERRO NO SELECT DA V0APOLICE");

                    /*" -756- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                    /*" -757- DISPLAY 'APOLICE  - ' V1MSIN-NUM-APOL */
                    _.Display($"APOLICE  - {V1MSIN_NUM_APOL}");

                    /*" -758- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -759- END-IF */
                }


                /*" -759- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-V0APOLICE-DB-SELECT-1 */
        public void R0900_00_SELECT_V0APOLICE_DB_SELECT_1()
        {
            /*" -748- EXEC SQL SELECT NUM_APOLICE, TIPSGU, ORGAO, RAMO INTO :V0APOL-NUM-APOL, :V0APOL-TIPSGU, :V0APOL-ORGAO, :V0APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1MSIN-NUM-APOL END-EXEC. */

            var r0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 = new R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_APOL = V1MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_V0APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_NUM_APOL, V0APOL_NUM_APOL);
                _.Move(executed_1.V0APOL_TIPSGU, V0APOL_TIPSGU);
                _.Move(executed_1.V0APOL_ORGAO, V0APOL_ORGAO);
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECT-SX010-SECTION */
        private void R1000_00_SELECT_SX010_SECTION()
        {
            /*" -772- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -793- PERFORM R1000_00_SELECT_SX010_DB_SELECT_1 */

            R1000_00_SELECT_SX010_DB_SELECT_1();

            /*" -796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -797- DISPLAY 'R1000 - ERRO NO SELECT DA SX_APOLICE' */
                _.Display($"R1000 - ERRO NO SELECT DA SX_APOLICE");

                /*" -798- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -799- DISPLAY 'APOLICE  - ' V1MSIN-NUM-APOL */
                _.Display($"APOLICE  - {V1MSIN_NUM_APOL}");

                /*" -800- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -801- ELSE */
            }
            else
            {


                /*" -802- MOVE SX010-NUM-APOLICE TO V0APOL-NUM-APOL */
                _.Move(SX010.DCLSX_APOLICE.SX010_NUM_APOLICE, V0APOL_NUM_APOL);

                /*" -803- MOVE SX017-NUM-RAMO TO V0APOL-RAMO */
                _.Move(SX017.DCLSX_PRODUTO.SX017_NUM_RAMO, V0APOL_RAMO);

                /*" -804- MOVE 010 TO V0APOL-ORGAO */
                _.Move(010, V0APOL_ORGAO);

                /*" -805- MOVE '1' TO V0APOL-TIPSGU */
                _.Move("1", V0APOL_TIPSGU);

                /*" -805- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-SELECT-SX010-DB-SELECT-1 */
        public void R1000_00_SELECT_SX010_DB_SELECT_1()
        {
            /*" -793- EXEC SQL SELECT DISTINCT VALUE (A.NUM_APOLICE,+0), A.DTA_APOLICE, A.COD_FONTE, C.NUM_RAMO, C.COD_PRODUTO INTO :SX010-NUM-APOLICE, :SX010-DTA-APOLICE, :SX010-COD-FONTE, :SX017-NUM-RAMO, :SX017-COD-PRODUTO FROM SEGUROS.SX_APOLICE A, SEGUROS.SX_ORIGEM_CONTRATO B, SEGUROS.SX_PRODUTO C WHERE A.NUM_APOLICE = :V1MSIN-NUM-APOL AND A.STA_APOLICE = 'A' AND B.SEQ_APOLICE = A.SEQ_PROP_APOL AND B.STA_ORIGEM_CONTRATO = 'A' AND C.COD_PRODUTO = B.COD_PRODUTO WITH UR END-EXEC. */

            var r1000_00_SELECT_SX010_DB_SELECT_1_Query1 = new R1000_00_SELECT_SX010_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_APOL = V1MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R1000_00_SELECT_SX010_DB_SELECT_1_Query1.Execute(r1000_00_SELECT_SX010_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SX010_NUM_APOLICE, SX010.DCLSX_APOLICE.SX010_NUM_APOLICE);
                _.Move(executed_1.SX010_DTA_APOLICE, SX010.DCLSX_APOLICE.SX010_DTA_APOLICE);
                _.Move(executed_1.SX010_COD_FONTE, SX010.DCLSX_APOLICE.SX010_COD_FONTE);
                _.Move(executed_1.SX017_NUM_RAMO, SX017.DCLSX_PRODUTO.SX017_NUM_RAMO);
                _.Move(executed_1.SX017_COD_PRODUTO, SX017.DCLSX_PRODUTO.SX017_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0COTACAO-SECTION */
        private void R1100_00_SELECT_V0COTACAO_SECTION()
        {
            /*" -818- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -825- PERFORM R1100_00_SELECT_V0COTACAO_DB_SELECT_1 */

            R1100_00_SELECT_V0COTACAO_DB_SELECT_1();

            /*" -828- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -829- DISPLAY 'R1100 - ERRO NO SELECT DA V0COTACAO' */
                _.Display($"R1100 - ERRO NO SELECT DA V0COTACAO");

                /*" -830- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -831- DISPLAY 'MOEDA    - ' V1MSIN-COD-MOEDA */
                _.Display($"MOEDA    - {V1MSIN_COD_MOEDA}");

                /*" -832- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                /*" -833- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                /*" -834- DISPLAY 'DT MOVTO - ' V1HSIN-DTMOVTO */
                _.Display($"DT MOVTO - {V1HSIN_DTMOVTO}");

                /*" -835- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -835- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0COTACAO-DB-SELECT-1 */
        public void R1100_00_SELECT_V0COTACAO_DB_SELECT_1()
        {
            /*" -825- EXEC SQL SELECT VAL_VENDA INTO :V0COTA-VL-VENDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1MSIN-COD-MOEDA AND DTINIVIG <= :V1HSIN-DTMOVTO AND DTTERVIG >= :V1HSIN-DTMOVTO END-EXEC. */

            var r1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1()
            {
                V1MSIN_COD_MOEDA = V1MSIN_COD_MOEDA.ToString(),
                V1HSIN_DTMOVTO = V1HSIN_DTMOVTO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V0COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTA_VL_VENDA, V0COTA_VL_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-DECLARE-SX118-SECTION */
        private void R1200_00_DECLARE_SX118_SECTION()
        {
            /*" -848- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -864- PERFORM R1200_00_DECLARE_SX118_DB_DECLARE_1 */

            R1200_00_DECLARE_SX118_DB_DECLARE_1();

            /*" -866- PERFORM R1200_00_DECLARE_SX118_DB_OPEN_1 */

            R1200_00_DECLARE_SX118_DB_OPEN_1();

            /*" -869- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -870- DISPLAY 'R1200 - ERRO NO DECLARE DA SX_APOL_COSSEGURO' */
                _.Display($"R1200 - ERRO NO DECLARE DA SX_APOL_COSSEGURO");

                /*" -871- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -872- ELSE */
            }
            else
            {


                /*" -873- MOVE SPACES TO WFIM-SX-APOLCOSG */
                _.Move("", AREA_DE_WORK.WFIM_SX_APOLCOSG);

                /*" -873- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-DECLARE-SX118-DB-OPEN-1 */
        public void R1200_00_DECLARE_SX118_DB_OPEN_1()
        {
            /*" -866- EXEC SQL OPEN SX_APOLCOSG END-EXEC. */

            SX_APOLCOSG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-FETCH-SX118-SECTION */
        private void R1300_00_FETCH_SX118_SECTION()
        {
            /*" -884- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1300_10_LER_SX118 */

            R1300_10_LER_SX118();

        }

        [StopWatch]
        /*" R1300-10-LER-SX118 */
        private void R1300_10_LER_SX118(bool isPerform = false)
        {
            /*" -892- PERFORM R1300_10_LER_SX118_DB_FETCH_1 */

            R1300_10_LER_SX118_DB_FETCH_1();

            /*" -895- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -896- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -897- MOVE 'S' TO WFIM-SX-APOLCOSG */
                    _.Move("S", AREA_DE_WORK.WFIM_SX_APOLCOSG);

                    /*" -897- PERFORM R1300_10_LER_SX118_DB_CLOSE_1 */

                    R1300_10_LER_SX118_DB_CLOSE_1();

                    /*" -899- ELSE */
                }
                else
                {


                    /*" -900- DISPLAY 'R1300 - ERRO NO FETCH DA SX_APOL_COSSEGURO' */
                    _.Display($"R1300 - ERRO NO FETCH DA SX_APOL_COSSEGURO");

                    /*" -901- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -907- END-IF */
                }


                /*" -907- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-10-LER-SX118-DB-FETCH-1 */
        public void R1300_10_LER_SX118_DB_FETCH_1()
        {
            /*" -892- EXEC SQL FETCH SX_APOLCOSG INTO :SX010-NUM-APOLICE, :SX118-COD-CONGENERE, :SX118-PCT-PARTICIPACAO END-EXEC. */

            if (SX_APOLCOSG.Fetch())
            {
                _.Move(SX_APOLCOSG.SX010_NUM_APOLICE, SX010.DCLSX_APOLICE.SX010_NUM_APOLICE);
                _.Move(SX_APOLCOSG.SX118_COD_CONGENERE, SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE);
                _.Move(SX_APOLCOSG.SX118_PCT_PARTICIPACAO, SX118.DCLSX_APOL_COSSEGURO.SX118_PCT_PARTICIPACAO);
            }

        }

        [StopWatch]
        /*" R1300-10-LER-SX118-DB-CLOSE-1 */
        public void R1300_10_LER_SX118_DB_CLOSE_1()
        {
            /*" -897- EXEC SQL CLOSE SX_APOLCOSG END-EXEC */

            SX_APOLCOSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-REGISTRO-SECTION */
        private void R1400_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -920- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -924- MOVE ZEROS TO WHOST-VAL-OPER W0MSIN-VAL-OPER W0HSIN-VAL-OPER. */
            _.Move(0, WHOST_VAL_OPER, AREA_DE_WORK.W0MSIN_VAL_OPER, AREA_DE_WORK.W0HSIN_VAL_OPER);

            /*" -926- PERFORM R1500-00-CALCULA-VALORES. */

            R1500_00_CALCULA_VALORES_SECTION();

            /*" -927- IF V1HSIN-OPERACAO = 0101 */

            if (V1HSIN_OPERACAO == 0101)
            {

                /*" -928- PERFORM R1700-00-MONTA-V0COSSEG-SINI */

                R1700_00_MONTA_V0COSSEG_SINI_SECTION();

                /*" -929- PERFORM R1800-00-INSERT-V0COSSEG-SINI */

                R1800_00_INSERT_V0COSSEG_SINI_SECTION();

                /*" -930- PERFORM R1900-00-MONTA-V0COSSEG-HSIN */

                R1900_00_MONTA_V0COSSEG_HSIN_SECTION();

                /*" -931- PERFORM R2000-00-INSERT-V0COSSEG-HSIN */

                R2000_00_INSERT_V0COSSEG_HSIN_SECTION();

                /*" -932- ELSE */
            }
            else
            {


                /*" -935- IF V1HSIN-OPERACAO = 0104 OR 0114 OR 0107 OR 0117 OR 0108 OR 0118 */

                if (V1HSIN_OPERACAO.In("0104", "0114", "0107", "0117", "0108", "0118"))
                {

                    /*" -936- PERFORM R2100-00-VERIFICA-SITUACAO */

                    R2100_00_VERIFICA_SITUACAO_SECTION();

                    /*" -937- IF WTEM-V1COSSEGSINI = 'S' */

                    if (AREA_DE_WORK.WTEM_V1COSSEGSINI == "S")
                    {

                        /*" -938- PERFORM R2300-00-UPDATE-V0COSSEG-SINI */

                        R2300_00_UPDATE_V0COSSEG_SINI_SECTION();

                        /*" -939- PERFORM R1900-00-MONTA-V0COSSEG-HSIN */

                        R1900_00_MONTA_V0COSSEG_HSIN_SECTION();

                        /*" -940- PERFORM R2000-00-INSERT-V0COSSEG-HSIN */

                        R2000_00_INSERT_V0COSSEG_HSIN_SECTION();

                        /*" -941- ELSE */
                    }
                    else
                    {


                        /*" -942- PERFORM R1900-00-MONTA-V0COSSEG-HSIN */

                        R1900_00_MONTA_V0COSSEG_HSIN_SECTION();

                        /*" -943- PERFORM R2000-00-INSERT-V0COSSEG-HSIN */

                        R2000_00_INSERT_V0COSSEG_HSIN_SECTION();

                        /*" -944- ELSE */
                    }

                }
                else
                {


                    /*" -945- PERFORM R1900-00-MONTA-V0COSSEG-HSIN */

                    R1900_00_MONTA_V0COSSEG_HSIN_SECTION();

                    /*" -949- PERFORM R2000-00-INSERT-V0COSSEG-HSIN. */

                    R2000_00_INSERT_V0COSSEG_HSIN_SECTION();
                }

            }


            /*" -949- PERFORM R1300-00-FETCH-SX118. */

            R1300_00_FETCH_SX118_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-CALCULA-VALORES-SECTION */
        private void R1500_00_CALCULA_VALORES_SECTION()
        {
            /*" -962- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -964- IF V1MSIN-RAMO = 68 AND V1MSIN-NUM-APOL = 6501000001 */

            if (V1MSIN_RAMO == 68 && V1MSIN_NUM_APOL == 6501000001)
            {

                /*" -967- COMPUTE W0VLR-RESSEG ROUNDED = V1HSIN-VAL-OPER * V1MSIN-PCTRES / 100 */
                AREA_DE_WORK.W0VLR_RESSEG.Value = V1HSIN_VAL_OPER * V1MSIN_PCTRES / 100f;

                /*" -968- ELSE */
            }
            else
            {


                /*" -969- MOVE ZEROS TO W0VLR-RESSEG */
                _.Move(0, AREA_DE_WORK.W0VLR_RESSEG);

                /*" -971- END-IF. */
            }


            /*" -976- COMPUTE W0HSIN-VAL-OPER ROUNDED = (V1HSIN-VAL-OPER - W0VLR-RESSEG) * SX118-PCT-PARTICIPACAO / 100. */
            AREA_DE_WORK.W0HSIN_VAL_OPER.Value = (V1HSIN_VAL_OPER - AREA_DE_WORK.W0VLR_RESSEG) * SX118.DCLSX_APOL_COSSEGURO.SX118_PCT_PARTICIPACAO / 100f;

            /*" -977- COMPUTE W0MSIN-VAL-OPER ROUNDED = W0HSIN-VAL-OPER / V0COTA-VL-VENDA. */
            AREA_DE_WORK.W0MSIN_VAL_OPER.Value = AREA_DE_WORK.W0HSIN_VAL_OPER / V0COTA_VL_VENDA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-MONTA-V0COSSEG-SINI-SECTION */
        private void R1700_00_MONTA_V0COSSEG_SINI_SECTION()
        {
            /*" -990- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -991- MOVE ZEROS TO V0CSIN-COD-EMP. */
            _.Move(0, V0CSIN_COD_EMP);

            /*" -992- MOVE '1' TO V0CSIN-TIPSGU. */
            _.Move("1", V0CSIN_TIPSGU);

            /*" -993- MOVE SX118-COD-CONGENERE TO V0CSIN-CONGENER. */
            _.Move(SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE, V0CSIN_CONGENER);

            /*" -994- MOVE V1MSIN-NUM-SINI TO V0CSIN-NUM-SINI. */
            _.Move(V1MSIN_NUM_SINI, V0CSIN_NUM_SINI);

            /*" -995- MOVE W0MSIN-VAL-OPER TO V0CSIN-VAL-OPER. */
            _.Move(AREA_DE_WORK.W0MSIN_VAL_OPER, V0CSIN_VAL_OPER);

            /*" -996- MOVE '0' TO V0CSIN-SITUACAO. */
            _.Move("0", V0CSIN_SITUACAO);

            /*" -996- MOVE '0' TO V0CSIN-SIT-CONG. */
            _.Move("0", V0CSIN_SIT_CONG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-INSERT-V0COSSEG-SINI-SECTION */
        private void R1800_00_INSERT_V0COSSEG_SINI_SECTION()
        {
            /*" -1009- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -1019- PERFORM R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1 */

            R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1();

            /*" -1022- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1023- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1024- DISPLAY 'R1800 - REGISTRO DUPLICADO NA V0COSSEG-SINI' */
                    _.Display($"R1800 - REGISTRO DUPLICADO NA V0COSSEG-SINI");

                    /*" -1025- DISPLAY 'TIP SEGUR - ' V0CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V0CSIN_TIPSGU}");

                    /*" -1026- DISPLAY 'CONGENERE - ' V0CSIN-CONGENER */
                    _.Display($"CONGENERE - {V0CSIN_CONGENER}");

                    /*" -1027- DISPLAY 'SINISTRO  - ' V0CSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V0CSIN_NUM_SINI}");

                    /*" -1028- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1029- ELSE */
                }
                else
                {


                    /*" -1030- DISPLAY 'R1800 - ERRO NO INSERT DA V0COSSEG-SINI' */
                    _.Display($"R1800 - ERRO NO INSERT DA V0COSSEG-SINI");

                    /*" -1031- DISPLAY 'TIP SEGUR - ' V0CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V0CSIN_TIPSGU}");

                    /*" -1032- DISPLAY 'CONGENERE - ' V0CSIN-CONGENER */
                    _.Display($"CONGENERE - {V0CSIN_CONGENER}");

                    /*" -1033- DISPLAY 'SINISTRO  - ' V0CSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V0CSIN_NUM_SINI}");

                    /*" -1034- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1035- END-IF */
                }


                /*" -1036- ELSE */
            }
            else
            {


                /*" -1037- ADD +1 TO AC-I-V0COSSEGSINI */
                AREA_DE_WORK.AC_I_V0COSSEGSINI.Value = AREA_DE_WORK.AC_I_V0COSSEGSINI + +1;

                /*" -1037- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-INSERT-V0COSSEG-SINI-DB-INSERT-1 */
        public void R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1()
        {
            /*" -1019- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_SINI VALUES (:V0CSIN-COD-EMP, :V0CSIN-TIPSGU, :V0CSIN-CONGENER, :V0CSIN-NUM-SINI, :V0CSIN-VAL-OPER, :V0CSIN-SITUACAO, :V0CSIN-SIT-CONG, CURRENT TIMESTAMP) END-EXEC. */

            var r1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 = new R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1()
            {
                V0CSIN_COD_EMP = V0CSIN_COD_EMP.ToString(),
                V0CSIN_TIPSGU = V0CSIN_TIPSGU.ToString(),
                V0CSIN_CONGENER = V0CSIN_CONGENER.ToString(),
                V0CSIN_NUM_SINI = V0CSIN_NUM_SINI.ToString(),
                V0CSIN_VAL_OPER = V0CSIN_VAL_OPER.ToString(),
                V0CSIN_SITUACAO = V0CSIN_SITUACAO.ToString(),
                V0CSIN_SIT_CONG = V0CSIN_SIT_CONG.ToString(),
            };

            R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1.Execute(r1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-MONTA-V0COSSEG-HSIN-SECTION */
        private void R1900_00_MONTA_V0COSSEG_HSIN_SECTION()
        {
            /*" -1050- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -1051- MOVE ZEROS TO V0CHSI-COD-EMP. */
            _.Move(0, V0CHSI_COD_EMP);

            /*" -1052- MOVE SX118-COD-CONGENERE TO V0CHSI-CONGENER. */
            _.Move(SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE, V0CHSI_CONGENER);

            /*" -1053- MOVE V1MSIN-NUM-SINI TO V0CHSI-NUM-SINI. */
            _.Move(V1MSIN_NUM_SINI, V0CHSI_NUM_SINI);

            /*" -1054- MOVE V1HSIN-OCORHIST TO V0CHSI-OCORHIST. */
            _.Move(V1HSIN_OCORHIST, V0CHSI_OCORHIST);

            /*" -1055- MOVE V1HSIN-OPERACAO TO V0CHSI-OPERACAO. */
            _.Move(V1HSIN_OPERACAO, V0CHSI_OPERACAO);

            /*" -1056- MOVE V1HSIN-DTMOVTO TO V0CHSI-DTMOVTO. */
            _.Move(V1HSIN_DTMOVTO, V0CHSI_DTMOVTO);

            /*" -1058- MOVE W0HSIN-VAL-OPER TO V0CHSI-VAL-OPER. */
            _.Move(AREA_DE_WORK.W0HSIN_VAL_OPER, V0CHSI_VAL_OPER);

            /*" -1059- MOVE '0' TO V0CHSI-SITUACAO. */
            _.Move("0", V0CHSI_SITUACAO);

            /*" -1061- MOVE +1 TO VIND-SIT-REGT. */
            _.Move(+1, VIND_SIT_REGT);

            /*" -1062- MOVE '1' TO V0CHSI-TIPSGU. */
            _.Move("1", V0CHSI_TIPSGU);

            /*" -1064- MOVE +1 TO VIND-TIP-SEGR. */
            _.Move(+1, VIND_TIP_SEGR);

            /*" -1065- MOVE '0' TO V0CHSI-SIT-LIBRC. */
            _.Move("0", V0CHSI_SIT_LIBRC);

            /*" -1065- MOVE +1 TO VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_LIBR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERT-V0COSSEG-HSIN-SECTION */
        private void R2000_00_INSERT_V0COSSEG_HSIN_SECTION()
        {
            /*" -1078- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1091- PERFORM R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1 */

            R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1();

            /*" -1094- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1095- DISPLAY 'R2000 - ERRO NO INSERT DA V0COSSEG-HS' */
                _.Display($"R2000 - ERRO NO INSERT DA V0COSSEG-HS");

                /*" -1096- DISPLAY 'TIP SEGUR - ' V0CHSI-TIPSGU */
                _.Display($"TIP SEGUR - {V0CHSI_TIPSGU}");

                /*" -1097- DISPLAY 'CONGENERE - ' V0CHSI-CONGENER */
                _.Display($"CONGENERE - {V0CHSI_CONGENER}");

                /*" -1098- DISPLAY 'SINISTRO  - ' V0CHSI-NUM-SINI */
                _.Display($"SINISTRO  - {V0CHSI_NUM_SINI}");

                /*" -1099- DISPLAY 'OCOR HIST - ' V0CHSI-OCORHIST */
                _.Display($"OCOR HIST - {V0CHSI_OCORHIST}");

                /*" -1100- DISPLAY 'OPERACAO  - ' V0CHSI-OPERACAO */
                _.Display($"OPERACAO  - {V0CHSI_OPERACAO}");

                /*" -1101- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1102- ELSE */
            }
            else
            {


                /*" -1103- ADD +1 TO AC-I-V0COSSEGHSIN */
                AREA_DE_WORK.AC_I_V0COSSEGHSIN.Value = AREA_DE_WORK.AC_I_V0COSSEGHSIN + +1;

                /*" -1103- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-INSERT-V0COSSEG-HSIN-DB-INSERT-1 */
        public void R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1()
        {
            /*" -1091- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES (:V0CHSI-COD-EMP, :V0CHSI-CONGENER, :V0CHSI-NUM-SINI, :V0CHSI-OCORHIST, :V0CHSI-OPERACAO, :V0CHSI-DTMOVTO, :V0CHSI-VAL-OPER, CURRENT TIMESTAMP, :V0CHSI-SITUACAO:VIND-SIT-REGT, :V0CHSI-TIPSGU:VIND-TIP-SEGR, :V0CHSI-SIT-LIBRC:VIND-SIT-LIBR) END-EXEC. */

            var r2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 = new R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1()
            {
                V0CHSI_COD_EMP = V0CHSI_COD_EMP.ToString(),
                V0CHSI_CONGENER = V0CHSI_CONGENER.ToString(),
                V0CHSI_NUM_SINI = V0CHSI_NUM_SINI.ToString(),
                V0CHSI_OCORHIST = V0CHSI_OCORHIST.ToString(),
                V0CHSI_OPERACAO = V0CHSI_OPERACAO.ToString(),
                V0CHSI_DTMOVTO = V0CHSI_DTMOVTO.ToString(),
                V0CHSI_VAL_OPER = V0CHSI_VAL_OPER.ToString(),
                V0CHSI_SITUACAO = V0CHSI_SITUACAO.ToString(),
                VIND_SIT_REGT = VIND_SIT_REGT.ToString(),
                V0CHSI_TIPSGU = V0CHSI_TIPSGU.ToString(),
                VIND_TIP_SEGR = VIND_TIP_SEGR.ToString(),
                V0CHSI_SIT_LIBRC = V0CHSI_SIT_LIBRC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
            };

            R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1.Execute(r2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-VERIFICA-SITUACAO-SECTION */
        private void R2100_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -1116- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -1117- IF V1HSIN-OPERACAO EQUAL 0104 OR 0114 */

            if (V1HSIN_OPERACAO.In("0104", "0114"))
            {

                /*" -1118- MOVE '0' TO WHOST-SITUACAO */
                _.Move("0", WHOST_SITUACAO);

                /*" -1119- ELSE */
            }
            else
            {


                /*" -1121- IF V1HSIN-OPERACAO EQUAL 0107 OR 0117 OR 0108 OR 0118 */

                if (V1HSIN_OPERACAO.In("0107", "0117", "0108", "0118"))
                {

                    /*" -1122- MOVE '2' TO WHOST-SITUACAO */
                    _.Move("2", WHOST_SITUACAO);

                    /*" -1123- ELSE */
                }
                else
                {


                    /*" -1124- DISPLAY 'R2100 - OPERACAO NAO PREVISTA' */
                    _.Display($"R2100 - OPERACAO NAO PREVISTA");

                    /*" -1125- DISPLAY 'CONGENERE - ' SX118-COD-CONGENERE */
                    _.Display($"CONGENERE - {SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE}");

                    /*" -1126- DISPLAY 'SINISTRO  - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V1MSIN_NUM_SINI}");

                    /*" -1127- DISPLAY 'OCOR HIST - ' V1HSIN-OCORHIST */
                    _.Display($"OCOR HIST - {V1HSIN_OCORHIST}");

                    /*" -1128- DISPLAY 'OPERACAO  - ' V1HSIN-OPERACAO */
                    _.Display($"OPERACAO  - {V1HSIN_OPERACAO}");

                    /*" -1129- DISPLAY 'DT MOVTO  - ' V1HSIN-DTMOVTO */
                    _.Display($"DT MOVTO  - {V1HSIN_DTMOVTO}");

                    /*" -1130- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1131- END-IF */
                }


                /*" -1133- END-IF. */
            }


            /*" -1133- PERFORM R2200-00-SELECT-V1COSSEG-SINI. */

            R2200_00_SELECT_V1COSSEG_SINI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-V1COSSEG-SINI-SECTION */
        private void R2200_00_SELECT_V1COSSEG_SINI_SECTION()
        {
            /*" -1146- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -1157- PERFORM R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1 */

            R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1();

            /*" -1160- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1161- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1162- MOVE 'N' TO WTEM-V1COSSEGSINI */
                    _.Move("N", AREA_DE_WORK.WTEM_V1COSSEGSINI);

                    /*" -1163- ELSE */
                }
                else
                {


                    /*" -1164- DISPLAY 'R2200 - ERRO NO SELECT V1COSSEG-SINI' */
                    _.Display($"R2200 - ERRO NO SELECT V1COSSEG-SINI");

                    /*" -1165- DISPLAY 'TIP SEGUR - ' V1CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V1CSIN_TIPSGU}");

                    /*" -1166- DISPLAY 'CONGENERE - ' SX118-COD-CONGENERE */
                    _.Display($"CONGENERE - {SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE}");

                    /*" -1167- DISPLAY 'SINISTRO  - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V1MSIN_NUM_SINI}");

                    /*" -1168- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1169- END-IF */
                }


                /*" -1170- ELSE */
            }
            else
            {


                /*" -1171- MOVE 'S' TO WTEM-V1COSSEGSINI */
                _.Move("S", AREA_DE_WORK.WTEM_V1COSSEGSINI);

                /*" -1171- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-V1COSSEG-SINI-DB-SELECT-1 */
        public void R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1()
        {
            /*" -1157- EXEC SQL SELECT CONGENER, NUM_SINISTRO, TIPSGU INTO :V1CSIN-CONGENER, :V1CSIN-NUM-SINI, :V1CSIN-TIPSGU FROM SEGUROS.V1COSSEG_SINI WHERE CONGENER = :SX118-COD-CONGENERE AND NUM_SINISTRO = :V1MSIN-NUM-SINI AND TIPSGU = :V0APOL-TIPSGU END-EXEC. */

            var r2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1 = new R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1()
            {
                SX118_COD_CONGENERE = SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE.ToString(),
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V0APOL_TIPSGU = V0APOL_TIPSGU.ToString(),
            };

            var executed_1 = R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CSIN_CONGENER, V1CSIN_CONGENER);
                _.Move(executed_1.V1CSIN_NUM_SINI, V1CSIN_NUM_SINI);
                _.Move(executed_1.V1CSIN_TIPSGU, V1CSIN_TIPSGU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-UPDATE-V0COSSEG-SINI-SECTION */
        private void R2300_00_UPDATE_V0COSSEG_SINI_SECTION()
        {
            /*" -1184- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -1191- PERFORM R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1 */

            R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1();

            /*" -1194- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1195- DISPLAY 'R2300 - ERRO NO UPDATE DA V0COSSEG-SINI' */
                _.Display($"R2300 - ERRO NO UPDATE DA V0COSSEG-SINI");

                /*" -1196- DISPLAY 'TIP SEGUR - ' V1CSIN-TIPSGU */
                _.Display($"TIP SEGUR - {V1CSIN_TIPSGU}");

                /*" -1197- DISPLAY 'CONGENERE - ' V1CSIN-CONGENER */
                _.Display($"CONGENERE - {V1CSIN_CONGENER}");

                /*" -1198- DISPLAY 'SINISTRO  - ' V1CSIN-NUM-SINI */
                _.Display($"SINISTRO  - {V1CSIN_NUM_SINI}");

                /*" -1199- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1200- ELSE */
            }
            else
            {


                /*" -1201- ADD +1 TO AC-U-V0COSSEGSINI */
                AREA_DE_WORK.AC_U_V0COSSEGSINI.Value = AREA_DE_WORK.AC_U_V0COSSEGSINI + +1;

                /*" -1201- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-00-UPDATE-V0COSSEG-SINI-DB-UPDATE-1 */
        public void R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1()
        {
            /*" -1191- EXEC SQL UPDATE SEGUROS.V0COSSEG_SINI SET SITUACAO = :WHOST-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPSGU = :V1CSIN-TIPSGU AND CONGENER = :V1CSIN-CONGENER AND NUM_SINISTRO = :V1CSIN-NUM-SINI END-EXEC. */

            var r2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1 = new R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1()
            {
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V1CSIN_CONGENER = V1CSIN_CONGENER.ToString(),
                V1CSIN_NUM_SINI = V1CSIN_NUM_SINI.ToString(),
                V1CSIN_TIPSGU = V1CSIN_TIPSGU.ToString(),
            };

            R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1.Execute(r2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1217- MOVE V1SIST-DTMOVABE TO WDATA-REL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -1218- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1219- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1221- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1222- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1223- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1224- DISPLAY '*   AC0077B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0077B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -1225- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -1226- DISPLAY '*               S I N I S T R O S          *' . */
            _.Display($"*               S I N I S T R O S          *");

            /*" -1227- DISPLAY '*               -----------------          *' . */
            _.Display($"*               -----------------          *");

            /*" -1228- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1229- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA    *' . */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA    *");

            /*" -1231- DISPLAY '*              ' WDAT-REL-LIT '                    *' . */

            $"*              {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -1232- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1232- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1247- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1249- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1249- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1253- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1253- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}