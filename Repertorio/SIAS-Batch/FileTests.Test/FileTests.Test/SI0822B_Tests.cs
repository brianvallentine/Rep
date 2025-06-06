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
using static Code.SI0822B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0822B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0822B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0822B_CEDIDO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0COHISTSI_CONGENER" , ""},
                { "V0COHISTSI_AA_DTMOVTO" , ""},
                { "V0COHISTSI_MM_DTMOVTO" , ""},
                { "V0MEST_RAMO" , ""},
                { "V0COHISTSI_OPERACAO" , ""},
                { "V0COHISTSI_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0822B_CEDIDO", q0);

            #endregion

            #region SI0822B_ACEITO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_CODLIDER" , ""},
                { "V0HISTSINI_AA_DTMOVTO" , ""},
                { "V0HISTSINI_MM_DTMOVTO" , ""},
                { "V0MEST_RAMO" , ""},
                { "V0HISTSINI_OPERACAO" , ""},
                { "V0HISTSINI_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0822B_ACEITO", q1);

            #endregion

            #region SI0822B_V0RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0822B_V0RELATORIOS", q2);

            #endregion

            #region M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""},
                { "V1EMPR_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0CONGENERE_NOMECONG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_SI0822B_1", "Saida_SI0822B_2")]
        public static void SI0822B_Tests_TheoryErro99(string SICEDIDO_FILE_NAME_P, string SIACEITO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SICEDIDO_FILE_NAME_P = $"{SICEDIDO_FILE_NAME_P}_{timestamp}.txt";
            SIACEITO_FILE_NAME_P = $"{SIACEITO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0822B_V0RELATORIOS

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string> { }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("SI0822B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0822B_V0RELATORIOS", q4);

                #endregion
                #endregion
                var program = new SI0822B();
                program.Execute(SICEDIDO_FILE_NAME_P, SIACEITO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert") || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("Saida_SI0822B_1", "Saida_SI0822B_2")]
        public static void SI0822B_Tests_Theory(string SICEDIDO_FILE_NAME_P, string SIACEITO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SICEDIDO_FILE_NAME_P = $"{SICEDIDO_FILE_NAME_P}_{timestamp}.txt";
            SIACEITO_FILE_NAME_P = $"{SIACEITO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1");
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , "Empresa1"},
                    { "V1EMPR_DTCURRENT" , "2020-01-01"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , "Empresa2"},
                    { "V1EMPR_DTCURRENT" , "2020-01-01"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPR_NOM_EMP" , "Empresa3"},
                    { "V1EMPR_DTCURRENT" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Add("M_0000_00_MONTA_CABECALHO_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0CONGENERE_NOMECONG" , "NOMECOMGE"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0CONGENERE_NOMECONG" , "NOMECOMGE"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0CONGENERE_NOMECONG" , "NOMECOMGE"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_00_SELECT_CONGENERE_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new SI0822B();
                program.Execute(SICEDIDO_FILE_NAME_P, SIACEITO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert") || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1);

                //M_0000_00_DELETE_V0RELATORIOS_Delete1 checar se o cont do add data esta igual a 0.
                var envList = AppSettings.TestSet.DynamicData["M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList);


                Assert.True(File.Exists(program.SICEDIDO.FilePath));
                Assert.True(new FileInfo(program.SICEDIDO.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.SIACEITO.FilePath));
                Assert.True(new FileInfo(program.SIACEITO.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}