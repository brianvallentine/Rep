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
using static Code.PF0005S;

namespace FileTests.Test
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("PF0005S_Tests")]
    public class PF0005S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
           
            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region P0110_05_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_ENVIO" , ""},
                { "COD_EMPRESA_SIVPF" , ""},
                { "COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0110_05_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P0111_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PFMOTPRO_SIT_MOTIVO_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0111_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region P0401_05_INICIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISPROFI_NSL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0401_05_INICIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region P8000_05_INICIO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISPROFI_NUM_IDENTIFICACAO" , ""},
                { "HISPROFI_DATA_SITUACAO" , ""},
                { "HISPROFI_NSAS_SIVPF" , ""},
                { "HISPROFI_NSL" , ""},
                { "HISPROFI_SIT_PROPOSTA" , ""},
                { "HISPROFI_SIT_COBRANCA_SIVPF" , ""},
                { "HISPROFI_SIT_MOTIVO_SIVPF" , ""},
                { "HISPROFI_COD_EMPRESA_SIVPF" , ""},
                { "HISPROFI_COD_PRODUTO_SIVPF" , ""},
                { "HISPROFI_IND_TP_ACAO" , ""},
                { "HISPROFI_IND_TP_SENSIBILIZACAO" , ""},
                { "HISPROFI_IND_ENVIO" , ""},
                { "HISPROFI_DTA_INI_VIGENCIA" , ""},
                { "HISPROFI_DTA_FIM_VIGENCIA" , ""},
                { "HISPROFI_NUM_PARCELA" , ""},
                { "HISPROFI_COD_TP_LANCAMENTO" , ""},
                { "HISPROFI_VLR_PREMIO" , ""},
                { "HISPROFI_COD_ERRO" , ""},
                { "HISPROFI_COD_USUARIO" , ""},
                { "HISPROFI_NOM_PROGRAMA" , ""},
                { "HISPROFI_DTA_PROCESSAMENTO_CEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P8000_05_INICIO_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void PF0005S_Tests_Fact()
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

                #region P0050_05_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region P0110_05_INICIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_ENVIO" , "0"},
                { "COD_EMPRESA_SIVPF" , "1"},
                { "COD_PRODUTO_SIVPF" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("P0110_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0110_05_INICIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region P0111_05_INICIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PFMOTPRO_SIT_MOTIVO_SIVPF" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("P0111_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0111_05_INICIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region P0401_05_INICIO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISPROFI_NSL" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("P0401_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0401_05_INICIO_DB_SELECT_1_Query1", q3);

                #endregion


                #endregion
                var program = new PF0005S();
                PF0005W obj = new PF0005W();

                obj.LK_PF005_E_NUM_IDENTIFICACAO.Value = 2;
                obj.LK_PF005_E_IND_TP_ACAO.Value = "I";
                obj.LK_PF005_E_DTA_INI_VIGENCIA.Value = "0001-01-01";
                obj.LK_PF005_E_DTA_FIM_VIGENCIA.Value = "0001-01-01";
                obj.LK_PF005_E_ACAO.Value = 1;

                program.Execute(obj);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region P8000_05_INICIO_DB_INSERT_1_Insert1

                var envList = AppSettings.TestSet.DynamicData["P8000_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("HISPROFI_NUM_IDENTIFICACAO", out var HISPROFI_NUM_IDENTIFICACAO) && HISPROFI_NUM_IDENTIFICACAO == "000000000000002");
                Assert.True(envList[1].TryGetValue("HISPROFI_DATA_SITUACAO", out var HISPROFI_DATA_SITUACAO) && HISPROFI_DATA_SITUACAO == "          ");
                Assert.True(envList[1].TryGetValue("HISPROFI_NSAS_SIVPF", out var HISPROFI_NSAS_SIVPF) && HISPROFI_NSAS_SIVPF == "000000000");
                Assert.True(envList[1].TryGetValue("HISPROFI_NSL", out var HISPROFI_NSL) && HISPROFI_NSL == "000000000");
                Assert.True(envList[1].TryGetValue("HISPROFI_SIT_PROPOSTA", out var HISPROFI_SIT_PROPOSTA) && HISPROFI_SIT_PROPOSTA == "   ");
                Assert.True(envList[1].TryGetValue("HISPROFI_SIT_COBRANCA_SIVPF", out var HISPROFI_SIT_COBRANCA_SIVPF) && HISPROFI_SIT_COBRANCA_SIVPF == "   ");
                Assert.True(envList[1].TryGetValue("HISPROFI_SIT_MOTIVO_SIVPF", out var HISPROFI_SIT_MOTIVO_SIVPF) && HISPROFI_SIT_MOTIVO_SIVPF == "000000000");
                Assert.True(envList[1].TryGetValue("HISPROFI_COD_EMPRESA_SIVPF", out var HISPROFI_COD_EMPRESA_SIVPF) && HISPROFI_COD_EMPRESA_SIVPF == "0001");
                Assert.True(envList[1].TryGetValue("HISPROFI_COD_PRODUTO_SIVPF", out var HISPROFI_COD_PRODUTO_SIVPF) && HISPROFI_COD_PRODUTO_SIVPF == "0002");
                Assert.True(envList[1].TryGetValue("HISPROFI_IND_TP_ACAO", out var HISPROFI_IND_TP_ACAO) && HISPROFI_IND_TP_ACAO == "I");
                Assert.True(envList[1].TryGetValue("HISPROFI_IND_TP_SENSIBILIZACAO", out var HISPROFI_IND_TP_SENSIBILIZACAO) && HISPROFI_IND_TP_SENSIBILIZACAO == " ");
                Assert.True(envList[1].TryGetValue("HISPROFI_IND_ENVIO", out var HISPROFI_IND_ENVIO) && HISPROFI_IND_ENVIO == "0");
                Assert.True(envList[1].TryGetValue("HISPROFI_DTA_INI_VIGENCIA", out var HISPROFI_DTA_INI_VIGENCIA) && HISPROFI_DTA_INI_VIGENCIA == "0001-01-01");
                Assert.True(envList[1].TryGetValue("HISPROFI_DTA_FIM_VIGENCIA", out var HISPROFI_DTA_FIM_VIGENCIA) && HISPROFI_DTA_FIM_VIGENCIA == "0001-01-01");
                Assert.True(envList[1].TryGetValue("HISPROFI_NUM_PARCELA", out var HISPROFI_NUM_PARCELA) && HISPROFI_NUM_PARCELA == "000000000");
                Assert.True(envList[1].TryGetValue("HISPROFI_COD_TP_LANCAMENTO", out var HISPROFI_COD_TP_LANCAMENTO) && HISPROFI_COD_TP_LANCAMENTO == "0000");
                Assert.True(envList[1].TryGetValue("HISPROFI_VLR_PREMIO", out var HISPROFI_VLR_PREMIO) && HISPROFI_VLR_PREMIO == "0000000000000.00");
                Assert.True(envList[1].TryGetValue("HISPROFI_COD_ERRO", out var HISPROFI_COD_ERRO) && HISPROFI_COD_ERRO == "000000000");
                Assert.True(envList[1].TryGetValue("HISPROFI_COD_USUARIO", out var HISPROFI_COD_USUARIO) && HISPROFI_COD_USUARIO == "        ");
                Assert.True(envList[1].TryGetValue("HISPROFI_NOM_PROGRAMA", out var HISPROFI_NOM_PROGRAMA) && HISPROFI_NOM_PROGRAMA == "          ");
                Assert.True(envList[1].TryGetValue("HISPROFI_DTA_PROCESSAMENTO_CEF", out var HISPROFI_DTA_PROCESSAMENTO_CEF) && HISPROFI_DTA_PROCESSAMENTO_CEF == "          ");

                #endregion

                Assert.True(program.PF0005W.LK_PF005_SQLCODE == 0);
            }
        }

        [Fact]
        public static void PF0005S_Tests99_Fact()
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

                #region P0050_05_INICIO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

                #endregion

                #region P0110_05_INICIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("P0110_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0110_05_INICIO_DB_SELECT_1_Query1", q1);

                #endregion

                #region P0111_05_INICIO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PFMOTPRO_SIT_MOTIVO_SIVPF" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("P0111_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0111_05_INICIO_DB_SELECT_1_Query1", q2);

                #endregion

                #region P0401_05_INICIO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISPROFI_NSL" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("P0401_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0401_05_INICIO_DB_SELECT_1_Query1", q3);

                #endregion


                #endregion
                var program = new PF0005S();
                PF0005W obj = new PF0005W();

                obj.LK_PF005_E_NUM_IDENTIFICACAO.Value = 2;
                obj.LK_PF005_E_IND_TP_ACAO.Value = "I";
                obj.LK_PF005_E_DTA_INI_VIGENCIA.Value = "";
                obj.LK_PF005_E_DTA_FIM_VIGENCIA.Value = "";
                obj.LK_PF005_E_ACAO.Value = 1;

                program.Execute(obj);
              

                Assert.True(program.PF0005W.LK_PF005_SQLCODE == 100);
            }
        }

    }
}