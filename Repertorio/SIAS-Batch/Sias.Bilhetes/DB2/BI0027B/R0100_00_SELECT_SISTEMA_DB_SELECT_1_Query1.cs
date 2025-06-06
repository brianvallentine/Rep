using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0027B
{
    public class R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            (DATA_MOV_ABERTO - 6 MONTHS),
            CURRENT DATE
            INTO :WHOST-DT-FIM,
            :WHOST-DT-MOV6MON,
            :WHOST-DT-HOJE
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'BI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											(DATA_MOV_ABERTO - 6 MONTHS)
							,
											CURRENT DATE
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'BI'
											WITH UR";

            return query;
        }
        public string WHOST_DT_FIM { get; set; }
        public string WHOST_DT_MOV6MON { get; set; }
        public string WHOST_DT_HOJE { get; set; }

        public static R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DT_FIM = result[i++].Value?.ToString();
            dta.WHOST_DT_MOV6MON = result[i++].Value?.ToString();
            dta.WHOST_DT_HOJE = result[i++].Value?.ToString();
            return dta;
        }

    }
}