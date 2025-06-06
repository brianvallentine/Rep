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
using Dclgens;
using Code;
using static Code.VP0601B;

namespace FileTests.Test
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VP0601B_Tests")]
    public class VP0601B_Tests
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

            #region VP0601B_CPROPOSTA

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
                { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
                { "DCLPRODUTOS_VG_PRODUVG_RAMO" , ""},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CPROPOSTA", q2);

            #endregion

            #region VP0601B_C01_RCAPCOMP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_C01_RCAPCOMP", q3);

            #endregion

            #region R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NOME_SEGURADO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AZUL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "COD_ERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_CADASTRO_IS_SUPERIOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ESTIPULA_NOME_ESTIPULANTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q14);

            #endregion

            #region R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , ""},
                { "IMPMORACID" , ""},
                { "IMPINVPERM" , ""},
                { "IMPAMDS" , ""},
                { "IMPDH" , ""},
                { "IMPDIT" , ""},
                { "VLPREMIOTOT" , ""},
                { "PRMVG" , ""},
                { "PRMAP" , ""},
                { "TAXAVG" , ""},
                { "COD_PLANO" , ""},
                { "QTTITCAP" , ""},
                { "VLTITCAP" , ""},
                { "VLCUSTCAP" , ""},
                { "IMPSEGCDG" , ""},
                { "VLCUSTCDG" , ""},
                { "IMPSEGAUXF" , ""},
                { "VLCUSTAUXF" , ""},
                { "PRMDIT" , ""},
                { "QTDIT" , ""},
                { "FAIXA_SAL_FIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q17);

            #endregion

            #region R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , ""},
                { "IMPMORACID" , ""},
                { "IMPINVPERM" , ""},
                { "IMPAMDS" , ""},
                { "IMPDH" , ""},
                { "IMPDIT" , ""},
                { "VLPREMIOTOT" , ""},
                { "PRMVG" , ""},
                { "PRMAP" , ""},
                { "TAXAVG" , ""},
                { "COD_PLANO" , ""},
                { "QTTITCAP" , ""},
                { "VLTITCAP" , ""},
                { "VLCUSTCAP" , ""},
                { "IMPSEGCDG" , ""},
                { "VLCUSTCDG" , ""},
                { "IMPSEGAUXF" , ""},
                { "VLCUSTAUXF" , ""},
                { "PRMDIT" , ""},
                { "QTDIT" , ""},
                { "FAIXA_SAL_FIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q21);

            #endregion

            #region VP0601B_CPESENDER

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CPESENDER", q22);

            #endregion

            #region R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NRMATRVEN" , ""},
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q25);

            #endregion

            #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "NUM_TITULO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1", q26);

            #endregion

            #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1", q27);

            #endregion

            #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "WHOST_DATA_NASCIMENTO_7708" , ""},
                { "WHOST_DATA_NASCIMENTO_2" , ""},
                { "SEXO" , ""},
                { "COD_CBO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "UF_EXPEDIDORA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q28);

            #endregion

            #region R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "CPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q29);

            #endregion

            #region R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "PESSOJUR_CGC" , ""},
                { "PESSOJUR_NOME_FANTASIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1", q30);

            #endregion

            #region R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "OCOREND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q31);

            #endregion

            #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , ""},
                { "ENDERECO" , ""},
                { "BAIRRO" , ""},
                { "CIDADE" , ""},
                { "CEP" , ""},
                { "SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1", q32);

            #endregion

            #region VP0601B_CPESENDERR

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CPESENDERR", q33);

            #endregion

            #region VP0601B_CFONE

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_TELEFONE_TIPO_FONE" , ""},
                { "DCLPESSOA_TELEFONE_DDD" , ""},
                { "DCLPESSOA_TELEFONE_NUM_FONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CFONE", q34);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_RESIDENCIAL" , ""},
                { "WHOST_FONE_RESIDENCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1", q35);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_COMERCIAL" , ""},
                { "WHOST_FONE_COMERCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1", q36);

            #endregion

            #region VP0601B_CRISCO

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CRISCO", q37);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_CELULAR" , ""},
                { "WHOST_FONE_CELULAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1", q38);

            #endregion

            #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_FAX" , ""},
                { "WHOST_FONE_FAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1", q39);

            #endregion

            #region R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1", q41);

            #endregion

            #region R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1", q42);

            #endregion

            #region R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_INFORMACAO_COMPL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1", q43);

            #endregion

            #region VP0601B_CCLIENTES

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "DCLCLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CCLIENTES", q44);

            #endregion

            #region R2241_10_FETCH_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "IMP_MORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2241_10_FETCH_DB_SELECT_1_Query1", q45);

            #endregion

            #region R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "FAIXA_SAL_FIM" , ""},
                { "TAXAVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1", q46);

            #endregion

            #region R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "FAIXA_SAL_FIM" , ""},
                { "TAXAVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1", q47);

            #endregion

            #region R2247_CALCULO_IDADE_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2247_CALCULO_IDADE_DB_SELECT_1_Query1", q48);

            #endregion

            #region R2247_CALCULO_IDADE_DB_SELECT_2_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "WS_DIAS_ANO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2247_CALCULO_IDADE_DB_SELECT_2_Query1", q49);

            #endregion

            #region VP0601B_VGPLARAMC

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "VGPLAR_NUM_RAMO" , ""},
                { "VGPLAR_NUM_COBERTURA" , ""},
                { "VGPLAR_QTD_COBERTURA" , ""},
                { "VGPLAR_IMPSEGURADA" , ""},
                { "VGPLAR_CUSTO" , ""},
                { "VGPLAR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_VGPLARAMC", q50);

            #endregion

            #region R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "PESSOJUR_NOME_FANTASIA" , ""},
                { "PESSOJUR_CGC" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1", q51);

            #endregion

            #region R2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "ESTADO_CIVIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1", q52);

            #endregion

            #region R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1", q53);

            #endregion

            #region R2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1", q54);

            #endregion

            #region R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1", q55);

            #endregion

            #region R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1", q56);

            #endregion

            #region R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1", q57);

            #endregion

            #region R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q58);

            #endregion

            #region R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1", q59);

            #endregion

            #region R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1", q60);

            #endregion

            #region R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1", q61);

            #endregion

            #region R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1", q62);

            #endregion

            #region R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q63);

            #endregion

            #region R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , ""},
                { "COD_CLIENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1", q64);

            #endregion

            #region R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1", q65);

            #endregion

            #region R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "CLIENEMA_SEQ_EMAIL" , ""},
                { "WHOST_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1", q66);

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
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
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
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1", q67);

            #endregion

            #region R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "WS_VALOR_IS_CDC" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q68);

            #endregion

            #region R3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1", q69);

            #endregion

            #region R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "WS_TAXAVG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1", q70);

            #endregion

            #region VP0601B_VGPLAACES

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "VGPLAA_NUM_ACESSORIO" , ""},
                { "VGPLAA_QTD_COBERTURA" , ""},
                { "VGPLAA_IMPSEGURADA" , ""},
                { "VGPLAA_CUSTO" , ""},
                { "VGPLAA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_VGPLAACES", q71);

            #endregion

            #region R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "VGPLAR_NUM_RAMO" , ""},
                { "VGPLAR_NUM_COBERTURA" , ""},
                { "VGPLAR_QTD_COBERTURA" , ""},
                { "VGPLAR_IMPSEGURADA" , ""},
                { "VGPLAR_CUSTO" , ""},
                { "VGPLAR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1", q72);

            #endregion

            #region VP0601B_C01_AGENCEF

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , ""},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_C01_AGENCEF", q73);

            #endregion

            #region R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "VGPLAA_NUM_ACESSORIO" , ""},
                { "VGPLAA_QTD_COBERTURA" , ""},
                { "VGPLAA_IMPSEGURADA" , ""},
                { "VGPLAA_CUSTO" , ""},
                { "VGPLAA_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1", q74);

            #endregion

            #region R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

            var q75 = new DynamicData();
            q75.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q75);

            #endregion

            #region R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1

            var q76 = new DynamicData();
            q76.AddDynamic(new Dictionary<string, string>{
                { "VG096_NUM_CERTIFICADO" , ""},
                { "VG096_NUM_PARCELA" , ""},
                { "VG096_DTA_VENCIMENTO" , ""},
                { "VG096_VLR_PARCELA" , ""},
                { "VG096_STA_REGISTRO" , ""},
                { "VG096_COD_IDLG" , ""},
                { "VG096_COD_RETORNO" , ""},
                { "VG096_DES_RETORNO" , ""},
                { "VG096_COD_CONVENIO" , ""},
                { "VG096_NUM_BANCO_DEBITO" , ""},
                { "VG096_NUM_AGENCIA_DEBITO" , ""},
                { "VG096_NUM_CONTA_DEBITO" , ""},
                { "VG096_NOM_PROGRAMA" , ""},
                { "VG096_DTA_PROXIMA_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1", q76);

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

            #region R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

            var q79 = new DynamicData();
            q79.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_PARCELA" , ""},
                { "NUM_TITULO" , ""},
                { "WS_DATA_QUITACAO" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q79);

            #endregion

            #region R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

            var q80 = new DynamicData();
            q80.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q80);

            #endregion

            #region R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1

            var q81 = new DynamicData();
            q81.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1", q81);

            #endregion

            #region R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1

            var q82 = new DynamicData();
            q82.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1", q82);

            #endregion

            #region R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1

            var q83 = new DynamicData();
            q83.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1", q83);

            #endregion

            #region R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1

            var q84 = new DynamicData();
            q84.AddDynamic(new Dictionary<string, string>{
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
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
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
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1", q84);

            #endregion

            #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

            var q85 = new DynamicData();
            q85.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q85);

            #endregion

            #region R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q86 = new DynamicData();
            q86.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIT_PROPOSTA" , ""},
                { "WHOST_SIT_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q86);

            #endregion

            #region R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1

            var q87 = new DynamicData();
            q87.AddDynamic(new Dictionary<string, string>{
                { "PF062_DES_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1", q87);

            #endregion

            #region R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

            var q88 = new DynamicData();
            q88.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "VIND_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "VIND_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "VIND_NOME_CONJUGE" , ""},
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
            AppSettings.TestSet.DynamicData.Add("R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q88);

            #endregion

            #region VP0601B_CCBO

            var q89 = new DynamicData();
            q89.AddDynamic(new Dictionary<string, string>{
                { "DCLCBO_CBO_COD_CBO" , ""},
                { "DCLCBO_CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CCBO", q89);

            #endregion

            #region VP0601B_CFONTES

            var q90 = new DynamicData();
            q90.AddDynamic(new Dictionary<string, string>{
                { "DCLFONTES_FONTES_COD_FONTE" , ""},
                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VP0601B_CFONTES", q90);

            #endregion

            #region VP0601B_C01_GECLIMOV

            var q91 = new DynamicData();
            q91.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VP0601B_C01_GECLIMOV", q91);

            #endregion

            #region R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1

            var q92 = new DynamicData();
            q92.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1", q92);

            #endregion

            #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

            var q93 = new DynamicData();
            q93.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q93);

            #endregion

            #region R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1

            var q94 = new DynamicData();
            q94.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1", q94);

            #endregion

            #region R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1

            var q95 = new DynamicData();
            q95.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1", q95);

            #endregion

            #endregion
        }

        [Fact]
        public static void VP0601B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GEJVS002_Tests.Load_Parameters();
                #region GEJVS002_GE074_CURSOR

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "2020-10-10"},
                { "PARAMGER_DATA_TERVIGENCIA" , "2020-10-10"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "2"},
                { "PARAMGER_COD_AGENCIA" , "3"},
                { "PARAMGER_OPCAO_BANCO" , "4"},
                { "PARAMGER_DIF_PREMIOS" , "5"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "6"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "7"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "2020-10-10"},
                { "PARAMGER_CAPITAL_SOCIAL" , "8"},
                { "PARAMGER_CAPITAL_REALIZADO" , "9"},
                { "PARAMGER_CAPITAL_VINCULADO" , "10"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "11"},
                { "PARAMGER_CODIGO_LIDER" , "12"},
                { "PARAMGER_NUM_RELACAO" , "123"},
                { "PARAMGER_COD_EMPRESA" , "1"},
                { "PARAMGER_COD_CGCCPF" , "12345"},
                { "PARAMGER_COD_EMPRESA_CAP" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("GEJVS002_GE074_CURSOR");
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q100);

                #endregion

                CT0006S_Tests.Load_Parameters();
                #region R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "GE353_COD_INI_FAIXA_CEP" , "1"},
                { "GE353_COD_FIM_FAIXA_CEP" , "2"},
                { "GE353_NOM_UNIDADE_OPER" , "X"},
                { "GE353_NOM_CENTRALIZADOR" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1", q101);

                #endregion

                #region R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "GE332_COD_INI_CEP" , "1"},
                { "GE332_COD_FIM_CEP" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1", q102);

                #endregion

                #region R1110_10_SELECT_GE318_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "GE318_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_10_SELECT_GE318_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_10_SELECT_GE318_DB_SELECT_1_Query1", q103);

                #endregion

                #region R1110_10_SELECT_GE318_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "GE318_IND_TP_LOGRADOURO" , "1"},
                { "GE318_NOM_LOGRADOURO" , "X1"},
                { "GE329_NOM_BAIRRO" , "X2"},
                { "GE324_NOM_LOCALIDADE" , "X3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_10_SELECT_GE318_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_10_SELECT_GE318_DB_SELECT_2_Query1", q104);

                #endregion

                #region R1110_20_SELECT_GE321_DB_SELECT_1_Query1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "GE321_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_20_SELECT_GE321_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_20_SELECT_GE321_DB_SELECT_1_Query1", q105);

                #endregion

                #region R1110_20_SELECT_GE321_DB_SELECT_2_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "GE321_NOM_TP_LOGRADOURO" , "X1"},
                { "GE321_NOM_LOGRADOURO" , "X2"},
                { "GE329_NOM_BAIRRO" , "X3"},
                { "GE324_NOM_LOCALIDADE" , "X4"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_20_SELECT_GE321_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_20_SELECT_GE321_DB_SELECT_2_Query1", q106);

                #endregion

                #region R1110_30_SELECT_GE322_DB_SELECT_1_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "GE322_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_30_SELECT_GE322_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_30_SELECT_GE322_DB_SELECT_1_Query1", q107);

                #endregion

                #region R1110_30_SELECT_GE322_DB_SELECT_2_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "GE322_NOM_TP_LOGRADOURO" , "X1"},
                { "GE322_NOM_LOGRADOURO" , "X2"},
                { "GE329_NOM_BAIRRO" , "X3"},
                { "GE324_NOM_LOCALIDADE" , "X4"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_30_SELECT_GE322_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_30_SELECT_GE322_DB_SELECT_2_Query1", q108);

                #endregion

                #region R1110_40_SELECT_GE326_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "GE326_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_40_SELECT_GE326_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_40_SELECT_GE326_DB_SELECT_1_Query1", q109);

                #endregion

                #region R1110_50_SELECT_GE324_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "GE324_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_50_SELECT_GE324_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_50_SELECT_GE324_DB_SELECT_1_Query1", q110);

                #endregion
               

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_INICIALIZA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "NUM_CLIENTE" , "12345"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0601B_CPROPOSTA

                var q2 = new DynamicData();
             
                q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , "77"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , "1"},
                { "PROPSSVD_NUM_CONTR_VINCULO" , "1"},
                { "PROPSSVD_COD_CORRESP_BANC" , "1"},
                { "PROPSSVD_NUM_PRAZO_FIN" , "0"},
                { "PROPSSVD_COD_OPER_CREDITO" , "0"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , "100"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "x"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , "x"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , "1"},
                { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , "7732"},
                { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , "2020-01-01"},
                { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , "77"},
                { "DCLPRODUTOS_VG_PRODUVG_RAMO" , "77"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , "77"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , "1"},
                { "PROPSSVD_NUM_CONTR_VINCULO" , "1"},
                { "PROPSSVD_COD_CORRESP_BANC" , "1"},
                { "PROPSSVD_NUM_PRAZO_FIN" , "0"},
                { "PROPSSVD_COD_OPER_CREDITO" , "0"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , "100"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "x"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , "x"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , "1"},
                { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , "7732"},
                { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , "2020-01-01"},
                { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , "77"},
                { "DCLPRODUTOS_VG_PRODUVG_RAMO" , "77"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , "77"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , "1"},
                { "PROPSSVD_NUM_CONTR_VINCULO" , "1"},
                { "PROPSSVD_COD_CORRESP_BANC" , "1"},
                { "PROPSSVD_NUM_PRAZO_FIN" , "0"},
                { "PROPSSVD_COD_OPER_CREDITO" , "0"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , "1"},
                { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA" , "100"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "x"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSL" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE" , "1"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE" , "2020-01-01"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE" , "x"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND" , "77"},
                { "DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM" , "1"},
                { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , "7732"},
                { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , "2020-01-01"},
                { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , "77"},
                { "DCLPRODUTOS_VG_PRODUVG_RAMO" , "77"},
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CPROPOSTA", q2);

                #endregion

                #region VP0601B_C01_RCAPCOMP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "1"},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "2"},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "3"},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2025-05-02"},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2025-05-01"},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0601B_C01_RCAPCOMP", q3);

                #endregion

                #region R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NOME_SEGURADO" , "RCAP_CADASTRADO"},
                { "RCAPS_AGE_COBRANCA" , "RCAP_CADASTRADO"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AZUL" , "123456" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1", q7);

                #endregion            

                #region R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WS_CADASTRO_IS_SUPERIOR" , "X" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "ESTIPULA_NOME_ESTIPULANTE" , "João Silva" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q10);


                #endregion

                #region R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "1" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "1" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "6" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "1" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , "Maria Souza" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , "1" },
                { "IMPMORACID" , "1" },
                { "IMPINVPERM" , "1" },
                { "IMPAMDS" , "150" },
                { "IMPDH" , "300" },
                { "IMPDIT" , "250" },
                { "VLPREMIOTOT" , "1200" },
                { "PRMVG" , "100" },
                { "PRMAP" , "50" },
                { "QTTITCAP" , "10" },
                { "VLTITCAP" , "100" },
                { "VLCUSTCAP" , "80" },
                { "IMPSEGCDG" , "10" },
                { "VLCUSTCDG" , "5" },
                { "IMPSEGAUXF" , "20" },
                { "VLCUSTAUXF" , "15" },
                { "PRMDIT" , "200" },
                { "QTDIT" , "5" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , "5" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q14);

                #endregion

                #region R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU" , "2" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , "1" },
                { "IMPMORACID" , "7" },
                { "IMPINVPERM" , "3" },
                { "IMPAMDS" , "2" },
                { "IMPDH" , "4" },
                { "IMPDIT" , "3" },
                { "VLPREMIOTOT" , "1" },
                { "PRMVG" , "0" },
                { "PRMAP" , "0" },
                { "TAXAVG" , "5" },
                { "COD_PLANO" , "P100" },
                { "QTTITCAP" , "12" },
                { "VLTITCAP" , "120" },
                { "VLCUSTCAP" , "90" },
                { "IMPSEGCDG" , "15" },
                { "VLCUSTCDG" , "10" },
                { "IMPSEGAUXF" , "25" },
                { "VLCUSTAUXF" , "18" },
                { "PRMDIT" , "250" },
                { "QTDIT" , "8" },
                { "FAIXA_SAL_FIM" , "5000" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , "8000" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q17);

                #endregion

                #region R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , "2000" },
                { "IMPMORACID" , "1000" },
                { "IMPINVPERM" , "400" },
                { "IMPAMDS" , "300" },
                { "IMPDH" , "500" },
                { "IMPDIT" , "450" },
                { "VLPREMIOTOT" , "1600" },
                { "PRMVG" , "140" },
                { "PRMAP" , "70" },
                { "TAXAVG" , "6" },
                { "COD_PLANO" , "P200" },
                { "QTTITCAP" , "15" },
                { "VLTITCAP" , "150" },
                { "VLCUSTCAP" , "110" },
                { "IMPSEGCDG" , "20" },
                { "VLCUSTCDG" , "15" },
                { "IMPSEGAUXF" , "30" },
                { "VLCUSTAUXF" , "22" },
                { "PRMDIT" , "300" },
                { "QTDIT" , "10" },
                { "FAIXA_SAL_FIM" , "6000" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "1" },
                { "RCAPS_NUM_RCAP" , "3" },
                { "RCAPS_VAL_RCAP" , "25" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "2" },
                { "RCAPS_NUM_RCAP" , "4" },
                { "RCAPS_VAL_RCAP" , "27" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "1" },
                { "RCAPCOMP_AGE_AVISO" , "1" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "1" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2025-04-25" },
                { "RCAPCOMP_DATA_RCAP" , "2025-04-26" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q21);

                #endregion

                #region VP0601B_CPESENDER

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "1" },
                { "DCLPESSOA_ENDERECO_ENDERECO" , "1" },
                { "DCLPESSOA_ENDERECO_BAIRRO" , "1" },
                { "DCLPESSOA_ENDERECO_CIDADE" , "1" },
                { "DCLPESSOA_ENDERECO_CEP" , "1" },
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "SP" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CPESENDER");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CPESENDER", q22);

                #endregion

                #region R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "S" }
                });
                q25.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "N" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q25);

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "NUM_TITULO" , "HT123456789" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1", q26);

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , "Carlos Eduardo Lima" },
                { "PESSOA_TIPO_PESSOA" , "M" },
                });
                q27.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , "Carlos Eduardo Lima" },
                { "PESSOA_TIPO_PESSOA" , "F" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1", q27);

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "CPF" , "12" },
                { "DATA_NASCIMENTO" , "1990-05-20" },
                { "WHOST_DATA_NASCIMENTO_7708" , "1" },
                { "WHOST_DATA_NASCIMENTO_2" , "2020-01-01" },
                { "SEXO" , "M" },
                { "COD_CBO" , "1" },
                { "ESTADO_CIVIL" , "2" },
                { "ORGAO_EXPEDIDOR" , "SSP" },
                { "NUM_IDENTIDADE" , "1" },
                { "DATA_EXPEDICAO" , "2008-06-15" },
                { "UF_EXPEDIDORA" , "MG" },
                });
                
                AppSettings.TestSet.DynamicData.Remove("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q28);

                #endregion

                #region R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "CPF" , "9" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q29);
                #endregion

                #region R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "PESSOJUR_CGC" , "1" },
                { "PESSOJUR_NOME_FANTASIA" , "X" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1", q30);


                #endregion

                #region R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "OCOREND" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q31);

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , "1" },
                { "ENDERECO" , "Brasil" },
                { "BAIRRO" , "Centro" },
                { "CIDADE" , "Rio de Janeiro" },
                { "CEP" , "20" },
                { "SIGLA_UF" , "RJ" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1", q32);

                #endregion

                #region VP0601B_CPESENDERR

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "4" },
                { "DCLPESSOA_ENDERECO_ENDERECO" , "R" },
                { "DCLPESSOA_ENDERECO_BAIRRO" , "B" },
                { "DCLPESSOA_ENDERECO_CIDADE" , "x" },
                { "DCLPESSOA_ENDERECO_CEP" , "31" },
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "MG" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CPESENDERR");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CPESENDERR", q33);

                #endregion

                #region VP0601B_CFONE

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_TELEFONE_TIPO_FONE" , "R" },
                { "DCLPESSOA_TELEFONE_DDD" , "1" },
                { "DCLPESSOA_TELEFONE_NUM_FONE" , "23456789" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CFONE");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CFONE", q34);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_RESIDENCIAL" , "1" },
                { "WHOST_FONE_RESIDENCIAL" , "345" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1", q35);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_COMERCIAL" , "31" },
                { "WHOST_FONE_COMERCIAL" , "45" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1", q36);

                #endregion

                #region VP0601B_CRISCO

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CRISCO");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CRISCO", q37);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_CELULAR" , "1" },
                { "WHOST_FONE_CELULAR" , "9" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1", q38);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_FAX" , "8" },
                { "WHOST_FONE_FAX" , "33" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1", q39);

                #endregion

                #region R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , "exemplo@email.com" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1", q41);

                #endregion

                #region R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_INFORMACAO_COMPL" , "Cliente" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1", q43);


                #endregion

                #region VP0601B_CCLIENTES

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "DCLCLIENTES_COD_CLIENTE" , "x" }
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CCLIENTES");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CCLIENTES", q44);

                #endregion

                #region R2241_10_FETCH_DB_SELECT_1_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "IMP_MORNATU" , "4" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2241_10_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2241_10_FETCH_DB_SELECT_1_Query1", q45);

                #endregion

                #region R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "FAIXA_SAL_FIM" , "5" },
                { "TAXAVG" , "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1", q46);

                #endregion

                #region R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "FAIXA_SAL_FIM" , "1" },
                { "TAXAVG" , "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1", q47);

                #endregion

                #region R2247_CALCULO_IDADE_DB_SELECT_1_Query1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_NASCIMENTO" , "1985-06-15" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2247_CALCULO_IDADE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2247_CALCULO_IDADE_DB_SELECT_1_Query1", q48);


                #endregion

                #region R2247_CALCULO_IDADE_DB_SELECT_2_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "WS_DIAS_ANO" , "3" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2247_CALCULO_IDADE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2247_CALCULO_IDADE_DB_SELECT_2_Query1", q49);

                #endregion

                #region VP0601B_VGPLARAMC

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "VGPLAR_NUM_RAMO" , "3" },
                { "VGPLAR_NUM_COBERTURA" , "1" },
                { "VGPLAR_QTD_COBERTURA" , "1" },
                { "VGPLAR_IMPSEGURADA" , "10" },
                { "VGPLAR_CUSTO" , "50" },
                { "VGPLAR_PREMIO" , "7" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_VGPLARAMC");
                AppSettings.TestSet.DynamicData.Add("VP0601B_VGPLARAMC", q50);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1", q55);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1", q56);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "2" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1", q57);

                #endregion

                #region R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

                var q58 = new DynamicData();
                q58.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , "001" },
                { "ENDERECO_ENDERECO" , "Rua São João, 456" },
                { "ENDERECO_BAIRRO" , "Centro" },
                { "ENDERECO_CIDADE" , "Porto Alegre" },
                { "ENDERECO_SIGLA_UF" , "RS" },
                { "ENDERECO_CEP" , "90" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q58);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1", q59);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1", q60);

                #endregion

                #region R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1", q61);

                #endregion

                #region R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
               { "CLIENEMA_EMAIL" , "cliente@exemplo.com" }
               });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q63);


                #endregion

                #region R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_SEQ_EMAIL" , "0001" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1", q65);

                #endregion

                #region R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "WS_TAXAVG" , "8" }
                 });
                AppSettings.TestSet.DynamicData.Remove("R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1", q70);

                #endregion

                #region VP0601B_VGPLAACES

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "VGPLAA_NUM_ACESSORIO" , "1" },
                { "VGPLAA_QTD_COBERTURA" , "1" },
                { "VGPLAA_IMPSEGURADA" , "1" },
                { "VGPLAA_CUSTO" , "1" },
                { "VGPLAA_PREMIO" , "1" },
                 });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_VGPLAACES");
                AppSettings.TestSet.DynamicData.Add("VP0601B_VGPLAACES", q71);

                #endregion

                #region VP0601B_C01_AGENCEF

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "1" },
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "FNT01" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_C01_AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VP0601B_C01_AGENCEF", q73);

                #endregion

                #region R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "9" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1", q81);

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                var q85 = new DynamicData();
                 q85.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q85);

                #endregion

                #region R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "PF062_DES_CBO" , "An" }
                });
                AppSettings.TestSet.DynamicData.Remove("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1", q87);

                #endregion

                #region VP0601B_CCBO

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "DCLCBO_CBO_COD_CBO" , "2" },
                { "DCLCBO_CBO_DESCR_CBO" , "E" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CCBO");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CCBO", q89);

                #endregion

                #region VP0601B_CFONTES

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "DCLFONTES_FONTES_COD_FONTE" , "2" },
                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "2025-04-30" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CFONTES");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CFONTES", q90);

                #endregion

                #region VP0601B_C01_GECLIMOV

                var q91 = new DynamicData();
                q91.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_TIPO_MOVIMENTO" , "I" },
                { "GECLIMOV_DATA_ULT_MANUTEN" , "2025-05-01" },
                { "GECLIMOV_NOME_RAZAO" , "João" },
                { "GECLIMOV_TIPO_PESSOA" , "F" },
                { "GECLIMOV_IDE_SEXO" , "M" },
                { "GECLIMOV_ESTADO_CIVIL" , "SOLTEIRO" },
                { "GECLIMOV_OCORR_ENDERECO" , "009001" },
                { "GECLIMOV_ENDERECO" , "Rua" },
                { "GECLIMOV_BAIRRO" , "Centro" },
                { "GECLIMOV_CIDADE" , "São Paulo" },
                { "GECLIMOV_SIGLA_UF" , "SP" },
                { "GECLIMOV_CEP" , "0" },
                { "GECLIMOV_DDD" , "11" },
                { "GECLIMOV_TELEFONE" , "9" },
                { "GECLIMOV_FAX" , "1" },
                { "GECLIMOV_OCORR_HIST" , "000123" },
                { "GECLIMOV_CGCCPF" , "1" },
                { "GECLIMOV_DATA_NASCIMENTO" , "1990-01-01" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_C01_GECLIMOV");
                AppSettings.TestSet.DynamicData.Add("VP0601B_C01_GECLIMOV", q91);

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_HIST" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q93);

                #endregion

                #endregion

                var program = new VP0601B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region R0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1

                var envList = AppSettings.TestSet.DynamicData["R0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList[1].TryGetValue("PROPOFID_AGECOBR", out var PROPOFID_AGECOBR) && PROPOFID_AGECOBR == "0000");
                Assert.True(envList[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF) && PROPOFID_NUM_PROPOSTA_SIVPF == "000000000000001");

                #endregion
          
                #region R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

               var envList2 = AppSettings.TestSet.DynamicData["R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList2?.Count > 1);
               Assert.True(envList2[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF2) && PROPOFID_NUM_PROPOSTA_SIVPF2 == "000000000000001");
               Assert.True(envList2[1].TryGetValue("COD_ERRO", out var COD_ERRO) && COD_ERRO == "0402");

             #endregion
      
              /*  #region R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

                var envListR1600 = AppSettings.TestSet.DynamicData["R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR1600?.Count > 1);
                Assert.True(envListR1600[1].TryGetValue("PROPOFID_NRMATRVEN", out var PROPOFID_NRMATRVEN) && PROPOFID_NRMATRVEN == "000000000000010");
                Assert.True(envListR1600[1].TryGetValue("WHOST_SIT_PROPOSTA", out var WHOST_SIT_PROPOSTA) && WHOST_SIT_PROPOSTA == "PEN");
                Assert.True(envListR1600[1].TryGetValue("WHOST_SIT_ENVIO", out var WHOST_SIT_ENVIO) && WHOST_SIT_ENVIO == "S");
                Assert.True(envListR1600[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF3) && PROPOFID_NUM_PROPOSTA_SIVPF3 == "000000000000001");

                #endregion*/
                               
                #region R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1

                var envListR2235 = AppSettings.TestSet.DynamicData["R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR2235?.Count > 1);
                Assert.True(envListR2235[1].TryGetValue("PROPOFID_COD_PESSOA", out var PROPOFID_COD_PESSOA) && PROPOFID_COD_PESSOA == "000000001");

                #endregion

                #region R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1

                var envListR2236 = AppSettings.TestSet.DynamicData["R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR2236?.Count > 1);
                Assert.True(envListR2236[1].TryGetValue("PROPOFID_COD_PESSOA", out var PROPOFID_COD_PESSOA2) && PROPOFID_COD_PESSOA2 == "000000001");

                #endregion

              /* #region R2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1
                
                var envListR2310_2 = AppSettings.TestSet.DynamicData["R2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1"].DynamicList;
                 Assert.True(envListR2310_2?.Count > 1);
                 Assert.True(envListR2310_2[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE2) && COD_CLIENTE2 == "000012346");
                 Assert.True(envListR2310_2[1].TryGetValue("PESSOA_NOME_PESSOA", out var PESSOA_NOME_PESSOA) && PESSOA_NOME_PESSOA == "Carlos Eduardo Lima                     ");
                 Assert.True(envListR2310_2[1].TryGetValue("CPF", out var CPF) && CPF == "00000000012");
                 Assert.True(envListR2310_2[1].TryGetValue("DATA_NASCIMENTO", out var DATA_NASCIMENTO2) && DATA_NASCIMENTO2 == "1990-05-20");
                 Assert.True(envListR2310_2[1].TryGetValue("SEXO", out var SEXO) && SEXO == "M");
                 Assert.True(envListR2310_2[1].TryGetValue("ESTADO_CIVIL", out var ESTADO_CIVIL) && ESTADO_CIVIL == "2");
               
                #endregion*/

               /* #region R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1

                var envListR2315_1 = AppSettings.TestSet.DynamicData["R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR2315_1?.Count > 1);
                Assert.True(envListR2315_1[1].TryGetValue("GEDOCCLI_COD_CLIENTE", out var GEDOCCLI_COD_CLIENTE) && GEDOCCLI_COD_CLIENTE == "000012346");

                #endregion*/

                /*#region R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1

                var envListR2420 = AppSettings.TestSet.DynamicData["R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR2420?.Count > 1);
                Assert.True(envListR2420[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE3) && COD_CLIENTE3 == "000012346");
                Assert.True(envListR2420[1].TryGetValue("ENDERECO_OCORR_ENDERECO", out var ENDERECO_OCORR_ENDERECO) && ENDERECO_OCORR_ENDERECO == "0001");
                Assert.True(envListR2420[1].TryGetValue("ENDERECO", out var ENDERECO) && ENDERECO == "1                                       ");
                Assert.True(envListR2420[1].TryGetValue("BAIRRO", out var BAIRRO) && BAIRRO == "1                   ");
                Assert.True(envListR2420[1].TryGetValue("CIDADE", out var CIDADE) && CIDADE == "1                   ");
                Assert.True(envListR2420[1].TryGetValue("SIGLA_UF", out var SIGLA_UF) && SIGLA_UF == "SP");
                Assert.True(envListR2420[1].TryGetValue("CEP", out var CEP) && CEP == "000000001");
                Assert.True(envListR2420[1].TryGetValue("WHOST_DDD", out var WHOST_DDD) && WHOST_DDD == "0000");
                Assert.True(envListR2420[1].TryGetValue("WHOST_FONE", out var WHOST_FONE) && WHOST_FONE == "000000000");
                Assert.True(envListR2420[1].TryGetValue("WHOST_FAX", out var WHOST_FAX) && WHOST_FAX == "023456789");
                Assert.True(envListR2420[1].TryGetValue("WHOST_TELEX", out var WHOST_TELEX) && WHOST_TELEX == "000000000");

                #endregion*/

                /*#region R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1

                var envListR2510 = AppSettings.TestSet.DynamicData["R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR2510?.Count > 1);
                Assert.True(envListR2510[1].TryGetValue("WHOST_EMAIL", out var WHOST_EMAIL) && WHOST_EMAIL == "exemplo@email.com                       ");
                Assert.True(envListR2510[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE4) && COD_CLIENTE4 == "000000001");

                #endregion*/

              /* #region R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1

                var envListR3000 = AppSettings.TestSet.DynamicData["R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3000?.Count > 1);
                Assert.True(envListR3000[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3000) && PROPOFID_NUM_PROPOSTA_SIVPF_3000 == "000000000000001");
                Assert.True(envListR3000[1].TryGetValue("PRODUVG_COD_PRODUTO", out var PRODUVG_COD_PRODUTO) && PRODUVG_COD_PRODUTO == "7732");
                Assert.True(envListR3000[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE) && COD_CLIENTE == "000012346");
                Assert.True(envListR3000[1].TryGetValue("ENDERECO_OCORR_ENDERECO", out var ENDERECO_OCORR_ENDERECO1) && ENDERECO_OCORR_ENDERECO1 == "0001");
                Assert.True(envListR3000[1].TryGetValue("WHOST_FONTE", out var WHOST_FONTE) && WHOST_FONTE == "0005");


                #endregion*/

               /* #region R3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1

                var envListR3100_2 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envListR3100_2?.Count > 1);
                Assert.True(envListR3100_2[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3100_2) && PROPOFID_NUM_PROPOSTA_SIVPF_3100_2 == "000000000000001");
                Assert.True(envListR3100_2[1].TryGetValue("PROPOFID_DTQITBCO", out var PROPOFID_DTQITBCO_3100_2) && PROPOFID_DTQITBCO_3100_2 == "2020-01-01");
                Assert.True(envListR3100_2[1].TryGetValue("IMPMORNATU", out var IMPMORNATU_3100_2) && IMPMORNATU_3100_2 == "0000000000000.00");
                Assert.True(envListR3100_2[1].TryGetValue("PROPOFID_OPCAO_COBER", out var PROPOFID_OPCAO_COBER_3100_2) && PROPOFID_OPCAO_COBER_3100_2 == "1");
                Assert.True(envListR3100_2[1].TryGetValue("IMPMORACID", out var IMPMORACID_3100_2) && IMPMORACID_3100_2 == "0000000000007.00");
                Assert.True(envListR3100_2[1].TryGetValue("IMPINVPERM", out var IMPINVPERM_3100_2) && IMPINVPERM_3100_2 == "0000000000003.00");
                Assert.True(envListR3100_2[1].TryGetValue("IMPAMDS", out var IMPAMDS_3100_2) && IMPAMDS_3100_2 == "0000000000002.00");
                Assert.True(envListR3100_2[1].TryGetValue("IMPDH", out var IMPDH_3100_2) && IMPDH_3100_2 == "0000000000004.00");
                Assert.True(envListR3100_2[1].TryGetValue("IMPDIT", out var IMPDIT_3100_2) && IMPDIT_3100_2 == "0000000000003.00");
                Assert.True(envListR3100_2[1].TryGetValue("VLPREMIOTOT", out var VLPREMIOTOT_3100_2) && VLPREMIOTOT_3100_2 == "0000000000001.00");
                Assert.True(envListR3100_2[1].TryGetValue("PRMVG", out var PRMVG_3100_2) && PRMVG_3100_2 == "0000000000001.00");
                Assert.True(envListR3100_2[1].TryGetValue("PRMAP", out var PRMAP_3100_2) && PRMAP_3100_2 == "0000000000000.00");
                Assert.True(envListR3100_2[1].TryGetValue("QTTITCAP", out var QTTITCAP_3100_2) && QTTITCAP_3100_2 == "0012");
                Assert.True(envListR3100_2[1].TryGetValue("VLTITCAP", out var VLTITCAP_3100_2) && VLTITCAP_3100_2 == "0000000000120.00");
                Assert.True(envListR3100_2[1].TryGetValue("VLCUSTCAP", out var VLCUSTCAP_3100_2) && VLCUSTCAP_3100_2 == "0000000000090.00");
                Assert.True(envListR3100_2[1].TryGetValue("IMPSEGCDG", out var IMPSEGCDG_3100_2) && IMPSEGCDG_3100_2 == "0000000000015.00");
                Assert.True(envListR3100_2[1].TryGetValue("VLCUSTCDG", out var VLCUSTCDG_3100_2) && VLCUSTCDG_3100_2 == "0000000000010.00");
                Assert.True(envListR3100_2[1].TryGetValue("IMPSEGAUXF", out var IMPSEGAUXF_3100_2) && IMPSEGAUXF_3100_2 == "0000000000025.00");
                Assert.True(envListR3100_2[1].TryGetValue("VLCUSTAUXF", out var VLCUSTAUXF_3100_2) && VLCUSTAUXF_3100_2 == "0000000000018.00");
                Assert.True(envListR3100_2[1].TryGetValue("PRMDIT", out var PRMDIT_3100_2) && PRMDIT_3100_2 == "0000000000250.00");
                Assert.True(envListR3100_2[1].TryGetValue("QTDIT", out var QTDIT_3100_2) && QTDIT_3100_2 == "0008");

                #endregion*/

                /*#region R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1

                var envListR3130 = AppSettings.TestSet.DynamicData["R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3130?.Count > 1);
                Assert.True(envListR3130[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3130) && PROPOFID_NUM_PROPOSTA_SIVPF_3130 == "000000000000001");
                Assert.True(envListR3130[1].TryGetValue("VGPLAR_NUM_RAMO", out var VGPLAR_NUM_RAMO_3130) && VGPLAR_NUM_RAMO_3130 == "0003");
                Assert.True(envListR3130[1].TryGetValue("VGPLAR_NUM_COBERTURA", out var VGPLAR_NUM_COBERTURA_3130) && VGPLAR_NUM_COBERTURA_3130 == "0001");
                Assert.True(envListR3130[1].TryGetValue("VGPLAR_QTD_COBERTURA", out var VGPLAR_QTD_COBERTURA_3130) && VGPLAR_QTD_COBERTURA_3130 == "0001");
                Assert.True(envListR3130[1].TryGetValue("VGPLAR_IMPSEGURADA", out var VGPLAR_IMPSEGURADA_3130) && VGPLAR_IMPSEGURADA_3130 == "0000000000010.00");
                Assert.True(envListR3130[1].TryGetValue("VGPLAR_CUSTO", out var VGPLAR_CUSTO_3130) && VGPLAR_CUSTO_3130 == "0000000000050.00");
                Assert.True(envListR3130[1].TryGetValue("VGPLAR_PREMIO", out var VGPLAR_PREMIO_3130) && VGPLAR_PREMIO_3130 == "0000000000007.00");

                #endregion*/

                /*#region R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1

                var envListR3170 = AppSettings.TestSet.DynamicData["R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3170?.Count > 1);
                Assert.True(envListR3170[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3170) && PROPOFID_NUM_PROPOSTA_SIVPF_3170 == "000000000000001");
                Assert.True(envListR3170[1].TryGetValue("VGPLAA_NUM_ACESSORIO", out var VGPLAA_NUM_ACESSORIO_3170) && VGPLAA_NUM_ACESSORIO_3170 == "0001");
                Assert.True(envListR3170[1].TryGetValue("VGPLAA_QTD_COBERTURA", out var VGPLAA_QTD_COBERTURA_3170) && VGPLAA_QTD_COBERTURA_3170 == "0001");
                Assert.True(envListR3170[1].TryGetValue("VGPLAA_IMPSEGURADA", out var VGPLAA_IMPSEGURADA_3170) && VGPLAA_IMPSEGURADA_3170 == "0000000000001.00");
                Assert.True(envListR3170[1].TryGetValue("VGPLAA_CUSTO", out var VGPLAA_CUSTO_3170) && VGPLAA_CUSTO_3170 == "0000000000001.00");
                Assert.True(envListR3170[1].TryGetValue("VGPLAA_PREMIO", out var VGPLAA_PREMIO_3170) && VGPLAA_PREMIO_3170 == "0000000000001.00");

                #endregion*/

                /*#region R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

                var envListR3200 = AppSettings.TestSet.DynamicData["R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3200?.Count > 1);
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3200) && PROPOFID_NUM_PROPOSTA_SIVPF_3200 == "000000000000001");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_DTQITBCO", out var PROPOFID_DTQITBCO) && PROPOFID_DTQITBCO == "2020-01-01");
                Assert.True(envListR3200[1].TryGetValue("WHOST_OPCAOPAG", out var WHOST_OPCAOPAG) && WHOST_OPCAOPAG == "1");
                Assert.True(envListR3200[1].TryGetValue("PRODUVG_PERI_PAGAMENTO", out var PRODUVG_PERI_PAGAMENTO) && PRODUVG_PERI_PAGAMENTO == "2020");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_DIA_DEBITO", out var PROPOFID_DIA_DEBITO) && PROPOFID_DIA_DEBITO == "0001");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_AGECTADEB", out var PROPOFID_AGECTADEB) && PROPOFID_AGECTADEB == "0001");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_OPRCTADEB", out var PROPOFID_OPRCTADEB) && PROPOFID_OPRCTADEB == "0001");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_NUMCTADEB", out var PROPOFID_NUMCTADEB) && PROPOFID_NUMCTADEB == "0000000000001");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_DIGCTADEB", out var PROPOFID_DIGCTADEB) && PROPOFID_DIGCTADEB == "0001");

                #endregion*/

               /* #region R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1

                var envListR3210 = AppSettings.TestSet.DynamicData["R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3210?.Count > 1);
                Assert.True(envListR3210[1].TryGetValue("VG096_NUM_CERTIFICADO", out var VG096_NUM_CERTIFICADO) && VG096_NUM_CERTIFICADO == "000000000000001");
                Assert.True(envListR3210[1].TryGetValue("VG096_NUM_PARCELA", out var VG096_NUM_PARCELA) && VG096_NUM_PARCELA == "0001");
                Assert.True(envListR3210[1].TryGetValue("VG096_VLR_PARCELA", out var VG096_VLR_PARCELA) && VG096_VLR_PARCELA == "00000000001.00");
                Assert.True(envListR3210[1].TryGetValue("VG096_STA_REGISTRO", out var VG096_STA_REGISTRO) && VG096_STA_REGISTRO == "0");
                Assert.True(envListR3210[1].TryGetValue("VG096_COD_IDLG", out var VG096_COD_IDLG) && VG096_COD_IDLG == "                                        ");
                Assert.True(envListR3210[1].TryGetValue("VG096_COD_RETORNO", out var VG096_COD_RETORNO) && VG096_COD_RETORNO == "0000");
                Assert.True(envListR3210[1].TryGetValue("VG096_DES_RETORNO", out var VG096_DES_RETORNO) && VG096_DES_RETORNO == "                                                            ");
                Assert.True(envListR3210[1].TryGetValue("VG096_COD_CONVENIO", out var VG096_COD_CONVENIO) && VG096_COD_CONVENIO == "6088");
                Assert.True(envListR3210[1].TryGetValue("VG096_NUM_BANCO_DEBITO", out var VG096_NUM_BANCO_DEBITO) && VG096_NUM_BANCO_DEBITO == "0104");
                Assert.True(envListR3210[1].TryGetValue("VG096_NUM_AGENCIA_DEBITO", out var VG096_NUM_AGENCIA_DEBITO) && VG096_NUM_AGENCIA_DEBITO == "0001");
                Assert.True(envListR3210[1].TryGetValue("VG096_NUM_CONTA_DEBITO", out var VG096_NUM_CONTA_DEBITO) && VG096_NUM_CONTA_DEBITO == "000000011");
                Assert.True(envListR3210[1].TryGetValue("VG096_NOM_PROGRAMA", out var VG096_NOM_PROGRAMA) && VG096_NOM_PROGRAMA == "VP0601B   ");
                Assert.True(envListR3210[1].TryGetValue("VG096_DTA_PROXIMA_COBRANCA", out var VG096_DTA_PROXIMA_COBRANCA) && VG096_DTA_PROXIMA_COBRANCA == "2020010100");

                #endregion*/

               /* #region R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1

                var envListR3300 = AppSettings.TestSet.DynamicData["R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3300?.Count > 1);
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3300) && PROPOFID_NUM_PROPOSTA_SIVPF_3300 == "000000000000001");
                Assert.True(envListR3300[1].TryGetValue("WHOST_FONTE", out var WHOST_FONTE_3300) && WHOST_FONTE_3300 == "0005");
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_AGECOBR", out var PROPOFID_AGECOBR_3300) && PROPOFID_AGECOBR_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("RCAPS_VAL_RCAP", out var RCAPS_VAL_RCAP_3300) && RCAPS_VAL_RCAP_3300 == "0000000000027.00");
                Assert.True(envListR3300[1].TryGetValue("VAL_ADIANTAMENTO", out var VAL_ADIANTAMENTO_3300) && VAL_ADIANTAMENTO_3300 == "0000000000000.00");
                Assert.True(envListR3300[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO_3300) && SISTEMAS_DATA_MOV_ABERTO_3300 == "2020-01-01");
                Assert.True(envListR3300[1].TryGetValue("SIT_REGISTRO", out var SIT_REGISTRO_3300) && SIT_REGISTRO_3300 == "0");
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_AGECTAVEN", out var PROPOFID_AGECTAVEN_3300) && PROPOFID_AGECTAVEN_3300 == "0001");
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_OPRCTAVEN", out var PROPOFID_OPRCTAVEN_3300) && PROPOFID_OPRCTAVEN_3300 == "0001");
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_NUMCTAVEN", out var PROPOFID_NUMCTAVEN_3300) && PROPOFID_NUMCTAVEN_3300 == "0000000000001");
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_DIGCTAVEN", out var PROPOFID_DIGCTAVEN_3300) && PROPOFID_DIGCTAVEN_3300 == "0001");
                Assert.True(envListR3300[1].TryGetValue("PROPOFID_NRMATRVEN", out var PROPOFID_NRMATRVEN_3300) && PROPOFID_NRMATRVEN_3300 == "000000000000010");
                Assert.True(envListR3300[1].TryGetValue("SIT_FENAE", out var SIT_FENAE_3300) && SIT_FENAE_3300 == " ");
                Assert.True(envListR3300[1].TryGetValue("VAL_COMISSAO_VEN", out var VAL_COMISSAO_VEN_3300) && VAL_COMISSAO_VEN_3300 == "0000000000000.00");
                Assert.True(envListR3300[1].TryGetValue("PROPSSVD_NUM_APOLICE", out var PROPSSVD_NUM_APOLICE_3300) && PROPSSVD_NUM_APOLICE_3300 == "0000000000001");
                Assert.True(envListR3300[1].TryGetValue("PROPSSVD_COD_SUBGRUPO", out var PROPSSVD_COD_SUBGRUPO_3300) && PROPSSVD_COD_SUBGRUPO_3300 == "0077");
                Assert.True(envListR3300[1].TryGetValue("ORDEM_PAGAMENTO", out var ORDEM_PAGAMENTO_3300) && ORDEM_PAGAMENTO_3300 == "000000000");
                Assert.True(envListR3300[1].TryGetValue("NUM_ENDOSSO", out var NUM_ENDOSSO_3300) && NUM_ENDOSSO_3300 == "000000000");
                Assert.True(envListR3300[1].TryGetValue("NUM_MATR_GERENTE", out var NUM_MATR_GERENTE_3300) && NUM_MATR_GERENTE_3300 == "000000000000000");
                Assert.True(envListR3300[1].TryGetValue("COD_AGEN_GERENTE", out var COD_AGEN_GERENTE_3300) && COD_AGEN_GERENTE_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("OPE_CONTA_GERENTE", out var OPE_CONTA_GERENTE_3300) && OPE_CONTA_GERENTE_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("NUM_CONTA_GERENTE", out var NUM_CONTA_GERENTE_3300) && NUM_CONTA_GERENTE_3300 == "0000000000000");
                Assert.True(envListR3300[1].TryGetValue("DIG_CONTA_GERENTE", out var DIG_CONTA_GERENTE_3300) && DIG_CONTA_GERENTE_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("VAL_COMIS_GERENTE", out var VAL_COMIS_GERENTE_3300) && VAL_COMIS_GERENTE_3300 == "0000000000000.00");
                Assert.True(envListR3300[1].TryGetValue("NUM_MATR_SUN", out var NUM_MATR_SUN_3300) && NUM_MATR_SUN_3300 == "000000000000000");
                Assert.True(envListR3300[1].TryGetValue("COD_AGEN_SUN", out var COD_AGEN_SUN_3300) && COD_AGEN_SUN_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("OPE_CONTA_SUN", out var OPE_CONTA_SUN_3300) && OPE_CONTA_SUN_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("NUM_CONTA_SUN", out var NUM_CONTA_SUN_3300) && NUM_CONTA_SUN_3300 == "0000000000000");
                Assert.True(envListR3300[1].TryGetValue("DIG_CONTA_SUN", out var DIG_CONTA_SUN_3300) && DIG_CONTA_SUN_3300 == "0000");
                Assert.True(envListR3300[1].TryGetValue("VAL_COMIS_SUN", out var VAL_COMIS_SUN_3300) && VAL_COMIS_SUN_3300 == "0000000000000.00");

                #endregion*/

               /* #region R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1

                var envListR3400 = AppSettings.TestSet.DynamicData["R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3400?.Count > 1);
                Assert.True(envListR3400[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3400) && PROPOFID_NUM_PROPOSTA_SIVPF_3400 == "000000000000001");
                Assert.True(envListR3400[1].TryGetValue("NUM_PARCELA", out var NUM_PARCELA_3400) && NUM_PARCELA_3400 == "0001");
                Assert.True(envListR3400[1].TryGetValue("PROPOFID_DTQITBCO", out var PROPOFID_DTQITBCO_3400) && PROPOFID_DTQITBCO_3400 == "2020-01-01");
                Assert.True(envListR3400[1].TryGetValue("RCAPS_VAL_RCAP", out var RCAPS_VAL_RCAP_3400) && RCAPS_VAL_RCAP_3400 == "0000000000027.00");
                Assert.True(envListR3400[1].TryGetValue("PREMIO_AP", out var PREMIO_AP_3400) && PREMIO_AP_3400 == "0000000000000.00");
                Assert.True(envListR3400[1].TryGetValue("VLMULTA", out var VLMULTA_3400) && VLMULTA_3400 == "0000000000000.00");
                Assert.True(envListR3400[1].TryGetValue("WHOST_OPCAOPAG", out var WHOST_OPCAOPAG_3400) && WHOST_OPCAOPAG_3400 == "1");
                Assert.True(envListR3400[1].TryGetValue("SIT_REGISTRO", out var SIT_REGISTRO_3400) && SIT_REGISTRO_3400 == "1");
                Assert.True(envListR3400[1].TryGetValue("OCORR_HISTORICO", out var OCORR_HISTORICO_3400) && OCORR_HISTORICO_3400 == "0000");

                #endregion*/

                /*#region R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

                var envListR3500 = AppSettings.TestSet.DynamicData["R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3500?.Count > 1);
                Assert.True(envListR3500[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3500) && PROPOFID_NUM_PROPOSTA_SIVPF_3500 == "000000000000001");
                Assert.True(envListR3500[1].TryGetValue("NUM_PARCELA", out var NUM_PARCELA_3500) && NUM_PARCELA_3500 == "0001");
                Assert.True(envListR3500[1].TryGetValue("NUM_TITULO", out var NUM_TITULO_3500) && NUM_TITULO_3500 == "0000000000001");
                Assert.True(envListR3500[1].TryGetValue("WS_DATA_QUITACAO", out var WS_DATA_QUITACAO_3500) && WS_DATA_QUITACAO_3500 == "2020-01-01");
                Assert.True(envListR3500[1].TryGetValue("RCAPS_VAL_RCAP", out var RCAPS_VAL_RCAP_3500) && RCAPS_VAL_RCAP_3500 == "0000000000027.00");
                Assert.True(envListR3500[1].TryGetValue("WHOST_OPCAOPAG", out var WHOST_OPCAOPAG_3500) && WHOST_OPCAOPAG_3500 == "1");
                Assert.True(envListR3500[1].TryGetValue("SIT_REGISTRO", out var SIT_REGISTRO_3500) && SIT_REGISTRO_3500 == "1");
                Assert.True(envListR3500[1].TryGetValue("COD_OPERACAO", out var COD_OPERACAO_3500) && COD_OPERACAO_3500 == "0201");
                Assert.True(envListR3500[1].TryGetValue("OCORR_HISTORICO", out var OCORR_HISTORICO_3500) && OCORR_HISTORICO_3500 == "0001");
                Assert.True(envListR3500[1].TryGetValue("COD_DEVOLUCAO", out var COD_DEVOLUCAO_3500) && COD_DEVOLUCAO_3500 == "0000");
                Assert.True(envListR3500[1].TryGetValue("RCAPCOMP_BCO_AVISO", out var RCAPCOMP_BCO_AVISO_3500) && RCAPCOMP_BCO_AVISO_3500 == "0001");
                Assert.True(envListR3500[1].TryGetValue("RCAPCOMP_AGE_AVISO", out var RCAPCOMP_AGE_AVISO_3500) && RCAPCOMP_AGE_AVISO_3500 == "0002");
                Assert.True(envListR3500[1].TryGetValue("RCAPCOMP_NUM_AVISO_CREDITO", out var RCAPCOMP_NUM_AVISO_CREDITO_3500) && RCAPCOMP_NUM_AVISO_CREDITO_3500 == "000000003");
                Assert.True(envListR3500[1].TryGetValue("NUM_TITULO_COMP", out var NUM_TITULO_COMP_3500) && NUM_TITULO_COMP_3500 == "0000000000000");

                #endregion*/

                /*#region R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

                var envListR3600 = AppSettings.TestSet.DynamicData["R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3600?.Count > 1);
                Assert.True(envListR3600[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3600) && PROPOFID_NUM_PROPOSTA_SIVPF_3600 == "000000000000001");
                Assert.True(envListR3600[1].TryGetValue("NUM_PARCELA", out var NUM_PARCELA_3600) && NUM_PARCELA_3600 == "0001");
                Assert.True(envListR3600[1].TryGetValue("NUM_TITULO", out var NUM_TITULO_3600) && NUM_TITULO_3600 == "0000000000001");
                Assert.True(envListR3600[1].TryGetValue("OCORR_HISTORICO", out var OCORR_HISTORICO_3600) && OCORR_HISTORICO_3600 == "0001");
                Assert.True(envListR3600[1].TryGetValue("PROPSSVD_NUM_APOLICE", out var PROPSSVD_NUM_APOLICE_3600) && PROPSSVD_NUM_APOLICE_3600 == "0000000000001");
                Assert.True(envListR3600[1].TryGetValue("PROPSSVD_COD_SUBGRUPO", out var PROPSSVD_COD_SUBGRUPO_3600) && PROPSSVD_COD_SUBGRUPO_3600 == "0077");
                Assert.True(envListR3600[1].TryGetValue("WHOST_FONTE", out var WHOST_FONTE_3600) && WHOST_FONTE_3600 == "0005");
                Assert.True(envListR3600[1].TryGetValue("NUM_ENDOSSO", out var NUM_ENDOSSO_3600) && NUM_ENDOSSO_3600 == "000000000");
                Assert.True(envListR3600[1].TryGetValue("RCAPS_VAL_RCAP", out var RCAPS_VAL_RCAP_3600) && RCAPS_VAL_RCAP_3600 == "0000000000027.00");
                Assert.True(envListR3600[1].TryGetValue("PREMIO_AP", out var PREMIO_AP_3600) && PREMIO_AP_3600 == "0000000000000.00");
                Assert.True(envListR3600[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO_3600) && SISTEMAS_DATA_MOV_ABERTO_3600 == "2020-01-01");
                Assert.True(envListR3600[1].TryGetValue("SIT_REGISTRO", out var SIT_REGISTRO_3600) && SIT_REGISTRO_3600 == "0");
                Assert.True(envListR3600[1].TryGetValue("COD_OPERACAO", out var COD_OPERACAO_3600) && COD_OPERACAO_3600 == "0201");
                Assert.True(envListR3600[1].TryGetValue("DTFATUR", out var DTFATUR_3600) && DTFATUR_3600 == "          ");

                #endregion*/

               /* #region R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

                var envListR5635 = AppSettings.TestSet.DynamicData["R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR5635?.Count > 1);
                Assert.True(envListR5635[1].TryGetValue("PROPOFID_DATA_NASC_CONJUGE", out var PROPOFID_DATA_NASC_CONJUGE_5635) && PROPOFID_DATA_NASC_CONJUGE_5635 == "2020-01-01");
                Assert.True(envListR5635[1].TryGetValue("VIND_DATA_NASC_CONJUGE", out var VIND_DATA_NASC_CONJUGE_5635) && VIND_DATA_NASC_CONJUGE_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("PROPOFID_CGC_CONVENENTE", out var PROPOFID_CGC_CONVENENTE_5635) && PROPOFID_CGC_CONVENENTE_5635 == "00000000000001");
                Assert.True(envListR5635[1].TryGetValue("VIND_CGC_CONVENENTE", out var VIND_CGC_CONVENENTE_5635) && VIND_CGC_CONVENENTE_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("PROPOFID_NOME_CONJUGE", out var PROPOFID_NOME_CONJUGE_5635) && PROPOFID_NOME_CONJUGE_5635 == "1                                       ");
                Assert.True(envListR5635[1].TryGetValue("VIND_NOME_CONJUGE", out var VIND_NOME_CONJUGE_5635) && VIND_NOME_CONJUGE_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("WHOST_PROFISSAO_CONJUGE", out var WHOST_PROFISSAO_CONJUGE_5635) && WHOST_PROFISSAO_CONJUGE_5635 == "                    ");
                Assert.True(envListR5635[1].TryGetValue("VIND_PROFISSAO_CONJUGE", out var VIND_PROFISSAO_CONJUGE_5635) && VIND_PROFISSAO_CONJUGE_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("PROPSSVD_COD_OPER_CREDITO", out var PROPSSVD_COD_OPER_CREDITO_5635) && PROPSSVD_COD_OPER_CREDITO_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("VIND_COD_OPER_CRED", out var VIND_COD_OPER_CRED_5635) && VIND_COD_OPER_CRED_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("PROPSSVD_COD_CORRESP_BANC", out var PROPSSVD_COD_CORRESP_BANC_5635) && PROPSSVD_COD_CORRESP_BANC_5635 == "000000001");
                Assert.True(envListR5635[1].TryGetValue("VIND_COD_CORRESP", out var VIND_COD_CORRESP_5635) && VIND_COD_CORRESP_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("PROPSSVD_NUM_CONTR_VINCULO", out var PROPSSVD_NUM_CONTR_VINCULO_5635) && PROPSSVD_NUM_CONTR_VINCULO_5635 == "000000000000000001");
                Assert.True(envListR5635[1].TryGetValue("VIND_NUM_CONTR", out var VIND_NUM_CONTR_5635) && VIND_NUM_CONTR_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("PROPSSVD_NUM_PRAZO_FIN", out var PROPSSVD_NUM_PRAZO_FIN_5635) && PROPSSVD_NUM_PRAZO_FIN_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("VIND_NUM_PRAZO", out var VIND_NUM_PRAZO_5635) && VIND_NUM_PRAZO_5635 == "0000");
                Assert.True(envListR5635[1].TryGetValue("ENDERECO_OCORR_ENDERECO", out var ENDERECO_OCORR_ENDERECO_5635) && ENDERECO_OCORR_ENDERECO_5635 == "0001");
                Assert.True(envListR5635[1].TryGetValue("PROPOFID_ORIGEM_PROPOSTA", out var PROPOFID_ORIGEM_PROPOSTA_5635) && PROPOFID_ORIGEM_PROPOSTA_5635 == "0077");
                Assert.True(envListR5635[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE_5635) && COD_CLIENTE_5635 == "000000001");
                Assert.True(envListR5635[1].TryGetValue("WHOST_SIT_REGISTRO", out var WHOST_SIT_REGISTRO_5635) && WHOST_SIT_REGISTRO_5635 == "9");
                Assert.True(envListR5635[1].TryGetValue("WHOST_INFO_COMPL", out var WHOST_INFO_COMPL_5635) && WHOST_INFO_COMPL_5635 == "Cliente                                           ");
                Assert.True(envListR5635[1].TryGetValue("WHOST_PROFISSAO", out var WHOST_PROFISSAO_5635) && WHOST_PROFISSAO_5635 == "An                  ");
                Assert.True(envListR5635[1].TryGetValue("WHOST_DTPROXVEN", out var WHOST_DTPROXVEN_5635) && WHOST_DTPROXVEN_5635 == "9999-12-31");
                Assert.True(envListR5635[1].TryGetValue("WHOST_FONTE", out var WHOST_FONTE_5635) && WHOST_FONTE_5635 == "0005");
                Assert.True(envListR5635[1].TryGetValue("WHOST_IDADE", out var WHOST_IDADE_5635) && WHOST_IDADE_5635 == "0029");
                Assert.True(envListR5635[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_5635) && PROPOFID_NUM_PROPOSTA_SIVPF_5635 == "000000000000001");

                #endregion*/

                /*#region R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1

                var envListR9450 = AppSettings.TestSet.DynamicData["R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR9450?.Count > 1);
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_OCORR_ENDERECO", out var GECLIMOV_OCORR_ENDERECO_9450) && GECLIMOV_OCORR_ENDERECO_9450 == "0090");
                Assert.True(envListR9450[1].TryGetValue("VIND_OCORR_END", out var VIND_OCORR_END_9450) && VIND_OCORR_END_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_TIPO_PESSOA", out var GECLIMOV_TIPO_PESSOA_9450) && GECLIMOV_TIPO_PESSOA_9450 == "F");
                Assert.True(envListR9450[1].TryGetValue("VIND_TIPO_PESSOA", out var VIND_TIPO_PESSOA_9450) && VIND_TIPO_PESSOA_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_ESTADO_CIVIL", out var GECLIMOV_ESTADO_CIVIL_9450) && GECLIMOV_ESTADO_CIVIL_9450 == "S");
                Assert.True(envListR9450[1].TryGetValue("VIND_EST_CIVIL", out var VIND_EST_CIVIL_9450) && VIND_EST_CIVIL_9450 == "-001");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_DATA_NASCIMENTO", out var GECLIMOV_DATA_NASCIMENTO_9450) && GECLIMOV_DATA_NASCIMENTO_9450 == "1990-05-20");
                Assert.True(envListR9450[1].TryGetValue("VIND_DTNASC", out var VIND_DTNASC_9450) && VIND_DTNASC_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_NOME_RAZAO", out var GECLIMOV_NOME_RAZAO_9450) && GECLIMOV_NOME_RAZAO_9450 == "Carlos Eduardo Lima                     ");
                Assert.True(envListR9450[1].TryGetValue("VIND_NOME_RAZAO", out var VIND_NOME_RAZAO_9450) && VIND_NOME_RAZAO_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_IDE_SEXO", out var GECLIMOV_IDE_SEXO_9450) && GECLIMOV_IDE_SEXO_9450 == "M");
                Assert.True(envListR9450[1].TryGetValue("VIND_IDE_SEXO", out var VIND_IDE_SEXO_9450) && VIND_IDE_SEXO_9450 == "-001");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_ENDERECO", out var GECLIMOV_ENDERECO_9450) && GECLIMOV_ENDERECO_9450 == "1                                                                       ");
                Assert.True(envListR9450[1].TryGetValue("VIND_ENDERECO", out var VIND_ENDERECO_9450) && VIND_ENDERECO_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_SIGLA_UF", out var GECLIMOV_SIGLA_UF_9450) && GECLIMOV_SIGLA_UF_9450 == "SP");
                Assert.True(envListR9450[1].TryGetValue("VIND_SIGLA_UF", out var VIND_SIGLA_UF_9450) && VIND_SIGLA_UF_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_TELEFONE", out var GECLIMOV_TELEFONE_9450) && GECLIMOV_TELEFONE_9450 == "000000009");
                Assert.True(envListR9450[1].TryGetValue("VIND_TELEFONE", out var VIND_TELEFONE_9450) && VIND_TELEFONE_9450 == "-001");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_BAIRRO", out var GECLIMOV_BAIRRO_9450) && GECLIMOV_BAIRRO_9450 == "1                                                                       ");
                Assert.True(envListR9450[1].TryGetValue("VIND_BAIRRO", out var VIND_BAIRRO_9450) && VIND_BAIRRO_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_CIDADE", out var GECLIMOV_CIDADE_9450) && GECLIMOV_CIDADE_9450 == "1                                                                       ");
                Assert.True(envListR9450[1].TryGetValue("VIND_CIDADE", out var VIND_CIDADE_9450) && VIND_CIDADE_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_CGCCPF", out var GECLIMOV_CGCCPF_9450) && GECLIMOV_CGCCPF_9450 == "000000000000012");
                Assert.True(envListR9450[1].TryGetValue("VIND_CGCCPF", out var VIND_CGCCPF_9450) && VIND_CGCCPF_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_DATA_ULT_MANUTEN", out var GECLIMOV_DATA_ULT_MANUTEN_9450) && GECLIMOV_DATA_ULT_MANUTEN_9450 == "2025-05-01");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_TIPO_MOVIMENTO", out var GECLIMOV_TIPO_MOVIMENTO_9450) && GECLIMOV_TIPO_MOVIMENTO_9450 == "I");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_CEP", out var GECLIMOV_CEP_9450) && GECLIMOV_CEP_9450 == "000000001");
                Assert.True(envListR9450[1].TryGetValue("VIND_CEP", out var VIND_CEP_9450) && VIND_CEP_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_DDD", out var GECLIMOV_DDD_9450) && GECLIMOV_DDD_9450 == "0011");
                Assert.True(envListR9450[1].TryGetValue("VIND_DDD", out var VIND_DDD_9450) && VIND_DDD_9450 == "-001");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_FAX", out var GECLIMOV_FAX_9450) && GECLIMOV_FAX_9450 == "023456789");
                Assert.True(envListR9450[1].TryGetValue("VIND_FAX", out var VIND_FAX_9450) && VIND_FAX_9450 == "0000");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_COD_USUARIO", out var GECLIMOV_COD_USUARIO_9450) && GECLIMOV_COD_USUARIO_9450 == "VP0601B ");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_COD_CLIENTE", out var GECLIMOV_COD_CLIENTE_9450) && GECLIMOV_COD_CLIENTE_9450 == "000012346");
                Assert.True(envListR9450[1].TryGetValue("GECLIMOV_OCORR_HIST", out var GECLIMOV_OCORR_HIST_9450) && GECLIMOV_OCORR_HIST_9450 == "0001");

                #endregion*/

                /* #region R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

                var envListR1700 = AppSettings.TestSet.DynamicData["R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envListR1700?.Count > 1);
                Assert.True(envListR1700[1].TryGetValue("RCAPCOMP_DATA_MOVIMENTO", out var RCAPCOMP_DATA_MOVIMENTO) && RCAPCOMP_DATA_MOVIMENTO == "2025-04-25");
                Assert.True(envListR1700[1].TryGetValue("RCAPCOMP_DATA_RCAP", out var RCAPCOMP_DATA_RCAP) && RCAPCOMP_DATA_RCAP == "2025-04-26");
                Assert.True(envListR1700[1].TryGetValue("PROPOFID_VAL_PAGO", out var PROPOFID_VAL_PAGO) && PROPOFID_VAL_PAGO == "0000000000012.00");
                Assert.True(envListR1700[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF4) && PROPOFID_NUM_PROPOSTA_SIVPF4 == "000000000000123");

                #endregion
                */

                /*     
                #region R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

                var envListR3200 = AppSettings.TestSet.DynamicData["R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR3200?.Count > 1);
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3200) && PROPOFID_NUM_PROPOSTA_SIVPF_3200 == "000000000000123");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_DTQITBCO", out var PROPOFID_DTQITBCO_3200) && PROPOFID_DTQITBCO_3200 == "2020-01-01");
                Assert.True(envListR3200[1].TryGetValue("WHOST_OPCAOPAG", out var WHOST_OPCAOPAG_3200) && WHOST_OPCAOPAG_3200 == "1");
                Assert.True(envListR3200[1].TryGetValue("PRODUVG_PERI_PAGAMENTO", out var PRODUVG_PERI_PAGAMENTO_3200) && PRODUVG_PERI_PAGAMENTO_3200 == "2020");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_DIA_DEBITO", out var PROPOFID_DIA_DEBITO_3200) && PROPOFID_DIA_DEBITO_3200 == "0017");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_AGECTADEB", out var PROPOFID_AGECTADEB_3200) && PROPOFID_AGECTADEB_3200 == "0019");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_OPRCTADEB", out var PROPOFID_OPRCTADEB_3200) && PROPOFID_OPRCTADEB_3200 == "0023");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_NUMCTADEB", out var PROPOFID_NUMCTADEB_3200) && PROPOFID_NUMCTADEB_3200 == "0000000000021");
                Assert.True(envListR3200[1].TryGetValue("PROPOFID_DIGCTADEB", out var PROPOFID_DIGCTADEB_3200) && PROPOFID_DIGCTADEB_3200 == "0022");

                #endregion
               */
              

                /* #region R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

                 var envListR3100_1 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                 Assert.True(envListR3100_1?.Count > 1);
                 Assert.True(envListR3100_1[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF_3100_1) && PROPOFID_NUM_PROPOSTA_SIVPF_3100_1 == "000000000000123");
                 Assert.True(envListR3100_1[1].TryGetValue("PROPOFID_DTQITBCO", out var PROPOFID_DTQITBCO_3100_1) && PROPOFID_DTQITBCO_3100_1 == "2020-01-01");
                 Assert.True(envListR3100_1[1].TryGetValue("WS_VALOR_IS_CDC", out var WS_VALOR_IS_CDC_3100_1) && WS_VALOR_IS_CDC_3100_1 == "0000000000200");
                 Assert.True(envListR3100_1[1].TryGetValue("PROPOFID_OPCAO_COBER", out var PROPOFID_OPCAO_COBER_3100_1) && PROPOFID_OPCAO_COBER_3100_1 == "0000000000200.00");
                 Assert.True(envListR3100_1[1].TryGetValue("IMPINVPERM", out var IMPINVPERM_3100_1) && IMPINVPERM_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("IMPAMDS", out var IMPAMDS_3100_1) && IMPAMDS_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("IMPDH", out var IMPDH_3100_1) && IMPDH_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("IMPDIT", out var IMPDIT_3100_1) && IMPDIT_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("VLPREMIOTOT", out var VLPREMIOTOT_3100_1) && VLPREMIOTOT_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("PRMVG", out var PRMVG_3100_1) && PRMVG_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("PRMAP", out var PRMAP_3100_1) && PRMAP_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("QTTITCAP", out var QTTITCAP_3100_1) && QTTITCAP_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("VLTITCAP", out var VLTITCAP_3100_1) && VLTITCAP_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("VLCUSTCAP", out var VLCUSTCAP_3100_1) && VLCUSTCAP_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("IMPSEGCDG", out var IMPSEGCDG_3100_1) && IMPSEGCDG_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("VLCUSTCDG", out var VLCUSTCDG_3100_1) && VLCUSTCDG_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("IMPSEGAUXF", out var IMPSEGAUXF_3100_1) && IMPSEGAUXF_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("VLCUSTAUXF", out var VLCUSTAUXF_3100_1) && VLCUSTAUXF_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("PRMDIT", out var PRMDIT_3100_1) && PRMDIT_3100_1 == "");
                 Assert.True(envListR3100_1[1].TryGetValue("QTDIT", out var QTDIT_3100_1) && QTDIT_3100_1 == "");

                 #endregion
                */

                /*
                 #region R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1

                 var envList1 = AppSettings.TestSet.DynamicData["R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1"].DynamicList;
                 Assert.True(envList1?.Count > 1);
                 Assert.True(envList1[1].TryGetValue("PROPOFID_AGEPGTO", out var PROPOFID_AGEPGTO) && PROPOFID_AGEPGTO == "0001");
                 Assert.True(envList1[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF1) && PROPOFID_NUM_PROPOSTA_SIVPF1 == "000000000000000");

                 #endregion*/

             
                /*
                #region R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1

                var envListR2310 = AppSettings.TestSet.DynamicData["R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envListR2310?.Count > 1);
                Assert.True(envListR2310[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE) && COD_CLIENTE == "000001");
                Assert.True(envListR2310[1].TryGetValue("PESSOJUR_NOME_FANTASIA", out var PESSOJUR_NOME_FANTASIA) && PESSOJUR_NOME_FANTASIA == "EMPRESA X");
                Assert.True(envListR2310[1].TryGetValue("PESSOJUR_CGC", out var PESSOJUR_CGC) && PESSOJUR_CGC == "12345678000199");
                Assert.True(envListR2310[1].TryGetValue("DATA_NASCIMENTO", out var DATA_NASCIMENTO) && DATA_NASCIMENTO == "19900101");

                #endregion*/


                /*#region R2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1

                var envListR2315_2 = AppSettings.TestSet.DynamicData["R2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envListR2315_2?.Count > 1);
                Assert.True(envListR2315_2[1].TryGetValue("GEDOCCLI_COD_CLIENTE", out var GEDOCCLI_COD_CLIENTE2) && GEDOCCLI_COD_CLIENTE2 == "000002");
                Assert.True(envListR2315_2[1].TryGetValue("GEDOCCLI_COD_IDENTIFICACAO", out var GEDOCCLI_COD_IDENTIFICACAO) && GEDOCCLI_COD_IDENTIFICACAO == "RG");
                Assert.True(envListR2315_2[1].TryGetValue("GEDOCCLI_NOM_ORGAO_EXP", out var GEDOCCLI_NOM_ORGAO_EXP) && GEDOCCLI_NOM_ORGAO_EXP == "SSP");
                Assert.True(envListR2315_2[1].TryGetValue("GEDOCCLI_DTH_EXPEDICAO", out var GEDOCCLI_DTH_EXPEDICAO) && GEDOCCLI_DTH_EXPEDICAO == "20000101");
                Assert.True(envListR2315_2[1].TryGetValue("GEDOCCLI_COD_UF", out var GEDOCCLI_COD_UF) && GEDOCCLI_COD_UF == "SP");

                #endregion*/

                /*
                  #region R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1

                  var envListR2520 = AppSettings.TestSet.DynamicData["R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
                  Assert.True(envListR2520?.Count > 1);
                  Assert.True(envListR2520[1].TryGetValue("COD_CLIENTE", out var COD_CLIENTE5) && COD_CLIENTE5 == "000002");
                  Assert.True(envListR2520[1].TryGetValue("CLIENEMA_SEQ_EMAIL", out var CLIENEMA_SEQ_EMAIL) && CLIENEMA_SEQ_EMAIL == "1");
                  Assert.True(envListR2520[1].TryGetValue("WHOST_EMAIL", out var WHOST_EMAIL2) && WHOST_EMAIL2 == "joao@email.com");

                  #endregion
                */


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VP0601B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                GEJVS002_Tests.Load_Parameters();
                #region GEJVS002_GE074_CURSOR

                var q100 = new DynamicData();
                q100.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , "2020-10-10"},
                { "PARAMGER_DATA_TERVIGENCIA" , "2020-10-10"},
                { "PARAMGER_COD_MOEDA" , "1"},
                { "PARAMGER_COD_BANCO" , "2"},
                { "PARAMGER_COD_AGENCIA" , "3"},
                { "PARAMGER_OPCAO_BANCO" , "4"},
                { "PARAMGER_DIF_PREMIOS" , "5"},
                { "PARAMGER_FAIXA_APOL_MANUAL" , "6"},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , "7"},
                { "PARAMGER_DATA_FATURAVG_AUT" , "2020-10-10"},
                { "PARAMGER_CAPITAL_SOCIAL" , "8"},
                { "PARAMGER_CAPITAL_REALIZADO" , "9"},
                { "PARAMGER_CAPITAL_VINCULADO" , "10"},
                { "PARAMGER_ULT_AVISO_CREDITO" , "11"},
                { "PARAMGER_CODIGO_LIDER" , "12"},
                { "PARAMGER_NUM_RELACAO" , "123"},
                { "PARAMGER_COD_EMPRESA" , "1"},
                { "PARAMGER_COD_CGCCPF" , "12345"},
                { "PARAMGER_COD_EMPRESA_CAP" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("GEJVS002_GE074_CURSOR");
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q100);

                #endregion

                CT0006S_Tests.Load_Parameters();
                #region R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1

                var q101 = new DynamicData();
                q101.AddDynamic(new Dictionary<string, string>{
                { "GE353_COD_INI_FAIXA_CEP" , "1"},
                { "GE353_COD_FIM_FAIXA_CEP" , "2"},
                { "GE353_NOM_UNIDADE_OPER" , "X"},
                { "GE353_NOM_CENTRALIZADOR" , "X"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1", q101);

                #endregion

                #region R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1

                var q102 = new DynamicData();
                q102.AddDynamic(new Dictionary<string, string>{
                { "GE332_COD_INI_CEP" , "1"},
                { "GE332_COD_FIM_CEP" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1", q102);

                #endregion

                #region R1110_10_SELECT_GE318_DB_SELECT_1_Query1

                var q103 = new DynamicData();
                q103.AddDynamic(new Dictionary<string, string>{
                { "GE318_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_10_SELECT_GE318_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_10_SELECT_GE318_DB_SELECT_1_Query1", q103);

                #endregion

                #region R1110_10_SELECT_GE318_DB_SELECT_2_Query1

                var q104 = new DynamicData();
                q104.AddDynamic(new Dictionary<string, string>{
                { "GE318_IND_TP_LOGRADOURO" , "1"},
                { "GE318_NOM_LOGRADOURO" , "X1"},
                { "GE329_NOM_BAIRRO" , "X2"},
                { "GE324_NOM_LOCALIDADE" , "X3"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_10_SELECT_GE318_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_10_SELECT_GE318_DB_SELECT_2_Query1", q104);

                #endregion

                #region R1110_20_SELECT_GE321_DB_SELECT_1_Query1

                var q105 = new DynamicData();
                q105.AddDynamic(new Dictionary<string, string>{
                { "GE321_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_20_SELECT_GE321_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_20_SELECT_GE321_DB_SELECT_1_Query1", q105);

                #endregion

                #region R1110_20_SELECT_GE321_DB_SELECT_2_Query1

                var q106 = new DynamicData();
                q106.AddDynamic(new Dictionary<string, string>{
                { "GE321_NOM_TP_LOGRADOURO" , "X1"},
                { "GE321_NOM_LOGRADOURO" , "X2"},
                { "GE329_NOM_BAIRRO" , "X3"},
                { "GE324_NOM_LOCALIDADE" , "X4"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_20_SELECT_GE321_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_20_SELECT_GE321_DB_SELECT_2_Query1", q106);

                #endregion

                #region R1110_30_SELECT_GE322_DB_SELECT_1_Query1

                var q107 = new DynamicData();
                q107.AddDynamic(new Dictionary<string, string>{
                { "GE322_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_30_SELECT_GE322_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_30_SELECT_GE322_DB_SELECT_1_Query1", q107);

                #endregion

                #region R1110_30_SELECT_GE322_DB_SELECT_2_Query1

                var q108 = new DynamicData();
                q108.AddDynamic(new Dictionary<string, string>{
                { "GE322_NOM_TP_LOGRADOURO" , "X1"},
                { "GE322_NOM_LOGRADOURO" , "X2"},
                { "GE329_NOM_BAIRRO" , "X3"},
                { "GE324_NOM_LOCALIDADE" , "X4"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_30_SELECT_GE322_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_30_SELECT_GE322_DB_SELECT_2_Query1", q108);

                #endregion

                #region R1110_40_SELECT_GE326_DB_SELECT_1_Query1

                var q109 = new DynamicData();
                q109.AddDynamic(new Dictionary<string, string>{
                { "GE326_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_40_SELECT_GE326_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_40_SELECT_GE326_DB_SELECT_1_Query1", q109);

                #endregion

                #region R1110_50_SELECT_GE324_DB_SELECT_1_Query1

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "GE324_COD_UF" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1110_50_SELECT_GE324_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1110_50_SELECT_GE324_DB_SELECT_1_Query1", q110);

                #endregion


                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0100_00_INICIALIZA_DB_SELECT_2_Query1

                var q1 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R0100_00_INICIALIZA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_2_Query1", q1);

                #endregion

                #region VP0601B_CPROPOSTA

                var q2 = new DynamicData();  
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CPROPOSTA");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CPROPOSTA", q2);

                #endregion

                #region VP0601B_C01_RCAPCOMP

                var q3 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("VP0601B_C01_RCAPCOMP");
                AppSettings.TestSet.DynamicData.Add("VP0601B_C01_RCAPCOMP", q3);

                #endregion

                #region R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q4 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_PROPOSTA_AZUL" , "123456" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1", q7);

                #endregion            

                #region R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1

                var q9 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "ESTIPULA_NOME_ESTIPULANTE" , "João Silva" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q10);


                #endregion

                #region R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "001" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "12345" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "67890" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "1" },
                { "OPCPAGVI_NUM_CARTAO_CREDITO" , "1234 5678 9012 3456" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , "5000" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q14);

                #endregion

                #region R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU" , "2000" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , "1500" },
                { "IMPMORACID" , "750" },
                { "IMPINVPERM" , "300" },
                { "IMPAMDS" , "200" },
                { "IMPDH" , "400" },
                { "IMPDIT" , "350" },
                { "VLPREMIOTOT" , "1300" },
                { "PRMVG" , "120" },
                { "PRMAP" , "60" },
                { "TAXAVG" , "5" },
                { "COD_PLANO" , "P100" },
                { "QTTITCAP" , "12" },
                { "VLTITCAP" , "120" },
                { "VLCUSTCAP" , "90" },
                { "IMPSEGCDG" , "15" },
                { "VLCUSTCDG" , "10" },
                { "IMPSEGAUXF" , "25" },
                { "VLCUSTAUXF" , "18" },
                { "PRMDIT" , "250" },
                { "QTDIT" , "8" },
                { "FAIXA_SAL_FIM" , "5000" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "WHOST_IMPMORNATU_MAX" , "8000" }
                });
                AppSettings.TestSet.DynamicData.Remove("R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1", q17);

                #endregion

                #region R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "IMPMORNATU" , "2000" },
                { "IMPMORACID" , "1000" },
                { "IMPINVPERM" , "400" },
                { "IMPAMDS" , "300" },
                { "IMPDH" , "500" },
                { "IMPDIT" , "450" },
                { "VLPREMIOTOT" , "1600" },
                { "PRMVG" , "140" },
                { "PRMAP" , "70" },
                { "TAXAVG" , "6" },
                { "COD_PLANO" , "P200" },
                { "QTTITCAP" , "15" },
                { "VLTITCAP" , "150" },
                { "VLCUSTCAP" , "110" },
                { "IMPSEGCDG" , "20" },
                { "VLCUSTCDG" , "15" },
                { "IMPSEGAUXF" , "30" },
                { "VLCUSTAUXF" , "22" },
                { "PRMDIT" , "300" },
                { "QTDIT" , "10" },
                { "FAIXA_SAL_FIM" , "6000" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1", q18);

                #endregion

                #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "1" },
                { "RCAPS_NUM_RCAP" , "3" },
                { "RCAPS_VAL_RCAP" , "25" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q19);

                #endregion

                #region R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "2" },
                { "RCAPS_NUM_RCAP" , "4" },
                { "RCAPS_VAL_RCAP" , "27" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "Banco A" },
                { "RCAPCOMP_AGE_AVISO" , "1234" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "123456789" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2025-04-25" },
                { "RCAPCOMP_DATA_RCAP" , "2025-04-26" },
                });
                AppSettings.TestSet.DynamicData.Remove("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q21);

                #endregion

                #region VP0601B_CPESENDER

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "1" },
                { "DCLPESSOA_ENDERECO_ENDERECO" , "1" },
                { "DCLPESSOA_ENDERECO_BAIRRO" , "1" },
                { "DCLPESSOA_ENDERECO_CIDADE" , "1" },
                { "DCLPESSOA_ENDERECO_CEP" , "1" },
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "SP" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CPESENDER");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CPESENDER", q22);

                #endregion

                #region R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "S" }
                });
                q25.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , "N" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q25);

                #endregion

                #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "NUM_TITULO" , "HT123456789" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1", q26);

                #endregion

                #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , "Carlos Eduardo Lima" },
                { "PESSOA_TIPO_PESSOA" , "M" },
                });
                q27.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , "Carlos Eduardo Lima" },
                { "PESSOA_TIPO_PESSOA" , "F" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1", q27);

                #endregion

                #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "CPF" , "12345678901" },
                { "DATA_NASCIMENTO" , "1990-05-20" },
                { "WHOST_DATA_NASCIMENTO_7708" , "19900520" },
                { "WHOST_DATA_NASCIMENTO_2" , "20/05/1990" },
                { "SEXO" , "M" },
                { "COD_CBO" , "1234-56" },
                { "ESTADO_CIVIL" , "2" },
                { "ORGAO_EXPEDIDOR" , "SSP" },
                { "NUM_IDENTIDADE" , "MG1234567" },
                { "DATA_EXPEDICAO" , "2008-06-15" },
                { "UF_EXPEDIDORA" , "MG" },
                });
                q28.AddDynamic(new Dictionary<string, string>{
                { "CPF" , "12345678901" },
                { "DATA_NASCIMENTO" , "1990-05-20" },
                { "WHOST_DATA_NASCIMENTO_7708" , "19900520" },
                { "WHOST_DATA_NASCIMENTO_2" , "20/05/1990" },
                { "SEXO" , "M" },
                { "COD_CBO" , "1234-56" },
                { "ESTADO_CIVIL" , "2" },
                { "ORGAO_EXPEDIDOR" , "SSP" },
                { "NUM_IDENTIDADE" , "MG1234567" },
                { "DATA_EXPEDICAO" , "2008-06-15" },
                { "UF_EXPEDIDORA" , "MG" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q28);

                #endregion

                #region R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "CPF" , "98765432100" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q29);
                #endregion

                #region R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "PESSOJUR_CGC" , "11222333000199" },
                { "PESSOJUR_NOME_FANTASIA" , "Tech Solutions LTDA" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1", q30);


                #endregion

                #region R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "OCOREND" , "002" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q31);

                #endregion

                #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , "003" },
                { "ENDERECO" , "Av. Brasil, 456" },
                { "BAIRRO" , "Centro" },
                { "CIDADE" , "Rio de Janeiro" },
                { "CEP" , "20031-170" },
                { "SIGLA_UF" , "RJ" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1", q32);

                #endregion

                #region VP0601B_CPESENDERR

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "004" },
                { "DCLPESSOA_ENDERECO_ENDERECO" , "Rua Oliveira, 789" },
                { "DCLPESSOA_ENDERECO_BAIRRO" , "Bela Vista" },
                { "DCLPESSOA_ENDERECO_CIDADE" , "Belo Horizonte" },
                { "DCLPESSOA_ENDERECO_CEP" , "30180-001" },
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "MG" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CPESENDERR");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CPESENDERR", q33);

                #endregion

                #region VP0601B_CFONE

                var q34 = new DynamicData();
                q34.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_TELEFONE_TIPO_FONE" , "R" },
                { "DCLPESSOA_TELEFONE_DDD" , "11" },
                { "DCLPESSOA_TELEFONE_NUM_FONE" , "23456789" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CFONE");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CFONE", q34);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

                var q35 = new DynamicData();
                q35.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_RESIDENCIAL" , "21" },
                { "WHOST_FONE_RESIDENCIAL" , "34567890" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1", q35);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

                var q36 = new DynamicData();
                q36.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_COMERCIAL" , "31" },
                { "WHOST_FONE_COMERCIAL" , "45678901" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1", q36);

                #endregion

                #region VP0601B_CRISCO

                var q37 = new DynamicData();
                q37.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , "CERT987654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CRISCO");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CRISCO", q37);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

                var q38 = new DynamicData();
                q38.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_CELULAR" , "41" },
                { "WHOST_FONE_CELULAR" , "99887766" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1", q38);

                #endregion

                #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DDD_FAX" , "85" },
                { "WHOST_FONE_FAX" , "33445566" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1", q39);

                #endregion

                #region R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1

                var q41 = new DynamicData();
                q41.AddDynamic(new Dictionary<string, string>{
                { "WHOST_EMAIL" , "exemplo@email.com" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1", q41);

                #endregion

                #region R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1

                var q43 = new DynamicData();
                q43.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_INFORMACAO_COMPL" , "Cliente possui fundo de investimento complementar." }
                });
                AppSettings.TestSet.DynamicData.Remove("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1", q43);


                #endregion

                #region VP0601B_CCLIENTES

                var q44 = new DynamicData();
                q44.AddDynamic(new Dictionary<string, string>{
                { "DCLCLIENTES_COD_CLIENTE" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CCLIENTES");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CCLIENTES", q44);

                #endregion

                #region R2241_10_FETCH_DB_SELECT_1_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "IMP_MORNATU" , "45000.00" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2241_10_FETCH_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2241_10_FETCH_DB_SELECT_1_Query1", q45);

                #endregion

                #region R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1

                var q46 = new DynamicData();
                q46.AddDynamic(new Dictionary<string, string>{
                { "FAIXA_SAL_FIM" , "50000" },
                { "TAXAVG" , "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1", q46);

                #endregion

                #region R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1

                var q47 = new DynamicData();
                q47.AddDynamic(new Dictionary<string, string>{
                { "FAIXA_SAL_FIM" , "100000" },
                { "TAXAVG" , "1" },
                });
                AppSettings.TestSet.DynamicData.Remove("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1", q47);

                #endregion

                #region R2247_CALCULO_IDADE_DB_SELECT_1_Query1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_NASCIMENTO" , "1985-06-15" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2247_CALCULO_IDADE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2247_CALCULO_IDADE_DB_SELECT_1_Query1", q48);


                #endregion

                #region R2247_CALCULO_IDADE_DB_SELECT_2_Query1

                var q49 = new DynamicData();
                q49.AddDynamic(new Dictionary<string, string>{
                { "WS_DIAS_ANO" , "365" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2247_CALCULO_IDADE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2247_CALCULO_IDADE_DB_SELECT_2_Query1", q49);

                #endregion

                #region VP0601B_VGPLARAMC

                var q50 = new DynamicData();
                q50.AddDynamic(new Dictionary<string, string>{
                { "VGPLAR_NUM_RAMO" , "03" },
                { "VGPLAR_NUM_COBERTURA" , "101" },
                { "VGPLAR_QTD_COBERTURA" , "1" },
                { "VGPLAR_IMPSEGURADA" , "100000.00" },
                { "VGPLAR_CUSTO" , "500.00" },
                { "VGPLAR_PREMIO" , "750.00" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_VGPLARAMC");
                AppSettings.TestSet.DynamicData.Add("VP0601B_VGPLARAMC", q50);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1

                var q55 = new DynamicData();
                q55.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1", q55);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1", q56);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1

                var q57 = new DynamicData();
                q57.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "2" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1", q57);

                #endregion

                #region R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

                var q58 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q58);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1

                var q59 = new DynamicData();
                q59.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "1" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1", q59);

                #endregion

                #region R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1

                var q60 = new DynamicData();
                q60.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , "0" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1");
                AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1", q60);

                #endregion

                #region R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1

                var q61 = new DynamicData();
                q61.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_OCORR_ENDERECO" , "002" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1", q61);

                #endregion

                #region R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1

                var q63 = new DynamicData();
                q63.AddDynamic(new Dictionary<string, string>{
               { "CLIENEMA_EMAIL" , "cliente@exemplo.com" }
               });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q63);


                #endregion

                #region R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1

                var q65 = new DynamicData();
                q65.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_SEQ_EMAIL" , "0001" }
                });
                AppSettings.TestSet.DynamicData.Remove("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1", q65);

                #endregion

                #region R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1

                var q70 = new DynamicData();
                q70.AddDynamic(new Dictionary<string, string>{
                { "WS_TAXAVG" , "8" }
                 });
                AppSettings.TestSet.DynamicData.Remove("R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1", q70);

                #endregion

                #region VP0601B_VGPLAACES

                var q71 = new DynamicData();
                q71.AddDynamic(new Dictionary<string, string>{
                { "VGPLAA_NUM_ACESSORIO" , "A01" },
                { "VGPLAA_QTD_COBERTURA" , "1" },
                { "VGPLAA_IMPSEGURADA" , "5000.00" },
                { "VGPLAA_CUSTO" , "80.00" },
                { "VGPLAA_PREMIO" , "120.00" },
                 });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_VGPLAACES");
                AppSettings.TestSet.DynamicData.Add("VP0601B_VGPLAACES", q71);

                #endregion

                #region VP0601B_C01_AGENCEF

                var q73 = new DynamicData();
                q73.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "1234" },
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "FNT01" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_C01_AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VP0601B_C01_AGENCEF", q73);

                #endregion

                #region R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1

                var q81 = new DynamicData();
                q81.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "USR789" }
                });
                AppSettings.TestSet.DynamicData.Remove("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1", q81);

                #endregion

                #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

                var q85 = new DynamicData();
                q85.AddDynamic(new Dictionary<string, string>{
                { "SIT_REGISTRO" , "ATIVO" }
                });
                AppSettings.TestSet.DynamicData.Remove("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q85);

                #endregion

                #region R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1

                var q87 = new DynamicData();
                q87.AddDynamic(new Dictionary<string, string>{
                { "PF062_DES_CBO" , "Analista de Sistemas" }
                });
                AppSettings.TestSet.DynamicData.Remove("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1", q87);

                #endregion

                #region VP0601B_CCBO

                var q89 = new DynamicData();
                q89.AddDynamic(new Dictionary<string, string>{
                { "DCLCBO_CBO_COD_CBO" , "2123-05" },
                { "DCLCBO_CBO_DESCR_CBO" , "Engenheiro de Software" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CCBO");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CCBO", q89);

                #endregion

                #region VP0601B_CFONTES

                var q90 = new DynamicData();
                q90.AddDynamic(new Dictionary<string, string>{
                { "DCLFONTES_FONTES_COD_FONTE" , "F012" },
                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "2025-04-30" },
                });
                AppSettings.TestSet.DynamicData.Remove("VP0601B_CFONTES");
                AppSettings.TestSet.DynamicData.Add("VP0601B_CFONTES", q90);

                #endregion

                #region VP0601B_C01_GECLIMOV

                var q91 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("VP0601B_C01_GECLIMOV");
                AppSettings.TestSet.DynamicData.Add("VP0601B_C01_GECLIMOV", q91);

                #endregion

                #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

                var q93 = new DynamicData();
                q93.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_HIST" , "000123" }
                });
                AppSettings.TestSet.DynamicData.Remove("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q93);

                #endregion

                #endregion

                var program = new VP0601B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }

    }
}
