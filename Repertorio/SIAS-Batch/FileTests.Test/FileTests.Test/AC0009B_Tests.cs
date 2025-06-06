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
using static Code.AC0009B;

namespace FileTests.Test
{
    [Collection("AC0009B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0009B_Tests
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

            #region AC0009B_C01_PARCEHIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
                { "APOLICES_TIPO_SEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0009B_C01_PARCEHIS", q2);

            #endregion

            #region AC0009B_C01_APOLCOSS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_NUM_APOLICE" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0009B_C01_APOLCOSS", q3);

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
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ORDEMCOS_NUM_APOLICE" , ""},
                { "ORDEMCOS_NUM_ENDOSSO" , ""},
                { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                { "ORDEMCOS_ORDEM_CEDIDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1700_00_SELECT_GE399_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE399_VLR_PRMTAR_CED_VAR" , ""},
                { "GE399_PCT_PROP_TOTAL_PR" , ""},
                { "GE399_VLR_COMCOS_RAMO" , ""},
                { "GE399_PCT_PROP_COM_TOTAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE399_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "COSSPREM_COD_EMPRESA" , ""},
                { "COSSPREM_TIPO_SEGURO" , ""},
                { "COSSPREM_COD_CONGENERE" , ""},
                { "COSSPREM_NUM_ORDEM" , ""},
                { "COSSPREM_NUM_APOLICE" , ""},
                { "COSSPREM_NUM_ENDOSSO" , ""},
                { "COSSPREM_NUM_PARCELA" , ""},
                { "COSSPREM_PRM_TARIFARIO_IX" , ""},
                { "COSSPREM_VAL_DESCONTO_IX" , ""},
                { "COSSPREM_PRM_LIQUIDO_IX" , ""},
                { "COSSPREM_ADIC_FRACIO_IX" , ""},
                { "COSSPREM_VAL_COMISSAO_IX" , ""},
                { "COSSPREM_PRM_TOTAL_IX" , ""},
                { "COSSPREM_SIT_REGISTRO" , ""},
                { "COSSPREM_SIT_CONGENERE" , ""},
                { "COSSPREM_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "COSHISPR_COD_EMPRESA" , ""},
                { "COSHISPR_COD_CONGENERE" , ""},
                { "COSHISPR_NUM_APOLICE" , ""},
                { "COSHISPR_NUM_ENDOSSO" , ""},
                { "COSHISPR_NUM_PARCELA" , ""},
                { "COSHISPR_OCORR_HISTORICO" , ""},
                { "COSHISPR_COD_OPERACAO" , ""},
                { "COSHISPR_DATA_MOVIMENTO" , ""},
                { "COSHISPR_TIPO_SEGURO" , ""},
                { "COSHISPR_PRM_TARIFARIO" , ""},
                { "COSHISPR_VAL_DESCONTO" , ""},
                { "COSHISPR_PRM_LIQUIDO" , ""},
                { "COSHISPR_ADIC_FRACIONAMENTO" , ""},
                { "COSHISPR_VAL_COMISSAO" , ""},
                { "COSHISPR_PRM_TOTAL" , ""},
                { "COSHISPR_DATA_QUITACAO" , ""},
                { "COSHISPR_SIT_FINANCEIRA" , ""},
                { "COSHISPR_SIT_LIBRECUP" , ""},
                { "COSHISPR_NUM_OCORRENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1", q11);

            #endregion

            #region R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_REGT" , ""},
                { "WHOST_OCORHIST" , ""},
                { "COSHISPR_COD_CONGENERE" , ""},
                { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                { "COSHISPR_TIPO_SEGURO" , ""},
                { "COSHISPR_NUM_APOLICE" , ""},
                { "COSHISPR_NUM_ENDOSSO" , ""},
                { "COSHISPR_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0009B_Tests_Fact()
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
                #region PARAMETERS
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
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

                #region AC0009B_C01_PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , ""},
                    { "PARCEHIS_NUM_ENDOSSO" , ""},
                    { "PARCEHIS_NUM_PARCELA" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , "0202"},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_PRM_TARIFARIO" , ""},
                    { "PARCEHIS_VAL_DESCONTO" , ""},
                    { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                    { "PARCEHIS_DATA_QUITACAO" , ""},
                    { "PARCEHIS_COD_EMPRESA" , ""},
                    { "APOLICES_TIPO_SEGURO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0009B_C01_PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("AC0009B_C01_PARCEHIS", q2);

                #endregion

                #region AC0009B_C01_APOLCOSS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOSS_NUM_APOLICE" , ""},
                    { "APOLCOSS_COD_COSSEGURADORA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0009B_C01_APOLCOSS");
                AppSettings.TestSet.DynamicData.Add("AC0009B_C01_APOLCOSS", q3);

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
                    { "ENDOSSOS_NUM_APOLICE" , "109300002675"},
                    { "ENDOSSOS_NUM_ENDOSSO" , ""},
                    { "ENDOSSOS_RAMO_EMISSOR" , ""},
                    { "ENDOSSOS_COD_PRODUTO" , ""},
                    { "ENDOSSOS_COD_SUBGRUPO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "ENDOSSOS_DATA_EMISSAO" , ""},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , "2025-11-01"},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                    { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                    { "ENDOSSOS_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "ORDEMCOS_NUM_APOLICE" , ""},
                    { "ORDEMCOS_NUM_ENDOSSO" , ""},
                    { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                    { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1700_00_SELECT_GE399_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "GE399_VLR_PRMTAR_CED_VAR" , ""},
                    { "GE399_PCT_PROP_TOTAL_PR" , ""},
                    { "GE399_VLR_COMCOS_RAMO" , ""},
                    { "GE399_PCT_PROP_COM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_GE399_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE399_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , ""},
                    { "PARCELAS_NUM_ENDOSSO" , ""},
                    { "PARCELAS_NUM_PARCELA" , ""},
                    { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                    { "PARCELAS_VAL_DESCONTO_IX" , ""},
                    { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "COSSPREM_COD_EMPRESA" , ""},
                    { "COSSPREM_TIPO_SEGURO" , ""},
                    { "COSSPREM_COD_CONGENERE" , ""},
                    { "COSSPREM_NUM_ORDEM" , ""},
                    { "COSSPREM_NUM_APOLICE" , ""},
                    { "COSSPREM_NUM_ENDOSSO" , ""},
                    { "COSSPREM_NUM_PARCELA" , ""},
                    { "COSSPREM_PRM_TARIFARIO_IX" , ""},
                    { "COSSPREM_VAL_DESCONTO_IX" , ""},
                    { "COSSPREM_PRM_LIQUIDO_IX" , ""},
                    { "COSSPREM_ADIC_FRACIO_IX" , ""},
                    { "COSSPREM_VAL_COMISSAO_IX" , ""},
                    { "COSSPREM_PRM_TOTAL_IX" , ""},
                    { "COSSPREM_SIT_REGISTRO" , ""},
                    { "COSSPREM_SIT_CONGENERE" , ""},
                    { "COSSPREM_OCORR_HISTORICO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "COSHISPR_COD_EMPRESA" , ""},
                    { "COSHISPR_COD_CONGENERE" , ""},
                    { "COSHISPR_NUM_APOLICE" , ""},
                    { "COSHISPR_NUM_ENDOSSO" , ""},
                    { "COSHISPR_NUM_PARCELA" , ""},
                    { "COSHISPR_OCORR_HISTORICO" , ""},
                    { "COSHISPR_COD_OPERACAO" , ""},
                    { "COSHISPR_DATA_MOVIMENTO" , ""},
                    { "COSHISPR_TIPO_SEGURO" , ""},
                    { "COSHISPR_PRM_TARIFARIO" , ""},
                    { "COSHISPR_VAL_DESCONTO" , ""},
                    { "COSHISPR_PRM_LIQUIDO" , ""},
                    { "COSHISPR_ADIC_FRACIONAMENTO" , ""},
                    { "COSHISPR_VAL_COMISSAO" , ""},
                    { "COSHISPR_PRM_TOTAL" , ""},
                    { "COSHISPR_DATA_QUITACAO" , ""},
                    { "COSHISPR_SIT_FINANCEIRA" , ""},
                    { "COSHISPR_SIT_LIBRECUP" , ""},
                    { "COSHISPR_NUM_OCORRENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_OCORHIST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1", q11);

                #endregion

                #region R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SIT_REGT" , ""},
                    { "WHOST_OCORHIST" , ""},
                    { "COSHISPR_COD_CONGENERE" , ""},
                    { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                    { "COSHISPR_TIPO_SEGURO" , ""},
                    { "COSHISPR_NUM_APOLICE" , ""},
                    { "COSHISPR_NUM_ENDOSSO" , ""},
                    { "COSHISPR_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0009B();
                program.Execute();

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count > allSelects.Count / 2);

                var update1 = AppSettings.TestSet.DynamicData["R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(update1.Count > 1);
                Assert.True(update1[1].TryGetValue("COSHISPR_COD_CONGENERE", out string value1) && value1.Equals("0001"));
                Assert.True(update1[1].TryGetValue("UpdateCheck", out string value2) && value2.Equals("UpdateCheck"));

                var insert1 = AppSettings.TestSet.DynamicData["R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert1[1].TryGetValue("COSHISPR_COD_OPERACAO", out string value8) && value8.Equals("0202"));
                Assert.True(insert1.Count > 1);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void AC0009B_Tests_Insert2_Fact()
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
                #region PARAMETERS
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
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

                #region AC0009B_C01_PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , ""},
                    { "PARCEHIS_NUM_ENDOSSO" , ""},
                    { "PARCEHIS_NUM_PARCELA" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , "0101"},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_PRM_TARIFARIO" , ""},
                    { "PARCEHIS_VAL_DESCONTO" , ""},
                    { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                    { "PARCEHIS_DATA_QUITACAO" , ""},
                    { "PARCEHIS_COD_EMPRESA" , ""},
                    { "APOLICES_TIPO_SEGURO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0009B_C01_PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("AC0009B_C01_PARCEHIS", q2);

                #endregion

                #region AC0009B_C01_APOLCOSS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOSS_NUM_APOLICE" , ""},
                    { "APOLCOSS_COD_COSSEGURADORA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0009B_C01_APOLCOSS");
                AppSettings.TestSet.DynamicData.Add("AC0009B_C01_APOLCOSS", q3);

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
                    { "ENDOSSOS_NUM_APOLICE" , "109300002675"},
                    { "ENDOSSOS_NUM_ENDOSSO" , ""},
                    { "ENDOSSOS_RAMO_EMISSOR" , ""},
                    { "ENDOSSOS_COD_PRODUTO" , ""},
                    { "ENDOSSOS_COD_SUBGRUPO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "ENDOSSOS_DATA_EMISSAO" , ""},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , "2025-11-01"},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                    { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                    { "ENDOSSOS_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "ORDEMCOS_NUM_APOLICE" , ""},
                    { "ORDEMCOS_NUM_ENDOSSO" , ""},
                    { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                    { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1700_00_SELECT_GE399_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "GE399_VLR_PRMTAR_CED_VAR" , ""},
                    { "GE399_PCT_PROP_TOTAL_PR" , ""},
                    { "GE399_VLR_COMCOS_RAMO" , ""},
                    { "GE399_PCT_PROP_COM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_GE399_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE399_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , ""},
                    { "PARCELAS_NUM_ENDOSSO" , ""},
                    { "PARCELAS_NUM_PARCELA" , ""},
                    { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                    { "PARCELAS_VAL_DESCONTO_IX" , ""},
                    { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "COSSPREM_COD_EMPRESA" , ""},
                    { "COSSPREM_TIPO_SEGURO" , ""},
                    { "COSSPREM_COD_CONGENERE" , ""},
                    { "COSSPREM_NUM_ORDEM" , ""},
                    { "COSSPREM_NUM_APOLICE" , ""},
                    { "COSSPREM_NUM_ENDOSSO" , ""},
                    { "COSSPREM_NUM_PARCELA" , ""},
                    { "COSSPREM_PRM_TARIFARIO_IX" , ""},
                    { "COSSPREM_VAL_DESCONTO_IX" , ""},
                    { "COSSPREM_PRM_LIQUIDO_IX" , ""},
                    { "COSSPREM_ADIC_FRACIO_IX" , ""},
                    { "COSSPREM_VAL_COMISSAO_IX" , ""},
                    { "COSSPREM_PRM_TOTAL_IX" , ""},
                    { "COSSPREM_SIT_REGISTRO" , ""},
                    { "COSSPREM_SIT_CONGENERE" , ""},
                    { "COSSPREM_OCORR_HISTORICO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "COSHISPR_COD_EMPRESA" , ""},
                    { "COSHISPR_COD_CONGENERE" , ""},
                    { "COSHISPR_NUM_APOLICE" , ""},
                    { "COSHISPR_NUM_ENDOSSO" , ""},
                    { "COSHISPR_NUM_PARCELA" , ""},
                    { "COSHISPR_OCORR_HISTORICO" , ""},
                    { "COSHISPR_COD_OPERACAO" , ""},
                    { "COSHISPR_DATA_MOVIMENTO" , ""},
                    { "COSHISPR_TIPO_SEGURO" , ""},
                    { "COSHISPR_PRM_TARIFARIO" , ""},
                    { "COSHISPR_VAL_DESCONTO" , ""},
                    { "COSHISPR_PRM_LIQUIDO" , ""},
                    { "COSHISPR_ADIC_FRACIONAMENTO" , ""},
                    { "COSHISPR_VAL_COMISSAO" , ""},
                    { "COSHISPR_PRM_TOTAL" , ""},
                    { "COSHISPR_DATA_QUITACAO" , ""},
                    { "COSHISPR_SIT_FINANCEIRA" , ""},
                    { "COSHISPR_SIT_LIBRECUP" , ""},
                    { "COSHISPR_NUM_OCORRENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_OCORHIST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1", q11);

                #endregion

                #region R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SIT_REGT" , ""},
                    { "WHOST_OCORHIST" , ""},
                    { "COSHISPR_COD_CONGENERE" , ""},
                    { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                    { "COSHISPR_TIPO_SEGURO" , ""},
                    { "COSHISPR_NUM_APOLICE" , ""},
                    { "COSHISPR_NUM_ENDOSSO" , ""},
                    { "COSHISPR_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0009B();
                program.Execute();

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count > allSelects.Count / 2);

                var insert1 = AppSettings.TestSet.DynamicData["R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(insert1.Count > 1);
                Assert.True(insert1[1].TryGetValue("COSSPREM_COD_CONGENERE", out string value7) && value7.Equals("0001"));

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void AC0009B_Tests_ReturnCode99_Fact()
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
                #region PARAMETERS
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_QTDE_REG" , "0"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

                #endregion

                #region AC0009B_C01_PARCEHIS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "PARCEHIS_NUM_APOLICE" , ""},
                    { "PARCEHIS_NUM_ENDOSSO" , ""},
                    { "PARCEHIS_NUM_PARCELA" , ""},
                    { "PARCEHIS_DATA_MOVIMENTO" , ""},
                    { "PARCEHIS_COD_OPERACAO" , "0101"},
                    { "PARCEHIS_OCORR_HISTORICO" , ""},
                    { "PARCEHIS_PRM_TARIFARIO" , ""},
                    { "PARCEHIS_VAL_DESCONTO" , ""},
                    { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                    { "PARCEHIS_DATA_QUITACAO" , ""},
                    { "PARCEHIS_COD_EMPRESA" , ""},
                    { "APOLICES_TIPO_SEGURO" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("AC0009B_C01_PARCEHIS");
                AppSettings.TestSet.DynamicData.Add("AC0009B_C01_PARCEHIS", q2);

                #endregion

                #region AC0009B_C01_APOLCOSS

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "APOLCOSS_NUM_APOLICE" , ""},
                    { "APOLCOSS_COD_COSSEGURADORA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0009B_C01_APOLCOSS");
                AppSettings.TestSet.DynamicData.Add("AC0009B_C01_APOLCOSS", q3);

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
                    { "ENDOSSOS_NUM_APOLICE" , "109300002675"},
                    { "ENDOSSOS_NUM_ENDOSSO" , ""},
                    { "ENDOSSOS_RAMO_EMISSOR" , ""},
                    { "ENDOSSOS_COD_PRODUTO" , ""},
                    { "ENDOSSOS_COD_SUBGRUPO" , ""},
                    { "ENDOSSOS_COD_FONTE" , ""},
                    { "ENDOSSOS_DATA_EMISSAO" , ""},
                    { "ENDOSSOS_DATA_INIVIGENCIA" , "2025-11-01"},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                    { "ENDOSSOS_QTD_PARCELAS" , ""},
                    { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                    { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                    { "ENDOSSOS_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "ORDEMCOS_NUM_APOLICE" , ""},
                    { "ORDEMCOS_NUM_ENDOSSO" , ""},
                    { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                    { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1700_00_SELECT_GE399_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "GE399_VLR_PRMTAR_CED_VAR" , ""},
                    { "GE399_PCT_PROP_TOTAL_PR" , ""},
                    { "GE399_VLR_COMCOS_RAMO" , ""},
                    { "GE399_PCT_PROP_COM_TOTAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_GE399_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_GE399_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PARCELAS_NUM_APOLICE" , ""},
                    { "PARCELAS_NUM_ENDOSSO" , ""},
                    { "PARCELAS_NUM_PARCELA" , ""},
                    { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                    { "PARCELAS_VAL_DESCONTO_IX" , ""},
                    { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "COSSPREM_COD_EMPRESA" , ""},
                    { "COSSPREM_TIPO_SEGURO" , ""},
                    { "COSSPREM_COD_CONGENERE" , ""},
                    { "COSSPREM_NUM_ORDEM" , ""},
                    { "COSSPREM_NUM_APOLICE" , ""},
                    { "COSSPREM_NUM_ENDOSSO" , ""},
                    { "COSSPREM_NUM_PARCELA" , ""},
                    { "COSSPREM_PRM_TARIFARIO_IX" , ""},
                    { "COSSPREM_VAL_DESCONTO_IX" , ""},
                    { "COSSPREM_PRM_LIQUIDO_IX" , ""},
                    { "COSSPREM_ADIC_FRACIO_IX" , ""},
                    { "COSSPREM_VAL_COMISSAO_IX" , ""},
                    { "COSSPREM_PRM_TOTAL_IX" , ""},
                    { "COSSPREM_SIT_REGISTRO" , ""},
                    { "COSSPREM_SIT_CONGENERE" , ""},
                    { "COSSPREM_OCORR_HISTORICO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "COSHISPR_COD_EMPRESA" , ""},
                    { "COSHISPR_COD_CONGENERE" , ""},
                    { "COSHISPR_NUM_APOLICE" , ""},
                    { "COSHISPR_NUM_ENDOSSO" , ""},
                    { "COSHISPR_NUM_PARCELA" , ""},
                    { "COSHISPR_OCORR_HISTORICO" , ""},
                    { "COSHISPR_COD_OPERACAO" , ""},
                    { "COSHISPR_DATA_MOVIMENTO" , ""},
                    { "COSHISPR_TIPO_SEGURO" , ""},
                    { "COSHISPR_PRM_TARIFARIO" , ""},
                    { "COSHISPR_VAL_DESCONTO" , ""},
                    { "COSHISPR_PRM_LIQUIDO" , ""},
                    { "COSHISPR_ADIC_FRACIONAMENTO" , ""},
                    { "COSHISPR_VAL_COMISSAO" , ""},
                    { "COSHISPR_PRM_TOTAL" , ""},
                    { "COSHISPR_DATA_QUITACAO" , ""},
                    { "COSHISPR_SIT_FINANCEIRA" , ""},
                    { "COSHISPR_SIT_LIBRECUP" , ""},
                    { "COSHISPR_NUM_OCORRENCIA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_OCORHIST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1", q11);

                #endregion

                #region R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_SIT_REGT" , ""},
                    { "WHOST_OCORHIST" , ""},
                    { "COSHISPR_COD_CONGENERE" , ""},
                    { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                    { "COSHISPR_TIPO_SEGURO" , ""},
                    { "COSHISPR_NUM_APOLICE" , ""},
                    { "COSHISPR_NUM_ENDOSSO" , ""},
                    { "COSHISPR_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1", q12);

                #endregion

                #endregion
                #endregion
                var program = new AC0009B();
                program.Execute();

                Assert.True(program.RETURN_CODE.Value == 99);
            }
        }
    }
}