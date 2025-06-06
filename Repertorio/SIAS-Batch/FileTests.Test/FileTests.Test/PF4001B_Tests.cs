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
using static Code.PF4001B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("PF4001B_Tests")]
    public class PF4001B_Tests
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

            #region R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1

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
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.GPF.CVPRJPRP.D241126")]
        public static void PF4001B_Tests_Theory(string CVPRJPRP_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "73128480044073" },
                { "PROPOFID_SIT_PROPOSTA" , "3" },
                { "PROPOFID_CANAL_PROPOSTA" , "Online" },
                { "PROPOFID_ORIGEM_PROPOSTA" , "Internet" },
                { "PROPOFID_SITUACAO_ENVIO" , "Enviado" },
                { "PROPOFID_COD_PRODUTO_SIVPF" , "06" },
                { "PROPOFID_DATA_PROPOSTA" , "2023-12-01" },
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "20231201-001" },
                { "PROPOFID_VAL_PAGO" , "1000.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new PF4001B();
                program.Execute(CVPRJPRP_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("PRD.GPF.CVPRJPRP.D241127")]
        public static void PF4001B_Tests_Theory_Erro99(string CVPRJPRP_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region PARAMETERS

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion

                var program = new PF4001B();
                program.Execute(CVPRJPRP_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}
