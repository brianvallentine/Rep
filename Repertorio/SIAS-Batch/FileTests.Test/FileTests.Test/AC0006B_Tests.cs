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
using static Code.AC0006B;

namespace FileTests.Test
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("AC0006B_Tests")]
    public class AC0006B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
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

            #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region AC0006B_C01_PARCEHIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0006B_C01_PARCEHIS", q2);

            #endregion

            #region AC0006B_C01_APOLCOSS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_NUM_APOLICE" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0006B_C01_APOLCOSS", q3);

            #endregion

            #region R0800_00_SELECT_GE397_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_GE397_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q7);

            #endregion

            #region AC0006B_COSGCOBER

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , ""},
                { "GE397_NUM_ENDOSSO" , ""},
                { "GE397_COD_RAMO_COBER" , ""},
                { "GE397_COD_COBERTURA" , ""},
                { "GE397_VLR_IMP_SEGUR_VAR" , ""},
                { "GE397_VLR_PREMIO_TARIF_VAR" , ""},
                { "GE398_COD_COSSEGURADORA" , ""},
                { "GE398_PCT_PARTIC_COBER" , ""},
                { "GE398_PCT_COMCOS_COBER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0006B_COSGCOBER", q8);

            #endregion

            #region R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2500_00_INSERT_GE399_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GE399_NUM_APOLICE" , ""},
                { "GE399_NUM_ENDOSSO" , ""},
                { "GE399_COD_RAMO_COBER" , ""},
                { "GE399_COD_COSSEGURADORA" , ""},
                { "GE399_VLR_IMPSEG_CED_VAR" , ""},
                { "GE399_PCT_PROP_RAMO_IS" , ""},
                { "GE399_PCT_PROP_TOTAL_IS" , ""},
                { "GE399_VLR_PRMTAR_CED_VAR" , ""},
                { "GE399_PCT_PROP_RAMO_PR" , ""},
                { "GE399_PCT_PROP_TOTAL_PR" , ""},
                { "GE399_VLR_COMCOS_RAMO" , ""},
                { "GE399_PCT_PROP_COM_RAMO" , ""},
                { "GE399_PCT_PROP_COM_TOTAL" , ""},
                { "GE399_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_GE399_DB_INSERT_1_Insert1", q10);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0006B_Tests_Fact()
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0006B_C01_PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "1"},
                { "PARCEHIS_NUM_ENDOSSO" , "2"},
                { "PARCEHIS_NUM_PARCELA" , "3"},
                { "PARCEHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "PARCEHIS_COD_OPERACAO" , "1"},
                { "PARCEHIS_OCORR_HISTORICO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "1"},
                { "PARCEHIS_NUM_ENDOSSO" , "2"},
                { "PARCEHIS_NUM_PARCELA" , "3"},
                { "PARCEHIS_DATA_MOVIMENTO" , "2020-01-01"},
                { "PARCEHIS_COD_OPERACAO" , "1"},
                { "PARCEHIS_OCORR_HISTORICO" , "1"},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("AC0006B_C01_PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("AC0006B_C01_PARCEHIS", q2);

                #endregion

                #region AC0006B_C01_APOLCOSS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_NUM_APOLICE" , "1"},
                { "APOLCOSS_COD_COSSEGURADORA" , "2"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_NUM_APOLICE" , "1"},
                { "APOLCOSS_COD_COSSEGURADORA" , "2"},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("AC0006B_C01_APOLCOSS");
                AppSettings.TestSet.DynamicData.Add("AC0006B_C01_APOLCOSS", q3);

                #endregion

                #region R0800_00_SELECT_GE397_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_GE397_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_GE397_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , "1"},
                { "ENDOSSOS_NUM_ENDOSSO" , "2"},
                { "ENDOSSOS_RAMO_EMISSOR" , "3"},
                { "ENDOSSOS_COD_PRODUTO" , "4"},
                { "ENDOSSOS_COD_SUBGRUPO" , "5"},
                { "ENDOSSOS_COD_FONTE" , "0"},
                { "ENDOSSOS_DATA_EMISSAO" , "2020-01-01"},
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2020-01-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2020-01-01"},
                { "ENDOSSOS_COD_MOEDA_IMP" , "0"},
                { "ENDOSSOS_COD_MOEDA_PRM" , "0"},
                { "ENDOSSOS_SIT_REGISTRO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TARIFARIO_IX" , "1"},
                { "PARCELAS_VAL_DESCONTO_IX" , "2"},
                { "PARCELAS_ADICIONAL_FRAC_IX" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q7);

                #endregion

                #region AC0006B_COSGCOBER

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , "1"},
                { "GE397_NUM_ENDOSSO" , "2"},
                { "GE397_COD_RAMO_COBER" , "3"},
                { "GE397_COD_COBERTURA" , "4"},
                { "GE397_VLR_IMP_SEGUR_VAR" , "5"},
                { "GE397_VLR_PREMIO_TARIF_VAR" , "6"},
                { "GE398_COD_COSSEGURADORA" , "7"},
                { "GE398_PCT_PARTIC_COBER" , "8"},
                { "GE398_PCT_COMCOS_COBER" , "9"},
                }, new SQLCA(0), new SQLCA(0), new SQLCA(100));
                q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , "1"},
                { "GE397_NUM_ENDOSSO" , "2"},
                { "GE397_COD_RAMO_COBER" , "4"},
                { "GE397_COD_COBERTURA" , "4"},
                { "GE397_VLR_IMP_SEGUR_VAR" , "5"},
                { "GE397_VLR_PREMIO_TARIF_VAR" , "6"},
                { "GE398_COD_COSSEGURADORA" , "7"},
                { "GE398_PCT_PARTIC_COBER" , "8"},
                { "GE398_PCT_COMCOS_COBER" , "9"},
                }, new SQLCA(100));
                q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , "1"},
                { "GE397_NUM_ENDOSSO" , "2"},
                { "GE397_COD_RAMO_COBER" , "5"},
                { "GE397_COD_COBERTURA" , "4"},
                { "GE397_VLR_IMP_SEGUR_VAR" , "5"},
                { "GE397_VLR_PREMIO_TARIF_VAR" , "6"},
                { "GE398_COD_COSSEGURADORA" , "7"},
                { "GE398_PCT_PARTIC_COBER" , "8"},
                { "GE398_PCT_COMCOS_COBER" , "9"},
            });
                q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , ""},
                { "GE397_NUM_ENDOSSO" , ""},
                { "GE397_COD_RAMO_COBER" , ""},
                { "GE397_COD_COBERTURA" , ""},
                { "GE397_VLR_IMP_SEGUR_VAR" , ""},
                { "GE397_VLR_PREMIO_TARIF_VAR" , ""},
                { "GE398_COD_COSSEGURADORA" , ""},
                { "GE398_PCT_PARTIC_COBER" , ""},
                { "GE398_PCT_COMCOS_COBER" , ""},
            }, new SQLCA(100));
                q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , "1"},
                { "GE397_NUM_ENDOSSO" , "2"},
                { "GE397_COD_RAMO_COBER" , "7"},
                { "GE397_COD_COBERTURA" , "4"},
                { "GE397_VLR_IMP_SEGUR_VAR" , "5"},
                { "GE397_VLR_PREMIO_TARIF_VAR" , "6"},
                { "GE398_COD_COSSEGURADORA" , "7"},
                { "GE398_PCT_PARTIC_COBER" , "8"},
                { "GE398_PCT_COMCOS_COBER" , "9"},
            }, new SQLCA(100));
                q8.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , "1"},
                { "GE397_NUM_ENDOSSO" , "2"},
                { "GE397_COD_RAMO_COBER" , "8"},
                { "GE397_COD_COBERTURA" , "4"},
                { "GE397_VLR_IMP_SEGUR_VAR" , "5"},
                { "GE397_VLR_PREMIO_TARIF_VAR" , "6"},
                { "GE398_COD_COSSEGURADORA" , "7"},
                { "GE398_PCT_PARTIC_COBER" , "8"},
                { "GE398_PCT_COMCOS_COBER" , "9"},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("AC0006B_COSGCOBER");
                AppSettings.TestSet.DynamicData.Add("AC0006B_COSGCOBER", q8);

                #endregion

                #region R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_VAR" , "1"},
                { "APOLICOB_PRM_TARIFARIO_VAR" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1", q9);

                #endregion

                #endregion
               
                var program = new AC0006B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                #region R2500_00_INSERT_GE399_DB_INSERT_1_Insert1

                var envList = AppSettings.TestSet.DynamicData["R2500_00_INSERT_GE399_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("GE399_NUM_APOLICE", out var GE399_NUM_APOLICE) && GE399_NUM_APOLICE == "0000000000001");
                Assert.True(envList[1].TryGetValue("GE399_NUM_ENDOSSO", out var GE399_NUM_ENDOSSO) && GE399_NUM_ENDOSSO == "000000002");
                Assert.True(envList[1].TryGetValue("GE399_COD_RAMO_COBER", out var GE399_COD_RAMO_COBER) && GE399_COD_RAMO_COBER == "0003");
                Assert.True(envList[1].TryGetValue("GE399_COD_COSSEGURADORA", out var GE399_COD_COSSEGURADORA) && GE399_COD_COSSEGURADORA == "0002");
                Assert.True(envList[1].TryGetValue("GE399_VLR_IMPSEG_CED_VAR", out var GE399_VLR_IMPSEG_CED_VAR) && GE399_VLR_IMPSEG_CED_VAR == "0000000000000.40");
                Assert.True(envList[1].TryGetValue("GE399_PCT_PROP_RAMO_IS", out var GE399_PCT_PROP_RAMO_IS) && GE399_PCT_PROP_RAMO_IS == "0000.000000000");
                Assert.True(envList[1].TryGetValue("GE399_PCT_PROP_TOTAL_IS", out var GE399_PCT_PROP_TOTAL_IS) && GE399_PCT_PROP_TOTAL_IS == "0000.000000000");
                Assert.True(envList[1].TryGetValue("GE399_VLR_PRMTAR_CED_VAR", out var GE399_VLR_PRMTAR_CED_VAR) && GE399_VLR_PRMTAR_CED_VAR == "0000000000.47999");
                Assert.True(envList[1].TryGetValue("GE399_PCT_PROP_RAMO_PR", out var GE399_PCT_PROP_RAMO_PR) && GE399_PCT_PROP_RAMO_PR == "0000.000000000");
                Assert.True(envList[1].TryGetValue("GE399_PCT_PROP_TOTAL_PR", out var GE399_PCT_PROP_TOTAL_PR) && GE399_PCT_PROP_TOTAL_PR == "0000.000000000");
                Assert.True(envList[1].TryGetValue("GE399_VLR_COMCOS_RAMO", out var GE399_VLR_COMCOS_RAMO) && GE399_VLR_COMCOS_RAMO == "0000000000.54000");
                Assert.True(envList[1].TryGetValue("GE399_PCT_PROP_COM_RAMO", out var GE399_PCT_PROP_COM_RAMO) && GE399_PCT_PROP_COM_RAMO == "0000.000000000");
                Assert.True(envList[1].TryGetValue("GE399_PCT_PROP_COM_TOTAL", out var GE399_PCT_PROP_COM_TOTAL) && GE399_PCT_PROP_COM_TOTAL == "0000.000000000");
                Assert.True(envList[1].TryGetValue("GE399_NOM_PROGRAMA", out var GE399_NOM_PROGRAMA) && GE399_NOM_PROGRAMA == "AC0006B ");

                #endregion


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void AC0006B_Tests99_Fact()
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

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0006B_C01_PARCEHIS

                var q2 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("AC0006B_C01_PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("AC0006B_C01_PARCEHIS", q2);

                #endregion

                #region AC0006B_C01_APOLCOSS

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("AC0006B_C01_APOLCOSS");
                AppSettings.TestSet.DynamicData.Add("AC0006B_C01_APOLCOSS", q3);

                #endregion

                #region R0800_00_SELECT_GE397_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                           
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_GE397_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_GE397_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q6 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1

                var q7 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q7);

                #endregion

                #region AC0006B_COSGCOBER
                var q8 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("AC0006B_COSGCOBER");
                AppSettings.TestSet.DynamicData.Add("AC0006B_COSGCOBER", q8);

                #endregion

                #region R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1

                var q9 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1", q9);

                #endregion

                #endregion

                var program = new AC0006B();
                program.Execute();

               Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}