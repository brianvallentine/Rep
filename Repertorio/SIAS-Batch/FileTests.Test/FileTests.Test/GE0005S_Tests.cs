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
using static Code.GE0005S;

namespace FileTests.Test
{
    [Collection("GE0005S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GE0005S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_SELECT_GE292_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE292_COD_GRUPO_SUSEP" , ""},
                { "GE292_COD_RAMO_SUSEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_GE292_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0005S_Tests_Fact_SelecionaGrupoRamo_Sucesso()
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
                var param = new GE0005S_GE0005S_LINKAGE();
                param.GE0005S_PRODUTO.Value = 1;
                param.GE0005S_GRUPO_SUSEP.Value = 3;
                param.GE0005S_RAMO_SUSEP.Value = 4;
                param.GE0005S_RAMO_EMISSOR.Value = 3;
                param.GE0005S_INIVIGENCIA.Value = "2021-01-01";


                #region R1100_00_SELECT_GE292_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GE292_COD_GRUPO_SUSEP" , "25"},
                { "GE292_COD_RAMO_SUSEP" , "32"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_GE292_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_GE292_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new GE0005S();
                program.Execute(param);

                Assert.True(program.AREA_DE_WORK.WRETORNO.Value == " ");
                Assert.True(program.GE0005S_LINKAGE.GE0005S_GRUPO_SUSEP.Value == 25);
                Assert.True(program.GE0005S_LINKAGE.GE0005S_RAMO_SUSEP.Value == 32);

            }
        }
        [Fact]
        public static void GE0005S_Tests_Fact_SemSelecionar_Sucesso()
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
                var param = new GE0005S_GE0005S_LINKAGE();
                param.GE0005S_PRODUTO.Value = 1;
                param.GE0005S_GRUPO_SUSEP.Value = 3;
                param.GE0005S_RAMO_SUSEP.Value = 4;
                param.GE0005S_RAMO_EMISSOR.Value = 3;
                param.GE0005S_INIVIGENCIA.Value = "2021-01-01";


                #endregion
                var program = new GE0005S();
                program.Execute(param);

                Assert.True(program.AREA_DE_WORK.WRETORNO.Value == " ");
                Assert.True(program.GE0005S_LINKAGE.GE0005S_GRUPO_SUSEP.Value == 0);
                Assert.True(program.GE0005S_LINKAGE.GE0005S_RAMO_SUSEP.Value == 0);

            }
        }
        [Fact]
        public static void GE0005S_Tests_Fact_RamoEmissor_48_GrupoSusep_08_Sucesso()
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
                var param = new GE0005S_GE0005S_LINKAGE();
                param.GE0005S_PRODUTO.Value = 1;
                param.GE0005S_GRUPO_SUSEP.Value = 3;
                param.GE0005S_RAMO_SUSEP.Value = 4;
                param.GE0005S_RAMO_EMISSOR.Value = 48;
                param.GE0005S_INIVIGENCIA.Value = "2010-01-01";


                #endregion
                var program = new GE0005S();
                program.Execute(param);

                Assert.True(program.AREA_DE_WORK.WRETORNO.Value == " ");
                Assert.True(program.GE0005S_LINKAGE.GE0005S_GRUPO_SUSEP.Value == 8);
                Assert.True(program.GE0005S_LINKAGE.GE0005S_RAMO_SUSEP.Value == 870);

            }
        }
        [Fact]
        public static void GE0005S_Tests_Fact_Erro()
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
                var param = new GE0005S_GE0005S_LINKAGE();
                param.GE0005S_PRODUTO.Value = 1;
                param.GE0005S_GRUPO_SUSEP.Value = 3;
                param.GE0005S_RAMO_SUSEP.Value = 4;
                param.GE0005S_RAMO_EMISSOR.Value = 48;
                param.GE0005S_INIVIGENCIA.Value = "2010-01-01";

                #region R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1",q0);

                #endregion

                #endregion
                var program = new GE0005S();
                program.Execute(param);

                Assert.True(program.AREA_DE_WORK.WRETORNO.Value == "*");
            }
        }
    }
}