using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1 : QueryBasis<B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTH_ULT_DIA_MES
            INTO :CALENDAR-DTH-ULT-DIA-MES
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTH_ULT_DIA_MES
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.CALENDAR_DATA_CALENDARIO}'
											WITH UR";

            return query;
        }
        public string CALENDAR_DTH_ULT_DIA_MES { get; set; }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1 Execute(B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1 b3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1)
        {
            var ths = b3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DTH_ULT_DIA_MES = result[i++].Value?.ToString();
            return dta;
        }

    }
}