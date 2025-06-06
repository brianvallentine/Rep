using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1 : QueryBasis<R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NRPARCEL),01)
            INTO :WHOST-NRPARCEL
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND SITUACAO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NRPARCEL)
							,01)
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND SITUACAO = '1'";

            return query;
        }
        public string WHOST_NRPARCEL { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1 Execute(R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1 r1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NRPARCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}