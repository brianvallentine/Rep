using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_MOV_ABERTO ,
            DATA_MOV_ABERTO - 01 DAYS,
            DATA_MOV_ABERTO + 30 DAYS,
            DATA_MOV_ABERTO + 40 DAYS
            INTO
            :WS-DATA-MOV-ABERTO,
            :WS-DATA-MOV-ABERTO-1,
            :SISTEMAS-DATA-MOV-ABERTO-30,
            :SISTEMAS-DATA-MOV-ABERTO-40
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VA'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_MOV_ABERTO 
							,
											DATA_MOV_ABERTO - 01 DAYS
							,
											DATA_MOV_ABERTO + 30 DAYS
							,
											DATA_MOV_ABERTO + 40 DAYS
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VA'
											WITH UR";

            return query;
        }
        public string WS_DATA_MOV_ABERTO { get; set; }
        public string WS_DATA_MOV_ABERTO_1 { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO_30 { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO_40 { get; set; }

        public static R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.WS_DATA_MOV_ABERTO_1 = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO_30 = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO_40 = result[i++].Value?.ToString();
            return dta;
        }

    }
}