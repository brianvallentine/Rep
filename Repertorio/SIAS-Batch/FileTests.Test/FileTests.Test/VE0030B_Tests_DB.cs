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
using static Code.VE0030B;

namespace FileTests.Test_DB
{
    [Collection("VE0030B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class VE0030B_Tests_DB
    {

        [Fact]
        public static void VE0030B_Database()
        {
            var program = new VE0030B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var fullHoraMock = DateTime.Now.AddHours(-5).ToString("HH:mm:ss");


            try
            { /*1*/
                program.V1SIST_DTMOVABE.Value = fullDataMock;
                program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1(); program.R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.V1ENDO_DTINIVIG.Value = fullDataMock;
                program.V1ENDO_DTTERVIG.Value = fullDataMock;
                program.R0230_00_DECLER_V1ENDOSSO_DB_DECLARE_1(); program.R0230_00_DECLER_V1ENDOSSO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.V0TERMO_DT_ADESAO.Value = fullDataMock;
                program.V0TERMO_DTADESAO_3M.Value = fullDataMock;
                program.R0225_00_LER_V0TERMOADESAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0340_00_SEL_COMISSAO_ESTORNAR_DB_DECLARE_1(); program.R0340_00_SEL_COMISSAO_ESTORNAR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0280_00_LER_V1AGENCIACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0290_00_LER_V1MALHACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.V0PRODC_DTOPER.Value = fullDataMock;
                program.V0PRODC_DT_REFER.Value = fullDataMock;
                program.R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1(); program.R0900_00_DECLARE_V1PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.V0COMI_DATCLO.Value = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                program.V0COMI_DATSEL.Value = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");


                program.R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.V1PROD_DTINIVIG.Value = fullDataMock;
                program.V1PROD_DTTERVIG.Value = fullDataMock;
                program.R0380_00_LER_V0PRODESCNEG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2100_00_SELECT_NUMERO_AES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.V1HISP_DTVENCTO.Value = fullDataMock;
                program.R3100_00_ACUMULA_PREMIOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R3200_00_ACUMULA_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.V1HISP_DTVENCTO.Value = fullDataMock;
                program.V0HISP_DTMOVTO.Value = fullDataMock;
                program.V0HISP_DTVENCTO.Value = fullDataMock;
                program.V0HISP_DTQITBCO.Value = fullDataMock;
                program.V0HISP_HORAOPER.Value = fullHoraMock;
                program.R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}