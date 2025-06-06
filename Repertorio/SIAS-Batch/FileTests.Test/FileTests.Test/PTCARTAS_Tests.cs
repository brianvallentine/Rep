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
using Code;
using static Code.PTCARTAS;
using Dclgens;

namespace FileTests.Test
{
    [Collection("PTCARTAS_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTCARTAS_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GECARTA_NUM_CARTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GECARTA_NUM_CARTA" , ""},
                { "GECARTA_NUM_CARTA_REITERA" , ""},
                { "GECARTA_COD_USUARIO" , ""},
                { "GECARTA_SEQ_CARTA_REITERA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void PTCARTAS_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_NUM_CARTA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_NUM_CARTA" , ""},
                    { "GECARTA_NUM_CARTA_REITERA" , ""},
                    { "GECARTA_COD_USUARIO" , ""},
                    { "GECARTA_SEQ_CARTA_REITERA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1", q1);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new GECARTA_DCLGE_CARTA();
                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTCARTAS();
                program.Execute(param1, param2, param3);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 0);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL == 0);
            }
        }

        [Fact]
        public static void PTCARTAS_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_NUM_CARTA" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_NUM_CARTA" , ""},
                    { "GECARTA_NUM_CARTA_REITERA" , ""},
                    { "GECARTA_COD_USUARIO" , ""},
                    { "GECARTA_SEQ_CARTA_REITERA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1", q1);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new GECARTA_DCLGE_CARTA();
                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTCARTAS();
                program.Execute(param1, param2, param3);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 1);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL == 99);
            }
        }
    }
}