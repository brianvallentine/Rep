using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0032B
{
    public class R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 : QueryBasis<R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX
            INTO :V0COBA-IMPMORACID,
            :V0COBA-PRMAP
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP)
            AND MODALI_COBERTURA = 0
            AND COD_COBERTURA = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA IN (81
							, '{this.V1PAR_RAMO_AP}')
											AND MODALI_COBERTURA = 0
											AND COD_COBERTURA = 1";

            return query;
        }
        public string V0COBA_IMPMORACID { get; set; }
        public string V0COBA_PRMAP { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string V1PAR_RAMO_AP { get; set; }

        public static R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 Execute(R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 r6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1)
        {
            var ths = r6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0COBA_IMPMORACID = result[i++].Value?.ToString();
            dta.V0COBA_PRMAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}