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
using static Code.VG9550B;

namespace FileTests.Test_DB
{
    [Collection("VG9550B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG9550B_Tests_DB
    {

        [Fact]
        public static void VG9550B_Database()
        {
            var program = new VG9550B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0010_00_PROC_CANCELAMENTOS_DB_DECLARE_1(); program.R0010_00_PROC_CANCELAMENTOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1000_00_ALT_END_SEGURADOS_DB_DECLARE_1(); program.R1000_00_ALT_END_SEGURADOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0040_00_VERIFICA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0060_00_CANCELA_SEGURO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0060_10_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0060_10_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/

                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.Value = "2000-10-10";
                program.DATA_REFERENCIA.Value = "2000-10-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.Value = "2000-10-10";


                program.R0060_10_CONTINUA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0060_00_CANCELA_SEGURO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0060_00_CANCELA_SEGURO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0060_00_CANCELA_SEGURO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0060_00_CANCELA_SEGURO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1050_00_PROCESSA_ENDERECO_DB_DECLARE_1(); program.R1050_00_PROCESSA_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2070_00_INSERT_ENDERECO_SEG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}