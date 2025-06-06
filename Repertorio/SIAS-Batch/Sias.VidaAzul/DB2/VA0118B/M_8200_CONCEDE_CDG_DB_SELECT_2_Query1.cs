using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8200_CONCEDE_CDG_DB_SELECT_2_Query1 : QueryBasis<M_8200_CONCEDE_CDG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTREFER
            INTO :REPCDG-DTREF
            FROM SEGUROS.V0REPASSECDG
            WHERE CODCLIEN = :PROPVA-CODCLIEN
            AND DTREFER = :REPCDG-DTREF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTREFER
											FROM SEGUROS.V0REPASSECDG
											WHERE CODCLIEN = '{this.PROPVA_CODCLIEN}'
											AND DTREFER = '{this.REPCDG_DTREF}'";

            return query;
        }
        public string REPCDG_DTREF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }

        public static M_8200_CONCEDE_CDG_DB_SELECT_2_Query1 Execute(M_8200_CONCEDE_CDG_DB_SELECT_2_Query1 m_8200_CONCEDE_CDG_DB_SELECT_2_Query1)
        {
            var ths = m_8200_CONCEDE_CDG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8200_CONCEDE_CDG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8200_CONCEDE_CDG_DB_SELECT_2_Query1();
            var i = 0;
            dta.REPCDG_DTREF = result[i++].Value?.ToString();
            return dta;
        }

    }
}