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
using static Code.VF0851B;

namespace FileTests.Test_DB
{
    [Collection("VF0851B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class VF0851B_Tests_DB
    {

        [Fact]
        public static void VF0851B_Database()
        {
            var program = new VF0851B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_DECLARE_1(); program.R0000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.V1SIST_DTCORMENOQD.Value = "2020-01-01";
                program.R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1(); program.R1000_00_PROCESSA_REGISTRO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.V0BANC_NRTIT.Value = 1;
                program.R0000_00_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.V0PROP_NRCERTIF.Value = 1 ;
                program.R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1(); program.R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.R1100_00_ACUMULA_ATRASO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                 program.V0PROP_NRCERTIF.Value =1 ;
                 program.V0PARC_NRPARCEL.Value = 1;
                 program.R1100_00_ACUMULA_ATRASO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.V0HCOB_NRTIT.Value = 1;
                program.R1100_00_ACUMULA_ATRASO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.V0PARC_NRPARCEL.Value = 1;
                program.R1100_00_ACUMULA_ATRASO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ 
                program.V0PROP_NRCERTIF.Value = 1;
                program.R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.V0EVEN_NRPARCEL.Value = 1;
                program.V0HCOB_NRTIT.Value = 1;
                program.R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0PROP_NRCERTIF.Value = 1;
                program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.V0PROP_FONTE.Value = 1;
                program.R1300_20_LOOP_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.V0FONT_PROPAUTOM.Value = 1;
                program.V0PROP_FONTE.Value = 1;
                program.R1300_20_LOOP_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.V0PROP_NUM_APOLICE.Value = 1;   
                program.V0PROP_CODSUBES.Value = 1;
                program.V0PROP_FONTE.Value=1;
                program.V0FONT_PROPAUTOM.Value=1;
                program.V0PROP_NRCERTIF.Value = 1;
                program.V0SEGU_TPINCLUS.Value = "x";
                program.V0PROP_CODCLIEN.Value = 1;
                program.V0SEGU_AGENCIADOR.Value = 1;
                program.V0OPCP_PERIPGTO.Value = 1;
                program.V0COBA_IMPMORNATU.Value = 1;
                program.V0COBA_IMPMORACID.Value = 1;
                program.V0COBA_IMPINVPERM.Value = 1;
                program.V0COBA_IMPDIT.Value = 1;
                program.V0COBA_PRMVG.Value = 1;
                program.V0COBA_PRMAP.Value = 1;
                program.V0FATC_DTREF.Value = "2020-01-01";
                program.V0MOVI_DTMOVTO.Value = "2020-01-01";
                program.R1300_20_LOOP_PROPOSTA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                  program.V0MOVI_DTMOVTO.Value = "2020-01-01";
                  program.V0PROP_NRCERTIF.Value = 1;
                  program.R1300_00_CANCELA_FALTA_PG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                  program.V0PROP_NRCERTIF.Value = 1;
                  program.V0HCOB_NRTIT.Value = 1;
                  program.R1300_20_LOOP_PROPOSTA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                  program.V0PROP_NRCERTIF.Value = 1;
                  program.WHOST_NRPARCEL.Value = 1;
                  program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                  program.V0PROP_NUM_APOLICE.Value = 1;
                  program.V0PROP_CODSUBES.Value = 1;
                  program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ 
                  program.V0PROP_QTDPARATZ.Value = 1;
                  program.V0PROP_NRCERTIF.Value = 1;
                  program.R1400_00_EMITE_AVISO_ATRASO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                  program.V0PROP_NRCERTIF.Value = 1;
                  program.V0HCOB_NRPARCEL.Value = 1;
                  program.V0BANC_NRTIT.Value = 1;
                  program.V0HCOB_DTVENCTO.Value = "2020-01-01";
                  program.WHOST_VLPREMIO.Value = 1;
                  program.V0OPCP_OPCAOPAG.Value = "x";
                  program.V0HCOB_CODOPER.Value = 1 ;
                  program.R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                 program.V0PROP_CODPRODU.Value = 1;
                 program.R1400_00_EMITE_AVISO_ATRASO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                 program.V0PROP_NUM_APOLICE.Value = 1 ;
                 program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ 
                 program.V0PROP_NRCERTIF.Value = 1;
                 program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ 
                 program.V0BANC_NRTIT.Value = 1;
                 program.V0COMP_NRPARCEL.Value = 1;
                 program.V0COMP_CODOPER.Value = 1;
                 program.V0COMP_PRMDIFVG.Value = 1;
                 program.V0COMP_PRMDIFAP.Value = 1;
                 program.R1410_00_MONTA_TITULO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                 program.V0PROP_NUM_APOLICE.Value = 123;
                 program.V0SEGU_OCORHIST.Value = 1;
                 program.V0SEGU_ITEM.Value = 1;
                 program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                 program.V0PROP_NUM_APOLICE.Value = 123;
                 program.V0SEGU_OCORHIST.Value= 1;
                 program.V0SEGU_ITEM.Value = 1;
                 program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.V0PROP_NRCERTIF.Value = 123;
                program.R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1(); program.R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/
                 program.V0PROP_NUM_APOLICE.Value = 123456;
                 program.V0SEGU_OCORHIST.Value = 1;
                 program.V0SEGU_ITEM.Value = 1;  
                 program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/
                 program.V0PROP_NUM_APOLICE.Value = 123;
                 program.V0SEGU_OCORHIST.Value = 1;
                 program.V0SEGU_ITEM.Value = 1;
                 program.R1300_00_CANCELA_FALTA_PG_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                 program.V0BANC_NRTIT.Value = 123;
                 program.V0DIFP_NRPARCEL.Value = 1;
                 program.V0DIFP_CODOPER.Value = 1;
                 program.V0DIFP_PRMDIFVG.Value = 1;
                 program.V0DIFP_PRMDIFAP.Value  = 1;
                 program.R1510_00_MONTA_DIFERENCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/
                 program.V0PROP_NRCERTIF.Value = 123;
                 program.V0PARC_NRPARCEL.Value = 123;
                 program.V0PARC_OCORHIST.Value = 1;
                 program.V0OPCP_AGECTADEB.Value = 1;
                 program.V0OPCP_OPRCTADEB.Value = 1;
                 program.V0OPCP_NUMCTADEB.Value = 123456;
                 program.V0OPCP_DIGCTADEB.Value = 1;
                 program.V0HCOB_DTVENCTO.Value = "2020-01-01";
                 program.V0PARC_VLPRMTOT.Value = 100;
                 program.V0CONV_CODCONV.Value = 1;
                 program.R1600_00_GERA_DEBITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                 program.V0PARC_OCORHIST.Value = 1;
                 program.V0PROP_NRCERTIF.Value = 123;
                 program.V0PARC_NRPARCEL.Value = 123;
                 program.R1600_00_GERA_DEBITO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/
                 program.V0PROP_NRCERTIF.Value = 123;
                 program.V0PARC_NRPARCEL.Value = 1;
                 program.R1700_00_QUITA_ATRASADA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/
                 program.V0EVEN_NRCERTIF.Value = 123456;
                 program.R2000_00_GERA_EVENTO_DB_DECLARE_1(); program.R2000_00_GERA_EVENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/
                 program.V0PARC_NRPARCEL.Value = 123;
                 program.V0PARC_PRMVG.Value = 123;
                 program.V0PARC_PRMAP.Value = 123;
                 program.V0PROP_NRCERTIF.Value = 123;
                 program.R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                 program.V0PROP_NRCERTIF.Value = 123456;
                 program.V0DIFP_NRPARCELDIF.Value = 123;
                 program.V0DIFP_CODOPER.Value = 1;
                 program.V0DIFP_DTVENCTO.Value = "2020-01-01";
                 program.V0DIFP_PRMDIFVG.Value = 1;
                 program.V0DIFP_PRMDIFAP.Value = 2;
                 program.R1760_00_APROPRIA_DIFERENCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/
                 program.V0PARC_NRPARCEL.Value = 123;
                 program.V0PROP_NRCERTIF.Value = 123;
                 program.R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/
                 program.V0PROP_CODCLIEN.Value = 123;
                 program.R1800_00_VERIFICA_REPASSES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/
                 program.V0PROP_NRCERTIF.Value = 12346;
                 program.V0RSAF_DTREFER.Value = "2020-01-01";
                 program.R1900_00_REPASSA_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/
                 program.V0PROP_CODCLIEN.Value = 1;
                 program.V0RSAF_DTREFER.Value = "2020-01-01";
                 program.V0PROP_NRCERTIF.Value = 123;
                 program.V0PARC_NRPARCEL.Value = 123 ;
                 program.V0SAFC_VLCUSTSAF.Value = 100;
                 program.V0PARC_DTVENCTO.Value = "2020-01-01";
                 program.VIND_DTMOVTO.Value =1;
                 program.R1900_00_REPASSA_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/
                 program.V0PLAC_CODPDT.Value = 1;
                 program.R2100_00_GERA_EVENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/
                 program.V0PDVF_OCORHIST.Value = 1;
                 program.V0PLAC_CODPDT.Value = 1;
                 program.R2100_00_GERA_EVENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/
                  program.V0PLAC_CODPDT.Value = 1;
                  program.V0PDVF_OCORHIST.Value = 1;
                  program.V0EVEN_NRCERTIF.Value = 123;
                  program.V0EVEN_NRPARCEL.Value = 123;
                  program.V0EVEN_CODEVEN.Value = 1;
                  program.V0EVEN_CODOPER.Value = 2;
                  program.V1SIST_DTMOVABE.Value = "2020-01-01";
                  program.V0EVEN_DTVENCTO.Value = "2020-01-01";
                  program.V0EVEN_VLPRMTOT.Value = 100; 
                  program.R2100_00_GERA_EVENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}