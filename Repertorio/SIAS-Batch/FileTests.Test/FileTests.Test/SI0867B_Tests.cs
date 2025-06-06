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
using Code;
using static Code.SI0867B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0867B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0867B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_UPDATE_1_Update1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

            #endregion

            #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0867B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0867B_RELATORIOS", q2);

            #endregion

            #region SI0867B_RAMO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_TIPO_SEGURADO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0867B_RAMO", q3);

            #endregion

            #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region SI0867B_C01_PRODUTO

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_TIPO_SEGURADO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0867B_C01_PRODUTO", q5);

            #endregion

            #region SI0867B_APOLICE

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_TIPO_SEGURADO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0867B_APOLICE", q6);

            #endregion

            #region SI0867B_RAMOVG

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_TIPO_SEGURADO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0867B_RAMOVG", q7);

            #endregion

            #region R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0867B_OUTPUT_202504040000")]
        public static void SI0867B_Tests_Theory(string ARQ_SAIDA_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region Execute_DB_UPDATE_1_Update1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

                #endregion

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0867B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "RELATORI_NUM_APOLICE" , ""},
                    { "RELATORI_PERI_INICIAL" , ""},
                    { "RELATORI_PERI_FINAL" , ""},
                    { "RELATORI_RAMO_EMISSOR" , "81"},
                    { "RELATORI_COD_OPERACAO" , "1"},
                    { "RELATORI_COD_SUBGRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0867B_RELATORIOS", q2);

                #endregion

                #region SI0867B_RAMO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_RAMO");
                AppSettings.TestSet.DynamicData.Add("SI0867B_RAMO", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0867B_C01_PRODUTO

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_C01_PRODUTO");
                AppSettings.TestSet.DynamicData.Add("SI0867B_C01_PRODUTO", q5);

                #endregion

                #region SI0867B_APOLICE

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_APOLICE");
                AppSettings.TestSet.DynamicData.Add("SI0867B_APOLICE", q6);

                #endregion

                #region SI0867B_RAMOVG

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_RAMOVG");
                AppSettings.TestSet.DynamicData.Add("SI0867B_RAMOVG", q7);

                #endregion

                #region R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion
                #endregion

                var program = new SI0867B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQ_SAIDA.FilePath));
                Assert.True(new FileInfo(program.ARQ_SAIDA.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && !x.Key.Contains("_00_") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && !x.Key.Contains("_00_")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                var updates = AppSettings.TestSet.DynamicData.Where(
                    x => x.Key.Contains("UPDATE") &&
                    x.Value.DynamicList.Count > 1 &&
                    x.Value.DynamicList.Where(
                        y => y.ContainsKey("UpdateCheck")).ToList().Count > 0).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(updates.Count > (allUpdates.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0867B_OUTPUT_202504040001")]
        public static void SI0867B_Tests_Theory_ReturnCode99(string ARQ_SAIDA_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region Execute_DB_UPDATE_1_Update1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>
                {
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("Execute_DB_UPDATE_1_Update1", q0);

                #endregion

                #region R010_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0867B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "RELATORI_NUM_APOLICE" , ""},
                    { "RELATORI_PERI_INICIAL" , ""},
                    { "RELATORI_PERI_FINAL" , ""},
                    { "RELATORI_RAMO_EMISSOR" , "81"},
                    { "RELATORI_COD_OPERACAO" , "1"},
                    { "RELATORI_COD_SUBGRUPO" , ""},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("SI0867B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0867B_RELATORIOS", q2);

                #endregion

                #region SI0867B_RAMO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_RAMO");
                AppSettings.TestSet.DynamicData.Add("SI0867B_RAMO", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0867B_C01_PRODUTO

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_C01_PRODUTO");
                AppSettings.TestSet.DynamicData.Add("SI0867B_C01_PRODUTO", q5);

                #endregion

                #region SI0867B_APOLICE

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_APOLICE");
                AppSettings.TestSet.DynamicData.Add("SI0867B_APOLICE", q6);

                #endregion

                #region SI0867B_RAMOVG

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_SUBGRUPO" , ""},
                    { "SINISMES_NUM_CERTIFICADO" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_TIPO_SEGURADO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISCAU_DESCR_CAUSA" , ""},
                    { "SINISHIS_COD_OPERACAO" , "101"},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0867B_RAMOVG");
                AppSettings.TestSet.DynamicData.Add("SI0867B_RAMOVG", q7);

                #endregion

                #region R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1", q9);

                #endregion

                #region R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "FONTES_NOME_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion
                #endregion

                var program = new SI0867B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}