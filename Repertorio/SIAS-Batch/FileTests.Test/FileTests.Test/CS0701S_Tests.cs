using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.CS0701S;

namespace FileTests.Test
{
    [Collection("CS0701S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class CS0701S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region CS0701S_CURGE190

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE190_COD_PARAMETRO" , ""},
                { "GE190_COD_PRODUTO" , ""},
                { "GE190_STA_PARAMETRO" , ""},
                { "GE190_NOM_CLASSE_PARAM" , ""},
                { "GE190_COD_SISTEMA" , ""},
                { "GE190_DTA_INI_VIGENCA" , ""},
                { "GE190_DTA_FIM_VIGENCIA" , ""},
                { "GE190_DES_PARAMETRO" , ""},
                { "GE190_IND_TP_PARAMETRO" , ""},
                { "GE190_VLR_PARAMETRO" , ""},
                { "GE190_VLR_PARAM_INT" , ""},
                { "GE190_PCT_PARAMETRO" , ""},
                { "GE190_VLR_PARAM_TAXA" , ""},
                { "GE190_DTA_PARAMETRO" , ""},
                { "GE190_VLR_PARAM_REDUZIDO" , ""},
                { "GE190_VLR_PARAM_EXTENDIDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q0);

            #endregion

            #endregion
        }

        [Fact]
        public static void CS0701S_Tests_Fact()
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
                var param = new LBCS0701_CS0701S_AREA_PARAMETROS();

                param.CS0701S_OPERACAO.Value = "01";
                param.CS0701S_DATA_INIVIGENCIA.Value = "2000-10-10";

                var codOperacao = new StringBasis(new PIC("X", "2", "X(002)"), @"01");
                var inivigencia = new StringBasis(new PIC("X", "10", "X(010)"), @"2000-10-10");

                var program = new CS0701S();

                program.Execute(param);
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void CS0701S_Tests_Fact1()
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
                var param = new LBCS0701_CS0701S_AREA_PARAMETROS();

                param.CS0701S_OPERACAO.Value = "02";
                param.CS0701S_DATA_INIVIGENCIA.Value = "2000-10-10";

                var program = new CS0701S();

                program.Execute(param);
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void CS0701S_Tests_Fact2()
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
                var param = new LBCS0701_CS0701S_AREA_PARAMETROS();
                param.CS0701S_OPERACAO.Value = "03";
                param.CS0701S_DATA_INIVIGENCIA.Value = "2000-10-10";

                var program = new CS0701S();

                program.Execute(param);
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void CS0701S_Tests_SemDados()
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
                var param = new LBCS0701_CS0701S_AREA_PARAMETROS();
                param.CS0701S_OPERACAO.Value = "01";
                param.CS0701S_DATA_INIVIGENCIA.Value = "2000-10-10";

                AppSettings.TestSet.DynamicData.Remove("CS0701S_CURGE190");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "GE190_COD_PARAMETRO" , ""},
                { "GE190_COD_PRODUTO" , ""},
                { "GE190_STA_PARAMETRO" , ""},
                { "GE190_NOM_CLASSE_PARAM" , ""},
                { "GE190_COD_SISTEMA" , ""},
                { "GE190_DTA_INI_VIGENCA" , ""},
                { "GE190_DTA_FIM_VIGENCIA" , ""},
                { "GE190_DES_PARAMETRO" , ""},
                { "GE190_IND_TP_PARAMETRO" , ""},
                { "GE190_VLR_PARAMETRO" , ""},
                { "GE190_VLR_PARAM_INT" , ""},
                { "GE190_PCT_PARAMETRO" , ""},
                { "GE190_VLR_PARAM_TAXA" , ""},
                { "GE190_DTA_PARAMETRO" , ""},
                { "GE190_VLR_PARAM_REDUZIDO" , ""},
                { "GE190_VLR_PARAM_EXTENDIDO" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q0);

                var program = new CS0701S();

                program.Execute(param);
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        public static void Load_Parameters_To_FactEM0005B()
        {
            Load_Parameters();

            //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
            //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
            //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

            #region VARIAVEIS_TESTE
            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                    { "GE190_COD_PARAMETRO" , "2"},
                    { "GE190_COD_PRODUTO" , "0"},
                    { "GE190_STA_PARAMETRO" , "1"},
                    { "GE190_NOM_CLASSE_PARAM" , "PSS86005"},
                    { "GE190_COD_SISTEMA" , "PEPS "},
                    { "GE190_DTA_INI_VIGENCA" , "2022-03-11"},
                    { "GE190_DTA_FIM_VIGENCIA" , "9999-12-31"},
                    { "GE190_DES_PARAMETRO" , "USUARIO AUTORIZADO REALIZAR LIBERACOES DE OPERACOES BLOQUEADAS-PEPS"},
                    { "GE190_IND_TP_PARAMETRO" , "6"},
                    { "GE190_VLR_PARAMETRO" , ""},
                    { "GE190_VLR_PARAM_INT" , "1"},
                    { "GE190_PCT_PARAMETRO" , ""},
                    { "GE190_VLR_PARAM_TAXA" , ""},
                    { "GE190_DTA_PARAMETRO" , ""},
                    { "GE190_VLR_PARAM_REDUZIDO" , "CHAR"},
                    { "GE190_VLR_PARAM_EXTENDIDO" , "JOAO PAULO MIROSVICK"},
                });
            AppSettings.TestSet.DynamicData.Remove("CS0701S_CURGE190");
            AppSettings.TestSet.DynamicData.Add("CS0701S_CURGE190", q0);
            #endregion
        }
    }
}
