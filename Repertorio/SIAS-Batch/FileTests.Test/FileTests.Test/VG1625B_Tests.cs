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
using static Code.VG1625B;

namespace FileTests.Test
{
    [Collection("VG1625B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1625B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-18"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG1625B_CPROPOVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "19790324"},
                { "PROPOVA_NUM_APOLICE" , "7777"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_OCORR_HISTORICO" , "ocorrencia histórico"},
                { "PROPOVA_DTPROXVEN" , "2024-10-01"},
            });
            AppSettings.TestSet.DynamicData.Add("VG1625B_CPROPOVA", q1);

            #endregion

            #region R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDSEG" , "10"}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_DATA_VENCIMENTO" , ""},
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_INIVIGENCIA" , ""},
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
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PLANOFAI_PRM_VG" , ""},
                { "PLANOVGA_IMP_MORNATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2450_SELECT_00_MAX_PLAN_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PLANOVGA_COD_PLANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2450_SELECT_00_MAX_PLAN_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PLANOVGA_COD_PLANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PLANOVGA_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "1234"},
                { "HISCOBPR_OCORR_HISTORICO" , "ocorrencia"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "2024-10-01"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "2024-11-01"},
                { "HISCOBPR_IMPSEGUR" , "1"},
                { "HISCOBPR_QUANT_VIDAS" , "2"},
                { "HISCOBPR_IMPSEGIND" , "4"},
                { "HISCOBPR_COD_OPERACAO" , "44"},
                { "HISCOBPR_IMP_MORNATU" , "1"},
                { "HISCOBPR_IMPMORACID" , "1"},
                { "HISCOBPR_IMPINVPERM" , "2"},
                { "HISCOBPR_IMPAMDS" , "2"},
                { "HISCOBPR_IMPDH" , "3"},
                { "HISCOBPR_IMPDIT" , "3"},
                { "HISCOBPR_VLPREMIO" , "23"},
                { "HISCOBPR_PRMVG" , "hist vg"},
                { "HISCOBPR_PRMAP" , "hist map"},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , "hist qtde titulo"},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , "valor tit capit"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "valor custo"},
                { "HISCOBPR_IMPSEGCDG" , "2"},
                { "HISCOBPR_VLCUSTCDG" , "46"},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , "2024-10-10"},
                { "PROPOVA_NUM_CERTIFICADO" , "12346"},
                { "PROPOVA_OCORR_HISTORICO" , "ocorrencia historico"},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , "hist ocorrencia"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "7777"},
            });
            AppSettings.TestSet.DynamicData.Add("R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPSEG" , ""},
                { "WHOST_QTDSEG" , ""},
                { "WHOST_PRMVG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PRMVG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PRMVG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1", q15);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG1625B_Tests_Fact_ReturnCode00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string> {
                    { "PARCEVID_DATA_VENCIMENTO" , ""},
                    { "PARCEVID_PREMIO_VG" , ""},
                    { "PARCEVID_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q4);


                #endregion
                #endregion
                var program = new VG1625B();
                program.Execute();

                Assert.True(program.RETURN_CODE==00);
            }
        }
        [Fact]
        public static void VG1625B_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1
                //var q0 = new DynamicData();
                //q0.AddDynamic(new Dictionary<string, string>{
                //    { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-18"}
                //});
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1");
                //AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);


                #endregion
                #endregion
                var program = new VG1625B();
                program.Execute();

                Assert.True(program.RETURN_CODE==99);
            }
        }

    }
}