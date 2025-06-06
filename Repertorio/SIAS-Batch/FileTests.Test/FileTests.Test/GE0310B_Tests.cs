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
using Dclgens;
using Code;
using static Code.GE0310B;
using IBM.Data.DB2Types;

namespace FileTests.Test
{

    [Collection("GE0310B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class GE0310B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "PARAMGER_COD_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""},
                { "PARAMGER_COD_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1", q1);

            #endregion

            #region RT_SELECT_TP_SERV_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE612_SEQ_TP_SERVICO_INSS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("RT_SELECT_TP_SERV_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0310B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                GEJVS002_Tests.Load_Parameters();
             
                #region GEJVS002_GE074_CURSOR

                var q = new DynamicData();
                q.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "2020-01-01"},
                { "PARAMGER_DATA_TERVIGENCIA" , "2020-01-01"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "2"},
                { "PARAMGER_COD_AGENCIA" , "3"},
                { "PARAMGER_OPCAO_BANCO" , "4"},
                { "PARAMGER_DIF_PREMIOS" , "5"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "6"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "7"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "2020-01-01"},
                { "PARAMGER_CAPITAL_SOCIAL" , "8"},
                { "PARAMGER_CAPITAL_REALIZADO" , "9"},
                { "PARAMGER_CAPITAL_VINCULADO" , "10"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "11"},
                { "PARAMGER_CODIGO_LIDER" , "12"},
                { "PARAMGER_NUM_RELACAO" , "13"},
                { "PARAMGER_COD_EMPRESA" , "14"},
                { "PARAMGER_COD_CGCCPF" , "15"},
                { "PARAMGER_COD_EMPRESA_CAP" , "16"},
            });
                AppSettings.TestSet.DynamicData.Remove("GEJVS002_GE074_CURSOR");
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q);
                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "1"},
                { "PARAMGER_COD_CGCCPF" , "34020354000110"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "1"},
                { "PARAMGER_COD_CGCCPF" , "34020354000110"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1", q1);

                #endregion

                #region RT_SELECT_TP_SERV_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GE612_SEQ_TP_SERVICO_INSS" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("RT_SELECT_TP_SERV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("RT_SELECT_TP_SERV_DB_SELECT_1_Query1", q2);

                #endregion
                
                #endregion

                var program = new GE0310B();
                GE0310B_REGISTRO_LINKAGE obj = new GE0310B_REGISTRO_LINKAGE();
                obj.LK_AGENCIA.Value = 1;
                obj.LK_CONTA.Value = 1;
                obj.LK_NUM_APOLICE.Value = 123;
                obj.LK_CODIGO_INSS.Value = 5;
                obj.LK_DESC_INSS.Value = "S";
                obj.LK_ALIQUOTA_INSS.Value = 0;
                obj.LK_COD_PRODUTO.Value = 0;
                obj.LK_PASSO.Value = "X";
                obj.LK_OPC_PAG.Value = "1";
                obj.LK_PROGRAMA.Value = "GE0310B";
                obj.LK_COD_USER.Value = "1";
                obj.LK_NOME_USER.Value = "GE0310B";
                obj.LK_COD_LOTE.Value = 10;
                obj.LK_DEPTO_DEST.Value = "x";
                obj.LK_TIPO_DOC_FISC.Value = 10;
                obj.LK_DESC_DOC_FISC.Value = "GE0310B";
                obj.LK_VLR_NAO_RET.Value = 1;
                obj.LK_VALOR_DOC_FISC.Value = 1;
                obj.LK_NUM_DOC_FISC.Value= 1;
                obj.LK_SERIE_DOC_FISC.Value = "X";
                obj.LK_DATA_EMIS.Value = "2025-05-16";
                obj.LK_DESC_LOTE.Value = "X";
                obj.LK_FONTE.Value = 10;
                obj.LK_CNPJ_CONTR.Value = 34020354000110;
                obj.LK_QTDE_LANC.Value = 10;
                obj.LK_VALOR_TOTAL_LOTE.Value = 1;
                obj.LK_OPCAO_LOTE.Value = "V";
                obj.LK_ISENTO_IMP.Value = "N";
                obj.LK_IND_DESC_INSS.Value = "N";

                program.Execute(obj);

                //obj.LK_COD_PRODUTO.Value = 5;

                /*var envList1 = AppSettings.TestSet.DynamicData["R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList1);*/

                //obj.LK_COD_PRODUTO.Value = 0;
                var envList2 = AppSettings.TestSet.DynamicData["R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["RT_SELECT_TP_SERV_DB_SELECT_1_Query1"].DynamicList;
                Assert.Empty(envList3);



                Assert.True(program.AREA_DE_WORK.WSL_SQLCODE == 0);
            }
        }

        [Fact]
        public static void GE0310B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                GEJVS002_Tests.Load_Parameters();

                #region GEJVS002_GE074_CURSOR

                var q = new DynamicData();
                q.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "2020-01-01"},
                { "PARAMGER_DATA_TERVIGENCIA" , "2020-01-01"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "2"},
                { "PARAMGER_COD_AGENCIA" , "3"},
                { "PARAMGER_OPCAO_BANCO" , "4"},
                { "PARAMGER_DIF_PREMIOS" , "5"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "6"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "7"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "2020-01-01"},
                { "PARAMGER_CAPITAL_SOCIAL" , "8"},
                { "PARAMGER_CAPITAL_REALIZADO" , "9"},
                { "PARAMGER_CAPITAL_VINCULADO" , "10"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "11"},
                { "PARAMGER_CODIGO_LIDER" , "12"},
                { "PARAMGER_NUM_RELACAO" , "13"},
                { "PARAMGER_COD_EMPRESA" , "14"},
                { "PARAMGER_COD_CGCCPF" , "15"},
                { "PARAMGER_COD_EMPRESA_CAP" , "16"},
            });
                AppSettings.TestSet.DynamicData.Remove("GEJVS002_GE074_CURSOR");
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q);
                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1", q1);

                #endregion

                #region RT_SELECT_TP_SERV_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GE612_SEQ_TP_SERVICO_INSS" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("RT_SELECT_TP_SERV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("RT_SELECT_TP_SERV_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion

                var program = new GE0310B();
                GE0310B_REGISTRO_LINKAGE obj = new GE0310B_REGISTRO_LINKAGE();
                obj.LK_AGENCIA.Value = 1;
                obj.LK_CONTA.Value = 1;
                obj.LK_NUM_APOLICE.Value = 123;
                obj.LK_CODIGO_INSS.Value = 0;
                obj.LK_DESC_INSS.Value = "S";
                obj.LK_ALIQUOTA_INSS.Value = 0;
                obj.LK_COD_PRODUTO.Value = 0;
                obj.LK_PASSO.Value = "X";
                obj.LK_OPC_PAG.Value = "1";
                obj.LK_PROGRAMA.Value = "GE0310B";
                obj.LK_COD_USER.Value = "1";
                obj.LK_NOME_USER.Value = "GE0310B";
                obj.LK_COD_LOTE.Value = 10;
                obj.LK_DEPTO_DEST.Value = "x";
                obj.LK_TIPO_DOC_FISC.Value = 10;
                obj.LK_DESC_DOC_FISC.Value = "GE0310B";
                obj.LK_VLR_NAO_RET.Value = 1;
                obj.LK_VALOR_DOC_FISC.Value = 1;
                obj.LK_NUM_DOC_FISC.Value = 1;
                obj.LK_SERIE_DOC_FISC.Value = "S";
                obj.LK_DATA_EMIS.Value = "2020-05-16";
                obj.LK_DESC_LOTE.Value = "X";
                obj.LK_FONTE.Value = 10;
                obj.LK_CNPJ_CONTR.Value = 34020354000110;
                obj.LK_QTDE_LANC.Value = 10;
                obj.LK_VALOR_TOTAL_LOTE.Value = 0;
                obj.LK_OPCAO_LOTE.Value = "V";
                obj.LK_ISENTO_IMP.Value = "N";
                obj.LK_IND_DESC_INSS.Value = "N";

                program.Execute(obj);


                Assert.True(program.AREA_DE_WORK.WSL_SQLCODE != 0);
            }
        }


    }
}
