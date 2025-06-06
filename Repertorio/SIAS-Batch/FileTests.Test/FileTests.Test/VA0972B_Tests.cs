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
using static Code.VA0972B;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FileTests.Test
{
    [Collection("VA0972B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0972B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS

            #region VA0972B_TRELAT


            var q00 = new DynamicData();
            q00.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , "12345"},
                { "RELATORI_NUM_APOLICE" , "12"},
                { "RELATORI_COD_SUBGRUPO" , "12"},
                { "RELATORI_NUM_PARCELA" , "1"},
                { "RELATORI_MES_REFERENCIA" , "1"},
                { "RELATORI_ANO_REFERENCIA" , "2020"},
                { "RELATORI_DATA_SOLICITACAO" , "2020-01-01"},
                { "RELATORI_SIT_REGISTRO" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("VA0972B_TRELAT", q00);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q1);

            #endregion

            #region R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q2);

            #endregion

            #region R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_SIT_REGISTRO" , "2"},
                { "PROPOVA_DATA_QUITACAO" , "2020-01-01"},
                { "PROPOVA_COD_PRODUTO" , "12"},
                { "PARCEVID_DATA_VENCIMENTO" , "2020-02-03"},
                { "CLIENTES_NOME_RAZAO" , "asdasd"},
                { "CLIENTES_CGCCPF" , "12312312312"},
                { "CLIENTES_COD_CLIENTE" , "1"},
                { "ENDERECO_DDD" , "45"},
                { "ENDERECO_TELEFONE" , "123213"},
                { "PRODUVG_NOME_PRODUTO" , "adf"},
                { "COBHISVI_PRM_TOTAL" , "123"},
                { "GE407_COD_IDLG" , "23"},
            });
            AppSettings.TestSet.DynamicData.Add("R2040_00_BUSCA_DADOS_A_LISTAR_DB_SELECT_1_Query1", q3);

            #endregion

            #region R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , ""},
                { "COBHISVI_NUM_CERTIFICADO" , ""},
                { "COBHISVI_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_SIT_REGISTRO" , ""},
                { "PARCEVID_NUM_CERTIFICADO" , ""},
                { "PARCEVID_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE407_NUM_OCORR_MOVTO" , "3"},
                { "GE407_SEQ_CONTROL_CARTAO" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE407_DTA_MOVIMENTO" , ""},
                { "GE407_STA_REGISTRO" , ""},
                { "GE407_SEQ_CONTROL_CARTAO" , ""},
                { "GE407_NUM_CERTIFICADO" , ""},
                { "GE407_NUM_OCORR_MOVTO" , ""},
                { "GE407_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("DEVCIELO_FILE_NAME_P")]
        public static void VA0972B_Tests_TheoryErro99(string DEVCIELO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DEVCIELO_FILE_NAME_P = $"{DEVCIELO_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA0972B();
                program.Execute(DEVCIELO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);



                Assert.True(program.RETURN_CODE == 99);


            }
        }
        [Theory]
        [InlineData("DEVCIELO_FILE_NAME_P")]
        public static void VA0972B_Tests_Theory(string DEVCIELO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            DEVCIELO_FILE_NAME_P = $"{DEVCIELO_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0972B();
                program.Execute(DEVCIELO_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                //R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("RELATORI_NUM_CERTIFICADO", out var valOr) && valOr == "000000000000123");
                Assert.True(envList[1].TryGetValue("RELATORI_COD_RELATORIO", out var valSivpf) && valSivpf == "VA0972B ");

                //R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2035_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("RELATORI_NUM_CERTIFICADO", out var val2r) && val2r == "000000000000123");
                Assert.True(envList1[1].TryGetValue("RELATORI_NUM_APOLICE", out var val3f) && val3f == "0000000000012");

                //R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R7020_00_ATUALIZA_HISLANCT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("HISLANCT_NUM_CERTIFICADO", out var val4r) && val4r == "000000000000123");
                Assert.True(envList2[1].TryGetValue("HISLANCT_SIT_REGISTRO", out var val5r) && val5r == "2");

                //R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R7030_00_ATUALIZA_COBHISVI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("COBHISVI_SIT_REGISTRO", out var val6r) && val6r == "7");
                Assert.True(envList3[1].TryGetValue("COBHISVI_NUM_CERTIFICADO", out var val7r) && val7r == "000000000000123");

                //R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1
                var envList5 = AppSettings.TestSet.DynamicData["R7040_00_ATUALIZA_PARCEVID_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("PARCEVID_SIT_REGISTRO", out var val10r) && val10r == "2");
                Assert.True(envList5[1].TryGetValue("PARCEVID_NUM_CERTIFICADO", out var val11r) && val11r == "000000000000123");

                //R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1
                var envList6 = AppSettings.TestSet.DynamicData["R7060_00_ATUALIZA_CONTROLE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("GE407_DTA_MOVIMENTO", out var val12r) && val12r == "2020-01-01");
                Assert.True(envList6[1].TryGetValue("GE407_STA_REGISTRO", out var val13r) && val13r == "J");

                Assert.True(program.RETURN_CODE == 0);

                
            }
        }
    }
}