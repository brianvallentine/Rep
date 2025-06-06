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
using static Code.EM0015B;

namespace FileTests.Test
{
    [Collection("EM0015B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0015B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SISTE_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region EM0015B_V0EMISDIARIA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0EMISD_NUM_APOLICE" , ""},
                { "V0EMISD_NRENDOS" , ""},
                { "V0EMISD_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0015B_V0EMISDIARIA", q1);

            #endregion

            #region EM0015B_V0HISTOPARC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HISTO_NRPARCEL" , ""},
                { "V0HISTO_DTMOVTO" , ""},
                { "V0HISTO_VLPRMTOT" , ""},
                { "V0HISTO_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0015B_V0HISTOPARC", q2);

            #endregion

            #region EM0015B_V0APOLINDICA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0APOIN_FONTE" , ""},
                { "V0APOIN_NRPROPOS" , ""},
                { "V0APOIN_DTINIVIG" , ""},
                { "V0APOIN_DTTERVIG" , ""},
                { "V0APOIN_TIPOFUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0015B_V0APOLINDICA", q3);

            #endregion

            #region R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDOS_COD_EMPRESA" , ""},
                { "V0ENDOS_NRPROPOS" , ""},
                { "V0ENDOS_FONTE" , ""},
                { "V0ENDOS_DTINIVIG" , ""},
                { "V0ENDOS_DTTERVIG" , ""},
                { "V0ENDOS_TIPO_ENDOSSO" , ""},
                { "V0ENDOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROPC_FONTE" , ""},
                { "V0PROPC_CODPRODU" , ""},
                { "V0PROPC_NUM_MATRICULA" , ""},
                { "V0PROPC_COD_AGENCIA" , ""},
                { "V0PROPC_OPERACAO_CONTA" , ""},
                { "V0PROPC_NUM_CONTA" , ""},
                { "V0PROPC_DIG_CONTA" , ""},
                { "V0PROPC_TIPO_COBRANCA" , ""},
                { "V0PROPC_COD_AGENCIA_DEB" , ""},
                { "V0PROPC_OPER_CONTA_DEB" , ""},
                { "V0PROPC_NUM_CONTA_DEB" , ""},
                { "V0PROPC_DIG_CONTA_DEB" , ""},
                { "V0PROPC_DIA_DEBITO" , ""},
                { "V0PROPC_NRCERTIF_AUTO" , ""},
                { "V0PROPC_NUM_CARTAO" , ""},
                { "V0PROPC_MARGEM_COMERCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0PROPO_AGECOBR" , ""},
                { "V0PROPO_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0APOLC_COD_EMPRESA" , ""},
                { "V0APOLC_FONTE" , ""},
                { "V0APOLC_NUM_APOLICE" , ""},
                { "V0APOLC_NRENDOS" , ""},
                { "V0APOLC_CODPRODU" , ""},
                { "V0APOLC_NUM_MATRICULA" , ""},
                { "V0APOLC_TIPO_COBRANCA" , ""},
                { "V0APOLC_AGECOBR" , ""},
                { "V0APOLC_COD_AGENCIA" , ""},
                { "V0APOLC_OPER_CONTA" , ""},
                { "V0APOLC_NUM_CONTA" , ""},
                { "V0APOLC_DIG_CONTA" , ""},
                { "V0APOLC_COD_AGENCIA_DEB" , ""},
                { "V0APOLC_OPER_CONTA_DEB" , ""},
                { "V0APOLC_NUM_CONTA_DEB" , ""},
                { "V0APOLC_DIG_CONTA_DEB" , ""},
                { "V0APOLC_NUM_CARTAO" , ""},
                { "V0APOLC_DIA_DEBITO" , ""},
                { "V0APOLC_NRCERTIF_AUTO" , ""},
                { "V0APOLC_MARGEM_COMERCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "AU085_IND_FORMA_PAGTO_AD" , ""},
                { "AU085_COD_PARCEIRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "WHOST_NUM_APOLICE" , ""},
                { "WHOST_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0PARAMC_COD_CONVENIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0EMISD_SITUACAO" , ""},
                { "V0EMISD_NUM_APOLICE" , ""},
                { "V0EMISD_CODRELAT" , ""},
                { "V0EMISD_NRPARCEL" , ""},
                { "V0EMISD_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0MOVDE_COD_EMPRESA" , ""},
                { "V0MOVDE_NUM_APOLICE" , ""},
                { "V0MOVDE_NRENDOS" , ""},
                { "V0MOVDE_NRPARCEL" , ""},
                { "V0MOVDE_SIT_COBRANCA" , ""},
                { "V0MOVDE_DTVENCTO" , ""},
                { "V0MOVDE_VLR_DEBITO" , ""},
                { "V0MOVDE_DTMOVTO" , ""},
                { "V0MOVDE_DIA_DEBITO" , ""},
                { "V0MOVDE_COD_AGENCIA_DEB" , ""},
                { "V0MOVDE_OPER_CONTA_DEB" , ""},
                { "V0MOVDE_NUM_CONTA_DEB" , ""},
                { "V0MOVDE_DIG_CONTA_DEB" , ""},
                { "V0MOVDE_COD_CONVENIO" , ""},
                { "V0MOVDE_DTENVIO" , ""},
                { "V0MOVDE_NSAS" , ""},
                { "V0MOVDE_COD_USUARIO" , ""},
                { "V0MOVDE_NUM_CARTAO" , ""},
                { "V0MOVDE_DTCREDITO" , ""},
                { "V0MOVDE_STATUS_CARTAO" , ""},
                { "V0MOVDE_VLR_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0PRODG_COD_PROD_GERENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0541_00_LE_V0PRODGER_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0541_05_LE_V0PRODGER_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0PRODG_COD_PROD_GERENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0541_05_LE_V0PRODGER_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0PRODU_CHPFUN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0541_10_LE_V0PRODUTOR_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0FUNCI_NUM_MATRICULA" , ""},
                { "V0FUNCI_COD_AGENCIA" , ""},
                { "V0FUNCI_OPERACAO_CONTA" , ""},
                { "V0FUNCI_NUM_CONTA" , ""},
                { "V0FUNCI_DIG_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0AGENC_COD_ESCNEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0551_00_LE_V0AGENCIACEF_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0PRODE_NUM_MATRICULA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0552_00_LE_V0PRODESCNEG_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0FUNCI_COD_AGENCIA" , ""},
                { "V0FUNCI_OPERACAO_CONTA" , ""},
                { "V0FUNCI_NUM_CONTA" , ""},
                { "V0FUNCI_DIG_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0APOIN_NUM_APOLICE" , ""},
                { "V0APOIN_NRENDOS" , ""},
                { "V0APOIN_NRPROPOS" , ""},
                { "V0APOIN_TIPOFUNC" , ""},
                { "V0APOIN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_SEQ_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_NUM_TITULO" , ""},
                { "LTMVPROP_IND_TIPO_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2_Query1", q22);

            #endregion

            #region R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1", q23);

            #endregion

            #region R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_VAL_OPERACAO" , ""},
                { "FOLLOUP_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4_Query1", q24);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0015B_Tests_Fact()
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
                AppSettings.TestSet.DynamicData.Remove("R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0ENDOS_COD_EMPRESA" , ""},
                { "V0ENDOS_NRPROPOS" , ""},
                { "V0ENDOS_FONTE" , ""},
                { "V0ENDOS_DTINIVIG" , ""},
                { "V0ENDOS_DTTERVIG" , ""},
                { "V0ENDOS_TIPO_ENDOSSO" , ""},
                { "V0ENDOS_COD_PRODUTO" , "5302"},
                });
                AppSettings.TestSet.DynamicData.Add("R0070_00_LE_V0ENDOSSO_DB_SELECT_1_Query1", q4);

                AppSettings.TestSet.DynamicData.Remove("R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1");
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "AU085_IND_FORMA_PAGTO_AD" , "4"},
                { "AU085_COD_PARCEIRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1", q8);

