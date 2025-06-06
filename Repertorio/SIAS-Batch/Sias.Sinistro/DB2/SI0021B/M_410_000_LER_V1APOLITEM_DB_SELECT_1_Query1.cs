using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1 : QueryBasis<M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_ITEM
            INTO :V1APIT-DESCRITEM
            FROM SEGUROS.V1APOLITEM
            WHERE NUM_APOLICE = :V1MEST-NUM-APOL
            AND NRENDOS = :V1MEST-NRENDOS
            AND NRITEM = :V1MEST-NRITEM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_ITEM
											FROM SEGUROS.V1APOLITEM
											WHERE NUM_APOLICE = '{this.V1MEST_NUM_APOL}'
											AND NRENDOS = '{this.V1MEST_NRENDOS}'
											AND NRITEM = '{this.V1MEST_NRITEM}'";

            return query;
        }
        public string V1APIT_DESCRITEM { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_NRENDOS { get; set; }
        public string V1MEST_NRITEM { get; set; }

        public static M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1 Execute(M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1 m_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1)
        {
            var ths = m_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APIT_DESCRITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}