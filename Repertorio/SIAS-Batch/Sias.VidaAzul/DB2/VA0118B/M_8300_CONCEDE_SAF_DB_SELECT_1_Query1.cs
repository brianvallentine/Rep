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
    public class M_8300_CONCEDE_SAF_DB_SELECT_1_Query1 : QueryBasis<M_8300_CONCEDE_SAF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG
            INTO :SAFCOB-DTINIVIG
            FROM SEGUROS.V0SAFCOBER
            WHERE CODCLIEN = :PROPVA-CODCLIEN
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
											FROM SEGUROS.V0SAFCOBER
											WHERE CODCLIEN = '{this.PROPVA_CODCLIEN}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string SAFCOB_DTINIVIG { get; set; }
        public string PROPVA_CODCLIEN { get; set; }

        public static M_8300_CONCEDE_SAF_DB_SELECT_1_Query1 Execute(M_8300_CONCEDE_SAF_DB_SELECT_1_Query1 m_8300_CONCEDE_SAF_DB_SELECT_1_Query1)
        {
            var ths = m_8300_CONCEDE_SAF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8300_CONCEDE_SAF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8300_CONCEDE_SAF_DB_SELECT_1_Query1();
            var i = 0;
            dta.SAFCOB_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}