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
using static Code.AU0025S;

namespace FileTests.Test
{
    [Collection("AU0025S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AU0025S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "TAXAC_PRMREF_IX" , ""},
                { "TAXAC_TAXA_IS" , ""},
                { "TAXAC_CODUNIMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "TAXAC_PRMREF_IX" , ""},
                { "TAXAC_TAXA_IS" , ""},
                { "TAXAC_CODUNIMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1MOEDA_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_025_000_LE_BONUS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "BONAU_PCDESC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_025_000_LE_BONUS_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CATTF_VLPRTXCF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "FRFAC_PCDESC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CATTF_VLPRTXCF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CATTF_VLPRTXCF" , ""},
                { "CATTF_PREBASBT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CATTF_PREBASBT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PRAZO_PCPRMANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1", q9);

            #endregion

            #region AU0025S_NIVCSBT

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "NIVCS_NIVEL" , ""},
                { "NIVCS_IMPSEGBT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AU0025S_NIVCSBT", q10);

            #endregion

            #region M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CFRCF_COEFIC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "TXAPP_TAXAAPPM" , ""},
                { "TXAPP_TAXAAPPI" , ""},
                { "TXAPP_TAXAAPPA" , ""},
                { "TXAPP_TAXAAPPD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1", q12);

            #endregion

            #endregion
        }

        [Fact]
        public static void AU0025S_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                //q0.AddDynamic(new Dictionary<string, string>{
                //    { "TAXAC_PRMREF_IX" , ""},
                //    { "TAXAC_TAXA_IS" , ""},
                //    { "TAXAC_CODUNIMO" , ""},
                //});
                AppSettings.TestSet.DynamicData.Remove("M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "TAXAC_PRMREF_IX" , ""},
                    { "TAXAC_TAXA_IS" , ""},
                    { "TAXAC_CODUNIMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1MOEDA_VLCRUZAD" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_025_000_LE_BONUS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "BONAU_PCDESC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_025_000_LE_BONUS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_025_000_LE_BONUS_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_VLPRTXCF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "FRFAC_PCDESC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_VLPRTXCF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_VLPRTXCF" , ""},
                    { "CATTF_PREBASBT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_PREBASBT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "PRAZO_PCPRMANO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1", q9);

                #endregion

                #region AU0025S_NIVCSBT

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "NIVCS_NIVEL" , ""},
                    { "NIVCS_IMPSEGBT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AU0025S_NIVCSBT");
                AppSettings.TestSet.DynamicData.Add("AU0025S_NIVCSBT", q10);

                #endregion

                #region M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "CFRCF_COEFIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "TXAPP_TAXAAPPM" , ""},
                    { "TXAPP_TAXAAPPI" , ""},
                    { "TXAPP_TAXAAPPA" , ""},
                    { "TXAPP_TAXAAPPD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1", q12);

                #endregion
                #endregion

                var param = new AU0025S_CSP_REGISTRO();
                param.CSP_MOEDA_IMP.Value = 1;
                param.CSP_MOEDA_PRM.Value = 1;
                param.CSP_VLTARPRM.Value = 1;
                param.CSP_IDEPZSEG.Value = "S";
                param.CSP_VRISCASC.Value = 1;
                #endregion

                var program = new AU0025S();
                program.Execute(param);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selectsConsumed = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selectsConsumed.Count >= (allSelects.Count / 2));

                Assert.Equal(000, program.CSP_RETORNO.CSP_MSG.CSP_CODE.Value);
            }
        }

        [Fact]
        public static void AU0025S_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                //q0.AddDynamic(new Dictionary<string, string>{
                //    { "TAXAC_PRMREF_IX" , ""},
                //    { "TAXAC_TAXA_IS" , ""},
                //    { "TAXAC_CODUNIMO" , ""},
                //});
                AppSettings.TestSet.DynamicData.Remove("M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_010_000_SELECIONA_TAXAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "TAXAC_PRMREF_IX" , ""},
                    { "TAXAC_TAXA_IS" , ""},
                    { "TAXAC_CODUNIMO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_010_000_SELECIONA_TAXAS_DB_SELECT_2_Query1", q1);

                #endregion

                #region M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1MOEDA_VLCRUZAD" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_025_000_LE_BONUS_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "BONAU_PCDESC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_025_000_LE_BONUS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_025_000_LE_BONUS_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_VLPRTXCF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_035_000_PESQ_FRANQOBR_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "FRFAC_PCDESC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_VLPRTXCF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_VLPRTXCF" , ""},
                    { "CATTF_PREBASBT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "CATTF_PREBASBT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "PRAZO_PCPRMANO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1_Query1", q9);

                #endregion

                #region AU0025S_NIVCSBT

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "NIVCS_NIVEL" , ""},
                    { "NIVCS_IMPSEGBT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AU0025S_NIVCSBT");
                AppSettings.TestSet.DynamicData.Add("AU0025S_NIVCSBT", q10);

                #endregion

                #region M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "CFRCF_COEFIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "TXAPP_TAXAAPPM" , ""},
                    { "TXAPP_TAXAAPPI" , ""},
                    { "TXAPP_TAXAAPPA" , ""},
                    { "TXAPP_TAXAAPPD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1", q12);

                #endregion
                #endregion

                var param = new AU0025S_CSP_REGISTRO();
                //param.CSP_MOEDA_IMP.Value = 1;
                //param.CSP_MOEDA_PRM.Value = 1;
                //param.CSP_VLTARPRM.Value = 1;
                //param.CSP_IDEPZSEG.Value = "S";
                //param.CSP_VRISCASC.Value = 1;
                #endregion

                var program = new AU0025S();
                program.Execute(param);

                Assert.Equal(999, program.CSP_RETORNO.CSP_MSG.CSP_CODE.Value);
            }
        }
    }
}