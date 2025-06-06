using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_FONTE
            INTO :V1MCEF-COD-FONTE
            FROM SEGUROS.V1AGENCIACEF A,
            SEGUROS.V1MALHACEF B
            WHERE A.COD_ESCNEG > 99
            AND A.COD_ESCNEG < 1000
            AND A.COD_ESCNEG = B.COD_SUREG
            AND A.COD_AGENCIA = :V0HIST-AGECOBR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_FONTE
											FROM SEGUROS.V1AGENCIACEF A
							,
											SEGUROS.V1MALHACEF B
											WHERE A.COD_ESCNEG > 99
											AND A.COD_ESCNEG < 1000
											AND A.COD_ESCNEG = B.COD_SUREG
											AND A.COD_AGENCIA = '{this.V0HIST_AGECOBR}'";

            return query;
        }
        public string V1MCEF_COD_FONTE { get; set; }
        public string V0HIST_AGECOBR { get; set; }

        public static R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MCEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}