using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0078B
{
    public class R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            DATA_MOV_ABERTO - 10 DAYS
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :WS-DATA-MOVT-10
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'BI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO - 10 DAYS
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'BI'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WS_DATA_MOVT_10 { get; set; }

        public static R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 r0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.WS_DATA_MOVT_10 = result[i++].Value?.ToString();
            return dta;
        }

    }
}