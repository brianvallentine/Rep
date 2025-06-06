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
using static Code.BI8005B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("BI8005B_Tests_DB")]
    public class BI8005B_Tests_DB
    {

        [Fact]
        public static void BI8005B_Database()
        {
            var program = new BI8005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0110_00_DECLARE_CBO_DB_DECLARE_1(); program.R0110_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.V1SIST_TIMESTAMP.Value = "2025-04-24 12:00:00";
                program.R0200_00_DECLARE_V0BILHETE_DB_DECLARE_1(); program.R0200_00_DECLARE_V0BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.V1BILP_CODPRODU.Value = 1;
                program.WWORK_RAMO_ANT.Value = 2;
                program.V0ENDO_DTINIVIG.Value = "2020-01-01";
                program.V0ENDO_DTINIVIG.Value = "2020-01-01";
                program.WWORK_OPCAO_ANT.Value = 1;
                program.R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1(); program.R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.V0ENDO_CODPRODU.Value = 1;
                program.R0250_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.WHOST_SIT_PROP_SIVPF.Value = "X";
                program.V0BILH_NUMBIL.Value = 123;
                program.R0250_00_LEITURA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0BILH_NUMBIL.Value = 123;
                program.R0260_00_SELECT_PROPOFID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.PRPFIDEL_NUM_IDENTIFICA.Value = 123;
                program.R0270_00_SELECT_PRPFIDCO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0BILH_NUMBIL.Value = 123;
                program.R0280_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.V0BILH_OPCAO_COBER.Value = 123;
                program.V0BILH_RAMO.Value = 1;
                program.R0290_00_SELECT_BILPLCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V0BILH_CODCLIEN.Value = 123; 
                program.R0310_00_SELECT_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.V0CLIE_CGCCPF.Value = 123;
                program.R0320_00_SELECT_GELIMRISCO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0BILH_OPCAO_COBER.Value = 0;
                program.V0BILH_RAMO.Value = 1;
                program.R0330_00_SELECT_BIL_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.PRPFIDEL_QTD_MESES.Value = 1;
                program.WHOST_DTINIVIG.Value =  "2020-01-01";
                program.R0350_00_VER_VIGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.WHOST_DTINIVIG.Value = "2020-01-01";
                program.R0350_00_VER_VIGENCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ 
                program.V1APOL_NUMBIL.Value = 1;
                program.R0370_00_SELECT_APOLICE_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.V1BILC_MODALIFR.Value = 123;
                program.V1BILC_CODPRODU.Value = 123;
                program.V1BILC_RAMOFR.Value = 0;
                program.V1BILC_OPCAO.Value = 1;
                program.R0380_00_SELECT_BILCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.V0RCAP_NRTIT.Value = 123;
                program.R0400_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.WHOST_PROD_MENSAL.Value = 1 ;
                program.WHOST_PROD_PUANTE.Value = 2;
                program.V1SIST_DTMOVABE.Value = "2020-01-01";
                program.V0CLIE_CGCCPF.Value = 123;
                program.R0420_00_ACUMULA_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.V0BILH_NUMBIL.Value = 123;
                program.R0420_00_ACUMULA_BILHETE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.V0APOL_ORGAO.Value = 123 ;
                program.V0BILH_RAMO.Value = 1;
                program.R0500_00_TRATA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                program.V0NAES_SEQ_APOL.Value = 1;
                program.WWORK_RAMO_ANT.Value = 1;
                program.V0APOL_ORGAO.Value = 1;
                program.R0500_00_TRATA_APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.V1BILC_MODALIFR.Value = 1;
                program.V1BILC_RAMOFR.Value = 1;
                program.V1BILC_OPCAO.Value = 1;
                program.R0500_00_TRATA_APOLICE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                program.V0APOL_CODCLIEN.Value = 1;
                program.V0APOL_NUM_APOL.Value = 2;
                program.V0APOL_NUM_ITEM.Value = 3;
                program.V0APOL_MODALIDA.Value = 4;
                program.V0APOL_ORGAO.Value = 5;
                program.V0APOL_RAMO.Value = 6;
                program.V0APOL_NUM_APO_ANT.Value = 7;
                program.V0APOL_NUMBIL.Value = 8;
                program.V0APOL_TIPSGU.Value = "X";
                program.V0APOL_TIPAPO.Value = "X";
                program.V0APOL_TIPCALC.Value = "X";
                program.V0APOL_PODPUBL.Value = "X";
                program.V0APOL_NUM_ATA.Value = 123;
                program.V0APOL_ANO_ATA.Value = 2020;
                program.V0APOL_IDEMAN.Value = "0";
                program.V0APOL_PCDESCON.Value = 123;
                program.V0APOL_PCIOCC.Value = 123;
                program.V0APOL_TPCOSCED.Value = "X" ;
                program.V0APOL_QTCOSSEG.Value = 123;
                program.V0APOL_PCTCED.Value = 1;
                program.V0APOL_COD_EMPRESA.Value = 1;
                program.V0APOL_CODPRODU.Value =1 ;
                program.V0APOL_TPCORRET.Value = "X";
                program.R0500_00_TRATA_APOLICE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.V0APOL_NUM_APOL.Value = 1;
                program.V0BILH_SITUACAO.Value = "X";
                program.V0BILH_NUMBIL.Value = 123;
                program.R0500_00_TRATA_APOLICE_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.V0BILH_DTQITBCO.Value = "2020-10-10";
                program.V1BILC_RAMOFR.Value = 1 ;
                program.R0500_00_TRATA_APOLICE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.V0ENDO_NUM_APOL.Value = 1;
                program.V0ENDO_NRENDOS.Value = 2;
                program.V0ENDO_CODSUBES.Value = 3;
                program.V0ENDO_FONTE.Value = 4;
                program.V0ENDO_NRPROPOS.Value = 5;
                program.V0ENDO_DATPRO.Value = "2020-01-01";
                program.V0ENDO_DT_LIBER.Value = "2020-01-01";
                program.V0ENDO_DTEMIS.Value = "2020-01-01";
                program.V0ENDO_NRRCAP.Value = 6;
                program.V0ENDO_VLRCAP.Value = 10.00;
                program.V0ENDO_BCORCAP.Value = 7;
                program.V0ENDO_AGERCAP.Value = 8;
                program.V0ENDO_DACRCAP.Value = "2020-01-01";
                program.V0ENDO_IDRCAP.Value = "9";
                program.V0ENDO_BCOCOBR.Value = 1;
                program.V0ENDO_AGECOBR.Value = 1;
                program.V0ENDO_DACCOBR.Value = "2020-01-01";
                program.V0ENDO_DTINIVIG.Value = "2020-01-01";
                program.V0ENDO_DTTERVIG.Value = "2020-01-01";
                program.V0ENDO_CDFRACIO.Value = 0;
                program.V0ENDO_PCENTRAD.Value = 1.00;
                program.V0ENDO_PCADICIO.Value = 1.00;
                program.V0ENDO_PRESTA1.Value = 1;
                program.V0ENDO_QTPARCEL.Value = 1;
                program.V0ENDO_QTPRESTA.Value = 1;
                program.V0ENDO_QTITENS.Value = 19;
                program.V0ENDO_CODTXT.Value = "1";
                program.V0ENDO_CDACEITA.Value = "X";
                program.V0ENDO_MOEDA_IMP.Value = 1;
                program.V0ENDO_MOEDA_PRM.Value = 2;
                program.V0ENDO_TIPO_ENDO.Value = "X";
                program.V0ENDO_COD_USUAR.Value = "X";
                program.V0ENDO_OCORR_END.Value = 1;
                program.V0ENDO_SITUACAO.Value = "X";
                program.V0ENDO_DATARCAP.Value = "2020-01-01";
                program.VIND_DATARCAP.Value = 1;
                program.V0ENDO_COD_EMPRESA.Value = 2;
                program.V0ENDO_CORRECAO.Value = "X";
                program.V0ENDO_ISENTA_CST.Value = "X";
                program.V0ENDO_DTVENCTO.Value = "2020-01-01";
                program.VIND_DTVENCTO.Value = 1;
                program.V0ENDO_CFPREFIX.Value = 1;
                program.VIND_CFPREFIX.Value = 1;
                program.V0ENDO_VLCUSEMI.Value = 1.00;
                program.VIND_VLCUSEMI.Value = 1;
                program.V0ENDO_RAMO.Value = 1;
                program.V0ENDO_CODPRODU.Value = 1;

                program.R0530_00_INCLUI_ENDOSSO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.V0PARC_NUM_APOL.Value = 1;
                program.V0PARC_NRENDOS.Value = 1;
                program.V0PARC_NRPARCEL.Value = 1;
                program.V0PARC_DACPARC.Value = "X";
                program.V0PARC_FONTE.Value = 1;
                program.V0PARC_NRTIT.Value = 1;
                program.V0PARC_PRM_TAR_IX.Value = 1;
                program.V0PARC_VAL_DES_IX.Value = 1;
                program.V0PARC_OTNPRLIQ.Value = 1;
                program.V0PARC_OTNADFRA.Value = 1;
                program.V0PARC_OTNCUSTO.Value = 1;
                program.V0PARC_OTNIOF.Value = 1;
                program.V0PARC_OTNTOTAL.Value = 1;
                program.V0PARC_OCORHIST.Value = 1;
                program.V0PARC_QTDDOC.Value = 1;
                program.V0PARC_SITUACAO.Value = "X";
                program.V0PARC_COD_EMPRESA.Value = 1;
                program.R0540_00_INCLUI_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.V0HISP_NUM_APOL.Value = 1;
                program.V0HISP_NRENDOS.Value = 1;
                program.V0HISP_NRPARCEL.Value = 1;
                program.V0HISP_DACPARC.Value = "X";
                program.V0HISP_DTMOVTO.Value = "2020-01-01";
                program.V0HISP_OPERACAO.Value = 1;
                program.V0HISP_HORAOPER.Value = "12:00:00";
                program.V0HISP_OCORHIST.Value = 1;
                program.V0HISP_PRM_TARIFA.Value = 1;
                program.V0HISP_VAL_DESCON.Value = 1;
                program.V0HISP_VLPRMLIQ.Value = 1;
                program.V0HISP_VLADIFRA.Value = 1;
                program.V0HISP_VLCUSEMI.Value = 1;
                program.V0HISP_VLIOCC.Value = 1;
                program.V0HISP_VLPRMTOT.Value = 1;
                program.V0HISP_VLPREMIO.Value = 1;
                program.V0HISP_DTVENCTO.Value = "2020-01-01";
                program.V0HISP_BCOCOBR.Value = 1;
                program.V0HISP_AGECOBR.Value = 1;
                program.V0HISP_NRAVISO.Value = 1;
                program.V0HISP_NRENDOCA.Value = 1;
                program.V0HISP_SITCONTB.Value = "x";
                program.V0HISP_COD_USUAR.Value = "x";
                program.V0HISP_RNUDOC.Value = 1;
                program.V0HISP_DTQITBCO.Value = "2020-01-01";
                program.VIND_DTQITBCO.Value = 1;
                program.V0HISP_COD_EMPRESA.Value = 1;
                program.R0550_00_INSERT_V0HISTOPARC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/
                program.V0HISP_COD_EMPRESA.Value = 1;
                program.V0COBA_NUM_APOL.Value = 2;
                program.V0COBA_NRENDOS.Value = 3;
                program.V0COBA_NUM_ITEM.Value = 4;
                program.V0COBA_OCORHIST.Value = 5;
                program.V0COBA_RAMOFR.Value = 6;
                program.V0COBA_MODALIFR.Value = 7;
                program.V0COBA_COD_COBER.Value = 8;
                program.V0COBA_IMP_SEG_IX.Value = 9;
                program.V0COBA_PRM_TAR_IX.Value = 10;
                program.V0COBA_IMP_SEG_VR.Value = 11;
                program.V0COBA_PRM_TAR_VR.Value = 12;
                program.V0COBA_PCT_COBERT.Value = 13;
                program.V0COBA_FATOR_MULT.Value = 14;
                program.V0COBA_DATA_INIVI.Value = "2020-01-01";
                program.V0COBA_DATA_TERVI.Value = "2020-01-01";
                program.V0COBA_COD_EMPRESA.Value = 1 ;
                program.V0COBA_SITUACAO.Value = "X" ;
                program.VIND_SITUACAO.Value = 1 ;
                program.R0560_00_INSERT_V0COBERAPOL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/
                program.V1FONT_PROPAUTOM.Value = 1;
                program.V0BILH_FONTE.Value = 2;
                program.R0600_00_MONTA_ENDOSSO01_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                program.V0ENDO_DTINIVIG.Value ="2020-01-01" ;
                program.R0600_00_MONTA_ENDOSSO01_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/
                program.V0ENDO_CODPRODU.Value = 1;
                program.V0ENDO_DTINIVIG.Value = "2020-01-01";
                program.R1066_00_TRATA_EVOGEPES016_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                program.V0ENDO_CODPRODU.Value = 1;
                program.V0ENDO_DTINIVIG.Value = "2020-01-01";
                program.R1067_00_TRATA_CORRETOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/
                program.V0APCR_NUM_APOL.Value = 1;  
                program.V0APCR_RAMOFR.Value = 2;    
                program.V0APCR_MODALIFR.Value = 3;  
                program.V0APCR_CODCORR.Value = 4;   
                program.V0APCR_CODSUBES.Value = 5;
                program.V0APCR_DTINIVIG.Value = "2020-01-01";
                program.V0APCR_DTTERVIG.Value = "2020-01-01" ;
                program.V0APCR_PCPARCOR.Value = 6;
                program.V0APCR_PCCOMCOR.Value = 6;
                program.V0APCR_TIPCOM.Value = "x";
                program.V0APCR_INDCRT.Value = "6";
                program.V0APCR_COD_EMPRESA.Value = 6;
                program.V0APCR_COD_USUARIO.Value = "X";
                program.R1068_00_INSERT_APOLCORRET_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/
                program.V0ENDO_CODPRODU.Value = 1;
                program.V0ENDO_DTINIVIG.Value =  "2020-01-01";
                program.R1070_00_TRATA_PRO_LABORE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/
                program.V0RCAP_FONTE.Value = 1;
                program.V0RCAP_NRRCAP.Value = 2;
                program.R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                program.V0APCC_NUM_APOL.Value = 1;
                program.V0APCC_CODCOSS.Value = 2;
                program.V0APCC_RAMOFR.Value = 3;
                program.V0APCC_DTINIVIG.Value = "2020-01-01";
                program.V0APCC_DTTERVIG.Value = "2020-01-01";
                program.V0APCC_PCPARTIC.Value = 12;
                program.V0APCC_PCCOMCOS.Value = 123;
                program.V0APCC_COD_EMPRESA.Value = 123;
                program.R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/
                program.V1NCOS_CONGENER.Value = 1;
                program.V1NCOS_ORGAO.Value =    1;
                program.R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/
                program.V0ORDC_NUM_APOL.Value = 1;
                program.V0ORDC_NRENDOS.Value  = 1;
                program.V0ORDC_CODCOSS.Value = 1;
                program.V0ORDC_ORDEM_CED.Value = 1;
                program.V0ORDC_COD_EMPRESA.Value = 1;
                program.R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ 
                program.V1NCOS_NRORDEM.Value = 1;
                program.V1NCOS_CONGENER.Value = 1;
                program.V1NCOS_ORGAO.Value = 1;  
                program.R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/
                program.V0APOL_QTCOSSEG.Value = 1;  
                program.V0APOL_PCTCED.Value = 1;    
                program.V0APOL_NUM_APOL.Value = 1;  
                program.R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.Value = 1;  
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.Value = 1;  
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = 1;  
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.Value = "X";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value =  "2020-01-01";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.Value = 100  ;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2020-01-01";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.Value = 1;
                program.VIND_DIADEBITO.Value = 2;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.Value = 3;
                program.VIND_AGENCIA.Value = 4;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.Value = 5;
                program.VIND_OPERACAO.Value = 6;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.Value =7;
                program.VIND_NUMCONTA.Value = 8;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.Value = 9;
                program.VIND_DIGCONTA.Value = 10;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.Value = 11;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = "2020-01-01";
                program.VIND_DTENVIO.Value = 13;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = "2020-01-01";
                program.VIND_DTRETORNO.Value = 14;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.Value = 1;
                program.VIND_CODRETORNO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.Value = 3;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.Value = "X";
                program.VIND_USUARIO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.Value = 123;
                program.VIND_REQUISICAO.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.Value = 123;
                program.VIND_CARTAO_CREDITO.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.Value = 123;
                program.VIND_SEQUENCIA.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.Value = 123;
                program.VIND_NUM_LOTE.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = "2020-01-01";
                program.VIND_DTCREDITO.Value = 123;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.Value = "X";
                program.VIND_STATUS.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.Value = 100;
                program.VIND_VLCREDITO.Value = 1;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO.Value = 123;
                program.R1155_00_TRATA_MOVDEBCC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_EMPRESA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_FONTE.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_PRODUTO.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_MATRICULA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA.Value = "X";
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_AGE_COBRANCA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPERACAO_CONTA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB.Value = 100;
                program.VIND_AGENCIA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB.Value = 100;
                program.VIND_OPERACAO.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB.Value = 100;
                program.VIND_NUMCONTA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB.Value = 100;
                program.VIND_DIGCONTA.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO.Value = 100;
                program.VIND_CARTAO_CREDITO.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO.Value = 100;
                program.VIND_DIADEBITO.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NR_CERTIF_AUTO.Value = "X";
                program.VIND_NRCERTIF.Value = 100;
                program.APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_MARGEM_COMERCIAL.Value = 123;
                program.R1160_00_INSERT_APOLCOBR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/
                program.GELMR_QTD_SEGUROS.Value = 123;
                program.GELMR_VLR_SOMA_IS.Value = 123;
                program.V0CLIE_CGCCPF.Value = 123;
                program.R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/
                program.V0CLIE_CGCCPF.Value = 123;
                program.V0BILH_RAMO.Value = 123;
                program.GELMR_QTD_SEGUROS.Value = 123;
                program.GELMR_VLR_SOMA_IS.Value = 123;
                program.R1500_00_INSERT_GELIMRISCO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/
                program.V0RCAP_OPERACAO.Value = 123;
                program.V0RCAP_FONTE.Value = 123;
                program.WHOST_NRRCAP.Value = 123;
                program.R3000_00_LIBERA_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/
                program.V0BILH_SITUACAO.Value = "X";
                program.V0BILH_NUMBIL.Value = 123;
                program.R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/
                program.V0BILH_NUMBIL.Value = 132;
                program.R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/
                program.V0BILH_FONTE.Value =123 ;
                program.R3170_00_UPDATE_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/
                program.V1FONT_PROPAUTOM.Value = 123;
                program.V0BILH_FONTE.Value = 123;
                program.R3170_00_UPDATE_BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/
                program.V1FONT_PROPAUTOM.Value = 123;
                program.V0BILH_FONTE.Value = 123;
                program.R3180_00_LE_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/
                program.V1RCAC_NRRCAPCO.Value = 123;
                program.V1RCAC_OPERACAO.Value = 1;
                program.V1RCAC_HORAOPER.Value = "12:00:00";
                program.V1RCAC_DTMOVTO.Value = "2020-01-01";
                program.V1RCAC_NRRCAP.Value = 123;
                program.V1RCAC_FONTE.Value = 1;
                program.R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/
                program.V1RCAC_FONTE.Value = 1;
                program.V1RCAC_NRRCAP.Value = 1;
                program.V1RCAC_NRRCAPCO.Value = 1;
                program.V1RCAC_OPERACAO.Value = 1;
                program.V1SIST_DTMOVACB.Value = "2020-01-01";
                program.V1RCAC_HORAOPER.Value = "00:00:00";
                program.V1RCAC_SITUACAO.Value = "x";
                program.V1RCAC_BCOAVISO.Value = 1;
                program.V1RCAC_AGEAVISO.Value = 1;
                program.V1RCAC_NRAVISO.Value = 1;
                program.V1RCAC_VLRCAP.Value = 1;
                program.V1RCAC_DATARCAP.Value = "2020-01-01";
                program.V1RCAC_DTCADAST.Value = "2020-01-01";
                program.V1RCAC_SITCONTB.Value = "X";
                program.V1RCAC_COD_EMPRESA.Value = 1;
                program.R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/
                program.V1RCAC_VLRCAP.Value = 100 ;
                program.V1RCAC_BCOAVISO.Value = 1;
                program.V1RCAC_AGEAVISO.Value = 2;
                program.V1RCAC_NRAVISO.Value = 3;
                program.R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/
                program.V0PARC_NUM_APOL.Value = 3;
                program.V0PARC_NRPARCEL.Value = 3;
                program.V0PARC_NRENDOS.Value = 3;
                program.V0RCAP_NRRCAP.Value = 3;
                program.V0RCAP_FONTE.Value = 3;
                program.R3210_00_ALTERA_RCAPS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/
                program.V0BILH_CODCLIEN.Value = 1;
                program.R3210_20_CROT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/
                program.V0BILH_CGCCPF.Value = 1;    
                program.R3210_20_CROT_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/
                program.V0CROT_DTMOVABE.Value = "2020-01-01" ;
                program.V0CROT_BILH_AP.Value = "x";
                program.V0BILH_CGCCPF.Value = 123;
                program.R3240_00_UPDATE_CROT_AP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/
                program.V0CROT_BILH_RES.Value = "X" ;
                program.V0CROT_DTMOVABE.Value = "2020-01-01";
                program.V0BILH_CGCCPF.Value = 123;
                program.R3250_00_UPDATE_CROT_RES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/
                program.V0CROT_CGCCPF.Value = 123456 ;
                program.V0CROT_BILH_AP.Value = "X";
                program.V0CROT_BILH_RES.Value = "X";
                program.V0CROT_BILH_VDAZUL.Value = "X";
                program.V0CROT_DTMOVABE.Value = "2020-01-01";
                program.R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/
                program.V0BILH_NUMBIL.Value = 123;
                program.V1SIST_DTMOVABE.Value = "2020-01-01";
                program.R4400_00_INSERT_COMFEDCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/
                program.VG078.DCLVG_ANDAMENTO_PROP.VG078_NUM_CERTIFICADO.Value = 123;
                program.VG078.DCLVG_ANDAMENTO_PROP.VG078_COD_USUARIO.Value = "x";
                program.R9997_00_INSERE_ANDAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}