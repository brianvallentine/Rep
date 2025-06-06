using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0812B
{
    public class M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :SUBG-COD-CLIENTE
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :RELSIN-APOLICE
            AND COD_SUBGRUPO = :MEST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.RELSIN_APOLICE}'
											AND COD_SUBGRUPO = '{this.MEST_CODSUBES}'";

            return query;
        }
        public string SUBG_COD_CLIENTE { get; set; }
        public string RELSIN_APOLICE { get; set; }
        public string MEST_CODSUBES { get; set; }

        public static M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1 Execute(M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1 m_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = m_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_570_000_LER_SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBG_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}