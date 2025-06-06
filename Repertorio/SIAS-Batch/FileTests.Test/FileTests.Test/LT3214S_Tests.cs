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
using static Code.LT3214S;

namespace FileTests.Test
{
    [Collection("LT3214S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3214S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_CRITICA_PARAMETROS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_CRITICA_PARAMETROS_DB_SELECT_1_Query1", q0);

            #endregion

            #region LT3214S_CPREMIO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
            { "LT028_NUM_PROPOSTA_SIM" , "1"},
            { "LT028_IND_TIPO_VIGENCIA" , "1"},
            { "LT028_DTA_INI_VIGENCIA" , "2021-01-01"},
            { "LT028_DTA_FIM_VIGENCIA" , "2021-12-31"},
            { "LT028_IND_FORMA_COBRANCA_SEG" , "1"},
            { "LT028_IND_FORMA_PGTO_PRIM_PARC" , "1"},
            { "LT028_IND_FORMA_PGTO_DEM_PARC" , "1"},
            { "LT028_VLR_PRIM_PARCELA" , "153.94"},
            { "LT028_VLR_DEMAIS_PARCELAS" , "153.94"},
            { "LT028_DTA_VENC_PRIM_PARCELA" , "2020-12-23"},
            { "LT028_DIA_VENC_DEMAIS_PARCELAS" , "1"},
            { "LT028_QTD_PARCELA" , "10"},
            { "LT028_VLR_IOF_PRIM_PARCELA" , "10.58"},
            { "LT028_VLR_IOF_DEMAIS_PARCELAS" , "10.58"},
            { "LT028_VLR_DESCONTO_FIDELIDADE" , "96.86"},
            { "LT028_VLR_DESCONTO_COB_ADIC" , "116.23"},
            { "LT028_VLR_DESCONTO_RENOVACAO" , "193.73"},
            { "LT028_VLR_DESCONTO_EXPERIENCIA" , "193.73"},
            { "LT028_VLR_DESCONTO_COFRE_INT" , "96.86"},
            { "LT028_VLR_DESCONTO_BLINDAGEM" , "0.00"},
            { "LT028_VLR_DESCONTO_PLURIANUAL" , "0.00"},
            { "LT028_VLR_PREMIO_TARIFARIO" , "1937.30"},
            { "LT028_VLR_DESCONTO_TOTAL" , "503.68"},
            { "LT028_VLR_PREMIO_LIQUIDO" , "1433.62"},
            { "LT028_VLR_ADICIONAL_FRACIONA" , "0.00"},
            { "LT028_VLR_CUSTO_EMISSAO" , "0.00"},
            { "LT028_VLR_IOF" , "105.80"},
            { "LT028_VLR_PREMIO_TOTAL" , "1539.40"},
            { "LT028_QTD_DIAS_VIGENCIA" , "0"},
            { "LT028_VLR_PREMIO_LIQ_PRIM_PARC" , "0.00"},
            { "LT028_VLR_ADICIONAL_PRIM_PARC" , "0.00"},
            { "LT028_VLR_PREMIO_LIQ_DEM_PARC" , "0.00"},
            { "LT028_VLR_ADICIONAL_DEM_PARC" , "0.00"},
            });
            AppSettings.TestSet.DynamicData.Add("LT3214S_CPREMIO", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void LT3214S_Tests_Fact_ReturnCode_0()
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
                #region param
                var param = new LBLT3214_LT3214_AREA_PARAMETROS();
                param.LT3214_COD_LOTERICO.Value = 1;
                param.LT3214_SEQ_PROPOSTA.Value = 1;
                param.LT3214_NUM_PROPOSTA_SIM.Value = 1;
                param.LT3214_HORA_MOVIMENTO.Value = "20:20:20";
                param.LT3214_DATA_MOVIMENTO.Value = "2023-02-06";
                param.LT3214_COD_LOTERICO.Value = 1;
                #endregion
                #endregion
                var program = new LT3214S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE ==0);
                Assert.True(program.LT028.DCLLT_PREMIO.LT028_DTA_VENC_PRIM_PARCELA.Value == "2020-12-23");
            }
        }

        [Fact]
        public static void LT3214S_Tests_Fact_ReturnCode_99()
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
                #region param
                var param = new LBLT3214_LT3214_AREA_PARAMETROS();
                param.LT3214_COD_LOTERICO.Value = 1;
                param.LT3214_SEQ_PROPOSTA.Value = 1;
                param.LT3214_NUM_PROPOSTA_SIM.Value = 1;
                param.LT3214_HORA_MOVIMENTO.Value = "20:20:20";
                param.LT3214_DATA_MOVIMENTO.Value = "2023-02-06";
                param.LT3214_COD_LOTERICO.Value = 1;
                #endregion
                #region LT3214S_CPREMIO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "LT028_NUM_PROPOSTA_SIM" , "1"},
                { "LT028_IND_TIPO_VIGENCIA" , "1"},
                { "LT028_DTA_INI_VIGENCIA" , "2021-01-01"},
                { "LT028_DTA_FIM_VIGENCIA" , "2021-12-31"},
                { "LT028_IND_FORMA_COBRANCA_SEG" , "1"},
                { "LT028_IND_FORMA_PGTO_PRIM_PARC" , "1"},
                { "LT028_IND_FORMA_PGTO_DEM_PARC" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("LT3214S_CPREMIO");
                AppSettings.TestSet.DynamicData.Add("LT3214S_CPREMIO", q1);

                #endregion
                #endregion
                var program = new LT3214S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}