using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0612B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0612B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0612B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela,
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2023-02-24"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2023-02-24"}
            });
            AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "12254"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region PF0612B_MOVIMENTO_VGAP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , "3009300001909"},
                { "MOVVGAP_COD_SUBGRUPO" , "2"},
                { "MOVVGAP_COD_FONTE" , "6"},
                { "MOVVGAP_NUM_PROPOSTA" , "20977619"},
                { "MOVVGAP_TIPO_SEGURADO" , "1"},
                { "MOVVGAP_NUM_CERTIFICADO" , "80029070000586"},
                { "MOVVGAP_DAC_CERTIFICADO" , " "},
                { "MOVVGAP_TIPO_INCLUSAO" , "4"},
                { "MOVVGAP_COD_CLIENTE" , "35740835"},
                { "MOVVGAP_COD_AGENCIADOR" , "0"},
                { "MOVVGAP_COD_CORRETOR" , "0"},
                { "MOVVGAP_COD_PLANOVGAP" , "0"},
                { "MOVVGAP_COD_PLANOAP" , "0"},
                { "MOVVGAP_FAIXA" , "12"},
                { "MOVVGAP_AUTOR_AUM_AUTOMAT" , "S"},
                { "MOVVGAP_TIPO_BENEFICIARIO" , "S"},
                { "MOVVGAP_PERI_PAGAMENTO" , "1"},
                { "MOVVGAP_PERI_RENOVACAO" , "12"},
                { "MOVVGAP_COD_OCUPACAO" , "    "},
                { "MOVVGAP_ESTADO_CIVIL" , "S"},
                { "MOVVGAP_IDE_SEXO" , "M"},
                { "MOVVGAP_COD_PROFISSAO" , "0"},
                { "MOVVGAP_NATURALIDADE" , "                              "},
                { "MOVVGAP_OCORR_ENDERECO" , "1"},
                { "MOVVGAP_OCORR_END_COBRAN" , "1"},
                { "MOVVGAP_BCO_COBRANCA" , "104"},
                { "MOVVGAP_AGE_COBRANCA" , "29"},
                { "MOVVGAP_DAC_COBRANCA" , " "},
                { "MOVVGAP_NUM_MATRICULA" , "0"},
                { "MOVVGAP_NUM_CTA_CORRENTE" , "1288000790142849"},
                { "MOVVGAP_DAC_CTA_CORRENTE" , "0"},
                { "MOVVGAP_VAL_SALARIO" , "0.00"},
                { "MOVVGAP_TIPO_SALARIO" , " "},
                { "MOVVGAP_TIPO_PLANO" , "1"},
                { "MOVVGAP_PCT_CONJUGE_VG" , "0.00"},
                { "MOVVGAP_PCT_CONJUGE_AP" , "0.00"},
                { "MOVVGAP_QTD_SAL_MORNATU" , "0"},
                { "MOVVGAP_QTD_SAL_MORACID" , "0"},
                { "MOVVGAP_QTD_SAL_INVPERM" , "0"},
                { "MOVVGAP_TAXA_AP_MORACID" , "0.0000"},
                { "MOVVGAP_TAXA_AP_INVPERM" , "0.0000"},
                { "MOVVGAP_TAXA_AP_AMDS" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DH" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DIT" , "0.0000"},
                { "MOVVGAP_TAXA_VG" , "0.0000"},
                { "MOVVGAP_IMP_MORNATU_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORNATU_ATU" , "20000.00"},
                { "MOVVGAP_IMP_MORACID_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORACID_ATU" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ANT" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ATU" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ANT" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ATU" , "0.00"},
                { "MOVVGAP_IMP_DH_ANT" , "0.00"},
                { "MOVVGAP_IMP_DH_ATU" , "0.00"},
                { "MOVVGAP_IMP_DIT_ANT" , "0.00"},
                { "MOVVGAP_IMP_DIT_ATU" , "0.00"},
                { "MOVVGAP_PRM_VG_ANT" , "0.00"},
                { "MOVVGAP_PRM_VG_ATU" , "217.91"},
                { "MOVVGAP_PRM_AP_ANT" , "0.00"},
                { "MOVVGAP_PRM_AP_ATU" , "0.00"},
                { "MOVVGAP_COD_OPERACAO" , "101"},
                { "MOVVGAP_DATA_AVERBACAO" , "2023-02-24"},
                { "MOVVGAP_DATA_INCLUSAO" , "2023-02-24"},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVVGAP_SIT_REGISTRO" , "1"},
                { "MOVVGAP_COD_USUARIO" , "VA0056B "},
                { "DCLPRODUTOS_VG_COD_PRODUTO" , "9729"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , "3009300001909"},
                { "MOVVGAP_COD_SUBGRUPO" , "2"},
                { "MOVVGAP_COD_FONTE" , "6"},
                { "MOVVGAP_NUM_PROPOSTA" , "13343777"},
                { "MOVVGAP_TIPO_SEGURADO" , "1"},
                { "MOVVGAP_NUM_CERTIFICADO" , "80029070000899"},
                { "MOVVGAP_DAC_CERTIFICADO" , " "},
                { "MOVVGAP_TIPO_INCLUSAO" , "4"},
                { "MOVVGAP_COD_CLIENTE" , "35740835"},
                { "MOVVGAP_COD_AGENCIADOR" , "0"},
                { "MOVVGAP_COD_CORRETOR" , "0"},
                { "MOVVGAP_COD_PLANOVGAP" , "0"},
                { "MOVVGAP_COD_PLANOAP" , "0"},
                { "MOVVGAP_FAIXA" , "12"},
                { "MOVVGAP_AUTOR_AUM_AUTOMAT" , "S"},
                { "MOVVGAP_TIPO_BENEFICIARIO" , "S"},
                { "MOVVGAP_PERI_PAGAMENTO" , "1"},
                { "MOVVGAP_PERI_RENOVACAO" , "12"},
                { "MOVVGAP_COD_OCUPACAO" , "    "},
                { "MOVVGAP_ESTADO_CIVIL" , "S"},
                { "MOVVGAP_IDE_SEXO" , "M"},
                { "MOVVGAP_COD_PROFISSAO" , "0"},
                { "MOVVGAP_NATURALIDADE" , "                              "},
                { "MOVVGAP_OCORR_ENDERECO" , "1"},
                { "MOVVGAP_OCORR_END_COBRAN" , "1"},
                { "MOVVGAP_BCO_COBRANCA" , "104"},
                { "MOVVGAP_AGE_COBRANCA" , "29"},
                { "MOVVGAP_DAC_COBRANCA" , " "},
                { "MOVVGAP_NUM_MATRICULA" , "0"},
                { "MOVVGAP_NUM_CTA_CORRENTE" , "1288000790142849"},
                { "MOVVGAP_DAC_CTA_CORRENTE" , "0"},
                { "MOVVGAP_VAL_SALARIO" , "0.00"},
                { "MOVVGAP_TIPO_SALARIO" , " "},
                { "MOVVGAP_TIPO_PLANO" , "1"},
                { "MOVVGAP_PCT_CONJUGE_VG" , "0.00"},
                { "MOVVGAP_PCT_CONJUGE_AP" , "0.00"},
                { "MOVVGAP_QTD_SAL_MORNATU" , "0"},
                { "MOVVGAP_QTD_SAL_MORACID" , "0"},
                { "MOVVGAP_QTD_SAL_INVPERM" , "0"},
                { "MOVVGAP_TAXA_AP_MORACID" , "0.0000"},
                { "MOVVGAP_TAXA_AP_INVPERM" , "0.0000"},
                { "MOVVGAP_TAXA_AP_AMDS" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DH" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DIT" , "0.0000"},
                { "MOVVGAP_TAXA_VG" , "0.0000"},
                { "MOVVGAP_IMP_MORNATU_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORNATU_ATU" , "20000.00"},
                { "MOVVGAP_IMP_MORACID_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORACID_ATU" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ANT" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ATU" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ANT" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ATU" , "0.00"},
                { "MOVVGAP_IMP_DH_ANT" , "0.00"},
                { "MOVVGAP_IMP_DH_ATU" , "0.00"},
                { "MOVVGAP_IMP_DIT_ANT" , "0.00"},
                { "MOVVGAP_IMP_DIT_ATU" , "0.00"},
                { "MOVVGAP_PRM_VG_ANT" , "0.00"},
                { "MOVVGAP_PRM_VG_ATU" , "217.91"},
                { "MOVVGAP_PRM_AP_ANT" , "0.00"},
                { "MOVVGAP_PRM_AP_ATU" , "0.00"},
                { "MOVVGAP_COD_OPERACAO" , "101"},
                { "MOVVGAP_DATA_AVERBACAO" , "2023-02-24"},
                { "MOVVGAP_DATA_INCLUSAO" , "2023-02-24"},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVVGAP_SIT_REGISTRO" , "1"},
                { "MOVVGAP_COD_USUARIO" , "VA0056B "},
                { "DCLPRODUTOS_VG_COD_PRODUTO" , "9729"}
            });
            AppSettings.TestSet.DynamicData.Add("PF0612B_MOVIMENTO_VGAP", q3);

            #endregion

            #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_SICOB" , "95701787712"},
                { "ORIGEM_PROPOSTA" , "1005"},
                { "IND_TP_PROPOSTA" , "S"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_SICOB" , "95701787712"},
                { "ORIGEM_PROPOSTA" , "1005"},
                { "IND_TP_PROPOSTA" , "S"},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "95701787712"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "95701787712"}
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , "95701787712"}
            });
            AppSettings.TestSet.DynamicData.Add("R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0210_00_LER_SICOB_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_PROPOSTA_SIVPF" , "80029070000586"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_PROPOSTA_SIVPF" , "80029070000586"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_PROPOSTA_SIVPF" , "80029070000586"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_PROPOSTA_SIVPF" , "80029070000586"},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_LER_SICOB_DB_SELECT_1_Query1", q6);

            #endregion

            #region PF0612B_CUR_PARCELVA

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "DCLHIST_CONT_PARCELVA_PREMIO_VG" , ""},
                { "DCLHIST_CONT_PARCELVA_PREMIO_AP" , ""},
                { "DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0612B_CUR_PARCELVA", q7);

            #endregion

            #region R0216_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0216_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , ""},
                { "COD_PRODUTO" , ""},
                { "COD_CLIENTE" , ""},
                { "OCOREND" , ""},
                { "COD_FONTE" , ""},
                { "AGE_COBRANCA" , ""},
                { "OPCAO_COBERTURA" , ""},
                { "DATA_QUITACAO" , ""},
                { "COD_AGE_VENDEDOR" , ""},
                { "OPE_CONTA_VENDEDOR" , ""},
                { "NUM_CONTA_VENDEDOR" , ""},
                { "DIG_CONTA_VENDEDOR" , ""},
                { "NUM_MATRI_VENDEDOR" , ""},
                { "COD_OPERACAO" , ""},
                { "PROFISSAO" , ""},
                { "DTINCLUS" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "SIT_REGISTRO" , ""},
                { "NUM_APOLICE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "NRPRIPARATZ" , ""},
                { "QTDPARATZ" , ""},
                { "DTPROXVEN" , ""},
                { "NUM_PARCELA" , ""},
                { "DATA_VENCIMENTO" , ""},
                { "SIT_INTERFACE" , ""},
                { "DTFENAE" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
                { "IDADE" , ""},
                { "IDE_SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "APOS_INVALIDEZ" , ""},
                { "NOME_ESPOSA" , ""},
                { "DTNASC_ESPOSA" , ""},
                { "PROFIS_ESPOSA" , ""},
                { "DPS_TITULAR" , ""},
                { "DPS_ESPOSA" , ""},
                { "INFO_COMPLEMENTAR" , ""},
                { "COD_CCT" , ""},
                { "FAIXA_RENDA_IND" , ""},
                { "FAIXA_RENDA_FAM" , ""},
                { "COD_ORIGEM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            }); q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "11696828805"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1950-07-20"},
            });

            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0350_00_LER_ENDERECO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "0"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "ERREJOTA"},
                { "ENDERECO_CEP" , "88301451"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "334218810"},
                { "ENDERECO_FAX" , "3342188100"},
                { "ENDERECO_TELEX" , "334218810"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "0"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "ERREJOTA"},
                { "ENDERECO_CEP" , "88301451"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "334218810"},
                { "ENDERECO_FAX" , "3342188100"},
                { "ENDERECO_TELEX" , "334218810"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "0"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "ERREJOTA"},
                { "ENDERECO_CEP" , "88301451"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "334218810"},
                { "ENDERECO_FAX" , "3342188100"},
                { "ENDERECO_TELEX" , "334218810"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "0"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "ERREJOTA"},
                { "ENDERECO_CEP" , "88301451"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "334218810"},
                { "ENDERECO_FAX" , "3342188100"},
                { "ENDERECO_TELEX" , "334218810"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_LER_ENDERECO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0410_00_LER_CBO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_LER_CBO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "7"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "8"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "8"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "9"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });

            AppSettings.TestSet.DynamicData.Add("R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0500_00_LER_RCAP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211303130"},
                { "RCAPS_NUM_CERTIFICADO" , "13000000000402"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211303130"},
                { "RCAPS_NUM_CERTIFICADO" , "13000000000402"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211303130"},
                { "RCAPS_NUM_CERTIFICADO" , "13000000000402"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211303130"},
                { "RCAPS_NUM_CERTIFICADO" , "13000000000402"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211303130"},
                { "RCAPS_NUM_CERTIFICADO" , "13000000000402"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211303130"},
                { "RCAPS_NUM_CERTIFICADO" , "13000000000402"},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LER_RCAP_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0500_00_LER_RCAP_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211314408"},

            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "1"},
                { "RCAPS_COD_OPERACAO" , "110"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LER_RCAP_DB_SELECT_2_Query1", q15);

            #endregion

            #region R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "850"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1994-05-31"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "3"},
                { "OPPAGVA_PERI_PAGAMENTO" , "12"},
                { "OPPAGVA_DIA_DEBITO" , "17"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "1"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "145"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "123"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1", q16);

            #endregion

            #region PF0612B_FUNDOCOMISVA

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , "0"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , "6.82"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , "2.27"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , "0"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , "6.82"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , "2.27"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0612B_FUNDOCOMISVA", q17);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "2,19"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "2,19"}
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "2,19"}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0610_00_SEGURAVG_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_DATA_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_SEGURAVG_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0620_00_DADOS_RG_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_DADOS_RG_DB_SELECT_1_Query1", q20);

            #endregion

            #region PF0612B_BENEFICIARIOS

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "BENEFPRO_NUM_APOLICE" , "97010000889"},
                { "BENEFPRO_COD_SUBGRUPO" , "3603"},
                { "BENEFPRO_COD_FONTE" , "0"},
                { "BENEFPRO_NUM_PROPOSTA" , "-14939"},
                { "BENEFPRO_NUM_BENEFICIARIO" , "1"},
                { "BENEFPRO_NOME_BENEFICIARIO" , "GUS PAss"},
                { "BENEFPRO_GRAU_PARENTESCO" , "FILHO     "},
                { "BENEFPRO_PCT_PART_BENEFICIA" , "30"},
            });
            q21.AddDynamic(new Dictionary<string, string>{
                { "BENEFPRO_NUM_APOLICE" , "97010000889"},
                { "BENEFPRO_COD_SUBGRUPO" , "3603"},
                { "BENEFPRO_COD_FONTE" , "0"},
                { "BENEFPRO_NUM_PROPOSTA" , "-14939"},
                { "BENEFPRO_NUM_BENEFICIARIO" , "1"},
                { "BENEFPRO_NOME_BENEFICIARIO" , "GUS PAss"},
                { "BENEFPRO_GRAU_PARENTESCO" , "ESPOSA     "},
                { "BENEFPRO_PCT_PART_BENEFICIA" , "30"},
            });
            q21.AddDynamic(new Dictionary<string, string>{
                { "BENEFPRO_NUM_APOLICE" , "97010000889"},
                { "BENEFPRO_COD_SUBGRUPO" , "3603"},
                { "BENEFPRO_COD_FONTE" , "0"},
                { "BENEFPRO_NUM_PROPOSTA" , "-14939"},
                { "BENEFPRO_NUM_BENEFICIARIO" , "1"},
                { "BENEFPRO_NOME_BENEFICIARIO" , "GUS PAss"},
                { "BENEFPRO_GRAU_PARENTESCO" , "ESPOSA     "},
                { "BENEFPRO_PCT_PART_BENEFICIA" , "30"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0612B_BENEFICIARIOS", q21);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "TIPO_IDENT_SIVPF" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "COD_CBO" , ""},
                { "COD_USUARIO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q25);

            #endregion

            #region R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1", q27);

            #endregion

            #region R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "COD_USUARIO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "COD_CBO" , ""},
                { "TIPO_IDENT_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q29);

            #endregion

            #region PF0612B_EMAIL

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , "12"},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "3"},
                { "DCLPESSOA_EMAIL_EMAIL" , "asdasdasdasd"},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
            });
            q30.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , "12"},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "3"},
                { "DCLPESSOA_EMAIL_EMAIL" , "asdasdasdasd"},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
            });
            q30.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , "12"},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "3"},
                { "DCLPESSOA_EMAIL_EMAIL" , "asdasdasdasd"},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0612B_EMAIL", q30);

            #endregion

            #region R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q31);

            #endregion

            #region R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "12"},
                { "PESSOA_NOME_PESSOA" , "gus"},
                { "PESSOA_TIPO_PESSOA" , "boa"},
                { "PESSOA_TIMESTAMP" , "2020-12-30"},
                { "PESSOA_COD_USUARIO" , "10"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "12"},
                { "PESSOA_NOME_PESSOA" , "gus"},
                { "PESSOA_TIPO_PESSOA" , "boa"},
                { "PESSOA_TIMESTAMP" , "2020-12-30"},
                { "PESSOA_COD_USUARIO" , "10"},
            });
            q33.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "12"},
                { "PESSOA_NOME_PESSOA" , "gus"},
                { "PESSOA_TIPO_PESSOA" , "boa"},
                { "PESSOA_TIMESTAMP" , "2020-12-30"},
                { "PESSOA_COD_USUARIO" , "10"},
            });
            AppSettings.TestSet.DynamicData.Add("R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1", q33);

            #endregion

            #region R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , "3"}
            });
            q34.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , "3"}
            });
            q34.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , "3"}
            });
            AppSettings.TestSet.DynamicData.Add("R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q34);

            #endregion

            #region R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "12"},
                { "SEQ_EMAIL" , "12"},
                { "EMAIL" , "gus@hotmail.com"},
                { "SITUACAO_EMAIL" , "A"},
                { "COD_USUARIO" , "10"},
                { "TIMESTAMP" , "2020-10-01"},
            });
            q35.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "12"},
                { "SEQ_EMAIL" , "12"},
                { "EMAIL" , "gus@hotmail.com"},
                { "SITUACAO_EMAIL" , "A"},
                { "COD_USUARIO" , "10"},
                { "TIMESTAMP" , "2020-10-01"},
            });
            q35.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "12"},
                { "SEQ_EMAIL" , "12"},
                { "EMAIL" , "gus@hotmail.com"},
                { "SITUACAO_EMAIL" , "A"},
                { "COD_USUARIO" , "10"},
                { "TIMESTAMP" , "2020-10-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1", q35);

            #endregion

            #region PF0612B_ENDERECOS

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_COD_PESSOA" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0612B_ENDERECOS", q36);

            #endregion

            #region R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1", q37);

            #endregion

            #region R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "OCORR_ENDERECO" , ""},
                { "ENDERECO" , ""},
                { "TIPO_ENDER" , ""},
                { "BAIRRO" , ""},
                { "CEP" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "SITUACAO_ENDERECO" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R3255_LER_TELEFONE_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            AppSettings.TestSet.DynamicData.Add("R3255_LER_TELEFONE_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "1235"}
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "1235"}
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "1235"}
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "1235"}
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "1235"}
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "1235"}
            });
            AppSettings.TestSet.DynamicData.Add("R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1", q40);

            #endregion

            #region R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "SEQ_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1", q41);

            #endregion

            #region R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "12"},
                { "PRDSIVPF_COD_PRODUTO" , "2"},
                { "PRDSIVPF_COD_RELAC" , "2"},
            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "12"},
                { "PRDSIVPF_COD_PRODUTO" , "2"},
                { "PRDSIVPF_COD_RELAC" , "2"},

            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "12"},
                { "PRDSIVPF_COD_PRODUTO" , "2"},
                { "PRDSIVPF_COD_RELAC" , "2"},
            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "12"},
                { "PRDSIVPF_COD_PRODUTO" , "2"},
                { "PRDSIVPF_COD_RELAC" , "2"},
            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "12"},
                { "PRDSIVPF_COD_PRODUTO" , "2"},
                { "PRDSIVPF_COD_RELAC" , "2"},
            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "12"},
                { "PRDSIVPF_COD_PRODUTO" , "2"},
                { "PRDSIVPF_COD_RELAC" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1", q42);

            #endregion

            #region R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "1"},
                { "COD_RELAC" , "3"},
            });
            q43.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "1"},
                { "COD_RELAC" , "3"},
            });
            q43.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "1"},
                { "COD_RELAC" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q43);

            #endregion

            #region R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""},
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "32"}
            });
            q46.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "32"}
            });
            q46.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "32"}
            });
            AppSettings.TestSet.DynamicData.Add("R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1", q46);

            #endregion

            #region R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_IDENTIFICACAO" , ""},
                { "COD_EMPRESA_SIVPF" , ""},
                { "COD_PESSOA" , ""},
                { "NUM_SICOB" , ""},
                { "DATA_PROPOSTA" , ""},
                { "COD_PRODUTO_SIVPF" , ""},
                { "AGECOBR" , ""},
                { "DIA_DEBITO" , ""},
                { "OPCAOPAG" , ""},
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "PERC_DESCONTO" , ""},
                { "NRMATRVEN" , ""},
                { "AGECTAVEN" , ""},
                { "OPRCTAVEN" , ""},
                { "NUMCTAVEN" , ""},
                { "DIGCTAVEN" , ""},
                { "CGC_CONVENENTE" , ""},
                { "NOME_CONVENENTE" , ""},
                { "NRMATRCON" , ""},
                { "DTQITBCO" , ""},
                { "VAL_PAGO" , ""},
                { "AGEPGTO" , ""},
                { "VAL_TARIFA" , ""},
                { "VAL_IOF" , ""},
                { "DATA_CREDITO" , ""},
                { "VAL_COMISSAO" , ""},
                { "SIT_PROPOSTA" , ""},
                { "COD_USUARIO" , ""},
                { "CANAL_PROPOSTA" , ""},
                { "NSAS_SIVPF" , ""},
                { "ORIGEM_PROPOSTA" , ""},
                { "NSL" , ""},
                { "NSAC_SIVPF" , ""},
                { "SITUACAO_ENVIO" , ""},
                { "OPCAO_COBER" , ""},
                { "COD_PLANO" , ""},
                { "NOME_CONJUGE" , ""},
                { "DATA_NASC_CONJUGE" , ""},
                { "PROFISSAO_CONJUGE" , ""},
                { "FAIXA_RENDA_IND" , ""},
                { "FAIXA_RENDA_FAM" , ""},
                { "IND_TP_PROPOSTA" , ""},
                { "IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_IDENTIFICACAO" , ""},
                { "PROPSSVD_DPS_TITULAR" , ""},
                { "PROPSSVD_DPS_CONJUGE" , ""},
                { "PROPSSVD_APOS_INVALIDEZ" , ""},
                { "PROPSSVD_COD_USUARIO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1", q48);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q49);

            #endregion

            #region R3393_NUMERAR_SICOB_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_NUM_TITULO_MAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3393_NUMERAR_SICOB_DB_SELECT_1_Query1", q50);

            #endregion

            #region R3393_NUMERAR_SICOB_DB_UPDATE_2_Update1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R3393_NUMERAR_SICOB_DB_UPDATE_2_Update1", q51);

            #endregion

            #region R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_SICOB" , ""},
                { "COD_EMPRESA_SIVPF" , ""},
                { "PRODUTO_SIVPF" , ""},
                { "AGEPGTO" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1", q52);

            #endregion

            SPBGE053_Tests.Load_Parameters();
            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0612B.txt")]
        public static void PF0612B_Tests_Theory(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SIT_PROPOSTA" , "EMT"},
                    { "NUM_SICOB" , "95701787712"},
                    { "ORIGEM_PROPOSTA" , "8"},
                    { "IND_TP_PROPOSTA" , "S"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SIT_PROPOSTA" , "EMT"},
                    { "NUM_SICOB" , "95701787712"},
                    { "ORIGEM_PROPOSTA" , "8"},
                    { "IND_TP_PROPOSTA" , "S"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SIT_PROPOSTA" , "EMT"},
                    { "NUM_SICOB" , "95701787712"},
                    { "ORIGEM_PROPOSTA" , "8"},
                    { "IND_TP_PROPOSTA" , "S"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

                #endregion
                #endregion
                var program = new PF0612B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length > 0);

                var envList1 = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("PRPSASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

                var envList = AppSettings.TestSet.DynamicData["R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var val4r) && val4r.Contains("2023-02-24"));


            }
        }
        [Theory]
        [InlineData("Saida_PF0612B.txt")]
        public static void PF0612B_Tests_TheoryFluxoSem(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SPBGE053
                #region PARAMETERS
                #region SPBGE053_CSR_NOM_SOCIAL
                AppSettings.TestSet.DynamicData.Remove("SPBGE053_CSR_NOM_SOCIAL");

                var q00 = new DynamicData();
                q00.AddDynamic(new Dictionary<string, string>{
                 { "NUM_CPF" , "03574845928"},
                 { "DTH_OPERACAO" , "2024-06-04 21:17:05.975"},
                 { "CASE_IND_USA_NOME_SOCIAL" , "NOME SOCIAL TESTE"},
                 { "IND_TIPO_ACAO" , "I"},
                 { "IND_USA_NOME_SOCIAL" , "S"},
                 { "IFNULL_" , ""},
                 { "COD_CANAL_ORIGEM" , "0007      "},
                 { "NUM_MATRICULA" , "SPBGE052            "},
                 { "NOM_PROGRAMA" , "SPBGE053  "},
                 { "DTH_CADASTRAMENTO" , "2024-06-04 21:17:05.975"},
             }); q00.AddDynamic(new Dictionary<string, string>{
                 { "NUM_CPF" , "03574845928"},
                 { "DTH_OPERACAO" , "2024-06-04 21:17:05.975"},
                 { "CASE_IND_USA_NOME_SOCIAL" , "NOME SOCIAL TESTE"},
                 { "IND_TIPO_ACAO" , "I"},
                 { "IND_USA_NOME_SOCIAL" , "S"},
                 { "IFNULL_" , ""},
                 { "COD_CANAL_ORIGEM" , "0007      "},
                 { "NUM_MATRICULA" , "SPBGE052            "},
                 { "NOM_PROGRAMA" , "SPBGE053  "},
                 { "DTH_CADASTRAMENTO" , "2024-06-04 21:17:05.975"},
             });
               AppSettings.TestSet.DynamicData.Add("SPBGE053_CSR_NOM_SOCIAL", q00);

               #endregion

               #region P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1
               AppSettings.TestSet.DynamicData.Remove("P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1");

               var q11 = new DynamicData();
               q11.AddDynamic(new Dictionary<string, string>{
                 { "SISTEMAS_DATA_MOV_ABERTO" , "2000-01-01"}
             }); q11.AddDynamic(new Dictionary<string, string>{
                 { "SISTEMAS_DATA_MOV_ABERTO" , "2000-01-01"}
             });
               AppSettings.TestSet.DynamicData.Add("P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1", q11);

               #endregion

               #region P2020_INSERE_GE149_DB_INSERT_1_Insert1
               AppSettings.TestSet.DynamicData.Remove("P2020_INSERE_GE149_DB_INSERT_1_Insert1");

               var q22 = new DynamicData();
               q22.AddDynamic(new Dictionary<string, string>{
                 { "GE149_NUM_CPF" , ""},
                 { "GE149_DTH_OPERACAO" , ""},
                 { "GE149_NOM_SOCIAL" , ""},
                 { "GE149_IND_TIPO_ACAO" , ""},
                 { "GE149_IND_USA_NOME_SOCIAL" , ""},
                 { "GE149_COD_TP_PES_NEGOCIO" , ""},
                 { "GE149_NUM_PROPOSTA" , ""},
                 { "GE149_COD_CANAL_ORIGEM" , ""},
                 { "GE149_NUM_MATRICULA" , ""},
                 { "GE149_NOM_PROGRAMA" , ""},
             }); q22.AddDynamic(new Dictionary<string, string>{
                 { "GE149_NUM_CPF" , ""},
                 { "GE149_DTH_OPERACAO" , ""},
                 { "GE149_NOM_SOCIAL" , ""},
                 { "GE149_IND_TIPO_ACAO" , ""},
                 { "GE149_IND_USA_NOME_SOCIAL" , ""},
                 { "GE149_COD_TP_PES_NEGOCIO" , ""},
                 { "GE149_NUM_PROPOSTA" , ""},
                 { "GE149_COD_CANAL_ORIGEM" , ""},
                 { "GE149_NUM_MATRICULA" , ""},
                 { "GE149_NOM_PROGRAMA" , ""},
             });
               AppSettings.TestSet.DynamicData.Add("P2020_INSERE_GE149_DB_INSERT_1_Insert1", q22);

               #endregion

               #region P2030_CONSULTA_GE149_DB_SELECT_1_Query1
               AppSettings.TestSet.DynamicData.Remove("P2030_CONSULTA_GE149_DB_SELECT_1_Query1");

               var q33 = new DynamicData();
               q33.AddDynamic(new Dictionary<string, string>{
                 { "GE149_NUM_CPF" , ""},
                 { "GE149_DTH_OPERACAO" , ""},
                 { "GE149_NOM_SOCIAL" , ""},
                 { "GE149_IND_TIPO_ACAO" , ""},
                 { "GE149_IND_USA_NOME_SOCIAL" , ""},
                 { "GE149_COD_TP_PES_NEGOCIO" , ""},
                 { "GE149_NUM_PROPOSTA" , ""},
                 { "GE149_COD_CANAL_ORIGEM" , ""},
                 { "GE149_NUM_MATRICULA" , ""},
                 { "GE149_NOM_PROGRAMA" , ""},
                 { "GE149_DTH_CADASTRAMENTO" , ""},
             }); q33.AddDynamic(new Dictionary<string, string>{
                 { "GE149_NUM_CPF" , ""},
                 { "GE149_DTH_OPERACAO" , ""},
                 { "GE149_NOM_SOCIAL" , ""},
                 { "GE149_IND_TIPO_ACAO" , ""},
                 { "GE149_IND_USA_NOME_SOCIAL" , ""},
                 { "GE149_COD_TP_PES_NEGOCIO" , ""},
                 { "GE149_NUM_PROPOSTA" , ""},
                 { "GE149_COD_CANAL_ORIGEM" , ""},
                 { "GE149_NUM_MATRICULA" , ""},
                 { "GE149_NOM_PROGRAMA" , ""},
                 { "GE149_DTH_CADASTRAMENTO" , ""},
             });
                AppSettings.TestSet.DynamicData.Add("P2030_CONSULTA_GE149_DB_SELECT_1_Query1", q33);

                #endregion

                #endregion
                #endregion
                #region PF0612B_MOVIMENTO_VGAP
                AppSettings.TestSet.DynamicData.Remove("PF0612B_MOVIMENTO_VGAP");

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MOVVGAP_NUM_APOLICE" , "3009300001909"},
                { "MOVVGAP_COD_SUBGRUPO" , "2"},
                { "MOVVGAP_COD_FONTE" , "6"},
                { "MOVVGAP_NUM_PROPOSTA" , "20977619"},
                { "MOVVGAP_TIPO_SEGURADO" , "1"},
                { "MOVVGAP_NUM_CERTIFICADO" , "80029070000586"},
                { "MOVVGAP_DAC_CERTIFICADO" , " "},
                { "MOVVGAP_TIPO_INCLUSAO" , "4"},
                { "MOVVGAP_COD_CLIENTE" , "35740835"},
                { "MOVVGAP_COD_AGENCIADOR" , "0"},
                { "MOVVGAP_COD_CORRETOR" , "0"},
                { "MOVVGAP_COD_PLANOVGAP" , "0"},
                { "MOVVGAP_COD_PLANOAP" , "0"},
                { "MOVVGAP_FAIXA" , "12"},
                { "MOVVGAP_AUTOR_AUM_AUTOMAT" , "S"},
                { "MOVVGAP_TIPO_BENEFICIARIO" , "S"},
                { "MOVVGAP_PERI_PAGAMENTO" , "1"},
                { "MOVVGAP_PERI_RENOVACAO" , "12"},
                { "MOVVGAP_COD_OCUPACAO" , "    "},
                { "MOVVGAP_ESTADO_CIVIL" , "S"},
                { "MOVVGAP_IDE_SEXO" , "M"},
                { "MOVVGAP_COD_PROFISSAO" , "0"},
                { "MOVVGAP_NATURALIDADE" , "                              "},
                { "MOVVGAP_OCORR_ENDERECO" , "1"},
                { "MOVVGAP_OCORR_END_COBRAN" , "1"},
                { "MOVVGAP_BCO_COBRANCA" , "104"},
                { "MOVVGAP_AGE_COBRANCA" , "29"},
                { "MOVVGAP_DAC_COBRANCA" , " "},
                { "MOVVGAP_NUM_MATRICULA" , "0"},
                { "MOVVGAP_NUM_CTA_CORRENTE" , "1288000790142849"},
                { "MOVVGAP_DAC_CTA_CORRENTE" , "0"},
                { "MOVVGAP_VAL_SALARIO" , "0.00"},
                { "MOVVGAP_TIPO_SALARIO" , " "},
                { "MOVVGAP_TIPO_PLANO" , "1"},
                { "MOVVGAP_PCT_CONJUGE_VG" , "0.00"},
                { "MOVVGAP_PCT_CONJUGE_AP" , "0.00"},
                { "MOVVGAP_QTD_SAL_MORNATU" , "0"},
                { "MOVVGAP_QTD_SAL_MORACID" , "0"},
                { "MOVVGAP_QTD_SAL_INVPERM" , "0"},
                { "MOVVGAP_TAXA_AP_MORACID" , "0.0000"},
                { "MOVVGAP_TAXA_AP_INVPERM" , "0.0000"},
                { "MOVVGAP_TAXA_AP_AMDS" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DH" , "0.0000"},
                { "MOVVGAP_TAXA_AP_DIT" , "0.0000"},
                { "MOVVGAP_TAXA_VG" , "0.0000"},
                { "MOVVGAP_IMP_MORNATU_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORNATU_ATU" , "20000.00"},
                { "MOVVGAP_IMP_MORACID_ANT" , "0.00"},
                { "MOVVGAP_IMP_MORACID_ATU" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ANT" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ATU" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ANT" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ATU" , "0.00"},
                { "MOVVGAP_IMP_DH_ANT" , "0.00"},
                { "MOVVGAP_IMP_DH_ATU" , "0.00"},
                { "MOVVGAP_IMP_DIT_ANT" , "0.00"},
                { "MOVVGAP_IMP_DIT_ATU" , "0.00"},
                { "MOVVGAP_PRM_VG_ANT" , "0.00"},
                { "MOVVGAP_PRM_VG_ATU" , "217.91"},
                { "MOVVGAP_PRM_AP_ANT" , "0.00"},
                { "MOVVGAP_PRM_AP_ATU" , "0.00"},
                { "MOVVGAP_COD_OPERACAO" , "101"},
                { "MOVVGAP_DATA_AVERBACAO" , "2023-02-24"},
                { "MOVVGAP_DATA_INCLUSAO" , "2023-02-24"},
                { "MOVVGAP_COD_SUBGRUPO_TRANS" , "0"},
                { "MOVVGAP_SIT_REGISTRO" , "1"},
                { "MOVVGAP_COD_USUARIO" , "VA0056B "},
                { "DCLPRODUTOS_VG_COD_PRODUTO" , "9729"}
            });
                AppSettings.TestSet.DynamicData.Add("PF0612B_MOVIMENTO_VGAP", q3);

                #endregion
                #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_SICOB" , "95701787712"},
                { "ORIGEM_PROPOSTA" , "1005"},
                { "IND_TP_PROPOSTA" , "S"},
            });

                AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

                #endregion
                #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

                var q10 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1");
                q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "35740835"},
                { "NOME_RAZAO" , "JOSE MARIA DA SILVA                     "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "123"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "-1"},
            });
                AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q10);

                #endregion
                #region R0210_00_LER_SICOB_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SIT_PROPOSTA" , "EMT"},
                    { "NUM_PROPOSTA_SIVPF" , "80029070000586"},
                });

                AppSettings.TestSet.DynamicData.Remove("R0210_00_LER_SICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_LER_SICOB_DB_SELECT_1_Query1", q6);



                #endregion

                #endregion
                var program = new PF0612B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);


            }
        }

        [Theory]
        [InlineData("Saida_PF0612B.txt")]
        public static void PF0612B_Tests_TheoryErr99(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new PF0612B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);



            }
        }

    }
}