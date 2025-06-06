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
using static Code.SI0910B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0910B_Tests")]
    public class SI0910B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "AD001_DES_AMBIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0910B_Tests_Theory(string SIJC0910_FILE_NAME_P)
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
                { "AD001_DES_AMBIENTE" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1", q0);

                #endregion
                var program = new SI0910B();
                program.Execute(new SI0910B_LK_PARAMETROS(), SIJC0910_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.LK_PARAMETROS.LK_PARM_CONTEUDO.LK_TP_ERRO.Value == 00);
            }
        }

        [Theory]
        [InlineData("123456789")]
        public static void SI0910B_Tests_Return99(string SIJC0910_FILE_NAME_P)
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
               
            });

                AppSettings.TestSet.DynamicData.Remove("P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1", q0);

                #endregion
                var program = new SI0910B();
                program.Execute(new SI0910B_LK_PARAMETROS(), SIJC0910_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.LK_PARAMETROS.LK_PARM_CONTEUDO.LK_TP_ERRO.Value == 1);
            }
        }
    }
}