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
using Dclgens;
using Code;
using static Code.VE0125B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0125B_Tests_DB")]
    public class VE0125B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void VE0125B_Database()
        {
            var program = new VE0125B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.W_DATA_ULT_VE0125B.Value = pData;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0205_00_LER_RCAPCOMP_DB_DECLARE_1(); program.R0205_00_LER_RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0170_00_LER_CERTIFICADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0170_00_LER_CERTIFICADO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0200_00_LER_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0200_00_LER_RCAPS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0205_00_LER_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0350_00_DECLARE_ENDERECO_DB_DECLARE_1(); program.R0350_00_DECLARE_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0300_00_LER_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.Value = pData;
                program.R0450_00_OBTER_COBERTURA_DB_DECLARE_1(); program.R0450_00_OBTER_COBERTURA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0400_00_LER_SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.Value = pData;
                program.R0500_00_OBTER_OPCAOPAG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0570_00_LER_COMISSAO_DB_DECLARE_1(); program.R0570_00_LER_COMISSAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R6000_00_DECLARE_AGENCEF_DB_DECLARE_1(); program.R6000_00_DECLARE_AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0590_00_LER_COMPL_TERMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = pData;
                program.R1300_00_INSERT_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.R1350_00_UPDATE_RELATORIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}