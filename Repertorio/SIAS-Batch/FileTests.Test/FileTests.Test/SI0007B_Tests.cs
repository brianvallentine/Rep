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
using static Code.SI0007B;
using Newtonsoft.Json;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0007B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0007B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0007B_HIST_AVISOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "LOTERI01_SIGLA_UF" , ""},
                { "LOTERI01_ENDERECO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SIMOLOT1_VALOR_INFORMADO" , ""},
                { "SIMOLOT1_QTD_PORTADORES" , ""},
                { "SIMOLOT1_IND_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0007B_HIST_AVISOS", q1);

            #endregion

            #region M_231_00_ADIANTAMENTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_231_00_ADIANTAMENTO_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("REVISO.txt")]
        public static void SI0007B_Tests_Theory(string RAVISO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RAVISO_FILE_NAME_P = $"{RAVISO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                var program = new SI0007B();

                var fileName = Path.GetFileNameWithoutExtension(RAVISO_FILE_NAME_P);
                RAVISO_FILE_NAME_P = RAVISO_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {RAVISO_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(RAVISO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RAVISO.FilePath));

                Assert.True(new FileInfo(program.RAVISO.FilePath)?.Length > 0);
            }
        }
        [Theory]
        [InlineData("REVISO.txt")]
        public static void SI0007B_Tests_SemDadosTheory(string RAVISO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RAVISO_FILE_NAME_P = $"{RAVISO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                var program = new SI0007B();

                Load_Parameters();

                #region VARIAVEIS_TESTE

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1", q0);
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("SI0007B_HIST_AVISOS");
                AppSettings.TestSet.DynamicData.Add("SI0007B_HIST_AVISOS", q1);
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_231_00_ADIANTAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_231_00_ADIANTAMENTO_DB_SELECT_1_Query1", q2);

                #endregion
                program.Execute(RAVISO_FILE_NAME_P);

                Assert.True(program.AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE == 100);

            }
        }
    }
}