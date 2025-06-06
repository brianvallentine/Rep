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
using Sias.VidaAzul.DB2.VA0972B;

namespace Code
{
    public class VA0972B
    {
        public bool IsCall { get; set; }

        public VA0972B()
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
        /*"      *   PROGRAMADOR ............  DANIEL MEDINA GOMIDE - MILLENIUM   *      */
        /*"      *   DATA CODIFICACAO .......  31/05/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  RELATORIO DE SEGUROS DECLINADOS    *      */
        /*"      *   QUE NAO HOUVERAM A DEVOLUCAO DE PREMIO POIS SE TRATA DA OPCAO*      */
        /*"      *   DE PAGAMENTO CARTAO DE CREDITO E O ESTORNO AUTOMATICO AINDA  *      */
        /*"      *   NAO FOI IMPLEMENTADO. (INSERE CARTA DE DECLINIO "VA0512B") *        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.ZZ                                               *      */
        /*"      *  JAZ......: XXXXX           PROGRAMADOR:                       *      */
        /*"      *  DATA ....: 99/99/9999                                         *      */
        /*"      *  DESCRICAO:                                                    *      */
        /*"      *                                          PROCURE POR V.XX      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *=================================================================      */
        #endregion


        #region VARIABLES

        public FileBasis _DEVCIELO { get; set; } = new FileBasis(new PIC("X", "320", "X(320)"));

