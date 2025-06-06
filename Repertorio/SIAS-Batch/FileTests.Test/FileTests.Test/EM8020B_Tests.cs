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
using static Code.EM8020B;

namespace FileTests.Test
{
    [Collection("EM8020B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class EM8020B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "GE369_COD_AGENCIA" , ""},
                { "GE369_COD_BANCO" , ""},
                { "GE369_NUM_CONTA_CNB" , ""},
                { "GE369_NUM_DV_CONTA_CNB" , ""},
                { "GE369_IND_CONTA_BANCARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0350_00_SELECT_GE366_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE366_NUM_OCORR_MOVTO" , ""},
                { "GE366_COD_EVENTO" , ""},
                { "GE366_IDE_SISTEMA" , ""},
                { "GE366_IND_ESTRUTURA" , ""},
                { "GE366_IND_ORIGEM_FUNC" , ""},
                { "GE366_IND_EVENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_GE366_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_CONTA" , ""},
                { "SIARDEVC_DV_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1050_00_SELECT_GE368_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE368_NUM_PESSOA" , ""},
                { "GE368_NUM_OCORR_MOVTO" , ""},
                { "GE368_SEQ_ENTIDADE" , ""},
                { "GE368_IND_ENTIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_GE368_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_00_SELECT_OD001_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_OD001_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1120_00_SELECT_OD002_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "OD002_NUM_PESSOA" , ""},
                { "OD002_NUM_CPF" , ""},
                { "OD002_NUM_DV_CPF" , ""},
                { "OD002_NOM_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_SELECT_OD002_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1140_00_SELECT_OD003_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "OD003_NUM_PESSOA" , ""},
                { "OD003_NUM_CNPJ" , ""},
                { "OD003_NUM_FILIAL" , ""},
                { "OD003_NUM_DV_CNPJ" , ""},
                { "OD003_NOM_RAZAO_SOCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_SELECT_OD003_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1200_00_SELECT_OD007_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "OD007_NUM_PESSOA" , ""},
                { "OD007_SEQ_ENDERECO" , ""},
                { "OD007_NOM_LOGRADOURO" , ""},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , ""},
                { "OD007_NOM_BAIRRO" , ""},
                { "OD007_NOM_CIDADE" , ""},
                { "OD007_COD_CEP" , ""},
                { "OD007_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_OD007_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1210_00_SELECT_HISTSINI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_HISTSINI_DB_SELECT_1_Query1", q9);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SEM8020B_FILE_NAME_P", "PRD.EM.D241127.EM8006B.SIACC.txt", "MOV921286_CC_FILE_NAME_P")]
        public static void EM8020B_Tests_Theory(string SEM8020B_FILE_NAME_P, string MOVIMENTO_FILE_NAME_P, string MOV921286_CC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SEM8020B_FILE_NAME_P = $"{SEM8020B_FILE_NAME_P}_{timestamp}.txt";
            MOV921286_CC_FILE_NAME_P = $"{MOV921286_CC_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new EM8020B();
                program.Execute(SEM8020B_FILE_NAME_P, MOVIMENTO_FILE_NAME_P, MOV921286_CC_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList);

                var envList1 = AppSettings.TestSet.DynamicData["R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["R0350_00_SELECT_GE366_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

            }
        }
    }
}