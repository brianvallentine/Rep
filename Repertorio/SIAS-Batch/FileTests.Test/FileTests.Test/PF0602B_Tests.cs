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
using static Code.PF0602B;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FileTests.Test
{
    [Collection("PF0602B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0602B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_INICIALIZA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_2_Query1", q1);

            #endregion

            #region PF0602B_CPROPOSTA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROP_SASSE_BILHETE_PROPSSBI_RENOVACAO_AUTOM" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_PESSOA" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , ""},
                { "DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGECOBR" , ""},
                { "DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPCAOPAG" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGECTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPRCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUMCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_DIGCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , ""},
                { "DCLPROPOSTA_FIDELIZ_NRMATRVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGECTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , ""},
                { "DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , ""},
                { "DCLPROPOSTA_FIDELIZ_NRMATRCON" , ""},
                { "DCLPROPOSTA_FIDELIZ_DTQITBCO" , ""},
                { "WHOST_DTPROXVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_PAGO" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGEPGTO" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_IOF" , ""},
                { "DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , ""},
                { "DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_USUARIO" , ""},
                { "DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_TIMESTAMP" , ""},
                { "DCLPROPOSTA_FIDELIZ_NSL" , ""},
                { "DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_NOME_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_DATA_NASC_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROFISSAO_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPCAO_COBER" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_PLANO" , ""},
                { "DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_IND" , ""},
                { "DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_CPROPOSTA", q2);

            #endregion

            #region PF0602B_CPESENDER

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_CPESENDER", q3);

            #endregion

            #region R1100_00_LER_BILHETE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LER_BILHETE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "DATA_CREDITO" , ""},
                { "DTQITBCO" , ""},
                { "VAL_PAGO" , ""},
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2_Update1", q6);

            #endregion

            #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ESTIPULA_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ESTIPULA_NOME_ESTIPULANTE" , ""},
                { "ESTIPULA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "NSAC_SIVPF" , ""},
                { "NSL" , ""},
                { "COD_EMPRESA_SIVPF" , ""},
                { "COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "COD_CBO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "UF_EXPEDIDORA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q14);

            #endregion

            #region PF0602B_CPESENDERR

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_CPESENDERR", q15);

            #endregion

            #region PF0602B_CFONE

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_TELEFONE_TIPO_FONE" , ""},
                { "DCLPESSOA_TELEFONE_DDD" , ""},
                { "DCLPESSOA_TELEFONE_NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_CFONE", q16);

            #endregion

            #region PF0602B_CCLIENTES

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "DCLCLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_CCLIENTES", q17);

            #endregion

            #region R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_INFORMACAO_COMPL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1", q18);

            #endregion

            #region R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2_Query1", q20);

            #endregion

            #region PF0602B_C01_AGENCEF

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , ""},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_C01_AGENCEF", q21);

            #endregion

            #region R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_OPCAO_PLANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_OPCAO_PLANO" , ""},
                { "BILHECOB_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1", q25);

            #endregion

            #region R2352_00_OBTER_COBERTURA_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_OPCAO_PLANO" , ""},
                { "BILHECOB_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2352_00_OBTER_COBERTURA_DB_SELECT_1_Query1", q26);

            #endregion

            #region R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_OPCAO_PLANO" , ""},
                { "BILHECOB_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1", q27);

            #endregion

            #region R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_OPCAO_PLANO" , ""},
                { "BILHECOB_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_OPCAO_PLANO" , ""},
                { "BILHECOB_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1_Query1", q29);

            #endregion

            #region R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q30);

            #endregion

            #region R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO" , ""},
                { "SIGLA_UF" , ""},
                { "BAIRRO" , ""},
                { "CIDADE" , ""},
                { "CEP" , ""},
                { "WHOST_TELEFONE" , ""},
                { "WHOST_DDD" , ""},
                { "WHOST_FAX" , ""},
                { "COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "ENDERECO" , ""},
                { "BAIRRO" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "CEP" , ""},
                { "WHOST_DDD" , ""},
                { "WHOST_TELEFONE" , ""},
                { "WHOST_FAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PROPESTI_COD_FONTE" , ""},
                { "PROPESTI_NUM_PROPOSTA" , ""},
                { "PROPESTI_COD_PRODUTO" , ""},
                { "PROPESTI_COD_CCT" , ""},
                { "PROPESTI_COD_FROTA" , ""},
                { "PROPESTI_NUM_APOLICE" , ""},
                { "PROPESTI_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1", q33);

            #endregion

            #region R2600_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_TRATA_EMAIL_DB_SELECT_1_Query1", q34);

            #endregion

            #region R2600_00_TRATA_EMAIL_DB_SELECT_2_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_TRATA_EMAIL_DB_SELECT_2_Query1", q35);

            #endregion

            #region R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
                { "CLIENEMA_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""},
                { "CLIENEMA_COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R3000_10_CONTINUA_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "WHOST_FONTE" , ""},
                { "AGECOBR" , ""},
                { "NRMATRVEN" , ""},
                { "AGECTAVEN" , ""},
                { "OPRCTAVEN" , ""},
                { "NUMCTAVEN" , ""},
                { "DIGCTAVEN" , ""},
                { "COD_CLIENTE" , ""},
                { "WHOST_PROFISSAO" , ""},
                { "SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "BILHECOB_COD_OPCAO_PLANO" , ""},
                { "DTQITBCO" , ""},
                { "VAL_PAGO" , ""},
                { "WHOST_RAMO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_SIT_REGISTRO" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
                { "BILHECOB_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_10_CONTINUA_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "OPPAGVA_NUM_CARTAO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "VG084_COD_OPERADOR" , ""},
                { "VG084_NUM_CORRESP_CX_AQUI" , ""},
                { "VG084_IND_TP_CORRESP_SICAQ" , ""},
                { "VG084_DTA_CONTRATACAO" , ""},
                { "VG084_HRA_CONTRATACAO" , ""},
                { "VG084_NUM_PROPOSTA_SICAQ" , ""},
                { "VG084_IND_ORIGEM_PROPOSTA" , ""},
                { "VG084_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_INFORMACAO_COMPL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1", q41);

            #endregion

            #region R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1_Query1", q42);

            #endregion

            #region R4500_00_INS_CLIENTE_JUR_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_INS_CLIENTE_JUR_DB_INSERT_1_Insert1", q43);

            #endregion

            #region R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4510_00_INS_ENDERECO_JUR_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R4530_00_INS_EMAIL_JUR_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
                { "CLIENEMA_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4530_00_INS_EMAIL_JUR_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "VG092_COD_CLIENTE" , ""},
                { "VG092_DTA_FAT_ANUAL" , ""},
                { "VG092_VLR_FAT_ANUAL" , ""},
                { "VG092_DTA_CONSTITUICAO" , ""},
                { "VG092_COD_CNAE_ATIVIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1_Insert1", q46);

            #endregion

            #region R4700_00_INS_RELACIONAMENTO_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "GE085_NUM_CERTIFICADO" , ""},
                { "GE085_IND_TP_PROPOSTA" , ""},
                { "GE085_COD_CLIENTE_PJ" , ""},
                { "GE085_COD_ENDERECO_PJ" , ""},
                { "GE085_COD_CLIENTE_PF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4700_00_INS_RELACIONAMENTO_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "PF062_DES_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1", q48);

            #endregion

            #region PF0602B_CCBO

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "DCLCBO_CBO_COD_CBO" , ""},
                { "DCLCBO_CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_CCBO", q49);

            #endregion

            #region PF0602B_C01_GECLIMOV

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_TIPO_MOVIMENTO" , ""},
                { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "GECLIMOV_TIPO_PESSOA" , ""},
                { "GECLIMOV_IDE_SEXO" , ""},
                { "GECLIMOV_ESTADO_CIVIL" , ""},
                { "GECLIMOV_OCORR_ENDERECO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "GECLIMOV_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "GECLIMOV_FAX" , ""},
                { "GECLIMOV_OCORR_HIST" , ""},
                { "GECLIMOV_CGCCPF" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0602B_C01_GECLIMOV", q50);

            #endregion

            #region R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1", q51);

            #endregion

            #region R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "VIND_DTMOVTO" , ""},
                { "NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1", q52);

            #endregion

            #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q53);

            #endregion

            #region R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_COD_CLIENTE" , ""},
                { "GECLIMOV_TIPO_MOVIMENTO" , ""},
                { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "GECLIMOV_TIPO_PESSOA" , ""},
                { "GECLIMOV_IDE_SEXO" , ""},
                { "GECLIMOV_ESTADO_CIVIL" , ""},
                { "GECLIMOV_OCORR_ENDERECO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "GECLIMOV_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "GECLIMOV_FAX" , ""},
                { "GECLIMOV_OCORR_HIST" , ""},
                { "GECLIMOV_CGCCPF" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
                { "GECLIMOV_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1", q54);

            #endregion

            #region R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_ENDERECO" , ""},
                { "VIND_OCORR_END" , ""},
                { "GECLIMOV_TIPO_PESSOA" , ""},
                { "VIND_TIPO_PESSOA" , ""},
                { "GECLIMOV_ESTADO_CIVIL" , ""},
                { "VIND_EST_CIVIL" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
                { "VIND_DTNASC" , ""},
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "VIND_NOME_RAZAO" , ""},
                { "GECLIMOV_IDE_SEXO" , ""},
                { "VIND_IDE_SEXO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "VIND_ENDERECO" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "VIND_SIGLA_UF" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "VIND_TELEFONE" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "VIND_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "VIND_CIDADE" , ""},
                { "GECLIMOV_CGCCPF" , ""},
                { "VIND_CGCCPF" , ""},
                { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
                { "GECLIMOV_TIPO_MOVIMENTO" , ""},
                { "GECLIMOV_CEP" , ""},
                { "VIND_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "VIND_DDD" , ""},
                { "GECLIMOV_FAX" , ""},
                { "VIND_FAX" , ""},
                { "GECLIMOV_COD_USUARIO" , ""},
                { "GECLIMOV_COD_CLIENTE" , ""},
                { "GECLIMOV_OCORR_HIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1", q55);

            #endregion


            #endregion
        }

        [Fact]
        public static void PF0602B_Tests_FactErro99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                var program = new PF0602B();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

                #endregion
                SPBVG001_Tests.Load_Parameters();
                AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
                //SPBVG009_Tests.Load_Parameters();
                GEJVS002_Tests.Load_Parameters();




                #endregion

                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);






                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void PF0602B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                var program = new PF0602B();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                SPBVG001_Tests.Load_Parameters();
                AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
                //SPBVG009_Tests.Load_Parameters();
                GEJVS002_Tests.Load_Parameters();

                #region R1100_00_LER_BILHETE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LER_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LER_BILHETE_DB_SELECT_1_Query1", q4);

                #endregion

                #region PF0602B_CPROPOSTA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROP_SASSE_BILHETE_PROPSSBI_RENOVACAO_AUTOM" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_PESSOA" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "123456"},
                { "DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "29"},
                { "DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF" , "10"},
                { "DCLPROPOSTA_FIDELIZ_AGECOBR" , "1"},
                { "DCLPROPOSTA_FIDELIZ_DIA_DEBITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPCAOPAG" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGECTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPRCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUMCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_DIGCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PERC_DESCONTO" , ""},
                { "DCLPROPOSTA_FIDELIZ_NRMATRVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGECTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPRCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_NUMCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_DIGCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE" , ""},
                { "DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE" , ""},
                { "DCLPROPOSTA_FIDELIZ_NRMATRCON" , ""},
                { "DCLPROPOSTA_FIDELIZ_DTQITBCO" , ""},
                { "WHOST_DTPROXVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_PAGO" , ""},
                { "DCLPROPOSTA_FIDELIZ_AGEPGTO" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_TARIFA" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_IOF" , ""},
                { "DCLPROPOSTA_FIDELIZ_DATA_CREDITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_VAL_COMISSAO" , ""},
                { "DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_USUARIO" , ""},
                { "DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "5"},
                { "DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "02"},
                { "DCLPROPOSTA_FIDELIZ_TIMESTAMP" , ""},
                { "DCLPROPOSTA_FIDELIZ_NSL" , ""},
                { "DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_NOME_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_DATA_NASC_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROFISSAO_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_OPCAO_COBER" , ""},
                { "DCLPROPOSTA_FIDELIZ_COD_PLANO" , "3721"},
                { "DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_IND" , ""},
                { "DCLPROPOSTA_FIDELIZ_FAIXA_RENDA_FAM" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("PF0602B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("PF0602B_CPROPOSTA", q2);

                #endregion

                #region R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "BILHECOB_COD_OPCAO_PLANO" , "11"}
                });
                q24.AddDynamic(new Dictionary<string, string>{
                    { "BILHECOB_COD_OPCAO_PLANO" , "11"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1", q24);

                #endregion
                #region PF0602B_CCLIENTES

                var q17 = new DynamicData();


                AppSettings.TestSet.DynamicData.Remove("PF0602B_CCLIENTES");
                AppSettings.TestSet.DynamicData.Add("PF0602B_CCLIENTES", q17);

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "CPF" , ""},
                    { "DATA_NASCIMENTO" , ""},
                    { "SEXO" , ""},
                    { "COD_CBO" , ""},
                    { "ESTADO_CIVIL" , ""},
                    { "ORGAO_EXPEDIDOR" , ""},
                    { "NUM_IDENTIDADE" , ""},
                    { "DATA_EXPEDICAO" , "2020-01-01"},
                    { "UF_EXPEDIDORA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q14);

                #endregion

                #region R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "BILHECOB_COD_OPCAO_PLANO" , "11"},
                    { "BILHECOB_COD_PRODUTO" , "10"},
                });
                q25.AddDynamic(new Dictionary<string, string>{
                    { "BILHECOB_COD_OPCAO_PLANO" , "11"},
                    { "BILHECOB_COD_PRODUTO" , "10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2351_00_OBTER_COBERTURA_DB_SELECT_1_Query1", q25);

                #endregion

                #region R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q9);

                #endregion

                #region P0130_05_INICIO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "123456"},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG102_DES_MSG_CRITICA" , ""},
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG099_DES_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
                { "VG102_IND_ALCADA" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("P0130_05_INICIO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("P0130_05_INICIO_DB_SELECT_1_Query1", q6);

                #endregion


                #endregion

                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);



                var envList = AppSettings.TestSet.DynamicData["R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("WHOST_SIT_PROPOSTA", out var valOr) && valOr == "PAI");
                Assert.True(envList[1].TryGetValue("NUM_PROPOSTA_SIVPF", out var valSivpf) && valSivpf == "000000000000000");


                var envList1 = AppSettings.TestSet.DynamicData["R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("COD_CLIENTE", out var val2r) && val2r == "000000001");
                Assert.True(envList1[1].TryGetValue("CPF", out var val3pf) && val3pf == "00000000000");

                var envList2 = AppSettings.TestSet.DynamicData["R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_COD_CLIENTE", out var val3r) && val3r == "000000001");
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_DTH_EXPEDICAO", out var val4pf) && val4pf == "2020-01-01");

                var envList3 = AppSettings.TestSet.DynamicData["R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("COD_CLIENTE", out var val5r) && val5r == "000000001");
                Assert.True(envList3[1].TryGetValue("CEP", out var val6pf) && val6pf == "000000000");


                var envList4 = AppSettings.TestSet.DynamicData["R3000_10_CONTINUA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("NUM_SICOB", out var val7r) && val7r == "000000000123456");
                Assert.True(envList4[1].TryGetValue("WHOST_FONTE", out var val8pf) && val8pf == "0005");

                var envList5 = AppSettings.TestSet.DynamicData["R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("VIND_DTMOVTO", out var val8r) && val8r == "0000");
                Assert.True(envList5[1].TryGetValue("NUM_IDENTIFICACAO", out var val9f) && val9f == "000000000000000");

                var envList6 = AppSettings.TestSet.DynamicData["R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("GECLIMOV_OCORR_ENDERECO", out var val10r) && val10r == "0000");
                Assert.True(envList6[1].TryGetValue("GECLIMOV_TIPO_PESSOA", out var val11f) && val11f == "F");


                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}