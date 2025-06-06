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
using Sias.VidaEmGrupo.DB2.VG0100B;

namespace Code
{
    public class VG0100B
    {
        public bool IsCall { get; set; }

        public VG0100B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROGRAMA ...............  VG0100B                            *      */
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
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 28/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32 - INCIDENTE 487196                                 *      */
        /*"      *             - RESOLU��O DE ABEND                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2023 - RAUL BASILI ROTTA                            *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31 - HIST 181.242                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30 - CADMUS 154.956                                   *      */
        /*"      *             - DESCONSIDERAR MODALIDADE NA CONSULTA DE COBERTURA*      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 07/12/2007       FAST COMPUTER      SSI            *      */
        /*"      *                                                                *      */
        /*"      *          PASSA A TRATAR A DATA DE TERMINO DE VIGENCIA          *      */
        /*"      *          DO ENDOSSO POR EM DETERMINADAS SITUACAOES             *      */
        /*"      *          ESTAR SENDO GERADO MENOR QUE A DATA DE                *      */
        /*"      *          INICIO DE VIGENCIA.                                   *      */
        /*"      *                             (PROCURE V.01)                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 06/06/2006       TERCIO CARVALHO    SSI 9886       *      */
        /*"      *                                                                *      */
        /*"      *          PASSA A RECUPERAR O TERMO DE ADESAO UTILIZANTO        *      */
        /*"      *          TAMBEM O NUMERO DA APOLICE EM FUNCAO DE -811          *      */
        /*"      *                             (PROCURE FC0606)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 08/11/2000       FREDERICO FONSECA                 *      */
        /*"      *                                                                *      */
        /*"      *          PASSA A INSERIR NA V0COBERAPOL A MODALIDADE CADASTRA- *      */
        /*"      *          DA NA V1APOLICE                                       *      */
        /*"      *                             (PROCURE FF1100)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 24/05/1999       TERCIO CARVALHO                   *      */
        /*"      *                                                                *      */
        /*"      *          PASSA A TRATAR O PERI_FATURAMENTO  PARA DETERMINAR    *      */
        /*"      *          O TERMINO DA VIGENCIA, INDEPENDENTE DO TIPO_SUBGRUPO  *      */
        /*"      *          DA V0SUBGRUPO      (PROCURE TL9905)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 02/06/2000       MANOEL MESSIAS                    *      */
        /*"      *                                                                *      */
        /*"      *          PASSA A USAR A VARIAVEL DATA-TERVIG PARA O TERMINO DE *      */
        /*"      *          VIGENCIA DAS TABELAS V0FATURAS, V0ENDOSSO E V0COBERA  *      */
        /*"      *          POL, NO LUGAR DA VARIAVEL WDATA-TERVIG.               *      */
        /*"      *                             (PROCURE MM0600)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 17/07/2000       MANOEL MESSIAS                    *      */
        /*"      *                                                                *      */
        /*"      *      1 - PRESERVAR A DATA DE TERMINO DE VIGENCIA DA FATURA     *      */
        /*"      *          CALCULADO NO FATURAMENTO.                             *      */
        /*"      *      2 - DETERMINA A DATA DO PROXIMO FATURAMENTO NA V0FATURCONT*      */
        /*"      *          TAMBEM QUANDO FOR REFATURAMENTO.                      *      */
        /*"      *      3 - GERA SOLICITACAO AUTOMATICA DA PROXIMA PREVIA APOS UM *      */
        /*"      *          FATURAMENTO OU REFATURAMENTO.                         *      */
        /*"      *                             (PROCURE MM0700)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 21/07/2000       MANOEL MESSIAS                    *      */
        /*"      *                                                                *      */
        /*"      *      1 - GERA SOLICITACAO AUTOMATICA DA PROXIMA PREVIA APOS UM *      */
        /*"      *          FATURAMENTO OU REFATURAMENTO TAMBEM PARA AS APOLICES  *      */
        /*"      *          ESPECIFICAS.                                          *      */
        /*"      *                             (PROCURE MM0721)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 05/07/2001       MANOEL MESSIAS                    *      */
        /*"      *                                                                *      */
        /*"      *      1 - QUANDO O REFATURAMENTO SE TRATAR DE UMA FATURA ANTE_  *      */
        /*"      *          RIOR A ATUAL, NAO GERAR PREVIA AUTOMATICA.            *      */
        /*"      *                             (PROCURE MM0701)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 10/01/2002       MANOEL MESSIAS                    *      */
        /*"      *                                                                *      */
        /*"      *      1 - A PEDIDO DA GEPES, NAO PERMITIR A SOLICITACAO AUTOMA- *      */
        /*"      *          TICA DE PREVIA, APOS, O REFATURAMENTO.                *      */
        /*"      *                             (PROCURE MM0102)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 01/03/2002       MANOEL MESSIAS                    *      */
        /*"      *                                                                *      */
        /*"      *     SE A APOLICE FOI MIGRADA PARA A ESTRUTURA DO MULTIPREMIADO *      */
        /*"      *  NAO PERMITE A GERACAO AUTOMATICA DE FATURAMENTO.              *      */
        /*"      *                             (PROCURE MM0302)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 10/03/2003       TERCIO CARVALHO                   *      */
        /*"      *                                                                *      */
        /*"      *     PASSA A TRATAR O RAMO 77 - APOLICE PRESTAMISTA             *      */
        /*"      *                             (PROCURE TL0303)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO EM 09/12/2005       NORA CORTABERRIA SANZ             *      */
        /*"      *                                                                *      */
        /*"      * 1.- PASSA A TRATAR ORIG-PRODU 'ESPE%'                          *      */
        /*"      * 2.- NAO PRECISA CALCULAR DTINIVIG PARA ACESSAR RAMOIND         *      */
        /*"      *     TEM Q PEGAR A DATA DE INICIO DE VIGENCIA DA FATURA         *      */
        /*"      *     QUE JA EXISTE, OU A DATA DA SOLICITADA                     *      */
        /*"      *                             (PROCURE NC1205)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  25/07/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I03 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77         WHOST-DATA-TERVIGENCIA   PIC X(010).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         W1ENDO-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis W1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1ENDO-TIPEND       PIC  X(001).*/
        public StringBasis W1ENDO_TIPEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"77         V1MOED-VLCRUZAD     PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         W1MOED-VLCRUZAD-IM  PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis W1MOED_VLCRUZAD_IM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         W1MOED-VLCRUZAD-PR  PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis W1MOED_VLCRUZAD_PR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1RIND-ISECUSTO     PIC  X(001).*/
        public StringBasis V1RIND_ISECUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1RIND-PCIOF        PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1RIND-DTINIVIG     PIC  X(010).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRAM-RAMO-VGAP    PIC S9(004)                COMP.*/
        public IntBasis V1PRAM_RAMO_VGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAM-RAMO-VG      PIC S9(004)                COMP.*/
        public IntBasis V1PRAM_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAM-RAMO-AP      PIC S9(004)                COMP.*/
        public IntBasis V1PRAM_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAM-RAMO-PRESTAMISTA  PIC S9(004)           COMP.*/
        public IntBasis V1PRAM_RAMO_PRESTAMISTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FONT-PROPAUTOM    PIC S9(009)                COMP.*/
        public IntBasis V0FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELT-COD-USUAR    PIC  X(008).*/
        public StringBasis V0RELT_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0RELT-DATA-SOLI    PIC  X(010).*/
        public StringBasis V0RELT_DATA_SOLI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELT-CODREL       PIC  X(008).*/
        public StringBasis V0RELT_CODREL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0RELT-DATA-REFER   PIC  X(010).*/
        public StringBasis V0RELT_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELT-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V0RELT_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELT-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0RELT_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELT-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V0RELT_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELT-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0RELT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELT-PERI-RENOVA  PIC S9(004)                COMP.*/
        public IntBasis V0RELT_PERI_RENOVA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELT-PCT-AUMENTO  PIC S9(003)V99             COMP-3*/
        public DoubleBasis V0RELT_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1APOL-ORGAO       PIC S9(004)                 COMP.*/
        public IntBasis V1APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APOL-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V1APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APOL-MODALIDA    PIC S9(004)                 COMP.*/
        public IntBasis V1APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V1SUBG-DTTERVIG     PIC  X(010).*/
        public StringBasis V1SUBG_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SUBG-IND-IOF      PIC  X(001).*/
        public StringBasis V1SUBG_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SOLF-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V1SOLF_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SOLF-COD-SUBG     PIC S9(004)                COMP.*/
        public IntBasis V1SOLF_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SOLF-NUM-FAT      PIC S9(009)                COMP.*/
        public IntBasis V1SOLF_NUM_FAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SOLF-NUM-FATUR    PIC S9(009)                COMP.*/
        public IntBasis V0SOLF_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77         V9SOLF-NUM-FAT      PIC S9(009)                COMP.*/
        public IntBasis V9SOLF_NUM_FAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBE-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0COBE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBE-NUM-ENDOS    PIC S9(009)                COMP.*/
        public IntBasis V0COBE_NUM_ENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBE-NUM-ITEM     PIC S9(009)                COMP.*/
        public IntBasis V0COBE_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBE-OCORR-HIST   PIC S9(004)                COMP.*/
        public IntBasis V0COBE_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBE-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V0COBE_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBE-MODALIFR     PIC S9(004)                COMP.*/
        public IntBasis V0COBE_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBE-COD-COBER    PIC S9(004)                COMP.*/
        public IntBasis V0COBE_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBE-IMP-SEGUR-I  PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0COBE_IMP_SEGUR_I { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBE-PRM-TARIF-I  PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V0COBE_PRM_TARIF_I { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBE-IMP-SEGUR-V  PIC S9(013)V99             COMP-3*/
        public DoubleBasis V0COBE_IMP_SEGUR_V { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBE-PRM-TARIF-V  PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V0COBE_PRM_TARIF_V { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBE-PCT-COBER    PIC S9(003)V99             COMP-3*/
        public DoubleBasis V0COBE_PCT_COBER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0COBE-FAT-MULT     PIC S9(004)                COMP.*/
        public IntBasis V0COBE_FAT_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBE-DATA-INIVIG  PIC  X(010).*/
        public StringBasis V0COBE_DATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBE-DATA-TERVIG  PIC  X(010).*/
        public StringBasis V0COBE_DATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBE-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0COBE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBE-COD-SITUACAO PIC  X(001).*/
        public StringBasis V0COBE_COD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COBE-COD-SIT-I    PIC  S9(004)    COMP.*/
        public IntBasis V0COBE_COD_SIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V9COBE-IMP-SEGUR-I  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V9COBE_IMP_SEGUR_I { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V9COBE-PRM-TARIF-I  PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V9COBE_PRM_TARIF_I { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V9COBE-IMP-SEGUR-V  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V9COBE_IMP_SEGUR_V { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V9COBE-PRM-TARIF-V  PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V9COBE_PRM_TARIF_V { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0NAES-COD-ORGAO    PIC S9(004)                COMP.*/
        public IntBasis V0NAES_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-COD-RAMO     PIC S9(004)                COMP.*/
        public IntBasis V0NAES_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-ENDOSCOB     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSCOB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSRES     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSRES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSSEM     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSSEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CODSUBES    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-FONTE       PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-NRPROPOS    PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-DATPRO      PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DT-LIBER    PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-NRRCAP      PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-VLRCAP      PIC S9(013)V9(02)           COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0ENDO-BCORCAP     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGERCAP     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACRCAP     PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-IDRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-BCOCOBR     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGECOBR     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACCOBR     PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CDFRACIO    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-PCENTRAD    PIC S9(003)V9(02)           COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PCADICIO    PIC S9(003)V9(02)           COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PRESTA1     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPRESTA    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTITENS     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODTXT      PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0ENDO-CDACEITA    PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-MOEDA-IMP   PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM   PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-TIPEND      PIC  X(001).*/
        public StringBasis V0ENDO_TIPEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-COD-USUAR   PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ENDO-OCORR-END   PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DATARCAP    PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-COD-EMPRESA PIC S9(009)  VALUE +0       COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-CORRECAO-I  PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CORRECAO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-ISENTA-CST  PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-ISNT-CST-I  PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_ISNT_CST_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DATARCAP-I  PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_DATARCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DTVENCTO    PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTVENCTO-I  PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_DTVENCTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CFPREFIX    PIC  S9(004)V9(05)    COMP-3.*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
        /*"77         V0ENDO-CFPREFIX-I  PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CFPREFIX_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-VLCUSEMI    PIC  S9(013)V9(02)    COMP-3.*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0ENDO-VLCUSEMI-I  PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_VLCUSEMI_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODPRODU    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V1ENDO-CODPRODU    PIC S9(004)                 COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V0FATR-VLIOCC       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0FATR_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0FATR-DATA-VENC-I  PIC S9(004)                COMP.*/
        public IntBasis V0FATR_DATA_VENC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-DATA-RCAP-I  PIC S9(004)                COMP.*/
        public IntBasis V0FATR_DATA_RCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FATR-DATA-FATU-I  PIC S9(004)                COMP.*/
        public IntBasis V0FATR_DATA_FATU_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77         V1FATC-DATA-REFER   PIC  X(010).*/
        public StringBasis V1FATC_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-NRCERTIF     PIC S9(015)              COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         NUM-TITULO          PIC S9(013)              COMP-3.*/
        public IntBasis NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
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
        /*"01  REGISTRO-LINKAGE-GE0510S.*/
        public VG0100B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG0100B_REGISTRO_LINKAGE_GE0510S();
        public class VG0100B_REGISTRO_LINKAGE_GE0510S : VarBasis
        {
            /*"    10 LK-GE510-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    10 LK-GE510-COD-SUBGRUPO      PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE510-COD-MODALIDADE    PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE510_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE510-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE510_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE510-MENSAGEM.*/
            public VG0100B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG0100B_LK_GE510_MENSAGEM();
            public class VG0100B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01           AREA-DE-WORK.*/
            }
        }
        public VG0100B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0100B_AREA_DE_WORK();
        public class VG0100B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSTATUS            PIC  X(002)    VALUE  ZEROS.*/
            public StringBasis WSTATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05         WSOUTROS           PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WSOUTROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WS-SOMA            PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WS_SOMA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WZEROS             PIC S9(003)    VALUE +0  COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WRESTO             PIC S9(005)    VALUE +0  COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WRESPOSTA          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WRESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFATNT-PREMIO      PIC S9(013)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WFATNT_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         PRM-TOTAL          PIC S9(013)V99           COMP-3.*/
            public DoubleBasis PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         W0COBE-PCT-COBERVG PIC S9(003)V99           COMP-3.*/
            public DoubleBasis W0COBE_PCT_COBERVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         W0COBE-PCT-COBERAP PIC S9(003)V99           COMP-3.*/
            public DoubleBasis W0COBE_PCT_COBERAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"  05         W0COBE-PRM-TARIF   PIC S9(013)V99           COMP-3.*/
            public DoubleBasis W0COBE_PRM_TARIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         CLACUM1            PIC S9(005)   VALUE +0   COMP-3.*/
            public IntBasis CLACUM1 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         CLACUM2            PIC S9(005)   VALUE +0   COMP-3.*/
            public IntBasis CLACUM2 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WK-DATA1.*/
            public VG0100B_WK_DATA1 WK_DATA1 { get; set; } = new VG0100B_WK_DATA1();
            public class VG0100B_WK_DATA1 : VarBasis
            {
                /*"    10       WK-ANO1           PIC  9(004).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CLANOMES.*/
            }
            public VG0100B_CLANOMES CLANOMES { get; set; } = new VG0100B_CLANOMES();
            public class VG0100B_CLANOMES : VarBasis
            {
                /*"    10       CLANO             PIC  9(004).*/
                public IntBasis CLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CLMES             PIC  9(002).*/
                public IntBasis CLMES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CLDIA             PIC  9(002).*/
                public IntBasis CLDIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CLDATA1           PIC  9(006)    VALUE ZEROS.*/
            }
            public IntBasis CLDATA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         FILLER            REDEFINES      CLDATA1.*/
            private _REDEF_VG0100B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG0100B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG0100B_FILLER_5(); _.Move(CLDATA1, _filler_5); VarBasis.RedefinePassValue(CLDATA1, _filler_5, CLDATA1); _filler_5.ValueChanged += () => { _.Move(_filler_5, CLDATA1); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, CLDATA1); }
            }  //Redefines
            public class _REDEF_VG0100B_FILLER_5 : VarBasis
            {
                /*"    10       CLANO1            PIC  9(004).*/
                public IntBasis CLANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       CLMES1            PIC  9(002).*/
                public IntBasis CLMES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CLDATA2           PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG0100B_FILLER_5()
                {
                    CLANO1.ValueChanged += OnValueChanged;
                    CLMES1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis CLDATA2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         FILLER            REDEFINES      CLDATA2.*/
            private _REDEF_VG0100B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG0100B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG0100B_FILLER_6(); _.Move(CLDATA2, _filler_6); VarBasis.RedefinePassValue(CLDATA2, _filler_6, CLDATA2); _filler_6.ValueChanged += () => { _.Move(_filler_6, CLDATA2); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, CLDATA2); }
            }  //Redefines
            public class _REDEF_VG0100B_FILLER_6 : VarBasis
            {
                /*"    10       CLANO2            PIC  9(004).*/
                public IntBasis CLANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       CLMES2            PIC  9(002).*/
                public IntBasis CLMES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            WS-DTRENOVA           PIC X(010).*/

                public _REDEF_VG0100B_FILLER_6()
                {
                    CLANO2.ValueChanged += OnValueChanged;
                    CLMES2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            WS-DTINIVIG           PIC X(010).*/
            public StringBasis WS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 05             WS-DTFATUR.*/
            public VG0100B_WS_DTFATUR WS_DTFATUR { get; set; } = new VG0100B_WS_DTFATUR();
            public class VG0100B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VG0100B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VG0100B_WS_DTFATUR_AM();
                public class VG0100B_WS_DTFATUR_AM : VarBasis
                {
                    /*"     15         WS-AAFATUR            PIC 9(004).*/
                    public IntBasis WS_AAFATUR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMFATUR            PIC 9(002).*/
                    public IntBasis WS_MMFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDFATUR            PIC 9(002).*/
                public IntBasis WS_DDFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DTBASE.*/
            }
            public VG0100B_WS_DTBASE WS_DTBASE { get; set; } = new VG0100B_WS_DTBASE();
            public class VG0100B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VG0100B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VG0100B_WS_DTBASE_AM();
                public class VG0100B_WS_DTBASE_AM : VarBasis
                {
                    /*"     15         WS-AABASE             PIC 9(004).*/
                    public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMBASE             PIC 9(002).*/
                    public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDBASE             PIC 9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DIA                PIC 9(004).*/
            }
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/
        }
        public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  05         FILLER            REDEFINES      W01DTCSP.*/
        private _REDEF_VG0100B_FILLER_11 _filler_11 { get; set; }
        public _REDEF_VG0100B_FILLER_11 FILLER_11
        {
            get { _filler_11 = new _REDEF_VG0100B_FILLER_11(); _.Move(W01DTCSP, _filler_11); VarBasis.RedefinePassValue(W01DTCSP, _filler_11, W01DTCSP); _filler_11.ValueChanged += () => { _.Move(_filler_11, W01DTCSP); }; return _filler_11; }
            set { VarBasis.RedefinePassValue(value, _filler_11, W01DTCSP); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_11 : VarBasis
        {
            /*"    10       W01DDCSP          PIC  9(002).*/
            public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W01MMCSP          PIC  9(002).*/
            public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W01AACSP          PIC  9(004).*/
            public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

            public _REDEF_VG0100B_FILLER_11()
            {
                W01DDCSP.ValueChanged += OnValueChanged;
                W01MMCSP.ValueChanged += OnValueChanged;
                W01AACSP.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  05         FILLER            REDEFINES      W02DTCSP.*/
        private _REDEF_VG0100B_FILLER_12 _filler_12 { get; set; }
        public _REDEF_VG0100B_FILLER_12 FILLER_12
        {
            get { _filler_12 = new _REDEF_VG0100B_FILLER_12(); _.Move(W02DTCSP, _filler_12); VarBasis.RedefinePassValue(W02DTCSP, _filler_12, W02DTCSP); _filler_12.ValueChanged += () => { _.Move(_filler_12, W02DTCSP); }; return _filler_12; }
            set { VarBasis.RedefinePassValue(value, _filler_12, W02DTCSP); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_12 : VarBasis
        {
            /*"    10       W02DDCSP          PIC  9(002).*/
            public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W02MMCSP          PIC  9(002).*/
            public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       W02AACSP          PIC  9(004).*/
            public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WNUMERO-APOL      PIC  9(013)    VALUE ZEROS.*/

            public _REDEF_VG0100B_FILLER_12()
            {
                W02DDCSP.ValueChanged += OnValueChanged;
                W02MMCSP.ValueChanged += OnValueChanged;
                W02AACSP.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WNUMERO_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"  05         FILLER            REDEFINES      WNUMERO-APOL.*/
        private _REDEF_VG0100B_FILLER_13 _filler_13 { get; set; }
        public _REDEF_VG0100B_FILLER_13 FILLER_13
        {
            get { _filler_13 = new _REDEF_VG0100B_FILLER_13(); _.Move(WNUMERO_APOL, _filler_13); VarBasis.RedefinePassValue(WNUMERO_APOL, _filler_13, WNUMERO_APOL); _filler_13.ValueChanged += () => { _.Move(_filler_13, WNUMERO_APOL); }; return _filler_13; }
            set { VarBasis.RedefinePassValue(value, _filler_13, WNUMERO_APOL); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_13 : VarBasis
        {
            /*"    10       WNUM-APOL-ORG     PIC  9(003).*/
            public IntBasis WNUM_APOL_ORG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10       WNUM-APOL-RAM     PIC  9(002).*/
            public IntBasis WNUM_APOL_RAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WNUM-APOL-SEQ     PIC  9(008).*/
            public IntBasis WNUM_APOL_SEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         WNUM-APOLICE      PIC S9(013)    VALUE +0  COMP-3.*/

            public _REDEF_VG0100B_FILLER_13()
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
        private _REDEF_VG0100B_FILLER_14 _filler_14 { get; set; }
        public _REDEF_VG0100B_FILLER_14 FILLER_14
        {
            get { _filler_14 = new _REDEF_VG0100B_FILLER_14(); _.Move(WNUM_FATURA, _filler_14); VarBasis.RedefinePassValue(WNUM_FATURA, _filler_14, WNUM_FATURA); _filler_14.ValueChanged += () => { _.Move(_filler_14, WNUM_FATURA); }; return _filler_14; }
            set { VarBasis.RedefinePassValue(value, _filler_14, WNUM_FATURA); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_14 : VarBasis
        {
            /*"    10       WFAT-ANO          PIC  9(004).*/
            public IntBasis WFAT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WFAT-MES          PIC  9(002).*/
            public IntBasis WFAT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WNUM-FATURA1      PIC  9(006)    VALUE ZEROS.*/

            public _REDEF_VG0100B_FILLER_14()
            {
                WFAT_ANO.ValueChanged += OnValueChanged;
                WFAT_MES.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WNUM_FATURA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"  05         FILLER            REDEFINES      WNUM-FATURA1.*/
        private _REDEF_VG0100B_FILLER_15 _filler_15 { get; set; }
        public _REDEF_VG0100B_FILLER_15 FILLER_15
        {
            get { _filler_15 = new _REDEF_VG0100B_FILLER_15(); _.Move(WNUM_FATURA1, _filler_15); VarBasis.RedefinePassValue(WNUM_FATURA1, _filler_15, WNUM_FATURA1); _filler_15.ValueChanged += () => { _.Move(_filler_15, WNUM_FATURA1); }; return _filler_15; }
            set { VarBasis.RedefinePassValue(value, _filler_15, WNUM_FATURA1); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_15 : VarBasis
        {
            /*"    10       WFAT-ANO1         PIC  9(004).*/
            public IntBasis WFAT_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WFAT-MES1         PIC  9(002).*/
            public IntBasis WFAT_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         W1MOVI-NUM-FAT.*/

            public _REDEF_VG0100B_FILLER_15()
            {
                WFAT_ANO1.ValueChanged += OnValueChanged;
                WFAT_MES1.ValueChanged += OnValueChanged;
            }

        }
        public VG0100B_W1MOVI_NUM_FAT W1MOVI_NUM_FAT { get; set; } = new VG0100B_W1MOVI_NUM_FAT();
        public class VG0100B_W1MOVI_NUM_FAT : VarBasis
        {
            /*"    10       W1ANO-FAT         PIC  9(004).*/
            public IntBasis W1ANO_FAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       FILLER            PIC  X(001)    VALUE  '-'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    10       W1MES-FAT         PIC  9(002).*/
            public IntBasis W1MES_FAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001)    VALUE  '-'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    10       W1DIA-FAT         PIC  9(002).*/
            public IntBasis W1DIA_FAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WDATA-INIVIG      PIC  X(010)    VALUE SPACES.*/
        }
        public StringBasis WDATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05         FILLER            REDEFINES      WDATA-INIVIG.*/
        private _REDEF_VG0100B_FILLER_18 _filler_18 { get; set; }
        public _REDEF_VG0100B_FILLER_18 FILLER_18
        {
            get { _filler_18 = new _REDEF_VG0100B_FILLER_18(); _.Move(WDATA_INIVIG, _filler_18); VarBasis.RedefinePassValue(WDATA_INIVIG, _filler_18, WDATA_INIVIG); _filler_18.ValueChanged += () => { _.Move(_filler_18, WDATA_INIVIG); }; return _filler_18; }
            set { VarBasis.RedefinePassValue(value, _filler_18, WDATA_INIVIG); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_18 : VarBasis
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

            public _REDEF_VG0100B_FILLER_18()
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
        private _REDEF_VG0100B_FILLER_19 _filler_19 { get; set; }
        public _REDEF_VG0100B_FILLER_19 FILLER_19
        {
            get { _filler_19 = new _REDEF_VG0100B_FILLER_19(); _.Move(WDATA_TERVIG, _filler_19); VarBasis.RedefinePassValue(WDATA_TERVIG, _filler_19, WDATA_TERVIG); _filler_19.ValueChanged += () => { _.Move(_filler_19, WDATA_TERVIG); }; return _filler_19; }
            set { VarBasis.RedefinePassValue(value, _filler_19, WDATA_TERVIG); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_19 : VarBasis
        {
            /*"    10       WTER-ANO.*/
            public VG0100B_WTER_ANO WTER_ANO { get; set; } = new VG0100B_WTER_ANO();
            public class VG0100B_WTER_ANO : VarBasis
            {
                /*"      15     WTER-ANOA         PIC  9(004).*/
                public IntBasis WTER_ANOA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WTER-BR1          PIC  X(001).*/

                public VG0100B_WTER_ANO()
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

            public _REDEF_VG0100B_FILLER_19()
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
        private _REDEF_VG0100B_FILLER_20 _filler_20 { get; set; }
        public _REDEF_VG0100B_FILLER_20 FILLER_20
        {
            get { _filler_20 = new _REDEF_VG0100B_FILLER_20(); _.Move(WDATA_CORRECAO, _filler_20); VarBasis.RedefinePassValue(WDATA_CORRECAO, _filler_20, WDATA_CORRECAO); _filler_20.ValueChanged += () => { _.Move(_filler_20, WDATA_CORRECAO); }; return _filler_20; }
            set { VarBasis.RedefinePassValue(value, _filler_20, WDATA_CORRECAO); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_20 : VarBasis
        {
            /*"    10       WCOR-ANO.*/
            public VG0100B_WCOR_ANO WCOR_ANO { get; set; } = new VG0100B_WCOR_ANO();
            public class VG0100B_WCOR_ANO : VarBasis
            {
                /*"      15     WCOR-ANOA         PIC  9(004).*/
                public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WCOR-BR1          PIC  X(001).*/

                public VG0100B_WCOR_ANO()
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

            public _REDEF_VG0100B_FILLER_20()
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
        private _REDEF_VG0100B_FILLER_21 _filler_21 { get; set; }
        public _REDEF_VG0100B_FILLER_21 FILLER_21
        {
            get { _filler_21 = new _REDEF_VG0100B_FILLER_21(); _.Move(WDATA_REFERENCIA, _filler_21); VarBasis.RedefinePassValue(WDATA_REFERENCIA, _filler_21, WDATA_REFERENCIA); _filler_21.ValueChanged += () => { _.Move(_filler_21, WDATA_REFERENCIA); }; return _filler_21; }
            set { VarBasis.RedefinePassValue(value, _filler_21, WDATA_REFERENCIA); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_21 : VarBasis
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

            public _REDEF_VG0100B_FILLER_21()
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
        private _REDEF_VG0100B_FILLER_22 _filler_22 { get; set; }
        public _REDEF_VG0100B_FILLER_22 FILLER_22
        {
            get { _filler_22 = new _REDEF_VG0100B_FILLER_22(); _.Move(WDATA_PARAMETRO, _filler_22); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_22, WDATA_PARAMETRO); _filler_22.ValueChanged += () => { _.Move(_filler_22, WDATA_PARAMETRO); }; return _filler_22; }
            set { VarBasis.RedefinePassValue(value, _filler_22, WDATA_PARAMETRO); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_22 : VarBasis
        {
            /*"    10       WPAR-DIA          PIC  9(002).*/
            public IntBasis WPAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WPAR-MES          PIC  9(002).*/
            public IntBasis WPAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WPAR-ANO          PIC  9(004).*/
            public IntBasis WPAR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WDATA-RETORNO     PIC  9(008)    VALUE ZEROS.*/

            public _REDEF_VG0100B_FILLER_22()
            {
                WPAR_DIA.ValueChanged += OnValueChanged;
                WPAR_MES.ValueChanged += OnValueChanged;
                WPAR_ANO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WDATA_RETORNO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"  05         FILLER            REDEFINES      WDATA-RETORNO.*/
        private _REDEF_VG0100B_FILLER_23 _filler_23 { get; set; }
        public _REDEF_VG0100B_FILLER_23 FILLER_23
        {
            get { _filler_23 = new _REDEF_VG0100B_FILLER_23(); _.Move(WDATA_RETORNO, _filler_23); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_23, WDATA_RETORNO); _filler_23.ValueChanged += () => { _.Move(_filler_23, WDATA_RETORNO); }; return _filler_23; }
            set { VarBasis.RedefinePassValue(value, _filler_23, WDATA_RETORNO); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_23 : VarBasis
        {
            /*"    10       WRET-DIA          PIC  9(002).*/
            public IntBasis WRET_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WRET-MES          PIC  9(002).*/
            public IntBasis WRET_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WRET-ANO          PIC  9(004).*/
            public IntBasis WRET_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WPROSOMD1.*/

            public _REDEF_VG0100B_FILLER_23()
            {
                WRET_DIA.ValueChanged += OnValueChanged;
                WRET_MES.ValueChanged += OnValueChanged;
                WRET_ANO.ValueChanged += OnValueChanged;
            }

        }
        public VG0100B_WPROSOMD1 WPROSOMD1 { get; set; } = new VG0100B_WPROSOMD1();
        public class VG0100B_WPROSOMD1 : VarBasis
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
        /*"  05         AC-I-V0SOLICFAT   PIC  9(004)    VALUE ZEROS.*/
        public IntBasis AC_I_V0SOLICFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
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
        /*"  05         AC-I-V0ENDOSSO    PIC  9(004)    VALUE ZEROS.*/
        public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05         AC-I-V0COBERAPOL  PIC  9(004)    VALUE ZEROS.*/
        public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
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
        private _REDEF_VG0100B_FILLER_24 _filler_24 { get; set; }
        public _REDEF_VG0100B_FILLER_24 FILLER_24
        {
            get { _filler_24 = new _REDEF_VG0100B_FILLER_24(); _.Move(WDATA_REL, _filler_24); VarBasis.RedefinePassValue(WDATA_REL, _filler_24, WDATA_REL); _filler_24.ValueChanged += () => { _.Move(_filler_24, WDATA_REL); }; return _filler_24; }
            set { VarBasis.RedefinePassValue(value, _filler_24, WDATA_REL); }
        }  //Redefines
        public class _REDEF_VG0100B_FILLER_24 : VarBasis
        {
            /*"    10       WDAT-REL-ANO      PIC  9(004).*/
            public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDAT-REL-MES      PIC  9(002).*/
            public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDAT-REL-DIA      PIC  9(002).*/
            public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WDAT-REL-LIT.*/

            public _REDEF_VG0100B_FILLER_24()
            {
                WDAT_REL_ANO.ValueChanged += OnValueChanged;
                FILLER_25.ValueChanged += OnValueChanged;
                WDAT_REL_MES.ValueChanged += OnValueChanged;
                FILLER_26.ValueChanged += OnValueChanged;
                WDAT_REL_DIA.ValueChanged += OnValueChanged;
            }

        }
        public VG0100B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG0100B_WDAT_REL_LIT();
        public class VG0100B_WDAT_REL_LIT : VarBasis
        {
            /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WTIME-DAY         PIC  99.99.99.*/
        }
        public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"  05         WTIME-DAYR        REDEFINES      WTIME-DAY.*/
        private _REDEF_VG0100B_WTIME_DAYR _wtime_dayr { get; set; }
        public _REDEF_VG0100B_WTIME_DAYR WTIME_DAYR
        {
            get { _wtime_dayr = new _REDEF_VG0100B_WTIME_DAYR(); _.Move(WTIME_DAY, _wtime_dayr); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_dayr, WTIME_DAY); _wtime_dayr.ValueChanged += () => { _.Move(_wtime_dayr, WTIME_DAY); }; return _wtime_dayr; }
            set { VarBasis.RedefinePassValue(value, _wtime_dayr, WTIME_DAY); }
        }  //Redefines
        public class _REDEF_VG0100B_WTIME_DAYR : VarBasis
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
            /*"  05           TREL-IMPRESSAO.*/

            public _REDEF_VG0100B_WTIME_DAYR()
            {
                WTIME_HORA.ValueChanged += OnValueChanged;
                WTIME_2PT1.ValueChanged += OnValueChanged;
                WTIME_MINU.ValueChanged += OnValueChanged;
                WTIME_2PT2.ValueChanged += OnValueChanged;
                WTIME_SEGU.ValueChanged += OnValueChanged;
            }

        }
        public VG0100B_TREL_IMPRESSAO TREL_IMPRESSAO { get; set; } = new VG0100B_TREL_IMPRESSAO();
        public class VG0100B_TREL_IMPRESSAO : VarBasis
        {
            /*"    10         TREL-MASCARA.*/
            public VG0100B_TREL_MASCARA TREL_MASCARA { get; set; } = new VG0100B_TREL_MASCARA();
            public class VG0100B_TREL_MASCARA : VarBasis
            {
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0210B'*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0210B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0220B'*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0220B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0230B'*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0230B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0240B'*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0240B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0250B'*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0250B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0260B'*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0260B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0270B'*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0270B");
                /*"      15       FILLER           PIC  X(008)      VALUE 'VG0280B'*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0280B");
                /*"    10         TRELATORIOS      REDEFINES        TREL-MASCARA                                OCCURS           8    TIMES                                INDEXED BY       I03.*/
            }
            private ListBasis<_REDEF_VG0100B_TRELATORIOS> _trelatorios { get; set; }
            public ListBasis<_REDEF_VG0100B_TRELATORIOS> TRELATORIOS
            {
                get { _trelatorios = new ListBasis<_REDEF_VG0100B_TRELATORIOS>(8); _.Move(TREL_MASCARA, _trelatorios); VarBasis.RedefinePassValue(TREL_MASCARA, _trelatorios, TREL_MASCARA); _trelatorios.ValueChanged += () => { _.Move(_trelatorios, TREL_MASCARA); }; return _trelatorios; }
                set { VarBasis.RedefinePassValue(value, _trelatorios, TREL_MASCARA); }
            }  //Redefines
            public class _REDEF_VG0100B_TRELATORIOS : VarBasis
            {
                /*"      15       CODREL           PIC  X(008).*/
                public StringBasis CODREL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  05           TACUM-IMPRESSAO.*/

                public _REDEF_VG0100B_TRELATORIOS()
                {
                    CODREL.ValueChanged += OnValueChanged;
                }

            }
        }
        public VG0100B_TACUM_IMPRESSAO TACUM_IMPRESSAO { get; set; } = new VG0100B_TACUM_IMPRESSAO();
        public class VG0100B_TACUM_IMPRESSAO : VarBasis
        {
            /*"    10         TACUM-MASCARA.*/
            public VG0100B_TACUM_MASCARA TACUM_MASCARA { get; set; } = new VG0100B_TACUM_MASCARA();
            public class VG0100B_TACUM_MASCARA : VarBasis
            {
                /*"      15       FILLER           PIC S9(013)      VALUE +0 COMP-3*/
                public IntBasis FILLER_37 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis FILLER_38 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_39 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis FILLER_40 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_41 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_42 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
                /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                public DoubleBasis FILLER_49 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                public DoubleBasis FILLER_50 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"      15       FILLER           PIC  X(001)      VALUE  SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_52 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"      15       TACUM-CAMPOS.*/
                public VG0100B_TACUM_CAMPOS TACUM_CAMPOS { get; set; } = new VG0100B_TACUM_CAMPOS();
                public class VG0100B_TACUM_CAMPOS : VarBasis
                {
                    /*"        20     TACUM-OPERACAO   OCCURS 14  TIMES INDEXED BY I01.*/
                    public ListBasis<VG0100B_TACUM_OPERACAO> TACUM_OPERACAO { get; set; } = new ListBasis<VG0100B_TACUM_OPERACAO>(14);
                    public class VG0100B_TACUM_OPERACAO : VarBasis
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
        public VG0100B_ATACUM_IMPRESSAO ATACUM_IMPRESSAO { get; set; } = new VG0100B_ATACUM_IMPRESSAO();
        public class VG0100B_ATACUM_IMPRESSAO : VarBasis
        {
            /*"    10        ATACUM-MASCARA.*/
            public VG0100B_ATACUM_MASCARA ATACUM_MASCARA { get; set; } = new VG0100B_ATACUM_MASCARA();
            public class VG0100B_ATACUM_MASCARA : VarBasis
            {
                /*"      15       FILLER           PIC S9(013)      VALUE +0 COMP-3*/
                public IntBasis FILLER_53 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis FILLER_54 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_55 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"      15       FILLER           PIC S9(004)      VALUE +0 COMP.*/
                public IntBasis FILLER_56 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_57 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_58 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
                /*"      15       FILLER           PIC S9(013)V9(2) VALUE +0 COMP-3*/
                public DoubleBasis FILLER_66 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
                /*"      15       FILLER           PIC  X(001)      VALUE  SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"      15       FILLER           PIC S9(009)      VALUE +0 COMP.*/
                public IntBasis FILLER_68 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"      15      ATACUM-CAMPOS.*/
                public VG0100B_ATACUM_CAMPOS ATACUM_CAMPOS { get; set; } = new VG0100B_ATACUM_CAMPOS();
                public class VG0100B_ATACUM_CAMPOS : VarBasis
                {
                    /*"        20    ATACUM-OPERACAO   OCCURS 14 TIMES INDEXED BY I02.*/
                    public ListBasis<VG0100B_ATACUM_OPERACAO> ATACUM_OPERACAO { get; set; } = new ListBasis<VG0100B_ATACUM_OPERACAO>(14);
                    public class VG0100B_ATACUM_OPERACAO : VarBasis
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
        public VG0100B_WABEND WABEND { get; set; } = new VG0100B_WABEND();
        public class VG0100B_WABEND : VarBasis
        {
            /*"    10      FILLER              PIC  X(010) VALUE           ' VG0100B'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0100B");
            /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"  01        LK-LINK.*/
        }
        public VG0100B_LK_LINK LK_LINK { get; set; } = new VG0100B_LK_LINK();
        public class VG0100B_LK_LINK : VarBasis
        {
            /*"      05     LK-DATA1          PIC  9(008).*/
            public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     LK-DATA2          PIC  9(008).*/
            public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }


        public VG0100B_V1SOLICFAT V1SOLICFAT { get; set; } = new VG0100B_V1SOLICFAT();
        public VG0100B_V1FATURAST V1FATURAST { get; set; } = new VG0100B_V1FATURAST();
        public VG0100B_V1SUBGRUPO V1SUBGRUPO { get; set; } = new VG0100B_V1SUBGRUPO();
        public VG0100B_V1FATURTOT1 V1FATURTOT1 { get; set; } = new VG0100B_V1FATURTOT1();
        public VG0100B_MOVIMENTO MOVIMENTO { get; set; } = new VG0100B_MOVIMENTO();
        public VG0100B_CMOVTO2 CMOVTO2 { get; set; } = new VG0100B_CMOVTO2();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -996- MOVE '010' TO WNR-EXEC-SQL. */
                _.Move("010", WABEND.WNR_EXEC_SQL);

                /*" -997- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1000- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

                /*" -1003- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1003- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -1012- MOVE SPACES TO WFIM-V1PARAMRAMO */
            _.Move("", WFIM_V1PARAMRAMO);

            /*" -1013- PERFORM R0050-00-SELECT-V1PARAMRAMO */

            R0050_00_SELECT_V1PARAMRAMO_SECTION();

            /*" -1014- IF WFIM-V1PARAMRAMO NOT EQUAL SPACES */

            if (!WFIM_V1PARAMRAMO.IsEmpty())
            {

                /*" -1016- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1017- MOVE SPACES TO WFIM-V1SISTEMA */
            _.Move("", WFIM_V1SISTEMA);

            /*" -1018- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1019- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1021- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1022- MOVE SPACES TO WFIM-V1SOLICFAT */
            _.Move("", WFIM_V1SOLICFAT);

            /*" -1024- PERFORM R0900-00-DECLARE-V1SOLICFAT */

            R0900_00_DECLARE_V1SOLICFAT_SECTION();

            /*" -1025- PERFORM R0910-00-FETCH-V1SOLICFAT */

            R0910_00_FETCH_V1SOLICFAT_SECTION();

            /*" -1026- IF WFIM-V1SOLICFAT NOT EQUAL SPACES */

            if (!WFIM_V1SOLICFAT.IsEmpty())
            {

                /*" -1027- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1029- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1032- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1SOLICFAT NOT EQUAL SPACES. */

            while (!(!WFIM_V1SOLICFAT.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1033- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1037- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1038- DISPLAY 'SOLICITACOES LIDAS       ' AC-L-V1SOLICFAT */
            _.Display($"SOLICITACOES LIDAS       {AC_L_V1SOLICFAT}");

            /*" -1039- DISPLAY 'DOCUMENTOS INSERIDOS     ' */
            _.Display($"DOCUMENTOS INSERIDOS     ");

            /*" -1040- DISPLAY ' . ENDOSSOS              ' AC-I-V0ENDOSSO */
            _.Display($" . ENDOSSOS              {AC_I_V0ENDOSSO}");

            /*" -1041- DISPLAY ' . COBERTURA APOLICE     ' AC-I-V0COBERAPOL */
            _.Display($" . COBERTURA APOLICE     {AC_I_V0COBERAPOL}");

            /*" -1042- DISPLAY 'DOCUMENTOS SELECIONADOS  ' */
            _.Display($"DOCUMENTOS SELECIONADOS  ");

            /*" -1043- DISPLAY ' . SUBGRUPOS             ' AC-S-V1SUBGRUPO */
            _.Display($" . SUBGRUPOS             {AC_S_V1SUBGRUPO}");

            /*" -1044- DISPLAY ' . FATURAS               ' AC-S-V1FATURAS */
            _.Display($" . FATURAS               {AC_S_V1FATURAS}");

            /*" -1045- DISPLAY ' . FATURA ANTERIOR       ' AC-S-V1FATURANT */
            _.Display($" . FATURA ANTERIOR       {AC_S_V1FATURANT}");

            /*" -1046- DISPLAY ' . APOLICES              ' AC-S-V1APOLICE */
            _.Display($" . APOLICES              {AC_S_V1APOLICE}");

            /*" -1047- DISPLAY ' . FATURA TOTAL          ' AC-S-V1FATURTOT */
            _.Display($" . FATURA TOTAL          {AC_S_V1FATURTOT}");

            /*" -1048- DISPLAY ' . ENDOSSOS              ' AC-S-V1ENDOSSO */
            _.Display($" . ENDOSSOS              {AC_S_V1ENDOSSO}");

            /*" -1049- DISPLAY 'DOCUMENTOS DELETADOS     ' */
            _.Display($"DOCUMENTOS DELETADOS     ");

            /*" -1050- DISPLAY ' . FATURAS               ' AC-D-V0FATURTOT */
            _.Display($" . FATURAS               {AC_D_V0FATURTOT}");

            /*" -1051- DISPLAY 'DOCUMENTOS ATUALIZADOS   ' */
            _.Display($"DOCUMENTOS ATUALIZADOS   ");

            /*" -1052- DISPLAY ' . FATURAS               ' AC-A-V0FATURAS */
            _.Display($" . FATURAS               {AC_A_V0FATURAS}");

            /*" -1053- DISPLAY ' . CONTROLE FATURAS      ' AC-A-V0FATURCONT */
            _.Display($" . CONTROLE FATURAS      {AC_A_V0FATURCONT}");

            /*" -1053- DISPLAY ' . SOLICITACAO FATURAS   ' AC-A-V0SOLICFAT. */
            _.Display($" . SOLICITACAO FATURAS   {AC_A_V0SOLICFAT}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1059- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1059- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECT-V1PARAMRAMO-SECTION */
        private void R0050_00_SELECT_V1PARAMRAMO_SECTION()
        {
            /*" -1072- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -1079- PERFORM R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1 */

            R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1();

            /*" -1082- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1083- DISPLAY 'VG0100B - V1PARAMRAMO' */
                _.Display($"VG0100B - V1PARAMRAMO");

                /*" -1083- MOVE 'S' TO WFIM-V1PARAMRAMO. */
                _.Move("S", WFIM_V1PARAMRAMO);
            }


        }

        [StopWatch]
        /*" R0050-00-SELECT-V1PARAMRAMO-DB-SELECT-1 */
        public void R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -1079- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC, RAMO_EDUCACAO INTO :V1PRAM-RAMO-VG, :V1PRAM-RAMO-AP, :V1PRAM-RAMO-VGAP, :V1PRAM-RAMO-PRESTAMISTA FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var r0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 = new R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(r0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PRAM_RAMO_VG, V1PRAM_RAMO_VG);
                _.Move(executed_1.V1PRAM_RAMO_AP, V1PRAM_RAMO_AP);
                _.Move(executed_1.V1PRAM_RAMO_VGAP, V1PRAM_RAMO_VGAP);
                _.Move(executed_1.V1PRAM_RAMO_PRESTAMISTA, V1PRAM_RAMO_PRESTAMISTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-LEITURA-V1TERMOADESAO-SECTION */
        private void R0060_00_LEITURA_V1TERMOADESAO_SECTION()
        {
            /*" -1095- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -1115- PERFORM R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1 */

            R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1();

            /*" -1118- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1119- MOVE 'N' TO WTEM-TERMO-ADESAO */
                _.Move("N", WTEM_TERMO_ADESAO);

                /*" -1120- ELSE */
            }
            else
            {


                /*" -1121- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1122- DISPLAY 'R0060 ERRO NO SELECT DO V1TERMOADESAO .' */
                    _.Display($"R0060 ERRO NO SELECT DO V1TERMOADESAO .");

                    /*" -1123- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1124- ELSE */
                }
                else
                {


                    /*" -1124- MOVE 'S' TO WTEM-TERMO-ADESAO. */
                    _.Move("S", WTEM_TERMO_ADESAO);
                }

            }


        }

        [StopWatch]
        /*" R0060-00-LEITURA-V1TERMOADESAO-DB-SELECT-1 */
        public void R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1()
        {
            /*" -1115- EXEC SQL SELECT NUM_TERMO, COD_SUBGRUPO, DATA_ADESAO, PERI_PAGAMENTO, MODALIDADE_CAPITAL INTO :NUM-TERMO, :COD-SUBGRUPO, :DATA-ADESAO, :PERI-PAGTO, :MODALIDADE-CAPITAL FROM SEGUROS.TERMO_ADESAO WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG AND SITUACAO = '0' END-EXEC. */

            var r0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1 = new R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
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
            /*" -1137- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -1142- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1145- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1146- DISPLAY 'VG0100B - SISTEMA  -- V G -- NAO CADASTRADO' */
                _.Display($"VG0100B - SISTEMA  -- V G -- NAO CADASTRADO");

                /*" -1146- MOVE 'S' TO WFIM-V1SISTEMA. */
                _.Move("S", WFIM_V1SISTEMA);
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1142- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

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
            /*" -1159- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1177- PERFORM R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1 */

            R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1();

            /*" -1179- PERFORM R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1 */

            R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1SOLICFAT-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1()
        {
            /*" -1177- EXEC SQL DECLARE V1SOLICFAT CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , NUM_RCAP , VAL_RCAP , COD_OPERACAO , SIT_REGISTRO , DATA_RCAP , DATA_VENCIMENTO , DATA_SOLICITACAO , COD_USUARIO FROM SEGUROS.V1SOLICITAFAT WHERE SIT_REGISTRO = '0' AND FONTE IS NULL ORDER BY NUM_APOLICE, COD_SUBGRUPO, NUM_FATURA END-EXEC. */
            V1SOLICFAT = new VG0100B_V1SOLICFAT(false);
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
							WHERE SIT_REGISTRO = '0' 
							AND FONTE IS NULL 
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
            /*" -1179- EXEC SQL OPEN V1SOLICFAT END-EXEC. */

            V1SOLICFAT.Open();

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-DECLARE-1 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1()
        {
            /*" -1675- EXEC SQL DECLARE V1FATURAST CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , QTD_VIDAS_VG , QTD_VIDAS_AP , IMP_MORNATU , IMP_MORACID , IMP_INVPERM , IMP_AMDS , IMP_DH , IMP_DIT , PRM_VG , PRM_AP , SIT_REGISTRO , COD_EMPRESA FROM SEGUROS.V1FATURASTOT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA <= :W2SOLF-NUM-FAT AND COD_OPERACAO = 1800 ORDER BY NUM_FATURA DESC END-EXEC. */
            V1FATURAST = new VG0100B_V1FATURAST(true);
            string GetQuery_V1FATURAST()
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
            V1FATURAST.GetQueryEvent += GetQuery_V1FATURAST;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-SECTION */
        private void R0910_00_FETCH_V1SOLICFAT_SECTION()
        {
            /*" -1192- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WABEND.WNR_EXEC_SQL);

            /*" -1204- PERFORM R0910_00_FETCH_V1SOLICFAT_DB_FETCH_1 */

            R0910_00_FETCH_V1SOLICFAT_DB_FETCH_1();

            /*" -1207- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1208- MOVE 'S' TO WFIM-V1SOLICFAT */
                _.Move("S", WFIM_V1SOLICFAT);

                /*" -1208- PERFORM R0910_00_FETCH_V1SOLICFAT_DB_CLOSE_1 */

                R0910_00_FETCH_V1SOLICFAT_DB_CLOSE_1();

                /*" -1211- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1221- MOVE V1SOLF-COD-OPER TO W1S-COD-OPER */
            _.Move(V1SOLF_COD_OPER, W1S_COD_OPER);

            /*" -1232- PERFORM R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1 */

            R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1();

            /*" -1235- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1237- DISPLAY 'APOLICE MIGRADA PARA O MULTIPREMIADO...' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                $"APOLICE MIGRADA PARA O MULTIPREMIADO...{V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();

                /*" -1238- GO TO R0910-00-FETCH-V1SOLICFAT */
                new Task(() => R0910_00_FETCH_V1SOLICFAT_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1239- ELSE */
            }
            else
            {


                /*" -1240- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1246- PERFORM R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2 */

                    R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2();

                    /*" -1248- IF SQLCODE EQUAL ZEROES */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1250- DISPLAY 'APOLICE MIGRADA PARA O MULTIPREMIADO...' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                        $"APOLICE MIGRADA PARA O MULTIPREMIADO...{V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                        .Display();

                        /*" -1251- GO TO R0910-00-FETCH-V1SOLICFAT */
                        new Task(() => R0910_00_FETCH_V1SOLICFAT_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1252- ELSE */
                    }
                    else
                    {


                        /*" -1254- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1255- ELSE */
                        }
                        else
                        {


                            /*" -1257- DISPLAY 'PROBLEMA NA LEITURA DA PROPOSTAVA... ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                            $"PROBLEMA NA LEITURA DA PROPOSTAVA... {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                            .Display();

                            /*" -1258- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1259- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -1261- DISPLAY 'PROBLEMA NA LEITURA DA PROPOSTAVA... ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                    $"PROBLEMA NA LEITURA DA PROPOSTAVA... {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                    .Display();

                    /*" -1266- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1268- PERFORM R5600-00-SELECT-V0ENDOSSO. */

            R5600_00_SELECT_V0ENDOSSO_SECTION();

            /*" -1269- IF V0ENDO-DTTERVIG NOT GREATER V1SIST-DTMOVABE */

            if (V0ENDO_DTTERVIG <= V1SIST_DTMOVABE)
            {

                /*" -1270- DISPLAY 'VIGENCIA DA APOLICE EXPIRADA. NAO CALCULADA.' */
                _.Display($"VIGENCIA DA APOLICE EXPIRADA. NAO CALCULADA.");

                /*" -1271- DISPLAY 'APOLICE = ' V1SOLF-NUM-APOL */
                _.Display($"APOLICE = {V1SOLF_NUM_APOL}");

                /*" -1272- DISPLAY 'CODSUBES= ' V1SOLF-COD-SUBG */
                _.Display($"CODSUBES= {V1SOLF_COD_SUBG}");

                /*" -1274- GO TO R0910-00-FETCH-V1SOLICFAT. */
                new Task(() => R0910_00_FETCH_V1SOLICFAT_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1274- ADD 1 TO AC-L-V1SOLICFAT. */
            AC_L_V1SOLICFAT.Value = AC_L_V1SOLICFAT + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-DB-FETCH-1 */
        public void R0910_00_FETCH_V1SOLICFAT_DB_FETCH_1()
        {
            /*" -1204- EXEC SQL FETCH V1SOLICFAT INTO :V1SOLF-NUM-APOL, :V1SOLF-COD-SUBG, :V1SOLF-NUM-FAT, :V1SOLF-NUM-RCAP, :V1SOLF-VAL-RCAP, :V1SOLF-COD-OPER, :V1SOLF-SIT-REG, :V1SOLF-DATA-RCAP:V1SOLF-DATA-RCAP-I, :V1SOLF-DATA-VENC:V1SOLF-DATA-VENC-I, :V1SOLF-DATA-SOLI:V1SOLF-DATA-SOLI-I, :V1SOLF-COD-USUAR END-EXEC. */

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
            /*" -1208- EXEC SQL CLOSE V1SOLICFAT END-EXEC */

            V1SOLICFAT.Close();

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-DB-SELECT-1 */
        public void R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1()
        {
            /*" -1232- EXEC SQL SELECT A.NRCERTIF INTO :V0PROP-NRCERTIF FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NUM_APOLICE = :V1SOLF-NUM-APOL AND A.CODSUBES = :V1SOLF-COD-SUBG AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.ORIG_PRODU IN ( 'EMPRE' , 'ESPEC' , 'ESPE1' , 'ESPE2' , 'ESPE3' ) END-EXEC. */

            var r0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1 = new R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
            };

            var executed_1 = R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1.Execute(r0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1SOLICFAT-DB-SELECT-2 */
        public void R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2()
        {
            /*" -1246- EXEC SQL SELECT VALUE(NUM_TITULO,0) INTO :NUM-TITULO FROM SEGUROS.VG_SOLICITA_FATURA WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG END-EXEC */

            var r0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1 = new R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
            };

            var executed_1 = R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1.Execute(r0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_TITULO, NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1287- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -1288- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA1 */
            _.Move(V1SOLF_NUM_FAT, WNUM_FATURA1);

            /*" -1289- MOVE WFAT-ANO1 TO W1ANO-FAT */
            _.Move(FILLER_15.WFAT_ANO1, W1MOVI_NUM_FAT.W1ANO_FAT);

            /*" -1294- MOVE WFAT-MES1 TO W1MES-FAT */
            _.Move(FILLER_15.WFAT_MES1, W1MOVI_NUM_FAT.W1MES_FAT);

            /*" -1295- IF V1SOLF-NUM-APOL EQUAL 97010000889 */

            if (V1SOLF_NUM_APOL == 97010000889)
            {

                /*" -1297- IF V1SOLF-COD-SUBG EQUAL 1 OR 1948 OR 1949 OR 1950 OR 1951 OR 2910 */

                if (V1SOLF_COD_SUBG.In("1", "1948", "1949", "1950", "1951", "2910"))
                {

                    /*" -1298- GO TO R1000-10-LEITURA */

                    R1000_10_LEITURA(); //GOTO
                    return;

                    /*" -1299- ELSE */
                }
                else
                {


                    /*" -1300- PERFORM R0060-00-LEITURA-V1TERMOADESAO */

                    R0060_00_LEITURA_V1TERMOADESAO_SECTION();

                    /*" -1301- ELSE */
                }

            }
            else
            {


                /*" -1303- MOVE 'N' TO WTEM-TERMO-ADESAO. */
                _.Move("N", WTEM_TERMO_ADESAO);
            }


            /*" -1305- PERFORM R1100-00-SELECT-V1SUBGRUPO */

            R1100_00_SELECT_V1SUBGRUPO_SECTION();

            /*" -1307- PERFORM R1600-00-SELECT-V1APOLICE. */

            R1600_00_SELECT_V1APOLICE_SECTION();

            /*" -1317- PERFORM R7777-CONS-MODALIDADE-APOL. */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -1319- IF V1SUBG-TIPO-FAT EQUAL '1' OR V1SUBG-TIPO-FAT EQUAL '3' */

            if (V1SUBG_TIPO_FAT == "1" || V1SUBG_TIPO_FAT == "3")
            {

                /*" -1320- PERFORM R2330-00-SELECT-V1FATURCONT */

                R2330_00_SELECT_V1FATURCONT_SECTION();

                /*" -1321- ELSE */
            }
            else
            {


                /*" -1323- PERFORM R2315-00-SELECT-V1FATURCONT. */

                R2315_00_SELECT_V1FATURCONT_SECTION();
            }


            /*" -1324- MOVE V1FATC-DATA-REFER TO WDATA-REFERENCIA */
            _.Move(V1FATC_DATA_REFER, WDATA_REFERENCIA);

            /*" -1325- MOVE WREF-DIA TO W1DIA-FAT */
            _.Move(FILLER_21.WREF_DIA, W1MOVI_NUM_FAT.W1DIA_FAT);

            /*" -1335- MOVE W1MOVI-NUM-FAT TO V1FATC-DATA-REFER */
            _.Move(W1MOVI_NUM_FAT, V1FATC_DATA_REFER);

            /*" -1336- IF V1SOLF-COD-OPER EQUAL 300 */

            if (V1SOLF_COD_OPER == 300)
            {

                /*" -1337- PERFORM R3500-00-SELECT-V1FATURA */

                R3500_00_SELECT_V1FATURA_SECTION();

                /*" -1338- MOVE V1FATR-DATA-INIVIG TO WDATA-INIVIG */
                _.Move(V1FATR_DATA_INIVIG, WDATA_INIVIG);

                /*" -1340- MOVE V1FATR-DATA-TERVIG TO WDATA-TERVIG DATA-TERVIG */
                _.Move(V1FATR_DATA_TERVIG, WDATA_TERVIG, DATA_TERVIG);

                /*" -1341- ELSE */
            }
            else
            {


                /*" -1342- IF V1SOLF-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 100)
                {

                    /*" -1343- MOVE SPACES TO WFIM-V1FATURAS */
                    _.Move("", WFIM_V1FATURAS);

                    /*" -1344- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
                    _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

                    /*" -1345- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
                    _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

                    /*" -1346- MOVE V1SOLF-COD-SUBG TO W1SOLF-COD-SUBG */
                    _.Move(V1SOLF_COD_SUBG, W1SOLF_COD_SUBG);

                    /*" -1347- PERFORM R1200-00-SELECT-V1FATURA */

                    R1200_00_SELECT_V1FATURA_SECTION();

                    /*" -1348- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                    if (!WFIM_V1FATURAS.IsEmpty())
                    {

                        /*" -1349- PERFORM R2310-00-DETERMINA-VIGENCIA */

                        R2310_00_DETERMINA_VIGENCIA_SECTION();

                        /*" -1350- ELSE */
                    }
                    else
                    {


                        /*" -1351- MOVE V1FATR-DATA-INIVIG TO WDATA-INIVIG */
                        _.Move(V1FATR_DATA_INIVIG, WDATA_INIVIG);

                        /*" -1353- MOVE V1FATR-DATA-TERVIG TO WDATA-TERVIG DATA-TERVIG */
                        _.Move(V1FATR_DATA_TERVIG, WDATA_TERVIG, DATA_TERVIG);

                        /*" -1354- ELSE */
                    }

                }
                else
                {


                    /*" -1356- PERFORM R2310-00-DETERMINA-VIGENCIA. */

                    R2310_00_DETERMINA_VIGENCIA_SECTION();
                }

            }


            /*" -1357- MOVE V1SUBG-DTTERVIG TO WS-DTRENOVA */
            _.Move(V1SUBG_DTTERVIG, AREA_DE_WORK.WS_DTRENOVA);

            /*" -1365- MOVE WDATA-INIVIG TO WS-DTFATUR */
            _.Move(WDATA_INIVIG, AREA_DE_WORK.WS_DTFATUR);

            /*" -1367- MOVE WDATA-INIVIG TO V1RIND-DTINIVIG */
            _.Move(WDATA_INIVIG, V1RIND_DTINIVIG);

            /*" -1379- PERFORM R1900-00-SELECT-V1RAMOIND. */

            R1900_00_SELECT_V1RAMOIND_SECTION();

            /*" -1380- IF V1SOLF-COD-SUBG NOT EQUAL ZEROS */

            if (V1SOLF_COD_SUBG != 00)
            {

                /*" -1381- PERFORM R2000-00-FATURA */

                R2000_00_FATURA_SECTION();

                /*" -1382- ELSE */
            }
            else
            {


                /*" -1383- MOVE SPACES TO WFIM-V1SUBGRUPO */
                _.Move("", WFIM_V1SUBGRUPO);

                /*" -1384- IF V1SUBG-TIPO-FAT EQUAL '2' OR '3' */

                if (V1SUBG_TIPO_FAT.In("2", "3"))
                {

                    /*" -1385- PERFORM R3000-00-FATURA-SUBG-RESUMO */

                    R3000_00_FATURA_SUBG_RESUMO_SECTION();

                    /*" -1386- ELSE */
                }
                else
                {


                    /*" -1388- PERFORM R2000-00-FATURA. */

                    R2000_00_FATURA_SECTION();
                }

            }


            /*" -1397- PERFORM R5300-00-UPDATE-V0SOLICFAT. */

            R5300_00_UPDATE_V0SOLICFAT_SECTION();

            /*" -1398- IF V1SOLF-COD-OPER EQUAL 0200 */

            if (V1SOLF_COD_OPER == 0200)
            {

                /*" -1399- PERFORM R5400-00-SELECT-V1FATURCONT */

                R5400_00_SELECT_V1FATURCONT_SECTION();

                /*" -1400- IF V9SOLF-NUM-FAT EQUAL V1SOLF-NUM-FAT */

                if (V9SOLF_NUM_FAT == V1SOLF_NUM_FAT)
                {

                    /*" -1400- PERFORM R5500-00-INSERT-V0SOLICITAFAT. */

                    R5500_00_INSERT_V0SOLICITAFAT_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA */

            R1000_10_LEITURA();

        }

        [StopWatch]
        /*" R1000-10-LEITURA */
        private void R1000_10_LEITURA(bool isPerform = false)
        {
            /*" -1406- PERFORM R0910-00-FETCH-V1SOLICFAT. */

            R0910_00_FETCH_V1SOLICFAT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1005-00-CALCULA-DTINIVIG-SECTION */
        private void R1005_00_CALCULA_DTINIVIG_SECTION()
        {
            /*" -1417- MOVE WS-DTRENOVA TO WS-DTBASE. */
            _.Move(AREA_DE_WORK.WS_DTRENOVA, AREA_DE_WORK.WS_DTBASE);

            /*" -1419- MOVE 01 TO WS-DIA. */
            _.Move(01, AREA_DE_WORK.WS_DIA);

            /*" -1420- IF WS-DTFATUR GREATER WS-DTBASE */

            if (AREA_DE_WORK.WS_DTFATUR > AREA_DE_WORK.WS_DTBASE)
            {

                /*" -1420- GO TO R1005-99-SAIDA. */
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
            /*" -1425- COMPUTE WS-AABASE = WS-AABASE - 1 */
            AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE - 1;

            /*" -1427- COMPUTE WS-DDBASE = WS-DDBASE + WS-DIA */
            AREA_DE_WORK.WS_DTBASE.WS_DDBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DDBASE + AREA_DE_WORK.WS_DIA;

            /*" -1429- IF WS-MMBASE EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -1430- IF WS-DDBASE GREATER 31 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 31)
                {

                    /*" -1431- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1432- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1433- END-IF */
                }


                /*" -1435- END-IF */
            }


            /*" -1436- IF WS-MMBASE EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("04", "06", "09", "11"))
            {

                /*" -1437- IF WS-DDBASE GREATER 30 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 30)
                {

                    /*" -1438- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1439- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1440- END-IF */
                }


                /*" -1442- END-IF */
            }


            /*" -1443- IF WS-MMBASE EQUAL 02 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE == 02)
            {

                /*" -1444- IF WS-DDBASE GREATER 28 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 28)
                {

                    /*" -1445- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -1446- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -1447- END-IF */
                }


                /*" -1449- END-IF */
            }


            /*" -1450- IF WS-MMBASE GREATER 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE > 12)
            {

                /*" -1451- MOVE 01 TO WS-MMBASE */
                _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE);

                /*" -1452- COMPUTE WS-AABASE = WS-AABASE + 1 */
                AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE + 1;

                /*" -1454- END-IF */
            }


            /*" -1455- IF WS-DTFATUR-AM LESS WS-DTBASE-AM */

            if (AREA_DE_WORK.WS_DTFATUR.WS_DTFATUR_AM < AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM)
            {

                /*" -1456- MOVE ZEROS TO WS-DIA */
                _.Move(0, AREA_DE_WORK.WS_DIA);

                /*" -1456- GO TO R1005-10-DIMINUI-UM-ANO. */
                new Task(() => R1005_10_DIMINUI_UM_ANO()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1SUBGRUPO-SECTION */
        private void R1100_00_SELECT_V1SUBGRUPO_SECTION()
        {
            /*" -1468- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -1492- PERFORM R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1 */

            R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1();

            /*" -1495- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1496- DISPLAY 'R1100 - ' */
                _.Display($"R1100 - ");

                /*" -1498- DISPLAY 'NAO EXISTE SUBGRUPO PARA APOLICE ... ' V1SOLF-NUM-APOL */
                _.Display($"NAO EXISTE SUBGRUPO PARA APOLICE ... {V1SOLF_NUM_APOL}");

                /*" -1500- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1501- MOVE V1SUBG-TIPO-FAT TO W1S-TIPO-FAT */
            _.Move(V1SUBG_TIPO_FAT, W1S_TIPO_FAT);

            /*" -1502- MOVE V1SUBG-COD-FONTE TO W1S-COD-FONTE */
            _.Move(V1SUBG_COD_FONTE, W1S_COD_FONTE);

            /*" -1503- MOVE V1SUBG-COD-SUBG TO W1S-COD-SUBG */
            _.Move(V1SUBG_COD_SUBG, W1S_COD_SUBG);

            /*" -1504- MOVE V1SUBG-BCO-COB TO W1S-BCO-COB */
            _.Move(V1SUBG_BCO_COB, W1S_BCO_COB);

            /*" -1505- MOVE V1SUBG-AGE-COB TO W1S-AGE-COB */
            _.Move(V1SUBG_AGE_COB, W1S_AGE_COB);

            /*" -1506- MOVE V1SUBG-DAC-COB TO W1S-DAC-COB */
            _.Move(V1SUBG_DAC_COB, W1S_DAC_COB);

            /*" -1508- MOVE V1SUBG-END-COB TO W1S-END-COB */
            _.Move(V1SUBG_END_COB, W1S_END_COB);

            /*" -1508- ADD 1 TO AC-S-V1SUBGRUPO. */
            AC_S_V1SUBGRUPO.Value = AC_S_V1SUBGRUPO + 1;

        }

        [StopWatch]
        /*" R1100-00-SELECT-V1SUBGRUPO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -1492- EXEC SQL SELECT TIPO_FATURAMENTO , COD_FONTE , COD_SUBGRUPO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , PERI_FATURAMENTO , DTTERVIG , VALUE(IND_IOF, 'S' ) INTO :V1SUBG-TIPO-FAT , :V1SUBG-COD-FONTE , :V1SUBG-COD-SUBG , :V1SUBG-END-COB , :V1SUBG-BCO-COB , :V1SUBG-AGE-COB , :V1SUBG-DAC-COB , :V1SUBG-PERI-FATUR , :V1SUBG-DTTERVIG , :V1SUBG-IND-IOF FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG END-EXEC. */

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
                _.Move(executed_1.V1SUBG_PERI_FATUR, V1SUBG_PERI_FATUR);
                _.Move(executed_1.V1SUBG_DTTERVIG, V1SUBG_DTTERVIG);
                _.Move(executed_1.V1SUBG_IND_IOF, V1SUBG_IND_IOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1FATURA-SECTION */
        private void R1200_00_SELECT_V1FATURA_SECTION()
        {
            /*" -1524- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -1563- PERFORM R1200_00_SELECT_V1FATURA_DB_SELECT_1 */

            R1200_00_SELECT_V1FATURA_DB_SELECT_1();

            /*" -1566- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1567- MOVE '*' TO WFIM-V1FATURAS */
                _.Move("*", WFIM_V1FATURAS);

                /*" -1568- GO TO R1200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;

                /*" -1569- ELSE */
            }
            else
            {


                /*" -1570- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1571- DISPLAY 'NUM_APOLICE ==> ' W1SOLF-NUM-APOL */
                    _.Display($"NUM_APOLICE ==> {W1SOLF_NUM_APOL}");

                    /*" -1572- DISPLAY 'COD_SUBGRUPO==> ' W1SOLF-COD-SUBG */
                    _.Display($"COD_SUBGRUPO==> {W1SOLF_COD_SUBG}");

                    /*" -1574- DISPLAY 'NUM_FATURA====> ' W1SOLF-NUM-FAT. */
                    _.Display($"NUM_FATURA====> {W1SOLF_NUM_FAT}");
                }

            }


            /*" -1574- ADD 1 TO AC-S-V1FATURAS. */
            AC_S_V1FATURAS.Value = AC_S_V1FATURAS + 1;

        }

        [StopWatch]
        /*" R1200-00-SELECT-V1FATURA-DB-SELECT-1 */
        public void R1200_00_SELECT_V1FATURA_DB_SELECT_1()
        {
            /*" -1563- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , TIPO_ENDOSSO , NUM_ENDOSSO , VAL_FATURA , COD_FONTE , NUM_RCAP , VAL_RCAP , DATA_INIVIGENCIA , DATA_TERVIGENCIA , SIT_REGISTRO , DATA_FATURA , DATA_RCAP , COD_EMPRESA , DATA_VENCIMENTO INTO :V1FATR-NUM-APOL , :V1FATR-COD-SUBG , :V1FATR-NUM-FATUR , :V1FATR-COD-OPER , :V1FATR-TIPO-ENDOS , :V1FATR-NUM-ENDOS , :V1FATR-VAL-FATURA , :V1FATR-COD-FONTE , :V1FATR-NUM-RCAP , :V1FATR-VAL-RCAP , :V1FATR-DATA-INIVIG , :V1FATR-DATA-TERVIG , :V1FATR-SIT-REG , :V1FATR-DATA-FATUR:V1FATR-DATA-FATU-I, :V1FATR-DATA-RCAP:V1FATR-DATA-RCAP-I, :V1FATR-COD-EMPRESA:VIND-COD-EMP, :V1FATR-DATA-VENC:V1FATR-DATA-VENC-I FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

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
            /*" -1587- MOVE '128' TO WNR-EXEC-SQL. */
            _.Move("128", WABEND.WNR_EXEC_SQL);

            /*" -1626- PERFORM R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1 */

            R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1();

            /*" -1629- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1630- MOVE '*' TO WFIM-FATURA-ANT */
                _.Move("*", WFIM_FATURA_ANT);

                /*" -1630- GO TO R1280-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1280_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1280-00-SELECT-V1FATURA-ANT-DB-SELECT-1 */
        public void R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1()
        {
            /*" -1626- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , TIPO_ENDOSSO , NUM_ENDOSSO , VAL_FATURA , COD_FONTE , NUM_RCAP , VAL_RCAP , DATA_INIVIGENCIA , DATA_TERVIGENCIA , SIT_REGISTRO , DATA_FATURA , DATA_RCAP , COD_EMPRESA , DATA_VENCIMENTO INTO :V1FATR-NUM-APOL , :V1FATR-COD-SUBG , :V1FATR-NUM-FATUR , :V1FATR-COD-OPER , :V1FATR-TIPO-ENDOS , :V1FATR-NUM-ENDOS , :V1FATR-VAL-FATURA , :V1FATR-COD-FONTE , :V1FATR-NUM-RCAP , :V1FATR-VAL-RCAP , :V1FATR-DATA-INIVIG , :V1FATR-DATA-TERVIG , :V1FATR-SIT-REG , :V1FATR-DATA-FATUR:V1FATR-DATA-FATU-I, :V1FATR-DATA-RCAP:V1FATR-DATA-RCAP-I, :V1FATR-COD-EMPRESA:VIND-COD-EMP, :V1FATR-DATA-VENC:V1FATR-DATA-VENC-I FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = 0 AND NUM_FATURA = :W2SOLF-NUM-FAT END-EXEC. */

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
            /*" -1643- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1644- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA */
            _.Move(V1SOLF_NUM_FAT, WNUM_FATURA);

            /*" -1645- IF WFAT-MES EQUAL 01 */

            if (FILLER_14.WFAT_MES == 01)
            {

                /*" -1646- MOVE 12 TO WFAT-MES */
                _.Move(12, FILLER_14.WFAT_MES);

                /*" -1647- SUBTRACT 1 FROM WFAT-ANO */
                FILLER_14.WFAT_ANO.Value = FILLER_14.WFAT_ANO - 1;

                /*" -1648- ELSE */
            }
            else
            {


                /*" -1650- SUBTRACT 1 FROM WFAT-MES. */
                FILLER_14.WFAT_MES.Value = FILLER_14.WFAT_MES - 1;
            }


            /*" -1652- MOVE WNUM-FATURA TO W2SOLF-NUM-FAT */
            _.Move(WNUM_FATURA, W2SOLF_NUM_FAT);

            /*" -1675- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1 */

            R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1();

            /*" -1677- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1 */

            R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1();

            /*" -1696- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_FETCH_1 */

            R1300_00_SELECT_V1FATTOT_ANT_DB_FETCH_1();

            /*" -1699- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1700- MOVE '*' TO WFIM-V1FATURANT */
                _.Move("*", WFIM_V1FATURANT);

                /*" -1700- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_CLOSE_1 */

                R1300_00_SELECT_V1FATTOT_ANT_DB_CLOSE_1();

                /*" -1703- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1704- ADD 1 TO AC-S-V1FATURANT. */
            AC_S_V1FATURANT.Value = AC_S_V1FATURANT + 1;

            /*" -1704- PERFORM R1300_00_SELECT_V1FATTOT_ANT_DB_CLOSE_2 */

            R1300_00_SELECT_V1FATTOT_ANT_DB_CLOSE_2();

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-OPEN-1 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1()
        {
            /*" -1677- EXEC SQL OPEN V1FATURAST END-EXEC. */

            V1FATURAST.Open();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1SUBGR-DB-DECLARE-1 */
        public void R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1()
        {
            /*" -1833- EXEC SQL DECLARE V1SUBGRUPO CURSOR FOR SELECT TIPO_FATURAMENTO , NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , OCORR_END_COBRAN , PERI_FATURAMENTO , VALUE(IND_IOF, 'S' ) FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO > 0 AND SIT_REGISTRO = '0' END-EXEC. */
            V1SUBGRUPO = new VG0100B_V1SUBGRUPO(true);
            string GetQuery_V1SUBGRUPO()
            {
                var query = @$"SELECT TIPO_FATURAMENTO
							, 
							NUM_APOLICE
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
							, 
							PERI_FATURAMENTO
							, 
							VALUE(IND_IOF
							, 'S' ) 
							FROM SEGUROS.V1SUBGRUPO 
							WHERE NUM_APOLICE = '{V1SOLF_NUM_APOL}' 
							AND COD_SUBGRUPO > 0 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            V1SUBGRUPO.GetQueryEvent += GetQuery_V1SUBGRUPO;

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-FETCH-1 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_FETCH_1()
        {
            /*" -1696- EXEC SQL FETCH V1FATURAST INTO :V1FATT-NUM-APOL , :V1FATT-COD-SUBG , :V1FATT-NUM-FATUR , :V1FATT-COD-OPER , :V1FATT-QT-VIDA-VG , :V1FATT-QT-VIDA-AP , :V1FATT-IMP-MORNAT , :V1FATT-IMP-MORACI , :V1FATT-IMP-INVPER , :V1FATT-IMP-AMDS , :V1FATT-IMP-DH , :V1FATT-IMP-DIT , :V1FATT-PRM-VG , :V1FATT-PRM-AP , :V1FATT-SIT-REG , :V1FATT-COD-EMPRESA:VIND-COD-EMP END-EXEC. */

            if (V1FATURAST.Fetch())
            {
                _.Move(V1FATURAST.V1FATT_NUM_APOL, V1FATT_NUM_APOL);
                _.Move(V1FATURAST.V1FATT_COD_SUBG, V1FATT_COD_SUBG);
                _.Move(V1FATURAST.V1FATT_NUM_FATUR, V1FATT_NUM_FATUR);
                _.Move(V1FATURAST.V1FATT_COD_OPER, V1FATT_COD_OPER);
                _.Move(V1FATURAST.V1FATT_QT_VIDA_VG, V1FATT_QT_VIDA_VG);
                _.Move(V1FATURAST.V1FATT_QT_VIDA_AP, V1FATT_QT_VIDA_AP);
                _.Move(V1FATURAST.V1FATT_IMP_MORNAT, V1FATT_IMP_MORNAT);
                _.Move(V1FATURAST.V1FATT_IMP_MORACI, V1FATT_IMP_MORACI);
                _.Move(V1FATURAST.V1FATT_IMP_INVPER, V1FATT_IMP_INVPER);
                _.Move(V1FATURAST.V1FATT_IMP_AMDS, V1FATT_IMP_AMDS);
                _.Move(V1FATURAST.V1FATT_IMP_DH, V1FATT_IMP_DH);
                _.Move(V1FATURAST.V1FATT_IMP_DIT, V1FATT_IMP_DIT);
                _.Move(V1FATURAST.V1FATT_PRM_VG, V1FATT_PRM_VG);
                _.Move(V1FATURAST.V1FATT_PRM_AP, V1FATT_PRM_AP);
                _.Move(V1FATURAST.V1FATT_SIT_REG, V1FATT_SIT_REG);
                _.Move(V1FATURAST.V1FATT_COD_EMPRESA, V1FATT_COD_EMPRESA);
                _.Move(V1FATURAST.VIND_COD_EMP, VIND_COD_EMP);
            }

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-CLOSE-1 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_CLOSE_1()
        {
            /*" -1700- EXEC SQL CLOSE V1FATURAST END-EXEC */

            V1FATURAST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V1FATTOT-ANT-DB-CLOSE-2 */
        public void R1300_00_SELECT_V1FATTOT_ANT_DB_CLOSE_2()
        {
            /*" -1704- EXEC SQL CLOSE V1FATURAST END-EXEC. */

            V1FATURAST.Close();

        }

        [StopWatch]
        /*" R1400-00-SELECT-V0NUMEROAES-SECTION */
        private void R1400_00_SELECT_V0NUMEROAES_SECTION()
        {
            /*" -1718- COMPUTE PRM-TOTAL = PRM-AP(13) + PRM-VG(13). */
            AREA_DE_WORK.PRM_TOTAL.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value;

            /*" -1720- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1730- PERFORM R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1 */

            R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1();

            /*" -1733- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1736- DISPLAY 'R1400-00 (NAO EXITE NA V1NUMERO-AES) ... ' ' ' V1APOL-ORGAO ' ' V1APOL-RAMO */

                $"R1400-00 (NAO EXITE NA V1NUMERO-AES) ...  {V1APOL_ORGAO} {V1APOL_RAMO}"
                .Display();

                /*" -1738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1739- IF PRM-TOTAL LESS ZEROS */

            if (AREA_DE_WORK.PRM_TOTAL < 00)
            {

                /*" -1741- COMPUTE V0NAES-ENDOSRES = V0NAES-ENDOSRES + 1 */
                V0NAES_ENDOSRES.Value = V0NAES_ENDOSRES + 1;

                /*" -1743- COMPUTE PRM-TOTAL = PRM-TOTAL * -1 */
                AREA_DE_WORK.PRM_TOTAL.Value = AREA_DE_WORK.PRM_TOTAL * -1;

                /*" -1744- MOVE '3' TO W1ENDO-TIPEND */
                _.Move("3", W1ENDO_TIPEND);

                /*" -1745- MOVE V0NAES-ENDOSRES TO W1ENDO-NRENDOS */
                _.Move(V0NAES_ENDOSRES, W1ENDO_NRENDOS);

                /*" -1746- ELSE */
            }
            else
            {


                /*" -1747- IF PRM-TOTAL EQUAL ZEROS */

                if (AREA_DE_WORK.PRM_TOTAL == 00)
                {

                    /*" -1749- COMPUTE V0NAES-ENDOSSEM = V0NAES-ENDOSSEM + 1 */
                    V0NAES_ENDOSSEM.Value = V0NAES_ENDOSSEM + 1;

                    /*" -1750- MOVE '4' TO W1ENDO-TIPEND */
                    _.Move("4", W1ENDO_TIPEND);

                    /*" -1751- MOVE V0NAES-ENDOSSEM TO W1ENDO-NRENDOS */
                    _.Move(V0NAES_ENDOSSEM, W1ENDO_NRENDOS);

                    /*" -1752- ELSE */
                }
                else
                {


                    /*" -1754- COMPUTE V0NAES-ENDOSCOB = V0NAES-ENDOSCOB + 1 */
                    V0NAES_ENDOSCOB.Value = V0NAES_ENDOSCOB + 1;

                    /*" -1755- MOVE '1' TO W1ENDO-TIPEND */
                    _.Move("1", W1ENDO_TIPEND);

                    /*" -1755- MOVE V0NAES-ENDOSCOB TO W1ENDO-NRENDOS. */
                    _.Move(V0NAES_ENDOSCOB, W1ENDO_NRENDOS);
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0NUMEROAES-DB-SELECT-1 */
        public void R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1()
        {
            /*" -1730- EXEC SQL SELECT ENDOSCOB , ENDOSRES , ENDOSSEM INTO :V0NAES-ENDOSCOB , :V0NAES-ENDOSRES , :V0NAES-ENDOSSEM FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V1APOL-ORGAO AND COD_RAMO = :V1APOL-RAMO END-EXEC. */

            var r1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1 = new R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1()
            {
                V1APOL_ORGAO = V1APOL_ORGAO.ToString(),
                V1APOL_RAMO = V1APOL_RAMO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NAES_ENDOSCOB, V0NAES_ENDOSCOB);
                _.Move(executed_1.V0NAES_ENDOSRES, V0NAES_ENDOSRES);
                _.Move(executed_1.V0NAES_ENDOSSEM, V0NAES_ENDOSSEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-UPDATE-V0NUMEROAES-SECTION */
        private void R1410_00_UPDATE_V0NUMEROAES_SECTION()
        {
            /*" -1768- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -1776- PERFORM R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1 */

            R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1();

            /*" -1779- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1782- DISPLAY 'R1410-00 (PROBLEMAS UPDATE NUMERO-AES) ... ' ' ' V1APOL-ORGAO ' ' V1APOL-RAMO */

                $"R1410-00 (PROBLEMAS UPDATE NUMERO-AES) ...  {V1APOL_ORGAO} {V1APOL_RAMO}"
                .Display();

                /*" -1782- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1410-00-UPDATE-V0NUMEROAES-DB-UPDATE-1 */
        public void R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1()
        {
            /*" -1776- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0NAES-ENDOSCOB , ENDOSRES = :V0NAES-ENDOSRES , ENDOSSEM = :V0NAES-ENDOSSEM, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_ORGAO = :V1APOL-ORGAO AND COD_RAMO = :V1APOL-RAMO END-EXEC. */

            var r1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1 = new R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1()
            {
                V0NAES_ENDOSCOB = V0NAES_ENDOSCOB.ToString(),
                V0NAES_ENDOSRES = V0NAES_ENDOSRES.ToString(),
                V0NAES_ENDOSSEM = V0NAES_ENDOSSEM.ToString(),
                V1APOL_ORGAO = V1APOL_ORGAO.ToString(),
                V1APOL_RAMO = V1APOL_RAMO.ToString(),
            };

            R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1.Execute(r1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-UPDATE-V0FONTE-SECTION */
        private void R1420_00_UPDATE_V0FONTE_SECTION()
        {
            /*" -1795- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1800- PERFORM R1420_00_UPDATE_V0FONTE_DB_UPDATE_1 */

            R1420_00_UPDATE_V0FONTE_DB_UPDATE_1();

            /*" -1803- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1805- DISPLAY 'R1420-00 (PROBLEMAS UPDATE V0FONTE) ... ' ' ' V1SUBG-COD-FONTE */

                $"R1420-00 (PROBLEMAS UPDATE V0FONTE) ...  {V1SUBG_COD_FONTE}"
                .Display();

                /*" -1805- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1420-00-UPDATE-V0FONTE-DB-UPDATE-1 */
        public void R1420_00_UPDATE_V0FONTE_DB_UPDATE_1()
        {
            /*" -1800- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V0FONT-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :W1SUBG-COD-FONTE END-EXEC. */

            var r1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1 = new R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1()
            {
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                W1SUBG_COD_FONTE = W1SUBG_COD_FONTE.ToString(),
            };

            R1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1.Execute(r1420_00_UPDATE_V0FONTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-DECLARE-V1SUBGR-SECTION */
        private void R1500_00_DECLARE_V1SUBGR_SECTION()
        {
            /*" -1818- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -1833- PERFORM R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1 */

            R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1();

            /*" -1835- PERFORM R1500_00_DECLARE_V1SUBGR_DB_OPEN_1 */

            R1500_00_DECLARE_V1SUBGR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R1500-00-DECLARE-V1SUBGR-DB-OPEN-1 */
        public void R1500_00_DECLARE_V1SUBGR_DB_OPEN_1()
        {
            /*" -1835- EXEC SQL OPEN V1SUBGRUPO END-EXEC. */

            V1SUBGRUPO.Open();

        }

        [StopWatch]
        /*" R1700-00-ACESSA-TOTAIS-DB-DECLARE-1 */
        public void R1700_00_ACESSA_TOTAIS_DB_DECLARE_1()
        {
            /*" -1931- EXEC SQL DECLARE V1FATURTOT1 CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_FATURA , COD_OPERACAO , QTD_VIDAS_VG , QTD_VIDAS_AP , IMP_MORNATU , IMP_MORACID , IMP_INVPERM , IMP_AMDS , IMP_DH , IMP_DIT , PRM_VG , PRM_AP , SIT_REGISTRO , COD_EMPRESA FROM SEGUROS.V1FATURASTOT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */
            V1FATURTOT1 = new VG0100B_V1FATURTOT1(true);
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
            /*" -1848- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -1859- PERFORM R1510_00_FETCH_V1SUBGR_DB_FETCH_1 */

            R1510_00_FETCH_V1SUBGR_DB_FETCH_1();

            /*" -1862- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1863- MOVE 'S' TO WFIM-V1SUBGRUPO */
                _.Move("S", WFIM_V1SUBGRUPO);

                /*" -1863- PERFORM R1510_00_FETCH_V1SUBGR_DB_CLOSE_1 */

                R1510_00_FETCH_V1SUBGR_DB_CLOSE_1();

                /*" -1866- GO TO R1510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1866- ADD 1 TO AC-S-V1SUBGRUPO. */
            AC_S_V1SUBGRUPO.Value = AC_S_V1SUBGRUPO + 1;

        }

        [StopWatch]
        /*" R1510-00-FETCH-V1SUBGR-DB-FETCH-1 */
        public void R1510_00_FETCH_V1SUBGR_DB_FETCH_1()
        {
            /*" -1859- EXEC SQL FETCH V1SUBGRUPO INTO :V1SUBG-TIPO-FAT , :V1SUBG-NUM-APOL , :V1SUBG-COD-SUBG , :V1SUBG-COD-FONTE , :V1SUBG-BCO-COB , :V1SUBG-AGE-COB , :V1SUBG-DAC-COB , :V1SUBG-END-COB , :V1SUBG-PERI-FATUR , :V1SUBG-IND-IOF END-EXEC. */

            if (V1SUBGRUPO.Fetch())
            {
                _.Move(V1SUBGRUPO.V1SUBG_TIPO_FAT, V1SUBG_TIPO_FAT);
                _.Move(V1SUBGRUPO.V1SUBG_NUM_APOL, V1SUBG_NUM_APOL);
                _.Move(V1SUBGRUPO.V1SUBG_COD_SUBG, V1SUBG_COD_SUBG);
                _.Move(V1SUBGRUPO.V1SUBG_COD_FONTE, V1SUBG_COD_FONTE);
                _.Move(V1SUBGRUPO.V1SUBG_BCO_COB, V1SUBG_BCO_COB);
                _.Move(V1SUBGRUPO.V1SUBG_AGE_COB, V1SUBG_AGE_COB);
                _.Move(V1SUBGRUPO.V1SUBG_DAC_COB, V1SUBG_DAC_COB);
                _.Move(V1SUBGRUPO.V1SUBG_END_COB, V1SUBG_END_COB);
                _.Move(V1SUBGRUPO.V1SUBG_PERI_FATUR, V1SUBG_PERI_FATUR);
                _.Move(V1SUBGRUPO.V1SUBG_IND_IOF, V1SUBG_IND_IOF);
            }

        }

        [StopWatch]
        /*" R1510-00-FETCH-V1SUBGR-DB-CLOSE-1 */
        public void R1510_00_FETCH_V1SUBGR_DB_CLOSE_1()
        {
            /*" -1863- EXEC SQL CLOSE V1SUBGRUPO END-EXEC */

            V1SUBGRUPO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-V1APOLICE-SECTION */
        private void R1600_00_SELECT_V1APOLICE_SECTION()
        {
            /*" -1879- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1888- PERFORM R1600_00_SELECT_V1APOLICE_DB_SELECT_1 */

            R1600_00_SELECT_V1APOLICE_DB_SELECT_1();

            /*" -1891- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1893- DISPLAY 'R1600-00 (NAO EXITE NA V1APOLICE) ... ' ' ' V1SOLF-NUM-APOL */

                $"R1600-00 (NAO EXITE NA V1APOLICE) ...  {V1SOLF_NUM_APOL}"
                .Display();

                /*" -1895- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1895- ADD 1 TO AC-S-V1APOLICE. */
            AC_S_V1APOLICE.Value = AC_S_V1APOLICE + 1;

        }

        [StopWatch]
        /*" R1600-00-SELECT-V1APOLICE-DB-SELECT-1 */
        public void R1600_00_SELECT_V1APOLICE_DB_SELECT_1()
        {
            /*" -1888- EXEC SQL SELECT ORGAO, RAMO, MODALIDA INTO :V1APOL-ORGAO, :V1APOL-RAMO, :V1APOL-MODALIDA FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1SOLF-NUM-APOL END-EXEC. */

            var r1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 = new R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_ORGAO, V1APOL_ORGAO);
                _.Move(executed_1.V1APOL_RAMO, V1APOL_RAMO);
                _.Move(executed_1.V1APOL_MODALIDA, V1APOL_MODALIDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-ACESSA-TOTAIS-SECTION */
        private void R1700_00_ACESSA_TOTAIS_SECTION()
        {
            /*" -1908- MOVE SPACES TO WFIM-V1FATURTOT */
            _.Move("", WFIM_V1FATURTOT);

            /*" -1910- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -1931- PERFORM R1700_00_ACESSA_TOTAIS_DB_DECLARE_1 */

            R1700_00_ACESSA_TOTAIS_DB_DECLARE_1();

            /*" -1933- PERFORM R1700_00_ACESSA_TOTAIS_DB_OPEN_1 */

            R1700_00_ACESSA_TOTAIS_DB_OPEN_1();

            /*" -1936- PERFORM R1710-00-FETCH-V1FATURASTOT UNTIL WFIM-V1FATURTOT EQUAL 'S' . */

            while (!(WFIM_V1FATURTOT == "S"))
            {

                R1710_00_FETCH_V1FATURASTOT_SECTION();
            }

        }

        [StopWatch]
        /*" R1700-00-ACESSA-TOTAIS-DB-OPEN-1 */
        public void R1700_00_ACESSA_TOTAIS_DB_OPEN_1()
        {
            /*" -1933- EXEC SQL OPEN V1FATURTOT1 END-EXEC. */

            V1FATURTOT1.Open();

        }

        [StopWatch]
        /*" M-6100-DECLARE-MOVIM-DB-DECLARE-1 */
        public void M_6100_DECLARE_MOVIM_DB_DECLARE_1()
        {
            /*" -3998- EXEC SQL DECLARE MOVIMENTO CURSOR FOR SELECT IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_MOVIMENTO , DATA_FATURA FROM SEGUROS.V0MOVIMENTO WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SUB-GRUPO AND DATA_INCLUSAO IS NOT NULL AND DATA_REFERENCIA = :V1FATC-DATA-REFER END-EXEC. */
            MOVIMENTO = new VG0100B_MOVIMENTO(true);
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
							AND COD_SUBGRUPO = '{W1SUB_GRUPO}' 
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
            /*" -1949- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -1966- PERFORM R1710_00_FETCH_V1FATURASTOT_DB_FETCH_1 */

            R1710_00_FETCH_V1FATURASTOT_DB_FETCH_1();

            /*" -1969- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1970- MOVE 'S' TO WFIM-V1FATURTOT */
                _.Move("S", WFIM_V1FATURTOT);

                /*" -1970- PERFORM R1710_00_FETCH_V1FATURASTOT_DB_CLOSE_1 */

                R1710_00_FETCH_V1FATURASTOT_DB_CLOSE_1();

                /*" -1973- GO TO R1710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1975- PERFORM R1720-00-GUARDA-TOTAIS */

            R1720_00_GUARDA_TOTAIS_SECTION();

            /*" -1975- ADD 1 TO AC-S-V1FATURTOT. */
            AC_S_V1FATURTOT.Value = AC_S_V1FATURTOT + 1;

        }

        [StopWatch]
        /*" R1710-00-FETCH-V1FATURASTOT-DB-FETCH-1 */
        public void R1710_00_FETCH_V1FATURASTOT_DB_FETCH_1()
        {
            /*" -1966- EXEC SQL FETCH V1FATURTOT1 INTO :V1FATT-NUM-APOL , :V1FATT-COD-SUBG , :V1FATT-NUM-FATUR , :V1FATT-COD-OPER , :V1FATT-QT-VIDA-VG , :V1FATT-QT-VIDA-AP , :V1FATT-IMP-MORNAT , :V1FATT-IMP-MORACI , :V1FATT-IMP-INVPER , :V1FATT-IMP-AMDS , :V1FATT-IMP-DH , :V1FATT-IMP-DIT , :V1FATT-PRM-VG , :V1FATT-PRM-AP , :V1FATT-SIT-REG , :V1FATT-COD-EMPRESA:VIND-COD-EMP END-EXEC. */

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
            /*" -1970- EXEC SQL CLOSE V1FATURTOT1 END-EXEC */

            V1FATURTOT1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/

        [StopWatch]
        /*" R1720-00-GUARDA-TOTAIS-SECTION */
        private void R1720_00_GUARDA_TOTAIS_SECTION()
        {
            /*" -1987- IF V1FATT-COD-OPER EQUAL 100 */

            if (V1FATT_COD_OPER == 100)
            {

                /*" -1989- SET I01 TO +2. */
                I01.Value = +2;
            }


            /*" -1990- IF V1FATT-COD-OPER EQUAL 200 */

            if (V1FATT_COD_OPER == 200)
            {

                /*" -1992- SET I01 TO +3. */
                I01.Value = +3;
            }


            /*" -1993- IF V1FATT-COD-OPER EQUAL 300 */

            if (V1FATT_COD_OPER == 300)
            {

                /*" -1995- SET I01 TO +4. */
                I01.Value = +4;
            }


            /*" -1996- IF V1FATT-COD-OPER EQUAL 400 */

            if (V1FATT_COD_OPER == 400)
            {

                /*" -1998- SET I01 TO +5. */
                I01.Value = +5;
            }


            /*" -1999- IF V1FATT-COD-OPER EQUAL 500 */

            if (V1FATT_COD_OPER == 500)
            {

                /*" -2001- SET I01 TO +6. */
                I01.Value = +6;
            }


            /*" -2002- IF V1FATT-COD-OPER EQUAL 1100 */

            if (V1FATT_COD_OPER == 1100)
            {

                /*" -2004- SET I01 TO +7. */
                I01.Value = +7;
            }


            /*" -2005- IF V1FATT-COD-OPER EQUAL 1200 */

            if (V1FATT_COD_OPER == 1200)
            {

                /*" -2007- SET I01 TO +8. */
                I01.Value = +8;
            }


            /*" -2008- IF V1FATT-COD-OPER EQUAL 1300 */

            if (V1FATT_COD_OPER == 1300)
            {

                /*" -2010- SET I01 TO +9. */
                I01.Value = +9;
            }


            /*" -2011- IF V1FATT-COD-OPER EQUAL 1400 */

            if (V1FATT_COD_OPER == 1400)
            {

                /*" -2013- SET I01 TO +10. */
                I01.Value = +10;
            }


            /*" -2014- IF V1FATT-COD-OPER EQUAL 1500 */

            if (V1FATT_COD_OPER == 1500)
            {

                /*" -2016- SET I01 TO +11. */
                I01.Value = +11;
            }


            /*" -2017- IF V1FATT-COD-OPER EQUAL 1600 */

            if (V1FATT_COD_OPER == 1600)
            {

                /*" -2019- SET I01 TO +12. */
                I01.Value = +12;
            }


            /*" -2020- IF V1FATT-COD-OPER EQUAL 1700 */

            if (V1FATT_COD_OPER == 1700)
            {

                /*" -2022- SET I01 TO +13. */
                I01.Value = +13;
            }


            /*" -2023- IF V1FATT-COD-OPER EQUAL 1800 */

            if (V1FATT_COD_OPER == 1800)
            {

                /*" -2025- SET I01 TO +14. */
                I01.Value = +14;
            }


            /*" -2026- MOVE V1FATT-NUM-APOL TO NUM-APOL(I01) */
            _.Move(V1FATT_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_APOL);

            /*" -2027- MOVE V1FATT-COD-SUBG TO COD-SUBG(I01) */
            _.Move(V1FATT_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_SUBG);

            /*" -2028- MOVE V1FATT-NUM-FATUR TO NUM-FATUR(I01) */
            _.Move(V1FATT_NUM_FATUR, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_FATUR);

            /*" -2029- MOVE V1FATT-COD-OPER TO COD-OPER(I01) */
            _.Move(V1FATT_COD_OPER, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER);

            /*" -2030- MOVE V1FATT-QT-VIDA-VG TO QT-VIDA-VG(I01) */
            _.Move(V1FATT_QT_VIDA_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_VG);

            /*" -2031- MOVE V1FATT-QT-VIDA-AP TO QT-VIDA-AP(I01) */
            _.Move(V1FATT_QT_VIDA_AP, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_AP);

            /*" -2032- MOVE V1FATT-IMP-MORNAT TO IMP-MORNAT(I01) */
            _.Move(V1FATT_IMP_MORNAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORNAT);

            /*" -2033- MOVE V1FATT-IMP-MORACI TO IMP-MORACI(I01) */
            _.Move(V1FATT_IMP_MORACI, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORACI);

            /*" -2034- MOVE V1FATT-IMP-INVPER TO IMP-INVPER(I01) */
            _.Move(V1FATT_IMP_INVPER, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_INVPER);

            /*" -2035- MOVE V1FATT-IMP-AMDS TO IMP-AMDS(I01) */
            _.Move(V1FATT_IMP_AMDS, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_AMDS);

            /*" -2036- MOVE V1FATT-IMP-DH TO IMP-DH(I01) */
            _.Move(V1FATT_IMP_DH, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DH);

            /*" -2037- MOVE V1FATT-IMP-DIT TO IMP-DIT(I01) */
            _.Move(V1FATT_IMP_DIT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DIT);

            /*" -2038- MOVE V1FATT-PRM-VG TO PRM-VG(I01) */
            _.Move(V1FATT_PRM_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_VG);

            /*" -2039- MOVE V1FATT-PRM-AP TO PRM-AP(I01) */
            _.Move(V1FATT_PRM_AP, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_AP);

            /*" -2040- MOVE ZEROS TO COD-EMPRESA(I01) */
            _.Move(0, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_EMPRESA);

            /*" -2041- MOVE '0' TO SIT-REG(I01) */
            _.Move("0", TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].SIT_REG);

            /*" -2041- MOVE -1 TO VIND-COD-EMP. */
            _.Move(-1, VIND_COD_EMP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1720_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-V1ENDOSSO-SECTION */
        private void R1800_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -2054- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -2070- PERFORM R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -2073- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2075- DISPLAY 'R1800-00 (NAO EXISTE NA V1ENDOSSO) ... ' ' ' V1SUBG-NUM-APOL */

                $"R1800-00 (NAO EXISTE NA V1ENDOSSO) ...  {V1SUBG_NUM_APOL}"
                .Display();

                /*" -2077- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2077- ADD 1 TO AC-S-V1ENDOSSO. */
            AC_S_V1ENDOSSO.Value = AC_S_V1ENDOSSO + 1;

        }

        [StopWatch]
        /*" R1800-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -2070- EXEC SQL SELECT RAMO , COD_MOEDA_IMP , COD_MOEDA_PRM , OCORR_ENDERECO , CORRECAO , CODPRODU INTO :V1ENDO-RAMO , :V1ENDO-MOEDA-IMP , :V1ENDO-MOEDA-PRM , :V1ENDO-OCORR-END , :V1ENDO-CORRECAO:V1ENDO-CORRECAO-I, :V1ENDO-CODPRODU FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND NRENDOS = 0 END-EXEC. */

            var r1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_MOEDA_IMP, V1ENDO_MOEDA_IMP);
                _.Move(executed_1.V1ENDO_MOEDA_PRM, V1ENDO_MOEDA_PRM);
                _.Move(executed_1.V1ENDO_OCORR_END, V1ENDO_OCORR_END);
                _.Move(executed_1.V1ENDO_CORRECAO, V1ENDO_CORRECAO);
                _.Move(executed_1.V1ENDO_CORRECAO_I, V1ENDO_CORRECAO_I);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1850-00-SELECT-V1MOEDA-SECTION */
        private void R1850_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -2090- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -2098- PERFORM R1850_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R1850_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -2101- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2103- DISPLAY 'R1850-00 (NAO EXITE NA V1MOEDA) ... ' ' ' V1MOED-CODUNIMO */

                $"R1850-00 (NAO EXITE NA V1MOEDA) ...  {V1MOED_CODUNIMO}"
                .Display();

                /*" -2103- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1850-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R1850_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -2098- EXEC SQL SELECT CODUNIMO, VLCRUZAD INTO :V1MOED-CODUNIMO, :V1MOED-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE TIPO_MOEDA = '0' AND SITUACAO = '0' END-EXEC. */

            var r1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_CODUNIMO, V1MOED_CODUNIMO);
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1850_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-V1RAMOIND-SECTION */
        private void R1900_00_SELECT_V1RAMOIND_SECTION()
        {
            /*" -2116- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -2123- PERFORM R1900_00_SELECT_V1RAMOIND_DB_SELECT_1 */

            R1900_00_SELECT_V1RAMOIND_DB_SELECT_1();

            /*" -2126- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2128- DISPLAY 'R1900-00 (NAO EXITE NA V1RAMOIND) ... ' ' ' V1ENDO-RAMO */

                $"R1900-00 (NAO EXITE NA V1RAMOIND) ...  {V1ENDO_RAMO}"
                .Display();

                /*" -2128- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-V1RAMOIND-DB-SELECT-1 */
        public void R1900_00_SELECT_V1RAMOIND_DB_SELECT_1()
        {
            /*" -2123- EXEC SQL SELECT ISECUSTO, PCIOF INTO :V1RIND-ISECUSTO, :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1APOL-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

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
        /*" R1940-00-ACESSA-RCAPCOMP-SECTION */
        private void R1940_00_ACESSA_RCAPCOMP_SECTION()
        {
            /*" -2141- MOVE '205' TO WNR-EXEC-SQL. */
            _.Move("205", WABEND.WNR_EXEC_SQL);

            /*" -2149- PERFORM R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1 */

            R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1();

            /*" -2152- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2153- DISPLAY 'R1940   - V1RCAPCOMP NAO CADASTRADO' */
                _.Display($"R1940   - V1RCAPCOMP NAO CADASTRADO");

                /*" -2154- DISPLAY 'FONTE    10' */
                _.Display($"FONTE    10");

                /*" -2155- DISPLAY 'NRRCAP   ' V1SOLF-NUM-RCAP */
                _.Display($"NRRCAP   {V1SOLF_NUM_RCAP}");

                /*" -2155- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1940-00-ACESSA-RCAPCOMP-DB-SELECT-1 */
        public void R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1()
        {
            /*" -2149- EXEC SQL SELECT BCOAVISO, AGEAVISO INTO :V1RCAP-BCOAVISO, :V1RCAP-AGEAVISO FROM SEGUROS.V1RCAPCOMP WHERE NRRCAP = :V1SOLF-NUM-RCAP AND NRRCAPCO = 0 AND SITUACAO = '0' END-EXEC. */

            var r1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1 = new R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_RCAP = V1SOLF_NUM_RCAP.ToString(),
            };

            var executed_1 = R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1.Execute(r1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAP_BCOAVISO, V1RCAP_BCOAVISO);
                _.Move(executed_1.V1RCAP_AGEAVISO, V1RCAP_AGEAVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1940_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-SELECT-V1FONTE-SECTION */
        private void R1950_00_SELECT_V1FONTE_SECTION()
        {
            /*" -2170- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -2175- PERFORM R1950_00_SELECT_V1FONTE_DB_SELECT_1 */

            R1950_00_SELECT_V1FONTE_DB_SELECT_1();

            /*" -2178- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2180- DISPLAY 'R1950-00 (NAO EXITE NA V1FONTE) ... ' ' ' V1SUBG-COD-FONTE */

                $"R1950-00 (NAO EXITE NA V1FONTE) ...  {V1SUBG_COD_FONTE}"
                .Display();

                /*" -2182- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2185- COMPUTE V0FONT-PROPAUTOM = V0FONT-PROPAUTOM + 1. */
            V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

            /*" -2185- EXIT. */

            return;

        }

        [StopWatch]
        /*" R1950-00-SELECT-V1FONTE-DB-SELECT-1 */
        public void R1950_00_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -2175- EXEC SQL SELECT PROPAUTOM INTO :V0FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :W1SUBG-COD-FONTE END-EXEC. */

            var r1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1 = new R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1()
            {
                W1SUBG_COD_FONTE = W1SUBG_COD_FONTE.ToString(),
            };

            var executed_1 = R1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1.Execute(r1950_00_SELECT_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONT_PROPAUTOM, V0FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R2000-00-FATURA-SECTION */
        private void R2000_00_FATURA_SECTION()
        {
            /*" -2195- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -2197- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
            _.Move(TACUM_IMPRESSAO.TACUM_MASCARA, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

            /*" -2198- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

            /*" -2199- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
            _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

            /*" -2201- MOVE V1SOLF-COD-SUBG TO W1SOLF-COD-SUBG */
            _.Move(V1SOLF_COD_SUBG, W1SOLF_COD_SUBG);

            /*" -2202- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", WFIM_V1FATURAS);

            /*" -2212- PERFORM R1200-00-SELECT-V1FATURA */

            R1200_00_SELECT_V1FATURA_SECTION();

            /*" -2213- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2214- IF V1SOLF-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 100)
                {

                    /*" -2217- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -2222- GO TO R2000-10-CONTINUA. */

                        R2000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -2223- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2225- IF V1SOLF-COD-OPER EQUAL 200 AND V1FATR-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 200 && V1FATR_COD_OPER == 100)
                {

                    /*" -2231- GO TO R2000-10-CONTINUA. */

                    R2000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2232- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2233- IF V1SOLF-COD-OPER EQUAL 300 */

                if (V1SOLF_COD_OPER == 300)
                {

                    /*" -2236- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -2241- GO TO R2000-10-CONTINUA. */

                        R2000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -2242- IF WFIM-V1FATURAS NOT EQUAL SPACES */

            if (!WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2243- IF V1SOLF-COD-OPER EQUAL 100 OR 200 */

                if (V1SOLF_COD_OPER.In("100", "200"))
                {

                    /*" -2248- GO TO R2000-10-CONTINUA. */

                    R2000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2249- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -2251- IF V1SOLF-COD-OPER EQUAL 200 AND WTEM-TERMO-ADESAO EQUAL 'S' */

                if (V1SOLF_COD_OPER == 200 && WTEM_TERMO_ADESAO == "S")
                {

                    /*" -2255- GO TO R2000-10-CONTINUA. */

                    R2000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2256- DISPLAY 'R2000 - SOLICITACAO INVALIDA ... ' */
            _.Display($"R2000 - SOLICITACAO INVALIDA ... ");

            /*" -2257- DISPLAY 'APOLICE  ' V1SOLF-NUM-APOL */
            _.Display($"APOLICE  {V1SOLF_NUM_APOL}");

            /*" -2258- DISPLAY 'SUBGRUPO ' V1SOLF-COD-SUBG */
            _.Display($"SUBGRUPO {V1SOLF_COD_SUBG}");

            /*" -2259- DISPLAY 'FATURA   ' V1SOLF-NUM-FAT */
            _.Display($"FATURA   {V1SOLF_NUM_FAT}");

            /*" -2261- DISPLAY 'OPERACAO ' V1SOLF-COD-OPER */
            _.Display($"OPERACAO {V1SOLF_COD_OPER}");

            /*" -2261- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R2000-10-CONTINUA */
        private void R2000_10_CONTINUA(bool isPerform = false)
        {
            /*" -2277- IF (V1SOLF-COD-OPER EQUAL 100) OR (V1SOLF-COD-OPER EQUAL 200 AND WFIM-V1FATURAS NOT EQUAL SPACES) OR (V1SOLF-COD-OPER EQUAL 300 AND V1FATR-COD-OPER NOT EQUAL 100) */

            if ((V1SOLF_COD_OPER == 100) || (V1SOLF_COD_OPER == 200 && !WFIM_V1FATURAS.IsEmpty()) || (V1SOLF_COD_OPER == 300 && V1FATR_COD_OPER != 100))
            {

                /*" -2278- MOVE SPACES TO WFIM-V1FATURANT */
                _.Move("", WFIM_V1FATURANT);

                /*" -2279- PERFORM R1300-00-SELECT-V1FATTOT-ANT */

                R1300_00_SELECT_V1FATTOT_ANT_SECTION();

                /*" -2280- IF WFIM-V1FATURANT NOT EQUAL SPACES */

                if (!WFIM_V1FATURANT.IsEmpty())
                {

                    /*" -2281- PERFORM S0100-00-ZERA-SALDO-ANT */

                    S0100_00_ZERA_SALDO_ANT_SECTION();

                    /*" -2282- ELSE */
                }
                else
                {


                    /*" -2283- PERFORM S0200-00-MONTA-SALDO-ANT */

                    S0200_00_MONTA_SALDO_ANT_SECTION();

                    /*" -2284- ELSE */
                }

            }
            else
            {


                /*" -2286- PERFORM S0100-00-ZERA-SALDO-ANT. */

                S0100_00_ZERA_SALDO_ANT_SECTION();
            }


            /*" -2289- IF (V1SOLF-COD-OPER EQUAL 200 OR 300) AND WFIM-V1FATURAS EQUAL SPACES AND V1FATR-COD-OPER EQUAL 100 */

            if ((V1SOLF_COD_OPER.In("200", "300")) && WFIM_V1FATURAS.IsEmpty() && V1FATR_COD_OPER == 100)
            {

                /*" -2290- PERFORM R1700-00-ACESSA-TOTAIS */

                R1700_00_ACESSA_TOTAIS_SECTION();

                /*" -2291- ELSE */
            }
            else
            {


                /*" -2294- IF (V1SOLF-COD-OPER EQUAL 100 OR 200 OR 300) AND WTEM-TERMO-ADESAO EQUAL 'S' AND MODALIDADE-CAPITAL EQUAL '0' */

                if ((V1SOLF_COD_OPER.In("100", "200", "300")) && WTEM_TERMO_ADESAO == "S" && MODALIDADE_CAPITAL == "0")
                {

                    /*" -2295- PERFORM R1700-00-ACESSA-TOTAIS */

                    R1700_00_ACESSA_TOTAIS_SECTION();

                    /*" -2297- IF PRM-VG(13) EQUAL ZEROS AND PRM-AP(13) EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG == 00 && TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP == 00)
                    {

                        /*" -2298- PERFORM S0300-00-TOTALIZA-FATURA */

                        S0300_00_TOTALIZA_FATURA_SECTION();

                        /*" -2300- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2301- ELSE */
                    }

                }
                else
                {


                    /*" -2302- PERFORM R6000-00-TOTALIZA-MOVIMENTO */

                    R6000_00_TOTALIZA_MOVIMENTO_SECTION();

                    /*" -2304- PERFORM S0300-00-TOTALIZA-FATURA. */

                    S0300_00_TOTALIZA_FATURA_SECTION();
                }

            }


            /*" -2305- IF V1SOLF-COD-OPER EQUAL 100 */

            if (V1SOLF_COD_OPER == 100)
            {

                /*" -2307- MOVE W1S-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -2308- MOVE ZEROS TO W1SOLF-NUM-RCAP */
                _.Move(0, W1SOLF_NUM_RCAP);

                /*" -2309- MOVE ZEROS TO W1SOLF-VAL-RCAP */
                _.Move(0, W1SOLF_VAL_RCAP);

                /*" -2310- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -2311- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -2312- MOVE -1 TO W1SOLF-DATA-RCAP-I */
                _.Move(-1, W1SOLF_DATA_RCAP_I);

                /*" -2314- MOVE -1 TO W1SOLF-DATA-VENC-I */
                _.Move(-1, W1SOLF_DATA_VENC_I);

                /*" -2315- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -2316- MOVE '0' TO W1ENDO-TIPEND */
                    _.Move("0", W1ENDO_TIPEND);

                    /*" -2317- MOVE ZEROS TO W1ENDO-NRENDOS */
                    _.Move(0, W1ENDO_NRENDOS);

                    /*" -2318- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2319- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2320- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -2321- ELSE */
                }
                else
                {


                    /*" -2322- MOVE V1FATR-TIPO-ENDOS TO W1ENDO-TIPEND */
                    _.Move(V1FATR_TIPO_ENDOS, W1ENDO_TIPEND);

                    /*" -2323- MOVE V1FATR-NUM-ENDOS TO W1ENDO-NRENDOS */
                    _.Move(V1FATR_NUM_ENDOS, W1ENDO_NRENDOS);

                    /*" -2324- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -2325- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2326- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2327- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -2329- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


            /*" -2330- IF V1SOLF-COD-OPER EQUAL 200 OR 300 */

            if (V1SOLF_COD_OPER.In("200", "300"))
            {

                /*" -2331- MOVE W1S-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -2332- MOVE W1S-COD-SUBG TO W1SUBG-COD-SUBG */
                _.Move(W1S_COD_SUBG, W1SUBG_COD_SUBG);

                /*" -2333- MOVE W1S-BCO-COB TO W1SUBG-BCO-COB */
                _.Move(W1S_BCO_COB, W1SUBG_BCO_COB);

                /*" -2334- MOVE W1S-AGE-COB TO W1SUBG-AGE-COB */
                _.Move(W1S_AGE_COB, W1SUBG_AGE_COB);

                /*" -2335- MOVE W1S-DAC-COB TO W1SUBG-DAC-COB */
                _.Move(W1S_DAC_COB, W1SUBG_DAC_COB);

                /*" -2336- MOVE W1S-END-COB TO W1SUBG-END-COB */
                _.Move(W1S_END_COB, W1SUBG_END_COB);

                /*" -2337- MOVE V1SOLF-NUM-RCAP TO W1SOLF-NUM-RCAP */
                _.Move(V1SOLF_NUM_RCAP, W1SOLF_NUM_RCAP);

                /*" -2339- MOVE V1SOLF-VAL-RCAP TO W1SOLF-VAL-RCAP */
                _.Move(V1SOLF_VAL_RCAP, W1SOLF_VAL_RCAP);

                /*" -2340- PERFORM R6500-00-UPDATE-MOVIMENTO */

                R6500_00_UPDATE_MOVIMENTO_SECTION();

                /*" -2341- PERFORM R1400-00-SELECT-V0NUMEROAES */

                R1400_00_SELECT_V0NUMEROAES_SECTION();

                /*" -2342- PERFORM R1410-00-UPDATE-V0NUMEROAES */

                R1410_00_UPDATE_V0NUMEROAES_SECTION();

                /*" -2346- PERFORM R1950-00-SELECT-V1FONTE */

                R1950_00_SELECT_V1FONTE_SECTION();

                /*" -2347- PERFORM R5200-00-UPDATE-V0FATURCONT */

                R5200_00_UPDATE_V0FATURCONT_SECTION();

                /*" -2348- PERFORM R2300-00-MONTA-V0ENDOSSO */

                R2300_00_MONTA_V0ENDOSSO_SECTION();

                /*" -2349- PERFORM R3300-00-INSERT-V0ENDOSSO */

                R3300_00_INSERT_V0ENDOSSO_SECTION();

                /*" -2350- PERFORM R3060-00-ANEXO-V0RELATORIOS */

                R3060_00_ANEXO_V0RELATORIOS_SECTION();

                /*" -2352- PERFORM R2400-00-MONTA-COBERAPOL */

                R2400_00_MONTA_COBERAPOL_SECTION();

                /*" -2353- MOVE W1S-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -2354- MOVE V1SOLF-NUM-RCAP TO W1SOLF-NUM-RCAP */
                _.Move(V1SOLF_NUM_RCAP, W1SOLF_NUM_RCAP);

                /*" -2355- MOVE V1SOLF-VAL-RCAP TO W1SOLF-VAL-RCAP */
                _.Move(V1SOLF_VAL_RCAP, W1SOLF_VAL_RCAP);

                /*" -2356- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -2357- MOVE V1SOLF-DATA-RCAP-I TO W1SOLF-DATA-RCAP-I */
                _.Move(V1SOLF_DATA_RCAP_I, W1SOLF_DATA_RCAP_I);

                /*" -2358- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -2360- MOVE V1SOLF-DATA-VENC-I TO W1SOLF-DATA-VENC-I */
                _.Move(V1SOLF_DATA_VENC_I, W1SOLF_DATA_VENC_I);

                /*" -2361- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -2362- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2363- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -2364- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -2365- ELSE */
                }
                else
                {


                    /*" -2366- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -2367- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -2367- PERFORM R3100-00-INSERT-V0FATURAS. */

                    R3100_00_INSERT_V0FATURAS_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MONTA-V0FATURAS-SECTION */
        private void R2100_00_MONTA_V0FATURAS_SECTION()
        {
            /*" -2379- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -2380- MOVE W1SOLF-NUM-APOL TO V0FATR-NUM-APOL */
            _.Move(W1SOLF_NUM_APOL, V0FATR_NUM_APOL);

            /*" -2381- MOVE W1SOLF-COD-SUBG TO V0FATR-COD-SUBG */
            _.Move(W1SOLF_COD_SUBG, V0FATR_COD_SUBG);

            /*" -2382- MOVE W1SOLF-NUM-FAT TO V0FATR-NUM-FATUR */
            _.Move(W1SOLF_NUM_FAT, V0FATR_NUM_FATUR);

            /*" -2383- MOVE V1SOLF-COD-OPER TO V0FATR-COD-OPER */
            _.Move(V1SOLF_COD_OPER, V0FATR_COD_OPER);

            /*" -2384- MOVE W1ENDO-TIPEND TO V0FATR-TIPO-ENDOS */
            _.Move(W1ENDO_TIPEND, V0FATR_TIPO_ENDOS);

            /*" -2385- MOVE W1ENDO-NRENDOS TO V0FATR-NUM-ENDOS */
            _.Move(W1ENDO_NRENDOS, V0FATR_NUM_ENDOS);

            /*" -2388- COMPUTE V0FATR-VAL-FATURA = PRM-VG(13) + PRM-AP(13) */
            V0FATR_VAL_FATURA.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value;

            /*" -2391- COMPUTE V0FATR-VLIOCC ROUNDED = V0FATR-VAL-FATURA - (V0FATR-VAL-FATURA / (1 + (V1RIND-PCIOF / 100))) */
            V0FATR_VLIOCC.Value = V0FATR_VAL_FATURA - (V0FATR_VAL_FATURA / (1 + (V1RIND_PCIOF / 100f)));

            /*" -2392- IF V1SUBG-IND-IOF EQUAL 'N' */

            if (V1SUBG_IND_IOF == "N")
            {

                /*" -2394- MOVE ZEROS TO V0FATR-VLIOCC. */
                _.Move(0, V0FATR_VLIOCC);
            }


            /*" -2395- IF W1SOLF-NUM-RCAP NOT EQUAL ZEROS */

            if (W1SOLF_NUM_RCAP != 00)
            {

                /*" -2396- MOVE 10 TO V0FATR-COD-FONTE */
                _.Move(10, V0FATR_COD_FONTE);

                /*" -2397- ELSE */
            }
            else
            {


                /*" -2399- MOVE ZEROS TO V0FATR-COD-FONTE. */
                _.Move(0, V0FATR_COD_FONTE);
            }


            /*" -2400- MOVE W1SOLF-NUM-RCAP TO V0FATR-NUM-RCAP */
            _.Move(W1SOLF_NUM_RCAP, V0FATR_NUM_RCAP);

            /*" -2401- MOVE W1SOLF-VAL-RCAP TO V0FATR-VAL-RCAP */
            _.Move(W1SOLF_VAL_RCAP, V0FATR_VAL_RCAP);

            /*" -2402- MOVE WDATA-INIVIG TO V0FATR-DATA-INIVIG */
            _.Move(WDATA_INIVIG, V0FATR_DATA_INIVIG);

            /*" -2404- MOVE DATA-TERVIG TO V0FATR-DATA-TERVIG */
            _.Move(DATA_TERVIG, V0FATR_DATA_TERVIG);

            /*" -2406- MOVE '0' TO V0FATR-SIT-REG */
            _.Move("0", V0FATR_SIT_REG);

            /*" -2407- MOVE V1SIST-DTMOVABE TO V0FATR-DATA-FATUR */
            _.Move(V1SIST_DTMOVABE, V0FATR_DATA_FATUR);

            /*" -2409- MOVE 0 TO V0FATR-DATA-FATU-I */
            _.Move(0, V0FATR_DATA_FATU_I);

            /*" -2410- MOVE W1SOLF-DATA-RCAP TO V0FATR-DATA-RCAP */
            _.Move(W1SOLF_DATA_RCAP, V0FATR_DATA_RCAP);

            /*" -2411- MOVE W1SOLF-DATA-RCAP-I TO V0FATR-DATA-RCAP-I */
            _.Move(W1SOLF_DATA_RCAP_I, V0FATR_DATA_RCAP_I);

            /*" -2412- MOVE V1SOLF-DATA-VENC TO V0FATR-DATA-VENC */
            _.Move(V1SOLF_DATA_VENC, V0FATR_DATA_VENC);

            /*" -2413- MOVE V1SOLF-DATA-VENC-I TO V0FATR-DATA-VENC-I */
            _.Move(V1SOLF_DATA_VENC_I, V0FATR_DATA_VENC_I);

            /*" -2415- MOVE -1 TO VIND-COD-EMP. */
            _.Move(-1, VIND_COD_EMP);

            /*" -2416- IF V1SOLF-COD-OPER EQUAL 200 OR 300 */

            if (V1SOLF_COD_OPER.In("200", "300"))
            {

                /*" -2417- MOVE 'VG0200B' TO V0RELT-CODREL */
                _.Move("VG0200B", V0RELT_CODREL);

                /*" -2418- MOVE V1SOLF-DATA-SOLI TO V0RELT-DATA-SOLI */
                _.Move(V1SOLF_DATA_SOLI, V0RELT_DATA_SOLI);

                /*" -2419- MOVE V1SOLF-COD-USUAR TO V0RELT-COD-USUAR */
                _.Move(V1SOLF_COD_USUAR, V0RELT_COD_USUAR);

                /*" -2420- MOVE V1FATC-DATA-REFER TO V0RELT-DATA-REFER */
                _.Move(V1FATC_DATA_REFER, V0RELT_DATA_REFER);

                /*" -2421- MOVE W1SUBG-COD-FONTE TO V0RELT-FONTE */
                _.Move(W1SUBG_COD_FONTE, V0RELT_FONTE);

                /*" -2422- MOVE V0FATR-NUM-ENDOS TO V0RELT-NRENDOS */
                _.Move(V0FATR_NUM_ENDOS, V0RELT_NRENDOS);

                /*" -2423- MOVE V0FATR-COD-SUBG TO V0RELT-CODSUBES */
                _.Move(V0FATR_COD_SUBG, V0RELT_CODSUBES);

                /*" -2426- MOVE ZEROS TO V0RELT-COD-EMPRESA V0RELT-PERI-RENOVA V0RELT-PCT-AUMENTO */
                _.Move(0, V0RELT_COD_EMPRESA, V0RELT_PERI_RENOVA, V0RELT_PCT_AUMENTO);

                /*" -2430- MOVE -1 TO VIND-COD-EMP VIND-PERI-RENOVA VIND-PCT-AUMENTO */
                _.Move(-1, VIND_COD_EMP, VIND_PERI_RENOVA, VIND_PCT_AUMENTO);

                /*" -2430- PERFORM R3080-00-INSERT-V0RELATORIOS. */

                R3080_00_INSERT_V0RELATORIOS_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-MONTA-V0FATURASTOT-SECTION */
        private void R2200_00_MONTA_V0FATURASTOT_SECTION()
        {
            /*" -2441- SET I01 TO +2. */
            I01.Value = +2;

            /*" -0- FLUXCONTROL_PERFORM R2200_10_LOOP */

            R2200_10_LOOP();

        }

        [StopWatch]
        /*" R2200-10-LOOP */
        private void R2200_10_LOOP(bool isPerform = false)
        {
            /*" -2446- IF NUM-APOL(I01) NOT EQUAL ZEROS */

            if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_APOL != 00)
            {

                /*" -2447- MOVE NUM-APOL(I01) TO V0FATT-NUM-APOL */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_APOL, V0FATT_NUM_APOL);

                /*" -2448- MOVE COD-SUBG(I01) TO V0FATT-COD-SUBG */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_SUBG, V0FATT_COD_SUBG);

                /*" -2449- MOVE NUM-FATUR(I01) TO V0FATT-NUM-FATUR */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].NUM_FATUR, V0FATT_NUM_FATUR);

                /*" -2450- MOVE COD-OPER(I01) TO V0FATT-COD-OPER */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER, V0FATT_COD_OPER);

                /*" -2451- MOVE QT-VIDA-VG(I01) TO V0FATT-QT-VIDA-VG */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_VG, V0FATT_QT_VIDA_VG);

                /*" -2452- MOVE QT-VIDA-AP(I01) TO V0FATT-QT-VIDA-AP */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_AP, V0FATT_QT_VIDA_AP);

                /*" -2453- MOVE IMP-MORNAT(I01) TO V0FATT-IMP-MORNAT */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORNAT, V0FATT_IMP_MORNAT);

                /*" -2454- MOVE IMP-MORACI(I01) TO V0FATT-IMP-MORACI */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORACI, V0FATT_IMP_MORACI);

                /*" -2455- MOVE IMP-INVPER(I01) TO V0FATT-IMP-INVPER */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_INVPER, V0FATT_IMP_INVPER);

                /*" -2456- MOVE IMP-AMDS(I01) TO V0FATT-IMP-AMDS */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_AMDS, V0FATT_IMP_AMDS);

                /*" -2457- MOVE IMP-DH(I01) TO V0FATT-IMP-DH */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DH, V0FATT_IMP_DH);

                /*" -2458- MOVE IMP-DIT(I01) TO V0FATT-IMP-DIT */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DIT, V0FATT_IMP_DIT);

                /*" -2459- MOVE PRM-VG(I01) TO V0FATT-PRM-VG */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_VG, V0FATT_PRM_VG);

                /*" -2460- MOVE PRM-AP(I01) TO V0FATT-PRM-AP */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_AP, V0FATT_PRM_AP);

                /*" -2461- MOVE '0' TO V0FATT-SIT-REG */
                _.Move("0", V0FATT_SIT_REG);

                /*" -2463- MOVE -1 TO VIND-COD-EMP */
                _.Move(-1, VIND_COD_EMP);

                /*" -2465- PERFORM R3200-00-INSERT-V0FATURASTOT. */

                R3200_00_INSERT_V0FATURASTOT_SECTION();
            }


            /*" -2467- SET I01 UP BY +1. */
            I01.Value += +1;

            /*" -2468- IF I01 LESS 15 */

            if (I01 < 15)
            {

                /*" -2468- GO TO R2200-10-LOOP. */
                new Task(() => R2200_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-V0ENDOSSO-SECTION */
        private void R2300_00_MONTA_V0ENDOSSO_SECTION()
        {
            /*" -2482- PERFORM R1800-00-SELECT-V1ENDOSSO. */

            R1800_00_SELECT_V1ENDOSSO_SECTION();

            /*" -2484- PERFORM R1850-00-SELECT-V1MOEDA. */

            R1850_00_SELECT_V1MOEDA_SECTION();

            /*" -2485- MOVE V1MOED-VLCRUZAD TO W1MOED-VLCRUZAD-IM */
            _.Move(V1MOED_VLCRUZAD, W1MOED_VLCRUZAD_IM);

            /*" -2487- MOVE W1MOED-VLCRUZAD-IM TO W1MOED-VLCRUZAD-PR */
            _.Move(W1MOED_VLCRUZAD_IM, W1MOED_VLCRUZAD_PR);

            /*" -2489- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WABEND.WNR_EXEC_SQL);

            /*" -2490- MOVE W1SOLF-NUM-APOL TO V0ENDO-NUM-APOL */
            _.Move(W1SOLF_NUM_APOL, V0ENDO_NUM_APOL);

            /*" -2491- MOVE W1ENDO-NRENDOS TO V0ENDO-NRENDOS */
            _.Move(W1ENDO_NRENDOS, V0ENDO_NRENDOS);

            /*" -2492- MOVE W1SUBG-COD-SUBG TO V0ENDO-CODSUBES */
            _.Move(W1SUBG_COD_SUBG, V0ENDO_CODSUBES);

            /*" -2493- MOVE W1SUBG-COD-FONTE TO V0ENDO-FONTE */
            _.Move(W1SUBG_COD_FONTE, V0ENDO_FONTE);

            /*" -2494- MOVE V0FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
            _.Move(V0FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -2495- MOVE V1SIST-DTMOVABE TO V0ENDO-DATPRO */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DATPRO);

            /*" -2496- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -2497- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -2498- MOVE W1SOLF-NUM-RCAP TO V0ENDO-NRRCAP */
            _.Move(W1SOLF_NUM_RCAP, V0ENDO_NRRCAP);

            /*" -2499- MOVE W1SOLF-VAL-RCAP TO V0ENDO-VLRCAP */
            _.Move(W1SOLF_VAL_RCAP, V0ENDO_VLRCAP);

            /*" -2501- MOVE SPACES TO V0ENDO-DACRCAP */
            _.Move("", V0ENDO_DACRCAP);

            /*" -2502- IF W1ENDO-TIPEND EQUAL '4' */

            if (W1ENDO_TIPEND == "4")
            {

                /*" -2505- MOVE ZEROS TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
                _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);
            }


            /*" -2507- IF V1SOLF-NUM-RCAP EQUAL ZEROS OR W1ENDO-TIPEND EQUAL '4' */

            if (V1SOLF_NUM_RCAP == 00 || W1ENDO_TIPEND == "4")
            {

                /*" -2508- MOVE SPACES TO V0ENDO-IDRCAP */
                _.Move("", V0ENDO_IDRCAP);

                /*" -2510- MOVE ZEROS TO V0ENDO-BCORCAP V0ENDO-AGERCAP */
                _.Move(0, V0ENDO_BCORCAP, V0ENDO_AGERCAP);

                /*" -2511- ELSE */
            }
            else
            {


                /*" -2512- MOVE '1' TO V0ENDO-IDRCAP */
                _.Move("1", V0ENDO_IDRCAP);

                /*" -2513- PERFORM R1940-00-ACESSA-RCAPCOMP */

                R1940_00_ACESSA_RCAPCOMP_SECTION();

                /*" -2514- MOVE V1RCAP-BCOAVISO TO V0ENDO-BCORCAP */
                _.Move(V1RCAP_BCOAVISO, V0ENDO_BCORCAP);

                /*" -2516- MOVE V1RCAP-AGEAVISO TO V0ENDO-AGERCAP. */
                _.Move(V1RCAP_AGEAVISO, V0ENDO_AGERCAP);
            }


            /*" -2517- MOVE W1SUBG-BCO-COB TO V0ENDO-BCOCOBR */
            _.Move(W1SUBG_BCO_COB, V0ENDO_BCOCOBR);

            /*" -2518- MOVE W1SUBG-AGE-COB TO V0ENDO-AGECOBR */
            _.Move(W1SUBG_AGE_COB, V0ENDO_AGECOBR);

            /*" -2520- MOVE W1SUBG-DAC-COB TO V0ENDO-DACCOBR */
            _.Move(W1SUBG_DAC_COB, V0ENDO_DACCOBR);

            /*" -2521- MOVE WDATA-INIVIG TO V0ENDO-DTINIVIG */
            _.Move(WDATA_INIVIG, V0ENDO_DTINIVIG);

            /*" -2524- MOVE DATA-TERVIG TO V0ENDO-DTTERVIG */
            _.Move(DATA_TERVIG, V0ENDO_DTTERVIG);

            /*" -2525- MOVE ZEROS TO V0ENDO-CDFRACIO */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -2526- MOVE ZEROS TO V0ENDO-PCENTRAD */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -2528- MOVE ZEROS TO V0ENDO-PCADICIO */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -2529- MOVE V1SOLF-DATA-VENC TO WK-DATA1 */
            _.Move(V1SOLF_DATA_VENC, AREA_DE_WORK.WK_DATA1);

            /*" -2530- MOVE WK-ANO1 TO W01AACSP */
            _.Move(AREA_DE_WORK.WK_DATA1.WK_ANO1, FILLER_11.W01AACSP);

            /*" -2531- MOVE WK-MES1 TO W01MMCSP */
            _.Move(AREA_DE_WORK.WK_DATA1.WK_MES1, FILLER_11.W01MMCSP);

            /*" -2532- MOVE WK-DIA1 TO W01DDCSP */
            _.Move(AREA_DE_WORK.WK_DATA1.WK_DIA1, FILLER_11.W01DDCSP);

            /*" -2533- MOVE W01DTCSP TO LK-DATA1 */
            _.Move(W01DTCSP, LK_LINK.LK_DATA1);

            /*" -2534- MOVE V1SIST-DTMOVABE TO WK-DATA1 */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WK_DATA1);

            /*" -2535- MOVE WK-ANO1 TO W02AACSP */
            _.Move(AREA_DE_WORK.WK_DATA1.WK_ANO1, FILLER_12.W02AACSP);

            /*" -2536- MOVE WK-MES1 TO W02MMCSP */
            _.Move(AREA_DE_WORK.WK_DATA1.WK_MES1, FILLER_12.W02MMCSP);

            /*" -2537- MOVE WK-DIA1 TO W02DDCSP */
            _.Move(AREA_DE_WORK.WK_DATA1.WK_DIA1, FILLER_12.W02DDCSP);

            /*" -2538- MOVE W02DTCSP TO LK-DATA2 */
            _.Move(W02DTCSP, LK_LINK.LK_DATA2);

            /*" -2540- MOVE ZEROS TO QTDIA. */
            _.Move(0, LK_LINK.QTDIA);

            /*" -2542- CALL 'PRODIFC1' USING LK-LINK. */
            _.Call("PRODIFC1", LK_LINK);

            /*" -2543- MOVE QTDIA TO V0ENDO-PRESTA1 */
            _.Move(LK_LINK.QTDIA, V0ENDO_PRESTA1);

            /*" -2544- MOVE ZEROS TO V0ENDO-QTPARCEL */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -2545- MOVE ZEROS TO V0ENDO-QTPRESTA */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -2546- MOVE ZEROS TO V0ENDO-QTITENS */
            _.Move(0, V0ENDO_QTITENS);

            /*" -2547- MOVE SPACES TO V0ENDO-CODTXT */
            _.Move("", V0ENDO_CODTXT);

            /*" -2548- MOVE '4' TO V0ENDO-CDACEITA */
            _.Move("4", V0ENDO_CDACEITA);

            /*" -2549- MOVE V1MOED-CODUNIMO TO V0ENDO-MOEDA-IMP */
            _.Move(V1MOED_CODUNIMO, V0ENDO_MOEDA_IMP);

            /*" -2550- MOVE V1MOED-CODUNIMO TO V0ENDO-MOEDA-PRM */
            _.Move(V1MOED_CODUNIMO, V0ENDO_MOEDA_PRM);

            /*" -2551- MOVE W1ENDO-TIPEND TO V0ENDO-TIPEND */
            _.Move(W1ENDO_TIPEND, V0ENDO_TIPEND);

            /*" -2552- MOVE V1SOLF-COD-USUAR TO V0ENDO-COD-USUAR */
            _.Move(V1SOLF_COD_USUAR, V0ENDO_COD_USUAR);

            /*" -2553- MOVE W1SUBG-END-COB TO V0ENDO-OCORR-END */
            _.Move(W1SUBG_END_COB, V0ENDO_OCORR_END);

            /*" -2554- MOVE SPACES TO V0ENDO-SITUACAO */
            _.Move("", V0ENDO_SITUACAO);

            /*" -2555- MOVE V1SOLF-DATA-RCAP TO V0ENDO-DATARCAP */
            _.Move(V1SOLF_DATA_RCAP, V0ENDO_DATARCAP);

            /*" -2556- MOVE V1SOLF-DATA-RCAP-I TO V0ENDO-DATARCAP-I */
            _.Move(V1SOLF_DATA_RCAP_I, V0ENDO_DATARCAP_I);

            /*" -2557- MOVE V1ENDO-CORRECAO TO V0ENDO-CORRECAO */
            _.Move(V1ENDO_CORRECAO, V0ENDO_CORRECAO);

            /*" -2558- MOVE V1ENDO-CORRECAO-I TO V0ENDO-CORRECAO-I */
            _.Move(V1ENDO_CORRECAO_I, V0ENDO_CORRECAO_I);

            /*" -2559- MOVE 'S' TO V0ENDO-ISENTA-CST */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2561- MOVE -1 TO VIND-COD-EMP */
            _.Move(-1, VIND_COD_EMP);

            /*" -2562- IF V1SOLF-DATA-VENC-I LESS 0 */

            if (V1SOLF_DATA_VENC_I < 0)
            {

                /*" -2563- MOVE -1 TO V0ENDO-DTVENCTO-I */
                _.Move(-1, V0ENDO_DTVENCTO_I);

                /*" -2564- ELSE */
            }
            else
            {


                /*" -2565- MOVE V1SOLF-DATA-VENC TO V0ENDO-DTVENCTO */
                _.Move(V1SOLF_DATA_VENC, V0ENDO_DTVENCTO);

                /*" -2567- MOVE 0 TO V0ENDO-DTVENCTO-I. */
                _.Move(0, V0ENDO_DTVENCTO_I);
            }


            /*" -2568- MOVE 0 TO V0ENDO-CORRECAO-I. */
            _.Move(0, V0ENDO_CORRECAO_I);

            /*" -2569- MOVE 0 TO V0ENDO-CFPREFIX. */
            _.Move(0, V0ENDO_CFPREFIX);

            /*" -2570- MOVE 0 TO V0ENDO-VLCUSEMI. */
            _.Move(0, V0ENDO_VLCUSEMI);

            /*" -2571- MOVE V1ENDO-RAMO TO V0ENDO-RAMO. */
            _.Move(V1ENDO_RAMO, V0ENDO_RAMO);

            /*" -2573- MOVE V1ENDO-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V1ENDO_CODPRODU, V0ENDO_CODPRODU);

            /*" -2575- IF V0ENDO-DTINIVIG GREATER V0ENDO-DTTERVIG */

            if (V0ENDO_DTINIVIG > V0ENDO_DTTERVIG)
            {

                /*" -2576- PERFORM R2305-00-AJUSTA-VIGENCIA */

                R2305_00_AJUSTA_VIGENCIA_SECTION();

                /*" -2578- MOVE WHOST-DATA-TERVIGENCIA TO V0ENDO-DTTERVIG */
                _.Move(WHOST_DATA_TERVIGENCIA, V0ENDO_DTTERVIG);

                /*" -2578- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2305-00-AJUSTA-VIGENCIA-SECTION */
        private void R2305_00_AJUSTA_VIGENCIA_SECTION()
        {
            /*" -2595- MOVE '23A' TO WNR-EXEC-SQL. */
            _.Move("23A", WABEND.WNR_EXEC_SQL);

            /*" -2606- PERFORM R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1 */

            R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1();

            /*" -2609- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2613- DISPLAY 'R2305 - ERRO SELECT V1FATURAS ... ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG ' ' V1SOLF-NUM-FAT */

                $"R2305 - ERRO SELECT V1FATURAS ...  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG} {V1SOLF_NUM_FAT}"
                .Display();

                /*" -2613- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2305-00-AJUSTA-VIGENCIA-DB-SELECT-1 */
        public void R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1()
        {
            /*" -2606- EXEC SQL SELECT A.DATA_INIVIGENCIA + B.PERI_FATURAMENTO MONTH - 1 DAY INTO :WHOST-DATA-TERVIGENCIA FROM SEGUROS.V1FATURAS A, SEGUROS.SUBGRUPOS_VGAP B WHERE A.NUM_APOLICE = :V1SOLF-NUM-APOL AND A.COD_SUBGRUPO = :V1SOLF-COD-SUBG AND A.NUM_FATURA = :V1SOLF-NUM-FAT AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO END-EXEC. */

            var r2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 = new R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
                V1SOLF_NUM_FAT = V1SOLF_NUM_FAT.ToString(),
            };

            var executed_1 = R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1.Execute(r2305_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_TERVIGENCIA, WHOST_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2305_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-DETERMINA-VIGENCIA-SECTION */
        private void R2310_00_DETERMINA_VIGENCIA_SECTION()
        {
            /*" -2626- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WABEND.WNR_EXEC_SQL);

            /*" -2627- MOVE V1FATC-DATA-REFER TO WDATA-REFERENCIA. */
            _.Move(V1FATC_DATA_REFER, WDATA_REFERENCIA);

            /*" -2628- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA. */
            _.Move(V1SOLF_NUM_FAT, WNUM_FATURA);

            /*" -2629- MOVE WFAT-ANO TO WINI-ANO. */
            _.Move(FILLER_14.WFAT_ANO, FILLER_18.WINI_ANO);

            /*" -2630- MOVE WFAT-MES TO WINI-MES. */
            _.Move(FILLER_14.WFAT_MES, FILLER_18.WINI_MES);

            /*" -2664- MOVE WREF-DIA TO WINI-DIA. */
            _.Move(FILLER_21.WREF_DIA, FILLER_18.WINI_DIA);

            /*" -2666- MOVE DATA-TERVIG TO WDATA-TERVIG. */
            _.Move(DATA_TERVIG, WDATA_TERVIG);

            /*" -2669- MOVE '-' TO WINI-BR1 WINI-BR2 WTER-BR1 WTER-BR2. */
            _.Move("-", FILLER_18.WINI_BR1);
            _.Move("-", FILLER_18.WINI_BR2);
            _.Move("-", FILLER_19.WTER_BR1);
            _.Move("-", FILLER_19.WTER_BR2);


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V1FATURCONT-SECTION */
        private void R2315_00_SELECT_V1FATURCONT_SECTION()
        {
            /*" -2682- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", WABEND.WNR_EXEC_SQL);

            /*" -2694- PERFORM R2315_00_SELECT_V1FATURCONT_DB_SELECT_1 */

            R2315_00_SELECT_V1FATURCONT_DB_SELECT_1();

            /*" -2697- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2700- DISPLAY 'R2315 - NAO EXISTE NA V1FATURCONT ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                $"R2315 - NAO EXISTE NA V1FATURCONT  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();

                /*" -2700- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V1FATURCONT-DB-SELECT-1 */
        public void R2315_00_SELECT_V1FATURCONT_DB_SELECT_1()
        {
            /*" -2694- EXEC SQL SELECT A.DATA_REFERENCIA, A.DATA_REFERENCIA + B.PERI_FATURAMENTO MONTH - 1 DAY INTO :V1FATC-DATA-REFER, :DATA-TERVIG FROM SEGUROS.V1FATURCONT A, SEGUROS.V1SUBGRUPO B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_APOLICE = :V1SOLF-NUM-APOL AND A.COD_SUBGRUPO = :V1SOLF-COD-SUBG END-EXEC. */

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
            /*" -2738- MOVE '035' TO WNR-EXEC-SQL. */
            _.Move("035", WABEND.WNR_EXEC_SQL);

            /*" -2746- PERFORM R2330_00_SELECT_V1FATURCONT_DB_SELECT_1 */

            R2330_00_SELECT_V1FATURCONT_DB_SELECT_1();

            /*" -2749- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2752- DISPLAY 'R2330 - NAO EXISTE NA V1FATURCONT ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                $"R2330 - NAO EXISTE NA V1FATURCONT  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();

                /*" -2754- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2755- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -2757- DISPLAY 'R2330 - ACHOU MAIS DE UM SUBGRUPO ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG. */

                $"R2330 - ACHOU MAIS DE UM SUBGRUPO  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();
            }


        }

        [StopWatch]
        /*" R2330-00-SELECT-V1FATURCONT-DB-SELECT-1 */
        public void R2330_00_SELECT_V1FATURCONT_DB_SELECT_1()
        {
            /*" -2746- EXEC SQL SELECT DATA_REFERENCIA, DATA_REFERENCIA + :V1SUBG-PERI-FATUR MONTH - 1 DAY INTO :V1FATC-DATA-REFER, :DATA-TERVIG FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :V1SOLF-NUM-APOL END-EXEC. */

            var r2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 = new R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1()
            {
                V1SUBG_PERI_FATUR = V1SUBG_PERI_FATUR.ToString(),
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1.Execute(r2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATC_DATA_REFER, V1FATC_DATA_REFER);
                _.Move(executed_1.DATA_TERVIG, DATA_TERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2330_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-MONTA-COBERAPOL-SECTION */
        private void R2400_00_MONTA_COBERAPOL_SECTION()
        {
            /*" -2769- MOVE V1SOLF-NUM-APOL TO V0COBE-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, V0COBE_NUM_APOL);

            /*" -2770- MOVE W1ENDO-NRENDOS TO V0COBE-NUM-ENDOS */
            _.Move(W1ENDO_NRENDOS, V0COBE_NUM_ENDOS);

            /*" -2771- MOVE ZEROS TO V0COBE-NUM-ITEM */
            _.Move(0, V0COBE_NUM_ITEM);

            /*" -2772- MOVE ZEROS TO V0COBE-OCORR-HIST */
            _.Move(0, V0COBE_OCORR_HIST);

            /*" -2774- MOVE -1 TO VIND-COD-EMP */
            _.Move(-1, VIND_COD_EMP);

            /*" -2777- COMPUTE PRM-TOTAL = PRM-VG(13) + PRM-AP(13) */
            AREA_DE_WORK.PRM_TOTAL.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value;

            /*" -2783- COMPUTE W0COBE-PCT-COBERVG ROUNDED = (PRM-VG(13) / PRM-TOTAL) * 100 ON SIZE ERROR MOVE ZEROS TO W0COBE-PCT-COBERVG END-COMPUTE. */
            if (AREA_DE_WORK.PRM_TOTAL.Value == 0)
                _.Move(0, AREA_DE_WORK.W0COBE_PCT_COBERVG);
            else

                AREA_DE_WORK.W0COBE_PCT_COBERVG.Value = (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value / AREA_DE_WORK.PRM_TOTAL) * 100;

            /*" -2787- COMPUTE W0COBE-PCT-COBERAP = 100,00 - W0COBE-PCT-COBERVG */
            AREA_DE_WORK.W0COBE_PCT_COBERAP.Value = 100.00 - AREA_DE_WORK.W0COBE_PCT_COBERVG;

            /*" -2789- MOVE V1APOL-MODALIDA TO V0COBE-MODALIFR */
            _.Move(V1APOL_MODALIDA, V0COBE_MODALIFR);

            /*" -2790- MOVE WDATA-INIVIG TO V0COBE-DATA-INIVIG */
            _.Move(WDATA_INIVIG, V0COBE_DATA_INIVIG);

            /*" -2793- MOVE DATA-TERVIG TO V0COBE-DATA-TERVIG */
            _.Move(DATA_TERVIG, V0COBE_DATA_TERVIG);

            /*" -2801- MOVE 1 TO V0COBE-FAT-MULT */
            _.Move(1, V0COBE_FAT_MULT);

            /*" -2803- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-VG OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_VG || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2804- MOVE 11 TO V0COBE-COD-COBER */
                _.Move(11, V0COBE_COD_COBER);

                /*" -2805- MOVE V1PRAM-RAMO-VG TO V0COBE-RAMOFR */
                _.Move(V1PRAM_RAMO_VG, V0COBE_RAMOFR);

                /*" -2807- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-MORNAT(13) / W1MOED-VLCRUZAD-IM */
                V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORNAT.Value / W1MOED_VLCRUZAD_IM;

                /*" -2809- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                /*" -2812- COMPUTE W0COBE-PRM-TARIF ROUNDED = PRM-VG (13) / (1 + (V1RIND-PCIOF / 100)) */
                AREA_DE_WORK.W0COBE_PRM_TARIF.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value / (1 + (V1RIND_PCIOF / 100f));

                /*" -2813- IF V1SUBG-IND-IOF = 'N' */

                if (V1SUBG_IND_IOF == "N")
                {

                    /*" -2814- MOVE PRM-VG (13) TO W0COBE-PRM-TARIF */
                    _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG, AREA_DE_WORK.W0COBE_PRM_TARIF);

                    /*" -2816- END-IF */
                }


                /*" -2819- COMPUTE V0COBE-PRM-TARIF-I ROUNDED = W0COBE-PRM-TARIF / W1MOED-VLCRUZAD-PR */
                V0COBE_PRM_TARIF_I.Value = AREA_DE_WORK.W0COBE_PRM_TARIF / W1MOED_VLCRUZAD_PR;

                /*" -2821- MOVE V0COBE-PRM-TARIF-I TO V0COBE-PRM-TARIF-V */
                _.Move(V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V);

                /*" -2822- MOVE W0COBE-PCT-COBERVG TO V0COBE-PCT-COBER */
                _.Move(AREA_DE_WORK.W0COBE_PCT_COBERVG, V0COBE_PCT_COBER);

                /*" -2823- PERFORM R2450-00-INSERE-COBERAPOL */

                R2450_00_INSERE_COBERAPOL_SECTION();

                /*" -2824- MOVE ZEROS TO V0COBE-NUM-ITEM */
                _.Move(0, V0COBE_NUM_ITEM);

                /*" -2825- MOVE ZEROS TO V0COBE-COD-COBER */
                _.Move(0, V0COBE_COD_COBER);

                /*" -2826- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

                if (V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
                {

                    /*" -2827- MOVE W0COBE-PCT-COBERVG TO V0COBE-PCT-COBER */
                    _.Move(AREA_DE_WORK.W0COBE_PCT_COBERVG, V0COBE_PCT_COBER);

                    /*" -2828- PERFORM R2450-00-INSERE-COBERAPOL */

                    R2450_00_INSERE_COBERAPOL_SECTION();

                    /*" -2829- ELSE */
                }
                else
                {


                    /*" -2830- MOVE 100 TO V0COBE-PCT-COBER */
                    _.Move(100, V0COBE_PCT_COBER);

                    /*" -2832- PERFORM R2450-00-INSERE-COBERAPOL. */

                    R2450_00_INSERE_COBERAPOL_SECTION();
                }

            }


            /*" -2833- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-PRESTAMISTA */

            if (V1ENDO_RAMO == V1PRAM_RAMO_PRESTAMISTA)
            {

                /*" -2834- MOVE 11 TO V0COBE-COD-COBER */
                _.Move(11, V0COBE_COD_COBER);

                /*" -2835- MOVE V1PRAM-RAMO-PRESTAMISTA TO V0COBE-RAMOFR */
                _.Move(V1PRAM_RAMO_PRESTAMISTA, V0COBE_RAMOFR);

                /*" -2837- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-MORNAT(13) / W1MOED-VLCRUZAD-IM */
                V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORNAT.Value / W1MOED_VLCRUZAD_IM;

                /*" -2839- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                /*" -2842- COMPUTE W0COBE-PRM-TARIF ROUNDED = PRM-VG (13) / (1 + (V1RIND-PCIOF / 100)) */
                AREA_DE_WORK.W0COBE_PRM_TARIF.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value / (1 + (V1RIND_PCIOF / 100f));

                /*" -2843- IF V1SUBG-IND-IOF = 'N' */

                if (V1SUBG_IND_IOF == "N")
                {

                    /*" -2844- MOVE PRM-VG (13) TO W0COBE-PRM-TARIF */
                    _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG, AREA_DE_WORK.W0COBE_PRM_TARIF);

                    /*" -2846- END-IF */
                }


                /*" -2849- COMPUTE V0COBE-PRM-TARIF-I ROUNDED = W0COBE-PRM-TARIF / W1MOED-VLCRUZAD-PR */
                V0COBE_PRM_TARIF_I.Value = AREA_DE_WORK.W0COBE_PRM_TARIF / W1MOED_VLCRUZAD_PR;

                /*" -2851- MOVE V0COBE-PRM-TARIF-I TO V0COBE-PRM-TARIF-V */
                _.Move(V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V);

                /*" -2852- MOVE W0COBE-PCT-COBERVG TO V0COBE-PCT-COBER */
                _.Move(AREA_DE_WORK.W0COBE_PCT_COBERVG, V0COBE_PCT_COBER);

                /*" -2853- PERFORM R2450-00-INSERE-COBERAPOL */

                R2450_00_INSERE_COBERAPOL_SECTION();

                /*" -2854- MOVE ZEROS TO V0COBE-NUM-ITEM */
                _.Move(0, V0COBE_NUM_ITEM);

                /*" -2855- MOVE ZEROS TO V0COBE-COD-COBER */
                _.Move(0, V0COBE_COD_COBER);

                /*" -2856- MOVE 100 TO V0COBE-PCT-COBER */
                _.Move(100, V0COBE_PCT_COBER);

                /*" -2858- PERFORM R2450-00-INSERE-COBERAPOL. */

                R2450_00_INSERE_COBERAPOL_SECTION();
            }


            /*" -2860- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-AP OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_AP || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2861- MOVE 1 TO V0COBE-COD-COBER */
                _.Move(1, V0COBE_COD_COBER);

                /*" -2862- MOVE V1PRAM-RAMO-AP TO V0COBE-RAMOFR */
                _.Move(V1PRAM_RAMO_AP, V0COBE_RAMOFR);

                /*" -2864- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-MORACI(13) / W1MOED-VLCRUZAD-IM */
                V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORACI.Value / W1MOED_VLCRUZAD_IM;

                /*" -2866- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                /*" -2869- COMPUTE W0COBE-PRM-TARIF ROUNDED = PRM-AP (13) / (1 + (V1RIND-PCIOF / 100)) */
                AREA_DE_WORK.W0COBE_PRM_TARIF.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value / (1 + (V1RIND_PCIOF / 100f));

                /*" -2870- IF V1SUBG-IND-IOF = 'N' */

                if (V1SUBG_IND_IOF == "N")
                {

                    /*" -2871- MOVE PRM-AP (13) TO W0COBE-PRM-TARIF */
                    _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP, AREA_DE_WORK.W0COBE_PRM_TARIF);

                    /*" -2873- END-IF */
                }


                /*" -2876- COMPUTE V0COBE-PRM-TARIF-I ROUNDED = W0COBE-PRM-TARIF / W1MOED-VLCRUZAD-PR */
                V0COBE_PRM_TARIF_I.Value = AREA_DE_WORK.W0COBE_PRM_TARIF / W1MOED_VLCRUZAD_PR;

                /*" -2878- MOVE V0COBE-PRM-TARIF-I TO V0COBE-PRM-TARIF-V */
                _.Move(V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V);

                /*" -2879- MOVE W0COBE-PCT-COBERAP TO V0COBE-PCT-COBER */
                _.Move(AREA_DE_WORK.W0COBE_PCT_COBERAP, V0COBE_PCT_COBER);

                /*" -2880- PERFORM R2450-00-INSERE-COBERAPOL */

                R2450_00_INSERE_COBERAPOL_SECTION();

                /*" -2881- ADD V0COBE-IMP-SEGUR-I TO V9COBE-IMP-SEGUR-I */
                V9COBE_IMP_SEGUR_I.Value = V9COBE_IMP_SEGUR_I + V0COBE_IMP_SEGUR_I;

                /*" -2882- ADD V0COBE-IMP-SEGUR-V TO V9COBE-IMP-SEGUR-V */
                V9COBE_IMP_SEGUR_V.Value = V9COBE_IMP_SEGUR_V + V0COBE_IMP_SEGUR_V;

                /*" -2883- ADD V0COBE-PRM-TARIF-I TO V9COBE-PRM-TARIF-I */
                V9COBE_PRM_TARIF_I.Value = V9COBE_PRM_TARIF_I + V0COBE_PRM_TARIF_I;

                /*" -2885- ADD V0COBE-PRM-TARIF-V TO V9COBE-PRM-TARIF-V. */
                V9COBE_PRM_TARIF_V.Value = V9COBE_PRM_TARIF_V + V0COBE_PRM_TARIF_V;
            }


            /*" -2887- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-AP OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_AP || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2888- IF IMP-INVPER(13) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_INVPER != 00)
                {

                    /*" -2889- MOVE 2 TO V0COBE-COD-COBER */
                    _.Move(2, V0COBE_COD_COBER);

                    /*" -2890- MOVE V1PRAM-RAMO-AP TO V0COBE-RAMOFR */
                    _.Move(V1PRAM_RAMO_AP, V0COBE_RAMOFR);

                    /*" -2892- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-INVPER(13) / W1MOED-VLCRUZAD-IM */
                    V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_INVPER.Value / W1MOED_VLCRUZAD_IM;

                    /*" -2894- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                    _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                    /*" -2897- MOVE ZEROS TO V0COBE-PRM-TARIF-I V0COBE-PRM-TARIF-V V0COBE-PCT-COBER */
                    _.Move(0, V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V, V0COBE_PCT_COBER);

                    /*" -2898- PERFORM R2450-00-INSERE-COBERAPOL */

                    R2450_00_INSERE_COBERAPOL_SECTION();

                    /*" -2899- ADD V0COBE-IMP-SEGUR-I TO V9COBE-IMP-SEGUR-I */
                    V9COBE_IMP_SEGUR_I.Value = V9COBE_IMP_SEGUR_I + V0COBE_IMP_SEGUR_I;

                    /*" -2900- ADD V0COBE-IMP-SEGUR-V TO V9COBE-IMP-SEGUR-V */
                    V9COBE_IMP_SEGUR_V.Value = V9COBE_IMP_SEGUR_V + V0COBE_IMP_SEGUR_V;

                    /*" -2901- ADD V0COBE-PRM-TARIF-I TO V9COBE-PRM-TARIF-I */
                    V9COBE_PRM_TARIF_I.Value = V9COBE_PRM_TARIF_I + V0COBE_PRM_TARIF_I;

                    /*" -2903- ADD V0COBE-PRM-TARIF-V TO V9COBE-PRM-TARIF-V. */
                    V9COBE_PRM_TARIF_V.Value = V9COBE_PRM_TARIF_V + V0COBE_PRM_TARIF_V;
                }

            }


            /*" -2905- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-AP OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_AP || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2906- IF IMP-AMDS(13) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_AMDS != 00)
                {

                    /*" -2907- MOVE 3 TO V0COBE-COD-COBER */
                    _.Move(3, V0COBE_COD_COBER);

                    /*" -2908- MOVE V1PRAM-RAMO-AP TO V0COBE-RAMOFR */
                    _.Move(V1PRAM_RAMO_AP, V0COBE_RAMOFR);

                    /*" -2910- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-AMDS(13) / W1MOED-VLCRUZAD-IM */
                    V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_AMDS.Value / W1MOED_VLCRUZAD_IM;

                    /*" -2912- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                    _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                    /*" -2915- MOVE ZEROS TO V0COBE-PRM-TARIF-I V0COBE-PRM-TARIF-V V0COBE-PCT-COBER */
                    _.Move(0, V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V, V0COBE_PCT_COBER);

                    /*" -2916- PERFORM R2450-00-INSERE-COBERAPOL */

                    R2450_00_INSERE_COBERAPOL_SECTION();

                    /*" -2917- ADD V0COBE-IMP-SEGUR-I TO V9COBE-IMP-SEGUR-I */
                    V9COBE_IMP_SEGUR_I.Value = V9COBE_IMP_SEGUR_I + V0COBE_IMP_SEGUR_I;

                    /*" -2918- ADD V0COBE-IMP-SEGUR-V TO V9COBE-IMP-SEGUR-V */
                    V9COBE_IMP_SEGUR_V.Value = V9COBE_IMP_SEGUR_V + V0COBE_IMP_SEGUR_V;

                    /*" -2919- ADD V0COBE-PRM-TARIF-I TO V9COBE-PRM-TARIF-I */
                    V9COBE_PRM_TARIF_I.Value = V9COBE_PRM_TARIF_I + V0COBE_PRM_TARIF_I;

                    /*" -2921- ADD V0COBE-PRM-TARIF-V TO V9COBE-PRM-TARIF-V. */
                    V9COBE_PRM_TARIF_V.Value = V9COBE_PRM_TARIF_V + V0COBE_PRM_TARIF_V;
                }

            }


            /*" -2923- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-AP OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_AP || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2924- IF IMP-DH(13) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DH != 00)
                {

                    /*" -2925- MOVE 4 TO V0COBE-COD-COBER */
                    _.Move(4, V0COBE_COD_COBER);

                    /*" -2926- MOVE V1PRAM-RAMO-AP TO V0COBE-RAMOFR */
                    _.Move(V1PRAM_RAMO_AP, V0COBE_RAMOFR);

                    /*" -2928- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-DH(13) / W1MOED-VLCRUZAD-IM */
                    V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DH.Value / W1MOED_VLCRUZAD_IM;

                    /*" -2930- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                    _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                    /*" -2933- MOVE ZEROS TO V0COBE-PRM-TARIF-I V0COBE-PRM-TARIF-V V0COBE-PCT-COBER */
                    _.Move(0, V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V, V0COBE_PCT_COBER);

                    /*" -2934- PERFORM R2450-00-INSERE-COBERAPOL */

                    R2450_00_INSERE_COBERAPOL_SECTION();

                    /*" -2935- ADD V0COBE-IMP-SEGUR-I TO V9COBE-IMP-SEGUR-I */
                    V9COBE_IMP_SEGUR_I.Value = V9COBE_IMP_SEGUR_I + V0COBE_IMP_SEGUR_I;

                    /*" -2936- ADD V0COBE-IMP-SEGUR-V TO V9COBE-IMP-SEGUR-V */
                    V9COBE_IMP_SEGUR_V.Value = V9COBE_IMP_SEGUR_V + V0COBE_IMP_SEGUR_V;

                    /*" -2937- ADD V0COBE-PRM-TARIF-I TO V9COBE-PRM-TARIF-I */
                    V9COBE_PRM_TARIF_I.Value = V9COBE_PRM_TARIF_I + V0COBE_PRM_TARIF_I;

                    /*" -2939- ADD V0COBE-PRM-TARIF-V TO V9COBE-PRM-TARIF-V. */
                    V9COBE_PRM_TARIF_V.Value = V9COBE_PRM_TARIF_V + V0COBE_PRM_TARIF_V;
                }

            }


            /*" -2941- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-AP OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_AP || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2942- IF IMP-DIT(13) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DIT != 00)
                {

                    /*" -2943- MOVE V1PRAM-RAMO-AP TO V0COBE-RAMOFR */
                    _.Move(V1PRAM_RAMO_AP, V0COBE_RAMOFR);

                    /*" -2944- MOVE 5 TO V0COBE-COD-COBER */
                    _.Move(5, V0COBE_COD_COBER);

                    /*" -2946- COMPUTE V0COBE-IMP-SEGUR-I ROUNDED = IMP-DIT(13) / W1MOED-VLCRUZAD-IM */
                    V0COBE_IMP_SEGUR_I.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DIT.Value / W1MOED_VLCRUZAD_IM;

                    /*" -2948- MOVE V0COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-V */
                    _.Move(V0COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_V);

                    /*" -2951- MOVE ZEROS TO V0COBE-PRM-TARIF-I V0COBE-PRM-TARIF-V V0COBE-PCT-COBER */
                    _.Move(0, V0COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_V, V0COBE_PCT_COBER);

                    /*" -2952- PERFORM R2450-00-INSERE-COBERAPOL */

                    R2450_00_INSERE_COBERAPOL_SECTION();

                    /*" -2953- ADD V0COBE-IMP-SEGUR-I TO V9COBE-IMP-SEGUR-I */
                    V9COBE_IMP_SEGUR_I.Value = V9COBE_IMP_SEGUR_I + V0COBE_IMP_SEGUR_I;

                    /*" -2954- ADD V0COBE-IMP-SEGUR-V TO V9COBE-IMP-SEGUR-V */
                    V9COBE_IMP_SEGUR_V.Value = V9COBE_IMP_SEGUR_V + V0COBE_IMP_SEGUR_V;

                    /*" -2955- ADD V0COBE-PRM-TARIF-I TO V9COBE-PRM-TARIF-I */
                    V9COBE_PRM_TARIF_I.Value = V9COBE_PRM_TARIF_I + V0COBE_PRM_TARIF_I;

                    /*" -2959- ADD V0COBE-PRM-TARIF-V TO V9COBE-PRM-TARIF-V. */
                    V9COBE_PRM_TARIF_V.Value = V9COBE_PRM_TARIF_V + V0COBE_PRM_TARIF_V;
                }

            }


            /*" -2961- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-AP OR V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

            if (V1ENDO_RAMO == V1PRAM_RAMO_AP || V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
            {

                /*" -2966- IF V9COBE-IMP-SEGUR-I EQUAL ZEROS AND V9COBE-IMP-SEGUR-V EQUAL ZEROS AND V9COBE-PRM-TARIF-I EQUAL ZEROS AND V9COBE-PRM-TARIF-V EQUAL ZEROS NEXT SENTENCE */

                if (V9COBE_IMP_SEGUR_I == 00 && V9COBE_IMP_SEGUR_V == 00 && V9COBE_PRM_TARIF_I == 00 && V9COBE_PRM_TARIF_V == 00)
                {

                    /*" -2967- ELSE */
                }
                else
                {


                    /*" -2968- MOVE V1PRAM-RAMO-AP TO V0COBE-RAMOFR */
                    _.Move(V1PRAM_RAMO_AP, V0COBE_RAMOFR);

                    /*" -2969- MOVE ZEROS TO V0COBE-COD-COBER */
                    _.Move(0, V0COBE_COD_COBER);

                    /*" -2970- MOVE ZEROS TO V0COBE-NUM-ITEM */
                    _.Move(0, V0COBE_NUM_ITEM);

                    /*" -2971- IF V1ENDO-RAMO EQUAL V1PRAM-RAMO-VGAP */

                    if (V1ENDO_RAMO == V1PRAM_RAMO_VGAP)
                    {

                        /*" -2972- MOVE W0COBE-PCT-COBERAP TO V0COBE-PCT-COBER */
                        _.Move(AREA_DE_WORK.W0COBE_PCT_COBERAP, V0COBE_PCT_COBER);

                        /*" -2973- MOVE V9COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-I */
                        _.Move(V9COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_I);

                        /*" -2974- MOVE V9COBE-IMP-SEGUR-V TO V0COBE-IMP-SEGUR-V */
                        _.Move(V9COBE_IMP_SEGUR_V, V0COBE_IMP_SEGUR_V);

                        /*" -2975- MOVE V9COBE-PRM-TARIF-I TO V0COBE-PRM-TARIF-I */
                        _.Move(V9COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_I);

                        /*" -2976- MOVE V9COBE-PRM-TARIF-V TO V0COBE-PRM-TARIF-V */
                        _.Move(V9COBE_PRM_TARIF_V, V0COBE_PRM_TARIF_V);

                        /*" -2977- PERFORM R2450-00-INSERE-COBERAPOL */

                        R2450_00_INSERE_COBERAPOL_SECTION();

                        /*" -2981- MOVE ZEROS TO V9COBE-IMP-SEGUR-I V9COBE-IMP-SEGUR-V V9COBE-PRM-TARIF-I V9COBE-PRM-TARIF-V */
                        _.Move(0, V9COBE_IMP_SEGUR_I, V9COBE_IMP_SEGUR_V, V9COBE_PRM_TARIF_I, V9COBE_PRM_TARIF_V);

                        /*" -2982- ELSE */
                    }
                    else
                    {


                        /*" -2983- MOVE 100 TO V0COBE-PCT-COBER */
                        _.Move(100, V0COBE_PCT_COBER);

                        /*" -2984- MOVE V9COBE-IMP-SEGUR-I TO V0COBE-IMP-SEGUR-I */
                        _.Move(V9COBE_IMP_SEGUR_I, V0COBE_IMP_SEGUR_I);

                        /*" -2985- MOVE V9COBE-IMP-SEGUR-V TO V0COBE-IMP-SEGUR-V */
                        _.Move(V9COBE_IMP_SEGUR_V, V0COBE_IMP_SEGUR_V);

                        /*" -2986- MOVE V9COBE-PRM-TARIF-I TO V0COBE-PRM-TARIF-I */
                        _.Move(V9COBE_PRM_TARIF_I, V0COBE_PRM_TARIF_I);

                        /*" -2987- MOVE V9COBE-PRM-TARIF-V TO V0COBE-PRM-TARIF-V */
                        _.Move(V9COBE_PRM_TARIF_V, V0COBE_PRM_TARIF_V);

                        /*" -2988- PERFORM R2450-00-INSERE-COBERAPOL */

                        R2450_00_INSERE_COBERAPOL_SECTION();

                        /*" -2991- MOVE ZEROS TO V9COBE-IMP-SEGUR-I V9COBE-IMP-SEGUR-V V9COBE-PRM-TARIF-I V9COBE-PRM-TARIF-V. */
                        _.Move(0, V9COBE_IMP_SEGUR_I, V9COBE_IMP_SEGUR_V, V9COBE_PRM_TARIF_I, V9COBE_PRM_TARIF_V);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-INSERE-COBERAPOL-SECTION */
        private void R2450_00_INSERE_COBERAPOL_SECTION()
        {
            /*" -3004- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -3006- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -3026- PERFORM R2450_00_INSERE_COBERAPOL_DB_INSERT_1 */

            R2450_00_INSERE_COBERAPOL_DB_INSERT_1();

            /*" -3028- ADD +1 TO AC-I-V0FATURAS. */
            AC_I_V0FATURAS.Value = AC_I_V0FATURAS + +1;

        }

        [StopWatch]
        /*" R2450-00-INSERE-COBERAPOL-DB-INSERT-1 */
        public void R2450_00_INSERE_COBERAPOL_DB_INSERT_1()
        {
            /*" -3026- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBE-NUM-APOL , :V0COBE-NUM-ENDOS , :V0COBE-NUM-ITEM , :V0COBE-OCORR-HIST , :V0COBE-RAMOFR , :V0COBE-MODALIFR , :V0COBE-COD-COBER , :V0COBE-IMP-SEGUR-I , :V0COBE-PRM-TARIF-I , :V0COBE-IMP-SEGUR-V , :V0COBE-PRM-TARIF-V , :V0COBE-PCT-COBER , :V0COBE-FAT-MULT , :V0COBE-DATA-INIVIG , :V0COBE-DATA-TERVIG , :V0COBE-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP, :V0COBE-COD-SITUACAO:V0COBE-COD-SIT-I) END-EXEC. */

            var r2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1 = new R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1()
            {
                V0COBE_NUM_APOL = V0COBE_NUM_APOL.ToString(),
                V0COBE_NUM_ENDOS = V0COBE_NUM_ENDOS.ToString(),
                V0COBE_NUM_ITEM = V0COBE_NUM_ITEM.ToString(),
                V0COBE_OCORR_HIST = V0COBE_OCORR_HIST.ToString(),
                V0COBE_RAMOFR = V0COBE_RAMOFR.ToString(),
                V0COBE_MODALIFR = V0COBE_MODALIFR.ToString(),
                V0COBE_COD_COBER = V0COBE_COD_COBER.ToString(),
                V0COBE_IMP_SEGUR_I = V0COBE_IMP_SEGUR_I.ToString(),
                V0COBE_PRM_TARIF_I = V0COBE_PRM_TARIF_I.ToString(),
                V0COBE_IMP_SEGUR_V = V0COBE_IMP_SEGUR_V.ToString(),
                V0COBE_PRM_TARIF_V = V0COBE_PRM_TARIF_V.ToString(),
                V0COBE_PCT_COBER = V0COBE_PCT_COBER.ToString(),
                V0COBE_FAT_MULT = V0COBE_FAT_MULT.ToString(),
                V0COBE_DATA_INIVIG = V0COBE_DATA_INIVIG.ToString(),
                V0COBE_DATA_TERVIG = V0COBE_DATA_TERVIG.ToString(),
                V0COBE_COD_EMPRESA = V0COBE_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0COBE_COD_SITUACAO = V0COBE_COD_SITUACAO.ToString(),
                V0COBE_COD_SIT_I = V0COBE_COD_SIT_I.ToString(),
            };

            R2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1.Execute(r2450_00_INSERE_COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-FATURA-SUBG-RESUMO-SECTION */
        private void R3000_00_FATURA_SUBG_RESUMO_SECTION()
        {
            /*" -3040- MOVE SPACES TO WFIM-V1SUBGRUPO */
            _.Move("", WFIM_V1SUBGRUPO);

            /*" -3042- PERFORM R1500-00-DECLARE-V1SUBGR. */

            R1500_00_DECLARE_V1SUBGR_SECTION();

            /*" -3042- MOVE ATACUM-MASCARA TO ATACUM-CAMPOS. */
            _.Move(ATACUM_IMPRESSAO.ATACUM_MASCARA, ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS);

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LEITURA_V1SUBG */

            R3000_10_LEITURA_V1SUBG();

        }

        [StopWatch]
        /*" R3000-10-LEITURA-V1SUBG */
        private void R3000_10_LEITURA_V1SUBG(bool isPerform = false)
        {
            /*" -3047- PERFORM R1510-00-FETCH-V1SUBGR. */

            R1510_00_FETCH_V1SUBGR_SECTION();

            /*" -3048- IF WFIM-V1SUBGRUPO NOT EQUAL SPACES */

            if (!WFIM_V1SUBGRUPO.IsEmpty())
            {

                /*" -3050- GO TO R3000-50-INCLUI-FATURA-APOL. */

                R3000_50_INCLUI_FATURA_APOL(); //GOTO
                return;
            }


            /*" -3057- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
            _.Move(TACUM_IMPRESSAO.TACUM_MASCARA, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

            /*" -3058- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

            /*" -3059- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
            _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

            /*" -3065- MOVE V1SUBG-COD-SUBG TO W1SOLF-COD-SUBG */
            _.Move(V1SUBG_COD_SUBG, W1SOLF_COD_SUBG);

            /*" -3066- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", WFIM_V1FATURAS);

            /*" -3074- PERFORM R1200-00-SELECT-V1FATURA */

            R1200_00_SELECT_V1FATURA_SECTION();

            /*" -3075- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -3076- IF V1SOLF-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 100)
                {

                    /*" -3079- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -3085- GO TO R3000-10-CONTINUA. */

                        R3000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -3086- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -3088- IF V1SOLF-COD-OPER EQUAL 200 AND V1FATR-COD-OPER EQUAL 100 */

                if (V1SOLF_COD_OPER == 200 && V1FATR_COD_OPER == 100)
                {

                    /*" -3095- GO TO R3000-10-CONTINUA. */

                    R3000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -3096- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -3097- IF V1SOLF-COD-OPER EQUAL 300 */

                if (V1SOLF_COD_OPER == 300)
                {

                    /*" -3100- IF V1FATR-COD-OPER EQUAL 100 OR ((V1FATR-COD-OPER EQUAL 200 OR 300) AND (V1FATR-SIT-REG EQUAL '2' )) */

                    if (V1FATR_COD_OPER == 100 || ((V1FATR_COD_OPER.In("200", "300")) && (V1FATR_SIT_REG == "2")))
                    {

                        /*" -3106- GO TO R3000-10-CONTINUA. */

                        R3000_10_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -3107- IF WFIM-V1FATURAS NOT EQUAL SPACES */

            if (!WFIM_V1FATURAS.IsEmpty())
            {

                /*" -3108- IF V1SOLF-COD-OPER EQUAL 100 OR 200 */

                if (V1SOLF_COD_OPER.In("100", "200"))
                {

                    /*" -3113- GO TO R3000-10-CONTINUA. */

                    R3000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -3114- IF WFIM-V1FATURAS EQUAL SPACES */

            if (WFIM_V1FATURAS.IsEmpty())
            {

                /*" -3116- IF V1SOLF-COD-OPER EQUAL 200 AND WTEM-TERMO-ADESAO EQUAL 'S' */

                if (V1SOLF_COD_OPER == 200 && WTEM_TERMO_ADESAO == "S")
                {

                    /*" -3120- GO TO R3000-10-CONTINUA. */

                    R3000_10_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -3121- DISPLAY 'R3000 - SOLICITACAO INVALIDA ... ' */
            _.Display($"R3000 - SOLICITACAO INVALIDA ... ");

            /*" -3122- DISPLAY 'APOLICE  ' V1SOLF-NUM-APOL */
            _.Display($"APOLICE  {V1SOLF_NUM_APOL}");

            /*" -3123- DISPLAY 'SUBGRUPO ' W1SOLF-COD-SUBG */
            _.Display($"SUBGRUPO {W1SOLF_COD_SUBG}");

            /*" -3124- DISPLAY 'FATURA   ' V1SOLF-NUM-FAT */
            _.Display($"FATURA   {V1SOLF_NUM_FAT}");

            /*" -3126- DISPLAY 'OPERACAO ' V1SOLF-COD-OPER */
            _.Display($"OPERACAO {V1SOLF_COD_OPER}");

            /*" -3126- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3000-10-CONTINUA */
        private void R3000_10_CONTINUA(bool isPerform = false)
        {
            /*" -3142- IF (V1SOLF-COD-OPER EQUAL 100) OR (V1SOLF-COD-OPER EQUAL 200 AND WFIM-V1FATURAS NOT EQUAL SPACES) OR (V1SOLF-COD-OPER EQUAL 300 AND V1FATR-COD-OPER NOT EQUAL 100) */

            if ((V1SOLF_COD_OPER == 100) || (V1SOLF_COD_OPER == 200 && !WFIM_V1FATURAS.IsEmpty()) || (V1SOLF_COD_OPER == 300 && V1FATR_COD_OPER != 100))
            {

                /*" -3143- MOVE SPACES TO WFIM-V1FATURANT */
                _.Move("", WFIM_V1FATURANT);

                /*" -3144- PERFORM R1300-00-SELECT-V1FATTOT-ANT */

                R1300_00_SELECT_V1FATTOT_ANT_SECTION();

                /*" -3145- IF WFIM-V1FATURANT NOT EQUAL SPACES */

                if (!WFIM_V1FATURANT.IsEmpty())
                {

                    /*" -3146- PERFORM S0100-00-ZERA-SALDO-ANT */

                    S0100_00_ZERA_SALDO_ANT_SECTION();

                    /*" -3147- ELSE */
                }
                else
                {


                    /*" -3148- PERFORM S0200-00-MONTA-SALDO-ANT */

                    S0200_00_MONTA_SALDO_ANT_SECTION();

                    /*" -3149- ELSE */
                }

            }
            else
            {


                /*" -3151- PERFORM S0100-00-ZERA-SALDO-ANT. */

                S0100_00_ZERA_SALDO_ANT_SECTION();
            }


            /*" -3154- IF (V1SOLF-COD-OPER EQUAL 200 OR 300) AND WFIM-V1FATURAS EQUAL SPACES AND V1FATR-COD-OPER EQUAL 100 */

            if ((V1SOLF_COD_OPER.In("200", "300")) && WFIM_V1FATURAS.IsEmpty() && V1FATR_COD_OPER == 100)
            {

                /*" -3155- PERFORM R1700-00-ACESSA-TOTAIS */

                R1700_00_ACESSA_TOTAIS_SECTION();

                /*" -3156- ELSE */
            }
            else
            {


                /*" -3159- IF (V1SOLF-COD-OPER EQUAL 100 OR 200 OR 300) AND WTEM-TERMO-ADESAO EQUAL 'S' AND MODALIDADE-CAPITAL EQUAL '0' */

                if ((V1SOLF_COD_OPER.In("100", "200", "300")) && WTEM_TERMO_ADESAO == "S" && MODALIDADE_CAPITAL == "0")
                {

                    /*" -3160- PERFORM R1700-00-ACESSA-TOTAIS */

                    R1700_00_ACESSA_TOTAIS_SECTION();

                    /*" -3162- IF PRM-VG(13) EQUAL ZEROS AND PRM-AP(13) EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG == 00 && TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP == 00)
                    {

                        /*" -3163- PERFORM S0300-00-TOTALIZA-FATURA */

                        S0300_00_TOTALIZA_FATURA_SECTION();

                        /*" -3165- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -3166- ELSE */
                    }

                }
                else
                {


                    /*" -3167- PERFORM R6000-00-TOTALIZA-MOVIMENTO */

                    R6000_00_TOTALIZA_MOVIMENTO_SECTION();

                    /*" -3169- PERFORM S0300-00-TOTALIZA-FATURA. */

                    S0300_00_TOTALIZA_FATURA_SECTION();
                }

            }


            /*" -3171- PERFORM S0400-00-TOTALIZA-APOLICE */

            S0400_00_TOTALIZA_APOLICE_SECTION();

            /*" -3172- IF W1S-TIPO-FAT EQUAL '3' */

            if (W1S_TIPO_FAT == "3")
            {

                /*" -3173- PERFORM R3020-00-GERA-FATURA */

                R3020_00_GERA_FATURA_SECTION();

                /*" -3174- ELSE */
            }
            else
            {


                /*" -3176- PERFORM R3040-00-GERA-FATURA-ENDOSSO. */

                R3040_00_GERA_FATURA_ENDOSSO_SECTION();
            }


            /*" -3178- PERFORM R6500-00-UPDATE-MOVIMENTO */

            R6500_00_UPDATE_MOVIMENTO_SECTION();

            /*" -3179- IF V1SOLF-COD-OPER EQUAL 200 OR 300 */

            if (V1SOLF_COD_OPER.In("200", "300"))
            {

                /*" -3181- PERFORM R3060-00-ANEXO-V0RELATORIOS. */

                R3060_00_ANEXO_V0RELATORIOS_SECTION();
            }


            /*" -3181- GO TO R3000-10-LEITURA-V1SUBG. */

            R3000_10_LEITURA_V1SUBG(); //GOTO
            return;

        }

        [StopWatch]
        /*" R3000-50-INCLUI-FATURA-APOL */
        private void R3000_50_INCLUI_FATURA_APOL(bool isPerform = false)
        {
            /*" -3186- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
            _.Move(TACUM_IMPRESSAO.TACUM_MASCARA, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

            /*" -3188- MOVE ATACUM-IMPRESSAO TO TACUM-IMPRESSAO */
            _.Move(ATACUM_IMPRESSAO, TACUM_IMPRESSAO);

            /*" -3191- COMPUTE PRM-TOTAL = PRM-AP(13) + PRM-VG(13). */
            AREA_DE_WORK.PRM_TOTAL.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value;

            /*" -3192- MOVE V1SOLF-NUM-APOL TO W1SOLF-NUM-APOL */
            _.Move(V1SOLF_NUM_APOL, W1SOLF_NUM_APOL);

            /*" -3193- MOVE W1S-COD-SUBG TO W1SOLF-COD-SUBG */
            _.Move(W1S_COD_SUBG, W1SOLF_COD_SUBG);

            /*" -3196- MOVE V1SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
            _.Move(V1SOLF_NUM_FAT, W1SOLF_NUM_FAT);

            /*" -3197- IF V1SOLF-COD-OPER EQUAL 200 OR 300 */

            if (V1SOLF_COD_OPER.In("200", "300"))
            {

                /*" -3199- PERFORM R5200-00-UPDATE-V0FATURCONT. */

                R5200_00_UPDATE_V0FATURCONT_SECTION();
            }


            /*" -3200- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", WFIM_V1FATURAS);

            /*" -3202- PERFORM R1200-00-SELECT-V1FATURA */

            R1200_00_SELECT_V1FATURA_SECTION();

            /*" -3203- IF W1S-TIPO-FAT EQUAL '2' */

            if (W1S_TIPO_FAT == "2")
            {

                /*" -3204- MOVE W1S-COD-FONTE TO V1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, V1SUBG_COD_FONTE);

                /*" -3205- PERFORM R3020-00-GERA-FATURA */

                R3020_00_GERA_FATURA_SECTION();

                /*" -3206- ELSE */
            }
            else
            {


                /*" -3207- MOVE W1S-COD-SUBG TO V1SUBG-COD-SUBG */
                _.Move(W1S_COD_SUBG, V1SUBG_COD_SUBG);

                /*" -3208- MOVE W1S-COD-FONTE TO V1SUBG-COD-FONTE */
                _.Move(W1S_COD_FONTE, V1SUBG_COD_FONTE);

                /*" -3209- MOVE W1S-BCO-COB TO V1SUBG-BCO-COB */
                _.Move(W1S_BCO_COB, V1SUBG_BCO_COB);

                /*" -3210- MOVE W1S-AGE-COB TO V1SUBG-AGE-COB */
                _.Move(W1S_AGE_COB, V1SUBG_AGE_COB);

                /*" -3211- MOVE W1S-DAC-COB TO V1SUBG-DAC-COB */
                _.Move(W1S_DAC_COB, V1SUBG_DAC_COB);

                /*" -3212- MOVE W1S-END-COB TO V1SUBG-END-COB */
                _.Move(W1S_END_COB, V1SUBG_END_COB);

                /*" -3216- PERFORM R3040-00-GERA-FATURA-ENDOSSO. */

                R3040_00_GERA_FATURA_ENDOSSO_SECTION();
            }


            /*" -3218- MOVE SPACES TO WFIM-FATURA-ANT */
            _.Move("", WFIM_FATURA_ANT);

            /*" -3219- MOVE V1SOLF-NUM-FAT TO WNUM-FATURA */
            _.Move(V1SOLF_NUM_FAT, WNUM_FATURA);

            /*" -3220- IF WFAT-MES EQUAL 01 */

            if (FILLER_14.WFAT_MES == 01)
            {

                /*" -3221- MOVE 12 TO WFAT-MES */
                _.Move(12, FILLER_14.WFAT_MES);

                /*" -3222- SUBTRACT 1 FROM WFAT-ANO */
                FILLER_14.WFAT_ANO.Value = FILLER_14.WFAT_ANO - 1;

                /*" -3223- ELSE */
            }
            else
            {


                /*" -3225- SUBTRACT 1 FROM WFAT-MES. */
                FILLER_14.WFAT_MES.Value = FILLER_14.WFAT_MES - 1;
            }


            /*" -3227- MOVE WNUM-FATURA TO W2SOLF-NUM-FAT */
            _.Move(WNUM_FATURA, W2SOLF_NUM_FAT);

            /*" -3229- PERFORM R1280-00-SELECT-V1FATURA-ANT */

            R1280_00_SELECT_V1FATURA_ANT_SECTION();

            /*" -3230- IF WFIM-FATURA-ANT NOT EQUAL SPACES */

            if (!WFIM_FATURA_ANT.IsEmpty())
            {

                /*" -3231- MOVE TACUM-MASCARA TO TACUM-CAMPOS */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS);

                /*" -3233- MOVE ATACUM-OPERACAO(1) TO TACUM-OPERACAO(1) */
                _.Move(ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[1], TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1]);

                /*" -3235- MOVE W2SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
                _.Move(W2SOLF_NUM_FAT, W1SOLF_NUM_FAT);

                /*" -3237- PERFORM S0300-00-TOTALIZA-FATURA */

                S0300_00_TOTALIZA_FATURA_SECTION();

                /*" -3238- MOVE '0' TO W1ENDO-TIPEND */
                _.Move("0", W1ENDO_TIPEND);

                /*" -3242- MOVE ZEROS TO W1ENDO-NRENDOS W1SUBG-COD-FONTE W1SOLF-NUM-RCAP W1SOLF-VAL-RCAP */
                _.Move(0, W1ENDO_NRENDOS, W1SUBG_COD_FONTE, W1SOLF_NUM_RCAP, W1SOLF_VAL_RCAP);

                /*" -3243- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -3244- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -3245- MOVE -1 TO W1SOLF-DATA-RCAP-I */
                _.Move(-1, W1SOLF_DATA_RCAP_I);

                /*" -3246- MOVE -1 TO W1SOLF-DATA-VENC-I */
                _.Move(-1, W1SOLF_DATA_VENC_I);

                /*" -3247- MOVE W2SOLF-NUM-FAT TO W1SOLF-NUM-FAT */
                _.Move(W2SOLF_NUM_FAT, W1SOLF_NUM_FAT);

                /*" -3249- MOVE ZEROS TO V1SOLF-COD-OPER */
                _.Move(0, V1SOLF_COD_OPER);

                /*" -3250- PERFORM R2100-00-MONTA-V0FATURAS */

                R2100_00_MONTA_V0FATURAS_SECTION();

                /*" -3251- PERFORM R3100-00-INSERT-V0FATURAS */

                R3100_00_INSERT_V0FATURAS_SECTION();

                /*" -3251- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                R2200_00_MONTA_V0FATURASTOT_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-GERA-FATURA-SECTION */
        private void R3020_00_GERA_FATURA_SECTION()
        {
            /*" -3264- MOVE '0' TO W1ENDO-TIPEND */
            _.Move("0", W1ENDO_TIPEND);

            /*" -3265- MOVE V1SUBG-COD-FONTE TO W1SUBG-COD-FONTE */
            _.Move(V1SUBG_COD_FONTE, W1SUBG_COD_FONTE);

            /*" -3268- MOVE ZEROS TO W1ENDO-NRENDOS W1SOLF-NUM-RCAP W1SOLF-VAL-RCAP */
            _.Move(0, W1ENDO_NRENDOS, W1SOLF_NUM_RCAP, W1SOLF_VAL_RCAP);

            /*" -3269- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
            _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

            /*" -3270- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
            _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

            /*" -3271- MOVE -1 TO W1SOLF-DATA-RCAP-I */
            _.Move(-1, W1SOLF_DATA_RCAP_I);

            /*" -3273- MOVE -1 TO W1SOLF-DATA-VENC-I */
            _.Move(-1, W1SOLF_DATA_VENC_I);

            /*" -3274- IF V1SOLF-COD-OPER EQUAL 100 */

            if (V1SOLF_COD_OPER == 100)
            {

                /*" -3275- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -3276- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3277- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3278- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -3279- ELSE */
                }
                else
                {


                    /*" -3280- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -3281- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3282- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3283- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -3286- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


            /*" -3287- IF V1SOLF-COD-OPER EQUAL 200 OR 300 */

            if (V1SOLF_COD_OPER.In("200", "300"))
            {

                /*" -3288- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -3289- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3290- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3291- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -3292- ELSE */
                }
                else
                {


                    /*" -3293- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -3294- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3294- PERFORM R3100-00-INSERT-V0FATURAS. */

                    R3100_00_INSERT_V0FATURAS_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-GERA-FATURA-ENDOSSO-SECTION */
        private void R3040_00_GERA_FATURA_ENDOSSO_SECTION()
        {
            /*" -3305- IF V1SOLF-COD-OPER EQUAL 100 */

            if (V1SOLF_COD_OPER == 100)
            {

                /*" -3306- MOVE V1SUBG-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(V1SUBG_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -3308- MOVE ZEROS TO W1SOLF-NUM-RCAP W1SOLF-VAL-RCAP */
                _.Move(0, W1SOLF_NUM_RCAP, W1SOLF_VAL_RCAP);

                /*" -3309- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -3310- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -3311- MOVE -1 TO W1SOLF-DATA-RCAP-I */
                _.Move(-1, W1SOLF_DATA_RCAP_I);

                /*" -3312- MOVE -1 TO W1SOLF-DATA-VENC-I */
                _.Move(-1, W1SOLF_DATA_VENC_I);

                /*" -3313- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -3314- MOVE '0' TO W1ENDO-TIPEND */
                    _.Move("0", W1ENDO_TIPEND);

                    /*" -3315- MOVE ZEROS TO W1ENDO-NRENDOS */
                    _.Move(0, W1ENDO_NRENDOS);

                    /*" -3316- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3317- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3318- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -3319- ELSE */
                }
                else
                {


                    /*" -3320- MOVE V1FATR-TIPO-ENDOS TO W1ENDO-TIPEND */
                    _.Move(V1FATR_TIPO_ENDOS, W1ENDO_TIPEND);

                    /*" -3321- MOVE V1FATR-NUM-ENDOS TO W1ENDO-NRENDOS */
                    _.Move(V1FATR_NUM_ENDOS, W1ENDO_NRENDOS);

                    /*" -3322- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -3323- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3324- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3325- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -3327- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


            /*" -3328- IF V1SOLF-COD-OPER EQUAL 200 OR 300 */

            if (V1SOLF_COD_OPER.In("200", "300"))
            {

                /*" -3329- MOVE V1SUBG-COD-SUBG TO W1SUBG-COD-SUBG */
                _.Move(V1SUBG_COD_SUBG, W1SUBG_COD_SUBG);

                /*" -3330- MOVE V1SUBG-COD-FONTE TO W1SUBG-COD-FONTE */
                _.Move(V1SUBG_COD_FONTE, W1SUBG_COD_FONTE);

                /*" -3331- MOVE V1SUBG-BCO-COB TO W1SUBG-BCO-COB */
                _.Move(V1SUBG_BCO_COB, W1SUBG_BCO_COB);

                /*" -3332- MOVE V1SUBG-AGE-COB TO W1SUBG-AGE-COB */
                _.Move(V1SUBG_AGE_COB, W1SUBG_AGE_COB);

                /*" -3333- MOVE V1SUBG-DAC-COB TO W1SUBG-DAC-COB */
                _.Move(V1SUBG_DAC_COB, W1SUBG_DAC_COB);

                /*" -3334- MOVE V1SUBG-END-COB TO W1SUBG-END-COB */
                _.Move(V1SUBG_END_COB, W1SUBG_END_COB);

                /*" -3335- MOVE V1SOLF-NUM-RCAP TO W1SOLF-NUM-RCAP */
                _.Move(V1SOLF_NUM_RCAP, W1SOLF_NUM_RCAP);

                /*" -3336- MOVE V1SOLF-VAL-RCAP TO W1SOLF-VAL-RCAP */
                _.Move(V1SOLF_VAL_RCAP, W1SOLF_VAL_RCAP);

                /*" -3337- PERFORM R1400-00-SELECT-V0NUMEROAES */

                R1400_00_SELECT_V0NUMEROAES_SECTION();

                /*" -3338- PERFORM R1410-00-UPDATE-V0NUMEROAES */

                R1410_00_UPDATE_V0NUMEROAES_SECTION();

                /*" -3342- PERFORM R1950-00-SELECT-V1FONTE */

                R1950_00_SELECT_V1FONTE_SECTION();

                /*" -3343- PERFORM R2300-00-MONTA-V0ENDOSSO */

                R2300_00_MONTA_V0ENDOSSO_SECTION();

                /*" -3344- PERFORM R3300-00-INSERT-V0ENDOSSO */

                R3300_00_INSERT_V0ENDOSSO_SECTION();

                /*" -3346- PERFORM R2400-00-MONTA-COBERAPOL */

                R2400_00_MONTA_COBERAPOL_SECTION();

                /*" -3347- MOVE V1SOLF-NUM-RCAP TO W1SOLF-NUM-RCAP */
                _.Move(V1SOLF_NUM_RCAP, W1SOLF_NUM_RCAP);

                /*" -3348- MOVE V1SOLF-VAL-RCAP TO W1SOLF-VAL-RCAP */
                _.Move(V1SOLF_VAL_RCAP, W1SOLF_VAL_RCAP);

                /*" -3349- MOVE V1SOLF-DATA-RCAP TO W1SOLF-DATA-RCAP */
                _.Move(V1SOLF_DATA_RCAP, W1SOLF_DATA_RCAP);

                /*" -3350- MOVE V1SOLF-DATA-RCAP-I TO W1SOLF-DATA-RCAP-I */
                _.Move(V1SOLF_DATA_RCAP_I, W1SOLF_DATA_RCAP_I);

                /*" -3351- MOVE V1SOLF-DATA-VENC TO W1SOLF-DATA-VENC */
                _.Move(V1SOLF_DATA_VENC, W1SOLF_DATA_VENC);

                /*" -3353- MOVE V1SOLF-DATA-VENC-I TO W1SOLF-DATA-VENC-I */
                _.Move(V1SOLF_DATA_VENC_I, W1SOLF_DATA_VENC_I);

                /*" -3354- IF WFIM-V1FATURAS NOT EQUAL SPACES */

                if (!WFIM_V1FATURAS.IsEmpty())
                {

                    /*" -3355- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3356- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3357- PERFORM R2200-00-MONTA-V0FATURASTOT */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();

                    /*" -3358- ELSE */
                }
                else
                {


                    /*" -3359- PERFORM R5100-00-DELETE-V0FATURAS */

                    R5100_00_DELETE_V0FATURAS_SECTION();

                    /*" -3360- PERFORM R2100-00-MONTA-V0FATURAS */

                    R2100_00_MONTA_V0FATURAS_SECTION();

                    /*" -3361- PERFORM R3100-00-INSERT-V0FATURAS */

                    R3100_00_INSERT_V0FATURAS_SECTION();

                    /*" -3362- PERFORM R4100-00-DELETE-V0FATURASTOT */

                    R4100_00_DELETE_V0FATURASTOT_SECTION();

                    /*" -3362- PERFORM R2200-00-MONTA-V0FATURASTOT. */

                    R2200_00_MONTA_V0FATURASTOT_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3060-00-ANEXO-V0RELATORIOS-SECTION */
        private void R3060_00_ANEXO_V0RELATORIOS_SECTION()
        {
            /*" -3375- SET I03 TO +1. */
            I03.Value = +1;

            /*" -3376- MOVE V1SOLF-DATA-SOLI TO V0RELT-DATA-SOLI */
            _.Move(V1SOLF_DATA_SOLI, V0RELT_DATA_SOLI);

            /*" -3377- MOVE V1SOLF-COD-USUAR TO V0RELT-COD-USUAR */
            _.Move(V1SOLF_COD_USUAR, V0RELT_COD_USUAR);

            /*" -3378- MOVE V1FATC-DATA-REFER TO V0RELT-DATA-REFER */
            _.Move(V1FATC_DATA_REFER, V0RELT_DATA_REFER);

            /*" -3379- MOVE W1SUBG-COD-FONTE TO V0RELT-FONTE */
            _.Move(W1SUBG_COD_FONTE, V0RELT_FONTE);

            /*" -3380- MOVE W1ENDO-NRENDOS TO V0RELT-NRENDOS */
            _.Move(W1ENDO_NRENDOS, V0RELT_NRENDOS);

            /*" -3381- MOVE V1SUBG-COD-SUBG TO V0RELT-CODSUBES */
            _.Move(V1SUBG_COD_SUBG, V0RELT_CODSUBES);

            /*" -3384- MOVE ZEROS TO V0RELT-COD-EMPRESA V0RELT-PERI-RENOVA V0RELT-PCT-AUMENTO */
            _.Move(0, V0RELT_COD_EMPRESA, V0RELT_PERI_RENOVA, V0RELT_PCT_AUMENTO);

            /*" -3386- MOVE -1 TO VIND-COD-EMP VIND-PERI-RENOVA VIND-PCT-AUMENTO. */
            _.Move(-1, VIND_COD_EMP, VIND_PERI_RENOVA, VIND_PCT_AUMENTO);

            /*" -0- FLUXCONTROL_PERFORM R3060_10_LOOP */

            R3060_10_LOOP();

        }

        [StopWatch]
        /*" R3060-10-LOOP */
        private void R3060_10_LOOP(bool isPerform = false)
        {
            /*" -3392- MOVE CODREL(I03) TO V0RELT-CODREL */
            _.Move(TREL_IMPRESSAO.TRELATORIOS[I03].CODREL, V0RELT_CODREL);

            /*" -3394- PERFORM R3080-00-INSERT-V0RELATORIOS */

            R3080_00_INSERT_V0RELATORIOS_SECTION();

            /*" -3396- SET I03 UP BY +1. */
            I03.Value += +1;

            /*" -3397- IF I03 LESS 9 */

            if (I03 < 9)
            {

                /*" -3397- GO TO R3060-10-LOOP. */
                new Task(() => R3060_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3060_99_SAIDA*/

        [StopWatch]
        /*" R3080-00-INSERT-V0RELATORIOS-SECTION */
        private void R3080_00_INSERT_V0RELATORIOS_SECTION()
        {
            /*" -3410- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -3453- PERFORM R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1 */

            R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1();

        }

        [StopWatch]
        /*" R3080-00-INSERT-V0RELATORIOS-DB-INSERT-1 */
        public void R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1()
        {
            /*" -3453- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELT-COD-USUAR , :V0RELT-DATA-SOLI , 'VG' , :V0RELT-CODREL , 1 , 0 , :V1SIST-DTMOVABE , :V1SIST-DTMOVABE , :V0RELT-DATA-REFER , 0 , 0 , 0 , :V0RELT-FONTE , 0 , 0 , 0 , 0 , :V1SOLF-NUM-APOL , :V0RELT-NRENDOS , 0 , 0 , 0 , :V0RELT-CODSUBES , 0 , 0 , 0 , ' ' , ' ' , 0 , 0 , ' ' , 0 , 0 , ' ' , '0' , ' ' , ' ' , :V0RELT-COD-EMPRESA:VIND-COD-EMP, :V0RELT-PERI-RENOVA:VIND-PERI-RENOVA, :V0RELT-PCT-AUMENTO:VIND-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 = new R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1()
            {
                V0RELT_COD_USUAR = V0RELT_COD_USUAR.ToString(),
                V0RELT_DATA_SOLI = V0RELT_DATA_SOLI.ToString(),
                V0RELT_CODREL = V0RELT_CODREL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0RELT_DATA_REFER = V0RELT_DATA_REFER.ToString(),
                V0RELT_FONTE = V0RELT_FONTE.ToString(),
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V0RELT_NRENDOS = V0RELT_NRENDOS.ToString(),
                V0RELT_CODSUBES = V0RELT_CODSUBES.ToString(),
                V0RELT_COD_EMPRESA = V0RELT_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0RELT_PERI_RENOVA = V0RELT_PERI_RENOVA.ToString(),
                VIND_PERI_RENOVA = VIND_PERI_RENOVA.ToString(),
                V0RELT_PCT_AUMENTO = V0RELT_PCT_AUMENTO.ToString(),
                VIND_PCT_AUMENTO = VIND_PCT_AUMENTO.ToString(),
            };

            R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1.Execute(r3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3080_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-V0FATURAS-SECTION */
        private void R3100_00_INSERT_V0FATURAS_SECTION()
        {
            /*" -3467- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", WABEND.WNR_EXEC_SQL);

            /*" -3487- PERFORM R3100_00_INSERT_V0FATURAS_DB_INSERT_1 */

            R3100_00_INSERT_V0FATURAS_DB_INSERT_1();

            /*" -3490- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3490- ADD +1 TO AC-I-V0FATURAS. */
                AC_I_V0FATURAS.Value = AC_I_V0FATURAS + +1;
            }


        }

        [StopWatch]
        /*" R3100-00-INSERT-V0FATURAS-DB-INSERT-1 */
        public void R3100_00_INSERT_V0FATURAS_DB_INSERT_1()
        {
            /*" -3487- EXEC SQL INSERT INTO SEGUROS.V0FATURAS VALUES (:V0FATR-NUM-APOL , :V0FATR-COD-SUBG , :V0FATR-NUM-FATUR , :V0FATR-COD-OPER , :V0FATR-TIPO-ENDOS , :V0FATR-NUM-ENDOS , :V0FATR-VAL-FATURA , :V0FATR-COD-FONTE , :V0FATR-NUM-RCAP , :V0FATR-VAL-RCAP , :V0FATR-DATA-INIVIG , :V0FATR-DATA-TERVIG , :V0FATR-SIT-REG , :V0FATR-DATA-FATUR:V0FATR-DATA-FATU-I, :V0FATR-DATA-RCAP:V0FATR-DATA-RCAP-I, :V0FATR-COD-EMPRESA:VIND-COD-EMP, :V0FATR-DATA-VENC:V0FATR-DATA-VENC-I, :V0FATR-VLIOCC) END-EXEC. */

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
            /*" -3503- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -3521- PERFORM R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1 */

            R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1();

            /*" -3524- ADD +1 TO AC-I-V0FATURASTOT. */
            AC_I_V0FATURASTOT.Value = AC_I_V0FATURASTOT + +1;

        }

        [StopWatch]
        /*" R3200-00-INSERT-V0FATURASTOT-DB-INSERT-1 */
        public void R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1()
        {
            /*" -3521- EXEC SQL INSERT INTO SEGUROS.V0FATURASTOT VALUES (:V0FATT-NUM-APOL , :V0FATT-COD-SUBG , :V0FATT-NUM-FATUR , :V0FATT-COD-OPER , :V0FATT-QT-VIDA-VG , :V0FATT-QT-VIDA-AP , :V0FATT-IMP-MORNAT , :V0FATT-IMP-MORACI , :V0FATT-IMP-INVPER , :V0FATT-IMP-AMDS , :V0FATT-IMP-DH , :V0FATT-IMP-DIT , :V0FATT-PRM-VG , :V0FATT-PRM-AP , :V0FATT-SIT-REG , :V0FATT-COD-EMPRESA:VIND-COD-EMP) END-EXEC. */

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
        /*" R3300-00-INSERT-V0ENDOSSO-SECTION */
        private void R3300_00_INSERT_V0ENDOSSO_SECTION()
        {
            /*" -3537- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3540- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3300_00_V0ENDOSSO_PROPAUTOM */

            R3300_00_V0ENDOSSO_PROPAUTOM();

        }

        [StopWatch]
        /*" R3300-00-V0ENDOSSO-PROPAUTOM */
        private void R3300_00_V0ENDOSSO_PROPAUTOM(bool isPerform = false)
        {
            /*" -3634- PERFORM R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1 */

            R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1();

            /*" -3637- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3641- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3643- COMPUTE V0FONT-PROPAUTOM = V0FONT-PROPAUTOM + 1 */
                    V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

                    /*" -3644- MOVE V0FONT-PROPAUTOM TO V0ENDO-NRPROPOS */
                    _.Move(V0FONT_PROPAUTOM, V0ENDO_NRPROPOS);

                    /*" -3645- GO TO R3300-00-V0ENDOSSO-PROPAUTOM */
                    new Task(() => R3300_00_V0ENDOSSO_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3646- ELSE */
                }
                else
                {


                    /*" -3647- DISPLAY 'R3300-V0ENDOSSO (ERRO INSERT V0ENDOSSO)' */
                    _.Display($"R3300-V0ENDOSSO (ERRO INSERT V0ENDOSSO)");

                    /*" -3649- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3651- PERFORM R1420-00-UPDATE-V0FONTE. */

            R1420_00_UPDATE_V0FONTE_SECTION();

            /*" -3652- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -3655- ADD +1 TO AC-I-V0ENDOSSO. */
            AC_I_V0ENDOSSO.Value = AC_I_V0ENDOSSO + +1;

        }

        [StopWatch]
        /*" R3300-00-V0ENDOSSO-PROPAUTOM-DB-INSERT-1 */
        public void R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1()
        {
            /*" -3634- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPEND , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:V0ENDO-DATARCAP-I, :V0ENDO-COD-EMPRESA:VIND-COD-EMP, :V0ENDO-CORRECAO:V0ENDO-CORRECAO-I, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:V0ENDO-DTVENCTO-I, NULL, NULL, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

            var r3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1 = new R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_DATPRO = V0ENDO_DATPRO.ToString(),
                V0ENDO_DT_LIBER = V0ENDO_DT_LIBER.ToString(),
                V0ENDO_DTEMIS = V0ENDO_DTEMIS.ToString(),
                V0ENDO_NRRCAP = V0ENDO_NRRCAP.ToString(),
                V0ENDO_VLRCAP = V0ENDO_VLRCAP.ToString(),
                V0ENDO_BCORCAP = V0ENDO_BCORCAP.ToString(),
                V0ENDO_AGERCAP = V0ENDO_AGERCAP.ToString(),
                V0ENDO_DACRCAP = V0ENDO_DACRCAP.ToString(),
                V0ENDO_IDRCAP = V0ENDO_IDRCAP.ToString(),
                V0ENDO_BCOCOBR = V0ENDO_BCOCOBR.ToString(),
                V0ENDO_AGECOBR = V0ENDO_AGECOBR.ToString(),
                V0ENDO_DACCOBR = V0ENDO_DACCOBR.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V0ENDO_PCENTRAD = V0ENDO_PCENTRAD.ToString(),
                V0ENDO_PCADICIO = V0ENDO_PCADICIO.ToString(),
                V0ENDO_PRESTA1 = V0ENDO_PRESTA1.ToString(),
                V0ENDO_QTPARCEL = V0ENDO_QTPARCEL.ToString(),
                V0ENDO_QTPRESTA = V0ENDO_QTPRESTA.ToString(),
                V0ENDO_QTITENS = V0ENDO_QTITENS.ToString(),
                V0ENDO_CODTXT = V0ENDO_CODTXT.ToString(),
                V0ENDO_CDACEITA = V0ENDO_CDACEITA.ToString(),
                V0ENDO_MOEDA_IMP = V0ENDO_MOEDA_IMP.ToString(),
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_TIPEND = V0ENDO_TIPEND.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                V0ENDO_DATARCAP_I = V0ENDO_DATARCAP_I.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                V0ENDO_CORRECAO_I = V0ENDO_CORRECAO_I.ToString(),
                V0ENDO_ISENTA_CST = V0ENDO_ISENTA_CST.ToString(),
                V0ENDO_DTVENCTO = V0ENDO_DTVENCTO.ToString(),
                V0ENDO_DTVENCTO_I = V0ENDO_DTVENCTO_I.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-SELECT-V1FATURA-SECTION */
        private void R3500_00_SELECT_V1FATURA_SECTION()
        {
            /*" -3667- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WABEND.WNR_EXEC_SQL);

            /*" -3676- PERFORM R3500_00_SELECT_V1FATURA_DB_SELECT_1 */

            R3500_00_SELECT_V1FATURA_DB_SELECT_1();

            /*" -3679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3683- DISPLAY 'R3500 - ERRO SELECT V1FATURAS ... ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG ' ' V1SOLF-NUM-FAT */

                $"R3500 - ERRO SELECT V1FATURAS ...  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG} {V1SOLF_NUM_FAT}"
                .Display();

                /*" -3683- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3500-00-SELECT-V1FATURA-DB-SELECT-1 */
        public void R3500_00_SELECT_V1FATURA_DB_SELECT_1()
        {
            /*" -3676- EXEC SQL SELECT DATA_INIVIGENCIA , DATA_TERVIGENCIA INTO :V1FATR-DATA-INIVIG , :V1FATR-DATA-TERVIG FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG AND NUM_FATURA = :V1SOLF-NUM-FAT END-EXEC. */

            var r3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1 = new R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
                V1SOLF_COD_SUBG = V1SOLF_COD_SUBG.ToString(),
                V1SOLF_NUM_FAT = V1SOLF_NUM_FAT.ToString(),
            };

            var executed_1 = R3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1.Execute(r3500_00_SELECT_V1FATURA_DB_SELECT_1_Query1);
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
            /*" -3697- MOVE '320' TO WNR-EXEC-SQL */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -3701- PERFORM R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1 */

            R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1();

            /*" -3704- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3708- DISPLAY 'R4100 - ERRO DELETE V0FATURASTOT ... ' ' ' W1SOLF-NUM-APOL ' ' W1SOLF-COD-SUBG ' ' W1SOLF-NUM-FAT */

                $"R4100 - ERRO DELETE V0FATURASTOT ...  {W1SOLF_NUM_APOL} {W1SOLF_COD_SUBG} {W1SOLF_NUM_FAT}"
                .Display();

                /*" -3710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3710- ADD +1 TO AC-D-V0FATURTOT. */
            AC_D_V0FATURTOT.Value = AC_D_V0FATURTOT + +1;

        }

        [StopWatch]
        /*" R4100-00-DELETE-V0FATURASTOT-DB-DELETE-1 */
        public void R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1()
        {
            /*" -3701- EXEC SQL DELETE FROM SEGUROS.V0FATURASTOT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

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
            /*" -3723- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WABEND.WNR_EXEC_SQL);

            /*" -3728- PERFORM R5100_00_DELETE_V0FATURAS_DB_DELETE_1 */

            R5100_00_DELETE_V0FATURAS_DB_DELETE_1();

            /*" -3731- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3735- DISPLAY 'R5100-00 (PROBLEMAS DELETE V0FATURAS) ... ' ' ' W1SOLF-NUM-APOL ' ' W1SOLF-COD-SUBG ' ' W1SOLF-NUM-FAT */

                $"R5100-00 (PROBLEMAS DELETE V0FATURAS) ...  {W1SOLF_NUM_APOL} {W1SOLF_COD_SUBG} {W1SOLF_NUM_FAT}"
                .Display();

                /*" -3737- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3737- ADD +1 TO AC-A-V0FATURAS. */
            AC_A_V0FATURAS.Value = AC_A_V0FATURAS + +1;

        }

        [StopWatch]
        /*" R5100-00-DELETE-V0FATURAS-DB-DELETE-1 */
        public void R5100_00_DELETE_V0FATURAS_DB_DELETE_1()
        {
            /*" -3728- EXEC SQL DELETE FROM SEGUROS.V0FATURAS WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND NUM_FATURA = :W1SOLF-NUM-FAT END-EXEC. */

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
        /*" R5200-00-UPDATE-V0FATURCONT-SECTION */
        private void R5200_00_UPDATE_V0FATURCONT_SECTION()
        {
            /*" -3757- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WABEND.WNR_EXEC_SQL);

            /*" -3764- PERFORM R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1 */

            R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1();

            /*" -3767- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3770- DISPLAY 'R5200-00 (PROBLEMAS UPDATE V0FATURCONT) ... ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG */

                $"R5200-00 (PROBLEMAS UPDATE V0FATURCONT) ...  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG}"
                .Display();

                /*" -3772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3772- ADD +1 TO AC-A-V0FATURCONT. */
            AC_A_V0FATURCONT.Value = AC_A_V0FATURCONT + +1;

        }

        [StopWatch]
        /*" R5200-00-UPDATE-V0FATURCONT-DB-UPDATE-1 */
        public void R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1()
        {
            /*" -3764- EXEC SQL UPDATE SEGUROS.V0FATURCONT SET DATA_REFERENCIA = DATA_REFERENCIA + :V1SUBG-PERI-FATUR MONTH, DATA_ULT_FATURAMEN = :V1SIST-DTMOVABE WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG END-EXEC */

            var r5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1 = new R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1()
            {
                V1SUBG_PERI_FATUR = V1SUBG_PERI_FATUR.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
            };

            R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1.Execute(r5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-UPDATE-V0SOLICFAT-SECTION */
        private void R5300_00_UPDATE_V0SOLICFAT_SECTION()
        {
            /*" -3785- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", WABEND.WNR_EXEC_SQL);

            /*" -3786- IF W1S-COD-OPER EQUAL 100 */

            if (W1S_COD_OPER == 100)
            {

                /*" -3787- MOVE '1' TO V1SOLF-SIT-REG */
                _.Move("1", V1SOLF_SIT_REG);

                /*" -3788- ELSE */
            }
            else
            {


                /*" -3790- MOVE '2' TO V1SOLF-SIT-REG. */
                _.Move("2", V1SOLF_SIT_REG);
            }


            /*" -3797- PERFORM R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1 */

            R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1();

            /*" -3800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3804- DISPLAY 'R5300-00 (PROBLEMAS UPDATE V0SOLICFAT) ... ' ' ' V1SOLF-NUM-APOL ' ' V1SOLF-COD-SUBG ' ' V1SOLF-NUM-FAT */

                $"R5300-00 (PROBLEMAS UPDATE V0SOLICFAT) ...  {V1SOLF_NUM_APOL} {V1SOLF_COD_SUBG} {V1SOLF_NUM_FAT}"
                .Display();

                /*" -3806- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3806- ADD +1 TO AC-A-V0SOLICFAT. */
            AC_A_V0SOLICFAT.Value = AC_A_V0SOLICFAT + +1;

        }

        [StopWatch]
        /*" R5300-00-UPDATE-V0SOLICFAT-DB-UPDATE-1 */
        public void R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1()
        {
            /*" -3797- EXEC SQL UPDATE SEGUROS.V0SOLICITAFAT SET SIT_REGISTRO = :V1SOLF-SIT-REG WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND COD_SUBGRUPO = :V1SOLF-COD-SUBG AND NUM_FATURA = :V1SOLF-NUM-FAT AND SIT_REGISTRO = '0' END-EXEC. */

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
        /*" R5400-00-SELECT-V1FATURCONT-SECTION */
        private void R5400_00_SELECT_V1FATURCONT_SECTION()
        {
            /*" -3819- MOVE '540' TO WNR-EXEC-SQL. */
            _.Move("540", WABEND.WNR_EXEC_SQL);

            /*" -3826- PERFORM R5400_00_SELECT_V1FATURCONT_DB_SELECT_1 */

            R5400_00_SELECT_V1FATURCONT_DB_SELECT_1();

            /*" -3829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3833- DISPLAY 'R5400-00 (PROBLEMAS SELECT V1FATURCONT) .. ' ' ' W1SOLF-NUM-APOL ' ' W1SOLF-COD-SUBG ' ' V1SIST-DTMOVABE */

                $"R5400-00 (PROBLEMAS SELECT V1FATURCONT) ..  {W1SOLF_NUM_APOL} {W1SOLF_COD_SUBG} {V1SIST_DTMOVABE}"
                .Display();

                /*" -3835- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3842- PERFORM R5400_00_SELECT_V1FATURCONT_DB_SELECT_2 */

            R5400_00_SELECT_V1FATURCONT_DB_SELECT_2();

            /*" -3845- IF V9SOLF-NUM-FAT EQUAL ZEROS */

            if (V9SOLF_NUM_FAT == 00)
            {

                /*" -3846- DISPLAY 'NUMERO DE FATURA ZERADO' W1SOLF-COD-SUBG */
                _.Display($"NUMERO DE FATURA ZERADO{W1SOLF_COD_SUBG}");

                /*" -3846- GO TO R5400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5400_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5400-00-SELECT-V1FATURCONT-DB-SELECT-1 */
        public void R5400_00_SELECT_V1FATURCONT_DB_SELECT_1()
        {
            /*" -3826- EXEC SQL SELECT DATA_REFERENCIA INTO :V1FATC-DATA-REFER FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND DATA_ULT_FATURAMEN = :V1SIST-DTMOVABE END-EXEC. */

            var r5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 = new R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1.Execute(r5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATC_DATA_REFER, V1FATC_DATA_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5400_99_SAIDA*/

        [StopWatch]
        /*" R5400-00-SELECT-V1FATURCONT-DB-SELECT-2 */
        public void R5400_00_SELECT_V1FATURCONT_DB_SELECT_2()
        {
            /*" -3842- EXEC SQL SELECT VALUE(MAX(NUM_FATURA),0) INTO :V9SOLF-NUM-FAT FROM SEGUROS.V1SOLICITAFAT WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SOLF-COD-SUBG AND FONTE IS NULL END-EXEC. */

            var r5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1 = new R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
            };

            var executed_1 = R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1.Execute(r5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V9SOLF_NUM_FAT, V9SOLF_NUM_FAT);
            }


        }

        [StopWatch]
        /*" R5500-00-INSERT-V0SOLICITAFAT-SECTION */
        private void R5500_00_INSERT_V0SOLICITAFAT_SECTION()
        {
            /*" -3859- MOVE '550' TO WNR-EXEC-SQL. */
            _.Move("550", WABEND.WNR_EXEC_SQL);

            /*" -3860- MOVE V1FATC-DATA-REFER TO WDATA-REFERENCIA */
            _.Move(V1FATC_DATA_REFER, WDATA_REFERENCIA);

            /*" -3861- MOVE WREF-ANO TO WFAT-ANO */
            _.Move(FILLER_21.WREF_ANO, FILLER_14.WFAT_ANO);

            /*" -3862- MOVE WREF-MES TO WFAT-MES */
            _.Move(FILLER_21.WREF_MES, FILLER_14.WFAT_MES);

            /*" -3864- MOVE WNUM-FATURA TO V0SOLF-NUM-FATUR */
            _.Move(WNUM_FATURA, V0SOLF_NUM_FATUR);

            /*" -3879- PERFORM R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1 */

            R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1();

            /*" -3882- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3882- ADD +1 TO AC-I-V0SOLICFAT. */
                AC_I_V0SOLICFAT.Value = AC_I_V0SOLICFAT + +1;
            }


        }

        [StopWatch]
        /*" R5500-00-INSERT-V0SOLICITAFAT-DB-INSERT-1 */
        public void R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1()
        {
            /*" -3879- EXEC SQL INSERT INTO SEGUROS.V0SOLICITAFAT VALUES (:W1SOLF-NUM-APOL , :W1SOLF-COD-SUBG , :V0SOLF-NUM-FATUR , 0 , 0 , 100 , '3' , NULL , NULL , :V1SIST-DTMOVABE , CURRENT TIMESTAMP , '9999' , NULL) END-EXEC. */

            var r5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1 = new R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1()
            {
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SOLF_COD_SUBG = W1SOLF_COD_SUBG.ToString(),
                V0SOLF_NUM_FATUR = V0SOLF_NUM_FATUR.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1.Execute(r5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R5600-00-SELECT-V0ENDOSSO-SECTION */
        private void R5600_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -3895- MOVE '560' TO WNR-EXEC-SQL. */
            _.Move("560", WABEND.WNR_EXEC_SQL);

            /*" -3901- PERFORM R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -3904- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3906- DISPLAY 'R5600-00 (NAO EXISTE NA V0ENDOSSO) ... ' ' ' V1SUBG-NUM-APOL */

                $"R5600-00 (NAO EXISTE NA V0ENDOSSO) ...  {V1SUBG_NUM_APOL}"
                .Display();

                /*" -3906- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5600-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -3901- EXEC SQL SELECT DTTERVIG INTO :V0ENDO-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1SOLF-NUM-APOL AND NRENDOS = 0 END-EXEC. */

            var r5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V1SOLF_NUM_APOL = V1SOLF_NUM_APOL.ToString(),
            };

            var executed_1 = R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r5600_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5600_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3920- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, WDATA_REL);

            /*" -3921- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_24.WDAT_REL_DIA, WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -3922- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_24.WDAT_REL_MES, WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -3924- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_24.WDAT_REL_ANO, WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -3925- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3926- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3927- DISPLAY '*   VG0100B - F A T U R A M E N T O        *' */
            _.Display($"*   VG0100B - F A T U R A M E N T O        *");

            /*" -3928- DISPLAY '*   -------   - - - - - - - - - - -        *' */
            _.Display($"*   -------   - - - - - - - - - - -        *");

            /*" -3929- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3930- DISPLAY '*   NAO HOUVE SOLICITACAO                  *' */
            _.Display($"*   NAO HOUVE SOLICITACAO                  *");

            /*" -3932- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {WDAT_REL_LIT}                    *"
            .Display();

            /*" -3933- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3933- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-TOTALIZA-MOVIMENTO-SECTION */
        private void R6000_00_TOTALIZA_MOVIMENTO_SECTION()
        {
            /*" -3945- IF V1SOLF-COD-SUBG EQUAL ZEROS */

            if (V1SOLF_COD_SUBG == 00)
            {

                /*" -3947- IF W1S-TIPO-FAT EQUAL '2' OR '3' */

                if (W1S_TIPO_FAT.In("2", "3"))
                {

                    /*" -3948- MOVE W1SOLF-COD-SUBG TO W1SUB-GRUPO */
                    _.Move(W1SOLF_COD_SUBG, W1SUB_GRUPO);

                    /*" -3949- MOVE W1SOLF-COD-SUBG TO W2SUB-GRUPO */
                    _.Move(W1SOLF_COD_SUBG, W2SUB_GRUPO);

                    /*" -3950- PERFORM 6100-DECLARE-MOVIM */

                    M_6100_DECLARE_MOVIM_SECTION();

                    /*" -3952- ELSE */
                }
                else
                {


                    /*" -3953- MOVE 0001 TO W1SUB-GRUPO */
                    _.Move(0001, W1SUB_GRUPO);

                    /*" -3954- MOVE 9999 TO W2SUB-GRUPO */
                    _.Move(9999, W2SUB_GRUPO);

                    /*" -3955- PERFORM 6110-DECLARE-MOVIM */

                    M_6110_DECLARE_MOVIM_SECTION();

                    /*" -3957- ELSE */
                }

            }
            else
            {


                /*" -3958- MOVE W1SOLF-COD-SUBG TO W1SUB-GRUPO */
                _.Move(W1SOLF_COD_SUBG, W1SUB_GRUPO);

                /*" -3959- MOVE W1SOLF-COD-SUBG TO W2SUB-GRUPO */
                _.Move(W1SOLF_COD_SUBG, W2SUB_GRUPO);

                /*" -3959- PERFORM 6100-DECLARE-MOVIM. */

                M_6100_DECLARE_MOVIM_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" M-6100-DECLARE-MOVIM-SECTION */
        private void M_6100_DECLARE_MOVIM_SECTION()
        {
            /*" -3970- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", WFIM_MOVIMENTO);

            /*" -3972- MOVE '370' TO WNR-EXEC-SQL. */
            _.Move("370", WABEND.WNR_EXEC_SQL);

            /*" -3998- PERFORM M_6100_DECLARE_MOVIM_DB_DECLARE_1 */

            M_6100_DECLARE_MOVIM_DB_DECLARE_1();

            /*" -4000- PERFORM M_6100_DECLARE_MOVIM_DB_OPEN_1 */

            M_6100_DECLARE_MOVIM_DB_OPEN_1();

            /*" -4003- PERFORM R6150-00-FETCH-MOVIMENTO UNTIL WFIM-MOVIMENTO EQUAL 'S' . */

            while (!(WFIM_MOVIMENTO == "S"))
            {

                R6150_00_FETCH_MOVIMENTO_SECTION();
            }

        }

        [StopWatch]
        /*" M-6100-DECLARE-MOVIM-DB-OPEN-1 */
        public void M_6100_DECLARE_MOVIM_DB_OPEN_1()
        {
            /*" -4000- EXEC SQL OPEN MOVIMENTO END-EXEC. */

            MOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-6110-DECLARE-MOVIM-DB-DECLARE-1 */
        public void M_6110_DECLARE_MOVIM_DB_DECLARE_1()
        {
            /*" -4041- EXEC SQL DECLARE CMOVTO2 CURSOR FOR SELECT IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_MOVIMENTO , DATA_FATURA FROM SEGUROS.V0MOVIMENTO WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO BETWEEN 1 AND 9999 AND DATA_INCLUSAO IS NOT NULL AND DATA_REFERENCIA = :V1FATC-DATA-REFER END-EXEC. */
            CMOVTO2 = new VG0100B_CMOVTO2(true);
            string GetQuery_CMOVTO2()
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
							AND COD_SUBGRUPO BETWEEN 1 AND 9999 
							AND DATA_INCLUSAO IS NOT NULL 
							AND DATA_REFERENCIA = '{V1FATC_DATA_REFER}'";

                return query;
            }
            CMOVTO2.GetQueryEvent += GetQuery_CMOVTO2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_6100_FIM*/

        [StopWatch]
        /*" M-6110-DECLARE-MOVIM-SECTION */
        private void M_6110_DECLARE_MOVIM_SECTION()
        {
            /*" -4013- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", WFIM_MOVIMENTO);

            /*" -4015- MOVE '371' TO WNR-EXEC-SQL. */
            _.Move("371", WABEND.WNR_EXEC_SQL);

            /*" -4041- PERFORM M_6110_DECLARE_MOVIM_DB_DECLARE_1 */

            M_6110_DECLARE_MOVIM_DB_DECLARE_1();

            /*" -4043- PERFORM M_6110_DECLARE_MOVIM_DB_OPEN_1 */

            M_6110_DECLARE_MOVIM_DB_OPEN_1();

            /*" -4046- PERFORM R6151-00-FETCH-MOVIMENTO UNTIL WFIM-MOVIMENTO EQUAL 'S' . */

            while (!(WFIM_MOVIMENTO == "S"))
            {

                R6151_00_FETCH_MOVIMENTO_SECTION();
            }

        }

        [StopWatch]
        /*" M-6110-DECLARE-MOVIM-DB-OPEN-1 */
        public void M_6110_DECLARE_MOVIM_DB_OPEN_1()
        {
            /*" -4043- EXEC SQL OPEN CMOVTO2 END-EXEC. */

            CMOVTO2.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_6110_FIM*/

        [StopWatch]
        /*" R6150-00-FETCH-MOVIMENTO-SECTION */
        private void R6150_00_FETCH_MOVIMENTO_SECTION()
        {
            /*" -4057- MOVE '380' TO WNR-EXEC-SQL. */
            _.Move("380", WABEND.WNR_EXEC_SQL);

            /*" -4076- PERFORM R6150_00_FETCH_MOVIMENTO_DB_FETCH_1 */

            R6150_00_FETCH_MOVIMENTO_DB_FETCH_1();

            /*" -4079- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4080- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WFIM_MOVIMENTO);

                /*" -4080- PERFORM R6150_00_FETCH_MOVIMENTO_DB_CLOSE_1 */

                R6150_00_FETCH_MOVIMENTO_DB_CLOSE_1();

                /*" -4082- ELSE */
            }
            else
            {


                /*" -4082- PERFORM R6200-00-VERDATA. */

                R6200_00_VERDATA_SECTION();
            }


        }

        [StopWatch]
        /*" R6150-00-FETCH-MOVIMENTO-DB-FETCH-1 */
        public void R6150_00_FETCH_MOVIMENTO_DB_FETCH_1()
        {
            /*" -4076- EXEC SQL FETCH MOVIMENTO INTO :V0MOVI-MORNATU-ANT , :V0MOVI-MORNATU-ATU , :V0MOVI-MORACID-ANT , :V0MOVI-MORACID-ATU , :V0MOVI-INVPERM-ANT , :V0MOVI-INVPERM-ATU , :V0MOVI-AMDS-ANT , :V0MOVI-AMDS-ATU , :V0MOVI-DH-ANT , :V0MOVI-DH-ATU , :V0MOVI-DIT-ANT , :V0MOVI-DIT-ATU , :V0MOVI-VG-ANT , :V0MOVI-VG-ATU , :V0MOVI-AP-ANT , :V0MOVI-AP-ATU , :V0MOVI-COD-OPER , :V0MOVI-DATA-MOVI END-EXEC. */

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
            /*" -4080- EXEC SQL CLOSE MOVIMENTO END-EXEC */

            MOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_99_SAIDA*/

        [StopWatch]
        /*" R6151-00-FETCH-MOVIMENTO-SECTION */
        private void R6151_00_FETCH_MOVIMENTO_SECTION()
        {
            /*" -4094- MOVE '381' TO WNR-EXEC-SQL. */
            _.Move("381", WABEND.WNR_EXEC_SQL);

            /*" -4113- PERFORM R6151_00_FETCH_MOVIMENTO_DB_FETCH_1 */

            R6151_00_FETCH_MOVIMENTO_DB_FETCH_1();

            /*" -4116- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4117- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WFIM_MOVIMENTO);

                /*" -4117- PERFORM R6151_00_FETCH_MOVIMENTO_DB_CLOSE_1 */

                R6151_00_FETCH_MOVIMENTO_DB_CLOSE_1();

                /*" -4119- ELSE */
            }
            else
            {


                /*" -4119- PERFORM R6200-00-VERDATA. */

                R6200_00_VERDATA_SECTION();
            }


        }

        [StopWatch]
        /*" R6151-00-FETCH-MOVIMENTO-DB-FETCH-1 */
        public void R6151_00_FETCH_MOVIMENTO_DB_FETCH_1()
        {
            /*" -4113- EXEC SQL FETCH CMOVTO2 INTO :V0MOVI-MORNATU-ANT , :V0MOVI-MORNATU-ATU , :V0MOVI-MORACID-ANT , :V0MOVI-MORACID-ATU , :V0MOVI-INVPERM-ANT , :V0MOVI-INVPERM-ATU , :V0MOVI-AMDS-ANT , :V0MOVI-AMDS-ATU , :V0MOVI-DH-ANT , :V0MOVI-DH-ATU , :V0MOVI-DIT-ANT , :V0MOVI-DIT-ATU , :V0MOVI-VG-ANT , :V0MOVI-VG-ATU , :V0MOVI-AP-ANT , :V0MOVI-AP-ATU , :V0MOVI-COD-OPER , :V0MOVI-DATA-MOVI END-EXEC. */

            if (CMOVTO2.Fetch())
            {
                _.Move(CMOVTO2.V0MOVI_MORNATU_ANT, V0MOVI_MORNATU_ANT);
                _.Move(CMOVTO2.V0MOVI_MORNATU_ATU, V0MOVI_MORNATU_ATU);
                _.Move(CMOVTO2.V0MOVI_MORACID_ANT, V0MOVI_MORACID_ANT);
                _.Move(CMOVTO2.V0MOVI_MORACID_ATU, V0MOVI_MORACID_ATU);
                _.Move(CMOVTO2.V0MOVI_INVPERM_ANT, V0MOVI_INVPERM_ANT);
                _.Move(CMOVTO2.V0MOVI_INVPERM_ATU, V0MOVI_INVPERM_ATU);
                _.Move(CMOVTO2.V0MOVI_AMDS_ANT, V0MOVI_AMDS_ANT);
                _.Move(CMOVTO2.V0MOVI_AMDS_ATU, V0MOVI_AMDS_ATU);
                _.Move(CMOVTO2.V0MOVI_DH_ANT, V0MOVI_DH_ANT);
                _.Move(CMOVTO2.V0MOVI_DH_ATU, V0MOVI_DH_ATU);
                _.Move(CMOVTO2.V0MOVI_DIT_ANT, V0MOVI_DIT_ANT);
                _.Move(CMOVTO2.V0MOVI_DIT_ATU, V0MOVI_DIT_ATU);
                _.Move(CMOVTO2.V0MOVI_VG_ANT, V0MOVI_VG_ANT);
                _.Move(CMOVTO2.V0MOVI_VG_ATU, V0MOVI_VG_ATU);
                _.Move(CMOVTO2.V0MOVI_AP_ANT, V0MOVI_AP_ANT);
                _.Move(CMOVTO2.V0MOVI_AP_ATU, V0MOVI_AP_ATU);
                _.Move(CMOVTO2.V0MOVI_COD_OPER, V0MOVI_COD_OPER);
                _.Move(CMOVTO2.V0MOVI_DATA_MOVI, V0MOVI_DATA_MOVI);
            }

        }

        [StopWatch]
        /*" R6151-00-FETCH-MOVIMENTO-DB-CLOSE-1 */
        public void R6151_00_FETCH_MOVIMENTO_DB_CLOSE_1()
        {
            /*" -4117- EXEC SQL CLOSE CMOVTO2 END-EXEC */

            CMOVTO2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6151_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-VERDATA-SECTION */
        private void R6200_00_VERDATA_SECTION()
        {
            /*" -4130- MOVE V1FATC-DATA-REFER TO CLANOMES */
            _.Move(V1FATC_DATA_REFER, AREA_DE_WORK.CLANOMES);

            /*" -4131- MOVE CLANO TO CLANO2 */
            _.Move(AREA_DE_WORK.CLANOMES.CLANO, AREA_DE_WORK.FILLER_6.CLANO2);

            /*" -4132- MOVE CLMES TO CLMES2 */
            _.Move(AREA_DE_WORK.CLANOMES.CLMES, AREA_DE_WORK.FILLER_6.CLMES2);

            /*" -4133- MOVE V0MOVI-DATA-MOVI TO CLANOMES */
            _.Move(V0MOVI_DATA_MOVI, AREA_DE_WORK.CLANOMES);

            /*" -4134- MOVE CLANO TO CLANO1 */
            _.Move(AREA_DE_WORK.CLANOMES.CLANO, AREA_DE_WORK.FILLER_5.CLANO1);

            /*" -4136- MOVE CLMES TO CLMES1. */
            _.Move(AREA_DE_WORK.CLANOMES.CLMES, AREA_DE_WORK.FILLER_5.CLMES1);

            /*" -4138- IF CLDATA1 GREATER CLDATA2 NEXT SENTENCE */

            if (AREA_DE_WORK.CLDATA1 > AREA_DE_WORK.CLDATA2)
            {

                /*" -4139- ELSE */
            }
            else
            {


                /*" -4139- PERFORM R6250-00-PROC-DATA. */

                R6250_00_PROC_DATA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6250-00-PROC-DATA-SECTION */
        private void R6250_00_PROC_DATA_SECTION()
        {
            /*" -4148- IF CLANO1 NOT EQUAL CLANO2 */

            if (AREA_DE_WORK.FILLER_5.CLANO1 != AREA_DE_WORK.FILLER_6.CLANO2)
            {

                /*" -4149- COMPUTE CLACUM1 = CLANO2 - CLANO1 */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.FILLER_6.CLANO2 - AREA_DE_WORK.FILLER_5.CLANO1;

                /*" -4150- COMPUTE CLACUM1 = CLACUM1 * 12 */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.CLACUM1 * 12;

                /*" -4151- COMPUTE CLACUM2 = CLMES2 - CLMES1 */
                AREA_DE_WORK.CLACUM2.Value = AREA_DE_WORK.FILLER_6.CLMES2 - AREA_DE_WORK.FILLER_5.CLMES1;

                /*" -4152- COMPUTE CLACUM1 = CLACUM1 + CLACUM2 */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.CLACUM1 + AREA_DE_WORK.CLACUM2;

                /*" -4153- ELSE */
            }
            else
            {


                /*" -4155- COMPUTE CLACUM1 = CLMES2 - CLMES1. */
                AREA_DE_WORK.CLACUM1.Value = AREA_DE_WORK.FILLER_6.CLMES2 - AREA_DE_WORK.FILLER_5.CLMES1;
            }


            /*" -4155- PERFORM R6300-00-MONTA-TABELA. */

            R6300_00_MONTA_TABELA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6250_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-MONTA-TABELA-SECTION */
        private void R6300_00_MONTA_TABELA_SECTION()
        {
            /*" -4166- MOVE SPACES TO WSOUTROS */
            _.Move("", AREA_DE_WORK.WSOUTROS);

            /*" -4171- MOVE 'SIM' TO WS-SOMA. */
            _.Move("SIM", AREA_DE_WORK.WS_SOMA);

            /*" -4175- IF (V0MOVI-COD-OPER GREATER 99 AND V0MOVI-COD-OPER LESS 200) OR (V0MOVI-COD-OPER GREATER 499 AND V0MOVI-COD-OPER LESS 600) */

            if ((V0MOVI_COD_OPER > 99 && V0MOVI_COD_OPER < 200) || (V0MOVI_COD_OPER > 499 && V0MOVI_COD_OPER < 600))
            {

                /*" -4176- MOVE W1SOLF-NUM-APOL TO NUM-APOL(2) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].NUM_APOL);

                /*" -4177- MOVE W1SOLF-COD-SUBG TO COD-SUBG(2) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].COD_SUBG);

                /*" -4178- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(2) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].NUM_FATUR);

                /*" -4179- MOVE 0100 TO COD-OPER(2) */
                _.Move(0100, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].COD_OPER);

                /*" -4181- COMPUTE IMP-MORNAT(02) = IMP-MORNAT(02) + V0MOVI-MORNATU-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -4183- COMPUTE IMP-MORACI(02) = IMP-MORACI(02) + V0MOVI-MORACID-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -4185- COMPUTE IMP-INVPER(02) = IMP-INVPER(02) + V0MOVI-INVPERM-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -4187- COMPUTE IMP-AMDS(02) = IMP-AMDS(02) + V0MOVI-AMDS-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -4189- COMPUTE IMP-DH(02) = IMP-DH(02) + V0MOVI-DH-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -4191- COMPUTE IMP-DIT(02) = IMP-DIT(02) + V0MOVI-DIT-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -4193- COMPUTE PRM-VG(02) = PRM-VG(02) + V0MOVI-VG-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -4196- COMPUTE PRM-AP(02) = PRM-AP(02) + V0MOVI-AP-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -4197- MOVE 'DEB' TO WSOUTROS */
                _.Move("DEB", AREA_DE_WORK.WSOUTROS);

                /*" -4198- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, OUT_IMP_MORNAT);

                /*" -4199- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, OUT_IMP_MORACI);

                /*" -4200- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, OUT_IMP_INVPER);

                /*" -4201- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, OUT_IMP_AMDS);

                /*" -4202- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, OUT_IMP_DH);

                /*" -4203- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, OUT_IMP_DIT);

                /*" -4204- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, OUT_PRM_VG);

                /*" -4206- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, OUT_PRM_AP);

                /*" -4207- IF PRM-VG(02) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_VG != 00)
                {

                    /*" -4208- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4209- ADD 1 TO QT-VIDA-VG(02) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_VG + 1;

                    /*" -4210- IF PRM-AP(02) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP != 00)
                    {

                        /*" -4211- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4212- ADD 1 TO QT-VIDA-AP(02) */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP + 1;

                        /*" -4213- ELSE */
                    }
                    else
                    {


                        /*" -4214- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4215- ELSE */
                    }

                }
                else
                {


                    /*" -4216- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4217- IF PRM-AP(02) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].PRM_AP != 00)
                    {

                        /*" -4218- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4223- ADD 1 TO QT-VIDA-AP(02). */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[02].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -4225- IF V0MOVI-COD-OPER GREATER 799 AND V0MOVI-COD-OPER LESS 900 */

            if (V0MOVI_COD_OPER > 799 && V0MOVI_COD_OPER < 900)
            {

                /*" -4226- MOVE W1SOLF-NUM-APOL TO NUM-APOL(3) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].NUM_APOL);

                /*" -4227- MOVE W1SOLF-COD-SUBG TO COD-SUBG(3) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].COD_SUBG);

                /*" -4228- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(3) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].NUM_FATUR);

                /*" -4229- MOVE 0200 TO COD-OPER(3) */
                _.Move(0200, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].COD_OPER);

                /*" -4232- COMPUTE IMP-MORNAT(03) = IMP-MORNAT(03) + (V0MOVI-MORNATU-ATU - V0MOVI-MORNATU-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORNAT.Value + (V0MOVI_MORNATU_ATU - V0MOVI_MORNATU_ANT);

                /*" -4235- COMPUTE IMP-MORACI(03) = IMP-MORACI(03) + (V0MOVI-MORACID-ATU - V0MOVI-MORACID-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_MORACI.Value + (V0MOVI_MORACID_ATU - V0MOVI_MORACID_ANT);

                /*" -4238- COMPUTE IMP-INVPER(03) = IMP-INVPER(03) + (V0MOVI-INVPERM-ATU - V0MOVI-INVPERM-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_INVPER.Value + (V0MOVI_INVPERM_ATU - V0MOVI_INVPERM_ANT);

                /*" -4241- COMPUTE IMP-AMDS(03) = IMP-AMDS(03) + (V0MOVI-AMDS-ATU - V0MOVI-AMDS-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_AMDS.Value + (V0MOVI_AMDS_ATU - V0MOVI_AMDS_ANT);

                /*" -4244- COMPUTE IMP-DH(03) = IMP-DH(03) + (V0MOVI-DH-ATU - V0MOVI-DH-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DH.Value + (V0MOVI_DH_ATU - V0MOVI_DH_ANT);

                /*" -4247- COMPUTE IMP-DIT(03) = IMP-DIT(03) + (V0MOVI-DIT-ATU - V0MOVI-DIT-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].IMP_DIT.Value + (V0MOVI_DIT_ATU - V0MOVI_DIT_ANT);

                /*" -4250- COMPUTE PRM-VG(03) = PRM-VG(03) + (V0MOVI-VG-ATU - V0MOVI-VG-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_VG.Value + (V0MOVI_VG_ATU - V0MOVI_VG_ANT);

                /*" -4254- COMPUTE PRM-AP(03) = PRM-AP(03) + (V0MOVI-AP-ATU - V0MOVI-AP-ANT) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP.Value + (V0MOVI_AP_ATU - V0MOVI_AP_ANT);

                /*" -4255- MOVE 'NAO' TO WS-SOMA */
                _.Move("NAO", AREA_DE_WORK.WS_SOMA);

                /*" -4256- MOVE 'DEB' TO WSOUTROS */
                _.Move("DEB", AREA_DE_WORK.WSOUTROS);

                /*" -4258- COMPUTE OUT-IMP-MORNAT = V0MOVI-MORNATU-ATU - V0MOVI-MORNATU-ANT */
                OUT_IMP_MORNAT.Value = V0MOVI_MORNATU_ATU - V0MOVI_MORNATU_ANT;

                /*" -4260- COMPUTE OUT-IMP-MORACI = V0MOVI-MORACID-ATU - V0MOVI-MORACID-ANT */
                OUT_IMP_MORACI.Value = V0MOVI_MORACID_ATU - V0MOVI_MORACID_ANT;

                /*" -4262- COMPUTE OUT-IMP-INVPER = V0MOVI-INVPERM-ATU - V0MOVI-INVPERM-ANT */
                OUT_IMP_INVPER.Value = V0MOVI_INVPERM_ATU - V0MOVI_INVPERM_ANT;

                /*" -4264- COMPUTE OUT-IMP-AMDS = V0MOVI-AMDS-ATU - V0MOVI-AMDS-ANT */
                OUT_IMP_AMDS.Value = V0MOVI_AMDS_ATU - V0MOVI_AMDS_ANT;

                /*" -4266- COMPUTE OUT-IMP-DH = V0MOVI-DH-ATU - V0MOVI-DH-ANT */
                OUT_IMP_DH.Value = V0MOVI_DH_ATU - V0MOVI_DH_ANT;

                /*" -4268- COMPUTE OUT-IMP-DIT = V0MOVI-DIT-ATU - V0MOVI-DIT-ANT */
                OUT_IMP_DIT.Value = V0MOVI_DIT_ATU - V0MOVI_DIT_ANT;

                /*" -4270- COMPUTE OUT-PRM-VG = V0MOVI-VG-ATU - V0MOVI-VG-ANT */
                OUT_PRM_VG.Value = V0MOVI_VG_ATU - V0MOVI_VG_ANT;

                /*" -4273- COMPUTE OUT-PRM-AP = V0MOVI-AP-ATU - V0MOVI-AP-ANT */
                OUT_PRM_AP.Value = V0MOVI_AP_ATU - V0MOVI_AP_ANT;

                /*" -4274- IF PRM-VG(03) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_VG != 00)
                {

                    /*" -4276- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4277- IF PRM-AP(03) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP != 00)
                    {

                        /*" -4279- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4280- ELSE */
                    }
                    else
                    {


                        /*" -4281- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4282- ELSE */
                    }

                }
                else
                {


                    /*" -4283- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4284- IF PRM-AP(03) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[03].PRM_AP != 00)
                    {

                        /*" -4290- MOVE 1 TO OUT-QT-VIDA-AP. */
                        _.Move(1, OUT_QT_VIDA_AP);
                    }

                }

            }


            /*" -4292- IF V0MOVI-COD-OPER GREATER 199 AND V0MOVI-COD-OPER LESS 300 */

            if (V0MOVI_COD_OPER > 199 && V0MOVI_COD_OPER < 300)
            {

                /*" -4293- MOVE W1SOLF-NUM-APOL TO NUM-APOL(4) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].NUM_APOL);

                /*" -4294- MOVE W1SOLF-COD-SUBG TO COD-SUBG(4) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].COD_SUBG);

                /*" -4295- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(4) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].NUM_FATUR);

                /*" -4296- MOVE 0300 TO COD-OPER(4) */
                _.Move(0300, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].COD_OPER);

                /*" -4298- COMPUTE IMP-MORNAT(04) = IMP-MORNAT(04) + V0MOVI-MORNATU-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -4300- COMPUTE IMP-MORACI(04) = IMP-MORACI(04) + V0MOVI-MORACID-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -4302- COMPUTE IMP-INVPER(04) = IMP-INVPER(04) + V0MOVI-INVPERM-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -4304- COMPUTE IMP-AMDS(04) = IMP-AMDS(04) + V0MOVI-AMDS-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -4306- COMPUTE IMP-DH(04) = IMP-DH(04) + V0MOVI-DH-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -4308- COMPUTE IMP-DIT(04) = IMP-DIT(04) + V0MOVI-DIT-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -4310- COMPUTE PRM-VG(04) = PRM-VG(04) + V0MOVI-VG-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -4312- COMPUTE PRM-AP(04) = PRM-AP(04) + V0MOVI-AP-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -4313- MOVE 'DEB' TO WSOUTROS */
                _.Move("DEB", AREA_DE_WORK.WSOUTROS);

                /*" -4314- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, OUT_IMP_MORNAT);

                /*" -4315- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, OUT_IMP_MORACI);

                /*" -4316- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, OUT_IMP_INVPER);

                /*" -4317- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, OUT_IMP_AMDS);

                /*" -4318- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, OUT_IMP_DH);

                /*" -4319- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, OUT_IMP_DIT);

                /*" -4320- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, OUT_PRM_VG);

                /*" -4322- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, OUT_PRM_AP);

                /*" -4323- IF PRM-VG(04) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_VG != 00)
                {

                    /*" -4324- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4325- ADD 1 TO QT-VIDA-VG(04) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_VG + 1;

                    /*" -4326- IF PRM-AP(04) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP != 00)
                    {

                        /*" -4327- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4328- ADD 1 TO QT-VIDA-AP(04) */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP + 1;

                        /*" -4329- ELSE */
                    }
                    else
                    {


                        /*" -4330- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4331- ELSE */
                    }

                }
                else
                {


                    /*" -4332- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4333- IF PRM-AP(04) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].PRM_AP != 00)
                    {

                        /*" -4334- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4340- ADD 1 TO QT-VIDA-AP(04). */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[04].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -4341- IF WSOUTROS EQUAL 'DEB' */

            if (AREA_DE_WORK.WSOUTROS == "DEB")
            {

                /*" -4343- IF OUT-QT-VIDA-VG NOT EQUAL ZEROS OR OUT-QT-VIDA-AP NOT EQUAL ZEROS */

                if (OUT_QT_VIDA_VG != 00 || OUT_QT_VIDA_AP != 00)
                {

                    /*" -4344- MOVE W1SOLF-NUM-APOL TO NUM-APOL(6) */
                    _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].NUM_APOL);

                    /*" -4345- MOVE W1SOLF-COD-SUBG TO COD-SUBG(6) */
                    _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].COD_SUBG);

                    /*" -4346- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(6) */
                    _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].NUM_FATUR);

                    /*" -4365- MOVE 0500 TO COD-OPER(6) */
                    _.Move(0500, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].COD_OPER);

                    /*" -4368- COMPUTE PRM-VG(06) = PRM-VG(06) + (OUT-PRM-VG * CLACUM1) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_VG.Value + (OUT_PRM_VG * AREA_DE_WORK.CLACUM1);

                    /*" -4379- COMPUTE PRM-AP(06) = PRM-AP(06) + (OUT-PRM-AP * CLACUM1). */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[06].PRM_AP.Value + (OUT_PRM_AP * AREA_DE_WORK.CLACUM1);
                }

            }


            /*" -4382- IF (V0MOVI-COD-OPER GREATER 399 AND V0MOVI-COD-OPER LESS 500) AND V0MOVI-COD-OPER NOT EQUAL 402 */

            if ((V0MOVI_COD_OPER > 399 && V0MOVI_COD_OPER < 500) && V0MOVI_COD_OPER != 402)
            {

                /*" -4383- MOVE W1SOLF-NUM-APOL TO NUM-APOL(7) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].NUM_APOL);

                /*" -4384- MOVE W1SOLF-COD-SUBG TO COD-SUBG(7) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].COD_SUBG);

                /*" -4385- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(7) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].NUM_FATUR);

                /*" -4386- MOVE 1100 TO COD-OPER(7) */
                _.Move(1100, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].COD_OPER);

                /*" -4388- COMPUTE IMP-MORNAT(07) = IMP-MORNAT(07) + V0MOVI-MORNATU-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -4390- COMPUTE IMP-MORACI(07) = IMP-MORACI(07) + V0MOVI-MORACID-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -4392- COMPUTE IMP-INVPER(07) = IMP-INVPER(07) + V0MOVI-INVPERM-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -4394- COMPUTE IMP-AMDS(07) = IMP-AMDS(07) + V0MOVI-AMDS-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -4396- COMPUTE IMP-DH(07) = IMP-DH(07) + V0MOVI-DH-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -4398- COMPUTE IMP-DIT(07) = IMP-DIT(07) + V0MOVI-DIT-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -4400- COMPUTE PRM-VG(07) = PRM-VG(07) + V0MOVI-VG-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -4402- COMPUTE PRM-AP(07) = PRM-AP(07) + V0MOVI-AP-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -4403- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -4404- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, OUT_IMP_MORNAT);

                /*" -4405- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, OUT_IMP_MORACI);

                /*" -4406- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, OUT_IMP_INVPER);

                /*" -4407- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, OUT_IMP_AMDS);

                /*" -4408- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, OUT_IMP_DH);

                /*" -4409- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, OUT_IMP_DIT);

                /*" -4410- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, OUT_PRM_VG);

                /*" -4412- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, OUT_PRM_AP);

                /*" -4413- IF PRM-VG(07) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_VG != 00)
                {

                    /*" -4414- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4415- ADD 1 TO QT-VIDA-VG(07) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_VG + 1;

                    /*" -4416- IF PRM-AP(07) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP != 00)
                    {

                        /*" -4417- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4418- ADD 1 TO QT-VIDA-AP(07) */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP + 1;

                        /*" -4419- ELSE */
                    }
                    else
                    {


                        /*" -4420- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4421- ELSE */
                    }

                }
                else
                {


                    /*" -4422- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4423- IF PRM-AP(07) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].PRM_AP != 00)
                    {

                        /*" -4424- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4430- ADD 1 TO QT-VIDA-AP(07). */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[07].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -4431- IF V0MOVI-COD-OPER EQUAL 402 */

            if (V0MOVI_COD_OPER == 402)
            {

                /*" -4432- MOVE W1SOLF-NUM-APOL TO NUM-APOL(8) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].NUM_APOL);

                /*" -4433- MOVE W1SOLF-COD-SUBG TO COD-SUBG(8) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].COD_SUBG);

                /*" -4434- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(8) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].NUM_FATUR);

                /*" -4435- MOVE 1200 TO COD-OPER(8) */
                _.Move(1200, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].COD_OPER);

                /*" -4437- COMPUTE IMP-MORNAT(08) = IMP-MORNAT(08) + V0MOVI-MORNATU-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -4439- COMPUTE IMP-MORACI(08) = IMP-MORACI(08) + V0MOVI-MORACID-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -4441- COMPUTE IMP-INVPER(08) = IMP-INVPER(08) + V0MOVI-INVPERM-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -4443- COMPUTE IMP-AMDS(08) = IMP-AMDS(08) + V0MOVI-AMDS-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -4445- COMPUTE IMP-DH(08) = IMP-DH(08) + V0MOVI-DH-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -4447- COMPUTE IMP-DIT(08) = IMP-DIT(08) + V0MOVI-DIT-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -4449- COMPUTE PRM-VG(08) = PRM-VG(08) + V0MOVI-VG-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -4451- COMPUTE PRM-AP(08) = PRM-AP(08) + V0MOVI-AP-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -4452- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -4453- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, OUT_IMP_MORNAT);

                /*" -4454- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, OUT_IMP_MORACI);

                /*" -4455- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, OUT_IMP_INVPER);

                /*" -4456- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, OUT_IMP_AMDS);

                /*" -4457- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, OUT_IMP_DH);

                /*" -4458- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, OUT_IMP_DIT);

                /*" -4459- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, OUT_PRM_VG);

                /*" -4461- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, OUT_PRM_AP);

                /*" -4462- IF PRM-VG(08) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_VG != 00)
                {

                    /*" -4463- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4464- ADD 1 TO QT-VIDA-VG(08) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_VG + 1;

                    /*" -4465- IF PRM-AP(08) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP != 00)
                    {

                        /*" -4466- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4467- ADD 1 TO QT-VIDA-AP(08) */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP + 1;

                        /*" -4468- ELSE */
                    }
                    else
                    {


                        /*" -4469- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4470- ELSE */
                    }

                }
                else
                {


                    /*" -4471- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4472- IF PRM-AP(08) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].PRM_AP != 00)
                    {

                        /*" -4473- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4477- ADD 1 TO QT-VIDA-AP(08). */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[08].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -4479- IF V0MOVI-COD-OPER GREATER 699 AND V0MOVI-COD-OPER LESS 800 */

            if (V0MOVI_COD_OPER > 699 && V0MOVI_COD_OPER < 800)
            {

                /*" -4480- MOVE W1SOLF-NUM-APOL TO NUM-APOL(9) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].NUM_APOL);

                /*" -4481- MOVE W1SOLF-COD-SUBG TO COD-SUBG(9) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].COD_SUBG);

                /*" -4482- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(9) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].NUM_FATUR);

                /*" -4483- MOVE 1300 TO COD-OPER(9) */
                _.Move(1300, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].COD_OPER);

                /*" -4486- COMPUTE IMP-MORNAT(09) = IMP-MORNAT(09) + (V0MOVI-MORNATU-ANT - V0MOVI-MORNATU-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORNAT.Value + (V0MOVI_MORNATU_ANT - V0MOVI_MORNATU_ATU);

                /*" -4489- COMPUTE IMP-MORACI(09) = IMP-MORACI(09) + (V0MOVI-MORACID-ANT - V0MOVI-MORACID-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_MORACI.Value + (V0MOVI_MORACID_ANT - V0MOVI_MORACID_ATU);

                /*" -4492- COMPUTE IMP-INVPER(09) = IMP-INVPER(09) + (V0MOVI-INVPERM-ANT - V0MOVI-INVPERM-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_INVPER.Value + (V0MOVI_INVPERM_ANT - V0MOVI_INVPERM_ATU);

                /*" -4495- COMPUTE IMP-AMDS(09) = IMP-AMDS(09) + (V0MOVI-AMDS-ANT - V0MOVI-AMDS-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_AMDS.Value + (V0MOVI_AMDS_ANT - V0MOVI_AMDS_ATU);

                /*" -4498- COMPUTE IMP-DH(09) = IMP-DH(09) + (V0MOVI-DH-ANT - V0MOVI-DH-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DH.Value + (V0MOVI_DH_ANT - V0MOVI_DH_ATU);

                /*" -4501- COMPUTE IMP-DIT(09) = IMP-DIT(09) + (V0MOVI-DIT-ANT - V0MOVI-DIT-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].IMP_DIT.Value + (V0MOVI_DIT_ANT - V0MOVI_DIT_ATU);

                /*" -4504- COMPUTE PRM-VG(09) = PRM-VG(09) + (V0MOVI-VG-ANT - V0MOVI-VG-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_VG.Value + (V0MOVI_VG_ANT - V0MOVI_VG_ATU);

                /*" -4507- COMPUTE PRM-AP(09) = PRM-AP(09) + (V0MOVI-AP-ANT - V0MOVI-AP-ATU) */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP.Value + (V0MOVI_AP_ANT - V0MOVI_AP_ATU);

                /*" -4508- MOVE 'NAO' TO WS-SOMA */
                _.Move("NAO", AREA_DE_WORK.WS_SOMA);

                /*" -4509- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -4511- COMPUTE OUT-IMP-MORNAT = V0MOVI-MORNATU-ANT - V0MOVI-MORNATU-ATU */
                OUT_IMP_MORNAT.Value = V0MOVI_MORNATU_ANT - V0MOVI_MORNATU_ATU;

                /*" -4513- COMPUTE OUT-IMP-MORACI = V0MOVI-MORACID-ANT - V0MOVI-MORACID-ATU */
                OUT_IMP_MORACI.Value = V0MOVI_MORACID_ANT - V0MOVI_MORACID_ATU;

                /*" -4515- COMPUTE OUT-IMP-INVPER = V0MOVI-INVPERM-ANT - V0MOVI-INVPERM-ATU */
                OUT_IMP_INVPER.Value = V0MOVI_INVPERM_ANT - V0MOVI_INVPERM_ATU;

                /*" -4517- COMPUTE OUT-IMP-AMDS = V0MOVI-AMDS-ANT - V0MOVI-AMDS-ATU */
                OUT_IMP_AMDS.Value = V0MOVI_AMDS_ANT - V0MOVI_AMDS_ATU;

                /*" -4519- COMPUTE OUT-IMP-DH = V0MOVI-DH-ANT - V0MOVI-DH-ATU */
                OUT_IMP_DH.Value = V0MOVI_DH_ANT - V0MOVI_DH_ATU;

                /*" -4521- COMPUTE OUT-IMP-DIT = V0MOVI-DIT-ANT - V0MOVI-DIT-ATU */
                OUT_IMP_DIT.Value = V0MOVI_DIT_ANT - V0MOVI_DIT_ATU;

                /*" -4523- COMPUTE OUT-PRM-VG = V0MOVI-VG-ANT - V0MOVI-VG-ATU */
                OUT_PRM_VG.Value = V0MOVI_VG_ANT - V0MOVI_VG_ATU;

                /*" -4526- COMPUTE OUT-PRM-AP = V0MOVI-AP-ANT - V0MOVI-AP-ATU */
                OUT_PRM_AP.Value = V0MOVI_AP_ANT - V0MOVI_AP_ATU;

                /*" -4527- IF PRM-VG(09) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_VG != 00)
                {

                    /*" -4529- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4530- IF PRM-AP(09) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP != 00)
                    {

                        /*" -4532- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4533- ELSE */
                    }
                    else
                    {


                        /*" -4534- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4535- ELSE */
                    }

                }
                else
                {


                    /*" -4536- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4537- IF PRM-AP(09) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[09].PRM_AP != 00)
                    {

                        /*" -4543- MOVE 1 TO OUT-QT-VIDA-AP. */
                        _.Move(1, OUT_QT_VIDA_AP);
                    }

                }

            }


            /*" -4545- IF (V0MOVI-COD-OPER GREATER 299 AND V0MOVI-COD-OPER LESS 400) */

            if ((V0MOVI_COD_OPER > 299 && V0MOVI_COD_OPER < 400))
            {

                /*" -4546- MOVE W1SOLF-NUM-APOL TO NUM-APOL(10) */
                _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].NUM_APOL);

                /*" -4547- MOVE W1SOLF-COD-SUBG TO COD-SUBG(10) */
                _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].COD_SUBG);

                /*" -4548- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(10) */
                _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].NUM_FATUR);

                /*" -4549- MOVE 1400 TO COD-OPER(10) */
                _.Move(1400, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].COD_OPER);

                /*" -4551- COMPUTE IMP-MORNAT(10) = IMP-MORNAT(10) + V0MOVI-MORNATU-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORNAT.Value + V0MOVI_MORNATU_ATU;

                /*" -4553- COMPUTE IMP-MORACI(10) = IMP-MORACI(10) + V0MOVI-MORACID-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORACI.Value + V0MOVI_MORACID_ATU;

                /*" -4555- COMPUTE IMP-INVPER(10) = IMP-INVPER(10) + V0MOVI-INVPERM-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_INVPER.Value + V0MOVI_INVPERM_ATU;

                /*" -4557- COMPUTE IMP-AMDS(10) = IMP-AMDS(10) + V0MOVI-AMDS-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_AMDS.Value + V0MOVI_AMDS_ATU;

                /*" -4559- COMPUTE IMP-DH(10) = IMP-DH(10) + V0MOVI-DH-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DH.Value + V0MOVI_DH_ATU;

                /*" -4561- COMPUTE IMP-DIT(10) = IMP-DIT(10) + V0MOVI-DIT-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DIT.Value + V0MOVI_DIT_ATU;

                /*" -4563- COMPUTE PRM-VG(10) = PRM-VG(10) + V0MOVI-VG-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG.Value + V0MOVI_VG_ATU;

                /*" -4565- COMPUTE PRM-AP(10) = PRM-AP(10) + V0MOVI-AP-ATU */
                TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP.Value + V0MOVI_AP_ATU;

                /*" -4566- MOVE 'CRE' TO WSOUTROS */
                _.Move("CRE", AREA_DE_WORK.WSOUTROS);

                /*" -4567- MOVE V0MOVI-MORNATU-ATU TO OUT-IMP-MORNAT */
                _.Move(V0MOVI_MORNATU_ATU, OUT_IMP_MORNAT);

                /*" -4568- MOVE V0MOVI-MORACID-ATU TO OUT-IMP-MORACI */
                _.Move(V0MOVI_MORACID_ATU, OUT_IMP_MORACI);

                /*" -4569- MOVE V0MOVI-INVPERM-ATU TO OUT-IMP-INVPER */
                _.Move(V0MOVI_INVPERM_ATU, OUT_IMP_INVPER);

                /*" -4570- MOVE V0MOVI-AMDS-ATU TO OUT-IMP-AMDS */
                _.Move(V0MOVI_AMDS_ATU, OUT_IMP_AMDS);

                /*" -4571- MOVE V0MOVI-DH-ATU TO OUT-IMP-DH */
                _.Move(V0MOVI_DH_ATU, OUT_IMP_DH);

                /*" -4572- MOVE V0MOVI-DIT-ATU TO OUT-IMP-DIT */
                _.Move(V0MOVI_DIT_ATU, OUT_IMP_DIT);

                /*" -4573- MOVE V0MOVI-VG-ATU TO OUT-PRM-VG */
                _.Move(V0MOVI_VG_ATU, OUT_PRM_VG);

                /*" -4575- MOVE V0MOVI-AP-ATU TO OUT-PRM-AP */
                _.Move(V0MOVI_AP_ATU, OUT_PRM_AP);

                /*" -4576- IF PRM-VG(10) NOT EQUAL ZEROS */

                if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG != 00)
                {

                    /*" -4577- MOVE 1 TO OUT-QT-VIDA-VG */
                    _.Move(1, OUT_QT_VIDA_VG);

                    /*" -4578- ADD 1 TO QT-VIDA-VG(10) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_VG + 1;

                    /*" -4579- IF PRM-AP(10) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP != 00)
                    {

                        /*" -4580- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4581- ADD 1 TO QT-VIDA-AP(10) */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP + 1;

                        /*" -4582- ELSE */
                    }
                    else
                    {


                        /*" -4583- MOVE 0 TO OUT-QT-VIDA-AP */
                        _.Move(0, OUT_QT_VIDA_AP);

                        /*" -4584- ELSE */
                    }

                }
                else
                {


                    /*" -4585- MOVE 0 TO OUT-QT-VIDA-VG */
                    _.Move(0, OUT_QT_VIDA_VG);

                    /*" -4586- IF PRM-AP(10) NOT EQUAL ZEROS */

                    if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP != 00)
                    {

                        /*" -4587- MOVE 1 TO OUT-QT-VIDA-AP */
                        _.Move(1, OUT_QT_VIDA_AP);

                        /*" -4592- ADD 1 TO QT-VIDA-AP(10). */
                        TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP + 1;
                    }

                }

            }


            /*" -4593- IF WSOUTROS EQUAL 'CRE' */

            if (AREA_DE_WORK.WSOUTROS == "CRE")
            {

                /*" -4595- IF OUT-QT-VIDA-VG NOT EQUAL ZEROS OR OUT-QT-VIDA-AP NOT EQUAL ZEROS */

                if (OUT_QT_VIDA_VG != 00 || OUT_QT_VIDA_AP != 00)
                {

                    /*" -4596- MOVE W1SOLF-NUM-APOL TO NUM-APOL(12) */
                    _.Move(W1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].NUM_APOL);

                    /*" -4597- MOVE W1SOLF-COD-SUBG TO COD-SUBG(12) */
                    _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].COD_SUBG);

                    /*" -4598- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(12) */
                    _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].NUM_FATUR);

                    /*" -4617- MOVE 1600 TO COD-OPER(12) */
                    _.Move(1600, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].COD_OPER);

                    /*" -4620- COMPUTE PRM-VG(12) = PRM-VG(12) + (OUT-PRM-VG * CLACUM1) */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value + (OUT_PRM_VG * AREA_DE_WORK.CLACUM1);

                    /*" -4622- COMPUTE PRM-AP(12) = PRM-AP(12) + (OUT-PRM-AP * CLACUM1). */
                    TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value + (OUT_PRM_AP * AREA_DE_WORK.CLACUM1);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-UPDATE-MOVIMENTO-SECTION */
        private void R6500_00_UPDATE_MOVIMENTO_SECTION()
        {
            /*" -4640- IF V1SOLF-COD-SUBG EQUAL ZEROS */

            if (V1SOLF_COD_SUBG == 00)
            {

                /*" -4642- IF W1S-TIPO-FAT EQUAL '2' OR '3' */

                if (W1S_TIPO_FAT.In("2", "3"))
                {

                    /*" -4643- MOVE W1SOLF-COD-SUBG TO W1SUB-GRUPO */
                    _.Move(W1SOLF_COD_SUBG, W1SUB_GRUPO);

                    /*" -4644- MOVE W1SOLF-COD-SUBG TO W2SUB-GRUPO */
                    _.Move(W1SOLF_COD_SUBG, W2SUB_GRUPO);

                    /*" -4645- PERFORM 6510-ATUALIZA-MOV */

                    M_6510_ATUALIZA_MOV_SECTION();

                    /*" -4647- ELSE */
                }
                else
                {


                    /*" -4648- MOVE 0001 TO W1SUB-GRUPO */
                    _.Move(0001, W1SUB_GRUPO);

                    /*" -4649- MOVE 9999 TO W2SUB-GRUPO */
                    _.Move(9999, W2SUB_GRUPO);

                    /*" -4650- PERFORM 6520-ATUALIZA-MOV */

                    M_6520_ATUALIZA_MOV_SECTION();

                    /*" -4652- ELSE */
                }

            }
            else
            {


                /*" -4653- MOVE W1SOLF-COD-SUBG TO W1SUB-GRUPO */
                _.Move(W1SOLF_COD_SUBG, W1SUB_GRUPO);

                /*" -4654- MOVE W1SOLF-COD-SUBG TO W2SUB-GRUPO */
                _.Move(W1SOLF_COD_SUBG, W2SUB_GRUPO);

                /*" -4654- PERFORM 6510-ATUALIZA-MOV. */

                M_6510_ATUALIZA_MOV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" M-6510-ATUALIZA-MOV-SECTION */
        private void M_6510_ATUALIZA_MOV_SECTION()
        {
            /*" -4662- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", WABEND.WNR_EXEC_SQL);

            /*" -4664- MOVE V1SIST-DTMOVABE TO V0MOVI-DATA-FATURA. */
            _.Move(V1SIST_DTMOVABE, V0MOVI_DATA_FATURA);

            /*" -4671- PERFORM M_6510_ATUALIZA_MOV_DB_UPDATE_1 */

            M_6510_ATUALIZA_MOV_DB_UPDATE_1();

        }

        [StopWatch]
        /*" M-6510-ATUALIZA-MOV-DB-UPDATE-1 */
        public void M_6510_ATUALIZA_MOV_DB_UPDATE_1()
        {
            /*" -4671- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_FATURA = :V0MOVI-DATA-FATURA WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO = :W1SUB-GRUPO AND DATA_INCLUSAO IS NOT NULL AND DATA_REFERENCIA = :V1FATC-DATA-REFER END-EXEC. */

            var m_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1 = new M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1()
            {
                V0MOVI_DATA_FATURA = V0MOVI_DATA_FATURA.ToString(),
                V1FATC_DATA_REFER = V1FATC_DATA_REFER.ToString(),
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
                W1SUB_GRUPO = W1SUB_GRUPO.ToString(),
            };

            M_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1.Execute(m_6510_ATUALIZA_MOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_6510_FIM*/

        [StopWatch]
        /*" M-6520-ATUALIZA-MOV-SECTION */
        private void M_6520_ATUALIZA_MOV_SECTION()
        {
            /*" -4682- MOVE '391' TO WNR-EXEC-SQL. */
            _.Move("391", WABEND.WNR_EXEC_SQL);

            /*" -4684- MOVE V1SIST-DTMOVABE TO V0MOVI-DATA-FATURA. */
            _.Move(V1SIST_DTMOVABE, V0MOVI_DATA_FATURA);

            /*" -4691- PERFORM M_6520_ATUALIZA_MOV_DB_UPDATE_1 */

            M_6520_ATUALIZA_MOV_DB_UPDATE_1();

        }

        [StopWatch]
        /*" M-6520-ATUALIZA-MOV-DB-UPDATE-1 */
        public void M_6520_ATUALIZA_MOV_DB_UPDATE_1()
        {
            /*" -4691- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_FATURA = :V0MOVI-DATA-FATURA WHERE NUM_APOLICE = :W1SOLF-NUM-APOL AND COD_SUBGRUPO BETWEEN 1 AND 9999 AND DATA_INCLUSAO IS NOT NULL AND DATA_REFERENCIA = :V1FATC-DATA-REFER END-EXEC. */

            var m_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1 = new M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1()
            {
                V0MOVI_DATA_FATURA = V0MOVI_DATA_FATURA.ToString(),
                V1FATC_DATA_REFER = V1FATC_DATA_REFER.ToString(),
                W1SOLF_NUM_APOL = W1SOLF_NUM_APOL.ToString(),
            };

            M_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1.Execute(m_6520_ATUALIZA_MOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_6520_FIM*/

        [StopWatch]
        /*" S0100-00-ZERA-SALDO-ANT-SECTION */
        private void S0100_00_ZERA_SALDO_ANT_SECTION()
        {
            /*" -4702- MOVE V1SOLF-NUM-APOL TO NUM-APOL(1) */
            _.Move(V1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_APOL);

            /*" -4703- MOVE W1SOLF-COD-SUBG TO COD-SUBG(1) */
            _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_SUBG);

            /*" -4704- MOVE V1SOLF-NUM-FAT TO NUM-FATUR(1) */
            _.Move(V1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_FATUR);

            /*" -4716- MOVE ZEROS TO COD-OPER(1) QT-VIDA-VG(1) QT-VIDA-AP(1) IMP-MORNAT(1) IMP-MORACI(1) IMP-INVPER(1) IMP-AMDS(1) IMP-DH(1) IMP-DIT(1) PRM-VG(1) PRM-VG(1) COD-EMPRESA(1) */
            _.Move(0, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_OPER, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_AP, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORNAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORACI, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_INVPER, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_AMDS, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DH, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DIT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_EMPRESA);

            /*" -4716- MOVE '0' TO SIT-REG(1). */
            _.Move("0", TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].SIT_REG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0100_99_SAIDA*/

        [StopWatch]
        /*" S0200-00-MONTA-SALDO-ANT-SECTION */
        private void S0200_00_MONTA_SALDO_ANT_SECTION()
        {
            /*" -4727- MOVE V1FATT-NUM-APOL TO NUM-APOL(1) */
            _.Move(V1FATT_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_APOL);

            /*" -4728- MOVE V1FATT-COD-SUBG TO COD-SUBG(1) */
            _.Move(V1FATT_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_SUBG);

            /*" -4729- MOVE V1FATT-NUM-FATUR TO NUM-FATUR(1) */
            _.Move(V1FATT_NUM_FATUR, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].NUM_FATUR);

            /*" -4730- MOVE V1FATT-COD-OPER TO COD-OPER(1) */
            _.Move(V1FATT_COD_OPER, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_OPER);

            /*" -4731- MOVE V1FATT-QT-VIDA-VG TO QT-VIDA-VG(1) */
            _.Move(V1FATT_QT_VIDA_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_VG);

            /*" -4732- MOVE V1FATT-QT-VIDA-AP TO QT-VIDA-AP(1) */
            _.Move(V1FATT_QT_VIDA_AP, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_AP);

            /*" -4733- MOVE V1FATT-IMP-MORNAT TO IMP-MORNAT(1) */
            _.Move(V1FATT_IMP_MORNAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORNAT);

            /*" -4734- MOVE V1FATT-IMP-MORACI TO IMP-MORACI(1) */
            _.Move(V1FATT_IMP_MORACI, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORACI);

            /*" -4735- MOVE V1FATT-IMP-INVPER TO IMP-INVPER(1) */
            _.Move(V1FATT_IMP_INVPER, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_INVPER);

            /*" -4736- MOVE V1FATT-IMP-AMDS TO IMP-AMDS(1) */
            _.Move(V1FATT_IMP_AMDS, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_AMDS);

            /*" -4737- MOVE V1FATT-IMP-DH TO IMP-DH(1) */
            _.Move(V1FATT_IMP_DH, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DH);

            /*" -4738- MOVE V1FATT-IMP-DIT TO IMP-DIT(1) */
            _.Move(V1FATT_IMP_DIT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DIT);

            /*" -4739- MOVE V1FATT-PRM-VG TO PRM-VG(1) */
            _.Move(V1FATT_PRM_VG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG);

            /*" -4740- MOVE V1FATT-PRM-AP TO PRM-AP(1) */
            _.Move(V1FATT_PRM_AP, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_AP);

            /*" -4741- MOVE ZEROS TO COD-EMPRESA(1) */
            _.Move(0, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].COD_EMPRESA);

            /*" -4741- MOVE '0' TO SIT-REG(1). */
            _.Move("0", TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].SIT_REG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0200_99_SAIDA*/

        [StopWatch]
        /*" S0300-00-TOTALIZA-FATURA-SECTION */
        private void S0300_00_TOTALIZA_FATURA_SECTION()
        {
            /*" -4752- MOVE V1SOLF-NUM-APOL TO NUM-APOL(13) */
            _.Move(V1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].NUM_APOL);

            /*" -4753- MOVE W1SOLF-COD-SUBG TO COD-SUBG(13) */
            _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].COD_SUBG);

            /*" -4754- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(13) */
            _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].NUM_FATUR);

            /*" -4756- MOVE 1700 TO COD-OPER(13) */
            _.Move(1700, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].COD_OPER);

            /*" -4767- COMPUTE QT-VIDA-VG(13) = QT-VIDA-VG(1) + QT-VIDA-VG(2) + QT-VIDA-VG(4) + QT-VIDA-VG(5) + QT-VIDA-VG(6) - QT-VIDA-VG(7) - QT-VIDA-VG(8) - QT-VIDA-VG(10) - QT-VIDA-VG(11) - QT-VIDA-VG(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].QT_VIDA_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].QT_VIDA_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].QT_VIDA_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].QT_VIDA_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].QT_VIDA_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].QT_VIDA_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_VG.Value;

            /*" -4778- COMPUTE QT-VIDA-AP(13) = QT-VIDA-AP(1) + QT-VIDA-AP(2) + QT-VIDA-AP(4) + QT-VIDA-AP(5) + QT-VIDA-AP(6) - QT-VIDA-AP(7) - QT-VIDA-AP(8) - QT-VIDA-AP(10) - QT-VIDA-AP(11) - QT-VIDA-AP(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].QT_VIDA_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].QT_VIDA_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].QT_VIDA_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].QT_VIDA_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].QT_VIDA_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].QT_VIDA_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].QT_VIDA_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].QT_VIDA_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_AP.Value;

            /*" -4791- COMPUTE IMP-MORNAT(13) = IMP-MORNAT(1) + IMP-MORNAT(2) + IMP-MORNAT(3) + IMP-MORNAT(4) + IMP-MORNAT(5) + IMP-MORNAT(6) - IMP-MORNAT(7) - IMP-MORNAT(8) - IMP-MORNAT(9) - IMP-MORNAT(10) - IMP-MORNAT(11) - IMP-MORNAT(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORNAT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_MORNAT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_MORNAT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_MORNAT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_MORNAT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORNAT.Value;

            /*" -4804- COMPUTE IMP-MORACI(13) = IMP-MORACI(1) + IMP-MORACI(2) + IMP-MORACI(3) + IMP-MORACI(4) + IMP-MORACI(5) + IMP-MORACI(6) - IMP-MORACI(7) - IMP-MORACI(8) - IMP-MORACI(9) - IMP-MORACI(10) - IMP-MORACI(11) - IMP-MORACI(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_MORACI.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_MORACI.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_MORACI.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_MORACI.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_MORACI.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORACI.Value;

            /*" -4817- COMPUTE IMP-INVPER(13) = IMP-INVPER(1) + IMP-INVPER(2) + IMP-INVPER(3) + IMP-INVPER(4) + IMP-INVPER(5) + IMP-INVPER(6) - IMP-INVPER(7) - IMP-INVPER(8) - IMP-INVPER(9) - IMP-INVPER(10) - IMP-INVPER(11) - IMP-INVPER(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_INVPER.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_INVPER.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_INVPER.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_INVPER.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_INVPER.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_INVPER.Value;

            /*" -4830- COMPUTE IMP-AMDS(13) = IMP-AMDS(1) + IMP-AMDS(2) + IMP-AMDS(3) + IMP-AMDS(4) + IMP-AMDS(5) + IMP-AMDS(6) - IMP-AMDS(7) - IMP-AMDS(8) - IMP-AMDS(9) - IMP-AMDS(10) - IMP-AMDS(11) - IMP-AMDS(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_AMDS.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_AMDS.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_AMDS.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_AMDS.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_AMDS.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_AMDS.Value;

            /*" -4843- COMPUTE IMP-DH(13) = IMP-DH(1) + IMP-DH(2) + IMP-DH(3) + IMP-DH(4) + IMP-DH(5) + IMP-DH(6) - IMP-DH(7) - IMP-DH(8) - IMP-DH(9) - IMP-DH(10) - IMP-DH(11) - IMP-DH(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DH.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_DH.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_DH.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_DH.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_DH.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DH.Value;

            /*" -4856- COMPUTE IMP-DIT(13) = IMP-DIT(1) + IMP-DIT(2) + IMP-DIT(3) + IMP-DIT(4) + IMP-DIT(5) + IMP-DIT(6) - IMP-DIT(7) - IMP-DIT(8) - IMP-DIT(9) - IMP-DIT(10) - IMP-DIT(11) - IMP-DIT(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].IMP_DIT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].IMP_DIT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].IMP_DIT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].IMP_DIT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].IMP_DIT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DIT.Value;

            /*" -4869- COMPUTE PRM-VG(13) = PRM-VG(1) + PRM-VG(2) + PRM-VG(3) + PRM-VG(4) + PRM-VG(5) + PRM-VG(6) - PRM-VG(7) - PRM-VG(8) - PRM-VG(9) - PRM-VG(10) - PRM-VG(11) - PRM-VG(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value;

            /*" -4882- COMPUTE PRM-AP(13) = PRM-AP(1) + PRM-AP(2) + PRM-AP(3) + PRM-AP(4) + PRM-AP(5) + PRM-AP(6) - PRM-AP(7) - PRM-AP(8) - PRM-AP(9) - PRM-AP(10) - PRM-AP(11) - PRM-AP(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[1].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[2].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[3].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[4].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[5].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[7].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[8].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[9].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[10].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[11].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value;

            /*" -4883- MOVE -1 TO VIND-COD-EMP */
            _.Move(-1, VIND_COD_EMP);

            /*" -4885- MOVE '0' TO SIT-REG(13). */
            _.Move("0", TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].SIT_REG);

            /*" -4891- COMPUTE PRM-TOTAL = PRM-AP(13) + PRM-VG(13). */
            AREA_DE_WORK.PRM_TOTAL.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value;

            /*" -4892- MOVE V1SOLF-NUM-APOL TO NUM-APOL(14) */
            _.Move(V1SOLF_NUM_APOL, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].NUM_APOL);

            /*" -4893- MOVE W1SOLF-COD-SUBG TO COD-SUBG(14) */
            _.Move(W1SOLF_COD_SUBG, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].COD_SUBG);

            /*" -4894- MOVE W1SOLF-NUM-FAT TO NUM-FATUR(14) */
            _.Move(W1SOLF_NUM_FAT, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].NUM_FATUR);

            /*" -4896- MOVE 1800 TO COD-OPER(14) */
            _.Move(1800, TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].COD_OPER);

            /*" -4900- COMPUTE QT-VIDA-VG(14) = QT-VIDA-VG(13) - QT-VIDA-VG(6) + QT-VIDA-VG(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].QT_VIDA_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_VG.Value;

            /*" -4904- COMPUTE QT-VIDA-AP(14) = QT-VIDA-AP(13) - QT-VIDA-AP(6) + QT-VIDA-AP(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].QT_VIDA_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].QT_VIDA_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].QT_VIDA_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].QT_VIDA_AP.Value;

            /*" -4908- COMPUTE IMP-MORNAT(14) = IMP-MORNAT(13) - IMP-MORNAT(6) + IMP-MORNAT(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_MORNAT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORNAT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORNAT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORNAT.Value;

            /*" -4912- COMPUTE IMP-MORACI(14) = IMP-MORACI(13) - IMP-MORACI(6) + IMP-MORACI(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_MORACI.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_MORACI.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_MORACI.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_MORACI.Value;

            /*" -4916- COMPUTE IMP-INVPER(14) = IMP-INVPER(13) - IMP-INVPER(6) + IMP-INVPER(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_INVPER.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_INVPER.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_INVPER.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_INVPER.Value;

            /*" -4920- COMPUTE IMP-AMDS(14) = IMP-AMDS(13) - IMP-AMDS(6) + IMP-AMDS(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_AMDS.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_AMDS.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_AMDS.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_AMDS.Value;

            /*" -4924- COMPUTE IMP-DH(14) = IMP-DH(13) - IMP-DH(6) + IMP-DH(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_DH.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DH.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DH.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DH.Value;

            /*" -4928- COMPUTE IMP-DIT(14) = IMP-DIT(13) - IMP-DIT(6) + IMP-DIT(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].IMP_DIT.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].IMP_DIT.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].IMP_DIT.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].IMP_DIT.Value;

            /*" -4932- COMPUTE PRM-VG(14) = PRM-VG(13) - PRM-VG(6) + PRM-VG(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].PRM_VG.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_VG.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_VG.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_VG.Value;

            /*" -4936- COMPUTE PRM-AP(14) = PRM-AP(13) - PRM-AP(6) + PRM-AP(12) */
            TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].PRM_AP.Value = TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[13].PRM_AP.Value - TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[6].PRM_AP.Value + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[12].PRM_AP.Value;

            /*" -4937- MOVE -1 TO VIND-COD-EMP */
            _.Move(-1, VIND_COD_EMP);

            /*" -4937- MOVE '0' TO SIT-REG(14). */
            _.Move("0", TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[14].SIT_REG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0300_99_SAIDA*/

        [StopWatch]
        /*" S0400-00-TOTALIZA-APOLICE-SECTION */
        private void S0400_00_TOTALIZA_APOLICE_SECTION()
        {
            /*" -4950- SET I01 TO +1. */
            I01.Value = +1;

            /*" -0- FLUXCONTROL_PERFORM S0400_10_LOOP */

            S0400_10_LOOP();

        }

        [StopWatch]
        /*" S0400-10-LOOP */
        private void S0400_10_LOOP(bool isPerform = false)
        {
            /*" -4955- IF COD-OPER(I01) NOT EQUAL ZEROS */

            if (TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER != 00)
            {

                /*" -4956- MOVE V1SOLF-NUM-APOL TO ANUM-APOL(I01) */
                _.Move(V1SOLF_NUM_APOL, ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ANUM_APOL);

                /*" -4957- MOVE V1SOLF-COD-SUBG TO ACOD-SUBG(I01) */
                _.Move(V1SOLF_COD_SUBG, ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ACOD_SUBG);

                /*" -4958- MOVE V1SOLF-NUM-FAT TO ANUM-FATUR(I01) */
                _.Move(V1SOLF_NUM_FAT, ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ANUM_FATUR);

                /*" -4959- MOVE COD-OPER(I01) TO ACOD-OPER(I01) */
                _.Move(TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].COD_OPER, ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ACOD_OPER);

                /*" -4960- ADD QT-VIDA-VG(I01) TO AQT-VIDA-VG(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_VG.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_VG + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_VG;

                /*" -4961- ADD QT-VIDA-AP(I01) TO AQT-VIDA-AP(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_AP.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AQT_VIDA_AP + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].QT_VIDA_AP;

                /*" -4962- ADD IMP-MORNAT(I01) TO AIMP-MORNAT(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORNAT.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORNAT + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORNAT;

                /*" -4963- ADD IMP-MORACI(I01) TO AIMP-MORACI(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORACI.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_MORACI + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_MORACI;

                /*" -4964- ADD IMP-INVPER(I01) TO AIMP-INVPER(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_INVPER.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_INVPER + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_INVPER;

                /*" -4965- ADD IMP-AMDS(I01) TO AIMP-AMDS(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_AMDS.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_AMDS + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_AMDS;

                /*" -4966- ADD IMP-DH(I01) TO AIMP-DH(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DH.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DH + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DH;

                /*" -4967- ADD IMP-DIT(I01) TO AIMP-DIT(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DIT.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].AIMP_DIT + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].IMP_DIT;

                /*" -4968- ADD PRM-VG(I01) TO APRM-VG(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_VG.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_VG + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_VG;

                /*" -4969- ADD PRM-AP(I01) TO APRM-AP(I01) */
                ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_AP.Value = ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].APRM_AP + TACUM_IMPRESSAO.TACUM_MASCARA.TACUM_CAMPOS.TACUM_OPERACAO[I01].PRM_AP;

                /*" -4970- MOVE ZEROS TO ACOD-EMPRESA(I01) */
                _.Move(0, ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ACOD_EMPRESA);

                /*" -4973- MOVE '0' TO ASIT-REG(I01). */
                _.Move("0", ATACUM_IMPRESSAO.ATACUM_MASCARA.ATACUM_CAMPOS.ATACUM_OPERACAO[I01].ASIT_REG);
            }


            /*" -4975- SET I01 UP BY +1. */
            I01.Value += +1;

            /*" -4976- IF I01 LESS 15 */

            if (I01 < 15)
            {

                /*" -4976- GO TO S0400-10-LOOP. */
                new Task(() => S0400_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: S0400_99_SAIDA*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -4988- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", WABEND.WNR_EXEC_SQL);

            /*" -4990- INITIALIZE REGISTRO-LINKAGE-GE0510S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -4991- MOVE V1SOLF-NUM-APOL TO LK-GE510-NUM-APOLICE */
            _.Move(V1SOLF_NUM_APOL, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -4993- MOVE V1SOLF-COD-SUBG TO LK-GE510-COD-SUBGRUPO */
            _.Move(V1SOLF_COD_SUBG, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -4995- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S. */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -4996- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -4997- MOVE LK-GE510-COD-MODALIDADE TO V1APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, V1APOL_MODALIDA);

                /*" -4998- ELSE */
            }
            else
            {


                /*" -4999- DISPLAY ' ' */
                _.Display($" ");

                /*" -5000- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -5001- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -5002- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -5003- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -5004- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -5005- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -5006- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -5007- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -5008- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -5009- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -5010- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -5011- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -5012- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5013- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5027- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -5028- DISPLAY 'APOLICE        ' V1SOLF-NUM-APOL */
            _.Display($"APOLICE        {V1SOLF_NUM_APOL}");

            /*" -5029- DISPLAY 'ENDOSSO        ' V0ENDO-NRENDOS */
            _.Display($"ENDOSSO        {V0ENDO_NRENDOS}");

            /*" -5030- DISPLAY 'PROPOSTA       ' V0ENDO-NRPROPOS */
            _.Display($"PROPOSTA       {V0ENDO_NRPROPOS}");

            /*" -5031- DISPLAY 'SUBGRUPO       ' V1SOLF-COD-SUBG */
            _.Display($"SUBGRUPO       {V1SOLF_COD_SUBG}");

            /*" -5032- DISPLAY 'FATURA         ' V1SOLF-NUM-FAT */
            _.Display($"FATURA         {V1SOLF_NUM_FAT}");

            /*" -5034- DISPLAY 'TERMO          ' NUM-TERMO */
            _.Display($"TERMO          {NUM_TERMO}");

            /*" -5036- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -5038- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5038- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -5040- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5041- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}