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
using static Code.VA0506B;

namespace FileTests.Test
{
    [Collection("VA0506B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0506B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0506B_V0FUNDO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FUNCOMVA_CODIGO_PRODUTO" , ""},
                { "FUNCOMVA_NUM_CERTIFICADO" , ""},
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
                { "FUNCOMVA_NUM_APOLICE" , ""},
                { "FUNCOMVA_COD_SUBGRUPO" , ""},
                { "FUNCOMVA_NUM_ENDOSSO" , ""},
                { "FUNCOMVA_NUM_TITULO" , ""},
                { "FUNCOMVA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0506B_V0FUNDO", q1);

            #endregion

            #region VA0506B_V0COBERAPOL

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0506B_V0COBERAPOL", q2);

            #endregion

            #region R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_COD_PRODUTO" , ""},
                { "PARAMPRO_VALOR_COMISSAO_PRD" , ""},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PCTCOBER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FUNCOMVA_NUM_MATRI_VENDEDOR" , ""},
                { "FUNCOMVA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1", q8);

            #endregion

            #region VA0506B_V0HISCONPA

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_COD_FONTE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "HISCONPA_DTFATUR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0506B_V0HISCONPA", q9);

            #endregion

            #region R3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
                { "COMISSOE_DATA_MOVIMENTO" , ""},
                { "COMISSOE_DATA_SELECAO" , ""},
                { "COMISSOE_COD_EMPRESA" , ""},
                { "COMISSOE_COD_PREPOSTO" , ""},
                { "COMISSOE_NUM_BILHETE" , ""},
                { "COMISSOE_VAL_VARMON" , ""},
                { "COMISSOE_DATA_QUITACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COMISSOE_NUM_RECIBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1", q11);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0506B_Tests_Fact_Update_ReturnCode_00()
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

                #region VA0506B_V0FUNDO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FUNCOMVA_CODIGO_PRODUTO" , ""},
                { "FUNCOMVA_NUM_CERTIFICADO" , ""},
                { "FUNCOMVA_NUM_TERMO" , ""},
                { "FUNCOMVA_SITUACAO" , "1"},
                { "FUNCOMVA_COD_OPERACAO" , ""},
                { "FUNCOMVA_COD_FONTE" , ""},
                { "FUNCOMVA_COD_AGENCIA" , ""},
                { "FUNCOMVA_COD_CLIENTE" , ""},
                { "FUNCOMVA_NUM_MATRI_VENDEDOR" , "12"},
                { "FUNCOMVA_VAL_BASICO_VG" , "0"},
                { "FUNCOMVA_VAL_BASICO_AP" , "0"},
                { "FUNCOMVA_VAL_COMISSAO_VG" , ""},
                { "FUNCOMVA_VAL_COMISSAO_AP" , ""},
                { "FUNCOMVA_DATA_QUITACAO" , ""},
                { "FUNCOMVA_PCCOMIND" , ""},
                { "FUNCOMVA_PCCOMGER" , ""},
                { "FUNCOMVA_PCCOMSUP" , ""},
                { "FUNCOMVA_DATA_MOVIMENTO" , ""},
                { "FUNCOMVA_NUM_APOLICE" , ""},
                { "FUNCOMVA_COD_SUBGRUPO" , ""},
                { "FUNCOMVA_NUM_ENDOSSO" , ""},
                { "FUNCOMVA_NUM_TITULO" , ""},
                { "FUNCOMVA_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0506B_V0FUNDO");
                AppSettings.TestSet.DynamicData.Add("VA0506B_V0FUNDO", q1);

