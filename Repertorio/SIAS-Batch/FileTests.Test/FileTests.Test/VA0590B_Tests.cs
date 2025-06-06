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
using static Code.VA0590B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0590B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0590B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-11-14"}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0590B_PRESTAMISTA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "9999"},
                { "PROPOVA_COD_PRODUTO" , "7710"},
                { "PROPOVA_COD_CLIENTE" , "01"},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "01"},
                { "PROPOVA_PROFISSAO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_IDE_SEXO" , ""},
                { "PROPOVA_NOME_ESPOSA" , ""},
                { "PROPOVA_DTNASC_ESPOSA" , ""},
                { "PROPOVA_FAIXA_RENDA_IND" , "200"},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PROPOVA_NUM_CONTR_VINCULO" , ""},
                { "PROPOVA_COD_CORRESP_BANC" , ""},
                { "PROPOVA_COD_ORIGEM_PROPOSTA" , ""},
                { "PROPOVA_COD_OPER_CREDITO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "WS_FIM_DE_VIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0590B_PRESTAMISTA", q1);

            #endregion

            #region R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NUM_MATRICULA" , "123"},
                { "FUNCICEF_NOME_FUNCIONARIO" , "Teste da Silva"},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0600_00_LE_GEDOC_CLI_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , "SESPR"},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_LE_GEDOC_CLI_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE243_VLR_MIN_FAIXA" , "10"},
                { "GE243_VLR_MAX_FAIXA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_LE_GE_FAI_REN_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE372_DES_OPER_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_PARCELA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_BUSCA_VALORES2_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQVA590_FILE_NAME_P")]
        public static void VA0590B_Tests_Theory(string ARQVA590_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQVA590_FILE_NAME_P = $"{ARQVA590_FILE_NAME_P}_{timestamp}.txt";
           
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
                var program = new VA0590B();
                program.Execute(ARQVA590_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQVA590.FilePath));
                Assert.True(new FileInfo(program.ARQVA590.FilePath)?.Length > 0);

                Assert.True(program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO == "2024-11-14");
                Assert.True(program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO == 9999);
                Assert.True(program.FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA == 000000000000123);
                Assert.True(program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP == "SESPR");
                Assert.True(program.GE243.DCLGE_FAIXA_RENDA.GE243_VLR_MIN_FAIXA == 10);


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("ARQVA590_FILE_NAME_P")]
        public static void VA0590B_Tests_SemDados(string ARQVA590_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQVA590_FILE_NAME_P = $"{ARQVA590_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("R0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0000_00_ROTINA_INICIAL_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new VA0590B();
                program.Execute(ARQVA590_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}