                AppSettings.TestSet.DynamicData.Remove("EM0015B_V0HISTOPARC");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HISTO_NRPARCEL" , "5"},
                { "V0HISTO_DTMOVTO" , ""},
                { "V0HISTO_VLPRMTOT" , ""},
                { "V0HISTO_DTVENCTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("EM0015B_V0HISTOPARC", q2);

                AppSettings.TestSet.DynamicData.Remove("R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROPC_FONTE" , ""},
                { "V0PROPC_CODPRODU" , ""},
                { "V0PROPC_NUM_MATRICULA" , ""},
                { "V0PROPC_COD_AGENCIA" , ""},
                { "V0PROPC_OPERACAO_CONTA" , ""},
                { "V0PROPC_NUM_CONTA" , ""},
                { "V0PROPC_DIG_CONTA" , ""},
                { "V0PROPC_TIPO_COBRANCA" , "1"},
                { "V0PROPC_COD_AGENCIA_DEB" , ""},
                { "V0PROPC_OPER_CONTA_DEB" , ""},
                { "V0PROPC_NUM_CONTA_DEB" , ""},
                { "V0PROPC_DIG_CONTA_DEB" , ""},
                { "V0PROPC_DIA_DEBITO" , ""},
                { "V0PROPC_NRCERTIF_AUTO" , ""},
                { "V0PROPC_NUM_CARTAO" , ""},
                { "V0PROPC_MARGEM_COMERCIAL" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1", q5);

                #endregion
                var program = new EM0015B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0APOLC_COD_EMPRESA", out string valor) && valor == "000000000");
                Assert.True(envList1[1].TryGetValue("V0EMISD_CODRELAT", out valor) && valor == "EM0015B1");
                Assert.True(envList2[1].TryGetValue("MOVIMCOB_NUM_AVISO", out valor) && valor == "000023000");
                Assert.True(envList3[1].TryGetValue("V0MOVDE_NRPARCEL", out valor) && valor == "0005");
            }
        }
    }
}