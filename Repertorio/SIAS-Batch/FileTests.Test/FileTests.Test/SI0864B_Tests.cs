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
using static Code.SI0864B;
using System.IO;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0864B_Tests")]
    public class SI0864B_Tests
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

            #region SI0864B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0864B_RELATORIOS", q2);

            #endregion

            #region SI0864B_MESTRE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "SINILT01_NUM_APOLICE" , ""},
                { "SINILT01_COD_LOT_FENAL" , ""},
                { "SINILT01_DTINIVIG" , ""},
                { "SINILT01_COD_COBERTURA" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0864B_MESTRE", q3);

            #endregion

            #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region SI0864B_BONUS

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "LOTBONUS_TIPO_BONUS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI0864B_BONUS", q5);

            #endregion

            #region R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_NOME_FANTASIA" , ""},
                { "LOTERI01_NUM_ENCEF" , ""},
                { "LOTERI01_NUM_PVCEF" , ""},
                { "LOTERI01_ENDERECO" , ""},
                { "LOTERI01_COMPL_ENDERECO" , ""},
                { "LOTERI01_BAIRRO" , ""},
                { "LOTERI01_CEP" , ""},
                { "LOTERI01_CIDADE" , ""},
                { "LOTERI01_SIGLA_UF" , ""},
                { "LOTERI01_DDD" , ""},
                { "LOTERI01_NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1", q6);

            #endregion

            #region R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "LTTIPBON_DESCR_BONUS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "LOTISG01_IMP_SEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0864BSaida_t1")]
        public static void SI0864B_Tests_Theory(string ARQ_SAIDA_FILE_NAME_P)
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
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0864B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , "1"},
                    { "RELATORI_DATA_SOLICITACAO" , "2025-04-04"},
                    { "RELATORI_PERI_FINAL" , "1"},
                    { "RELATORI_NUM_APOLICE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0864B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0864B_RELATORIOS", q2);

                #endregion

                #region SI0864B_MESTRE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_NUM_APOLICE" , "1"},
                    { "SINISMES_COD_CAUSA" , "1"},
                    { "SINISMES_RAMO" , "1"},
                    { "SINISMES_SIT_REGISTRO" , "1"},
                    { "SINISMES_DATA_OCORRENCIA" , "1"},
                    { "SINISCAU_DESCR_CAUSA" , "1"},
                    { "SINILT01_COD_LOT_CEF" , "1"},
                    { "SINILT01_NUM_APOLICE" , "1"},
                    { "SINILT01_COD_LOT_FENAL" , "1"},
                    { "SINILT01_DTINIVIG" , "2025-04-04"},
                    { "SINILT01_COD_COBERTURA" , "1"},
                    { "CLIENTES_NOME_RAZAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0864B_MESTRE");
                AppSettings.TestSet.DynamicData.Add("SI0864B_MESTRE", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0864B_BONUS

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "LOTBONUS_TIPO_BONUS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("SI0864B_BONUS");
                AppSettings.TestSet.DynamicData.Add("SI0864B_BONUS", q5);

                #endregion

                #region R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "LOTERI01_NOME_FANTASIA" , "1"},
                    { "LOTERI01_NUM_ENCEF" , "1"},
                    { "LOTERI01_NUM_PVCEF" , "1"},
                    { "LOTERI01_ENDERECO" , "1"},
                    { "LOTERI01_COMPL_ENDERECO" , "1"},
                    { "LOTERI01_BAIRRO" , "1"},
                    { "LOTERI01_CEP" , "1150000"},
                    { "LOTERI01_CIDADE" , "1"},
                    { "LOTERI01_SIGLA_UF" , "1"},
                    { "LOTERI01_DDD" , "1"},
                    { "LOTERI01_NUM_FONE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1", q6);

                #endregion

                #region R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "LTTIPBON_DESCR_BONUS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1", q7);

                #endregion

                #region R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "LOTISG01_IMP_SEG" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-04"}
                });
                AppSettings.TestSet.DynamicData.Remove("R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-04"}
                });
                AppSettings.TestSet.DynamicData.Remove("R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1", q10);

                #endregion

                #region PARAMETERS_SI1000S
                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var qa0 = new DynamicData();
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                qa0.AddDynamic(new Dictionary<string, string>{
                { "GESISFUN_NOM_FUNCAO" , "LIBERACAO DE COSSEGURO                                      "}
            });
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", qa0);

                #endregion

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var qa1 = new DynamicData();
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                qa1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , "12256511"}
            });
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", qa1);

                #endregion

                #region R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1

                var qa2 = new DynamicData();
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                qa2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2028-01-01"}
            });
                AppSettings.TestSet.DynamicData.Add("R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1", qa2);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var qa3 = new DynamicData();
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                qa3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "500000"}
            });
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", qa3);

                #endregion

                #region R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1

                var qa4 = new DynamicData();
                qa4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                qa4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                qa4.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20336"}
            });
                AppSettings.TestSet.DynamicData.Add("R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1", qa4);

                #endregion

                #region R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1

                var qa5 = new DynamicData();
                qa5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                qa5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                qa5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "20235659"}
            });
                AppSettings.TestSet.DynamicData.Add("R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1", qa5);

                #endregion

                #endregion

                #endregion
                var program = new SI0864B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQ_SAIDA.FilePath));
                Assert.True(new FileInfo(program.ARQ_SAIDA.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.True(inserts.Count >= allInserts.Count / 2);
                Assert.True(updates.Count >= allUpdates.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0864BSaida_t2")]
        public static void SI0864B_Tests_Theory_Return99(string ARQ_SAIDA_FILE_NAME_P)
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
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0864B_RELATORIOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_USUARIO" , "1"},
                    { "RELATORI_DATA_SOLICITACAO" , "2025-04-04"},
                    { "RELATORI_PERI_FINAL" , "1"},
                    { "RELATORI_NUM_APOLICE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0864B_RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0864B_RELATORIOS", q2);

                #endregion

                #region SI0864B_MESTRE

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_NUM_APOLICE" , "1"},
                    { "SINISMES_COD_CAUSA" , "1"},
                    { "SINISMES_RAMO" , "1"},
                    { "SINISMES_SIT_REGISTRO" , "1"},
                    { "SINISMES_DATA_OCORRENCIA" , "1"},
                    { "SINISCAU_DESCR_CAUSA" , "1"},
                    { "SINILT01_COD_LOT_CEF" , "1"},
                    { "SINILT01_NUM_APOLICE" , "1"},
                    { "SINILT01_COD_LOT_FENAL" , "1"},
                    { "SINILT01_DTINIVIG" , "2025-04-04"},
                    { "SINILT01_COD_COBERTURA" , "1"},
                    { "CLIENTES_NOME_RAZAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0864B_MESTRE");
                AppSettings.TestSet.DynamicData.Add("SI0864B_MESTRE", q3);

                #endregion

                #region R021_FETCH_RELATORIO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R021_FETCH_RELATORIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R021_FETCH_RELATORIO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0864B_BONUS

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "LOTBONUS_TIPO_BONUS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("SI0864B_BONUS");
                AppSettings.TestSet.DynamicData.Add("SI0864B_BONUS", q5);

                #endregion

                #region R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "LOTERI01_NOME_FANTASIA" , "1"},
                    { "LOTERI01_NUM_ENCEF" , "1"},
                    { "LOTERI01_NUM_PVCEF" , "1"},
                    { "LOTERI01_ENDERECO" , "1"},
                    { "LOTERI01_COMPL_ENDERECO" , "1"},
                    { "LOTERI01_BAIRRO" , "1"},
                    { "LOTERI01_CEP" , "1150000"},
                    { "LOTERI01_CIDADE" , "1"},
                    { "LOTERI01_SIGLA_UF" , "1"},
                    { "LOTERI01_DDD" , "1"},
                    { "LOTERI01_NUM_FONE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1", q6);

                #endregion

                #region R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "LTTIPBON_DESCR_BONUS" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1", q7);

                #endregion

                #region R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    
                });
                AppSettings.TestSet.DynamicData.Remove("R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    
                });
                AppSettings.TestSet.DynamicData.Remove("R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_DATA_MOVIMENTO" , "2025-04-04"}
                });
                AppSettings.TestSet.DynamicData.Remove("R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1", q10);

                #endregion

                #endregion
                var program = new SI0864B();
                program.Execute(ARQ_SAIDA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}