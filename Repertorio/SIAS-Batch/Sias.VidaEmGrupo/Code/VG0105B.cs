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
using Sias.VidaEmGrupo.DB2.VG0105B;

namespace Code
{
    public class VG0105B
    {
        public bool IsCall { get; set; }

        public VG0105B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROGRAMA ...............  VG0105B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/1991                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERACAO DE PREVIAS, FATURAS E    *      */
        /*"      *                               REFATURAS                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * APOLICE                             V1APOLICE         INPUT    *      */
        /*"      * SOLICITACAO FATURAS                 V1SOLICITA_FAT    INPUT    *      */
        /*"      * RAMOS                               V1RAMOIND         INPUT    *      */
        /*"      * FONTES                              V0FONTE           I-O      *      */
        /*"      * FATURAS                             V1FATURAS         INPUT    *      */
        /*"      * FATURAS                             V0FATURAS         I-O      *      */
        /*"      * TOTAL FATURAS                       V1FATURASTOT      INPUT    *      */
        /*"      * TOTAL FATURAS                       V0FATURASTOT      I-O      *      */
        /*"      * CONTROLE FATURAS                    V1FATURCONT       I-O      *      */
        /*"      * SUB-GRUPOS                          V1SUBGRUPO        INPUT    *      */
        /*"      * NUMERO DE APOLICES/ENDOSSOS         V0NUMERO_AES      I-O      *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 28/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * VERSAO V.01 - INCIDENTE 558204 - ELIMINAR SQLCODE -811 ERRO 060*      */
        /*"      * KINKAS EM 06/12/2023   PROCURAR PELA MARCA V.01                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77         W1ENDO-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis W1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1ENDO-TIPEND       PIC  X(001).*/
        public StringBasis W1ENDO_TIPEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         W1SOLF-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis W1SOLF_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         W1SOLF-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis W1SOLF_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SOLF-NUM-FAT      PIC S9(009)                COMP.*/
        public IntBasis W1SOLF_NUM_FAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1SOLF-VAL-RCAP     PIC S9(013)V99             COMP-3*/
        public DoubleBasis W1SOLF_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         W1SOLF-NUM-RCAP     PIC S9(009)                COMP.*/
        public IntBasis W1SOLF_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1SOLF-DATA-RCAP    PIC  X(010).*/
        public StringBasis W1SOLF_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         W1SOLF-DATA-VENC    PIC  X(010).*/
        public StringBasis W1SOLF_DATA_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         W1SOLF-DATA-RCAP-I  PIC S9(004)                COMP.*/
        public IntBasis W1SOLF_DATA_RCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SOLF-DATA-VENC-I  PIC S9(004)                COMP.*/
        public IntBasis W1SOLF_DATA_VENC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SUBG-COD-FONTE    PIC S9(004)                COMP.*/
        public IntBasis W1SUBG_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SUBG-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis W1SUBG_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SUBG-BCO-COB      PIC S9(004)                COMP.*/
        public IntBasis W1SUBG_BCO_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SUBG-AGE-COB      PIC S9(004)                COMP.*/
        public IntBasis W1SUBG_AGE_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SUBG-DAC-COB      PIC  X(001).*/
        public StringBasis W1SUBG_DAC_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         W1SUBG-END-COB      PIC S9(004)                COMP.*/
        public IntBasis W1SUBG_END_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W2SOLF-NUM-FAT      PIC S9(009)                COMP.*/
        public IntBasis W2SOLF_NUM_FAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1S-COD-FONTE       PIC S9(004)                COMP.*/
        public IntBasis W1S_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1S-COD-SUBG        PIC S9(004)                COMP.*/
        public IntBasis W1S_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1S-COD-OPER        PIC S9(004)                COMP.*/
        public IntBasis W1S_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1S-BCO-COB         PIC S9(004)                COMP.*/
        public IntBasis W1S_BCO_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1S-AGE-COB         PIC S9(004)                COMP.*/
        public IntBasis W1S_AGE_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1S-DAC-COB         PIC  X(001).*/
        public StringBasis W1S_DAC_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         W1S-END-COB         PIC S9(004)                COMP.*/
        public IntBasis W1S_END_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1S-TIPO-FAT        PIC  X(001).*/
        public StringBasis W1S_TIPO_FAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WFLAG-SOLICITA      PIC  X(001)           VALUE '0'.*/
        public StringBasis WFLAG_SOLICITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PERI-RENOVA    PIC S9(004)                COMP.*/
        public IntBasis VIND_PERI_RENOVA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCT-AUMENTO    PIC S9(004)                COMP.*/
        public IntBasis VIND_PCT_AUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)                COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1SUB-GRUPO         PIC S9(004)                COMP.*/
        public IntBasis W1SUB_GRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W2SUB-GRUPO         PIC S9(004)                COMP.*/
        public IntBasis W2SUB_GRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77     NUM-TERMO                     PIC S9(011)    COMP-3.*/
        public IntBasis NUM_TERMO { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77     COD-SUBGRUPO                  PIC S9(004)    COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77     PERI-PAGTO                    PIC S9(004)    COMP.*/
        public IntBasis PERI_PAGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77     DATA-ADESAO                   PIC X(010).*/
        public StringBasis DATA_ADESAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77     DATA-TERVIG                   PIC X(010).*/
        public StringBasis DATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77     MODALIDADE-CAPITAL            PIC X(001).*/
        public StringBasis MODALIDADE_CAPITAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1MOED-CODUNIMO     PIC S9(004)      COMP.*/
        public IntBasis V1MOED_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-VLCRUZAD     PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1MOED-VLCRUZAD-IM  PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis W1MOED_VLCRUZAD_IM { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1MOED-VLCRUZAD-PR  PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis W1MOED_VLCRUZAD_PR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1RIND-ISECUSTO     PIC  X(001).*/
        public StringBasis V1RIND_ISECUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RIND-PCIOF        PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1RIND-DTINIVIG     PIC  X(010).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRAMO-RAMO-VGAP   PIC S9(004)                COMP.*/
        public IntBasis V1PRAMO_RAMO_VGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAMO-RAMO-VG     PIC S9(004)                COMP.*/
        public IntBasis V1PRAMO_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAMO-RAMO-AP     PIC S9(004)                COMP.*/
        public IntBasis V1PRAMO_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FONT-PROPAUTOM    PIC S9(009)                COMP.*/
        public IntBasis V0FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APOL-ORGAO       PIC S9(004)                 COMP.*/
        public IntBasis V1APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APOL-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V1APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1SUBG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SUBG-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-COD-FONTE    PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-TIPO-FAT     PIC  X(001).*/
        public StringBasis V1SUBG_TIPO_FAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-FORMA-FAT    PIC  X(001).*/
        public StringBasis V1SUBG_FORMA_FAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-FORMA-AVER   PIC  X(001).*/
        public StringBasis V1SUBG_FORMA_AVER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-TIPO-PLANO   PIC  X(001).*/
        public StringBasis V1SUBG_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-PERI-FATUR   PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_PERI_FATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUGB-PERI-RENOV   PIC S9(004)                COMP.*/
        public IntBasis V1SUGB_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-PER-RET-INC  PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_PER_RET_INC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUGB-PER-RET-CAN  PIC S9(004)                COMP.*/
        public IntBasis V1SUGB_PER_RET_CAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-OCOR-END     PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_OCOR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-END-COB      PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_END_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-BCO-COB      PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_BCO_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-AGE-COB      PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_AGE_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-DAC-COB      PIC  X(001).*/
        public StringBasis V1SUBG_DAC_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-TIPO-COB     PIC  X(001).*/
        public StringBasis V1SUBG_TIPO_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-COD-PAG-ANG  PIC S9(004)                COMP.*/
        public IntBasis V1SUBG_COD_PAG_ANG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SUBG-PCT-CONJ-VG  PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1SUBG_PCT_CONJ_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1SUBG-PCT-CONJ-AP  PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1SUBG_PCT_CONJ_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1SUBG-OPCAO-COB    PIC  X(001).*/
        public StringBasis V1SUBG_OPCAO_COB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-OPCAO-CORR   PIC  X(001).*/
        public StringBasis V1SUBG_OPCAO_CORR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUGB-IND-CON-MAT  PIC  X(001).*/
        public StringBasis V1SUGB_IND_CON_MAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-IND-PL-ASS   PIC  X(001).*/
        public StringBasis V1SUBG_IND_PL_ASS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-SIT-REGI     PIC  X(001).*/
        public StringBasis V1SUBG_SIT_REGI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-OPCAO-CONJ   PIC  X(001).*/
        public StringBasis V1SUBG_OPCAO_CONJ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SUBG-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1SUBG_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SUBG-CODCLIEN     PIC S9(009)                COMP.*/
        public IntBasis V1SUBG_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SUBG-DTTERVIG     PIC  X(010).*/
        public StringBasis V1SUBG_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SOLF-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1SOLF_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SOLF-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V1SOLF_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SOLF-NUM-FAT      PIC S9(009)                COMP.*/
        public IntBasis V1SOLF_NUM_FAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SOLF-NUM-RCAP     PIC S9(009)                COMP.*/
        public IntBasis V1SOLF_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SOLF-VAL-RCAP     PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1SOLF_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1SOLF-COD-OPER     PIC S9(004)                COMP.*/
        public IntBasis V1SOLF_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SOLF-SIT-REG      PIC  X(001).*/
        public StringBasis V1SOLF_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SOLF-DATA-RCAP    PIC  X(010).*/
        public StringBasis V1SOLF_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SOLF-DATA-RCAP-I  PIC S9(004)       COMP.*/
        public IntBasis V1SOLF_DATA_RCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SOLF-DATA-VENC    PIC  X(010).*/
        public StringBasis V1SOLF_DATA_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SOLF-DATA-VENC-I  PIC S9(004)       COMP.*/
        public IntBasis V1SOLF_DATA_VENC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SOLF-DATA-SOLI    PIC  X(010).*/
        public StringBasis V1SOLF_DATA_SOLI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SOLF-DATA-SOLI-I  PIC S9(004)       COMP.*/
        public IntBasis V1SOLF_DATA_SOLI_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SOLF-COD-USUAR    PIC  X(008).*/
        public StringBasis V1SOLF_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1RCAP-BCOAVISO     PIC S9(004)                COMP.*/
        public IntBasis V1RCAP_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RCAP-AGEAVISO     PIC S9(004)                COMP.*/
        public IntBasis V1RCAP_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-IMP   PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-PRM   PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-OCORR-END   PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-CORRECAO-I  PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CORRECAO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1FATR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1FATR-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V1FATR_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-NUM-FATUR    PIC S9(009)                COMP.*/
        public IntBasis V1FATR_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATR-COD-OPER     PIC S9(004)                COMP.*/
        public IntBasis V1FATR_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-TIPO-ENDOS   PIC  X(001).*/
        public StringBasis V1FATR_TIPO_ENDOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1FATR-NUM-ENDOS    PIC S9(009)                COMP.*/
        public IntBasis V1FATR_NUM_ENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATR-VAL-FATURA   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATR_VAL_FATURA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATR-COD-FONTE    PIC S9(004)                COMP.*/
        public IntBasis V1FATR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-NUM-RCAP     PIC S9(009)                COMP.*/
        public IntBasis V1FATR_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATR-VAL-RCAP     PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATR_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATR-DATA-INIVIG  PIC  X(010).*/
        public StringBasis V1FATR_DATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FATR-DATA-TERVIG  PIC  X(010).*/
        public StringBasis V1FATR_DATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FATR-SIT-REG      PIC  X(001).*/
        public StringBasis V1FATR_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1FATR-DATA-FATUR   PIC  X(010).*/
        public StringBasis V1FATR_DATA_FATUR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FATR-DATA-RCAP    PIC  X(010).*/
        public StringBasis V1FATR_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FATR-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1FATR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATR-DATA-VENC    PIC  X(010).*/
        public StringBasis V1FATR_DATA_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FATR-DATA-VENC-I  PIC S9(004)                COMP.*/
        public IntBasis V1FATR_DATA_VENC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-DATA-RCAP-I  PIC S9(004)                COMP.*/
        public IntBasis V1FATR_DATA_RCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-DATA-FATU-I  PIC S9(004)                COMP.*/
        public IntBasis V1FATR_DATA_FATU_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-QTDDIACARE   PIC S9(004)                COMP.*/
        public IntBasis V1FATR_QTDDIACARE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATR-VLIOCC       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATR_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATR-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0FATR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FATR-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V0FATR_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-NUM-FATUR    PIC S9(009)                COMP.*/
        public IntBasis V0FATR_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATR-COD-OPER     PIC S9(004)                COMP.*/
        public IntBasis V0FATR_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-TIPO-ENDOS   PIC  X(001).*/
        public StringBasis V0FATR_TIPO_ENDOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FATR-NUM-ENDOS    PIC S9(009)                COMP.*/
        public IntBasis V0FATR_NUM_ENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATR-VAL-FATURA   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATR_VAL_FATURA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATR-COD-FONTE    PIC S9(004)                COMP.*/
        public IntBasis V0FATR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-NUM-RCAP     PIC S9(009)                COMP.*/
        public IntBasis V0FATR_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATR-VAL-RCAP     PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATR_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATR-DATA-INIVIG  PIC  X(010).*/
        public StringBasis V0FATR_DATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATR-DATA-TERVIG  PIC  X(010).*/
        public StringBasis V0FATR_DATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATR-SIT-REG      PIC  X(001).*/
        public StringBasis V0FATR_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FATR-DATA-FATUR   PIC  X(010).*/
        public StringBasis V0FATR_DATA_FATUR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATR-DATA-RCAP    PIC  X(010).*/
        public StringBasis V0FATR_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATR-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0FATR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATR-DATA-VENC    PIC  X(010).*/
        public StringBasis V0FATR_DATA_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATR-DATA-VENC-I  PIC S9(004)                COMP.*/
        public IntBasis V0FATR_DATA_VENC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-DATA-RCAP-I  PIC S9(004)                COMP.*/
        public IntBasis V0FATR_DATA_RCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-DATA-FATU-I  PIC S9(004)                COMP.*/
        public IntBasis V0FATR_DATA_FATU_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-QTDDIACARE   PIC S9(004)                COMP.*/
        public IntBasis V0FATR_QTDDIACARE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-VLIOCC       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATR_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1FATT_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1FATT-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V1FATT_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATT-NUM-FATUR    PIC S9(009)                COMP.*/
        public IntBasis V1FATT_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATT-COD-OPER     PIC S9(004)                COMP.*/
        public IntBasis V1FATT_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATT-QT-VIDA-VG   PIC S9(009)                COMP.*/
        public IntBasis V1FATT_QT_VIDA_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATT-QT-VIDA-AP   PIC S9(009)                COMP.*/
        public IntBasis V1FATT_QT_VIDA_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATT-IMP-MORNAT   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_MORNAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-MORACI   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_MORACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-INVPER   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-AMDS     PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-DH       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-DIT      PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-PRM-VG       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-PRM-AP       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-SIT-REG      PIC  X(001).*/
        public StringBasis V1FATT_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1FATT-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1FATT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATT-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0FATT_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FATT-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V0FATT_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATT-NUM-FATUR    PIC S9(009)                COMP.*/
        public IntBasis V0FATT_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATT-COD-OPER     PIC S9(004)                COMP.*/
        public IntBasis V0FATT_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATT-QT-VIDA-VG   PIC S9(009)                COMP.*/
        public IntBasis V0FATT_QT_VIDA_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATT-QT-VIDA-AP   PIC S9(009)                COMP.*/
        public IntBasis V0FATT_QT_VIDA_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATT-IMP-MORNAT   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_IMP_MORNAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-IMP-MORACI   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_IMP_MORACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-IMP-INVPER   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_IMP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-IMP-AMDS     PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-IMP-DH       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-IMP-DIT      PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-PRM-VG       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-PRM-AP       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATT-SIT-REG      PIC  X(001).*/
        public StringBasis V0FATT_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FATT-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0FATT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FATC-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0FATC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FATC-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V0FATC_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATC-DATA-REFER   PIC  X(010).*/
        public StringBasis V0FATC_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATC-DAT-ULT-FAT  PIC  X(010).*/
        public StringBasis V0FATC_DAT_ULT_FAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FATC-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0FATC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATC-NUM-APOLICE  PIC S9(013)                COMP-3*/
        public IntBasis V1FATC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1FATC-DATA-REFER   PIC  X(010).*/
        public StringBasis V1FATC_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MOVI-MORNATU-ANT  PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_MORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-MORNATU-ATU  PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-MORACID-ANT  PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_MORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-MORACID-ATU  PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-INVPERM-ANT  PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_INVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-INVPERM-ATU  PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-AMDS-ANT     PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_AMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-AMDS-ATU     PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-DH-ANT       PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_DH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-DH-ATU       PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-DIT-ANT      PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_DIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-DIT-ATU      PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-VG-ANT       PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_VG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-VG-ATU       PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-AP-ANT       PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_AP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-AP-ATU       PIC S9(013)V9(2)     COMP-3.*/
        public DoubleBasis V0MOVI_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0MOVI-COD-OPER         PIC S9(004)          COMP.*/
        public IntBasis V0MOVI_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MOVI-DATA-MOVI        PIC  X(010).*/
        public StringBasis V0MOVI_DATA_MOVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MOVI-DATA-FATURA      PIC  X(010).*/
        public StringBasis V0MOVI_DATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VG0105B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0105B_AREA_DE_WORK();
        public class VG0105B_AREA_DE_WORK : VarBasis
        {
            /*" 05          WS-DTRENOVA           PIC X(010).*/
            public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 05          WS-DTINIVIG           PIC X(010).*/
            public StringBasis WS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 05          WS-DTFATUR.*/
            public VG0105B_WS_DTFATUR WS_DTFATUR { get; set; } = new VG0105B_WS_DTFATUR();
            public class VG0105B_WS_DTFATUR : VarBasis
            {
                /*"   10        WS-DTFATUR-AM.*/
                public VG0105B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VG0105B_WS_DTFATUR_AM();
                public class VG0105B_WS_DTFATUR_AM : VarBasis
                {
                    /*"     15      WS-AAFATUR            PIC 9(004).*/
                    public IntBasis WS_AAFATUR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15      FILLER                PIC X(001).*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15      WS-MMFATUR            PIC 9(002).*/
                    public IntBasis WS_MMFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10        FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10        WS-DDFATUR            PIC 9(002).*/
                public IntBasis WS_DDFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05          WS-DTBASE.*/
            }
            public VG0105B_WS_DTBASE WS_DTBASE { get; set; } = new VG0105B_WS_DTBASE();
            public class VG0105B_WS_DTBASE : VarBasis
            {
                /*"   10        WS-DTBASE-AM.*/
                public VG0105B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VG0105B_WS_DTBASE_AM();
                public class VG0105B_WS_DTBASE_AM : VarBasis
                {
                    /*"     15      WS-AABASE             PIC 9(004).*/
                    public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15      FILLER                PIC X(001).*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15      WS-MMBASE             PIC 9(002).*/
                    public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10        FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10        WS-DDBASE             PIC 9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05          WS-DIA                PIC 9(004).*/
            }
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WSTATUS           PIC  X(002)    VALUE  ZEROS.*/
            public StringBasis WSTATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05         WSOUTROS          PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WSOUTROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WS-SOMA           PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WS_SOMA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WZEROS            PIC S9(003)    VALUE +0  COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WRESTO            PIC S9(005)    VALUE +0  COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WRESPOSTA         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WRESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFATNT-PREMIO     PIC S9(013)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WFATNT_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         PRM-TOTAL         PIC S9(010)V9(5)         COMP-3.*/
            public DoubleBasis PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05         CLACUM1           PIC S9(005)   VALUE +0   COMP-3.*/
            public IntBasis CLACUM1 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         CLACUM2           PIC S9(005)   VALUE +0   COMP-3.*/
            public IntBasis CLACUM2 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WK-DATA1.*/
            public VG0105B_WK_DATA1 WK_DATA1 { get; set; } = new VG0105B_WK_DATA1();
            public class VG0105B_WK_DATA1 : VarBasis
            {
                /*"    10       WK-ANO1           PIC  9(004).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CLANOMES.*/
            }
            public VG0105B_CLANOMES CLANOMES { get; set; } = new VG0105B_CLANOMES();
            public class VG0105B_CLANOMES : VarBasis
            {
                /*"    10       CLANO             PIC  9(004).*/
                public IntBasis CLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CLMES             PIC  9(002).*/
                public IntBasis CLMES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CLDIA             PIC  9(002).*/
                public IntBasis CLDIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CLDATA1           PIC  9(006)    VALUE ZEROS.*/
            }
            public IntBasis CLDATA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         FILLER            REDEFINES      CLDATA1.*/
            private _REDEF_VG0105B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG0105B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG0105B_FILLER_8(); _.Move(CLDATA1, _filler_8); VarBasis.RedefinePassValue(CLDATA1, _filler_8, CLDATA1); _filler_8.ValueChanged += () => { _.Move(_filler_8, CLDATA1); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, CLDATA1); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_8 : VarBasis
            {
                /*"    10       CLANO1            PIC  9(004).*/
                public IntBasis CLANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       CLMES1            PIC  9(002).*/
                public IntBasis CLMES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CLDATA2           PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_8()
                {
                    CLANO1.ValueChanged += OnValueChanged;
                    CLMES1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis CLDATA2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         FILLER            REDEFINES      CLDATA2.*/
            private _REDEF_VG0105B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VG0105B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VG0105B_FILLER_9(); _.Move(CLDATA2, _filler_9); VarBasis.RedefinePassValue(CLDATA2, _filler_9, CLDATA2); _filler_9.ValueChanged += () => { _.Move(_filler_9, CLDATA2); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, CLDATA2); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_9 : VarBasis
            {
                /*"    10       CLANO2            PIC  9(004).*/
                public IntBasis CLANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       CLMES2            PIC  9(002).*/
                public IntBasis CLMES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_9()
                {
                    CLANO2.ValueChanged += OnValueChanged;
                    CLMES2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG0105B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_VG0105B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_VG0105B_FILLER_10(); _.Move(W01DTCSP, _filler_10); VarBasis.RedefinePassValue(W01DTCSP, _filler_10, W01DTCSP); _filler_10.ValueChanged += () => { _.Move(_filler_10, W01DTCSP); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_10 : VarBasis
            {
                /*"    10       W01DDCSP          PIC  9(002).*/
                public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01MMCSP          PIC  9(002).*/
                public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01AACSP          PIC  9(004).*/
                public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_10()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG0105B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VG0105B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VG0105B_FILLER_11(); _.Move(W02DTCSP, _filler_11); VarBasis.RedefinePassValue(W02DTCSP, _filler_11, W02DTCSP); _filler_11.ValueChanged += () => { _.Move(_filler_11, W02DTCSP); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_11 : VarBasis
            {
                /*"    10       W02DDCSP          PIC  9(002).*/
                public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02MMCSP          PIC  9(002).*/
                public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02AACSP          PIC  9(004).*/
                public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WVENCIMENTO       PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VG0105B_FILLER_11()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WVENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WVENCIMENTO.*/
            private _REDEF_VG0105B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VG0105B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VG0105B_FILLER_12(); _.Move(WVENCIMENTO, _filler_12); VarBasis.RedefinePassValue(WVENCIMENTO, _filler_12, WVENCIMENTO); _filler_12.ValueChanged += () => { _.Move(_filler_12, WVENCIMENTO); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WVENCIMENTO); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_12 : VarBasis
            {
                /*"    10       WVENC-ANOMES.*/
                public VG0105B_WVENC_ANOMES WVENC_ANOMES { get; set; } = new VG0105B_WVENC_ANOMES();
                public class VG0105B_WVENC_ANOMES : VarBasis
                {
                    /*"      15     WVENC-ANO         PIC  X(004).*/
                    public StringBasis WVENC_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WVENC-MES         PIC  X(002).*/
                    public StringBasis WVENC_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       FILLER            PIC  X(001).*/

                    public VG0105B_WVENC_ANOMES()
                    {
                        WVENC_ANO.ValueChanged += OnValueChanged;
                        FILLER_13.ValueChanged += OnValueChanged;
                        WVENC_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WVENC-DIA         PIC  9(002).*/
                public IntBasis WVENC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WEMISSAO          PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VG0105B_FILLER_12()
                {
                    WVENC_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WVENC_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WEMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WEMISSAO.*/
            private _REDEF_VG0105B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_VG0105B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_VG0105B_FILLER_15(); _.Move(WEMISSAO, _filler_15); VarBasis.RedefinePassValue(WEMISSAO, _filler_15, WEMISSAO); _filler_15.ValueChanged += () => { _.Move(_filler_15, WEMISSAO); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WEMISSAO); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_15 : VarBasis
            {
                /*"    10       WEMIS-ANOMES.*/
                public VG0105B_WEMIS_ANOMES WEMIS_ANOMES { get; set; } = new VG0105B_WEMIS_ANOMES();
                public class VG0105B_WEMIS_ANOMES : VarBasis
                {
                    /*"      15     WEMIS-ANO         PIC  X(004).*/
                    public StringBasis WEMIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      15     FILLER            PIC  X(001).*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WEMIS-MES         PIC  X(002).*/
                    public StringBasis WEMIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       FILLER            PIC  X(001).*/

                    public VG0105B_WEMIS_ANOMES()
                    {
                        WEMIS_ANO.ValueChanged += OnValueChanged;
                        FILLER_16.ValueChanged += OnValueChanged;
                        WEMIS_MES.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WEMIS-DIA         PIC  9(002).*/
                public IntBasis WEMIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WNUMERO-APOL      PIC  9(013)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_15()
                {
                    WEMIS_ANOMES.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    WEMIS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUMERO_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WNUMERO-APOL.*/
            private _REDEF_VG0105B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VG0105B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VG0105B_FILLER_18(); _.Move(WNUMERO_APOL, _filler_18); VarBasis.RedefinePassValue(WNUMERO_APOL, _filler_18, WNUMERO_APOL); _filler_18.ValueChanged += () => { _.Move(_filler_18, WNUMERO_APOL); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, WNUMERO_APOL); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_18 : VarBasis
            {
                /*"    10       WNUM-APOL-ORG     PIC  9(003).*/
                public IntBasis WNUM_APOL_ORG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WNUM-APOL-RAM     PIC  9(002).*/
                public IntBasis WNUM_APOL_RAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WNUM-APOL-SEQ     PIC  9(008).*/
                public IntBasis WNUM_APOL_SEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WNUM-APOLICE      PIC S9(013)    VALUE +0  COMP-3.*/

                public _REDEF_VG0105B_FILLER_18()
                {
                    WNUM_APOL_ORG.ValueChanged += OnValueChanged;
                    WNUM_APOL_RAM.ValueChanged += OnValueChanged;
                    WNUM_APOL_SEQ.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         WNUM-FATURA       PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WNUM_FATURA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         FILLER            REDEFINES      WNUM-FATURA.*/
            private _REDEF_VG0105B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_VG0105B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_VG0105B_FILLER_19(); _.Move(WNUM_FATURA, _filler_19); VarBasis.RedefinePassValue(WNUM_FATURA, _filler_19, WNUM_FATURA); _filler_19.ValueChanged += () => { _.Move(_filler_19, WNUM_FATURA); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, WNUM_FATURA); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_19 : VarBasis
            {
                /*"    10       WFAT-ANO          PIC  9(004).*/
                public IntBasis WFAT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WFAT-MES          PIC  9(002).*/
                public IntBasis WFAT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WNUM-FATURA1      PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_19()
                {
                    WFAT_ANO.ValueChanged += OnValueChanged;
                    WFAT_MES.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_FATURA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         FILLER            REDEFINES      WNUM-FATURA1.*/
            private _REDEF_VG0105B_FILLER_20 _filler_20 { get; set; }
            public _REDEF_VG0105B_FILLER_20 FILLER_20
            {
                get { _filler_20 = new _REDEF_VG0105B_FILLER_20(); _.Move(WNUM_FATURA1, _filler_20); VarBasis.RedefinePassValue(WNUM_FATURA1, _filler_20, WNUM_FATURA1); _filler_20.ValueChanged += () => { _.Move(_filler_20, WNUM_FATURA1); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, WNUM_FATURA1); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_20 : VarBasis
            {
                /*"    10       WFAT-ANO1         PIC  9(004).*/
                public IntBasis WFAT_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WFAT-MES1         PIC  9(002).*/
                public IntBasis WFAT_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W1MOVI-NUM-FAT.*/

                public _REDEF_VG0105B_FILLER_20()
                {
                    WFAT_ANO1.ValueChanged += OnValueChanged;
                    WFAT_MES1.ValueChanged += OnValueChanged;
                }

            }
            public VG0105B_W1MOVI_NUM_FAT W1MOVI_NUM_FAT { get; set; } = new VG0105B_W1MOVI_NUM_FAT();
            public class VG0105B_W1MOVI_NUM_FAT : VarBasis
            {
                /*"    10       W1ANO-FAT         PIC  9(004).*/
                public IntBasis W1ANO_FAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       W1MES-FAT         PIC  9(002).*/
                public IntBasis W1MES_FAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       W1DIA-FAT         PIC  9(002).*/
                public IntBasis W1DIA_FAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-INIVIG      PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-INIVIG.*/
            private _REDEF_VG0105B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_VG0105B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_VG0105B_FILLER_23(); _.Move(WDATA_INIVIG, _filler_23); VarBasis.RedefinePassValue(WDATA_INIVIG, _filler_23, WDATA_INIVIG); _filler_23.ValueChanged += () => { _.Move(_filler_23, WDATA_INIVIG); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WDATA_INIVIG); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_23 : VarBasis
            {
                /*"    10       WINI-ANO          PIC  9(004).*/
                public IntBasis WINI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WINI-BR1          PIC  X(001).*/
                public StringBasis WINI_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WINI-MES          PIC  9(002).*/
                public IntBasis WINI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WINI-BR2          PIC  X(001).*/
                public StringBasis WINI_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WINI-DIA          PIC  9(002).*/
                public IntBasis WINI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-TERVIG      PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VG0105B_FILLER_23()
                {
                    WINI_ANO.ValueChanged += OnValueChanged;
                    WINI_BR1.ValueChanged += OnValueChanged;
                    WINI_MES.ValueChanged += OnValueChanged;
                    WINI_BR2.ValueChanged += OnValueChanged;
                    WINI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-TERVIG.*/
            private _REDEF_VG0105B_FILLER_24 _filler_24 { get; set; }
            public _REDEF_VG0105B_FILLER_24 FILLER_24
            {
                get { _filler_24 = new _REDEF_VG0105B_FILLER_24(); _.Move(WDATA_TERVIG, _filler_24); VarBasis.RedefinePassValue(WDATA_TERVIG, _filler_24, WDATA_TERVIG); _filler_24.ValueChanged += () => { _.Move(_filler_24, WDATA_TERVIG); }; return _filler_24; }
                set { VarBasis.RedefinePassValue(value, _filler_24, WDATA_TERVIG); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_24 : VarBasis
            {
                /*"    10       WTER-ANO.*/
                public VG0105B_WTER_ANO WTER_ANO { get; set; } = new VG0105B_WTER_ANO();
                public class VG0105B_WTER_ANO : VarBasis
                {
                    /*"      15     WTER-ANOA         PIC  9(004).*/
                    public IntBasis WTER_ANOA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       WTER-BR1          PIC  X(001).*/

                    public VG0105B_WTER_ANO()
                    {
                        WTER_ANOA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTER_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTER-MES          PIC  9(002).*/
                public IntBasis WTER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WTER-BR2          PIC  X(001).*/
                public StringBasis WTER_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTER-DIA          PIC  9(002).*/
                public IntBasis WTER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-CORRECAO    PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VG0105B_FILLER_24()
                {
                    WTER_ANO.ValueChanged += OnValueChanged;
                    WTER_BR1.ValueChanged += OnValueChanged;
                    WTER_MES.ValueChanged += OnValueChanged;
                    WTER_BR2.ValueChanged += OnValueChanged;
                    WTER_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CORRECAO.*/
            private _REDEF_VG0105B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG0105B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG0105B_FILLER_25(); _.Move(WDATA_CORRECAO, _filler_25); VarBasis.RedefinePassValue(WDATA_CORRECAO, _filler_25, WDATA_CORRECAO); _filler_25.ValueChanged += () => { _.Move(_filler_25, WDATA_CORRECAO); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WDATA_CORRECAO); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_25 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG0105B_WCOR_ANO WCOR_ANO { get; set; } = new VG0105B_WCOR_ANO();
                public class VG0105B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOA         PIC  9(004).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG0105B_WCOR_ANO()
                    {
                        WCOR_ANOA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WCOR_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-MES          PIC  9(002).*/
                public IntBasis WCOR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WCOR-BR2          PIC  X(001).*/
                public StringBasis WCOR_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-DIA          PIC  9(002).*/
                public IntBasis WCOR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-REFERENCIA  PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VG0105B_FILLER_25()
                {
                    WCOR_ANO.ValueChanged += OnValueChanged;
                    WCOR_BR1.ValueChanged += OnValueChanged;
                    WCOR_MES.ValueChanged += OnValueChanged;
                    WCOR_BR2.ValueChanged += OnValueChanged;
                    WCOR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REFERENCIA.*/
            private _REDEF_VG0105B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_VG0105B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_VG0105B_FILLER_26(); _.Move(WDATA_REFERENCIA, _filler_26); VarBasis.RedefinePassValue(WDATA_REFERENCIA, _filler_26, WDATA_REFERENCIA); _filler_26.ValueChanged += () => { _.Move(_filler_26, WDATA_REFERENCIA); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WDATA_REFERENCIA); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_26 : VarBasis
            {
                /*"    10       WREF-ANO          PIC  9(004).*/
                public IntBasis WREF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WREF-BR1          PIC  X(001).*/
                public StringBasis WREF_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREF-MES          PIC  9(002).*/
                public IntBasis WREF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WREF-BR2          PIC  X(001).*/
                public StringBasis WREF_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREF-DIA          PIC  9(002).*/
                public IntBasis WREF_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-PARAMETRO   PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_26()
                {
                    WREF_ANO.ValueChanged += OnValueChanged;
                    WREF_BR1.ValueChanged += OnValueChanged;
                    WREF_MES.ValueChanged += OnValueChanged;
                    WREF_BR2.ValueChanged += OnValueChanged;
                    WREF_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_PARAMETRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES      WDATA-PARAMETRO.*/
            private _REDEF_VG0105B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VG0105B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VG0105B_FILLER_27(); _.Move(WDATA_PARAMETRO, _filler_27); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_27, WDATA_PARAMETRO); _filler_27.ValueChanged += () => { _.Move(_filler_27, WDATA_PARAMETRO); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WDATA_PARAMETRO); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_27 : VarBasis
            {
                /*"    10       WPAR-DIA          PIC  9(002).*/
                public IntBasis WPAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-MES          PIC  9(002).*/
                public IntBasis WPAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-ANO          PIC  9(004).*/
                public IntBasis WPAR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WDATA-RETORNO     PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG0105B_FILLER_27()
                {
                    WPAR_DIA.ValueChanged += OnValueChanged;
                    WPAR_MES.ValueChanged += OnValueChanged;
                    WPAR_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_RETORNO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES      WDATA-RETORNO.*/
            private _REDEF_VG0105B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_VG0105B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_VG0105B_FILLER_28(); _.Move(WDATA_RETORNO, _filler_28); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_28, WDATA_RETORNO); _filler_28.ValueChanged += () => { _.Move(_filler_28, WDATA_RETORNO); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WDATA_RETORNO); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_28 : VarBasis
            {
                /*"    10       WRET-DIA          PIC  9(002).*/
                public IntBasis WRET_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-MES          PIC  9(002).*/
                public IntBasis WRET_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-ANO          PIC  9(004).*/
                public IntBasis WRET_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WPROSOMC1.*/

                public _REDEF_VG0105B_FILLER_28()
                {
                    WRET_DIA.ValueChanged += OnValueChanged;
                    WRET_MES.ValueChanged += OnValueChanged;
                    WRET_ANO.ValueChanged += OnValueChanged;
                }

            }
            public VG0105B_WPROSOMC1 WPROSOMC1 { get; set; } = new VG0105B_WPROSOMC1();
            public class VG0105B_WPROSOMC1 : VarBasis
            {
                /*"    10       WDATA-INFORMADA   PIC  9(008).*/
                public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       WDATA-QTDIAS      PIC S9(005)    COMP-3.*/
                public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    10       WDATA-CALCULO     PIC  9(008).*/
                public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PARAMRAMO  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PARAMRAMO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SOLICFAT   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SOLICFAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1FATURAS    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1FATURAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1FATURTOT   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1FATURTOT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SUBGRUPO   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1FATURANT   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1FATURANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-FATURA-ANT   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_FATURA_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-TERMO-ADESAO PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_TERMO_ADESAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-L-V1SOLICFAT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_L_V1SOLICFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-R-V1SOLICFAT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_R_V1SOLICFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-P-V1SOLICFAT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_P_V1SOLICFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-L-V1FATURAS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_L_V1FATURAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-L-V1FATURAFAT  PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_L_V1FATURAFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-V1SUBGRUPO   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_V1SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-V1FATURAS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_V1FATURAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-V1FATURANT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_V1FATURANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-V1APOLICE    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_V1APOLICE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-V1FATURTOT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_V1FATURTOT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-S-V1ENDOSSO    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_S_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-V0FATURAS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FATURAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-I-V0FATURASTOT PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FATURASTOT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-D-V0FATURTOT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_D_V0FATURTOT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-A-V0FATURAS    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_A_V0FATURAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-A-V0FATURCONT  PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_A_V0FATURCONT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-A-V0SOLICFAT   PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_A_V0SOLICFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VG0105B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_VG0105B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_VG0105B_FILLER_29(); _.Move(WDATA_REL, _filler_29); VarBasis.RedefinePassValue(WDATA_REL, _filler_29, WDATA_REL); _filler_29.ValueChanged += () => { _.Move(_filler_29, WDATA_REL); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG0105B_FILLER_29 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_VG0105B_FILLER_29()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_30.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_31.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG0105B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG0105B_WDAT_REL_LIT();
            public class VG0105B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WTIME-DAY         PIC  99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"  05         WTIME-DAYR        REDEFINES      WTIME-DAY.*/
            private _REDEF_VG0105B_WTIME_DAYR _wtime_dayr { get; set; }
            public _REDEF_VG0105B_WTIME_DAYR WTIME_DAYR
            {
                get { _wtime_dayr = new _REDEF_VG0105B_WTIME_DAYR(); _.Move(WTIME_DAY, _wtime_dayr); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_dayr, WTIME_DAY); _wtime_dayr.ValueChanged += () => { _.Move(_wtime_dayr, WTIME_DAY); }; return _wtime_dayr; }
                set { VarBasis.RedefinePassValue(value, _wtime_dayr, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG0105B_WTIME_DAYR : VarBasis
            {
                /*"    10       WTIME-HORA        PIC  X(002).*/
                public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WTIME-2PT1        PIC  X(001).*/
                public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-MINU        PIC  X(002).*/
                public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WTIME-2PT2        PIC  X(001).*/
                public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-SEGU        PIC  X(002).*/
                public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05           TACUM-IMPRESSAO.*/

                public _REDEF_VG0105B_WTIME_DAYR()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_2PT1.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_2PT2.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                }

            }
            public VG0105B_TACUM_IMPRESSAO TACUM_IMPRESSAO { get; set; } = new VG0105B_TACUM_IMPRESSAO();
            public class VG0105B_TACUM_IMPRESSAO : VarBasis
            {
                /*"    10         TACUM-MASCARA.*/
                public VG0105B_TACUM_MASCARA TACUM_MASCARA { get; set; } = new VG0105B_TACUM_MASCARA();
                public class VG0105B_TACUM_MASCARA : VarBasis
                {
                    /*"      15       FILLER           PIC S9(013)      VALUE +0 COMP-3*/
                    public IntBasis FILLER_34 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                    /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                    public IntBasis FILLER_35 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_36 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                    public IntBasis FILLER_37 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_38 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_39 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_40 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_41 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_42 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_43 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_44 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_45 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_46 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_47 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_48 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC  X(001)      VALUE  SPACES.*/
                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_50 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       TACUM-CAMPOS.*/
                    public VG0105B_TACUM_CAMPOS TACUM_CAMPOS { get; set; } = new VG0105B_TACUM_CAMPOS();
                    public class VG0105B_TACUM_CAMPOS : VarBasis
                    {
                        /*"        20     TACUM-OPERACAO   OCCURS 14  TIMES INDEXED BY I01.*/
                        public ListBasis<VG0105B_TACUM_OPERACAO> TACUM_OPERACAO { get; set; } = new ListBasis<VG0105B_TACUM_OPERACAO>(14);
                        public class VG0105B_TACUM_OPERACAO : VarBasis
                        {
                            /*"          25   NUM-APOL         PIC S9(013)               COMP-3*/
                            public IntBasis NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                            /*"          25   COD-SUBG         PIC S9(004)               COMP.*/
                            public IntBasis COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          25   NUM-FATUR        PIC S9(009)               COMP.*/
                            public IntBasis NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          25   COD-OPER         PIC S9(004)               COMP.*/
                            public IntBasis COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          25   QT-VIDA-VG       PIC S9(009)               COMP.*/
                            public IntBasis QT_VIDA_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          25   QT-VIDA-AP       PIC S9(009)               COMP.*/
                            public IntBasis QT_VIDA_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          25   IMP-MORNAT       PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_MORNAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   IMP-MORACI       PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_MORACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   IMP-INVPER       PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   IMP-AMDS         PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   IMP-DH           PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   IMP-DIT          PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   IMP-DMH          PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis IMP_DMH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   PRM-VG           PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   PRM-AP           PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25   SIT-REG          PIC  X(001).*/
                            public StringBasis SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          25   COD-EMPRESA      PIC S9(009)               COMP.*/
                            public IntBasis COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"  05          ATACUM-IMPRESSAO.*/
                        }
                    }
                }
            }
            public VG0105B_ATACUM_IMPRESSAO ATACUM_IMPRESSAO { get; set; } = new VG0105B_ATACUM_IMPRESSAO();
            public class VG0105B_ATACUM_IMPRESSAO : VarBasis
            {
                /*"    10        ATACUM-MASCARA.*/
                public VG0105B_ATACUM_MASCARA ATACUM_MASCARA { get; set; } = new VG0105B_ATACUM_MASCARA();
                public class VG0105B_ATACUM_MASCARA : VarBasis
                {
                    /*"      15       FILLER           PIC S9(013)      VALUE +0 COMP-3*/
                    public IntBasis FILLER_51 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                    /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                    public IntBasis FILLER_52 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_53 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                    public IntBasis FILLER_54 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_55 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_56 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_57 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_58 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_59 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_60 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_61 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_62 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_63 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_64 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                    public DoubleBasis FILLER_65 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                    /*"      15       FILLER           PIC  X(001)      VALUE  SPACES.*/
                    public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                    public IntBasis FILLER_67 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"      15      ATACUM-CAMPOS.*/
                    public VG0105B_ATACUM_CAMPOS ATACUM_CAMPOS { get; set; } = new VG0105B_ATACUM_CAMPOS();
                    public class VG0105B_ATACUM_CAMPOS : VarBasis
                    {
                        /*"        20    ATACUM-OPERACAO   OCCURS 14 TIMES INDEXED BY I02.*/
                        public ListBasis<VG0105B_ATACUM_OPERACAO> ATACUM_OPERACAO { get; set; } = new ListBasis<VG0105B_ATACUM_OPERACAO>(14);
                        public class VG0105B_ATACUM_OPERACAO : VarBasis
                        {
                            /*"          25  ANUM-APOL         PIC S9(013)               COMP-3*/
                            public IntBasis ANUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                            /*"          25  ACOD-SUBG         PIC S9(004)               COMP.*/
                            public IntBasis ACOD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          25  ANUM-FATUR        PIC S9(009)               COMP.*/
                            public IntBasis ANUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          25  ACOD-OPER         PIC S9(004)               COMP.*/
                            public IntBasis ACOD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          25  AQT-VIDA-VG       PIC S9(009)               COMP.*/
                            public IntBasis AQT_VIDA_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          25  AQT-VIDA-AP       PIC S9(009)               COMP.*/
                            public IntBasis AQT_VIDA_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          25  AIMP-MORNAT       PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_MORNAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  AIMP-MORACI       PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_MORACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  AIMP-INVPER       PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  AIMP-AMDS         PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  AIMP-DH           PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  AIMP-DIT          PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  AIMP-DMH          PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis AIMP_DMH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  APRM-VG           PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis APRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  APRM-AP           PIC S9(013)V9(2)          COMP-3*/
                            public DoubleBasis APRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                            /*"          25  ASIT-REG          PIC  X(001).*/
                            public StringBasis ASIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          25  ACOD-EMPRESA      PIC S9(009)               COMP.*/
                            public IntBasis ACOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"  05       OUT-IMP-MORNAT       PIC S9(013)V9(2)          COMP-3*/
                        }
                    }
                }
            }
            public DoubleBasis OUT_IMP_MORNAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-IMP-MORACI       PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_IMP_MORACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-IMP-INVPER       PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_IMP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-IMP-AMDS         PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-IMP-DH           PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-IMP-DIT          PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-PRM-VG           PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-PRM-AP           PIC S9(013)V9(2)          COMP-3*/
            public DoubleBasis OUT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  05       OUT-QT-VIDA-VG       PIC S9(009)               COMP.*/
            public IntBasis OUT_QT_VIDA_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       OUT-QT-VIDA-AP       PIC S9(009)               COMP.*/
            public IntBasis OUT_QT_VIDA_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WABEND.*/
            public VG0105B_WABEND WABEND { get; set; } = new VG0105B_WABEND();
            public class VG0105B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VG0105B'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0105B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  01        LK-LINK.*/
            }
            public VG0105B_LK_LINK LK_LINK { get; set; } = new VG0105B_LK_LINK();
            public class VG0105B_LK_LINK : VarBasis
            {
                /*"      05     LK-DATA1          PIC  9(008).*/
                public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      05     LK-DATA2          PIC  9(008).*/
                public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
                public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            }
        }


        public VG0105B_V1SOLICFAT V1SOLICFAT { get; set; } = new VG0105B_V1SOLICFAT();
        public VG0105B_V1FATTOT V1FATTOT { get; set; } = new VG0105B_V1FATTOT();
        public VG0105B_V1SUBGRUPO V1SUBGRUPO { get; set; } = new VG0105B_V1SUBGRUPO();
        public VG0105B_V1FATURTOT1 V1FATURTOT1 { get; set; } = new VG0105B_V1FATURTOT1();
        public VG0105B_MOVIMENTO MOVIMENTO { get; set; } = new VG0105B_MOVIMENTO();
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
            /*" -770- DISPLAY ' ' */
            _.Display($" ");

            /*" -772- DISPLAY '================================================' '================================================' */
            _.Display($"================================================================================================");

            /*" -774- DISPLAY 'VG0105B - VERSAO V.01 - INCIDENTE 558204 - ' FUNCTION WHEN-COMPILED */

            $"VG0105B - VERSAO V.01 - INCIDENTE 558204 - FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -775- DISPLAY ' ' */
            _.Display($" ");

            /*" -784- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -785- MOVE SPACES TO WFIM-V1PARAMRAMO */
            _.Move("", AREA_DE_WORK.WFIM_V1PARAMRAMO);

            /*" -786- PERFORM R0050-00-SELECT-V1PARAMRAMO */

            R0050_00_SELECT_V1PARAMRAMO_SECTION();

            /*" -787- IF WFIM-V1PARAMRAMO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PARAMRAMO.IsEmpty())
            {

                /*" -789- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -790- MOVE SPACES TO WFIM-V1SISTEMA */
            _.Move("", AREA_DE_WORK.WFIM_V1SISTEMA);

            /*" -791- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -792- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -794- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -795- MOVE SPACES TO WFIM-V1SOLICFAT */
            _.Move("", AREA_DE_WORK.WFIM_V1SOLICFAT);

            /*" -797- PERFORM R0900-00-DECLARE-V1SOLICFAT */

            R0900_00_DECLARE_V1SOLICFAT_SECTION();

            /*" -798- PERFORM R0910-00-FETCH-V1SOLICFAT */

            R0910_00_FETCH_V1SOLICFAT_SECTION();

            /*" -799- IF WFIM-V1SOLICFAT NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SOLICFAT.IsEmpty())
            {

                /*" -800- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -802- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -805- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1SOLICFAT NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1SOLICFAT.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -806- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -810- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -811- DISPLAY 'SOLICITACOES LIDAS       ' AC-L-V1SOLICFAT */
            _.Display($"SOLICITACOES LIDAS       {AREA_DE_WORK.AC_L_V1SOLICFAT}");

            /*" -812- DISPLAY 'DOCUMENTOS SELECIONADOS  ' */
            _.Display($"DOCUMENTOS SELECIONADOS  ");

            /*" -813- DISPLAY ' . SUBGRUPOS             ' AC-S-V1SUBGRUPO */
            _.Display($" . SUBGRUPOS             {AREA_DE_WORK.AC_S_V1SUBGRUPO}");

            /*" -814- DISPLAY ' . FATURAS               ' AC-S-V1FATURAS */
            _.Display($" . FATURAS               {AREA_DE_WORK.AC_S_V1FATURAS}");

            /*" -815- DISPLAY ' . FATURA ANTERIOR       ' AC-S-V1FATURANT */
            _.Display($" . FATURA ANTERIOR       {AREA_DE_WORK.AC_S_V1FATURANT}");

            /*" -816- DISPLAY ' . APOLICES              ' AC-S-V1APOLICE */
            _.Display($" . APOLICES              {AREA_DE_WORK.AC_S_V1APOLICE}");

            /*" -817- DISPLAY ' . FATURA TOTAL          ' AC-S-V1FATURTOT */
            _.Display($" . FATURA TOTAL          {AREA_DE_WORK.AC_S_V1FATURTOT}");

            /*" -818- DISPLAY ' . ENDOSSOS              ' AC-S-V1ENDOSSO */
            _.Display($" . ENDOSSOS              {AREA_DE_WORK.AC_S_V1ENDOSSO}");

            /*" -819- DISPLAY 'DOCUMENTOS DELETADOS     ' */
            _.Display($"DOCUMENTOS DELETADOS     ");

            /*" -820- DISPLAY ' . FATURAS               ' AC-D-V0FATURTOT */
            _.Display($" . FATURAS               {AREA_DE_WORK.AC_D_V0FATURTOT}");

            /*" -821- DISPLAY 'DOCUMENTOS ATUALIZADOS   ' */
            _.Display($"DOCUMENTOS ATUALIZADOS   ");

            /*" -822- DISPLAY ' . FATURAS               ' AC-A-V0FATURAS */
            _.Display($" . FATURAS               {AREA_DE_WORK.AC_A_V0FATURAS}");

            /*" -823- DISPLAY ' . CONTROLE FATURAS      ' AC-A-V0FATURCONT */
            _.Display($" . CONTROLE FATURAS      {AREA_DE_WORK.AC_A_V0FATURCONT}");

            /*" -823- DISPLAY ' . SOLICITACAO FATURAS   ' AC-A-V0SOLICFAT. */
            _.Display($" . SOLICITACAO FATURAS   {AREA_DE_WORK.AC_A_V0SOLICFAT}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -829- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -829- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECT-V1PARAMRAMO-SECTION */
        private void R0050_00_SELECT_V1PARAMRAMO_SECTION()
        {
            /*" -843- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -848- PERFORM R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1 */

            R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1();

            /*" -851- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -852- DISPLAY 'VG0105B - V1PARAMRAMO' */
                _.Display($"VG0105B - V1PARAMRAMO");

                /*" -852- MOVE 'S' TO WFIM-V1PARAMRAMO. */
                _.Move("S", AREA_DE_WORK.WFIM_V1PARAMRAMO);
            }


        }

        [StopWatch]
        /*" R0050-00-SELECT-V1PARAMRAMO-DB-SELECT-1 */
        public void R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -848- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC INTO :V1PRAMO-RAMO-VG, :V1PRAMO-RAMO-AP, :V1PRAMO-RAMO-VGAP FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var r0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 = new R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(r0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PRAMO_RAMO_VG, V1PRAMO_RAMO_VG);
                _.Move(executed_1.V1PRAMO_RAMO_AP, V1PRAMO_RAMO_AP);
                _.Move(executed_1.V1PRAMO_RAMO_VGAP, V1PRAMO_RAMO_VGAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-LEITURA-V1TERMOADESAO-SECTION */
        private void R0060_00_LEITURA_V1TERMOADESAO_SECTION()
        {
            /*" -864- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -885- PERFORM R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1 */

            R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1();

            /*" -888- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -889- MOVE 'N' TO WTEM-TERMO-ADESAO */
                _.Move("N", AREA_DE_WORK.WTEM_TERMO_ADESAO);

                /*" -890- ELSE */
            }
            else
            {


                /*" -891- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -892- DISPLAY 'ERRO NO SELECT DO V1TERMOADESAO.......' */
                    _.Display($"ERRO NO SELECT DO V1TERMOADESAO.......");

                    /*" -893- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -894- ELSE */
                }
                else
                {


                    /*" -894- MOVE 'S' TO WTEM-TERMO-ADESAO. */
                    _.Move("S", AREA_DE_WORK.WTEM_TERMO_ADESAO);
                }

            }


        }

        [StopWatch]
        /*" R0060-00-LEITURA-V1TERMOADESAO-DB-SELECT-1 */
        public void R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1()
        {
            /*" -885- EXEC SQL SELECT NUM_TERMO, COD_SUBGRUPO, DATA_ADESAO, PERI_PAGAMENTO, MODALIDADE_CAPITAL INTO :NUM-TERMO, :COD-SUBGRUPO, :DATA-ADESAO, :PERI-PAGTO, :MODALIDADE-CAPITAL FROM SEGUROS.V1TERMOADESAO WHERE COD_SUBGRUPO = :V1SOLF-COD-SUBG AND NUM_APOLICE = :V1SOLF-NUM-APOL AND SITUACAO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1 = new R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1()
            {
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1.Execute(r0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_TERMO, NUM_TERMO);
                _.Move(executed_1.COD_SUBGRUPO, COD_SUBGRUPO);
                _.Move(executed_1.DATA_ADESAO, DATA_ADESAO);
                _.Move(executed_1.PERI_PAGTO, PERI_PAGTO);
                _.Move(executed_1.MODALIDADE_CAPITAL, MODALIDADE_CAPITAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -908- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -913- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -916- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -917- DISPLAY 'VG0105B - SISTEMA  -- V G -- NAO CADASTRADO' */
                _.Display($"VG0105B - SISTEMA  -- V G -- NAO CADASTRADO");

                /*" -917- MOVE 'S' TO WFIM-V1SISTEMA. */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -913- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

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
        /*" R0900-00-DECLARE-V1SOLICFAT-SECTION */
        private void R0900_00_DECLARE_V1SOLICFAT_SECTION()
        {
            /*" -931- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -949- PERFORM R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1 */

            R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1();

            /*" -951- PERFORM R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1 */

            R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1SOLICFAT-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1()
        {
            /*" -949- EXEC SQL DECLARE V1SOLICFAT CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , NUM_RCAP , VAL_RCAP , COD_OPERACAO , SIT_REGISTRO , DATA_RCAP , DATA_VENCIMENTO , DATA_SOLICITACAO , COD_USUARIO FROM SEGUROS.V1SOLICITAFAT WHERE SIT_REGISTRO = '3' AND COD_OPERACAO = 0100 ORDER BY NUM_APOLICE, COD_SUBGRUPO, NUM_FATURA END-EXEC. */
            V1SOLICFAT = new VG0105B_V1SOLICFAT(false);
            string GetQuery_V1SOLICFAT()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_FATURA
							, 
							NUM_RCAP
							, 
							VAL_RCAP
							, 
							COD_OPERACAO
							, 
							SIT_REGISTRO
							, 
							DATA_RCAP
							, 
							DATA_VENCIMENTO
							, 
							DATA_SOLICITACAO
							, 
							COD_USUARIO 
							FROM SEGUROS.V1SOLICITAFAT 
							WHERE SIT_REGISTRO = '3' 
							AND COD_OPERACAO = 0100 
							ORDER BY NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_FATURA";

                return query;
            }
            V1SOLICFAT.GetQueryEvent += GetQuery_V1SOLICFAT;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1SOLICFAT-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1()
        {
            /*" -951- EXEC SQL OPEN V1SOLICFAT END-EXEC. */

            V1SOLICFAT.Open();

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-DECLARE-1 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1()
        {
            /*" -1325- EXEC SQL DECLARE V1FATTOT CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_FATURA, COD_OPERACAO, QTD_VIDAS_VG, QTD_VIDAS_AP, IMP_MORNATU, IMP_MORACID, IMP_INVPERM, IMP_AMDS, IMP_DH, IMP_DIT, PRM_VG, PRM_AP, SIT_REGISTRO, COD_EMPRESA FROM SEGUROS.V1FATURASTOT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA <= :W2SOLF-NUM-FAT AND COD_OPERACAO = 1800 ORDER BY NUM_FATURA DESC END-EXEC. */
            V1FATTOT = new VG0105B_V1FATTOT(true);
            string GetQuery_V1FATTOT()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_FATURA
							, 
							COD_OPERACAO
							, 
							QTD_VIDAS_VG
							, 
							QTD_VIDAS_AP
							, 
							IMP_MORNATU
							, 
							IMP_MORACID
							, 
							IMP_INVPERM
							, 
							IMP_AMDS
							, 
							IMP_DH
							, 
							IMP_DIT
							, 
							PRM_VG
							, 
							PRM_AP
							, 
							SIT_REGISTRO
							, 
							COD_EMPRESA 
							FROM SEGUROS.V1FATURASTOT 
							WHERE NUM_APOLICE = '{W1SOLF_NUM_APOL}' 
							AND COD_SUBGRUPO = '{W1SOLF_COD_SUBG}' 
							AND NUM_FATURA <= '{W2SOLF_NUM_FAT}' 
							AND COD_OPERACAO = 1800 
							ORDER BY NUM_FATURA DESC";

                return query;
            }
            V1FATTOT.GetQueryEvent += GetQuery_V1FATTOT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-SECTION */
        private void R0910_00_FETCH_V1SOLICFAT_SECTION()
        {
            /*" -965- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -977- PERFORM R0910_00_FETCH_V1SOLICFAT_DB_FETCH_1 */

            R0910_00_FETCH_V1SOLICFAT_DB_FETCH_1();

            /*" -980- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -981- MOVE 'S' TO WFIM-V1SOLICFAT */
                _.Move("S", AREA_DE_WORK.WFIM_V1SOLICFAT);

                /*" -981- PERFORM R0910_00_FETCH_V1SOLICFAT_DB_CLOSE_1 */

                R0910_00_FETCH_V1SOLICFAT_DB_CLOSE_1();

                /*" -984- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -986- MOVE V1SOLF-COD-OPER TO W1S-COD-OPER */
            _.Move(V1SOLF_COD_OPER, W1S_COD_OPER);

            /*" -986- ADD 1 TO AC-L-V1SOLICFAT. */
            AREA_DE_WORK.AC_L_V1SOLICFAT.Value = AREA_DE_WORK.AC_L_V1SOLICFAT + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-DB-FETCH-1 */
        public void R0910_00_FETCH_V1SOLICFAT_DB_FETCH_1()
        {
            /*" -977- EXEC SQL FETCH V1SOLICFAT INTO :V1SOLF-NUM-APOL, :V1SOLF-COD-SUBG, :V1SOLF-NUM-FAT, :V1SOLF-NUM-RCAP, :V1SOLF-VAL-RCAP, :V1SOLF-COD-OPER, :V1SOLF-SIT-REG, :V1SOLF-DATA-RCAP:V1SOLF-DATA-RCAP-I, :V1SOLF-DATA-VENC:V1SOLF-DATA-VENC-I, :V1SOLF-DATA-SOLI:V1SOLF-DATA-SOLI-I, :V1SOLF-COD-USUAR END-EXEC. */

            if (V1SOLICFAT.Fetch())
            {
                _.Move(V1SOLICFAT.V1SOLF_NUM_APOL, V1SOLF_NUM_APOL);
                _.Move(V1SOLICFAT.V1SOLF_COD_SUBG, V1SOLF_COD_SUBG);
                _.Move(V1SOLICFAT.V1SOLF_NUM_FAT, V1SOLF_NUM_FAT);
                _.Move(V1SOLICFAT.V1SOLF_NUM_RCAP, V1SOLF_NUM_RCAP);
                _.Move(V1SOLICFAT.V1SOLF_VAL_RCAP, V1SOLF_VAL_RCAP);
                _.Move(V1SOLICFAT.V1SOLF_COD_OPER, V1SOLF_COD_OPER);
                _.Move(V1SOLICFAT.V1SOLF_SIT_REG, V1SOLF_SIT_REG);
                _.Move(V1SOLICFAT.V1SOLF_DATA_RCAP, V1SOLF_DATA_RCAP);
                _.Move(V1SOLICFAT.V1SOLF_DATA_RCAP_I, V1SOLF_DATA_RCAP_I);
                _.Move(V1SOLICFAT.V1SOLF_DATA_VENC, V1SOLF_DATA_VENC);
                _.Move(V1SOLICFAT.V1SOLF_DATA_VENC_I, V1SOLF_DATA_VENC_I);
                _.Move(V1SOLICFAT.V1SOLF_DATA_SOLI, V1SOLF_DATA_SOLI);
                _.Move(V1SOLICFAT.V1SOLF_DATA_SOLI_I, V1SOLF_DATA_SOLI_I);
                _.Move(V1SOLICFAT.V1SOLF_COD_USUAR, V1SOLF_COD_USUAR);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1SOLICFAT_DB_CLOSE_1()
        {
            /*" -981- EXEC SQL CLOSE V1SOLICFAT END-EXEC */

            V1SOLICFAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1000- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1001- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA1 */
            _.Move(V1SOLF_NUM_FAT, AREA_DE_WORK.WNUM_FATURA1);

            /*" -1002- MOVE WFAT-ANO1 TO W1ANO-FAT */
            _.Move(AREA_DE_WORK.FILLER_20.WFAT_ANO1, AREA_DE_WORK.W1MOVI_NUM_FAT.W1ANO_FAT);

            /*" -1004- MOVE WFAT-MES1 TO W1MES-FAT */
            _.Move(AREA_DE_WORK.FILLER_20.WFAT_MES1, AREA_DE_WORK.W1MOVI_NUM_FAT.W1MES_FAT);

            /*" -1005- PERFORM R1600-00-SELECT-V1APOLICE */

            R1600_00_SELECT_V1APOLICE_SECTION();

            /*" -1011- PERFORM R1100-00-SELECT-V1SUBGRUPO */

            R1100_00_SELECT_V1SUBGRUPO_SECTION();

            /*" -1012- IF V1SOLF-NUM-APOL EQUAL 97010000889 */

            if (V1SOLF_NUM_APOL == 97010000889)
            {

                /*" -1013- PERFORM R0060-00-LEITURA-V1TERMOADESAO */

                R0060_00_LEITURA_V1TERMOADESAO_SECTION();

                /*" -1014- ELSE */
            }
            else
            {


                /*" -1016- MOVE 'N' TO WTEM-TERMO-ADESAO. */
                _.Move("N", AREA_DE_WORK.WTEM_TERMO_ADESAO);
            }


            /*" -1018- IF V1SUBG-TIPO-FAT EQUAL '1' OR V1SUBG-TIPO-FAT EQUAL '3' */

            if (V1SUBG_TIPO_FAT == "1" || V1SUBG_TIPO_FAT == "3")
            {

                /*" -1019- PERFORM R2330-00-SELECT-V1FATURCONT */

                R2330_00_SELECT_V1FATURCONT_SECTION();

                /*" -1020- ELSE */
            }
            else
            {


                /*" -1022- PERFORM R2315-00-SELECT-V1FATURCONT. */

                R2315_00_SELECT_V1FATURCONT_SECTION();
            }


            /*" -1023- MOVE V1FATC-DATA-REFER TO WDATA-REFERENCIA. */
            _.Move(V1FATC_DATA_REFER, AREA_DE_WORK.WDATA_REFERENCIA);

            /*" -1024- MOVE WREF-DIA TO W1DIA-FAT. */
            _.Move(AREA_DE_WORK.FILLER_26.WREF_DIA, AREA_DE_WORK.W1MOVI_NUM_FAT.W1DIA_FAT);

            /*" -1027- MOVE W1MOVI-NUM-FAT TO V1FATC-DATA-REFER */
            _.Move(AREA_DE_WORK.W1MOVI_NUM_FAT, V1FATC_DATA_REFER);

            /*" -1028- IF V1SOLF-COD-OPER EQUAL 300 */

            if (V1SOLF_COD_OPER == 300)
            {

                /*" -1029- PERFORM R3500-00-SELECT-V1FATURAS */

                R3500_00_SELECT_V1FATURAS_SECTION();

                /*" -1030- MOVE V1FATR-DATA-INIVIG TO WDATA-INIVIG */
                _.Move(V1FATR_DATA_INIVIG, AREA_DE_WORK.WDATA_INIVIG);

                /*" -1031- MOVE V1FATR-DATA-TERVIG TO WDATA-TERVIG */
                _.Move(V1FATR_DATA_TERVIG, AREA_DE_WORK.WDATA_TERVIG);

                /*" -1032- ELSE */
            }
            else
            {


                /*" -1034- PERFORM R2310-00-DETERMINA-VIGENCIA. */

                R2310_00_DETERMINA_VIGENCIA_SECTION();
            }


            /*" -1035- MOVE V1SUBG-DTTERVIG TO WS-DTRENOVA */
            _.Move(V1SUBG_DTTERVIG, AREA_DE_WORK.WS_DTRENOVA);

            /*" -1036- MOVE WDATA-INIVIG TO WS-DTFATUR */
            _.Move(AREA_DE_WORK.WDATA_INIVIG, AREA_DE_WORK.WS_DTFATUR);

            /*" -1038- PERFORM R1005-00-CALCULA-DTINIVIG. */

            R1005_00_CALCULA_DTINIVIG_SECTION();

            /*" -1040- MOVE WS-DTBASE TO V1RIND-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DTBASE, V1RIND_DTINIVIG);

            /*" -1042- PERFORM R1900-00-SELECT-V1RAMOIND */

            R1900_00_SELECT_V1RAMOIND_SECTION();

            /*" -1043- IF V1SOLF-COD-SUBG NOT EQUAL ZEROS */

            if (V1SOLF_COD_SUBG != 00)
            {

                /*" -1044- PERFORM R2000-00-FATURA */

                R2000_00_FATURA_SECTION();

                /*" -1045- ELSE */
            }
            else
            {


                /*" -1046- MOVE SPACES TO WFIM-V1SUBGRUPO */
                _.Move("", AREA_DE_WORK.WFIM_V1SUBGRUPO);

                /*" -1047- IF V1SUBG-TIPO-FAT EQUAL '2' OR '3' */

                if (V1SUBG_TIPO_FAT.In("2", "3"))
                {

                    /*" -1048- PERFORM R3000-00-FATURA-SUBG-RESUMO */

                    R3000_00_FATURA_SUBG_RESUMO_SECTION();

                    /*" -1049- ELSE */
                }
                else
                {


                    /*" -1051- PERFORM R2000-00-FATURA. */

                    R2000_00_FATURA_SECTION();
                }

            }


            /*" -1052- IF WFLAG-SOLICITA EQUAL '0' */

            if (WFLAG_SOLICITA == "0")
            {

                /*" -1053- PERFORM R5300-00-UPDATE-V0SOLICFAT */

                R5300_00_UPDATE_V0SOLICFAT_SECTION();

                /*" -1054- ELSE */
            }
            else
            {


                /*" -1058- MOVE '0' TO WFLAG-SOLICITA. */
                _.Move("0", WFLAG_SOLICITA);
            }


            /*" -1058- PERFORM R0910-00-FETCH-V1SOLICFAT. */

            R0910_00_FETCH_V1SOLICFAT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1005-00-CALCULA-DTINIVIG-SECTION */
        private void R1005_00_CALCULA_DTINIVIG_SECTION()
        {
            /*" -1069- MOVE WS-DTRENOVA TO WS-DTBASE. */
            _.Move(AREA_DE_WORK.WS_DTRENOVA, AREA_DE_WORK.WS_DTBASE);

            /*" -1071- MOVE 01 TO WS-DIA. */
            _.Move(01, AREA_DE_WORK.WS_DIA);

            /*" -1072- IF WS-DTFATUR GREATER WS-DTBASE */

            if (AREA_DE_WORK.WS_DTFATUR > AREA_DE_WORK.WS_DTBASE)
            {

                /*" -1073- DISPLAY 'APOLICE.....: ' V1SOLF-NUM-APOL */
                _.Display($"APOLICE.....: {V1SOLF_NUM_APOL}");

                /*" -1074- DISPLAY 'SUBGRUPO....: ' V1SOLF-COD-SUBG */
                _.Display($"SUBGRUPO....: {V1SOLF_COD_SUBG}");

                /*" -1075- DISPLAY 'R1005-00 VIGENCIA/FATURA SUPERIOR A DO SEGURADO' */
                _.Display($"R1005-00 VIGENCIA/FATURA SUPERIOR A DO SEGURADO");

                /*" -1076- DISPLAY 'VIGENCIA DA FATURA .............' WS-DTFATUR */
                _.Display($"VIGENCIA DA FATURA .............{AREA_DE_WORK.WS_DTFATUR}");

                /*" -1077- DISPLAY 'TERMINO DE VIGENCIA DO SEGURADO.' WS-DTBASE */
                _.Display($"TERMINO DE VIGENCIA DO SEGURADO.{AREA_DE_WORK.WS_DTBASE}");

                /*" -1078- MOVE WS-DTFATUR TO WS-DTBASE */
                _.Move(AREA_DE_WORK.WS_DTFATUR, AREA_DE_WORK.WS_DTBASE);

                /*" -1078- GO TO R1005-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1005_10_DIMINUI_UM_ANO */

            R1005_10_DIMINUI_UM_ANO();

        }

        [StopWatch]
        /*" R1005-10-DIMINUI-UM-ANO */
        private void R1005_10_DIMINUI_UM_ANO(bool isPerform = false)
        {
            /*" -1083- COMPUTE WS-AABASE = WS-AABASE - 1 */
            AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE - 1;

            /*" -1085- COMPUTE WS-DDBASE = WS-DDBASE + WS-DIA */
            AREA_DE_WORK.WS_DTBASE.WS_DDBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DDBASE + AREA_DE_WORK.WS_DIA;

            /*" -1087- IF WS-MMBASE EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -1088- IF WS-DDBASE GREATER 31 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 31)
                {

                    /*" -1089- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1090- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1091- END-IF */
                }


                /*" -1093- END-IF */
            }


            /*" -1094- IF WS-MMBASE EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("04", "06", "09", "11"))
            {

                /*" -1095- IF WS-DDBASE GREATER 30 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 30)
                {

                    /*" -1096- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1097- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1098- END-IF */
                }


                /*" -1100- END-IF */
            }


            /*" -1101- IF WS-MMBASE EQUAL 02 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE == 02)
            {

                /*" -1102- IF WS-DDBASE GREATER 28 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 28)
                {

                    /*" -1103- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1104- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1105- END-IF */
                }


                /*" -1107- END-IF */
            }


            /*" -1108- IF WS-MMBASE GREATER 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE > 12)
            {

                /*" -1109- MOVE 01 TO WS-MMBASE */
                _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE);

                /*" -1110- COMPUTE WS-AABASE = WS-AABASE + 1 */
                AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE + 1;

                /*" -1112- END-IF */
            }


            /*" -1113- IF WS-DTFATUR-AM LESS WS-DTBASE-AM */

            if (AREA_DE_WORK.WS_DTFATUR.WS_DTFATUR_AM < AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM)
            {

                /*" -1114- MOVE ZEROS TO WS-DIA */
                _.Move(0, AREA_DE_WORK.WS_DIA);

                /*" -1114- GO TO R1005-10-DIMINUI-UM-ANO. */
                new Task(() => R1005_10_DIMINUI_UM_ANO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1SUBGRUPO-SECTION */
        private void R1100_00_SELECT_V1SUBGRUPO_SECTION()
        {
            /*" -1127- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1147- PERFORM R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1 */

            R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1();

            /*" -1150- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1153- DISPLAY 'NAO EXISTE SUBGRUPO PARA APOLICE ... ' V1SOLF-NUM-APOL V1SOLF-COD-SUBG */

                $"NAO EXISTE SUBGRUPO PARA APOLICE ... {V1SOLF_NUM_APOL}{V1SOLF_COD_SUBG}"
                .Display();

                /*" -1155- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1156- MOVE V1SUBG-TIPO-FAT TO W1S-TIPO-FAT */
            _.Move(V1SUBG_TIPO_FAT, W1S_TIPO_FAT);

            /*" -1157- MOVE V1SUBG-COD-FONTE TO W1S-COD-FONTE */
            _.Move(V1SUBG_COD_FONTE, W1S_COD_FONTE);

            /*" -1158- MOVE V1SUBG-COD-SUBG TO W1S-COD-SUBG */
            _.Move(V1SUBG_COD_SUBG, W1S_COD_SUBG);

            /*" -1159- MOVE V1SUBG-BCO-COB TO W1S-BCO-COB */
            _.Move(V1SUBG_BCO_COB, W1S_BCO_COB);

            /*" -1160- MOVE V1SUBG-AGE-COB TO W1S-AGE-COB */
            _.Move(V1SUBG_AGE_COB, W1S_AGE_COB);

            /*" -1161- MOVE V1SUBG-DAC-COB TO W1S-DAC-COB */
            _.Move(V1SUBG_DAC_COB, W1S_DAC_COB);

            /*" -1163- MOVE V1SUBG-END-COB TO W1S-END-COB */
            _.Move(V1SUBG_END_COB, W1S_END_COB);

            /*" -1163- ADD 1 TO AC-S-V1SUBGRUPO. */
            AREA_DE_WORK.AC_S_V1SUBGRUPO.Value = AREA_DE_WORK.AC_S_V1SUBGRUPO + 1;

        }

        [StopWatch]
        /*" R1100-00-SELECT-V1SUBGRUPO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -1147- EXEC SQL SELECT TIPO_FATURAMENTO , COD_FONTE , COD_SUBGRUPO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , DTTERVIG INTO :V1SUBG-TIPO-FAT , :V1SUBG-COD-FONTE , :V1SUBG-COD-SUBG , :V1SUBG-END-COB , :V1SUBG-BCO-COB , :V1SUBG-AGE-COB , :V1SUBG-DAC-COB , :V1SUBG-DTTERVIG FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG END-EXEC. */

            var r1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SUBG_TIPO_FAT, V1SUBG_TIPO_FAT);
                _.Move(executed_1.V1SUBG_COD_FONTE, V1SUBG_COD_FONTE);
                _.Move(executed_1.V1SUBG_COD_SUBG, V1SUBG_COD_SUBG);
                _.Move(executed_1.V1SUBG_END_COB, V1SUBG_END_COB);
                _.Move(executed_1.V1SUBG_BCO_COB, V1SUBG_BCO_COB);
                _.Move(executed_1.V1SUBG_AGE_COB, V1SUBG_AGE_COB);
                _.Move(executed_1.V1SUBG_DAC_COB, V1SUBG_DAC_COB);
                _.Move(executed_1.V1SUBG_DTTERVIG, V1SUBG_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1FATURA-SECTION */
        private void R1200_00_SELECT_V1FATURA_SECTION()
        {
            /*" -1177- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1216- PERFORM R1200_00_SELECT_V1FATURA_DB_SELECT_1 */

            R1200_00_SELECT_V1FATURA_DB_SELECT_1();

            /*" -1219- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1220- MOVE '*' TO WFIM-V1FATURAS */
                _.Move("*", AREA_DE_WORK.WFIM_V1FATURAS);

                /*" -1222- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1222- ADD 1 TO AC-S-V1FATURAS. */
            AREA_DE_WORK.AC_S_V1FATURAS.Value = AREA_DE_WORK.AC_S_V1FATURAS + 1;

        }

        [StopWatch]
        /*" R1200-00-SELECT-V1FATURA-DB-SELECT-1 */
        public void R1200_00_SELECT_V1FATURA_DB_SELECT_1()
        {
            /*" -1216- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , TIPO_ENDOSSO , NUM_ENDOSSO , VAL_FATURA , COD_FONTE , NUM_RCAP , VAL_RCAP , DATA_INIVIGENCIA , DATA_TERVIGENCIA , SIT_REGISTRO , DATA_FATURA , DATA_RCAP , COD_EMPRESA , DATA_VENCIMENTO INTO :V1FATR-NUM-APOL , :V1FATR-COD-SUBG , :V1FATR-NUM-FATUR , :V1FATR-COD-OPER , :V1FATR-TIPO-ENDOS , :V1FATR-NUM-ENDOS , :V1FATR-VAL-FATURA , :V1FATR-COD-FONTE , :V1FATR-NUM-RCAP , :V1FATR-VAL-RCAP , :V1FATR-DATA-INIVIG , :V1FATR-DATA-TERVIG , :V1FATR-SIT-REG , :V1FATR-DATA-FATUR:V1FATR-DATA-FATU-I, :V1FATR-DATA-RCAP:V1FATR-DATA-RCAP-I, :V1FATR-COD-EMPRESA:VIND-COD-EMP, :V1FATR-DATA-VENC:V1FATR-DATA-VENC-I FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

            var r1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
                W1SOLF_NUM_FAT = W1SOLF_NUM_FAT.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_NUM_APOL, V1FATR_NUM_APOL);
                _.Move(executed_1.V1FATR_COD_SUBG, V1FATR_COD_SUBG);
                _.Move(executed_1.V1FATR_NUM_FATUR, V1FATR_NUM_FATUR);
                _.Move(executed_1.V1FATR_COD_OPER, V1FATR_COD_OPER);
                _.Move(executed_1.V1FATR_TIPO_ENDOS, V1FATR_TIPO_ENDOS);
                _.Move(executed_1.V1FATR_NUM_ENDOS, V1FATR_NUM_ENDOS);
                _.Move(executed_1.V1FATR_VAL_FATURA, V1FATR_VAL_FATURA);
                _.Move(executed_1.V1FATR_COD_FONTE, V1FATR_COD_FONTE);
                _.Move(executed_1.V1FATR_NUM_RCAP, V1FATR_NUM_RCAP);
                _.Move(executed_1.V1FATR_VAL_RCAP, V1FATR_VAL_RCAP);
                _.Move(executed_1.V1FATR_DATA_INIVIG, V1FATR_DATA_INIVIG);
                _.Move(executed_1.V1FATR_DATA_TERVIG, V1FATR_DATA_TERVIG);
                _.Move(executed_1.V1FATR_SIT_REG, V1FATR_SIT_REG);
                _.Move(executed_1.V1FATR_DATA_FATUR, V1FATR_DATA_FATUR);
                _.Move(executed_1.V1FATR_DATA_FATU_I, V1FATR_DATA_FATU_I);
                _.Move(executed_1.V1FATR_DATA_RCAP, V1FATR_DATA_RCAP);
                _.Move(executed_1.V1FATR_DATA_RCAP_I, V1FATR_DATA_RCAP_I);
                _.Move(executed_1.V1FATR_COD_EMPRESA, V1FATR_COD_EMPRESA);
                _.Move(executed_1.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(executed_1.V1FATR_DATA_VENC, V1FATR_DATA_VENC);
                _.Move(executed_1.V1FATR_DATA_VENC_I, V1FATR_DATA_VENC_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1280-00-SELECT-V1FATURA-ANT-SECTION */
        private void R1280_00_SELECT_V1FATURA_ANT_SECTION()
        {
            /*" -1236- MOVE '128' TO WNR-EXEC-SQL. */
            _.Move("128", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1275- PERFORM R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1 */

            R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1();

            /*" -1278- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1279- MOVE '*' TO WFIM-FATURA-ANT */
                _.Move("*", AREA_DE_WORK.WFIM_FATURA_ANT);

                /*" -1279- GO TO R1280-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1280-00-SELECT-V1FATURA-ANT-DB-SELECT-1 */
        public void R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1()
        {
            /*" -1275- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , TIPO_ENDOSSO , NUM_ENDOSSO , VAL_FATURA , COD_FONTE , NUM_RCAP , VAL_RCAP , DATA_INIVIGENCIA , DATA_TERVIGENCIA , SIT_REGISTRO , DATA_FATURA , DATA_RCAP , COD_EMPRESA , DATA_VENCIMENTO INTO :V1FATR-NUM-APOL , :V1FATR-COD-SUBG , :V1FATR-NUM-FATUR , :V1FATR-COD-OPER , :V1FATR-TIPO-ENDOS , :V1FATR-NUM-ENDOS , :V1FATR-VAL-FATURA , :V1FATR-COD-FONTE , :V1FATR-NUM-RCAP , :V1FATR-VAL-RCAP , :V1FATR-DATA-INIVIG , :V1FATR-DATA-TERVIG , :V1FATR-SIT-REG , :V1FATR-DATA-FATUR:V1FATR-DATA-FATU-I, :V1FATR-DATA-RCAP:V1FATR-DATA-RCAP-I, :V1FATR-COD-EMPRESA:VIND-COD-EMP, :V1FATR-DATA-VENC:V1FATR-DATA-VENC-I FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = 0 AND NUM_FATURA = :W2SOLF-NUM-FAT END-EXEC. */

            var r1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1 = new R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W2SOLF_NUM_FAT = W2SOLF_NUM_FAT.ToString(),
            };

            var executed_1 = R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1.Execute(r1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_NUM_APOL, V1FATR_NUM_APOL);
                _.Move(executed_1.V1FATR_COD_SUBG, V1FATR_COD_SUBG);
                _.Move(executed_1.V1FATR_NUM_FATUR, V1FATR_NUM_FATUR);
                _.Move(executed_1.V1FATR_COD_OPER, V1FATR_COD_OPER);
                _.Move(executed_1.V1FATR_TIPO_ENDOS, V1FATR_TIPO_ENDOS);
                _.Move(executed_1.V1FATR_NUM_ENDOS, V1FATR_NUM_ENDOS);
                _.Move(executed_1.V1FATR_VAL_FATURA, V1FATR_VAL_FATURA);
                _.Move(executed_1.V1FATR_COD_FONTE, V1FATR_COD_FONTE);
                _.Move(executed_1.V1FATR_NUM_RCAP, V1FATR_NUM_RCAP);
                _.Move(executed_1.V1FATR_VAL_RCAP, V1FATR_VAL_RCAP);
                _.Move(executed_1.V1FATR_DATA_INIVIG, V1FATR_DATA_INIVIG);
                _.Move(executed_1.V1FATR_DATA_TERVIG, V1FATR_DATA_TERVIG);
                _.Move(executed_1.V1FATR_SIT_REG, V1FATR_SIT_REG);
                _.Move(executed_1.V1FATR_DATA_FATUR, V1FATR_DATA_FATUR);
                _.Move(executed_1.V1FATR_DATA_FATU_I, V1FATR_DATA_FATU_I);
                _.Move(executed_1.V1FATR_DATA_RCAP, V1FATR_DATA_RCAP);
                _.Move(executed_1.V1FATR_DATA_RCAP_I, V1FATR_DATA_RCAP_I);
                _.Move(executed_1.V1FATR_COD_EMPRESA, V1FATR_COD_EMPRESA);
                _.Move(executed_1.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(executed_1.V1FATR_DATA_VENC, V1FATR_DATA_VENC);
                _.Move(executed_1.V1FATR_DATA_VENC_I, V1FATR_DATA_VENC_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-SECTION */
        private void R1300_00_SELECT_V1FATTOT_ANT_SECTION()
        {
            /*" -1293- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1294- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA */
            _.Move(V1SOLF_NUM_FAT, AREA_DE_WORK.WNUM_FATURA);

            /*" -1295- IF WFAT-MES EQUAL 01 */

            if (AREA_DE_WORK.FILLER_19.WFAT_MES == 01)
            {

                /*" -1296- MOVE 12 TO WFAT-MES */
                _.Move(12, AREA_DE_WORK.FILLER_19.WFAT_MES);

                /*" -1297- SUBTRACT 1 FROM WFAT-ANO */
                AREA_DE_WORK.FILLER_19.WFAT_ANO.Value = AREA_DE_WORK.FILLER_19.WFAT_ANO - 1;

                /*" -1298- ELSE */
            }
            else
            {


                /*" -1300- SUBTRACT 1 FROM WFAT-MES. */
                AREA_DE_WORK.FILLER_19.WFAT_MES.Value = AREA_DE_WORK.FILLER_19.WFAT_MES - 1;
            }


            /*" -1302- MOVE WNUM-FATURA TO W2SOLF-NUM-FAT */
            _.Move(AREA_DE_WORK.WNUM_FATURA, W2SOLF_NUM_FAT);

            /*" -1325- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1 */

            R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1();

            /*" -1327- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1 */

            R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1();

            /*" -1329- PERFORM R1310-00-SELECT-V1FATTOT-ANT. */

            R1310_00_SELECT_V1FATTOT_ANT_SECTION();

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-OPEN-1 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1()
        {
            /*" -1327- EXEC SQL OPEN V1FATTOT END-EXEC. */

            V1FATTOT.Open();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1SUBGR-DB-DECLARE-1 */
        public void R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1()
        {
            /*" -1394- EXEC SQL DECLARE V1SUBGRUPO CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , OCORR_END_COBRAN FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO > 0 AND SIT_REGISTRO = '0' END-EXEC. */
            V1SUBGRUPO = new VG0105B_V1SUBGRUPO(true);
            string GetQuery_V1SUBGRUPO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							BCO_COBRANCA
							, 
							AGE_COBRANCA
							, 
							DAC_COBRANCA
							, 
							OCORR_END_COBRAN 
							FROM SEGUROS.V1SUBGRUPO 
							WHERE NUM_APOLICE = '{V1SOLF_NUM_APOL}' 
							AND COD_SUBGRUPO > 0 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            V1SUBGRUPO.GetQueryEvent += GetQuery_V1SUBGRUPO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-SELECT-V1FATTOT-ANT-SECTION */
        private void R1310_00_SELECT_V1FATTOT_ANT_SECTION()
        {
            /*" -1343- MOVE '131' TO WNR-EXEC-SQL. */
            _.Move("131", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1360- PERFORM R1310_00_SELECT_V1FATTOT_ANT_DB_FETCH_1 */

            R1310_00_SELECT_V1FATTOT_ANT_DB_FETCH_1();

            /*" -1363- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1365- MOVE '*' TO WFIM-V1FATURANT. */
                _.Move("*", AREA_DE_WORK.WFIM_V1FATURANT);
            }


            /*" -1365- PERFORM R1310_00_SELECT_V1FATTOT_ANT_DB_CLOSE_1 */

            R1310_00_SELECT_V1FATTOT_ANT_DB_CLOSE_1();

            /*" -1367- ADD 1 TO AC-S-V1FATURANT. */
            AREA_DE_WORK.AC_S_V1FATURANT.Value = AREA_DE_WORK.AC_S_V1FATURANT + 1;

        }

        [StopWatch]
        /*" R1310-00-SELECT-V1FATTOT-ANT-DB-FETCH-1 */
        public void R1310_00_SELECT_V1FATTOT_ANT_DB_FETCH_1()
        {
            /*" -1360- EXEC SQL FETCH V1FATTOT INTO :V1FATT-NUM-APOL, :V1FATT-COD-SUBG, :V1FATT-NUM-FATUR, :V1FATT-COD-OPER, :V1FATT-QT-VIDA-VG, :V1FATT-QT-VIDA-AP, :V1FATT-IMP-MORNAT, :V1FATT-IMP-MORACI, :V1FATT-IMP-INVPER, :V1FATT-IMP-AMDS, :V1FATT-IMP-DH, :V1FATT-IMP-DIT, :V1FATT-PRM-VG, :V1FATT-PRM-AP, :V1FATT-SIT-REG, :V1FATT-COD-EMPRESA:VIND-COD-EMP END-EXEC. */

            if (V1FATTOT.Fetch())
            {
                _.Move(V1FATTOT.V1FATT_NUM_APOL, V1FATT_NUM_APOL);
                _.Move(V1FATTOT.V1FATT_COD_SUBG, V1FATT_COD_SUBG);
                _.Move(V1FATTOT.V1FATT_NUM_FATUR, V1FATT_NUM_FATUR);
                _.Move(V1FATTOT.V1FATT_COD_OPER, V1FATT_COD_OPER);
                _.Move(V1FATTOT.V1FATT_QT_VIDA_VG, V1FATT_QT_VIDA_VG);
                _.Move(V1FATTOT.V1FATT_QT_VIDA_AP, V1FATT_QT_VIDA_AP);
                _.Move(V1FATTOT.V1FATT_IMP_MORNAT, V1FATT_IMP_MORNAT);
                _.Move(V1FATTOT.V1FATT_IMP_MORACI, V1FATT_IMP_MORACI);
                _.Move(V1FATTOT.V1FATT_IMP_INVPER, V1FATT_IMP_INVPER);
                _.Move(V1FATTOT.V1FATT_IMP_AMDS, V1FATT_IMP_AMDS);
                _.Move(V1FATTOT.V1FATT_IMP_DH, V1FATT_IMP_DH);
                _.Move(V1FATTOT.V1FATT_IMP_DIT, V1FATT_IMP_DIT);
                _.Move(V1FATTOT.V1FATT_PRM_VG, V1FATT_PRM_VG);
                _.Move(V1FATTOT.V1FATT_PRM_AP, V1FATT_PRM_AP);
                _.Move(V1FATTOT.V1FATT_SIT_REG, V1FATT_SIT_REG);
                _.Move(V1FATTOT.V1FATT_COD_EMPRESA, V1FATT_COD_EMPRESA);
                _.Move(V1FATTOT.VIND_COD_EMP, VIND_COD_EMP);
            }

        }

        [StopWatch]
        /*" R1310-00-SELECT-V1FATTOT-ANT-DB-CLOSE-1 */
        public void R1310_00_SELECT_V1FATTOT_ANT_DB_CLOSE_1()
        {
            /*" -1365- EXEC SQL CLOSE V1FATTOT END-EXEC. */

            V1FATTOT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-DECLARE-V1SUBGR-SECTION */
        private void R1500_00_DECLARE_V1SUBGR_SECTION()
        {
            /*" -1382- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1394- PERFORM R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1 */

            R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1();

            /*" -1396- PERFORM R1500_00_DECLARE_V1SUBGR_DB_OPEN_1 */

            R1500_00_DECLARE_V1SUBGR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1SUBGR-DB-OPEN-1 */
        public void R1500_00_DECLARE_V1SUBGR_DB_OPEN_1()
        {
            /*" -1396- EXEC SQL OPEN V1SUBGRUPO END-EXEC. */

            V1SUBGRUPO.Open();

        }

        [StopWatch]
        /*" R1700-00-ACESSA-TOTAIS-DB-DECLARE-1 */
        public void R1700_00_ACESSA_TOTAIS_DB_DECLARE_1()
        {
            /*" -1490- EXEC SQL DECLARE V1FATURTOT1 CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , QTD_VIDAS_VG , QTD_VIDAS_AP , IMP_MORNATU , IMP_MORACID , IMP_INVPERM , IMP_AMDS , IMP_DH , IMP_DIT , PRM_VG , PRM_AP , SIT_REGISTRO , COD_EMPRESA FROM SEGUROS.V1FATURASTOT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */
            V1FATURTOT1 = new VG0105B_V1FATURTOT1(true);
            string GetQuery_V1FATURTOT1()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_FATURA
							, 
							COD_OPERACAO
							, 
							QTD_VIDAS_VG
							, 
							QTD_VIDAS_AP
							, 
							IMP_MORNATU
							, 
							IMP_MORACID
							, 
							IMP_INVPERM
							, 
							IMP_AMDS
							, 
							IMP_DH
							, 
							IMP_DIT
							, 
							PRM_VG
							, 
							PRM_AP
							, 
							SIT_REGISTRO
							, 
							COD_EMPRESA 
							FROM SEGUROS.V1FATURASTOT 
							WHERE NUM_APOLICE = '{W1SOLF_NUM_APOL}' 
							AND COD_SUBGRUPO = '{W1SOLF_COD_SUBG}' 
							AND NUM_FATURA = '{W1SOLF_NUM_FAT}'";

                return query;
            }
            V1FATURTOT1.GetQueryEvent += GetQuery_V1FATURTOT1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-FETCH-V1SUBGR-SECTION */
        private void R1510_00_FETCH_V1SUBGR_SECTION()
        {
            /*" -1410- MOVE '151' TO WNR-EXEC-SQL. */
            _.Move("151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1418- PERFORM R1510_00_FETCH_V1SUBGR_DB_FETCH_1 */

            R1510_00_FETCH_V1SUBGR_DB_FETCH_1();

            /*" -1421- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1422- MOVE 'S' TO WFIM-V1SUBGRUPO */
                _.Move("S", AREA_DE_WORK.WFIM_V1SUBGRUPO);

                /*" -1422- PERFORM R1510_00_FETCH_V1SUBGR_DB_CLOSE_1 */

                R1510_00_FETCH_V1SUBGR_DB_CLOSE_1();

                /*" -1425- GO TO R1510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1425- ADD 1 TO AC-S-V1SUBGRUPO. */
            AREA_DE_WORK.AC_S_V1SUBGRUPO.Value = AREA_DE_WORK.AC_S_V1SUBGRUPO + 1;

        }

        [StopWatch]
        /*" R1510-00-FETCH-V1SUBGR-DB-FETCH-1 */
        public void R1510_00_FETCH_V1SUBGR_DB_FETCH_1()
        {
            /*" -1418- EXEC SQL FETCH V1SUBGRUPO INTO :V1SUBG-NUM-APOL , :V1SUBG-COD-SUBG , :V1SUBG-COD-FONTE , :V1SUBG-BCO-COB , :V1SUBG-AGE-COB , :V1SUBG-DAC-COB , :V1SUBG-END-COB END-EXEC. */

            if (V1SUBGRUPO.Fetch())
            {
                _.Move(V1SUBGRUPO.V1SUBG_NUM_APOL, V1SUBG_NUM_APOL);
                _.Move(V1SUBGRUPO.V1SUBG_COD_SUBG, V1SUBG_COD_SUBG);
                _.Move(V1SUBGRUPO.V1SUBG_COD_FONTE, V1SUBG_COD_FONTE);
                _.Move(V1SUBGRUPO.V1SUBG_BCO_COB, V1SUBG_BCO_COB);
                _.Move(V1SUBGRUPO.V1SUBG_AGE_COB, V1SUBG_AGE_COB);
                _.Move(V1SUBGRUPO.V1SUBG_DAC_COB, V1SUBG_DAC_COB);
                _.Move(V1SUBGRUPO.V1SUBG_END_COB, V1SUBG_END_COB);
            }

        }

        [StopWatch]
        /*" R1510-00-FETCH-V1SUBGR-DB-CLOSE-1 */
        public void R1510_00_FETCH_V1SUBGR_DB_CLOSE_1()
        {
            /*" -1422- EXEC SQL CLOSE V1SUBGRUPO END-EXEC */

            V1SUBGRUPO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-V1APOLICE-SECTION */
        private void R1600_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -1439- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1446- PERFORM R1600_00_SELECT_V1APOLICE_DB_SELECT_1 */

            R1600_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -1449- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1451- DISPLAY 'R1600-00 (NAO EXISTE NA V1APOLICE) ... ' ' ' V1SOLF-NUM-APOL */

                $"R1600-00 (NAO EXISTE NA V1APOLICE) ...  {V1SOLF_NUM_APOL}"
                .Display();

                /*" -1453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1453- ADD 1 TO AC-S-V1APOLICE. */
            AREA_DE_WORK.AC_S_V1APOLICE.Value = AREA_DE_WORK.AC_S_V1APOLICE + 1;

        }

        [StopWatch]
        /*" R1600-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void R1600_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -1446- EXEC SQL SELECT ORGAO , RAMO INTO :V1APOL-ORGAO , :V1APOL-RAMO FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1SOLF-NUM-APOL END-EXEC. */

            var r1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 = new R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_ORGAO, V1APOL_ORGAO);
                _.Move(executed_1.V1APOL_RAMO, V1APOL_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-ACESSA-TOTAIS-SECTION */
        private void R1700_00_ACESSA_TOTAIS_SECTION()
        {
            /*" -1466- MOVE SPACES TO WFIM-V1FATURTOT */
            _.Move("", AREA_DE_WORK.WFIM_V1FATURTOT);

            /*" -1469- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1490- PERFORM R1700_00_ACESSA_TOTAIS_DB_DECLARE_1 */

            R1700_00_ACESSA_TOTAIS_DB_DECLARE_1();

            /*" -1492- PERFORM R1700_00_ACESSA_TOTAIS_DB_OPEN_1 */

            R1700_00_ACESSA_TOTAIS_DB_OPEN_1();

            /*" -1495- PERFORM R1710-00-FETCH-V1FATURASTOT UNTIL WFIM-V1FATURTOT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V1FATURTOT == "S"))
            {

                R1710_00_FETCH_V1FATURASTOT_SECTION();
            }

        }

        [StopWatch]
        /*" R1700-00-ACESSA-TOTAIS-DB-OPEN-1 */
        public void R1700_00_ACESSA_TOTAIS_DB_OPEN_1()
        {
            /*" -1492- EXEC SQL OPEN V1FATURTOT1 END-EXEC. */

            V1FATURTOT1.Open();

        }

        [StopWatch]
        /*" R6100-00-DECLARE-V0MOVIMENTO-DB-DECLARE-1 */
        public void R6100_00_DECLARE_V0MOVIMENTO_DB_DECLARE_1()
        {
            /*" -2720- EXEC SQL DECLARE MOVIMENTO CURSOR FOR SELECT IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_MOVIMENTO , DATA_FATURA FROM SEGUROS.V0MOVIMENTO WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO >= :W1SUB-GRUPO AND COD_SUBGRUPO <= :W2SUB-GRUPO AND DATA_INCLUSAO IS NOT NULL AND DATA_REFERENCIA = :V1FATC-DATA-REFER END-EXEC. */
            MOVIMENTO = new VG0105B_MOVIMENTO(true);
            string GetQuery_MOVIMENTO()
            {
                var query = @$"SELECT IMP_MORNATU_ANT
							, 
							IMP_MORNATU_ATU
							, 
							IMP_MORACID_ANT
							, 
							IMP_MORACID_ATU
							, 
							IMP_INVPERM_ANT
							, 
							IMP_INVPERM_ATU
							, 
							IMP_AMDS_ANT
							, 
							IMP_AMDS_ATU
							, 
							IMP_DH_ANT
							, 
							IMP_DH_ATU
							, 
							IMP_DIT_ANT
							, 
							IMP_DIT_ATU
							, 
							PRM_VG_ANT
							, 
							PRM_VG_ATU
							, 
							PRM_AP_ANT
							, 
							PRM_AP_ATU
							, 
							COD_OPERACAO
							, 
							DATA_MOVIMENTO
							, 
							DATA_FATURA 
							FROM SEGUROS.V0MOVIMENTO 
							WHERE NUM_APOLICE = '{W1SOLF_NUM_APOL}' 
							AND COD_SUBGRUPO >= '{W1SUB_GRUPO}' 
							AND COD_SUBGRUPO <= '{W2SUB_GRUPO}' 
							AND DATA_INCLUSAO IS NOT NULL 
							AND DATA_REFERENCIA = '{V1FATC_DATA_REFER}'";

                return query;
            }
            MOVIMENTO.GetQueryEvent += GetQuery_MOVIMENTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1710-00-FETCH-V1FATURASTOT-SECTION */
        private void R1710_00_FETCH_V1FATURASTOT_SECTION()
        {
            /*" -1509- MOVE '171' TO WNR-EXEC-SQL. */
            _.Move("171", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1526- PERFORM R1710_00_FETCH_V1FATURASTOT_DB_FETCH_1 */

            R1710_00_FETCH_V1FATURASTOT_DB_FETCH_1();

            /*" -1529- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1530- MOVE 'S' TO WFIM-V1FATURTOT */
                _.Move("S", AREA_DE_WORK.WFIM_V1FATURTOT);

                /*" -1530- PERFORM R1710_00_FETCH_V1FATURASTOT_DB_CLOSE_1 */

                R1710_00_FETCH_V1FATURASTOT_DB_CLOSE_1();

                /*" -1533- GO TO R1710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1535- PERFORM R1720-00-GUARDA-TOTAIS */

            R1720_00_GUARDA_TOTAIS_SECTION();

            /*" -1535- ADD 1 TO AC-S-V1FATURTOT. */
            AREA_DE_WORK.AC_S_V1FATURTOT.Value = AREA_DE_WORK.AC_S_V1FATURTOT + 1;

        }

        [StopWatch]
        /*" R1710-00-FETCH-V1FATURASTOT-DB-FETCH-1 */
        public void R1710_00_FETCH_V1FATURASTOT_DB_FETCH_1()
        {
            /*" -1526- EXEC SQL FETCH V1FATURTOT1 INTO :V1FATT-NUM-APOL , :V1FATT-COD-SUBG , :V1FATT-NUM-FATUR , :V1FATT-COD-OPER , :V1FATT-QT-VIDA-VG , :V1FATT-QT-VIDA-AP , :V1FATT-IMP-MORNAT , :V1FATT-IMP-MORACI , :V1FATT-IMP-INVPER , :V1FATT-IMP-AMDS , :V1FATT-IMP-DH , :V1FATT-IMP-DIT , :V1FATT-PRM-VG , :V1FATT-PRM-AP , :V1FATT-SIT-REG , :V1FATT-COD-EMPRESA:VIND-COD-EMP END-EXEC. */

            if (V1FATURTOT1.Fetch())
            {
                _.Move(V1FATURTOT1.V1FATT_NUM_APOL, V1FATT_NUM_APOL);
                _.Move(V1FATURTOT1.V1FATT_COD_SUBG, V1FATT_COD_SUBG);
                _.Move(V1FATURTOT1.V1FATT_NUM_FATUR, V1FATT_NUM_FATUR);
                _.Move(V1FATURTOT1.V1FATT_COD_OPER, V1FATT_COD_OPER);
                _.Move(V1FATURTOT1.V1FATT_QT_VIDA_VG, V1FATT_QT_VIDA_VG);
                _.Move(V1FATURTOT1.V1FATT_QT_VIDA_AP, V1FATT_QT_VIDA_AP);
                _.Move(V1FATURTOT1.V1FATT_IMP_MORNAT, V1FATT_IMP_MORNAT);
                _.Move(V1FATURTOT1.V1FATT_IMP_MORACI, V1FATT_IMP_MORACI);
                _.Move(V1FATURTOT1.V1FATT_IMP_INVPER, V1FATT_IMP_INVPER);
                _.Move(V1FATURTOT1.V1FATT_IMP_AMDS, V1FATT_IMP_AMDS);
                _.Move(V1FATURTOT1.V1FATT_IMP_DH, V1FATT_IMP_DH);
                _.Move(V1FATURTOT1.V1FATT_IMP_DIT, V1FATT_IMP_DIT);
                _.Move(V1FATURTOT1.V1FATT_PRM_VG, V1FATT_PRM_VG);
                _.Move(V1FATURTOT1.V1FATT_PRM_AP, V1FATT_PRM_AP);
                _.Move(V1FATURTOT1.V1FATT_SIT_REG, V1FATT_SIT_REG);
                _.Move(V1FATURTOT1.V1FATT_COD_EMPRESA, V1FATT_COD_EMPRESA);
                _.Move(V1FATURTOT1.VIND_COD_EMP, VIND_COD_EMP);
            }

        }

        [StopWatch]
        /*" R1710-00-FETCH-V1FATURASTOT-DB-CLOSE-1 */
        public void R1710_00_FETCH_V1FATURASTOT_DB_CLOSE_1()
        {
            /*" -1530- EXEC SQL CLOSE V1FATURTOT1 END-EXEC */

            V1FATURTOT1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/

        [StopWatch]
        /*" R1720-00-GUARDA-TOTAIS-SECTION */
        private void R1720_00_GUARDA_TOTAIS_SECTION()
        {
            /*" -1547- IF V1FATT-COD-OPER EQUAL 100 */

            if (V1FATT_COD_OPER == 100)
            {

                /*" -1549- SET I01 TO +2. */
                I01.Value = +2;
            }


            /*" -1550- IF V1FATT-COD-OPER EQUAL 200 */

            if (V1FATT_COD_OPER == 200)
            {

                /*" -1552- SET I01 TO +3. */
                I01.Value = +3;
            }


            /*" -1553- IF V1FATT-COD-OPER EQUAL 300 */

            if (V1FATT_COD_OPER == 300)
            {

                /*" -1555- SET I01 TO +4. */
                I01.Value = +4;
            }


            /*" -1556- IF V1FATT-COD-OPER EQUAL 400 */

            if (V1FATT_COD_OPER == 400)
            {

                /*" -1558- SET I01 TO +5. */
                I01.Value = +5;
            }


            /*" -1559- IF V1FATT-COD-OPER EQUAL 500 */

            if (V1FATT_COD_OPER == 500)
            {

                /*" -1561- SET I01 TO +6. */
                I01.Value = +6;
            }


            /*" -1562- IF V1FATT-COD-OPER EQUAL 1100 */

            if (V1FATT_COD_OPER == 1100)
            {

                /*" -1564- SET I01 TO +7. */
                I01.Value = +7;
            }


            /*" -1565- IF V1FATT-COD-OPER EQUAL 1200 */

            if (V1FATT_COD_OPER == 1200)
            {

                /*" -1567- SET I01 TO +8. */
                I01.Value = +8;
            }


            /*" -1568- IF V1FATT-COD-OPER EQUAL 1300 */

            if (V1FATT_COD_OPER == 1300)
            {

                /*" -1570- SET I01 TO +9. */
                I01.Value = +9;
            }


            /*" -1571- IF V1FATT-COD-OPER EQUAL 1400 */

            if (V1FATT_COD_OPER == 1400)
            {

                /*" -1573- SET I01 TO +10. */
                I01.Value = +10;
            }


            /*" -1574- IF V1FATT-COD-OPER EQUAL 1500 */

            if (V1FATT_COD_OPER == 1500)
            {

                /*" -1576- SET I01 TO +11. */
                I01.Value = +11;
            }


            /*" -1577- IF V1FATT-COD-OPER EQUAL 1600 */

            if (V1FATT_COD_OPER == 1600)
            {

                /*" -1579- SET I01 TO +12. */
                I01.Value = +12;
            }


            /*" -1580- IF V1FATT-COD-OPER EQUAL 1700 */

            if (V1FATT_COD_OPER == 1700)
            {

                /*" -1582- SET I01 TO +13. */
                I01.Value = +13;
            }


            /*" -1583- IF V1FATT-COD-OPER EQUAL 1800 */

            if (V1FATT_COD_OPER == 1800)
            {

                /*" -1585- SET I01 TO +14. */
                I01.Value = +14;
            }


            /*" -1586- MOVE V1FATT-NUM-APOL TO NUM-APOL(I01) */
            _.Move(V1FATT_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_APOL);

            /*" -1587- MOVE V1FATT-COD-SUBG TO COD-SUBG(I01) */
            _.Move(V1FATT_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_SUBG);

            /*" -1588- MOVE V1FATT-NUM-FATUR TO NUM-FATUR(I01) */
            _.Move(V1FATT_NUM_FATUR, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_FATUR);

            /*" -1589- MOVE V1FATT-COD-OPER TO COD-OPER(I01) */
            _.Move(V1FATT_COD_OPER, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER);

            /*" -1590- MOVE V1FATT-QT-VIDA-VG TO QT-VIDA-VG(I01) */
            _.Move(V1FATT_QT_VIDA_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_VG);

            /*" -1591- MOVE V1FATT-QT-VIDA-AP TO QT-VIDA-AP(I01) */
            _.Move(V1FATT_QT_VIDA_AP, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_AP);

            /*" -1592- MOVE V1FATT-IMP-MORNAT TO IMP-MORNAT(I01) */
            _.Move(V1FATT_IMP_MORNAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORNAT);

            /*" -1593- MOVE V1FATT-IMP-MORACI TO IMP-MORACI(I01) */
            _.Move(V1FATT_IMP_MORACI, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORACI);

            /*" -1594- MOVE V1FATT-IMP-INVPER TO IMP-INVPER(I01) */
            _.Move(V1FATT_IMP_INVPER, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_INVPER);

            /*" -1595- MOVE V1FATT-IMP-AMDS TO IMP-AMDS(I01) */
            _.Move(V1FATT_IMP_AMDS, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_AMDS);

            /*" -1596- MOVE V1FATT-IMP-DH TO IMP-DH(I01) */
            _.Move(V1FATT_IMP_DH, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DH);

            /*" -1597- MOVE V1FATT-IMP-DIT TO IMP-DIT(I01) */
            _.Move(V1FATT_IMP_DIT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DIT);

            /*" -1598- MOVE V1FATT-PRM-VG TO PRM-VG(I01) */
            _.Move(V1FATT_PRM_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_VG);

            /*" -1599- MOVE V1FATT-PRM-AP TO PRM-AP(I01) */
            _.Move(V1FATT_PRM_AP, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_AP);

            /*" -1600- MOVE ZEROS TO COD-EMPRESA(I01) */
            _.Move(0, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_EMPRESA);

            /*" -1601- MOVE '0' TO SIT-REG(I01) */
            _.Move("0", AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].SIT_REG);

            /*" -1601- MOVE -1 TO VIND-COD-EMP. */
            _.Move(-1, VIND_COD_EMP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1720_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-V1RAMOIND-SECTION */
        private void R1900_00_SELECT_V1RAMOIND_SECTION()
        {
            /*" -1679- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1686- PERFORM R1900_00_SELECT_V1RAMOIND_DB_SELECT_1 */

            R1900_00_SELECT_V1RAMOIND_DB_SELECT_1();

            /*" -1689- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1691- DISPLAY 'R1900-00 (NAO EXISTE NA V1RAMOIND) ... ' ' ' V1ENDO-RAMO */

                $"R1900-00 (NAO EXISTE NA V1RAMOIND) ...  {V1ENDO_RAMO}"
                .Display();

                /*" -1691- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-V1RAMOIND-DB-SELECT-1 */
        public void R1900_00_SELECT_V1RAMOIND_DB_SELECT_1()
        {
            /*" -1686- EXEC SQL SELECT ISECUSTO, PCIOF INTO :V1RIND-ISECUSTO, :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1APOL-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

            var r1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 = new R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1()
            {
                V1RIND_DTINIVIG = V1RIND_DTINIVIG.ToString(),
                V1APOL_RAMO = V1APOL_RAMO.ToString(),
            };

            var executed_1 = R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_ISECUSTO, V1RIND_ISECUSTO);
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-FATURA-SECTION */
        private void R2000_00_FATURA_SECTION()
        {
            /*" -1758- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1760- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
            _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

            /*" -1761- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

            /*" -1762- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
            _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

            /*" -1764- MOVE V1SOLF-COD-SUBG TO W1SOLF-COD-SUBG */
            _.Move(V1SOLF_COD_SUBG, W1SOLF_COD_SUBG);

            /*" -1765- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", AREA_DE_WORK.WFIM_V1FATURAS);

            /*" -1775- PERFORM R1200-00-SELECT-V1FATURA */

            R1200_00_SELECT_V1FATURA_SECTION();

            /*" -1776- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -1777- IF V1SOLF-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 100)
                {

                    /*" -1780- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -1785- GO TO R2000-10-CONTINUA. */

                        R2000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -1786- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -1788- IF V1SOLF-COD-OPER EQUAL 200 AND V1FATR-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 200 && V1FATR_COD_OPER == 100)
                {

                    /*" -1794- GO TO R2000-10-CONTINUA. */

                    R2000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -1795- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -1796- IF V1SOLF-COD-OPER EQUAL 300 */

                if (V1SOLF_COD_OPER == 300)
                {

                    /*" -1799- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -1804- GO TO R2000-10-CONTINUA. */

                        R2000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -1805- IF WFIM-V1FATURAS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -1806- IF V1SOLF-COD-OPER EQUAL 100 OR 200 */

                if (V1SOLF_COD_OPER.In("100", "200"))
                {

                    /*" -1811- GO TO R2000-10-CONTINUA. */

                    R2000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -1812- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -1814- IF V1SOLF-COD-OPER EQUAL 200 AND WTEM-TERMO-ADESAO EQUAL 'S' */

                if (V1SOLF_COD_OPER == 200 && AREA_DE_WORK.WTEM_TERMO_ADESAO == "S")
                {

                    /*" -1824- GO TO R2000-10-CONTINUA. */

                    R2000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -1826- MOVE '1' TO WFLAG-SOLICITA. */
            _.Move("1", WFLAG_SOLICITA);

            /*" -1826- GO TO R2000-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R2000-10-CONTINUA */
        private void R2000_10_CONTINUA(bool isPerform = false)
        {
            /*" -1842- IF (V1SOLF-COD-OPER EQUAL 100) OR (V1SOLF-COD-OPER EQUAL 200 AND WFIM-V1FATURAS NOT EQUAL SPACES) OR (V1SOLF-COD-OPER EQUAL 300 AND V1FATR-COD-OPER NOT EQUAL 100) */

            if ((V1SOLF_COD_OPER == 100) || (V1SOLF_COD_OPER == 200 && !AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty()) || (V1SOLF_COD_OPER == 300 && V1FATR_COD_OPER != 100))
            {

                /*" -1843- MOVE SPACES TO WFIM-V1FATURANT */
                _.Move("", AREA_DE_WORK.WFIM_V1FATURANT);

                /*" -1844- PERFORM R1300-00-SELECT-V1FATTOT-ANT */

                R1300_00_SELECT_V1FATTOT_ANT_SECTION();

                /*" -1845- IF WFIM-V1FATURANT NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1FATURANT.IsEmpty())
                {

                    /*" -1846- PERFORM S0100-00-ZERA-SALDO-ANT */

                    S0100_00_ZERA_SALDO_ANT_SECTION();

                    /*" -1847- ELSE */
                }
                else
                {


                    /*" -1848- PERFORM S0200-00-MONTA-SALDO-ANT */

                    S0200_00_MONTA_SALDO_ANT_SECTION();

                    /*" -1849- ELSE */
                }

            }
            else
            {


                /*" -1851- PERFORM S0100-00-ZERA-SALDO-ANT. */

                S0100_00_ZERA_SALDO_ANT_SECTION();
            }


            /*" -1854- IF (V1SOLF-COD-OPER EQUAL 200 OR 300) AND WFIM-V1FATURAS EQUAL SPACES AND V1FATR-COD-OPER EQUAL 100 */

            if ((V1SOLF_COD_OPER.In("200", "300")) && AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty() && V1FATR_COD_OPER == 100)
            {

                /*" -1855- PERFORM R1700-00-ACESSA-TOTAIS */

                R1700_00_ACESSA_TOTAIS_SECTION();

                /*" -1856- ELSE */
            }
            else
            {


                /*" -1859- IF (V1SOLF-COD-OPER EQUAL 100 OR 200 OR 300) AND WTEM-TERMO-ADESAO EQUAL 'S' AND MODALIDADE-CAPITAL EQUAL '0' */

                if ((V1SOLF_COD_OPER.In("100", "200", "300")) && AREA_DE_WORK.WTEM_TERMO_ADESAO == "S" && MODALIDADE_CAPITAL == "0")
                {

                    /*" -1860- PERFORM R1700-00-ACESSA-TOTAIS */

                    R1700_00_ACESSA_TOTAIS_SECTION();

                    /*" -1862- IF PRM-VG(13) EQUAL ZEROS AND PRM-AP(13) EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG == 00 && AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP == 00)
                    {

                        /*" -1863- PERFORM S0300-00-TOTALIZA-FATURA */

                        S0300_00_TOTALIZA_FATURA_SECTION();

                        /*" -1865- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1866- ELSE */
                    }

                }
                else
                {


                    /*" -1867- PERFORM R6000-00-TOTALIZA-MOVIMENTO */

                    R6000_00_TOTALIZA_MOVIMENTO_SECTION();

                    /*" -1869- PERFORM S0300-00-TOTALIZA-FATURA. */

                    S0300_00_TOTALIZA_FATURA_SECTION();
                }

            }


            /*" -1870- IF V1SOLF-COD-OPER EQUAL 100 */

            if (V1SOLF_COD_OPER == 100)
            {

                /*" -1872- MOVE W1S-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -1873- MOVE ZEROS TO W1SOLF-NUM-RCAP */
                _.Move(0, W1SOLF_NUM_RCAP);

                /*" -1874- MOVE ZEROS TO W1SOLF-VAL-RCAP */
                _.Move(0, W1SOLF_VAL_RCAP);

                /*" -1875- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -1876- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -1877- MOVE -1 TO W1SOLF-DATA-RCAP-I */
                _.Move(-1, W1SOLF_DATA_RCAP_I);

                /*" -1879- MOVE -1 TO W1SOLF-DATA-VENC-I */
                _.Move(-1, W1SOLF_DATA_VENC_I);

                /*" -1880- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -1881- MOVE '0' TO W1ENDO-TIPEND */
                    _.Move("0", W1ENDO_TIPEND);

                    /*" -1882- MOVE ZEROS TO W1ENDO-NRENDOS */
                    _.Move(0, W1ENDO_NRENDOS);

                    /*" -1883- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -1884- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -1885- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -1886- ELSE */
                }
                else
                {


                    /*" -1887- MOVE V1FATR-TIPO-ENDOS TO W1ENDO-TIPEND */
                    _.Move(V1FATR_TIPO_ENDOS, W1ENDO_TIPEND);

                    /*" -1888- MOVE V1FATR-NUM-ENDOS TO W1ENDO-NRENDOS */
                    _.Move(V1FATR_NUM_ENDOS, W1ENDO_NRENDOS);

                    /*" -1889- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -1890- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -1891- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -1892- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -1892- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MONTA-V0FATURAS-SECTION */
        private void R2100_00_MONTA_V0FATURAS_SECTION()
        {
            /*" -1905- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1906- MOVE W1SOLF-NUM-APOL TO V0FATR-NUM-APOL */
            _.Move(W1SOLF_NUM_APOL, V0FATR_NUM_APOL);

            /*" -1907- MOVE W1SOLF-COD-SUBG TO V0FATR-COD-SUBG */
            _.Move(W1SOLF_COD_SUBG, V0FATR_COD_SUBG);

            /*" -1908- MOVE W1SOLF-NUM-FAT TO V0FATR-NUM-FATUR */
            _.Move(W1SOLF_NUM_FAT, V0FATR_NUM_FATUR);

            /*" -1909- MOVE V1SOLF-COD-OPER TO V0FATR-COD-OPER */
            _.Move(V1SOLF_COD_OPER, V0FATR_COD_OPER);

            /*" -1910- MOVE W1ENDO-TIPEND TO V0FATR-TIPO-ENDOS */
            _.Move(W1ENDO_TIPEND, V0FATR_TIPO_ENDOS);

            /*" -1911- MOVE W1ENDO-NRENDOS TO V0FATR-NUM-ENDOS */
            _.Move(W1ENDO_NRENDOS, V0FATR_NUM_ENDOS);

            /*" -1914- COMPUTE V0FATR-VAL-FATURA = PRM-VG(13) + PRM-AP(13) */
            V0FATR_VAL_FATURA.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value;

            /*" -1917- COMPUTE V0FATR-VLIOCC ROUNDED = V0FATR-VAL-FATURA - (V0FATR-VAL-FATURA / (1 + (V1RIND-PCIOF / 100))) */
            V0FATR_VLIOCC.Value = V0FATR_VAL_FATURA - (V0FATR_VAL_FATURA / (1 + (V1RIND_PCIOF / 100f)));

            /*" -1918- IF W1SOLF-NUM-RCAP NOT EQUAL ZEROS */

            if (W1SOLF_NUM_RCAP != 00)
            {

                /*" -1919- MOVE W1SUBG-COD-FONTE TO V0FATR-COD-FONTE */
                _.Move(W1SUBG_COD_FONTE, V0FATR_COD_FONTE);

                /*" -1920- ELSE */
            }
            else
            {


                /*" -1922- MOVE ZEROS TO V0FATR-COD-FONTE. */
                _.Move(0, V0FATR_COD_FONTE);
            }


            /*" -1923- MOVE W1SOLF-NUM-RCAP TO V0FATR-NUM-RCAP */
            _.Move(W1SOLF_NUM_RCAP, V0FATR_NUM_RCAP);

            /*" -1924- MOVE W1SOLF-VAL-RCAP TO V0FATR-VAL-RCAP */
            _.Move(W1SOLF_VAL_RCAP, V0FATR_VAL_RCAP);

            /*" -1925- MOVE WDATA-INIVIG TO V0FATR-DATA-INIVIG */
            _.Move(AREA_DE_WORK.WDATA_INIVIG, V0FATR_DATA_INIVIG);

            /*" -1926- MOVE WDATA-TERVIG TO V0FATR-DATA-TERVIG */
            _.Move(AREA_DE_WORK.WDATA_TERVIG, V0FATR_DATA_TERVIG);

            /*" -1928- MOVE '0' TO V0FATR-SIT-REG */
            _.Move("0", V0FATR_SIT_REG);

            /*" -1929- MOVE V1SIST-DTMOVABE TO V0FATR-DATA-FATUR */
            _.Move(V1SIST_DTMOVABE, V0FATR_DATA_FATUR);

            /*" -1931- MOVE 0 TO V0FATR-DATA-FATU-I */
            _.Move(0, V0FATR_DATA_FATU_I);

            /*" -1932- MOVE W1SOLF-DATA-RCAP TO V0FATR-DATA-RCAP */
            _.Move(W1SOLF_DATA_RCAP, V0FATR_DATA_RCAP);

            /*" -1933- MOVE W1SOLF-DATA-RCAP-I TO V0FATR-DATA-RCAP-I */
            _.Move(W1SOLF_DATA_RCAP_I, V0FATR_DATA_RCAP_I);

            /*" -1934- MOVE V1SOLF-DATA-VENC TO V0FATR-DATA-VENC */
            _.Move(V1SOLF_DATA_VENC, V0FATR_DATA_VENC);

            /*" -1935- MOVE V1SOLF-DATA-VENC-I TO V0FATR-DATA-VENC-I */
            _.Move(V1SOLF_DATA_VENC_I, V0FATR_DATA_VENC_I);

            /*" -1935- MOVE -1 TO VIND-COD-EMP. */
            _.Move(-1, VIND_COD_EMP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-MONTA-V0FATURASTOT-SECTION */
        private void R2200_00_MONTA_V0FATURASTOT_SECTION()
        {
            /*" -1946- SET I01 TO +2. */
            I01.Value = +2;

            /*" -0- FLUXCONTROL_PERFORM R2200_10_LOOP */

            R2200_10_LOOP();

        }

        [StopWatch]
        /*" R2200-10-LOOP */
        private void R2200_10_LOOP(bool isPerform = false)
        {
            /*" -1952- IF NUM-APOL(I01) NOT EQUAL ZEROS */

            if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_APOL != 00)
            {

                /*" -1953- MOVE NUM-APOL(I01) TO V0FATT-NUM-APOL */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_APOL, V0FATT_NUM_APOL);

                /*" -1954- MOVE COD-SUBG(I01) TO V0FATT-COD-SUBG */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_SUBG, V0FATT_COD_SUBG);

                /*" -1955- MOVE NUM-FATUR(I01) TO V0FATT-NUM-FATUR */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_FATUR, V0FATT_NUM_FATUR);

                /*" -1956- MOVE COD-OPER(I01) TO V0FATT-COD-OPER */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER, V0FATT_COD_OPER);

                /*" -1957- MOVE QT-VIDA-VG(I01) TO V0FATT-QT-VIDA-VG */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_VG, V0FATT_QT_VIDA_VG);

                /*" -1958- MOVE QT-VIDA-AP(I01) TO V0FATT-QT-VIDA-AP */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_AP, V0FATT_QT_VIDA_AP);

                /*" -1959- MOVE IMP-MORNAT(I01) TO V0FATT-IMP-MORNAT */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORNAT, V0FATT_IMP_MORNAT);

                /*" -1960- MOVE IMP-MORACI(I01) TO V0FATT-IMP-MORACI */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORACI, V0FATT_IMP_MORACI);

                /*" -1961- MOVE IMP-INVPER(I01) TO V0FATT-IMP-INVPER */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_INVPER, V0FATT_IMP_INVPER);

                /*" -1962- MOVE IMP-AMDS(I01) TO V0FATT-IMP-AMDS */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_AMDS, V0FATT_IMP_AMDS);

                /*" -1963- MOVE IMP-DH(I01) TO V0FATT-IMP-DH */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DH, V0FATT_IMP_DH);

                /*" -1964- MOVE IMP-DIT(I01) TO V0FATT-IMP-DIT */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DIT, V0FATT_IMP_DIT);

                /*" -1965- MOVE PRM-VG(I01) TO V0FATT-PRM-VG */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_VG, V0FATT_PRM_VG);

                /*" -1966- MOVE PRM-AP(I01) TO V0FATT-PRM-AP */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_AP, V0FATT_PRM_AP);

                /*" -1967- MOVE '0' TO V0FATT-SIT-REG */
                _.Move("0", V0FATT_SIT_REG);

                /*" -1969- MOVE -1 TO VIND-COD-EMP */
                _.Move(-1, VIND_COD_EMP);

                /*" -1971- PERFORM R3200-00-INSERT-V0FATURASTOT. */

                R3200_00_INSERT_V0FATURASTOT_SECTION();
            }


            /*" -1973- SET I01 UP BY +1. */
            I01.Value += +1;

            /*" -1974- IF I01 LESS 15 */

            if (I01 < 15)
            {

                /*" -1974- GO TO R2200-10-LOOP. */
                new Task(() => R2200_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-DETERMINA-VIGENCIA-SECTION */
        private void R2310_00_DETERMINA_VIGENCIA_SECTION()
        {
            /*" -1989- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1990- MOVE V1FATC-DATA-REFER TO WDATA-REFERENCIA */
            _.Move(V1FATC_DATA_REFER, AREA_DE_WORK.WDATA_REFERENCIA);

            /*" -1991- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA */
            _.Move(V1SOLF_NUM_FAT, AREA_DE_WORK.WNUM_FATURA);

            /*" -1992- MOVE WFAT-ANO TO WINI-ANO */
            _.Move(AREA_DE_WORK.FILLER_19.WFAT_ANO, AREA_DE_WORK.FILLER_23.WINI_ANO);

            /*" -1993- MOVE WFAT-MES TO WINI-MES */
            _.Move(AREA_DE_WORK.FILLER_19.WFAT_MES, AREA_DE_WORK.FILLER_23.WINI_MES);

            /*" -1995- MOVE WREF-DIA TO WINI-DIA */
            _.Move(AREA_DE_WORK.FILLER_26.WREF_DIA, AREA_DE_WORK.FILLER_23.WINI_DIA);

            /*" -1997- IF V1SUBG-TIPO-FAT EQUAL '1' OR V1SUBG-TIPO-FAT EQUAL '3' */

            if (V1SUBG_TIPO_FAT == "1" || V1SUBG_TIPO_FAT == "3")
            {

                /*" -1999- MOVE WDATA-INIVIG TO WDATA-TERVIG */
                _.Move(AREA_DE_WORK.WDATA_INIVIG, AREA_DE_WORK.WDATA_TERVIG);

                /*" -2000- IF WINI-DIA EQUAL 01 */

                if (AREA_DE_WORK.FILLER_23.WINI_DIA == 01)
                {

                    /*" -2002- IF WINI-MES EQUAL 04 OR 06 OR 09 OR 11 */

                    if (AREA_DE_WORK.FILLER_23.WINI_MES.In("04", "06", "09", "11"))
                    {

                        /*" -2003- MOVE 30 TO WTER-DIA */
                        _.Move(30, AREA_DE_WORK.FILLER_24.WTER_DIA);

                        /*" -2004- ELSE */
                    }
                    else
                    {


                        /*" -2005- IF WINI-MES EQUAL 02 */

                        if (AREA_DE_WORK.FILLER_23.WINI_MES == 02)
                        {

                            /*" -2008- COMPUTE WRESTO EQUAL WINI-ANO - (WINI-ANO / 4 * 4) */
                            AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.FILLER_23.WINI_ANO - (AREA_DE_WORK.FILLER_23.WINI_ANO / 4 * 4);

                            /*" -2009- IF WRESTO EQUAL ZEROS */

                            if (AREA_DE_WORK.WRESTO == 00)
                            {

                                /*" -2010- MOVE 29 TO WTER-DIA */
                                _.Move(29, AREA_DE_WORK.FILLER_24.WTER_DIA);

                                /*" -2011- ELSE */
                            }
                            else
                            {


                                /*" -2012- MOVE 28 TO WTER-DIA */
                                _.Move(28, AREA_DE_WORK.FILLER_24.WTER_DIA);

                                /*" -2013- ELSE */
                            }

                        }
                        else
                        {


                            /*" -2014- MOVE 31 TO WTER-DIA */
                            _.Move(31, AREA_DE_WORK.FILLER_24.WTER_DIA);

                            /*" -2015- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -2016- MOVE WINI-DIA TO WPAR-DIA */
                    _.Move(AREA_DE_WORK.FILLER_23.WINI_DIA, AREA_DE_WORK.FILLER_27.WPAR_DIA);

                    /*" -2017- MOVE WINI-MES TO WPAR-MES */
                    _.Move(AREA_DE_WORK.FILLER_23.WINI_MES, AREA_DE_WORK.FILLER_27.WPAR_MES);

                    /*" -2018- MOVE WINI-ANO TO WPAR-ANO */
                    _.Move(AREA_DE_WORK.FILLER_23.WINI_ANO, AREA_DE_WORK.FILLER_27.WPAR_ANO);

                    /*" -2019- MOVE WDATA-PARAMETRO TO WDATA-INFORMADA */
                    _.Move(AREA_DE_WORK.WDATA_PARAMETRO, AREA_DE_WORK.WPROSOMC1.WDATA_INFORMADA);

                    /*" -2020- MOVE 30 TO WDATA-QTDIAS */
                    _.Move(30, AREA_DE_WORK.WPROSOMC1.WDATA_QTDIAS);

                    /*" -2021- MOVE ZEROS TO WDATA-CALCULO */
                    _.Move(0, AREA_DE_WORK.WPROSOMC1.WDATA_CALCULO);

                    /*" -2023- CALL 'PROSOMC1' USING WPROSOMC1 */
                    _.Call("PROSOMC1", AREA_DE_WORK.WPROSOMC1);

                    /*" -2024- MOVE WDATA-CALCULO TO WDATA-RETORNO */
                    _.Move(AREA_DE_WORK.WPROSOMC1.WDATA_CALCULO, AREA_DE_WORK.WDATA_RETORNO);

                    /*" -2025- MOVE WRET-DIA TO WTER-DIA */
                    _.Move(AREA_DE_WORK.FILLER_28.WRET_DIA, AREA_DE_WORK.FILLER_24.WTER_DIA);

                    /*" -2026- MOVE WRET-MES TO WTER-MES */
                    _.Move(AREA_DE_WORK.FILLER_28.WRET_MES, AREA_DE_WORK.FILLER_24.WTER_MES);

                    /*" -2069- MOVE WRET-ANO TO WTER-ANOA */
                    _.Move(AREA_DE_WORK.FILLER_28.WRET_ANO, AREA_DE_WORK.FILLER_24.WTER_ANO.WTER_ANOA);

                    /*" -2070- ELSE */
                }

            }
            else
            {


                /*" -2072- MOVE DATA-TERVIG TO WDATA-TERVIG. */
                _.Move(DATA_TERVIG, AREA_DE_WORK.WDATA_TERVIG);
            }


            /*" -2075- MOVE '-' TO WINI-BR1 WINI-BR2 WTER-BR1 WTER-BR2. */
            _.Move("-", AREA_DE_WORK.FILLER_23.WINI_BR1);
            _.Move("-", AREA_DE_WORK.FILLER_23.WINI_BR2);
            _.Move("-", AREA_DE_WORK.FILLER_24.WTER_BR1);
            _.Move("-", AREA_DE_WORK.FILLER_24.WTER_BR2);


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V1FATURCONT-SECTION */
        private void R2315_00_SELECT_V1FATURCONT_SECTION()
        {
            /*" -2089- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2101- PERFORM R2315_00_SELECT_V1FATURCONT_DB_SELECT_1 */

            R2315_00_SELECT_V1FATURCONT_DB_SELECT_1();

            /*" -2104- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2107- DISPLAY 'R2315 - NAO EXISTE NA V1FATURCONT ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                $"R2315 - NAO EXISTE NA V1FATURCONT  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();

                /*" -2107- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V1FATURCONT-DB-SELECT-1 */
        public void R2315_00_SELECT_V1FATURCONT_DB_SELECT_1()
        {
            /*" -2101- EXEC SQL SELECT A.DATA_REFERENCIA, A.DATA_REFERENCIA + B.PERI_FATURAMENTO MONTH - 1 DAY INTO :V1FATC-DATA-REFER, :DATA-TERVIG FROM SEGUROS.V1FATURCONT A, SEGUROS.V1SUBGRUPO B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_APOLICE = :V1SOLF-NUM-APOL AND A.COD_SUBGRUPO = :V1SOLF-COD-SUBG END-EXEC. */

            var r2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 = new R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
            };

            var executed_1 = R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1.Execute(r2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATC_DATA_REFER, V1FATC_DATA_REFER);
                _.Move(executed_1.DATA_TERVIG, DATA_TERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2330-00-SELECT-V1FATURCONT-SECTION */
        private void R2330_00_SELECT_V1FATURCONT_SECTION()
        {
            /*" -2147- MOVE '233' TO WNR-EXEC-SQL. */
            _.Move("233", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2154- PERFORM R2330_00_SELECT_V1FATURCONT_DB_SELECT_1 */

            R2330_00_SELECT_V1FATURCONT_DB_SELECT_1();

            /*" -2157- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2160- DISPLAY 'R2330 - NAO EXISTE NA V1FATURCONT ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                $"R2330 - NAO EXISTE NA V1FATURCONT  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();

                /*" -2162- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2163- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -2165- DISPLAY 'R2330 - ACHOU MAIS DE UM ... ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG. */

                $"R2330 - ACHOU MAIS DE UM ...  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();
            }


        }

        [StopWatch]
        /*" R2330-00-SELECT-V1FATURCONT-DB-SELECT-1 */
        public void R2330_00_SELECT_V1FATURCONT_DB_SELECT_1()
        {
            /*" -2154- EXEC SQL SELECT NUM_APOLICE, DATA_REFERENCIA INTO :V1FATC-NUM-APOLICE, :V1FATC-DATA-REFER FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :V1SOLF-NUM-APOL END-EXEC. */

            var r2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 = new R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1.Execute(r2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATC_NUM_APOLICE, V1FATC_NUM_APOLICE);
                _.Move(executed_1.V1FATC_DATA_REFER, V1FATC_DATA_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2330_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-FATURA-SUBG-RESUMO-SECTION */
        private void R3000_00_FATURA_SUBG_RESUMO_SECTION()
        {
            /*" -2177- MOVE SPACES TO WFIM-V1SUBGRUPO */
            _.Move("", AREA_DE_WORK.WFIM_V1SUBGRUPO);

            /*" -2179- PERFORM R1500-00-DECLARE-V1SUBGR. */

            R1500_00_DECLARE_V1SUBGR_SECTION();

            /*" -2179- MOVE ATACUM-MASCARA TO ATACUM-CAMPOS. */
            _.Move(AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA, AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS);

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LEITURA_V1SUBG */

            R3000_10_LEITURA_V1SUBG();

        }

        [StopWatch]
        /*" R3000-10-LEITURA-V1SUBG */
        private void R3000_10_LEITURA_V1SUBG(bool isPerform = false)
        {
            /*" -2184- PERFORM R1510-00-FETCH-V1SUBGR. */

            R1510_00_FETCH_V1SUBGR_SECTION();

            /*" -2185- IF WFIM-V1SUBGRUPO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SUBGRUPO.IsEmpty())
            {

                /*" -2187- GO TO R3000-50-INCLUI-FATURA-APOL. */

                R3000_50_INCLUI_FATURA_APOL(); //GOTO
                return;
            }


            /*" -2189- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
            _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

            /*" -2190- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

            /*" -2191- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
            _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

            /*" -2193- MOVE V1SUBG-COD-SUBG TO W1SOLF-COD-SUBG */
            _.Move(V1SUBG_COD_SUBG, W1SOLF_COD_SUBG);

            /*" -2194- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", AREA_DE_WORK.WFIM_V1FATURAS);

            /*" -2202- PERFORM R1200-00-SELECT-V1FATURA */

            R1200_00_SELECT_V1FATURA_SECTION();

            /*" -2203- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2204- IF V1SOLF-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 100)
                {

                    /*" -2207- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -2213- GO TO R3000-10-CONTINUA. */

                        R3000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -2214- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2216- IF V1SOLF-COD-OPER EQUAL 200 AND V1FATR-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 200 && V1FATR_COD_OPER == 100)
                {

                    /*" -2223- GO TO R3000-10-CONTINUA. */

                    R3000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2224- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2225- IF V1SOLF-COD-OPER EQUAL 300 */

                if (V1SOLF_COD_OPER == 300)
                {

                    /*" -2228- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -2234- GO TO R3000-10-CONTINUA. */

                        R3000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -2235- IF WFIM-V1FATURAS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2236- IF V1SOLF-COD-OPER EQUAL 100 OR 200 */

                if (V1SOLF_COD_OPER.In("100", "200"))
                {

                    /*" -2241- GO TO R3000-10-CONTINUA. */

                    R3000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2242- IF WFIM-V1FATURAS EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2244- IF V1SOLF-COD-OPER EQUAL 200 AND WTEM-TERMO-ADESAO EQUAL 'S' */

                if (V1SOLF_COD_OPER == 200 && AREA_DE_WORK.WTEM_TERMO_ADESAO == "S")
                {

                    /*" -2248- GO TO R3000-10-CONTINUA. */

                    R3000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2249- DISPLAY 'SOLICITACAO INVALIDA ... ' */
            _.Display($"SOLICITACAO INVALIDA ... ");

            /*" -2250- DISPLAY 'APOLICE  ' V1SOLF-NUM-APOL */
            _.Display($"APOLICE  {V1SOLF_NUM_APOL}");

            /*" -2251- DISPLAY 'SUBGRUPO ' W1SOLF-COD-SUBG */
            _.Display($"SUBGRUPO {W1SOLF_COD_SUBG}");

            /*" -2252- DISPLAY 'FATURA   ' V1SOLF-NUM-FAT */
            _.Display($"FATURA   {V1SOLF_NUM_FAT}");

            /*" -2254- DISPLAY 'OPERACAO ' V1SOLF-COD-OPER */
            _.Display($"OPERACAO {V1SOLF_COD_OPER}");

            /*" -2254- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3000-10-CONTINUA */
        private void R3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -2270- IF (V1SOLF-COD-OPER EQUAL 100) OR (V1SOLF-COD-OPER EQUAL 200 AND WFIM-V1FATURAS NOT EQUAL SPACES) OR (V1SOLF-COD-OPER EQUAL 300 AND V1FATR-COD-OPER NOT EQUAL 100) */

            if ((V1SOLF_COD_OPER == 100) || (V1SOLF_COD_OPER == 200 && !AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty()) || (V1SOLF_COD_OPER == 300 && V1FATR_COD_OPER != 100))
            {

                /*" -2271- MOVE SPACES TO WFIM-V1FATURANT */
                _.Move("", AREA_DE_WORK.WFIM_V1FATURANT);

                /*" -2272- PERFORM R1300-00-SELECT-V1FATTOT-ANT */

                R1300_00_SELECT_V1FATTOT_ANT_SECTION();

                /*" -2273- IF WFIM-V1FATURANT NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1FATURANT.IsEmpty())
                {

                    /*" -2274- PERFORM S0100-00-ZERA-SALDO-ANT */

                    S0100_00_ZERA_SALDO_ANT_SECTION();

                    /*" -2275- ELSE */
                }
                else
                {


                    /*" -2276- PERFORM S0200-00-MONTA-SALDO-ANT */

                    S0200_00_MONTA_SALDO_ANT_SECTION();

                    /*" -2277- ELSE */
                }

            }
            else
            {


                /*" -2279- PERFORM S0100-00-ZERA-SALDO-ANT. */

                S0100_00_ZERA_SALDO_ANT_SECTION();
            }


            /*" -2282- IF (V1SOLF-COD-OPER EQUAL 200 OR 300) AND WFIM-V1FATURAS EQUAL SPACES AND V1FATR-COD-OPER EQUAL 100 */

            if ((V1SOLF_COD_OPER.In("200", "300")) && AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty() && V1FATR_COD_OPER == 100)
            {

                /*" -2283- PERFORM R1700-00-ACESSA-TOTAIS */

                R1700_00_ACESSA_TOTAIS_SECTION();

                /*" -2284- ELSE */
            }
            else
            {


                /*" -2287- IF (V1SOLF-COD-OPER EQUAL 100 OR 200 OR 300) AND WTEM-TERMO-ADESAO EQUAL 'S' AND MODALIDADE-CAPITAL EQUAL '0' */

                if ((V1SOLF_COD_OPER.In("100", "200", "300")) && AREA_DE_WORK.WTEM_TERMO_ADESAO == "S" && MODALIDADE_CAPITAL == "0")
                {

                    /*" -2288- PERFORM R1700-00-ACESSA-TOTAIS */

                    R1700_00_ACESSA_TOTAIS_SECTION();

                    /*" -2290- IF PRM-VG(13) EQUAL ZEROS AND PRM-AP(13) EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG == 00 && AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP == 00)
                    {

                        /*" -2291- PERFORM S0300-00-TOTALIZA-FATURA */

                        S0300_00_TOTALIZA_FATURA_SECTION();

                        /*" -2293- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2294- ELSE */
                    }

                }
                else
                {


                    /*" -2295- PERFORM R6000-00-TOTALIZA-MOVIMENTO */

                    R6000_00_TOTALIZA_MOVIMENTO_SECTION();

                    /*" -2297- PERFORM S0300-00-TOTALIZA-FATURA. */

                    S0300_00_TOTALIZA_FATURA_SECTION();
                }

            }


            /*" -2299- PERFORM S0400-00-TOTALIZA-APOLICE */

            S0400_00_TOTALIZA_APOLICE_SECTION();

            /*" -2300- IF W1S-TIPO-FAT EQUAL '3' */

            if (W1S_TIPO_FAT == "3")
            {

                /*" -2301- PERFORM R3020-00-GERA-FATURA */

                R3020_00_GERA_FATURA_SECTION();

                /*" -2302- ELSE */
            }
            else
            {


                /*" -2304- PERFORM R3040-00-GERA-FATURA-ENDOSSO. */

                R3040_00_GERA_FATURA_ENDOSSO_SECTION();
            }


            /*" -2306- PERFORM R6500-00-UPDATE-MOVIMENTO */

            R6500_00_UPDATE_MOVIMENTO_SECTION();

            /*" -2306- GO TO R3000-10-LEITURA-V1SUBG. */

            R3000_10_LEITURA_V1SUBG(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3000-50-INCLUI-FATURA-APOL */
        private void R3000_50_INCLUI_FATURA_APOL(bool isPerform = false)
        {
            /*" -2312- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
            _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

            /*" -2314- MOVE ATACUM-IMPRESSAO TO TACUM-IMPRESSAO */
            _.Move(AREA_DE_WORK.ATACUM_IMPRESSAO, AREA_DE_WORK.TACUM_IMPRESSAO);

            /*" -2317- COMPUTE PRM-TOTAL = PRM-AP(13) + PRM-VG(13). */
            AREA_DE_WORK.PRM_TOTAL.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value;

            /*" -2318- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

            /*" -2319- MOVE W1S-COD-SUBG TO W1SOLF-COD-SUBG */
            _.Move(W1S_COD_SUBG, W1SOLF_COD_SUBG);

            /*" -2321- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
            _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

            /*" -2322- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", AREA_DE_WORK.WFIM_V1FATURAS);

            /*" -2324- PERFORM R1200-00-SELECT-V1FATURA */

            R1200_00_SELECT_V1FATURA_SECTION();

            /*" -2325- IF W1S-TIPO-FAT EQUAL '2' */

            if (W1S_TIPO_FAT == "2")
            {

                /*" -2326- MOVE W1S-COD-FONTE TO V1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, V1SUBG_COD_FONTE);

                /*" -2327- PERFORM R3020-00-GERA-FATURA */

                R3020_00_GERA_FATURA_SECTION();

                /*" -2328- ELSE */
            }
            else
            {


                /*" -2329- MOVE W1S-COD-SUBG TO V1SUBG-COD-SUBG */
                _.Move(W1S_COD_SUBG, V1SUBG_COD_SUBG);

                /*" -2330- MOVE W1S-COD-FONTE TO V1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, V1SUBG_COD_FONTE);

                /*" -2331- MOVE W1S-BCO-COB TO V1SUBG-BCO-COB */
                _.Move(W1S_BCO_COB, V1SUBG_BCO_COB);

                /*" -2332- MOVE W1S-AGE-COB TO V1SUBG-AGE-COB */
                _.Move(W1S_AGE_COB, V1SUBG_AGE_COB);

                /*" -2333- MOVE W1S-DAC-COB TO V1SUBG-DAC-COB */
                _.Move(W1S_DAC_COB, V1SUBG_DAC_COB);

                /*" -2334- MOVE W1S-END-COB TO V1SUBG-END-COB */
                _.Move(W1S_END_COB, V1SUBG_END_COB);

                /*" -2339- PERFORM R3040-00-GERA-FATURA-ENDOSSO. */

                R3040_00_GERA_FATURA_ENDOSSO_SECTION();
            }


            /*" -2341- MOVE SPACES TO WFIM-FATURA-ANT */
            _.Move("", AREA_DE_WORK.WFIM_FATURA_ANT);

            /*" -2342- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA */
            _.Move(V1SOLF_NUM_FAT, AREA_DE_WORK.WNUM_FATURA);

            /*" -2343- IF WFAT-MES EQUAL 01 */

            if (AREA_DE_WORK.FILLER_19.WFAT_MES == 01)
            {

                /*" -2344- MOVE 12 TO WFAT-MES */
                _.Move(12, AREA_DE_WORK.FILLER_19.WFAT_MES);

                /*" -2345- SUBTRACT 1 FROM WFAT-ANO */
                AREA_DE_WORK.FILLER_19.WFAT_ANO.Value = AREA_DE_WORK.FILLER_19.WFAT_ANO - 1;

                /*" -2346- ELSE */
            }
            else
            {


                /*" -2348- SUBTRACT 1 FROM WFAT-MES. */
                AREA_DE_WORK.FILLER_19.WFAT_MES.Value = AREA_DE_WORK.FILLER_19.WFAT_MES - 1;
            }


            /*" -2350- MOVE WNUM-FATURA TO W2SOLF-NUM-FAT */
            _.Move(AREA_DE_WORK.WNUM_FATURA, W2SOLF_NUM_FAT);

            /*" -2352- PERFORM R1280-00-SELECT-V1FATURA-ANT */

            R1280_00_SELECT_V1FATURA_ANT_SECTION();

            /*" -2353- IF WFIM-FATURA-ANT NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_FATURA_ANT.IsEmpty())
            {

                /*" -2354- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

                /*" -2356- MOVE ATACUM-OPERACAO(1) TO TACUM-OPERACAO(1) */
                _.Move(AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[1], AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1]);

                /*" -2358- MOVE W2SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
                _.Move(W2SOLF_NUM_FAT, W1SOLF_NUM_FAT);

                /*" -2360- PERFORM S0300-00-TOTALIZA-FATURA */

                S0300_00_TOTALIZA_FATURA_SECTION();

                /*" -2361- MOVE '0' TO W1ENDO-TIPEND */
                _.Move("0", W1ENDO_TIPEND);

                /*" -2365- MOVE ZEROS TO W1ENDO-NRENDOS W1SUBG-COD-FONTE W1SOLF-NUM-RCAP W1SOLF-VAL-RCAP */
                _.Move(0, W1ENDO_NRENDOS, W1SUBG_COD_FONTE, W1SOLF_NUM_RCAP, W1SOLF_VAL_RCAP);

                /*" -2366- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -2367- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -2368- MOVE -1 TO W1SOLF-DATA-RCAP-I */
                _.Move(-1, W1SOLF_DATA_RCAP_I);

                /*" -2369- MOVE -1 TO W1SOLF-DATA-VENC-I */
                _.Move(-1, W1SOLF_DATA_VENC_I);

                /*" -2370- MOVE W2SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
                _.Move(W2SOLF_NUM_FAT, W1SOLF_NUM_FAT);

                /*" -2372- MOVE ZEROS TO V1SOLF-COD-OPER */
                _.Move(0, V1SOLF_COD_OPER);

                /*" -2373- PERFORM R2100-00-MONTA-V0FATURAS */

                R2100_00_MONTA_V0FATURAS_SECTION();

                /*" -2374- PERFORM R3100-00-INSERT-V0FATURAS */

                R3100_00_INSERT_V0FATURAS_SECTION();

                /*" -2374- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                R2200_00_MONTA_V0FATURASTOT_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-GERA-FATURA-SECTION */
        private void R3020_00_GERA_FATURA_SECTION()
        {
            /*" -2386- MOVE '0' TO W1ENDO-TIPEND */
            _.Move("0", W1ENDO_TIPEND);

            /*" -2387- MOVE V1SUBG-COD-FONTE TO W1SUBG-COD-FONTE */
            _.Move(V1SUBG_COD_FONTE, W1SUBG_COD_FONTE);

            /*" -2390- MOVE ZEROS TO W1ENDO-NRENDOS W1SOLF-NUM-RCAP W1SOLF-VAL-RCAP */
            _.Move(0, W1ENDO_NRENDOS, W1SOLF_NUM_RCAP, W1SOLF_VAL_RCAP);

            /*" -2391- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
            _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

            /*" -2392- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
            _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

            /*" -2393- MOVE -1 TO W1SOLF-DATA-RCAP-I */
            _.Move(-1, W1SOLF_DATA_RCAP_I);

            /*" -2395- MOVE -1 TO W1SOLF-DATA-VENC-I */
            _.Move(-1, W1SOLF_DATA_VENC_I);

            /*" -2396- IF V1SOLF-COD-OPER EQUAL 100 */

            if (V1SOLF_COD_OPER == 100)
            {

                /*" -2397- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -2398- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2399- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2400- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -2401- ELSE */
                }
                else
                {


                    /*" -2402- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -2403- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2404- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2405- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -2405- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-GERA-FATURA-ENDOSSO-SECTION */
        private void R3040_00_GERA_FATURA_ENDOSSO_SECTION()
        {
            /*" -2416- IF V1SOLF-COD-OPER EQUAL 100 */

            if (V1SOLF_COD_OPER == 100)
            {

                /*" -2417- MOVE V1SUBG-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(V1SUBG_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -2419- MOVE ZEROS TO W1SOLF-NUM-RCAP W1SOLF-VAL-RCAP */
                _.Move(0, W1SOLF_NUM_RCAP, W1SOLF_VAL_RCAP);

                /*" -2420- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -2421- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -2422- MOVE -1 TO W1SOLF-DATA-RCAP-I */
                _.Move(-1, W1SOLF_DATA_RCAP_I);

                /*" -2423- MOVE -1 TO W1SOLF-DATA-VENC-I */
                _.Move(-1, W1SOLF_DATA_VENC_I);

                /*" -2424- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -2425- MOVE '0' TO W1ENDO-TIPEND */
                    _.Move("0", W1ENDO_TIPEND);

                    /*" -2426- MOVE ZEROS TO W1ENDO-NRENDOS */
                    _.Move(0, W1ENDO_NRENDOS);

                    /*" -2427- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2428- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2429- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -2430- ELSE */
                }
                else
                {


                    /*" -2431- MOVE V1FATR-TIPO-ENDOS TO W1ENDO-TIPEND */
                    _.Move(V1FATR_TIPO_ENDOS, W1ENDO_TIPEND);

                    /*" -2432- MOVE V1FATR-NUM-ENDOS TO W1ENDO-NRENDOS */
                    _.Move(V1FATR_NUM_ENDOS, W1ENDO_NRENDOS);

                    /*" -2433- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -2434- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2435- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2436- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -2436- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-V0FATURAS-SECTION */
        private void R3100_00_INSERT_V0FATURAS_SECTION()
        {
            /*" -2449- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2469- PERFORM R3100_00_INSERT_V0FATURAS_DB_INSERT_1 */

            R3100_00_INSERT_V0FATURAS_DB_INSERT_1();

            /*" -2472- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2472- ADD +1 TO AC-I-V0FATURAS. */
                AREA_DE_WORK.AC_I_V0FATURAS.Value = AREA_DE_WORK.AC_I_V0FATURAS + +1;
            }


        }

        [StopWatch]
        /*" R3100-00-INSERT-V0FATURAS-DB-INSERT-1 */
        public void R3100_00_INSERT_V0FATURAS_DB_INSERT_1()
        {
            /*" -2469- EXEC SQL INSERT INTO SEGUROS.V0FATURAS VALUES (:V0FATR-NUM-APOL , :V0FATR-COD-SUBG , :V0FATR-NUM-FATUR , :V0FATR-COD-OPER , :V0FATR-TIPO-ENDOS , :V0FATR-NUM-ENDOS , :V0FATR-VAL-FATURA , :V0FATR-COD-FONTE , :V0FATR-NUM-RCAP , :V0FATR-VAL-RCAP , :V0FATR-DATA-INIVIG , :V0FATR-DATA-TERVIG , :V0FATR-SIT-REG , :V0FATR-DATA-FATUR:V0FATR-DATA-FATU-I, :V0FATR-DATA-RCAP:V0FATR-DATA-RCAP-I, :V0FATR-COD-EMPRESA:VIND-COD-EMP, :V0FATR-DATA-VENC:V0FATR-DATA-VENC-I, :V0FATR-VLIOCC) END-EXEC. */

            var r3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1 = new R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1()
            {
                V0FATR_NUM_APOL = V0FATR_NUM_APOL.ToString(),
                V0FATR_COD_SUBG = V0FATR_COD_SUBG.ToString(),
                V0FATR_NUM_FATUR = V0FATR_NUM_FATUR.ToString(),
                V0FATR_COD_OPER = V0FATR_COD_OPER.ToString(),
                V0FATR_TIPO_ENDOS = V0FATR_TIPO_ENDOS.ToString(),
                V0FATR_NUM_ENDOS = V0FATR_NUM_ENDOS.ToString(),
                V0FATR_VAL_FATURA = V0FATR_VAL_FATURA.ToString(),
                V0FATR_COD_FONTE = V0FATR_COD_FONTE.ToString(),
                V0FATR_NUM_RCAP = V0FATR_NUM_RCAP.ToString(),
                V0FATR_VAL_RCAP = V0FATR_VAL_RCAP.ToString(),
                V0FATR_DATA_INIVIG = V0FATR_DATA_INIVIG.ToString(),
                V0FATR_DATA_TERVIG = V0FATR_DATA_TERVIG.ToString(),
                V0FATR_SIT_REG = V0FATR_SIT_REG.ToString(),
                V0FATR_DATA_FATUR = V0FATR_DATA_FATUR.ToString(),
                V0FATR_DATA_FATU_I = V0FATR_DATA_FATU_I.ToString(),
                V0FATR_DATA_RCAP = V0FATR_DATA_RCAP.ToString(),
                V0FATR_DATA_RCAP_I = V0FATR_DATA_RCAP_I.ToString(),
                V0FATR_COD_EMPRESA = V0FATR_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0FATR_DATA_VENC = V0FATR_DATA_VENC.ToString(),
                V0FATR_DATA_VENC_I = V0FATR_DATA_VENC_I.ToString(),
                V0FATR_VLIOCC = V0FATR_VLIOCC.ToString(),
            };

            R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-INSERT-V0FATURASTOT-SECTION */
        private void R3200_00_INSERT_V0FATURASTOT_SECTION()
        {
            /*" -2486- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2504- PERFORM R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1 */

            R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1();

            /*" -2507- ADD +1 TO AC-I-V0FATURASTOT. */
            AREA_DE_WORK.AC_I_V0FATURASTOT.Value = AREA_DE_WORK.AC_I_V0FATURASTOT + +1;

        }

        [StopWatch]
        /*" R3200-00-INSERT-V0FATURASTOT-DB-INSERT-1 */
        public void R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1()
        {
            /*" -2504- EXEC SQL INSERT INTO SEGUROS.V0FATURASTOT VALUES (:V0FATT-NUM-APOL , :V0FATT-COD-SUBG , :V0FATT-NUM-FATUR , :V0FATT-COD-OPER , :V0FATT-QT-VIDA-VG , :V0FATT-QT-VIDA-AP , :V0FATT-IMP-MORNAT , :V0FATT-IMP-MORACI , :V0FATT-IMP-INVPER , :V0FATT-IMP-AMDS , :V0FATT-IMP-DH , :V0FATT-IMP-DIT , :V0FATT-PRM-VG , :V0FATT-PRM-AP , :V0FATT-SIT-REG , :V0FATT-COD-EMPRESA:VIND-COD-EMP) END-EXEC. */

            var r3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1 = new R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1()
            {
                V0FATT_NUM_APOL = V0FATT_NUM_APOL.ToString(),
                V0FATT_COD_SUBG = V0FATT_COD_SUBG.ToString(),
                V0FATT_NUM_FATUR = V0FATT_NUM_FATUR.ToString(),
                V0FATT_COD_OPER = V0FATT_COD_OPER.ToString(),
                V0FATT_QT_VIDA_VG = V0FATT_QT_VIDA_VG.ToString(),
                V0FATT_QT_VIDA_AP = V0FATT_QT_VIDA_AP.ToString(),
                V0FATT_IMP_MORNAT = V0FATT_IMP_MORNAT.ToString(),
                V0FATT_IMP_MORACI = V0FATT_IMP_MORACI.ToString(),
                V0FATT_IMP_INVPER = V0FATT_IMP_INVPER.ToString(),
                V0FATT_IMP_AMDS = V0FATT_IMP_AMDS.ToString(),
                V0FATT_IMP_DH = V0FATT_IMP_DH.ToString(),
                V0FATT_IMP_DIT = V0FATT_IMP_DIT.ToString(),
                V0FATT_PRM_VG = V0FATT_PRM_VG.ToString(),
                V0FATT_PRM_AP = V0FATT_PRM_AP.ToString(),
                V0FATT_SIT_REG = V0FATT_SIT_REG.ToString(),
                V0FATT_COD_EMPRESA = V0FATT_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-SELECT-V1FATURAS-SECTION */
        private void R3500_00_SELECT_V1FATURAS_SECTION()
        {
            /*" -2520- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2529- PERFORM R3500_00_SELECT_V1FATURAS_DB_SELECT_1 */

            R3500_00_SELECT_V1FATURAS_DB_SELECT_1();

            /*" -2532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2536- DISPLAY 'ERRO  SELECT V1FATURAS...' ' ' W1SOLF-NUM-APOL ' ' W1SOLF-COD-SUBG ' ' W1SOLF-NUM-FAT */

                $"ERRO  SELECT V1FATURAS... {W1SOLF_NUM_APOL} {W1SOLF_COD_SUBG} {W1SOLF_NUM_FAT}"
                .Display();

                /*" -2536- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3500-00-SELECT-V1FATURAS-DB-SELECT-1 */
        public void R3500_00_SELECT_V1FATURAS_DB_SELECT_1()
        {
            /*" -2529- EXEC SQL SELECT DATA_INIVIGENCIA , DATA_TERVIGENCIA INTO :V1FATR-DATA-INIVIG , :V1FATR-DATA-TERVIG FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

            var r3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 = new R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
                W1SOLF_NUM_FAT = W1SOLF_NUM_FAT.ToString(),
            };

            var executed_1 = R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1.Execute(r3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_DATA_INIVIG, V1FATR_DATA_INIVIG);
                _.Move(executed_1.V1FATR_DATA_TERVIG, V1FATR_DATA_TERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-DELETE-V0FATURASTOT-SECTION */
        private void R4100_00_DELETE_V0FATURASTOT_SECTION()
        {
            /*" -2552- MOVE '410' TO WNR-EXEC-SQL */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2556- PERFORM R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1 */

            R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1();

            /*" -2559- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2563- DISPLAY 'ERRO DELETE V0FATURASTOT ... ' ' ' W1SOLF-NUM-APOL ' ' W1SOLF-COD-SUBG ' ' W1SOLF-NUM-FAT */

                $"ERRO DELETE V0FATURASTOT ...  {W1SOLF_NUM_APOL} {W1SOLF_COD_SUBG} {W1SOLF_NUM_FAT}"
                .Display();

                /*" -2565- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2565- ADD +1 TO AC-D-V0FATURTOT. */
            AREA_DE_WORK.AC_D_V0FATURTOT.Value = AREA_DE_WORK.AC_D_V0FATURTOT + +1;

        }

        [StopWatch]
        /*" R4100-00-DELETE-V0FATURASTOT-DB-DELETE-1 */
        public void R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1()
        {
            /*" -2556- EXEC SQL DELETE FROM SEGUROS.V0FATURASTOT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

            var r4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1 = new R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
                W1SOLF_NUM_FAT = W1SOLF_NUM_FAT.ToString(),
            };

            R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1.Execute(r4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-DELETE-V0FATURAS-SECTION */
        private void R5100_00_DELETE_V0FATURAS_SECTION()
        {
            /*" -2579- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2584- PERFORM R5100_00_DELETE_V0FATURAS_DB_DELETE_1 */

            R5100_00_DELETE_V0FATURAS_DB_DELETE_1();

            /*" -2587- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2591- DISPLAY 'R5100-00 (PROBLEMAS DELETE V0FATURAS) ... ' ' ' W1SOLF-NUM-APOL ' ' W1SOLF-COD-SUBG ' ' W1SOLF-NUM-FAT */

                $"R5100-00 (PROBLEMAS DELETE V0FATURAS) ...  {W1SOLF_NUM_APOL} {W1SOLF_COD_SUBG} {W1SOLF_NUM_FAT}"
                .Display();

                /*" -2593- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2593- ADD +1 TO AC-A-V0FATURAS. */
            AREA_DE_WORK.AC_A_V0FATURAS.Value = AREA_DE_WORK.AC_A_V0FATURAS + +1;

        }

        [StopWatch]
        /*" R5100-00-DELETE-V0FATURAS-DB-DELETE-1 */
        public void R5100_00_DELETE_V0FATURAS_DB_DELETE_1()
        {
            /*" -2584- EXEC SQL DELETE FROM SEGUROS.V0FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

            var r5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1 = new R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
                W1SOLF_NUM_FAT = W1SOLF_NUM_FAT.ToString(),
            };

            R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1.Execute(r5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-UPDATE-V0SOLICFAT-SECTION */
        private void R5300_00_UPDATE_V0SOLICFAT_SECTION()
        {
            /*" -2607- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2609- MOVE '1' TO V1SOLF-SIT-REG */
            _.Move("1", V1SOLF_SIT_REG);

            /*" -2618- PERFORM R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1 */

            R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1();

            /*" -2621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2625- DISPLAY 'R5300-00 (PROBLEMAS UPDATE V0SOLICFAT) ... ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG ' ' V1SOLF-NUM-FAT */

                $"R5300-00 (PROBLEMAS UPDATE V0SOLICFAT) ...  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG} {V1SOLF_NUM_FAT}"
                .Display();

                /*" -2627- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2627- ADD +1 TO AC-A-V0SOLICFAT. */
            AREA_DE_WORK.AC_A_V0SOLICFAT.Value = AREA_DE_WORK.AC_A_V0SOLICFAT + +1;

        }

        [StopWatch]
        /*" R5300-00-UPDATE-V0SOLICFAT-DB-UPDATE-1 */
        public void R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1()
        {
            /*" -2618- EXEC SQL UPDATE SEGUROS.V0SOLICITAFAT SET SIT_REGISTRO = :V1SOLF-SIT-REG, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG AND NUM_FATURA = :V1SOLF-NUM-FAT AND (SIT_REGISTRO = '3' OR SIT_REGISTRO = '0' ) END-EXEC. */

            var r5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1 = new R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1()
            {
                V1SOLF_SIT_REG = V1SOLF_SIT_REG.ToString(),
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
                V1SOLF_NUM_FAT = V1SOLF_NUM_FAT.ToString(),
            };

            R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1.Execute(r5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2641- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -2642- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_29.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -2643- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_29.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -2645- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_29.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -2646- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2647- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2648- DISPLAY '*   VG0105B - F A T U R A M E N T O        *' */
            _.Display($"*   VG0105B - F A T U R A M E N T O        *");

            /*" -2649- DISPLAY '*   -------   - - - - - - - - - - -        *' */
            _.Display($"*   -------   - - - - - - - - - - -        *");

            /*" -2650- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2651- DISPLAY '*   NAO HOUVE SOLICITACAO                  *' */
            _.Display($"*   NAO HOUVE SOLICITACAO                  *");

            /*" -2653- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -2654- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2654- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-TOTALIZA-MOVIMENTO-SECTION */
        private void R6000_00_TOTALIZA_MOVIMENTO_SECTION()
        {
            /*" -2666- IF V1SOLF-COD-SUBG EQUAL ZEROS */

            if (V1SOLF_COD_SUBG == 00)
            {

                /*" -2668- IF W1S-TIPO-FAT EQUAL '2' OR '3' */

                if (W1S_TIPO_FAT.In("2", "3"))
                {

                    /*" -2669- MOVE 0001 TO W1SUB-GRUPO */
                    _.Move(0001, W1SUB_GRUPO);

                    /*" -2670- MOVE 9999 TO W2SUB-GRUPO */
                    _.Move(9999, W2SUB_GRUPO);

                    /*" -2672- ELSE */
                }
                else
                {


                    /*" -2673- MOVE 0001 TO W1SUB-GRUPO */
                    _.Move(0001, W1SUB_GRUPO);

                    /*" -2674- MOVE 9999 TO W2SUB-GRUPO */
                    _.Move(9999, W2SUB_GRUPO);

                    /*" -2676- ELSE */
                }

            }
            else
            {


                /*" -2677- MOVE W1SOLF-COD-SUBG TO W1SUB-GRUPO */
                _.Move(W1SOLF_COD_SUBG, W1SUB_GRUPO);

                /*" -2679- MOVE W1SOLF-COD-SUBG TO W2SUB-GRUPO. */
                _.Move(W1SOLF_COD_SUBG, W2SUB_GRUPO);
            }


            /*" -2679- PERFORM R6100-00-DECLARE-V0MOVIMENTO. */

            R6100_00_DECLARE_V0MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-DECLARE-V0MOVIMENTO-SECTION */
        private void R6100_00_DECLARE_V0MOVIMENTO_SECTION()
        {
            /*" -2690- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -2693- MOVE '610' TO WNR-EXEC-SQL. */
            _.Move("610", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2720- PERFORM R6100_00_DECLARE_V0MOVIMENTO_DB_DECLARE_1 */

            R6100_00_DECLARE_V0MOVIMENTO_DB_DECLARE_1();

            /*" -2722- PERFORM R6100_00_DECLARE_V0MOVIMENTO_DB_OPEN_1 */

            R6100_00_DECLARE_V0MOVIMENTO_DB_OPEN_1();

            /*" -2725- PERFORM R6150-00-FETCH-MOVIMENTO UNTIL WFIM-MOVIMENTO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_MOVIMENTO == "S"))
            {

                R6150_00_FETCH_MOVIMENTO_SECTION();
            }

        }

        [StopWatch]
        /*" R6100-00-DECLARE-V0MOVIMENTO-DB-OPEN-1 */
        public void R6100_00_DECLARE_V0MOVIMENTO_DB_OPEN_1()
        {
            /*" -2722- EXEC SQL OPEN MOVIMENTO END-EXEC. */

            MOVIMENTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6150-00-FETCH-MOVIMENTO-SECTION */
        private void R6150_00_FETCH_MOVIMENTO_SECTION()
        {
            /*" -2738- MOVE '615' TO WNR-EXEC-SQL. */
            _.Move("615", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2757- PERFORM R6150_00_FETCH_MOVIMENTO_DB_FETCH_1 */

            R6150_00_FETCH_MOVIMENTO_DB_FETCH_1();

            /*" -2760- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2761- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -2761- PERFORM R6150_00_FETCH_MOVIMENTO_DB_CLOSE_1 */

                R6150_00_FETCH_MOVIMENTO_DB_CLOSE_1();

                /*" -2763- ELSE */
            }
            else
            {


                /*" -2764- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2765- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -2765- PERFORM R6150_00_FETCH_MOVIMENTO_DB_CLOSE_2 */

                    R6150_00_FETCH_MOVIMENTO_DB_CLOSE_2();

                    /*" -2767- ELSE */
                }
                else
                {


                    /*" -2767- PERFORM R6200-00-VERDATA. */

                    R6200_00_VERDATA_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R6150-00-FETCH-MOVIMENTO-DB-FETCH-1 */
        public void R6150_00_FETCH_MOVIMENTO_DB_FETCH_1()
        {
            /*" -2757- EXEC SQL FETCH MOVIMENTO INTO :V0MOVI-MORNATU-ANT , :V0MOVI-MORNATU-ATU , :V0MOVI-MORACID-ANT , :V0MOVI-MORACID-ATU , :V0MOVI-INVPERM-ANT , :V0MOVI-INVPERM-ATU , :V0MOVI-AMDS-ANT , :V0MOVI-AMDS-ATU , :V0MOVI-DH-ANT , :V0MOVI-DH-ATU , :V0MOVI-DIT-ANT , :V0MOVI-DIT-ATU , :V0MOVI-VG-ANT , :V0MOVI-VG-ATU , :V0MOVI-AP-ANT , :V0MOVI-AP-ATU , :V0MOVI-COD-OPER , :V0MOVI-DATA-MOVI END-EXEC. */

            if (MOVIMENTO.Fetch())
            {
                _.Move(MOVIMENTO.V0MOVI_MORNATU_ANT, V0MOVI_MORNATU_ANT);
                _.Move(MOVIMENTO.V0MOVI_MORNATU_ATU, V0MOVI_MORNATU_ATU);
                _.Move(MOVIMENTO.V0MOVI_MORACID_ANT, V0MOVI_MORACID_ANT);
                _.Move(MOVIMENTO.V0MOVI_MORACID_ATU, V0MOVI_MORACID_ATU);
                _.Move(MOVIMENTO.V0MOVI_INVPERM_ANT, V0MOVI_INVPERM_ANT);
                _.Move(MOVIMENTO.V0MOVI_INVPERM_ATU, V0MOVI_INVPERM_ATU);
                _.Move(MOVIMENTO.V0MOVI_AMDS_ANT, V0MOVI_AMDS_ANT);
                _.Move(MOVIMENTO.V0MOVI_AMDS_ATU, V0MOVI_AMDS_ATU);
                _.Move(MOVIMENTO.V0MOVI_DH_ANT, V0MOVI_DH_ANT);
                _.Move(MOVIMENTO.V0MOVI_DH_ATU, V0MOVI_DH_ATU);
                _.Move(MOVIMENTO.V0MOVI_DIT_ANT, V0MOVI_DIT_ANT);
                _.Move(MOVIMENTO.V0MOVI_DIT_ATU, V0MOVI_DIT_ATU);
                _.Move(MOVIMENTO.V0MOVI_VG_ANT, V0MOVI_VG_ANT);
                _.Move(MOVIMENTO.V0MOVI_VG_ATU, V0MOVI_VG_ATU);
                _.Move(MOVIMENTO.V0MOVI_AP_ANT, V0MOVI_AP_ANT);
                _.Move(MOVIMENTO.V0MOVI_AP_ATU, V0MOVI_AP_ATU);
                _.Move(MOVIMENTO.V0MOVI_COD_OPER, V0MOVI_COD_OPER);
                _.Move(MOVIMENTO.V0MOVI_DATA_MOVI, V0MOVI_DATA_MOVI);
            }

        }

        [StopWatch]
        /*" R6150-00-FETCH-MOVIMENTO-DB-CLOSE-1 */
        public void R6150_00_FETCH_MOVIMENTO_DB_CLOSE_1()
        {
            /*" -2761- EXEC SQL CLOSE MOVIMENTO END-EXEC */

            MOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_99_SAIDA*/

        [StopWatch]
        /*" R6150-00-FETCH-MOVIMENTO-DB-CLOSE-2 */
        public void R6150_00_FETCH_MOVIMENTO_DB_CLOSE_2()
        {
            /*" -2765- EXEC SQL CLOSE MOVIMENTO END-EXEC */

            MOVIMENTO.Close();

        }

        [StopWatch]
        /*" R6200-00-VERDATA-SECTION */
        private void R6200_00_VERDATA_SECTION()
        {
            /*" -2781- MOVE '620' TO WNR-EXEC-SQL. */
            _.Move("620", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2782- MOVE V1FATC-DATA-REFER TO CLANOMES */
            _.Move(V1FATC_DATA_REFER, AREA_DE_WORK.CLANOMES);

            /*" -2783- MOVE CLANO TO CLANO2 */
            _.Move(AREA_DE_WORK.CLANOMES.CLANO, AREA_DE_WORK.FILLER_9.CLANO2);

            /*" -2784- MOVE CLMES TO CLMES2 */
            _.Move(AREA_DE_WORK.CLANOMES.CLMES, AREA_DE_WORK.FILLER_9.CLMES2);

            /*" -2785- MOVE V0MOVI-DATA-MOVI TO CLANOMES */
            _.Move(V0MOVI_DATA_MOVI, AREA_DE_WORK.CLANOMES);

            /*" -2786- MOVE CLANO TO CLANO1 */
            _.Move(AREA_DE_WORK.CLANOMES.CLANO, AREA_DE_WORK.FILLER_8.CLANO1);

            /*" -2788- MOVE CLMES TO CLMES1. */
            _.Move(AREA_DE_WORK.CLANOMES.CLMES, AREA_DE_WORK.FILLER_8.CLMES1);

            /*" -2790- IF CLDATA1 GREATER CLDATA2 NEXT SENTENCE */

            if (AREA_DE_WORK.CLDATA1 > AREA_DE_WORK.CLDATA2)
            {

                /*" -2791- ELSE */
            }
            else
            {


                /*" -2791- PERFORM R6250-00-PROC-DATA. */

                R6250_00_PROC_DATA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6250-00-PROC-DATA-SECTION */
        private void R6250_00_PROC_DATA_SECTION()
        {
            /*" -2801- MOVE '625' TO WNR-EXEC-SQL. */
            _.Move("625", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2802- IF CLANO1 NOT EQUAL CLANO2 */

            if (AREA_DE_WORK.FILLER_8.CLANO1 != AREA_DE_WORK.FILLER_9.CLANO2)
            {

                /*" -2803- COMPUTE CLACUM1 = CLANO2 - CLANO1 */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.FILLER_9.CLANO2 - AREA_DE_WORK.FILLER_8.CLANO1;

                /*" -2804- COMPUTE CLACUM1 = CLACUM1 * 12 */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.CLACUM1 * 12;

                /*" -2805- COMPUTE CLACUM2 = CLMES2 - CLMES1 */
                AREA_DE_WORK.CLACUM2.Value = AREA_DE_WORK.FILLER_9.CLMES2 - AREA_DE_WORK.FILLER_8.CLMES1;

                /*" -2806- COMPUTE CLACUM1 = CLACUM1 + CLACUM2 */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.CLACUM1 + AREA_DE_WORK.CLACUM2;

                /*" -2807- ELSE */
            }
            else
            {


                /*" -2809- COMPUTE CLACUM1 = CLMES2 - CLMES1. */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.FILLER_9.CLMES2 - AREA_DE_WORK.FILLER_8.CLMES1;
            }


            /*" -2809- PERFORM R6300-00-MONTA-TABELA. */

            R6300_00_MONTA_TABELA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6250_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-MONTA-TABELA-SECTION */
        private void R6300_00_MONTA_TABELA_SECTION()
        {
            /*" -2821- MOVE '630' TO WNR-EXEC-SQL. */
            _.Move("630", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2822- MOVE SPACES TO WSOUTROS */
            _.Move("", AREA_DE_WORK.WSOUTROS);

            /*" -2827- MOVE 'SIM' TO WS-SOMA. */
            _.Move("SIM", AREA_DE_WORK.WS_SOMA);

            /*" -2831- IF (V0MOVI-COD-OPER GREATER 99 AND V0MOVI-COD-OPER LESS 200) OR (V0MOVI-COD-OPER GREATER 499 AND V0MOVI-COD-OPER LESS 600) */

            if ((V0MOVI_COD_OPER > 99 && V0MOVI_COD_OPER < 200) || (V0MOVI_COD_OPER > 499 && V0MOVI_COD_OPER < 600))
            {

                /*" -2832- MOVE W1SOLF-NUM-APOL TO NUM-APOL(2) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].NUM_APOL);

                /*" -2833- MOVE W1SOLF-COD-SUBG TO COD-SUBG(2) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].COD_SUBG);

                /*" -2834- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(2) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].NUM_FATUR);

                /*" -2835- MOVE 0100 TO COD-OPER(2) */
                _.Move(0100, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].COD_OPER);

                /*" -2837- COMPUTE IMP-MORNAT(02) = IMP-MORNAT(02) + V0MOVI-MORNATU-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -2839- COMPUTE IMP-MORACI(02) = IMP-MORACI(02) + V0MOVI-MORACID-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -2841- COMPUTE IMP-INVPER(02) = IMP-INVPER(02) + V0MOVI-INVPERM-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -2843- COMPUTE IMP-AMDS(02) = IMP-AMDS(02) + V0MOVI-AMDS-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -2845- COMPUTE IMP-DH(02) = IMP-DH(02) + V0MOVI-DH-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -2847- COMPUTE IMP-DIT(02) = IMP-DIT(02) + V0MOVI-DIT-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -2849- COMPUTE PRM-VG(02) = PRM-VG(02) + V0MOVI-VG-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -2852- COMPUTE PRM-AP(02) = PRM-AP(02) + V0MOVI-AP-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -2853- MOVE 'DEB' TO WSOUTROS */
                _.Move("DEB", AREA_DE_WORK.WSOUTROS);

                /*" -2854- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, AREA_DE_WORK.OUT_IMP_MORNAT);

                /*" -2855- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, AREA_DE_WORK.OUT_IMP_MORACI);

                /*" -2856- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, AREA_DE_WORK.OUT_IMP_INVPER);

                /*" -2857- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, AREA_DE_WORK.OUT_IMP_AMDS);

                /*" -2858- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, AREA_DE_WORK.OUT_IMP_DH);

                /*" -2859- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, AREA_DE_WORK.OUT_IMP_DIT);

                /*" -2860- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, AREA_DE_WORK.OUT_PRM_VG);

                /*" -2862- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, AREA_DE_WORK.OUT_PRM_AP);

                /*" -2863- IF PRM-VG(02) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_VG != 00)
                {

                    /*" -2864- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -2865- ADD 1 TO QT-VIDA-VG(02) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_VG + 1;

                    /*" -2866- IF PRM-AP(02) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP != 00)
                    {

                        /*" -2867- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2868- ADD 1 TO QT-VIDA-AP(02) */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP + 1;

                        /*" -2869- ELSE */
                    }
                    else
                    {


                        /*" -2870- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2871- ELSE */
                    }

                }
                else
                {


                    /*" -2872- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -2873- IF PRM-AP(02) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP != 00)
                    {

                        /*" -2874- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2879- ADD 1 TO QT-VIDA-AP(02). */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -2881- IF V0MOVI-COD-OPER GREATER 799 AND V0MOVI-COD-OPER LESS 900 */

            if (V0MOVI_COD_OPER > 799 && V0MOVI_COD_OPER < 900)
            {

                /*" -2882- MOVE W1SOLF-NUM-APOL TO NUM-APOL(3) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].NUM_APOL);

                /*" -2883- MOVE W1SOLF-COD-SUBG TO COD-SUBG(3) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].COD_SUBG);

                /*" -2884- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(3) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].NUM_FATUR);

                /*" -2885- MOVE 0200 TO COD-OPER(3) */
                _.Move(0200, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].COD_OPER);

                /*" -2888- COMPUTE IMP-MORNAT(03) = IMP-MORNAT(03) + (V0MOVI-MORNATU-ATU - V0MOVI-MORNATU-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORNAT.Value + (V0MOVI_MORNATU_ATU - V0MOVI_MORNATU_ANT);

                /*" -2891- COMPUTE IMP-MORACI(03) = IMP-MORACI(03) + (V0MOVI-MORACID-ATU - V0MOVI-MORACID-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORACI.Value + (V0MOVI_MORACID_ATU - V0MOVI_MORACID_ANT);

                /*" -2894- COMPUTE IMP-INVPER(03) = IMP-INVPER(03) + (V0MOVI-INVPERM-ATU - V0MOVI-INVPERM-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_INVPER.Value + (V0MOVI_INVPERM_ATU - V0MOVI_INVPERM_ANT);

                /*" -2897- COMPUTE IMP-AMDS(03) = IMP-AMDS(03) + (V0MOVI-AMDS-ATU - V0MOVI-AMDS-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_AMDS.Value + (V0MOVI_AMDS_ATU - V0MOVI_AMDS_ANT);

                /*" -2900- COMPUTE IMP-DH(03) = IMP-DH(03) + (V0MOVI-DH-ATU - V0MOVI-DH-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DH.Value + (V0MOVI_DH_ATU - V0MOVI_DH_ANT);

                /*" -2903- COMPUTE IMP-DIT(03) = IMP-DIT(03) + (V0MOVI-DIT-ATU - V0MOVI-DIT-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DIT.Value + (V0MOVI_DIT_ATU - V0MOVI_DIT_ANT);

                /*" -2906- COMPUTE PRM-VG(03) = PRM-VG(03) + (V0MOVI-VG-ATU - V0MOVI-VG-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_VG.Value + (V0MOVI_VG_ATU - V0MOVI_VG_ANT);

                /*" -2910- COMPUTE PRM-AP(03) = PRM-AP(03) + (V0MOVI-AP-ATU - V0MOVI-AP-ANT) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP.Value + (V0MOVI_AP_ATU - V0MOVI_AP_ANT);

                /*" -2911- MOVE 'NAO' TO WS-SOMA */
                _.Move("NAO", AREA_DE_WORK.WS_SOMA);

                /*" -2912- MOVE 'DEB' TO WSOUTROS */
                _.Move("DEB", AREA_DE_WORK.WSOUTROS);

                /*" -2914- COMPUTE OUT-IMP-MORNAT = V0MOVI-MORNATU-ATU - V0MOVI-MORNATU-ANT */
                AREA_DE_WORK.OUT_IMP_MORNAT.Value = V0MOVI_MORNATU_ATU - V0MOVI_MORNATU_ANT;

                /*" -2916- COMPUTE OUT-IMP-MORACI = V0MOVI-MORACID-ATU - V0MOVI-MORACID-ANT */
                AREA_DE_WORK.OUT_IMP_MORACI.Value = V0MOVI_MORACID_ATU - V0MOVI_MORACID_ANT;

                /*" -2918- COMPUTE OUT-IMP-INVPER = V0MOVI-INVPERM-ATU - V0MOVI-INVPERM-ANT */
                AREA_DE_WORK.OUT_IMP_INVPER.Value = V0MOVI_INVPERM_ATU - V0MOVI_INVPERM_ANT;

                /*" -2920- COMPUTE OUT-IMP-AMDS = V0MOVI-AMDS-ATU - V0MOVI-AMDS-ANT */
                AREA_DE_WORK.OUT_IMP_AMDS.Value = V0MOVI_AMDS_ATU - V0MOVI_AMDS_ANT;

                /*" -2922- COMPUTE OUT-IMP-DH = V0MOVI-DH-ATU - V0MOVI-DH-ANT */
                AREA_DE_WORK.OUT_IMP_DH.Value = V0MOVI_DH_ATU - V0MOVI_DH_ANT;

                /*" -2924- COMPUTE OUT-IMP-DIT = V0MOVI-DIT-ATU - V0MOVI-DIT-ANT */
                AREA_DE_WORK.OUT_IMP_DIT.Value = V0MOVI_DIT_ATU - V0MOVI_DIT_ANT;

                /*" -2926- COMPUTE OUT-PRM-VG = V0MOVI-VG-ATU - V0MOVI-VG-ANT */
                AREA_DE_WORK.OUT_PRM_VG.Value = V0MOVI_VG_ATU - V0MOVI_VG_ANT;

                /*" -2929- COMPUTE OUT-PRM-AP = V0MOVI-AP-ATU - V0MOVI-AP-ANT */
                AREA_DE_WORK.OUT_PRM_AP.Value = V0MOVI_AP_ATU - V0MOVI_AP_ANT;

                /*" -2930- IF PRM-VG(03) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_VG != 00)
                {

                    /*" -2932- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -2933- IF PRM-AP(03) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP != 00)
                    {

                        /*" -2935- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2936- ELSE */
                    }
                    else
                    {


                        /*" -2937- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2938- ELSE */
                    }

                }
                else
                {


                    /*" -2939- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -2940- IF PRM-AP(03) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP != 00)
                    {

                        /*" -2946- MOVE 1 TO OUT-QT-VIDA-AP. */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);
                    }

                }

            }


            /*" -2948- IF V0MOVI-COD-OPER GREATER 199 AND V0MOVI-COD-OPER LESS 300 */

            if (V0MOVI_COD_OPER > 199 && V0MOVI_COD_OPER < 300)
            {

                /*" -2949- MOVE W1SOLF-NUM-APOL TO NUM-APOL(4) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].NUM_APOL);

                /*" -2950- MOVE W1SOLF-COD-SUBG TO COD-SUBG(4) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].COD_SUBG);

                /*" -2951- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(4) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].NUM_FATUR);

                /*" -2952- MOVE 0300 TO COD-OPER(4) */
                _.Move(0300, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].COD_OPER);

                /*" -2954- COMPUTE IMP-MORNAT(04) = IMP-MORNAT(04) + V0MOVI-MORNATU-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -2956- COMPUTE IMP-MORACI(04) = IMP-MORACI(04) + V0MOVI-MORACID-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -2958- COMPUTE IMP-INVPER(04) = IMP-INVPER(04) + V0MOVI-INVPERM-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -2960- COMPUTE IMP-AMDS(04) = IMP-AMDS(04) + V0MOVI-AMDS-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -2962- COMPUTE IMP-DH(04) = IMP-DH(04) + V0MOVI-DH-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -2964- COMPUTE IMP-DIT(04) = IMP-DIT(04) + V0MOVI-DIT-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -2966- COMPUTE PRM-VG(04) = PRM-VG(04) + V0MOVI-VG-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -2968- COMPUTE PRM-AP(04) = PRM-AP(04) + V0MOVI-AP-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -2969- MOVE 'DEB' TO WSOUTROS */
                _.Move("DEB", AREA_DE_WORK.WSOUTROS);

                /*" -2970- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, AREA_DE_WORK.OUT_IMP_MORNAT);

                /*" -2971- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, AREA_DE_WORK.OUT_IMP_MORACI);

                /*" -2972- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, AREA_DE_WORK.OUT_IMP_INVPER);

                /*" -2973- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, AREA_DE_WORK.OUT_IMP_AMDS);

                /*" -2974- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, AREA_DE_WORK.OUT_IMP_DH);

                /*" -2975- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, AREA_DE_WORK.OUT_IMP_DIT);

                /*" -2976- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, AREA_DE_WORK.OUT_PRM_VG);

                /*" -2978- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, AREA_DE_WORK.OUT_PRM_AP);

                /*" -2979- IF PRM-VG(04) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_VG != 00)
                {

                    /*" -2980- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -2981- ADD 1 TO QT-VIDA-VG(04) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_VG + 1;

                    /*" -2982- IF PRM-AP(04) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP != 00)
                    {

                        /*" -2983- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2984- ADD 1 TO QT-VIDA-AP(04) */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP + 1;

                        /*" -2985- ELSE */
                    }
                    else
                    {


                        /*" -2986- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2987- ELSE */
                    }

                }
                else
                {


                    /*" -2988- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -2989- IF PRM-AP(04) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP != 00)
                    {

                        /*" -2990- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -2996- ADD 1 TO QT-VIDA-AP(04). */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -2997- IF WSOUTROS EQUAL 'DEB' */

            if (AREA_DE_WORK.WSOUTROS == "DEB")
            {

                /*" -2999- IF OUT-QT-VIDA-VG NOT EQUAL ZEROS OR OUT-QT-VIDA-AP NOT EQUAL ZEROS */

                if (AREA_DE_WORK.OUT_QT_VIDA_VG != 00 || AREA_DE_WORK.OUT_QT_VIDA_AP != 00)
                {

                    /*" -3000- MOVE W1SOLF-NUM-APOL TO NUM-APOL(6) */
                    _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].NUM_APOL);

                    /*" -3001- MOVE W1SOLF-COD-SUBG TO COD-SUBG(6) */
                    _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].COD_SUBG);

                    /*" -3002- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(6) */
                    _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].NUM_FATUR);

                    /*" -3021- MOVE 0500 TO COD-OPER(6) */
                    _.Move(0500, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].COD_OPER);

                    /*" -3024- COMPUTE PRM-VG(06) = PRM-VG(06) + (OUT-PRM-VG * CLACUM1) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_VG.Value + (AREA_DE_WORK.OUT_PRM_VG * AREA_DE_WORK.CLACUM1);

                    /*" -3035- COMPUTE PRM-AP(06) = PRM-AP(06) + (OUT-PRM-AP * CLACUM1). */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_AP.Value + (AREA_DE_WORK.OUT_PRM_AP * AREA_DE_WORK.CLACUM1);
                }

            }


            /*" -3038- IF (V0MOVI-COD-OPER GREATER 399 AND V0MOVI-COD-OPER LESS 500) AND V0MOVI-COD-OPER NOT EQUAL 402 */

            if ((V0MOVI_COD_OPER > 399 && V0MOVI_COD_OPER < 500) && V0MOVI_COD_OPER != 402)
            {

                /*" -3039- MOVE W1SOLF-NUM-APOL TO NUM-APOL(7) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].NUM_APOL);

                /*" -3040- MOVE W1SOLF-COD-SUBG TO COD-SUBG(7) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].COD_SUBG);

                /*" -3041- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(7) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].NUM_FATUR);

                /*" -3042- MOVE 1100 TO COD-OPER(7) */
                _.Move(1100, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].COD_OPER);

                /*" -3044- COMPUTE IMP-MORNAT(07) = IMP-MORNAT(07) + V0MOVI-MORNATU-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -3046- COMPUTE IMP-MORACI(07) = IMP-MORACI(07) + V0MOVI-MORACID-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -3048- COMPUTE IMP-INVPER(07) = IMP-INVPER(07) + V0MOVI-INVPERM-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -3050- COMPUTE IMP-AMDS(07) = IMP-AMDS(07) + V0MOVI-AMDS-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -3052- COMPUTE IMP-DH(07) = IMP-DH(07) + V0MOVI-DH-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -3054- COMPUTE IMP-DIT(07) = IMP-DIT(07) + V0MOVI-DIT-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -3056- COMPUTE PRM-VG(07) = PRM-VG(07) + V0MOVI-VG-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -3058- COMPUTE PRM-AP(07) = PRM-AP(07) + V0MOVI-AP-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -3059- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -3060- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, AREA_DE_WORK.OUT_IMP_MORNAT);

                /*" -3061- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, AREA_DE_WORK.OUT_IMP_MORACI);

                /*" -3062- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, AREA_DE_WORK.OUT_IMP_INVPER);

                /*" -3063- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, AREA_DE_WORK.OUT_IMP_AMDS);

                /*" -3064- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, AREA_DE_WORK.OUT_IMP_DH);

                /*" -3065- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, AREA_DE_WORK.OUT_IMP_DIT);

                /*" -3066- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, AREA_DE_WORK.OUT_PRM_VG);

                /*" -3068- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, AREA_DE_WORK.OUT_PRM_AP);

                /*" -3069- IF PRM-VG(07) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_VG != 00)
                {

                    /*" -3070- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3071- ADD 1 TO QT-VIDA-VG(07) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_VG + 1;

                    /*" -3072- IF PRM-AP(07) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP != 00)
                    {

                        /*" -3073- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3074- ADD 1 TO QT-VIDA-AP(07) */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP + 1;

                        /*" -3075- ELSE */
                    }
                    else
                    {


                        /*" -3076- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3077- ELSE */
                    }

                }
                else
                {


                    /*" -3078- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3079- IF PRM-AP(07) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP != 00)
                    {

                        /*" -3080- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3086- ADD 1 TO QT-VIDA-AP(07). */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -3087- IF V0MOVI-COD-OPER EQUAL 402 */

            if (V0MOVI_COD_OPER == 402)
            {

                /*" -3088- MOVE W1SOLF-NUM-APOL TO NUM-APOL(8) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].NUM_APOL);

                /*" -3089- MOVE W1SOLF-COD-SUBG TO COD-SUBG(8) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].COD_SUBG);

                /*" -3090- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(8) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].NUM_FATUR);

                /*" -3091- MOVE 1200 TO COD-OPER(8) */
                _.Move(1200, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].COD_OPER);

                /*" -3093- COMPUTE IMP-MORNAT(08) = IMP-MORNAT(08) + V0MOVI-MORNATU-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -3095- COMPUTE IMP-MORACI(08) = IMP-MORACI(08) + V0MOVI-MORACID-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -3097- COMPUTE IMP-INVPER(08) = IMP-INVPER(08) + V0MOVI-INVPERM-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -3099- COMPUTE IMP-AMDS(08) = IMP-AMDS(08) + V0MOVI-AMDS-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -3101- COMPUTE IMP-DH(08) = IMP-DH(08) + V0MOVI-DH-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -3103- COMPUTE IMP-DIT(08) = IMP-DIT(08) + V0MOVI-DIT-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -3105- COMPUTE PRM-VG(08) = PRM-VG(08) + V0MOVI-VG-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -3107- COMPUTE PRM-AP(08) = PRM-AP(08) + V0MOVI-AP-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -3108- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -3109- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, AREA_DE_WORK.OUT_IMP_MORNAT);

                /*" -3110- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, AREA_DE_WORK.OUT_IMP_MORACI);

                /*" -3111- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, AREA_DE_WORK.OUT_IMP_INVPER);

                /*" -3112- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, AREA_DE_WORK.OUT_IMP_AMDS);

                /*" -3113- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, AREA_DE_WORK.OUT_IMP_DH);

                /*" -3114- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, AREA_DE_WORK.OUT_IMP_DIT);

                /*" -3115- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, AREA_DE_WORK.OUT_PRM_VG);

                /*" -3117- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, AREA_DE_WORK.OUT_PRM_AP);

                /*" -3118- IF PRM-VG(08) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_VG != 00)
                {

                    /*" -3119- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3120- ADD 1 TO QT-VIDA-VG(08) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_VG + 1;

                    /*" -3121- IF PRM-AP(08) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP != 00)
                    {

                        /*" -3122- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3123- ADD 1 TO QT-VIDA-AP(08) */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP + 1;

                        /*" -3124- ELSE */
                    }
                    else
                    {


                        /*" -3125- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3126- ELSE */
                    }

                }
                else
                {


                    /*" -3127- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3128- IF PRM-AP(08) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP != 00)
                    {

                        /*" -3129- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3133- ADD 1 TO QT-VIDA-AP(08). */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -3135- IF V0MOVI-COD-OPER GREATER 699 AND V0MOVI-COD-OPER LESS 800 */

            if (V0MOVI_COD_OPER > 699 && V0MOVI_COD_OPER < 800)
            {

                /*" -3136- MOVE W1SOLF-NUM-APOL TO NUM-APOL(9) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].NUM_APOL);

                /*" -3137- MOVE W1SOLF-COD-SUBG TO COD-SUBG(9) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].COD_SUBG);

                /*" -3138- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(9) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].NUM_FATUR);

                /*" -3139- MOVE 1300 TO COD-OPER(9) */
                _.Move(1300, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].COD_OPER);

                /*" -3142- COMPUTE IMP-MORNAT(09) = IMP-MORNAT(09) + (V0MOVI-MORNATU-ANT - V0MOVI-MORNATU-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORNAT.Value + (V0MOVI_MORNATU_ANT - V0MOVI_MORNATU_ATU);

                /*" -3145- COMPUTE IMP-MORACI(09) = IMP-MORACI(09) + (V0MOVI-MORACID-ANT - V0MOVI-MORACID-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORACI.Value + (V0MOVI_MORACID_ANT - V0MOVI_MORACID_ATU);

                /*" -3148- COMPUTE IMP-INVPER(09) = IMP-INVPER(09) + (V0MOVI-INVPERM-ANT - V0MOVI-INVPERM-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_INVPER.Value + (V0MOVI_INVPERM_ANT - V0MOVI_INVPERM_ATU);

                /*" -3151- COMPUTE IMP-AMDS(09) = IMP-AMDS(09) + (V0MOVI-AMDS-ANT - V0MOVI-AMDS-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_AMDS.Value + (V0MOVI_AMDS_ANT - V0MOVI_AMDS_ATU);

                /*" -3154- COMPUTE IMP-DH(09) = IMP-DH(09) + (V0MOVI-DH-ANT - V0MOVI-DH-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DH.Value + (V0MOVI_DH_ANT - V0MOVI_DH_ATU);

                /*" -3157- COMPUTE IMP-DIT(09) = IMP-DIT(09) + (V0MOVI-DIT-ANT - V0MOVI-DIT-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DIT.Value + (V0MOVI_DIT_ANT - V0MOVI_DIT_ATU);

                /*" -3160- COMPUTE PRM-VG(09) = PRM-VG(09) + (V0MOVI-VG-ANT - V0MOVI-VG-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_VG.Value + (V0MOVI_VG_ANT - V0MOVI_VG_ATU);

                /*" -3163- COMPUTE PRM-AP(09) = PRM-AP(09) + (V0MOVI-AP-ANT - V0MOVI-AP-ATU) */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP.Value + (V0MOVI_AP_ANT - V0MOVI_AP_ATU);

                /*" -3164- MOVE 'NAO' TO WS-SOMA */
                _.Move("NAO", AREA_DE_WORK.WS_SOMA);

                /*" -3165- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -3167- COMPUTE OUT-IMP-MORNAT = V0MOVI-MORNATU-ANT - V0MOVI-MORNATU-ATU */
                AREA_DE_WORK.OUT_IMP_MORNAT.Value = V0MOVI_MORNATU_ANT - V0MOVI_MORNATU_ATU;

                /*" -3169- COMPUTE OUT-IMP-MORACI = V0MOVI-MORACID-ANT - V0MOVI-MORACID-ATU */
                AREA_DE_WORK.OUT_IMP_MORACI.Value = V0MOVI_MORACID_ANT - V0MOVI_MORACID_ATU;

                /*" -3171- COMPUTE OUT-IMP-INVPER = V0MOVI-INVPERM-ANT - V0MOVI-INVPERM-ATU */
                AREA_DE_WORK.OUT_IMP_INVPER.Value = V0MOVI_INVPERM_ANT - V0MOVI_INVPERM_ATU;

                /*" -3173- COMPUTE OUT-IMP-AMDS = V0MOVI-AMDS-ANT - V0MOVI-AMDS-ATU */
                AREA_DE_WORK.OUT_IMP_AMDS.Value = V0MOVI_AMDS_ANT - V0MOVI_AMDS_ATU;

                /*" -3175- COMPUTE OUT-IMP-DH = V0MOVI-DH-ANT - V0MOVI-DH-ATU */
                AREA_DE_WORK.OUT_IMP_DH.Value = V0MOVI_DH_ANT - V0MOVI_DH_ATU;

                /*" -3177- COMPUTE OUT-IMP-DIT = V0MOVI-DIT-ANT - V0MOVI-DIT-ATU */
                AREA_DE_WORK.OUT_IMP_DIT.Value = V0MOVI_DIT_ANT - V0MOVI_DIT_ATU;

                /*" -3179- COMPUTE OUT-PRM-VG = V0MOVI-VG-ANT - V0MOVI-VG-ATU */
                AREA_DE_WORK.OUT_PRM_VG.Value = V0MOVI_VG_ANT - V0MOVI_VG_ATU;

                /*" -3182- COMPUTE OUT-PRM-AP = V0MOVI-AP-ANT - V0MOVI-AP-ATU */
                AREA_DE_WORK.OUT_PRM_AP.Value = V0MOVI_AP_ANT - V0MOVI_AP_ATU;

                /*" -3183- IF PRM-VG(09) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_VG != 00)
                {

                    /*" -3185- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3186- IF PRM-AP(09) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP != 00)
                    {

                        /*" -3188- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3189- ELSE */
                    }
                    else
                    {


                        /*" -3190- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3191- ELSE */
                    }

                }
                else
                {


                    /*" -3192- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3193- IF PRM-AP(09) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP != 00)
                    {

                        /*" -3199- MOVE 1 TO OUT-QT-VIDA-AP. */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);
                    }

                }

            }


            /*" -3201- IF (V0MOVI-COD-OPER GREATER 299 AND V0MOVI-COD-OPER LESS 400) */

            if ((V0MOVI_COD_OPER > 299 && V0MOVI_COD_OPER < 400))
            {

                /*" -3202- MOVE W1SOLF-NUM-APOL TO NUM-APOL(10) */
                _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].NUM_APOL);

                /*" -3203- MOVE W1SOLF-COD-SUBG TO COD-SUBG(10) */
                _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].COD_SUBG);

                /*" -3204- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(10) */
                _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].NUM_FATUR);

                /*" -3205- MOVE 1400 TO COD-OPER(10) */
                _.Move(1400, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].COD_OPER);

                /*" -3207- COMPUTE IMP-MORNAT(10) = IMP-MORNAT(10) + V0MOVI-MORNATU-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -3209- COMPUTE IMP-MORACI(10) = IMP-MORACI(10) + V0MOVI-MORACID-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -3211- COMPUTE IMP-INVPER(10) = IMP-INVPER(10) + V0MOVI-INVPERM-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -3213- COMPUTE IMP-AMDS(10) = IMP-AMDS(10) + V0MOVI-AMDS-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -3215- COMPUTE IMP-DH(10) = IMP-DH(10) + V0MOVI-DH-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -3217- COMPUTE IMP-DIT(10) = IMP-DIT(10) + V0MOVI-DIT-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -3219- COMPUTE PRM-VG(10) = PRM-VG(10) + V0MOVI-VG-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -3221- COMPUTE PRM-AP(10) = PRM-AP(10) + V0MOVI-AP-ATU */
                AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -3222- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -3223- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, AREA_DE_WORK.OUT_IMP_MORNAT);

                /*" -3224- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, AREA_DE_WORK.OUT_IMP_MORACI);

                /*" -3225- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, AREA_DE_WORK.OUT_IMP_INVPER);

                /*" -3226- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, AREA_DE_WORK.OUT_IMP_AMDS);

                /*" -3227- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, AREA_DE_WORK.OUT_IMP_DH);

                /*" -3228- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, AREA_DE_WORK.OUT_IMP_DIT);

                /*" -3229- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, AREA_DE_WORK.OUT_PRM_VG);

                /*" -3231- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, AREA_DE_WORK.OUT_PRM_AP);

                /*" -3232- IF PRM-VG(10) NOT EQUAL ZEROS */

                if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG != 00)
                {

                    /*" -3233- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3234- ADD 1 TO QT-VIDA-VG(10) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_VG + 1;

                    /*" -3235- IF PRM-AP(10) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP != 00)
                    {

                        /*" -3236- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3237- ADD 1 TO QT-VIDA-AP(10) */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP + 1;

                        /*" -3238- ELSE */
                    }
                    else
                    {


                        /*" -3239- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3240- ELSE */
                    }

                }
                else
                {


                    /*" -3241- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, AREA_DE_WORK.OUT_QT_VIDA_VG);

                    /*" -3242- IF PRM-AP(10) NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP != 00)
                    {

                        /*" -3243- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, AREA_DE_WORK.OUT_QT_VIDA_AP);

                        /*" -3248- ADD 1 TO QT-VIDA-AP(10). */
                        AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -3249- IF WSOUTROS EQUAL 'CRE' */

            if (AREA_DE_WORK.WSOUTROS == "CRE")
            {

                /*" -3251- IF OUT-QT-VIDA-VG NOT EQUAL ZEROS OR OUT-QT-VIDA-AP NOT EQUAL ZEROS */

                if (AREA_DE_WORK.OUT_QT_VIDA_VG != 00 || AREA_DE_WORK.OUT_QT_VIDA_AP != 00)
                {

                    /*" -3252- MOVE W1SOLF-NUM-APOL TO NUM-APOL(12) */
                    _.Move(W1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].NUM_APOL);

                    /*" -3253- MOVE W1SOLF-COD-SUBG TO COD-SUBG(12) */
                    _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].COD_SUBG);

                    /*" -3254- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(12) */
                    _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].NUM_FATUR);

                    /*" -3273- MOVE 1600 TO COD-OPER(12) */
                    _.Move(1600, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].COD_OPER);

                    /*" -3276- COMPUTE PRM-VG(12) = PRM-VG(12) + (OUT-PRM-VG * CLACUM1) */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value + (AREA_DE_WORK.OUT_PRM_VG * AREA_DE_WORK.CLACUM1);

                    /*" -3278- COMPUTE PRM-AP(12) = PRM-AP(12) + (OUT-PRM-AP * CLACUM1). */
                    AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value + (AREA_DE_WORK.OUT_PRM_AP * AREA_DE_WORK.CLACUM1);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-UPDATE-MOVIMENTO-SECTION */
        private void R6500_00_UPDATE_MOVIMENTO_SECTION()
        {
            /*" -3297- MOVE '650' TO WNR-EXEC-SQL. */
            _.Move("650", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3298- IF V1SOLF-COD-SUBG EQUAL ZEROS */

            if (V1SOLF_COD_SUBG == 00)
            {

                /*" -3300- IF W1S-TIPO-FAT EQUAL '2' OR '3' */

                if (W1S_TIPO_FAT.In("2", "3"))
                {

                    /*" -3301- MOVE 0001 TO W1SUB-GRUPO */
                    _.Move(0001, W1SUB_GRUPO);

                    /*" -3302- MOVE 9999 TO W2SUB-GRUPO */
                    _.Move(9999, W2SUB_GRUPO);

                    /*" -3304- ELSE */
                }
                else
                {


                    /*" -3305- MOVE 0001 TO W1SUB-GRUPO */
                    _.Move(0001, W1SUB_GRUPO);

                    /*" -3306- MOVE 9999 TO W2SUB-GRUPO */
                    _.Move(9999, W2SUB_GRUPO);

                    /*" -3308- ELSE */
                }

            }
            else
            {


                /*" -3309- MOVE W1SOLF-COD-SUBG TO W1SUB-GRUPO */
                _.Move(W1SOLF_COD_SUBG, W1SUB_GRUPO);

                /*" -3311- MOVE W1SOLF-COD-SUBG TO W2SUB-GRUPO. */
                _.Move(W1SOLF_COD_SUBG, W2SUB_GRUPO);
            }


            /*" -3313- MOVE '650' TO WNR-EXEC-SQL. */
            _.Move("650", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3315- MOVE V1SIST-DTMOVABE TO V0MOVI-DATA-FATURA. */
            _.Move(V1SIST_DTMOVABE, V0MOVI_DATA_FATURA);

            /*" -3323- PERFORM R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1 */

            R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1();

        }

        [StopWatch]
        /*" R6500-00-UPDATE-MOVIMENTO-DB-UPDATE-1 */
        public void R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1()
        {
            /*" -3323- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_FATURA = :V0MOVI-DATA-FATURA WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO >= :W1SUB-GRUPO AND COD_SUBGRUPO <= :W2SUB-GRUPO AND DATA_INCLUSAO IS NOT NULL AND DATA_REFERENCIA = :V1FATC-DATA-REFER END-EXEC. */

            var r6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 = new R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1()
            {
                V0MOVI_DATA_FATURA = V0MOVI_DATA_FATURA.ToString(),
                V1FATC_DATA_REFER = V1FATC_DATA_REFER.ToString(),
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SUB_GRUPO = W1SUB_GRUPO.ToString(),
                W2SUB_GRUPO = W2SUB_GRUPO.ToString(),
            };

            R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1.Execute(r6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" S0100-00-ZERA-SALDO-ANT-SECTION */
        private void S0100_00_ZERA_SALDO_ANT_SECTION()
        {
            /*" -3335- MOVE V1SOLF-NUM-APOL TO NUM-APOL(1) */
            _.Move(V1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_APOL);

            /*" -3336- MOVE W1SOLF-COD-SUBG TO COD-SUBG(1) */
            _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_SUBG);

            /*" -3337- MOVE V1SOLF-NUM-FAT TO NUM-FATUR(1) */
            _.Move(V1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_FATUR);

            /*" -3349- MOVE ZEROS TO COD-OPER(1) QT-VIDA-VG(1) QT-VIDA-AP(1) IMP-MORNAT(1) IMP-MORACI(1) IMP-INVPER(1) IMP-AMDS(1) IMP-DH(1) IMP-DIT(1) PRM-VG(1) PRM-VG(1) COD-EMPRESA(1) */
            _.Move(0, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_OPER, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_AP, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORNAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORACI, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_INVPER, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_AMDS, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DH, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DIT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_EMPRESA);

            /*" -3349- MOVE '0' TO SIT-REG(1). */
            _.Move("0", AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].SIT_REG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0100_99_SAIDA*/

        [StopWatch]
        /*" S0200-00-MONTA-SALDO-ANT-SECTION */
        private void S0200_00_MONTA_SALDO_ANT_SECTION()
        {
            /*" -3360- MOVE V1FATT-NUM-APOL TO NUM-APOL(1) */
            _.Move(V1FATT_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_APOL);

            /*" -3361- MOVE V1FATT-COD-SUBG TO COD-SUBG(1) */
            _.Move(V1FATT_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_SUBG);

            /*" -3362- MOVE V1FATT-NUM-FATUR TO NUM-FATUR(1) */
            _.Move(V1FATT_NUM_FATUR, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_FATUR);

            /*" -3363- MOVE V1FATT-COD-OPER TO COD-OPER(1) */
            _.Move(V1FATT_COD_OPER, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_OPER);

            /*" -3364- MOVE V1FATT-QT-VIDA-VG TO QT-VIDA-VG(1) */
            _.Move(V1FATT_QT_VIDA_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_VG);

            /*" -3365- MOVE V1FATT-QT-VIDA-AP TO QT-VIDA-AP(1) */
            _.Move(V1FATT_QT_VIDA_AP, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_AP);

            /*" -3366- MOVE V1FATT-IMP-MORNAT TO IMP-MORNAT(1) */
            _.Move(V1FATT_IMP_MORNAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORNAT);

            /*" -3367- MOVE V1FATT-IMP-MORACI TO IMP-MORACI(1) */
            _.Move(V1FATT_IMP_MORACI, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORACI);

            /*" -3368- MOVE V1FATT-IMP-INVPER TO IMP-INVPER(1) */
            _.Move(V1FATT_IMP_INVPER, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_INVPER);

            /*" -3369- MOVE V1FATT-IMP-AMDS TO IMP-AMDS(1) */
            _.Move(V1FATT_IMP_AMDS, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_AMDS);

            /*" -3370- MOVE V1FATT-IMP-DH TO IMP-DH(1) */
            _.Move(V1FATT_IMP_DH, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DH);

            /*" -3371- MOVE V1FATT-IMP-DIT TO IMP-DIT(1) */
            _.Move(V1FATT_IMP_DIT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DIT);

            /*" -3372- MOVE V1FATT-PRM-VG TO PRM-VG(1) */
            _.Move(V1FATT_PRM_VG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG);

            /*" -3373- MOVE V1FATT-PRM-AP TO PRM-AP(1) */
            _.Move(V1FATT_PRM_AP, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_AP);

            /*" -3374- MOVE ZEROS TO COD-EMPRESA(1) */
            _.Move(0, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_EMPRESA);

            /*" -3374- MOVE '0' TO SIT-REG(1). */
            _.Move("0", AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].SIT_REG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0200_99_SAIDA*/

        [StopWatch]
        /*" S0300-00-TOTALIZA-FATURA-SECTION */
        private void S0300_00_TOTALIZA_FATURA_SECTION()
        {
            /*" -3385- MOVE V1SOLF-NUM-APOL TO NUM-APOL(13) */
            _.Move(V1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].NUM_APOL);

            /*" -3386- MOVE W1SOLF-COD-SUBG TO COD-SUBG(13) */
            _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].COD_SUBG);

            /*" -3387- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(13) */
            _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].NUM_FATUR);

            /*" -3389- MOVE 1700 TO COD-OPER(13) */
            _.Move(1700, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].COD_OPER);

            /*" -3400- COMPUTE QT-VIDA-VG(13) = QT-VIDA-VG(1) + QT-VIDA-VG(2) + QT-VIDA-VG(4) + QT-VIDA-VG(5) + QT-VIDA-VG(6) - QT-VIDA-VG(7) - QT-VIDA-VG(8) - QT-VIDA-VG(10) - QT-VIDA-VG(11) - QT-VIDA-VG(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].QT_VIDA_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].QT_VIDA_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].QT_VIDA_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].QT_VIDA_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].QT_VIDA_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].QT_VIDA_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_VG.Value;

            /*" -3411- COMPUTE QT-VIDA-AP(13) = QT-VIDA-AP(1) + QT-VIDA-AP(2) + QT-VIDA-AP(4) + QT-VIDA-AP(5) + QT-VIDA-AP(6) - QT-VIDA-AP(7) - QT-VIDA-AP(8) - QT-VIDA-AP(10) - QT-VIDA-AP(11) - QT-VIDA-AP(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].QT_VIDA_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].QT_VIDA_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].QT_VIDA_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].QT_VIDA_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].QT_VIDA_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].QT_VIDA_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_AP.Value;

            /*" -3424- COMPUTE IMP-MORNAT(13) = IMP-MORNAT(1) + IMP-MORNAT(2) + IMP-MORNAT(3) + IMP-MORNAT(4) + IMP-MORNAT(5) + IMP-MORNAT(6) - IMP-MORNAT(7) - IMP-MORNAT(8) - IMP-MORNAT(9) - IMP-MORNAT(10) - IMP-MORNAT(11) - IMP-MORNAT(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORNAT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_MORNAT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_MORNAT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_MORNAT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_MORNAT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORNAT.Value;

            /*" -3437- COMPUTE IMP-MORACI(13) = IMP-MORACI(1) + IMP-MORACI(2) + IMP-MORACI(3) + IMP-MORACI(4) + IMP-MORACI(5) + IMP-MORACI(6) - IMP-MORACI(7) - IMP-MORACI(8) - IMP-MORACI(9) - IMP-MORACI(10) - IMP-MORACI(11) - IMP-MORACI(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORACI.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_MORACI.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_MORACI.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_MORACI.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_MORACI.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORACI.Value;

            /*" -3450- COMPUTE IMP-INVPER(13) = IMP-INVPER(1) + IMP-INVPER(2) + IMP-INVPER(3) + IMP-INVPER(4) + IMP-INVPER(5) + IMP-INVPER(6) - IMP-INVPER(7) - IMP-INVPER(8) - IMP-INVPER(9) - IMP-INVPER(10) - IMP-INVPER(11) - IMP-INVPER(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_INVPER.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_INVPER.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_INVPER.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_INVPER.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_INVPER.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_INVPER.Value;

            /*" -3463- COMPUTE IMP-AMDS(13) = IMP-AMDS(1) + IMP-AMDS(2) + IMP-AMDS(3) + IMP-AMDS(4) + IMP-AMDS(5) + IMP-AMDS(6) - IMP-AMDS(7) - IMP-AMDS(8) - IMP-AMDS(9) - IMP-AMDS(10) - IMP-AMDS(11) - IMP-AMDS(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_AMDS.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_AMDS.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_AMDS.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_AMDS.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_AMDS.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_AMDS.Value;

            /*" -3476- COMPUTE IMP-DH(13) = IMP-DH(1) + IMP-DH(2) + IMP-DH(3) + IMP-DH(4) + IMP-DH(5) + IMP-DH(6) - IMP-DH(7) - IMP-DH(8) - IMP-DH(9) - IMP-DH(10) - IMP-DH(11) - IMP-DH(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DH.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_DH.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_DH.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_DH.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_DH.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DH.Value;

            /*" -3490- COMPUTE IMP-DIT(13) = IMP-DIT(1) + IMP-DIT(2) + IMP-DIT(3) + IMP-DIT(4) + IMP-DIT(5) + IMP-DIT(6) - IMP-DIT(7) - IMP-DIT(8) - IMP-DIT(9) - IMP-DIT(10) - IMP-DIT(11) - IMP-DIT(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DIT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_DIT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_DIT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_DIT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_DIT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DIT.Value;

            /*" -3503- COMPUTE PRM-VG(13) = PRM-VG(1) + PRM-VG(2) + PRM-VG(3) + PRM-VG(4) + PRM-VG(5) + PRM-VG(6) - PRM-VG(7) - PRM-VG(8) - PRM-VG(9) - PRM-VG(10) - PRM-VG(11) - PRM-VG(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value;

            /*" -3516- COMPUTE PRM-AP(13) = PRM-AP(1) + PRM-AP(2) + PRM-AP(3) + PRM-AP(4) + PRM-AP(5) + PRM-AP(6) - PRM-AP(7) - PRM-AP(8) - PRM-AP(9) - PRM-AP(10) - PRM-AP(11) - PRM-AP(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value;

            /*" -3517- MOVE -1 TO VIND-COD-EMP */
            _.Move(-1, VIND_COD_EMP);

            /*" -3519- MOVE '0' TO SIT-REG(13). */
            _.Move("0", AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].SIT_REG);

            /*" -3525- COMPUTE PRM-TOTAL = PRM-AP(13) + PRM-VG(13). */
            AREA_DE_WORK.PRM_TOTAL.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value;

            /*" -3526- MOVE V1SOLF-NUM-APOL TO NUM-APOL(14) */
            _.Move(V1SOLF_NUM_APOL, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].NUM_APOL);

            /*" -3527- MOVE W1SOLF-COD-SUBG TO COD-SUBG(14) */
            _.Move(W1SOLF_COD_SUBG, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].COD_SUBG);

            /*" -3528- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(14) */
            _.Move(W1SOLF_NUM_FAT, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].NUM_FATUR);

            /*" -3530- MOVE 1800 TO COD-OPER(14) */
            _.Move(1800, AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].COD_OPER);

            /*" -3534- COMPUTE QT-VIDA-VG(14) = QT-VIDA-VG(13) - QT-VIDA-VG(6) + QT-VIDA-VG(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].QT_VIDA_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_VG.Value;

            /*" -3538- COMPUTE QT-VIDA-AP(14) = QT-VIDA-AP(13) - QT-VIDA-AP(6) + QT-VIDA-AP(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].QT_VIDA_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_AP.Value;

            /*" -3542- COMPUTE IMP-MORNAT(14) = IMP-MORNAT(13) - IMP-MORNAT(6) + IMP-MORNAT(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_MORNAT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORNAT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORNAT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORNAT.Value;

            /*" -3546- COMPUTE IMP-MORACI(14) = IMP-MORACI(13) - IMP-MORACI(6) + IMP-MORACI(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_MORACI.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORACI.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORACI.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORACI.Value;

            /*" -3550- COMPUTE IMP-INVPER(14) = IMP-INVPER(13) - IMP-INVPER(6) + IMP-INVPER(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_INVPER.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_INVPER.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_INVPER.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_INVPER.Value;

            /*" -3554- COMPUTE IMP-AMDS(14) = IMP-AMDS(13) - IMP-AMDS(6) + IMP-AMDS(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_AMDS.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_AMDS.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_AMDS.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_AMDS.Value;

            /*" -3558- COMPUTE IMP-DH(14) = IMP-DH(13) - IMP-DH(6) + IMP-DH(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_DH.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DH.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DH.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DH.Value;

            /*" -3563- COMPUTE IMP-DIT(14) = IMP-DIT(13) - IMP-DIT(6) + IMP-DIT(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_DIT.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DIT.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DIT.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DIT.Value;

            /*" -3567- COMPUTE PRM-VG(14) = PRM-VG(13) - PRM-VG(6) + PRM-VG(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].PRM_VG.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_VG.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value;

            /*" -3571- COMPUTE PRM-AP(14) = PRM-AP(13) - PRM-AP(6) + PRM-AP(12) */
            AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].PRM_AP.Value = AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value - AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_AP.Value + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value;

            /*" -3572- MOVE -1 TO VIND-COD-EMP */
            _.Move(-1, VIND_COD_EMP);

            /*" -3572- MOVE '0' TO SIT-REG(14). */
            _.Move("0", AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].SIT_REG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0300_99_SAIDA*/

        [StopWatch]
        /*" S0400-00-TOTALIZA-APOLICE-SECTION */
        private void S0400_00_TOTALIZA_APOLICE_SECTION()
        {
            /*" -3585- SET I01 TO +1. */
            I01.Value = +1;

            /*" -0- FLUXCONTROL_PERFORM S0400_10_LOOP */

            S0400_10_LOOP();

        }

        [StopWatch]
        /*" S0400-10-LOOP */
        private void S0400_10_LOOP(bool isPerform = false)
        {
            /*" -3590- IF COD-OPER(I01) NOT EQUAL ZEROS */

            if (AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER != 00)
            {

                /*" -3591- MOVE V1SOLF-NUM-APOL TO ANUM-APOL(I01) */
                _.Move(V1SOLF_NUM_APOL, AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ANUM_APOL);

                /*" -3592- MOVE V1SOLF-COD-SUBG TO ACOD-SUBG(I01) */
                _.Move(V1SOLF_COD_SUBG, AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ACOD_SUBG);

                /*" -3593- MOVE V1SOLF-NUM-FAT TO ANUM-FATUR(I01) */
                _.Move(V1SOLF_NUM_FAT, AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ANUM_FATUR);

                /*" -3594- MOVE COD-OPER(I01) TO ACOD-OPER(I01) */
                _.Move(AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER, AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ACOD_OPER);

                /*" -3595- ADD QT-VIDA-VG(I01) TO AQT-VIDA-VG(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_VG.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_VG + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_VG;

                /*" -3596- ADD QT-VIDA-AP(I01) TO AQT-VIDA-AP(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_AP.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_AP + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_AP;

                /*" -3597- ADD IMP-MORNAT(I01) TO AIMP-MORNAT(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORNAT.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORNAT + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORNAT;

                /*" -3598- ADD IMP-MORACI(I01) TO AIMP-MORACI(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORACI.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORACI + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORACI;

                /*" -3599- ADD IMP-INVPER(I01) TO AIMP-INVPER(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_INVPER.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_INVPER + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_INVPER;

                /*" -3600- ADD IMP-AMDS(I01) TO AIMP-AMDS(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_AMDS.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_AMDS + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_AMDS;

                /*" -3601- ADD IMP-DH(I01) TO AIMP-DH(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DH.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DH + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DH;

                /*" -3602- ADD IMP-DIT(I01) TO AIMP-DIT(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DIT.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DIT + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DIT;

                /*" -3603- ADD PRM-VG(I01) TO APRM-VG(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_VG.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_VG + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_VG;

                /*" -3604- ADD PRM-AP(I01) TO APRM-AP(I01) */
                AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_AP.Value = AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_AP + AREA_DE_WORK.TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_AP;

                /*" -3605- MOVE ZEROS TO ACOD-EMPRESA(I01) */
                _.Move(0, AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ACOD_EMPRESA);

                /*" -3608- MOVE '0' TO ASIT-REG(I01). */
                _.Move("0", AREA_DE_WORK.ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ASIT_REG);
            }


            /*" -3610- SET I01 UP BY +1. */
            I01.Value += +1;

            /*" -3611- IF I01 LESS 15 */

            if (I01 < 15)
            {

                /*" -3611- GO TO S0400-10-LOOP. */
                new Task(() => S0400_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0400_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3625- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -3626- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -3630- DISPLAY '==> SQLERRMC=<' SQLERRMC '>' */

            $"==> SQLERRMC=<{DB.SQLERRMC}>"
            .Display();

            /*" -3630- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3632- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3632- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}