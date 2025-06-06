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
using Dclgens;
using Code;
using static Code.VG0016B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    [Collection("VG0016B_Tests")]
    public class VG0016B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VG0016B_ACOPLADO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_IDE_SISTEMA" , ""},
                { "WS_COD_DOC_PARCEIRO_P" , ""},
                { "WS_COD_PRODUTO" , ""},
                { "WS_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0016B_ACOPLADO", q0);

            #endregion

            #region R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG135_NUM_CERTIFICADO" , ""},
                { "VG135_IDE_SISTEMA" , ""},
                { "VG135_COD_PRODUTO" , ""},
                { "VG135_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VG135_IDE_SISTEMA" , ""},
                { "VG135_NUM_CERTIFICADO" , ""},
                { "VG135_COD_PRODUTO" , ""},
                { "VG135_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1", q3);

            #endregion

            #endregion            
        }
        [Fact]
        public void VG0016B_Test_Cenario_1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VG0016B_ACOPLADO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WS_IDE_SISTEMA" , "SIST001" },
                    { "WS_COD_DOC_PARCEIRO_P" , "DOC123" },
                    { "WS_COD_PRODUTO" , "PROD456" },
                    { "WS_COD_PLANO" , "PLANO789" },
                });
                AppSettings.TestSet.DynamicData.Remove("VG0016B_ACOPLADO");
                AppSettings.TestSet.DynamicData.Add("VG0016B_ACOPLADO", q0);

                #endregion

                #region R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_CURRENT_TIMESTAMP" , "2023-12-01" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "VG135_NUM_CERTIFICADO" , "CERT001" },
                    { "VG135_IDE_SISTEMA" , "SIST002" },
                    { "VG135_COD_PRODUTO" , "PROD457" },
                    { "VG135_COD_PLANO" , "PLANO790" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1", q2);

                #endregion

                #region R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "VG135_IDE_SISTEMA" , "SIST002" },
                    { "VG135_NUM_CERTIFICADO" , "CERT001" },
                    { "VG135_COD_PRODUTO" , "PROD457" },
                    { "VG135_COD_PLANO" , "PLANO790" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1", q3);

                #endregion
                #endregion
                #endregion


                //var = (string)(AppSettings.TestSet.DynamicData.Where(dd => dd.Value.DynamicList.Any(d => d.ContainsKey(""))).Select(dd => dd.Value.DynamicList.First().GetValueOrDefault("")).FirstOrDefault() ?? "123456789");
                var program = new VG0016B();
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

                Assert.True(program.RETURN_CODE == 0);

            }
        }

        [Fact]
        public void VG0016B_Test_Cenario_2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VG0016B_ACOPLADO

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WS_IDE_SISTEMA" , "SIST123" },
                    { "WS_COD_DOC_PARCEIRO_P" , "DOC456" },
                    { "WS_COD_PRODUTO" , "PROD789" },
                    { "WS_COD_PLANO" , "PLANO101112" },
                });
                AppSettings.TestSet.DynamicData.Remove("VG0016B_ACOPLADO");
                AppSettings.TestSet.DynamicData.Add("VG0016B_ACOPLADO", q0);

                #endregion

                #region R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_CURRENT_TIMESTAMP" , "2023-12-01" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "VG135_NUM_CERTIFICADO" , "CERT135" },
                    { "VG135_IDE_SISTEMA" , "SIST135" },
                    { "VG135_COD_PRODUTO" , "PROD135" },
                    { "VG135_COD_PLANO" , "PLANO135" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1", q2);

                #endregion

                #region R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "VG135_IDE_SISTEMA" , "SIST135" },
                    { "VG135_NUM_CERTIFICADO" , "CERT135" },
                    { "VG135_COD_PRODUTO" , "PROD135" },
                    { "VG135_COD_PLANO" , "PLANO135" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1", q3);

                #endregion
                #endregion
                #endregion


                //var = (string)(AppSettings.TestSet.DynamicData.Where(dd => dd.Value.DynamicList.Any(d => d.ContainsKey(""))).Select(dd => dd.Value.DynamicList.First().GetValueOrDefault("")).FirstOrDefault() ?? "123456789");
                var program = new VG0016B();
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

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public void VG0016B_Test_Cenario_Retorno99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                //Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WS_IDE_SISTEMA" , null }
                });
                AppSettings.TestSet.DynamicData.Add("VG0016B_ACOPLADO", q0);

                var program = new VG0016B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}