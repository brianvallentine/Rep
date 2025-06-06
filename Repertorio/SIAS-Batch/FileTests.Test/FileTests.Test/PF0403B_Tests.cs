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
using static Code.PF0403B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0403B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0403B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2024-07-19"},
                { "V1SIST_DTHOJE" , "2024-10-22"},
                { "V1SIST_QTDIAS" , "739181"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_NUM_PARCELA" , "0"},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_NUM_PARCELA" , "0"},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_NUM_PARCELA" , "1"},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_NUM_PARCELA" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0AGEN_NOMEAGE" , "AEROPORTO PRESIDENTE JK, DF             "}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0AGEN_NOMEAGE" , "AEROPORTO PRESIDENTE JK, DF             "}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0AGEN_NOMEAGE" , "AEROPORTO PRESIDENTE JK, DF             "}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0AGEN_NOMEAGE" , "AEROPORTO PRESIDENTE JK, DF             "}
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_NOME_PRODUTO" , "EXECUTIVO                               "}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_NOME_PRODUTO" , "EXECUTIVO                               "}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_NOME_PRODUTO" , "EXECUTIVO                               "}
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.GPF.MJUNMOV.D240927_LIMITED.txt", "Saida_PF0403B_1.txt", "Saida_PF0403B_1.txt")]
        public static void PF0403B_Tests_Theory_Sucesso(string MOVSIGAT_FILE_NAME_P, string RPF0403B_FILE_NAME_P, string SPF0403B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RPF0403B_FILE_NAME_P = $"{RPF0403B_FILE_NAME_P}_{timestamp}.txt";
            SPF0403B_FILE_NAME_P = $"{SPF0403B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0403B();
                program.Execute(MOVSIGAT_FILE_NAME_P, RPF0403B_FILE_NAME_P, SPF0403B_FILE_NAME_P);


                Assert.True(File.Exists(program.MOVSIGAT.FilePath));
                Assert.True(new FileInfo(program.MOVSIGAT.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);
                
            }
        }

        [Theory]
        [InlineData("PRD.GPF.MJUNMOV.D240927_LIMITED.txt", "Saida_PF0403B_1.txt", "Saida_PF0403B_1.txt")]
        public static void PF0403B_Tests_Theory_Erro99(string MOVSIGAT_FILE_NAME_P, string RPF0403B_FILE_NAME_P, string SPF0403B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RPF0403B_FILE_NAME_P = $"{RPF0403B_FILE_NAME_P}_{timestamp}.txt";
            SPF0403B_FILE_NAME_P = $"{SPF0403B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

                var q0 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new PF0403B();
                program.Execute(MOVSIGAT_FILE_NAME_P, RPF0403B_FILE_NAME_P, SPF0403B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}