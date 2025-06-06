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
using static Code.SI0048B;

namespace FileTests.Test_DB
{
    [Collection("SI0048B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0048B_Tests_DB
    {

        [Fact]
        public static void SI0048B_Database()
        {
            var program = new SI0048B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0500_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0600_00_LE_RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.R0900_00_DECLARA_LISTA_DB_DECLARE_1(); program.R0900_00_DECLARA_LISTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try {
                /*5*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 23;
                program.R1000_00_BUSCA_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.Value = 1;
                program.R1100_00_BUSCA_SINISCAU_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.R1200_00_BUSCA_DATAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 12;
                program.R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 12;
                program.R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 12;
                program.R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO.Value = 123;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA.Value = 1;
                program.SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG.Value = 1; 
                program.R2210_00_ACESSA_APOLICRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ 
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 12;
                program.R2220_00_ACESSA_SINIITEM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ 
                program.SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.Value = 1;
                program.R2230_00_ACESSA_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 1;
                program.R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 12;
                program.R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 12;
                program.R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 12;
                program.R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1 ;
                program.R1600_00_BUSCA_SEGURADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ 
                program.SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.Value = 1 ;
                program.R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}