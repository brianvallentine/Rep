using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R0020_00_PROCESSA_DB_SELECT_3_Query1 : QueryBasis<R0020_00_PROCESSA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERIPGTO,
            DIA_DEBITO,
            OPCAOPAG
            INTO :V0OPCP-PERIPGTO,
            :V0OPCP-DIADEB,
            :V0OPCP-OPCAOPAG
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERIPGTO
							,
											DIA_DEBITO
							,
											OPCAOPAG
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_DIADEB { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static R0020_00_PROCESSA_DB_SELECT_3_Query1 Execute(R0020_00_PROCESSA_DB_SELECT_3_Query1 r0020_00_PROCESSA_DB_SELECT_3_Query1)
        {
            var ths = r0020_00_PROCESSA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_PROCESSA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_PROCESSA_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_DIADEB = result[i++].Value?.ToString();
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            return dta;
        }

    }
}