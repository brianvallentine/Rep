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
using static Code.RG0805B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("RG0805B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class RG0805B_Tests_DB
    {

        [Fact]
        public static void RG0805B_Database()
        {
            var program = new RG0805B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DELETE_V0RELATORIO_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V0RELA_CODUSU.Value = "RG0805B";
                program.V0RELA_DT_SOLIC.Value = "2020-01-31";
                program.V0RELA_IDSISTEM.Value = "RG";
                program.V0RELA_CODRELAT.Value = "RG0051B1";
                program.V0RELA_NRCOPIAS.Value = 0;
                program.V0RELA_QTDE.Value = 0;
                program.V0RELA_PERI_INIC.Value = "2020-01-31";
                program.V0RELA_PERI_FINAL.Value = "2020-01-31";
                program.V0RELA_DATA_REFER.Value = "2020-01-31";
                program.V0RELA_MES_REFER.Value = 1;
                program.V0RELA_ANO_REFER.Value = 2020;
                program.V0RELA_ORGAO.Value = 0;
                program.V0RELA_FONTE.Value = 0;
                program.V0RELA_CODPDT.Value = 0;
                program.V0RELA_RAMO.Value = 0;
                program.V0RELA_MODALID.Value = 0;
                program.V0RELA_CONGENER.Value = 0;
                program.V0RELA_NUM_APOL.Value = 0;
                program.V0RELA_NRENDOS.Value = 0;
                program.V0RELA_NRPARCEL.Value = 0;
                program.V0RELA_NRCERTIF.Value = 0;
                program.V0RELA_NRTIT.Value = 0;
                program.V0RELA_CODSUBES.Value = 0;
                program.V0RELA_OPERACAO.Value = 0;
                program.V0RELA_COD_PLANO.Value = 0;
                program.V0RELA_ENDS_LIDER.Value = "";
                program.V0RELA_NRPARC_LID.Value = 0;
                program.V0RELA_NUM_SINIST.Value = 0;
                program.V0RELA_NSINI_LID.Value = "";
                program.V0RELA_NUM_ORDEM.Value = 0;
                program.V0RELA_CODUNIMO.Value = 0 ;
                program.V0RELA_CORRECAO.Value = "";
                program.V0RELA_SITUACAO.Value = "";
                program.V0RELA_PRV_DEF.Value = "";
                program.V0RELA_ANAL_RESU.Value = "";
                program.V0RELA_COD_EMPR.Value = 0;
                program.VIND_COD_EMPR.Value = 0;
                program.V0RELA_PERI_RENOV.Value = 0;
                program.VIND_PERI_RENOV.Value = 0;
                program.V0RELA_PCT_AUMENTO.Value = 0;
                program.VIND_PCT_AUMENTO.Value = 0;
                program.R0500_00_INSERT_V0RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}