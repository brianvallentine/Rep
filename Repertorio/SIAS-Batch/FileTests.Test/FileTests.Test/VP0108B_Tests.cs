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
using static Code.VP0108B;

namespace FileTests.Test
{
    [Collection("VP0108B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VP0108B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VP0108B_TRELAT

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "DATA_SOLICITACAO" , ""},
                { "NRCOPIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0108B_TRELAT", q0);

            #endregion

            #region VP0108B_TFUNCIOCEF

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FSUREG" , ""},
                { "FCOD_UNIDADE" , ""},
                { "FNOME_UNIDADE" , ""},
                { "FMATRICULA" , ""},
                { "FNOME_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0108B_TFUNCIOCEF", q1);

            #endregion

            #region M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_012_000_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_015_000_PROCESSA_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "NRCOPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_PROCESSA_DB_UPDATE_1_Update1", q3);

            #endregion

            #region VP0108B_TFUNCIOSUR

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FSUREG" , ""},
                { "FCOD_UNIDADE" , ""},
                { "FNOME_UNIDADE" , ""},
                { "FMATRICULA" , ""},
                { "FNOME_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0108B_TFUNCIOSUR", q4);

            #endregion

            #region M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUREG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VP0108B_Saida1.txt")]
        public static void VP0108B_Tests_Theory_Processing_ReturnCode_0(string RELPREFV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELPREFV_FILE_NAME_P = $"{RELPREFV_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VP0108B_TRELAT

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "DATA_SOLICITACAO" , "2020-01-01"},
                { "NRCOPIAS" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0108B_TRELAT");
                AppSettings.TestSet.DynamicData.Add("VP0108B_TRELAT", q0);

                #endregion
                #region VP0108B_TFUNCIOCEF

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FSUREG" , "99"},
                { "FCOD_UNIDADE" , "5000"},
                { "FNOME_UNIDADE" , "RECUPERACAO DE CREDITOS DE ATACADO      "},
                { "FMATRICULA" , "1295233"},
                { "FNOME_FUNC" , "PEDRO HENRIQUE LACERDA COSTA            "},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0108B_TFUNCIOCEF");
                AppSettings.TestSet.DynamicData.Add("VP0108B_TFUNCIOCEF", q1);

                #endregion
                #region VP0108B_TFUNCIOSUR

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "FSUREG" , "99"},
                { "FCOD_UNIDADE" , "5003"},
                { "FNOME_UNIDADE" , "AUDITORIA INTERNA                       "},
                { "FMATRICULA" , "1516711"},
                { "FNOME_FUNC" , "ADRIANA ESTEVES LIMA DE OLIVEIRA        "},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0108B_TFUNCIOSUR");
                AppSettings.TestSet.DynamicData.Add("VP0108B_TFUNCIOSUR", q4);

                #endregion
                #endregion
                var program = new VP0108B();
                program.Execute(RELPREFV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WS_COUNT == 1);
                //M_015_000_PROCESSA_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["M_015_000_PROCESSA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("NRCOPIAS", out var valor) && valor.Contains("2"));
            }
        }

        [Theory]
        [InlineData("VP0108B_Saida2.txt")]
        public static void VP0108B_Tests_Theory_NoProcessing_ReturnCode_0(string RELPREFV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RELPREFV_FILE_NAME_P = $"{RELPREFV_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VP0108B_TRELAT

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VP0108B_TRELAT");
                AppSettings.TestSet.DynamicData.Add("VP0108B_TRELAT", q0);

                #endregion
                #endregion
                var program = new VP0108B();
                program.Execute(RELPREFV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WS_COUNT == 0);

            }
        }
    }
}