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
using static Code.VA0134B;

namespace FileTests.Test
{
    [Collection("VA0134B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0134B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA0134B_C01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_NUM_APOLICE" , ""},
                { "SEGVGAP_NUM_CERTIFICADO" , ""},
                { "HISLANCT_CODRET" , ""},
                { "HISLANCT_TIPLANC" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "CLIENEMA_EMAIL" , ""},
                { "DB2_COD_SUSEP" , ""},
                { "DB2_SIT_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0134B_C01", q0);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0134B_1_t1", "VA0134B_2_t1", "VA0134B_3_t1")]
        public static void VA0134B_Tests_Theory(string WS_DTPARM_P, string VA0134B1_FILE_NAME_P, string VA0134B2_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            WS_DTPARM_P = $"{WS_DTPARM_P}_{timestamp}.txt";
            VA0134B1_FILE_NAME_P = $"{VA0134B1_FILE_NAME_P}_{timestamp}.txt";
            VA0134B2_FILE_NAME_P = $"{VA0134B2_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0134B_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_NUM_APOLICE" , "109300000559"},
                { "SEGVGAP_NUM_CERTIFICADO" , "10001754696"},
                { "HISLANCT_CODRET" , "0"},
                { "HISLANCT_TIPLANC" , "2"},
                { "HISLANCT_CODCONV" , "6090"},
                { "HISLANCT_SIT_REGISTRO" , "1"},
                { "HISLANCT_NUM_PARCELA" , "240"},
                { "HISLANCT_DATA_VENCIMENTO" , "2021-12-28"},
                { "PROPOVA_COD_PRODUTO" , "9310"},
                { "PROPOVA_SIT_REGISTRO" , "4"},
                { "PROPOVA_COD_CLIENTE" , "1858416"},
                { "CLIENTES_CGCCPF" , "48387037672"},
                { "CLIENTES_NOME_RAZAO" , "MARIA SILVIA ALVES E SILVA"},
                { "ENDERECO_DDD" , "37"},
                { "ENDERECO_TELEFONE" , "32410584"},
                { "ENDERECO_ENDERECO" , "R JOSE FLAVIO AGUILAR 91"},
                { "ENDERECO_BAIRRO" , "LOURDES"},
                { "ENDERECO_CIDADE" , "ITAUNA"},
                { "ENDERECO_SIGLA_UF" , "MG"},
                { "ENDERECO_CEP" , "35680176"},
                { "CLIENEMA_EMAIL" , "M.SILVIAS@UOL.COM.BR"},
                { "DB2_COD_SUSEP" , "15414.001980/2006-77"},
                { "DB2_SIT_COBRANCA" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("VA0134B_C01");
                AppSettings.TestSet.DynamicData.Add("VA0134B_C01", q0);

                #endregion

                #endregion
                var program = new VA0134B();
                program.Execute(new StringBasis(null, WS_DTPARM_P), VA0134B1_FILE_NAME_P, VA0134B2_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["VA0134B_C01"].DynamicList;
                Assert.Empty(envList1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }


        [Theory]
        [InlineData("VA0134B_1_t2", "VA0134B_2_t2", "VA0134B_3_t2")]
        public static void VA0134B_Tests99_Theory(string WS_DTPARM_P, string VA0134B1_FILE_NAME_P, string VA0134B2_FILE_NAME_P)
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
                #region VA0134B_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_NUM_APOLICE" , "109300000559"},
                { "SEGVGAP_NUM_CERTIFICADO" , "10001754696"},
                { "HISLANCT_CODRET" , "0"},
                { "HISLANCT_TIPLANC" , "2"},
                { "HISLANCT_CODCONV" , "6090"},
                { "HISLANCT_SIT_REGISTRO" , "1"},
                { "HISLANCT_NUM_PARCELA" , "240"},
                { "HISLANCT_DATA_VENCIMENTO" , "2021-12-28"},
                { "PROPOVA_COD_PRODUTO" , "9310"},
                { "PROPOVA_SIT_REGISTRO" , "4"},
                { "PROPOVA_COD_CLIENTE" , "1858416"},
                { "CLIENTES_CGCCPF" , "48387037672"},
                { "CLIENTES_NOME_RAZAO" , "MARIA SILVIA ALVES E SILVA"},
                { "ENDERECO_DDD" , "37"},
                { "ENDERECO_TELEFONE" , "32410584"},
                { "ENDERECO_ENDERECO" , "R JOSE FLAVIO AGUILAR 91"},
                { "ENDERECO_BAIRRO" , "LOURDES"},
                { "ENDERECO_CIDADE" , "ITAUNA"},
                { "ENDERECO_SIGLA_UF" , "MG"},
                { "ENDERECO_CEP" , "35680176"},
                { "CLIENEMA_EMAIL" , "M.SILVIAS@UOL.COM.BR"},
                { "DB2_COD_SUSEP" , "15414.001980/2006-77"},
                { "DB2_SIT_COBRANCA" , "0"},
            }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("VA0134B_C01");
                AppSettings.TestSet.DynamicData.Add("VA0134B_C01", q0);

                #endregion

                #endregion
                var program = new VA0134B();
                program.Execute(new StringBasis(null, WS_DTPARM_P), VA0134B1_FILE_NAME_P, VA0134B2_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}