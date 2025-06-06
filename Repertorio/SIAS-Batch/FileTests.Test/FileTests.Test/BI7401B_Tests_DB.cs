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
using static Code.BI7401B;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("BI7401B_Tests_DB")]
    public class BI7401B_Tests_DB
    {

        [Fact]
        public static void BI7401B_Database()
        {
            var program = new BI7401B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.V1SIST_DTMOVABE_1Y.Value = "2020-01-01";
                program.R0200_00_DECLARE_RELATORI_DB_DECLARE_1(); program.R0200_00_DECLARE_RELATORI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R2200_00_DECLARE_RCAPCOMP_DB_DECLARE_1(); program.R2200_00_DECLARE_RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.Value = 1;   
                program.R0230_00_SELECT_APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.Value = 2;  
                program.R0240_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.Value = 123;
                program.R0250_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.Value = 123;
                program.R0325_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ 
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.Value = 3;   
                program.R0330_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.Value = 12;
                program.R0335_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.Value = 123;
                program.R0340_00_SELECT_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.Value = 123;
                program.R0345_00_SELECT_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0350_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.Value = 123;
                program.R0370_00_SELECT_PARCEHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.Value = 123;
                program.R0410_00_SELECT_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.Value = 123;
                program.R0420_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.Value = 123;
                program.R0440_00_UPDATE_RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.Value = 123;
                program.R0450_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.Value = "1";
                program.RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.Value = "2";
                program.RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.Value = 123;
                program.R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.Value ="2020-01-01" ;
                program.VIND_NULL01.Value = 1;
                program.BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.Value = 123;
                program.R1040_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.Value = "1";
                program.RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.Value = 1;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.Value = 123;
                program.R1330_00_UPDATE_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.Value = 123;
                program.R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.Value = 1;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.Value = 12;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.Value = 3;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.Value = 1;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value ="2020-01-01" ;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.Value = "X";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.Value = 1;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.Value = 2;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.Value = 123;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.Value = 120.32;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2020-10-10";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.Value = "2020-01-01";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.Value = "1";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.Value = 1;
                program.VIND_NULL01.Value = 1;
                program.R1350_00_INSERT_RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                program.APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.Value = 1;
                program.APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.Value = 1;
                program.R1430_00_SELECT_NUMERO_AES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.Value = 1;
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.Value = 2;
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.Value = 3;
                program.R1440_00_UPDATE_NUMERO_AES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.Value =1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.Value = 2;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.Value = 3;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = 4;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 5;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 6;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.Value = 7;
                program.R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 2;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.Value = 3;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.Value = "4";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = "2026-01-01";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = 2;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.Value = 2;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.Value = 3;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.Value = 4;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.Value = 200;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.Value = 100;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.Value = 150;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.Value = 800;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = "2026-01-01";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.Value = 2;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.Value = 123;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.Value = "2";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.Value = "X";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = "2026-01-01";
                program.VIND_NULL01.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.Value = 2;
                program.VIND_NULL02.Value = 1;
                program.R1550_00_INSERT_PARCEHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 12;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.Value = 1;
                program.R1560_00_UPDATE_PARCELAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 2;
                program.R1570_00_UPDATE_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.V1SIST_DTMOVABE_1Y.Value = "2020-01-01";
                program.R2600_00_DECLARE_RELATORI_DB_DECLARE_1(); program.R2600_00_DECLARE_RELATORI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.Value = 1;
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.Value = 2;
                program.R2250_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/
                program.RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.Value = "1";
                program.RCAPS.DCLRCAPS.RCAPS_COD_FONTE.Value = 1;
                program.RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.Value = 123;
                program.R2530_00_UPDATE_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/
                program.RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.Value = 1;
                program.RCAPS.DCLRCAPS.RCAPS_COD_FONTE.Value = 2;
                program.RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.Value = 3;
                program.R2540_00_UPDATE_RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R2650_00_DECLARE_RELATORI_DB_DECLARE_1(); program.R2650_00_DECLARE_RELATORI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/
                program.APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.Value = 1;
                program.APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.Value = 2;
                program.R3030_00_SELECT_NUMERO_AES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ 
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANC_RESTI.Value = 1;
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.Value = 1;
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.Value = 1;
                program.R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ 
                program.BILHETE.DCLBILHETE.BILHETE_FONTE.Value = 1; 
                program.R3050_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/
                program.FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = 1;
                program.BILHETE.DCLBILHETE.BILHETE_FONTE.Value = 2;
                program.R3060_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ 
                program.FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = 1;
                program.BILHETE.DCLBILHETE.BILHETE_FONTE.Value =2;  
                program.R3070_00_UPDATE_FONTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1;    
                program.R3100_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1;
                program.R3110_00_UPDATE_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1246;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.Value = 745;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.Value = 2;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.Value = 3;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.Value = 4;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.Value = 5;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.Value = "2020-01-01";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.Value = "2020-01-01";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.Value = "2020-01-01";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP.Value = 174;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP.Value = 2;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.Value = 3;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA.Value = 2;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Value = "2020-01-01";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.Value =000;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.Value = 0;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.Value = "x";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.Value = "2020-01-01";
                program.VIND_DATA_RCAP.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA.Value = 1;
                program.VIND_COD_EMPRESA.Value = 2;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO.Value = "x";
                program.VIND_TIPO_CORRECAO.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO.Value = "x";
                program.VIND_ISENTA_CUSTO.Value = 54;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.Value = "2020-01-01";
                program.VIND_DTVENCTO.Value =54;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX.Value = 55;
                program.VIND_COEF_PREFIX.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO.Value =100;
                program.VIND_VAL_CUSTO.Value = 100;
                program.R3120_00_INSERT_ENDOSSOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.Value = 12;
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.Value =12;
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.Value = 0;
                program.PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA.Value = "0";
                program.PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE.Value = 1;
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO.Value = 688;
                program.PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.Value = 1;
                program.PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX.Value = 2;
                program.PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX.Value = 3;
                program.PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX.Value = 4;
                program.PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX.Value = 5;
                program.PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX.Value = 6;
                program.PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.Value = 7;
                program.PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.Value = 8;
                program.PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.Value = 9;
                program.PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.Value = "10";
                program.PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA.Value =11;
                program.VIND_NULL01.Value = 12;
                program.PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA.Value = "0";
                program.VIND_NULL02.Value = 13;
                program.R3130_00_INSERT_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 12;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 12;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.Value = "0";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = "2025-11-11";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.Value =0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = "2025-11-11";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.Value =0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.Value = "0";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.Value = "0";
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = "2025-11-11";
                program.VIND_NULL01.Value = 0;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.Value = 0;
                program.VIND_NULL02.Value = 0;
                program.R3150_00_INSERT_PARCEHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1358;
                program.R3200_00_SELECT_APOLICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.Value = 156;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.Value = 65;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.Value = 4;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.Value = 6;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.Value = 8;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.Value = 5;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.Value = 5;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.Value =58;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.Value = 85;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.Value = 85;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.Value = 8;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.Value = 8;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.Value = 8;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Value = "2020-01-01";
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.Value = 0;
                program.VIND_NULL01.Value = 0;
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.Value = "0";
                program.VIND_NULL02.Value = 1;
                program.R3210_00_INSERT_APOLICOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}