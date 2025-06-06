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
using static Code.VG0105B;

namespace FileTests.Test
{
    [Collection("VG0105B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0105B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1PRAMO_RAMO_VG" , ""},
                { "V1PRAMO_RAMO_AP" , ""},
                { "V1PRAMO_RAMO_VGAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NUM_TERMO" , ""},
                { "COD_SUBGRUPO" , ""},
                { "DATA_ADESAO" , ""},
                { "PERI_PAGTO" , ""},
                { "MODALIDADE_CAPITAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG0105B_V1SOLICFAT

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1SOLF_NUM_APOL" , ""},
                { "V1SOLF_COD_SUBG" , ""},
                { "V1SOLF_NUM_FAT" , ""},
                { "V1SOLF_NUM_RCAP" , ""},
                { "V1SOLF_VAL_RCAP" , ""},
                { "V1SOLF_COD_OPER" , ""},
                { "V1SOLF_SIT_REG" , ""},
                { "V1SOLF_DATA_RCAP" , ""},
                { "V1SOLF_DATA_VENC" , ""},
                { "V1SOLF_DATA_SOLI" , ""},
                { "V1SOLF_COD_USUAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0105B_V1SOLICFAT", q3);

            #endregion

            #region VG0105B_V1FATTOT

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUM_APOL" , ""},
                { "V1FATT_COD_SUBG" , ""},
                { "V1FATT_NUM_FATUR" , ""},
                { "V1FATT_COD_OPER" , ""},
                { "V1FATT_QT_VIDA_VG" , ""},
                { "V1FATT_QT_VIDA_AP" , ""},
                { "V1FATT_IMP_MORNAT" , ""},
                { "V1FATT_IMP_MORACI" , ""},
                { "V1FATT_IMP_INVPER" , ""},
                { "V1FATT_IMP_AMDS" , ""},
                { "V1FATT_IMP_DH" , ""},
                { "V1FATT_IMP_DIT" , ""},
                { "V1FATT_PRM_VG" , ""},
                { "V1FATT_PRM_AP" , ""},
                { "V1FATT_SIT_REG" , ""},
                { "V1FATT_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0105B_V1FATTOT", q4);

            #endregion

            #region R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_TIPO_FAT" , ""},
                { "V1SUBG_COD_FONTE" , ""},
                { "V1SUBG_COD_SUBG" , ""},
                { "V1SUBG_END_COB" , ""},
                { "V1SUBG_BCO_COB" , ""},
                { "V1SUBG_AGE_COB" , ""},
                { "V1SUBG_DAC_COB" , ""},
                { "V1SUBG_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_APOL" , ""},
                { "V1FATR_COD_SUBG" , ""},
                { "V1FATR_NUM_FATUR" , ""},
                { "V1FATR_COD_OPER" , ""},
                { "V1FATR_TIPO_ENDOS" , ""},
                { "V1FATR_NUM_ENDOS" , ""},
                { "V1FATR_VAL_FATURA" , ""},
                { "V1FATR_COD_FONTE" , ""},
                { "V1FATR_NUM_RCAP" , ""},
                { "V1FATR_VAL_RCAP" , ""},
                { "V1FATR_DATA_INIVIG" , ""},
                { "V1FATR_DATA_TERVIG" , ""},
                { "V1FATR_SIT_REG" , ""},
                { "V1FATR_DATA_FATUR" , ""},
                { "V1FATR_DATA_RCAP" , ""},
                { "V1FATR_COD_EMPRESA" , ""},
                { "V1FATR_DATA_VENC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_NUM_APOL" , ""},
                { "V1FATR_COD_SUBG" , ""},
                { "V1FATR_NUM_FATUR" , ""},
                { "V1FATR_COD_OPER" , ""},
                { "V1FATR_TIPO_ENDOS" , ""},
                { "V1FATR_NUM_ENDOS" , ""},
                { "V1FATR_VAL_FATURA" , ""},
                { "V1FATR_COD_FONTE" , ""},
                { "V1FATR_NUM_RCAP" , ""},
                { "V1FATR_VAL_RCAP" , ""},
                { "V1FATR_DATA_INIVIG" , ""},
                { "V1FATR_DATA_TERVIG" , ""},
                { "V1FATR_SIT_REG" , ""},
                { "V1FATR_DATA_FATUR" , ""},
                { "V1FATR_DATA_RCAP" , ""},
                { "V1FATR_COD_EMPRESA" , ""},
                { "V1FATR_DATA_VENC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1", q7);

            #endregion

            #region VG0105B_V1SUBGRUPO

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_NUM_APOL" , ""},
                { "V1SUBG_COD_SUBG" , ""},
                { "V1SUBG_COD_FONTE" , ""},
                { "V1SUBG_BCO_COB" , ""},
                { "V1SUBG_AGE_COB" , ""},
                { "V1SUBG_DAC_COB" , ""},
                { "V1SUBG_END_COB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0105B_V1SUBGRUPO", q8);

            #endregion

            #region VG0105B_V1FATURTOT1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUM_APOL" , ""},
                { "V1FATT_COD_SUBG" , ""},
                { "V1FATT_NUM_FATUR" , ""},
                { "V1FATT_COD_OPER" , ""},
                { "V1FATT_QT_VIDA_VG" , ""},
                { "V1FATT_QT_VIDA_AP" , ""},
                { "V1FATT_IMP_MORNAT" , ""},
                { "V1FATT_IMP_MORACI" , ""},
                { "V1FATT_IMP_INVPER" , ""},
                { "V1FATT_IMP_AMDS" , ""},
                { "V1FATT_IMP_DH" , ""},
                { "V1FATT_IMP_DIT" , ""},
                { "V1FATT_PRM_VG" , ""},
                { "V1FATT_PRM_AP" , ""},
                { "V1FATT_SIT_REG" , ""},
                { "V1FATT_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0105B_V1FATURTOT1", q9);

            #endregion

            #region R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_ORGAO" , ""},
                { "V1APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q10);

            #endregion

            #region VG0105B_MOVIMENTO

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_MORNATU_ANT" , ""},
                { "V0MOVI_MORNATU_ATU" , ""},
                { "V0MOVI_MORACID_ANT" , ""},
                { "V0MOVI_MORACID_ATU" , ""},
                { "V0MOVI_INVPERM_ANT" , ""},
                { "V0MOVI_INVPERM_ATU" , ""},
                { "V0MOVI_AMDS_ANT" , ""},
                { "V0MOVI_AMDS_ATU" , ""},
                { "V0MOVI_DH_ANT" , ""},
                { "V0MOVI_DH_ATU" , ""},
                { "V0MOVI_DIT_ANT" , ""},
                { "V0MOVI_DIT_ATU" , ""},
                { "V0MOVI_VG_ANT" , ""},
                { "V0MOVI_VG_ATU" , ""},
                { "V0MOVI_AP_ANT" , ""},
                { "V0MOVI_AP_ATU" , ""},
                { "V0MOVI_COD_OPER" , ""},
                { "V0MOVI_DATA_MOVI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0105B_MOVIMENTO", q11);

            #endregion

            #region R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1RIND_ISECUSTO" , ""},
                { "V1RIND_PCIOF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_DATA_REFER" , ""},
                { "DATA_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1FATC_NUM_APOLICE" , ""},
                { "V1FATC_DATA_REFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1", q14);

            #endregion

            #region R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0FATR_NUM_APOL" , ""},
                { "V0FATR_COD_SUBG" , ""},
                { "V0FATR_NUM_FATUR" , ""},
                { "V0FATR_COD_OPER" , ""},
                { "V0FATR_TIPO_ENDOS" , ""},
                { "V0FATR_NUM_ENDOS" , ""},
                { "V0FATR_VAL_FATURA" , ""},
                { "V0FATR_COD_FONTE" , ""},
                { "V0FATR_NUM_RCAP" , ""},
                { "V0FATR_VAL_RCAP" , ""},
                { "V0FATR_DATA_INIVIG" , ""},
                { "V0FATR_DATA_TERVIG" , ""},
                { "V0FATR_SIT_REG" , ""},
                { "V0FATR_DATA_FATUR" , ""},
                { "V0FATR_DATA_RCAP" , ""},
                { "V0FATR_COD_EMPRESA" , ""},
                { "V0FATR_DATA_VENC" , ""},
                { "V0FATR_VLIOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0FATT_NUM_APOL" , ""},
                { "V0FATT_COD_SUBG" , ""},
                { "V0FATT_NUM_FATUR" , ""},
                { "V0FATT_COD_OPER" , ""},
                { "V0FATT_QT_VIDA_VG" , ""},
                { "V0FATT_QT_VIDA_AP" , ""},
                { "V0FATT_IMP_MORNAT" , ""},
                { "V0FATT_IMP_MORACI" , ""},
                { "V0FATT_IMP_INVPER" , ""},
                { "V0FATT_IMP_AMDS" , ""},
                { "V0FATT_IMP_DH" , ""},
                { "V0FATT_IMP_DIT" , ""},
                { "V0FATT_PRM_VG" , ""},
                { "V0FATT_PRM_AP" , ""},
                { "V0FATT_SIT_REG" , ""},
                { "V0FATT_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1FATR_DATA_INIVIG" , ""},
                { "V1FATR_DATA_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1", q17);

            #endregion

            #region R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SOLF_COD_SUBG" , ""},
                { "W1SOLF_NUM_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1_Delete1", q18);

            #endregion

            #region R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SOLF_COD_SUBG" , ""},
                { "W1SOLF_NUM_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1", q19);

            #endregion

            #region R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1SOLF_SIT_REG" , ""},
                { "V1SOLF_NUM_APOL" , ""},
                { "V1SOLF_COD_SUBG" , ""},
                { "V1SOLF_NUM_FAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0MOVI_DATA_FATURA" , ""},
                { "V1FATC_DATA_REFER" , ""},
                { "W1SOLF_NUM_APOL" , ""},
                { "W1SUB_GRUPO" , ""},
                { "W2SUB_GRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1", q21);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0105B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0105B();

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG0105B_V1SOLICFAT");
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1SOLF_NUM_APOL" , "1"},
                { "V1SOLF_COD_SUBG" , ""},
                { "V1SOLF_NUM_FAT" , ""},
                { "V1SOLF_NUM_RCAP" , ""},
                { "V1SOLF_VAL_RCAP" , ""},
                { "V1SOLF_COD_OPER" , "100"},
                { "V1SOLF_SIT_REG" , ""},
                { "V1SOLF_DATA_RCAP" , ""},
                { "V1SOLF_DATA_VENC" , ""},
                { "V1SOLF_DATA_SOLI" , ""},
                { "V1SOLF_COD_USUAR" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VG0105B_V1SOLICFAT", q3);

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1FATURA_DB_SELECT_1_Query1", q5);

                program.Execute();

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("V0FATT_COD_OPER", out var valor) && valor == "1700");

                var envList1 = AppSettings.TestSet.DynamicData["R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("V1SOLF_NUM_APOL", out valor) && valor == "0000000000001");

                var envList3 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("V0FATR_SIT_REG", out valor) && valor == "0");

            }
        }

        [Fact]
        public static void VG0105B_Tests_SemDados()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0105B();

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q4);

                program.Execute();
                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}