using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using System.Linq;

namespace FileTests.Test
{
    [Collection("VA0850B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0850B_Tests
    {
        [Fact]
        public static void VA0850B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.IsTest = true;
                #region PARAMETERS
                #region VA0850B_CHISTCB

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "V0HCOB_COUNT" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("VA0850B_CHISTCB", q0);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "VIND_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
                { "VIND_ORIG_PRODU" , ""},
            });
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , "2"},
                { "V0PROP_SITUACAO" , "2"},
                { "V0PROP_ESTR_COBR" , "MULT"},
                { "VIND_ESTR_COBR" , "2"},
                { "V0PROP_ORIG_PRODU" , "2"},
                { "VIND_ORIG_PRODU" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRPARCELMAX" , "1"}
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q2);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , "3"},
                { "V0HCOB_OPCAOPAG" , "3"},
            });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , "32"},
                { "V0HCOB_OPCAOPAG" , "32"},
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q3);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , "2"},
                { "V0HCOB_OPCAOPAG" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q4);

                #endregion

                #region VA0850B_CPARCEL

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "NRPARCEL" , "6"},
                { "PRMVG" , "6"},
                { "PRMAP" , "6"},
                { "DTVENCTO" , "6"},
            });
                AppSettings.TestSet.DynamicData.Add("VA0850B_CPARCEL", q5);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0DIFP_CODOPER" , ""},
                { "V0HCOB_VLPRMTOT" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCELMAX" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVGTOT" , ""},
                { "V0PARC_PRMAPTOT" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCELMAX" , "3"},
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q7);

                #endregion

                #region R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_QTDPARATZ" , ""},
                { "V0HCOB_NRPARCELMIN" , ""},
                { "V0HCOB_NRCERTIF" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1", q8);

                #endregion

                #region R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1", q9);

                #endregion

                #region R1100_00_PARC_EM_CARNE_DB_UPDATE_2_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0PARC_NRPARCEL" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1100_00_PARC_EM_CARNE_DB_UPDATE_2_Update1", q10);

                #endregion

                #region R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCELMAX" , "4"},
                { "V0PARC_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCELMAX" , "5"},
                { "V0PARC_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1", q12);

                #endregion

                #region R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCELMAX" , "6"},
                { "V0PARC_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
                { "V0PARC_DTVENCTO" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1", q13);

                #endregion

                #region R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCELMAX" , "7"},
                { "V0PARC_NRPARCEL" , ""},
                { "V0DIFP_CODOPER" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1", q14);

                #endregion

                #endregion
                var program = new VA0850B();
                program.Execute();

                var envList0 = AppSettings.TestSet.DynamicData["R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1"].DynamicList;

                Assert.True(envList0?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);

                Assert.True(envList0[1].TryGetValue("V0DIFP_CODOPER", out var V0DIFP_CODOPER) && V0DIFP_CODOPER == "0121");
                Assert.True(envList0[1].TryGetValue("V0PARC_PRMVG", out var V0PARC_PRMVG) && V0PARC_PRMVG == "0000000000006.00");
                Assert.True(envList0[1].TryGetValue("V0HCOB_NRPARCELMAX", out var V0HCOB_NRPARCELMAX) && V0HCOB_NRPARCELMAX == "0001");

                Assert.True(envList1[1].TryGetValue("V0DIFP_CODOPER", out V0DIFP_CODOPER) && V0DIFP_CODOPER == "0121");

                Assert.True(envList2[1].TryGetValue("V0HCOB_NRPARCELMAX", out V0HCOB_NRPARCELMAX) && V0HCOB_NRPARCELMAX == "0001");

                Assert.True(envList3[1].TryGetValue("V0HCOB_NRPARCELMIN", out var V0HCOB_NRPARCELMIN) && V0HCOB_NRPARCELMIN == "0006");
            }
        }
    }
}