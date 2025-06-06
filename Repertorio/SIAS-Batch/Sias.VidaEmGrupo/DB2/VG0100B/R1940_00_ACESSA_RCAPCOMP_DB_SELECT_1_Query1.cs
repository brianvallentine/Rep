using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCOAVISO, AGEAVISO
            INTO :V1RCAP-BCOAVISO, :V1RCAP-AGEAVISO
            FROM SEGUROS.V1RCAPCOMP
            WHERE NRRCAP = :V1SOLF-NUM-RCAP
            AND NRRCAPCO = 0
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BCOAVISO
							, AGEAVISO
											FROM SEGUROS.V1RCAPCOMP
											WHERE NRRCAP = '{this.V1SOLF_NUM_RCAP}'
											AND NRRCAPCO = 0
											AND SITUACAO = '0'";

            return query;
        }
        public string V1RCAP_BCOAVISO { get; set; }
        public string V1RCAP_AGEAVISO { get; set; }
        public string V1SOLF_NUM_RCAP { get; set; }

        public static R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1 Execute(R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1 r1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = r1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RCAP_BCOAVISO = result[i++].Value?.ToString();
            dta.V1RCAP_AGEAVISO = result[i++].Value?.ToString();
            return dta;
        }

    }
}