using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1200_00_GERA_PARCELAS_Query8 : QueryBasis<R1200_00_GERA_PARCELAS_Query8>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :V0MOVF-COUNT
            FROM SEGUROS.V0MOVFDCAPVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0MOVFDCAPVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string V0MOVF_COUNT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1200_00_GERA_PARCELAS_Query8 Execute(R1200_00_GERA_PARCELAS_Query8 r1200_00_GERA_PARCELAS_Query8)
        {
            var ths = r1200_00_GERA_PARCELAS_Query8;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_GERA_PARCELAS_Query8 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_GERA_PARCELAS_Query8();
            var i = 0;
            dta.V0MOVF_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}