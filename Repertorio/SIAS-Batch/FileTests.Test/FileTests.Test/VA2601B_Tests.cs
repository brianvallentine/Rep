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
using static Code.VA2601B;
using Sias.VidaAzul.DB2.VA2601B;

namespace FileTests.Test
{
    [Collection("VA2601B_Tests")]
   [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
   [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
   public class VA2601B_Tests
   {
       //é de extrema importancia que este método seja modificado com cautela, 
       //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
       private static void Load_Parameters()
       {
           AppSettings.TestSet.Clear();
           #region PARAMETERS
           #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

           var q0 = new DynamicData();
           q0.AddDynamic(new Dictionary<string, string>{
               { "SISTEMAS_DATA_MOV_ABERTO" , ""},
               { "WHOST_DATA_AGENDAMENTO" , "2024-09-17"},
           });
           AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

           #endregion

           #region R0100_00_INICIALIZA_DB_SELECT_2_Query1

           var q1 = new DynamicData();
           q1.AddDynamic(new Dictionary<string, string>{
               { "NUM_CLIENTE" , "102030"}
           });
           AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_2_Query1", q1);

           #endregion

           #region VA2601B_CPROPOSTA

           var q2 = new DynamicData();
           q2.AddDynamic(new Dictionary<string, string>{
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "123"},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , ""},//sss
               { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , ""},//s
               { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
               { "PROPSSVD_COD_CORRESP_BANC" , ""},
               { "PROPSSVD_NUM_PRAZO_FIN" , ""},
               { "PROPSSVD_COD_OPER_CREDITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "123456"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2024-09-18"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "2"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "1015"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , "D"},
               { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
               { "WHOST_RAMO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CPROPOSTA", q2);

           #endregion

           #region R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1

           var q3 = new DynamicData();
           q3.AddDynamic(new Dictionary<string, string>{
               { "RCAPS_NOME_SEGURADO" , ""},
               { "RCAPS_AGE_COBRANCA" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1", q3);

           #endregion

           #region R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1

           var q4 = new DynamicData();
           q4.AddDynamic(new Dictionary<string, string>{
               { "WS_NUM_PROPOSTA_AZUL" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1", q4);

           #endregion

           #region R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1

           var q5 = new DynamicData();
           q5.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
               { "COD_ERRO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1", q5);

           #endregion

           #region R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

           var q6 = new DynamicData();
           q6.AddDynamic(new Dictionary<string, string>{
               { "ESTIPULA_NOME_ESTIPULANTE" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q6);

           #endregion

           #region R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1

           var q7 = new DynamicData();
           q7.AddDynamic(new Dictionary<string, string>{
               { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
               { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
               { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
               { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
               { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1", q7);

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

           #region R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1

           var q14 = new DynamicData();
           q14.AddDynamic(new Dictionary<string, string>{
               { "RCAPS_COD_FONTE" , "10"},
               { "RCAPS_NUM_RCAP" , ""},
               { "RCAPS_VAL_RCAP" , "10"},
           });
           AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q14);

           #endregion

           #region R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1

           var q15 = new DynamicData();
           q15.AddDynamic(new Dictionary<string, string>{
               { "RCAPS_COD_FONTE" , ""},
               { "RCAPS_NUM_RCAP" , ""},
               { "RCAPS_VAL_RCAP" , "10"},
           });
           AppSettings.TestSet.DynamicData.Add("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1", q15);

           #endregion

           #region R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1

           var q16 = new DynamicData();
           q16.AddDynamic(new Dictionary<string, string>{
               { "RCAPCOMP_BCO_AVISO" , ""},
               { "RCAPCOMP_AGE_AVISO" , ""},
               { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
               { "RCAPCOMP_DATA_MOVIMENTO" , ""},
               { "RCAPCOMP_DATA_RCAP" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1", q16);

           #endregion

           #region VA2601B_C01_RCAPCOMP

           var q17 = new DynamicData();
           q17.AddDynamic(new Dictionary<string, string>{
               { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
               { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
               { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
               { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
               { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
               { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_C01_RCAPCOMP", q17);

           #endregion

           #region R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

           var q18 = new DynamicData();
           q18.AddDynamic(new Dictionary<string, string>{
               { "WHOST_SIT_PROPOSTA" , ""},
               { "WHOST_SIT_ENVIO" , ""},
               { "PROPOFID_NRMATRVEN" , ""},
               { "WHOST_DATA_AGENDAMENTO" , ""},
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1", q18);

           #endregion
            
           #region R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

           var q19 = new DynamicData();
           q19.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DATA_AGENDAMENTO" , ""},
               { "RCAPCOMP_DATA_MOVIMENTO" , ""},
               { "PROPOFID_VAL_PAGO" , ""},
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q19);

           #endregion

           #region R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1

           var q20 = new DynamicData();
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           q20.AddDynamic(new Dictionary<string, string>{
               { "CONDITEC_CARREGA_CONJUGE" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q20);

           #endregion

           #region R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1

           var q21 = new DynamicData();
           q21.AddDynamic(new Dictionary<string, string>{
               { "NUM_TITULO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1", q21);

           #endregion

           #region R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1

           var q22 = new DynamicData();
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           q22.AddDynamic(new Dictionary<string, string>{
               { "PESSOA_NOME_PESSOA" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1", q22);

           #endregion

           #region R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1

           var q23 = new DynamicData();
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},
           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},
           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},

           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},

           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},

           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},

           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},

           });
           q23.AddDynamic(new Dictionary<string, string>{
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "COD_CBO" , ""},
               { "ESTADO_CIVIL" , ""},
               { "ORGAO_EXPEDIDOR" , ""},
               { "NUM_IDENTIDADE" , ""},
               { "DATA_EXPEDICAO" , "00"},
               { "UF_EXPEDIDORA" , ""},

           });
           AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1", q23);

           #endregion

           #region R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1

           var q24 = new DynamicData();
           q24.AddDynamic(new Dictionary<string, string>{
               { "OCOREND" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q24);

           #endregion

           #region R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1

           var q25 = new DynamicData();
           q25.AddDynamic(new Dictionary<string, string>{
               { "OCORR_ENDERECO" , ""},
               { "ENDERECO" , ""},
               { "BAIRRO" , ""},
               { "CIDADE" , ""},
               { "CEP" , ""},
               { "SIGLA_UF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1", q25);

           #endregion

           #region VA2601B_CPESENDER

           var q26 = new DynamicData();
           q26.AddDynamic(new Dictionary<string, string>{
               { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
               { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
               { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
               { "DCLPESSOA_ENDERECO_CIDADE" , ""},
               { "DCLPESSOA_ENDERECO_CEP" , ""},
               { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CPESENDER", q26);

           #endregion

           #region VA2601B_CPESENDERR

           var q27 = new DynamicData();
           q27.AddDynamic(new Dictionary<string, string>{
               { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
               { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
               { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
               { "DCLPESSOA_ENDERECO_CIDADE" , ""},
               { "DCLPESSOA_ENDERECO_CEP" , ""},
               { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CPESENDERR", q27);

           #endregion

           #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1

           var q28 = new DynamicData();
           q28.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DDD_RESIDENCIAL" , "41"},
               { "WHOST_FONE_RESIDENCIAL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1", q28);

           #endregion

           #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1

           var q29 = new DynamicData();
           q29.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DDD_COMERCIAL" , ""},
               { "WHOST_FONE_COMERCIAL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1", q29);

           #endregion

           #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1

           var q30 = new DynamicData();
           q30.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DDD_CELULAR" , ""},
               { "WHOST_FONE_CELULAR" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1", q30);

           #endregion

           #region R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1

           var q31 = new DynamicData();
           q31.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DDD_FAX" , ""},
               { "WHOST_FONE_FAX" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1", q31);

           #endregion

           #region VA2601B_CFONE

           var q32 = new DynamicData();
           q32.AddDynamic(new Dictionary<string, string>{
               { "DCLPESSOA_TELEFONE_TIPO_FONE" , ""},
               { "DCLPESSOA_TELEFONE_DDD" , ""},
               { "DCLPESSOA_TELEFONE_NUM_FONE" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CFONE", q32);

           #endregion
            
           #region R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1

           var q33 = new DynamicData();
           q33.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_COD_PESSOA" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1", q33);

           #endregion

           #region R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1

           var q34 = new DynamicData();
           q34.AddDynamic(new Dictionary<string, string>{
               { "WHOST_EMAIL" , "teste@teste.com.br"}
           });
           AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1", q34);

           #endregion

           #region R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_2_Update1

           var q35 = new DynamicData();
           q35.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_COD_PESSOA" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_2_Update1", q35);

           #endregion

           #region R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1

           var q36 = new DynamicData();
           q36.AddDynamic(new Dictionary<string, string>{
               { "PROFIDCO_INFORMACAO_COMPL" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1", q36);

           #endregion

           #region VA2601B_CRISCO

           var q37 = new DynamicData();
           q37.AddDynamic(new Dictionary<string, string>{
               { "PROPVA_NRCERTIF" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CRISCO", q37);

           #endregion

           #region R2241_10_FETCH_DB_SELECT_1_Query1

           var q38 = new DynamicData();
           q38.AddDynamic(new Dictionary<string, string>{
               { "APOLCOB_IMPSEGURADO" , ""},
               { "APOLCOB_DT_TERVIGENCIA" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2241_10_FETCH_DB_SELECT_1_Query1", q38);

           #endregion

           #region VA2601B_CCLIENTES

           var q39 = new DynamicData();
           q39.AddDynamic(new Dictionary<string, string>{
               { "DCLCLIENTES_COD_CLIENTE" , "102030"}
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CCLIENTES", q39);

           #endregion
            
           #region R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1

           var q40 = new DynamicData();
           q40.AddDynamic(new Dictionary<string, string>{
               { "COD_CLIENTE" , ""},
               { "PESSOA_NOME_PESSOA" , ""},
               { "CPF" , ""},
               { "DATA_NASCIMENTO" , ""},
               { "SEXO" , ""},
               { "ESTADO_CIVIL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1", q40);

           #endregion
            
           #region R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1

           var q41 = new DynamicData();
           q41.AddDynamic(new Dictionary<string, string>{
               { "GEDOCCLI_COD_CLIENTE" , ""},
               { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
               { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
               { "GEDOCCLI_DTH_EXPEDICAO" , ""},
               { "GEDOCCLI_COD_UF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1", q41);

           #endregion

           #region R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1

           var q42 = new DynamicData();
           q42.AddDynamic(new Dictionary<string, string>{
               { "WS_COUNT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1", q42);

           #endregion

           #region R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1

           var q43 = new DynamicData();
           q43.AddDynamic(new Dictionary<string, string>{
               { "WS_COUNT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1", q43);

           #endregion

           #region R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1

           var q44 = new DynamicData();
           q44.AddDynamic(new Dictionary<string, string>{
               { "WS_COUNT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1", q44);

           #endregion

           #region R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1

           var q45 = new DynamicData();
           q45.AddDynamic(new Dictionary<string, string>{
               { "WS_COUNT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1", q45);

           #endregion

           #region R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1

           var q46 = new DynamicData();

           AppSettings.TestSet.DynamicData.Add("R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1", q46);

           #endregion

           #region R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1

           var q47 = new DynamicData();
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           q47.AddDynamic(new Dictionary<string, string>{
               { "ENDERECO_OCORR_ENDERECO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1", q47);

           #endregion

           #region R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1

           var q48 = new DynamicData();
           q48.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1", q48);

           #endregion

           #region R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1

           var q49 = new DynamicData();
           q49.AddDynamic(new Dictionary<string, string>{
               { "WS_SIGLA_UF" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1", q49);

           #endregion

           #region R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1

           var q50 = new DynamicData();
           q50.AddDynamic(new Dictionary<string, string>{
               { "CLIENEMA_EMAIL" , "teste@teste.com.br"}
           });
           AppSettings.TestSet.DynamicData.Add("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q50);

           #endregion
            
           #region R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1

           var q51 = new DynamicData();
           q51.AddDynamic(new Dictionary<string, string>{
               { "WHOST_EMAIL" , ""},
               { "COD_CLIENTE" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1", q51);

           #endregion

           #region R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1

           var q52 = new DynamicData();
           q52.AddDynamic(new Dictionary<string, string>{
               { "CLIENEMA_SEQ_EMAIL" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1", q52);

           #endregion
            
           #region R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1

           var q53 = new DynamicData();
           q53.AddDynamic(new Dictionary<string, string>{
               { "COD_CLIENTE" , ""},
               { "CLIENEMA_SEQ_EMAIL" , ""},
               { "WHOST_EMAIL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1", q53);

           #endregion
            
           #region R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1

           var q54 = new DynamicData();
           q54.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
               { "PRODUVG_COD_PRODUTO" , ""},
               { "COD_CLIENTE" , ""},
               { "ENDERECO_OCORR_ENDERECO" , ""},
               { "WHOST_FONTE" , ""},
               { "PROPOFID_AGECOBR" , ""},
               { "PROPOFID_OPCAO_COBER" , ""},
               { "WHOST_DATA_AGENDAMENTO" , ""},
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
               { "PROPOFID_DTQITBCO" , ""},
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
           });
           AppSettings.TestSet.DynamicData.Add("R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1", q54);

           #endregion
            
           #region R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1

           var q55 = new DynamicData();
           q55.AddDynamic(new Dictionary<string, string>{
               { "VG078_NUM_CERTIFICADO" , ""},
               { "VG078_DES_ANDAMENTO" , ""},
               { "VG078_COD_USUARIO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1", q55);

           #endregion
            
           #region R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

           var q56 = new DynamicData();
           q56.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q56);

           #endregion

           #region VA2601B_VGPLARAMC

           var q57 = new DynamicData();
           q57.AddDynamic(new Dictionary<string, string>{
               { "VGPLAR_NUM_RAMO" , ""},
               { "VGPLAR_NUM_COBERTURA" , ""},
               { "VGPLAR_QTD_COBERTURA" , ""},
               { "VGPLAR_IMPSEGURADA" , ""},
               { "VGPLAR_CUSTO" , ""},
               { "VGPLAR_PREMIO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_VGPLARAMC", q57);

           #endregion
            
           #region R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1

           var q58 = new DynamicData();
           q58.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
               { "VGPLAR_NUM_RAMO" , ""},
               { "VGPLAR_NUM_COBERTURA" , ""},
               { "VGPLAR_QTD_COBERTURA" , ""},
               { "VGPLAR_IMPSEGURADA" , ""},
               { "VGPLAR_CUSTO" , ""},
               { "VGPLAR_PREMIO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1", q58);

           #endregion

           #region VA2601B_VGPLAACES

           var q59 = new DynamicData();
           q59.AddDynamic(new Dictionary<string, string>{
               { "VGPLAA_NUM_ACESSORIO" , ""},
               { "VGPLAA_QTD_COBERTURA" , ""},
               { "VGPLAA_IMPSEGURADA" , ""},
               { "VGPLAA_CUSTO" , ""},
               { "VGPLAA_PREMIO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_VGPLAACES", q59);

           #endregion
            
           #region R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1

           var q60 = new DynamicData();
           q60.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
               { "VGPLAA_NUM_ACESSORIO" , ""},
               { "VGPLAA_QTD_COBERTURA" , ""},
               { "VGPLAA_IMPSEGURADA" , ""},
               { "VGPLAA_CUSTO" , ""},
               { "VGPLAA_PREMIO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1", q60);

           #endregion
            
           #region R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

           var q61 = new DynamicData();
           q61.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q61);

           #endregion
            
           #region R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1

           var q62 = new DynamicData();
           q62.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1", q62);

           #endregion
            
           #region R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1

           var q63 = new DynamicData();
           q63.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
               { "NUM_PARCELA" , ""},
               { "WHOST_DATA_AGENDAMENTO" , ""},
               { "PROPOFID_VAL_PAGO" , ""},
               { "PREMIO_AP" , ""},
               { "VLMULTA" , ""},
               { "WHOST_OPCAOPAG" , ""},
               { "SIT_REGISTRO" , ""},
               { "OCORR_HISTORICO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1", q63);

           #endregion
            
           #region R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1

           var q64 = new DynamicData();
           q64.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
               { "NUM_PARCELA" , ""},
               { "NUM_TITULO" , ""},
               { "WHOST_DATA_AGENDAMENTO" , ""},
               { "PROPOFID_VAL_PAGO" , ""},
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
           AppSettings.TestSet.DynamicData.Add("R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1", q64);

           #endregion
            
           #region R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1

           var q65 = new DynamicData();
           q65.AddDynamic(new Dictionary<string, string>{
               { "HISLANCT_NUM_CERTIFICADO" , ""},
               { "HISLANCT_NUM_PARCELA" , ""},
               { "HISLANCT_OCORR_HISTORICOCTA" , ""},
               { "HISLANCT_COD_AGENCIA_DEBITO" , ""},
               { "HISLANCT_OPE_CONTA_DEBITO" , ""},
               { "HISLANCT_NUM_CONTA_DEBITO" , ""},
               { "HISLANCT_DIG_CONTA_DEBITO" , ""},
               { "WHOST_DATA_AGENDAMENTO" , ""},
               { "HISLANCT_PRM_TOTAL" , ""},
               { "HISLANCT_SIT_REGISTRO" , ""},
               { "HISLANCT_TIPLANC" , ""},
               { "HISLANCT_OCORR_HISTORICO" , ""},
               { "HISLANCT_CODCONV" , ""},
               { "HISLANCT_COD_USUARIO" , ""},
               { "HISLANCT_NUM_CARTAO_CREDITO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1", q65);

           #endregion

           #region R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1

           var q66 = new DynamicData();
           q66.AddDynamic(new Dictionary<string, string>{
               { "CONVEVG_COD_SEGURO" , ""},
               { "CONVEVG_COD_CONV_CARTAO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1", q66);

           #endregion

           #region R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1

           var q67 = new DynamicData();
           q67.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1", q67);

           #endregion

           #region R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1

           var q68 = new DynamicData();
           q68.AddDynamic(new Dictionary<string, string>{
               { "RELATORI_COD_USUARIO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1", q68);

           #endregion

           #region R3700_00_INSERT_RELATORIOS_DB_UPDATE_2_Update1

           var q69 = new DynamicData();
           q69.AddDynamic(new Dictionary<string, string>{
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_UPDATE_2_Update1", q69);

           #endregion

           #region R3700_00_INSERT_RELATORIOS_DB_INSERT_3_Insert1

           var q70 = new DynamicData();
           q70.AddDynamic(new Dictionary<string, string>{
               { "SISTEMAS_DATA_MOV_ABERTO" , ""},
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
           AppSettings.TestSet.DynamicData.Add("R3700_00_INSERT_RELATORIOS_DB_INSERT_3_Insert1", q70);

           #endregion

           #region R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1

           var q71 = new DynamicData();
           AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q71);
            
           #endregion
            
           #region R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1

           var q72 = new DynamicData();
           q72.AddDynamic(new Dictionary<string, string>{
               { "WHOST_SIT_PROPOSTA" , ""},
               { "WHOST_SIT_ENVIO" , ""},
               { "WHOST_DATA_AGENDAMENTO" , ""},
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1", q72);

           #endregion

           #region R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1

           var q73 = new DynamicData();
           q73.AddDynamic(new Dictionary<string, string>{
               { "PF062_DES_CBO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1", q73);

           #endregion
            
           #region R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1

           var q74 = new DynamicData();
           q74.AddDynamic(new Dictionary<string, string>{
               { "COD_CLIENTE" , "102030"},
               { "ENDERECO_OCORR_ENDERECO" , ""},
               { "WHOST_FONTE" , ""},
               { "WHOST_PROFISSAO" , ""},
               { "WHOST_SIT_REGISTRO" , ""},
               { "WHOST_DTPROXVEN" , ""},
               { "WHOST_IDADE" , ""},
               { "PROPOFID_NOME_CONJUGE" , ""},
               { "VIND_NOME_CONJUGE" , ""},
               { "PROPOFID_DATA_NASC_CONJUGE" , ""},
               { "VIND_DATA_NASC_CONJUGE" , ""},
               { "WHOST_PROFISSAO_CONJUGE" , ""},
               { "VIND_PROFISSAO_CONJUGE" , ""},
               { "WHOST_INFO_COMPL" , ""},
               { "PROPOFID_CGC_CONVENENTE" , ""},
               { "VIND_CGC_CONVENENTE" , ""},
               { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
               { "VIND_NUM_CONTR" , ""},
               { "PROPSSVD_COD_CORRESP_BANC" , ""},
               { "VIND_COD_CORRESP" , ""},
               { "PROPOFID_ORIGEM_PROPOSTA" , ""},
               { "PROPSSVD_NUM_PRAZO_FIN" , ""},
               { "VIND_NUM_PRAZO" , ""},
               { "PROPSSVD_COD_OPER_CREDITO" , ""},
               { "VIND_COD_OPER_CRED" , ""},
               { "SISTEMAS_DATA_MOV_ABERTO" , ""},
               { "VIND_DATA_DECLINIO" , ""},
               { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1", q74);

           #endregion

           #region VA2601B_C01_AGENCEF

           var q75 = new DynamicData();
           q75.AddDynamic(new Dictionary<string, string>{
               { "DCLAGENCIAS_CEF_COD_AGENCIA" , ""},
               { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_C01_AGENCEF", q75);

           #endregion

           #region VA2601B_CCBO

           var q76 = new DynamicData();
           q76.AddDynamic(new Dictionary<string, string>{
               { "DCLCBO_CBO_COD_CBO" , ""},
               { "DCLCBO_CBO_DESCR_CBO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CCBO", q76);

           #endregion

           #region VA2601B_CFONTES

           var q77 = new DynamicData();
           q77.AddDynamic(new Dictionary<string, string>{
               { "DCLFONTES_FONTES_COD_FONTE" , ""},
               { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CFONTES", q77);

           #endregion

           #region VA2601B_CVGRAMOCOMP

           var q78 = new DynamicData();
           q78.AddDynamic(new Dictionary<string, string>{
               { "VG081_NUM_APOLICE" , ""},
               { "VG081_COD_SUBGRUPO" , ""},
               { "VG081_COD_GRUPO_SUSEP" , "15"},
               { "VG081_RAMO_EMISSOR" , ""},
               { "VG081_COD_MODALIDADE" , ""},
               { "VG081_DTH_INI_VIGENCIA" , ""},
               { "VG081_COD_OPCAO_COBERTURA" , ""},
               { "VG081_NUM_IDADE_INICIAL" , ""},
               { "VG081_NUM_IDADE_FINAL" , ""},
               { "VG081_VLR_PERC_PREMIO" , "10"},
               { "VG081_COD_USUARIO" , ""},
               { "VG081_DTH_ATUALIZACAO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CVGRAMOCOMP", q78);

           #endregion
            
           #region R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1

           var q79 = new DynamicData();
           q79.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1", q79);

           #endregion
            
           #region R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1

           var q80 = new DynamicData();
           q80.AddDynamic(new Dictionary<string, string>{
               { "NUM_CLIENTE" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1", q80);

           #endregion

           #region R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

           var q81 = new DynamicData();
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           q81.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_OCORR_HIST" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q81);

           #endregion

           #region VA2601B_C01_GECLIMOV

           var q82 = new DynamicData();
           q82.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_TIPO_MOVIMENTO" , "2"},
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
           AppSettings.TestSet.DynamicData.Add("VA2601B_C01_GECLIMOV", q82);

           #endregion
            
           #region R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1

           var q83 = new DynamicData();
           q83.AddDynamic(new Dictionary<string, string>{
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
           AppSettings.TestSet.DynamicData.Add("R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1", q83);

           #endregion

           #region R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1

           var q84 = new DynamicData();
           q84.AddDynamic(new Dictionary<string, string>{
               { "GECLIMOV_TIPO_MOVIMENTO" , ""},
               { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
               { "GECLIMOV_NOME_RAZAO" , ""},
               { "VIND_NOME_RAZAO" , ""},
               { "GECLIMOV_TIPO_PESSOA" , ""},
               { "VIND_TIPO_PESSOA" , ""},
               { "GECLIMOV_IDE_SEXO" , ""},
               { "VIND_IDE_SEXO" , ""},
               { "GECLIMOV_ESTADO_CIVIL" , ""},
               { "VIND_EST_CIVIL" , ""},
               { "GECLIMOV_OCORR_ENDERECO" , ""},
               { "VIND_OCORR_END" , ""},
               { "GECLIMOV_ENDERECO" , ""},
               { "VIND_ENDERECO" , ""},
               { "GECLIMOV_BAIRRO" , ""},
               { "VIND_BAIRRO" , ""},
               { "GECLIMOV_CIDADE" , ""},
               { "VIND_CIDADE" , ""},
               { "GECLIMOV_SIGLA_UF" , ""},
               { "VIND_SIGLA_UF" , ""},
               { "GECLIMOV_CEP" , ""},
               { "VIND_CEP" , ""},
               { "GECLIMOV_DDD" , ""},
               { "VIND_DDD" , ""},
               { "GECLIMOV_TELEFONE" , ""},
               { "VIND_TELEFONE" , ""},
               { "GECLIMOV_FAX" , ""},
               { "VIND_FAX" , ""},
               { "GECLIMOV_CGCCPF" , ""},
               { "VIND_CGCCPF" , ""},
               { "GECLIMOV_DATA_NASCIMENTO" , ""},
               { "VIND_DTNASC" , ""},
               { "GECLIMOV_COD_USUARIO" , ""},
               { "GECLIMOV_COD_CLIENTE" , ""},
               { "GECLIMOV_OCORR_HIST" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1", q84);

           #endregion

           #endregion
       }

       [Fact]
       public static void VA2601B_Tests_Fact()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE
               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList = AppSettings.TestSet.DynamicData["R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList?.Count > 1);

               var envList1 = AppSettings.TestSet.DynamicData["R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList1[1].TryGetValue("WHOST_SIT_PROPOSTA", out var val1r) && (val1r.Contains("POB") ||val1r.Contains("REJ") || val1r.Contains("PEN")));

               var envList2 = AppSettings.TestSet.DynamicData["R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList2[1].TryGetValue("WHOST_DATA_AGENDAMENTO", out var val2r) && val2r.Contains("2024-09-17"));

               var envList3 = AppSettings.TestSet.DynamicData["R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList3[1].TryGetValue("PROPOFID_COD_PESSOA", out var val3r) && val3r.Contains("123456"));

               var envList6 = AppSettings.TestSet.DynamicData["R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList6?.Count > 1); 

               var envList7 = AppSettings.TestSet.DynamicData["R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList7[1].TryGetValue("WHOST_EMAIL", out var val4r) && val4r.Contains("teste@teste.com.br"));//atual

               var envList9 = AppSettings.TestSet.DynamicData["R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList9?.Count > 1);

               var envList10 = AppSettings.TestSet.DynamicData["R3020_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList10?.Count > 1);

               var envList11 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList11?.Count > 1);

               var envList12 = AppSettings.TestSet.DynamicData["R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList12?.Count > 1);

               var envList13 = AppSettings.TestSet.DynamicData["R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList13?.Count > 1);

               var envList14 = AppSettings.TestSet.DynamicData["R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList14?.Count > 1);

               var envList15 = AppSettings.TestSet.DynamicData["R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList15?.Count > 1);

               var envList16 = AppSettings.TestSet.DynamicData["R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList16?.Count > 1);

               var envList17 = AppSettings.TestSet.DynamicData["R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList17?.Count > 1);

               var envList18 = AppSettings.TestSet.DynamicData["R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList18?.Count > 1);

               var envList19 = AppSettings.TestSet.DynamicData["R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList18?.Count > 1);

               //var envList21 = AppSettings.TestSet.DynamicData["R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1"].DynamicList;
               //Assert.True(envList21?.Count > 1);

               var envList22 = AppSettings.TestSet.DynamicData["R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList22[1].TryGetValue("GECLIMOV_TIPO_MOVIMENTO", out var val22r) && val22r.Contains("2"));

           }
       }
        
       [Fact]
       public static void VA2601B_Tests_VA2601B_Infinito()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               var q14 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1");
               AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1", q14);

               var q15 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1");
               AppSettings.TestSet.DynamicData.Add("R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1", q15);

               var q2 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VA2601B_CPROPOSTA");
               q2.AddDynamic(new Dictionary<string, string>{
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "123"},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR" , "SSS"},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ" , "S"},
               { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
               { "PROPSSVD_COD_CORRESP_BANC" , ""},
               { "PROPSSVD_NUM_PRAZO_FIN" , ""},
               { "PROPSSVD_COD_OPER_CREDITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO" , ""},
               { "DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "123456"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2024-09-18"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "2"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "1015"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , "D"},
               { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
               { "WHOST_RAMO" , ""},
           });
               AppSettings.TestSet.DynamicData.Add("VA2601B_CPROPOSTA", q2);
               #region VARIAVEIS_TESTE


               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList20 = AppSettings.TestSet.DynamicData["R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList20[1].TryGetValue("NUM_CLIENTE", out var val20r) && val20r.Contains("102030"));
               Assert.True(program.LPARM01.Value == 0000000);
                
           }
       }

       [Fact]
       public static void VA2601B_Tests_VA2601B_PRP_FIDELIZ()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE

               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList2 = AppSettings.TestSet.DynamicData["R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList2[1].TryGetValue("WHOST_DATA_AGENDAMENTO", out var val2r) && val2r.Contains("2024-09-17"));

               Assert.True(program.CT0006S_LINKAGE.CT0006S_BAIRRO == "");
           }
       }

       [Fact]
       public static void VA2601B_Tests_VA2601B_CCLIENTES_ZERADO()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE

               var q2 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VA2601B_CCLIENTES");
               AppSettings.TestSet.DynamicData.Add("VA2601B_CCLIENTES", q2);

               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList4 = AppSettings.TestSet.DynamicData["R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList4?.Count > 1);

               var envList5 = AppSettings.TestSet.DynamicData["R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList5?.Count > 1);
           }
       }

       [Fact]
       public static void VA2601B_Tests_Fact_INSERT_VGHISTCONT()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE

               var q2 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VA2601B_CPROPOSTA");
               q2.AddDynamic(new Dictionary<string, string>{
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "123"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "123456"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2024-09-18"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "2"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "1015"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , "D"},
               { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
               { "WHOST_RAMO" , ""},
           });
               AppSettings.TestSet.DynamicData.Add("VA2601B_CPROPOSTA", q2);

               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList1 = AppSettings.TestSet.DynamicData["R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList1?.Count > 1);

           }
       }
        
       [Fact]
       public static void VA2601B_Tests_Fact_UPDATE_PROPOSTAVA()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE

               var q71 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1");
               q71.AddDynamic(new Dictionary<string, string>{
               { "SIT_REGISTRO" , "3"}
               });
                
               AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q71);

               var q2 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VA2601B_CPROPOSTA");
               q2.AddDynamic(new Dictionary<string, string>{
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "123"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "8464327676"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "8464327676"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2024-09-18"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "2"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "1015"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , "D"},
               { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
               { "WHOST_RAMO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("VA2601B_CPROPOSTA", q2);
               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList1 = AppSettings.TestSet.DynamicData["R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList1[0].TryGetValue("COD_CLIENTE", out var val1r) && val1r.Contains("102030"));

           }
       }

       [Fact]
       public static void VA2601B_Tests_Fact_UPDATE_PRP()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE

               var q2 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VA2601B_CPROPOSTA");
               q2.AddDynamic(new Dictionary<string, string>{
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "123"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "8464327676"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "8464327676"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2024-09-18"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "2"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "1015"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , "D"},
               { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
               { "WHOST_RAMO" , ""},
           });
               AppSettings.TestSet.DynamicData.Add("VA2601B_CPROPOSTA", q2);

               var q71 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1");
               q71.AddDynamic(new Dictionary<string, string>{
               { "SIT_REGISTRO" , "3"}
               });
               q71.AddDynamic(new Dictionary<string, string>{
               { "SIT_REGISTRO" , "3"}
               });
               q71.AddDynamic(new Dictionary<string, string>{
               { "SIT_REGISTRO" , "3"}
               });
               q71.AddDynamic(new Dictionary<string, string>{
               { "SIT_REGISTRO" , "3"}
               });
               q71.AddDynamic(new Dictionary<string, string>{
               { "SIT_REGISTRO" , "3"}
               });
                
               AppSettings.TestSet.DynamicData.Add("R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1", q71);

               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList20 = AppSettings.TestSet.DynamicData["R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1"].DynamicList;
               Assert.True(envList20[1].TryGetValue("WHOST_SIT_PROPOSTA", out var val5r) && val5r.Contains("EMT"));

           }
       }

       [Fact]
       public static void VA2601B_Tests_Fact_Insert_Email()
       {
           lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               Load_Parameters();

               #region VARIAVEIS_TESTE

               var q50 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1");
               AppSettings.TestSet.DynamicData.Add("R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1", q50);

               var q2 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VA2601B_CPROPOSTA");
               q2.AddDynamic(new Dictionary<string, string>{
               { "DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE" , "123"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF" , "1"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA" , "123456"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA" , "2024-09-18"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF" , "7"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG" , "2"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO" , "0001-01-01"},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO" , ""},
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA" , "1015"},
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
               { "DCLPROPOSTA_FIDELIZ_PROPOFID_IND_TP_PROPOSTA" , "D"},
               { "DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO" , ""},
               { "DCLPRODUTOS_VG_PRODUVG_NOME_PRODUTO" , ""},
               { "WHOST_RAMO" , ""},
           });
               AppSettings.TestSet.DynamicData.Add("VA2601B_CPROPOSTA", q2);

               #endregion
               var program = new VA2601B();
               program.Execute();

               var envList1 = AppSettings.TestSet.DynamicData["R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
               Assert.True(envList1?.Count > 1);

           }
       }
        
   }
}
