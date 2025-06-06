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
using static Code.PR0100B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PR0100B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PR0100B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0015_00_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELATO_IDSISTEM" , ""},
                { "V1RELATO_CODRELAT" , ""},
                { "V1RELATO_SITUACAO" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1", q1);

            #endregion

            #region PR0100B_V1CODOPER

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TCODOPER_OPERACAO" , ""},
                { "TCODOPER_DESOPR" , ""},
                { "TCODOPER_TIPROC" , ""},
                { "TCODOPER_ARENVOLV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PR0100B_V1CODOPER", q2);

            #endregion

            #region R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PR0100B_o1")]
        public static void PR0100B_Tests_Theory(string RPR0100B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RPR0100B_FILE_NAME_P = $"{RPR0100B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0015_00_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "SEGUROS" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1RELATO_IDSISTEM" , "PR" },
                    { "V1RELATO_CODRELAT" , "PR0100B1" },
                    { "V1RELATO_SITUACAO" , "0" },
                    { "V1SIST_DTCURRENT" , "2025-05-05" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1", q1);

                #endregion

                #region PR0100B_V1CODOPER

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "TCODOPER_OPERACAO" , "1546" },
                    { "TCODOPER_DESOPR" , "DEVOLUÇÃO PROC. DE SINISTRO P/AGENCIA   " },
                    { "TCODOPER_TIPROC" , "1" },
                    { "TCODOPER_ARENVOLV" , "1" },
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "TCODOPER_OPERACAO" , "1547" },
                    { "TCODOPER_DESOPR" , "DEVOLUÇÃO PROC. DE SINISTRO P/AGENCIA   " },
                    { "TCODOPER_TIPROC" , "2" },
                    { "TCODOPER_ARENVOLV" , "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("PR0100B_V1CODOPER");
                AppSettings.TestSet.DynamicData.Add("PR0100B_V1CODOPER", q2);

                #endregion

                #region R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1", q3);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new PR0100B();
                program.Execute(RPR0100B_FILE_NAME_P);

                //Assert.True(File.Exists(program.RPR0100B.FilePath));
                //Assert.True(new FileInfo(program.RPR0100B.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);
                
                var deletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE") && x.Value.DynamicList.Count == 0).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();
                Assert.True(deletes.Count >= allDeletes.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}