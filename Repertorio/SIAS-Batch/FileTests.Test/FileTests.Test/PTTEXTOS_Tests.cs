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
using static Code.PTTEXTOS;

namespace FileTests.Test
{
    [Collection("PTTEXTOS_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTTEXTOS_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GECARTEX_NUM_CARTA" , ""},
                { "GECARTEX_TEXTO_CARTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1", q0);

            #endregion

            #region R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GECARTEX_TEXTO_CARTA" , ""},
                { "GECARTEX_NUM_CARTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void PTTEXTOS_Tests_Fact_Inclusao()
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
                #region R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_NUM_CARTA" , ""},
                    { "GECARTEX_TEXTO_CARTA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_TEXTO_CARTA" , ""},
                    { "GECARTEX_NUM_CARTA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1", q1);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new GECARTEX_DCLGE_CARTA_TEXTO();
                param2.GECARTEX_NUM_CARTA.Value = 1;
                param2.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_TEXT.Value = "Lorem";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTTEXTOS();
                program.Execute(param1, param2, param3);

                var insert = AppSettings.TestSet.DynamicData["R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert[1].TryGetValue("GECARTEX_NUM_CARTA", out string value) && value.Equals("000000001"));

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value == "0000");
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL.Value == 0);
            }
        }

        [Fact]
        public static void PTTEXTOS_Tests_Fact_Alteracao()
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
                #region R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_NUM_CARTA" , ""},
                    { "GECARTEX_TEXTO_CARTA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_TEXTO_CARTA" , ""},
                    { "GECARTEX_NUM_CARTA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1", q1);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "2";

                var param2 = new GECARTEX_DCLGE_CARTA_TEXTO();
                param2.GECARTEX_NUM_CARTA.Value = 1;
                param2.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_TEXT.Value = "Lorem";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTTEXTOS();
                program.Execute(param1, param2, param3);

                var update = AppSettings.TestSet.DynamicData["R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.True(update[1].TryGetValue("GECARTEX_NUM_CARTA", out string value) && value.Equals("000000001"));

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value == "0000");
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL.Value == 0);
            }
        }

        [Fact]
        public static void PTTEXTOS_Tests_Fact_ReturnCode99()
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
                #region R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_NUM_CARTA" , ""},
                    { "GECARTEX_TEXTO_CARTA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_TEXTO_CARTA" , ""},
                    { "GECARTEX_NUM_CARTA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1", q1);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "2";

                var param2 = new GECARTEX_DCLGE_CARTA_TEXTO();
                param2.GECARTEX_NUM_CARTA.Value = 1;
                param2.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_TEXT.Value = "Lorem";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTTEXTOS();
                program.Execute(param1, param2, param3);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value == "0001");
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL.Value == 99);
            }
        }
    }
}