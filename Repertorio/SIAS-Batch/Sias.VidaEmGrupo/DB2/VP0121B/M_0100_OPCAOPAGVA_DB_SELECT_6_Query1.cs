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
    public class M_0100_OPCAOPAGVA_DB_SELECT_6_Query1 : QueryBasis<M_0100_OPCAOPAGVA_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPRMTOT
            INTO :V0HCOB-VLPRMTOT
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            AND NRPARCEL = :V0COBER-MINOCOR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VLPRMTOT
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND NRPARCEL = '{this.V0COBER_MINOCOR}'";

            return query;
        }
        public string V0HCOB_VLPRMTOT { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string V0COBER_MINOCOR { get; set; }

        public static M_0100_OPCAOPAGVA_DB_SELECT_6_Query1 Execute(M_0100_OPCAOPAGVA_DB_SELECT_6_Query1 m_0100_OPCAOPAGVA_DB_SELECT_6_Query1)
        {
            var ths = m_0100_OPCAOPAGVA_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_OPCAOPAGVA_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_OPCAOPAGVA_DB_SELECT_6_Query1();
            var i = 0;
            dta.V0HCOB_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}