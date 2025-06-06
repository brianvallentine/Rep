using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1 : QueryBasis<M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = 23
            AND DTINIVIG = :SISTEMA-DTTERCOT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = 23
											AND DTINIVIG = '{this.SISTEMA_DTTERCOT}'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string SISTEMA_DTTERCOT { get; set; }

        public static M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1 Execute(M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1 m_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1)
        {
            var ths = m_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0010_SELECT_SISTEMAS_DB_SELECT_4_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}