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
using static Code.CB0009B;
using Castle.DynamicProxy;

namespace FileTests.Test_DB
{
    [Collection("CB0009B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class CB0009B_Tests_DB
    {
        private static string pData = "2023-01-01";

        [Fact]
        public static void CB0009B_Database()
        {
            var program = new CB0009B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLARE_V0AGENCIAS_DB_DECLARE_1(); program.R0200_00_DECLARE_V0AGENCIAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0400_00_DECLARE_V0BILHETE_DB_DECLARE_1(); program.R0400_00_DECLARE_V0BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0500_00_DECLARE_V0ERRO_DB_DECLARE_1(); program.R0500_00_DECLARE_V0ERRO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0451_00_SELECT_BI_BIL_ACAT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0460_00_SELECT_V0RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0460_00_SELECT_V0RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0470_00_SELECT_V0COMISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2810_00_DECLARE_V0ERRO_DB_DECLARE_1(); program.R2810_00_DECLARE_V0ERRO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0565_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0575_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0610_00_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0CLIE_DTNASC.Value = pData;
                program.R0620_00_TRATA_ANO_CLIENTE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R0665_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ 
                program.V0BILH_DTQITBCO.Value = pData;
                program.R0900_00_SELECT_V0COBERTURA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*17*/ program.R0910_00_SELECT_V0COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0920_00_SELECT_V0COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0930_00_SELECT_V0COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0940_00_SELECT_V0COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1510_00_SELECT_V0ERRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1515_00_SELECT_V0ERRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1550_00_SELECT_SEQ_CRTCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2100_00_UPDATE_V0COFENAE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2230_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.V0RCOM_DATARCAP.Value = pData;
                program.V0SIST_DTMOVABE.Value = pData;
                program.R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*28*/ 
                program.V0RCOM_DTMOVTO.Value = pData;
                program.R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/ program.R2400_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R2851_00_DECLARE_V0ERRO_DB_DECLARE_1(); program.R2851_00_DECLARE_V0ERRO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R3010_00_DECLARE_V0COBERTURA_DB_DECLARE_1(); program.R3010_00_DECLARE_V0COBERTURA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                program.V0SIST_DTLIBERA.Value = pData;
                program.R7100_00_DECLARE_V1BILHETE_DB_DECLARE_1(); 
                program.R7100_00_DECLARE_V1BILHETE_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*34*/ 
                program.V0FOLL_DTQITBCO.Value = pData;
                program.V0RCOM_DTCADAST.Value = pData;
                program.R4100_00_INSERT_V0RCAPCOMP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*35*/ program.R4150_00_UPDATE_V0RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R4200_00_UPDATE_V0FOLLOWUP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ 
                program.V0CFEN_DTCREDITO.Value = pData;
                program.V0CFEN_DTQITBCO.Value= pData;
                program.V0CFEN_DTMOVTO.Value = pData;
                program.V0CFEN_DTPAGGER.Value = pData;
                program.V0CFEN_DTCANCEL.Value = pData;
                program.V0CFEN_DTPAGSUN.Value = pData;
                program.R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*38*/ program.R6300_00_SELECIONA_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ 
                program.V0TRBL_DTMOVTO.Value = pData;
                program.R6700_00_INSERT_TARIFA_BALCAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R8100_00_DECLARE_CBO_DB_DECLARE_1(); program.R8100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R7160_00_SELECT_V0RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ 
                program.V0BILH_DTCANCEL.Value = pData;
                program.R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*45*/ program.R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R7200_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R7210_00_DELETE_V0COMISSAO_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R7600_00_SELECT_V0BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/
                program.V0BILH_DTMOVTO.Value = pData;
                program.V0BILH_DTVENDA.Value = pData;
                program.R7650_00_INSERT_V0BILHETE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}