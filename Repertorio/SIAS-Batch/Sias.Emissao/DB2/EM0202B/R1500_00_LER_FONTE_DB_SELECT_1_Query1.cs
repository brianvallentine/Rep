using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1500_00_LER_FONTE_DB_SELECT_1_Query1 : QueryBasis<R1500_00_LER_FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE
            INTO :V1FONT-NOMEFTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V1EDIA-ORGAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V1EDIA_ORGAO}'";

            return query;
        }
        public string V1FONT_NOMEFTE { get; set; }
        public string V1EDIA_ORGAO { get; set; }

        public static R1500_00_LER_FONTE_DB_SELECT_1_Query1 Execute(R1500_00_LER_FONTE_DB_SELECT_1_Query1 r1500_00_LER_FONTE_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_LER_FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_LER_FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_LER_FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FONT_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}