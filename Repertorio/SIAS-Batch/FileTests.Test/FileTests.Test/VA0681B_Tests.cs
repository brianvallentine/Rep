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
using static Code.VA0681B;

namespace FileTests.Test
{
    [Collection("VA0681B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0681B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0015_LER_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WSIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0015_LER_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0681B_CPROPOSTA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""},
                { "ESCRINEG_COD_ESCNEG" , ""},
                { "ESCRINEG_NOME_ABREV_ESCNEG" , ""},
                { "AGENCIAS_COD_AGENCIA" , ""},
                { "AGENCIAS_NOME_AGENCIA" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0681B_CPROPOSTA", q1);

            #endregion

            #region M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_COD_DEVOLUCAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "DEVOLVID_DESC_DEVOLUCAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("EM0005B_20052025_1", "EM0005B_20052025_2")]
        public static void VA0681B_Tests_Theory(string ARQUIVO_DEVOLUCAO_FILE_NAME_P, string SVA0681B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQUIVO_DEVOLUCAO_FILE_NAME_P = $"{ARQUIVO_DEVOLUCAO_FILE_NAME_P}_{timestamp}.txt";
            SVA0681B_FILE_NAME_P = $"{SVA0681B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0015_LER_SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WSIST_DTMOVABE" , ""}
                 });
                AppSettings.TestSet.DynamicData.Remove("M_0015_LER_SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0015_LER_SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0681B_CPROPOSTA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , "GERAL"},
                { "ESCRINEG_COD_ESCNEG" , "101"},
                { "ESCRINEG_NOME_ABREV_ESCNEG" , "xxxx"},
                { "AGENCIAS_COD_AGENCIA" , "221"},
                { "AGENCIAS_NOME_AGENCIA" , "MEIER, RJ"},
                { "HISCONPA_NUM_PARCELA" , "2"},
                { "PROPOVA_COD_USUARIO" , "EX0008B"},
                { "PROPOVA_NUM_CERTIFICADO" , "10000101526"},
                { "PROPOVA_NUM_APOLICE" , "97010000889"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_SIT_REGISTRO" , "4"},
                { "PROPOVA_DATA_QUITACAO" , "1992-03-05"},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "0"},
                { "PROPOVA_COD_CLIENTE" , "370373"},
            });
               
                q1.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , "GERAL"},
                { "ESCRINEG_COD_ESCNEG" , "101"},
                { "ESCRINEG_NOME_ABREV_ESCNEG" , "yyyyy"},
                { "AGENCIAS_COD_AGENCIA" , "785"},
                { "AGENCIAS_NOME_AGENCIA" , "TIANGUA, CE"},
                { "HISCONPA_NUM_PARCELA" , "2"},
                { "PROPOVA_COD_USUARIO" , "EX0008B"},
                { "PROPOVA_NUM_CERTIFICADO" , "10000101526"},
                { "PROPOVA_NUM_APOLICE" , "97010000889"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_SIT_REGISTRO" , "4"},
                { "PROPOVA_DATA_QUITACAO" , "1992-03-05"},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "0"},
                { "PROPOVA_COD_CLIENTE" , "370373"},
            });
                AppSettings.TestSet.DynamicData.Remove("VA0681B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("VA0681B_CPROPOSTA", q1);
            

                #endregion

                #region M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , "15.34"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_COD_DEVOLUCAO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "DEVOLVID_DESC_DEVOLUCAO" , "DATA ESCOLHIDA PARA DEBITO FORA DO LIMITE PREESTABELECIDO"}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "DEVOLVID_DESC_DEVOLUCAO" , "DATA ESCOLHIDA PARA DEBITO FORA DO LIMITE PREESTABELECIDO"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new VA0681B();
                program.Execute(ARQUIVO_DEVOLUCAO_FILE_NAME_P, SVA0681B_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

                var envList1 = AppSettings.TestSet.DynamicData["M_0015_LER_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList5);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("EM0005B_20052025_1", "EM0005B_20052025_2")]
        public static void VA0681B_Tests99_Theory(string ARQUIVO_DEVOLUCAO_FILE_NAME_P, string SVA0681B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQUIVO_DEVOLUCAO_FILE_NAME_P = $"{ARQUIVO_DEVOLUCAO_FILE_NAME_P}_{timestamp}.txt";
            SVA0681B_FILE_NAME_P = $"{SVA0681B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0681B_CPROPOSTA

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""},
                { "ESCRINEG_COD_ESCNEG" , ""},
                { "ESCRINEG_NOME_ABREV_ESCNEG" , ""},
                { "AGENCIAS_COD_AGENCIA" , ""},
                { "AGENCIAS_NOME_AGENCIA" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},

            }, new SQLCA(100));              
                AppSettings.TestSet.DynamicData.Remove("VA0681B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("VA0681B_CPROPOSTA", q1);

                #endregion

                #region M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_SELECT_PRODUTO_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_COD_DEVOLUCAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0135_SELECT_RELATORIOS_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "DEVOLVID_DESC_DEVOLUCAO" , ""}
                });
            
                AppSettings.TestSet.DynamicData.Remove("M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0140_SELECT_DEVOLVID_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new VA0681B();
                program.Execute(ARQUIVO_DEVOLUCAO_FILE_NAME_P, SVA0681B_FILE_NAME_P);
                                
                var envList1 = AppSettings.TestSet.DynamicData["M_0015_LER_SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);    
             
             
                Assert.True(program.RETURN_CODE == 9);
            }
        }


    }
}