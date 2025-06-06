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
using Sias.VidaAzul.DB2.VA0685B;

namespace Code
{
    public class VA0685B
    {
        public bool IsCall { get; set; }

        public VA0685B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  RELATORIO DE PROPOSTAS RECUSADAS   *      */
        /*"      *                             POR CPF RECORRENTE.                *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  EDIVALDO GOMES                     *      */
        /*"      *                                                                *      */
        /*"      *   EMPRESA ................  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0685B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  12/04/2010                         *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS .................  40.454                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.02  *   VERSAO 02 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "450", "X(450)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_SAIDA, _ARQ_SAIDA, REG_SAIDA); return _ARQ_SAIDA;
            }
        }
        public SortBasis<VA0685B_REG_SVA0685B> SVA0685B { get; set; } = new SortBasis<VA0685B_REG_SVA0685B>(new VA0685B_REG_SVA0685B());
        /*"01            REG-SAIDA           PIC X(450).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "450", "X(450)."), @"");
        /*"01            REG-SVA0685B.*/
        public VA0685B_REG_SVA0685B REG_SVA0685B { get; set; } = new VA0685B_REG_SVA0685B();
        public class VA0685B_REG_SVA0685B : VarBasis
        {
            /*"    03        SVA-NOM-PRODUTO        PIC X(040).*/
            public StringBasis SVA_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03        SVA-COD-FILIAL         PIC 9(004).*/
            public IntBasis SVA_COD_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        SVA-NOM-FILIAL         PIC X(040).*/
            public StringBasis SVA_NOM_FILIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03        SVA-COD-SR             PIC 9(004).*/
            public IntBasis SVA_COD_SR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        SVA-NOM-SR             PIC X(040).*/
            public StringBasis SVA_NOM_SR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03        SVA-NUM-CERTIFICADO    PIC 9(015).*/
            public IntBasis SVA_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03        SVA-QTD-DIAS           PIC 9(006).*/
            public IntBasis SVA_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03        SVA-NOM-SEGURADO       PIC X(040).*/
            public StringBasis SVA_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03        SVA-NUM-CGCCPF         PIC 9(015).*/
            public IntBasis SVA_NUM_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03        SVA-DATA-QUITACAO      PIC X(010).*/
            public StringBasis SVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03        SVA-COD-AGENCIA        PIC 9(004).*/
            public IntBasis SVA_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        SVA-VLR-PREMIO         PIC 9(015),99.*/
            public DoubleBasis SVA_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    03        SVA-VLR-IMPSEGUR       PIC 9(015),99.*/
            public DoubleBasis SVA_VLR_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    03        SVA-DATA-CANCEL        PIC X(010).*/
            public StringBasis SVA_DATA_CANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03        SVA-DES-OPCAO-PG       PIC X(010).*/
            public StringBasis SVA_DES_OPCAO_PG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03        SVA-COD-AGENCIA-DEB    PIC 9(004).*/
            public IntBasis SVA_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        SVA-COD-OPER-DEB       PIC 9(004).*/
            public IntBasis SVA_COD_OPER_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        SVA-NUM-CONTA-DEB      PIC 9(012).*/
            public IntBasis SVA_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    03        SVA-DIG-CONTA-DEB      PIC 9(003).*/
            public IntBasis SVA_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03        SVA-NUM-CHEQUE         PIC 9(003).*/
            public IntBasis SVA_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03        SVA-DIG-CHEQUE         PIC 9(008).*/
            public IntBasis SVA_DIG_CHEQUE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03        SVA-NUM-CARTAO         PIC 9(018).*/
            public IntBasis SVA_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"    03        SVA-COD-INDICADOR      PIC X(008).*/
            public StringBasis SVA_COD_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03        SVA-COD-MOTIVO         PIC 9(004).*/
            public IntBasis SVA_COD_MOTIVO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        SVA-DES-MOTIVO         PIC X(070).*/
            public StringBasis SVA_DES_MOTIVO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"    03        SVA-COD-USUARIO        PIC X(008).*/
            public StringBasis SVA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77  WSIST-DTMOVABE                  PIC X(10).*/
        public StringBasis WSIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WSIST-DTCURREN                  PIC X(10).*/
        public StringBasis WSIST_DTCURREN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  VGPROP-QTD-DIAS                 PIC S9(04) COMP.*/
        public IntBasis VGPROP_QTD_DIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VGPROP-COD-USUARIO              PIC X(08).*/
        public StringBasis VGPROP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  VGDEVO-DES-DEVOLUCAO            PIC X(70).*/
        public StringBasis VGDEVO_DES_DEVOLUCAO { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"01  VIND-COD-USUARIO                 PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-AGE-DEB                 PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_AGE_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPE-CONTA-DEB               PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_OPE_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-CONTA-DEB               PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DIG-CONTA-DEB               PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-CARTAO                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-IND                      PIC  S9(004)    COMP   VALUE +0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-WORK-AREAS.*/
        public VA0685B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA0685B_WS_WORK_AREAS();
        public class VA0685B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 WFIM-MOVIMENTO           PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WFIM-SORT                PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 AC-LIDOS                 PIC 9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-LIDOS-SORT            PIC 9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 WTEM-HISCOBER            PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_HISCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WTEM-PRODUTO             PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WTEM-COBERHIST           PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_COBERHIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WTEM-ESTRVIN             PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_ESTRVIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 W-NUM-MATRI-VENDEDOR     PIC X(15).*/
            public StringBasis W_NUM_MATRI_VENDEDOR { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"01  LC01.*/
        }
        public VA0685B_LC01 LC01 { get; set; } = new VA0685B_LC01();
        public class VA0685B_LC01 : VarBasis
        {
            /*"    03 FILLER               PIC X(007)  VALUE 'PRODUTO'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(006)  VALUE 'Filial'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"Filial");
            /*"    03 FILLER               PIC X(002)  VALUE ';;'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @";;");
            /*"    03 FILLER               PIC X(002)  VALUE 'EN'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"EN");
            /*"    03 FILLER               PIC X(002)  VALUE ';;'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @";;");
            /*"    03 FILLER               PIC X(011)  VALUE 'CERTIFICADO'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(006)  VALUE 'QTDIAS'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"QTDIAS");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(004)  VALUE 'NOME'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NOME");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(003)  VALUE 'CPF'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"CPF");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(008)  VALUE 'QUITACAO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"QUITACAO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(007)  VALUE 'AGENCIA'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AGENCIA");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(006)  VALUE 'PREMIO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(006)  VALUE 'IMP.SG'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"IMP.SG");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(009)  VALUE 'DT.CANCEL'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DT.CANCEL");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(011)  VALUE 'OPCAO-PAGTO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"OPCAO_PAGTO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(006)  VALUE 'AG.DEB'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"AG.DEB");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(004)  VALUE 'OPER'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"OPER");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(012)  VALUE 'CTA DEBTO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"CTA DEBTO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(004)  VALUE 'DVCT'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DVCT");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(008)  VALUE 'NUM.CHEQ'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NUM.CHEQ");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(004)  VALUE 'DVCQ'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DVCQ");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(006)  VALUE 'CART�O'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CART�O");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(007)  VALUE 'MATRVEN'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"MATRVEN");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(004)  VALUE 'MOTV'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"MOTV");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(011)  VALUE 'DESC MOTIVO'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"DESC MOTIVO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 FILLER               PIC X(007)  VALUE 'USUARIO'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"USUARIO");
            /*"    03 FILLER               PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  LD01.*/
        }
        public VA0685B_LD01 LD01 { get; set; } = new VA0685B_LD01();
        public class VA0685B_LD01 : VarBasis
        {
            /*"    03 LD01-NOM-PRODUTO         PIC X(040).*/
            public StringBasis LD01_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-FILIAL          PIC 9(004).*/
            public IntBasis LD01_COD_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NOM-FILIAL          PIC X(040).*/
            public StringBasis LD01_NOM_FILIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-SR              PIC 9(004).*/
            public IntBasis LD01_COD_SR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NOM-SR              PIC X(040).*/
            public StringBasis LD01_NOM_SR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NUM-CERTIFICADO     PIC 9(015).*/
            public IntBasis LD01_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-QTD-DIAS            PIC 9(006).*/
            public IntBasis LD01_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NOM-SEGURADO        PIC X(040).*/
            public StringBasis LD01_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NUM-CGCCPF          PIC 9(015).*/
            public IntBasis LD01_NUM_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-DATA-QUITACAO       PIC X(010).*/
            public StringBasis LD01_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-AGENCIA         PIC 9(004).*/
            public IntBasis LD01_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-VLR-PREMIO          PIC 9(015),99.*/
            public DoubleBasis LD01_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-VLR-IMPSEGUR        PIC 9(015),99.*/
            public DoubleBasis LD01_VLR_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-DATA-CANCEL         PIC X(010).*/
            public StringBasis LD01_DATA_CANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-DES-OPCAO-PG        PIC X(010).*/
            public StringBasis LD01_DES_OPCAO_PG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-AGENCIA-DEB     PIC 9(004).*/
            public IntBasis LD01_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-OPER-DEB        PIC 9(004).*/
            public IntBasis LD01_COD_OPER_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NUM-CONTA-DEB       PIC 9(012).*/
            public IntBasis LD01_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-DIG-CONTA-DEB       PIC 9(003).*/
            public IntBasis LD01_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NUM-CHEQUE          PIC 9(008).*/
            public IntBasis LD01_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-DIG-CHEQUE          PIC 9(003).*/
            public IntBasis LD01_DIG_CHEQUE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-NUM-CARTAO          PIC 9(018).*/
            public IntBasis LD01_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-INDICADOR       PIC X(008).*/
            public StringBasis LD01_COD_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-MOTIVO          PIC 9(004).*/
            public IntBasis LD01_COD_MOTIVO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-DES-MOTIVO          PIC X(070).*/
            public StringBasis LD01_DES_MOTIVO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 LD01-COD-USUARIO         PIC X(008).*/
            public StringBasis LD01_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 FILLER                   PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  WABEND.*/
        }
        public VA0685B_WABEND WABEND { get; set; } = new VA0685B_WABEND();
        public class VA0685B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(016) VALUE            '*** VA0685B *** '.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VA0685B *** ");
            /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      05      LOCALIZA-ABEND-1.*/
            public VA0685B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0685B_LOCALIZA_ABEND_1();
            public class VA0685B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO              PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      05      LOCALIZA-ABEND-2.*/
            }
            public VA0685B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0685B_LOCALIZA_ABEND_2();
            public class VA0685B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"      05         WSQLERRO.*/
            }
            public VA0685B_WSQLERRO WSQLERRO { get; set; } = new VA0685B_WSQLERRO();
            public class VA0685B_WSQLERRO : VarBasis
            {
                /*"        10       FILLER               PIC  X(014) VALUE              ' *** SQLERRMC '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"        10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.CBHSTZUL CBHSTZUL { get; set; } = new Dclgens.CBHSTZUL();
        public Dclgens.DEVOLVID DEVOLVID { get; set; } = new Dclgens.DEVOLVID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public VA0685B_CPROPOSTA CPROPOSTA { get; set; } = new VA0685B_CPROPOSTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0685B_FILE_NAME_P, string ARQ_SAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0685B.SetFile(SVA0685B_FILE_NAME_P);
                ARQ_SAIDA.SetFile(ARQ_SAIDA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -314- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -316- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -318- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -321- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -322- DISPLAY 'PROGRAMA EM EXECUCAO VA0685B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0685B  ");

            /*" -323- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -326- DISPLAY 'VERSAO V.02 402.982 14/02/2023' */
            _.Display($"VERSAO V.02 402.982 14/02/2023");

