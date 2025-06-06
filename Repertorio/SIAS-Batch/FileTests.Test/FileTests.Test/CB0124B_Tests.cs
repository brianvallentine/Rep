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
using Dclgens;
using Code;
using static Code.CB0124B;

namespace FileTests.Test
{
    [Collection("CB0124B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CB0124B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region CB0124B_C0_PRODUTOS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("CB0124B_C0_PRODUTOS", q0);

            #endregion

            #region CB0124B_C1_PARC_SRETORNO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARC_SR" , ""},
                { "WS_VLR_PARC_SR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0124B_C1_PARC_SRETORNO", q1);

            #endregion

            #region R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_TIPLANC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_PREMIO_AP" , ""},
                { "WS_DATA_GERACAO_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "COBHISVI_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_PREMIO_AP" , ""},
                { "WS_DATA_GERACAO_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "COBHISVI_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_PREMIO_AP" , ""},
                { "WS_DATA_GERACAO_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "COBHISVI_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_PREMIO_AP" , ""},
                { "WS_DATA_GERACAO_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "COBHISVI_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_SIT_REGISTRO" , ""},
                { "PARCEVID_NUM_CERTIFICADO" , ""},
                { "PARCEVID_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_NUM_CERTIFICADO" , ""},
                { "COBHISVI_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_NUM_CERTIFICADO" , ""},
                { "COBHISVI_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CARTAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "WS_DATA_GERACAO_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTA_CONTABIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_COD_FONTE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "HISCONPA_DATA_MOVIMENTO" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "HISCONPA_DTFATUR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

            #endregion

            #region R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_CODRET" , ""},
                { "VIND_COD_RET" , ""},
                { "HISLANCT_NSAC" , ""},
                { "VIND_NSAC" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1", q24);

            #endregion

            #region R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_HORA_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1", q26);

            #endregion

            #region R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_COD_OPERACAO" , ""},
                { "AVISOCRE_TIPO_AVISO" , ""},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_IOCC" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_COSSEGURO_CED" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
                { "AVISOCRE_SIT_CONTABIL" , ""},
                { "AVISOCRE_COD_EMPRESA" , ""},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOCRE_VAL_ADIANTAMENTO" , ""},
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
                { "AVISOSAL_TIPO_SEGURO" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_DATA_AVISO" , ""},
                { "AVISOSAL_DATA_MOVIMENTO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , ""},
                { "CONDESCE_ANO_REFERENCIA" , ""},
                { "CONDESCE_MES_REFERENCIA" , ""},
                { "CONDESCE_BCO_AVISO" , ""},
                { "CONDESCE_AGE_AVISO" , ""},
                { "CONDESCE_NUM_AVISO_CREDITO" , ""},
                { "CONDESCE_COD_PRODUTO" , ""},
                { "CONDESCE_TIPO_REGISTRO" , ""},
                { "CONDESCE_SITUACAO" , ""},
                { "CONDESCE_TIPO_COBRANCA" , ""},
                { "CONDESCE_DATA_MOVIMENTO" , ""},
                { "CONDESCE_DATA_AVISO" , ""},
                { "CONDESCE_QTD_REGISTROS" , ""},
                { "CONDESCE_PRM_TOTAL" , ""},
                { "CONDESCE_PRM_LIQUIDO" , ""},
                { "CONDESCE_VAL_TARIFA" , ""},
                { "CONDESCE_VAL_BALCAO" , ""},
                { "CONDESCE_VAL_IOCC" , ""},
                { "CONDESCE_VAL_DESCONTO" , ""},
                { "CONDESCE_VAL_JUROS" , ""},
                { "CONDESCE_VAL_MULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_CODRET" , ""},
                { "HISLANCT_NSAC" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "HISLANCT_NSAS" , ""},
                { "HISLANCT_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1", q32);

            #endregion

            #region R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , ""},
                { "V0SEGU_AGENCIADOR" , ""},
                { "V0SEGU_ITEM" , ""},
                { "V0SEGU_OCORHIST" , ""},
                { "V0SEGU_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1", q33);

            #endregion

            #region R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_NRPARCEL" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTVENCTO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_NRPRIPARATZ" , ""},
                { "V0PROP_QTDPARATZ" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0PROP_DTADMISSAO" , ""},
                { "V0PROP_TIMESTAMP" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0OPCP_OPCAOPAG" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0OPCP_CARTAOCRED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1", q34);

            #endregion

            #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1", q35);

            #endregion

            #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1", q36);

            #endregion

            #region R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1", q37);

            #endregion

            #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1", q38);

            #endregion

            #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1", q39);

            #endregion

            #region R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0FONT_PROPAUTOM" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0SEGU_TPINCLUS" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0SEGU_AGENCIADOR" , ""},
                { "V0OPCP_PERIPGTO" , ""},
                { "V0PROP_NRMATRFUN" , ""},
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_IMPINVPERM" , ""},
                { "V0COBA_IMPDIT" , ""},
                { "V0COBA_PRMVG" , ""},
                { "V0COBA_PRMAP" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V0SEGU_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , ""},
                { "V0PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1", q41);

            #endregion

            #region R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WS_BCO_RELAT" , ""},
                { "V0OPCP_AGECTADEB" , ""},
                { "V0OPCP_OPRCTADEB" , ""},
                { "V0OPCP_DIGCTADEB" , ""},
                { "V0PROP_NUM_APOLICE" , ""},
                { "WS_NUM_PARCELA" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0OPCP_NUMCTADEB" , ""},
                { "WS_NUM_ORDEM_RELAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_PARC_SR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1", q43);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("D240917.EM8024B.CCDEMAIS.txt")]
        public static void CB0124B_Tests_Theory(string CCDEMAIS_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region CB0124B_C0_PRODUTOS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , "123456" }
            });
            AppSettings.TestSet.DynamicData.Remove("CB0124B_C0_PRODUTOS");
AppSettings.TestSet.DynamicData.Add("CB0124B_C0_PRODUTOS", q0);

                #endregion

                #region CB0124B_C1_PARC_SRETORNO

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARC_SR" , "5" },
                { "WS_VLR_PARC_SR" , "150.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("CB0124B_C1_PARC_SRETORNO");
AppSettings.TestSet.DynamicData.Add("CB0124B_C1_PARC_SRETORNO", q1);

                #endregion

                #region R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC20231201" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q3);

                #endregion

                #region R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_TIPLANC" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_TIPLANC" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q7);

                #endregion

                #region R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_SIT_REGISTRO" , "Ativo" },
                { "PARCEVID_NUM_CERTIFICADO" , "CERT789012" },
                { "PARCEVID_NUM_PARCELA" , "2" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , "Ativo" },
                { "COBHISVI_NUM_CERTIFICADO" , "CERT345678" },
                { "COBHISVI_NUM_PARCELA" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , "Ativo" },
                { "COBHISVI_NUM_CERTIFICADO" , "CERT345678" },
                { "COBHISVI_NUM_PARCELA" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT901234" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "5" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CARTAO" , "4444333322221111" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "5555444433332222" },
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT901234" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTA_CONTABIL" , "0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
                { "HISCONPA_NUM_TITULO" , "TIT789012" },
                { "HISCONPA_OCORR_HISTORICO" , "Histórico de parcela atualizado" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_COD_SUBGRUPO" , "SG456" },
                { "HISCONPA_COD_FONTE" , "FNT002" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
                { "HISCONPA_PREMIO_VG" , "250.00" },
                { "HISCONPA_PREMIO_AP" , "150.00" },
                { "HISCONPA_DATA_MOVIMENTO" , "2023-12-02" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "HISCONPA_COD_OPERACAO" , "OP123" },
                { "HISCONPA_DTFATUR" , "2023-12-03" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "PARCELAS_DAC_PARCELA" , "DAC202312" },
                { "PARCELAS_PRM_TARIFARIO_IX" , "300.00" },
                { "PARCELAS_VAL_DESCONTO_IX" , "50.00" },
                { "PARCELAS_PRM_LIQUIDO_IX" , "250.00" },
                { "PARCELAS_ADICIONAL_FRAC_IX" , "10.00" },
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , "5.00" },
                { "PARCELAS_VAL_IOCC_IX" , "2.50" },
                { "PARCELAS_PRM_TOTAL_IX" , "267.50" },
                { "PARCELAS_QTD_DOCUMENTOS" , "3" },
                { "PARCELAS_SIT_REGISTRO" , "0" },
                { "PROPOVA_COD_PRODUTO" , "PRD789012" },
                { "ENDOSSOS_TIPO_CORRECAO" , "Correção de valor" },
                { "ENDOSSOS_COD_MOEDA_PRM" , "BRL" },
                { "ENDOSSOS_COD_USUARIO" , "USR123" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "PARCELAS_DAC_PARCELA" , "DAC202312" },
                { "PARCELAS_PRM_TARIFARIO_IX" , "300.00" },
                { "PARCELAS_VAL_DESCONTO_IX" , "50.00" },
                { "PARCELAS_PRM_LIQUIDO_IX" , "250.00" },
                { "PARCELAS_ADICIONAL_FRAC_IX" , "10.00" },
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , "5.00" },
                { "PARCELAS_VAL_IOCC_IX" , "2.50" },
                { "PARCELAS_PRM_TOTAL_IX" , "267.50" },
                { "PARCELAS_QTD_DOCUMENTOS" , "3" },
                { "PARCELAS_SIT_REGISTRO" , "0" },
                { "PROPOVA_COD_PRODUTO" , "PRD789012" },
                { "ENDOSSOS_TIPO_CORRECAO" , "Correção de valor" },
                { "ENDOSSOS_COD_MOEDA_PRM" , "BRL" },
                { "ENDOSSOS_COD_USUARIO" , "USR123" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "HISCONPA_OCORR_HISTORICO" , "Histórico de parcela atualizado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

                #endregion

                #region R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "EMP123" },
                { "MOVIMCOB_COD_MOVIMENTO" , "MOV456" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV789012" },
                { "MOVIMCOB_NUM_FITA" , "FT123456" },
                { "MOVIMCOB_DATA_MOVIMENTO" , "2023-12-04" },
                { "MOVIMCOB_DATA_QUITACAO" , "2023-12-05" },
                { "MOVIMCOB_NUM_TITULO" , "TIT012345" },
                { "MOVIMCOB_NUM_APOLICE" , "AP012345678" },
                { "MOVIMCOB_NUM_ENDOSSO" , "END789012" },
                { "MOVIMCOB_NUM_PARCELA" , "5" },
                { "MOVIMCOB_VAL_TITULO" , "400.00" },
                { "MOVIMCOB_VAL_IOCC" , "3.00" },
                { "MOVIMCOB_VAL_CREDITO" , "397.00" },
                { "MOVIMCOB_SIT_REGISTRO" , "Ativo" },
                { "MOVIMCOB_NOME_SEGURADO" , "João Silva" },
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Pagamento" },
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "NT123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1", q21);

                #endregion

                #region R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV789012" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q22);

                #endregion

                #region R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_CODRET" , "9020" },
                { "VIND_COD_RET" , "VCR123" },
                { "HISLANCT_NSAC" , "NSAC789012" },
                { "VIND_NSAC" , "VNSAC123456" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q23);

                #endregion

                #region R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1

    var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_VENCIMENTO" , "2023-12-10" },
                { "PARCEHIS_OCORR_HISTORICO" , "Histórico de parcela registrado" },
                { "PARCEHIS_PRM_TARIFARIO" , "350.00" },
                { "PARCEHIS_VAL_DESCONTO" , "70.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "280.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "15.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "7.50" },
                { "PARCEHIS_VAL_IOCC" , "3.50" },
                { "PARCEHIS_PRM_TOTAL" , "40.47" },
                { "PARCEHIS_NUM_PARCELA" , "6" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1", q24);

                #endregion

                #region R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1

    var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "AP234567890" },
                { "PARCEHIS_NUM_ENDOSSO" , "END234567" },
                { "PARCEHIS_NUM_PARCELA" , "6" },
                { "PARCEHIS_DAC_PARCELA" , "DAC202312" },
                { "PARCEHIS_DATA_MOVIMENTO" , "2023-12-06" },
                { "PARCEHIS_COD_OPERACAO" , "OP456" },
                { "PARCEHIS_HORA_OPERACAO" , "14:00" },
                { "PARCEHIS_OCORR_HISTORICO" , "Histórico de parcela registrado" },
                { "PARCEHIS_PRM_TARIFARIO" , "350.00" },
                { "PARCEHIS_VAL_DESCONTO" , "70.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "280.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "15.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "7.50" },
                { "PARCEHIS_VAL_IOCC" , "3.50" },
                { "PARCEHIS_PRM_TOTAL" , "40.47" },
                { "PARCEHIS_VAL_OPERACAO" , "305.00" },
                { "PARCEHIS_DATA_VENCIMENTO" , "2023-12-10" },
                { "PARCEHIS_BCO_COBRANCA" , "001" },
                { "PARCEHIS_AGE_COBRANCA" , "0001" },
                { "PARCEHIS_NUM_AVISO_CREDITO" , "AC789012" },
                { "PARCEHIS_ENDOS_CANCELA" , "Não" },
                { "PARCEHIS_SIT_CONTABIL" , "Ativo" },
                { "PARCEHIS_COD_USUARIO" , "USR456" },
                { "PARCEHIS_RENUM_DOCUMENTO" , "DOC789012" },
                { "PARCEHIS_DATA_QUITACAO" , "2023-12-11" },
                { "PARCEHIS_COD_EMPRESA" , "EMP456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1", q25);

                #endregion

                #region R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1

    var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , "Histórico de parcela registrado" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1", q26);

                #endregion

                #region R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1

    var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1", q27);

                #endregion

                #region R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1

    var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , "001" },
                { "AVISOCRE_AGE_AVISO" , "0001" },
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC20231201" },
                { "AVISOCRE_NUM_SEQUENCIA" , "SEQ123456" },
                { "AVISOCRE_DATA_MOVIMENTO" , "2023-12-07" },
                { "AVISOCRE_COD_OPERACAO" , "OP789" },
                { "AVISOCRE_TIPO_AVISO" , "Aviso de Crédito" },
                { "AVISOCRE_DATA_AVISO" , "2023-12-08" },
                { "AVISOCRE_VAL_IOCC" , "4.00" },
                { "AVISOCRE_VAL_DESPESA" , "20.00" },
                { "AVISOCRE_PRM_COSSEGURO_CED" , "50.00" },
                { "AVISOCRE_PRM_LIQUIDO" , "430.00" },
                { "AVISOCRE_PRM_TOTAL" , "500.00" },
                { "AVISOCRE_SIT_CONTABIL" , "Ativo" },
                { "AVISOCRE_COD_EMPRESA" , "EMP789" },
                { "AVISOCRE_ORIGEM_AVISO" , "Origem X" },
                { "AVISOCRE_VAL_ADIANTAMENTO" , "100.00" },
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Remove("R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1", q28);

                #endregion

                #region R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1

    var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , "EMP012" },
                { "AVISOSAL_BCO_AVISO" , "001" },
                { "AVISOSAL_AGE_AVISO" , "0001" },
                { "AVISOSAL_TIPO_SEGURO" , "Seguro de Vida" },
                { "AVISOSAL_NUM_AVISO_CREDITO" , "AC012345" },
                { "AVISOSAL_DATA_AVISO" , "2023-12-09" },
                { "AVISOSAL_DATA_MOVIMENTO" , "2023-12-10" },
                { "AVISOSAL_SALDO_ATUAL" , "1200.00" },
                { "AVISOSAL_SIT_REGISTRO" , "Ativo" },
            });
            AppSettings.TestSet.DynamicData.Remove("R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1", q29);

                #endregion

                #region R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

    var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , "EMP234" },
                { "CONDESCE_ANO_REFERENCIA" , "2023" },
                { "CONDESCE_MES_REFERENCIA" , "12" },
                { "CONDESCE_BCO_AVISO" , "001" },
                { "CONDESCE_AGE_AVISO" , "0001" },
                { "CONDESCE_NUM_AVISO_CREDITO" , "AC234567" },
                { "CONDESCE_COD_PRODUTO" , "PRD234567" },
                { "CONDESCE_TIPO_REGISTRO" , "Tipo X" },
                { "CONDESCE_SITUACAO" , "Ativo" },
                { "CONDESCE_TIPO_COBRANCA" , "Cobrança Direta" },
                { "CONDESCE_DATA_MOVIMENTO" , "2023-12-11" },
                { "CONDESCE_DATA_AVISO" , "2023-12-12" },
                { "CONDESCE_QTD_REGISTROS" , "10" },
                { "CONDESCE_PRM_TOTAL" , "600.00" },
                { "CONDESCE_PRM_LIQUIDO" , "540.00" },
                { "CONDESCE_VAL_TARIFA" , "30.00" },
                { "CONDESCE_VAL_BALCAO" , "20.00" },
                { "CONDESCE_VAL_IOCC" , "6.00" },
                { "CONDESCE_VAL_DESCONTO" , "10.00" },
                { "CONDESCE_VAL_JUROS" , "5.00" },
                { "CONDESCE_VAL_MULTA" , "15.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q30);

                #endregion

                #region R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

    var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_CODRET" , "9020" },
                { "HISLANCT_NSAC" , "NSAC789012" },
                { "HISLANCT_CODCONV" , "9020" },
                { "HISLANCT_NSAS" , "NSAS789012" },
                { "HISLANCT_NSL" , "NSL123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q31);

                #endregion

                #region R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1

    var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1", q32);

                #endregion

                #region R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1

    var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , "Inclusão" },
                { "V0SEGU_AGENCIADOR" , "AG789012" },
                { "V0SEGU_ITEM" , "Item X" },
                { "V0SEGU_OCORHIST" , "Ocorrência X" },
                { "V0SEGU_LOT_EMP_SEGURADO" , "LOT789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1", q33);

                #endregion

                #region R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1

    var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
                { "V0PROP_FONTE" , "FNT789" },
                { "V0PROP_NUM_APOLICE" , "AP789012345" },
                { "V0PROP_CODSUBES" , "SUB789012" },
                { "V0PROP_CODPRODU" , "PRD789012345" },
                { "V0PROP_CODCLIEN" , "CL789012345" },
                { "V0PROP_NRPARCEL" , "12" },
                { "V0PROP_SITUACAO" , "2" },
                { "V0PROP_DTQITBCO" , "2023-12-13" },
                { "V0PROP_DTVENCTO" , "2023-12-14" },
                { "V0PROP_DTPROXVEN" , "2024-01-01" },
                { "V0PROP_NRPRIPARATZ" , "1" },
                { "V0PROP_QTDPARATZ" , "12" },
                { "V0PROP_NRMATRFUN" , "MAT789012" },
                { "V0PROP_DTADMISSAO" , "2023-01-01" },
                { "V0PROP_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "V0OPCP_PERIPGTO" , "Mensal" },
                { "V0OPCP_OPCAOPAG" , "Débito em Conta" },
                { "V0OPCP_AGECTADEB" , "0001" },
                { "V0OPCP_OPRCTADEB" , "Operação X" },
                { "V0OPCP_NUMCTADEB" , "CT789012" },
                { "V0OPCP_DIGCTADEB" , "5" },
                { "V0OPCP_CARTAOCRED" , "5555444433331111" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1", q34);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1

    var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , "Morte Natural" },
                { "V0COBA_PRMVG" , "300.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1", q35);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1

    var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , "Morte Acidental" },
                { "V0COBA_PRMAP" , "150.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1", q36);

                #endregion

                #region R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1

    var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , "Automático" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1", q37);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1

    var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , "Invalidez Permanente" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1", q38);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1

    var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , "Doença Invalidez Total" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1", q39);

                #endregion

                #region R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1

    var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "AP789012345" },
                { "V0PROP_CODSUBES" , "SUB789012" },
                { "V0PROP_FONTE" , "FNT789" },
                { "V0FONT_PROPAUTOM" , "Automático" },
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
                { "V0SEGU_TPINCLUS" , "Inclusão" },
                { "V0PROP_CODCLIEN" , "CL789012345" },
                { "V0SEGU_AGENCIADOR" , "AG789012" },
                { "V0OPCP_PERIPGTO" , "Mensal" },
                { "V0PROP_NRMATRFUN" , "MAT789012" },
                { "V0COBA_IMPMORNATU" , "Morte Natural" },
                { "V0COBA_IMPMORACID" , "Morte Acidental" },
                { "V0COBA_IMPINVPERM" , "Invalidez Permanente" },
                { "V0COBA_IMPDIT" , "Doença Invalidez Total" },
                { "V0COBA_PRMVG" , "300.00" },
                { "V0COBA_PRMAP" , "150.00" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "V0SEGU_LOT_EMP_SEGURADO" , "LOT789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1", q40);

                #endregion

                #region R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1

    var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , "Automático" },
                { "V0PROP_FONTE" , "FNT789" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1", q41);

                #endregion

                #region R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1

    var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "WS_BCO_RELAT" , "001" },
                { "V0OPCP_AGECTADEB" , "0001" },
                { "V0OPCP_OPRCTADEB" , "Operação X" },
                { "V0OPCP_DIGCTADEB" , "5" },
                { "V0PROP_NUM_APOLICE" , "AP789012345" },
                { "WS_NUM_PARCELA" , "7" },
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
                { "V0PROP_CODSUBES" , "SUB789012" },
                { "V0OPCP_NUMCTADEB" , "CT789012" },
                { "WS_NUM_ORDEM_RELAT" , "ORD789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1", q42);

                #endregion

                #region R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1

    var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_PARC_SR" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1", q43);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new CB0124B();
                program.Execute(CCDEMAIS_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 3);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 3);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2.5);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("D240917.EM8024B.CCDEMAIS.txt")]
        public static void CB0124B_Tests_ReturnCode99_Theory(string CCDEMAIS_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region CB0124B_C0_PRODUTOS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , "123456" }
            }, new SQLCA(99));
            AppSettings.TestSet.DynamicData.Remove("CB0124B_C0_PRODUTOS");
AppSettings.TestSet.DynamicData.Add("CB0124B_C0_PRODUTOS", q0);

                #endregion

                #region CB0124B_C1_PARC_SRETORNO

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PARC_SR" , "5" },
                { "WS_VLR_PARC_SR" , "150.00" },
            }, new SQLCA(99));
            AppSettings.TestSet.DynamicData.Remove("CB0124B_C1_PARC_SRETORNO");
