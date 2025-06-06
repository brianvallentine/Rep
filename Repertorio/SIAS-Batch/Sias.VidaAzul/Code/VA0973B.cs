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
using Sias.VidaAzul.DB2.VA0973B;

namespace Code
{
    public class VA0973B
    {
        public bool IsCall { get; set; }

        public VA0973B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-*************************** BOTTOM OF DATA *********************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      *                                                                *      */
        /*"      *   PROJETO CARTAO DE CREDITO CIELO.                             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  DANIEL MEDINA GOMIDE - MILLENIUM   *      */
        /*"      *   DATA CODIFICACAO .......  05/06/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  RELATORIO SEGUROS COM OPCAO DE     *      */
        /*"      *   CARTAO DE CREDITOS COM PARCELAS EM ATRASO                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.ZZ                                               *      */
        /*"      *  JAZ......: XXXXX           PROGRAMADOR:                       *      */
        /*"      *  DATA ....: 99/99/9999                                         *      */
        /*"      *  DESCRICAO:                                                    *      */
        /*"      *                                          PROCURE POR V.XX      *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RETCIELO { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis RETCIELO
        {
            get
            {
                _.Move(REG_CIELO, _RETCIELO); VarBasis.RedefinePassValue(REG_CIELO, _RETCIELO, REG_CIELO); return _RETCIELO;
            }
        }
        /*"01  REG-CIELO                   PIC X(0350).*/
        public StringBasis REG_CIELO { get; set; } = new StringBasis(new PIC("X", "350", "X(0350)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WORK-AREA.*/
        public VA0973B_WORK_AREA WORK_AREA { get; set; } = new VA0973B_WORK_AREA();
        public class VA0973B_WORK_AREA : VarBasis
        {
            /*"    05 WS-AC-SEMRET                 PIC 9(06) VALUE ZEROS.*/
            public IntBasis WS_AC_SEMRET { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 WS-FIM-PARCELAS              PIC X(01) VALUE SPACES.*/
            public StringBasis WS_FIM_PARCELAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 WS-HOST-DT-HOJE              PIC X(10) VALUE SPACES.*/
            public StringBasis WS_HOST_DT_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 WS-HOST-DT-MAIS5D            PIC X(10) VALUE SPACES.*/
            public StringBasis WS_HOST_DT_MAIS5D { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 WS-HOST-DES-SITU             PIC X(25) VALUE SPACES.*/
            public StringBasis WS_HOST_DES_SITU { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
            /*"01  CAB1.*/
        }
        public VA0973B_CAB1 CAB1 { get; set; } = new VA0973B_CAB1();
        public class VA0973B_CAB1 : VarBasis
        {
            /*"    05 FILLER                       PIC X(07) VALUE 'VA0973B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA0973B");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(51) VALUE       'PARCELAS EM ATRASO PAGAMENTO CARTAO CIELO - CR�DITO'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"PARCELAS EM ATRASO PAGAMENTO CARTAO CIELO - CR�DITO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(17) VALUE       'DT.PROCESSAMENTO:'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DT.PROCESSAMENTO:");
            /*"    05 CAB1-DATA-ATU                PIC X(10).*/
            public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(15) VALUE       'DT.VENCIMENTO:'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DT.VENCIMENTO:");
            /*"    05 CAB1-DATA-CORTE              PIC X(14).*/
            public StringBasis CAB1_DATA_CORTE { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(14) VALUE       'DT.TOLER�NCIA:'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT.TOLER�NCIA:");
            /*"    05 CAB1-DATA-TOLER              PIC X(10).*/
            public StringBasis CAB1_DATA_TOLER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB2.*/
        }
        public VA0973B_CAB2 CAB2 { get; set; } = new VA0973B_CAB2();
        public class VA0973B_CAB2 : VarBasis
        {
            /*"    05 FILLER                       PIC X(17)       VALUE 'NOME DO CLIENTE '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"NOME DO CLIENTE ");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(11)       VALUE 'CPF CLIENTE'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CPF CLIENTE");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(11)       VALUE 'CERTIFICADO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(07)       VALUE 'AP�LICE'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AP�LICE");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(08)       VALUE 'SUBGRUPO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SUBGRUPO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(07)       VALUE 'PARCELA'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PARCELA");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(18)       VALUE 'SITUA��O DO SEGURO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"SITUA��O DO SEGURO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(11)       VALUE 'COD.PRODUTO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD.PRODUTO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(20)       VALUE 'DESCRI��O DO PRODUTO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"DESCRI��O DO PRODUTO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(10)       VALUE 'IDLG (SAP)'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"IDLG (SAP)");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(18)       VALUE 'DATA DO VENCIMENTO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DATA DO VENCIMENTO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(26)       VALUE 'DATA PREVISTA PARA CR�DITO'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"DATA PREVISTA PARA CR�DITO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(23)       VALUE 'DATA PR�XIMO VENCIMENTO'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"DATA PR�XIMO VENCIMENTO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(13)       VALUE 'DIA DO DEBITO'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DIA DO DEBITO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC X(15)       VALUE 'VALOR DO PR�MIO'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR DO PR�MIO");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  DET1.*/
        }
        public VA0973B_DET1 DET1 { get; set; } = new VA0973B_DET1();
        public class VA0973B_DET1 : VarBasis
        {
            /*"    05 DET-NOM-SEGURADO             PIC X(40).*/
            public StringBasis DET_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-CGCCPF                   PIC 9(11).*/
            public IntBasis DET_CGCCPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-NUM-CERTIFICADO          PIC 9(14).*/
            public IntBasis DET_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-NUM-APOLICE              PIC 9(12).*/
            public IntBasis DET_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-COD-SUBGRUPO             PIC 9(03).*/
            public IntBasis DET_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-NUM-PARCELA              PIC 9(03).*/
            public IntBasis DET_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DES-SITUACAO             PIC X(42).*/
            public StringBasis DET_DES_SITUACAO { get; set; } = new StringBasis(new PIC("X", "42", "X(42)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-COD-PRODUTO              PIC 9(04).*/
            public IntBasis DET_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DES-PRODUTO              PIC X(25).*/
            public StringBasis DET_DES_PRODUTO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-COD-IDLG                 PIC X(40).*/
            public StringBasis DET_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DT-VENCIMENTO            PIC X(10).*/
            public StringBasis DET_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DT-PREV-CRED             PIC X(10).*/
            public StringBasis DET_DT_PREV_CRED { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DT-PROX-VENC             PIC X(10).*/
            public StringBasis DET_DT_PROX_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DIA-DEBITO               PIC 9(02).*/
            public IntBasis DET_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-VALOR-COBRANCA           PIC Z.ZZZ.ZZ9,99.*/
            public DoubleBasis DET_VALOR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
            /*"    05 FILLER                       PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  ABEND.*/
        }
        public VA0973B_ABEND ABEND { get; set; } = new VA0973B_ABEND();
        public class VA0973B_ABEND : VarBasis
        {
            /*"    03  WS-ABEND.*/
            public VA0973B_WS_ABEND WS_ABEND { get; set; } = new VA0973B_WS_ABEND();
            public class VA0973B_WS_ABEND : VarBasis
            {
                /*"        05 FILLER                   PIC X(010) VALUE        ' VA0973B  '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0973B  ");
                /*"        05 FILLER                   PIC X(028) VALUE        ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"        05 WNR-EXEC-SQL             PIC X(040) VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    03  WS-ABEND1.*/
            }
            public VA0973B_WS_ABEND1 WS_ABEND1 { get; set; } = new VA0973B_WS_ABEND1();
            public class VA0973B_WS_ABEND1 : VarBasis
            {
                /*"        05 FILLER                   PIC X(012) VALUE        ' SQLCODE  = '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLCODE  = ");
                /*"        05 WS-SQLCODE               PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"        05 FILLER                   PIC X(012) VALUE        ' SQLERRD1 = '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"        05 WSQLERRD1                PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"        05 FILLER                   PIC X(012) VALUE        ' SQLERRD2 = '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"        05   WSQLERRD2              PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.GE407 GE407 { get; set; } = new Dclgens.GE407();
        public Dclgens.GE408 GE408 { get; set; } = new Dclgens.GE408();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();

        public VA0973B_CPARCELAS CPARCELAS { get; set; } = new VA0973B_CPARCELAS(false);
        string GetQuery_CPARCELAS()
        {
            var query = @$"SELECT A.NUM_CERTIFICADO
							,CASE B.SIT_REGISTRO WHEN '3' THEN 'INTEGRADA ' WHEN '4' THEN 'CANCELADA AP�S INTEGRA��O' WHEN '6' THEN 'COBERTURA SUSPENSA' END
							,A.NUM_PARCELA
							,B.NUM_APOLICE
							,B.COD_SUBGRUPO
							,D.COD_IDLG
							,C.DATA_VENCIMENTO
							,E.DTA_CREDITO
							,B.DTPROXVEN
							,G.DIA_DEBITO
							,A.PRM_TOTAL
							,B.COD_PRODUTO
							,F.NOME_PRODUTO
							,H.NOME_RAZAO
							,H.CGCCPF
							,I.DDD
							,I.TELEFONE
							FROM SEGUROS.HIST_LANC_CTA A
							,SEGUROS.PROPOSTAS_VA B
							,SEGUROS.PARCELAS_VIDAZUL C
							,SEGUROS.GE_CONTROLE_CARTAO_CIELO D
							,SEGUROS.GE_RETORNO_CA_CIELO E
							,SEGUROS.PRODUTOS_VG F
							,SEGUROS.OPCAO_PAG_VIDAZUL G
							,SEGUROS.CLIENTES H
							,SEGUROS.ENDERECOS I WHERE A.SIT_REGISTRO = '3' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.SIT_REGISTRO IN ('3'
							,'6'
							,'4') AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA AND C.OPCAO_PAGAMENTO = '5' AND A.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND A.NUM_PARCELA = D.NUM_PARCELA AND D.COD_TP_PAGAMENTO IN ('01'
							,'02') AND D.STA_REGISTRO = 'A' AND D.NUM_CERTIFICADO = E.NUM_CERTIFICADO AND D.NUM_PARCELA = E.NUM_PARCELA AND D.NUM_PROPOSTA = E.NUM_PROPOSTA AND E.DTA_CREDITO + 5 DAYS <= CURRENT DATE AND D.SEQ_CONTROL_CARTAO = E.SEQ_CONTROL_CARTAO AND E.COD_MOVIMENTO = '03' AND B.NUM_APOLICE = F.NUM_APOLICE AND B.COD_SUBGRUPO = F.COD_SUBGRUPO AND B.COD_PRODUTO = F.COD_PRODUTO AND A.NUM_CERTIFICADO = G.NUM_CERTIFICADO AND G.DATA_TERVIGENCIA = '9999-12-31' AND B.COD_CLIENTE = H.COD_CLIENTE AND H.COD_CLIENTE = I.COD_CLIENTE AND B.OCOREND = I.OCORR_ENDERECO ORDER BY A.NUM_PARCELA
							,B.COD_PRODUTO
							,A.NUM_CERTIFICADO";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETCIELO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETCIELO.SetFile(RETCIELO_FILE_NAME_P);
                InitializeGetQuery();

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

        public void InitializeGetQuery()
        {
            CPARCELAS.GetQueryEvent += GetQuery_CPARCELAS;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -294- MOVE '0000-00-PRINCIPAL' TO WNR-EXEC-SQL. */
            _.Move("0000-00-PRINCIPAL", ABEND.WS_ABEND.WNR_EXEC_SQL);

            /*" -302- DISPLAY 'VERSAO V.00 : ' FUNCTION WHEN-COMPILED '- VA0973B ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VERSAO V.00 : FUNCTION{_.WhenCompiled()}- VA0973B {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -304- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -307- OPEN OUTPUT RETCIELO */
            RETCIELO.Open(REG_CIELO);

            /*" -309- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -312- IF (SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -313- DISPLAY '0000-00-ERRO OPEN CURSOR CPARCELAS' */
                _.Display($"0000-00-ERRO OPEN CURSOR CPARCELAS");

                /*" -314- DISPLAY 'CODIGO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CODIGO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -315- DISPLAY 'CODIGO = ' PROPOVA-NUM-PARCELA */
                _.Display($"CODIGO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -316- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -318- END-IF */
            }


            /*" -319- MOVE 'N' TO WS-FIM-PARCELAS */
            _.Move("N", WORK_AREA.WS_FIM_PARCELAS);

            /*" -321- PERFORM R1010-00-FETCH-PARCELAS. */

            R1010_00_FETCH_PARCELAS_SECTION();

            /*" -322- IF WS-FIM-PARCELAS EQUAL 'S' */

            if (WORK_AREA.WS_FIM_PARCELAS == "S")
            {

                /*" -323- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -324- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -325- DISPLAY '*  VA0973B - RELATORIO DE SEGUROS COM PAGA-*' */
                _.Display($"*  VA0973B - RELATORIO DE SEGUROS COM PAGA-*");

                /*" -326- DISPLAY '*  -------   ----------------------------- *' */
                _.Display($"*  -------   ----------------------------- *");

                /*" -327- DISPLAY '*            MENTOS C. CREDITO EM ATRASO   *' */
                _.Display($"*            MENTOS C. CREDITO EM ATRASO   *");

                /*" -328- DISPLAY '*            ----------------------------- *' */
                _.Display($"*            ----------------------------- *");

                /*" -329- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -330- DISPLAY '*   NENHUM  REGISTRO PENDENTE DE PAGAMENTO *' */
                _.Display($"*   NENHUM  REGISTRO PENDENTE DE PAGAMENTO *");

                /*" -331- DISPLAY '*           NESTA DATA                     *' */
                _.Display($"*           NESTA DATA                     *");

                /*" -332- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -333- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -335- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -337- PERFORM R2000-00-MOVIMENTA-DADOS */

            R2000_00_MOVIMENTA_DADOS_SECTION();

            /*" -338- WRITE REG-CIELO FROM CAB1 */
            _.Move(CAB1.GetMoveValues(), REG_CIELO);

            RETCIELO.Write(REG_CIELO.GetMoveValues().ToString());

            /*" -340- WRITE REG-CIELO FROM CAB2 */
            _.Move(CAB2.GetMoveValues(), REG_CIELO);

            RETCIELO.Write(REG_CIELO.GetMoveValues().ToString());

            /*" -344- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-FIM-PARCELAS EQUAL 'S' */

            while (!(WORK_AREA.WS_FIM_PARCELAS == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -346- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -347- DISPLAY '*** VA0973B ***************************' */
            _.Display($"*** VA0973B ***************************");

            /*" -348- DISPLAY '*            ' */
            _.Display($"*            ");

            /*" -349- DISPLAY '* PARCELAS SEM RETORNO: ' WS-AC-SEMRET */
            _.Display($"* PARCELAS SEM RETORNO: {WORK_AREA.WS_AC_SEMRET}");

            /*" -350- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -352- DISPLAY '*** VA0973B - TERMINO NORMAL ***********' */
            _.Display($"*** VA0973B - TERMINO NORMAL ***********");

            /*" -354- CLOSE RETCIELO */
            RETCIELO.Close();

            /*" -354- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -309- EXEC SQL OPEN CPARCELAS END-EXEC */

            CPARCELAS.Open();

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -361- MOVE 'R0100-00-SELECT-SISTEMAS' TO WNR-EXEC-SQL. */
            _.Move("R0100-00-SELECT-SISTEMAS", ABEND.WS_ABEND.WNR_EXEC_SQL);

            /*" -373- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -376- DISPLAY 'DATA PROCESSAMENTO : ' WS-HOST-DT-HOJE */
            _.Display($"DATA PROCESSAMENTO : {WORK_AREA.WS_HOST_DT_HOJE}");

            /*" -377- DISPLAY 'DATA MOVIMENTO.... : ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA MOVIMENTO.... : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -379- DISPLAY 'DATA TOLERANCIA... : ' WS-HOST-DT-MAIS5D */
            _.Display($"DATA TOLERANCIA... : {WORK_AREA.WS_HOST_DT_MAIS5D}");

            /*" -381-  EVALUATE SQLCODE  */

            /*" -382-  WHEN ZEROS  */

            /*" -382- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -384- CONTINUE */

                /*" -385-  WHEN 100  */

                /*" -385- ELSE IF   SQLCODE EQUALS  100 */
            }
            else

            if (DB.SQLCODE == 100)
            {

                /*" -386- DISPLAY '0100-ERRO-SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"0100-ERRO-SISTEMA NAO ESTA CADASTRADO");

                /*" -387- DISPLAY 'SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                _.Display($"SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -389- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -390-  WHEN OTHER  */

                /*" -390- ELSE */
            }
            else
            {


                /*" -391- DISPLAY '0100-00-ERRO SELECT SISTEMAS  ' */
                _.Display($"0100-00-ERRO SELECT SISTEMAS  ");

                /*" -392- DISPLAY 'SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                _.Display($"SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -396-  END-EVALUATE  */

                /*" -396- END-IF */
            }


            /*" -397- MOVE WS-HOST-DT-HOJE(9:2) TO CAB1-DATA-ATU(1:2) */
            _.MoveAtPosition(WORK_AREA.WS_HOST_DT_HOJE.Substring(9, 2), CAB1.CAB1_DATA_ATU, 1, 2);

            /*" -398- MOVE WS-HOST-DT-HOJE(6:2) TO CAB1-DATA-ATU(4:2) */
            _.MoveAtPosition(WORK_AREA.WS_HOST_DT_HOJE.Substring(6, 2), CAB1.CAB1_DATA_ATU, 4, 2);

            /*" -399- MOVE WS-HOST-DT-HOJE(1:4) TO CAB1-DATA-ATU(7:4) */
            _.MoveAtPosition(WORK_AREA.WS_HOST_DT_HOJE.Substring(1, 4), CAB1.CAB1_DATA_ATU, 7, 4);

            /*" -401- MOVE '/' TO CAB1-DATA-ATU(6:1) */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_ATU, 6, 1);

            /*" -401- MOVE '/' TO CAB1-DATA-ATU(3:1) */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_ATU, 3, 1);

            /*" -403- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO CAB1-DATA-CORTE(1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), CAB1.CAB1_DATA_CORTE, 1, 2);

            /*" -405- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO CAB1-DATA-CORTE(4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), CAB1.CAB1_DATA_CORTE, 4, 2);

            /*" -407- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO CAB1-DATA-CORTE(7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), CAB1.CAB1_DATA_CORTE, 7, 4);

            /*" -410- MOVE '/' TO CAB1-DATA-CORTE(6:1) */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_CORTE, 6, 1);

            /*" -410- MOVE '/' TO CAB1-DATA-CORTE(3:1) */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_CORTE, 3, 1);

            /*" -411- MOVE WS-HOST-DT-MAIS5D(9:2) TO CAB1-DATA-TOLER(1:2) */
            _.MoveAtPosition(WORK_AREA.WS_HOST_DT_MAIS5D.Substring(9, 2), CAB1.CAB1_DATA_TOLER, 1, 2);

            /*" -412- MOVE WS-HOST-DT-MAIS5D(6:2) TO CAB1-DATA-TOLER(4:2) */
            _.MoveAtPosition(WORK_AREA.WS_HOST_DT_MAIS5D.Substring(6, 2), CAB1.CAB1_DATA_TOLER, 4, 2);

            /*" -413- MOVE WS-HOST-DT-MAIS5D(1:4) TO CAB1-DATA-TOLER(7:4) */
            _.MoveAtPosition(WORK_AREA.WS_HOST_DT_MAIS5D.Substring(1, 4), CAB1.CAB1_DATA_TOLER, 7, 4);

            /*" -414- MOVE '/' TO CAB1-DATA-TOLER(6:1). */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_TOLER, 6, 1);

            /*" -414- MOVE '/' TO CAB1-DATA-TOLER(3:1) */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_TOLER, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -373- EXEC SQL SELECT DATA_MOV_ABERTO ,CURRENT DATE ,(DATA_MOV_ABERTO + 5 DAYS) INTO :SISTEMAS-DATA-MOV-ABERTO ,:WS-HOST-DT-HOJE ,:WS-HOST-DT-MAIS5D FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WS_HOST_DT_HOJE, WORK_AREA.WS_HOST_DT_HOJE);
                _.Move(executed_1.WS_HOST_DT_MAIS5D, WORK_AREA.WS_HOST_DT_MAIS5D);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -424- MOVE 'R1000-00-PROCESSA-REGISTRO' TO WNR-EXEC-SQL */
            _.Move("R1000-00-PROCESSA-REGISTRO", ABEND.WS_ABEND.WNR_EXEC_SQL);

            /*" -426- PERFORM R2000-00-MOVIMENTA-DADOS */

            R2000_00_MOVIMENTA_DADOS_SECTION();

            /*" -427- WRITE REG-CIELO FROM DET1 */
            _.Move(DET1.GetMoveValues(), REG_CIELO);

            RETCIELO.Write(REG_CIELO.GetMoveValues().ToString());

            /*" -429- ADD 1 TO WS-AC-SEMRET */
            WORK_AREA.WS_AC_SEMRET.Value = WORK_AREA.WS_AC_SEMRET + 1;

            /*" -429- PERFORM R1010-00-FETCH-PARCELAS. */

            R1010_00_FETCH_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-SECTION */
        private void R1010_00_FETCH_PARCELAS_SECTION()
        {
            /*" -438- MOVE 'R1010-00-FETCH-PARCELAS' TO WNR-EXEC-SQL. */
            _.Move("R1010-00-FETCH-PARCELAS", ABEND.WS_ABEND.WNR_EXEC_SQL);

            /*" -458- PERFORM R1010_00_FETCH_PARCELAS_DB_FETCH_1 */

            R1010_00_FETCH_PARCELAS_DB_FETCH_1();

            /*" -463-  EVALUATE SQLCODE  */

            /*" -464-  WHEN ZEROS  */

            /*" -464- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -466- CONTINUE */

                /*" -467-  WHEN +100  */

                /*" -467- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -469- MOVE 'S' TO WS-FIM-PARCELAS */
                _.Move("S", WORK_AREA.WS_FIM_PARCELAS);

                /*" -471- PERFORM R1010_00_FETCH_PARCELAS_DB_CLOSE_1 */

                R1010_00_FETCH_PARCELAS_DB_CLOSE_1();

                /*" -474- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -476- DISPLAY '1010-ERRO-PROBLEMAS CLOSE CURSOR CPARCELAS' */
                    _.Display($"1010-ERRO-PROBLEMAS CLOSE CURSOR CPARCELAS");

                    /*" -477- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -479- END-IF */
                }


                /*" -480-  WHEN OTHER  */

                /*" -480- ELSE */
            }
            else
            {


                /*" -481- DISPLAY '1010-00-ERRO AO LER CURSOR CPARCELAS' */
                _.Display($"1010-00-ERRO AO LER CURSOR CPARCELAS");

                /*" -482- DISPLAY 'CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -483- DISPLAY 'PARCELA      = ' PROPOVA-NUM-PARCELA */
                _.Display($"PARCELA      = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -485- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -485-  END-EVALUATE.  */

                /*" -485- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-DB-FETCH-1 */
        public void R1010_00_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -458- EXEC SQL FETCH CPARCELAS INTO :HISLANCT-NUM-CERTIFICADO ,:WS-HOST-DES-SITU ,:HISLANCT-NUM-PARCELA ,:PROPOVA-NUM-APOLICE ,:PROPOVA-COD-SUBGRUPO ,:GE407-COD-IDLG ,:PARCEVID-DATA-VENCIMENTO ,:GE408-DTA-CREDITO ,:PROPOVA-DTPROXVEN ,:OPCPAGVI-DIA-DEBITO ,:HISLANCT-PRM-TOTAL ,:PROPOVA-COD-PRODUTO ,:PRODUVG-NOME-PRODUTO ,:CLIENTES-NOME-RAZAO ,:CLIENTES-CGCCPF ,:ENDERECO-DDD ,:ENDERECO-TELEFONE END-EXEC */

            if (CPARCELAS.Fetch())
            {
                _.Move(CPARCELAS.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(CPARCELAS.WS_HOST_DES_SITU, WORK_AREA.WS_HOST_DES_SITU);
                _.Move(CPARCELAS.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(CPARCELAS.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPARCELAS.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPARCELAS.GE407_COD_IDLG, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG);
                _.Move(CPARCELAS.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(CPARCELAS.GE408_DTA_CREDITO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO);
                _.Move(CPARCELAS.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CPARCELAS.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(CPARCELAS.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(CPARCELAS.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CPARCELAS.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(CPARCELAS.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(CPARCELAS.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(CPARCELAS.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(CPARCELAS.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
            }

        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R1010_00_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -471- EXEC SQL CLOSE CPARCELAS END-EXEC */

            CPARCELAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-MOVIMENTA-DADOS-SECTION */
        private void R2000_00_MOVIMENTA_DADOS_SECTION()
        {
            /*" -496- MOVE 'R2000-00-MOVIMENTA-DADOS' TO WNR-EXEC-SQL */
            _.Move("R2000-00-MOVIMENTA-DADOS", ABEND.WS_ABEND.WNR_EXEC_SQL);

            /*" -498- MOVE CLIENTES-NOME-RAZAO TO DET-NOM-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DET1.DET_NOM_SEGURADO);

            /*" -500- MOVE CLIENTES-CGCCPF TO DET-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DET1.DET_CGCCPF);

            /*" -502- MOVE HISLANCT-NUM-CERTIFICADO TO DET-NUM-CERTIFICADO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, DET1.DET_NUM_CERTIFICADO);

            /*" -504- MOVE PROPOVA-NUM-APOLICE TO DET-NUM-APOLICE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, DET1.DET_NUM_APOLICE);

            /*" -506- MOVE PROPOVA-COD-SUBGRUPO TO DET-COD-SUBGRUPO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, DET1.DET_COD_SUBGRUPO);

            /*" -508- MOVE HISLANCT-NUM-PARCELA TO DET-NUM-PARCELA */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, DET1.DET_NUM_PARCELA);

            /*" -510- MOVE WS-HOST-DES-SITU TO DET-DES-SITUACAO */
            _.Move(WORK_AREA.WS_HOST_DES_SITU, DET1.DET_DES_SITUACAO);

            /*" -512- MOVE PROPOVA-COD-PRODUTO TO DET-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, DET1.DET_COD_PRODUTO);

            /*" -514- MOVE PRODUVG-NOME-PRODUTO TO DET-DES-PRODUTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, DET1.DET_DES_PRODUTO);

            /*" -516- MOVE GE407-COD-IDLG TO DET-COD-IDLG */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG, DET1.DET_COD_IDLG);

            /*" -518- MOVE PARCEVID-DATA-VENCIMENTO(1:4) TO DET-DT-VENCIMENTO(7:4) */
            _.MoveAtPosition(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Substring(1, 4), DET1.DET_DT_VENCIMENTO, 7, 4);

            /*" -520- MOVE PARCEVID-DATA-VENCIMENTO(6:2) TO DET-DT-VENCIMENTO(4:2) */
            _.MoveAtPosition(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Substring(6, 2), DET1.DET_DT_VENCIMENTO, 4, 2);

            /*" -522- MOVE PARCEVID-DATA-VENCIMENTO(9:2) TO DET-DT-VENCIMENTO(1:2) */
            _.MoveAtPosition(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Substring(9, 2), DET1.DET_DT_VENCIMENTO, 1, 2);

            /*" -525- MOVE '/' TO DET-DT-VENCIMENTO(6:1) */
            _.MoveAtPosition("/", DET1.DET_DT_VENCIMENTO, 6, 1);

            /*" -525- MOVE '/' TO DET-DT-VENCIMENTO(3:1) */
            _.MoveAtPosition("/", DET1.DET_DT_VENCIMENTO, 3, 1);

            /*" -527- MOVE GE408-DTA-CREDITO(1:4) TO DET-DT-PREV-CRED(7:4) */
            _.MoveAtPosition(GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO.Substring(1, 4), DET1.DET_DT_PREV_CRED, 7, 4);

            /*" -529- MOVE GE408-DTA-CREDITO(6:2) TO DET-DT-PREV-CRED(4:2) */
            _.MoveAtPosition(GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO.Substring(6, 2), DET1.DET_DT_PREV_CRED, 4, 2);

            /*" -530- MOVE GE408-DTA-CREDITO(9:2) TO DET-DT-PREV-CRED(1:2) */
            _.MoveAtPosition(GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO.Substring(9, 2), DET1.DET_DT_PREV_CRED, 1, 2);

            /*" -534- MOVE '/' TO DET-DT-PREV-CRED(6:1) */
            _.MoveAtPosition("/", DET1.DET_DT_PREV_CRED, 6, 1);

            /*" -534- MOVE '/' TO DET-DT-PREV-CRED(3:1) */
            _.MoveAtPosition("/", DET1.DET_DT_PREV_CRED, 3, 1);

            /*" -535- MOVE PROPOVA-DTPROXVEN(1:4) TO DET-DT-PROX-VENC(7:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Substring(1, 4), DET1.DET_DT_PROX_VENC, 7, 4);

            /*" -536- MOVE PROPOVA-DTPROXVEN(6:2) TO DET-DT-PROX-VENC(4:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Substring(6, 2), DET1.DET_DT_PROX_VENC, 4, 2);

            /*" -537- MOVE PROPOVA-DTPROXVEN(9:2) TO DET-DT-PROX-VENC(1:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Substring(9, 2), DET1.DET_DT_PROX_VENC, 1, 2);

            /*" -540- MOVE '/' TO DET-DT-PROX-VENC(6:1) */
            _.MoveAtPosition("/", DET1.DET_DT_PROX_VENC, 6, 1);

            /*" -540- MOVE '/' TO DET-DT-PROX-VENC(3:1) */
            _.MoveAtPosition("/", DET1.DET_DT_PROX_VENC, 3, 1);

            /*" -542- MOVE OPCPAGVI-DIA-DEBITO TO DET-DIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, DET1.DET_DIA_DEBITO);

            /*" -542- MOVE HISLANCT-PRM-TOTAL TO DET-VALOR-COBRANCA. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, DET1.DET_VALOR_COBRANCA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -552- MOVE 'R9999-00-ROT-ERRO' TO WNR-EXEC-SQL */
            _.Move("R9999-00-ROT-ERRO", ABEND.WS_ABEND.WNR_EXEC_SQL);

            /*" -553- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEND.WS_ABEND1.WSQLERRD1);

            /*" -554- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEND.WS_ABEND1.WSQLERRD2);

            /*" -555- DISPLAY WS-ABEND */
            _.Display(ABEND.WS_ABEND);

            /*" -557- DISPLAY WS-ABEND1 */
            _.Display(ABEND.WS_ABEND1);

            /*" -557- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -561- CLOSE RETCIELO */
            RETCIELO.Close();

            /*" -563- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -563- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}