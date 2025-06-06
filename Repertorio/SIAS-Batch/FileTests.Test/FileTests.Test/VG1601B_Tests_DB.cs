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
using static Code.VG1601B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VG1601B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1601B_Tests_DB
    {

        [Fact]
        public static void VG1601B_Database()
        {
            var program = new VG1601B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_000_000_PRINCIPAL_DB_DECLARE_1(); program.M_000_000_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_010_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_011_000_LER_PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_050_000_PROCESSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_110_000_ACESSA_V1APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*8*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.Value = "2024-12-10";
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.Value = "2024-12-10";

                program.M_500_001_LOOP_GRAVA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_502_000_LER_V0SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_505_000_LER_V1SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_520_000_ACESSA_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_530_000_ATUALIZA_FONTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_830_000_ACESSA_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_830_000_ACESSA_V1MOEDA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}