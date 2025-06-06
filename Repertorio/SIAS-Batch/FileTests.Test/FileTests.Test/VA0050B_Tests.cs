using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using System.IO;
using static Code.VA0050B;
using Newtonsoft.Json;
namespace FileTests.Test
{
    [Collection("VA0050B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0050B_Tests
    {
        [Theory]
        [InlineData("mov_file_.txt")]
        public static void VA0050B_Tests_Theory(string MOV_CRIVO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_CRIVO_FILE_NAME_P = $"{MOV_CRIVO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                var fileName = Path.GetFileNameWithoutExtension(MOV_CRIVO_FILE_NAME_P);
                MOV_CRIVO_FILE_NAME_P = MOV_CRIVO_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                AppSettings.TestSet.IsTest = true;
                var program = new VA0050B();

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {MOV_CRIVO_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                #region PARAMETERS
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0050B_CPROPVA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "1"},
                { "COD_CLIENTE" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("VA0050B_CPROPVA", q1);

                #endregion

                #region R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "MATHEUS"},
                { "CLIENTES_CGCCPF" , "21444"},
            });
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , "1"},
                { "HISCOBPR_IMPMORACID" , "1"},
            });
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                program.Execute(MOV_CRIVO_FILE_NAME_P);
                Assert.True(File.Exists(program.MOV_CRIVO.FilePath));
                Assert.True(new FileInfo(program.MOV_CRIVO.FilePath)?.Length > 0);
            }
        }
    }
}