                #endregion
                #region VA0506B_V0HISCONPA

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , "1"},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_COD_FONTE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_PREMIO_VG" , "1000"},
                { "HISCONPA_PREMIO_AP" , "2000"},
                { "HISCONPA_DTFATUR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0506B_V0HISCONPA");
                AppSettings.TestSet.DynamicData.Add("VA0506B_V0HISCONPA", q9);

                #endregion

                #region R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , "2016-01-01"},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q5);

                #endregion


                #region R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_COD_PRODUTO" , ""},
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "10"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PCTCOBER" , "100"}
                 });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q7);

                #endregion
                #region R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1", q11);

                #endregion
                #endregion
                var program = new VA0506B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
                //R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("FUNCOMVA_NUM_MATRI_VENDEDOR", out var valor) && valor.Contains("12"));

            }
        }
        [Fact]
        public static void VA0506B_Tests_Fact_Insert_ReturnCode_00()
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

                #region VA0506B_V0FUNDO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FUNCOMVA_CODIGO_PRODUTO" , ""},
                { "FUNCOMVA_NUM_CERTIFICADO" , "100"},
                { "FUNCOMVA_NUM_TERMO" , ""},
                { "FUNCOMVA_SITUACAO" , "1"},
                { "FUNCOMVA_COD_OPERACAO" , ""},
                { "FUNCOMVA_COD_FONTE" , ""},
                { "FUNCOMVA_COD_AGENCIA" , ""},
                { "FUNCOMVA_COD_CLIENTE" , ""},
                { "FUNCOMVA_NUM_MATRI_VENDEDOR" , "12"},
                { "FUNCOMVA_VAL_BASICO_VG" , "1200"},
                { "FUNCOMVA_VAL_BASICO_AP" , "1300"},
                { "FUNCOMVA_VAL_COMISSAO_VG" , ""},
                { "FUNCOMVA_VAL_COMISSAO_AP" , ""},
                { "FUNCOMVA_DATA_QUITACAO" , ""},
                { "FUNCOMVA_PCCOMIND" , ""},
                { "FUNCOMVA_PCCOMGER" , ""},
                { "FUNCOMVA_PCCOMSUP" , ""},
                { "FUNCOMVA_DATA_MOVIMENTO" , ""},
                { "FUNCOMVA_NUM_APOLICE" , ""},
                { "FUNCOMVA_COD_SUBGRUPO" , ""},
                { "FUNCOMVA_NUM_ENDOSSO" , ""},
                { "FUNCOMVA_NUM_TITULO" , ""},
                { "FUNCOMVA_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0506B_V0FUNDO");
                AppSettings.TestSet.DynamicData.Add("VA0506B_V0FUNDO", q1);

                #endregion
                #region R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , "100"},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q3);

                #endregion
                #region VA0506B_V0HISCONPA

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , "1"},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_COD_FONTE" , ""},
                { "HISCONPA_NUM_ENDOSSO" , ""},
                { "HISCONPA_PREMIO_VG" , "1000"},
                { "HISCONPA_PREMIO_AP" , "2000"},
                { "HISCONPA_DTFATUR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0506B_V0HISCONPA");
                AppSettings.TestSet.DynamicData.Add("VA0506B_V0HISCONPA", q9);

                #endregion

                #region R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , "2016-01-01"},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q5);

                #endregion


                #region R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMPRO_COD_PRODUTO" , ""},
                { "PARAMPRO_VALOR_COMISSAO_PRD" , "10"},
                { "PARAMPRO_PERCEN_COMIS_FUNC" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PCTCOBER" , "100"}
                 });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1", q7);

                #endregion
                #region R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1", q11);

                #endregion
                #endregion
                var program = new VA0506B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
                //R3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("COMISSOE_VAL_BASICO", out var valor) && valor.Contains("2500"));
                Assert.True(envList.Count > 1);
            }
        }
        [Fact]
        public static void VA0506B_Tests_Fact_Insert_ReturnCode_99()
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

                #region VA0506B_V0FUNDO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FUNCOMVA_CODIGO_PRODUTO" , ""},
                { "FUNCOMVA_NUM_CERTIFICADO" , "100"},
                { "FUNCOMVA_NUM_TERMO" , ""},
                { "FUNCOMVA_SITUACAO" , "1"},
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
                { "FUNCOMVA_NUM_APOLICE" , ""},
                { "FUNCOMVA_COD_SUBGRUPO" , ""},
                { "FUNCOMVA_NUM_ENDOSSO" , ""},
                { "FUNCOMVA_NUM_TITULO" , ""},
                { "FUNCOMVA_NUM_PARCELA" , ""},
            }, new SQLCA(100));
          
                AppSettings.TestSet.DynamicData.Remove("VA0506B_V0FUNDO");
                AppSettings.TestSet.DynamicData.Add("VA0506B_V0FUNDO", q1);

                #endregion
                               #endregion
                var program = new VA0506B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}