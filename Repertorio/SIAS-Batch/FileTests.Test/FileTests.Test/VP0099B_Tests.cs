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
using static Code.VP0099B;

namespace FileTests.Test
{
    [Collection("VP0099B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VP0099B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VP0099B_CR_CERTIF_COMPRA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
                { "VG096_DTA_PROXIMA_COBRANCA" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0099B_CR_CERTIF_COMPRA", q0);

            #endregion

            #region VP0099B_CR_CERTIF_CANCEL

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "VG096_DTA_PROXIMA_COBRANCA" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0099B_CR_CERTIF_CANCEL", q1);

            #endregion

            #region R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG097_NUM_ARQ_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2300_LER_FIDELIZ_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2300_LER_FIDELIZ_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2400_LER_CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_LER_CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_DATA_NASCIMENTO" , ""},
                { "PESSOFIS_SEXO" , ""},
                { "PESSOFIS_ESTADO_CIVIL" , ""},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_COD_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2530_DESC_PROFISSAO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CBO_DESCR_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2530_DESC_PROFISSAO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2600_LER_ENDERECO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PESSOEND_ENDERECO" , ""},
                { "PESSOEND_COMPL_ENDER" , ""},
                { "PESSOEND_CIDADE" , ""},
                { "PESSOEND_BAIRRO" , ""},
                { "PESSOEND_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2600_LER_ENDERECO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2700_LER_TELEFONE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_DDI" , ""},
                { "WS_DDD" , ""},
                { "WS_NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_LER_TELEFONE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VG097_NUM_CERTIFICADO" , ""},
                { "VG097_COD_PRODUTO" , ""},
                { "VG097_COD_ACOPLADO" , ""},
                { "VG097_NUM_ARQ_PROPOSTA" , ""},
                { "VG097_DES_ACOPLADO" , ""},
                { "VG097_DTA_INI_VIGENCIA" , ""},
                { "VG097_DTA_FIM_VIGENCIA" , ""},
                { "VG097_STA_REGISTRO" , ""},
                { "VG097_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_INTERFACE" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQTEMPO_FILE_NAME_P")]
        public static void VP0099B_Tests_Theory_Erro99(string ARQTEMPO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQTEMPO_FILE_NAME_P = $"{ARQTEMPO_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VP0099B_CR_CERTIF_COMPRA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
                { "VG096_DTA_PROXIMA_COBRANCA" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("VP0099B_CR_CERTIF_COMPRA");
                AppSettings.TestSet.DynamicData.Add("VP0099B_CR_CERTIF_COMPRA", q0);

                #endregion

                #endregion
                var program = new VP0099B();
                program.Execute(ARQTEMPO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("ARQTEMPO_FILE_NAME_P")]
        public static void VP0099B_Tests_Theory(string ARQTEMPO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQTEMPO_FILE_NAME_P = $"{ARQTEMPO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VP0099B_CR_CERTIF_COMPRA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "80002770011635"},
                { "PROPOVA_DATA_MOVIMENTO" , "2018-01-11"},
                { "VG096_DTA_PROXIMA_COBRANCA" , "2018-01-24"},
                { "PROPOVA_COD_PRODUTO" , "7732"},
                { "PROPOVA_NUM_APOLICE" , "107700000067"},
                { "PROPOVA_NUM_PARCELA" , "2"},
                { "PROPOVA_COD_CLIENTE" , "15421307"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0099B_CR_CERTIF_COMPRA");
                AppSettings.TestSet.DynamicData.Add("VP0099B_CR_CERTIF_COMPRA", q0);

                #endregion

                #region VP0099B_CR_CERTIF_CANCEL

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "80002770011635"},
                { "VG096_DTA_PROXIMA_COBRANCA" , "2018-01-24"},
                { "PROPOVA_COD_PRODUTO" , "7732"},
                { "PROPOVA_NUM_APOLICE" , "107700000067"},
                { "PROPOVA_NUM_PARCELA" , "2"},
                { "PROPOVA_COD_CLIENTE" , "15421307"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0099B_CR_CERTIF_CANCEL");
                AppSettings.TestSet.DynamicData.Add("VP0099B_CR_CERTIF_CANCEL", q1);

                #endregion

                #region R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "VG097_NUM_ARQ_PROPOSTA" , ""}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "VG097_NUM_ARQ_PROPOSTA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_PEGAR_MAX_SEQ_DB_SELECT_1_Query1", q2);

                #endregion

                #region R2300_LER_FIDELIZ_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_LER_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_LER_FIDELIZ_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2400_LER_CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_LER_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_LER_CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_DATA_NASCIMENTO" , ""},
                { "PESSOFIS_SEXO" , ""},
                { "PESSOFIS_ESTADO_CIVIL" , ""},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                });
                q5.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_DATA_NASCIMENTO" , ""},
                { "PESSOFIS_SEXO" , ""},
                { "PESSOFIS_ESTADO_CIVIL" , ""},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2530_DESC_PROFISSAO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CBO_DESCR_CBO" , ""}
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "CBO_DESCR_CBO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2530_DESC_PROFISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2530_DESC_PROFISSAO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2600_LER_ENDERECO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "PESSOEND_ENDERECO" , ""},
                { "PESSOEND_COMPL_ENDER" , ""},
                { "PESSOEND_CIDADE" , ""},
                { "PESSOEND_BAIRRO" , ""},
                { "PESSOEND_CEP" , ""},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "PESSOEND_ENDERECO" , ""},
                { "PESSOEND_COMPL_ENDER" , ""},
                { "PESSOEND_CIDADE" , ""},
                { "PESSOEND_BAIRRO" , ""},
                { "PESSOEND_CEP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2600_LER_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2600_LER_ENDERECO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2700_LER_TELEFONE_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "WS_DDI" , ""},
                { "WS_DDD" , ""},
                { "WS_NUM_FONE" , ""},
                });
                q8.AddDynamic(new Dictionary<string, string>{
                { "WS_DDI" , ""},
                { "WS_DDD" , ""},
                { "WS_NUM_FONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2700_LER_TELEFONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2700_LER_TELEFONE_DB_SELECT_1_Query1", q8);

                #endregion

                #region R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "VG097_NUM_CERTIFICADO" , "80002770011635"},
                { "VG097_COD_PRODUTO" , "7732"},
                { "VG097_COD_ACOPLADO" , "2"},
                { "VG097_NUM_ARQ_PROPOSTA" , "123123"},
                { "VG097_DES_ACOPLADO" , "2"},
                { "VG097_DTA_INI_VIGENCIA" , "2018-01-11"},
                { "VG097_DTA_FIM_VIGENCIA" , "2018-01-11"},
                { "VG097_STA_REGISTRO" , "4"},
                { "VG097_NOM_PROGRAMA" , "VP0099B"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_INTERFACE" , "0"},
                { "PROPOVA_NUM_CERTIFICADO" , "80002770011635"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1", q10);

                #endregion

                #endregion
                var program = new VP0099B();
                program.Execute(ARQTEMPO_FILE_NAME_P);

                //R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("VG097_COD_PRODUTO", out var valor) && valor.Contains("7732"));
                Assert.True(envList.Count > 1);

                //R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var valor2) && valor2.Contains("080002770011635"));
                Assert.True(envList2.Count > 1);


                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}