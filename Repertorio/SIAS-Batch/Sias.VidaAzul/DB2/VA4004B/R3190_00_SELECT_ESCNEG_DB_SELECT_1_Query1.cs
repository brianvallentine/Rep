using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4004B
{
    public class R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1 : QueryBasis<R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESCNEG,
            REGIAO_ESCNEG,
            COD_FONTE
            INTO :V0ESCN-CODESC,
            :V0ESCN-NOMEESC,
            :V0ESCN-FONTE
            FROM SEGUROS.V0ESCNEG
            WHERE COD_ESCNEG = :WHOST-COD-ESCNEG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESCNEG
							,
											REGIAO_ESCNEG
							,
											COD_FONTE
											FROM SEGUROS.V0ESCNEG
											WHERE COD_ESCNEG = '{this.WHOST_COD_ESCNEG}'
											WITH UR";

            return query;
        }
        public string V0ESCN_CODESC { get; set; }
        public string V0ESCN_NOMEESC { get; set; }
        public string V0ESCN_FONTE { get; set; }
        public string WHOST_COD_ESCNEG { get; set; }

        public static R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1 Execute(R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1 r3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1)
        {
            var ths = r3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ESCN_CODESC = result[i++].Value?.ToString();
            dta.V0ESCN_NOMEESC = result[i++].Value?.ToString();
            dta.V0ESCN_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}