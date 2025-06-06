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
using static Code.BI8173B;

namespace FileTests.Test
{
    [Collection("BI8173B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI8173B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region BI8173B_CPROPOSTA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_REG_DIA" , ""},
                { "WS_REG_MES" , ""},
                { "WS_REG_ANO" , ""},
                { "WS_VALOR_RCAP" , ""},
                { "WS_QUANT_PROP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8173B_CPROPOSTA", q0);

            #endregion

            #region BI8173B_CPROPOSTA_TOT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_REG_MES_TOT" , ""},
                { "WS_REG_ANO_TOT" , ""},
                { "WS_VALOR_RCAP" , ""},
                { "WS_QUANT_PROP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8173B_CPROPOSTA_TOT", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RBI8173A")]
        public static void BI8173B_Tests_Theory(string RBI8173A_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI8173A_FILE_NAME_P = $"{RBI8173A_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region BI8173B_CPROPOSTA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_REG_DIA" , "04"},
                { "WS_REG_MES" , "12"},
                { "WS_REG_ANO" , "2017"},
                { "WS_VALOR_RCAP" , "1526.78"},
                { "WS_QUANT_PROP" , "15"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8173B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("BI8173B_CPROPOSTA", q0);

                #endregion

                #region BI8173B_CPROPOSTA_TOT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WS_REG_MES_TOT" , "04"},
                { "WS_REG_ANO_TOT" , "2"},
                { "WS_VALOR_RCAP" , "3000"},
                { "WS_QUANT_PROP" , "30"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8173B_CPROPOSTA_TOT");
                AppSettings.TestSet.DynamicData.Add("BI8173B_CPROPOSTA_TOT", q1);

                #endregion


                #endregion
                var program = new BI8173B();
                program.Execute(RBI8173A_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["BI8173B_CPROPOSTA"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["BI8173B_CPROPOSTA_TOT"].DynamicList;
                Assert.Empty(envList2);


                Assert.True(program.RETURN_CODE == 0);
            }
        }



        [Theory]
        [InlineData("RBI8173A")]
        public static void BI8173B_Tests99_Theory(string RBI8173A_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI8173A_FILE_NAME_P = $"{RBI8173A_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region BI8173B_CPROPOSTA

                var q0 = new DynamicData();
               /* q0.AddDynamic(new Dictionary<string, string>{
                { "WS_REG_DIA" , "04"},
                { "WS_REG_MES" , "12"},
                { "WS_REG_ANO" , "2017"},
                { "WS_VALOR_RCAP" , "1526.78"},
                { "WS_QUANT_PROP" , "15"},
            });*/
                AppSettings.TestSet.DynamicData.Remove("BI8173B_CPROPOSTA");
               // AppSettings.TestSet.DynamicData.Add("BI8173B_CPROPOSTA", q0);

                #endregion

                #region BI8173B_CPROPOSTA_TOT

                var q1 = new DynamicData();
              /*  q1.AddDynamic(new Dictionary<string, string>{
                { "WS_REG_MES_TOT" , "04"},
                { "WS_REG_ANO_TOT" , "2"},
                { "WS_VALOR_RCAP" , "3000"},
                { "WS_QUANT_PROP" , "30"},
            });*/
                AppSettings.TestSet.DynamicData.Remove("BI8173B_CPROPOSTA_TOT");
               // AppSettings.TestSet.DynamicData.Add("BI8173B_CPROPOSTA_TOT", q1);

                #endregion


                #endregion
                var program = new BI8173B();
                program.Execute(RBI8173A_FILE_NAME_P);

              
                Assert.True(program.WABEND.WNR_EXEC_SQL == 9800);
            }
        }




    }



}