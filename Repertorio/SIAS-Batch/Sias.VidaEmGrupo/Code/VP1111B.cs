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
using Sias.VidaEmGrupo.DB2.VP1111B;

namespace Code
{
    public class VP1111B
    {
        public bool IsCall { get; set; }

        public VP1111B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA/PROGRAMADOR....  DIOGO MATHEUS                        *      */
        /*"      * DATA CODIFICACAO .......  02/12/2015                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO: GERAR ARQUIVO DE CANCELAMENTOS DOS PRODUTOS PRESTAMISTA*      */
        /*"      *         7705, 7707, 7713 E 7715  PARA O SIGPF.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 2                                                    *      */
        /*"      * MOTIVO  : MELHORA DE ACESSO A TABELA                           *      */
        /*"      * CADMUS  : PEDIDO DO FORONI                                     *      */
        /*"      * DATA    : 25/08/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.2                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 1                                                    *      */
        /*"      * MOTIVO  : GERAR ARQUIVO DE CANCELAMENTOS PARA SIGPF            *      */
        /*"      * CADMUS  : 122174                                               *      */
        /*"      * DATA    : 02/12/2015                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.1                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_SAIDA01, _ARQSAIDA); VarBasis.RedefinePassValue(REG_SAIDA01, _ARQSAIDA, REG_SAIDA01); return _ARQSAIDA;
            }
        }
        /*"01  REG-SAIDA01                   PIC X(100).*/
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 WS-NUM-PROPOSTA                PIC 9(14) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
        /*"01 WS-NUM-CONT-TERC               PIC 9(15) VALUE ZEROS.*/
        public IntBasis WS_NUM_CONT_TERC { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
        /*"01 WS-CERT-SIAS-LIDOS             PIC 9(10) VALUE ZEROS.*/
        public IntBasis WS_CERT_SIAS_LIDOS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)"));
        /*"01 WS-CERT-ARQ-LIDOS              PIC 9(10) VALUE ZEROS.*/
        public IntBasis WS_CERT_ARQ_LIDOS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)"));
        /*"01 WS-CERT-EFP-LIDOS              PIC 9(10) VALUE ZEROS.*/
        public IntBasis WS_CERT_EFP_LIDOS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)"));
        /*"01 WS-LABEL                       PIC X(05) VALUE SPACES.*/
        public StringBasis WS_LABEL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
        /*"01 WS-FIM-CERT-SIAS               PIC X(03) VALUE SPACES.*/
        public StringBasis WS_FIM_CERT_SIAS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01 WS-FIM-CERT-EFP                PIC X(03) VALUE SPACES.*/
        public StringBasis WS_FIM_CERT_EFP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01 WS-FIM-CERT-ARQ                PIC X(03) VALUE SPACES.*/
        public StringBasis WS_FIM_CERT_ARQ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01 WS-GRAVADOS                    PIC 9(10) VALUE ZEROS.*/
        public IntBasis WS_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)"));
        /*"01 WS-DATA-CORRENTE               PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-DATA-CANCEL                 PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_CANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-DT-INI                      PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-DT-FIM                      PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-NUM-TERC1.*/
        public VP1111B_WS_NUM_TERC1 WS_NUM_TERC1 { get; set; } = new VP1111B_WS_NUM_TERC1();
        public class VP1111B_WS_NUM_TERC1 : VarBasis
        {
            /*"   03 WS-ZEROS-TERC1              PIC 9(03) VALUE ZEROS.*/
            public IntBasis WS_ZEROS_TERC1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"   03 WS-CANAL-TERC1              PIC 9(01) VALUE ZEROS.*/
            public IntBasis WS_CANAL_TERC1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"   03 WS-AGENCIA-TERC1            PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_AGENCIA_TERC1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   03 WS-SEQ-TERC1                PIC 9(07) VALUE ZEROS.*/
            public IntBasis WS_SEQ_TERC1 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"01 WS-NUM-TERC2.*/
        }
        public VP1111B_WS_NUM_TERC2 WS_NUM_TERC2 { get; set; } = new VP1111B_WS_NUM_TERC2();
        public class VP1111B_WS_NUM_TERC2 : VarBasis
        {
            /*"   03 WS-CANAL-TERC2              PIC 9(01) VALUE ZEROS.*/
            public IntBasis WS_CANAL_TERC2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"   03 WS-AGENCIA-TERC2            PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_AGENCIA_TERC2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   03 WS-RAMO-TERC2               PIC 9(02) VALUE ZEROS.*/
            public IntBasis WS_RAMO_TERC2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   03 WS-SEQ-TERC2                PIC 9(07) VALUE ZEROS.*/
            public IntBasis WS_SEQ_TERC2 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"01 WS-DT-AUX.*/
        }
        public VP1111B_WS_DT_AUX WS_DT_AUX { get; set; } = new VP1111B_WS_DT_AUX();
        public class VP1111B_WS_DT_AUX : VarBasis
        {
            /*"   03 WS-ANO-AUX                  PIC X(04) VALUE SPACES.*/
            public StringBasis WS_ANO_AUX { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"   03 WS-BR1-AUX                  PIC X(01) VALUE SPACES.*/
            public StringBasis WS_BR1_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   03 WS-MES-AUX                  PIC X(02) VALUE SPACES.*/
            public StringBasis WS_MES_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"   03 WS-BR2-AUX                  PIC X(01) VALUE SPACES.*/
            public StringBasis WS_BR2_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   03 WS-DIA-AUX                  PIC X(02) VALUE SPACES.*/
            public StringBasis WS_DIA_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"01 WS-DT-CANCEL.*/
        }
        public VP1111B_WS_DT_CANCEL WS_DT_CANCEL { get; set; } = new VP1111B_WS_DT_CANCEL();
        public class VP1111B_WS_DT_CANCEL : VarBasis
        {
            /*"   03 WS-DIA-CAN                  PIC 9(02) VALUE ZEROS.*/
            public IntBasis WS_DIA_CAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   03 WS-MES-CAN                  PIC 9(02) VALUE ZEROS.*/
            public IntBasis WS_MES_CAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   03 WS-ANO-CAN                  PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_ANO_CAN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"01 WS-TIMESTAMP.*/
        }
        public VP1111B_WS_TIMESTAMP WS_TIMESTAMP { get; set; } = new VP1111B_WS_TIMESTAMP();
        public class VP1111B_WS_TIMESTAMP : VarBasis
        {
            /*"   03 WS-DT-TIME                  PIC X(10) VALUE SPACES.*/
            public StringBasis WS_DT_TIME { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   03 WS-FILLER-TIME              PIC X(16) VALUE SPACES.*/
            public StringBasis WS_FILLER_TIME { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
            /*"01 WS-TIMESTAMP2.*/
        }
        public VP1111B_WS_TIMESTAMP2 WS_TIMESTAMP2 { get; set; } = new VP1111B_WS_TIMESTAMP2();
        public class VP1111B_WS_TIMESTAMP2 : VarBasis
        {
            /*"   03 WS-DT-TIME2                 PIC X(10) VALUE SPACES.*/
            public StringBasis WS_DT_TIME2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   03 WS-FILLER-TIME2             PIC X(16) VALUE SPACES.*/
            public StringBasis WS_FILLER_TIME2 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
            /*"01 WS-REG-HEADER.*/
        }
        public VP1111B_WS_REG_HEADER WS_REG_HEADER { get; set; } = new VP1111B_WS_REG_HEADER();
        public class VP1111B_WS_REG_HEADER : VarBasis
        {
            /*"   03 REG-H-IDENTIFICA            PIC X(001).*/
            public StringBasis REG_H_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   03 REG-H-NOME-ARQ              PIC X(008).*/
            public StringBasis REG_H_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   03 REG-H-DATA-GER.*/
            public VP1111B_REG_H_DATA_GER REG_H_DATA_GER { get; set; } = new VP1111B_REG_H_DATA_GER();
            public class VP1111B_REG_H_DATA_GER : VarBasis
            {
                /*"      05 REG-H-DD-GER             PIC X(002) VALUE SPACES.*/
                public StringBasis REG_H_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      05 REG-H-MM-GER             PIC X(002) VALUE SPACES.*/
                public StringBasis REG_H_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"      05 REG-H-AA-GER             PIC X(004) VALUE SPACES.*/
                public StringBasis REG_H_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   03 REG-H-COD-SIST              PIC 9(001).*/
            }
            public IntBasis REG_H_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   03 REG-H-COD-SIST-DEST         PIC 9(001).*/
            public IntBasis REG_H_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   03 REG-H-SEQ-ARQ               PIC 9(006).*/
            public IntBasis REG_H_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   03 REG-H-ESPACOS               PIC X(075).*/
            public StringBasis REG_H_ESPACOS { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
            /*"01 WS-REG-DETALHE.*/
        }
        public VP1111B_WS_REG_DETALHE WS_REG_DETALHE { get; set; } = new VP1111B_WS_REG_DETALHE();
        public class VP1111B_WS_REG_DETALHE : VarBasis
        {
            /*"   03 REG-D-IDENTIFICA            PIC X(001).*/
            public StringBasis REG_D_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   03 REG-D-NUM-PROPOSTA          PIC 9(014).*/
            public IntBasis REG_D_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"   03 REG-D-SIT-PROPOSTA          PIC X(003).*/
            public StringBasis REG_D_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"   03 REG-D-BRANCOS-0             PIC X(003).*/
            public StringBasis REG_D_BRANCOS_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"   03 REG-D-TIPO-MOTIVO           PIC 9(003).*/
            public IntBasis REG_D_TIPO_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   03 REG-D-DATA-INICIO-SIT       PIC 9(008).*/
            public IntBasis REG_D_DATA_INICIO_SIT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-D-BRANCOS-1             PIC X(046).*/
            public StringBasis REG_D_BRANCOS_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"   03 REG-D-NUM-SEQ-ARQ           PIC 9(006).*/
            public IntBasis REG_D_NUM_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   03 REG-D-NUM-SEQ-REG           PIC 9(006).*/
            public IntBasis REG_D_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   03 WS-FILLER                   PIC X(010).*/
            public StringBasis WS_FILLER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01 WS-REG-TRAILLER.*/
        }
        public VP1111B_WS_REG_TRAILLER WS_REG_TRAILLER { get; set; } = new VP1111B_WS_REG_TRAILLER();
        public class VP1111B_WS_REG_TRAILLER : VarBasis
        {
            /*"   03 REG-T-IDENTIFICA            PIC X(001).*/
            public StringBasis REG_T_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   03 REG-T-NOME-ARQ-T            PIC X(008).*/
            public StringBasis REG_T_NOME_ARQ_T { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   03 REG-T-QTDE-REG-1            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-2            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-3            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-4            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-5            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-6            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-7            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-8            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 REG-T-QTDE-REG-9            PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 FILLER                      PIC X(008) VALUE SPACES.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"   03 REG-T-QTDE-REG-TOTAL        PIC 9(008).*/
            public IntBasis REG_T_QTDE_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   03 FILLER                      PIC X(003) VALUE SPACES.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"01 WS-ERRO-DB2.*/
        }
        public VP1111B_WS_ERRO_DB2 WS_ERRO_DB2 { get; set; } = new VP1111B_WS_ERRO_DB2();
        public class VP1111B_WS_ERRO_DB2 : VarBasis
        {
            /*"   03 FILLER                PIC X(11)     VALUE      ' SQLCODE = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" SQLCODE = ");
            /*"   03 WS-SQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"   03 FILLER                PIC X(12)     VALUE      ' SQLCODE1 = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SQLCODE1 = ");
            /*"   03 WS-SQLCODE1           PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"   03 FILLER                PIC  X(12) VALUE      ' SQLCODE2 = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SQLCODE2 = ");
            /*"   03 WS-SQLCODE2           PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.EF150 EF150 { get; set; } = new Dclgens.EF150();
        public Dclgens.EF050 EF050 { get; set; } = new Dclgens.EF050();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.EF158 EF158 { get; set; } = new Dclgens.EF158();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EF064 EF064 { get; set; } = new Dclgens.EF064();
        public Dclgens.EF072 EF072 { get; set; } = new Dclgens.EF072();

        public VP1111B_CR_CANC_SIAS CR_CANC_SIAS { get; set; } = new VP1111B_CR_CANC_SIAS(false);
        string GetQuery_CR_CANC_SIAS()
        {
            var query = @$"SELECT T1.NUM_PROPOSTA_SIVPF
							, T2.TIMESTAMP
							FROM SEGUROS.PROPOSTA_FIDELIZ T1
							, SEGUROS.PROPOSTAS_VA T2 WHERE T2.TIMESTAMP > '2014-01-01 00:00:00.000000' AND T1.COD_USUARIO <> 'VP1111B' AND T1.NUM_PROPOSTA_SIVPF = T2.NUM_CERTIFICADO AND T1.SIT_PROPOSTA = 'CAN' AND T1.COD_PRODUTO_SIVPF = 77 AND T2.COD_PRODUTO IN (7705
							, 7707
							, 7713
							, 7715)";

            return query;
        }


        public VP1111B_CR_CANC_EFP CR_CANC_EFP { get; set; } = new VP1111B_CR_CANC_EFP(false);
        string GetQuery_CR_CANC_EFP()
        {
            var query = @$"SELECT T1.NUM_OCORR_MOVTO
							, T1.NUM_CONTRATO_SEGUR
							, T1.NOM_ARQUIVO
							, T1.NUM_CONTR_TERC
							, T1.NUM_APOLICE
							, T1.COD_PRODUTO
							, VALUE(T2.DTH_FIM_VIGENCIA
							, '0001-01-01')
							, T1.DTH_ATUALIZACAO
							FROM SEGUROS.EF_ENVIO_MOVTO_SAP T1
							, SEGUROS.EF_CONTRATO T2 WHERE T1.DTH_ATUALIZACAO > '2014-01-01 00:00:00.000000' AND T1.NOM_PROGRAMA <> 'VP1111B' AND T1.COD_PRODUTO IN (7705
							, 7716) AND T1.NUM_CONTRATO_SEGUR = T2.NUM_CONTRATO AND T2.STA_CONTRATO = 'C'";

            return query;
        }


        public VP1111B_CR_CANC_ARQ CR_CANC_ARQ { get; set; } = new VP1111B_CR_CANC_ARQ(true);
        string GetQuery_CR_CANC_ARQ()
        {
            var query = @$"SELECT ECS.NUM_CONTRATO
							,
							(SELECT  MIN(EPE3.DTH_ULT_MOVTO)
							FROM SEGUROS.EF_PREMIO_EMITIDO EPE3 WHERE EPE3.NUM_CONTRATO_SEGUR = ECS.NUM_CONTRATO AND EPE3.COD_PRODUTO = ECS.COD_PRODUTO AND EPE3.IND_TIPO_PREMIO = 2 ) AS DTA_CANCELAMENTO
							FROM SEGUROS.EF_CONTRATO_SEGURO ECS WHERE ECS.COD_PRODUTO IN (7705
							, 7716) AND ECS.DTH_CANCEL_SIGPF IS NULL AND EXISTS
							(SELECT  1
							FROM SEGUROS.EF_PREMIO_EMITIDO EPE WHERE EPE.NUM_CONTRATO_SEGUR = ECS.NUM_CONTRATO AND EPE.COD_PRODUTO = ECS.COD_PRODUTO AND EPE.IND_TIPO_PREMIO = 2 AND EPE.DTH_ULT_MOVTO BETWEEN '{WS_DT_INI}' AND '{WS_DT_FIM}' AND NOT EXISTS
							(SELECT  1
							FROM SEGUROS.EF_PREMIO_EMITIDO EPE2 WHERE EPE2.NUM_CONTRATO_SEGUR = EPE.NUM_CONTRATO_SEGUR AND EPE2.COD_PRODUTO = EPE.COD_PRODUTO AND EPE2.IND_TIPO_PREMIO = 1 AND EPE2.STA_PREMIO = 'A' ) )";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);
                InitializeGetQuery();

                /*" -240- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -241- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -242- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -246- PERFORM R10000-INICIALIZA THRU R10000-FIM. */

                R10000_INICIALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_FIM*/


                /*" -248- PERFORM R20000-PRINCIPAL THRU R20000-FIM. */

                R20000_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20000_FIM*/


                /*" -250- PERFORM R90000-FINALIZA THRU R90000-FIM. */

                R90000_FINALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R90000_FIM*/


                /*" -250- STOP RUN. */

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
            CR_CANC_SIAS.GetQueryEvent += GetQuery_CR_CANC_SIAS;
            CR_CANC_EFP.GetQueryEvent += GetQuery_CR_CANC_EFP;
            CR_CANC_ARQ.GetQueryEvent += GetQuery_CR_CANC_ARQ;
        }

        [StopWatch]
        /*" R10000-INICIALIZA */
        private void R10000_INICIALIZA(bool isPerform = false)
        {
            /*" -258- MOVE 'R10000' TO WS-LABEL */
            _.Move("R10000", WS_LABEL);

            /*" -266- DISPLAY 'VP1111B V2 - INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B V2 - INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -267- INITIALIZE WS-REG-HEADER */
            _.Initialize(
                WS_REG_HEADER
            );

            /*" -268- INITIALIZE WS-REG-DETALHE */
            _.Initialize(
                WS_REG_DETALHE
            );

            /*" -270- INITIALIZE WS-REG-TRAILLER */
            _.Initialize(
                WS_REG_TRAILLER
            );

            /*" -272- OPEN OUTPUT ARQSAIDA */
            ARQSAIDA.Open(REG_SAIDA01);

            /*" -274- PERFORM R10000_INICIALIZA_DB_SET_1 */

            R10000_INICIALIZA_DB_SET_1();

            /*" -277- MOVE WS-DATA-CORRENTE TO WS-DT-AUX */
            _.Move(WS_DATA_CORRENTE, WS_DT_AUX);

            /*" -278- MOVE 'H' TO REG-H-IDENTIFICA */
            _.Move("H", WS_REG_HEADER.REG_H_IDENTIFICA);

            /*" -279- MOVE 'STASASSE' TO REG-H-NOME-ARQ */
            _.Move("STASASSE", WS_REG_HEADER.REG_H_NOME_ARQ);

            /*" -280- MOVE WS-DIA-AUX TO REG-H-DD-GER */
            _.Move(WS_DT_AUX.WS_DIA_AUX, WS_REG_HEADER.REG_H_DATA_GER.REG_H_DD_GER);

            /*" -281- MOVE WS-MES-AUX TO REG-H-MM-GER */
            _.Move(WS_DT_AUX.WS_MES_AUX, WS_REG_HEADER.REG_H_DATA_GER.REG_H_MM_GER);

            /*" -282- MOVE WS-ANO-AUX TO REG-H-AA-GER */
            _.Move(WS_DT_AUX.WS_ANO_AUX, WS_REG_HEADER.REG_H_DATA_GER.REG_H_AA_GER);

            /*" -283- MOVE 4 TO REG-H-COD-SIST */
            _.Move(4, WS_REG_HEADER.REG_H_COD_SIST);

            /*" -284- MOVE 1 TO REG-H-COD-SIST-DEST */
            _.Move(1, WS_REG_HEADER.REG_H_COD_SIST_DEST);

            /*" -285- MOVE 1 TO REG-H-SEQ-ARQ */
            _.Move(1, WS_REG_HEADER.REG_H_SEQ_ARQ);

            /*" -287- MOVE SPACES TO REG-H-ESPACOS */
            _.Move("", WS_REG_HEADER.REG_H_ESPACOS);

            /*" -292- PERFORM R10000_INICIALIZA_DB_SELECT_1 */

            R10000_INICIALIZA_DB_SELECT_1();

            /*" -295- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -296- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -297- DISPLAY 'VP1111B - ERRO NO LER TABELA SISTEMAS' */
                _.Display($"VP1111B - ERRO NO LER TABELA SISTEMAS");

                /*" -298- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -298- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -300- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -301- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -304- END-IF */
            }


            /*" -312- PERFORM R10000_INICIALIZA_DB_SELECT_2 */

            R10000_INICIALIZA_DB_SELECT_2();

            /*" -313- . */

        }

        [StopWatch]
        /*" R10000-INICIALIZA-DB-SET-1 */
        public void R10000_INICIALIZA_DB_SET_1()
        {
            /*" -274- EXEC SQL SET :WS-DATA-CORRENTE = CURRENT DATE END-EXEC */
            _.Move(_.CurrentDate(), WS_DATA_CORRENTE);

        }

        [StopWatch]
        /*" R10000-INICIALIZA-DB-SELECT-1 */
        public void R10000_INICIALIZA_DB_SELECT_1()
        {
            /*" -292- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r10000_INICIALIZA_DB_SELECT_1_Query1 = new R10000_INICIALIZA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R10000_INICIALIZA_DB_SELECT_1_Query1.Execute(r10000_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_FIM*/

        [StopWatch]
        /*" R10000-INICIALIZA-DB-SELECT-2 */
        public void R10000_INICIALIZA_DB_SELECT_2()
        {
            /*" -312- EXEC SQL SELECT DATE(SUBSTR(CHAR(DATE(CURRENT DATE)),1,7) || '-01' ) , DATE(SUBSTR(CHAR(DATE(CURRENT DATE) + 1 MONTH),1,7)|| '-01' ) - 1 DAY INTO :WS-DT-INI, :WS-DT-FIM FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC */

            var r10000_INICIALIZA_DB_SELECT_2_Query1 = new R10000_INICIALIZA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R10000_INICIALIZA_DB_SELECT_2_Query1.Execute(r10000_INICIALIZA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DT_INI, WS_DT_INI);
                _.Move(executed_1.WS_DT_FIM, WS_DT_FIM);
            }


        }

        [StopWatch]
        /*" R20000-PRINCIPAL */
        private void R20000_PRINCIPAL(bool isPerform = false)
        {
            /*" -322- MOVE 'R20000' TO WS-LABEL */
            _.Move("R20000", WS_LABEL);

            /*" -324- MOVE SPACES TO WS-FIM-CERT-SIAS */
            _.Move("", WS_FIM_CERT_SIAS);

            /*" -332- DISPLAY 'VP1111B - INICIO DO OPEN CURSOR CR_CANC_SIAS: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - INICIO DO OPEN CURSOR CR_CANC_SIAS: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -332- PERFORM R20000_PRINCIPAL_DB_OPEN_1 */

            R20000_PRINCIPAL_DB_OPEN_1();

            /*" -342- DISPLAY 'VP1111B - FIM DO OPEN CURSOR CR_CANC_SIAS   : ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - FIM DO OPEN CURSOR CR_CANC_SIAS   : {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -343- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -344- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -345- DISPLAY 'VP1111B - ERRO NA ABERTURA CURSOR CR_CANC_SIAS' */
                _.Display($"VP1111B - ERRO NA ABERTURA CURSOR CR_CANC_SIAS");

                /*" -346- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -346- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -348- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -349- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -351- END-IF */
            }


            /*" -353- PERFORM R20100-LER-CERT-SIAS THRU R20100-FIM */

            R20100_LER_CERT_SIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20100_FIM*/


            /*" -354- IF WS-FIM-CERT-SIAS EQUAL 'SIM' */

            if (WS_FIM_CERT_SIAS == "SIM")
            {

                /*" -355- DISPLAY 'VP1111B - NAO ENCONTROU CERTIFICADO NO SIAS' */
                _.Display($"VP1111B - NAO ENCONTROU CERTIFICADO NO SIAS");

                /*" -357- END-IF */
            }


            /*" -360- PERFORM R20200-PROC-CERT-SIAS THRU R20200-FIM UNTIL WS-FIM-CERT-SIAS = 'SIM' */

            while (!(WS_FIM_CERT_SIAS == "SIM"))
            {

                R20200_PROC_CERT_SIAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20200_FIM*/

            }

            /*" -360- PERFORM R20000_PRINCIPAL_DB_CLOSE_1 */

            R20000_PRINCIPAL_DB_CLOSE_1();

            /*" -363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -364- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -365- DISPLAY 'VP1111B - ERRO NO CLOSE DO CURSOR CR_CANC_SIAS' */
                _.Display($"VP1111B - ERRO NO CLOSE DO CURSOR CR_CANC_SIAS");

                /*" -366- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -366- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -368- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -369- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -371- END-IF */
            }


            /*" -373- MOVE SPACES TO WS-FIM-CERT-EFP */
            _.Move("", WS_FIM_CERT_EFP);

            /*" -381- DISPLAY 'VP1111B - INICIO DO OPEN CURSOR CR_CANC_EFP : ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - INICIO DO OPEN CURSOR CR_CANC_EFP : {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -381- PERFORM R20000_PRINCIPAL_DB_OPEN_2 */

            R20000_PRINCIPAL_DB_OPEN_2();

            /*" -391- DISPLAY 'VP1111B - FIM DO OPEN CURSOR CR_CANC_EFP    : ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - FIM DO OPEN CURSOR CR_CANC_EFP    : {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -394- DISPLAY 'VP1111B - ERRO NA ABERTURA CURSOR CR_CANC_EFP ' */
                _.Display($"VP1111B - ERRO NA ABERTURA CURSOR CR_CANC_EFP ");

                /*" -395- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -395- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -397- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -398- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -400- END-IF */
            }


            /*" -402- PERFORM R20500-LER-CERT-EFP THRU R20500-FIM */

            R20500_LER_CERT_EFP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20500_FIM*/


            /*" -403- IF WS-FIM-CERT-EFP EQUAL 'SIM' */

            if (WS_FIM_CERT_EFP == "SIM")
            {

                /*" -404- DISPLAY 'VP1111B - NAO ENCONTROU CERTIFICADO NO EFP ' */
                _.Display($"VP1111B - NAO ENCONTROU CERTIFICADO NO EFP ");

                /*" -406- END-IF */
            }


            /*" -409- PERFORM R20600-PROC-CERT-EFP THRU R20600-FIM UNTIL WS-FIM-CERT-EFP = 'SIM' */

            while (!(WS_FIM_CERT_EFP == "SIM"))
            {

                R20600_PROC_CERT_EFP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20600_FIM*/

            }

            /*" -409- PERFORM R20000_PRINCIPAL_DB_CLOSE_2 */

            R20000_PRINCIPAL_DB_CLOSE_2();

            /*" -412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -413- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -414- DISPLAY 'VP1111B - ERRO NO CLOSE DO CURSOR CR_CANC_EFP ' */
                _.Display($"VP1111B - ERRO NO CLOSE DO CURSOR CR_CANC_EFP ");

                /*" -415- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -415- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -417- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -418- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -420- END-IF */
            }


            /*" -422- MOVE SPACES TO WS-FIM-CERT-ARQ */
            _.Move("", WS_FIM_CERT_ARQ);

            /*" -430- DISPLAY 'VP1111B - INICIO DO OPEN CURSOR CR_CANC_ARQ : ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - INICIO DO OPEN CURSOR CR_CANC_ARQ : {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -430- PERFORM R20000_PRINCIPAL_DB_OPEN_3 */

            R20000_PRINCIPAL_DB_OPEN_3();

            /*" -440- DISPLAY 'VP1111B - FIM DO OPEN CURSOR CR_CANC_ARQ    : ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - FIM DO OPEN CURSOR CR_CANC_ARQ    : {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -442- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -443- DISPLAY 'VP1111B - ERRO NA ABERTURA CURSOR CR_CANC_ARQ ' */
                _.Display($"VP1111B - ERRO NA ABERTURA CURSOR CR_CANC_ARQ ");

                /*" -444- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -444- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -446- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -447- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -449- END-IF */
            }


            /*" -451- PERFORM R21000-LER-CERT-ARQ THRU R21000-FIM */

            R21000_LER_CERT_ARQ(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R21000_FIM*/


            /*" -452- IF WS-FIM-CERT-ARQ EQUAL 'SIM' */

            if (WS_FIM_CERT_ARQ == "SIM")
            {

                /*" -454- DISPLAY 'VP1111B - NAO ENCONTROU CERTIFICADO NO EFP ' 'VP1111B - NAO ENCONTROU CERTIFICADO CANCELADO VIA ARQUIVO' */
                _.Display($"VP1111B - NAO ENCONTROU CERTIFICADO NO EFP VP1111B - NAO ENCONTROU CERTIFICADO CANCELADO VIA ARQUIVO");

                /*" -456- END-IF */
            }


            /*" -459- PERFORM R21100-PROC-CERT-ARQ THRU R21100-FIM UNTIL WS-FIM-CERT-ARQ = 'SIM' */

            while (!(WS_FIM_CERT_ARQ == "SIM"))
            {

                R21100_PROC_CERT_ARQ(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R21100_FIM*/

            }

            /*" -459- PERFORM R20000_PRINCIPAL_DB_CLOSE_3 */

            R20000_PRINCIPAL_DB_CLOSE_3();

            /*" -462- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -463- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -464- DISPLAY 'VP1111B - ERRO NO CLOSE DO CURSOR CR_CANC_ARQ ' */
                _.Display($"VP1111B - ERRO NO CLOSE DO CURSOR CR_CANC_ARQ ");

                /*" -465- DISPLAY 'VP1111B - SQLCODE = ' WS-SQLCODE */
                _.Display($"VP1111B - SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -465- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -467- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -468- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -470- END-IF */
            }


            /*" -471- IF WS-GRAVADOS > ZEROS */

            if (WS_GRAVADOS > 00)
            {

                /*" -472- MOVE 'T' TO REG-T-IDENTIFICA */
                _.Move("T", WS_REG_TRAILLER.REG_T_IDENTIFICA);

                /*" -473- MOVE 'STASASSE' TO REG-T-NOME-ARQ-T */
                _.Move("STASASSE", WS_REG_TRAILLER.REG_T_NOME_ARQ_T);

                /*" -474- MOVE WS-GRAVADOS TO REG-T-QTDE-REG-1 REG-T-QTDE-REG-TOTAL */
                _.Move(WS_GRAVADOS, WS_REG_TRAILLER.REG_T_QTDE_REG_1, WS_REG_TRAILLER.REG_T_QTDE_REG_TOTAL);

                /*" -478- MOVE ZEROS TO REG-T-QTDE-REG-2 REG-T-QTDE-REG-3 REG-T-QTDE-REG-4 REG-T-QTDE-REG-5 REG-T-QTDE-REG-7 REG-T-QTDE-REG-8 REG-T-QTDE-REG-9 */
                _.Move(0, WS_REG_TRAILLER.REG_T_QTDE_REG_2, WS_REG_TRAILLER.REG_T_QTDE_REG_3, WS_REG_TRAILLER.REG_T_QTDE_REG_4, WS_REG_TRAILLER.REG_T_QTDE_REG_5, WS_REG_TRAILLER.REG_T_QTDE_REG_7, WS_REG_TRAILLER.REG_T_QTDE_REG_8, WS_REG_TRAILLER.REG_T_QTDE_REG_9);

                /*" -479- WRITE REG-SAIDA01 FROM WS-REG-TRAILLER */
                _.Move(WS_REG_TRAILLER.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -481- END-IF */
            }


            /*" -481- . */

        }

        [StopWatch]
        /*" R20000-PRINCIPAL-DB-OPEN-1 */
        public void R20000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -332- EXEC SQL OPEN CR_CANC_SIAS END-EXEC */

            CR_CANC_SIAS.Open();

        }

        [StopWatch]
        /*" R20000-PRINCIPAL-DB-CLOSE-1 */
        public void R20000_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -360- EXEC SQL CLOSE CR_CANC_SIAS END-EXEC */

            CR_CANC_SIAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20000_FIM*/

        [StopWatch]
        /*" R20000-PRINCIPAL-DB-OPEN-2 */
        public void R20000_PRINCIPAL_DB_OPEN_2()
        {
            /*" -381- EXEC SQL OPEN CR_CANC_EFP END-EXEC */

            CR_CANC_EFP.Open();

        }

        [StopWatch]
        /*" R20000-PRINCIPAL-DB-CLOSE-2 */
        public void R20000_PRINCIPAL_DB_CLOSE_2()
        {
            /*" -409- EXEC SQL CLOSE CR_CANC_EFP END-EXEC */

            CR_CANC_EFP.Close();

        }

        [StopWatch]
        /*" R20100-LER-CERT-SIAS */
        private void R20100_LER_CERT_SIAS(bool isPerform = false)
        {
            /*" -488- MOVE 'R20100' TO WS-LABEL */
            _.Move("R20100", WS_LABEL);

            /*" -492- PERFORM R20100_LER_CERT_SIAS_DB_FETCH_1 */

            R20100_LER_CERT_SIAS_DB_FETCH_1();

            /*" -495- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -496- MOVE 'SIM' TO WS-FIM-CERT-SIAS */
                _.Move("SIM", WS_FIM_CERT_SIAS);

                /*" -497- ELSE */
            }
            else
            {


                /*" -498- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -499- ADD 1 TO WS-CERT-SIAS-LIDOS */
                    WS_CERT_SIAS_LIDOS.Value = WS_CERT_SIAS_LIDOS + 1;

                    /*" -500- ELSE */
                }
                else
                {


                    /*" -501- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                    /*" -503- DISPLAY 'VP1111B - ERRO LEITURA DO CERT-SIAS = ' WS-SQLCODE */
                    _.Display($"VP1111B - ERRO LEITURA DO CERT-SIAS = {WS_ERRO_DB2.WS_SQLCODE}");

                    /*" -505- DISPLAY 'VP1111B - QTD DE CERT-SIAS LIDOS    = ' WS-CERT-SIAS-LIDOS */
                    _.Display($"VP1111B - QTD DE CERT-SIAS LIDOS    = {WS_CERT_SIAS_LIDOS}");

                    /*" -506- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -506- EXEC SQL ROLLBACK WORK END-EXEC */

                    DatabaseConnection.Instance.RollbackTransaction();

                    /*" -508- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -509- END-IF */
                }


                /*" -510- END-IF */
            }


            /*" -510- . */

        }

        [StopWatch]
        /*" R20100-LER-CERT-SIAS-DB-FETCH-1 */
        public void R20100_LER_CERT_SIAS_DB_FETCH_1()
        {
            /*" -492- EXEC SQL FETCH CR_CANC_SIAS INTO :PROPOFID-NUM-PROPOSTA-SIVPF ,:PROPOVA-TIMESTAMP END-EXEC */

            if (CR_CANC_SIAS.Fetch())
            {
                _.Move(CR_CANC_SIAS.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(CR_CANC_SIAS.PROPOVA_TIMESTAMP, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R20000-PRINCIPAL-DB-OPEN-3 */
        public void R20000_PRINCIPAL_DB_OPEN_3()
        {
            /*" -430- EXEC SQL OPEN CR_CANC_ARQ END-EXEC */

            CR_CANC_ARQ.Open();

        }

        [StopWatch]
        /*" R20000-PRINCIPAL-DB-CLOSE-3 */
        public void R20000_PRINCIPAL_DB_CLOSE_3()
        {
            /*" -459- EXEC SQL CLOSE CR_CANC_ARQ END-EXEC */

            CR_CANC_ARQ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20100_FIM*/

        [StopWatch]
        /*" R20200-PROC-CERT-SIAS */
        private void R20200_PROC_CERT_SIAS(bool isPerform = false)
        {
            /*" -516- MOVE 'R20200' TO WS-LABEL */
            _.Move("R20200", WS_LABEL);

            /*" -518- PERFORM R20300-GRAVA-RELATORIO THRU R20300-FIM */

            R20300_GRAVA_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20300_FIM*/


            /*" -520- PERFORM R20400-UPDATE-FIDELIZ THRU R20400-FIM */

            R20400_UPDATE_FIDELIZ(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20400_FIM*/


            /*" -521- PERFORM R20100-LER-CERT-SIAS THRU R20100-FIM */

            R20100_LER_CERT_SIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20100_FIM*/


            /*" -521- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20200_FIM*/

        [StopWatch]
        /*" R20300-GRAVA-RELATORIO */
        private void R20300_GRAVA_RELATORIO(bool isPerform = false)
        {
            /*" -526- MOVE ZEROS TO REG-D-NUM-SEQ-ARQ */
            _.Move(0, WS_REG_DETALHE.REG_D_NUM_SEQ_ARQ);

            /*" -527- MOVE ZEROS TO REG-D-NUM-SEQ-REG */
            _.Move(0, WS_REG_DETALHE.REG_D_NUM_SEQ_REG);

            /*" -528- MOVE '1' TO REG-D-IDENTIFICA */
            _.Move("1", WS_REG_DETALHE.REG_D_IDENTIFICA);

            /*" -529- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO REG-D-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_REG_DETALHE.REG_D_NUM_PROPOSTA);

            /*" -530- MOVE 'CAN' TO REG-D-SIT-PROPOSTA */
            _.Move("CAN", WS_REG_DETALHE.REG_D_SIT_PROPOSTA);

            /*" -531- MOVE ZEROS TO REG-D-TIPO-MOTIVO */
            _.Move(0, WS_REG_DETALHE.REG_D_TIPO_MOTIVO);

            /*" -532- MOVE PROPOVA-TIMESTAMP TO WS-TIMESTAMP */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_TIMESTAMP, WS_TIMESTAMP);

            /*" -533- MOVE WS-DT-TIME TO WS-DT-AUX */
            _.Move(WS_TIMESTAMP.WS_DT_TIME, WS_DT_AUX);

            /*" -534- MOVE WS-DIA-AUX TO WS-DIA-CAN */
            _.Move(WS_DT_AUX.WS_DIA_AUX, WS_DT_CANCEL.WS_DIA_CAN);

            /*" -535- MOVE WS-MES-AUX TO WS-MES-CAN */
            _.Move(WS_DT_AUX.WS_MES_AUX, WS_DT_CANCEL.WS_MES_CAN);

            /*" -536- MOVE WS-ANO-AUX TO WS-ANO-CAN */
            _.Move(WS_DT_AUX.WS_ANO_AUX, WS_DT_CANCEL.WS_ANO_CAN);

            /*" -538- MOVE WS-DT-CANCEL TO REG-D-DATA-INICIO-SIT */
            _.Move(WS_DT_CANCEL, WS_REG_DETALHE.REG_D_DATA_INICIO_SIT);

            /*" -539- IF WS-GRAVADOS = ZEROS */

            if (WS_GRAVADOS == 00)
            {

                /*" -540- WRITE REG-SAIDA01 FROM WS-REG-HEADER */
                _.Move(WS_REG_HEADER.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -541- WRITE REG-SAIDA01 FROM WS-REG-DETALHE */
                _.Move(WS_REG_DETALHE.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -542- ELSE */
            }
            else
            {


                /*" -543- WRITE REG-SAIDA01 FROM WS-REG-DETALHE */
                _.Move(WS_REG_DETALHE.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -545- END-IF */
            }


            /*" -546- ADD 1 TO WS-GRAVADOS */
            WS_GRAVADOS.Value = WS_GRAVADOS + 1;

            /*" -546- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20300_FIM*/

        [StopWatch]
        /*" R20400-UPDATE-FIDELIZ */
        private void R20400_UPDATE_FIDELIZ(bool isPerform = false)
        {
            /*" -552- MOVE 'R20400' TO WS-LABEL */
            _.Move("R20400", WS_LABEL);

            /*" -556- PERFORM R20400_UPDATE_FIDELIZ_DB_UPDATE_1 */

            R20400_UPDATE_FIDELIZ_DB_UPDATE_1();

            /*" -559- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -560- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -561- DISPLAY 'VP1111B - ERRO UPDATE DA PROPOSTA_FIDELIZ' */
                _.Display($"VP1111B - ERRO UPDATE DA PROPOSTA_FIDELIZ");

                /*" -562- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -563- DISPLAY 'NUM_PROPOSTA_SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_PROPOSTA_SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -563- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -565- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -566- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -567- END-IF */
            }


            /*" -567- . */

        }

        [StopWatch]
        /*" R20400-UPDATE-FIDELIZ-DB-UPDATE-1 */
        public void R20400_UPDATE_FIDELIZ_DB_UPDATE_1()
        {
            /*" -556- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET COD_USUARIO = 'VP1111B' WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC */

            var r20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 = new R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1.Execute(r20400_UPDATE_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20400_FIM*/

        [StopWatch]
        /*" R20500-LER-CERT-EFP */
        private void R20500_LER_CERT_EFP(bool isPerform = false)
        {
            /*" -573- MOVE 'R20500' TO WS-LABEL */
            _.Move("R20500", WS_LABEL);

            /*" -583- PERFORM R20500_LER_CERT_EFP_DB_FETCH_1 */

            R20500_LER_CERT_EFP_DB_FETCH_1();

            /*" -586- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -587- MOVE 'SIM' TO WS-FIM-CERT-EFP */
                _.Move("SIM", WS_FIM_CERT_EFP);

                /*" -588- ELSE */
            }
            else
            {


                /*" -589- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -590- ADD 1 TO WS-CERT-EFP-LIDOS */
                    WS_CERT_EFP_LIDOS.Value = WS_CERT_EFP_LIDOS + 1;

                    /*" -591- ELSE */
                }
                else
                {


                    /*" -592- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                    /*" -593- DISPLAY 'VP1111B - ERRO LEITURA DO CERT-EFP' */
                    _.Display($"VP1111B - ERRO LEITURA DO CERT-EFP");

                    /*" -594- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                    /*" -596- DISPLAY 'VP1111B - QTD DE CERT-SIAS LIDOS    = ' WS-CERT-EFP-LIDOS */
                    _.Display($"VP1111B - QTD DE CERT-SIAS LIDOS    = {WS_CERT_EFP_LIDOS}");

                    /*" -596- EXEC SQL ROLLBACK WORK END-EXEC */

                    DatabaseConnection.Instance.RollbackTransaction();

                    /*" -598- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -599- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -600- END-IF */
                }


                /*" -601- END-IF */
            }


            /*" -601- . */

        }

        [StopWatch]
        /*" R20500-LER-CERT-EFP-DB-FETCH-1 */
        public void R20500_LER_CERT_EFP_DB_FETCH_1()
        {
            /*" -583- EXEC SQL FETCH CR_CANC_EFP INTO :EF150-NUM-OCORR-MOVTO, :EF150-NUM-CONTRATO-SEGUR, :EF150-NOM-ARQUIVO, :EF150-NUM-CONTR-TERC, :EF150-NUM-APOLICE, :EF150-COD-PRODUTO, :EF050-DTH-FIM-VIGENCIA, :EF150-DTH-ATUALIZACAO END-EXEC */

            if (CR_CANC_EFP.Fetch())
            {
                _.Move(CR_CANC_EFP.EF150_NUM_OCORR_MOVTO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO);
                _.Move(CR_CANC_EFP.EF150_NUM_CONTRATO_SEGUR, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTRATO_SEGUR);
                _.Move(CR_CANC_EFP.EF150_NOM_ARQUIVO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NOM_ARQUIVO);
                _.Move(CR_CANC_EFP.EF150_NUM_CONTR_TERC, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTR_TERC);
                _.Move(CR_CANC_EFP.EF150_NUM_APOLICE, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_APOLICE);
                _.Move(CR_CANC_EFP.EF150_COD_PRODUTO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_COD_PRODUTO);
                _.Move(CR_CANC_EFP.EF050_DTH_FIM_VIGENCIA, EF050.DCLEF_CONTRATO.EF050_DTH_FIM_VIGENCIA);
                _.Move(CR_CANC_EFP.EF150_DTH_ATUALIZACAO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_DTH_ATUALIZACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20500_FIM*/

        [StopWatch]
        /*" R20600-PROC-CERT-EFP */
        private void R20600_PROC_CERT_EFP(bool isPerform = false)
        {
            /*" -607- MOVE 'R20600' TO WS-LABEL */
            _.Move("R20600", WS_LABEL);

            /*" -609- PERFORM R20650-TRATA-NUM-PROPOSTA THRU R20650-FIM */

            R20650_TRATA_NUM_PROPOSTA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20650_FIM*/


            /*" -611- PERFORM R20700-GRAVA-RELATORIO THRU R20700-FIM */

            R20700_GRAVA_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20700_FIM*/


            /*" -613- PERFORM R20800-UPDATE-EF-SAP THRU R20800-FIM */

            R20800_UPDATE_EF_SAP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20800_FIM*/


            /*" -614- PERFORM R20500-LER-CERT-EFP THRU R20500-FIM */

            R20500_LER_CERT_EFP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20500_FIM*/


            /*" -614- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20600_FIM*/

        [StopWatch]
        /*" R20650-TRATA-NUM-PROPOSTA */
        private void R20650_TRATA_NUM_PROPOSTA(bool isPerform = false)
        {
            /*" -619- MOVE 'R20650' TO WS-LABEL */
            _.Move("R20650", WS_LABEL);

            /*" -620- MOVE EF150-NUM-CONTR-TERC TO EF158-NUM-CONTRATO-TERC */
            _.Move(EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTR_TERC, EF158.DCLEF_MATRICULA_INDICADOR.EF158_NUM_CONTRATO_TERC);

            /*" -621- MOVE EF150-NUM-CONTR-TERC TO WS-NUM-CONT-TERC */
            _.Move(EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTR_TERC, WS_NUM_CONT_TERC);

            /*" -623- MOVE ZEROS TO WS-NUM-PROPOSTA */
            _.Move(0, WS_NUM_PROPOSTA);

            /*" -630- PERFORM R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1 */

            R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1();

            /*" -633- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -634- MOVE EF158-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
                _.Move(EF158.DCLEF_MATRICULA_INDICADOR.EF158_NUM_PROPOSTA, WS_NUM_PROPOSTA);

                /*" -637- END-IF */
            }


            /*" -638- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -639- MOVE WS-NUM-CONT-TERC TO WS-NUM-TERC1 */
                _.Move(WS_NUM_CONT_TERC, WS_NUM_TERC1);

                /*" -640- MOVE WS-CANAL-TERC1 TO WS-CANAL-TERC2 */
                _.Move(WS_NUM_TERC1.WS_CANAL_TERC1, WS_NUM_TERC2.WS_CANAL_TERC2);

                /*" -641- MOVE WS-AGENCIA-TERC1 TO WS-AGENCIA-TERC2 */
                _.Move(WS_NUM_TERC1.WS_AGENCIA_TERC1, WS_NUM_TERC2.WS_AGENCIA_TERC2);

                /*" -642- MOVE WS-SEQ-TERC1 TO WS-SEQ-TERC2 */
                _.Move(WS_NUM_TERC1.WS_SEQ_TERC1, WS_NUM_TERC2.WS_SEQ_TERC2);

                /*" -643- MOVE 77 TO WS-RAMO-TERC2 */
                _.Move(77, WS_NUM_TERC2.WS_RAMO_TERC2);

                /*" -644- MOVE WS-NUM-TERC2 TO WS-NUM-PROPOSTA */
                _.Move(WS_NUM_TERC2, WS_NUM_PROPOSTA);

                /*" -646- END-IF */
            }


            /*" -647- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -648- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -649- DISPLAY 'VP1111B - ERRO LEITURA EF_MATRICULA_INDICADOR' */
                _.Display($"VP1111B - ERRO LEITURA EF_MATRICULA_INDICADOR");

                /*" -650- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -651- DISPLAY 'NUM_CONTRATO_TERC = ' EF158-NUM-CONTRATO-TERC */
                _.Display($"NUM_CONTRATO_TERC = {EF158.DCLEF_MATRICULA_INDICADOR.EF158_NUM_CONTRATO_TERC}");

                /*" -651- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -653- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -654- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -655- END-IF */
            }


            /*" -655- . */

        }

        [StopWatch]
        /*" R20650-TRATA-NUM-PROPOSTA-DB-SELECT-1 */
        public void R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1()
        {
            /*" -630- EXEC SQL SELECT NUM_PROPOSTA INTO :EF158-NUM-PROPOSTA FROM SEGUROS.EF_MATRICULA_INDICADOR WHERE NUM_CONTRATO_TERC = :EF158-NUM-CONTRATO-TERC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1 = new R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1()
            {
                EF158_NUM_CONTRATO_TERC = EF158.DCLEF_MATRICULA_INDICADOR.EF158_NUM_CONTRATO_TERC.ToString(),
            };

            var executed_1 = R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1.Execute(r20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF158_NUM_PROPOSTA, EF158.DCLEF_MATRICULA_INDICADOR.EF158_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20650_FIM*/

        [StopWatch]
        /*" R20700-GRAVA-RELATORIO */
        private void R20700_GRAVA_RELATORIO(bool isPerform = false)
        {
            /*" -660- MOVE ZEROS TO REG-D-NUM-SEQ-ARQ */
            _.Move(0, WS_REG_DETALHE.REG_D_NUM_SEQ_ARQ);

            /*" -661- MOVE ZEROS TO REG-D-NUM-SEQ-REG */
            _.Move(0, WS_REG_DETALHE.REG_D_NUM_SEQ_REG);

            /*" -662- MOVE '1' TO REG-D-IDENTIFICA */
            _.Move("1", WS_REG_DETALHE.REG_D_IDENTIFICA);

            /*" -663- MOVE WS-NUM-PROPOSTA TO REG-D-NUM-PROPOSTA */
            _.Move(WS_NUM_PROPOSTA, WS_REG_DETALHE.REG_D_NUM_PROPOSTA);

            /*" -664- MOVE 'CAN' TO REG-D-SIT-PROPOSTA */
            _.Move("CAN", WS_REG_DETALHE.REG_D_SIT_PROPOSTA);

            /*" -665- MOVE ZEROS TO REG-D-TIPO-MOTIVO */
            _.Move(0, WS_REG_DETALHE.REG_D_TIPO_MOTIVO);

            /*" -666- IF EF050-DTH-FIM-VIGENCIA = '0001-01-01' */

            if (EF050.DCLEF_CONTRATO.EF050_DTH_FIM_VIGENCIA == "0001-01-01")
            {

                /*" -667- MOVE EF150-DTH-ATUALIZACAO TO WS-TIMESTAMP2 */
                _.Move(EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_DTH_ATUALIZACAO, WS_TIMESTAMP2);

                /*" -668- MOVE WS-DT-TIME2 TO EF050-DTH-FIM-VIGENCIA */
                _.Move(WS_TIMESTAMP2.WS_DT_TIME2, EF050.DCLEF_CONTRATO.EF050_DTH_FIM_VIGENCIA);

                /*" -669- END-IF */
            }


            /*" -670- MOVE EF050-DTH-FIM-VIGENCIA TO WS-DT-AUX */
            _.Move(EF050.DCLEF_CONTRATO.EF050_DTH_FIM_VIGENCIA, WS_DT_AUX);

            /*" -671- MOVE WS-DIA-AUX TO WS-DIA-CAN */
            _.Move(WS_DT_AUX.WS_DIA_AUX, WS_DT_CANCEL.WS_DIA_CAN);

            /*" -672- MOVE WS-MES-AUX TO WS-MES-CAN */
            _.Move(WS_DT_AUX.WS_MES_AUX, WS_DT_CANCEL.WS_MES_CAN);

            /*" -673- MOVE WS-ANO-AUX TO WS-ANO-CAN */
            _.Move(WS_DT_AUX.WS_ANO_AUX, WS_DT_CANCEL.WS_ANO_CAN);

            /*" -675- MOVE WS-DT-CANCEL TO REG-D-DATA-INICIO-SIT */
            _.Move(WS_DT_CANCEL, WS_REG_DETALHE.REG_D_DATA_INICIO_SIT);

            /*" -676- IF WS-GRAVADOS = ZEROS */

            if (WS_GRAVADOS == 00)
            {

                /*" -677- WRITE REG-SAIDA01 FROM WS-REG-HEADER */
                _.Move(WS_REG_HEADER.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -678- WRITE REG-SAIDA01 FROM WS-REG-DETALHE */
                _.Move(WS_REG_DETALHE.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -679- ELSE */
            }
            else
            {


                /*" -680- WRITE REG-SAIDA01 FROM WS-REG-DETALHE */
                _.Move(WS_REG_DETALHE.GetMoveValues(), REG_SAIDA01);

                ARQSAIDA.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -682- END-IF */
            }


            /*" -683- ADD 1 TO WS-GRAVADOS */
            WS_GRAVADOS.Value = WS_GRAVADOS + 1;

            /*" -683- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20700_FIM*/

        [StopWatch]
        /*" R20800-UPDATE-EF-SAP */
        private void R20800_UPDATE_EF_SAP(bool isPerform = false)
        {
            /*" -689- MOVE 'R20800' TO WS-LABEL */
            _.Move("R20800", WS_LABEL);

            /*" -694- PERFORM R20800_UPDATE_EF_SAP_DB_UPDATE_1 */

            R20800_UPDATE_EF_SAP_DB_UPDATE_1();

            /*" -698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -699- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -700- DISPLAY 'VP1111B - ERRO UPDATE DA EF_ENVIO_MOVTO_SAP' */
                _.Display($"VP1111B - ERRO UPDATE DA EF_ENVIO_MOVTO_SAP");

                /*" -701- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -702- DISPLAY 'NUM_OCORR_MOVTO    = ' EF150-NUM-OCORR-MOVTO */
                _.Display($"NUM_OCORR_MOVTO    = {EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO}");

                /*" -703- DISPLAY 'NUM_CONTRATO_SEGUR = ' EF150-NUM-CONTRATO-SEGUR */
                _.Display($"NUM_CONTRATO_SEGUR = {EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTRATO_SEGUR}");

                /*" -703- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -705- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -706- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -707- END-IF */
            }


            /*" -707- . */

        }

        [StopWatch]
        /*" R20800-UPDATE-EF-SAP-DB-UPDATE-1 */
        public void R20800_UPDATE_EF_SAP_DB_UPDATE_1()
        {
            /*" -694- EXEC SQL UPDATE SEGUROS.EF_ENVIO_MOVTO_SAP SET NOM_PROGRAMA= 'VP1111B' WHERE NUM_OCORR_MOVTO = :EF150-NUM-OCORR-MOVTO AND NUM_CONTRATO_SEGUR = :EF150-NUM-CONTRATO-SEGUR END-EXEC */

            var r20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1 = new R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1()
            {
                EF150_NUM_CONTRATO_SEGUR = EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTRATO_SEGUR.ToString(),
                EF150_NUM_OCORR_MOVTO = EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO.ToString(),
            };

            R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1.Execute(r20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20800_FIM*/

        [StopWatch]
        /*" R21000-LER-CERT-ARQ */
        private void R21000_LER_CERT_ARQ(bool isPerform = false)
        {
            /*" -713- MOVE 'R21000' TO WS-LABEL */
            _.Move("R21000", WS_LABEL);

            /*" -717- PERFORM R21000_LER_CERT_ARQ_DB_FETCH_1 */

            R21000_LER_CERT_ARQ_DB_FETCH_1();

            /*" -720- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -721- MOVE 'SIM' TO WS-FIM-CERT-ARQ */
                _.Move("SIM", WS_FIM_CERT_ARQ);

                /*" -722- ELSE */
            }
            else
            {


                /*" -723- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -724- ADD 1 TO WS-CERT-ARQ-LIDOS */
                    WS_CERT_ARQ_LIDOS.Value = WS_CERT_ARQ_LIDOS + 1;

                    /*" -725- ELSE */
                }
                else
                {


                    /*" -726- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                    /*" -728- DISPLAY 'VP1111B - ERRO LEITURA DO CERT-ARQ  = ' WS-SQLCODE */
                    _.Display($"VP1111B - ERRO LEITURA DO CERT-ARQ  = {WS_ERRO_DB2.WS_SQLCODE}");

                    /*" -730- DISPLAY 'VP1111B - QTD DE CERT-ARQ  LIDOS    = ' WS-CERT-ARQ-LIDOS */
                    _.Display($"VP1111B - QTD DE CERT-ARQ  LIDOS    = {WS_CERT_ARQ_LIDOS}");

                    /*" -731- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -731- EXEC SQL ROLLBACK WORK END-EXEC */

                    DatabaseConnection.Instance.RollbackTransaction();

                    /*" -733- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -734- END-IF */
                }


                /*" -735- END-IF */
            }


            /*" -735- . */

        }

        [StopWatch]
        /*" R21000-LER-CERT-ARQ-DB-FETCH-1 */
        public void R21000_LER_CERT_ARQ_DB_FETCH_1()
        {
            /*" -717- EXEC SQL FETCH CR_CANC_ARQ INTO :EF064-NUM-CONTRATO ,:WS-DATA-CANCEL END-EXEC */

            if (CR_CANC_ARQ.Fetch())
            {
                _.Move(CR_CANC_ARQ.EF064_NUM_CONTRATO, EF064.DCLEF_CONTRATO_SEGURO.EF064_NUM_CONTRATO);
                _.Move(CR_CANC_ARQ.WS_DATA_CANCEL, WS_DATA_CANCEL);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R21000_FIM*/

        [StopWatch]
        /*" R21100-PROC-CERT-ARQ */
        private void R21100_PROC_CERT_ARQ(bool isPerform = false)
        {
            /*" -740- MOVE 'R21100' TO WS-LABEL */
            _.Move("R21100", WS_LABEL);

            /*" -742- MOVE 'R21100' TO WS-LABEL */
            _.Move("R21100", WS_LABEL);

            /*" -744- PERFORM R21110-PEGAR-NUM-CONT-TERC THRU R21110-FIM */

            R21110_PEGAR_NUM_CONT_TERC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R21110_FIM*/


            /*" -746- PERFORM R20650-TRATA-NUM-PROPOSTA THRU R20650-FIM */

            R20650_TRATA_NUM_PROPOSTA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20650_FIM*/


            /*" -748- MOVE WS-DATA-CANCEL TO EF050-DTH-FIM-VIGENCIA */
            _.Move(WS_DATA_CANCEL, EF050.DCLEF_CONTRATO.EF050_DTH_FIM_VIGENCIA);

            /*" -750- PERFORM R20700-GRAVA-RELATORIO THRU R20700-FIM */

            R20700_GRAVA_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R20700_FIM*/


            /*" -752- PERFORM R21120-UPDATE-EF-ENVIO THRU R21120-FIM */

            R21120_UPDATE_EF_ENVIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R21120_FIM*/


            /*" -753- PERFORM R21000-LER-CERT-ARQ THRU R21000-FIM */

            R21000_LER_CERT_ARQ(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R21000_FIM*/


            /*" -753- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R21100_FIM*/

        [StopWatch]
        /*" R21110-PEGAR-NUM-CONT-TERC */
        private void R21110_PEGAR_NUM_CONT_TERC(bool isPerform = false)
        {
            /*" -758- MOVE 'R21110' TO WS-LABEL */
            _.Move("R21110", WS_LABEL);

            /*" -760- MOVE EF064-NUM-CONTRATO TO EF072-NUM-CONTRATO */
            _.Move(EF064.DCLEF_CONTRATO_SEGURO.EF064_NUM_CONTRATO, EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO);

            /*" -767- PERFORM R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1 */

            R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1();

            /*" -770- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -771- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -772- DISPLAY 'VP1111B - ERRO SELECT EF_CONTR_SEG_HABIT' */
                _.Display($"VP1111B - ERRO SELECT EF_CONTR_SEG_HABIT");

                /*" -773- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -774- DISPLAY 'NOM_ARQUIVO  = EF001' */
                _.Display($"NOM_ARQUIVO  = EF001");

                /*" -775- DISPLAY 'NUM_CONTRATO = ' EF072-NUM-CONTRATO */
                _.Display($"NUM_CONTRATO = {EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO}");

                /*" -776- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -776- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -778- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -779- END-IF */
            }


            /*" -779- . */

        }

        [StopWatch]
        /*" R21110-PEGAR-NUM-CONT-TERC-DB-SELECT-1 */
        public void R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1()
        {
            /*" -767- EXEC SQL SELECT NUM_CONTRATO_TERC INTO :EF150-NUM-CONTR-TERC FROM SEGUROS.EF_CONTR_SEG_HABIT WHERE NOM_ARQUIVO = 'EF001' AND NUM_CONTRATO = :EF072-NUM-CONTRATO WITH UR END-EXEC */

            var r21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1 = new R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1.Execute(r21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF150_NUM_CONTR_TERC, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTR_TERC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R21110_FIM*/

        [StopWatch]
        /*" R21120-UPDATE-EF-ENVIO */
        private void R21120_UPDATE_EF_ENVIO(bool isPerform = false)
        {
            /*" -785- MOVE 'R21120' TO WS-LABEL */
            _.Move("R21120", WS_LABEL);

            /*" -789- PERFORM R21120_UPDATE_EF_ENVIO_DB_UPDATE_1 */

            R21120_UPDATE_EF_ENVIO_DB_UPDATE_1();

            /*" -793- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -794- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_ERRO_DB2.WS_SQLCODE);

                /*" -795- DISPLAY 'VP1111B - ERRO UPDATE DA EF_CONTRATO_SEGURO' */
                _.Display($"VP1111B - ERRO UPDATE DA EF_CONTRATO_SEGURO");

                /*" -796- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_ERRO_DB2.WS_SQLCODE}");

                /*" -797- DISPLAY 'NUM_CONTRATO  = ' EF064-NUM-CONTRATO */
                _.Display($"NUM_CONTRATO  = {EF064.DCLEF_CONTRATO_SEGURO.EF064_NUM_CONTRATO}");

                /*" -797- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -799- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -800- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -801- END-IF */
            }


            /*" -802- . */

            /*" -802- . */

        }

        [StopWatch]
        /*" R21120-UPDATE-EF-ENVIO-DB-UPDATE-1 */
        public void R21120_UPDATE_EF_ENVIO_DB_UPDATE_1()
        {
            /*" -789- EXEC SQL UPDATE SEGUROS.EF_CONTRATO_SEGURO SET DTH_CANCEL_SIGPF = CURRENT TIMESTAMP WHERE NUM_CONTRATO = :EF064-NUM-CONTRATO END-EXEC */

            var r21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1 = new R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1()
            {
                EF064_NUM_CONTRATO = EF064.DCLEF_CONTRATO_SEGURO.EF064_NUM_CONTRATO.ToString(),
            };

            R21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1.Execute(r21120_UPDATE_EF_ENVIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R21120_FIM*/

        [StopWatch]
        /*" R90000-FINALIZA */
        private void R90000_FINALIZA(bool isPerform = false)
        {
            /*" -808- MOVE 'R90000' TO WS-LABEL */
            _.Move("R90000", WS_LABEL);

            /*" -810- CLOSE ARQSAIDA */
            ARQSAIDA.Close();

            /*" -811- DISPLAY 'VP1111B -------------------------------------------' */
            _.Display($"VP1111B -------------------------------------------");

            /*" -813- DISPLAY 'VP1111B - CONTRATO-CANCEL-SIAS LIDOS    = ' WS-CERT-SIAS-LIDOS */
            _.Display($"VP1111B - CONTRATO-CANCEL-SIAS LIDOS    = {WS_CERT_SIAS_LIDOS}");

            /*" -815- DISPLAY 'VP1111B - CONTRATO-CANCEL-EFP  LIDOS    = ' WS-CERT-EFP-LIDOS */
            _.Display($"VP1111B - CONTRATO-CANCEL-EFP  LIDOS    = {WS_CERT_EFP_LIDOS}");

            /*" -817- DISPLAY 'VP1111B - CONTRATO-CANCEL-EFP/ARQ LIDOS = ' WS-CERT-ARQ-LIDOS */
            _.Display($"VP1111B - CONTRATO-CANCEL-EFP/ARQ LIDOS = {WS_CERT_ARQ_LIDOS}");

            /*" -819- DISPLAY 'VP1111B - CONTRATOS GRAVADOS            = ' WS-GRAVADOS */
            _.Display($"VP1111B - CONTRATOS GRAVADOS            = {WS_GRAVADOS}");

            /*" -821- DISPLAY 'VP1111B -------------------------------------------' */
            _.Display($"VP1111B -------------------------------------------");

            /*" -822- DISPLAY ' ' */
            _.Display($" ");

            /*" -829- DISPLAY 'VP1111B - FIM PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP1111B - FIM PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -829- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R90000_FIM*/
    }
}