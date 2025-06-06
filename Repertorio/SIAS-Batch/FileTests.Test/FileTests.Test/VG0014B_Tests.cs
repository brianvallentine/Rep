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
using static Code.VG0014B;

namespace FileTests.Test
{
    [Collection("VG0014B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class VG0014B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region VG0014B_ACOPLADO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , "1234"},
                { "WS_COD_PLANO" , ""},
                { "WS_NUM_SERIE" , ""},
                { "WS_NUM_TITULO" , ""},
                { "WS_STA_TITULO" , ""},
                { "WS_COD_SUB_TITULO" , ""},
                { "WS_DTH_ATIVACAO" , ""},
                { "WS_DTA_CADUCACAO" , ""},
                { "WS_DTH_CRIACAO" , ""},
                { "WS_DTA_FIM_VIGENCIA" , ""},
                { "WS_DTA_INI_SORTEIO" , ""},
                { "WS_DTA_INI_VIGENCIA" , ""},
                { "WS_DTA_SUSPENSAO" , ""},
                { "WS_COD_DV" , ""},
                { "WS_VLR_MENSALIDADE" , ""},
                { "WS_COD_DOC_PARCEIRO_P" , ""},
                { "WS_NUM_MOD_PLANO" , ""},
                { "WS_DES_COMBINACAO" , ""},
                { "WS_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0014B_ACOPLADO", q0);

            #endregion

            #region R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_CURRENT_TIMESTAMP" , "20241030"}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0014B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0014B();
                program.Execute();

                Assert.True(program.AREA_DE_WORK.WS_COD_PRODUTO == "1234");

                Assert.True(program.WS_DATAS.WS_CURRENT_TIMESTAMP == "20241030"); 
            }
        }
    }
}