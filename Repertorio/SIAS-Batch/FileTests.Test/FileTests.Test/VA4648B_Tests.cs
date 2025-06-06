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
using static Code.VA4648B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA4648B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA4648B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region VA4648B_CPROPOVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROPOSTAS_VA_NUM_CERTIFICADO" , ""},
                { "DCLPROPOSTAS_VA_COD_PRODUTO" , ""},
                { "DCLPROPOSTAS_VA_COD_CLIENTE" , ""},
                { "DCLPROPOSTAS_VA_OCOREND" , ""},
                { "DCLPROPOSTAS_VA_COD_FONTE" , ""},
                { "DCLPROPOSTAS_VA_AGE_COBRANCA" , ""},
                { "DCLPROPOSTAS_VA_OPCAO_COBERTURA" , ""},
                { "DCLPROPOSTAS_VA_DATA_QUITACAO" , ""},
                { "DCLPROPOSTAS_VA_COD_AGE_VENDEDOR" , ""},
                { "DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR" , ""},
                { "DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR" , ""},
                { "DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR" , ""},
                { "DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR" , ""},
                { "DCLPROPOSTAS_VA_COD_OPERACAO" , ""},
                { "DCLPROPOSTAS_VA_PROFISSAO" , ""},
                { "DCLPROPOSTAS_VA_DTINCLUS" , ""},
                { "DCLPROPOSTAS_VA_DATA_MOVIMENTO" , ""},
                { "DCLPROPOSTAS_VA_SIT_REGISTRO" , ""},
                { "DCLPROPOSTAS_VA_NUM_APOLICE" , ""},
                { "DCLPROPOSTAS_VA_COD_SUBGRUPO" , ""},
                { "DCLPROPOSTAS_VA_OCORR_HISTORICO" , ""},
                { "DCLPROPOSTAS_VA_NRPRIPARATZ" , ""},
                { "DCLPROPOSTAS_VA_QTDPARATZ" , ""},
                { "DCLPROPOSTAS_VA_DTPROXVEN" , ""},
                { "DCLPROPOSTAS_VA_NUM_PARCELA" , ""},
                { "DCLPROPOSTAS_VA_DATA_VENCIMENTO" , ""},
                { "DCLPROPOSTAS_VA_SIT_INTERFACE" , ""},
                { "DCLPROPOSTAS_VA_DTFENAE" , ""},
                { "DCLPROPOSTAS_VA_COD_USUARIO" , ""},
                { "DCLPROPOSTAS_VA_TIMESTAMP" , ""},
                { "DCLPROPOSTAS_VA_IDADE" , ""},
                { "DCLPROPOSTAS_VA_IDE_SEXO" , ""},
                { "DCLPROPOSTAS_VA_ESTADO_CIVIL" , ""},
                { "DCLPROPOSTAS_VA_APOS_INVALIDEZ" , ""},
                { "DCLPROPOSTAS_VA_NOME_ESPOSA" , ""},
                { "DCLPROPOSTAS_VA_DTNASC_ESPOSA" , ""},
                { "DCLPROPOSTAS_VA_PROFIS_ESPOSA" , ""},
                { "DCLPROPOSTAS_VA_DPS_TITULAR" , ""},
                { "DCLPROPOSTAS_VA_DPS_ESPOSA" , ""},
                { "DCLPROPOSTAS_VA_INFO_COMPLEMENTAR" , ""},
                { "DCLPROPOSTAS_VA_COD_CCT" , ""},
                { "DCLPROPOSTAS_VA_FAIXA_RENDA_IND" , ""},
                { "DCLPROPOSTAS_VA_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4648B_CPROPOVA", q2);

            #endregion

            #region VA4648B_FUNDOCOMISVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4648B_FUNDOCOMISVA", q3);

            #endregion

            #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO_SIVPF" , ""},
                { "SIT_PROPOSTA" , ""},
                { "NUM_SICOB" , ""},
                { "DATA_PROPOSTA" , ""},
                { "AGECOBR" , ""},
                { "NOME_CONVENENTE" , ""},
                { "NRMATRCON" , ""},
                { "CGC_CONVENENTE" , ""},
                { "PERC_DESCONTO" , ""},
                { "COD_PLANO" , ""},
                { "ORIGEM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0210_00_LER_SICOB_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_LER_SICOB_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , ""},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0310_00_LER_EMAIL_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_LER_EMAIL_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0320_00_LER_PRODUVG_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_LER_PRODUVG_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0330_00_LER_SUBGVGAP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_LER_SUBGVGAP_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0350_00_LER_ENDERECO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "ENDERECO_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_LER_ENDERECO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0410_00_LER_CBO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_LER_CBO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , ""},
                { "OPPAGVA_DATA_INIVIGENCIA" , ""},
                { "OPPAGVA_DATA_TERVIGENCIA" , ""},
                { "OPPAGVA_OPCAO_PAGAMENTO" , ""},
                { "OPPAGVA_DIA_DEBITO" , ""},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , ""},
                { "OPPAGVA_OPE_CONTA_DEBITO" , ""},
                { "OPPAGVA_NUM_CONTA_DEBITO" , ""},
                { "OPPAGVA_DIG_CONTA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0620_00_DADOS_RG_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_DADOS_RG_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "DATA_CREDITO" , ""},
                { "VAL_COMISSAO" , ""},
                { "COD_USUARIO" , ""},
                { "VAL_TARIFA" , ""},
                { "NSAS_SIVPF" , ""},
                { "NSAC_SIVPF" , ""},
                { "DTQITBCO" , ""},
                { "VAL_PAGO" , ""},
                { "AGEPGTO" , ""},
                { "NSL" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1", q18);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVTO_PRP_SASSE_FILE_NAME_P", "MOVTO_PRP_DISC_FILE_NAME_P")]
        public static void VA4648B_Tests_Theory(string MOVTO_PRP_SASSE_FILE_NAME_P, string MOVTO_PRP_DISC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_PRP_DISC_FILE_NAME_P = $"{MOVTO_PRP_DISC_FILE_NAME_P}_{timestamp}.txt";
           
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
                var program = new VA4648B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P, MOVTO_PRP_DISC_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length > 0);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("MOVTO_PRP_SASSE_FILE_NAME_P", "MOVTO_PRP_DISC_FILE_NAME_P")]
        public static void VA4648B_Tests_TheoryErro9(string MOVTO_PRP_SASSE_FILE_NAME_P, string MOVTO_PRP_DISC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_PRP_DISC_FILE_NAME_P = $"{MOVTO_PRP_DISC_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                 
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1");
                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1", q5);

                #endregion
                #endregion
                var program = new VA4648B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P, MOVTO_PRP_DISC_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}