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
using static Code.BI0027B;

namespace FileTests.Test
{
    [Collection("BI0027B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0027B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region BI0027B_CURSOR_BILHETES

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_COD_CLIENTE" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
                { "WS_HOST_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0027B_CURSOR_BILHETES", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DT_FIM" , ""},
                { "WHOST_DT_MOV6MON" , ""},
                { "WHOST_DT_HOJE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SAI0027B.txt")]
        public static void BI0027B_Tests_Theory(string SAI0027B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0027B_FILE_NAME_P = $"{SAI0027B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI0027B_CURSOR_BILHETES

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "95581868800"},
                { "BILHETE_NUM_APOLICE" , "103703574443"},
                { "BILHETE_DATA_QUITACAO" , "2019-03-25"},
                { "BILHETE_SITUACAO" , "R"},
                { "CLIENTES_NOME_RAZAO" , "DEUSDETE DE ARAUJO"},
                { "CLIENTES_CGCCPF" , "147957109"},
                { "CLIENTES_COD_CLIENTE" , "29167080"},
                { "ENDERECO_DDD" , "61"},
                { "ENDERECO_TELEFONE" , "93433355"},
                { "RCAPS_VAL_RCAP" , "60.00"},
                { "RCAPS_NUM_RCAP" , "558186880"},
                { "RCAPS_NUM_PROPOSTA" , "17059261"},
                { "RCAPS_DATA_MOVIMENTO" , "2019-03-25"},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "2019-04-10"},
                { "RCAPCOMP_DATA_RCAP" , "2019-03-25"},
                { "CONVERSI_COD_PRODUTO_SIVPF" , "924102677"},
                { "WS_HOST_PRODU" , "2019-03-29"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI0027B_CURSOR_BILHETES");
                AppSettings.TestSet.DynamicData.Add("BI0027B_CURSOR_BILHETES", q0);

                #endregion

                #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DT_FIM" ,"2019-03-25"},
                { "WHOST_DT_MOV6MON" , "2019-03-25"},
                { "WHOST_DT_HOJE" , "2019-03-25"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new BI0027B();
                program.Execute(SAI0027B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


       



    }
}