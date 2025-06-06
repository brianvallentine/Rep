using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(IMP_SEGURADA_VAR),+0),
            VALUE(SUM(PRM_TARIFARIO_VAR),+0)
            INTO :APOLICOB-IMP-SEGURADA-VAR,
            :APOLICOB-PRM-TARIFARIO-VAR
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND RAMO_COBERTURA = :GE397-COD-RAMO-COBER
            AND NUM_ITEM = 0
            AND COD_COBERTURA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(IMP_SEGURADA_VAR)
							,+0)
							,
											VALUE(SUM(PRM_TARIFARIO_VAR)
							,+0)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND RAMO_COBERTURA = '{this.GE397_COD_RAMO_COBER}'
											AND NUM_ITEM = 0
											AND COD_COBERTURA = 0";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string GE397_COD_RAMO_COBER { get; set; }

        public static R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1 r2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_VAR = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}