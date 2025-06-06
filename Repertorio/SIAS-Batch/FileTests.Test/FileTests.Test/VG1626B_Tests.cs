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
using static Code.VG1626B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG1626B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG1626B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTVENFIM_CN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PRO_VCTO" , ""},
                { "WS_DATA_VCTO" , ""},
                { "WS_DATA_PRO_VCTO_15" , ""},
                { "WS_DATA_GER_VA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MIN_DTPROXVEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1", q3);

            #endregion

            #region VG1626B_CPROPOVA

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1626B_CPROPOVA", q4);

            #endregion

            #region VG1626B_SEGURVGA1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1626B_SEGURVGA1", q5);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_MOVIMVGA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1000_05_DELETE_DB_DELETE_1_Delete1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_05_DELETE_DB_DELETE_1_Delete1", q7);

            #endregion

            #region R1000_05_DELETE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_05_DELETE_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_VENCIMENTO" , ""},
                { "WHOST_NUM_PARCELA" , ""},
                { "WHOST_SIT_PARCELA" , ""},
                { "PARCEVID_PREMIO_VG" , "1"},
                { "PROPOVA_DTPROXVEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q9);

            #endregion

            #region R1000_05_DELETE_DB_UPDATE_2_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "WHOST_DATA_VENCIMENTO" , ""},
                { "WHOST_NUM_PARCELA" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_05_DELETE_DB_UPDATE_2_Update1", q10);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "WHOST_DATA_HISCOBPR" , ""},
                { "WHOST_COD_USUARIO" , ""},
                { "WHOST_PROX_DATA_INIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1", q11);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "WHOST_DATA_HISCOBPR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1", q12);

            #endregion

            #region R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1", q14);

            #endregion

            #region R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "VG098_NUM_TITULO" , ""},
                { "VG098_NUM_SERIE" , ""},
                { "VG098_NUM_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_FORMA_FATURAMENTO" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q18);

            #endregion

            #region R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "VG083_DTA_INI_FATURA" , ""},
                { "VG083_DTA_FIM_FATURA" , ""},
                { "VG083_IND_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_DATA_VENCIMENTO" , ""},
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q20);

            #endregion

            #region R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
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
                { "HISCOBPR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "WS_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q25);

            #endregion

            #region R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "WHOST_IMPSEG" , ""},
                { "WHOST_QTDSEG" , ""},
                { "WHOST_PRMVG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1", q26);

            #endregion

            #region R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PREMIO_VG" , ""},
                { "WHOST_PREMIO_AP" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1", q27);

            #endregion

            #region R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PRMVG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PRMVG" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1", q29);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VG1626BO_OUTPUT_2025031417160000", "VG1626BO_OUTPUT_2025031417160001")]
        public static void VG1626B_Tests_Theory(string VG1626BO_FILE_NAME_P, string VG1626BD_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                PROSOCU1_Tests.Load_Parameters();
                VG0710S_Tests.Load_Parameters();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                //var q21 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1");
                //AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1", q21);

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "0000-00-00"},
                    { "V1SIST_DTVENFIM_CN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_MIN_DTPROXVEN" , "2025-03-14"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1", q3);

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""},
                    { "PROPOVA_NUM_APOLICE" , "0108211311837"},
                    { "PROPOVA_COD_SUBGRUPO" , ""},
                    { "PROPOVA_NUM_PARCELA" , ""},
                    { "PROPOVA_OCORR_HISTORICO" , ""},
                    { "PROPOVA_DTPROXVEN" , "2025-03-14"},
                });
                AppSettings.TestSet.DynamicData.Remove("VG1626B_CPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VG1626B_CPROPOVA", q4);

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_DATA_VENCIMENTO" , ""},
                    { "WHOST_NUM_PARCELA" , ""},
                    { "WHOST_SIT_PARCELA" , ""},
                    { "PARCEVID_PREMIO_VG" , "1"},
                    { "PROPOVA_DTPROXVEN" , "2025-03-14"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1", q9);

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_OCORR_HISTORICO" , ""},
                    { "WHOST_DATA_VENCIMENTO" , ""},
                    { "WHOST_NUM_PARCELA" , ""},
                    { "PROPOVA_DTPROXVEN" , "2025-03-14"},
                    { "PROPOVA_NUM_CERTIFICADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_05_DELETE_DB_UPDATE_2_Update1");
                AppSettings.TestSet.DynamicData.Add("R1000_05_DELETE_DB_UPDATE_2_Update1", q10);

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "APOLICOB_IMP_SEGURADA_IX" , "1000"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q13);

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "VG083_DTA_INI_FATURA" , "1997-01-01"},
                    { "VG083_DTA_FIM_FATURA" , ""},
                    { "VG083_IND_PROCESSAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1", q19);

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "PARCEVID_DATA_VENCIMENTO" , ""},
                    { "PARCEVID_PREMIO_VG" , "1"},
                    { "PARCEVID_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q20);

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_APOLICE" , "0108211311837"},
                    { "WS_COD_SUBGRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1", q22);
                #endregion

                var program = new VG1626B();
                program.Execute(VG1626BO_FILE_NAME_P, VG1626BD_FILE_NAME_P);

                Assert.True(File.Exists(program.VG1626BD.FilePath));
                Assert.True(new FileInfo(program.VG1626BD.FilePath).Length > 1);

                Assert.True(File.Exists(program.VG1626BO.FilePath));
                Assert.True(new FileInfo(program.VG1626BO.FilePath).Length > 1);

                var select1 = AppSettings.TestSet.DynamicData["R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select1);

                var select2 = AppSettings.TestSet.DynamicData["R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select2);

                var select3 = AppSettings.TestSet.DynamicData["R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select3);

                var select4 = AppSettings.TestSet.DynamicData["R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select4);

                var select5 = AppSettings.TestSet.DynamicData["VG1626B_CPROPOVA"].DynamicList;
                Assert.Empty(select5);

                var select6 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select6);

                var select7 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1"].DynamicList;
                Assert.Empty(select7);

                var select8 = AppSettings.TestSet.DynamicData["R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1"].DynamicList;
                Assert.Empty(select8);

                var select9 = AppSettings.TestSet.DynamicData["R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select9);

                var select10 = AppSettings.TestSet.DynamicData["R2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select9);

                var select11 = AppSettings.TestSet.DynamicData["R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select11);

                var select12 = AppSettings.TestSet.DynamicData["R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select12);

                var select13 = AppSettings.TestSet.DynamicData["R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(select13);

                var delete1 = AppSettings.TestSet.DynamicData["R1000_05_DELETE_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(delete1);

                var update1 = AppSettings.TestSet.DynamicData["R1000_05_DELETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.NotEmpty(update1);
                Assert.True(update1[^1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out string value) && value.Contains("000000000000000"));
                Assert.True(update1[^1].TryGetValue("UpdateCheck", out string check) && check.Contains("UpdateCheck"));

                var update2 = AppSettings.TestSet.DynamicData["R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.NotEmpty(update1);
                Assert.True(update1[^1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out string value1) && value1.Contains("000000000000000"));
                Assert.True(update1[^1].TryGetValue("UpdateCheck", out string check1) && check1.Contains("UpdateCheck"));

                var insert1 = AppSettings.TestSet.DynamicData["R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.NotEmpty(insert1);
                Assert.True(insert1[^1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out string value2) && value2.Contains("000000000000000"));
                Assert.True(insert1[^1].TryGetValue("HISCOBPR_COD_OPERACAO", out string value3) && value3.Contains("0801"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VG1626BO_OUTPUT_2025031417160002", "VG1626BO_OUTPUT_2025031417160003")]
        public static void VG1626B_Tests_Theory_StatusCode99(string VG1626BO_FILE_NAME_P, string VG1626BD_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();

                PROSOCU1_Tests.Load_Parameters();

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "0000-00-00"},
                    { "V1SIST_DTVENFIM_CN" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VG1626B();
                program.Execute(VG1626BO_FILE_NAME_P, VG1626BD_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}