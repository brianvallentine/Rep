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
using static Code.SI5040B;
using Sias.Sinistro.DB2.SI5040B;

namespace FileTests.Test
{
    [Collection("SI5040B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI5040B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI5040B_CR_SIVAT

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "CA_IDENT_MOV" , ""},
                { "CHEQUEMI_TIPO_MOVIMENTO" , ""},
                { "CHEQUEMI_COD_FONTE" , ""},
                { "CHEQUEMI_NUM_DOCUMENTO" , ""},
                { "CHEQUEMI_NOME_FAVORECIDO" , ""},
                { "CHEQUEMI_VAL_CHEQUE" , ""},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_PRACA_PAGAMENTO" , ""},
                { "CHEQUEMI_DATA_LANCAMENTO" , ""},
                { "RALCHEDO_NUM_DOCUMENTO" , ""},
                { "RALCHEDO_AGENCIA_CONTRATO" , ""},
                { "RALCHEDO_AGE_CENTRAL_PROD01" , ""},
                { "RALCHEDO_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI5040B_CR_SIVAT", q0);

            #endregion

            #region R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DT_MOVABTO_MENOS_10DIAS" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_SIVAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RALCHEDO_NUMERO_SIVAT" , ""},
                { "RALCHEDO_DV_SIVAT" , ""},
                { "CHEQUEMI_NUM_CHEQUE_INTERNO" , ""},
                { "CHEQUEMI_DIG_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_AGE_CENTRAL_PROD01" , ""},
                { "RALCHEDO_AGENCIA_CONTRATO" , ""},
                { "RALCHEDO_OCORR_HISTORICO" , ""},
                { "RALCHEDO_NUM_DOCUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "NUMEROUT_NUM_SIVAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1", q4);

            #endregion
            #endregion
        }

        [Fact]
        public static void SI5040B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DT_MOVABTO_MENOS_10DIAS" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1", q1);
                #endregion
                var program = new SI5040B();
                program.Execute();
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("RALCHEDO_NUMERO_SIVAT", out var valor) && valor == "000000001");

                var envList1 = AppSettings.TestSet.DynamicData["R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("NUMEROUT_NUM_SIVAT", out valor) && valor == "000000001");

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void SI5040B_Tests_SemDados()
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
                AppSettings.TestSet.DynamicData.Remove("R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1", q1);

                #endregion
                var program = new SI5040B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}