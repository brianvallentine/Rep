using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 : QueryBasis<R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0HICB-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0PROP-NRPARCEL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0PROP_NRPARCEL}'";

            return query;
        }
        public string V0HICB_DTVENCTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 Execute(R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1)
        {
            var ths = r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0HICB_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}