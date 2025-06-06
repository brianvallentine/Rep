using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0065B
{
    public class R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1 : QueryBasis<R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO + 1 DAYS)
            ,(DATA_CALENDARIO + 1 MONTH)
            INTO :WSHOST-DATA-INIVIGENCIA
            ,:WSHOST-DATA-TERVIGENCIA
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO + 1 DAYS)
											,(DATA_CALENDARIO + 1 MONTH)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string WSHOST_DATA_INIVIGENCIA { get; set; }
        public string WSHOST_DATA_TERVIGENCIA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1 Execute(R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1 r0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1)
        {
            var ths = r0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WSHOST_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSHOST_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}