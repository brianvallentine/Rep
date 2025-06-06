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
using static Code.VA0806B;

namespace FileTests.Test
{
    [Collection("VA0806B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0806B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0001_00_FITA_CREDITO_DB_INSERT_1_Insert1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "GEARDETA_DTH_ANO_REFERENCIA" , ""},
                { "GEARDETA_DTH_MES_REFERENCIA" , ""},
                { "GEARDETA_DTH_MOVIMENTO" , ""},
                { "GEARDETA_DTH_GERACAO" , ""},
                { "GEARDETA_DTH_RECEPCAO" , ""},
                { "GEARDETA_IND_MEIO_ENVIO" , ""},
                { "GEARDETA_STA_ENVIO_RECEPCAO" , ""},
                { "GEARDETA_COD_TIPO_ARQUIVO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_QTD_REG_REJEITADOS" , ""},
                { "GEARDETA_QTD_REG_ACEITOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0001_00_FITA_CREDITO_DB_INSERT_1_Insert1", q0);

            #endregion

            #region R0020_00_PROCESSA_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "VGFOLLOW_NOM_ARQUIVO" , ""},
                { "VGFOLLOW_SEQ_GERACAO" , ""},
                { "VGFOLLOW_NUM_FITA_CEF" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
                { "VGFOLLOW_COD_CONVENIO" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_COD_BANCO" , ""},
                { "VGFOLLOW_STA_PROCESSAMENTO" , ""},
                { "VGFOLLOW_NUM_VERSAO_LAYOUT" , ""},
                { "VGFOLLOW_REG_LANCAMENTO" , ""},
                { "VGFOLLOW_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_PROCESSA_DB_INSERT_1_Insert1", q1);

            #endregion

            #region R0220_00_PROCESSA_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VGFOLLOW_NOM_ARQUIVO" , ""},
                { "VGFOLLOW_SEQ_GERACAO" , ""},
                { "VGFOLLOW_NUM_FITA_CEF" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
                { "VGFOLLOW_COD_CONVENIO" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_COD_BANCO" , ""},
                { "VGFOLLOW_STA_PROCESSAMENTO" , ""},
                { "VGFOLLOW_NUM_VERSAO_LAYOUT" , ""},
                { "VGFOLLOW_REG_LANCAMENTO" , ""},
                { "VGFOLLOW_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_PROCESSA_DB_INSERT_1_Insert1", q2);

            #endregion

            #region DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1", q3);

            #endregion

            #region DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_DTH_ANO_REFERENCIA" , ""},
                { "GEARDETA_DTH_MES_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1", q4);

            #endregion

            #region DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1", q5);

            #endregion

            #region DB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "GEARDETA_DTH_ANO_REFERENCIA" , ""},
                { "GEARDETA_DTH_MES_REFERENCIA" , ""},
                { "GEARDETA_DTH_MOVIMENTO" , ""},
                { "GEARDETA_DTH_GERACAO" , ""},
                { "GEARDETA_DTH_RECEPCAO" , ""},
                { "GEARDETA_IND_MEIO_ENVIO" , ""},
                { "GEARDETA_STA_ENVIO_RECEPCAO" , ""},
                { "GEARDETA_COD_TIPO_ARQUIVO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_QTD_REG_REJEITADOS" , ""},
                { "GEARDETA_QTD_REG_ACEITOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("DB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_Debito_R6090.txt", "Entrada_Credito_R6090.txt")]
        public static void VA0806B_Tests_Theory_R6090_CreditProcessingSuccess_ReturnCode_0(string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P)
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
                #endregion
                var program = new VA0806B();
                program.Execute(RETDEB_FILE_NAME_P, RETCRE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE ==0);

                //R0001_00_FITA_CREDITO_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R0001_00_FITA_CREDITO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var valor0) && valor0.Contains("R609000"));
                Assert.True(envList0[1].TryGetValue("GEARDETA_DTH_GERACAO", out var valor1) && valor1.Contains("2024-12-02"));
                Assert.True(envList0.Count > 1);

                //R0220_00_PROCESSA_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R0220_00_PROCESSA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out var valor2) && valor2.Contains("080987460000259"));
                Assert.True(envList1[1].TryGetValue("VGFOLLOW_COD_BANCO", out var valor3) && valor3.Contains("0104"));
                Assert.True(envList1.Count > 1);


            }
        }
        [Theory]
        [InlineData("Entrada_Debito_R6088.txt", "Entrada_Credito_R6088.txt")]
        public static void VA0806B_Tests_Theory_R6088_DebitProcessingSuccess_ReturnCode_0(string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P)
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
                #endregion
                var program = new VA0806B();
                program.Execute(RETDEB_FILE_NAME_P, RETCRE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //R0020_00_PROCESSA_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R0020_00_PROCESSA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("VGFOLLOW_NOM_ARQUIVO", out var valor0) && valor0.Contains("R608800"));
                Assert.True(envList0[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out var valor1) && valor1.Contains("000010000088275"));
                Assert.True(envList0.Count > 1);

                //DB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["DB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var valor2) && valor2.Contains("R608800"));
                Assert.True(envList1[1].TryGetValue("GEARDETA_DTH_GERACAO", out var valor3) && valor3.Contains("2024-11-26"));
                Assert.True(envList1.Count > 1);


            }
        }
        [Theory]
        [InlineData("Entrada_Debito_R6090.txt", "Entrada_Credito_R6090_Erro.txt")]
        public static void VA0806B_Tests_Theory_R6090_CreditProcessingErro_ReturnCode_9(string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P)
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
                #endregion
                var program = new VA0806B();
                program.Execute(RETDEB_FILE_NAME_P, RETCRE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);

            }
        }
    }
}