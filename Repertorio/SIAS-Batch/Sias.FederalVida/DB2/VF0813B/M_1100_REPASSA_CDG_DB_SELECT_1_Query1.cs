using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1100_REPASSA_CDG_DB_SELECT_1_Query1 : QueryBasis<M_1100_REPASSA_CDG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0RCDG-SITUACAO
            FROM SEGUROS.V0REPASSECDG
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTREFER = :V0RCDG-DTREFER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0REPASSECDG
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTREFER = '{this.V0RCDG_DTREFER}'";

            return query;
        }
        public string V0RCDG_SITUACAO { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RCDG_DTREFER { get; set; }

        public static M_1100_REPASSA_CDG_DB_SELECT_1_Query1 Execute(M_1100_REPASSA_CDG_DB_SELECT_1_Query1 m_1100_REPASSA_CDG_DB_SELECT_1_Query1)
        {
            var ths = m_1100_REPASSA_CDG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_REPASSA_CDG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_REPASSA_CDG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCDG_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}