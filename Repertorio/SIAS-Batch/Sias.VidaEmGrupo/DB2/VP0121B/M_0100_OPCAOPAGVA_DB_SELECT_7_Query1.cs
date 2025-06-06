using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0100_OPCAOPAGVA_DB_SELECT_7_Query1 : QueryBasis<M_0100_OPCAOPAGVA_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMVG + PRMAP
            INTO :V0HCOB-VLPRMTOT
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            AND NRPARCEL = 1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PRMVG + PRMAP
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND NRPARCEL = 1";

            return query;
        }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_OPCAOPAGVA_DB_SELECT_7_Query1 Execute(M_0100_OPCAOPAGVA_DB_SELECT_7_Query1 m_0100_OPCAOPAGVA_DB_SELECT_7_Query1)
        {
            var ths = m_0100_OPCAOPAGVA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_OPCAOPAGVA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_OPCAOPAGVA_DB_SELECT_7_Query1();
            var i = 0;
            dta.V0HCOB_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}