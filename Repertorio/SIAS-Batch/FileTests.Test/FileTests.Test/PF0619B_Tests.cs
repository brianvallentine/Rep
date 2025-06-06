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
using static Code.PF0619B;
using System.IO;
using Sias.PessoaFisica.DB2.PF0619B;

namespace FileTests.Test
{
    [Collection("PF0619B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0619B_Tests
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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "124546"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region PF0619B_PROPOSTAS_VA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                {"DCLPROPOSTAS_VA_NUM_CERTIFICADO" , "19999999950"},
                {"DCLPROPOSTAS_VA_COD_PRODUTO" , "9321"},
                {"DCLPROPOSTAS_VA_COD_CLIENTE" , "13527943"},
                {"DCLPROPOSTAS_VA_OCOREND" , "1"},
                {"DCLPROPOSTAS_VA_COD_FONTE" , "20"},
                {"DCLPROPOSTAS_VA_AGE_COBRANCA" , "1880"},
                {"DCLPROPOSTAS_VA_OPCAO_COBERTURA" , "C"},
                {"DCLPROPOSTAS_VA_DATA_QUITACAO" , "2008-07-31"},
                {"DCLPROPOSTAS_VA_COD_AGE_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR" , "895043"},
                {"DCLPROPOSTAS_VA_COD_OPERACAO" , "106"},
                {"DCLPROPOSTAS_VA_PROFISSAO" , "ADMINISTRADOR       "},
                {"DCLPROPOSTAS_VA_DTINCLUS" , "2008-08-01"},
                {"DCLPROPOSTAS_VA_DATA_MOVIMENTO" , "2008-07-31"},
                {"DCLPROPOSTAS_VA_SIT_REGISTRO" , "2"},
                {"DCLPROPOSTAS_VA_NUM_APOLICE" , "109300000550"},
                {"DCLPROPOSTAS_VA_COD_SUBGRUPO" , "12"},
                {"DCLPROPOSTAS_VA_OCORR_HISTORICO" , "1"},
                {"DCLPROPOSTAS_VA_NRPRIPARATZ" , "0"},
                {"DCLPROPOSTAS_VA_QTDPARATZ" , "0"},
                {"DCLPROPOSTAS_VA_DTPROXVEN" , "2010-08-01"},
                {"DCLPROPOSTAS_VA_NUM_PARCELA" , "2"},
                {"DCLPROPOSTAS_VA_DATA_VENCIMENTO" , "2009-08-01"},
                {"DCLPROPOSTAS_VA_SIT_INTERFACE" , "0"},
                {"DCLPROPOSTAS_VA_DTFENAE" , "2008-08-01"},
                {"DCLPROPOSTAS_VA_COD_USUARIO" , "TER00292"},
                {"DCLPROPOSTAS_VA_IDADE" , "32"},
                {"DCLPROPOSTAS_VA_IDE_SEXO" , "M"},
                {"DCLPROPOSTAS_VA_ESTADO_CIVIL" , "C"},
                {"DCLPROPOSTAS_VA_APOS_INVALIDEZ" , "N"},
                {"DCLPROPOSTAS_VA_NOME_ESPOSA" , "GICELE ANGELITA LANSER CORREA           "},
                {"DCLPROPOSTAS_VA_DTNASC_ESPOSA" , "1976-03-10"},
                {"DCLPROPOSTAS_VA_PROFIS_ESPOSA" , "ADMINISTRADOR       "},
                {"DCLPROPOSTAS_VA_DPS_TITULAR" , "SNNNNNN                  "},
                {"DCLPROPOSTAS_VA_DPS_ESPOSA" , "SNNNNNN                  "},
                {"DCLPROPOSTAS_VA_GRAU_PARENTESCO" , ""},
                {"DCLPROPOSTAS_VA_NUM_PROPOSTA" , ""},
                {"DCLPROPOSTAS_VA_INFO_COMPLEMENTAR" , "                                                  "},
                {"DCLPROPOSTAS_VA_COD_CCT" , ""},
                {"DCLPROPOSTAS_VA_FAIXA_RENDA_IND" , "2"},
                {"DCLPROPOSTAS_VA_FAIXA_RENDA_FAM" , "2"},
                {"DCLPROPOSTAS_VA_COD_ORIGEM_PROPOSTA" , ""}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                {"DCLPROPOSTAS_VA_NUM_CERTIFICADO" , "24"},
                {"DCLPROPOSTAS_VA_COD_PRODUTO" , "9321"},
                {"DCLPROPOSTAS_VA_COD_CLIENTE" , "13527943"},
                {"DCLPROPOSTAS_VA_OCOREND" , "1"},
                {"DCLPROPOSTAS_VA_COD_FONTE" , "20"},
                {"DCLPROPOSTAS_VA_AGE_COBRANCA" , "1880"},
                {"DCLPROPOSTAS_VA_OPCAO_COBERTURA" , "C"},
                {"DCLPROPOSTAS_VA_DATA_QUITACAO" , "2008-07-31"},
                {"DCLPROPOSTAS_VA_COD_AGE_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR" , "895043"},
                {"DCLPROPOSTAS_VA_COD_OPERACAO" , "106"},
                {"DCLPROPOSTAS_VA_PROFISSAO" , "ADMINISTRADOR       "},
                {"DCLPROPOSTAS_VA_DTINCLUS" , "2008-08-01"},
                {"DCLPROPOSTAS_VA_DATA_MOVIMENTO" , "2008-07-31"},
                {"DCLPROPOSTAS_VA_SIT_REGISTRO" , "2"},
                {"DCLPROPOSTAS_VA_NUM_APOLICE" , "109300000550"},
                {"DCLPROPOSTAS_VA_COD_SUBGRUPO" , "12"},
                {"DCLPROPOSTAS_VA_OCORR_HISTORICO" , "1"},
                {"DCLPROPOSTAS_VA_NRPRIPARATZ" , "0"},
                {"DCLPROPOSTAS_VA_QTDPARATZ" , "0"},
                {"DCLPROPOSTAS_VA_DTPROXVEN" , "2010-08-01"},
                {"DCLPROPOSTAS_VA_NUM_PARCELA" , "2"},
                {"DCLPROPOSTAS_VA_DATA_VENCIMENTO" , "2009-08-01"},
                {"DCLPROPOSTAS_VA_SIT_INTERFACE" , "0"},
                {"DCLPROPOSTAS_VA_DTFENAE" , "2008-08-01"},
                {"DCLPROPOSTAS_VA_COD_USUARIO" , "TER00292"},
                {"DCLPROPOSTAS_VA_IDADE" , "32"},
                {"DCLPROPOSTAS_VA_IDE_SEXO" , "M"},
                {"DCLPROPOSTAS_VA_ESTADO_CIVIL" , "C"},
                {"DCLPROPOSTAS_VA_APOS_INVALIDEZ" , "N"},
                {"DCLPROPOSTAS_VA_NOME_ESPOSA" , "GICELE ANGELITA LANSER CORREA           "},
                {"DCLPROPOSTAS_VA_DTNASC_ESPOSA" , "1976-03-10"},
                {"DCLPROPOSTAS_VA_PROFIS_ESPOSA" , "ADMINISTRADOR       "},
                {"DCLPROPOSTAS_VA_DPS_TITULAR" , "SNNNNNN                  "},
                {"DCLPROPOSTAS_VA_DPS_ESPOSA" , "SNNNNNN                  "},
                {"DCLPROPOSTAS_VA_GRAU_PARENTESCO" , ""},
                {"DCLPROPOSTAS_VA_NUM_PROPOSTA" , ""},
                {"DCLPROPOSTAS_VA_INFO_COMPLEMENTAR" , "                                                  "},
                {"DCLPROPOSTAS_VA_COD_CCT" , ""},
                {"DCLPROPOSTAS_VA_FAIXA_RENDA_IND" , "2"},
                {"DCLPROPOSTAS_VA_FAIXA_RENDA_FAM" , "2"},
                {"DCLPROPOSTAS_VA_COD_ORIGEM_PROPOSTA" , ""}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                {"DCLPROPOSTAS_VA_NUM_CERTIFICADO" , "24"},
                {"DCLPROPOSTAS_VA_COD_PRODUTO" , "9321"},
                {"DCLPROPOSTAS_VA_COD_CLIENTE" , "13527943"},
                {"DCLPROPOSTAS_VA_OCOREND" , "1"},
                {"DCLPROPOSTAS_VA_COD_FONTE" , "20"},
                {"DCLPROPOSTAS_VA_AGE_COBRANCA" , "1880"},
                {"DCLPROPOSTAS_VA_OPCAO_COBERTURA" , "C"},
                {"DCLPROPOSTAS_VA_DATA_QUITACAO" , "2008-07-31"},
                {"DCLPROPOSTAS_VA_COD_AGE_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR" , "0"},
                {"DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR" , "895043"},
                {"DCLPROPOSTAS_VA_COD_OPERACAO" , "106"},
                {"DCLPROPOSTAS_VA_PROFISSAO" , "ADMINISTRADOR       "},
                {"DCLPROPOSTAS_VA_DTINCLUS" , "2008-08-01"},
                {"DCLPROPOSTAS_VA_DATA_MOVIMENTO" , "2008-07-31"},
                {"DCLPROPOSTAS_VA_SIT_REGISTRO" , "2"},
                {"DCLPROPOSTAS_VA_NUM_APOLICE" , "109300000550"},
                {"DCLPROPOSTAS_VA_COD_SUBGRUPO" , "12"},
                {"DCLPROPOSTAS_VA_OCORR_HISTORICO" , "1"},
                {"DCLPROPOSTAS_VA_NRPRIPARATZ" , "0"},
                {"DCLPROPOSTAS_VA_QTDPARATZ" , "0"},
                {"DCLPROPOSTAS_VA_DTPROXVEN" , "2010-08-01"},
                {"DCLPROPOSTAS_VA_NUM_PARCELA" , "2"},
                {"DCLPROPOSTAS_VA_DATA_VENCIMENTO" , "2009-08-01"},
                {"DCLPROPOSTAS_VA_SIT_INTERFACE" , "0"},
                {"DCLPROPOSTAS_VA_DTFENAE" , "2008-08-01"},
                {"DCLPROPOSTAS_VA_COD_USUARIO" , "TER00292"},
                {"DCLPROPOSTAS_VA_IDADE" , "32"},
                {"DCLPROPOSTAS_VA_IDE_SEXO" , "M"},
                {"DCLPROPOSTAS_VA_ESTADO_CIVIL" , "C"},
                {"DCLPROPOSTAS_VA_APOS_INVALIDEZ" , "N"},
                {"DCLPROPOSTAS_VA_NOME_ESPOSA" , "GICELE ANGELITA LANSER CORREA           "},
                {"DCLPROPOSTAS_VA_DTNASC_ESPOSA" , "1976-03-10"},
                {"DCLPROPOSTAS_VA_PROFIS_ESPOSA" , "ADMINISTRADOR       "},
                {"DCLPROPOSTAS_VA_DPS_TITULAR" , "SNNNNNN                  "},
                {"DCLPROPOSTAS_VA_DPS_ESPOSA" , "SNNNNNN                  "},
                {"DCLPROPOSTAS_VA_GRAU_PARENTESCO" , ""},
                {"DCLPROPOSTAS_VA_NUM_PROPOSTA" , ""},
                {"DCLPROPOSTAS_VA_INFO_COMPLEMENTAR" , "                                                  "},
                {"DCLPROPOSTAS_VA_COD_CCT" , ""},
                {"DCLPROPOSTAS_VA_FAIXA_RENDA_IND" , "2"},
                {"DCLPROPOSTAS_VA_FAIXA_RENDA_FAM" , "2"},
                {"DCLPROPOSTAS_VA_COD_ORIGEM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_PROPOSTAS_VA", q3);

            #endregion

            #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_SICOB" , "80000000017"},
                { "COD_PRODUTO_SIVPF" , "80"},
                { "COD_EMPRESA_SIVPF" , "3"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_SICOB" , "80000000017"},
                { "COD_PRODUTO_SIVPF" , "80"},
                { "COD_EMPRESA_SIVPF" , "3"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIT_PROPOSTA" , "EMT"},
                { "NUM_SICOB" , "80000000017"},
                { "COD_PRODUTO_SIVPF" , "80"},
                { "COD_EMPRESA_SIVPF" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "1"},
                { "NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "06478013960"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1990-05-30"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "1"},
                { "NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "06478013960"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1990-05-30"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "1"},
                { "NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "06478013960"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1990-05-30"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "1"},
                { "NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "06478013960"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1990-05-30"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "1"},
                { "NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "06478013960"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1990-05-30"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "1"},
                { "NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A              "},
                { "TIPO_PESSOA" , "F"},
                { "CGCCPF" , "06478013960"},
                { "SIT_REGISTRO" , "0"},
                { "DATA_NASCIMENTO" , "1990-05-30"},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0350_00_LER_ENDERECO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , "1"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_OCORR_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "PRAIA DE BOTAFOGO N 228/18                                              "},
                { "ENDERECO_BAIRRO" , "BOTAFOGO"},
                { "ENDERECO_CIDADE" , "RIO DE JANEIRO                                                          "},
                { "ENDERECO_SIGLA_UF" , "RJ"},
                { "ENDERECO_CEP" , "22250000"},
                { "ENDERECO_DDD" , "47"},
                { "ENDERECO_TELEFONE" , "3342181"},
                { "ENDERECO_FAX" , "325689985"},
                { "ENDERECO_TELEX" , "6356596"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_LER_ENDERECO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0410_00_LER_CBO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "125"},
                { "CBO_DESCR_CBO" , "ADMINISTRADOR                                     "},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "125"},
                { "CBO_DESCR_CBO" , "ADMINISTRADOR                                     "},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "125"},
                { "CBO_DESCR_CBO" , "ADMINISTRADOR                                     "},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "125"},
                { "CBO_DESCR_CBO" , "ADMINISTRADOR                                     "},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "125"},
                { "CBO_DESCR_CBO" , "ADMINISTRADOR                                     "},
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "125"},
                { "CBO_DESCR_CBO" , "ADMINISTRADOR                                     "},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_LER_CBO_DB_SELECT_1_Query1", q8);

            #endregion

            #region PF0619B_C01_CBO

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DCLCBO_CBO_COD_CBO" , ""},
                { "DCLCBO_CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_C01_CBO", q9);

            #endregion

            #region R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_PRODUTO" , "9707"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0500_00_LER_RCAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "220"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "220"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "220"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "20"},
                { "RCAPS_NUM_RCAP" , "-378631462"},
                { "RCAPS_NUM_PROPOSTA" , "0"},
                { "RCAPS_VAL_RCAP" , "1171.89"},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "1171.89"},
                { "RCAPS_DATA_CADASTRAMENTO" , "2018-12-17"},
                { "RCAPS_DATA_MOVIMENTO" , "2018-12-17"},
                { "RCAPS_SIT_REGISTRO" , "0"},
                { "RCAPS_COD_OPERACAO" , "220"},
                { "RCAPS_NUM_TITULO" , "8211314408"},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LER_RCAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region PF0619B_CUR_PARCELVA

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "DCLHIST_CONT_PARCELVA_PREMIO_VG" , "23,33"},
                { "DCLHIST_CONT_PARCELVA_PREMIO_AP" , "0"},
                { "DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO" , "2001-08-27"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "DCLHIST_CONT_PARCELVA_PREMIO_VG" , "23,33"},
                { "DCLHIST_CONT_PARCELVA_PREMIO_AP" , "0"},
                { "DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO" , "2001-08-27"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "DCLHIST_CONT_PARCELVA_PREMIO_VG" , "23,33"},
                { "DCLHIST_CONT_PARCELVA_PREMIO_AP" , "0"},
                { "DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO" , "2001-08-27"},
            });
            q12.AddDynamic(new Dictionary<string, string>{
                { "DCLHIST_CONT_PARCELVA_PREMIO_VG" , "23,33"},
                { "DCLHIST_CONT_PARCELVA_PREMIO_AP" , "0"},
                { "DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO" , "2001-08-27"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_CUR_PARCELVA", q12);

            #endregion

            #region R0521_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "VLPREMIO" , "75.50"}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "VLPREMIO" , "75.50"}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "VLPREMIO" , "75.50"}
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "VLPREMIO" , "75.50"}

            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "VLPREMIO" , "75.50"}
            });
            AppSettings.TestSet.DynamicData.Add("R0521_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "27"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1901-01-02"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "1"},
                { "OPPAGVA_DIA_DEBITO" , "20"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "206"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "3"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "817"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "0"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "27"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1901-01-02"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "1"},
                { "OPPAGVA_DIA_DEBITO" , "20"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "206"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "3"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "817"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "0"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "27"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1901-01-02"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "1"},
                { "OPPAGVA_DIA_DEBITO" , "20"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "206"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "3"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "817"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "0"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "27"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1901-01-02"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "1"},
                { "OPPAGVA_DIA_DEBITO" , "20"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "206"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "3"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "817"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "0"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "27"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1901-01-02"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "1"},
                { "OPPAGVA_DIA_DEBITO" , "20"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "206"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "3"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "817"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "0"},
            });
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CERTIFICADO" , "27"},
                { "OPPAGVA_DATA_INIVIGENCIA" , "1901-01-02"},
                { "OPPAGVA_DATA_TERVIGENCIA" , "9999-12-31"},
                { "OPPAGVA_OPCAO_PAGAMENTO" , "1"},
                { "OPPAGVA_DIA_DEBITO" , "20"},
                { "OPPAGVA_COD_AGENCIA_DEBITO" , "206"},
                { "OPPAGVA_OPE_CONTA_DEBITO" , "3"},
                { "OPPAGVA_NUM_CONTA_DEBITO" , "817"},
                { "OPPAGVA_DIG_CONTA_DEBITO" , "0"},
            });

            AppSettings.TestSet.DynamicData.Add("R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1", q14);

            #endregion

            #region PF0619B_FUNDOCOMISVA

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , "0"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , "6,82"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , "2,27"},
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , "0"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , "6,82"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , "2,27"},
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , "0"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , "6,82"},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , "2,27"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_FUNDOCOMISVA", q15);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "35"}
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "35"}
            });
            q16.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "35"}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0620_00_DADOS_RG_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , "1"},
                { "GEDOCCLI_COD_IDENTIFICACAO" , "23"},
                { "GEDOCCLI_NOM_ORGAO_EXP" , "23"},
                { "GEDOCCLI_DTH_EXPEDICAO" , "2020-01-01"},
                { "GEDOCCLI_COD_UF" , "SC"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , "1"},
                { "GEDOCCLI_COD_IDENTIFICACAO" , "23"},
                { "GEDOCCLI_NOM_ORGAO_EXP" , "23"},
                { "GEDOCCLI_DTH_EXPEDICAO" , "2020-01-01"},
                { "GEDOCCLI_COD_UF" , "SC"},
            });
            q17.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , "1"},
                { "GEDOCCLI_COD_IDENTIFICACAO" , "23"},
                { "GEDOCCLI_NOM_ORGAO_EXP" , "23"},
                { "GEDOCCLI_DTH_EXPEDICAO" , "2020-01-01"},
                { "GEDOCCLI_COD_UF" , "SC"},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_DADOS_RG_DB_SELECT_1_Query1", q17);

            #endregion

            #region PF0619B_BENEFICIARIOS

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "BENEFPRO_NUM_APOLICE" , "97010000889"},
                { "BENEFPRO_COD_SUBGRUPO" , "3603"},
                { "BENEFPRO_COD_FONTE" , "0"},
                { "BENEFPRO_NUM_PROPOSTA" , "-14939"},
                { "BENEFPRO_NUM_BENEFICIARIO" , "1"},
                { "BENEFPRO_NOME_BENEFICIARIO" , "RAFAEL DE OLIVEIRA BALTAZAR             "},
                { "BENEFPRO_GRAU_PARENTESCO" , "FILHO     "},
                { "BENEFPRO_PCT_PART_BENEFICIA" , "30.00"},
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "BENEFPRO_NUM_APOLICE" , "97010000889"},
                { "BENEFPRO_COD_SUBGRUPO" , "3603"},
                { "BENEFPRO_COD_FONTE" , "0"},
                { "BENEFPRO_NUM_PROPOSTA" , "-14939"},
                { "BENEFPRO_NUM_BENEFICIARIO" , "1"},
                { "BENEFPRO_NOME_BENEFICIARIO" , "RAFAEL DE OLIVEIRA BALTAZAR             "},
                { "BENEFPRO_GRAU_PARENTESCO" , "FILHO     "},
                { "BENEFPRO_PCT_PART_BENEFICIA" , "30.00"},
            });
            q18.AddDynamic(new Dictionary<string, string>{
                { "BENEFPRO_NUM_APOLICE" , "97010000889"},
                { "BENEFPRO_COD_SUBGRUPO" , "3603"},
                { "BENEFPRO_COD_FONTE" , "0"},
                { "BENEFPRO_NUM_PROPOSTA" , "-14939"},
                { "BENEFPRO_NUM_BENEFICIARIO" , "1"},
                { "BENEFPRO_NOME_BENEFICIARIO" , "RAFAEL DE OLIVEIRA BALTAZAR             "},
                { "BENEFPRO_GRAU_PARENTESCO" , "FILHO     "},
                { "BENEFPRO_PCT_PART_BENEFICIA" , "30.00"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_BENEFICIARIOS", q18);

            #endregion

            #region R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q22);

            #endregion

            #region R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1", q26);

            #endregion

            #region R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q27);

            #endregion

            #region PF0619B_EMAIL

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , ""},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_EMAIL", q28);

            #endregion

            #region R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q29);

            #endregion

            #region R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
                { "PESSOA_TIMESTAMP" , ""},
                { "PESSOA_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1", q31);

            #endregion

            #region R31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1", q32);

            #endregion

            #region R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q33);

            #endregion

            #region R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1", q34);

            #endregion

            #region PF0619B_ENDERECOS

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("PF0619B_ENDERECOS", q35);

            #endregion

            #region R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1", q36);

            #endregion

            #region R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1", q37);

            #endregion

            #region R3255_LER_TELEFONE_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            q38.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            q38.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            q38.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , "A"}
            });
            AppSettings.TestSet.DynamicData.Add("R3255_LER_TELEFONE_DB_SELECT_1_Query1", q38);

            #endregion

            #region R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}

            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            q39.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , "32"}
            });
            AppSettings.TestSet.DynamicData.Add("R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "SEQ_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
                { "PRDSIVPF_COD_RELAC" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1", q41);

            #endregion

            #region R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "1"},
                { "COD_RELAC" , "2"},
            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "1"},
                { "COD_RELAC" , "2"},
            });
            q42.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "1"},
                { "COD_RELAC" , "2"},
            });
            AppSettings.TestSet.DynamicData.Add("R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q42);

            #endregion

            #region R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1", q43);

            #endregion

            #region R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""},
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "6"}
            });
            q45.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "6"}
            });
            q45.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "6"}
            });
            q45.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "6"}
            });
            AppSettings.TestSet.DynamicData.Add("R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1", q45);

            #endregion

            #region R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
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
                { "IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1", q46);

            #endregion

            #region R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_IDENTIFICACAO" , ""},
                { "PROPSSVD_DPS_TITULAR" , ""},
                { "PROPSSVD_DPS_CONJUGE" , ""},
                { "PROPSSVD_APOS_INVALIDEZ" , ""},
                { "PROPSSVD_COD_USUARIO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q48);

            #endregion

            #region R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1", q49);

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
            q51.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_COD_CEDENTE" , ""},
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

            #region PF0619B_CRS_BILHETE

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "0"},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "888330"},
            });
            q53.AddDynamic(new Dictionary<string, string>{
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "0"},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "888330"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0619B_CRS_BILHETE", q53);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("Saida_PF0619B.txt")]
        public static void PF0619B_Tests_Theory(string MOVTO_PRP_SASSE_FILE_NAME_P)
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
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

                #endregion

                #region R3255_LER_TELEFONE_DB_SELECT_1_Query1

                var q38 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3255_LER_TELEFONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3255_LER_TELEFONE_DB_SELECT_1_Query1", q38);

                #endregion

                #region R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q42);

                #endregion

                #endregion



                var program = new PF0619B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.W01DIGCERT.WDIG != 0);

                //Assert.True(program.RETURN_CODE == 99);

                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length > 0);

                
                //R31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PESSOA_NOME_PESSOA", out var val4r) && val4r.Contains("JOAO FORTES"));

                //R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("DDI", out var val3r) && val3r.Contains("55"));
                Assert.True(envList[1].TryGetValue("DDD", out var val5r) && val5r.Contains("47"));

                //R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("COD_PESSOA", out var val2r) && val2r.Contains("0"));
                Assert.True(envList3[1].TryGetValue("COD_RELAC", out var val1r) && val1r.Contains("3"));

                //R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("NUM_IDENTIFICACAO", out var val6r) && val6r.Contains("7"));
                Assert.True(envList4[1].TryGetValue("COD_RELAC", out var val7r) && val7r.Contains("3"));

                //R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5.Count > 1);
                Assert.True(envList5[1].TryGetValue("NUM_IDENTIFICACAO", out var val8r) && val8r.Contains("7"));
                Assert.True(envList5[1].TryGetValue("OPRCTADEB", out var val9r) && val9r.Contains("3"));

                //R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6.Count > 1);
                Assert.True(envList6[1].TryGetValue("PROPSSVD_NUM_APOLICE", out var val11r) && val11r.Contains("109300000550"));
                Assert.True(envList6[1].TryGetValue("PROPSSVD_APOS_INVALIDEZ", out var val22r) && val22r.Contains("N"));

                //R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7.Count > 1);
                Assert.True(envList7[1].TryGetValue("PROPFIDH_DATA_SITUACAO", out var val12r) && val12r.Contains("2008-07-31"));
                Assert.True(envList7[1].TryGetValue("PROPFIDH_SIT_COBRANCA_SIVPF", out var val21r) && val21r.Contains("SUS"));


            }
        }

        [Theory]
        [InlineData("Saida_PF0619B.txt")]
        public static void PF0619B_Tests_TheoryFluxoErro99(string MOVTO_PRP_SASSE_FILE_NAME_P)
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
                //#region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

                //var q4 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1");
                //AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

                //#endregion

                #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion

                var program = new PF0619B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 99);

            }
        }
        [Theory]
        [InlineData("Saida_PF0619B.txt")]
        public static void PF0619B_Tests_TheoryFluxo00SemFide(string MOVTO_PRP_SASSE_FILE_NAME_P)
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
                //#region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

                //var q4 = new DynamicData();
                //AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1");
                //AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

                //#endregion

                #endregion

                var program = new PF0619B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                
                Assert.True(program.RETURN_CODE == 00);

                //R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("WHOST_SIT_PROPOSTA", out var val4r) && val4r.Contains("REJ"));
                Assert.True(envList2[1].TryGetValue("WHOST_SIT_ENVIO", out var val3r) && val3r.Contains("S"));

                //R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var valor) && valor.Contains("PRPSASSE"));
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val0r) && val0r.Contains("4"));

                //R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var val5r) && val5r.Contains("2020-01-01"));

            }
        }
        [Theory]
        [InlineData("Saida_PF0619B.txt")]
        public static void PF0619B_Tests_TheoryFluxoBilhete(string MOVTO_PRP_SASSE_FILE_NAME_P)
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
                #region PF0619B_PROPOSTAS_VA

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("PF0619B_PROPOSTAS_VA");
                AppSettings.TestSet.DynamicData.Add("PF0619B_PROPOSTAS_VA", q3);

                #endregion
                #endregion

                var program = new PF0619B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 00);

                //R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("WHOST_SIT_PROPOSTA", out var val4r) && val4r.Contains("REJ"));
                Assert.True(envList2[1].TryGetValue("WHOST_SIT_ENVIO", out var val3r) && val3r.Contains("S"));


            }
        }
    }
}