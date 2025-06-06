using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1 : QueryBasis<R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_SUBGRUPO,
            COD_CLIENTE
            INTO :V0PROP-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-CODCLIEN
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											COD_CLIENTE
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.WS_NUM_CERTIFICADO}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0PROP_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string WS_NUM_CERTIFICADO { get; set; }

        public static R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1 Execute(R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1 r1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1)
        {
            var ths = r1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0PROP_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}