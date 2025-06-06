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
using static Code.EM8021B;

namespace FileTests.Test
{
    [Collection("EM8021B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class EM8021B_Tests
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

            #region R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
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
                { "RALCHEDO_NUM_CHEQUE_INTERNO" , ""},
                { "RALCHEDO_AGENCIA_CONTRATO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CHEQUEMI_COD_FAVORECIDO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FORNECED_NOME_FORNECEDOR" , ""},
                { "FORNECED_ENDERECO" , ""},
                { "FORNECED_BAIRRO" , ""},
                { "FORNECED_CIDADE" , ""},
                { "FORNECED_SIGLA_UF" , ""},
                { "FORNECED_CEP" , ""},
                { "FORNECED_CGCCPF" , ""},
                { "FORNECED_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_SUREG" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_NUM_CONTRATO" , ""},
                { "SINCREIN_CONTRATO_DIGITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "APOLICRE_PROPRIET" , ""},
                { "APOLICRE_TIPO_PESSOA" , ""},
                { "APOLICRE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2025_00_ACESSA_SINIITEM_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2025_00_ACESSA_SINIITEM_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2040_00_ACESSA_ENDERECO1_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2040_00_ACESSA_ENDERECO1_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2050_00_ACESSA_ENDERECO2_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2050_00_ACESSA_ENDERECO2_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DES_COMPLEMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINIPENH_NUM_CONTRATO" , ""},
                { "SINIPENH_COD_AGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SINIHAB1_COD_UNO" , ""},
                { "SINIHAB1_PONTO_VENDA" , ""},
                { "SINIHAB1_NUM_CONTRATO" , ""},
                { "SINIHAB1_CGCCPF" , ""},
                { "SINIHAB1_NOME_SEGURADO" , ""},
                { "SINIHAB1_DATA_NASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MOVSINIH_AGE_INDENIZACAO" , ""},
                { "MOVSINIH_NOME_SEGURADO" , ""},
                { "MOVSINIH_CGCCPF" , ""},
                { "MOVSINIH_DTH_NASCIMENTO" , ""},
                { "MOVSINIH_NUM_CONTRATO_CEF" , ""},
                { "MOVSINIH_MATR_AGENTE" , ""},
                { "MOVSINIH_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1_Query1", q16);

            #endregion

            #region R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_COD_EMPRESA" , ""},
                { "PARAMCON_COD_BANCO" , ""},
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_COD_AGENCIA_SASS" , ""},
                { "PARAMCON_OPER_CONTA_SASS" , ""},
                { "PARAMCON_NUM_CONTA_SASS" , ""},
                { "PARAMCON_DIG_CONTA_SASS" , ""},
                { "PARAMCON_DATA_MOVIMENTO" , ""},
                { "PARAMCON_DATA_PROXIMO_DEB" , ""},
                { "PARAMCON_DIA_DEBITO" , ""},
                { "PARAMCON_SIT_REGISTRO" , ""},
                { "PARAMCON_TIMESTAMP" , ""},
                { "PARAMCON_DESCR_CONVENIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1", q17);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SEM8021B_FILE_NAME_P", "PRD.EM.D241127.EM8006B 1.SIACC", "MOV043350_CC_FILE_NAME_P")]
        public static void EM8021B_Tests_Theory(string SEM8021B_FILE_NAME_P, string MOVIMENTO_FILE_NAME_P, string MOV043350_CC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SEM8021B_FILE_NAME_P = $"{SEM8021B_FILE_NAME_P}_{timestamp}.txt";
            MOV043350_CC_FILE_NAME_P = $"{MOV043350_CC_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new EM8021B();
                program.Execute(SEM8021B_FILE_NAME_P, MOVIMENTO_FILE_NAME_P, MOV043350_CC_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1"].DynamicList;

                Assert.Empty(envList);
                Assert.Empty(envList1);
                Assert.Empty(envList2);
            }
        }
    }
}