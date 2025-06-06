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
using static Code.VG9521B;

namespace FileTests.Test_DB
{
    [Collection("VG9521B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG9521B_Tests_DB
    {

        [Fact]
        public static void VG9521B_Database()
        {
            var program = new VG9521B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0000_00_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0050_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0060_00_INTEGRA_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0060_01_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0060_00_INTEGRA_VG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0060_01_CLIENTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0060_09_CRIA_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0060_09_CRIA_CLIENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0060_09_CRIA_CLIENTE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0060_10_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0060_09_CRIA_CLIENTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0060_10_CONTINUA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0060_10_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0060_10_CONTINUA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0060_09_CRIA_CLIENTE_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0060_10_CONTINUA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R7310_00_MAX_GECLIMOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R7320_00_SELECT_GECLIMOV_DB_DECLARE_1(); program.R7320_00_SELECT_GECLIMOV_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R7400_00_INSERT_GECLIMOV_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}