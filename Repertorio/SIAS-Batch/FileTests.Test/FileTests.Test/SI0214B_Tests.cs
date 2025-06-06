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
using static Code.SI0214B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0214B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0214B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "HOST_DATA_CORRENTE" , "2025-03-11"},
                { "HOST_DATA_SISTEMA_MENOS_30DIAS" , "2024-12-27"},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                   "}
            });
            AppSettings.TestSet.DynamicData.Add("R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0214B_COBRANCA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , "104800010560"},
                { "SI111_NUM_RESSARC" , "2"},
                { "SI111_NUM_PARCELA" , "5"},
                { "SI111_NUM_NOSSO_TITULO" , "8000400000402092"},
                { "SI111_DTH_VENCIMENTO" , "2025-01-10"},
                { "SINISHIS_OCORR_HISTORICO" , "43"},
                { "SINISHIS_COD_OPERACAO" , "4100"},
                { "SINISHIS_VAL_OPERACAO" , "500.00"},
                { "SINISHIS_COD_PREST_SERVICO" , "0"},
                { "SI111_DTH_PAGAMENTO" , "2025-01-10"},
                { "SINISHIS_DATA_MOVIMENTO" , "2025-01-13"},
                { "GE284_COD_SISTEMA_ORIGEM" , "3"},
                { "GE284_NOM_SISTEMA" , "RESSARCIMENTOWEB                        "},
                { "SI111_NUM_TITULO_SIGCB" , "149000400000402090"},
                { "SI111_IND_FORMA_BAIXA" , "1"},
                { "HOST_TEXTO_FORMA_BAIXA" , "BAIXA AUTOMATICA"},
                { "HOST_IND_TIPO_BAIXA" , "0"},
                { "HOST_TEXTO_TIPO_BAIXA" , "BAIXA EFETUADA COM SUCESSO"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , "104800069343"},
                { "SI111_NUM_RESSARC" , "8"},
                { "SI111_NUM_PARCELA" , "6"},
                { "SI111_NUM_NOSSO_TITULO" , "8000400000402360"},
                { "SI111_DTH_VENCIMENTO" , "2025-01-15"},
                { "SINISHIS_OCORR_HISTORICO" , "343"},
                { "SINISHIS_COD_OPERACAO" , "4100"},
                { "SINISHIS_VAL_OPERACAO" , "377.64"},
                { "SINISHIS_COD_PREST_SERVICO" , "0"},
                { "SI111_DTH_PAGAMENTO" , "2025-01-17"},
                { "SINISHIS_DATA_MOVIMENTO" , "2025-01-20"},
                { "GE284_COD_SISTEMA_ORIGEM" , "3"},
                { "GE284_NOM_SISTEMA" , "RESSARCIMENTOWEB                        "},
                { "SI111_NUM_TITULO_SIGCB" , "149000400000402368"},
                { "SI111_IND_FORMA_BAIXA" , "1"},
                { "HOST_TEXTO_FORMA_BAIXA" , "BAIXA AUTOMATICA"},
                { "HOST_IND_TIPO_BAIXA" , "0"},
                { "HOST_TEXTO_TIPO_BAIXA" , "BAIXA EFETUADA COM SUCESSO"},
            });
            AppSettings.TestSet.DynamicData.Add("SI0214B_COBRANCA", q2);

            #endregion

            #region R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "115.00"},
                { "SINISHIS_COD_PREST_SERVICO" , "2286850"},
                { "SINISHIS_COD_OPERACAO" , "4260"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "86.85"},
                { "SINISHIS_COD_PREST_SERVICO" , "2286850"},
                { "SINISHIS_COD_OPERACAO" , "4260"},
            });
            AppSettings.TestSet.DynamicData.Add("R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CGCCPF" , "4038488000105"},
                { "FORNECED_NOME_FORNECEDOR" , "SAVAS & HEINZEN ADVOGADOS ASSOC. S/C    "},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_CGCCPF" , "4038488000105"},
                { "FORNECED_NOME_FORNECEDOR" , "SAVAS & HEINZEN ADVOGADOS ASSOC. S/C    "},
            });
            AppSettings.TestSet.DynamicData.Add("R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1", q4);

            #endregion

            #region R100_PROCESSA_COBRANCA_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "75.00"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_VAL_OPERACAO" , "75.40"}
            });
            AppSettings.TestSet.DynamicData.Add("R100_PROCESSA_COBRANCA_DB_SELECT_3_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0214B_OUTPUT_2025031110520000")]
        public static void SI0214B_Tests_Theory(string REG_RET_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REG_RET_FILE_NAME_P = $"{REG_RET_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new SI0214B();
                program.Execute(REG_RET_FILE_NAME_P);

                Assert.True(File.Exists(program.REG_RET.FilePath));
                Assert.True(new FileInfo(program.REG_RET.FilePath).Length > 1);

                var select1 = AppSettings.TestSet.DynamicData["R010_LE_SISTEMAS_DB_SELECT_1_Query1"].DynamicList.ToList();
                var select2 = AppSettings.TestSet.DynamicData["R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1"].DynamicList.ToList();
                var select3 = AppSettings.TestSet.DynamicData["SI0214B_COBRANCA"].DynamicList.ToList();
                var select4 = AppSettings.TestSet.DynamicData["R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1"].DynamicList.ToList();
                var select5 = AppSettings.TestSet.DynamicData["R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1"].DynamicList.ToList();
                var select6 = AppSettings.TestSet.DynamicData["R100_PROCESSA_COBRANCA_DB_SELECT_3_Query1"].DynamicList.ToList();

                Assert.Empty(select1);
                Assert.Empty(select2);
                Assert.Empty(select3);
                Assert.Empty(select4);
                Assert.Empty(select5);
                Assert.Empty(select6);

                Assert.True(program.RETURN_CODE == 0);
            }
        }



        [Theory]
        [InlineData("SI0214B_OUTPUT_2025031110520001")]
        public static void SI0214B_Tests_Theory_ReturnCode_99(string REG_RET_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REG_RET_FILE_NAME_P = $"{REG_RET_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                    { "HOST_DATA_CORRENTE" , "2025-03-11"},
                    { "HOST_DATA_SISTEMA_MENOS_30DIAS" , "2024-12-27"},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion

                var program = new SI0214B();
                program.Execute(REG_RET_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}