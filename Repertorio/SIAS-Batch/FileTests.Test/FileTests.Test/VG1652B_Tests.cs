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
using static Code.VG1652B;

namespace FileTests.Test
{
    [Collection("VG1652B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG1652B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , ""},
                { "PARAMRAM_RAMO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_HOJE" , ""},
                { "WHOST_DATA_HOJE_MAIS15" , ""},
                { "WHOST_DIA_HOJE_MAIS15" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_FATURAMENTO" , ""},
                { "WHOST_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region VG1652B_CPROPOVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_OCORR_HISTORICO" , "1"},
                { "PROPOVA_DTPROXVEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1652B_CPROPOVA", q2);

            #endregion

            #region VG1652B_SEGURVGA1
            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "WHOST_NUM_PARCELA" , ""},
                { "MOVIMVGA_COD_FONTE" , ""},
                { "MOVIMVGA_NUM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1652B_SEGURVGA1", q3);
            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "WHOST_DATA_FAT_FIM" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "WHOST_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "VIND_DATA_FATURA_U" , ""},
                { "MOVIMVGA_NUM_PROPOSTA" , ""},
                { "MOVIMVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1", q6);

            #endregion

            #region R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1", q8);

            #endregion

            #region R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "WHOST_DATA_TERVIGENCIA" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DIA_DEBITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
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
            });
            AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINIVIG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1", q15);

            #endregion

            #region R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q16);

            #endregion

            VG0710S_Tests.Load_Parameters();

