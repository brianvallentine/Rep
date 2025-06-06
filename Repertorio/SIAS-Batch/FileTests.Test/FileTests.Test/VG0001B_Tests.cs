using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.VG0001B;

namespace FileTests.Test
{
    [Collection("VG0001B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0001B_Tests
    {

        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_ANTERIOR" , ""},
                { "SISTEMAS_DATA_MOV_6MONTH" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0001B_CSOLICITA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_DATA_SOLICITACAO" , ""},
                { "VGSOLFAT_DIA_DEBITO" , ""},
                { "VGSOLFAT_OPCAOPAG" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "VGSOLFAT_CAP_BAS_SEGURADO" , ""},
                { "VGSOLFAT_PRM_VG" , "1"},
                { "VGSOLFAT_PRM_AP" , ""},
                { "VGSOLFAT_PRM_TOTAL" , ""},
                { "VGSOLFAT_DTVENCTO_FATURA" , ""},
                { "VGSOLFAT_COD_FONTE" , ""},
                { "VGSOLFAT_NUM_TITULO" , ""},
                { "VGSOLFAT_DT_QUITBCO_TITULO" , ""},
                { "VGSOLFAT_VALOR_TITULO" , ""},
                { "VGSOLFAT_AGECTADEB" , ""},
                { "VGSOLFAT_OPRCTADEB" , ""},
                { "VGSOLFAT_NUMCTADEB" , ""},
                { "VGSOLFAT_DIGCTADEB" , ""},
                { "VGSOLFAT_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0001B_CSOLICITA", q1);

            #endregion

            #region VG0001B_V1RCAPCOMP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_HORA_OPERACAO" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0001B_V1RCAPCOMP", q2);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                { "SUBGVGAP_AGE_COBRANCA" , ""},
                { "SUBGVGAP_OPCAO_COBERTURA" , ""},
                { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                { "SUBGVGAP_TIPO_SUBGRUPO" , ""},
                { "SUBGVGAP_IND_IOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1000_UPDATE_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_SIT_SOLICITA" , ""},
                { "SISTEMAS_DATA_MOV_6MONTH" , ""},
                { "JVPRD8205" , ""},
                { "JVPRD8209" , ""},
                { "JVPRD9329" , ""},
                { "JVPRD9343" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_UPDATE_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1", q6);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1", q7);

            #endregion

            #region M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_AUX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1", q9);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "TERMOADE_COD_AGENCIA_VEN" , ""},
                { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                { "TERMOADE_NUM_CONTA_VEN" , ""},
                { "TERMOADE_DIG_CONTA_VEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1", q10);

            #endregion

            #region M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""},
                { "VGCOMTRO_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1", q12);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1", q13);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "VGFUNCOB_VLR_PREMIO" , ""},
                { "VGFUNCOB_IMP_SEGURADA" , ""},
                { "VGFUNCOB_QTD_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1", q15);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q16);

            #endregion

            #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q17);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_COMPRA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1", q18);

            #endregion

            #region VG0001B_CPROPOVACRT

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "VGSOLFAT_NUM_TITULO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "VGSOLFAT_PRM_VG" , ""},
                { "VGSOLFAT_PRM_AP" , ""},
                { "VGSOLFAT_PRM_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0001B_CPROPOVACRT", q19);

            #endregion

            #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1", q20);

            #endregion

            #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_HORA_OPERACAO" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q21);

            #endregion

            #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q22);

            #endregion

            #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q23);

            #endregion

            #region M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1", q25);

            #endregion

            #region M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1", q26);

            #endregion

            #region M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1", q27);

            #endregion

            #region M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1", q28);

            #endregion

            #region M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "H_NUM_CERTIFICADO" , ""},
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1", q29);

            #endregion

            #region M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , ""},
                { "VGPROSIA_COD_PRODUTO_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_2000_INSERT_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "TERMOADE_COD_AGENCIA_VEN" , ""},
                { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                { "TERMOADE_NUM_CONTA_VEN" , ""},
                { "TERMOADE_DIG_CONTA_VEN" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "WHOST_FAIXA_RENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INSERT_DB_INSERT_1_Insert1", q31);

            #endregion

            #region M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "VGSOLFAT_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q32);

            #endregion

            #region M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q33);

            #endregion

            #region M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "PARCEVID_OPCAO_PAGAMENTO" , ""},
                { "PARCEVID_SIT_REGISTRO" , ""},
                { "PARCEVID_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1", q34);

            #endregion

            #region M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "WS_DTVENC_1PARC" , ""},
                { "COBHISVI_PRM_TOTAL" , ""},
                { "PARCEVID_OPCAO_PAGAMENTO" , ""},
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_OCORR_HISTORICO" , ""},
                { "COBHISVI_BCO_AVISO" , ""},
                { "COBHISVI_AGE_AVISO" , ""},
                { "COBHISVI_NUM_AVISO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q35);

            #endregion

            #region M_2700_NUM_TITULO_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2700_NUM_TITULO_DB_SELECT_1_Query1", q36);

            #endregion

            #region M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1", q37);

            #endregion

            #region M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "COBHISVI_PRM_TOTAL" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_TIPLANC" , ""},
                { "HISLANCT_OCORR_HISTORICO" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "HISLANCT_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1", q38);

            #endregion

            #region M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_FATURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1", q39);

            #endregion

            #region M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "VGSOLFAT_NUM_APOLICE" , ""},
                { "VGSOLFAT_COD_SUBGRUPO" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "HISCONPA_DTFATUR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q40);

            #endregion

            #region M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_ENDOSSO" , ""},
                { "FATURAS_DATA_FATURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1", q41);

            #endregion

            #region M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "CONVEVG_NUM_APOLICE" , ""},
                { "CONVEVG_CODSUBES" , ""},
                { "CONVEVG_COD_SEGURO" , ""},
                { "CONVEVG_COD_AJUSTE" , ""},
                { "CONVEVG_COD_COMISSAO" , ""},
                { "CONVEVG_COD_NAOACEITE" , ""},
                { "CONVEVG_CODUSU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1", q42);

            #endregion

            #region M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1", q43);

            #endregion

            #region M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "VGCOBTER_COD_GARANTIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1", q44);

            #endregion

            #region M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NUM_APOLICE" , ""},
                { "PRODUVG_COD_SUBGRUPO" , ""},
                { "PRODUVG_ID_SISTEMA" , ""},
                { "PRODUVG_COD_PRODUTO_AZUL" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUVG_DIAS_INICIO_VIGENC" , ""},
                { "PRODUVG_DATA_MINVIGENCIA" , ""},
                { "PRODUVG_DATA_MAXVIGENCIA" , ""},
                { "PRODUVG_SIT_PLANO_CEF" , ""},
                { "PRODUVG_OPCAO_PAGAMENTO" , ""},
                { "PRODUVG_COD_CEDENTE" , ""},
                { "PRODUVG_OPC_AGENCTO_SUREG" , ""},
                { "PRODUVG_OPCAO_CAPITALIZ" , ""},
                { "PRODUVG_COD_SERIE" , ""},
                { "PRODUVG_NUM_SEQ_TITULO" , ""},
                { "PRODUVG_NUM_MALA_DIRETA" , ""},
                { "PRODUVG_RAMO" , ""},
                { "PRODUVG_CANCELA_ANTIGO" , ""},
                { "PRODUVG_TEM_CDG" , ""},
                { "PRODUVG_TEM_SAF" , ""},
                { "PRODUVG_DIA_FATURA" , ""},
                { "PRODUVG_ESTR_COBR" , ""},
                { "PRODUVG_ESTR_EMISS" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
                { "PRODUVG_CODRELAT" , ""},
                { "PRODUVG_ROT_SAF" , ""},
                { "PRODUVG_COD_PRODUTO_EA" , ""},
                { "PRODUVG_COBERADIC_PREMIO" , ""},
                { "PRODUVG_CUSTOCAP_TOTAL" , ""},
                { "PRODUVG_DESCONTO_ADESAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1", q45);

            #endregion

            #region M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "VGCOBTER_COD_GARANTIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1", q46);

            #endregion

            #region M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1", q47);

            #endregion

            #region M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1", q48);

            #endregion

            #region M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_COBERTURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1", q49);

            #endregion

            #region M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_COD_OPERACAO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1", q50);

            #endregion

            #region M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                { "SUBGVGAP_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1", q51);

            #endregion

            #region M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "WS_INIVIGENCIA" , ""},
                { "WS_TERVIGENCIA" , ""},
                { "SUBGVGAP_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1", q52);

            #endregion

            #region M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "WS_INIVIGENCIA" , ""},
                { "WS_TERVIGENCIA" , ""},
                { "SUBGVGAP_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1", q53);

            #endregion

            #region M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "WS_CNT_SEGURADOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1", q54);

            #endregion

            #region M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1", q55);

            #endregion

            #region M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "WS_INIVIGENCIA" , ""},
                { "WS_TERVIGENCIA" , ""},
                { "SEGVGAP_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1", q56);

            #endregion

            #region M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1", q57);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0001B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SISTEMAS_DATA_ANTERIOR" , ""},
                    { "SISTEMAS_DATA_MOV_6MONTH" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region VG0001B_CSOLICITA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "VGSOLFAT_NUM_APOLICE" , ""},
                    { "VGSOLFAT_COD_SUBGRUPO" , ""},
                    { "VGSOLFAT_DATA_SOLICITACAO" , ""},
                    { "VGSOLFAT_DIA_DEBITO" , ""},
                    { "VGSOLFAT_OPCAOPAG" , ""},
                    { "VGSOLFAT_QUANT_VIDAS" , "1"},
                    { "VGSOLFAT_CAP_BAS_SEGURADO" , "1"},
                    { "VGSOLFAT_PRM_VG" , "1"},
                    { "VGSOLFAT_PRM_AP" , ""},
                    { "VGSOLFAT_PRM_TOTAL" , ""},
                    { "VGSOLFAT_DTVENCTO_FATURA" , ""},
                    { "VGSOLFAT_COD_FONTE" , ""},
                    { "VGSOLFAT_NUM_TITULO" , ""},
                    { "VGSOLFAT_DT_QUITBCO_TITULO" , ""},
                    { "VGSOLFAT_VALOR_TITULO" , ""},
                    { "VGSOLFAT_AGECTADEB" , ""},
                    { "VGSOLFAT_OPRCTADEB" , ""},
                    { "VGSOLFAT_NUMCTADEB" , ""},
                    { "VGSOLFAT_DIGCTADEB" , ""},
                    { "VGSOLFAT_COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0001B_CSOLICITA");
                AppSettings.TestSet.DynamicData.Add("VG0001B_CSOLICITA", q1);

                #endregion

                #region VG0001B_V1RCAPCOMP

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_COD_FONTE" , ""},
                    { "RCAPCOMP_NUM_RCAP" , ""},
                    { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                    { "RCAPCOMP_COD_OPERACAO" , ""},
                    { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                    { "RCAPCOMP_HORA_OPERACAO" , ""},
                    { "RCAPCOMP_SIT_REGISTRO" , ""},
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_VAL_RCAP" , ""},
                    { "RCAPCOMP_DATA_RCAP" , ""},
                    { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                    { "RCAPCOMP_SIT_CONTABIL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0001B_V1RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VG0001B_V1RCAPCOMP", q2);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SUBGVGAP_COD_FONTE" , ""},
                    { "SUBGVGAP_COD_CLIENTE" , ""},
                    { "SUBGVGAP_OCORR_ENDERECO" , ""},
                    { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                    { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                    { "SUBGVGAP_AGE_COBRANCA" , ""},
                    { "SUBGVGAP_OPCAO_COBERTURA" , ""},
                    { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                    { "SUBGVGAP_TIPO_SUBGRUPO" , ""},
                    { "SUBGVGAP_IND_IOF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_1000_UPDATE_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "VGSOLFAT_SIT_SOLICITA" , ""},
                    { "SISTEMAS_DATA_MOV_6MONTH" , ""},
                    { "JVPRD8205" , ""},
                    { "JVPRD8209" , ""},
                    { "JVPRD9329" , ""},
                    { "JVPRD9343" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_UPDATE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1000_UPDATE_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "ENDOSSOS_COD_PRODUTO" , ""},
                    { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                    { "ENDOSSOS_OCORR_ENDERECO" , ""},
                    { "ENDOSSOS_NUM_PROPOSTA" , ""},
                    { "ENDOSSOS_AGE_COBRANCA" , ""},
                    { "ENDOSSOS_RAMO_EMISSOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1
                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1", q6);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , ""},
                    { "CLIENTES_CGCCPF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1", q7);

                #endregion

                #region M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "WS_DATA_AUX" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "VGPROSIA_COD_PRODUTO_EMP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1", q9);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "TERMOADE_NUM_TERMO" , ""},
                    { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                    { "TERMOADE_COD_AGENCIA_VEN" , ""},
                    { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                    { "TERMOADE_NUM_CONTA_VEN" , ""},
                    { "TERMOADE_DIG_CONTA_VEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1", q10);

                #endregion

                #region M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""},
                    { "VGCOMTRO_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1", q12);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "PROPOFID_NUM_SICOB" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1", q13);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "RCAPS_COD_FONTE" , ""},
                    { "RCAPS_NUM_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "VGFUNCOB_VLR_PREMIO" , ""},
                    { "VGFUNCOB_IMP_SEGURADA" , ""},
                    { "VGFUNCOB_QTD_VIDAS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1", q15);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "VGSOLFAT_NUM_APOLICE" , ""},
                    { "PROPOVA_COD_PRODUTO" , ""},
                    { "RCAPS_COD_FONTE" , ""},
                    { "RCAPS_NUM_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1", q16);

                #endregion

                #region M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_DATA_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1", q17);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "MOEDACOT_VAL_COMPRA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1", q18);

                #endregion

                #region VG0001B_CPROPOVACRT
                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "VGSOLFAT_NUM_APOLICE" , ""},
                    { "VGSOLFAT_COD_SUBGRUPO" , ""},
                    { "VGSOLFAT_NUM_TITULO" , ""},
                    { "PROPOVA_NUM_CERTIFICADO" , "1"},
                    { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                    { "VGSOLFAT_PRM_VG" , "1"},
                    { "VGSOLFAT_PRM_AP" , ""},
                    { "VGSOLFAT_PRM_TOTAL" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG0001B_CPROPOVACRT");
                AppSettings.TestSet.DynamicData.Add("VG0001B_CPROPOVACRT", q19);

                #endregion

                #region M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "FATURAS_NUM_FATURA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1", q20);

                #endregion

                #region M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                    { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                    { "RCAPCOMP_HORA_OPERACAO" , ""},
                    { "RCAPCOMP_COD_OPERACAO" , ""},
                    { "RCAPCOMP_COD_FONTE" , ""},
                    { "RCAPCOMP_NUM_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q21);

                #endregion

                #region M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_COD_FONTE" , ""},
                    { "RCAPCOMP_NUM_RCAP" , ""},
                    { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                    { "RCAPCOMP_COD_OPERACAO" , ""},
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "RCAPCOMP_SIT_REGISTRO" , ""},
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_VAL_RCAP" , ""},
                    { "RCAPCOMP_DATA_RCAP" , ""},
                    { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                    { "RCAPCOMP_SIT_CONTABIL" , ""},
                    { "RCAPCOMP_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q22);

                #endregion

                #region M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_VAL_RCAP" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1", q23);

                #endregion

                #region M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "RCAPS_COD_FONTE" , ""},
                    { "RCAPS_NUM_RCAP" , ""},
                    { "RCAPS_VAL_RCAP" , "1"},
                    { "RCAPS_DATA_MOVIMENTO" , ""},
                    { "RCAPS_AGE_COBRANCA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1", q24);

                #endregion

                #region M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_DATA_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1", q25);

                #endregion

                #region M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1
                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "RCAPS_COD_FONTE" , ""},
                    { "RCAPS_NUM_RCAP" , ""},
                    { "RCAPS_VAL_RCAP" , "1"},
                    { "RCAPS_DATA_MOVIMENTO" , "2000-10-10"},
                    { "RCAPS_AGE_COBRANCA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1", q26);

                #endregion

                #region M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "VGSOLFAT_NUM_APOLICE" , ""},
                    { "PROPOVA_COD_PRODUTO" , ""},
                    { "RCAPS_COD_FONTE" , ""},
                    { "RCAPS_NUM_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1", q27);

                #endregion

                #region M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_DATA_RCAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1", q28);

                #endregion

                #region M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "H_NUM_CERTIFICADO" , ""},
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1", q29);

                #endregion

                #region M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "VGPROSIA_COD_PRODUTO" , ""},
                    { "VGPROSIA_COD_PRODUTO_EMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1", q30);

                #endregion

                #region M_2000_INSERT_DB_INSERT_1_Insert1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "PROPOVA_COD_PRODUTO" , ""},
                    { "SUBGVGAP_COD_CLIENTE" , ""},
                    { "SUBGVGAP_OCORR_ENDERECO" , ""},
                    { "SUBGVGAP_COD_FONTE" , ""},
                    { "PROPOVA_AGE_COBRANCA" , ""},
                    { "PROPOVA_DATA_QUITACAO" , ""},
                    { "TERMOADE_COD_AGENCIA_VEN" , ""},
                    { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                    { "TERMOADE_NUM_CONTA_VEN" , ""},
                    { "TERMOADE_DIG_CONTA_VEN" , ""},
                    { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "PROPOVA_SIT_REGISTRO" , ""},
                    { "VGSOLFAT_NUM_APOLICE" , ""},
                    { "VGSOLFAT_COD_SUBGRUPO" , ""},
                    { "PROPOVA_DTPROXVEN" , ""},
                    { "PROPOVA_NUM_PARCELA" , ""},
                    { "PROPOVA_DATA_VENCIMENTO" , ""},
                    { "ENDOSSOS_NUM_PROPOSTA" , ""},
                    { "WHOST_FAIXA_RENDA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2000_INSERT_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2000_INSERT_DB_INSERT_1_Insert1", q31);

                #endregion

                #region M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                    { "HISCOBPR_IMPSEGUR" , ""},
                    { "VGSOLFAT_QUANT_VIDAS" , ""},
                    { "HISCOBPR_IMPSEGIND" , ""},
                    { "HISCOBPR_IMP_MORNATU" , ""},
                    { "HISCOBPR_IMPMORACID" , ""},
                    { "HISCOBPR_IMPINVPERM" , ""},
                    { "HISCOBPR_IMPAMDS" , ""},
                    { "HISCOBPR_IMPDH" , ""},
                    { "HISCOBPR_IMPDIT" , ""},
                    { "HISCOBPR_VLPREMIO" , ""},
                    { "HISCOBPR_PRMVG" , ""},
                    { "HISCOBPR_PRMAP" , ""},
                    { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                    { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                    { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                    { "HISCOBPR_IMPSEGCDG" , ""},
                    { "HISCOBPR_VLCUSTCDG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q32);

                #endregion

                #region M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "PROPOVA_DATA_QUITACAO" , ""},
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q33);

                #endregion

                #region M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "PROPOVA_NUM_PARCELA" , ""},
                    { "PROPOVA_DATA_VENCIMENTO" , ""},
                    { "HISCOBPR_PRMVG" , ""},
                    { "HISCOBPR_PRMAP" , ""},
                    { "PARCEVID_OPCAO_PAGAMENTO" , ""},
                    { "PARCEVID_SIT_REGISTRO" , ""},
                    { "PARCEVID_OCORR_HISTORICO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1", q34);

                #endregion

                #region M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "PROPOVA_NUM_PARCELA" , ""},
                    { "COBHISVI_NUM_TITULO" , ""},
                    { "WS_DTVENC_1PARC" , ""},
                    { "COBHISVI_PRM_TOTAL" , ""},
                    { "PARCEVID_OPCAO_PAGAMENTO" , ""},
                    { "COBHISVI_SIT_REGISTRO" , ""},
                    { "COBHISVI_OCORR_HISTORICO" , ""},
                    { "COBHISVI_BCO_AVISO" , ""},
                    { "COBHISVI_AGE_AVISO" , ""},
                    { "COBHISVI_NUM_AVISO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q35);

                #endregion

                #region M_2700_NUM_TITULO_DB_SELECT_1_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                    { "BANCOS_NUM_TITULO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_2700_NUM_TITULO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2700_NUM_TITULO_DB_SELECT_1_Query1", q36);

                #endregion

                #region M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                    { "BANCOS_NUM_TITULO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1", q37);

                #endregion

                #region M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "PROPOVA_NUM_PARCELA" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "PROPOVA_DATA_VENCIMENTO" , ""},
                    { "COBHISVI_PRM_TOTAL" , ""},
                    { "HISLANCT_SIT_REGISTRO" , ""},
                    { "HISLANCT_TIPLANC" , ""},
                    { "HISLANCT_OCORR_HISTORICO" , ""},
                    { "HISLANCT_CODCONV" , ""},
                    { "HISLANCT_COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1", q38);

                #endregion

                #region M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                    { "FATURAS_NUM_FATURA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1", q39);

                #endregion

                #region M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

                var q40 = new DynamicData();
                q40.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                    { "PROPOVA_NUM_PARCELA" , ""},
                    { "HISCONPA_NUM_TITULO" , ""},
                    { "HISCONPA_OCORR_HISTORICO" , ""},
                    { "VGSOLFAT_NUM_APOLICE" , ""},
                    { "VGSOLFAT_COD_SUBGRUPO" , ""},
                    { "SUBGVGAP_COD_FONTE" , ""},
                    { "HISCONPA_NUM_ENDOSSO" , ""},
                    { "HISCONPA_PREMIO_VG" , ""},
                    { "HISCONPA_PREMIO_AP" , ""},
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "HISCONPA_SIT_REGISTRO" , ""},
                    { "HISCONPA_COD_OPERACAO" , ""},
                    { "HISCONPA_DTFATUR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q40);

                #endregion

                #region M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                    { "FATURAS_NUM_ENDOSSO" , ""},
                    { "FATURAS_DATA_FATURA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1", q41);

                #endregion

                #region M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                    { "CONVEVG_NUM_APOLICE" , ""},
                    { "CONVEVG_CODSUBES" , ""},
                    { "CONVEVG_COD_SEGURO" , ""},
                    { "CONVEVG_COD_AJUSTE" , ""},
                    { "CONVEVG_COD_COMISSAO" , ""},
                    { "CONVEVG_COD_NAOACEITE" , ""},
                    { "CONVEVG_CODUSU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1", q42);

                #endregion

                #region M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTO_DESCR_PRODUTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1", q43);

                #endregion

                #region M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                    { "VGCOBTER_COD_GARANTIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1", q44);

                #endregion

                #region M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                    { "PRODUVG_NUM_APOLICE" , ""},
                    { "PRODUVG_COD_SUBGRUPO" , ""},
                    { "PRODUVG_ID_SISTEMA" , ""},
                    { "PRODUVG_COD_PRODUTO_AZUL" , ""},
                    { "PRODUVG_COD_PRODUTO" , ""},
                    { "PRODUVG_NOME_PRODUTO" , ""},
                    { "PRODUVG_PERI_PAGAMENTO" , ""},
                    { "PRODUVG_DIAS_INICIO_VIGENC" , ""},
                    { "PRODUVG_DATA_MINVIGENCIA" , ""},
                    { "PRODUVG_DATA_MAXVIGENCIA" , ""},
                    { "PRODUVG_SIT_PLANO_CEF" , ""},
                    { "PRODUVG_OPCAO_PAGAMENTO" , ""},
                    { "PRODUVG_COD_CEDENTE" , ""},
                    { "PRODUVG_OPC_AGENCTO_SUREG" , ""},
                    { "PRODUVG_OPCAO_CAPITALIZ" , ""},
                    { "PRODUVG_COD_SERIE" , ""},
                    { "PRODUVG_NUM_SEQ_TITULO" , ""},
                    { "PRODUVG_NUM_MALA_DIRETA" , ""},
                    { "PRODUVG_RAMO" , ""},
                    { "PRODUVG_CANCELA_ANTIGO" , ""},
                    { "PRODUVG_TEM_CDG" , ""},
                    { "PRODUVG_TEM_SAF" , ""},
                    { "PRODUVG_DIA_FATURA" , ""},
                    { "PRODUVG_ESTR_COBR" , ""},
                    { "PRODUVG_ESTR_EMISS" , ""},
                    { "PRODUVG_ORIG_PRODU" , ""},
                    { "PRODUVG_CODRELAT" , ""},
                    { "PRODUVG_ROT_SAF" , ""},
                    { "PRODUVG_COD_PRODUTO_EA" , ""},
                    { "PRODUVG_COBERADIC_PREMIO" , ""},
                    { "PRODUVG_CUSTOCAP_TOTAL" , ""},
                    { "PRODUVG_DESCONTO_ADESAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1", q45);

                #endregion

                #region M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                    { "VGCOBTER_COD_GARANTIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1", q46);

                #endregion

                #region M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                    { "NUMEROUT_NUM_CERT_VGAP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1", q47);

                #endregion

                #region M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                    { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                    { "RCAPCOMP_BCO_AVISO" , ""},
                    { "RCAPCOMP_AGE_AVISO" , ""},
                    { "NUMEROUT_NUM_CERT_VGAP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1", q48);

                #endregion

                #region M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                    { "SUBGVGAP_OPCAO_COBERTURA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1", q49);

                #endregion

                #region M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                    { "HISCONPA_COD_OPERACAO" , ""},
                    { "HISCONPA_PREMIO_VG" , ""},
                    { "HISCONPA_PREMIO_AP" , ""},
                    { "PROPOVA_NUM_CERTIFICADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1", q50);

                #endregion

                #region M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                    { "SUBGVGAP_DATA_INIVIGENCIA" , ""},
                    { "SUBGVGAP_DATA_TERVIGENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1", q51);

                #endregion

                #region M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1

                var q52 = new DynamicData();
                q52.AddDynamic(new Dictionary<string, string>{
                    { "WS_INIVIGENCIA" , ""},
                    { "WS_TERVIGENCIA" , ""},
                    { "SUBGVGAP_NUM_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1", q52);

                #endregion

                #region M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1

                var q53 = new DynamicData();
                q53.AddDynamic(new Dictionary<string, string>{
                    { "WS_INIVIGENCIA" , ""},
                    { "WS_TERVIGENCIA" , ""},
                    { "SUBGVGAP_NUM_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1", q53);

                #endregion

                #region M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1

                var q54 = new DynamicData();
                q54.AddDynamic(new Dictionary<string, string>{
                    { "WS_CNT_SEGURADOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1", q54);

                #endregion

                #region M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_SIT_REGISTRO" , ""},
                    { "PROPOVA_NUM_CERTIFICADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1", q55);

                #endregion

                #region M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                    { "WS_INIVIGENCIA" , ""},
                    { "WS_TERVIGENCIA" , ""},
                    { "SEGVGAP_NUM_APOLICE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1");
                AppSettings.TestSet.DynamicData.Add("M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1", q56);

                #endregion

                #region M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                    { "WS_NUM_PROPOSTA_SIVPF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1", q57);

                #endregion
                #endregion

                var program = new VG0001B();
                program.Execute();

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("RCAPCOMP_NUM_RCAP_COMPLEMEN", out var valor) && valor == "000000000");

                envList = AppSettings.TestSet.DynamicData["M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("RCAPCOMP_NUM_RCAP", out valor) && valor == "000000000");

                envList = AppSettings.TestSet.DynamicData["M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("RCAPCOMP_VAL_RCAP", out valor) && valor == "0000000000000.00");

                envList = AppSettings.TestSet.DynamicData["M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("PROPOVA_COD_PRODUTO", out valor) && valor == "0000");

                envList = AppSettings.TestSet.DynamicData["M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("NUMEROUT_NUM_CERT_VGAP", out valor) && valor == "000000000000001");

                envList = AppSettings.TestSet.DynamicData["M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("RCAPCOMP_NUM_AVISO_CREDITO", out valor) && valor == "000000000");

                envList = AppSettings.TestSet.DynamicData["M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("HISCONPA_COD_OPERACAO", out valor) && valor == "0201");

                envList = AppSettings.TestSet.DynamicData["M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("WS_INIVIGENCIA", out valor) && valor == "2001-09-30");

                envList = AppSettings.TestSet.DynamicData["M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("WS_TERVIGENCIA", out valor) && valor == "2000-10-01");

                envList = AppSettings.TestSet.DynamicData["M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("PROPOVA_SIT_REGISTRO", out valor) && valor == "3");

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public static void VG0001B_Tests_FactErro()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion
                #endregion
                var program = new VG0001B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);

            }
        }
    }
}