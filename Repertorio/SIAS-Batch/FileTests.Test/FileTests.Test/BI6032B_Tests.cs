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
using static Code.BI6032B;

namespace FileTests.Test
{
    [Collection("BI6032B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI6032B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , ""},
                { "V1SISTE_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1", q2);

            #endregion

            #region BI6032B_V0RELAT

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELAT_NUM_APOLICE" , ""},
                { "V0RELAT_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6032B_V0RELAT", q3);

            #endregion

            #region BI6032B_V0MOVDE

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6032B_V0MOVDE", q4);

            #endregion

            #region R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0RELAT_QUANTIDADE" , ""},
                { "V0RELAT_SITUACAO" , ""},
                { "V0RELAT_NUM_APOLICE" , ""},
                { "V0RELAT_CODRELAT" , ""},
                { "V0RELAT_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1", q5);

            #endregion

            #region BI6032B_CORIGEM

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("BI6032B_CORIGEM", q6);

            #endregion

            #region R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , ""},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_MATR_IND" , ""},
                { "V1BILH_NUM_APOL" , ""},
                { "V1BILH_AGENCIA_DEB" , ""},
                { "V1BILH_OPERACAO_DEB" , ""},
                { "V1BILH_CONTA_DEB" , ""},
                { "V1BILH_DIGITO_DEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0076_00_LE_PROPOFID_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0076_00_LE_PROPOFID_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0076_00_LE_PROPOFID_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0076_00_LE_PROPOFID_DB_SELECT_2_Query1", q9);

            #endregion

            #region R0077_00_LE_V0RCAP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0077_00_LE_V0RCAP_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0090_00_MAX_PARCELA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0090_00_MAX_PARCELA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0090_00_MAX_PARCELA_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0090_00_MAX_PARCELA_DB_SELECT_2_Query1", q13);

            #endregion

            #region R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1", q15);

            #endregion

            #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_TIPO_MOVTOCC" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_SITUACAO" , ""},
                { "V0PARAMC_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUM_APOL" , ""},
                { "WS_ENDOSSO" , ""},
                { "WS_PARCELA" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "WS_VLPREMIO" , ""},
                { "V1SISTE_DTMOVABE" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V1BILH_AGENCIA_DEB" , ""},
                { "V1BILH_OPERACAO_DEB" , ""},
                { "V1BILH_CONTA_DEB" , ""},
                { "V1BILH_DIGITO_DEB" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1", q18);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVCREDITO", "RBI6032B")]
        public static void BI6032B_Tests_Theory(string MOVCREDITO_CC_FILE_NAME_P, string RBI6032B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVCREDITO_CC_FILE_NAME_P = $"{MOVCREDITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI6032B_FILE_NAME_P = $"{RBI6032B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , "2025-01-01"},
                { "V1SISTE_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "TESTE"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
                { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_DIA_DEBITO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1", q2);

                #endregion

                #region BI6032B_V0RELAT

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELAT_NUM_APOLICE" , ""},
                { "V0RELAT_NRTIT" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("BI6032B_V0RELAT");
                AppSettings.TestSet.DynamicData.Add("BI6032B_V0RELAT", q3);

                #endregion

                #region BI6032B_V0MOVDE

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_DTVENCTO" , "2025-01-01"},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("BI6032B_V0MOVDE");
                AppSettings.TestSet.DynamicData.Add("BI6032B_V0MOVDE", q4);

                #endregion

                #region BI6032B_CORIGEM

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("BI6032B_CORIGEM");
                AppSettings.TestSet.DynamicData.Add("BI6032B_CORIGEM", q6);

                #endregion

                #region R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , "8259298302"},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_MATR_IND" , ""},
                { "V1BILH_NUM_APOL" , "100"},
                { "V1BILH_AGENCIA_DEB" , ""},
                { "V1BILH_OPERACAO_DEB" , ""},
                { "V1BILH_CONTA_DEB" , ""},
                { "V1BILH_DIGITO_DEB" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0076_00_LE_PROPOFID_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0076_00_LE_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0076_00_LE_PROPOFID_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0076_00_LE_PROPOFID_DB_SELECT_2_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0076_00_LE_PROPOFID_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0076_00_LE_PROPOFID_DB_SELECT_2_Query1", q9);

                #endregion

                #region R0077_00_LE_V0RCAP_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_OPERACAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0077_00_LE_V0RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0077_00_LE_V0RCAP_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_TITULO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0090_00_MAX_PARCELA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WS_PARCELA" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0090_00_MAX_PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_MAX_PARCELA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0090_00_MAX_PARCELA_DB_SELECT_2_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WS_VLPREMIO" , "150"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0090_00_MAX_PARCELA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_MAX_PARCELA_DB_SELECT_2_Query1", q13);

                #endregion

                #region R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WS_ENDOSSO" , "100"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WS_VLPREMIO" , "6501000001"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1", q15);

                #endregion

                #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q16);

                #endregion

                #endregion
                var program = new BI6032B();
                program.Execute(MOVCREDITO_CC_FILE_NAME_P, RBI6032B_FILE_NAME_P);


                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                var envList = AppSettings.TestSet.DynamicData["R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("V0RELAT_QUANTIDADE", out var V0RELAT_QUANTIDADE) && V0RELAT_QUANTIDADE == "0001");
                Assert.True(envList[1].TryGetValue("V0RELAT_SITUACAO", out var V0RELAT_SITUACAO) && V0RELAT_SITUACAO == "1");
                Assert.True(envList[1].TryGetValue("V0RELAT_NUM_APOLICE", out var V0RELAT_NUM_APOLICE) && V0RELAT_NUM_APOLICE == "0000000000000");
                Assert.True(envList[1].TryGetValue("V0RELAT_CODRELAT", out var V0RELAT_CODRELAT) && V0RELAT_CODRELAT == "BI6401B1");
                Assert.True(envList[1].TryGetValue("V0RELAT_NRTIT", out var V0RELAT_NRTIT) && V0RELAT_NRTIT == "0000000000000");

                var envList1 = AppSettings.TestSet.DynamicData["R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V0PARAMC_NSAS", out var V0PARAMC_NSAS) && V0PARAMC_NSAS == "0001");
                Assert.True(envList1[1].TryGetValue("V0PARAMC_TIPO_MOVTOCC", out var V0PARAMC_TIPO_MOVTOCC) && V0PARAMC_TIPO_MOVTOCC == "0001");
                Assert.True(envList1[1].TryGetValue("V0PARAMC_COD_CONVENIO", out var V0PARAMC_COD_CONVENIO) && V0PARAMC_COD_CONVENIO == "000000000");
                Assert.True(envList1[1].TryGetValue("V0PARAMC_SITUACAO", out var V0PARAMC_SITUACAO) && V0PARAMC_SITUACAO == "A");
                Assert.True(envList1[1].TryGetValue("V0PARAMC_CODPRODU", out var V0PARAMC_CODPRODU) && V0PARAMC_CODPRODU == "0000");

                                   
                var envList2 = AppSettings.TestSet.DynamicData["R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("V1BILH_NUM_APOL", out var V1BILH_NUM_APOL) && V1BILH_NUM_APOL == "0000000000100");
                Assert.True(envList2[1].TryGetValue("WS_ENDOSSO", out var WS_ENDOSSO) && WS_ENDOSSO == "000000100");
                Assert.True(envList2[1].TryGetValue("WS_PARCELA", out var WS_PARCELA) && WS_PARCELA == "0000");
                Assert.True(envList2[1].TryGetValue("V0MOVDE_DTVENCTO", out var V0MOVDE_DTVENCTO) && V0MOVDE_DTVENCTO == "0000-00-00");
                Assert.True(envList2[1].TryGetValue("WS_VLPREMIO", out var WS_VLPREMIO) && WS_VLPREMIO == "0006501000001.00");
                Assert.True(envList2[1].TryGetValue("V1SISTE_DTMOVABE", out var V1SISTE_DTMOVABE) && V1SISTE_DTMOVABE == "2025-01-01");
                Assert.True(envList2[1].TryGetValue("V0MOVDE_DIA_DEBITO", out var V0MOVDE_DIA_DEBITO) && V0MOVDE_DIA_DEBITO == "0000");
                Assert.True(envList2[1].TryGetValue("V1BILH_AGENCIA_DEB", out var V1BILH_AGENCIA_DEB) && V1BILH_AGENCIA_DEB == "0000");
                Assert.True(envList2[1].TryGetValue("V1BILH_CONTA_DEB", out var V1BILH_CONTA_DEB) && V1BILH_CONTA_DEB == "0000000000000");
                Assert.True(envList2[1].TryGetValue("V1BILH_DIGITO_DEB", out var V1BILH_DIGITO_DEB) && V1BILH_DIGITO_DEB == "0000");
                Assert.True(envList2[1].TryGetValue("V0PARAMC_COD_CONVENIO", out var V0PARAMC_COD_CONVENIO1) && V0PARAMC_COD_CONVENIO1 == "000000000");
                Assert.True(envList2[1].TryGetValue("V0PARAMC_NSAS", out var V0PARAMC_NSAS1) && V0PARAMC_NSAS1 == "0001");

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("MOVCREDITO", "RBI6032B")]
        public static void BI6032B_Tests99_Theory(string MOVCREDITO_CC_FILE_NAME_P, string RBI6032B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVCREDITO_CC_FILE_NAME_P = $"{MOVCREDITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RBI6032B_FILE_NAME_P = $"{RBI6032B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , ""},
                { "V1SISTE_DTCURRENT" , ""},
                 });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1EMPR_NOM_EMP" , "TESTE"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion

                #region R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_CODPRODU" , ""},
                { "V0PARAMC_COD_CONVENIO" , ""},
               // { "V0PARAMC_NSAS" , ""},
                { "V0PARAMC_DIA_DEBITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1", q2);

                #endregion

                #region BI6032B_V0RELAT

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELAT_NUM_APOLICE" , ""},
                { "V0RELAT_NRTIT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6032B_V0RELAT");
                AppSettings.TestSet.DynamicData.Add("BI6032B_V0RELAT", q3);

                #endregion

                #region BI6032B_V0MOVDE

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_DTVENCTO" , "2025-01-01"},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6032B_V0MOVDE");
                AppSettings.TestSet.DynamicData.Add("BI6032B_V0MOVDE", q4);

                #endregion

                #region BI6032B_CORIGEM

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("BI6032B_CORIGEM");
                AppSettings.TestSet.DynamicData.Add("BI6032B_CORIGEM", q6);

                #endregion

                #region R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1BILH_NUMBIL" , "8259298302"},
                { "V1BILH_COD_CLIENTE" , ""},
                { "V1BILH_MATR_IND" , ""},
                { "V1BILH_NUM_APOL" , "100"},
                { "V1BILH_AGENCIA_DEB" , ""},
                { "V1BILH_OPERACAO_DEB" , ""},
                { "V1BILH_CONTA_DEB" , ""},
                { "V1BILH_DIGITO_DEB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0076_00_LE_PROPOFID_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0076_00_LE_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0076_00_LE_PROPOFID_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0076_00_LE_PROPOFID_DB_SELECT_2_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_ORIGEM_PROPOSTA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0076_00_LE_PROPOFID_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0076_00_LE_PROPOFID_DB_SELECT_2_Query1", q9);

                #endregion

                #region R0077_00_LE_V0RCAP_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0077_00_LE_V0RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0077_00_LE_V0RCAP_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_TITULO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0090_00_MAX_PARCELA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WS_PARCELA" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0090_00_MAX_PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_MAX_PARCELA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0090_00_MAX_PARCELA_DB_SELECT_2_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WS_VLPREMIO" , "150"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0090_00_MAX_PARCELA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0090_00_MAX_PARCELA_DB_SELECT_2_Query1", q13);

                #endregion

                #region R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WS_ENDOSSO" , "100"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WS_VLPREMIO" , "6501000001"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1", q15);

                #endregion

                #region R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1CLIEN_NOME_RAZAO" , ""}
                 });
                AppSettings.TestSet.DynamicData.Remove("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1", q16);

                #endregion

                #endregion
                var program = new BI6032B();
                program.Execute(MOVCREDITO_CC_FILE_NAME_P, RBI6032B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}