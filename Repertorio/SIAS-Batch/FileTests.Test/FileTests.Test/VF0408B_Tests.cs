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
using static Code.VF0408B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VF0408B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VF0408B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTATRASO" , ""},
                { "V1SIST_DTHOJE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q2);

            #endregion

            #region VF0408B_CPROPVF

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PRVA_NRCERTIF" , ""},
                { "V0PRDR_CODPDT" , ""},
                { "V0PRDR_NOMPDT" , ""},
                { "V0PRDR_ENDERECO" , ""},
                { "V0PRDR_BAIRRO" , ""},
                { "V0PRDR_CIDADE" , ""},
                { "V0PRDR_ESTADO" , ""},
                { "V0PRDR_CEP" , ""},
                { "V0PRVA_DTQITBCO" , ""},
                { "V0CLIE_NOME_RAZAO" , ""},
                { "V0ENDE_ENDERECO" , ""},
                { "V0ENDE_BAIRRO" , ""},
                { "V0ENDE_CIDADE" , ""},
                { "V0ENDE_SIGLA_UF" , ""},
                { "V0ENDE_CEP" , ""},
                { "V0HSEG_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VF0408B_CPROPVF", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VF0408B_o1", "VF0408B_o2")]
        public static void VF0408B_Tests_Theory(string RVF0408B_FILE_NAME_P, string SVF0408B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                RVF0408B_FILE_NAME_P = $"{RVF0408B_FILE_NAME_P}_{timestamp}.txt";
                SVF0408B_FILE_NAME_P = $"{SVF0408B_FILE_NAME_P}_{timestamp}.txt";

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_SITUACAO" , "4" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "DATA_MOVIMENTO" },
                { "V1SIST_DTATRASO" , "" },
                { "V1SIST_DTHOJE" , "" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Remove("R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q2);

                #endregion

                #region VF0408B_CPROPVF

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PRVA_NRCERTIF" , "NRCERTIF" },
                { "V0PRDR_CODPDT" , "CODPDT" },
                { "V0PRDR_NOMPDT" , "NOMPDT" },
                { "V0PRDR_ENDERECO" , "ENDERECO" },
                { "V0PRDR_BAIRRO" , "BAIRRO" },
                { "V0PRDR_CIDADE" , "CIDADE" },
                { "V0PRDR_ESTADO" , "ESTADO" },
                { "V0PRDR_CEP" , "CEP" },
                { "V0PRVA_DTQITBCO" , "DTQITBCO" },
                { "V0CLIE_NOME_RAZAO" , "NOME_RAZAO" },
                { "V0ENDE_ENDERECO" , "ENDERECO" },
                { "V0ENDE_BAIRRO" , "BAIRRO" },
                { "V0ENDE_CIDADE" , "CIDADE" },
                { "V0ENDE_SIGLA_UF" , "SIGLA_UF" },
                { "V0ENDE_CEP" , "CEP" },
                { "V0HSEG_DTMOVTO" , "DATA_MOVIMENTO" },
            });
            AppSettings.TestSet.DynamicData.Remove("VF0408B_CPROPVF");
AppSettings.TestSet.DynamicData.Add("VF0408B_CPROPVF", q3);

                #endregion

                #endregion

      #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VF0408B();
                program.Execute(RVF0408B_FILE_NAME_P, SVF0408B_FILE_NAME_P);

                Assert.True(File.Exists(program.RVF0408B.FilePath));
                Assert.True(new FileInfo(program.RVF0408B.FilePath).Length > 0);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VF0408B_o1", "VF0408B_o2")]
        public static void VF0408B_Tests_ReturnCode99_Theory(string RVF0408B_FILE_NAME_P, string SVF0408B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                RVF0408B_FILE_NAME_P = $"{RVF0408B_FILE_NAME_P}_{timestamp}.txt";
                SVF0408B_FILE_NAME_P = $"{SVF0408B_FILE_NAME_P}_{timestamp}.txt";

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V0RELA_SITUACAO" , "4" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "DATA_MOVIMENTO" },
                    { "V1SIST_DTATRASO" , "" },
                    { "V1SIST_DTHOJE" , "" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>
                {
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q2);

                #endregion

                #region VF0408B_CPROPVF

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0PRVA_NRCERTIF" , "NRCERTIF" },
                    { "V0PRDR_CODPDT" , "CODPDT" },
                    { "V0PRDR_NOMPDT" , "NOMPDT" },
                    { "V0PRDR_ENDERECO" , "ENDERECO" },
                    { "V0PRDR_BAIRRO" , "BAIRRO" },
                    { "V0PRDR_CIDADE" , "CIDADE" },
                    { "V0PRDR_ESTADO" , "ESTADO" },
                    { "V0PRDR_CEP" , "CEP" },
                    { "V0PRVA_DTQITBCO" , "DTQITBCO" },
                    { "V0CLIE_NOME_RAZAO" , "NOME_RAZAO" },
                    { "V0ENDE_ENDERECO" , "ENDERECO" },
                    { "V0ENDE_BAIRRO" , "BAIRRO" },
                    { "V0ENDE_CIDADE" , "CIDADE" },
                    { "V0ENDE_SIGLA_UF" , "SIGLA_UF" },
                    { "V0ENDE_CEP" , "CEP" },
                    { "V0HSEG_DTMOVTO" , "DATA_MOVIMENTO" },
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VF0408B_CPROPVF");
                AppSettings.TestSet.DynamicData.Add("VF0408B_CPROPVF", q3);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VF0408B();
                program.Execute(RVF0408B_FILE_NAME_P, SVF0408B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}