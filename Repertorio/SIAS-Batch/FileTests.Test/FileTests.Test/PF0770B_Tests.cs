using IA_ConverterCommons;
using System.Collections.Generic;
using Xunit;
using Code;
using System.IO;
using System;

namespace FileTests.Test
{
    [Collection("PF0770B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0770B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , "00010"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , "00012"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_PF0770B.txt", "Saida_PF0770B_00.txt")]
        public static void PF0770B_Tests_TheorySemPropostasParaProcessarReturnCode00(string ARQ_0641_ENTR_FILE_NAME_P, string ARQ_0641_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_0641_SAIDA_FILE_NAME_P = $"{ARQ_0641_SAIDA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new PF0770B();
                program.Execute(ARQ_0641_ENTR_FILE_NAME_P, ARQ_0641_SAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program._ARQ_0641_SAIDA.FilePath));
                Assert.True(new FileInfo(program._ARQ_0641_SAIDA.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("Entrada_PF0770B.txt", "Saida_PF0770B_01.txt")]
        public static void PF0770B_Tests_TheoryProcessamentoReturnCode00(string ARQ_0641_ENTR_FILE_NAME_P, string ARQ_0641_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_0641_SAIDA_FILE_NAME_P = $"{ARQ_0641_SAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0770B();
                program.Execute(ARQ_0641_ENTR_FILE_NAME_P, ARQ_0641_SAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program._ARQ_0641_SAIDA.FilePath));
                Assert.True(new FileInfo(program._ARQ_0641_SAIDA.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("Entrada_PF0770B.txt", "Saida_PF0770B_02.txt")]
        public static void PF0770B_Tests_TheoryProcessamentoSemNumPropostaReturnCode00(string ARQ_0641_ENTR_FILE_NAME_P, string ARQ_0641_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_0641_SAIDA_FILE_NAME_P = $"{ARQ_0641_SAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new PF0770B();
                program.Execute(ARQ_0641_ENTR_FILE_NAME_P, ARQ_0641_SAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program._ARQ_0641_SAIDA.FilePath));
                Assert.True(new FileInfo(program._ARQ_0641_SAIDA.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 00);
            }
        }


    }
}