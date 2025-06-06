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
using static Code.SI0120B;

namespace FileTests.Test
{
    [Collection("SI0120B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0120B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0120B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATO_DTINIVIG" , ""},
                { "RELATO_DTTERVIG" , ""},
                { "RELATO_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0120B_V1RELATSINI", q2);

            #endregion

            #region SI0120B_V1CONTSINI

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CONTSIN_FONTE" , ""},
                { "CONTSIN_PROTSINI" , ""},
                { "CONTSIN_DAC" , ""},
                { "CONTSIN_APOLICE" , ""},
                { "CONTSIN_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0120B_V1CONTSINI", q3);

            #endregion

            #region M_240_000_ACESSA_TGEFONTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TGEFONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_ACESSA_TGEFONTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_270_000_LER_TAPOLICE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_LER_TAPOLICE_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0120B_OUTPUT_202504030000")]
        public static void SI0120B_Tests_Theory(string SI0120M1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "Teste"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new SI0120B();
                program.Execute(SI0120M1_FILE_NAME_P);

                Assert.Empty(AppSettings.TestSet.DynamicData["M_015_000_CABECALHOS_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["SI0120B_V1RELATSINI"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["SI0120B_V1CONTSINI"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1"].DynamicList.ToList());

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0120B_OUTPUT_202504030001")]
        public static void SI0120B_Tests_Theory_Return_Code_99(string SI0120M1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMA_DTMOVABE" , ""},
                    { "SISTEMA_DTCURRENT" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);
                #endregion
                var program = new SI0120B();
                program.Execute(SI0120M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}