using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.VG1617B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VG1617B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG1617B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DT_SISTEMA_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-10"},
                { "WS_DATA_MOV_ABERTO_1D" , "2024-10-12"},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DT_SISTEMA_Query1", q0);

            #endregion

            #region VG1617B_ERROPROC

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PF089_NUM_ERRO_PROPOSTA" , ""},
                { "PF089_DES_ERRO_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1617B_ERROPROC", q1);

            #endregion

            #region VG1617B_CAMPOARQ

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PF088_NUM_CAMPO_PROPOSTA" , ""},
                { "PF088_NOM_DET_ARQ_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG1617B_CAMPOARQ", q2);

            #endregion

            #region R0117_00_OBTER_NSAS_MOVTO_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0117_00_OBTER_NSAS_MOVTO_Query1", q3);

            #endregion

            #region R0118_00_CRITICA_ARQ_PROC_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_DATA_PROCESSAMENTO" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0118_00_CRITICA_ARQ_PROC_Query1", q4);

            #endregion

            #region R0449_00_MAX_NUM_BENEFIC_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NUM_BENEFICIARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0449_00_MAX_NUM_BENEFIC_Query1", q5);

            #endregion

            #region R0532_00_INSERT_BENEFIC_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NUM_APOLICE" , ""},
                { "BENEFICI_COD_SUBGRUPO" , ""},
                { "BENEFICI_NUM_CERTIFICADO" , ""},
                { "BENEFICI_DAC_CERTIFICADO" , ""},
                { "BENEFICI_NUM_BENEFICIARIO" , ""},
                { "BENEFICI_NOME_BENEFICIARIO" , ""},
                { "BENEFICI_GRAU_PARENTESCO" , ""},
                { "BENEFICI_PCT_PART_BENEFICIA" , ""},
                { "BENEFICI_DATA_INIVIGENCIA" , ""},
                { "BENEFICI_DATA_TERVIGENCIA" , ""},
                { "BENEFICI_COD_USUARIO" , ""},
                { "BENEFICI_NUM_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0532_00_INSERT_BENEFIC_Insert1", q6);

            #endregion

            #region R0558_00_INSERT_CNTRLE_PROC_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PF087_SIGLA_ARQUIVO" , ""},
                { "PF087_SISTEMA_ORIGEM" , ""},
                { "PF087_NSAS_SIVPF" , ""},
                { "PF087_NUM_PROPOSTA" , ""},
                { "PF087_SEQ_OCORRENCIA" , ""},
                { "PF087_NUM_DET_ARQ_PROPOSTA" , ""},
                { "PF087_NUM_ERRO_PROPOSTA" , ""},
                { "PF087_NUM_APOLICE_VINCULADA" , ""},
                { "PF087_NUM_LINHA_ARQUIVO" , ""},
                { "PF087_DES_CONTEUDO" , ""},
                { "PF087_STA_PROCESSAMENTO" , ""},
                { "PF087_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0558_00_INSERT_CNTRLE_PROC_Insert1", q7);

            #endregion

            #region R0559_00_INSERT_CNTRLE_HIST_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PF087_SIGLA_ARQUIVO" , ""},
                { "PF087_SISTEMA_ORIGEM" , ""},
                { "PF087_NSAS_SIVPF" , ""},
                { "PF087_NUM_PROPOSTA" , ""},
                { "PF087_SEQ_OCORRENCIA" , ""},
                { "PF090_SEQ_OCORR_HIST" , ""},
                { "PF087_STA_PROCESSAMENTO" , ""},
                { "PF087_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0559_00_INSERT_CNTRLE_HIST_Insert1", q8);

            #endregion

            #region R2060_00_ATUALIZA_ARQSIVPF_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2060_00_ATUALIZA_ARQSIVPF_Insert1", q9);

            #endregion

            #region R8001_00_VERIFICA_DATA_VALIDA_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "W_DATA_SQL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8001_00_VERIFICA_DATA_VALIDA_Query1", q10);

            #endregion

            #region R8012_00_VERIFICA_SEGURVGA_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_DAC_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8012_00_VERIFICA_SEGURVGA_Query1", q11);

            #endregion

            #region R8017_00_UPDATE_BENEFIC_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_DATA_INIVIGENCIA" , ""},
                { "BENEFICI_NUM_CERTIFICADO" , ""},
                { "BENEFICI_COD_SUBGRUPO" , ""},
                { "BENEFICI_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8017_00_UPDATE_BENEFIC_Update1", q12);

            #endregion

            #region R8030_00_VERIFICA_APOL_PROD_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_ESTR_EMISS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8030_00_VERIFICA_APOL_PROD_Query1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_VG1617B.txt", "Saida_VG1617B.txt")]
        public static void VG1617B_Tests_Theory_ReturnCode_09(string MOV_BENEFC_FILE_NAME_P, string RVG1617B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG1617B_FILE_NAME_P = $"{RVG1617B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0005_00_OBTER_DT_SISTEMA_Query1
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DT_SISTEMA_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DT_SISTEMA_Query1", q0);
                #endregion
                #endregion
                var program = new VG1617B();
                program.Execute(MOV_BENEFC_FILE_NAME_P, RVG1617B_FILE_NAME_P);

                //Assert.True(File.Exists(program._RVG1617B.FilePath));
                //Assert.True(new FileInfo(program._RVG1617B.FilePath)?.Length >= 0);

                Assert.True(program.RETURN_CODE == 09);
            }
        }
        [Theory]
        [InlineData("Entrada_VG1617B.txt", "Saida_VG1617B.txt")]
        public static void VG1617B_Tests_Theory_ImpossibilidadeExecucaoFluxo(string MOV_BENEFC_FILE_NAME_P, string RVG1617B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG1617B_FILE_NAME_P = $"{RVG1617B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG1617B();
                program.Execute(MOV_BENEFC_FILE_NAME_P, RVG1617B_FILE_NAME_P);

                //Assert.True(File.Exists(program._RVG1617B.FilePath));
                //Assert.True(new FileInfo(program._RVG1617B.FilePath)?.Length >= 0);

                Assert.True(program.RETURN_CODE == 09);
            }
        }
    }
}