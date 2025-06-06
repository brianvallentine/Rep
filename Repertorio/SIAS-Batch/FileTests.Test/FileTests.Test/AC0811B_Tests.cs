using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.AC0811B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    [Collection("AC0811B_Tests")]
    public class AC0811B_Tests
    {
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region AC0811B_C01_COSHISSI

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_COD_EMPRESA" , ""},
                { "COSHISSI_COD_CONGENERE" , ""},
                { "COSHISSI_NUM_SINISTRO" , ""},
                { "COSHISSI_DATA_MOVIMENTO" , ""},
                { "COSHISSI_OCORR_HISTORICO" , ""},
                { "COSHISSI_COD_OPERACAO" , ""},
                { "COSHISSI_TIPO_SEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0811B_C01_COSHISSI", q1);

            #endregion

            #region R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "PRODUTO_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "COSHISSI_COD_CONGENERE" , ""},
                { "COSHISSI_NUM_SINISTRO" , ""},
                { "COSHISSI_TIPO_SEGURO" , ""},
                { "COSHISSI_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "COSHISSI_OCORR_HISTORICO" , ""},
                { "COSHISSI_DATA_MOVIMENTO" , ""},
                { "COSHISSI_COD_CONGENERE" , ""},
                { "COSHISSI_NUM_SINISTRO" , ""},
                { "COSHISSI_COD_OPERACAO" , ""},
                { "COSHISSI_TIPO_SEGURO" , ""},
                { "COSHISSI_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public void AC0811B_Test_Cenario_1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_COD_EMPRESA" , "123" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_NUM_SINISTRO" , "789" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-02" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente reportado" },
                { "COSHISSI_COD_OPERACAO" , "805" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0811B_C01_COSHISSI");
                AppSettings.TestSet.DynamicData.Add("AC0811B_C01_COSHISSI", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "101112" },
                { "SINISMES_COD_PRODUTO" , "131415" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "161718" },
                { "PRODUTO_COD_PRODUTO" , "192021" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "161718" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_NUM_SINISTRO" , "789" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "123" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "161718" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente reportado" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-02" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_NUM_SINISTRO" , "789" },
                { "COSHISSI_COD_OPERACAO" , "805" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "123" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1", q5);

                var program = new AC0811B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);
            }
        }

        [Fact]
        public void AC0811B_Test_Cenario_2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_COD_EMPRESA" , "123" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_NUM_SINISTRO" , "789" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-02" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente ocorrido sem maiores problemas." },
                { "COSHISSI_COD_OPERACAO" , "805" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0811B_C01_COSHISSI");
                AppSettings.TestSet.DynamicData.Add("AC0811B_C01_COSHISSI", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "AP123456" },
                { "SINISMES_COD_PRODUTO" , "Prod123" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "321" },
                { "PRODUTO_COD_PRODUTO" , "Prod321" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "321" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_NUM_SINISTRO" , "789" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "123" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "321" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente ocorrido sem maiores problemas." },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-02" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_NUM_SINISTRO" , "789" },
                { "COSHISSI_COD_OPERACAO" , "805" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "123" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1", q5);

                var program = new AC0811B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);
            }
        }

        [Fact]
        public void AC0811B_Test_Cenario_3()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_COD_EMPRESA" , "100" },
                { "COSHISSI_COD_CONGENERE" , "200" },
                { "COSHISSI_NUM_SINISTRO" , "SN123456" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-01" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente reportado" },
                { "COSHISSI_COD_OPERACAO" , "805" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0811B_C01_COSHISSI");
                AppSettings.TestSet.DynamicData.Add("AC0811B_C01_COSHISSI", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "AP123456" },
                { "SINISMES_COD_PRODUTO" , "300" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "100" },
                { "PRODUTO_COD_PRODUTO" , "400" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "100" },
                { "COSHISSI_COD_CONGENERE" , "200" },
                { "COSHISSI_NUM_SINISTRO" , "SN123456" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "100" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "100" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente reportado" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-01" },
                { "COSHISSI_COD_CONGENERE" , "200" },
                { "COSHISSI_NUM_SINISTRO" , "SN123456" },
                { "COSHISSI_COD_OPERACAO" , "805" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "100" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1", q5);

                var program = new AC0811B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);
            }
        }

        [Fact]
        public void AC0811B_Test_Cenario_4()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_COD_EMPRESA" , "100" },
                { "COSHISSI_COD_CONGENERE" , "200" },
                { "COSHISSI_NUM_SINISTRO" , "300" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-02" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente reportado" },
                { "COSHISSI_COD_OPERACAO" , "101" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0811B_C01_COSHISSI");
                AppSettings.TestSet.DynamicData.Add("AC0811B_C01_COSHISSI", q1);

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOLICE" , "400" },
                { "SINISMES_COD_PRODUTO" , "500" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "600" },
                { "PRODUTO_COD_PRODUTO" , "700" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "600" },
                { "COSHISSI_COD_CONGENERE" , "200" },
                { "COSHISSI_NUM_SINISTRO" , "300" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "100" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "600" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente reportado" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-02" },
                { "COSHISSI_COD_CONGENERE" , "200" },
                { "COSHISSI_NUM_SINISTRO" , "300" },
                { "COSHISSI_COD_OPERACAO" , "101" },
                { "COSHISSI_TIPO_SEGURO" , "Vida" },
                { "COSHISSI_COD_EMPRESA" , "100" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1", q5);

                var program = new AC0811B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}