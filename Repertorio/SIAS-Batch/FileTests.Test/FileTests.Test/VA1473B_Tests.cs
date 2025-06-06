using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA1473B;

namespace FileTests.Test
{
    [Collection("VA1473B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA1473B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"},
                { "SISTEMAS_DTMOVABE_10" , "2024-08-23"},
                { "SISTEMAS_DTCURREN" , "2024-09-04"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CONARQEA_NSAS" , "17592"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CONARQEA_ANO_REFERENCIA" , "2023"},
                { "CONARQEA_NUM_ARQUIVO" , "101"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q2);

            #endregion

            #region VA1473B_CPROPVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "95702925620"},
                { "PROPOVA_NUM_APOLICE" , "3008104131620"},
                { "PROPOVA_COD_SUBGRUPO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "35590513"},
                { "PROPOVA_OCOREND" , "4"},
                { "PROPOVA_DATA_VENCIMENTO" , "2024-09-04"},
                { "PROPOVA_DATA_QUITACAO" , "2024-09-04"},
                { "PROPVA_DTQIT10A" , "2025-09-04"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_DTPROXVEN" , "2025-09-04"},
                { "PRODUVG_COD_PRODUTO_EA" , "SS"},
                { "PRODUVG_OPCAO_PAGAMENTO" , "1"},
                { "PRODUVG_PERI_PAGAMENTO" , "12"},
                { "PRODUVG_ORIG_PRODU" , "BILHE"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "95702925710"},
                { "PROPOVA_NUM_APOLICE" , "3003707513813"},
                { "PROPOVA_COD_SUBGRUPO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "36096046"},
                { "PROPOVA_OCOREND" , "1"},
                { "PROPOVA_DATA_VENCIMENTO" , "2024-09-04"},
                { "PROPOVA_DATA_QUITACAO" , "2024-09-04"},
                { "PROPVA_DTQIT10A" , "2025-09-04"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_DTPROXVEN" , " 2025-09-04"},
                { "PRODUVG_COD_PRODUTO_EA" , " SS"},
                { "PRODUVG_OPCAO_PAGAMENTO" , " 1"},
                { "PRODUVG_PERI_PAGAMENTO" , " 12"},
                { "PRODUVG_ORIG_PRODU" , " BILHE"},
            });
            q3.AddDynamic(new Dictionary<string, string>
            {
                { "PROPOVA_NUM_CERTIFICADO" , "95702925744"},
                { "PROPOVA_NUM_APOLICE" , "3008104131621"},
                { "PROPOVA_COD_SUBGRUPO" , "0"},
                { "PROPOVA_COD_CLIENTE" , "36096164"},
                { "PROPOVA_OCOREND" , "1"},
                { "PROPOVA_DATA_VENCIMENTO" , "2024-09-04"},
                { "PROPOVA_DATA_QUITACAO" , "2024-09-04"},
                { "PROPVA_DTQIT10A" , "2025-09-04"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_DTPROXVEN" , "2025-09-04"},
                { "PRODUVG_COD_PRODUTO_EA" , "SS"},
                { "PRODUVG_OPCAO_PAGAMENTO" , "1"},
                { "PRODUVG_PERI_PAGAMENTO" , "12"},
                { "PRODUVG_ORIG_PRODU" , "BILHE"},
            });
            AppSettings.TestSet.DynamicData.Add("VA1473B_CPROPVA", q3);

            #endregion

            #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CONARQEA_NSAS" , ""},
                { "CONARQEA_ANO_REFERENCIA" , ""},
                { "CONARQEA_NUM_ARQUIVO" , ""},
                { "CONARQEA_NUM_REGISTROS" , ""},
                { "CONARQEA_NUM_INCLUSOES" , ""},
                { "CONARQEA_NUM_ALTERACOES" , ""},
                { "CONARQEA_NUM_EXCLUSOES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q4);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "59999999999998"},
                { "CONVERSI_COD_PRODUTO_SIVPF" , "9"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "59999999999998"},
                { "CONVERSI_COD_PRODUTO_SIVPF" , "56"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "59999999999998"},
                { "CONVERSI_COD_PRODUTO_SIVPF" , "9"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_NSAS" , "0"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_NSAS" , "0"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_NSAS" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q6);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_TIPO_MOVIMENTO" , "I"}
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_TIPO_MOVIMENTO" , "A"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q7);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_PARCELA" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "29164567803"},
                { "CLIENTES_NOME_RAZAO" , "TITULAR CINCO                           "},
                { "CLIENTES_DATA_NASCIMENTO" , "1975-07-07"},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "22164167803"},
                { "CLIENTES_NOME_RAZAO" , "TITULAR CINCO                           "},
                { "CLIENTES_DATA_NASCIMENTO" , "1975-07-07"},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "22164567103"},
                { "CLIENTES_NOME_RAZAO" , "TITULAR CINCO                           "},
                { "CLIENTES_DATA_NASCIMENTO" , "1975-07-07"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q9);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , "1960-01-01"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , "1964-01-01"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , "1990-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q10);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "GENARO DE CARVALHO                                                      "},
                { "ENDERECO_BAIRRO" , "RECREIO DOS BANDEIRA                                                    "},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22795077"},
                { "ENDERECO_TELEFONE" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q11);

            #endregion

            #region M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "CONARQEA_NSAS" , ""},
                { "MOVIMEA_TIPO_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_VA1473B.txt")]
        public static void VA1473B_Tests_Theory(string REPSAF_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REPSAF_FILE_NAME_P = $"{REPSAF_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário altera-r alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA1473B();
                program.Execute(REPSAF_FILE_NAME_P);

                var envlist0 = AppSettings.TestSet.DynamicData["M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envlist0.Count > 1);
                Assert.True(envlist0[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val2r) && val2r.Contains("000095702925620"));
                Assert.True(envlist0[1].TryGetValue("CONARQEA_NSAS", out var val3r) && val3r.Contains("1760"));

                var envlist = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envlist.Count > 1);
                Assert.True(envlist[1].TryGetValue("CONARQEA_NSAS", out var valor) && valor.Contains("1760"));
                Assert.True(envlist[1].TryGetValue("CONARQEA_ANO_REFERENCIA", out var val5r) && val5r.Contains("2024"));


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("Saida_VA1473B.txt")]
        public static void VA1473B_Tests_Theory1(string REPSAF_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REPSAF_FILE_NAME_P = $"{REPSAF_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário altera-r alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA1473B();
                program.Execute(REPSAF_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}