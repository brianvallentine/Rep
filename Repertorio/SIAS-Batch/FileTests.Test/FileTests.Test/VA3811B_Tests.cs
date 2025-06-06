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
using static Code.VA3811B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA3811B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA3811B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA3811B_V1AGENCEF

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_COD_AGENCIA" , "1234"},
                { "V1MCEF_COD_FONTE" , "5678"},
            });
            AppSettings.TestSet.DynamicData.Add("VA3811B_V1AGENCEF", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RETDEB.txt", "RVA3811B_FILE_NAME_P")]
        public static void VA3811B_Tests_Theory(string RETDEB_FILE_NAME_P, string RVA3811B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3811B_FILE_NAME_P = $"{RVA3811B_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA3811B();
                program.Execute(RETDEB_FILE_NAME_P, RVA3811B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.V1ACEF_COD_AGENCIA == "1234");

                Assert.True(program.V1MCEF_COD_FONTE == "5678");

            }
        }

        [Theory]
        [InlineData("RETDEB.txt", "RVA3811B_FILE_NAME_P")]
        public static void VA3811B_Tests_SemDados(string RETDEB_FILE_NAME_P, string RVA3811B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA3811B_FILE_NAME_P = $"{RVA3811B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA3811B();

                AppSettings.TestSet.DynamicData.Remove("VA3811B_V1AGENCEF");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("VA3811B_V1AGENCEF", q0);
                program.Execute(RETDEB_FILE_NAME_P, RVA3811B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 9 );


            }
        }

    }
}