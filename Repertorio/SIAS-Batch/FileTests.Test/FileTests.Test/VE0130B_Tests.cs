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
using static Code.VE0130B;

namespace FileTests.Test
{
    [Collection("VE0130B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0130B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VE0130B_CURS01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_OCOREND" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_DATA_VENCIMENTO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_PROPOSTA" , ""},
                { "PROPOVA_STA_MUDANCA_PLANO" , ""},
                { "WS_DTPROXVEN_1D" , ""},
                { "WS_DTQUITACAO_1D" , ""},
                { "WS_DTPROXVEN_YEAR" , ""},
                { "WS_DTPROXVEN_MONTH" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0130B_CURS01", q0);

            #endregion

            #region VE0130B_CURS02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0130B_CURS02", q1);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DTMOV_ABERTO" , ""},
                { "SISTEMAS_DTTER_COTACAO" , ""},
                { "SISTEMAS_DTINI_COTACAO" , ""},
                { "SISTEMAS_DTMOV_ABERTO_30" , ""},
                { "SISTEMAS_DTMOV_YEAR" , ""},
                { "SISTEMAS_DTMOV_MONTH" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "PROPOVA_COD_OPERACAO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "WS_DTINIVIG_1D" , ""},
                { "WS_DTINIVIG_YEAR" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_COD_USUARIO" , ""},
                { "HISCOBPR_TIMESTAMP" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q6);

            #endregion

            #region R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CERTIFICADO" , ""},
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_USUARIO" , ""},
                { "OPCPAGVI_TIMESTAMP" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE0130B_Tests_Fact_ReturnCode_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VE0130B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "" },
                { "PROPOVA_COD_SUBGRUPO" , "" },
                { "PROPOVA_NUM_CERTIFICADO" , "" },
                { "PROPOVA_COD_CLIENTE" , "" },
                { "PROPOVA_OCOREND" , "" },
                { "PROPOVA_COD_FONTE" , "" },
                { "PROPOVA_AGE_COBRANCA" , "" },
                { "PROPOVA_OCORR_HISTORICO" , "" },
                { "PROPOVA_DATA_QUITACAO" , "" },
                { "PROPOVA_DATA_VENCIMENTO" , "" },
                { "PROPOVA_DTPROXVEN" , "" },
                { "PROPOVA_NUM_PARCELA" , "" },
                { "PROPOVA_COD_PRODUTO" , "" },
                { "PROPOVA_NUM_PROPOSTA" , "" },
                { "PROPOVA_STA_MUDANCA_PLANO" , "" },
                { "WS_DTPROXVEN_1D" , "" },
                { "WS_DTQUITACAO_1D" , "" },
                { "WS_DTPROXVEN_YEAR" , "" },
                { "WS_DTPROXVEN_MONTH" , "" },
            });
                AppSettings.TestSet.DynamicData.Remove("VE0130B_CURS01");
                AppSettings.TestSet.DynamicData.Add("VE0130B_CURS01", q0);

                #endregion

                #region VE0130B_CURS02

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VE0130B_CURS02");
                AppSettings.TestSet.DynamicData.Add("VE0130B_CURS02", q1);

                #endregion
                #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE0130B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Fact]
        public static void VE0130B_Tests_Fact_ReturnCode_03()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DTMOV_ABERTO" , "2020-01-01" },
                { "SISTEMAS_DTTER_COTACAO" , "2022-01-01" },
                { "SISTEMAS_DTINI_COTACAO" , "2021-01-01" },
                { "SISTEMAS_DTMOV_ABERTO_30" , "2020-01-31" },
                { "SISTEMAS_DTMOV_YEAR" , "2020" },
                { "SISTEMAS_DTMOV_MONTH" , "01" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE0130B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 3);
            }
        }
        [Fact]
        public static void VE0130B_Tests_Fact_ReturnCode_00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS
                #region VE0130B_CURS01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "108208874329" },
                { "PROPOVA_COD_SUBGRUPO" , "1" },
                { "PROPOVA_NUM_CERTIFICADO" , "19790324" },
                { "PROPOVA_COD_CLIENTE" , "11514280" },
                { "PROPOVA_OCOREND" , "1" },
                { "PROPOVA_COD_FONTE" , "4" },
                { "PROPOVA_AGE_COBRANCA" , "1236" },
                { "PROPOVA_OCORR_HISTORICO" , "1" },
                { "PROPOVA_DATA_QUITACAO" , "2006-11-16" },
                { "PROPOVA_DATA_VENCIMENTO" , "2006-11-16" },
                { "PROPOVA_DTPROXVEN" , "9999-12-31" },
                { "PROPOVA_NUM_PARCELA" , "0" },
                { "PROPOVA_COD_PRODUTO" , "8205" },
                { "PROPOVA_NUM_PROPOSTA" , "10117709" },
                { "PROPOVA_STA_MUDANCA_PLANO" , "" },
                { "WS_DTPROXVEN_1D" , "9999-12-01" },
                { "WS_DTQUITACAO_1D" , "2006-11-01" },
                { "WS_DTPROXVEN_YEAR" , "9999" },
                { "WS_DTPROXVEN_MONTH" , "12" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0130B_CURS01");
                AppSettings.TestSet.DynamicData.Add("VE0130B_CURS01", q0);

                #endregion

                #region VE0130B_CURS02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2020-01-03" },
                { "MOEDACOT_VAL_VENDA" , "-1" },
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2020-01-04" },
                { "MOEDACOT_VAL_VENDA" , "-1" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0130B_CURS02");
                AppSettings.TestSet.DynamicData.Add("VE0130B_CURS02", q1);

                #endregion
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DTMOV_ABERTO" , "2020-01-01" },
                { "SISTEMAS_DTTER_COTACAO" , "2022-01-01" },
                { "SISTEMAS_DTINI_COTACAO" , "2021-01-01" },
                { "SISTEMAS_DTMOV_ABERTO_30" , "2020-01-31" },
                { "SISTEMAS_DTMOV_YEAR" , "2020" },
                { "SISTEMAS_DTMOV_MONTH" , "01" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_VERIFICA_COTACAO_DB_SELECT_1_Query1", q3);

                #endregion
                #region R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "20100826" },
                { "HISCOBPR_OCORR_HISTORICO" , "1" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "1994-05-10" },
                { "WS_DTINIVIG_1D" , "1994-05-11" },
                { "WS_DTINIVIG_YEAR" , "1994" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31" },
                { "HISCOBPR_IMPSEGUR" , "0" },
                { "HISCOBPR_QUANT_VIDAS" , "1" },
                { "HISCOBPR_IMPSEGIND" , "0" },
                { "HISCOBPR_COD_OPERACAO" , "106" },
                { "HISCOBPR_OPCAO_COBERTURA" , "L" },
                { "HISCOBPR_IMP_MORNATU" , "0" },
                { "HISCOBPR_IMPMORACID" , "0" },
                { "HISCOBPR_IMPINVPERM" , "0" },
                { "HISCOBPR_IMPAMDS" , "0" },
                { "HISCOBPR_IMPDH" , "0"  },
                { "HISCOBPR_IMPDIT" , "0" },
                { "HISCOBPR_VLPREMIO" , "0" },
                { "HISCOBPR_PRMVG" , "0" },
                { "HISCOBPR_PRMAP" , "0" },
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "0" },
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "0" },
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0" },
                { "HISCOBPR_IMPSEGCDG" , "0" },
                { "HISCOBPR_VLCUSTCDG" , "0" },
                { "HISCOBPR_COD_USUARIO" , "PF0601B " },
                { "HISCOBPR_TIMESTAMP" , "2001-10-01 19:48:31.771" },
                { "HISCOBPR_IMPSEGAUXF" , "" },
                { "HISCOBPR_VLCUSTAUXF" , "" },
                { "HISCOBPR_PRMDIT" , "" },
                { "HISCOBPR_QTMDIT" , "" },
                });
                AppSettings.TestSet.DynamicData.Remove("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE0130B();
                program.Execute();

                var envList0 = AppSettings.TestSet.DynamicData["R2100_00_ATUALIZA_HISCOBPR_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var valor0) && valor0.Contains("19790324"));
                
                var envList1 = AppSettings.TestSet.DynamicData["R2400_00_ATUALIZA_PROPOVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPOVA_COD_OPERACAO", out var valor1) && valor1.Contains("0895"));
                
                var envList2 = AppSettings.TestSet.DynamicData["R8300_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("HISCOBPR_NUM_CERTIFICADO", out var valor2) && valor2.Contains("20100826"));
                Assert.True(envList2.Count > 1);
                
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
    }
}