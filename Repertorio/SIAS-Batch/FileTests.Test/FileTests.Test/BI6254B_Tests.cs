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
using static Code.BI6254B;

namespace FileTests.Test
{
    [Collection("BI6254B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI6254B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DTMOVABE20" , ""},
                { "WSHOST_DATA_CURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_PROCESSA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_PROCESSA_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI6254B_V0MOVDEBCE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6254B_V0MOVDEBCE", q2);

            #endregion

            #region R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0510_00_SELECT_AU085_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_FONTE" , ""},
                { "PROPOSTA_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "AU085_NUM_TOKEN_PGTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_AU085_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PARAMCON_NSAS" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_QTD_PARCELAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DTMOVABE20" , ""},
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOV023000_00", "BI6254B1_00")]
        public static void BI6254B_Tests_Theory_Erro99(string MOV023000_CC_FILE_NAME_P, string BI6254B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV023000_CC_FILE_NAME_P = $"{MOV023000_CC_FILE_NAME_P}_{timestamp}.txt";
            BI6254B1_FILE_NAME_P = $"{BI6254B1_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new BI6254B();
                program.Execute(MOV023000_CC_FILE_NAME_P, BI6254B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("MOV023000_01", "BI6254B1_01")]
        public static void BI6254B_Tests_Theory(string MOV023000_CC_FILE_NAME_P, string BI6254B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV023000_CC_FILE_NAME_P = $"{MOV023000_CC_FILE_NAME_P}_{timestamp}.txt";
            BI6254B1_FILE_NAME_P = $"{BI6254B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                GEJVS002_Tests.Load_Parameters();
                //GEJVSERR_Tests.Load_Parameters();

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2013-09-13"},
                { "WSHOST_DTMOVABE20" , "2013-10-03"},
                { "WSHOST_DATA_CURRENT" , "2013-09-13"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new BI6254B();
                program.Execute(MOV023000_CC_FILE_NAME_P, BI6254B1_FILE_NAME_P);

                //R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var valor) && valor.Contains("23000"));

                //R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PARAMCON_NSAS", out var valor2) && valor2.Contains("0001"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}