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
using static Code.PF0771B;

namespace FileTests.Test
{
    [Collection("PF0771B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class PF0771B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_PF0771B_RegistroVazio.txt", "Saida_PF0771B.txt")]
        public static void PF0771B_Tests_Theory_ReturnEmptyFile(string ARQ_0711_ENTR_FILE_NAME_P, string ARQ_0711_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_0711_SAIDA_FILE_NAME_P = $"{ARQ_0711_SAIDA_FILE_NAME_P}_{timestamp}.txt";
           
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
                var program = new PF0771B();
                program.Execute(ARQ_0711_ENTR_FILE_NAME_P, ARQ_0711_SAIDA_FILE_NAME_P);

                Assert.True(program.AC_0711_LIDO == 1);
                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Entrada_PF0771B_RegistroHT.txt", "Saida_PF0771B.txt")]
        public static void PF0771B_Tests_Theory_RegistroHt(string ARQ_0711_ENTR_FILE_NAME_P, string ARQ_0711_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_0711_SAIDA_FILE_NAME_P = $"{ARQ_0711_SAIDA_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new PF0771B();
                program.Execute(ARQ_0711_ENTR_FILE_NAME_P, ARQ_0711_SAIDA_FILE_NAME_P);

                Assert.True(program.REG_0711_SAIDA.FILLER_1 == "H");
                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Entrada_PF0771B_RegistroX.txt", "Saida_PF0771B.txt")]
        public static void PF0771B_Tests_Theory_Registro_OrigemProposta6(string ARQ_0711_ENTR_FILE_NAME_P, string ARQ_0711_SAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQ_0711_SAIDA_FILE_NAME_P = $"{ARQ_0711_SAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1");
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , "6"}
                });
                AppSettings.TestSet.DynamicData.Add("M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new PF0771B();
                program.Execute(ARQ_0711_ENTR_FILE_NAME_P, ARQ_0711_SAIDA_FILE_NAME_P);

                Assert.True(program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 6);
                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}