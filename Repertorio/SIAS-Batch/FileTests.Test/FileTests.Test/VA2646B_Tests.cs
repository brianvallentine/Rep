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
using static Code.VA2646B;
using System.IO;
using Dclgens;
using Sias.VidaAzul.DB2.VA2646B;

namespace FileTests.Test
{
    [Collection("VA2646B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2646B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-02-27"},
                { "W_ANO_MOV_ABERTO" , "2025"},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2025-02-27"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2025-02-27"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA2646B_TPROPOVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "108208225372"},
                { "PROPOVA_COD_SUBGRUPO" , "0"},
                { "PROPOVA_NUM_CERTIFICADO" , "10020465915"},
                { "PROPOVA_COD_CLIENTE" , "10020728"},
                { "PROPOVA_OCOREND" , "5"},
                { "PROPOVA_AGE_COBRANCA" , "239"},
                { "PROPOVA_DATA_QUITACAO" , "2025-02-27"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_COD_PRODUTO" , "8203"},
                { "PROPOVA_DTNASC_ESPOSA" , ""},
                { "PROPOVA_NRCERTIFANT" , ""},
                { "MOVVGAP_NUM_APOLICE" , ""},
                { "MOVVGAP_COD_SUBGRUPO" , ""},
                { "MOVVGAP_COD_FONTE" , ""},
                { "MOVVGAP_NUM_PROPOSTA" , ""},
                { "PRODUVG_ORIG_PRODU" , "ESPEC"},
                { "PROPOVA_DTINCLUS" , "2005-11-04"},
            });
            AppSettings.TestSet.DynamicData.Add("VA2646B_TPROPOVA", q2);

            #endregion

            #region VA2646B_BENEFICIARIOS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "BENEFICI_NUM_BENEFICIARIO" , "10000"},
                { "BENEFICI_NOME_BENEFICIARIO" , "ANTONIO DA SILVA SANTOS"},
                { "BENEFICI_GRAU_PARENTESCO" , "IRMAO"},
                { "BENEFICI_PCT_PART_BENEFICIA" , "50"},
            });
            AppSettings.TestSet.DynamicData.Add("VA2646B_BENEFICIARIOS", q3);

            #endregion

            #region R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "111"}
            });
            AppSettings.TestSet.DynamicData.Add("R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_COD_PRODUTO_AZUL" , "ESP"}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2024-12-04"},
                { "RELATORI_COD_RELATORIO" , "VGICA"},
                { "RELATORI_NUM_CERTIFICADO" , "10020465915"},
                { "RELATORI_NUM_PARCELA" , "301"},
                { "RELATORI_COD_PLANO" , "6"},
                { "RELATORI_TIMESTAMP" , "2024-12-04 10:44:17.035"},
            });
            AppSettings.TestSet.DynamicData.Add("R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1016_SELECT_PARCELA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_PREMIO_VG" , "0"},
                { "PARCEVID_PREMIO_AP" , "4096.49"},
                { "PARCEVID_SIT_REGISTRO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1016_SELECT_PARCELA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , "2005-11-01"},
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2025-10-31"},
                { "ENDOSSOS_AGE_RCAP" , "239"},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_PROPOSTA" , "EMT"},
                { "PROPFIDH_DATA_SITUACAO" , "2024-12-23"},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2025-02-27"},
                { "RELATORI_NUM_CERTIFICADO" , "10020465915"},
                { "RELATORI_COD_RELATORIO" , "001"},
                { "RELATORI_NUM_PARCELA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "585554463125544"},
                { "CLIENTES_NOME_RAZAO" , "ASSOC DE PESSOAL DA CEF DE SAO PAULO"},
                { "CLIENTES_TIPO_PESSOA" , "J"},
                { "CLIENTES_DATA_NASCIMENTO" , "1969-05-09"},
                { "CLIENTES_IDE_SEXO" , "F"},
                { "CLIENTES_ESTADO_CIVIL" , "S"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , "RUA VINTE E QUATRO DE MAIO N 208"},
                { "ENDERECO_BAIRRO" , "REPUBLICA"},
                { "ENDERECO_CIDADE" , "SAO PAULO"},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "ENDERECO_CEP" , "1041000"},
                { "ENDERECO_DDD" , "16"},
                { "ENDERECO_TELEFONE" , "32023424"},
                { "ENDERECO_FAX" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "3"},
                { "OPCPAGVI_PERI_PAGAMENTO" , "1"},
                { "OPCPAGVI_DIA_DEBITO" , "28"},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "0000000000000000"},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , "ANALISE@APCEFSP.ORG.BR"}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , "4096.49"}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , "239"},
                { "AGENCCEF_SITUACAO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PLANOAGE_MATRIC_INDICADOR" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_SEQ_PRD_PROPOSTA" , "10000"}
            });
            AppSettings.TestSet.DynamicData.Add("R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_SEQ_PRD_PROPOSTA" , "10000"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "48"},
                { "PROPOVA_COD_PRODUTO" , "8203"},
            });
            AppSettings.TestSet.DynamicData.Add("R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "2000"}
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1", q21);

            #endregion

            #region R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "2000"}
            });
            AppSettings.TestSet.DynamicData.Add("R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "2000"}
            });
            AppSettings.TestSet.DynamicData.Add("R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "1000"},
                { "CLIENTES_NOME_RAZAO" , "JOSE ISABEL PACHECO"},
                { "PESSOA_COD_USUARIO" , "2001"},
                { "CLIENTES_TIPO_PESSOA" , "J"},
            });
            AppSettings.TestSet.DynamicData.Add("R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "1000"},
                { "PESSOFIS_CPF" , "08650200001"},
                { "CLIENTES_DATA_NASCIMENTO" , "1966-08-20"},
                { "PESSOFIS_SEXO" , "F"},
                { "PESSOFIS_COD_USUARIO" , "1000"},
                { "CLIENTES_ESTADO_CIVIL" , "S"},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_ORGAO_EXPEDIDOR" , ""},
                { "PESSOFIS_UF_EXPEDIDORA" , ""},
                { "PESSOFIS_DATA_EXPEDICAO" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                { "PESSOFIS_TIPO_IDENT_SIVPF" , ""},
            });
            q25.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "2000"},
                { "PESSOFIS_CPF" , "08650200001"},
                { "CLIENTES_DATA_NASCIMENTO" , "1966-08-20"},
                { "PESSOFIS_SEXO" , "F"},
                { "PESSOFIS_COD_USUARIO" , "1000"},
                { "CLIENTES_ESTADO_CIVIL" , "S"},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_ORGAO_EXPEDIDOR" , ""},
                { "PESSOFIS_UF_EXPEDIDORA" , ""},
                { "PESSOFIS_DATA_EXPEDICAO" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                { "PESSOFIS_TIPO_IDENT_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1", q25);

            #endregion

            #region R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "1000"},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , "AMANDA SILVA SOUZA"},
                { "PESSOJUR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "28880270"},
                { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                { "PROPOFID_CANAL_PROPOSTA" , "2"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "6"},
                { "PROPOFID_SITUACAO_ENVIO" , "R"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "48"},
                { "PROPOFID_DATA_PROPOSTA" , "2005-11-01"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "10020465915"},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q27);

            #endregion

            #region R1910_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SITUACAO_ENVIO" , "R"},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , "1000"},
                { "PROPOVA_NUM_CERTIFICADO" , "10020465915"},
            });
            AppSettings.TestSet.DynamicData.Add("R1910_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1", q28);

            #endregion

            #region R1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_COD_USUARIO" , "1000"},
                { "PROPOVA_NUM_CERTIFICADO" , "10020465915"},
            });
            AppSettings.TestSet.DynamicData.Add("R1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1", q29);

            #endregion

            #region R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1", q30);

            #endregion

            #region R1913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , "10020465915"},
            });
            AppSettings.TestSet.DynamicData.Add("R1913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R1915_00_SELECT_MAX_RELAC_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1915_00_SELECT_MAX_RELAC_DB_SELECT_1_Query1", q32);

            #endregion

            #region R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "IDENTREL_COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1", q33);

            #endregion

            #region R1915_00_SELECT_MAX_RELAC_DB_INSERT_2_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PESSOA_COD_PESSOA" , ""},
                { "IDENTREL_COD_RELAC" , ""},
                { "IDENTREL_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1915_00_SELECT_MAX_RELAC_DB_INSERT_2_Insert1", q34);

            #endregion

            #region R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PESSOA_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "48"},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_OPCAOPAG" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_PERC_DESCONTO" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONVENENTE" , ""},
                { "PROPOFID_NRMATRCON" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_VAL_TARIFA" , ""},
                { "PROPOFID_VAL_IOF" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_VAL_COMISSAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , "A"},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , "R"},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
                { "PROPOFID_IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R1921_00_INSERT_PROPOFID_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PESSOA_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "48"},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_OPCAOPAG" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_PERC_DESCONTO" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONVENENTE" , ""},
                { "PROPOFID_NRMATRCON" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_VAL_TARIFA" , ""},
                { "PROPOFID_VAL_IOF" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_VAL_COMISSAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , "R"},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1921_00_INSERT_PROPOFID_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2025-02-27"}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q37);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA2646B_OUTPUT_20250227154500", "VA2646B_OUTPUT_20250227154501")]
        public static void VA2646B_Tests_Theory_Selects_ReturnCode_00(string AVA2646B_FILE_NAME_P, string RVA2646B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2646B_FILE_NAME_P = $"{AVA2646B_FILE_NAME_P}_{timestamp}.txt";
            RVA2646B_FILE_NAME_P = $"{RVA2646B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                ResetDBData();
                #endregion
                var program = new VA2646B();

                program.WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Value = 10020465915;
                program.WORK_AREA_0.TEM_CONVERSAO.Value = " ";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS.Value = "2027-02-28";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.Value = 8203;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.Value = "3";
                program.WORK_AREA_0.WS_ERRO_RENOV.Value = "N";

                program.Execute(AVA2646B_FILE_NAME_P, RVA2646B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA2646B.FilePath));

                // SELECTS
                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1016_SELECT_PARCELA_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1"].DynamicList);
                Assert.Empty(AppSettings.TestSet.DynamicData["R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VA2646B_OUTPUT_20250305140100", "VA2646B_OUTPUT_20250305140101")]
        public static void VA2646B_Tests_Theory_Inserts_ReturnCode_00(string AVA2646B_FILE_NAME_P, string RVA2646B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2646B_FILE_NAME_P = $"{AVA2646B_FILE_NAME_P}_{timestamp}.txt";
            RVA2646B_FILE_NAME_P = $"{RVA2646B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                ResetDBData();

                #endregion
                var program = new VA2646B();

                program.WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Value = 0;
                program.WORK_AREA_0.TEM_CONVERSAO.Value = " ";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS.Value = "2027-02-28";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.Value = 9310;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.Value = "3";
                program.WORK_AREA_0.WS_ERRO_RENOV.Value = "N";

                program.Execute(AVA2646B_FILE_NAME_P, RVA2646B_FILE_NAME_P);

                Assert.True(File.Exists(program.AVA2646B.FilePath));

                // INSERTS
                var insertSelect = AppSettings.TestSet.DynamicData["R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1"].DynamicList.ToList();
                Assert.Empty(insertSelect);

                var insert = AppSettings.TestSet.DynamicData["R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert[^1].TryGetValue("PESSOA_COD_PESSOA", out var value) && value.Contains("000002001"));

                var insert1 = AppSettings.TestSet.DynamicData["R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert1[^1].TryGetValue("CLIENTES_CGCCPF", out var value1) && value1.Contains("585554463125544"));

                var insert2 = AppSettings.TestSet.DynamicData["R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert2[^1].TryGetValue("CLIENTES_NOME_RAZAO", out var value3) && value3.Contains("ASSOC DE PESSOAL DA CEF DE SAO PAULO"));

                var insert3 = AppSettings.TestSet.DynamicData["R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert3[^1].TryGetValue("PESSOA_COD_PESSOA", out var value4) && value4.Contains("2000"));

                var insert4 = AppSettings.TestSet.DynamicData["R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert3[^1].TryGetValue("PESSOFIS_CPF", out var value5) && value5.Contains("08650200001"));

                var insert5 = AppSettings.TestSet.DynamicData["R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1"].DynamicList.ToList();
                Assert.True(insert3[^1].TryGetValue("CLIENTES_DATA_NASCIMENTO", out var value6) && value6.Contains("1966-08-20"));

                // UPDATES
                var update = AppSettings.TestSet.DynamicData["R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update);
                Assert.True(update[^1].ContainsKey("UpdateCheck"));

                var update3 = AppSettings.TestSet.DynamicData["R1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1"].DynamicList.ToList();
                Assert.NotEmpty(update3);
                Assert.True(update3[^1].ContainsKey("UpdateCheck"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VA2646B_OUTPUT_20250305165900", "VA2646B_OUTPUT_20250305165901")]
        public static void VA2646B_Tests_Theory_ReturnCode_99(string AVA2646B_FILE_NAME_P, string RVA2646B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2646B_FILE_NAME_P = $"{AVA2646B_FILE_NAME_P}_{timestamp}.txt";
            RVA2646B_FILE_NAME_P = $"{RVA2646B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                ResetDBData();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-02-27"},
                    { "W_ANO_MOV_ABERTO" , "2025"},
                    { "SISTEMAS_DATA_MOV_ABERTO_30" , "2025-02-27"},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                var program = new VA2646B();

                program.WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Value = 0;
                program.WORK_AREA_0.TEM_CONVERSAO.Value = " ";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS.Value = "2027-02-28";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.Value = 9310;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.Value = "3";
                program.WORK_AREA_0.WS_ERRO_RENOV.Value = "N";

                program.Execute(AVA2646B_FILE_NAME_P, RVA2646B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        public static void ResetDBData()
        {
            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-02-27"},
                    { "W_ANO_MOV_ABERTO" , "2025"},
                    { "SISTEMAS_DATA_MOV_ABERTO_30" , "2025-02-27"},
                });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_DATA_SOLICITACAO" , "2025-02-27"}
                });
            AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q1);

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_APOLICE" , "108208225372"},
                    { "PROPOVA_COD_SUBGRUPO" , "0"},
                    { "PROPOVA_NUM_CERTIFICADO" , "10020465915"},
                    { "PROPOVA_COD_CLIENTE" , "10020728"},
                    { "PROPOVA_OCOREND" , "5"},
                    { "PROPOVA_AGE_COBRANCA" , "239"},
                    { "PROPOVA_DATA_QUITACAO" , "2005-11-01"},
                    { "PROPOVA_SIT_REGISTRO" , "3"},
                    { "PROPOVA_COD_PRODUTO" , "9310"},
                    { "PROPOVA_DTNASC_ESPOSA" , ""},
                    { "PROPOVA_NRCERTIFANT" , ""},
                    { "MOVVGAP_NUM_APOLICE" , ""},
                    { "MOVVGAP_COD_SUBGRUPO" , ""},
                    { "MOVVGAP_COD_FONTE" , ""},
                    { "MOVVGAP_NUM_PROPOSTA" , ""},
                    { "PRODUVG_ORIG_PRODU" , "ESPEC"},
                    { "PROPOVA_DTINCLUS" , "2005-11-04"},
                });
            AppSettings.TestSet.DynamicData.Remove("VA2646B_TPROPOVA");
            AppSettings.TestSet.DynamicData.Add("VA2646B_TPROPOVA", q2);

            var q3 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("VA2646B_BENEFICIARIOS");
            AppSettings.TestSet.DynamicData.Add("VA2646B_BENEFICIARIOS", q3);

            var q4 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1", q4);

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                    { "PRODUVG_COD_PRODUTO_AZUL" , "ESP"}
                });
            AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q5);

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_DATA_SOLICITACAO" , "2024-12-04"},
                    { "RELATORI_COD_RELATORIO" , "VGICA"},
                    { "RELATORI_NUM_CERTIFICADO" , "10020465915"},
                    { "RELATORI_NUM_PARCELA" , "301"},
                    { "RELATORI_COD_PLANO" , "6"},
                    { "RELATORI_TIMESTAMP" , "2024-12-04 10:44:17.035"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1", q6);

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                    { "PARCEVID_PREMIO_VG" , "0"},
                    { "PARCEVID_PREMIO_AP" , "4096.49"},
                    { "PARCEVID_SIT_REGISTRO" , "1"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1016_SELECT_PARCELA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1016_SELECT_PARCELA_DB_SELECT_1_Query1", q7);

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                    { "ENDOSSOS_DATA_INIVIGENCIA" , "2005-11-01"},
                    { "ENDOSSOS_DATA_TERVIGENCIA" , "2025-10-31"},
                    { "ENDOSSOS_AGE_RCAP" , "239"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q8);

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                    { "PROPFIDH_SIT_PROPOSTA" , "EMT"},
                    { "PROPFIDH_DATA_SITUACAO" , "2024-12-23"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1", q9);

            var q10 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1");
            AppSettings.TestSet.DynamicData.Add("R1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1", q10);

            var q11 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1");
            q11.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_CGCCPF" , "585554463125544"},
                    { "CLIENTES_NOME_RAZAO" , "ASSOC DE PESSOAL DA CEF DE SAO PAULO"},
                    { "CLIENTES_TIPO_PESSOA" , "J"},
                    { "CLIENTES_DATA_NASCIMENTO" , "1969-05-09"},
                    { "CLIENTES_IDE_SEXO" , "F"},
                    { "CLIENTES_ESTADO_CIVIL" , "S"},
                });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q11);

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                    { "ENDERECO_ENDERECO" , "RUA VINTE E QUATRO DE MAIO N 208"},
                    { "ENDERECO_BAIRRO" , "REPUBLICA"},
                    { "ENDERECO_CIDADE" , "SAO PAULO"},
                    { "ENDERECO_SIGLA_UF" , "SP"},
                    { "ENDERECO_CEP" , "1041000"},
                    { "ENDERECO_DDD" , "16"},
                    { "ENDERECO_TELEFONE" , "32023424"},
                    { "ENDERECO_FAX" , "0"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q12);

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                    { "OPCPAGVI_OPCAO_PAGAMENTO" , "3"},
                    { "OPCPAGVI_PERI_PAGAMENTO" , "1"},
                    { "OPCPAGVI_DIA_DEBITO" , "28"},
                    { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                    { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                    { "OPCPAGVI_NUM_CARTAO_CREDITO" , "0000000000000000"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q13);

            var q14 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1", q14);

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                    { "HISCOBPR_VLPREMIO" , "4096.49"}
                });
            AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q15);

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                    { "AGENCCEF_COD_AGENCIA" , "239"},
                    { "AGENCCEF_SITUACAO" , "0"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q16);

            var q17 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q17);

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                    { "PLANOAGE_MATRIC_INDICADOR" , "0"}
                });
            AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1", q18);

            var q19 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1", q19);

            var q22 = new DynamicData();
            AppSettings.TestSet.DynamicData.Remove("R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1", q22);

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                    { "PROPOFID_NUM_IDENTIFICACAO" , "28880270"},
                    { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                    { "PROPOFID_CANAL_PROPOSTA" , "2"},
                    { "PROPOFID_ORIGEM_PROPOSTA" , "6"},
                    { "PROPOFID_SITUACAO_ENVIO" , "D"},
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "48"},
                    { "PROPOFID_DATA_PROPOSTA" , "2005-11-01"},
                    { "PROPOFID_NUM_PROPOSTA_SIVPF" , "10020465915"},
                });
            AppSettings.TestSet.DynamicData.Remove("R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q27);

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                    { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""}
                });
            AppSettings.TestSet.DynamicData.Remove("R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1", q30);
        }
    }
}