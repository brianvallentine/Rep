using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.AC0217B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("AC0217B_Tests")]
    public class AC0217B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region AC0217B_COSSEGURO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_NUM_SINISTRO" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "COSHISSI_COD_CONGENERE" , ""},
                { "COSHISSI_OCORR_HISTORICO" , ""},
                { "COSHISSI_COD_OPERACAO" , ""},
                { "COSHISSI_VAL_OPERACAO" , ""},
                { "COSHISSI_TIPO_SEGURO" , ""},
                { "COSHISSI_DATA_MOVIMENTO" , ""},
                { "GESISFUO_NUM_FATOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0217B_COSSEGURO", q1);

            #endregion

            #region R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1", q4);

            #endregion

            #region R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_COSSEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1", q6);

            #endregion

            #region R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_COSSEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VALOR_AJUSTADO" , ""},
                { "CONGENERE_ANT" , ""},
                { "SINISTRO_ANT" , ""},
                { "OCOR_HIS_ANT" , ""},
                { "COD_OPER_ANT" , ""},
                { "DT_MOVTO_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("AC0217B_Saida")]
        public static void AC0217B_Tests_Theory(string ACOCORR_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0217B_COSSEGURO

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_NUM_SINISTRO" , "123456789" },
                { "GESISFUO_COD_FUNCAO" , "12" },
                { "COSHISSI_COD_CONGENERE" , "345" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente ocorrido durante o transporte." },
                { "COSHISSI_COD_OPERACAO" , "8280" },
                { "COSHISSI_VAL_OPERACAO" , "15000.00" },
                { "COSHISSI_TIPO_SEGURO" , "V" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-01" },
                { "GESISFUO_NUM_FATOR" , "3" },
            });

                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_NUM_SINISTRO" , "122345678" },
                { "GESISFUO_COD_FUNCAO" , "12" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente ocorrido durante o transporte." },
                { "COSHISSI_COD_OPERACAO" , "8283" },
                { "COSHISSI_VAL_OPERACAO" , "15000.00" },
                { "COSHISSI_TIPO_SEGURO" , "V" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-01" },
                { "GESISFUO_NUM_FATOR" , "4" },
            });
                
                AppSettings.TestSet.DynamicData.Remove("AC0217B_COSSEGURO");
AppSettings.TestSet.DynamicData.Add("AC0217B_COSSEGURO", q1);

                #endregion

                #region R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_SINISTRO" , "Não" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , "5000.00" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , "5000.00" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_COSSEG" , "Sim" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , "5000.00" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_COSSEG" , "Sim" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VALOR_AJUSTADO" , "14500.00" },
                { "CONGENERE_ANT" , "CGN123" },
                { "SINISTRO_ANT" , "SN987654321" },
                { "OCOR_HIS_ANT" , "Acidente anterior sem vítimas." },
                { "COD_OPER_ANT" , "1050" },
                { "DT_MOVTO_ANT" , "2023-11-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1", q8);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new AC0217B();
                program.Execute(ACOCORR_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("AC0217BRet_Saida")]
        public static void AC0217B_Tests_Return99(string ACOCORR_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region AC0217B_COSSEGURO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_NUM_SINISTRO" , "123456789" },
                { "GESISFUO_COD_FUNCAO" , "123" },
                { "COSHISSI_COD_CONGENERE" , "345" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente ocorrido durante o transporte." },
                { "COSHISSI_COD_OPERACAO" , "8280" },
                { "COSHISSI_VAL_OPERACAO" , "15000.00" },
                { "COSHISSI_TIPO_SEGURO" , "V" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-01" },
                { "GESISFUO_NUM_FATOR" , "3" },
            });

                q1.AddDynamic(new Dictionary<string, string>{
                { "COSHISSI_NUM_SINISTRO" , "122345678" },
                { "GESISFUO_COD_FUNCAO" , "123" },
                { "COSHISSI_COD_CONGENERE" , "456" },
                { "COSHISSI_OCORR_HISTORICO" , "Incidente ocorrido durante o transporte." },
                { "COSHISSI_COD_OPERACAO" , "8283" },
                { "COSHISSI_VAL_OPERACAO" , "15000.00" },
                { "COSHISSI_TIPO_SEGURO" , "V" },
                { "COSHISSI_DATA_MOVIMENTO" , "2023-12-01" },
                { "GESISFUO_NUM_FATOR" , "4" },
            });

                AppSettings.TestSet.DynamicData.Remove("AC0217B_COSSEGURO");
                AppSettings.TestSet.DynamicData.Add("AC0217B_COSSEGURO", q1);

                #endregion

                #region R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_SINISTRO" , "Não" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , "5000.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , "5000.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_COSSEG" , "Sim" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GE396_VLR_COSSEGURO" , "5000.00" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PENDENTE_COSSEG" , "Sim" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "VALOR_AJUSTADO" , "14500.00" },
                { "CONGENERE_ANT" , "CGN123" },
                { "SINISTRO_ANT" , "SN987654321" },
                { "OCOR_HIS_ANT" , "Acidente anterior sem vítimas." },
                { "COD_OPER_ANT" , "1050" },
                { "DT_MOVTO_ANT" , "2023-11-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1", q8);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new AC0217B();
                program.Execute(ACOCORR_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}