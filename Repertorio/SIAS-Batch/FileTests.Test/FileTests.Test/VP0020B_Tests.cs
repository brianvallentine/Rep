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
using static Code.VP0020B;

namespace FileTests.Test
{
    [Collection("VP0020B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VP0020B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_1000_PROCESSA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_DV" , ""},
                { "SQLCEF_NOME_UNID" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_TIPO_VINC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_CPF" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_UF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_ANGARIADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_1100_INCLUSAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NOME_UNID" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_1100_INCLUSAO_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_DV" , ""},
                { "SQL_NOME_UNID" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_CPF" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_UF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_UNID_ORIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_INSERT_1_Insert1", q2);

            #endregion

            #region M_1100_INCLUSAO_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_AGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_SELECT_2_Query1", q3);

            #endregion

            #region M_1200_ALTERACAO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_NOME_UNID" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_ALTERACAO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1", q6);

            #endregion

            #region M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SQLCEF_NOME_UNID" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_SUREG" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_CPF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_DV" , ""},
                { "SQL_UF" , ""},
                { "SQL_MATRICULA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1", q7);

            #endregion

            #region M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void VP0020B_Tests_Theory_ReturnCode99(string CADCEF_FILE_NAME_P)
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
                #region M_1000_PROCESSA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_DV" , ""},
                { "SQLCEF_NOME_UNID" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_TIPO_VINC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_CPF" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_UF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_ANGARIADOR" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_1100_INCLUSAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NOME_UNID" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1100_INCLUSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_1100_INCLUSAO_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_DV" , ""},
                { "SQL_NOME_UNID" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_CPF" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_UF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_UNID_ORIG" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1100_INCLUSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_INSERT_1_Insert1", q2);

                #endregion

                #region M_1100_INCLUSAO_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_AGENCIA" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1100_INCLUSAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_SELECT_2_Query1", q3);

                #endregion

                #region M_1200_ALTERACAO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_NOME_UNID" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1200_ALTERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1200_ALTERACAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_CPF" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1", q6);

                #endregion

                #region M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SQLCEF_NOME_UNID" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_SUREG" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_CPF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_DV" , ""},
                { "SQL_UF" , ""},
                { "SQL_MATRICULA" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1", q7);

                #endregion

                #region M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1", q8);

                #endregion
                #endregion
                var program = new VP0020B();
                program.Execute(CADCEF_FILE_NAME_P);


                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                var updates = AppSettings.TestSet.DynamicData.Where(
                 x => x.Key.Contains("UPDATE") &&
                 x.Value.DynamicList.Count > 1 &&
                 x.Value.DynamicList.Where(
                     y => y.ContainsKey("UpdateCheck")).ToList().Count > 0).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(updates.Count > (allUpdates.Count / 2));

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count == 0).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count == 0).ToList();


                Assert.True(program.RETURN_CODE == 0);

            }
        }

        [Theory]
        [InlineData("123456789")]
        public static void VP0020B_Tests_Theory_ReturnCode00(string CADCEF_FILE_NAME_P)
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
                #region M_1000_PROCESSA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_DV" , ""},
                { "SQLCEF_NOME_UNID" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_TIPO_VINC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_CPF" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_UF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_ANGARIADOR" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_1100_INCLUSAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NOME_UNID" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1100_INCLUSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region M_1100_INCLUSAO_DB_INSERT_1_Insert1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_DV" , ""},
                { "SQL_NOME_UNID" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_CPF" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_UF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_UNID_ORIG" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1100_INCLUSAO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_INSERT_1_Insert1", q2);

                #endregion

                #region M_1100_INCLUSAO_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_AGENCIA" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1100_INCLUSAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1100_INCLUSAO_DB_SELECT_2_Query1", q3);

                #endregion

                #region M_1200_ALTERACAO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_NOME_UNID" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1200_ALTERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1200_ALTERACAO_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SQL_SUREG" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1210_ALTERA_AGENCIA_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SQL_AGENCIA" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_CPF" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1", q6);

                #endregion

                #region M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SQLCEF_NOME_UNID" , ""},
                { "SQL_NOME_FUNC" , ""},
                { "SQL_DATA_NASC" , ""},
                { "SQL_ENDERECO" , ""},
                { "SQL_OPERACAO" , ""},
                { "SQL_DV_CONTA" , ""},
                { "SQL_UNIDADE" , ""},
                { "SQL_AGENCIA" , ""},
                { "SQL_CIDADE" , ""},
                { "SQL_SUREG" , ""},
                { "SQL_CONTA" , ""},
                { "SQL_CPF" , ""},
                { "SQL_CEP" , ""},
                { "SQL_DV" , ""},
                { "SQL_UF" , ""},
                { "SQL_MATRICULA" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1", q7);

                #endregion

                #region M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>
                {
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1", q8);

                #endregion
                #endregion
                var program = new VP0020B();
                program.Execute(CADCEF_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 999);

            }
        }
    }
}