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
using static Code.VG0133B;

namespace FileTests.Test_DB
{
    [Collection("VG0133B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0133B_Tests_DB
    {

        [Fact]
        public static void VG0133B_Database()
        {
            var program = new VG0133B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.R_DATA_AUMENTO.Value = "2000-10-10";
            program.R_DATA_AUMENTO.Value = "2000-10-10";

            program.MDATA_MOVIMENTO.Value = "2000-10-10";
            program.MDATA_REFERENCIA.Value = "2000-10-10";
            program.MDATA_FATURA.Value = "2000-10-10";
            program.MDATA_NASCIMENTO.Value = "2000-10-10";
            program.MDATA_INCLUSAO.Value = "2000-10-10";
            program.MDATA_ADMISSAO.Value = "2000-10-10";
            program.MDATA_AVERBACAO.Value = "2000-10-10";
            program.MDATA_OPERACAO.Value = "2000-10-10";


            try { /*1*/ program.M_030_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_040_000_LER_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_050_000_DECLARA_RELATORIO_DB_DECLARE_1(); program.M_050_000_DECLARA_RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1(); program.M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_070_000_VE_FATURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_070_000_VE_FATURAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_070_000_VE_FATURAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_230_000_SELECT_V1COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_270_000_ACESSA_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_270_000_ACESSA_V1MOEDA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_300_000_INSERE_V0MOVIMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_306_000_ACESSA_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_307_000_ATUALIZA_FONTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_700_000_UPDATE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_800_000_BUSCA_MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_810_000_ACESSA_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_810_000_ACESSA_V1MOEDA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}