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
using static Code.CB0112B;

namespace FileTests.Test
{
    [Collection("CB0112B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class CB0112B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
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

            #region CB0112B_V0MOVDEBCE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , "19790324"},
                { "MOVDEBCE_NUM_ENDOSSO" , "0"},
                { "MOVDEBCE_NUM_PARCELA" , "3"},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , "2024-12-12"},
                { "MOVDEBCE_VALOR_DEBITO" , "50"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_NSAS" , "852"},
                { "MOVDEBCE_NUM_CARTAO" , "5200325684597888"},
            });
            AppSettings.TestSet.DynamicData.Add("CB0112B_V0MOVDEBCE", q1);

            #endregion

            #region R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_NSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PARAMCON_NSAS" , ""},
                { "WS_NSL" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NSAS" , ""},
                { "VIND_NSAS" , ""},
                { "HISLANCT_NSL" , ""},
                { "VIND_NSL" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_DATA_PROXIMO_DEB" , ""},
                { "PARAMCON_DATA_MOVIMENTO" , ""},
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1", q6);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("MOVIMENTO_FILE_NAME_P", "RCB0112B_FILE_NAME_P")]
        public static void CB0112B_Tests_Theory(string MOVIMENTO_FILE_NAME_P, string RCB0112B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";
            RCB0112B_FILE_NAME_P = $"{RCB0112B_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new CB0112B();
                program.Execute(MOVIMENTO_FILE_NAME_P, RCB0112B_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);

                Assert.True(envList1[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var val1r) && val1r.Equals("000009022"));
                Assert.True(envList2[1].TryGetValue("HISLANCT_NSL", out val1r) && val1r.Equals("000000001"));
                Assert.True(envList3[1].TryGetValue("PARAMCON_TIPO_MOVTO_CC", out val1r) && val1r.Equals("0004"));

            }
        }
    }
}