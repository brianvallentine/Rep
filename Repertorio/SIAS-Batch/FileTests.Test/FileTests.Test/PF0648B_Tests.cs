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
using static Code.PF0648B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0648B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0648B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
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

            #region PF0648B_MOVIMENTO_VGAP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , ""},
                { "MOVVGAP_COD_SUBGRUPO" , ""},
                { "MOVVGAP_COD_FONTE" , ""},
                { "MOVVGAP_NUM_PROPOSTA" , ""},
                { "MOVVGAP_TIPO_SEGURADO" , ""},
                { "MOVVGAP_NUM_CERTIFICADO" , "6"},
                { "MOVVGAP_DAC_CERTIFICADO" , ""},
                { "MOVVGAP_TIPO_INCLUSAO" , ""},
                { "MOVVGAP_COD_CLIENTE" , ""},
                { "MOVVGAP_COD_AGENCIADOR" , ""},
                { "MOVVGAP_COD_CORRETOR" , ""},
                { "MOVVGAP_COD_PLANOVGAP" , ""},
                { "MOVVGAP_COD_PLANOAP" , ""},
                { "MOVVGAP_FAIXA" , ""},
                { "MOVVGAP_AUTOR_AUM_AUTOMAT" , ""},
                { "MOVVGAP_TIPO_BENEFICIARIO" , ""},
                { "MOVVGAP_PERI_PAGAMENTO" , ""},
                { "MOVVGAP_PERI_RENOVACAO" , ""},
                { "MOVVGAP_COD_OCUPACAO" , ""},
                { "MOVVGAP_ESTADO_CIVIL" , ""},
                { "MOVVGAP_IDE_SEXO" , ""},
                { "MOVVGAP_COD_PROFISSAO" , ""},
                { "MOVVGAP_NATURALIDADE" , ""},
                { "MOVVGAP_OCORR_ENDERECO" , ""},
                { "MOVVGAP_OCORR_END_COBRAN" , ""},
                { "MOVVGAP_BCO_COBRANCA" , ""},
                { "MOVVGAP_AGE_COBRANCA" , ""},
                { "MOVVGAP_DAC_COBRANCA" , ""},
                { "MOVVGAP_NUM_MATRICULA" , ""},
                { "MOVVGAP_NUM_CTA_CORRENTE" , ""},
                { "MOVVGAP_DAC_CTA_CORRENTE" , ""},
                { "MOVVGAP_VAL_SALARIO" , ""},
                { "MOVVGAP_TIPO_SALARIO" , ""},
                { "MOVVGAP_TIPO_PLANO" , ""},
                { "MOVVGAP_PCT_CONJUGE_VG" , ""},
                { "MOVVGAP_PCT_CONJUGE_AP" , ""},
                { "MOVVGAP_QTD_SAL_MORNATU" , ""},
                { "MOVVGAP_QTD_SAL_MORACID" , ""},
                { "MOVVGAP_QTD_SAL_INVPERM" , ""},
                { "MOVVGAP_TAXA_AP_MORACID" , ""},
                { "MOVVGAP_TAXA_AP_INVPERM" , ""},
                { "MOVVGAP_TAXA_AP_AMDS" , ""},
                { "MOVVGAP_TAXA_AP_DH" , ""},
                { "MOVVGAP_TAXA_AP_DIT" , ""},
                { "MOVVGAP_TAXA_VG" , ""},
                { "MOVVGAP_IMP_MORNATU_ANT" , ""},
                { "MOVVGAP_IMP_MORNATU_ATU" , ""},
                { "MOVVGAP_IMP_MORACID_ANT" , ""},
                { "MOVVGAP_IMP_MORACID_ATU" , ""},
                { "MOVVGAP_IMP_INVPERM_ANT" , ""},
                { "MOVVGAP_IMP_INVPERM_ATU" , ""},
                { "MOVVGAP_IMP_AMDS_ANT" , ""},
                { "MOVVGAP_IMP_AMDS_ATU" , ""},
                { "MOVVGAP_IMP_DH_ANT" , ""},
                { "MOVVGAP_IMP_DH_ATU" , ""},
                { "MOVVGAP_IMP_DIT_ANT" , ""},
                { "MOVVGAP_IMP_DIT_ATU" , ""},
                { "MOVVGAP_PRM_VG_ANT" , ""},
                { "MOVVGAP_PRM_VG_ATU" , ""},
                { "MOVVGAP_PRM_AP_ANT" , ""},
                { "MOVVGAP_PRM_AP_ATU" , ""},
                { "MOVVGAP_COD_OPERACAO" , ""},
                { "MOVVGAP_DATA_AVERBACAO" , ""},
                { "MOVVGAP_DATA_INCLUSAO" , ""},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , ""},
                { "MOVVGAP_SIT_REGISTRO" , ""},
                { "MOVVGAP_COD_USUARIO" , ""},
                { "DCLPRODUTOS_VG_COD_PRODUTO" , ""},
                { "RELATORI_PERI_FINAL" , "2024092410"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0648B_MOVIMENTO_VGAP", q2);

            #endregion

            #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0210_00_LER_SICOB_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_LER_SICOB_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , ""},
                { "COD_PRODUTO" , ""},
                { "COD_CLIENTE" , ""},
                { "OCOREND" , ""},
                { "COD_FONTE" , ""},
                { "AGE_COBRANCA" , ""},
                { "OPCAO_COBERTURA" , ""},
                { "DATA_QUITACAO" , ""},
                { "COD_AGE_VENDEDOR" , ""},
                { "OPE_CONTA_VENDEDOR" , ""},
                { "NUM_CONTA_VENDEDOR" , ""},
                { "DIG_CONTA_VENDEDOR" , ""},
                { "NUM_MATRI_VENDEDOR" , ""},
                { "COD_OPERACAO" , ""},
                { "PROFISSAO" , ""},
                { "DTINCLUS" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "SIT_REGISTRO" , ""},
                { "NUM_APOLICE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "NRPRIPARATZ" , ""},
                { "QTDPARATZ" , ""},
                { "DTPROXVEN" , ""},
                { "NUM_PARCELA" , ""},
                { "DATA_VENCIMENTO" , ""},
                { "SIT_INTERFACE" , ""},
                { "DTFENAE" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
                { "IDADE" , ""},
                { "IDE_SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "APOS_INVALIDEZ" , ""},
                { "NOME_ESPOSA" , ""},
                { "DTNASC_ESPOSA" , ""},
                { "PROFIS_ESPOSA" , ""},
                { "DPS_TITULAR" , ""},
                { "DPS_ESPOSA" , ""},
                { "INFO_COMPLEMENTAR" , ""},
                { "COD_CCT" , ""},
                { "FAIXA_RENDA_IND" , ""},
                { "FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , ""},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0350_00_LER_ENDERECO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0350_00_LER_ENDERECO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0410_00_LER_CBO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_LER_CBO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , ""},
                { "OPPAGVA_DATA_INIVIGENCIA" , ""},
                { "OPPAGVA_DATA_TERVIGENCIA" , ""},
                { "OPPAGVA_OPCAO_PAGAMENTO" , ""},
                { "OPPAGVA_PERI_PAGAMENTO" , ""},
                { "OPPAGVA_DIA_DEBITO" , ""},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , ""},
                { "OPPAGVA_OPE_CONTA_DEBITO" , ""},
                { "OPPAGVA_NUM_CONTA_DEBITO" , ""},
                { "OPPAGVA_DIG_CONTA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region PF0648B_FUNDOCOMISVA

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0648B_FUNDOCOMISVA", q10);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0610_00_SEGURAVG_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_DATA_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_SEGURAVG_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0620_00_DADOS_RG_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_DADOS_RG_DB_SELECT_1_Query1", q13);

            #endregion

            #region PF0648B_OBTER_DATA_CREDITO

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_DATA_MOVIMENTO" , ""}
            });
            //AppSettings.TestSet.DynamicData.Add("PF0648B_OBTER_DATA_CREDITO", q14);

            #endregion

            #region R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1", q15);

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
                { "DTQITBCO" , ""},
                { "VAL_PAGO" , ""},
                { "AGEPGTO" , ""},
                { "VAL_TARIFA" , ""},
                { "DATA_CREDITO" , ""},
                { "VAL_COMISSAO" , ""},
                { "COD_USUARIO" , ""},
                { "NSAS_SIVPF" , ""},
                { "NSAC_SIVPF" , ""},
                { "NSL" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1", q18);

            #endregion

            #region PF0648B_DADOS_LANC

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0648B_DADOS_LANC", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVTO_PRP_SASSE_FILE_00.txt")]
        public static void PF0648B_Tests_Theory(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0648B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("NUM_PROPOSTA_SIVPF", out var valor) && valor == "000000000000006");

                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out valor) && valor == "PRPSASSE");
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out valor) && valor == "0004");
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out valor) && valor == "000000001");
            }
        }
    }
}