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
using static Code.VG1601B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG1601B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1601B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region VG1601B_CSEGURA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                {"SEGURVGA_NUM_APOLICE" , "81010000020"},
                {"SEGURVGA_COD_SUBGRUPO" , "1"},
                {"SEGURVGA_NUM_CERTIFICADO" , "10001015850"},
                {"SEGURVGA_DAC_CERTIFICADO" , "1"},
                {"SEGURVGA_TIPO_SEGURADO" , "1"},
                {"SEGURVGA_NUM_ITEM" , "3"},
                {"SEGURVGA_TIPO_INCLUSAO" , "1"},
                {"SEGURVGA_COD_CLIENTE" , "1274813"},
                {"SEGURVGA_COD_FONTE" , "27"},
                {"SEGURVGA_NUM_PROPOSTA" , "473719"},
                {"SEGURVGA_COD_AGENCIADOR" , "0"},
                {"SEGURVGA_COD_CORRETOR" , "0"},
                {"SEGURVGA_COD_PLANOVGAP" , "0"},
                {"SEGURVGA_COD_PLANOAP" , "0"},
                {"SEGURVGA_FAIXA" , "0"},
                {"SEGURVGA_AUTOR_AUM_AUTOMAT" , " "},
                {"SEGURVGA_TIPO_BENEFICIARIO" , "S"},
                {"SEGURVGA_OCORR_HISTORICO" , "1"},
                {"SEGURVGA_PERI_PAGAMENTO" , "0"},
                {"SEGURVGA_PERI_RENOVACAO" , "0"},
                {"SEGURVGA_NUM_CARNE" , "0"},
                {"SEGURVGA_COD_OCUPACAO" , "    "},
                {"SEGURVGA_ESTADO_CIVIL" , " "},
                {"SEGURVGA_IDE_SEXO" , "M"},
                {"SEGURVGA_COD_PROFISSAO" , "0"},
                {"SEGURVGA_NATURALIDADE" , "                              "},
                {"SEGURVGA_OCORR_ENDERECO" , "1"},
                {"SEGURVGA_OCORR_END_COBRAN" , "1"},
                {"SEGURVGA_BCO_COBRANCA" , "0"},
                {"SEGURVGA_AGE_COBRANCA" , "0"},
                {"SEGURVGA_DAC_COBRANCA" , " "},
                {"SEGURVGA_NUM_MATRICULA" , "0"},
                {"SEGURVGA_VAL_SALARIO" , "0.00"},
                {"SEGURVGA_TIPO_SALARIO" , " "},
                {"SEGURVGA_TIPO_PLANO" , "1"},
                {"SEGURVGA_DATA_INIVIGENCIA" , "1992-01-05"},
                {"SEGURVGA_PCT_CONJUGE_VG" , "0.00"},
                {"SEGURVGA_PCT_CONJUGE_AP" , "0.00"},
                {"SEGURVGA_QTD_SAL_MORNATU" , "0"},
                {"SEGURVGA_QTD_SAL_MORACID" , "0"},
                {"SEGURVGA_QTD_SAL_INVPERM" , "0"},
                {"SEGURVGA_TAXA_AP_MORACID" , "0.0310"},
                {"SEGURVGA_TAXA_AP_INVPERM" , "0.0620"},
                {"SEGURVGA_TAXA_AP_AMDS" , "0.0000"},
                {"SEGURVGA_TAXA_AP_DH" , "0.0000"},
                {"SEGURVGA_TAXA_AP_DIT" , "0.0000"},
                {"SEGURVGA_TAXA_AP" , "0.0000"},
                {"SEGURVGA_TAXA_VG" , "0.0000"},
                {"SEGURVGA_SIT_REGISTRO" , "1"},
                {"SEGURVGA_DATA_ADMISSAO" , ""},
                {"SEGURVGA_DATA_NASCIMENTO" , "1975-10-14"},
                {"SEGURVGA_COD_EMPRESA" , "3"},
                {"SEGURVGA_LOT_EMP_SEGURADO" , "3"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                {"SEGURVGA_NUM_APOLICE" , "81010000001"},
                {"SEGURVGA_COD_SUBGRUPO" , "1"},
                {"SEGURVGA_NUM_CERTIFICADO" , "10001015855"},
                {"SEGURVGA_DAC_CERTIFICADO" , "1"},
                {"SEGURVGA_TIPO_SEGURADO" , "1"},
                {"SEGURVGA_NUM_ITEM" , "3"},
                {"SEGURVGA_TIPO_INCLUSAO" , "1"},
                {"SEGURVGA_COD_CLIENTE" , "1274813"},
                {"SEGURVGA_COD_FONTE" , "27"},
                {"SEGURVGA_NUM_PROPOSTA" , "473719"},
                {"SEGURVGA_COD_AGENCIADOR" , "0"},
                {"SEGURVGA_COD_CORRETOR" , "0"},
                {"SEGURVGA_COD_PLANOVGAP" , "0"},
                {"SEGURVGA_COD_PLANOAP" , "0"},
                {"SEGURVGA_FAIXA" , "0"},
                {"SEGURVGA_AUTOR_AUM_AUTOMAT" , " "},
                {"SEGURVGA_TIPO_BENEFICIARIO" , "S"},
                {"SEGURVGA_OCORR_HISTORICO" , "1"},
                {"SEGURVGA_PERI_PAGAMENTO" , "0"},
                {"SEGURVGA_PERI_RENOVACAO" , "0"},
                {"SEGURVGA_NUM_CARNE" , "0"},
                {"SEGURVGA_COD_OCUPACAO" , "    "},
                {"SEGURVGA_ESTADO_CIVIL" , " "},
                {"SEGURVGA_IDE_SEXO" , "M"},
                {"SEGURVGA_COD_PROFISSAO" , "0"},
                {"SEGURVGA_NATURALIDADE" , "                              "},
                {"SEGURVGA_OCORR_ENDERECO" , "1"},
                {"SEGURVGA_OCORR_END_COBRAN" , "1"},
                {"SEGURVGA_BCO_COBRANCA" , "0"},
                {"SEGURVGA_AGE_COBRANCA" , "0"},
                {"SEGURVGA_DAC_COBRANCA" , " "},
                {"SEGURVGA_NUM_MATRICULA" , "0"},
                {"SEGURVGA_VAL_SALARIO" , "0.00"},
                {"SEGURVGA_TIPO_SALARIO" , " "},
                {"SEGURVGA_TIPO_PLANO" , "1"},
                {"SEGURVGA_DATA_INIVIGENCIA" , "1992-01-05"},
                {"SEGURVGA_PCT_CONJUGE_VG" , "0.00"},
                {"SEGURVGA_PCT_CONJUGE_AP" , "0.00"},
                {"SEGURVGA_QTD_SAL_MORNATU" , "0"},
                {"SEGURVGA_QTD_SAL_MORACID" , "0"},
                {"SEGURVGA_QTD_SAL_INVPERM" , "0"},
                {"SEGURVGA_TAXA_AP_MORACID" , "0.0310"},
                {"SEGURVGA_TAXA_AP_INVPERM" , "0.0620"},
                {"SEGURVGA_TAXA_AP_AMDS" , "0.0000"},
                {"SEGURVGA_TAXA_AP_DH" , "0.0000"},
                {"SEGURVGA_TAXA_AP_DIT" , "0.0000"},
                {"SEGURVGA_TAXA_AP" , "0.0000"},
                {"SEGURVGA_TAXA_VG" , "0.0000"},
                {"SEGURVGA_SIT_REGISTRO" , "1"},
                {"SEGURVGA_DATA_ADMISSAO" , ""},
                {"SEGURVGA_DATA_NASCIMENTO" , "1975-10-14"},
                {"SEGURVGA_COD_EMPRESA" , "3"},
                {"SEGURVGA_LOT_EMP_SEGURADO" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("VG1601B_CSEGURA", q0);

            #endregion

            #region M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-02"},
                { "SISTEMAS_DATA_MOVIMENTO" , "2021-01-02"},
            });
            AppSettings.TestSet.DynamicData.Add("M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "97"},
                { "PARAMRAM_RAMO_VG" , "93"},
                { "PARAMRAM_RAMO_AP" , "82"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "97"},
                { "PARAMRAM_RAMO_VG" , "93"},
                { "PARAMRAM_RAMO_AP" , "82"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "97"},
                { "PARAMRAM_RAMO_VG" , "93"},
                { "PARAMRAM_RAMO_AP" , "82"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "97"},
                { "PARAMRAM_RAMO_VG" , "93"},
                { "PARAMRAM_RAMO_AP" , "82"},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "77"},
            });
            AppSettings.TestSet.DynamicData.Add("M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_050_000_PROCESSA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_COD_OPERACAO" , "501"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_COD_OPERACAO" , "501"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_COD_OPERACAO" , "501"}
            });
            AppSettings.TestSet.DynamicData.Add("M_050_000_PROCESSA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , "1"},
                { "APOL_NUM_APOLICE" , "11001001961"},
                { "APOL_MODALIDA" , "0"},
                { "APOL_ORGAO" , "10"},
                { "APOL_RAMO" , "11"},
                { "APOL_NUMBIL" , "0"},
                { "APOL_TIPAPO" , "2"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , "1"},
                { "APOL_NUM_APOLICE" , "11001001961"},
                { "APOL_MODALIDA" , "0"},
                { "APOL_ORGAO" , "10"},
                { "APOL_RAMO" , "11"},
                { "APOL_NUMBIL" , "0"},
                { "APOL_TIPAPO" , "2"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , "1"},
                { "APOL_NUM_APOLICE" , "11001001961"},
                { "APOL_MODALIDA" , "0"},
                { "APOL_ORGAO" , "10"},
                { "APOL_RAMO" , "11"},
                { "APOL_NUMBIL" , "0"},
                { "APOL_TIPAPO" , "2"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , "1"},
                { "APOL_NUM_APOLICE" , "11001001961"},
                { "APOL_MODALIDA" , "0"},
                { "APOL_ORGAO" , "10"},
                { "APOL_RAMO" , "11"},
                { "APOL_NUMBIL" , "0"},
                { "APOL_TIPAPO" , "2"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , "1"},
                { "APOL_NUM_APOLICE" , "11001001961"},
                { "APOL_MODALIDA" , "0"},
                { "APOL_ORGAO" , "10"},
                { "APOL_RAMO" , "11"},
                { "APOL_NUMBIL" , "0"},
                { "APOL_TIPAPO" , "2"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "APOL_COD_CLIENTE" , "1"},
                { "APOL_NUM_APOLICE" , "11001001961"},
                { "APOL_MODALIDA" , "0"},
                { "APOL_ORGAO" , "10"},
                { "APOL_RAMO" , "11"},
                { "APOL_NUMBIL" , "0"},
                { "APOL_TIPAPO" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUBG_COD_FONTE" , "21"},
                { "SUBG_TIPO_PLANO" , "1"},
                { "SUBG_FORMA_AVERBA" , "1"},
                { "SUBG_PERI_FATURAMENTO" , "0"},
                { "SUBG_PERI_RENOVACAO" , "12"},
                { "SUBG_BCO_COBRANCA" , "104"},
                { "SUBG_AGE_COBRANCA" , "630"},
                { "SUBG_DAC_COBRANCA" , "1"},
                { "SUBG_PCT_CONJUGE_VG" , "0"},
                { "SUBG_PCT_CONJUGE_AP" , "0"},
                { "SUBG_PLANO_ASSOCIA" , "N"},
                { "SUBG_TIPO_COBRANCA" , "2"},
                { "SUBG_COD_CLIENTE" , "179642"},
                { "SUBG_OCORR_ENDERECO" , "1"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUBG_COD_FONTE" , "21"},
                { "SUBG_TIPO_PLANO" , "1"},
                { "SUBG_FORMA_AVERBA" , "1"},
                { "SUBG_PERI_FATURAMENTO" , "0"},
                { "SUBG_PERI_RENOVACAO" , "12"},
                { "SUBG_BCO_COBRANCA" , "104"},
                { "SUBG_AGE_COBRANCA" , "630"},
                { "SUBG_DAC_COBRANCA" , "1"},
                { "SUBG_PCT_CONJUGE_VG" , "0"},
                { "SUBG_PCT_CONJUGE_AP" , "0"},
                { "SUBG_PLANO_ASSOCIA" , "N"},
                { "SUBG_TIPO_COBRANCA" , "2"},
                { "SUBG_COD_CLIENTE" , "179642"},
                { "SUBG_OCORR_ENDERECO" , "1"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUBG_COD_FONTE" , "21"},
                { "SUBG_TIPO_PLANO" , "1"},
                { "SUBG_FORMA_AVERBA" , "1"},
                { "SUBG_PERI_FATURAMENTO" , "0"},
                { "SUBG_PERI_RENOVACAO" , "12"},
                { "SUBG_BCO_COBRANCA" , "104"},
                { "SUBG_AGE_COBRANCA" , "630"},
                { "SUBG_DAC_COBRANCA" , "1"},
                { "SUBG_PCT_CONJUGE_VG" , "0"},
                { "SUBG_PCT_CONJUGE_AP" , "0"},
                { "SUBG_PLANO_ASSOCIA" , "N"},
                { "SUBG_TIPO_COBRANCA" , "2"},
                { "SUBG_COD_CLIENTE" , "179642"},
                { "SUBG_OCORR_ENDERECO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "FATCON_NUM_APOL" , "81010000001"},
                { "FATCON_COD_SUBG" , "0"},
                { "FATCON_DATA_REFER" , "1995-01-01"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "FATCON_NUM_APOL" , "81010000001"},
                { "FATCON_COD_SUBG" , "0"},
                { "FATCON_DATA_REFER" , "1995-01-01"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "FATCON_NUM_APOL" , "81010000001"},
                { "FATCON_COD_SUBG" , "0"},
                { "FATCON_DATA_REFER" , "1995-01-01"},
            });
            AppSettings.TestSet.DynamicData.Add("M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_SEGVG" , "359"}
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_SEGVG" , "359"}
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_SEGVG" , "359"}
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_SEGVG" , "359"}
            });
            AppSettings.TestSet.DynamicData.Add("M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_505_000_LER_V1SUBGRUPO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "1998-10-01"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "1998-10-01"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "1998-10-01"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , "1998-10-01"}
            });
            AppSettings.TestSet.DynamicData.Add("M_505_000_LER_V1SUBGRUPO_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_520_000_ACESSA_FONTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "9019777"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "9019777"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "9019777"}
            });
            AppSettings.TestSet.DynamicData.Add("M_520_000_ACESSA_FONTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "FONTE_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1", q11);

            #endregion

            #region M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CNUM_APOLICE" , "6501000001"},
                { "CNRENDOS" , "200001"},
                { "CNUM_ITEM" , "0"},
                { "COCORHIST" , "1"},
                { "CRAMOFR" , "68"},
                { "CMODALIFR" , "0"},
                { "CCOD_COBERTURA" , "0"},
                { "CIMP_SEGURADA_IX" , "155512600.91"},
                { "CPRM_TARIFARIO_IX" , "49151.79000"},
                { "CFATOR_MULTIPLICA" , "1"},
                { "CDATA_INIVIGENCIA" , "1999-01-01"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "CNUM_APOLICE" , "6501000001"},
                { "CNRENDOS" , "200001"},
                { "CNUM_ITEM" , "0"},
                { "COCORHIST" , "1"},
                { "CRAMOFR" , "68"},
                { "CMODALIFR" , "0"},
                { "CCOD_COBERTURA" , "0"},
                { "CIMP_SEGURADA_IX" , "155512600.91"},
                { "CPRM_TARIFARIO_IX" , "49151.79000"},
                { "CFATOR_MULTIPLICA" , "1"},
                { "CDATA_INIVIGENCIA" , "1999-01-01"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "CNUM_APOLICE" , "6501000001"},
                { "CNRENDOS" , "200001"},
                { "CNUM_ITEM" , "0"},
                { "COCORHIST" , "1"},
                { "CRAMOFR" , "68"},
                { "CMODALIFR" , "0"},
                { "CCOD_COBERTURA" , "0"},
                { "CIMP_SEGURADA_IX" , "155512600.91"},
                { "CPRM_TARIFARIO_IX" , "49151.79000"},
                { "CFATOR_MULTIPLICA" , "1"},
                { "CDATA_INIVIGENCIA" , "1999-01-01"},
            });
            AppSettings.TestSet.DynamicData.Add("M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "ECOD_MOEDA_IMP" , "1"},
                { "ECOD_MOEDA_PRM" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "ECOD_MOEDA_IMP" , "1"},
                { "ECOD_MOEDA_PRM" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "ECOD_MOEDA_IMP" , "1"},
                { "ECOD_MOEDA_PRM" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , "46396"}
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , "46396"}
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , "46396"}
            });
            AppSettings.TestSet.DynamicData.Add("M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_830_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , "46396"}
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , "46396"}
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , "46396"}
            });
            AppSettings.TestSet.DynamicData.Add("M_830_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1", q15);

            #endregion

            #region M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OCOD_CLIENTE" , "1627"},
                { "ONUM_APOLICE" , "109300000909"},
                { "OCOD_BANCO" , "104"},
                { "OCOD_AGENCIA" , "100"},
                { "ONUM_CTA_CORRENTE" , "3000000000044"},
                { "ODAC_CTA_CORRENTE" , "9"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OCOD_CLIENTE" , "1627"},
                { "ONUM_APOLICE" , "109300000909"},
                { "OCOD_BANCO" , "104"},
                { "OCOD_AGENCIA" , "100"},
                { "ONUM_CTA_CORRENTE" , "3000000000044"},
                { "ODAC_CTA_CORRENTE" , "9"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OCOD_CLIENTE" , "1627"},
                { "ONUM_APOLICE" , "109300000909"},
                { "OCOD_BANCO" , "104"},
                { "OCOD_AGENCIA" , "100"},
                { "ONUM_CTA_CORRENTE" , "3000000000044"},
                { "ODAC_CTA_CORRENTE" , "9"},
            });
            AppSettings.TestSet.DynamicData.Add("M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1", q16);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_VG1601B.txt")]
        public static void VG1601B_Tests_TheorySemProcessa(string ARQUIVO_LEITURA_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_050_000_PROCESSA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_050_000_PROCESSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_050_000_PROCESSA_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new VG1601B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 0);
                //m_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("FONTE_PROPAUTOM", out var val8r) && val8r.Contains("9019778"));
                Assert.True(envList1[1].TryGetValue("FONTE_FONTE", out var val9r) && val9r.Contains("27"));

                //M_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["M_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("MOVIMVGA_NUM_APOLICE", out var val1r) && val1r.Contains("81010000020"));
                Assert.True(envList2[1].TryGetValue("MOVIMVGA_COD_SUBGRUPO", out var val2r) && val2r.Contains("1"));


            }
        }

        [Theory]
        [InlineData("Entrada_VG1601B.txt")]
        public static void VG1601B_Tests_TheoryComProcessa(string ARQUIVO_LEITURA_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_050_000_PROCESSA_DB_SELECT_1_Query1

                //var q3 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("M_050_000_PROCESSA_DB_SELECT_1_Query1");
                //AppSettings.TestSet.DynamicData.Add("M_050_000_PROCESSA_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new VG1601B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQUIVO_LEITURA.FilePath));
                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("Entrada_VG1601B.txt")]
        public static void VG1601B_Tests_TheoryErro99(string ARQUIVO_LEITURA_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new VG1601B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 99);



            }
        }
    }
}