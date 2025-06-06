using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0459B;
using System.Drawing;

namespace FileTests.Test
{
    [Collection("VA0459B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0459B_Tests
    {
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "99"},
                { "V1SIST_DTMOVABE_30" , "10"},
                { "V1SIST_DTMOVABE_45" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0459B_TCOMIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "CODSUBES" , ""},
                { "NRCERTIF" , ""},
                { "DTQITBCO" , "10"},
                { "DAYS" , ""},
                { "SITUACAO" , ""},
                { "DPS_TITULAR" , ""},
                { "DPS_ESPOSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0459B_TCOMIS", q1);

            #endregion

            #region R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CONV_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1030_00_SELECT_VG078_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ACOMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_VG078_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ERROS" , "1"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ERROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0PROP_APOLICE" , "99"},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0459B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                var program = new VA0459B();
                program.Execute();
                var envList6 = AppSettings.TestSet.DynamicData["R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("V1SIST_DTMOVABE", out var valor) && valor == "99        ");
            }
        }
    }
}