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
using static Code.VP1110B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("VP1110B_Tests")]
    public class VP1110B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VP1110B_CUR001

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_TIMESTAMP" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP1110B_CUR001", q0);

            #endregion

            #region VP1110B_CUR002

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_OCORR_MOVTO" , ""},
                { "EF150_NUM_CONTRATO_SEGUR" , ""},
                { "EF150_NUM_CONTR_TERC" , ""},
                { "EF150_COD_PRODUTO" , ""},
                { "EF050_DTH_FIM_VIGENCIA" , ""},
                { "EF150_DTH_ATUALIZACAO" , ""},
                { "EF150_VLR_RESTITUIR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP1110B_CUR002", q1);

            #endregion

            #region P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_CT_RESTITUICAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q2);

            #endregion

            #region P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1", q3);

            #endregion

            #region P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "DDD" , ""},
                { "NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1", q4);

            #endregion

            #region P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GEPESSOA_COD_PESSOA" , ""},
                { "GEPESSOA_NOM_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1", q5);

            #endregion

            #region P2420_BUSCA_CPF_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEPESFIS_NUM_CPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P2420_BUSCA_CPF_DB_SELECT_1_Query1", q6);

            #endregion

            #region P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GEPESTEL_NUM_TELEFONE" , ""},
                { "GEPESTEL_NUM_DDD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VP1110B_t1")]
        public static void VP1110B_Tests_Theory(string VP1110S1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VP1110S1_FILE_NAME_P = $"{VP1110S1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VP1110B_CUR001

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_TIMESTAMP" , "2023-12-01T12:00:00Z" },
                { "PROPOVA_NUM_CERTIFICADO" , "123456789" },
                { "PROPOVA_COD_CLIENTE" , "C123456" },
                { "PROPOFID_COD_PESSOA" , "PF123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP1110B_CUR001");
AppSettings.TestSet.DynamicData.Add("VP1110B_CUR001", q0);

                #endregion

                #region VP1110B_CUR002

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_OCORR_MOVTO" , "987654321" },
                { "EF150_NUM_CONTRATO_SEGUR" , "S123456789" },
                { "EF150_NUM_CONTR_TERC" , "T987654321" },
                { "EF150_COD_PRODUTO" , "P123456" },
                { "EF050_DTH_FIM_VIGENCIA" , "2024-12-31T23:59:59Z" },
                { "EF150_DTH_ATUALIZACAO" , "2023-12-01T12:00:00Z" },
                { "EF150_VLR_RESTITUIR" , "1500.00" },
            });
            AppSettings.TestSet.DynamicData.Remove("VP1110B_CUR002");
AppSettings.TestSet.DynamicData.Add("VP1110B_CUR002", q1);

                #endregion

                #region P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WS_CT_RESTITUICAO" , "WS123456789" }
            });
            AppSettings.TestSet.DynamicData.Remove("P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q2);

                #endregion

                #region P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "12345678901" },
                { "CLIENTES_NOME_RAZAO" , "Empresa Exemplo S.A." },
            });
            AppSettings.TestSet.DynamicData.Remove("P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1", q3);

                #endregion

                #region P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "DDD" , "11" },
                { "NUM_FONE" , "987654321" },
            });
            AppSettings.TestSet.DynamicData.Remove("P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1", q4);

                #endregion

                #region P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GEPESSOA_COD_PESSOA" , "PF987654" },
                { "GEPESSOA_NOM_PESSOA" , "João Silva" },
            });
            AppSettings.TestSet.DynamicData.Remove("P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1", q5);

                #endregion

                #region P2420_BUSCA_CPF_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEPESFIS_NUM_CPF" , "12345678901" }
            });
            AppSettings.TestSet.DynamicData.Remove("P2420_BUSCA_CPF_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("P2420_BUSCA_CPF_DB_SELECT_1_Query1", q6);

                #endregion

                #region P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GEPESTEL_NUM_TELEFONE" , "987654321" },
                { "GEPESTEL_NUM_DDD" , "11" },
            });
            AppSettings.TestSet.DynamicData.Remove("P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VP1110B();
                program.Execute(VP1110S1_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VP1110B_t2")]
        public static void VP1110B_Tests_Return99(string VP1110S1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VP1110S1_FILE_NAME_P = $"{VP1110S1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region VP1110B_CUR001

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
  
            });
                AppSettings.TestSet.DynamicData.Remove("VP1110B_CUR001");
                AppSettings.TestSet.DynamicData.Add("VP1110B_CUR001", q0);

                #endregion

                #region VP1110B_CUR002

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EF150_NUM_OCORR_MOVTO" , "987654321" },
                { "EF150_NUM_CONTRATO_SEGUR" , "S123456789" },
                { "EF150_NUM_CONTR_TERC" , "T987654321" },
                { "EF150_COD_PRODUTO" , "P123456" },
                { "EF050_DTH_FIM_VIGENCIA" , "2024-12-31T23:59:59Z" },
                { "EF150_DTH_ATUALIZACAO" , "2023-12-01T12:00:00Z" },
                { "EF150_VLR_RESTITUIR" , "1500.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("VP1110B_CUR002");
                AppSettings.TestSet.DynamicData.Add("VP1110B_CUR002", q1);

                #endregion

                #region P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WS_CT_RESTITUICAO" , "WS123456789" }
            });
                AppSettings.TestSet.DynamicData.Remove("P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q2);

                #endregion

                #region P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "12345678901" },
                { "CLIENTES_NOME_RAZAO" , "Empresa Exemplo S.A." },
            });
                AppSettings.TestSet.DynamicData.Remove("P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1", q3);

                #endregion

                #region P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "DDD" , "11" },
                { "NUM_FONE" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1", q4);

                #endregion

                #region P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GEPESSOA_COD_PESSOA" , "PF987654" },
                { "GEPESSOA_NOM_PESSOA" , "João Silva" },
            });
                AppSettings.TestSet.DynamicData.Remove("P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1", q5);

                #endregion

                #region P2420_BUSCA_CPF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GEPESFIS_NUM_CPF" , "12345678901" }
            });
                AppSettings.TestSet.DynamicData.Remove("P2420_BUSCA_CPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2420_BUSCA_CPF_DB_SELECT_1_Query1", q6);

                #endregion

                #region P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "GEPESTEL_NUM_TELEFONE" , "987654321" },
                { "GEPESTEL_NUM_DDD" , "11" },
            });
                AppSettings.TestSet.DynamicData.Remove("P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1", q7);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VP1110B();
                program.Execute(VP1110S1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}