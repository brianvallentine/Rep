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
using static Code.BI0070B;

namespace FileTests.Test
{
    [Collection("BI0070B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0070B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRENT" , ""},
                { "SISTEMA_DTTERCOT" , ""},
                { "SISTEMA_DTINICOT" , ""},
                { "SISTEMA_DTMOV01M" , ""},
                { "SISTEMA_DTMOV20D" , ""},
                { "SISTEMA_DTMOV10D" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI0070B_V0COTACAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0070B_V0COTACAO", q2);

            #endregion

            #region BI0070B_V0MOVDEBCE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_PROXVEN" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0070B_V0MOVDEBCE", q3);

            #endregion

            #region R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "WSGER00_DATA_INIVIGENCIA" , ""},
                { "WSGER00_DATA_TERVIGENCIA" , ""},
                { "WSGER00_DATA_CORRETOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "APOLCOBR_COD_AGENCIA" , ""},
                { "APOLCOBR_COD_AGENCIA_DEB" , ""},
                { "APOLCOBR_OPER_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CONTA_DEB" , ""},
                { "APOLCOBR_DIG_CONTA_DEB" , ""},
                { "APOLCOBR_NUM_CARTAO" , ""},
                { "APOLCOBR_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
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
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_COD_EMPRESA" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_ISENTA_CUSTO" , ""},
                { "ENDOSSOS_COEF_PREFIX" , ""},
                { "ENDOSSOS_VAL_CUSTO_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
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
            });
            AppSettings.TestSet.DynamicData.Add("R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_COD_FONTE" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1200_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_FONTES_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2100_00_INSERT_APOLICOR_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_NUM_APOLICE" , ""},
                { "APOLICOR_RAMO_COBERTURA" , ""},
                { "APOLICOR_MODALI_COBERTURA" , ""},
                { "APOLICOR_COD_CORRETOR" , ""},
                { "APOLICOR_COD_SUBGRUPO" , ""},
                { "APOLICOR_DATA_INIVIGENCIA" , ""},
                { "APOLICOR_DATA_TERVIGENCIA" , ""},
                { "APOLICOR_PCT_PART_CORRETOR" , ""},
                { "APOLICOR_PCT_COM_CORRETOR" , ""},
                { "APOLICOR_TIPO_COMISSAO" , ""},
                { "APOLICOR_IND_CORRETOR_PRIN" , ""},
                { "APOLICOR_COD_EMPRESA" , ""},
                { "APOLICOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_APOLICOR_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "MOVDEBCE_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q24);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0070B_Tests_Fact()
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
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "2"}
                });
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1", q1);

                AppSettings.TestSet.DynamicData.Remove("BI0070B_V0COTACAO");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , "100"},
                });
                AppSettings.TestSet.DynamicData.Add("BI0070B_V0COTACAO", q2);

                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_SITUACAO" , "9"},
                { "WSGER00_DATA_INIVIGENCIA" , ""},
                { "WSGER00_DATA_TERVIGENCIA" , ""},
                { "WSGER00_DATA_CORRETOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);


                
                #endregion
                var program = new BI0070B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);

                Assert.True(envList[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out var val1r) && val1r.Equals("000000002"));
                Assert.True(envList1[1].TryGetValue("ENDOSSOS_NUM_APOLICE", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList2[1].TryGetValue("PARCELAS_NUM_APOLICE", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList3[1].TryGetValue("PARCEHIS_COD_USUARIO", out val1r) && val1r.Equals("BI0070B "));
                Assert.True(envList4[1].TryGetValue("APOLICOB_NUM_ITEM", out val1r) && val1r.Equals("000000000"));
                Assert.True(envList5[1].TryGetValue("PARCELAS_PRM_TOTAL_IX", out val1r) && val1r.Equals("0000000000.00000"));
                Assert.True(envList6[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out val1r) && val1r.Equals("0000000000000"));
                Assert.True(envList7[1].TryGetValue("MOVDEBCE_SITUACAO_COBRANCA", out val1r) && val1r.Equals("6"));
            }
        }

        [Fact]
        public static void BI0070B_Tests_Fact_NUM_ENDOSSO()
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
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "2"}
                });
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1", q1);

                AppSettings.TestSet.DynamicData.Remove("BI0070B_V0COTACAO");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , "100"},
                });
                AppSettings.TestSet.DynamicData.Add("BI0070B_V0COTACAO", q2);

                AppSettings.TestSet.DynamicData.Remove("R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_SITUACAO" , "9"},
                { "WSGER00_DATA_INIVIGENCIA" , ""},
                { "WSGER00_DATA_TERVIGENCIA" , ""},
                { "WSGER00_DATA_CORRETOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1", q4);

                AppSettings.TestSet.DynamicData.Remove("BI0070B_V0MOVDEBCE");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , "25"},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_PROXVEN" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("BI0070B_V0MOVDEBCE", q3);

                #endregion
                var program = new BI0070B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("RELATORI_NUM_ENDOSSO", out var val1r) && val1r.Equals("000000025"));

            }
        }

        [Fact]
        public static void BI0070B_Tests_Fact_UPDATE_MOVDEBCE()
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
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "2"}
                });
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1", q1);

                AppSettings.TestSet.DynamicData.Remove("BI0070B_V0COTACAO");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , "100"},
                });
                AppSettings.TestSet.DynamicData.Add("BI0070B_V0COTACAO", q2);

                #endregion
                var program = new BI0070B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var val1r) && val1r.Equals("000000000"));
            }
        }
    }
}