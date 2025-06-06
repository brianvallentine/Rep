using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0809B
{
    public class M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :V1SEGU-CODCLIEN
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_CERTIFICADO = :V1SEGU-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V1SEGU_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V1SEGU_CODCLIEN { get; set; }
        public string V1SEGU_NRCERTIF { get; set; }

        public static M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 Execute(M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 m_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SEGU_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}