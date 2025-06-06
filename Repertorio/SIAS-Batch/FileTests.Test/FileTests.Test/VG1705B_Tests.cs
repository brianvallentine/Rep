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
using static Code.VG1705B;

namespace FileTests.Test
{
    [Collection("VG1705B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG1705B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG1705B_AGENCTOAPOL

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "AGEAPOVG_NUM_APOLICE" , ""},
                { "AGEAPOVG_COD_SUBGRUPO" , ""},
                { "AGEAPOVG_NUM_PARCELA" , ""},
                { "AGEAPOVG_COD_AGENCIADOR" , ""},
                { "AGEAPOVG_MATRIC_INDICADOR" , ""},
                { "AGEAPOVG_PERC_PAG_PARCELA" , ""},
                { "AGEAPOVG_COD_PAG_ANGARIACAO" , ""},
                { "AGEAPOVG_NUM_ENDOSSO" , ""},
                { "AGEAPOVG_DATA_MOVIMENTO" , ""},
                { "AGEAPOVG_SITUACAO_AGENCTO" , ""},
                { "AGEAPOVG_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1705B_AGENCTOAPOL", q1);

            #endregion

            #region VG1705B_FATURASC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FATURAS_NUM_FATURA" , ""},
                { "FATURAS_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1705B_FATURASC", q2);

            #endregion

            #region M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_TIPO_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1000_CONTINUA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AGEAPOVG_SITUACAO_AGENCTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "AGEAPOVG_NUM_ENDOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_CONTINUA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_AGE_PRODUTORA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_BCO_RCAP" , ""},
                { "ENDOSSOS_AGE_RCAP" , ""},
                { "ENDOSSOS_DAC_RCAP" , ""},
                { "ENDOSSOS_TIPO_RCAP" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_PLANO_SEGURO" , ""},
                { "ENDOSSOS_PCT_ENTRADA" , ""},
                { "ENDOSSOS_PCT_ADIC_FRACIO" , ""},
                { "ENDOSSOS_QTD_DIAS_PRIMEIRA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_QTD_PRESTACOES" , ""},
                { "ENDOSSOS_QTD_ITENS" , ""},
                { "ENDOSSOS_COD_TEXTO_PADRAO" , ""},
                { "ENDOSSOS_COD_ACEITACAO" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_2_Query1", q7);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_3_Query1", q8);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_4_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_4_Query1", q9);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_5_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_5_Query1", q10);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_6_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_6_Query1", q11);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_7_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_7_Query1", q12);

            #endregion

