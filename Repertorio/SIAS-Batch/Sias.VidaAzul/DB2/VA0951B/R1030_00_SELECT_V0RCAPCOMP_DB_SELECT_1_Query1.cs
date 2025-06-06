using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0951B
{
    public class R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRRCAP ,
            DATARCAP
            INTO :V0RCAPCOMP-NRRCAP ,
            :V0RCAPCOMP-DATARCAP
            FROM SEGUROS.V0RCAPCOMP
            WHERE FONTE = :V0RCAP-COD-FONTE
            AND NRRCAP = :V0RCAP-NUM-RCAP
            AND NRRCAPCO = 0
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRRCAP 
							,
											DATARCAP
											FROM SEGUROS.V0RCAPCOMP
											WHERE FONTE = '{this.V0RCAP_COD_FONTE}'
											AND NRRCAP = '{this.V0RCAP_NUM_RCAP}'
											AND NRRCAPCO = 0
											AND SITUACAO = '0'";

            return query;
        }
        public string V0RCAPCOMP_NRRCAP { get; set; }
        public string V0RCAPCOMP_DATARCAP { get; set; }
        public string V0RCAP_COD_FONTE { get; set; }
        public string V0RCAP_NUM_RCAP { get; set; }

        public static R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 Execute(R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 r1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAPCOMP_NRRCAP = result[i++].Value?.ToString();
            dta.V0RCAPCOMP_DATARCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}