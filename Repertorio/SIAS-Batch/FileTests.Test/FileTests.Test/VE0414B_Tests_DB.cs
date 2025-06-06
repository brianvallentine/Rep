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
using static Code.VE0414B;

namespace FileTests.Test_DB
{
    [Collection("VE0414B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VE0414B_Tests_DB
    {

        [Fact]
        public static void VE0414B_Database()
        {
            var program = new VE0414B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = fullDataMock;

                program.R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();
                program.R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1();
                program.R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R0300_00_OBTEM_NUMERACAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.AREA_DE_WORK.WHOST_PROXIMA_DATA.Value = fullDataMock;

                program.R0410_00_CALCULA_DIA_UTIL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R0900_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();
                program.R0900_00_DECLARE_V0RELATORIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R2300_00_MONTA_LINHAS_DB_DECLARE_1();
                program.R2300_00_MONTA_LINHAS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R1300_00_SELECT_V0ENDERECO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.R1400_00_SELECT_PERIPGTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.R1600_00_SELECT_TITFEDCAP_DB_CALL_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.R1940_00_SELECT_HISCOBPR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.R1940_00_SELECT_HISCOBPR_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.R2301_00_SELECT_V0CLIENTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.R2305_00_SELECT_V0CONDTEC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.R2305_00_SELECT_V0CONDTEC_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.R4000_00_GERA_OBJETO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.R4000_02_INSERT_OBJETO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.R5000_00_ATU_RELATORIOS_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*23*/
                program.R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}