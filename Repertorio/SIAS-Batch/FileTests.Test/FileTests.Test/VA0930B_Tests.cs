using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VA0930B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0930B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VA0930B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTHOJE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0930B_TRELAT

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0930B_TRELAT", q1);

            #endregion

            #region R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0BILH_NUM_APOLICE" , ""},
                { "V0BILH_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_CODCLIEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1", q4);

            #endregion

            #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NOMPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1", q6);

            #endregion

            #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NOMPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1", q7);

            #endregion

            #region R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , ""},
                { "V0CLIE_CGCCPF" , ""},
                { "V0CLIE_TIPO_PESSOA" , ""},
                { "V0CLIE_DATA_NASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0USUA_NOMUSU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1", q11);

            #endregion

            #region R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "DEVOLVID_COD_DEVOLUCAO" , ""},
                { "DEVOLVID_DESC_DEVOLUCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1", q14);

            #endregion

            #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1", q16);

            #endregion

            #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1", q17);

            #endregion

            #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1", q18);

            #endregion

            #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1", q20);

            #endregion

            #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "SEGURHIS_COD_OPERACAO" , ""},
                { "SEGURHIS_DATA_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1", q22);

            #endregion

            #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1", q23);

            #endregion

            #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1", q24);

            #endregion

            #region R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1", q25);

            #endregion

            #region R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1", q26);

            #endregion

            #region R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_PROFISSAO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1", q28);

            #endregion

            #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1", q29);

            #endregion

            #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1", q30);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0930B_o1", "VA0930B_o2")]
        public static void VA0930B_Tests_Selects1_Theory(string SVA0930B_FILE_NAME_P, string AVA0930B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                SVA0930B_FILE_NAME_P = $"{SVA0930B_FILE_NAME_P}_{timestamp}.txt";
                AVA0930B_FILE_NAME_P = $"{AVA0930B_FILE_NAME_P}_{timestamp}.txt";

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""},
                    { "V1SIST_DTHOJE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0930B_TRELAT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_NUM_APOLICE" , ""},
                    { "RELATORI_COD_SUBGRUPO" , ""},
                    { "RELATORI_NUM_CERTIFICADO" , ""},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "RELATORI_IDE_SISTEMA" , ""},
                    { "RELATORI_COD_RELATORIO" , "CB52A"},
                    { "RELATORI_NUM_COPIAS" , ""},
                    { "RELATORI_QUANTIDADE" , ""},
                    { "RELATORI_TIPO_CORRECAO" , ""},
                    { "RELATORI_IND_PREV_DEFINIT" , ""},
                    { "RELATORI_NUM_ENDOSSO" , ""},
                    { "RELATORI_NUM_TITULO" , ""},
                    { "RELATORI_NUM_PARCELA" , ""},
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_NUM_ORDEM" , ""},
                    { "RELATORI_COD_OPERACAO" , ""},
                    { "RELATORI_NUM_APOL_LIDER" , ""},
                    { "RELATORI_ENDOS_LIDER" , ""},
                    { "RELATORI_NUM_SINI_LIDER" , ""},
                    { "RELATORI_COD_PRODUTOR" , ""},
                    { "RELATORI_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0930B_TRELAT");
                AppSettings.TestSet.DynamicData.Add("VA0930B_TRELAT", q1);

                #endregion

                #region R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0BILH_NUM_APOLICE" , ""},
                    { "V0BILH_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "TERMOADE_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1", q7);

                #endregion

                #region R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CLIE_NOME_RAZAO" , ""},
                    { "V0CLIE_CGCCPF" , ""},
                    { "V0CLIE_TIPO_PESSOA" , ""},
                    { "V0CLIE_DATA_NASC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0USUA_NOMUSU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SUBGRU_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1", q11);

                #endregion

                #region R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "APOLICOB_NUM_APOLICE" , ""},
                    { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "DEVOLVID_COD_DEVOLUCAO" , ""},
                    { "DEVOLVID_DESC_DEVOLUCAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1", q14);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_APOLICE" , ""},
                    { "PROPOVA_COD_SUBGRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "COBHISVI_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1", q16);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "CONDITEC_CARREGA_CONJUGE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1", q17);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1", q18);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_APOLICE" , ""},
                    { "SEGURVGA_NUM_ITEM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1", q20);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "SEGURHIS_COD_OPERACAO" , ""},
                    { "SEGURHIS_DATA_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1", q22);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1", q23);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1", q24);

                #endregion

                #region R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                    { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                    { "MOVIMVGA_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "HISLANCT_DATA_VENCIMENTO" , ""},
                    { "HISLANCT_PRM_TOTAL" , ""},
                    { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                    { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                    { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                    { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                    { "HISLANCT_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_PROFISSAO" , ""},
                    { "PROPOVA_DTPROXVEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , ""},
                    { "ENDERECO_BAIRRO" , ""},
                    { "ENDERECO_CIDADE" , ""},
                    { "ENDERECO_SIGLA_UF" , ""},
                    { "ENDERECO_CEP" , ""},
                    { "ENDERECO_DDD" , ""},
                    { "ENDERECO_TELEFONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1", q30);

                #endregion

                #endregion
                #endregion
                var program = new VA0930B();
                program.Execute(new VA0930B_LK_PARAMETRO(), SVA0930B_FILE_NAME_P, AVA0930B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA0930B.FilePath));
                Assert.True(new FileInfo(program.AVA0930B.FilePath).Length > 0);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1")).ToList());

                Assert.Equal(0, program.RETURN_CODE.Value);
            }
        }

        [Theory]
        [InlineData("VA0930B_o3", "VA0930B_o4")]
        public static void VA0930B_Tests_Selects2_Theory(string SVA0930B_FILE_NAME_P, string AVA0930B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                SVA0930B_FILE_NAME_P = $"{SVA0930B_FILE_NAME_P}_{timestamp}.txt";
                AVA0930B_FILE_NAME_P = $"{AVA0930B_FILE_NAME_P}_{timestamp}.txt";

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""},
                    { "V1SIST_DTHOJE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0930B_TRELAT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_NUM_APOLICE" , ""},
                    { "RELATORI_COD_SUBGRUPO" , ""},
                    { "RELATORI_NUM_CERTIFICADO" , "1"},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "RELATORI_IDE_SISTEMA" , ""},
                    { "RELATORI_COD_RELATORIO" , "VLNOA"},
                    { "RELATORI_NUM_COPIAS" , ""},
                    { "RELATORI_QUANTIDADE" , ""},
                    { "RELATORI_TIPO_CORRECAO" , ""},
                    { "RELATORI_IND_PREV_DEFINIT" , ""},
                    { "RELATORI_NUM_ENDOSSO" , ""},
                    { "RELATORI_NUM_TITULO" , ""},
                    { "RELATORI_NUM_PARCELA" , ""},
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_NUM_ORDEM" , ""},
                    { "RELATORI_COD_OPERACAO" , ""},
                    { "RELATORI_NUM_APOL_LIDER" , ""},
                    { "RELATORI_ENDOS_LIDER" , ""},
                    { "RELATORI_NUM_SINI_LIDER" , ""},
                    { "RELATORI_COD_PRODUTOR" , ""},
                    { "RELATORI_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0930B_TRELAT");
                AppSettings.TestSet.DynamicData.Add("VA0930B_TRELAT", q1);

                #endregion

                #region R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0BILH_NUM_APOLICE" , ""},
                    { "V0BILH_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "TERMOADE_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1", q7);

                #endregion

                #region R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CLIE_NOME_RAZAO" , ""},
                    { "V0CLIE_CGCCPF" , ""},
                    { "V0CLIE_TIPO_PESSOA" , ""},
                    { "V0CLIE_DATA_NASC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0USUA_NOMUSU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SUBGRU_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1", q11);

                #endregion

                #region R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "APOLICOB_NUM_APOLICE" , ""},
                    { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "DEVOLVID_COD_DEVOLUCAO" , ""},
                    { "DEVOLVID_DESC_DEVOLUCAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1", q14);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_APOLICE" , ""},
                    { "PROPOVA_COD_SUBGRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "COBHISVI_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1", q16);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "CONDITEC_CARREGA_CONJUGE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1", q17);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1", q18);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_APOLICE" , ""},
                    { "SEGURVGA_NUM_ITEM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1", q20);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "SEGURHIS_COD_OPERACAO" , ""},
                    { "SEGURHIS_DATA_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1", q22);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1", q23);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1", q24);

                #endregion

                #region R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                    { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                    { "MOVIMVGA_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "HISLANCT_DATA_VENCIMENTO" , ""},
                    { "HISLANCT_PRM_TOTAL" , ""},
                    { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                    { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                    { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                    { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                    { "HISLANCT_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_PROFISSAO" , ""},
                    { "PROPOVA_DTPROXVEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , ""},
                    { "ENDERECO_BAIRRO" , ""},
                    { "ENDERECO_CIDADE" , ""},
                    { "ENDERECO_SIGLA_UF" , ""},
                    { "ENDERECO_CEP" , ""},
                    { "ENDERECO_DDD" , ""},
                    { "ENDERECO_TELEFONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1", q30);

                #endregion

                #endregion
                #endregion
                var program = new VA0930B();
                program.Execute(new VA0930B_LK_PARAMETRO(), SVA0930B_FILE_NAME_P, AVA0930B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA0930B.FilePath));
                Assert.True(new FileInfo(program.AVA0930B.FilePath).Length > 0);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1")).ToList());

                Assert.Equal(0, program.RETURN_CODE.Value);
            }
        }

        [Theory]
        [InlineData("VA0930B_o5", "VA0930B_o6")]
        public static void VA0930B_Tests_Selects3_Theory(string SVA0930B_FILE_NAME_P, string AVA0930B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                SVA0930B_FILE_NAME_P = $"{SVA0930B_FILE_NAME_P}_{timestamp}.txt";
                AVA0930B_FILE_NAME_P = $"{AVA0930B_FILE_NAME_P}_{timestamp}.txt";

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""},
                    { "V1SIST_DTHOJE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0930B_TRELAT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_NUM_APOLICE" , ""},
                    { "RELATORI_COD_SUBGRUPO" , ""},
                    { "RELATORI_NUM_CERTIFICADO" , "0"},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "RELATORI_IDE_SISTEMA" , ""},
                    { "RELATORI_COD_RELATORIO" , "VLNOA"},
                    { "RELATORI_NUM_COPIAS" , ""},
                    { "RELATORI_QUANTIDADE" , ""},
                    { "RELATORI_TIPO_CORRECAO" , ""},
                    { "RELATORI_IND_PREV_DEFINIT" , ""},
                    { "RELATORI_NUM_ENDOSSO" , ""},
                    { "RELATORI_NUM_TITULO" , ""},
                    { "RELATORI_NUM_PARCELA" , ""},
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_NUM_ORDEM" , ""},
                    { "RELATORI_COD_OPERACAO" , ""},
                    { "RELATORI_NUM_APOL_LIDER" , ""},
                    { "RELATORI_ENDOS_LIDER" , ""},
                    { "RELATORI_NUM_SINI_LIDER" , ""},
                    { "RELATORI_COD_PRODUTOR" , ""},
                    { "RELATORI_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0930B_TRELAT");
                AppSettings.TestSet.DynamicData.Add("VA0930B_TRELAT", q1);

                #endregion

                #region R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0BILH_NUM_APOLICE" , ""},
                    { "V0BILH_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "TERMOADE_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1", q7);

                #endregion

                #region R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CLIE_NOME_RAZAO" , ""},
                    { "V0CLIE_CGCCPF" , ""},
                    { "V0CLIE_TIPO_PESSOA" , ""},
                    { "V0CLIE_DATA_NASC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0USUA_NOMUSU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SUBGRU_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1", q11);

                #endregion

                #region R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "APOLICOB_NUM_APOLICE" , ""},
                    { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "DEVOLVID_COD_DEVOLUCAO" , ""},
                    { "DEVOLVID_DESC_DEVOLUCAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1", q14);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_APOLICE" , ""},
                    { "PROPOVA_COD_SUBGRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "COBHISVI_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1", q16);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "CONDITEC_CARREGA_CONJUGE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1", q17);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1", q18);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_APOLICE" , ""},
                    { "SEGURVGA_NUM_ITEM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1", q20);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "SEGURHIS_COD_OPERACAO" , ""},
                    { "SEGURHIS_DATA_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1", q22);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1", q23);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1", q24);

                #endregion

                #region R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                    { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                    { "MOVIMVGA_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "HISLANCT_DATA_VENCIMENTO" , ""},
                    { "HISLANCT_PRM_TOTAL" , ""},
                    { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                    { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                    { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                    { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                    { "HISLANCT_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_PROFISSAO" , ""},
                    { "PROPOVA_DTPROXVEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , ""},
                    { "ENDERECO_BAIRRO" , ""},
                    { "ENDERECO_CIDADE" , ""},
                    { "ENDERECO_SIGLA_UF" , ""},
                    { "ENDERECO_CEP" , ""},
                    { "ENDERECO_DDD" , ""},
                    { "ENDERECO_TELEFONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1", q30);

                #endregion

                #endregion
                #endregion
                var program = new VA0930B();
                program.Execute(new VA0930B_LK_PARAMETRO(), SVA0930B_FILE_NAME_P, AVA0930B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA0930B.FilePath));
                Assert.True(new FileInfo(program.AVA0930B.FilePath).Length > 0);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1")).ToList());
                Assert.NotEmpty(selects.Where(x => x.Key.Equals("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1")).ToList());

                Assert.Equal(0, program.RETURN_CODE.Value);
            }
        }

        [Theory]
        [InlineData("VA0930B_o7", "VA0930B_o8")]
        public static void VA0930B_Tests_ReturnCode99_Theory(string SVA0930B_FILE_NAME_P, string AVA0930B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                SVA0930B_FILE_NAME_P = $"{SVA0930B_FILE_NAME_P}_{timestamp}.txt";
                AVA0930B_FILE_NAME_P = $"{AVA0930B_FILE_NAME_P}_{timestamp}.txt";

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""},
                    { "V1SIST_DTHOJE" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VA0930B_TRELAT

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_NUM_APOLICE" , ""},
                    { "RELATORI_COD_SUBGRUPO" , ""},
                    { "RELATORI_NUM_CERTIFICADO" , "0"},
                    { "RELATORI_DATA_SOLICITACAO" , ""},
                    { "RELATORI_IDE_SISTEMA" , ""},
                    { "RELATORI_COD_RELATORIO" , "VLNOA"},
                    { "RELATORI_NUM_COPIAS" , ""},
                    { "RELATORI_QUANTIDADE" , ""},
                    { "RELATORI_TIPO_CORRECAO" , ""},
                    { "RELATORI_IND_PREV_DEFINIT" , ""},
                    { "RELATORI_NUM_ENDOSSO" , ""},
                    { "RELATORI_NUM_TITULO" , ""},
                    { "RELATORI_NUM_PARCELA" , ""},
                    { "RELATORI_COD_USUARIO" , ""},
                    { "RELATORI_NUM_ORDEM" , ""},
                    { "RELATORI_COD_OPERACAO" , ""},
                    { "RELATORI_NUM_APOL_LIDER" , ""},
                    { "RELATORI_ENDOS_LIDER" , ""},
                    { "RELATORI_NUM_SINI_LIDER" , ""},
                    { "RELATORI_COD_PRODUTOR" , ""},
                    { "RELATORI_COD_EMPRESA" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VA0930B_TRELAT");
                AppSettings.TestSet.DynamicData.Add("VA0930B_TRELAT", q1);

                #endregion

                #region R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0BILH_NUM_APOLICE" , ""},
                    { "V0BILH_CODCLIEN" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_APOLICE" , ""},
                    { "V0PROP_CODSUBES" , ""},
                    { "V0PROP_CODCLIEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1", q4);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "TERMOADE_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1", q6);

                #endregion

                #region R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_CODPRODU" , ""},
                    { "V0PROP_NOMPRODU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1", q7);

                #endregion

                #region R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0CLIE_NOME_RAZAO" , ""},
                    { "V0CLIE_CGCCPF" , ""},
                    { "V0CLIE_TIPO_PESSOA" , ""},
                    { "V0CLIE_DATA_NASC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0USUA_NOMUSU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SUBGRU_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V0PROP_NRCERTIF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1", q11);

                #endregion

                #region R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "APOLICOB_NUM_APOLICE" , ""},
                    { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "DEVOLVID_COD_DEVOLUCAO" , ""},
                    { "DEVOLVID_DESC_DEVOLUCAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "WS_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1", q14);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_APOLICE" , ""},
                    { "PROPOVA_COD_SUBGRUPO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "COBHISVI_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1", q16);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "CONDITEC_CARREGA_CONJUGE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1", q17);

                #endregion

                #region R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1", q18);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "SEGURVGA_NUM_APOLICE" , ""},
                    { "SEGURVGA_NUM_ITEM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1", q20);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1", q21);

                #endregion

                #region R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "SEGURHIS_COD_OPERACAO" , ""},
                    { "SEGURHIS_DATA_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1", q22);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                    { "OPCPAGVI_DIA_DEBITO" , ""},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1", q23);

                #endregion

                #region R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1", q24);

                #endregion

                #region R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                    { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                    { "MOVIMVGA_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1", q26);

                #endregion

                #region R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "HISLANCT_DATA_VENCIMENTO" , ""},
                    { "HISLANCT_PRM_TOTAL" , ""},
                    { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                    { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                    { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                    { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                    { "HISLANCT_SIT_REGISTRO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1", q27);

                #endregion

                #region R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_PROFISSAO" , ""},
                    { "PROPOVA_DTPROXVEN" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1", q28);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "WS_COD_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1", q29);

                #endregion

                #region R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , ""},
                    { "ENDERECO_BAIRRO" , ""},
                    { "ENDERECO_CIDADE" , ""},
                    { "ENDERECO_SIGLA_UF" , ""},
                    { "ENDERECO_CEP" , ""},
                    { "ENDERECO_DDD" , ""},
                    { "ENDERECO_TELEFONE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1", q30);

                #endregion

                #endregion
                #endregion
                var program = new VA0930B();
                program.Execute(new VA0930B_LK_PARAMETRO(), SVA0930B_FILE_NAME_P, AVA0930B_FILE_NAME_P);

                Assert.Equal(99, program.RETURN_CODE.Value);
            }
        }
    }
}