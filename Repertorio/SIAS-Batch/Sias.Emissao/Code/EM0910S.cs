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
using Sias.Emissao.DB2.EM0910S;

namespace Code
{
    public class EM0910S
    {
        public bool IsCall { get; set; }

        public EM0910S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0910S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1991                       *      */
        /*"      *   DATA ALTERACAO .........  DEZEMBRO/1993                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZA ITENS APOLICE  AUTO       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         INPUT    *      */
        /*"      * MOEDA / COTACAO                     V1MOEDA           INPUT    *      */
        /*"      * PROPOSTA AUTO                       V1AUTOPROP        INPUT    *      */
        /*"      * PROPOSTA AUTO TARIFA                V1AUTOTARIRPROP   INPUT    *      */
        /*"      * PROPOSTA AUTO COBERTURAS            V1AUTOCOBERPROP   INPUT    *      */
        /*"      * PROPOSTA ACESSORIOS                 V1PROPACES        INPUT    *      */
        /*"      * PROPOSTA CLAUSULAS                  V1PROPCLAU        INPUT    *      */
        /*"      * PROPOSTA COBERTURA                  V1COBERPROP       INPUT    *      */
        /*"      * APOLICE AUTO                        V0AUTOAPOL        OUTPUT   *      */
        /*"      * APOLICE AUTO TARIFA                 V0AUTOTARIFA      OUTPUT   *      */
        /*"      * APOLICE AUTO COBERTURAS             V0AUTOCOBER       OUTPUT   *      */
        /*"      * APOLICE ACESSORIOS                  V0APOLACESS       OUTPUT   *      */
        /*"      * APOLICE CLAUSULAS                   V0APOLCLAUSULA    OUTPUT   *      */
        /*"      * APOLICE COBERTURA                   V0COBERAPOL       OUTPUT   *      */
        /*"      * EMISSAO DIARIA                      V0EMISDIARIA      OUTPUT   *      */
        /*"      ******************************************************************      */
        /*"V.06  *  VERSAO 06  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *             - PORQUE A CAP ESTA DEIXANDO O MAINFRAME.          *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.06        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * ALTERACAO EM 26/02/2019 - CADMUS 191673 - OLIVEIRA             *      */
        /*"      *                                                                *      */
        /*"      *  . INCLUIR PARAMETROS PARA TRATAR TIT. DE CAPITALIZACAO        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * ALTERACAO EM 24/09/2018 - CADMUS 168975 - LISIANE              *      */
        /*"      *                                                                *      */
        /*"      *  . MUDANCA NA PLACA DO VEICULO                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * ALTERACAO EM 10/09/2013 - RILDO  - AUTO FACIL - CADMUS 86443   *      */
        /*"      *                                                                *      */
        /*"      *  . INCLUSAO DA COBERTURA 4212 PARA OS PRODUTOS DO AUTO FACIL   *      */
        /*"      *  . NA TABELA APOLICE_COBERTURAS, COM ISSO, ESSE PRODUTO NAO    *      */
        /*"      *  . SER� CONTABILIZADO.                                         *      */
        /*"      *                                                  PROCURE: V.03 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * ALTERACAO EM 10/12/2012 - COREON - AUTO FACIL - CADMUS 74582   *      */
        /*"      *                                                                *      */
        /*"      *  . INCLUSAO DA TABELA AU_APOLICE_COMPL                         *      */
        /*"      *  . COMPRA CAPITALIZACAO                                        *      */
        /*"      *  . GERACAO PAINEL DE CONTROLE/CONSULTAS                        *      */
        /*"      *                                                  PROCURE: V.02 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * ALTERACAO EM 27/05/2011 - BRSEG - PROJAUTO     VER V.01        *      */
        /*"      * INSERCAO DE COLUNAS NAS TABELAS :                              *      */
        /*"      * - V0AUTOCOBER                                                  *      */
        /*"      *   . VLR_FRANQUIA_IX                                            *      */
        /*"      *   . VLR_FRANQUIA_VAR                                           *      */
        /*"      * - V0AUTOAPOL                                                   *      */
        /*"      *   . COD_IDENTIFICACAO                                          *      */
        /*"      *   . COD_CI                                                     *      */
        /*"      *   . NUM_CONTRATO_CONV                                          *      */
        /*"      *   . NUM_RECIBO_CONV                                            *      */
        /*"      *   . IND_REL_CLI_PROPR                                          *      */
        /*"      *   . COD_IDENT_PEP                                              *      */
        /*"      *   . IND_ORIGEM_PROP                                            *      */
        /*"      *   . COD_CONGENERE                                              *      */
        /*"      *   . COD_CBO_CONV                                               *      */
        /*"      *   . COD_ATIVIDADE_CONV                                         *      */
        /*"      *   . IND_USO_VEICULO                                            *      */
        /*"      * - V0AUTOTARIFA                                                 *      */
        /*"      *   . COD_CAT_TARIF_CONV                                         *      */
        /*"      *   . COD_CONGENERE                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"KT001 *   ALTERACOES                                                   *      */
        /*"      *   EM 15.12.95 POR KITA (PROCAS) .......... PROCURE POR /KT001  *      */
        /*"      *   . SUBSTITUICAO DA CHAMADA AO PROGRAMA EM0210B (EMISSAO   DE  *      */
        /*"      *     APOLICES E ENDOSSOS DE AUTO - CORPO DUPLO), PELOS  PROGRA  *      */
        /*"      *     MAS EM0212B (APOLICE - CORPO SIMPLES) E EM0213B  (ENDOSSO  *      */
        /*"      *     - CORPO DUPLO).                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JN001 *   ALTERACOES                                                   *      */
        /*"      *   EM 29.02.96 POR JOAO (PROCASEG)......... PROCURE POR /JN001  *      */
        /*"      *   . SUBSTITUICAO DA CHAMADA AO PROGRAMA EM0220B (EMISSAO   DE  *      */
        /*"      *     ESPECIFICACAO ANEXA) PELOS PROGRAMAS EM0240B  (ESPECIFICA  *      */
        /*"      *     CAO DE CLAUSULAS) E EM0241B (ESPECIFICACAO DE VEICULOS)    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"RU001 *   ALTERACOES                                                   *      */
        /*"      *   EM 27.06.96 POR RUBENS (PROCASEG)....... PROCURE POR /RU001  *      */
        /*"      *   . VERIFICA SE DOCUMENTO TEM MAIS DE 1 ITEM                   *      */
        /*"      *     .. V1ENDO-TIPAPO '1' OU '3' - FROTA E COLETIVA             *      */
        /*"      *     CASO AFIRMATIVO SOLICITA   PROGRAMAS EM0210B  (APOLICE /   *      */
        /*"      *     ENDOSSO DE AUTO )                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V202  *   EM 21.11.2000 - HELEN MOURA JORDAO ..... PROCURE POR /V202   *      */
        /*"      *   . INCLUSAO DO CAMPO CODDESPEXTR NA TABELA APOLICE_AUTO -     *      */
        /*"      *     VERSAO 202.                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V202  *   EM 28.11.2000 - WANGER C. SILVA    ..... PROCURE POR /V202   *      */
        /*"      *   . INCLUSAO DO CAMPO DA AUTOTARIPROP E AUTOTARIFA OS ULTIMOS  *      */
        /*"      *     04(QUATRO) CAMPOS - PROCURAR V202                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V205  *   EM 30.04.2001 - HELEN MOURA JORDAO ..... PROCURE POR /V205   *      */
        /*"      *   . INCLUSAO DO CAMPO DESPEXTR_PT NAS TABELAS APOLICE_AUTO E   *      */
        /*"      *     PROPOSTA_AUTO - VERSAO 205                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V206  *   EM 09.07.2001 - HELEN MOURA JORDAO ..... PROCURE POR /V206   *      */
        /*"      *   . INCLUSAO DO CAMPO PERC_VARIACAO_IS NAS TAB. APOLICE_AUTO E *      */
        /*"      *     PROPOSTA_AUTO - VERSAO 206                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"CH0801*   EM 01.08.2001 - ALEXANDRE CHICON   ..... IMPLEMENTACAO DA    *      */
        /*"      *   . COLUNA CANAL_PROPOSTA NAS TABELAS PROPOSTA_AUTO E          *      */
        /*"      *     APOLICE_AUTO                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 05/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-FONTE         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRPROPOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUM-APOL      PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis WHOST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-NRENDOS       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-DTMOVABE      PIC  X(010).*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-COD-MOEDA     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-VLCRUZAD      PIC S9(006)V9(9) VALUE +0  COMP-3*/
        public DoubleBasis WHOST_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         WHOST-CODCORR       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NUM-ITEM      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis WHOST_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-CONGENERE     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-QT-PARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WHOST_QT_PARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-VL-PARCEL     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis WHOST_VL_PARCEL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         W1CPRO-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis W1CPRO_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W0APOL-PCTCED       PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         W1COBP-PCT-TOTAL    PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PCT_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1COBP-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-PCT-COBERT   PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         W0NAES-SEQ-APOLICE  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W0NAES_SEQ_APOLICE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W0APOL-QTCOSSEG     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis W0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1PCOR-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W1PCOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1COBA-ULTENDO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W1COBA_ULTENDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W0COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         VIND-PARC           PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PTOV           PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PTOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TOKEN          PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_TOKEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-ATA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ANO-ATA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-SORT       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DAT_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTAPOLM        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTAPOLM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-RCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DAT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIMESTAMP      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESAUT       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESAUT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESACE       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESACE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESRCF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESRCF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESAPP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESAPP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDEACESS       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_IDEACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PRMTARIFA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PRMTARIFA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ULTENDO        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ULTENDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODCLIEN       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESPLCA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESPLCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESPLRF      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESPLRF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCDESPLAP      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCDESPLAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCAGPLRF       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCAGPLRF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCAGPLAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCAGPLAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODPRODU       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCAGISCASC     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PCAGISCASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-ORGAO        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-RAMO         PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NRPROPOS     PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-MOEDA-PRM    PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-IMP    PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TIPAPO       PIC  X(001).*/
        public StringBasis V1ENDO_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-CODPRODU     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1MOED-VLCRUZAD     PIC S9(006)V9(9)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1MOED-VLCR-IMP     PIC S9(006)V9(9)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCR_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1MOED-VLCR-PRM     PIC S9(006)V9(9)  VALUE +0 COMP-3*/
        public DoubleBasis V1MOED_VLCR_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77         V1AUPR-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-NRITEM       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-DTINIVIG     PIC  X(010).*/
        public StringBasis V1AUPR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUPR-DTTERVIG     PIC  X(010).*/
        public StringBasis V1AUPR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUPR-TIPOVEIC     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-FABRICAN     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-CDVEICL      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-COMBUST      PIC  X(001).*/
        public StringBasis V1AUPR_COMBUST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-ANOVEICL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-ANOMOD       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_ANOMOD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-CORVEICL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_CORVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-CAPACID      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_CAPACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-LOTACAO      PIC  X(001).*/
        public StringBasis V1AUPR_LOTACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-PLACAUF      PIC  X(002).*/
        public StringBasis V1AUPR_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1AUPR-PLACALET     PIC  X(003).*/
        public StringBasis V1AUPR_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1AUPR-PLACANR      PIC  X(004)       VALUE SPACES.*/
        public StringBasis V1AUPR_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"77         V1AUPR-CHASSIS      PIC  X(020).*/
        public StringBasis V1AUPR_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1AUPR-UTILIZA      PIC  X(001).*/
        public StringBasis V1AUPR_UTILIZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-QTACESS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_QTACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-DTBAIXA      PIC  X(010).*/
        public StringBasis V1AUPR_DTBAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUPR-CDVISTOR     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_CDVISTOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-PROPRIET     PIC  X(040).*/
        public StringBasis V1AUPR_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1AUPR-DTIVEXTP     PIC  X(010).*/
        public StringBasis V1AUPR_DTIVEXTP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUPR-ACEITE       PIC  X(001).*/
        public StringBasis V1AUPR_ACEITE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-NRPRRESS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_NRPRRESS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-PROTSINI     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-SITUACAO     PIC  X(001).*/
        public StringBasis V1AUPR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUPR-TPMOVTO      PIC  X(001).*/
        public StringBasis V1AUPR_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-ZEROKM       PIC  X(001).*/
        public StringBasis V1AUPR_ZEROKM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-SEGBONUS     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_SEGBONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-FIDEL-AUTO   PIC  X(001).*/
        public StringBasis V1AUPR_FIDEL_AUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-FIDEL-VIDA   PIC  X(001).*/
        public StringBasis V1AUPR_FIDEL_VIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-FIDEL-PREV   PIC  X(001).*/
        public StringBasis V1AUPR_FIDEL_PREV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-DANOS-MORAIS PIC  X(001).*/
        public StringBasis V1AUPR_DANOS_MORAIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-SEG-MERC-DET PIC  X(001).*/
        public StringBasis V1AUPR_SEG_MERC_DET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-ADIC-VLR-MERCADO PIC  X(001).*/
        public StringBasis V1AUPR_ADIC_VLR_MERCADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-PERFIL       PIC  X(001).*/
        public StringBasis V1AUPR_PERFIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-DESPEXTR     PIC  X(001).*/
        public StringBasis V1AUPR_DESPEXTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-VLNOVO       PIC  X(001).*/
        public StringBasis V1AUPR_VLNOVO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-CODDESPEXTR  PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUPR_CODDESPEXTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-DESPEXTR-PT  PIC  X(001).*/
        public StringBasis V1AUPR_DESPEXTR_PT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-VARIA-IS     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1AUPR_VARIA_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1AUPR-CANAL-PROPOSTA PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V1AUPR_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUPR-TIPO-COBRANCA  PIC X(001).*/
        public StringBasis V1AUPR_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUPR-NUM-PROP-CNV PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1AUPR_NUM_PROP_CNV { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1AUPR-NUM-CERTIF   PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1AUPR_NUM_CERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1AUPR-NUM-RENAVAM  PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1AUPR_NUM_RENAVAM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1AUPR-IND-USO-VEIC PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUPR_IND_USO_VEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1INDI-ZEROKM       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1INDI_ZEROKM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1INDI-SEGBONUS     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1INDI_SEGBONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-NRITEM       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0AUTO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0AUTO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0AUTO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0AUTO-TIPOVEIC     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-FABRICAN     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-CDVEICL      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-COMBUST      PIC  X(001).*/
        public StringBasis V0AUTO_COMBUST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-ANOVEICL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-ANOMOD       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_ANOMOD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-CORVEICL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_CORVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-CAPACID      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_CAPACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-LOTACAO      PIC  X(001).*/
        public StringBasis V0AUTO_LOTACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-PLACAUF      PIC  X(002).*/
        public StringBasis V0AUTO_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0AUTO-PLACALET     PIC  X(003).*/
        public StringBasis V0AUTO_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0AUTO-PLACANR      PIC  X(004)       VALUE SPACES.*/
        public StringBasis V0AUTO_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"77         V0AUTO-CHASSIS      PIC  X(020).*/
        public StringBasis V0AUTO_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V0AUTO-UTILIZA      PIC  X(001).*/
        public StringBasis V0AUTO_UTILIZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-QTACESS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_QTACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-DTBAIXA      PIC  X(010).*/
        public StringBasis V0AUTO_DTBAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0AUTO-CDVISTOR     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_CDVISTOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-PROPRIET     PIC  X(040).*/
        public StringBasis V0AUTO_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0AUTO-DTIVEXTP     PIC  X(010).*/
        public StringBasis V0AUTO_DTIVEXTP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0AUTO-ACEITE       PIC  X(001).*/
        public StringBasis V0AUTO_ACEITE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-NRPRRESS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_NRPRRESS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-PROTSINI     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-SITUACAO     PIC  X(001).*/
        public StringBasis V0AUTO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0AUTO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0AUTO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUTO-TPMOVTO      PIC  X(001).*/
        public StringBasis V0AUTO_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-ZEROKM       PIC  X(001).*/
        public StringBasis V0AUTO_ZEROKM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-SEGBONUS     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_SEGBONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-FIDEL-AUTO   PIC  X(001).*/
        public StringBasis V0AUTO_FIDEL_AUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-FIDEL-VIDA   PIC  X(001).*/
        public StringBasis V0AUTO_FIDEL_VIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-FIDEL-PREV   PIC  X(001).*/
        public StringBasis V0AUTO_FIDEL_PREV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-DANOS-MORAIS PIC  X(001).*/
        public StringBasis V0AUTO_DANOS_MORAIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-SEG-MERC-DET PIC  X(001).*/
        public StringBasis V0AUTO_SEG_MERC_DET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-ADIC-VLR-MERCADO PIC  X(001).*/
        public StringBasis V0AUTO_ADIC_VLR_MERCADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-PERFIL       PIC  X(001).*/
        public StringBasis V0AUTO_PERFIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-DESPEXTR     PIC  X(001).*/
        public StringBasis V0AUTO_DESPEXTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-VLNOVO       PIC  X(001).*/
        public StringBasis V0AUTO_VLNOVO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-CODDESPEXTR  PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0AUTO_CODDESPEXTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-DESPEXTR-PT  PIC  X(001).*/
        public StringBasis V0AUTO_DESPEXTR_PT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-VARIA-IS     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0AUTO_VARIA_IS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0AUTO-CANAL-PROPOSTA PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V0AUTO_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-TIPO-COBRANCA PIC X(001).*/
        public StringBasis V0AUTO_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUTO-NUM-PROP-CONV PIC S9(015)      VALUE +0 COMP-3*/
        public IntBasis V0AUTO_NUM_PROP_CONV { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0AUTO-NUM-CERTIF    PIC S9(015)      VALUE +0 COMP-3*/
        public IntBasis V0AUTO_NUM_CERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0AUTO-NUM-RENAVAM   PIC S9(015)      VALUE +0 COMP-3*/
        public IntBasis V0AUTO_NUM_RENAVAM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0AUTO-IND-USO-VEIC  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0AUTO_IND_USO_VEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUTO-COD-CONGENERE PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0AUTO_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1TAPR-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1TAPR-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1TAPR-DTINIVIG     PIC  X(010).*/
        public StringBasis V1TAPR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1TAPR-DTTERVIG     PIC  X(010).*/
        public StringBasis V1TAPR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1TAPR-TERCEIXO     PIC  X(001).*/
        public StringBasis V1TAPR_TERCEIXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1TAPR-CATTARIF     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-TIPOCOB      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_TIPOCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-REGIAO       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-FRANQFAC     PIC  X(001).*/
        public StringBasis V1TAPR_FRANQFAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1TAPR-CLABONAT     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_CLABONAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-PCDESCAT     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESCAT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-CLABONDM     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_CLABONDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-CLABONDP     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_CLABONDP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-CATTARIR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_CATTARIR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-DESCFROT     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_DESCFROT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-NUMPASSG     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_NUMPASSG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-VRFROBR-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRFROBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-VRFRFACC-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRFRFACC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-VRFRFACA-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRFRFACA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-VRFRADIC-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRFRADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-VRPRREF      PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRPRREF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-CFFROBR      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_CFFROBR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-CFFRFACC     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_CFFRFACC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-CFFRFACA     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_CFFRFACA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-CFPRREF      PIC S9(002)V9(3) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_CFPRREF { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V1TAPR-PCDSCFRF     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDSCFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-PCISCASC     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCISCASC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-PCINCROU     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCINCROU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-PCAGPLCA     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCAGPLCA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-PCAGPLAC     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCAGPLAC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-VRPRRFDM     PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRPRRFDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1TAPR-VRPRRFDP     PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VRPRRFDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1TAPR-EXTPER       PIC  X(001).*/
        public StringBasis V1TAPR_EXTPER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1TAPR-PERIODO      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_PERIODO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-PCFRADIC     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCFRADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PRAZOSEG     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TAPR_PRAZOSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TAPR-DESCIDAD     PIC  X(001).*/
        public StringBasis V1TAPR_DESCIDAD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1TAPR-TCFAPLPR     PIC S9(002)V9(3) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TCFAPLPR { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V1TAPR-TPCDSFRF     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCDSFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-TPCDSBAU     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCDSBAU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-TTXAPLIS     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TTXAPLIS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-TPCPZSEG     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCPZSEG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TAPR-TPRBRCDM     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPRBRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-TCFPBRDM     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TCFPBRDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TPRBRCDP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPRBRCDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TCFPBRDP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TCFPBRDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TPCBONDM     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCBONDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TPCBONDP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCBONDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TTXAPPM      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TTXAPPM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TTXAPPI      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TTXAPPI { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TTXAPPA      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TTXAPPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TTXAPPD      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TTXAPPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TPCDSAPP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCDSAPP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-DATEND       PIC  X(010).*/
        public StringBasis V1TAPR_DATEND { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1TAPR-TPCMAJOR     PIC S9(003)V9(4) VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCMAJOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77         V1TAPR-PCDESAUT     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESAUT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCDESRCF     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESRCF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCDESAPP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESAPP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCDESPLCA    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESPLCA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCDESPLRF    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESPLRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCDESPLAP    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESPLAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCAGPLRF     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCAGPLRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCAGPLAP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCAGPLAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCDESACE     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCDESACE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-PCAGISCASC   PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_PCAGISCASC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-VALOR-AVARIA PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_VALOR_AVARIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TAPR-TPCBONDMO    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TPCBONDMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-TCFPBRDMO    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TAPR_TCFPBRDMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TAPR-IND-COML     PIC  X(001)      VALUE SPACE.*/
        public StringBasis V1TAPR_IND_COML { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1TAPR-PCT-COML     PIC S9(003)v99   VALUE +0  COMP-3*/
        public IntBasis V1TAPR_PCT_COML { get; set; } = new IntBasis(new PIC("S9", "5", "S9(003)v99"));
        /*"77         V1TAPR-CODUSU       PIC  X(008)      VALUE SPACES.*/
        public StringBasis V1TAPR_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V1TAPR-IND-VLR-MIN  PIC  X(001)      VALUE SPACE.*/
        public StringBasis V1TAPR_IND_VLR_MIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0TARI-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0TARI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0TARI-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0TARI_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0TARI-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0TARI_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0TARI-DTINIVIG     PIC  X(010).*/
        public StringBasis V0TARI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0TARI-DTTERVIG     PIC  X(010).*/
        public StringBasis V0TARI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0TARI-TERCEIXO     PIC  X(001).*/
        public StringBasis V0TARI_TERCEIXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0TARI-CATTARIF     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_CATTARIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-TIPOCOB      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_TIPOCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-REGIAO       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-FRANQFAC     PIC  X(001).*/
        public StringBasis V0TARI_FRANQFAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0TARI-CLABONAT     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_CLABONAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-PCDESCAT     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESCAT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-CLABONDM     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_CLABONDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-CLABONDP     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_CLABONDP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-CATTARIR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_CATTARIR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-DESCFROT     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_DESCFROT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-NUMPASSG     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_NUMPASSG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-VRFROBR-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRFROBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-VRFRFACC-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRFRFACC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-VRFRFACA-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRFRFACA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-VRFRADIC-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRFRADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-VRPRREF      PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRPRREF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-CFFROBR      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_CFFROBR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-CFFRFACC     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_CFFRFACC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-CFFRFACA     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_CFFRFACA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-CFPRREF      PIC S9(002)V9(3) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_CFPRREF { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V0TARI-PCDSCFRF     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDSCFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-PCISCASC     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCISCASC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-PCINCROU     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCINCROU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-PCAGPLCA     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCAGPLCA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-PCAGPLAC     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCAGPLAC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-VRPRRFDM     PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRPRRFDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0TARI-VRPRRFDP     PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VRPRRFDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0TARI-EXTPER       PIC  X(001).*/
        public StringBasis V0TARI_EXTPER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0TARI-PERIODO      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_PERIODO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-PCFRADIC     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCFRADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PRAZOSEG     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0TARI_PRAZOSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0TARI-DESCIDAD     PIC  X(001).*/
        public StringBasis V0TARI_DESCIDAD { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0TARI-TCFAPLPR     PIC S9(002)V9(3) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TCFAPLPR { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V0TARI-TPCDSFRF     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCDSFRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-TPCDSBAU     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCDSBAU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-TTXAPLIS     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TTXAPLIS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-TPCPZSEG     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCPZSEG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0TARI-TPRBRCDM     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPRBRCDM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-TCFPBRDM     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TCFPBRDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TPRBRCDP     PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPRBRCDP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0TARI-TCFPBRDP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TCFPBRDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TPCBONDM     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCBONDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TPCBONDP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCBONDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TTXAPPM      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TTXAPPM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TTXAPPI      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TTXAPPI { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TTXAPPA      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TTXAPPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TTXAPPD      PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TTXAPPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TPCDSAPP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCDSAPP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-DATEND       PIC  X(010).*/
        public StringBasis V0TARI_DATEND { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0TARI-TPCMAJOR     PIC S9(003)V9(4) VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCMAJOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77         V0TARI-PCDESAUT     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESAUT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCDESRCF     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESRCF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCDESAPP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESAPP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCDESPLCA    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESPLCA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCDESPLRF    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESPLRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCDESPLAP    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESPLAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCAGPLRF     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCAGPLRF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCAGPLAP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCAGPLAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-PCDESACE     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCDESACE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0TARI_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0TARI-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0TARI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0TARI-PCAGISCASC   PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_PCAGISCASC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-VALOR-AVARIA PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_VALOR_AVARIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0TARI-TPCBONDMO    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TPCBONDMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-TCFPBRDMO    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0TARI_TCFPBRDMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0TARI-IND-COML     PIC  X(001)      VALUE SPACE.*/
        public StringBasis V0TARI_IND_COML { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0TARI-PCT-COML     PIC S9(003)v99   VALUE +0  COMP-3*/
        public IntBasis V0TARI_PCT_COML { get; set; } = new IntBasis(new PIC("S9", "5", "S9(003)v99"));
        /*"77         V0TARI-CODUSU       PIC  X(008)      VALUE SPACES.*/
        public StringBasis V0TARI_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V0TARI-IND-VLR-MIN  PIC  X(001)      VALUE SPACE.*/
        public StringBasis V0TARI_IND_VLR_MIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1AUCP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUCP-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCP-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUCP-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUCP-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCP-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCP-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCP_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1AUCP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUCP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1AUCP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUCP-IMP-SEG-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1AUCP_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1AUCP-IMP-SEG-VR   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1AUCP_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1AUCP-TAXA-IS      PIC S9(002)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCP_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(5)"), 5);
        /*"77         V1AUCP-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCP_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1AUCP-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1AUCP-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCP_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1AUCP-SITUACAO     PIC  X(001).*/
        public StringBasis V1AUCP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUCB-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUCB-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUCB-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUCB-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0AUCB-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUCB-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUCB-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0AUCB-DTINIVIG     PIC  X(010).*/
        public StringBasis V0AUCB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0AUCB-DTTERVIG     PIC  X(010).*/
        public StringBasis V0AUCB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0AUCB-IMP-SEG-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0AUCB_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0AUCB-IMP-SEG-VR   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0AUCB_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0AUCB-TAXA-IS      PIC S9(002)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0AUCB_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(5)"), 5);
        /*"77         V0AUCB-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0AUCB_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0AUCB-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0AUCB_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0AUCB-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0AUCB_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0AUCB-SITUACAO     PIC  X(001).*/
        public StringBasis V0AUCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0AUCB-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0AUCB_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0AUCB-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0AUCB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-COD-COBERT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_COD_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCL-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-CODCLAUS     PIC  X(008).*/
        public StringBasis V1PRCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1PRCL-LIM-IND-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1PRCL_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRCL-TIPOCLAU     PIC  X(001).*/
        public StringBasis V1PRCL_TIPOCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRCL-TPMOVTO      PIC  X(001).*/
        public StringBasis V1PRCL_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCL-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0APCL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCL-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-COD-COBERT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_COD_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCL-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-CODCLAUS     PIC  X(003).*/
        public StringBasis V0APCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0APCL-TIPOCLAU     PIC  X(001).*/
        public StringBasis V0APCL_TIPOCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCL-LIM-IND-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APCL_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRAC-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAC-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRAC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRAC-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRAC_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRAC-CDACESS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRAC_CDACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAC-VRACESS      PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_VRACESS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRAC-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRAC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRAC-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRAC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRAC-VRPLACES     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_VRPLACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRAC-VRPAACES     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_VRPAACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRAC-VRPLAACE     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_VRPLAACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRAC-VRPRBACE     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_VRPRBACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRAC-TPMOVTO      PIC  X(001).*/
        public StringBasis V1PRAC_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRAC-TTXISACE     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_TTXISACE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PRAC-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1PRAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRAC-IDEACESS     PIC  X(001).*/
        public StringBasis V1PRAC_IDEACESS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APAC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0APAC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APAC-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APAC_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APAC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APAC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APAC-CDACESS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APAC_CDACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APAC-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APAC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APAC-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APAC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APAC-VRACESS      PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_VRACESS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APAC-VRPLACES     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_VRPLACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APAC-VRPAACES     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_VRPAACES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APAC-VRPLAACE     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_VRPLAACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APAC-VRPRBACE     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_VRPRBACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APAC-TTXISACE     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_TTXISACE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0APAC-TPMOVTO      PIC  X(001).*/
        public StringBasis V0APAC_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APAC-OTNACE       PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_OTNACE { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APAC-PREACEBT     PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APAC_PREACEBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APAC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APAC-IDEACESS     PIC  X(001).*/
        public StringBasis V0APAC_IDEACESS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBP-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-NUM-ITEM     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBP-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBP-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBP-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBP-DAT-INIVIG   PIC  X(010).*/
        public StringBasis V1COBP_DAT_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-DAT-TERVIG   PIC  X(010).*/
        public StringBasis V1COBP_DAT_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-ITEM     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PCT-COBERT   PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0COBA-FATOR-MULT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-SITUACAO     PIC  X(001).*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COBA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COBA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-NUM-ITEM     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-COD-COBER    PIC S9(004)                COMP.*/
        public IntBasis V1COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-PCT-COBERT   PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COBA-FATOR-MULT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V1COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V1COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-CODRELAT     PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0EDIA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0EDIA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-DTMOVTO      PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0EDIA-ORGAO        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-RAMO         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CONGENER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-SITUACAO     PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0EDIA-COD-EMPRESA  PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public EM0910S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0910S_AREA_DE_WORK();
        public class EM0910S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WFIM-V1AUTOPROP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AUTOPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1AUTARIPROP PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AUTARIPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1AUTCOBPROP PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AUTCOBPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCLAU   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPACES   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPACES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-AUPROPCOMP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_AUPROPCOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERAPOL  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERPROP  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COBERPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         CH-I-V0COBERAPOL  PIC  X(001)    VALUE SPACES.*/
            public StringBasis CH_I_V0COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WCH-ULTENDO       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WCH_ULTENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         CH-COBER-ATU.*/
            public EM0910S_CH_COBER_ATU CH_COBER_ATU { get; set; } = new EM0910S_CH_COBER_ATU();
            public class EM0910S_CH_COBER_ATU : VarBasis
            {
                /*"    10       CH-FONT-ATU       PIC  9(004) VALUE  0.*/
                public IntBasis CH_FONT_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       CH-PROP-ATU       PIC  9(009) VALUE  0.*/
                public IntBasis CH_PROP_ATU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    10       CH-RAMO-ATU       PIC  9(004) VALUE  0.*/
                public IntBasis CH_RAMO_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         CH-COBER-ANT.*/
            }
            public EM0910S_CH_COBER_ANT CH_COBER_ANT { get; set; } = new EM0910S_CH_COBER_ANT();
            public class EM0910S_CH_COBER_ANT : VarBasis
            {
                /*"    10       CH-FONT-ANT       PIC  9(004) VALUE  0.*/
                public IntBasis CH_FONT_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       CH-PROP-ANT       PIC  9(009) VALUE  0.*/
                public IntBasis CH_PROP_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    10       CH-RAMO-ANT       PIC  9(004) VALUE  0.*/
                public IntBasis CH_RAMO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05            AC-S-PROPACESS     PIC  9(004)  VALUE ZEROS.*/
            }
            public IntBasis AC_S_PROPACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-APOLACESS     PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-PROPCLAU      PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-APOLCLAU      PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-AUTOPROP      PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-AUTOAPOL      PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-AUTOCOBERP    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-AUTOCOBER     PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-AUTOTARIFP    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-AUTOTARIFA    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-COBERAPOL     PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-COBERPROP     PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_COBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-EMISDIARIA    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-S-AUPROPCOMP    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_S_AUPROPCOMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05            AC-I-AUAPOLCOMP    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AC_I_AUAPOLCOMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        WABEND.*/
            public EM0910S_WABEND WABEND { get; set; } = new EM0910S_WABEND();
            public class EM0910S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0910S'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0910S");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05        WSQLERRO.*/
            }
            public EM0910S_WSQLERRO WSQLERRO { get; set; } = new EM0910S_WSQLERRO();
            public class EM0910S_WSQLERRO : VarBasis
            {
                /*"    10      FILLER              PIC  X(014)     VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    10      WSQLERRMC           PIC  X(070)     VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01         LK-NUM-PLANO            PIC S9(4)      USAGE COMP.*/
            }
        }
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-SERIE            PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-TITULO           PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01         LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01         LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01         LK-EMP-PARCEIRA         PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_EMP_PARCEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-COD-RAMO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-COD-USUARIO          PIC  X(8).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01         LK-NUM-NSA              PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88       LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01         LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01               LK-PROPOSTA.*/
        public EM0910S_LK_PROPOSTA LK_PROPOSTA { get; set; } = new EM0910S_LK_PROPOSTA();
        public class EM0910S_LK_PROPOSTA : VarBasis
        {
            /*"  05             LK-FONTE            PIC S9(004)          COMP.*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-NRPROPOS         PIC S9(009)          COMP.*/
            public IntBasis LK_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-NUM-APOL         PIC S9(013)          COMP-3*/
            public IntBasis LK_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05             LK-NRENDOS          PIC S9(009)          COMP.*/
            public IntBasis LK_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-DTMOVABE         PIC  X(010).*/
            public StringBasis LK_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05             LK-CODCORR          PIC S9(009)          COMP.*/
            public IntBasis LK_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05             LK-RETORNO          PIC  X(070).*/
            public StringBasis LK_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05             LK-CODPRODU         PIC S9(004)          COMP.*/
            public IntBasis LK_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-QT-PARCEL        PIC S9(004)          COMP.*/
            public IntBasis LK_QT_PARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05             LK-VL-PARCEL        PIC S9(013)V99       COMP-3*/
            public DoubleBasis LK_VL_PARCEL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05             LK-S-PROPACESS      PIC  9(004).*/
            public IntBasis LK_S_PROPACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-APOLACESS      PIC  9(004).*/
            public IntBasis LK_I_APOLACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-PROPCLAU       PIC  9(004).*/
            public IntBasis LK_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-APOLCLAU       PIC  9(004).*/
            public IntBasis LK_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-AUTOPROP       PIC  9(004).*/
            public IntBasis LK_S_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-AUTOAPOL       PIC  9(004).*/
            public IntBasis LK_I_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-AUTOCOBERP     PIC  9(004).*/
            public IntBasis LK_S_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-AUTOCOBER      PIC  9(004).*/
            public IntBasis LK_I_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-AUTOTARIFP     PIC  9(004).*/
            public IntBasis LK_S_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-AUTOTARIFA     PIC  9(004).*/
            public IntBasis LK_I_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-COBERPROP      PIC  9(004).*/
            public IntBasis LK_S_COBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-COBERAPOL      PIC  9(004).*/
            public IntBasis LK_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-EMISDIARIA     PIC  9(004).*/
            public IntBasis LK_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-S-AUPROPCOMP     PIC  9(004).*/
            public IntBasis LK_S_AUPROPCOMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05             LK-I-AUAPOLCOMP     PIC  9(004).*/
            public IntBasis LK_I_AUAPOLCOMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }


        public Copies.LBLT3159 LBLT3159 { get; set; } = new Copies.LBLT3159();
        public Dclgens.AU084 AU084 { get; set; } = new Dclgens.AU084();
        public Dclgens.AU085 AU085 { get; set; } = new Dclgens.AU085();
        public Dclgens.AU050 AU050 { get; set; } = new Dclgens.AU050();
        public Dclgens.AU055 AU055 { get; set; } = new Dclgens.AU055();
        public Dclgens.AU057 AU057 { get; set; } = new Dclgens.AU057();
        public Dclgens.V1ENDOSS V1ENDOSS { get; set; } = new Dclgens.V1ENDOSS();
        public EM0910S_V1AUTOPROP V1AUTOPROP { get; set; } = new EM0910S_V1AUTOPROP();
        public EM0910S_V1AUTARIPROP V1AUTARIPROP { get; set; } = new EM0910S_V1AUTARIPROP();
        public EM0910S_V1AUTCOBPROP V1AUTCOBPROP { get; set; } = new EM0910S_V1AUTCOBPROP();
        public EM0910S_V1PROPACES V1PROPACES { get; set; } = new EM0910S_V1PROPACES();
        public EM0910S_V1PROPCLAU V1PROPCLAU { get; set; } = new EM0910S_V1PROPCLAU();
        public EM0910S_AUPROPCOMPL AUPROPCOMPL { get; set; } = new EM0910S_AUPROPCOMPL();
        public EM0910S_V1COBERPROP V1COBERPROP { get; set; } = new EM0910S_V1COBERPROP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0910S_LK_PROPOSTA EM0910S_LK_PROPOSTA_P) //PROCEDURE DIVISION USING 
        /*LK_PROPOSTA*/
        {
            try
            {
                this.LK_PROPOSTA = EM0910S_LK_PROPOSTA_P;

                /*" -917- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -918- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -921- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -924- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -924- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PROPOSTA, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -948- MOVE ZEROS TO AC-S-PROPACESS AC-I-APOLACESS AC-S-PROPCLAU AC-I-APOLCLAU AC-S-AUTOPROP AC-I-AUTOAPOL AC-S-AUTOCOBERP AC-I-AUTOCOBER AC-S-AUTOTARIFP AC-I-AUTOTARIFA AC-S-COBERPROP AC-I-COBERAPOL AC-S-AUPROPCOMP AC-I-AUAPOLCOMP AC-I-EMISDIARIA. */
            _.Move(0, AREA_DE_WORK.AC_S_PROPACESS, AREA_DE_WORK.AC_I_APOLACESS, AREA_DE_WORK.AC_S_PROPCLAU, AREA_DE_WORK.AC_I_APOLCLAU, AREA_DE_WORK.AC_S_AUTOPROP, AREA_DE_WORK.AC_I_AUTOAPOL, AREA_DE_WORK.AC_S_AUTOCOBERP, AREA_DE_WORK.AC_I_AUTOCOBER, AREA_DE_WORK.AC_S_AUTOTARIFP, AREA_DE_WORK.AC_I_AUTOTARIFA, AREA_DE_WORK.AC_S_COBERPROP, AREA_DE_WORK.AC_I_COBERAPOL, AREA_DE_WORK.AC_S_AUPROPCOMP, AREA_DE_WORK.AC_I_AUAPOLCOMP, AREA_DE_WORK.AC_I_EMISDIARIA);

            /*" -949- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -950- DISPLAY ' V.06                              ' */
            _.Display($" V.06                              ");

            /*" -952- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -953- IF LK-CODPRODU EQUAL 99 */

            if (LK_PROPOSTA.LK_CODPRODU == 99)
            {

                /*" -955- GO TO R0000-90-FINAL. */

                R0000_90_FINAL(); //GOTO
                return;
            }


            /*" -957- MOVE 5631 TO WHOST-CONGENERE */
            _.Move(5631, WHOST_CONGENERE);

            /*" -958- MOVE LK-FONTE TO WHOST-FONTE */
            _.Move(LK_PROPOSTA.LK_FONTE, WHOST_FONTE);

            /*" -959- MOVE LK-NRPROPOS TO WHOST-NRPROPOS */
            _.Move(LK_PROPOSTA.LK_NRPROPOS, WHOST_NRPROPOS);

            /*" -960- MOVE LK-NUM-APOL TO WHOST-NUM-APOL */
            _.Move(LK_PROPOSTA.LK_NUM_APOL, WHOST_NUM_APOL);

            /*" -961- MOVE LK-NRENDOS TO WHOST-NRENDOS */
            _.Move(LK_PROPOSTA.LK_NRENDOS, WHOST_NRENDOS);

            /*" -962- MOVE LK-DTMOVABE TO WHOST-DTMOVABE */
            _.Move(LK_PROPOSTA.LK_DTMOVABE, WHOST_DTMOVABE);

            /*" -963- MOVE LK-CODCORR TO WHOST-CODCORR */
            _.Move(LK_PROPOSTA.LK_CODCORR, WHOST_CODCORR);

            /*" -964- MOVE LK-QT-PARCEL TO WHOST-QT-PARCEL */
            _.Move(LK_PROPOSTA.LK_QT_PARCEL, WHOST_QT_PARCEL);

            /*" -966- MOVE LK-VL-PARCEL TO WHOST-VL-PARCEL */
            _.Move(LK_PROPOSTA.LK_VL_PARCEL, WHOST_VL_PARCEL);

            /*" -968- PERFORM R1000-00-PROCESSA-REGISTRO. */

            R1000_00_PROCESSA_REGISTRO_SECTION();

            /*" -968- PERFORM R7000-00-ATUALIZA-HISTORICO. */

            R7000_00_ATUALIZA_HISTORICO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINAL */

            R0000_90_FINAL();

        }

        [StopWatch]
        /*" R0000-90-FINAL */
        private void R0000_90_FINAL(bool isPerform = false)
        {
            /*" -973- MOVE AC-S-PROPACESS TO LK-S-PROPACESS */
            _.Move(AREA_DE_WORK.AC_S_PROPACESS, LK_PROPOSTA.LK_S_PROPACESS);

            /*" -974- MOVE AC-I-APOLACESS TO LK-I-APOLACESS */
            _.Move(AREA_DE_WORK.AC_I_APOLACESS, LK_PROPOSTA.LK_I_APOLACESS);

            /*" -975- MOVE AC-S-PROPCLAU TO LK-S-PROPCLAU */
            _.Move(AREA_DE_WORK.AC_S_PROPCLAU, LK_PROPOSTA.LK_S_PROPCLAU);

            /*" -976- MOVE AC-I-APOLCLAU TO LK-I-APOLCLAU */
            _.Move(AREA_DE_WORK.AC_I_APOLCLAU, LK_PROPOSTA.LK_I_APOLCLAU);

            /*" -977- MOVE AC-S-AUTOPROP TO LK-S-AUTOPROP */
            _.Move(AREA_DE_WORK.AC_S_AUTOPROP, LK_PROPOSTA.LK_S_AUTOPROP);

            /*" -978- MOVE AC-I-AUTOAPOL TO LK-I-AUTOAPOL */
            _.Move(AREA_DE_WORK.AC_I_AUTOAPOL, LK_PROPOSTA.LK_I_AUTOAPOL);

            /*" -979- MOVE AC-S-AUTOCOBERP TO LK-S-AUTOCOBERP */
            _.Move(AREA_DE_WORK.AC_S_AUTOCOBERP, LK_PROPOSTA.LK_S_AUTOCOBERP);

            /*" -980- MOVE AC-I-AUTOCOBER TO LK-I-AUTOCOBER */
            _.Move(AREA_DE_WORK.AC_I_AUTOCOBER, LK_PROPOSTA.LK_I_AUTOCOBER);

            /*" -981- MOVE AC-S-AUTOTARIFP TO LK-S-AUTOTARIFP */
            _.Move(AREA_DE_WORK.AC_S_AUTOTARIFP, LK_PROPOSTA.LK_S_AUTOTARIFP);

            /*" -982- MOVE AC-I-AUTOTARIFA TO LK-I-AUTOTARIFA */
            _.Move(AREA_DE_WORK.AC_I_AUTOTARIFA, LK_PROPOSTA.LK_I_AUTOTARIFA);

            /*" -983- MOVE AC-S-COBERPROP TO LK-S-COBERPROP */
            _.Move(AREA_DE_WORK.AC_S_COBERPROP, LK_PROPOSTA.LK_S_COBERPROP);

            /*" -984- MOVE AC-I-COBERAPOL TO LK-I-COBERAPOL */
            _.Move(AREA_DE_WORK.AC_I_COBERAPOL, LK_PROPOSTA.LK_I_COBERAPOL);

            /*" -986- MOVE AC-I-EMISDIARIA TO LK-I-EMISDIARIA */
            _.Move(AREA_DE_WORK.AC_I_EMISDIARIA, LK_PROPOSTA.LK_I_EMISDIARIA);

            /*" -988- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -988- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-V1SISTEMA-SECTION */
        private void R0900_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1002- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1007- PERFORM R0900_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0900_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1010- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1012- DISPLAY 'R0900- SISTEMA EM NAO CADASTRADO' ' SQLCODE :' SQLCODE */

                $"R0900- SISTEMA EM NAO CADASTRADO SQLCODE :{DB.SQLCODE}"
                .Display();

                /*" -1013- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1013- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0900_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1007- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1022- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1024- PERFORM R0900-00-SELECT-V1SISTEMA */

            R0900_00_SELECT_V1SISTEMA_SECTION();

            /*" -1026- PERFORM R1100-00-SELECT-V1ENDOSSO */

            R1100_00_SELECT_V1ENDOSSO_SECTION();

            /*" -1027- PERFORM R2100-00-DECLARE-V1AUTOPROP */

            R2100_00_DECLARE_V1AUTOPROP_SECTION();

            /*" -1028- MOVE SPACES TO WFIM-V1AUTOPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1AUTOPROP);

            /*" -1031- PERFORM R2110-00-INCLUI-V0AUTOAPOL UNTIL WFIM-V1AUTOPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1AUTOPROP.IsEmpty()))
            {

                R2110_00_INCLUI_V0AUTOAPOL_SECTION();
            }

            /*" -1032- PERFORM R2200-00-DECLARE-V1AUTARIPROP */

            R2200_00_DECLARE_V1AUTARIPROP_SECTION();

            /*" -1033- MOVE SPACES TO WFIM-V1AUTARIPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1AUTARIPROP);

            /*" -1036- PERFORM R2210-00-INCLUI-V0AUTOTARIFA UNTIL WFIM-V1AUTARIPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1AUTARIPROP.IsEmpty()))
            {

                R2210_00_INCLUI_V0AUTOTARIFA_SECTION();
            }

            /*" -1037- PERFORM R2300-00-DECLARE-V1AUTCOBPROP */

            R2300_00_DECLARE_V1AUTCOBPROP_SECTION();

            /*" -1038- MOVE SPACES TO WFIM-V1AUTCOBPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1AUTCOBPROP);

            /*" -1041- PERFORM R2310-00-INCLUI-V0AUTOCOBER UNTIL WFIM-V1AUTCOBPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1AUTCOBPROP.IsEmpty()))
            {

                R2310_00_INCLUI_V0AUTOCOBER_SECTION();
            }

            /*" -1042- PERFORM R2400-00-DECLARE-V1PROPACES */

            R2400_00_DECLARE_V1PROPACES_SECTION();

            /*" -1043- MOVE SPACES TO WFIM-V1PROPACES */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPACES);

            /*" -1046- PERFORM R2410-00-INCLUI-V0APOLACES UNTIL WFIM-V1PROPACES NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1PROPACES.IsEmpty()))
            {

                R2410_00_INCLUI_V0APOLACES_SECTION();
            }

            /*" -1047- PERFORM R2500-00-DECLARE-V1PROPCLAU */

            R2500_00_DECLARE_V1PROPCLAU_SECTION();

            /*" -1048- MOVE SPACES TO WFIM-V1PROPCLAU */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPCLAU);

            /*" -1051- PERFORM R2510-00-INCLUI-V0APOLCLAU UNTIL WFIM-V1PROPCLAU NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1PROPCLAU.IsEmpty()))
            {

                R2510_00_INCLUI_V0APOLCLAU_SECTION();
            }

            /*" -1052- PERFORM R2600-00-DECLARE-AUPROPCOMPL */

            R2600_00_DECLARE_AUPROPCOMPL_SECTION();

            /*" -1053- MOVE SPACES TO WFIM-AUPROPCOMP */
            _.Move("", AREA_DE_WORK.WFIM_AUPROPCOMP);

            /*" -1056- PERFORM R2610-00-INCLUI-AUAPOLCOMPL UNTIL WFIM-AUPROPCOMP NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_AUPROPCOMP.IsEmpty()))
            {

                R2610_00_INCLUI_AUAPOLCOMPL_SECTION();
            }

            /*" -1058- IF V1ENDO-CODPRODU EQUAL 3101 OR 3102 OR 3105 NEXT SENTENCE */

            if (V1ENDO_CODPRODU.In("3101", "3102", "3105"))
            {

                /*" -1059- ELSE */
            }
            else
            {


                /*" -1061- PERFORM R3000-00-MONTA-V0EMISDIARIA. */

                R3000_00_MONTA_V0EMISDIARIA_SECTION();
            }


            /*" -1063- PERFORM R4000-00-TRATAMENTO-COBERAPOL. */

            R4000_00_TRATAMENTO_COBERAPOL_SECTION();

            /*" -1068- IF (( V1ENDO-TIPO-ENDO EQUAL '0' OR '1' ) AND ( V1ENDO-ORGAO EQUAL 10 ) AND ( V1ENDO-RAMO EQUAL 53 ) AND ( V1ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 )) */

            if (((V1ENDO_TIPO_ENDO.In("0", "1")) && (V1ENDO_ORGAO == 10) && (V1ENDO_RAMO == 53) && (V1ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -1069- PERFORM R5500-00-LER-PARAMETROS */

                R5500_00_LER_PARAMETROS_SECTION();

                /*" -1070- PERFORM R6000-00-CAPITALIZACAO */

                R6000_00_CAPITALIZACAO_SECTION();

                /*" -1070- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-SECTION */
        private void R1100_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -1084- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1106- PERFORM R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -1109- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1111- MOVE 'V1ENDOSSO (DOCUMENTO NAO CADASTRADO)' TO LK-RETORNO */
                _.Move("V1ENDOSSO (DOCUMENTO NAO CADASTRADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1113- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1114- IF VIND-CODPRODU LESS ZEROS */

            if (VIND_CODPRODU < 00)
            {

                /*" -1114- MOVE ZEROS TO V1ENDO-CODPRODU. */
                _.Move(0, V1ENDO_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -1106- EXEC SQL SELECT ORGAO, RAMO, FONTE, NRPROPOS, COD_MOEDA_PRM, COD_MOEDA_IMP, TIPO_ENDOSSO , TIPAPO , CODPRODU INTO :V1ENDO-ORGAO, :V1ENDO-RAMO, :V1ENDO-FONTE, :V1ENDO-NRPROPOS, :V1ENDO-MOEDA-PRM, :V1ENDO-MOEDA-IMP, :V1ENDO-TIPO-ENDO, :V1ENDO-TIPAPO , :V1ENDO-CODPRODU:VIND-CODPRODU FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :WHOST-NUM-APOL AND NRENDOS = :WHOST-NRENDOS END-EXEC. */

            var r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                WHOST_NRENDOS = WHOST_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_ORGAO, V1ENDO_ORGAO);
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_FONTE, V1ENDO_FONTE);
                _.Move(executed_1.V1ENDO_NRPROPOS, V1ENDO_NRPROPOS);
                _.Move(executed_1.V1ENDO_MOEDA_PRM, V1ENDO_MOEDA_PRM);
                _.Move(executed_1.V1ENDO_MOEDA_IMP, V1ENDO_MOEDA_IMP);
                _.Move(executed_1.V1ENDO_TIPO_ENDO, V1ENDO_TIPO_ENDO);
                _.Move(executed_1.V1ENDO_TIPAPO, V1ENDO_TIPAPO);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1MOEDA-SECTION */
        private void R1200_00_SELECT_V1MOEDA_SECTION()
        {
            /*" -1128- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1135- PERFORM R1200_00_SELECT_V1MOEDA_DB_SELECT_1 */

            R1200_00_SELECT_V1MOEDA_DB_SELECT_1();

            /*" -1138- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1140- MOVE 'V1MOEDA (NAO EXISTE COTACAO)' TO LK-RETORNO */
                _.Move("V1MOEDA (NAO EXISTE COTACAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1142- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1143- IF WHOST-VLCRUZAD NOT NUMERIC */

            if (!WHOST_VLCRUZAD.IsNumeric())
            {

                /*" -1145- MOVE 'V1MOEDA (COTACAO INVALIDA)  ' TO LK-RETORNO */
                _.Move("V1MOEDA (COTACAO INVALIDA)  ", LK_PROPOSTA.LK_RETORNO);

                /*" -1147- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1148- IF WHOST-VLCRUZAD EQUAL ZEROS */

            if (WHOST_VLCRUZAD == 00)
            {

                /*" -1150- MOVE 'V1MOEDA (COTACAO INVALIDA)  ' TO LK-RETORNO */
                _.Move("V1MOEDA (COTACAO INVALIDA)  ", LK_PROPOSTA.LK_RETORNO);

                /*" -1150- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V1MOEDA-DB-SELECT-1 */
        public void R1200_00_SELECT_V1MOEDA_DB_SELECT_1()
        {
            /*" -1135- EXEC SQL SELECT VLCRUZAD INTO :WHOST-VLCRUZAD FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WHOST-COD-MOEDA AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG END-EXEC. */

            var r1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1()
            {
                WHOST_COD_MOEDA = WHOST_COD_MOEDA.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLCRUZAD, WHOST_VLCRUZAD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-V1AUTOPROP-SECTION */
        private void R2100_00_DECLARE_V1AUTOPROP_SECTION()
        {
            /*" -1164- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1220- PERFORM R2100_00_DECLARE_V1AUTOPROP_DB_DECLARE_1 */

            R2100_00_DECLARE_V1AUTOPROP_DB_DECLARE_1();

            /*" -1222- PERFORM R2100_00_DECLARE_V1AUTOPROP_DB_OPEN_1 */

            R2100_00_DECLARE_V1AUTOPROP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1AUTOPROP-DB-DECLARE-1 */
        public void R2100_00_DECLARE_V1AUTOPROP_DB_DECLARE_1()
        {
            /*" -1220- EXEC SQL DECLARE V1AUTOPROP CURSOR FOR SELECT COD_EMPRESA, FONTE , NRPROPOS , NRITEM , DTINIVIG , DTTERVIG , TIPOVEIC , FABRICAN , CDVEICL , COMBUST , ANOVEICL , ANOMOD , CORVEICL , CAPACID , LOTACAO , PLACAUF , PLACALET , PLACANR , CHASSIS , UTILIZA , QTACESS , DTBAIXA , CDVISTOR , PROPRIET , DTIVEXTP , ACEITE , NRPRRESS , PROTSINI , SITUACAO , CODCLIEN , TPMOVTO , ZEROKM , SEGBONUS , FIDEL_AUTO , FIDEL_VIDA , FIDEL_PREV , DANOS_MORAIS , SEG_MERC_DET , ADIC_VLR_MERCADO , PERFIL , DESPEXTR , VLNOVO , CODDESPEXTR, DESPEXTR_PT, PERC_VARIACAO_IS, CANAL_PROPOSTA, TIPO_COBRANCA, NUM_PROPOSTA_CONV, NUM_CERTIFICADO, NUM_RENAVAM, IND_USO_VEICULO FROM SEGUROS.V1AUTOPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY NRITEM END-EXEC. */
            V1AUTOPROP = new EM0910S_V1AUTOPROP(true);
            string GetQuery_V1AUTOPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRITEM
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							TIPOVEIC
							, 
							FABRICAN
							, 
							CDVEICL
							, 
							COMBUST
							, 
							ANOVEICL
							, 
							ANOMOD
							, 
							CORVEICL
							, 
							CAPACID
							, 
							LOTACAO
							, 
							PLACAUF
							, 
							PLACALET
							, 
							PLACANR
							, 
							CHASSIS
							, 
							UTILIZA
							, 
							QTACESS
							, 
							DTBAIXA
							, 
							CDVISTOR
							, 
							PROPRIET
							, 
							DTIVEXTP
							, 
							ACEITE
							, 
							NRPRRESS
							, 
							PROTSINI
							, 
							SITUACAO
							, 
							CODCLIEN
							, 
							TPMOVTO
							, 
							ZEROKM
							, 
							SEGBONUS
							, 
							FIDEL_AUTO
							, 
							FIDEL_VIDA
							, 
							FIDEL_PREV
							, 
							DANOS_MORAIS
							, 
							SEG_MERC_DET
							, 
							ADIC_VLR_MERCADO
							, 
							PERFIL
							, 
							DESPEXTR
							, 
							VLNOVO
							, 
							CODDESPEXTR
							, 
							DESPEXTR_PT
							, 
							PERC_VARIACAO_IS
							, 
							CANAL_PROPOSTA
							, 
							TIPO_COBRANCA
							, 
							NUM_PROPOSTA_CONV
							, 
							NUM_CERTIFICADO
							, 
							NUM_RENAVAM
							, 
							IND_USO_VEICULO 
							FROM SEGUROS.V1AUTOPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY NRITEM";

                return query;
            }
            V1AUTOPROP.GetQueryEvent += GetQuery_V1AUTOPROP;

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1AUTOPROP-DB-OPEN-1 */
        public void R2100_00_DECLARE_V1AUTOPROP_DB_OPEN_1()
        {
            /*" -1222- EXEC SQL OPEN V1AUTOPROP END-EXEC. */

            V1AUTOPROP.Open();

        }

        [StopWatch]
        /*" R2200-00-DECLARE-V1AUTARIPROP-DB-DECLARE-1 */
        public void R2200_00_DECLARE_V1AUTARIPROP_DB_DECLARE_1()
        {
            /*" -1710- EXEC SQL DECLARE V1AUTARIPROP CURSOR FOR SELECT COD_EMPRESA, FONTE , NRPROPOS , NRITEM , DTINIVIG , DTTERVIG , TERCEIXO , CATTARIF , TIPOCOB , REGIAO , FRANQFAC , CLABONAT , PCDESCAT , CLABONDM , CLABONDP , CATTARIR , DESCFROT , NUMPASSG , VRFROBR_IX , VRFRFACC_IX, VRFRFACA_IX, VRFRADIC_IX, VRPRREF , CFFROBR , CFFRFACC , CFFRFACA , CFPRREF , PCDSCFRF , PCISCASC , PCINCROU , PCAGPLCA , PCAGPLAC , VRPRRFDM , VRPRRFDP , EXTPER , PERIODO , PCFRADIC , PRAZOSEG , DESCIDAD , TCFAPLPR , TPCDSFRF , TPCDSBAU , TTXAPLIS , TPCPZSEG , TPRBRCDM , TCFPBRDM , TPRBRCDP , TCFPBRDP , TPCBONDM , TPCBONDP , TTXAPPM , TTXAPPI , TTXAPPA , TTXAPPD , TPCDSAPP , DATEND , TPCMAJOR , PCDESAUT , PCDESRCF , PCDESAPP , PCDESPLCA , PCDESPLRF , PCDESPLAP , PCAGPLRF , PCAGPLAP , PCDESACE , PCAGISCASC , VALOR_AVARIA, TPCBONDMO , TCFPBRDMO , IND_COMERCIAL, PCT_COMERCIAL, COD_USUARIO , IND_VLR_MINIMO FROM SEGUROS.V1AUTOTARIPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY NRITEM END-EXEC. */
            V1AUTARIPROP = new EM0910S_V1AUTARIPROP(true);
            string GetQuery_V1AUTARIPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRITEM
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							TERCEIXO
							, 
							CATTARIF
							, 
							TIPOCOB
							, 
							REGIAO
							, 
							FRANQFAC
							, 
							CLABONAT
							, 
							PCDESCAT
							, 
							CLABONDM
							, 
							CLABONDP
							, 
							CATTARIR
							, 
							DESCFROT
							, 
							NUMPASSG
							, 
							VRFROBR_IX
							, 
							VRFRFACC_IX
							, 
							VRFRFACA_IX
							, 
							VRFRADIC_IX
							, 
							VRPRREF
							, 
							CFFROBR
							, 
							CFFRFACC
							, 
							CFFRFACA
							, 
							CFPRREF
							, 
							PCDSCFRF
							, 
							PCISCASC
							, 
							PCINCROU
							, 
							PCAGPLCA
							, 
							PCAGPLAC
							, 
							VRPRRFDM
							, 
							VRPRRFDP
							, 
							EXTPER
							, 
							PERIODO
							, 
							PCFRADIC
							, 
							PRAZOSEG
							, 
							DESCIDAD
							, 
							TCFAPLPR
							, 
							TPCDSFRF
							, 
							TPCDSBAU
							, 
							TTXAPLIS
							, 
							TPCPZSEG
							, 
							TPRBRCDM
							, 
							TCFPBRDM
							, 
							TPRBRCDP
							, 
							TCFPBRDP
							, 
							TPCBONDM
							, 
							TPCBONDP
							, 
							TTXAPPM
							, 
							TTXAPPI
							, 
							TTXAPPA
							, 
							TTXAPPD
							, 
							TPCDSAPP
							, 
							DATEND
							, 
							TPCMAJOR
							, 
							PCDESAUT
							, 
							PCDESRCF
							, 
							PCDESAPP
							, 
							PCDESPLCA
							, 
							PCDESPLRF
							, 
							PCDESPLAP
							, 
							PCAGPLRF
							, 
							PCAGPLAP
							, 
							PCDESACE
							, 
							PCAGISCASC
							, 
							VALOR_AVARIA
							, 
							TPCBONDMO
							, 
							TCFPBRDMO
							, 
							IND_COMERCIAL
							, 
							PCT_COMERCIAL
							, 
							COD_USUARIO
							, 
							IND_VLR_MINIMO 
							FROM SEGUROS.V1AUTOTARIPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY NRITEM";

                return query;
            }
            V1AUTARIPROP.GetQueryEvent += GetQuery_V1AUTARIPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-INCLUI-V0AUTOAPOL-SECTION */
        private void R2110_00_INCLUI_V0AUTOAPOL_SECTION()
        {
            /*" -1234- PERFORM R2120-00-FETCH-V1AUTOPROP */

            R2120_00_FETCH_V1AUTOPROP_SECTION();

            /*" -1235- IF WFIM-V1AUTOPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AUTOPROP.IsEmpty())
            {

                /*" -1237- GO TO R2110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1239- PERFORM R2130-00-MONTA-V0AUTOAPOL */

            R2130_00_MONTA_V0AUTOAPOL_SECTION();

            /*" -1305- MOVE '211' TO WNR-EXEC-SQL. */
            _.Move("211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1435- PERFORM R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1 */

            R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1();

            /*" -1438- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1440- MOVE 'V0AUTOAPOL (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0AUTOAPOL (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1442- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1443- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1445- MOVE 'V0AUTOAPOL (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0AUTOAPOL (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1447- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1447- ADD 1 TO AC-I-AUTOAPOL. */
            AREA_DE_WORK.AC_I_AUTOAPOL.Value = AREA_DE_WORK.AC_I_AUTOAPOL + 1;

        }

        [StopWatch]
        /*" R2110-00-INCLUI-V0AUTOAPOL-DB-INSERT-1 */
        public void R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1()
        {
            /*" -1435- EXEC SQL INSERT INTO SEGUROS.V0AUTOAPOL (COD_EMPRESA, FONTE , NRPROPOS , NRITEM , DTINIVIG , DTTERVIG , TIPOVEIC , FABRICAN , CDVEICL , COMBUST , ANOVEICL , ANOMOD , CORVEICL , CAPACID , LOTACAO , PLACAUF , PLACALET , PLACANR , CHASSIS , UTILIZA , QTACESS , DTBAIXA , CDVISTOR , PROPRIET , DTIVEXTP , ACEITE , NRPRRESS , PROTSINI , SITUACAO , CODCLIEN , NUM_APOLICE, NRENDOS , TIMESTAMP , TPMOVTO , ZEROKM , SEGBONUS , FIDEL_AUTO , FIDEL_VIDA , FIDEL_PREV , DANOS_MORAIS , SEG_MERC_DET , ADIC_VLR_MERCADO , PERFIL , DESPEXTR , VLNOVO, CODDESPEXTR, DESPEXTR_PT, PERC_VARIACAO_IS, CANAL_PROPOSTA, TIPO_COBRANCA, NUM_PROPOSTA_CONV, NUM_CERTIFICADO, NUM_RENAVAM, COD_CI , NUM_CONTRATO_CONV, NUM_RECIBO_CONV, COD_IDENT_PEP, IND_REL_CLI_PROPR , IND_USO_VEICULO , IND_ORIGEM_PROP , COD_CONGENERE , COD_CBO_CONV, COD_ATIVIDADE_CONV) VALUES (:V0AUTO-COD-EMPRESA, :V0AUTO-FONTE , :V0AUTO-NRPROPOS , :V0AUTO-NRITEM , :V0AUTO-DTINIVIG , :V0AUTO-DTTERVIG , :V0AUTO-TIPOVEIC , :V0AUTO-FABRICAN , :V0AUTO-CDVEICL , :V0AUTO-COMBUST , :V0AUTO-ANOVEICL , :V0AUTO-ANOMOD , :V0AUTO-CORVEICL , :V0AUTO-CAPACID , :V0AUTO-LOTACAO , :V0AUTO-PLACAUF , :V0AUTO-PLACALET , :V0AUTO-PLACANR , :V0AUTO-CHASSIS , :V0AUTO-UTILIZA , :V0AUTO-QTACESS , :V0AUTO-DTBAIXA , :V0AUTO-CDVISTOR , :V0AUTO-PROPRIET , :V0AUTO-DTIVEXTP , :V0AUTO-ACEITE , :V0AUTO-NRPRRESS , :V0AUTO-PROTSINI , :V0AUTO-SITUACAO , :V0AUTO-CODCLIEN , :V0AUTO-NUM-APOL , :V0AUTO-NRENDOS , CURRENT TIMESTAMP , :V0AUTO-TPMOVTO , :V0AUTO-ZEROKM:V1INDI-ZEROKM , :V0AUTO-SEGBONUS:V1INDI-SEGBONUS, :V0AUTO-FIDEL-AUTO , :V0AUTO-FIDEL-VIDA , :V0AUTO-FIDEL-PREV , :V0AUTO-DANOS-MORAIS , :V0AUTO-SEG-MERC-DET , :V0AUTO-ADIC-VLR-MERCADO , :V0AUTO-PERFIL , :V0AUTO-DESPEXTR , :V0AUTO-VLNOVO, :V0AUTO-CODDESPEXTR, :V0AUTO-DESPEXTR-PT, :V0AUTO-VARIA-IS, :V0AUTO-CANAL-PROPOSTA , :V0AUTO-TIPO-COBRANCA, :V0AUTO-NUM-PROP-CONV, :V0AUTO-NUM-CERTIF, :V0AUTO-NUM-RENAVAM, NULL, NULL, NULL, NULL, 0, :V0AUTO-IND-USO-VEIC, 99, :WHOST-CONGENERE, 999, 99) END-EXEC. */

            var r2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1 = new R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1()
            {
                V0AUTO_COD_EMPRESA = V0AUTO_COD_EMPRESA.ToString(),
                V0AUTO_FONTE = V0AUTO_FONTE.ToString(),
                V0AUTO_NRPROPOS = V0AUTO_NRPROPOS.ToString(),
                V0AUTO_NRITEM = V0AUTO_NRITEM.ToString(),
                V0AUTO_DTINIVIG = V0AUTO_DTINIVIG.ToString(),
                V0AUTO_DTTERVIG = V0AUTO_DTTERVIG.ToString(),
                V0AUTO_TIPOVEIC = V0AUTO_TIPOVEIC.ToString(),
                V0AUTO_FABRICAN = V0AUTO_FABRICAN.ToString(),
                V0AUTO_CDVEICL = V0AUTO_CDVEICL.ToString(),
                V0AUTO_COMBUST = V0AUTO_COMBUST.ToString(),
                V0AUTO_ANOVEICL = V0AUTO_ANOVEICL.ToString(),
                V0AUTO_ANOMOD = V0AUTO_ANOMOD.ToString(),
                V0AUTO_CORVEICL = V0AUTO_CORVEICL.ToString(),
                V0AUTO_CAPACID = V0AUTO_CAPACID.ToString(),
                V0AUTO_LOTACAO = V0AUTO_LOTACAO.ToString(),
                V0AUTO_PLACAUF = V0AUTO_PLACAUF.ToString(),
                V0AUTO_PLACALET = V0AUTO_PLACALET.ToString(),
                V0AUTO_PLACANR = V0AUTO_PLACANR.ToString(),
                V0AUTO_CHASSIS = V0AUTO_CHASSIS.ToString(),
                V0AUTO_UTILIZA = V0AUTO_UTILIZA.ToString(),
                V0AUTO_QTACESS = V0AUTO_QTACESS.ToString(),
                V0AUTO_DTBAIXA = V0AUTO_DTBAIXA.ToString(),
                V0AUTO_CDVISTOR = V0AUTO_CDVISTOR.ToString(),
                V0AUTO_PROPRIET = V0AUTO_PROPRIET.ToString(),
                V0AUTO_DTIVEXTP = V0AUTO_DTIVEXTP.ToString(),
                V0AUTO_ACEITE = V0AUTO_ACEITE.ToString(),
                V0AUTO_NRPRRESS = V0AUTO_NRPRRESS.ToString(),
                V0AUTO_PROTSINI = V0AUTO_PROTSINI.ToString(),
                V0AUTO_SITUACAO = V0AUTO_SITUACAO.ToString(),
                V0AUTO_CODCLIEN = V0AUTO_CODCLIEN.ToString(),
                V0AUTO_NUM_APOL = V0AUTO_NUM_APOL.ToString(),
                V0AUTO_NRENDOS = V0AUTO_NRENDOS.ToString(),
                V0AUTO_TPMOVTO = V0AUTO_TPMOVTO.ToString(),
                V0AUTO_ZEROKM = V0AUTO_ZEROKM.ToString(),
                V1INDI_ZEROKM = V1INDI_ZEROKM.ToString(),
                V0AUTO_SEGBONUS = V0AUTO_SEGBONUS.ToString(),
                V1INDI_SEGBONUS = V1INDI_SEGBONUS.ToString(),
                V0AUTO_FIDEL_AUTO = V0AUTO_FIDEL_AUTO.ToString(),
                V0AUTO_FIDEL_VIDA = V0AUTO_FIDEL_VIDA.ToString(),
                V0AUTO_FIDEL_PREV = V0AUTO_FIDEL_PREV.ToString(),
                V0AUTO_DANOS_MORAIS = V0AUTO_DANOS_MORAIS.ToString(),
                V0AUTO_SEG_MERC_DET = V0AUTO_SEG_MERC_DET.ToString(),
                V0AUTO_ADIC_VLR_MERCADO = V0AUTO_ADIC_VLR_MERCADO.ToString(),
                V0AUTO_PERFIL = V0AUTO_PERFIL.ToString(),
                V0AUTO_DESPEXTR = V0AUTO_DESPEXTR.ToString(),
                V0AUTO_VLNOVO = V0AUTO_VLNOVO.ToString(),
                V0AUTO_CODDESPEXTR = V0AUTO_CODDESPEXTR.ToString(),
                V0AUTO_DESPEXTR_PT = V0AUTO_DESPEXTR_PT.ToString(),
                V0AUTO_VARIA_IS = V0AUTO_VARIA_IS.ToString(),
                V0AUTO_CANAL_PROPOSTA = V0AUTO_CANAL_PROPOSTA.ToString(),
                V0AUTO_TIPO_COBRANCA = V0AUTO_TIPO_COBRANCA.ToString(),
                V0AUTO_NUM_PROP_CONV = V0AUTO_NUM_PROP_CONV.ToString(),
                V0AUTO_NUM_CERTIF = V0AUTO_NUM_CERTIF.ToString(),
                V0AUTO_NUM_RENAVAM = V0AUTO_NUM_RENAVAM.ToString(),
                V0AUTO_IND_USO_VEIC = V0AUTO_IND_USO_VEIC.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1.Execute(r2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-FETCH-V1AUTOPROP-SECTION */
        private void R2120_00_FETCH_V1AUTOPROP_SECTION()
        {
            /*" -1461- MOVE '212' TO WNR-EXEC-SQL. */
            _.Move("212", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1462- MOVE SPACES TO V1AUPR-ZEROKM. */
            _.Move("", V1AUPR_ZEROKM);

            /*" -1464- MOVE ZEROS TO V1AUPR-SEGBONUS. */
            _.Move(0, V1AUPR_SEGBONUS);

            /*" -1516- PERFORM R2120_00_FETCH_V1AUTOPROP_DB_FETCH_1 */

            R2120_00_FETCH_V1AUTOPROP_DB_FETCH_1();

            /*" -1521- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1522- MOVE 'S' TO WFIM-V1AUTOPROP */
                _.Move("S", AREA_DE_WORK.WFIM_V1AUTOPROP);

                /*" -1522- PERFORM R2120_00_FETCH_V1AUTOPROP_DB_CLOSE_1 */

                R2120_00_FETCH_V1AUTOPROP_DB_CLOSE_1();

                /*" -1525- GO TO R2120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1526- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1529- DISPLAY 'PROBLEMAS NO FETCH (V1AUTOPROP) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (V1AUTOPROP) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1531- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1531- ADD 1 TO AC-S-AUTOPROP. */
            AREA_DE_WORK.AC_S_AUTOPROP.Value = AREA_DE_WORK.AC_S_AUTOPROP + 1;

        }

        [StopWatch]
        /*" R2120-00-FETCH-V1AUTOPROP-DB-FETCH-1 */
        public void R2120_00_FETCH_V1AUTOPROP_DB_FETCH_1()
        {
            /*" -1516- EXEC SQL FETCH V1AUTOPROP INTO :V1AUPR-COD-EMPRESA, :V1AUPR-FONTE , :V1AUPR-NRPROPOS , :V1AUPR-NRITEM , :V1AUPR-DTINIVIG , :V1AUPR-DTTERVIG , :V1AUPR-TIPOVEIC , :V1AUPR-FABRICAN , :V1AUPR-CDVEICL , :V1AUPR-COMBUST , :V1AUPR-ANOVEICL , :V1AUPR-ANOMOD , :V1AUPR-CORVEICL , :V1AUPR-CAPACID , :V1AUPR-LOTACAO , :V1AUPR-PLACAUF , :V1AUPR-PLACALET , :V1AUPR-PLACANR , :V1AUPR-CHASSIS , :V1AUPR-UTILIZA , :V1AUPR-QTACESS , :V1AUPR-DTBAIXA , :V1AUPR-CDVISTOR , :V1AUPR-PROPRIET , :V1AUPR-DTIVEXTP , :V1AUPR-ACEITE , :V1AUPR-NRPRRESS , :V1AUPR-PROTSINI , :V1AUPR-SITUACAO , :V1AUPR-CODCLIEN , :V1AUPR-TPMOVTO , :V1AUPR-ZEROKM:V1INDI-ZEROKM, :V1AUPR-SEGBONUS:V1INDI-SEGBONUS, :V1AUPR-FIDEL-AUTO , :V1AUPR-FIDEL-VIDA , :V1AUPR-FIDEL-PREV , :V1AUPR-DANOS-MORAIS , :V1AUPR-SEG-MERC-DET , :V1AUPR-ADIC-VLR-MERCADO , :V1AUPR-PERFIL , :V1AUPR-DESPEXTR , :V1AUPR-VLNOVO , :V1AUPR-CODDESPEXTR, :V1AUPR-DESPEXTR-PT, :V1AUPR-VARIA-IS, :V1AUPR-CANAL-PROPOSTA, :V1AUPR-TIPO-COBRANCA, :V1AUPR-NUM-PROP-CNV, :V1AUPR-NUM-CERTIF, :V1AUPR-NUM-RENAVAM, :V1AUPR-IND-USO-VEIC END-EXEC. */

            if (V1AUTOPROP.Fetch())
            {
                _.Move(V1AUTOPROP.V1AUPR_COD_EMPRESA, V1AUPR_COD_EMPRESA);
                _.Move(V1AUTOPROP.V1AUPR_FONTE, V1AUPR_FONTE);
                _.Move(V1AUTOPROP.V1AUPR_NRPROPOS, V1AUPR_NRPROPOS);
                _.Move(V1AUTOPROP.V1AUPR_NRITEM, V1AUPR_NRITEM);
                _.Move(V1AUTOPROP.V1AUPR_DTINIVIG, V1AUPR_DTINIVIG);
                _.Move(V1AUTOPROP.V1AUPR_DTTERVIG, V1AUPR_DTTERVIG);
                _.Move(V1AUTOPROP.V1AUPR_TIPOVEIC, V1AUPR_TIPOVEIC);
                _.Move(V1AUTOPROP.V1AUPR_FABRICAN, V1AUPR_FABRICAN);
                _.Move(V1AUTOPROP.V1AUPR_CDVEICL, V1AUPR_CDVEICL);
                _.Move(V1AUTOPROP.V1AUPR_COMBUST, V1AUPR_COMBUST);
                _.Move(V1AUTOPROP.V1AUPR_ANOVEICL, V1AUPR_ANOVEICL);
                _.Move(V1AUTOPROP.V1AUPR_ANOMOD, V1AUPR_ANOMOD);
                _.Move(V1AUTOPROP.V1AUPR_CORVEICL, V1AUPR_CORVEICL);
                _.Move(V1AUTOPROP.V1AUPR_CAPACID, V1AUPR_CAPACID);
                _.Move(V1AUTOPROP.V1AUPR_LOTACAO, V1AUPR_LOTACAO);
                _.Move(V1AUTOPROP.V1AUPR_PLACAUF, V1AUPR_PLACAUF);
                _.Move(V1AUTOPROP.V1AUPR_PLACALET, V1AUPR_PLACALET);
                _.Move(V1AUTOPROP.V1AUPR_PLACANR, V1AUPR_PLACANR);
                _.Move(V1AUTOPROP.V1AUPR_CHASSIS, V1AUPR_CHASSIS);
                _.Move(V1AUTOPROP.V1AUPR_UTILIZA, V1AUPR_UTILIZA);
                _.Move(V1AUTOPROP.V1AUPR_QTACESS, V1AUPR_QTACESS);
                _.Move(V1AUTOPROP.V1AUPR_DTBAIXA, V1AUPR_DTBAIXA);
                _.Move(V1AUTOPROP.V1AUPR_CDVISTOR, V1AUPR_CDVISTOR);
                _.Move(V1AUTOPROP.V1AUPR_PROPRIET, V1AUPR_PROPRIET);
                _.Move(V1AUTOPROP.V1AUPR_DTIVEXTP, V1AUPR_DTIVEXTP);
                _.Move(V1AUTOPROP.V1AUPR_ACEITE, V1AUPR_ACEITE);
                _.Move(V1AUTOPROP.V1AUPR_NRPRRESS, V1AUPR_NRPRRESS);
                _.Move(V1AUTOPROP.V1AUPR_PROTSINI, V1AUPR_PROTSINI);
                _.Move(V1AUTOPROP.V1AUPR_SITUACAO, V1AUPR_SITUACAO);
                _.Move(V1AUTOPROP.V1AUPR_CODCLIEN, V1AUPR_CODCLIEN);
                _.Move(V1AUTOPROP.V1AUPR_TPMOVTO, V1AUPR_TPMOVTO);
                _.Move(V1AUTOPROP.V1AUPR_ZEROKM, V1AUPR_ZEROKM);
                _.Move(V1AUTOPROP.V1INDI_ZEROKM, V1INDI_ZEROKM);
                _.Move(V1AUTOPROP.V1AUPR_SEGBONUS, V1AUPR_SEGBONUS);
                _.Move(V1AUTOPROP.V1INDI_SEGBONUS, V1INDI_SEGBONUS);
                _.Move(V1AUTOPROP.V1AUPR_FIDEL_AUTO, V1AUPR_FIDEL_AUTO);
                _.Move(V1AUTOPROP.V1AUPR_FIDEL_VIDA, V1AUPR_FIDEL_VIDA);
                _.Move(V1AUTOPROP.V1AUPR_FIDEL_PREV, V1AUPR_FIDEL_PREV);
                _.Move(V1AUTOPROP.V1AUPR_DANOS_MORAIS, V1AUPR_DANOS_MORAIS);
                _.Move(V1AUTOPROP.V1AUPR_SEG_MERC_DET, V1AUPR_SEG_MERC_DET);
                _.Move(V1AUTOPROP.V1AUPR_ADIC_VLR_MERCADO, V1AUPR_ADIC_VLR_MERCADO);
                _.Move(V1AUTOPROP.V1AUPR_PERFIL, V1AUPR_PERFIL);
                _.Move(V1AUTOPROP.V1AUPR_DESPEXTR, V1AUPR_DESPEXTR);
                _.Move(V1AUTOPROP.V1AUPR_VLNOVO, V1AUPR_VLNOVO);
                _.Move(V1AUTOPROP.V1AUPR_CODDESPEXTR, V1AUPR_CODDESPEXTR);
                _.Move(V1AUTOPROP.V1AUPR_DESPEXTR_PT, V1AUPR_DESPEXTR_PT);
                _.Move(V1AUTOPROP.V1AUPR_VARIA_IS, V1AUPR_VARIA_IS);
                _.Move(V1AUTOPROP.V1AUPR_CANAL_PROPOSTA, V1AUPR_CANAL_PROPOSTA);
                _.Move(V1AUTOPROP.V1AUPR_TIPO_COBRANCA, V1AUPR_TIPO_COBRANCA);
                _.Move(V1AUTOPROP.V1AUPR_NUM_PROP_CNV, V1AUPR_NUM_PROP_CNV);
                _.Move(V1AUTOPROP.V1AUPR_NUM_CERTIF, V1AUPR_NUM_CERTIF);
                _.Move(V1AUTOPROP.V1AUPR_NUM_RENAVAM, V1AUPR_NUM_RENAVAM);
                _.Move(V1AUTOPROP.V1AUPR_IND_USO_VEIC, V1AUPR_IND_USO_VEIC);
            }

        }

        [StopWatch]
        /*" R2120-00-FETCH-V1AUTOPROP-DB-CLOSE-1 */
        public void R2120_00_FETCH_V1AUTOPROP_DB_CLOSE_1()
        {
            /*" -1522- EXEC SQL CLOSE V1AUTOPROP END-EXEC */

            V1AUTOPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-MONTA-V0AUTOAPOL-SECTION */
        private void R2130_00_MONTA_V0AUTOAPOL_SECTION()
        {
            /*" -1545- MOVE '213' TO WNR-EXEC-SQL. */
            _.Move("213", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1546- MOVE V1AUPR-COD-EMPRESA TO V0AUTO-COD-EMPRESA */
            _.Move(V1AUPR_COD_EMPRESA, V0AUTO_COD_EMPRESA);

            /*" -1547- MOVE WHOST-FONTE TO V0AUTO-FONTE */
            _.Move(WHOST_FONTE, V0AUTO_FONTE);

            /*" -1548- MOVE WHOST-NRPROPOS TO V0AUTO-NRPROPOS */
            _.Move(WHOST_NRPROPOS, V0AUTO_NRPROPOS);

            /*" -1549- MOVE V1AUPR-NRITEM TO V0AUTO-NRITEM */
            _.Move(V1AUPR_NRITEM, V0AUTO_NRITEM);

            /*" -1550- MOVE V1AUPR-DTINIVIG TO V0AUTO-DTINIVIG */
            _.Move(V1AUPR_DTINIVIG, V0AUTO_DTINIVIG);

            /*" -1551- MOVE V1AUPR-DTTERVIG TO V0AUTO-DTTERVIG */
            _.Move(V1AUPR_DTTERVIG, V0AUTO_DTTERVIG);

            /*" -1552- MOVE V1AUPR-TIPOVEIC TO V0AUTO-TIPOVEIC */
            _.Move(V1AUPR_TIPOVEIC, V0AUTO_TIPOVEIC);

            /*" -1553- MOVE V1AUPR-FABRICAN TO V0AUTO-FABRICAN */
            _.Move(V1AUPR_FABRICAN, V0AUTO_FABRICAN);

            /*" -1555- MOVE V1AUPR-CDVEICL TO V0AUTO-CDVEICL */
            _.Move(V1AUPR_CDVEICL, V0AUTO_CDVEICL);

            /*" -1556- MOVE V1AUPR-COMBUST TO V0AUTO-COMBUST */
            _.Move(V1AUPR_COMBUST, V0AUTO_COMBUST);

            /*" -1557- MOVE V1AUPR-ANOVEICL TO V0AUTO-ANOVEICL */
            _.Move(V1AUPR_ANOVEICL, V0AUTO_ANOVEICL);

            /*" -1558- MOVE V1AUPR-ANOMOD TO V0AUTO-ANOMOD */
            _.Move(V1AUPR_ANOMOD, V0AUTO_ANOMOD);

            /*" -1559- MOVE V1AUPR-CORVEICL TO V0AUTO-CORVEICL */
            _.Move(V1AUPR_CORVEICL, V0AUTO_CORVEICL);

            /*" -1560- MOVE V1AUPR-CAPACID TO V0AUTO-CAPACID */
            _.Move(V1AUPR_CAPACID, V0AUTO_CAPACID);

            /*" -1561- MOVE V1AUPR-LOTACAO TO V0AUTO-LOTACAO */
            _.Move(V1AUPR_LOTACAO, V0AUTO_LOTACAO);

            /*" -1562- MOVE V1AUPR-PLACAUF TO V0AUTO-PLACAUF */
            _.Move(V1AUPR_PLACAUF, V0AUTO_PLACAUF);

            /*" -1563- MOVE V1AUPR-PLACALET TO V0AUTO-PLACALET */
            _.Move(V1AUPR_PLACALET, V0AUTO_PLACALET);

            /*" -1564- MOVE V1AUPR-PLACANR TO V0AUTO-PLACANR */
            _.Move(V1AUPR_PLACANR, V0AUTO_PLACANR);

            /*" -1565- MOVE V1AUPR-CHASSIS TO V0AUTO-CHASSIS */
            _.Move(V1AUPR_CHASSIS, V0AUTO_CHASSIS);

            /*" -1566- MOVE V1AUPR-UTILIZA TO V0AUTO-UTILIZA */
            _.Move(V1AUPR_UTILIZA, V0AUTO_UTILIZA);

            /*" -1567- MOVE V1AUPR-QTACESS TO V0AUTO-QTACESS */
            _.Move(V1AUPR_QTACESS, V0AUTO_QTACESS);

            /*" -1568- MOVE V1AUPR-DTBAIXA TO V0AUTO-DTBAIXA */
            _.Move(V1AUPR_DTBAIXA, V0AUTO_DTBAIXA);

            /*" -1569- MOVE V1AUPR-CDVISTOR TO V0AUTO-CDVISTOR */
            _.Move(V1AUPR_CDVISTOR, V0AUTO_CDVISTOR);

            /*" -1570- MOVE V1AUPR-PROPRIET TO V0AUTO-PROPRIET */
            _.Move(V1AUPR_PROPRIET, V0AUTO_PROPRIET);

            /*" -1571- MOVE V1AUPR-DTIVEXTP TO V0AUTO-DTIVEXTP */
            _.Move(V1AUPR_DTIVEXTP, V0AUTO_DTIVEXTP);

            /*" -1572- MOVE V1AUPR-ACEITE TO V0AUTO-ACEITE */
            _.Move(V1AUPR_ACEITE, V0AUTO_ACEITE);

            /*" -1573- MOVE V1AUPR-NRPRRESS TO V0AUTO-NRPRRESS */
            _.Move(V1AUPR_NRPRRESS, V0AUTO_NRPRRESS);

            /*" -1574- MOVE V1AUPR-PROTSINI TO V0AUTO-PROTSINI */
            _.Move(V1AUPR_PROTSINI, V0AUTO_PROTSINI);

            /*" -1575- MOVE V1AUPR-CODCLIEN TO V0AUTO-CODCLIEN */
            _.Move(V1AUPR_CODCLIEN, V0AUTO_CODCLIEN);

            /*" -1576- MOVE WHOST-NUM-APOL TO V0AUTO-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0AUTO_NUM_APOL);

            /*" -1577- MOVE WHOST-NRENDOS TO V0AUTO-NRENDOS */
            _.Move(WHOST_NRENDOS, V0AUTO_NRENDOS);

            /*" -1587- MOVE V1AUPR-TPMOVTO TO V0AUTO-TPMOVTO. */
            _.Move(V1AUPR_TPMOVTO, V0AUTO_TPMOVTO);

            /*" -1589- MOVE V1AUPR-SITUACAO TO V0AUTO-SITUACAO. */
            _.Move(V1AUPR_SITUACAO, V0AUTO_SITUACAO);

            /*" -1590- MOVE V1AUPR-ZEROKM TO V0AUTO-ZEROKM. */
            _.Move(V1AUPR_ZEROKM, V0AUTO_ZEROKM);

            /*" -1591- MOVE V1AUPR-SEGBONUS TO V0AUTO-SEGBONUS. */
            _.Move(V1AUPR_SEGBONUS, V0AUTO_SEGBONUS);

            /*" -1592- MOVE V1AUPR-FIDEL-AUTO TO V0AUTO-FIDEL-AUTO. */
            _.Move(V1AUPR_FIDEL_AUTO, V0AUTO_FIDEL_AUTO);

            /*" -1593- MOVE V1AUPR-FIDEL-VIDA TO V0AUTO-FIDEL-VIDA. */
            _.Move(V1AUPR_FIDEL_VIDA, V0AUTO_FIDEL_VIDA);

            /*" -1594- MOVE V1AUPR-FIDEL-PREV TO V0AUTO-FIDEL-PREV. */
            _.Move(V1AUPR_FIDEL_PREV, V0AUTO_FIDEL_PREV);

            /*" -1596- MOVE V1AUPR-DANOS-MORAIS TO V0AUTO-DANOS-MORAIS. */
            _.Move(V1AUPR_DANOS_MORAIS, V0AUTO_DANOS_MORAIS);

            /*" -1598- MOVE V1AUPR-SEG-MERC-DET TO V0AUTO-SEG-MERC-DET. */
            _.Move(V1AUPR_SEG_MERC_DET, V0AUTO_SEG_MERC_DET);

            /*" -1600- MOVE V1AUPR-ADIC-VLR-MERCADO TO V0AUTO-ADIC-VLR-MERCADO. */
            _.Move(V1AUPR_ADIC_VLR_MERCADO, V0AUTO_ADIC_VLR_MERCADO);

            /*" -1601- MOVE V1AUPR-PERFIL TO V0AUTO-PERFIL. */
            _.Move(V1AUPR_PERFIL, V0AUTO_PERFIL);

            /*" -1602- MOVE V1AUPR-DESPEXTR TO V0AUTO-DESPEXTR. */
            _.Move(V1AUPR_DESPEXTR, V0AUTO_DESPEXTR);

            /*" -1603- MOVE V1AUPR-VLNOVO TO V0AUTO-VLNOVO. */
            _.Move(V1AUPR_VLNOVO, V0AUTO_VLNOVO);

            /*" -1604- MOVE V1AUPR-CODDESPEXTR TO V0AUTO-CODDESPEXTR. */
            _.Move(V1AUPR_CODDESPEXTR, V0AUTO_CODDESPEXTR);

            /*" -1605- MOVE V1AUPR-DESPEXTR-PT TO V0AUTO-DESPEXTR-PT. */
            _.Move(V1AUPR_DESPEXTR_PT, V0AUTO_DESPEXTR_PT);

            /*" -1606- MOVE V1AUPR-VARIA-IS TO V0AUTO-VARIA-IS. */
            _.Move(V1AUPR_VARIA_IS, V0AUTO_VARIA_IS);

            /*" -1608- MOVE V1AUPR-CANAL-PROPOSTA TO V0AUTO-CANAL-PROPOSTA. */
            _.Move(V1AUPR_CANAL_PROPOSTA, V0AUTO_CANAL_PROPOSTA);

            /*" -1610- MOVE V1AUPR-TIPO-COBRANCA TO V0AUTO-TIPO-COBRANCA. */
            _.Move(V1AUPR_TIPO_COBRANCA, V0AUTO_TIPO_COBRANCA);

            /*" -1612- MOVE V1AUPR-NUM-PROP-CNV TO V0AUTO-NUM-PROP-CONV. */
            _.Move(V1AUPR_NUM_PROP_CNV, V0AUTO_NUM_PROP_CONV);

            /*" -1614- MOVE V1AUPR-NUM-CERTIF TO V0AUTO-NUM-CERTIF. */
            _.Move(V1AUPR_NUM_CERTIF, V0AUTO_NUM_CERTIF);

            /*" -1616- MOVE V1AUPR-NUM-RENAVAM TO V0AUTO-NUM-RENAVAM. */
            _.Move(V1AUPR_NUM_RENAVAM, V0AUTO_NUM_RENAVAM);

            /*" -1617- MOVE V1AUPR-IND-USO-VEIC TO V0AUTO-IND-USO-VEIC. */
            _.Move(V1AUPR_IND_USO_VEIC, V0AUTO_IND_USO_VEIC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-DECLARE-V1AUTARIPROP-SECTION */
        private void R2200_00_DECLARE_V1AUTARIPROP_SECTION()
        {
            /*" -1631- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1710- PERFORM R2200_00_DECLARE_V1AUTARIPROP_DB_DECLARE_1 */

            R2200_00_DECLARE_V1AUTARIPROP_DB_DECLARE_1();

            /*" -1712- PERFORM R2200_00_DECLARE_V1AUTARIPROP_DB_OPEN_1 */

            R2200_00_DECLARE_V1AUTARIPROP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2200-00-DECLARE-V1AUTARIPROP-DB-OPEN-1 */
        public void R2200_00_DECLARE_V1AUTARIPROP_DB_OPEN_1()
        {
            /*" -1712- EXEC SQL OPEN V1AUTARIPROP END-EXEC. */

            V1AUTARIPROP.Open();

        }

        [StopWatch]
        /*" R2300-00-DECLARE-V1AUTCOBPROP-DB-DECLARE-1 */
        public void R2300_00_DECLARE_V1AUTCOBPROP_DB_DECLARE_1()
        {
            /*" -2066- EXEC SQL DECLARE V1AUTCOBPROP CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NRITEM , RAMOFR , MODALIFR , COD_COBERTURA , DTINIVIG , DTTERVIG , IMP_SEGURADA_IX , IMP_SEGURADA_VAR , TAXA_IS , PRM_ANUAL_IX , PRM_TARIFARIO_IX , PRM_TARIFARIO_VAR, SITUACAO FROM SEGUROS.V1AUTOCOBERPROP WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY NRITEM , RAMOFR , MODALIFR , COD_COBERTURA END-EXEC. */
            V1AUTCOBPROP = new EM0910S_V1AUTCOBPROP(true);
            string GetQuery_V1AUTCOBPROP()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NRITEM
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							IMP_SEGURADA_IX
							, 
							IMP_SEGURADA_VAR
							, 
							TAXA_IS
							, 
							PRM_ANUAL_IX
							, 
							PRM_TARIFARIO_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							SITUACAO 
							FROM SEGUROS.V1AUTOCOBERPROP 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY NRITEM
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA";

                return query;
            }
            V1AUTCOBPROP.GetQueryEvent += GetQuery_V1AUTCOBPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-INCLUI-V0AUTOTARIFA-SECTION */
        private void R2210_00_INCLUI_V0AUTOTARIFA_SECTION()
        {
            /*" -1724- PERFORM R2220-00-FETCH-V1AUTARIPROP */

            R2220_00_FETCH_V1AUTARIPROP_SECTION();

            /*" -1725- IF WFIM-V1AUTARIPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AUTARIPROP.IsEmpty())
            {

                /*" -1727- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1729- PERFORM R2230-00-MONTA-V0AUTOTARIFA */

            R2230_00_MONTA_V0AUTOTARIFA_SECTION();

            /*" -1732- MOVE '221' TO WNR-EXEC-SQL. */
            _.Move("221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1813- PERFORM R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1 */

            R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1();

            /*" -1816- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1818- MOVE 'V0AUTOTARIFA (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0AUTOTARIFA (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1820- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1821- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1823- MOVE 'V0AUTOTARIFA (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0AUTOTARIFA (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -1825- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1825- ADD 1 TO AC-I-AUTOTARIFA. */
            AREA_DE_WORK.AC_I_AUTOTARIFA.Value = AREA_DE_WORK.AC_I_AUTOTARIFA + 1;

        }

        [StopWatch]
        /*" R2210-00-INCLUI-V0AUTOTARIFA-DB-INSERT-1 */
        public void R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1()
        {
            /*" -1813- EXEC SQL INSERT INTO SEGUROS.V0AUTOTARIFA VALUES (:V0TARI-COD-EMPRESA, :V0TARI-FONTE , :V0TARI-NRPROPOS , :V0TARI-NRITEM , :V0TARI-DTINIVIG , :V0TARI-DTTERVIG , :V0TARI-TERCEIXO , :V0TARI-CATTARIF , :V0TARI-TIPOCOB , :V0TARI-REGIAO , :V0TARI-FRANQFAC , :V0TARI-CLABONAT , :V0TARI-PCDESCAT , :V0TARI-CLABONDM , :V0TARI-CLABONDP , :V0TARI-CATTARIR , :V0TARI-DESCFROT , :V0TARI-NUMPASSG , :V0TARI-VRFROBR-IX , :V0TARI-VRFRFACC-IX, :V0TARI-VRFRFACA-IX, :V0TARI-VRFRADIC-IX, :V0TARI-VRPRREF , :V0TARI-CFFROBR , :V0TARI-CFFRFACC , :V0TARI-CFFRFACA , :V0TARI-CFPRREF , :V0TARI-PCDSCFRF , :V0TARI-PCISCASC , :V0TARI-PCINCROU , :V0TARI-PCAGPLCA , :V0TARI-PCAGPLAC , :V0TARI-VRPRRFDM , :V0TARI-VRPRRFDP , :V0TARI-EXTPER , :V0TARI-PERIODO , :V0TARI-PCFRADIC , :V0TARI-PRAZOSEG , :V0TARI-DESCIDAD , :V0TARI-TCFAPLPR , :V0TARI-TPCDSFRF , :V0TARI-TPCDSBAU , :V0TARI-TTXAPLIS , :V0TARI-TPCPZSEG , :V0TARI-TPRBRCDM , :V0TARI-TCFPBRDM , :V0TARI-TPRBRCDP , :V0TARI-TCFPBRDP , :V0TARI-TPCBONDM , :V0TARI-TPCBONDP , :V0TARI-TTXAPPM , :V0TARI-TTXAPPI , :V0TARI-TTXAPPA , :V0TARI-TTXAPPD , :V0TARI-TPCDSAPP , :V0TARI-DATEND , :V0TARI-TPCMAJOR , :V0TARI-PCDESAUT , :V0TARI-PCDESRCF , :V0TARI-PCDESAPP , :V0TARI-PCDESPLCA , :V0TARI-PCDESPLRF , :V0TARI-PCDESPLAP , :V0TARI-PCAGPLRF , :V0TARI-PCAGPLAP , :V0TARI-PCDESACE , :V0TARI-NUM-APOL , :V0TARI-NRENDOS , CURRENT TIMESTAMP , :V0TARI-PCAGISCASC :VIND-PCAGISCASC, :V0TARI-VALOR-AVARIA, :V0TARI-TPCBONDMO , :V0TARI-TCFPBRDMO , :V0TARI-IND-COML , :V0TARI-PCT-COML , :V0TARI-CODUSU , :V0TARI-IND-VLR-MIN, NULL, :WHOST-CONGENERE) END-EXEC. */

            var r2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1 = new R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1()
            {
                V0TARI_COD_EMPRESA = V0TARI_COD_EMPRESA.ToString(),
                V0TARI_FONTE = V0TARI_FONTE.ToString(),
                V0TARI_NRPROPOS = V0TARI_NRPROPOS.ToString(),
                V0TARI_NRITEM = V0TARI_NRITEM.ToString(),
                V0TARI_DTINIVIG = V0TARI_DTINIVIG.ToString(),
                V0TARI_DTTERVIG = V0TARI_DTTERVIG.ToString(),
                V0TARI_TERCEIXO = V0TARI_TERCEIXO.ToString(),
                V0TARI_CATTARIF = V0TARI_CATTARIF.ToString(),
                V0TARI_TIPOCOB = V0TARI_TIPOCOB.ToString(),
                V0TARI_REGIAO = V0TARI_REGIAO.ToString(),
                V0TARI_FRANQFAC = V0TARI_FRANQFAC.ToString(),
                V0TARI_CLABONAT = V0TARI_CLABONAT.ToString(),
                V0TARI_PCDESCAT = V0TARI_PCDESCAT.ToString(),
                V0TARI_CLABONDM = V0TARI_CLABONDM.ToString(),
                V0TARI_CLABONDP = V0TARI_CLABONDP.ToString(),
                V0TARI_CATTARIR = V0TARI_CATTARIR.ToString(),
                V0TARI_DESCFROT = V0TARI_DESCFROT.ToString(),
                V0TARI_NUMPASSG = V0TARI_NUMPASSG.ToString(),
                V0TARI_VRFROBR_IX = V0TARI_VRFROBR_IX.ToString(),
                V0TARI_VRFRFACC_IX = V0TARI_VRFRFACC_IX.ToString(),
                V0TARI_VRFRFACA_IX = V0TARI_VRFRFACA_IX.ToString(),
                V0TARI_VRFRADIC_IX = V0TARI_VRFRADIC_IX.ToString(),
                V0TARI_VRPRREF = V0TARI_VRPRREF.ToString(),
                V0TARI_CFFROBR = V0TARI_CFFROBR.ToString(),
                V0TARI_CFFRFACC = V0TARI_CFFRFACC.ToString(),
                V0TARI_CFFRFACA = V0TARI_CFFRFACA.ToString(),
                V0TARI_CFPRREF = V0TARI_CFPRREF.ToString(),
                V0TARI_PCDSCFRF = V0TARI_PCDSCFRF.ToString(),
                V0TARI_PCISCASC = V0TARI_PCISCASC.ToString(),
                V0TARI_PCINCROU = V0TARI_PCINCROU.ToString(),
                V0TARI_PCAGPLCA = V0TARI_PCAGPLCA.ToString(),
                V0TARI_PCAGPLAC = V0TARI_PCAGPLAC.ToString(),
                V0TARI_VRPRRFDM = V0TARI_VRPRRFDM.ToString(),
                V0TARI_VRPRRFDP = V0TARI_VRPRRFDP.ToString(),
                V0TARI_EXTPER = V0TARI_EXTPER.ToString(),
                V0TARI_PERIODO = V0TARI_PERIODO.ToString(),
                V0TARI_PCFRADIC = V0TARI_PCFRADIC.ToString(),
                V0TARI_PRAZOSEG = V0TARI_PRAZOSEG.ToString(),
                V0TARI_DESCIDAD = V0TARI_DESCIDAD.ToString(),
                V0TARI_TCFAPLPR = V0TARI_TCFAPLPR.ToString(),
                V0TARI_TPCDSFRF = V0TARI_TPCDSFRF.ToString(),
                V0TARI_TPCDSBAU = V0TARI_TPCDSBAU.ToString(),
                V0TARI_TTXAPLIS = V0TARI_TTXAPLIS.ToString(),
                V0TARI_TPCPZSEG = V0TARI_TPCPZSEG.ToString(),
                V0TARI_TPRBRCDM = V0TARI_TPRBRCDM.ToString(),
                V0TARI_TCFPBRDM = V0TARI_TCFPBRDM.ToString(),
                V0TARI_TPRBRCDP = V0TARI_TPRBRCDP.ToString(),
                V0TARI_TCFPBRDP = V0TARI_TCFPBRDP.ToString(),
                V0TARI_TPCBONDM = V0TARI_TPCBONDM.ToString(),
                V0TARI_TPCBONDP = V0TARI_TPCBONDP.ToString(),
                V0TARI_TTXAPPM = V0TARI_TTXAPPM.ToString(),
                V0TARI_TTXAPPI = V0TARI_TTXAPPI.ToString(),
                V0TARI_TTXAPPA = V0TARI_TTXAPPA.ToString(),
                V0TARI_TTXAPPD = V0TARI_TTXAPPD.ToString(),
                V0TARI_TPCDSAPP = V0TARI_TPCDSAPP.ToString(),
                V0TARI_DATEND = V0TARI_DATEND.ToString(),
                V0TARI_TPCMAJOR = V0TARI_TPCMAJOR.ToString(),
                V0TARI_PCDESAUT = V0TARI_PCDESAUT.ToString(),
                V0TARI_PCDESRCF = V0TARI_PCDESRCF.ToString(),
                V0TARI_PCDESAPP = V0TARI_PCDESAPP.ToString(),
                V0TARI_PCDESPLCA = V0TARI_PCDESPLCA.ToString(),
                V0TARI_PCDESPLRF = V0TARI_PCDESPLRF.ToString(),
                V0TARI_PCDESPLAP = V0TARI_PCDESPLAP.ToString(),
                V0TARI_PCAGPLRF = V0TARI_PCAGPLRF.ToString(),
                V0TARI_PCAGPLAP = V0TARI_PCAGPLAP.ToString(),
                V0TARI_PCDESACE = V0TARI_PCDESACE.ToString(),
                V0TARI_NUM_APOL = V0TARI_NUM_APOL.ToString(),
                V0TARI_NRENDOS = V0TARI_NRENDOS.ToString(),
                V0TARI_PCAGISCASC = V0TARI_PCAGISCASC.ToString(),
                VIND_PCAGISCASC = VIND_PCAGISCASC.ToString(),
                V0TARI_VALOR_AVARIA = V0TARI_VALOR_AVARIA.ToString(),
                V0TARI_TPCBONDMO = V0TARI_TPCBONDMO.ToString(),
                V0TARI_TCFPBRDMO = V0TARI_TCFPBRDMO.ToString(),
                V0TARI_IND_COML = V0TARI_IND_COML.ToString(),
                V0TARI_PCT_COML = V0TARI_PCT_COML.ToString(),
                V0TARI_CODUSU = V0TARI_CODUSU.ToString(),
                V0TARI_IND_VLR_MIN = V0TARI_IND_VLR_MIN.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1.Execute(r2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-FETCH-V1AUTARIPROP-SECTION */
        private void R2220_00_FETCH_V1AUTARIPROP_SECTION()
        {
            /*" -1839- MOVE '222' TO WNR-EXEC-SQL. */
            _.Move("222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1914- PERFORM R2220_00_FETCH_V1AUTARIPROP_DB_FETCH_1 */

            R2220_00_FETCH_V1AUTARIPROP_DB_FETCH_1();

            /*" -1919- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1920- MOVE 'S' TO WFIM-V1AUTARIPROP */
                _.Move("S", AREA_DE_WORK.WFIM_V1AUTARIPROP);

                /*" -1920- PERFORM R2220_00_FETCH_V1AUTARIPROP_DB_CLOSE_1 */

                R2220_00_FETCH_V1AUTARIPROP_DB_CLOSE_1();

                /*" -1923- GO TO R2220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1924- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1927- DISPLAY 'PROBLEMAS NO FETCH (V1AUTOTARIPROP) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (V1AUTOTARIPROP) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -1929- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1929- ADD 1 TO AC-S-AUTOTARIFP. */
            AREA_DE_WORK.AC_S_AUTOTARIFP.Value = AREA_DE_WORK.AC_S_AUTOTARIFP + 1;

        }

        [StopWatch]
        /*" R2220-00-FETCH-V1AUTARIPROP-DB-FETCH-1 */
        public void R2220_00_FETCH_V1AUTARIPROP_DB_FETCH_1()
        {
            /*" -1914- EXEC SQL FETCH V1AUTARIPROP INTO :V1TAPR-COD-EMPRESA, :V1TAPR-FONTE , :V1TAPR-NRPROPOS , :V1TAPR-NRITEM , :V1TAPR-DTINIVIG , :V1TAPR-DTTERVIG , :V1TAPR-TERCEIXO , :V1TAPR-CATTARIF , :V1TAPR-TIPOCOB , :V1TAPR-REGIAO , :V1TAPR-FRANQFAC , :V1TAPR-CLABONAT , :V1TAPR-PCDESCAT , :V1TAPR-CLABONDM , :V1TAPR-CLABONDP , :V1TAPR-CATTARIR , :V1TAPR-DESCFROT , :V1TAPR-NUMPASSG , :V1TAPR-VRFROBR-IX , :V1TAPR-VRFRFACC-IX, :V1TAPR-VRFRFACA-IX, :V1TAPR-VRFRADIC-IX, :V1TAPR-VRPRREF , :V1TAPR-CFFROBR , :V1TAPR-CFFRFACC , :V1TAPR-CFFRFACA , :V1TAPR-CFPRREF , :V1TAPR-PCDSCFRF , :V1TAPR-PCISCASC , :V1TAPR-PCINCROU , :V1TAPR-PCAGPLCA , :V1TAPR-PCAGPLAC , :V1TAPR-VRPRRFDM , :V1TAPR-VRPRRFDP , :V1TAPR-EXTPER , :V1TAPR-PERIODO , :V1TAPR-PCFRADIC , :V1TAPR-PRAZOSEG , :V1TAPR-DESCIDAD , :V1TAPR-TCFAPLPR , :V1TAPR-TPCDSFRF , :V1TAPR-TPCDSBAU , :V1TAPR-TTXAPLIS , :V1TAPR-TPCPZSEG , :V1TAPR-TPRBRCDM , :V1TAPR-TCFPBRDM , :V1TAPR-TPRBRCDP , :V1TAPR-TCFPBRDP , :V1TAPR-TPCBONDM , :V1TAPR-TPCBONDP , :V1TAPR-TTXAPPM , :V1TAPR-TTXAPPI , :V1TAPR-TTXAPPA , :V1TAPR-TTXAPPD , :V1TAPR-TPCDSAPP , :V1TAPR-DATEND , :V1TAPR-TPCMAJOR , :V1TAPR-PCDESAUT , :V1TAPR-PCDESRCF , :V1TAPR-PCDESAPP , :V1TAPR-PCDESPLCA , :V1TAPR-PCDESPLRF , :V1TAPR-PCDESPLAP , :V1TAPR-PCAGPLRF , :V1TAPR-PCAGPLAP , :V1TAPR-PCDESACE , :V1TAPR-PCAGISCASC :VIND-PCAGISCASC, :V1TAPR-VALOR-AVARIA, :V1TAPR-TPCBONDMO , :V1TAPR-TCFPBRDMO , :V1TAPR-IND-COML , :V1TAPR-PCT-COML , :V1TAPR-CODUSU , :V1TAPR-IND-VLR-MIN END-EXEC. */

            if (V1AUTARIPROP.Fetch())
            {
                _.Move(V1AUTARIPROP.V1TAPR_COD_EMPRESA, V1TAPR_COD_EMPRESA);
                _.Move(V1AUTARIPROP.V1TAPR_FONTE, V1TAPR_FONTE);
                _.Move(V1AUTARIPROP.V1TAPR_NRPROPOS, V1TAPR_NRPROPOS);
                _.Move(V1AUTARIPROP.V1TAPR_NRITEM, V1TAPR_NRITEM);
                _.Move(V1AUTARIPROP.V1TAPR_DTINIVIG, V1TAPR_DTINIVIG);
                _.Move(V1AUTARIPROP.V1TAPR_DTTERVIG, V1TAPR_DTTERVIG);
                _.Move(V1AUTARIPROP.V1TAPR_TERCEIXO, V1TAPR_TERCEIXO);
                _.Move(V1AUTARIPROP.V1TAPR_CATTARIF, V1TAPR_CATTARIF);
                _.Move(V1AUTARIPROP.V1TAPR_TIPOCOB, V1TAPR_TIPOCOB);
                _.Move(V1AUTARIPROP.V1TAPR_REGIAO, V1TAPR_REGIAO);
                _.Move(V1AUTARIPROP.V1TAPR_FRANQFAC, V1TAPR_FRANQFAC);
                _.Move(V1AUTARIPROP.V1TAPR_CLABONAT, V1TAPR_CLABONAT);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESCAT, V1TAPR_PCDESCAT);
                _.Move(V1AUTARIPROP.V1TAPR_CLABONDM, V1TAPR_CLABONDM);
                _.Move(V1AUTARIPROP.V1TAPR_CLABONDP, V1TAPR_CLABONDP);
                _.Move(V1AUTARIPROP.V1TAPR_CATTARIR, V1TAPR_CATTARIR);
                _.Move(V1AUTARIPROP.V1TAPR_DESCFROT, V1TAPR_DESCFROT);
                _.Move(V1AUTARIPROP.V1TAPR_NUMPASSG, V1TAPR_NUMPASSG);
                _.Move(V1AUTARIPROP.V1TAPR_VRFROBR_IX, V1TAPR_VRFROBR_IX);
                _.Move(V1AUTARIPROP.V1TAPR_VRFRFACC_IX, V1TAPR_VRFRFACC_IX);
                _.Move(V1AUTARIPROP.V1TAPR_VRFRFACA_IX, V1TAPR_VRFRFACA_IX);
                _.Move(V1AUTARIPROP.V1TAPR_VRFRADIC_IX, V1TAPR_VRFRADIC_IX);
                _.Move(V1AUTARIPROP.V1TAPR_VRPRREF, V1TAPR_VRPRREF);
                _.Move(V1AUTARIPROP.V1TAPR_CFFROBR, V1TAPR_CFFROBR);
                _.Move(V1AUTARIPROP.V1TAPR_CFFRFACC, V1TAPR_CFFRFACC);
                _.Move(V1AUTARIPROP.V1TAPR_CFFRFACA, V1TAPR_CFFRFACA);
                _.Move(V1AUTARIPROP.V1TAPR_CFPRREF, V1TAPR_CFPRREF);
                _.Move(V1AUTARIPROP.V1TAPR_PCDSCFRF, V1TAPR_PCDSCFRF);
                _.Move(V1AUTARIPROP.V1TAPR_PCISCASC, V1TAPR_PCISCASC);
                _.Move(V1AUTARIPROP.V1TAPR_PCINCROU, V1TAPR_PCINCROU);
                _.Move(V1AUTARIPROP.V1TAPR_PCAGPLCA, V1TAPR_PCAGPLCA);
                _.Move(V1AUTARIPROP.V1TAPR_PCAGPLAC, V1TAPR_PCAGPLAC);
                _.Move(V1AUTARIPROP.V1TAPR_VRPRRFDM, V1TAPR_VRPRRFDM);
                _.Move(V1AUTARIPROP.V1TAPR_VRPRRFDP, V1TAPR_VRPRRFDP);
                _.Move(V1AUTARIPROP.V1TAPR_EXTPER, V1TAPR_EXTPER);
                _.Move(V1AUTARIPROP.V1TAPR_PERIODO, V1TAPR_PERIODO);
                _.Move(V1AUTARIPROP.V1TAPR_PCFRADIC, V1TAPR_PCFRADIC);
                _.Move(V1AUTARIPROP.V1TAPR_PRAZOSEG, V1TAPR_PRAZOSEG);
                _.Move(V1AUTARIPROP.V1TAPR_DESCIDAD, V1TAPR_DESCIDAD);
                _.Move(V1AUTARIPROP.V1TAPR_TCFAPLPR, V1TAPR_TCFAPLPR);
                _.Move(V1AUTARIPROP.V1TAPR_TPCDSFRF, V1TAPR_TPCDSFRF);
                _.Move(V1AUTARIPROP.V1TAPR_TPCDSBAU, V1TAPR_TPCDSBAU);
                _.Move(V1AUTARIPROP.V1TAPR_TTXAPLIS, V1TAPR_TTXAPLIS);
                _.Move(V1AUTARIPROP.V1TAPR_TPCPZSEG, V1TAPR_TPCPZSEG);
                _.Move(V1AUTARIPROP.V1TAPR_TPRBRCDM, V1TAPR_TPRBRCDM);
                _.Move(V1AUTARIPROP.V1TAPR_TCFPBRDM, V1TAPR_TCFPBRDM);
                _.Move(V1AUTARIPROP.V1TAPR_TPRBRCDP, V1TAPR_TPRBRCDP);
                _.Move(V1AUTARIPROP.V1TAPR_TCFPBRDP, V1TAPR_TCFPBRDP);
                _.Move(V1AUTARIPROP.V1TAPR_TPCBONDM, V1TAPR_TPCBONDM);
                _.Move(V1AUTARIPROP.V1TAPR_TPCBONDP, V1TAPR_TPCBONDP);
                _.Move(V1AUTARIPROP.V1TAPR_TTXAPPM, V1TAPR_TTXAPPM);
                _.Move(V1AUTARIPROP.V1TAPR_TTXAPPI, V1TAPR_TTXAPPI);
                _.Move(V1AUTARIPROP.V1TAPR_TTXAPPA, V1TAPR_TTXAPPA);
                _.Move(V1AUTARIPROP.V1TAPR_TTXAPPD, V1TAPR_TTXAPPD);
                _.Move(V1AUTARIPROP.V1TAPR_TPCDSAPP, V1TAPR_TPCDSAPP);
                _.Move(V1AUTARIPROP.V1TAPR_DATEND, V1TAPR_DATEND);
                _.Move(V1AUTARIPROP.V1TAPR_TPCMAJOR, V1TAPR_TPCMAJOR);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESAUT, V1TAPR_PCDESAUT);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESRCF, V1TAPR_PCDESRCF);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESAPP, V1TAPR_PCDESAPP);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESPLCA, V1TAPR_PCDESPLCA);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESPLRF, V1TAPR_PCDESPLRF);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESPLAP, V1TAPR_PCDESPLAP);
                _.Move(V1AUTARIPROP.V1TAPR_PCAGPLRF, V1TAPR_PCAGPLRF);
                _.Move(V1AUTARIPROP.V1TAPR_PCAGPLAP, V1TAPR_PCAGPLAP);
                _.Move(V1AUTARIPROP.V1TAPR_PCDESACE, V1TAPR_PCDESACE);
                _.Move(V1AUTARIPROP.V1TAPR_PCAGISCASC, V1TAPR_PCAGISCASC);
                _.Move(V1AUTARIPROP.VIND_PCAGISCASC, VIND_PCAGISCASC);
                _.Move(V1AUTARIPROP.V1TAPR_VALOR_AVARIA, V1TAPR_VALOR_AVARIA);
                _.Move(V1AUTARIPROP.V1TAPR_TPCBONDMO, V1TAPR_TPCBONDMO);
                _.Move(V1AUTARIPROP.V1TAPR_TCFPBRDMO, V1TAPR_TCFPBRDMO);
                _.Move(V1AUTARIPROP.V1TAPR_IND_COML, V1TAPR_IND_COML);
                _.Move(V1AUTARIPROP.V1TAPR_PCT_COML, V1TAPR_PCT_COML);
                _.Move(V1AUTARIPROP.V1TAPR_CODUSU, V1TAPR_CODUSU);
                _.Move(V1AUTARIPROP.V1TAPR_IND_VLR_MIN, V1TAPR_IND_VLR_MIN);
            }

        }

        [StopWatch]
        /*" R2220-00-FETCH-V1AUTARIPROP-DB-CLOSE-1 */
        public void R2220_00_FETCH_V1AUTARIPROP_DB_CLOSE_1()
        {
            /*" -1920- EXEC SQL CLOSE V1AUTARIPROP END-EXEC */

            V1AUTARIPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-MONTA-V0AUTOTARIFA-SECTION */
        private void R2230_00_MONTA_V0AUTOTARIFA_SECTION()
        {
            /*" -1943- MOVE '223' TO WNR-EXEC-SQL. */
            _.Move("223", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1944- MOVE V1TAPR-COD-EMPRESA TO V0TARI-COD-EMPRESA */
            _.Move(V1TAPR_COD_EMPRESA, V0TARI_COD_EMPRESA);

            /*" -1945- MOVE WHOST-FONTE TO V0TARI-FONTE */
            _.Move(WHOST_FONTE, V0TARI_FONTE);

            /*" -1946- MOVE WHOST-NRPROPOS TO V0TARI-NRPROPOS */
            _.Move(WHOST_NRPROPOS, V0TARI_NRPROPOS);

            /*" -1948- MOVE V1TAPR-NRITEM TO V0TARI-NRITEM */
            _.Move(V1TAPR_NRITEM, V0TARI_NRITEM);

            /*" -1949- MOVE V1TAPR-DTINIVIG TO WHOST-DTINIVIG */
            _.Move(V1TAPR_DTINIVIG, WHOST_DTINIVIG);

            /*" -1950- MOVE V1ENDO-MOEDA-IMP TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_IMP, WHOST_COD_MOEDA);

            /*" -1951- PERFORM R1200-00-SELECT-V1MOEDA */

            R1200_00_SELECT_V1MOEDA_SECTION();

            /*" -1953- MOVE WHOST-VLCRUZAD TO V1MOED-VLCR-IMP */
            _.Move(WHOST_VLCRUZAD, V1MOED_VLCR_IMP);

            /*" -1954- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

            /*" -1955- PERFORM R1200-00-SELECT-V1MOEDA */

            R1200_00_SELECT_V1MOEDA_SECTION();

            /*" -1957- MOVE WHOST-VLCRUZAD TO V1MOED-VLCR-PRM */
            _.Move(WHOST_VLCRUZAD, V1MOED_VLCR_PRM);

            /*" -1958- MOVE V1TAPR-DTINIVIG TO V0TARI-DTINIVIG */
            _.Move(V1TAPR_DTINIVIG, V0TARI_DTINIVIG);

            /*" -1959- MOVE V1TAPR-DTTERVIG TO V0TARI-DTTERVIG */
            _.Move(V1TAPR_DTTERVIG, V0TARI_DTTERVIG);

            /*" -1960- MOVE V1TAPR-TERCEIXO TO V0TARI-TERCEIXO */
            _.Move(V1TAPR_TERCEIXO, V0TARI_TERCEIXO);

            /*" -1961- MOVE V1TAPR-CATTARIF TO V0TARI-CATTARIF */
            _.Move(V1TAPR_CATTARIF, V0TARI_CATTARIF);

            /*" -1962- MOVE V1TAPR-TIPOCOB TO V0TARI-TIPOCOB */
            _.Move(V1TAPR_TIPOCOB, V0TARI_TIPOCOB);

            /*" -1963- MOVE V1TAPR-REGIAO TO V0TARI-REGIAO */
            _.Move(V1TAPR_REGIAO, V0TARI_REGIAO);

            /*" -1964- MOVE V1TAPR-FRANQFAC TO V0TARI-FRANQFAC */
            _.Move(V1TAPR_FRANQFAC, V0TARI_FRANQFAC);

            /*" -1965- MOVE V1TAPR-CLABONAT TO V0TARI-CLABONAT */
            _.Move(V1TAPR_CLABONAT, V0TARI_CLABONAT);

            /*" -1966- MOVE V1TAPR-PCDESCAT TO V0TARI-PCDESCAT */
            _.Move(V1TAPR_PCDESCAT, V0TARI_PCDESCAT);

            /*" -1967- MOVE V1TAPR-CLABONDM TO V0TARI-CLABONDM */
            _.Move(V1TAPR_CLABONDM, V0TARI_CLABONDM);

            /*" -1968- MOVE V1TAPR-CLABONDP TO V0TARI-CLABONDP */
            _.Move(V1TAPR_CLABONDP, V0TARI_CLABONDP);

            /*" -1969- MOVE V1TAPR-CATTARIR TO V0TARI-CATTARIR */
            _.Move(V1TAPR_CATTARIR, V0TARI_CATTARIR);

            /*" -1970- MOVE V1TAPR-DESCFROT TO V0TARI-DESCFROT */
            _.Move(V1TAPR_DESCFROT, V0TARI_DESCFROT);

            /*" -1971- MOVE V1TAPR-NUMPASSG TO V0TARI-NUMPASSG */
            _.Move(V1TAPR_NUMPASSG, V0TARI_NUMPASSG);

            /*" -1972- MOVE V1TAPR-VRFROBR-IX TO V0TARI-VRFROBR-IX */
            _.Move(V1TAPR_VRFROBR_IX, V0TARI_VRFROBR_IX);

            /*" -1973- MOVE V1TAPR-VRFRFACC-IX TO V0TARI-VRFRFACC-IX */
            _.Move(V1TAPR_VRFRFACC_IX, V0TARI_VRFRFACC_IX);

            /*" -1974- MOVE V1TAPR-VRFRFACA-IX TO V0TARI-VRFRFACA-IX */
            _.Move(V1TAPR_VRFRFACA_IX, V0TARI_VRFRFACA_IX);

            /*" -1975- MOVE V1TAPR-VRFRADIC-IX TO V0TARI-VRFRADIC-IX */
            _.Move(V1TAPR_VRFRADIC_IX, V0TARI_VRFRADIC_IX);

            /*" -1976- MOVE V1TAPR-VRPRREF TO V0TARI-VRPRREF */
            _.Move(V1TAPR_VRPRREF, V0TARI_VRPRREF);

            /*" -1977- MOVE V1TAPR-CFFROBR TO V0TARI-CFFROBR */
            _.Move(V1TAPR_CFFROBR, V0TARI_CFFROBR);

            /*" -1978- MOVE V1TAPR-CFFRFACC TO V0TARI-CFFRFACC */
            _.Move(V1TAPR_CFFRFACC, V0TARI_CFFRFACC);

            /*" -1979- MOVE V1TAPR-CFFRFACA TO V0TARI-CFFRFACA */
            _.Move(V1TAPR_CFFRFACA, V0TARI_CFFRFACA);

            /*" -1980- MOVE V1TAPR-CFPRREF TO V0TARI-CFPRREF */
            _.Move(V1TAPR_CFPRREF, V0TARI_CFPRREF);

            /*" -1981- MOVE V1TAPR-PCDSCFRF TO V0TARI-PCDSCFRF */
            _.Move(V1TAPR_PCDSCFRF, V0TARI_PCDSCFRF);

            /*" -1982- MOVE V1TAPR-PCISCASC TO V0TARI-PCISCASC */
            _.Move(V1TAPR_PCISCASC, V0TARI_PCISCASC);

            /*" -1983- MOVE V1TAPR-PCINCROU TO V0TARI-PCINCROU */
            _.Move(V1TAPR_PCINCROU, V0TARI_PCINCROU);

            /*" -1984- MOVE V1TAPR-PCAGPLCA TO V0TARI-PCAGPLCA */
            _.Move(V1TAPR_PCAGPLCA, V0TARI_PCAGPLCA);

            /*" -1985- MOVE V1TAPR-PCAGPLAC TO V0TARI-PCAGPLAC */
            _.Move(V1TAPR_PCAGPLAC, V0TARI_PCAGPLAC);

            /*" -1986- MOVE V1TAPR-VRPRRFDM TO V0TARI-VRPRRFDM */
            _.Move(V1TAPR_VRPRRFDM, V0TARI_VRPRRFDM);

            /*" -1987- MOVE V1TAPR-VRPRRFDP TO V0TARI-VRPRRFDP */
            _.Move(V1TAPR_VRPRRFDP, V0TARI_VRPRRFDP);

            /*" -1988- MOVE V1TAPR-EXTPER TO V0TARI-EXTPER */
            _.Move(V1TAPR_EXTPER, V0TARI_EXTPER);

            /*" -1989- MOVE V1TAPR-PERIODO TO V0TARI-PERIODO */
            _.Move(V1TAPR_PERIODO, V0TARI_PERIODO);

            /*" -1990- MOVE V1TAPR-PCFRADIC TO V0TARI-PCFRADIC */
            _.Move(V1TAPR_PCFRADIC, V0TARI_PCFRADIC);

            /*" -1991- MOVE V1TAPR-PRAZOSEG TO V0TARI-PRAZOSEG */
            _.Move(V1TAPR_PRAZOSEG, V0TARI_PRAZOSEG);

            /*" -1992- MOVE V1TAPR-DESCIDAD TO V0TARI-DESCIDAD */
            _.Move(V1TAPR_DESCIDAD, V0TARI_DESCIDAD);

            /*" -1993- MOVE V1TAPR-TCFAPLPR TO V0TARI-TCFAPLPR */
            _.Move(V1TAPR_TCFAPLPR, V0TARI_TCFAPLPR);

            /*" -1994- MOVE V1TAPR-TPCDSFRF TO V0TARI-TPCDSFRF */
            _.Move(V1TAPR_TPCDSFRF, V0TARI_TPCDSFRF);

            /*" -1995- MOVE V1TAPR-TPCDSBAU TO V0TARI-TPCDSBAU */
            _.Move(V1TAPR_TPCDSBAU, V0TARI_TPCDSBAU);

            /*" -1996- MOVE V1TAPR-TTXAPLIS TO V0TARI-TTXAPLIS */
            _.Move(V1TAPR_TTXAPLIS, V0TARI_TTXAPLIS);

            /*" -1997- MOVE V1TAPR-TPCPZSEG TO V0TARI-TPCPZSEG */
            _.Move(V1TAPR_TPCPZSEG, V0TARI_TPCPZSEG);

            /*" -1998- MOVE V1TAPR-TPRBRCDM TO V0TARI-TPRBRCDM */
            _.Move(V1TAPR_TPRBRCDM, V0TARI_TPRBRCDM);

            /*" -1999- MOVE V1TAPR-TCFPBRDM TO V0TARI-TCFPBRDM */
            _.Move(V1TAPR_TCFPBRDM, V0TARI_TCFPBRDM);

            /*" -2000- MOVE V1TAPR-TPRBRCDP TO V0TARI-TPRBRCDP */
            _.Move(V1TAPR_TPRBRCDP, V0TARI_TPRBRCDP);

            /*" -2001- MOVE V1TAPR-TCFPBRDP TO V0TARI-TCFPBRDP */
            _.Move(V1TAPR_TCFPBRDP, V0TARI_TCFPBRDP);

            /*" -2002- MOVE V1TAPR-TPCBONDM TO V0TARI-TPCBONDM */
            _.Move(V1TAPR_TPCBONDM, V0TARI_TPCBONDM);

            /*" -2003- MOVE V1TAPR-TPCBONDP TO V0TARI-TPCBONDP */
            _.Move(V1TAPR_TPCBONDP, V0TARI_TPCBONDP);

            /*" -2004- MOVE V1TAPR-TTXAPPM TO V0TARI-TTXAPPM */
            _.Move(V1TAPR_TTXAPPM, V0TARI_TTXAPPM);

            /*" -2005- MOVE V1TAPR-TTXAPPI TO V0TARI-TTXAPPI */
            _.Move(V1TAPR_TTXAPPI, V0TARI_TTXAPPI);

            /*" -2006- MOVE V1TAPR-TTXAPPA TO V0TARI-TTXAPPA */
            _.Move(V1TAPR_TTXAPPA, V0TARI_TTXAPPA);

            /*" -2007- MOVE V1TAPR-TTXAPPD TO V0TARI-TTXAPPD */
            _.Move(V1TAPR_TTXAPPD, V0TARI_TTXAPPD);

            /*" -2008- MOVE V1TAPR-TPCDSAPP TO V0TARI-TPCDSAPP */
            _.Move(V1TAPR_TPCDSAPP, V0TARI_TPCDSAPP);

            /*" -2009- MOVE V1TAPR-DATEND TO V0TARI-DATEND */
            _.Move(V1TAPR_DATEND, V0TARI_DATEND);

            /*" -2010- MOVE V1TAPR-TPCMAJOR TO V0TARI-TPCMAJOR */
            _.Move(V1TAPR_TPCMAJOR, V0TARI_TPCMAJOR);

            /*" -2011- MOVE V1TAPR-PCDESAUT TO V0TARI-PCDESAUT */
            _.Move(V1TAPR_PCDESAUT, V0TARI_PCDESAUT);

            /*" -2012- MOVE V1TAPR-PCDESRCF TO V0TARI-PCDESRCF */
            _.Move(V1TAPR_PCDESRCF, V0TARI_PCDESRCF);

            /*" -2013- MOVE V1TAPR-PCDESAPP TO V0TARI-PCDESAPP */
            _.Move(V1TAPR_PCDESAPP, V0TARI_PCDESAPP);

            /*" -2014- MOVE V1TAPR-PCDESPLCA TO V0TARI-PCDESPLCA */
            _.Move(V1TAPR_PCDESPLCA, V0TARI_PCDESPLCA);

            /*" -2015- MOVE V1TAPR-PCDESPLRF TO V0TARI-PCDESPLRF */
            _.Move(V1TAPR_PCDESPLRF, V0TARI_PCDESPLRF);

            /*" -2016- MOVE V1TAPR-PCDESPLAP TO V0TARI-PCDESPLAP */
            _.Move(V1TAPR_PCDESPLAP, V0TARI_PCDESPLAP);

            /*" -2017- MOVE V1TAPR-PCAGPLRF TO V0TARI-PCAGPLRF */
            _.Move(V1TAPR_PCAGPLRF, V0TARI_PCAGPLRF);

            /*" -2018- MOVE V1TAPR-PCAGPLAP TO V0TARI-PCAGPLAP */
            _.Move(V1TAPR_PCAGPLAP, V0TARI_PCAGPLAP);

            /*" -2019- MOVE V1TAPR-PCDESACE TO V0TARI-PCDESACE */
            _.Move(V1TAPR_PCDESACE, V0TARI_PCDESACE);

            /*" -2020- MOVE WHOST-NUM-APOL TO V0TARI-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0TARI_NUM_APOL);

            /*" -2021- MOVE WHOST-NRENDOS TO V0TARI-NRENDOS */
            _.Move(WHOST_NRENDOS, V0TARI_NRENDOS);

            /*" -2022- MOVE V1TAPR-PCAGISCASC TO V0TARI-PCAGISCASC. */
            _.Move(V1TAPR_PCAGISCASC, V0TARI_PCAGISCASC);

            /*" -2023- MOVE V1TAPR-VALOR-AVARIA TO V0TARI-VALOR-AVARIA */
            _.Move(V1TAPR_VALOR_AVARIA, V0TARI_VALOR_AVARIA);

            /*" -2024- MOVE V1TAPR-TPCBONDMO TO V0TARI-TPCBONDMO. */
            _.Move(V1TAPR_TPCBONDMO, V0TARI_TPCBONDMO);

            /*" -2025- MOVE V1TAPR-TCFPBRDMO TO V0TARI-TCFPBRDMO. */
            _.Move(V1TAPR_TCFPBRDMO, V0TARI_TCFPBRDMO);

            /*" -2026- MOVE V1TAPR-IND-COML TO V0TARI-IND-COML. */
            _.Move(V1TAPR_IND_COML, V0TARI_IND_COML);

            /*" -2027- MOVE V1TAPR-PCT-COML TO V0TARI-PCT-COML. */
            _.Move(V1TAPR_PCT_COML, V0TARI_PCT_COML);

            /*" -2028- MOVE V1TAPR-CODUSU TO V0TARI-CODUSU. */
            _.Move(V1TAPR_CODUSU, V0TARI_CODUSU);

            /*" -2028- MOVE V1TAPR-IND-VLR-MIN TO V0TARI-IND-VLR-MIN. */
            _.Move(V1TAPR_IND_VLR_MIN, V0TARI_IND_VLR_MIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DECLARE-V1AUTCOBPROP-SECTION */
        private void R2300_00_DECLARE_V1AUTCOBPROP_SECTION()
        {
            /*" -2042- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2066- PERFORM R2300_00_DECLARE_V1AUTCOBPROP_DB_DECLARE_1 */

            R2300_00_DECLARE_V1AUTCOBPROP_DB_DECLARE_1();

            /*" -2068- PERFORM R2300_00_DECLARE_V1AUTCOBPROP_DB_OPEN_1 */

            R2300_00_DECLARE_V1AUTCOBPROP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2300-00-DECLARE-V1AUTCOBPROP-DB-OPEN-1 */
        public void R2300_00_DECLARE_V1AUTCOBPROP_DB_OPEN_1()
        {
            /*" -2068- EXEC SQL OPEN V1AUTCOBPROP END-EXEC. */

            V1AUTCOBPROP.Open();

        }

        [StopWatch]
        /*" R2400-00-DECLARE-V1PROPACES-DB-DECLARE-1 */
        public void R2400_00_DECLARE_V1PROPACES_DB_DECLARE_1()
        {
            /*" -2235- EXEC SQL DECLARE V1PROPACES CURSOR FOR SELECT FONTE, NRPROPOS, NRITEM, CDACESS, VRACESS, DTINIVIG, DTTERVIG, VRPLACES, VRPAACES, VRPLAACE, VRPRBACE, TPMOVTO, TTXISACE, IDEACESS FROM SEGUROS.V1PROPACESS WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY FONTE, NRPROPOS, NRITEM END-EXEC. */
            V1PROPACES = new EM0910S_V1PROPACES(true);
            string GetQuery_V1PROPACES()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS
							, 
							NRITEM
							, 
							CDACESS
							, 
							VRACESS
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							VRPLACES
							, 
							VRPAACES
							, 
							VRPLAACE
							, 
							VRPRBACE
							, 
							TPMOVTO
							, 
							TTXISACE
							, 
							IDEACESS 
							FROM SEGUROS.V1PROPACESS 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							NRITEM";

                return query;
            }
            V1PROPACES.GetQueryEvent += GetQuery_V1PROPACES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-INCLUI-V0AUTOCOBER-SECTION */
        private void R2310_00_INCLUI_V0AUTOCOBER_SECTION()
        {
            /*" -2080- PERFORM R2320-00-FETCH-V1AUTCOBPROP */

            R2320_00_FETCH_V1AUTCOBPROP_SECTION();

            /*" -2081- IF WFIM-V1AUTCOBPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AUTCOBPROP.IsEmpty())
            {

                /*" -2083- GO TO R2310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2085- PERFORM R2330-00-MONTA-V0AUTOCOBER */

            R2330_00_MONTA_V0AUTOCOBER_SECTION();

            /*" -2088- MOVE '231' TO WNR-EXEC-SQL. */
            _.Move("231", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2111- PERFORM R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1 */

            R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1();

            /*" -2114- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2116- MOVE 'V0AUTOCOBER (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0AUTOCOBER (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2118- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2119- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2121- MOVE 'V0AUTOCOBER (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0AUTOCOBER (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2123- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2123- ADD 1 TO AC-I-AUTOCOBER. */
            AREA_DE_WORK.AC_I_AUTOCOBER.Value = AREA_DE_WORK.AC_I_AUTOCOBER + 1;

        }

        [StopWatch]
        /*" R2310-00-INCLUI-V0AUTOCOBER-DB-INSERT-1 */
        public void R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1()
        {
            /*" -2111- EXEC SQL INSERT INTO SEGUROS.V0AUTOCOBER VALUES (:V0AUCB-COD-EMPRESA, :V0AUCB-FONTE , :V0AUCB-NRPROPOS , :V0AUCB-NRITEM , :V0AUCB-RAMOFR , :V0AUCB-MODALIFR , :V0AUCB-COD-COBER , :V0AUCB-DTINIVIG , :V0AUCB-DTTERVIG , :V0AUCB-IMP-SEG-IX , :V0AUCB-IMP-SEG-VR , :V0AUCB-TAXA-IS , :V0AUCB-PRM-ANU-IX , :V0AUCB-PRM-TAR-IX , :V0AUCB-PRM-TAR-VR , :V0AUCB-SITUACAO , :V0AUCB-NUM-APOL , :V0AUCB-NRENDOS , CURRENT TIMESTAMP , NULL, NULL) END-EXEC. */

            var r2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1 = new R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1()
            {
                V0AUCB_COD_EMPRESA = V0AUCB_COD_EMPRESA.ToString(),
                V0AUCB_FONTE = V0AUCB_FONTE.ToString(),
                V0AUCB_NRPROPOS = V0AUCB_NRPROPOS.ToString(),
                V0AUCB_NRITEM = V0AUCB_NRITEM.ToString(),
                V0AUCB_RAMOFR = V0AUCB_RAMOFR.ToString(),
                V0AUCB_MODALIFR = V0AUCB_MODALIFR.ToString(),
                V0AUCB_COD_COBER = V0AUCB_COD_COBER.ToString(),
                V0AUCB_DTINIVIG = V0AUCB_DTINIVIG.ToString(),
                V0AUCB_DTTERVIG = V0AUCB_DTTERVIG.ToString(),
                V0AUCB_IMP_SEG_IX = V0AUCB_IMP_SEG_IX.ToString(),
                V0AUCB_IMP_SEG_VR = V0AUCB_IMP_SEG_VR.ToString(),
                V0AUCB_TAXA_IS = V0AUCB_TAXA_IS.ToString(),
                V0AUCB_PRM_ANU_IX = V0AUCB_PRM_ANU_IX.ToString(),
                V0AUCB_PRM_TAR_IX = V0AUCB_PRM_TAR_IX.ToString(),
                V0AUCB_PRM_TAR_VR = V0AUCB_PRM_TAR_VR.ToString(),
                V0AUCB_SITUACAO = V0AUCB_SITUACAO.ToString(),
                V0AUCB_NUM_APOL = V0AUCB_NUM_APOL.ToString(),
                V0AUCB_NRENDOS = V0AUCB_NRENDOS.ToString(),
            };

            R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1.Execute(r2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-FETCH-V1AUTCOBPROP-SECTION */
        private void R2320_00_FETCH_V1AUTCOBPROP_SECTION()
        {
            /*" -2137- MOVE '232' TO WNR-EXEC-SQL. */
            _.Move("232", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2154- PERFORM R2320_00_FETCH_V1AUTCOBPROP_DB_FETCH_1 */

            R2320_00_FETCH_V1AUTCOBPROP_DB_FETCH_1();

            /*" -2159- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2160- MOVE 'S' TO WFIM-V1AUTCOBPROP */
                _.Move("S", AREA_DE_WORK.WFIM_V1AUTCOBPROP);

                /*" -2160- PERFORM R2320_00_FETCH_V1AUTCOBPROP_DB_CLOSE_1 */

                R2320_00_FETCH_V1AUTCOBPROP_DB_CLOSE_1();

                /*" -2163- GO TO R2320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2164- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2167- DISPLAY 'PROBLEMAS NO FETCH (V1AUTOCOBERPROP) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                $"PROBLEMAS NO FETCH (V1AUTOCOBERPROP) ...  {WHOST_FONTE} {WHOST_NRPROPOS}"
                .Display();

                /*" -2169- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2169- ADD 1 TO AC-S-AUTOCOBERP. */
            AREA_DE_WORK.AC_S_AUTOCOBERP.Value = AREA_DE_WORK.AC_S_AUTOCOBERP + 1;

        }

        [StopWatch]
        /*" R2320-00-FETCH-V1AUTCOBPROP-DB-FETCH-1 */
        public void R2320_00_FETCH_V1AUTCOBPROP_DB_FETCH_1()
        {
            /*" -2154- EXEC SQL FETCH V1AUTCOBPROP INTO :V1AUCP-COD-EMPRESA, :V1AUCP-FONTE , :V1AUCP-NRPROPOS , :V1AUCP-NRITEM , :V1AUCP-RAMOFR , :V1AUCP-MODALIFR , :V1AUCP-COD-COBER , :V1AUCP-DTINIVIG , :V1AUCP-DTTERVIG , :V1AUCP-IMP-SEG-IX , :V1AUCP-IMP-SEG-VR , :V1AUCP-TAXA-IS , :V1AUCP-PRM-ANU-IX , :V1AUCP-PRM-TAR-IX , :V1AUCP-PRM-TAR-VR , :V1AUCP-SITUACAO END-EXEC. */

            if (V1AUTCOBPROP.Fetch())
            {
                _.Move(V1AUTCOBPROP.V1AUCP_COD_EMPRESA, V1AUCP_COD_EMPRESA);
                _.Move(V1AUTCOBPROP.V1AUCP_FONTE, V1AUCP_FONTE);
                _.Move(V1AUTCOBPROP.V1AUCP_NRPROPOS, V1AUCP_NRPROPOS);
                _.Move(V1AUTCOBPROP.V1AUCP_NRITEM, V1AUCP_NRITEM);
                _.Move(V1AUTCOBPROP.V1AUCP_RAMOFR, V1AUCP_RAMOFR);
                _.Move(V1AUTCOBPROP.V1AUCP_MODALIFR, V1AUCP_MODALIFR);
                _.Move(V1AUTCOBPROP.V1AUCP_COD_COBER, V1AUCP_COD_COBER);
                _.Move(V1AUTCOBPROP.V1AUCP_DTINIVIG, V1AUCP_DTINIVIG);
                _.Move(V1AUTCOBPROP.V1AUCP_DTTERVIG, V1AUCP_DTTERVIG);
                _.Move(V1AUTCOBPROP.V1AUCP_IMP_SEG_IX, V1AUCP_IMP_SEG_IX);
                _.Move(V1AUTCOBPROP.V1AUCP_IMP_SEG_VR, V1AUCP_IMP_SEG_VR);
                _.Move(V1AUTCOBPROP.V1AUCP_TAXA_IS, V1AUCP_TAXA_IS);
                _.Move(V1AUTCOBPROP.V1AUCP_PRM_ANU_IX, V1AUCP_PRM_ANU_IX);
                _.Move(V1AUTCOBPROP.V1AUCP_PRM_TAR_IX, V1AUCP_PRM_TAR_IX);
                _.Move(V1AUTCOBPROP.V1AUCP_PRM_TAR_VR, V1AUCP_PRM_TAR_VR);
                _.Move(V1AUTCOBPROP.V1AUCP_SITUACAO, V1AUCP_SITUACAO);
            }

        }

        [StopWatch]
        /*" R2320-00-FETCH-V1AUTCOBPROP-DB-CLOSE-1 */
        public void R2320_00_FETCH_V1AUTCOBPROP_DB_CLOSE_1()
        {
            /*" -2160- EXEC SQL CLOSE V1AUTCOBPROP END-EXEC */

            V1AUTCOBPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2330-00-MONTA-V0AUTOCOBER-SECTION */
        private void R2330_00_MONTA_V0AUTOCOBER_SECTION()
        {
            /*" -2183- MOVE '233' TO WNR-EXEC-SQL. */
            _.Move("233", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2184- MOVE V1AUCP-COD-EMPRESA TO V0AUCB-COD-EMPRESA */
            _.Move(V1AUCP_COD_EMPRESA, V0AUCB_COD_EMPRESA);

            /*" -2185- MOVE WHOST-FONTE TO V0AUCB-FONTE */
            _.Move(WHOST_FONTE, V0AUCB_FONTE);

            /*" -2186- MOVE WHOST-NRPROPOS TO V0AUCB-NRPROPOS */
            _.Move(WHOST_NRPROPOS, V0AUCB_NRPROPOS);

            /*" -2187- MOVE V1AUCP-NRITEM TO V0AUCB-NRITEM */
            _.Move(V1AUCP_NRITEM, V0AUCB_NRITEM);

            /*" -2188- MOVE V1AUCP-RAMOFR TO V0AUCB-RAMOFR */
            _.Move(V1AUCP_RAMOFR, V0AUCB_RAMOFR);

            /*" -2189- MOVE V1AUCP-MODALIFR TO V0AUCB-MODALIFR */
            _.Move(V1AUCP_MODALIFR, V0AUCB_MODALIFR);

            /*" -2190- MOVE V1AUCP-COD-COBER TO V0AUCB-COD-COBER */
            _.Move(V1AUCP_COD_COBER, V0AUCB_COD_COBER);

            /*" -2191- MOVE V1AUCP-DTINIVIG TO V0AUCB-DTINIVIG */
            _.Move(V1AUCP_DTINIVIG, V0AUCB_DTINIVIG);

            /*" -2192- MOVE V1AUCP-DTTERVIG TO V0AUCB-DTTERVIG */
            _.Move(V1AUCP_DTTERVIG, V0AUCB_DTTERVIG);

            /*" -2193- MOVE V1AUCP-IMP-SEG-IX TO V0AUCB-IMP-SEG-IX */
            _.Move(V1AUCP_IMP_SEG_IX, V0AUCB_IMP_SEG_IX);

            /*" -2194- MOVE V1AUCP-IMP-SEG-VR TO V0AUCB-IMP-SEG-VR */
            _.Move(V1AUCP_IMP_SEG_VR, V0AUCB_IMP_SEG_VR);

            /*" -2195- MOVE V1AUCP-TAXA-IS TO V0AUCB-TAXA-IS */
            _.Move(V1AUCP_TAXA_IS, V0AUCB_TAXA_IS);

            /*" -2196- MOVE V1AUCP-PRM-ANU-IX TO V0AUCB-PRM-ANU-IX */
            _.Move(V1AUCP_PRM_ANU_IX, V0AUCB_PRM_ANU_IX);

            /*" -2197- MOVE V1AUCP-PRM-TAR-IX TO V0AUCB-PRM-TAR-IX */
            _.Move(V1AUCP_PRM_TAR_IX, V0AUCB_PRM_TAR_IX);

            /*" -2198- MOVE V1AUCP-PRM-TAR-VR TO V0AUCB-PRM-TAR-VR */
            _.Move(V1AUCP_PRM_TAR_VR, V0AUCB_PRM_TAR_VR);

            /*" -2199- MOVE V1AUCP-SITUACAO TO V0AUCB-SITUACAO */
            _.Move(V1AUCP_SITUACAO, V0AUCB_SITUACAO);

            /*" -2200- MOVE WHOST-NUM-APOL TO V0AUCB-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0AUCB_NUM_APOL);

            /*" -2200- MOVE WHOST-NRENDOS TO V0AUCB-NRENDOS. */
            _.Move(WHOST_NRENDOS, V0AUCB_NRENDOS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2330_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-DECLARE-V1PROPACES-SECTION */
        private void R2400_00_DECLARE_V1PROPACES_SECTION()
        {
            /*" -2214- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2235- PERFORM R2400_00_DECLARE_V1PROPACES_DB_DECLARE_1 */

            R2400_00_DECLARE_V1PROPACES_DB_DECLARE_1();

            /*" -2237- PERFORM R2400_00_DECLARE_V1PROPACES_DB_OPEN_1 */

            R2400_00_DECLARE_V1PROPACES_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2400-00-DECLARE-V1PROPACES-DB-OPEN-1 */
        public void R2400_00_DECLARE_V1PROPACES_DB_OPEN_1()
        {
            /*" -2237- EXEC SQL OPEN V1PROPACES END-EXEC. */

            V1PROPACES.Open();

        }

        [StopWatch]
        /*" R2500-00-DECLARE-V1PROPCLAU-DB-DECLARE-1 */
        public void R2500_00_DECLARE_V1PROPCLAU_DB_DECLARE_1()
        {
            /*" -2397- EXEC SQL DECLARE V1PROPCLAU CURSOR FOR SELECT FONTE, NRPROPOS, NRITEM, CODCLAUS, TIPOCLAU, TPMOVTO, COD_EMPRESA FROM SEGUROS.V1PROPCLAU WHERE FONTE = :WHOST-FONTE AND NRPROPOS = :WHOST-NRPROPOS ORDER BY FONTE, NRPROPOS, NRITEM END-EXEC. */
            V1PROPCLAU = new EM0910S_V1PROPCLAU(true);
            string GetQuery_V1PROPCLAU()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS
							, 
							NRITEM
							, 
							CODCLAUS
							, 
							TIPOCLAU
							, 
							TPMOVTO
							, 
							COD_EMPRESA 
							FROM SEGUROS.V1PROPCLAU 
							WHERE FONTE = '{WHOST_FONTE}' 
							AND NRPROPOS = '{WHOST_NRPROPOS}' 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							NRITEM";

                return query;
            }
            V1PROPCLAU.GetQueryEvent += GetQuery_V1PROPCLAU;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-INCLUI-V0APOLACES-SECTION */
        private void R2410_00_INCLUI_V0APOLACES_SECTION()
        {
            /*" -2249- PERFORM R2420-00-FETCH-V1PROPACES */

            R2420_00_FETCH_V1PROPACES_SECTION();

            /*" -2250- IF WFIM-V1PROPACES NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPACES.IsEmpty())
            {

                /*" -2252- GO TO R2410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2254- PERFORM R2430-00-MONTA-V0APOLACES */

            R2430_00_MONTA_V0APOLACES_SECTION();

            /*" -2257- MOVE '221' TO WNR-EXEC-SQL. */
            _.Move("221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2278- PERFORM R2410_00_INCLUI_V0APOLACES_DB_INSERT_1 */

            R2410_00_INCLUI_V0APOLACES_DB_INSERT_1();

            /*" -2281- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2283- MOVE 'V0APOLACES (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0APOLACES (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2285- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2286- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2288- MOVE 'V0APOLACES (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0APOLACES (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2290- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2290- ADD 1 TO AC-I-APOLACESS. */
            AREA_DE_WORK.AC_I_APOLACESS.Value = AREA_DE_WORK.AC_I_APOLACESS + 1;

        }

        [StopWatch]
        /*" R2410-00-INCLUI-V0APOLACES-DB-INSERT-1 */
        public void R2410_00_INCLUI_V0APOLACES_DB_INSERT_1()
        {
            /*" -2278- EXEC SQL INSERT INTO SEGUROS.V0APOLACESS VALUES (:V0APAC-NUM-APOL, :V0APAC-NRITEM, :V0APAC-NRENDOS, :V0APAC-CDACESS, :V0APAC-DTINIVIG, :V0APAC-DTTERVIG, :V0APAC-VRACESS, :V0APAC-VRPLACES, :V0APAC-VRPAACES, :V0APAC-VRPLAACE, :V0APAC-VRPRBACE, :V0APAC-TTXISACE, :V0APAC-TPMOVTO, :V0APAC-OTNACE, :V0APAC-PREACEBT, :V0APAC-COD-EMPRESA, CURRENT TIMESTAMP, :V0APAC-IDEACESS:VIND-IDEACESS) END-EXEC. */

            var r2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1 = new R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1()
            {
                V0APAC_NUM_APOL = V0APAC_NUM_APOL.ToString(),
                V0APAC_NRITEM = V0APAC_NRITEM.ToString(),
                V0APAC_NRENDOS = V0APAC_NRENDOS.ToString(),
                V0APAC_CDACESS = V0APAC_CDACESS.ToString(),
                V0APAC_DTINIVIG = V0APAC_DTINIVIG.ToString(),
                V0APAC_DTTERVIG = V0APAC_DTTERVIG.ToString(),
                V0APAC_VRACESS = V0APAC_VRACESS.ToString(),
                V0APAC_VRPLACES = V0APAC_VRPLACES.ToString(),
                V0APAC_VRPAACES = V0APAC_VRPAACES.ToString(),
                V0APAC_VRPLAACE = V0APAC_VRPLAACE.ToString(),
                V0APAC_VRPRBACE = V0APAC_VRPRBACE.ToString(),
                V0APAC_TTXISACE = V0APAC_TTXISACE.ToString(),
                V0APAC_TPMOVTO = V0APAC_TPMOVTO.ToString(),
                V0APAC_OTNACE = V0APAC_OTNACE.ToString(),
                V0APAC_PREACEBT = V0APAC_PREACEBT.ToString(),
                V0APAC_COD_EMPRESA = V0APAC_COD_EMPRESA.ToString(),
                V0APAC_IDEACESS = V0APAC_IDEACESS.ToString(),
                VIND_IDEACESS = VIND_IDEACESS.ToString(),
            };

            R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1.Execute(r2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2420-00-FETCH-V1PROPACES-SECTION */
        private void R2420_00_FETCH_V1PROPACES_SECTION()
        {
            /*" -2304- MOVE '242' TO WNR-EXEC-SQL. */
            _.Move("242", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2319- PERFORM R2420_00_FETCH_V1PROPACES_DB_FETCH_1 */

            R2420_00_FETCH_V1PROPACES_DB_FETCH_1();

            /*" -2322- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2323- MOVE 'S' TO WFIM-V1PROPACES */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPACES);

                /*" -2323- PERFORM R2420_00_FETCH_V1PROPACES_DB_CLOSE_1 */

                R2420_00_FETCH_V1PROPACES_DB_CLOSE_1();

                /*" -2325- ADD 1 TO AC-S-PROPACESS. */
                AREA_DE_WORK.AC_S_PROPACESS.Value = AREA_DE_WORK.AC_S_PROPACESS + 1;
            }


        }

        [StopWatch]
        /*" R2420-00-FETCH-V1PROPACES-DB-FETCH-1 */
        public void R2420_00_FETCH_V1PROPACES_DB_FETCH_1()
        {
            /*" -2319- EXEC SQL FETCH V1PROPACES INTO :V1PRAC-FONTE, :V1PRAC-NRPROPOS, :V1PRAC-NRITEM, :V1PRAC-CDACESS, :V1PRAC-VRACESS, :V1PRAC-DTINIVIG, :V1PRAC-DTTERVIG, :V1PRAC-VRPLACES, :V1PRAC-VRPAACES, :V1PRAC-VRPLAACE, :V1PRAC-VRPRBACE, :V1PRAC-TPMOVTO, :V1PRAC-TTXISACE, :V1PRAC-IDEACESS:VIND-IDEACESS END-EXEC. */

            if (V1PROPACES.Fetch())
            {
                _.Move(V1PROPACES.V1PRAC_FONTE, V1PRAC_FONTE);
                _.Move(V1PROPACES.V1PRAC_NRPROPOS, V1PRAC_NRPROPOS);
                _.Move(V1PROPACES.V1PRAC_NRITEM, V1PRAC_NRITEM);
                _.Move(V1PROPACES.V1PRAC_CDACESS, V1PRAC_CDACESS);
                _.Move(V1PROPACES.V1PRAC_VRACESS, V1PRAC_VRACESS);
                _.Move(V1PROPACES.V1PRAC_DTINIVIG, V1PRAC_DTINIVIG);
                _.Move(V1PROPACES.V1PRAC_DTTERVIG, V1PRAC_DTTERVIG);
                _.Move(V1PROPACES.V1PRAC_VRPLACES, V1PRAC_VRPLACES);
                _.Move(V1PROPACES.V1PRAC_VRPAACES, V1PRAC_VRPAACES);
                _.Move(V1PROPACES.V1PRAC_VRPLAACE, V1PRAC_VRPLAACE);
                _.Move(V1PROPACES.V1PRAC_VRPRBACE, V1PRAC_VRPRBACE);
                _.Move(V1PROPACES.V1PRAC_TPMOVTO, V1PRAC_TPMOVTO);
                _.Move(V1PROPACES.V1PRAC_TTXISACE, V1PRAC_TTXISACE);
                _.Move(V1PROPACES.V1PRAC_IDEACESS, V1PRAC_IDEACESS);
                _.Move(V1PROPACES.VIND_IDEACESS, VIND_IDEACESS);
            }

        }

        [StopWatch]
        /*" R2420-00-FETCH-V1PROPACES-DB-CLOSE-1 */
        public void R2420_00_FETCH_V1PROPACES_DB_CLOSE_1()
        {
            /*" -2323- EXEC SQL CLOSE V1PROPACES END-EXEC. */

            V1PROPACES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2430-00-MONTA-V0APOLACES-SECTION */
        private void R2430_00_MONTA_V0APOLACES_SECTION()
        {
            /*" -2339- MOVE '223' TO WNR-EXEC-SQL. */
            _.Move("223", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2340- MOVE V1PRAC-DTINIVIG TO WHOST-DTINIVIG */
            _.Move(V1PRAC_DTINIVIG, WHOST_DTINIVIG);

            /*" -2341- MOVE V1ENDO-MOEDA-PRM TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_PRM, WHOST_COD_MOEDA);

            /*" -2342- PERFORM R1200-00-SELECT-V1MOEDA */

            R1200_00_SELECT_V1MOEDA_SECTION();

            /*" -2344- MOVE WHOST-VLCRUZAD TO V1MOED-VLCR-PRM */
            _.Move(WHOST_VLCRUZAD, V1MOED_VLCR_PRM);

            /*" -2345- MOVE V1ENDO-MOEDA-IMP TO WHOST-COD-MOEDA */
            _.Move(V1ENDO_MOEDA_IMP, WHOST_COD_MOEDA);

            /*" -2346- PERFORM R1200-00-SELECT-V1MOEDA */

            R1200_00_SELECT_V1MOEDA_SECTION();

            /*" -2348- MOVE WHOST-VLCRUZAD TO V1MOED-VLCR-IMP */
            _.Move(WHOST_VLCRUZAD, V1MOED_VLCR_IMP);

            /*" -2349- MOVE WHOST-NUM-APOL TO V0APAC-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APAC_NUM_APOL);

            /*" -2350- MOVE V1PRAC-NRITEM TO V0APAC-NRITEM */
            _.Move(V1PRAC_NRITEM, V0APAC_NRITEM);

            /*" -2351- MOVE WHOST-NRENDOS TO V0APAC-NRENDOS */
            _.Move(WHOST_NRENDOS, V0APAC_NRENDOS);

            /*" -2352- MOVE V1PRAC-CDACESS TO V0APAC-CDACESS */
            _.Move(V1PRAC_CDACESS, V0APAC_CDACESS);

            /*" -2353- MOVE V1PRAC-DTINIVIG TO V0APAC-DTINIVIG */
            _.Move(V1PRAC_DTINIVIG, V0APAC_DTINIVIG);

            /*" -2354- MOVE V1PRAC-DTTERVIG TO V0APAC-DTTERVIG */
            _.Move(V1PRAC_DTTERVIG, V0APAC_DTTERVIG);

            /*" -2355- MOVE V1PRAC-VRACESS TO V0APAC-VRACESS */
            _.Move(V1PRAC_VRACESS, V0APAC_VRACESS);

            /*" -2356- MOVE V1PRAC-VRPLACES TO V0APAC-VRPLACES */
            _.Move(V1PRAC_VRPLACES, V0APAC_VRPLACES);

            /*" -2357- MOVE V1PRAC-VRPAACES TO V0APAC-VRPAACES */
            _.Move(V1PRAC_VRPAACES, V0APAC_VRPAACES);

            /*" -2358- MOVE V1PRAC-VRPLAACE TO V0APAC-VRPLAACE */
            _.Move(V1PRAC_VRPLAACE, V0APAC_VRPLAACE);

            /*" -2359- MOVE V1PRAC-VRPRBACE TO V0APAC-VRPRBACE */
            _.Move(V1PRAC_VRPRBACE, V0APAC_VRPRBACE);

            /*" -2360- MOVE V1PRAC-TTXISACE TO V0APAC-TTXISACE */
            _.Move(V1PRAC_TTXISACE, V0APAC_TTXISACE);

            /*" -2361- MOVE V1PRAC-IDEACESS TO V0APAC-IDEACESS */
            _.Move(V1PRAC_IDEACESS, V0APAC_IDEACESS);

            /*" -2363- MOVE V1PRAC-TPMOVTO TO V0APAC-TPMOVTO */
            _.Move(V1PRAC_TPMOVTO, V0APAC_TPMOVTO);

            /*" -2366- COMPUTE V0APAC-OTNACE = V1PRAC-VRACESS / V1MOED-VLCR-IMP */
            V0APAC_OTNACE.Value = V1PRAC_VRACESS / V1MOED_VLCR_IMP;

            /*" -2369- COMPUTE V0APAC-PREACEBT = V1PRAC-VRPLACES / V1MOED-VLCR-PRM */
            V0APAC_PREACEBT.Value = V1PRAC_VRPLACES / V1MOED_VLCR_PRM;

            /*" -2369- MOVE V1AUPR-COD-EMPRESA TO V0APAC-COD-EMPRESA. */
            _.Move(V1AUPR_COD_EMPRESA, V0APAC_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2430_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-DECLARE-V1PROPCLAU-SECTION */
        private void R2500_00_DECLARE_V1PROPCLAU_SECTION()
        {
            /*" -2383- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2397- PERFORM R2500_00_DECLARE_V1PROPCLAU_DB_DECLARE_1 */

            R2500_00_DECLARE_V1PROPCLAU_DB_DECLARE_1();

            /*" -2399- PERFORM R2500_00_DECLARE_V1PROPCLAU_DB_OPEN_1 */

            R2500_00_DECLARE_V1PROPCLAU_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2500-00-DECLARE-V1PROPCLAU-DB-OPEN-1 */
        public void R2500_00_DECLARE_V1PROPCLAU_DB_OPEN_1()
        {
            /*" -2399- EXEC SQL OPEN V1PROPCLAU END-EXEC. */

            V1PROPCLAU.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-AUPROPCOMPL-DB-DECLARE-1 */
        public void R2600_00_DECLARE_AUPROPCOMPL_DB_DECLARE_1()
        {
            /*" -2528- EXEC SQL DECLARE AUPROPCOMPL CURSOR FOR SELECT COD_FONTE, NUM_PROPOSTA, NUM_ITEM, VALUE (COD_PARCEIRO, 0), VALUE (COD_PONTO_VENDA, 0), NUM_CPF_OPERADOR, STA_RENOVACAO_AUT, STA_ENVIO_SMS, STA_ENVIO_EMAIL, NUM_TOKEN_PGTO, IND_FORMA_PAGTO_AD FROM SEGUROS.AU_PROPOSTA_COMPL WHERE COD_FONTE = :WHOST-FONTE AND NUM_PROPOSTA = :WHOST-NRPROPOS END-EXEC. */
            AUPROPCOMPL = new EM0910S_AUPROPCOMPL(true);
            string GetQuery_AUPROPCOMPL()
            {
                var query = @$"SELECT COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							NUM_ITEM
							, 
							VALUE (COD_PARCEIRO
							, 0)
							, 
							VALUE (COD_PONTO_VENDA
							, 0)
							, 
							NUM_CPF_OPERADOR
							, 
							STA_RENOVACAO_AUT
							, 
							STA_ENVIO_SMS
							, 
							STA_ENVIO_EMAIL
							, 
							NUM_TOKEN_PGTO
							, 
							IND_FORMA_PAGTO_AD 
							FROM SEGUROS.AU_PROPOSTA_COMPL 
							WHERE COD_FONTE = '{WHOST_FONTE}' 
							AND NUM_PROPOSTA = '{WHOST_NRPROPOS}'";

                return query;
            }
            AUPROPCOMPL.GetQueryEvent += GetQuery_AUPROPCOMPL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-INCLUI-V0APOLCLAU-SECTION */
        private void R2510_00_INCLUI_V0APOLCLAU_SECTION()
        {
            /*" -2411- PERFORM R2520-00-FETCH-V1PROPCLAU */

            R2520_00_FETCH_V1PROPCLAU_SECTION();

            /*" -2412- IF WFIM-V1PROPCLAU NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPCLAU.IsEmpty())
            {

                /*" -2414- GO TO R2510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2416- PERFORM R2530-00-MONTA-V0APOLCLAU */

            R2530_00_MONTA_V0APOLCLAU_SECTION();

            /*" -2419- MOVE '251' TO WNR-EXEC-SQL. */
            _.Move("251", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2434- PERFORM R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1 */

            R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1();

            /*" -2437- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2439- MOVE 'V0APOLCLAUS (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0APOLCLAUS (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2441- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2442- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2444- MOVE 'V0APOLCLAUS (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0APOLCLAUS (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2446- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2446- ADD 1 TO AC-I-APOLCLAU. */
            AREA_DE_WORK.AC_I_APOLCLAU.Value = AREA_DE_WORK.AC_I_APOLCLAU + 1;

        }

        [StopWatch]
        /*" R2510-00-INCLUI-V0APOLCLAU-DB-INSERT-1 */
        public void R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1()
        {
            /*" -2434- EXEC SQL INSERT INTO SEGUROS.V0APOLCLAUSULA VALUES (:V0APCL-COD-EMPRESA:VIND-COD-EMP, :V0APCL-NUM-APOL, :V0APCL-NRENDOS, :V0APCL-RAMOFR, :V0APCL-MODALIFR, :V0APCL-COD-COBERT, :V0APCL-DTINIVIG, :V0APCL-DTTERVIG, :V0APCL-NRITEM, :V0APCL-CODCLAUS, :V0APCL-TIPOCLAU, :V0APCL-LIM-IND-IX, CURRENT TIMESTAMP) END-EXEC. */

            var r2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1 = new R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1()
            {
                V0APCL_COD_EMPRESA = V0APCL_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0APCL_NUM_APOL = V0APCL_NUM_APOL.ToString(),
                V0APCL_NRENDOS = V0APCL_NRENDOS.ToString(),
                V0APCL_RAMOFR = V0APCL_RAMOFR.ToString(),
                V0APCL_MODALIFR = V0APCL_MODALIFR.ToString(),
                V0APCL_COD_COBERT = V0APCL_COD_COBERT.ToString(),
                V0APCL_DTINIVIG = V0APCL_DTINIVIG.ToString(),
                V0APCL_DTTERVIG = V0APCL_DTTERVIG.ToString(),
                V0APCL_NRITEM = V0APCL_NRITEM.ToString(),
                V0APCL_CODCLAUS = V0APCL_CODCLAUS.ToString(),
                V0APCL_TIPOCLAU = V0APCL_TIPOCLAU.ToString(),
                V0APCL_LIM_IND_IX = V0APCL_LIM_IND_IX.ToString(),
            };

            R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1.Execute(r2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-FETCH-V1PROPCLAU-SECTION */
        private void R2520_00_FETCH_V1PROPCLAU_SECTION()
        {
            /*" -2460- MOVE '252' TO WNR-EXEC-SQL. */
            _.Move("252", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2468- PERFORM R2520_00_FETCH_V1PROPCLAU_DB_FETCH_1 */

            R2520_00_FETCH_V1PROPCLAU_DB_FETCH_1();

            /*" -2471- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2472- MOVE 'S' TO WFIM-V1PROPCLAU */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPCLAU);

                /*" -2472- PERFORM R2520_00_FETCH_V1PROPCLAU_DB_CLOSE_1 */

                R2520_00_FETCH_V1PROPCLAU_DB_CLOSE_1();

                /*" -2474- ADD 1 TO AC-S-PROPCLAU. */
                AREA_DE_WORK.AC_S_PROPCLAU.Value = AREA_DE_WORK.AC_S_PROPCLAU + 1;
            }


        }

        [StopWatch]
        /*" R2520-00-FETCH-V1PROPCLAU-DB-FETCH-1 */
        public void R2520_00_FETCH_V1PROPCLAU_DB_FETCH_1()
        {
            /*" -2468- EXEC SQL FETCH V1PROPCLAU INTO :V1PRCL-FONTE, :V1PRCL-NRPROPOS, :V1PRCL-NRITEM, :V1PRCL-CODCLAUS, :V1PRCL-TIPOCLAU, :V1PRCL-TPMOVTO, :V1PRCL-COD-EMPRESA:VIND-COD-EMP END-EXEC. */

            if (V1PROPCLAU.Fetch())
            {
                _.Move(V1PROPCLAU.V1PRCL_FONTE, V1PRCL_FONTE);
                _.Move(V1PROPCLAU.V1PRCL_NRPROPOS, V1PRCL_NRPROPOS);
                _.Move(V1PROPCLAU.V1PRCL_NRITEM, V1PRCL_NRITEM);
                _.Move(V1PROPCLAU.V1PRCL_CODCLAUS, V1PRCL_CODCLAUS);
                _.Move(V1PROPCLAU.V1PRCL_TIPOCLAU, V1PRCL_TIPOCLAU);
                _.Move(V1PROPCLAU.V1PRCL_TPMOVTO, V1PRCL_TPMOVTO);
                _.Move(V1PROPCLAU.V1PRCL_COD_EMPRESA, V1PRCL_COD_EMPRESA);
                _.Move(V1PROPCLAU.VIND_COD_EMP, VIND_COD_EMP);
            }

        }

        [StopWatch]
        /*" R2520-00-FETCH-V1PROPCLAU-DB-CLOSE-1 */
        public void R2520_00_FETCH_V1PROPCLAU_DB_CLOSE_1()
        {
            /*" -2472- EXEC SQL CLOSE V1PROPCLAU END-EXEC. */

            V1PROPCLAU.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R2530-00-MONTA-V0APOLCLAU-SECTION */
        private void R2530_00_MONTA_V0APOLCLAU_SECTION()
        {
            /*" -2488- MOVE '253' TO WNR-EXEC-SQL. */
            _.Move("253", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2489- MOVE WHOST-NUM-APOL TO V0APCL-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0APCL_NUM_APOL);

            /*" -2490- MOVE WHOST-NRENDOS TO V0APCL-NRENDOS */
            _.Move(WHOST_NRENDOS, V0APCL_NRENDOS);

            /*" -2491- MOVE ZEROS TO V0APCL-RAMOFR */
            _.Move(0, V0APCL_RAMOFR);

            /*" -2492- MOVE ZEROS TO V0APCL-MODALIFR */
            _.Move(0, V0APCL_MODALIFR);

            /*" -2493- MOVE ZEROS TO V0APCL-COD-COBERT */
            _.Move(0, V0APCL_COD_COBERT);

            /*" -2494- MOVE V1AUPR-DTINIVIG TO V0APCL-DTINIVIG */
            _.Move(V1AUPR_DTINIVIG, V0APCL_DTINIVIG);

            /*" -2495- MOVE V1AUPR-DTTERVIG TO V0APCL-DTTERVIG */
            _.Move(V1AUPR_DTTERVIG, V0APCL_DTTERVIG);

            /*" -2496- MOVE V1PRCL-NRITEM TO V0APCL-NRITEM */
            _.Move(V1PRCL_NRITEM, V0APCL_NRITEM);

            /*" -2497- MOVE V1PRCL-CODCLAUS TO V0APCL-CODCLAUS */
            _.Move(V1PRCL_CODCLAUS, V0APCL_CODCLAUS);

            /*" -2498- MOVE V1PRCL-TIPOCLAU TO V0APCL-TIPOCLAU */
            _.Move(V1PRCL_TIPOCLAU, V0APCL_TIPOCLAU);

            /*" -2499- MOVE ZEROS TO V0APCL-LIM-IND-IX */
            _.Move(0, V0APCL_LIM_IND_IX);

            /*" -2499- MOVE V1PRCL-COD-EMPRESA TO V0APCL-COD-EMPRESA. */
            _.Move(V1PRCL_COD_EMPRESA, V0APCL_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLARE-AUPROPCOMPL-SECTION */
        private void R2600_00_DECLARE_AUPROPCOMPL_SECTION()
        {
            /*" -2513- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2528- PERFORM R2600_00_DECLARE_AUPROPCOMPL_DB_DECLARE_1 */

            R2600_00_DECLARE_AUPROPCOMPL_DB_DECLARE_1();

            /*" -2530- PERFORM R2600_00_DECLARE_AUPROPCOMPL_DB_OPEN_1 */

            R2600_00_DECLARE_AUPROPCOMPL_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-AUPROPCOMPL-DB-OPEN-1 */
        public void R2600_00_DECLARE_AUPROPCOMPL_DB_OPEN_1()
        {
            /*" -2530- EXEC SQL OPEN AUPROPCOMPL END-EXEC. */

            AUPROPCOMPL.Open();

        }

        [StopWatch]
        /*" R4200-00-DECLARE-V1COBERPROP-DB-DECLARE-1 */
        public void R4200_00_DECLARE_V1COBERPROP_DB_DECLARE_1()
        {
            /*" -2835- EXEC SQL DECLARE V1COBERPROP CURSOR FOR SELECT A.FONTE, A.NRPROPOS, A.NRITEM, A.RAMOFR, A.MODALIFR, A.COD_COBERTURA, A.IMP_SEGURADA_IX, A.IMP_SEGURADA_VAR, A.PRM_TARIFARIO_IX, A.PRM_TARIFARIO_VAR, A.DTINIVIG, A.DTTERVIG FROM SEGUROS.V1AUTOCOBERPROP A WHERE A.FONTE = :WHOST-FONTE AND A.NRPROPOS = :WHOST-NRPROPOS AND A.NRITEM = ( SELECT MAX(B.NRITEM) FROM SEGUROS.V1AUTOCOBERPROP B WHERE A.FONTE = B.FONTE AND A.NRPROPOS = B.NRPROPOS ) ORDER BY FONTE, NRPROPOS, RAMOFR, NRITEM END-EXEC. */
            V1COBERPROP = new EM0910S_V1COBERPROP(true);
            string GetQuery_V1COBERPROP()
            {
                var query = @$"SELECT A.FONTE
							, 
							A.NRPROPOS
							, 
							A.NRITEM
							, 
							A.RAMOFR
							, 
							A.MODALIFR
							, 
							A.COD_COBERTURA
							, 
							A.IMP_SEGURADA_IX
							, 
							A.IMP_SEGURADA_VAR
							, 
							A.PRM_TARIFARIO_IX
							, 
							A.PRM_TARIFARIO_VAR
							, 
							A.DTINIVIG
							, 
							A.DTTERVIG 
							FROM SEGUROS.V1AUTOCOBERPROP A 
							WHERE A.FONTE = '{WHOST_FONTE}' 
							AND A.NRPROPOS = '{WHOST_NRPROPOS}' 
							AND A.NRITEM = 
							( SELECT MAX(B.NRITEM) 
							FROM SEGUROS.V1AUTOCOBERPROP B 
							WHERE A.FONTE = B.FONTE 
							AND A.NRPROPOS = B.NRPROPOS ) 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							RAMOFR
							, 
							NRITEM";

                return query;
            }
            V1COBERPROP.GetQueryEvent += GetQuery_V1COBERPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-INCLUI-AUAPOLCOMPL-SECTION */
        private void R2610_00_INCLUI_AUAPOLCOMPL_SECTION()
        {
            /*" -2542- PERFORM R2620-00-FETCH-AUPROPCOMPL */

            R2620_00_FETCH_AUPROPCOMPL_SECTION();

            /*" -2543- IF WFIM-AUPROPCOMP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_AUPROPCOMP.IsEmpty())
            {

                /*" -2545- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2547- PERFORM R2630-00-MONTA-AUAPOLCOMPL */

            R2630_00_MONTA_AUAPOLCOMPL_SECTION();

            /*" -2550- MOVE '261' TO WNR-EXEC-SQL. */
            _.Move("261", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2563- PERFORM R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1 */

            R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1();

            /*" -2566- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2568- MOVE 'AUAPOLCOMPL (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("AUAPOLCOMPL (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2570- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2571- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2573- MOVE 'AUAPOLCOMPL (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("AUAPOLCOMPL (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2575- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2575- ADD 1 TO AC-I-AUAPOLCOMP. */
            AREA_DE_WORK.AC_I_AUAPOLCOMP.Value = AREA_DE_WORK.AC_I_AUAPOLCOMP + 1;

        }

        [StopWatch]
        /*" R2610-00-INCLUI-AUAPOLCOMPL-DB-INSERT-1 */
        public void R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1()
        {
            /*" -2563- EXEC SQL INSERT INTO SEGUROS.AU_APOLICE_COMPL VALUES (:AU084-NUM-APOLICE , :AU084-NUM-ENDOSSO , :AU084-NUM-ITEM , :AU084-COD-PARCEIRO:VIND-PARC , :AU084-COD-PONTO-VENDA:VIND-PTOV, :AU084-NUM-CPF-OPERADOR , :AU084-STA-RENOVACAO-AUT, :AU084-STA-ENVIO-SMS , :AU084-STA-ENVIO-EMAIL , :AU084-NUM-TOKEN-PGTO:VIND-TOKEN , :AU084-IND-FORMA-PAGTO-AD) END-EXEC. */

            var r2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1 = new R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1()
            {
                AU084_NUM_APOLICE = AU084.DCLAU_APOLICE_COMPL.AU084_NUM_APOLICE.ToString(),
                AU084_NUM_ENDOSSO = AU084.DCLAU_APOLICE_COMPL.AU084_NUM_ENDOSSO.ToString(),
                AU084_NUM_ITEM = AU084.DCLAU_APOLICE_COMPL.AU084_NUM_ITEM.ToString(),
                AU084_COD_PARCEIRO = AU084.DCLAU_APOLICE_COMPL.AU084_COD_PARCEIRO.ToString(),
                VIND_PARC = VIND_PARC.ToString(),
                AU084_COD_PONTO_VENDA = AU084.DCLAU_APOLICE_COMPL.AU084_COD_PONTO_VENDA.ToString(),
                VIND_PTOV = VIND_PTOV.ToString(),
                AU084_NUM_CPF_OPERADOR = AU084.DCLAU_APOLICE_COMPL.AU084_NUM_CPF_OPERADOR.ToString(),
                AU084_STA_RENOVACAO_AUT = AU084.DCLAU_APOLICE_COMPL.AU084_STA_RENOVACAO_AUT.ToString(),
                AU084_STA_ENVIO_SMS = AU084.DCLAU_APOLICE_COMPL.AU084_STA_ENVIO_SMS.ToString(),
                AU084_STA_ENVIO_EMAIL = AU084.DCLAU_APOLICE_COMPL.AU084_STA_ENVIO_EMAIL.ToString(),
                AU084_NUM_TOKEN_PGTO = AU084.DCLAU_APOLICE_COMPL.AU084_NUM_TOKEN_PGTO.ToString(),
                VIND_TOKEN = VIND_TOKEN.ToString(),
                AU084_IND_FORMA_PAGTO_AD = AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD.ToString(),
            };

            R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1.Execute(r2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2620-00-FETCH-AUPROPCOMPL-SECTION */
        private void R2620_00_FETCH_AUPROPCOMPL_SECTION()
        {
            /*" -2589- MOVE '262' TO WNR-EXEC-SQL. */
            _.Move("262", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2601- PERFORM R2620_00_FETCH_AUPROPCOMPL_DB_FETCH_1 */

            R2620_00_FETCH_AUPROPCOMPL_DB_FETCH_1();

            /*" -2604- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2605- MOVE 'S' TO WFIM-AUPROPCOMP */
                _.Move("S", AREA_DE_WORK.WFIM_AUPROPCOMP);

                /*" -2605- PERFORM R2620_00_FETCH_AUPROPCOMPL_DB_CLOSE_1 */

                R2620_00_FETCH_AUPROPCOMPL_DB_CLOSE_1();

                /*" -2607- ADD 1 TO AC-S-AUPROPCOMP. */
                AREA_DE_WORK.AC_S_AUPROPCOMP.Value = AREA_DE_WORK.AC_S_AUPROPCOMP + 1;
            }


        }

        [StopWatch]
        /*" R2620-00-FETCH-AUPROPCOMPL-DB-FETCH-1 */
        public void R2620_00_FETCH_AUPROPCOMPL_DB_FETCH_1()
        {
            /*" -2601- EXEC SQL FETCH AUPROPCOMPL INTO :AU085-COD-FONTE , :AU085-NUM-PROPOSTA , :AU085-NUM-ITEM , :AU085-COD-PARCEIRO , :AU085-COD-PONTO-VENDA , :AU085-NUM-CPF-OPERADOR , :AU085-STA-RENOVACAO-AUT, :AU085-STA-ENVIO-SMS , :AU085-STA-ENVIO-EMAIL , :AU085-NUM-TOKEN-PGTO:VIND-TOKEN , :AU085-IND-FORMA-PAGTO-AD END-EXEC. */

            if (AUPROPCOMPL.Fetch())
            {
                _.Move(AUPROPCOMPL.AU085_COD_FONTE, AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_FONTE);
                _.Move(AUPROPCOMPL.AU085_NUM_PROPOSTA, AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_PROPOSTA);
                _.Move(AUPROPCOMPL.AU085_NUM_ITEM, AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_ITEM);
                _.Move(AUPROPCOMPL.AU085_COD_PARCEIRO, AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_PARCEIRO);
                _.Move(AUPROPCOMPL.AU085_COD_PONTO_VENDA, AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_PONTO_VENDA);
                _.Move(AUPROPCOMPL.AU085_NUM_CPF_OPERADOR, AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_CPF_OPERADOR);
                _.Move(AUPROPCOMPL.AU085_STA_RENOVACAO_AUT, AU085.DCLAU_PROPOSTA_COMPL.AU085_STA_RENOVACAO_AUT);
                _.Move(AUPROPCOMPL.AU085_STA_ENVIO_SMS, AU085.DCLAU_PROPOSTA_COMPL.AU085_STA_ENVIO_SMS);
                _.Move(AUPROPCOMPL.AU085_STA_ENVIO_EMAIL, AU085.DCLAU_PROPOSTA_COMPL.AU085_STA_ENVIO_EMAIL);
                _.Move(AUPROPCOMPL.AU085_NUM_TOKEN_PGTO, AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_TOKEN_PGTO);
                _.Move(AUPROPCOMPL.VIND_TOKEN, VIND_TOKEN);
                _.Move(AUPROPCOMPL.AU085_IND_FORMA_PAGTO_AD, AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);
            }

        }

        [StopWatch]
        /*" R2620-00-FETCH-AUPROPCOMPL-DB-CLOSE-1 */
        public void R2620_00_FETCH_AUPROPCOMPL_DB_CLOSE_1()
        {
            /*" -2605- EXEC SQL CLOSE AUPROPCOMPL END-EXEC. */

            AUPROPCOMPL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2620_99_SAIDA*/

        [StopWatch]
        /*" R2630-00-MONTA-AUAPOLCOMPL-SECTION */
        private void R2630_00_MONTA_AUAPOLCOMPL_SECTION()
        {
            /*" -2621- MOVE '263' TO WNR-EXEC-SQL. */
            _.Move("263", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2622- MOVE WHOST-NUM-APOL TO AU084-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, AU084.DCLAU_APOLICE_COMPL.AU084_NUM_APOLICE);

            /*" -2623- MOVE WHOST-NRENDOS TO AU084-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, AU084.DCLAU_APOLICE_COMPL.AU084_NUM_ENDOSSO);

            /*" -2624- MOVE AU085-NUM-ITEM TO AU084-NUM-ITEM */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_ITEM, AU084.DCLAU_APOLICE_COMPL.AU084_NUM_ITEM);

            /*" -2625- MOVE AU085-COD-PARCEIRO TO AU084-COD-PARCEIRO */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_PARCEIRO, AU084.DCLAU_APOLICE_COMPL.AU084_COD_PARCEIRO);

            /*" -2626- IF AU084-COD-PARCEIRO EQUAL ZEROS */

            if (AU084.DCLAU_APOLICE_COMPL.AU084_COD_PARCEIRO == 00)
            {

                /*" -2627- MOVE -1 TO VIND-PARC */
                _.Move(-1, VIND_PARC);

                /*" -2628- ELSE */
            }
            else
            {


                /*" -2629- MOVE +0 TO VIND-PARC */
                _.Move(+0, VIND_PARC);

                /*" -2630- END-IF. */
            }


            /*" -2631- MOVE AU085-COD-PONTO-VENDA TO AU084-COD-PONTO-VENDA */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_PONTO_VENDA, AU084.DCLAU_APOLICE_COMPL.AU084_COD_PONTO_VENDA);

            /*" -2632- IF AU084-COD-PONTO-VENDA EQUAL ZEROS */

            if (AU084.DCLAU_APOLICE_COMPL.AU084_COD_PONTO_VENDA == 00)
            {

                /*" -2633- MOVE -1 TO VIND-PTOV */
                _.Move(-1, VIND_PTOV);

                /*" -2634- ELSE */
            }
            else
            {


                /*" -2635- MOVE +0 TO VIND-PTOV */
                _.Move(+0, VIND_PTOV);

                /*" -2636- END-IF. */
            }


            /*" -2637- MOVE AU085-NUM-CPF-OPERADOR TO AU084-NUM-CPF-OPERADOR */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_CPF_OPERADOR, AU084.DCLAU_APOLICE_COMPL.AU084_NUM_CPF_OPERADOR);

            /*" -2638- MOVE AU085-STA-RENOVACAO-AUT TO AU084-STA-RENOVACAO-AUT */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_STA_RENOVACAO_AUT, AU084.DCLAU_APOLICE_COMPL.AU084_STA_RENOVACAO_AUT);

            /*" -2639- MOVE AU085-STA-ENVIO-SMS TO AU084-STA-ENVIO-SMS. */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_STA_ENVIO_SMS, AU084.DCLAU_APOLICE_COMPL.AU084_STA_ENVIO_SMS);

            /*" -2641- MOVE AU085-STA-ENVIO-EMAIL TO AU084-STA-ENVIO-EMAIL. */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_STA_ENVIO_EMAIL, AU084.DCLAU_APOLICE_COMPL.AU084_STA_ENVIO_EMAIL);

            /*" -2642- MOVE AU085-NUM-TOKEN-PGTO TO AU084-NUM-TOKEN-PGTO. */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_TOKEN_PGTO, AU084.DCLAU_APOLICE_COMPL.AU084_NUM_TOKEN_PGTO);

            /*" -2642- MOVE AU085-IND-FORMA-PAGTO-AD TO AU084-IND-FORMA-PAGTO-AD. */
            _.Move(AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD, AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2630_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-V0EMISDIARIA-SECTION */
        private void R3000_00_MONTA_V0EMISDIARIA_SECTION()
        {
            /*" -2656- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2657- IF V1ENDO-TIPAPO EQUAL '1' OR '3' */

            if (V1ENDO_TIPAPO.In("1", "3"))
            {

                /*" -2658- MOVE 'EM0210B1' TO V0EDIA-CODRELAT */
                _.Move("EM0210B1", V0EDIA_CODRELAT);

                /*" -2659- ELSE */
            }
            else
            {


                /*" -2660- IF WHOST-NRENDOS EQUAL ZEROS */

                if (WHOST_NRENDOS == 00)
                {

                    /*" -2661- MOVE 'EM0212B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0212B1", V0EDIA_CODRELAT);

                    /*" -2662- ELSE */
                }
                else
                {


                    /*" -2666- MOVE 'EM0213B1' TO V0EDIA-CODRELAT. */
                    _.Move("EM0213B1", V0EDIA_CODRELAT);
                }

            }


            /*" -2667- MOVE WHOST-NUM-APOL TO V0EDIA-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0EDIA_NUM_APOL);

            /*" -2668- MOVE WHOST-NRENDOS TO V0EDIA-NRENDOS */
            _.Move(WHOST_NRENDOS, V0EDIA_NRENDOS);

            /*" -2669- MOVE ZEROS TO V0EDIA-NRPARCEL */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -2670- MOVE WHOST-DTMOVABE TO V0EDIA-DTMOVTO */
            _.Move(WHOST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -2671- MOVE V1ENDO-ORGAO TO V0EDIA-ORGAO */
            _.Move(V1ENDO_ORGAO, V0EDIA_ORGAO);

            /*" -2672- MOVE V1ENDO-RAMO TO V0EDIA-RAMO */
            _.Move(V1ENDO_RAMO, V0EDIA_RAMO);

            /*" -2673- MOVE V1ENDO-FONTE TO V0EDIA-FONTE */
            _.Move(V1ENDO_FONTE, V0EDIA_FONTE);

            /*" -2674- MOVE ZEROS TO V0EDIA-CONGENER */
            _.Move(0, V0EDIA_CONGENER);

            /*" -2675- MOVE WHOST-CODCORR TO V0EDIA-CODCORR */
            _.Move(WHOST_CODCORR, V0EDIA_CODCORR);

            /*" -2676- MOVE '0' TO V0EDIA-SITUACAO */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -2677- MOVE V1AUPR-COD-EMPRESA TO V0EDIA-COD-EMPRESA. */
            _.Move(V1AUPR_COD_EMPRESA, V0EDIA_COD_EMPRESA);

            /*" -2685- PERFORM R3100-00-INCLUI-V0EMISDIARIA */

            R3100_00_INCLUI_V0EMISDIARIA_SECTION();

            /*" -2686- MOVE 'EM0241B1' TO V0EDIA-CODRELAT */
            _.Move("EM0241B1", V0EDIA_CODRELAT);

            /*" -2686- PERFORM R3100-00-INCLUI-V0EMISDIARIA. */

            R3100_00_INCLUI_V0EMISDIARIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INCLUI-V0EMISDIARIA-SECTION */
        private void R3100_00_INCLUI_V0EMISDIARIA_SECTION()
        {
            /*" -2700- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2715- PERFORM R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -2718- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2720- MOVE 'V0EMISDIARIA (REGISTRO DUPLICADO)' TO LK-RETORNO */
                _.Move("V0EMISDIARIA (REGISTRO DUPLICADO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2722- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2723- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2725- MOVE 'V0EMISDIARIA (PROBLEMAS INSERCAO)' TO LK-RETORNO */
                _.Move("V0EMISDIARIA (PROBLEMAS INSERCAO)", LK_PROPOSTA.LK_RETORNO);

                /*" -2727- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2727- ADD 1 TO AC-I-EMISDIARIA. */
            AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + 1;

        }

        [StopWatch]
        /*" R3100-00-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -2715- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1()
            {
                V0EDIA_CODRELAT = V0EDIA_CODRELAT.ToString(),
                V0EDIA_NUM_APOL = V0EDIA_NUM_APOL.ToString(),
                V0EDIA_NRENDOS = V0EDIA_NRENDOS.ToString(),
                V0EDIA_NRPARCEL = V0EDIA_NRPARCEL.ToString(),
                V0EDIA_DTMOVTO = V0EDIA_DTMOVTO.ToString(),
                V0EDIA_ORGAO = V0EDIA_ORGAO.ToString(),
                V0EDIA_RAMO = V0EDIA_RAMO.ToString(),
                V0EDIA_FONTE = V0EDIA_FONTE.ToString(),
                V0EDIA_CONGENER = V0EDIA_CONGENER.ToString(),
                V0EDIA_CODCORR = V0EDIA_CODCORR.ToString(),
                V0EDIA_SITUACAO = V0EDIA_SITUACAO.ToString(),
                V0EDIA_COD_EMPRESA = V0EDIA_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATAMENTO-COBERAPOL-SECTION */
        private void R4000_00_TRATAMENTO_COBERAPOL_SECTION()
        {
            /*" -2741- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2742- MOVE ZEROS TO W1COBP-PRM-TAR-VR */
            _.Move(0, W1COBP_PRM_TAR_VR);

            /*" -2743- MOVE ZEROS TO W1COBP-PCT-TOTAL */
            _.Move(0, W1COBP_PCT_TOTAL);

            /*" -2744- MOVE ZEROS TO CH-COBER-ATU */
            _.Move(0, AREA_DE_WORK.CH_COBER_ATU);

            /*" -2746- MOVE ZEROS TO CH-COBER-ANT */
            _.Move(0, AREA_DE_WORK.CH_COBER_ANT);

            /*" -2747- MOVE SPACES TO WFIM-V1COBERPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1COBERPROP);

            /*" -2749- MOVE SPACES TO CH-I-V0COBERAPOL */
            _.Move("", AREA_DE_WORK.CH_I_V0COBERAPOL);

            /*" -2751- PERFORM R4100-00-SELECT-V1COBERPROP */

            R4100_00_SELECT_V1COBERPROP_SECTION();

            /*" -2752- PERFORM R4200-00-DECLARE-V1COBERPROP */

            R4200_00_DECLARE_V1COBERPROP_SECTION();

            /*" -2753- PERFORM R4210-00-FETCH-V1COBERPROP */

            R4210_00_FETCH_V1COBERPROP_SECTION();

            /*" -2754- IF WFIM-V1COBERPROP NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COBERPROP.IsEmpty())
            {

                /*" -2756- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2759- PERFORM R4300-00-INCLUI-V0COBERAPOL UNTIL WFIM-V1COBERPROP NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1COBERPROP.IsEmpty()))
            {

                R4300_00_INCLUI_V0COBERAPOL_SECTION();
            }

            /*" -2760- IF CH-I-V0COBERAPOL NOT EQUAL SPACES */

            if (!AREA_DE_WORK.CH_I_V0COBERAPOL.IsEmpty())
            {

                /*" -2760- PERFORM R5000-00-UPDATE-V0COBERAPOL. */

                R5000_00_UPDATE_V0COBERAPOL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-SELECT-V1COBERPROP-SECTION */
        private void R4100_00_SELECT_V1COBERPROP_SECTION()
        {
            /*" -2774- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2785- PERFORM R4100_00_SELECT_V1COBERPROP_DB_SELECT_1 */

            R4100_00_SELECT_V1COBERPROP_DB_SELECT_1();

            /*" -2788- IF VIND-PRMTARIFA LESS 0 */

            if (VIND_PRMTARIFA < 0)
            {

                /*" -2790- MOVE ZEROS TO W1COBP-PRM-TAR-VR. */
                _.Move(0, W1COBP_PRM_TAR_VR);
            }


            /*" -2791- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2793- MOVE ZEROS TO W1COBP-PRM-TAR-VR. */
                _.Move(0, W1COBP_PRM_TAR_VR);
            }


            /*" -2795- IF (V1ENDO-TIPO-ENDO EQUAL '3' OR '5' ) AND (W1COBP-PRM-TAR-VR NOT EQUAL ZEROS) */

            if ((V1ENDO_TIPO_ENDO.In("3", "5")) && (W1COBP_PRM_TAR_VR != 00))
            {

                /*" -2796- COMPUTE W1COBP-PRM-TAR-VR = W1COBP-PRM-TAR-VR * -1. */
                W1COBP_PRM_TAR_VR.Value = W1COBP_PRM_TAR_VR * -1;
            }


        }

        [StopWatch]
        /*" R4100-00-SELECT-V1COBERPROP-DB-SELECT-1 */
        public void R4100_00_SELECT_V1COBERPROP_DB_SELECT_1()
        {
            /*" -2785- EXEC SQL SELECT SUM(A.PRM_TARIFARIO_VAR) INTO :W1COBP-PRM-TAR-VR:VIND-PRMTARIFA FROM SEGUROS.V1AUTOCOBERPROP A WHERE A.FONTE = :WHOST-FONTE AND A.NRPROPOS = :WHOST-NRPROPOS AND A.NRITEM = ( SELECT MAX(B.NRITEM) FROM SEGUROS.V1AUTOCOBERPROP B WHERE A.FONTE = B.FONTE AND A.NRPROPOS = B.NRPROPOS ) END-EXEC. */

            var r4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 = new R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1()
            {
                WHOST_NRPROPOS = WHOST_NRPROPOS.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
            };

            var executed_1 = R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1.Execute(r4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1COBP_PRM_TAR_VR, W1COBP_PRM_TAR_VR);
                _.Move(executed_1.VIND_PRMTARIFA, VIND_PRMTARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-DECLARE-V1COBERPROP-SECTION */
        private void R4200_00_DECLARE_V1COBERPROP_SECTION()
        {
            /*" -2810- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2835- PERFORM R4200_00_DECLARE_V1COBERPROP_DB_DECLARE_1 */

            R4200_00_DECLARE_V1COBERPROP_DB_DECLARE_1();

            /*" -2837- PERFORM R4200_00_DECLARE_V1COBERPROP_DB_OPEN_1 */

            R4200_00_DECLARE_V1COBERPROP_DB_OPEN_1();

        }

        [StopWatch]
        /*" R4200-00-DECLARE-V1COBERPROP-DB-OPEN-1 */
        public void R4200_00_DECLARE_V1COBERPROP_DB_OPEN_1()
        {
            /*" -2837- EXEC SQL OPEN V1COBERPROP END-EXEC. */

            V1COBERPROP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4210-00-FETCH-V1COBERPROP-SECTION */
        private void R4210_00_FETCH_V1COBERPROP_SECTION()
        {
            /*" -2851- MOVE '421' TO WNR-EXEC-SQL. */
            _.Move("421", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2864- PERFORM R4210_00_FETCH_V1COBERPROP_DB_FETCH_1 */

            R4210_00_FETCH_V1COBERPROP_DB_FETCH_1();

            /*" -2867- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2868- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2869- MOVE 'S' TO WFIM-V1COBERPROP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COBERPROP);

                    /*" -2870- MOVE HIGH-VALUES TO CH-COBER-ATU */

                    AREA_DE_WORK.CH_COBER_ATU.IsHighValues = true;

                    /*" -2870- PERFORM R4210_00_FETCH_V1COBERPROP_DB_CLOSE_1 */

                    R4210_00_FETCH_V1COBERPROP_DB_CLOSE_1();

                    /*" -2872- GO TO R4210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/ //GOTO
                    return;

                    /*" -2873- ELSE */
                }
                else
                {


                    /*" -2875- MOVE 'R4210 (ERRO FECTH V1COBERPRP)' TO LK-RETORNO */
                    _.Move("R4210 (ERRO FECTH V1COBERPRP)", LK_PROPOSTA.LK_RETORNO);

                    /*" -2877- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2878- MOVE V1COBP-FONTE TO CH-FONT-ATU */
            _.Move(V1COBP_FONTE, AREA_DE_WORK.CH_COBER_ATU.CH_FONT_ATU);

            /*" -2879- MOVE V1COBP-NRPROPOS TO CH-PROP-ATU */
            _.Move(V1COBP_NRPROPOS, AREA_DE_WORK.CH_COBER_ATU.CH_PROP_ATU);

            /*" -2883- MOVE V1COBP-RAMOFR TO CH-RAMO-ATU. */
            _.Move(V1COBP_RAMOFR, AREA_DE_WORK.CH_COBER_ATU.CH_RAMO_ATU);

            /*" -2883- ADD 1 TO AC-S-COBERPROP. */
            AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + 1;

        }

        [StopWatch]
        /*" R4210-00-FETCH-V1COBERPROP-DB-FETCH-1 */
        public void R4210_00_FETCH_V1COBERPROP_DB_FETCH_1()
        {
            /*" -2864- EXEC SQL FETCH V1COBERPROP INTO :V1COBP-FONTE, :V1COBP-NRPROPOS, :V1COBP-NUM-ITEM, :V1COBP-RAMOFR, :V1COBP-MODALIFR, :V1COBP-COD-COBER, :V1COBP-IMP-SEG-IX, :V1COBP-IMP-SEG-VR, :V1COBP-PRM-TAR-IX, :V1COBP-PRM-TAR-VR, :V1COBP-DAT-INIVIG, :V1COBP-DAT-TERVIG END-EXEC. */

            if (V1COBERPROP.Fetch())
            {
                _.Move(V1COBERPROP.V1COBP_FONTE, V1COBP_FONTE);
                _.Move(V1COBERPROP.V1COBP_NRPROPOS, V1COBP_NRPROPOS);
                _.Move(V1COBERPROP.V1COBP_NUM_ITEM, V1COBP_NUM_ITEM);
                _.Move(V1COBERPROP.V1COBP_RAMOFR, V1COBP_RAMOFR);
                _.Move(V1COBERPROP.V1COBP_MODALIFR, V1COBP_MODALIFR);
                _.Move(V1COBERPROP.V1COBP_COD_COBER, V1COBP_COD_COBER);
                _.Move(V1COBERPROP.V1COBP_IMP_SEG_IX, V1COBP_IMP_SEG_IX);
                _.Move(V1COBERPROP.V1COBP_IMP_SEG_VR, V1COBP_IMP_SEG_VR);
                _.Move(V1COBERPROP.V1COBP_PRM_TAR_IX, V1COBP_PRM_TAR_IX);
                _.Move(V1COBERPROP.V1COBP_PRM_TAR_VR, V1COBP_PRM_TAR_VR);
                _.Move(V1COBERPROP.V1COBP_DAT_INIVIG, V1COBP_DAT_INIVIG);
                _.Move(V1COBERPROP.V1COBP_DAT_TERVIG, V1COBP_DAT_TERVIG);
            }

        }

        [StopWatch]
        /*" R4210-00-FETCH-V1COBERPROP-DB-CLOSE-1 */
        public void R4210_00_FETCH_V1COBERPROP_DB_CLOSE_1()
        {
            /*" -2870- EXEC SQL CLOSE V1COBERPROP END-EXEC */

            V1COBERPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INCLUI-V0COBERAPOL-SECTION */
        private void R4300_00_INCLUI_V0COBERAPOL_SECTION()
        {
            /*" -2897- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2898- MOVE ZEROS TO W0COBA-IMP-SEG-IX */
            _.Move(0, W0COBA_IMP_SEG_IX);

            /*" -2899- MOVE ZEROS TO W0COBA-PRM-TAR-IX */
            _.Move(0, W0COBA_PRM_TAR_IX);

            /*" -2900- MOVE ZEROS TO W0COBA-IMP-SEG-VR */
            _.Move(0, W0COBA_IMP_SEG_VR);

            /*" -2902- MOVE ZEROS TO W0COBA-PRM-TAR-VR */
            _.Move(0, W0COBA_PRM_TAR_VR);

            /*" -2908- MOVE CH-COBER-ATU TO CH-COBER-ANT */
            _.Move(AREA_DE_WORK.CH_COBER_ATU, AREA_DE_WORK.CH_COBER_ANT);

            /*" -2916- PERFORM R4400-00-MONTA-COBER-ITEM UNTIL CH-COBER-ATU NOT EQUAL CH-COBER-ANT AND WFIM-V1COBERPROP NOT EQUAL SPACES. */

            while (!(AREA_DE_WORK.CH_COBER_ATU != AREA_DE_WORK.CH_COBER_ANT && !AREA_DE_WORK.WFIM_V1COBERPROP.IsEmpty()))
            {

                R4400_00_MONTA_COBER_ITEM_SECTION();
            }

            /*" -2918- PERFORM R4500-00-MONTA-COBER-TOT */

            R4500_00_MONTA_COBER_TOT_SECTION();

            /*" -2923- IF (V1ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304) AND W0COBA-PRM-TAR-IX EQUAL ZEROS AND W0COBA-PRM-TAR-VR EQUAL ZEROS AND CH-RAMO-ANT EQUAL 42 NEXT SENTENCE */

            if ((V1ENDO_CODPRODU.In("5302", "5303", "5304")) && W0COBA_PRM_TAR_IX == 00 && W0COBA_PRM_TAR_VR == 00 && AREA_DE_WORK.CH_COBER_ANT.CH_RAMO_ANT == 42)
            {

                /*" -2924- ELSE */
            }
            else
            {


                /*" -2925- PERFORM R4600-00-INSERE-V0COBERAPOL */

                R4600_00_INSERE_V0COBERAPOL_SECTION();

                /*" -2925- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-MONTA-COBER-ITEM-SECTION */
        private void R4400_00_MONTA_COBER_ITEM_SECTION()
        {
            /*" -2941- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2942- ADD V1COBP-IMP-SEG-IX TO W0COBA-IMP-SEG-IX */
            W0COBA_IMP_SEG_IX.Value = W0COBA_IMP_SEG_IX + V1COBP_IMP_SEG_IX;

            /*" -2943- ADD V1COBP-PRM-TAR-IX TO W0COBA-PRM-TAR-IX */
            W0COBA_PRM_TAR_IX.Value = W0COBA_PRM_TAR_IX + V1COBP_PRM_TAR_IX;

            /*" -2944- ADD V1COBP-IMP-SEG-VR TO W0COBA-IMP-SEG-VR */
            W0COBA_IMP_SEG_VR.Value = W0COBA_IMP_SEG_VR + V1COBP_IMP_SEG_VR;

            /*" -2944- ADD V1COBP-PRM-TAR-VR TO W0COBA-PRM-TAR-VR. */
            W0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR + V1COBP_PRM_TAR_VR;

            /*" -0- FLUXCONTROL_PERFORM R4400_90_LEITURA_COBERPROP */

            R4400_90_LEITURA_COBERPROP();

        }

        [StopWatch]
        /*" R4400-90-LEITURA-COBERPROP */
        private void R4400_90_LEITURA_COBERPROP(bool isPerform = false)
        {
            /*" -2948- PERFORM R4210-00-FETCH-V1COBERPROP. */

            R4210_00_FETCH_V1COBERPROP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-MONTA-COBER-TOT-SECTION */
        private void R4500_00_MONTA_COBER_TOT_SECTION()
        {
            /*" -2962- MOVE '450' TO WNR-EXEC-SQL. */
            _.Move("450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2963- MOVE WHOST-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(WHOST_NUM_APOL, V0COBA_NUM_APOL);

            /*" -2964- MOVE WHOST-NRENDOS TO V0COBA-NRENDOS */
            _.Move(WHOST_NRENDOS, V0COBA_NRENDOS);

            /*" -2965- MOVE CH-RAMO-ANT TO V0COBA-RAMOFR */
            _.Move(AREA_DE_WORK.CH_COBER_ANT.CH_RAMO_ANT, V0COBA_RAMOFR);

            /*" -2968- MOVE ZEROS TO V0COBA-MODALIFR V0COBA-NUM-ITEM V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_MODALIFR, V0COBA_NUM_ITEM, V0COBA_COD_EMPRESA);

            /*" -2969- MOVE V0AUCB-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0AUCB_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -2971- MOVE V0AUCB-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0AUCB_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -2973- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -2975- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -2977- IF ((V1ENDO-TIPO-ENDO EQUAL '3' OR '5' ) AND (W0COBA-PRM-TAR-VR NOT EQUAL ZEROS)) */

            if (((V1ENDO_TIPO_ENDO.In("3", "5")) && (W0COBA_PRM_TAR_VR != 00)))
            {

                /*" -2980- COMPUTE W0COBA-PRM-TAR-VR = W0COBA-PRM-TAR-VR * -1. */
                W0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR * -1;
            }


            /*" -2981- MOVE W0COBA-IMP-SEG-IX TO V0COBA-IMP-SEG-IX */
            _.Move(W0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_IX);

            /*" -2982- MOVE W0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-IX */
            _.Move(W0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_IX);

            /*" -2983- MOVE W0COBA-IMP-SEG-VR TO V0COBA-IMP-SEG-VR */
            _.Move(W0COBA_IMP_SEG_VR, V0COBA_IMP_SEG_VR);

            /*" -2985- MOVE W0COBA-PRM-TAR-VR TO V0COBA-PRM-TAR-VR */
            _.Move(W0COBA_PRM_TAR_VR, V0COBA_PRM_TAR_VR);

            /*" -2986- IF W1COBP-PRM-TAR-VR EQUAL ZEROS */

            if (W1COBP_PRM_TAR_VR == 00)
            {

                /*" -2987- MOVE ZEROS TO V0COBA-PCT-COBERT */
                _.Move(0, V0COBA_PCT_COBERT);

                /*" -2988- ELSE */
            }
            else
            {


                /*" -2989- IF W0COBA-PRM-TAR-VR NOT EQUAL ZEROS */

                if (W0COBA_PRM_TAR_VR != 00)
                {

                    /*" -2992- COMPUTE V0COBA-PCT-COBERT = W0COBA-PRM-TAR-VR * 100 / W1COBP-PRM-TAR-VR */
                    V0COBA_PCT_COBERT.Value = W0COBA_PRM_TAR_VR * 100 / W1COBP_PRM_TAR_VR;

                    /*" -2993- ELSE */
                }
                else
                {


                    /*" -2995- MOVE ZEROS TO V0COBA-PCT-COBERT. */
                    _.Move(0, V0COBA_PCT_COBERT);
                }

            }


            /*" -2997- ADD V0COBA-PCT-COBERT TO W1COBP-PCT-TOTAL */
            W1COBP_PCT_TOTAL.Value = W1COBP_PCT_TOTAL + V0COBA_PCT_COBERT;

            /*" -2997- MOVE 1 TO V0COBA-FATOR-MULT. */
            _.Move(1, V0COBA_FATOR_MULT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INSERE-V0COBERAPOL-SECTION */
        private void R4600_00_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -3021- MOVE '460' TO WNR-EXEC-SQL. */
            _.Move("460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3041- PERFORM R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1 */

            R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -3046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3047- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3053- DISPLAY 'R4600-00 (REGISTRO DUPLICADO) ... ' ' ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                    $"R4600-00 (REGISTRO DUPLICADO) ...  {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {WHOST_FONTE} {WHOST_NRPROPOS}"
                    .Display();

                    /*" -3054- GO TO R4600-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/ //GOTO
                    return;

                    /*" -3055- ELSE */
                }
                else
                {


                    /*" -3061- DISPLAY 'R4600-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM ' ' WHOST-FONTE ' ' WHOST-NRPROPOS */

                    $"R4600-00 (PROBLEMAS NA INSERCAO) ...  {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {WHOST_FONTE} {WHOST_NRPROPOS}"
                    .Display();

                    /*" -3063- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3065- MOVE '*' TO CH-I-V0COBERAPOL. */
            _.Move("*", AREA_DE_WORK.CH_I_V0COBERAPOL);

            /*" -3065- ADD 1 TO AC-I-COBERAPOL. */
            AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + 1;

        }

        [StopWatch]
        /*" R4600-00-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -3041- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , NULL) END-EXEC. */

            var r4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_IMP_SEG_IX = V0COBA_IMP_SEG_IX.ToString(),
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_IMP_SEG_VR = V0COBA_IMP_SEG_VR.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_FATOR_MULT = V0COBA_FATOR_MULT.ToString(),
                V0COBA_DATA_INIVI = V0COBA_DATA_INIVI.ToString(),
                V0COBA_DATA_TERVI = V0COBA_DATA_TERVI.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
            };

            R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-UPDATE-V0COBERAPOL-SECTION */
        private void R5000_00_UPDATE_V0COBERAPOL_SECTION()
        {
            /*" -3088- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3089- IF W1COBP-PCT-TOTAL EQUAL ZEROS */

            if (W1COBP_PCT_TOTAL == 00)
            {

                /*" -3091- GO TO R5000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3095- COMPUTE V0COBA-PCT-COBERT = V0COBA-PCT-COBERT + (100 - W1COBP-PCT-TOTAL) */
            V0COBA_PCT_COBERT.Value = V0COBA_PCT_COBERT + (100 - W1COBP_PCT_TOTAL);

            /*" -3105- PERFORM R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1 */

            R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1();

            /*" -3108- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3113- DISPLAY 'R5000-00 (PROBLEMAS UPDATE V0COBERAPOL) ... ' ' ' WHOST-FONTE ' ' WHOST-NRPROPOS ' ' WHOST-NUM-APOL ' ' WHOST-NRENDOS */

                $"R5000-00 (PROBLEMAS UPDATE V0COBERAPOL) ...  {WHOST_FONTE} {WHOST_NRPROPOS} {WHOST_NUM_APOL} {WHOST_NRENDOS}"
                .Display();

                /*" -3113- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-UPDATE-V0COBERAPOL-DB-UPDATE-1 */
        public void R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -3105- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET PCT_COBERTURA = :V0COBA-PCT-COBERT, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0COBA-NUM-APOL AND NRENDOS = :V0COBA-NRENDOS AND NUM_ITEM = :V0COBA-NUM-ITEM AND OCORHIST = :V0COBA-OCORHIST AND RAMOFR = :V0COBA-RAMOFR AND MODALIFR = :V0COBA-MODALIFR END-EXEC. */

            var r5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 = new R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1()
            {
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
            };

            R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1.Execute(r5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5500-00-LER-PARAMETROS-SECTION */
        private void R5500_00_LER_PARAMETROS_SECTION()
        {
            /*" -3130- INITIALIZE LT3159S-AREA-PARAMETROS */
            _.Initialize(
                LBLT3159.LT3159S_AREA_PARAMETROS
            );

            /*" -3131- MOVE V1ENDO-CODPRODU TO LT3159S-COD-PRODUTO */
            _.Move(V1ENDO_CODPRODU, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO);

            /*" -3132- MOVE '04' TO LT3159S-OPERACAO */
            _.Move("04", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO);

            /*" -3133- MOVE 0 TO LT3159S-PARAM */
            _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM);

            /*" -3134- MOVE 0 TO LT3159S-VALOR */
            _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR);

            /*" -3136- MOVE V0SIST-DTMOVABE TO LT3159S-DATA-INIVIGENCIA */
            _.Move(V0SIST_DTMOVABE, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA);

            /*" -3138- CALL 'LT3159S' USING LT3159S-AREA-PARAMETROS. */
            _.Call("LT3159S", LBLT3159.LT3159S_AREA_PARAMETROS);

            /*" -3139- IF LT3159S-COD-RETORNO > 0 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO > 0)
            {

                /*" -3142- DISPLAY ' R0910S-ERRO CALL LT3159S ' ' COD=' LT3159S-COD-RETORNO ' MSG=' LT3159S-MSG-RETORNO */

                $" R0910S-ERRO CALL LT3159S  COD={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO} MSG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO}"
                .Display();

                /*" -3143- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3145- END-IF */
            }


            /*" -3150- IF LT3159S-TB-VALOR(84) EQUAL ZEROS OR LT3159S-TB-VALOR(85) EQUAL ZEROS OR LT3159S-TB-VALOR(86) EQUAL ZEROS OR LT3159S-TB-VALOR-DT(87) EQUAL SPACES OR LT3159S-TB-VALOR-DT(87) < '1999-01-01' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[84].LT3159S_TB_VALOR == 00 || LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[85].LT3159S_TB_VALOR == 00 || LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[86].LT3159S_TB_VALOR == 00 || LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[87].LT3159S_TB_VALOR_DT == string.Empty || LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[87].LT3159S_TB_VALOR_DT < "1999-01-01")
            {

                /*" -3152- MOVE 'EM0910S-PARAMETRO TIT CAP INVALIDO  ' TO LT3159S-MSG-RETORNO */
                _.Move("EM0910S-PARAMETRO TIT CAP INVALIDO  ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -3154- MOVE 100 TO LT3159S-COD-RETORNO */
                _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -3158- DISPLAY 'R0910S-COD=' LT3159S-COD-RETORNO ' MSG=' LT3159S-MSG-RETORNO ' INIVIG=' LT3159S-DATA-INIVIGENCIA ' PRODU=' LT3159S-COD-PRODUTO */

                $"R0910S-COD={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO} MSG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO} INIVIG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA} PRODU={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO}"
                .Display();

                /*" -3162- DISPLAY ' PLANO=' LT3159S-TB-VALOR(84) ' VALOR=' LT3159S-TB-VALOR(85) ' QTD=' LT3159S-TB-VALOR(86) ' DT-COMPRA=' LT3159S-TB-VALOR-DT(87) */

                $" PLANO={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[84]} VALOR={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[85]} QTD={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[86]} DT-COMPRA={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[87]}"
                .Display();

                /*" -3163- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3165- END-IF */
            }


            /*" -3166- IF V0SIST-DTMOVABE < LT3159S-TB-VALOR-DT(87) */

            if (V0SIST_DTMOVABE < LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[87].LT3159S_TB_VALOR_DT)
            {

                /*" -3168- MOVE 'EM0910S-DATA HOJE MENOR QUE DATA DA COMPRA  ' TO LT3159S-MSG-RETORNO */
                _.Move("EM0910S-DATA HOJE MENOR QUE DATA DA COMPRA  ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -3169- MOVE 100 TO LT3159S-COD-RETORNO */
                _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -3170- DISPLAY ' EM0910S-' */
                _.Display($" EM0910S-");

                /*" -3175- DISPLAY ' PLANO=' LT3159S-TB-VALOR(84) ' VALOR=' LT3159S-TB-VALOR(85) ' QTD=' LT3159S-TB-VALOR(86) ' DT-COMPRA=' LT3159S-TB-VALOR-DT(87) ' DT-SIST=' V0SIST-DTMOVABE */

                $" PLANO={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[84]} VALOR={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[85]} QTD={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[86]} DT-COMPRA={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[87]} DT-SIST={V0SIST_DTMOVABE}"
                .Display();

                /*" -3178- DISPLAY 'COD-RET=' LT3159S-COD-RETORNO ' MSG=' LT3159S-MSG-RETORNO */

                $"COD-RET={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO} MSG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO}"
                .Display();

                /*" -3179- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3180- END-IF */
            }


            /*" -3180- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CAPITALIZACAO-SECTION */
        private void R6000_00_CAPITALIZACAO_SECTION()
        {
            /*" -3194- MOVE 'R6000' TO WNR-EXEC-SQL. */
            _.Move("R6000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3203- INITIALIZE LK-COD-USUARIO LK-NUM-SERIE LK-NUM-TITULO LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE */
            _.Initialize(
                LK_COD_USUARIO
                , LK_NUM_SERIE
                , LK_NUM_TITULO
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -3207- MOVE V0AUTO-NUM-PROP-CONV TO LK-NUM-PROPOSTA */
            _.Move(V0AUTO_NUM_PROP_CONV, LK_NUM_PROPOSTA);

            /*" -3208- MOVE 0001 TO LK-EMP-PARCEIRA */
            _.Move(0001, LK_EMP_PARCEIRA);

            /*" -3209- MOVE V1ENDO-CODPRODU TO LK-COD-RAMO */
            _.Move(V1ENDO_CODPRODU, LK_COD_RAMO);

            /*" -3210- MOVE 'TRACE OFF' TO LK-TRACE */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -3211- MOVE ZEROS TO LK-NUM-NSA */
            _.Move(0, LK_NUM_NSA);

            /*" -3213- MOVE 'EM0910S' TO LK-COD-USUARIO */
            _.Move("EM0910S", LK_COD_USUARIO);

            /*" -3214- MOVE LT3159S-TB-VALOR(84) TO LK-NUM-PLANO */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[84].LT3159S_TB_VALOR, LK_NUM_PLANO);

            /*" -3215- MOVE LT3159S-TB-VALOR(85) TO LK-VLR-TITULO */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[85].LT3159S_TB_VALOR, LK_VLR_TITULO);

            /*" -3224- MOVE LT3159S-TB-VALOR(86) TO LK-QTD-TITULOS */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[86].LT3159S_TB_VALOR, LK_QTD_TITULOS);

            /*" -3243- CALL 'VG0105S' USING LK-NUM-PLANO , LK-NUM-SERIE , LK-NUM-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-EMP-PARCEIRA , LK-COD-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE . */
            _.Call("VG0105S", LK_NUM_PLANO, LK_NUM_SERIE, LK_NUM_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_EMP_PARCEIRA, LK_COD_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE, AU084.DCLAU_APOLICE_COMPL.AU084_NUM_ITEM);

            /*" -3244- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -3245- DISPLAY 'LK-NUM-PLANO       ' LK-NUM-PLANO */
                _.Display($"LK-NUM-PLANO       {LK_NUM_PLANO}");

                /*" -3246- DISPLAY 'LK-NUM-SERIE       ' LK-NUM-SERIE */
                _.Display($"LK-NUM-SERIE       {LK_NUM_SERIE}");

                /*" -3247- DISPLAY 'LK-NUM-TITULO      ' LK-NUM-TITULO */
                _.Display($"LK-NUM-TITULO      {LK_NUM_TITULO}");

                /*" -3248- DISPLAY 'LK-NUM-PROPOSTA    ' LK-NUM-PROPOSTA */
                _.Display($"LK-NUM-PROPOSTA    {LK_NUM_PROPOSTA}");

                /*" -3249- DISPLAY 'LK-QTD-TITULOS     ' LK-QTD-TITULOS */
                _.Display($"LK-QTD-TITULOS     {LK_QTD_TITULOS}");

                /*" -3250- DISPLAY 'LK-VLR-TITULO      ' LK-VLR-TITULO */
                _.Display($"LK-VLR-TITULO      {LK_VLR_TITULO}");

                /*" -3251- DISPLAY 'LK-EMP-PARCEIRA    ' LK-EMP-PARCEIRA */
                _.Display($"LK-EMP-PARCEIRA    {LK_EMP_PARCEIRA}");

                /*" -3252- DISPLAY 'LK-COD-RAMO        ' LK-COD-RAMO */
                _.Display($"LK-COD-RAMO        {LK_COD_RAMO}");

                /*" -3253- DISPLAY 'LK-NUM-NSA         ' LK-NUM-NSA */
                _.Display($"LK-NUM-NSA         {LK_NUM_NSA}");

                /*" -3254- DISPLAY 'LK-COD-USUSAROI    ' LK-COD-USUARIO */
                _.Display($"LK-COD-USUSAROI    {LK_COD_USUARIO}");

                /*" -3255- DISPLAY 'LK-TRACE           ' LK-TRACE */
                _.Display($"LK-TRACE           {LK_TRACE}");

                /*" -3256- DISPLAY 'LK-OUT-COD-RETORNO ' LK-OUT-COD-RETORNO */
                _.Display($"LK-OUT-COD-RETORNO {LK_OUT_COD_RETORNO}");

                /*" -3257- DISPLAY 'LK-OUT-SQLCODE     ' LK-OUT-SQLCODE */
                _.Display($"LK-OUT-SQLCODE     {LK_OUT_SQLCODE}");

                /*" -3258- DISPLAY 'LK-OUT-MENSAGEM    ' LK-OUT-MENSAGEM */
                _.Display($"LK-OUT-MENSAGEM    {LK_OUT_MENSAGEM}");

                /*" -3259- DISPLAY 'LK-OUT-SQLERRMC    ' LK-OUT-SQLERRMC */
                _.Display($"LK-OUT-SQLERRMC    {LK_OUT_SQLERRMC}");

                /*" -3260- DISPLAY 'LK-OUT-SQLSTATE    ' LK-OUT-SQLSTATE */
                _.Display($"LK-OUT-SQLSTATE    {LK_OUT_SQLSTATE}");

                /*" -3261- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

                if (LK_OUT_COD_RETORNO != 00)
                {

                    /*" -3263- MOVE 'PROBLEMAS NO ACESSO A VG0105S ' TO LK-RETORNO */
                    _.Move("PROBLEMAS NO ACESSO A VG0105S ", LK_PROPOSTA.LK_RETORNO);

                    /*" -3264- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3264- END-IF. */
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-ATUALIZA-HISTORICO-SECTION */
        private void R7000_00_ATUALIZA_HISTORICO_SECTION()
        {
            /*" -3277- MOVE 'R7000' TO WNR-EXEC-SQL. */
            _.Move("R7000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3281- MOVE WHOST-CONGENERE TO AU050-COD-CONGENERE AU055-COD-CONGENERE AU057-COD-CONGENERE */
            _.Move(WHOST_CONGENERE, AU050.DCLAU_PROP_COBRNCA_VC.AU050_COD_CONGENERE, AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE, AU057.DCLAU_PROP_CONV_VC.AU057_COD_CONGENERE);

            /*" -3282- PERFORM R7010-00-INCLUI-AU055. */

            R7010_00_INCLUI_AU055_SECTION();

            /*" -3283- PERFORM R7020-00-UPDATE-AU057. */

            R7020_00_UPDATE_AU057_SECTION();

            /*" -3284- PERFORM R7030-00-SELECT-AU055. */

            R7030_00_SELECT_AU055_SECTION();

            /*" -3284- PERFORM R7040-00-INCLUI-AU050. */

            R7040_00_INCLUI_AU050_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7010-00-INCLUI-AU055-SECTION */
        private void R7010_00_INCLUI_AU055_SECTION()
        {
            /*" -3297- MOVE 'R7010' TO WNR-EXEC-SQL. */
            _.Move("R7010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3300- MOVE V1AUPR-NUM-PROP-CNV TO AU055-NUM-PROPOSTA-VC */
            _.Move(V1AUPR_NUM_PROP_CNV, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC);

            /*" -3306- PERFORM R7010_00_INCLUI_AU055_DB_SELECT_1 */

            R7010_00_INCLUI_AU055_DB_SELECT_1();

            /*" -3309- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3312- DISPLAY 'R7010 - PROBLEMAS SELECT AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' ' AU055-COD-CONGENERE */

                $"R7010 - PROBLEMAS SELECT AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC} {AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE}"
                .Display();

                /*" -3314- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3315- MOVE 'EM0910S' TO AU055-NOM-PROGRAMA */
            _.Move("EM0910S", AU055.DCLAU_HIS_PROP_CONV.AU055_NOM_PROGRAMA);

            /*" -3316- MOVE WHOST-DTMOVABE TO AU055-DTH-OPERACAO */
            _.Move(WHOST_DTMOVABE, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO);

            /*" -3318- MOVE 'EMT' TO AU055-IND-OPERACAO. */
            _.Move("EMT", AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO);

            /*" -3327- PERFORM R7010_00_INCLUI_AU055_DB_SELECT_2 */

            R7010_00_INCLUI_AU055_DB_SELECT_2();

            /*" -3330- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3333- DISPLAY 'R7010 - PROBLEMAS SELECT AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' ' AU055-COD-CONGENERE */

                $"R7010 - PROBLEMAS SELECT AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC} {AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE}"
                .Display();

                /*" -3335- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3336- ADD 1 TO AU055-SEQ-HISTORICO */
            AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO.Value = AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO + 1;

            /*" -3338- MOVE 'N' TO AU055-STA-ERRO */
            _.Move("N", AU055.DCLAU_HIS_PROP_CONV.AU055_STA_ERRO);

            /*" -3360- PERFORM R7010_00_INCLUI_AU055_DB_INSERT_1 */

            R7010_00_INCLUI_AU055_DB_INSERT_1();

            /*" -3363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3367- DISPLAY 'R7010 - PROBLEMAS INSERT AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' ' AU055-SEQ-HISTORICO ' ' AU055-COD-CONGENERE */

                $"R7010 - PROBLEMAS INSERT AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC} {AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO} {AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE}"
                .Display();

                /*" -3367- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7010-00-INCLUI-AU055-DB-SELECT-1 */
        public void R7010_00_INCLUI_AU055_DB_SELECT_1()
        {
            /*" -3306- EXEC SQL SELECT VALUE ( MAX ( SEQ_HISTORICO ) , 0 ) INTO :AU055-SEQ-HISTORICO FROM SEGUROS.AU_HIS_PROP_CONV WHERE NUM_PROPOSTA_VC = :AU055-NUM-PROPOSTA-VC AND COD_CONGENERE = :AU055-COD-CONGENERE END-EXEC. */

            var r7010_00_INCLUI_AU055_DB_SELECT_1_Query1 = new R7010_00_INCLUI_AU055_DB_SELECT_1_Query1()
            {
                AU055_NUM_PROPOSTA_VC = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC.ToString(),
                AU055_COD_CONGENERE = AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE.ToString(),
            };

            var executed_1 = R7010_00_INCLUI_AU055_DB_SELECT_1_Query1.Execute(r7010_00_INCLUI_AU055_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU055_SEQ_HISTORICO, AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7010_99_SAIDA*/

        [StopWatch]
        /*" R7010-00-INCLUI-AU055-DB-INSERT-1 */
        public void R7010_00_INCLUI_AU055_DB_INSERT_1()
        {
            /*" -3360- EXEC SQL INSERT INTO SEGUROS.AU_HIS_PROP_CONV ( NUM_PROPOSTA_VC , SEQ_HISTORICO , NOM_PROGRAMA , DTH_OPERACAO , IND_OPERACAO , DTH_MOVTO_ARQUIVO , NUM_ARQUIVO , STA_ERRO , DTH_CADASTRAMENTO, COD_CONGENERE) VALUES (:AU055-NUM-PROPOSTA-VC , :AU055-SEQ-HISTORICO , :AU055-NOM-PROGRAMA , :AU055-DTH-OPERACAO , :AU055-IND-OPERACAO , :AU055-DTH-MOVTO-ARQUIVO, :AU055-NUM-ARQUIVO , :AU055-STA-ERRO , CURRENT TIMESTAMP, :AU055-COD-CONGENERE) END-EXEC. */

            var r7010_00_INCLUI_AU055_DB_INSERT_1_Insert1 = new R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1()
            {
                AU055_NUM_PROPOSTA_VC = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC.ToString(),
                AU055_SEQ_HISTORICO = AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO.ToString(),
                AU055_NOM_PROGRAMA = AU055.DCLAU_HIS_PROP_CONV.AU055_NOM_PROGRAMA.ToString(),
                AU055_DTH_OPERACAO = AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO.ToString(),
                AU055_IND_OPERACAO = AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO.ToString(),
                AU055_DTH_MOVTO_ARQUIVO = AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_MOVTO_ARQUIVO.ToString(),
                AU055_NUM_ARQUIVO = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO.ToString(),
                AU055_STA_ERRO = AU055.DCLAU_HIS_PROP_CONV.AU055_STA_ERRO.ToString(),
                AU055_COD_CONGENERE = AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE.ToString(),
            };

            R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1.Execute(r7010_00_INCLUI_AU055_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R7010-00-INCLUI-AU055-DB-SELECT-2 */
        public void R7010_00_INCLUI_AU055_DB_SELECT_2()
        {
            /*" -3327- EXEC SQL SELECT NUM_ARQUIVO , DTH_MOVTO_ARQUIVO INTO :AU055-NUM-ARQUIVO , :AU055-DTH-MOVTO-ARQUIVO FROM SEGUROS.AU_HIS_PROP_CONV WHERE NUM_PROPOSTA_VC = :AU055-NUM-PROPOSTA-VC AND SEQ_HISTORICO = :AU055-SEQ-HISTORICO AND COD_CONGENERE = :AU055-COD-CONGENERE END-EXEC. */

            var r7010_00_INCLUI_AU055_DB_SELECT_2_Query1 = new R7010_00_INCLUI_AU055_DB_SELECT_2_Query1()
            {
                AU055_NUM_PROPOSTA_VC = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC.ToString(),
                AU055_SEQ_HISTORICO = AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO.ToString(),
                AU055_COD_CONGENERE = AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE.ToString(),
            };

            var executed_1 = R7010_00_INCLUI_AU055_DB_SELECT_2_Query1.Execute(r7010_00_INCLUI_AU055_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU055_NUM_ARQUIVO, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO);
                _.Move(executed_1.AU055_DTH_MOVTO_ARQUIVO, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_MOVTO_ARQUIVO);
            }


        }

        [StopWatch]
        /*" R7020-00-UPDATE-AU057-SECTION */
        private void R7020_00_UPDATE_AU057_SECTION()
        {
            /*" -3380- MOVE 'R7020' TO WNR-EXEC-SQL. */
            _.Move("R7020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3381- MOVE WHOST-NUM-APOL TO AU057-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, AU057.DCLAU_PROP_CONV_VC.AU057_NUM_APOLICE);

            /*" -3382- MOVE WHOST-NRENDOS TO AU057-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, AU057.DCLAU_PROP_CONV_VC.AU057_NUM_ENDOSSO);

            /*" -3383- MOVE AU055-IND-OPERACAO TO AU057-IND-OPERACAO. */
            _.Move(AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO, AU057.DCLAU_PROP_CONV_VC.AU057_IND_OPERACAO);

            /*" -3385- MOVE AU055-NUM-PROPOSTA-VC TO AU057-NUM-PROPOSTA-VC. */
            _.Move(AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC, AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA_VC);

            /*" -3386- MOVE V1ENDO-FONTE TO AU057-COD-FONTE. */
            _.Move(V1ENDO_FONTE, AU057.DCLAU_PROP_CONV_VC.AU057_COD_FONTE);

            /*" -3387- MOVE V1ENDO-NRPROPOS TO AU057-NUM-PROPOSTA. */
            _.Move(V1ENDO_NRPROPOS, AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA);

            /*" -3389- MOVE V1ENDO-TIPO-ENDO TO AU057-COD-TIPO-ENDOSSO. */
            _.Move(V1ENDO_TIPO_ENDO, AU057.DCLAU_PROP_CONV_VC.AU057_COD_TIPO_ENDOSSO);

            /*" -3399- PERFORM R7020_00_UPDATE_AU057_DB_UPDATE_1 */

            R7020_00_UPDATE_AU057_DB_UPDATE_1();

            /*" -3402- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3405- DISPLAY 'R7020 - PROBLEMAS UPDATE AU_PROP_CONV_VC' ' ' AU057-NUM-PROPOSTA-VC ' ' AU057-COD-CONGENERE */

                $"R7020 - PROBLEMAS UPDATE AU_PROP_CONV_VC {AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA_VC} {AU057.DCLAU_PROP_CONV_VC.AU057_COD_CONGENERE}"
                .Display();

                /*" -3405- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7020-00-UPDATE-AU057-DB-UPDATE-1 */
        public void R7020_00_UPDATE_AU057_DB_UPDATE_1()
        {
            /*" -3399- EXEC SQL UPDATE SEGUROS.AU_PROP_CONV_VC SET IND_OPERACAO = :AU057-IND-OPERACAO, COD_FONTE = :AU057-COD-FONTE, NUM_PROPOSTA = :AU057-NUM-PROPOSTA, NUM_APOLICE = :AU057-NUM-APOLICE, NUM_ENDOSSO = :AU057-NUM-ENDOSSO, COD_TIPO_ENDOSSO = :AU057-COD-TIPO-ENDOSSO WHERE NUM_PROPOSTA_VC = :AU057-NUM-PROPOSTA-VC AND COD_CONGENERE = :AU057-COD-CONGENERE END-EXEC. */

            var r7020_00_UPDATE_AU057_DB_UPDATE_1_Update1 = new R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1()
            {
                AU057_COD_TIPO_ENDOSSO = AU057.DCLAU_PROP_CONV_VC.AU057_COD_TIPO_ENDOSSO.ToString(),
                AU057_IND_OPERACAO = AU057.DCLAU_PROP_CONV_VC.AU057_IND_OPERACAO.ToString(),
                AU057_NUM_PROPOSTA = AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA.ToString(),
                AU057_NUM_APOLICE = AU057.DCLAU_PROP_CONV_VC.AU057_NUM_APOLICE.ToString(),
                AU057_NUM_ENDOSSO = AU057.DCLAU_PROP_CONV_VC.AU057_NUM_ENDOSSO.ToString(),
                AU057_COD_FONTE = AU057.DCLAU_PROP_CONV_VC.AU057_COD_FONTE.ToString(),
                AU057_NUM_PROPOSTA_VC = AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA_VC.ToString(),
                AU057_COD_CONGENERE = AU057.DCLAU_PROP_CONV_VC.AU057_COD_CONGENERE.ToString(),
            };

            R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1.Execute(r7020_00_UPDATE_AU057_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_99_SAIDA*/

        [StopWatch]
        /*" R7030-00-SELECT-AU055-SECTION */
        private void R7030_00_SELECT_AU055_SECTION()
        {
            /*" -3418- MOVE 'R7030' TO WNR-EXEC-SQL. */
            _.Move("R7030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3427- PERFORM R7030_00_SELECT_AU055_DB_SELECT_1 */

            R7030_00_SELECT_AU055_DB_SELECT_1();

            /*" -3430- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -3433- DISPLAY 'R7030-00 - PROBLEMAS SELECT AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' PRV ' ' ' AU055-COD-CONGENERE */

                $"R7030-00 - PROBLEMAS SELECT AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC}PRV {AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE}"
                .Display();

                /*" -3433- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7030-00-SELECT-AU055-DB-SELECT-1 */
        public void R7030_00_SELECT_AU055_DB_SELECT_1()
        {
            /*" -3427- EXEC SQL SELECT DTH_OPERACAO , NUM_ARQUIVO INTO :AU055-DTH-OPERACAO , :AU055-NUM-ARQUIVO FROM SEGUROS.AU_HIS_PROP_CONV WHERE NUM_PROPOSTA_VC = :AU055-NUM-PROPOSTA-VC AND IND_OPERACAO = 'PRV' AND COD_CONGENERE = :AU055-COD-CONGENERE END-EXEC. */

            var r7030_00_SELECT_AU055_DB_SELECT_1_Query1 = new R7030_00_SELECT_AU055_DB_SELECT_1_Query1()
            {
                AU055_NUM_PROPOSTA_VC = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC.ToString(),
                AU055_COD_CONGENERE = AU055.DCLAU_HIS_PROP_CONV.AU055_COD_CONGENERE.ToString(),
            };

            var executed_1 = R7030_00_SELECT_AU055_DB_SELECT_1_Query1.Execute(r7030_00_SELECT_AU055_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU055_DTH_OPERACAO, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO);
                _.Move(executed_1.AU055_NUM_ARQUIVO, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7030_99_SAIDA*/

        [StopWatch]
        /*" R7040-00-INCLUI-AU050-SECTION */
        private void R7040_00_INCLUI_AU050_SECTION()
        {
            /*" -3446- MOVE 'R7040' TO WNR-EXEC-SQL. */
            _.Move("R7040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3447- MOVE WHOST-NUM-APOL TO AU050-NUM-APOLICE */
            _.Move(WHOST_NUM_APOL, AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_APOLICE);

            /*" -3448- MOVE WHOST-NRENDOS TO AU050-NUM-ENDOSSO */
            _.Move(WHOST_NRENDOS, AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_ENDOSSO);

            /*" -3449- MOVE 1 TO AU050-NUM-PARCELA */
            _.Move(1, AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_PARCELA);

            /*" -3450- IF WHOST-QT-PARCEL LESS 2 */

            if (WHOST_QT_PARCEL < 2)
            {

                /*" -3452- MOVE ZEROS TO AU050-NUM-PARCELA. */
                _.Move(0, AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_PARCELA);
            }


            /*" -3453- MOVE 1 TO AU050-SEQ-HISTORICO */
            _.Move(1, AU050.DCLAU_PROP_COBRNCA_VC.AU050_SEQ_HISTORICO);

            /*" -3454- MOVE 1 TO AU050-OCORR-HISTORICO */
            _.Move(1, AU050.DCLAU_PROP_COBRNCA_VC.AU050_OCORR_HISTORICO);

            /*" -3455- MOVE 201 TO AU050-COD-OPERACAO */
            _.Move(201, AU050.DCLAU_PROP_COBRNCA_VC.AU050_COD_OPERACAO);

            /*" -3456- MOVE WHOST-VL-PARCEL TO AU050-VLR-PARCELA */
            _.Move(WHOST_VL_PARCEL, AU050.DCLAU_PROP_COBRNCA_VC.AU050_VLR_PARCELA);

            /*" -3457- MOVE AU055-DTH-OPERACAO TO AU050-DTH-MOVIMENTO */
            _.Move(AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO, AU050.DCLAU_PROP_COBRNCA_VC.AU050_DTH_MOVIMENTO);

            /*" -3458- MOVE SPACES TO AU050-DTH-VENCTO-REPROG */
            _.Move("", AU050.DCLAU_PROP_COBRNCA_VC.AU050_DTH_VENCTO_REPROG);

            /*" -3460- MOVE AU055-NUM-ARQUIVO TO AU050-NUM-ARQUIVO */
            _.Move(AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO, AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_ARQUIVO);

            /*" -3486- PERFORM R7040_00_INCLUI_AU050_DB_INSERT_1 */

            R7040_00_INCLUI_AU050_DB_INSERT_1();

            /*" -3489- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3494- DISPLAY 'R7040 - PROBLEMAS INSERT AU_PROP_COBRNCA_VC' ' ' AU050-NUM-APOLICE ' ' AU050-NUM-ENDOSSO ' ' AU050-NUM-PARCELA ' ' AU050-COD-CONGENERE */

                $"R7040 - PROBLEMAS INSERT AU_PROP_COBRNCA_VC {AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_APOLICE} {AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_ENDOSSO} {AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_PARCELA} {AU050.DCLAU_PROP_COBRNCA_VC.AU050_COD_CONGENERE}"
                .Display();

                /*" -3494- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7040-00-INCLUI-AU050-DB-INSERT-1 */
        public void R7040_00_INCLUI_AU050_DB_INSERT_1()
        {
            /*" -3486- EXEC SQL INSERT INTO SEGUROS.AU_PROP_COBRNCA_VC ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SEQ_HISTORICO , OCORR_HISTORICO , COD_OPERACAO , VLR_PARCELA , DTH_MOVIMENTO , DTH_VENCTO_REPROG , NUM_ARQUIVO , DTH_CADASTRAMENTO , COD_CONGENERE) VALUES (:AU050-NUM-APOLICE , :AU050-NUM-ENDOSSO , :AU050-NUM-PARCELA , :AU050-SEQ-HISTORICO , :AU050-OCORR-HISTORICO , :AU050-COD-OPERACAO , :AU050-VLR-PARCELA , :AU050-DTH-MOVIMENTO , NULL , :AU050-NUM-ARQUIVO , CURRENT TIMESTAMP, :AU050-COD-CONGENERE) END-EXEC. */

            var r7040_00_INCLUI_AU050_DB_INSERT_1_Insert1 = new R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1()
            {
                AU050_NUM_APOLICE = AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_APOLICE.ToString(),
                AU050_NUM_ENDOSSO = AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_ENDOSSO.ToString(),
                AU050_NUM_PARCELA = AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_PARCELA.ToString(),
                AU050_SEQ_HISTORICO = AU050.DCLAU_PROP_COBRNCA_VC.AU050_SEQ_HISTORICO.ToString(),
                AU050_OCORR_HISTORICO = AU050.DCLAU_PROP_COBRNCA_VC.AU050_OCORR_HISTORICO.ToString(),
                AU050_COD_OPERACAO = AU050.DCLAU_PROP_COBRNCA_VC.AU050_COD_OPERACAO.ToString(),
                AU050_VLR_PARCELA = AU050.DCLAU_PROP_COBRNCA_VC.AU050_VLR_PARCELA.ToString(),
                AU050_DTH_MOVIMENTO = AU050.DCLAU_PROP_COBRNCA_VC.AU050_DTH_MOVIMENTO.ToString(),
                AU050_NUM_ARQUIVO = AU050.DCLAU_PROP_COBRNCA_VC.AU050_NUM_ARQUIVO.ToString(),
                AU050_COD_CONGENERE = AU050.DCLAU_PROP_COBRNCA_VC.AU050_COD_CONGENERE.ToString(),
            };

            R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1.Execute(r7040_00_INCLUI_AU050_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7040_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3509- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -3511- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERRO.WSQLERRMC);

            /*" -3512- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -3514- DISPLAY WSQLERRO */
            _.Display(AREA_DE_WORK.WSQLERRO);

            /*" -3514- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3516- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3520- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3522- IF LK-RETORNO EQUAL SPACES OR LOW-VALUES */

            if (LK_PROPOSTA.LK_RETORNO.IsLowValues())
            {

                /*" -3524- MOVE ALL '*' TO LK-RETORNO. */
                _.MoveAll("*", LK_PROPOSTA.LK_RETORNO);
            }


            /*" -3524- GOBACK. */

            throw new GoBack();

        }
    }
}