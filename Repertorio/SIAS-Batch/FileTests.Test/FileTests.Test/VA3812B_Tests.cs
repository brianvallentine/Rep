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
using static Code.VA3812B;

namespace FileTests.Test
{
    [Collection("VA3812B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA3812B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA3812B_V1AGENCEF

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_COD_AGENCIA" , ""},
                { "V1MCEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3812B_V1AGENCEF", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA3812B_Entrada_1_R6088.txt", "VA3812B_Saida_1_R6088.txt")]
        public static void VA3812B_Tests_Theory_R6088_ReturnCode_0(string RETCRE_FILE_NAME_P, string RVA3812B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3812B_FILE_NAME_P = $"{RVA3812B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA3812B();
                program.Execute(RETCRE_FILE_NAME_P, RVA3812B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WORK_AREA.AC_LIDOS == 0);
            }
        }
        [Theory]
        [InlineData("VA3812B_Entrada_1_R6090.txt", "VA3812B_Saida_1_R6090.txt")]
        public static void VA3812B_Tests_Theory_R6090_ReturnCode_0(string RETCRE_FILE_NAME_P, string RVA3812B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3812B_FILE_NAME_P = $"{RVA3812B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA3812B();
                program.Execute(RETCRE_FILE_NAME_P, RVA3812B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WORK_AREA.AC_LIDOS == 340);
            }
        }
        [Theory]
        [InlineData("VA3812B_Entrada_1_R6131.txt", "VA3812B_Saida_1_R6131.txt")]
        public static void VA3812B_Tests_Theory_R6131_ReturnCode_0(string RETCRE_FILE_NAME_P, string RVA3812B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3812B_FILE_NAME_P = $"{RVA3812B_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA3812B();
                program.Execute(RETCRE_FILE_NAME_P, RVA3812B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WORK_AREA.AC_LIDOS == 0);
            }
        }
        [Theory]
        [InlineData("VA3812B_Entrada_2_R6090.txt", "VA3812B_Saida_2_R6090.txt")]
        public static void VA3812B_Tests_Theory_R6090_ErrorReturnCode_9(string RETCRE_FILE_NAME_P, string RVA3812B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3812B_FILE_NAME_P = $"{RVA3812B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA3812B_V1AGENCEF

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_COD_AGENCIA" , ""},
                { "V1MCEF_COD_FONTE" , ""},
                },new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VA3812B_V1AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VA3812B_V1AGENCEF", q0);

                #endregion
                #endregion
                var program = new VA3812B();
                program.Execute(RETCRE_FILE_NAME_P, RVA3812B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}