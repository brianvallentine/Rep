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
using static Code.SI5001B;

namespace FileTests.Test
{
    [Collection("SI5001B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class SI5001B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DATA_CORRENTE" , ""},
                { "HOST_HORA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R010_LE_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q2);

            #endregion

            #region SI5001B_C01_PARAMCON

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_NSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI5001B_C01_PARAMCON", q3);

            #endregion

            #region SI5001B_C01_MOVDEBCE

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI5001B_C01_MOVDEBCE", q4);

            #endregion

            #region R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_DESCR_CONVENIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1", q5);

            #endregion

            #region R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_LOT_FENAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1", q6);

            #endregion

            #region R210_00_VER_COBRANCA_SUSP_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_CONTADOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R210_00_VER_COBRANCA_SUSP_DB_SELECT_2_Query1", q7);

            #endregion

            #region R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R15000_GERA_SAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R15000_GERA_SAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region P7239_SI2_SELECT_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SI239_IDE_SISTEMA" , ""},
                { "SI239_COD_OPERACAO" , ""},
                { "SI239_COD_EVENTO_SAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P7239_SI2_SELECT_DB_SELECT_1_Query1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI5001B_1_t1", "SI5001B_2_t1")]
        public static void SI5001B_Tests_Theory(string MOVDEBITO_CC_FILE_NAME_P, string RSI5001B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVDEBITO_CC_FILE_NAME_P = $"{MOVDEBITO_CC_FILE_NAME_P}_{timestamp}.txt";
            RSI5001B_FILE_NAME_P = $"{RSI5001B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new SI5001B();
                program.Execute(new SI5001B_LINK_PARM_CONV_PROCESSADO(), MOVDEBITO_CC_FILE_NAME_P, RSI5001B_FILE_NAME_P);

                Assert.True(true);
            }
        }
    }
}