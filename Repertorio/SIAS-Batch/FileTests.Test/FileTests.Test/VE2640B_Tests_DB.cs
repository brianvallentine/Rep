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
using static Code.VE2640B;

namespace FileTests.Test_DB
{
    [Collection("VE2640B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE2640B_Tests_DB
    {

        [Fact]
        public static void VE2640B_Database()
        {
            var program = new VE2640B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();
            #region VARIAVEIS_TESTEDB

            program.VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_INI_VIGENCIA.Value = "2010-10-10";
            program.VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_FIM_VIGENCIA.Value = "2010-10-10";
            program.VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_NASCIMENTO.Value = "2010-10-10";
            program.VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_EMISSAO_RG.Value = "2010-10-10";

            program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.Value = "2010-10-10";
            program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.Value = "2010-10-10";

            program.FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_INIVIGENCIA.Value = "2010-10-10";
            program.FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_TERVIGENCIA.Value = "2010-10-10";

            program.VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DATA_SOLICITACAO.Value = "2010-10-10";
            program.VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA.Value = "2010-10-10";
            program.VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO.Value = "2010-10-10";

            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.Value = "2010-10-10";
            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value = "2010-10-10";
            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2010-10-10";
            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO.Value = "22:33:33";
            program.WS_WORK_AREAS.H_DT_MOV_ABERTO_2610.Value = "2010-10-10";

            program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Value = "2010-10-10";
            program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.Value = "2010-10-10";

            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_ADMISSAO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Value = "2010-10-10";

            program.VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA.Value = "2010-10-10";
            program.VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA.Value = "2010-10-10";
            program.VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_TIMESTAMP.Value = "2010-10-10";

            program.H_DTVENCTO1.Value = "2010-10-10";
            program.H_DT_MOV_ABERTO_2600.Value = "2010-10-10";

            program.TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO.Value = "2010-10-10";
            program.TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_INCLUSAO.Value = "2010-10-10";
            program.TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_RCAP.Value = "2010-10-10";

            program.VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_DIA_DEBITO.Value = 10;
            program.VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_LIBERACAO.Value = "2010-10-10";

            program.PARAGEEM.DCLPARM_AGENCI_EMP.PARAGEEM_DATA_INIVIGENCIA.Value = "2010-10-10";
            program.PARAGEEM.DCLPARM_AGENCI_EMP.PARAGEEM_DATA_TERVIGENCIA.Value = "2010-10-10";

            program.VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_DTH_INI_VIGENCIA.Value = "2010-10-10";
            program.VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_DTH_FIM_VIGENCIA.Value = "2010-10-10";
            program.VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_DTH_TIMESTAMP.Value = "2010-10-10";

            program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA.Value = "2010-10-10";
            program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INCLUSAO.Value = "2010-10-10";
            program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA.Value = "2010-10-10";

            program.VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO.Value = "2010-10-10";
            program.VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL.Value = "2010-10-10";

            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_ADMISSAO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.Value = 1;

            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTA_DECLINIO.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTFENAE.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Value = "2010-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_TITULAR.Value = "2010-10-10";

            program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.Value = "2010-10-10";

            program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MINVIGENCIA.Value = "2010-10-10";
            program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MAXVIGENCIA.Value = "2010-10-10";
            program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_DTAVERB.Value = "2010-10-10";
            program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_DTMVFDCAP.Value = "2010-10-10";

            program.NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.Value = 123;
            #endregion

            try { /*1*/ program.DB042_OPEN_C1PARGEREM_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0110_2600_VALIDAR_CONVENIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0802_2600_TRATA_REG_EMP_TP02_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0838_2600_TRATA_CNPJ_FILIAL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0844_2600_TRATA_CORRETOR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0846_2600_TRATA_FAIXAETA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0880_05_INICIO_DB_DECLARE_1(); program.R0880_05_INICIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0900_2600_OPEN_C2_TERMONIVEL_DB_DECLARE_1(); program.R0900_2600_OPEN_C2_TERMONIVEL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0894_2600_INSERE_PESSOFIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0010_2610_OPEN_C4SOLICITA_DB_DECLARE_1(); program.R0010_2610_OPEN_C4SOLICITA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0930_2600_UPDATE_VGSOLICITA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R9978_2600_VERIFICAR_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1118_2610_OPEN_C5RCAPCOMP_DB_DECLARE_1(); program.R1118_2610_OPEN_C5RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2910_2610_OPEN_C6VGRAMOCOMP_DB_DECLARE_1(); program.R2910_2610_OPEN_C6VGRAMOCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1123_2610_UPDATE_V1RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1124_2610_INSERT_V1RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1125_2610_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1300_2610_UPDATE_NUM_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2010_2610_CALCULA_PRMDIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2100_2610_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2360_2610_SELECT_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2500_2610_INSERT_PARCELVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2600_2610_INSERT_HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R2800_2610_INSERT_HISTCONTAVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R2960_2610_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R4070_2610_UPDT_SUBGRUPO_VGAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R4072_2610_UPDT_TERMO_ADESAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R4250_00_SELECT_PLANVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R4400_2610_INSERT_COMFEDCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R5000_00_SELECT_EMP_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.DB002_ACESSA_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.DB005_ACESSA_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.DB007_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.DB008_ACESSA_CONVSICOB_NSICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.DB010_ACESSA_MAX_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.DB012_ACESSA_CLIENTES_RAZAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.DB018_ALTERA_NUMERO_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.DB020_INCLUI_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.DB022_ALTERA_CLIENTE_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.DB024_INCLUI_CLIENTE_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.DB026_ACESSA_MAX_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.DB028_INCLUI_ENDERECOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.DB038_INCLUI_TERMO_ADESAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.DB040_INCLUI_VG_COMPL_TERMO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.DB080_OPEN_C3_VGMOVFUN_DB_DECLARE_1(); program.DB080_OPEN_C3_VGMOVFUN_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.DB044_ALTERA_PORTE_CLIENTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.DB046_INCLUI_VG_TERMO_NIVEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.DB050_ALTERA_PROP_SASSE_VIDA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.DB054_ACESSA_PARM_GERAIS_EMPRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.DB056_ACESSA_APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.DB060_ALTERA_TERMO_ADESAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.DB062_ACESSA_VG_GARANTIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.DB064_INCLUI_VG_COBER_TERMO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/ program.DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/ program.DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/ program.DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.DB072_INCLUI_V0RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/ program.DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.DB076_ACESSA_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/ program.DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/ program.DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.DB090_INCLUI_VGREPRESLEGAL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/ program.DB092_ACESSA_MAX_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/ program.DB094_INCLUI_PESSOA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/ program.DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*83*/ program.DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*84*/ program.DB100_ACESSA_RCAPS_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*85*/ program.DB102_ACESSA_RCAPCOMPL_A1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*86*/ program.DB104_ACESSA_SUBGRUPOS_VGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*87*/ program.DB106_ACESSA_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*88*/ program.DB108_ACESSA_PROPOSTAS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*89*/ program.DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*90*/ program.DB112_ACESSA_VG_COMPL_TERMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*91*/ program.DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*92*/ program.DB116_ACESSA_FATURAS_COUNT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*93*/ program.DB118_ALTERA_VGSOLICITAFATURA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*94*/ program.DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*95*/ program.DB122_ALTERA_SUBGRUPOSVGAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*96*/ program.DB124_ALTERA_COMISSOES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*97*/ program.DB126_ACESSA_RCAPS_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*98*/ program.DB128_ALTERA_RCAPS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*99*/ program.DB130_ACESSA_RCAPCOMPL_A2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*100*/ program.DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*101*/ program.DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*102*/ program.DB136_INCLUI_PROPOSTASVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*103*/ program.DB138_ACESSA_BANCOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*104*/ program.DB140_ALTERA_BANCOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*105*/ program.DB141_ACESSA_FATURAS_MIN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*106*/ program.DB142_ACESSA_FATURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*107*/ program.DB144_INCLUI_HISCONTPARCEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*108*/ program.DB146_ACESSA_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*109*/ program.DB148_ACESSA_VGCOBERTERMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*110*/ program.DB150_INCLUI_PRODUTOSVG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*111*/ program.C0010_CALL_SP_SZEMNL01_DB_CALL_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}