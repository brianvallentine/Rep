using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-ERROS
            FROM SEGUROS.V0ERROSPROPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND COD_ERRO IN (1803, 1804)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.V0ERROSPROPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND COD_ERRO IN (1803
							, 1804)";

            return query;
        }
        public string WHOST_ERROS { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1 r1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_ERROS = result[i++].Value?.ToString();
            return dta;
        }

    }
}