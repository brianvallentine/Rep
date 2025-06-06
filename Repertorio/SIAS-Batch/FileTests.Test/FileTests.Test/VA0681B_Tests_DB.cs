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
using static Code.VA0681B;

namespace FileTests.Test_DB
{
    [Collection("VA0681B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0681B_Tests_DB
    {

        [Fact]
        public static void VA0681B_Database()
        {
            var program = new VA0681B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0015_LER_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.WSIST_DTMOVABE.Value = "1992-04-06";
                program.M_0020_DECLARE_CURSOR_DB_DECLARE_1(); program.M_0020_DECLARE_CURSOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.Value = 1;
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.Value = 93010000890;
                program.M_0110_SELECT_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.Value = 1627;
                program.M_0120_SELECT_HISCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.Value = 850;
                program.COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.Value = 1;
                program.M_0130_SELECT_COBHISVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.Value = 82525370000026;
                program.COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.Value = 0;
                program.M_0135_SELECT_RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO.Value = 6 ;
                program.M_0140_SELECT_DEVOLVID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}