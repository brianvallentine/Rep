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
using static Code.VE0414B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VE0414B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0414B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "WHOST_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VE0414B_CFAIXACEP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DCLGE_FAIXA_CEP_GEFAICEP_FAIXA" , ""},
                { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL" , ""},
                { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL" , ""},
                { "DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA" , ""},
                { "DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0414B_CFAIXACEP", q1);

            #endregion

            #region VE0414B_V1AGENCEF

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
                { "DCLFONTES_FONTES_NOME_FONTE" , ""},
                { "DCLFONTES_FONTES_ENDERECO" , ""},
                { "DCLFONTES_FONTES_BAIRRO" , ""},
                { "DCLFONTES_FONTES_CIDADE" , ""},
                { "DCLFONTES_FONTES_CEP" , ""},
                { "DCLFONTES_FONTES_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0414B_V1AGENCEF", q2);

            #endregion

            #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q4);

            #endregion

            #region VE0414B_CRELAT

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "DCLRELATORIOS_RELATORI_NUM_TITULO" , ""},
                { "DCLRELATORIOS_RELATORI_NUM_APOLICE" , ""},
                { "DCLRELATORIOS_RELATORI_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0414B_CRELAT", q5);

            #endregion

            #region VE0414B_CADIC

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_NUM_GARANTIA" , ""},
                { "VGARANTI_DES_GARANTIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0414B_CADIC", q6);

            #endregion

            #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , ""},
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_COD_SUBGRUPO" , ""},
                { "TERMOADE_DATA_ADESAO" , ""},
                { "TERMOADE_COD_AGENCIA_OP" , ""},
                { "TERMOADE_MODALIDADE_CAPITAL" , ""},
                { "TERMOADE_TIPO_PLANO" , ""},
                { "TERMOADE_COD_PLANO_VGAPC" , ""},
                { "TERMOADE_COD_PLANO_APC" , ""},
                { "TERMOADE_VAL_CONTRATADO" , ""},
                { "TERMOADE_VAL_RCAP" , ""},
                { "TERMOADE_QUANT_VIDAS" , ""},
                { "TERMOADE_TIPO_COBERTURA" , ""},
                { "TERMOADE_PERI_PAGAMENTO" , ""},
                { "TERMOADE_COD_CLIENTE" , ""},
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""},
                { "VGCOMTRO_DTH_DIA_DEBITO" , ""},
                { "VGCOMTRO_COD_AGENCIA_DEB" , ""},
                { "VGCOMTRO_OPERACAO_CONTA_DEB" , ""},
                { "VGCOMTRO_NUM_CONTA_DEBITO" , ""},
                { "VGCOMTRO_DIG_CONTA_DEBITO" , ""},
                { "VGCOMTRO_NUM_CARTAO_CREDITO" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO_EMP" , ""},
                { "VGPROSIA_COD_PRODUTO" , ""},
                { "PRODUTO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , ""},
                { "MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1", q12);

            #endregion

            #region SEGUROS_SPBVG012_Call1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO_FC12" , ""},
                { "LK_NUM_PROPOSTA_FC12" , ""},
                { "LK_COD_RAMO_FC12" , ""},
                { "LK_TRACE_FC12" , ""},
                { "LK_OUT_COD_RET_FC12" , ""},
                { "LK_OUT_SQLCODE_FC12" , ""},
                { "LK_OUT_MENSAGEM_FC12" , ""},
                { "LK_OUT_SQLERRMC_FC12" , ""},
                { "LK_OUT_SQLSTATE_FC12" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q13);

            #endregion

            #region R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q15);

            #endregion

            #region R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1", q17);

            #endregion

            #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1", q18);

            #endregion

            #region R4000_00_GERA_OBJETO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1", q19);

            #endregion

            #region R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , ""},
                { "GEOBJECT_COD_FORMULARIO" , ""},
                { "GEOBJECT_STA_REGISTRO" , ""},
                { "GEOBJECT_COD_PRODUTO" , ""},
                { "GEOBJECT_NUM_INI_POS_VERSO" , ""},
                { "GEOBJECT_QTD_PESO_GRAMAS" , ""},
                { "GEOBJECT_VLR_DECLARADO" , ""},
                { "GEOBJECT_COD_IDENT_OBJETO" , ""},
                { "GEOBJECT_DES_OBJETO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q22);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VE0414B_o1", "VE0414B_o2", "VE0414B_o3", "VE0414B_o4", "VE0414B_o5", "VE0414B_o6")]
        public static void VE0414B_Tests_Theory(string RVE0414B_FILE_NAME_P, string RVE0414I_FILE_NAME_P, string RVE0414P_FILE_NAME_P, string RVE0414H_FILE_NAME_P, string SVE0414B_FILE_NAME_P, string FVE0414B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                RVE0414B_FILE_NAME_P = $"{RVE0414B_FILE_NAME_P}_{timestamp}.txt";
                RVE0414I_FILE_NAME_P = $"{RVE0414I_FILE_NAME_P}_{timestamp}.txt";
                RVE0414P_FILE_NAME_P = $"{RVE0414P_FILE_NAME_P}_{timestamp}.txt";
                RVE0414H_FILE_NAME_P = $"{RVE0414H_FILE_NAME_P}_{timestamp}.txt";
                SVE0414B_FILE_NAME_P = $"{SVE0414B_FILE_NAME_P}_{timestamp}.txt";
                FVE0414B_FILE_NAME_P = $"{FVE0414B_FILE_NAME_P}_{timestamp}.txt";

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                    { "V1SIST_MESREFER" , "12" },
                    { "V1SIST_ANOREFER" , "2023" },
                    { "WHOST_DATA_MOV_ABERTO" , "2023-12-01" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0414B_CFAIXACEP

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "DCLGE_FAIXA_CEP_GEFAICEP_FAIXA" , "1" },
                    { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL" , "01000-000" },
                    { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL" , "02000-000" },
                    { "DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA" , "São Paulo - Centro" },
                    { "DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR" , "São Paulo" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0414B_CFAIXACEP");
                AppSettings.TestSet.DynamicData.Add("VE0414B_CFAIXACEP", q1);

                #endregion

                #region VE0414B_V1AGENCEF

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "123" },
                    { "DCLFONTES_FONTES_NOME_FONTE" , "Fonte Primária" },
                    { "DCLFONTES_FONTES_ENDERECO" , "Rua Principal, 1000" },
                    { "DCLFONTES_FONTES_BAIRRO" , "Centro" },
                    { "DCLFONTES_FONTES_CIDADE" , "São Paulo" },
                    { "DCLFONTES_FONTES_CEP" , "01000-000" },
                    { "DCLFONTES_FONTES_SIGLA_UF" , "SP" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0414B_V1AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VE0414B_V1AGENCEF", q2);

                #endregion

                #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_NUM_COPIAS" , "5" }
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "2023-05-10" },
                    { "WHOST_PROXIMA_DATA" , "2023-05-11" },
                    { "CALENDAR_DIA_SEMANA" , "Q" },
                    { "CALENDAR_FERIADO" , "S" },
                });
                q4.AddDynamic(new Dictionary<string, string>{
                    { "CALENDAR_DATA_CALENDARIO" , "2023-05-11" },
                    { "WHOST_PROXIMA_DATA" , "2023-05-12" },
                    { "CALENDAR_DIA_SEMANA" , "Q" },
                    { "CALENDAR_FERIADO" , "S" },
                });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region VE0414B_CRELAT

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "DCLRELATORIOS_RELATORI_NUM_TITULO" , "123456" },
                    { "DCLRELATORIOS_RELATORI_NUM_APOLICE" , "108210105792" },
                    { "DCLRELATORIOS_RELATORI_COD_SUBGRUPO" , "001" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0414B_CRELAT");
                AppSettings.TestSet.DynamicData.Add("VE0414B_CRELAT", q5);

                #endregion

                #region VE0414B_CADIC

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "VGARANTI_NUM_GARANTIA" , "987654" },
                    { "VGARANTI_DES_GARANTIA" , "Garantia Total" },
                });
                AppSettings.TestSet.DynamicData.Remove("VE0414B_CADIC");
                AppSettings.TestSet.DynamicData.Add("VE0414B_CADIC", q6);

                #endregion

                #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "TERMOADE_NUM_APOLICE" , "108210105792" },
                    { "TERMOADE_NUM_TERMO" , "20230001" },
                    { "TERMOADE_COD_SUBGRUPO" , "001" },
                    { "TERMOADE_DATA_ADESAO" , "2023-01-01" },
                    { "TERMOADE_COD_AGENCIA_OP" , "1234" },
                    { "TERMOADE_MODALIDADE_CAPITAL" , "Fixo" },
                    { "TERMOADE_TIPO_PLANO" , "Básico" },
                    { "TERMOADE_COD_PLANO_VGAPC" , "VGAPC001" },
                    { "TERMOADE_COD_PLANO_APC" , "APC001" },
                    { "TERMOADE_VAL_CONTRATADO" , "100000" },
                    { "TERMOADE_VAL_RCAP" , "50000" },
                    { "TERMOADE_QUANT_VIDAS" , "10" },
                    { "TERMOADE_TIPO_COBERTURA" , "Total" },
                    { "TERMOADE_PERI_PAGAMENTO" , "Mensal" },
                    { "TERMOADE_COD_CLIENTE" , "C123456" },
                    { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , "P123456" },
                    { "VGCOMTRO_DTH_DIA_DEBITO" , "2023-12-05" },
                    { "VGCOMTRO_COD_AGENCIA_DEB" , "1234" },
                    { "VGCOMTRO_OPERACAO_CONTA_DEB" , "001" },
                    { "VGCOMTRO_NUM_CONTA_DEBITO" , "0001234567" },
                    { "VGCOMTRO_DIG_CONTA_DEBITO" , "1" },
                    { "VGCOMTRO_NUM_CARTAO_CREDITO" , "4000123456789012" },
                    { "SUBGVGAP_OCORR_ENDERECO" , "Rua Secundária, 200" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "VGPROSIA_COD_PRODUTO_EMP" , "01" },
                    { "VGPROSIA_COD_PRODUTO" , "01" },
                    { "PRODUTO_COD_EMPRESA" , "01" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , "0001234567" },
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , "1" },
                    { "OPCPAGVI_DIA_DEBITO" , "05" },
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , "1234" },
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , "001" },
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , "4000123456789012" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , "Rua Principal, 1000" },
                    { "ENDERECO_BAIRRO" , "Centro" },
                    { "ENDERECO_CIDADE" , "São Paulo" },
                    { "ENDERECO_SIGLA_UF" , "SP" },
                    { "ENDERECO_CEP" , "01000-000" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "AGENCCEF_NOME_AGENCIA" , "Agência Central" },
                    { "MALHACEF_COD_FONTE" , "123" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region SEGUROS_SPBVG012_Call1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "LK_NUM_PLANO_FC12" , "FC12" },
                    { "LK_NUM_PROPOSTA_FC12" , "P123456" },
                    { "LK_COD_RAMO_FC12" , "001" },
                    { "LK_TRACE_FC12" , "Trace123" },
                    { "LK_OUT_COD_RET_FC12" , "00" },
                    { "LK_OUT_SQLCODE_FC12" , "00" },
                    { "LK_OUT_MENSAGEM_FC12" , "Operação realizada com sucesso" },
                    { "LK_OUT_SQLERRMC_FC12" , "Nenhum erro encontrado" },
                    { "LK_OUT_SQLSTATE_FC12" , "00000" },
                });
                AppSettings.TestSet.DynamicData.Remove("SEGUROS_SPBVG012_Call1");
                AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q13);

                #endregion

                #region R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "HISCOBPR_IMPSEGUR" , "10000" },
                    { "HISCOBPR_QUANT_VIDAS" , "10" },
                    { "HISCOBPR_VLPREMIO" , "500" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "HISCOBPR_IMPSEGUR" , "10000" },
                    { "HISCOBPR_QUANT_VIDAS" , "10" },
                    { "HISCOBPR_VLPREMIO" , "500" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q15);

                #endregion

                #region R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_NOME_RAZAO" , "Empresa Exemplo S.A." },
                    { "CLIENTES_CGCCPF" , "12.345.678/0001-99" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "CONDITEC_CARREGA_CONJUGE" , "Sim" },
                    { "CONDITEC_CARREGA_FILHOS" , "Sim" },
                    { "CONDITEC_GARAN_ADIC_IEA" , "Invalidez por Enfermidade Acidental" },
                    { "CONDITEC_GARAN_ADIC_IPA" , "Invalidez Permanente por Acidente" },
                    { "CONDITEC_GARAN_ADIC_IPD" , "Invalidez Permanente por Doença" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "APOLICES_RAMO_EMISSOR" , "Vida" },
                    { "APOLICES_COD_PRODUTO" , "8205" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1", q18);

                #endregion

                #region R4000_00_GERA_OBJETO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "GEOBJECT_STA_REGISTRO" , "Ativo" }
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "GEOBJECT_NUM_CEP" , "01000-000" },
                    { "GEOBJECT_COD_FORMULARIO" , "VA55" },
                    { "GEOBJECT_STA_REGISTRO" , "Ativo" },
                    { "GEOBJECT_COD_PRODUTO" , "8205" },
                    { "GEOBJECT_NUM_INI_POS_VERSO" , "001" },
                    { "GEOBJECT_QTD_PESO_GRAMAS" , "100" },
                    { "GEOBJECT_VLR_DECLARADO" , "1000" },
                    { "GEOBJECT_COD_IDENT_OBJETO" , "OBJ123456" },
                    { "GEOBJECT_DES_OBJETO" , "Documento Importante" },
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_COD_RELATORIO" , "R001" },
                    { "RELATORI_SIT_REGISTRO" , "Ativo" },
                    { "RELATORI_COD_SUBGRUPO" , "001" },
                    { "RELATORI_NUM_APOLICE" , "01" },
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_TIPO_CORRECAO" , "Automática" },
                    { "RELATORI_NUM_APOL_LIDER" , "108210105792" },
                });
                AppSettings.TestSet.DynamicData.Remove("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q22);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VE0414B();
                program.Execute(RVE0414B_FILE_NAME_P, RVE0414I_FILE_NAME_P, RVE0414P_FILE_NAME_P, RVE0414H_FILE_NAME_P, SVE0414B_FILE_NAME_P, FVE0414B_FILE_NAME_P);

                Assert.True(File.Exists(program.RVE0414B.FilePath));
                Assert.True(new FileInfo(program.RVE0414B.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.RVE0414H.FilePath));
                Assert.True(new FileInfo(program.RVE0414H.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.RVE0414B.FilePath));
                Assert.True(new FileInfo(program.RVE0414B.FilePath).Length > 0);
                
                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count > allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VE0414B_o7", "VE0414B_o8", "VE0414B_o9", "VE0414B_o10", "VE0414B_o11", "VE0414B_o12")]
        public static void VE0414B_Tests_Insert_Theory(string RVE0414B_FILE_NAME_P, string RVE0414I_FILE_NAME_P, string RVE0414P_FILE_NAME_P, string RVE0414H_FILE_NAME_P, string SVE0414B_FILE_NAME_P, string FVE0414B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                RVE0414B_FILE_NAME_P = $"{RVE0414B_FILE_NAME_P}_{timestamp}.txt";
                RVE0414I_FILE_NAME_P = $"{RVE0414I_FILE_NAME_P}_{timestamp}.txt";
                RVE0414P_FILE_NAME_P = $"{RVE0414P_FILE_NAME_P}_{timestamp}.txt";
                RVE0414H_FILE_NAME_P = $"{RVE0414H_FILE_NAME_P}_{timestamp}.txt";
                SVE0414B_FILE_NAME_P = $"{SVE0414B_FILE_NAME_P}_{timestamp}.txt";
                FVE0414B_FILE_NAME_P = $"{FVE0414B_FILE_NAME_P}_{timestamp}.txt";

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "V1SIST_MESREFER" , "12" },
                { "V1SIST_ANOREFER" , "2023" },
                { "WHOST_DATA_MOV_ABERTO" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0414B_CFAIXACEP

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DCLGE_FAIXA_CEP_GEFAICEP_FAIXA" , "1" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL" , "01000-000" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL" , "02000-000" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA" , "São Paulo - Centro" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR" , "São Paulo" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_CFAIXACEP");
AppSettings.TestSet.DynamicData.Add("VE0414B_CFAIXACEP", q1);

                #endregion

                #region VE0414B_V1AGENCEF

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "123" },
                { "DCLFONTES_FONTES_NOME_FONTE" , "Fonte Primária" },
                { "DCLFONTES_FONTES_ENDERECO" , "Rua Principal, 1000" },
                { "DCLFONTES_FONTES_BAIRRO" , "Centro" },
                { "DCLFONTES_FONTES_CIDADE" , "São Paulo" },
                { "DCLFONTES_FONTES_CEP" , "01000-000" },
                { "DCLFONTES_FONTES_SIGLA_UF" , "SP" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_V1AGENCEF");
AppSettings.TestSet.DynamicData.Add("VE0414B_V1AGENCEF", q2);

                #endregion

                #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-05-10" },
                { "WHOST_PROXIMA_DATA" , "2023-05-11" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "S" },
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-05-11" },
                { "WHOST_PROXIMA_DATA" , "2023-05-12" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "S" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region VE0414B_CRELAT

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "DCLRELATORIOS_RELATORI_NUM_TITULO" , "123456" },
                { "DCLRELATORIOS_RELATORI_NUM_APOLICE" , "108210105792" },
                { "DCLRELATORIOS_RELATORI_COD_SUBGRUPO" , "001" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_CRELAT");
AppSettings.TestSet.DynamicData.Add("VE0414B_CRELAT", q5);

                #endregion

                #region VE0414B_CADIC

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_NUM_GARANTIA" , "987654" },
                { "VGARANTI_DES_GARANTIA" , "Garantia Total" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_CADIC");
AppSettings.TestSet.DynamicData.Add("VE0414B_CADIC", q6);

                #endregion

                #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , "108210105792" },
                { "TERMOADE_NUM_TERMO" , "20230001" },
                { "TERMOADE_COD_SUBGRUPO" , "001" },
                { "TERMOADE_DATA_ADESAO" , "2023-01-01" },
                { "TERMOADE_COD_AGENCIA_OP" , "1234" },
                { "TERMOADE_MODALIDADE_CAPITAL" , "Fixo" },
                { "TERMOADE_TIPO_PLANO" , "Básico" },
                { "TERMOADE_COD_PLANO_VGAPC" , "VGAPC001" },
                { "TERMOADE_COD_PLANO_APC" , "APC001" },
                { "TERMOADE_VAL_CONTRATADO" , "100000" },
                { "TERMOADE_VAL_RCAP" , "50000" },
                { "TERMOADE_QUANT_VIDAS" , "10" },
                { "TERMOADE_TIPO_COBERTURA" , "Total" },
                { "TERMOADE_PERI_PAGAMENTO" , "Mensal" },
                { "TERMOADE_COD_CLIENTE" , "C123456" },
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , "P123456" },
                { "VGCOMTRO_DTH_DIA_DEBITO" , "2023-12-05" },
                { "VGCOMTRO_COD_AGENCIA_DEB" , "1234" },
                { "VGCOMTRO_OPERACAO_CONTA_DEB" , "001" },
                { "VGCOMTRO_NUM_CONTA_DEBITO" , "0001234567" },
                { "VGCOMTRO_DIG_CONTA_DEBITO" , "1" },
                { "VGCOMTRO_NUM_CARTAO_CREDITO" , "4000123456789012" },
                { "SUBGVGAP_OCORR_ENDERECO" , "Rua Secundária, 200" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO_EMP" , "01" },
                { "VGPROSIA_COD_PRODUTO" , "01" },
                { "PRODUTO_COD_EMPRESA" , "01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "0001234567" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "1" },
                { "OPCPAGVI_DIA_DEBITO" , "05" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "1234" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "001" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "4000123456789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "Rua Principal, 1000" },
                { "ENDERECO_BAIRRO" , "Centro" },
                { "ENDERECO_CIDADE" , "São Paulo" },
                { "ENDERECO_SIGLA_UF" , "SP" },
                { "ENDERECO_CEP" , "01000-000" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , "Agência Central" },
                { "MALHACEF_COD_FONTE" , "123" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region SEGUROS_SPBVG012_Call1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO_FC12" , "FC12" },
                { "LK_NUM_PROPOSTA_FC12" , "P123456" },
                { "LK_COD_RAMO_FC12" , "001" },
                { "LK_TRACE_FC12" , "Trace123" },
                { "LK_OUT_COD_RET_FC12" , "00" },
                { "LK_OUT_SQLCODE_FC12" , "00" },
                { "LK_OUT_MENSAGEM_FC12" , "Operação realizada com sucesso" },
                { "LK_OUT_SQLERRMC_FC12" , "Nenhum erro encontrado" },
                { "LK_OUT_SQLSTATE_FC12" , "00000" },
            });
            AppSettings.TestSet.DynamicData.Remove("SEGUROS_SPBVG012_Call1");
AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q13);

                #endregion

                #region R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "10000" },
                { "HISCOBPR_QUANT_VIDAS" , "10" },
                { "HISCOBPR_VLPREMIO" , "500" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "10000" },
                { "HISCOBPR_QUANT_VIDAS" , "10" },
                { "HISCOBPR_VLPREMIO" , "500" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q15);

                #endregion

                #region R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Empresa Exemplo S.A." },
                { "CLIENTES_CGCCPF" , "12.345.678/0001-99" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "Sim" },
                { "CONDITEC_CARREGA_FILHOS" , "Sim" },
                { "CONDITEC_GARAN_ADIC_IEA" , "Invalidez por Enfermidade Acidental" },
                { "CONDITEC_GARAN_ADIC_IPA" , "Invalidez Permanente por Acidente" },
                { "CONDITEC_GARAN_ADIC_IPD" , "Invalidez Permanente por Doença" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "Vida" },
                { "APOLICES_COD_PRODUTO" , "8205" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1", q18);

                #endregion

                #region R4000_00_GERA_OBJETO_DB_SELECT_1_Query1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , "Ativo" }
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , "01000-000" },
                { "GEOBJECT_COD_FORMULARIO" , "VA55" },
                { "GEOBJECT_STA_REGISTRO" , "Ativo" },
                { "GEOBJECT_COD_PRODUTO" , "8205" },
                { "GEOBJECT_NUM_INI_POS_VERSO" , "001" },
                { "GEOBJECT_QTD_PESO_GRAMAS" , "100" },
                { "GEOBJECT_VLR_DECLARADO" , "1000" },
                { "GEOBJECT_COD_IDENT_OBJETO" , "OBJ123456" },
                { "GEOBJECT_DES_OBJETO" , "Documento Importante" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , "R001" },
                { "RELATORI_SIT_REGISTRO" , "Ativo" },
                { "RELATORI_COD_SUBGRUPO" , "001" },
                { "RELATORI_NUM_APOLICE" , "01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , "Automática" },
                { "RELATORI_NUM_APOL_LIDER" , "108210105792" },
            });
            AppSettings.TestSet.DynamicData.Remove("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q22);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VE0414B();
                program.Execute(RVE0414B_FILE_NAME_P, RVE0414I_FILE_NAME_P, RVE0414P_FILE_NAME_P, RVE0414H_FILE_NAME_P, SVE0414B_FILE_NAME_P, FVE0414B_FILE_NAME_P);

                Assert.True(File.Exists(program.RVE0414B.FilePath));
                Assert.True(new FileInfo(program.RVE0414B.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.RVE0414H.FilePath));
                Assert.True(new FileInfo(program.RVE0414H.FilePath).Length > 0);
                
                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count > allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VE0414B_o13", "VE0414B_o14", "VE0414B_o15", "VE0414B_o16", "VE0414B_o17", "VE0414B_o18")]
        public static void VE0414B_Tests_ReturnCode99_Theory(string RVE0414B_FILE_NAME_P, string RVE0414I_FILE_NAME_P, string RVE0414P_FILE_NAME_P, string RVE0414H_FILE_NAME_P, string SVE0414B_FILE_NAME_P, string FVE0414B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                RVE0414B_FILE_NAME_P = $"{RVE0414B_FILE_NAME_P}_{timestamp}.txt";
                RVE0414I_FILE_NAME_P = $"{RVE0414I_FILE_NAME_P}_{timestamp}.txt";
                RVE0414P_FILE_NAME_P = $"{RVE0414P_FILE_NAME_P}_{timestamp}.txt";
                RVE0414H_FILE_NAME_P = $"{RVE0414H_FILE_NAME_P}_{timestamp}.txt";
                SVE0414B_FILE_NAME_P = $"{SVE0414B_FILE_NAME_P}_{timestamp}.txt";
                FVE0414B_FILE_NAME_P = $"{FVE0414B_FILE_NAME_P}_{timestamp}.txt";

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "V1SIST_MESREFER" , "12" },
                { "V1SIST_ANOREFER" , "2023" },
                { "WHOST_DATA_MOV_ABERTO" , "2023-12-01" },
            }, new SQLCA(100));
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0414B_CFAIXACEP

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DCLGE_FAIXA_CEP_GEFAICEP_FAIXA" , "1" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL" , "01000-000" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL" , "02000-000" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA" , "São Paulo - Centro" },
                { "DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR" , "São Paulo" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_CFAIXACEP");
AppSettings.TestSet.DynamicData.Add("VE0414B_CFAIXACEP", q1);

                #endregion

                #region VE0414B_V1AGENCEF

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "123" },
                { "DCLFONTES_FONTES_NOME_FONTE" , "Fonte Primária" },
                { "DCLFONTES_FONTES_ENDERECO" , "Rua Principal, 1000" },
                { "DCLFONTES_FONTES_BAIRRO" , "Centro" },
                { "DCLFONTES_FONTES_CIDADE" , "São Paulo" },
                { "DCLFONTES_FONTES_CEP" , "01000-000" },
                { "DCLFONTES_FONTES_SIGLA_UF" , "SP" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_V1AGENCEF");
AppSettings.TestSet.DynamicData.Add("VE0414B_V1AGENCEF", q2);

                #endregion

                #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "5" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-05-10" },
                { "WHOST_PROXIMA_DATA" , "2023-05-11" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "S" },
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-05-11" },
                { "WHOST_PROXIMA_DATA" , "2023-05-12" },
                { "CALENDAR_DIA_SEMANA" , "Q" },
                { "CALENDAR_FERIADO" , "S" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q4);

                #endregion

                #region VE0414B_CRELAT

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "DCLRELATORIOS_RELATORI_NUM_TITULO" , "123456" },
                { "DCLRELATORIOS_RELATORI_NUM_APOLICE" , "108210105792" },
                { "DCLRELATORIOS_RELATORI_COD_SUBGRUPO" , "001" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_CRELAT");
AppSettings.TestSet.DynamicData.Add("VE0414B_CRELAT", q5);

                #endregion

                #region VE0414B_CADIC

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_NUM_GARANTIA" , "987654" },
                { "VGARANTI_DES_GARANTIA" , "Garantia Total" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0414B_CADIC");
AppSettings.TestSet.DynamicData.Add("VE0414B_CADIC", q6);

                #endregion

                #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , "108210105792" },
                { "TERMOADE_NUM_TERMO" , "20230001" },
                { "TERMOADE_COD_SUBGRUPO" , "001" },
                { "TERMOADE_DATA_ADESAO" , "2023-01-01" },
                { "TERMOADE_COD_AGENCIA_OP" , "1234" },
                { "TERMOADE_MODALIDADE_CAPITAL" , "Fixo" },
                { "TERMOADE_TIPO_PLANO" , "Básico" },
                { "TERMOADE_COD_PLANO_VGAPC" , "VGAPC001" },
                { "TERMOADE_COD_PLANO_APC" , "APC001" },
                { "TERMOADE_VAL_CONTRATADO" , "100000" },
                { "TERMOADE_VAL_RCAP" , "50000" },
                { "TERMOADE_QUANT_VIDAS" , "10" },
                { "TERMOADE_TIPO_COBERTURA" , "Total" },
                { "TERMOADE_PERI_PAGAMENTO" , "Mensal" },
                { "TERMOADE_COD_CLIENTE" , "C123456" },
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , "P123456" },
                { "VGCOMTRO_DTH_DIA_DEBITO" , "2023-12-05" },
                { "VGCOMTRO_COD_AGENCIA_DEB" , "1234" },
                { "VGCOMTRO_OPERACAO_CONTA_DEB" , "001" },
                { "VGCOMTRO_NUM_CONTA_DEBITO" , "0001234567" },
                { "VGCOMTRO_DIG_CONTA_DEBITO" , "1" },
                { "VGCOMTRO_NUM_CARTAO_CREDITO" , "4000123456789012" },
                { "SUBGVGAP_OCORR_ENDERECO" , "Rua Secundária, 200" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VGPROSIA_COD_PRODUTO_EMP" , "01" },
                { "VGPROSIA_COD_PRODUTO" , "01" },
                { "PRODUTO_COD_EMPRESA" , "01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1", q8);

                #endregion

                #region R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "0001234567" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "1" },
                { "OPCPAGVI_DIA_DEBITO" , "05" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "1234" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "001" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "4000123456789012" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "Rua Principal, 1000" },
                { "ENDERECO_BAIRRO" , "Centro" },
                { "ENDERECO_CIDADE" , "São Paulo" },
                { "ENDERECO_SIGLA_UF" , "SP" },
                { "ENDERECO_CEP" , "01000-000" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PERIPGTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , "Agência Central" },
                { "MALHACEF_COD_FONTE" , "123" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region SEGUROS_SPBVG012_Call1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "LK_NUM_PLANO_FC12" , "FC12" },
                { "LK_NUM_PROPOSTA_FC12" , "P123456" },
                { "LK_COD_RAMO_FC12" , "001" },
                { "LK_TRACE_FC12" , "Trace123" },
                { "LK_OUT_COD_RET_FC12" , "00" },
                { "LK_OUT_SQLCODE_FC12" , "00" },
                { "LK_OUT_MENSAGEM_FC12" , "Operação realizada com sucesso" },
                { "LK_OUT_SQLERRMC_FC12" , "Nenhum erro encontrado" },
                { "LK_OUT_SQLSTATE_FC12" , "00000" },
            });
            AppSettings.TestSet.DynamicData.Remove("SEGUROS_SPBVG012_Call1");
AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBVG012_Call1", q13);

                #endregion

                #region R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "10000" },
                { "HISCOBPR_QUANT_VIDAS" , "10" },
                { "HISCOBPR_VLPREMIO" , "500" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMPSEGUR" , "10000" },
                { "HISCOBPR_QUANT_VIDAS" , "10" },
                { "HISCOBPR_VLPREMIO" , "500" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1940_00_SELECT_HISCOBPR_DB_SELECT_2_Query1", q15);

                #endregion

                #region R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "Empresa Exemplo S.A." },
                { "CLIENTES_CGCCPF" , "12.345.678/0001-99" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2301_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "Sim" },
                { "CONDITEC_CARREGA_FILHOS" , "Sim" },
                { "CONDITEC_GARAN_ADIC_IEA" , "Invalidez por Enfermidade Acidental" },
                { "CONDITEC_GARAN_ADIC_IPA" , "Invalidez Permanente por Acidente" },
                { "CONDITEC_GARAN_ADIC_IPD" , "Invalidez Permanente por Doença" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1", q17);

                #endregion

                #region R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "Vida" },
                { "APOLICES_COD_PRODUTO" , "8205" },
            });
            AppSettings.TestSet.DynamicData.Remove("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1", q18);

                #endregion

                #region R4000_00_GERA_OBJETO_DB_SELECT_1_Query1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , "Ativo" }
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R4000_00_GERA_OBJETO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , "01000-000" },
                { "GEOBJECT_COD_FORMULARIO" , "VA55" },
                { "GEOBJECT_STA_REGISTRO" , "Ativo" },
                { "GEOBJECT_COD_PRODUTO" , "8205" },
                { "GEOBJECT_NUM_INI_POS_VERSO" , "001" },
                { "GEOBJECT_QTD_PESO_GRAMAS" , "100" },
                { "GEOBJECT_VLR_DECLARADO" , "1000" },
                { "GEOBJECT_COD_IDENT_OBJETO" , "OBJ123456" },
                { "GEOBJECT_DES_OBJETO" , "Documento Importante" },
            });
            AppSettings.TestSet.DynamicData.Remove("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R4000_02_INSERT_OBJETO_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_RELATORIO" , "R001" },
                { "RELATORI_SIT_REGISTRO" , "Ativo" },
                { "RELATORI_COD_SUBGRUPO" , "001" },
                { "RELATORI_NUM_APOLICE" , "01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , "Automática" },
                { "RELATORI_NUM_APOL_LIDER" , "108210105792" },
            });
            AppSettings.TestSet.DynamicData.Remove("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q22);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VE0414B();
                program.Execute(RVE0414B_FILE_NAME_P, RVE0414I_FILE_NAME_P, RVE0414P_FILE_NAME_P, RVE0414H_FILE_NAME_P, SVE0414B_FILE_NAME_P, FVE0414B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}