using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0127B
{
    public class M_0000_PRINCIPAL_DB_SELECT_5_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:WS-DATA-INI) + 1 MONTH - 1 DAY
            INTO :WS-DATA-FIM
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'CB'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.WS_DATA_INI}') + 1 MONTH - 1 DAY
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'CB'";

            return query;
        }
        public string WS_DATA_FIM { get; set; }
        public string WS_DATA_INI { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_5_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_5_Query1 m_0000_PRINCIPAL_DB_SELECT_5_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_5_Query1();
            var i = 0;
            dta.WS_DATA_FIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}