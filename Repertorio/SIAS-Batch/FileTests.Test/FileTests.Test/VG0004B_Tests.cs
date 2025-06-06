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
using static Code.VG0004B;

namespace FileTests.Test
{
    [Collection("VG0004B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0004B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VG0004B_CHISTCTB

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "HISCONPA_DTFATUR" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0004B_CHISTCTB", q0);

            #endregion

            #region M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_DTPROXVEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_SELECT_ENDOSSOS_DB_SELECT_2_Query1", q3);

            #endregion

            #region M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_QUITACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_SELECT_ENDOSSOS_DB_SELECT_3_Query1", q5);

            #endregion

            #region M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0004B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0004B();

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                q2.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_SIT_REGISTRO" , "1"}});
                AppSettings.TestSet.DynamicData.Add("M_1100_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q2);

                program.Execute();
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("ENDOSSOS_SIT_REGISTRO", out var valor) && valor == "1");

                var envList1 = AppSettings.TestSet.DynamicData["M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ENDOSSOS_SIT_REGISTRO", out valor) && valor == "1");

                var envList2 = AppSettings.TestSet.DynamicData["M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("HISCONPA_COD_OPERACAO", out valor) && valor == "0201");
            }
        }
        [Fact]
        public static void VG0004B_Tests_SemDados()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0004B();

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1050_SELECT_PROPOVA_DB_SELECT_1_Query1", q2);

                program.Execute();
                Assert.True(program.RETURN_CODE == 9);

            }
        }

    }
}