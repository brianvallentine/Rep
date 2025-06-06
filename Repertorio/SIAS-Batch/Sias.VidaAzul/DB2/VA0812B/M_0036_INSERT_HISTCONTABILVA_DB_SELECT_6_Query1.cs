using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1 : QueryBasis<M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST,
            NRTIT,
            DTVENCTO
            INTO :HCVA-OCORHIST,
            :HCVA-NRTIT,
            :HCVA-DTVENCTO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :HCTA-NRCERTIF
            AND NRPARCEL = :HCTA-NRPARCEL
            AND NRTIT = ( SELECT MAX(NRTIT)
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :HCTA-NRCERTIF
            AND NRPARCEL = :HCTA-NRPARCEL )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
							,
											NRTIT
							,
											DTVENCTO
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.HCTA_NRPARCEL}'
											AND NRTIT = ( SELECT MAX(NRTIT)
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.HCTA_NRPARCEL}' )
											WITH UR";

            return query;
        }
        public string HCVA_OCORHIST { get; set; }
        public string HCVA_NRTIT { get; set; }
        public string HCVA_DTVENCTO { get; set; }
        public string HCTA_NRCERTIF { get; set; }
        public string HCTA_NRPARCEL { get; set; }

        public static M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1 Execute(M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1 m_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1)
        {
            var ths = m_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1();
            var i = 0;
            dta.HCVA_OCORHIST = result[i++].Value?.ToString();
            dta.HCVA_NRTIT = result[i++].Value?.ToString();
            dta.HCVA_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}