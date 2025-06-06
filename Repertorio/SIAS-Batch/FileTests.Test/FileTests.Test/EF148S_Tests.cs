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
using static Code.EF148S;

namespace FileTests.Test
{
    [Collection("EF148S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EF148S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region P010_INS_PROC_DB_INSERT_1_Insert1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "EF148_NUM_CONTRATO_APOL" , ""},
                { "EF148_COD_PRODUTO" , ""},
                { "EF148_COD_COBERTURA" , ""},
                { "EF148_DTH_INI_VIGENCIA" , ""},
                { "EF148_NUM_RAMO_CONTABIL" , ""},
                { "EF148_COD_PRODUTO_ACESS" , ""},
                { "EF148_COD_COBERTURA_ACESS" , ""},
                { "EF148_NUM_APOLICE" , ""},
                { "EF148_DTH_FIM_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P010_INS_PROC_DB_INSERT_1_Insert1", q0);

            #endregion

            #region P020_UPD_PROC_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EF148_DTH_FIM_VIGENCIA" , ""},
                { "WS_DTH_FIM_VIGENCIA_NULL" , ""},
                { "EF148_COD_COBERTURA_ACESS" , ""},
                { "EF148_NUM_RAMO_CONTABIL" , ""},
                { "EF148_COD_PRODUTO_ACESS" , ""},
                { "EF148_NUM_APOLICE" , ""},
                { "EF148_NUM_CONTRATO_APOL" , ""},
                { "EF148_DTH_INI_VIGENCIA" , ""},
                { "EF148_COD_COBERTURA" , ""},
                { "EF148_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P020_UPD_PROC_DB_UPDATE_1_Update1", q1);

            #endregion

            #region P030_DEL_PROC_DB_DELETE_1_Delete1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EF148_NUM_CONTRATO_APOL" , ""},
                { "EF148_COD_PRODUTO" , ""},
                { "EF148_COD_COBERTURA" , ""},
                { "EF148_DTH_INI_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P030_DEL_PROC_DB_DELETE_1_Delete1", q2);

            #endregion

            #region P040_SEL_PROC_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "EF148_NUM_CONTRATO_APOL" , ""},
                { "EF148_COD_PRODUTO" , ""},
                { "EF148_COD_COBERTURA" , ""},
                { "EF148_DTH_INI_VIGENCIA" , ""},
                { "EF148_NUM_RAMO_CONTABIL" , ""},
                { "EF148_COD_PRODUTO_ACESS" , ""},
                { "EF148_COD_COBERTURA_ACESS" , ""},
                { "EF148_NUM_APOLICE" , ""},
                { "EF148_DTH_FIM_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P040_SEL_PROC_DB_SELECT_1_Query1", q3);

            #endregion

            #region P041_SEL_PROC_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "EF148_NUM_CONTRATO_APOL" , ""},
                { "EF148_COD_PRODUTO" , ""},
                { "EF148_COD_COBERTURA" , ""},
                { "EF148_DTH_INI_VIGENCIA" , ""},
                { "EF148_NUM_RAMO_CONTABIL" , ""},
                { "EF148_COD_PRODUTO_ACESS" , ""},
                { "EF148_COD_COBERTURA_ACESS" , ""},
                { "EF148_NUM_APOLICE" , ""},
                { "EF148_DTH_FIM_VIGENCIA" , ""},
                { "EF148_NUM_APOLICE_EF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P041_SEL_PROC_DB_SELECT_1_Query1", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void EF148S_Tests_Fact()
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
                #endregion
                var program = new EF148S();
                var ef = new EF148S_LINKAGE_EF148S() { LK_OPERACAO = new StringBasis(new PIC("X", "1", "X(1)."), @"I") };
                program.Execute(ef);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["P010_INS_PROC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("EF148_NUM_RAMO_CONTABIL", out var valor) && valor == "0000");
            }
        }
        [Fact]
        public static void EF148S_Tests_Fact1()
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
                #endregion
                var program = new EF148S();
                var ef = new EF148S_LINKAGE_EF148S() { LK_OPERACAO = new StringBasis(new PIC("X", "1", "X(1)."), @"D") };
                program.Execute(ef);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["P030_DEL_PROC_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList);
            }
        }
        [Fact]
        public static void EF148S_Tests_Fact2()
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
                #endregion
                var program = new EF148S();
                var ef = new EF148S_LINKAGE_EF148S() { LK_OPERACAO = new StringBasis(new PIC("X", "1", "X(1)."), @"S") };
                program.Execute(ef);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["P041_SEL_PROC_DB_SELECT_1_Query1"].DynamicList;
                Assert.NotEmpty(envList);

            }
        }
        [Fact]
        public static void EF148S_Tests_Fact3()
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
                #endregion
                var program = new EF148S();
                var ef = new EF148S_LINKAGE_EF148S() { LK_OPERACAO = new StringBasis(new PIC("X", "1", "X(1)."), @"C") };
                program.Execute(ef);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["P040_SEL_PROC_DB_SELECT_1_Query1"].DynamicList;
                Assert.NotEmpty(envList);
            }
        }
        [Fact]
        public static void EF148S_Tests_Fact4()
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
                #endregion
                var program = new EF148S();
                var ef = new EF148S_LINKAGE_EF148S() { LK_OPERACAO = new StringBasis(new PIC("X", "1", "X(1)."), @"U") };
                program.Execute(ef);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);


                var envList = AppSettings.TestSet.DynamicData["P041_SEL_PROC_DB_SELECT_1_Query1"].DynamicList;
                Assert.NotEmpty(envList);

                var envList1 = AppSettings.TestSet.DynamicData["P020_UPD_PROC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("WS_DTH_FIM_VIGENCIA_NULL", out var valor) && valor == "-001");
            }
        }
    }
}