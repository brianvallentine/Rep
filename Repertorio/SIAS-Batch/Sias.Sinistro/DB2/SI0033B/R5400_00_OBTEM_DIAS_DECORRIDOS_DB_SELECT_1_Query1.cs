using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0033B
{
    public class R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 : QueryBasis<R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-COUNT
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO >=
            :SIDOCACO-DATA-MOVTO-DOCACO
            AND DATA_CALENDARIO <= :SISTEMAS-DATA-MOV-ABERTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO >=
											'{this.SIDOCACO_DATA_MOVTO_DOCACO}'
											AND DATA_CALENDARIO <= '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 Execute(R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 r5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1)
        {
            var ths = r5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5400_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}