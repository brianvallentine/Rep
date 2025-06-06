using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1 : QueryBasis<M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT
            INTO :BANCOS-NRTIT
            FROM SEGUROS.V0BANCO
            WHERE BANCO = 104
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
											FROM SEGUROS.V0BANCO
											WHERE BANCO = 104";

            return query;
        }
        public string BANCOS_NRTIT { get; set; }

        public static M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1 Execute(M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1 m_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1)
        {
            var ths = m_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0010_LER_TITULO_V0BANCO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BANCOS_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}