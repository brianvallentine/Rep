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
using static Code.PF0716B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0716B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0716B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_INICIALIZAR_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024/05/05"},
                { "WHOST_DATA_REFERENCIA" , "2024/10/10"},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_INICIALIZAR_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "10"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF0716B_TERMO_ADESAO

            var q2 = new DynamicData();

            q2.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , "123"},
                { "TERMOADE_NUM_APOLICE" , "109300000672"},
                { "TERMOADE_COD_SUBGRUPO" , "99"},
                { "MOVIMVGA_DATA_MOVIMENTO" , "2024/06/02"},
                { "MOVIMVGA_DATA_OPERACAO" , "2024/05/02"},
                { "MOVIMVGA_COD_OPERACAO" , "200"},
                { "MOVIMVGA_SIT_REGISTRO" , "1"},
                { "PROPOFID_SIT_PROPOSTA" , "2"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "7777"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "7777"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "7654"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "45"},
            });

            q2.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , "124"},
                { "TERMOADE_NUM_APOLICE" , "986532"},
                { "TERMOADE_COD_SUBGRUPO" , "01"},
                { "MOVIMVGA_DATA_MOVIMENTO" , "2024/03/02"},
                { "MOVIMVGA_DATA_OPERACAO" , "2024/01/02"},
                { "MOVIMVGA_COD_OPERACAO" , "003"},
                { "MOVIMVGA_SIT_REGISTRO" , "2"},
                { "PROPOFID_SIT_PROPOSTA" , "3"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "9999"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "989898"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "00111"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "6355"},
            });

            AppSettings.TestSet.DynamicData.Add("PF0716B_TERMO_ADESAO", q2);

            #endregion

            #region R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_DATA_QUITACAO" , "2025/07/07"},
                { "PROPOVA_NUM_PARCELA" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1", q3);

            #endregion

            #region PF0716B_COBERTURAS

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0716B_COBERTURAS", q4);

            #endregion

            #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1234"}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q5);

            #endregion

            #region PF0716B_TER_NIVEL

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGTERNIV_NUM_PROPOSTA_SIVPF" , ""},
                { "VGTERNIV_DTH_INI_VIGENCIA" , ""},
                { "VGTERNIV_NUM_NIVEL_CARGO" , ""},
                { "VGTERNIV_DTH_FIM_VIGENCIA" , ""},
                { "VGTERNIV_IMP_SEGURADA" , ""},
                { "VGTERNIV_VLR_PRM_INDIVIDUAL" , ""},
                { "VGTERNIV_QTD_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0716B_TER_NIVEL", q6);

            #endregion

            #region R0860_LER_APOLICE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0860_LER_APOLICE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0870_LER_RAMOIND_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0870_LER_RAMOIND_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , "TXT"},
                { "ARQSIVPF_SISTEMA_ORIGEM" , "ABC"},
                { "ARQSIVPF_NSAS_SIVPF" , "12345"},
                { "ARQSIVPF_DATA_GERACAO" , "2024/05/05"},
                { "ARQSIVPF_QTDE_REG_GER" , "001"},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , "2024/06/05"},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "13568"},
                { "PROPFIDH_DATA_SITUACAO" , "2024/07/10"},
                { "PROPFIDH_NSAS_SIVPF" , "12345"},
                { "PROPFIDH_NSL" , "8877"},
                { "PROPFIDH_SIT_PROPOSTA" , "1"},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , "2"},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , "3"},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , "0007"},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , "3456"},
            });
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NSAS_SIVPF" , "12345"},
                { "PROPOFID_NSL" , "1234"},
                { "PROPOFID_SIT_PROPOSTA" , "1"},
                { "PROPOFID_COD_USUARIO" , "002"},
                { "PROPOFID_SITUACAO_ENVIO" , "2"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "7788"},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0716B.txt")]
        public static void PF0716B_Tests_TheorySemMovimento(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PF0716B_TERMO_ADESAO
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("PF0716B_TERMO_ADESAO");
                AppSettings.TestSet.DynamicData.Add("PF0716B_TERMO_ADESAO", q2);
                #endregion

                #endregion
                var program = new PF0716B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                //Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                //Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length == 0);

                Assert.True(program.WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM");
                Assert.True(program.WABEND.LOCALIZA_ABEND_2.COMANDO == "COMMIT WORK");

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Saida_PF0716B.txt")]
        public static void PF0716B_Tests_TheoryComMovimentoParaProcessarComErro09(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0716B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 09);
            }
        }
    }
}