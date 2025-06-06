using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0110B;

namespace FileTests.Test
{
    [Collection("PF0110B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF0110B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #endregion
        }

        [Theory]
        [InlineData("PRD.GPF.MJUNMOV.D240930", "DES.PF.D241230.PF0110B.ARQESP.txt", "DES.PF.D241230.PF0110B.ARQVP.txt", "DES.PF.D241230.PF0110B.ARQVG.txt", "DES.PF.D241230.PF0110B.ARQDESP.TXT", "DES.PF.D241230.PF0110B.ARQCRESC.TXT")]
        public static void PF0110B_Tests_Theory_Total95Registros(string MOV_SIGAT_FILE_NAME_P, string MOV_ESP_FILE_NAME_P, string MOV_VP_FILE_NAME_P, string MOV_VG_FILE_NAME_P, string MOV_DESP_FILE_NAME_P, string MOV_CRESCER_FILE_NAME_P)
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
                #endregion
                var program = new PF0110B();
                program.Execute(MOV_SIGAT_FILE_NAME_P, MOV_ESP_FILE_NAME_P, MOV_VP_FILE_NAME_P, MOV_VG_FILE_NAME_P, MOV_DESP_FILE_NAME_P, MOV_CRESCER_FILE_NAME_P);
                Assert.True(program.MOV_SIGAT.AllLines.Count == 51);
            }
        }

    }
}