using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 : QueryBasis<R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO,
            COD_MOEDA_SINI,
            NUM_APOLICE
            INTO :V0MSIN-NUM-SINISTRO,
            :V0MSIN-MOEDA-SINI,
            :V0MSIN-NUM-APOL
            FROM SEGUROS.V0MESTSINI
            WHERE NUM_APOL_SINISTRO = :V1CHSI-NUM-SINI
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
							,
											COD_MOEDA_SINI
							,
											NUM_APOLICE
											FROM SEGUROS.V0MESTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1CHSI_NUM_SINI}'
											WITH UR";

            return query;
        }
        public string V0MSIN_NUM_SINISTRO { get; set; }
        public string V0MSIN_MOEDA_SINI { get; set; }
        public string V0MSIN_NUM_APOL { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }

        public static R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 Execute(R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 r1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MSIN_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.V0MSIN_MOEDA_SINI = result[i++].Value?.ToString();
            dta.V0MSIN_NUM_APOL = result[i++].Value?.ToString();
            return dta;
        }

    }
}