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
    public class M_575_000_LER_TFONTE_DB_SELECT_1_Query1 : QueryBasis<M_575_000_LER_TFONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE
            INTO :TFONTE-NOMEFTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :MEST-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.MEST_FONTE}'";

            return query;
        }
        public string TFONTE_NOMEFTE { get; set; }
        public string MEST_FONTE { get; set; }

        public static M_575_000_LER_TFONTE_DB_SELECT_1_Query1 Execute(M_575_000_LER_TFONTE_DB_SELECT_1_Query1 m_575_000_LER_TFONTE_DB_SELECT_1_Query1)
        {
            var ths = m_575_000_LER_TFONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_575_000_LER_TFONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_575_000_LER_TFONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.TFONTE_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}