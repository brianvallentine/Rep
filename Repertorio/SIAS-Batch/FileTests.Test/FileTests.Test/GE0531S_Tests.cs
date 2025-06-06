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
using static Code.GE0531S;

namespace FileTests.Test
{
    [Collection("GE0531S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0531S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE615_NUM_CPF_CNPJ" , ""},
                { "GE615_SEQ_REGISTRO" , ""},
                { "GE615_NUM_CERTIFICADO_EXT" , ""},
                { "GE615_DTA_INCLUSAO" , ""},
                { "GE615_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_PESSOA_LOG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE615_NUM_CPF_CNPJ" , ""},
                { "GE615_SEQ_REGISTRO" , ""},
                { "GE615_NUM_RAMO_EMISSOR" , ""},
                { "GE615_COD_PRODUTO" , ""},
                { "GE615_COD_FONTE" , ""},
                { "GE615_NUM_PROPOSTA" , ""},
                { "GE615_NUM_CERTIFICADO_EXT" , ""},
                { "GE615_NUM_APOLICE" , ""},
                { "GE615_NUM_ENDOSSO" , ""},
                { "GE615_NUM_SINISTRO" , ""},
                { "GE615_OCORR_HISTORICO" , ""},
                { "GE615_COD_OPER_SINISTRO" , ""},
                { "GE615_NOM_SEGURADO" , ""},
                { "GE615_COD_CARGO" , ""},
                { "GE615_DES_CARGO" , ""},
                { "GE615_NOM_ORGAO" , ""},
                { "GE615_COD_RELACAO_EXTERNO" , ""},
                { "GE615_IND_TP_RELAC_INTERNO" , ""},
                { "GE615_IND_TIPO_PESSOA" , ""},
                { "GE615_IND_MOVIMENTO" , ""},
                { "GE615_IND_EVENTO" , ""},
                { "GE615_DTA_INCLUSAO" , ""},
                { "GE615_STA_REGISTRO" , ""},
                { "GE615_COD_ORIGEM" , ""},
                { "GE615_COD_USUARIO" , ""},
                { "GE615_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0531S_Tests_Fact1()
        {
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
                var program = new GE0531S();
                var param = new LBGE0531_LK_GE0531();

                param.LK_GE0531_CPF_CNPJ.Value = 123;
                param.LK_GE0531_COD_FONTE.Value = 123;
                param.LK_GE0531_COD_PRODUTO.Value = 123;
                param.LK_GE0531_NUM_RAMO_EMISSOR.Value = 123;
                param.LK_GE0531_NUM_PROPOSTA.Value = 123;
                param.LK_GE0531_NUM_CERTIFIC_EXT.Value = 123;

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE615_NUM_CPF_CNPJ", out var valor) && valor == "000000000000000123");

                Assert.True(program.LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO == 0);
            }
        }
        [Fact]
        public static void GE0531S_Tests_FactErro()
        {
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
                var program = new GE0531S();

                program.Execute(new LBGE0531_LK_GE0531());

                Assert.True(program.LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO == 02);
            }
        }
    }
}