            #region M_2000_LOOP_TIME_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_APOLICE" , ""},
                { "COMISSOE_NUM_ENDOSSO" , ""},
                { "COMISSOE_NUM_CERTIFICADO" , ""},
                { "COMISSOE_DAC_CERTIFICADO" , ""},
                { "COMISSOE_TIPO_SEGURADO" , ""},
                { "COMISSOE_NUM_PARCELA" , ""},
                { "COMISSOE_COD_OPERACAO" , ""},
                { "COMISSOE_COD_PRODUTOR" , ""},
                { "COMISSOE_RAMO_COBERTURA" , ""},
                { "COMISSOE_MODALI_COBERTURA" , ""},
                { "COMISSOE_OCORR_HISTORICO" , ""},
                { "COMISSOE_COD_FONTE" , ""},
                { "COMISSOE_COD_CLIENTE" , ""},
                { "COMISSOE_VAL_COMISSAO" , ""},
                { "COMISSOE_DATA_CALCULO" , ""},
                { "COMISSOE_NUM_RECIBO" , ""},
                { "COMISSOE_VAL_BASICO" , ""},
                { "COMISSOE_TIPO_COMISSAO" , ""},
                { "COMISSOE_QTD_PARCELAS" , ""},
                { "COMISSOE_PCT_COM_CORRETOR" , ""},
                { "COMISSOE_PCT_DESC_PREMIO" , ""},
                { "COMISSOE_COD_SUBGRUPO" , ""},
                { "COMISSOE_HORA_OPERACAO" , ""},
                { "COMISSOE_DATA_SELECAO" , ""},
                { "COMISSOE_DATA_QUITACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_LOOP_TIME_DB_INSERT_1_Insert1", q13);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_8_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_COD_PAG_ANGARIACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_8_Query1", q14);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_9_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_TITULO" , ""},
                { "PARCELAS_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_9_Query1", q15);

            #endregion

            #region M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "FUNCOMVA_CODIGO_PRODUTO" , ""},
                { "FUNCOMVA_NUM_CERTIFICADO" , ""},
                { "FUNCOMVA_NUM_PROPOSTA_AZUL" , ""},
                { "FUNCOMVA_NUM_TERMO" , ""},
                { "FUNCOMVA_SITUACAO" , ""},
                { "FUNCOMVA_COD_OPERACAO" , ""},
                { "FUNCOMVA_COD_FONTE" , ""},
                { "FUNCOMVA_COD_AGENCIA" , ""},
                { "FUNCOMVA_COD_CLIENTE" , ""},
                { "FUNCOMVA_NUM_MATRI_VENDEDOR" , ""},
                { "FUNCOMVA_VAL_BASICO_VG" , ""},
                { "FUNCOMVA_VAL_BASICO_AP" , ""},
                { "FUNCOMVA_VAL_COMISSAO_VG" , ""},
                { "FUNCOMVA_VAL_COMISSAO_AP" , ""},
                { "FUNCOMVA_DATA_QUITACAO" , ""},
                { "FUNCOMVA_PCCOMIND" , ""},
                { "FUNCOMVA_PCCOMGER" , ""},
                { "FUNCOMVA_PCCOMSUP" , ""},
                { "FUNCOMVA_DATA_MOVIMENTO" , ""},
                { "FUNCOMVA_COD_USUARIO" , ""},
                { "FUNCOMVA_NUM_APOLICE" , ""},
                { "FUNCOMVA_COD_SUBGRUPO" , ""},
                { "FUNCOMVA_NUM_ENDOSSO" , ""},
                { "FUNCOMVA_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region M_1500_PROC_FATURAS_DB_SELECT_10_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_DATA_QUITACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_10_Query1", q17);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG1705B_Tests_Fact()
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
                AppSettings.TestSet.DynamicData.Remove("M_1500_PROC_FATURAS_DB_SELECT_1_Query1");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_BCO_RCAP" , ""},
                { "ENDOSSOS_AGE_RCAP" , ""},
                { "ENDOSSOS_DAC_RCAP" , ""},
                { "ENDOSSOS_TIPO_RCAP" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_PLANO_SEGURO" , ""},
                { "ENDOSSOS_PCT_ENTRADA" , ""},
                { "ENDOSSOS_PCT_ADIC_FRACIO" , ""},
                { "ENDOSSOS_QTD_DIAS_PRIMEIRA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_QTD_PRESTACOES" , ""},
                { "ENDOSSOS_QTD_ITENS" , ""},
                { "ENDOSSOS_COD_TEXTO_PADRAO" , ""},
                { "ENDOSSOS_COD_ACEITACAO" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , "1"},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_1_Query1", q6);

                AppSettings.TestSet.DynamicData.Remove("VG1705B_AGENCTOAPOL");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "AGEAPOVG_NUM_APOLICE" , ""},
                { "AGEAPOVG_COD_SUBGRUPO" , ""},
                { "AGEAPOVG_NUM_PARCELA" , ""},
                { "AGEAPOVG_COD_AGENCIADOR" , ""},
                { "AGEAPOVG_MATRIC_INDICADOR" , ""},
                { "AGEAPOVG_PERC_PAG_PARCELA" , ""},
                { "AGEAPOVG_COD_PAG_ANGARIACAO" , "2"},
                { "AGEAPOVG_NUM_ENDOSSO" , ""},
                { "AGEAPOVG_DATA_MOVIMENTO" , ""},
                { "AGEAPOVG_SITUACAO_AGENCTO" , ""},
                { "AGEAPOVG_TIMESTAMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG1705B_AGENCTOAPOL", q1);

                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_TIPO_APOLICE" , "5"}
                });
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1", q2);

                AppSettings.TestSet.DynamicData.Remove("M_1500_PROC_FATURAS_DB_SELECT_2_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_VENDA" , "10"}
                });
                AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_2_Query1", q7);

                AppSettings.TestSet.DynamicData.Remove("M_1500_PROC_FATURAS_DB_SELECT_5_Query1");
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , "10"},
                { "APOLICOB_FATOR_MULTIPLICA" , "10"},
                });
                AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_5_Query1", q10);

                AppSettings.TestSet.DynamicData.Remove("M_1500_PROC_FATURAS_DB_SELECT_6_Query1");
                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_PRM_TARIFARIO_IX" , "11"},
                { "APOLICOB_FATOR_MULTIPLICA" , "11"},
                });
                AppSettings.TestSet.DynamicData.Add("M_1500_PROC_FATURAS_DB_SELECT_6_Query1", q11);
                #endregion
                var program = new VG1705B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["M_1000_CONTINUA_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_2000_LOOP_TIME_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);

                Assert.True(envList[1].TryGetValue("AGEAPOVG_SITUACAO_AGENCTO", out string valor) && valor == "1");
                Assert.True(envList1[1].TryGetValue("COMISSOE_RAMO_COBERTURA", out valor) && valor == "0081");
                Assert.True(envList2[1].TryGetValue("FUNCOMVA_COD_OPERACAO", out valor) && valor == "1101");
            }
        }
    }
}