AppSettings.TestSet.DynamicData.Add("CB0124B_C1_PARC_SRETORNO", q1);

                #endregion

                #region R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC20231201" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q3);

                #endregion

                #region R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_TIPLANC" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3002_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_TIPLANC" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3005_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3006_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1", q7);

                #endregion

                #region R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3006_00_VERIFICAR_PARCELA_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3007_00_VERIFICAR_CREDITO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_FONTE" , "FNT001" },
                { "PROPOVA_NUM_APOLICE" , "AP123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "SG123" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PARCEVID_PREMIO_VG" , "200.00" },
                { "PARCEVID_PREMIO_AP" , "100.00" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "COBHISVI_OCORR_HISTORICO" , "Histórico de cobrança registrado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3008_00_VERIF_PARC_CHARGE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_SIT_REGISTRO" , "Ativo" },
                { "PARCEVID_NUM_CERTIFICADO" , "CERT789012" },
                { "PARCEVID_NUM_PARCELA" , "2" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3020_00_UPDATE_PARCEVID_DB_UPDATE_1_Update1", q11);

                #endregion

                #region R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , "Ativo" },
                { "COBHISVI_NUM_CERTIFICADO" , "CERT345678" },
                { "COBHISVI_NUM_PARCELA" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3030_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , "Ativo" },
                { "COBHISVI_NUM_CERTIFICADO" , "CERT345678" },
                { "COBHISVI_NUM_PARCELA" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3040_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT901234" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "" },
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "5" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "GE408_NUM_CARTAO" , "4444333322221111" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "5555444433332222" },
                { "OPCPAGVI_NUM_CERTIFICADO" , "CERT901234" },
                { "WS_DATA_GERACAO_PARCELA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R3070_00_ATUALIZA_NUM_CARTAO_DB_UPDATE_1_Update1", q16);

                #endregion

                #region R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTA_CONTABIL" , "0" }
            });
            AppSettings.TestSet.DynamicData.Remove("R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1", q17);

                #endregion

                #region R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
                { "HISCONPA_NUM_TITULO" , "TIT789012" },
                { "HISCONPA_OCORR_HISTORICO" , "Histórico de parcela atualizado" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_COD_SUBGRUPO" , "SG456" },
                { "HISCONPA_COD_FONTE" , "FNT002" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
                { "HISCONPA_PREMIO_VG" , "250.00" },
                { "HISCONPA_PREMIO_AP" , "150.00" },
                { "HISCONPA_DATA_MOVIMENTO" , "2023-12-02" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "HISCONPA_COD_OPERACAO" , "OP123" },
                { "HISCONPA_DTFATUR" , "2023-12-03" },
            });
            AppSettings.TestSet.DynamicData.Remove("R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "PARCELAS_DAC_PARCELA" , "DAC202312" },
                { "PARCELAS_PRM_TARIFARIO_IX" , "300.00" },
                { "PARCELAS_VAL_DESCONTO_IX" , "50.00" },
                { "PARCELAS_PRM_LIQUIDO_IX" , "250.00" },
                { "PARCELAS_ADICIONAL_FRAC_IX" , "10.00" },
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , "5.00" },
                { "PARCELAS_VAL_IOCC_IX" , "2.50" },
                { "PARCELAS_PRM_TOTAL_IX" , "267.50" },
                { "PARCELAS_QTD_DOCUMENTOS" , "3" },
                { "PARCELAS_SIT_REGISTRO" , "0" },
                { "PROPOVA_COD_PRODUTO" , "PRD789012" },
                { "ENDOSSOS_TIPO_CORRECAO" , "Correção de valor" },
                { "ENDOSSOS_COD_MOEDA_PRM" , "BRL" },
                { "ENDOSSOS_COD_USUARIO" , "USR123" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4010_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_SIT_REGISTRO" , "Ativo" },
                { "PARCELAS_DAC_PARCELA" , "DAC202312" },
                { "PARCELAS_PRM_TARIFARIO_IX" , "300.00" },
                { "PARCELAS_VAL_DESCONTO_IX" , "50.00" },
                { "PARCELAS_PRM_LIQUIDO_IX" , "250.00" },
                { "PARCELAS_ADICIONAL_FRAC_IX" , "10.00" },
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , "5.00" },
                { "PARCELAS_VAL_IOCC_IX" , "2.50" },
                { "PARCELAS_PRM_TOTAL_IX" , "267.50" },
                { "PARCELAS_QTD_DOCUMENTOS" , "3" },
                { "PARCELAS_SIT_REGISTRO" , "0" },
                { "PROPOVA_COD_PRODUTO" , "PRD789012" },
                { "ENDOSSOS_TIPO_CORRECAO" , "Correção de valor" },
                { "ENDOSSOS_COD_MOEDA_PRM" , "BRL" },
                { "ENDOSSOS_COD_USUARIO" , "USR123" },
                { "COBHISVI_NUM_TITULO" , "TIT123456" },
                { "HISCONPA_OCORR_HISTORICO" , "Histórico de parcela atualizado" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4015_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q20);

                #endregion

                #region R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "EMP123" },
                { "MOVIMCOB_COD_MOVIMENTO" , "MOV456" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV789012" },
                { "MOVIMCOB_NUM_FITA" , "FT123456" },
                { "MOVIMCOB_DATA_MOVIMENTO" , "2023-12-04" },
                { "MOVIMCOB_DATA_QUITACAO" , "2023-12-05" },
                { "MOVIMCOB_NUM_TITULO" , "TIT012345" },
                { "MOVIMCOB_NUM_APOLICE" , "AP012345678" },
                { "MOVIMCOB_NUM_ENDOSSO" , "END789012" },
                { "MOVIMCOB_NUM_PARCELA" , "5" },
                { "MOVIMCOB_VAL_TITULO" , "400.00" },
                { "MOVIMCOB_VAL_IOCC" , "3.00" },
                { "MOVIMCOB_VAL_CREDITO" , "397.00" },
                { "MOVIMCOB_SIT_REGISTRO" , "Ativo" },
                { "MOVIMCOB_NOME_SEGURADO" , "João Silva" },
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Pagamento" },
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "NT123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R4025_00_INSERT_MOV_COBR_DB_INSERT_1_Insert1", q21);

                #endregion

                #region R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , "0001" },
                { "MOVIMCOB_NUM_AVISO" , "AV789012" },
                { "MOVIMCOB_COD_BANCO" , "001" },
                { "HISCONPA_NUM_CERTIFICADO" , "CERT567890" },
                { "HISCONPA_NUM_PARCELA" , "4" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4030_UPD_COBER_HIST_VIDAZUL_DB_UPDATE_1_Update1", q22);

                #endregion

                #region R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

    var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_CODRET" , "9020" },
                { "VIND_COD_RET" , "VCR123" },
                { "HISLANCT_NSAC" , "NSAC789012" },
                { "VIND_NSAC" , "VNSAC123456" },
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_OCORR_HISTORICOCTA" , "Histórico de conta atualizado" },
                { "HISLANCT_NUM_CERTIFICADO" , "83295110022477" },
                { "HISLANCT_NUM_PARCELA" , "24" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4040_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q23);

                #endregion

                #region R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1

    var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_VENCIMENTO" , "2023-12-10" },
                { "PARCEHIS_OCORR_HISTORICO" , "Histórico de parcela registrado" },
                { "PARCEHIS_PRM_TARIFARIO" , "350.00" },
                { "PARCEHIS_VAL_DESCONTO" , "70.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "280.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "15.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "7.50" },
                { "PARCEHIS_VAL_IOCC" , "3.50" },
                { "PARCEHIS_PRM_TOTAL" , "40.47" },
                { "PARCEHIS_NUM_PARCELA" , "6" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4215_00_RECUP_DADOS_HISTORICO_DB_SELECT_1_Query1", q24);

                #endregion

                #region R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1

    var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "AP234567890" },
                { "PARCEHIS_NUM_ENDOSSO" , "END234567" },
                { "PARCEHIS_NUM_PARCELA" , "6" },
                { "PARCEHIS_DAC_PARCELA" , "DAC202312" },
                { "PARCEHIS_DATA_MOVIMENTO" , "2023-12-06" },
                { "PARCEHIS_COD_OPERACAO" , "OP456" },
                { "PARCEHIS_HORA_OPERACAO" , "14:00" },
                { "PARCEHIS_OCORR_HISTORICO" , "Histórico de parcela registrado" },
                { "PARCEHIS_PRM_TARIFARIO" , "350.00" },
                { "PARCEHIS_VAL_DESCONTO" , "70.00" },
                { "PARCEHIS_PRM_LIQUIDO" , "280.00" },
                { "PARCEHIS_ADICIONAL_FRACIO" , "15.00" },
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , "7.50" },
                { "PARCEHIS_VAL_IOCC" , "3.50" },
                { "PARCEHIS_PRM_TOTAL" , "40.47" },
                { "PARCEHIS_VAL_OPERACAO" , "305.00" },
                { "PARCEHIS_DATA_VENCIMENTO" , "2023-12-10" },
                { "PARCEHIS_BCO_COBRANCA" , "001" },
                { "PARCEHIS_AGE_COBRANCA" , "0001" },
                { "PARCEHIS_NUM_AVISO_CREDITO" , "AC789012" },
                { "PARCEHIS_ENDOS_CANCELA" , "Não" },
                { "PARCEHIS_SIT_CONTABIL" , "Ativo" },
                { "PARCEHIS_COD_USUARIO" , "USR456" },
                { "PARCEHIS_RENUM_DOCUMENTO" , "DOC789012" },
                { "PARCEHIS_DATA_QUITACAO" , "2023-12-11" },
                { "PARCEHIS_COD_EMPRESA" , "EMP456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R4220_00_INSERT_PARCELA_HIS_DB_INSERT_1_Insert1", q25);

                #endregion

                #region R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1

    var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , "Histórico de parcela registrado" },
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4230_00_ATUALIZA_PARCELAS_DB_UPDATE_1_Update1", q26);

                #endregion

                #region R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1

    var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , "AP987654321" },
                { "HISCONPA_NUM_ENDOSSO" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R4240_00_ATUALIZA_ENDOSSOS_DB_UPDATE_1_Update1", q27);

                #endregion

                #region R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1

    var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , "001" },
                { "AVISOCRE_AGE_AVISO" , "0001" },
                { "AVISOCRE_NUM_AVISO_CREDITO" , "AC20231201" },
                { "AVISOCRE_NUM_SEQUENCIA" , "SEQ123456" },
                { "AVISOCRE_DATA_MOVIMENTO" , "2023-12-07" },
                { "AVISOCRE_COD_OPERACAO" , "OP789" },
                { "AVISOCRE_TIPO_AVISO" , "Aviso de Crédito" },
                { "AVISOCRE_DATA_AVISO" , "2023-12-08" },
                { "AVISOCRE_VAL_IOCC" , "4.00" },
                { "AVISOCRE_VAL_DESPESA" , "20.00" },
                { "AVISOCRE_PRM_COSSEGURO_CED" , "50.00" },
                { "AVISOCRE_PRM_LIQUIDO" , "430.00" },
                { "AVISOCRE_PRM_TOTAL" , "500.00" },
                { "AVISOCRE_SIT_CONTABIL" , "Ativo" },
                { "AVISOCRE_COD_EMPRESA" , "EMP789" },
                { "AVISOCRE_ORIGEM_AVISO" , "Origem X" },
                { "AVISOCRE_VAL_ADIANTAMENTO" , "100.00" },
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Remove("R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R5010_00_INSERT_AVISO_CREDITO_DB_INSERT_1_Insert1", q28);

                #endregion

                #region R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1

    var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , "EMP012" },
                { "AVISOSAL_BCO_AVISO" , "001" },
                { "AVISOSAL_AGE_AVISO" , "0001" },
                { "AVISOSAL_TIPO_SEGURO" , "Seguro de Vida" },
                { "AVISOSAL_NUM_AVISO_CREDITO" , "AC012345" },
                { "AVISOSAL_DATA_AVISO" , "2023-12-09" },
                { "AVISOSAL_DATA_MOVIMENTO" , "2023-12-10" },
                { "AVISOSAL_SALDO_ATUAL" , "1200.00" },
                { "AVISOSAL_SIT_REGISTRO" , "Ativo" },
            });
            AppSettings.TestSet.DynamicData.Remove("R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R5020_00_INSERT_AVISOS_SALDOS_DB_INSERT_1_Insert1", q29);

                #endregion

                #region R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

    var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , "EMP234" },
                { "CONDESCE_ANO_REFERENCIA" , "2023" },
                { "CONDESCE_MES_REFERENCIA" , "12" },
                { "CONDESCE_BCO_AVISO" , "001" },
                { "CONDESCE_AGE_AVISO" , "0001" },
                { "CONDESCE_NUM_AVISO_CREDITO" , "AC234567" },
                { "CONDESCE_COD_PRODUTO" , "PRD234567" },
                { "CONDESCE_TIPO_REGISTRO" , "Tipo X" },
                { "CONDESCE_SITUACAO" , "Ativo" },
                { "CONDESCE_TIPO_COBRANCA" , "Cobrança Direta" },
                { "CONDESCE_DATA_MOVIMENTO" , "2023-12-11" },
                { "CONDESCE_DATA_AVISO" , "2023-12-12" },
                { "CONDESCE_QTD_REGISTROS" , "10" },
                { "CONDESCE_PRM_TOTAL" , "600.00" },
                { "CONDESCE_PRM_LIQUIDO" , "540.00" },
                { "CONDESCE_VAL_TARIFA" , "30.00" },
                { "CONDESCE_VAL_BALCAO" , "20.00" },
                { "CONDESCE_VAL_IOCC" , "6.00" },
                { "CONDESCE_VAL_DESCONTO" , "10.00" },
                { "CONDESCE_VAL_JUROS" , "5.00" },
                { "CONDESCE_VAL_MULTA" , "15.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R5500_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q30);

                #endregion

                #region R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1

    var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , "Ativo" },
                { "HISLANCT_CODRET" , "9020" },
                { "HISLANCT_NSAC" , "NSAC789012" },
                { "HISLANCT_CODCONV" , "9020" },
                { "HISLANCT_NSAS" , "NSAS789012" },
                { "HISLANCT_NSL" , "NSL123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R6010_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1", q31);

                #endregion

                #region R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1

    var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R7010_00_UPDATE_PROPOSTA_VA_DB_UPDATE_1_Update1", q32);

                #endregion

                #region R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1

    var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V0SEGU_TPINCLUS" , "Inclusão" },
                { "V0SEGU_AGENCIADOR" , "AG789012" },
                { "V0SEGU_ITEM" , "Item X" },
                { "V0SEGU_OCORHIST" , "Ocorrência X" },
                { "V0SEGU_LOT_EMP_SEGURADO" , "LOT789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1", q33);

                #endregion

                #region R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1

    var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
                { "V0PROP_FONTE" , "FNT789" },
                { "V0PROP_NUM_APOLICE" , "AP789012345" },
                { "V0PROP_CODSUBES" , "SUB789012" },
                { "V0PROP_CODPRODU" , "PRD789012345" },
                { "V0PROP_CODCLIEN" , "CL789012345" },
                { "V0PROP_NRPARCEL" , "12" },
                { "V0PROP_SITUACAO" , "2" },
                { "V0PROP_DTQITBCO" , "2023-12-13" },
                { "V0PROP_DTVENCTO" , "2023-12-14" },
                { "V0PROP_DTPROXVEN" , "2024-01-01" },
                { "V0PROP_NRPRIPARATZ" , "1" },
                { "V0PROP_QTDPARATZ" , "12" },
                { "V0PROP_NRMATRFUN" , "MAT789012" },
                { "V0PROP_DTADMISSAO" , "2023-01-01" },
                { "V0PROP_TIMESTAMP" , "2023-12-01T12:00:00" },
                { "V0OPCP_PERIPGTO" , "Mensal" },
                { "V0OPCP_OPCAOPAG" , "Débito em Conta" },
                { "V0OPCP_AGECTADEB" , "0001" },
                { "V0OPCP_OPRCTADEB" , "Operação X" },
                { "V0OPCP_NUMCTADEB" , "CT789012" },
                { "V0OPCP_DIGCTADEB" , "5" },
                { "V0OPCP_CARTAOCRED" , "5555444433331111" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1", q34);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1

    var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , "Morte Natural" },
                { "V0COBA_PRMVG" , "300.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_1_Query1", q35);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1

    var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , "Morte Acidental" },
                { "V0COBA_PRMAP" , "150.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_2_Query1", q36);

                #endregion

                #region R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1

    var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , "Automático" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7050_00_RECUPERA_PROPOSTA_AUT_DB_SELECT_1_Query1", q37);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1

    var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , "Invalidez Permanente" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_3_Query1", q38);

                #endregion

                #region R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1

    var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , "Doença Invalidez Total" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1");
