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
using static Code.VP0107B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VP0107B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VP0107B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VP0107B_TRELAT

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "DATA_SOLICITACAO" , ""},
                { "NRCOPIAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0107B_TRELAT", q0);

            #endregion

            #region VP0107B_TFUNCIOCEF

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FSUREG" , ""},
                { "FCOD_UNIDADE" , ""},
                { "FNOME_UNIDADE" , ""},
                { "FMATRICULA" , ""},
                { "FNOME_FUNC" , ""},
                { "SNUM_CERTIFICADO" , ""},
                { "SNUM_ITEM" , ""},
                { "SOCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0107B_TFUNCIOCEF", q1);

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

            #region VP0107B_TFUNCIOSUR

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FSUREG" , ""},
                { "FCOD_UNIDADE" , ""},
                { "FNOME_UNIDADE" , ""},
                { "FMATRICULA" , ""},
                { "FNOME_FUNC" , ""},
                { "SNUM_CERTIFICADO" , ""},
                { "SNUM_ITEM" , ""},
                { "SOCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0107B_TFUNCIOSUR", q4);

            #endregion

            #region M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUREG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_150_000_SELECT_V0SUREG_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_IX" , ""},
                { "CPRM_TARIFARIO_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_1000_000_COTACAO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "XDATA_MOVIMENTO" , ""},
                { "ECOD_MOEDA_IMP" , ""},
                { "ECOD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_000_COTACAO_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_1200_ACESSA_V1MOEDA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_IMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_ACESSA_V1MOEDA_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_1200_ACESSA_V1MOEDA_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DVLCRUZAD_PRM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_ACESSA_V1MOEDA_DB_SELECT_2_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VP0107B1.TXT")]
        public static void VP0107B_Tests_Theory(string RELPREFV_FILE_NAME_P)
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
                #region M_1000_000_COTACAO_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("M_1000_000_COTACAO_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "XDATA_MOVIMENTO" , "2000-10-10"},
                { "ECOD_MOEDA_IMP" , "2"},
                { "ECOD_MOEDA_PRM" , "3"},
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_000_COTACAO_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new VP0107B();
                program.Execute(RELPREFV_FILE_NAME_P);

                Assert.True(File.Exists(program.RELPREFV.FilePath));
                Assert.True(new FileInfo(program.RELPREFV.FilePath)?.Length > 0);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["M_015_000_PROCESSA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("NRCOPIAS", out var valor) && valor == "0000");

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("VP0107B2.TXT")]
        public static void VP0107B_Tests_TheoryErro(string RELPREFV_FILE_NAME_P)
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
                #region M_1000_000_COTACAO_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_000_COTACAO_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("M_1000_000_COTACAO_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new VP0107B();
                program.Execute(RELPREFV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}