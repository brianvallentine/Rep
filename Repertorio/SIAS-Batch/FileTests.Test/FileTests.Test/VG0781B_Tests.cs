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
using static Code.VG0781B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG0781B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0781B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "EMPRESA1"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "EMPRESA1"}
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "EMPRESA1"}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region VG0781B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_DATA1" , ""},
                { "V1RELATORIOS_DATA2" , ""},
                { "V1RELATORIOS_APOLICE" , ""},
                { "V1RELATORIOS_CODSUBES1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0781B_RELATORIOS", q2);

            #endregion

            #region M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , "1"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , "1"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1", q5);

            #endregion

            #region VG0781B_ENDOSSO

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0APOLICE_ENDOSSO" , ""},
                { "V0ENDOPARC_DTINIVIG" , ""},
                { "V0ENDOPARC_CODSUBES" , ""},
                { "V0ENDOPARC_NRENDOS" , ""},
                { "V0ENDOPARC_DTEMIS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0781B_ENDOSSO", q6);

            #endregion

            #region M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0ENDOPARC_VLPRMLIQ" , ""},
                { "V0ENDOPARC_DTQITBCO" , ""},
                { "V0ENDOPARC_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0ENDOPARC_PCT_COBERTURA" , "25"}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VG0781M1_FILE_NAME_P")]
        public static void VG0781B_Tests_TheoryErro99(string VG0781M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VG0781M1_FILE_NAME_P = $"{VG0781M1_FILE_NAME_P}_{timestamp}.txt";
           
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
                var program = new VG0781B();
                program.Execute(VG0781M1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(program.FILLER_0.LC01.LC01_NOME_EMPRESA.Value.Contains("EMPRESA"));
                Assert.True(program.RETURN_CODE.Value == 99);
            }
        }

        [Theory]
        [InlineData("VG0781M1_FILE_NAME_P")]
        public static void VG0781B_Tests_TheorySucesso(string VG0781M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VG0781M1_FILE_NAME_P = $"{VG0781M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDOPARC_VLPRMLIQ" , "1000"},
                    { "V0ENDOPARC_DTQITBCO" , "2020-10-10"},
                    { "V0ENDOPARC_DTMOVTO" , "2020-10-10"},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDOPARC_VLPRMLIQ" , "1000"},
                    { "V0ENDOPARC_DTQITBCO" , "2020-10-10"},
                    { "V0ENDOPARC_DTMOVTO" , "2020-10-10"},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0ENDOPARC_VLPRMLIQ" , "1000"},
                    { "V0ENDOPARC_DTQITBCO" , "2020-10-10"},
                    { "V0ENDOPARC_DTMOVTO" , "2020-10-10"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_800_100_BUSCA_HISTORICO_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new VG0781B();
                program.Execute(VG0781M1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(File.Exists(program.VG0781M1.FilePath));
                Assert.True(new FileInfo(program.VG0781M1.FilePath)?.Length > 0);

                //verifica se o insert ou update foi realizado
                var envList = AppSettings.TestSet.DynamicData["M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("UpdateCheck", out var valOr) && valOr == "UpdateCheck");

                Assert.True(program.FILLER_0.LC01.LC01_NOME_EMPRESA.Value.Contains("EMPRESA"));

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }
    }
}