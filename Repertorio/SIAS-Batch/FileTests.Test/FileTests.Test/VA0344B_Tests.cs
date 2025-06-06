using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0344B;
using Newtonsoft.Json;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0344B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0344B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMINDEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "PARM_VERSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA0344B_DEBITO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0344B_DEBITO", q2);

            #endregion

            #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "PARM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q3);

            #endregion

            #region M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""},
                { "SQL_NOT_NULL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_9000_FINALIZA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region M_9000_FINALIZA_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMAXDEB" , ""},
                { "PARM_VERSAO" , ""},
                { "FITSAS_REG" , ""},
                { "FITSAS_VALOR" , ""},
                { "FITSAS_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_9000_FINALIZA_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVIMENTO_02.txt")]
        public static void VA0344B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                var fileName = Path.GetFileNameWithoutExtension(MOVIMENTO_FILE_NAME_P);
                MOVIMENTO_FILE_NAME_P = MOVIMENTO_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                AppSettings.TestSet.IsTest = true;
                var program = new VA0344B();

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {MOVIMENTO_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(MOVIMENTO_FILE_NAME_P);
                //M_0000_PRINCIPAL_DB_INSERT_1_Insert1
                //M_9000_FINALIZA_DB_INSERT_1_Insert1

                Assert.True(File.Exists(program.MOVIMENTO.FilePath));
                Assert.True(new FileInfo(program.MOVIMENTO.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["M_9000_FINALIZA_DB_INSERT_1_Insert1"].DynamicList;
                

                Assert.True(envList?.Count > 1);
                Assert.True(envList2?.Count > 1);
             

                Assert.True(envList[1].TryGetValue("PARM_NSA", out var valor) && valor == "0001");
                Assert.True(envList2[1].TryGetValue("FITSAS_REG", out valor) && valor == "000000003");
            }
        }
    }
}