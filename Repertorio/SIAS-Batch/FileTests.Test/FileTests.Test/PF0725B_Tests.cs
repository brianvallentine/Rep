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
using static Code.PF0725B;

namespace FileTests.Test
{
    [Collection("PF0725B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class PF0725B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-22"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1", q2);

            #endregion

            #region R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1", q4);

            #endregion

            #region R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q6);

            #endregion

            #region PF0725B_CPAGAMENTOS

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "W_PARC_ENDO" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0725B_CPAGAMENTOS", q7);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("MOVTO_STA_SASSE_FILE_NAME_P")]
        public static void PF0725B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                PF0725B_WS_PARAMETRO pF0725B_WS_PARAMETRO = new PF0725B_WS_PARAMETRO();
                pF0725B_WS_PARAMETRO.WS_PARAM_DAT.Value = "0000-00-00";

                #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion

                var program = new PF0725B();
                program.Execute(pF0725B_WS_PARAMETRO, MOVTO_STA_SASSE_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
            }
        }
    }
}