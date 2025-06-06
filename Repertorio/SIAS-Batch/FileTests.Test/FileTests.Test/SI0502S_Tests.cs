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
using static Code.SI0502S;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0502S_Tests")]
    public class SI0502S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_IDE_SISTEMA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_VAL_PENDENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_COD_COBERTURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1", q6);

            #endregion

            #region R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        } 
        
        public static void Load_Parameters2()
        {
            #region VARIAVEIS_TESTE

            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_IDE_SISTEMA" , "10"},
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-04-01"},
                });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , "22"},
                    { "SINISMES_COD_PRODUTO" , "10"},
                    { "SINISMES_OCORR_HISTORICO" , "10"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_OCORR_HISTORICO" , "5"},
                    { "SINISHIS_NUM_APOL_SINISTRO" , "123456789"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
            AppSettings.TestSet.DynamicData.Add("R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , "10"},
                    { "SINISHIS_TIPO_REGISTRO" , "10"},
                    { "SINISHIS_DATA_LIM_CORRECAO" , "2025-04-01"},
                    { "SINISHIS_TIPO_FAVORECIDO" , "10"},
                    { "SINISHIS_DATA_NEGOCIADA" , "2025-04-01"},
                    { "SINISHIS_FONTE_PAGAMENTO" , "10"},
                    { "SINISHIS_COD_PREST_SERVICO" , "10"},
                    { "SINISHIS_COD_SERVICO" , "10"},
                    { "SINISHIS_ORDEM_PAGAMENTO" , "10"},
                    { "SINISHIS_NUM_RECIBO" , "10"},
                    { "SINISHIS_NUM_MOV_SINISTRO" , "10"},
                    { "SINISHIS_COD_USUARIO" , "10"},
                    { "SINISHIS_SIT_CONTABIL" , "10"},
                    { "SINISHIS_NUM_APOLICE" , "10"},
                    { "SINISHIS_COD_PRODUTO" , "10"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VAL_PENDENTE" , "0"}
                });

            q4.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VAL_PENDENTE" , "0"}
                });

            q4.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VAL_PENDENTE" , "0"}
                });

            AppSettings.TestSet.DynamicData.Remove("R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , "10"},
                    { "SINISHIS_TIPO_REGISTRO" , "10"},
                    { "SINISHIS_NUM_APOL_SINISTRO" , "123456789"},
                    { "SINISHIS_OCORR_HISTORICO" , "10"},
                    { "SINISHIS_COD_OPERACAO" , "10"},
                    { "SINISHIS_DATA_MOVIMENTO" , "10"},
                    { "SINISHIS_NOME_FAVORECIDO" , "10"},
                    { "SINISHIS_VAL_OPERACAO" , "10"},
                    { "SINISHIS_DATA_LIM_CORRECAO" , "2025-04-01"},
                    { "SINISHIS_TIPO_FAVORECIDO" , "10"},
                    { "SINISHIS_DATA_NEGOCIADA" , "2025-04-01"},
                    { "SINISHIS_FONTE_PAGAMENTO" , "10"},
                    { "SINISHIS_COD_PREST_SERVICO" , "10"},
                    { "SINISHIS_COD_SERVICO" , "10"},
                    { "SINISHIS_ORDEM_PAGAMENTO" , "10"},
                    { "SINISHIS_NUM_RECIBO" , "10"},
                    { "SINISHIS_NUM_MOV_SINISTRO" , "10"},
                    { "SINISHIS_COD_USUARIO" , "10"},
                    { "SINISHIS_SIT_CONTABIL" , "10"},
                    { "SINISHIS_SIT_REGISTRO" , "10"},
                    { "SINISHIS_NUM_APOLICE" , "10"},
                    { "SINISHIS_COD_PRODUTO" , "10"},
                    { "SINISHIS_NOM_PROGRAMA" , "10"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
            AppSettings.TestSet.DynamicData.Add("R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                    { "SINIHAB1_COD_COBERTURA" , "10"}
                });
            AppSettings.TestSet.DynamicData.Remove("R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1", q6);

            #endregion

            #region R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                    { "SINCREIN_COD_OPERACAO" , "10"}
                });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0502S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters2();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                var program = new SI0502S();

                var param = new SI0502S_LINK_PARAMETRO();
                param.LINK_NUM_APOL_SINISTRO.Value = 123456789;

                program.Execute(param);


                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void SI0502S_Tests_Fact_Return99()
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_IDE_SISTEMA" , "10"},
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-04-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_RAMO" , "22"},
                    { "SINISMES_COD_PRODUTO" , "10"},
                    { "SINISMES_OCORR_HISTORICO" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_OCORR_HISTORICO" , "5"},
                    { "SINISHIS_NUM_APOL_SINISTRO" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q2);

                #endregion

                #region R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , "10"},
                    { "SINISHIS_TIPO_REGISTRO" , "10"},
                    { "SINISHIS_DATA_LIM_CORRECAO" , "2025-04-01"},
                    { "SINISHIS_TIPO_FAVORECIDO" , "10"},
                    { "SINISHIS_DATA_NEGOCIADA" , "2025-04-01"},
                    { "SINISHIS_FONTE_PAGAMENTO" , "10"},
                    { "SINISHIS_COD_PREST_SERVICO" , "10"},
                    { "SINISHIS_COD_SERVICO" , "10"},
                    { "SINISHIS_ORDEM_PAGAMENTO" , "10"},
                    { "SINISHIS_NUM_RECIBO" , "10"},
                    { "SINISHIS_NUM_MOV_SINISTRO" , "10"},
                    { "SINISHIS_COD_USUARIO" , "10"},
                    { "SINISHIS_SIT_CONTABIL" , "10"},
                    { "SINISHIS_NUM_APOLICE" , "10"},
                    { "SINISHIS_COD_PRODUTO" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "HOST_VAL_PENDENTE" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    
                });
                AppSettings.TestSet.DynamicData.Remove("R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINIHAB1_COD_COBERTURA" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1", q6);

                #endregion

                #region R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINCREIN_COD_OPERACAO" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion
                var program = new SI0502S();

                var param = new SI0502S_LINK_PARAMETRO();

                param.LINK_NUM_APOL_SINISTRO.Value = 10;
                param.LINK_VAL_RESERVA_DESEJADA.Value = 8;


                program.Execute(param);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}