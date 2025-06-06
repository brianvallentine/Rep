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
using static Code.VA0601B;

namespace FileTests.Test
{
    [Collection("VA0601B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0601B_Tests
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

            #region VA0601B_CPROPOSTA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , ""},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , ""},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , ""},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , ""},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , ""},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , ""},
                { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                { "PROPSSVD_COD_CORRESP_BANC" , ""},
                { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                { "PROPSSVD_COD_OPER_CREDITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , ""},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
                { "WHOST_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CPROPOSTA", q2);

            #endregion

            #region VA0601B_C01_RCAPCOMP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_C01_RCAPCOMP", q3);

            #endregion

            #region R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NOME_SEGURADO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0911_00_SELECT_RCAPS_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NOME_SEGURADO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0911_00_SELECT_RCAPS_DB_SELECT_2_Query1", q5);

            #endregion

            #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AZUL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_CONSISTE_RCAP_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ESTIPULA_NOME_ESTIPULANTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , ""},
                { "IMPMORACID" , ""},
                { "IMPINVPERM" , ""},
                { "IMPAMDS" , ""},
                { "IMPDH" , ""},
                { "IMPDIT" , ""},
                { "VLPREMIOTOT" , ""},
                { "PRMVG" , ""},
                { "PRMAP" , ""},
                { "QTTITCAP" , ""},
                { "VLTITCAP" , ""},
                { "VLCUSTCAP" , ""},
                { "IMPSEGCDG" , ""},
                { "VLCUSTCDG" , ""},
                { "IMPSEGAUXF" , ""},
                { "VLCUSTAUXF" , ""},
                { "PRMDIT" , ""},
                { "QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q10);

            #endregion

            #region R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , ""},
                { "IMPMORACID" , ""},
                { "IMPINVPERM" , ""},
                { "IMPAMDS" , ""},
                { "IMPDH" , ""},
                { "IMPDIT" , ""},
                { "VLPREMIOTOT" , ""},
                { "PRMVG" , ""},
                { "PRMAP" , ""},
                { "QTTITCAP" , ""},
                { "VLTITCAP" , ""},
                { "VLCUSTCAP" , ""},
                { "IMPSEGCDG" , ""},
                { "VLCUSTCDG" , ""},
                { "IMPSEGAUXF" , ""},
                { "VLCUSTAUXF" , ""},
                { "PRMDIT" , ""},
                { "QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q13);

            #endregion

            #region R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "GE406_IND_RET_SUBSCRICAO" , ""},
                { "GE406_PCT_AGRAVO" , ""},
                { "GE406_VLR_PRM_SEM_AGR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q17);

            #endregion

            #region VA0601B_CPESENDER

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CPESENDER", q18);

            #endregion

            #region R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NRMATRVEN" , ""},
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WS_TEM_CARENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1", q22);

            #endregion

            #region R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q23);

            #endregion

            #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1", q25);

            #endregion

            #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q26);

            #endregion

            #region R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "OCOREND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q27);

            #endregion

            #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , ""},
                { "ENDERECO" , ""},
                { "BAIRRO" , ""},
                { "CIDADE" , ""},
                { "CEP" , ""},
                { "SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1", q28);

            #endregion

            #region VA0601B_CPESENDERR

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CPESENDERR", q29);

            #endregion

            #region VA0601B_CFONE

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_TELEFONE_TIPO_FONE" , ""},
                { "DCLPESSOA_TELEFONE_DDD" , ""},
                { "DCLPESSOA_TELEFONE_NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CFONE", q30);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_RESIDENCIAL" , ""},
                { "WHOST_FONE_RESIDENCIAL" , ""},
                { "WHOST_SEQ_RESIDENCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_COMERCIAL" , ""},
                { "WHOST_FONE_COMERCIAL" , ""},
                { "WHOST_SEQ_COMERCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1", q32);

            #endregion

            #region VA0601B_CRISCO

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CRISCO", q33);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_CELULAR" , ""},
                { "WHOST_FONE_CELULAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1", q34);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_FAX" , ""},
                { "WHOST_FONE_FAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1", q35);

            #endregion

            #region R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1", q36);

            #endregion

            #region R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1", q37);

            #endregion

            #region R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1", q38);

            #endregion

            #region R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_INFORMACAO_COMPL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1", q39);

            #endregion

            #region VA0601B_CRISCO1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CRISCO1", q40);

            #endregion

            #region R2241_10_FETCH_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "IMP_MORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2241_10_FETCH_DB_SELECT_1_Query1", q41);

            #endregion

            #region VA0601B_CRISCO2

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CRISCO2", q42);

            #endregion

            #region R2242_10_FETCH_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "APOLCOB_IMPSEGURADO" , ""},
                { "APOLCOB_DT_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2242_10_FETCH_DB_SELECT_1_Query1", q43);

            #endregion

            #region R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "IMPSEGUR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1", q44);

            #endregion

            #region VA0601B_CRISCO3

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CRISCO3", q45);

            #endregion

            #region R2243_10_FETCH_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "IMP_MORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2243_10_FETCH_DB_SELECT_1_Query1", q46);

            #endregion

            #region VA0601B_CCLIENTES

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "DCLCLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CCLIENTES", q47);

            #endregion

            #region R2244_10_FETCH_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "APOLCOB_IMPSEGURADO" , ""},
                { "APOLCOB_DT_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2244_10_FETCH_DB_SELECT_1_Query1", q48);

            #endregion

            #region SEGUROS_SPBGE051_Call1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "LK_GE051_TRACE" , ""},
                { "LK_GE051_NUM_CPF_CNPJ" , ""},
                { "LK_GE051_S_QTD_CNTR_PREST" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_PREST" , ""},
                { "LK_GE051_S_DTH_CAD_PREST" , ""},
                { "LK_GE051_S_QTD_CONTR_VIDA" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_VIDA" , ""},
                { "LK_GE051_S_DTH_CAD_VIDA" , ""},
                { "LK_GE051_S_QTD_CNTR_PREV" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_PREV" , ""},
                { "LK_GE051_S_DTH_CAD_PREV" , ""},
                { "LK_GE051_S_QTD_CONTR_HABIT" , ""},
                { "LK_GE051_S_VLR_IS_ACUM_HABIT" , ""},
                { "LK_GE051_S_DTH_CAD_HABIT" , ""},
                { "LK_GE051_S_QTD_TOTAL_CNTR" , ""},
                { "LK_GE051_S_VLR_TOTAL_CNTR" , ""},
                { "LK_GE051_S_DTH_CADASTRAMENTO" , ""},
                { "LK_GE051_IND_ERRO" , ""},
                { "LK_GE051_MSG_ERRO" , ""},
                { "LK_GE051_NOM_TABELA" , ""},
                { "LK_GE051_SQLCODE" , ""},
                { "LK_GE051_SQLERRMC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SEGUROS_SPBGE051_Call1", q49);

            #endregion

            #region VA0601B_VGPLARAMC

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "VGPLAR_NUM_RAMO" , ""},
                { "VGPLAR_NUM_COBERTURA" , ""},
                { "VGPLAR_QTD_COBERTURA" , ""},
                { "VGPLAR_IMPSEGURADA" , ""},
                { "VGPLAR_CUSTO" , ""},
                { "VGPLAR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_VGPLARAMC", q50);

            #endregion

            #region R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CONT_ESPACO" , ""},
                { "WHOST_NOME_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1", q51);

            #endregion

            #region R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1", q52);

            #endregion

            #region R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1", q53);

            #endregion

            #region R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1", q54);

            #endregion

            #region R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_UF" , ""},
                { "VIND_UF_EXPEDIDORA" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1", q55);

            #endregion

            #region R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1", q56);

            #endregion

            #region R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q57);

            #endregion

            #region R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1", q58);

            #endregion

            #region R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO" , ""},
                { "BAIRRO" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "CEP" , ""},
                { "WHOST_DDD" , ""},
                { "WHOST_FONE" , ""},
                { "WHOST_FAX" , ""},
                { "WHOST_TELEX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1", q59);

            #endregion

            #region R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "WS_SIGLA_UF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1", q60);

            #endregion

            #region R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q61);

            #endregion

            #region R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , ""},
                { "COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1", q62);

            #endregion

            #region R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1", q63);

            #endregion

            #region R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
                { "WHOST_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1", q64);

            #endregion

            #region R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "ESTADO_CIVIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1_Query1", q65);

            #endregion

            #region R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1_Update1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "ESTADO_CIVIL" , ""},
                { "COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1_Update1", q66);

            #endregion

            #region R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "COD_CLIENTE" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "WHOST_FONTE" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "WHOST_PROFISSAO" , ""},
                { "WHOST_SIT_REGISTRO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "WHOST_DTPROXVEN" , ""},
                { "WHOST_IDADE" , ""},
                { "SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "PROPSSVD_APOS_INVALIDEZ" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "WHOST_PROFISSAO_CONJUGE" , ""},
                { "PROPSSVD_DPS_TITULAR" , ""},
                { "PROPSSVD_DPS_CONJUGE" , ""},
                { "WHOST_INFO_COMPL" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
                { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                { "PROPSSVD_COD_CORRESP_BANC" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                { "PROPSSVD_COD_OPER_CREDITO" , ""},
                { "WHOST_STA_ANTECIPACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1", q67);

            #endregion

            #region R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "VG084_COD_OPERADOR" , ""},
                { "VG084_NUM_CORRESP_CX_AQUI" , ""},
                { "VG084_IND_TP_CORRESP_SICAQ" , ""},
                { "VG084_DTA_CONTRATACAO" , ""},
                { "VG084_HRA_CONTRATACAO" , ""},
                { "VG084_NUM_PROPOSTA_SICAQ" , ""},
                { "VG084_IND_ORIGEM_PROPOSTA" , ""},
                { "VG084_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1", q68);

            #endregion

            #region R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "VG078_NUM_CERTIFICADO" , ""},
                { "VG078_DES_ANDAMENTO" , ""},
                { "VG078_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1", q69);

            #endregion

            #region R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "IMPMORNATU" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "IMPMORACID" , ""},
                { "IMPINVPERM" , ""},
                { "IMPAMDS" , ""},
                { "IMPDH" , ""},
                { "IMPDIT" , ""},
                { "VLPREMIOTOT" , ""},
                { "PRMVG" , ""},
                { "PRMAP" , ""},
                { "QTTITCAP" , ""},
                { "VLTITCAP" , ""},
                { "VLCUSTCAP" , ""},
                { "IMPSEGCDG" , ""},
                { "VLCUSTCDG" , ""},
                { "IMPSEGAUXF" , ""},
                { "VLCUSTAUXF" , ""},
                { "PRMDIT" , ""},
                { "QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q70);

            #endregion

            #region R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NUM_CERTIFICADO" , ""},
                { "WHOST_OCORR_HISTORICO" , ""},
                { "WHOST_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_TERVIGENCIA" , ""},
                { "WHOST_IMPSEGUR" , ""},
                { "WHOST_QUANT_VIDAS" , ""},
                { "WHOST_IMPSEGIND" , ""},
                { "WHOST_COD_OPERACAO" , ""},
                { "WHOST_OPCAO_COBERTURA" , ""},
                { "WHOST_IMP_MORNATU" , ""},
                { "WHOST_IMPMORACID" , ""},
                { "WHOST_IMPINVPERM" , ""},
                { "WHOST_IMPAMDS" , ""},
                { "WHOST_IMPDH" , ""},
                { "WHOST_IMPDIT" , ""},
                { "WHOST_VLPREMIO" , ""},
                { "WHOST_PRMVG" , ""},
                { "WHOST_PRMAP" , ""},
                { "WHOST_QTDE_TIT_CAPITALIZ" , ""},
                { "WHOST_VAL_TIT_CAPITALIZ" , ""},
                { "WHOST_VAL_CUSTO_CAPITALI" , ""},
                { "WHOST_IMPSEGCDG" , ""},
                { "WHOST_VLCUSTCDG" , ""},
                { "WHOST_COD_USUARIO" , ""},
                { "WHOST_TIMESTAMP" , ""},
                { "WHOST_IMPSEGAUXF" , ""},
                { "WHOST_VLCUSTAUXF" , ""},
                { "WHOST_PRMDIT" , ""},
                { "WHOST_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1_Query1", q71);

            #endregion

            #region VA0601B_VGPLAACES

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "VGPLAA_NUM_ACESSORIO" , ""},
                { "VGPLAA_QTD_COBERTURA" , ""},
                { "VGPLAA_IMPSEGURADA" , ""},
                { "VGPLAA_CUSTO" , ""},
                { "VGPLAA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_VGPLAACES", q72);

            #endregion

            #region R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "VGPLAR_NUM_RAMO" , ""},
                { "VGPLAR_NUM_COBERTURA" , ""},
                { "VGPLAR_QTD_COBERTURA" , ""},
                { "VGPLAR_IMPSEGURADA" , ""},
                { "VGPLAR_CUSTO" , ""},
                { "VGPLAR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1", q73);

            #endregion

            #region VA0601B_CEMPRESA

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CEMPRESA", q74);

            #endregion

            #region R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "VGPLAA_NUM_ACESSORIO" , ""},
                { "VGPLAA_QTD_COBERTURA" , ""},
                { "VGPLAA_IMPSEGURADA" , ""},
                { "VGPLAA_CUSTO" , ""},
                { "VGPLAA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1", q75);

            #endregion

            #region R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "WHOST_OPCAOPAG" , ""},
                { "PRODUVG_PERI_PAGAMENTO" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q76);

            #endregion

            #region R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1

            var q77 = new DynamicData();
            q77.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "WHOST_FONTE" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "VAL_ADIANTAMENTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SIT_REGISTRO" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "SIT_FENAE" , ""},
                { "VAL_COMISSAO_VEN" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "ORDEM_PAGAMENTO" , ""},
                { "NUM_ENDOSSO" , ""},
                { "NUM_MATR_GERENTE" , ""},
                { "COD_AGEN_GERENTE" , ""},
                { "OPE_CONTA_GERENTE" , ""},
                { "NUM_CONTA_GERENTE" , ""},
                { "DIG_CONTA_GERENTE" , ""},
                { "VAL_COMIS_GERENTE" , ""},
                { "NUM_MATR_SUN" , ""},
                { "COD_AGEN_SUN" , ""},
                { "OPE_CONTA_SUN" , ""},
                { "NUM_CONTA_SUN" , ""},
                { "DIG_CONTA_SUN" , ""},
                { "VAL_COMIS_SUN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1", q77);

            #endregion

            #region R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1

            var q78 = new DynamicData();
            q78.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "PREMIO_AP" , ""},
                { "VLMULTA" , ""},
                { "WHOST_OPCAOPAG" , ""},
                { "SIT_REGISTRO" , ""},
                { "OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1", q78);

            #endregion

            #region R3410_00_INSERT_PARCELVA_DB_INSERT_1_Insert1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PREMIO_AP" , ""},
                { "VLMULTA" , ""},
                { "WHOST_OPCAOPAG" , ""},
                { "SIT_REGISTRO" , ""},
                { "OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3410_00_INSERT_PARCELVA_DB_INSERT_1_Insert1", q79);

            #endregion

            #region R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "NUM_TITULO" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "WHOST_OPCAOPAG" , ""},
                { "SIT_REGISTRO" , ""},
                { "COD_OPERACAO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "COD_DEVOLUCAO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "NUM_TITULO_COMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q80);

            #endregion

            #region R3510_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "NUM_TITULO" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "WHOST_OPCAOPAG" , ""},
                { "SIT_REGISTRO" , ""},
                { "COD_OPERACAO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "COD_DEVOLUCAO" , ""},
                { "BCO_AVISO" , ""},
                { "AGE_AVISO" , ""},
                { "NUM_AVISO_CREDITO" , ""},
                { "NUM_TITULO_COMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3510_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q81);

            #endregion

            #region R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "HISLANCT_OCORR_HISTORICOCTA" , ""},
                { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
                { "HISLANCT_OPE_CONTA_DEBITO" , ""},
                { "HISLANCT_NUM_CONTA_DEBITO" , ""},
                { "HISLANCT_DIG_CONTA_DEBITO" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_TIPLANC" , ""},
                { "HISLANCT_OCORR_HISTORICO" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "HISLANCT_COD_USUARIO" , ""},
                { "HISLANCT_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1", q82);

            #endregion

            #region R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "CONVEVG_COD_SEGURO" , ""},
                { "CONVEVG_COD_CONV_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1", q83);

            #endregion

            #region R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL_56" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1", q84);

            #endregion

            #region R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "NUM_TITULO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "WHOST_FONTE" , ""},
                { "NUM_ENDOSSO" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "PREMIO_AP" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SIT_REGISTRO" , ""},
                { "COD_OPERACAO" , ""},
                { "DTFATUR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q85);

            #endregion

            #region R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1

            var q86 = new DynamicData();
            q86.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRPARCEL_56" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1", q86);

            #endregion

            #region R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

            var q87 = new DynamicData();
            q87.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "NUM_TITULO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "WHOST_FONTE" , ""},
                { "NUM_ENDOSSO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PREMIO_AP" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SIT_REGISTRO" , ""},
                { "COD_OPERACAO" , ""},
                { "DTFATUR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q87);

            #endregion

            #region R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1

            var q88 = new DynamicData();
            q88.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1", q88);

            #endregion

            #region R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1

            var q89 = new DynamicData();
            q89.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1", q89);

            #endregion

            #region R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q90 = new DynamicData();
            q90.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "WHOST_BCO_RELAT" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "WHOST_SIN_RELAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q90);

            #endregion

            #region VA0601B_C01_AGENCEF

            var q91 = new DynamicData();
            q91.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , ""},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_C01_AGENCEF", q91);

            #endregion

            #region R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1

            var q92 = new DynamicData();
            q92.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4310_00_INSERT_CLIENTES_DB_SELECT_1_Query1", q92);

            #endregion

            #region R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1

            var q93 = new DynamicData();
            q93.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , ""},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "COD_EMPRESA" , ""},
                { "COD_GRD_GRUPO_CBO" , ""},
                { "COD_SUBGRUPO_CBO" , ""},
                { "COD_GRUPO_BASE_CBO" , ""},
                { "COD_SUBGR_BASE_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1", q93);

            #endregion

            #region R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

            var q94 = new DynamicData();
            q94.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q94);

            #endregion

            #region R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1

            var q95 = new DynamicData();
            q95.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1", q95);

            #endregion

            #region R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1

            var q96 = new DynamicData();
            q96.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLIENTE" , ""},
                { "WHOST_OCORR_ENDERECO" , ""},
                { "WHOST_ENDERECO" , ""},
                { "WHOST_BAIRRO" , ""},
                { "WHOST_CIDADE" , ""},
                { "WHOST_SIGLA_UF" , ""},
                { "WHOST_CEP" , ""},
                { "WHOST_DDD" , ""},
                { "WHOST_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1", q96);

            #endregion

            #region R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q97 = new DynamicData();
            q97.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q97);

            #endregion

            #region R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1

            var q98 = new DynamicData();
            q98.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , ""},
                { "WHOST_COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1", q98);

            #endregion

            #region R4520_00_INSERT_EMAIL_DB_SELECT_1_Query1

            var q99 = new DynamicData();
            q99.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4520_00_INSERT_EMAIL_DB_SELECT_1_Query1", q99);

            #endregion

            #region R4520_00_INSERT_EMAIL_DB_INSERT_1_Insert1

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
                { "WHOST_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4520_00_INSERT_EMAIL_DB_INSERT_1_Insert1", q100);

            #endregion

            #region R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1

            var q101 = new DynamicData();
            q101.AddDynamic(new Dictionary<string, string>{
                { "GE085_NUM_CERTIFICADO" , ""},
                { "GE085_IND_TP_PROPOSTA" , ""},
                { "GE085_COD_CLIENTE_PJ" , ""},
                { "GE085_COD_ENDERECO_PJ" , ""},
                { "GE085_COD_CLIENTE_PF" , ""},
                { "GE085_COD_USUARIO" , ""},
                { "GE085_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1_Insert1", q101);

            #endregion

            #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

            var q102 = new DynamicData();
            q102.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q102);

            #endregion

            #region R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q103 = new DynamicData();
            q103.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q103);

            #endregion

            #region R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1

            var q104 = new DynamicData();
            q104.AddDynamic(new Dictionary<string, string>{
                { "PF062_DES_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1", q104);

            #endregion

            #region R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

            var q105 = new DynamicData();
            q105.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "VIND_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "VIND_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "VIND_NOME_CONJUGE" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "VIND_DATA_DECLINIO" , ""},
                { "WHOST_PROFISSAO_CONJUGE" , ""},
                { "VIND_PROFISSAO_CONJUGE" , ""},
                { "PROPSSVD_COD_OPER_CREDITO" , ""},
                { "VIND_COD_OPER_CRED" , ""},
                { "PROPSSVD_COD_CORRESP_BANC" , ""},
                { "VIND_COD_CORRESP" , ""},
                { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                { "VIND_NUM_CONTR" , ""},
                { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                { "VIND_NUM_PRAZO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "COD_CLIENTE" , ""},
                { "WHOST_SIT_REGISTRO" , ""},
                { "WHOST_INFO_COMPL" , ""},
                { "WHOST_PROFISSAO" , ""},
                { "WHOST_DTPROXVEN" , ""},
                { "WHOST_FONTE" , ""},
                { "WHOST_IDADE" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q105);

            #endregion

            #region R5650_00_INSERE_RELATORIOS_DB_INSERT_1_Insert1

            var q106 = new DynamicData();
            q106.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5650_00_INSERE_RELATORIOS_DB_INSERT_1_Insert1", q106);

            #endregion

            #region VA0601B_CCBO

            var q107 = new DynamicData();
            q107.AddDynamic(new Dictionary<string, string>{
                { "DCLCBO_CBO_COD_CBO" , ""},
                { "DCLCBO_CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CCBO", q107);

            #endregion

            #region VA0601B_CVGRAMOCOMP

            var q108 = new DynamicData();
            q108.AddDynamic(new Dictionary<string, string>{
                { "VG081_NUM_APOLICE" , ""},
                { "VG081_COD_SUBGRUPO" , ""},
                { "VG081_COD_GRUPO_SUSEP" , ""},
                { "VG081_RAMO_EMISSOR" , ""},
                { "VG081_COD_MODALIDADE" , ""},
                { "VG081_DTH_INI_VIGENCIA" , ""},
                { "VG081_COD_OPCAO_COBERTURA" , ""},
                { "VG081_NUM_IDADE_INICIAL" , ""},
                { "VG081_NUM_IDADE_FINAL" , ""},
                { "VG081_VLR_PERC_PREMIO" , ""},
                { "VG081_COD_USUARIO" , ""},
                { "VG081_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CVGRAMOCOMP", q108);

            #endregion

            #region VA0601B_CSR_ERRO_DPS

            var q109 = new DynamicData();
            q109.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0601B_CSR_ERRO_DPS", q109);

            #endregion

            #region R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1

            var q110 = new DynamicData();
            q110.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "NUM_TITULO" , ""},
                { "OCORR_HISTORICO" , ""},
                { "WHOST_GRUPO_SUSEP" , ""},
                { "WHOST_COD_RAMO" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "WHOST_PREMIO_CONJ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1", q110);

            #endregion

            #region VA0601B_C01_GECLIMOV

            var q111 = new DynamicData();
            q111.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VA0601B_C01_GECLIMOV", q111);

            #endregion

            #region R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1

            var q112 = new DynamicData();
            q112.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1", q112);

            #endregion

            #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

            var q113 = new DynamicData();
            q113.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q113);

            #endregion

            #region R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1

            var q114 = new DynamicData();
            q114.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1", q114);

            #endregion

            #region R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1

            var q115 = new DynamicData();
            q115.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1", q115);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0601B_Tests_Fact_0()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region VA0601B_CPROPOSTA
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR", "nnnn");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO", "11");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG", "3");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO", "30");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO", "9314");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO", "9314");


                var q2 = AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"];
                AppSettings.TestSet.DynamicData.Remove("VA0601B_CPROPOSTA");

                q2.AddDynamic(new Dictionary<string, string>{
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "nnnn"},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , ""},
                    { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                    { "PROPSSVD_COD_CORRESP_BANC" , ""},
                    { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                    { "PROPSSVD_COD_OPER_CREDITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , "11"},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "0"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "2"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , "30"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "77"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , "77"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , "1"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "3"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , "1"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA" , ""},
                    { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , "9314"},
                    { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , "9314"},
                    { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
                    { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
                    { "WHOST_RAMO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0601B_CPROPOSTA", q2);
                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WS_NUM_PROPOSTA_AZUL");
                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WS_NUM_PROPOSTA_AZUL", "30");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_IMPMORNATU_MAX");
                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_IMPMORNATU_MAX", "2");

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_TITULO");
                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_TITULO", "32");

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("PESSOA_NOME_PESSOA");
                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("PESSOA_NOME_PESSOA", "gUS");

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CPF");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CPF", "06478122");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_NASCIMENTO", "1970-01-01");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SEXO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SEXO", "M");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("COD_CBO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("COD_CBO", "1");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ESTADO_CIVIL", "S");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ORGAO_EXPEDIDOR");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ORGAO_EXPEDIDOR", "SSP");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_IDENTIDADE");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_IDENTIDADE", "5465456");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_EXPEDICAO", "20/05/2016");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("UF_EXPEDIDORA", "SC");

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("BAIRRO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("BAIRRO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CIDADE");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CIDADE", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CEP");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CEP", "84");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIGLA_UF");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIGLA_UF", "SC");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_RESIDENCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_RESIDENCIAL", "1212");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_RESIDENCIAL", "1212");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_COMERCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_COMERCIAL", "13");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_COMERCIAL", "18");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_CELULAR", "47");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_CELULAR", "177");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_FAX", "45");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_FAX", "45");

                #endregion

                #region VA0601B_CFONE

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_TIPO_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_TIPO_FONE", "C");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_NUM_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_NUM_FONE", "95959");

                #endregion

                #region VA0601B_CRISCO

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO1

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("IMPSEGUR");
                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("IMPSEGUR", "1");

                #endregion

                #region VA0601B_CRISCO2

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO3

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Remove("BILHETE_NUM_APOLICE");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Add("BILHETE_NUM_APOLICE", "1");

                #endregion

                #region R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_CLIENTE");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_CLIENTE", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_IDENTIFICACAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_IDENTIFICACAO", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_NOM_ORGAO_EXP");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_NOM_ORGAO_EXP", "ssp");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_DTH_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_DTH_EXPEDICAO", "30/05/90");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_UF");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_UF", "sc");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("VIND_UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("VIND_UF_EXPEDIDORA", "sc");

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIT_REGISTRO");
                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIT_REGISTRO", "1");

                #endregion

                #region VA0601B_CCBO

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_COD_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_COD_CBO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_DESCR_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_DESCR_CBO", "10");

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                #endregion

                #region VA0601B_C01_GECLIMOV

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_MOVIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_MOVIMENTO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_ULT_MANUTEN");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_ULT_MANUTEN", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_NOME_RAZAO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_NOME_RAZAO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_PESSOA", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_IDE_SEXO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_IDE_SEXO", "m");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ESTADO_CIVIL", "s");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_BAIRRO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_BAIRRO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CIDADE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CIDADE", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_SIGLA_UF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_SIGLA_UF", "sc");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CEP");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CEP", "22");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TELEFONE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TELEFONE", "23");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_FAX");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_FAX", "12");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CGCCPF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CGCCPF", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_NASCIMENTO", "1980-01-01");

                #endregion



                #endregion
                var program = new VA0601B();
                program.Execute();
                var envList = AppSettings.TestSet.DynamicData["R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                var envList0 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList0?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                var envList1 = AppSettings.TestSet.DynamicData["R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList1?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro

                var envList2 = AppSettings.TestSet.DynamicData["R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_COD_IDENTIFICACAO", out var valOr) && valOr == "5465456        ");


                //Assert.True(program.SPVG001W.LK_VG001_COD_USUARIO == "BATCH");
                //Assert.True(program.SPVG001W.LK_VG001_IND_TP_PROPOSTA == "PF");
            }
        }

        [Fact]
        public static void VA0601B_Tests_Fact_1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region VA0601B_CPROPOSTA
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR", "ssss");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO", "11");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG", "3");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO", "30");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO", "9314");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO", "9314");


