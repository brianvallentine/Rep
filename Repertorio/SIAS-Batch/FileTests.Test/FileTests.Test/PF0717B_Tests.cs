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
using static Code.PF0717B;
using System.IO;
using Sias.PessoaFisica.DB2.PF0717B;

namespace FileTests.Test
{
    [Collection("PF0717B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0717B_Tests
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
                { "ARQSIVPF_NSAS_SIVPF" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF0717B_TERMO_ADESAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , "123"},
                { "TERMOADE_NUM_APOLICE" , "109300000672"},
                { "TERMOADE_COD_SUBGRUPO" , "99"},
                { "PROPOVA_DATA_MOVIMENTO" , "2024/05/02"},
                { "PROPOVA_NUM_PARCELA" , "2"},
                { "PROPOFID_SIT_PROPOSTA" , "2"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "7889"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "4556"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "55"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "11"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , "124"},
                { "TERMOADE_NUM_APOLICE" , "654"},
                { "TERMOADE_COD_SUBGRUPO" , "98"},
                { "PROPOVA_DATA_MOVIMENTO" , "2024/12/12"},
                { "PROPOVA_NUM_PARCELA" , "3"},
                { "PROPOFID_SIT_PROPOSTA" , "2"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "9654"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "454"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "2"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "7"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0717B_TERMO_ADESAO", q2);

            #endregion

            #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "654"}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , "TXT"},
                { "ARQSIVPF_SISTEMA_ORIGEM" , "ABC"},
                { "ARQSIVPF_NSAS_SIVPF" , "4565"},
                { "ARQSIVPF_DATA_GERACAO" , "2024/10/11"},
                { "ARQSIVPF_QTDE_REG_GER" , "002"},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , "2024/11/11"},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q4);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "12"},
                { "PROPFIDH_DATA_SITUACAO" , "2024/07/10"},
                { "PROPFIDH_NSAS_SIVPF" , "235"},
                { "PROPFIDH_NSL" , "456"},
                { "PROPFIDH_SIT_PROPOSTA" , "2"},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , "3"},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , "4"},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , "0007"},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , "3565"},
            });
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NSAS_SIVPF" , "12345"},
                { "PROPOFID_NSL" , "124"},
                { "PROPOFID_SIT_PROPOSTA" , "1"},
                { "PROPOFID_COD_USUARIO" , "003"},
                { "PROPOFID_SITUACAO_ENVIO" , "2"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "7799"},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0717B.txt")]
        public static void PF0717B_Tests_TheorySemMovimento(string MOVTO_STA_SASSE_FILE_NAME_P)
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
                #region PF0717B_TERMO_ADESAO
                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("PF0717B_TERMO_ADESAO");
                AppSettings.TestSet.DynamicData.Add("PF0717B_TERMO_ADESAO",q2);
                #endregion
                #endregion
                var program = new PF0717B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE ==0);
            }
        }
        [Theory]
        [InlineData("Saida_PF0717B.txt")]
        public static void PF0717B_Tests_TheoryObterValMaxComErro09(string MOVTO_STA_SASSE_FILE_NAME_P)
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
                #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);
                #endregion
                #endregion
                var program = new PF0717B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 09);
            }
        }
        
        [Theory]
        [InlineData("Saida_PF0717B.txt")]
        public static void PF0717B_Tests_TheoryComMovimentoReturnCode00(string MOVTO_STA_SASSE_FILE_NAME_P)
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
                #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1
                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1");
                
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PROPFIDH_NUM_IDENTIFICACAO" , "654"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "PROPFIDH_NUM_IDENTIFICACAO" , "655"}
                });
                AppSettings.TestSet.DynamicData.Add("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q3);
                
                #endregion
                #endregion
                var program = new PF0717B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 00);

            }
        }
    }

}