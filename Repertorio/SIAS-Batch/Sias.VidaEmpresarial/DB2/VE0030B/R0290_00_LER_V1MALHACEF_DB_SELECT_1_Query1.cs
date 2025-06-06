using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1 : QueryBasis<R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUREG,
            COD_FONTE
            INTO :V1MALHA-COD-SUREG,
            :V1MALHA-COD-FONTE
            FROM SEGUROS.V1MALHACEF
            WHERE COD_SUREG = :V1AGENC-COD-SUREG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUREG
							,
											COD_FONTE
											FROM SEGUROS.V1MALHACEF
											WHERE COD_SUREG = '{this.V1AGENC_COD_SUREG}'
											WITH UR";

            return query;
        }
        public string V1MALHA_COD_SUREG { get; set; }
        public string V1MALHA_COD_FONTE { get; set; }
        public string V1AGENC_COD_SUREG { get; set; }

        public static R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1 Execute(R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1 r0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1)
        {
            var ths = r0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MALHA_COD_SUREG = result[i++].Value?.ToString();
            dta.V1MALHA_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}