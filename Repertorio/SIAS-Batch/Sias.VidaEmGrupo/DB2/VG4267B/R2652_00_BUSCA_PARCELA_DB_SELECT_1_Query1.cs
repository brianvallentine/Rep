using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTVENCTO
            INTO :V0PARC-DTVENCTO-ORIG
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0PARC-NRCERTIF
            AND NRPARCEL = :V0PARC-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0PARC_NRCERTIF}'
											AND NRPARCEL = '{this.V0PARC_NRPARCEL}'";

            return query;
        }
        public string V0PARC_DTVENCTO_ORIG { get; set; }
        public string V0PARC_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1 Execute(R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1 r2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_DTVENCTO_ORIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}