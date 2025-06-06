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
using static Code.BI8172B;

namespace FileTests.Test
{
    [Collection("BI8172B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI8172B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
        
            #region BI8172B_CPROPOSTA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , ""},
                { "WS_REG_DET_EXTRATO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI8172B_CPROPOSTA", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RBI8172A", "RBI8172A")]
        public static void BI8172B_Tests_Theory(string RBI8172A_FILE_NAME_P, string RBI8172B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI8172A_FILE_NAME_P = $"{RBI8172A_FILE_NAME_P}_{timestamp}.txt";
            RBI8172B_FILE_NAME_P = $"{RBI8172B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PARAMETERS
                #region BI8172B_CPROPOSTA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , "6919"},
                { "WS_REG_DET_EXTRATO" , "106900007256;95542148893;29999090304673;6919;ELO INTERNACIONAL I           ;29/11/2017;01/12/2017;0000000000095\r\n\t\t\t\t\t\t\t,40;"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI8172B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("BI8172B_CPROPOSTA", q0);

                #endregion

                #endregion
                #endregion
                var program = new BI8172B();
                program.Execute(RBI8172A_FILE_NAME_P, RBI8172B_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["BI8172B_CPROPOSTA"].DynamicList;
                Assert.Empty(envList1);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("RBI8172A", "RBI8172A")]
        public static void BI8172B_Tests99_Theory(string RBI8172A_FILE_NAME_P, string RBI8172B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RBI8172A_FILE_NAME_P = $"{RBI8172A_FILE_NAME_P}_{timestamp}.txt";
            RBI8172B_FILE_NAME_P = $"{RBI8172B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PARAMETERS
                #region BI8172B_CPROPOSTA

                var q0 = new DynamicData();
                /*q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PRODUTO" , null},
                { "WS_REG_DET_EXTRATO" , null},
                });*/
                AppSettings.TestSet.DynamicData.Remove("BI8172B_CPROPOSTA");
                //AppSettings.TestSet.DynamicData.Add("BI8172B_CPROPOSTA", q0);

                #endregion

                #endregion
                #endregion
                var program = new BI8172B();
                program.Execute(RBI8172A_FILE_NAME_P, RBI8172B_FILE_NAME_P);

               

                Assert.True(program.WFIM_PROPOSTA == "S");
            }
        }


    }
}