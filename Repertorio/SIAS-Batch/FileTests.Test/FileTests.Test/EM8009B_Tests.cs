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
using static Code.EM8009B;

namespace FileTests.Test
{
    [Collection("EM8009B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class EM8009B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "PRD.EM.D240909.EM8006B.SICAP", "SAIDA01_FILE_NAME_P", "SAIDA02_FILE_NAME_P", "SAIDA03_FILE_NAME_P", "SAIDA04_FILE_NAME_P")]
        public static void EM8009B_Tests_Theory(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
            SAIDA03_FILE_NAME_P = $"{SAIDA03_FILE_NAME_P}_{timestamp}.txt";
            SAIDA04_FILE_NAME_P = $"{SAIDA04_FILE_NAME_P}_{timestamp}.txt";
         
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
                var program = new EM8009B();
                program.Execute(ARQSORT_FILE_NAME_P, ENTRADA_FILE_NAME_P, SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P, SAIDA03_FILE_NAME_P, SAIDA04_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1"].DynamicList;

                Assert.Empty(envList);
                Assert.Empty(envList1);
            }
        }
    }
}

