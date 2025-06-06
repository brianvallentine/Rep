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
using static Code.CB0139B;

namespace FileTests.Test.FileTests.Test
{
    [Collection("CB0139B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class CB0139B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region CB0139B_V0EXTRATO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EXTFUNCE_COD_EMPRESA" , ""},
                { "EXTFUNCE_COD_ESCNEG" , ""},
                { "EXTFUNCE_DATA_MOVIMENTO" , ""},
                { "EXTFUNCE_NRSEQ" , ""},
                { "EXTFUNCE_TIPO_MOVIMENTO" , ""},
                { "EXTFUNCE_VAL_MOVIMENTO" , ""},
                { "EXTFUNCE_DATA_OCORRENCIA" , ""},
                { "EXTFUNCE_DESC_OCORRENCIA" , ""},
                { "EXTFUNCE_SALDO_ATUAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0139B_V0EXTRATO", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB0139B_1_t1", "CB0139B_2_t1")]
        public static void CB0139B_Tests_Theory_SistemaQuery(string ARQSORT_FILE_NAME_P, string ARQCEF1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            ARQCEF1_FILE_NAME_P = $"{ARQCEF1_FILE_NAME_P}_{timestamp}.txt";

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

                var program = new CB0139B();
                program.Execute(ARQSORT_FILE_NAME_P, ARQCEF1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var qList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList;
 
                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("CB0139B_1_t2", "CB0139B_2_t2")]
        public static void CB0139B_Tests_Theory_SistemaQuery_SemDados(string ARQSORT_FILE_NAME_P, string ARQCEF1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            ARQCEF1_FILE_NAME_P = $"{ARQCEF1_FILE_NAME_P}_{timestamp}.txt";

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

                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                var program = new CB0139B();
                program.Execute(ARQSORT_FILE_NAME_P, ARQCEF1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("CB0139B_1_t3", "CB0139B_2_t3")]
        public static void CB0139B_Tests_Theory_RelatorioQuery(string ARQSORT_FILE_NAME_P, string ARQCEF1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            ARQCEF1_FILE_NAME_P = $"{ARQCEF1_FILE_NAME_P}_{timestamp}.txt";

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

                var program = new CB0139B();
                program.Execute(ARQSORT_FILE_NAME_P, ARQCEF1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var qList = AppSettings.TestSet.DynamicData["R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1"].DynamicList;

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("CB0139B_1_t4", "CB0139B_2_t4")]
        public static void CB0139B_Tests_Theory_RelatorioQuery_SemDados(string ARQSORT_FILE_NAME_P, string ARQCEF1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            ARQCEF1_FILE_NAME_P = $"{ARQCEF1_FILE_NAME_P}_{timestamp}.txt";

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

                AppSettings.TestSet.DynamicData.Remove("R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

                #endregion

                var program = new CB0139B();
                program.Execute(ARQSORT_FILE_NAME_P, ARQCEF1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("CB0139B_1_t5", "CB0139B_2_t5")]
        public static void CB0139B_Tests_Theory_ExtratoQuery(string ARQSORT_FILE_NAME_P, string ARQCEF1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            ARQCEF1_FILE_NAME_P = $"{ARQCEF1_FILE_NAME_P}_{timestamp}.txt";

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

                var program = new CB0139B();
                program.Execute(ARQSORT_FILE_NAME_P, ARQCEF1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var qList = AppSettings.TestSet.DynamicData["CB0139B_V0EXTRATO"].DynamicList;

                Assert.True(program.RETURN_CODE == 00);
            }
        }        
    }
}