                var q2 = AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"];
                AppSettings.TestSet.DynamicData.Remove("VA0601B_CPROPOSTA");

                q2.AddDynamic(new Dictionary<string, string>{
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "nnnn"},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , ""},
                    { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                    { "PROPSSVD_COD_CORRESP_BANC" , ""},
                    { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                    { "PROPSSVD_COD_OPER_CREDITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , "11"},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "0"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "2"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , "30"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "77"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , "77"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , "1"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "3"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , "1"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA" , ""},
                    { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , "9314"},
                    { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , "9314"},
                    { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
                    { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
                    { "WHOST_RAMO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0601B_CPROPOSTA", q2);
                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WS_NUM_PROPOSTA_AZUL");
                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WS_NUM_PROPOSTA_AZUL", "30");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_IMPMORNATU_MAX");
                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_IMPMORNATU_MAX", "2");

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_TITULO");
                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_TITULO", "32");

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("PESSOA_NOME_PESSOA");
                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("PESSOA_NOME_PESSOA", "gUS");

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CPF");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CPF", "06478122");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_NASCIMENTO", "1970-01-01");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SEXO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SEXO", "M");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("COD_CBO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("COD_CBO", "1");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ESTADO_CIVIL", "S");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ORGAO_EXPEDIDOR");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ORGAO_EXPEDIDOR", "SSP");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_IDENTIDADE");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_IDENTIDADE", "5465456");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_EXPEDICAO", "20/05/2016");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("UF_EXPEDIDORA", "SC");

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("BAIRRO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("BAIRRO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CIDADE");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CIDADE", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CEP");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CEP", "84");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIGLA_UF");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIGLA_UF", "SC");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_RESIDENCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_RESIDENCIAL", "1212");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_RESIDENCIAL", "1212");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_COMERCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_COMERCIAL", "13");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_COMERCIAL", "18");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_CELULAR", "47");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_CELULAR", "177");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_FAX", "45");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_FAX", "45");

                #endregion

                #region VA0601B_CFONE

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_TIPO_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_TIPO_FONE", "C");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_NUM_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_NUM_FONE", "95959");

                #endregion

                #region VA0601B_CRISCO

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO1

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("IMPSEGUR");
                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("IMPSEGUR", "1");

                #endregion

                #region VA0601B_CRISCO2

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO3

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Remove("BILHETE_NUM_APOLICE");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Add("BILHETE_NUM_APOLICE", "1");

                #endregion

                #region R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_CLIENTE");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_CLIENTE", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_IDENTIFICACAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_IDENTIFICACAO", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_NOM_ORGAO_EXP");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_NOM_ORGAO_EXP", "ssp");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_DTH_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_DTH_EXPEDICAO", "30/05/90");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_UF");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_UF", "sc");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("VIND_UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("VIND_UF_EXPEDIDORA", "sc");

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIT_REGISTRO");
                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIT_REGISTRO", "1");

                #endregion

                #region VA0601B_CCBO

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_COD_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_COD_CBO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_DESCR_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_DESCR_CBO", "10");

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                #endregion

                #region VA0601B_C01_GECLIMOV

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_MOVIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_MOVIMENTO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_ULT_MANUTEN");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_ULT_MANUTEN", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_NOME_RAZAO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_NOME_RAZAO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_PESSOA", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_IDE_SEXO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_IDE_SEXO", "m");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ESTADO_CIVIL", "s");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_BAIRRO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_BAIRRO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CIDADE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CIDADE", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_SIGLA_UF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_SIGLA_UF", "sc");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CEP");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CEP", "22");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TELEFONE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TELEFONE", "23");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_FAX");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_FAX", "12");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CGCCPF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CGCCPF", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_NASCIMENTO", "1980-01-01");

                #endregion



                #endregion
                var program = new VA0601B();
                program.Execute();

                //var envList = AppSettings.TestSet.DynamicData["R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //var envList0 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList0?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //var envList1 = AppSettings.TestSet.DynamicData["R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList1?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro

                var envList2 = AppSettings.TestSet.DynamicData["R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_COD_IDENTIFICACAO", out var valOr) && valOr == "5465456        ");


                //Assert.True(program.SPVG001W.LK_VG001_COD_USUARIO == "BATCH");
                //Assert.True(program.SPVG001W.LK_VG001_IND_TP_PROPOSTA == "PF");
                Assert.True(program.AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO != "");
            }
        }

        [Fact]
        public static void VA0601B_Tests_Fact_2()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region VA0601B_CPROPOSTA
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR", "nnnn");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO", "11");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG", "3");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE", "1");

                //AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO");
                //AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO", "30");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO", "9314");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO", "9314");


                var q2 = AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"];
                AppSettings.TestSet.DynamicData.Remove("VA0601B_CPROPOSTA");

                q2.AddDynamic(new Dictionary<string, string>{
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "nnnn"},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , ""},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , ""},
                    { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                    { "PROPSSVD_COD_CORRESP_BANC" , ""},
                    { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                    { "PROPSSVD_COD_OPER_CREDITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , "11"},
                    { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "0"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "2"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , "30"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "77"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , "77"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , "1"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "3"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , "1"},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , ""},
                    { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TIPO_CONTA" , ""},
                    { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , "9314"},
                    { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , "9314"},
                    { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
                    { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
                    { "WHOST_RAMO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0601B_CPROPOSTA", q2);
                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WS_NUM_PROPOSTA_AZUL");
                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WS_NUM_PROPOSTA_AZUL", "30");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_IMPMORNATU_MAX");
                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_IMPMORNATU_MAX", "2");

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_TITULO");
                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_TITULO", "32");

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("PESSOA_NOME_PESSOA");
                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("PESSOA_NOME_PESSOA", "gUS");

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CPF");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CPF", "06478122");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_NASCIMENTO", "1970-01-01");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SEXO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SEXO", "M");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("COD_CBO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("COD_CBO", "1");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ESTADO_CIVIL", "S");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ORGAO_EXPEDIDOR");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ORGAO_EXPEDIDOR", "SSP");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_IDENTIDADE");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_IDENTIDADE", "5465456");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_EXPEDICAO", "20/05/2016");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("UF_EXPEDIDORA", "SC");

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("BAIRRO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("BAIRRO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CIDADE");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CIDADE", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CEP");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CEP", "84");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIGLA_UF");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIGLA_UF", "SC");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_RESIDENCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_RESIDENCIAL", "1212");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_RESIDENCIAL", "1212");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_COMERCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_COMERCIAL", "13");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_COMERCIAL", "18");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_CELULAR", "47");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_CELULAR", "177");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_FAX", "45");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_FAX", "45");

                #endregion

                #region VA0601B_CFONE

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_TIPO_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_TIPO_FONE", "C");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_NUM_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_NUM_FONE", "95959");

                #endregion

                #region VA0601B_CRISCO

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO1

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("IMPSEGUR");
                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("IMPSEGUR", "1");

                #endregion

                #region VA0601B_CRISCO2

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO3

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Remove("BILHETE_NUM_APOLICE");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Add("BILHETE_NUM_APOLICE", "1");

                #endregion

                #region R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_CLIENTE");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_CLIENTE", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_IDENTIFICACAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_IDENTIFICACAO", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_NOM_ORGAO_EXP");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_NOM_ORGAO_EXP", "ssp");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_DTH_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_DTH_EXPEDICAO", "30/05/90");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_UF");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_UF", "sc");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("VIND_UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("VIND_UF_EXPEDIDORA", "sc");

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIT_REGISTRO");
                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIT_REGISTRO", "1");

                #endregion

                #region VA0601B_CCBO

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_COD_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_COD_CBO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_DESCR_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_DESCR_CBO", "10");

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                #endregion

                #region VA0601B_C01_GECLIMOV

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_MOVIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_MOVIMENTO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_ULT_MANUTEN");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_ULT_MANUTEN", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_NOME_RAZAO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_NOME_RAZAO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_PESSOA", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_IDE_SEXO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_IDE_SEXO", "m");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ESTADO_CIVIL", "s");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_BAIRRO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_BAIRRO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CIDADE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CIDADE", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_SIGLA_UF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_SIGLA_UF", "sc");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CEP");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CEP", "22");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TELEFONE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TELEFONE", "23");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_FAX");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_FAX", "12");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CGCCPF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CGCCPF", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_NASCIMENTO", "1980-01-01");

                #endregion



                #endregion
                var program = new VA0601B();
                program.Execute();

                //var envList = AppSettings.TestSet.DynamicData["R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //var envList0 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList0?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //var envList1 = AppSettings.TestSet.DynamicData["R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList1?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro

                var envList2 = AppSettings.TestSet.DynamicData["R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_COD_IDENTIFICACAO", out var valOr) && valOr == "5465456        ");


            }
        }

        [Fact]
        public static void VA0601B_Tests_Fact_3()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SISTEMAS_DATA_MOV_ABERTO");
                AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SISTEMAS_DATA_MOV_ABERTO", "2024-08-21");

                #endregion

                #region VA0601B_CPROPOSTA
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE", "109300001666");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR", "nnnn");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO", "11");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF", "3");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF", "7");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG", "3");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA", "1018");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA", "D");

                //AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO");
                //AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO", "30");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO", "9318");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO", "9703");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WS_NUM_PROPOSTA_AZUL");
                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WS_NUM_PROPOSTA_AZUL", "30");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_IMPMORNATU_MAX");
                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_IMPMORNATU_MAX", "2");

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_TITULO");
                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_TITULO", "32");

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("PESSOA_NOME_PESSOA");
                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("PESSOA_NOME_PESSOA", "gUS");

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CPF");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CPF", "06478122");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_NASCIMENTO", "1970-01-01");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SEXO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SEXO", "M");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("COD_CBO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("COD_CBO", "1");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ESTADO_CIVIL", "S");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ORGAO_EXPEDIDOR");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ORGAO_EXPEDIDOR", "SSP");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_IDENTIDADE");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_IDENTIDADE", "5465456");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_EXPEDICAO", "20/05/2016");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("UF_EXPEDIDORA", "SC");

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("BAIRRO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("BAIRRO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CIDADE");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CIDADE", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CEP");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CEP", "84");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIGLA_UF");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIGLA_UF", "SC");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_RESIDENCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_RESIDENCIAL", "1212");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_RESIDENCIAL", "1212");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_COMERCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_COMERCIAL", "13");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_COMERCIAL", "18");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_CELULAR", "47");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_CELULAR", "177");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_FAX", "45");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_FAX", "45");

                #endregion

                #region VA0601B_CFONE

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_TIPO_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_TIPO_FONE", "C");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_NUM_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_NUM_FONE", "95959");

                #endregion

                #region VA0601B_CRISCO

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO1

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("IMPSEGUR");
                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("IMPSEGUR", "1");

                #endregion

                #region VA0601B_CRISCO2

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO3

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Remove("BILHETE_NUM_APOLICE");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Add("BILHETE_NUM_APOLICE", "1");

                #endregion

                #region R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_CLIENTE");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_CLIENTE", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_IDENTIFICACAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_IDENTIFICACAO", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_NOM_ORGAO_EXP");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_NOM_ORGAO_EXP", "ssp");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_DTH_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_DTH_EXPEDICAO", "30/05/90");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_UF");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_UF", "sc");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("VIND_UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("VIND_UF_EXPEDIDORA", "sc");

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIT_REGISTRO");
                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIT_REGISTRO", "");

                #endregion

                #region VA0601B_CCBO

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_COD_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_COD_CBO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_DESCR_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_DESCR_CBO", "10");

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                #endregion

                #region VA0601B_C01_GECLIMOV

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_MOVIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_MOVIMENTO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_ULT_MANUTEN");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_ULT_MANUTEN", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_NOME_RAZAO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_NOME_RAZAO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TIPO_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TIPO_PESSOA", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_IDE_SEXO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_IDE_SEXO", "m");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ESTADO_CIVIL", "s");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_ENDERECO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_BAIRRO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_BAIRRO", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CIDADE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CIDADE", "a");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_SIGLA_UF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_SIGLA_UF", "sc");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CEP");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CEP", "22");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_TELEFONE");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_TELEFONE", "23");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_FAX");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_FAX", "12");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_CGCCPF");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_CGCCPF", "1");

                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Remove("GECLIMOV_DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_C01_GECLIMOV"].DynamicList.FirstOrDefault().Add("GECLIMOV_DATA_NASCIMENTO", "1980-01-01");

                #endregion

                #region GEJVS002_GE074_CURSOR

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , ""},
                { "PARAMGER_DATA_TERVIGENCIA" , ""},
                { "PARAMGER_COD_MOEDA" , ""},
                { "PARAMGER_COD_BANCO" , ""},
                { "PARAMGER_COD_AGENCIA" , ""},
                { "PARAMGER_OPCAO_BANCO" , ""},
                { "PARAMGER_DIF_PREMIOS" , ""},
                { "PARAMGER_FAIXA_APOL_MANUAL" , ""},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , ""},
                { "PARAMGER_DATA_FATURAVG_AUT" , ""},
                { "PARAMGER_CAPITAL_SOCIAL" , ""},
                { "PARAMGER_CAPITAL_REALIZADO" , ""},
                { "PARAMGER_CAPITAL_VINCULADO" , ""},
                { "PARAMGER_ULT_AVISO_CREDITO" , ""},
                { "PARAMGER_CODIGO_LIDER" , "123"},
                { "PARAMGER_NUM_RELACAO" , ""},
                { "PARAMGER_COD_EMPRESA" , ""},
                { "PARAMGER_COD_CGCCPF" , ""},
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q110);

                #endregion


                #endregion
                var program = new VA0601B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                var envList0 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList0?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                var envList1 = AppSettings.TestSet.DynamicData["R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList1?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro

                var envList2 = AppSettings.TestSet.DynamicData["R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_COD_IDENTIFICACAO", out var valOr) && valOr == "5465456        ");


                var envList3 = AppSettings.TestSet.DynamicData["R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList3?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //Assert.True(program.SPVG001W.LK_VG001_COD_USUARIO == "BATCH");
                //Assert.True(program.SPVG001W.LK_VG001_IND_TP_PROPOSTA == "PF");


            }
        }

        [Fact]
        public static void VA0601B_Tests_Fact_4()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE


                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SISTEMAS_DATA_MOV_ABERTO");
                AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SISTEMAS_DATA_MOV_ABERTO", "2024-08-21");

                #endregion

                #region VA0601B_CPROPOSTA

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR", "nnnn");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO", "11");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF", "5");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA", "2");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA", "1990-05-30");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF", "77");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG", "3");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO", "40");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA", "C");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO", "9314");

                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Remove("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO");
                AppSettings.TestSet.DynamicData["VA0601B_CPROPOSTA"].DynamicList.FirstOrDefault().Add("DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO", "9314");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WS_NUM_PROPOSTA_AZUL");
                AppSettings.TestSet.DynamicData["R1000_CONSISTE_RCAP_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WS_NUM_PROPOSTA_AZUL", "30");

                #endregion

                #region R1000_CONSISTE_RCAP_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_IMPMORNATU_MAX");
                AppSettings.TestSet.DynamicData["R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_IMPMORNATU_MAX", "2");

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_TITULO");
                AppSettings.TestSet.DynamicData["R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_TITULO", "32");

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("PESSOA_NOME_PESSOA");
                AppSettings.TestSet.DynamicData["R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("PESSOA_NOME_PESSOA", "gUS");

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CPF");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CPF", "06478122");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_NASCIMENTO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_NASCIMENTO", "1970-01-01");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SEXO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SEXO", "M");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("COD_CBO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("COD_CBO", "1");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ESTADO_CIVIL");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ESTADO_CIVIL", "S");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ORGAO_EXPEDIDOR");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ORGAO_EXPEDIDOR", "SSP");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("NUM_IDENTIDADE");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("NUM_IDENTIDADE", "5465456");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("DATA_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("DATA_EXPEDICAO", "20/05/2016");

                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("UF_EXPEDIDORA", "SC");

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("OCORR_ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("OCORR_ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("ENDERECO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("ENDERECO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("BAIRRO");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("BAIRRO", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CIDADE");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CIDADE", "a");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("CEP");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("CEP", "84");

                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIGLA_UF");
                AppSettings.TestSet.DynamicData["R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIGLA_UF", "SC");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_RESIDENCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_RESIDENCIAL", "1212");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_RESIDENCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_RESIDENCIAL", "1212");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_COMERCIAL", "12");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_COMERCIAL", "13");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_SEQ_COMERCIAL");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1"].DynamicList.FirstOrDefault().Add("WHOST_SEQ_COMERCIAL", "18");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_CELULAR", "47");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_CELULAR");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_CELULAR", "177");

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_DDD_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_DDD_FAX", "45");

                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Remove("WHOST_FONE_FAX");
                AppSettings.TestSet.DynamicData["R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1"].DynamicList.FirstOrDefault().Add("WHOST_FONE_FAX", "45");

                #endregion

                #region VA0601B_CFONE

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_TIPO_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_TIPO_FONE", "C");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_DDD");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_DDD", "47");

                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Remove("DCLPESSOA_TELEFONE_NUM_FONE");
                AppSettings.TestSet.DynamicData["VA0601B_CFONE"].DynamicList.FirstOrDefault().Add("DCLPESSOA_TELEFONE_NUM_FONE", "95959");

                #endregion

                #region VA0601B_CRISCO

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO1

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO1"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("IMPSEGUR");
                AppSettings.TestSet.DynamicData["R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("IMPSEGUR", "1");

                #endregion

                #region VA0601B_CRISCO2

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Remove("PROPVA_NRCERTIF");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO2"].DynamicList.FirstOrDefault().Add("PROPVA_NRCERTIF", "1");

                #endregion

                #region VA0601B_CRISCO3

                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Remove("BILHETE_NUM_APOLICE");
                AppSettings.TestSet.DynamicData["VA0601B_CRISCO3"].DynamicList.FirstOrDefault().Add("BILHETE_NUM_APOLICE", "1");

                #endregion

                #region R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_CLIENTE");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_CLIENTE", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_IDENTIFICACAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_IDENTIFICACAO", "1");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_NOM_ORGAO_EXP");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_NOM_ORGAO_EXP", "ssp");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_DTH_EXPEDICAO");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_DTH_EXPEDICAO", "30/05/90");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GEDOCCLI_COD_UF");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GEDOCCLI_COD_UF", "sc");

                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("VIND_UF_EXPEDIDORA");
                AppSettings.TestSet.DynamicData["R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("VIND_UF_EXPEDIDORA", "sc");

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("SIT_REGISTRO");
                AppSettings.TestSet.DynamicData["R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("SIT_REGISTRO", "");

                #endregion

                #region VA0601B_CCBO

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_COD_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_COD_CBO", "1");

                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Remove("DCLCBO_CBO_DESCR_CBO");
                AppSettings.TestSet.DynamicData["VA0601B_CCBO"].DynamicList.FirstOrDefault().Add("DCLCBO_CBO_DESCR_CBO", "10");

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Remove("GECLIMOV_OCORR_HIST");
                AppSettings.TestSet.DynamicData["R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1"].DynamicList.FirstOrDefault().Add("GECLIMOV_OCORR_HIST", "1");

                #endregion


                #endregion
                var program = new VA0601B();
                program.Execute();

                //var envList = AppSettings.TestSet.DynamicData["R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //var envList0 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList0?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro


                //var envList1 = AppSettings.TestSet.DynamicData["R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1"].DynamicList;
                //Assert.True(envList1?.Count > 1); // lembrando que 1 porque a lista começa com 1 registro

                var envList2 = AppSettings.TestSet.DynamicData["R2316_00_UPDATE_GE_DOC_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("GEDOCCLI_COD_IDENTIFICACAO", out var valOr) && valOr == "5465456        ");

                var envList3 = AppSettings.TestSet.DynamicData["R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(envList3[1].TryGetValue("WHOST_SIT_PROPOSTA", out var valsr) && valsr == "PEN");

                //Assert.True(program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "1990-05-30");
            }
        }
    }
}