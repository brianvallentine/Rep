using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1466B
{
    public class R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_FONTE,
            A.COD_ESCNEG
            INTO :V0MALHA-CDFONTE,
            :V0MALHA-CDESCNEG
            FROM SEGUROS.V0AGENCIACEF A,
            SEGUROS.V0MALHACEF B
            WHERE A.COD_AGENCIA = :V0PROP-AGECOBR
            AND B.COD_SUREG = A.COD_ESCNEG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_FONTE
							,
											A.COD_ESCNEG
											FROM SEGUROS.V0AGENCIACEF A
							,
											SEGUROS.V0MALHACEF B
											WHERE A.COD_AGENCIA = '{this.V0PROP_AGECOBR}'
											AND B.COD_SUREG = A.COD_ESCNEG
											WITH UR";

            return query;
        }
        public string V0MALHA_CDFONTE { get; set; }
        public string V0MALHA_CDESCNEG { get; set; }
        public string V0PROP_AGECOBR { get; set; }

        public static R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 r1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MALHA_CDFONTE = result[i++].Value?.ToString();
            dta.V0MALHA_CDESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}