            /*" -327- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -329- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -330- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -332- MOVE '0000          ' TO COMANDO. */
            _.Move("0000          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -334- PERFORM 0010-ABRIR-ARQUIVOS. */

            M_0010_ABRIR_ARQUIVOS_SECTION();

            /*" -336- PERFORM 0015-LER-SISTEMA. */

            M_0015_LER_SISTEMA_SECTION();

            /*" -338- PERFORM 0016-LER-RELATORIO. */

            M_0016_LER_RELATORIO_SECTION();

            /*" -340- PERFORM 0020-DECLARE-CURSOR. */

            M_0020_DECLARE_CURSOR_SECTION();

            /*" -342- PERFORM 0030-FETCH-CURSOR. */

            M_0030_FETCH_CURSOR_SECTION();

            /*" -344- PERFORM 0035-SELECT-DEVOL. */

            M_0035_SELECT_DEVOL_SECTION();

            /*" -345- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -346- PERFORM 9998-FINALIZAR */

                M_9998_FINALIZAR_SECTION();

                /*" -348- END-IF. */
            }


            /*" -350- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -356- SORT SVA0685B ON ASCENDING KEY SVA-NOM-PRODUTO SVA-COD-FILIAL SVA-COD-SR SVA-COD-AGENCIA INPUT PROCEDURE 0040-SELECIONA THRU 0040-FIM OUTPUT PROCEDURE 0190-GERA-ARQ THRU 0190-FIM. */
            SVA0685B.Sort("SVA-NOM-PRODUTO,SVA-COD-FILIAL,SVA-COD-SR,SVA-COD-AGENCIA", () => M_0040_SELECIONA_SECTION(), () => M_0190_GERA_ARQ_SECTION());

            /*" -360- PERFORM 0250-ATUALIZA-RELAT. */

            M_0250_ATUALIZA_RELAT_SECTION();

            /*" -360- PERFORM 9998-FINALIZAR. */

