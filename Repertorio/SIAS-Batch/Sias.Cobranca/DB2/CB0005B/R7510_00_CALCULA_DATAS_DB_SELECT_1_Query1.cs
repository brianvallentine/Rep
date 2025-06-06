using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1 : QueryBasis<R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:V0ENDO-DTINIVIG) + 1 DAY
            INTO :WS-INI-SEG-COMI
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'BI'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.V0ENDO_DTINIVIG}') + 1 DAY
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'BI'";

            return query;
        }
        public string WS_INI_SEG_COMI { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }

        public static R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1 Execute(R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1 r7510_00_CALCULA_DATAS_DB_SELECT_1_Query1)
        {
            var ths = r7510_00_CALCULA_DATAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7510_00_CALCULA_DATAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_INI_SEG_COMI = result[i++].Value?.ToString();
            return dta;
        }

    }
}