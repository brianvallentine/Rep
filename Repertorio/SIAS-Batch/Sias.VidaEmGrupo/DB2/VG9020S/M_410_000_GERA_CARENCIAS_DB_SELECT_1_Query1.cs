using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1 : QueryBasis<M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :V0PROP-OCORHIST
            FROM SEGUROS.V0PROPOSTAVA
            WHERE
            NRCERTIF = :MNUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V0PROPOSTAVA
											WHERE
											NRCERTIF = '{this.MNUM_CERTIFICADO}'";

            return query;
        }
        public string V0PROP_OCORHIST { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1 Execute(M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1 m_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1)
        {
            var ths = m_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}