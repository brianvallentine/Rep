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
using static Code.BI0005B;

namespace FileTests.Test_DB
{
    [Collection("BI0005B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0005B_Tests_DB
    {

        [Fact]
        public static void BI0005B_Database()
        {
            var program = new BI0005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1(); program.R0900_00_DECLARE_V0BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.V0ENDO_DTINIVIG.Value = "2025-03-11";
                program.R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1(); program.R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1000_10_ANTIGA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.V0APCR_NUM_APOL.Value = 0101400000002;
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1000_15_NOVA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.V0APCR_NUM_APOL.Value = 0101400000002;
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1000_15_NOVA_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.V0APCR_NUM_APOL.Value = 000001;
                program.V0PARC_NRENDOS.Value = 000001;
                program.R1000_15_FIM_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1000_15_FIM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.V0APCR_NUM_APOL.Value = 000004;
                program.V0COBA_DATA_INIVI.Value = "2025-03-11";
                program.V0COBA_DATA_TERVI.Value = "2025-03-11";
                program.R1000_15_FIM_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1000_15_FIM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_15_FIM_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.V0APOL_CODPRODU.Value = 001;
                program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.V0ADIA_DTMOVTO.Value = "2025-03-11";
                program.R1000_15_FIM_DB_INSERT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.V0BILH_NUMBIL.Value = 80000000017;
                program.R1000_00_LEITURA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.V0FORM_DTMOVTO.Value = "2025-03-11";
                program.V0FORM_DTVENCTO.Value = "2025-03-11";
                program.R1000_15_FIM_DB_INSERT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.V0ENDO_NUM_APOL.Value = 000005;
                program.V0ENDO_DATPRO.Value = "2025-03-11";
                program.V0ENDO_DT_LIBER.Value = "2025-03-11";
                program.V0ENDO_DTEMIS.Value = "2025-03-11";
                program.V0ENDO_DTINIVIG.Value = "2025-03-10";
                program.V0ENDO_DTTERVIG.Value = "2025-03-11";
                program.V0ENDO_DATARCAP.Value = "2025-03-11";
                program.V0ENDO_DTVENCTO.Value = "2025-03-11";
                program.VIND_DTVENCTO.Value = 03;
                program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*23*/
                program.V0HISR_DTMOVTO.Value = "2025-03-11";
                program.R1000_15_FIM_DB_INSERT_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*26*/
                program.V0APCR_NUM_APOL.Value = 000006;
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1050_00_TRATA_FUNDAO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*28*/
                program.V0APCR_NUM_APOL.Value = 000007;
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1050_00_TRATA_FUNDAO_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*30*/
                program.V0APCR_NUM_APOL.Value = 000008;
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1051_00_TRATA_FUNDAO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*31*/
                program.V0APCR_NUM_APOL.Value = 000009;
                program.V0APCR_DTINIVIG.Value = "2025-03-11";
                program.V0APCR_DTTERVIG.Value = "2025-03-11";
                program.R1051_00_TRATA_FUNDAO_DB_INSERT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*33*/
                program.V0APCC_NUM_APOL.Value = 000010;
                program.V0APCC_DTINIVIG.Value = "2025-03-11";
                program.V0APCC_DTTERVIG.Value = "2025-03-11";
                program.R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R1100_00_SELECT_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R1200_00_SELECT_GELIMRISCO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R1300_00_SELECT_BIL_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R1400_00_UPDATE_GELIMRISCO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*42*/
                program.V0CLIE_CGCCPF.Value = 21276811004;
                program.R1500_00_INSERT_GELIMRISCO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*43*/
                program.V0HISP_NUM_APOL.Value = 000011;
                program.V0HISP_DTMOVTO.Value = "2025-03-11";
                program.V0HISP_HORAOPER.Value = "00:00:00";
                program.V0HISP_DTVENCTO.Value = "2025-03-11";
                program.V0HISP_DTQITBCO.Value = "2025-03-11";
                program.VIND_DTQITBCO.Value = 03;
                program.R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R3000_10_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R3000_10_CONTINUA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R3000_90_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R3000_10_CONTINUA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*53*/
                program.V1COBI_DTINIVIG.Value = "2025-03-11";
                program.R3000_10_CONTINUA_DB_SELECT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R3000_10_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*55*/
                program.V1SIST_DTMOVACB.Value = "2025-03-11";
                program.R3000_10_CONTINUA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R3000_10_CONTINUA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R3000_10_CONTINUA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.R3000_10_CONTINUA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.R3000_10_CONTINUA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/ program.R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/ program.R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*71*/
                program.V0C396_DTMOVTO.Value = "2025-03-11";
                program.R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.R8100_00_DECLARE_CBO_DB_DECLARE_1(); program.R8100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*73*/
                program.V1RCAC_HORAOPER.Value = "00:00:00";
                program.V1RCAC_DTMOVTO.Value = "2025-03-11";
                program.R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*74*/
                program.V1SIST_DTMOVACB.Value = "2025-03-11";
                program.V1RCAC_HORAOPER.Value = "00:00:00";
                program.V1RCAC_DATARCAP.Value = "2025-03-11";
                program.V1RCAC_DTCADAST.Value = "2025-03-11";
                program.R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*76*/
                program.V0CROT_DTMOVABE.Value = "2025-03-11";
                program.R3240_00_UPDATE_CROT_AP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*77*/
                program.V0CROT_DTMOVABE.Value = "2025-03-11";
                program.R3250_00_UPDATE_CROT_RES_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*78*/
                program.V0CROT_CGCCPF.Value = 56798987623;
                program.V0CROT_DTMOVABE.Value = "2025-03-11";
                program.R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*79*/
                program.V1APOL_NUMBIL.Value = 6501000001;
                program.R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*80*/
                program.V1SIST_DTMOVABE.Value = "2025-03-11";
                program.R3290_10_INSERT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*81*/
                program.MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.Value = 180011534163;
                program.TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.Value = "2025-03-11";
                program.TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.Value = "2025-03-11";
                program.V1SIST_DTMOVABE.Value = "2025-03-11";
                program.R3300_00_INSERT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*82*/
                program.V1SIST_DTMOVABE.Value = "2025-03-11";
                program.R3400_10_INSERT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*83*/
                program.V1SIST_DTMOVABE.Value = "2025-03-11";
                program.R3500_10_INSERT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*84*/
                program.V1SIST_DTMOVABE.Value = "2025-03-11";
                program.R4400_00_INSERT_COMFEDCA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}