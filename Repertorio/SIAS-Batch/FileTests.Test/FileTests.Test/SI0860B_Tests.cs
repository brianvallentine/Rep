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
using static Code.SI0860B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0860B_Tests")]
    public class SI0860B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0860B_CBASICA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINBENCB_NUM_APOLICE" , ""},
                { "SINBENCB_NUM_SINISTRO" , ""},
                { "SINBENCB_NUM_BILHETE" , ""},
                { "SINBENCB_OCORR_HISTORICO" , ""},
                { "SINBENCB_NOME_BENEFICIARIO" , ""},
                { "SINBENCB_ENDERECO" , ""},
                { "SINBENCB_BAIRRO" , ""},
                { "SINBENCB_CIDADE" , ""},
                { "SINBENCB_SIGLA_UF" , ""},
                { "SINBENCB_CEP" , ""},
                { "SINBENCB_SIT_REGISTRO" , ""},
                { "SINBENCB_DTMOVTO" , ""},
                { "SINBENCB_DDD_BENEF_CBASICA" , ""},
                { "SINBENCB_FONE_BENEF_CBASICA" , ""},
                { "SINBENCB_OBS_BENEF_CBASICA" , ""},
                { "SINBENCB_DATA_INDENIZACAO" , ""},
                { "SINBENCB_NUM_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0860B_CBASICA", q1);

            #endregion

            #region SI0860B_CESTORNO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI0860B_CESTORNO", q2);

            #endregion

            #region R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_HISTSINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINBENCB_DATA_INDENIZACAO" , ""},
                { "SINBENCB_OCORR_HISTORICO" , ""},
                { "SINBENCB_NUM_SINISTRO" , ""},
                { "SINBENCB_NUM_APOLICE" , ""},
                { "SINBENCB_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_HISTSINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINBENCB_NUM_APOLICE" , ""},
                { "SINBENCB_NUM_SINISTRO" , ""},
                { "SINBENCB_NUM_BILHETE" , ""},
                { "SINBENCB_OCORR_HISTORICO" , ""},
                { "SINBENCB_NOME_BENEFICIARIO" , ""},
                { "SINBENCB_ENDERECO" , ""},
                { "SINBENCB_BAIRRO" , ""},
                { "SINBENCB_CIDADE" , ""},
                { "SINBENCB_SIGLA_UF" , ""},
                { "SINBENCB_CEP" , ""},
                { "SINBENCB_SIT_REGISTRO" , ""},
                { "SINBENCB_DTMOVTO" , ""},
                { "SINBENCB_DDD_BENEF_CBASICA" , ""},
                { "SINBENCB_FONE_BENEF_CBASICA" , ""},
                { "SINBENCB_OBS_BENEF_CBASICA" , ""},
                { "SINBENCB_DATA_INDENIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINBENCB_OCORR_HISTORICO" , ""},
                { "SINBENCB_NUM_SINISTRO" , ""},
                { "SINBENCB_NUM_APOLICE" , ""},
                { "SINBENCB_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0860B_t1")]
        public static void SI0860B_Tests_Theory_Erro99(string SI0860BA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0860BA_FILE_NAME_P = $"{SI0860BA_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTCURRENT" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0860B();
                program.Execute(SI0860BA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0860B_t2")]
        public static void SI0860B_Tests_Theory(string SI0860BA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0860BA_FILE_NAME_P = $"{SI0860BA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region SI0860B_CESTORNO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("SI0860B_CESTORNO");
                AppSettings.TestSet.DynamicData.Add("SI0860B_CESTORNO", q2);

                #region R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_HISTSINI" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion

                #endregion
                var program = new SI0860B();
                program.Execute(SI0860BA_FILE_NAME_P);

                //R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0110_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList);

                //R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1"].DynamicList);

                //R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0221_00_NOME_SEGURADO_DB_SELECT_1_Query1"].DynamicList);

                //R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0222_00_DATA_PRIMEIRA_IND_DB_SELECT_1_Query1"].DynamicList);

                //R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0250_00_UPDATE_CBASICA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("SINBENCB_NUM_BILHETE", out var valor) && valor.Contains("0"));
                Assert.True(envList.Count > 1);

                //R0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0320_00_ACESSA_HISTSINI_DB_SELECT_1_Query1"].DynamicList);

                //R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1"].DynamicList);

                //R0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R0350_00_UPDATE_CBASICA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("SINBENCB_NUM_BILHETE", out var valor1) && valor1.Contains("0"));
                Assert.True(envList1.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}