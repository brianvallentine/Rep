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
using Dclgens;
using Code;
using static Code.PF4002B;

namespace FileTests.Test
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("PF4002B_Tests")]
    public class PF4002B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.GPF.CVPRJEMI_teste.D241126")]
        public static void PF4002B_Tests_Theory(string CVPRJEMI_FILE_NAME_P)
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
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_SIT_PROPOSTA" , "2"},
                { "PROPOFID_CANAL_PROPOSTA" , "3"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "4"},
                { "PROPOFID_SITUACAO_ENVIO" , "5"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "07"},
                { "PROPOFID_DATA_PROPOSTA" , "2020-01-01"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "7"},
                { "PROPOFID_VAL_PAGO" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new PF4002B();
                program.Execute(CVPRJEMI_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("PRD.GPF.CVPRJEMI_teste.D241126")]
        public static void PF4002B_Tests99_Theory(string CVPRJEMI_FILE_NAME_P)
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
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q1 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new PF4002B();
                program.Execute(CVPRJEMI_FILE_NAME_P);
               

                Assert.True(program.RETURN_CODE != 00);
            }
        }

    }
}