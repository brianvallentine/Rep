using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0141B;
using Sias.VidaAzul.DB2.VA0141B;

namespace FileTests.Test
{
    [Collection("VA0141B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0141B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA15" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DTH_ULT_DIA_MES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0180_00_SELECT_GE403_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0180_00_SELECT_GE403_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0270_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DTH_ULT_DIA_MES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0360_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "WHOST_NUMPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "WHOST_NUMPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_COBRANCA" , ""},
                { "NUMERAES_ENDOS_RESTITUICAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0700_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_FONTES_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0710_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0710_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q14);

            #endregion

            #region VA0141B_V0VG082

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "VG082_NUM_CERTIFICADO" , ""},
                { "VG082_NUM_PARCELA" , ""},
                { "VG082_RAMO_EMISSOR" , ""},
                { "VG082_VLR_PREMIO_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0141B_V0VG082", q15);

            #endregion

            #region VA0141B_V0APOLCOSS

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_COD_COSSEGURADORA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0141B_V0APOLCOSS", q16);

            #endregion

            #region R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_RESTITUICAO" , ""},
                { "NUMERAES_ENDOS_COBRANCA" , ""},
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R2450_00_UPDATE_FONTES_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "FONTES_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2450_00_UPDATE_FONTES_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_DATA_VENCIMENTO" , ""},
                { "PARCEVID_DATA_VENCIMENTO_1M" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUM_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q20);

            #endregion

            #region R2514_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2514_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_BCO_RCAP" , ""},
                { "ENDOSSOS_AGE_RCAP" , ""},
                { "ENDOSSOS_DAC_RCAP" , ""},
                { "ENDOSSOS_TIPO_RCAP" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_PLANO_SEGURO" , ""},
                { "ENDOSSOS_PCT_ENTRADA" , ""},
                { "ENDOSSOS_PCT_ADIC_FRACIO" , ""},
                { "ENDOSSOS_QTD_DIAS_PRIMEIRA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_QTD_PRESTACOES" , ""},
                { "ENDOSSOS_QTD_ITENS" , ""},
                { "ENDOSSOS_COD_TEXTO_PADRAO" , ""},
                { "ENDOSSOS_COD_ACEITACAO" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "ENDOSSOS_DATA_RCAP" , ""},
                { "ENDOSSOS_COD_EMPRESA" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_ISENTA_CUSTO" , ""},
                { "ENDOSSOS_DATA_VENCIMENTO" , ""},
                { "ENDOSSOS_COEF_PREFIX" , ""},
                { "ENDOSSOS_VAL_CUSTO_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R2530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_COD_FONTE" , ""},
                { "PARCELAS_NUM_TITULO" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "PARCELAS_OCORR_HISTORICO" , ""},
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PARCELAS_COD_EMPRESA" , ""},
                { "PARCELAS_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R2550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R2550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "NUMERCOS_SEQ_ORD_CEDIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1", q25);

            #endregion

            #region R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
                { "NUMERCOS_SEQ_ORD_CEDIDO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "NUMERCOS_SEQ_ORD_CEDIDO" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
                { "NUMERAES_ORGAO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "EMISSDIA_COD_RELATORIO" , ""},
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "EMISSDIA_ORGAO_EMISSOR" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "EMISSDIA_COD_FONTE" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
                { "EMISSDIA_COD_CORRETOR" , ""},
                { "EMISSDIA_SIT_REGISTRO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_COD_EMPRESA" , ""},
                { "APOLICOB_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_DTFATUR" , ""},
                { "VIND_NULL01" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R9000_00_INSERT_RELATORI_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9000_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q32);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SVA0141B_FILE_NAME_P.txt", "REDUX.PRD.VA.D240919.VA0140B.txt", "SAIDA01_FILE_NAME_P.txt")]
        public static void VA0141B_Tests_Theory(string SVA0141B_FILE_NAME_P, string ENTRADA1_FILE_NAME_P, string SAIDA01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0141B_FILE_NAME_P = $"{SVA0141B_FILE_NAME_P}_{timestamp}.txt";
            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
               q12.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_ENDOS_COBRANCA" , ""},
                { "NUMERAES_ENDOS_RESTITUICAO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1", q12);

                #endregion
                #region R0700_00_SELECT_FONTES_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0700_00_SELECT_FONTES_DB_SELECT_1_Query1");

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_FONTES_DB_SELECT_1_Query1", q13);

                #endregion
                #endregion
                var program = new VA0141B();
                program.Execute(SVA0141B_FILE_NAME_P, ENTRADA1_FILE_NAME_P, SAIDA01_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList1 = AppSettings.TestSet.DynamicData["R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("HISCONPA_NUM_CERTIFICADO", out var valor) && valor == "086426130000238");
                Assert.True(envList1[1].TryGetValue("HISCONPA_NUM_PARCELA", out valor) && valor == "0001");

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Theory]
        [InlineData("SVA0141B_FILE_NAME_P.txt", "PRD.VA.D240919.VA0140B.txt", "SAIDA01_FILE_NAME_P.txt")]
        public static void VA0141B_Tests_SemDados(string SVA0141B_FILE_NAME_P, string ENTRADA1_FILE_NAME_P, string SAIDA01_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0141B_FILE_NAME_P = $"{SVA0141B_FILE_NAME_P}_{timestamp}.txt";
            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA0141B();
                program.Execute(SVA0141B_FILE_NAME_P, ENTRADA1_FILE_NAME_P, SAIDA01_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}