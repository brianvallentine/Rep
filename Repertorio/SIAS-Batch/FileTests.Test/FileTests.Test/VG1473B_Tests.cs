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
using static Code.VG1473B;

namespace FileTests.Test
{
    [Collection("VG1473B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG1473B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DTCURREN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_NSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q2);

            #endregion

            #region VG1473B_CPROPVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPVA_DTQIT10A" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PRODUVG_COD_PRODUTO_EA" , ""},
                { "PRODUVG_OPCAO_PAGAMENTO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "PROPOVA_ESTADO_CIVIL" , ""},
                { "PROPOVA_IDE_SEXO" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1473B_CPROPVA", q3);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_TIPO_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q4);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_NUM_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q5);

            #endregion

            #region M_0000_PRINCIPAL_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "GEARDETA_DTH_ANO_REFERENCIA" , ""},
                { "GEARDETA_DTH_MES_REFERENCIA" , ""},
                { "GEARDETA_IND_MEIO_ENVIO" , ""},
                { "GEARDETA_STA_ENVIO_RECEPCAO" , ""},
                { "GEARDETA_COD_TIPO_ARQUIVO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_QTD_REG_REJEITADOS" , ""},
                { "GEARDETA_QTD_REG_ACEITOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_INSERT_1_Insert1", q6);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_PROFISSAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q7);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q9);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q10);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_DTH_ANO_REFERENCIA" , ""},
                { "GEARDETA_DTH_MES_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q11);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
                { "ENDERECO_DDD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1", q12);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "UNIDAFED_COD_PAIS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1", q13);

            #endregion

            #region M_0110_FETCH_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "MOVIMEA_TIPO_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1", q15);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VG1473B_Saida1.txt")]
        public static void VG1473B_Tests_Theory_SitReg_2_ReturnCode_0(string REPSAF_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REPSAF_FILE_NAME_P = $"{REPSAF_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DTCURREN" , "2025-02-20"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , "2000-02-02"}
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , "2001-02-02"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1", q10);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_SIT_REGISTRO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q14);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_NSAS" , "3"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                var program = new VG1473B();
                program.Execute(REPSAF_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //M_0000_PRINCIPAL_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("GEARDETA_IND_MEIO_ENVIO", out var valor) && valor.Contains("E"));
                Assert.True(envList.Count > 1);

            }
        }
        [Theory]
        [InlineData("VG1473B_Saida2.txt")]
        public static void VG1473B_Tests_Theory_NoBirthDate_Error_ReturnCode_99(string REPSAF_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REPSAF_FILE_NAME_P = $"{REPSAF_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DTCURREN" , "2025-02-20"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new VG1473B();
                program.Execute(REPSAF_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
                Assert.True(program.CLIENT_DTNASC_I.Value == -1);

            }
        }
        [Theory]
        [InlineData("VG1473B_Saida3.txt")]
        public static void VG1473B_Tests_Theory_SitReg_2_NoProcessing_ReturnCode_0(string REPSAF_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            REPSAF_FILE_NAME_P = $"{REPSAF_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-01-27"},
                { "SISTEMAS_DTCURREN" , "2025-02-20"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0110_FETCH_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_SIT_REGISTRO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0110_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0110_FETCH_DB_SELECT_1_Query1", q14);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMEA_NSAS" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                var program = new VG1473B();
                program.Execute(REPSAF_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.WS_WORK_AREAS.AC_INCLUIDOS == 0 && program.WS_WORK_AREAS.AC_ALTERADOS == 0 && program.WS_WORK_AREAS.AC_EXCLUIDOS == 0 && program.WS_WORK_AREAS.AC_REATIVADOS == 0);

            }
        }
    }
}