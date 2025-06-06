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
using static Code.VA0133B;

namespace FileTests.Test
{
    [Collection("VA0133B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0133B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA0133B_C01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_CODRET" , ""},
                { "HISLANCT_TIPLANC" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "CLIENEMA_EMAIL" , ""},
                { "DB2_COD_SUSEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0133B_C01", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("WS_DTPARM_P", "VA0133B1", "VA0133B2")]
        public static void VA0133B_Tests_Theory(string WS_DTPARM_P, string VA0133B1_FILE_NAME_P, string VA0133B2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WS_DTPARM_P = $"{WS_DTPARM_P}_{timestamp}.txt";
            VA0133B1_FILE_NAME_P = $"{VA0133B1_FILE_NAME_P}_{timestamp}.txt";
            VA0133B2_FILE_NAME_P = $"{VA0133B2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0133B_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "97010000889"},
                { "HISLANCT_SIT_REGISTRO" , "10000243107"},
                { "HISLANCT_CODRET" , "0"},
                { "HISLANCT_TIPLANC" , "2"},
                { "HISLANCT_NUM_PARCELA" , "6090"},
                { "HISLANCT_PRM_TOTAL" , "1"},
                { "HISLANCT_DATA_VENCIMENTO" , "337"},
                { "PROPOVA_COD_PRODUTO" , "2022-12-28"},
                { "PROPOVA_COD_CLIENTE" , "9701"},
                { "PROPOVA_NUM_APOLICE" , "4"},
                { "PROPOVA_NUM_PARCELA" , "526746"},
                { "PROPOVA_SIT_REGISTRO" , "16325559800"},
                { "CLIENTES_CGCCPF" , "ALBERTO PICCOLI FILHO"},
                { "CLIENTES_NOME_RAZAO" , "13"},
                { "ENDERECO_OCORR_ENDERECO" , "32231080"},
                { "ENDERECO_ENDERECO" , "AVDOUTOR BERNARDINO DE CAMPOS 437 AP 95"},
                { "ENDERECO_BAIRRO" , "CAMPO GRANDE"},
                { "ENDERECO_CIDADE" , "SANTOS"},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "11065003"},
                { "ENDERECO_DDD" , "13"},
                { "ENDERECO_TELEFONE" , "32231080"},
                { "CLIENEMA_EMAIL" , "albertopiccoli2016@bol.com.br"},
                { "DB2_COD_SUSEP" , "10.002684/01-29"},
            });
                AppSettings.TestSet.DynamicData.Remove("VA0133B_C01");
                AppSettings.TestSet.DynamicData.Add("VA0133B_C01", q0);

                #endregion
                #endregion
                var program = new VA0133B();
                program.Execute(new StringBasis(null, WS_DTPARM_P), VA0133B1_FILE_NAME_P, VA0133B2_FILE_NAME_P);


                var envList1 = AppSettings.TestSet.DynamicData["VA0133B_C01"].DynamicList;
                Assert.Empty(envList1);


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("WS_DTPARM_P", "VA0133B1", "VA0133B2")]
        public static void VA0133B_Tests99_Theory(string WS_DTPARM_P, string VA0133B1_FILE_NAME_P, string VA0133B2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WS_DTPARM_P = $"{WS_DTPARM_P}_{timestamp}.txt";
            VA0133B1_FILE_NAME_P = $"{VA0133B1_FILE_NAME_P}_{timestamp}.txt";
            VA0133B2_FILE_NAME_P = $"{VA0133B2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0133B_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_SIT_REGISTRO" , "10000243107"},
                { "HISLANCT_CODRET" , "0"},
                { "HISLANCT_TIPLANC" , "2"},
                { "HISLANCT_NUM_PARCELA" , "6090"},
                { "HISLANCT_PRM_TOTAL" , "1"},
                { "HISLANCT_DATA_VENCIMENTO" , "337"},
                { "PROPOVA_COD_PRODUTO" , "2022-12-28"},
                { "PROPOVA_COD_CLIENTE" , "9701"},
                { "PROPOVA_NUM_APOLICE" , "4"},
                { "PROPOVA_NUM_PARCELA" , "526746"},
                { "PROPOVA_SIT_REGISTRO" , "16325559800"},
                { "CLIENTES_CGCCPF" , "ALBERTO PICCOLI FILHO"},
                { "CLIENTES_NOME_RAZAO" , "13"},
                { "ENDERECO_OCORR_ENDERECO" , "32231080"},
                { "ENDERECO_ENDERECO" , "AVDOUTOR BERNARDINO DE CAMPOS 437 AP 95"},
                { "ENDERECO_BAIRRO" , "CAMPO GRANDE"},
                { "ENDERECO_CIDADE" , "SANTOS"},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "11065003"},
                { "ENDERECO_DDD" , "13"},
                { "ENDERECO_TELEFONE" , "32231080"},
                { "CLIENEMA_EMAIL" , "albertopiccoli2016@bol.com.br"},
                { "DB2_COD_SUSEP" , "10.002684/01-29"},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VA0133B_C01");
                AppSettings.TestSet.DynamicData.Add("VA0133B_C01", q0);

                #endregion
                #endregion
                var program = new VA0133B();
                program.Execute(new StringBasis(null, WS_DTPARM_P), VA0133B1_FILE_NAME_P, VA0133B2_FILE_NAME_P);

                Assert.True(program.VARDISP.WSS_COD_SQLC != 00);
            }
        }

    }
}