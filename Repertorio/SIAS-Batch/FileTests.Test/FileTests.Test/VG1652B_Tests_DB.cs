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
using static Code.VG1652B;
using Dclgens;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("VG1652B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG1652B_Tests_DB
    {

        [Fact]
        public static void VG1652B_Database()
        {
            var program = new VG1652B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0090_00_SELECT_PARAMRAM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                        program.WHOST_DATA_HOJE.Value = "2025-02-07"; 
                        program.WHOST_DATA_HOJE_MAIS15.Value = "2025-02-22";
                        program.WHOST_DIA_HOJE_MAIS15.Value = 22;
                        program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2025-01-27";
                        program.WHOST_DATA_FATURAMENTO.Value = "2025-01-27";
                        program.WHOST_DTTERVIG.Value = "2025-02-28";
                        program.R0100_00_SELECT_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }


            try { /*3*/ program.R0900_00_DECLA_PROPOVA_DB_DECLARE_1(); program.R0900_00_DECLA_PROPOVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 109300002357; 
                        program.WHOST_DATA_FAT_FIM.Value = "2014-04-16";
                        program.R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1(); program.R2100_00_DECLARE_SEGURVGA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                       program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 1627;
                       program.WHOST_DTINIVIG.Value = "1994-05-10";
                       program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           
            try { /*6*/
                       program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.Value = 4485405;
                       program.WHOST_DATA_FAT_FIM.Value = "2014-04-17";
                       program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.Value = 7457254811;
                       program.WHOST_NUM_PARCELA.Value = 1;
                       program.R2130_00_ACUMULA_IS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/
                       program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2014-04-17";
                       program.VIND_DATA_FATURA_U.Value = 1;
                       program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA.Value = 736215;
                       program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE.Value = 1;
                       program.R2130_00_ACUMULA_IS_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try {/*8*/   program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 6501000001;
                         program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.Value = 0;
                         program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.Value = 1;
                         program.APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.Value = 68;
                         program.R2140_00_SELECT_APOLICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 6501000001;
                        program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.Value = 0;
                        program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.Value = 1;
                        program.APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.Value = 68;
                        program.R2140_00_SELECT_APOLICOB_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 6501000001;
                        program.R2150_00_SELECT_APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*11*/
                        program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.Value = 1;
                        program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.Value = 81010000001;
                        program.R2200_00_SELECT_SUBGVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }


            try
            { /*12*/
                    program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.Value =1;
                    program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 100000266;
                    program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.Value = 1;                
                    program.R2300_00_SELECT_COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 5555884;
                         program.WHOST_DTINIVIG.Value = "1901-01-02";
                         program.R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 1627;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.Value = 5;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Value = "1994-05-10";
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.Value = "9999-12-31";
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS.Value = 1;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO.Value = 106;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT.Value = 240.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ.Value = 0;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG.Value = 0.00;
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG.Value = 0.00;
                        program.R2900_00_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }


            try { /*15*/
                         program.WHOST_DTINIVIG.Value = "9999-12-31";
                         program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 1627;
                         program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.Value = 1;
                         program.R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 1627;
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.Value = 1;
                        program.R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/
                        program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.Value = 1;
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Value = "2010-08-01";
                        program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 24;
                        program.R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}