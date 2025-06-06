using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMOS
{
    public class R1600_00_LE_SINISCAU_DB_SELECT_1_Query1 : QueryBasis<R1600_00_LE_SINISCAU_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_GRUPO_CAUSA,
            COD_SUBGRUPO_CAUSA
            INTO :SINISCAU-COD-GRUPO-CAUSA,
            :SINISCAU-COD-SUBGRUPO-CAUSA
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE RAMO_EMISSOR = :SIMOVSIN-RAMO-EMISSOR
            AND COD_CAUSA = :SIMOVSIN-COD-CAUSA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_GRUPO_CAUSA
							,
											COD_SUBGRUPO_CAUSA
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE RAMO_EMISSOR = '{this.SIMOVSIN_RAMO_EMISSOR}'
											AND COD_CAUSA = '{this.SIMOVSIN_COD_CAUSA}'";

            return query;
        }
        public string SINISCAU_COD_GRUPO_CAUSA { get; set; }
        public string SINISCAU_COD_SUBGRUPO_CAUSA { get; set; }
        public string SIMOVSIN_RAMO_EMISSOR { get; set; }
        public string SIMOVSIN_COD_CAUSA { get; set; }

        public static R1600_00_LE_SINISCAU_DB_SELECT_1_Query1 Execute(R1600_00_LE_SINISCAU_DB_SELECT_1_Query1 r1600_00_LE_SINISCAU_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_LE_SINISCAU_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_LE_SINISCAU_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_LE_SINISCAU_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_COD_GRUPO_CAUSA = result[i++].Value?.ToString();
            dta.SINISCAU_COD_SUBGRUPO_CAUSA = result[i++].Value?.ToString();
            return dta;
        }

    }
}