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
using static Code.VG1613B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG1613B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG1613B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "1"},
                { "PARAMRAM_RAMO_AP" , "2"},
                { "PARAMRAM_RAMO_VGAPC" , "3"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "123"},
            });
            AppSettings.TestSet.DynamicData.Add("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-01-01"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2024-01-02"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "NUMEROUT_NUM_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PLANOFAI_PRM_VG" , ""},
                { "PLANOFAI_PRM_AP" , ""},
                { "PLANOFAI_FAIXA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PLANFSAL_PRM_VG" , ""},
                { "PLANFSAL_PRM_AP" , ""},
                { "PLANFSAL_FAIXA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PLANOVGA_COD_PLANO" , ""},
                { "PLANOVGA_DATA_INIVIGENCIA" , ""},
                { "PLANOVGA_IMP_MORNATU" , ""},
                { "PLANOVGA_IMP_MORACID" , ""},
                { "PLANOVGA_IMP_INVPERM" , ""},
                { "PLANOVGA_IMP_AMDS" , ""},
                { "PLANOVGA_IMP_DH" , ""},
                { "PLANOVGA_IMP_DIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1", q7);

            #endregion

            #region VG1613B_PLANOVGA1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PLANOVGA_COD_PLANO" , ""},
                { "PLANOVGA_DATA_INIVIGENCIA" , ""},
                { "PLANOVGA_IMP_MORNATU" , ""},
                { "PLANOVGA_IMP_MORACID" , ""},
                { "PLANOVGA_IMP_INVPERM" , ""},
                { "PLANOVGA_IMP_AMDS" , ""},
                { "PLANOVGA_IMP_DH" , ""},
                { "PLANOVGA_IMP_DIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1613B_PLANOVGA1", q8);

            #endregion

            #region VG1613B_SEGURVGA1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_TIPO_SEGURADO" , ""},
                { "SEGURVGA_PCT_CONJUGE_VG" , ""},
                { "SEGURVGA_PCT_CONJUGE_AP" , ""},
                { "SEGURVGA_TAXA_AP_MORACID" , ""},
                { "SEGURVGA_TAXA_AP_INVPERM" , ""},
                { "SEGURVGA_TAXA_AP_AMDS" , ""},
                { "SEGURVGA_TAXA_AP_DH" , ""},
                { "SEGURVGA_TAXA_AP_DIT" , ""},
                { "SEGURVGA_TAXA_AP" , ""},
                { "SEGURVGA_TAXA_VG" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1613B_SEGURVGA1", q9);

            #endregion

            #region R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PLANOMUL_QTD_SAL_MORNATU" , ""},
                { "PLANOMUL_QTD_SAL_MORACID" , ""},
                { "PLANOMUL_QTD_SAL_INVPERM" , ""},
                { "PLANOMUL_LIM_CAP_MORNATU" , ""},
                { "PLANOMUL_LIM_CAP_MORACID" , ""},
                { "PLANOMUL_LIM_CAP_INVAPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2080_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FAIXAETA_FAIXA" , ""},
                { "FAIXAETA_TAXA_VG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2080_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FAIXAETA_IDADE_FINAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FAIXASAL_FAIXA" , ""},
                { "FAIXASAL_TAXA_VG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "FAIXASAL_FAIXA" , ""},
                { "FAIXASAL_TAXA_VG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ORIG_PRODU" , "15"}
            });
            AppSettings.TestSet.DynamicData.Add("R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q15);

            #endregion

            #region VG1613B_CSUBGVGAP

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_NUM_APOLICE" , ""},
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1613B_CSUBGVGAP", q16);

            #endregion

            #region R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "ERROSVID_DESCR_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_ENDERECO" , ""},
                { "WHOST_OCORR_ENDERECO" , ""},
                { "WHOST_ENDERECO" , ""},
                { "WHOST_BAIRRO" , ""},
                { "WHOST_CIDADE" , ""},
                { "WHOST_SIGLA_UF" , ""},
                { "WHOST_CEP" , ""},
                { "WHOST_DDD" , ""},
                { "WHOST_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q18);

            #endregion

            #region R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
                { "SUBGVGAP_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1", q20);

            #endregion

            #region R2700_00_SELECT_PROPOSTA_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_PROPOSTA_DB_SELECT_2_Query1", q21);

            #endregion

            #region R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q22);

            #endregion

            #region R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1", q23);

            #endregion

            #region R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_NUM_APOLICE" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
                { "APOLICES_NUM_BILHETE" , ""},
                { "APOLICES_TIPO_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_TIPO_PLANO" , ""},
                { "SUBGVGAP_FORMA_AVERBACAO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_PERI_RENOVACAO" , ""},
                { "SUBGVGAP_BCO_COBRANCA" , ""},
                { "SUBGVGAP_AGE_COBRANCA" , ""},
                { "SUBGVGAP_DAC_COBRANCA" , ""},
                { "SUBGVGAP_PCT_CONJUGE_VG" , ""},
                { "SUBGVGAP_PCT_CONJUGE_AP" , ""},
                { "SUBGVGAP_IND_PLANO_ASSOCIA" , ""},
                { "SUBGVGAP_TIPO_COBRANCA" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q25);

            #endregion

            #region R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q26);

            #endregion

            #region R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_QTD_SAL_MORNATU" , ""},
                { "CONDITEC_QTD_SAL_MORACID" , ""},
                { "CONDITEC_QTD_SAL_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_MORACID" , ""},
                { "CONDITEC_TAXA_AP_INVPERM" , ""},
                { "CONDITEC_TAXA_AP_AMDS" , ""},
                { "CONDITEC_TAXA_AP_DH" , ""},
                { "CONDITEC_TAXA_AP_DIT" , ""},
                { "CONDITEC_TAXA_AP" , ""},
                { "CONDITEC_LIM_CAP_MORNATU" , ""},
                { "CONDITEC_LIM_CAP_MORACID" , ""},
                { "CONDITEC_LIM_CAP_INVAPER" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
                { "CONDITEC_GARAN_ADIC_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q27);

            #endregion

            #region R3230_00_SELECT_FONTE_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3230_00_SELECT_FONTE_DB_SELECT_1_Query1", q28);

            #endregion

            #region R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_INIVIGENCIA_APOL" , ""},
                { "WS_QTD_DIAS_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q29);

            #endregion

            #region R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PROP_AUTOMAT" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q31);

            #endregion

            #region R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_SIT_REGISTRO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_COD_EMPRESA" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_ESTADO_CIVIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R4210_00_MOVE_CLIENTE_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4210_00_MOVE_CLIENTE_DB_SELECT_1_Query1", q33);

            #endregion

            #region R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_IDE_SEXO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1", q34);

            #endregion

            #region R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1", q36);

            #endregion

            #region R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "ENDERECO_SIT_REGISTRO" , ""},
                { "ENDERECO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_APOLICE" , ""},
                { "MOVIMVGA_COD_SUBGRUPO" , ""},
                { "MOVIMVGA_COD_FONTE" , ""},
                { "MOVIMVGA_NUM_PROPOSTA" , ""},
                { "MOVIMVGA_TIPO_SEGURADO" , ""},
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_DAC_CERTIFICADO" , ""},
                { "MOVIMVGA_TIPO_INCLUSAO" , ""},
                { "MOVIMVGA_COD_CLIENTE" , ""},
                { "MOVIMVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_COD_CORRETOR" , ""},
                { "MOVIMVGA_COD_PLANOVGAP" , ""},
                { "MOVIMVGA_COD_PLANOAP" , ""},
                { "MOVIMVGA_FAIXA" , ""},
                { "MOVIMVGA_AUTOR_AUM_AUTOMAT" , ""},
                { "MOVIMVGA_TIPO_BENEFICIARIO" , ""},
                { "MOVIMVGA_PERI_PAGAMENTO" , ""},
                { "MOVIMVGA_PERI_RENOVACAO" , ""},
                { "MOVIMVGA_COD_OCUPACAO" , ""},
                { "MOVIMVGA_ESTADO_CIVIL" , ""},
                { "MOVIMVGA_IDE_SEXO" , ""},
                { "MOVIMVGA_COD_PROFISSAO" , ""},
                { "MOVIMVGA_NATURALIDADE" , ""},
                { "MOVIMVGA_OCORR_ENDERECO" , ""},
                { "MOVIMVGA_OCORR_END_COBRAN" , ""},
                { "MOVIMVGA_BCO_COBRANCA" , ""},
                { "MOVIMVGA_AGE_COBRANCA" , ""},
                { "MOVIMVGA_DAC_COBRANCA" , ""},
                { "MOVIMVGA_NUM_MATRICULA" , ""},
                { "MOVIMVGA_NUM_CTA_CORRENTE" , ""},
                { "MOVIMVGA_DAC_CTA_CORRENTE" , ""},
                { "MOVIMVGA_VAL_SALARIO" , ""},
                { "MOVIMVGA_TIPO_SALARIO" , ""},
                { "MOVIMVGA_TIPO_PLANO" , ""},
                { "MOVIMVGA_PCT_CONJUGE_VG" , ""},
                { "MOVIMVGA_PCT_CONJUGE_AP" , ""},
                { "MOVIMVGA_QTD_SAL_MORNATU" , ""},
                { "MOVIMVGA_QTD_SAL_MORACID" , ""},
                { "MOVIMVGA_QTD_SAL_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_MORACID" , ""},
                { "MOVIMVGA_TAXA_AP_INVPERM" , ""},
                { "MOVIMVGA_TAXA_AP_AMDS" , ""},
                { "MOVIMVGA_TAXA_AP_DH" , ""},
                { "MOVIMVGA_TAXA_AP_DIT" , ""},
                { "MOVIMVGA_TAXA_VG" , ""},
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ANT" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ANT" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_IMP_AMDS_ANT" , ""},
                { "MOVIMVGA_IMP_AMDS_ATU" , ""},
                { "MOVIMVGA_IMP_DH_ANT" , ""},
                { "MOVIMVGA_IMP_DH_ATU" , ""},
                { "MOVIMVGA_IMP_DIT_ANT" , ""},
                { "MOVIMVGA_IMP_DIT_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ANT" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "MOVIMVGA_PRM_AP_ANT" , ""},
                { "MOVIMVGA_PRM_AP_ATU" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "MOVIMVGA_DATA_OPERACAO" , ""},
                { "MOVIMVGA_COD_SUBGRUPO_TRANS" , ""},
                { "MOVIMVGA_SIT_REGISTRO" , ""},
                { "MOVIMVGA_COD_USUARIO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "MOVIMVGA_DATA_ADMISSAO" , ""},
                { "MOVIMVGA_DATA_INCLUSAO" , ""},
                { "MOVIMVGA_DATA_NASCIMENTO" , ""},
                { "MOVIMVGA_DATA_FATURA" , ""},
                { "MOVIMVGA_DATA_REFERENCIA" , ""},
                { "MOVIMVGA_DATA_MOVIMENTO" , ""},
                { "MOVIMVGA_COD_EMPRESA" , ""},
                { "MOVIMVGA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1", q39);

            #endregion
       

            #region R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , ""},
                { "NUMEROUT_NUM_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1", q41);

            #endregion

            VG0702S_Tests.Load_Parameters();
            VG0710S_Tests.Load_Parameters();
            #endregion
        }

        [Theory]
        [InlineData("Entrada_VG1613B.txt", "Sort_VG1613B.txt", "Saida_VG1613B_00.txt")]
        public static void VG1613B_Tests_Theory_SemRamo_ReturnCode_99(string ARQUIVO_LEITURA_FILE_NAME_P, string ARQUIVO_SORT_FILE_NAME_P, string ARQUIVO_RETORNO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQUIVO_SORT_FILE_NAME_P = $"{ARQUIVO_SORT_FILE_NAME_P}_{timestamp}.txt";
            ARQUIVO_RETORNO_FILE_NAME_P = $"{ARQUIVO_RETORNO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new VG1613B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P, ARQUIVO_SORT_FILE_NAME_P, ARQUIVO_RETORNO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

                Assert.True(File.Exists(program.ARQUIVO_LEITURA.FilePath));
                Assert.True(new FileInfo(program.ARQUIVO_LEITURA.FilePath)?.Length >= 0);

            }
        }
        [Theory]
        [InlineData("Entrada_VG1613B_empty.txt", "Sort_VG1613B.txt", "Saida_VG1613B_01.txt")]
        public static void VG1613B_Tests_Theory_ApoliceEmpresarial_ReturnCode_00(string ARQUIVO_LEITURA_FILE_NAME_P, string ARQUIVO_SORT_FILE_NAME_P, string ARQUIVO_RETORNO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQUIVO_SORT_FILE_NAME_P = $"{ARQUIVO_SORT_FILE_NAME_P}_{timestamp}.txt";
            ARQUIVO_RETORNO_FILE_NAME_P = $"{ARQUIVO_RETORNO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VG1613B_SEGURVGA1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "12"},
                { "SEGURVGA_NUM_APOLICE" , "19790324"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "1231"},
                { "SEGURVGA_NUM_CERTIFICADO" , "1979"},
                { "SEGURVGA_TIPO_SEGURADO" , "5"},
                { "SEGURVGA_PCT_CONJUGE_VG" , "30"},
                { "SEGURVGA_PCT_CONJUGE_AP" , "31"},
                { "SEGURVGA_TAXA_AP_MORACID" , "1"},
                { "SEGURVGA_TAXA_AP_INVPERM" , "3"},
                { "SEGURVGA_TAXA_AP_AMDS" , "5"},
                { "SEGURVGA_TAXA_AP_DH" , "7"},
                { "SEGURVGA_TAXA_AP_DIT" , "9"},
                { "SEGURVGA_TAXA_AP" , "11"},
                { "SEGURVGA_TAXA_VG" , "13"},
                { "ENDERECO_OCORR_ENDERECO" , "RUA SAO PAULO"},
                { "SEGURVGA_SIT_REGISTRO" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1613B_SEGURVGA1");
                AppSettings.TestSet.DynamicData.Add("VG1613B_SEGURVGA1", q9);
                #endregion
                #region VG1613B_CSUBGVGAP

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_NUM_APOLICE" , "19790324"},
                { "SUBGVGAP_COD_SUBGRUPO" , "77"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1613B_CSUBGVGAP");
                AppSettings.TestSet.DynamicData.Add("VG1613B_CSUBGVGAP", q16);

                #endregion
                #region R8100_00_PROCESSA_SUBGVGAP_DB_SELECT_1_Query1



                #endregion
                #region R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "FERNANDO SANTOS"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q31);
                #endregion

                #region R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "6"},
                { "PARAMRAM_RAMO_AP" , "7"},
                { "PARAMRAM_RAMO_VGAPC" , "3"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "456"},
                });
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "1"},
                { "PARAMRAM_RAMO_AP" , "2"},
                { "PARAMRAM_RAMO_VGAPC" , "3"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "123"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1", q0);

                #endregion
                #region R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ORIG_PRODU" , "GLOBAL"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q15);

                #endregion
                #region R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , "19790324"},
                { "NUMEROUT_NUM_CLIENTE" , "1979"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                var program = new VG1613B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P, ARQUIVO_SORT_FILE_NAME_P, ARQUIVO_RETORNO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);

                Assert.True(File.Exists(program.ARQUIVO_LEITURA.FilePath));
                Assert.True(new FileInfo(program.ARQUIVO_LEITURA.FilePath)?.Length >= 0);


                Assert.True(File.Exists(program.ARQUIVO_RETORNO.FilePath));
                Assert.True(new FileInfo(program.ARQUIVO_RETORNO.FilePath)?.Length >= 0);

                // R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("NUMEROUT_NUM_CERT_VGAP", out var val2r) && val2r.Contains("19790324"));
                Assert.True(envList1[1].TryGetValue("NUMEROUT_NUM_CLIENTE", out var val3r) && val3r.Contains("1979"));

            }
        }
        [Theory]
        [InlineData("Entrada_VG1613B_empty.txt", "Sort_VG1613B.txt", "Saida_VG1613B_02.txt")]
        public static void VG1613B_Tests_Theory_ReturnCode_00(string ARQUIVO_LEITURA_FILE_NAME_P, string ARQUIVO_SORT_FILE_NAME_P, string ARQUIVO_RETORNO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQUIVO_SORT_FILE_NAME_P = $"{ARQUIVO_SORT_FILE_NAME_P}_{timestamp}.txt";
            ARQUIVO_RETORNO_FILE_NAME_P = $"{ARQUIVO_RETORNO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VG1613B_SEGURVGA1
                /*
                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "12"},
                { "SEGURVGA_NUM_APOLICE" , "19790324"},
                { "SEGURVGA_NUM_ITEM" , "1"},
                { "SEGURVGA_OCORR_HISTORICO" , "1231"},
                { "SEGURVGA_NUM_CERTIFICADO" , "1979"},
                { "SEGURVGA_TIPO_SEGURADO" , "5"},
                { "SEGURVGA_PCT_CONJUGE_VG" , "30"},
                { "SEGURVGA_PCT_CONJUGE_AP" , "31"},
                { "SEGURVGA_TAXA_AP_MORACID" , "1"},
                { "SEGURVGA_TAXA_AP_INVPERM" , "3"},
                { "SEGURVGA_TAXA_AP_AMDS" , "5"},
                { "SEGURVGA_TAXA_AP_DH" , "7"},
                { "SEGURVGA_TAXA_AP_DIT" , "9"},
                { "SEGURVGA_TAXA_AP" , "11"},
                { "SEGURVGA_TAXA_VG" , "13"},
                { "ENDERECO_OCORR_ENDERECO" , "RUA SAO PAULO"},
                { "SEGURVGA_SIT_REGISTRO" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1613B_SEGURVGA1");
                AppSettings.TestSet.DynamicData.Add("VG1613B_SEGURVGA1", q15);
                */
                #endregion
                #region VG1613B_CSUBGVGAP

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_NUM_APOLICE" , "19790324"},
                { "SUBGVGAP_COD_SUBGRUPO" , "77"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1613B_CSUBGVGAP");
                AppSettings.TestSet.DynamicData.Add("VG1613B_CSUBGVGAP", q16);

                #endregion
                
                #region R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "FERNANDO SANTOS"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q31);
                #endregion

                #region R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "6"},
                { "PARAMRAM_RAMO_AP" , "7"},
                { "PARAMRAM_RAMO_VGAPC" , "3"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "456"},
                });
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "1"},
                { "PARAMRAM_RAMO_AP" , "2"},
                { "PARAMRAM_RAMO_VGAPC" , "3"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "123"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1", q0);

                #endregion
                #region R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_CERT_VGAP" , "19790324"},
                { "NUMEROUT_NUM_CLIENTE" , "1979"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1", q2);

                #endregion
                #region VG1613B_SEGURVGA1

                var q9 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG1613B_SEGURVGA1");
                AppSettings.TestSet.DynamicData.Add("VG1613B_SEGURVGA1", q9);
                #endregion
                #region R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "321"},
                { "APOLICES_NUM_APOLICE" , "19790324"},
                { "APOLICES_COD_MODALIDADE" , "01"},
                { "APOLICES_ORGAO_EMISSOR" , "SSP"},
                { "APOLICES_RAMO_EMISSOR" , "1"},
                { "APOLICES_COD_PRODUTO" , "654"},
                { "APOLICES_NUM_BILHETE" , "852"},
                { "APOLICES_TIPO_APOLICE" , "44"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1", q24);

                #endregion
                #region R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_FONTE" , "12"},
                { "SUBGVGAP_TIPO_PLANO" , "5"},
                { "SUBGVGAP_FORMA_AVERBACAO" , "3"},
                { "SUBGVGAP_TIPO_FATURAMENTO" , "6"},
                { "SUBGVGAP_PERI_FATURAMENTO" , "2024-10-10"},
                { "SUBGVGAP_PERI_RENOVACAO" , "2024-01-01"},
                { "SUBGVGAP_BCO_COBRANCA" , "237"},
                { "SUBGVGAP_AGE_COBRANCA" , "001"},
                { "SUBGVGAP_DAC_COBRANCA" , "1"},
                { "SUBGVGAP_PCT_CONJUGE_VG" , "2"},
                { "SUBGVGAP_PCT_CONJUGE_AP" , "3"},
                { "SUBGVGAP_IND_PLANO_ASSOCIA" , "1"},
                { "SUBGVGAP_TIPO_COBRANCA" , "4"},
                { "SUBGVGAP_COD_CLIENTE" , "3"},
                { "SUBGVGAP_OCORR_ENDERECO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q25);

                #endregion
                #region R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PLANOVGA_COD_PLANO" , "1"},
                { "PLANOVGA_DATA_INIVIGENCIA" , "2023-01-01"},
                { "PLANOVGA_IMP_MORNATU" , "2"},
                { "PLANOVGA_IMP_MORACID" , "4"},
                { "PLANOVGA_IMP_INVPERM" , "6"},
                { "PLANOVGA_IMP_AMDS" , "9"},
                { "PLANOVGA_IMP_DH" , "5"},
                { "PLANOVGA_IMP_DIT" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1", q7);

                #endregion
                #region R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "PAULO OLIVEIRA"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q26);

                #endregion
                #region R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_QTD_SAL_MORNATU" , "2"},
                { "CONDITEC_QTD_SAL_MORACID" , "2"},
                { "CONDITEC_QTD_SAL_INVPERM" , "2"},
                { "CONDITEC_TAXA_AP_MORACID" , "12"},
                { "CONDITEC_TAXA_AP_INVPERM" , "12"},
                { "CONDITEC_TAXA_AP_AMDS" , "12"},
                { "CONDITEC_TAXA_AP_DH" , "12"},
                { "CONDITEC_TAXA_AP_DIT" , "12"},
                { "CONDITEC_TAXA_AP" , "12"},
                { "CONDITEC_LIM_CAP_MORNATU" , "7"},
                { "CONDITEC_LIM_CAP_MORACID" , "7"},
                { "CONDITEC_LIM_CAP_INVAPER" , "7"},
                { "CONDITEC_GARAN_ADIC_IEA" , "7"},
                { "CONDITEC_GARAN_ADIC_IPA" , "7"},
                { "CONDITEC_GARAN_ADIC_IPD" , "7"},
                { "CONDITEC_GARAN_ADIC_HD" , "7"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q27);

                #endregion

                #region R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_ENDERECO" , "2"},
                { "WHOST_OCORR_ENDERECO" , "4"},
                { "WHOST_ENDERECO" , "RUA SEQUOIA"},
                { "WHOST_BAIRRO" , "JARDIM HORTENCIA"},
                { "WHOST_CIDADE" , "SÃO PAULO"},
                { "WHOST_SIGLA_UF" , "SP"},
                { "WHOST_CEP" , "1111111"},
                { "WHOST_DDD" , "11"},
                { "WHOST_TELEFONE" , "33331111"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q18);
                #endregion

                #region R3230_00_SELECT_FONTE_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , "FONTE"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3230_00_SELECT_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3230_00_SELECT_FONTE_DB_SELECT_1_Query1", q28);

                #endregion

                #region R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "FAIXASAL_FAIXA" , "10000"},
                { "FAIXASAL_TAXA_VG" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1", q13);

                #endregion

                #endregion
                var program = new VG1613B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P, ARQUIVO_SORT_FILE_NAME_P, ARQUIVO_RETORNO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);

                Assert.True(File.Exists(program.ARQUIVO_LEITURA.FilePath));
                Assert.True(new FileInfo(program.ARQUIVO_LEITURA.FilePath)?.Length >= 0);


                Assert.True(File.Exists(program.ARQUIVO_RETORNO.FilePath));
                Assert.True(new FileInfo(program.ARQUIVO_RETORNO.FilePath)?.Length >= 0);

                //R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("SUBGVGAP_COD_SUBGRUPO", out var val0r) && val0r.Contains("77"));
                Assert.True(envList0[1].TryGetValue("SUBGVGAP_NUM_APOLICE", out var val1r) && val1r.Contains("19790324"));

                //R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("CLIENTES_CGCCPF", out var val2r) && val2r.Contains("10600871622"));
                Assert.True(envList1[1].TryGetValue("CLIENTES_NOME_RAZAO", out var val3r) && val3r.Contains("DAIANNA SILVA LANA"));

                //R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("ENDERECO_ENDERECO", out var val4r) && val4r.Contains("RUA SEQUOIA"));
                Assert.True(envList2[1].TryGetValue("ENDERECO_BAIRRO", out var val5r) && val5r.Contains("JARDIM HORTENCIA"));

                //R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("SUBGVGAP_COD_FONTE", out var val6r) && val6r.Contains("12"));

                //R4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("MOVIMVGA_NUM_APOLICE", out var val7r) && val7r.Contains("3009300008113"));
                Assert.True(envList4[1].TryGetValue("MOVIMVGA_COD_FONTE", out var val8r) && val8r.Contains("12"));

                //R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5.Count > 1);
                Assert.True(envList5[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var val9r) && val9r.Contains("2024-01-01"));
                Assert.True(envList5[1].TryGetValue("RELATORI_NUM_APOLICE", out var val10r) && val10r.Contains("3009300008113"));


            }
        }
    }
}