        public FileBasis DEVCIELO
        {
            get
            {
                _.Move(REG_CIELO, _DEVCIELO); VarBasis.RedefinePassValue(REG_CIELO, _DEVCIELO, REG_CIELO); return _DEVCIELO;
            }
        }
        /*"01  REG-CIELO                   PIC X(0320).*/
        public StringBasis REG_CIELO { get; set; } = new StringBasis(new PIC("X", "320", "X(0320)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WORK-AREA.*/
        public VA0972B_WORK_AREA WORK_AREA { get; set; } = new VA0972B_WORK_AREA();
        public class VA0972B_WORK_AREA : VarBasis
        {
            /*"    05 WS-AC-LIDOS                  PIC  9(006)     VALUE ZEROS.*/
            public IntBasis WS_AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 WS-AC-GRAVA                  PIC  9(006)     VALUE ZEROS.*/
            public IntBasis WS_AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 WS-AC-DUPLI                  PIC  9(006)     VALUE ZEROS.*/
            public IntBasis WS_AC_DUPLI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 WS-AC-CARTA                  PIC  9(006)     VALUE ZEROS.*/
            public IntBasis WS_AC_CARTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 WS-AC-ESTOR                  PIC  9(006)     VALUE ZEROS.*/
            public IntBasis WS_AC_ESTOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 WS-ACHOU-CTRL-CIELO          PIC  X(001)     VALUE SPACES*/
            public StringBasis WS_ACHOU_CTRL_CIELO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WS-FIM-RELATORIOS            PIC  X(001)     VALUE SPACES*/
            public StringBasis WS_FIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  CAB1.*/
        }
        public VA0972B_CAB1 CAB1 { get; set; } = new VA0972B_CAB1();
        public class VA0972B_CAB1 : VarBasis
        {
            /*"    05  FILLER                      PIC  X(007) VALUE 'VA0972B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VA0972B");
            /*"    05  FILLER                      PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  FILLER                      PIC  X(045) VALUE       'SEGUROS DECLINADOS SEM DEVOLUCAO DE CAPITAL'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SEGUROS DECLINADOS SEM DEVOLUCAO DE CAPITAL");
            /*"    05  FILLER                      PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  FILLER                      PIC  X(012) VALUE        'DT.PROCESS: '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"DT.PROCESS: ");
            /*"    05  CAB1-DATA-ATU               PIC  X(10).*/
            public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05  FILLER                      PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  CAB2.*/
        }
        public VA0972B_CAB2 CAB2 { get; set; } = new VA0972B_CAB2();
        public class VA0972B_CAB2 : VarBasis
        {
            /*"    05 FILLER                       PIC  X(17)       VALUE 'NOME DO CLIENTE'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"NOME DO CLIENTE");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(11)       VALUE 'CPF CLIENTE'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CPF CLIENTE");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(12)       VALUE 'CERTIFICADO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"CERTIFICADO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(07)       VALUE 'PARCELA'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PARCELA");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(15)       VALUE 'VALOR DO PR�MIO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR DO PR�MIO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(15)       VALUE 'DATA VENCIMENTO'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA VENCIMENTO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(10)       VALUE 'IDLG (SAP)'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"IDLG (SAP)");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(07)       VALUE 'AP�LICE'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AP�LICE");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(08)       VALUE 'SUBGRUPO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SUBGRUPO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(18)       VALUE 'SITUA��O DO SEGURO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"SITUA��O DO SEGURO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(11)       VALUE 'COD.PRODUTO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD.PRODUTO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(20)       VALUE 'DESCRI��O DO PRODUTO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"DESCRI��O DO PRODUTO");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(13)       VALUE 'DATA QUITA��O'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA QUITA��O");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(16)       VALUE 'DATA SOLICITA��O'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"DATA SOLICITA��O");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                       PIC  X(08)       VALUE 'TELEFONE'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
            /*"    05 FILLER                       PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  DET1.*/
        }
        public VA0972B_DET1 DET1 { get; set; } = new VA0972B_DET1();
        public class VA0972B_DET1 : VarBasis
        {
            /*"    05 DET-NOME-RAZAO               PIC  X(40).*/
            public StringBasis DET_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-CGCCPF                   PIC  9(11).*/
            public IntBasis DET_CGCCPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-NUM-CERTIFICADO          PIC  9(14).*/
            public IntBasis DET_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-NUM-PARCELA              PIC  9(03).*/
            public IntBasis DET_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-VALOR-PREMIO             PIC  ZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DT-VENCIMENTO            PIC  X(10).*/
            public StringBasis DET_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-COD-IDLG                 PIC  X(40).*/
            public StringBasis DET_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-NUM-APOLICE              PIC  9(12).*/
            public IntBasis DET_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-COD-SUBGRUPO             PIC  9(03).*/
            public IntBasis DET_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DES-SITUACAO             PIC  X(42).*/
            public StringBasis DET_DES_SITUACAO { get; set; } = new StringBasis(new PIC("X", "42", "X(42)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-COD-PRODUTO              PIC  9(04).*/
            public IntBasis DET_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DES-PRODUTO              PIC  X(40).*/
            public StringBasis DET_DES_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DT-QUITACAO              PIC  X(10).*/
            public StringBasis DET_DT_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DT-SOLICITA              PIC  X(10).*/
            public StringBasis DET_DT_SOLICITA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 DET-DDD                      PIC  9(03).*/
            public IntBasis DET_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 FILLER                       PIC  X(01)  VALUE '-'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 DET-TELEFONE                 PIC  Z99999999.*/
            public IntBasis DET_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "Z99999999."));
            /*"    05 FILLER                       PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  ABEND.*/
        }
        public VA0972B_ABEND ABEND { get; set; } = new VA0972B_ABEND();
        public class VA0972B_ABEND : VarBasis
        {
            /*"    03     WABEND.*/
            public VA0972B_WABEND WABEND { get; set; } = new VA0972B_WABEND();
            public class VA0972B_WABEND : VarBasis
            {
                /*"      05   FILLER                   PIC  X(010)    VALUE          ' VA0972B  '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0972B  ");
                /*"      05   FILLER                   PIC  X(028)    VALUE          ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"      05   WNR-EXEC-SQL             PIC  X(040)    VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    03     WABEND1.*/
            }
            public VA0972B_WABEND1 WABEND1 { get; set; } = new VA0972B_WABEND1();
            public class VA0972B_WABEND1 : VarBasis
            {
                /*"      05   FILLER                   PIC  X(011)    VALUE          ' SQLCODE = '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"      05   WS-SQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      05   FILLER                   PIC  X(012)    VALUE          ' SQLERRD1 = '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"      05   WSQLERRD1                PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      05   FILLER                   PIC  X(012)    VALUE          ' SQLERRD2 = '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"      05   WSQLERRD2                PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.GE407 GE407 { get; set; } = new Dclgens.GE407();

        public VA0972B_TRELAT TRELAT { get; set; } = new VA0972B_TRELAT(false);
        string GetQuery_TRELAT()
        {
            var query = @$"SELECT NUM_CERTIFICADO
							,NUM_APOLICE
							,COD_SUBGRUPO
							,NUM_PARCELA
							,MES_REFERENCIA
							,ANO_REFERENCIA
							,DATA_SOLICITACAO
							,SIT_REGISTRO
							FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VA0972B' AND SIT_REGISTRO = '0' ORDER BY NUM_APOLICE
							, COD_SUBGRUPO";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string DEVCIELO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                DEVCIELO.SetFile(DEVCIELO_FILE_NAME_P);
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
            TRELAT.GetQueryEvent += GetQuery_TRELAT;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -230- MOVE '0000-00-PRINCIPAL' TO WNR-EXEC-SQL */
            _.Move("0000-00-PRINCIPAL", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -239- DISPLAY 'VERSAO V.00 : ' FUNCTION WHEN-COMPILED ' - VA0972B-' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VERSAO V.00 : FUNCTION{_.WhenCompiled()} - VA0972B-{_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -241- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -244- OPEN OUTPUT DEVCIELO */
            DEVCIELO.Open(REG_CIELO);

            /*" -246- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -249-  EVALUATE SQLCODE  */

            /*" -250-  WHEN ZEROS  */

            /*" -250- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -251- CONTINUE */

                /*" -252-  WHEN OTHER  */

                /*" -252- ELSE */
            }
            else
            {


                /*" -253- DISPLAY '0000-00-ERRO OPEN CURSOR TRELATORIOS' */
                _.Display($"0000-00-ERRO OPEN CURSOR TRELATORIOS");

                /*" -254- DISPLAY 'CODIGO          = ' RELATORI-COD-RELATORIO */
                _.Display($"CODIGO          = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -255- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -257-  END-EVALUATE.  */

                /*" -257- END-IF. */
            }


            /*" -258- MOVE 'N' TO WS-FIM-RELATORIOS */
            _.Move("N", WORK_AREA.WS_FIM_RELATORIOS);

            /*" -260- PERFORM R1010-00-FETCH-RELATORIOS. */

            R1010_00_FETCH_RELATORIOS_SECTION();

            /*" -261- IF WS-FIM-RELATORIOS EQUAL 'S' */

            if (WORK_AREA.WS_FIM_RELATORIOS == "S")
            {

                /*" -262- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -263- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -264- DISPLAY '*   VA0972B                                *' */
                _.Display($"*   VA0972B                                *");

                /*" -265- DISPLAY '*   -------                                *' */
                _.Display($"*   -------                                *");

                /*" -266- DISPLAY '*   SEGUROS DECLINADOS CARTOES DE CREDITO  *' */
                _.Display($"*   SEGUROS DECLINADOS CARTOES DE CREDITO  *");

                /*" -267- DISPLAY '*   ------- -----------------------------  *' */
                _.Display($"*   ------- -----------------------------  *");

                /*" -268- DISPLAY '*           SEM DEVOLUCAO DE CAPITAL       *' */
                _.Display($"*           SEM DEVOLUCAO DE CAPITAL       *");

                /*" -269- DISPLAY '*           ------------------------------ *' */
                _.Display($"*           ------------------------------ *");

                /*" -270- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -271- DISPLAY '*   *NENHUMA DEVOLUCAO ENCONTRADA NO DIA   *' */
                _.Display($"*   *NENHUMA DEVOLUCAO ENCONTRADA NO DIA   *");

                /*" -272- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -273- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -274- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -277- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -278- WRITE REG-CIELO FROM CAB1 */
            _.Move(CAB1.GetMoveValues(), REG_CIELO);

            DEVCIELO.Write(REG_CIELO.GetMoveValues().ToString());

            /*" -280- WRITE REG-CIELO FROM CAB2 */
            _.Move(CAB2.GetMoveValues(), REG_CIELO);

            DEVCIELO.Write(REG_CIELO.GetMoveValues().ToString());

            /*" -284- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-FIM-RELATORIOS EQUAL 'S' */

            while (!(WORK_AREA.WS_FIM_RELATORIOS == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -286- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -287- DISPLAY '*** VA0972B - ************************************' */
            _.Display($"*** VA0972B - ************************************");

            /*" -288- DISPLAY '*            ' */
            _.Display($"*            ");

            /*" -289- DISPLAY '* LIDOS RELATORIOS...................:' WS-AC-LIDOS */
            _.Display($"* LIDOS RELATORIOS...................:{WORK_AREA.WS_AC_LIDOS}");

            /*" -290- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -291- DISPLAY '* GRAVADOS DEVCIELO..................:' WS-AC-GRAVA */
            _.Display($"* GRAVADOS DEVCIELO..................:{WORK_AREA.WS_AC_GRAVA}");

            /*" -292- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -293- DISPLAY '* CARTAS DECLINIO A EMITIR (VA0512B).:' WS-AC-CARTA */
            _.Display($"* CARTAS DECLINIO A EMITIR (VA0512B).:{WORK_AREA.WS_AC_CARTA}");

            /*" -294- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -295- DISPLAY '* DUPLICADOS AO INSERIR CARTA DECLINI:' WS-AC-DUPLI */
            _.Display($"* DUPLICADOS AO INSERIR CARTA DECLINI:{WORK_AREA.WS_AC_DUPLI}");

            /*" -296- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -297- DISPLAY '* ADESOES CANCELADAS P/ESTORNO MANUAL:' WS-AC-ESTOR */
            _.Display($"* ADESOES CANCELADAS P/ESTORNO MANUAL:{WORK_AREA.WS_AC_ESTOR}");

            /*" -298- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -300- DISPLAY '************** TERMINO NORMAL *********************' */
            _.Display($"************** TERMINO NORMAL *********************");

            /*" -302- CLOSE DEVCIELO. */
            DEVCIELO.Close();

            /*" -302- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -246- EXEC SQL OPEN TRELAT END-EXEC */

            TRELAT.Open();

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -309- MOVE 'R0100-00-SELECT-SISTEMAS' TO WNR-EXEC-SQL. */
            _.Move("R0100-00-SELECT-SISTEMAS", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -315- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -318-  EVALUATE SQLCODE  */

            /*" -319-  WHEN ZEROS  */

            /*" -319- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -320- CONTINUE */

                /*" -321-  WHEN 100  */

                /*" -321- ELSE IF   SQLCODE EQUALS  100 */
            }
            else

            if (DB.SQLCODE == 100)
            {

                /*" -322- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, ABEND.WABEND1.WS_SQLCODE);

                /*" -323- DISPLAY '0100-ERRO-SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"0100-ERRO-SISTEMA NAO ESTA CADASTRADO");

                /*" -324- DISPLAY 'SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                _.Display($"SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -325- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -326-  WHEN OTHER  */

                /*" -326- ELSE */
            }
            else
            {


                /*" -327- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, ABEND.WABEND1.WS_SQLCODE);

                /*" -328- DISPLAY '0100-00-ERRO SELECT SISTEMAS  ' */
                _.Display($"0100-00-ERRO SELECT SISTEMAS  ");

                /*" -329- DISPLAY 'SISTEMA  = ' SISTEMAS-IDE-SISTEMA */
                _.Display($"SISTEMA  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -330- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -332-  END-EVALUATE.  */

                /*" -332- END-IF. */
            }


            /*" -334- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO CAB1-DATA-ATU(1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), CAB1.CAB1_DATA_ATU, 1, 2);

            /*" -336- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO CAB1-DATA-ATU(4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), CAB1.CAB1_DATA_ATU, 4, 2);

            /*" -338- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO CAB1-DATA-ATU(7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), CAB1.CAB1_DATA_ATU, 7, 4);

            /*" -339- MOVE '/' TO CAB1-DATA-ATU(6:1). */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_ATU, 6, 1);

            /*" -339- MOVE '/' TO CAB1-DATA-ATU(3:1) */
            _.MoveAtPosition("/", CAB1.CAB1_DATA_ATU, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -315- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -348- MOVE 'R1000-00-PROCESSA-REGISTRO' TO WNR-EXEC-SQL */
            _.Move("R1000-00-PROCESSA-REGISTRO", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -350- PERFORM R2040-00-BUSCA-DADOS-A-LISTAR */

            R2040_00_BUSCA_DADOS_A_LISTAR_SECTION();

            /*" -352- PERFORM R2000-00-MOVIMENTA-DADOS */

            R2000_00_MOVIMENTA_DADOS_SECTION();

            /*" -353- WRITE REG-CIELO FROM DET1 */
            _.Move(DET1.GetMoveValues(), REG_CIELO);

            DEVCIELO.Write(REG_CIELO.GetMoveValues().ToString());

            /*" -356- ADD 1 TO WS-AC-GRAVA */
            WORK_AREA.WS_AC_GRAVA.Value = WORK_AREA.WS_AC_GRAVA + 1;

            /*" -359- PERFORM R2030-00-UPDATE-RELATORI */

            R2030_00_UPDATE_RELATORI_SECTION();

            /*" -361- IF RELATORI-NUM-PARCELA EQUAL 1 AND PROPOVA-SIT-REGISTRO EQUAL '2' */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
            {

                /*" -362- PERFORM R2035-00-INSERT-RELATORIOS */

                R2035_00_INSERT_RELATORIOS_SECTION();

                /*" -363- PERFORM R7000-00-CANCELA-ADESAO */

                R7000_00_CANCELA_ADESAO_SECTION();

                /*" -365- END-IF */
            }


            /*" -365- PERFORM R1010-00-FETCH-RELATORIOS. */

            R1010_00_FETCH_RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-FETCH-RELATORIOS-SECTION */
        private void R1010_00_FETCH_RELATORIOS_SECTION()
        {
            /*" -374- MOVE 'R1010-00-FETCH-RELATORIOS' TO WNR-EXEC-SQL. */
            _.Move("R1010-00-FETCH-RELATORIOS", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -383- PERFORM R1010_00_FETCH_RELATORIOS_DB_FETCH_1 */

            R1010_00_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -388-  EVALUATE SQLCODE  */

            /*" -389-  WHEN ZEROS  */

            /*" -389- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -391- ADD 1 TO WS-AC-LIDOS */
                WORK_AREA.WS_AC_LIDOS.Value = WORK_AREA.WS_AC_LIDOS + 1;

                /*" -392-  WHEN +100  */

                /*" -392- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -395- MOVE 'S' TO WS-FIM-RELATORIOS */
                _.Move("S", WORK_AREA.WS_FIM_RELATORIOS);

                /*" -397- PERFORM R1010_00_FETCH_RELATORIOS_DB_CLOSE_1 */

                R1010_00_FETCH_RELATORIOS_DB_CLOSE_1();

                /*" -400- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -402- DISPLAY '1010-ERRO-PROBLEMAS CLOSE CURSOR TRELATORIOS' */
                    _.Display($"1010-ERRO-PROBLEMAS CLOSE CURSOR TRELATORIOS");

                    /*" -403- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -405- END-IF */
                }


                /*" -407-  WHEN OTHER  */

                /*" -407- ELSE */
            }
            else
            {


                /*" -408- DISPLAY '1010-00-ERRO AO LER CURSOR TRELATORIOS' */
                _.Display($"1010-00-ERRO AO LER CURSOR TRELATORIOS");

                /*" -409- DISPLAY 'CODIGO  = ' RELATORI-COD-RELATORIO */
                _.Display($"CODIGO  = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -411- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -411-  END-EVALUATE.  */

                /*" -411- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-FETCH-RELATORIOS-DB-FETCH-1 */
        public void R1010_00_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -383- EXEC SQL FETCH TRELAT INTO :RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-APOLICE ,:RELATORI-COD-SUBGRUPO ,:RELATORI-NUM-PARCELA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-SIT-REGISTRO END-EXEC. */

            if (TRELAT.Fetch())
            {
                _.Move(TRELAT.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(TRELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(TRELAT.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(TRELAT.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(TRELAT.RELATORI_MES_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);
                _.Move(TRELAT.RELATORI_ANO_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);
                _.Move(TRELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(TRELAT.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R1010-00-FETCH-RELATORIOS-DB-CLOSE-1 */
        public void R1010_00_FETCH_RELATORIOS_DB_CLOSE_1()
        {
            /*" -397- EXEC SQL CLOSE TRELAT END-EXEC */

            TRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-MOVIMENTA-DADOS-SECTION */
        private void R2000_00_MOVIMENTA_DADOS_SECTION()
        {
            /*" -421- MOVE 'R2000-00-MOVIMENTA-DADOS' TO WNR-EXEC-SQL */
            _.Move("R2000-00-MOVIMENTA-DADOS", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -423- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DET1.DET_NOME_RAZAO);

            /*" -425- MOVE CLIENTES-CGCCPF TO DET-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DET1.DET_CGCCPF);

            /*" -427- MOVE PROPOVA-NUM-CERTIFICADO TO DET-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, DET1.DET_NUM_CERTIFICADO);

            /*" -429- MOVE PROPOVA-NUM-PARCELA TO DET-NUM-PARCELA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, DET1.DET_NUM_PARCELA);

            /*" -431- MOVE COBHISVI-PRM-TOTAL TO DET-VALOR-PREMIO */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, DET1.DET_VALOR_PREMIO);

            /*" -433- MOVE PARCEVID-DATA-VENCIMENTO(1:4) TO DET-DT-VENCIMENTO(7:4) */
            _.MoveAtPosition(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Substring(1, 4), DET1.DET_DT_VENCIMENTO, 7, 4);

            /*" -435- MOVE PARCEVID-DATA-VENCIMENTO(6:2) TO DET-DT-VENCIMENTO(4:2) */
            _.MoveAtPosition(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Substring(6, 2), DET1.DET_DT_VENCIMENTO, 4, 2);

            /*" -437- MOVE PARCEVID-DATA-VENCIMENTO(9:2) TO DET-DT-VENCIMENTO(1:2) */
            _.MoveAtPosition(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Substring(9, 2), DET1.DET_DT_VENCIMENTO, 1, 2);

            /*" -440- MOVE '/' TO DET-DT-VENCIMENTO(6:1) */
            _.MoveAtPosition("/", DET1.DET_DT_VENCIMENTO, 6, 1);

            /*" -440- MOVE '/' TO DET-DT-VENCIMENTO(3:1) */
            _.MoveAtPosition("/", DET1.DET_DT_VENCIMENTO, 3, 1);

            /*" -442- MOVE GE407-COD-IDLG TO DET-COD-IDLG */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG, DET1.DET_COD_IDLG);

            /*" -444- MOVE RELATORI-NUM-APOLICE TO DET-NUM-APOLICE */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, DET1.DET_NUM_APOLICE);

            /*" -446- MOVE RELATORI-COD-SUBGRUPO TO DET-COD-SUBGRUPO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, DET1.DET_COD_SUBGRUPO);

            /*" -447- EVALUATE PROPOVA-SIT-REGISTRO */
            switch (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.Value.Trim())
            {

                /*" -448- WHEN '0' */
                case "0":

                    /*" -449- MOVE 'A INTEGRAR          ' TO DET-DES-SITUACAO */
                    _.Move("A INTEGRAR          ", DET1.DET_DES_SITUACAO);

                    /*" -450- WHEN '1' */
                    break;
                case "1":

                    /*" -451- MOVE 'EM CRITICA          ' TO DET-DES-SITUACAO */
                    _.Move("EM CRITICA          ", DET1.DET_DES_SITUACAO);

                    /*" -452- WHEN '2' */
                    break;
                case "2":

                    /*" -453- MOVE 'NAO ACEITA          ' TO DET-DES-SITUACAO */
                    _.Move("NAO ACEITA          ", DET1.DET_DES_SITUACAO);

                    /*" -454- WHEN '3' */
                    break;
                case "3":

                    /*" -455- MOVE 'INTEGRADA' TO DET-DES-SITUACAO */
                    _.Move("INTEGRADA", DET1.DET_DES_SITUACAO);

                    /*" -456- WHEN '4' */
                    break;
                case "4":

                    /*" -458- MOVE 'CANCELADA APOS ACEITACAO' TO DET-DES-SITUACAO */
                    _.Move("CANCELADA APOS ACEITACAO", DET1.DET_DES_SITUACAO);

                    /*" -459- WHEN '5' */
                    break;
                case "5":

                    /*" -460- MOVE 'SEM RCAP            ' TO DET-DES-SITUACAO */
                    _.Move("SEM RCAP            ", DET1.DET_DES_SITUACAO);

                    /*" -461- WHEN '6' */
                    break;
                case "6":

                    /*" -462- MOVE 'COBERTURA SUSPENSA' TO DET-DES-SITUACAO */
                    _.Move("COBERTURA SUSPENSA", DET1.DET_DES_SITUACAO);

                    /*" -463- WHEN '7' */
                    break;
                case "7":

                    /*" -465- MOVE 'ACEITA-AGUARDANDO EMISSAO 1A PARCELA' TO DET-DES-SITUACAO */
                    _.Move("ACEITA-AGUARDANDO EMISSAO 1A PARCELA", DET1.DET_DES_SITUACAO);

                    /*" -466- WHEN '8' */
                    break;
                case "8":

                    /*" -468- MOVE 'ACEITA-AGUARDANDO PAGAMENTO PROPOSTA' TO DET-DES-SITUACAO */
                    _.Move("ACEITA-AGUARDANDO PAGAMENTO PROPOSTA", DET1.DET_DES_SITUACAO);

                    /*" -469- WHEN '9' */
                    break;
                case "9":

                    /*" -471- MOVE 'AGUARDANDO PROPOSTAS FISICA  ' TO DET-DES-SITUACAO */
                    _.Move("AGUARDANDO PROPOSTAS FISICA  ", DET1.DET_DES_SITUACAO);

                    /*" -472- WHEN 'A' */
                    break;
                case "A":

                    /*" -473- MOVE 'A INTEGRAR          ' TO DET-DES-SITUACAO */
                    _.Move("A INTEGRAR          ", DET1.DET_DES_SITUACAO);

                    /*" -474- WHEN 'B' */
                    break;
                case "B":

                    /*" -476- MOVE 'INTEGRADA-PROPOSTA NOVA ' TO DET-DES-SITUACAO */
                    _.Move("INTEGRADA-PROPOSTA NOVA ", DET1.DET_DES_SITUACAO);

                    /*" -477- WHEN 'C' */
                    break;
                case "C":

                    /*" -478- MOVE 'INTEGRADA MIGRADA ' TO DET-DES-SITUACAO */
                    _.Move("INTEGRADA MIGRADA ", DET1.DET_DES_SITUACAO);

                    /*" -479- WHEN 'D' */
                    break;
                case "D":

                    /*" -480- MOVE 'UTILIZADO PELO SAUDE' TO DET-DES-SITUACAO */
                    _.Move("UTILIZADO PELO SAUDE", DET1.DET_DES_SITUACAO);

                    /*" -481- WHEN 'E' */
                    break;
                case "E":

                    /*" -482- MOVE 'AGUARDANDO CRIVO' TO DET-DES-SITUACAO */
                    _.Move("AGUARDANDO CRIVO", DET1.DET_DES_SITUACAO);

                    /*" -483- WHEN 'T' */
                    break;
                case "T":

                    /*" -485- MOVE 'PROPOSTA-ERRO NAO PERMITE INTEGRACAO' TO DET-DES-SITUACAO */
                    _.Move("PROPOSTA-ERRO NAO PERMITE INTEGRACAO", DET1.DET_DES_SITUACAO);

                    /*" -486- WHEN '*' */
                    break;
                case "*":

                    /*" -487- MOVE 'PROPOSTA REJEITADA  ' TO DET-DES-SITUACAO */
                    _.Move("PROPOSTA REJEITADA  ", DET1.DET_DES_SITUACAO);

                    /*" -489- END-EVALUATE */
                    break;
            }


            /*" -491- MOVE PROPOVA-COD-PRODUTO TO DET-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, DET1.DET_COD_PRODUTO);

            /*" -493- MOVE PRODUVG-NOME-PRODUTO TO DET-DES-PRODUTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, DET1.DET_DES_PRODUTO);

            /*" -494- MOVE PROPOVA-DATA-QUITACAO(1:4) TO DET-DT-QUITACAO(7:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(1, 4), DET1.DET_DT_QUITACAO, 7, 4);

            /*" -495- MOVE PROPOVA-DATA-QUITACAO(6:2) TO DET-DT-QUITACAO(4:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(6, 2), DET1.DET_DT_QUITACAO, 4, 2);

            /*" -496- MOVE PROPOVA-DATA-QUITACAO(9:2) TO DET-DT-QUITACAO(1:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(9, 2), DET1.DET_DT_QUITACAO, 1, 2);

            /*" -499- MOVE '/' TO DET-DT-QUITACAO(6:1) */
            _.MoveAtPosition("/", DET1.DET_DT_QUITACAO, 6, 1);

            /*" -499- MOVE '/' TO DET-DT-QUITACAO(3:1) */
            _.MoveAtPosition("/", DET1.DET_DT_QUITACAO, 3, 1);

            /*" -501- MOVE RELATORI-DATA-SOLICITACAO(1:4) TO DET-DT-SOLICITA(7:4) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(1, 4), DET1.DET_DT_SOLICITA, 7, 4);

            /*" -503- MOVE RELATORI-DATA-SOLICITACAO(6:2) TO DET-DT-SOLICITA(4:2) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(6, 2), DET1.DET_DT_SOLICITA, 4, 2);

            /*" -505- MOVE RELATORI-DATA-SOLICITACAO(9:2) TO DET-DT-SOLICITA(1:2) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(9, 2), DET1.DET_DT_SOLICITA, 1, 2);

            /*" -508- MOVE '/' TO DET-DT-SOLICITA(6:1) */
            _.MoveAtPosition("/", DET1.DET_DT_SOLICITA, 6, 1);

            /*" -508- MOVE '/' TO DET-DT-SOLICITA(3:1) */
            _.MoveAtPosition("/", DET1.DET_DT_SOLICITA, 3, 1);

            /*" -510- MOVE ENDERECO-DDD TO DET-DDD */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, DET1.DET_DDD);

            /*" -510- MOVE ENDERECO-TELEFONE TO DET-TELEFONE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, DET1.DET_TELEFONE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-UPDATE-RELATORI-SECTION */
        private void R2030_00_UPDATE_RELATORI_SECTION()
        {
            /*" -519- MOVE 'R2030-00-UPDATE-RELATORI' TO WNR-EXEC-SQL. */
            _.Move("R2030-00-UPDATE-RELATORI", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -520- MOVE PROPOVA-NUM-CERTIFICADO TO RELATORI-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -521- MOVE PROPOVA-NUM-PARCELA TO RELATORI-NUM-PARCELA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);

            /*" -523- MOVE 'VA0972B' TO RELATORI-COD-RELATORIO */
            _.Move("VA0972B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -530- PERFORM R2030_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2030_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -534- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -535- WHEN 0 */
                case 0:

                    /*" -537- CONTINUE */

                    /*" -538- WHEN 100 */
                    break;
                case 100:

                    /*" -540- DISPLAY '2030-ERRO-REGISTRO NAO ATUALIZADO TABELA RELATORIOS' */
                    _.Display($"2030-ERRO-REGISTRO NAO ATUALIZADO TABELA RELATORIOS");

                    /*" -541- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -542- DISPLAY 'NUM_PARCELA     = ' RELATORI-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                    /*" -543- DISPLAY 'SITUACAO        = ' RELATORI-SIT-REGISTRO */
                    _.Display($"SITUACAO        = {RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO}");

                    /*" -546- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -547- WHEN OTHER */
                    break;
                default:

                    /*" -548- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEND.WABEND1.WS_SQLCODE);

                    /*" -549- DISPLAY '2030-ERRO-UPDATE RELATORIOS  ' */
                    _.Display($"2030-ERRO-UPDATE RELATORIOS  ");

                    /*" -550- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -551- DISPLAY 'NUM_PARCELA     = ' RELATORI-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                    /*" -552- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -552- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R2030-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2030_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -530- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND SIT_REGISTRO = :RELATORI-SIT-REGISTRO END-EXEC */

            var r2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/

        [StopWatch]
        /*" R2035-00-INSERT-RELATORIOS-SECTION */
        private void R2035_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -564- MOVE 'R2035-00-INSERT-RELATORIOS' TO WNR-EXEC-SQL. */
            _.Move("R2035-00-INSERT-RELATORIOS", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -607- PERFORM R2035_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R2035_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -611- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -612- WHEN 0 */
                case 0:

                    /*" -614- ADD 1 TO WS-AC-CARTA */
                    WORK_AREA.WS_AC_CARTA.Value = WORK_AREA.WS_AC_CARTA + 1;

                    /*" -615- WHEN -813 */
                    break;
                case -813:

                    /*" -616- ADD 1 TO WS-AC-DUPLI */
                    WORK_AREA.WS_AC_DUPLI.Value = WORK_AREA.WS_AC_DUPLI + 1;

                    /*" -618- DISPLAY '2030-ERRO-REGISTRO DUPLICADO TABELA RELATORIOS ' */
                    _.Display($"2030-ERRO-REGISTRO DUPLICADO TABELA RELATORIOS ");

                    /*" -619- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -620- DISPLAY 'NUM_PARCELA     = ' RELATORI-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                    /*" -621- DISPLAY 'SITUACAO        = ' RELATORI-SIT-REGISTRO */
                    _.Display($"SITUACAO        = {RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO}");

                    /*" -624- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -625- WHEN OTHER */
                    break;
                default:

                    /*" -626- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEND.WABEND1.WS_SQLCODE);

                    /*" -627- DISPLAY '2030-ERRO-ERROINSERT TABELA RELATORIOS' */
                    _.Display($"2030-ERRO-ERROINSERT TABELA RELATORIOS");

                    /*" -628- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -629- DISPLAY 'NUM_PARCELA     = ' RELATORI-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                    /*" -630- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -630- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R2035-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R2035_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -607- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0972B' , :SISTEMAS-DATA-MOV-ABERTO , 'VA' , 'VA0512B' , 0, 0, :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , 0, 0, 0, 0, 0, 0, 0, 0, :RELATORI-NUM-APOLICE, 0, :RELATORI-NUM-PARCELA, :RELATORI-NUM-CERTIFICADO, 0, :RELATORI-COD-SUBGRUPO , 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
            };

            R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2035_99_SAIDA*/

        [StopWatch]
        /*" R2040-00-BUSCA-DADOS-A-LISTAR-SECTION */
        private void R2040_00_BUSCA_DADOS_A_LISTAR_SECTION()
        {
            /*" -639- MOVE 'R2040-00-BUSCA-DADOS-A-LISTAR' TO WNR-EXEC-SQL */
            _.Move("R2040-00-BUSCA-DADOS-A-LISTAR", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -640- MOVE RELATORI-NUM-CERTIFICADO TO PROPOVA-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -642- MOVE RELATORI-NUM-PARCELA TO PROPOVA-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);

            /*" -694- PERFORM R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1 */

            R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1();

            /*" -697- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -698- WHEN 0 */
                case 0:

                    /*" -699- CONTINUE */

                    /*" -700- WHEN 100 */
                    break;
                case 100:

                    /*" -702- DISPLAY '2040-ERRO-REGISTRO NAO ENCONTRAO JOIN PROPOSTAS_VA' */
                    _.Display($"2040-ERRO-REGISTRO NAO ENCONTRAO JOIN PROPOSTAS_VA");

                    /*" -703- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -704- DISPLAY 'NUM_PARCELA     = ' PROPOVA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                    /*" -705- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -706- WHEN  -811 */
                    break;
                case -811:

                    /*" -707- DISPLAY '2040-ERRO-DUPLIICIDADE  JOIN PROPOSTAS_VA' */
                    _.Display($"2040-ERRO-DUPLIICIDADE  JOIN PROPOSTAS_VA");

                    /*" -708- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -709- DISPLAY 'NUM_PARCELA     = ' PROPOVA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                    /*" -710- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -711- WHEN OTHER */
                    break;
                default:

                    /*" -712- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, ABEND.WABEND1.WS_SQLCODE);

                    /*" -713- DISPLAY '2040-ERRO-SELECT PROPOSTAS_VA' */
                    _.Display($"2040-ERRO-SELECT PROPOSTAS_VA");

                    /*" -714- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -715- DISPLAY 'NUM_PARCELA     = ' PROPOVA-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                    /*" -716- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -716- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R2040-00-BUSCA-DADOS-A-LISTAR-DB-SELECT-1 */
        public void R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1()
        {
            /*" -694- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.SIT_REGISTRO , A.DATA_QUITACAO , A.COD_PRODUTO , B.DATA_VENCIMENTO , C.NOME_RAZAO , C.CGCCPF , C.COD_CLIENTE , D.DDD , D.TELEFONE , E.NOME_PRODUTO , F.PRM_TOTAL , VALUE(G.COD_IDLG, ' ' ) INTO :PROPOVA-NUM-CERTIFICADO , :PROPOVA-NUM-PARCELA , :PROPOVA-SIT-REGISTRO , :PROPOVA-DATA-QUITACAO , :PROPOVA-COD-PRODUTO , :PARCEVID-DATA-VENCIMENTO , :CLIENTES-NOME-RAZAO , :CLIENTES-CGCCPF , :CLIENTES-COD-CLIENTE , :ENDERECO-DDD , :ENDERECO-TELEFONE , :PRODUVG-NOME-PRODUTO , :COBHISVI-PRM-TOTAL , :GE407-COD-IDLG FROM SEGUROS.PROPOSTAS_VA A JOIN SEGUROS.PARCELAS_VIDAZUL B ON A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_PARCELA = B.NUM_PARCELA JOIN SEGUROS.CLIENTES C ON A.COD_CLIENTE = C.COD_CLIENTE JOIN SEGUROS.ENDERECOS D ON C.COD_CLIENTE = D.COD_CLIENTE AND A.OCOREND = D.OCORR_ENDERECO JOIN SEGUROS.PRODUTOS_VG E ON A.NUM_APOLICE = E.NUM_APOLICE AND A.COD_SUBGRUPO = E.COD_SUBGRUPO JOIN SEGUROS.COBER_HIST_VIDAZUL F ON A.NUM_CERTIFICADO = F.NUM_CERTIFICADO AND A.NUM_PARCELA = F.NUM_PARCELA LEFT JOIN SEGUROS.GE_CONTROLE_CARTAO_CIELO G ON A.NUM_CERTIFICADO = G.NUM_CERTIFICADO AND A.NUM_PARCELA = G.NUM_PARCELA WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.NUM_PARCELA = :PROPOVA-NUM-PARCELA WITH UR END-EXEC */

            var r2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1 = new R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1.Execute(r2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(executed_1.COBHISVI_PRM_TOTAL, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL);
                _.Move(executed_1.GE407_COD_IDLG, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-CANCELA-ADESAO-SECTION */
        private void R7000_00_CANCELA_ADESAO_SECTION()
        {
            /*" -727- MOVE 'R7000-00-CANCELA-ADESAO' TO WNR-EXEC-SQL */
            _.Move("R7000-00-CANCELA-ADESAO", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -728- MOVE RELATORI-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -729- MOVE RELATORI-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -732- MOVE '2' TO HISLANCT-SIT-REGISTRO */
            _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -734- PERFORM R7020-00-ATUALIZA-HISLANCT */

            R7020_00_ATUALIZA_HISLANCT_SECTION();

            /*" -735- MOVE HISLANCT-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -736- MOVE HISLANCT-NUM-PARCELA TO COBHISVI-NUM-PARCELA */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -739- MOVE '7' TO COBHISVI-SIT-REGISTRO */
            _.Move("7", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

            /*" -741- PERFORM R7030-00-ATUALIZA-COBHISVI */

            R7030_00_ATUALIZA_COBHISVI_SECTION();

            /*" -742- MOVE HISLANCT-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

            /*" -743- MOVE HISLANCT-NUM-PARCELA TO PARCEVID-NUM-PARCELA */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -746- MOVE '2' TO PARCEVID-SIT-REGISTRO */
            _.Move("2", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

            /*" -749- PERFORM R7040-00-ATUALIZA-PARCEVID */

            R7040_00_ATUALIZA_PARCEVID_SECTION();

            /*" -751- PERFORM R7050-00-RECUPERA-CONTROLE */

            R7050_00_RECUPERA_CONTROLE_SECTION();

            /*" -752- IF WS-ACHOU-CTRL-CIELO EQUAL 'S' */

            if (WORK_AREA.WS_ACHOU_CTRL_CIELO == "S")
            {

                /*" -755- MOVE 'J' TO GE407-STA-REGISTRO */
                _.Move("J", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                /*" -756- PERFORM R7060-00-ATUALIZA-CONTROLE */

                R7060_00_ATUALIZA_CONTROLE_SECTION();

                /*" -758- END-IF */
            }


            /*" -758- ADD 1 TO WS-AC-ESTOR. */
            WORK_AREA.WS_AC_ESTOR.Value = WORK_AREA.WS_AC_ESTOR + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7020-00-ATUALIZA-HISLANCT-SECTION */
        private void R7020_00_ATUALIZA_HISLANCT_SECTION()
        {
            /*" -769- MOVE 'R7020-00-ATUALIZA-HISLANCT' TO WNR-EXEC-SQL */
            _.Move("R7020-00-ATUALIZA-HISLANCT", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -780- PERFORM R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1 */

            R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1();

            /*" -783-  EVALUATE SQLCODE  */

            /*" -784-  WHEN ZEROS  */

            /*" -784- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -785- CONTINUE */

                /*" -786-  WHEN OTHER  */

                /*" -786- ELSE */
            }
            else
            {


                /*" -787- DISPLAY 'R07020 - PROBLEMAS UPDATE HIST_LANC_CTA' */
                _.Display($"R07020 - PROBLEMAS UPDATE HIST_LANC_CTA");

                /*" -788- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -789- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -790- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -792-  END-EVALUATE  */

                /*" -792- END-IF */
            }


            /*" -792- . */

        }

        [StopWatch]
        /*" R7020-00-ATUALIZA-HISLANCT-DB-UPDATE-1 */
        public void R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1()
        {
            /*" -780- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = :HISLANCT-SIT-REGISTRO , OCORR_HISTORICO = OCORR_HISTORICO + 1 , TIMESTAMP = CURRENT TIMESTAMP , COD_USUARIO = 'VA0972B' WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND OCORR_HISTORICOCTA >= 0 AND NSAC IS NULL AND SIT_REGISTRO = '3' END-EXEC */

            var r7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1 = new R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1()
            {
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1.Execute(r7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_99_SAIDA*/

        [StopWatch]
        /*" R7030-00-ATUALIZA-COBHISVI-SECTION */
        private void R7030_00_ATUALIZA_COBHISVI_SECTION()
        {
            /*" -803- MOVE 'R7030-00-ATUALIZA-COBHISVI' TO WNR-EXEC-SQL */
            _.Move("R7030-00-ATUALIZA-COBHISVI", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -809- PERFORM R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1 */

            R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1();

            /*" -812-  EVALUATE SQLCODE  */

            /*" -813-  WHEN ZEROS  */

            /*" -813- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -814- CONTINUE */

                /*" -815-  WHEN OTHER  */

                /*" -815- ELSE */
            }
            else
            {


                /*" -816- DISPLAY 'R07030 - PROBLEMAS UPDATE COBER_HIST_VIDAZUL' */
                _.Display($"R07030 - PROBLEMAS UPDATE COBER_HIST_VIDAZUL");

                /*" -817- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -818- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -819- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -821-  END-EVALUATE  */

                /*" -821- END-IF */
            }


            /*" -821- . */

        }

        [StopWatch]
        /*" R7030-00-ATUALIZA-COBHISVI-DB-UPDATE-1 */
        public void R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1()
        {
            /*" -809- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = :COBHISVI-SIT-REGISTRO , OCORR_HISTORICO = OCORR_HISTORICO + 1 WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA END-EXEC */

            var r7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1 = new R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1()
            {
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1.Execute(r7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7030_99_SAIDA*/

        [StopWatch]
        /*" R7040-00-ATUALIZA-PARCEVID-SECTION */
        private void R7040_00_ATUALIZA_PARCEVID_SECTION()
        {
            /*" -832- MOVE 'R7040-00-ATUALIZA-PARCEVID' TO WNR-EXEC-SQL */
            _.Move("R7040-00-ATUALIZA-PARCEVID", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -838- PERFORM R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1 */

            R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1();

            /*" -841-  EVALUATE SQLCODE  */

            /*" -842-  WHEN ZEROS  */

            /*" -842- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -843- CONTINUE */

                /*" -844-  WHEN OTHER  */

                /*" -844- ELSE */
            }
            else
            {


                /*" -845- DISPLAY 'R07040 - PROBLEMAS UPDATE PARCELAS_VIDAZUL' */
                _.Display($"R07040 - PROBLEMAS UPDATE PARCELAS_VIDAZUL");

                /*" -846- DISPLAY 'NUM-CERTIFICADO = ' PARCEVID-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO}");

                /*" -847- DISPLAY 'NUM-PARCELA     = ' PARCEVID-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -848- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -850-  END-EVALUATE  */

                /*" -850- END-IF */
            }


            /*" -850- . */

        }

        [StopWatch]
        /*" R7040-00-ATUALIZA-PARCEVID-DB-UPDATE-1 */
        public void R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1()
        {
            /*" -838- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = :PARCEVID-SIT-REGISTRO , OCORR_HISTORICO = OCORR_HISTORICO + 1 WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA END-EXEC */

            var r7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1 = new R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1()
            {
                PARCEVID_SIT_REGISTRO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO.ToString(),
                PARCEVID_NUM_CERTIFICADO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1.Execute(r7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7040_99_SAIDA*/

        [StopWatch]
        /*" R7050-00-RECUPERA-CONTROLE-SECTION */
        private void R7050_00_RECUPERA_CONTROLE_SECTION()
        {
            /*" -861- MOVE 'R7050-00-RECUPERA-CONTROLE' TO WNR-EXEC-SQL */
            _.Move("R7050-00-RECUPERA-CONTROLE", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -863- INITIALIZE DCLGE-CONTROLE-CARTAO-CIELO */
            _.Initialize(
                GE407.DCLGE_CONTROLE_CARTAO_CIELO
            );

            /*" -864- MOVE HISLANCT-NUM-CERTIFICADO TO GE407-NUM-CERTIFICADO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO);

            /*" -866- MOVE HISLANCT-NUM-PARCELA TO GE407-NUM-PARCELA */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA);

            /*" -876- PERFORM R7050_00_RECUPERA_CONTROLE_DB_SELECT_1 */

            R7050_00_RECUPERA_CONTROLE_DB_SELECT_1();

            /*" -879-  EVALUATE SQLCODE  */

            /*" -880-  WHEN ZEROS  */

            /*" -880- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -881- MOVE 'S' TO WS-ACHOU-CTRL-CIELO */
                _.Move("S", WORK_AREA.WS_ACHOU_CTRL_CIELO);

                /*" -882-  WHEN +100  */

                /*" -882- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -883- MOVE 'N' TO WS-ACHOU-CTRL-CIELO */
                _.Move("N", WORK_AREA.WS_ACHOU_CTRL_CIELO);

                /*" -885- MOVE ZEROS TO GE407-NUM-OCORR-MOVTO GE407-SEQ-CONTROL-CARTAO */
                _.Move(0, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO);

                /*" -886-  WHEN -811  */

                /*" -886- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -887- DISPLAY 'R7050-00-MAIS DE UM REGISTRO PENDENTE DE RETORNO' */
                _.Display($"R7050-00-MAIS DE UM REGISTRO PENDENTE DE RETORNO");

                /*" -888- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -889- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -890- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -891-  WHEN OTHER  */

                /*" -891- ELSE */
            }
            else
            {


                /*" -892- DISPLAY 'R7050-00-ERRO SELECT GE_CONTROLE_CARTAO_CIELO' */
                _.Display($"R7050-00-ERRO SELECT GE_CONTROLE_CARTAO_CIELO");

                /*" -893- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -894- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -895- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -895-  END-EVALUATE.  */

                /*" -895- END-IF. */
            }


        }

        [StopWatch]
        /*" R7050-00-RECUPERA-CONTROLE-DB-SELECT-1 */
        public void R7050_00_RECUPERA_CONTROLE_DB_SELECT_1()
        {
            /*" -876- EXEC SQL SELECT NUM_OCORR_MOVTO , SEQ_CONTROL_CARTAO INTO :GE407-NUM-OCORR-MOVTO , :GE407-SEQ-CONTROL-CARTAO FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO WHERE NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO AND NUM_PARCELA = :GE407-NUM-PARCELA AND STA_REGISTRO IN ( 'H' , 'A' ) WITH UR END-EXEC */

            var r7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1 = new R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1()
            {
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_NUM_PARCELA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.ToString(),
            };

            var executed_1 = R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1.Execute(r7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE407_NUM_OCORR_MOVTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE407_SEQ_CONTROL_CARTAO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7050_99_SAIDA*/

        [StopWatch]
        /*" R7060-00-ATUALIZA-CONTROLE-SECTION */
        private void R7060_00_ATUALIZA_CONTROLE_SECTION()
        {
            /*" -907- MOVE 'R7060-00-ATUALIZA-CONTROLE' TO WNR-EXEC-SQL */
            _.Move("R7060-00-ATUALIZA-CONTROLE", ABEND.WABEND.WNR_EXEC_SQL);

            /*" -909- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE407-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO);

            /*" -918- PERFORM R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1 */

            R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1();

            /*" -921-  EVALUATE SQLCODE  */

            /*" -922-  WHEN ZEROS  */

            /*" -922- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -923- CONTINUE */

                /*" -924-  WHEN OTHER  */

                /*" -924- ELSE */
            }
            else
            {


                /*" -925- DISPLAY 'R7000-ERRO INSERT GE_CONTROLE_CARTAO_CIELO' */
                _.Display($"R7000-ERRO INSERT GE_CONTROLE_CARTAO_CIELO");

                /*" -926- DISPLAY 'NUM-CERTIFICADO    = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -927- DISPLAY 'NUM-PARCELA        = ' GE407-NUM-PARCELA */
                _.Display($"NUM-PARCELA        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -928- DISPLAY 'SEQ-CONTROL-CARTAO = ' GE407-SEQ-CONTROL-CARTAO */
                _.Display($"SEQ-CONTROL-CARTAO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO}");

                /*" -929- DISPLAY 'NUM-OCORR-MOVTO    = ' GE407-NUM-OCORR-MOVTO */
                _.Display($"NUM-OCORR-MOVTO    = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO}");

                /*" -930- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -932-  END-EVALUATE.  */

                /*" -932- END-IF. */
            }


            /*" -932- . */

        }

        [StopWatch]
        /*" R7060-00-ATUALIZA-CONTROLE-DB-UPDATE-1 */
        public void R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1()
        {
            /*" -918- EXEC SQL UPDATE SEGUROS.GE_CONTROLE_CARTAO_CIELO SET STA_REGISTRO = :GE407-STA-REGISTRO , DTA_MOVIMENTO = :GE407-DTA-MOVIMENTO , DTH_PROCESSAMENTO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO AND NUM_PARCELA = :GE407-NUM-PARCELA AND SEQ_CONTROL_CARTAO = :GE407-SEQ-CONTROL-CARTAO AND NUM_OCORR_MOVTO = :GE407-NUM-OCORR-MOVTO END-EXEC */

            var r7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1 = new R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1()
            {
                GE407_DTA_MOVIMENTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO.ToString(),
                GE407_STA_REGISTRO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO.ToString(),
                GE407_SEQ_CONTROL_CARTAO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO.ToString(),
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_NUM_OCORR_MOVTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO.ToString(),
                GE407_NUM_PARCELA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.ToString(),
            };

            R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1.Execute(r7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7060_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -940- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -941- DISPLAY '* VA0972B    ' */
            _.Display($"* VA0972B    ");

            /*" -942- DISPLAY '* -------    ' */
            _.Display($"* -------    ");

            /*" -943- DISPLAY '*            ' */
            _.Display($"*            ");

            /*" -944- DISPLAY '* LIDOS RELATORIOS...................:' WS-AC-LIDOS. */
            _.Display($"* LIDOS RELATORIOS...................:{WORK_AREA.WS_AC_LIDOS}");

            /*" -945- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -946- DISPLAY '* ROTINA ENCERRADA COM ERRO ' */
            _.Display($"* ROTINA ENCERRADA COM ERRO ");

            /*" -947- DISPLAY '* ------------------------- ' */
            _.Display($"* ------------------------- ");

            /*" -948- DISPLAY '*             ' */
            _.Display($"*             ");

            /*" -949- DISPLAY '************** TERMINO ANORMAL ********************' */
            _.Display($"************** TERMINO ANORMAL ********************");

            /*" -950- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, ABEND.WABEND1.WS_SQLCODE);

            /*" -951- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEND.WABEND1.WSQLERRD1);

            /*" -952- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEND.WABEND1.WSQLERRD2);

            /*" -953- DISPLAY WABEND */
            _.Display(ABEND.WABEND);

            /*" -955- DISPLAY WABEND1 */
            _.Display(ABEND.WABEND1);

            /*" -955- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -959- CLOSE DEVCIELO */
            DEVCIELO.Close();

            /*" -961- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -961- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}