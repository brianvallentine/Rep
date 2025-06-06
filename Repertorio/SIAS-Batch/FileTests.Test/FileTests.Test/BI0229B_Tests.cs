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
using static Code.BI0229B;

namespace FileTests.Test
{
    [Collection("BI0229B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0229B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI0229B_V0ENDOSSO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                 { "PARCEHIS_NUM_APOLICE" , "106900004697"},
                { "PARCEHIS_NUM_ENDOSSO" , "1"},
                { "PARCEHIS_NUM_PARCELA" , "0"},
                { "PARCEHIS_VAL_IOCC" , "0.68"},
                { "PARCEHIS_PRM_TOTAL" , "180.20"},
                { "ENDOSSOS_RAMO_EMISSOR" , "69"},
                { "ENDOSSOS_COD_PRODUTO" , "6919"},
                { "ENDOSSOS_COD_SUBGRUPO" , "0"},
                { "ENDOSSOS_COD_FONTE" , "5"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "0"},
                { "ENDOSSOS_OCORR_ENDERECO" , "1"},
                { "APOLICES_COD_CLIENTE" , "26495089"},
                { "APOLICES_NUM_BILHETE" , "95537374295"},
                { "APOLICES_TIPO_SEGURO" , "1"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "29999090272407"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "16"},
                { "BILHETE_DATA_QUITACAO" , "2017-08-24"},
            });
            AppSettings.TestSet.DynamicData.Add("BI0229B_V0ENDOSSO", q1);

            #endregion

            #region R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_ENDERECOS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_SEQUENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_COD_EMPRESA" , ""},
                { "CBCONDEV_TIPO_MOVIMENTO" , ""},
                { "CBCONDEV_NUM_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DIG_CHEQUE_INTERNO" , ""},
                { "CBCONDEV_DATA_MOVIMENTO" , ""},
                { "CBCONDEV_NUM_SEQUENCIA" , ""},
                { "CBCONDEV_NUM_TITULO" , ""},
                { "CBCONDEV_COD_FONTE" , ""},
                { "CBCONDEV_NUM_RCAP" , ""},
                { "CBCONDEV_NUM_RCAP_COMPLEMEN" , ""},
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
                { "CBCONDEV_COD_SUBGRUPO" , ""},
                { "CBCONDEV_NUM_CERTIFICADO" , ""},
                { "CBCONDEV_DATA_OCORRENCIA" , ""},
                { "CBCONDEV_NUM_MATRICULA" , ""},
                { "CBCONDEV_RAMO_EMISSOR" , ""},
                { "CBCONDEV_COD_PRODUTO" , ""},
                { "CBCONDEV_COD_FILIAL" , ""},
                { "CBCONDEV_COD_ESCNEG" , ""},
                { "CBCONDEV_AGE_COBRANCA" , ""},
                { "CBCONDEV_TIPO_FAVORECIDO" , ""},
                { "CBCONDEV_COD_FAVORECIDO" , ""},
                { "CBCONDEV_COD_ENDERECO" , ""},
                { "CBCONDEV_OCORR_ENDERECO" , ""},
                { "CBCONDEV_COD_AGENCIA" , ""},
                { "CBCONDEV_OPERACAO_CONTA" , ""},
                { "CBCONDEV_NUM_CONTA" , ""},
                { "CBCONDEV_DIG_CONTA" , ""},
                { "CBCONDEV_SIT_REGISTRO" , ""},
                { "CBCONDEV_DATA_QUITACAO" , ""},
                { "CBCONDEV_VAL_TITULO" , ""},
                { "CBCONDEV_VAL_DESCONTO" , ""},
                { "CBCONDEV_VAL_OPERACAO" , ""},
                { "CBCONDEV_COD_DESPESA" , ""},
                { "CBCONDEV_COD_DEVOLUCAO" , ""},
                { "CBCONDEV_COD_SISTEMA" , ""},
                { "CBCONDEV_COD_USU_SOLICITA" , ""},
                { "CBCONDEV_DATA_CANCELAMENTO" , ""},
                { "CBCONDEV_COD_USU_CANCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }


        [Theory]
        [InlineData("Sort_BI0229B")]
        public static void BI0229B_Tests_Theory_ReturnCode_00(string SBI0229B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI0229B_FILE_NAME_P = $"{SBI0229B_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new BI0229B();
                program.Execute(SBI0229B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);

                //R1250_00_INSERT_CBCONDEV_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R1250_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0.Count > 1);
                Assert.True(envList0[1].TryGetValue("CBCONDEV_NUM_TITULO", out var val0r) && val0r.Contains("0095537374295"));
                Assert.True(envList0[1].TryGetValue("CBCONDEV_NUM_APOLICE", out var val1r) && val1r.Contains("0106900004697"));

            }
        }
        [Theory]
        [InlineData("Sort_BI0229B")]
        public static void BI0229B_Tests_Theory_ReturnCode_99(string SBI0229B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI0229B_FILE_NAME_P = $"{SBI0229B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region BI0229B_V0ENDOSSO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , "106900004697"},
                { "PARCEHIS_NUM_ENDOSSO" , "1"},
                { "PARCEHIS_NUM_PARCELA" , "0"},
                { "PARCEHIS_VAL_IOCC" , "0.68"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "16"},
                { "BILHETE_DATA_QUITACAO" , "2017-08-24"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI0229B_V0ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("BI0229B_V0ENDOSSO", q1);

                #endregion
                #endregion
                var program = new BI0229B();
                program.Execute(SBI0229B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}