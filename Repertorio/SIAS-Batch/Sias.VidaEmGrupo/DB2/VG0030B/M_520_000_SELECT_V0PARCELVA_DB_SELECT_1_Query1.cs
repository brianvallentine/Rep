using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1 : QueryBasis<M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG,
            PRMAP
            INTO :V0PARC-PRMVG,
            :V0PARC-PRMAP
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :MNUM-CERTIFICADO
            AND NRPARCEL = :V0PROP-NRPARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMVG
							,
											PRMAP
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.MNUM_CERTIFICADO}'
											AND NRPARCEL = '{this.V0PROP_NRPARCELA}'
											WITH UR";

            return query;
        }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_NRPARCELA { get; set; }

        public static M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1 Execute(M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1 m_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1)
        {
            var ths = m_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}