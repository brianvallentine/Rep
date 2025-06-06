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
using static Code.RE0002S;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("RE0002S_Tests_DB")]
    public class RE0002S_Tests_DB
    {

        [Fact]
        public static void RE0002S_Database()
        {
            var program = new RE0002S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE.Value = 1;
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO.Value = 2;
                program.MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO.Value = 3;
                program.R0800_00_DECLARE_ITENS_ENDO_DB_DECLARE_1(); program.R0800_00_DECLARE_ITENS_ENDO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_APOLICE.Value = 1;
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_NUM_ENDOSSO.Value = 2;
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM.Value = 3;
                program.R1100_00_DECLARE_MRAPOCOB_DB_DECLARE_1(); program.R1100_00_DECLARE_MRAPOCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE.Value = 1;
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO.Value = 2;
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA.Value = 3;
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA.Value = 4;
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.R2100_00_DECLARE_APOLICOR_DB_DECLARE_1(); program.R2100_00_DECLARE_APOLICOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_MODALI_COBERTURA.Value = 1;
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_RAMO_COBERTURA.Value = 2;
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_COBERTURA.Value = 3;
                program.MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO.Value = 4;
                program.MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_COD_EMPRESA.Value = 5 ;
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_VERSAO.Value = 6;
                program.R1400_00_SELECT_PROD_COBT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.MR022.DCLMR_APOL_ITEM_EMPR.MR022_NUM_APOLICE.Value = 1;
                program.MR022.DCLMR_APOL_ITEM_EMPR.MR022_NUM_ENDOSSO.Value = 1;
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM.Value = 1;
                program.R1700_SELECT_MR022_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_APOLICE.Value = 1;
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ENDOSSO.Value = 2;
                program.MRPROCOB.DCLMR_PRODUTO_COBER.MRPROCOB_COD_PRODUTO.Value = 3;
                program.MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_NUM_ITEM.Value =4 ;
                program.R1800_SELECT_MRAPOITE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_NUM_APOLICE.Value = 123;
                program.R2300_00_SELECT_APOLCOSS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 123;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 123;
                program.R2500_00_SELECT_PARCEHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}