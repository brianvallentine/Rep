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
using static Code.VG5001B;

namespace FileTests.Test
{
    [Collection("VG5001B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG5001B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG5001B_RELATORIO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "R_NUM_APOLICE" , ""},
                { "R_NRPARCEL" , ""},
                { "R_CODSUBES" , ""},
                { "R_OPERACAO" , ""},
                { "R_CODUSU" , ""},
                { "R_CORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG5001B_RELATORIO", q1);

            #endregion

            #region VG5001B_SEGURAVG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SNUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VG5001B_SEGURAVG", q2);

            #endregion

            #region M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "R_CODUSU" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "R_NUM_APOLICE" , ""},
                { "R_NRPARCEL" , ""},
                { "SNUM_CERTIFICADO" , ""},
                { "R_CODSUBES" , ""},
                { "R_OPERACAO" , ""},
                { "R_CORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1", q3);

            #endregion

            #region M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q4);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG5001B_Tests_Fact_ReturnCode_0()
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

                AppSettings.TestSet.DynamicData.Remove("VG5001B_SEGURAVG");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SNUM_CERTIFICADO" , "000000000000123"}
                });
                AppSettings.TestSet.DynamicData.Add("VG5001B_SEGURAVG", q2);

                #endregion
                var program = new VG5001B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 0);

                //M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0?.Count > 1);
                Assert.True(envList0[1].TryGetValue("SNUM_CERTIFICADO", out string valor00) && valor00 == "000000000000123");

                //M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("UpdateCheck", out var valor01) && valor01 == "UpdateCheck");
            }
        }
        [Fact]
        public static void VG5001B_Tests_Fact_SemMov_ReturnCode_0()
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

                #region VG5001B_RELATORIO
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VG5001B_RELATORIO");
                AppSettings.TestSet.DynamicData.Add("VG5001B_RELATORIO", q1);
                #endregion
                #endregion
                var program = new VG5001B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void VG5001B_Tests_Fact_ReturnCode_9()
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

                #region VG5001B_RELATORIO
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "R_NUM_APOLICE" , ""},
                { "R_NRPARCEL" , ""},
                { "R_CODSUBES" , ""},
                { "R_OPERACAO" , ""},
                { "R_CODUSU" , ""},
                { "R_CORRECAO" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VG5001B_RELATORIO");
                AppSettings.TestSet.DynamicData.Add("VG5001B_RELATORIO", q1);
                #endregion
                #endregion
                var program = new VG5001B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 9);
            }
        }

    }
}