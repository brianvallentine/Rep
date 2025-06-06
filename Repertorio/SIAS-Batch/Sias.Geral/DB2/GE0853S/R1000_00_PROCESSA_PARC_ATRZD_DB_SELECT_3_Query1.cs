using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1 : QueryBasis<R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :V0MOVI-COUNT
            FROM SEGUROS.V0MOVIMENTO
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            AND DATA_INCLUSAO IS NULL
            AND DATA_AVERBACAO IS NOT NULL
            AND COD_OPERACAO BETWEEN 400 AND 499
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0MOVIMENTO
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'
											AND DATA_INCLUSAO IS NULL
											AND DATA_AVERBACAO IS NOT NULL
											AND COD_OPERACAO BETWEEN 400 AND 499
											WITH UR";

            return query;
        }
        public string V0MOVI_COUNT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1 Execute(R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1 r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1)
        {
            var ths = r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0MOVI_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}