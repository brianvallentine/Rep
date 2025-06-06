using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_13130_00_CBO_DB_SELECT_1_Query1 : QueryBasis<M_13130_00_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_CBO
            INTO :CBO-DESCR-CBO
            FROM SEGUROS.CBO
            WHERE COD_CBO = :CBO-COD-CBO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DESCR_CBO
											FROM SEGUROS.CBO
											WHERE COD_CBO = '{this.CBO_COD_CBO}'
											WITH UR";

            return query;
        }
        public string CBO_DESCR_CBO { get; set; }
        public string CBO_COD_CBO { get; set; }

        public static M_13130_00_CBO_DB_SELECT_1_Query1 Execute(M_13130_00_CBO_DB_SELECT_1_Query1 m_13130_00_CBO_DB_SELECT_1_Query1)
        {
            var ths = m_13130_00_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_13130_00_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_13130_00_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}