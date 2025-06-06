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
using static Code.BI6005B;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FileTests.Test_DB
{
    [Collection("BI6005B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI6005B_Tests_DB
    {
        private static string pData = "2020-01-01";
        private static string pDataM = "2020-01-02";
        private static string pHora = "15:15:15";

        [Fact]
        public static void BI6005B_Database()
        {
            var program = new BI6005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1(); program.R0900_00_DECLARE_V0BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.V0ENDO_DTINIVIG.Value = pData;
                program.R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1(); 
                program.R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.V0APCR_DTINIVIG.Value = pData;
                program.V0APCR_DTTERVIG.Value = pData;
                program.R1000_10_ANTIGA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0APCR_DTINIVIG.Value = pData;
                program.V0APCR_DTTERVIG.Value = pData;
                program.R1000_15_NOVA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/
                program.V0BILH_NUMBIL.Value = 80000000017;
                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0APCR_DTINIVIG.Value = pData;
                program.V0APCR_DTTERVIG.Value = pData;
                program.R1000_15_NOVA_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1000_15_FIM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1000_15_FIM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.V0COBA_DATA_INIVI.Value = pData;
                program.V0COBA_DATA_TERVI.Value = pData;
                program.R1000_15_FIM_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/ program.R1000_15_FIM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_15_FIM_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.V0ADIA_DTMOVTO.Value = pData;
                program.R1000_15_FIM_DB_INSERT_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*20*/ program.R1000_00_LEITURA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.V0FORM_DTMOVTO.Value = pData;
                program.V0FORM_DTVENCTO.Value = pData;
                program.R1000_15_FIM_DB_INSERT_4(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*22*/
                program.V0ENDO_DT_LIBER.Value = pData;
                program.V0ENDO_DTEMIS.Value = pData;
                program.V0ENDO_DTINIVIG.Value = pData;
                program.V0ENDO_DTTERVIG.Value = pDataM;
                program.V0ENDO_DTVENCTO.Value = pData;
                program.V0ENDO_DATARCAP.Value = pData;
                program.V0ENDO_DATPRO.Value = pData;
                program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*23*/
                program.V0HISR_DTMOVTO.Value = pData;
                program.R1000_15_FIM_DB_INSERT_5(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*24*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.V0APCR_DTINIVIG.Value = pData;
                program.R1050_00_TRATA_FUNDAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*27*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.V0APCR_DTINIVIG.Value = pData;
                program.V0APCR_DTTERVIG.Value = pData;
                program.R1050_00_TRATA_FUNDAO_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/
                program.V0APCC_DTINIVIG.Value = pData;
                program.V0APCC_DTTERVIG.Value = pData;
                program.R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*32*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ 
                program.V0HISP_DTMOVTO.Value = pData;
                program.V0HISP_HORAOPER.Value = pHora;
                program.V0HISP_DTVENCTO.Value = pData;
                program.V0HISP_DTQITBCO.Value = pData;
                program.R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*37*/ program.R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R3000_10_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R3000_10_CONTINUA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R3000_90_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R3000_10_CONTINUA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/
                program.V1COBI_DTINIVIG.Value = pData;
                program.R3000_10_CONTINUA_DB_SELECT_4(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*47*/ program.R3000_10_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ 
                program.V1SIST_DTMOVACB.Value = pData;
                program.R3000_10_CONTINUA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*49*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R3000_10_CONTINUA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R3000_10_CONTINUA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R3000_10_CONTINUA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R3000_10_CONTINUA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R3060_00_VERIFICA_CRTCA_PEND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/
                program.V0C396_DTMOVTO.Value = pData;
                program.R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*66*/ program.R8100_00_DECLARE_CBO_DB_DECLARE_1(); program.R8100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/
                program.V1RCAC_HORAOPER.Value = pHora;
                program.V1RCAC_DTMOVTO.Value = pData;
                program.R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*68*/
                program.V1RCAC_HORAOPER.Value = pHora;
                program.V1RCAC_DATARCAP.Value = pData;
                program.V1RCAC_DTCADAST.Value = pData;
                program.R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*69*/ program.R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/
                program.V0CROT_DTMOVABE.Value = pData;
                program.R3240_00_UPDATE_CROT_AP_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*71*/ program.R3250_00_UPDATE_CROT_RES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/
                program.V1APOL_NUMBIL.Value = 1;
                program.R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.R3290_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/
                program.TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.Value = pData;
                program.TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.Value = pData;
                program.R3300_00_INSERT_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*77*/ program.R3400_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.R3500_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.R4400_00_INSERT_COMFEDCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/ program.R5000_00_SELECT_EMP_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/ program.R9100_00_DECLARE_FCAP_DB_DECLARE_1(); program.R9100_00_DECLARE_FCAP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/ program.R9130_00_SELECT_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}