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
using static Code.VG0283B;
using Newtonsoft.Json;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG0283B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0283B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0283B_V1RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_NUM_APOL" , ""},
                { "V1RELA_CODSUBES" , ""},
                { "V1RELA_CODUNIMO" , ""},
                { "V1RELA_PERI_INI" , ""},
                { "V1RELA_PERI_FIN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0283B_V1RELATORIOS", q1);

            #endregion

            #region VG0283B_V2COMISSAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1COMI_CODSUBES" , ""},
                { "V1COMI_OPERACAO" , ""},
                { "V1COMI_DTMOVTO" , ""},
                { "V1COMI_VLCOMIS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0283B_V2COMISSAO", q2);

            #endregion

            #region R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0MOED_SIGLUNIM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1", q5);

            #endregion

            #region R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1SUBG_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVG0283B_FILE_NAME_P")]
        public static void VG0283B_Tests_Theory(string RVG0283B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0283B_FILE_NAME_P = $"{RVG0283B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                var program = new VG0283B();

                var fileName = Path.GetFileNameWithoutExtension(RVG0283B_FILE_NAME_P);
                RVG0283B_FILE_NAME_P = RVG0283B_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {RVG0283B_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1");
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "CAIXA SEGURADORA S.A."}});
                AppSettings.TestSet.DynamicData.Add("R0300_00_MONTA_CABECALHOS_DB_SELECT_1_Query1", q3);

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG0283B_V2COMISSAO");
                q5.AddDynamic(new Dictionary<string, string>{
                 { "V1COMI_CODSUBES" , ""},
                 { "V1COMI_OPERACAO" , ""},
                 { "V1COMI_DTMOVTO" , "10-10-2000"},
                 { "V1COMI_VLCOMIS" , "9999"},});
                AppSettings.TestSet.DynamicData.Add("VG0283B_V2COMISSAO", q5);


                program.Execute(RVG0283B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RVG0283B.FilePath));
                Assert.True(new FileInfo(program.RVG0283B.FilePath)?.Length > 0);

            }
        }
        [Theory]
        [InlineData("RVG0283B_FILE_NAME_P")]
        public static void VG0283B_Tests_Sem_Dados(string RVG0283B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0283B_FILE_NAME_P = $"{RVG0283B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...
                #region VARIAVEIS_TESTE
                var program = new VG0283B();
                /* var q1 = new DynamicData();
                 AppSettings.TestSet.DynamicData.Remove("VG0283B_V1RELATORIOS");
                 AppSettings.TestSet.DynamicData.Add("VG0283B_V1RELATORIOS", q1);*/

                /* var q0 = new DynamicData();
                 AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_Query1");
                 AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_Query1", q0);*/

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG0283B_V1RELATORIOS");
                q1.AddDynamic(new Dictionary<string, string>{
                  { "V1RELA_NUM_APOL" , ""},
                  { "V1RELA_CODSUBES" , ""},
                  { "V1RELA_CODUNIMO" , ""},
                  { "V1RELA_PERI_INI" , ""},
                  { "V1RELA_PERI_FIN" , ""},
              }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("VG0283B_V1RELATORIOS", q1);

                #endregion
                program.Execute(RVG0283B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}