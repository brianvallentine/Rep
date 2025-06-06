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
using static Code.VA5437B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA5437B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA5437B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-07-19"},
                { "SISTEMAS_DATA_MOV_ABERTO_1" , "2023-07-19"},
                { "SISTEMAS_DATA_MOV_ABERTO_15D" , "2024-07-04"},
                { "V1SIST_MESREFER" , "7"},
                { "V1SIST_ANOREFER" , "2024"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA5437B_CFAIXACEP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "1"},
                { "GEFAICEP_CEP_INICIAL" , "1001000"},
                { "GEFAICEP_CEP_FINAL" , "1058999"},
                { "GEFAICEP_DESCRICAO_FAIXA" , "CDD AV. SAO JOAO/SPM                                                    "},
                { "GEFAICEP_CENTRALIZADOR" , "CTC/MOOCA/SPM   01                                                      "},
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEFAICEP_FAIXA" , "1"},
                { "GEFAICEP_CEP_INICIAL" , "1001000"},
                { "GEFAICEP_CEP_FINAL" , "1058999"},
                { "GEFAICEP_DESCRICAO_FAIXA" , "CDD AV. SAO JOAO/SPM                                                    "},
                { "GEFAICEP_CENTRALIZADOR" , "CTC/MOOCA/SPM   01                                                      "},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_CFAIXACEP", q1);

            #endregion

            #region VA5437B_CMSG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "93010000890"},
                { "COBMENVG_CODSUBES" , "3"},
                { "COBMENVG_COD_OPERACAO" , "6"},
                { "COBMENVG_JDE" , "VA54"},
                { "COBMENVG_JDL" , "PV      "},
                { "COBMENVG_IDFORM" , "A5"},
            }); 
            q2.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_NUM_APOLICE" , "93010000890"},
                { "COBMENVG_CODSUBES" , "3"},
                { "COBMENVG_COD_OPERACAO" , "6"},
                { "COBMENVG_JDE" , "93010000890"},
                { "COBMENVG_JDL" , "PV      "},
                { "COBMENVG_IDFORM" , "A5"},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_CMSG", q2);

            #endregion

            #region VA5437B_CFCPLANO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "FCPLANO_NUM_PLANO" , "203"},
                { "FCPLANO_QTD_DIG_COMBINACAO" , "5"},
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "FCPLANO_NUM_PLANO" , "203"},
                { "FCPLANO_QTD_DIG_COMBINACAO" , "5"},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_CFCPLANO", q3);

            #endregion

            #region VA5437B_V1AGENCEF

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "2"},
                { "FONTES_NOME_FONTE" , "AMAZONAS                                "},
                { "FONTES_ENDERECO" , "AV.SERZEDELO CORREA, N. 160             "},
                { "FONTES_BAIRRO" , "CENTRO              "},
                { "FONTES_CIDADE" , "BELEM               "},
                { "FONTES_CEP" , "66025240"},
                { "FONTES_SIGLA_UF" , "PA"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "2"},
                { "FONTES_NOME_FONTE" , "AMAZONAS                                "},
                { "FONTES_ENDERECO" , "AV.SERZEDELO CORREA, N. 160             "},
                { "FONTES_BAIRRO" , "CENTRO              "},
                { "FONTES_CIDADE" , "BELEM               "},
                { "FONTES_CEP" , "66025240"},
                { "FONTES_SIGLA_UF" , "PA"},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_V1AGENCEF", q4);

            #endregion

            #region VA5437B_CRELAT

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "2"},
                { "RELATORI_COD_USUARIO" , "MILENE  "},
                { "RELATORI_COD_RELATORIO" , "VG0420B "},
                { "RELATORI_NUM_PARCELA" , "2"},
                { "RELATORI_TIMESTAMP" , "2015-12-03 16:22:42.364"},
                { "PROPOVA_DATA_QUITACAO" , "1991-11-26"},
                { "PROPOVA_NUM_APOLICE" , "93010000890"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "10000022115"},
                { "PROPOVA_COD_PRODUTO" , "9701"},
                { "PROPOVA_COD_CLIENTE" , "281796"},
                { "PROPOVA_OCOREND" , "2"},
                { "PROPOVA_IDE_SEXO" , "F"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_AGE_COBRANCA" , "1627"},
                { "PROPOVA_COD_FONTE" , "15"},
                { "PROPOVA_IDADE" , "48"},
                { "PROPOVA_OCORR_HISTORICO" , "31"},
                { "PROPOVA_FAIXA_RENDA_IND" , "5"},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PROPOVA_DTPROXVEN" , "2017-04-06"},
                { "PRODUVG_CODRELAT" , "VA0437B "},
                { "PRODUVG_PERI_PAGAMENTO" , "1"},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "PRODUTO_COD_EMPRESA" , "10"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_OPERACAO" , "2"},
                { "RELATORI_COD_USUARIO" , "MILENE  "},
                { "RELATORI_COD_RELATORIO" , "VG0420B "},
                { "RELATORI_NUM_PARCELA" , "2"},
                { "RELATORI_TIMESTAMP" , "2015-12-03 16:22:42.364"},
                { "PROPOVA_DATA_QUITACAO" , "1991-11-26"},
                { "PROPOVA_NUM_APOLICE" , "93010000890"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_NUM_CERTIFICADO" , "10000022115"},
                { "PROPOVA_COD_PRODUTO" , "9701"},
                { "PROPOVA_COD_CLIENTE" , "281796"},
                { "PROPOVA_OCOREND" , "2"},
                { "PROPOVA_IDE_SEXO" , "F"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_AGE_COBRANCA" , "1627"},
                { "PROPOVA_COD_FONTE" , "15"},
                { "PROPOVA_IDADE" , "48"},
                { "PROPOVA_OCORR_HISTORICO" , "31"},
                { "PROPOVA_FAIXA_RENDA_IND" , "5"},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PROPOVA_DTPROXVEN" , "2017-04-06"},
                { "PRODUVG_CODRELAT" , "VA0437B "},
                { "PRODUVG_PERI_PAGAMENTO" , "1"},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "PRODUTO_COD_EMPRESA" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_CRELAT", q5);

            #endregion

            #region VA5437B_CTITFEDCA

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NRTITFDCAP" , "801010000037"},
                { "TITFEDCA_NRSORTEIO" , "97780"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NRTITFDCAP" , "801010000037"},
                { "TITFEDCA_NRSORTEIO" , "97780"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "TITFEDCA_NRTITFDCAP" , "801010000037"},
                { "TITFEDCA_NRSORTEIO" , "97780"},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_CTITFEDCA", q6);

            #endregion

            #region R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_DUPLICADO" , "29382133"}
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_DUPLICADO" , "29382133"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_IDADE" , "34"}
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_IDADE" , "34"}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"},
                { "SEGURVGA_COD_CLIENTE" , "1541758"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1993-02-28"},
                { "WHOST_DATA_TERVIG_PREMIO" , "1993-12-28"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "5"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"},
                { "SEGURVGA_COD_CLIENTE" , "1541758"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1993-02-28"},
                { "WHOST_DATA_TERVIG_PREMIO" , "1993-12-28"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "5"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
            { "SEGURVGA_DATA_INIVIGENCIA" , "1991-08-30"}
            });
            q10.AddDynamic(new Dictionary<string, string>{
            { "SEGURVGA_DATA_INIVIGENCIA" , "1991-08-30"}
            });
            AppSettings.TestSet.DynamicData.Add("R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "3"},
                { "OPCPAGVI_DIA_DEBITO" , "9"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "2220"},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "13"},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "12356"},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "0"},
                { "OPCPAGVI_PERI_PAGAMENTO" , "12"},
                { "OPCPAGVI_DATA_INIVIGENCIA" , "1901-01-02"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q11);

            #endregion

            #region VA5437B_V0BENEF

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , "ANTONIO MONTECHIEZE                     "},
                { "BENEFICI_GRAU_PARENTESCO" , "ESPOSO    "},
                { "BENEFICI_PCT_PART_BENEFICIA" , "100.00"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , "ANTONIO MONTECHIEZE                     "},
                { "BENEFICI_GRAU_PARENTESCO" , "ESPOSO    "},
                { "BENEFICI_PCT_PART_BENEFICIA" , "100.00"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NOME_BENEFICIARIO" , "ANTONIO MONTECHIEZE                     "},
                { "BENEFICI_GRAU_PARENTESCO" , "ESPOSO    "},
                { "BENEFICI_PCT_PART_BENEFICIA" , "100.00"},
            });
            AppSettings.TestSet.DynamicData.Add("VA5437B_V0BENEF", q12);

            #endregion

            #region R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FCPROSUS_COD_PROCESSO_SUSEP" , "10.001532/01-45          "}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "FCPROSUS_COD_PROCESSO_SUSEP" , "10.001532/01-45          "}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "FCPROSUS_COD_PROCESSO_SUSEP" , "10.001532/01-45          "}
            });
            AppSettings.TestSet.DynamicData.Add("R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "CARLOS ALBERTO NUNES COELHO             "},
                { "CLIENTES_CGCCPF" , "0,"},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "CARLOS ALBERTO NUNES COELHO             "},
                { "CLIENTES_CGCCPF" , "0,"},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "CARLOS ALBERTO NUNES COELHO             "},
                { "CLIENTES_CGCCPF" , "0,"},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_IDADE" , "34"}
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_IDADE" , "34"}
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_IDADE" , "34"}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , "GU@HOT.COM"}
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , "GU@HOT.COM"}
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , "GU@HOT.COM"}
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "RUA SAO PAULO 854 1 ANDAR SALA 1                                        "},
                { "ENDERECO_BAIRRO" , "JARDIM IRAJA                                                            "},
                { "ENDERECO_CIDADE" , "RIBEIRAO PRETO                                                          "},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "14020640"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "RUA SAO PAULO 854 1 ANDAR SALA 1                                        "},
                { "ENDERECO_BAIRRO" , "JARDIM IRAJA                                                            "},
                { "ENDERECO_CIDADE" , "RIBEIRAO PRETO                                                          "},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "14020640"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "RUA SAO PAULO 854 1 ANDAR SALA 1                                        "},
                { "ENDERECO_BAIRRO" , "JARDIM IRAJA                                                            "},
                { "ENDERECO_CIDADE" , "RIBEIRAO PRETO                                                          "},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "14020640"},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_OPER_CORR_MONET" , "2020-01-01"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_OPER_CORR_MONET" , "2020-01-01"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_OPER_CORR_MONET" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , "2000-07-21"},
                { "HISCOBPR_COD_OPERACAO" , "101"},
                { "HISCOBPR_OPCAO_COBERTURA" , "L"},
                { "HISCOBPR_IMP_MORNATU" , "12000"},
                { "HISCOBPR_IMPSEGCDG" , "360000"},
                { "HISCOBPR_VLPREMIO" , "70.56"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0"},
            });
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , "2000-07-21"},
                { "HISCOBPR_COD_OPERACAO" , "101"},
                { "HISCOBPR_OPCAO_COBERTURA" , "L"},
                { "HISCOBPR_IMP_MORNATU" , "12000"},
                { "HISCOBPR_IMPSEGCDG" , "360000"},
                { "HISCOBPR_VLPREMIO" , "70.56"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0"},
            });
            q19.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , "2000-07-21"},
                { "HISCOBPR_COD_OPERACAO" , "101"},
                { "HISCOBPR_OPCAO_COBERTURA" , "L"},
                { "HISCOBPR_IMP_MORNATU" , "12000"},
                { "HISCOBPR_IMPSEGCDG" , "360000"},
                { "HISCOBPR_VLPREMIO" , "70.56"},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "2"}
            });
            q20.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "2"}
            });
            q20.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "12311771"},
                { "APOLICES_RAMO_EMISSOR" , "10"},
            });
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "12311771"},
                { "APOLICES_RAMO_EMISSOR" , "10"},
            });
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , "12311771"},
                { "APOLICES_RAMO_EMISSOR" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "1974-07-31"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2035-07-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , "2034-07-01"},
            });
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "1974-07-31"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2035-07-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , "2034-07-01"},
            });
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "1974-07-31"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2035-07-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA_1" , "2034-07-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q22);

            #endregion

            #region R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , "9999-12-31"}
            });
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , "9999-12-31"}
            });
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , "9999-12-31"}
            });
            AppSettings.TestSet.DynamicData.Add("R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1_Query1", q23);

            #endregion

            #region R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , "3018-03-01"}
            });
            q24.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , "3018-03-01"}
            });
            q24.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , "3018-03-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_RELAT_CAR" , ""}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_RELAT_CAR" , ""}
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_RELAT_CAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1", q25);

            #endregion

            #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ",EG6423 "}
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ",EG6423 "}
            });
            q26.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ",EG6423 "}
            });
            AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q26);

            #endregion

            #region R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , "0"}
            });
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , "0"}
            });
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1", q27);

            #endregion

            #region R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , "PV01    "},
                { "COBMENVG_JDL" , "PV      "},
            });
            q28.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , "PV01    "},
                { "COBMENVG_JDL" , "PV      "},
            });
            q28.AddDynamic(new Dictionary<string, string>{
                { "COBMENVG_JDE" , "PV01    "},
                { "COBMENVG_JDL" , "PV      "},

            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q28);

            #endregion

            #region R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODRELAT" , ""},
                { "WHOST_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q29);

            #endregion

            #region R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA PARENTES    "},
                { "PRODUVG_COD_PRODUTO" , "9304"},
            });
            q30.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA PARENTES    "},
                { "PRODUVG_COD_PRODUTO" , "9304"},
            });
            q30.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA PARENTES    "},
                { "PRODUVG_COD_PRODUTO" , "9304"},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q30);

            #endregion

            #region R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "BANKIM FARRADAY DO TDM                  "}
            });
            q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "BANKIM FARRADAY DO TDM                  "}
            });
            q31.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "BANKIM FARRADAY DO TDM                  "}
            });
            AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , "3"}
            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , "3"}
            });
            q32.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_OPCAO_CONJUGE" , "3"}
            });
            AppSettings.TestSet.DynamicData.Add("R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1", q32);

            #endregion

            #region R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , "0"}
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , "0"}
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q33);

            #endregion

            #region R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "},
                { "PRODUTO_COD_PRODUTO" , "2"},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , "001.003403/96            "},
            });
            q34.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "},
                { "PRODUTO_COD_PRODUTO" , "2"},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , "001.003403/96            "},
            });
            q34.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "PREVIDENCIA PRIVADA                     "},
                { "PRODUTO_COD_PRODUTO" , "2"},
                { "PRODUTO_NUM_PROCESSO_SUSEP" , "001.003403/96            "},
            });
            AppSettings.TestSet.DynamicData.Add("R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q34);

            #endregion

            #region R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "3"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q35);

            #endregion

            #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "32767"}
            });
            q36.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "32767"}
            });
            q36.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_NUM_COPIAS" , "32767"}
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q36);

            #endregion

            #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "WHOST_NRAPOLICE" , ""},
                { "WHOST_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
            });
            q38.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
            });
            q38.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1", q38);

            #endregion
            VG0711S_Tests.Load_Parameters();
            #endregion
        }

        [Theory]
        [InlineData("RVA5437B_FILE_NAME_P_0", "SVA5437B_FILE_NAME_P_1", "FVA5437B_FILE_NAME_P_2", "IMP5437B_FILE_NAME_P_3", "PDF5437B_FILE_NAME_P_4", "VDHTML01_FILE_NAME_P_5", "VDHTML09_FILE_NAME_P_6")]
        public static void VA5437B_Tests_Theory(string RVA5437B_FILE_NAME_P, string SVA5437B_FILE_NAME_P, string FVA5437B_FILE_NAME_P, string IMP5437B_FILE_NAME_P, string PDF5437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

            RVA5437B_FILE_NAME_P = $"{RVA5437B_FILE_NAME_P}_{timestamp}.txt";
            SVA5437B_FILE_NAME_P = $"{SVA5437B_FILE_NAME_P}_{timestamp}.txt";
            FVA5437B_FILE_NAME_P = $"{FVA5437B_FILE_NAME_P}_{timestamp}.txt";
            IMP5437B_FILE_NAME_P = $"{IMP5437B_FILE_NAME_P}_{timestamp}.txt";
            PDF5437B_FILE_NAME_P = $"{PDF5437B_FILE_NAME_P}_{timestamp}.txt";
            VDHTML01_FILE_NAME_P = $"{VDHTML01_FILE_NAME_P}_{timestamp}.txt";
            VDHTML09_FILE_NAME_P = $"{VDHTML09_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new VA5437B();
                program.Execute(RVA5437B_FILE_NAME_P, SVA5437B_FILE_NAME_P, FVA5437B_FILE_NAME_P, IMP5437B_FILE_NAME_P, PDF5437B_FILE_NAME_P, VDHTML01_FILE_NAME_P, VDHTML09_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                //teste SUBPROGRAMAS
                Assert.True(program.AREA_DE_WORK.LK_PROSOMU1.LK_QTDIAS == 3);
                Assert.True(program.PARAMETROS_711.LK711_CERTIFICADO == 10000022115);

                Assert.True(program.RETURN_CODE == 0);

                //R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var val5r) && val5r.Contains("2024-07-19"));
                Assert.True(envList[1].TryGetValue("V1SIST_MESREFER", out var val6r) && val6r.Contains("7"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("RVA5437B_FILE_NAME_P_7", "SVA5437B_FILE_NAME_P_8", "FVA5437B_FILE_NAME_P_9", "IMP5437B_FILE_NAME_P_10", "PDF5437B_FILE_NAME_P_11", "VDHTML01_FILE_NAME_P_12", "VDHTML09_FILE_NAME_P_13")]
        public static void VA5437B_Tests_Theory_SIT_Registro1(string RVA5437B_FILE_NAME_P, string SVA5437B_FILE_NAME_P, string FVA5437B_FILE_NAME_P, string IMP5437B_FILE_NAME_P, string PDF5437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

            RVA5437B_FILE_NAME_P = $"{RVA5437B_FILE_NAME_P}_{timestamp}.txt";
            SVA5437B_FILE_NAME_P = $"{SVA5437B_FILE_NAME_P}_{timestamp}.txt";
            FVA5437B_FILE_NAME_P = $"{FVA5437B_FILE_NAME_P}_{timestamp}.txt";
            IMP5437B_FILE_NAME_P = $"{IMP5437B_FILE_NAME_P}_{timestamp}.txt";
            PDF5437B_FILE_NAME_P = $"{PDF5437B_FILE_NAME_P}_{timestamp}.txt";
            VDHTML01_FILE_NAME_P = $"{VDHTML01_FILE_NAME_P}_{timestamp}.txt";
            VDHTML09_FILE_NAME_P = $"{VDHTML09_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R1010_00_SELECT_SEGURVGA_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"},
                { "SEGURVGA_COD_CLIENTE" , "1541758"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1993-02-28"},
                { "WHOST_DATA_TERVIG_PREMIO" , "1993-12-28"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "5"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
            });
                q8.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_SIT_REGISTRO" , "0"},
                { "SEGURVGA_COD_CLIENTE" , "1541758"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1993-02-28"},
                { "WHOST_DATA_TERVIG_PREMIO" , "1993-12-28"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_NUM_ITEM" , "5"},
                { "SEGURVGA_OCORR_HISTORICO" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q8);

                #region R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q25);

                #endregion

                #endregion

                #endregion
                var program = new VA5437B();
                program.Execute(RVA5437B_FILE_NAME_P, SVA5437B_FILE_NAME_P, FVA5437B_FILE_NAME_P, IMP5437B_FILE_NAME_P, PDF5437B_FILE_NAME_P, VDHTML01_FILE_NAME_P, VDHTML09_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RVA5437B.FilePath));
                Assert.True(new FileInfo(program.RVA5437B.FilePath)?.Length > 0);

                //R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("WHOST_CODRELAT", out var val5r) && val5r.Contains("VG0420B"));
                Assert.True(envList[1].TryGetValue("WHOST_NRCERTIF", out var val6r) && val6r.Contains("10000022115"));

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Theory]
        [InlineData("RVA5437B_FILE_NAME_P_14", "SVA5437B_FILE_NAME_P_15", "FVA5437B_FILE_NAME_P_16", "IMP5437B_FILE_NAME_P_17", "PDF5437B_FILE_NAME_P_18", "VDHTML01_FILE_NAME_P_19", "VDHTML09_FILE_NAME_P_20")]
        public static void VA5437B_Tests_TheoryErro99(string RVA5437B_FILE_NAME_P, string SVA5437B_FILE_NAME_P, string FVA5437B_FILE_NAME_P, string IMP5437B_FILE_NAME_P, string PDF5437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssffftt");

            RVA5437B_FILE_NAME_P = $"{RVA5437B_FILE_NAME_P}_{timestamp}.txt";
            SVA5437B_FILE_NAME_P = $"{SVA5437B_FILE_NAME_P}_{timestamp}.txt";
            FVA5437B_FILE_NAME_P = $"{FVA5437B_FILE_NAME_P}_{timestamp}.txt";
            IMP5437B_FILE_NAME_P = $"{IMP5437B_FILE_NAME_P}_{timestamp}.txt";
            PDF5437B_FILE_NAME_P = $"{PDF5437B_FILE_NAME_P}_{timestamp}.txt";
            VDHTML01_FILE_NAME_P = $"{VDHTML01_FILE_NAME_P}_{timestamp}.txt";
            VDHTML09_FILE_NAME_P = $"{VDHTML09_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VA5437B_V1AGENCEF

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VA5437B_V1AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VA5437B_V1AGENCEF", q4);

                #endregion
                #endregion
                var program = new VA5437B();
                program.Execute(RVA5437B_FILE_NAME_P, SVA5437B_FILE_NAME_P, FVA5437B_FILE_NAME_P, IMP5437B_FILE_NAME_P, PDF5437B_FILE_NAME_P, VDHTML01_FILE_NAME_P, VDHTML09_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}