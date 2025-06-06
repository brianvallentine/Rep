using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.CODPRODU
            INTO :V1ENDO-CODPRODU
            FROM SEGUROS.V0HISTCOBVA A,
            SEGUROS.V0PROPOSTAVA B
            WHERE A.NRTIT = :V0MCOB-NRTIT
            AND B.NRCERTIF = A.NRCERTIF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.CODPRODU
											FROM SEGUROS.V0HISTCOBVA A
							,
											SEGUROS.V0PROPOSTAVA B
											WHERE A.NRTIT = '{this.V0MCOB_NRTIT}'
											AND B.NRCERTIF = A.NRCERTIF
											WITH UR";

            return query;
        }
        public string V1ENDO_CODPRODU { get; set; }
        public string V0MCOB_NRTIT { get; set; }

        public static R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 Execute(R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 r3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3400_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}