            M_9998_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-0010-ABRIR-ARQUIVOS-SECTION */
        private void M_0010_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -369- MOVE '0010-ABRIR-ARQUIVOS ' TO PARAGRAFO. */
            _.Move("0010-ABRIR-ARQUIVOS ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -373- MOVE '0010' TO COMANDO. */
            _.Move("0010", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -373- OPEN OUTPUT ARQ-SAIDA. */
            ARQ_SAIDA.Open(REG_SAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0015-LER-SISTEMA-SECTION */
        private void M_0015_LER_SISTEMA_SECTION()
        {
            /*" -382- MOVE '0015-LER-SISTEMA    ' TO PARAGRAFO. */
            _.Move("0015-LER-SISTEMA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -386- MOVE '0015' TO COMANDO. */
            _.Move("0015", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -393- PERFORM M_0015_LER_SISTEMA_DB_SELECT_1 */

            M_0015_LER_SISTEMA_DB_SELECT_1();

            /*" -396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -397- DISPLAY 'ERRO NO ACESSO A TABELA DE SISTEMAS - VA' */
                _.Display($"ERRO NO ACESSO A TABELA DE SISTEMAS - VA");

                /*" -398- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -398- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0015-LER-SISTEMA-DB-SELECT-1 */
        public void M_0015_LER_SISTEMA_DB_SELECT_1()
        {
            /*" -393- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :WSIST-DTMOVABE, :WSIST-DTCURREN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var m_0015_LER_SISTEMA_DB_SELECT_1_Query1 = new M_0015_LER_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0015_LER_SISTEMA_DB_SELECT_1_Query1.Execute(m_0015_LER_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSIST_DTMOVABE, WSIST_DTMOVABE);
                _.Move(executed_1.WSIST_DTCURREN, WSIST_DTCURREN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0015_FIM*/

        [StopWatch]
        /*" M-0016-LER-RELATORIO-SECTION */
        private void M_0016_LER_RELATORIO_SECTION()
        {
            /*" -407- MOVE '0016-LER-RELATORIO  ' TO PARAGRAFO. */
            _.Move("0016-LER-RELATORIO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -411- MOVE '0016' TO COMANDO. */
            _.Move("0016", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -417- PERFORM M_0016_LER_RELATORIO_DB_SELECT_1 */

            M_0016_LER_RELATORIO_DB_SELECT_1();

            /*" -420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -421- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -422- PERFORM 0017-INSERE-RELAT */

                    M_0017_INSERE_RELAT_SECTION();

                    /*" -423- ELSE */
                }
                else
                {


                    /*" -424- DISPLAY 'ERRO NO ACESSO A TABELA DE RELATORIOS' */
                    _.Display($"ERRO NO ACESSO A TABELA DE RELATORIOS");

                    /*" -425- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -425- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" M-0016-LER-RELATORIO-DB-SELECT-1 */
        public void M_0016_LER_RELATORIO_DB_SELECT_1()
        {
            /*" -417- EXEC SQL SELECT PERI_INICIAL INTO :RELATORI-PERI-INICIAL FROM SEGUROS.RELATORIOS WHERE COD_USUARIO = 'VA0685B' AND COD_RELATORIO = 'VA0685B' END-EXEC. */

            var m_0016_LER_RELATORIO_DB_SELECT_1_Query1 = new M_0016_LER_RELATORIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0016_LER_RELATORIO_DB_SELECT_1_Query1.Execute(m_0016_LER_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0016_FIM*/

        [StopWatch]
        /*" M-0017-INSERE-RELAT-SECTION */
        private void M_0017_INSERE_RELAT_SECTION()
        {
            /*" -434- MOVE '0017-INSERE-RELAT   ' TO PARAGRAFO. */
            _.Move("0017-INSERE-RELAT   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -438- MOVE '0017' TO COMANDO. */
            _.Move("0017", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -460- PERFORM M_0017_INSERE_RELAT_DB_INSERT_1 */

            M_0017_INSERE_RELAT_DB_INSERT_1();

            /*" -465- MOVE '2008-08-01' TO RELATORI-PERI-INICIAL. */
            _.Move("2008-08-01", RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);

            /*" -466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -467- DISPLAY 'VA0685B - PROBLEMAS NO INSERT DA RELATORIOS' */
                _.Display($"VA0685B - PROBLEMAS NO INSERT DA RELATORIOS");

                /*" -467- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0017-INSERE-RELAT-DB-INSERT-1 */
        public void M_0017_INSERE_RELAT_DB_INSERT_1()
        {
            /*" -460- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA, COD_RELATORIO, NUM_COPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR, COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO, NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO, COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER, ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA, TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT, IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) SELECT 'VA0685B' , CURRENT DATE, 'VA' , 'VA0685B' , 0, 0, '2008-08-01' , '9999-12-31' , CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0.00, CURRENT TIMESTAMP FROM SYSIBM.SYSDUMMY1 END-EXEC. */

            var m_0017_INSERE_RELAT_DB_INSERT_1_Insert1 = new M_0017_INSERE_RELAT_DB_INSERT_1_Insert1()
            {
            };

            M_0017_INSERE_RELAT_DB_INSERT_1_Insert1.Execute(m_0017_INSERE_RELAT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0017_FIM*/

        [StopWatch]
        /*" M-0020-DECLARE-CURSOR-SECTION */
        private void M_0020_DECLARE_CURSOR_SECTION()
        {
            /*" -476- MOVE '0020-DECLARE-CURSOR ' TO PARAGRAFO. */
            _.Move("0020-DECLARE-CURSOR ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -509- MOVE '0020' TO COMANDO. */
            _.Move("0020", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -541- PERFORM M_0020_DECLARE_CURSOR_DB_DECLARE_1 */

            M_0020_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -543- PERFORM M_0020_DECLARE_CURSOR_DB_OPEN_1 */

            M_0020_DECLARE_CURSOR_DB_OPEN_1();

            /*" -546- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -547- DISPLAY 'VA0685B - PROBLEMAS NO OPEN CPROPOSTA ' */
                _.Display($"VA0685B - PROBLEMAS NO OPEN CPROPOSTA ");

                /*" -547- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0020-DECLARE-CURSOR-DB-DECLARE-1 */
        public void M_0020_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -541- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT T1.AGE_COBRANCA, T1.NUM_MATRI_VENDEDOR, T1.NUM_CERTIFICADO, T1.DATA_QUITACAO, T1.COD_CLIENTE, T1.COD_USUARIO, T1.NUM_APOLICE, T1.COD_SUBGRUPO, T1.DATA_MOVIMENTO, CAST (T1.DATA_MOVIMENTO - T1.DATA_QUITACAO AS INTEGER) AS QTD_DIAS FROM SEGUROS.PROPOSTAS_VA T1, SEGUROS.VG_CRITICA_PROPOSTA T2 WHERE T1.DATA_MOVIMENTO > :RELATORI-PERI-INICIAL AND T1.SIT_REGISTRO = '2' AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T2.COD_MSG_CRITICA = 1864 AND T2.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND NOT EXISTS ( SELECT * FROM SEGUROS.VG_CRITICA_PROPOSTA T10, SEGUROS.VG_DM_MSG_CRITICA T11 WHERE T10.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T10.COD_MSG_CRITICA <> T2.COD_MSG_CRITICA AND T10.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T11.COD_MSG_CRITICA = T10.COD_MSG_CRITICA AND T11.COD_TP_MSG_CRITICA <> '3' ) WITH UR END-EXEC. */
            CPROPOSTA = new VA0685B_CPROPOSTA(true);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT T1.AGE_COBRANCA
							, 
							T1.NUM_MATRI_VENDEDOR
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DATA_QUITACAO
							, 
							T1.COD_CLIENTE
							, 
							T1.COD_USUARIO
							, 
							T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.DATA_MOVIMENTO
							, 
							CAST (T1.DATA_MOVIMENTO - T1.DATA_QUITACAO AS 
							INTEGER) AS QTD_DIAS 
							FROM SEGUROS.PROPOSTAS_VA T1
							, 
							SEGUROS.VG_CRITICA_PROPOSTA T2 
							WHERE T1.DATA_MOVIMENTO > '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND T1.SIT_REGISTRO = '2' 
							AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO 
							AND T2.COD_MSG_CRITICA = 1864 
							AND T2.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND NOT EXISTS 
							( 
							SELECT * 
							FROM SEGUROS.VG_CRITICA_PROPOSTA T10
							, 
							SEGUROS.VG_DM_MSG_CRITICA T11 
							WHERE T10.NUM_CERTIFICADO = T2.NUM_CERTIFICADO 
							AND T10.COD_MSG_CRITICA <> T2.COD_MSG_CRITICA 
							AND T10.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND T11.COD_MSG_CRITICA = T10.COD_MSG_CRITICA 
							AND T11.COD_TP_MSG_CRITICA <> '3' 
							)";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" M-0020-DECLARE-CURSOR-DB-OPEN-1 */
        public void M_0020_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -543- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-0030-FETCH-CURSOR-SECTION */
        private void M_0030_FETCH_CURSOR_SECTION()
        {
            /*" -556- MOVE '0030-FETCH-CURSOR' TO PARAGRAFO. */
            _.Move("0030-FETCH-CURSOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -560- MOVE '0030' TO COMANDO. */
            _.Move("0030", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -572- PERFORM M_0030_FETCH_CURSOR_DB_FETCH_1 */

            M_0030_FETCH_CURSOR_DB_FETCH_1();

            /*" -575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -576- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -577- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", WS_WORK_AREAS.WFIM_MOVIMENTO);

                    /*" -577- PERFORM M_0030_FETCH_CURSOR_DB_CLOSE_1 */

                    M_0030_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -579- GO TO 0030-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0030_FIM*/ //GOTO
                    return;

                    /*" -580- ELSE */
                }
                else
                {


                    /*" -582- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -582- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" M-0030-FETCH-CURSOR-DB-FETCH-1 */
        public void M_0030_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -572- EXEC SQL FETCH CPROPOSTA INTO :PROPOVA-AGE-COBRANCA, :PROPOVA-NUM-MATRI-VENDEDOR, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-DATA-QUITACAO, :PROPOVA-COD-CLIENTE, :VGPROP-COD-USUARIO:VIND-COD-USUARIO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-DATA-MOVIMENTO, :VGPROP-QTD-DIAS END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(CPROPOSTA.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(CPROPOSTA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPOSTA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CPROPOSTA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CPROPOSTA.VGPROP_COD_USUARIO, VGPROP_COD_USUARIO);
                _.Move(CPROPOSTA.VIND_COD_USUARIO, VIND_COD_USUARIO);
                _.Move(CPROPOSTA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPOSTA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPOSTA.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(CPROPOSTA.VGPROP_QTD_DIAS, VGPROP_QTD_DIAS);
            }

        }

        [StopWatch]
        /*" M-0030-FETCH-CURSOR-DB-CLOSE-1 */
        public void M_0030_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -577- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0030_FIM*/

        [StopWatch]
        /*" M-0035-SELECT-DEVOL-SECTION */
        private void M_0035_SELECT_DEVOL_SECTION()
        {
            /*" -591- MOVE '0035-SELECT-DEVOL   ' TO PARAGRAFO. */
            _.Move("0035-SELECT-DEVOL   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -595- MOVE '0035' TO COMANDO. */
            _.Move("0035", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -598- MOVE 116 TO DEVOLVID-COD-DEVOLUCAO. */
            _.Move(116, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);

            /*" -601- MOVE SPACES TO VGDEVO-DES-DEVOLUCAO. */
            _.Move("", VGDEVO_DES_DEVOLUCAO);

            /*" -606- PERFORM M_0035_SELECT_DEVOL_DB_SELECT_1 */

            M_0035_SELECT_DEVOL_DB_SELECT_1();

            /*" -609- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -610- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -611- MOVE ZEROS TO DEVOLVID-COD-DEVOLUCAO */
                    _.Move(0, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);

                    /*" -612- MOVE SPACES TO VGDEVO-DES-DEVOLUCAO */
                    _.Move("", VGDEVO_DES_DEVOLUCAO);

                    /*" -613- ELSE */
                }
                else
                {


                    /*" -614- DISPLAY 'ERRO NO ACESSO A TABELA DEVOLUCAO_VIDAZUL' */
                    _.Display($"ERRO NO ACESSO A TABELA DEVOLUCAO_VIDAZUL");

                    /*" -615- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -616- END-IF */
                }


                /*" -616- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0035-SELECT-DEVOL-DB-SELECT-1 */
        public void M_0035_SELECT_DEVOL_DB_SELECT_1()
        {
            /*" -606- EXEC SQL SELECT DESC_DEVOLUCAO INTO :VGDEVO-DES-DEVOLUCAO FROM SEGUROS.DEVOLUCAO_VIDAZUL WHERE COD_DEVOLUCAO = 116 END-EXEC. */

            var m_0035_SELECT_DEVOL_DB_SELECT_1_Query1 = new M_0035_SELECT_DEVOL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0035_SELECT_DEVOL_DB_SELECT_1_Query1.Execute(m_0035_SELECT_DEVOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGDEVO_DES_DEVOLUCAO, VGDEVO_DES_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0035_FIM*/

        [StopWatch]
        /*" M-0040-SELECIONA-SECTION */
        private void M_0040_SELECIONA_SECTION()
        {
            /*" -625- MOVE '0040-SELECIONA   ' TO PARAGRAFO. */
            _.Move("0040-SELECIONA   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -629- MOVE '0040' TO COMANDO. */
            _.Move("0040", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -630- PERFORM 0100-PROCESSAR UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty()))
            {

                M_0100_PROCESSAR_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0040_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSAR-SECTION */
        private void M_0100_PROCESSAR_SECTION()
        {
            /*" -639- MOVE '0100-PROCESSAR      ' TO PARAGRAFO. */
            _.Move("0100-PROCESSAR      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -643- MOVE '0100' TO COMANDO. */
            _.Move("0100", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -646- INITIALIZE LD01 REG-SVA0685B. */
            _.Initialize(
                LD01
                , REG_SVA0685B
            );

            /*" -648- PERFORM 0105-SELECT-COBHIS. */

            M_0105_SELECT_COBHIS_SECTION();

            /*" -649- IF WTEM-COBERHIST EQUAL 'N' */

            if (WS_WORK_AREAS.WTEM_COBERHIST == "N")
            {

                /*" -651- GO TO 0100-LEITURA. */

                M_0100_LEITURA(); //GOTO
                return;
            }


            /*" -653- PERFORM 0110-SELECT-PRODUTO. */

            M_0110_SELECT_PRODUTO_SECTION();

            /*" -654- IF WTEM-PRODUTO EQUAL 'N' */

            if (WS_WORK_AREAS.WTEM_PRODUTO == "N")
            {

                /*" -656- GO TO 0100-LEITURA. */

                M_0100_LEITURA(); //GOTO
                return;
            }


            /*" -658- PERFORM 0120-SELECT-HISCOBER. */

            M_0120_SELECT_HISCOBER_SECTION();

            /*" -660- PERFORM 0130-SELECT-CLIENTE. */

            M_0130_SELECT_CLIENTE_SECTION();

            /*" -662- PERFORM 0140-SELECT-OPCAO. */

            M_0140_SELECT_OPCAO_SECTION();

            /*" -664- PERFORM 0150-SELECT-ESTR-VIN. */

            M_0150_SELECT_ESTR_VIN_SECTION();

            /*" -665- IF WTEM-ESTRVIN EQUAL 'N' */

            if (WS_WORK_AREAS.WTEM_ESTRVIN == "N")
            {

                /*" -667- GO TO 0100-LEITURA. */

                M_0100_LEITURA(); //GOTO
                return;
            }


            /*" -669- PERFORM 0160-SELECT-CHEQUE. */

            M_0160_SELECT_CHEQUE_SECTION();

            /*" -669- PERFORM 0185-LIBERA-DADOS. */

            M_0185_LIBERA_DADOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0100_LEITURA */

            M_0100_LEITURA();

        }

        [StopWatch]
        /*" M-0100-LEITURA */
        private void M_0100_LEITURA(bool isPerform = false)
        {
            /*" -673- PERFORM 0030-FETCH-CURSOR. */

            M_0030_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0105-SELECT-COBHIS-SECTION */
        private void M_0105_SELECT_COBHIS_SECTION()
        {
            /*" -682- MOVE '0105-SELECT-COBHIS  ' TO PARAGRAFO. */
            _.Move("0105-SELECT-COBHIS  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -686- MOVE '0105' TO COMANDO. */
            _.Move("0105", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -689- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO);

            /*" -692- MOVE 'S' TO WTEM-COBERHIST. */
            _.Move("S", WS_WORK_AREAS.WTEM_COBERHIST);

            /*" -700- PERFORM M_0105_SELECT_COBHIS_DB_SELECT_1 */

            M_0105_SELECT_COBHIS_DB_SELECT_1();

            /*" -703- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -704- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -705- MOVE 'N' TO WTEM-COBERHIST */
                    _.Move("N", WS_WORK_AREAS.WTEM_COBERHIST);

                    /*" -706- ELSE */
                }
                else
                {


                    /*" -707- DISPLAY 'ERRO NO ACESSO A TABELA COBER_HIST_VIDAZUL' */
                    _.Display($"ERRO NO ACESSO A TABELA COBER_HIST_VIDAZUL");

                    /*" -708- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -709- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -710- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -711- END-IF */
                }


                /*" -711- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0105-SELECT-COBHIS-DB-SELECT-1 */
        public void M_0105_SELECT_COBHIS_DB_SELECT_1()
        {
            /*" -700- EXEC SQL SELECT COD_DEVOLUCAO INTO :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :DCLCOBER-HIST-VIDAZUL.NUM-CERTIFICADO AND NUM_PARCELA = 1 AND COD_DEVOLUCAO = 116 END-EXEC. */

            var m_0105_SELECT_COBHIS_DB_SELECT_1_Query1 = new M_0105_SELECT_COBHIS_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0105_SELECT_COBHIS_DB_SELECT_1_Query1.Execute(m_0105_SELECT_COBHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_DEVOLUCAO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0105_FIM*/

        [StopWatch]
        /*" M-0110-SELECT-PRODUTO-SECTION */
        private void M_0110_SELECT_PRODUTO_SECTION()
        {
            /*" -720- MOVE '0110-SELECT-PRODUTO ' TO PARAGRAFO. */
            _.Move("0110-SELECT-PRODUTO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -724- MOVE '0110' TO COMANDO. */
            _.Move("0110", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -727- MOVE PROPOVA-NUM-APOLICE TO PRODUVG-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -730- MOVE PROPOVA-COD-SUBGRUPO TO PRODUVG-COD-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -733- MOVE 'S' TO WTEM-PRODUTO. */
            _.Move("S", WS_WORK_AREAS.WTEM_PRODUTO);

            /*" -739- PERFORM M_0110_SELECT_PRODUTO_DB_SELECT_1 */

            M_0110_SELECT_PRODUTO_DB_SELECT_1();

            /*" -742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -743- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -744- MOVE 'N' TO WTEM-PRODUTO */
                    _.Move("N", WS_WORK_AREAS.WTEM_PRODUTO);

                    /*" -745- ELSE */
                }
                else
                {


                    /*" -746- DISPLAY 'ERRO NO ACESSO A TABELA PRODUTOS_VG ' */
                    _.Display($"ERRO NO ACESSO A TABELA PRODUTOS_VG ");

                    /*" -747- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -748- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -749- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -750- END-IF */
                }


                /*" -750- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-SELECT-PRODUTO-DB-SELECT-1 */
        public void M_0110_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -739- EXEC SQL SELECT NOME_PRODUTO INTO :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO END-EXEC. */

            var m_0110_SELECT_PRODUTO_DB_SELECT_1_Query1 = new M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(m_0110_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0120-SELECT-HISCOBER-SECTION */
        private void M_0120_SELECT_HISCOBER_SECTION()
        {
            /*" -759- MOVE '0120-SELECT-HISCOBER' TO PARAGRAFO. */
            _.Move("0120-SELECT-HISCOBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -763- MOVE '0120' TO COMANDO. */
            _.Move("0120", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -766- MOVE PROPOVA-NUM-CERTIFICADO TO HISCOBPR-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -774- PERFORM M_0120_SELECT_HISCOBER_DB_SELECT_1 */

            M_0120_SELECT_HISCOBER_DB_SELECT_1();

            /*" -777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -778- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -780- MOVE ZEROS TO HISCOBPR-IMPSEGUR HISCOBPR-VLPREMIO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);

                    /*" -781- ELSE */
                }
                else
                {


                    /*" -782- DISPLAY 'ERRO NO ACESSO A TABELA HIS_COBER_PROPOST ' */
                    _.Display($"ERRO NO ACESSO A TABELA HIS_COBER_PROPOST ");

                    /*" -783- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -784- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -785- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -786- END-IF */
                }


                /*" -786- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0120-SELECT-HISCOBER-DB-SELECT-1 */
        public void M_0120_SELECT_HISCOBER_DB_SELECT_1()
        {
            /*" -774- EXEC SQL SELECT IMPSEGUR, VLPREMIO INTO :HISCOBPR-IMPSEGUR, :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var m_0120_SELECT_HISCOBER_DB_SELECT_1_Query1 = new M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1.Execute(m_0120_SELECT_HISCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_FIM*/

        [StopWatch]
        /*" M-0130-SELECT-CLIENTE-SECTION */
        private void M_0130_SELECT_CLIENTE_SECTION()
        {
            /*" -795- MOVE '0130-SELECT-CLIENTE ' TO PARAGRAFO. */
            _.Move("0130-SELECT-CLIENTE ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -799- MOVE '0130' TO COMANDO. */
            _.Move("0130", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -802- MOVE PROPOVA-COD-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -809- PERFORM M_0130_SELECT_CLIENTE_DB_SELECT_1 */

            M_0130_SELECT_CLIENTE_DB_SELECT_1();

            /*" -812- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -813- DISPLAY 'ERRO NO ACESSO A TABELA DE CLIENTES ' */
                _.Display($"ERRO NO ACESSO A TABELA DE CLIENTES ");

                /*" -814- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -815- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -816- DISPLAY 'CODIGO CLIENTE ' CLIENTES-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -817- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -817- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0130-SELECT-CLIENTE-DB-SELECT-1 */
        public void M_0130_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -809- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var m_0130_SELECT_CLIENTE_DB_SELECT_1_Query1 = new M_0130_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_0130_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(m_0130_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_FIM*/

        [StopWatch]
        /*" M-0140-SELECT-OPCAO-SECTION */
        private void M_0140_SELECT_OPCAO_SECTION()
        {
            /*" -826- MOVE '0140-SELECT-OPCAO' TO PARAGRAFO. */
            _.Move("0140-SELECT-OPCAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -830- MOVE '0140' TO COMANDO. */
            _.Move("0140", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -833- MOVE PROPOVA-NUM-CERTIFICADO TO HISCOBPR-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -849- PERFORM M_0140_SELECT_OPCAO_DB_SELECT_1 */

            M_0140_SELECT_OPCAO_DB_SELECT_1();

            /*" -852- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -853- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -854- MOVE SPACES TO OPCPAGVI-OPCAO-PAGAMENTO */
                    _.Move("", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                    /*" -860- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                    _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                    /*" -861- ELSE */
                }
                else
                {


                    /*" -862- DISPLAY 'ERRO NO ACESSO A TABELA OPCAO_PAG_VIDAZUL ' */
                    _.Display($"ERRO NO ACESSO A TABELA OPCAO_PAG_VIDAZUL ");

                    /*" -863- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -864- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -865- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -866- END-IF */
                }


                /*" -868- END-IF. */
            }


            /*" -869- IF VIND-COD-AGE-DEB LESS -1 */

            if (VIND_COD_AGE_DEB < -1)
            {

                /*" -870- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -872- END-IF. */
            }


            /*" -873- IF VIND-OPE-CONTA-DEB LESS -1 */

            if (VIND_OPE_CONTA_DEB < -1)
            {

                /*" -874- MOVE ZEROS TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -876- END-IF. */
            }


            /*" -877- IF VIND-NUM-CONTA-DEB LESS -1 */

            if (VIND_NUM_CONTA_DEB < -1)
            {

                /*" -878- MOVE ZEROS TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -880- END-IF. */
            }


            /*" -881- IF VIND-DIG-CONTA-DEB LESS -1 */

            if (VIND_DIG_CONTA_DEB < -1)
            {

                /*" -882- MOVE ZEROS TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -884- END-IF. */
            }


            /*" -885- IF VIND-NUM-CARTAO LESS -1 */

            if (VIND_NUM_CARTAO < -1)
            {

                /*" -886- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -886- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0140-SELECT-OPCAO-DB-SELECT-1 */
        public void M_0140_SELECT_OPCAO_DB_SELECT_1()
        {
            /*" -849- EXEC SQL SELECT OPCAO_PAGAMENTO, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-COD-AGE-DEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE-CONTA-DEB, :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUM-CONTA-DEB, :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG-CONTA-DEB, :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUM-CARTAO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var m_0140_SELECT_OPCAO_DB_SELECT_1_Query1 = new M_0140_SELECT_OPCAO_DB_SELECT_1_Query1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0140_SELECT_OPCAO_DB_SELECT_1_Query1.Execute(m_0140_SELECT_OPCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_COD_AGE_DEB, VIND_COD_AGE_DEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPE_CONTA_DEB, VIND_OPE_CONTA_DEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUM_CONTA_DEB, VIND_NUM_CONTA_DEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIG_CONTA_DEB, VIND_DIG_CONTA_DEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_NUM_CARTAO, VIND_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0140_FIM*/

        [StopWatch]
        /*" M-0150-SELECT-ESTR-VIN-SECTION */
        private void M_0150_SELECT_ESTR_VIN_SECTION()
        {
            /*" -895- MOVE '0150-SELECT-ESTR-VIN' TO PARAGRAFO. */
            _.Move("0150-SELECT-ESTR-VIN", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -899- MOVE '0150' TO COMANDO. */
            _.Move("0150", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -902- MOVE PROPOVA-AGE-COBRANCA TO AGENCIAS-COD-AGENCIA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);

            /*" -905- MOVE 'S' TO WTEM-ESTRVIN. */
            _.Move("S", WS_WORK_AREAS.WTEM_ESTRVIN);

            /*" -922- PERFORM M_0150_SELECT_ESTR_VIN_DB_SELECT_1 */

            M_0150_SELECT_ESTR_VIN_DB_SELECT_1();

            /*" -925- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -926- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -927- MOVE 'N' TO WTEM-ESTRVIN */
                    _.Move("N", WS_WORK_AREAS.WTEM_ESTRVIN);

                    /*" -928- ELSE */
                }
                else
                {


                    /*" -929- DISPLAY 'ERRO NO ACESSO A ESTRUTURA VINCULADA ' */
                    _.Display($"ERRO NO ACESSO A ESTRUTURA VINCULADA ");

                    /*" -930- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -931- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -932- DISPLAY 'AGENCIA        ' AGENCIAS-COD-AGENCIA */
                    _.Display($"AGENCIA        {AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA}");

                    /*" -933- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -934- END-IF */
                }


                /*" -934- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0150-SELECT-ESTR-VIN-DB-SELECT-1 */
        public void M_0150_SELECT_ESTR_VIN_DB_SELECT_1()
        {
            /*" -922- EXEC SQL SELECT T1.COD_AGENCIA, T2.COD_ESCNEG, T2.REGIAO_ESCNEG, T3.COD_FONTE, T3.NOME_FONTE INTO :AGENCIAS-COD-AGENCIA, :ESCRINEG-COD-ESCNEG, :ESCRINEG-REGIAO-ESCNEG, :FONTES-COD-FONTE, :FONTES-NOME-FONTE FROM SEGUROS.AGENCIAS_CEF T1, SEGUROS.ESCRITORIO_NEGOCIO T2, SEGUROS.FONTES T3 WHERE T1.COD_AGENCIA = :AGENCIAS-COD-AGENCIA AND T1.COD_ESCNEG = T2.COD_ESCNEG AND T2.COD_FONTE = T3.COD_FONTE END-EXEC. */

            var m_0150_SELECT_ESTR_VIN_DB_SELECT_1_Query1 = new M_0150_SELECT_ESTR_VIN_DB_SELECT_1_Query1()
            {
                AGENCIAS_COD_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA.ToString(),
            };

            var executed_1 = M_0150_SELECT_ESTR_VIN_DB_SELECT_1_Query1.Execute(m_0150_SELECT_ESTR_VIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCIAS_COD_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);
                _.Move(executed_1.ESCRINEG_COD_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG);
                _.Move(executed_1.ESCRINEG_REGIAO_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG);
                _.Move(executed_1.FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0150_FIM*/

        [StopWatch]
        /*" M-0160-SELECT-CHEQUE-SECTION */
        private void M_0160_SELECT_CHEQUE_SECTION()
        {
            /*" -943- MOVE '0160-SELECT-CHEQUE  ' TO PARAGRAFO. */
            _.Move("0160-SELECT-CHEQUE  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -947- MOVE '0160' TO COMANDO. */
            _.Move("0160", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -950- MOVE PROPOVA-NUM-CERTIFICADO TO CBCONDEV-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -958- PERFORM M_0160_SELECT_CHEQUE_DB_SELECT_1 */

            M_0160_SELECT_CHEQUE_DB_SELECT_1();

            /*" -961- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -962- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -964- MOVE ZEROS TO CBCONDEV-NUM-CHEQUE-INTERNO CBCONDEV-DIG-CHEQUE-INTERNO */
                    _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

                    /*" -965- ELSE */
                }
                else
                {


                    /*" -966- DISPLAY 'ERRO NO ACESSO A TABELA CB_CONTR_DEVPREMIO' */
                    _.Display($"ERRO NO ACESSO A TABELA CB_CONTR_DEVPREMIO");

                    /*" -967- DISPLAY 'CERTIFICADO    ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -968- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -969- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -970- END-IF */
                }


                /*" -970- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0160-SELECT-CHEQUE-DB-SELECT-1 */
        public void M_0160_SELECT_CHEQUE_DB_SELECT_1()
        {
            /*" -958- EXEC SQL SELECT NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO INTO :CBCONDEV-NUM-CHEQUE-INTERNO, :CBCONDEV-DIG-CHEQUE-INTERNO FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO FETCH FIRST 1 ROW ONLY END-EXEC. */

            var m_0160_SELECT_CHEQUE_DB_SELECT_1_Query1 = new M_0160_SELECT_CHEQUE_DB_SELECT_1_Query1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0160_SELECT_CHEQUE_DB_SELECT_1_Query1.Execute(m_0160_SELECT_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBCONDEV_NUM_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.CBCONDEV_DIG_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0160_FIM*/

        [StopWatch]
        /*" M-0185-LIBERA-DADOS-SECTION */
        private void M_0185_LIBERA_DADOS_SECTION()
        {
            /*" -979- MOVE '0185-LIBERA-DADOS   ' TO PARAGRAFO. */
            _.Move("0185-LIBERA-DADOS   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -983- MOVE '0185' TO COMANDO. */
            _.Move("0185", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -986- MOVE PRODUVG-NOME-PRODUTO TO SVA-NOM-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, REG_SVA0685B.SVA_NOM_PRODUTO);

            /*" -989- MOVE FONTES-COD-FONTE TO SVA-COD-FILIAL. */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, REG_SVA0685B.SVA_COD_FILIAL);

            /*" -992- MOVE FONTES-NOME-FONTE TO SVA-NOM-FILIAL. */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, REG_SVA0685B.SVA_NOM_FILIAL);

            /*" -995- MOVE ESCRINEG-COD-ESCNEG TO SVA-COD-SR. */
            _.Move(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_COD_ESCNEG, REG_SVA0685B.SVA_COD_SR);

            /*" -998- MOVE ESCRINEG-REGIAO-ESCNEG TO SVA-NOM-SR. */
            _.Move(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG, REG_SVA0685B.SVA_NOM_SR);

            /*" -1001- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA0685B.SVA_NUM_CERTIFICADO);

            /*" -1004- MOVE VGPROP-QTD-DIAS TO SVA-QTD-DIAS. */
            _.Move(VGPROP_QTD_DIAS, REG_SVA0685B.SVA_QTD_DIAS);

            /*" -1007- MOVE CLIENTES-NOME-RAZAO TO SVA-NOM-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SVA0685B.SVA_NOM_SEGURADO);

            /*" -1010- MOVE CLIENTES-CGCCPF TO SVA-NUM-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SVA0685B.SVA_NUM_CGCCPF);

            /*" -1013- MOVE PROPOVA-DATA-QUITACAO TO SVA-DATA-QUITACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVA0685B.SVA_DATA_QUITACAO);

            /*" -1016- MOVE AGENCIAS-COD-AGENCIA TO SVA-COD-AGENCIA. */
            _.Move(AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA, REG_SVA0685B.SVA_COD_AGENCIA);

            /*" -1019- MOVE HISCOBPR-VLPREMIO TO SVA-VLR-PREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVA0685B.SVA_VLR_PREMIO);

            /*" -1022- MOVE HISCOBPR-IMPSEGUR TO SVA-VLR-IMPSEGUR. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, REG_SVA0685B.SVA_VLR_IMPSEGUR);

            /*" -1025- MOVE PROPOVA-DATA-MOVIMENTO TO SVA-DATA-CANCEL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, REG_SVA0685B.SVA_DATA_CANCEL);

            /*" -1026- EVALUATE OPCPAGVI-OPCAO-PAGAMENTO */
            switch (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.Value.Trim())
            {

                /*" -1026- WHEN    '1' */
                case "1":

                    /*" -1026- MOVE 'C/C' TO    SVA-DES-OPCAO-PG */
                    _.Move("C/C", REG_SVA0685B.SVA_DES_OPCAO_PG);

                    /*" -1027- WHEN    '2' */
                    break;
                case "2":

                    /*" -1027- MOVE 'POUPANCA'  TO    SVA-DES-OPCAO-PG */
                    _.Move("POUPANCA", REG_SVA0685B.SVA_DES_OPCAO_PG);

                    /*" -1028- WHEN    '3' */
                    break;
                case "3":

                    /*" -1028- MOVE 'BOLETO'  TO    SVA-DES-OPCAO-PG */
                    _.Move("BOLETO", REG_SVA0685B.SVA_DES_OPCAO_PG);

                    /*" -1029- WHEN    '4' */
                    break;
                case "4":

                    /*" -1029- MOVE 'AVERBACAO'   TO    SVA-DES-OPCAO-PG */
                    _.Move("AVERBACAO", REG_SVA0685B.SVA_DES_OPCAO_PG);

                    /*" -1030- WHEN    '5' */
                    break;
                case "5":

                    /*" -1030- MOVE 'CARTAO'        TO    SVA-DES-OPCAO-PG */
                    _.Move("CARTAO", REG_SVA0685B.SVA_DES_OPCAO_PG);

                    /*" -1031- WHEN    OTHER */
                    break;
                default:

                    /*" -1031- MOVE 'BOLETO'   TO    SVA-DES-OPCAO-PG */
                    _.Move("BOLETO", REG_SVA0685B.SVA_DES_OPCAO_PG);
                    /*" -1034- END-EVALUATE. */
                    break;
            }

            /*" -1037- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-COD-AGENCIA-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVA0685B.SVA_COD_AGENCIA_DEB);

            /*" -1040- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-COD-OPER-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVA0685B.SVA_COD_OPER_DEB);

            /*" -1043- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUM-CONTA-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVA0685B.SVA_NUM_CONTA_DEB);

            /*" -1046- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIG-CONTA-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVA0685B.SVA_DIG_CONTA_DEB);

            /*" -1049- MOVE CBCONDEV-NUM-CHEQUE-INTERNO TO SVA-NUM-CHEQUE. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO, REG_SVA0685B.SVA_NUM_CHEQUE);

            /*" -1052- MOVE CBCONDEV-DIG-CHEQUE-INTERNO TO SVA-DIG-CHEQUE. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO, REG_SVA0685B.SVA_DIG_CHEQUE);

            /*" -1055- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO SVA-NUM-CARTAO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, REG_SVA0685B.SVA_NUM_CARTAO);

            /*" -1058- MOVE SPACES TO W-NUM-MATRI-VENDEDOR. */
            _.Move("", WS_WORK_AREAS.W_NUM_MATRI_VENDEDOR);

            /*" -1061- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO W-NUM-MATRI-VENDEDOR. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, WS_WORK_AREAS.W_NUM_MATRI_VENDEDOR);

            /*" -1064- MOVE W-NUM-MATRI-VENDEDOR (8:8) TO SVA-COD-INDICADOR. */
            _.Move(WS_WORK_AREAS.W_NUM_MATRI_VENDEDOR.Substring(8, 8), REG_SVA0685B.SVA_COD_INDICADOR);

            /*" -1067- MOVE DEVOLVID-COD-DEVOLUCAO TO SVA-COD-MOTIVO. */
            _.Move(DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO, REG_SVA0685B.SVA_COD_MOTIVO);

            /*" -1070- MOVE VGDEVO-DES-DEVOLUCAO TO SVA-DES-MOTIVO. */
            _.Move(VGDEVO_DES_DEVOLUCAO, REG_SVA0685B.SVA_DES_MOTIVO);

            /*" -1073- MOVE VGPROP-COD-USUARIO TO SVA-COD-USUARIO. */
            _.Move(VGPROP_COD_USUARIO, REG_SVA0685B.SVA_COD_USUARIO);

            /*" -1073- RELEASE REG-SVA0685B. */
            SVA0685B.Release(REG_SVA0685B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0185_FIM*/

        [StopWatch]
        /*" M-0190-GERA-ARQ-SECTION */
        private void M_0190_GERA_ARQ_SECTION()
        {
            /*" -1082- MOVE '0190-GERA-ARQ    ' TO PARAGRAFO. */
            _.Move("0190-GERA-ARQ    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1086- MOVE '0190' TO COMANDO. */
            _.Move("0190", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1088- PERFORM 0195-LE-SORT. */

            M_0195_LE_SORT_SECTION();

            /*" -1090- WRITE REG-SAIDA FROM LC01. */
            _.Move(LC01.GetMoveValues(), REG_SAIDA);

            ARQ_SAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1091- PERFORM 0200-PROCESSA UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_SORT == "S"))
            {

                M_0200_PROCESSA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0190_FIM*/

        [StopWatch]
        /*" M-0195-LE-SORT-SECTION */
        private void M_0195_LE_SORT_SECTION()
        {
            /*" -1100- MOVE '0195-LE-SORT     ' TO PARAGRAFO. */
            _.Move("0195-LE-SORT     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1104- MOVE '0195' TO COMANDO. */
            _.Move("0195", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1106- RETURN SVA0685B AT END */
            try
            {
                SVA0685B.Return(REG_SVA0685B, () =>
                {

                    /*" -1108- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WS_WORK_AREAS.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1108- ADD 1 TO AC-LIDOS-SORT. */
            WS_WORK_AREAS.AC_LIDOS_SORT.Value = WS_WORK_AREAS.AC_LIDOS_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0195_FIM*/

        [StopWatch]
        /*" M-0200-PROCESSA-SECTION */
        private void M_0200_PROCESSA_SECTION()
        {
            /*" -1117- MOVE '0200-PROCESSA    ' TO PARAGRAFO. */
            _.Move("0200-PROCESSA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1121- MOVE '0200' TO COMANDO. */
            _.Move("0200", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1121- PERFORM 0210-MOVE-ANALITICO. */

            M_0210_MOVE_ANALITICO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_0200_LEITURA */

            M_0200_LEITURA();

        }

        [StopWatch]
        /*" M-0200-LEITURA */
        private void M_0200_LEITURA(bool isPerform = false)
        {
            /*" -1125- PERFORM 0195-LE-SORT. */

            M_0195_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0210-MOVE-ANALITICO-SECTION */
        private void M_0210_MOVE_ANALITICO_SECTION()
        {
            /*" -1134- MOVE '0210-MOVE-ANALITICO' TO PARAGRAFO. */
            _.Move("0210-MOVE-ANALITICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1138- MOVE '0210' TO COMANDO. */
            _.Move("0210", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1141- MOVE SVA-NOM-PRODUTO TO LD01-NOM-PRODUTO. */
            _.Move(REG_SVA0685B.SVA_NOM_PRODUTO, LD01.LD01_NOM_PRODUTO);

            /*" -1144- MOVE SVA-COD-FILIAL TO LD01-COD-FILIAL. */
            _.Move(REG_SVA0685B.SVA_COD_FILIAL, LD01.LD01_COD_FILIAL);

            /*" -1147- MOVE SVA-NOM-FILIAL TO LD01-NOM-FILIAL. */
            _.Move(REG_SVA0685B.SVA_NOM_FILIAL, LD01.LD01_NOM_FILIAL);

            /*" -1150- MOVE SVA-COD-SR TO LD01-COD-SR. */
            _.Move(REG_SVA0685B.SVA_COD_SR, LD01.LD01_COD_SR);

            /*" -1153- MOVE SVA-NOM-SR TO LD01-NOM-SR. */
            _.Move(REG_SVA0685B.SVA_NOM_SR, LD01.LD01_NOM_SR);

            /*" -1156- MOVE SVA-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO. */
            _.Move(REG_SVA0685B.SVA_NUM_CERTIFICADO, LD01.LD01_NUM_CERTIFICADO);

            /*" -1159- MOVE SVA-QTD-DIAS TO LD01-QTD-DIAS. */
            _.Move(REG_SVA0685B.SVA_QTD_DIAS, LD01.LD01_QTD_DIAS);

            /*" -1162- MOVE SVA-NOM-SEGURADO TO LD01-NOM-SEGURADO. */
            _.Move(REG_SVA0685B.SVA_NOM_SEGURADO, LD01.LD01_NOM_SEGURADO);

            /*" -1165- MOVE SVA-NUM-CGCCPF TO LD01-NUM-CGCCPF. */
            _.Move(REG_SVA0685B.SVA_NUM_CGCCPF, LD01.LD01_NUM_CGCCPF);

            /*" -1168- MOVE SVA-DATA-QUITACAO TO LD01-DATA-QUITACAO. */
            _.Move(REG_SVA0685B.SVA_DATA_QUITACAO, LD01.LD01_DATA_QUITACAO);

            /*" -1171- MOVE SVA-COD-AGENCIA TO LD01-COD-AGENCIA. */
            _.Move(REG_SVA0685B.SVA_COD_AGENCIA, LD01.LD01_COD_AGENCIA);

            /*" -1174- MOVE SVA-VLR-PREMIO TO LD01-VLR-PREMIO. */
            _.Move(REG_SVA0685B.SVA_VLR_PREMIO, LD01.LD01_VLR_PREMIO);

            /*" -1177- MOVE SVA-VLR-IMPSEGUR TO LD01-VLR-IMPSEGUR. */
            _.Move(REG_SVA0685B.SVA_VLR_IMPSEGUR, LD01.LD01_VLR_IMPSEGUR);

            /*" -1180- MOVE SVA-DATA-CANCEL TO LD01-DATA-CANCEL. */
            _.Move(REG_SVA0685B.SVA_DATA_CANCEL, LD01.LD01_DATA_CANCEL);

            /*" -1183- MOVE SVA-DES-OPCAO-PG TO LD01-DES-OPCAO-PG */
            _.Move(REG_SVA0685B.SVA_DES_OPCAO_PG, LD01.LD01_DES_OPCAO_PG);

            /*" -1186- MOVE SVA-COD-AGENCIA-DEB TO LD01-COD-AGENCIA-DEB. */
            _.Move(REG_SVA0685B.SVA_COD_AGENCIA_DEB, LD01.LD01_COD_AGENCIA_DEB);

            /*" -1189- MOVE SVA-COD-OPER-DEB TO LD01-COD-OPER-DEB. */
            _.Move(REG_SVA0685B.SVA_COD_OPER_DEB, LD01.LD01_COD_OPER_DEB);

            /*" -1192- MOVE SVA-NUM-CONTA-DEB TO LD01-NUM-CONTA-DEB. */
            _.Move(REG_SVA0685B.SVA_NUM_CONTA_DEB, LD01.LD01_NUM_CONTA_DEB);

            /*" -1195- MOVE SVA-DIG-CONTA-DEB TO LD01-DIG-CONTA-DEB. */
            _.Move(REG_SVA0685B.SVA_DIG_CONTA_DEB, LD01.LD01_DIG_CONTA_DEB);

            /*" -1198- MOVE SVA-NUM-CHEQUE TO LD01-NUM-CHEQUE. */
            _.Move(REG_SVA0685B.SVA_NUM_CHEQUE, LD01.LD01_NUM_CHEQUE);

            /*" -1201- MOVE SVA-DIG-CHEQUE TO LD01-DIG-CHEQUE. */
            _.Move(REG_SVA0685B.SVA_DIG_CHEQUE, LD01.LD01_DIG_CHEQUE);

            /*" -1204- MOVE SVA-NUM-CARTAO TO LD01-NUM-CARTAO. */
            _.Move(REG_SVA0685B.SVA_NUM_CARTAO, LD01.LD01_NUM_CARTAO);

            /*" -1207- MOVE SVA-COD-INDICADOR TO LD01-COD-INDICADOR. */
            _.Move(REG_SVA0685B.SVA_COD_INDICADOR, LD01.LD01_COD_INDICADOR);

            /*" -1210- MOVE SVA-COD-MOTIVO TO LD01-COD-MOTIVO. */
            _.Move(REG_SVA0685B.SVA_COD_MOTIVO, LD01.LD01_COD_MOTIVO);

            /*" -1213- MOVE SVA-DES-MOTIVO TO LD01-DES-MOTIVO. */
            _.Move(REG_SVA0685B.SVA_DES_MOTIVO, LD01.LD01_DES_MOTIVO);

            /*" -1216- MOVE SVA-COD-USUARIO TO LD01-COD-USUARIO. */
            _.Move(REG_SVA0685B.SVA_COD_USUARIO, LD01.LD01_COD_USUARIO);

            /*" -1216- WRITE REG-SAIDA FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SAIDA);

            ARQ_SAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0210_FIM*/

        [StopWatch]
        /*" M-0250-ATUALIZA-RELAT-SECTION */
        private void M_0250_ATUALIZA_RELAT_SECTION()
        {
            /*" -1225- MOVE '0250-ATUALIZA-RELAT ' TO PARAGRAFO. */
            _.Move("0250-ATUALIZA-RELAT ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1229- MOVE '0250' TO COMANDO. */
            _.Move("0250", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1234- PERFORM M_0250_ATUALIZA_RELAT_DB_UPDATE_1 */

            M_0250_ATUALIZA_RELAT_DB_UPDATE_1();

            /*" -1237- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1238- DISPLAY 'ERRO NO UPDATE DA TABELA DE RELATORIOS' */
                _.Display($"ERRO NO UPDATE DA TABELA DE RELATORIOS");

                /*" -1239- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1239- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0250-ATUALIZA-RELAT-DB-UPDATE-1 */
        public void M_0250_ATUALIZA_RELAT_DB_UPDATE_1()
        {
            /*" -1234- EXEC SQL UPDATE SEGUROS.RELATORIOS SET PERI_INICIAL = :WSIST-DTCURREN WHERE COD_USUARIO = 'VA0685B' AND COD_RELATORIO = 'VA0685B' END-EXEC. */

            var m_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1 = new M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1()
            {
                WSIST_DTCURREN = WSIST_DTCURREN.ToString(),
            };

            M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1.Execute(m_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0250_FIM*/

        [StopWatch]
        /*" M-9997-FECHAR-ARQUIVOS-SECTION */
        private void M_9997_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1248- MOVE '9997-FECHAR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("9997-FECHAR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1252- MOVE '9997' TO COMANDO. */
            _.Move("9997", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1252- CLOSE ARQ-SAIDA. */
            ARQ_SAIDA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9997_FIM*/

        [StopWatch]
        /*" M-9998-FINALIZAR-SECTION */
        private void M_9998_FINALIZAR_SECTION()
        {
            /*" -1261- MOVE '9998-FINALIZAR      ' TO PARAGRAFO. */
            _.Move("9998-FINALIZAR      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1265- MOVE '9998' TO COMANDO. */
            _.Move("9998", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1266- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1266- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1269- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -1271- DISPLAY '** VA0685B ** TERMINO NORMAL    ' . */
            _.Display($"** VA0685B ** TERMINO NORMAL    ");

            /*" -1273- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1275- PERFORM 9997-FECHAR-ARQUIVOS. */

            M_9997_FECHAR_ARQUIVOS_SECTION();

            /*" -1275- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9998_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -1286- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1287- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1288- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1290- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1291- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

            /*" -1293- DISPLAY WSQLERRO. */
            _.Display(WABEND.WSQLERRO);

            /*" -1295- DISPLAY '*** VA0685B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0685B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1295- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1298- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1299- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1299- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1303- DISPLAY '*** VA0685B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0685B *** ERRO DE EXECUCAO");

            /*" -1305- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1305- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/
    }
}