            #endregion
        }

       // [Fact]
        public static void VG1652B_Tests_Fact()
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

                //*******************************
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "0"},
                { "PARAMRAM_RAMO_AP" , "82"},
                 });
                AppSettings.TestSet.DynamicData.Remove("R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1", q0);
                //******************
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_HOJE" , "2025-02-07"},
                { "WHOST_DATA_HOJE_MAIS15" , "2025-02-22"},
                { "WHOST_DIA_HOJE_MAIS15" , "22"},
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "WHOST_DATA_FATURAMENTO" , "2025-01-27"},
                { "WHOST_DTTERVIG" , "2025-02-28"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q1);
                //*******************
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , "1"},
                { "SUBGVGAP_TIPO_FATURAMENTO" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q10);

                //******************
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123456789"},
                { "PROPOVA_NUM_APOLICE" , "93010000890"},
                { "PROPOVA_COD_SUBGRUPO" , "13"},
                { "PROPOVA_NUM_PARCELA" , "118"},
                { "PROPOVA_OCORR_HISTORICO" , "1"},
                { "PROPOVA_DTPROXVEN" , ""},
               });
                AppSettings.TestSet.DynamicData.Remove("VG1652B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VG1652B_CPROPOVA", q2);

                //*************************
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_ITEM" , "23295"},
                { "SEGURVGA_OCORR_HISTORICO" , "4"},
                { "SEGURVGA_NUM_CERTIFICADO" , "7457254811"},
                { "WHOST_NUM_PARCELA" , "22"},
                { "MOVIMVGA_COD_FONTE" , "5"},
                { "MOVIMVGA_NUM_PROPOSTA" , "13744336"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1652B_SEGURVGA1");
                AppSettings.TestSet.DynamicData.Add("VG1652B_SEGURVGA1", q3);
              //************************
           
                var q4 = new DynamicData();
                 /*q4.AddDynamic(new Dictionary<string, string>{
               { "HISCOBPR_NUM_CERTIFICADO" , ""}              
                } , new SQLCA(100) ); */
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);
                //***************************************************
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , "200"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1", q8);
                //************************************************
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , "21"}
                 });
                AppSettings.TestSet.DynamicData.Remove("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q7);
                //*************************************************
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "0"}
                });
                 AppSettings.TestSet.DynamicData.Remove("R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                 AppSettings.TestSet.DynamicData.Add("R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1", q9);
                #endregion
 
                 var program = new VG1652B();
                 program.Execute();

                 AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                 var envList1 = AppSettings.TestSet.DynamicData["R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1"].DynamicList;
                 Assert.True(envList1?.Count > 1);
                 Assert.True(envList1[1].TryGetValue("HISCONPA_NUM_ENDOSSO", out var HISCONPA_NUM_ENDOSSO) && HISCONPA_NUM_ENDOSSO == "-00202502");
                 Assert.True(envList1[1].TryGetValue("WHOST_DATA_FAT_FIM", out var WHOST_DATA_FAT_FIM) && WHOST_DATA_FAT_FIM == "2025-01-27");
                 Assert.True(envList1[1].TryGetValue("SEGURVGA_NUM_CERTIFICADO", out var SEGURVGA_NUM_CERTIFICADO) && SEGURVGA_NUM_CERTIFICADO == "000007457254811");
                 Assert.True(envList1[1].TryGetValue("WHOST_NUM_PARCELA", out var WHOST_NUM_PARCELA) && WHOST_NUM_PARCELA == "0022");

                //**************************************************************************************************************
                 var envList2 = AppSettings.TestSet.DynamicData["R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1"].DynamicList;
                 Assert.True(envList2?.Count > 1);
                 Assert.True(envList2[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2025-01-27");
                 Assert.True(envList2[1].TryGetValue("VIND_DATA_FATURA_U", out var VIND_DATA_FATURA_U) && VIND_DATA_FATURA_U == "0000");
                 Assert.True(envList2[1].TryGetValue("MOVIMVGA_NUM_PROPOSTA", out var MOVIMVGA_NUM_PROPOSTA) && MOVIMVGA_NUM_PROPOSTA == "013744336");
                 Assert.True(envList2[1].TryGetValue("MOVIMVGA_COD_FONTE", out var MOVIMVGA_COD_FONTE) && MOVIMVGA_COD_FONTE == "0005");
                //***************************************************************************************************************
                 var envList3 = AppSettings.TestSet.DynamicData["R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1"].DynamicList;
                 Assert.True(envList3?.Count > 1);
                 Assert.True(envList3[1].TryGetValue("WHOST_DTINIVIG", out var WHOST_DTINIVIG) && WHOST_DTINIVIG == "2025-02-01");
                 Assert.True(envList3[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var PROPOVA_NUM_CERTIFICADO) && PROPOVA_NUM_CERTIFICADO == "000000123456789");
                 Assert.True(envList3[1].TryGetValue("PROPOVA_OCORR_HISTORICO", out var PROPOVA_OCORR_HISTORICO) && PROPOVA_OCORR_HISTORICO == "0001");
                //**************************************************************************************************************
                 var envList4 = AppSettings.TestSet.DynamicData["R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1"].DynamicList;
                 Assert.True(envList4?.Count > 1);
                 Assert.True(envList4[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var NUM_CERTIFICADO) && NUM_CERTIFICADO == "000000123456789");
                 Assert.True(envList4[1].TryGetValue("PROPOVA_OCORR_HISTORICO", out var OCORR_HISTORICO) && OCORR_HISTORICO == "0001");
                //**************************************************************************************************************
                 var envList5 = AppSettings.TestSet.DynamicData["R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1"].DynamicList;
                 Assert.True(envList5?.Count > 1);
                 Assert.True(envList5[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var HISCOBPR_OCORR_HISTORICO) && HISCOBPR_OCORR_HISTORICO == "0002");
                 Assert.True(envList5[1].TryGetValue("PROPOVA_DTPROXVEN", out var PROPOVA_DTPROXVEN) && PROPOVA_DTPROXVEN == "2025-02-00");
                 Assert.True(envList5[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var CERTIFICADO) && CERTIFICADO == "000000123456789");
               //********************************************************************
                var envList6 = AppSettings.TestSet.DynamicData["R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var INC_CERTIFICADO) && INC_CERTIFICADO == "000000123456789");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var INC_OCORR_HISTORICO) && INC_OCORR_HISTORICO == "0002");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_DATA_INIVIGENCIA", out var HISCOBPR_DATA_INIVIGENCIA) && HISCOBPR_DATA_INIVIGENCIA == "2025-02-01");              
                Assert.True(envList6[1].TryGetValue("HISCOBPR_DATA_TERVIGENCIA", out var HISCOBPR_DATA_TERVIGENCIA) && HISCOBPR_DATA_TERVIGENCIA == "9999-12-31");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPSEGUR", out var HISCOBPR_IMPSEGUR) && HISCOBPR_IMPSEGUR == "0000000000021.00");             
                Assert.True(envList6[1].TryGetValue("HISCOBPR_QUANT_VIDAS", out var HISCOBPR_QUANT_VIDAS) && HISCOBPR_QUANT_VIDAS == "000000001");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPSEGIND", out var HISCOBPR_IMPSEGIND) && HISCOBPR_IMPSEGIND == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_COD_OPERACAO", out var HISCOBPR_COD_OPERACAO) && HISCOBPR_COD_OPERACAO == "0801");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMP_MORNATU", out var HISCOBPR_IMP_MORNATU) && HISCOBPR_IMP_MORNATU == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPMORACID", out var HISCOBPR_IMPMORACID) && HISCOBPR_IMPMORACID == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPINVPERM", out var HISCOBPR_IMPINVPERM) && HISCOBPR_IMPINVPERM == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPAMDS", out var HISCOBPR_IMPAMDS) && HISCOBPR_IMPAMDS == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPDH", out var HISCOBPR_IMPDH) && HISCOBPR_IMPDH == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPDIT", out var HISCOBPR_IMPDIT) && HISCOBPR_IMPDIT == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VLPREMIO", out var HISCOBPR_VLPREMIO) && HISCOBPR_VLPREMIO == "0000000000200.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_PRMVG", out var HISCOBPR_PRMVG) && HISCOBPR_PRMVG == "0000000000200.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_PRMAP", out var HISCOBPR_PRMAP) && HISCOBPR_PRMAP == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_QTDE_TIT_CAPITALIZ", out var HISCOBPR_QTDE_TIT_CAPITALIZ) && HISCOBPR_QTDE_TIT_CAPITALIZ == "0000");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VAL_TIT_CAPITALIZ", out var HISCOBPR_VAL_TIT_CAPITALIZ) && HISCOBPR_VAL_TIT_CAPITALIZ == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VAL_CUSTO_CAPITALI", out var HISCOBPR_VAL_CUSTO_CAPITALI) && HISCOBPR_VAL_CUSTO_CAPITALI == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPSEGCDG", out var HISCOBPR_IMPSEGCDG) && HISCOBPR_IMPSEGCDG == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VLCUSTCDG", out var HISCOBPR_VLCUSTCDG) && HISCOBPR_VLCUSTCDG == "0000000000000.00");

                Assert.True(program.RETURN_CODE == 0);
           
               //Assert.True(true);

            }
        }


        [Fact]
        public static void VG1652B_Tests99_Fact()
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

                //*******************************
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VG" , "0"},
                { "PARAMRAM_RAMO_AP" , "82"},
                 });
                AppSettings.TestSet.DynamicData.Remove("R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_SELECT_PARAMRAM_DB_SELECT_1_Query1", q0);
                //******************
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_HOJE" , "2025-02-07"},
                { "WHOST_DATA_HOJE_MAIS15" , "2025-02-22"},
                { "WHOST_DIA_HOJE_MAIS15" , "22"},
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "WHOST_DATA_FATURAMENTO" , "2025-01-27"},
                { "WHOST_DTTERVIG" , "2025-02-28"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q1);
                //*******************
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , "1"},
                { "SUBGVGAP_TIPO_FATURAMENTO" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q10);

                //******************
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123456789"},
                { "PROPOVA_NUM_APOLICE" , "93010000890"},
                { "PROPOVA_COD_SUBGRUPO" , "13"},
                { "PROPOVA_NUM_PARCELA" , "118"},
                { "PROPOVA_OCORR_HISTORICO" , "1"},
                { "PROPOVA_DTPROXVEN" , ""},
               });
                AppSettings.TestSet.DynamicData.Remove("VG1652B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VG1652B_CPROPOVA", q2);

                //*************************
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_ITEM" , "23295"},
                { "SEGURVGA_OCORR_HISTORICO" , "4"},
                { "SEGURVGA_NUM_CERTIFICADO" , "7457254811"},
                { "WHOST_NUM_PARCELA" , "22"},
                { "MOVIMVGA_COD_FONTE" , "5"},
                { "MOVIMVGA_NUM_PROPOSTA" , "13744336"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1652B_SEGURVGA1");
                AppSettings.TestSet.DynamicData.Add("VG1652B_SEGURVGA1", q3);
                //************************

                var q4 = new DynamicData();
                /*q4.AddDynamic(new Dictionary<string, string>{
              { "HISCOBPR_NUM_CERTIFICADO" , ""}              
               } , new SQLCA(100) ); */
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);
                //***************************************************
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , "200"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1", q8);
                //************************************************
                //Erro 99
                var q7 = new DynamicData();
                /* q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , "21"}
                 });*/
                AppSettings.TestSet.DynamicData.Remove("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q7);
                //*************************************************
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1", q9);
                #endregion

                var program = new VG1652B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                /*var envList1 = AppSettings.TestSet.DynamicData["R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("HISCONPA_NUM_ENDOSSO", out var HISCONPA_NUM_ENDOSSO) && HISCONPA_NUM_ENDOSSO == "-00202502");
                Assert.True(envList1[1].TryGetValue("WHOST_DATA_FAT_FIM", out var WHOST_DATA_FAT_FIM) && WHOST_DATA_FAT_FIM == "2025-01-27");
                Assert.True(envList1[1].TryGetValue("SEGURVGA_NUM_CERTIFICADO", out var SEGURVGA_NUM_CERTIFICADO) && SEGURVGA_NUM_CERTIFICADO == "000007457254811");
                Assert.True(envList1[1].TryGetValue("WHOST_NUM_PARCELA", out var WHOST_NUM_PARCELA) && WHOST_NUM_PARCELA == "0022");

                //**************************************************************************************************************
                var envList2 = AppSettings.TestSet.DynamicData["R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2025-01-27");
                Assert.True(envList2[1].TryGetValue("VIND_DATA_FATURA_U", out var VIND_DATA_FATURA_U) && VIND_DATA_FATURA_U == "0000");
                Assert.True(envList2[1].TryGetValue("MOVIMVGA_NUM_PROPOSTA", out var MOVIMVGA_NUM_PROPOSTA) && MOVIMVGA_NUM_PROPOSTA == "013744336");
                Assert.True(envList2[1].TryGetValue("MOVIMVGA_COD_FONTE", out var MOVIMVGA_COD_FONTE) && MOVIMVGA_COD_FONTE == "0005");
                //***************************************************************************************************************
                var envList3 = AppSettings.TestSet.DynamicData["R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("WHOST_DTINIVIG", out var WHOST_DTINIVIG) && WHOST_DTINIVIG == "2025-02-01");
                Assert.True(envList3[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var PROPOVA_NUM_CERTIFICADO) && PROPOVA_NUM_CERTIFICADO == "000000123456789");
                Assert.True(envList3[1].TryGetValue("PROPOVA_OCORR_HISTORICO", out var PROPOVA_OCORR_HISTORICO) && PROPOVA_OCORR_HISTORICO == "0001");
                //**************************************************************************************************************
                var envList4 = AppSettings.TestSet.DynamicData["R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var NUM_CERTIFICADO) && NUM_CERTIFICADO == "000000123456789");
                Assert.True(envList4[1].TryGetValue("PROPOVA_OCORR_HISTORICO", out var OCORR_HISTORICO) && OCORR_HISTORICO == "0001");
                //**************************************************************************************************************
                var envList5 = AppSettings.TestSet.DynamicData["R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                Assert.True(envList5[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var HISCOBPR_OCORR_HISTORICO) && HISCOBPR_OCORR_HISTORICO == "0002");
                Assert.True(envList5[1].TryGetValue("PROPOVA_DTPROXVEN", out var PROPOVA_DTPROXVEN) && PROPOVA_DTPROXVEN == "2025-02-00");
                Assert.True(envList5[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var CERTIFICADO) && CERTIFICADO == "000000123456789");
                //********************************************************************
                var envList6 = AppSettings.TestSet.DynamicData["R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var INC_CERTIFICADO) && INC_CERTIFICADO == "000000123456789");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_OCORR_HISTORICO", out var INC_OCORR_HISTORICO) && INC_OCORR_HISTORICO == "0002");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_DATA_INIVIGENCIA", out var HISCOBPR_DATA_INIVIGENCIA) && HISCOBPR_DATA_INIVIGENCIA == "2025-02-01");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_DATA_TERVIGENCIA", out var HISCOBPR_DATA_TERVIGENCIA) && HISCOBPR_DATA_TERVIGENCIA == "9999-12-31");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPSEGUR", out var HISCOBPR_IMPSEGUR) && HISCOBPR_IMPSEGUR == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_QUANT_VIDAS", out var HISCOBPR_QUANT_VIDAS) && HISCOBPR_QUANT_VIDAS == "000000001");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPSEGIND", out var HISCOBPR_IMPSEGIND) && HISCOBPR_IMPSEGIND == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_COD_OPERACAO", out var HISCOBPR_COD_OPERACAO) && HISCOBPR_COD_OPERACAO == "0801");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMP_MORNATU", out var HISCOBPR_IMP_MORNATU) && HISCOBPR_IMP_MORNATU == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPMORACID", out var HISCOBPR_IMPMORACID) && HISCOBPR_IMPMORACID == "0000000000021.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPINVPERM", out var HISCOBPR_IMPINVPERM) && HISCOBPR_IMPINVPERM == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPAMDS", out var HISCOBPR_IMPAMDS) && HISCOBPR_IMPAMDS == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPDH", out var HISCOBPR_IMPDH) && HISCOBPR_IMPDH == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPDIT", out var HISCOBPR_IMPDIT) && HISCOBPR_IMPDIT == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VLPREMIO", out var HISCOBPR_VLPREMIO) && HISCOBPR_VLPREMIO == "0000000000200.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_PRMVG", out var HISCOBPR_PRMVG) && HISCOBPR_PRMVG == "0000000000200.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_PRMAP", out var HISCOBPR_PRMAP) && HISCOBPR_PRMAP == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_QTDE_TIT_CAPITALIZ", out var HISCOBPR_QTDE_TIT_CAPITALIZ) && HISCOBPR_QTDE_TIT_CAPITALIZ == "0000");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VAL_TIT_CAPITALIZ", out var HISCOBPR_VAL_TIT_CAPITALIZ) && HISCOBPR_VAL_TIT_CAPITALIZ == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VAL_CUSTO_CAPITALI", out var HISCOBPR_VAL_CUSTO_CAPITALI) && HISCOBPR_VAL_CUSTO_CAPITALI == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_IMPSEGCDG", out var HISCOBPR_IMPSEGCDG) && HISCOBPR_IMPSEGCDG == "0000000000000.00");
                Assert.True(envList6[1].TryGetValue("HISCOBPR_VLCUSTCDG", out var HISCOBPR_VLCUSTCDG) && HISCOBPR_VLCUSTCDG == "0000000000000.00");*/

                Assert.True(program.RETURN_CODE == 99);

                //Assert.True(true);

            }
        }

    }
}