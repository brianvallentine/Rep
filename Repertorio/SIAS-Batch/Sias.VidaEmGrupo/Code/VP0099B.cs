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
using Sias.VidaEmGrupo.DB2.VP0099B;

namespace Code
{
    public class VP0099B
    {
        public bool IsCall { get; set; }

        public VP0099B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *-- COMPRAR ASSISTENCIA SAF PARA O PRESTAMISTA CONTA CORRENTE 7732      */
        /*"      *   GERA UM ARQUIVO QUE SERA ENVIADO PARA TEMPO USS.                    */
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQTEMPO { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis ARQTEMPO
        {
            get
            {
                _.Move(REG_ARQTEMPO, _ARQTEMPO); VarBasis.RedefinePassValue(REG_ARQTEMPO, _ARQTEMPO, REG_ARQTEMPO); return _ARQTEMPO;
            }
        }
        /*"01   REG-ARQTEMPO                       PIC X(500).*/
        public StringBasis REG_ARQTEMPO { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 WS-LABEL                      PIC X(05) VALUE SPACES.*/
        public StringBasis WS_LABEL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
        /*"01 WS-FIM-CERTIF                 PIC X(03) VALUE SPACES.*/
        public StringBasis WS_FIM_CERTIF { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01 WS-FAZ-CAB                    PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_FAZ_CAB { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"01 WS-TAMANHO-RG                 PIC 9(02) VALUE ZEROS.*/
        public IntBasis WS_TAMANHO_RG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"01 WS-CERT-LIDO-COMP             PIC 9(08) VALUE ZEROS.*/
        public IntBasis WS_CERT_LIDO_COMP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01 WS-CERT-LIDO-CANC             PIC 9(08) VALUE ZEROS.*/
        public IntBasis WS_CERT_LIDO_CANC { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01 WS-QTD-COMPRA1                PIC 9(08) VALUE ZEROS.*/
        public IntBasis WS_QTD_COMPRA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01 WS-QTD-COMPRA2                PIC 9(08) VALUE ZEROS.*/
        public IntBasis WS_QTD_COMPRA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01 WS-QTD-CANCEL                 PIC 9(08) VALUE ZEROS.*/
        public IntBasis WS_QTD_CANCEL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01 WS-SQLCODE-ERRO               PIC 9(03) VALUE ZEROS.*/
        public IntBasis WS_SQLCODE_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"01 WS-DATA-CORRENTE              PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-DT-MENOS-1-MES             PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_MENOS_1_MES { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-COD-PESSOA                 PIC S9(9) USAGE COMP.*/
        public IntBasis WS_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01 WS-DDI                        PIC S9(4) USAGE COMP.*/
        public IntBasis WS_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01 WS-DDD                        PIC S9(4) USAGE COMP.*/
        public IntBasis WS_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01 WS-NUM-FONE                   PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis WS_NUM_FONE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"01 WS-I-DT-NASCIMENTO            PIC S9(4) COMP VALUE +0.*/
        public IntBasis WS_I_DT_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01 WS-DT-AUX.*/
        public VP0099B_WS_DT_AUX WS_DT_AUX { get; set; } = new VP0099B_WS_DT_AUX();
        public class VP0099B_WS_DT_AUX : VarBasis
        {
            /*"   03 WS-DT-ANO-AUX              PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_DT_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   03 WS-DT-MES-AUX              PIC 9(02) VALUE ZEROS.*/
            public IntBasis WS_DT_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   03 WS-DT-DIA-AUX              PIC 9(02) VALUE ZEROS.*/
            public IntBasis WS_DT_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"01 WS-IND                        PIC 9(06) VALUE ZEROS.*/
        }
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01 WS-IND1                       PIC 9(06) VALUE ZEROS.*/
        public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01 WS-IND2                       PIC 9(06) VALUE ZEROS.*/
        public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01 WS-TB1-RG.*/
        public VP0099B_WS_TB1_RG WS_TB1_RG { get; set; } = new VP0099B_WS_TB1_RG();
        public class VP0099B_WS_TB1_RG : VarBasis
        {
            /*"   03 WS-TAB1-NUM    OCCURS  15 TIMES.*/
            public ListBasis<VP0099B_WS_TAB1_NUM> WS_TAB1_NUM { get; set; } = new ListBasis<VP0099B_WS_TAB1_NUM>(15);
            public class VP0099B_WS_TAB1_NUM : VarBasis
            {
                /*"      05 WS-TB1-NUM-RG           PIC  X(001).*/
                public StringBasis WS_TB1_NUM_RG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"01 WS-TB2-RG2.*/
            }
        }
        public VP0099B_WS_TB2_RG2 WS_TB2_RG2 { get; set; } = new VP0099B_WS_TB2_RG2();
        public class VP0099B_WS_TB2_RG2 : VarBasis
        {
            /*"   03 WS-TAB2-NUM2    OCCURS  15 TIMES.*/
            public ListBasis<VP0099B_WS_TAB2_NUM2> WS_TAB2_NUM2 { get; set; } = new ListBasis<VP0099B_WS_TAB2_NUM2>(15);
            public class VP0099B_WS_TAB2_NUM2 : VarBasis
            {
                /*"      05 WS-TB2-NUM-RG2          PIC  9(001).*/
                public IntBasis WS_TB2_NUM_RG2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01 WS-TB3-RG3.*/
            }
        }
        public VP0099B_WS_TB3_RG3 WS_TB3_RG3 { get; set; } = new VP0099B_WS_TB3_RG3();
        public class VP0099B_WS_TB3_RG3 : VarBasis
        {
            /*"   03 WS-TAB3-NUM3    OCCURS  20 TIMES.*/
            public ListBasis<VP0099B_WS_TAB3_NUM3> WS_TAB3_NUM3 { get; set; } = new ListBasis<VP0099B_WS_TAB3_NUM3>(20);
            public class VP0099B_WS_TAB3_NUM3 : VarBasis
            {
                /*"      05 WS-TB3-NUM-RG3          PIC  9(001).*/
                public IntBasis WS_TB3_NUM_RG3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01 WS-CAB-TEMPO.*/
            }
        }
        public VP0099B_WS_CAB_TEMPO WS_CAB_TEMPO { get; set; } = new VP0099B_WS_CAB_TEMPO();
        public class VP0099B_WS_CAB_TEMPO : VarBasis
        {
            /*"   03 WS-CAB-COD-CLIENTE             PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_CAB_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"   03 WS-CAB-COD-PRODUTO             PIC  9(002) VALUE ZEROS.*/
            public IntBasis WS_CAB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"   03 WS-CAB-DTA-GERACAO             PIC  9(008) VALUE ZEROS.*/
            public IntBasis WS_CAB_DTA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   03 WS-CAB-NUM-SEQ                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_CAB_NUM_SEQ { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"   03 WS-CAB-FILLER                  PIC  X(482) VALUE SPACES.*/
            public StringBasis WS_CAB_FILLER { get; set; } = new StringBasis(new PIC("X", "482", "X(482)"), @"");
            /*"01 WS-DET-TEMPO.*/
        }
        public VP0099B_WS_DET_TEMPO WS_DET_TEMPO { get; set; } = new VP0099B_WS_DET_TEMPO();
        public class VP0099B_WS_DET_TEMPO : VarBasis
        {
            /*"   03 WS-DET-NUM-APOLICE             PIC  X(040) VALUE SPACES.*/
            public StringBasis WS_DET_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"   03 WS-DET-NUM-ITEM                PIC  X(005) VALUE SPACES.*/
            public StringBasis WS_DET_NUM_ITEM { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"   03 WS-DET-NUM-CARTAO              PIC  X(030) VALUE SPACES.*/
            public StringBasis WS_DET_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"   03 WS-DET-COD-SEGURO              PIC  9(010) VALUE ZEROS.*/
            public IntBasis WS_DET_COD_SEGURO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"   03 WS-DET-SIT-REGISTRO            PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_DET_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   03 WS-DET-DTA-INICIO              PIC  9(008) VALUE ZEROS.*/
            public IntBasis WS_DET_DTA_INICIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   03 WS-DET-DTA-FIM                 PIC  9(008) VALUE ZEROS.*/
            public IntBasis WS_DET_DTA_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   03 WS-DET-NOM-SEGURADO            PIC  X(040) VALUE SPACES.*/
            public StringBasis WS_DET_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"   03 WS-DET-CPF-CNPJ                PIC  9(014) VALUE ZEROS.*/
            public IntBasis WS_DET_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"   03 WS-DET-END-SEGURADO            PIC  X(060) VALUE SPACES.*/
            public StringBasis WS_DET_END_SEGURADO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"   03 WS-DET-NUM-ENDERECO            PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_DET_NUM_ENDERECO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   03 WS-DET-END-COMPLEME            PIC  X(040) VALUE SPACES.*/
            public StringBasis WS_DET_END_COMPLEME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"   03 WS-DET-NOM-CIDADE              PIC  X(062) VALUE SPACES.*/
            public StringBasis WS_DET_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "62", "X(062)"), @"");
            /*"   03 WS-DET-NOM-BAIRRO              PIC  X(040) VALUE SPACES.*/
            public StringBasis WS_DET_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"   03 WS-DET-CEP-CIDADE              PIC  9(008) VALUE ZEROS.*/
            public IntBasis WS_DET_CEP_CIDADE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   03 WS-DET-NOM-PAIS                PIC  X(020) VALUE SPACES.*/
            public StringBasis WS_DET_NOM_PAIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"   03 WS-DET-DDI-TEL                 PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_DET_DDI_TEL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"   03 WS-DET-DDD-TEL                 PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_DET_DDD_TEL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"   03 WS-DET-NUM-TEL                 PIC  9(010) VALUE ZEROS.*/
            public IntBasis WS_DET_NUM_TEL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"   03 WS-DET-COD-SEXO                PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_DET_COD_SEXO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"   03 WS-DET-DTA-NASC                PIC  9(008) VALUE ZEROS.*/
            public IntBasis WS_DET_DTA_NASC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   03 WS-DET-COD-RG                  PIC  9(018) VALUE ZEROS.*/
            public IntBasis WS_DET_COD_RG { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"   03 WS-DET-EST-CIVIL               PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_DET_EST_CIVIL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"   03 WS-DET-NOM-PROFISSAO           PIC  X(060) VALUE SPACES.*/
            public StringBasis WS_DET_NOM_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"   03 WS-DET-FILLER                  PIC  X(004) VALUE SPACES.*/
            public StringBasis WS_DET_FILLER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"01 WS-TRI-TEMPO.*/
        }
        public VP0099B_WS_TRI_TEMPO WS_TRI_TEMPO { get; set; } = new VP0099B_WS_TRI_TEMPO();
        public class VP0099B_WS_TRI_TEMPO : VarBasis
        {
            /*"   03 WS-TRI-QTD-REG                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_TRI_QTD_REG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"   03 WS-TRI-SEPARADOR               PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_TRI_SEPARADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"   03 WS-TRI-IDE-INCL                PIC  X(001) VALUE 'I'.*/
            public StringBasis WS_TRI_IDE_INCL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
            /*"   03 WS-TRI-QTD-INCL                PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_TRI_QTD_INCL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"   03 WS-TRI-IDE-ALTE                PIC  X(001) VALUE 'A'.*/
            public StringBasis WS_TRI_IDE_ALTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"   03 WS-TRI-QTD-ALTE                PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_TRI_QTD_ALTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"   03 WS-TRI-IDE-CANC                PIC  X(001) VALUE 'C'.*/
            public StringBasis WS_TRI_IDE_CANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"   03 WS-TRI-QTD-CANC                PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_TRI_QTD_CANC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"   03 WS-TRI-IDE-REAT                PIC  X(001) VALUE 'R'.*/
            public StringBasis WS_TRI_IDE_REAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"R");
            /*"   03 WS-TRI-QTD-REAT                PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_TRI_QTD_REAT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"   03 WS-TRI-FILLER                  PIC  X(470) VALUE SPACES.*/
            public StringBasis WS_TRI_FILLER { get; set; } = new StringBasis(new PIC("X", "470", "X(470)"), @"");
            /*"01  WS-ERRO-DB2.*/
        }
        public VP0099B_WS_ERRO_DB2 WS_ERRO_DB2 { get; set; } = new VP0099B_WS_ERRO_DB2();
        public class VP0099B_WS_ERRO_DB2 : VarBasis
        {
            /*"    03 FILLER                PIC X(11)     VALUE      ' SQLCODE = '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" SQLCODE = ");
            /*"    03 WS-SQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    03 FILLER                PIC X(12)     VALUE      ' SQLCODE1 = '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SQLCODE1 = ");
            /*"    03 WS-SQLCODE1           PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    03 FILLER                PIC  X(12) VALUE      ' SQLCODE2 = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SQLCODE2 = ");
            /*"    03 WS-SQLCODE2           PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PESSOEND PESSOEND { get; set; } = new Dclgens.PESSOEND();
        public Dclgens.VG097 VG097 { get; set; } = new Dclgens.VG097();
        public Dclgens.VG096 VG096 { get; set; } = new Dclgens.VG096();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();

        public VP0099B_CR_CERTIF_COMPRA CR_CERTIF_COMPRA { get; set; } = new VP0099B_CR_CERTIF_COMPRA(false);
        string GetQuery_CR_CERTIF_COMPRA()
        {
            var query = @$" SELECT PROPOVA.NUM_CERTIFICADO
							,PROPOVA.DATA_MOVIMENTO
							,VG096.DTA_PROXIMA_COBRANCA
							,PROPOVA.COD_PRODUTO
							,PROPOVA.NUM_APOLICE
							,PROPOVA.NUM_PARCELA
							,PROPOVA.COD_CLIENTE
							,PROPOVA.SIT_REGISTRO
							FROM SEGUROS.PROPOSTAS_VA PROPOVA
							JOIN SEGUROS.VG_MOVTO_PRESTAMISTA VG096 ON PROPOVA.NUM_CERTIFICADO = VG096.NUM_CERTIFICADO WHERE PROPOVA.COD_PRODUTO = 7732 AND PROPOVA.SIT_REGISTRO = '3' AND PROPOVA.SIT_INTERFACE = '0' AND CURRENT DATE BETWEEN VG096.DTA_VENCIMENTO AND VG096.DTA_PROXIMA_COBRANCA AND VG096.NUM_PARCELA =
							(SELECT  MAX(VG096A.NUM_PARCELA)
							FROM SEGUROS.VG_MOVTO_PRESTAMISTA VG096A WHERE VG096A.NUM_CERTIFICADO = VG096.NUM_CERTIFICADO)";

            return query;
        }


        public VP0099B_CR_CERTIF_CANCEL CR_CERTIF_CANCEL { get; set; } = new VP0099B_CR_CERTIF_CANCEL(false);
        string GetQuery_CR_CERTIF_CANCEL()
        {
            var query = @$" SELECT PROPOVA.NUM_CERTIFICADO
							,VG096.DTA_PROXIMA_COBRANCA
							,PROPOVA.COD_PRODUTO
							,PROPOVA.NUM_APOLICE
							,PROPOVA.NUM_PARCELA
							,PROPOVA.COD_CLIENTE
							,PROPOVA.SIT_REGISTRO
							FROM SEGUROS.PROPOSTAS_VA PROPOVA
							JOIN SEGUROS.VG_MOVTO_PRESTAMISTA VG096 ON PROPOVA.NUM_CERTIFICADO = VG096.NUM_CERTIFICADO WHERE PROPOVA.COD_PRODUTO = 7732 AND PROPOVA.SIT_REGISTRO = '4' AND PROPOVA.SIT_INTERFACE = '1' AND VG096.NUM_PARCELA =
							(SELECT  MAX(VG096A.NUM_PARCELA)
							FROM SEGUROS.VG_MOVTO_PRESTAMISTA VG096A WHERE VG096A.NUM_CERTIFICADO = VG096.NUM_CERTIFICADO)";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQTEMPO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQTEMPO.SetFile(ARQTEMPO_FILE_NAME_P);
                InitializeGetQuery();

                /*" -214- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -215- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -216- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -220- PERFORM R1000-INICIALIZA THRU R1000-FIM. */

                R1000_INICIALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_FIM*/


                /*" -222- PERFORM R2000-PRINCIPAL-COMPRA THRU R2000-FIM. */

                R2000_PRINCIPAL_COMPRA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_FIM*/


                /*" -224- PERFORM R4000-PRINCIPAL-CANCEL THRU R4000-FIM. */

                R4000_PRINCIPAL_CANCEL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_FIM*/


                /*" -226- PERFORM R9000-FINALIZA THRU R9000-FIM. */

                R9000_FINALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/


                /*" -226- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

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
            CR_CERTIF_COMPRA.GetQueryEvent += GetQuery_CR_CERTIF_COMPRA;
            CR_CERTIF_CANCEL.GetQueryEvent += GetQuery_CR_CERTIF_CANCEL;
        }

        [StopWatch]
        /*" R1000-INICIALIZA */
        private void R1000_INICIALIZA(bool isPerform = false)
        {
            /*" -231- MOVE 'R1000' TO WS-LABEL */
            _.Move("R1000", WS_LABEL);

            /*" -233- OPEN OUTPUT ARQTEMPO */
            ARQTEMPO.Open(REG_ARQTEMPO);

            /*" -241- DISPLAY 'VP0099B - VERSAO 01 - INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP0099B - VERSAO 01 - INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -243- PERFORM R1000_INICIALIZA_DB_SET_1 */

            R1000_INICIALIZA_DB_SET_1();

            /*" -246- INITIALIZE WS-DT-AUX */
            _.Initialize(
                WS_DT_AUX
            );

            /*" -253- STRING WS-DATA-CORRENTE(1:4) WS-DATA-CORRENTE(6:2) WS-DATA-CORRENTE(9:2) DELIMITED BY SIZE INTO WS-DT-AUX END-STRING */
            #region STRING
            var spl1 = WS_DATA_CORRENTE.Substring(1, 4).GetMoveValues();
            var spl2 = WS_DATA_CORRENTE.Substring(6, 2).GetMoveValues();
            var spl3 = WS_DATA_CORRENTE.Substring(9, 2).GetMoveValues();
            var results4 = spl1 + spl2 + spl3;
            _.Move(results4, WS_DT_AUX);
            #endregion

            /*" -254- PERFORM R1100-PEGAR-MAX-SEQ THRU R1100-FIM */

            R1100_PEGAR_MAX_SEQ(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_FIM*/


            /*" -254- . */

        }

        [StopWatch]
        /*" R1000-INICIALIZA-DB-SET-1 */
        public void R1000_INICIALIZA_DB_SET_1()
        {
            /*" -243- EXEC SQL SET :WS-DATA-CORRENTE = CURRENT DATE END-EXEC */
            _.Move(_.CurrentDate(), WS_DATA_CORRENTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_FIM*/

        [StopWatch]
        /*" R1100-PEGAR-MAX-SEQ */
        private void R1100_PEGAR_MAX_SEQ(bool isPerform = false)
        {
            /*" -260- MOVE 'R1100' TO WS-LABEL */
            _.Move("R1100", WS_LABEL);

            /*" -267- PERFORM R1100_PEGAR_MAX_SEQ_DB_SELECT_1 */

            R1100_PEGAR_MAX_SEQ_DB_SELECT_1();

            /*" -270- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -271- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -272- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -274- DISPLAY 'VP0099B - ERRO SELECT MAX VG_ACOPLADO_PRESTAMISTA ' */
                _.Display($"VP0099B - ERRO SELECT MAX VG_ACOPLADO_PRESTAMISTA ");

                /*" -275- DISPLAY 'SQLCODE       = ' WS-SQLCODE */
                _.Display($"SQLCODE       = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -276- DISPLAY 'COD_PRODUTO   = 7732' */
                _.Display($"COD_PRODUTO   = 7732");

                /*" -277- DISPLAY 'COD_ACOPLADO  = 3 ' */
                _.Display($"COD_ACOPLADO  = 3 ");

                /*" -278- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -279- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -280- END-IF */
            }


            /*" -280- . */

        }

        [StopWatch]
        /*" R1100-PEGAR-MAX-SEQ-DB-SELECT-1 */
        public void R1100_PEGAR_MAX_SEQ_DB_SELECT_1()
        {
            /*" -267- EXEC SQL SELECT VALUE(MAX(NUM_ARQ_PROPOSTA),0)+ 1 INTO :VG097-NUM-ARQ-PROPOSTA FROM SEGUROS.VG_ACOPLADO_PRESTAMISTA VG097 WHERE COD_PRODUTO = 7732 AND COD_ACOPLADO = 3 WITH UR END-EXEC */

            var r1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1 = new R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1.Execute(r1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG097_NUM_ARQ_PROPOSTA, VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_ARQ_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_FIM*/

        [StopWatch]
        /*" R2000-PRINCIPAL-COMPRA */
        private void R2000_PRINCIPAL_COMPRA(bool isPerform = false)
        {
            /*" -285- MOVE 'R2000' TO WS-LABEL */
            _.Move("R2000", WS_LABEL);

            /*" -287- MOVE SPACES TO WS-FIM-CERTIF */
            _.Move("", WS_FIM_CERTIF);

            /*" -289- PERFORM R2000_PRINCIPAL_COMPRA_DB_OPEN_1 */

            R2000_PRINCIPAL_COMPRA_DB_OPEN_1();

            /*" -292- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -293- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -294- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -297- DISPLAY 'VP0099B - ERRO CLOSE CURSOR CR_CERTIF-COMPRA => SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO CLOSE CURSOR CR_CERTIF-COMPRA => SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -298- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -299- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -301- END-IF */
            }


            /*" -303- PERFORM R2100-LER-CERT-COMPRA THRU R2100-FIM */

            R2100_LER_CERT_COMPRA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_FIM*/


            /*" -311- DISPLAY 'INICIO DA ROTINA => R2200-PROC-CERT-COMPRA ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIO DA ROTINA => R2200-PROC-CERT-COMPRA {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -314- PERFORM R2200-PROC-CERT-COMPRA THRU R2200-FIM UNTIL WS-FIM-CERTIF = 'SIM' */

            while (!(WS_FIM_CERTIF == "SIM"))
            {

                R2200_PROC_CERT_COMPRA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_FIM*/

            }

            /*" -322- DISPLAY 'FIM DA ROTINA    => R2200-PROC-CERT-COMPRA ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"FIM DA ROTINA    => R2200-PROC-CERT-COMPRA {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -323- IF WS-CERT-LIDO-COMP = ZEROS */

            if (WS_CERT_LIDO_COMP == 00)
            {

                /*" -324- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -325- DISPLAY 'NAO TEVE CERTIFICADO DO PRODUTO 7732' */
                _.Display($"NAO TEVE CERTIFICADO DO PRODUTO 7732");

                /*" -326- DISPLAY 'NOVOS OU PARCELAS PAGAS' */
                _.Display($"NOVOS OU PARCELAS PAGAS");

                /*" -327- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -329- END-IF */
            }


            /*" -331- PERFORM R2000_PRINCIPAL_COMPRA_DB_CLOSE_1 */

            R2000_PRINCIPAL_COMPRA_DB_CLOSE_1();

            /*" -334- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -335- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -336- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -339- DISPLAY 'VP0099B - ERRO CLOSE CURSOR CR_CERTIF-COMPRA => SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO CLOSE CURSOR CR_CERTIF-COMPRA => SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -340- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -341- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -342- END-IF */
            }


            /*" -342- . */

        }

        [StopWatch]
        /*" R2000-PRINCIPAL-COMPRA-DB-OPEN-1 */
        public void R2000_PRINCIPAL_COMPRA_DB_OPEN_1()
        {
            /*" -289- EXEC SQL OPEN CR_CERTIF-COMPRA END-EXEC */

            CR_CERTIF_COMPRA.Open();

        }

        [StopWatch]
        /*" R2000-PRINCIPAL-COMPRA-DB-CLOSE-1 */
        public void R2000_PRINCIPAL_COMPRA_DB_CLOSE_1()
        {
            /*" -331- EXEC SQL CLOSE CR_CERTIF-COMPRA END-EXEC */

            CR_CERTIF_COMPRA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_FIM*/

        [StopWatch]
        /*" R2100-LER-CERT-COMPRA */
        private void R2100_LER_CERT_COMPRA(bool isPerform = false)
        {
            /*" -348- MOVE 'R2100' TO WS-LABEL */
            _.Move("R2100", WS_LABEL);

            /*" -358- PERFORM R2100_LER_CERT_COMPRA_DB_FETCH_1 */

            R2100_LER_CERT_COMPRA_DB_FETCH_1();

            /*" -361- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -362- MOVE 'SIM' TO WS-FIM-CERTIF */
                _.Move("SIM", WS_FIM_CERTIF);

                /*" -363- ELSE */
            }
            else
            {


                /*" -364- IF SQLCODE = ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -365- ADD 1 TO WS-CERT-LIDO-COMP */
                    WS_CERT_LIDO_COMP.Value = WS_CERT_LIDO_COMP + 1;

                    /*" -366- ELSE */
                }
                else
                {


                    /*" -367- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -368- MOVE SQLCODE TO WS-SQLCODE */
                        _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                        /*" -369- DISPLAY '--------------------------------------------' */
                        _.Display($"--------------------------------------------");

                        /*" -372- DISPLAY 'VP0099B - ERRO FETCH CURSOR CR_CERTIF-COMPRA => SQLCODE = ' WS-SQLCODE */
                        _.Display($"VP0099B - ERRO FETCH CURSOR CR_CERTIF-COMPRA => SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                        /*" -373- DISPLAY '---------------------------------------------' */
                        _.Display($"---------------------------------------------");

                        /*" -374- PERFORM R9999-FIM-ANORMAL */

                        R9999_FIM_ANORMAL(true);

                        /*" -375- END-IF */
                    }


                    /*" -376- END-IF */
                }


                /*" -377- END-IF */
            }


            /*" -377- . */

        }

        [StopWatch]
        /*" R2100-LER-CERT-COMPRA-DB-FETCH-1 */
        public void R2100_LER_CERT_COMPRA_DB_FETCH_1()
        {
            /*" -358- EXEC SQL FETCH CR_CERTIF-COMPRA INTO :PROPOVA-NUM-CERTIFICADO ,:PROPOVA-DATA-MOVIMENTO ,:PROPOVA-DTPROXVEN ,:PROPOVA-COD-PRODUTO ,:PROPOVA-NUM-APOLICE ,:PROPOVA-NUM-PARCELA ,:PROPOVA-COD-CLIENTE ,:PROPOVA-SIT-REGISTRO END-EXEC */

            if (CR_CERTIF_COMPRA.Fetch())
            {
                _.Move(CR_CERTIF_COMPRA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CR_CERTIF_COMPRA.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(CR_CERTIF_COMPRA.VG096_DTA_PROXIMA_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CR_CERTIF_COMPRA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CR_CERTIF_COMPRA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CR_CERTIF_COMPRA.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CR_CERTIF_COMPRA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CR_CERTIF_COMPRA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_FIM*/

        [StopWatch]
        /*" R2200-PROC-CERT-COMPRA */
        private void R2200_PROC_CERT_COMPRA(bool isPerform = false)
        {
            /*" -383- MOVE 'R2200' TO WS-LABEL */
            _.Move("R2200", WS_LABEL);

            /*" -385- PERFORM R2300-LER-FIDELIZ THRU R2300-FIM */

            R2300_LER_FIDELIZ(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_FIM*/


            /*" -387- PERFORM R2400-LER-CLIENTE THRU R2400-FIM */

            R2400_LER_CLIENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_FIM*/


            /*" -389- PERFORM R2500-LER-PESSOA-FISICA THRU R2500-FIM */

            R2500_LER_PESSOA_FISICA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_FIM*/


            /*" -391- PERFORM R2600-LER-ENDERECO THRU R2600-FIM */

            R2600_LER_ENDERECO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_FIM*/


            /*" -393- PERFORM R2700-LER-TELEFONE THRU R2700-FIM */

            R2700_LER_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_FIM*/


            /*" -395- PERFORM R2800-TRATAR-SAF THRU R2800-FIM */

            R2800_TRATAR_SAF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_FIM*/


            /*" -397- PERFORM R2900-INS-VG-ACOPLADO-PREST THRU R2900-FIM */

            R2900_INS_VG_ACOPLADO_PREST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_FIM*/


            /*" -399- PERFORM R2950-UPT-PROPOSTAS-VA THRU R2950-FIM */

            R2950_UPT_PROPOSTAS_VA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2950_FIM*/


            /*" -400- PERFORM R2100-LER-CERT-COMPRA THRU R2100-FIM */

            R2100_LER_CERT_COMPRA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_FIM*/


            /*" -400- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_FIM*/

        [StopWatch]
        /*" R2300-LER-FIDELIZ */
        private void R2300_LER_FIDELIZ(bool isPerform = false)
        {
            /*" -405- MOVE 'R2300' TO WS-LABEL */
            _.Move("R2300", WS_LABEL);

            /*" -407- MOVE PROPOVA-NUM-CERTIFICADO TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -413- PERFORM R2300_LER_FIDELIZ_DB_SELECT_1 */

            R2300_LER_FIDELIZ_DB_SELECT_1();

            /*" -416- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -417- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -418- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -421- DISPLAY 'VP0099B - ERRO SELECT PROPOSTA_FIDELIZ SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO SELECT PROPOSTA_FIDELIZ SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -422- DISPLAY 'NUM_PROPOSTA_SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_PROPOSTA_SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -423- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -424- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -425- END-IF */
            }


            /*" -425- . */

        }

        [StopWatch]
        /*" R2300-LER-FIDELIZ-DB-SELECT-1 */
        public void R2300_LER_FIDELIZ_DB_SELECT_1()
        {
            /*" -413- EXEC SQL SELECT COD_PESSOA INTO :PROPOFID-COD-PESSOA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r2300_LER_FIDELIZ_DB_SELECT_1_Query1 = new R2300_LER_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R2300_LER_FIDELIZ_DB_SELECT_1_Query1.Execute(r2300_LER_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_FIM*/

        [StopWatch]
        /*" R2400-LER-CLIENTE */
        private void R2400_LER_CLIENTE(bool isPerform = false)
        {
            /*" -430- MOVE 'R2400' TO WS-LABEL */
            _.Move("R2400", WS_LABEL);

            /*" -432- MOVE PROPOVA-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -442- PERFORM R2400_LER_CLIENTE_DB_SELECT_1 */

            R2400_LER_CLIENTE_DB_SELECT_1();

            /*" -445- IF WS-I-DT-NASCIMENTO IS NEGATIVE */

            if (WS_I_DT_NASCIMENTO < 0)
            {

                /*" -446- MOVE SPACES TO CLIENTES-DATA-NASCIMENTO */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -447- MOVE ZEROS TO WS-I-DT-NASCIMENTO */
                _.Move(0, WS_I_DT_NASCIMENTO);

                /*" -449- END-IF */
            }


            /*" -450- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -451- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -452- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -455- DISPLAY 'VP0099B - ERRO SELECT CLIENTES SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO SELECT CLIENTES SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -456- DISPLAY 'COD_CLIENTE = ' CLIENTES-COD-CLIENTE */
                _.Display($"COD_CLIENTE = {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -457- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -458- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -459- END-IF */
            }


            /*" -459- . */

        }

        [StopWatch]
        /*" R2400-LER-CLIENTE-DB-SELECT-1 */
        public void R2400_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -442- EXEC SQL SELECT NOME_RAZAO, CGCCPF, DATA_NASCIMENTO INTO :CLIENTES-NOME-RAZAO ,:CLIENTES-CGCCPF ,:CLIENTES-DATA-NASCIMENTO :WS-I-DT-NASCIMENTO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE WITH UR END-EXEC */

            var r2400_LER_CLIENTE_DB_SELECT_1_Query1 = new R2400_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2400_LER_CLIENTE_DB_SELECT_1_Query1.Execute(r2400_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.WS_I_DT_NASCIMENTO, WS_I_DT_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_FIM*/

        [StopWatch]
        /*" R2500-LER-PESSOA-FISICA */
        private void R2500_LER_PESSOA_FISICA(bool isPerform = false)
        {
            /*" -464- MOVE 'R2500' TO WS-LABEL */
            _.Move("R2500", WS_LABEL);

            /*" -466- MOVE PROPOFID-COD-PESSOA TO PESSOFIS-COD-PESSOA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA);

            /*" -480- PERFORM R2500_LER_PESSOA_FISICA_DB_SELECT_1 */

            R2500_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -494- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -495- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -498- DISPLAY 'VP0099B - ERRO SELECT PESSOA_FISICA SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO SELECT PESSOA_FISICA SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -499- DISPLAY 'COD_PESSOA = ' PESSOFIS-COD-PESSOA */
                _.Display($"COD_PESSOA = {PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA}");

                /*" -500- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -501- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -503- END-IF */
            }


            /*" -508- MOVE ZEROS TO WS-TB2-RG2 WS-TB3-RG3 WS-TAMANHO-RG WS-IND2 */
            _.Move(0, WS_TB2_RG2, WS_TB3_RG3, WS_TAMANHO_RG, WS_IND2);

            /*" -509- MOVE SPACES TO WS-TB1-RG */
            _.Move("", WS_TB1_RG);

            /*" -514- MOVE PESSOFIS-NUM-IDENTIDADE TO WS-TB1-RG */
            _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE, WS_TB1_RG);

            /*" -521- PERFORM R2510-TRATA-TAB-RG THRU R2510-FIM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 15. */

            for (WS_IND.Value = 1; !(WS_IND > 15); WS_IND.Value += 1)
            {

                R2510_TRATA_TAB_RG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_FIM*/

            }

            /*" -523- MOVE 20 TO WS-IND2 */
            _.Move(20, WS_IND2);

            /*" -531- PERFORM R2520-MOVER-TAB-RG3 THRU R2520-FIM VARYING WS-IND FROM WS-TAMANHO-RG BY -1 UNTIL WS-IND = ZEROS */

            for (WS_IND.Value = WS_TAMANHO_RG; !(WS_IND == 00); WS_IND.Value += -1)
            {

                R2520_MOVER_TAB_RG3(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_FIM*/

            }

            /*" -532- PERFORM R2530-DESC-PROFISSAO THRU R2530-FIM */

            R2530_DESC_PROFISSAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_FIM*/


            /*" -532- . */

        }

        [StopWatch]
        /*" R2500-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R2500_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -480- EXEC SQL SELECT DATA_NASCIMENTO, SEXO, ESTADO_CIVIL, VALUE(NUM_IDENTIDADE, ' ' ), VALUE(COD_CBO, 0) INTO :PESSOFIS-DATA-NASCIMENTO, :PESSOFIS-SEXO, :PESSOFIS-ESTADO-CIVIL, :PESSOFIS-NUM-IDENTIDADE, :PESSOFIS-COD-CBO FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :PESSOFIS-COD-PESSOA WITH UR END-EXEC */

            var r2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1 = new R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                PESSOFIS_COD_PESSOA = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA.ToString(),
            };

            var executed_1 = R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOFIS_DATA_NASCIMENTO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_NASCIMENTO);
                _.Move(executed_1.PESSOFIS_SEXO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO);
                _.Move(executed_1.PESSOFIS_ESTADO_CIVIL, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL);
                _.Move(executed_1.PESSOFIS_NUM_IDENTIDADE, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE);
                _.Move(executed_1.PESSOFIS_COD_CBO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_FIM*/

        [StopWatch]
        /*" R2510-TRATA-TAB-RG */
        private void R2510_TRATA_TAB_RG(bool isPerform = false)
        {
            /*" -543- MOVE 'R2510' TO WS-LABEL */
            _.Move("R2510", WS_LABEL);

            /*" -549- IF WS-TB1-NUM-RG(WS-IND) = '0' OR '1' OR '2' OR '3' OR '4' OR '5' OR '6' OR '7' OR '8' OR '9' */

            if (WS_TB1_RG.WS_TAB1_NUM[WS_IND].WS_TB1_NUM_RG.In("0", "1", "2", "3", "4", "5", "6", "7", "8", "9"))
            {

                /*" -550- ADD 1 TO WS-IND2 WS-TAMANHO-RG */
                WS_IND2.Value = WS_IND2 + 1;
                WS_TAMANHO_RG.Value = WS_TAMANHO_RG + 1;

                /*" -555- MOVE WS-TB1-NUM-RG(WS-IND) TO WS-TB2-NUM-RG2(WS-IND2) */
                _.Move(WS_TB1_RG.WS_TAB1_NUM[WS_IND].WS_TB1_NUM_RG, WS_TB2_RG2.WS_TAB2_NUM2[WS_IND2].WS_TB2_NUM_RG2);

                /*" -556- END-IF */
            }


            /*" -556- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_FIM*/

        [StopWatch]
        /*" R2520-MOVER-TAB-RG3 */
        private void R2520_MOVER_TAB_RG3(bool isPerform = false)
        {
            /*" -562- MOVE 'R2520' TO WS-LABEL */
            _.Move("R2520", WS_LABEL);

            /*" -569- MOVE WS-TB2-NUM-RG2(WS-IND) TO WS-TB3-NUM-RG3(WS-IND2) */
            _.Move(WS_TB2_RG2.WS_TAB2_NUM2[WS_IND].WS_TB2_NUM_RG2, WS_TB3_RG3.WS_TAB3_NUM3[WS_IND2].WS_TB3_NUM_RG3);

            /*" -570- SUBTRACT 1 FROM WS-IND2 */
            WS_IND2.Value = WS_IND2 - 1;

            /*" -570- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_FIM*/

        [StopWatch]
        /*" R2530-DESC-PROFISSAO */
        private void R2530_DESC_PROFISSAO(bool isPerform = false)
        {
            /*" -576- MOVE 'R2530' TO WS-LABEL */
            _.Move("R2530", WS_LABEL);

            /*" -582- PERFORM R2530_DESC_PROFISSAO_DB_SELECT_1 */

            R2530_DESC_PROFISSAO_DB_SELECT_1();

            /*" -585- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -586- MOVE SPACES TO CBO-DESCR-CBO */
                _.Move("", CBO.DCLCBO.CBO_DESCR_CBO);

                /*" -587- ELSE */
            }
            else
            {


                /*" -588- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -589- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                    /*" -590- DISPLAY '---------------------------------------------' */
                    _.Display($"---------------------------------------------");

                    /*" -593- DISPLAY 'VP0099B - ERRO SELECT SEGUROS.CBO  SQLCODE = ' WS-SQLCODE */
                    _.Display($"VP0099B - ERRO SELECT SEGUROS.CBO  SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                    /*" -594- DISPLAY 'COD_CBO     = ' PESSOFIS-COD-CBO */
                    _.Display($"COD_CBO     = {PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO}");

                    /*" -595- DISPLAY '---------------------------------------------' */
                    _.Display($"---------------------------------------------");

                    /*" -596- PERFORM R9999-FIM-ANORMAL */

                    R9999_FIM_ANORMAL(true);

                    /*" -597- END-IF */
                }


                /*" -598- END-IF */
            }


            /*" -598- . */

        }

        [StopWatch]
        /*" R2530-DESC-PROFISSAO-DB-SELECT-1 */
        public void R2530_DESC_PROFISSAO_DB_SELECT_1()
        {
            /*" -582- EXEC SQL SELECT DESCR_CBO INTO :CBO-DESCR-CBO FROM SEGUROS.CBO WHERE COD_CBO = :PESSOFIS-COD-CBO WITH UR END-EXEC */

            var r2530_DESC_PROFISSAO_DB_SELECT_1_Query1 = new R2530_DESC_PROFISSAO_DB_SELECT_1_Query1()
            {
                PESSOFIS_COD_CBO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO.ToString(),
            };

            var executed_1 = R2530_DESC_PROFISSAO_DB_SELECT_1_Query1.Execute(r2530_DESC_PROFISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_FIM*/

        [StopWatch]
        /*" R2600-LER-ENDERECO */
        private void R2600_LER_ENDERECO(bool isPerform = false)
        {
            /*" -603- MOVE 'R2600' TO WS-LABEL */
            _.Move("R2600", WS_LABEL);

            /*" -605- MOVE PROPOFID-COD-PESSOA TO PESSOEND-COD-PESSOA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA, PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_COD_PESSOA);

            /*" -620- PERFORM R2600_LER_ENDERECO_DB_SELECT_1 */

            R2600_LER_ENDERECO_DB_SELECT_1();

            /*" -623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -624- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -625- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -628- DISPLAY 'VP0099B - ERRO SELECT PESSOA_ENDERECO SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO SELECT PESSOA_ENDERECO SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -629- DISPLAY 'COD_PESSOA = ' PESSOEND-COD-PESSOA */
                _.Display($"COD_PESSOA = {PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_COD_PESSOA}");

                /*" -630- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -631- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -632- END-IF */
            }


            /*" -632- . */

        }

        [StopWatch]
        /*" R2600-LER-ENDERECO-DB-SELECT-1 */
        public void R2600_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -620- EXEC SQL SELECT ENDERECO, VALUE(COMPL_ENDER, ' ' ), RTRIM(CIDADE) || '/' || SIGLA_UF, VALUE(BAIRRO, ' ' ), CEP INTO :PESSOEND-ENDERECO, :PESSOEND-COMPL-ENDER, :PESSOEND-CIDADE, :PESSOEND-BAIRRO, :PESSOEND-CEP FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :PESSOEND-COD-PESSOA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r2600_LER_ENDERECO_DB_SELECT_1_Query1 = new R2600_LER_ENDERECO_DB_SELECT_1_Query1()
            {
                PESSOEND_COD_PESSOA = PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_COD_PESSOA.ToString(),
            };

            var executed_1 = R2600_LER_ENDERECO_DB_SELECT_1_Query1.Execute(r2600_LER_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOEND_ENDERECO, PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_ENDERECO);
                _.Move(executed_1.PESSOEND_COMPL_ENDER, PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_COMPL_ENDER);
                _.Move(executed_1.PESSOEND_CIDADE, PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_CIDADE);
                _.Move(executed_1.PESSOEND_BAIRRO, PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_BAIRRO);
                _.Move(executed_1.PESSOEND_CEP, PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_FIM*/

        [StopWatch]
        /*" R2700-LER-TELEFONE */
        private void R2700_LER_TELEFONE(bool isPerform = false)
        {
            /*" -638- MOVE 'R2700' TO WS-LABEL */
            _.Move("R2700", WS_LABEL);

            /*" -640- MOVE PROPOFID-COD-PESSOA TO WS-COD-PESSOA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA, WS_COD_PESSOA);

            /*" -651- PERFORM R2700_LER_TELEFONE_DB_SELECT_1 */

            R2700_LER_TELEFONE_DB_SELECT_1();

            /*" -654- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -657- MOVE ZEROS TO WS-DDI WS-DDD WS-NUM-FONE */
                _.Move(0, WS_DDI, WS_DDD, WS_NUM_FONE);

                /*" -658- ELSE */
            }
            else
            {


                /*" -659- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -660- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                    /*" -661- DISPLAY '---------------------------------------------' */
                    _.Display($"---------------------------------------------");

                    /*" -664- DISPLAY 'VP0099B - ERRO SELECT PESSOA_TELEFONE SQLCODE = ' WS-SQLCODE */
                    _.Display($"VP0099B - ERRO SELECT PESSOA_TELEFONE SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                    /*" -665- DISPLAY 'COD_PESSOA = ' WS-COD-PESSOA */
                    _.Display($"COD_PESSOA = {WS_COD_PESSOA}");

                    /*" -666- DISPLAY '---------------------------------------------' */
                    _.Display($"---------------------------------------------");

                    /*" -667- PERFORM R9999-FIM-ANORMAL */

                    R9999_FIM_ANORMAL(true);

                    /*" -668- END-IF */
                }


                /*" -669- END-IF */
            }


            /*" -669- . */

        }

        [StopWatch]
        /*" R2700-LER-TELEFONE-DB-SELECT-1 */
        public void R2700_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -651- EXEC SQL SELECT DDI, DDD, NUM_FONE INTO :WS-DDI, :WS-DDD, :WS-NUM-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :WS-COD-PESSOA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r2700_LER_TELEFONE_DB_SELECT_1_Query1 = new R2700_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                WS_COD_PESSOA = WS_COD_PESSOA.ToString(),
            };

            var executed_1 = R2700_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r2700_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DDI, WS_DDI);
                _.Move(executed_1.WS_DDD, WS_DDD);
                _.Move(executed_1.WS_NUM_FONE, WS_NUM_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_FIM*/

        [StopWatch]
        /*" R2800-TRATAR-SAF */
        private void R2800_TRATAR_SAF(bool isPerform = false)
        {
            /*" -675- MOVE 'R2800' TO WS-LABEL */
            _.Move("R2800", WS_LABEL);

            /*" -676- IF WS-FAZ-CAB = ZEROS */

            if (WS_FAZ_CAB == 00)
            {

                /*" -677- MOVE 9 TO WS-CAB-COD-CLIENTE */
                _.Move(9, WS_CAB_TEMPO.WS_CAB_COD_CLIENTE);

                /*" -678- MOVE 3 TO WS-CAB-COD-PRODUTO */
                _.Move(3, WS_CAB_TEMPO.WS_CAB_COD_PRODUTO);

                /*" -679- MOVE WS-DT-AUX TO WS-CAB-DTA-GERACAO */
                _.Move(WS_DT_AUX, WS_CAB_TEMPO.WS_CAB_DTA_GERACAO);

                /*" -680- MOVE VG097-NUM-ARQ-PROPOSTA TO WS-CAB-NUM-SEQ */
                _.Move(VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_ARQ_PROPOSTA, WS_CAB_TEMPO.WS_CAB_NUM_SEQ);

                /*" -681- MOVE 1 TO WS-FAZ-CAB */
                _.Move(1, WS_FAZ_CAB);

                /*" -682- WRITE REG-ARQTEMPO FROM WS-CAB-TEMPO */
                _.Move(WS_CAB_TEMPO.GetMoveValues(), REG_ARQTEMPO);

                ARQTEMPO.Write(REG_ARQTEMPO.GetMoveValues().ToString());

                /*" -684- END-IF */
            }


            /*" -685- MOVE PROPOVA-NUM-CERTIFICADO TO WS-DET-NUM-APOLICE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_DET_TEMPO.WS_DET_NUM_APOLICE);

            /*" -686- MOVE SPACES TO WS-DET-NUM-ITEM */
            _.Move("", WS_DET_TEMPO.WS_DET_NUM_ITEM);

            /*" -687- MOVE PROPOVA-NUM-APOLICE TO WS-DET-NUM-CARTAO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, WS_DET_TEMPO.WS_DET_NUM_CARTAO);

            /*" -689- MOVE 7732 TO WS-DET-COD-SEGURO */
            _.Move(7732, WS_DET_TEMPO.WS_DET_COD_SEGURO);

            /*" -691- IF PROPOVA-SIT-REGISTRO = '3' AND PROPOVA-NUM-PARCELA = 1 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA == 1)
            {

                /*" -692- MOVE 'I' TO WS-DET-SIT-REGISTRO */
                _.Move("I", WS_DET_TEMPO.WS_DET_SIT_REGISTRO);

                /*" -694- END-IF */
            }


            /*" -696- IF PROPOVA-SIT-REGISTRO = '3' AND PROPOVA-NUM-PARCELA > 1 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA > 1)
            {

                /*" -697- MOVE 'A' TO WS-DET-SIT-REGISTRO */
                _.Move("A", WS_DET_TEMPO.WS_DET_SIT_REGISTRO);

                /*" -699- END-IF */
            }


            /*" -700- IF PROPOVA-SIT-REGISTRO = '4' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
            {

                /*" -701- MOVE 'E' TO WS-DET-SIT-REGISTRO */
                _.Move("E", WS_DET_TEMPO.WS_DET_SIT_REGISTRO);

                /*" -704- END-IF */
            }


            /*" -709- PERFORM R2800_TRATAR_SAF_DB_SELECT_1 */

            R2800_TRATAR_SAF_DB_SELECT_1();

            /*" -712- INITIALIZE WS-DET-DTA-INICIO */
            _.Initialize(
                WS_DET_TEMPO.WS_DET_DTA_INICIO
            );

            /*" -719- STRING WS-DT-MENOS-1-MES(1:4) WS-DT-MENOS-1-MES(6:2) WS-DT-MENOS-1-MES(9:2) DELIMITED BY SIZE INTO WS-DET-DTA-INICIO END-STRING */
            #region STRING
            var spl4 = WS_DT_MENOS_1_MES.Substring(1, 4).GetMoveValues();
            var spl5 = WS_DT_MENOS_1_MES.Substring(6, 2).GetMoveValues();
            var spl6 = WS_DT_MENOS_1_MES.Substring(9, 2).GetMoveValues();
            var results7 = spl4 + spl5 + spl6;
            _.Move(results7, WS_DET_TEMPO.WS_DET_DTA_INICIO);
            #endregion

            /*" -720- INITIALIZE WS-DET-DTA-FIM */
            _.Initialize(
                WS_DET_TEMPO.WS_DET_DTA_FIM
            );

            /*" -727- STRING PROPOVA-DTPROXVEN(1:4) PROPOVA-DTPROXVEN(6:2) PROPOVA-DTPROXVEN(9:2) DELIMITED BY SIZE INTO WS-DET-DTA-FIM END-STRING */
            #region STRING
            var spl7 = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Substring(1, 4).GetMoveValues();
            var spl8 = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Substring(6, 2).GetMoveValues();
            var spl9 = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Substring(9, 2).GetMoveValues();
            var results10 = spl7 + spl8 + spl9;
            _.Move(results10, WS_DET_TEMPO.WS_DET_DTA_FIM);
            #endregion

            /*" -728- MOVE CLIENTES-NOME-RAZAO TO WS-DET-NOM-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WS_DET_TEMPO.WS_DET_NOM_SEGURADO);

            /*" -729- MOVE CLIENTES-CGCCPF TO WS-DET-CPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WS_DET_TEMPO.WS_DET_CPF_CNPJ);

            /*" -730- MOVE PESSOEND-ENDERECO TO WS-DET-END-SEGURADO */
            _.Move(PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_ENDERECO, WS_DET_TEMPO.WS_DET_END_SEGURADO);

            /*" -731- MOVE 0 TO WS-DET-NUM-ENDERECO */
            _.Move(0, WS_DET_TEMPO.WS_DET_NUM_ENDERECO);

            /*" -732- MOVE PESSOEND-COMPL-ENDER TO WS-DET-END-COMPLEME */
            _.Move(PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_COMPL_ENDER, WS_DET_TEMPO.WS_DET_END_COMPLEME);

            /*" -733- MOVE PESSOEND-CIDADE TO WS-DET-NOM-CIDADE */
            _.Move(PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_CIDADE, WS_DET_TEMPO.WS_DET_NOM_CIDADE);

            /*" -734- MOVE PESSOEND-BAIRRO TO WS-DET-NOM-BAIRRO */
            _.Move(PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_BAIRRO, WS_DET_TEMPO.WS_DET_NOM_BAIRRO);

            /*" -735- MOVE PESSOEND-CEP TO WS-DET-CEP-CIDADE */
            _.Move(PESSOEND.DCLPESSOA_ENDERECO.PESSOEND_CEP, WS_DET_TEMPO.WS_DET_CEP_CIDADE);

            /*" -736- MOVE 'BRASIL' TO WS-DET-NOM-PAIS */
            _.Move("BRASIL", WS_DET_TEMPO.WS_DET_NOM_PAIS);

            /*" -737- MOVE WS-DDI TO WS-DET-DDI-TEL */
            _.Move(WS_DDI, WS_DET_TEMPO.WS_DET_DDI_TEL);

            /*" -738- MOVE WS-DDD TO WS-DET-DDD-TEL */
            _.Move(WS_DDD, WS_DET_TEMPO.WS_DET_DDD_TEL);

            /*" -740- MOVE WS-NUM-FONE TO WS-DET-NUM-TEL */
            _.Move(WS_NUM_FONE, WS_DET_TEMPO.WS_DET_NUM_TEL);

            /*" -741- IF PESSOFIS-SEXO = 'M' */

            if (PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO == "M")
            {

                /*" -742- MOVE 1 TO WS-DET-COD-SEXO */
                _.Move(1, WS_DET_TEMPO.WS_DET_COD_SEXO);

                /*" -743- ELSE */
            }
            else
            {


                /*" -744- IF PESSOFIS-SEXO = 'F' */

                if (PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO == "F")
                {

                    /*" -745- MOVE 2 TO WS-DET-COD-SEXO */
                    _.Move(2, WS_DET_TEMPO.WS_DET_COD_SEXO);

                    /*" -746- ELSE */
                }
                else
                {


                    /*" -747- MOVE 2 TO WS-DET-COD-SEXO */
                    _.Move(2, WS_DET_TEMPO.WS_DET_COD_SEXO);

                    /*" -748- END-IF */
                }


                /*" -750- END-IF */
            }


            /*" -751- INITIALIZE WS-DET-DTA-NASC */
            _.Initialize(
                WS_DET_TEMPO.WS_DET_DTA_NASC
            );

            /*" -758- STRING CLIENTES-DATA-NASCIMENTO(1:4) CLIENTES-DATA-NASCIMENTO(6:2) CLIENTES-DATA-NASCIMENTO(9:2) DELIMITED BY SIZE INTO WS-DET-DTA-NASC END-STRING */
            #region STRING
            var spl10 = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(1, 4).GetMoveValues();
            var spl11 = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(6, 2).GetMoveValues();
            var spl12 = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(9, 2).GetMoveValues();
            var results13 = spl10 + spl11 + spl12;
            _.Move(results13, WS_DET_TEMPO.WS_DET_DTA_NASC);
            #endregion

            /*" -759- MOVE WS-TB3-RG3 TO WS-DET-COD-RG */
            _.Move(WS_TB3_RG3, WS_DET_TEMPO.WS_DET_COD_RG);

            /*" -761- MOVE ZEROS TO WS-TB3-RG3 */
            _.Move(0, WS_TB3_RG3);

            /*" -762- IF PESSOFIS-ESTADO-CIVIL = 'C' */

            if (PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL == "C")
            {

                /*" -763- MOVE 1 TO WS-DET-EST-CIVIL */
                _.Move(1, WS_DET_TEMPO.WS_DET_EST_CIVIL);

                /*" -764- ELSE */
            }
            else
            {


                /*" -765- IF PESSOFIS-ESTADO-CIVIL = 'S' */

                if (PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL == "S")
                {

                    /*" -766- MOVE 2 TO WS-DET-EST-CIVIL */
                    _.Move(2, WS_DET_TEMPO.WS_DET_EST_CIVIL);

                    /*" -767- ELSE */
                }
                else
                {


                    /*" -768- IF PESSOFIS-ESTADO-CIVIL = 'D' */

                    if (PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL == "D")
                    {

                        /*" -769- MOVE 3 TO WS-DET-EST-CIVIL */
                        _.Move(3, WS_DET_TEMPO.WS_DET_EST_CIVIL);

                        /*" -770- ELSE */
                    }
                    else
                    {


                        /*" -771- IF PESSOFIS-ESTADO-CIVIL = 'V' */

                        if (PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL == "V")
                        {

                            /*" -772- MOVE 4 TO WS-DET-EST-CIVIL */
                            _.Move(4, WS_DET_TEMPO.WS_DET_EST_CIVIL);

                            /*" -773- ELSE */
                        }
                        else
                        {


                            /*" -774- MOVE 5 TO WS-DET-EST-CIVIL */
                            _.Move(5, WS_DET_TEMPO.WS_DET_EST_CIVIL);

                            /*" -775- END-IF */
                        }


                        /*" -776- END-IF */
                    }


                    /*" -777- END-IF */
                }


                /*" -779- END-IF */
            }


            /*" -781- MOVE CBO-DESCR-CBO TO WS-DET-NOM-PROFISSAO */
            _.Move(CBO.DCLCBO.CBO_DESCR_CBO, WS_DET_TEMPO.WS_DET_NOM_PROFISSAO);

            /*" -783- WRITE REG-ARQTEMPO FROM WS-DET-TEMPO */
            _.Move(WS_DET_TEMPO.GetMoveValues(), REG_ARQTEMPO);

            ARQTEMPO.Write(REG_ARQTEMPO.GetMoveValues().ToString());

            /*" -785- IF PROPOVA-SIT-REGISTRO = '3' AND PROPOVA-NUM-PARCELA = 1 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA == 1)
            {

                /*" -786- ADD 1 TO WS-QTD-COMPRA1 */
                WS_QTD_COMPRA1.Value = WS_QTD_COMPRA1 + 1;

                /*" -788- END-IF */
            }


            /*" -790- IF PROPOVA-SIT-REGISTRO = '3' AND PROPOVA-NUM-PARCELA > 1 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA > 1)
            {

                /*" -791- ADD 1 TO WS-QTD-COMPRA2 */
                WS_QTD_COMPRA2.Value = WS_QTD_COMPRA2 + 1;

                /*" -793- END-IF */
            }


            /*" -794- IF PROPOVA-SIT-REGISTRO = '4' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
            {

                /*" -795- ADD 1 TO WS-QTD-CANCEL */
                WS_QTD_CANCEL.Value = WS_QTD_CANCEL + 1;

                /*" -798- END-IF */
            }


            /*" -798- . */

        }

        [StopWatch]
        /*" R2800-TRATAR-SAF-DB-SELECT-1 */
        public void R2800_TRATAR_SAF_DB_SELECT_1()
        {
            /*" -709- EXEC SQL SELECT DATE(:PROPOVA-DTPROXVEN) - 1 MONTH INTO :WS-DT-MENOS-1-MES FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:PROPOVA-DTPROXVEN) - 1 MONTH
            /*--INTO :WS-DT-MENOS-1-MES
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC
            /*-- */

            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToDateTime().AddMonths(-1).ToString(_.CurrentDateFormat), WS_DT_MENOS_1_MES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_FIM*/

        [StopWatch]
        /*" R2900-INS-VG-ACOPLADO-PREST */
        private void R2900_INS_VG_ACOPLADO_PREST(bool isPerform = false)
        {
            /*" -804- MOVE 'R2900' TO WS-LABEL */
            _.Move("R2900", WS_LABEL);

            /*" -805- MOVE PROPOVA-NUM-CERTIFICADO TO VG097-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_CERTIFICADO);

            /*" -806- MOVE PROPOVA-COD-PRODUTO TO VG097-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_COD_PRODUTO);

            /*" -807- MOVE 3 TO VG097-COD-ACOPLADO */
            _.Move(3, VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_COD_ACOPLADO);

            /*" -809- MOVE 'SERVICO DE ASSISTENCIA FUNERAL' TO VG097-DES-ACOPLADO */
            _.Move("SERVICO DE ASSISTENCIA FUNERAL", VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DES_ACOPLADO);

            /*" -810- MOVE WS-DT-MENOS-1-MES TO VG097-DTA-INI-VIGENCIA */
            _.Move(WS_DT_MENOS_1_MES, VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_INI_VIGENCIA);

            /*" -811- MOVE PROPOVA-DTPROXVEN TO VG097-DTA-FIM-VIGENCIA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN, VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_FIM_VIGENCIA);

            /*" -813- MOVE 'VP0099B' TO VG097-NOM-PROGRAMA */
            _.Move("VP0099B", VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NOM_PROGRAMA);

            /*" -815- IF PROPOVA-SIT-REGISTRO = '3' AND PROPOVA-NUM-PARCELA = 1 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA == 1)
            {

                /*" -816- MOVE 'I' TO VG097-STA-REGISTRO */
                _.Move("I", VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_STA_REGISTRO);

                /*" -818- END-IF */
            }


            /*" -820- IF PROPOVA-SIT-REGISTRO = '3' AND PROPOVA-NUM-PARCELA > 1 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA > 1)
            {

                /*" -821- MOVE 'A' TO VG097-STA-REGISTRO */
                _.Move("A", VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_STA_REGISTRO);

                /*" -823- END-IF */
            }


            /*" -824- IF PROPOVA-SIT-REGISTRO = '4' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
            {

                /*" -825- MOVE 'E' TO VG097-STA-REGISTRO */
                _.Move("E", VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_STA_REGISTRO);

                /*" -827- END-IF */
            }


            /*" -850- PERFORM R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1 */

            R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1();

            /*" -871- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -872- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -873- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -876- DISPLAY 'VP0099B - ERRO INSERT VG_ACOPLADO_PRESTAMISTA SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO INSERT VG_ACOPLADO_PRESTAMISTA SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -877- DISPLAY 'NUM-CERTIFICADO  = ' VG097-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO  = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_CERTIFICADO}");

                /*" -878- DISPLAY 'COD-PRODUTO      = ' VG097-COD-PRODUTO */
                _.Display($"COD-PRODUTO      = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_COD_PRODUTO}");

                /*" -879- DISPLAY 'COD-ACOPLADO     = ' VG097-COD-ACOPLADO */
                _.Display($"COD-ACOPLADO     = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_COD_ACOPLADO}");

                /*" -880- DISPLAY 'NUM-ARQ-PROPOSTA = ' VG097-NUM-ARQ-PROPOSTA */
                _.Display($"NUM-ARQ-PROPOSTA = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_ARQ_PROPOSTA}");

                /*" -881- DISPLAY 'DES-ACOPLADO     = ' VG097-DES-ACOPLADO */
                _.Display($"DES-ACOPLADO     = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DES_ACOPLADO}");

                /*" -882- DISPLAY 'DTA-INI-VIGENCIA = ' VG097-DTA-INI-VIGENCIA */
                _.Display($"DTA-INI-VIGENCIA = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_INI_VIGENCIA}");

                /*" -883- DISPLAY 'DTA-FIM-VIGENCIA = ' VG097-DTA-FIM-VIGENCIA */
                _.Display($"DTA-FIM-VIGENCIA = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_FIM_VIGENCIA}");

                /*" -884- DISPLAY 'STA-REGISTRO     = ' VG097-STA-REGISTRO */
                _.Display($"STA-REGISTRO     = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_STA_REGISTRO}");

                /*" -885- DISPLAY 'NOM-PROGRAMA     = ' VG097-NOM-PROGRAMA */
                _.Display($"NOM-PROGRAMA     = {VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NOM_PROGRAMA}");

                /*" -886- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -887- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -888- END-IF */
            }


            /*" -888- . */

        }

        [StopWatch]
        /*" R2900-INS-VG-ACOPLADO-PREST-DB-INSERT-1 */
        public void R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1()
        {
            /*" -850- EXEC SQL INSERT INTO SEGUROS.VG_ACOPLADO_PRESTAMISTA ( NUM_CERTIFICADO ,COD_PRODUTO ,COD_ACOPLADO ,NUM_ARQ_PROPOSTA ,DES_ACOPLADO ,DTA_INI_VIGENCIA ,DTA_FIM_VIGENCIA ,STA_REGISTRO ,NOM_PROGRAMA ,DTH_ATUALIZACAO) VALUES ( :VG097-NUM-CERTIFICADO ,:VG097-COD-PRODUTO ,:VG097-COD-ACOPLADO ,:VG097-NUM-ARQ-PROPOSTA ,:VG097-DES-ACOPLADO ,:VG097-DTA-INI-VIGENCIA ,:VG097-DTA-FIM-VIGENCIA ,:VG097-STA-REGISTRO ,:VG097-NOM-PROGRAMA , CURRENT TIMESTAMP) END-EXEC. */

            var r2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1 = new R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1()
            {
                VG097_NUM_CERTIFICADO = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_CERTIFICADO.ToString(),
                VG097_COD_PRODUTO = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_COD_PRODUTO.ToString(),
                VG097_COD_ACOPLADO = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_COD_ACOPLADO.ToString(),
                VG097_NUM_ARQ_PROPOSTA = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NUM_ARQ_PROPOSTA.ToString(),
                VG097_DES_ACOPLADO = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DES_ACOPLADO.ToString(),
                VG097_DTA_INI_VIGENCIA = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_INI_VIGENCIA.ToString(),
                VG097_DTA_FIM_VIGENCIA = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_FIM_VIGENCIA.ToString(),
                VG097_STA_REGISTRO = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_STA_REGISTRO.ToString(),
                VG097_NOM_PROGRAMA = VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_NOM_PROGRAMA.ToString(),
            };

            R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1.Execute(r2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_FIM*/

        [StopWatch]
        /*" R2950-UPT-PROPOSTAS-VA */
        private void R2950_UPT_PROPOSTAS_VA(bool isPerform = false)
        {
            /*" -894- MOVE 'R2950' TO WS-LABEL */
            _.Move("R2950", WS_LABEL);

            /*" -895- IF PROPOVA-SIT-REGISTRO = '3' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
            {

                /*" -896- MOVE '1' TO PROPOVA-SIT-INTERFACE */
                _.Move("1", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_INTERFACE);

                /*" -898- END-IF */
            }


            /*" -899- IF PROPOVA-SIT-REGISTRO = '4' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
            {

                /*" -900- MOVE '2' TO PROPOVA-SIT-INTERFACE */
                _.Move("2", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_INTERFACE);

                /*" -902- END-IF */
            }


            /*" -906- PERFORM R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1 */

            R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1();

            /*" -909- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -910- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -911- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -914- DISPLAY 'VP0099B - ERRO UPDATE PROPOSTAS_VA SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO UPDATE PROPOSTAS_VA SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -915- DISPLAY 'SIT_INTERFACE    = 1' */
                _.Display($"SIT_INTERFACE    = 1");

                /*" -916- DISPLAY 'NUM_CERTIFICADO  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -917- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -918- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -919- END-IF */
            }


            /*" -919- . */

        }

        [StopWatch]
        /*" R2950-UPT-PROPOSTAS-VA-DB-UPDATE-1 */
        public void R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1()
        {
            /*" -906- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_INTERFACE = :PROPOVA-SIT-INTERFACE WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC */

            var r2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1 = new R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1()
            {
                PROPOVA_SIT_INTERFACE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_INTERFACE.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1.Execute(r2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2950_FIM*/

        [StopWatch]
        /*" R4000-PRINCIPAL-CANCEL */
        private void R4000_PRINCIPAL_CANCEL(bool isPerform = false)
        {
            /*" -924- MOVE 'R4000' TO WS-LABEL */
            _.Move("R4000", WS_LABEL);

            /*" -926- MOVE SPACES TO WS-FIM-CERTIF */
            _.Move("", WS_FIM_CERTIF);

            /*" -928- PERFORM R4000_PRINCIPAL_CANCEL_DB_OPEN_1 */

            R4000_PRINCIPAL_CANCEL_DB_OPEN_1();

            /*" -931- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -932- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -933- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -936- DISPLAY 'VP0099B - ERRO CLOSE CURSOR CR_CERTIF-CANCEL => SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO CLOSE CURSOR CR_CERTIF-CANCEL => SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -937- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -938- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -940- END-IF */
            }


            /*" -942- PERFORM R4100-LER-CERT-CANCEL THRU R4100-FIM */

            R4100_LER_CERT_CANCEL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_FIM*/


            /*" -950- DISPLAY 'INICIO DA ROTINA => R4200-PROC-CERT-CANCEL ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIO DA ROTINA => R4200-PROC-CERT-CANCEL {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -953- PERFORM R4200-PROC-CERT-CANCEL THRU R4200-FIM UNTIL WS-FIM-CERTIF = 'SIM' */

            while (!(WS_FIM_CERTIF == "SIM"))
            {

                R4200_PROC_CERT_CANCEL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_FIM*/

            }

            /*" -961- DISPLAY 'FIM DA ROTINA    => R4200-PROC-CERT-CANCEL ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"FIM DA ROTINA    => R4200-PROC-CERT-CANCEL {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -962- IF WS-CERT-LIDO-CANC = ZEROS */

            if (WS_CERT_LIDO_CANC == 00)
            {

                /*" -963- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -964- DISPLAY 'NAO TEVE CERTIFICADO DO PRODUTO 7732' */
                _.Display($"NAO TEVE CERTIFICADO DO PRODUTO 7732");

                /*" -965- DISPLAY 'PARA CANCELAR COMPRA ASSISTENCIA SAF' */
                _.Display($"PARA CANCELAR COMPRA ASSISTENCIA SAF");

                /*" -966- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -968- END-IF */
            }


            /*" -970- PERFORM R4000_PRINCIPAL_CANCEL_DB_CLOSE_1 */

            R4000_PRINCIPAL_CANCEL_DB_CLOSE_1();

            /*" -973- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -974- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -975- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -978- DISPLAY 'VP0099B - ERRO CLOSE CURSOR CR_CERTIF-CANCEL => SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0099B - ERRO CLOSE CURSOR CR_CERTIF-CANCEL => SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -979- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -980- PERFORM R9999-FIM-ANORMAL */

                R9999_FIM_ANORMAL(true);

                /*" -981- END-IF */
            }


            /*" -981- . */

        }

        [StopWatch]
        /*" R4000-PRINCIPAL-CANCEL-DB-OPEN-1 */
        public void R4000_PRINCIPAL_CANCEL_DB_OPEN_1()
        {
            /*" -928- EXEC SQL OPEN CR_CERTIF-CANCEL END-EXEC */

            CR_CERTIF_CANCEL.Open();

        }

        [StopWatch]
        /*" R4000-PRINCIPAL-CANCEL-DB-CLOSE-1 */
        public void R4000_PRINCIPAL_CANCEL_DB_CLOSE_1()
        {
            /*" -970- EXEC SQL CLOSE CR_CERTIF-CANCEL END-EXEC */

            CR_CERTIF_CANCEL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_FIM*/

        [StopWatch]
        /*" R4100-LER-CERT-CANCEL */
        private void R4100_LER_CERT_CANCEL(bool isPerform = false)
        {
            /*" -987- MOVE 'R4100' TO WS-LABEL */
            _.Move("R4100", WS_LABEL);

            /*" -996- PERFORM R4100_LER_CERT_CANCEL_DB_FETCH_1 */

            R4100_LER_CERT_CANCEL_DB_FETCH_1();

            /*" -999- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1000- MOVE 'SIM' TO WS-FIM-CERTIF */
                _.Move("SIM", WS_FIM_CERTIF);

                /*" -1001- ELSE */
            }
            else
            {


                /*" -1002- IF SQLCODE = ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1003- ADD 1 TO WS-CERT-LIDO-CANC */
                    WS_CERT_LIDO_CANC.Value = WS_CERT_LIDO_CANC + 1;

                    /*" -1004- ELSE */
                }
                else
                {


                    /*" -1005- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1006- MOVE SQLCODE TO WS-SQLCODE */
                        _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                        /*" -1007- DISPLAY '--------------------------------------------' */
                        _.Display($"--------------------------------------------");

                        /*" -1010- DISPLAY 'VP0099B - ERRO FETCH CURSOR CR_CERTIF-CANCEL => SQLCODE = ' WS-SQLCODE */
                        _.Display($"VP0099B - ERRO FETCH CURSOR CR_CERTIF-CANCEL => SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                        /*" -1011- DISPLAY '---------------------------------------------' */
                        _.Display($"---------------------------------------------");

                        /*" -1012- PERFORM R9999-FIM-ANORMAL */

                        R9999_FIM_ANORMAL(true);

                        /*" -1013- END-IF */
                    }


                    /*" -1014- END-IF */
                }


                /*" -1015- END-IF */
            }


            /*" -1015- . */

        }

        [StopWatch]
        /*" R4100-LER-CERT-CANCEL-DB-FETCH-1 */
        public void R4100_LER_CERT_CANCEL_DB_FETCH_1()
        {
            /*" -996- EXEC SQL FETCH CR_CERTIF-CANCEL INTO :PROPOVA-NUM-CERTIFICADO ,:PROPOVA-DTPROXVEN ,:PROPOVA-COD-PRODUTO ,:PROPOVA-NUM-APOLICE ,:PROPOVA-NUM-PARCELA ,:PROPOVA-COD-CLIENTE ,:PROPOVA-SIT-REGISTRO END-EXEC */

            if (CR_CERTIF_CANCEL.Fetch())
            {
                _.Move(CR_CERTIF_CANCEL.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CR_CERTIF_CANCEL.VG096_DTA_PROXIMA_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CR_CERTIF_CANCEL.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CR_CERTIF_CANCEL.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CR_CERTIF_CANCEL.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CR_CERTIF_CANCEL.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CR_CERTIF_CANCEL.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_FIM*/

        [StopWatch]
        /*" R4200-PROC-CERT-CANCEL */
        private void R4200_PROC_CERT_CANCEL(bool isPerform = false)
        {
            /*" -1021- MOVE 'R4200' TO WS-LABEL */
            _.Move("R4200", WS_LABEL);

            /*" -1023- PERFORM R2300-LER-FIDELIZ THRU R2300-FIM */

            R2300_LER_FIDELIZ(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_FIM*/


            /*" -1025- PERFORM R2400-LER-CLIENTE THRU R2400-FIM */

            R2400_LER_CLIENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_FIM*/


            /*" -1027- PERFORM R2500-LER-PESSOA-FISICA THRU R2500-FIM */

            R2500_LER_PESSOA_FISICA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_FIM*/


            /*" -1029- PERFORM R2600-LER-ENDERECO THRU R2600-FIM */

            R2600_LER_ENDERECO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_FIM*/


            /*" -1031- PERFORM R2700-LER-TELEFONE THRU R2700-FIM */

            R2700_LER_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_FIM*/


            /*" -1033- PERFORM R2800-TRATAR-SAF THRU R2800-FIM */

            R2800_TRATAR_SAF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_FIM*/


            /*" -1035- PERFORM R2900-INS-VG-ACOPLADO-PREST THRU R2900-FIM */

            R2900_INS_VG_ACOPLADO_PREST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_FIM*/


            /*" -1037- PERFORM R2950-UPT-PROPOSTAS-VA THRU R2950-FIM */

            R2950_UPT_PROPOSTAS_VA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2950_FIM*/


            /*" -1038- PERFORM R4100-LER-CERT-CANCEL THRU R4100-FIM */

            R4100_LER_CERT_CANCEL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_FIM*/


            /*" -1038- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_FIM*/

        [StopWatch]
        /*" R9000-FINALIZA */
        private void R9000_FINALIZA(bool isPerform = false)
        {
            /*" -1048- MOVE 'R9000' TO WS-LABEL */
            _.Move("R9000", WS_LABEL);

            /*" -1049- IF WS-FAZ-CAB = 1 */

            if (WS_FAZ_CAB == 1)
            {

                /*" -1050- MOVE WS-QTD-COMPRA1 TO WS-TRI-QTD-INCL */
                _.Move(WS_QTD_COMPRA1, WS_TRI_TEMPO.WS_TRI_QTD_INCL);

                /*" -1051- MOVE WS-QTD-COMPRA2 TO WS-TRI-QTD-ALTE */
                _.Move(WS_QTD_COMPRA2, WS_TRI_TEMPO.WS_TRI_QTD_ALTE);

                /*" -1052- MOVE WS-QTD-CANCEL TO WS-TRI-QTD-CANC */
                _.Move(WS_QTD_CANCEL, WS_TRI_TEMPO.WS_TRI_QTD_CANC);

                /*" -1053- COMPUTE WS-TRI-QTD-REG = WS-TRI-QTD-INCL + WS-TRI-QTD-CANC */
                WS_TRI_TEMPO.WS_TRI_QTD_REG.Value = WS_TRI_TEMPO.WS_TRI_QTD_INCL + WS_TRI_TEMPO.WS_TRI_QTD_CANC;

                /*" -1054- WRITE REG-ARQTEMPO FROM WS-TRI-TEMPO */
                _.Move(WS_TRI_TEMPO.GetMoveValues(), REG_ARQTEMPO);

                ARQTEMPO.Write(REG_ARQTEMPO.GetMoveValues().ToString());

                /*" -1056- END-IF */
            }


            /*" -1057- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1059- DISPLAY 'VP0099B - QTD CERTIFICADOS LIDOS COMPRA    = ' WS-CERT-LIDO-COMP */
            _.Display($"VP0099B - QTD CERTIFICADOS LIDOS COMPRA    = {WS_CERT_LIDO_COMP}");

            /*" -1061- DISPLAY 'VP0099B - QTD COMPRA SAF                   = ' WS-QTD-COMPRA1 */
            _.Display($"VP0099B - QTD COMPRA SAF                   = {WS_QTD_COMPRA1}");

            /*" -1063- DISPLAY 'VP0099B - QTD RE-COMPRA SAF                = ' WS-QTD-COMPRA2 */
            _.Display($"VP0099B - QTD RE-COMPRA SAF                = {WS_QTD_COMPRA2}");

            /*" -1065- DISPLAY 'VP0099B - QTD CERTIFICADOS LIDOS CANCELADO = ' WS-CERT-LIDO-CANC */
            _.Display($"VP0099B - QTD CERTIFICADOS LIDOS CANCELADO = {WS_CERT_LIDO_CANC}");

            /*" -1067- DISPLAY 'VP0099B - QTD CANCELADO SAF                = ' WS-QTD-CANCEL */
            _.Display($"VP0099B - QTD CANCELADO SAF                = {WS_QTD_CANCEL}");

            /*" -1069- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1077- DISPLAY 'VP0099B - FIM PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP0099B - FIM PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1079- CLOSE ARQTEMPO */
            ARQTEMPO.Close();

            /*" -1080- STOP RUN */

            throw new GoBack();   // => STOP RUN.

            /*" -1080- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/

        [StopWatch]
        /*" R9999-FIM-ANORMAL */
        private void R9999_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -1087- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1089- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

            /*" -1090- MOVE SQLERRD(1) TO WS-SQLCODE1 */
            _.Move(DB.SQLERRD[1], WS_ERRO_DB2.WS_SQLCODE1);

            /*" -1092- MOVE SQLERRD(2) TO WS-SQLCODE2 */
            _.Move(DB.SQLERRD[2], WS_ERRO_DB2.WS_SQLCODE2);

            /*" -1093- DISPLAY 'VP0099B -  PARAGRAFO DO ERRO => ' WS-LABEL */
            _.Display($"VP0099B -  PARAGRAFO DO ERRO => {WS_LABEL}");

            /*" -1095- DISPLAY WS-ERRO-DB2. */
            _.Display(WS_ERRO_DB2);

            /*" -1097- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1098- CLOSE ARQTEMPO */
            ARQTEMPO.Close();

            /*" -1099- STOP RUN */

            throw new GoBack();   // => STOP RUN.

            /*" -1099- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_FIM*/
    }
}