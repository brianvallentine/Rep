using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 : QueryBasis<R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTVENCTO
            INTO
            :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0HCTB-NRCERTIF
            AND NRPARCEL = :V0HCTB-NRPARCEL
            FETCH FIRST 1 ROWS ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0HCTB_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCTB_NRPARCEL}'
											FETCH FIRST 1 ROWS ONLY";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0HCTB_NRPARCEL { get; set; }

        public static R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 Execute(R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 r0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1)
        {
            var ths = r0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}