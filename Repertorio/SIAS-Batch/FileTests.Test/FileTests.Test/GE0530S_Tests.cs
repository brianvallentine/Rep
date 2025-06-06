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
using static Code.GE0530S;

namespace FileTests.Test
{
    [Collection("GE0530S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0530S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region GE0530S_C001

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE530_SEQ_PEPS" , ""},
                { "GE530_DTA_INIVIG_PEPS" , ""},
                { "GE530_DTA_FIMVIG_PEPS" , ""},
                { "GE530_COD_TP_PEPS" , ""},
                { "GE530_COD_PEPS_EXTERNO" , ""},
                { "GE530_COD_PEPS_RELACIONADO" , ""},
                { "GE530_NUM_CPF_CNPJ" , ""},
                { "GE530_NOM_PEPS" , ""},
                { "GE530_COD_ORGAO_PESS_PEPS" , ""},
                { "GE530_NOM_ORGAO_PEPS" , ""},
                { "GE530_COD_CARGO" , ""},
                { "GE530_NOM_CARGO" , ""},
                { "GE530_COD_COAF" , ""},
                { "GE530_IND_SEXO" , ""},
                { "GE530_NOM_LOGRADOURO" , ""},
                { "GE530_DES_LOGRADOURO" , ""},
                { "GE530_DES_COMPLEMENTO" , ""},
                { "GE530_NOM_BAIRRO" , ""},
                { "GE530_COD_CEP" , ""},
                { "GE530_NOM_MUNICIPIO" , ""},
                { "GE530_COD_UF" , ""},
                { "GE530_DTA_NOMEACAO" , ""},
                { "GE530_DTA_EXONERACAO" , ""},
                { "GE530_NOM_MUNICIPIO_ORGAO" , ""},
                { "GE530_COD_UF_ORGAO" , ""},
                { "GE530_COD_USUARIO" , ""},
                { "GE530_NOM_PROGRAMA" , ""},
                { "GE530_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0530S_C001", q0);

            #endregion

            #region GE0530S_C002

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE530_SEQ_PEPS" , ""},
                { "GE530_DTA_INIVIG_PEPS" , ""},
                { "GE530_DTA_FIMVIG_PEPS" , ""},
                { "GE530_COD_TP_PEPS" , ""},
                { "GE530_COD_PEPS_EXTERNO" , ""},
                { "GE530_COD_PEPS_RELACIONADO" , ""},
                { "GE530_NUM_CPF_CNPJ" , ""},
                { "GE530_NOM_PEPS" , ""},
                { "GE530_COD_ORGAO_PESS_PEPS" , ""},
                { "GE530_NOM_ORGAO_PEPS" , ""},
                { "GE530_COD_CARGO" , ""},
                { "GE530_NOM_CARGO" , ""},
                { "GE530_COD_COAF" , ""},
                { "GE530_IND_SEXO" , ""},
                { "GE530_NOM_LOGRADOURO" , ""},
                { "GE530_DES_LOGRADOURO" , ""},
                { "GE530_DES_COMPLEMENTO" , ""},
                { "GE530_NOM_BAIRRO" , ""},
                { "GE530_COD_CEP" , ""},
                { "GE530_NOM_MUNICIPIO" , ""},
                { "GE530_COD_UF" , ""},
                { "GE530_DTA_NOMEACAO" , ""},
                { "GE530_DTA_EXONERACAO" , ""},
                { "GE530_NOM_MUNICIPIO_ORGAO" , ""},
                { "GE530_COD_UF_ORGAO" , ""},
                { "GE530_COD_USUARIO" , ""},
                { "GE530_NOM_PROGRAMA" , ""},
                { "GE530_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GE0530S_C002", q1);

            #endregion

            #region R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE530_SEQ_PEPS" , ""},
                { "GE530_DTA_INIVIG_PEPS" , ""},
                { "GE530_DTA_FIMVIG_PEPS" , ""},
                { "GE530_COD_TP_PEPS" , ""},
                { "GE530_COD_PEPS_EXTERNO" , ""},
                { "GE530_COD_PEPS_RELACIONADO" , ""},
                { "GE530_NUM_CPF_CNPJ" , ""},
                { "GE530_NOM_PEPS" , ""},
                { "GE530_COD_ORGAO_PESS_PEPS" , ""},
                { "GE530_NOM_ORGAO_PEPS" , ""},
                { "GE530_COD_CARGO" , ""},
                { "GE530_NOM_CARGO" , ""},
                { "GE530_COD_COAF" , ""},
                { "GE530_IND_SEXO" , ""},
                { "GE530_NOM_LOGRADOURO" , ""},
                { "GE530_DES_LOGRADOURO" , ""},
                { "GE530_DES_COMPLEMENTO" , ""},
                { "GE530_NOM_BAIRRO" , ""},
                { "GE530_COD_CEP" , ""},
                { "GE530_NOM_MUNICIPIO" , ""},
                { "GE530_COD_UF" , ""},
                { "GE530_DTA_NOMEACAO" , ""},
                { "GE530_DTA_EXONERACAO" , ""},
                { "GE530_NOM_MUNICIPIO_ORGAO" , ""},
                { "GE530_COD_UF_ORGAO" , ""},
                { "GE530_COD_USUARIO" , ""},
                { "GE530_NOM_PROGRAMA" , ""},
                { "GE530_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1", q3);

            #endregion
            GE0531S_Tests.Load_Parameters();
            #endregion
        }

        [Fact]
        public static void GE0530S_Tests_FactLT1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2000-10-10"}
            });
                AppSettings.TestSet.DynamicData.Add("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GE530_SEQ_PEPS" , ""},
                { "GE530_DTA_INIVIG_PEPS" , "2000-10-10"},
                { "GE530_DTA_FIMVIG_PEPS" , "2000-10-10"},
                { "GE530_COD_TP_PEPS" , ""},
                { "GE530_COD_PEPS_EXTERNO" , ""},
                { "GE530_COD_PEPS_RELACIONADO" , ""},
                { "GE530_NUM_CPF_CNPJ" , ""},
                { "GE530_NOM_PEPS" , ""},
                { "GE530_COD_ORGAO_PESS_PEPS" , ""},
                { "GE530_NOM_ORGAO_PEPS" , ""},
                { "GE530_COD_CARGO" , ""},
                { "GE530_NOM_CARGO" , ""},
                { "GE530_COD_COAF" , ""},
                { "GE530_IND_SEXO" , ""},
                { "GE530_NOM_LOGRADOURO" , ""},
                { "GE530_DES_LOGRADOURO" , ""},
                { "GE530_DES_COMPLEMENTO" , ""},
                { "GE530_NOM_BAIRRO" , ""},
                { "GE530_COD_CEP" , ""},
                { "GE530_NOM_MUNICIPIO" , ""},
                { "GE530_COD_UF" , ""},
                { "GE530_DTA_NOMEACAO" , "2000-10-10"},
                { "GE530_DTA_EXONERACAO" , "2000-10-10"},
                { "GE530_NOM_MUNICIPIO_ORGAO" , ""},
                { "GE530_COD_UF_ORGAO" , ""},
                { "GE530_COD_USUARIO" , ""},
                { "GE530_NOM_PROGRAMA" , ""},
                { "GE530_DTH_CADASTRAMENTO" , "2000-10-10"},
            });
                AppSettings.TestSet.DynamicData.Add("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                var program = new GE0530S();
                var param = new LBGE0530_LK_GE0530();

                param.LK_GE0530_FUNCAO.Value = "LT1";

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO == 0);
            }
        }

        [Fact]
        public static void GE0530S_Tests_FactLT2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2000-10-10"}
            });
                AppSettings.TestSet.DynamicData.Add("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GE530_SEQ_PEPS" , ""},
                { "GE530_DTA_INIVIG_PEPS" , "2000-10-10"},
                { "GE530_DTA_FIMVIG_PEPS" , "2000-10-10"},
                { "GE530_COD_TP_PEPS" , ""},
                { "GE530_COD_PEPS_EXTERNO" , ""},
                { "GE530_COD_PEPS_RELACIONADO" , ""},
                { "GE530_NUM_CPF_CNPJ" , ""},
                { "GE530_NOM_PEPS" , ""},
                { "GE530_COD_ORGAO_PESS_PEPS" , ""},
                { "GE530_NOM_ORGAO_PEPS" , ""},
                { "GE530_COD_CARGO" , ""},
                { "GE530_NOM_CARGO" , ""},
                { "GE530_COD_COAF" , ""},
                { "GE530_IND_SEXO" , ""},
                { "GE530_NOM_LOGRADOURO" , ""},
                { "GE530_DES_LOGRADOURO" , ""},
                { "GE530_DES_COMPLEMENTO" , ""},
                { "GE530_NOM_BAIRRO" , ""},
                { "GE530_COD_CEP" , ""},
                { "GE530_NOM_MUNICIPIO" , ""},
                { "GE530_COD_UF" , ""},
                { "GE530_DTA_NOMEACAO" , "2000-10-10"},
                { "GE530_DTA_EXONERACAO" , "2000-10-10"},
                { "GE530_NOM_MUNICIPIO_ORGAO" , ""},
                { "GE530_COD_UF_ORGAO" , ""},
                { "GE530_COD_USUARIO" , ""},
                { "GE530_NOM_PROGRAMA" , ""},
                { "GE530_DTH_CADASTRAMENTO" , "2000-10-10"},
            });
                AppSettings.TestSet.DynamicData.Add("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                var program = new GE0530S();
                var param = new LBGE0530_LK_GE0530();

                param.LK_GE0530_FUNCAO.Value = "LT2";
                param.LK_GE0530_CPF_CNPJ.Value = 123;
                param.LK_GE0530_COD_FONTE.Value = 123;
                param.LK_GE0530_COD_PRODUTO.Value = 123;
                param.LK_GE0530_NUM_RAMO_EMISSOR.Value = 123;
                param.LK_GE0530_NUM_PROPOSTA.Value = 123;
                param.LK_GE0530_NUM_CERTIFIC_EXT.Value = 123;

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO == 0);
            }
        }
        [Fact]
        public static void GE0530S_Tests_FactErro()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE

                #region R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2000-10-10"}
            });
                AppSettings.TestSet.DynamicData.Add("R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GE530_SEQ_PEPS" , ""},
                { "GE530_DTA_INIVIG_PEPS" , "2000-10-10"},
                { "GE530_DTA_FIMVIG_PEPS" , "2000-10-10"},
                { "GE530_COD_TP_PEPS" , ""},
                { "GE530_COD_PEPS_EXTERNO" , ""},
                { "GE530_COD_PEPS_RELACIONADO" , ""},
                { "GE530_NUM_CPF_CNPJ" , ""},
                { "GE530_NOM_PEPS" , ""},
                { "GE530_COD_ORGAO_PESS_PEPS" , ""},
                { "GE530_NOM_ORGAO_PEPS" , ""},
                { "GE530_COD_CARGO" , ""},
                { "GE530_NOM_CARGO" , ""},
                { "GE530_COD_COAF" , ""},
                { "GE530_IND_SEXO" , ""},
                { "GE530_NOM_LOGRADOURO" , ""},
                { "GE530_DES_LOGRADOURO" , ""},
                { "GE530_DES_COMPLEMENTO" , ""},
                { "GE530_NOM_BAIRRO" , ""},
                { "GE530_COD_CEP" , ""},
                { "GE530_NOM_MUNICIPIO" , ""},
                { "GE530_COD_UF" , ""},
                { "GE530_DTA_NOMEACAO" , "2000-10-10"},
                { "GE530_DTA_EXONERACAO" , "2000-10-10"},
                { "GE530_NOM_MUNICIPIO_ORGAO" , ""},
                { "GE530_COD_UF_ORGAO" , ""},
                { "GE530_COD_USUARIO" , ""},
                { "GE530_NOM_PROGRAMA" , ""},
                { "GE530_DTH_CADASTRAMENTO" , "2000-10-10"},
            });
                AppSettings.TestSet.DynamicData.Add("R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1", q3);

                #endregion

                #endregion
                var program = new GE0530S();
                var param = new LBGE0530_LK_GE0530();

                param.LK_GE0530_FUNCAO.Value = "LT2";
                param.LK_GE0530_CPF_CNPJ.Value = 123;
                param.LK_GE0530_COD_FONTE.Value = 123;
                param.LK_GE0530_COD_PRODUTO.Value = 123;
                param.LK_GE0530_NUM_RAMO_EMISSOR.Value = 123;
                param.LK_GE0530_NUM_PROPOSTA.Value = 123;

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.LBGE0530.LK_GE0530.LK_GE0530_GERAL.LK_GE0530_COD_RETORNO == 10);
            }
        }
    }
}