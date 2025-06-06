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
    public class M_8300_CONCEDE_SAF_DB_SELECT_2_Query1 : QueryBasis<M_8300_CONCEDE_SAF_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTREF
            INTO :REPSAF-DTREF
            FROM SEGUROS.V0HISTREPSAF
            WHERE CODCLIEN = :PROPVA-CODCLIEN
            AND DTREF = :REPSAF-DTREF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTREF
											FROM SEGUROS.V0HISTREPSAF
											WHERE CODCLIEN = '{this.PROPVA_CODCLIEN}'
											AND DTREF = '{this.REPSAF_DTREF}'";

            return query;
        }
        public string REPSAF_DTREF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }

        public static M_8300_CONCEDE_SAF_DB_SELECT_2_Query1 Execute(M_8300_CONCEDE_SAF_DB_SELECT_2_Query1 m_8300_CONCEDE_SAF_DB_SELECT_2_Query1)
        {
            var ths = m_8300_CONCEDE_SAF_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8300_CONCEDE_SAF_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8300_CONCEDE_SAF_DB_SELECT_2_Query1();
            var i = 0;
            dta.REPSAF_DTREF = result[i++].Value?.ToString();
            return dta;
        }

    }
}