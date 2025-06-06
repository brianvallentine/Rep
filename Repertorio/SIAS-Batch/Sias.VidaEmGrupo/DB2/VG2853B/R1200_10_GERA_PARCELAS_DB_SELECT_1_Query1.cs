using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2853B
{
    public class R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG + PRMAP - VLMULTA
            INTO :V0PARC-PRMTOTANT
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0PROP-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG + PRMAP - VLMULTA
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0PROP_NRPARCEL}'";

            return query;
        }
        public string V0PARC_PRMTOTANT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1 Execute(R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1 r1200_10_GERA_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1200_10_GERA_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMTOTANT = result[i++].Value?.ToString();
            return dta;
        }

    }
}