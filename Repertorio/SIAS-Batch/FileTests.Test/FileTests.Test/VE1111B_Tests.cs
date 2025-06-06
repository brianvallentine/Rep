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
using static Code.VE1111B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("VE1111B_Tests")]
    public class VE1111B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "W02DTSQL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region VE1111B_CPRODUTOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NUM_APOLICE" , ""},
                { "PRODUVG_COD_SUBGRUPO" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE1111B_CPRODUTOS", q2);

            #endregion

            #region M_1000_PROCESSA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1000_PROCESSA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_1000_PROCESSA_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_2000_UPDATE_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_UPDATE_DB_UPDATE_1_Update1", q7);

            #endregion

            #region M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE1111B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "W02DTSQL" , "SELECT * FROM W02DT WHERE DATA = @data" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region VE1111B_CPRODUTOS

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NUM_APOLICE" , "123456789" },
                { "PRODUVG_COD_SUBGRUPO" , "001" },
                { "PRODUVG_COD_PRODUTO" , "VG123" },
                { "PRODUVG_PERI_PAGAMENTO" , "Mensal" },
                { "PRODUVG_NOME_PRODUTO" , "Vida Grupo Standard" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE1111B_CPRODUTOS");
AppSettings.TestSet.DynamicData.Add("VE1111B_CPRODUTOS", q2);

                #endregion

                #region M_1000_PROCESSA_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_CLIENTE" , "C000123456" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_1000_PROCESSA_DB_UPDATE_1_Update1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "Vida Grupo Standard" },
                { "PRODUVG_COD_PRODUTO" , "VG123" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_1000_PROCESSA_DB_SELECT_2_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , "VG321" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_2000_UPDATE_DB_UPDATE_1_Update1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , "VG123" },
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_2000_UPDATE_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("M_2000_UPDATE_DB_UPDATE_1_Update1", q7);

                #endregion

                #region M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "Seguro de Vida" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1", q8);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE1111B();
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
        public static void VE1111B_Tests_Return99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
       
            });
                AppSettings.TestSet.DynamicData.Remove("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "W02DTSQL" , "SELECT * FROM W02DT WHERE DATA = @data" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region VE1111B_CPRODUTOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NUM_APOLICE" , "123456789" },
                { "PRODUVG_COD_SUBGRUPO" , "001" },
                { "PRODUVG_COD_PRODUTO" , "VG123" },
                { "PRODUVG_PERI_PAGAMENTO" , "Mensal" },
                { "PRODUVG_NOME_PRODUTO" , "Vida Grupo Standard" },
            });
                AppSettings.TestSet.DynamicData.Remove("VE1111B_CPRODUTOS");
                AppSettings.TestSet.DynamicData.Add("VE1111B_CPRODUTOS", q2);

                #endregion

                #region M_1000_PROCESSA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_CLIENTE" , "C000123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_1000_PROCESSA_DB_UPDATE_1_Update1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "Vida Grupo Standard" },
                { "PRODUVG_COD_PRODUTO" , "VG123" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_UPDATE_1_Update1", q4);

                #endregion

                #region M_1000_PROCESSA_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_2_Query1", q5);

                #endregion

                #region M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO" , "VG321" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_2000_UPDATE_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , "VG123" },
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("M_2000_UPDATE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_2000_UPDATE_DB_UPDATE_1_Update1", q7);

                #endregion

                #region M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "Seguro de Vida" }
            });
                AppSettings.TestSet.DynamicData.Remove("M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1", q8);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE1111B();
                program.Execute();

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}