AppSettings.TestSet.DynamicData.Add("R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1", q39);

                #endregion

                #region R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1

    var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUM_APOLICE" , "AP789012345" },
                { "V0PROP_CODSUBES" , "SUB789012" },
                { "V0PROP_FONTE" , "FNT789" },
                { "V0FONT_PROPAUTOM" , "Automático" },
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
                { "V0SEGU_TPINCLUS" , "Inclusão" },
                { "V0PROP_CODCLIEN" , "CL789012345" },
                { "V0SEGU_AGENCIADOR" , "AG789012" },
                { "V0OPCP_PERIPGTO" , "Mensal" },
                { "V0PROP_NRMATRFUN" , "MAT789012" },
                { "V0COBA_IMPMORNATU" , "Morte Natural" },
                { "V0COBA_IMPMORACID" , "Morte Acidental" },
                { "V0COBA_IMPINVPERM" , "Invalidez Permanente" },
                { "V0COBA_IMPDIT" , "Doença Invalidez Total" },
                { "V0COBA_PRMVG" , "300.00" },
                { "V0COBA_PRMAP" , "150.00" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "V0SEGU_LOT_EMP_SEGURADO" , "LOT789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R7060_10_INSERT_MOVIMENTO_DB_INSERT_1_Insert1", q40);

                #endregion

                #region R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1

    var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_PROPAUTOM" , "Automático" },
                { "V0PROP_FONTE" , "FNT789" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R7060_10_INSERT_MOVIMENTO_DB_UPDATE_1_Update1", q41);

                #endregion

                #region R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1

    var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "WS_BCO_RELAT" , "001" },
                { "V0OPCP_AGECTADEB" , "0001" },
                { "V0OPCP_OPRCTADEB" , "Operação X" },
                { "V0OPCP_DIGCTADEB" , "5" },
                { "V0PROP_NUM_APOLICE" , "AP789012345" },
                { "WS_NUM_PARCELA" , "7" },
                { "V0PROP_NRCERTIF" , "NRCERT789012" },
                { "V0PROP_CODSUBES" , "SUB789012" },
                { "V0OPCP_NUMCTADEB" , "CT789012" },
                { "WS_NUM_ORDEM_RELAT" , "ORD789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1", q42);

                #endregion

                #region R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1

    var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_PARC_SR" , "10" }
            });
            AppSettings.TestSet.DynamicData.Remove("R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1", q43);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new CB0124B();
                program.Execute(CCDEMAIS_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}