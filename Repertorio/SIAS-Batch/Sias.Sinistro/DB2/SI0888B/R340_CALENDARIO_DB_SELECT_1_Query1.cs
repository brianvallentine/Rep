using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R340_CALENDARIO_DB_SELECT_1_Query1 : QueryBasis<R340_CALENDARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTH_ULT_DIA_MES
            INTO
            :HOST-DTH-ULT-DIA-MES
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTH_ULT_DIA_MES
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string HOST_DTH_ULT_DIA_MES { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R340_CALENDARIO_DB_SELECT_1_Query1 Execute(R340_CALENDARIO_DB_SELECT_1_Query1 r340_CALENDARIO_DB_SELECT_1_Query1)
        {
            var ths = r340_CALENDARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R340_CALENDARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R340_CALENDARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_DTH_ULT_DIA_MES = result[i++].Value?.ToString();
            return dta;
        }

    }
}