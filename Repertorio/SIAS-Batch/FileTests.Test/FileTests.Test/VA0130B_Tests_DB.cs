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
using static Code.VA0130B;

namespace FileTests.Test_DB
{
    [Collection("VA0130B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0130B_Tests_DB
    {

        [Fact]
        public static void VA0130B_Database()
        {
            var program = new VA0130B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try 
            { /*1*/
                program.LK_PARAMETRO.LK_DATA_INI_PROC.Value = "2025-01-29";
                program.M_0010_SELECT_SISTEMAS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0010_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0020_CARGA_INDICE_DB_DECLARE_1(); program.M_0020_CARGA_INDICE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0109_DECLARE_PROPOSTAS_DB_DECLARE_1(); program.M_0109_DECLARE_PROPOSTAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0010_SELECT_SISTEMAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0010_SELECT_SISTEMAS_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0040_SELECT_VG_INDICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0045_SELECT_COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_0050_DATA_ENCERRAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0410_00_DECLARE_VGHISTRAMCOB_DB_DECLARE_1(); program.M_0410_00_DECLARE_VGHISTRAMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_0110_FETCH_PROPOSTAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_0130_VERIFICA_MUDANCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_0130_VERIFICA_MUDANCA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_0300_CORRIGE_IGPM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*24*/ 
                program.SISTEMA_DTMOVABE.Value = "2025-01-29";
                program.CLIENT_DTNASC.Value = "2025-01-29";
                program.SISTEMA_DTMAXALTIGPM.Value = "2025-01-29";
                program.COBERP_DTINIVIG.Value = "2025-01-29";
                program.M_0300_PROPAUTOM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_0300_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_0300_CORRIGE_IGPM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_0300_CORRIGE_IGPM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_0300_CORRIGE_IGPM_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_0500_00_DECLARE_VGHISTACESSCOB_DB_DECLARE_1(); program.M_0500_00_DECLARE_VGHISTACESSCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_2200_00_DECLARE_VGPLANACESS_DB_DECLARE_1(); program.M_2200_00_DECLARE_VGPLANACESS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*35*/
                program.SISTEMA_DTMOVABE.Value = "2025-01-29";
                program.CLIENT_DTNASC.Value = "2025-01-29";
                program.PROPVA_DTMOVTO.Value = "2025-01-29";
                program.M_1000_PROPAUTOM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.M_1000_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.M_1000_MUDA_FAIXA_ETARIA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.M_1000_MUDA_FAIXA_ETARIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*42*/
                program.SISTEMA_DTMOVABE.Value = "2025-01-29";
                program.CLIENT_DTNASC.Value = "2025-01-29";
                program.DATA_MOVIMENTO.Value = "2025-01-29";
                program.M_2000_PROPAUTOM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.M_2000_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.M_2000_MUDA_FAIXA_ETARIA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.M_2000_MUDA_FAIXA_ETARIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.M_2500_SELECT_V0COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}