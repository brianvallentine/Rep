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
using static Code.PTFASESS;

namespace FileTests.Test
{
    [Collection("PTFASESS_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTFASESS_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISINFAS_COD_FONTE" , ""},
                { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                { "SISINFAS_COD_FASE" , ""},
                { "SISINFAS_COD_EVENTO" , ""},
                { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                { "SISINFAS_DATA_INIVIG_REFAEV" , ""},
                { "SISINFAS_DATA_ABERTURA_SIFA" , ""},
                { "SISINFAS_DATA_FECHA_SIFA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1", q0);

            #endregion

            #region R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISINFAS_DATA_FECHA_SIFA" , ""},
                { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                { "SISINFAS_COD_FONTE" , ""},
                { "SISINFAS_COD_FASE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1", q1);

            #endregion

            #region R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISINFAS_COD_FONTE" , ""},
                { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                { "SISINFAS_COD_FASE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void PTFASESS_Tests_Insert_Fact()
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
                #region R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                    { "SISINFAS_COD_EVENTO" , ""},
                    { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                    { "SISINFAS_DATA_INIVIG_REFAEV" , ""},
                    { "SISINFAS_DATA_ABERTURA_SIFA" , ""},
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1", q1);

                #endregion

                #region R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1", q2);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new SISINFAS_DCLSI_SINISTRO_FASE();
                param2.SISINFAS_COD_FONTE.Value = 1;
                param2.SISINFAS_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SISINFAS_COD_FASE.Value = 1;
                param2.SISINFAS_COD_EVENTO.Value = 1;
                param2.SISINFAS_NUM_OCORR_SINIACO.Value = 1;
                param2.SISINFAS_DATA_INIVIG_REFAEV.Value = "2025-01-01";
                param2.SISINFAS_DATA_ABERTURA_SIFA.Value = "2025-01-01";
                param2.SISINFAS_DATA_FECHA_SIFA.Value = "2025-01-01";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTFASESS();
                program.Execute(param1, param2, param3);

                var insert = AppSettings.TestSet.DynamicData["R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.NotEmpty(insert);
                Assert.True(insert[1].TryGetValue("SISINFAS_NUM_PROTOCOLO_SINI", out string value1) && value1.Equals("000000001"));

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL.Value == 0);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value == "0000");
            }
        }

        [Fact]
        public static void PTFASESS_Tests_Delete_Fact()
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
                #region R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                    { "SISINFAS_COD_EVENTO" , ""},
                    { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                    { "SISINFAS_DATA_INIVIG_REFAEV" , ""},
                    { "SISINFAS_DATA_ABERTURA_SIFA" , ""},
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1", q1);

                #endregion

                #region R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1", q2);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "3";

                var param2 = new SISINFAS_DCLSI_SINISTRO_FASE();
                param2.SISINFAS_COD_FONTE.Value = 1;
                param2.SISINFAS_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SISINFAS_COD_FASE.Value = 1;
                param2.SISINFAS_COD_EVENTO.Value = 1;
                param2.SISINFAS_NUM_OCORR_SINIACO.Value = 1;
                param2.SISINFAS_DATA_INIVIG_REFAEV.Value = "2025-01-01";
                param2.SISINFAS_DATA_ABERTURA_SIFA.Value = "2025-01-01";
                param2.SISINFAS_DATA_FECHA_SIFA.Value = "2025-01-01";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTFASESS();
                program.Execute(param1, param2, param3);

                var delete = AppSettings.TestSet.DynamicData["R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(delete);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL == 0);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 0);
            }
        }

        [Fact]
        public static void PTFASESS_Tests_Update_Fact()
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
                #region R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                    { "SISINFAS_COD_EVENTO" , ""},
                    { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                    { "SISINFAS_DATA_INIVIG_REFAEV" , ""},
                    { "SISINFAS_DATA_ABERTURA_SIFA" , ""},
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1", q1);

                #endregion

                #region R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1", q2);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "2";

                var param2 = new SISINFAS_DCLSI_SINISTRO_FASE();
                param2.SISINFAS_COD_FONTE.Value = 1;
                param2.SISINFAS_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SISINFAS_COD_FASE.Value = 1;
                param2.SISINFAS_COD_EVENTO.Value = 1;
                param2.SISINFAS_NUM_OCORR_SINIACO.Value = 1;
                param2.SISINFAS_DATA_INIVIG_REFAEV.Value = "2025-01-01";
                param2.SISINFAS_DATA_ABERTURA_SIFA.Value = "2025-01-01";
                param2.SISINFAS_DATA_FECHA_SIFA.Value = "2025-01-01";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTFASESS();
                program.Execute(param1, param2, param3);

                var update = AppSettings.TestSet.DynamicData["R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.NotEmpty(update);
                Assert.True(update[1].TryGetValue("SISINFAS_NUM_PROTOCOLO_SINI", out string value1) && value1.Equals("000000001"));

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL == 0);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 0);
            }
        }

        [Fact]
        public static void PTFASESS_Tests_ReturnCode99_Fact()
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
                #region R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                    { "SISINFAS_COD_EVENTO" , ""},
                    { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                    { "SISINFAS_DATA_INIVIG_REFAEV" , ""},
                    { "SISINFAS_DATA_ABERTURA_SIFA" , ""},
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1", q0);

                #endregion

                #region R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_DATA_FECHA_SIFA" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1", q1);

                #endregion

                #region R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FONTE" , ""},
                    { "SISINFAS_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINFAS_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1", q2);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new SISINFAS_DCLSI_SINISTRO_FASE();
                param2.SISINFAS_COD_FONTE.Value = 1;
                param2.SISINFAS_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SISINFAS_COD_FASE.Value = 1;
                param2.SISINFAS_COD_EVENTO.Value = 1;
                param2.SISINFAS_NUM_OCORR_SINIACO.Value = 1;
                param2.SISINFAS_DATA_INIVIG_REFAEV.Value = "2025-01-01";
                param2.SISINFAS_DATA_ABERTURA_SIFA.Value = "2025-01-01";
                param2.SISINFAS_DATA_FECHA_SIFA.Value = "2025-01-01";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTFASESS();
                program.Execute(param1, param2, param3);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL.Value == 99);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value == "0001");
            }
        }
    }
}