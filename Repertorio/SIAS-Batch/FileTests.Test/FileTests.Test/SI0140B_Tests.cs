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
using static Code.SI0140B;

namespace FileTests.Test
{
    [Collection("SI0140B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0140B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0140B_MESTHIST

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_FONTE" , ""},
                { "V0MEST_RAMO" , ""},
                { "V0MEST_CODCAU" , ""},
                { "V0MEST_SITUACAO" , ""},
                { "V0SINI_DESCAU" , ""} ,
                { "V0MEST_NUM_APOLICE" , ""},
                { "V0MEST_NUM_APOL_SINISTRO" , ""},
                { "V0AUTO1_NUM_ITEM" , ""},
                { "V0HIST_VAL_OPERACAO" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0140B_MESTHIST", q0);

            #endregion

            #region M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0AUTO_PROPRIET" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0140B_t1")]
        public static void SI0140B_Tests_Theory_Return00(string SI0140BR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0140BR_FILE_NAME_P = $"{SI0140BR_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0140B_MESTHIST

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0MEST_FONTE" , "0"},
                    { "V0MEST_RAMO" , "0"},
                    { "V0MEST_CODCAU" , "0"},
                    { "V0MEST_SITUACAO" , ""},
                    { "V0SINI_DESCAU" , "0"} ,
                    { "V0MEST_NUM_APOLICE" , "0"},
                    { "V0MEST_NUM_APOL_SINISTRO" , "0"},
                    { "V0AUTO1_NUM_ITEM" , "0"},
                    { "V0HIST_VAL_OPERACAO" , "0"},
                    { "V1SIST_DTMOVABE" , "0"},
                    { "V1SIST_DTCURRENT" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0140B_MESTHIST");
                AppSettings.TestSet.DynamicData.Add("SI0140B_MESTHIST", q0);

                #endregion

                #region M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0AUTO_PROPRIET" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI0140B();
                program.Execute(SI0140BR_FILE_NAME_P);

                var envListMesthist = AppSettings.TestSet.DynamicData["SI0140B_MESTHIST"].DynamicList;
                Assert.Empty(envListMesthist);

                var envSelectProprietario = AppSettings.TestSet.DynamicData["M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envSelectProprietario);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("SI0140B_t2")]
        public static void SI0140B_Tests_Theory_Return99(string SI0140BR_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0140BR_FILE_NAME_P = $"{SI0140BR_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0140B_MESTHIST

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0MEST_FONTE" , "0"},
                    { "V0MEST_RAMO" , "0"},
                    { "V0MEST_CODCAU" , "0"},
                    { "V0MEST_SITUACAO" , ""},
                    { "V0SINI_DESCAU" , "0"} ,
                    { "V0MEST_NUM_APOLICE" , "0"},
                    { "V0MEST_NUM_APOL_SINISTRO" , "0"},
                    { "V0AUTO1_NUM_ITEM" , "0"},
                    { "V0HIST_VAL_OPERACAO" , "0"},
                    { "V1SIST_DTMOVABE" , "0"},
                    { "V1SIST_DTCURRENT" , "0"},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0140B_MESTHIST");
                AppSettings.TestSet.DynamicData.Add("SI0140B_MESTHIST", q0);

                #endregion

                #region M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V0AUTO_PROPRIET" , "0"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI0140B();
                program.Execute(SI0140BR_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}