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
using static Code.VF0853B;

namespace FileTests.Test_DB
{
    [Collection("VF0853B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VF0853B_Tests_DB
    {

        [Fact]
        public static void VF0853B_Database()
        {
            var program = new VF0853B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            program.V0PROP_DTPROXVEN.Value = fullDataMock;
            program.V0PROP_DTVENCTO.Value = fullDataMock;
            program.V0DIFP_DTVENCTO.Value = fullDataMock;
            program.V0RSAF_DTREFER.Value = fullDataMock;

            try
            { /*1*/
                program.R0000_00_PRINCIPAL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R0000_00_PRINCIPAL_DB_DECLARE_1();
                program.R0000_00_PRINCIPAL_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R1500_00_COMPOE_DIFERENCAS_DB_DECLARE_1();
                program.R1500_00_COMPOE_DIFERENCAS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R0000_00_PRINCIPAL_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R0000_00_PRINCIPAL_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.R1200_00_GERA_PARCELAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R1200_00_GERA_PARCELAS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.R1200_00_GERA_PARCELAS_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R1220_00_GERA_NUM_TITULO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.R1220_00_GERA_NUM_TITULO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.R1250_00_GERA_V0COMPTITVA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.V0HICB_DTVENCTO.Value = fullDataMock;

                program.R1300_00_GERA_DEBITO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.R1750_00_APROPRIA_DIFERENCAS_DB_DECLARE_1();
                program.R1750_00_APROPRIA_DIFERENCAS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.R1510_00_MONTA_DIFERENCA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.R1530_00_DESMEMBRA_DIFERENCA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.R1530_00_LOOP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*23*/
                program.R1600_00_VERIFICA_REPASSE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*24*/
                program.R1670_00_REPASSA_SAF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*25*/
                program.R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}