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
    public class M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRPARCE
            INTO :V0PROP-NRPARCELA
            FROM SEGUROS.V0PROPOSTAVA
            WHERE NRCERTIF = :MNUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRPARCE
											FROM SEGUROS.V0PROPOSTAVA
											WHERE NRCERTIF = '{this.MNUM_CERTIFICADO}'";

            return query;
        }
        public string V0PROP_NRPARCELA { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 Execute(M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 m_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = m_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_NRPARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}