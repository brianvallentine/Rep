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
using static Code.PF0402B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0402B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0402B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0205_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_NOME_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0205_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0210_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_NOME_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0250_00_SELECT_PESSOA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_PESSOA_DB_SELECT_1_Query1", q3);

            #endregion

            #region PF0402B_HIST_PROP_FIDELIZ

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0402B_HIST_PROP_FIDELIZ", q4);

            #endregion

            #region R0230_00_LER_DATA_GERACAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_DATA_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_LER_DATA_GERACAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-16"}
            });
            AppSettings.TestSet.DynamicData.Add("R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0648B_1.txt", "PRD.GPF.MSREJCNP.D240924_LIMITED.txt", "Saida_PF0648B_2.txt")]
        public static void PF0402B_Tests_Theory_Sucesso(string RPF0402B_FILE_NAME_P, string DPF0402B_FILE_NAME_P, string SPF0402B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RPF0402B_FILE_NAME_P = $"{RPF0402B_FILE_NAME_P}_{timestamp}.txt";
            SPF0402B_FILE_NAME_P = $"{SPF0402B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0402B();
                program.Execute(RPF0402B_FILE_NAME_P, DPF0402B_FILE_NAME_P, SPF0402B_FILE_NAME_P);

                Assert.True(File.Exists(program.RPF0402B.FilePath));
                Assert.True(new FileInfo(program.RPF0402B.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Theory]
        [InlineData("Saida_PF0648B_1.txt", "PRD.GPF.MSREJCNP.D240924_LIMITED.txt", "Saida_PF0648B_2.txt")]
        public static void PF0402B_Tests_Theory_Erro99(string RPF0402B_FILE_NAME_P, string DPF0402B_FILE_NAME_P, string SPF0402B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RPF0402B_FILE_NAME_P = $"{RPF0402B_FILE_NAME_P}_{timestamp}.txt";
            SPF0402B_FILE_NAME_P = $"{SPF0402B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q6 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new PF0402B();
                program.Execute(RPF0402B_FILE_NAME_P, DPF0402B_FILE_NAME_P, SPF0402B_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}