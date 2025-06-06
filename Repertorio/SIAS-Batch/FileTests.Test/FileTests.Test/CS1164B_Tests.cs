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
using static Code.CS1164B;

namespace FileTests.Test
{
    [Collection("CS1164B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CS1164B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region CS1164B_CURS01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_FONTE" , ""},
                { "PROPOSTA_NUM_PROPOSTA" , ""},
                { "PROPOSTA_NUM_RCAP" , ""},
                { "PROPOSTA_DATA_CADASTRAMENTO" , ""},
                { "PROPOSTA_DATA_INIVIGENCIA" , ""},
                { "PROPOSTA_DATA_TERVIGENCIA" , ""},
                { "PROPOAUT_NUM_PROPOSTA_CONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CS1164B_CURS01", q0);

            #endregion

            #region R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_10DIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CS1164B_Saida1")]
        public static void CS1164B_Tests_Theory_ReturnCode0(string CS1164B1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                CS0701S_Tests.Load_Parameters();
                #region CS0701S_CURGE190

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GE190_COD_PARAMETRO" , "0"},
                { "GE190_COD_PRODUTO" , "1"},
                { "GE190_STA_PARAMETRO" , "2"},
                { "GE190_NOM_CLASSE_PARAM" , "X"},
                { "GE190_COD_SISTEMA" , "3"},
                { "GE190_DTA_INI_VIGENCA" , "2020-01-01"},
                { "GE190_DTA_FIM_VIGENCIA" , "2020-01-01"},
                { "GE190_DES_PARAMETRO" , "X"},
                { "GE190_IND_TP_PARAMETRO" , "4"},
                { "GE190_VLR_PARAMETRO" , "100"},
                { "GE190_VLR_PARAM_INT" , "100"},
                { "GE190_PCT_PARAMETRO" , "1"},
                { "GE190_VLR_PARAM_TAXA" , "10"},
                { "GE190_DTA_PARAMETRO" , "2020-01-01"},
                { "GE190_VLR_PARAM_REDUZIDO" , "10"},
                { "GE190_VLR_PARAM_EXTENDIDO" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("CS0701S_CURGE190");
                AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q4);
                #endregion

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region CS1164B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_FONTE" , "PROPOSTA" },
                { "PROPOSTA_NUM_PROPOSTA" , "123456" },
                { "PROPOSTA_NUM_RCAP" , "RC123456" },
                { "PROPOSTA_DATA_CADASTRAMENTO" , "2023-01-01" },
                { "PROPOSTA_DATA_INIVIGENCIA" , "2023-01-02" },
                { "PROPOSTA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "PROPOAUT_NUM_PROPOSTA_CONV" , "CONV123456" },
                });
                AppSettings.TestSet.DynamicData.Remove("CS1164B_CURS01");
                AppSettings.TestSet.DynamicData.Add("CS1164B_CURS01", q0);

                #endregion

                #region R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-01-10" },
                { "WHOST_DATA_10DIAS" , "2023-01-20" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "Empresa XYZ" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new CS1164B();
                program.Execute(CS1164B1_FILE_NAME_P);

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
        [Theory]
        [InlineData("CS1164B__Saida_Erro1")]
        public static void CS1164B_Tests_Theory_Erro99(string CS1164B1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                CS0701S_Tests.Load_Parameters();
                #region CS0701S_CURGE190

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GE190_COD_PARAMETRO" , "0"},
                { "GE190_COD_PRODUTO" , "1"},
                { "GE190_STA_PARAMETRO" , "2"},
                { "GE190_NOM_CLASSE_PARAM" , "X"},
                { "GE190_COD_SISTEMA" , "3"},
                { "GE190_DTA_INI_VIGENCA" , "2020-01-01"},
                { "GE190_DTA_FIM_VIGENCIA" , "2020-01-01"},
                { "GE190_DES_PARAMETRO" , "X"},
                { "GE190_IND_TP_PARAMETRO" , "4"},
                { "GE190_VLR_PARAMETRO" , "100"},
                { "GE190_VLR_PARAM_INT" , "100"},
                { "GE190_PCT_PARAMETRO" , "1"},
                { "GE190_VLR_PARAM_TAXA" , "10"},
                { "GE190_DTA_PARAMETRO" , "2020-01-01"},
                { "GE190_VLR_PARAM_REDUZIDO" , "10"},
                { "GE190_VLR_PARAM_EXTENDIDO" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("CS0701S_CURGE190");
                AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q4);
                #endregion
                #region PARAMETERS

                #region CS1164B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_FONTE" , "PROPOSTA" },
                { "PROPOSTA_NUM_PROPOSTA" , "123456" },
                { "PROPOSTA_NUM_RCAP" , "RC123456" },
                { "PROPOSTA_DATA_CADASTRAMENTO" , "2023-01-01" },
                { "PROPOSTA_DATA_INIVIGENCIA" , "2023-01-02" },
                { "PROPOSTA_DATA_TERVIGENCIA" , "2024-01-01" },
                { "PROPOAUT_NUM_PROPOSTA_CONV" , "CONV123456" },
                });
                AppSettings.TestSet.DynamicData.Remove("CS1164B_CURS01");
                AppSettings.TestSet.DynamicData.Add("CS1164B_CURS01", q0);

                #endregion

                #region R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-01-10" },
                { "WHOST_DATA_10DIAS" , "2023-01-20" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion
                #region R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new CS1164B();
                program.Execute(CS1164B1_FILE_NAME_P);
                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}