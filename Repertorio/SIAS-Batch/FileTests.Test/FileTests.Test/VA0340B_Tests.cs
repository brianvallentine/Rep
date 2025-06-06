using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0340B;
using System.IO;
using Newtonsoft.Json;

namespace FileTests.Test
{
    [Collection("VA0340B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0340B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0050_00_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMINDEB" , ""},
                { "SIST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0050_00_INICIO_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0050_00_INICIO_DB_SELECT_3_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FERIADOS_DATA_FERIADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_3_Query1", q2);

            #endregion

            #region R0050_00_INICIO_DB_SELECT_4_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "PARM_VERSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_INICIO_DB_SELECT_4_Query1", q3);

            #endregion

            #region VA0340B_V0HCONTAVA

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "OCORRHISTCTA" , ""},
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
            AppSettings.TestSet.DynamicData.Add("VA0340B_V0HCONTAVA", q4);

            #endregion

            #region R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_SITUACAO" , "3"},
                { "V0PROP_CODPRODU" , "7732"},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_SITUACAO" , "1"},
                { "V0PARC_OPCAOPAG" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1", q6);

            #endregion

            #region R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "OCORRHISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , "S"},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_3_Query1", q8);

            #endregion

            #region R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DTVENCTO" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1", q9);

            #endregion

            #region R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "DTVENCTO" , "2"},
                { "PARM_NSA" , ""},
                { "SQL_NOT_NULL" , ""},
                { "NSL" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
                { "OCORRHISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1", q10);

            #endregion

            #region R9000_00_FINALIZA_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "PARM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9000_00_FINALIZA_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R9000_00_FINALIZA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9000_00_FINALIZA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R9000_00_FINALIZA_DB_INSERT_2_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "SIST_CURRDATE" , ""},
                { "SIST_DTMAXDEB" , ""},
                { "PARM_VERSAO" , ""},
                { "FITSAS_REG" , ""},
                { "FITSAS_VALOR" , ""},
                { "FITSAS_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9000_00_FINALIZA_DB_INSERT_2_Insert1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVIMENTO_FILE.txt")]
        public static void VA0340B_Tests_Theory(string MOVIMENTO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                var fileName = Path.GetFileNameWithoutExtension(MOVIMENTO_FILE_NAME_P);
                MOVIMENTO_FILE_NAME_P = MOVIMENTO_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                AppSettings.TestSet.IsTest = true;
                var program = new VA0340B();

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {MOVIMENTO_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(MOVIMENTO_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVIMENTO.FilePath));
                Assert.True(new FileInfo(program.MOVIMENTO.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R9000_00_FINALIZA_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_1_Update1"].DynamicList;
                //var envList3 = AppSettings.TestSet.DynamicData["R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_2_Update1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R9000_00_FINALIZA_DB_UPDATE_1_Update1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R9000_00_FINALIZA_DB_INSERT_2_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList2?.Count > 1);
                //Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);

                Assert.True(envList[1].TryGetValue("PARM_NSA", out var valor) && valor == "0001");
                Assert.True(envList2[1].TryGetValue("NRPARCEL", out valor) && valor == "0000");
                //Assert.True(envList3[1].TryGetValue("NSL", out valor) && valor == "000000001");
                Assert.True(envList4[1].TryGetValue("PARM_NSA", out valor) && valor == "0001");
                Assert.True(envList5[1].TryGetValue("FITSAS_REG", out valor) && valor == "000000002");

            }
        }
    }
}