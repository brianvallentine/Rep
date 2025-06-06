using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;

namespace FileTests.Test
{
    [Collection("VG0032B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0032B_Tests
    {
        [Fact]
        public static void VG0032B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.IsTest = true;
                #region PARAMETERS
                #region VG0032B_TMOVIMENTO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "2"},
                { "SIT_REGISTRO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("VG0032B_TMOVIMENTO", q0);

                #endregion

                #region M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , "4"}
            });
                AppSettings.TestSet.DynamicData.Add("M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1", q1);

                #endregion

                #endregion
                var program = new VG0032B();
                program.Execute();
                var envList = AppSettings.TestSet.DynamicData["M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("SEGURVGA_NUM_CERTIFICADO", out var valOr) && valOr == "000000000000002");

            }
        }
    }
}