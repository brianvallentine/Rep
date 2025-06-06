using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.AC0003B;

namespace FileTests.Test
{
    [Collection("AC0003B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0003B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_CURR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region AC0003B_C01_PARCEHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_TIPO_SEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0003B_C01_PARCEHIS", q1);

            #endregion

            #region AC0003B_C01_APOLCOSS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APOLCOSS_NUM_APOLICE" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
                { "APOLCOSS_DATA_INIVIGENCIA" , ""},
                { "APOLCOSS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0003B_C01_APOLCOSS", q2);

            #endregion

            #region R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_TIPO_ENDS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_CONG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ORDEMCOS_NUM_APOLICE" , ""},
                { "ORDEMCOS_NUM_ENDOSSO" , ""},
                { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                { "ORDEMCOS_ORDEM_CEDIDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "NUMERCOS_ORGAO_EMISSOR" , ""},
                { "NUMERCOS_SEQ_ORD_CEDIDO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ORDEMCOS_NUM_APOLICE" , ""},
                { "ORDEMCOS_NUM_ENDOSSO" , ""},
                { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                { "ORDEMCOS_ORDEM_CEDIDO" , ""},
                { "ORDEMCOS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "NUMERCOS_SEQ_ORD_CEDIDO" , ""},
                { "APOLCOSS_COD_COSSEGURADORA" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0003B_Tests_Fact()
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
                var program = new AC0003B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}